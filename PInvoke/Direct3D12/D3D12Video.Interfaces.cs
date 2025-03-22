namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>Encapsulates a list of graphics commands for video decoding. This interface is inherited by <c>ID3D12VideoDecodeCommandList1</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecodecommandlist
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecodeCommandList")]
	[ComImport, Guid("3b60536e-ad29-4e64-a269-f853837e5e53"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecodeCommandList : ID3D12CommandList
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-close HRESULT Close();
		[PreserveSig]
		HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-clearstate void ClearState();
		[PreserveSig]
		void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		void ResourceBarrier(int NumBarriers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		void DiscardResource([In] ID3D12Resource pResource, [Optional] in D3D12_DISCARD_REGION pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		void SetPredication([In] ID3D12Resource pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		void SetMarker(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		void BeginEvent(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endevent void EndEvent();
		[PreserveSig]
		void EndEvent();

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The <c>ID3D12VideoDecodeCommandList1::DecodeFrame1</c> method provides the same functionality as this method, but adds support
		/// for decode histograms.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-decodeframe void
		// DecodeFrame( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		void DecodeFrame([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);
	}

	/// <summary>
	/// Encapsulates a list of graphics commands for video decoding. This interface inherits from <c>ID3D12VideoDecodeCommandList</c> and
	/// adds support for video decode histograms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecodecommandlist1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecodeCommandList1")]
	[ComImport, Guid("d52f011b-b56e-453c-a05a-a7f311c8f472"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecodeCommandList1 : ID3D12VideoDecodeCommandList
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [Optional] in D3D12_DISCARD_REGION pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In] ID3D12Resource pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The <c>ID3D12VideoDecodeCommandList1::DecodeFrame1</c> method provides the same functionality as this method, but adds support
		/// for decode histograms.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-decodeframe void
		// DecodeFrame( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void DecodeFrame([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method. Takes a <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure to support video decode histograms.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist1-decodeframe1 void
		// DecodeFrame1( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		void DecodeFrame1([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);
	}

	/// <summary>
	/// Encapsulates a list of graphics commands for video decoding. This interface inherits from <c>ID3D12VideoDecodeCommandList1</c> and
	/// adds support for video extension commands.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecodecommandlist2
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecodeCommandList2")]
	[ComImport, Guid("6e120880-c114-4153-8036-d247051e1729"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecodeCommandList2 : ID3D12VideoDecodeCommandList1
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [Optional] in D3D12_DISCARD_REGION pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In] ID3D12Resource pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The <c>ID3D12VideoDecodeCommandList1::DecodeFrame1</c> method provides the same functionality as this method, but adds support
		/// for decode histograms.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-decodeframe void
		// DecodeFrame( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void DecodeFrame([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method. Takes a <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure to support video decode histograms.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist1-decodeframe1 void
		// DecodeFrame1( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void DecodeFrame1([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the video decode command list. By
		/// default, no protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected
		/// resources of the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no
		/// protected resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist2-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		void SetProtectedResourceSession([In] ID3D12ProtectedResourceSession pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video decode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist2-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters, SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into a decode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist2-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters, SizeT ExecutionParametersSizeInBytes);
	}

	/// <summary>
	/// <para>
	/// Encapsulates a list of graphics commands for video decoding. This interface derives from <c>ID3D12VideoDecodeCommandList2</c>, and
	/// adds support for barriers.
	/// </para>
	/// <para>Requires the DirectX 12 Agility SDK 1.7 or later.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecodecommandlist3
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecodeCommandList3")]
	[ComImport, Guid("2aee8c37-9562-42da-8abf-61efeb2e4513"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecodeCommandList3 : ID3D12VideoDecodeCommandList2
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [Optional] in D3D12_DISCARD_REGION pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In] ID3D12Resource pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The <c>ID3D12VideoDecodeCommandList1::DecodeFrame1</c> method provides the same functionality as this method, but adds support
		/// for decode histograms.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-decodeframe void
		// DecodeFrame( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void DecodeFrame([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Records a decode frame operation to the command list. Inputs, outputs, and parameters for the decode are specified as arguments
		/// to this method. Takes a <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure to support video decode histograms.
		/// </summary>
		/// <param name="pDecoder">A pointer to an <c>ID3D12VideoDecoder</c> interface representing a decoder instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS</c> structure specifying the input bitstream, reference frames, and other input parameters.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist1-decodeframe1 void
		// DecodeFrame1( ID3D12VideoDecoder *pDecoder, const D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 *pOutputArguments, const
		// D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void DecodeFrame1([In] ID3D12VideoDecoder pDecoder, in D3D12_VIDEO_DECODE_OUTPUT_STREAM_ARGUMENTS1 pOutputArguments, in D3D12_VIDEO_DECODE_INPUT_STREAM_ARGUMENTS pInputArguments);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the video decode command list. By
		/// default, no protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected
		/// resources of the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no
		/// protected resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist2-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		new void SetProtectedResourceSession([In] ID3D12ProtectedResourceSession pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video decode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist2-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		new void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters, SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into a decode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist2-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		new void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters, SizeT ExecutionParametersSizeInBytes);

		/// <summary>
		/// <para>Adds a collection of barriers into a video decode command list recording.</para>
		/// <para>Requires the DirectX 12 Agility SDK 1.7 or later.</para>
		/// </summary>
		/// <param name="NumBarrierGroups">Number of barrier groups pointed to by pBarrierGroups.</param>
		/// <param name="pBarrierGroups">Pointer to an array of <c>D3D12_BARRIER_GROUP</c> objects.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecodecommandlist3-barrier void Barrier(
		// UINT32 NumBarrierGroups, const D3D12_BARRIER_GROUP *pBarrierGroups );
		[PreserveSig]
		void Barrier(int NumBarrierGroups, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_BARRIER_GROUP[] pBarrierGroups);
	}

	/// <summary>
	/// Represents a Direct3D 12 video decoder that contains resolution-independent resources and state for performing the decode operation.
	/// </summary>
	/// <remarks>
	/// <para>Get an instance of this class by calling <c>ID3D12VideoDevice::CreateVideoDecoder</c>.</para>
	/// <para>It is not necessary to recreate this object during a resolution change.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecoder
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecoder")]
	[ComImport, Guid("c59b6bdc-7720-4074-a136-17a156037470"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecoder : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>
		/// Gets the <c>D3D12_VIDEO_DECODER_DESC</c> structure that was passed into <c>ID3D12VideoDevice::CreateVideoDecoder</c> when the
		/// <c>ID3D12VideoDecoder</c> was created.
		/// </summary>
		/// <returns>This method returns a <b>D3D12_VIDEO_DECODER_DESC</b> structure.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecoder-getdesc D3D12_VIDEO_DECODER_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_VIDEO_DECODER_DESC size);
	}

	/// <summary>
	/// Represents a Direct3D 12 video decoder that contains resolution-independent resources and state for performing the decode operation.
	/// Inherits from <c>ID3D12VideoDecoder</c> and adds support for protected resources.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecoder1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecoder1")]
	[ComImport, Guid("79a2e5fb-ccd2-469a-9fde-195d10951f7e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecoder1 : ID3D12VideoDecoder
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>
		/// Gets the <c>D3D12_VIDEO_DECODER_DESC</c> structure that was passed into <c>ID3D12VideoDevice::CreateVideoDecoder</c> when the
		/// <c>ID3D12VideoDecoder</c> was created.
		/// </summary>
		/// <returns>This method returns a <b>D3D12_VIDEO_DECODER_DESC</b> structure.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecoder-getdesc D3D12_VIDEO_DECODER_DESC GetDesc();
		[PreserveSig]
		new void GetDesc(out D3D12_VIDEO_DECODER_DESC size);

		/// <summary>
		/// Gets the <c>ID3D12ProtectedResourceSession</c> that was passed into <c>ID3D12VideoDevice2::CreateVideoDecoder1</c> when the
		/// <c>ID3D12VideoDecoder1</c> was created.
		/// </summary>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <param name="ppProtectedSession">Receives a void pointer representing the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecoder1-getprotectedresourcesession
		// HRESULT GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>
	/// Represents a Direct3D 12 video decoder heap that contains resolution-dependent resources and state for performing the decode operation.
	/// </summary>
	/// <remarks>Get an instance of this class by calling <c>ID3D12VideoDevice::CreateVideoDecoderHeap</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecoderheap
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecoderHeap")]
	[ComImport, Guid("0946b7c9-ebf6-4047-bb73-8683e27dbb1f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecoderHeap : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>
		/// Gets the <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> structure that was passed into <c>ID3D12VideoDevice::CreateVideoDecoderHeap</c>
		/// when the <c>ID3D12VideoDecoderHeap</c> was created.
		/// </summary>
		/// <returns>This method returns a <b>D3D12_VIDEO_DECODER_HEAP_DESC</b> structure.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecoderheap-getdesc
		// D3D12_VIDEO_DECODER_HEAP_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_VIDEO_DECODER_HEAP_DESC size);
	}

	/// <summary>ID3D12VideoDecoderHeap1 inherits from <c>ID3D12VideoDecoderHeap</c> and introduces support for protected resources.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodecoderheap1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDecoderHeap1")]
	[ComImport, Guid("da1d98c5-539f-41b2-bf6b-1198a03b6d26"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDecoderHeap1 : ID3D12VideoDecoderHeap
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>
		/// Gets the <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> structure that was passed into <c>ID3D12VideoDevice::CreateVideoDecoderHeap</c>
		/// when the <c>ID3D12VideoDecoderHeap</c> was created.
		/// </summary>
		/// <returns>This method returns a <b>D3D12_VIDEO_DECODER_HEAP_DESC</b> structure.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecoderheap-getdesc
		// D3D12_VIDEO_DECODER_HEAP_DESC GetDesc();
		[PreserveSig]
		new void GetDesc(out D3D12_VIDEO_DECODER_HEAP_DESC size);

		/// <summary>
		/// Gets the <c>ID3D12ProtectedResourceSession</c> that was passed into <c>ID3D12VideoDevice2::CreateVideoDecoderHeap1</c> when the
		/// <c>ID3D12VideoDecoderHeap1</c> was created.
		/// </summary>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <param name="ppProtectedSession">Receives a void pointer representing the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodecoderheap1-getprotectedresourcesession
		// HRESULT GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>
	/// Provides video decoding and processing capabilities of a Microsoft Direct3D 12 device including the ability to query video
	/// capabilities and instantiating video decoders and processors.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodevice
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDevice")]
	[ComImport, Guid("1f052807-0b46-4acc-8a89-364f793718a4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDevice
	{
		/// <summary>Gets information about the features that are supported by the current video driver.</summary>
		/// <param name="FeatureVideo">A member of the <c>D3D12_FEATURE_VIDEO</c> enumeration that specifies the feature to query for support.</param>
		/// <param name="pFeatureSupportData">
		/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon
		/// the completion of the call, is populated with details about the level of support available. For information on the structure
		/// that is associated with each type of feature support request, see the field descriptions for <c>D3D12_FEATURE_VIDEO</c>.
		/// </param>
		/// <param name="FeatureSupportDataSize">The size of the structure passed to the pFeatureSupportData parameter.</param>
		/// <returns>
		/// Returns <b>S_OK</b> if successful; otherwise, returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-checkfeaturesupport HRESULT
		// CheckFeatureSupport( D3D12_FEATURE_VIDEO FeatureVideo, void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		HRESULT CheckFeatureSupport(D3D12_FEATURE_VIDEO FeatureVideo, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a video decoder instance that contains the resolution-independent driver resources and state.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_DECODER_DESC</c> structure describing the decode profile and bitstream encryption for the decoder.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoder">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoder</c> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>Decoding a new stream requires instantiating a new decoder object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoder HRESULT
		// CreateVideoDecoder( const D3D12_VIDEO_DECODER_DESC *pDesc, REFIID riid, void **ppVideoDecoder );
		[PreserveSig]
		HRESULT CreateVideoDecoder(in D3D12_VIDEO_DECODER_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoder);

		/// <summary>Allocates a video decoder heap that contains the resolution-dependent driver resources and state.</summary>
		/// <param name="pVideoDecoderHeapDesc">A pointer to a <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing the decoding configuration.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoderHeap">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoderHeap</c> interface.</param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoderheap HRESULT
		// CreateVideoDecoderHeap( const D3D12_VIDEO_DECODER_HEAP_DESC *pVideoDecoderHeapDesc, REFIID riid, void **ppVideoDecoderHeap );
		[PreserveSig]
		HRESULT CreateVideoDecoderHeap(in D3D12_VIDEO_DECODER_HEAP_DESC pVideoDecoderHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoderHeap);

		/// <summary>Creates a video processor instance.</summary>
		/// <param name="NodeMask">
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </param>
		/// <param name="pOutputStreamDesc">
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </param>
		/// <param name="NumInputStreamDescs">The number of input streams provided in the pInputStreamDescs parameter.</param>
		/// <param name="pInputStreamDescs">
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams. The number of structures provided should match the value specified in the NumInputStreamDescs parameter.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the video processor interface.</param>
		/// <param name="ppVideoProcessor">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoProcessor</c> interface</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>To change the parameters set during creation, you must recreate the video processor object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideoprocessor HRESULT
		// CreateVideoProcessor( UINT NodeMask, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc, UINT NumInputStreamDescs,
		// const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs, REFIID riid, void **ppVideoProcessor );
		[PreserveSig]
		HRESULT CreateVideoProcessor(uint NodeMask, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC pOutputStreamDesc, int NumInputStreamDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppVideoProcessor);
	}

	/// <summary>
	/// Provides video decoding and processing capabilities of a Microsoft Direct3D 12 device including the ability to query video
	/// capabilities and instantiating video decoders and processors. This interface adds support for motion estimation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodevice1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDevice1")]
	[ComImport, Guid("981611ad-a144-4c83-9890-f30e26d658ab"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDevice1 : ID3D12VideoDevice
	{
		/// <summary>Gets information about the features that are supported by the current video driver.</summary>
		/// <param name="FeatureVideo">A member of the <c>D3D12_FEATURE_VIDEO</c> enumeration that specifies the feature to query for support.</param>
		/// <param name="pFeatureSupportData">
		/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon
		/// the completion of the call, is populated with details about the level of support available. For information on the structure
		/// that is associated with each type of feature support request, see the field descriptions for <c>D3D12_FEATURE_VIDEO</c>.
		/// </param>
		/// <param name="FeatureSupportDataSize">The size of the structure passed to the pFeatureSupportData parameter.</param>
		/// <returns>
		/// Returns <b>S_OK</b> if successful; otherwise, returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-checkfeaturesupport HRESULT
		// CheckFeatureSupport( D3D12_FEATURE_VIDEO FeatureVideo, void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D12_FEATURE_VIDEO FeatureVideo, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a video decoder instance that contains the resolution-independent driver resources and state.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_DECODER_DESC</c> structure describing the decode profile and bitstream encryption for the decoder.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoder">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoder</c> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>Decoding a new stream requires instantiating a new decoder object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoder HRESULT
		// CreateVideoDecoder( const D3D12_VIDEO_DECODER_DESC *pDesc, REFIID riid, void **ppVideoDecoder );
		[PreserveSig]
		new HRESULT CreateVideoDecoder(in D3D12_VIDEO_DECODER_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoder);

		/// <summary>Allocates a video decoder heap that contains the resolution-dependent driver resources and state.</summary>
		/// <param name="pVideoDecoderHeapDesc">A pointer to a <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing the decoding configuration.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoderHeap">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoderHeap</c> interface.</param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoderheap HRESULT
		// CreateVideoDecoderHeap( const D3D12_VIDEO_DECODER_HEAP_DESC *pVideoDecoderHeapDesc, REFIID riid, void **ppVideoDecoderHeap );
		[PreserveSig]
		new HRESULT CreateVideoDecoderHeap(in D3D12_VIDEO_DECODER_HEAP_DESC pVideoDecoderHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoderHeap);

		/// <summary>Creates a video processor instance.</summary>
		/// <param name="NodeMask">
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </param>
		/// <param name="pOutputStreamDesc">
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </param>
		/// <param name="NumInputStreamDescs">The number of input streams provided in the pInputStreamDescs parameter.</param>
		/// <param name="pInputStreamDescs">
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams. The number of structures provided should match the value specified in the NumInputStreamDescs parameter.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the video processor interface.</param>
		/// <param name="ppVideoProcessor">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoProcessor</c> interface</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>To change the parameters set during creation, you must recreate the video processor object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideoprocessor HRESULT
		// CreateVideoProcessor( UINT NodeMask, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc, UINT NumInputStreamDescs,
		// const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs, REFIID riid, void **ppVideoProcessor );
		[PreserveSig]
		new HRESULT CreateVideoProcessor(uint NodeMask, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC pOutputStreamDesc, int NumInputStreamDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppVideoProcessor);

		/// <summary>Creates an <c>ID3D12VideoMotionEstimator</c>, which maintains context for video motion estimation operations.</summary>
		/// <param name="pDesc">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</c> describing the parameters used for motion estimation. This structure contains both
		/// input and output fields.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12VideoMotionEstimator</b> interface.</param>
		/// <param name="ppVideoMotionEstimator">
		/// A pointer to a memory block that receives a pointer to the <b>ID3D12VideoMotionEstimator</b> interface.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice1-createvideomotionestimator
		// HRESULT CreateVideoMotionEstimator( const D3D12_VIDEO_MOTION_ESTIMATOR_DESC *pDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoMotionEstimator );
		[PreserveSig]
		HRESULT CreateVideoMotionEstimator(in D3D12_VIDEO_MOTION_ESTIMATOR_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoMotionEstimator);

		/// <summary>Allocates heap that contains motion vectors for video motion estimation.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC</c> describing the format of the heap. This structure contains both input
		/// and output fields.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12VideoMotionVectorHeap</b> interface.</param>
		/// <param name="ppVideoMotionVectorHeap">
		/// A pointer to a memory block that receives a pointer to the <b>ID3D12VideoMotionVectorHeap</b> interface.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice1-createvideomotionvectorheap
		// HRESULT CreateVideoMotionVectorHeap( const D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC *pDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoMotionVectorHeap );
		[PreserveSig]
		HRESULT CreateVideoMotionVectorHeap(in D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC pDesc, [In] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoMotionVectorHeap);
	}

	/// <summary>
	/// Provides video decoding and processing capabilities of a Microsoft Direct3D 12 device including the ability to query video
	/// capabilities and instantiating video decoders and processors. This interface adds support for protected resources and video
	/// extension commands.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodevice2
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDevice2")]
	[ComImport, Guid("f019ac49-f838-4a95-9b17-579437c8f513"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDevice2 : ID3D12VideoDevice1
	{
		/// <summary>Gets information about the features that are supported by the current video driver.</summary>
		/// <param name="FeatureVideo">A member of the <c>D3D12_FEATURE_VIDEO</c> enumeration that specifies the feature to query for support.</param>
		/// <param name="pFeatureSupportData">
		/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon
		/// the completion of the call, is populated with details about the level of support available. For information on the structure
		/// that is associated with each type of feature support request, see the field descriptions for <c>D3D12_FEATURE_VIDEO</c>.
		/// </param>
		/// <param name="FeatureSupportDataSize">The size of the structure passed to the pFeatureSupportData parameter.</param>
		/// <returns>
		/// Returns <b>S_OK</b> if successful; otherwise, returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-checkfeaturesupport HRESULT
		// CheckFeatureSupport( D3D12_FEATURE_VIDEO FeatureVideo, void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D12_FEATURE_VIDEO FeatureVideo, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a video decoder instance that contains the resolution-independent driver resources and state.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_DECODER_DESC</c> structure describing the decode profile and bitstream encryption for the decoder.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoder">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoder</c> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>Decoding a new stream requires instantiating a new decoder object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoder HRESULT
		// CreateVideoDecoder( const D3D12_VIDEO_DECODER_DESC *pDesc, REFIID riid, void **ppVideoDecoder );
		[PreserveSig]
		new HRESULT CreateVideoDecoder(in D3D12_VIDEO_DECODER_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoder);

		/// <summary>Allocates a video decoder heap that contains the resolution-dependent driver resources and state.</summary>
		/// <param name="pVideoDecoderHeapDesc">A pointer to a <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing the decoding configuration.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoderHeap">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoderHeap</c> interface.</param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoderheap HRESULT
		// CreateVideoDecoderHeap( const D3D12_VIDEO_DECODER_HEAP_DESC *pVideoDecoderHeapDesc, REFIID riid, void **ppVideoDecoderHeap );
		[PreserveSig]
		new HRESULT CreateVideoDecoderHeap(in D3D12_VIDEO_DECODER_HEAP_DESC pVideoDecoderHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoderHeap);

		/// <summary>Creates a video processor instance.</summary>
		/// <param name="NodeMask">
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </param>
		/// <param name="pOutputStreamDesc">
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </param>
		/// <param name="NumInputStreamDescs">The number of input streams provided in the pInputStreamDescs parameter.</param>
		/// <param name="pInputStreamDescs">
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams. The number of structures provided should match the value specified in the NumInputStreamDescs parameter.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the video processor interface.</param>
		/// <param name="ppVideoProcessor">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoProcessor</c> interface</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>To change the parameters set during creation, you must recreate the video processor object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideoprocessor HRESULT
		// CreateVideoProcessor( UINT NodeMask, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc, UINT NumInputStreamDescs,
		// const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs, REFIID riid, void **ppVideoProcessor );
		[PreserveSig]
		new HRESULT CreateVideoProcessor(uint NodeMask, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC pOutputStreamDesc, int NumInputStreamDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppVideoProcessor);

		/// <summary>Creates an <c>ID3D12VideoMotionEstimator</c>, which maintains context for video motion estimation operations.</summary>
		/// <param name="pDesc">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</c> describing the parameters used for motion estimation. This structure contains both
		/// input and output fields.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12VideoMotionEstimator</b> interface.</param>
		/// <param name="ppVideoMotionEstimator">
		/// A pointer to a memory block that receives a pointer to the <b>ID3D12VideoMotionEstimator</b> interface.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice1-createvideomotionestimator
		// HRESULT CreateVideoMotionEstimator( const D3D12_VIDEO_MOTION_ESTIMATOR_DESC *pDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoMotionEstimator );
		[PreserveSig]
		new HRESULT CreateVideoMotionEstimator(in D3D12_VIDEO_MOTION_ESTIMATOR_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoMotionEstimator);

		/// <summary>Allocates heap that contains motion vectors for video motion estimation.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC</c> describing the format of the heap. This structure contains both input
		/// and output fields.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12VideoMotionVectorHeap</b> interface.</param>
		/// <param name="ppVideoMotionVectorHeap">
		/// A pointer to a memory block that receives a pointer to the <b>ID3D12VideoMotionVectorHeap</b> interface.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice1-createvideomotionvectorheap
		// HRESULT CreateVideoMotionVectorHeap( const D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC *pDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoMotionVectorHeap );
		[PreserveSig]
		new HRESULT CreateVideoMotionVectorHeap(in D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC pDesc, [In] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoMotionVectorHeap);

		/// <summary>
		/// Creates a video decoder instance that contains the resolution-independent driver resources and state, with support for protected resources.
		/// </summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_DECODER_DESC</c> structure describing the decode profile and bitstream encryption for the decoder.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoder">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoder1</c> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>Decoding a new stream requires instantiating a new decoder object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideodecoder1 HRESULT
		// CreateVideoDecoder1( const D3D12_VIDEO_DECODER_DESC *pDesc, ID3D12ProtectedResourceSession *pProtectedResourceSession, REFIID
		// riid, void **ppVideoDecoder );
		[PreserveSig]
		HRESULT CreateVideoDecoder1(in D3D12_VIDEO_DECODER_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoDecoder);

		/// <summary>
		/// Allocates a video decoder heap that contains the resolution-dependent driver resources and state, with support for protected resources.
		/// </summary>
		/// <param name="pVideoDecoderHeapDesc">A pointer to a <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing the decoding configuration.</param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoderHeap">
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoderHeap1</c> interface.
		/// </param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideodecoderheap1 HRESULT
		// CreateVideoDecoderHeap1( const D3D12_VIDEO_DECODER_HEAP_DESC *pVideoDecoderHeapDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoDecoderHeap );
		[PreserveSig]
		HRESULT CreateVideoDecoderHeap1(in D3D12_VIDEO_DECODER_HEAP_DESC pVideoDecoderHeapDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoDecoderHeap);

		/// <summary>Creates a video processor instance with support for protected resources.</summary>
		/// <param name="NodeMask">
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </param>
		/// <param name="pOutputStreamDesc">
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </param>
		/// <param name="NumInputStreamDescs">The number of input streams provided in the pInputStreamDescs parameter.</param>
		/// <param name="pInputStreamDescs">
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams. The number of structures provided should match the value specified in the NumInputStreamDescs parameter.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the video processor interface.</param>
		/// <param name="ppVideoProcessor">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoProcessor1</c> interface</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>To change the parameters set during creation, you must recreate the video processor object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideoprocessor1 HRESULT
		// CreateVideoProcessor1( UINT NodeMask, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc, UINT NumInputStreamDescs,
		// const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs, ID3D12ProtectedResourceSession *pProtectedResourceSession, REFIID
		// riid, void **ppVideoProcessor );
		[PreserveSig]
		HRESULT CreateVideoProcessor1(uint NodeMask, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC pOutputStreamDesc, int NumInputStreamDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppVideoProcessor);

		/// <summary>Creates a video extension command.</summary>
		/// <param name="pDesc">The <c>D3D12_VIDEO_EXTENSION_COMMAND_DESC</c> describing the command to be created.</param>
		/// <param name="pCreationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CREATION</c>.
		/// </param>
		/// <param name="CreationParametersDataSizeInBytes">The size of the pCreationParameters parameter structure, in bytes.</param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <c>ID3D12VideoExtensionCommand</c> interface.</param>
		/// <param name="ppVideoExtensionCommand">
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12VideoExtensionCommand</c> interface.
		/// </param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideoextensioncommand
		// HRESULT CreateVideoExtensionCommand( const D3D12_VIDEO_EXTENSION_COMMAND_DESC *pDesc, const void *pCreationParameters, SIZE_T
		// CreationParametersDataSizeInBytes, ID3D12ProtectedResourceSession *pProtectedResourceSession, REFIID riid, void
		// **ppVideoExtensionCommand );
		[PreserveSig]
		HRESULT CreateVideoExtensionCommand(in D3D12_VIDEO_EXTENSION_COMMAND_DESC pDesc, [In] IntPtr pCreationParameters, SizeT CreationParametersDataSizeInBytes,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppVideoExtensionCommand);

		/// <summary>Executes a video extension command.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution input parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <param name="pOutputData">A pointer to the execution output parameters structure, which is defined by the command.</param>
		/// <param name="OutputDataSizeInBytes">Receives the size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// Video extension commands executed through this method must complete before this method returns. For efficiency, extension
		/// implementations should schedule work in command lists instead of using this method, whenever possible. Each video command list
		/// type provides an <b>ExecuteExtensionCommand</b> for scheduled work. These include:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12VideoDecodeComandlist2::ExecuteExtensionCommand</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12VideoEncodeComandlist1::ExecuteExtensionCommand</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12VideoProcessComandlist2::ExecuteExtensionCommand</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-executeextensioncommand HRESULT
		// ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes, void *pOutputData, SIZE_T OutputDataSizeInBytes );
		[PreserveSig]
		HRESULT ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters,
			SizeT ExecutionParametersSizeInBytes, [Out] IntPtr pOutputData, SizeT OutputDataSizeInBytes);
	}

	/// <summary>Extends the <c>ID3D12VideoDevice</c> interface to add support video encoding capabilities.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videodevice3
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoDevice3")]
	[ComImport, Guid("4243adb4-3a32-4666-973c-0ccc5625dc44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoDevice3 : ID3D12VideoDevice2
	{
		/// <summary>Gets information about the features that are supported by the current video driver.</summary>
		/// <param name="FeatureVideo">A member of the <c>D3D12_FEATURE_VIDEO</c> enumeration that specifies the feature to query for support.</param>
		/// <param name="pFeatureSupportData">
		/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon
		/// the completion of the call, is populated with details about the level of support available. For information on the structure
		/// that is associated with each type of feature support request, see the field descriptions for <c>D3D12_FEATURE_VIDEO</c>.
		/// </param>
		/// <param name="FeatureSupportDataSize">The size of the structure passed to the pFeatureSupportData parameter.</param>
		/// <returns>
		/// Returns <b>S_OK</b> if successful; otherwise, returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
		/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-checkfeaturesupport HRESULT
		// CheckFeatureSupport( D3D12_FEATURE_VIDEO FeatureVideo, void *pFeatureSupportData, UINT FeatureSupportDataSize );
		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D12_FEATURE_VIDEO FeatureVideo, [In, Out] IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Creates a video decoder instance that contains the resolution-independent driver resources and state.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_DECODER_DESC</c> structure describing the decode profile and bitstream encryption for the decoder.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoder">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoder</c> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>Decoding a new stream requires instantiating a new decoder object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoder HRESULT
		// CreateVideoDecoder( const D3D12_VIDEO_DECODER_DESC *pDesc, REFIID riid, void **ppVideoDecoder );
		[PreserveSig]
		new HRESULT CreateVideoDecoder(in D3D12_VIDEO_DECODER_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoder);

		/// <summary>Allocates a video decoder heap that contains the resolution-dependent driver resources and state.</summary>
		/// <param name="pVideoDecoderHeapDesc">A pointer to a <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing the decoding configuration.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoderHeap">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoderHeap</c> interface.</param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideodecoderheap HRESULT
		// CreateVideoDecoderHeap( const D3D12_VIDEO_DECODER_HEAP_DESC *pVideoDecoderHeapDesc, REFIID riid, void **ppVideoDecoderHeap );
		[PreserveSig]
		new HRESULT CreateVideoDecoderHeap(in D3D12_VIDEO_DECODER_HEAP_DESC pVideoDecoderHeapDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoDecoderHeap);

		/// <summary>Creates a video processor instance.</summary>
		/// <param name="NodeMask">
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </param>
		/// <param name="pOutputStreamDesc">
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </param>
		/// <param name="NumInputStreamDescs">The number of input streams provided in the pInputStreamDescs parameter.</param>
		/// <param name="pInputStreamDescs">
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams. The number of structures provided should match the value specified in the NumInputStreamDescs parameter.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the video processor interface.</param>
		/// <param name="ppVideoProcessor">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoProcessor</c> interface</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>To change the parameters set during creation, you must recreate the video processor object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice-createvideoprocessor HRESULT
		// CreateVideoProcessor( UINT NodeMask, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc, UINT NumInputStreamDescs,
		// const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs, REFIID riid, void **ppVideoProcessor );
		[PreserveSig]
		new HRESULT CreateVideoProcessor(uint NodeMask, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC pOutputStreamDesc, int NumInputStreamDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppVideoProcessor);

		/// <summary>Creates an <c>ID3D12VideoMotionEstimator</c>, which maintains context for video motion estimation operations.</summary>
		/// <param name="pDesc">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</c> describing the parameters used for motion estimation. This structure contains both
		/// input and output fields.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12VideoMotionEstimator</b> interface.</param>
		/// <param name="ppVideoMotionEstimator">
		/// A pointer to a memory block that receives a pointer to the <b>ID3D12VideoMotionEstimator</b> interface.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice1-createvideomotionestimator
		// HRESULT CreateVideoMotionEstimator( const D3D12_VIDEO_MOTION_ESTIMATOR_DESC *pDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoMotionEstimator );
		[PreserveSig]
		new HRESULT CreateVideoMotionEstimator(in D3D12_VIDEO_MOTION_ESTIMATOR_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoMotionEstimator);

		/// <summary>Allocates heap that contains motion vectors for video motion estimation.</summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC</c> describing the format of the heap. This structure contains both input
		/// and output fields.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12VideoMotionVectorHeap</b> interface.</param>
		/// <param name="ppVideoMotionVectorHeap">
		/// A pointer to a memory block that receives a pointer to the <b>ID3D12VideoMotionVectorHeap</b> interface.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice1-createvideomotionvectorheap
		// HRESULT CreateVideoMotionVectorHeap( const D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC *pDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoMotionVectorHeap );
		[PreserveSig]
		new HRESULT CreateVideoMotionVectorHeap(in D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC pDesc, [In] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoMotionVectorHeap);

		/// <summary>
		/// Creates a video decoder instance that contains the resolution-independent driver resources and state, with support for protected resources.
		/// </summary>
		/// <param name="pDesc">
		/// A pointer to a <c>D3D12_VIDEO_DECODER_DESC</c> structure describing the decode profile and bitstream encryption for the decoder.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoder">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoder1</c> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>Decoding a new stream requires instantiating a new decoder object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideodecoder1 HRESULT
		// CreateVideoDecoder1( const D3D12_VIDEO_DECODER_DESC *pDesc, ID3D12ProtectedResourceSession *pProtectedResourceSession, REFIID
		// riid, void **ppVideoDecoder );
		[PreserveSig]
		new HRESULT CreateVideoDecoder1(in D3D12_VIDEO_DECODER_DESC pDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoDecoder);

		/// <summary>
		/// Allocates a video decoder heap that contains the resolution-dependent driver resources and state, with support for protected resources.
		/// </summary>
		/// <param name="pVideoDecoderHeapDesc">A pointer to a <c>D3D12_VIDEO_DECODER_HEAP_DESC</c> describing the decoding configuration.</param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the decode video state interface.</param>
		/// <param name="ppVideoDecoderHeap">
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12VideoDecoderHeap1</c> interface.
		/// </param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideodecoderheap1 HRESULT
		// CreateVideoDecoderHeap1( const D3D12_VIDEO_DECODER_HEAP_DESC *pVideoDecoderHeapDesc, ID3D12ProtectedResourceSession
		// *pProtectedResourceSession, REFIID riid, void **ppVideoDecoderHeap );
		[PreserveSig]
		new HRESULT CreateVideoDecoderHeap1(in D3D12_VIDEO_DECODER_HEAP_DESC pVideoDecoderHeapDesc, [In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppVideoDecoderHeap);

		/// <summary>Creates a video processor instance with support for protected resources.</summary>
		/// <param name="NodeMask">
		/// The node mask specifying the physical adapter on which the video processor will be used. For single GPU operation, set this to
		/// zero. If there are multiple GPU nodes, set a bit to identify the node, i.e. the device's physical adapter, to which the command
		/// queue applies. Each bit in the mask corresponds to a single node. Only 1 bit may be set.
		/// </param>
		/// <param name="pOutputStreamDesc">
		/// A pointer to a D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_output_stream_desc) structure describing
		/// the output stream.
		/// </param>
		/// <param name="NumInputStreamDescs">The number of input streams provided in the pInputStreamDescs parameter.</param>
		/// <param name="pInputStreamDescs">
		/// A pointer to a list of D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC(ns-d3d12video-d3d12_video_process_input_stream_desc) structures the
		/// input streams. The number of structures provided should match the value specified in the NumInputStreamDescs parameter.
		/// </param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the video processor interface.</param>
		/// <param name="ppVideoProcessor">A pointer to a memory block that receives a pointer to the <c>ID3D12VideoProcessor1</c> interface</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>To change the parameters set during creation, you must recreate the video processor object.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideoprocessor1 HRESULT
		// CreateVideoProcessor1( UINT NodeMask, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC *pOutputStreamDesc, UINT NumInputStreamDescs,
		// const D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs, ID3D12ProtectedResourceSession *pProtectedResourceSession, REFIID
		// riid, void **ppVideoProcessor );
		[PreserveSig]
		new HRESULT CreateVideoProcessor1(uint NodeMask, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC pOutputStreamDesc, int NumInputStreamDescs,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 5)] out object? ppVideoProcessor);

		/// <summary>Creates a video extension command.</summary>
		/// <param name="pDesc">The <c>D3D12_VIDEO_EXTENSION_COMMAND_DESC</c> describing the command to be created.</param>
		/// <param name="pCreationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_CREATION</c>.
		/// </param>
		/// <param name="CreationParametersDataSizeInBytes">The size of the pCreationParameters parameter structure, in bytes.</param>
		/// <param name="pProtectedResourceSession">A <c>ID3D12ProtectedResourceSession</c> for managing access to protected resources.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the <c>ID3D12VideoExtensionCommand</c> interface.</param>
		/// <param name="ppVideoExtensionCommand">
		/// A pointer to a memory block that receives a pointer to the <c>ID3D12VideoExtensionCommand</c> interface.
		/// </param>
		/// <returns>This method returns an HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-createvideoextensioncommand
		// HRESULT CreateVideoExtensionCommand( const D3D12_VIDEO_EXTENSION_COMMAND_DESC *pDesc, const void *pCreationParameters, SIZE_T
		// CreationParametersDataSizeInBytes, ID3D12ProtectedResourceSession *pProtectedResourceSession, REFIID riid, void
		// **ppVideoExtensionCommand );
		[PreserveSig]
		new HRESULT CreateVideoExtensionCommand(in D3D12_VIDEO_EXTENSION_COMMAND_DESC pDesc, [In] IntPtr pCreationParameters, SizeT CreationParametersDataSizeInBytes,
			[In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 4)] out object? ppVideoExtensionCommand);

		/// <summary>Executes a video extension command.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution input parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <param name="pOutputData">A pointer to the execution output parameters structure, which is defined by the command.</param>
		/// <param name="OutputDataSizeInBytes">Receives the size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>This method returns HRESULT.</returns>
		/// <remarks>
		/// <para>
		/// Video extension commands executed through this method must complete before this method returns. For efficiency, extension
		/// implementations should schedule work in command lists instead of using this method, whenever possible. Each video command list
		/// type provides an <b>ExecuteExtensionCommand</b> for scheduled work. These include:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><c>ID3D12VideoDecodeComandlist2::ExecuteExtensionCommand</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12VideoEncodeComandlist1::ExecuteExtensionCommand</c></description>
		/// </item>
		/// <item>
		/// <description><c>ID3D12VideoProcessComandlist2::ExecuteExtensionCommand</c></description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice2-executeextensioncommand HRESULT
		// ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes, void *pOutputData, SIZE_T OutputDataSizeInBytes );
		[PreserveSig]
		new HRESULT ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters,
			SizeT ExecutionParametersSizeInBytes, [Out] IntPtr pOutputData, SizeT OutputDataSizeInBytes);

		/// <summary>Creates a new instance of <c>ID3D12VideoEncoder</c>.</summary>
		/// <param name="pDesc">A <c>D3D12_VIDEO_ENCODER_DESC</c> representing the configuration parameters for the video encoder.</param>
		/// <param name="riid">The globally unique identifier (GUID) for the video encoder interface. Expected value: IID_ID3D12VideoEncoder.</param>
		/// <param name="ppVideoEncoder">A pointer to a memory block that receives a pointer to the video encoder interface.</param>
		/// <returns>Returns S_OK on success.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice3-createvideoencoder HRESULT
		// CreateVideoEncoder( const D3D12_VIDEO_ENCODER_DESC *pDesc, REFIID riid, void **ppVideoEncoder );
		[PreserveSig]
		HRESULT CreateVideoEncoder(in D3D12_VIDEO_ENCODER_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoEncoder);

		/// <summary>Creates a new instance of <c>ID3D12VideoEncoderHeap</c>.</summary>
		/// <param name="pDesc">
		/// A <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> representing the configuration parameters for the video encoder heap.
		/// </param>
		/// <param name="riid">The globally unique identifier (GUID) for the video encoder heap interface. Expected value: IID_ID3D12VideoEncoderHeap.</param>
		/// <param name="ppVideoEncoderHeap">A pointer to a memory block that receives a pointer to the video encoder heap interface.</param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videodevice3-createvideoencoderheap HRESULT
		// CreateVideoEncoderHeap( const D3D12_VIDEO_ENCODER_HEAP_DESC *pDesc, REFIID riid, void **ppVideoEncoderHeap );
		[PreserveSig]
		HRESULT CreateVideoEncoderHeap(in D3D12_VIDEO_ENCODER_HEAP_DESC pDesc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppVideoEncoderHeap);
	}

	/// <summary>Encapsulates a list of graphics commands for video encoding, including motion estimation.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoencodecommandlist
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoEncodeCommandList")]
	[ComImport, Guid("8455293a-0cbd-4831-9b39-fbdbab724723"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoEncodeCommandList : ID3D12CommandList
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-close HRESULT Close();
		[PreserveSig]
		HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-clearstate void ClearState();
		[PreserveSig]
		void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method returns void.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries, [In] ID3D12Resource pDestinationBuffer,
			ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endevent void EndEvent();
		[PreserveSig]
		void EndEvent();

		/// <summary>Performs the motion estimation operation.</summary>
		/// <param name="pMotionEstimator">An <c>ID3D12VideoMotionEstimator</c> representing the video motion estimator context object.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT</c> structure representing the video motion estimation output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_INPUT</c> structure representing the video motion estimation input arguments.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-estimatemotion void
		// EstimateMotion( ID3D12VideoMotionEstimator *pMotionEstimator, const D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT *pOutputArguments, const
		// D3D12_VIDEO_MOTION_ESTIMATOR_INPUT *pInputArguments );
		[PreserveSig]
		void EstimateMotion([In] ID3D12VideoMotionEstimator pMotionEstimator, in D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT pOutputArguments,
			in D3D12_VIDEO_MOTION_ESTIMATOR_INPUT pInputArguments);

		/// <summary>
		/// Translates the motion vector output of the <c>EstimateMotion</c> method from hardware-dependent formats into a consistent format
		/// defined by the video motion estimation APIs.
		/// </summary>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT</c> structure containing the translated motion vectors.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT</c> structure containing the motion vectors to translate.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvemotionvectorheap
		// void ResolveMotionVectorHeap( const D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT *pOutputArguments, const
		// D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT *pInputArguments );
		[PreserveSig]
		void ResolveMotionVectorHeap(in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT pOutputArguments, in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		void WriteBufferImmediate(int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the command list. By default, no
		/// protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected resources of
		/// the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no protected
		/// resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		void SetProtectedResourceSession([In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession);
	}

	/// <summary>
	/// Encapsulates a list of graphics commands for video decoding. This interface inherits from <c>ID3D12VideoEncodeCommandList</c> and
	/// adds support for video extension commands.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoencodecommandlist1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoEncodeCommandList1")]
	[ComImport, Guid("94971eca-2bdb-4769-88cf-3675ea757ebc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoEncodeCommandList1 : ID3D12VideoEncodeCommandList
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method returns void.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries, [In] ID3D12Resource pDestinationBuffer,
			ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>Performs the motion estimation operation.</summary>
		/// <param name="pMotionEstimator">An <c>ID3D12VideoMotionEstimator</c> representing the video motion estimator context object.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT</c> structure representing the video motion estimation output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_INPUT</c> structure representing the video motion estimation input arguments.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-estimatemotion void
		// EstimateMotion( ID3D12VideoMotionEstimator *pMotionEstimator, const D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT *pOutputArguments, const
		// D3D12_VIDEO_MOTION_ESTIMATOR_INPUT *pInputArguments );
		[PreserveSig]
		new void EstimateMotion([In] ID3D12VideoMotionEstimator pMotionEstimator, in D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT pOutputArguments,
			in D3D12_VIDEO_MOTION_ESTIMATOR_INPUT pInputArguments);

		/// <summary>
		/// Translates the motion vector output of the <c>EstimateMotion</c> method from hardware-dependent formats into a consistent format
		/// defined by the video motion estimation APIs.
		/// </summary>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT</c> structure containing the translated motion vectors.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT</c> structure containing the motion vectors to translate.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvemotionvectorheap
		// void ResolveMotionVectorHeap( const D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT *pOutputArguments, const
		// D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT *pInputArguments );
		[PreserveSig]
		new void ResolveMotionVectorHeap(in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT pOutputArguments, in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the command list. By default, no
		/// protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected resources of
		/// the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no protected
		/// resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		new void SetProtectedResourceSession([In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video encode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist1-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters,
			SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into an encode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist1-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters,
			SizeT ExecutionParametersSizeInBytes);
	}

	/// <summary>
	/// Encapsulates a list of graphics commands for video encoding. This interface inherits from <c>ID3D12VideoEncodeCommandList1</c> and
	/// adds methods for encoding video and resolving encode operation metadata.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoencodecommandlist2
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoEncodeCommandList2")]
	[ComImport, Guid("895491e2-e701-46a9-9a1f-8d3480ed867a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoEncodeCommandList2 : ID3D12VideoEncodeCommandList1
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method returns void.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries, [In] ID3D12Resource pDestinationBuffer,
			ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>Performs the motion estimation operation.</summary>
		/// <param name="pMotionEstimator">An <c>ID3D12VideoMotionEstimator</c> representing the video motion estimator context object.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT</c> structure representing the video motion estimation output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_INPUT</c> structure representing the video motion estimation input arguments.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-estimatemotion void
		// EstimateMotion( ID3D12VideoMotionEstimator *pMotionEstimator, const D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT *pOutputArguments, const
		// D3D12_VIDEO_MOTION_ESTIMATOR_INPUT *pInputArguments );
		[PreserveSig]
		new void EstimateMotion([In] ID3D12VideoMotionEstimator pMotionEstimator, in D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT pOutputArguments,
			in D3D12_VIDEO_MOTION_ESTIMATOR_INPUT pInputArguments);

		/// <summary>
		/// Translates the motion vector output of the <c>EstimateMotion</c> method from hardware-dependent formats into a consistent format
		/// defined by the video motion estimation APIs.
		/// </summary>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT</c> structure containing the translated motion vectors.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT</c> structure containing the motion vectors to translate.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvemotionvectorheap
		// void ResolveMotionVectorHeap( const D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT *pOutputArguments, const
		// D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT *pInputArguments );
		[PreserveSig]
		new void ResolveMotionVectorHeap(in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT pOutputArguments, in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the command list. By default, no
		/// protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected resources of
		/// the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no protected
		/// resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		new void SetProtectedResourceSession([In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video encode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist1-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		new void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters,
			SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into an encode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist1-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		new void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters,
			SizeT ExecutionParametersSizeInBytes);

		/// <summary>Encodes a bitstream.</summary>
		/// <param name="pEncoder">A <c>ID3D12VideoEncoder</c> representing the video encoder to be used for the encode operation.</param>
		/// <param name="pHeap">
		/// <para>A <c>ID3D12VideoEncoderHeap</c> representing the video encoder heap to be used for this operation.</para>
		/// <para>The encoder heap object allocation must not be released before any in-flight GPU commands that references it finish execution.</para>
		/// <para>
		/// Note that the reconfigurations in recorded commands input arguments done within allowed bounds (e.g. different target
		/// resolutions in allowed lists of resolutions) can co-exist in-flight with the same encoder heap instance, providing the target
		/// resolution is supported by the given encoder heap.
		/// </para>
		/// <para>
		/// In the current release, we only support one execution flow at a time using the same encoder or encoder heap instances. All
		/// commands against these objects must be recorded and submitted in a serialized order, i.e. from a single CPU thread or
		/// synchronizing multiple threads in such way that the commands are recorded in a serialized order.
		/// </para>
		/// <para>
		/// The video encoder and video encoder heap may be used to record commands from multiple command lists, but may only be associated
		/// with one command list at a time. The application is responsible for synchronizing single accesses to the video encoder and video
		/// encoder heap at a time. The application must also record video encoding commands against the video encoder and video encoder
		/// heaps in the order that they are executed on the GPU.
		/// </para>
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS</c> representing input arguments for the encode operation.
		/// </param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS</c> representing output arguments for the encode operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist2-encodeframe void
		// EncodeFrame( ID3D12VideoEncoder *pEncoder, ID3D12VideoEncoderHeap *pHeap, const D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS
		// *pInputArguments, const D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS *pOutputArguments );
		[PreserveSig]
		void EncodeFrame([In] ID3D12VideoEncoder pEncoder, [In] ID3D12VideoEncoderHeap pHeap, in D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS pInputArguments,
			in D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS pOutputArguments);

		/// <summary>Resolves the output metadata from a call to <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c> to a readable format.</summary>
		/// <param name="pInputArguments">
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS</c>, containing a pointer to the opaque
		/// <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> received from a previous call to <b>EncodeFrame</b>.
		/// </param>
		/// <param name="pOutputArguments">
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS</c>, containing a pointer to the
		/// <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> where the resolved, readable metadata will be written.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The caller can interpret the contents of pOutputArguments as a memory blob that contains a
		/// <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> structure and the metadata array contents. The array contents of the dynamic size
		/// metadata based on the subregion number are positioned in memory contiguously right after the struct allocation and the pointers
		/// in the struct point to the start addresses of the array contents.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist2-resolveencoderoutputmetadata
		// void ResolveEncoderOutputMetadata( const D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS *pInputArguments, const
		// D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS *pOutputArguments );
		[PreserveSig]
		void ResolveEncoderOutputMetadata(in D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS pInputArguments, in D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS pOutputArguments);
	}

	/// <summary>
	/// <para>
	/// Encapsulates a list of graphics commands for video encoding. This interface derives from <c>ID3D12VideoEncodeCommandList2</c>, and
	/// adds support for barriers.
	/// </para>
	/// <para>Requires the DirectX 12 Agility SDK 1.7 or later.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoencodecommandlist3
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoEncodeCommandList3")]
	[ComImport, Guid("7f027b22-1515-4e85-aa0d-026486580576"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoEncodeCommandList3 : ID3D12VideoEncodeCommandList2
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>This method returns void.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicate that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endquery void EndQuery(
		// ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries, [In] ID3D12Resource pDestinationBuffer,
			ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>Performs the motion estimation operation.</summary>
		/// <param name="pMotionEstimator">An <c>ID3D12VideoMotionEstimator</c> representing the video motion estimator context object.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT</c> structure representing the video motion estimation output arguments.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_MOTION_ESTIMATOR_INPUT</c> structure representing the video motion estimation input arguments.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-estimatemotion void
		// EstimateMotion( ID3D12VideoMotionEstimator *pMotionEstimator, const D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT *pOutputArguments, const
		// D3D12_VIDEO_MOTION_ESTIMATOR_INPUT *pInputArguments );
		[PreserveSig]
		new void EstimateMotion([In] ID3D12VideoMotionEstimator pMotionEstimator, in D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT pOutputArguments,
			in D3D12_VIDEO_MOTION_ESTIMATOR_INPUT pInputArguments);

		/// <summary>
		/// Translates the motion vector output of the <c>EstimateMotion</c> method from hardware-dependent formats into a consistent format
		/// defined by the video motion estimation APIs.
		/// </summary>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT</c> structure containing the translated motion vectors.
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT</c> structure containing the motion vectors to translate.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-resolvemotionvectorheap
		// void ResolveMotionVectorHeap( const D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT *pOutputArguments, const
		// D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT *pInputArguments );
		[PreserveSig]
		new void ResolveMotionVectorHeap(in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_OUTPUT pOutputArguments, in D3D12_RESOLVE_VIDEO_MOTION_VECTOR_HEAP_INPUT pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The capability for this feature is specified with <c>D3D12_FEATURE_DATA_D3D12_OPTIONS3::WriteBufferImmediateSupportFlags</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the command list. By default, no
		/// protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected resources of
		/// the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no protected
		/// resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		new void SetProtectedResourceSession([In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video encode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist1-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		new void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters,
			SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into an encode command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist1-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		new void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters,
			SizeT ExecutionParametersSizeInBytes);

		/// <summary>Encodes a bitstream.</summary>
		/// <param name="pEncoder">A <c>ID3D12VideoEncoder</c> representing the video encoder to be used for the encode operation.</param>
		/// <param name="pHeap">
		/// <para>A <c>ID3D12VideoEncoderHeap</c> representing the video encoder heap to be used for this operation.</para>
		/// <para>The encoder heap object allocation must not be released before any in-flight GPU commands that references it finish execution.</para>
		/// <para>
		/// Note that the reconfigurations in recorded commands input arguments done within allowed bounds (e.g. different target
		/// resolutions in allowed lists of resolutions) can co-exist in-flight with the same encoder heap instance, providing the target
		/// resolution is supported by the given encoder heap.
		/// </para>
		/// <para>
		/// In the current release, we only support one execution flow at a time using the same encoder or encoder heap instances. All
		/// commands against these objects must be recorded and submitted in a serialized order, i.e. from a single CPU thread or
		/// synchronizing multiple threads in such way that the commands are recorded in a serialized order.
		/// </para>
		/// <para>
		/// The video encoder and video encoder heap may be used to record commands from multiple command lists, but may only be associated
		/// with one command list at a time. The application is responsible for synchronizing single accesses to the video encoder and video
		/// encoder heap at a time. The application must also record video encoding commands against the video encoder and video encoder
		/// heaps in the order that they are executed on the GPU.
		/// </para>
		/// </param>
		/// <param name="pInputArguments">
		/// A <c>D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS</c> representing input arguments for the encode operation.
		/// </param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS</c> representing output arguments for the encode operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist2-encodeframe void
		// EncodeFrame( ID3D12VideoEncoder *pEncoder, ID3D12VideoEncoderHeap *pHeap, const D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS
		// *pInputArguments, const D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS *pOutputArguments );
		[PreserveSig]
		new void EncodeFrame([In] ID3D12VideoEncoder pEncoder, [In] ID3D12VideoEncoderHeap pHeap, in D3D12_VIDEO_ENCODER_ENCODEFRAME_INPUT_ARGUMENTS pInputArguments,
			in D3D12_VIDEO_ENCODER_ENCODEFRAME_OUTPUT_ARGUMENTS pOutputArguments);

		/// <summary>Resolves the output metadata from a call to <c>ID3D12VideoEncodeCommandList2::EncodeFrame</c> to a readable format.</summary>
		/// <param name="pInputArguments">
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS</c>, containing a pointer to the opaque
		/// <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> received from a previous call to <b>EncodeFrame</b>.
		/// </param>
		/// <param name="pOutputArguments">
		/// A pointer to a <c>D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS</c>, containing a pointer to the
		/// <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> where the resolved, readable metadata will be written.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The caller can interpret the contents of pOutputArguments as a memory blob that contains a
		/// <c>D3D12_VIDEO_ENCODER_OUTPUT_METADATA</c> structure and the metadata array contents. The array contents of the dynamic size
		/// metadata based on the subregion number are positioned in memory contiguously right after the struct allocation and the pointers
		/// in the struct point to the start addresses of the array contents.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist2-resolveencoderoutputmetadata
		// void ResolveEncoderOutputMetadata( const D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS *pInputArguments, const
		// D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS *pOutputArguments );
		[PreserveSig]
		new void ResolveEncoderOutputMetadata(in D3D12_VIDEO_ENCODER_RESOLVE_METADATA_INPUT_ARGUMENTS pInputArguments, in D3D12_VIDEO_ENCODER_RESOLVE_METADATA_OUTPUT_ARGUMENTS pOutputArguments);

		/// <summary>
		/// <para>Adds a collection of barriers into a video encode command list recording.</para>
		/// <para>Requires the DirectX 12 Agility SDK 1.7 or later.</para>
		/// </summary>
		/// <param name="NumBarrierGroups">Number of barrier groups pointed to by pBarrierGroups.</param>
		/// <param name="pBarrierGroups">Pointer to an array of <c>D3D12_BARRIER_GROUP</c> objects.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencodecommandlist3-barrier void Barrier(
		// UINT32 NumBarrierGroups, const D3D12_BARRIER_GROUP *pBarrierGroups );
		[PreserveSig]
		void Barrier(int NumBarrierGroups, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_BARRIER_GROUP[] pBarrierGroups);
	}

	/// <summary>Represents a Direct3D 12 video encoder.</summary>
	/// <remarks>Get an instance of this class by calling <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoencoder
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoEncoder")]
	[ComImport, Guid("2e0d212d-8df9-44a6-a770-bb289b182737"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoEncoder : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the node mask for the video encoder.</summary>
		/// <returns>The node mask value specified in the <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getnodemask UINT GetNodeMask();
		[PreserveSig]
		uint GetNodeMask();

		/// <summary>Gets the encoder flags with which the video encoder was initialized.</summary>
		/// <returns>
		/// The bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_FLAGS</c> enumeration specified in the
		/// <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getencoderflags
		// D3D12_VIDEO_ENCODER_FLAGS GetEncoderFlags();
		[PreserveSig]
		D3D12_VIDEO_ENCODER_FLAGS GetEncoderFlags();

		/// <summary>Gets the codec associated with the video encoder.</summary>
		/// <returns>
		/// The value from the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specified in the <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getcodec
		// D3D12_VIDEO_ENCODER_CODEC GetCodec();
		[PreserveSig]
		D3D12_VIDEO_ENCODER_CODEC GetCodec();

		/// <summary>Gets the codec profile associated with the video encoder.</summary>
		/// <param name="dstProfile">
		/// Receives a <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure representing the codec profile specified in the
		/// <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.
		/// </param>
		/// <returns>Returns S_OK on success.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getcodecprofile HRESULT
		// GetCodecProfile( D3D12_VIDEO_ENCODER_PROFILE_DESC dstProfile );
		[PreserveSig]
		HRESULT GetCodecProfile(D3D12_VIDEO_ENCODER_PROFILE_DESC dstProfile);

		/// <summary>Gets the codec configuration parameters associated with the video encoder.</summary>
		/// <param name="dstCodecConfig">
		/// Receives a <c>D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION</c> structure representing the codec configuration parameters specified in
		/// the <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.
		/// </param>
		/// <returns>Returns S_OK on success.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getcodecconfiguration HRESULT
		// GetCodecConfiguration( D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION dstCodecConfig );
		[PreserveSig]
		HRESULT GetCodecConfiguration(D3D12_VIDEO_ENCODER_CODEC_CONFIGURATION dstCodecConfig);

		/// <summary>Gets the input format of the video encoder.</summary>
		/// <returns>The <c>DXGI_FORMAT</c> value specified in the <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getinputformat DXGI_FORMAT GetInputFormat();
		[PreserveSig]
		DXGI_FORMAT GetInputFormat();

		/// <summary>Gets the maximum motion estimation precision of the video encoder.</summary>
		/// <returns>
		/// The value from the <c>D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE</c> enumeration specified in the
		/// <c>D3D12_VIDEO_ENCODER_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoder</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoder-getmaxmotionestimationprecision
		// D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE GetMaxMotionEstimationPrecision();
		[PreserveSig]
		D3D12_VIDEO_ENCODER_MOTION_ESTIMATION_PRECISION_MODE GetMaxMotionEstimationPrecision();
	}

	/// <summary>Represents a Direct3D 12 video encoder heap.</summary>
	/// <remarks>Get an instance of this class by calling <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoencoderheap
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoEncoderHeap")]
	[ComImport, Guid("22b35d96-876a-44c0-b25e-fb8c9c7f1c4a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoEncoderHeap : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the node mask for the video encoder heap.</summary>
		/// <returns>The node mask value specified in the <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getnodemask UINT GetNodeMask();
		[PreserveSig]
		uint GetNodeMask();

		/// <summary>Gets the encoder heap flags with which the video encoder heap was initialized.</summary>
		/// <returns>
		/// The bitwise OR combination of values from the <c>D3D12_VIDEO_ENCODER_HEAP_FLAGS</c> enumeration specified in the
		/// <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getencoderheapflags
		// D3D12_VIDEO_ENCODER_HEAP_FLAGS GetEncoderHeapFlags();
		[PreserveSig]
		D3D12_VIDEO_ENCODER_HEAP_FLAGS GetEncoderHeapFlags();

		/// <summary>Gets the codec associated with the video encoder heap.</summary>
		/// <returns>
		/// The value from the <c>D3D12_VIDEO_ENCODER_CODEC</c> enumeration specified in the <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed
		/// into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getcodec
		// D3D12_VIDEO_ENCODER_CODEC GetCodec();
		[PreserveSig]
		D3D12_VIDEO_ENCODER_CODEC GetCodec();

		/// <summary>Gets the codec profile associated with the video encoder heap.</summary>
		/// <param name="dstProfile">
		/// Receives a <c>D3D12_VIDEO_ENCODER_PROFILE_DESC</c> structure representing the codec profile specified in the
		/// <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.
		/// </param>
		/// <returns>Returns S_OK on success.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getcodecprofile HRESULT
		// GetCodecProfile( D3D12_VIDEO_ENCODER_PROFILE_DESC dstProfile );
		[PreserveSig]
		HRESULT GetCodecProfile(D3D12_VIDEO_ENCODER_PROFILE_DESC dstProfile);

		/// <summary>Gets the codec level associated with the video encoder heap.</summary>
		/// <param name="dstLevel">
		/// Receives a <c>D3D12_VIDEO_ENCODER_LEVEL_SETTING</c> structure representing the codec profile specified in the
		/// <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getcodeclevel HRESULT
		// GetCodecLevel( D3D12_VIDEO_ENCODER_LEVEL_SETTING dstLevel );
		[PreserveSig]
		HRESULT GetCodecLevel(D3D12_VIDEO_ENCODER_LEVEL_SETTING dstLevel);

		/// <summary>Gets the resolution list count associated with the video encoder heap.</summary>
		/// <returns>The size of the resolution list provided in the <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getresolutionlistcount UINT GetResolutionListCount();
		[PreserveSig]
		uint GetResolutionListCount();

		/// <summary>Gets the resolution list associated with the video encoder heap.</summary>
		/// <param name="ResolutionsListCount">
		/// The count of resolutions to retrieve. Get the number of resolutions with which the encoder heap was created by calling <c>ID3D12VideoEncoderHeap::GetResolutionListCount</c>.
		/// </param>
		/// <param name="pResolutionList">
		/// Receives a pointer to an array of <c>D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC</c> structures representing the resolutions
		/// specified in the <c>D3D12_VIDEO_ENCODER_HEAP_DESC</c> passed into <c>ID3D12VideoDevice3::CreateVideoEncoderHeap</c>.
		/// </param>
		/// <returns>Returns S_OK on success.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoencoderheap-getresolutionlist HRESULT
		// GetResolutionList( const UINT ResolutionsListCount, D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC *pResolutionList );
		[PreserveSig]
		HRESULT GetResolutionList(int ResolutionsListCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_VIDEO_ENCODER_PICTURE_RESOLUTION_DESC[] pResolutionList);
	}

	/// <summary>Represents a video extension command.</summary>
	/// <remarks>Create an instance of this interface by calling <c>ID3D12VideoDevice2::CreateVideoExtensionCommand</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoextensioncommand
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoExtensionCommand")]
	[ComImport, Guid("554e41e8-ae8e-4a8c-b7d2-5b4f274a30e4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoExtensionCommand : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the <c>D3D12_VIDEO_EXTENSION_COMMAND_DESC</c> provided when the interface was created.</summary>
		/// <returns>The <c>D3D12_VIDEO_EXTENSION_COMMAND_DESC</c> provided when the interface was created.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoextensioncommand-getdesc
		// D3D12_VIDEO_EXTENSION_COMMAND_DESC GetDesc();
		[PreserveSig]
		D3D12_VIDEO_EXTENSION_COMMAND_DESC GetDesc();

		/// <summary>
		/// Gets the <c>ID3D12ProtectedResourceSession</c> that was passed into <c>ID3D12VideoDevice2::CreateVideoExtensionCommand</c> when
		/// the <c>ID3D12VideoExtensionCommand</c> was created.
		/// </summary>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <param name="ppProtectedSession">Receives a void pointer representing the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoextensioncommand-getprotectedresourcesession
		// HRESULT GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>This interface maintains context for video motion estimation operations.</summary>
	/// <remarks>
	/// <para>Create a new instance of this interface by calling <c>ID3D12VideoDevice1::CreateVideoMotionEstimator</c>.</para>
	/// <para>This interface is passed into calls to <c>ID3D12VideoEncodeCommandList::EstimateMotion</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videomotionestimator
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoMotionEstimator")]
	[ComImport, Guid("33fdae0e-098b-428f-87bb-34b695de08f8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoMotionEstimator : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>
		/// Gets the <c>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</c> structure that was passed into
		/// <c>ID3D12VideoDevice1::CreateVideoMotionEstimator</c> when the <c>ID3D12VideoMotionEstimator</c> was created.
		/// </summary>
		/// <returns>This method returns a <b>D3D12_VIDEO_MOTION_ESTIMATOR_DESC</b> structure.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videomotionestimator-getdesc
		// D3D12_VIDEO_MOTION_ESTIMATOR_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_VIDEO_MOTION_ESTIMATOR_DESC size);

		/// <summary>
		/// Gets the <c>ID3D12ProtectedResourceSession</c> that was passed into <c>ID3D12VideoDevice1::CreateVideoMotionEstimator</c> when
		/// the <c>ID3D12VideoMotionEstimator</c> was created.
		/// </summary>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <param name="ppProtectedSession">Receives a void pointer representing the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videomotionestimator-getprotectedresourcesession
		// HRESULT GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>
	/// Represents the storage of the motion vector output of a motion estimation operation in an IHV-dependent layout. Call
	/// <c>ID3D12VideoEncodeCommandList::EstimateMotion</c> to calculate and store motion vectors. Use
	/// <c>ID3D12VideoEncodeCommandList::ResolveMotionVectorHeap</c> to copy and translate these results into the API-defined layout in a
	/// Texture 2D.
	/// </summary>
	/// <remarks>
	/// <para>Create a new instance of this interface by calling <c>ID3D12VideoDevice1::CreateVideoMotionVectorHeap</c>.</para>
	/// <para>
	/// This interface is used by the <c>D3D12_VIDEO_MOTION_ESTIMATOR_OUTPUT</c> structure returned from
	/// <c>ID3D12VideoEncodeCommandList::EstimateMotion</c>. It is also used to supply hint vectors in the
	/// <c>D3D12_VIDEO_MOTION_ESTIMATOR_INPUT</c> structure.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videomotionvectorheap
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoMotionVectorHeap")]
	[ComImport, Guid("5be17987-743a-4061-834b-23d22daea505"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoMotionVectorHeap : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>
		/// Gets the <c>D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC</c> structure that was passed into
		/// <c>ID3D12VideoDevice1::CreateVideoMotionEstimatorHeap</c> when the <c>ID3D12VideoMotionEstimatorHeap</c> was created.
		/// </summary>
		/// <returns>This method returns a <b>D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC</b> structure.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videomotionvectorheap-getdesc
		// D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_VIDEO_MOTION_VECTOR_HEAP_DESC size);

		/// <summary>
		/// Gets the <c>ID3D12ProtectedResourceSession</c> that was passed into <c>ID3D12VideoDevice1::CreateVideoMotionEstimatorHeap</c>
		/// when the <c>ID3D12VideoMotionEstimatorHeap</c> was created.
		/// </summary>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <param name="ppProtectedSession">Receives a void pointer representing the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videomotionvectorheap-getprotectedresourcesession
		// HRESULT GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [Optional, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>Encapsulates a list of graphics commands for video processing. This interface is inherited by <c>ID3D12VideoProcessCommandList1</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoprocesscommandlist
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoProcessCommandList")]
	[ComImport, Guid("aeb2543a-167f-4682-acc8-d159ed4a6209"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoProcessCommandList : ID3D12CommandList
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-close HRESULT Close();
		[PreserveSig]
		HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-clearstate void ClearState();
		[PreserveSig]
		void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicates that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endquery void
		// EndQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endevent void EndEvent();
		[PreserveSig]
		void EndEvent();

		/// <summary>
		/// <para>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c> without recreating the interface. It
		/// is recommended that you use <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to change the field
		/// type with each call.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c>. When dealing with mixed content, use
		/// <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to specify a field type with each call.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-processframes void
		// ProcessFrames( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		void ProcessFrames([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS[] pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);
	}

	/// <summary>
	/// Encapsulates a list of graphics commands for video processing. Adds the <c>ID3D12VideoProcessCommandList1::ProcessFrames1</c> method
	/// which supports changing the <c>D3D12_VIDEO_FIELD_TYPE</c> for each call, unlike <c>ID3D12VideoProcessCommandList::ProcessFrames</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoprocesscommandlist1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoProcessCommandList1")]
	[ComImport, Guid("542c5c4d-7596-434f-8c93-4efa6766f267"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoProcessCommandList1 : ID3D12VideoProcessCommandList
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicates that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endquery void
		// EndQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>
		/// <para>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c> without recreating the interface. It
		/// is recommended that you use <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to change the field
		/// type with each call.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c>. When dealing with mixed content, use
		/// <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to specify a field type with each call.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-processframes void
		// ProcessFrames( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void ProcessFrames([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS[] pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface. This version of the method supports changing the <c>D3D12_VIDEO_FIELD_TYPE</c> for each call, unlike <c>ID3D12VideoProcessCommandList::ProcessFrames</c>.
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist1-processframes1 void
		// ProcessFrames1( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1 *pInputArguments );
		[PreserveSig]
		void ProcessFrames1([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1[] pInputArguments);
	}

	/// <summary>
	/// Encapsulates a list of graphics commands for video processing. This interface inherits from <c>ID3D12VideoProcessCommandList1</c>
	/// and adds support for video extension commands.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoprocesscommandlist2
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoProcessCommandList2")]
	[ComImport, Guid("db525ae4-6ad6-473c-baa7-59b2e37082e4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoProcessCommandList2 : ID3D12VideoProcessCommandList1
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicates that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endquery void
		// EndQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>
		/// <para>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c> without recreating the interface. It
		/// is recommended that you use <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to change the field
		/// type with each call.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c>. When dealing with mixed content, use
		/// <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to specify a field type with each call.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-processframes void
		// ProcessFrames( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void ProcessFrames([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS[] pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface. This version of the method supports changing the <c>D3D12_VIDEO_FIELD_TYPE</c> for each call, unlike <c>ID3D12VideoProcessCommandList::ProcessFrames</c>.
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist1-processframes1 void
		// ProcessFrames1( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1 *pInputArguments );
		[PreserveSig]
		new void ProcessFrames1([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1[] pInputArguments);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the video process command list. By
		/// default, no protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected
		/// resources of the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no
		/// protected resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist2-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		void SetProtectedResourceSession([In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video processor command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist2-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters, SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into a video process command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist2-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters, SizeT ExecutionParametersSizeInBytes);
	}

	/// <summary>
	/// <para>
	/// Encapsulates a list of graphics commands for video processing. This interface derives from <c>ID3D12VideoProcessCommandList2</c>,
	/// and adds support for barriers.
	/// </para>
	/// <para>Requires the DirectX 12 Agility SDK 1.7 or later.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoprocesscommandlist3
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoProcessCommandList3")]
	[ComImport, Guid("1a0a4ca4-9f08-40ce-9558-b411fd2666ff"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoProcessCommandList3 : ID3D12VideoProcessCommandList2
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>Gets the type of the command list, such as direct, bundle, compute, or copy.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_COMMAND_LIST_TYPE</c></b></para>
		/// <para>
		/// This method returns the type of the command list, as a <c>D3D12_COMMAND_LIST_TYPE</c> enumeration constant, such as direct,
		/// bundle, compute, or copy.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12commandlist-gettype D3D12_COMMAND_LIST_TYPE GetType();
		[PreserveSig]
		new D3D12_COMMAND_LIST_TYPE GetType();

		/// <summary>Indicates that recording to the command list has finished.</summary>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list has already been closed, or an invalid API was called during command list recording.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory during recording.</description>
		/// </item>
		/// <item>
		/// <description><b>E_INVALIDARG</b> if an invalid argument was passed to the command list API during recording.</description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The runtime will validate that the command list has not previously been closed. If an error was encountered during recording,
		/// the error code is returned here. The runtime won't call the close device driver interface (DDI) in this case.
		/// </para>
		/// <para>For an example of creating a command list, see <c>ID3D12GraphicsCommandList::Close method</c></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>Returns <b>S_OK</b> if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>E_FAIL</b> if the command list was not in the "closed" state when the <b>Reset</b> call was made, or the per-device limit
		/// would have been exceeded.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>E_OUTOFMEMORY</b> if the operating system ran out of memory.</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>E_INVALIDARG</b> if the allocator is currently being used with another command list in the "recording" state or if the
		/// specified allocator was created with the wrong type.
		/// </description>
		/// </item>
		/// </list>
		/// <para>See <c>Direct3D 12 Return Codes</c> for other possible return values.</para>
		/// </returns>
		/// <remarks>For additional information and examples of using this method, see <c>ID3D12GraphicsCommandList::Reset method</c></remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-reset HRESULT Reset(
		// ID3D12CommandAllocator *pAllocator );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-clearstate void ClearState();
		[PreserveSig]
		new void ClearState();

		/// <summary>Notifies the driver that it needs to synchronize multiple accesses to resources.</summary>
		/// <param name="NumBarriers">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of submitted barrier descriptions.</para>
		/// </param>
		/// <param name="pBarriers">
		/// <para>Type: <b>const <c>D3D12_RESOURCE_BARRIER</c>*</b></para>
		/// <para>Pointer to an array of barrier descriptions.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resourcebarrier void
		// ResourceBarrier( UINT NumBarriers, const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>
		/// Indicates that the current contents of a resource can be discarded. The current contents of the resource are no longer valid
		/// allowing optimizations for subsequent operations such as <c>ResourceBarrier</c>.
		/// </summary>
		/// <param name="pResource">A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</param>
		/// <param name="pRegion">
		/// A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Some queries do not use <b>BeginQuery</b> and only have an <b>EndQuery</b>. See each query type in <c>D3D12_QUERY_TYPE</c> to
		/// determine proper usage.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginquery void
		// BeginQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage for this query.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="Index">The index of the query within the query heap.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endquery void
		// EndQuery( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query.</summary>
		/// <param name="pQueryHeap">A pointer to an <c>ID3D12QueryHeap</c> specifying the storage containing the queries to resolve.</param>
		/// <param name="Type">A member of the <c>D3D12_QUERY_TYPE</c> enumeration specifying the type of the query.</param>
		/// <param name="StartIndex">The index of the first query to resolve.</param>
		/// <param name="NumQueries">The number of queries to resolve.</param>
		/// <param name="pDestinationBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the destination buffer. The resource must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// The alignment offset into the destination buffer. This must be a multiple of 8 bytes.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-resolvequerydata void
		// ResolveQueryData( ID3D12QueryHeap *pQueryHeap, D3D12_QUERY_TYPE Type, UINT StartIndex, UINT NumQueries, ID3D12Resource
		// *pDestinationBuffer, UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Specifies that subsequent commands should not be performed if the predicate value passes the specified operation.</summary>
		/// <param name="pBuffer">
		/// A pointer to an <c>ID3D12Resource</c> representing the buffer from which to read the 64-bit predication value.
		/// </param>
		/// <param name="AlignedBufferOffset">The UINT64-aligned buffer offset.</param>
		/// <param name="Operation">A member of the <c>D3D12_PREDICATION_OP</c> enumeration specifying the predicate operation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setpredication void
		// SetPredication( ID3D12Resource *pBuffer, UINT64 AlignedBufferOffset, D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-setmarker void
		// SetMarker( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <param name="Metadata">Internal.</param>
		/// <param name="pData">Internal.</param>
		/// <param name="Size">Internal.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-beginevent void
		// BeginEvent( UINT Metadata, const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In] IntPtr pData, uint Size);

		/// <summary>For internal use only. Not intended to be called directly.</summary>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>
		/// <para>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c> without recreating the interface. It
		/// is recommended that you use <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to change the field
		/// type with each call.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This version of the method does not allow you to change the <c>D3D12_VIDEO_FIELD_TYPE</c>. When dealing with mixed content, use
		/// <c>ID3D12VideoProcessCommandList::ProcessFrames1</c> instead, which allows you to specify a field type with each call.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-processframes void
		// ProcessFrames( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS *pInputArguments );
		[PreserveSig]
		new void ProcessFrames([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS[] pInputArguments);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">The number of elements in the pParams and pModes arrays.</param>
		/// <param name="pParams">The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures of size Count.</param>
		/// <param name="pModes">
		/// The address of an array of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures of size Count. The default value is <b>null</b>.
		/// Passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist-writebufferimmediate
		// void WriteBufferImmediate( UINT Count, const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, const D3D12_WRITEBUFFERIMMEDIATE_MODE
		// *pModes );
		[PreserveSig]
		new void WriteBufferImmediate(int Count, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[]? pModes);

		/// <summary>
		/// Records a video processing operation to the command list, operating on one or more input samples and writing the result to an
		/// output surface. This version of the method supports changing the <c>D3D12_VIDEO_FIELD_TYPE</c> for each call, unlike <c>ID3D12VideoProcessCommandList::ProcessFrames</c>.
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to an <c>ID3D12VideoProcessor</c> interface representing a video processor instance.</param>
		/// <param name="pOutputArguments">
		/// A <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS</c> structure specifying the output surface and output arguments.
		/// </param>
		/// <param name="NumInputStreams">The count of input streams.</param>
		/// <param name="pInputArguments">
		/// A pointer to an array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1</c> structures specifying the input parameters.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist1-processframes1 void
		// ProcessFrames1( ID3D12VideoProcessor *pVideoProcessor, const D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS *pOutputArguments, UINT
		// NumInputStreams, const D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1 *pInputArguments );
		[PreserveSig]
		new void ProcessFrames1([In] ID3D12VideoProcessor pVideoProcessor, in D3D12_VIDEO_PROCESS_OUTPUT_STREAM_ARGUMENTS pOutputArguments,
			uint NumInputStreams, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D12_VIDEO_PROCESS_INPUT_STREAM_ARGUMENTS1[] pInputArguments);

		/// <summary>
		/// Specifies whether or not protected resources can be accessed by subsequent commands in the video process command list. By
		/// default, no protected resources are enabled. After calling <b>SetProtectedResourceSession</b> with a valid session, protected
		/// resources of the same type can refer to that session. After calling <b>SetProtectedResourceSession</b> with <b>NULL</b>, no
		/// protected resources can be accessed.
		/// </summary>
		/// <param name="pProtectedResourceSession">
		/// An optional pointer to an <c>ID3D12ProtectedResourceSession</c>. You can obtain an <b>ID3D12ProtectedResourceSession</b> by
		/// calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist2-setprotectedresourcesession
		// void SetProtectedResourceSession( ID3D12ProtectedResourceSession *pProtectedResourceSession );
		[PreserveSig]
		new void SetProtectedResourceSession([In, Optional] ID3D12ProtectedResourceSession? pProtectedResourceSession);

		/// <summary>Records a command to initializes or re-initializes a video extension command into a video processor command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to initialize. The caller is
		/// responsible for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pInitializationParameters">
		/// A pointer to the creation parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_INITIALIZATION</c>.
		/// </param>
		/// <param name="InitializationParametersSizeInBytes">The size of the pInitializationParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist2-initializeextensioncommand
		// void InitializeExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pInitializationParameters, SIZE_T
		// InitializationParametersSizeInBytes );
		[PreserveSig]
		new void InitializeExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pInitializationParameters, SizeT InitializationParametersSizeInBytes);

		/// <summary>Records a command to execute a video extension command into a video process command list.</summary>
		/// <param name="pExtensionCommand">
		/// Pointer to an <c>ID3D12VideoExtensionCommand</c> representing the video extension command to execute. The caller is responsible
		/// for maintaining object lifetime until command execution is complete.
		/// </param>
		/// <param name="pExecutionParameters">
		/// A pointer to the execution parameters structure, which is defined by the command. The parameters structure must match the
		/// parameters enumerated by a call to <c>ID3D12VideoDevice::CheckFeatureSupport</c> with the feature value of
		/// <c>D3D12_FEATURE_VIDEO_EXTENSION_COMMAND_PARAMETERS</c> and a parameter stage value of <c>D3D12_VIDEO_EXTENSION_COMMAND_PARAMETER_STAGE_EXECUTION</c>.
		/// </param>
		/// <param name="ExecutionParametersSizeInBytes">The size of the pExecutionParameters parameter structure, in bytes.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Errors initializing the extension command are reported via debug layers and the return value of the command list's <c>Close</c> method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist2-executeextensioncommand
		// void ExecuteExtensionCommand( ID3D12VideoExtensionCommand *pExtensionCommand, const void *pExecutionParameters, SIZE_T
		// ExecutionParametersSizeInBytes );
		[PreserveSig]
		new void ExecuteExtensionCommand([In] ID3D12VideoExtensionCommand pExtensionCommand, [In] IntPtr pExecutionParameters, SizeT ExecutionParametersSizeInBytes);

		/// <summary>
		/// <para>Adds a collection of barriers into a video process command list recording.</para>
		/// <para>Requires the DirectX 12 Agility SDK 1.7 or later.</para>
		/// </summary>
		/// <param name="NumBarrierGroups">Number of barrier groups pointed to by pBarrierGroups.</param>
		/// <param name="pBarrierGroups">Pointer to an array of <c>D3D12_BARRIER_GROUP</c> objects.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocesscommandlist3-barrier void Barrier(
		// UINT32 NumBarrierGroups, const D3D12_BARRIER_GROUP *pBarrierGroups );
		[PreserveSig]
		void Barrier(int NumBarrierGroups, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_BARRIER_GROUP[] pBarrierGroups);
	}

	/// <summary>
	/// Provides methods for getting information about the parameters to the call to <c>ID3D12VideoDevice::CreateVideoProcessor</c> that
	/// created the video processor.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoprocessor
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoProcessor")]
	[ComImport, Guid("304fdb32-bede-410a-8545-943ac6a46138"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoProcessor : ID3D12Pageable
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>The node mask specifying the physical adapter on which the video processor will be used.</summary>
		/// <returns>This method returns a UINT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getnodemask UINT GetNodeMask();
		[PreserveSig]
		uint GetNodeMask();

		/// <summary>Gets the number of input stream descriptions provided when the video processor was created with a call to <c>ID3D12VideoDevice::CreateVideoProcessor</c>.</summary>
		/// <returns>
		/// This method returns UINT. Use this value to determine the correct size of the array you pass in the pInputStreamDescs parameter
		/// to <c>ID3D12VideoProcessor::GetInputStreamDescs</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getnuminputstreamdescs UINT GetNumInputStreamDescs();
		[PreserveSig]
		uint GetNumInputStreamDescs();

		/// <summary>Gets the input stream descriptions provided when the video processor was created with a call to <c>ID3D12VideoDevice::CreateVideoProcessor</c>.</summary>
		/// <param name="NumInputStreamDescs">
		/// The size of the array pointed to by pInputStreamDescs. Get the number of input stream descriptions associated with the video
		/// processor by calling <c>ID3DVideoProcessor::GetNumInputStreamDescs</c>.
		/// </param>
		/// <param name="pInputStreamDescs">
		/// An array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC</c> structures that is populated with the input stream descriptions
		/// associated with the video processor.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getinputstreamdescs HRESULT
		// GetInputStreamDescs( UINT NumInputStreamDescs, D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs );
		[PreserveSig]
		HRESULT GetInputStreamDescs(int NumInputStreamDescs, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs);

		/// <summary>Gets the output stream description provided when the video processor was created with a call to <c>ID3D12VideoDevice::CreateVideoProcessor</c>.</summary>
		/// <returns>This method returns <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getoutputstreamdesc
		// D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC GetOutputStreamDesc();
		[PreserveSig]
		void GetOutputStreamDesc(out D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC size);
	}

	/// <summary>
	/// Provides methods for getting information about the parameters to the call to <c>ID3D12VideoDevice2::CreateVideoProcessor1</c> that
	/// created the video processor.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nn-d3d12video-id3d12videoprocessor1
	[PInvokeData("d3d12video.h", MSDNShortId = "NN:d3d12video.ID3D12VideoProcessor1")]
	[ComImport, Guid("f3cfe615-553f-425c-86d8-ee8c1b1fb01c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VideoProcessor1 : ID3D12VideoProcessor
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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

		/// <summary>Gets a pointer to the device that created this interface.</summary>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// The globally unique identifier (<b>GUID</b>) for the device interface. The <b>REFIID</b>, or <b>GUID</b>, of the interface to
		/// the device can be obtained by using the __uuidof() macro. For example, __uuidof(<c>ID3D12Device</c>) will get the <b>GUID</b>
		/// of the interface to a device.
		/// </para>
		/// </param>
		/// <param name="ppvDevice">
		/// <para>Type: <b>void**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the <c>ID3D12Device</c> interface for the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces have their reference count incremented by one, so be sure to call ::release() on the returned pointers
		/// before they are freed or else you will have a memory leak.
		///  Examples The <c>D3D12Multithreading</c> sample uses <b>ID3D12DeviceChild::GetDevice</b> as follows:</para>
		/// <code language="cpp">
		///<![CDATA[// Returns required size of a buffer to be used for data upload
		///inline UINT64 GetRequiredIntermediateSize(
		///   _In_ ID3D12Resource* pDestinationResource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		///   _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources)
		///{
		///   D3D12_RESOURCE_DESC Desc = pDestinationResource->GetDesc();
		///   UINT64 RequiredSize = 0;
		///
		///   ID3D12Device* pDevice;
		///   pDestinationResource->GetDevice(__uuidof(*pDevice), reinterpret_cast<void**>(&pDevice));
		///   pDevice->GetCopyableFootprints(&Desc, FirstSubresource, NumSubresources, 0, nullptr, nullptr, nullptr, &RequiredSize);
		///   pDevice->Release();
		///
		///   return RequiredSize;
		///}]]>
		/// </code>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12devicechild-getdevice HRESULT GetDevice( REFIID riid,
		// [out, optional] void **ppvDevice );
		[PreserveSig]
		new HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);

		/// <summary>The node mask specifying the physical adapter on which the video processor will be used.</summary>
		/// <returns>This method returns a UINT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getnodemask UINT GetNodeMask();
		[PreserveSig]
		new uint GetNodeMask();

		/// <summary>Gets the number of input stream descriptions provided when the video processor was created with a call to <c>ID3D12VideoDevice::CreateVideoProcessor</c>.</summary>
		/// <returns>
		/// This method returns UINT. Use this value to determine the correct size of the array you pass in the pInputStreamDescs parameter
		/// to <c>ID3D12VideoProcessor::GetInputStreamDescs</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getnuminputstreamdescs UINT GetNumInputStreamDescs();
		[PreserveSig]
		new uint GetNumInputStreamDescs();

		/// <summary>Gets the input stream descriptions provided when the video processor was created with a call to <c>ID3D12VideoDevice::CreateVideoProcessor</c>.</summary>
		/// <param name="NumInputStreamDescs">
		/// The size of the array pointed to by pInputStreamDescs. Get the number of input stream descriptions associated with the video
		/// processor by calling <c>ID3DVideoProcessor::GetNumInputStreamDescs</c>.
		/// </param>
		/// <param name="pInputStreamDescs">
		/// An array of <c>D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC</c> structures that is populated with the input stream descriptions
		/// associated with the video processor.
		/// </param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getinputstreamdescs HRESULT
		// GetInputStreamDescs( UINT NumInputStreamDescs, D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC *pInputStreamDescs );
		[PreserveSig]
		new HRESULT GetInputStreamDescs(int NumInputStreamDescs, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_VIDEO_PROCESS_INPUT_STREAM_DESC[] pInputStreamDescs);

		/// <summary>Gets the output stream description provided when the video processor was created with a call to <c>ID3D12VideoDevice::CreateVideoProcessor</c>.</summary>
		/// <returns>This method returns <c>D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC</c>.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor-getoutputstreamdesc
		// D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC GetOutputStreamDesc();
		[PreserveSig]
		new void GetOutputStreamDesc(out D3D12_VIDEO_PROCESS_OUTPUT_STREAM_DESC size);

		/// <summary>
		/// Gets the <c>ID3D12ProtectedResourceSession</c> that was passed into <c>ID3D12VideoDevice2::CreateVideoProcessor1</c> when the
		/// <c>ID3D12VideoProcessor1</c> was created.
		/// </summary>
		/// <param name="riid">The globally unique identifier (GUID) for the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <param name="ppProtectedSession">Receives a void pointer representing the <b>ID3D12ProtectedResourceSession</b> interface.</param>
		/// <returns>This method returns HRESULT.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12video/nf-d3d12video-id3d12videoprocessor1-getprotectedresourcesession
		// HRESULT GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>Gets information about the features that are supported by the current video driver.</summary>
	/// <typeparam name="T">The type of the structure associated with <paramref name="FeatureVideo"/>.</typeparam>
	/// <param name="device">The <see cref="ID3D12VideoDevice"/> instance.</param>
	/// <param name="pFeatureSupportData">
	/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon the
	/// completion of the call, is populated with details about the level of support available. For information on the structure that is
	/// associated with each type of feature support request, see the field descriptions for <c>D3D12_FEATURE_VIDEO</c>.
	/// </param>
	/// <param name="FeatureVideo">A member of the <c>D3D12_FEATURE_VIDEO</c> enumeration that specifies the feature to query for support.</param>
	/// <returns>
	/// Returns <b>S_OK</b> if successful; otherwise, returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
	/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
	/// </returns>
	public static HRESULT CheckFeatureSupport<T>(this ID3D12VideoDevice device, ref T pFeatureSupportData, D3D12_FEATURE_VIDEO? FeatureVideo = null) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<T, D3D12_FEATURE_VIDEO>(FeatureVideo, out var f))
			return HRESULT.E_INVALIDARG;
		using SafeCoTaskMemStruct<T> mem = new(pFeatureSupportData);
		var hr = device.CheckFeatureSupport(f, mem, mem.Size);
		pFeatureSupportData = mem.Value;
		return hr;
	}

	/// <summary>Gets information about the features that are supported by the current video driver.</summary>
	/// <typeparam name="T">The type of the structure associated with <paramref name="FeatureVideo"/>.</typeparam>
	/// <param name="device">The <see cref="ID3D12VideoDevice"/> instance.</param>
	/// <param name="pFeatureSupportData">
	/// A structure that contains data that describes the configuration details of the feature for which support is requested and, upon the
	/// completion of the call, is populated with details about the level of support available. For information on the structure that is
	/// associated with each type of feature support request, see the field descriptions for <c>D3D12_FEATURE_VIDEO</c>.
	/// </param>
	/// <param name="FeatureVideo">A member of the <c>D3D12_FEATURE_VIDEO</c> enumeration that specifies the feature to query for support.</param>
	/// <returns>
	/// Returns <b>S_OK</b> if successful; otherwise, returns <b>E_INVALIDARG</b> if an unsupported data type is passed to the
	/// pFeatureSupportData parameter or a size mismatch is detected for the FeatureSupportDataSize parameter.
	/// </returns>
	public static HRESULT CheckFeatureSupport<T>(this ID3D12VideoDevice device, in T? pFeatureSupportData, D3D12_FEATURE_VIDEO? FeatureVideo = null) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<T, D3D12_FEATURE_VIDEO>(FeatureVideo, out var f))
			return HRESULT.E_INVALIDARG;
		using SafeCoTaskMemStruct<T> mem = pFeatureSupportData;
		return device.CheckFeatureSupport(f, mem, mem.Size);
	}
}