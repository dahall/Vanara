namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>
	/// <para>Represents a virtual adapter.</para>
	/// <para>This interface extends <c>ID3D12Device5</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12device6
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Device6")]
	[ComImport, Guid("c70b221b-40e4-4a17-89af-025a0727a6dc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Device6 : ID3D12Device5
	{
		/// <summary>Gets application-defined data from a device object.</summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> that is associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <i>pData</i> points to, and on output
		/// contains the size, in bytes, of the amount of data that <b>GetPrivateData</b> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// A pointer to a memory block that receives the data from the device object if <i>pDataSize</i> points to a value that specifies a
		/// buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// If the data returned is a pointer to an <c>IUnknown</c>, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] UINT *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Sets application-defined data to a device object and associates that data with an application-defined <b>GUID</b>.</summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> to associate with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size in bytes of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>
		/// A pointer to a memory block that contains the data to be stored with this device object. If <i>pData</i> is <b>NULL</b>,
		/// <i>DataSize</i> must also be 0, and any data that was previously associated with the <b>GUID</b> specified in <i>guid</i> will
		/// be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// Rather than using the Direct3D 11 debug object naming scheme of calling <b>ID3D12Object::SetPrivateData</b> using
		/// <b>WKPDID_D3DDebugObjectName</b> with an ASCII name, call <c>ID3D12Object::SetName</c> with a UNICODE name.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] UINT DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associates an <c>IUnknown</c>-derived interface with the device object, and associates that interface with an
		/// application-defined <b>GUID</b>.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> to associate with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const <c>IUnknown</c>*</b></para>
		/// <para>
		/// A pointer to the <c>IUnknown</c>-derived interface to be associated with the device object. Its reference count is incremented
		/// when set, and its reference count is decremented when either the <c>ID3D12Object</c> is destroyed, or when the data is
		/// overwritten by calling <c>SetPrivateData</c> or <b>SetPrivateDataInterface</b> with the same <b>GUID</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 return codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object? pData);

		/// <summary>Associates a name with the device object. This name is for use in debug diagnostics and tools.</summary>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>A <b>NULL</b>-terminated <b>UNICODE</b> string that contains the name to associate with the device object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method takes UNICODE names.</para>
		/// <para>
		/// Note that this is simply a convenience wrapper around <c>ID3D12Object::SetPrivateData</c> with
		/// <b>WKPDID_D3DDebugObjectNameW</b>. Therefore names which are set with <c>SetName</c> can be retrieved with
		/// <c>ID3D12Object::GetPrivateData</c> with the same GUID. Additionally, D3D12 supports narrow strings for names, using the
		/// <b>WKPDID_D3DDebugObjectName</b> GUID directly instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setname HRESULT SetName( [in] LPCWSTR Name );
		[PreserveSig]
		new HRESULT SetName([MarshalAs(UnmanagedType.LPWStr)] string Name);

		/// <summary>Reports the number of physical adapters (nodes) that are associated with this device.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of physical adapters (nodes) that this device has.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getnodecount UINT GetNodeCount();
		[PreserveSig]
		new uint GetNodeCount();

		/// <summary>
		/// <para>Creates a command queue.</para>
		/// <para>Also see <c>ID3D12Device9::CreateCommandQueue1</c>.</para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_COMMAND_QUEUE_DESC</c>*</b></para>
		/// <para>Specifies a <b>D3D12_COMMAND_QUEUE_DESC</b> that describes the command queue.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier (GUID) for the command queue interface. See <b>Remarks</b>. An input parameter.</para>
		/// </param>
		/// <param name="ppCommandQueue">
		/// <para>Type: [out] <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12CommandQueue</c> interface for the command queue.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the command queue. See <c>Direct3D 12 return
		/// codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the command queue can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12CommandQueue) will get the <b>GUID</b> of the interface to a command queue.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandqueue HRESULT CreateCommandQueue(
		// const D3D12_COMMAND_QUEUE_DESC *pDesc, REFIID riid, void **ppCommandQueue );
		[PreserveSig]
		new HRESULT CreateCommandQueue(in D3D12_COMMAND_QUEUE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppCommandQueue);

		/// <summary>Creates a command allocator object.</summary>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// A <c>D3D12_COMMAND_LIST_TYPE</c>-typed value that specifies the type of command allocator to create. The type of command
		/// allocator can be the type that records either direct command lists or bundles.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the command allocator interface ( <c>ID3D12CommandAllocator</c>). The
		/// <b>REFIID</b>, or <b>GUID</b>, of the interface to the command allocator can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12CommandAllocator) will get the <b>GUID</b> of the interface to a command allocator.
		/// </para>
		/// </param>
		/// <param name="ppCommandAllocator">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12CommandAllocator</c> interface for the command allocator.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the command allocator. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The device creates command lists from the command allocator. Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12Device::CreateCommandAllocator</b> as follows:</para>
		/// <para>
		/// <c>ThrowIfFailed(pDevice-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT, IID_PPV_ARGS(&amp;m_commandAllocator)));
		/// ThrowIfFailed(pDevice-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_BUNDLE, IID_PPV_ARGS(&amp;m_bundleAllocator)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandallocator HRESULT
		// CreateCommandAllocator( [in] D3D12_COMMAND_LIST_TYPE type, REFIID riid, [out] void **ppCommandAllocator );
		[PreserveSig]
		new HRESULT CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE type, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppCommandAllocator);

		/// <summary>Creates a graphics pipeline state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure that describes graphics pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>). The <b>REFIID</b>,
		/// or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// The pipeline state object is an immutable state object. It contains no methods.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-creategraphicspipelinestate HRESULT
		// CreateGraphicsPipelineState( [in] const D3D12_GRAPHICS_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreateGraphicsPipelineState(in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>Creates a compute pipeline state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structure that describes compute pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>). The <b>REFIID</b>,
		/// or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// The pipeline state object is an immutable state object. It contains no methods.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcomputepipelinestate HRESULT
		// CreateComputePipelineState( [in] const D3D12_COMPUTE_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreateComputePipelineState(in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>Creates a command list.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node (the device's
		/// physical adapter) for which to create the command list. Each bit in the mask corresponds to a single node. Only one bit must be
		/// set. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>Specifies the type of command list to create.</para>
		/// </param>
		/// <param name="pCommandAllocator">
		/// <para>Type: <b><c>ID3D12CommandAllocator</c>*</b></para>
		/// <para>A pointer to the command allocator object from which the device creates command lists.</para>
		/// </param>
		/// <param name="pInitialState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>
		/// An optional pointer to the pipeline state object that contains the initial pipeline state for the command list. If it is
		/// <c>nullptr</c>, then the runtime sets a dummy initial pipeline state, so that drivers don't have to deal with undefined state.
		/// The overhead for this is low, particularly for a command list, for which the overall cost of recording the command list likely
		/// dwarfs the cost of a single initial state setting. So there's little cost in not setting the initial pipeline state parameter,
		/// if doing so is inconvenient.
		/// </para>
		/// <para>
		/// For bundles, on the other hand, it might make more sense to try to set the initial state parameter (since bundles are likely
		/// smaller overall, and can be reused frequently).
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the command list interface to return in ppCommandList.</para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12CommandList</c> or <c>ID3D12GraphicsCommandList</c>
		/// interface for the command list.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the command list.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>The device creates command lists from the command allocator.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandlist HRESULT CreateCommandList( [in]
		// UINT nodeMask, [in] D3D12_COMMAND_LIST_TYPE type, [in] ID3D12CommandAllocator *pCommandAllocator, [in, optional]
		// ID3D12PipelineState *pInitialState, [in] REFIID riid, [out] void **ppCommandList );
		[PreserveSig]
		new HRESULT CreateCommandList(uint nodeMask, D3D12_COMMAND_LIST_TYPE type, [In] ID3D12CommandAllocator pCommandAllocator, [In, Optional] ID3D12PipelineState? pInitialState,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppCommandList);

		/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
		/// <param name="Feature">
		/// <para>Type: <b><c>D3D12_FEATURE</c></b></para>
		/// <para>A constant from the <c>D3D12_FEATURE</c> enumeration describing the feature(s) that you want to query for support.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// A pointer to a data structure that corresponds to the value of the <i>Feature</i> parameter. To determine the corresponding data
		/// structure for each constant, see <c>D3D12_FEATURE</c>.
		/// </para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the structure pointed to by the <i>pFeatureSupportData</i> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns <b>S_OK</b> if successful. Returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// <i>pFeatureSupportData</i> parameter or if a size mismatch is detected for the <i>FeatureSupportDataSize</i> parameter.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As a usage example, to check for ray tracing support, specify the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS5</c> structure in the
		/// <i>pFeatureSupportData</i> parameter. When the function completes successfully, access the <i>RaytracingTier</i> field (which
		/// specifies the supported ray tracing tier) of the now-populated <b>D3D12_FEATURE_DATA_D3D12_OPTIONS5</b> structure.
		/// </para>
		/// <para>For more info, see <c>Capability Querying</c>.</para>
		/// <para><c></c><c></c><c></c> Hardware support for DXGI Formats</para>
		/// <para>To view tables of DXGI formats and hardware features, refer to:</para>
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
		/// <description><c>Format Support for Direct3D Feature Level 10.1 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format Support for Direct3D Feature Level 10.0 Hardware</c></description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>The <c>D3D1211on12</c> sample uses <b>ID3D12Device::CheckFeatureSupport</b> as follows:</para>
		/// <para>
		/// <c>inline UINT8 D3D12GetFormatPlaneCount( _In_ ID3D12Device* pDevice, DXGI_FORMAT Format ) { D3D12_FEATURE_DATA_FORMAT_INFO
		/// formatInfo = {Format}; if (FAILED(pDevice-&gt;CheckFeatureSupport(D3D12_FEATURE_FORMAT_INFO, &amp;formatInfo,
		/// sizeof(formatInfo)))) { return 0; } return formatInfo.PlaneCount; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-checkfeaturesupport HRESULT CheckFeatureSupport(
		// D3D12_FEATURE Feature, [in, out] void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D12_FEATURE Feature, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a descriptor heap object.</summary>
		/// <param name="pDescriptorHeapDesc">
		/// <para>Type: <b>const <c>D3D12_DESCRIPTOR_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DESCRIPTOR_HEAP_DESC</c> structure that describes the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the descriptor heap interface. See Remarks. An input parameter.</para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the descriptor heap. <i>ppvHeap</i> can be NULL, to enable capability
		/// testing. When <i>ppvHeap</i> is NULL, no object will be created and S_FALSE will be returned when <i>pDescriptorHeapDesc</i> is valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the descriptor heap object. See <c>Direct3D
		/// 12 Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the descriptor heap can be obtained by using the __uuidof() macro. For
		/// example, __uuidof( <c>ID3D12DescriptorHeap</c>) will get the <b>GUID</b> of the interface to a descriptor heap.
		///  Examples The <c>D3D12HelloWorld</c> sample uses <b>ID3D12Device::CreateDescriptorHeap</b> as follows:</para>
		/// <para>Describe and create a render target view (RTV) descriptor heap.</para>
		/// <para>
		/// <c>// Create descriptor heaps. { // Describe and create a render target view (RTV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// rtvHeapDesc = {}; rtvHeapDesc.NumDescriptors = FrameCount; rtvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV; rtvHeapDesc.Flags
		/// = D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;rtvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_rtvHeap))); m_rtvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV); } // Create frame resources. {
		/// CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); // Create a RTV for each frame. for
		/// (UINT n = 0; n &lt; FrameCount; n++) { ThrowIfFailed(m_swapChain-&gt;GetBuffer(n, IID_PPV_ARGS(&amp;m_renderTargets[n])));
		/// m_device-&gt;CreateRenderTargetView(m_renderTargets[n].Get(), nullptr, rtvHandle); rtvHandle.Offset(1, m_rtvDescriptorSize); }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createdescriptorheap HRESULT
		// CreateDescriptorHeap( [in] const D3D12_DESCRIPTOR_HEAP_DESC *pDescriptorHeapDesc, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateDescriptorHeap(in D3D12_DESCRIPTOR_HEAP_DESC pDescriptorHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>
		/// Gets the size of the handle increment for the given type of descriptor heap. This value is typically used to increment a handle
		/// into a descriptor array by the correct amount.
		/// </summary>
		/// <param name="DescriptorHeapType">
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to get the size of the handle
		/// increment for.
		/// </param>
		/// <returns>Returns the size of the handle increment for the given type of descriptor heap, including any necessary padding.</returns>
		/// <remarks>
		/// <para>
		/// The descriptor size returned by this method is used as one input to the helper structures <c>CD3DX12_CPU_DESCRIPTOR_HANDLE</c>
		/// and <c>CD3DX12_GPU_DESCRIPTOR_HANDLE</c>.
		///  Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12Device::GetDescriptorHandleIncrementSize</b> as follows:</para>
		/// <para>
		/// Create the descriptor heap for the resources. The <c>m_rtvDescriptorSize</c> variable stores the render target view descriptor
		/// handle increment size, and is used in the <b>Create frame resources</b> section of the code.
		/// </para>
		/// <para>
		/// <c>// Create descriptor heaps. { // Describe and create a render target view (RTV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// rtvHeapDesc = {}; rtvHeapDesc.NumDescriptors = FrameCount; rtvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV; rtvHeapDesc.Flags
		/// = D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;rtvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_rtvHeap))); // Describe and create a depth stencil view (DSV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// dsvHeapDesc = {}; dsvHeapDesc.NumDescriptors = 1; dsvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_DSV; dsvHeapDesc.Flags =
		/// D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;dsvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_dsvHeap))); // Describe and create a constant buffer view (CBV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// cbvHeapDesc = {}; cbvHeapDesc.NumDescriptors = CbvCountPerFrame * FrameCount; cbvHeapDesc.Type =
		/// D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV; cbvHeapDesc.Flags = D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE;
		/// ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;cbvHeapDesc, IID_PPV_ARGS(&amp;m_cbvHeap))); // Describe and create a heap
		/// for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1; queryHeapDesc.Type =
		/// D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc,
		/// IID_PPV_ARGS(&amp;m_queryHeap))); m_rtvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV); m_cbvSrvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV); } // Create frame resources. {
		/// CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); // Create a RTV and a command
		/// allocator for each frame. for (UINT n = 0; n &lt; FrameCount; n++) { ThrowIfFailed(m_swapChain-&gt;GetBuffer(n,
		/// IID_PPV_ARGS(&amp;m_renderTargets[n]))); m_device-&gt;CreateRenderTargetView(m_renderTargets[n].Get(), nullptr, rtvHandle);
		/// rtvHandle.Offset(1, m_rtvDescriptorSize); ThrowIfFailed(m_device-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT,
		/// IID_PPV_ARGS(&amp;m_commandAllocators[n]))); } }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getdescriptorhandleincrementsize UINT
		// GetDescriptorHandleIncrementSize( [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType );
		[PreserveSig]
		new uint GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType);

		/// <summary>Creates a root signature layout.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set bits to identify the nodes (the device's
		/// physical adapters) to which the root signature is to apply. Each bit in the mask corresponds to a single node. Refer to
		/// <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="pBlobWithRootSignature">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>A pointer to the source data for the serialized signature.</para>
		/// </param>
		/// <param name="blobLengthInBytes">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>The size, in bytes, of the block of memory that <i>pBlobWithRootSignature</i> points to.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the root signature interface. See Remarks. An input parameter.</para>
		/// </param>
		/// <param name="ppvRootSignature">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the root signature.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// <para>This method returns <b>E_INVALIDARG</b> if the blob that <i>pBlobWithRootSignature</i> points to is invalid.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application procedurally generates a <c>D3D12_ROOT_SIGNATURE_DESC</c> data structure, it must pass a pointer to this
		/// <b>D3D12_ROOT_SIGNATURE_DESC</b> in a call to <c>D3D12SerializeRootSignature</c> to make the serialized form. The application
		/// then passes the serialized form to <i>pBlobWithRootSignature</i> in a call to <b>ID3D12Device::CreateRootSignature</b>.
		/// </para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the root signature layout can be obtained by using the __uuidof() macro.
		/// For example, __uuidof( <c>ID3D12RootSignature</c>) will get the <b>GUID</b> of the interface to a root signature.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12Device::CreateRootSignature</b> as follows:</para>
		/// <para>Create an empty root signature.</para>
		/// <para>
		/// <c>CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc; rootSignatureDesc.Init(0, nullptr, 0, nullptr,
		/// D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT); ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
		/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
		/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(), IID_PPV_ARGS(&amp;m_rootSignature)));</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createrootsignature HRESULT CreateRootSignature(
		// [in] UINT nodeMask, [in] const void *pBlobWithRootSignature, [in] SIZE_T blobLengthInBytes, REFIID riid, [out] void
		// **ppvRootSignature );
		[PreserveSig]
		new HRESULT CreateRootSignature(uint nodeMask, [In] IntPtr pBlobWithRootSignature, [In] SizeT blobLengthInBytes, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppvRootSignature);

		/// <summary>Creates a constant-buffer view for accessing resource data.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_CONSTANT_BUFFER_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_CONSTANT_BUFFER_VIEW_DESC</c> structure that describes the constant-buffer view.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the constant-buffer view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createconstantbufferview void
		// CreateConstantBufferView( [in, optional] const D3D12_CONSTANT_BUFFER_VIEW_DESC *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE
		// DestDescriptor );
		[PreserveSig]
		new void CreateConstantBufferView([In, Optional] StructPointer<D3D12_CONSTANT_BUFFER_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the shader resource.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c> structure that describes the shader-resource view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and for buffers SRVs target a full buffer and are typed (not raw or structured), and for textures SRVs target a full texture,
		/// all mips and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// Describes the CPU descriptor handle that represents the shader-resource view. This handle can be created in a shader-visible or
		/// non-shader-visible descriptor heap.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c></c><c></c><c></c> Processing YUV 4:2:0 video formats</para>
		/// <para>
		/// An app must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling
		/// <b>CreateShaderResourceView</b> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a
		/// 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes
		/// (together) maps only the U and V planes as a single resource view.
		/// </para>
		/// <para>YUV 4:2:0 formats are listed in <c>DXGI_FORMAT</c>. Examples The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12Device::CreateShaderResourceView</b> as follows:</para>
		/// <para>Describe and create two shader resource views based on one description.</para>
		/// <para>
		/// <c>D3D12_SHADER_RESOURCE_VIEW_DESC srvDesc = {}; srvDesc.Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING;
		/// srvDesc.Format = DXGI_FORMAT_UNKNOWN; srvDesc.ViewDimension = D3D12_SRV_DIMENSION_BUFFER; srvDesc.Buffer.FirstElement = 0;
		/// srvDesc.Buffer.NumElements = ParticleCount; srvDesc.Buffer.StructureByteStride = sizeof(Particle); srvDesc.Buffer.Flags =
		/// D3D12_BUFFER_SRV_FLAG_NONE; CD3DX12_CPU_DESCRIPTOR_HANDLE srvHandle0(m_srvUavHeap-&gt;GetCPUDescriptorHandleForHeapStart(),
		/// SrvParticlePosVelo0 + index, m_srvUavDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// srvHandle1(m_srvUavHeap-&gt;GetCPUDescriptorHandleForHeapStart(), SrvParticlePosVelo1 + index, m_srvUavDescriptorSize);
		/// m_device-&gt;CreateShaderResourceView(m_particleBuffer0[index].Get(), &amp;srvDesc, srvHandle0);
		/// m_device-&gt;CreateShaderResourceView(m_particleBuffer1[index].Get(), &amp;srvDesc, srvHandle1);</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview void
		// CreateShaderResourceView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_SHADER_RESOURCE_VIEW_DESC *pDesc,
		// [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateShaderResourceView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_SHADER_RESOURCE_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a view for unordered accessing.</summary>
		/// <param name="pResource">
		/// <para>Type: [in, optional] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the unordered access.</para>
		/// <para>At least one of <i>pResource</i> or <i>pDesc</i> must be provided.</para>
		/// <para>
		/// A null <i>pResource</i> is used to initialize a null descriptor, which guarantees Direct3D 11-like null binding behavior
		/// (reading 0s, writes are discarded), but must have a valid <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pCounterResource">
		/// <para>Type: [in, optional] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>The <c>ID3D12Resource</c> for the counter (if any) associated with the UAV.</para>
		/// <para>
		/// If <i>pCounterResource</i> is not specified, then the <b>CounterOffsetInBytes</b> member of the <c>D3D12_BUFFER_UAV</c>
		/// structure must be 0.
		/// </para>
		/// <para>
		/// If <i>pCounterResource</i> is specified, then there is a counter associated with the UAV, and the runtime performs validation of
		/// the following requirements:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The <b>StructureByteStride</b> member of the <c>D3D12_BUFFER_UAV</c> structure must be greater than 0.</description>
		/// </item>
		/// <item>
		/// <description>The format must be DXGI_FORMAT_UNKNOWN.</description>
		/// </item>
		/// <item>
		/// <description>The D3D12_BUFFER_UAV_FLAG_RAW flag (a <c>D3D12_BUFFER_UAV_FLAGS</c> enumeration constant) must not be set.</description>
		/// </item>
		/// <item>
		/// <description>Both of the resources ( <i>pResource</i> and <i>pCounterResource</i>) must be buffers.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The <b>CounterOffsetInBytes</b> member of the <c>D3D12_BUFFER_UAV</c> structure must be a multiple of
		/// **D3D12_UAV_COUNTER_PLACEMENT_ALIGNMENT** (4096), and must be within the range of the counter resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><i>pResource</i> cannot be NULL</description>
		/// </item>
		/// <item>
		/// <description><i>pDesc</i> cannot be NULL.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in, optional] <b>const <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure that describes the unordered-access view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and for buffers UAVs target a full buffer and are typed, and for textures UAVs target the first mip and all array slices. Not
		/// all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the unordered-access view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createunorderedaccessview void
		// CreateUnorderedAccessView( ID3D12Resource *pResource, ID3D12Resource *pCounterResource, const D3D12_UNORDERED_ACCESS_VIEW_DESC
		// *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateUnorderedAccessView([In, Optional] ID3D12Resource? pResource, [In, Optional] ID3D12Resource? pCounterResource,
			[In, Optional] StructPointer<D3D12_UNORDERED_ACCESS_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the render target.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RENDER_TARGET_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure that describes the render-target view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and RTVs target the first mip and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the destination where the newly-created render target view will reside.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createrendertargetview void
		// CreateRenderTargetView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_RENDER_TARGET_VIEW_DESC *pDesc, [in]
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateRenderTargetView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_RENDER_TARGET_VIEW_DESC> pDesc,
			[In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a depth-stencil view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the depth stencil.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure that describes the depth-stencil view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and DSVs target the first mip and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the depth-stencil view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createdepthstencilview void
		// CreateDepthStencilView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_DEPTH_STENCIL_VIEW_DESC *pDesc, [in]
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateDepthStencilView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_DEPTH_STENCIL_VIEW_DESC> pDesc,
			[In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Create a sampler object that encapsulates sampling information for a texture.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_SAMPLER_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SAMPLER_DESC</c> structure that describes the sampler.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the sampler.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createsampler void CreateSampler( [in] const
		// D3D12_SAMPLER_DESC *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateSampler(in D3D12_SAMPLER_DESC pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Copies descriptors from a source to a destination.</summary>
		/// <param name="NumDestDescriptorRanges">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of destination descriptor ranges to copy to.</para>
		/// </param>
		/// <param name="pDestDescriptorRangeStarts">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>An array of <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> objects to copy to.</para>
		/// <para>All the destination and source descriptors must be in heaps of the same <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>.</para>
		/// </param>
		/// <param name="pDestDescriptorRangeSizes">
		/// <para>Type: <b>const <c>UINT</c>*</b></para>
		/// <para>An array of destination descriptor range sizes to copy to.</para>
		/// </param>
		/// <param name="NumSrcDescriptorRanges">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of source descriptor ranges to copy from.</para>
		/// </param>
		/// <param name="pSrcDescriptorRangeStarts">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>An array of <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> objects to copy from.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// All elements in the pSrcDescriptorRangeStarts parameter must be in a non shader-visible descriptor heap. This is because
		/// shader-visible descriptor heaps may be created in <b>WRITE_COMBINE</b> memory or GPU local memory, which is prohibitively slow
		/// to read from. If your application manages descriptor heaps via copying the descriptors required for a given pass or frame from
		/// local "storage" descriptor heaps to the GPU-bound descriptor heap, use shader-opaque heaps for the storage heaps and copy into
		/// the GPU-visible heap as required.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pSrcDescriptorRangeSizes">
		/// <para>Type: <b>const <c>UINT</c>*</b></para>
		/// <para>An array of source descriptor range sizes to copy from.</para>
		/// </param>
		/// <param name="DescriptorHeapsType">
		/// <para>Type: <b><c>D3D12_DESCRIPTOR_HEAP_TYPE</c></b></para>
		/// <para>
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to copy with. This is required as
		/// different descriptor types may have different sizes.
		/// </para>
		/// <para>Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Where applicable, prefer <c><b>ID3D12Device::CopyDescriptorsSimple</b></c> to this method. It can have a better CPU cache miss
		/// rate due to the linear nature of the copy.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-copydescriptors void CopyDescriptors( [in] UINT
		// NumDestDescriptorRanges, [in] const D3D12_CPU_DESCRIPTOR_HANDLE *pDestDescriptorRangeStarts, [in, optional] const UINT
		// *pDestDescriptorRangeSizes, [in] UINT NumSrcDescriptorRanges, [in] const D3D12_CPU_DESCRIPTOR_HANDLE *pSrcDescriptorRangeStarts,
		// [in, optional] const UINT *pSrcDescriptorRangeSizes, [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType );
		[PreserveSig]
		new void CopyDescriptors(int NumDestDescriptorRanges, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_CPU_DESCRIPTOR_HANDLE[] pDestDescriptorRangeStarts,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? pDestDescriptorRangeSizes, int NumSrcDescriptorRanges,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D12_CPU_DESCRIPTOR_HANDLE[] pSrcDescriptorRangeStarts,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[]? pSrcDescriptorRangeSizes, D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType);

		/// <summary>Copies descriptors from a source to a destination.</summary>
		/// <param name="NumDescriptors">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of descriptors to copy.</para>
		/// </param>
		/// <param name="DestDescriptorRangeStart">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> that describes the destination descriptors to start to copy to.</para>
		/// <para>The destination and source descriptors must be in heaps of the same <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>.</para>
		/// </param>
		/// <param name="SrcDescriptorRangeStart">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> that describes the source descriptors to start to copy from.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// The SrcDescriptorRangeStart parameter must be in a non shader-visible descriptor heap. This is because shader-visible descriptor
		/// heaps may be created in <b>WRITE_COMBINE</b> memory or GPU local memory, which is prohibitively slow to read from. If your
		/// application manages descriptor heaps via copying the descriptors required for a given pass or frame from local "storage"
		/// descriptor heaps to the GPU-bound descriptor heap, then use shader-opaque heaps for the storage heaps and copy into the
		/// GPU-visible heap as required.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="DescriptorHeapsType">
		/// <para>Type: <b><c>D3D12_DESCRIPTOR_HEAP_TYPE</c></b></para>
		/// <para>
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to copy with. This is required as
		/// different descriptor types may have different sizes.
		/// </para>
		/// <para>Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Where applicable, prefer this method to <c><b>ID3D12Device::CopyDescriptors</b></c>. It can have a better CPU cache miss rate
		/// due to the linear nature of the copy.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-copydescriptorssimple void CopyDescriptorsSimple(
		// [in] UINT NumDescriptors, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart, [in] D3D12_CPU_DESCRIPTOR_HANDLE
		// SrcDescriptorRangeStart, [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType );
		[PreserveSig]
		new void CopyDescriptorsSimple(uint NumDescriptors, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart, [In] D3D12_CPU_DESCRIPTOR_HANDLE SrcDescriptorRangeStart,
			D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType);

		/// <summary>Gets the size and alignment of memory required for a collection of resources on this adapter.</summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// <para>If an error occurs, then <b>D3D12_RESOURCE_ALLOCATION_INFO::SizeInBytes</b> equals <b>UINT64_MAX</b>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you're using <c>CreatePlacedResource</c>, your application must use <b>GetResourceAllocationInfo</b> in order to understand
		/// the size and alignment characteristics of texture resources. The results of this method vary depending on the particular
		/// adapter, and must be treated as unique to this adapter and driver version.
		/// </para>
		/// <para>
		/// Your application can't use the output of <b>GetResourceAllocationInfo</b> to understand packed mip properties of textures. To
		/// understand packed mip properties of textures, your application must use <c>GetResourceTiling</c>.
		/// </para>
		/// <para>
		/// Texture resource sizes significantly differ from the information returned by <b>GetResourceTiling</b>, because some adapter
		/// architectures allocate extra memory for textures to reduce the effective bandwidth during common rendering scenarios. This even
		/// includes textures that have constraints on their texture layouts, or have standardized texture layouts. That extra memory can't
		/// be sparsely mapped nor remapped by an application using <c>CreateReservedResource</c> and <c>UpdateTileMappings</c>, so it isn't
		/// reported by <b>GetResourceTiling</b>.
		/// </para>
		/// <para>
		/// Your application can forgo using <b>GetResourceAllocationInfo</b> for buffer resources (
		/// <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>). Buffers have the same size on all adapters, which is merely the smallest multiple of
		/// 64KB that's greater or equal to <c>D3D12_RESOURCE_DESC::Width</c>.
		/// </para>
		/// <para>
		/// When multiple resource descriptions are passed in, the C++ algorithm for calculating a structure size and alignment are used.
		/// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource, reports differing sizes
		/// based on the order of the array. If the 4MB aligned resource is in the middle, then the resulting <b>Size</b> is 12MB.
		/// Otherwise, the resulting <b>Size</b> is 8MB. The <b>Alignment</b> returned would always be 4MB, because it's the superset of all
		/// alignments in the resource array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getresourceallocationinfo(uint_uint_constd3d12_resource_desc)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo( [in] UINT visibleMask, [in] UINT numResourceDescs, [in] const
		// D3D12_RESOURCE_DESC *pResourceDescs );
		[PreserveSig]
		new D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_RESOURCE_DESC[] pResourceDescs);

		/// <summary>
		/// Divulges the equivalent custom heap properties that are used for non-custom heap types, based on the adapter's architectural properties.
		/// </summary>
		/// <param name="nodeMask">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter). Each bit in the mask corresponds to a single node. Only 1 bit must be set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="heapType">
		/// <para>Type: <b><c>D3D12_HEAP_TYPE</c></b></para>
		/// <para>
		/// A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the heap to get properties for. D3D12_HEAP_TYPE_CUSTOM is not supported as a
		/// parameter value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_HEAP_PROPERTIES</c></b></para>
		/// <para>
		/// Returns a <c>D3D12_HEAP_PROPERTIES</c> structure that provides properties for the specified heap. The <b>Type</b> member of the
		/// returned D3D12_HEAP_PROPERTIES is always D3D12_HEAP_TYPE_CUSTOM.
		/// </para>
		/// <para>When <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>::UMA is FALSE, the returned D3D12_HEAP_PROPERTIES members convert as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_COMBINE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L1.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// When D3D12_FEATURE_DATA_ARCHITECTURE::UMA is TRUE and D3D12_FEATURE_DATA_ARCHITECTURE::CacheCoherentUMA is FALSE, the returned
		/// D3D12_HEAP_PROPERTIES members convert as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_COMBINE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// When D3D12_FEATURE_DATA_ARCHITECTURE::UMA is TRUE and D3D12_FEATURE_DATA_ARCHITECTURE::CacheCoherentUMA is TRUE, the returned
		/// D3D12_HEAP_PROPERTIES members convert as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getcustomheapproperties(uint_d3d12_heap_type)
		// D3D12_HEAP_PROPERTIES GetCustomHeapProperties( [in] UINT nodeMask, D3D12_HEAP_TYPE heapType );
		[PreserveSig]
		new D3D12_HEAP_PROPERTIES GetCustomHeapProperties(uint nodeMask, D3D12_HEAP_TYPE heapType);

		/// <summary>
		/// Creates both a resource and an implicit heap, such that the heap is big enough to contain the entire resource, and the resource
		/// is mapped to the heap.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommittedresource HRESULT
		// CreateCommittedResource( [in] const D3D12_HEAP_PROPERTIES *pHeapProperties, [in] D3D12_HEAP_FLAGS HeapFlags, [in] const
		// D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialResourceState, [in, optional] const D3D12_CLEAR_VALUE
		// *pOptimizedClearValue, [in] REFIID riidResource, [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateCommittedResource(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>Creates a heap that can be used with placed resources and reserved resources.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_HEAP_DESC</b> structure that describes the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the heap interface to return in ppvHeap.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Heap</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// An optional pointer to a memory block that receives the requested interface pointer to the created heap object. <paramref
		/// name="ppvHeap"/> can be <c>nullptr</c>, to enable capability testing. When ppvHeap is <c>nullptr</c>, no object is created, and
		/// <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the heap.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para><b>CreateHeap</b> creates a heap that can be used with placed resources and reserved resources.</para>
		/// <para>
		/// Before releasing the final reference on the heap, your application must ensure that the GPU will no longer read or write to this heap.
		/// </para>
		/// <para>
		/// A placed resource object holds a reference on the heap it is created on; but a reserved resource doesn't hold a reference for
		/// each mapping made to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createheap HRESULT CreateHeap( [in] const
		// D3D12_HEAP_DESC *pDesc, [in] REFIID riid, [out, optional] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateHeap(in D3D12_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvHeap);

		/// <summary>
		/// <para>
		/// Creates a resource that is placed in a specific heap. Placed resources are the lightest weight resource objects available, and
		/// are the fastest to create and destroy.
		/// </para>
		/// <para>
		/// Your application can re-use video memory by overlapping multiple Direct3D placed and reserved resources on heap regions. The
		/// simple memory re-use model (described in <c>Remarks</c>) exists to clarify which overlapping resource is valid at any given
		/// time. To maximize graphics tool support, with the simple model data-inheritance isn't supported; and finer-grained tile and
		/// sub-resource invalidation isn't supported. Only full overlapping resource invalidation occurs.
		/// </para>
		/// </summary>
		/// <param name="pHeap">
		/// <para>Type: [in] <b><c>ID3D12Heap</c></b>*</para>
		/// <para>A pointer to the <b>ID3D12Heap</b> interface that represents the heap in which the resource is placed.</para>
		/// </param>
		/// <param name="HeapOffset">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// The offset, in bytes, to the resource. The HeapOffset must be a multiple of the resource's alignment, and HeapOffset plus the
		/// resource size must be smaller than or equal to the heap size. <c><b>GetResourceAllocationInfo</b></c> must be used to understand
		/// the sizes of texture resources.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_RESOURCE_DESC</c></b>*</para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>
		/// When a resource is created together with a <b>D3D12_HEAP_TYPE_UPLOAD</b> heap, InitialState must be
		/// <b>D3D12_RESOURCE_STATE_GENERIC_READ</b>. When a resource is created together with a <b>D3D12_HEAP_TYPE_READBACK</b> heap,
		/// InitialState must be <b>D3D12_RESOURCE_STATE_COPY_DEST</b>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: [in, optional] <b>const <c>D3D12_CLEAR_VALUE</c></b>*</para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <b>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</b> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, your application should choose the value that the clear operation will most commonly be called with.
		/// </para>
		/// <para>
		/// Clear operations can be called with other values, but those operations will not be as efficient as when the value matches the
		/// one passed into resource creation.
		/// </para>
		/// <para><paramref name="pOptimizedClearValue"/> must be NULL when used with <b>D3D12_RESOURCE_DIMENSION_BUFFER</b>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the resource interface. This is an input parameter.</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the resource can be obtained by using the <c>__uuidof</c> macro. For
		/// example, <c>__uuidof(ID3D12Resource)</c> gets the <b>GUID</b> of the interface to a resource. Although <b>riid</b> is, most
		/// commonly, the GUID for <c><b>ID3D12Resource</b></c>, it may be any <b>GUID</b> for any interface. If the resource object doesn't
		/// support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: [out, optional] <b>void</b>**</para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the resource. ppvResource can be NULL, to enable capability testing. When
		/// ppvResource is NULL, no object will be created and S_FALSE will be returned when pResourceDesc and other parameters are valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the resource. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreatePlacedResource</b> is similar to fully mapping a reserved resource to an offset within a heap; but the virtual address
		/// space associated with a heap may be reused as well.
		/// </para>
		/// <para>
		/// Placed resources are lighter weight to create and destroy than committed resources are. This is because no heap is created nor
		/// destroyed during those operations. In addition, placed resources enable an even lighter weight technique to reuse memory than
		/// resource creation and destruction—that is, reuse through aliasing, and aliasing barriers. Multiple placed resources may
		/// simultaneously overlap each other on the same heap, but only a single overlapping resource can be used at a time.
		/// </para>
		/// <para>
		/// There are two placed resource usage semantics—a simple model, and an advanced model. We recommend that you choose the simple
		/// model (it maximizes graphics tool support across the diverse ecosystem of GPUs), unless and until you find that you need the
		/// advanced model for your app.
		/// </para>
		/// <para>Simple model</para>
		/// <para>
		/// In this model, you can consider a placed resource to be in one of two states: active, or inactive. It's invalid for the GPU to
		/// either read or write from an inactive resource. Placed resources are created in the inactive state.
		/// </para>
		/// <para>
		/// To activate a resource with an aliasing barrier on a command list, your application must pass the resource in
		/// <c><b>D3D12_RESOURCE_ALIASING_BARRIER::pResourceAfter</b></c>. <b>pResourceBefore</b> can be left NULL during an activation. All
		/// resources that share physical memory with the activated resource now become inactive, which includes overlapping placed and
		/// reserved resources.
		/// </para>
		/// <para>Aliasing barriers should be grouped up and submitted together, in order to maximize efficiency.</para>
		/// <para>
		/// After activation, resources with either the render target or depth stencil flags must be further initialized. See the notes on
		/// the required resource initialization below.
		/// </para>
		/// <para>Notes on the required resource initialization</para>
		/// <para>
		/// Certain resource types still require initialization. Resources with either the render target or depth stencil flags must be
		/// initialized with either a clear operation or a collection of full subresource copies. If an aliasing barrier was used to denote
		/// the transition between two aliased resources, the initialization must occur after the aliasing barrier. This initialization is
		/// still required whenever a resource would've been activated in the simple model.
		/// </para>
		/// <para>
		/// Placed and reserved resources with either the render target or depth stencil flags must be initialized with one of the following
		/// operations before other operations are supported.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>A Clear operation; for example <c>ClearRenderTargetView</c> or <c>ClearDepthStencilView</c>.</description>
		/// </item>
		/// <item>
		/// <description>A <c>DiscardResource</c> operation.</description>
		/// </item>
		/// <item>
		/// <description>A Copy operation; for example <c>CopyBufferRegion</c>, <c>CopyTextureRegion</c>, or <c>CopyResource</c>.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications should prefer the most explicit operation that results in the least amount of texels modified. Consider the
		/// following examples.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Using a depth buffer to solve pixel visibility typically requires each depth texel start out at 1.0 or 0. Therefore, a Clear
		/// operation should be the most efficient option for aliased depth buffer initialization.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// An application may use an aliased render target as a destination for tone mapping. Since the application will render over every
		/// pixel during the tone mapping, <c>DiscardResource</c> should be the most efficient option for initialization.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Advanced model</para>
		/// <para>In this model, you can ignore the active/inactive state abstraction. Instead, you must honor these lower-level rules.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// An aliasing barrier must be between two different GPU resource accesses of the same physical memory, as long as those accesses
		/// are within the same <c>ExecuteCommandLists</c> call.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The first rendering operation to certain types of aliased resource must still be an initialization, just like the simple model.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Initialization operations must occur either on an entire subresource, or on a 64KB granularity. An entire subresource
		/// initialization is supported for all resource types. A 64KB initialization granularity, aligned at a 64KB offset, is supported
		/// for buffers and textures with either the 64KB_UNDEFINED_SWIZZLE or 64KB_STANDARD_SWIZZLE texture layout (refer to <c>D3D12_TEXTURE_LAYOUT</c>).
		/// </para>
		/// <para>Notes on the aliasing barrier</para>
		/// <para>
		/// The aliasing barrier may set NULL for both pResourceAfter and pResourceBefore. The memory coherence definition of
		/// <c><b>ExecuteCommandLists</b></c> and an aliasing barrier are the same, such that two aliased accesses to the same physical
		/// memory need no aliasing barrier when the accesses are in two different <b>ExecuteCommandLists</b> invocations.
		/// </para>
		/// <para>
		/// For D3D12 advanced usage models, the synchronization definition of <c><b>ExecuteCommandLists</b></c> is equivalent to an
		/// aliasing barrier. Therefore, applications may either insert an aliasing barrier between reusing physical memory, or ensure the
		/// two aliased usages of physical memory occurs in two separate calls to <b>ExecuteCommandLists</b>.
		/// </para>
		/// <para>
		/// The amount of inactivation varies based on resource properties. Textures with undefined memory layouts are the worst case, as
		/// the entire texture must be inactivated atomically. For two overlapping resources with defined layouts, inactivation can result
		/// in only the overlapping aligned regions of a resource. Data inheritance can even be well-defined. For more details, see
		/// <c>Memory aliasing and data inheritance</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createplacedresource HRESULT
		// CreatePlacedResource( ID3D12Heap *pHeap, UINT64 HeapOffset, const D3D12_RESOURCE_DESC *pDesc, D3D12_RESOURCE_STATES InitialState,
		// const D3D12_CLEAR_VALUE *pOptimizedClearValue, REFIID riid, void **ppvResource );
		[PreserveSig]
		new HRESULT CreatePlacedResource([In] ID3D12Heap pHeap, ulong HeapOffset, in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>Creates a resource that is reserved, and not yet mapped to any pages in a heap.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource. See <b>Remarks</b>.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateReservedResource</b> is equivalent to <c>D3D11_RESOURCE_MISC_TILED</c> in Direct3D 11. It creates a resource with
		/// virtual memory only, no backing store.
		/// </para>
		/// <para>You need to map the resource to physical memory (that is, to a heap) using <c>CopyTileMappings</c> and <c>UpdateTileMappings</c>.</para>
		/// <para>
		/// These resource types can only be created when the adapter supports tiled resource tier 1 or greater. The tiled resource tier
		/// defines the behavior of accessing a resource that is not mapped to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createreservedresource HRESULT
		// CreateReservedResource( [in] const D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialState, [in, optional] const
		// D3D12_CLEAR_VALUE *pOptimizedClearValue, [in] REFIID riid, [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateReservedResource(in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppvResource);

		/// <summary>Creates a shared handle to a heap, resource, or fence object.</summary>
		/// <param name="pObject">
		/// <para>Type: <b><c>ID3D12DeviceChild</c>*</b></para>
		/// <para>
		/// A pointer to the <c>ID3D12DeviceChild</c> interface that represents the heap, resource, or fence object to create for sharing.
		/// The following interfaces (derived from <b>ID3D12DeviceChild</b>) are supported:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAttributes">
		/// <para>Type: <b>const <c>SECURITY_ATTRIBUTES</c>*</b></para>
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security
		/// descriptor, and a <b>Boolean</b> value that determines whether child processes can inherit the returned handle.
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
		/// <param name="Access">
		/// <para>Type: <b><c>DWORD</c></b></para>
		/// <para>Currently the only value this parameter accepts is GENERIC_ALL.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>
		/// A <b>NULL</b>-terminated <b>UNICODE</b> string that contains the name to associate with the shared heap. The name is limited to
		/// MAX_PATH characters. Name comparison is case-sensitive.
		/// </para>
		/// <para>
		/// If <i>Name</i> matches the name of an existing resource, <b>CreateSharedHandle</b> fails with
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
		/// <para>Type: <b><c>HANDLE</c>*</b></para>
		/// <para>
		/// A pointer to a variable that receives the NT HANDLE value to the resource to share. You can use this handle in calls to access
		/// the resource.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
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
		/// <description>Possibly other error codes that are described in the <c>Direct3D 12 Return Codes</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Both heaps and committed resources can be shared. Sharing a committed resource shares the implicit heap along with the committed
		/// resource description, such that a compatible resource description can be mapped to the heap from another device.
		/// </para>
		/// <para>
		/// For Direct3D 11 and Direct3D 12 interop scenarios, a shared fence is opened in DirectX 11 with the
		/// <c>ID3D11Device5::OpenSharedFence</c> method, and a shared resource is opened with the <c>ID3D11Device::OpenSharedResource1</c> method.
		/// </para>
		/// <para>
		/// For Direct3D 12, a shared handle is opened with the <c>ID3D12Device::OpenSharedHandle</c> or the
		/// ID3D12Device::OpenSharedHandleByName method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createsharedhandle HRESULT CreateSharedHandle(
		// [in] ID3D12DeviceChild *pObject, [in, optional] const SECURITY_ATTRIBUTES *pAttributes, DWORD Access, [in, optional] LPCWSTR
		// Name, [out] HANDLE *pHandle );
		[PreserveSig]
		new HRESULT CreateSharedHandle([In] ID3D12DeviceChild pObject, [In, Optional] SECURITY_ATTRIBUTES? pAttributes, ACCESS_MASK Access,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? Name, out HANDLE pHandle);

		/// <summary>Opens a handle for shared resources, shared heaps, and shared fences, by using HANDLE and REFIID.</summary>
		/// <param name="NTHandle">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>The handle that was output by the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for one of the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// <para>The REFIID , or GUID , of the interface can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D12Heap) will get the GUID of the interface to a resource.</para>
		/// </param>
		/// <param name="ppvObj">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to one of the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-opensharedhandle HRESULT OpenSharedHandle( [in]
		// HANDLE NTHandle, REFIID riid, [out, optional] void **ppvObj );
		[PreserveSig]
		new HRESULT OpenSharedHandle(HANDLE NTHandle, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvObj);

		/// <summary>Opens a handle for shared resources, shared heaps, and shared fences, by using Name and Access.</summary>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The name that was optionally passed as the <i>Name</i> parameter in the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="Access">
		/// <para>Type: <b>DWORD</b></para>
		/// <para>The access level that was specified in the <i>Access</i> parameter in the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="pNTHandle">
		/// <para>Type: <b>HANDLE*</b></para>
		/// <para>Pointer to the shared handle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-opensharedhandlebyname HRESULT
		// OpenSharedHandleByName( [in] LPCWSTR Name, DWORD Access, [out] HANDLE *pNTHandle );
		[PreserveSig]
		new HRESULT OpenSharedHandleByName([MarshalAs(UnmanagedType.LPWStr)] string Name, ACCESS_MASK Access, out HANDLE pNTHandle);

		/// <summary>Makes objects resident for the device.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to make resident for the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block that contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>
		/// Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following
		/// objects: Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>MakeResident</b> loads the data associated with a resource from disk, and re-allocates the memory from the resource's
		/// appropriate memory pool. This method should be called on the object which owns the physical memory.
		/// </para>
		/// <para>
		/// Use this method, and <c>Evict</c>, to manage GPU video memory, noting that this was done automatically in D3D11, but now has to
		/// be done by the app in D3D12.
		/// </para>
		/// <para>
		/// <b>MakeResident</b> and <c>Evict</c> can help applications manage the residency budget on many adapters. <b>MakeResident</b>
		/// explicitly pages-in data and, then, precludes page-out so the GPU can access the data. <b>Evict</b> enables page-out.
		/// </para>
		/// <para>
		/// Some GPU architectures do not benefit from residency manipulation, due to the lack of sufficient GPU virtual address space. Use
		/// <c>D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT</c> and <c>IDXGIAdapter3::QueryVideoMemoryInfo</c> to recognize when the
		/// maximum GPU VA space per-process is too small or roughly the same size as the residency budget. For such architectures, the
		/// residency budget will always be constrained by the amount of GPU virtual address space. <c>Evict</c> will not free-up any
		/// residency budget on such systems.
		/// </para>
		/// <para>
		/// Applications must handle <b>MakeResident</b> failures, even if there appears to be enough residency budget available. Physical
		/// memory fragmentation and adapter architecture quirks can preclude the utilization of large contiguous ranges. Applications
		/// should free up more residency budget before trying again.
		/// </para>
		/// <para>
		/// <b>MakeResident</b> is ref-counted, such that <c>Evict</c> must be called the same amount of times as <b>MakeResident</b> before
		/// <b>Evict</b> takes effect. Objects that support residency are made resident during creation, so a single <b>Evict</b> call will
		/// actually evict the object.
		/// </para>
		/// <para>
		/// Applications must use fences to ensure the GPU doesn't use non-resident objects. <b>MakeResident</b> must return before the GPU
		/// executes a command list that references the object. <c>Evict</c> must be called after the GPU finishes executing a command list
		/// that references the object.
		/// </para>
		/// <para>
		/// Evicted objects still consume the same GPU virtual address and same amount of GPU virtual address space. Therefore, resource
		/// descriptors and other GPU virtual address references are not invalidated after <c>Evict</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-makeresident HRESULT MakeResident( UINT
		// NumObjects, [in] ID3D12Pageable * const *ppObjects );
		[PreserveSig]
		new HRESULT MakeResident(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects);

		/// <summary>Enables the page-out of data, which precludes GPU access of that data.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to evict from the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block that contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>
		/// Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following
		/// objects: Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>Evict</b> persists the data associated with a resource to disk, and then removes the resource from the memory pool where it
		/// was located. This method should be called on the object which owns the physical memory: either a committed resource (which owns
		/// both virtual and physical memory assignments) or a heap - noting that reserved resources do not have physical memory, and placed
		/// resources are borrowing memory from a heap.
		/// </para>
		/// <para>Refer to the remarks for <c>MakeResident</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-evict HRESULT Evict( UINT NumObjects, [in]
		// ID3D12Pageable * const *ppObjects );
		[PreserveSig]
		new HRESULT Evict(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects);

		/// <summary>Creates a fence object.</summary>
		/// <param name="InitialValue">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The initial value for the fence.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_FENCE_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_FENCE_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for the fence.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the fence interface ( <c>ID3D12Fence</c>). The <b>REFIID</b>, or <b>GUID</b>,
		/// of the interface to the fence can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D12Fence) will get the
		/// <b>GUID</b> of the interface to a fence.
		/// </para>
		/// </param>
		/// <param name="ppFence">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Fence</c> interface that is used to access the fence.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createfence HRESULT CreateFence( UINT64
		// InitialValue, D3D12_FENCE_FLAGS Flags, REFIID riid, [out] void **ppFence );
		[PreserveSig]
		new HRESULT CreateFence(ulong InitialValue, D3D12_FENCE_FLAGS Flags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppFence);

		/// <summary>
		/// Gets the reason that the device was removed, or <b>S_OK</b> if the device isn't removed. To be called back when a device is
		/// removed, consider using <c>ID3D12Fence::SetEventOnCompletion</c> with a value of <b>UINT64_MAX</b>. That's because device
		/// removal causes all fences to be signaled to that value (which also implies completing all events waited on, because they'll all
		/// be less than <b>UINT64_MAX</b>).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns the reason that the device was removed.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getdeviceremovedreason HRESULT GetDeviceRemovedReason();
		[PreserveSig]
		new HRESULT GetDeviceRemovedReason();

		/// <summary>
		/// Gets a resource layout that can be copied. Helps the app fill-in <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> when suballocating space in upload heaps.
		/// </summary>
		/// <param name="pResourceDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A description of the resource, as a pointer to a <c>D3D12_RESOURCE_DESC</c> structure.</para>
		/// </param>
		/// <param name="FirstSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
		/// </param>
		/// <param name="NumSubresources">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - <i>FirstSubresource</i>).</para>
		/// </param>
		/// <param name="BaseOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset, in bytes, to the resource.</para>
		/// </param>
		/// <param name="pLayouts">
		/// <para>Type: <b><c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structures, to be filled
		/// with the description and placement of each subresource.
		/// </para>
		/// </param>
		/// <param name="pNumRows">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, to be filled with the number of rows for each subresource.
		/// </para>
		/// </param>
		/// <param name="pRowSizeInBytes">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, each entry to be filled with the unpadded size in
		/// bytes of a row, of each subresource.
		/// </para>
		/// <para>For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4,</para>
		/// <para>then <i>pRowSizeInBytes</i> returns 128.</para>
		/// <para>
		/// <i>pRowSizeInBytes</i> should not be confused with <b>row pitch</b>, as examining <i>pLayouts</i> and getting the row pitch from
		/// that will give you 256 as it is aligned to D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.
		/// </para>
		/// </param>
		/// <param name="pTotalBytes">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>A pointer to an integer variable, to be filled with the total size, in bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This routine assists the application in filling out <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> structures, when suballocating space in upload heaps. The resulting structures are GPU
		/// adapter-agnostic, meaning that the values will not vary from one GPU adapter to the next. <b>GetCopyableFootprints</b> uses
		/// specified details about resource formats, texture layouts, and alignment requirements (from the <c>D3D12_RESOURCE_DESC</c>
		/// structure) to fill out the subresource structures. Applications have access to all these details, so this method, or a variation
		/// of it, could be written as part of the app.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12Device::GetCopyableFootprints</b> as follows:</para>
		/// <para>
		/// <c>// Returns required size of a buffer to be used for data upload inline UINT64 GetRequiredIntermediateSize( _In_
		/// ID3D12Resource* pDestinationResource, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources) { D3D12_RESOURCE_DESC Desc =
		/// pDestinationResource-&gt;GetDesc(); UINT64 RequiredSize = 0; ID3D12Device* pDevice;
		/// pDestinationResource-&gt;GetDevice(__uuidof(*pDevice), reinterpret_cast&lt;void**&gt;(&amp;pDevice));
		/// pDevice-&gt;GetCopyableFootprints(&amp;Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr,
		/// &amp;RequiredSize); pDevice-&gt;Release(); return RequiredSize; }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getcopyablefootprints void GetCopyableFootprints(
		// [in] const D3D12_RESOURCE_DESC *pResourceDesc, [in] UINT FirstSubresource, [in] UINT NumSubresources, UINT64 BaseOffset, [out,
		// optional] D3D12_PLACED_SUBRESOURCE_FOOTPRINT *pLayouts, [out, optional] UINT *pNumRows, [out, optional] UINT64 *pRowSizeInBytes,
		// [out, optional] UINT64 *pTotalBytes );
		[PreserveSig]
		new void GetCopyableFootprints(in D3D12_RESOURCE_DESC pResourceDesc, uint FirstSubresource, int NumSubresources, ulong BaseOffset,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[]? pLayouts,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[]? pNumRows,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[]? pRowSizeInBytes,
			[Out, Optional] StructPointer<ulong> pTotalBytes);

		/// <summary>Creates a query heap. A query heap contains an array of queries.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_QUERY_HEAP_DESC</c>*</b></para>
		/// <para>Specifies the query heap in a <c>D3D12_QUERY_HEAP_DESC</c> structure.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>Specifies a REFIID that uniquely identifies the heap.</para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// Specifies a pointer to the heap, that will be returned on successful completion of the method. <i>ppvHeap</i> can be NULL, to
		/// enable capability testing. When <i>ppvHeap</i> is NULL, no object will be created and S_FALSE will be returned when <i>pDesc</i>
		/// is valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>Refer to <c>Queries</c> for more information. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12Device::CreateQueryHeap</b> as follows:</para>
		/// <para>Create a query heap and a query result buffer.</para>
		/// <para>
		/// <c>// Pipeline objects. D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain;
		/// ComPtr&lt;ID3D12Device&gt; m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount];
		/// ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocators[FrameCount]; ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue;
		/// ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature; ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_cbvHeap; ComPtr&lt;ID3D12DescriptorHeap&gt; m_dsvHeap; ComPtr&lt;ID3D12QueryHeap&gt;
		/// m_queryHeap; UINT m_rtvDescriptorSize; UINT m_cbvSrvDescriptorSize; UINT m_frameIndex; // Synchronization objects.
		/// ComPtr&lt;ID3D12Fence&gt; m_fence; UINT64 m_fenceValues[FrameCount]; HANDLE m_fenceEvent; // Asset objects.
		/// ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState; ComPtr&lt;ID3D12PipelineState&gt; m_queryState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; ComPtr&lt;ID3D12Resource&gt; m_vertexBuffer; ComPtr&lt;ID3D12Resource&gt;
		/// m_constantBuffer; ComPtr&lt;ID3D12Resource&gt; m_depthStencil; ComPtr&lt;ID3D12Resource&gt; m_queryResult;
		/// D3D12_VERTEX_BUFFER_VIEW m_vertexBufferView;</c>
		/// </para>
		/// <para>
		/// <c>// Describe and create a heap for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1;
		/// queryHeapDesc.Type = D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc, IID_PPV_ARGS(&amp;m_queryHeap)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createqueryheap HRESULT CreateQueryHeap( [in]
		// const D3D12_QUERY_HEAP_DESC *pDesc, REFIID riid, [out, optional] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateQueryHeap(in D3D12_QUERY_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvHeap);

		/// <summary>A development-time aid for certain types of profiling and experimental prototyping.</summary>
		/// <param name="Enable">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies a BOOL that turns the stable power state on or off.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is only useful during the development of applications. It enables developers to profile GPU usage of multiple
		/// algorithms without experiencing artifacts from <c>dynamic frequency scaling</c>.
		/// </para>
		/// <para>
		/// Do not call this method in normal execution for a shipped application. This method only works while the machine is in
		/// <c>developer mode</c>. If developer mode is not enabled, then device removal will occur. Instead, call this method in response
		/// to an off-by-default, developer-facing switch. Calling it in response to command line parameters, config files, registry keys,
		/// and developer console commands are reasonable usage scenarios.
		/// </para>
		/// <para>
		/// A stable power state typically fixes GPU clock rates at a slower setting that is significantly lower than that experienced by
		/// users under normal application load. This reduction in clock rate affects the entire system. Slow clock rates are required to
		/// ensure processors don’t exhaust power, current, and thermal limits. Normal usage scenarios commonly leverage a processors
		/// ability to dynamically over-clock. Any conclusions made by comparing two designs under a stable power state should be
		/// double-checked with supporting results from real usage scenarios.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-setstablepowerstate HRESULT SetStablePowerState(
		// BOOL Enable );
		[PreserveSig]
		new HRESULT SetStablePowerState(bool Enable);

		/// <summary>This method creates a command signature.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMMAND_SIGNATURE_DESC</c>*</b></para>
		/// <para>Describes the command signature to be created with the <c>D3D12_COMMAND_SIGNATURE_DESC</c> structure.</para>
		/// </param>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>Specifies the <c>ID3D12RootSignature</c> that the command signature applies to.</para>
		/// <para>
		/// The root signature is required if any of the commands in the signature will update bindings on the pipeline. If the only command
		/// present is a draw or dispatch, the root signature parameter can be set to NULL.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the command signature interface ( <c>ID3D12CommandSignature</c>). The
		/// <b>REFIID</b>, or <b>GUID</b>, of the interface to the command signature can be obtained by using the __uuidof() macro. For
		/// example, __uuidof( <b>ID3D12CommandSignature</b>) will get the <b>GUID</b> of the interface to a command signature.
		/// </para>
		/// </param>
		/// <param name="ppvCommandSignature">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer, that on successful completion of the method will point to the created command signature ( <c>ID3D12CommandSignature</c>).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandsignature HRESULT
		// CreateCommandSignature( [in] const D3D12_COMMAND_SIGNATURE_DESC *pDesc, [in, optional] ID3D12RootSignature *pRootSignature,
		// REFIID riid, [out, optional] void **ppvCommandSignature );
		[PreserveSig]
		new HRESULT CreateCommandSignature(in D3D12_COMMAND_SIGNATURE_DESC pDesc, [In, Optional] ID3D12RootSignature? pRootSignature,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvCommandSignature);

		/// <summary>Gets info about how a tiled resource is broken into tiles.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies a tiled <c>ID3D12Resource</c> to get info about.</para>
		/// </param>
		/// <param name="pNumTilesForEntireResource">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>A pointer to a variable that receives the number of tiles needed to store the entire tiled resource.</para>
		/// </param>
		/// <param name="pPackedMipDesc">
		/// <para>Type: <b><c>D3D12_PACKED_MIP_INFO</c>*</b></para>
		/// <para>
		/// A pointer to a <c>D3D12_PACKED_MIP_INFO</c> structure that <b>GetResourceTiling</b> fills with info about how the tiled
		/// resource's mipmaps are packed.
		/// </para>
		/// </param>
		/// <param name="pStandardTileShapeForNonPackedMips">
		/// <para>Type: <b><c>D3D12_TILE_SHAPE</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_TILE_SHAPE</c> structure that <b>GetResourceTiling</b> fills with info about the tile shape. This is info
		/// about how pixels fit in the tiles, independent of tiled resource's dimensions, not including packed mipmaps. If the entire tiled
		/// resource is packed, this parameter is meaningless because the tiled resource has no defined layout for packed mipmaps. In this
		/// situation, <b>GetResourceTiling</b> sets the members of D3D12_TILE_SHAPE to zeros.
		/// </para>
		/// </param>
		/// <param name="pNumSubresourceTilings">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A pointer to a variable that contains the number of tiles in the subresource. On input, this is the number of subresources to
		/// query tilings for; on output, this is the number that was actually retrieved at <i>pSubresourceTilingsForNonPackedMips</i>
		/// (clamped to what's available).
		/// </para>
		/// </param>
		/// <param name="FirstSubresourceTilingToGet">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of the first subresource tile to get. <b>GetResourceTiling</b> ignores this parameter if the number that
		/// <i>pNumSubresourceTilings</i> points to is 0.
		/// </para>
		/// </param>
		/// <param name="pSubresourceTilingsForNonPackedMips">
		/// <para>Type: <b><c>D3D12_SUBRESOURCE_TILING</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_SUBRESOURCE_TILING</c> structure that <b>GetResourceTiling</b> fills with info about subresource tiles. If
		/// subresource tiles are part of packed mipmaps, <b>GetResourceTiling</b> sets the members of D3D12_SUBRESOURCE_TILING to zeros,
		/// except the <i>StartTileIndexInOverallResource</i> member, which <b>GetResourceTiling</b> sets to D3D12_PACKED_TILE (0xffffffff).
		/// The D3D12_PACKED_TILE constant indicates that the whole <b>D3D12_SUBRESOURCE_TILING</b> structure is meaningless for this
		/// situation, and the info that the <i>pPackedMipDesc</i> parameter points to applies.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To estimate the total resource size of textures needed when calculating heap sizes and calling <c>CreatePlacedResource</c>, use
		/// <c>GetResourceAllocationInfo</c> instead of <b>GetResourceTiling</b>. <b>GetResourceTiling</b> cannot be used for this.
		/// </para>
		/// <para>For more information on tiled resources, refer to <c>Volume Tiled Resources</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getresourcetiling void GetResourceTiling( [in]
		// ID3D12Resource *pTiledResource, [out, optional] UINT *pNumTilesForEntireResource, [out, optional] D3D12_PACKED_MIP_INFO
		// *pPackedMipDesc, [out, optional] D3D12_TILE_SHAPE *pStandardTileShapeForNonPackedMips, [in, out, optional] UINT
		// *pNumSubresourceTilings, [in] UINT FirstSubresourceTilingToGet, [out] D3D12_SUBRESOURCE_TILING
		// *pSubresourceTilingsForNonPackedMips );
		[PreserveSig]
		new void GetResourceTiling([In] ID3D12Resource pTiledResource, [Out, Optional] StructPointer<uint> pNumTilesForEntireResource,
			[Out, Optional] StructPointer<D3D12_PACKED_MIP_INFO> pPackedMipDesc, [Out, Optional] StructPointer<D3D12_TILE_SHAPE> pStandardTileShapeForNonPackedMips,
			[In, Out, Optional] StructPointer<uint> pNumSubresourceTilings, uint FirstSubresourceTilingToGet,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_TILING[] pSubresourceTilingsForNonPackedMips);

		/// <summary>Gets a locally unique identifier for the current device (adapter).</summary>
		/// <returns>
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>The locally unique identifier for the adapter.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method returns a unique identifier for the adapter that is specific to the adapter hardware. Applications can use this
		/// identifier to define robust mappings across various APIs (Direct3D 12, DXGI).
		/// </para>
		/// <para>
		/// A locally unique identifier (LUID) is a 64-bit value that is guaranteed to be unique only on the system on which it was
		/// generated. The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getadapterluid LUID GetAdapterLuid();
		[PreserveSig]
		new LUID GetAdapterLuid();

		/// <summary>
		/// <para>
		/// Creates a cached pipeline library. For pipeline state objects (PSOs) that are expected to share data together, grouping them
		/// into a library before serializing them means that there's less overhead due to metadata, as well as the opportunity to avoid
		/// redundant or duplicated data being written to disk.
		/// </para>
		/// <para>
		/// You can query for <b>ID3D12PipelineLibrary</b> support with <b><c>ID3D12Device::CheckFeatureSupport</c></b>, with
		/// <b><c>D3D12_FEATURE_SHADER_CACHE</c></b> and <b><c>D3D12_FEATURE_DATA_SHADER_CACHE</c></b>. If the Flags member of
		/// <b><c>D3D12_FEATURE_DATA_SHADER_CACHE</c></b> contains the flag <b><c>D3D12_SHADER_CACHE_SUPPORT_LIBRARY</c></b>, the
		/// <b>ID3D12PipelineLibrary</b> interface is supported. If not, then <b>DXGI_ERROR_NOT_SUPPORTED</b> will always be returned when
		/// this function is called.
		/// </para>
		/// </summary>
		/// <param name="pLibraryBlob">
		/// <para>Type: [in] <b>const void*</b></para>
		/// <para>
		/// If the input library blob is empty, then the initial content of the library is empty. If the input library blob is not empty,
		/// then it is validated for integrity, parsed, and the pointer is stored. The pointer provided as input to this method must remain
		/// valid for the lifetime of the object returned. For efficiency reasons, the data is not copied.
		/// </para>
		/// </param>
		/// <param name="BlobLength">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>Specifies the length of pLibraryBlob in bytes.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a unique REFIID for the <c>ID3D12PipelineLibrary</c> object. Typically set this and the following parameter with the
		/// macro <c>IID_PPV_ARGS(&amp;Library)</c>, where <b>Library</b> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineLibrary">
		/// <para>Type: [out] <b>void**</b></para>
		/// <para>Returns a pointer to the created library.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>, including
		/// <b>E_INVALIDARG</b> if the blob is corrupted or unrecognized, <b>D3D12_ERROR_DRIVER_VERSION_MISMATCH</b> if the provided data
		/// came from an old driver or runtime, and <b>D3D12_ERROR_ADAPTER_NOT_FOUND</b> if the data came from different hardware.
		/// </para>
		/// <para>
		/// If you pass <c>nullptr</c> for pPipelineLibrary then the runtime still performs the validation of the blob but avoid creating
		/// the actual library and returns S_FALSE if the library would have been created.
		/// </para>
		/// <para>Also, the feature requires an updated driver, and attempting to use it on old drivers will return DXGI_ERROR_UNSUPPORTED.</para>
		/// </returns>
		/// <remarks>
		/// <para>A pipeline library enables the following operations.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Adding pipeline state objects (PSOs) to an existing library object (refer to <c>StorePipeline</c>).</description>
		/// </item>
		/// <item>
		/// <description>Serializing a PSO library into a contiguous block of memory for disk storage (refer to <c>Serialize</c>).</description>
		/// </item>
		/// <item>
		/// <description>De-serializing a PSO library from persistent storage (this is handled by <b>CreatePipelineLibrary</b>).</description>
		/// </item>
		/// <item>
		/// <description>Retrieving individual PSOs from the library (refer to <c>LoadComputePipeline</c> and <c>LoadGraphicsPipeline</c>).</description>
		/// </item>
		/// </list>
		/// <para>At no point in the lifecycle of a pipeline library is there duplication between PSOs with identical sub-components.</para>
		/// <para>
		/// A recommended solution for managing the lifetime of the provided pointer while only having to ref-count the returned interface
		/// is to leverage <c>ID3D12Object::SetPrivateDataInterface</c>, and use an object which implements <b>IUnknown</b>, and frees the
		/// memory when the ref-count reaches 0.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>
		/// The pipeline library is thread-safe to use, and will internally synchronize as necessary, with one exception: multiple threads
		/// loading the same PSO (via <c><b>LoadComputePipeline</b></c>, <c><b>LoadGraphicsPipeline</b></c>, or <c><b>LoadPipeline</b></c>)
		/// should synchronize themselves, as this act may modify the state of that pipeline within the library in a non-thread-safe manner.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-createpipelinelibrary HRESULT
		// CreatePipelineLibrary( const void *pLibraryBlob, SIZE_T BlobLength, REFIID riid, void **ppPipelineLibrary );
		[PreserveSig]
		new HRESULT CreatePipelineLibrary([In] IntPtr pLibraryBlob, [In] SizeT BlobLength, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppPipelineLibrary);

		/// <summary>Specifies an event that should be fired when one or more of a collection of fences reach specific values.</summary>
		/// <param name="ppFences">
		/// <para>Type: <b>ID3D12Fence*</b></para>
		/// <para>An array of length <i>NumFences</i> that specifies the <c>ID3D12Fence</c> objects.</para>
		/// </param>
		/// <param name="pFenceValues">
		/// <para>Type: <b>const UINT64*</b></para>
		/// <para>An array of length <i>NumFences</i> that specifies the fence values required for the event is to be signaled.</para>
		/// </param>
		/// <param name="NumFences">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of fences to be included.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_MULTIPLE_FENCE_WAIT_FLAGS</c></b></para>
		/// <para>Specifies one of the <c>D3D12_MULTIPLE_FENCE_WAIT_FLAGS</c> that determines how to proceed.</para>
		/// </param>
		/// <param name="hEvent">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>A handle to the event object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To specify a single fence refer to the <c>SetEventOnCompletion</c> method.</para>
		/// <para>If hEvent is a null handle, then this API will not return until the specified fence value(s) have been reached.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-seteventonmultiplefencecompletion HRESULT
		// SetEventOnMultipleFenceCompletion( [in] ID3D12Fence * const *ppFences, [in] const UINT64 *pFenceValues, UINT NumFences,
		// D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags, HANDLE hEvent );
		[PreserveSig]
		new HRESULT SetEventOnMultipleFenceCompletion([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D12Fence[] ppFences,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] pFenceValues, int NumFences, D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags,
			HEVENT hEvent);

		/// <summary>This method sets residency priorities of a specified list of objects.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of objects in the <i>ppObjects</i> and <i>pPriorities</i> arrays.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b>ID3D12Pageable*</b></para>
		/// <para>Specifies an array, of length <i>NumObjects</i>, containing references to <c>ID3D12Pageable</c> objects.</para>
		/// </param>
		/// <param name="pPriorities">
		/// <para>Type: <b>const <c>D3D12_RESIDENCY_PRIORITY</c>*</b></para>
		/// <para>Specifies an array, of length <i>NumObjects</i>, of <c>D3D12_RESIDENCY_PRIORITY</c> values for the list of objects.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>For more information, refer to <c>Residency</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-setresidencypriority HRESULT
		// SetResidencyPriority( UINT NumObjects, [in] ID3D12Pageable * const *ppObjects, [in] const D3D12_RESIDENCY_PRIORITY *pPriorities );
		[PreserveSig]
		new HRESULT SetResidencyPriority(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESIDENCY_PRIORITY[] pPriorities);

		/// <summary>Creates a pipeline state object from a pipeline state stream description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PIPELINE_STATE_STREAM_DESC</c>*</b></para>
		/// <para>The address of a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> structure that describes the pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// </para>
		/// <para>The pipeline state object is an immutable state object. It contains no methods.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function takes the pipeline description as a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> and combines the functionality of the
		/// <c>ID3D12Device::CreateGraphicsPipelineState</c> and <c>ID3D12Device::CreateComputePipelineState</c> functions, which take their
		/// pipeline description as the less-flexible <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> and <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>
		/// structs, respectively.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device2-createpipelinestate HRESULT CreatePipelineState(
		// const D3D12_PIPELINE_STATE_STREAM_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreatePipelineState(in D3D12_PIPELINE_STATE_STREAM_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>
		/// Creates a special-purpose diagnostic heap in system memory from an address. The created heap can persist even in the event of a
		/// GPU-fault or device-removed scenario.
		/// </summary>
		/// <param name="pAddress">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The address used to create the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the heap interface ( <c>ID3D12Heap</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the heap can be obtained by using the <b>__uuidof()</b> macro. For
		/// example, <b>__uuidof(ID3D12Heap)</b> will retrieve the <b>GUID</b> of the interface to a heap.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block. On success, the D3D12 runtime will write a pointer to the newly-opened heap into the memory block.
		/// The type of the pointer depends on the provided <b>riid</b> parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to open the existing heap. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The heap is created in system memory and permits CPU access. It wraps the entire VirtualAlloc region.</para>
		/// <para>
		/// Heaps can be used for placed and reserved resources, as orthogonally as other heaps. Restrictions may still exist based on the
		/// flags that cannot be app-chosen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-openexistingheapfromaddress HRESULT
		// OpenExistingHeapFromAddress( [in] const void *pAddress, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT OpenExistingHeapFromAddress([In] IntPtr pAddress, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>
		/// Creates a special-purpose diagnostic heap in system memory from a file mapping object. The created heap can persist even in the
		/// event of a GPU-fault or device-removed scenario.
		/// </summary>
		/// <param name="hFileMapping">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>The handle to the file mapping object to use to create the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the heap interface ( <c>ID3D12Heap</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the heap can be obtained by using the <b>__uuidof()</b> macro. For
		/// example, <b>__uuidof(ID3D12Heap)</b> will retrieve the <b>GUID</b> of the interface to a heap.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block. On success, the D3D12 runtime will write a pointer to the newly-opened heap into the memory block.
		/// The type of the pointer depends on the provided <b>riid</b> parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to open the existing heap. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The heap is created in system memory, and it permits CPU access. It wraps the entire VirtualAlloc region.</para>
		/// <para>
		/// Heaps can be used for placed and reserved resources, as orthogonally as other heaps. Restrictions may still exist based on the
		/// flags that cannot be app-chosen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-openexistingheapfromfilemapping HRESULT
		// OpenExistingHeapFromFileMapping( HANDLE hFileMapping, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT OpenExistingHeapFromFileMapping([In] IntPtr hFileMapping, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>Asynchronously makes objects resident for the device.</summary>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_RESIDENCY_FLAGS</c></b></para>
		/// <para>Controls whether the objects should be made resident if the application is over its memory budget.</para>
		/// </param>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to make resident for the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block; contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>descriptor heaps</description>
		/// </item>
		/// <item>
		/// <description>heaps</description>
		/// </item>
		/// <item>
		/// <description>committed resources</description>
		/// </item>
		/// <item>
		/// <description>query heaps</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pFenceToSignal">
		/// <para>Type: <b><c>ID3D12Fence</c>*</b></para>
		/// <para>A pointer to the fence used to signal when the work is done.</para>
		/// </param>
		/// <param name="FenceValueToSignal">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>An unsigned 64-bit value signaled to the fence when the work is done.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>EnqueueMakeResident</b> performs the same actions as <c>MakeResident</c>, but does not wait for the resources to be made
		/// resident. Instead, <b>EnqueueMakeResident</b> signals a fence when the work is done.
		/// </para>
		/// <para>
		/// The system will not allow work that references the resources that are being made resident by using <b>EnqueueMakeResident</b>
		/// before its fence is signaled. Instead, calls to this API are guaranteed to signal their corresponding fence in order, so the
		/// same fence can be used from call to call.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-enqueuemakeresident HRESULT EnqueueMakeResident(
		// D3D12_RESIDENCY_FLAGS Flags, UINT NumObjects, [in] ID3D12Pageable * const *ppObjects, [in] ID3D12Fence *pFenceToSignal, UINT64
		// FenceValueToSignal );
		[PreserveSig]
		new HRESULT EnqueueMakeResident(D3D12_RESIDENCY_FLAGS Flags, int NumObjects,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D12Pageable[] ppObjects,
			[In] ID3D12Fence pFenceToSignal, ulong FenceValueToSignal);

		/// <summary>Creates a command list in the closed state. Also see <c>ID3D12Device::CreateCommandList</c>.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node (the device's
		/// physical adapter) for which to create the command list. Each bit in the mask corresponds to a single node. Only one bit must be
		/// set. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>Specifies the type of command list to create.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_FLAGS</c></b></para>
		/// <para>Specifies creation flags.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the command list interface to return in ppCommandList.</para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12CommandList</c> or <c>ID3D12GraphicsCommandList</c>
		/// interface for the command list.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the command list.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createcommandlist1 HRESULT CreateCommandList1(
		// [in] UINT nodeMask, [in] D3D12_COMMAND_LIST_TYPE type, D3D12_COMMAND_LIST_FLAGS flags, [in] REFIID riid, [out] void
		// **ppCommandList );
		[PreserveSig]
		new HRESULT CreateCommandList1(uint nodeMask, D3D12_COMMAND_LIST_TYPE type, D3D12_COMMAND_LIST_FLAGS flags, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppCommandList);

		/// <summary>
		/// <para>
		/// Creates an object that represents a session for content protection. You can then provide that session when you're creating
		/// resource or heap objects, to indicate that they should be protected.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Memory contents can't be transferred from a protected resource to an unprotected resource.</para>
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_PROTECTED_RESOURCE_SESSION_DESC</b> structure, describing the session to create.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the <c>ID3D12ProtectedResourceSession</c> interface.</para>
		/// </param>
		/// <param name="ppSession">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives an <c>ID3D12ProtectedResourceSession</c> interface pointer to the created session object.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createprotectedresourcesession HRESULT
		// CreateProtectedResourceSession( [in] const D3D12_PROTECTED_RESOURCE_SESSION_DESC *pDesc, [in] REFIID riid, [out] void **ppSession );
		[PreserveSig]
		new HRESULT CreateProtectedResourceSession(in D3D12_PROTECTED_RESOURCE_SESSION_DESC pDesc, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppSession);

		/// <summary>
		/// Creates both a resource and an implicit heap (optionally for a protected session), such that the heap is big enough to contain
		/// the entire resource, and the resource is mapped to the heap. Also see <c>ID3D12Device::CreateCommittedResource</c> for a code example.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createcommittedresource1 HRESULT
		// CreateCommittedResource1( [in] const D3D12_HEAP_PROPERTIES *pHeapProperties, [in] D3D12_HEAP_FLAGS HeapFlags, [in] const
		// D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialResourceState, [in, optional] const D3D12_CLEAR_VALUE
		// *pOptimizedClearValue, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riidResource, [out,
		// optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateCommittedResource1(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object? ppvResource);

		/// <summary>
		/// Creates a heap (optionally for a protected session) that can be used with placed resources and reserved resources. Also see <c>ID3D12Device::CreateHeap</c>.
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_HEAP_DESC</b> structure that describes the heap.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// heap should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// <para>A heap with a protected session can't be created with the <c>D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER</c> flag.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the heap interface to return in ppvHeap.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Heap</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created heap object.</para>
		/// <para>
		/// <paramref name="ppvHeap"/> can be <c>nullptr</c>, to enable capability testing. When ppvHeap is <c>nullptr</c>, no object is
		/// created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the heap.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para><b>CreateHeap1</b> creates a heap that can be used with placed resources and reserved resources.</para>
		/// <para>
		/// Before releasing the final reference on the heap, your application must ensure that the GPU will no longer read or write to this heap.
		/// </para>
		/// <para>
		/// A placed resource object holds a reference on the heap it is created on; but a reserved resource doesn't hold a reference for
		/// each mapping made to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createheap1 HRESULT CreateHeap1( [in] const
		// D3D12_HEAP_DESC *pDesc, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riid, [out, optional] void
		// **ppvHeap );
		[PreserveSig]
		new HRESULT CreateHeap1(in D3D12_HEAP_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvHeap);

		/// <summary>
		/// <para>
		/// Creates a resource (optionally for a protected session) that is reserved, and not yet mapped to any pages in a heap. Also see <c>ID3D12Device::CreateReservedResource</c>.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Only tiles from heaps created with the same protected resource session can be mapped into a protected reserved resource.</para>
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/>&gt; specifies a value for which clear operations are most optimal. When the created
		/// resource is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or
		/// <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b> flags, you should choose the value with which the clear operation will most
		/// commonly be called. You can call the clear operation with other values, but those operations won't be as efficient as when the
		/// value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource. See <b>Remarks</b>.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateReservedResource</b> is equivalent to <c>D3D11_RESOURCE_MISC_TILED</c> in Direct3D 11. It creates a resource with
		/// virtual memory only, no backing store.
		/// </para>
		/// <para>You need to map the resource to physical memory (that is, to a heap) using <c>CopyTileMappings</c> and <c>UpdateTileMappings</c>.</para>
		/// <para>
		/// These resource types can only be created when the adapter supports tiled resource tier 1 or greater. The tiled resource tier
		/// defines the behavior of accessing a resource that is not mapped to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createreservedresource1 HRESULT
		// CreateReservedResource1( [in] const D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialState, [in, optional] const
		// D3D12_CLEAR_VALUE *pOptimizedClearValue, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riid,
		// [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateReservedResource1(in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, [In, Optional] ID3D12ProtectedResourceSession? pProtectedSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppvResource);

		/// <summary>
		/// <para>
		/// Gets rich info about the size and alignment of memory required for a collection of resources on this adapter. Also see <c>ID3D12Device::GetResourceAllocationInfo</c>.
		/// </para>
		/// <para>
		/// In addition to the <c>D3D12_RESOURCE_ALLOCATION_INFO</c> returned from the method, this version also returns an array of
		/// <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, which provide additional details for each resource description passed as
		/// input. See the pResourceAllocationInfo1 parameter.
		/// </para>
		/// </summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array. This is also the size (the number of elements in) pResourceAllocationInfo1.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <param name="pResourceAllocationInfo1">
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO1</c>*</b></para>
		/// <para>
		/// An array of <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, containing additional details for each resource description
		/// passed as input. This makes it simpler for your application to allocate a heap for multiple resources, and without manually
		/// computing offsets for where each resource should be placed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you're using <c>CreatePlacedResource</c>, your application must use <b>GetResourceAllocationInfo</b> in order to understand
		/// the size and alignment characteristics of texture resources. The results of this method vary depending on the particular
		/// adapter, and must be treated as unique to this adapter and driver version.
		/// </para>
		/// <para>
		/// Your application can't use the output of <b>GetResourceAllocationInfo</b> to understand packed mip properties of textures. To
		/// understand packed mip properties of textures, your application must use <c>GetResourceTiling</c>.
		/// </para>
		/// <para>
		/// Texture resource sizes significantly differ from the information returned by <b>GetResourceTiling</b>, because some adapter
		/// architectures allocate extra memory for textures to reduce the effective bandwidth during common rendering scenarios. This even
		/// includes textures that have constraints on their texture layouts, or have standardized texture layouts. That extra memory can't
		/// be sparsely mapped nor remapped by an application using <c>CreateReservedResource</c> and <c>UpdateTileMappings</c>, so it isn't
		/// reported by <b>GetResourceTiling</b>.
		/// </para>
		/// <para>
		/// Your application can forgo using <b>GetResourceAllocationInfo</b> for buffer resources (
		/// <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>). Buffers have the same size on all adapters, which is merely the smallest multiple of
		/// 64KB that's greater or equal to <c>D3D12_RESOURCE_DESC::Width</c>.
		/// </para>
		/// <para>
		/// When multiple resource descriptions are passed in, the C++ algorithm for calculating a structure size and alignment are used.
		/// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource, reports differing sizes
		/// based on the order of the array. If the 4MB aligned resource is in the middle, then the resulting <b>Size</b> is 12MB.
		/// Otherwise, the resulting <b>Size</b> is 8MB. The <b>Alignment</b> returned would always be 4MB, because it's the superset of all
		/// alignments in the resource array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-getresourceallocationinfo1(uint_uint_constd3d12_resource_desc_d3d12_resource_allocation_info1)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo1( [in] UINT visibleMask, [in] UINT numResourceDescs, [in] const
		// D3D12_RESOURCE_DESC *pResourceDescs, [out] D3D12_RESOURCE_ALLOCATION_INFO1 *pResourceAllocationInfo1 );
		[PreserveSig]
		new D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo1(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_DESC[] pResourceDescs,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_ALLOCATION_INFO1[]? pResourceAllocationInfo1);

		/// <summary>
		/// Creates a lifetime tracker associated with an application-defined callback; the callback receives notifications when the
		/// lifetime of a tracked object is changed.
		/// </summary>
		/// <param name="pOwner">
		/// <para>Type: <b><c>ID3D12LifetimeOwner</c>*</b></para>
		/// <para>A pointer to an <b>ID3D12LifetimeOwner</b> interface representing the application-defined callback.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the interface identifier (IID) of the interface to return in ppvTracker.</para>
		/// </param>
		/// <param name="ppvTracker">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives the requested interface pointer to the created object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createlifetimetracker HRESULT
		// CreateLifetimeTracker( [in] ID3D12LifetimeOwner *pOwner, [in] REFIID riid, [out] void **ppvTracker );
		[PreserveSig]
		new HRESULT CreateLifetimeTracker([In] ID3D12LifetimeOwner pOwner, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvTracker);

		/// <summary>
		/// You can call <b>RemoveDevice</b> to indicate to the Direct3D 12 runtime that the GPU device encountered a problem, and can no
		/// longer be used. Doing so will cause all devices' monitored fences to be signaled. Your application typically doesn't need to
		/// explicitly call <b>RemoveDevice</b>.
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Because device removal triggers all fences to be signaled to <c>UINT64_MAX</c>, you can create a callback for device removal
		/// using an event.
		/// </para>
		/// <para>
		/// <c>HANDLE deviceRemovedEvent = CreateEventW(NULL, FALSE, FALSE, NULL); assert(deviceRemovedEvent != NULL);
		/// _deviceFence-&gt;SetEventOnCompletion(UINT64_MAX, deviceRemoved); HANDLE waitHandle; RegisterWaitForSingleObject(
		/// &amp;waitHandle, deviceRemovedEvent, OnDeviceRemoved, _device.Get(), // Pass the device as our context INFINITE, // No timeout 0
		/// // No flags ); void OnDeviceRemoved(PVOID context, BOOLEAN) { ID3D12Device* removedDevice = (ID3D12Device*)context; HRESULT
		/// removedReason = removedDevice-&gt;GetDeviceRemovedReason(); // Perform app-specific device removed operation, such as logging or
		/// inspecting DRED output }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-removedevice void RemoveDevice();
		[PreserveSig]
		new void RemoveDevice();

		/// <summary>Queries reflection metadata about available meta commands.</summary>
		/// <param name="pNumMetaCommands">
		/// <para>Type: [in, out] <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a <c>UINT</c> containing the number of meta commands to query for. This field determines the size of the
		/// <i>pDescs</i> array, unless <i>pDescs</i> is <b>nullptr</b>.
		/// </para>
		/// </param>
		/// <param name="pDescs">
		/// <para>Type: [out, optional] <b><c>D3D12_META_COMMAND_DESC</c>*</b></para>
		/// <para>
		/// An optional pointer to an array of <c>D3D12_META_COMMAND_DESC</c> containing the descriptions of the available meta commands.
		/// Pass <c>nullptr</c> to have the number of available meta commands returned in <i>pNumMetaCommands</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-enumeratemetacommands HRESULT
		// EnumerateMetaCommands( UINT *pNumMetaCommands, D3D12_META_COMMAND_DESC *pDescs );
		[PreserveSig]
		new HRESULT EnumerateMetaCommands(ref int pNumMetaCommands, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_META_COMMAND_DESC[]? pDescs);

		/// <summary>Queries reflection metadata about the parameters of the specified meta command.</summary>
		/// <param name="CommandId">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier (GUID) of the meta command whose parameters you wish to be returned in <i>pParameterDescs</i>.</para>
		/// </param>
		/// <param name="Stage">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_STAGE</b></para>
		/// <para>
		/// A <c>D3D12_META_COMMAND_PARAMETER_STAGE</c> specifying the stage of the parameters that you wish to be included in the query.
		/// </para>
		/// </param>
		/// <param name="pTotalStructureSizeInBytes">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// An optional pointer to a <c>UINT</c> containing the size of the structure containing the parameter values, which you pass when
		/// creating/initializing/executing the meta command, as appropriate.
		/// </para>
		/// </param>
		/// <param name="pParameterCount">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a <c>UINT</c> containing the number of parameters to query for. This field determines the size of the
		/// <i>pParameterDescs</i> array, unless <i>pParameterDescs</i> is <b>nullptr</b>.
		/// </para>
		/// </param>
		/// <param name="pParameterDescs">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_DESC*</b></para>
		/// <para>
		/// An optional pointer to an array of <c>D3D12_META_COMMAND_PARAMETER_DESC</c> containing the descriptions of the parameters. Pass
		/// <b>nullptr</b> to have the parameter count returned in <i>pParameterCount</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-enumeratemetacommandparameters HRESULT
		// EnumerateMetaCommandParameters( [in] REFGUID CommandId, [in] D3D12_META_COMMAND_PARAMETER_STAGE Stage, [out, optional] UINT
		// *pTotalStructureSizeInBytes, [in, out] UINT *pParameterCount, [out, optional] D3D12_META_COMMAND_PARAMETER_DESC *pParameterDescs );
		[PreserveSig]
		new HRESULT EnumerateMetaCommandParameters(in Guid CommandId, D3D12_META_COMMAND_PARAMETER_STAGE Stage, out uint pTotalStructureSizeInBytes,
			ref int pParameterCount, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D12_META_COMMAND_PARAMETER_DESC[]? pParameterDescs);

		/// <summary>Creates an instance of the specified meta command.</summary>
		/// <param name="CommandId">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier (GUID) of the meta command that you wish to instantiate.</para>
		/// </param>
		/// <param name="NodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the
		/// device's physical adapters) to which the meta command applies. Each bit in the mask corresponds to a single node. Only one bit
		/// must be set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="pCreationParametersData">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>An optional pointer to a constant structure containing the values of the parameters for creating the meta command.</para>
		/// </param>
		/// <param name="CreationParametersDataSizeInBytes">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>A <c>SIZE_T</c> containing the size of the structure pointed to by <i>pCreationParametersData</i>, if set, otherwise 0.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in <i>ppMetaCommand</i>. This
		/// is expected to be the GUID of <c>ID3D12MetaCommand</c>.
		/// </para>
		/// </param>
		/// <param name="ppMetaCommand">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the meta command. This is the address of a pointer to an
		/// <c>ID3D12MetaCommand</c>, representing the meta command created.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>The current hardware does not support the algorithm being requested</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createmetacommand HRESULT CreateMetaCommand(
		// [in] REFGUID CommandId, [in] UINT NodeMask, [in, optional] const void *pCreationParametersData, [in] SIZE_T
		// CreationParametersDataSizeInBytes, REFIID riid, [out] void **ppMetaCommand );
		[PreserveSig]
		new HRESULT CreateMetaCommand(in Guid CommandId, uint NodeMask, [In, Optional] IntPtr pCreationParametersData, [In] SizeT CreationParametersDataSizeInBytes,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppMetaCommand);

		/// <summary>Creates an <c>ID3D12StateObject</c>.</summary>
		/// <param name="pDesc">The description of the state object to create.</param>
		/// <param name="riid">The GUID of the interface to create. Use <i>__uuidof(ID3D12StateObject)</i>.</param>
		/// <param name="ppStateObject">The returned state object.</param>
		/// <returns>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>E_INVALIDARG if one of the input parameters is invalid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY if sufficient memory is not available to create the handle.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>Direct3D 12 Return Codes</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createstateobject HRESULT CreateStateObject(
		// [in] const D3D12_STATE_OBJECT_DESC *pDesc, REFIID riid, [out] void **ppStateObject );
		[PreserveSig]
		new HRESULT CreateStateObject(in D3D12_STATE_OBJECT_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppStateObject);

		/// <summary>Query the driver for resource requirements to build an acceleration structure.</summary>
		/// <param name="pDesc">
		/// <para>
		/// Description of the acceleration structure build. This structure is shared with <c>BuildRaytracingAccelerationStructure</c>. For
		/// more information, see <c>D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS</c>.
		/// </para>
		/// <para>
		/// The implementation is allowed to look at all the CPU parameters in this struct and nested structs. It may not
		/// inspect/dereference any GPU virtual addresses, other than to check to see if a pointer is NULL or not, such as the optional
		/// transform in <c>D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC</c>, without dereferencing it. In other words, the calculation of
		/// resource requirements for the acceleration structure does not depend on the actual geometry data (such as vertex positions),
		/// rather it can only depend on overall properties, such as the number of triangles, number of instances etc.
		/// </para>
		/// </param>
		/// <param name="pInfo">The result of the query (in a <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO</c> structure).</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The input acceleration structure description is the same as what goes into <c>BuildRaytracingAccelerationStructure</c>. The
		/// result of this function lets the application provide the correct amount of output storage and scratch storage to
		/// <b>BuildRaytracingAccelerationStructure</b> given the same geometry.
		/// </para>
		/// <para>
		/// Builds can also be done with the same configuration passed to <b>GetAccelerationStructurePrebuildInfo</b> overall except equal
		/// or smaller counts for the number of geometries/instances or the number of vertices/indices/AABBs in any given geometry. In this
		/// case the storage requirements reported with the original sizes passed to <b>GetRaytracingAccelerationStructurePrebuildInfo</b>
		/// will be valid – the build may actually consume less space but not more. This is handy for app scenarios where having
		/// conservatively large storage allocated for acceleration structures is fine.
		/// </para>
		/// <para>
		/// This method is on the device interface as opposed to command list on the assumption that drivers must be able to calculate
		/// resource requirements for an acceleration structure build from only looking at the CPU-visible portions of the call, without
		/// having to dereference any pointers to GPU memory containing actual vertex data, index data, etc.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-getraytracingaccelerationstructureprebuildinfo
		// void GetRaytracingAccelerationStructurePrebuildInfo( [in] const D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS *pDesc,
		// [out] D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO *pInfo );
		[PreserveSig]
		new void GetRaytracingAccelerationStructurePrebuildInfo(in D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS pDesc, out D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO pInfo);

		/// <summary>
		/// Reports the compatibility of serialized data, such as a serialized raytracing acceleration structure resulting from a call to
		/// <c>CopyRaytracingAccelerationStructure</c> with mode <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_SERIALIZE</c>, with
		/// the current device/driver.
		/// </summary>
		/// <param name="SerializedDataType">The type of the serialized data. For more information, see <c>D3D12_SERIALIZED_DATA_TYPE</c>.</param>
		/// <param name="pIdentifierToCheck">
		/// Identifier from the header of the serialized data to check with the driver. For more information, see <c>D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER</c>.
		/// </param>
		/// <returns>The returned compatibility status. For more information, see <c>D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-checkdrivermatchingidentifier
		// D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS CheckDriverMatchingIdentifier( [in] D3D12_SERIALIZED_DATA_TYPE SerializedDataType, [in]
		// const D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER *pIdentifierToCheck );
		[PreserveSig]
		new D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS CheckDriverMatchingIdentifier(D3D12_SERIALIZED_DATA_TYPE SerializedDataType,
			in D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER pIdentifierToCheck);

		/// <summary>Sets the mode for driver background processing optimizations.</summary>
		/// <param name="Mode">
		/// <para>Type: <b><c>D3D12_BACKGROUND_PROCESSING_MODE</c></b></para>
		/// <para>The level of dynamic optimization to apply to GPU work that's subsequently submitted.</para>
		/// </param>
		/// <param name="MeasurementsAction">
		/// <para>Type: <b><c>D3D12_MEASUREMENTS_ACTION</c></b></para>
		/// <para>The action to take with the results of earlier workload instrumentation.</para>
		/// </param>
		/// <param name="hEventToSignalUponCompletion">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>
		/// An optional handle to signal when the function is complete. For example, if MeasurementsAction is set to
		/// <c>D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS</c>, then hEventToSignalUponCompletion is signaled when all resulting compilations
		/// have finished.
		/// </para>
		/// </param>
		/// <param name="pbFurtherMeasurementsDesired">
		/// <para>Type: <b><c>BOOL</c>*</b></para>
		/// <para>
		/// An optional pointer to a Boolean value. The function sets the value to <c>true</c> to indicate that you should continue
		/// profiling, otherwise, <c>false</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A graphics driver can use idle-priority background CPU threads to dynamically recompile shader programs. That can improve GPU
		/// performance by specializing shader code to better match details of the hardware that it's running on, and/or the context in
		/// which it's being used.
		/// </para>
		/// <para>
		/// As a developer, you don't have to do anything to benefit from this feature (over time, as drivers adopt background processing
		/// optimizations, existing shaders will automatically be tuned more efficiently). But, when you're profiling your code, you'll
		/// probably want to call <b>SetBackgroundProcessingMode</b> to make sure that any driver background processing optimizations have
		/// taken place before you take timing measurements. Here's an example.
		/// </para>
		/// <para>
		/// <c>SetBackgroundProcessingMode( D3D12_BACKGROUND_PROCESSING_MODE_ALLOW_INTRUSIVE_MEASUREMENTS, D3D_MEASUREMENTS_ACTION_KEEP_ALL,
		/// nullptr, nullptr); // Here, prime the system by rendering some typical content. // For example, a level flythrough.
		/// SetBackgroundProcessingMode( D3D12_BACKGROUND_PROCESSING_MODE_ALLOWED, D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS, nullptr,
		/// nullptr); // Here, continue rendering. This time with dynamic optimizations applied. // And then take your measurements.</c>
		/// </para>
		/// <para>
		/// <c>PIX</c> automatically uses <b>SetBackgroundProcessingMode</b>—first to prime the system,and then to prevent any further
		/// changes from taking place in the middle of its analysis. PIX waits on an event (to make sure all background shader recompiles
		/// have finished) before it starts taking measurements.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device6-setbackgroundprocessingmode
		// HRESULT SetBackgroundProcessingMode( [in] D3D12_BACKGROUND_PROCESSING_MODE Mode, [in] D3D12_MEASUREMENTS_ACTION MeasurementsAction, [in] HANDLE hEventToSignalUponCompletion, [out] BOOL *pbFurtherMeasurementsDesired );
		[PreserveSig]
		HRESULT SetBackgroundProcessingMode(D3D12_BACKGROUND_PROCESSING_MODE Mode, D3D12_MEASUREMENTS_ACTION MeasurementsAction,
			[In] HEVENT hEventToSignalUponCompletion, out bool pbFurtherMeasurementsDesired);
	}

	/// <summary>
	/// <para>Represents a virtual adapter.</para>
	/// <para>This interface extends <c>ID3D12Device6</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12device7
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Device7")]
	[ComImport, Guid("5c014b53-68a1-4b9b-8bd1-dd6046b9358b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Device7 : ID3D12Device6
	{
		/// <summary>Gets application-defined data from a device object.</summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> that is associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <i>pData</i> points to, and on output
		/// contains the size, in bytes, of the amount of data that <b>GetPrivateData</b> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// A pointer to a memory block that receives the data from the device object if <i>pDataSize</i> points to a value that specifies a
		/// buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// If the data returned is a pointer to an <c>IUnknown</c>, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] UINT *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Sets application-defined data to a device object and associates that data with an application-defined <b>GUID</b>.</summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> to associate with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size in bytes of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>
		/// A pointer to a memory block that contains the data to be stored with this device object. If <i>pData</i> is <b>NULL</b>,
		/// <i>DataSize</i> must also be 0, and any data that was previously associated with the <b>GUID</b> specified in <i>guid</i> will
		/// be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// Rather than using the Direct3D 11 debug object naming scheme of calling <b>ID3D12Object::SetPrivateData</b> using
		/// <b>WKPDID_D3DDebugObjectName</b> with an ASCII name, call <c>ID3D12Object::SetName</c> with a UNICODE name.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] UINT DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associates an <c>IUnknown</c>-derived interface with the device object, and associates that interface with an
		/// application-defined <b>GUID</b>.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> to associate with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const <c>IUnknown</c>*</b></para>
		/// <para>
		/// A pointer to the <c>IUnknown</c>-derived interface to be associated with the device object. Its reference count is incremented
		/// when set, and its reference count is decremented when either the <c>ID3D12Object</c> is destroyed, or when the data is
		/// overwritten by calling <c>SetPrivateData</c> or <b>SetPrivateDataInterface</b> with the same <b>GUID</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 return codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object? pData);

		/// <summary>Associates a name with the device object. This name is for use in debug diagnostics and tools.</summary>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>A <b>NULL</b>-terminated <b>UNICODE</b> string that contains the name to associate with the device object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method takes UNICODE names.</para>
		/// <para>
		/// Note that this is simply a convenience wrapper around <c>ID3D12Object::SetPrivateData</c> with
		/// <b>WKPDID_D3DDebugObjectNameW</b>. Therefore names which are set with <c>SetName</c> can be retrieved with
		/// <c>ID3D12Object::GetPrivateData</c> with the same GUID. Additionally, D3D12 supports narrow strings for names, using the
		/// <b>WKPDID_D3DDebugObjectName</b> GUID directly instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setname HRESULT SetName( [in] LPCWSTR Name );
		[PreserveSig]
		new HRESULT SetName([MarshalAs(UnmanagedType.LPWStr)] string Name);

		/// <summary>Reports the number of physical adapters (nodes) that are associated with this device.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of physical adapters (nodes) that this device has.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getnodecount UINT GetNodeCount();
		[PreserveSig]
		new uint GetNodeCount();

		/// <summary>
		/// <para>Creates a command queue.</para>
		/// <para>Also see <c>ID3D12Device9::CreateCommandQueue1</c>.</para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_COMMAND_QUEUE_DESC</c>*</b></para>
		/// <para>Specifies a <b>D3D12_COMMAND_QUEUE_DESC</b> that describes the command queue.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier (GUID) for the command queue interface. See <b>Remarks</b>. An input parameter.</para>
		/// </param>
		/// <param name="ppCommandQueue">
		/// <para>Type: [out] <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12CommandQueue</c> interface for the command queue.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the command queue. See <c>Direct3D 12 return
		/// codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the command queue can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12CommandQueue) will get the <b>GUID</b> of the interface to a command queue.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandqueue HRESULT CreateCommandQueue(
		// const D3D12_COMMAND_QUEUE_DESC *pDesc, REFIID riid, void **ppCommandQueue );
		[PreserveSig]
		new HRESULT CreateCommandQueue(in D3D12_COMMAND_QUEUE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppCommandQueue);

		/// <summary>Creates a command allocator object.</summary>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// A <c>D3D12_COMMAND_LIST_TYPE</c>-typed value that specifies the type of command allocator to create. The type of command
		/// allocator can be the type that records either direct command lists or bundles.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the command allocator interface ( <c>ID3D12CommandAllocator</c>). The
		/// <b>REFIID</b>, or <b>GUID</b>, of the interface to the command allocator can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12CommandAllocator) will get the <b>GUID</b> of the interface to a command allocator.
		/// </para>
		/// </param>
		/// <param name="ppCommandAllocator">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12CommandAllocator</c> interface for the command allocator.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the command allocator. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The device creates command lists from the command allocator. Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12Device::CreateCommandAllocator</b> as follows:</para>
		/// <para>
		/// <c>ThrowIfFailed(pDevice-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT, IID_PPV_ARGS(&amp;m_commandAllocator)));
		/// ThrowIfFailed(pDevice-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_BUNDLE, IID_PPV_ARGS(&amp;m_bundleAllocator)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandallocator HRESULT
		// CreateCommandAllocator( [in] D3D12_COMMAND_LIST_TYPE type, REFIID riid, [out] void **ppCommandAllocator );
		[PreserveSig]
		new HRESULT CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE type, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppCommandAllocator);

		/// <summary>Creates a graphics pipeline state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure that describes graphics pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>). The <b>REFIID</b>,
		/// or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// The pipeline state object is an immutable state object. It contains no methods.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-creategraphicspipelinestate HRESULT
		// CreateGraphicsPipelineState( [in] const D3D12_GRAPHICS_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreateGraphicsPipelineState(in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>Creates a compute pipeline state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structure that describes compute pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>). The <b>REFIID</b>,
		/// or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// The pipeline state object is an immutable state object. It contains no methods.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcomputepipelinestate HRESULT
		// CreateComputePipelineState( [in] const D3D12_COMPUTE_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreateComputePipelineState(in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>Creates a command list.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node (the device's
		/// physical adapter) for which to create the command list. Each bit in the mask corresponds to a single node. Only one bit must be
		/// set. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>Specifies the type of command list to create.</para>
		/// </param>
		/// <param name="pCommandAllocator">
		/// <para>Type: <b><c>ID3D12CommandAllocator</c>*</b></para>
		/// <para>A pointer to the command allocator object from which the device creates command lists.</para>
		/// </param>
		/// <param name="pInitialState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>
		/// An optional pointer to the pipeline state object that contains the initial pipeline state for the command list. If it is
		/// <c>nullptr</c>, then the runtime sets a dummy initial pipeline state, so that drivers don't have to deal with undefined state.
		/// The overhead for this is low, particularly for a command list, for which the overall cost of recording the command list likely
		/// dwarfs the cost of a single initial state setting. So there's little cost in not setting the initial pipeline state parameter,
		/// if doing so is inconvenient.
		/// </para>
		/// <para>
		/// For bundles, on the other hand, it might make more sense to try to set the initial state parameter (since bundles are likely
		/// smaller overall, and can be reused frequently).
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the command list interface to return in ppCommandList.</para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12CommandList</c> or <c>ID3D12GraphicsCommandList</c>
		/// interface for the command list.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the command list.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>The device creates command lists from the command allocator.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandlist HRESULT CreateCommandList( [in]
		// UINT nodeMask, [in] D3D12_COMMAND_LIST_TYPE type, [in] ID3D12CommandAllocator *pCommandAllocator, [in, optional]
		// ID3D12PipelineState *pInitialState, [in] REFIID riid, [out] void **ppCommandList );
		[PreserveSig]
		new HRESULT CreateCommandList(uint nodeMask, D3D12_COMMAND_LIST_TYPE type, [In] ID3D12CommandAllocator pCommandAllocator, [In, Optional] ID3D12PipelineState? pInitialState,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppCommandList);

		/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
		/// <param name="Feature">
		/// <para>Type: <b><c>D3D12_FEATURE</c></b></para>
		/// <para>A constant from the <c>D3D12_FEATURE</c> enumeration describing the feature(s) that you want to query for support.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// A pointer to a data structure that corresponds to the value of the <i>Feature</i> parameter. To determine the corresponding data
		/// structure for each constant, see <c>D3D12_FEATURE</c>.
		/// </para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the structure pointed to by the <i>pFeatureSupportData</i> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns <b>S_OK</b> if successful. Returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// <i>pFeatureSupportData</i> parameter or if a size mismatch is detected for the <i>FeatureSupportDataSize</i> parameter.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As a usage example, to check for ray tracing support, specify the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS5</c> structure in the
		/// <i>pFeatureSupportData</i> parameter. When the function completes successfully, access the <i>RaytracingTier</i> field (which
		/// specifies the supported ray tracing tier) of the now-populated <b>D3D12_FEATURE_DATA_D3D12_OPTIONS5</b> structure.
		/// </para>
		/// <para>For more info, see <c>Capability Querying</c>.</para>
		/// <para><c></c><c></c><c></c> Hardware support for DXGI Formats</para>
		/// <para>To view tables of DXGI formats and hardware features, refer to:</para>
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
		/// <description><c>Format Support for Direct3D Feature Level 10.1 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format Support for Direct3D Feature Level 10.0 Hardware</c></description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>The <c>D3D1211on12</c> sample uses <b>ID3D12Device::CheckFeatureSupport</b> as follows:</para>
		/// <para>
		/// <c>inline UINT8 D3D12GetFormatPlaneCount( _In_ ID3D12Device* pDevice, DXGI_FORMAT Format ) { D3D12_FEATURE_DATA_FORMAT_INFO
		/// formatInfo = {Format}; if (FAILED(pDevice-&gt;CheckFeatureSupport(D3D12_FEATURE_FORMAT_INFO, &amp;formatInfo,
		/// sizeof(formatInfo)))) { return 0; } return formatInfo.PlaneCount; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-checkfeaturesupport HRESULT CheckFeatureSupport(
		// D3D12_FEATURE Feature, [in, out] void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D12_FEATURE Feature, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a descriptor heap object.</summary>
		/// <param name="pDescriptorHeapDesc">
		/// <para>Type: <b>const <c>D3D12_DESCRIPTOR_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DESCRIPTOR_HEAP_DESC</c> structure that describes the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the descriptor heap interface. See Remarks. An input parameter.</para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the descriptor heap. <i>ppvHeap</i> can be NULL, to enable capability
		/// testing. When <i>ppvHeap</i> is NULL, no object will be created and S_FALSE will be returned when <i>pDescriptorHeapDesc</i> is valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the descriptor heap object. See <c>Direct3D
		/// 12 Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the descriptor heap can be obtained by using the __uuidof() macro. For
		/// example, __uuidof( <c>ID3D12DescriptorHeap</c>) will get the <b>GUID</b> of the interface to a descriptor heap.
		///  Examples The <c>D3D12HelloWorld</c> sample uses <b>ID3D12Device::CreateDescriptorHeap</b> as follows:</para>
		/// <para>Describe and create a render target view (RTV) descriptor heap.</para>
		/// <para>
		/// <c>// Create descriptor heaps. { // Describe and create a render target view (RTV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// rtvHeapDesc = {}; rtvHeapDesc.NumDescriptors = FrameCount; rtvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV; rtvHeapDesc.Flags
		/// = D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;rtvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_rtvHeap))); m_rtvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV); } // Create frame resources. {
		/// CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); // Create a RTV for each frame. for
		/// (UINT n = 0; n &lt; FrameCount; n++) { ThrowIfFailed(m_swapChain-&gt;GetBuffer(n, IID_PPV_ARGS(&amp;m_renderTargets[n])));
		/// m_device-&gt;CreateRenderTargetView(m_renderTargets[n].Get(), nullptr, rtvHandle); rtvHandle.Offset(1, m_rtvDescriptorSize); }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createdescriptorheap HRESULT
		// CreateDescriptorHeap( [in] const D3D12_DESCRIPTOR_HEAP_DESC *pDescriptorHeapDesc, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateDescriptorHeap(in D3D12_DESCRIPTOR_HEAP_DESC pDescriptorHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>
		/// Gets the size of the handle increment for the given type of descriptor heap. This value is typically used to increment a handle
		/// into a descriptor array by the correct amount.
		/// </summary>
		/// <param name="DescriptorHeapType">
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to get the size of the handle
		/// increment for.
		/// </param>
		/// <returns>Returns the size of the handle increment for the given type of descriptor heap, including any necessary padding.</returns>
		/// <remarks>
		/// <para>
		/// The descriptor size returned by this method is used as one input to the helper structures <c>CD3DX12_CPU_DESCRIPTOR_HANDLE</c>
		/// and <c>CD3DX12_GPU_DESCRIPTOR_HANDLE</c>.
		///  Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12Device::GetDescriptorHandleIncrementSize</b> as follows:</para>
		/// <para>
		/// Create the descriptor heap for the resources. The <c>m_rtvDescriptorSize</c> variable stores the render target view descriptor
		/// handle increment size, and is used in the <b>Create frame resources</b> section of the code.
		/// </para>
		/// <para>
		/// <c>// Create descriptor heaps. { // Describe and create a render target view (RTV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// rtvHeapDesc = {}; rtvHeapDesc.NumDescriptors = FrameCount; rtvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV; rtvHeapDesc.Flags
		/// = D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;rtvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_rtvHeap))); // Describe and create a depth stencil view (DSV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// dsvHeapDesc = {}; dsvHeapDesc.NumDescriptors = 1; dsvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_DSV; dsvHeapDesc.Flags =
		/// D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;dsvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_dsvHeap))); // Describe and create a constant buffer view (CBV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// cbvHeapDesc = {}; cbvHeapDesc.NumDescriptors = CbvCountPerFrame * FrameCount; cbvHeapDesc.Type =
		/// D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV; cbvHeapDesc.Flags = D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE;
		/// ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;cbvHeapDesc, IID_PPV_ARGS(&amp;m_cbvHeap))); // Describe and create a heap
		/// for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1; queryHeapDesc.Type =
		/// D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc,
		/// IID_PPV_ARGS(&amp;m_queryHeap))); m_rtvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV); m_cbvSrvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV); } // Create frame resources. {
		/// CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); // Create a RTV and a command
		/// allocator for each frame. for (UINT n = 0; n &lt; FrameCount; n++) { ThrowIfFailed(m_swapChain-&gt;GetBuffer(n,
		/// IID_PPV_ARGS(&amp;m_renderTargets[n]))); m_device-&gt;CreateRenderTargetView(m_renderTargets[n].Get(), nullptr, rtvHandle);
		/// rtvHandle.Offset(1, m_rtvDescriptorSize); ThrowIfFailed(m_device-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT,
		/// IID_PPV_ARGS(&amp;m_commandAllocators[n]))); } }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getdescriptorhandleincrementsize UINT
		// GetDescriptorHandleIncrementSize( [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType );
		[PreserveSig]
		new uint GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType);

		/// <summary>Creates a root signature layout.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set bits to identify the nodes (the device's
		/// physical adapters) to which the root signature is to apply. Each bit in the mask corresponds to a single node. Refer to
		/// <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="pBlobWithRootSignature">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>A pointer to the source data for the serialized signature.</para>
		/// </param>
		/// <param name="blobLengthInBytes">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>The size, in bytes, of the block of memory that <i>pBlobWithRootSignature</i> points to.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the root signature interface. See Remarks. An input parameter.</para>
		/// </param>
		/// <param name="ppvRootSignature">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the root signature.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// <para>This method returns <b>E_INVALIDARG</b> if the blob that <i>pBlobWithRootSignature</i> points to is invalid.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application procedurally generates a <c>D3D12_ROOT_SIGNATURE_DESC</c> data structure, it must pass a pointer to this
		/// <b>D3D12_ROOT_SIGNATURE_DESC</b> in a call to <c>D3D12SerializeRootSignature</c> to make the serialized form. The application
		/// then passes the serialized form to <i>pBlobWithRootSignature</i> in a call to <b>ID3D12Device::CreateRootSignature</b>.
		/// </para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the root signature layout can be obtained by using the __uuidof() macro.
		/// For example, __uuidof( <c>ID3D12RootSignature</c>) will get the <b>GUID</b> of the interface to a root signature.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12Device::CreateRootSignature</b> as follows:</para>
		/// <para>Create an empty root signature.</para>
		/// <para>
		/// <c>CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc; rootSignatureDesc.Init(0, nullptr, 0, nullptr,
		/// D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT); ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
		/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
		/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(), IID_PPV_ARGS(&amp;m_rootSignature)));</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createrootsignature HRESULT CreateRootSignature(
		// [in] UINT nodeMask, [in] const void *pBlobWithRootSignature, [in] SIZE_T blobLengthInBytes, REFIID riid, [out] void
		// **ppvRootSignature );
		[PreserveSig]
		new HRESULT CreateRootSignature(uint nodeMask, [In] IntPtr pBlobWithRootSignature, [In] SizeT blobLengthInBytes, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppvRootSignature);

		/// <summary>Creates a constant-buffer view for accessing resource data.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_CONSTANT_BUFFER_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_CONSTANT_BUFFER_VIEW_DESC</c> structure that describes the constant-buffer view.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the constant-buffer view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createconstantbufferview void
		// CreateConstantBufferView( [in, optional] const D3D12_CONSTANT_BUFFER_VIEW_DESC *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE
		// DestDescriptor );
		[PreserveSig]
		new void CreateConstantBufferView([In, Optional] StructPointer<D3D12_CONSTANT_BUFFER_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the shader resource.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c> structure that describes the shader-resource view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and for buffers SRVs target a full buffer and are typed (not raw or structured), and for textures SRVs target a full texture,
		/// all mips and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// Describes the CPU descriptor handle that represents the shader-resource view. This handle can be created in a shader-visible or
		/// non-shader-visible descriptor heap.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c></c><c></c><c></c> Processing YUV 4:2:0 video formats</para>
		/// <para>
		/// An app must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling
		/// <b>CreateShaderResourceView</b> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a
		/// 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes
		/// (together) maps only the U and V planes as a single resource view.
		/// </para>
		/// <para>YUV 4:2:0 formats are listed in <c>DXGI_FORMAT</c>. Examples The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12Device::CreateShaderResourceView</b> as follows:</para>
		/// <para>Describe and create two shader resource views based on one description.</para>
		/// <para>
		/// <c>D3D12_SHADER_RESOURCE_VIEW_DESC srvDesc = {}; srvDesc.Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING;
		/// srvDesc.Format = DXGI_FORMAT_UNKNOWN; srvDesc.ViewDimension = D3D12_SRV_DIMENSION_BUFFER; srvDesc.Buffer.FirstElement = 0;
		/// srvDesc.Buffer.NumElements = ParticleCount; srvDesc.Buffer.StructureByteStride = sizeof(Particle); srvDesc.Buffer.Flags =
		/// D3D12_BUFFER_SRV_FLAG_NONE; CD3DX12_CPU_DESCRIPTOR_HANDLE srvHandle0(m_srvUavHeap-&gt;GetCPUDescriptorHandleForHeapStart(),
		/// SrvParticlePosVelo0 + index, m_srvUavDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// srvHandle1(m_srvUavHeap-&gt;GetCPUDescriptorHandleForHeapStart(), SrvParticlePosVelo1 + index, m_srvUavDescriptorSize);
		/// m_device-&gt;CreateShaderResourceView(m_particleBuffer0[index].Get(), &amp;srvDesc, srvHandle0);
		/// m_device-&gt;CreateShaderResourceView(m_particleBuffer1[index].Get(), &amp;srvDesc, srvHandle1);</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview void
		// CreateShaderResourceView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_SHADER_RESOURCE_VIEW_DESC *pDesc,
		// [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateShaderResourceView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_SHADER_RESOURCE_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a view for unordered accessing.</summary>
		/// <param name="pResource">
		/// <para>Type: [in, optional] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the unordered access.</para>
		/// <para>At least one of <i>pResource</i> or <i>pDesc</i> must be provided.</para>
		/// <para>
		/// A null <i>pResource</i> is used to initialize a null descriptor, which guarantees Direct3D 11-like null binding behavior
		/// (reading 0s, writes are discarded), but must have a valid <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pCounterResource">
		/// <para>Type: [in, optional] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>The <c>ID3D12Resource</c> for the counter (if any) associated with the UAV.</para>
		/// <para>
		/// If <i>pCounterResource</i> is not specified, then the <b>CounterOffsetInBytes</b> member of the <c>D3D12_BUFFER_UAV</c>
		/// structure must be 0.
		/// </para>
		/// <para>
		/// If <i>pCounterResource</i> is specified, then there is a counter associated with the UAV, and the runtime performs validation of
		/// the following requirements:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The <b>StructureByteStride</b> member of the <c>D3D12_BUFFER_UAV</c> structure must be greater than 0.</description>
		/// </item>
		/// <item>
		/// <description>The format must be DXGI_FORMAT_UNKNOWN.</description>
		/// </item>
		/// <item>
		/// <description>The D3D12_BUFFER_UAV_FLAG_RAW flag (a <c>D3D12_BUFFER_UAV_FLAGS</c> enumeration constant) must not be set.</description>
		/// </item>
		/// <item>
		/// <description>Both of the resources ( <i>pResource</i> and <i>pCounterResource</i>) must be buffers.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The <b>CounterOffsetInBytes</b> member of the <c>D3D12_BUFFER_UAV</c> structure must be a multiple of
		/// **D3D12_UAV_COUNTER_PLACEMENT_ALIGNMENT** (4096), and must be within the range of the counter resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><i>pResource</i> cannot be NULL</description>
		/// </item>
		/// <item>
		/// <description><i>pDesc</i> cannot be NULL.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in, optional] <b>const <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure that describes the unordered-access view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and for buffers UAVs target a full buffer and are typed, and for textures UAVs target the first mip and all array slices. Not
		/// all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the unordered-access view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createunorderedaccessview void
		// CreateUnorderedAccessView( ID3D12Resource *pResource, ID3D12Resource *pCounterResource, const D3D12_UNORDERED_ACCESS_VIEW_DESC
		// *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateUnorderedAccessView([In, Optional] ID3D12Resource? pResource, [In, Optional] ID3D12Resource? pCounterResource,
			[In, Optional] StructPointer<D3D12_UNORDERED_ACCESS_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the render target.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RENDER_TARGET_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure that describes the render-target view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and RTVs target the first mip and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the destination where the newly-created render target view will reside.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createrendertargetview void
		// CreateRenderTargetView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_RENDER_TARGET_VIEW_DESC *pDesc, [in]
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateRenderTargetView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_RENDER_TARGET_VIEW_DESC> pDesc,
			[In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a depth-stencil view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the depth stencil.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure that describes the depth-stencil view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and DSVs target the first mip and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the depth-stencil view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createdepthstencilview void
		// CreateDepthStencilView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_DEPTH_STENCIL_VIEW_DESC *pDesc, [in]
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateDepthStencilView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_DEPTH_STENCIL_VIEW_DESC> pDesc,
			[In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Create a sampler object that encapsulates sampling information for a texture.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_SAMPLER_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SAMPLER_DESC</c> structure that describes the sampler.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the sampler.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createsampler void CreateSampler( [in] const
		// D3D12_SAMPLER_DESC *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateSampler(in D3D12_SAMPLER_DESC pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Copies descriptors from a source to a destination.</summary>
		/// <param name="NumDestDescriptorRanges">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of destination descriptor ranges to copy to.</para>
		/// </param>
		/// <param name="pDestDescriptorRangeStarts">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>An array of <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> objects to copy to.</para>
		/// <para>All the destination and source descriptors must be in heaps of the same <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>.</para>
		/// </param>
		/// <param name="pDestDescriptorRangeSizes">
		/// <para>Type: <b>const <c>UINT</c>*</b></para>
		/// <para>An array of destination descriptor range sizes to copy to.</para>
		/// </param>
		/// <param name="NumSrcDescriptorRanges">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of source descriptor ranges to copy from.</para>
		/// </param>
		/// <param name="pSrcDescriptorRangeStarts">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>An array of <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> objects to copy from.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// All elements in the pSrcDescriptorRangeStarts parameter must be in a non shader-visible descriptor heap. This is because
		/// shader-visible descriptor heaps may be created in <b>WRITE_COMBINE</b> memory or GPU local memory, which is prohibitively slow
		/// to read from. If your application manages descriptor heaps via copying the descriptors required for a given pass or frame from
		/// local "storage" descriptor heaps to the GPU-bound descriptor heap, use shader-opaque heaps for the storage heaps and copy into
		/// the GPU-visible heap as required.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pSrcDescriptorRangeSizes">
		/// <para>Type: <b>const <c>UINT</c>*</b></para>
		/// <para>An array of source descriptor range sizes to copy from.</para>
		/// </param>
		/// <param name="DescriptorHeapsType">
		/// <para>Type: <b><c>D3D12_DESCRIPTOR_HEAP_TYPE</c></b></para>
		/// <para>
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to copy with. This is required as
		/// different descriptor types may have different sizes.
		/// </para>
		/// <para>Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Where applicable, prefer <c><b>ID3D12Device::CopyDescriptorsSimple</b></c> to this method. It can have a better CPU cache miss
		/// rate due to the linear nature of the copy.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-copydescriptors void CopyDescriptors( [in] UINT
		// NumDestDescriptorRanges, [in] const D3D12_CPU_DESCRIPTOR_HANDLE *pDestDescriptorRangeStarts, [in, optional] const UINT
		// *pDestDescriptorRangeSizes, [in] UINT NumSrcDescriptorRanges, [in] const D3D12_CPU_DESCRIPTOR_HANDLE *pSrcDescriptorRangeStarts,
		// [in, optional] const UINT *pSrcDescriptorRangeSizes, [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType );
		[PreserveSig]
		new void CopyDescriptors(int NumDestDescriptorRanges, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_CPU_DESCRIPTOR_HANDLE[] pDestDescriptorRangeStarts,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? pDestDescriptorRangeSizes, int NumSrcDescriptorRanges,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D12_CPU_DESCRIPTOR_HANDLE[] pSrcDescriptorRangeStarts,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[]? pSrcDescriptorRangeSizes, D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType);

		/// <summary>Copies descriptors from a source to a destination.</summary>
		/// <param name="NumDescriptors">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of descriptors to copy.</para>
		/// </param>
		/// <param name="DestDescriptorRangeStart">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> that describes the destination descriptors to start to copy to.</para>
		/// <para>The destination and source descriptors must be in heaps of the same <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>.</para>
		/// </param>
		/// <param name="SrcDescriptorRangeStart">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> that describes the source descriptors to start to copy from.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// The SrcDescriptorRangeStart parameter must be in a non shader-visible descriptor heap. This is because shader-visible descriptor
		/// heaps may be created in <b>WRITE_COMBINE</b> memory or GPU local memory, which is prohibitively slow to read from. If your
		/// application manages descriptor heaps via copying the descriptors required for a given pass or frame from local "storage"
		/// descriptor heaps to the GPU-bound descriptor heap, then use shader-opaque heaps for the storage heaps and copy into the
		/// GPU-visible heap as required.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="DescriptorHeapsType">
		/// <para>Type: <b><c>D3D12_DESCRIPTOR_HEAP_TYPE</c></b></para>
		/// <para>
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to copy with. This is required as
		/// different descriptor types may have different sizes.
		/// </para>
		/// <para>Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Where applicable, prefer this method to <c><b>ID3D12Device::CopyDescriptors</b></c>. It can have a better CPU cache miss rate
		/// due to the linear nature of the copy.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-copydescriptorssimple void CopyDescriptorsSimple(
		// [in] UINT NumDescriptors, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart, [in] D3D12_CPU_DESCRIPTOR_HANDLE
		// SrcDescriptorRangeStart, [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType );
		[PreserveSig]
		new void CopyDescriptorsSimple(uint NumDescriptors, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart, [In] D3D12_CPU_DESCRIPTOR_HANDLE SrcDescriptorRangeStart,
			D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType);

		/// <summary>Gets the size and alignment of memory required for a collection of resources on this adapter.</summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// <para>If an error occurs, then <b>D3D12_RESOURCE_ALLOCATION_INFO::SizeInBytes</b> equals <b>UINT64_MAX</b>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you're using <c>CreatePlacedResource</c>, your application must use <b>GetResourceAllocationInfo</b> in order to understand
		/// the size and alignment characteristics of texture resources. The results of this method vary depending on the particular
		/// adapter, and must be treated as unique to this adapter and driver version.
		/// </para>
		/// <para>
		/// Your application can't use the output of <b>GetResourceAllocationInfo</b> to understand packed mip properties of textures. To
		/// understand packed mip properties of textures, your application must use <c>GetResourceTiling</c>.
		/// </para>
		/// <para>
		/// Texture resource sizes significantly differ from the information returned by <b>GetResourceTiling</b>, because some adapter
		/// architectures allocate extra memory for textures to reduce the effective bandwidth during common rendering scenarios. This even
		/// includes textures that have constraints on their texture layouts, or have standardized texture layouts. That extra memory can't
		/// be sparsely mapped nor remapped by an application using <c>CreateReservedResource</c> and <c>UpdateTileMappings</c>, so it isn't
		/// reported by <b>GetResourceTiling</b>.
		/// </para>
		/// <para>
		/// Your application can forgo using <b>GetResourceAllocationInfo</b> for buffer resources (
		/// <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>). Buffers have the same size on all adapters, which is merely the smallest multiple of
		/// 64KB that's greater or equal to <c>D3D12_RESOURCE_DESC::Width</c>.
		/// </para>
		/// <para>
		/// When multiple resource descriptions are passed in, the C++ algorithm for calculating a structure size and alignment are used.
		/// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource, reports differing sizes
		/// based on the order of the array. If the 4MB aligned resource is in the middle, then the resulting <b>Size</b> is 12MB.
		/// Otherwise, the resulting <b>Size</b> is 8MB. The <b>Alignment</b> returned would always be 4MB, because it's the superset of all
		/// alignments in the resource array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getresourceallocationinfo(uint_uint_constd3d12_resource_desc)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo( [in] UINT visibleMask, [in] UINT numResourceDescs, [in] const
		// D3D12_RESOURCE_DESC *pResourceDescs );
		[PreserveSig]
		new D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_RESOURCE_DESC[] pResourceDescs);

		/// <summary>
		/// Divulges the equivalent custom heap properties that are used for non-custom heap types, based on the adapter's architectural properties.
		/// </summary>
		/// <param name="nodeMask">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter). Each bit in the mask corresponds to a single node. Only 1 bit must be set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="heapType">
		/// <para>Type: <b><c>D3D12_HEAP_TYPE</c></b></para>
		/// <para>
		/// A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the heap to get properties for. D3D12_HEAP_TYPE_CUSTOM is not supported as a
		/// parameter value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_HEAP_PROPERTIES</c></b></para>
		/// <para>
		/// Returns a <c>D3D12_HEAP_PROPERTIES</c> structure that provides properties for the specified heap. The <b>Type</b> member of the
		/// returned D3D12_HEAP_PROPERTIES is always D3D12_HEAP_TYPE_CUSTOM.
		/// </para>
		/// <para>When <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>::UMA is FALSE, the returned D3D12_HEAP_PROPERTIES members convert as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_COMBINE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L1.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// When D3D12_FEATURE_DATA_ARCHITECTURE::UMA is TRUE and D3D12_FEATURE_DATA_ARCHITECTURE::CacheCoherentUMA is FALSE, the returned
		/// D3D12_HEAP_PROPERTIES members convert as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_COMBINE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// When D3D12_FEATURE_DATA_ARCHITECTURE::UMA is TRUE and D3D12_FEATURE_DATA_ARCHITECTURE::CacheCoherentUMA is TRUE, the returned
		/// D3D12_HEAP_PROPERTIES members convert as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getcustomheapproperties(uint_d3d12_heap_type)
		// D3D12_HEAP_PROPERTIES GetCustomHeapProperties( [in] UINT nodeMask, D3D12_HEAP_TYPE heapType );
		[PreserveSig]
		new D3D12_HEAP_PROPERTIES GetCustomHeapProperties(uint nodeMask, D3D12_HEAP_TYPE heapType);

		/// <summary>
		/// Creates both a resource and an implicit heap, such that the heap is big enough to contain the entire resource, and the resource
		/// is mapped to the heap.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommittedresource HRESULT
		// CreateCommittedResource( [in] const D3D12_HEAP_PROPERTIES *pHeapProperties, [in] D3D12_HEAP_FLAGS HeapFlags, [in] const
		// D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialResourceState, [in, optional] const D3D12_CLEAR_VALUE
		// *pOptimizedClearValue, [in] REFIID riidResource, [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateCommittedResource(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>Creates a heap that can be used with placed resources and reserved resources.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_HEAP_DESC</b> structure that describes the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the heap interface to return in ppvHeap.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Heap</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// An optional pointer to a memory block that receives the requested interface pointer to the created heap object. <paramref
		/// name="ppvHeap"/> can be <c>nullptr</c>, to enable capability testing. When ppvHeap is <c>nullptr</c>, no object is created, and
		/// <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the heap.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para><b>CreateHeap</b> creates a heap that can be used with placed resources and reserved resources.</para>
		/// <para>
		/// Before releasing the final reference on the heap, your application must ensure that the GPU will no longer read or write to this heap.
		/// </para>
		/// <para>
		/// A placed resource object holds a reference on the heap it is created on; but a reserved resource doesn't hold a reference for
		/// each mapping made to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createheap HRESULT CreateHeap( [in] const
		// D3D12_HEAP_DESC *pDesc, [in] REFIID riid, [out, optional] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateHeap(in D3D12_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvHeap);

		/// <summary>
		/// <para>
		/// Creates a resource that is placed in a specific heap. Placed resources are the lightest weight resource objects available, and
		/// are the fastest to create and destroy.
		/// </para>
		/// <para>
		/// Your application can re-use video memory by overlapping multiple Direct3D placed and reserved resources on heap regions. The
		/// simple memory re-use model (described in <c>Remarks</c>) exists to clarify which overlapping resource is valid at any given
		/// time. To maximize graphics tool support, with the simple model data-inheritance isn't supported; and finer-grained tile and
		/// sub-resource invalidation isn't supported. Only full overlapping resource invalidation occurs.
		/// </para>
		/// </summary>
		/// <param name="pHeap">
		/// <para>Type: [in] <b><c>ID3D12Heap</c></b>*</para>
		/// <para>A pointer to the <b>ID3D12Heap</b> interface that represents the heap in which the resource is placed.</para>
		/// </param>
		/// <param name="HeapOffset">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// The offset, in bytes, to the resource. The HeapOffset must be a multiple of the resource's alignment, and HeapOffset plus the
		/// resource size must be smaller than or equal to the heap size. <c><b>GetResourceAllocationInfo</b></c> must be used to understand
		/// the sizes of texture resources.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_RESOURCE_DESC</c></b>*</para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>
		/// When a resource is created together with a <b>D3D12_HEAP_TYPE_UPLOAD</b> heap, InitialState must be
		/// <b>D3D12_RESOURCE_STATE_GENERIC_READ</b>. When a resource is created together with a <b>D3D12_HEAP_TYPE_READBACK</b> heap,
		/// InitialState must be <b>D3D12_RESOURCE_STATE_COPY_DEST</b>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: [in, optional] <b>const <c>D3D12_CLEAR_VALUE</c></b>*</para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <b>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</b> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, your application should choose the value that the clear operation will most commonly be called with.
		/// </para>
		/// <para>
		/// Clear operations can be called with other values, but those operations will not be as efficient as when the value matches the
		/// one passed into resource creation.
		/// </para>
		/// <para><paramref name="pOptimizedClearValue"/> must be NULL when used with <b>D3D12_RESOURCE_DIMENSION_BUFFER</b>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the resource interface. This is an input parameter.</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the resource can be obtained by using the <c>__uuidof</c> macro. For
		/// example, <c>__uuidof(ID3D12Resource)</c> gets the <b>GUID</b> of the interface to a resource. Although <b>riid</b> is, most
		/// commonly, the GUID for <c><b>ID3D12Resource</b></c>, it may be any <b>GUID</b> for any interface. If the resource object doesn't
		/// support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: [out, optional] <b>void</b>**</para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the resource. ppvResource can be NULL, to enable capability testing. When
		/// ppvResource is NULL, no object will be created and S_FALSE will be returned when pResourceDesc and other parameters are valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the resource. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreatePlacedResource</b> is similar to fully mapping a reserved resource to an offset within a heap; but the virtual address
		/// space associated with a heap may be reused as well.
		/// </para>
		/// <para>
		/// Placed resources are lighter weight to create and destroy than committed resources are. This is because no heap is created nor
		/// destroyed during those operations. In addition, placed resources enable an even lighter weight technique to reuse memory than
		/// resource creation and destruction—that is, reuse through aliasing, and aliasing barriers. Multiple placed resources may
		/// simultaneously overlap each other on the same heap, but only a single overlapping resource can be used at a time.
		/// </para>
		/// <para>
		/// There are two placed resource usage semantics—a simple model, and an advanced model. We recommend that you choose the simple
		/// model (it maximizes graphics tool support across the diverse ecosystem of GPUs), unless and until you find that you need the
		/// advanced model for your app.
		/// </para>
		/// <para>Simple model</para>
		/// <para>
		/// In this model, you can consider a placed resource to be in one of two states: active, or inactive. It's invalid for the GPU to
		/// either read or write from an inactive resource. Placed resources are created in the inactive state.
		/// </para>
		/// <para>
		/// To activate a resource with an aliasing barrier on a command list, your application must pass the resource in
		/// <c><b>D3D12_RESOURCE_ALIASING_BARRIER::pResourceAfter</b></c>. <b>pResourceBefore</b> can be left NULL during an activation. All
		/// resources that share physical memory with the activated resource now become inactive, which includes overlapping placed and
		/// reserved resources.
		/// </para>
		/// <para>Aliasing barriers should be grouped up and submitted together, in order to maximize efficiency.</para>
		/// <para>
		/// After activation, resources with either the render target or depth stencil flags must be further initialized. See the notes on
		/// the required resource initialization below.
		/// </para>
		/// <para>Notes on the required resource initialization</para>
		/// <para>
		/// Certain resource types still require initialization. Resources with either the render target or depth stencil flags must be
		/// initialized with either a clear operation or a collection of full subresource copies. If an aliasing barrier was used to denote
		/// the transition between two aliased resources, the initialization must occur after the aliasing barrier. This initialization is
		/// still required whenever a resource would've been activated in the simple model.
		/// </para>
		/// <para>
		/// Placed and reserved resources with either the render target or depth stencil flags must be initialized with one of the following
		/// operations before other operations are supported.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>A Clear operation; for example <c>ClearRenderTargetView</c> or <c>ClearDepthStencilView</c>.</description>
		/// </item>
		/// <item>
		/// <description>A <c>DiscardResource</c> operation.</description>
		/// </item>
		/// <item>
		/// <description>A Copy operation; for example <c>CopyBufferRegion</c>, <c>CopyTextureRegion</c>, or <c>CopyResource</c>.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications should prefer the most explicit operation that results in the least amount of texels modified. Consider the
		/// following examples.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Using a depth buffer to solve pixel visibility typically requires each depth texel start out at 1.0 or 0. Therefore, a Clear
		/// operation should be the most efficient option for aliased depth buffer initialization.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// An application may use an aliased render target as a destination for tone mapping. Since the application will render over every
		/// pixel during the tone mapping, <c>DiscardResource</c> should be the most efficient option for initialization.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Advanced model</para>
		/// <para>In this model, you can ignore the active/inactive state abstraction. Instead, you must honor these lower-level rules.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// An aliasing barrier must be between two different GPU resource accesses of the same physical memory, as long as those accesses
		/// are within the same <c>ExecuteCommandLists</c> call.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The first rendering operation to certain types of aliased resource must still be an initialization, just like the simple model.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Initialization operations must occur either on an entire subresource, or on a 64KB granularity. An entire subresource
		/// initialization is supported for all resource types. A 64KB initialization granularity, aligned at a 64KB offset, is supported
		/// for buffers and textures with either the 64KB_UNDEFINED_SWIZZLE or 64KB_STANDARD_SWIZZLE texture layout (refer to <c>D3D12_TEXTURE_LAYOUT</c>).
		/// </para>
		/// <para>Notes on the aliasing barrier</para>
		/// <para>
		/// The aliasing barrier may set NULL for both pResourceAfter and pResourceBefore. The memory coherence definition of
		/// <c><b>ExecuteCommandLists</b></c> and an aliasing barrier are the same, such that two aliased accesses to the same physical
		/// memory need no aliasing barrier when the accesses are in two different <b>ExecuteCommandLists</b> invocations.
		/// </para>
		/// <para>
		/// For D3D12 advanced usage models, the synchronization definition of <c><b>ExecuteCommandLists</b></c> is equivalent to an
		/// aliasing barrier. Therefore, applications may either insert an aliasing barrier between reusing physical memory, or ensure the
		/// two aliased usages of physical memory occurs in two separate calls to <b>ExecuteCommandLists</b>.
		/// </para>
		/// <para>
		/// The amount of inactivation varies based on resource properties. Textures with undefined memory layouts are the worst case, as
		/// the entire texture must be inactivated atomically. For two overlapping resources with defined layouts, inactivation can result
		/// in only the overlapping aligned regions of a resource. Data inheritance can even be well-defined. For more details, see
		/// <c>Memory aliasing and data inheritance</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createplacedresource HRESULT
		// CreatePlacedResource( ID3D12Heap *pHeap, UINT64 HeapOffset, const D3D12_RESOURCE_DESC *pDesc, D3D12_RESOURCE_STATES InitialState,
		// const D3D12_CLEAR_VALUE *pOptimizedClearValue, REFIID riid, void **ppvResource );
		[PreserveSig]
		new HRESULT CreatePlacedResource([In] ID3D12Heap pHeap, ulong HeapOffset, in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>Creates a resource that is reserved, and not yet mapped to any pages in a heap.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource. See <b>Remarks</b>.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateReservedResource</b> is equivalent to <c>D3D11_RESOURCE_MISC_TILED</c> in Direct3D 11. It creates a resource with
		/// virtual memory only, no backing store.
		/// </para>
		/// <para>You need to map the resource to physical memory (that is, to a heap) using <c>CopyTileMappings</c> and <c>UpdateTileMappings</c>.</para>
		/// <para>
		/// These resource types can only be created when the adapter supports tiled resource tier 1 or greater. The tiled resource tier
		/// defines the behavior of accessing a resource that is not mapped to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createreservedresource HRESULT
		// CreateReservedResource( [in] const D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialState, [in, optional] const
		// D3D12_CLEAR_VALUE *pOptimizedClearValue, [in] REFIID riid, [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateReservedResource(in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppvResource);

		/// <summary>Creates a shared handle to a heap, resource, or fence object.</summary>
		/// <param name="pObject">
		/// <para>Type: <b><c>ID3D12DeviceChild</c>*</b></para>
		/// <para>
		/// A pointer to the <c>ID3D12DeviceChild</c> interface that represents the heap, resource, or fence object to create for sharing.
		/// The following interfaces (derived from <b>ID3D12DeviceChild</b>) are supported:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAttributes">
		/// <para>Type: <b>const <c>SECURITY_ATTRIBUTES</c>*</b></para>
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security
		/// descriptor, and a <b>Boolean</b> value that determines whether child processes can inherit the returned handle.
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
		/// <param name="Access">
		/// <para>Type: <b><c>DWORD</c></b></para>
		/// <para>Currently the only value this parameter accepts is GENERIC_ALL.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>
		/// A <b>NULL</b>-terminated <b>UNICODE</b> string that contains the name to associate with the shared heap. The name is limited to
		/// MAX_PATH characters. Name comparison is case-sensitive.
		/// </para>
		/// <para>
		/// If <i>Name</i> matches the name of an existing resource, <b>CreateSharedHandle</b> fails with
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
		/// <para>Type: <b><c>HANDLE</c>*</b></para>
		/// <para>
		/// A pointer to a variable that receives the NT HANDLE value to the resource to share. You can use this handle in calls to access
		/// the resource.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
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
		/// <description>Possibly other error codes that are described in the <c>Direct3D 12 Return Codes</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Both heaps and committed resources can be shared. Sharing a committed resource shares the implicit heap along with the committed
		/// resource description, such that a compatible resource description can be mapped to the heap from another device.
		/// </para>
		/// <para>
		/// For Direct3D 11 and Direct3D 12 interop scenarios, a shared fence is opened in DirectX 11 with the
		/// <c>ID3D11Device5::OpenSharedFence</c> method, and a shared resource is opened with the <c>ID3D11Device::OpenSharedResource1</c> method.
		/// </para>
		/// <para>
		/// For Direct3D 12, a shared handle is opened with the <c>ID3D12Device::OpenSharedHandle</c> or the
		/// ID3D12Device::OpenSharedHandleByName method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createsharedhandle HRESULT CreateSharedHandle(
		// [in] ID3D12DeviceChild *pObject, [in, optional] const SECURITY_ATTRIBUTES *pAttributes, DWORD Access, [in, optional] LPCWSTR
		// Name, [out] HANDLE *pHandle );
		[PreserveSig]
		new HRESULT CreateSharedHandle([In] ID3D12DeviceChild pObject, [In, Optional] SECURITY_ATTRIBUTES? pAttributes, ACCESS_MASK Access,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? Name, out HANDLE pHandle);

		/// <summary>Opens a handle for shared resources, shared heaps, and shared fences, by using HANDLE and REFIID.</summary>
		/// <param name="NTHandle">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>The handle that was output by the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for one of the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// <para>The REFIID , or GUID , of the interface can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D12Heap) will get the GUID of the interface to a resource.</para>
		/// </param>
		/// <param name="ppvObj">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to one of the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-opensharedhandle HRESULT OpenSharedHandle( [in]
		// HANDLE NTHandle, REFIID riid, [out, optional] void **ppvObj );
		[PreserveSig]
		new HRESULT OpenSharedHandle(HANDLE NTHandle, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvObj);

		/// <summary>Opens a handle for shared resources, shared heaps, and shared fences, by using Name and Access.</summary>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The name that was optionally passed as the <i>Name</i> parameter in the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="Access">
		/// <para>Type: <b>DWORD</b></para>
		/// <para>The access level that was specified in the <i>Access</i> parameter in the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="pNTHandle">
		/// <para>Type: <b>HANDLE*</b></para>
		/// <para>Pointer to the shared handle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-opensharedhandlebyname HRESULT
		// OpenSharedHandleByName( [in] LPCWSTR Name, DWORD Access, [out] HANDLE *pNTHandle );
		[PreserveSig]
		new HRESULT OpenSharedHandleByName([MarshalAs(UnmanagedType.LPWStr)] string Name, ACCESS_MASK Access, out HANDLE pNTHandle);

		/// <summary>Makes objects resident for the device.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to make resident for the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block that contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>
		/// Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following
		/// objects: Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>MakeResident</b> loads the data associated with a resource from disk, and re-allocates the memory from the resource's
		/// appropriate memory pool. This method should be called on the object which owns the physical memory.
		/// </para>
		/// <para>
		/// Use this method, and <c>Evict</c>, to manage GPU video memory, noting that this was done automatically in D3D11, but now has to
		/// be done by the app in D3D12.
		/// </para>
		/// <para>
		/// <b>MakeResident</b> and <c>Evict</c> can help applications manage the residency budget on many adapters. <b>MakeResident</b>
		/// explicitly pages-in data and, then, precludes page-out so the GPU can access the data. <b>Evict</b> enables page-out.
		/// </para>
		/// <para>
		/// Some GPU architectures do not benefit from residency manipulation, due to the lack of sufficient GPU virtual address space. Use
		/// <c>D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT</c> and <c>IDXGIAdapter3::QueryVideoMemoryInfo</c> to recognize when the
		/// maximum GPU VA space per-process is too small or roughly the same size as the residency budget. For such architectures, the
		/// residency budget will always be constrained by the amount of GPU virtual address space. <c>Evict</c> will not free-up any
		/// residency budget on such systems.
		/// </para>
		/// <para>
		/// Applications must handle <b>MakeResident</b> failures, even if there appears to be enough residency budget available. Physical
		/// memory fragmentation and adapter architecture quirks can preclude the utilization of large contiguous ranges. Applications
		/// should free up more residency budget before trying again.
		/// </para>
		/// <para>
		/// <b>MakeResident</b> is ref-counted, such that <c>Evict</c> must be called the same amount of times as <b>MakeResident</b> before
		/// <b>Evict</b> takes effect. Objects that support residency are made resident during creation, so a single <b>Evict</b> call will
		/// actually evict the object.
		/// </para>
		/// <para>
		/// Applications must use fences to ensure the GPU doesn't use non-resident objects. <b>MakeResident</b> must return before the GPU
		/// executes a command list that references the object. <c>Evict</c> must be called after the GPU finishes executing a command list
		/// that references the object.
		/// </para>
		/// <para>
		/// Evicted objects still consume the same GPU virtual address and same amount of GPU virtual address space. Therefore, resource
		/// descriptors and other GPU virtual address references are not invalidated after <c>Evict</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-makeresident HRESULT MakeResident( UINT
		// NumObjects, [in] ID3D12Pageable * const *ppObjects );
		[PreserveSig]
		new HRESULT MakeResident(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects);

		/// <summary>Enables the page-out of data, which precludes GPU access of that data.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to evict from the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block that contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>
		/// Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following
		/// objects: Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>Evict</b> persists the data associated with a resource to disk, and then removes the resource from the memory pool where it
		/// was located. This method should be called on the object which owns the physical memory: either a committed resource (which owns
		/// both virtual and physical memory assignments) or a heap - noting that reserved resources do not have physical memory, and placed
		/// resources are borrowing memory from a heap.
		/// </para>
		/// <para>Refer to the remarks for <c>MakeResident</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-evict HRESULT Evict( UINT NumObjects, [in]
		// ID3D12Pageable * const *ppObjects );
		[PreserveSig]
		new HRESULT Evict(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects);

		/// <summary>Creates a fence object.</summary>
		/// <param name="InitialValue">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The initial value for the fence.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_FENCE_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_FENCE_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for the fence.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the fence interface ( <c>ID3D12Fence</c>). The <b>REFIID</b>, or <b>GUID</b>,
		/// of the interface to the fence can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D12Fence) will get the
		/// <b>GUID</b> of the interface to a fence.
		/// </para>
		/// </param>
		/// <param name="ppFence">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Fence</c> interface that is used to access the fence.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createfence HRESULT CreateFence( UINT64
		// InitialValue, D3D12_FENCE_FLAGS Flags, REFIID riid, [out] void **ppFence );
		[PreserveSig]
		new HRESULT CreateFence(ulong InitialValue, D3D12_FENCE_FLAGS Flags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppFence);

		/// <summary>
		/// Gets the reason that the device was removed, or <b>S_OK</b> if the device isn't removed. To be called back when a device is
		/// removed, consider using <c>ID3D12Fence::SetEventOnCompletion</c> with a value of <b>UINT64_MAX</b>. That's because device
		/// removal causes all fences to be signaled to that value (which also implies completing all events waited on, because they'll all
		/// be less than <b>UINT64_MAX</b>).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns the reason that the device was removed.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getdeviceremovedreason HRESULT GetDeviceRemovedReason();
		[PreserveSig]
		new HRESULT GetDeviceRemovedReason();

		/// <summary>
		/// Gets a resource layout that can be copied. Helps the app fill-in <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> when suballocating space in upload heaps.
		/// </summary>
		/// <param name="pResourceDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A description of the resource, as a pointer to a <c>D3D12_RESOURCE_DESC</c> structure.</para>
		/// </param>
		/// <param name="FirstSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
		/// </param>
		/// <param name="NumSubresources">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - <i>FirstSubresource</i>).</para>
		/// </param>
		/// <param name="BaseOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset, in bytes, to the resource.</para>
		/// </param>
		/// <param name="pLayouts">
		/// <para>Type: <b><c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structures, to be filled
		/// with the description and placement of each subresource.
		/// </para>
		/// </param>
		/// <param name="pNumRows">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, to be filled with the number of rows for each subresource.
		/// </para>
		/// </param>
		/// <param name="pRowSizeInBytes">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, each entry to be filled with the unpadded size in
		/// bytes of a row, of each subresource.
		/// </para>
		/// <para>For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4,</para>
		/// <para>then <i>pRowSizeInBytes</i> returns 128.</para>
		/// <para>
		/// <i>pRowSizeInBytes</i> should not be confused with <b>row pitch</b>, as examining <i>pLayouts</i> and getting the row pitch from
		/// that will give you 256 as it is aligned to D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.
		/// </para>
		/// </param>
		/// <param name="pTotalBytes">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>A pointer to an integer variable, to be filled with the total size, in bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This routine assists the application in filling out <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> structures, when suballocating space in upload heaps. The resulting structures are GPU
		/// adapter-agnostic, meaning that the values will not vary from one GPU adapter to the next. <b>GetCopyableFootprints</b> uses
		/// specified details about resource formats, texture layouts, and alignment requirements (from the <c>D3D12_RESOURCE_DESC</c>
		/// structure) to fill out the subresource structures. Applications have access to all these details, so this method, or a variation
		/// of it, could be written as part of the app.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12Device::GetCopyableFootprints</b> as follows:</para>
		/// <para>
		/// <c>// Returns required size of a buffer to be used for data upload inline UINT64 GetRequiredIntermediateSize( _In_
		/// ID3D12Resource* pDestinationResource, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources) { D3D12_RESOURCE_DESC Desc =
		/// pDestinationResource-&gt;GetDesc(); UINT64 RequiredSize = 0; ID3D12Device* pDevice;
		/// pDestinationResource-&gt;GetDevice(__uuidof(*pDevice), reinterpret_cast&lt;void**&gt;(&amp;pDevice));
		/// pDevice-&gt;GetCopyableFootprints(&amp;Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr,
		/// &amp;RequiredSize); pDevice-&gt;Release(); return RequiredSize; }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getcopyablefootprints void GetCopyableFootprints(
		// [in] const D3D12_RESOURCE_DESC *pResourceDesc, [in] UINT FirstSubresource, [in] UINT NumSubresources, UINT64 BaseOffset, [out,
		// optional] D3D12_PLACED_SUBRESOURCE_FOOTPRINT *pLayouts, [out, optional] UINT *pNumRows, [out, optional] UINT64 *pRowSizeInBytes,
		// [out, optional] UINT64 *pTotalBytes );
		[PreserveSig]
		new void GetCopyableFootprints(in D3D12_RESOURCE_DESC pResourceDesc, uint FirstSubresource, int NumSubresources, ulong BaseOffset,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[]? pLayouts,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[]? pNumRows,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[]? pRowSizeInBytes,
			[Out, Optional] StructPointer<ulong> pTotalBytes);

		/// <summary>Creates a query heap. A query heap contains an array of queries.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_QUERY_HEAP_DESC</c>*</b></para>
		/// <para>Specifies the query heap in a <c>D3D12_QUERY_HEAP_DESC</c> structure.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>Specifies a REFIID that uniquely identifies the heap.</para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// Specifies a pointer to the heap, that will be returned on successful completion of the method. <i>ppvHeap</i> can be NULL, to
		/// enable capability testing. When <i>ppvHeap</i> is NULL, no object will be created and S_FALSE will be returned when <i>pDesc</i>
		/// is valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>Refer to <c>Queries</c> for more information. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12Device::CreateQueryHeap</b> as follows:</para>
		/// <para>Create a query heap and a query result buffer.</para>
		/// <para>
		/// <c>// Pipeline objects. D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain;
		/// ComPtr&lt;ID3D12Device&gt; m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount];
		/// ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocators[FrameCount]; ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue;
		/// ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature; ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_cbvHeap; ComPtr&lt;ID3D12DescriptorHeap&gt; m_dsvHeap; ComPtr&lt;ID3D12QueryHeap&gt;
		/// m_queryHeap; UINT m_rtvDescriptorSize; UINT m_cbvSrvDescriptorSize; UINT m_frameIndex; // Synchronization objects.
		/// ComPtr&lt;ID3D12Fence&gt; m_fence; UINT64 m_fenceValues[FrameCount]; HANDLE m_fenceEvent; // Asset objects.
		/// ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState; ComPtr&lt;ID3D12PipelineState&gt; m_queryState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; ComPtr&lt;ID3D12Resource&gt; m_vertexBuffer; ComPtr&lt;ID3D12Resource&gt;
		/// m_constantBuffer; ComPtr&lt;ID3D12Resource&gt; m_depthStencil; ComPtr&lt;ID3D12Resource&gt; m_queryResult;
		/// D3D12_VERTEX_BUFFER_VIEW m_vertexBufferView;</c>
		/// </para>
		/// <para>
		/// <c>// Describe and create a heap for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1;
		/// queryHeapDesc.Type = D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc, IID_PPV_ARGS(&amp;m_queryHeap)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createqueryheap HRESULT CreateQueryHeap( [in]
		// const D3D12_QUERY_HEAP_DESC *pDesc, REFIID riid, [out, optional] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateQueryHeap(in D3D12_QUERY_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvHeap);

		/// <summary>A development-time aid for certain types of profiling and experimental prototyping.</summary>
		/// <param name="Enable">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies a BOOL that turns the stable power state on or off.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is only useful during the development of applications. It enables developers to profile GPU usage of multiple
		/// algorithms without experiencing artifacts from <c>dynamic frequency scaling</c>.
		/// </para>
		/// <para>
		/// Do not call this method in normal execution for a shipped application. This method only works while the machine is in
		/// <c>developer mode</c>. If developer mode is not enabled, then device removal will occur. Instead, call this method in response
		/// to an off-by-default, developer-facing switch. Calling it in response to command line parameters, config files, registry keys,
		/// and developer console commands are reasonable usage scenarios.
		/// </para>
		/// <para>
		/// A stable power state typically fixes GPU clock rates at a slower setting that is significantly lower than that experienced by
		/// users under normal application load. This reduction in clock rate affects the entire system. Slow clock rates are required to
		/// ensure processors don’t exhaust power, current, and thermal limits. Normal usage scenarios commonly leverage a processors
		/// ability to dynamically over-clock. Any conclusions made by comparing two designs under a stable power state should be
		/// double-checked with supporting results from real usage scenarios.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-setstablepowerstate HRESULT SetStablePowerState(
		// BOOL Enable );
		[PreserveSig]
		new HRESULT SetStablePowerState(bool Enable);

		/// <summary>This method creates a command signature.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMMAND_SIGNATURE_DESC</c>*</b></para>
		/// <para>Describes the command signature to be created with the <c>D3D12_COMMAND_SIGNATURE_DESC</c> structure.</para>
		/// </param>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>Specifies the <c>ID3D12RootSignature</c> that the command signature applies to.</para>
		/// <para>
		/// The root signature is required if any of the commands in the signature will update bindings on the pipeline. If the only command
		/// present is a draw or dispatch, the root signature parameter can be set to NULL.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the command signature interface ( <c>ID3D12CommandSignature</c>). The
		/// <b>REFIID</b>, or <b>GUID</b>, of the interface to the command signature can be obtained by using the __uuidof() macro. For
		/// example, __uuidof( <b>ID3D12CommandSignature</b>) will get the <b>GUID</b> of the interface to a command signature.
		/// </para>
		/// </param>
		/// <param name="ppvCommandSignature">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer, that on successful completion of the method will point to the created command signature ( <c>ID3D12CommandSignature</c>).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandsignature HRESULT
		// CreateCommandSignature( [in] const D3D12_COMMAND_SIGNATURE_DESC *pDesc, [in, optional] ID3D12RootSignature *pRootSignature,
		// REFIID riid, [out, optional] void **ppvCommandSignature );
		[PreserveSig]
		new HRESULT CreateCommandSignature(in D3D12_COMMAND_SIGNATURE_DESC pDesc, [In, Optional] ID3D12RootSignature? pRootSignature,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvCommandSignature);

		/// <summary>Gets info about how a tiled resource is broken into tiles.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies a tiled <c>ID3D12Resource</c> to get info about.</para>
		/// </param>
		/// <param name="pNumTilesForEntireResource">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>A pointer to a variable that receives the number of tiles needed to store the entire tiled resource.</para>
		/// </param>
		/// <param name="pPackedMipDesc">
		/// <para>Type: <b><c>D3D12_PACKED_MIP_INFO</c>*</b></para>
		/// <para>
		/// A pointer to a <c>D3D12_PACKED_MIP_INFO</c> structure that <b>GetResourceTiling</b> fills with info about how the tiled
		/// resource's mipmaps are packed.
		/// </para>
		/// </param>
		/// <param name="pStandardTileShapeForNonPackedMips">
		/// <para>Type: <b><c>D3D12_TILE_SHAPE</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_TILE_SHAPE</c> structure that <b>GetResourceTiling</b> fills with info about the tile shape. This is info
		/// about how pixels fit in the tiles, independent of tiled resource's dimensions, not including packed mipmaps. If the entire tiled
		/// resource is packed, this parameter is meaningless because the tiled resource has no defined layout for packed mipmaps. In this
		/// situation, <b>GetResourceTiling</b> sets the members of D3D12_TILE_SHAPE to zeros.
		/// </para>
		/// </param>
		/// <param name="pNumSubresourceTilings">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A pointer to a variable that contains the number of tiles in the subresource. On input, this is the number of subresources to
		/// query tilings for; on output, this is the number that was actually retrieved at <i>pSubresourceTilingsForNonPackedMips</i>
		/// (clamped to what's available).
		/// </para>
		/// </param>
		/// <param name="FirstSubresourceTilingToGet">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of the first subresource tile to get. <b>GetResourceTiling</b> ignores this parameter if the number that
		/// <i>pNumSubresourceTilings</i> points to is 0.
		/// </para>
		/// </param>
		/// <param name="pSubresourceTilingsForNonPackedMips">
		/// <para>Type: <b><c>D3D12_SUBRESOURCE_TILING</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_SUBRESOURCE_TILING</c> structure that <b>GetResourceTiling</b> fills with info about subresource tiles. If
		/// subresource tiles are part of packed mipmaps, <b>GetResourceTiling</b> sets the members of D3D12_SUBRESOURCE_TILING to zeros,
		/// except the <i>StartTileIndexInOverallResource</i> member, which <b>GetResourceTiling</b> sets to D3D12_PACKED_TILE (0xffffffff).
		/// The D3D12_PACKED_TILE constant indicates that the whole <b>D3D12_SUBRESOURCE_TILING</b> structure is meaningless for this
		/// situation, and the info that the <i>pPackedMipDesc</i> parameter points to applies.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To estimate the total resource size of textures needed when calculating heap sizes and calling <c>CreatePlacedResource</c>, use
		/// <c>GetResourceAllocationInfo</c> instead of <b>GetResourceTiling</b>. <b>GetResourceTiling</b> cannot be used for this.
		/// </para>
		/// <para>For more information on tiled resources, refer to <c>Volume Tiled Resources</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getresourcetiling void GetResourceTiling( [in]
		// ID3D12Resource *pTiledResource, [out, optional] UINT *pNumTilesForEntireResource, [out, optional] D3D12_PACKED_MIP_INFO
		// *pPackedMipDesc, [out, optional] D3D12_TILE_SHAPE *pStandardTileShapeForNonPackedMips, [in, out, optional] UINT
		// *pNumSubresourceTilings, [in] UINT FirstSubresourceTilingToGet, [out] D3D12_SUBRESOURCE_TILING
		// *pSubresourceTilingsForNonPackedMips );
		[PreserveSig]
		new void GetResourceTiling([In] ID3D12Resource pTiledResource, [Out, Optional] StructPointer<uint> pNumTilesForEntireResource,
			[Out, Optional] StructPointer<D3D12_PACKED_MIP_INFO> pPackedMipDesc, [Out, Optional] StructPointer<D3D12_TILE_SHAPE> pStandardTileShapeForNonPackedMips,
			[In, Out, Optional] StructPointer<uint> pNumSubresourceTilings, uint FirstSubresourceTilingToGet,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_TILING[] pSubresourceTilingsForNonPackedMips);

		/// <summary>Gets a locally unique identifier for the current device (adapter).</summary>
		/// <returns>
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>The locally unique identifier for the adapter.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method returns a unique identifier for the adapter that is specific to the adapter hardware. Applications can use this
		/// identifier to define robust mappings across various APIs (Direct3D 12, DXGI).
		/// </para>
		/// <para>
		/// A locally unique identifier (LUID) is a 64-bit value that is guaranteed to be unique only on the system on which it was
		/// generated. The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getadapterluid LUID GetAdapterLuid();
		[PreserveSig]
		new LUID GetAdapterLuid();

		/// <summary>
		/// <para>
		/// Creates a cached pipeline library. For pipeline state objects (PSOs) that are expected to share data together, grouping them
		/// into a library before serializing them means that there's less overhead due to metadata, as well as the opportunity to avoid
		/// redundant or duplicated data being written to disk.
		/// </para>
		/// <para>
		/// You can query for <b>ID3D12PipelineLibrary</b> support with <b><c>ID3D12Device::CheckFeatureSupport</c></b>, with
		/// <b><c>D3D12_FEATURE_SHADER_CACHE</c></b> and <b><c>D3D12_FEATURE_DATA_SHADER_CACHE</c></b>. If the Flags member of
		/// <b><c>D3D12_FEATURE_DATA_SHADER_CACHE</c></b> contains the flag <b><c>D3D12_SHADER_CACHE_SUPPORT_LIBRARY</c></b>, the
		/// <b>ID3D12PipelineLibrary</b> interface is supported. If not, then <b>DXGI_ERROR_NOT_SUPPORTED</b> will always be returned when
		/// this function is called.
		/// </para>
		/// </summary>
		/// <param name="pLibraryBlob">
		/// <para>Type: [in] <b>const void*</b></para>
		/// <para>
		/// If the input library blob is empty, then the initial content of the library is empty. If the input library blob is not empty,
		/// then it is validated for integrity, parsed, and the pointer is stored. The pointer provided as input to this method must remain
		/// valid for the lifetime of the object returned. For efficiency reasons, the data is not copied.
		/// </para>
		/// </param>
		/// <param name="BlobLength">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>Specifies the length of pLibraryBlob in bytes.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a unique REFIID for the <c>ID3D12PipelineLibrary</c> object. Typically set this and the following parameter with the
		/// macro <c>IID_PPV_ARGS(&amp;Library)</c>, where <b>Library</b> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineLibrary">
		/// <para>Type: [out] <b>void**</b></para>
		/// <para>Returns a pointer to the created library.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>, including
		/// <b>E_INVALIDARG</b> if the blob is corrupted or unrecognized, <b>D3D12_ERROR_DRIVER_VERSION_MISMATCH</b> if the provided data
		/// came from an old driver or runtime, and <b>D3D12_ERROR_ADAPTER_NOT_FOUND</b> if the data came from different hardware.
		/// </para>
		/// <para>
		/// If you pass <c>nullptr</c> for pPipelineLibrary then the runtime still performs the validation of the blob but avoid creating
		/// the actual library and returns S_FALSE if the library would have been created.
		/// </para>
		/// <para>Also, the feature requires an updated driver, and attempting to use it on old drivers will return DXGI_ERROR_UNSUPPORTED.</para>
		/// </returns>
		/// <remarks>
		/// <para>A pipeline library enables the following operations.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Adding pipeline state objects (PSOs) to an existing library object (refer to <c>StorePipeline</c>).</description>
		/// </item>
		/// <item>
		/// <description>Serializing a PSO library into a contiguous block of memory for disk storage (refer to <c>Serialize</c>).</description>
		/// </item>
		/// <item>
		/// <description>De-serializing a PSO library from persistent storage (this is handled by <b>CreatePipelineLibrary</b>).</description>
		/// </item>
		/// <item>
		/// <description>Retrieving individual PSOs from the library (refer to <c>LoadComputePipeline</c> and <c>LoadGraphicsPipeline</c>).</description>
		/// </item>
		/// </list>
		/// <para>At no point in the lifecycle of a pipeline library is there duplication between PSOs with identical sub-components.</para>
		/// <para>
		/// A recommended solution for managing the lifetime of the provided pointer while only having to ref-count the returned interface
		/// is to leverage <c>ID3D12Object::SetPrivateDataInterface</c>, and use an object which implements <b>IUnknown</b>, and frees the
		/// memory when the ref-count reaches 0.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>
		/// The pipeline library is thread-safe to use, and will internally synchronize as necessary, with one exception: multiple threads
		/// loading the same PSO (via <c><b>LoadComputePipeline</b></c>, <c><b>LoadGraphicsPipeline</b></c>, or <c><b>LoadPipeline</b></c>)
		/// should synchronize themselves, as this act may modify the state of that pipeline within the library in a non-thread-safe manner.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-createpipelinelibrary HRESULT
		// CreatePipelineLibrary( const void *pLibraryBlob, SIZE_T BlobLength, REFIID riid, void **ppPipelineLibrary );
		[PreserveSig]
		new HRESULT CreatePipelineLibrary([In] IntPtr pLibraryBlob, [In] SizeT BlobLength, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppPipelineLibrary);

		/// <summary>Specifies an event that should be fired when one or more of a collection of fences reach specific values.</summary>
		/// <param name="ppFences">
		/// <para>Type: <b>ID3D12Fence*</b></para>
		/// <para>An array of length <i>NumFences</i> that specifies the <c>ID3D12Fence</c> objects.</para>
		/// </param>
		/// <param name="pFenceValues">
		/// <para>Type: <b>const UINT64*</b></para>
		/// <para>An array of length <i>NumFences</i> that specifies the fence values required for the event is to be signaled.</para>
		/// </param>
		/// <param name="NumFences">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of fences to be included.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_MULTIPLE_FENCE_WAIT_FLAGS</c></b></para>
		/// <para>Specifies one of the <c>D3D12_MULTIPLE_FENCE_WAIT_FLAGS</c> that determines how to proceed.</para>
		/// </param>
		/// <param name="hEvent">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>A handle to the event object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To specify a single fence refer to the <c>SetEventOnCompletion</c> method.</para>
		/// <para>If hEvent is a null handle, then this API will not return until the specified fence value(s) have been reached.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-seteventonmultiplefencecompletion HRESULT
		// SetEventOnMultipleFenceCompletion( [in] ID3D12Fence * const *ppFences, [in] const UINT64 *pFenceValues, UINT NumFences,
		// D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags, HANDLE hEvent );
		[PreserveSig]
		new HRESULT SetEventOnMultipleFenceCompletion([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D12Fence[] ppFences,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] pFenceValues, int NumFences, D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags,
			HEVENT hEvent);

		/// <summary>This method sets residency priorities of a specified list of objects.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of objects in the <i>ppObjects</i> and <i>pPriorities</i> arrays.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b>ID3D12Pageable*</b></para>
		/// <para>Specifies an array, of length <i>NumObjects</i>, containing references to <c>ID3D12Pageable</c> objects.</para>
		/// </param>
		/// <param name="pPriorities">
		/// <para>Type: <b>const <c>D3D12_RESIDENCY_PRIORITY</c>*</b></para>
		/// <para>Specifies an array, of length <i>NumObjects</i>, of <c>D3D12_RESIDENCY_PRIORITY</c> values for the list of objects.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>For more information, refer to <c>Residency</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-setresidencypriority HRESULT
		// SetResidencyPriority( UINT NumObjects, [in] ID3D12Pageable * const *ppObjects, [in] const D3D12_RESIDENCY_PRIORITY *pPriorities );
		[PreserveSig]
		new HRESULT SetResidencyPriority(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESIDENCY_PRIORITY[] pPriorities);

		/// <summary>Creates a pipeline state object from a pipeline state stream description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PIPELINE_STATE_STREAM_DESC</c>*</b></para>
		/// <para>The address of a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> structure that describes the pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// </para>
		/// <para>The pipeline state object is an immutable state object. It contains no methods.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function takes the pipeline description as a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> and combines the functionality of the
		/// <c>ID3D12Device::CreateGraphicsPipelineState</c> and <c>ID3D12Device::CreateComputePipelineState</c> functions, which take their
		/// pipeline description as the less-flexible <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> and <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>
		/// structs, respectively.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device2-createpipelinestate HRESULT CreatePipelineState(
		// const D3D12_PIPELINE_STATE_STREAM_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreatePipelineState(in D3D12_PIPELINE_STATE_STREAM_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>
		/// Creates a special-purpose diagnostic heap in system memory from an address. The created heap can persist even in the event of a
		/// GPU-fault or device-removed scenario.
		/// </summary>
		/// <param name="pAddress">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The address used to create the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the heap interface ( <c>ID3D12Heap</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the heap can be obtained by using the <b>__uuidof()</b> macro. For
		/// example, <b>__uuidof(ID3D12Heap)</b> will retrieve the <b>GUID</b> of the interface to a heap.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block. On success, the D3D12 runtime will write a pointer to the newly-opened heap into the memory block.
		/// The type of the pointer depends on the provided <b>riid</b> parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to open the existing heap. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The heap is created in system memory and permits CPU access. It wraps the entire VirtualAlloc region.</para>
		/// <para>
		/// Heaps can be used for placed and reserved resources, as orthogonally as other heaps. Restrictions may still exist based on the
		/// flags that cannot be app-chosen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-openexistingheapfromaddress HRESULT
		// OpenExistingHeapFromAddress( [in] const void *pAddress, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT OpenExistingHeapFromAddress([In] IntPtr pAddress, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>
		/// Creates a special-purpose diagnostic heap in system memory from a file mapping object. The created heap can persist even in the
		/// event of a GPU-fault or device-removed scenario.
		/// </summary>
		/// <param name="hFileMapping">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>The handle to the file mapping object to use to create the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the heap interface ( <c>ID3D12Heap</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the heap can be obtained by using the <b>__uuidof()</b> macro. For
		/// example, <b>__uuidof(ID3D12Heap)</b> will retrieve the <b>GUID</b> of the interface to a heap.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block. On success, the D3D12 runtime will write a pointer to the newly-opened heap into the memory block.
		/// The type of the pointer depends on the provided <b>riid</b> parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to open the existing heap. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The heap is created in system memory, and it permits CPU access. It wraps the entire VirtualAlloc region.</para>
		/// <para>
		/// Heaps can be used for placed and reserved resources, as orthogonally as other heaps. Restrictions may still exist based on the
		/// flags that cannot be app-chosen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-openexistingheapfromfilemapping HRESULT
		// OpenExistingHeapFromFileMapping( HANDLE hFileMapping, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT OpenExistingHeapFromFileMapping([In] IntPtr hFileMapping, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>Asynchronously makes objects resident for the device.</summary>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_RESIDENCY_FLAGS</c></b></para>
		/// <para>Controls whether the objects should be made resident if the application is over its memory budget.</para>
		/// </param>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to make resident for the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block; contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>descriptor heaps</description>
		/// </item>
		/// <item>
		/// <description>heaps</description>
		/// </item>
		/// <item>
		/// <description>committed resources</description>
		/// </item>
		/// <item>
		/// <description>query heaps</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pFenceToSignal">
		/// <para>Type: <b><c>ID3D12Fence</c>*</b></para>
		/// <para>A pointer to the fence used to signal when the work is done.</para>
		/// </param>
		/// <param name="FenceValueToSignal">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>An unsigned 64-bit value signaled to the fence when the work is done.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>EnqueueMakeResident</b> performs the same actions as <c>MakeResident</c>, but does not wait for the resources to be made
		/// resident. Instead, <b>EnqueueMakeResident</b> signals a fence when the work is done.
		/// </para>
		/// <para>
		/// The system will not allow work that references the resources that are being made resident by using <b>EnqueueMakeResident</b>
		/// before its fence is signaled. Instead, calls to this API are guaranteed to signal their corresponding fence in order, so the
		/// same fence can be used from call to call.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-enqueuemakeresident HRESULT EnqueueMakeResident(
		// D3D12_RESIDENCY_FLAGS Flags, UINT NumObjects, [in] ID3D12Pageable * const *ppObjects, [in] ID3D12Fence *pFenceToSignal, UINT64
		// FenceValueToSignal );
		[PreserveSig]
		new HRESULT EnqueueMakeResident(D3D12_RESIDENCY_FLAGS Flags, int NumObjects,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D12Pageable[] ppObjects,
			[In] ID3D12Fence pFenceToSignal, ulong FenceValueToSignal);

		/// <summary>Creates a command list in the closed state. Also see <c>ID3D12Device::CreateCommandList</c>.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node (the device's
		/// physical adapter) for which to create the command list. Each bit in the mask corresponds to a single node. Only one bit must be
		/// set. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>Specifies the type of command list to create.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_FLAGS</c></b></para>
		/// <para>Specifies creation flags.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the command list interface to return in ppCommandList.</para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12CommandList</c> or <c>ID3D12GraphicsCommandList</c>
		/// interface for the command list.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the command list.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createcommandlist1 HRESULT CreateCommandList1(
		// [in] UINT nodeMask, [in] D3D12_COMMAND_LIST_TYPE type, D3D12_COMMAND_LIST_FLAGS flags, [in] REFIID riid, [out] void
		// **ppCommandList );
		[PreserveSig]
		new HRESULT CreateCommandList1(uint nodeMask, D3D12_COMMAND_LIST_TYPE type, D3D12_COMMAND_LIST_FLAGS flags, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppCommandList);

		/// <summary>
		/// <para>
		/// Creates an object that represents a session for content protection. You can then provide that session when you're creating
		/// resource or heap objects, to indicate that they should be protected.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Memory contents can't be transferred from a protected resource to an unprotected resource.</para>
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_PROTECTED_RESOURCE_SESSION_DESC</b> structure, describing the session to create.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the <c>ID3D12ProtectedResourceSession</c> interface.</para>
		/// </param>
		/// <param name="ppSession">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives an <c>ID3D12ProtectedResourceSession</c> interface pointer to the created session object.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createprotectedresourcesession HRESULT
		// CreateProtectedResourceSession( [in] const D3D12_PROTECTED_RESOURCE_SESSION_DESC *pDesc, [in] REFIID riid, [out] void **ppSession );
		[PreserveSig]
		new HRESULT CreateProtectedResourceSession(in D3D12_PROTECTED_RESOURCE_SESSION_DESC pDesc, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppSession);

		/// <summary>
		/// Creates both a resource and an implicit heap (optionally for a protected session), such that the heap is big enough to contain
		/// the entire resource, and the resource is mapped to the heap. Also see <c>ID3D12Device::CreateCommittedResource</c> for a code example.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createcommittedresource1 HRESULT
		// CreateCommittedResource1( [in] const D3D12_HEAP_PROPERTIES *pHeapProperties, [in] D3D12_HEAP_FLAGS HeapFlags, [in] const
		// D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialResourceState, [in, optional] const D3D12_CLEAR_VALUE
		// *pOptimizedClearValue, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riidResource, [out,
		// optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateCommittedResource1(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object? ppvResource);

		/// <summary>
		/// Creates a heap (optionally for a protected session) that can be used with placed resources and reserved resources. Also see <c>ID3D12Device::CreateHeap</c>.
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_HEAP_DESC</b> structure that describes the heap.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// heap should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// <para>A heap with a protected session can't be created with the <c>D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER</c> flag.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the heap interface to return in ppvHeap.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Heap</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created heap object.</para>
		/// <para>
		/// <paramref name="ppvHeap"/> can be <c>nullptr</c>, to enable capability testing. When ppvHeap is <c>nullptr</c>, no object is
		/// created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the heap.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para><b>CreateHeap1</b> creates a heap that can be used with placed resources and reserved resources.</para>
		/// <para>
		/// Before releasing the final reference on the heap, your application must ensure that the GPU will no longer read or write to this heap.
		/// </para>
		/// <para>
		/// A placed resource object holds a reference on the heap it is created on; but a reserved resource doesn't hold a reference for
		/// each mapping made to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createheap1 HRESULT CreateHeap1( [in] const
		// D3D12_HEAP_DESC *pDesc, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riid, [out, optional] void
		// **ppvHeap );
		[PreserveSig]
		new HRESULT CreateHeap1(in D3D12_HEAP_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvHeap);

		/// <summary>
		/// <para>
		/// Creates a resource (optionally for a protected session) that is reserved, and not yet mapped to any pages in a heap. Also see <c>ID3D12Device::CreateReservedResource</c>.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Only tiles from heaps created with the same protected resource session can be mapped into a protected reserved resource.</para>
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/>&gt; specifies a value for which clear operations are most optimal. When the created
		/// resource is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or
		/// <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b> flags, you should choose the value with which the clear operation will most
		/// commonly be called. You can call the clear operation with other values, but those operations won't be as efficient as when the
		/// value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource. See <b>Remarks</b>.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateReservedResource</b> is equivalent to <c>D3D11_RESOURCE_MISC_TILED</c> in Direct3D 11. It creates a resource with
		/// virtual memory only, no backing store.
		/// </para>
		/// <para>You need to map the resource to physical memory (that is, to a heap) using <c>CopyTileMappings</c> and <c>UpdateTileMappings</c>.</para>
		/// <para>
		/// These resource types can only be created when the adapter supports tiled resource tier 1 or greater. The tiled resource tier
		/// defines the behavior of accessing a resource that is not mapped to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createreservedresource1 HRESULT
		// CreateReservedResource1( [in] const D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialState, [in, optional] const
		// D3D12_CLEAR_VALUE *pOptimizedClearValue, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riid,
		// [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateReservedResource1(in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, [In, Optional] ID3D12ProtectedResourceSession? pProtectedSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppvResource);

		/// <summary>
		/// <para>
		/// Gets rich info about the size and alignment of memory required for a collection of resources on this adapter. Also see <c>ID3D12Device::GetResourceAllocationInfo</c>.
		/// </para>
		/// <para>
		/// In addition to the <c>D3D12_RESOURCE_ALLOCATION_INFO</c> returned from the method, this version also returns an array of
		/// <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, which provide additional details for each resource description passed as
		/// input. See the pResourceAllocationInfo1 parameter.
		/// </para>
		/// </summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array. This is also the size (the number of elements in) pResourceAllocationInfo1.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <param name="pResourceAllocationInfo1">
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO1</c>*</b></para>
		/// <para>
		/// An array of <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, containing additional details for each resource description
		/// passed as input. This makes it simpler for your application to allocate a heap for multiple resources, and without manually
		/// computing offsets for where each resource should be placed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you're using <c>CreatePlacedResource</c>, your application must use <b>GetResourceAllocationInfo</b> in order to understand
		/// the size and alignment characteristics of texture resources. The results of this method vary depending on the particular
		/// adapter, and must be treated as unique to this adapter and driver version.
		/// </para>
		/// <para>
		/// Your application can't use the output of <b>GetResourceAllocationInfo</b> to understand packed mip properties of textures. To
		/// understand packed mip properties of textures, your application must use <c>GetResourceTiling</c>.
		/// </para>
		/// <para>
		/// Texture resource sizes significantly differ from the information returned by <b>GetResourceTiling</b>, because some adapter
		/// architectures allocate extra memory for textures to reduce the effective bandwidth during common rendering scenarios. This even
		/// includes textures that have constraints on their texture layouts, or have standardized texture layouts. That extra memory can't
		/// be sparsely mapped nor remapped by an application using <c>CreateReservedResource</c> and <c>UpdateTileMappings</c>, so it isn't
		/// reported by <b>GetResourceTiling</b>.
		/// </para>
		/// <para>
		/// Your application can forgo using <b>GetResourceAllocationInfo</b> for buffer resources (
		/// <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>). Buffers have the same size on all adapters, which is merely the smallest multiple of
		/// 64KB that's greater or equal to <c>D3D12_RESOURCE_DESC::Width</c>.
		/// </para>
		/// <para>
		/// When multiple resource descriptions are passed in, the C++ algorithm for calculating a structure size and alignment are used.
		/// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource, reports differing sizes
		/// based on the order of the array. If the 4MB aligned resource is in the middle, then the resulting <b>Size</b> is 12MB.
		/// Otherwise, the resulting <b>Size</b> is 8MB. The <b>Alignment</b> returned would always be 4MB, because it's the superset of all
		/// alignments in the resource array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-getresourceallocationinfo1(uint_uint_constd3d12_resource_desc_d3d12_resource_allocation_info1)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo1( [in] UINT visibleMask, [in] UINT numResourceDescs, [in] const
		// D3D12_RESOURCE_DESC *pResourceDescs, [out] D3D12_RESOURCE_ALLOCATION_INFO1 *pResourceAllocationInfo1 );
		[PreserveSig]
		new D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo1(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_DESC[] pResourceDescs,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_ALLOCATION_INFO1[]? pResourceAllocationInfo1);

		/// <summary>
		/// Creates a lifetime tracker associated with an application-defined callback; the callback receives notifications when the
		/// lifetime of a tracked object is changed.
		/// </summary>
		/// <param name="pOwner">
		/// <para>Type: <b><c>ID3D12LifetimeOwner</c>*</b></para>
		/// <para>A pointer to an <b>ID3D12LifetimeOwner</b> interface representing the application-defined callback.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the interface identifier (IID) of the interface to return in ppvTracker.</para>
		/// </param>
		/// <param name="ppvTracker">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives the requested interface pointer to the created object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createlifetimetracker HRESULT
		// CreateLifetimeTracker( [in] ID3D12LifetimeOwner *pOwner, [in] REFIID riid, [out] void **ppvTracker );
		[PreserveSig]
		new HRESULT CreateLifetimeTracker([In] ID3D12LifetimeOwner pOwner, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvTracker);

		/// <summary>
		/// You can call <b>RemoveDevice</b> to indicate to the Direct3D 12 runtime that the GPU device encountered a problem, and can no
		/// longer be used. Doing so will cause all devices' monitored fences to be signaled. Your application typically doesn't need to
		/// explicitly call <b>RemoveDevice</b>.
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Because device removal triggers all fences to be signaled to <c>UINT64_MAX</c>, you can create a callback for device removal
		/// using an event.
		/// </para>
		/// <para>
		/// <c>HANDLE deviceRemovedEvent = CreateEventW(NULL, FALSE, FALSE, NULL); assert(deviceRemovedEvent != NULL);
		/// _deviceFence-&gt;SetEventOnCompletion(UINT64_MAX, deviceRemoved); HANDLE waitHandle; RegisterWaitForSingleObject(
		/// &amp;waitHandle, deviceRemovedEvent, OnDeviceRemoved, _device.Get(), // Pass the device as our context INFINITE, // No timeout 0
		/// // No flags ); void OnDeviceRemoved(PVOID context, BOOLEAN) { ID3D12Device* removedDevice = (ID3D12Device*)context; HRESULT
		/// removedReason = removedDevice-&gt;GetDeviceRemovedReason(); // Perform app-specific device removed operation, such as logging or
		/// inspecting DRED output }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-removedevice void RemoveDevice();
		[PreserveSig]
		new void RemoveDevice();

		/// <summary>Queries reflection metadata about available meta commands.</summary>
		/// <param name="pNumMetaCommands">
		/// <para>Type: [in, out] <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a <c>UINT</c> containing the number of meta commands to query for. This field determines the size of the
		/// <i>pDescs</i> array, unless <i>pDescs</i> is <b>nullptr</b>.
		/// </para>
		/// </param>
		/// <param name="pDescs">
		/// <para>Type: [out, optional] <b><c>D3D12_META_COMMAND_DESC</c>*</b></para>
		/// <para>
		/// An optional pointer to an array of <c>D3D12_META_COMMAND_DESC</c> containing the descriptions of the available meta commands.
		/// Pass <c>nullptr</c> to have the number of available meta commands returned in <i>pNumMetaCommands</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-enumeratemetacommands HRESULT
		// EnumerateMetaCommands( UINT *pNumMetaCommands, D3D12_META_COMMAND_DESC *pDescs );
		[PreserveSig]
		new HRESULT EnumerateMetaCommands(ref int pNumMetaCommands, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_META_COMMAND_DESC[]? pDescs);

		/// <summary>Queries reflection metadata about the parameters of the specified meta command.</summary>
		/// <param name="CommandId">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier (GUID) of the meta command whose parameters you wish to be returned in <i>pParameterDescs</i>.</para>
		/// </param>
		/// <param name="Stage">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_STAGE</b></para>
		/// <para>
		/// A <c>D3D12_META_COMMAND_PARAMETER_STAGE</c> specifying the stage of the parameters that you wish to be included in the query.
		/// </para>
		/// </param>
		/// <param name="pTotalStructureSizeInBytes">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// An optional pointer to a <c>UINT</c> containing the size of the structure containing the parameter values, which you pass when
		/// creating/initializing/executing the meta command, as appropriate.
		/// </para>
		/// </param>
		/// <param name="pParameterCount">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a <c>UINT</c> containing the number of parameters to query for. This field determines the size of the
		/// <i>pParameterDescs</i> array, unless <i>pParameterDescs</i> is <b>nullptr</b>.
		/// </para>
		/// </param>
		/// <param name="pParameterDescs">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_DESC*</b></para>
		/// <para>
		/// An optional pointer to an array of <c>D3D12_META_COMMAND_PARAMETER_DESC</c> containing the descriptions of the parameters. Pass
		/// <b>nullptr</b> to have the parameter count returned in <i>pParameterCount</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-enumeratemetacommandparameters HRESULT
		// EnumerateMetaCommandParameters( [in] REFGUID CommandId, [in] D3D12_META_COMMAND_PARAMETER_STAGE Stage, [out, optional] UINT
		// *pTotalStructureSizeInBytes, [in, out] UINT *pParameterCount, [out, optional] D3D12_META_COMMAND_PARAMETER_DESC *pParameterDescs );
		[PreserveSig]
		new HRESULT EnumerateMetaCommandParameters(in Guid CommandId, D3D12_META_COMMAND_PARAMETER_STAGE Stage, out uint pTotalStructureSizeInBytes,
			ref int pParameterCount, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D12_META_COMMAND_PARAMETER_DESC[]? pParameterDescs);

		/// <summary>Creates an instance of the specified meta command.</summary>
		/// <param name="CommandId">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier (GUID) of the meta command that you wish to instantiate.</para>
		/// </param>
		/// <param name="NodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the
		/// device's physical adapters) to which the meta command applies. Each bit in the mask corresponds to a single node. Only one bit
		/// must be set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="pCreationParametersData">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>An optional pointer to a constant structure containing the values of the parameters for creating the meta command.</para>
		/// </param>
		/// <param name="CreationParametersDataSizeInBytes">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>A <c>SIZE_T</c> containing the size of the structure pointed to by <i>pCreationParametersData</i>, if set, otherwise 0.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in <i>ppMetaCommand</i>. This
		/// is expected to be the GUID of <c>ID3D12MetaCommand</c>.
		/// </para>
		/// </param>
		/// <param name="ppMetaCommand">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the meta command. This is the address of a pointer to an
		/// <c>ID3D12MetaCommand</c>, representing the meta command created.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>The current hardware does not support the algorithm being requested</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createmetacommand HRESULT CreateMetaCommand(
		// [in] REFGUID CommandId, [in] UINT NodeMask, [in, optional] const void *pCreationParametersData, [in] SIZE_T
		// CreationParametersDataSizeInBytes, REFIID riid, [out] void **ppMetaCommand );
		[PreserveSig]
		new HRESULT CreateMetaCommand(in Guid CommandId, uint NodeMask, [In, Optional] IntPtr pCreationParametersData, [In] SizeT CreationParametersDataSizeInBytes,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppMetaCommand);

		/// <summary>Creates an <c>ID3D12StateObject</c>.</summary>
		/// <param name="pDesc">The description of the state object to create.</param>
		/// <param name="riid">The GUID of the interface to create. Use <i>__uuidof(ID3D12StateObject)</i>.</param>
		/// <param name="ppStateObject">The returned state object.</param>
		/// <returns>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>E_INVALIDARG if one of the input parameters is invalid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY if sufficient memory is not available to create the handle.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>Direct3D 12 Return Codes</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createstateobject HRESULT CreateStateObject(
		// [in] const D3D12_STATE_OBJECT_DESC *pDesc, REFIID riid, [out] void **ppStateObject );
		[PreserveSig]
		new HRESULT CreateStateObject(in D3D12_STATE_OBJECT_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppStateObject);

		/// <summary>Query the driver for resource requirements to build an acceleration structure.</summary>
		/// <param name="pDesc">
		/// <para>
		/// Description of the acceleration structure build. This structure is shared with <c>BuildRaytracingAccelerationStructure</c>. For
		/// more information, see <c>D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS</c>.
		/// </para>
		/// <para>
		/// The implementation is allowed to look at all the CPU parameters in this struct and nested structs. It may not
		/// inspect/dereference any GPU virtual addresses, other than to check to see if a pointer is NULL or not, such as the optional
		/// transform in <c>D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC</c>, without dereferencing it. In other words, the calculation of
		/// resource requirements for the acceleration structure does not depend on the actual geometry data (such as vertex positions),
		/// rather it can only depend on overall properties, such as the number of triangles, number of instances etc.
		/// </para>
		/// </param>
		/// <param name="pInfo">The result of the query (in a <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO</c> structure).</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The input acceleration structure description is the same as what goes into <c>BuildRaytracingAccelerationStructure</c>. The
		/// result of this function lets the application provide the correct amount of output storage and scratch storage to
		/// <b>BuildRaytracingAccelerationStructure</b> given the same geometry.
		/// </para>
		/// <para>
		/// Builds can also be done with the same configuration passed to <b>GetAccelerationStructurePrebuildInfo</b> overall except equal
		/// or smaller counts for the number of geometries/instances or the number of vertices/indices/AABBs in any given geometry. In this
		/// case the storage requirements reported with the original sizes passed to <b>GetRaytracingAccelerationStructurePrebuildInfo</b>
		/// will be valid – the build may actually consume less space but not more. This is handy for app scenarios where having
		/// conservatively large storage allocated for acceleration structures is fine.
		/// </para>
		/// <para>
		/// This method is on the device interface as opposed to command list on the assumption that drivers must be able to calculate
		/// resource requirements for an acceleration structure build from only looking at the CPU-visible portions of the call, without
		/// having to dereference any pointers to GPU memory containing actual vertex data, index data, etc.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-getraytracingaccelerationstructureprebuildinfo
		// void GetRaytracingAccelerationStructurePrebuildInfo( [in] const D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS *pDesc,
		// [out] D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO *pInfo );
		[PreserveSig]
		new void GetRaytracingAccelerationStructurePrebuildInfo(in D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS pDesc, out D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO pInfo);

		/// <summary>
		/// Reports the compatibility of serialized data, such as a serialized raytracing acceleration structure resulting from a call to
		/// <c>CopyRaytracingAccelerationStructure</c> with mode <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_SERIALIZE</c>, with
		/// the current device/driver.
		/// </summary>
		/// <param name="SerializedDataType">The type of the serialized data. For more information, see <c>D3D12_SERIALIZED_DATA_TYPE</c>.</param>
		/// <param name="pIdentifierToCheck">
		/// Identifier from the header of the serialized data to check with the driver. For more information, see <c>D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER</c>.
		/// </param>
		/// <returns>The returned compatibility status. For more information, see <c>D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-checkdrivermatchingidentifier
		// D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS CheckDriverMatchingIdentifier( [in] D3D12_SERIALIZED_DATA_TYPE SerializedDataType, [in]
		// const D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER *pIdentifierToCheck );
		[PreserveSig]
		new D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS CheckDriverMatchingIdentifier(D3D12_SERIALIZED_DATA_TYPE SerializedDataType,
			in D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER pIdentifierToCheck);

		/// <summary>Sets the mode for driver background processing optimizations.</summary>
		/// <param name="Mode">
		/// <para>Type: <b><c>D3D12_BACKGROUND_PROCESSING_MODE</c></b></para>
		/// <para>The level of dynamic optimization to apply to GPU work that's subsequently submitted.</para>
		/// </param>
		/// <param name="MeasurementsAction">
		/// <para>Type: <b><c>D3D12_MEASUREMENTS_ACTION</c></b></para>
		/// <para>The action to take with the results of earlier workload instrumentation.</para>
		/// </param>
		/// <param name="hEventToSignalUponCompletion">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>
		/// An optional handle to signal when the function is complete. For example, if MeasurementsAction is set to
		/// <c>D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS</c>, then hEventToSignalUponCompletion is signaled when all resulting compilations
		/// have finished.
		/// </para>
		/// </param>
		/// <param name="pbFurtherMeasurementsDesired">
		/// <para>Type: <b><c>BOOL</c>*</b></para>
		/// <para>
		/// An optional pointer to a Boolean value. The function sets the value to <c>true</c> to indicate that you should continue
		/// profiling, otherwise, <c>false</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A graphics driver can use idle-priority background CPU threads to dynamically recompile shader programs. That can improve GPU
		/// performance by specializing shader code to better match details of the hardware that it's running on, and/or the context in
		/// which it's being used.
		/// </para>
		/// <para>
		/// As a developer, you don't have to do anything to benefit from this feature (over time, as drivers adopt background processing
		/// optimizations, existing shaders will automatically be tuned more efficiently). But, when you're profiling your code, you'll
		/// probably want to call <b>SetBackgroundProcessingMode</b> to make sure that any driver background processing optimizations have
		/// taken place before you take timing measurements. Here's an example.
		/// </para>
		/// <para>
		/// <c>SetBackgroundProcessingMode( D3D12_BACKGROUND_PROCESSING_MODE_ALLOW_INTRUSIVE_MEASUREMENTS, D3D_MEASUREMENTS_ACTION_KEEP_ALL,
		/// nullptr, nullptr); // Here, prime the system by rendering some typical content. // For example, a level flythrough.
		/// SetBackgroundProcessingMode( D3D12_BACKGROUND_PROCESSING_MODE_ALLOWED, D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS, nullptr,
		/// nullptr); // Here, continue rendering. This time with dynamic optimizations applied. // And then take your measurements.</c>
		/// </para>
		/// <para>
		/// <c>PIX</c> automatically uses <b>SetBackgroundProcessingMode</b>—first to prime the system,and then to prevent any further
		/// changes from taking place in the middle of its analysis. PIX waits on an event (to make sure all background shader recompiles
		/// have finished) before it starts taking measurements.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device6-setbackgroundprocessingmode
		// HRESULT SetBackgroundProcessingMode( [in] D3D12_BACKGROUND_PROCESSING_MODE Mode, [in] D3D12_MEASUREMENTS_ACTION MeasurementsAction, [in] HANDLE hEventToSignalUponCompletion, [out] BOOL *pbFurtherMeasurementsDesired );
		[PreserveSig]
		new HRESULT SetBackgroundProcessingMode(D3D12_BACKGROUND_PROCESSING_MODE Mode, D3D12_MEASUREMENTS_ACTION MeasurementsAction,
			[In] HEVENT hEventToSignalUponCompletion, out bool pbFurtherMeasurementsDesired);

		/// <summary>
		/// Incrementally add to an existing state object. This incurs lower CPU overhead than creating a state object from scratch that is
		/// a superset of an existing one (for example, adding a few more shaders).
		/// </summary>
		/// <param name="pAddition">
		/// <para>Type: _In_ <b>const <c>D3D12_STATE_OBJECT_DESC</c>*</b></para>
		/// <para>
		/// Description of state object contents to add to existing state object. To help generate this see the
		/// <b>CD3D12_STATE_OBJECT_DESC</b> helper in class in <c>d3dx12.h</c>.
		/// </para>
		/// </param>
		/// <param name="pStateObjectToGrowFrom">
		/// <para>Type: _In_ <b><c>ID3D12StateObject</c>*</b></para>
		/// <para>Existing state object, which can be in use (for example, active raytracing) during this operation.</para>
		/// <para>The existing state object must not be of type <b>Collection</b>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: _In_ <b>REFIID</b></para>
		/// <para>Must be the IID of the <c>ID3D12StateObject</c> interface.</para>
		/// </param>
		/// <param name="ppNewStateObject">
		/// <para>Type: _COM_Outptr_ <b>void**</b></para>
		/// <para>Returned state object.</para>
		/// <para>
		/// Behavior is undefined if shader identifiers are retrieved for new shaders from this call and they are accessed via shader tables
		/// by any already existing or in-flight command list that references some older state object. Use of the new shaders added to the
		/// state object can occur only from commands (such as <b>DispatchRays</b> or <b>ExecuteIndirect</b> calls) recorded in a command
		/// list after the call to <b>AddToStateObject</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <b>S_OK</b> for success. <b>E_INVALIDARG</b>, <b>E_OUTOFMEMORY</b> on failure. The debug layer provides detailed status information.
		/// </returns>
		/// <remarks>For more info, see <c>AddToStateObject</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device7-addtostateobject HRESULT AddToStateObject( const
		// D3D12_STATE_OBJECT_DESC *pAddition, ID3D12StateObject *pStateObjectToGrowFrom, REFIID riid, void **ppNewStateObject );
		[PreserveSig]
		HRESULT AddToStateObject(in D3D12_STATE_OBJECT_DESC pAddition, [In] ID3D12StateObject pStateObjectToGrowFrom, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppNewStateObject);

		/// <summary>
		/// <para>
		/// <b>CreateProtectedResourceSession1</b> revises the <c><b>ID3D12Device4::CreateProtectedResourceSession</b></c> method with
		/// provision (in the structure passed via the pDesc parameter) for a globally unique identifier ( <b>GUID</b>) that indicates the
		/// type of protected resource session.
		/// </para>
		/// <para>
		/// Calling <b>ID3D12Device4::CreateProtectedResourceSession</b> is equivalent to calling
		/// <b>ID3D12Device7::CreateProtectedResourceSession1</b> with the <b>D3D12_PROTECTED_RESOURCES_SESSION_HARDWARE_PROTECTED</b> GUID.
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: _In_ <b>const <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC1</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_PROTECTED_RESOURCE_SESSION_DESC1</b> structure, describing the session to create.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: _In_ <b>REFIID</b></para>
		/// <para>
		/// The GUID of the interface to a protected session. Most commonly, <c>ID3D12ProtectedResourceSession1</c>, although it may be any
		/// <b>GUID</b> for any interface. If the protected session object doesn't support the interface for this <b>GUID</b>, the getter
		/// will return <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppSession">
		/// <para>Type: _COM_Outptr_ <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the session for the given protected session (the specific interface type
		/// returned depends on riid).
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device7-createprotectedresourcesession1 HRESULT
		// CreateProtectedResourceSession1( const D3D12_PROTECTED_RESOURCE_SESSION_DESC1 *pDesc, REFIID riid, void **ppSession );
		[PreserveSig]
		HRESULT CreateProtectedResourceSession1(in D3D12_PROTECTED_RESOURCE_SESSION_DESC1 pDesc, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppSession);
	}

	/// <summary>
	/// <para>Represents a virtual adapter.</para>
	/// <para>This interface extends <c>ID3D12Device7</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12device8
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Device8")]
	[ComImport, Guid("9218e6bb-f944-4f7e-a75c-b1b2c7b701f3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Device8 : ID3D12Device7
	{
		/// <summary>Gets application-defined data from a device object.</summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> that is associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <i>pData</i> points to, and on output
		/// contains the size, in bytes, of the amount of data that <b>GetPrivateData</b> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// A pointer to a memory block that receives the data from the device object if <i>pDataSize</i> points to a value that specifies a
		/// buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// If the data returned is a pointer to an <c>IUnknown</c>, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] UINT *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Sets application-defined data to a device object and associates that data with an application-defined <b>GUID</b>.</summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> to associate with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size in bytes of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>
		/// A pointer to a memory block that contains the data to be stored with this device object. If <i>pData</i> is <b>NULL</b>,
		/// <i>DataSize</i> must also be 0, and any data that was previously associated with the <b>GUID</b> specified in <i>guid</i> will
		/// be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// Rather than using the Direct3D 11 debug object naming scheme of calling <b>ID3D12Object::SetPrivateData</b> using
		/// <b>WKPDID_D3DDebugObjectName</b> with an ASCII name, call <c>ID3D12Object::SetName</c> with a UNICODE name.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] UINT DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associates an <c>IUnknown</c>-derived interface with the device object, and associates that interface with an
		/// application-defined <b>GUID</b>.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <b><c>REFGUID</c></b></para>
		/// <para>The <b>GUID</b> to associate with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const <c>IUnknown</c>*</b></para>
		/// <para>
		/// A pointer to the <c>IUnknown</c>-derived interface to be associated with the device object. Its reference count is incremented
		/// when set, and its reference count is decremented when either the <c>ID3D12Object</c> is destroyed, or when the data is
		/// overwritten by calling <c>SetPrivateData</c> or <b>SetPrivateDataInterface</b> with the same <b>GUID</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 return codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object? pData);

		/// <summary>Associates a name with the device object. This name is for use in debug diagnostics and tools.</summary>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>A <b>NULL</b>-terminated <b>UNICODE</b> string that contains the name to associate with the device object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method takes UNICODE names.</para>
		/// <para>
		/// Note that this is simply a convenience wrapper around <c>ID3D12Object::SetPrivateData</c> with
		/// <b>WKPDID_D3DDebugObjectNameW</b>. Therefore names which are set with <c>SetName</c> can be retrieved with
		/// <c>ID3D12Object::GetPrivateData</c> with the same GUID. Additionally, D3D12 supports narrow strings for names, using the
		/// <b>WKPDID_D3DDebugObjectName</b> GUID directly instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setname HRESULT SetName( [in] LPCWSTR Name );
		[PreserveSig]
		new HRESULT SetName([MarshalAs(UnmanagedType.LPWStr)] string Name);

		/// <summary>Reports the number of physical adapters (nodes) that are associated with this device.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of physical adapters (nodes) that this device has.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getnodecount UINT GetNodeCount();
		[PreserveSig]
		new uint GetNodeCount();

		/// <summary>
		/// <para>Creates a command queue.</para>
		/// <para>Also see <c>ID3D12Device9::CreateCommandQueue1</c>.</para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_COMMAND_QUEUE_DESC</c>*</b></para>
		/// <para>Specifies a <b>D3D12_COMMAND_QUEUE_DESC</b> that describes the command queue.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier (GUID) for the command queue interface. See <b>Remarks</b>. An input parameter.</para>
		/// </param>
		/// <param name="ppCommandQueue">
		/// <para>Type: [out] <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12CommandQueue</c> interface for the command queue.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the command queue. See <c>Direct3D 12 return
		/// codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the command queue can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12CommandQueue) will get the <b>GUID</b> of the interface to a command queue.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandqueue HRESULT CreateCommandQueue(
		// const D3D12_COMMAND_QUEUE_DESC *pDesc, REFIID riid, void **ppCommandQueue );
		[PreserveSig]
		new HRESULT CreateCommandQueue(in D3D12_COMMAND_QUEUE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppCommandQueue);

		/// <summary>Creates a command allocator object.</summary>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// A <c>D3D12_COMMAND_LIST_TYPE</c>-typed value that specifies the type of command allocator to create. The type of command
		/// allocator can be the type that records either direct command lists or bundles.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the command allocator interface ( <c>ID3D12CommandAllocator</c>). The
		/// <b>REFIID</b>, or <b>GUID</b>, of the interface to the command allocator can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12CommandAllocator) will get the <b>GUID</b> of the interface to a command allocator.
		/// </para>
		/// </param>
		/// <param name="ppCommandAllocator">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12CommandAllocator</c> interface for the command allocator.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the command allocator. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The device creates command lists from the command allocator. Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12Device::CreateCommandAllocator</b> as follows:</para>
		/// <para>
		/// <c>ThrowIfFailed(pDevice-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT, IID_PPV_ARGS(&amp;m_commandAllocator)));
		/// ThrowIfFailed(pDevice-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_BUNDLE, IID_PPV_ARGS(&amp;m_bundleAllocator)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandallocator HRESULT
		// CreateCommandAllocator( [in] D3D12_COMMAND_LIST_TYPE type, REFIID riid, [out] void **ppCommandAllocator );
		[PreserveSig]
		new HRESULT CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE type, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppCommandAllocator);

		/// <summary>Creates a graphics pipeline state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure that describes graphics pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>). The <b>REFIID</b>,
		/// or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// The pipeline state object is an immutable state object. It contains no methods.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-creategraphicspipelinestate HRESULT
		// CreateGraphicsPipelineState( [in] const D3D12_GRAPHICS_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreateGraphicsPipelineState(in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>Creates a compute pipeline state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structure that describes compute pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>). The <b>REFIID</b>,
		/// or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// The pipeline state object is an immutable state object. It contains no methods.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcomputepipelinestate HRESULT
		// CreateComputePipelineState( [in] const D3D12_COMPUTE_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreateComputePipelineState(in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>Creates a command list.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node (the device's
		/// physical adapter) for which to create the command list. Each bit in the mask corresponds to a single node. Only one bit must be
		/// set. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>Specifies the type of command list to create.</para>
		/// </param>
		/// <param name="pCommandAllocator">
		/// <para>Type: <b><c>ID3D12CommandAllocator</c>*</b></para>
		/// <para>A pointer to the command allocator object from which the device creates command lists.</para>
		/// </param>
		/// <param name="pInitialState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>
		/// An optional pointer to the pipeline state object that contains the initial pipeline state for the command list. If it is
		/// <c>nullptr</c>, then the runtime sets a dummy initial pipeline state, so that drivers don't have to deal with undefined state.
		/// The overhead for this is low, particularly for a command list, for which the overall cost of recording the command list likely
		/// dwarfs the cost of a single initial state setting. So there's little cost in not setting the initial pipeline state parameter,
		/// if doing so is inconvenient.
		/// </para>
		/// <para>
		/// For bundles, on the other hand, it might make more sense to try to set the initial state parameter (since bundles are likely
		/// smaller overall, and can be reused frequently).
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the command list interface to return in ppCommandList.</para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12CommandList</c> or <c>ID3D12GraphicsCommandList</c>
		/// interface for the command list.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the command list.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>The device creates command lists from the command allocator.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandlist HRESULT CreateCommandList( [in]
		// UINT nodeMask, [in] D3D12_COMMAND_LIST_TYPE type, [in] ID3D12CommandAllocator *pCommandAllocator, [in, optional]
		// ID3D12PipelineState *pInitialState, [in] REFIID riid, [out] void **ppCommandList );
		[PreserveSig]
		new HRESULT CreateCommandList(uint nodeMask, D3D12_COMMAND_LIST_TYPE type, [In] ID3D12CommandAllocator pCommandAllocator, [In, Optional] ID3D12PipelineState? pInitialState,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppCommandList);

		/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
		/// <param name="Feature">
		/// <para>Type: <b><c>D3D12_FEATURE</c></b></para>
		/// <para>A constant from the <c>D3D12_FEATURE</c> enumeration describing the feature(s) that you want to query for support.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// A pointer to a data structure that corresponds to the value of the <i>Feature</i> parameter. To determine the corresponding data
		/// structure for each constant, see <c>D3D12_FEATURE</c>.
		/// </para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the structure pointed to by the <i>pFeatureSupportData</i> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// Returns <b>S_OK</b> if successful. Returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// <i>pFeatureSupportData</i> parameter or if a size mismatch is detected for the <i>FeatureSupportDataSize</i> parameter.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As a usage example, to check for ray tracing support, specify the <c>D3D12_FEATURE_DATA_D3D12_OPTIONS5</c> structure in the
		/// <i>pFeatureSupportData</i> parameter. When the function completes successfully, access the <i>RaytracingTier</i> field (which
		/// specifies the supported ray tracing tier) of the now-populated <b>D3D12_FEATURE_DATA_D3D12_OPTIONS5</b> structure.
		/// </para>
		/// <para>For more info, see <c>Capability Querying</c>.</para>
		/// <para><c></c><c></c><c></c> Hardware support for DXGI Formats</para>
		/// <para>To view tables of DXGI formats and hardware features, refer to:</para>
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
		/// <description><c>Format Support for Direct3D Feature Level 10.1 Hardware</c></description>
		/// </item>
		/// <item>
		/// <description><c>Format Support for Direct3D Feature Level 10.0 Hardware</c></description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>The <c>D3D1211on12</c> sample uses <b>ID3D12Device::CheckFeatureSupport</b> as follows:</para>
		/// <para>
		/// <c>inline UINT8 D3D12GetFormatPlaneCount( _In_ ID3D12Device* pDevice, DXGI_FORMAT Format ) { D3D12_FEATURE_DATA_FORMAT_INFO
		/// formatInfo = {Format}; if (FAILED(pDevice-&gt;CheckFeatureSupport(D3D12_FEATURE_FORMAT_INFO, &amp;formatInfo,
		/// sizeof(formatInfo)))) { return 0; } return formatInfo.PlaneCount; }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-checkfeaturesupport HRESULT CheckFeatureSupport(
		// D3D12_FEATURE Feature, [in, out] void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D12_FEATURE Feature, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a descriptor heap object.</summary>
		/// <param name="pDescriptorHeapDesc">
		/// <para>Type: <b>const <c>D3D12_DESCRIPTOR_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DESCRIPTOR_HEAP_DESC</c> structure that describes the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the descriptor heap interface. See Remarks. An input parameter.</para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the descriptor heap. <i>ppvHeap</i> can be NULL, to enable capability
		/// testing. When <i>ppvHeap</i> is NULL, no object will be created and S_FALSE will be returned when <i>pDescriptorHeapDesc</i> is valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the descriptor heap object. See <c>Direct3D
		/// 12 Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the descriptor heap can be obtained by using the __uuidof() macro. For
		/// example, __uuidof( <c>ID3D12DescriptorHeap</c>) will get the <b>GUID</b> of the interface to a descriptor heap.
		///  Examples The <c>D3D12HelloWorld</c> sample uses <b>ID3D12Device::CreateDescriptorHeap</b> as follows:</para>
		/// <para>Describe and create a render target view (RTV) descriptor heap.</para>
		/// <para>
		/// <c>// Create descriptor heaps. { // Describe and create a render target view (RTV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// rtvHeapDesc = {}; rtvHeapDesc.NumDescriptors = FrameCount; rtvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV; rtvHeapDesc.Flags
		/// = D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;rtvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_rtvHeap))); m_rtvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV); } // Create frame resources. {
		/// CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); // Create a RTV for each frame. for
		/// (UINT n = 0; n &lt; FrameCount; n++) { ThrowIfFailed(m_swapChain-&gt;GetBuffer(n, IID_PPV_ARGS(&amp;m_renderTargets[n])));
		/// m_device-&gt;CreateRenderTargetView(m_renderTargets[n].Get(), nullptr, rtvHandle); rtvHandle.Offset(1, m_rtvDescriptorSize); }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createdescriptorheap HRESULT
		// CreateDescriptorHeap( [in] const D3D12_DESCRIPTOR_HEAP_DESC *pDescriptorHeapDesc, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateDescriptorHeap(in D3D12_DESCRIPTOR_HEAP_DESC pDescriptorHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>
		/// Gets the size of the handle increment for the given type of descriptor heap. This value is typically used to increment a handle
		/// into a descriptor array by the correct amount.
		/// </summary>
		/// <param name="DescriptorHeapType">
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to get the size of the handle
		/// increment for.
		/// </param>
		/// <returns>Returns the size of the handle increment for the given type of descriptor heap, including any necessary padding.</returns>
		/// <remarks>
		/// <para>
		/// The descriptor size returned by this method is used as one input to the helper structures <c>CD3DX12_CPU_DESCRIPTOR_HANDLE</c>
		/// and <c>CD3DX12_GPU_DESCRIPTOR_HANDLE</c>.
		///  Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12Device::GetDescriptorHandleIncrementSize</b> as follows:</para>
		/// <para>
		/// Create the descriptor heap for the resources. The <c>m_rtvDescriptorSize</c> variable stores the render target view descriptor
		/// handle increment size, and is used in the <b>Create frame resources</b> section of the code.
		/// </para>
		/// <para>
		/// <c>// Create descriptor heaps. { // Describe and create a render target view (RTV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// rtvHeapDesc = {}; rtvHeapDesc.NumDescriptors = FrameCount; rtvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_RTV; rtvHeapDesc.Flags
		/// = D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;rtvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_rtvHeap))); // Describe and create a depth stencil view (DSV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// dsvHeapDesc = {}; dsvHeapDesc.NumDescriptors = 1; dsvHeapDesc.Type = D3D12_DESCRIPTOR_HEAP_TYPE_DSV; dsvHeapDesc.Flags =
		/// D3D12_DESCRIPTOR_HEAP_FLAG_NONE; ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;dsvHeapDesc,
		/// IID_PPV_ARGS(&amp;m_dsvHeap))); // Describe and create a constant buffer view (CBV) descriptor heap. D3D12_DESCRIPTOR_HEAP_DESC
		/// cbvHeapDesc = {}; cbvHeapDesc.NumDescriptors = CbvCountPerFrame * FrameCount; cbvHeapDesc.Type =
		/// D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV; cbvHeapDesc.Flags = D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE;
		/// ThrowIfFailed(m_device-&gt;CreateDescriptorHeap(&amp;cbvHeapDesc, IID_PPV_ARGS(&amp;m_cbvHeap))); // Describe and create a heap
		/// for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1; queryHeapDesc.Type =
		/// D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc,
		/// IID_PPV_ARGS(&amp;m_queryHeap))); m_rtvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_RTV); m_cbvSrvDescriptorSize =
		/// m_device-&gt;GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV); } // Create frame resources. {
		/// CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); // Create a RTV and a command
		/// allocator for each frame. for (UINT n = 0; n &lt; FrameCount; n++) { ThrowIfFailed(m_swapChain-&gt;GetBuffer(n,
		/// IID_PPV_ARGS(&amp;m_renderTargets[n]))); m_device-&gt;CreateRenderTargetView(m_renderTargets[n].Get(), nullptr, rtvHandle);
		/// rtvHandle.Offset(1, m_rtvDescriptorSize); ThrowIfFailed(m_device-&gt;CreateCommandAllocator(D3D12_COMMAND_LIST_TYPE_DIRECT,
		/// IID_PPV_ARGS(&amp;m_commandAllocators[n]))); } }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getdescriptorhandleincrementsize UINT
		// GetDescriptorHandleIncrementSize( [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType );
		[PreserveSig]
		new uint GetDescriptorHandleIncrementSize(D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapType);

		/// <summary>Creates a root signature layout.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set bits to identify the nodes (the device's
		/// physical adapters) to which the root signature is to apply. Each bit in the mask corresponds to a single node. Refer to
		/// <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="pBlobWithRootSignature">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>A pointer to the source data for the serialized signature.</para>
		/// </param>
		/// <param name="blobLengthInBytes">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>The size, in bytes, of the block of memory that <i>pBlobWithRootSignature</i> points to.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b><b>REFIID</b></b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the root signature interface. See Remarks. An input parameter.</para>
		/// </param>
		/// <param name="ppvRootSignature">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the root signature.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// <para>This method returns <b>E_INVALIDARG</b> if the blob that <i>pBlobWithRootSignature</i> points to is invalid.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application procedurally generates a <c>D3D12_ROOT_SIGNATURE_DESC</c> data structure, it must pass a pointer to this
		/// <b>D3D12_ROOT_SIGNATURE_DESC</b> in a call to <c>D3D12SerializeRootSignature</c> to make the serialized form. The application
		/// then passes the serialized form to <i>pBlobWithRootSignature</i> in a call to <b>ID3D12Device::CreateRootSignature</b>.
		/// </para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the root signature layout can be obtained by using the __uuidof() macro.
		/// For example, __uuidof( <c>ID3D12RootSignature</c>) will get the <b>GUID</b> of the interface to a root signature.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12Device::CreateRootSignature</b> as follows:</para>
		/// <para>Create an empty root signature.</para>
		/// <para>
		/// <c>CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc; rootSignatureDesc.Init(0, nullptr, 0, nullptr,
		/// D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT); ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
		/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
		/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(), IID_PPV_ARGS(&amp;m_rootSignature)));</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createrootsignature HRESULT CreateRootSignature(
		// [in] UINT nodeMask, [in] const void *pBlobWithRootSignature, [in] SIZE_T blobLengthInBytes, REFIID riid, [out] void
		// **ppvRootSignature );
		[PreserveSig]
		new HRESULT CreateRootSignature(uint nodeMask, [In] IntPtr pBlobWithRootSignature, [In] SizeT blobLengthInBytes, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppvRootSignature);

		/// <summary>Creates a constant-buffer view for accessing resource data.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_CONSTANT_BUFFER_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_CONSTANT_BUFFER_VIEW_DESC</c> structure that describes the constant-buffer view.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the constant-buffer view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createconstantbufferview void
		// CreateConstantBufferView( [in, optional] const D3D12_CONSTANT_BUFFER_VIEW_DESC *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE
		// DestDescriptor );
		[PreserveSig]
		new void CreateConstantBufferView([In, Optional] StructPointer<D3D12_CONSTANT_BUFFER_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the shader resource.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c> structure that describes the shader-resource view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and for buffers SRVs target a full buffer and are typed (not raw or structured), and for textures SRVs target a full texture,
		/// all mips and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// Describes the CPU descriptor handle that represents the shader-resource view. This handle can be created in a shader-visible or
		/// non-shader-visible descriptor heap.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c></c><c></c><c></c> Processing YUV 4:2:0 video formats</para>
		/// <para>
		/// An app must map the luma (Y) plane separately from the chroma (UV) planes. Developers do this by calling
		/// <b>CreateShaderResourceView</b> twice for the same texture and passing in 1-channel and 2-channel formats. Passing in a
		/// 1-channel format compatible with the Y plane maps only the Y plane. Passing in a 2-channel format compatible with the UV planes
		/// (together) maps only the U and V planes as a single resource view.
		/// </para>
		/// <para>YUV 4:2:0 formats are listed in <c>DXGI_FORMAT</c>. Examples The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12Device::CreateShaderResourceView</b> as follows:</para>
		/// <para>Describe and create two shader resource views based on one description.</para>
		/// <para>
		/// <c>D3D12_SHADER_RESOURCE_VIEW_DESC srvDesc = {}; srvDesc.Shader4ComponentMapping = D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING;
		/// srvDesc.Format = DXGI_FORMAT_UNKNOWN; srvDesc.ViewDimension = D3D12_SRV_DIMENSION_BUFFER; srvDesc.Buffer.FirstElement = 0;
		/// srvDesc.Buffer.NumElements = ParticleCount; srvDesc.Buffer.StructureByteStride = sizeof(Particle); srvDesc.Buffer.Flags =
		/// D3D12_BUFFER_SRV_FLAG_NONE; CD3DX12_CPU_DESCRIPTOR_HANDLE srvHandle0(m_srvUavHeap-&gt;GetCPUDescriptorHandleForHeapStart(),
		/// SrvParticlePosVelo0 + index, m_srvUavDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// srvHandle1(m_srvUavHeap-&gt;GetCPUDescriptorHandleForHeapStart(), SrvParticlePosVelo1 + index, m_srvUavDescriptorSize);
		/// m_device-&gt;CreateShaderResourceView(m_particleBuffer0[index].Get(), &amp;srvDesc, srvHandle0);
		/// m_device-&gt;CreateShaderResourceView(m_particleBuffer1[index].Get(), &amp;srvDesc, srvHandle1);</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createshaderresourceview void
		// CreateShaderResourceView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_SHADER_RESOURCE_VIEW_DESC *pDesc,
		// [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateShaderResourceView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_SHADER_RESOURCE_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a view for unordered accessing.</summary>
		/// <param name="pResource">
		/// <para>Type: [in, optional] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the unordered access.</para>
		/// <para>At least one of <i>pResource</i> or <i>pDesc</i> must be provided.</para>
		/// <para>
		/// A null <i>pResource</i> is used to initialize a null descriptor, which guarantees Direct3D 11-like null binding behavior
		/// (reading 0s, writes are discarded), but must have a valid <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pCounterResource">
		/// <para>Type: [in, optional] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>The <c>ID3D12Resource</c> for the counter (if any) associated with the UAV.</para>
		/// <para>
		/// If <i>pCounterResource</i> is not specified, then the <b>CounterOffsetInBytes</b> member of the <c>D3D12_BUFFER_UAV</c>
		/// structure must be 0.
		/// </para>
		/// <para>
		/// If <i>pCounterResource</i> is specified, then there is a counter associated with the UAV, and the runtime performs validation of
		/// the following requirements:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>The <b>StructureByteStride</b> member of the <c>D3D12_BUFFER_UAV</c> structure must be greater than 0.</description>
		/// </item>
		/// <item>
		/// <description>The format must be DXGI_FORMAT_UNKNOWN.</description>
		/// </item>
		/// <item>
		/// <description>The D3D12_BUFFER_UAV_FLAG_RAW flag (a <c>D3D12_BUFFER_UAV_FLAGS</c> enumeration constant) must not be set.</description>
		/// </item>
		/// <item>
		/// <description>Both of the resources ( <i>pResource</i> and <i>pCounterResource</i>) must be buffers.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The <b>CounterOffsetInBytes</b> member of the <c>D3D12_BUFFER_UAV</c> structure must be a multiple of
		/// **D3D12_UAV_COUNTER_PLACEMENT_ALIGNMENT** (4096), and must be within the range of the counter resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description><i>pResource</i> cannot be NULL</description>
		/// </item>
		/// <item>
		/// <description><i>pDesc</i> cannot be NULL.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in, optional] <b>const <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure that describes the unordered-access view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and for buffers UAVs target a full buffer and are typed, and for textures UAVs target the first mip and all array slices. Not
		/// all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the unordered-access view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createunorderedaccessview void
		// CreateUnorderedAccessView( ID3D12Resource *pResource, ID3D12Resource *pCounterResource, const D3D12_UNORDERED_ACCESS_VIEW_DESC
		// *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateUnorderedAccessView([In, Optional] ID3D12Resource? pResource, [In, Optional] ID3D12Resource? pCounterResource,
			[In, Optional] StructPointer<D3D12_UNORDERED_ACCESS_VIEW_DESC> pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the render target.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RENDER_TARGET_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure that describes the render-target view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and RTVs target the first mip and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the destination where the newly-created render target view will reside.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createrendertargetview void
		// CreateRenderTargetView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_RENDER_TARGET_VIEW_DESC *pDesc, [in]
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateRenderTargetView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_RENDER_TARGET_VIEW_DESC> pDesc,
			[In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Creates a depth-stencil view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> object that represents the depth stencil.</para>
		/// <para>
		/// At least one of <i>pResource</i> or <i>pDesc</i> must be provided. A null <i>pResource</i> is used to initialize a null
		/// descriptor, which guarantees D3D11-like null binding behavior (reading 0s, writes are discarded), but must have a valid
		/// <i>pDesc</i> in order to determine the descriptor type.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure that describes the depth-stencil view.</para>
		/// <para>
		/// A null <i>pDesc</i> is used to initialize a default descriptor, if possible. This behavior is identical to the D3D11 null
		/// descriptor behavior, where defaults are filled in. This behavior inherits the resource format and dimension (if not typeless)
		/// and DSVs target the first mip and all array slices. Not all resources support null descriptor initialization.
		/// </para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the depth-stencil view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createdepthstencilview void
		// CreateDepthStencilView( [in, optional] ID3D12Resource *pResource, [in, optional] const D3D12_DEPTH_STENCIL_VIEW_DESC *pDesc, [in]
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateDepthStencilView([In, Optional] ID3D12Resource? pResource, [In, Optional] StructPointer<D3D12_DEPTH_STENCIL_VIEW_DESC> pDesc,
			[In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Create a sampler object that encapsulates sampling information for a texture.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_SAMPLER_DESC</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_SAMPLER_DESC</c> structure that describes the sampler.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap that holds the sampler.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createsampler void CreateSampler( [in] const
		// D3D12_SAMPLER_DESC *pDesc, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		new void CreateSampler(in D3D12_SAMPLER_DESC pDesc, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>Copies descriptors from a source to a destination.</summary>
		/// <param name="NumDestDescriptorRanges">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of destination descriptor ranges to copy to.</para>
		/// </param>
		/// <param name="pDestDescriptorRangeStarts">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>An array of <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> objects to copy to.</para>
		/// <para>All the destination and source descriptors must be in heaps of the same <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>.</para>
		/// </param>
		/// <param name="pDestDescriptorRangeSizes">
		/// <para>Type: <b>const <c>UINT</c>*</b></para>
		/// <para>An array of destination descriptor range sizes to copy to.</para>
		/// </param>
		/// <param name="NumSrcDescriptorRanges">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of source descriptor ranges to copy from.</para>
		/// </param>
		/// <param name="pSrcDescriptorRangeStarts">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>An array of <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> objects to copy from.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// All elements in the pSrcDescriptorRangeStarts parameter must be in a non shader-visible descriptor heap. This is because
		/// shader-visible descriptor heaps may be created in <b>WRITE_COMBINE</b> memory or GPU local memory, which is prohibitively slow
		/// to read from. If your application manages descriptor heaps via copying the descriptors required for a given pass or frame from
		/// local "storage" descriptor heaps to the GPU-bound descriptor heap, use shader-opaque heaps for the storage heaps and copy into
		/// the GPU-visible heap as required.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pSrcDescriptorRangeSizes">
		/// <para>Type: <b>const <c>UINT</c>*</b></para>
		/// <para>An array of source descriptor range sizes to copy from.</para>
		/// </param>
		/// <param name="DescriptorHeapsType">
		/// <para>Type: <b><c>D3D12_DESCRIPTOR_HEAP_TYPE</c></b></para>
		/// <para>
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to copy with. This is required as
		/// different descriptor types may have different sizes.
		/// </para>
		/// <para>Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Where applicable, prefer <c><b>ID3D12Device::CopyDescriptorsSimple</b></c> to this method. It can have a better CPU cache miss
		/// rate due to the linear nature of the copy.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-copydescriptors void CopyDescriptors( [in] UINT
		// NumDestDescriptorRanges, [in] const D3D12_CPU_DESCRIPTOR_HANDLE *pDestDescriptorRangeStarts, [in, optional] const UINT
		// *pDestDescriptorRangeSizes, [in] UINT NumSrcDescriptorRanges, [in] const D3D12_CPU_DESCRIPTOR_HANDLE *pSrcDescriptorRangeStarts,
		// [in, optional] const UINT *pSrcDescriptorRangeSizes, [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType );
		[PreserveSig]
		new void CopyDescriptors(int NumDestDescriptorRanges, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_CPU_DESCRIPTOR_HANDLE[] pDestDescriptorRangeStarts,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? pDestDescriptorRangeSizes, int NumSrcDescriptorRanges,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D12_CPU_DESCRIPTOR_HANDLE[] pSrcDescriptorRangeStarts,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] uint[]? pSrcDescriptorRangeSizes, D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType);

		/// <summary>Copies descriptors from a source to a destination.</summary>
		/// <param name="NumDescriptors">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of descriptors to copy.</para>
		/// </param>
		/// <param name="DestDescriptorRangeStart">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> that describes the destination descriptors to start to copy to.</para>
		/// <para>The destination and source descriptors must be in heaps of the same <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>.</para>
		/// </param>
		/// <param name="SrcDescriptorRangeStart">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b> that describes the source descriptors to start to copy from.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// The SrcDescriptorRangeStart parameter must be in a non shader-visible descriptor heap. This is because shader-visible descriptor
		/// heaps may be created in <b>WRITE_COMBINE</b> memory or GPU local memory, which is prohibitively slow to read from. If your
		/// application manages descriptor heaps via copying the descriptors required for a given pass or frame from local "storage"
		/// descriptor heaps to the GPU-bound descriptor heap, then use shader-opaque heaps for the storage heaps and copy into the
		/// GPU-visible heap as required.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="DescriptorHeapsType">
		/// <para>Type: <b><c>D3D12_DESCRIPTOR_HEAP_TYPE</c></b></para>
		/// <para>
		/// The <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the type of descriptor heap to copy with. This is required as
		/// different descriptor types may have different sizes.
		/// </para>
		/// <para>Both the source and destination descriptor heaps must have the same type, else the debug layer will emit an error.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Where applicable, prefer this method to <c><b>ID3D12Device::CopyDescriptors</b></c>. It can have a better CPU cache miss rate
		/// due to the linear nature of the copy.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-copydescriptorssimple void CopyDescriptorsSimple(
		// [in] UINT NumDescriptors, [in] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart, [in] D3D12_CPU_DESCRIPTOR_HANDLE
		// SrcDescriptorRangeStart, [in] D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType );
		[PreserveSig]
		new void CopyDescriptorsSimple(uint NumDescriptors, [In] D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptorRangeStart, [In] D3D12_CPU_DESCRIPTOR_HANDLE SrcDescriptorRangeStart,
			D3D12_DESCRIPTOR_HEAP_TYPE DescriptorHeapsType);

		/// <summary>Gets the size and alignment of memory required for a collection of resources on this adapter.</summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// <para>If an error occurs, then <b>D3D12_RESOURCE_ALLOCATION_INFO::SizeInBytes</b> equals <b>UINT64_MAX</b>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you're using <c>CreatePlacedResource</c>, your application must use <b>GetResourceAllocationInfo</b> in order to understand
		/// the size and alignment characteristics of texture resources. The results of this method vary depending on the particular
		/// adapter, and must be treated as unique to this adapter and driver version.
		/// </para>
		/// <para>
		/// Your application can't use the output of <b>GetResourceAllocationInfo</b> to understand packed mip properties of textures. To
		/// understand packed mip properties of textures, your application must use <c>GetResourceTiling</c>.
		/// </para>
		/// <para>
		/// Texture resource sizes significantly differ from the information returned by <b>GetResourceTiling</b>, because some adapter
		/// architectures allocate extra memory for textures to reduce the effective bandwidth during common rendering scenarios. This even
		/// includes textures that have constraints on their texture layouts, or have standardized texture layouts. That extra memory can't
		/// be sparsely mapped nor remapped by an application using <c>CreateReservedResource</c> and <c>UpdateTileMappings</c>, so it isn't
		/// reported by <b>GetResourceTiling</b>.
		/// </para>
		/// <para>
		/// Your application can forgo using <b>GetResourceAllocationInfo</b> for buffer resources (
		/// <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>). Buffers have the same size on all adapters, which is merely the smallest multiple of
		/// 64KB that's greater or equal to <c>D3D12_RESOURCE_DESC::Width</c>.
		/// </para>
		/// <para>
		/// When multiple resource descriptions are passed in, the C++ algorithm for calculating a structure size and alignment are used.
		/// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource, reports differing sizes
		/// based on the order of the array. If the 4MB aligned resource is in the middle, then the resulting <b>Size</b> is 12MB.
		/// Otherwise, the resulting <b>Size</b> is 8MB. The <b>Alignment</b> returned would always be 4MB, because it's the superset of all
		/// alignments in the resource array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getresourceallocationinfo(uint_uint_constd3d12_resource_desc)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo( [in] UINT visibleMask, [in] UINT numResourceDescs, [in] const
		// D3D12_RESOURCE_DESC *pResourceDescs );
		[PreserveSig]
		new D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_RESOURCE_DESC[] pResourceDescs);

		/// <summary>
		/// Divulges the equivalent custom heap properties that are used for non-custom heap types, based on the adapter's architectural properties.
		/// </summary>
		/// <param name="nodeMask">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter). Each bit in the mask corresponds to a single node. Only 1 bit must be set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="heapType">
		/// <para>Type: <b><c>D3D12_HEAP_TYPE</c></b></para>
		/// <para>
		/// A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the heap to get properties for. D3D12_HEAP_TYPE_CUSTOM is not supported as a
		/// parameter value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_HEAP_PROPERTIES</c></b></para>
		/// <para>
		/// Returns a <c>D3D12_HEAP_PROPERTIES</c> structure that provides properties for the specified heap. The <b>Type</b> member of the
		/// returned D3D12_HEAP_PROPERTIES is always D3D12_HEAP_TYPE_CUSTOM.
		/// </para>
		/// <para>When <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>::UMA is FALSE, the returned D3D12_HEAP_PROPERTIES members convert as follows:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_COMBINE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L1.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// When D3D12_FEATURE_DATA_ARCHITECTURE::UMA is TRUE and D3D12_FEATURE_DATA_ARCHITECTURE::CacheCoherentUMA is FALSE, the returned
		/// D3D12_HEAP_PROPERTIES members convert as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_COMBINE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// When D3D12_FEATURE_DATA_ARCHITECTURE::UMA is TRUE and D3D12_FEATURE_DATA_ARCHITECTURE::CacheCoherentUMA is TRUE, the returned
		/// D3D12_HEAP_PROPERTIES members convert as follows:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Heap Type</description>
		/// <description>How the returned D3D12_HEAP_PROPERTIES members convert</description>
		/// </listheader>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_UPLOAD</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_DEFAULT</description>
		/// <description><b>CPUPageProperty</b> = NOT_AVAILABLE, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_HEAP_TYPE_READBACK</description>
		/// <description><b>CPUPageProperty</b> = WRITE_BACK, <b>MemoryPoolPreference</b> = L0.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getcustomheapproperties(uint_d3d12_heap_type)
		// D3D12_HEAP_PROPERTIES GetCustomHeapProperties( [in] UINT nodeMask, D3D12_HEAP_TYPE heapType );
		[PreserveSig]
		new D3D12_HEAP_PROPERTIES GetCustomHeapProperties(uint nodeMask, D3D12_HEAP_TYPE heapType);

		/// <summary>
		/// Creates both a resource and an implicit heap, such that the heap is big enough to contain the entire resource, and the resource
		/// is mapped to the heap.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommittedresource HRESULT
		// CreateCommittedResource( [in] const D3D12_HEAP_PROPERTIES *pHeapProperties, [in] D3D12_HEAP_FLAGS HeapFlags, [in] const
		// D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialResourceState, [in, optional] const D3D12_CLEAR_VALUE
		// *pOptimizedClearValue, [in] REFIID riidResource, [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateCommittedResource(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>Creates a heap that can be used with placed resources and reserved resources.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_HEAP_DESC</b> structure that describes the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the heap interface to return in ppvHeap.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Heap</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// An optional pointer to a memory block that receives the requested interface pointer to the created heap object. <paramref
		/// name="ppvHeap"/> can be <c>nullptr</c>, to enable capability testing. When ppvHeap is <c>nullptr</c>, no object is created, and
		/// <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the heap.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para><b>CreateHeap</b> creates a heap that can be used with placed resources and reserved resources.</para>
		/// <para>
		/// Before releasing the final reference on the heap, your application must ensure that the GPU will no longer read or write to this heap.
		/// </para>
		/// <para>
		/// A placed resource object holds a reference on the heap it is created on; but a reserved resource doesn't hold a reference for
		/// each mapping made to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createheap HRESULT CreateHeap( [in] const
		// D3D12_HEAP_DESC *pDesc, [in] REFIID riid, [out, optional] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateHeap(in D3D12_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvHeap);

		/// <summary>
		/// <para>
		/// Creates a resource that is placed in a specific heap. Placed resources are the lightest weight resource objects available, and
		/// are the fastest to create and destroy.
		/// </para>
		/// <para>
		/// Your application can re-use video memory by overlapping multiple Direct3D placed and reserved resources on heap regions. The
		/// simple memory re-use model (described in <c>Remarks</c>) exists to clarify which overlapping resource is valid at any given
		/// time. To maximize graphics tool support, with the simple model data-inheritance isn't supported; and finer-grained tile and
		/// sub-resource invalidation isn't supported. Only full overlapping resource invalidation occurs.
		/// </para>
		/// </summary>
		/// <param name="pHeap">
		/// <para>Type: [in] <b><c>ID3D12Heap</c></b>*</para>
		/// <para>A pointer to the <b>ID3D12Heap</b> interface that represents the heap in which the resource is placed.</para>
		/// </param>
		/// <param name="HeapOffset">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// The offset, in bytes, to the resource. The HeapOffset must be a multiple of the resource's alignment, and HeapOffset plus the
		/// resource size must be smaller than or equal to the heap size. <c><b>GetResourceAllocationInfo</b></c> must be used to understand
		/// the sizes of texture resources.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_RESOURCE_DESC</c></b>*</para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>
		/// When a resource is created together with a <b>D3D12_HEAP_TYPE_UPLOAD</b> heap, InitialState must be
		/// <b>D3D12_RESOURCE_STATE_GENERIC_READ</b>. When a resource is created together with a <b>D3D12_HEAP_TYPE_READBACK</b> heap,
		/// InitialState must be <b>D3D12_RESOURCE_STATE_COPY_DEST</b>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: [in, optional] <b>const <c>D3D12_CLEAR_VALUE</c></b>*</para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <b>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</b> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, your application should choose the value that the clear operation will most commonly be called with.
		/// </para>
		/// <para>
		/// Clear operations can be called with other values, but those operations will not be as efficient as when the value matches the
		/// one passed into resource creation.
		/// </para>
		/// <para><paramref name="pOptimizedClearValue"/> must be NULL when used with <b>D3D12_RESOURCE_DIMENSION_BUFFER</b>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the resource interface. This is an input parameter.</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the resource can be obtained by using the <c>__uuidof</c> macro. For
		/// example, <c>__uuidof(ID3D12Resource)</c> gets the <b>GUID</b> of the interface to a resource. Although <b>riid</b> is, most
		/// commonly, the GUID for <c><b>ID3D12Resource</b></c>, it may be any <b>GUID</b> for any interface. If the resource object doesn't
		/// support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: [out, optional] <b>void</b>**</para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the resource. ppvResource can be NULL, to enable capability testing. When
		/// ppvResource is NULL, no object will be created and S_FALSE will be returned when pResourceDesc and other parameters are valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the resource. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreatePlacedResource</b> is similar to fully mapping a reserved resource to an offset within a heap; but the virtual address
		/// space associated with a heap may be reused as well.
		/// </para>
		/// <para>
		/// Placed resources are lighter weight to create and destroy than committed resources are. This is because no heap is created nor
		/// destroyed during those operations. In addition, placed resources enable an even lighter weight technique to reuse memory than
		/// resource creation and destruction—that is, reuse through aliasing, and aliasing barriers. Multiple placed resources may
		/// simultaneously overlap each other on the same heap, but only a single overlapping resource can be used at a time.
		/// </para>
		/// <para>
		/// There are two placed resource usage semantics—a simple model, and an advanced model. We recommend that you choose the simple
		/// model (it maximizes graphics tool support across the diverse ecosystem of GPUs), unless and until you find that you need the
		/// advanced model for your app.
		/// </para>
		/// <para>Simple model</para>
		/// <para>
		/// In this model, you can consider a placed resource to be in one of two states: active, or inactive. It's invalid for the GPU to
		/// either read or write from an inactive resource. Placed resources are created in the inactive state.
		/// </para>
		/// <para>
		/// To activate a resource with an aliasing barrier on a command list, your application must pass the resource in
		/// <c><b>D3D12_RESOURCE_ALIASING_BARRIER::pResourceAfter</b></c>. <b>pResourceBefore</b> can be left NULL during an activation. All
		/// resources that share physical memory with the activated resource now become inactive, which includes overlapping placed and
		/// reserved resources.
		/// </para>
		/// <para>Aliasing barriers should be grouped up and submitted together, in order to maximize efficiency.</para>
		/// <para>
		/// After activation, resources with either the render target or depth stencil flags must be further initialized. See the notes on
		/// the required resource initialization below.
		/// </para>
		/// <para>Notes on the required resource initialization</para>
		/// <para>
		/// Certain resource types still require initialization. Resources with either the render target or depth stencil flags must be
		/// initialized with either a clear operation or a collection of full subresource copies. If an aliasing barrier was used to denote
		/// the transition between two aliased resources, the initialization must occur after the aliasing barrier. This initialization is
		/// still required whenever a resource would've been activated in the simple model.
		/// </para>
		/// <para>
		/// Placed and reserved resources with either the render target or depth stencil flags must be initialized with one of the following
		/// operations before other operations are supported.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>A Clear operation; for example <c>ClearRenderTargetView</c> or <c>ClearDepthStencilView</c>.</description>
		/// </item>
		/// <item>
		/// <description>A <c>DiscardResource</c> operation.</description>
		/// </item>
		/// <item>
		/// <description>A Copy operation; for example <c>CopyBufferRegion</c>, <c>CopyTextureRegion</c>, or <c>CopyResource</c>.</description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications should prefer the most explicit operation that results in the least amount of texels modified. Consider the
		/// following examples.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Using a depth buffer to solve pixel visibility typically requires each depth texel start out at 1.0 or 0. Therefore, a Clear
		/// operation should be the most efficient option for aliased depth buffer initialization.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// An application may use an aliased render target as a destination for tone mapping. Since the application will render over every
		/// pixel during the tone mapping, <c>DiscardResource</c> should be the most efficient option for initialization.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Advanced model</para>
		/// <para>In this model, you can ignore the active/inactive state abstraction. Instead, you must honor these lower-level rules.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// An aliasing barrier must be between two different GPU resource accesses of the same physical memory, as long as those accesses
		/// are within the same <c>ExecuteCommandLists</c> call.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The first rendering operation to certain types of aliased resource must still be an initialization, just like the simple model.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Initialization operations must occur either on an entire subresource, or on a 64KB granularity. An entire subresource
		/// initialization is supported for all resource types. A 64KB initialization granularity, aligned at a 64KB offset, is supported
		/// for buffers and textures with either the 64KB_UNDEFINED_SWIZZLE or 64KB_STANDARD_SWIZZLE texture layout (refer to <c>D3D12_TEXTURE_LAYOUT</c>).
		/// </para>
		/// <para>Notes on the aliasing barrier</para>
		/// <para>
		/// The aliasing barrier may set NULL for both pResourceAfter and pResourceBefore. The memory coherence definition of
		/// <c><b>ExecuteCommandLists</b></c> and an aliasing barrier are the same, such that two aliased accesses to the same physical
		/// memory need no aliasing barrier when the accesses are in two different <b>ExecuteCommandLists</b> invocations.
		/// </para>
		/// <para>
		/// For D3D12 advanced usage models, the synchronization definition of <c><b>ExecuteCommandLists</b></c> is equivalent to an
		/// aliasing barrier. Therefore, applications may either insert an aliasing barrier between reusing physical memory, or ensure the
		/// two aliased usages of physical memory occurs in two separate calls to <b>ExecuteCommandLists</b>.
		/// </para>
		/// <para>
		/// The amount of inactivation varies based on resource properties. Textures with undefined memory layouts are the worst case, as
		/// the entire texture must be inactivated atomically. For two overlapping resources with defined layouts, inactivation can result
		/// in only the overlapping aligned regions of a resource. Data inheritance can even be well-defined. For more details, see
		/// <c>Memory aliasing and data inheritance</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createplacedresource HRESULT
		// CreatePlacedResource( ID3D12Heap *pHeap, UINT64 HeapOffset, const D3D12_RESOURCE_DESC *pDesc, D3D12_RESOURCE_STATES InitialState,
		// const D3D12_CLEAR_VALUE *pOptimizedClearValue, REFIID riid, void **ppvResource );
		[PreserveSig]
		new HRESULT CreatePlacedResource([In] ID3D12Heap pHeap, ulong HeapOffset, in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>Creates a resource that is reserved, and not yet mapped to any pages in a heap.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource. See <b>Remarks</b>.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateReservedResource</b> is equivalent to <c>D3D11_RESOURCE_MISC_TILED</c> in Direct3D 11. It creates a resource with
		/// virtual memory only, no backing store.
		/// </para>
		/// <para>You need to map the resource to physical memory (that is, to a heap) using <c>CopyTileMappings</c> and <c>UpdateTileMappings</c>.</para>
		/// <para>
		/// These resource types can only be created when the adapter supports tiled resource tier 1 or greater. The tiled resource tier
		/// defines the behavior of accessing a resource that is not mapped to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createreservedresource HRESULT
		// CreateReservedResource( [in] const D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialState, [in, optional] const
		// D3D12_CLEAR_VALUE *pOptimizedClearValue, [in] REFIID riid, [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateReservedResource(in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object? ppvResource);

		/// <summary>Creates a shared handle to a heap, resource, or fence object.</summary>
		/// <param name="pObject">
		/// <para>Type: <b><c>ID3D12DeviceChild</c>*</b></para>
		/// <para>
		/// A pointer to the <c>ID3D12DeviceChild</c> interface that represents the heap, resource, or fence object to create for sharing.
		/// The following interfaces (derived from <b>ID3D12DeviceChild</b>) are supported:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAttributes">
		/// <para>Type: <b>const <c>SECURITY_ATTRIBUTES</c>*</b></para>
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security
		/// descriptor, and a <b>Boolean</b> value that determines whether child processes can inherit the returned handle.
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
		/// <param name="Access">
		/// <para>Type: <b><c>DWORD</c></b></para>
		/// <para>Currently the only value this parameter accepts is GENERIC_ALL.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>
		/// A <b>NULL</b>-terminated <b>UNICODE</b> string that contains the name to associate with the shared heap. The name is limited to
		/// MAX_PATH characters. Name comparison is case-sensitive.
		/// </para>
		/// <para>
		/// If <i>Name</i> matches the name of an existing resource, <b>CreateSharedHandle</b> fails with
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
		/// <para>Type: <b><c>HANDLE</c>*</b></para>
		/// <para>
		/// A pointer to a variable that receives the NT HANDLE value to the resource to share. You can use this handle in calls to access
		/// the resource.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
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
		/// <description>Possibly other error codes that are described in the <c>Direct3D 12 Return Codes</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Both heaps and committed resources can be shared. Sharing a committed resource shares the implicit heap along with the committed
		/// resource description, such that a compatible resource description can be mapped to the heap from another device.
		/// </para>
		/// <para>
		/// For Direct3D 11 and Direct3D 12 interop scenarios, a shared fence is opened in DirectX 11 with the
		/// <c>ID3D11Device5::OpenSharedFence</c> method, and a shared resource is opened with the <c>ID3D11Device::OpenSharedResource1</c> method.
		/// </para>
		/// <para>
		/// For Direct3D 12, a shared handle is opened with the <c>ID3D12Device::OpenSharedHandle</c> or the
		/// ID3D12Device::OpenSharedHandleByName method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createsharedhandle HRESULT CreateSharedHandle(
		// [in] ID3D12DeviceChild *pObject, [in, optional] const SECURITY_ATTRIBUTES *pAttributes, DWORD Access, [in, optional] LPCWSTR
		// Name, [out] HANDLE *pHandle );
		[PreserveSig]
		new HRESULT CreateSharedHandle([In] ID3D12DeviceChild pObject, [In, Optional] SECURITY_ATTRIBUTES? pAttributes, ACCESS_MASK Access,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? Name, out HANDLE pHandle);

		/// <summary>Opens a handle for shared resources, shared heaps, and shared fences, by using HANDLE and REFIID.</summary>
		/// <param name="NTHandle">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>The handle that was output by the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for one of the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// <para>The REFIID , or GUID , of the interface can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D12Heap) will get the GUID of the interface to a resource.</para>
		/// </param>
		/// <param name="ppvObj">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to one of the following interfaces:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12Heap</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Resource</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12Fence</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-opensharedhandle HRESULT OpenSharedHandle( [in]
		// HANDLE NTHandle, REFIID riid, [out, optional] void **ppvObj );
		[PreserveSig]
		new HRESULT OpenSharedHandle(HANDLE NTHandle, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvObj);

		/// <summary>Opens a handle for shared resources, shared heaps, and shared fences, by using Name and Access.</summary>
		/// <param name="Name">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The name that was optionally passed as the <i>Name</i> parameter in the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="Access">
		/// <para>Type: <b>DWORD</b></para>
		/// <para>The access level that was specified in the <i>Access</i> parameter in the call to <c>ID3D12Device::CreateSharedHandle</c>.</para>
		/// </param>
		/// <param name="pNTHandle">
		/// <para>Type: <b>HANDLE*</b></para>
		/// <para>Pointer to the shared handle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-opensharedhandlebyname HRESULT
		// OpenSharedHandleByName( [in] LPCWSTR Name, DWORD Access, [out] HANDLE *pNTHandle );
		[PreserveSig]
		new HRESULT OpenSharedHandleByName([MarshalAs(UnmanagedType.LPWStr)] string Name, ACCESS_MASK Access, out HANDLE pNTHandle);

		/// <summary>Makes objects resident for the device.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to make resident for the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block that contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>
		/// Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following
		/// objects: Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>MakeResident</b> loads the data associated with a resource from disk, and re-allocates the memory from the resource's
		/// appropriate memory pool. This method should be called on the object which owns the physical memory.
		/// </para>
		/// <para>
		/// Use this method, and <c>Evict</c>, to manage GPU video memory, noting that this was done automatically in D3D11, but now has to
		/// be done by the app in D3D12.
		/// </para>
		/// <para>
		/// <b>MakeResident</b> and <c>Evict</c> can help applications manage the residency budget on many adapters. <b>MakeResident</b>
		/// explicitly pages-in data and, then, precludes page-out so the GPU can access the data. <b>Evict</b> enables page-out.
		/// </para>
		/// <para>
		/// Some GPU architectures do not benefit from residency manipulation, due to the lack of sufficient GPU virtual address space. Use
		/// <c>D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT</c> and <c>IDXGIAdapter3::QueryVideoMemoryInfo</c> to recognize when the
		/// maximum GPU VA space per-process is too small or roughly the same size as the residency budget. For such architectures, the
		/// residency budget will always be constrained by the amount of GPU virtual address space. <c>Evict</c> will not free-up any
		/// residency budget on such systems.
		/// </para>
		/// <para>
		/// Applications must handle <b>MakeResident</b> failures, even if there appears to be enough residency budget available. Physical
		/// memory fragmentation and adapter architecture quirks can preclude the utilization of large contiguous ranges. Applications
		/// should free up more residency budget before trying again.
		/// </para>
		/// <para>
		/// <b>MakeResident</b> is ref-counted, such that <c>Evict</c> must be called the same amount of times as <b>MakeResident</b> before
		/// <b>Evict</b> takes effect. Objects that support residency are made resident during creation, so a single <b>Evict</b> call will
		/// actually evict the object.
		/// </para>
		/// <para>
		/// Applications must use fences to ensure the GPU doesn't use non-resident objects. <b>MakeResident</b> must return before the GPU
		/// executes a command list that references the object. <c>Evict</c> must be called after the GPU finishes executing a command list
		/// that references the object.
		/// </para>
		/// <para>
		/// Evicted objects still consume the same GPU virtual address and same amount of GPU virtual address space. Therefore, resource
		/// descriptors and other GPU virtual address references are not invalidated after <c>Evict</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-makeresident HRESULT MakeResident( UINT
		// NumObjects, [in] ID3D12Pageable * const *ppObjects );
		[PreserveSig]
		new HRESULT MakeResident(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects);

		/// <summary>Enables the page-out of data, which precludes GPU access of that data.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to evict from the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block that contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>
		/// Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following
		/// objects: Descriptor Heaps, Heaps, Committed Resources, and Query Heaps
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>Evict</b> persists the data associated with a resource to disk, and then removes the resource from the memory pool where it
		/// was located. This method should be called on the object which owns the physical memory: either a committed resource (which owns
		/// both virtual and physical memory assignments) or a heap - noting that reserved resources do not have physical memory, and placed
		/// resources are borrowing memory from a heap.
		/// </para>
		/// <para>Refer to the remarks for <c>MakeResident</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-evict HRESULT Evict( UINT NumObjects, [in]
		// ID3D12Pageable * const *ppObjects );
		[PreserveSig]
		new HRESULT Evict(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects);

		/// <summary>Creates a fence object.</summary>
		/// <param name="InitialValue">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The initial value for the fence.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_FENCE_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_FENCE_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies options for the fence.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the fence interface ( <c>ID3D12Fence</c>). The <b>REFIID</b>, or <b>GUID</b>,
		/// of the interface to the fence can be obtained by using the __uuidof() macro. For example, __uuidof(ID3D12Fence) will get the
		/// <b>GUID</b> of the interface to a fence.
		/// </para>
		/// </param>
		/// <param name="ppFence">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Fence</c> interface that is used to access the fence.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createfence HRESULT CreateFence( UINT64
		// InitialValue, D3D12_FENCE_FLAGS Flags, REFIID riid, [out] void **ppFence );
		[PreserveSig]
		new HRESULT CreateFence(ulong InitialValue, D3D12_FENCE_FLAGS Flags, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppFence);

		/// <summary>
		/// Gets the reason that the device was removed, or <b>S_OK</b> if the device isn't removed. To be called back when a device is
		/// removed, consider using <c>ID3D12Fence::SetEventOnCompletion</c> with a value of <b>UINT64_MAX</b>. That's because device
		/// removal causes all fences to be signaled to that value (which also implies completing all events waited on, because they'll all
		/// be less than <b>UINT64_MAX</b>).
		/// </summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns the reason that the device was removed.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getdeviceremovedreason HRESULT GetDeviceRemovedReason();
		[PreserveSig]
		new HRESULT GetDeviceRemovedReason();

		/// <summary>
		/// Gets a resource layout that can be copied. Helps the app fill-in <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> when suballocating space in upload heaps.
		/// </summary>
		/// <param name="pResourceDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A description of the resource, as a pointer to a <c>D3D12_RESOURCE_DESC</c> structure.</para>
		/// </param>
		/// <param name="FirstSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
		/// </param>
		/// <param name="NumSubresources">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - <i>FirstSubresource</i>).</para>
		/// </param>
		/// <param name="BaseOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset, in bytes, to the resource.</para>
		/// </param>
		/// <param name="pLayouts">
		/// <para>Type: <b><c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structures, to be filled
		/// with the description and placement of each subresource.
		/// </para>
		/// </param>
		/// <param name="pNumRows">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, to be filled with the number of rows for each subresource.
		/// </para>
		/// </param>
		/// <param name="pRowSizeInBytes">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, each entry to be filled with the unpadded size in
		/// bytes of a row, of each subresource.
		/// </para>
		/// <para>For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4,</para>
		/// <para>then <i>pRowSizeInBytes</i> returns 128.</para>
		/// <para>
		/// <i>pRowSizeInBytes</i> should not be confused with <b>row pitch</b>, as examining <i>pLayouts</i> and getting the row pitch from
		/// that will give you 256 as it is aligned to D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.
		/// </para>
		/// </param>
		/// <param name="pTotalBytes">
		/// <para>Type: <b>UINT64*</b></para>
		/// <para>A pointer to an integer variable, to be filled with the total size, in bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This routine assists the application in filling out <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> structures, when suballocating space in upload heaps. The resulting structures are GPU
		/// adapter-agnostic, meaning that the values will not vary from one GPU adapter to the next. <b>GetCopyableFootprints</b> uses
		/// specified details about resource formats, texture layouts, and alignment requirements (from the <c>D3D12_RESOURCE_DESC</c>
		/// structure) to fill out the subresource structures. Applications have access to all these details, so this method, or a variation
		/// of it, could be written as part of the app.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12Device::GetCopyableFootprints</b> as follows:</para>
		/// <para>
		/// <c>// Returns required size of a buffer to be used for data upload inline UINT64 GetRequiredIntermediateSize( _In_
		/// ID3D12Resource* pDestinationResource, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources) { D3D12_RESOURCE_DESC Desc =
		/// pDestinationResource-&gt;GetDesc(); UINT64 RequiredSize = 0; ID3D12Device* pDevice;
		/// pDestinationResource-&gt;GetDevice(__uuidof(*pDevice), reinterpret_cast&lt;void**&gt;(&amp;pDevice));
		/// pDevice-&gt;GetCopyableFootprints(&amp;Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr,
		/// &amp;RequiredSize); pDevice-&gt;Release(); return RequiredSize; }</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getcopyablefootprints void GetCopyableFootprints(
		// [in] const D3D12_RESOURCE_DESC *pResourceDesc, [in] UINT FirstSubresource, [in] UINT NumSubresources, UINT64 BaseOffset, [out,
		// optional] D3D12_PLACED_SUBRESOURCE_FOOTPRINT *pLayouts, [out, optional] UINT *pNumRows, [out, optional] UINT64 *pRowSizeInBytes,
		// [out, optional] UINT64 *pTotalBytes );
		[PreserveSig]
		new void GetCopyableFootprints(in D3D12_RESOURCE_DESC pResourceDesc, uint FirstSubresource, int NumSubresources, ulong BaseOffset,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[]? pLayouts,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[]? pNumRows,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[]? pRowSizeInBytes,
			[Out, Optional] StructPointer<ulong> pTotalBytes);

		/// <summary>Creates a query heap. A query heap contains an array of queries.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_QUERY_HEAP_DESC</c>*</b></para>
		/// <para>Specifies the query heap in a <c>D3D12_QUERY_HEAP_DESC</c> structure.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>Specifies a REFIID that uniquely identifies the heap.</para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// Specifies a pointer to the heap, that will be returned on successful completion of the method. <i>ppvHeap</i> can be NULL, to
		/// enable capability testing. When <i>ppvHeap</i> is NULL, no object will be created and S_FALSE will be returned when <i>pDesc</i>
		/// is valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>Refer to <c>Queries</c> for more information. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12Device::CreateQueryHeap</b> as follows:</para>
		/// <para>Create a query heap and a query result buffer.</para>
		/// <para>
		/// <c>// Pipeline objects. D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain;
		/// ComPtr&lt;ID3D12Device&gt; m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount];
		/// ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocators[FrameCount]; ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue;
		/// ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature; ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_cbvHeap; ComPtr&lt;ID3D12DescriptorHeap&gt; m_dsvHeap; ComPtr&lt;ID3D12QueryHeap&gt;
		/// m_queryHeap; UINT m_rtvDescriptorSize; UINT m_cbvSrvDescriptorSize; UINT m_frameIndex; // Synchronization objects.
		/// ComPtr&lt;ID3D12Fence&gt; m_fence; UINT64 m_fenceValues[FrameCount]; HANDLE m_fenceEvent; // Asset objects.
		/// ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState; ComPtr&lt;ID3D12PipelineState&gt; m_queryState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; ComPtr&lt;ID3D12Resource&gt; m_vertexBuffer; ComPtr&lt;ID3D12Resource&gt;
		/// m_constantBuffer; ComPtr&lt;ID3D12Resource&gt; m_depthStencil; ComPtr&lt;ID3D12Resource&gt; m_queryResult;
		/// D3D12_VERTEX_BUFFER_VIEW m_vertexBufferView;</c>
		/// </para>
		/// <para>
		/// <c>// Describe and create a heap for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1;
		/// queryHeapDesc.Type = D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc, IID_PPV_ARGS(&amp;m_queryHeap)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createqueryheap HRESULT CreateQueryHeap( [in]
		// const D3D12_QUERY_HEAP_DESC *pDesc, REFIID riid, [out, optional] void **ppvHeap );
		[PreserveSig]
		new HRESULT CreateQueryHeap(in D3D12_QUERY_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvHeap);

		/// <summary>A development-time aid for certain types of profiling and experimental prototyping.</summary>
		/// <param name="Enable">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Specifies a BOOL that turns the stable power state on or off.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is only useful during the development of applications. It enables developers to profile GPU usage of multiple
		/// algorithms without experiencing artifacts from <c>dynamic frequency scaling</c>.
		/// </para>
		/// <para>
		/// Do not call this method in normal execution for a shipped application. This method only works while the machine is in
		/// <c>developer mode</c>. If developer mode is not enabled, then device removal will occur. Instead, call this method in response
		/// to an off-by-default, developer-facing switch. Calling it in response to command line parameters, config files, registry keys,
		/// and developer console commands are reasonable usage scenarios.
		/// </para>
		/// <para>
		/// A stable power state typically fixes GPU clock rates at a slower setting that is significantly lower than that experienced by
		/// users under normal application load. This reduction in clock rate affects the entire system. Slow clock rates are required to
		/// ensure processors don’t exhaust power, current, and thermal limits. Normal usage scenarios commonly leverage a processors
		/// ability to dynamically over-clock. Any conclusions made by comparing two designs under a stable power state should be
		/// double-checked with supporting results from real usage scenarios.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-setstablepowerstate HRESULT SetStablePowerState(
		// BOOL Enable );
		[PreserveSig]
		new HRESULT SetStablePowerState(bool Enable);

		/// <summary>This method creates a command signature.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMMAND_SIGNATURE_DESC</c>*</b></para>
		/// <para>Describes the command signature to be created with the <c>D3D12_COMMAND_SIGNATURE_DESC</c> structure.</para>
		/// </param>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>Specifies the <c>ID3D12RootSignature</c> that the command signature applies to.</para>
		/// <para>
		/// The root signature is required if any of the commands in the signature will update bindings on the pipeline. If the only command
		/// present is a draw or dispatch, the root signature parameter can be set to NULL.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier ( <b>GUID</b>) for the command signature interface ( <c>ID3D12CommandSignature</c>). The
		/// <b>REFIID</b>, or <b>GUID</b>, of the interface to the command signature can be obtained by using the __uuidof() macro. For
		/// example, __uuidof( <b>ID3D12CommandSignature</b>) will get the <b>GUID</b> of the interface to a command signature.
		/// </para>
		/// </param>
		/// <param name="ppvCommandSignature">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer, that on successful completion of the method will point to the created command signature ( <c>ID3D12CommandSignature</c>).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-createcommandsignature HRESULT
		// CreateCommandSignature( [in] const D3D12_COMMAND_SIGNATURE_DESC *pDesc, [in, optional] ID3D12RootSignature *pRootSignature,
		// REFIID riid, [out, optional] void **ppvCommandSignature );
		[PreserveSig]
		new HRESULT CreateCommandSignature(in D3D12_COMMAND_SIGNATURE_DESC pDesc, [In, Optional] ID3D12RootSignature? pRootSignature,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvCommandSignature);

		/// <summary>Gets info about how a tiled resource is broken into tiles.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies a tiled <c>ID3D12Resource</c> to get info about.</para>
		/// </param>
		/// <param name="pNumTilesForEntireResource">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>A pointer to a variable that receives the number of tiles needed to store the entire tiled resource.</para>
		/// </param>
		/// <param name="pPackedMipDesc">
		/// <para>Type: <b><c>D3D12_PACKED_MIP_INFO</c>*</b></para>
		/// <para>
		/// A pointer to a <c>D3D12_PACKED_MIP_INFO</c> structure that <b>GetResourceTiling</b> fills with info about how the tiled
		/// resource's mipmaps are packed.
		/// </para>
		/// </param>
		/// <param name="pStandardTileShapeForNonPackedMips">
		/// <para>Type: <b><c>D3D12_TILE_SHAPE</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_TILE_SHAPE</c> structure that <b>GetResourceTiling</b> fills with info about the tile shape. This is info
		/// about how pixels fit in the tiles, independent of tiled resource's dimensions, not including packed mipmaps. If the entire tiled
		/// resource is packed, this parameter is meaningless because the tiled resource has no defined layout for packed mipmaps. In this
		/// situation, <b>GetResourceTiling</b> sets the members of D3D12_TILE_SHAPE to zeros.
		/// </para>
		/// </param>
		/// <param name="pNumSubresourceTilings">
		/// <para>Type: <b>UINT*</b></para>
		/// <para>
		/// A pointer to a variable that contains the number of tiles in the subresource. On input, this is the number of subresources to
		/// query tilings for; on output, this is the number that was actually retrieved at <i>pSubresourceTilingsForNonPackedMips</i>
		/// (clamped to what's available).
		/// </para>
		/// </param>
		/// <param name="FirstSubresourceTilingToGet">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of the first subresource tile to get. <b>GetResourceTiling</b> ignores this parameter if the number that
		/// <i>pNumSubresourceTilings</i> points to is 0.
		/// </para>
		/// </param>
		/// <param name="pSubresourceTilingsForNonPackedMips">
		/// <para>Type: <b><c>D3D12_SUBRESOURCE_TILING</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_SUBRESOURCE_TILING</c> structure that <b>GetResourceTiling</b> fills with info about subresource tiles. If
		/// subresource tiles are part of packed mipmaps, <b>GetResourceTiling</b> sets the members of D3D12_SUBRESOURCE_TILING to zeros,
		/// except the <i>StartTileIndexInOverallResource</i> member, which <b>GetResourceTiling</b> sets to D3D12_PACKED_TILE (0xffffffff).
		/// The D3D12_PACKED_TILE constant indicates that the whole <b>D3D12_SUBRESOURCE_TILING</b> structure is meaningless for this
		/// situation, and the info that the <i>pPackedMipDesc</i> parameter points to applies.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To estimate the total resource size of textures needed when calculating heap sizes and calling <c>CreatePlacedResource</c>, use
		/// <c>GetResourceAllocationInfo</c> instead of <b>GetResourceTiling</b>. <b>GetResourceTiling</b> cannot be used for this.
		/// </para>
		/// <para>For more information on tiled resources, refer to <c>Volume Tiled Resources</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getresourcetiling void GetResourceTiling( [in]
		// ID3D12Resource *pTiledResource, [out, optional] UINT *pNumTilesForEntireResource, [out, optional] D3D12_PACKED_MIP_INFO
		// *pPackedMipDesc, [out, optional] D3D12_TILE_SHAPE *pStandardTileShapeForNonPackedMips, [in, out, optional] UINT
		// *pNumSubresourceTilings, [in] UINT FirstSubresourceTilingToGet, [out] D3D12_SUBRESOURCE_TILING
		// *pSubresourceTilingsForNonPackedMips );
		[PreserveSig]
		new void GetResourceTiling([In] ID3D12Resource pTiledResource, [Out, Optional] StructPointer<uint> pNumTilesForEntireResource,
			[Out, Optional] StructPointer<D3D12_PACKED_MIP_INFO> pPackedMipDesc, [Out, Optional] StructPointer<D3D12_TILE_SHAPE> pStandardTileShapeForNonPackedMips,
			[In, Out, Optional] StructPointer<uint> pNumSubresourceTilings, uint FirstSubresourceTilingToGet,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_TILING[] pSubresourceTilingsForNonPackedMips);

		/// <summary>Gets a locally unique identifier for the current device (adapter).</summary>
		/// <returns>
		/// <para>Type: <b><c>LUID</c></b></para>
		/// <para>The locally unique identifier for the adapter.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method returns a unique identifier for the adapter that is specific to the adapter hardware. Applications can use this
		/// identifier to define robust mappings across various APIs (Direct3D 12, DXGI).
		/// </para>
		/// <para>
		/// A locally unique identifier (LUID) is a 64-bit value that is guaranteed to be unique only on the system on which it was
		/// generated. The uniqueness of a locally unique identifier (LUID) is guaranteed only until the system is restarted.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device-getadapterluid LUID GetAdapterLuid();
		[PreserveSig]
		new LUID GetAdapterLuid();

		/// <summary>
		/// <para>
		/// Creates a cached pipeline library. For pipeline state objects (PSOs) that are expected to share data together, grouping them
		/// into a library before serializing them means that there's less overhead due to metadata, as well as the opportunity to avoid
		/// redundant or duplicated data being written to disk.
		/// </para>
		/// <para>
		/// You can query for <b>ID3D12PipelineLibrary</b> support with <b><c>ID3D12Device::CheckFeatureSupport</c></b>, with
		/// <b><c>D3D12_FEATURE_SHADER_CACHE</c></b> and <b><c>D3D12_FEATURE_DATA_SHADER_CACHE</c></b>. If the Flags member of
		/// <b><c>D3D12_FEATURE_DATA_SHADER_CACHE</c></b> contains the flag <b><c>D3D12_SHADER_CACHE_SUPPORT_LIBRARY</c></b>, the
		/// <b>ID3D12PipelineLibrary</b> interface is supported. If not, then <b>DXGI_ERROR_NOT_SUPPORTED</b> will always be returned when
		/// this function is called.
		/// </para>
		/// </summary>
		/// <param name="pLibraryBlob">
		/// <para>Type: [in] <b>const void*</b></para>
		/// <para>
		/// If the input library blob is empty, then the initial content of the library is empty. If the input library blob is not empty,
		/// then it is validated for integrity, parsed, and the pointer is stored. The pointer provided as input to this method must remain
		/// valid for the lifetime of the object returned. For efficiency reasons, the data is not copied.
		/// </para>
		/// </param>
		/// <param name="BlobLength">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>Specifies the length of pLibraryBlob in bytes.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a unique REFIID for the <c>ID3D12PipelineLibrary</c> object. Typically set this and the following parameter with the
		/// macro <c>IID_PPV_ARGS(&amp;Library)</c>, where <b>Library</b> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineLibrary">
		/// <para>Type: [out] <b>void**</b></para>
		/// <para>Returns a pointer to the created library.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c><b>HRESULT</b></c><c>error code</c>, including
		/// <b>E_INVALIDARG</b> if the blob is corrupted or unrecognized, <b>D3D12_ERROR_DRIVER_VERSION_MISMATCH</b> if the provided data
		/// came from an old driver or runtime, and <b>D3D12_ERROR_ADAPTER_NOT_FOUND</b> if the data came from different hardware.
		/// </para>
		/// <para>
		/// If you pass <c>nullptr</c> for pPipelineLibrary then the runtime still performs the validation of the blob but avoid creating
		/// the actual library and returns S_FALSE if the library would have been created.
		/// </para>
		/// <para>Also, the feature requires an updated driver, and attempting to use it on old drivers will return DXGI_ERROR_UNSUPPORTED.</para>
		/// </returns>
		/// <remarks>
		/// <para>A pipeline library enables the following operations.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Adding pipeline state objects (PSOs) to an existing library object (refer to <c>StorePipeline</c>).</description>
		/// </item>
		/// <item>
		/// <description>Serializing a PSO library into a contiguous block of memory for disk storage (refer to <c>Serialize</c>).</description>
		/// </item>
		/// <item>
		/// <description>De-serializing a PSO library from persistent storage (this is handled by <b>CreatePipelineLibrary</b>).</description>
		/// </item>
		/// <item>
		/// <description>Retrieving individual PSOs from the library (refer to <c>LoadComputePipeline</c> and <c>LoadGraphicsPipeline</c>).</description>
		/// </item>
		/// </list>
		/// <para>At no point in the lifecycle of a pipeline library is there duplication between PSOs with identical sub-components.</para>
		/// <para>
		/// A recommended solution for managing the lifetime of the provided pointer while only having to ref-count the returned interface
		/// is to leverage <c>ID3D12Object::SetPrivateDataInterface</c>, and use an object which implements <b>IUnknown</b>, and frees the
		/// memory when the ref-count reaches 0.
		/// </para>
		/// <para>Thread Safety</para>
		/// <para>
		/// The pipeline library is thread-safe to use, and will internally synchronize as necessary, with one exception: multiple threads
		/// loading the same PSO (via <c><b>LoadComputePipeline</b></c>, <c><b>LoadGraphicsPipeline</b></c>, or <c><b>LoadPipeline</b></c>)
		/// should synchronize themselves, as this act may modify the state of that pipeline within the library in a non-thread-safe manner.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-createpipelinelibrary HRESULT
		// CreatePipelineLibrary( const void *pLibraryBlob, SIZE_T BlobLength, REFIID riid, void **ppPipelineLibrary );
		[PreserveSig]
		new HRESULT CreatePipelineLibrary([In] IntPtr pLibraryBlob, [In] SizeT BlobLength, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppPipelineLibrary);

		/// <summary>Specifies an event that should be fired when one or more of a collection of fences reach specific values.</summary>
		/// <param name="ppFences">
		/// <para>Type: <b>ID3D12Fence*</b></para>
		/// <para>An array of length <i>NumFences</i> that specifies the <c>ID3D12Fence</c> objects.</para>
		/// </param>
		/// <param name="pFenceValues">
		/// <para>Type: <b>const UINT64*</b></para>
		/// <para>An array of length <i>NumFences</i> that specifies the fence values required for the event is to be signaled.</para>
		/// </param>
		/// <param name="NumFences">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of fences to be included.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_MULTIPLE_FENCE_WAIT_FLAGS</c></b></para>
		/// <para>Specifies one of the <c>D3D12_MULTIPLE_FENCE_WAIT_FLAGS</c> that determines how to proceed.</para>
		/// </param>
		/// <param name="hEvent">
		/// <para>Type: <b>HANDLE</b></para>
		/// <para>A handle to the event object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To specify a single fence refer to the <c>SetEventOnCompletion</c> method.</para>
		/// <para>If hEvent is a null handle, then this API will not return until the specified fence value(s) have been reached.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-seteventonmultiplefencecompletion HRESULT
		// SetEventOnMultipleFenceCompletion( [in] ID3D12Fence * const *ppFences, [in] const UINT64 *pFenceValues, UINT NumFences,
		// D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags, HANDLE hEvent );
		[PreserveSig]
		new HRESULT SetEventOnMultipleFenceCompletion([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D12Fence[] ppFences,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[] pFenceValues, int NumFences, D3D12_MULTIPLE_FENCE_WAIT_FLAGS Flags,
			HEVENT hEvent);

		/// <summary>This method sets residency priorities of a specified list of objects.</summary>
		/// <param name="NumObjects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of objects in the <i>ppObjects</i> and <i>pPriorities</i> arrays.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b>ID3D12Pageable*</b></para>
		/// <para>Specifies an array, of length <i>NumObjects</i>, containing references to <c>ID3D12Pageable</c> objects.</para>
		/// </param>
		/// <param name="pPriorities">
		/// <para>Type: <b>const <c>D3D12_RESIDENCY_PRIORITY</c>*</b></para>
		/// <para>Specifies an array, of length <i>NumObjects</i>, of <c>D3D12_RESIDENCY_PRIORITY</c> values for the list of objects.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code.</para>
		/// </returns>
		/// <remarks>For more information, refer to <c>Residency</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device1-setresidencypriority HRESULT
		// SetResidencyPriority( UINT NumObjects, [in] ID3D12Pageable * const *ppObjects, [in] const D3D12_RESIDENCY_PRIORITY *pPriorities );
		[PreserveSig]
		new HRESULT SetResidencyPriority(int NumObjects, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D12Pageable[] ppObjects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESIDENCY_PRIORITY[] pPriorities);

		/// <summary>Creates a pipeline state object from a pipeline state stream description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PIPELINE_STATE_STREAM_DESC</c>*</b></para>
		/// <para>The address of a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> structure that describes the pipeline state.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the pipeline state interface ( <c>ID3D12PipelineState</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the pipeline state can be obtained by using the __uuidof() macro. For
		/// example, __uuidof(ID3D12PipelineState) will get the <b>GUID</b> of the interface to a pipeline state.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12PipelineState</c> interface for the pipeline state object.
		/// </para>
		/// <para>The pipeline state object is an immutable state object. It contains no methods.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the pipeline state object. See <c>Direct3D 12
		/// Return Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function takes the pipeline description as a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> and combines the functionality of the
		/// <c>ID3D12Device::CreateGraphicsPipelineState</c> and <c>ID3D12Device::CreateComputePipelineState</c> functions, which take their
		/// pipeline description as the less-flexible <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> and <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>
		/// structs, respectively.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device2-createpipelinestate HRESULT CreatePipelineState(
		// const D3D12_PIPELINE_STATE_STREAM_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		new HRESULT CreatePipelineState(in D3D12_PIPELINE_STATE_STREAM_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppPipelineState);

		/// <summary>
		/// Creates a special-purpose diagnostic heap in system memory from an address. The created heap can persist even in the event of a
		/// GPU-fault or device-removed scenario.
		/// </summary>
		/// <param name="pAddress">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The address used to create the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the heap interface ( <c>ID3D12Heap</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the heap can be obtained by using the <b>__uuidof()</b> macro. For
		/// example, <b>__uuidof(ID3D12Heap)</b> will retrieve the <b>GUID</b> of the interface to a heap.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block. On success, the D3D12 runtime will write a pointer to the newly-opened heap into the memory block.
		/// The type of the pointer depends on the provided <b>riid</b> parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to open the existing heap. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The heap is created in system memory and permits CPU access. It wraps the entire VirtualAlloc region.</para>
		/// <para>
		/// Heaps can be used for placed and reserved resources, as orthogonally as other heaps. Restrictions may still exist based on the
		/// flags that cannot be app-chosen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-openexistingheapfromaddress HRESULT
		// OpenExistingHeapFromAddress( [in] const void *pAddress, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT OpenExistingHeapFromAddress([In] IntPtr pAddress, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>
		/// Creates a special-purpose diagnostic heap in system memory from a file mapping object. The created heap can persist even in the
		/// event of a GPU-fault or device-removed scenario.
		/// </summary>
		/// <param name="hFileMapping">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>The handle to the file mapping object to use to create the heap.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the heap interface ( <c>ID3D12Heap</c>).</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the heap can be obtained by using the <b>__uuidof()</b> macro. For
		/// example, <b>__uuidof(ID3D12Heap)</b> will retrieve the <b>GUID</b> of the interface to a heap.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>
		/// A pointer to a memory block. On success, the D3D12 runtime will write a pointer to the newly-opened heap into the memory block.
		/// The type of the pointer depends on the provided <b>riid</b> parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to open the existing heap. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The heap is created in system memory, and it permits CPU access. It wraps the entire VirtualAlloc region.</para>
		/// <para>
		/// Heaps can be used for placed and reserved resources, as orthogonally as other heaps. Restrictions may still exist based on the
		/// flags that cannot be app-chosen.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-openexistingheapfromfilemapping HRESULT
		// OpenExistingHeapFromFileMapping( HANDLE hFileMapping, REFIID riid, [out] void **ppvHeap );
		[PreserveSig]
		new HRESULT OpenExistingHeapFromFileMapping([In] IntPtr hFileMapping, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvHeap);

		/// <summary>Asynchronously makes objects resident for the device.</summary>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_RESIDENCY_FLAGS</c></b></para>
		/// <para>Controls whether the objects should be made resident if the application is over its memory budget.</para>
		/// </param>
		/// <param name="NumObjects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of objects in the <i>ppObjects</i> array to make resident for the device.</para>
		/// </param>
		/// <param name="ppObjects">
		/// <para>Type: <b><c>ID3D12Pageable</c>*</b></para>
		/// <para>A pointer to a memory block; contains an array of <c>ID3D12Pageable</c> interface pointers for the objects.</para>
		/// <para>Even though most D3D12 objects inherit from <c>ID3D12Pageable</c>, residency changes are only supported on the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>descriptor heaps</description>
		/// </item>
		/// <item>
		/// <description>heaps</description>
		/// </item>
		/// <item>
		/// <description>committed resources</description>
		/// </item>
		/// <item>
		/// <description>query heaps</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pFenceToSignal">
		/// <para>Type: <b><c>ID3D12Fence</c>*</b></para>
		/// <para>A pointer to the fence used to signal when the work is done.</para>
		/// </param>
		/// <param name="FenceValueToSignal">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>An unsigned 64-bit value signaled to the fence when the work is done.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>EnqueueMakeResident</b> performs the same actions as <c>MakeResident</c>, but does not wait for the resources to be made
		/// resident. Instead, <b>EnqueueMakeResident</b> signals a fence when the work is done.
		/// </para>
		/// <para>
		/// The system will not allow work that references the resources that are being made resident by using <b>EnqueueMakeResident</b>
		/// before its fence is signaled. Instead, calls to this API are guaranteed to signal their corresponding fence in order, so the
		/// same fence can be used from call to call.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device3-enqueuemakeresident HRESULT EnqueueMakeResident(
		// D3D12_RESIDENCY_FLAGS Flags, UINT NumObjects, [in] ID3D12Pageable * const *ppObjects, [in] ID3D12Fence *pFenceToSignal, UINT64
		// FenceValueToSignal );
		[PreserveSig]
		new HRESULT EnqueueMakeResident(D3D12_RESIDENCY_FLAGS Flags, int NumObjects,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D12Pageable[] ppObjects,
			[In] ID3D12Fence pFenceToSignal, ulong FenceValueToSignal);

		/// <summary>Creates a command list in the closed state. Also see <c>ID3D12Device::CreateCommandList</c>.</summary>
		/// <param name="nodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node (the device's
		/// physical adapter) for which to create the command list. Each bit in the mask corresponds to a single node. Only one bit must be
		/// set. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="type">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>Specifies the type of command list to create.</para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_FLAGS</c></b></para>
		/// <para>Specifies creation flags.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the command list interface to return in ppCommandList.</para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12CommandList</c> or <c>ID3D12GraphicsCommandList</c>
		/// interface for the command list.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the command list.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createcommandlist1 HRESULT CreateCommandList1(
		// [in] UINT nodeMask, [in] D3D12_COMMAND_LIST_TYPE type, D3D12_COMMAND_LIST_FLAGS flags, [in] REFIID riid, [out] void
		// **ppCommandList );
		[PreserveSig]
		new HRESULT CreateCommandList1(uint nodeMask, D3D12_COMMAND_LIST_TYPE type, D3D12_COMMAND_LIST_FLAGS flags, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppCommandList);

		/// <summary>
		/// <para>
		/// Creates an object that represents a session for content protection. You can then provide that session when you're creating
		/// resource or heap objects, to indicate that they should be protected.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Memory contents can't be transferred from a protected resource to an unprotected resource.</para>
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_PROTECTED_RESOURCE_SESSION_DESC</b> structure, describing the session to create.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the <c>ID3D12ProtectedResourceSession</c> interface.</para>
		/// </param>
		/// <param name="ppSession">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives an <c>ID3D12ProtectedResourceSession</c> interface pointer to the created session object.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createprotectedresourcesession HRESULT
		// CreateProtectedResourceSession( [in] const D3D12_PROTECTED_RESOURCE_SESSION_DESC *pDesc, [in] REFIID riid, [out] void **ppSession );
		[PreserveSig]
		new HRESULT CreateProtectedResourceSession(in D3D12_PROTECTED_RESOURCE_SESSION_DESC pDesc, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppSession);

		/// <summary>
		/// Creates both a resource and an implicit heap (optionally for a protected session), such that the heap is big enough to contain
		/// the entire resource, and the resource is mapped to the heap. Also see <c>ID3D12Device::CreateCommittedResource</c> for a code example.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createcommittedresource1 HRESULT
		// CreateCommittedResource1( [in] const D3D12_HEAP_PROPERTIES *pHeapProperties, [in] D3D12_HEAP_FLAGS HeapFlags, [in] const
		// D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialResourceState, [in, optional] const D3D12_CLEAR_VALUE
		// *pOptimizedClearValue, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riidResource, [out,
		// optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateCommittedResource1(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object? ppvResource);

		/// <summary>
		/// Creates a heap (optionally for a protected session) that can be used with placed resources and reserved resources. Also see <c>ID3D12Device::CreateHeap</c>.
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_HEAP_DESC</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_HEAP_DESC</b> structure that describes the heap.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// heap should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// <para>A heap with a protected session can't be created with the <c>D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER</c> flag.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the heap interface to return in ppvHeap.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Heap</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvHeap">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created heap object.</para>
		/// <para>
		/// <paramref name="ppvHeap"/> can be <c>nullptr</c>, to enable capability testing. When ppvHeap is <c>nullptr</c>, no object is
		/// created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the heap.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para><b>CreateHeap1</b> creates a heap that can be used with placed resources and reserved resources.</para>
		/// <para>
		/// Before releasing the final reference on the heap, your application must ensure that the GPU will no longer read or write to this heap.
		/// </para>
		/// <para>
		/// A placed resource object holds a reference on the heap it is created on; but a reserved resource doesn't hold a reference for
		/// each mapping made to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createheap1 HRESULT CreateHeap1( [in] const
		// D3D12_HEAP_DESC *pDesc, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riid, [out, optional] void
		// **ppvHeap );
		[PreserveSig]
		new HRESULT CreateHeap1(in D3D12_HEAP_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvHeap);

		/// <summary>
		/// <para>
		/// Creates a resource (optionally for a protected session) that is reserved, and not yet mapped to any pages in a heap. Also see <c>ID3D12Device::CreateReservedResource</c>.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>Only tiles from heaps created with the same protected resource session can be mapped into a protected reserved resource.</para>
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC</b> structure that describes the resource.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/>&gt; specifies a value for which clear operations are most optimal. When the created
		/// resource is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or
		/// <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b> flags, you should choose the value with which the clear operation will most
		/// commonly be called. You can call the clear operation with other values, but those operations won't be as efficient as when the
		/// value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource. See <b>Remarks</b>.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>CreateReservedResource</b> is equivalent to <c>D3D11_RESOURCE_MISC_TILED</c> in Direct3D 11. It creates a resource with
		/// virtual memory only, no backing store.
		/// </para>
		/// <para>You need to map the resource to physical memory (that is, to a heap) using <c>CopyTileMappings</c> and <c>UpdateTileMappings</c>.</para>
		/// <para>
		/// These resource types can only be created when the adapter supports tiled resource tier 1 or greater. The tiled resource tier
		/// defines the behavior of accessing a resource that is not mapped to a heap.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-createreservedresource1 HRESULT
		// CreateReservedResource1( [in] const D3D12_RESOURCE_DESC *pDesc, [in] D3D12_RESOURCE_STATES InitialState, [in, optional] const
		// D3D12_CLEAR_VALUE *pOptimizedClearValue, [in, optional] ID3D12ProtectedResourceSession *pProtectedSession, [in] REFIID riid,
		// [out, optional] void **ppvResource );
		[PreserveSig]
		new HRESULT CreateReservedResource1(in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, [In, Optional] ID3D12ProtectedResourceSession? pProtectedSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppvResource);

		/// <summary>
		/// <para>
		/// Gets rich info about the size and alignment of memory required for a collection of resources on this adapter. Also see <c>ID3D12Device::GetResourceAllocationInfo</c>.
		/// </para>
		/// <para>
		/// In addition to the <c>D3D12_RESOURCE_ALLOCATION_INFO</c> returned from the method, this version also returns an array of
		/// <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, which provide additional details for each resource description passed as
		/// input. See the pResourceAllocationInfo1 parameter.
		/// </para>
		/// </summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array. This is also the size (the number of elements in) pResourceAllocationInfo1.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <param name="pResourceAllocationInfo1">
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO1</c>*</b></para>
		/// <para>
		/// An array of <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, containing additional details for each resource description
		/// passed as input. This makes it simpler for your application to allocate a heap for multiple resources, and without manually
		/// computing offsets for where each resource should be placed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When you're using <c>CreatePlacedResource</c>, your application must use <b>GetResourceAllocationInfo</b> in order to understand
		/// the size and alignment characteristics of texture resources. The results of this method vary depending on the particular
		/// adapter, and must be treated as unique to this adapter and driver version.
		/// </para>
		/// <para>
		/// Your application can't use the output of <b>GetResourceAllocationInfo</b> to understand packed mip properties of textures. To
		/// understand packed mip properties of textures, your application must use <c>GetResourceTiling</c>.
		/// </para>
		/// <para>
		/// Texture resource sizes significantly differ from the information returned by <b>GetResourceTiling</b>, because some adapter
		/// architectures allocate extra memory for textures to reduce the effective bandwidth during common rendering scenarios. This even
		/// includes textures that have constraints on their texture layouts, or have standardized texture layouts. That extra memory can't
		/// be sparsely mapped nor remapped by an application using <c>CreateReservedResource</c> and <c>UpdateTileMappings</c>, so it isn't
		/// reported by <b>GetResourceTiling</b>.
		/// </para>
		/// <para>
		/// Your application can forgo using <b>GetResourceAllocationInfo</b> for buffer resources (
		/// <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>). Buffers have the same size on all adapters, which is merely the smallest multiple of
		/// 64KB that's greater or equal to <c>D3D12_RESOURCE_DESC::Width</c>.
		/// </para>
		/// <para>
		/// When multiple resource descriptions are passed in, the C++ algorithm for calculating a structure size and alignment are used.
		/// For example, a three-element array with two tiny 64KB-aligned resources and a tiny 4MB-aligned resource, reports differing sizes
		/// based on the order of the array. If the 4MB aligned resource is in the middle, then the resulting <b>Size</b> is 12MB.
		/// Otherwise, the resulting <b>Size</b> is 8MB. The <b>Alignment</b> returned would always be 4MB, because it's the superset of all
		/// alignments in the resource array.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device4-getresourceallocationinfo1(uint_uint_constd3d12_resource_desc_d3d12_resource_allocation_info1)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo1( [in] UINT visibleMask, [in] UINT numResourceDescs, [in] const
		// D3D12_RESOURCE_DESC *pResourceDescs, [out] D3D12_RESOURCE_ALLOCATION_INFO1 *pResourceAllocationInfo1 );
		[PreserveSig]
		new D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo1(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_DESC[] pResourceDescs,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_ALLOCATION_INFO1[]? pResourceAllocationInfo1);

		/// <summary>
		/// Creates a lifetime tracker associated with an application-defined callback; the callback receives notifications when the
		/// lifetime of a tracked object is changed.
		/// </summary>
		/// <param name="pOwner">
		/// <para>Type: <b><c>ID3D12LifetimeOwner</c>*</b></para>
		/// <para>A pointer to an <b>ID3D12LifetimeOwner</b> interface representing the application-defined callback.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the interface identifier (IID) of the interface to return in ppvTracker.</para>
		/// </param>
		/// <param name="ppvTracker">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives the requested interface pointer to the created object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createlifetimetracker HRESULT
		// CreateLifetimeTracker( [in] ID3D12LifetimeOwner *pOwner, [in] REFIID riid, [out] void **ppvTracker );
		[PreserveSig]
		new HRESULT CreateLifetimeTracker([In] ID3D12LifetimeOwner pOwner, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvTracker);

		/// <summary>
		/// You can call <b>RemoveDevice</b> to indicate to the Direct3D 12 runtime that the GPU device encountered a problem, and can no
		/// longer be used. Doing so will cause all devices' monitored fences to be signaled. Your application typically doesn't need to
		/// explicitly call <b>RemoveDevice</b>.
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Because device removal triggers all fences to be signaled to <c>UINT64_MAX</c>, you can create a callback for device removal
		/// using an event.
		/// </para>
		/// <para>
		/// <c>HANDLE deviceRemovedEvent = CreateEventW(NULL, FALSE, FALSE, NULL); assert(deviceRemovedEvent != NULL);
		/// _deviceFence-&gt;SetEventOnCompletion(UINT64_MAX, deviceRemoved); HANDLE waitHandle; RegisterWaitForSingleObject(
		/// &amp;waitHandle, deviceRemovedEvent, OnDeviceRemoved, _device.Get(), // Pass the device as our context INFINITE, // No timeout 0
		/// // No flags ); void OnDeviceRemoved(PVOID context, BOOLEAN) { ID3D12Device* removedDevice = (ID3D12Device*)context; HRESULT
		/// removedReason = removedDevice-&gt;GetDeviceRemovedReason(); // Perform app-specific device removed operation, such as logging or
		/// inspecting DRED output }</c>
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-removedevice void RemoveDevice();
		[PreserveSig]
		new void RemoveDevice();

		/// <summary>Queries reflection metadata about available meta commands.</summary>
		/// <param name="pNumMetaCommands">
		/// <para>Type: [in, out] <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a <c>UINT</c> containing the number of meta commands to query for. This field determines the size of the
		/// <i>pDescs</i> array, unless <i>pDescs</i> is <b>nullptr</b>.
		/// </para>
		/// </param>
		/// <param name="pDescs">
		/// <para>Type: [out, optional] <b><c>D3D12_META_COMMAND_DESC</c>*</b></para>
		/// <para>
		/// An optional pointer to an array of <c>D3D12_META_COMMAND_DESC</c> containing the descriptions of the available meta commands.
		/// Pass <c>nullptr</c> to have the number of available meta commands returned in <i>pNumMetaCommands</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-enumeratemetacommands HRESULT
		// EnumerateMetaCommands( UINT *pNumMetaCommands, D3D12_META_COMMAND_DESC *pDescs );
		[PreserveSig]
		new HRESULT EnumerateMetaCommands(ref int pNumMetaCommands, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_META_COMMAND_DESC[]? pDescs);

		/// <summary>Queries reflection metadata about the parameters of the specified meta command.</summary>
		/// <param name="CommandId">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier (GUID) of the meta command whose parameters you wish to be returned in <i>pParameterDescs</i>.</para>
		/// </param>
		/// <param name="Stage">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_STAGE</b></para>
		/// <para>
		/// A <c>D3D12_META_COMMAND_PARAMETER_STAGE</c> specifying the stage of the parameters that you wish to be included in the query.
		/// </para>
		/// </param>
		/// <param name="pTotalStructureSizeInBytes">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// An optional pointer to a <c>UINT</c> containing the size of the structure containing the parameter values, which you pass when
		/// creating/initializing/executing the meta command, as appropriate.
		/// </para>
		/// </param>
		/// <param name="pParameterCount">
		/// <para>Type: <b><c>UINT</c>*</b></para>
		/// <para>
		/// A pointer to a <c>UINT</c> containing the number of parameters to query for. This field determines the size of the
		/// <i>pParameterDescs</i> array, unless <i>pParameterDescs</i> is <b>nullptr</b>.
		/// </para>
		/// </param>
		/// <param name="pParameterDescs">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_DESC*</b></para>
		/// <para>
		/// An optional pointer to an array of <c>D3D12_META_COMMAND_PARAMETER_DESC</c> containing the descriptions of the parameters. Pass
		/// <b>nullptr</b> to have the parameter count returned in <i>pParameterCount</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-enumeratemetacommandparameters HRESULT
		// EnumerateMetaCommandParameters( [in] REFGUID CommandId, [in] D3D12_META_COMMAND_PARAMETER_STAGE Stage, [out, optional] UINT
		// *pTotalStructureSizeInBytes, [in, out] UINT *pParameterCount, [out, optional] D3D12_META_COMMAND_PARAMETER_DESC *pParameterDescs );
		[PreserveSig]
		new HRESULT EnumerateMetaCommandParameters(in Guid CommandId, D3D12_META_COMMAND_PARAMETER_STAGE Stage, out uint pTotalStructureSizeInBytes,
			ref int pParameterCount, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D12_META_COMMAND_PARAMETER_DESC[]? pParameterDescs);

		/// <summary>Creates an instance of the specified meta command.</summary>
		/// <param name="CommandId">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier (GUID) of the meta command that you wish to instantiate.</para>
		/// </param>
		/// <param name="NodeMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the
		/// device's physical adapters) to which the meta command applies. Each bit in the mask corresponds to a single node. Only one bit
		/// must be set. See <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="pCreationParametersData">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>An optional pointer to a constant structure containing the values of the parameters for creating the meta command.</para>
		/// </param>
		/// <param name="CreationParametersDataSizeInBytes">
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>A <c>SIZE_T</c> containing the size of the structure pointed to by <i>pCreationParametersData</i>, if set, otherwise 0.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// A reference to the globally unique identifier (GUID) of the interface that you wish to be returned in <i>ppMetaCommand</i>. This
		/// is expected to be the GUID of <c>ID3D12MetaCommand</c>.
		/// </para>
		/// </param>
		/// <param name="ppMetaCommand">
		/// <para>Type: <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the meta command. This is the address of a pointer to an
		/// <c>ID3D12MetaCommand</c>, representing the meta command created.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>DXGI_ERROR_UNSUPPORTED</description>
		/// <description>The current hardware does not support the algorithm being requested</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createmetacommand HRESULT CreateMetaCommand(
		// [in] REFGUID CommandId, [in] UINT NodeMask, [in, optional] const void *pCreationParametersData, [in] SIZE_T
		// CreationParametersDataSizeInBytes, REFIID riid, [out] void **ppMetaCommand );
		[PreserveSig]
		new HRESULT CreateMetaCommand(in Guid CommandId, uint NodeMask, [In, Optional] IntPtr pCreationParametersData, [In] SizeT CreationParametersDataSizeInBytes,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object ppMetaCommand);

		/// <summary>Creates an <c>ID3D12StateObject</c>.</summary>
		/// <param name="pDesc">The description of the state object to create.</param>
		/// <param name="riid">The GUID of the interface to create. Use <i>__uuidof(ID3D12StateObject)</i>.</param>
		/// <param name="ppStateObject">The returned state object.</param>
		/// <returns>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>E_INVALIDARG if one of the input parameters is invalid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY if sufficient memory is not available to create the handle.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the <c>Direct3D 12 Return Codes</c> topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-createstateobject HRESULT CreateStateObject(
		// [in] const D3D12_STATE_OBJECT_DESC *pDesc, REFIID riid, [out] void **ppStateObject );
		[PreserveSig]
		new HRESULT CreateStateObject(in D3D12_STATE_OBJECT_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppStateObject);

		/// <summary>Query the driver for resource requirements to build an acceleration structure.</summary>
		/// <param name="pDesc">
		/// <para>
		/// Description of the acceleration structure build. This structure is shared with <c>BuildRaytracingAccelerationStructure</c>. For
		/// more information, see <c>D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS</c>.
		/// </para>
		/// <para>
		/// The implementation is allowed to look at all the CPU parameters in this struct and nested structs. It may not
		/// inspect/dereference any GPU virtual addresses, other than to check to see if a pointer is NULL or not, such as the optional
		/// transform in <c>D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC</c>, without dereferencing it. In other words, the calculation of
		/// resource requirements for the acceleration structure does not depend on the actual geometry data (such as vertex positions),
		/// rather it can only depend on overall properties, such as the number of triangles, number of instances etc.
		/// </para>
		/// </param>
		/// <param name="pInfo">The result of the query (in a <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO</c> structure).</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The input acceleration structure description is the same as what goes into <c>BuildRaytracingAccelerationStructure</c>. The
		/// result of this function lets the application provide the correct amount of output storage and scratch storage to
		/// <b>BuildRaytracingAccelerationStructure</b> given the same geometry.
		/// </para>
		/// <para>
		/// Builds can also be done with the same configuration passed to <b>GetAccelerationStructurePrebuildInfo</b> overall except equal
		/// or smaller counts for the number of geometries/instances or the number of vertices/indices/AABBs in any given geometry. In this
		/// case the storage requirements reported with the original sizes passed to <b>GetRaytracingAccelerationStructurePrebuildInfo</b>
		/// will be valid – the build may actually consume less space but not more. This is handy for app scenarios where having
		/// conservatively large storage allocated for acceleration structures is fine.
		/// </para>
		/// <para>
		/// This method is on the device interface as opposed to command list on the assumption that drivers must be able to calculate
		/// resource requirements for an acceleration structure build from only looking at the CPU-visible portions of the call, without
		/// having to dereference any pointers to GPU memory containing actual vertex data, index data, etc.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-getraytracingaccelerationstructureprebuildinfo
		// void GetRaytracingAccelerationStructurePrebuildInfo( [in] const D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS *pDesc,
		// [out] D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO *pInfo );
		[PreserveSig]
		new void GetRaytracingAccelerationStructurePrebuildInfo(in D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS pDesc, out D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO pInfo);

		/// <summary>
		/// Reports the compatibility of serialized data, such as a serialized raytracing acceleration structure resulting from a call to
		/// <c>CopyRaytracingAccelerationStructure</c> with mode <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_COPY_MODE_SERIALIZE</c>, with
		/// the current device/driver.
		/// </summary>
		/// <param name="SerializedDataType">The type of the serialized data. For more information, see <c>D3D12_SERIALIZED_DATA_TYPE</c>.</param>
		/// <param name="pIdentifierToCheck">
		/// Identifier from the header of the serialized data to check with the driver. For more information, see <c>D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER</c>.
		/// </param>
		/// <returns>The returned compatibility status. For more information, see <c>D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device5-checkdrivermatchingidentifier
		// D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS CheckDriverMatchingIdentifier( [in] D3D12_SERIALIZED_DATA_TYPE SerializedDataType, [in]
		// const D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER *pIdentifierToCheck );
		[PreserveSig]
		new D3D12_DRIVER_MATCHING_IDENTIFIER_STATUS CheckDriverMatchingIdentifier(D3D12_SERIALIZED_DATA_TYPE SerializedDataType,
			in D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER pIdentifierToCheck);

		/// <summary>Sets the mode for driver background processing optimizations.</summary>
		/// <param name="Mode">
		/// <para>Type: <b><c>D3D12_BACKGROUND_PROCESSING_MODE</c></b></para>
		/// <para>The level of dynamic optimization to apply to GPU work that's subsequently submitted.</para>
		/// </param>
		/// <param name="MeasurementsAction">
		/// <para>Type: <b><c>D3D12_MEASUREMENTS_ACTION</c></b></para>
		/// <para>The action to take with the results of earlier workload instrumentation.</para>
		/// </param>
		/// <param name="hEventToSignalUponCompletion">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>
		/// An optional handle to signal when the function is complete. For example, if MeasurementsAction is set to
		/// <c>D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS</c>, then hEventToSignalUponCompletion is signaled when all resulting compilations
		/// have finished.
		/// </para>
		/// </param>
		/// <param name="pbFurtherMeasurementsDesired">
		/// <para>Type: <b><c>BOOL</c>*</b></para>
		/// <para>
		/// An optional pointer to a Boolean value. The function sets the value to <c>true</c> to indicate that you should continue
		/// profiling, otherwise, <c>false</c>.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A graphics driver can use idle-priority background CPU threads to dynamically recompile shader programs. That can improve GPU
		/// performance by specializing shader code to better match details of the hardware that it's running on, and/or the context in
		/// which it's being used.
		/// </para>
		/// <para>
		/// As a developer, you don't have to do anything to benefit from this feature (over time, as drivers adopt background processing
		/// optimizations, existing shaders will automatically be tuned more efficiently). But, when you're profiling your code, you'll
		/// probably want to call <b>SetBackgroundProcessingMode</b> to make sure that any driver background processing optimizations have
		/// taken place before you take timing measurements. Here's an example.
		/// </para>
		/// <para>
		/// <c>SetBackgroundProcessingMode( D3D12_BACKGROUND_PROCESSING_MODE_ALLOW_INTRUSIVE_MEASUREMENTS, D3D_MEASUREMENTS_ACTION_KEEP_ALL,
		/// nullptr, nullptr); // Here, prime the system by rendering some typical content. // For example, a level flythrough.
		/// SetBackgroundProcessingMode( D3D12_BACKGROUND_PROCESSING_MODE_ALLOWED, D3D12_MEASUREMENTS_ACTION_COMMIT_RESULTS, nullptr,
		/// nullptr); // Here, continue rendering. This time with dynamic optimizations applied. // And then take your measurements.</c>
		/// </para>
		/// <para>
		/// <c>PIX</c> automatically uses <b>SetBackgroundProcessingMode</b>—first to prime the system,and then to prevent any further
		/// changes from taking place in the middle of its analysis. PIX waits on an event (to make sure all background shader recompiles
		/// have finished) before it starts taking measurements.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device6-setbackgroundprocessingmode HRESULT
		// SetBackgroundProcessingMode( [in] D3D12_BACKGROUND_PROCESSING_MODE Mode, [in] D3D12_MEASUREMENTS_ACTION MeasurementsAction, [in]
		// HANDLE hEventToSignalUponCompletion, [out] BOOL *pbFurtherMeasurementsDesired );
		[PreserveSig]
		new HRESULT SetBackgroundProcessingMode(D3D12_BACKGROUND_PROCESSING_MODE Mode, D3D12_MEASUREMENTS_ACTION MeasurementsAction,
			[In] HEVENT hEventToSignalUponCompletion, out bool pbFurtherMeasurementsDesired);

		/// <summary>
		/// Incrementally add to an existing state object. This incurs lower CPU overhead than creating a state object from scratch that is
		/// a superset of an existing one (for example, adding a few more shaders).
		/// </summary>
		/// <param name="pAddition">
		/// <para>Type: _In_ <b>const <c>D3D12_STATE_OBJECT_DESC</c>*</b></para>
		/// <para>
		/// Description of state object contents to add to existing state object. To help generate this see the
		/// <b>CD3D12_STATE_OBJECT_DESC</b> helper in class in <c>d3dx12.h</c>.
		/// </para>
		/// </param>
		/// <param name="pStateObjectToGrowFrom">
		/// <para>Type: _In_ <b><c>ID3D12StateObject</c>*</b></para>
		/// <para>Existing state object, which can be in use (for example, active raytracing) during this operation.</para>
		/// <para>The existing state object must not be of type <b>Collection</b>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: _In_ <b>REFIID</b></para>
		/// <para>Must be the IID of the <c>ID3D12StateObject</c> interface.</para>
		/// </param>
		/// <param name="ppNewStateObject">
		/// <para>Type: _COM_Outptr_ <b>void**</b></para>
		/// <para>Returned state object.</para>
		/// <para>
		/// Behavior is undefined if shader identifiers are retrieved for new shaders from this call and they are accessed via shader tables
		/// by any already existing or in-flight command list that references some older state object. Use of the new shaders added to the
		/// state object can occur only from commands (such as <b>DispatchRays</b> or <b>ExecuteIndirect</b> calls) recorded in a command
		/// list after the call to <b>AddToStateObject</b>.
		/// </para>
		/// </param>
		/// <returns>
		/// <b>S_OK</b> for success. <b>E_INVALIDARG</b>, <b>E_OUTOFMEMORY</b> on failure. The debug layer provides detailed status information.
		/// </returns>
		/// <remarks>For more info, see <c>AddToStateObject</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device7-addtostateobject HRESULT AddToStateObject( const
		// D3D12_STATE_OBJECT_DESC *pAddition, ID3D12StateObject *pStateObjectToGrowFrom, REFIID riid, void **ppNewStateObject );
		[PreserveSig]
		new HRESULT AddToStateObject(in D3D12_STATE_OBJECT_DESC pAddition, [In] ID3D12StateObject pStateObjectToGrowFrom, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppNewStateObject);

		/// <summary>
		/// <para>
		/// <b>CreateProtectedResourceSession1</b> revises the <c><b>ID3D12Device4::CreateProtectedResourceSession</b></c> method with
		/// provision (in the structure passed via the pDesc parameter) for a globally unique identifier ( <b>GUID</b>) that indicates the
		/// type of protected resource session.
		/// </para>
		/// <para>
		/// Calling <b>ID3D12Device4::CreateProtectedResourceSession</b> is equivalent to calling
		/// <b>ID3D12Device7::CreateProtectedResourceSession1</b> with the <b>D3D12_PROTECTED_RESOURCES_SESSION_HARDWARE_PROTECTED</b> GUID.
		/// </para>
		/// </summary>
		/// <param name="pDesc">
		/// <para>Type: _In_ <b>const <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC1</c>*</b></para>
		/// <para>A pointer to a constant <b>D3D12_PROTECTED_RESOURCE_SESSION_DESC1</b> structure, describing the session to create.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: _In_ <b>REFIID</b></para>
		/// <para>
		/// The GUID of the interface to a protected session. Most commonly, <c>ID3D12ProtectedResourceSession1</c>, although it may be any
		/// <b>GUID</b> for any interface. If the protected session object doesn't support the interface for this <b>GUID</b>, the getter
		/// will return <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppSession">
		/// <para>Type: _COM_Outptr_ <b>void**</b></para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the session for the given protected session (the specific interface type
		/// returned depends on riid).
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device7-createprotectedresourcesession1 HRESULT
		// CreateProtectedResourceSession1( const D3D12_PROTECTED_RESOURCE_SESSION_DESC1 *pDesc, REFIID riid, void **ppSession );
		[PreserveSig]
		new HRESULT CreateProtectedResourceSession1(in D3D12_PROTECTED_RESOURCE_SESSION_DESC1 pDesc, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppSession);

		/// <summary>
		/// <para>
		/// Gets rich info about the size and alignment of memory required for a collection of resources on this adapter. Also see <c>ID3D12Device4::GetResourceAllocationInfo1</c>.
		/// </para>
		/// <para>This version also returns an array of <c>D3D12_RESOURCE_DESC1</c> structures.</para>
		/// </summary>
		/// <param name="visibleMask">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single-GPU operation, set this to zero. If there are multiple GPU nodes, then set bits to identify the nodes (the device's
		/// physical adapters). Each bit in the mask corresponds to a single node. Also see <c>Multi-adapter systems</c>.
		/// </para>
		/// </param>
		/// <param name="numResourceDescs">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of resource descriptors in the pResourceDescs array. This is also the size (the number of elements in) pResourceAllocationInfo1.</para>
		/// </param>
		/// <param name="pResourceDescs">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC1</c>*</b></para>
		/// <para>An array of <b>D3D12_RESOURCE_DESC1</b> structures that described the resources to get info about.</para>
		/// </param>
		/// <param name="pResourceAllocationInfo1">
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO1</c>*</b></para>
		/// <para>
		/// An array of <c>D3D12_RESOURCE_ALLOCATION_INFO1</c> structures, containing additional details for each resource description
		/// passed as input. This makes it simpler for your application to allocate a heap for multiple resources, and without manually
		/// computing offsets for where each resource should be placed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_ALLOCATION_INFO</c></b></para>
		/// <para>
		/// A <c>D3D12_RESOURCE_ALLOCATION_INFO</c> structure that provides info about video memory allocated for the specified array of resources.
		/// </para>
		/// </returns>
		/// <remarks>For remarks, see <c>ID3D12Device4::GetResourceAllocationInfo1</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device8-getresourceallocationinfo2(uint_uint_constd3d12_resource_desc1_d3d12_resource_allocation_info1)
		// D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo2( UINT visibleMask, UINT numResourceDescs, const D3D12_RESOURCE_DESC1
		// *pResourceDescs, D3D12_RESOURCE_ALLOCATION_INFO1 *pResourceAllocationInfo1 );
		[PreserveSig]
		D3D12_RESOURCE_ALLOCATION_INFO GetResourceAllocationInfo2(uint visibleMask, int numResourceDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_DESC1[] pResourceDescs,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_RESOURCE_ALLOCATION_INFO1[] pResourceAllocationInfo1);

		/// <summary>
		/// Creates both a resource and an implicit heap (optionally for a protected session), such that the heap is big enough to contain
		/// the entire resource, and the resource is mapped to the heap. Also see <c>ID3D12Device::CreateCommittedResource</c> for a code example.
		/// </summary>
		/// <param name="pHeapProperties">
		/// <para>Type: _In_ <b>const <c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_HEAP_PROPERTIES</b> structure that provides properties for the resource's heap.</para>
		/// </param>
		/// <param name="HeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c></b></para>
		/// <para>Heap options, as a bitwise-OR'd combination of <b>D3D12_HEAP_FLAGS</b> enumeration constants.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC1</c>*</b></para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC1</b> structure that describes the resource, including a mip region.</para>
		/// </param>
		/// <param name="InitialResourceState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>When you create a resource together with a <c>D3D12_HEAP_TYPE_UPLOAD</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_GENERIC_READ</c>.</para>
		/// <para>
		/// When you create a resource together with a <c>D3D12_HEAP_TYPE_READBACK</c> heap, you must set InitialResourceState to <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: <b>const <c>D3D12_CLEAR_VALUE</c>*</b></para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> structure that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, you should choose the value with which the clear operation will most commonly be called. You can call the clear operation
		/// with other values, but those operations won't be as efficient as when the value matches the one passed in to resource creation.
		/// </para>
		/// <para>When you use <c>D3D12_RESOURCE_DIMENSION_BUFFER</c>, you must set pOptimizedClearValue to <c>nullptr</c>.</para>
		/// </param>
		/// <param name="pProtectedSession">
		/// <para>Type: <b><c>ID3D12ProtectedResourceSession</c>*</b></para>
		/// <para>
		/// An optional pointer to an object that represents a session for content protection. If provided, this session indicates that the
		/// resource should be protected. You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </para>
		/// </param>
		/// <param name="riidResource">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>A reference to the globally unique identifier ( <b>GUID</b>) of the resource interface to return in ppvResource.</para>
		/// <para>
		/// While riidResource is most commonly the <b>GUID</b> of <c>ID3D12Resource</c>, it may be the <b>GUID</b> of any interface. If the
		/// resource object doesn't support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: <b>void**</b></para>
		/// <para>An optional pointer to a memory block that receives the requested interface pointer to the created resource object.</para>
		/// <para>
		/// <paramref name="ppvResource"/> can be <c>nullptr</c>, to enable capability testing. When ppvResource is <c>nullptr</c>, no
		/// object is created, and <b>S_FALSE</b> is returned when pDesc is valid.
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
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the resource.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 return codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates both a resource and a heap, such that the heap is big enough to contain the entire resource, and the
		/// resource is mapped to the heap. The created heap is known as an implicit heap, because the heap object can't be obtained by the
		/// application. Before releasing the final reference on the resource, your application must ensure that the GPU will no longer read
		/// nor write to this resource.
		/// </para>
		/// <para>The implicit heap is made resident for GPU access before the method returns control to your application. Also see <c>Residency</c>.</para>
		/// <para>The resource GPU VA mapping can't be changed. See <c>ID3D12CommandQueue::UpdateTileMappings</c> and <c>Volume tiled resources</c>.</para>
		/// <para>This method may be called by multiple threads concurrently.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device8-createcommittedresource2 HRESULT
		// CreateCommittedResource2( const D3D12_HEAP_PROPERTIES *pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, const D3D12_RESOURCE_DESC1
		// *pDesc, D3D12_RESOURCE_STATES InitialResourceState, const D3D12_CLEAR_VALUE *pOptimizedClearValue, ID3D12ProtectedResourceSession
		// *pProtectedSession, REFIID riidResource, void **ppvResource );
		[PreserveSig]
		HRESULT CreateCommittedResource2(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags, in D3D12_RESOURCE_DESC1 pDesc,
			D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedSession, in Guid riidResource,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 6)] out object? ppvResource);

		/// <summary>
		/// <para>
		/// Creates a resource that is placed in a specific heap. Placed resources are the lightest weight resource objects available, and
		/// are the fastest to create and destroy.
		/// </para>
		/// <para>
		/// Your application can re-use video memory by overlapping multiple Direct3D placed and reserved resources on heap regions. The
		/// simple memory re-use model (described in <c>Remarks</c>) exists to clarify which overlapping resource is valid at any given
		/// time. To maximize graphics tool support, with the simple model data-inheritance isn't supported; and finer-grained tile and
		/// sub-resource invalidation isn't supported. Only full overlapping resource invalidation occurs.
		/// </para>
		/// </summary>
		/// <param name="pHeap">
		/// <para>Type: [in] <b><c>ID3D12Heap</c></b>*</para>
		/// <para>A pointer to the <b>ID3D12Heap</b> interface that represents the heap in which the resource is placed.</para>
		/// </param>
		/// <param name="HeapOffset">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// The offset, in bytes, to the resource. The HeapOffset must be a multiple of the resource's alignment, and HeapOffset plus the
		/// resource size must be smaller than or equal to the heap size. <c><b>GetResourceAllocationInfo</b></c> must be used to understand
		/// the sizes of texture resources.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: [in] <b>const <c>D3D12_RESOURCE_DESC1</c></b>*</para>
		/// <para>A pointer to a <b>D3D12_RESOURCE_DESC1</b> structure that describes the resource, including a mip region.</para>
		/// </param>
		/// <param name="InitialState">
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>The initial state of the resource, as a bitwise-OR'd combination of <b>D3D12_RESOURCE_STATES</b> enumeration constants.</para>
		/// <para>
		/// When a resource is created together with a <b>D3D12_HEAP_TYPE_UPLOAD</b> heap, InitialState must be
		/// <b>D3D12_RESOURCE_STATE_GENERIC_READ</b>. When a resource is created together with a <b>D3D12_HEAP_TYPE_READBACK</b> heap,
		/// InitialState must be <b>D3D12_RESOURCE_STATE_COPY_DEST</b>.
		/// </para>
		/// </param>
		/// <param name="pOptimizedClearValue">
		/// <para>Type: [in, optional] <b>const <c>D3D12_CLEAR_VALUE</c></b>*</para>
		/// <para>Specifies a <b>D3D12_CLEAR_VALUE</b> that describes the default value for a clear color.</para>
		/// <para>
		/// <paramref name="pOptimizedClearValue"/> specifies a value for which clear operations are most optimal. When the created resource
		/// is a texture with either the <b>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</b> or <b>D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL</b>
		/// flags, your application should choose the value that the clear operation will most commonly be called with.
		/// </para>
		/// <para>
		/// Clear operations can be called with other values, but those operations will not be as efficient as when the value matches the
		/// one passed into resource creation.
		/// </para>
		/// <para><paramref name="pOptimizedClearValue"/> must be NULL when used with <b>D3D12_RESOURCE_DIMENSION_BUFFER</b>.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>The globally unique identifier ( <b>GUID</b>) for the resource interface. This is an input parameter.</para>
		/// <para>
		/// The <b>REFIID</b>, or <b>GUID</b>, of the interface to the resource can be obtained by using the <c>__uuidof</c> macro. For
		/// example, <c>__uuidof(ID3D12Resource)</c> gets the <b>GUID</b> of the interface to a resource. Although <b>riid</b> is, most
		/// commonly, the GUID for <c><b>ID3D12Resource</b></c>, it may be any <b>GUID</b> for any interface. If the resource object doesn't
		/// support the interface for this <b>GUID</b>, then creation fails with <b>E_NOINTERFACE</b>.
		/// </para>
		/// </param>
		/// <param name="ppvResource">
		/// <para>Type: [out, optional] <b>void</b>**</para>
		/// <para>
		/// A pointer to a memory block that receives a pointer to the resource. ppvResource can be NULL, to enable capability testing. When
		/// ppvResource is NULL, no object will be created and S_FALSE will be returned when pResourceDesc and other parameters are valid.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if there is insufficient memory to create the resource. See <c>Direct3D 12 Return
		/// Codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>See <c>ID3D12Device::CreatePlacedResource</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device8-createplacedresource1 HRESULT
		// CreatePlacedResource1( ID3D12Heap *pHeap, UINT64 HeapOffset, const D3D12_RESOURCE_DESC1 *pDesc, D3D12_RESOURCE_STATES
		// InitialState, const D3D12_CLEAR_VALUE *pOptimizedClearValue, REFIID riid, void **ppvResource );
		[PreserveSig]
		HRESULT CreatePlacedResource1([In] ID3D12Heap pHeap, ulong HeapOffset, in D3D12_RESOURCE_DESC1 pDesc, D3D12_RESOURCE_STATES InitialState,
			[In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppvResource);

		/// <summary>For purposes of sampler feedback, creates a descriptor suitable for binding.</summary>
		/// <param name="pTargetedResource">
		/// <para>Type: _In_opt_ <b><c>ID3D12Resource</c>*</b></para>
		/// <para>The targeted resource, such as a texture, to create a descriptor for.</para>
		/// </param>
		/// <param name="pFeedbackResource">
		/// <para>Type: _In_opt_ <b><c>ID3D12Resource</c>*</b></para>
		/// <para>The feedback resource, such as a texture, to create a descriptor for.</para>
		/// </param>
		/// <param name="DestDescriptor">
		/// <para>Type: _In_ <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>The CPU descriptor handle.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device8-createsamplerfeedbackunorderedaccessview void
		// CreateSamplerFeedbackUnorderedAccessView( ID3D12Resource *pTargetedResource, ID3D12Resource *pFeedbackResource,
		// D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor );
		[PreserveSig]
		void CreateSamplerFeedbackUnorderedAccessView([In, Optional] ID3D12Resource? pTargetedResource, [In, Optional] ID3D12Resource? pFeedbackResource,
			D3D12_CPU_DESCRIPTOR_HANDLE DestDescriptor);

		/// <summary>
		/// Gets a resource layout that can be copied. Helps your app fill in <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> and
		/// <c>D3D12_SUBRESOURCE_FOOTPRINT</c> when suballocating space in upload heaps.
		/// </summary>
		/// <param name="pResourceDesc">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_DESC1</c>*</b></para>
		/// <para>A description of the resource, as a pointer to a <b>D3D12_RESOURCE_DESC1</b> structure.</para>
		/// </param>
		/// <param name="FirstSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>Index of the first subresource in the resource. The range of valid values is 0 to D3D12_REQ_SUBRESOURCES.</para>
		/// </param>
		/// <param name="NumSubresources">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of subresources in the resource. The range of valid values is 0 to (D3D12_REQ_SUBRESOURCES - <i>FirstSubresource</i>).</para>
		/// </param>
		/// <param name="BaseOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset, in bytes, to the resource.</para>
		/// </param>
		/// <param name="pLayouts">
		/// <para>Type: [out, optional] <b><c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structures, to be filled
		/// with the description and placement of each subresource.
		/// </para>
		/// </param>
		/// <param name="pNumRows">
		/// <para>Type: [out, optional] <b>UINT*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, to be filled with the number of rows for each subresource.
		/// </para>
		/// </param>
		/// <param name="pRowSizeInBytes">
		/// <para>Type: [out, optional] <b>UINT64*</b></para>
		/// <para>
		/// A pointer to an array (of length <i>NumSubresources</i>) of integer variables, each entry to be filled with the unpadded size in
		/// bytes of a row, of each subresource.
		/// </para>
		/// <para>For example, if a Texture2D resource has a width of 32 and bytes per pixel of 4, then <i>pRowSizeInBytes</i> returns 128.</para>
		/// <para>
		/// <i>pRowSizeInBytes</i> should not be confused with <b>row pitch</b>, as examining <i>pLayouts</i> and getting the row pitch from
		/// that will give you 256 as it is aligned to D3D12_TEXTURE_DATA_PITCH_ALIGNMENT.
		/// </para>
		/// </param>
		/// <param name="pTotalBytes">
		/// <para>Type: [out, optional] <b>UINT64*</b></para>
		/// <para>A pointer to an integer variable, to be filled with the total size, in bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>For remarks and examples, see <c>ID3D12Device::GetCopyableFootprints</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12device8-getcopyablefootprints1 void
		// GetCopyableFootprints1( const D3D12_RESOURCE_DESC1 *pResourceDesc, UINT FirstSubresource, UINT NumSubresources, UINT64
		// BaseOffset, D3D12_PLACED_SUBRESOURCE_FOOTPRINT *pLayouts, UINT *pNumRows, UINT64 *pRowSizeInBytes, UINT64 *pTotalBytes );
		[PreserveSig]
		void GetCopyableFootprints1(in D3D12_RESOURCE_DESC1 pResourceDesc, uint FirstSubresource, int NumSubresources, ulong BaseOffset,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_PLACED_SUBRESOURCE_FOOTPRINT[]? pLayouts,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[]? pNumRows,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ulong[]? pRowSizeInBytes, out ulong pTotalBytes);
	}

	/// <summary>
	/// Incrementally add to an existing state object. This incurs lower CPU overhead than creating a state object from scratch that is
	/// a superset of an existing one (for example, adding a few more shaders).
	/// </summary>
	/// <param name="dev">The <see cref="ID3D12Device5"/> instance.</param>
	/// <param name="pAddition">
	/// <para>
	/// Description of state object contents to add to existing state object. To help generate this see the
	/// <b>CD3D12_STATE_OBJECT_DESC</b> helper in class in <c>d3dx12.h</c>.
	/// </para>
	/// </param>
	/// <param name="pStateObjectToGrowFrom">
	/// <para>Existing state object, which can be in use (for example, active raytracing) during this operation.</para>
	/// <para>The existing state object must not be of type <b>Collection</b>.</para>
	/// </param>
	/// <param name="ppNewStateObject">
	/// <para>Returned state object.</para>
	/// <para>
	/// Behavior is undefined if shader identifiers are retrieved for new shaders from this call and they are accessed via shader tables
	/// by any already existing or in-flight command list that references some older state object. Use of the new shaders added to the
	/// state object can occur only from commands (such as <b>DispatchRays</b> or <b>ExecuteIndirect</b> calls) recorded in a command
	/// list after the call to <b>AddToStateObject</b>.
	/// </para>
	/// </param>
	/// <returns>
	/// <b>S_OK</b> for success. <b>E_INVALIDARG</b>, <b>E_OUTOFMEMORY</b> on failure. The debug layer provides detailed status information.
	/// </returns>
	/// <remarks>For more info, see <c>AddToStateObject</c>.</remarks>
	public static HRESULT AddToStateObject(this ID3D12Device7 dev, [In] D3D12_STATE_OBJECT_DESC_MGD pAddition, [In] ID3D12StateObject pStateObjectToGrowFrom,
		out ID3D12StateObject? ppNewStateObject)
	{
		var hr = dev.AddToStateObject(pAddition.GetUnmanaged(out var mem), pStateObjectToGrowFrom, typeof(ID3D12StateObject).GUID, out var ppv);
		ppNewStateObject = hr.Failed ? null : (ID3D12StateObject)ppv!;
		mem.Dispose();
		return hr;
	}
}