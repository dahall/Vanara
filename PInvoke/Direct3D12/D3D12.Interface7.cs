namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>
	/// A heap is an abstraction of contiguous memory allocation, used to manage physical memory. This heap can be used with
	/// <c>ID3D12Resource</c> objects to support placed resources or reserved resources.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12heap
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Heap")]
	[ComImport, Guid("6b3b2502-6e51-45b3-90ee-9884265e8df3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Heap : ID3D12Pageable
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

		/// <summary>Gets the heap description.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_HEAP_DESC</c></b></para>
		/// <para>Returns the <c>D3D12_HEAP_DESC</c> structure that describes the heap.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12heap-getdesc D3D12_HEAP_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_HEAP_DESC size);
	}

	/// <summary>The <b>ID3D12Heap1</b> interface inherits from the ID3D12Heap interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12heap1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Heap1")]
	[ComImport, Guid("572f7389-2168-49e3-9693-d6df5871bf6d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Heap1 : ID3D12Heap
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

		/// <summary>Gets the heap description.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_HEAP_DESC</c></b></para>
		/// <para>Returns the <c>D3D12_HEAP_DESC</c> structure that describes the heap.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12heap-getdesc D3D12_HEAP_DESC GetDesc();
		[PreserveSig]
		new void GetDesc(out D3D12_HEAP_DESC size);

		/// <summary/>
		/// <param name="riid"/>
		/// <param name="ppProtectedSession"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12heap1-getprotectedresourcesession HRESULT
		// GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>Represents an application-defined callback used for being notified of lifetime changes of an object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12lifetimeowner
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12LifetimeOwner")]
	[ComImport, Guid("e667af9f-cd56-4f46-83ce-032e595d70a8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12LifetimeOwner
	{
		/// <summary>Called when the lifetime state of a lifetime-tracked object changes.</summary>
		/// <param name="NewState">
		/// <para>Type: <b><c>D3D12_LIFETIME_STATE</c></b></para>
		/// <para>The new state.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12lifetimeowner-lifetimestateupdated void
		// LifetimeStateUpdated( D3D12_LIFETIME_STATE NewState );
		[PreserveSig]
		void LifetimeStateUpdated(D3D12_LIFETIME_STATE NewState);
	}

	/// <summary>Represents facilities for controlling the lifetime a lifetime-tracked object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12lifetimetracker
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12LifetimeTracker")]
	[ComImport, Guid("3fd03d36-4eb1-424a-a582-494ecb8ba813"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12LifetimeTracker : ID3D12DeviceChild
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

		/// <summary>Destroys a lifetime-tracked object.</summary>
		/// <param name="pObject">
		/// <para>Type: <b><c>ID3D12DeviceChild</c>*</b></para>
		/// <para>A pointer to an <b>ID3D12DeviceChild</b> interface representing the lifetime-tracked object.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12lifetimetracker-destroyownedobject HRESULT
		// DestroyOwnedObject( [in] ID3D12DeviceChild *pObject );
		[PreserveSig]
		HRESULT DestroyOwnedObject([In] ID3D12DeviceChild pObject);
	}

	/// <summary/>
	[PInvokeData("d3d12.h")]
	[ComImport, Guid("86ca3b85-49ad-4b6e-aed5-eddb18540f41"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ManualWriteTrackingResource
	{
		/// <summary/>
		[PreserveSig]
		void TrackWrite(uint Subresource, IntPtr pWrittenRange);
	}

	/// <summary>
	/// <para>
	/// Represents a meta command. A meta command is a Direct3D 12 object representing an algorithm that is accelerated by independent
	/// hardware vendors (IHVs). It's an opaque reference to a command generator that is implemented by the driver.
	/// </para>
	/// <para>
	/// The lifetime of a meta command is tied to the lifetime of the command list that references it. So, you should only free a meta
	/// command if no command list referencing it is currently executing on the GPU.
	/// </para>
	/// <para>
	/// A meta command can encapsulate a set of pipeline state objects (PSOs), bindings, intermediate resource states, and Draw/Dispatch
	/// calls. You can think of the signature of a meta command as being similar to a C-style function, with multiple in/out parameters, and
	/// no return value.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12metacommand
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12MetaCommand")]
	[ComImport, Guid("dbb84c27-36ce-4fc9-b801-f048c46ac570"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12MetaCommand : ID3D12Pageable
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
		/// Retrieves the amount of memory required for the specified runtime parameter resource for a meta command, for the specified stage.
		/// </summary>
		/// <param name="Stage">
		/// <para>Type: <b>D3D12_META_COMMAND_PARAMETER_STAGE</b></para>
		/// <para>A <b>D3D12_META_COMMAND_PARAMETER_STAGE</b> specifying the stage to which the parameter belongs.</para>
		/// </param>
		/// <param name="ParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The zero-based index of the parameter within the stage.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The number of bytes required for the specified runtime parameter resource.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12metacommand-getrequiredparameterresourcesize UINT64
		// GetRequiredParameterResourceSize( [in] D3D12_META_COMMAND_PARAMETER_STAGE Stage, [in] UINT ParameterIndex );
		[PreserveSig]
		ulong GetRequiredParameterResourceSize(D3D12_META_COMMAND_PARAMETER_STAGE Stage, uint ParameterIndex);
	}

	/// <summary>
	/// An interface from which <c>ID3D12Device</c> and <c>ID3D12DeviceChild</c> inherit from. It provides methods to associate private data
	/// and annotate object names.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12object
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Object")]
	[ComImport, Guid("c4fec28f-7966-4e95-9f94-f431cb56c3b8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Object
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
		HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

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
		HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

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
		HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

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
		HRESULT SetName([MarshalAs(UnmanagedType.LPWStr)] string Name);
	}

	/// <summary>
	/// An interface from which many other core interfaces inherit from. It indicates that the object type encapsulates some amount of
	/// GPU-accessible memory; but does not strongly indicate whether the application can manipulate the object's residency.
	/// </summary>
	/// <remarks>For more details, refer to <c>Memory Management in Direct3D 12</c> and the <c>MakeResident</c> method reference.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pageable
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Pageable")]
	[ComImport, Guid("63ee58fb-1268-4835-86da-f008ce62f0d6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Pageable : ID3D12DeviceChild
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
	}

	/// <summary>Manages a pipeline library, in particular loading and retrieving individual PSOs.</summary>
	/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pipelinelibrary
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12PipelineLibrary")]
	[ComImport, Guid("c64226a8-9201-46af-b4cc-53fb9ff7414f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12PipelineLibrary : ID3D12DeviceChild
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

		/// <summary>Adds the input PSO to an internal database with the corresponding name.</summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>Specifies a unique name for the library. Overwriting is not supported.</para>
		/// </param>
		/// <param name="pPipeline">
		/// <para>Type: <b>ID3D12PipelineState*</b></para>
		/// <para>Specifies the <c>ID3D12PipelineState</c> to add.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, including E_INVALIDARG if the name already exists, E_OUTOFMEMORY if unable
		/// to allocate storage in the library.
		/// </para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-storepipeline HRESULT StorePipeline(
		// [in, optional] LPCWSTR pName, [in] ID3D12PipelineState *pPipeline );
		[PreserveSig]
		HRESULT StorePipeline([MarshalAs(UnmanagedType.LPWStr)] string? pName, [In] ID3D12PipelineState pPipeline);

		/// <summary>Retrieves the requested PSO from the library.</summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The unique name of the PSO.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>
		/// Specifies a description of the required PSO in a <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure. This input description is
		/// matched against the data in the current library database, and stored in order to prevent duplication of PSO contents.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a REFIID for the <c>ID3D12PipelineState</c> object. Typically set this, and the following parameter, with the macro
		/// <c>IID_PPV_ARGS(&amp;PSO1)</c>, where <i>PSO1</i> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer that will reference the returned PSO.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, which can include E_INVALIDARG if the name doesn’t exist, or if the input
		/// description doesn’t match the data in the library, and E_OUTOFMEMORY if unable to allocate the return PSO.
		/// </para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-loadgraphicspipeline HRESULT
		// LoadGraphicsPipeline( [in] LPCWSTR pName, [in] const D3D12_GRAPHICS_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void
		// **ppPipelineState );
		[PreserveSig]
		HRESULT LoadGraphicsPipeline([MarshalAs(UnmanagedType.LPWStr)] string pName, in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppPipelineState);

		/// <summary>
		/// Retrieves the requested PSO from the library. The input desc is matched against the data in the current library database, and
		/// remembered in order to prevent duplication of PSO contents.
		/// </summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The unique name of the PSO.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>
		/// Specifies a description of the required PSO in a <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structure. This input description is
		/// matched against the data in the current library database, and stored in order to prevent duplication of PSO contents.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a REFIID for the <c>ID3D12PipelineState</c> object. Typically set this, and the following parameter, with the macro
		/// <c>IID_PPV_ARGS(&amp;PSO1)</c>, where <i>PSO1</i> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer that will reference the returned PSO.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, which can include E_INVALIDARG if the name doesn’t exist, or if the input
		/// description doesn’t match the data in the library, and E_OUTOFMEMORY if unable to allocate the return PSO.
		/// </para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-loadcomputepipeline HRESULT
		// LoadComputePipeline( [in] LPCWSTR pName, [in] const D3D12_COMPUTE_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void
		// **ppPipelineState );
		[PreserveSig]
		HRESULT LoadComputePipeline([MarshalAs(UnmanagedType.LPWStr)] string pName, in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppPipelineState);

		/// <summary>Returns the amount of memory required to serialize the current contents of the database.</summary>
		/// <returns>
		/// <para>Type: <b>SIZE_T</b></para>
		/// <para>This method returns a SIZE_T object, containing the size required in bytes.</para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-getserializedsize SIZE_T GetSerializedSize();
		[PreserveSig]
		SIZE_T GetSerializedSize();

		/// <summary>Writes the contents of the library to the provided memory, to be provided back to the runtime at a later time.</summary>
		/// <param name="pData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// Specifies a pointer to the data. This memory must be readable and writable up to the input size. This data can be saved and
		/// provided to <c>CreatePipelineLibrary</c> at a later time, including future instances of this or other processes. The data
		/// becomes invalidated if the runtime or driver is updated, and is not portable to other hardware or devices.
		/// </para>
		/// </param>
		/// <param name="DataSizeInBytes">
		/// <para>Type: <b>SIZE_T</b></para>
		/// <para>The size provided must be at least the size returned from <c>GetSerializedSize</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code, including E_INVALIDARG if the buffer provided isn’t big enough.</para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-serialize HRESULT Serialize( [out] void
		// *pData, SIZE_T DataSizeInBytes );
		[PreserveSig]
		HRESULT Serialize([Out] IntPtr pData, SIZE_T DataSizeInBytes);
	}

	/// <summary>
	/// Manages a pipeline library. This interface extends <c>ID3D12PipelineLibrary</c> to load PSOs from a pipeline state stream description.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pipelinelibrary1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12PipelineLibrary1")]
	[ComImport, Guid("80eabf42-2568-4e5e-bd82-c37f86961dc3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12PipelineLibrary1 : ID3D12PipelineLibrary
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

		/// <summary>Adds the input PSO to an internal database with the corresponding name.</summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>Specifies a unique name for the library. Overwriting is not supported.</para>
		/// </param>
		/// <param name="pPipeline">
		/// <para>Type: <b>ID3D12PipelineState*</b></para>
		/// <para>Specifies the <c>ID3D12PipelineState</c> to add.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, including E_INVALIDARG if the name already exists, E_OUTOFMEMORY if unable
		/// to allocate storage in the library.
		/// </para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-storepipeline HRESULT StorePipeline(
		// [in, optional] LPCWSTR pName, [in] ID3D12PipelineState *pPipeline );
		[PreserveSig]
		new HRESULT StorePipeline([MarshalAs(UnmanagedType.LPWStr)] string? pName, [In] ID3D12PipelineState pPipeline);

		/// <summary>Retrieves the requested PSO from the library.</summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The unique name of the PSO.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>
		/// Specifies a description of the required PSO in a <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure. This input description is
		/// matched against the data in the current library database, and stored in order to prevent duplication of PSO contents.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a REFIID for the <c>ID3D12PipelineState</c> object. Typically set this, and the following parameter, with the macro
		/// <c>IID_PPV_ARGS(&amp;PSO1)</c>, where <i>PSO1</i> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer that will reference the returned PSO.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, which can include E_INVALIDARG if the name doesn’t exist, or if the input
		/// description doesn’t match the data in the library, and E_OUTOFMEMORY if unable to allocate the return PSO.
		/// </para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-loadgraphicspipeline HRESULT
		// LoadGraphicsPipeline( [in] LPCWSTR pName, [in] const D3D12_GRAPHICS_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void
		// **ppPipelineState );
		[PreserveSig]
		new HRESULT LoadGraphicsPipeline([MarshalAs(UnmanagedType.LPWStr)] string pName, in D3D12_GRAPHICS_PIPELINE_STATE_DESC pDesc,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppPipelineState);

		/// <summary>
		/// Retrieves the requested PSO from the library. The input desc is matched against the data in the current library database, and
		/// remembered in order to prevent duplication of PSO contents.
		/// </summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para>The unique name of the PSO.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c>*</b></para>
		/// <para>
		/// Specifies a description of the required PSO in a <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structure. This input description is
		/// matched against the data in the current library database, and stored in order to prevent duplication of PSO contents.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>
		/// Specifies a REFIID for the <c>ID3D12PipelineState</c> object. Typically set this, and the following parameter, with the macro
		/// <c>IID_PPV_ARGS(&amp;PSO1)</c>, where <i>PSO1</i> is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para>Specifies a pointer that will reference the returned PSO.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, which can include E_INVALIDARG if the name doesn’t exist, or if the input
		/// description doesn’t match the data in the library, and E_OUTOFMEMORY if unable to allocate the return PSO.
		/// </para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-loadcomputepipeline HRESULT
		// LoadComputePipeline( [in] LPCWSTR pName, [in] const D3D12_COMPUTE_PIPELINE_STATE_DESC *pDesc, REFIID riid, [out] void
		// **ppPipelineState );
		[PreserveSig]
		new HRESULT LoadComputePipeline([MarshalAs(UnmanagedType.LPWStr)] string pName, in D3D12_COMPUTE_PIPELINE_STATE_DESC pDesc,
			in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppPipelineState);

		/// <summary>Returns the amount of memory required to serialize the current contents of the database.</summary>
		/// <returns>
		/// <para>Type: <b>SIZE_T</b></para>
		/// <para>This method returns a SIZE_T object, containing the size required in bytes.</para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-getserializedsize SIZE_T GetSerializedSize();
		[PreserveSig]
		new SIZE_T GetSerializedSize();

		/// <summary>Writes the contents of the library to the provided memory, to be provided back to the runtime at a later time.</summary>
		/// <param name="pData">
		/// <para>Type: <b>void*</b></para>
		/// <para>
		/// Specifies a pointer to the data. This memory must be readable and writable up to the input size. This data can be saved and
		/// provided to <c>CreatePipelineLibrary</c> at a later time, including future instances of this or other processes. The data
		/// becomes invalidated if the runtime or driver is updated, and is not portable to other hardware or devices.
		/// </para>
		/// </param>
		/// <param name="DataSizeInBytes">
		/// <para>Type: <b>SIZE_T</b></para>
		/// <para>The size provided must be at least the size returned from <c>GetSerializedSize</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code, including E_INVALIDARG if the buffer provided isn’t big enough.</para>
		/// </returns>
		/// <remarks>Refer to the remarks and examples for <c>CreatePipelineLibrary</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary-serialize HRESULT Serialize( [out] void
		// *pData, SIZE_T DataSizeInBytes );
		[PreserveSig]
		new HRESULT Serialize([Out] IntPtr pData, SIZE_T DataSizeInBytes);

		/// <summary>
		/// Retrieves the requested PSO from the library. The pipeline stream description is matched against the library database, and
		/// remembered in order to prevent duplication of PSO contents.
		/// </summary>
		/// <param name="pName">
		/// <para>Type: <b>LPCWSTR</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The unique name of the PSO.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <b>const <c>D3D12_PIPELINE_STATE_STREAM_DESC</c>*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Describes the required PSO using a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> structure. This description is matched against the
		/// library database, and stored in order to prevent duplication of PSO contents.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <b>REFIID</b></para>
		/// <para>Specifies a REFIID for the <c>ID3D12PipelineState</c> object.</para>
		/// <para>
		/// Your app should typically set this argument and the following argument, ppPipelineState, by using the macro
		/// IID_PPV_ARGS(&amp;PSO1), where PSO1 is the name of the object.
		/// </para>
		/// </param>
		/// <param name="ppPipelineState">
		/// <para>Type: <b>void**</b></para>
		/// <para><c>SAL</c>: <c>COM_Outptr</c></para>
		/// <para>Specifies the pointer that will reference the PSO after the function successfully returns.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns an HRESULT success or error code, which can include E_INVALIDARG if the name doesn't exist or the stream
		/// description doesn't match the data in the library, and E_OUTOFMEMORY if the function is unable to allocate the resulting PSO.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function takes the pipeline description as a <c>D3D12_PIPELINE_STATE_STREAM_DESC</c> and is a replacement for the
		/// <c>ID3D12PipelineLibrary::LoadGraphicsPipeline</c> and <c>ID3D12PipelineLibrary::LoadComputePipeline</c> functions, which take
		/// their pipeline description as the less-flexible <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> and
		/// <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structs, respectively.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinelibrary1-loadpipeline HRESULT LoadPipeline( [in]
		// LPCWSTR pName, [in] const D3D12_PIPELINE_STATE_STREAM_DESC *pDesc, REFIID riid, [out] void **ppPipelineState );
		[PreserveSig]
		HRESULT LoadPipeline([MarshalAs(UnmanagedType.LPWStr)] string pName, in D3D12_PIPELINE_STATE_STREAM_DESC pDesc, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppPipelineState);
	}

	/// <summary>Represents the state of all currently set shaders as well as certain fixed function state objects.</summary>
	/// <remarks>
	/// <para>
	/// Use <c>ID3D12Device::CreateGraphicsPipelineState</c> or <c>ID3D12Device::CreateComputePipelineState</c> to create a pipeline state
	/// object (PSO).
	/// </para>
	/// <para>
	/// A pipeline state object corresponds to a significant portion of the state of the graphics processing unit (GPU). This state includes
	/// all currently set shaders and certain fixed function state objects. The only way to change states contained within the pipeline
	/// object is to change the currently bound pipeline object.
	/// </para>
	/// <para>Examples</para>
	/// <para>The <c>D3D12DynamicIndexing</c> sample uses <b>ID3D12PipelineState</b> as follows:</para>
	/// <para>Declare the pipeline objects.</para>
	/// <para>
	/// <c>// Asset objects. ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState; ComPtr&lt;ID3D12PipelineState&gt; m_computeState;
	/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; ComPtr&lt;ID3D12Resource&gt; m_vertexBuffer; ComPtr&lt;ID3D12Resource&gt;
	/// m_vertexBufferUpload; D3D12_VERTEX_BUFFER_VIEW m_vertexBufferView; ComPtr&lt;ID3D12Resource&gt; m_particleBuffer0[ThreadCount];
	/// ComPtr&lt;ID3D12Resource&gt; m_particleBuffer1[ThreadCount]; ComPtr&lt;ID3D12Resource&gt; m_particleBuffer0Upload[ThreadCount];
	/// ComPtr&lt;ID3D12Resource&gt; m_particleBuffer1Upload[ThreadCount]; ComPtr&lt;ID3D12Resource&gt; m_constantBufferGS; UINT8*
	/// m_pConstantBufferGSData; ComPtr&lt;ID3D12Resource&gt; m_constantBufferCS;</c>
	/// </para>
	/// <para>Initializing a bundle.</para>
	/// <para>
	/// <c>void FrameResource::InitBundle(ID3D12Device* pDevice, ID3D12PipelineState* pPso, UINT frameResourceIndex, UINT numIndices,
	/// D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc, D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap*
	/// pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize, ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature)
	/// { ThrowIfFailed(pDevice-&gt;CreateCommandList(0, D3D12_COMMAND_LIST_TYPE_BUNDLE, m_bundleAllocator.Get(), pPso,
	/// IID_PPV_ARGS(&amp;m_bundle))); PopulateCommandList(m_bundle.Get(), pPso, frameResourceIndex, numIndices, pIndexBufferViewDesc,
	/// pVertexBufferViewDesc, pCbvSrvDescriptorHeap, cbvSrvDescriptorSize, pSamplerDescriptorHeap, pRootSignature);
	/// ThrowIfFailed(m_bundle-&gt;Close()); }</c>
	/// </para>
	/// <para>The <c>D3D12Bundles</c> sample uses <b>ID3D12PipelineState</b> as follows:</para>
	/// <para>Populating the command lists, note the alternating PSO.</para>
	/// <para>
	/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1, ID3D12PipelineState*
	/// pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc, D3D12_VERTEX_BUFFER_VIEW*
	/// pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize, ID3D12DescriptorHeap*
	/// pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root signature of the caller,
	/// then // bindings are inherited, otherwise the bind space is reset. pCommandList-&gt;SetGraphicsRootSignature(pRootSignature);
	/// ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap, pSamplerDescriptorHeap };
	/// pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
	/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
	/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
	/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
	/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); // Calculate
	/// the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
	/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
	/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset, cbvSrvDescriptorSize);
	/// BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt; m_cityColumnCount; j++) { // Alternate
	/// which PSO to use; the pixel shader is different on // each just as a PSO setting demonstration.
	/// pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and move to the next
	/// descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle); cbvSrvHandle.Offset(cbvSrvDescriptorSize);
	/// pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pipelinestate
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12PipelineState")]
	[ComImport, Guid("765a30f3-f624-4c6f-a828-ace948622445"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12PipelineState : ID3D12Pageable
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

		/// <summary>Gets the cached blob representing the pipeline state.</summary>
		/// <param name="ppBlob">
		/// <para>Type: <b>ID3DBlob**</b></para>
		/// <para>After this method returns, points to the cached blob representing the pipeline state.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>Refer to the remarks for <c>D3D12_CACHED_PIPELINE_STATE</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12pipelinestate-getcachedblob HRESULT GetCachedBlob( [out]
		// ID3DBlob **ppBlob );
		[PreserveSig]
		HRESULT GetCachedBlob(out ID3DBlob ppBlob);
	}

	/// <summary>
	/// <para>Monitors the validity of a protected resource session. This interface extends <c>ID3D12ProtectedSession</c>.</para>
	/// <para>You can obtain an <b>ID3D12ProtectedResourceSession</b> by calling <c>ID3D12Device4::CreateProtectedResourceSession</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12protectedresourcesession
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12ProtectedResourceSession")]
	[ComImport, Guid("6cd696f4-f289-40cc-8091-5a6c0a099c3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ProtectedResourceSession : ID3D12ProtectedSession
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
		/// Retrieves the fence for the protected session. From the fence, you can retrieve the current uniqueness validity value (using
		/// <c>ID3D12Fence::GetCompletedValue</c>), and add monitors for changes to its value. This is a read-only fence.
		/// </summary>
		/// <param name="riid">
		/// The GUID of the interface to a fence. Most commonly, <c>ID3D12Fence</c>, although it may be any GUID for any interface. If the
		/// protected session object doesn’t support the interface for this GUID, the function returns <b>E_NOINTERFACE</b>.
		/// </param>
		/// <param name="ppFence">A pointer to a memory block that receives a pointer to the fence for the given protected session.</param>
		/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedsession-getstatusfence HRESULT GetStatusFence(
		// REFIID riid, [optional] void **ppFence );
		[PreserveSig]
		new HRESULT GetStatusFence(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppFence);

		/// <summary>Gets the status of the protected session.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_PROTECTED_SESSION_STATUS</c></b></para>
		/// <para>
		/// The status of the protected session. If the returned value is <c>D3D12_PROTECTED_SESSION_STATUS_INVALID</c>, then you need to
		/// wait for a uniqueness value bump to reuse the resource if the session is an <c>ID3D12ProtectedResourceSession</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedsession-getsessionstatus
		// D3D12_PROTECTED_SESSION_STATUS GetSessionStatus();
		[PreserveSig]
		new D3D12_PROTECTED_SESSION_STATUS GetSessionStatus();

		/// <summary>Retrieves a description of the protected resource session.</summary>
		/// <returns>A <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC</c> that describes the protected resource session.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedresourcesession-getdesc
		// D3D12_PROTECTED_RESOURCE_SESSION_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_PROTECTED_RESOURCE_SESSION_DESC size);
	}

	/// <summary>
	/// <para>Monitors the validity of a protected resource session. This interface extends <c>ID3D12ProtectedSession</c>.</para>
	/// <para>You can obtain an <b>ID3D12ProtectedResourceSession1</b> by calling <c>ID3D12Device7::CreateProtectedResourceSession1</c>.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12protectedresourcesession1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12ProtectedResourceSession1")]
	[ComImport, Guid("d6f12dd6-76fb-406e-8961-4296eefc0409"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ProtectedResourceSession1 : ID3D12ProtectedResourceSession
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
		/// Retrieves the fence for the protected session. From the fence, you can retrieve the current uniqueness validity value (using
		/// <c>ID3D12Fence::GetCompletedValue</c>), and add monitors for changes to its value. This is a read-only fence.
		/// </summary>
		/// <param name="riid">
		/// The GUID of the interface to a fence. Most commonly, <c>ID3D12Fence</c>, although it may be any GUID for any interface. If the
		/// protected session object doesn’t support the interface for this GUID, the function returns <b>E_NOINTERFACE</b>.
		/// </param>
		/// <param name="ppFence">A pointer to a memory block that receives a pointer to the fence for the given protected session.</param>
		/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedsession-getstatusfence HRESULT GetStatusFence(
		// REFIID riid, [optional] void **ppFence );
		[PreserveSig]
		new HRESULT GetStatusFence(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppFence);

		/// <summary>Gets the status of the protected session.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_PROTECTED_SESSION_STATUS</c></b></para>
		/// <para>
		/// The status of the protected session. If the returned value is <c>D3D12_PROTECTED_SESSION_STATUS_INVALID</c>, then you need to
		/// wait for a uniqueness value bump to reuse the resource if the session is an <c>ID3D12ProtectedResourceSession</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedsession-getsessionstatus
		// D3D12_PROTECTED_SESSION_STATUS GetSessionStatus();
		[PreserveSig]
		new D3D12_PROTECTED_SESSION_STATUS GetSessionStatus();

		/// <summary>Retrieves a description of the protected resource session.</summary>
		/// <returns>A <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC</c> that describes the protected resource session.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedresourcesession-getdesc
		// D3D12_PROTECTED_RESOURCE_SESSION_DESC GetDesc();
		[PreserveSig]
		new void GetDesc(out D3D12_PROTECTED_RESOURCE_SESSION_DESC size);

		/// <summary>Retrieves a description of the protected resource session.</summary>
		/// <returns>A <c>D3D12_PROTECTED_RESOURCE_SESSION_DESC1</c> that describes the protected resource session.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedresourcesession1-getdesc1
		// D3D12_PROTECTED_RESOURCE_SESSION_DESC1 GetDesc1();
		[PreserveSig]
		D3D12_PROTECTED_RESOURCE_SESSION_DESC1 GetDesc1();
	}

	/// <summary>
	/// Offers base functionality that allows for a consistent way to monitor the validity of a session across the different types of
	/// sessions. The only type of session currently available is of type <c>ID3D12ProtectedResourceSession</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12protectedsession
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12ProtectedSession")]
	[ComImport, Guid("a1533d18-0ac1-4084-85b9-89a96116806b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ProtectedSession : ID3D12DeviceChild
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
		/// Retrieves the fence for the protected session. From the fence, you can retrieve the current uniqueness validity value (using
		/// <c>ID3D12Fence::GetCompletedValue</c>), and add monitors for changes to its value. This is a read-only fence.
		/// </summary>
		/// <param name="riid">
		/// The GUID of the interface to a fence. Most commonly, <c>ID3D12Fence</c>, although it may be any GUID for any interface. If the
		/// protected session object doesn’t support the interface for this GUID, the function returns <b>E_NOINTERFACE</b>.
		/// </param>
		/// <param name="ppFence">A pointer to a memory block that receives a pointer to the fence for the given protected session.</param>
		/// <returns>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedsession-getstatusfence HRESULT GetStatusFence(
		// REFIID riid, [optional] void **ppFence );
		[PreserveSig]
		HRESULT GetStatusFence(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppFence);

		/// <summary>Gets the status of the protected session.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_PROTECTED_SESSION_STATUS</c></b></para>
		/// <para>
		/// The status of the protected session. If the returned value is <c>D3D12_PROTECTED_SESSION_STATUS_INVALID</c>, then you need to
		/// wait for a uniqueness value bump to reuse the resource if the session is an <c>ID3D12ProtectedResourceSession</c>.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12protectedsession-getsessionstatus
		// D3D12_PROTECTED_SESSION_STATUS GetSessionStatus();
		[PreserveSig]
		D3D12_PROTECTED_SESSION_STATUS GetSessionStatus();
	}

	/// <summary>Manages a query heap. A query heap holds an array of queries, referenced by indexes.</summary>
	/// <remarks>
	/// <para>For more information, refer to <c>Queries</c>.</para>
	/// <para>Examples</para>
	/// <para>The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12QueryHeap</b> as follows:</para>
	/// <para>Create a query heap and a query result buffer.</para>
	/// <para>
	/// <c>// Pipeline objects. D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain;
	/// ComPtr&lt;ID3D12Device&gt; m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt;
	/// m_commandAllocators[FrameCount]; ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
	/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12DescriptorHeap&gt; m_cbvHeap; ComPtr&lt;ID3D12DescriptorHeap&gt;
	/// m_dsvHeap; ComPtr&lt;ID3D12QueryHeap&gt; m_queryHeap; UINT m_rtvDescriptorSize; UINT m_cbvSrvDescriptorSize; UINT m_frameIndex; //
	/// Synchronization objects. ComPtr&lt;ID3D12Fence&gt; m_fence; UINT64 m_fenceValues[FrameCount]; HANDLE m_fenceEvent; // Asset objects.
	/// ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState; ComPtr&lt;ID3D12PipelineState&gt; m_queryState;
	/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; ComPtr&lt;ID3D12Resource&gt; m_vertexBuffer; ComPtr&lt;ID3D12Resource&gt;
	/// m_constantBuffer; ComPtr&lt;ID3D12Resource&gt; m_depthStencil; ComPtr&lt;ID3D12Resource&gt; m_queryResult; D3D12_VERTEX_BUFFER_VIEW m_vertexBufferView;</c>
	/// </para>
	/// <para>
	/// <c>// Describe and create a heap for occlusion queries. D3D12_QUERY_HEAP_DESC queryHeapDesc = {}; queryHeapDesc.Count = 1;
	/// queryHeapDesc.Type = D3D12_QUERY_HEAP_TYPE_OCCLUSION; ThrowIfFailed(m_device-&gt;CreateQueryHeap(&amp;queryHeapDesc, IID_PPV_ARGS(&amp;m_queryHeap)));</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12queryheap
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12QueryHeap")]
	[ComImport, Guid("0d9658ae-ed45-469e-a61d-970ec583cab4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12QueryHeap : ID3D12Pageable
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
	}

	/// <summary>
	/// Encapsulates a generalized ability of the CPU and GPU to read and write to physical memory, or heaps. It contains abstractions for
	/// organizing and manipulating simple arrays of data as well as multidimensional data optimized for shader sampling.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12resource
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Resource")]
	[ComImport, Guid("696442be-a72e-4059-bc79-5b5c98040fad"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Resource : ID3D12Pageable
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
		/// Gets a CPU pointer to the specified subresource in the resource, but may not disclose the pointer value to applications.
		/// <b>Map</b> also invalidates the CPU cache, when necessary, so that CPU reads to this address reflect any modifications made by
		/// the GPU.
		/// </summary>
		/// <param name="Subresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index number of the subresource.</para>
		/// </param>
		/// <param name="pReadRange">
		/// <para>Type: <b>const <c>D3D12_RANGE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to access.</para>
		/// <para>
		/// This indicates the region the CPU might read, and the coordinates are subresource-relative. A null pointer indicates the entire
		/// subresource might be read by the CPU. It is valid to specify the CPU won't read any data by passing a range where <b>End</b> is
		/// less than or equal to <b>Begin</b>.
		/// </para>
		/// </param>
		/// <param name="ppData">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the resource data.</para>
		/// <para>
		/// A null pointer is valid and is useful to cache a CPU virtual address range for methods like <c>WriteToSubresource</c>. When
		/// <i>ppData</i> is not NULL, the pointer returned is never offset by any values in <i>pReadRange</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>Map</b> and <c>Unmap</c> can be called by multiple threads safely. Nested <b>Map</b> calls are supported and are ref-counted.
		/// The first call to <b>Map</b> allocates a CPU virtual address range for the resource. The last call to <b>Unmap</b> deallocates
		/// the CPU virtual address range. The CPU virtual address is commonly returned to the application; but manipulating the contents of
		/// textures with unknown layouts precludes disclosing the CPU virtual address. See <c>WriteToSubresource</c> for more details.
		/// Applications cannot rely on the address being consistent, unless <b>Map</b> is persistently nested.
		/// </para>
		/// <para>
		/// Pointers returned by <b>Map</b> are not guaranteed to have all the capabilities of normal pointers, but most applications won't
		/// notice a difference in normal usage. For example, pointers with WRITE_COMBINE behavior have weaker CPU memory ordering
		/// guarantees than WRITE_BACK behavior. Memory accessible by both CPU and GPU are not guaranteed to share the same atomic memory
		/// guarantees that the CPU has, due to PCIe limitations. Use fences for synchronization.
		/// </para>
		/// <para>
		/// There are two usage model categories for <b>Map</b>, simple and advanced. The simple usage models maximize tool performance, so
		/// applications are recommended to stick with the simple models until the advanced models are proven to be required by the app.
		/// </para>
		/// <para><c></c><c></c><c></c> Simple Usage Models</para>
		/// <para>
		/// Applications should stick to the heap type abstractions of UPLOAD, DEFAULT, and READBACK, in order to support all adapter
		/// architectures reasonably well.
		/// </para>
		/// <para>
		/// Applications should avoid CPU reads from pointers to resources on UPLOAD heaps, even accidently. CPU reads will work, but are
		/// prohibitively slow on many common GPU architectures, so consider the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Don't make the CPU read from resources associated with heaps that are D3D12_HEAP_TYPE_UPLOAD or have D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The memory region to which <b>pData</b> points can be allocated with <c>PAGE_WRITECOMBINE</c>, and your app must honor all
		/// restrictions that are associated with such memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the
		/// following x86 assembly code.
		/// <para>C++ code:</para>
		/// <para>x86 assembly code:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can
		/// avoid the xor optimization by using a <b>volatile</b> pointer or by optimizing for code speed instead of code size.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications are encouraged to leave resources unmapped while the CPU will not modify them, and use tight, accurate ranges at
		/// all times. This enables the fastest modes for tools, like <c>Graphics Debugging</c> and the debug layer. Such tools need to
		/// track all CPU modifications to memory that the GPU could read.
		/// </para>
		/// <para><c></c><c></c><c></c> Advanced Usage Models</para>
		/// <para>
		/// Resources on CPU-accessible heaps can be persistently mapped, meaning <b>Map</b> can be called once, immediately after resource
		/// creation. <c>Unmap</c> never needs to be called, but the address returned from <b>Map</b> must no longer be used after the last
		/// reference to the resource is released. When using persistent map, the application must ensure the CPU finishes writing data into
		/// memory before the GPU executes a command list that reads or writes the memory. In common scenarios, the application merely must
		/// write to memory before calling <c>ExecuteCommandLists</c>; but using a fence to delay command list execution works as well.
		/// </para>
		/// <para>
		/// All CPU-accessible memory types support persistent mapping usage, where the resource is mapped but then never unmapped, provided
		/// the application does not access the pointer after the resource has been disposed.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12Resource::Map</b> as follows:</para>
		/// <para>Copy triangle data to the vertex buffer.</para>
		/// <para>
		/// <c>// Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE readRange(0, 0); // We do not intend
		/// to read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0, &amp;readRange,
		/// reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices, sizeof(triangleVertices));
		/// m_vertexBuffer-&gt;Unmap(0, nullptr);</c>
		/// </para>
		/// <para>Create an upload heap for the constant buffers.</para>
		/// <para>
		/// <c>// Create an upload heap for the constant buffers. ThrowIfFailed(pDevice-&gt;CreateCommittedResource(
		/// &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE,
		/// &amp;D3D12_RESOURCE_DESC::Buffer(sizeof(ConstantBuffer) * m_cityRowCount * m_cityColumnCount),
		/// D3D12_RESOURCE_STATE_GENERIC_READ, nullptr, IID_PPV_ARGS(&amp;m_cbvUploadHeap))); // Map the constant buffers. Note that unlike
		/// D3D11, the resource // does not need to be unmapped for use by the GPU. In this sample, // the resource stays 'permanently'
		/// mapped to avoid overhead with // mapping/unmapping each frame. CD3DX12_RANGE readRange(0, 0); // We do not intend to read from
		/// this resource on the CPU. ThrowIfFailed(m_cbvUploadHeap-&gt;Map(0, &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;m_pConstantBuffers)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-map HRESULT Map( UINT Subresource, [in,
		// optional] const D3D12_RANGE *pReadRange, [out, optional] void **ppData );
		[PreserveSig]
		HRESULT Map(uint Subresource, [In, Optional] StructPointer<D3D12_RANGE> pReadRange, [Out, Optional] IntPtr ppData);

		/// <summary>Invalidates the CPU pointer to the specified subresource in the resource.</summary>
		/// <param name="Subresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the subresource.</para>
		/// </param>
		/// <param name="pWrittenRange">
		/// <para>Type: <b>const <c>D3D12_RANGE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to unmap.</para>
		/// <para>
		/// This indicates the region the CPU might have modified, and the coordinates are subresource-relative. A null pointer indicates
		/// the entire subresource might have been modified by the CPU. It is valid to specify the CPU didn't write any data by passing a
		/// range where <b>End</b> is less than or equal to <b>Begin</b>.
		/// </para>
		/// <para>This parameter is only used by tooling, and not for correctness of the actual unmap operation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Refer to the extensive Remarks and Examples for the <c>Map</c> method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-unmap void Unmap( UINT Subresource, [in,
		// optional] const D3D12_RANGE *pWrittenRange );
		[PreserveSig]
		void Unmap(uint Subresource, [In, Optional] StructPointer<D3D12_RANGE> pWrittenRange);

		/// <summary>Gets the resource description.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_DESC</c></b></para>
		/// <para>A Direct3D 12 resource description structure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getdesc D3D12_RESOURCE_DESC GetDesc();
		[PreserveSig]
		void GetDesc(out D3D12_RESOURCE_DESC size);

		/// <summary>This method returns the GPU virtual address of a buffer resource.</summary>
		/// <returns>
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>This method returns the GPU virtual address. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd synonym of UINT64.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is only useful for buffer resources, it will return zero for all texture resources.</para>
		/// <para>For more information on the use of GPU virtual addresses, refer to <c>Indirect Drawing</c>. Examples The <c>D3D1211on12</c> sample uses <b>ID3D12Resource::GetGPUVirtualAddress</b> as follows:</para>
		/// <para>
		/// <c>// Initialize the vertex buffer view. m_vertexBufferView.BufferLocation = m_vertexBuffer-&gt;GetGPUVirtualAddress();
		/// m_vertexBufferView.StrideInBytes = sizeof(Vertex); m_vertexBufferView.SizeInBytes = vertexBufferSize;</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getgpuvirtualaddress D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress();
		[PreserveSig]
		D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress();

		/// <summary>
		/// Uses the CPU to copy data into a subresource, enabling the CPU to modify the contents of most textures with undefined layouts.
		/// </summary>
		/// <param name="DstSubresource">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies the index of the subresource.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. If NULL, the data is
		/// written to the destination subresource with no offset. The dimensions of the source must fit the destination (see <c>D3D12_BOX</c>).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>A pointer to the source data in memory.</para>
		/// </param>
		/// <param name="SrcRowPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one row of source data to the next row.</para>
		/// </param>
		/// <param name="SrcDepthPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one depth slice of source data to the next.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The resource should first be mapped using <c>Map</c>. Textures must be in the <c>D3D12_RESOURCE_STATE_COMMON</c> state for CPU
		/// access through <b>WriteToSubresource</b> and <c>ReadFromSubresource</c> to be legal; but buffers do not.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above. This is because small
		/// mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can interfere
		/// with alignment to cache lines.
		/// </para>
		/// <para>
		/// <b>WriteToSubresource</b> and <c>ReadFromSubresource</c> enable near zero-copy optimizations for UMA adapters, but can
		/// prohibitively impair the efficiency of discrete/ NUMA adapters as the texture data cannot reside in local video memory. Typical
		/// applications should stick to discrete-friendly upload techniques, unless they recognize the adapter architecture is UMA. For
		/// more details on uploading, refer to <c>CopyTextureRegion</c>, and for more details on UMA, refer to <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>.
		/// </para>
		/// <para>
		/// On UMA systems, this routine can be used to minimize the cost of memory copying through the loop optimization known as <c>loop
		/// tiling</c>. By breaking up the upload into chucks that comfortably fit in the CPU cache, the effective bandwidth between the CPU
		/// and main memory more closely achieves theoretical maximums.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-writetosubresource HRESULT WriteToSubresource(
		// UINT DstSubresource, [in, optional] const D3D12_BOX *pDstBox, [in] const void *pSrcData, UINT SrcRowPitch, UINT SrcDepthPitch );
		[PreserveSig]
		HRESULT WriteToSubresource(uint DstSubresource, [In, Optional] StructPointer<D3D12_BOX> pDstBox, [In] IntPtr pSrcData,
			uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>
		/// Uses the CPU to copy data from a subresource, enabling the CPU to read the contents of most textures with undefined layouts.
		/// </summary>
		/// <param name="pDstData">
		/// <para>Type: <b>void*</b></para>
		/// <para>A pointer to the destination data in memory.</para>
		/// </param>
		/// <param name="DstRowPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one row of destination data to the next row.</para>
		/// </param>
		/// <param name="DstDepthPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one depth slice of destination data to the next.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies the index of the subresource to read from.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data from. If NULL, the data is
		/// read from the destination subresource with no offset. The dimensions of the destination must fit the destination (see <c>D3D12_BOX</c>).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>See the Remarks section for <c>WriteToSubresource</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-readfromsubresource HRESULT
		// ReadFromSubresource( [out] void *pDstData, UINT DstRowPitch, UINT DstDepthPitch, UINT SrcSubresource, [in, optional] const
		// D3D12_BOX *pSrcBox );
		[PreserveSig]
		HRESULT ReadFromSubresource([Out] IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, uint SrcSubresource,
			[In, Optional] StructPointer<D3D12_BOX> pSrcBox);

		/// <summary>Retrieves the properties of the resource heap, for placed and committed resources.</summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b><c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>
		/// Pointer to a <c>D3D12_HEAP_PROPERTIES</c> structure, that on successful completion of the method will contain the resource heap properties.
		/// </para>
		/// </param>
		/// <param name="pHeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_HEAP_FLAGS</c> variable, that on successful completion of the method will contain any miscellaneous heap flags.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns one of the <c>Direct3D 12 Return Codes</c>. If the resource was created as reserved, E_INVALIDARG is returned.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method only works on placed and committed resources, not on reserved resources. If the resource was created as reserved,
		/// E_INVALIDARG is returned. The pages could be mapped to none, one, or more heaps.
		/// </para>
		/// <para>For more information, refer to <c>Memory Management in Direct3D 12</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getheapproperties HRESULT GetHeapProperties(
		// [out, optional] D3D12_HEAP_PROPERTIES *pHeapProperties, [out, optional] D3D12_HEAP_FLAGS *pHeapFlags );
		[PreserveSig]
		HRESULT GetHeapProperties(out D3D12_HEAP_PROPERTIES pHeapProperties, out D3D12_HEAP_FLAGS pHeapFlags);
	}

	/// <summary>The <b>ID3D12Resource1</b> interface inherits from the ID3D12Resource interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12resource1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Resource1")]
	[ComImport, Guid("9d5e227a-4430-4161-88b3-3eca6bb16e19"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Resource1 : ID3D12Resource
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
		/// Gets a CPU pointer to the specified subresource in the resource, but may not disclose the pointer value to applications.
		/// <b>Map</b> also invalidates the CPU cache, when necessary, so that CPU reads to this address reflect any modifications made by
		/// the GPU.
		/// </summary>
		/// <param name="Subresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index number of the subresource.</para>
		/// </param>
		/// <param name="pReadRange">
		/// <para>Type: <b>const <c>D3D12_RANGE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to access.</para>
		/// <para>
		/// This indicates the region the CPU might read, and the coordinates are subresource-relative. A null pointer indicates the entire
		/// subresource might be read by the CPU. It is valid to specify the CPU won't read any data by passing a range where <b>End</b> is
		/// less than or equal to <b>Begin</b>.
		/// </para>
		/// </param>
		/// <param name="ppData">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the resource data.</para>
		/// <para>
		/// A null pointer is valid and is useful to cache a CPU virtual address range for methods like <c>WriteToSubresource</c>. When
		/// <i>ppData</i> is not NULL, the pointer returned is never offset by any values in <i>pReadRange</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>Map</b> and <c>Unmap</c> can be called by multiple threads safely. Nested <b>Map</b> calls are supported and are ref-counted.
		/// The first call to <b>Map</b> allocates a CPU virtual address range for the resource. The last call to <b>Unmap</b> deallocates
		/// the CPU virtual address range. The CPU virtual address is commonly returned to the application; but manipulating the contents of
		/// textures with unknown layouts precludes disclosing the CPU virtual address. See <c>WriteToSubresource</c> for more details.
		/// Applications cannot rely on the address being consistent, unless <b>Map</b> is persistently nested.
		/// </para>
		/// <para>
		/// Pointers returned by <b>Map</b> are not guaranteed to have all the capabilities of normal pointers, but most applications won't
		/// notice a difference in normal usage. For example, pointers with WRITE_COMBINE behavior have weaker CPU memory ordering
		/// guarantees than WRITE_BACK behavior. Memory accessible by both CPU and GPU are not guaranteed to share the same atomic memory
		/// guarantees that the CPU has, due to PCIe limitations. Use fences for synchronization.
		/// </para>
		/// <para>
		/// There are two usage model categories for <b>Map</b>, simple and advanced. The simple usage models maximize tool performance, so
		/// applications are recommended to stick with the simple models until the advanced models are proven to be required by the app.
		/// </para>
		/// <para><c></c><c></c><c></c> Simple Usage Models</para>
		/// <para>
		/// Applications should stick to the heap type abstractions of UPLOAD, DEFAULT, and READBACK, in order to support all adapter
		/// architectures reasonably well.
		/// </para>
		/// <para>
		/// Applications should avoid CPU reads from pointers to resources on UPLOAD heaps, even accidently. CPU reads will work, but are
		/// prohibitively slow on many common GPU architectures, so consider the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Don't make the CPU read from resources associated with heaps that are D3D12_HEAP_TYPE_UPLOAD or have D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The memory region to which <b>pData</b> points can be allocated with <c>PAGE_WRITECOMBINE</c>, and your app must honor all
		/// restrictions that are associated with such memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the
		/// following x86 assembly code.
		/// <para>C++ code:</para>
		/// <para>x86 assembly code:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can
		/// avoid the xor optimization by using a <b>volatile</b> pointer or by optimizing for code speed instead of code size.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications are encouraged to leave resources unmapped while the CPU will not modify them, and use tight, accurate ranges at
		/// all times. This enables the fastest modes for tools, like <c>Graphics Debugging</c> and the debug layer. Such tools need to
		/// track all CPU modifications to memory that the GPU could read.
		/// </para>
		/// <para><c></c><c></c><c></c> Advanced Usage Models</para>
		/// <para>
		/// Resources on CPU-accessible heaps can be persistently mapped, meaning <b>Map</b> can be called once, immediately after resource
		/// creation. <c>Unmap</c> never needs to be called, but the address returned from <b>Map</b> must no longer be used after the last
		/// reference to the resource is released. When using persistent map, the application must ensure the CPU finishes writing data into
		/// memory before the GPU executes a command list that reads or writes the memory. In common scenarios, the application merely must
		/// write to memory before calling <c>ExecuteCommandLists</c>; but using a fence to delay command list execution works as well.
		/// </para>
		/// <para>
		/// All CPU-accessible memory types support persistent mapping usage, where the resource is mapped but then never unmapped, provided
		/// the application does not access the pointer after the resource has been disposed.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12Resource::Map</b> as follows:</para>
		/// <para>Copy triangle data to the vertex buffer.</para>
		/// <para>
		/// <c>// Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE readRange(0, 0); // We do not intend
		/// to read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0, &amp;readRange,
		/// reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices, sizeof(triangleVertices));
		/// m_vertexBuffer-&gt;Unmap(0, nullptr);</c>
		/// </para>
		/// <para>Create an upload heap for the constant buffers.</para>
		/// <para>
		/// <c>// Create an upload heap for the constant buffers. ThrowIfFailed(pDevice-&gt;CreateCommittedResource(
		/// &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE,
		/// &amp;D3D12_RESOURCE_DESC::Buffer(sizeof(ConstantBuffer) * m_cityRowCount * m_cityColumnCount),
		/// D3D12_RESOURCE_STATE_GENERIC_READ, nullptr, IID_PPV_ARGS(&amp;m_cbvUploadHeap))); // Map the constant buffers. Note that unlike
		/// D3D11, the resource // does not need to be unmapped for use by the GPU. In this sample, // the resource stays 'permanently'
		/// mapped to avoid overhead with // mapping/unmapping each frame. CD3DX12_RANGE readRange(0, 0); // We do not intend to read from
		/// this resource on the CPU. ThrowIfFailed(m_cbvUploadHeap-&gt;Map(0, &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;m_pConstantBuffers)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-map HRESULT Map( UINT Subresource, [in,
		// optional] const D3D12_RANGE *pReadRange, [out, optional] void **ppData );
		[PreserveSig]
		new HRESULT Map(uint Subresource, [In, Optional] StructPointer<D3D12_RANGE> pReadRange, [Out, Optional] IntPtr ppData);

		/// <summary>Invalidates the CPU pointer to the specified subresource in the resource.</summary>
		/// <param name="Subresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the subresource.</para>
		/// </param>
		/// <param name="pWrittenRange">
		/// <para>Type: <b>const <c>D3D12_RANGE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to unmap.</para>
		/// <para>
		/// This indicates the region the CPU might have modified, and the coordinates are subresource-relative. A null pointer indicates
		/// the entire subresource might have been modified by the CPU. It is valid to specify the CPU didn't write any data by passing a
		/// range where <b>End</b> is less than or equal to <b>Begin</b>.
		/// </para>
		/// <para>This parameter is only used by tooling, and not for correctness of the actual unmap operation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Refer to the extensive Remarks and Examples for the <c>Map</c> method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-unmap void Unmap( UINT Subresource, [in,
		// optional] const D3D12_RANGE *pWrittenRange );
		[PreserveSig]
		new void Unmap(uint Subresource, [In, Optional] StructPointer<D3D12_RANGE> pWrittenRange);

		/// <summary>Gets the resource description.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_DESC</c></b></para>
		/// <para>A Direct3D 12 resource description structure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getdesc D3D12_RESOURCE_DESC GetDesc();
		[PreserveSig]
		new void GetDesc(out D3D12_RESOURCE_DESC size);

		/// <summary>This method returns the GPU virtual address of a buffer resource.</summary>
		/// <returns>
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>This method returns the GPU virtual address. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd synonym of UINT64.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is only useful for buffer resources, it will return zero for all texture resources.</para>
		/// <para>For more information on the use of GPU virtual addresses, refer to <c>Indirect Drawing</c>. Examples The <c>D3D1211on12</c> sample uses <b>ID3D12Resource::GetGPUVirtualAddress</b> as follows:</para>
		/// <para>
		/// <c>// Initialize the vertex buffer view. m_vertexBufferView.BufferLocation = m_vertexBuffer-&gt;GetGPUVirtualAddress();
		/// m_vertexBufferView.StrideInBytes = sizeof(Vertex); m_vertexBufferView.SizeInBytes = vertexBufferSize;</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getgpuvirtualaddress D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress();
		[PreserveSig]
		new D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress();

		/// <summary>
		/// Uses the CPU to copy data into a subresource, enabling the CPU to modify the contents of most textures with undefined layouts.
		/// </summary>
		/// <param name="DstSubresource">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies the index of the subresource.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. If NULL, the data is
		/// written to the destination subresource with no offset. The dimensions of the source must fit the destination (see <c>D3D12_BOX</c>).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>A pointer to the source data in memory.</para>
		/// </param>
		/// <param name="SrcRowPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one row of source data to the next row.</para>
		/// </param>
		/// <param name="SrcDepthPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one depth slice of source data to the next.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The resource should first be mapped using <c>Map</c>. Textures must be in the <c>D3D12_RESOURCE_STATE_COMMON</c> state for CPU
		/// access through <b>WriteToSubresource</b> and <c>ReadFromSubresource</c> to be legal; but buffers do not.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above. This is because small
		/// mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can interfere
		/// with alignment to cache lines.
		/// </para>
		/// <para>
		/// <b>WriteToSubresource</b> and <c>ReadFromSubresource</c> enable near zero-copy optimizations for UMA adapters, but can
		/// prohibitively impair the efficiency of discrete/ NUMA adapters as the texture data cannot reside in local video memory. Typical
		/// applications should stick to discrete-friendly upload techniques, unless they recognize the adapter architecture is UMA. For
		/// more details on uploading, refer to <c>CopyTextureRegion</c>, and for more details on UMA, refer to <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>.
		/// </para>
		/// <para>
		/// On UMA systems, this routine can be used to minimize the cost of memory copying through the loop optimization known as <c>loop
		/// tiling</c>. By breaking up the upload into chucks that comfortably fit in the CPU cache, the effective bandwidth between the CPU
		/// and main memory more closely achieves theoretical maximums.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-writetosubresource HRESULT WriteToSubresource(
		// UINT DstSubresource, [in, optional] const D3D12_BOX *pDstBox, [in] const void *pSrcData, UINT SrcRowPitch, UINT SrcDepthPitch );
		[PreserveSig]
		new HRESULT WriteToSubresource(uint DstSubresource, [In, Optional] StructPointer<D3D12_BOX> pDstBox, [In] IntPtr pSrcData,
			uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>
		/// Uses the CPU to copy data from a subresource, enabling the CPU to read the contents of most textures with undefined layouts.
		/// </summary>
		/// <param name="pDstData">
		/// <para>Type: <b>void*</b></para>
		/// <para>A pointer to the destination data in memory.</para>
		/// </param>
		/// <param name="DstRowPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one row of destination data to the next row.</para>
		/// </param>
		/// <param name="DstDepthPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one depth slice of destination data to the next.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies the index of the subresource to read from.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data from. If NULL, the data is
		/// read from the destination subresource with no offset. The dimensions of the destination must fit the destination (see <c>D3D12_BOX</c>).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>See the Remarks section for <c>WriteToSubresource</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-readfromsubresource HRESULT
		// ReadFromSubresource( [out] void *pDstData, UINT DstRowPitch, UINT DstDepthPitch, UINT SrcSubresource, [in, optional] const
		// D3D12_BOX *pSrcBox );
		[PreserveSig]
		new HRESULT ReadFromSubresource([Out] IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, uint SrcSubresource,
			[In, Optional] StructPointer<D3D12_BOX> pSrcBox);

		/// <summary>Retrieves the properties of the resource heap, for placed and committed resources.</summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b><c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>
		/// Pointer to a <c>D3D12_HEAP_PROPERTIES</c> structure, that on successful completion of the method will contain the resource heap properties.
		/// </para>
		/// </param>
		/// <param name="pHeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_HEAP_FLAGS</c> variable, that on successful completion of the method will contain any miscellaneous heap flags.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns one of the <c>Direct3D 12 Return Codes</c>. If the resource was created as reserved, E_INVALIDARG is returned.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method only works on placed and committed resources, not on reserved resources. If the resource was created as reserved,
		/// E_INVALIDARG is returned. The pages could be mapped to none, one, or more heaps.
		/// </para>
		/// <para>For more information, refer to <c>Memory Management in Direct3D 12</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getheapproperties HRESULT GetHeapProperties(
		// [out, optional] D3D12_HEAP_PROPERTIES *pHeapProperties, [out, optional] D3D12_HEAP_FLAGS *pHeapFlags );
		[PreserveSig]
		new HRESULT GetHeapProperties(out D3D12_HEAP_PROPERTIES pHeapProperties, out D3D12_HEAP_FLAGS pHeapFlags);

		/// <summary/>
		/// <param name="riid"/>
		/// <param name="ppProtectedSession"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource1-getprotectedresourcesession HRESULT
		// GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		HRESULT GetProtectedResourceSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);
	}

	/// <summary>The <b>ID3D12Resource2</b> interface inherits from the ID3D12Resource1 interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12resource2
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Resource2")]
	[ComImport, Guid("be36ec3b-ea85-4aeb-a45a-e9d76404a495"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Resource2 : ID3D12Resource1
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
		/// Gets a CPU pointer to the specified subresource in the resource, but may not disclose the pointer value to applications.
		/// <b>Map</b> also invalidates the CPU cache, when necessary, so that CPU reads to this address reflect any modifications made by
		/// the GPU.
		/// </summary>
		/// <param name="Subresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index number of the subresource.</para>
		/// </param>
		/// <param name="pReadRange">
		/// <para>Type: <b>const <c>D3D12_RANGE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to access.</para>
		/// <para>
		/// This indicates the region the CPU might read, and the coordinates are subresource-relative. A null pointer indicates the entire
		/// subresource might be read by the CPU. It is valid to specify the CPU won't read any data by passing a range where <b>End</b> is
		/// less than or equal to <b>Begin</b>.
		/// </para>
		/// </param>
		/// <param name="ppData">
		/// <para>Type: <b><b>void</b>**</b></para>
		/// <para>A pointer to a memory block that receives a pointer to the resource data.</para>
		/// <para>
		/// A null pointer is valid and is useful to cache a CPU virtual address range for methods like <c>WriteToSubresource</c>. When
		/// <i>ppData</i> is not NULL, the pointer returned is never offset by any values in <i>pReadRange</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <b>Map</b> and <c>Unmap</c> can be called by multiple threads safely. Nested <b>Map</b> calls are supported and are ref-counted.
		/// The first call to <b>Map</b> allocates a CPU virtual address range for the resource. The last call to <b>Unmap</b> deallocates
		/// the CPU virtual address range. The CPU virtual address is commonly returned to the application; but manipulating the contents of
		/// textures with unknown layouts precludes disclosing the CPU virtual address. See <c>WriteToSubresource</c> for more details.
		/// Applications cannot rely on the address being consistent, unless <b>Map</b> is persistently nested.
		/// </para>
		/// <para>
		/// Pointers returned by <b>Map</b> are not guaranteed to have all the capabilities of normal pointers, but most applications won't
		/// notice a difference in normal usage. For example, pointers with WRITE_COMBINE behavior have weaker CPU memory ordering
		/// guarantees than WRITE_BACK behavior. Memory accessible by both CPU and GPU are not guaranteed to share the same atomic memory
		/// guarantees that the CPU has, due to PCIe limitations. Use fences for synchronization.
		/// </para>
		/// <para>
		/// There are two usage model categories for <b>Map</b>, simple and advanced. The simple usage models maximize tool performance, so
		/// applications are recommended to stick with the simple models until the advanced models are proven to be required by the app.
		/// </para>
		/// <para><c></c><c></c><c></c> Simple Usage Models</para>
		/// <para>
		/// Applications should stick to the heap type abstractions of UPLOAD, DEFAULT, and READBACK, in order to support all adapter
		/// architectures reasonably well.
		/// </para>
		/// <para>
		/// Applications should avoid CPU reads from pointers to resources on UPLOAD heaps, even accidently. CPU reads will work, but are
		/// prohibitively slow on many common GPU architectures, so consider the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Don't make the CPU read from resources associated with heaps that are D3D12_HEAP_TYPE_UPLOAD or have D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE.</description>
		/// </item>
		/// <item>
		/// <description>
		/// The memory region to which <b>pData</b> points can be allocated with <c>PAGE_WRITECOMBINE</c>, and your app must honor all
		/// restrictions that are associated with such memory.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the
		/// following x86 assembly code.
		/// <para>C++ code:</para>
		/// <para>x86 assembly code:</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can
		/// avoid the xor optimization by using a <b>volatile</b> pointer or by optimizing for code speed instead of code size.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Applications are encouraged to leave resources unmapped while the CPU will not modify them, and use tight, accurate ranges at
		/// all times. This enables the fastest modes for tools, like <c>Graphics Debugging</c> and the debug layer. Such tools need to
		/// track all CPU modifications to memory that the GPU could read.
		/// </para>
		/// <para><c></c><c></c><c></c> Advanced Usage Models</para>
		/// <para>
		/// Resources on CPU-accessible heaps can be persistently mapped, meaning <b>Map</b> can be called once, immediately after resource
		/// creation. <c>Unmap</c> never needs to be called, but the address returned from <b>Map</b> must no longer be used after the last
		/// reference to the resource is released. When using persistent map, the application must ensure the CPU finishes writing data into
		/// memory before the GPU executes a command list that reads or writes the memory. In common scenarios, the application merely must
		/// write to memory before calling <c>ExecuteCommandLists</c>; but using a fence to delay command list execution works as well.
		/// </para>
		/// <para>
		/// All CPU-accessible memory types support persistent mapping usage, where the resource is mapped but then never unmapped, provided
		/// the application does not access the pointer after the resource has been disposed.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12Resource::Map</b> as follows:</para>
		/// <para>Copy triangle data to the vertex buffer.</para>
		/// <para>
		/// <c>// Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE readRange(0, 0); // We do not intend
		/// to read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0, &amp;readRange,
		/// reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices, sizeof(triangleVertices));
		/// m_vertexBuffer-&gt;Unmap(0, nullptr);</c>
		/// </para>
		/// <para>Create an upload heap for the constant buffers.</para>
		/// <para>
		/// <c>// Create an upload heap for the constant buffers. ThrowIfFailed(pDevice-&gt;CreateCommittedResource(
		/// &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE,
		/// &amp;D3D12_RESOURCE_DESC::Buffer(sizeof(ConstantBuffer) * m_cityRowCount * m_cityColumnCount),
		/// D3D12_RESOURCE_STATE_GENERIC_READ, nullptr, IID_PPV_ARGS(&amp;m_cbvUploadHeap))); // Map the constant buffers. Note that unlike
		/// D3D11, the resource // does not need to be unmapped for use by the GPU. In this sample, // the resource stays 'permanently'
		/// mapped to avoid overhead with // mapping/unmapping each frame. CD3DX12_RANGE readRange(0, 0); // We do not intend to read from
		/// this resource on the CPU. ThrowIfFailed(m_cbvUploadHeap-&gt;Map(0, &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;m_pConstantBuffers)));</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-map HRESULT Map( UINT Subresource, [in,
		// optional] const D3D12_RANGE *pReadRange, [out, optional] void **ppData );
		[PreserveSig]
		new HRESULT Map(uint Subresource, [In, Optional] StructPointer<D3D12_RANGE> pReadRange, [Out, Optional] IntPtr ppData);

		/// <summary>Invalidates the CPU pointer to the specified subresource in the resource.</summary>
		/// <param name="Subresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the subresource.</para>
		/// </param>
		/// <param name="pWrittenRange">
		/// <para>Type: <b>const <c>D3D12_RANGE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to unmap.</para>
		/// <para>
		/// This indicates the region the CPU might have modified, and the coordinates are subresource-relative. A null pointer indicates
		/// the entire subresource might have been modified by the CPU. It is valid to specify the CPU didn't write any data by passing a
		/// range where <b>End</b> is less than or equal to <b>Begin</b>.
		/// </para>
		/// <para>This parameter is only used by tooling, and not for correctness of the actual unmap operation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Refer to the extensive Remarks and Examples for the <c>Map</c> method.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-unmap void Unmap( UINT Subresource, [in,
		// optional] const D3D12_RANGE *pWrittenRange );
		[PreserveSig]
		new void Unmap(uint Subresource, [In, Optional] StructPointer<D3D12_RANGE> pWrittenRange);

		/// <summary>Gets the resource description.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_RESOURCE_DESC</c></b></para>
		/// <para>A Direct3D 12 resource description structure.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getdesc D3D12_RESOURCE_DESC GetDesc();
		[PreserveSig]
		new void GetDesc(out D3D12_RESOURCE_DESC size);

		/// <summary>This method returns the GPU virtual address of a buffer resource.</summary>
		/// <returns>
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>This method returns the GPU virtual address. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd synonym of UINT64.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method is only useful for buffer resources, it will return zero for all texture resources.</para>
		/// <para>For more information on the use of GPU virtual addresses, refer to <c>Indirect Drawing</c>. Examples The <c>D3D1211on12</c> sample uses <b>ID3D12Resource::GetGPUVirtualAddress</b> as follows:</para>
		/// <para>
		/// <c>// Initialize the vertex buffer view. m_vertexBufferView.BufferLocation = m_vertexBuffer-&gt;GetGPUVirtualAddress();
		/// m_vertexBufferView.StrideInBytes = sizeof(Vertex); m_vertexBufferView.SizeInBytes = vertexBufferSize;</c>
		/// </para>
		/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getgpuvirtualaddress D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress();
		[PreserveSig]
		new D3D12_GPU_VIRTUAL_ADDRESS GetGPUVirtualAddress();

		/// <summary>
		/// Uses the CPU to copy data into a subresource, enabling the CPU to modify the contents of most textures with undefined layouts.
		/// </summary>
		/// <param name="DstSubresource">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies the index of the subresource.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. If NULL, the data is
		/// written to the destination subresource with no offset. The dimensions of the source must fit the destination (see <c>D3D12_BOX</c>).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>A pointer to the source data in memory.</para>
		/// </param>
		/// <param name="SrcRowPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one row of source data to the next row.</para>
		/// </param>
		/// <param name="SrcDepthPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one depth slice of source data to the next.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The resource should first be mapped using <c>Map</c>. Textures must be in the <c>D3D12_RESOURCE_STATE_COMMON</c> state for CPU
		/// access through <b>WriteToSubresource</b> and <c>ReadFromSubresource</c> to be legal; but buffers do not.
		/// </para>
		/// <para>
		/// For efficiency, ensure the bounds and alignment of the extents within the box are ( 64 / [bytes per pixel] ) pixels
		/// horizontally. Vertical bounds and alignment should be 2 rows, except when 1-byte-per-pixel formats are used, in which case 4
		/// rows are recommended. Single depth slices per call are handled efficiently. It is recommended but not necessary to provide
		/// pointers and strides which are 128-byte aligned.
		/// </para>
		/// <para>
		/// When writing to sub mipmap levels, it is recommended to use larger width and heights than described above. This is because small
		/// mipmap levels may actually be stored within a larger block of memory, with an opaque amount of offsetting which can interfere
		/// with alignment to cache lines.
		/// </para>
		/// <para>
		/// <b>WriteToSubresource</b> and <c>ReadFromSubresource</c> enable near zero-copy optimizations for UMA adapters, but can
		/// prohibitively impair the efficiency of discrete/ NUMA adapters as the texture data cannot reside in local video memory. Typical
		/// applications should stick to discrete-friendly upload techniques, unless they recognize the adapter architecture is UMA. For
		/// more details on uploading, refer to <c>CopyTextureRegion</c>, and for more details on UMA, refer to <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>.
		/// </para>
		/// <para>
		/// On UMA systems, this routine can be used to minimize the cost of memory copying through the loop optimization known as <c>loop
		/// tiling</c>. By breaking up the upload into chucks that comfortably fit in the CPU cache, the effective bandwidth between the CPU
		/// and main memory more closely achieves theoretical maximums.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-writetosubresource HRESULT WriteToSubresource(
		// UINT DstSubresource, [in, optional] const D3D12_BOX *pDstBox, [in] const void *pSrcData, UINT SrcRowPitch, UINT SrcDepthPitch );
		[PreserveSig]
		new HRESULT WriteToSubresource(uint DstSubresource, [In, Optional] StructPointer<D3D12_BOX> pDstBox, [In] IntPtr pSrcData,
			uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>
		/// Uses the CPU to copy data from a subresource, enabling the CPU to read the contents of most textures with undefined layouts.
		/// </summary>
		/// <param name="pDstData">
		/// <para>Type: <b>void*</b></para>
		/// <para>A pointer to the destination data in memory.</para>
		/// </param>
		/// <param name="DstRowPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one row of destination data to the next row.</para>
		/// </param>
		/// <param name="DstDepthPitch">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The distance from one depth slice of destination data to the next.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies the index of the subresource to read from.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data from. If NULL, the data is
		/// read from the destination subresource with no offset. The dimensions of the destination must fit the destination (see <c>D3D12_BOX</c>).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, this method doesn't perform any operation.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>See the Remarks section for <c>WriteToSubresource</c>.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-readfromsubresource HRESULT
		// ReadFromSubresource( [out] void *pDstData, UINT DstRowPitch, UINT DstDepthPitch, UINT SrcSubresource, [in, optional] const
		// D3D12_BOX *pSrcBox );
		[PreserveSig]
		new HRESULT ReadFromSubresource([Out] IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, uint SrcSubresource,
			[In, Optional] StructPointer<D3D12_BOX> pSrcBox);

		/// <summary>Retrieves the properties of the resource heap, for placed and committed resources.</summary>
		/// <param name="pHeapProperties">
		/// <para>Type: <b><c>D3D12_HEAP_PROPERTIES</c>*</b></para>
		/// <para>
		/// Pointer to a <c>D3D12_HEAP_PROPERTIES</c> structure, that on successful completion of the method will contain the resource heap properties.
		/// </para>
		/// </param>
		/// <param name="pHeapFlags">
		/// <para>Type: <b><c>D3D12_HEAP_FLAGS</c>*</b></para>
		/// <para>
		/// Specifies a <c>D3D12_HEAP_FLAGS</c> variable, that on successful completion of the method will contain any miscellaneous heap flags.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>
		/// This method returns one of the <c>Direct3D 12 Return Codes</c>. If the resource was created as reserved, E_INVALIDARG is returned.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method only works on placed and committed resources, not on reserved resources. If the resource was created as reserved,
		/// E_INVALIDARG is returned. The pages could be mapped to none, one, or more heaps.
		/// </para>
		/// <para>For more information, refer to <c>Memory Management in Direct3D 12</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource-getheapproperties HRESULT GetHeapProperties(
		// [out, optional] D3D12_HEAP_PROPERTIES *pHeapProperties, [out, optional] D3D12_HEAP_FLAGS *pHeapFlags );
		[PreserveSig]
		new HRESULT GetHeapProperties(out D3D12_HEAP_PROPERTIES pHeapProperties, out D3D12_HEAP_FLAGS pHeapFlags);

		/// <summary/>
		/// <param name="riid"/>
		/// <param name="ppProtectedSession"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource1-getprotectedresourcesession HRESULT
		// GetProtectedResourceSession( REFIID riid, void **ppProtectedSession );
		[PreserveSig]
		new HRESULT GetProtectedResourceSession(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppProtectedSession);

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12resource2-getdesc1 D3D12_RESOURCE_DESC1 GetDesc1();
		[PreserveSig]
		D3D12_RESOURCE_DESC1 GetDesc1();
	}

	/// <summary>
	/// The root signature defines what resources are bound to the graphics pipeline. A root signature is configured by the app and links
	/// command lists to the resources the shaders require. Currently, there is one graphics and one compute root signature per app.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12rootsignature
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12RootSignature")]
	[ComImport, Guid("c54a6b66-72df-4ee8-8be5-a946a1429214"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12RootSignature : ID3D12DeviceChild
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
	}

	/// <summary>
	/// Contains a method to return the deserialized <c>D3D12_ROOT_SIGNATURE_DESC</c> data structure, of a serialized root signature version 1.0.
	/// </summary>
	/// <remarks>This interface has been superceded by <c>ID3D12VersionedRootSignatureDeserializer</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12rootsignaturedeserializer
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12RootSignatureDeserializer")]
	[ComImport, Guid("34ab647b-3cc8-46ac-841b-c0965645c046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12RootSignatureDeserializer
	{
		/// <summary>Gets the layout of the root signature.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_ROOT_SIGNATURE_DESC</c></b></para>
		/// <para>
		/// This method returns a deserialized root signature in a <c>D3D12_ROOT_SIGNATURE_DESC</c> structure that describes the layout of
		/// the root signature.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12rootsignaturedeserializer-getrootsignaturedesc const
		// D3D12_ROOT_SIGNATURE_DESC * GetRootSignatureDesc();
		[PreserveSig]
		void GetRootSignatureDesc(out D3D12_ROOT_SIGNATURE_DESC size);
	}

	/// <summary>
	/// Provides SDK configuration methods. A pointer to this interface can be retrieved by calling the <c>D3D12GetInterface</c> free
	/// function with the <b>CLSID_D3D12SDKConfiguration</b> CLSID.
	/// </summary>
	/// <remarks>
	/// Tools that play back API capture such as PIX, and test harnesses such as the HLK, require modification to support the redist. Such
	/// tools can choose to ship with the latest redist. Direct3D's API compatibility through updates should mean that an API capture tool
	/// can capture on an older version of the Direct3D 12 SDK, and play it back on the newer version. However, some scenarios require more
	/// flexibility in selecting the SDK version.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12sdkconfiguration
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12SDKConfiguration")]
	[ComImport, Guid("e9eb5314-33aa-42b2-a718-d77f58b1f1c7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(D3D12SDKConfiguration))]
	public interface ID3D12SDKConfiguration
	{
		/// <summary>Configures the SDK version to use.</summary>
		/// <param name="SDKVersion">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The SDK version to set.</para>
		/// </param>
		/// <param name="SDKPath">
		/// <para>Type: _In_z_ <b><c>LPCSTR</c></b></para>
		/// <para>
		/// A NULL-terminated string that provides the relative path to <c>d3d12core.dll</c> at the specified SDKVersion. The path is
		/// relative to the process exe of the caller. If <c>d3d12core.dll</c> isn't found, or isn't of the specified SDKVersion, then
		/// Direct3D 12 device creation fails.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>If the function succeeds, then it returns <b>S_OK</b>. Otherwise, it returns one of the <c>Direct3D 12 return codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method can be used only in Windows Developer Mode.</para>
		/// <para>
		/// To set the SDK version using this API, you must call it before you create the Direct3D 12 device. Calling this API after
		/// creating the Direct3D 12 device will cause the Direct3D 12 runtime to remove the device.
		/// </para>
		/// <para>
		/// If the <c>d3d12core.dll</c> installed with the OS is newer than the SDK version specified, then the OS version is used instead.
		/// </para>
		/// <para>
		/// You can retrieve the version of a particular <c>D3D12Core.dll</c> from the exported symbol <c><b>D3D12SDKVersion</b></c>, which
		/// is a variable of type <b>UINT</b>, just like the variables exported from applications to enable use of the Agility SDK.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12sdkconfiguration-setsdkversion HRESULT SetSDKVersion(
		// UINT SDKVersion, LPCSTR SDKPath );
		[PreserveSig]
		HRESULT SetSDKVersion(uint SDKVersion, [MarshalAs(UnmanagedType.LPStr)] string SDKPath);
	}

	/*
	[ComImport, Guid("8aaf9303-ad25-48b9-9a57-d9c37e009d9f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12SDKConfiguration1 : ID3D12SDKConfiguration
	{
		[PreserveSig]
		new HRESULT SetSDKVersion(uint SDKVersion, [MarshalAs(UnmanagedType.LPStr)] string SDKPath);

		[PreserveSig]
		HRESULT CreateDeviceFactory(uint SDKVersion, [MarshalAs(UnmanagedType.LPStr)] string SDKPath, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvFactory);

		[PreserveSig]
		void FreeUnusedSDKs();
	}
	*/

	/// <summary>Represents a shader cache session.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12shadercachesession
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12ShaderCacheSession")]
	[ComImport, Guid("28e2495d-0f64-4ae4-a6ec-129255dc49a8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12ShaderCacheSession : ID3D12DeviceChild
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
		/// <para>Looks up an entry in the cache whose key exactly matches the provided key.</para>
		/// <para>
		/// Call the function twice. The first time to retrieve the value's size, and the second time to retrieve the data. In-memory
		/// temporary storage makes this calling pattern performant.
		/// </para>
		/// </summary>
		/// <param name="pKey">
		/// <para>Type: _In_reads_bytes_(KeySize) <b>const void *</b></para>
		/// <para>The key of the entry to look up.</para>
		/// </param>
		/// <param name="KeySize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the key, in bytes.</para>
		/// </param>
		/// <param name="pValue">
		/// <para>Type: _Out_writes_bytes_(*pValueSize) <b>void *</b></para>
		/// <para>A pointer to a memory block that receives the cached entry.</para>
		/// </param>
		/// <param name="pValueSize">
		/// <para>Type: _Inout_ <b><c>UINT</c>*</b></para>
		/// <para>A pointer to a <b>UINT</b> that receives the size of the cached entry, in bytes.</para>
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
		/// <description>DXGI_ERROR_CACHE_HASH_COLLISION</description>
		/// <description>There's an entry with the same hash as the provided key, but the key doesn't exactly match.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_NOT_FOUND</description>
		/// <description>The entry isn't present.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12shadercachesession-findvalue HRESULT FindValue( const
		// void *pKey, UINT KeySize, void *pValue, UINT *pValueSize );
		[PreserveSig]
		HRESULT FindValue([In] IntPtr pKey, uint KeySize, [Out] IntPtr pValue, ref uint pValueSize);

		/// <summary>Adds an entry to the cache.</summary>
		/// <param name="pKey">
		/// <para>Type: _In_reads_bytes_(KeySize) <b>const void *</b></para>
		/// <para>The key of the entry to add.</para>
		/// </param>
		/// <param name="KeySize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the key, in bytes.</para>
		/// </param>
		/// <param name="pValue">
		/// <para>Type: _In_reads_bytes_(ValueSize) <b>void *</b></para>
		/// <para>A pointer to a memory block containing the entry to add.</para>
		/// </param>
		/// <param name="ValueSize">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The size of the entry to add, in bytes.</para>
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
		/// <description>DXGI_ERROR_ALREADY_EXISTS</description>
		/// <description>There's an entry with the same key.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_CACHE_HASH_COLLISION</description>
		/// <description>There's an entry with the same hash as the provided key, but the key doesn't match.</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_CACHE_FULL</description>
		/// <description>Adding this entry would cause the cache to become larger than its maximum size.</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12shadercachesession-storevalue HRESULT StoreValue( const
		// void *pKey, UINT KeySize, const void *pValue, UINT ValueSize );
		[PreserveSig]
		HRESULT StoreValue([In] IntPtr pKey, uint KeySize, [In] IntPtr pValue, uint ValueSize);

		/// <summary>
		/// <para>When all cache session objects corresponding to a given cache are destroyed, the cache is cleared.</para>
		/// <para>See <b>Remarks</b> for the ways in which a disk cache can be cleared.</para>
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A disk cache can be cleared in one of the following ways.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Explicitly, by calling <b>SetDeleteOnDestroy</b> on the session object, and then releasing the session.</description>
		/// </item>
		/// <item>
		/// <description>Explicitly, in developer mode, by calling <c>ID3D12Device9::ShaderCacheControl</c> with <c>D3D12_SHADER_CACHE_KIND_FLAG_APPLICATION_MANAGED</c>.</description>
		/// </item>
		/// <item>
		/// <description>Implicitly, by creating a session object with a version that doesn't match the version used to create it.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Externally, by the disk cleanup utility enumerating it and clearing it. This won't happen for caches created with the
		/// <c>D3D12_SHADER_CACHE_FLAG_USE_WORKING_DIR</c> flag.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Manually, by deleting the files ( <c>*.idx</c>, <c>*.val</c>, and <c>*.lock</c>) stored on disk for
		/// <c>D3D12_SHADER_CACHE_FLAG_USE_WORKING_DIR</c> caches. Your application shouldn't attempt to do this for caches stored outside
		/// of the working directory.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12shadercachesession-setdeleteondestroy void SetDeleteOnDestroy();
		[PreserveSig]
		void SetDeleteOnDestroy();

		/// <summary>Retrieves the description used to create the cache session.</summary>
		/// <returns>A <c>D3D12_SHADER_CACHE_SESSION_DESC</c> structure representing the description used to create the cache session.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12shadercachesession-getdesc
		// D3D12_SHADER_CACHE_SESSION_DESC GetDesc();
		[PreserveSig]
		D3D12_SHADER_CACHE_SESSION_DESC GetDesc();
	}

	/// <summary>
	/// Represents a variable amount of configuration state, including shaders, that an application manages as a single unit and which is
	/// given to a driver atomically to process, such as compile or optimize. Create a state object by calling <c>ID3D12Device5::CreateStateObject</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12stateobject
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12StateObject")]
	[ComImport, Guid("47016943-fca8-4594-93ea-af258b55346d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12StateObject : ID3D12Pageable
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
	}

	/// <summary>
	/// Provides methods for getting and setting the properties of an <c><b>ID3D12StateObject</b></c>. To retrieve an instance of this type,
	/// call <c><b>ID3D12StateObject::QueryInterface</b></c> with the IID of <b>ID3D12StateObjectProperties</b>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12stateobjectproperties
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12StateObjectProperties")]
	[ComImport, Guid("de5fa827-9bf9-4f26-89ff-d7f56fde3860"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12StateObjectProperties
	{
		/// <summary>Retrieves the unique identifier for a shader that can be used in a shader record.</summary>
		/// <param name="pExportName">Entrypoint in the state object for which to retrieve an identifier.</param>
		/// <returns>
		/// <para>A pointer to the shader identifier.</para>
		/// <para>
		/// The data referenced by this pointer is valid as long as the state object it came from is valid. The size of the data returned is
		/// <c>D3D12_SHADER_IDENTIFIER_SIZE_IN_BYTES</c>. Applications should copy and cache this data to avoid the cost of searching for it
		/// in the state object if it will need to be retrieved many times. The identifier is used in shader records within shader tables in
		/// GPU memory, which the app must populate.
		/// </para>
		/// <para>
		/// The data itself globally identifies the shader, so even if the shader appears in a different state object with same
		/// associations, like any root signatures, it will have the same identifier.
		/// </para>
		/// <para>If the shader isn’t fully resolved in the state object, the return value is <b>nullptr</b>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12stateobjectproperties-getshaderidentifier void *
		// GetShaderIdentifier( LPCWSTR pExportName );
		[PreserveSig]
		void GetShaderIdentifier([MarshalAs(UnmanagedType.LPWStr)] string pExportName);

		/// <summary>Gets the amount of stack memory required to invoke a raytracing shader in HLSL.</summary>
		/// <param name="pExportName">
		/// <para>
		/// The shader entrypoint in the state object for which to retrieve stack size. For hit groups, an individual shader within the hit
		/// group must be specified using the syntax:
		/// </para>
		/// <para>hitGroupName::shaderType</para>
		/// <para>Where <i>hitGroupName</i> is the entrypoint name for the hit group and <i>shaderType</i> is one of:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>intersection</description>
		/// </item>
		/// <item>
		/// <description>anyhit</description>
		/// </item>
		/// <item>
		/// <description>closesthit</description>
		/// </item>
		/// </list>
		/// <para>These values are all case-sensitive.</para>
		/// <para>An example value is: "myTreeLeafHitGroup::anyhit".</para>
		/// </param>
		/// <returns>
		/// Amount of stack memory, in bytes, required to invoke the shader. If the shader isn’t fully resolved in the state object, or the
		/// shader is unknown or of a type for which a stack size isn’t relevant, such as a hit group, the return value is 0xffffffff. The
		/// 32-bit 0xffffffff value is used for the UINT64 return value to ensure that bad return values don’t get lost when summed up with
		/// other values as part of calculating an overall pipeline stack size.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method only needs to be called if the app wants to configure the stack size by calling <c>SetPipelineStackSize</c>, rather
		/// than relying on the conservative default stack size. This method is only valid for ray generation shaders, hit groups, miss
		/// shaders, and callable shaders. Even ray generation shaders may return a non-zero value despite being at the bottom of the stack.
		/// </para>
		/// <para>
		/// For hit groups, stack size must be queried for the individual shaders comprising it (intersection shaders, any hit shaders,
		/// closest hit shaders), as each likely has a different stack size requirement. The stack size can’t be queried on these individual
		/// shaders directly, as the way they are compiled can be influenced by the overall hit group that contains them. The
		/// <i>pExportName</i> parameter includes syntax for identifying individual shaders within a hit group.
		/// </para>
		/// <para>This API can be called on either collection state objects or raytracing pipeline state objects.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12stateobjectproperties-getshaderstacksize UINT64
		// GetShaderStackSize( LPCWSTR pExportName );
		[PreserveSig]
		ulong GetShaderStackSize([MarshalAs(UnmanagedType.LPWStr)] string pExportName);

		/// <summary>Gets the current pipeline stack size.</summary>
		/// <returns>
		/// The current pipeline stack size in bytes. When called on non-executable state objects, such as collections, the return value is 0.
		/// </returns>
		/// <remarks>
		/// This method and <c>SetPipelineStackSize</c> are not re-entrant. This means if calling either or both from separate threads, the
		/// app must synchronize on its own.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12stateobjectproperties-getpipelinestacksize UINT64 GetPipelineStackSize();
		[PreserveSig]
		ulong GetPipelineStackSize();

		/// <summary>Set the current pipeline stack size.</summary>
		/// <param name="PipelineStackSizeInBytes">
		/// <para>
		/// Stack size in bytes to use during pipeline execution for each shader thread. There can be many thousands of threads in flight at
		/// once on the GPU.
		/// </para>
		/// <para>
		/// If the value is greater than 0xffffffff (the maximum value of a 32-bit UINT) the runtime will drop the call, and the debug layer
		/// will print an error, as this is likely the result of summing up invalid stack sizes returned from <c>GetShaderStackSize</c>
		/// called with invalid parameters, which return 0xffffffff. In this case, the previously set stack size, or the default, remains.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method and <c>GetPipelineStackSize</c> are not re-entrant. This means if calling either or both from separate threads, the
		/// app must synchronize on its own.
		/// </para>
		/// <para>The runtime drops calls to state objects other than raytracing pipelines, such as collections.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12stateobjectproperties-setpipelinestacksize void
		// SetPipelineStackSize( UINT64 PipelineStackSizeInBytes );
		[PreserveSig]
		void SetPipelineStackSize(ulong PipelineStackSizeInBytes);
	}

	/// <summary>The <b>ID3D12SwapChainAssistant</b> interface inherits from the IUnknown interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12swapchainassistant
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12SwapChainAssistant")]
	[ComImport, Guid("f1df64b6-57fd-49cd-8807-c0eb88b45c8f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12SwapChainAssistant
	{
		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12swapchainassistant-getluid LUID GetLUID();
		[PreserveSig]
		void GetLUID(out LUID size);

		/// <summary/>
		/// <param name="riid"/>
		/// <param name="ppv"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12swapchainassistant-getswapchainobject HRESULT
		// GetSwapChainObject( REFIID riid, void **ppv );
		[PreserveSig]
		HRESULT GetSwapChainObject(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppv);

		/// <summary/>
		/// <param name="riidResource"/>
		/// <param name="ppvResource"/>
		/// <param name="riidQueue"/>
		/// <param name="ppvQueue"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12swapchainassistant-getcurrentresourceandcommandqueue
		// HRESULT GetCurrentResourceAndCommandQueue( REFIID riidResource, void **ppvResource, REFIID riidQueue, void **ppvQueue );
		[PreserveSig]
		HRESULT GetCurrentResourceAndCommandQueue(in Guid riidResource, [MarshalAs(UnmanagedType.Interface)] out object ppvResource,
			in Guid riidQueue, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvQueue);

		/// <summary/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12swapchainassistant-insertimplicitsync HRESULT InsertImplicitSync();
		[PreserveSig]
		HRESULT InsertImplicitSync();
	}

	/// <summary>This interface is used to configure the runtime for tools such as PIX. Its not intended or supported for any other scenario.</summary>
	/// <remarks>
	/// <para>
	/// Do not use this interface in your application, it's not intended or supported for any scenario other than to enable tooling such as PIX.
	/// </para>
	/// <para>Developer Mode must be enabled for this interface to respond.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12tools
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Tools")]
	[ComImport, Guid("7071e1f0-e84b-4b33-974f-12fa49de65c5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(D3D12Tools))]
	public interface ID3D12Tools
	{
		/// <summary>This method enables tools such as PIX to instrument shaders.</summary>
		/// <param name="bEnable">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>TRUE to enable shader instrumentation; otherwise, FALSE.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Do not use this interface in your application, it's not intended or supported for any scenario other than to enable tooling such
		/// as PIX.
		/// </para>
		/// <para>Developer Mode must be enabled for this interface to respond.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12tools-enableshaderinstrumentation void
		// EnableShaderInstrumentation( BOOL bEnable );
		[PreserveSig]
		void EnableShaderInstrumentation(bool bEnable);

		/// <summary>Determines whether shader instrumentation is enabled.</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if shader instrumentation is enabled; otherwise FALSE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Do not use this interface in your application, it's not intended or supported for any scenario other than to enable tooling such
		/// as PIX.
		/// </para>
		/// <para>Developer Mode must be enabled for this interface to respond.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12tools-shaderinstrumentationenabled BOOL ShaderInstrumentationEnabled();
		[PreserveSig]
		bool ShaderInstrumentationEnabled();
	}

	/// <summary>
	/// Contains methods to return the deserialized <c>D3D12_ROOT_SIGNATURE_DESC1</c> data structure, of any version of a serialized root signature.
	/// </summary>
	/// <remarks>This interface supercedes <c>ID3D12RootSignatureDeserializer</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12versionedrootsignaturedeserializer
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12VersionedRootSignatureDeserializer")]
	[ComImport, Guid("7f91ce67-090c-4bb7-b78e-ed8ff2e31da0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VersionedRootSignatureDeserializer
	{
		/// <summary>Converts root signature description structures to a requested version.</summary>
		/// <param name="convertToVersion">
		/// <para>Type: <b><c>D3D_ROOT_SIGNATURE_VERSION</c></b></para>
		/// <para>Specifies the required <c>D3D_ROOT_SIGNATURE_VERSION</c>.</para>
		/// </param>
		/// <param name="ppDesc">
		/// <para>Type: <b>const <c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c>**</b></para>
		/// <para>Contains the deserialized root signature in a <c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c> structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns an HRESULT success or error code. The method can fail with E_OUTOFMEMORY.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method allocates additional storage if needed for the converted root signature (memory owned by the deserializer
		/// interface). If conversion is done, the deserializer interface doesn’t free the original deserialized root signature memory – all
		/// versions the interface has been asked to convert to are available until the deserializer is destroyed.
		/// </para>
		/// <para>
		/// Converting a root signature from 1.1 to 1.0 will drop all <c>D3D12_DESCRIPTOR_RANGE_FLAGS</c> and
		/// <c>D3D12_ROOT_DESCRIPTOR_FLAGS</c> can be useful for generating compatible root signatures that need to run on old operating
		/// systems, though does lose optimization opportunities. For instance, multiple root signature versions can be serialized and
		/// stored with application assets, with the appropriate version used at runtime based on the operating system capabilities.
		/// </para>
		/// <para>Converting a root signature from 1.0 to 1.1 just adds the appropriate flags to match 1.0 semantics.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12versionedrootsignaturedeserializer-getrootsignaturedescatversion
		// HRESULT GetRootSignatureDescAtVersion( D3D_ROOT_SIGNATURE_VERSION convertToVersion, [out] const
		// D3D12_VERSIONED_ROOT_SIGNATURE_DESC **ppDesc );
		[PreserveSig]
		HRESULT GetRootSignatureDescAtVersion(D3D_ROOT_SIGNATURE_VERSION convertToVersion, out IntPtr ppDesc);

		/// <summary>Gets the layout of the root signature, without converting between root signature versions.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c></b></para>
		/// <para>
		/// This method returns a deserialized root signature in a <c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c> structure that describes the
		/// layout of the root signature.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12versionedrootsignaturedeserializer-getunconvertedrootsignaturedesc
		// const D3D12_VERSIONED_ROOT_SIGNATURE_DESC * GetUnconvertedRootSignatureDesc();
		[PreserveSig]
		void GetUnconvertedRootSignatureDesc(out D3D12_VERSIONED_ROOT_SIGNATURE_DESC size);
	}

	/// <summary>TBD</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12virtualizationguestdevice
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12VirtualizationGuestDevice")]
	[ComImport, Guid("bc66d368-7373-4943-8757-fc87dc79e476"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12VirtualizationGuestDevice
	{
		/// <summary/>
		/// <param name="pObject" />
		/// <param name="pHandle" />
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12virtualizationguestdevice-sharewithhost
		// HRESULT ShareWithHost( ID3D12DeviceChild *pObject, HANDLE *pHandle );
		[PreserveSig]
		HRESULT ShareWithHost([In] ID3D12DeviceChild pObject, out HANDLE pHandle);

		/// <summary/>
		/// <param name="pFence" />
		/// <param name="FenceValue" />
		/// <param name="pFenceFd" />
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12virtualizationguestdevice-createfencefd
		// HRESULT CreateFenceFd( ID3D12Fence *pFence, UINT64 FenceValue, int *pFenceFd );
		[PreserveSig]
		HRESULT CreateFenceFd([In] ID3D12Fence pFence, ulong FenceValue, out int pFenceFd);
	}

	/*
	[ComImport, Guid("065acf71-f863-4b89-82f4-02e4d5886757"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12WorkGraphProperties
	{
		[PreserveSig]
		uint GetNumWorkGraphs();

		[PreserveSig]
		string GetProgramName(uint WorkGraphIndex);

		[PreserveSig]
		uint GetWorkGraphIndex([MarshalAs(UnmanagedType.LPWStr)] string pProgramName);

		[PreserveSig]
		uint GetNumNodes(uint WorkGraphIndex);

		[PreserveSig]
		D3D12_NODE_ID GetNodeID(uint WorkGraphIndex, uint NodeIndex);

		[PreserveSig]
		uint GetNodeIndex(uint WorkGraphIndex, D3D12_NODE_ID NodeID);

		[PreserveSig]
		uint GetNodeLocalRootArgumentsTableIndex(uint WorkGraphIndex, uint NodeIndex);

		[PreserveSig]
		uint GetNumEntrypoints(uint WorkGraphIndex);

		[PreserveSig]
		D3D12_NODE_ID GetEntrypointID(uint WorkGraphIndex, uint EntrypointIndex);

		[PreserveSig]
		uint GetEntrypointIndex(uint WorkGraphIndex, D3D12_NODE_ID NodeID);

		[PreserveSig]
		uint GetEntrypointRecordSizeInBytes(uint WorkGraphIndex, uint EntrypointIndex);

		[PreserveSig]
		void GetWorkGraphMemoryRequirements(uint WorkGraphIndex, out D3D12_WORK_GRAPH_MEMORY_REQUIREMENTS pWorkGraphMemoryRequirements);
	}
	*/

	/// <summary>Gets application-defined data from a device object.</summary>
	/// <typeparam name="T">The data type.</typeparam>
	/// <param name="pObj">The <see cref="ID3D12Object"/> instance.</param>
	/// <param name="guid">The <b>GUID</b> that is associated with the data.</param>
	/// <returns>The data from the device object.</returns>
	/// <remarks>
	/// If the data returned is a pointer to an <c>IUnknown</c>, or one of its derivative classes, which was previously set by
	/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
	/// </remarks>
	public static T? GetPrivateData<T>(this ID3D12Object pObj, in Guid guid)
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

	/// <summary>
	/// Gets a CPU pointer to the specified subresource in the resource, but may not disclose the pointer value to applications. <b>Map</b>
	/// also invalidates the CPU cache, when necessary, so that CPU reads to this address reflect any modifications made by the GPU.
	/// </summary>
	/// <param name="res">The resource instance.</param>
	/// <param name="Subresource">Specifies the index number of the subresource.</param>
	/// <param name="pReadRange">
	/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to access.</para>
	/// <para>
	/// This indicates the region the CPU might read, and the coordinates are subresource-relative. A null pointer indicates the entire
	/// subresource might be read by the CPU. It is valid to specify the CPU won't read any data by passing a range where <b>End</b> is less
	/// than or equal to <b>Begin</b>.
	/// </para>
	/// </param>
	/// <param name="ppData">A pointer to a memory block that receives a pointer to the resource data.</param>
	/// <returns>This method returns one of the <c>Direct3D 12 Return Codes</c>.</returns>
	/// <remarks>
	/// <para>
	/// <b>Map</b> and <c>Unmap</c> can be called by multiple threads safely. Nested <b>Map</b> calls are supported and are ref-counted. The
	/// first call to <b>Map</b> allocates a CPU virtual address range for the resource. The last call to <b>Unmap</b> deallocates the CPU
	/// virtual address range. The CPU virtual address is commonly returned to the application; but manipulating the contents of textures
	/// with unknown layouts precludes disclosing the CPU virtual address. See <c>WriteToSubresource</c> for more details. Applications
	/// cannot rely on the address being consistent, unless <b>Map</b> is persistently nested.
	/// </para>
	/// <para>
	/// Pointers returned by <b>Map</b> are not guaranteed to have all the capabilities of normal pointers, but most applications won't
	/// notice a difference in normal usage. For example, pointers with WRITE_COMBINE behavior have weaker CPU memory ordering guarantees
	/// than WRITE_BACK behavior. Memory accessible by both CPU and GPU are not guaranteed to share the same atomic memory guarantees that
	/// the CPU has, due to PCIe limitations. Use fences for synchronization.
	/// </para>
	/// <para>
	/// There are two usage model categories for <b>Map</b>, simple and advanced. The simple usage models maximize tool performance, so
	/// applications are recommended to stick with the simple models until the advanced models are proven to be required by the app.
	/// </para>
	/// <para>Simple Usage Models</para>
	/// <para>
	/// Applications should stick to the heap type abstractions of UPLOAD, DEFAULT, and READBACK, in order to support all adapter
	/// architectures reasonably well.
	/// </para>
	/// <para>
	/// Applications should avoid CPU reads from pointers to resources on UPLOAD heaps, even accidently. CPU reads will work, but are
	/// prohibitively slow on many common GPU architectures, so consider the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Don't make the CPU read from resources associated with heaps that are D3D12_HEAP_TYPE_UPLOAD or have D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE.</description>
	/// </item>
	/// <item>
	/// <description>
	/// The memory region to which <b>pData</b> points can be allocated with <c>PAGE_WRITECOMBINE</c>, and your app must honor all
	/// restrictions that are associated with such memory.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the following
	/// x86 assembly code.
	/// <para>C++ code:</para>
	/// <para>x86 assembly code:</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can avoid
	/// the xor optimization by using a <b>volatile</b> pointer or by optimizing for code speed instead of code size.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Applications are encouraged to leave resources unmapped while the CPU will not modify them, and use tight, accurate ranges at all
	/// times. This enables the fastest modes for tools, like <c>Graphics Debugging</c> and the debug layer. Such tools need to track all
	/// CPU modifications to memory that the GPU could read.
	/// </para>
	/// <para>Advanced Usage Models</para>
	/// <para>
	/// Resources on CPU-accessible heaps can be persistently mapped, meaning <b>Map</b> can be called once, immediately after resource
	/// creation. <c>Unmap</c> never needs to be called, but the address returned from <b>Map</b> must no longer be used after the last
	/// reference to the resource is released. When using persistent map, the application must ensure the CPU finishes writing data into
	/// memory before the GPU executes a command list that reads or writes the memory. In common scenarios, the application merely must
	/// write to memory before calling <c>ExecuteCommandLists</c>; but using a fence to delay command list execution works as well.
	/// </para>
	/// <para>
	/// All CPU-accessible memory types support persistent mapping usage, where the resource is mapped but then never unmapped, provided the
	/// application does not access the pointer after the resource has been disposed. Examples The <c>D3D12Bundles</c> sample uses
	/// <b>ID3D12Resource::Map</b> as follows:
	/// </para>
	/// <para>Copy triangle data to the vertex buffer.</para>
	/// <para>
	/// <c>// Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE readRange(0, 0); // We do not intend to
	/// read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0, &amp;readRange,
	/// reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices, sizeof(triangleVertices));
	/// m_vertexBuffer-&gt;Unmap(0, nullptr);</c>
	/// </para>
	/// <para>Create an upload heap for the constant buffers.</para>
	/// <para>
	/// <c>// Create an upload heap for the constant buffers. ThrowIfFailed(pDevice-&gt;CreateCommittedResource(
	/// &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE, &amp;D3D12_RESOURCE_DESC::Buffer(sizeof(ConstantBuffer)
	/// * m_cityRowCount * m_cityColumnCount), D3D12_RESOURCE_STATE_GENERIC_READ, nullptr, IID_PPV_ARGS(&amp;m_cbvUploadHeap))); // Map the
	/// constant buffers. Note that unlike D3D11, the resource // does not need to be unmapped for use by the GPU. In this sample, // the
	/// resource stays 'permanently' mapped to avoid overhead with // mapping/unmapping each frame. CD3DX12_RANGE readRange(0, 0); // We do
	/// not intend to read from this resource on the CPU. ThrowIfFailed(m_cbvUploadHeap-&gt;Map(0, &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;m_pConstantBuffers)));</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	public static HRESULT Map(this ID3D12Resource res, uint Subresource, [In, Optional] D3D12_RANGE? pReadRange, out IntPtr ppData)
	{
		using SafeCoTaskMemStruct<D3D12_RANGE> rng = pReadRange;
		unsafe
		{
			void* p = default;
			var hr = res.Map(Subresource, rng, (IntPtr)(void**)&p);
			ppData = (IntPtr)p;
			return hr;
		}
	}

	/// <summary>
	/// Gets a CPU pointer to the specified subresource in the resource, but may not disclose the pointer value to applications. <b>Map</b>
	/// also invalidates the CPU cache, when necessary, so that CPU reads to this address reflect any modifications made by the GPU.
	/// </summary>
	/// <param name="res">The resource instance.</param>
	/// <param name="Subresource">Specifies the index number of the subresource.</param>
	/// <param name="pReadRange">
	/// <para>A pointer to a <c>D3D12_RANGE</c> structure that describes the range of memory to access.</para>
	/// <para>
	/// This indicates the region the CPU might read, and the coordinates are subresource-relative. A null pointer indicates the entire
	/// subresource might be read by the CPU. It is valid to specify the CPU won't read any data by passing a range where <b>End</b> is less
	/// than or equal to <b>Begin</b>.
	/// </para>
	/// </param>
	/// <returns>This method returns one of the <c>Direct3D 12 Return Codes</c>.</returns>
	/// <remarks>
	/// <para>
	/// <b>Map</b> and <c>Unmap</c> can be called by multiple threads safely. Nested <b>Map</b> calls are supported and are ref-counted. The
	/// first call to <b>Map</b> allocates a CPU virtual address range for the resource. The last call to <b>Unmap</b> deallocates the CPU
	/// virtual address range. The CPU virtual address is commonly returned to the application; but manipulating the contents of textures
	/// with unknown layouts precludes disclosing the CPU virtual address. See <c>WriteToSubresource</c> for more details. Applications
	/// cannot rely on the address being consistent, unless <b>Map</b> is persistently nested.
	/// </para>
	/// <para>
	/// Pointers returned by <b>Map</b> are not guaranteed to have all the capabilities of normal pointers, but most applications won't
	/// notice a difference in normal usage. For example, pointers with WRITE_COMBINE behavior have weaker CPU memory ordering guarantees
	/// than WRITE_BACK behavior. Memory accessible by both CPU and GPU are not guaranteed to share the same atomic memory guarantees that
	/// the CPU has, due to PCIe limitations. Use fences for synchronization.
	/// </para>
	/// <para>
	/// There are two usage model categories for <b>Map</b>, simple and advanced. The simple usage models maximize tool performance, so
	/// applications are recommended to stick with the simple models until the advanced models are proven to be required by the app.
	/// </para>
	/// <para>Simple Usage Models</para>
	/// <para>
	/// Applications should stick to the heap type abstractions of UPLOAD, DEFAULT, and READBACK, in order to support all adapter
	/// architectures reasonably well.
	/// </para>
	/// <para>
	/// Applications should avoid CPU reads from pointers to resources on UPLOAD heaps, even accidently. CPU reads will work, but are
	/// prohibitively slow on many common GPU architectures, so consider the following:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Don't make the CPU read from resources associated with heaps that are D3D12_HEAP_TYPE_UPLOAD or have D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE.</description>
	/// </item>
	/// <item>
	/// <description>
	/// The memory region to which <b>pData</b> points can be allocated with <c>PAGE_WRITECOMBINE</c>, and your app must honor all
	/// restrictions that are associated with such memory.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the following
	/// x86 assembly code.
	/// <para>C++ code:</para>
	/// <para>x86 assembly code:</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can avoid
	/// the xor optimization by using a <b>volatile</b> pointer or by optimizing for code speed instead of code size.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// Applications are encouraged to leave resources unmapped while the CPU will not modify them, and use tight, accurate ranges at all
	/// times. This enables the fastest modes for tools, like <c>Graphics Debugging</c> and the debug layer. Such tools need to track all
	/// CPU modifications to memory that the GPU could read.
	/// </para>
	/// <para>Advanced Usage Models</para>
	/// <para>
	/// Resources on CPU-accessible heaps can be persistently mapped, meaning <b>Map</b> can be called once, immediately after resource
	/// creation. <c>Unmap</c> never needs to be called, but the address returned from <b>Map</b> must no longer be used after the last
	/// reference to the resource is released. When using persistent map, the application must ensure the CPU finishes writing data into
	/// memory before the GPU executes a command list that reads or writes the memory. In common scenarios, the application merely must
	/// write to memory before calling <c>ExecuteCommandLists</c>; but using a fence to delay command list execution works as well.
	/// </para>
	/// <para>
	/// All CPU-accessible memory types support persistent mapping usage, where the resource is mapped but then never unmapped, provided the
	/// application does not access the pointer after the resource has been disposed. Examples The <c>D3D12Bundles</c> sample uses
	/// <b>ID3D12Resource::Map</b> as follows:
	/// </para>
	/// <para>Copy triangle data to the vertex buffer.</para>
	/// <para>
	/// <c>// Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE readRange(0, 0); // We do not intend to
	/// read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0, &amp;readRange,
	/// reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices, sizeof(triangleVertices));
	/// m_vertexBuffer-&gt;Unmap(0, nullptr);</c>
	/// </para>
	/// <para>Create an upload heap for the constant buffers.</para>
	/// <para>
	/// <c>// Create an upload heap for the constant buffers. ThrowIfFailed(pDevice-&gt;CreateCommittedResource(
	/// &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE, &amp;D3D12_RESOURCE_DESC::Buffer(sizeof(ConstantBuffer)
	/// * m_cityRowCount * m_cityColumnCount), D3D12_RESOURCE_STATE_GENERIC_READ, nullptr, IID_PPV_ARGS(&amp;m_cbvUploadHeap))); // Map the
	/// constant buffers. Note that unlike D3D11, the resource // does not need to be unmapped for use by the GPU. In this sample, // the
	/// resource stays 'permanently' mapped to avoid overhead with // mapping/unmapping each frame. CD3DX12_RANGE readRange(0, 0); // We do
	/// not intend to read from this resource on the CPU. ThrowIfFailed(m_cbvUploadHeap-&gt;Map(0, &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;m_pConstantBuffers)));</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	public static HRESULT Map(this ID3D12Resource res, uint Subresource, [In, Optional] D3D12_RANGE? pReadRange)
	{
		using SafeCoTaskMemStruct<D3D12_RANGE> rng = pReadRange;
		return res.Map(Subresource, rng, default);
	}

	/// <summary>Sets application-defined data to a device object and associates that data with an application-defined <b>GUID</b>.</summary>
	/// <typeparam name="T">The data type.</typeparam>
	/// <param name="pObj">The <see cref="ID3D12Object"/> instance.</param>
	/// <param name="guid">The <b>GUID</b> to associate with the data.</param>
	/// <param name="pData">
	/// A pointer to a memory block that contains the data to be stored with this device object. If <i>pData</i> is <b>NULL</b>,
	/// <i>DataSize</i> must also be 0, and any data that was previously associated with the <b>GUID</b> specified in <i>guid</i> will be destroyed.
	/// </param>
	/// <remarks>
	/// Rather than using the Direct3D 11 debug object naming scheme of calling <b>ID3D12Object::SetPrivateData</b> using
	/// <b>WKPDID_D3DDebugObjectName</b> with an ASCII name, call <c>ID3D12Object::SetName</c> with a UNICODE name.
	/// </remarks>
	public static void SetPrivateData<T>(this ID3D12Object pObj, in Guid guid, T? pData) where T : struct
	{
		using var mem = pData is null ? SafeHGlobalHandle.Null : SafeHGlobalHandle.CreateFromStructure(pData);
		pObj.SetPrivateData(guid, (uint)mem.Size, mem).ThrowIfFailed();
	}
}