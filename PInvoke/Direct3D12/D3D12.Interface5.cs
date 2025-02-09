namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>
	/// An interface from which other core interfaces inherit from, including (but not limited to) <c>ID3D12PipelineLibrary</c>,
	/// <c>ID3D12CommandList</c>, <c>ID3D12Pageable</c>, and <c>ID3D12RootSignature</c>. It provides a method to get back to the device
	/// object it was created against.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12devicechild
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12DeviceChild")]
	[ComImport, Guid("905db94b-a00c-4140-9df5-2b64ca9ea357"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceChild : ID3D12Object
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
		HRESULT GetDevice(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvDevice);
	}

	/*
	[ComImport, Guid("78dbf87b-f766-422b-a61c-c8c446bdb9ad"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceConfiguration
	{
		[PreserveSig]
		D3D12_DEVICE_CONFIGURATION_DESC GetDesc();

		[PreserveSig]
		HRESULT GetEnabledExperimentalFeatures([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] pGuids, int NumGuids);

		[PreserveSig]
		HRESULT SerializeVersionedRootSignature(ref D3D12_VERSIONED_ROOT_SIGNATURE_DESC pDesc, out [In] ID3D10Blob ppResult, out ID3D10Blob ppError);

		[PreserveSig]
		HRESULT CreateVersionedRootSignatureDeserializer(IntPtr pBlob, IntPtr Size, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvDeserializer);
	}

	[ComImport, Guid("ed342442-6343-4e16-bb82-a3a577874e56"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceConfiguration1 : ID3D12DeviceConfiguration
	{
		[PreserveSig]
		new D3D12_DEVICE_CONFIGURATION_DESC GetDesc();

		[PreserveSig]
		new HRESULT GetEnabledExperimentalFeatures([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] Guid[] pGuids, int NumGuids);

		[PreserveSig]
		new HRESULT SerializeVersionedRootSignature(ref D3D12_VERSIONED_ROOT_SIGNATURE_DESC pDesc, out [In] ID3D10Blob ppResult, out ID3D10Blob ppError);

		[PreserveSig]
		new HRESULT CreateVersionedRootSignatureDeserializer(IntPtr pBlob, IntPtr Size, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvDeserializer);

		[PreserveSig]
		HRESULT CreateVersionedRootSignatureDeserializerFromSubobjectInLibrary(IntPtr pLibraryBlob, IntPtr Size, [MarshalAs(UnmanagedType.LPWStr)] string RootSignatureSubobjectName, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvDeserializer);
	}

	[ComImport, Guid("61f307d3-d34e-4e7c-8374-3ba4de23cccb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceFactory
	{
		[PreserveSig]
		HRESULT InitializeFromGlobalState();

		[PreserveSig]
		HRESULT ApplyToGlobalState();

		[PreserveSig]
		HRESULT SetFlags(D3D12_DEVICE_FACTORY_FLAGS flags);

		[PreserveSig]
		D3D12_DEVICE_FACTORY_FLAGS GetFlags();

		[PreserveSig]
		HRESULT GetConfigurationInterface(in Guid clsid, in Guid iid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		[PreserveSig]
		HRESULT EnableExperimentalFeatures(int NumFeatures, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] Guid[] pIIDs, IntPtr pConfigurationStructs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pConfigurationStructSizes);

		[PreserveSig]
		HRESULT CreateDevice([MarshalAs(UnmanagedType.Interface)] object adapter, D3D_FEATURE_LEVEL FeatureLevel, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvDevice);
	}
	*/

	/// <summary>
	/// Provides runtime access to Device Removed Extended Data (DRED) data. To retrieve the <b>ID3D12DeviceRemovedExtendedData</b>
	/// interface, call <c>QueryInterface</c> on an <c>ID3D12Device</c> (or derived) interface, passing the interface identifier (IID) of <b>ID3D12DeviceRemovedExtendedData</b>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12deviceremovedextendeddata
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12DeviceRemovedExtendedData")]
	[ComImport, Guid("98931d33-5ae8-4791-aa3c-1a73a2934e71"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(D3D12DeviceRemovedExtendedData))]
	public interface ID3D12DeviceRemovedExtendedData
	{
		/// <summary>Retrieves the Device Removed Extended Data (DRED) auto-breadcrumbs output after device removal.</summary>
		/// <param name="pOutput">
		/// An output parameter that takes the address of a <c>D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT</c> object. The object whose address is
		/// passed receives the data.
		/// </param>
		/// <returns>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c><c>error code</c>. Returns
		/// <b>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</b> if the device is not in a removed state. Returns <b>DXGI_ERROR_UNSUPPORTED</b> if
		/// auto-breadcrumbs have not been enabled with <c>ID3D12DeviceRemovedExtendedDataSettings::SetAutoBreadcrumbsEnablement</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata-getautobreadcrumbsoutput
		// HRESULT GetAutoBreadcrumbsOutput( D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT *pOutput );
		[PreserveSig]
		HRESULT GetAutoBreadcrumbsOutput(out D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT pOutput);

		/// <summary>
		/// Retrieves the Device Removed Extended Data (DRED) page fault data, including matching allocation for both living and
		/// recently-deleted runtime objects. The object whose address is passed receives the data.
		/// </summary>
		/// <param name="pOutput">An output parameter that takes the address of a <c>D3D12_DRED_PAGE_FAULT_OUTPUT</c> object.</param>
		/// <returns>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c><c>error code</c>. Returns
		/// <b>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</b> if the device is not in a removed state. Returns <b>DXGI_ERROR_UNSUPPORTED</b> if page
		/// fault reporting has not been enabled with <c>ID3D12DeviceRemovedExtendedDataSettings::SetPageFaultEnablement</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata-getpagefaultallocationoutput
		// HRESULT GetPageFaultAllocationOutput( D3D12_DRED_PAGE_FAULT_OUTPUT *pOutput );
		[PreserveSig]
		HRESULT GetPageFaultAllocationOutput(out D3D12_DRED_PAGE_FAULT_OUTPUT pOutput);
	}

	/// <summary>The <b>ID3D12DeviceRemovedExtendedData1</b> interface inherits from the ID3D12DeviceRemovedExtendedData interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12deviceremovedextendeddata1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12DeviceRemovedExtendedData1")]
	[ComImport, Guid("9727a022-cf1d-4dda-9eba-effa653fc506"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceRemovedExtendedData1 : ID3D12DeviceRemovedExtendedData
	{
		/// <summary>Retrieves the Device Removed Extended Data (DRED) auto-breadcrumbs output after device removal.</summary>
		/// <param name="pOutput">
		/// An output parameter that takes the address of a <c>D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT</c> object. The object whose address is
		/// passed receives the data.
		/// </param>
		/// <returns>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c><c>error code</c>. Returns
		/// <b>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</b> if the device is not in a removed state. Returns <b>DXGI_ERROR_UNSUPPORTED</b> if
		/// auto-breadcrumbs have not been enabled with <c>ID3D12DeviceRemovedExtendedDataSettings::SetAutoBreadcrumbsEnablement</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata-getautobreadcrumbsoutput
		// HRESULT GetAutoBreadcrumbsOutput( D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT *pOutput );
		[PreserveSig]
		new HRESULT GetAutoBreadcrumbsOutput(out D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT pOutput);

		/// <summary>
		/// Retrieves the Device Removed Extended Data (DRED) page fault data, including matching allocation for both living and
		/// recently-deleted runtime objects. The object whose address is passed receives the data.
		/// </summary>
		/// <param name="pOutput">An output parameter that takes the address of a <c>D3D12_DRED_PAGE_FAULT_OUTPUT</c> object.</param>
		/// <returns>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c><c>error code</c>. Returns
		/// <b>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</b> if the device is not in a removed state. Returns <b>DXGI_ERROR_UNSUPPORTED</b> if page
		/// fault reporting has not been enabled with <c>ID3D12DeviceRemovedExtendedDataSettings::SetPageFaultEnablement</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata-getpagefaultallocationoutput
		// HRESULT GetPageFaultAllocationOutput( D3D12_DRED_PAGE_FAULT_OUTPUT *pOutput );
		[PreserveSig]
		new HRESULT GetPageFaultAllocationOutput(out D3D12_DRED_PAGE_FAULT_OUTPUT pOutput);

		/// <summary/>
		/// <param name="pOutput"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata1-getautobreadcrumbsoutput1
		// HRESULT GetAutoBreadcrumbsOutput1( D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 *pOutput );
		[PreserveSig]
		HRESULT GetAutoBreadcrumbsOutput1(out D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 pOutput);

		/// <summary/>
		/// <param name="pOutput"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata1-getpagefaultallocationoutput1
		// HRESULT GetPageFaultAllocationOutput1( D3D12_DRED_PAGE_FAULT_OUTPUT1 *pOutput );
		[PreserveSig]
		HRESULT GetPageFaultAllocationOutput1(out D3D12_DRED_PAGE_FAULT_OUTPUT1 pOutput);
	}

	/// <summary>The <b>ID3D12DeviceRemovedExtendedData2</b> interface inherits from the ID3D12DeviceRemovedExtendedData1 interface.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12deviceremovedextendeddata2
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12DeviceRemovedExtendedData2")]
	[ComImport, Guid("67fc5816-e4ca-4915-bf18-42541272da54"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceRemovedExtendedData2 : ID3D12DeviceRemovedExtendedData1
	{
		/// <summary>Retrieves the Device Removed Extended Data (DRED) auto-breadcrumbs output after device removal.</summary>
		/// <param name="pOutput">
		/// An output parameter that takes the address of a <c>D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT</c> object. The object whose address is
		/// passed receives the data.
		/// </param>
		/// <returns>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c><c>error code</c>. Returns
		/// <b>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</b> if the device is not in a removed state. Returns <b>DXGI_ERROR_UNSUPPORTED</b> if
		/// auto-breadcrumbs have not been enabled with <c>ID3D12DeviceRemovedExtendedDataSettings::SetAutoBreadcrumbsEnablement</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata-getautobreadcrumbsoutput
		// HRESULT GetAutoBreadcrumbsOutput( D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT *pOutput );
		[PreserveSig]
		new HRESULT GetAutoBreadcrumbsOutput(out D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT pOutput);

		/// <summary>
		/// Retrieves the Device Removed Extended Data (DRED) page fault data, including matching allocation for both living and
		/// recently-deleted runtime objects. The object whose address is passed receives the data.
		/// </summary>
		/// <param name="pOutput">An output parameter that takes the address of a <c>D3D12_DRED_PAGE_FAULT_OUTPUT</c> object.</param>
		/// <returns>
		/// If the function succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <c>HRESULT</c><c>error code</c>. Returns
		/// <b>DXGI_ERROR_NOT_CURRENTLY_AVAILABLE</b> if the device is not in a removed state. Returns <b>DXGI_ERROR_UNSUPPORTED</b> if page
		/// fault reporting has not been enabled with <c>ID3D12DeviceRemovedExtendedDataSettings::SetPageFaultEnablement</c>.
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata-getpagefaultallocationoutput
		// HRESULT GetPageFaultAllocationOutput( D3D12_DRED_PAGE_FAULT_OUTPUT *pOutput );
		[PreserveSig]
		new HRESULT GetPageFaultAllocationOutput(out D3D12_DRED_PAGE_FAULT_OUTPUT pOutput);

		/// <summary/>
		/// <param name="pOutput"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata1-getautobreadcrumbsoutput1
		// HRESULT GetAutoBreadcrumbsOutput1( D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 *pOutput );
		[PreserveSig]
		new HRESULT GetAutoBreadcrumbsOutput1(out D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 pOutput);

		/// <summary/>
		/// <param name="pOutput"/>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddata1-getpagefaultallocationoutput1
		// HRESULT GetPageFaultAllocationOutput1( D3D12_DRED_PAGE_FAULT_OUTPUT1 *pOutput );
		[PreserveSig]
		new HRESULT GetPageFaultAllocationOutput1(out D3D12_DRED_PAGE_FAULT_OUTPUT1 pOutput);

		/// <summary/>
		[PreserveSig]
		HRESULT GetPageFaultAllocationOutput2(out D3D12_DRED_PAGE_FAULT_OUTPUT2 pOutput);

		/// <summary/>
		[PreserveSig]
		D3D12_DRED_DEVICE_STATE GetDeviceState();
	}

	/// <summary>
	/// This interface controls Device Removed Extended Data (DRED) settings. You should configure all DRED settings before you create a
	/// Direct3D 12 device. To retrieve the <b>ID3D12DeviceRemovedExtendedDataSettings</b> interface, call <c>D3D12GetDebugInterface</c>,
	/// passing the interface identifier (IID) of <b>ID3D12DeviceRemovedExtendedDataSettings</b>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12deviceremovedextendeddatasettings
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12DeviceRemovedExtendedDataSettings")]
	[ComImport, Guid("82bc481c-6b9b-4030-aedb-7ee3d1df1e63"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceRemovedExtendedDataSettings
	{
		/// <summary>Configures the enablement settings for Device Removed Extended Data (DRED) auto-breadcrumbs.</summary>
		/// <param name="Enablement">A <c>D3D12_DRED_ENABLEMENT</c> value. The default is <b>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</b>.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings-setautobreadcrumbsenablement
		// void SetAutoBreadcrumbsEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		void SetAutoBreadcrumbsEnablement(D3D12_DRED_ENABLEMENT Enablement);

		/// <summary>Configures the enablement settings for Device Removed Extended Data (DRED) page fault reporting.</summary>
		/// <param name="Enablement">A <c>D3D12_DRED_ENABLEMENT</c> value. The default is <b>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</b>.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings-setpagefaultenablement
		// void SetPageFaultEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		void SetPageFaultEnablement(D3D12_DRED_ENABLEMENT Enablement);

		/// <summary>
		/// Configures the enablement settings for Device Removed Extended Data (DRED) dump creation for <c>Windows Error Reporting
		/// (WER)</c>, also known as Watson.
		/// </summary>
		/// <param name="Enablement">A <c>D3D12_DRED_ENABLEMENT</c> value. The default is <b>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</b>.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings-setwatsondumpenablement
		// void SetWatsonDumpEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		void SetWatsonDumpEnablement(D3D12_DRED_ENABLEMENT Enablement);
	}

	/// <summary>
	/// The <b>ID3D12DeviceRemovedExtendedDataSettings1</b> interface inherits from the ID3D12DeviceRemovedExtendedDataSettings interface.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12deviceremovedextendeddatasettings1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12DeviceRemovedExtendedDataSettings1")]
	[ComImport, Guid("dbd5ae51-3317-4f0a-adf9-1d7cedcaae0b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceRemovedExtendedDataSettings1 : ID3D12DeviceRemovedExtendedDataSettings
	{
		/// <summary>Configures the enablement settings for Device Removed Extended Data (DRED) auto-breadcrumbs.</summary>
		/// <param name="Enablement">A <c>D3D12_DRED_ENABLEMENT</c> value. The default is <b>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</b>.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings-setautobreadcrumbsenablement
		// void SetAutoBreadcrumbsEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		new void SetAutoBreadcrumbsEnablement(D3D12_DRED_ENABLEMENT Enablement);

		/// <summary>Configures the enablement settings for Device Removed Extended Data (DRED) page fault reporting.</summary>
		/// <param name="Enablement">A <c>D3D12_DRED_ENABLEMENT</c> value. The default is <b>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</b>.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings-setpagefaultenablement
		// void SetPageFaultEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		new void SetPageFaultEnablement(D3D12_DRED_ENABLEMENT Enablement);

		/// <summary>
		/// Configures the enablement settings for Device Removed Extended Data (DRED) dump creation for <c>Windows Error Reporting
		/// (WER)</c>, also known as Watson.
		/// </summary>
		/// <param name="Enablement">A <c>D3D12_DRED_ENABLEMENT</c> value. The default is <b>D3D12_DRED_ENABLEMENT_SYSTEM_CONTROLLED</b>.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings-setwatsondumpenablement
		// void SetWatsonDumpEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		new void SetWatsonDumpEnablement(D3D12_DRED_ENABLEMENT Enablement);

		/// <summary/>
		/// <param name="Enablement"/>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12deviceremovedextendeddatasettings1-setbreadcrumbcontextenablement
		// void SetBreadcrumbContextEnablement( D3D12_DRED_ENABLEMENT Enablement );
		[PreserveSig]
		void SetBreadcrumbContextEnablement(D3D12_DRED_ENABLEMENT Enablement);
	}

	/*
	[ComImport, Guid("61552388-01ab-4008-a436-83db189566ea"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12DeviceRemovedExtendedDataSettings2 : ID3D12DeviceRemovedExtendedDataSettings1
	{
		[PreserveSig]
		new void SetAutoBreadcrumbsEnablement(D3D12_DRED_ENABLEMENT Enablement);

		[PreserveSig]
		new void SetPageFaultEnablement(D3D12_DRED_ENABLEMENT Enablement);

		[PreserveSig]
		new void SetWatsonDumpEnablement(D3D12_DRED_ENABLEMENT Enablement);

		[PreserveSig]
		new void SetBreadcrumbContextEnablement(D3D12_DRED_ENABLEMENT Enablement);

		[PreserveSig]
		void UseMarkersOnlyAutoBreadcrumbs(bool MarkersOnly);
	}
	*/

	/// <summary>Represents a fence, an object used for synchronization of the CPU and one or more GPUs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12fence
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Fence")]
	[ComImport, Guid("0a753dcf-c4d8-4b91-adf6-be5a60d95a76"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Fence : ID3D12Pageable
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

		/// <summary>Gets the current value of the fence.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>Returns the current value of the fence. If the device has been removed, the return value will be <b>UINT64_MAX</b>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence-getcompletedvalue UINT64 GetCompletedValue();
		[PreserveSig]
		ulong GetCompletedValue();

		/// <summary>Specifies an event that's raised when the fence reaches a certain value.</summary>
		/// <param name="Value">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The fence value when the event is to be signaled.</para>
		/// </param>
		/// <param name="hEvent">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>A handle to the event object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if the kernel components don�t have sufficient memory to store the event in a list. See
		/// <c>Direct3D 12 return codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To specify multiple fences before an event is triggered, refer to <c>SetEventOnMultipleFenceCompletion</c>.</para>
		/// <para>If hEvent is a null handle, then this API will not return until the specified fence value(s) have been reached.</para>
		/// <para>This method can be safely called from multiple threads at one time.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence-seteventoncompletion HRESULT SetEventOnCompletion(
		// UINT64 Value, HANDLE hEvent );
		[PreserveSig]
		HRESULT SetEventOnCompletion(ulong Value, HEVENT hEvent);

		/// <summary>Sets the fence to the specified value.</summary>
		/// <param name="Value">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The value to set the fence to.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// Use this method to set a fence value from the CPU side. Use <c>ID3D12CommandQueue::Signal</c> to set a fence from the GPU side.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence-signal HRESULT Signal( UINT64 Value );
		[PreserveSig]
		HRESULT Signal(ulong Value);
	}

	/// <summary>
	/// <para>
	/// Represents a fence. This interface extends <c>ID3D12Fence</c>, and supports the retrieval of the flags used to create the original
	/// fence. This new feature is useful primarily for opening shared fences.
	/// </para>
	/// <note><b>ID3D12Fence1</b> was introduced in the Windows 10 Fall Creators Update, and is the latest version of the <c>ID3D12Fence</c>
	/// interface. Applications targeting Windows 10 Fall Creators Update and later should use <b>ID3D12Fence1</b> instead of earlier versions.</note>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12fence1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12Fence1")]
	[ComImport, Guid("433685fe-e22b-4ca0-a8db-b5b4f4dd0e4a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12Fence1 : ID3D12Fence
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

		/// <summary>Gets the current value of the fence.</summary>
		/// <returns>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>Returns the current value of the fence. If the device has been removed, the return value will be <b>UINT64_MAX</b>.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence-getcompletedvalue UINT64 GetCompletedValue();
		[PreserveSig]
		new ulong GetCompletedValue();

		/// <summary>Specifies an event that's raised when the fence reaches a certain value.</summary>
		/// <param name="Value">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The fence value when the event is to be signaled.</para>
		/// </param>
		/// <param name="hEvent">
		/// <para>Type: <b><c>HANDLE</c></b></para>
		/// <para>A handle to the event object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>
		/// This method returns <b>E_OUTOFMEMORY</b> if the kernel components don�t have sufficient memory to store the event in a list. See
		/// <c>Direct3D 12 return codes</c> for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>To specify multiple fences before an event is triggered, refer to <c>SetEventOnMultipleFenceCompletion</c>.</para>
		/// <para>If hEvent is a null handle, then this API will not return until the specified fence value(s) have been reached.</para>
		/// <para>This method can be safely called from multiple threads at one time.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence-seteventoncompletion HRESULT SetEventOnCompletion(
		// UINT64 Value, HANDLE hEvent );
		[PreserveSig]
		new HRESULT SetEventOnCompletion(ulong Value, HEVENT hEvent);

		/// <summary>Sets the fence to the specified value.</summary>
		/// <param name="Value">
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The value to set the fence to.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>HRESULT</c></b></para>
		/// <para>This method returns one of the <c>Direct3D 12 Return Codes</c>.</para>
		/// </returns>
		/// <remarks>
		/// Use this method to set a fence value from the CPU side. Use <c>ID3D12CommandQueue::Signal</c> to set a fence from the GPU side.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence-signal HRESULT Signal( UINT64 Value );
		[PreserveSig]
		new HRESULT Signal(ulong Value);

		/// <summary>Gets the flags used to create the fence represented by the current instance.</summary>
		/// <returns>
		/// <para>Type: <b><c>D3D12_FENCE_FLAGS</c></b></para>
		/// <para>The flags used to create the fence.</para>
		/// </returns>
		/// <remarks>The flags returned by <b>GetCreationFlags</b> are used mainly for opening a shared fence.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12fence1-getcreationflags D3D12_FENCE_FLAGS GetCreationFlags();
		[PreserveSig]
		D3D12_FENCE_FLAGS GetCreationFlags();
	}

	/// <summary>
	/// <para>
	/// Encapsulates a list of graphics commands for rendering. Includes APIs for instrumenting the command list execution, and for setting
	/// and clearing the pipeline state.
	/// </para>
	/// <note>The latest version of this interface is <c>ID3D12GraphicsCommandList1</c> introduced in the Windows 10 Creators Update.
	/// Applications targetting Windows 10 Creators Update should use the <b>ID3D12GraphicsCommandList1</b> interface instead of <b>ID3D12GraphicsCommandList</b>.</note>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface is new to D3D12, encapsulating much of the functionality of the <c>ID3D11CommandList</c> interface, and including the
	/// new functionality described in <c>Rendering</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12GraphicsCommandList</b> as follows:</para>
	/// <para>Declare the pipeline objects.</para>
	/// <para>
	/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
	/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
	/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
	/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
	/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
	/// </para>
	/// <para>Populating command lists.</para>
	/// <para>
	/// <c>// Fill the command list with all the render commands and dependent state. void D3D12nBodyGravity::PopulateCommandList() { //
	/// Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps should use
	/// // fences to determine GPU execution progress. ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when
	/// ExecuteCommandList() is called on a particular command // list, that command list can then be reset at any time and must be before
	/// // re-recording. ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set
	/// necessary state. m_commandList-&gt;SetPipelineState(m_pipelineState.Get());
	/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get());
	/// m_commandList-&gt;SetGraphicsRootConstantBufferView(RootParameterCB, m_constantBufferGS-&gt;GetGPUVirtualAddress() + m_frameIndex *
	/// sizeof(ConstantBufferGS)); ID3D12DescriptorHeap* ppHeaps[] = { m_srvUavHeap.Get() };
	/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;IASetVertexBuffers(0, 1,
	/// &amp;m_vertexBufferView); m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_POINTLIST);
	/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
	/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
	/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
	/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
	/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
	/// 0.0f, 0.1f, 0.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); // Render the particles. float
	/// viewportHeight = static_cast&lt;float&gt;(static_cast&lt;UINT&gt;(m_viewport.Height) / m_heightInstances); float viewportWidth =
	/// static_cast&lt;float&gt;(static_cast&lt;UINT&gt;(m_viewport.Width) / m_widthInstances); for (UINT n = 0; n &lt; ThreadCount; n++) {
	/// const UINT srvIndex = n + (m_srvIndex[n] == 0 ? SrvParticlePosVelo0 : SrvParticlePosVelo1); D3D12_VIEWPORT viewport;
	/// viewport.TopLeftX = (n % m_widthInstances) * viewportWidth; viewport.TopLeftY = (n / m_widthInstances) * viewportHeight;
	/// viewport.Width = viewportWidth; viewport.Height = viewportHeight; viewport.MinDepth = D3D12_MIN_DEPTH; viewport.MaxDepth =
	/// D3D12_MAX_DEPTH; m_commandList-&gt;RSSetViewports(1, &amp;viewport); CD3DX12_GPU_DESCRIPTOR_HANDLE
	/// srvHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), srvIndex, m_srvUavDescriptorSize);
	/// m_commandList-&gt;SetGraphicsRootDescriptorTable(RootParameterSRV, srvHandle); m_commandList-&gt;DrawInstanced(ParticleCount, 1, 0,
	/// 0); } m_commandList-&gt;RSSetViewports(1, &amp;m_viewport); // Indicate that the back buffer will now be used to present.
	/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
	/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
	/// </para>
	/// <para>Refer to the <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12graphicscommandlist
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12GraphicsCommandList")]
	[ComImport, Guid("5b160d0f-ac1b-4185-8ba8-b3ae42a5a455"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12GraphicsCommandList : ID3D12CommandList
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
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::Close</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::LoadAssets() { // Create an empty root signature. { CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc;
		/// rootSignatureDesc.Init(0, nullptr, 0, nullptr, D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT);
		/// ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
		/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
		/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(),
		/// IID_PPV_ARGS(&amp;m_rootSignature))); } // Create the pipeline state, which includes compiling and loading shaders. {
		/// ComPtr&lt;ID3DBlob&gt; vertexShader; ComPtr&lt;ID3DBlob&gt; pixelShader; #if defined(_DEBUG) // Enable better shader debugging
		/// with the graphics debugging tools. UINT compileFlags = D3DCOMPILE_DEBUG | D3DCOMPILE_SKIP_OPTIMIZATION; #else UINT compileFlags
		/// = 0; #endif ThrowIfFailed(D3DCompileFromFile(GetAssetFullPath(L"shaders.hlsl").c_str(), nullptr, nullptr, "VSMain", "vs_5_0",
		/// compileFlags, 0, &amp;vertexShader, nullptr)); ThrowIfFailed(D3DCompileFromFile(GetAssetFullPath(L"shaders.hlsl").c_str(),
		/// nullptr, nullptr, "PSMain", "ps_5_0", compileFlags, 0, &amp;pixelShader, nullptr)); // Define the vertex input layout.
		/// D3D12_INPUT_ELEMENT_DESC inputElementDescs[] = { { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,
		/// D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, 0 }, { "COLOR", 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 12,
		/// D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, 0 } }; // Describe and create the graphics pipeline state object (PSO).
		/// D3D12_GRAPHICS_PIPELINE_STATE_DESC psoDesc = {}; psoDesc.InputLayout = { inputElementDescs, _countof(inputElementDescs) };
		/// psoDesc.pRootSignature = m_rootSignature.Get(); psoDesc.VS = {
		/// reinterpret_cast&lt;UINT8*&gt;(vertexShader-&gt;GetBufferPointer()), vertexShader-&gt;GetBufferSize() }; psoDesc.PS = {
		/// reinterpret_cast&lt;UINT8*&gt;(pixelShader-&gt;GetBufferPointer()), pixelShader-&gt;GetBufferSize() }; psoDesc.RasterizerState =
		/// CD3DX12_RASTERIZER_DESC(D3D12_DEFAULT); psoDesc.BlendState = CD3DX12_BLEND_DESC(D3D12_DEFAULT);
		/// psoDesc.DepthStencilState.DepthEnable = FALSE; psoDesc.DepthStencilState.StencilEnable = FALSE; psoDesc.SampleMask = UINT_MAX;
		/// psoDesc.PrimitiveTopologyType = D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE; psoDesc.NumRenderTargets = 1; psoDesc.RTVFormats[0] =
		/// DXGI_FORMAT_R8G8B8A8_UNORM; psoDesc.SampleDesc.Count = 1; ThrowIfFailed(m_device-&gt;CreateGraphicsPipelineState(&amp;psoDesc,
		/// IID_PPV_ARGS(&amp;m_pipelineState))); } // Create the command list. ThrowIfFailed(m_device-&gt;CreateCommandList(0,
		/// D3D12_COMMAND_LIST_TYPE_DIRECT, m_commandAllocator.Get(), m_pipelineState.Get(), IID_PPV_ARGS(&amp;m_commandList))); // Command
		/// lists are created in the recording state, but there is nothing // to record yet. The main loop expects it to be closed, so close
		/// it now. ThrowIfFailed(m_commandList-&gt;Close()); // Create the vertex buffer. { // Define the geometry for a triangle. Vertex
		/// triangleVertices[] = { { { 0.0f, 0.25f * m_aspectRatio, 0.0f }, { 1.0f, 0.0f, 0.0f, 1.0f } }, { { 0.25f, -0.25f * m_aspectRatio,
		/// 0.0f }, { 0.0f, 1.0f, 0.0f, 1.0f } }, { { -0.25f, -0.25f * m_aspectRatio, 0.0f }, { 0.0f, 0.0f, 1.0f, 1.0f } } }; const UINT
		/// vertexBufferSize = sizeof(triangleVertices); // Note: using upload heaps to transfer static data like vert buffers is not //
		/// recommended. Every time the GPU needs it, the upload heap will be marshalled // over. Please read up on Default Heap usage. An
		/// upload heap is used here for // code simplicity and because there are very few verts to actually transfer.
		/// ThrowIfFailed(m_device-&gt;CreateCommittedResource( &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE,
		/// &amp;D3D12_RESOURCE_DESC::Buffer(vertexBufferSize), D3D12_RESOURCE_STATE_GENERIC_READ, nullptr,
		/// IID_PPV_ARGS(&amp;m_vertexBuffer))); // Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE
		/// readRange(0, 0); // We do not intend to read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0,
		/// &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices,
		/// sizeof(triangleVertices)); m_vertexBuffer-&gt;Unmap(0, nullptr); // Initialize the vertex buffer view.
		/// m_vertexBufferView.BufferLocation = m_vertexBuffer-&gt;GetGPUVirtualAddress(); m_vertexBufferView.StrideInBytes =
		/// sizeof(Vertex); m_vertexBufferView.SizeInBytes = vertexBufferSize; } // Create synchronization objects and wait until assets
		/// have been uploaded to the GPU. { ThrowIfFailed(m_device-&gt;CreateFence(0, D3D12_FENCE_FLAG_NONE, IID_PPV_ARGS(&amp;m_fence)));
		/// m_fenceValue = 1; // Create an event handle to use for frame synchronization. m_fenceEvent = CreateEvent(nullptr, FALSE, FALSE,
		/// nullptr); if (m_fenceEvent == nullptr) { ThrowIfFailed(HRESULT_FROM_WIN32(GetLastError())); } // Wait for the command list to
		/// execute; we are reusing the same command // list in our main loop but for now, we just want to wait for setup to // complete
		/// before continuing. WaitForPreviousFrame(); } }</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-close HRESULT Close();
		[PreserveSig]
		HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <param name="pInitialState">
		/// <para>Type: <b>ID3D12PipelineState*</b></para>
		/// <para>
		/// A pointer to the <c>ID3D12PipelineState</c> object that contains the initial pipeline state for the command list. This is
		/// optional and can be NULL. If NULL, the runtime sets a dummy initial pipeline state so that drivers don't have to deal with
		/// undefined state. The overhead for this is low, particularly for a command list, for which the overall cost of recording the
		/// command list likely dwarfs the cost of one initial state setting. So there is little cost in not setting the initial pipeline
		/// state parameter if it isn't convenient.
		/// </para>
		/// <para>
		/// For bundles on the other hand, it might make more sense to try to set the initial state parameter since bundles are likely
		/// smaller overall and can be reused frequently.
		/// </para>
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
		/// <remarks>
		/// <para>
		/// By using <b>Reset</b>, you can re-use command list tracking structures without any allocations. Unlike
		/// <c>ID3D12CommandAllocator::Reset</c>, you can call <b>Reset</b> while the command list is still being executed.
		/// </para>
		/// <para>You can use <b>Reset</b> for both direct command lists and bundles.</para>
		/// <para>
		/// The command allocator passed to <b>Reset</b> cannot be associated with any other currently-recording command list. The allocator
		/// type, direct command list or bundle, must match the type of command list that is being created.
		/// </para>
		/// <para>
		/// If a bundle doesn't specify a resource heap, it can't make changes to which descriptor tables are bound. Either way, bundles
		/// can't change the resource heap within the bundle. If a heap is specified for a bundle, the heap must match the calling 'parent'
		/// command list�s heap.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>
		/// Before an app calls <b>Reset</b>, the command list must be in the "closed" state. <b>Reset</b> will fail if the command list
		/// isn't in the "closed" state.
		/// </para>
		/// <para>
		/// <b>Note</b>��If a call to <c>ID3D12GraphicsCommandList::Close</c> fails, the command list can never be reset. Calling
		/// <b>Reset</b> will result in the same error being returned that <b>ID3D12GraphicsCommandList::Close</b> returned.
		/// </para>
		/// <para></para>
		/// <para>
		/// After <b>Reset</b> succeeds, the command list is left in the "recording" state. <b>Reset</b> will fail if it would cause the
		/// maximum concurrently recording command list limit, which is specified at device creation, to be exceeded.
		/// </para>
		/// <para>
		/// Apps must specify a command list allocator. The runtime will ensure that an allocator is never associated with more than one
		/// recording command list at the same time.
		/// </para>
		/// <para><b>Reset</b> fails for bundles that are referenced by a not yet submitted command list.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will also track graphics processing unit (GPU) progress and issue an error if it can't prove that there are no
		/// outstanding executions of the command list.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::Reset</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-reset HRESULT Reset( [in]
		// ID3D12CommandAllocator *pAllocator, [in, optional] ID3D12PipelineState *pInitialState );
		[PreserveSig]
		HRESULT Reset([In] ID3D12CommandAllocator pAllocator, [In, Optional] ID3D12PipelineState? pInitialState);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <param name="pPipelineState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12PipelineState</c> object that contains the initial pipeline state for the command list.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// It is invalid to call <b>ClearState</b> on a bundle. If an app calls <b>ClearState</b> on a bundle, the call to <c>Close</c>
		/// will return <b>E_FAIL</b>.
		/// </para>
		/// <para>
		/// When <b>ClearState</b> is called, all currently bound resources are unbound. The primitive topology is set to
		/// <c>D3D_PRIMITIVE_TOPOLOGY_UNDEFINED</c>. Viewports, scissor rectangles, stencil reference value, and the blend factor are set to
		/// empty values (all zeros). Predication is disabled.
		/// </para>
		/// <para>The app-provided pipeline state object becomes bound as the currently set pipeline state object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearstate void ClearState( [in,
		// optional] ID3D12PipelineState *pPipelineState );
		[PreserveSig]
		void ClearState([In, Optional] ID3D12PipelineState? pPipelineState);

		/// <summary>Draws non-indexed, instanced primitives.</summary>
		/// <param name="VertexCountPerInstance">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Index of the first vertex.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors.
		/// </para>
		/// <para>
		/// The vertex data for an instanced draw call typically comes from a vertex buffer that is bound to the pipeline. But, you could
		/// also provide the vertex data from a shader that has instanced data identified with a system-value semantic (SV_InstanceID).
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::DrawInstanced</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-drawinstanced void DrawInstanced(
		// [in] UINT VertexCountPerInstance, [in] UINT InstanceCount, [in] UINT StartVertexLocation, [in] UINT StartInstanceLocation );
		[PreserveSig]
		void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		/// <summary>Draws indexed, instanced primitives.</summary>
		/// <param name="IndexCountPerInstance">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of indices read from the index buffer for each instance.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <b><c>INT</c></b></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors. Instancing requires multiple vertex buffers: at least one
		/// for per-vertex data and a second buffer for per-instance data.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::DrawIndexedInstanced</b> as follows:</para>
		/// <para>
		/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1,
		/// ID3D12PipelineState* pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc,
		/// D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize,
		/// ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root
		/// signature of the caller, then // bindings are inherited, otherwise the bind space is reset.
		/// pCommandList-&gt;SetGraphicsRootSignature(pRootSignature); ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap,
		/// pSamplerDescriptorHeap }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); //
		/// Calculate the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
		/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset,
		/// cbvSrvDescriptorSize); BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt;
		/// m_cityColumnCount; j++) { // Alternate which PSO to use; the pixel shader is different on // each just as a PSO setting
		/// demonstration. pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and
		/// move to the next descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle);
		/// cbvSrvHandle.Offset(cbvSrvDescriptorSize); pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-drawindexedinstanced void
		// DrawIndexedInstanced( [in] UINT IndexCountPerInstance, [in] UINT InstanceCount, [in] UINT StartIndexLocation, [in] INT
		// BaseVertexLocation, [in] UINT StartInstanceLocation );
		[PreserveSig]
		void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		/// <summary>Executes a command list from a thread group.</summary>
		/// <param name="ThreadGroupCountX">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the x direction. <i>ThreadGroupCountX</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountY">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the y direction. <i>ThreadGroupCountY</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountZ">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the z direction. <i>ThreadGroupCountZ</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535). In feature level 10 the value for <i>ThreadGroupCountZ</i> must be 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You call the <b>Dispatch</b> method to execute commands in a compute shader. A compute shader can be run on many threads in
		/// parallel, within a thread group. Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
		///  Examples The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12GraphicsCommandList::Dispatch</b> as follows:</para>
		/// <para>
		/// <c>// Run the particle simulation using the compute shader. void D3D12nBodyGravity::Simulate(UINT threadIndex) {
		/// ID3D12GraphicsCommandList* pCommandList = m_computeCommandList[threadIndex].Get(); UINT srvIndex; UINT uavIndex; ID3D12Resource
		/// *pUavResource; if (m_srvIndex[threadIndex] == 0) { srvIndex = SrvParticlePosVelo0; uavIndex = UavParticlePosVelo1; pUavResource
		/// = m_particleBuffer1[threadIndex].Get(); } else { srvIndex = SrvParticlePosVelo1; uavIndex = UavParticlePosVelo0; pUavResource =
		/// m_particleBuffer0[threadIndex].Get(); } pCommandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(pUavResource, D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE,
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS)); pCommandList-&gt;SetPipelineState(m_computeState.Get());
		/// pCommandList-&gt;SetComputeRootSignature(m_computeRootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_srvUavHeap.Get()
		/// }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// srvHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), srvIndex + threadIndex, m_srvUavDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE uavHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), uavIndex + threadIndex,
		/// m_srvUavDescriptorSize); pCommandList-&gt;SetComputeRootConstantBufferView(RootParameterCB,
		/// m_constantBufferCS-&gt;GetGPUVirtualAddress()); pCommandList-&gt;SetComputeRootDescriptorTable(RootParameterSRV, srvHandle);
		/// pCommandList-&gt;SetComputeRootDescriptorTable(RootParameterUAV, uavHandle);
		/// pCommandList-&gt;Dispatch(static_cast&lt;int&gt;(ceil(ParticleCount / 128.0f)), 1, 1); pCommandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(pUavResource, D3D12_RESOURCE_STATE_UNORDERED_ACCESS,
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE)); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-dispatch void Dispatch( [in] UINT
		// ThreadGroupCountX, [in] UINT ThreadGroupCountY, [in] UINT ThreadGroupCountZ );
		[PreserveSig]
		void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		/// <summary>Copies a region of a buffer from one resource to another.</summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies the destination <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 offset (in bytes) into the destination resource.</para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies the source <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 offset (in bytes) into the source resource, to start the copy from.</para>
		/// </param>
		/// <param name="NumBytes">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies the number of bytes to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Consider using the <c>CopyResource</c> method when copying an entire resource, and use this method for copying regions of a resource.
		/// </para>
		/// <para>
		/// <b>CopyBufferRegion</b> may be used to initialize resources which alias the same heap memory. See <c>CreatePlacedResource</c>
		/// for more details.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::CopyBufferRegion</b> as follows:</para>
		/// <para>
		/// <c>inline UINT64 UpdateSubresources( _In_ ID3D12GraphicsCommandList* pCmdList, _In_ ID3D12Resource* pDestinationResource, _In_
		/// ID3D12Resource* pIntermediate, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources, UINT64 RequiredSize, _In_reads_(NumSubresources)
		/// const D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayouts, _In_reads_(NumSubresources) const UINT* pNumRows,
		/// _In_reads_(NumSubresources) const UINT64* pRowSizesInBytes, _In_reads_(NumSubresources) const D3D12_SUBRESOURCE_DATA* pSrcData)
		/// { // Minor validation D3D12_RESOURCE_DESC IntermediateDesc = pIntermediate-&gt;GetDesc(); D3D12_RESOURCE_DESC DestinationDesc =
		/// pDestinationResource-&gt;GetDesc(); if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER || IntermediateDesc.Width
		/// &lt; RequiredSize + pLayouts[0].Offset || RequiredSize &gt; (SIZE_T)-1 || (DestinationDesc.Dimension ==
		/// D3D12_RESOURCE_DIMENSION_BUFFER &amp;&amp; (FirstSubresource != 0 || NumSubresources != 1))) { return 0; } BYTE* pData; HRESULT
		/// hr = pIntermediate-&gt;Map(0, NULL, reinterpret_cast&lt;void**&gt;(&amp;pData)); if (FAILED(hr)) { return 0; } for (UINT i = 0;
		/// i &lt; NumSubresources; ++i) { if (pRowSizesInBytes[i] &gt; (SIZE_T)-1) return 0; D3D12_MEMCPY_DEST DestData = { pData +
		/// pLayouts[i].Offset, pLayouts[i].Footprint.RowPitch, pLayouts[i].Footprint.RowPitch * pNumRows[i] };
		/// MemcpySubresource(&amp;DestData, &amp;pSrcData[i], (SIZE_T)pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth); }
		/// pIntermediate-&gt;Unmap(0, NULL); if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION_BUFFER) { CD3DX12_BOX SrcBox( UINT(
		/// pLayouts[0].Offset ), UINT( pLayouts[0].Offset + pLayouts[0].Footprint.Width ) ); pCmdList-&gt;CopyBufferRegion(
		/// pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width); } else { for (UINT i = 0; i &lt;
		/// NumSubresources; ++i) { CD3DX12_TEXTURE_COPY_LOCATION Dst(pDestinationResource, i + FirstSubresource);
		/// CD3DX12_TEXTURE_COPY_LOCATION Src(pIntermediate, pLayouts[i]); pCmdList-&gt;CopyTextureRegion(&amp;Dst, 0, 0, 0, &amp;Src,
		/// nullptr); } } return RequiredSize; }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copybufferregion void
		// CopyBufferRegion( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset, UINT64
		// NumBytes );
		[PreserveSig]
		void CopyBufferRegion([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, ulong NumBytes);

		/// <summary>
		/// This method uses the GPU to copy texture data between two locations. Both the source and the destination may reference texture
		/// data located within either a buffer resource or a texture resource.
		/// </summary>
		/// <param name="pDst">
		/// <para>Type: <b>const <c>D3D12_TEXTURE_COPY_LOCATION</c>*</b></para>
		/// <para>
		/// Specifies the destination <c>D3D12_TEXTURE_COPY_LOCATION</c>. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COPY_DEST state.
		/// </para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The x-coordinate of the upper left corner of the destination region.</para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The y-coordinate of the upper left corner of the destination region. For a 1D subresource, this must be zero.</para>
		/// </param>
		/// <param name="DstZ">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The z-coordinate of the upper left corner of the destination region. For a 1D or 2D subresource, this must be zero.</para>
		/// </param>
		/// <param name="pSrc">
		/// <para>Type: <b>const <c>D3D12_TEXTURE_COPY_LOCATION</c>*</b></para>
		/// <para>
		/// Specifies the source <c>D3D12_TEXTURE_COPY_LOCATION</c>. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COPY_SOURCE state.
		/// </para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>Specifies an optional D3D12_BOX that sets the size of the source texture to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source box must be within the size of the source resource. The destination offsets, (x, y, and z), allow the source box to
		/// be offset when writing into the destination resource; however, the dimensions of the source box and the offsets must be within
		/// the size of the resource. If you try and copy outside the destination resource or specify a source box that is larger than the
		/// source resource, the behavior of <b>CopyTextureRegion</b> is undefined. If you created a device that supports the <c>debug
		/// layer</c>, the debug output reports an error on this invalid <b>CopyTextureRegion</b> call. Invalid parameters to
		/// <b>CopyTextureRegion</b> cause undefined behavior and might result in incorrect rendering, clipping, no copy, or even the
		/// removal of the rendering device.
		/// </para>
		/// <para>If the resources are buffers, all coordinates are in bytes; if the resources are textures, all coordinates are in texels.</para>
		/// <para>
		/// <b>CopyTextureRegion</b> performs the copy on the GPU (similar to a <c>memcpy</c> by the CPU). As a consequence, the source and
		/// destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different subresources (although they can be from the same resource).</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible <c>DXGI_FORMAT</c> s (identical or from the same type group). For example, a DXGI_FORMAT_R32G32B32_FLOAT
		/// texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in the
		/// DXGI_FORMAT_R32G32B32_TYPELESS group. <b>CopyTextureRegion</b> can copy between a few format types. For more info, see <c>Format
		/// Conversion using Direct3D 10.1</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>CopyTextureRegion</b> only supports copy; it does not support any stretch, color key, or blend. <b>CopyTextureRegion</b> can
		/// reinterpret the resource data between a few format types.
		/// </para>
		/// <para>Note that for a depth-stencil buffer, the depth and stencil planes are <c>separate subresources</c> within the buffer.</para>
		/// <para>To copy an entire resource, rather than just a region of a subresource, we recommend to use <c>CopyResource</c> instead.</para>
		/// <para>
		/// <b>Note</b>��If you use <b>CopyTextureRegion</b> with a depth-stencil buffer or a multisampled resource, you must copy the
		/// entire subresource rectangle. In this situation, you must pass 0 to the <i>DstX</i>, <i>DstY</i>, and <i>DstZ</i> parameters and
		/// <b>NULL</b> to the <i>pSrcBox</i> parameter. In addition, source and destination resources, which are represented by the
		/// <i>pSrcResource</i> and <i>pDstResource</i> parameters, should have identical sample count values.
		/// </para>
		/// <para></para>
		/// <para>
		/// <b>CopyTextureRegion</b> may be used to initialize resources which alias the same heap memory. See <c>CreatePlacedResource</c>
		/// for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Example</para>
		/// <para>
		/// The following code snippet copies the box (located at (120,100),(200,220)) from a source texture into the region
		/// (10,20),(90,140) in a destination texture.
		/// </para>
		/// <para>
		/// <c>D3D12_BOX sourceRegion; sourceRegion.left = 120; sourceRegion.top = 100; sourceRegion.right = 200; sourceRegion.bottom = 220;
		/// sourceRegion.front = 0; sourceRegion.back = 1; pCmdList -&gt; CopyTextureRegion(pDestTexture, 10, 20, 0, pSourceTexture, &amp;sourceRegion);</c>
		/// </para>
		/// <para>Notice, that for a 2D texture, front and back are set to 0 and 1 respectively. Examples The <b>HelloTriangle</b> sample uses <b>ID3D12GraphicsCommandList::CopyTextureRegion</b> as follows:</para>
		/// <para>
		/// <c>inline UINT64 UpdateSubresources( _In_ ID3D12GraphicsCommandList* pCmdList, _In_ ID3D12Resource* pDestinationResource, _In_
		/// ID3D12Resource* pIntermediate, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources, UINT64 RequiredSize, _In_reads_(NumSubresources)
		/// const D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayouts, _In_reads_(NumSubresources) const UINT* pNumRows,
		/// _In_reads_(NumSubresources) const UINT64* pRowSizesInBytes, _In_reads_(NumSubresources) const D3D12_SUBRESOURCE_DATA* pSrcData)
		/// { // Minor validation D3D12_RESOURCE_DESC IntermediateDesc = pIntermediate-&gt;GetDesc(); D3D12_RESOURCE_DESC DestinationDesc =
		/// pDestinationResource-&gt;GetDesc(); if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER || IntermediateDesc.Width
		/// &lt; RequiredSize + pLayouts[0].Offset || RequiredSize &gt; (SIZE_T)-1 || (DestinationDesc.Dimension ==
		/// D3D12_RESOURCE_DIMENSION_BUFFER &amp;&amp; (FirstSubresource != 0 || NumSubresources != 1))) { return 0; } BYTE* pData; HRESULT
		/// hr = pIntermediate-&gt;Map(0, NULL, reinterpret_cast&lt;void**&gt;(&amp;pData)); if (FAILED(hr)) { return 0; } for (UINT i = 0;
		/// i &lt; NumSubresources; ++i) { if (pRowSizesInBytes[i] &gt; (SIZE_T)-1) return 0; D3D12_MEMCPY_DEST DestData = { pData +
		/// pLayouts[i].Offset, pLayouts[i].Footprint.RowPitch, pLayouts[i].Footprint.RowPitch * pNumRows[i] };
		/// MemcpySubresource(&amp;DestData, &amp;pSrcData[i], (SIZE_T)pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth); }
		/// pIntermediate-&gt;Unmap(0, NULL); if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION_BUFFER) { CD3DX12_BOX SrcBox( UINT(
		/// pLayouts[0].Offset ), UINT( pLayouts[0].Offset + pLayouts[0].Footprint.Width ) ); pCmdList-&gt;CopyBufferRegion(
		/// pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width); } else { for (UINT i = 0; i &lt;
		/// NumSubresources; ++i) { CD3DX12_TEXTURE_COPY_LOCATION Dst(pDestinationResource, i + FirstSubresource);
		/// CD3DX12_TEXTURE_COPY_LOCATION Src(pIntermediate, pLayouts[i]); pCmdList-&gt;CopyTextureRegion(&amp;Dst, 0, 0, 0, &amp;Src,
		/// nullptr); } } return RequiredSize; }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copytextureregion void
		// CopyTextureRegion( [in] const D3D12_TEXTURE_COPY_LOCATION *pDst, UINT DstX, UINT DstY, UINT DstZ, [in] const
		// D3D12_TEXTURE_COPY_LOCATION *pSrc, [in, optional] const D3D12_BOX *pSrcBox );
		[PreserveSig]
		void CopyTextureRegion(in D3D12_TEXTURE_COPY_LOCATION pDst, uint DstX, uint DstY, uint DstZ, in D3D12_TEXTURE_COPY_LOCATION pSrc,
			[In, Optional] StructPointer<D3D12_BOX> pSrcBox);

		/// <summary>Copies the entire contents of the source resource to the destination resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the destination resource.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the source resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>CopyResource</b> operations are performed on the GPU, and do not incur a significant CPU workload linearly dependent on the
		/// size of the data to copy.
		/// </para>
		/// <para>
		/// <b>CopyResource</b> can be used to initialize resources that alias the same heap memory. See <c>CreatePlacedResource</c> for
		/// more details.
		/// </para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues an error if the source subresource is not in the <c>D3D12_RESOURCE_STATE_COPY_SOURCE</c> state.</para>
		/// <para>The debug layer issues an error if the destination subresource is not in the <c>D3D12_RESOURCE_STATE_COPY_DEST</c> state. Restrictions This method has a few restrictions designed for improving performance. For instance, the source and destination resources:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different resources.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same total size (bytes).</description>
		/// </item>
		/// <item>
		/// <description>Must have identical dimensions (width, height, depth) or be a compatible <c>Reinterpret Copy</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible <c>DXGI formats</c>, which means the formats must be identical or at least from the same type group. For
		/// example, a DXGI_FORMAT_R32G32B32_FLOAT texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats
		/// are in the DXGI_FORMAT_R32G32B32_TYPELESS group. <b>CopyResource</b> can copy between a few format types (see <c>Reinterpret copy</c>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>Can't be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para><b>CopyResource</b> only supports copy; it doesn't support any stretch, color key, or blend.</para>
		/// <para>
		/// <b>CopyResource</b> can reinterpret the resource data between a few format types, see <c>Reinterpret Copy</c> below for details.
		/// </para>
		/// <para>
		/// You can use a <c>depth-stencil</c> resource as either a source or a destination. Resources created with multi-sampling
		/// capability (see <c>DXGI_SAMPLE_DESC</c>) can be used as source and destination only if both source and destination have
		/// identical multi-sampled count and quality. If source and destination differ in multi-sampled count and quality or if one is
		/// multi-sampled and the other is not multi-sampled, the call to <b>CopyResource</b> fails. Use <c>ResolveSubresource</c> to
		/// resolve a multi-sampled resource to a resource that is not multi-sampled.
		/// </para>
		/// <para>
		/// The method is an asynchronous call, which may be added to the command-buffer queue. This attempts to remove pipeline stalls that
		/// may occur when copying data. For more info, see <c>performance considerations</c>.
		/// </para>
		/// <para>
		/// Consider using <c>CopyTextureRegion</c> or <c>CopyBufferRegion</c> if you only need to copy a portion of the data in a resource.
		/// </para>
		/// <para>Reinterpret copy</para>
		/// <para>
		/// The following table lists the allowable source and destination formats that you can use in the reinterpretation type of format
		/// conversion. The underlying data values are not converted or compressed/decompressed and must be encoded properly for the
		/// reinterpretation to work as expected. For more info, see <c>Format Conversion using Direct3D 10.1</c>.
		/// </para>
		/// <para>For DXGI_FORMAT_R9G9B9E5_SHAREDEXP the width and height must be equal (1 texel per block).</para>
		/// <para>
		/// Block-compressed resource width and height must be 4 times the uncompressed resource width and height (16 texels per block). For
		/// example, a uncompressed 256x256 DXGI_FORMAT_R32G32B32A32_UINT texture will map to a 1024x1024 DXGI_FORMAT_BC5_UNORM compressed texture.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Bit width</description>
		/// <description>Uncompressed resource</description>
		/// <description>Block-compressed resource</description>
		/// <description>Width / height difference</description>
		/// </listheader>
		/// <item>
		/// <description>32</description>
		/// <description>DXGI_FORMAT_R32_UINT DXGI_FORMAT_R32_SINT</description>
		/// <description>DXGI_FORMAT_R9G9B9E5_SHAREDEXP</description>
		/// <description>1:1</description>
		/// </item>
		/// <item>
		/// <description>64</description>
		/// <description>DXGI_FORMAT_R16G16B16A16_UINT DXGI_FORMAT_R16G16B16A16_SINT DXGI_FORMAT_R32G32_UINT DXGI_FORMAT_R32G32_SINT</description>
		/// <description>DXGI_FORMAT_BC1_UNORM[_SRGB] DXGI_FORMAT_BC4_UNORM DXGI_FORMAT_BC4_SNORM</description>
		/// <description>1:4</description>
		/// </item>
		/// <item>
		/// <description>128</description>
		/// <description>DXGI_FORMAT_R32G32B32A32_UINT DXGI_FORMAT_R32G32B32A32_SINT</description>
		/// <description>DXGI_FORMAT_BC2_UNORM[_SRGB] DXGI_FORMAT_BC3_UNORM[_SRGB] DXGI_FORMAT_BC5_UNORM DXGI_FORMAT_BC5_SNORM</description>
		/// <description>1:4</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copyresource void CopyResource( [in]
		// ID3D12Resource *pDstResource, [in] ID3D12Resource *pSrcResource );
		[PreserveSig]
		void CopyResource([In] ID3D12Resource pDstResource, [In] ID3D12Resource pSrcResource);

		/// <summary>Copies tiles from buffer to tiled resource or vice versa.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to a tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionStartCoordinate">
		/// <para>Type: <b>const <c>D3D12_TILED_RESOURCE_COORDINATE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_TILED_RESOURCE_COORDINATE</c> structure that describes the starting coordinates of the tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionSize">
		/// <para>Type: <b>const <c>D3D12_TILE_REGION_SIZE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_TILE_REGION_SIZE</c> structure that describes the size of the tiled region.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to an <c>ID3D12Resource</c> that represents a default, dynamic, or staging buffer.</para>
		/// </param>
		/// <param name="BufferStartOffsetInBytes">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset in bytes into the buffer at <i>pBuffer</i> to start the operation.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_TILE_COPY_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_TILE_COPY_FLAGS</c>-typed values that are combined by using a bitwise OR operation and that identifies
		/// how to copy tiles.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>CopyTiles</b> drops write operations to unmapped areas and handles read operations from unmapped areas (except on Tier_1
		/// tiled resources, where reading and writing unmapped areas is invalid - refer to <c>D3D12_TILED_RESOURCES_TIER</c>).
		/// </para>
		/// <para>
		/// If a copy operation involves writing to the same memory location multiple times because multiple locations in the destination
		/// resource are mapped to the same tile memory, the resulting write operations to multi-mapped tiles are non-deterministic and
		/// non-repeatable; that is, accesses to the tile memory happen in whatever order the hardware happens to execute the copy operation.
		/// </para>
		/// <para>
		/// The tiles involved in the copy operation can't include tiles that contain packed mipmaps or results of the copy operation are
		/// undefined. To transfer data to and from mipmaps that the hardware packs into the one-or-more tiles that constitute the packed
		/// mips, you must use the standard (that is, non-tile specific) copy APIs like <c>CopyTextureRegion</c>.
		/// </para>
		/// <para><b>CopyTiles</b> does copy data in a slightly different pattern than the standard copy methods.</para>
		/// <para>
		/// The memory layout of the tiles in the non-tiled buffer resource side of the copy operation is linear in memory within 64 KB
		/// tiles, which the hardware and driver swizzle and de-swizzle per tile as appropriate when they transfer to and from a tiled
		/// resource. For multisample antialiasing (MSAA) surfaces, the hardware and driver traverse each pixel's samples in sample-index
		/// order before they move to the next pixel. For tiles that are partially filled on the right side (for a surface that has a width
		/// not a multiple of tile width in pixels), the pitch and stride to move down a row is the full size in bytes of the number pixels
		/// that would fit across the tile if the tile was full. So, there can be a gap between each row of pixels in memory. Mipmaps that
		/// are smaller than a tile are not packed together in the linear layout, which might seem to be a waste of memory space, but as
		/// mentioned you can't use <b>CopyTiles</b> to copy to mipmaps that the hardware packs together. You can just use generic copy
		/// APIs, like <c>CopyTextureRegion</c>, to copy small mipmaps individually.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copytiles void CopyTiles( [in]
		// ID3D12Resource *pTiledResource, [in] const D3D12_TILED_RESOURCE_COORDINATE *pTileRegionStartCoordinate, [in] const
		// D3D12_TILE_REGION_SIZE *pTileRegionSize, [in] ID3D12Resource *pBuffer, UINT64 BufferStartOffsetInBytes, D3D12_TILE_COPY_FLAGS
		// Flags );
		[PreserveSig]
		void CopyTiles([In] ID3D12Resource pTiledResource, in D3D12_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate,
			in D3D12_TILE_REGION_SIZE pTileRegionSize, [In] ID3D12Resource pBuffer, ulong BufferStartOffsetInBytes, D3D12_TILE_COPY_FLAGS Flags);

		/// <summary>Copy a multi-sampled resource into a non-multi-sampled resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: [in] <b>ID3D12Resource*</b></para>
		/// <para>Destination resource. Must be a created on a <c>D3D12_HEAP_TYPE_DEFAULT</c> heap and be single-sampled. See <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>
		/// A zero-based index, that identifies the destination subresource. Use <c>D3D12CalcSubresource</c> to calculate the subresource
		/// index if the parent resource is complex.
		/// </para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: [in] <b>ID3D12Resource*</b></para>
		/// <para>Source resource. Must be multisampled.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The source subresource of the source resource.</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: [in] <b>DXGI_FORMAT</b></para>
		/// <para>A <c>DXGI_FORMAT</c> that indicates how the multisampled resource will be resolved to a single-sampled resource. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the source view is not in the
		/// <c>D3D12_RESOURCE_STATE_RESOLVE_SOURCE</c> state.
		/// </para>
		/// <para>The debug layer will issue an error if the destination buffer is not in the <c>D3D12_RESOURCE_STATE_RESOLVE_DEST</c> state.</para>
		/// <para>
		/// The source and destination resources must be the same resource type and have the same dimensions. In addition, they must have
		/// compatible formats. There are three scenarios for this:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Scenario</description>
		/// <description>Requirements</description>
		/// </listheader>
		/// <item>
		/// <description>Source and destination are prestructured and typed</description>
		/// <description>
		/// Both the source and destination must have identical formats and that format must be specified in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>One resource is prestructured and typed and the other is prestructured and typeless</description>
		/// <description>
		/// The typed resource must have a format that is compatible with the typeless resource (i.e. the typed resource is
		/// DXGI_FORMAT_R32_FLOAT and the typeless resource is DXGI_FORMAT_R32_TYPELESS). The format of the typed resource must be specified
		/// in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Source and destination are prestructured and typeless</description>
		/// <description>
		/// Both the source and destination must have the same typeless format (i.e. both must have DXGI_FORMAT_R32_TYPELESS), and the
		/// Format parameter must specify a format that is compatible with the source and destination (i.e. if both are
		/// DXGI_FORMAT_R32_TYPELESS then DXGI_FORMAT_R32_FLOAT could be specified in the Format parameter). For example, given the
		/// DXGI_FORMAT_R16G16B16A16_TYPELESS format:
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resolvesubresource void
		// ResolveSubresource( ID3D12Resource *pDstResource, UINT DstSubresource, ID3D12Resource *pSrcResource, UINT SrcSubresource,
		// DXGI_FORMAT Format );
		[PreserveSig]
		void ResolveSubresource([In] ID3D12Resource pDstResource, uint DstSubresource, [In] ID3D12Resource pSrcResource, uint SrcSubresource,
			DXGI_FORMAT Format);

		/// <summary>Bind information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="PrimitiveTopology">
		/// <para>Type: <b>D3D12_PRIMITIVE_TOPOLOGY</b></para>
		/// <para>The type of primitive and ordering of the primitive data (see <c>D3D_PRIMITIVE_TOPOLOGY</c>).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetprimitivetopology void
		// IASetPrimitiveTopology( [in] D3D12_PRIMITIVE_TOPOLOGY PrimitiveTopology );
		[PreserveSig]
		void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY PrimitiveTopology);

		/// <summary>Bind an array of viewports to the rasterizer stage of the pipeline.</summary>
		/// <param name="NumViewports">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Number of viewports to bind. The range of valid values is (0, D3D12_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE).</para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <b>const <c>D3D12_VIEWPORT</c>*</b></para>
		/// <para>An array of <c>D3D12_VIEWPORT</c> structures to bind to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All viewports must be set atomically as one operation. Any viewports not defined by the call are disabled.</para>
		/// <para>
		/// Which viewport to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader; if a geometry
		/// shader does not specify the semantic, Direct3D will use the first viewport in the array.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::RSSetViewports</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-rssetviewports void RSSetViewports(
		// [in] UINT NumViewports, [in] const D3D12_VIEWPORT *pViewports );
		[PreserveSig]
		void RSSetViewports(int NumViewports, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_VIEWPORT[] pViewports);

		/// <summary>Binds an array of scissor rectangles to the rasterizer stage.</summary>
		/// <param name="NumRects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of scissor rectangles to bind.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const D3D12_RECT*</b></para>
		/// <para>An array of scissor rectangles.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All scissor rectangles must be set atomically as one operation. Any scissor rectangles not defined by the call are disabled.</para>
		/// <para>
		/// Which scissor rectangle to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader (see
		/// shader semantic syntax). If a geometry shader does not make use of the <c>SV_ViewportArrayIndex</c> semantic then Direct3D will
		/// use the first scissor rectangle in the array.
		/// </para>
		/// <para>Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see <c>RSSetViewports</c>). Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::RSSetScissorRects</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>// Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps
		/// should use // fences to determine GPU execution progress. ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when
		/// ExecuteCommandList() is called on a particular command // list, that command list can then be reset at any time and must be
		/// before // re-recording. ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set
		/// necessary state. m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1,
		/// &amp;m_viewport); m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a
		/// render target. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close());</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-rssetscissorrects void
		// RSSetScissorRects( [in] UINT NumRects, [in] const D3D12_RECT *pRects );
		[PreserveSig]
		void RSSetScissorRects(int NumRects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		/// <summary>Sets the blend factor that modulate values for a pixel shader, render target, or both.</summary>
		/// <param name="BlendFactor">
		/// <para>Type: <b>const FLOAT[4]</b></para>
		/// <para>Array of blend factors, one for each RGBA component.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If you created the blend-state object with <c>D3D12_BLEND_BLEND_FACTOR</c> or <b>D3D12_BLEND_INV_BLEND_FACTOR</b>, then the
		/// blending stage uses the non-NULL array of blend factors. Otherwise,the blending stage doesn't use the non-NULL array of blend
		/// factors; the runtime stores the blend factors.
		/// </para>
		/// <para>If you pass NULL, then the runtime uses or stores a blend factor equal to <c>{ 1, 1, 1, 1 }</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetblendfactor void
		// OMSetBlendFactor( [in, optional] const FLOAT [4] BlendFactor );
		[PreserveSig]
		void OMSetBlendFactor([In, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[]? BlendFactor);

		/// <summary>Sets the reference value for depth stencil tests.</summary>
		/// <param name="StencilRef">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Reference value to perform against when doing a depth-stencil test.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetstencilref void
		// OMSetStencilRef( [in] UINT StencilRef );
		[PreserveSig]
		void OMSetStencilRef(uint StencilRef);

		/// <summary>Sets all shaders and programs most of the fixed-function state of the graphics processing unit (GPU) pipeline.</summary>
		/// <param name="pPipelineState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>Pointer to the <c>ID3D12PipelineState</c> containing the pipeline state data.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setpipelinestate void
		// SetPipelineState( [in] ID3D12PipelineState *pPipelineState );
		[PreserveSig]
		void SetPipelineState([In] ID3D12PipelineState pPipelineState);

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
		/// <remarks>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// A resource to be used for the <c>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</c> state must be created in that state,
		/// and then never transitioned out of it. Nor may a resource that was created not in that state be transitioned into it. For more
		/// info, see <c>Acceleration structure memory restrictions</c> in the DirectX raytracing (DXR) functional specification on GitHub.
		/// </para>
		/// </para>
		/// <para>There are three types of barrier descriptions:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_TRANSITION_BARRIER</c> - Transition barriers indicate that a set of subresources transition between different
		/// usages. The caller must specify the <i>before</i> and <i>after</i> usages of the subresources. The
		/// D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES flag is used to transition all subresources in a resource at the same time.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_ALIASING_BARRIER</c> - Aliasing barriers indicate a transition between usages of two different resources which
		/// have mappings into the same heap. The application can specify both the before and the after resource. Note that one or both
		/// resources can be NULL (indicating that any tiled resource could cause aliasing).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_UAV_BARRIER</c> - Unordered access view barriers indicate all UAV accesses (read or writes) to a particular
		/// resource must complete before any future UAV accesses (read or write) can begin. The specified resource may be NULL. It is not
		/// necessary to insert a UAV barrier between two draw or dispatch calls which only read a UAV. Additionally, it is not necessary to
		/// insert a UAV barrier between two draw or dispatch calls which write to the same UAV if the application knows that it is safe to
		/// execute the UAV accesses in any order. The resource can be NULL (indicating that any UAV access could require the barrier).
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// When <b>ID3D12GraphicsCommandList::ResourceBarrier</b> is passed an array of resource barrier descriptions, the API behaves as
		/// if it was called N times (1 for each array element), in the specified order. Transitions should be batched together into a
		/// single API call when possible, as a performance optimization.
		/// </para>
		/// <para>
		/// For descriptions of the usage states a subresource can be in, see the <c>D3D12_RESOURCE_STATES</c> enumeration and the <c>Using
		/// Resource Barriers to Synchronize Resource States in Direct3D 12</c> section.
		/// </para>
		/// <para>
		/// All subresources in a resource must be in the RENDER_TARGET state, or DEPTH_WRITE state, for render targets/depth-stencil
		/// resources respectively, when <c>ID3D12GraphicsCommandList::DiscardResource</c> is called.
		/// </para>
		/// <para>
		/// When a back buffer is presented, it must be in the D3D12_RESOURCE_STATE_PRESENT state. If <c>IDXGISwapChain1::Present1</c> is
		/// called on a resource which is not in the PRESENT state, a debug layer warning will be emitted.
		/// </para>
		/// <para>The resource usage bits are group into two categories, read-only and read/write.</para>
		/// <para>The following usage bits are read-only:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_INDEX_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_COPY_SOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_DEPTH_READ</description>
		/// </item>
		/// </list>
		/// <para>The following usage bits are read/write:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_DEPTH_WRITE</description>
		/// </item>
		/// </list>
		/// <para>The following usage bits are write-only:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_COPY_DEST</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_RENDER_TARGET</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_STREAM_OUT</description>
		/// </item>
		/// </list>
		/// <para>
		/// At most one write bit can be set. If any write bit is set, then no read bit may be set. If no write bit is set, then any number
		/// of read bits may be set.
		/// </para>
		/// <para>
		/// At any given time, a subresource is in exactly one state (determined by a set of flags). The application must ensure that the
		/// states are matched when making a sequence of <b>ResourceBarrier</b> calls. In other words, the before and after states in
		/// consecutive calls to <b>ResourceBarrier</b> must agree.
		/// </para>
		/// <para>
		/// To transition all subresources within a resource, the application can set the subresource index to
		/// D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES, which implies that all subresources are changed.
		/// </para>
		/// <para>
		/// For improved performance, applications should use split barriers (refer to <c>Multi-engine synchronization</c>). Your
		/// application should also batch multiple transitions into a single call whenever possible.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>The runtime will validate that the barrier type values are valid members of the <c>D3D12_RESOURCE_BARRIER_TYPE</c> enumeration.</para>
		/// <para>In addition, the runtime checks the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The resource pointer is non-NULL.</description>
		/// </item>
		/// <item>
		/// <description>The subresource index is valid</description>
		/// </item>
		/// <item>
		/// <description>
		/// The before and after states are supported by the <c>D3D12_RESOURCE_BINDING_TIER</c> and <c>D3D12_RESOURCE_FLAGS</c> flags of the resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Reserved bits in the state masks are not set.</description>
		/// </item>
		/// <item>
		/// <description>The before and after states are different.</description>
		/// </item>
		/// <item>
		/// <description>The set of bits in the before and after states are valid.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If the D3D12_RESOURCE_STATE_RESOLVE_SOURCE bit is set, then the resource sample count must be greater than 1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If the D3D12_RESOURCE_STATE_RESOLVE_DEST bit is set, then the resource sample count must be equal to 1.</description>
		/// </item>
		/// </list>
		/// <para>For aliasing barriers the runtime will validate that, if either resource pointer is non-NULL, it refers to a tiled resource.</para>
		/// <para>
		/// For UAV barriers the runtime will validate that, if the resource is non-NULL, the resource has the
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS bind flag set.
		/// </para>
		/// <para>Validation failure causes <c>ID3D12GraphicsCommandList::Close</c> to return E_INVALIDARG.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer normally issues errors where runtime validation fails:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If a subresource transition in a command list is inconsistent with previous transitions in the same command list.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If a resource is used without first calling <b>ResourceBarrier</b> to put the resource into the correct state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If a resource is illegally bound for read and write at the same time.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If the <i>before</i> states passed to the <b>ResourceBarrier</b> do not match the <i>after</i> states of previous calls to
		/// <b>ResourceBarrier</b>, including the aliasing case.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Whereas the debug layer attempts to validate the runtime rules, it operates conservatively so that debug layer errors are real
		/// errors, and in some cases real errors may not produce debug layer errors.
		/// </para>
		/// <para>The debug layer will issue warnings in the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>All of the cases where the D3D12 debug layer would issues warnings for <c>ID3D12GraphicsCommandList::ResourceBarrier</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If a depth buffer is used in a non-read-only mode while the resource has the D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE usage
		/// bit set.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resourcebarrier void
		// ResourceBarrier( [in] UINT NumBarriers, [in] const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>Executes a bundle.</summary>
		/// <param name="pCommandList">
		/// <para>Type: <b><c>ID3D12GraphicsCommandList</c>*</b></para>
		/// <para>Specifies the <c>ID3D12GraphicsCommandList</c> that determines the bundle to be executed.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Bundles inherit all state from the parent command list on which <b>ExecuteBundle</b> is called, except the pipeline state object
		/// and primitive topology. All of the state that is set in a bundle will affect the state of the parent command list. Note that
		/// <b>ExecuteBundle</b> is not a predicated operation.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>
		/// The runtime will validate that the "callee" is a bundle and that the "caller" is a direct command list. The runtime will also
		/// validate that the bundle has been closed. If the contract is violated, the runtime will silently drop the call. Validation
		/// failure will result in <c>Close</c> returning E_INVALIDARG.
		/// </para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will issue a warning in the same cases where the runtime will fail. The debug layer will issue a warning if a
		/// predicate is set when <c>ExecuteCommandList</c> is called. Also, the debug layer will issue an error if it detects that any
		/// resource reference by the command list has been destroyed.
		/// </para>
		/// <para>
		/// The debug layer will also validate that the command allocator associated with the bundle has not been reset since <c>Close</c>
		/// was called on the command list. This validation occurs at <b>ExecuteBundle</b> time, and when the parent command list is
		/// executed on a command queue.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::ExecuteBundle</b> as follows:</para>
		/// <para>
		/// <c>void D3D12Bundles::PopulateCommandList(FrameResource* pFrameResource) { // Command list allocators can only be reset when the
		/// associated // command lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a
		/// particular command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_pCurrentFrameResource-&gt;m_commandAllocator.Get(), m_pipelineState1.Get())); // Set
		/// necessary state. m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = {
		/// m_cbvSrvHeap.Get(), m_samplerHeap.Get() }; m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// m_commandList-&gt;RSSetViewports(1, &amp;m_viewport); m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate
		/// that the back buffer will be used as a render target. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;ClearDepthStencilView(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0,
		/// nullptr); if (UseBundles) { // Execute the prebuilt bundle. m_commandList-&gt;ExecuteBundle(pFrameResource-&gt;m_bundle.Get());
		/// } else { // Populate a new command list. pFrameResource-&gt;PopulateCommandList(m_commandList.Get(), m_pipelineState1.Get(),
		/// m_pipelineState2.Get(), m_currentFrameResourceIndex, m_numIndices, &amp;m_indexBufferView, &amp;m_vertexBufferView,
		/// m_cbvSrvHeap.Get(), m_cbvSrvDescriptorSize, m_samplerHeap.Get(), m_rootSignature.Get()); } // Indicate that the back buffer will
		/// now be used to present. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_RENDER_TARGET,
		/// D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-executebundle void ExecuteBundle(
		// [in] ID3D12GraphicsCommandList *pCommandList );
		[PreserveSig]
		void ExecuteBundle([In] ID3D12GraphicsCommandList pCommandList);

		/// <summary>Changes the currently bound descriptor heaps that are associated with a command list.</summary>
		/// <param name="NumDescriptorHeaps">
		/// <para>Type: [in] <b><c>UINT</c></b></para>
		/// <para>Number of descriptor heaps to bind.</para>
		/// </param>
		/// <param name="ppDescriptorHeaps">
		/// <para>Type: [in] <b><c>ID3D12DescriptorHeap</c>*</b></para>
		/// <para>A pointer to an array of <c>ID3D12DescriptorHeap</c> objects for the heaps to set on the command list.</para>
		/// <para>You can only bind descriptor heaps of type <c><b>D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV</b></c> and <c><b>D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER</b></c>.</para>
		/// <para>
		/// Only one descriptor heap of each type can be set at one time, which means a maximum of 2 heaps (one sampler, one CBV/SRV/UAV)
		/// can be set at one time.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>SetDescriptorHeaps</b> can be called on a bundle, but the bundle descriptor heaps must match the calling command list
		/// descriptor heap. For more information on bundle restrictions, refer to <c>Creating and Recording Command Lists and Bundles</c>.
		/// </para>
		/// <para>All previously set heaps are unset by the call. At most one heap of each shader-visible type can be set in the call.</para>
		/// <para>
		/// Changing descriptor heaps can incur a pipeline flush on some hardware. Because of this, it is recommended to use a single
		/// shader-visible heap of each type, and set it once per frame, rather than regularly changing the bound descriptor heaps. Instead,
		/// use <c><b>ID3D12Device::CopyDescriptors</b></c> and <c><b>ID3D12Device::CopyDescriptorsSimple</b></c> to copy the required
		/// descriptors from shader-opaque heaps to the single shader-visible heap as required during rendering.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setdescriptorheaps void
		// SetDescriptorHeaps( UINT NumDescriptorHeaps, ID3D12DescriptorHeap * const *ppDescriptorHeaps );
		[PreserveSig]
		void SetDescriptorHeaps(int NumDescriptorHeaps, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12DescriptorHeap[] ppDescriptorHeaps);

		/// <summary>Sets the layout of the compute root signature.</summary>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12RootSignature</c> object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootsignature void
		// SetComputeRootSignature( [in, optional] ID3D12RootSignature *pRootSignature );
		[PreserveSig]
		void SetComputeRootSignature([In, Optional] ID3D12RootSignature? pRootSignature);

		/// <summary>Sets the layout of the graphics root signature.</summary>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12RootSignature</c> object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootsignature void
		// SetGraphicsRootSignature( [in, optional] ID3D12RootSignature *pRootSignature );
		[PreserveSig]
		void SetGraphicsRootSignature([In, Optional] ID3D12RootSignature? pRootSignature);

		/// <summary>Sets a descriptor table into the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BaseDescriptor">
		/// <para>Type: <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A GPU_descriptor_handle object for the base descriptor to set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootdescriptortable void
		// SetComputeRootDescriptorTable( [in] UINT RootParameterIndex, [in] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor );
		[PreserveSig]
		void SetComputeRootDescriptorTable(uint RootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor);

		/// <summary>Sets a descriptor table into the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BaseDescriptor">
		/// <para>Type: <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A GPU_descriptor_handle object for the base descriptor to set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootdescriptortable void
		// SetGraphicsRootDescriptorTable( [in] UINT RootParameterIndex, [in] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor );
		[PreserveSig]
		void SetGraphicsRootDescriptorTable(uint RootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor);

		/// <summary>Sets a constant in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="SrcData">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The source data for the constant to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The offset, in 32-bit values, to set the constant in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputeroot32bitconstant void
		// SetComputeRoot32BitConstant( [in] UINT RootParameterIndex, [in] UINT SrcData, [in] UINT DestOffsetIn32BitValues );
		[PreserveSig]
		void SetComputeRoot32BitConstant(uint RootParameterIndex, uint SrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a constant in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="SrcData">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The source data for the constant to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the constant in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsroot32bitconstant void
		// SetGraphicsRoot32BitConstant( [in] UINT RootParameterIndex, [in] UINT SrcData, [in] UINT DestOffsetIn32BitValues );
		[PreserveSig]
		void SetGraphicsRoot32BitConstant(uint RootParameterIndex, uint SrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a group of constants in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="Num32BitValuesToSet">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of constants to set in the root signature.</para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The source data for the group of constants to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the first constant of the group in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputeroot32bitconstants void
		// SetComputeRoot32BitConstants( [in] UINT RootParameterIndex, [in] UINT Num32BitValuesToSet, [in] const void *pSrcData, [in] UINT
		// DestOffsetIn32BitValues );
		[PreserveSig]
		void SetComputeRoot32BitConstants(uint RootParameterIndex, uint Num32BitValuesToSet,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pSrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a group of constants in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="Num32BitValuesToSet">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of constants to set in the root signature.</para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The source data for the group of constants to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the first constant of the group in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsroot32bitconstants void
		// SetGraphicsRoot32BitConstants( [in] UINT RootParameterIndex, [in] UINT Num32BitValuesToSet, [in] const void *pSrcData, [in] UINT
		// DestOffsetIn32BitValues );
		[PreserveSig]
		void SetGraphicsRoot32BitConstants(uint RootParameterIndex, uint Num32BitValuesToSet,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pSrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a CPU descriptor handle for the constant buffer in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>Specifies the D3D12_GPU_VIRTUAL_ADDRESS of the constant buffer.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootconstantbufferview
		// void SetComputeRootConstantBufferView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		void SetComputeRootConstantBufferView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the constant buffer in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the constant buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootconstantbufferview
		// void SetGraphicsRootConstantBufferView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		void SetGraphicsRootConstantBufferView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the shader resource in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootshaderresourceview
		// void SetComputeRootShaderResourceView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		void SetComputeRootShaderResourceView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the shader resource in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the Buffer. Textures are not supported. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootshaderresourceview
		// void SetGraphicsRootShaderResourceView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		void SetGraphicsRootShaderResourceView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the unordered-access-view resource in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootunorderedaccessview
		// void SetComputeRootUnorderedAccessView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		void SetComputeRootUnorderedAccessView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the unordered-access-view resource in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootunorderedaccessview
		// void SetGraphicsRootUnorderedAccessView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		void SetGraphicsRootUnorderedAccessView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets the view for the index buffer.</summary>
		/// <param name="pView">
		/// <para>Type: <b>const <c>D3D12_INDEX_BUFFER_VIEW</c>*</b></para>
		/// <para>
		/// The view specifies the index buffer's address, size, and <c>DXGI_FORMAT</c>, as a pointer to a <c>D3D12_INDEX_BUFFER_VIEW</c> structure.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Only one index buffer can be bound to the graphics pipeline at any one time. Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::IASetIndexBuffer</b> as follows:</para>
		/// <para>
		/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1,
		/// ID3D12PipelineState* pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc,
		/// D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize,
		/// ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root
		/// signature of the caller, then // bindings are inherited, otherwise the bind space is reset.
		/// pCommandList-&gt;SetGraphicsRootSignature(pRootSignature); ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap,
		/// pSamplerDescriptorHeap }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); //
		/// Calculate the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
		/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset,
		/// cbvSrvDescriptorSize); BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt;
		/// m_cityColumnCount; j++) { // Alternate which PSO to use; the pixel shader is different on // each just as a PSO setting
		/// demonstration. pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and
		/// move to the next descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle);
		/// cbvSrvHandle.Offset(cbvSrvDescriptorSize); pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetindexbuffer void
		// IASetIndexBuffer( [in, optional] const D3D12_INDEX_BUFFER_VIEW *pView );
		[PreserveSig]
		void IASetIndexBuffer([In, Optional] StructPointer<D3D12_INDEX_BUFFER_VIEW> pView);

		/// <summary>Sets a CPU descriptor handle for the vertex buffers.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index into the device's zero-based array to begin setting vertex buffers.</para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of views in the <i>pViews</i> array.</para>
		/// </param>
		/// <param name="pViews">
		/// <para>Type: <b>const <c>D3D12_VERTEX_BUFFER_VIEW</c>*</b></para>
		/// <para>Specifies the vertex buffer views in an array of <c>D3D12_VERTEX_BUFFER_VIEW</c> structures.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetvertexbuffers void
		// IASetVertexBuffers( [in] UINT StartSlot, [in] UINT NumViews, [in, optional] const D3D12_VERTEX_BUFFER_VIEW *pViews );
		[PreserveSig]
		void IASetVertexBuffers(uint StartSlot, int NumViews, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_VERTEX_BUFFER_VIEW[] pViews);

		/// <summary>Sets the stream output buffer views.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index into the device's zero-based array to begin setting stream output buffers.</para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of entries in the <i>pViews</i> array.</para>
		/// </param>
		/// <param name="pViews">
		/// <para>Type: <b>const <c>D3D12_STREAM_OUTPUT_BUFFER_VIEW</c>*</b></para>
		/// <para>Specifies an array of <c>D3D12_STREAM_OUTPUT_BUFFER_VIEW</c> structures.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-sosettargets void SOSetTargets( [in]
		// UINT StartSlot, [in] UINT NumViews, [in, optional] const D3D12_STREAM_OUTPUT_BUFFER_VIEW *pViews );
		[PreserveSig]
		void SOSetTargets(uint StartSlot, int NumViews, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_STREAM_OUTPUT_BUFFER_VIEW[] pViews);

		/// <summary>Sets CPU descriptor handles for the render targets and depth stencil.</summary>
		/// <param name="NumRenderTargetDescriptors">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of entries in the <i>pRenderTargetDescriptors</i> array (ranges between 0 and
		/// <b>D3D12_SIMULTANEOUS_RENDER_TARGET_COUNT</b>). If this parameter is nonzero, the number of entries in the array to which
		/// pRenderTargetDescriptors points must equal the number in this parameter.
		/// </para>
		/// </param>
		/// <param name="pRenderTargetDescriptors">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>
		/// Specifies an array of <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structures that describe the CPU descriptor handles that represents the
		/// start of the heap of render target descriptors. If this parameter is NULL and NumRenderTargetDescriptors is 0, no render targets
		/// are bound.
		/// </para>
		/// </param>
		/// <param name="RTsSingleHandleToDescriptorRange">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// <b>True</b> means the handle passed in is the pointer to a contiguous range of <i>NumRenderTargetDescriptors</i> descriptors.
		/// This case is useful if the set of descriptors to bind already happens to be contiguous in memory (so all that�s needed is a
		/// handle to the first one). For example, if <i>NumRenderTargetDescriptors</i> is 3 then the memory layout is taken as follows:
		/// </para>
		/// <para>In this case the driver dereferences the handle and then increments the memory being pointed to.</para>
		/// <para>
		/// <b>False</b> means that the handle is the first of an array of <i>NumRenderTargetDescriptors</i> handles. The false case allows
		/// an application to bind a set of descriptors from different locations at once. Again assuming that
		/// <i>NumRenderTargetDescriptors</i> is 3, the memory layout is taken as follows:
		/// </para>
		/// <para>In this case the driver dereferences three handles that are expected to be adjacent to each other in memory.</para>
		/// </param>
		/// <param name="pDepthStencilDescriptor">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>
		/// A pointer to a <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structure that describes the CPU descriptor handle that represents the start
		/// of the heap that holds the depth stencil descriptor. If this parameter is NULL, no depth stencil descriptor is bound.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetrendertargets void
		// OMSetRenderTargets( [in] UINT NumRenderTargetDescriptors, [in, optional] const D3D12_CPU_DESCRIPTOR_HANDLE
		// *pRenderTargetDescriptors, [in] BOOL RTsSingleHandleToDescriptorRange, [in, optional] const D3D12_CPU_DESCRIPTOR_HANDLE
		// *pDepthStencilDescriptor );
		[PreserveSig]
		void OMSetRenderTargets(uint NumRenderTargetDescriptors,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_CPU_DESCRIPTOR_HANDLE[]? pRenderTargetDescriptors,
			bool RTsSingleHandleToDescriptorRange, [In, Optional] StructPointer<D3D12_CPU_DESCRIPTOR_HANDLE> pDepthStencilDescriptor);

		/// <summary>Clears the depth-stencil resource.</summary>
		/// <param name="DepthStencilView">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap for the depth stencil to be cleared.</para>
		/// </param>
		/// <param name="ClearFlags">
		/// <para>Type: <b><c>D3D12_CLEAR_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_CLEAR_FLAGS</c> values that are combined by using a bitwise OR operation. The resulting value
		/// identifies the type of data to clear (depth buffer, stencil buffer, or both).
		/// </para>
		/// </param>
		/// <param name="Depth">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>A value to clear the depth buffer with. This value will be clamped between 0 and 1.</para>
		/// </param>
		/// <param name="Stencil">
		/// <para>Type: <b>UINT8</b></para>
		/// <para>A value to clear the stencil buffer with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of rectangles in the array that the <i>pRects</i> parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const <b>D3D12_RECT</b>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearDepthStencilView</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Only direct and bundle command lists support this operation.</para>
		/// <para>
		/// <b>ClearDepthStencilView</b> may be used to initialize resources which alias the same heap memory. See
		/// <c>CreatePlacedResource</c> for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).</para>
		/// <para>Validation failure will result in the call to <c>Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer will issue errors if the input colors are denormalized.</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state. For
		/// <b>ClearDepthStencilView</b>, the state must be in the state <c>D3D12_RESOURCE_STATE_DEPTH_WRITE</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-cleardepthstencilview void
		// ClearDepthStencilView( [in] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, [in] D3D12_CLEAR_FLAGS ClearFlags, [in] FLOAT Depth,
		// [in] UINT8 Stencil, [in] UINT NumRects, [in] const D3D12_RECT *pRects );
		[PreserveSig]
		void ClearDepthStencilView([In] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, D3D12_CLEAR_FLAGS ClearFlags, float Depth, byte Stencil,
			[Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[]? pRects);

		/// <summary>Sets all the elements in a render target to one value.</summary>
		/// <param name="RenderTargetView">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// Specifies a D3D12_CPU_DESCRIPTOR_HANDLE structure that describes the CPU descriptor handle that represents the start of the heap
		/// for the render target to be cleared.
		/// </para>
		/// </param>
		/// <param name="ColorRGBA">
		/// <para>Type: <b>const FLOAT[4]</b></para>
		/// <para>A 4-component array that represents the color to fill the render target with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the <i>pRects</i> parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const D3D12_RECT*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearRenderTargetView</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>ClearRenderTargetView</b> may be used to initialize resources which alias the same heap memory. See
		/// <c>CreatePlacedResource</c> for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).</para>
		/// <para>Validation failure will result in the call to <c>Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer will issue errors if the input colors are denormalized.</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state. For
		/// <b>ClearRenderTargetView</b>, the state must be <c>D3D12_RESOURCE_STATE_RENDER_TARGET</c>.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::ClearRenderTargetView</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>The <c>D3D12Multithreading</c> sample uses <b>ID3D12GraphicsCommandList::ClearRenderTargetView</b> as follows:</para>
		/// <para><c>// Frame resources. FrameResource* m_frameResources[FrameCount]; FrameResource* m_pCurrentFrameResource; int m_currentFrameResourceIndex;</c></para>
		/// <para>
		/// <c>// Assemble the CommandListPre command list. void D3D12Multithreading::BeginFrame() { m_pCurrentFrameResource-&gt;Init(); //
		/// Indicate that the back buffer will be used as a render target.
		/// m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); // Clear the render target and depth stencil. const float clearColor[] = { 0.0f, 0.0f,
		/// 0.0f, 1.0f }; CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex,
		/// m_rtvDescriptorSize); m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ClearRenderTargetView(rtvHandle,
		/// clearColor, 0, nullptr);
		/// m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ClearDepthStencilView(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart(),
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr);
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;Close()); } // Assemble the CommandListMid command
		/// list. void D3D12Multithreading::MidFrame() { // Transition our shadow map from the shadow pass to readable in the scene pass.
		/// m_pCurrentFrameResource-&gt;SwapBarriers();
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandLists[CommandListMid]-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearrendertargetview void
		// ClearRenderTargetView( [in] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView, [in] const FLOAT [4] ColorRGBA, [in] UINT NumRects,
		// [in] const D3D12_RECT *pRects );
		[PreserveSig]
		void ClearRenderTargetView([In] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] ColorRGBA,
			[Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[]? pRects);

		/// <summary>
		/// <para>Sets all the elements in a unordered-access view (UAV) to the specified integer values.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <b>Dispatch</b> calls.
		/// To ensure ordering, barrier calls must be issued before and/or after the <b>ClearUnorderedAccessViewXxx</b> call as needed. It
		/// might appear on some drivers that such barriers aren't necessary. But implicit barriers are not a spec guarantee; so they can't
		/// be relied upon. This is in contrast to <b>ClearDepthStencilView</b> and <b>ClearRenderTargetView</b> which (like <b>DrawXxx</b>
		/// commands), respect command list ordering.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="ViewGPUHandleInCurrentHeap">
		/// <para>Type: [in] <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_GPU_DESCRIPTOR_HANDLE</c> that references an initialized descriptor for the unordered-access view (UAV) that is to be
		/// cleared. This descriptor must be in a shader-visible descriptor heap, which must be set on the command list via <c>SetDescriptorHeaps</c>.
		/// </para>
		/// </param>
		/// <param name="ViewCPUHandle">
		/// <para>Type: [in] <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> in a non-shader visible descriptor heap that references an initialized descriptor for the
		/// unordered-access view (UAV) that is to be cleared.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This descriptor must not be in a shader-visible descriptor heap. This is to allow drivers that implement the clear as a
		/// fixed-function hardware operation (rather than as a dispatch) to efficiently read from the descriptor, as shader-visible heaps
		/// may be created in <b>WRITE_BACK</b> memory (similar to <b>D3D12_HEAP_TYPE_UPLOAD</b> heap types), and CPU reads from this type
		/// of memory are prohibitively slow.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the unordered-access-view (UAV) resource to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: [in] <b>const UINT[4]</b></para>
		/// <para>A 4-component array that containing the values to fill the unordered-access-view resource with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the pRects parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: [in] <b>const <c>D3D12_RECT</c>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearUnorderedAccessViewUint</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Runtime validation</para>
		/// <para>Validation failure results in the call to <c>ID3D12GraphicsCommandList::Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues errors if the input values are outside of a normalized range.</para>
		/// <para>
		/// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state. For
		/// <b>ClearUnorderedAccessViewUint</b>, the state must be <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearunorderedaccessviewuint void
		// ClearUnorderedAccessViewUint( D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
		// ID3D12Resource *pResource, const UINT [4] Values, UINT NumRects, const D3D12_RECT *pRects );
		[PreserveSig]
		void ClearUnorderedAccessViewUint([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
			[In] ID3D12Resource pResource, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] Values, int NumRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[] pRects);

		/// <summary>
		/// <para>Sets all of the elements in an unordered-access view (UAV) to the specified float values.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <b>Dispatch</b> calls.
		/// To ensure ordering, barrier calls must be issued before and/or after the <b>ClearUnorderedAccessViewXxx</b> call as needed. It
		/// might appear on some drivers that such barriers aren't necessary. But implicit barriers are not a spec guarantee; so they can't
		/// be relied upon. This is in contrast to <b>ClearDepthStencilView</b> and <b>ClearRenderTargetView</b> which (like <b>DrawXxx</b>
		/// commands), respect command list ordering.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="ViewGPUHandleInCurrentHeap">
		/// <para>Type: [in] <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_GPU_DESCRIPTOR_HANDLE</c> that references an initialized descriptor for the unordered-access view (UAV) that is to be
		/// cleared. This descriptor must be in a shader-visible descriptor heap, which must be set on the command list via <c>SetDescriptorHeaps</c>.
		/// </para>
		/// </param>
		/// <param name="ViewCPUHandle">
		/// <para>Type: [in] <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> in a non-shader visible descriptor heap that references an initialized descriptor for the
		/// unordered-access view (UAV) that is to be cleared.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This descriptor must not be in a shader-visible descriptor heap. This is to allow drivers that implement the clear as a
		/// fixed-function hardware operation (rather than as a dispatch) to efficiently read from the descriptor, as shader-visible heaps
		/// may be created in <b>WRITE_BACK</b> memory (similar to <b>D3D12_HEAP_TYPE_UPLOAD</b> heap types), and CPU reads from this type
		/// of memory are prohibitively slow.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the unordered-access-view (UAV) resource to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: [in] <b>const FLOAT[4]</b></para>
		/// <para>A 4-component array that containing the values to fill the unordered-access-view resource with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the pRects parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: [in] <b>const <c>D3D12_RECT</c>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearUnorderedAccessViewFloat</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Runtime validation</para>
		/// <para>For floating-point inputs, the runtime sets denormalized values to 0 (while preserving NANs).</para>
		/// <para>If you want to clear the UAV to a specific bit pattern, consider using <c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewUint</c>.</para>
		/// <para>Validation failure results in the call to <c>ID3D12GraphicsCommandList::Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues errors if the input values are outside of a normalized range.</para>
		/// <para>
		/// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state. For
		/// <b>ClearUnorderedAccessViewFloat</b>, the state must be <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearunorderedaccessviewfloat void
		// ClearUnorderedAccessViewFloat( D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
		// ID3D12Resource *pResource, const FLOAT [4] Values, UINT NumRects, const D3D12_RECT *pRects );
		[PreserveSig]
		void ClearUnorderedAccessViewFloat([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
			[In] ID3D12Resource pResource, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] Values, int NumRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[] pRects);

		/// <summary>
		/// Indicates that the contents of a resource don't need to be preserved. The function may re-initialize resource metadata in some cases.
		/// </summary>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</para>
		/// </param>
		/// <param name="pRegion">
		/// <para>Type: [in, optional] <b>const <c>D3D12_DISCARD_REGION</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The semantics of <b>DiscardResource</b> change based on the command list type.</para>
		/// <para>For <c>D3D12_COMMAND_LIST_TYPE_DIRECT</c>, the following two rules apply:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// When a resource has the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> flag, <b>DiscardResource</b> must be called when the
		/// discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_RENDER_TARGET</c> resource barrier state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When a resource has the <c>D3D12_RESOURCE_FLAG _ALLOW_DEPTH_STENCIL</c> flag, <b>DiscardResource</b> must be called when the
		/// discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_DEPTH_WRITE</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>For <c>D3D12_COMMAND_LIST_TYPE_COMPUTE</c>, the following rule applies:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The resource must have the <c>D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS</c> flag, and <b>DiscardResource</b> must be called
		/// when the discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c> resource barrier state.
		/// </description>
		/// </item>
		/// </list>
		/// <para><b>DiscardResource</b> is not supported on command lists with either <c>D3D12_COMMAND_LIST_TYPE_BUNDLE</c> nor <b>D3D12_COMMAND_LIST_TYPE_COPY</b>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the query.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="Index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the query within the query heap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>See <c>Queries</c> for more information about D3D12 queries. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::BeginQuery</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-beginquery void BeginQuery( [in]
		// ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT Index );
		[PreserveSig]
		void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a running query.</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the query.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="Index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the query in the query heap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>See <c>Queries</c> for more information about D3D12 queries. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::EndQuery</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-endquery void EndQuery( [in]
		// ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT Index );
		[PreserveSig]
		void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query. <b>ResolveQueryData</b> works with all heap types (default, upload, and readback).</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the queries to resolve.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies the type of query, one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="StartIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies an index of the first query to resolve.</para>
		/// </param>
		/// <param name="NumQueries">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of queries to resolve.</para>
		/// </param>
		/// <param name="pDestinationBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies an <c>ID3D12Resource</c> destination buffer, which must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.</para>
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies an alignment offset into the destination buffer. Must be a multiple of 8 bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>ResolveQueryData</b> performs a batched operation that writes query data into a destination buffer. Query data is written
		/// contiguously to the destination buffer, and the parameter.
		/// </para>
		/// <para>
		/// <b>ResolveQueryData</b> turns application-opaque query data in an application-opaque query heap into adapter-agnostic values
		/// usable by your application. Resolving queries within a heap that have not been completed (so have had
		/// <c><b>ID3D12GraphicsCommandList::BeginQuery</b></c> called for them, but not <c><b>ID3D12GraphicsCommandList::EndQuery</b></c>),
		/// or that have been uninitialized, results in undefined behavior and might cause device hangs or removal. The debug layer will
		/// emit an error if it detects an application has resolved incomplete or uninitialized queries.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Resolving incomplete or uninitialized queries is undefined behavior because the driver might internally store GPUVAs or other
		/// data within unresolved queries. And so attempting to resolve these queries on uninitialized data could cause a page fault or
		/// device hang. Older versions of the debug layer didn't validate this behavior.
		/// </para>
		/// </para>
		/// <para>
		/// Binary occlusion queries write 64-bits per query. The least significant bit is either 0 (the object was entirely occluded) or 1
		/// (at least 1 sample of the object would have been drawn). The rest of the bits are 0. Occlusion queries write 64-bits per query.
		/// The value is the number of samples that passed testing. Timestamp queries write 64-bits per query, which is a tick value that
		/// must be compared to the respective command queue frequency (see <c>Timing</c>).
		/// </para>
		/// <para>
		/// Pipeline statistics queries write a <c><b>D3D12_QUERY_DATA_PIPELINE_STATISTICS</b></c> structure per query. All stream-out
		/// statistics queries write a <c><b>D3D12_QUERY_DATA_SO_STATISTICS</b></c> structure per query.
		/// </para>
		/// <para>The core runtime will validate the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><i>StartIndex</i> and <i>NumQueries</i> are within range.</description>
		/// </item>
		/// <item>
		/// <description><i>AlignedDestinationBufferOffset</i> is a multiple of 8 bytes.</description>
		/// </item>
		/// <item>
		/// <description><i>DestinationBuffer</i> is a buffer.</description>
		/// </item>
		/// <item>
		/// <description>The written data will not overflow the output buffer.</description>
		/// </item>
		/// <item>
		/// <description>The query type must be supported by the command list type.</description>
		/// </item>
		/// <item>
		/// <description>The query type must be supported by the query heap.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The debug layer will issue a warning if the destination buffer is not in the D3D12_RESOURCE_STATE_COPY_DEST state, or if any
		/// queries being resolved have not had <c><b>ID3D12GraphicsCommandList::EndQuery</b></c> called on them.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resolvequerydata void
		// ResolveQueryData( [in] ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT StartIndex, [in] UINT NumQueries, [in]
		// ID3D12Resource *pDestinationBuffer, [in] UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Sets a rendering predicate.</summary>
		/// <param name="pBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>
		/// The buffer, as an <c>ID3D12Resource</c>, which must be in the <c><b>D3D12_RESOURCE_STATE_PREDICATION</b></c> or
		/// <c><b>D3D21_RESOURCE_STATE_INDIRECT_ARGUMENT</b></c> state (both values are identical, and provided as aliases for clarity), or
		/// <b>NULL</b> to disable predication.
		/// </para>
		/// </param>
		/// <param name="AlignedBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The aligned buffer offset, as a UINT64.</para>
		/// </param>
		/// <param name="Operation">
		/// <para>Type: <b><c>D3D12_PREDICATION_OP</c></b></para>
		/// <para>Specifies a <c>D3D12_PREDICATION_OP</c>, such as D3D12_PREDICATION_OP_EQUAL_ZERO or D3D12_PREDICATION_OP_NOT_EQUAL_ZERO.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed if the
		/// resulting predicate data of the predicate is equal to the operation specified.
		/// </para>
		/// <para>
		/// Unlike Direct3D 11, in Direct3D 12 predication state is not inherited by direct command lists, and predication is always
		/// respected (there are no predication hints). All direct command lists begin with predication disabled. Bundles do inherit
		/// predication state. It is legal for the same predicate to be bound multiple times.
		/// </para>
		/// <para>
		/// Illegal API calls will result in <c>Close</c> returning an error, or <c>ID3D12CommandQueue::ExecuteCommandLists</c> dropping the
		/// command list and removing the device.
		/// </para>
		/// <para>The debug layer will issue errors whenever the runtime validation fails.</para>
		/// <para>Refer to <c>Predication</c> for more information. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::SetPredication</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setpredication void SetPredication(
		// [in, optional] ID3D12Resource *pBuffer, [in] UINT64 AlignedBufferOffset, [in] D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <param name="Metadata">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="Size">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To insert instrumentation markers at the current location within a D3D12 command list, use the <b>PIXSetMarker</b> function.�
		/// This is provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setmarker void SetMarker( UINT
		// Metadata, [in, optional] const void *pData, UINT Size );
		[PreserveSig]
		void SetMarker(uint Metadata, [In, Optional] IntPtr pData, uint Size);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <param name="Metadata">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="Size">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To mark the start of an instrumentation region at the current location within a D3D12 command list, use the <b>PIXBeginEvent</b>
		/// function or <b>PIXScopedEvent</b> macro.� These are provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-beginevent void BeginEvent( UINT
		// Metadata, [in, optional] const void *pData, UINT Size );
		[PreserveSig]
		void BeginEvent(uint Metadata, [In, Optional] IntPtr pData, uint Size);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To mark the end of an instrumentation region at the current location within a D3D12 command list, use the <b>PIXEndEvent</b>
		/// function or <b>PIXScopedEvent</b> macro.� These are provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-endevent void EndEvent();
		[PreserveSig]
		void EndEvent();

		/// <summary>Apps perform indirect draws/dispatches using the <b>ExecuteIndirect</b> method.</summary>
		/// <param name="pCommandSignature">
		/// <para>Type: <b><c>ID3D12CommandSignature</c>*</b></para>
		/// <para>
		/// Specifies a <c>ID3D12CommandSignature</c>. The data referenced by <i>pArgumentBuffer</i> will be interpreted depending on the
		/// contents of the command signature. Refer to <c>Indirect Drawing</c> for the APIs that are used to create a command signature.
		/// </para>
		/// </param>
		/// <param name="MaxCommandCount">
		/// <para>Type: <b>UINT</b></para>
		/// <para>There are two ways that command counts can be specified:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If <i>pCountBuffer</i> is not NULL, then <i>MaxCommandCount</i> specifies the maximum number of operations which will be
		/// performed. The actual number of operations to be performed are defined by the minimum of this value, and a 32-bit unsigned
		/// integer contained in <i>pCountBuffer</i> (at the byte offset specified by <i>CountBufferOffset</i>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If <i>pCountBuffer</i> is NULL, the <i>MaxCommandCount</i> specifies the exact number of operations which will be performed.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pArgumentBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies one or more <c>ID3D12Resource</c> objects, containing the command arguments.</para>
		/// </param>
		/// <param name="ArgumentBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies an offset into <i>pArgumentBuffer</i> to identify the first command argument.</para>
		/// </param>
		/// <param name="pCountBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies a pointer to a <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="CountBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 that is the offset into <i>pCountBuffer</i>, identifying the argument count.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The semantics of this API are defined with the following pseudo-code:</para>
		/// <para>Non-NULL pCountBuffer:</para>
		/// <para>
		/// <c>// Read draw count out of count buffer UINT CommandCount = pCountBuffer-&gt;ReadUINT32(CountBufferOffset); CommandCount =
		/// min(CommandCount, MaxCommandCount) // Get pointer to first Commanding argument BYTE* Arguments = pArgumentBuffer-&gt;GetBase() +
		/// ArgumentBufferOffset; for(UINT CommandIndex = 0; CommandIndex &lt; CommandCount; CommandIndex++) { // Interpret the data
		/// contained in *Arguments // according to the command signature pCommandSignature-&gt;Interpret(Arguments); Arguments +=
		/// pCommandSignature-&gt;GetByteStride(); }</c>
		/// </para>
		/// <para>NULL pCountBuffer:</para>
		/// <para>
		/// <c>// Get pointer to first Commanding argument BYTE* Arguments = pArgumentBuffer-&gt;GetBase() + ArgumentBufferOffset; for(UINT
		/// CommandIndex = 0; CommandIndex &lt; MaxCommandCount; CommandIndex++) { // Interpret the data contained in *Arguments //
		/// according to the command signature pCommandSignature-&gt;Interpret(Arguments); Arguments +=
		/// pCommandSignature-&gt;GetByteStride(); }</c>
		/// </para>
		/// <para>
		/// The debug layer will issue an error if either the count buffer or the argument buffer are not in the
		/// D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT state. The core runtime will validate:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><i>CountBufferOffset</i> and <i>ArgumentBufferOffset</i> are 4-byte aligned</description>
		/// </item>
		/// <item>
		/// <description><i>pCountBuffer</i> and <i>pArgumentBuffer</i> are buffer resources (any heap type)</description>
		/// </item>
		/// <item>
		/// <description>
		/// The offset implied by <i>MaxCommandCount</i>, <i>ArgumentBufferOffset</i>, and the drawing program stride do not exceed the
		/// bounds of <i>pArgumentBuffer</i> (similarly for count buffer)
		/// </description>
		/// </item>
		/// <item>
		/// <description>The command list is a direct command list or a compute command list (not a copy or JPEG decode command list)</description>
		/// </item>
		/// <item>
		/// <description>The root signature of the command list matches the root signature of the command signature</description>
		/// </item>
		/// </list>
		/// <para>
		/// The functionality of two APIs from earlier versions of Direct3D, <c>DrawInstancedIndirect</c> and
		/// <c>DrawIndexedInstancedIndirect</c>, are encompassed by <b>ExecuteIndirect</b>.
		/// </para>
		/// <para><c></c><c></c><c></c> Bundles</para>
		/// <para>
		/// <b>ID3D12GraphicsCommandList::ExecuteIndirect</b> is allowed inside of bundle command lists only if all of the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>CountBuffer is NULL (CPU-specified count only).</description>
		/// </item>
		/// <item>
		/// <description>
		/// The command signature contains exactly one operation. This implies that the command signature does not contain root arguments
		/// changes, nor contain VB/IB binding changes.
		/// </description>
		/// </item>
		/// </list>
		/// <para><c></c><c></c><c></c> Obtaining buffer virtual addresses</para>
		/// <para>The <c>ID3D12Resource::GetGPUVirtualAddress</c> method enables an app to retrieve the GPU virtual address of a buffer.</para>
		/// <para>
		/// Apps are free to apply byte offsets to virtual addresses before placing them in an indirect argument buffer. Note that all of
		/// the D3D12 alignment requirements for VB/IB/CB still apply to the resulting GPU virtual address.
		///  Examples The <c>D3D12ExecuteIndirect</c> sample uses <b>ID3D12GraphicsCommandList::ExecuteIndirect</b> as follows:</para>
		/// <para>
		/// <c>// Data structure to match the command signature used for ExecuteIndirect. struct IndirectCommand { D3D12_GPU_VIRTUAL_ADDRESS
		/// cbv; D3D12_DRAW_ARGUMENTS drawArguments; };</c>
		/// </para>
		/// <para>
		/// The call to <b>ExecuteIndirect</b> is near the end of this listing, below the comment "Draw the triangles that have not been culled."
		/// </para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void D3D12ExecuteIndirect::PopulateCommandLists()
		/// { // Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps
		/// should use // fences to determine GPU execution progress. ThrowIfFailed(m_computeCommandAllocators[m_frameIndex]-&gt;Reset());
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_computeCommandList-&gt;Reset(m_computeCommandAllocators[m_frameIndex].Get(), m_computeState.Get()));
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Record the compute
		/// commands that will cull triangles and prevent them from being processed by the vertex shader. if (m_enableCulling) { UINT
		/// frameDescriptorOffset = m_frameIndex * CbvSrvUavDescriptorCountPerFrame; D3D12_GPU_DESCRIPTOR_HANDLE cbvSrvUavHandle =
		/// m_cbvSrvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart();
		/// m_computeCommandList-&gt;SetComputeRootSignature(m_computeRootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = {
		/// m_cbvSrvUavHeap.Get() }; m_computeCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// m_computeCommandList-&gt;SetComputeRootDescriptorTable( SrvUavTable, CD3DX12_GPU_DESCRIPTOR_HANDLE(cbvSrvUavHandle, CbvSrvOffset
		/// + frameDescriptorOffset, m_cbvSrvUavDescriptorSize)); m_computeCommandList-&gt;SetComputeRoot32BitConstants(RootConstants, 4,
		/// reinterpret_cast&lt;void*&gt;(&amp;m_csRootConstants), 0); // Reset the UAV counter for this frame.
		/// m_computeCommandList-&gt;CopyBufferRegion(m_processedCommandBuffers[m_frameIndex].Get(), CommandBufferSizePerFrame,
		/// m_processedCommandBufferCounterReset.Get(), 0, sizeof(UINT)); D3D12_RESOURCE_BARRIER barrier =
		/// CD3DX12_RESOURCE_BARRIER::Transition(m_processedCommandBuffers[m_frameIndex].Get(), D3D12_RESOURCE_STATE_COPY_DEST,
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS); m_computeCommandList-&gt;ResourceBarrier(1, &amp;barrier);
		/// m_computeCommandList-&gt;Dispatch(static_cast&lt;UINT&gt;(ceil(TriangleCount / float(ComputeThreadBlockSize))), 1, 1); }
		/// ThrowIfFailed(m_computeCommandList-&gt;Close()); // Record the rendering commands. { // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvSrvUavHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, m_enableCulling ? &amp;m_cullingScissorRect : &amp;m_scissorRect); // Indicate that the
		/// command buffer will be used for indirect drawing // and that the back buffer will be used as a render target.
		/// D3D12_RESOURCE_BARRIER barriers[2] = { CD3DX12_RESOURCE_BARRIER::Transition( m_enableCulling ?
		/// m_processedCommandBuffers[m_frameIndex].Get() : m_commandBuffer.Get(), m_enableCulling ? D3D12_RESOURCE_STATE_UNORDERED_ACCESS :
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE, D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT), CD3DX12_RESOURCE_BARRIER::Transition(
		/// m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET) };
		/// m_commandList-&gt;ResourceBarrier(_countof(barriers), barriers); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP);
		/// m_commandList-&gt;IASetVertexBuffers(0, 1, &amp;m_vertexBufferView); if (m_enableCulling) { // Draw the triangles that have not
		/// been culled. m_commandList-&gt;ExecuteIndirect( m_commandSignature.Get(), TriangleCount,
		/// m_processedCommandBuffers[m_frameIndex].Get(), 0, m_processedCommandBuffers[m_frameIndex].Get(), CommandBufferSizePerFrame); }
		/// else { // Draw all of the triangles. m_commandList-&gt;ExecuteIndirect( m_commandSignature.Get(), TriangleCount,
		/// m_commandBuffer.Get(), CommandBufferSizePerFrame * m_frameIndex, nullptr, 0); } // Indicate that the command buffer may be used
		/// by the compute shader // and that the back buffer will now be used to present. barriers[0].Transition.StateBefore =
		/// D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT; barriers[0].Transition.StateAfter = m_enableCulling ? D3D12_RESOURCE_STATE_COPY_DEST :
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE; barriers[1].Transition.StateBefore = D3D12_RESOURCE_STATE_RENDER_TARGET;
		/// barriers[1].Transition.StateAfter = D3D12_RESOURCE_STATE_PRESENT; m_commandList-&gt;ResourceBarrier(_countof(barriers),
		/// barriers); ThrowIfFailed(m_commandList-&gt;Close()); } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-executeindirect void
		// ExecuteIndirect( [in] ID3D12CommandSignature *pCommandSignature, [in] UINT MaxCommandCount, [in] ID3D12Resource *pArgumentBuffer,
		// [in] UINT64 ArgumentBufferOffset, [in, optional] ID3D12Resource *pCountBuffer, [in] UINT64 CountBufferOffset );
		[PreserveSig]
		void ExecuteIndirect([In] ID3D12CommandSignature pCommandSignature, uint MaxCommandCount, [In] ID3D12Resource pArgumentBuffer,
			ulong ArgumentBufferOffset, [In, Optional] ID3D12Resource? pCountBuffer, ulong CountBufferOffset);
	}

	/// <summary>Sets the view for the index buffer.</summary>
	/// <param name="cmdl">The <see cref="ID3D12GraphicsCommandList"/> instance.</param>
	/// <param name="pView">
	/// <para>
	/// The view specifies the index buffer's address, size, and <c>DXGI_FORMAT</c>, as a pointer to a <c>D3D12_INDEX_BUFFER_VIEW</c> structure.
	/// </para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Only one index buffer can be bound to the graphics pipeline at any one time. Examples The <c>D3D12Bundles</c> sample uses
	/// <b>ID3D12GraphicsCommandList::IASetIndexBuffer</b> as follows:
	/// </para>
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
	/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetindexbuffer void
	public static void IASetIndexBuffer(this ID3D12GraphicsCommandList cmdl, D3D12_INDEX_BUFFER_VIEW? pView = null) =>
		cmdl.IASetIndexBuffer(new(pView, out var _));

	/// <summary>Sets CPU descriptor handles for the render targets and depth stencil.</summary>
	/// <param name="cmdl">The <see cref="ID3D12GraphicsCommandList"/> instance.</param>
	/// <param name="pRenderTargetDescriptors">
	/// Specifies an array of <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structures that describe the CPU descriptor handles that represents the
	/// start of the heap of render target descriptors. If this parameter is NULL and NumRenderTargetDescriptors is 0, no render targets are bound.
	/// </param>
	/// <param name="RTsSingleHandleToDescriptorRange">
	/// <para>
	/// <b>True</b> means the handle passed in is the pointer to a contiguous range of <i>NumRenderTargetDescriptors</i> descriptors. This
	/// case is useful if the set of descriptors to bind already happens to be contiguous in memory (so all that�s needed is a handle to the
	/// first one). For example, if <i>NumRenderTargetDescriptors</i> is 3 then the memory layout is taken as follows:
	/// </para>
	/// <para>In this case the driver dereferences the handle and then increments the memory being pointed to.</para>
	/// <para>
	/// <b>False</b> means that the handle is the first of an array of <i>NumRenderTargetDescriptors</i> handles. The false case allows an
	/// application to bind a set of descriptors from different locations at once. Again assuming that <i>NumRenderTargetDescriptors</i> is
	/// 3, the memory layout is taken as follows:
	/// </para>
	/// <para>In this case the driver dereferences three handles that are expected to be adjacent to each other in memory.</para>
	/// </param>
	/// <param name="pDepthStencilDescriptor">
	/// A pointer to a <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structure that describes the CPU descriptor handle that represents the start of
	/// the heap that holds the depth stencil descriptor. If this parameter is NULL, no depth stencil descriptor is bound.
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetrendertargets void
	public static void OMSetRenderTargets(this ID3D12GraphicsCommandList cmdl, D3D12_CPU_DESCRIPTOR_HANDLE[]? pRenderTargetDescriptors,
		bool RTsSingleHandleToDescriptorRange, D3D12_CPU_DESCRIPTOR_HANDLE? pDepthStencilDescriptor = null) =>
		cmdl.OMSetRenderTargets((uint?)pRenderTargetDescriptors?.Length ?? 0U, pRenderTargetDescriptors, RTsSingleHandleToDescriptorRange,
			new(pDepthStencilDescriptor, out var _));

	/// <summary>
	/// <para>
	/// Encapsulates a list of graphics commands for rendering, extending the interface to support programmable sample positions, atomic
	/// copies for implementing late-latch techniques, and optional depth-bounds testing.
	/// </para>
	/// <note>This interface, introduced in the Windows 10 Creators Update, is the latest version of the <c>ID3D12GraphicsCommandList</c>
	/// interface. Applications targetting Windows 10 Creators Update should use this interface instead of <b>ID3D12GraphicsCommandList</b>.</note>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12graphicscommandlist1
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12GraphicsCommandList1")]
	[ComImport, Guid("553103fb-1fe7-4557-bb38-946d7d0e7ca7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12GraphicsCommandList1 : ID3D12GraphicsCommandList
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
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::Close</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::LoadAssets() { // Create an empty root signature. { CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc;
		/// rootSignatureDesc.Init(0, nullptr, 0, nullptr, D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT);
		/// ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
		/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
		/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(),
		/// IID_PPV_ARGS(&amp;m_rootSignature))); } // Create the pipeline state, which includes compiling and loading shaders. {
		/// ComPtr&lt;ID3DBlob&gt; vertexShader; ComPtr&lt;ID3DBlob&gt; pixelShader; #if defined(_DEBUG) // Enable better shader debugging
		/// with the graphics debugging tools. UINT compileFlags = D3DCOMPILE_DEBUG | D3DCOMPILE_SKIP_OPTIMIZATION; #else UINT compileFlags
		/// = 0; #endif ThrowIfFailed(D3DCompileFromFile(GetAssetFullPath(L"shaders.hlsl").c_str(), nullptr, nullptr, "VSMain", "vs_5_0",
		/// compileFlags, 0, &amp;vertexShader, nullptr)); ThrowIfFailed(D3DCompileFromFile(GetAssetFullPath(L"shaders.hlsl").c_str(),
		/// nullptr, nullptr, "PSMain", "ps_5_0", compileFlags, 0, &amp;pixelShader, nullptr)); // Define the vertex input layout.
		/// D3D12_INPUT_ELEMENT_DESC inputElementDescs[] = { { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,
		/// D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, 0 }, { "COLOR", 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 12,
		/// D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, 0 } }; // Describe and create the graphics pipeline state object (PSO).
		/// D3D12_GRAPHICS_PIPELINE_STATE_DESC psoDesc = {}; psoDesc.InputLayout = { inputElementDescs, _countof(inputElementDescs) };
		/// psoDesc.pRootSignature = m_rootSignature.Get(); psoDesc.VS = {
		/// reinterpret_cast&lt;UINT8*&gt;(vertexShader-&gt;GetBufferPointer()), vertexShader-&gt;GetBufferSize() }; psoDesc.PS = {
		/// reinterpret_cast&lt;UINT8*&gt;(pixelShader-&gt;GetBufferPointer()), pixelShader-&gt;GetBufferSize() }; psoDesc.RasterizerState =
		/// CD3DX12_RASTERIZER_DESC(D3D12_DEFAULT); psoDesc.BlendState = CD3DX12_BLEND_DESC(D3D12_DEFAULT);
		/// psoDesc.DepthStencilState.DepthEnable = FALSE; psoDesc.DepthStencilState.StencilEnable = FALSE; psoDesc.SampleMask = UINT_MAX;
		/// psoDesc.PrimitiveTopologyType = D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE; psoDesc.NumRenderTargets = 1; psoDesc.RTVFormats[0] =
		/// DXGI_FORMAT_R8G8B8A8_UNORM; psoDesc.SampleDesc.Count = 1; ThrowIfFailed(m_device-&gt;CreateGraphicsPipelineState(&amp;psoDesc,
		/// IID_PPV_ARGS(&amp;m_pipelineState))); } // Create the command list. ThrowIfFailed(m_device-&gt;CreateCommandList(0,
		/// D3D12_COMMAND_LIST_TYPE_DIRECT, m_commandAllocator.Get(), m_pipelineState.Get(), IID_PPV_ARGS(&amp;m_commandList))); // Command
		/// lists are created in the recording state, but there is nothing // to record yet. The main loop expects it to be closed, so close
		/// it now. ThrowIfFailed(m_commandList-&gt;Close()); // Create the vertex buffer. { // Define the geometry for a triangle. Vertex
		/// triangleVertices[] = { { { 0.0f, 0.25f * m_aspectRatio, 0.0f }, { 1.0f, 0.0f, 0.0f, 1.0f } }, { { 0.25f, -0.25f * m_aspectRatio,
		/// 0.0f }, { 0.0f, 1.0f, 0.0f, 1.0f } }, { { -0.25f, -0.25f * m_aspectRatio, 0.0f }, { 0.0f, 0.0f, 1.0f, 1.0f } } }; const UINT
		/// vertexBufferSize = sizeof(triangleVertices); // Note: using upload heaps to transfer static data like vert buffers is not //
		/// recommended. Every time the GPU needs it, the upload heap will be marshalled // over. Please read up on Default Heap usage. An
		/// upload heap is used here for // code simplicity and because there are very few verts to actually transfer.
		/// ThrowIfFailed(m_device-&gt;CreateCommittedResource( &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE,
		/// &amp;D3D12_RESOURCE_DESC::Buffer(vertexBufferSize), D3D12_RESOURCE_STATE_GENERIC_READ, nullptr,
		/// IID_PPV_ARGS(&amp;m_vertexBuffer))); // Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE
		/// readRange(0, 0); // We do not intend to read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0,
		/// &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices,
		/// sizeof(triangleVertices)); m_vertexBuffer-&gt;Unmap(0, nullptr); // Initialize the vertex buffer view.
		/// m_vertexBufferView.BufferLocation = m_vertexBuffer-&gt;GetGPUVirtualAddress(); m_vertexBufferView.StrideInBytes =
		/// sizeof(Vertex); m_vertexBufferView.SizeInBytes = vertexBufferSize; } // Create synchronization objects and wait until assets
		/// have been uploaded to the GPU. { ThrowIfFailed(m_device-&gt;CreateFence(0, D3D12_FENCE_FLAG_NONE, IID_PPV_ARGS(&amp;m_fence)));
		/// m_fenceValue = 1; // Create an event handle to use for frame synchronization. m_fenceEvent = CreateEvent(nullptr, FALSE, FALSE,
		/// nullptr); if (m_fenceEvent == nullptr) { ThrowIfFailed(HRESULT_FROM_WIN32(GetLastError())); } // Wait for the command list to
		/// execute; we are reusing the same command // list in our main loop but for now, we just want to wait for setup to // complete
		/// before continuing. WaitForPreviousFrame(); } }</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <param name="pInitialState">
		/// <para>Type: <b>ID3D12PipelineState*</b></para>
		/// <para>
		/// A pointer to the <c>ID3D12PipelineState</c> object that contains the initial pipeline state for the command list. This is
		/// optional and can be NULL. If NULL, the runtime sets a dummy initial pipeline state so that drivers don't have to deal with
		/// undefined state. The overhead for this is low, particularly for a command list, for which the overall cost of recording the
		/// command list likely dwarfs the cost of one initial state setting. So there is little cost in not setting the initial pipeline
		/// state parameter if it isn't convenient.
		/// </para>
		/// <para>
		/// For bundles on the other hand, it might make more sense to try to set the initial state parameter since bundles are likely
		/// smaller overall and can be reused frequently.
		/// </para>
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
		/// <remarks>
		/// <para>
		/// By using <b>Reset</b>, you can re-use command list tracking structures without any allocations. Unlike
		/// <c>ID3D12CommandAllocator::Reset</c>, you can call <b>Reset</b> while the command list is still being executed.
		/// </para>
		/// <para>You can use <b>Reset</b> for both direct command lists and bundles.</para>
		/// <para>
		/// The command allocator passed to <b>Reset</b> cannot be associated with any other currently-recording command list. The allocator
		/// type, direct command list or bundle, must match the type of command list that is being created.
		/// </para>
		/// <para>
		/// If a bundle doesn't specify a resource heap, it can't make changes to which descriptor tables are bound. Either way, bundles
		/// can't change the resource heap within the bundle. If a heap is specified for a bundle, the heap must match the calling 'parent'
		/// command list�s heap.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>
		/// Before an app calls <b>Reset</b>, the command list must be in the "closed" state. <b>Reset</b> will fail if the command list
		/// isn't in the "closed" state.
		/// </para>
		/// <para>
		/// <b>Note</b>��If a call to <c>ID3D12GraphicsCommandList::Close</c> fails, the command list can never be reset. Calling
		/// <b>Reset</b> will result in the same error being returned that <b>ID3D12GraphicsCommandList::Close</b> returned.
		/// </para>
		/// <para></para>
		/// <para>
		/// After <b>Reset</b> succeeds, the command list is left in the "recording" state. <b>Reset</b> will fail if it would cause the
		/// maximum concurrently recording command list limit, which is specified at device creation, to be exceeded.
		/// </para>
		/// <para>
		/// Apps must specify a command list allocator. The runtime will ensure that an allocator is never associated with more than one
		/// recording command list at the same time.
		/// </para>
		/// <para><b>Reset</b> fails for bundles that are referenced by a not yet submitted command list.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will also track graphics processing unit (GPU) progress and issue an error if it can't prove that there are no
		/// outstanding executions of the command list.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::Reset</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-reset HRESULT Reset( [in]
		// ID3D12CommandAllocator *pAllocator, [in, optional] ID3D12PipelineState *pInitialState );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator, [In, Optional] ID3D12PipelineState? pInitialState);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <param name="pPipelineState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12PipelineState</c> object that contains the initial pipeline state for the command list.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// It is invalid to call <b>ClearState</b> on a bundle. If an app calls <b>ClearState</b> on a bundle, the call to <c>Close</c>
		/// will return <b>E_FAIL</b>.
		/// </para>
		/// <para>
		/// When <b>ClearState</b> is called, all currently bound resources are unbound. The primitive topology is set to
		/// <c>D3D_PRIMITIVE_TOPOLOGY_UNDEFINED</c>. Viewports, scissor rectangles, stencil reference value, and the blend factor are set to
		/// empty values (all zeros). Predication is disabled.
		/// </para>
		/// <para>The app-provided pipeline state object becomes bound as the currently set pipeline state object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearstate void ClearState( [in,
		// optional] ID3D12PipelineState *pPipelineState );
		[PreserveSig]
		new void ClearState([In, Optional] ID3D12PipelineState? pPipelineState);

		/// <summary>Draws non-indexed, instanced primitives.</summary>
		/// <param name="VertexCountPerInstance">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Index of the first vertex.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors.
		/// </para>
		/// <para>
		/// The vertex data for an instanced draw call typically comes from a vertex buffer that is bound to the pipeline. But, you could
		/// also provide the vertex data from a shader that has instanced data identified with a system-value semantic (SV_InstanceID).
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::DrawInstanced</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-drawinstanced void DrawInstanced(
		// [in] UINT VertexCountPerInstance, [in] UINT InstanceCount, [in] UINT StartVertexLocation, [in] UINT StartInstanceLocation );
		[PreserveSig]
		new void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		/// <summary>Draws indexed, instanced primitives.</summary>
		/// <param name="IndexCountPerInstance">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of indices read from the index buffer for each instance.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <b><c>INT</c></b></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors. Instancing requires multiple vertex buffers: at least one
		/// for per-vertex data and a second buffer for per-instance data.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::DrawIndexedInstanced</b> as follows:</para>
		/// <para>
		/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1,
		/// ID3D12PipelineState* pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc,
		/// D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize,
		/// ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root
		/// signature of the caller, then // bindings are inherited, otherwise the bind space is reset.
		/// pCommandList-&gt;SetGraphicsRootSignature(pRootSignature); ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap,
		/// pSamplerDescriptorHeap }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); //
		/// Calculate the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
		/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset,
		/// cbvSrvDescriptorSize); BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt;
		/// m_cityColumnCount; j++) { // Alternate which PSO to use; the pixel shader is different on // each just as a PSO setting
		/// demonstration. pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and
		/// move to the next descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle);
		/// cbvSrvHandle.Offset(cbvSrvDescriptorSize); pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-drawindexedinstanced void
		// DrawIndexedInstanced( [in] UINT IndexCountPerInstance, [in] UINT InstanceCount, [in] UINT StartIndexLocation, [in] INT
		// BaseVertexLocation, [in] UINT StartInstanceLocation );
		[PreserveSig]
		new void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		/// <summary>Executes a command list from a thread group.</summary>
		/// <param name="ThreadGroupCountX">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the x direction. <i>ThreadGroupCountX</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountY">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the y direction. <i>ThreadGroupCountY</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountZ">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the z direction. <i>ThreadGroupCountZ</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535). In feature level 10 the value for <i>ThreadGroupCountZ</i> must be 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You call the <b>Dispatch</b> method to execute commands in a compute shader. A compute shader can be run on many threads in
		/// parallel, within a thread group. Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
		///  Examples The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12GraphicsCommandList::Dispatch</b> as follows:</para>
		/// <para>
		/// <c>// Run the particle simulation using the compute shader. void D3D12nBodyGravity::Simulate(UINT threadIndex) {
		/// ID3D12GraphicsCommandList* pCommandList = m_computeCommandList[threadIndex].Get(); UINT srvIndex; UINT uavIndex; ID3D12Resource
		/// *pUavResource; if (m_srvIndex[threadIndex] == 0) { srvIndex = SrvParticlePosVelo0; uavIndex = UavParticlePosVelo1; pUavResource
		/// = m_particleBuffer1[threadIndex].Get(); } else { srvIndex = SrvParticlePosVelo1; uavIndex = UavParticlePosVelo0; pUavResource =
		/// m_particleBuffer0[threadIndex].Get(); } pCommandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(pUavResource, D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE,
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS)); pCommandList-&gt;SetPipelineState(m_computeState.Get());
		/// pCommandList-&gt;SetComputeRootSignature(m_computeRootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_srvUavHeap.Get()
		/// }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// srvHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), srvIndex + threadIndex, m_srvUavDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE uavHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), uavIndex + threadIndex,
		/// m_srvUavDescriptorSize); pCommandList-&gt;SetComputeRootConstantBufferView(RootParameterCB,
		/// m_constantBufferCS-&gt;GetGPUVirtualAddress()); pCommandList-&gt;SetComputeRootDescriptorTable(RootParameterSRV, srvHandle);
		/// pCommandList-&gt;SetComputeRootDescriptorTable(RootParameterUAV, uavHandle);
		/// pCommandList-&gt;Dispatch(static_cast&lt;int&gt;(ceil(ParticleCount / 128.0f)), 1, 1); pCommandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(pUavResource, D3D12_RESOURCE_STATE_UNORDERED_ACCESS,
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE)); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-dispatch void Dispatch( [in] UINT
		// ThreadGroupCountX, [in] UINT ThreadGroupCountY, [in] UINT ThreadGroupCountZ );
		[PreserveSig]
		new void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		/// <summary>Copies a region of a buffer from one resource to another.</summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies the destination <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 offset (in bytes) into the destination resource.</para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies the source <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 offset (in bytes) into the source resource, to start the copy from.</para>
		/// </param>
		/// <param name="NumBytes">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies the number of bytes to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Consider using the <c>CopyResource</c> method when copying an entire resource, and use this method for copying regions of a resource.
		/// </para>
		/// <para>
		/// <b>CopyBufferRegion</b> may be used to initialize resources which alias the same heap memory. See <c>CreatePlacedResource</c>
		/// for more details.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::CopyBufferRegion</b> as follows:</para>
		/// <para>
		/// <c>inline UINT64 UpdateSubresources( _In_ ID3D12GraphicsCommandList* pCmdList, _In_ ID3D12Resource* pDestinationResource, _In_
		/// ID3D12Resource* pIntermediate, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources, UINT64 RequiredSize, _In_reads_(NumSubresources)
		/// const D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayouts, _In_reads_(NumSubresources) const UINT* pNumRows,
		/// _In_reads_(NumSubresources) const UINT64* pRowSizesInBytes, _In_reads_(NumSubresources) const D3D12_SUBRESOURCE_DATA* pSrcData)
		/// { // Minor validation D3D12_RESOURCE_DESC IntermediateDesc = pIntermediate-&gt;GetDesc(); D3D12_RESOURCE_DESC DestinationDesc =
		/// pDestinationResource-&gt;GetDesc(); if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER || IntermediateDesc.Width
		/// &lt; RequiredSize + pLayouts[0].Offset || RequiredSize &gt; (SIZE_T)-1 || (DestinationDesc.Dimension ==
		/// D3D12_RESOURCE_DIMENSION_BUFFER &amp;&amp; (FirstSubresource != 0 || NumSubresources != 1))) { return 0; } BYTE* pData; HRESULT
		/// hr = pIntermediate-&gt;Map(0, NULL, reinterpret_cast&lt;void**&gt;(&amp;pData)); if (FAILED(hr)) { return 0; } for (UINT i = 0;
		/// i &lt; NumSubresources; ++i) { if (pRowSizesInBytes[i] &gt; (SIZE_T)-1) return 0; D3D12_MEMCPY_DEST DestData = { pData +
		/// pLayouts[i].Offset, pLayouts[i].Footprint.RowPitch, pLayouts[i].Footprint.RowPitch * pNumRows[i] };
		/// MemcpySubresource(&amp;DestData, &amp;pSrcData[i], (SIZE_T)pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth); }
		/// pIntermediate-&gt;Unmap(0, NULL); if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION_BUFFER) { CD3DX12_BOX SrcBox( UINT(
		/// pLayouts[0].Offset ), UINT( pLayouts[0].Offset + pLayouts[0].Footprint.Width ) ); pCmdList-&gt;CopyBufferRegion(
		/// pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width); } else { for (UINT i = 0; i &lt;
		/// NumSubresources; ++i) { CD3DX12_TEXTURE_COPY_LOCATION Dst(pDestinationResource, i + FirstSubresource);
		/// CD3DX12_TEXTURE_COPY_LOCATION Src(pIntermediate, pLayouts[i]); pCmdList-&gt;CopyTextureRegion(&amp;Dst, 0, 0, 0, &amp;Src,
		/// nullptr); } } return RequiredSize; }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copybufferregion void
		// CopyBufferRegion( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset, UINT64
		// NumBytes );
		[PreserveSig]
		new void CopyBufferRegion([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, ulong NumBytes);

		/// <summary>
		/// This method uses the GPU to copy texture data between two locations. Both the source and the destination may reference texture
		/// data located within either a buffer resource or a texture resource.
		/// </summary>
		/// <param name="pDst">
		/// <para>Type: <b>const <c>D3D12_TEXTURE_COPY_LOCATION</c>*</b></para>
		/// <para>
		/// Specifies the destination <c>D3D12_TEXTURE_COPY_LOCATION</c>. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COPY_DEST state.
		/// </para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The x-coordinate of the upper left corner of the destination region.</para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The y-coordinate of the upper left corner of the destination region. For a 1D subresource, this must be zero.</para>
		/// </param>
		/// <param name="DstZ">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The z-coordinate of the upper left corner of the destination region. For a 1D or 2D subresource, this must be zero.</para>
		/// </param>
		/// <param name="pSrc">
		/// <para>Type: <b>const <c>D3D12_TEXTURE_COPY_LOCATION</c>*</b></para>
		/// <para>
		/// Specifies the source <c>D3D12_TEXTURE_COPY_LOCATION</c>. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COPY_SOURCE state.
		/// </para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>Specifies an optional D3D12_BOX that sets the size of the source texture to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source box must be within the size of the source resource. The destination offsets, (x, y, and z), allow the source box to
		/// be offset when writing into the destination resource; however, the dimensions of the source box and the offsets must be within
		/// the size of the resource. If you try and copy outside the destination resource or specify a source box that is larger than the
		/// source resource, the behavior of <b>CopyTextureRegion</b> is undefined. If you created a device that supports the <c>debug
		/// layer</c>, the debug output reports an error on this invalid <b>CopyTextureRegion</b> call. Invalid parameters to
		/// <b>CopyTextureRegion</b> cause undefined behavior and might result in incorrect rendering, clipping, no copy, or even the
		/// removal of the rendering device.
		/// </para>
		/// <para>If the resources are buffers, all coordinates are in bytes; if the resources are textures, all coordinates are in texels.</para>
		/// <para>
		/// <b>CopyTextureRegion</b> performs the copy on the GPU (similar to a <c>memcpy</c> by the CPU). As a consequence, the source and
		/// destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different subresources (although they can be from the same resource).</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible <c>DXGI_FORMAT</c> s (identical or from the same type group). For example, a DXGI_FORMAT_R32G32B32_FLOAT
		/// texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in the
		/// DXGI_FORMAT_R32G32B32_TYPELESS group. <b>CopyTextureRegion</b> can copy between a few format types. For more info, see <c>Format
		/// Conversion using Direct3D 10.1</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>CopyTextureRegion</b> only supports copy; it does not support any stretch, color key, or blend. <b>CopyTextureRegion</b> can
		/// reinterpret the resource data between a few format types.
		/// </para>
		/// <para>Note that for a depth-stencil buffer, the depth and stencil planes are <c>separate subresources</c> within the buffer.</para>
		/// <para>To copy an entire resource, rather than just a region of a subresource, we recommend to use <c>CopyResource</c> instead.</para>
		/// <para>
		/// <b>Note</b>��If you use <b>CopyTextureRegion</b> with a depth-stencil buffer or a multisampled resource, you must copy the
		/// entire subresource rectangle. In this situation, you must pass 0 to the <i>DstX</i>, <i>DstY</i>, and <i>DstZ</i> parameters and
		/// <b>NULL</b> to the <i>pSrcBox</i> parameter. In addition, source and destination resources, which are represented by the
		/// <i>pSrcResource</i> and <i>pDstResource</i> parameters, should have identical sample count values.
		/// </para>
		/// <para></para>
		/// <para>
		/// <b>CopyTextureRegion</b> may be used to initialize resources which alias the same heap memory. See <c>CreatePlacedResource</c>
		/// for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Example</para>
		/// <para>
		/// The following code snippet copies the box (located at (120,100),(200,220)) from a source texture into the region
		/// (10,20),(90,140) in a destination texture.
		/// </para>
		/// <para>
		/// <c>D3D12_BOX sourceRegion; sourceRegion.left = 120; sourceRegion.top = 100; sourceRegion.right = 200; sourceRegion.bottom = 220;
		/// sourceRegion.front = 0; sourceRegion.back = 1; pCmdList -&gt; CopyTextureRegion(pDestTexture, 10, 20, 0, pSourceTexture, &amp;sourceRegion);</c>
		/// </para>
		/// <para>Notice, that for a 2D texture, front and back are set to 0 and 1 respectively. Examples The <b>HelloTriangle</b> sample uses <b>ID3D12GraphicsCommandList::CopyTextureRegion</b> as follows:</para>
		/// <para>
		/// <c>inline UINT64 UpdateSubresources( _In_ ID3D12GraphicsCommandList* pCmdList, _In_ ID3D12Resource* pDestinationResource, _In_
		/// ID3D12Resource* pIntermediate, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources, UINT64 RequiredSize, _In_reads_(NumSubresources)
		/// const D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayouts, _In_reads_(NumSubresources) const UINT* pNumRows,
		/// _In_reads_(NumSubresources) const UINT64* pRowSizesInBytes, _In_reads_(NumSubresources) const D3D12_SUBRESOURCE_DATA* pSrcData)
		/// { // Minor validation D3D12_RESOURCE_DESC IntermediateDesc = pIntermediate-&gt;GetDesc(); D3D12_RESOURCE_DESC DestinationDesc =
		/// pDestinationResource-&gt;GetDesc(); if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER || IntermediateDesc.Width
		/// &lt; RequiredSize + pLayouts[0].Offset || RequiredSize &gt; (SIZE_T)-1 || (DestinationDesc.Dimension ==
		/// D3D12_RESOURCE_DIMENSION_BUFFER &amp;&amp; (FirstSubresource != 0 || NumSubresources != 1))) { return 0; } BYTE* pData; HRESULT
		/// hr = pIntermediate-&gt;Map(0, NULL, reinterpret_cast&lt;void**&gt;(&amp;pData)); if (FAILED(hr)) { return 0; } for (UINT i = 0;
		/// i &lt; NumSubresources; ++i) { if (pRowSizesInBytes[i] &gt; (SIZE_T)-1) return 0; D3D12_MEMCPY_DEST DestData = { pData +
		/// pLayouts[i].Offset, pLayouts[i].Footprint.RowPitch, pLayouts[i].Footprint.RowPitch * pNumRows[i] };
		/// MemcpySubresource(&amp;DestData, &amp;pSrcData[i], (SIZE_T)pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth); }
		/// pIntermediate-&gt;Unmap(0, NULL); if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION_BUFFER) { CD3DX12_BOX SrcBox( UINT(
		/// pLayouts[0].Offset ), UINT( pLayouts[0].Offset + pLayouts[0].Footprint.Width ) ); pCmdList-&gt;CopyBufferRegion(
		/// pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width); } else { for (UINT i = 0; i &lt;
		/// NumSubresources; ++i) { CD3DX12_TEXTURE_COPY_LOCATION Dst(pDestinationResource, i + FirstSubresource);
		/// CD3DX12_TEXTURE_COPY_LOCATION Src(pIntermediate, pLayouts[i]); pCmdList-&gt;CopyTextureRegion(&amp;Dst, 0, 0, 0, &amp;Src,
		/// nullptr); } } return RequiredSize; }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copytextureregion void
		// CopyTextureRegion( [in] const D3D12_TEXTURE_COPY_LOCATION *pDst, UINT DstX, UINT DstY, UINT DstZ, [in] const
		// D3D12_TEXTURE_COPY_LOCATION *pSrc, [in, optional] const D3D12_BOX *pSrcBox );
		[PreserveSig]
		new void CopyTextureRegion(in D3D12_TEXTURE_COPY_LOCATION pDst, uint DstX, uint DstY, uint DstZ, in D3D12_TEXTURE_COPY_LOCATION pSrc,
			[In, Optional] StructPointer<D3D12_BOX> pSrcBox);

		/// <summary>Copies the entire contents of the source resource to the destination resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the destination resource.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the source resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>CopyResource</b> operations are performed on the GPU, and do not incur a significant CPU workload linearly dependent on the
		/// size of the data to copy.
		/// </para>
		/// <para>
		/// <b>CopyResource</b> can be used to initialize resources that alias the same heap memory. See <c>CreatePlacedResource</c> for
		/// more details.
		/// </para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues an error if the source subresource is not in the <c>D3D12_RESOURCE_STATE_COPY_SOURCE</c> state.</para>
		/// <para>The debug layer issues an error if the destination subresource is not in the <c>D3D12_RESOURCE_STATE_COPY_DEST</c> state. Restrictions This method has a few restrictions designed for improving performance. For instance, the source and destination resources:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different resources.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same total size (bytes).</description>
		/// </item>
		/// <item>
		/// <description>Must have identical dimensions (width, height, depth) or be a compatible <c>Reinterpret Copy</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible <c>DXGI formats</c>, which means the formats must be identical or at least from the same type group. For
		/// example, a DXGI_FORMAT_R32G32B32_FLOAT texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats
		/// are in the DXGI_FORMAT_R32G32B32_TYPELESS group. <b>CopyResource</b> can copy between a few format types (see <c>Reinterpret copy</c>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>Can't be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para><b>CopyResource</b> only supports copy; it doesn't support any stretch, color key, or blend.</para>
		/// <para>
		/// <b>CopyResource</b> can reinterpret the resource data between a few format types, see <c>Reinterpret Copy</c> below for details.
		/// </para>
		/// <para>
		/// You can use a <c>depth-stencil</c> resource as either a source or a destination. Resources created with multi-sampling
		/// capability (see <c>DXGI_SAMPLE_DESC</c>) can be used as source and destination only if both source and destination have
		/// identical multi-sampled count and quality. If source and destination differ in multi-sampled count and quality or if one is
		/// multi-sampled and the other is not multi-sampled, the call to <b>CopyResource</b> fails. Use <c>ResolveSubresource</c> to
		/// resolve a multi-sampled resource to a resource that is not multi-sampled.
		/// </para>
		/// <para>
		/// The method is an asynchronous call, which may be added to the command-buffer queue. This attempts to remove pipeline stalls that
		/// may occur when copying data. For more info, see <c>performance considerations</c>.
		/// </para>
		/// <para>
		/// Consider using <c>CopyTextureRegion</c> or <c>CopyBufferRegion</c> if you only need to copy a portion of the data in a resource.
		/// </para>
		/// <para>Reinterpret copy</para>
		/// <para>
		/// The following table lists the allowable source and destination formats that you can use in the reinterpretation type of format
		/// conversion. The underlying data values are not converted or compressed/decompressed and must be encoded properly for the
		/// reinterpretation to work as expected. For more info, see <c>Format Conversion using Direct3D 10.1</c>.
		/// </para>
		/// <para>For DXGI_FORMAT_R9G9B9E5_SHAREDEXP the width and height must be equal (1 texel per block).</para>
		/// <para>
		/// Block-compressed resource width and height must be 4 times the uncompressed resource width and height (16 texels per block). For
		/// example, a uncompressed 256x256 DXGI_FORMAT_R32G32B32A32_UINT texture will map to a 1024x1024 DXGI_FORMAT_BC5_UNORM compressed texture.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Bit width</description>
		/// <description>Uncompressed resource</description>
		/// <description>Block-compressed resource</description>
		/// <description>Width / height difference</description>
		/// </listheader>
		/// <item>
		/// <description>32</description>
		/// <description>DXGI_FORMAT_R32_UINT DXGI_FORMAT_R32_SINT</description>
		/// <description>DXGI_FORMAT_R9G9B9E5_SHAREDEXP</description>
		/// <description>1:1</description>
		/// </item>
		/// <item>
		/// <description>64</description>
		/// <description>DXGI_FORMAT_R16G16B16A16_UINT DXGI_FORMAT_R16G16B16A16_SINT DXGI_FORMAT_R32G32_UINT DXGI_FORMAT_R32G32_SINT</description>
		/// <description>DXGI_FORMAT_BC1_UNORM[_SRGB] DXGI_FORMAT_BC4_UNORM DXGI_FORMAT_BC4_SNORM</description>
		/// <description>1:4</description>
		/// </item>
		/// <item>
		/// <description>128</description>
		/// <description>DXGI_FORMAT_R32G32B32A32_UINT DXGI_FORMAT_R32G32B32A32_SINT</description>
		/// <description>DXGI_FORMAT_BC2_UNORM[_SRGB] DXGI_FORMAT_BC3_UNORM[_SRGB] DXGI_FORMAT_BC5_UNORM DXGI_FORMAT_BC5_SNORM</description>
		/// <description>1:4</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copyresource void CopyResource( [in]
		// ID3D12Resource *pDstResource, [in] ID3D12Resource *pSrcResource );
		[PreserveSig]
		new void CopyResource([In] ID3D12Resource pDstResource, [In] ID3D12Resource pSrcResource);

		/// <summary>Copies tiles from buffer to tiled resource or vice versa.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to a tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionStartCoordinate">
		/// <para>Type: <b>const <c>D3D12_TILED_RESOURCE_COORDINATE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_TILED_RESOURCE_COORDINATE</c> structure that describes the starting coordinates of the tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionSize">
		/// <para>Type: <b>const <c>D3D12_TILE_REGION_SIZE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_TILE_REGION_SIZE</c> structure that describes the size of the tiled region.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to an <c>ID3D12Resource</c> that represents a default, dynamic, or staging buffer.</para>
		/// </param>
		/// <param name="BufferStartOffsetInBytes">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset in bytes into the buffer at <i>pBuffer</i> to start the operation.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_TILE_COPY_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_TILE_COPY_FLAGS</c>-typed values that are combined by using a bitwise OR operation and that identifies
		/// how to copy tiles.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>CopyTiles</b> drops write operations to unmapped areas and handles read operations from unmapped areas (except on Tier_1
		/// tiled resources, where reading and writing unmapped areas is invalid - refer to <c>D3D12_TILED_RESOURCES_TIER</c>).
		/// </para>
		/// <para>
		/// If a copy operation involves writing to the same memory location multiple times because multiple locations in the destination
		/// resource are mapped to the same tile memory, the resulting write operations to multi-mapped tiles are non-deterministic and
		/// non-repeatable; that is, accesses to the tile memory happen in whatever order the hardware happens to execute the copy operation.
		/// </para>
		/// <para>
		/// The tiles involved in the copy operation can't include tiles that contain packed mipmaps or results of the copy operation are
		/// undefined. To transfer data to and from mipmaps that the hardware packs into the one-or-more tiles that constitute the packed
		/// mips, you must use the standard (that is, non-tile specific) copy APIs like <c>CopyTextureRegion</c>.
		/// </para>
		/// <para><b>CopyTiles</b> does copy data in a slightly different pattern than the standard copy methods.</para>
		/// <para>
		/// The memory layout of the tiles in the non-tiled buffer resource side of the copy operation is linear in memory within 64 KB
		/// tiles, which the hardware and driver swizzle and de-swizzle per tile as appropriate when they transfer to and from a tiled
		/// resource. For multisample antialiasing (MSAA) surfaces, the hardware and driver traverse each pixel's samples in sample-index
		/// order before they move to the next pixel. For tiles that are partially filled on the right side (for a surface that has a width
		/// not a multiple of tile width in pixels), the pitch and stride to move down a row is the full size in bytes of the number pixels
		/// that would fit across the tile if the tile was full. So, there can be a gap between each row of pixels in memory. Mipmaps that
		/// are smaller than a tile are not packed together in the linear layout, which might seem to be a waste of memory space, but as
		/// mentioned you can't use <b>CopyTiles</b> to copy to mipmaps that the hardware packs together. You can just use generic copy
		/// APIs, like <c>CopyTextureRegion</c>, to copy small mipmaps individually.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copytiles void CopyTiles( [in]
		// ID3D12Resource *pTiledResource, [in] const D3D12_TILED_RESOURCE_COORDINATE *pTileRegionStartCoordinate, [in] const
		// D3D12_TILE_REGION_SIZE *pTileRegionSize, [in] ID3D12Resource *pBuffer, UINT64 BufferStartOffsetInBytes, D3D12_TILE_COPY_FLAGS
		// Flags );
		[PreserveSig]
		new void CopyTiles([In] ID3D12Resource pTiledResource, in D3D12_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate,
			in D3D12_TILE_REGION_SIZE pTileRegionSize, [In] ID3D12Resource pBuffer, ulong BufferStartOffsetInBytes, D3D12_TILE_COPY_FLAGS Flags);

		/// <summary>Copy a multi-sampled resource into a non-multi-sampled resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: [in] <b>ID3D12Resource*</b></para>
		/// <para>Destination resource. Must be a created on a <c>D3D12_HEAP_TYPE_DEFAULT</c> heap and be single-sampled. See <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>
		/// A zero-based index, that identifies the destination subresource. Use <c>D3D12CalcSubresource</c> to calculate the subresource
		/// index if the parent resource is complex.
		/// </para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: [in] <b>ID3D12Resource*</b></para>
		/// <para>Source resource. Must be multisampled.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The source subresource of the source resource.</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: [in] <b>DXGI_FORMAT</b></para>
		/// <para>A <c>DXGI_FORMAT</c> that indicates how the multisampled resource will be resolved to a single-sampled resource. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the source view is not in the
		/// <c>D3D12_RESOURCE_STATE_RESOLVE_SOURCE</c> state.
		/// </para>
		/// <para>The debug layer will issue an error if the destination buffer is not in the <c>D3D12_RESOURCE_STATE_RESOLVE_DEST</c> state.</para>
		/// <para>
		/// The source and destination resources must be the same resource type and have the same dimensions. In addition, they must have
		/// compatible formats. There are three scenarios for this:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Scenario</description>
		/// <description>Requirements</description>
		/// </listheader>
		/// <item>
		/// <description>Source and destination are prestructured and typed</description>
		/// <description>
		/// Both the source and destination must have identical formats and that format must be specified in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>One resource is prestructured and typed and the other is prestructured and typeless</description>
		/// <description>
		/// The typed resource must have a format that is compatible with the typeless resource (i.e. the typed resource is
		/// DXGI_FORMAT_R32_FLOAT and the typeless resource is DXGI_FORMAT_R32_TYPELESS). The format of the typed resource must be specified
		/// in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Source and destination are prestructured and typeless</description>
		/// <description>
		/// Both the source and destination must have the same typeless format (i.e. both must have DXGI_FORMAT_R32_TYPELESS), and the
		/// Format parameter must specify a format that is compatible with the source and destination (i.e. if both are
		/// DXGI_FORMAT_R32_TYPELESS then DXGI_FORMAT_R32_FLOAT could be specified in the Format parameter). For example, given the
		/// DXGI_FORMAT_R16G16B16A16_TYPELESS format:
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resolvesubresource void
		// ResolveSubresource( ID3D12Resource *pDstResource, UINT DstSubresource, ID3D12Resource *pSrcResource, UINT SrcSubresource,
		// DXGI_FORMAT Format );
		[PreserveSig]
		new void ResolveSubresource([In] ID3D12Resource pDstResource, uint DstSubresource, [In] ID3D12Resource pSrcResource, uint SrcSubresource,
			DXGI_FORMAT Format);

		/// <summary>Bind information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="PrimitiveTopology">
		/// <para>Type: <b>D3D12_PRIMITIVE_TOPOLOGY</b></para>
		/// <para>The type of primitive and ordering of the primitive data (see <c>D3D_PRIMITIVE_TOPOLOGY</c>).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetprimitivetopology void
		// IASetPrimitiveTopology( [in] D3D12_PRIMITIVE_TOPOLOGY PrimitiveTopology );
		[PreserveSig]
		new void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY PrimitiveTopology);

		/// <summary>Bind an array of viewports to the rasterizer stage of the pipeline.</summary>
		/// <param name="NumViewports">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Number of viewports to bind. The range of valid values is (0, D3D12_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE).</para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <b>const <c>D3D12_VIEWPORT</c>*</b></para>
		/// <para>An array of <c>D3D12_VIEWPORT</c> structures to bind to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All viewports must be set atomically as one operation. Any viewports not defined by the call are disabled.</para>
		/// <para>
		/// Which viewport to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader; if a geometry
		/// shader does not specify the semantic, Direct3D will use the first viewport in the array.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::RSSetViewports</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-rssetviewports void RSSetViewports(
		// [in] UINT NumViewports, [in] const D3D12_VIEWPORT *pViewports );
		[PreserveSig]
		new void RSSetViewports(int NumViewports, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_VIEWPORT[] pViewports);

		/// <summary>Binds an array of scissor rectangles to the rasterizer stage.</summary>
		/// <param name="NumRects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of scissor rectangles to bind.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const D3D12_RECT*</b></para>
		/// <para>An array of scissor rectangles.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All scissor rectangles must be set atomically as one operation. Any scissor rectangles not defined by the call are disabled.</para>
		/// <para>
		/// Which scissor rectangle to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader (see
		/// shader semantic syntax). If a geometry shader does not make use of the <c>SV_ViewportArrayIndex</c> semantic then Direct3D will
		/// use the first scissor rectangle in the array.
		/// </para>
		/// <para>Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see <c>RSSetViewports</c>). Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::RSSetScissorRects</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>// Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps
		/// should use // fences to determine GPU execution progress. ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when
		/// ExecuteCommandList() is called on a particular command // list, that command list can then be reset at any time and must be
		/// before // re-recording. ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set
		/// necessary state. m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1,
		/// &amp;m_viewport); m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a
		/// render target. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close());</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-rssetscissorrects void
		// RSSetScissorRects( [in] UINT NumRects, [in] const D3D12_RECT *pRects );
		[PreserveSig]
		new void RSSetScissorRects(int NumRects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		/// <summary>Sets the blend factor that modulate values for a pixel shader, render target, or both.</summary>
		/// <param name="BlendFactor">
		/// <para>Type: <b>const FLOAT[4]</b></para>
		/// <para>Array of blend factors, one for each RGBA component.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If you created the blend-state object with <c>D3D12_BLEND_BLEND_FACTOR</c> or <b>D3D12_BLEND_INV_BLEND_FACTOR</b>, then the
		/// blending stage uses the non-NULL array of blend factors. Otherwise,the blending stage doesn't use the non-NULL array of blend
		/// factors; the runtime stores the blend factors.
		/// </para>
		/// <para>If you pass NULL, then the runtime uses or stores a blend factor equal to <c>{ 1, 1, 1, 1 }</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetblendfactor void
		// OMSetBlendFactor( [in, optional] const FLOAT [4] BlendFactor );
		[PreserveSig]
		new void OMSetBlendFactor([In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[]? BlendFactor);

		/// <summary>Sets the reference value for depth stencil tests.</summary>
		/// <param name="StencilRef">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Reference value to perform against when doing a depth-stencil test.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetstencilref void
		// OMSetStencilRef( [in] UINT StencilRef );
		[PreserveSig]
		new void OMSetStencilRef(uint StencilRef);

		/// <summary>Sets all shaders and programs most of the fixed-function state of the graphics processing unit (GPU) pipeline.</summary>
		/// <param name="pPipelineState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>Pointer to the <c>ID3D12PipelineState</c> containing the pipeline state data.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setpipelinestate void
		// SetPipelineState( [in] ID3D12PipelineState *pPipelineState );
		[PreserveSig]
		new void SetPipelineState([In] ID3D12PipelineState pPipelineState);

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
		/// <remarks>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// A resource to be used for the <c>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</c> state must be created in that state,
		/// and then never transitioned out of it. Nor may a resource that was created not in that state be transitioned into it. For more
		/// info, see <c>Acceleration structure memory restrictions</c> in the DirectX raytracing (DXR) functional specification on GitHub.
		/// </para>
		/// </para>
		/// <para>There are three types of barrier descriptions:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_TRANSITION_BARRIER</c> - Transition barriers indicate that a set of subresources transition between different
		/// usages. The caller must specify the <i>before</i> and <i>after</i> usages of the subresources. The
		/// D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES flag is used to transition all subresources in a resource at the same time.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_ALIASING_BARRIER</c> - Aliasing barriers indicate a transition between usages of two different resources which
		/// have mappings into the same heap. The application can specify both the before and the after resource. Note that one or both
		/// resources can be NULL (indicating that any tiled resource could cause aliasing).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_UAV_BARRIER</c> - Unordered access view barriers indicate all UAV accesses (read or writes) to a particular
		/// resource must complete before any future UAV accesses (read or write) can begin. The specified resource may be NULL. It is not
		/// necessary to insert a UAV barrier between two draw or dispatch calls which only read a UAV. Additionally, it is not necessary to
		/// insert a UAV barrier between two draw or dispatch calls which write to the same UAV if the application knows that it is safe to
		/// execute the UAV accesses in any order. The resource can be NULL (indicating that any UAV access could require the barrier).
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// When <b>ID3D12GraphicsCommandList::ResourceBarrier</b> is passed an array of resource barrier descriptions, the API behaves as
		/// if it was called N times (1 for each array element), in the specified order. Transitions should be batched together into a
		/// single API call when possible, as a performance optimization.
		/// </para>
		/// <para>
		/// For descriptions of the usage states a subresource can be in, see the <c>D3D12_RESOURCE_STATES</c> enumeration and the <c>Using
		/// Resource Barriers to Synchronize Resource States in Direct3D 12</c> section.
		/// </para>
		/// <para>
		/// All subresources in a resource must be in the RENDER_TARGET state, or DEPTH_WRITE state, for render targets/depth-stencil
		/// resources respectively, when <c>ID3D12GraphicsCommandList::DiscardResource</c> is called.
		/// </para>
		/// <para>
		/// When a back buffer is presented, it must be in the D3D12_RESOURCE_STATE_PRESENT state. If <c>IDXGISwapChain1::Present1</c> is
		/// called on a resource which is not in the PRESENT state, a debug layer warning will be emitted.
		/// </para>
		/// <para>The resource usage bits are group into two categories, read-only and read/write.</para>
		/// <para>The following usage bits are read-only:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_INDEX_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_COPY_SOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_DEPTH_READ</description>
		/// </item>
		/// </list>
		/// <para>The following usage bits are read/write:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_DEPTH_WRITE</description>
		/// </item>
		/// </list>
		/// <para>The following usage bits are write-only:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_COPY_DEST</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_RENDER_TARGET</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_STREAM_OUT</description>
		/// </item>
		/// </list>
		/// <para>
		/// At most one write bit can be set. If any write bit is set, then no read bit may be set. If no write bit is set, then any number
		/// of read bits may be set.
		/// </para>
		/// <para>
		/// At any given time, a subresource is in exactly one state (determined by a set of flags). The application must ensure that the
		/// states are matched when making a sequence of <b>ResourceBarrier</b> calls. In other words, the before and after states in
		/// consecutive calls to <b>ResourceBarrier</b> must agree.
		/// </para>
		/// <para>
		/// To transition all subresources within a resource, the application can set the subresource index to
		/// D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES, which implies that all subresources are changed.
		/// </para>
		/// <para>
		/// For improved performance, applications should use split barriers (refer to <c>Multi-engine synchronization</c>). Your
		/// application should also batch multiple transitions into a single call whenever possible.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>The runtime will validate that the barrier type values are valid members of the <c>D3D12_RESOURCE_BARRIER_TYPE</c> enumeration.</para>
		/// <para>In addition, the runtime checks the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The resource pointer is non-NULL.</description>
		/// </item>
		/// <item>
		/// <description>The subresource index is valid</description>
		/// </item>
		/// <item>
		/// <description>
		/// The before and after states are supported by the <c>D3D12_RESOURCE_BINDING_TIER</c> and <c>D3D12_RESOURCE_FLAGS</c> flags of the resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Reserved bits in the state masks are not set.</description>
		/// </item>
		/// <item>
		/// <description>The before and after states are different.</description>
		/// </item>
		/// <item>
		/// <description>The set of bits in the before and after states are valid.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If the D3D12_RESOURCE_STATE_RESOLVE_SOURCE bit is set, then the resource sample count must be greater than 1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If the D3D12_RESOURCE_STATE_RESOLVE_DEST bit is set, then the resource sample count must be equal to 1.</description>
		/// </item>
		/// </list>
		/// <para>For aliasing barriers the runtime will validate that, if either resource pointer is non-NULL, it refers to a tiled resource.</para>
		/// <para>
		/// For UAV barriers the runtime will validate that, if the resource is non-NULL, the resource has the
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS bind flag set.
		/// </para>
		/// <para>Validation failure causes <c>ID3D12GraphicsCommandList::Close</c> to return E_INVALIDARG.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer normally issues errors where runtime validation fails:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If a subresource transition in a command list is inconsistent with previous transitions in the same command list.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If a resource is used without first calling <b>ResourceBarrier</b> to put the resource into the correct state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If a resource is illegally bound for read and write at the same time.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If the <i>before</i> states passed to the <b>ResourceBarrier</b> do not match the <i>after</i> states of previous calls to
		/// <b>ResourceBarrier</b>, including the aliasing case.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Whereas the debug layer attempts to validate the runtime rules, it operates conservatively so that debug layer errors are real
		/// errors, and in some cases real errors may not produce debug layer errors.
		/// </para>
		/// <para>The debug layer will issue warnings in the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>All of the cases where the D3D12 debug layer would issues warnings for <c>ID3D12GraphicsCommandList::ResourceBarrier</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If a depth buffer is used in a non-read-only mode while the resource has the D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE usage
		/// bit set.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resourcebarrier void
		// ResourceBarrier( [in] UINT NumBarriers, [in] const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>Executes a bundle.</summary>
		/// <param name="pCommandList">
		/// <para>Type: <b><c>ID3D12GraphicsCommandList</c>*</b></para>
		/// <para>Specifies the <c>ID3D12GraphicsCommandList</c> that determines the bundle to be executed.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Bundles inherit all state from the parent command list on which <b>ExecuteBundle</b> is called, except the pipeline state object
		/// and primitive topology. All of the state that is set in a bundle will affect the state of the parent command list. Note that
		/// <b>ExecuteBundle</b> is not a predicated operation.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>
		/// The runtime will validate that the "callee" is a bundle and that the "caller" is a direct command list. The runtime will also
		/// validate that the bundle has been closed. If the contract is violated, the runtime will silently drop the call. Validation
		/// failure will result in <c>Close</c> returning E_INVALIDARG.
		/// </para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will issue a warning in the same cases where the runtime will fail. The debug layer will issue a warning if a
		/// predicate is set when <c>ExecuteCommandList</c> is called. Also, the debug layer will issue an error if it detects that any
		/// resource reference by the command list has been destroyed.
		/// </para>
		/// <para>
		/// The debug layer will also validate that the command allocator associated with the bundle has not been reset since <c>Close</c>
		/// was called on the command list. This validation occurs at <b>ExecuteBundle</b> time, and when the parent command list is
		/// executed on a command queue.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::ExecuteBundle</b> as follows:</para>
		/// <para>
		/// <c>void D3D12Bundles::PopulateCommandList(FrameResource* pFrameResource) { // Command list allocators can only be reset when the
		/// associated // command lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a
		/// particular command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_pCurrentFrameResource-&gt;m_commandAllocator.Get(), m_pipelineState1.Get())); // Set
		/// necessary state. m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = {
		/// m_cbvSrvHeap.Get(), m_samplerHeap.Get() }; m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// m_commandList-&gt;RSSetViewports(1, &amp;m_viewport); m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate
		/// that the back buffer will be used as a render target. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;ClearDepthStencilView(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0,
		/// nullptr); if (UseBundles) { // Execute the prebuilt bundle. m_commandList-&gt;ExecuteBundle(pFrameResource-&gt;m_bundle.Get());
		/// } else { // Populate a new command list. pFrameResource-&gt;PopulateCommandList(m_commandList.Get(), m_pipelineState1.Get(),
		/// m_pipelineState2.Get(), m_currentFrameResourceIndex, m_numIndices, &amp;m_indexBufferView, &amp;m_vertexBufferView,
		/// m_cbvSrvHeap.Get(), m_cbvSrvDescriptorSize, m_samplerHeap.Get(), m_rootSignature.Get()); } // Indicate that the back buffer will
		/// now be used to present. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_RENDER_TARGET,
		/// D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-executebundle void ExecuteBundle(
		// [in] ID3D12GraphicsCommandList *pCommandList );
		[PreserveSig]
		new void ExecuteBundle([In] ID3D12GraphicsCommandList pCommandList);

		/// <summary>Changes the currently bound descriptor heaps that are associated with a command list.</summary>
		/// <param name="NumDescriptorHeaps">
		/// <para>Type: [in] <b><c>UINT</c></b></para>
		/// <para>Number of descriptor heaps to bind.</para>
		/// </param>
		/// <param name="ppDescriptorHeaps">
		/// <para>Type: [in] <b><c>ID3D12DescriptorHeap</c>*</b></para>
		/// <para>A pointer to an array of <c>ID3D12DescriptorHeap</c> objects for the heaps to set on the command list.</para>
		/// <para>You can only bind descriptor heaps of type <c><b>D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV</b></c> and <c><b>D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER</b></c>.</para>
		/// <para>
		/// Only one descriptor heap of each type can be set at one time, which means a maximum of 2 heaps (one sampler, one CBV/SRV/UAV)
		/// can be set at one time.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>SetDescriptorHeaps</b> can be called on a bundle, but the bundle descriptor heaps must match the calling command list
		/// descriptor heap. For more information on bundle restrictions, refer to <c>Creating and Recording Command Lists and Bundles</c>.
		/// </para>
		/// <para>All previously set heaps are unset by the call. At most one heap of each shader-visible type can be set in the call.</para>
		/// <para>
		/// Changing descriptor heaps can incur a pipeline flush on some hardware. Because of this, it is recommended to use a single
		/// shader-visible heap of each type, and set it once per frame, rather than regularly changing the bound descriptor heaps. Instead,
		/// use <c><b>ID3D12Device::CopyDescriptors</b></c> and <c><b>ID3D12Device::CopyDescriptorsSimple</b></c> to copy the required
		/// descriptors from shader-opaque heaps to the single shader-visible heap as required during rendering.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setdescriptorheaps void
		// SetDescriptorHeaps( UINT NumDescriptorHeaps, ID3D12DescriptorHeap * const *ppDescriptorHeaps );
		[PreserveSig]
		new void SetDescriptorHeaps(int NumDescriptorHeaps, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12DescriptorHeap[] ppDescriptorHeaps);

		/// <summary>Sets the layout of the compute root signature.</summary>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12RootSignature</c> object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootsignature void
		// SetComputeRootSignature( [in, optional] ID3D12RootSignature *pRootSignature );
		[PreserveSig]
		new void SetComputeRootSignature([In, Optional] ID3D12RootSignature? pRootSignature);

		/// <summary>Sets the layout of the graphics root signature.</summary>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12RootSignature</c> object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootsignature void
		// SetGraphicsRootSignature( [in, optional] ID3D12RootSignature *pRootSignature );
		[PreserveSig]
		new void SetGraphicsRootSignature([In, Optional] ID3D12RootSignature? pRootSignature);

		/// <summary>Sets a descriptor table into the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BaseDescriptor">
		/// <para>Type: <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A GPU_descriptor_handle object for the base descriptor to set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootdescriptortable void
		// SetComputeRootDescriptorTable( [in] UINT RootParameterIndex, [in] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor );
		[PreserveSig]
		new void SetComputeRootDescriptorTable(uint RootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor);

		/// <summary>Sets a descriptor table into the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BaseDescriptor">
		/// <para>Type: <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A GPU_descriptor_handle object for the base descriptor to set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootdescriptortable void
		// SetGraphicsRootDescriptorTable( [in] UINT RootParameterIndex, [in] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor );
		[PreserveSig]
		new void SetGraphicsRootDescriptorTable(uint RootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor);

		/// <summary>Sets a constant in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="SrcData">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The source data for the constant to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The offset, in 32-bit values, to set the constant in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputeroot32bitconstant void
		// SetComputeRoot32BitConstant( [in] UINT RootParameterIndex, [in] UINT SrcData, [in] UINT DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetComputeRoot32BitConstant(uint RootParameterIndex, uint SrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a constant in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="SrcData">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The source data for the constant to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the constant in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsroot32bitconstant void
		// SetGraphicsRoot32BitConstant( [in] UINT RootParameterIndex, [in] UINT SrcData, [in] UINT DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetGraphicsRoot32BitConstant(uint RootParameterIndex, uint SrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a group of constants in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="Num32BitValuesToSet">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of constants to set in the root signature.</para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The source data for the group of constants to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the first constant of the group in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputeroot32bitconstants void
		// SetComputeRoot32BitConstants( [in] UINT RootParameterIndex, [in] UINT Num32BitValuesToSet, [in] const void *pSrcData, [in] UINT
		// DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetComputeRoot32BitConstants(uint RootParameterIndex, uint Num32BitValuesToSet,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pSrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a group of constants in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="Num32BitValuesToSet">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of constants to set in the root signature.</para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The source data for the group of constants to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the first constant of the group in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsroot32bitconstants void
		// SetGraphicsRoot32BitConstants( [in] UINT RootParameterIndex, [in] UINT Num32BitValuesToSet, [in] const void *pSrcData, [in] UINT
		// DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetGraphicsRoot32BitConstants(uint RootParameterIndex, uint Num32BitValuesToSet,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pSrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a CPU descriptor handle for the constant buffer in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>Specifies the D3D12_GPU_VIRTUAL_ADDRESS of the constant buffer.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootconstantbufferview
		// void SetComputeRootConstantBufferView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetComputeRootConstantBufferView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the constant buffer in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the constant buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootconstantbufferview
		// void SetGraphicsRootConstantBufferView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetGraphicsRootConstantBufferView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the shader resource in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootshaderresourceview
		// void SetComputeRootShaderResourceView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetComputeRootShaderResourceView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the shader resource in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the Buffer. Textures are not supported. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootshaderresourceview
		// void SetGraphicsRootShaderResourceView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetGraphicsRootShaderResourceView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the unordered-access-view resource in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootunorderedaccessview
		// void SetComputeRootUnorderedAccessView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetComputeRootUnorderedAccessView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the unordered-access-view resource in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootunorderedaccessview
		// void SetGraphicsRootUnorderedAccessView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetGraphicsRootUnorderedAccessView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets the view for the index buffer.</summary>
		/// <param name="pView">
		/// <para>Type: <b>const <c>D3D12_INDEX_BUFFER_VIEW</c>*</b></para>
		/// <para>
		/// The view specifies the index buffer's address, size, and <c>DXGI_FORMAT</c>, as a pointer to a <c>D3D12_INDEX_BUFFER_VIEW</c> structure.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Only one index buffer can be bound to the graphics pipeline at any one time. Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::IASetIndexBuffer</b> as follows:</para>
		/// <para>
		/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1,
		/// ID3D12PipelineState* pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc,
		/// D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize,
		/// ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root
		/// signature of the caller, then // bindings are inherited, otherwise the bind space is reset.
		/// pCommandList-&gt;SetGraphicsRootSignature(pRootSignature); ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap,
		/// pSamplerDescriptorHeap }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); //
		/// Calculate the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
		/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset,
		/// cbvSrvDescriptorSize); BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt;
		/// m_cityColumnCount; j++) { // Alternate which PSO to use; the pixel shader is different on // each just as a PSO setting
		/// demonstration. pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and
		/// move to the next descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle);
		/// cbvSrvHandle.Offset(cbvSrvDescriptorSize); pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetindexbuffer void
		// IASetIndexBuffer( [in, optional] const D3D12_INDEX_BUFFER_VIEW *pView );
		[PreserveSig]
		new void IASetIndexBuffer([In, Optional] StructPointer<D3D12_INDEX_BUFFER_VIEW> pView);

		/// <summary>Sets a CPU descriptor handle for the vertex buffers.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index into the device's zero-based array to begin setting vertex buffers.</para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of views in the <i>pViews</i> array.</para>
		/// </param>
		/// <param name="pViews">
		/// <para>Type: <b>const <c>D3D12_VERTEX_BUFFER_VIEW</c>*</b></para>
		/// <para>Specifies the vertex buffer views in an array of <c>D3D12_VERTEX_BUFFER_VIEW</c> structures.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetvertexbuffers void
		// IASetVertexBuffers( [in] UINT StartSlot, [in] UINT NumViews, [in, optional] const D3D12_VERTEX_BUFFER_VIEW *pViews );
		[PreserveSig]
		new void IASetVertexBuffers(uint StartSlot, int NumViews, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_VERTEX_BUFFER_VIEW[] pViews);

		/// <summary>Sets the stream output buffer views.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index into the device's zero-based array to begin setting stream output buffers.</para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of entries in the <i>pViews</i> array.</para>
		/// </param>
		/// <param name="pViews">
		/// <para>Type: <b>const <c>D3D12_STREAM_OUTPUT_BUFFER_VIEW</c>*</b></para>
		/// <para>Specifies an array of <c>D3D12_STREAM_OUTPUT_BUFFER_VIEW</c> structures.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-sosettargets void SOSetTargets( [in]
		// UINT StartSlot, [in] UINT NumViews, [in, optional] const D3D12_STREAM_OUTPUT_BUFFER_VIEW *pViews );
		[PreserveSig]
		new void SOSetTargets(uint StartSlot, int NumViews, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_STREAM_OUTPUT_BUFFER_VIEW[] pViews);

		/// <summary>Sets CPU descriptor handles for the render targets and depth stencil.</summary>
		/// <param name="NumRenderTargetDescriptors">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of entries in the <i>pRenderTargetDescriptors</i> array (ranges between 0 and
		/// <b>D3D12_SIMULTANEOUS_RENDER_TARGET_COUNT</b>). If this parameter is nonzero, the number of entries in the array to which
		/// pRenderTargetDescriptors points must equal the number in this parameter.
		/// </para>
		/// </param>
		/// <param name="pRenderTargetDescriptors">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>
		/// Specifies an array of <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structures that describe the CPU descriptor handles that represents the
		/// start of the heap of render target descriptors. If this parameter is NULL and NumRenderTargetDescriptors is 0, no render targets
		/// are bound.
		/// </para>
		/// </param>
		/// <param name="RTsSingleHandleToDescriptorRange">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// <b>True</b> means the handle passed in is the pointer to a contiguous range of <i>NumRenderTargetDescriptors</i> descriptors.
		/// This case is useful if the set of descriptors to bind already happens to be contiguous in memory (so all that�s needed is a
		/// handle to the first one). For example, if <i>NumRenderTargetDescriptors</i> is 3 then the memory layout is taken as follows:
		/// </para>
		/// <para>In this case the driver dereferences the handle and then increments the memory being pointed to.</para>
		/// <para>
		/// <b>False</b> means that the handle is the first of an array of <i>NumRenderTargetDescriptors</i> handles. The false case allows
		/// an application to bind a set of descriptors from different locations at once. Again assuming that
		/// <i>NumRenderTargetDescriptors</i> is 3, the memory layout is taken as follows:
		/// </para>
		/// <para>In this case the driver dereferences three handles that are expected to be adjacent to each other in memory.</para>
		/// </param>
		/// <param name="pDepthStencilDescriptor">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>
		/// A pointer to a <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structure that describes the CPU descriptor handle that represents the start
		/// of the heap that holds the depth stencil descriptor. If this parameter is NULL, no depth stencil descriptor is bound.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetrendertargets void
		// OMSetRenderTargets( [in] UINT NumRenderTargetDescriptors, [in, optional] const D3D12_CPU_DESCRIPTOR_HANDLE
		// *pRenderTargetDescriptors, [in] BOOL RTsSingleHandleToDescriptorRange, [in, optional] const D3D12_CPU_DESCRIPTOR_HANDLE
		// *pDepthStencilDescriptor );
		[PreserveSig]
		new void OMSetRenderTargets(uint NumRenderTargetDescriptors,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_CPU_DESCRIPTOR_HANDLE[]? pRenderTargetDescriptors,
			bool RTsSingleHandleToDescriptorRange, [In, Optional] StructPointer<D3D12_CPU_DESCRIPTOR_HANDLE> pDepthStencilDescriptor);

		/// <summary>Clears the depth-stencil resource.</summary>
		/// <param name="DepthStencilView">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap for the depth stencil to be cleared.</para>
		/// </param>
		/// <param name="ClearFlags">
		/// <para>Type: <b><c>D3D12_CLEAR_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_CLEAR_FLAGS</c> values that are combined by using a bitwise OR operation. The resulting value
		/// identifies the type of data to clear (depth buffer, stencil buffer, or both).
		/// </para>
		/// </param>
		/// <param name="Depth">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>A value to clear the depth buffer with. This value will be clamped between 0 and 1.</para>
		/// </param>
		/// <param name="Stencil">
		/// <para>Type: <b>UINT8</b></para>
		/// <para>A value to clear the stencil buffer with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of rectangles in the array that the <i>pRects</i> parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const <b>D3D12_RECT</b>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearDepthStencilView</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Only direct and bundle command lists support this operation.</para>
		/// <para>
		/// <b>ClearDepthStencilView</b> may be used to initialize resources which alias the same heap memory. See
		/// <c>CreatePlacedResource</c> for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).</para>
		/// <para>Validation failure will result in the call to <c>Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer will issue errors if the input colors are denormalized.</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state. For
		/// <b>ClearDepthStencilView</b>, the state must be in the state <c>D3D12_RESOURCE_STATE_DEPTH_WRITE</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-cleardepthstencilview void
		// ClearDepthStencilView( [in] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, [in] D3D12_CLEAR_FLAGS ClearFlags, [in] FLOAT Depth,
		// [in] UINT8 Stencil, [in] UINT NumRects, [in] const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearDepthStencilView([In] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, D3D12_CLEAR_FLAGS ClearFlags, float Depth, byte Stencil,
			[Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[]? pRects);

		/// <summary>Sets all the elements in a render target to one value.</summary>
		/// <param name="RenderTargetView">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// Specifies a D3D12_CPU_DESCRIPTOR_HANDLE structure that describes the CPU descriptor handle that represents the start of the heap
		/// for the render target to be cleared.
		/// </para>
		/// </param>
		/// <param name="ColorRGBA">
		/// <para>Type: <b>const FLOAT[4]</b></para>
		/// <para>A 4-component array that represents the color to fill the render target with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the <i>pRects</i> parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const D3D12_RECT*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearRenderTargetView</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>ClearRenderTargetView</b> may be used to initialize resources which alias the same heap memory. See
		/// <c>CreatePlacedResource</c> for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).</para>
		/// <para>Validation failure will result in the call to <c>Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer will issue errors if the input colors are denormalized.</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state. For
		/// <b>ClearRenderTargetView</b>, the state must be <c>D3D12_RESOURCE_STATE_RENDER_TARGET</c>.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::ClearRenderTargetView</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>The <c>D3D12Multithreading</c> sample uses <b>ID3D12GraphicsCommandList::ClearRenderTargetView</b> as follows:</para>
		/// <para><c>// Frame resources. FrameResource* m_frameResources[FrameCount]; FrameResource* m_pCurrentFrameResource; int m_currentFrameResourceIndex;</c></para>
		/// <para>
		/// <c>// Assemble the CommandListPre command list. void D3D12Multithreading::BeginFrame() { m_pCurrentFrameResource-&gt;Init(); //
		/// Indicate that the back buffer will be used as a render target.
		/// m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); // Clear the render target and depth stencil. const float clearColor[] = { 0.0f, 0.0f,
		/// 0.0f, 1.0f }; CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex,
		/// m_rtvDescriptorSize); m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ClearRenderTargetView(rtvHandle,
		/// clearColor, 0, nullptr);
		/// m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ClearDepthStencilView(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart(),
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr);
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;Close()); } // Assemble the CommandListMid command
		/// list. void D3D12Multithreading::MidFrame() { // Transition our shadow map from the shadow pass to readable in the scene pass.
		/// m_pCurrentFrameResource-&gt;SwapBarriers();
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandLists[CommandListMid]-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearrendertargetview void
		// ClearRenderTargetView( [in] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView, [in] const FLOAT [4] ColorRGBA, [in] UINT NumRects,
		// [in] const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearRenderTargetView([In] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] ColorRGBA,
			[Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[]? pRects);

		/// <summary>
		/// <para>Sets all the elements in a unordered-access view (UAV) to the specified integer values.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <b>Dispatch</b> calls.
		/// To ensure ordering, barrier calls must be issued before and/or after the <b>ClearUnorderedAccessViewXxx</b> call as needed. It
		/// might appear on some drivers that such barriers aren't necessary. But implicit barriers are not a spec guarantee; so they can't
		/// be relied upon. This is in contrast to <b>ClearDepthStencilView</b> and <b>ClearRenderTargetView</b> which (like <b>DrawXxx</b>
		/// commands), respect command list ordering.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="ViewGPUHandleInCurrentHeap">
		/// <para>Type: [in] <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_GPU_DESCRIPTOR_HANDLE</c> that references an initialized descriptor for the unordered-access view (UAV) that is to be
		/// cleared. This descriptor must be in a shader-visible descriptor heap, which must be set on the command list via <c>SetDescriptorHeaps</c>.
		/// </para>
		/// </param>
		/// <param name="ViewCPUHandle">
		/// <para>Type: [in] <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> in a non-shader visible descriptor heap that references an initialized descriptor for the
		/// unordered-access view (UAV) that is to be cleared.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This descriptor must not be in a shader-visible descriptor heap. This is to allow drivers that implement the clear as a
		/// fixed-function hardware operation (rather than as a dispatch) to efficiently read from the descriptor, as shader-visible heaps
		/// may be created in <b>WRITE_BACK</b> memory (similar to <b>D3D12_HEAP_TYPE_UPLOAD</b> heap types), and CPU reads from this type
		/// of memory are prohibitively slow.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the unordered-access-view (UAV) resource to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: [in] <b>const UINT[4]</b></para>
		/// <para>A 4-component array that containing the values to fill the unordered-access-view resource with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the pRects parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: [in] <b>const <c>D3D12_RECT</c>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearUnorderedAccessViewUint</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Runtime validation</para>
		/// <para>Validation failure results in the call to <c>ID3D12GraphicsCommandList::Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues errors if the input values are outside of a normalized range.</para>
		/// <para>
		/// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state. For
		/// <b>ClearUnorderedAccessViewUint</b>, the state must be <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearunorderedaccessviewuint void
		// ClearUnorderedAccessViewUint( D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
		// ID3D12Resource *pResource, const UINT [4] Values, UINT NumRects, const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearUnorderedAccessViewUint([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
			[In] ID3D12Resource pResource, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] Values, int NumRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[] pRects);

		/// <summary>
		/// <para>Sets all of the elements in an unordered-access view (UAV) to the specified float values.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <b>Dispatch</b> calls.
		/// To ensure ordering, barrier calls must be issued before and/or after the <b>ClearUnorderedAccessViewXxx</b> call as needed. It
		/// might appear on some drivers that such barriers aren't necessary. But implicit barriers are not a spec guarantee; so they can't
		/// be relied upon. This is in contrast to <b>ClearDepthStencilView</b> and <b>ClearRenderTargetView</b> which (like <b>DrawXxx</b>
		/// commands), respect command list ordering.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="ViewGPUHandleInCurrentHeap">
		/// <para>Type: [in] <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_GPU_DESCRIPTOR_HANDLE</c> that references an initialized descriptor for the unordered-access view (UAV) that is to be
		/// cleared. This descriptor must be in a shader-visible descriptor heap, which must be set on the command list via <c>SetDescriptorHeaps</c>.
		/// </para>
		/// </param>
		/// <param name="ViewCPUHandle">
		/// <para>Type: [in] <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> in a non-shader visible descriptor heap that references an initialized descriptor for the
		/// unordered-access view (UAV) that is to be cleared.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This descriptor must not be in a shader-visible descriptor heap. This is to allow drivers that implement the clear as a
		/// fixed-function hardware operation (rather than as a dispatch) to efficiently read from the descriptor, as shader-visible heaps
		/// may be created in <b>WRITE_BACK</b> memory (similar to <b>D3D12_HEAP_TYPE_UPLOAD</b> heap types), and CPU reads from this type
		/// of memory are prohibitively slow.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the unordered-access-view (UAV) resource to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: [in] <b>const FLOAT[4]</b></para>
		/// <para>A 4-component array that containing the values to fill the unordered-access-view resource with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the pRects parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: [in] <b>const <c>D3D12_RECT</c>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearUnorderedAccessViewFloat</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Runtime validation</para>
		/// <para>For floating-point inputs, the runtime sets denormalized values to 0 (while preserving NANs).</para>
		/// <para>If you want to clear the UAV to a specific bit pattern, consider using <c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewUint</c>.</para>
		/// <para>Validation failure results in the call to <c>ID3D12GraphicsCommandList::Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues errors if the input values are outside of a normalized range.</para>
		/// <para>
		/// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state. For
		/// <b>ClearUnorderedAccessViewFloat</b>, the state must be <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearunorderedaccessviewfloat void
		// ClearUnorderedAccessViewFloat( D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
		// ID3D12Resource *pResource, const FLOAT [4] Values, UINT NumRects, const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearUnorderedAccessViewFloat([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
			[In] ID3D12Resource pResource, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] Values, int NumRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[] pRects);

		/// <summary>
		/// Indicates that the contents of a resource don't need to be preserved. The function may re-initialize resource metadata in some cases.
		/// </summary>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</para>
		/// </param>
		/// <param name="pRegion">
		/// <para>Type: [in, optional] <b>const <c>D3D12_DISCARD_REGION</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The semantics of <b>DiscardResource</b> change based on the command list type.</para>
		/// <para>For <c>D3D12_COMMAND_LIST_TYPE_DIRECT</c>, the following two rules apply:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// When a resource has the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> flag, <b>DiscardResource</b> must be called when the
		/// discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_RENDER_TARGET</c> resource barrier state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When a resource has the <c>D3D12_RESOURCE_FLAG _ALLOW_DEPTH_STENCIL</c> flag, <b>DiscardResource</b> must be called when the
		/// discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_DEPTH_WRITE</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>For <c>D3D12_COMMAND_LIST_TYPE_COMPUTE</c>, the following rule applies:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The resource must have the <c>D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS</c> flag, and <b>DiscardResource</b> must be called
		/// when the discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c> resource barrier state.
		/// </description>
		/// </item>
		/// </list>
		/// <para><b>DiscardResource</b> is not supported on command lists with either <c>D3D12_COMMAND_LIST_TYPE_BUNDLE</c> nor <b>D3D12_COMMAND_LIST_TYPE_COPY</b>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the query.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="Index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the query within the query heap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>See <c>Queries</c> for more information about D3D12 queries. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::BeginQuery</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-beginquery void BeginQuery( [in]
		// ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a running query.</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the query.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="Index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the query in the query heap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>See <c>Queries</c> for more information about D3D12 queries. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::EndQuery</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-endquery void EndQuery( [in]
		// ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query. <b>ResolveQueryData</b> works with all heap types (default, upload, and readback).</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the queries to resolve.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies the type of query, one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="StartIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies an index of the first query to resolve.</para>
		/// </param>
		/// <param name="NumQueries">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of queries to resolve.</para>
		/// </param>
		/// <param name="pDestinationBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies an <c>ID3D12Resource</c> destination buffer, which must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.</para>
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies an alignment offset into the destination buffer. Must be a multiple of 8 bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>ResolveQueryData</b> performs a batched operation that writes query data into a destination buffer. Query data is written
		/// contiguously to the destination buffer, and the parameter.
		/// </para>
		/// <para>
		/// <b>ResolveQueryData</b> turns application-opaque query data in an application-opaque query heap into adapter-agnostic values
		/// usable by your application. Resolving queries within a heap that have not been completed (so have had
		/// <c><b>ID3D12GraphicsCommandList::BeginQuery</b></c> called for them, but not <c><b>ID3D12GraphicsCommandList::EndQuery</b></c>),
		/// or that have been uninitialized, results in undefined behavior and might cause device hangs or removal. The debug layer will
		/// emit an error if it detects an application has resolved incomplete or uninitialized queries.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Resolving incomplete or uninitialized queries is undefined behavior because the driver might internally store GPUVAs or other
		/// data within unresolved queries. And so attempting to resolve these queries on uninitialized data could cause a page fault or
		/// device hang. Older versions of the debug layer didn't validate this behavior.
		/// </para>
		/// </para>
		/// <para>
		/// Binary occlusion queries write 64-bits per query. The least significant bit is either 0 (the object was entirely occluded) or 1
		/// (at least 1 sample of the object would have been drawn). The rest of the bits are 0. Occlusion queries write 64-bits per query.
		/// The value is the number of samples that passed testing. Timestamp queries write 64-bits per query, which is a tick value that
		/// must be compared to the respective command queue frequency (see <c>Timing</c>).
		/// </para>
		/// <para>
		/// Pipeline statistics queries write a <c><b>D3D12_QUERY_DATA_PIPELINE_STATISTICS</b></c> structure per query. All stream-out
		/// statistics queries write a <c><b>D3D12_QUERY_DATA_SO_STATISTICS</b></c> structure per query.
		/// </para>
		/// <para>The core runtime will validate the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><i>StartIndex</i> and <i>NumQueries</i> are within range.</description>
		/// </item>
		/// <item>
		/// <description><i>AlignedDestinationBufferOffset</i> is a multiple of 8 bytes.</description>
		/// </item>
		/// <item>
		/// <description><i>DestinationBuffer</i> is a buffer.</description>
		/// </item>
		/// <item>
		/// <description>The written data will not overflow the output buffer.</description>
		/// </item>
		/// <item>
		/// <description>The query type must be supported by the command list type.</description>
		/// </item>
		/// <item>
		/// <description>The query type must be supported by the query heap.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The debug layer will issue a warning if the destination buffer is not in the D3D12_RESOURCE_STATE_COPY_DEST state, or if any
		/// queries being resolved have not had <c><b>ID3D12GraphicsCommandList::EndQuery</b></c> called on them.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resolvequerydata void
		// ResolveQueryData( [in] ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT StartIndex, [in] UINT NumQueries, [in]
		// ID3D12Resource *pDestinationBuffer, [in] UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Sets a rendering predicate.</summary>
		/// <param name="pBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>
		/// The buffer, as an <c>ID3D12Resource</c>, which must be in the <c><b>D3D12_RESOURCE_STATE_PREDICATION</b></c> or
		/// <c><b>D3D21_RESOURCE_STATE_INDIRECT_ARGUMENT</b></c> state (both values are identical, and provided as aliases for clarity), or
		/// <b>NULL</b> to disable predication.
		/// </para>
		/// </param>
		/// <param name="AlignedBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The aligned buffer offset, as a UINT64.</para>
		/// </param>
		/// <param name="Operation">
		/// <para>Type: <b><c>D3D12_PREDICATION_OP</c></b></para>
		/// <para>Specifies a <c>D3D12_PREDICATION_OP</c>, such as D3D12_PREDICATION_OP_EQUAL_ZERO or D3D12_PREDICATION_OP_NOT_EQUAL_ZERO.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed if the
		/// resulting predicate data of the predicate is equal to the operation specified.
		/// </para>
		/// <para>
		/// Unlike Direct3D 11, in Direct3D 12 predication state is not inherited by direct command lists, and predication is always
		/// respected (there are no predication hints). All direct command lists begin with predication disabled. Bundles do inherit
		/// predication state. It is legal for the same predicate to be bound multiple times.
		/// </para>
		/// <para>
		/// Illegal API calls will result in <c>Close</c> returning an error, or <c>ID3D12CommandQueue::ExecuteCommandLists</c> dropping the
		/// command list and removing the device.
		/// </para>
		/// <para>The debug layer will issue errors whenever the runtime validation fails.</para>
		/// <para>Refer to <c>Predication</c> for more information. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::SetPredication</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setpredication void SetPredication(
		// [in, optional] ID3D12Resource *pBuffer, [in] UINT64 AlignedBufferOffset, [in] D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <param name="Metadata">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="Size">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To insert instrumentation markers at the current location within a D3D12 command list, use the <b>PIXSetMarker</b> function.�
		/// This is provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setmarker void SetMarker( UINT
		// Metadata, [in, optional] const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In, Optional] IntPtr pData, uint Size);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <param name="Metadata">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="Size">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To mark the start of an instrumentation region at the current location within a D3D12 command list, use the <b>PIXBeginEvent</b>
		/// function or <b>PIXScopedEvent</b> macro.� These are provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-beginevent void BeginEvent( UINT
		// Metadata, [in, optional] const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In, Optional] IntPtr pData, uint Size);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To mark the end of an instrumentation region at the current location within a D3D12 command list, use the <b>PIXEndEvent</b>
		/// function or <b>PIXScopedEvent</b> macro.� These are provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>Apps perform indirect draws/dispatches using the <b>ExecuteIndirect</b> method.</summary>
		/// <param name="pCommandSignature">
		/// <para>Type: <b><c>ID3D12CommandSignature</c>*</b></para>
		/// <para>
		/// Specifies a <c>ID3D12CommandSignature</c>. The data referenced by <i>pArgumentBuffer</i> will be interpreted depending on the
		/// contents of the command signature. Refer to <c>Indirect Drawing</c> for the APIs that are used to create a command signature.
		/// </para>
		/// </param>
		/// <param name="MaxCommandCount">
		/// <para>Type: <b>UINT</b></para>
		/// <para>There are two ways that command counts can be specified:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If <i>pCountBuffer</i> is not NULL, then <i>MaxCommandCount</i> specifies the maximum number of operations which will be
		/// performed. The actual number of operations to be performed are defined by the minimum of this value, and a 32-bit unsigned
		/// integer contained in <i>pCountBuffer</i> (at the byte offset specified by <i>CountBufferOffset</i>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If <i>pCountBuffer</i> is NULL, the <i>MaxCommandCount</i> specifies the exact number of operations which will be performed.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pArgumentBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies one or more <c>ID3D12Resource</c> objects, containing the command arguments.</para>
		/// </param>
		/// <param name="ArgumentBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies an offset into <i>pArgumentBuffer</i> to identify the first command argument.</para>
		/// </param>
		/// <param name="pCountBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies a pointer to a <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="CountBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 that is the offset into <i>pCountBuffer</i>, identifying the argument count.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The semantics of this API are defined with the following pseudo-code:</para>
		/// <para>Non-NULL pCountBuffer:</para>
		/// <para>
		/// <c>// Read draw count out of count buffer UINT CommandCount = pCountBuffer-&gt;ReadUINT32(CountBufferOffset); CommandCount =
		/// min(CommandCount, MaxCommandCount) // Get pointer to first Commanding argument BYTE* Arguments = pArgumentBuffer-&gt;GetBase() +
		/// ArgumentBufferOffset; for(UINT CommandIndex = 0; CommandIndex &lt; CommandCount; CommandIndex++) { // Interpret the data
		/// contained in *Arguments // according to the command signature pCommandSignature-&gt;Interpret(Arguments); Arguments +=
		/// pCommandSignature-&gt;GetByteStride(); }</c>
		/// </para>
		/// <para>NULL pCountBuffer:</para>
		/// <para>
		/// <c>// Get pointer to first Commanding argument BYTE* Arguments = pArgumentBuffer-&gt;GetBase() + ArgumentBufferOffset; for(UINT
		/// CommandIndex = 0; CommandIndex &lt; MaxCommandCount; CommandIndex++) { // Interpret the data contained in *Arguments //
		/// according to the command signature pCommandSignature-&gt;Interpret(Arguments); Arguments +=
		/// pCommandSignature-&gt;GetByteStride(); }</c>
		/// </para>
		/// <para>
		/// The debug layer will issue an error if either the count buffer or the argument buffer are not in the
		/// D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT state. The core runtime will validate:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><i>CountBufferOffset</i> and <i>ArgumentBufferOffset</i> are 4-byte aligned</description>
		/// </item>
		/// <item>
		/// <description><i>pCountBuffer</i> and <i>pArgumentBuffer</i> are buffer resources (any heap type)</description>
		/// </item>
		/// <item>
		/// <description>
		/// The offset implied by <i>MaxCommandCount</i>, <i>ArgumentBufferOffset</i>, and the drawing program stride do not exceed the
		/// bounds of <i>pArgumentBuffer</i> (similarly for count buffer)
		/// </description>
		/// </item>
		/// <item>
		/// <description>The command list is a direct command list or a compute command list (not a copy or JPEG decode command list)</description>
		/// </item>
		/// <item>
		/// <description>The root signature of the command list matches the root signature of the command signature</description>
		/// </item>
		/// </list>
		/// <para>
		/// The functionality of two APIs from earlier versions of Direct3D, <c>DrawInstancedIndirect</c> and
		/// <c>DrawIndexedInstancedIndirect</c>, are encompassed by <b>ExecuteIndirect</b>.
		/// </para>
		/// <para><c></c><c></c><c></c> Bundles</para>
		/// <para>
		/// <b>ID3D12GraphicsCommandList::ExecuteIndirect</b> is allowed inside of bundle command lists only if all of the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>CountBuffer is NULL (CPU-specified count only).</description>
		/// </item>
		/// <item>
		/// <description>
		/// The command signature contains exactly one operation. This implies that the command signature does not contain root arguments
		/// changes, nor contain VB/IB binding changes.
		/// </description>
		/// </item>
		/// </list>
		/// <para><c></c><c></c><c></c> Obtaining buffer virtual addresses</para>
		/// <para>The <c>ID3D12Resource::GetGPUVirtualAddress</c> method enables an app to retrieve the GPU virtual address of a buffer.</para>
		/// <para>
		/// Apps are free to apply byte offsets to virtual addresses before placing them in an indirect argument buffer. Note that all of
		/// the D3D12 alignment requirements for VB/IB/CB still apply to the resulting GPU virtual address.
		///  Examples The <c>D3D12ExecuteIndirect</c> sample uses <b>ID3D12GraphicsCommandList::ExecuteIndirect</b> as follows:</para>
		/// <para>
		/// <c>// Data structure to match the command signature used for ExecuteIndirect. struct IndirectCommand { D3D12_GPU_VIRTUAL_ADDRESS
		/// cbv; D3D12_DRAW_ARGUMENTS drawArguments; };</c>
		/// </para>
		/// <para>
		/// The call to <b>ExecuteIndirect</b> is near the end of this listing, below the comment "Draw the triangles that have not been culled."
		/// </para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void D3D12ExecuteIndirect::PopulateCommandLists()
		/// { // Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps
		/// should use // fences to determine GPU execution progress. ThrowIfFailed(m_computeCommandAllocators[m_frameIndex]-&gt;Reset());
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_computeCommandList-&gt;Reset(m_computeCommandAllocators[m_frameIndex].Get(), m_computeState.Get()));
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Record the compute
		/// commands that will cull triangles and prevent them from being processed by the vertex shader. if (m_enableCulling) { UINT
		/// frameDescriptorOffset = m_frameIndex * CbvSrvUavDescriptorCountPerFrame; D3D12_GPU_DESCRIPTOR_HANDLE cbvSrvUavHandle =
		/// m_cbvSrvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart();
		/// m_computeCommandList-&gt;SetComputeRootSignature(m_computeRootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = {
		/// m_cbvSrvUavHeap.Get() }; m_computeCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// m_computeCommandList-&gt;SetComputeRootDescriptorTable( SrvUavTable, CD3DX12_GPU_DESCRIPTOR_HANDLE(cbvSrvUavHandle, CbvSrvOffset
		/// + frameDescriptorOffset, m_cbvSrvUavDescriptorSize)); m_computeCommandList-&gt;SetComputeRoot32BitConstants(RootConstants, 4,
		/// reinterpret_cast&lt;void*&gt;(&amp;m_csRootConstants), 0); // Reset the UAV counter for this frame.
		/// m_computeCommandList-&gt;CopyBufferRegion(m_processedCommandBuffers[m_frameIndex].Get(), CommandBufferSizePerFrame,
		/// m_processedCommandBufferCounterReset.Get(), 0, sizeof(UINT)); D3D12_RESOURCE_BARRIER barrier =
		/// CD3DX12_RESOURCE_BARRIER::Transition(m_processedCommandBuffers[m_frameIndex].Get(), D3D12_RESOURCE_STATE_COPY_DEST,
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS); m_computeCommandList-&gt;ResourceBarrier(1, &amp;barrier);
		/// m_computeCommandList-&gt;Dispatch(static_cast&lt;UINT&gt;(ceil(TriangleCount / float(ComputeThreadBlockSize))), 1, 1); }
		/// ThrowIfFailed(m_computeCommandList-&gt;Close()); // Record the rendering commands. { // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvSrvUavHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, m_enableCulling ? &amp;m_cullingScissorRect : &amp;m_scissorRect); // Indicate that the
		/// command buffer will be used for indirect drawing // and that the back buffer will be used as a render target.
		/// D3D12_RESOURCE_BARRIER barriers[2] = { CD3DX12_RESOURCE_BARRIER::Transition( m_enableCulling ?
		/// m_processedCommandBuffers[m_frameIndex].Get() : m_commandBuffer.Get(), m_enableCulling ? D3D12_RESOURCE_STATE_UNORDERED_ACCESS :
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE, D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT), CD3DX12_RESOURCE_BARRIER::Transition(
		/// m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET) };
		/// m_commandList-&gt;ResourceBarrier(_countof(barriers), barriers); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP);
		/// m_commandList-&gt;IASetVertexBuffers(0, 1, &amp;m_vertexBufferView); if (m_enableCulling) { // Draw the triangles that have not
		/// been culled. m_commandList-&gt;ExecuteIndirect( m_commandSignature.Get(), TriangleCount,
		/// m_processedCommandBuffers[m_frameIndex].Get(), 0, m_processedCommandBuffers[m_frameIndex].Get(), CommandBufferSizePerFrame); }
		/// else { // Draw all of the triangles. m_commandList-&gt;ExecuteIndirect( m_commandSignature.Get(), TriangleCount,
		/// m_commandBuffer.Get(), CommandBufferSizePerFrame * m_frameIndex, nullptr, 0); } // Indicate that the command buffer may be used
		/// by the compute shader // and that the back buffer will now be used to present. barriers[0].Transition.StateBefore =
		/// D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT; barriers[0].Transition.StateAfter = m_enableCulling ? D3D12_RESOURCE_STATE_COPY_DEST :
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE; barriers[1].Transition.StateBefore = D3D12_RESOURCE_STATE_RENDER_TARGET;
		/// barriers[1].Transition.StateAfter = D3D12_RESOURCE_STATE_PRESENT; m_commandList-&gt;ResourceBarrier(_countof(barriers),
		/// barriers); ThrowIfFailed(m_commandList-&gt;Close()); } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-executeindirect void
		// ExecuteIndirect( [in] ID3D12CommandSignature *pCommandSignature, [in] UINT MaxCommandCount, [in] ID3D12Resource *pArgumentBuffer,
		// [in] UINT64 ArgumentBufferOffset, [in, optional] ID3D12Resource *pCountBuffer, [in] UINT64 CountBufferOffset );
		[PreserveSig]
		new void ExecuteIndirect([In] ID3D12CommandSignature pCommandSignature, uint MaxCommandCount, [In] ID3D12Resource pArgumentBuffer,
			ulong ArgumentBufferOffset, [In, Optional] ID3D12Resource? pCountBuffer, ulong CountBufferOffset);

		/// <summary>
		/// <para>Atomically copies a primary data element of type UINT from one resource to another, along with optional dependent resources.</para>
		/// <para>
		/// These 'dependent resources' are so-named because they depend upon the primary data element to locate them, typically the key
		/// element is an address, index, or other handle that refers to one or more the dependent resources indirectly.
		/// </para>
		/// <para>
		/// This function supports a primary data element of type UINT (32bit). A different version of this function,
		/// <c>AtomicCopyBufferUINT64</c>, supports a primary data element of type UINT64 (64bit).
		/// </para>
		/// </summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The resource that the UINT primary data element is copied into.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the destination resource buffer that specifies where the primary data element is copied into, in bytes. This
		/// offset combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT values.
		/// </para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The resource that the UINT primary data element is copied from. This data is typically an address, index, or other handle that
		/// shader code can use to locate the most-recent version of latency-sensitive information.
		/// </para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the source resource buffer that specifies where the primary data element is copied from, in bytes. This offset
		/// combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT values.
		/// </para>
		/// </param>
		/// <param name="Dependencies">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of dependent resources.</para>
		/// </param>
		/// <param name="ppDependentResources">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>An array of resources that contain the dependent elements of the data payload.</para>
		/// </param>
		/// <param name="pDependentSubresourceRanges">
		/// <para>Type: <b>const <c>D3D12_SUBRESOURCE_RANGE_UINT64</c>*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>
		/// An array of subresource ranges that specify the dependent elements of the data payload. These elements are completely updated
		/// before the primary data element is itself atomically copied. This ensures that the entire operation is logically atomic; that
		/// is, the primary data element never refers to an incomplete data payload.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method is typically used to update resources for which normal rendering pipeline latency can be detrimental to user
		/// experience. For example, an application can compute a view matrix from the latest user input (such as from the sensors of a
		/// head-mounted display), and use this function to update and activate this matrix in command lists already dispatched to the GPU
		/// to reduce perceived latency between input and rendering.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-atomiccopybufferuint void
		// AtomicCopyBufferUINT( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset, UINT
		// Dependencies, [in] ID3D12Resource * const *ppDependentResources, [in] const D3D12_SUBRESOURCE_RANGE_UINT64
		// *pDependentSubresourceRanges );
		[PreserveSig]
		void AtomicCopyBufferUINT([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, int Dependencies,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D12Resource[] ppDependentResources,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_RANGE_UINT64[] pDependentSubresourceRanges);

		/// <summary>
		/// <para>Atomically copies a primary data element of type UINT64 from one resource to another, along with optional dependent resources.</para>
		/// <para>
		/// These 'dependent resources' are so-named because they depend upon the primary data element to locate them, typically the key
		/// element is an address, index, or other handle that refers to one or more the dependent resources indirectly.
		/// </para>
		/// <para>
		/// This function supports a primary data element of type UINT64 (64bit). A different version of this function,
		/// <c>AtomicCopyBufferUINT</c>, supports a primary data element of type UINT (32bit).
		/// </para>
		/// </summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The resource that the UINT64 primary data element is copied into.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the destination resource buffer that specifies where the primary data element is copied into, in bytes. This
		/// offset combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT64 values.
		/// </para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The resource that the UINT64 primary data element is copied from. This data is typically an address, index, or other handle that
		/// shader code can use to locate the most-recent version of latency-sensitive information.
		/// </para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the source resource buffer that specifies where the primary data element is copied from, in bytes. This offset
		/// combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT64 values.
		/// </para>
		/// </param>
		/// <param name="Dependencies">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of dependent resources.</para>
		/// </param>
		/// <param name="ppDependentResources">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>An array of resources that contain the dependent elements of the data payload.</para>
		/// </param>
		/// <param name="pDependentSubresourceRanges">
		/// <para>Type: <b>const <c>D3D12_SUBRESOURCE_RANGE_UINT64</c>*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>
		/// An array of subresource ranges that specify the dependent elements of the data payload. These elements are completely updated
		/// before the primary data element is itself atomically copied. This ensures that the entire operation is logically atomic; that
		/// is, the primary data element never refers to an incomplete data payload.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method is typically used to update resources for which normal rendering pipeline latency can be detrimental to user
		/// experience. For example, an application can compute a view matrix from the latest user input (such as from the sensors of a
		/// head-mounted display), and use this function to update and activate this matrix in command lists already dispatched to the GPU
		/// to reduce perceived latency between input and rendering.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-atomiccopybufferuint64 void
		// AtomicCopyBufferUINT64( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset,
		// UINT Dependencies, [in] ID3D12Resource * const *ppDependentResources, [in] const D3D12_SUBRESOURCE_RANGE_UINT64
		// *pDependentSubresourceRanges );
		[PreserveSig]
		void AtomicCopyBufferUINT64([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, int Dependencies,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D12Resource[] ppDependentResources,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_RANGE_UINT64[] pDependentSubresourceRanges);

		/// <summary>This method enables you to change the depth bounds dynamically.</summary>
		/// <param name="Min">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Specifies the minimum depth bounds. The default value is 0. NaN values silently convert to 0.</para>
		/// </param>
		/// <param name="Max">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Specifies the maximum depth bounds. The default value is 1. NaN values silently convert to 0.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Depth-bounds testing allows pixels and samples to be discarded if the currently-stored depth value is outside the range
		/// specified by <i>Min</i> and <i>Max</i>, inclusive. If the currently-stored depth value of the pixel or sample is inside this
		/// range, then the depth-bounds test passes and it is rendered; otherwise, the depth-bounds test fails and the pixel or sample is
		/// discarded. Note that the depth-bounds test considers the currently-stored depth value, not the depth value generated by the
		/// executing pixel shader.
		/// </para>
		/// <para>
		/// To use depth-bounds testing, the application must use the new <c>CreatePipelineState</c> method to enable depth-bounds testing
		/// on the PSO and then can use this command list method to change the depth-bounds dynamically.
		/// </para>
		/// <para>
		/// OMSetDepthBounds is an optional feature. Use the <c>CheckFeatureSupport</c> method to determine whether or not this feature is
		/// supported by the user-mode driver. Support for this feature is reported through the <c>D3D12_FEATURE_D3D12_OPTIONS2</c> structure.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-omsetdepthbounds void
		// OMSetDepthBounds( [in] FLOAT Min, [in] FLOAT Max );
		[PreserveSig]
		void OMSetDepthBounds(float Min, float Max);

		/// <summary>This method configures the sample positions used by subsequent draw, copy, resolve, and similar operations.</summary>
		/// <param name="NumSamplesPerPixel">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Specifies the number of samples to take, per pixel. This value can be 1, 2, 4, 8, or 16, otherwise the SetSamplePosition call is
		/// dropped. The number of samples must match the sample count configured in the PSO at draw time, otherwise the behavior is undefined.
		/// </para>
		/// </param>
		/// <param name="NumPixels">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Specifies the number of pixels that sample patterns are being specified for. This value can be either 1 or 4, otherwise the
		/// SetSamplePosition call is dropped. A value of 1 configures a single sample pattern to be used for each pixel; a value of 4
		/// configures separate sample patterns for each pixel in a 2x2 pixel grid which is repeated over the render-target or viewport
		/// space, aligned to even coordinates.
		/// </para>
		/// <para>
		/// Note that the maximum number of combined samples can't exceed 16, otherwise the call is dropped. If NumPixels is set to 4,
		/// NumSamplesPerPixel can specify no more than 4 samples.
		/// </para>
		/// </param>
		/// <param name="pSamplePositions">
		/// <para>Type: <b><c>D3D12_SAMPLE_POSITION</c>*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(NumSamplesPerPixel*NumPixels)</c></para>
		/// <para>
		/// Specifies an array of D3D12_SAMPLE_POSITION elements. The size of the array is NumPixels * NumSamplesPerPixel. If NumPixels is
		/// set to 4, then the first group of sample positions corresponds to the upper-left pixel in the 2x2 grid of pixels; the next group
		/// of sample positions corresponds to the upper-right pixel, the next group to the lower-left pixel, and the final group to the
		/// lower-right pixel.
		/// </para>
		/// <para>
		/// If centroid interpolation is used during rendering, the order of positions for each pixel determines centroid-sampling priority.
		/// That is, the first covered sample in the order specified is chosen as the centroid sample location.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The operational semantics of sample positions are determined by the various draw, copy, resolve, and other operations that can occur.
		/// </para>
		/// <para>
		/// <b>CommandList:</b> In the absence of any prior calls to SetSamplePositions in a CommandList, samples assume the default
		/// position based on the Pipeline State Object (PSO). The default positions are determined either by the SAMPLE_DESC portion of the
		/// PSO if it is present, or by the standard sample positions if the RASTERIZER_DESC portion of the PSO has ForcedSampleCount set to
		/// a value greater than 0.
		/// </para>
		/// <para>
		/// After SetSamplePosition has been called, subsequent draw calls must use a PSO that specifies a matching sample count either
		/// using the SAMPLE_DESC portion of the PSO, or ForcedSampleCount in the RASTERIZER_DESC portion of the PSO.
		/// </para>
		/// <para>
		/// SetSamplePositions can only be called on a graphics CommandList. It can't be called in a bundle; bundles inherit sample position
		/// state from the calling CommandList and don't modify it.
		/// </para>
		/// <para>Calling SetSamplePositions(0, 0, NULL) reverts the sample positions to their default values.</para>
		/// <para><b>Clear RenderTarget:</b> Sample positions are ignored when clearing a render target.</para>
		/// <para>
		/// <b>Clear DepthStencil:</b> When clearing the depth portion of a depth-stencil surface or any region of it, the sample positions
		/// must be set to match those of future rendering to the cleared surface or region; the contents of any uncleared regions produced
		/// using different sample positions become undefined.
		/// </para>
		/// <para>When clearing the stencil portion of a depth-stencil surface or any region of it, the sample positions are ignored.</para>
		/// <para>
		/// <b>Draw to RenderTarget:</b> When drawing to a render target the sample positions can be changed for each draw call, even when
		/// drawing to a region that overlaps previous draw calls. The current sample positions determine the operational semantics of each
		/// draw call and samples are taken from taken from the stored contents of the render target, even if the contents were produced
		/// using different sample positions.
		/// </para>
		/// <para>
		/// <b>Draw using DepthStencil:</b> When drawing to a depth-stencil surface (read or write) or any region of it, the sample
		/// positions must be set to match those used to clear the affected region previously. To use a different sample position, the
		/// target region must be cleared first. The pixels outside the clear region are unaffected.
		/// </para>
		/// <para>
		/// Hardware may store the depth portion or a depth-stencil surface as plane equations, and evaluate them to produce depth values
		/// when the application issues a read. Only the rasterizer and output-merger are required to support programmable sample positions
		/// of the depth portion of a depth-stencil surface. Any other read or write of the depth portion that has been rendered with sample
		/// positions set may ignore them and instead sample at the standard positions.
		/// </para>
		/// <para>
		/// <b>Resolve RenderTarget:</b> When resolving a render target or any region of it, the sample positions are ignored; these APIs
		/// operate only on stored color values.
		/// </para>
		/// <para>
		/// <b>Resolve DepthStencil:</b> When resolving the depth portion of a depth-stencil surface or any region of it, the sample
		/// positions must be set to match those of past rendering to the resolved surface or region. To use a different sample position,
		/// the target region must be cleared first.
		/// </para>
		/// <para>
		/// When resolving the stencil portion of a depth-stencil surface or any region of it, the sample positions are ignored; stencil
		/// resolves operate only on stored stencil values.
		/// </para>
		/// <para>
		/// <b>Copy RenderTarget:</b> When copying from a render target, the sample positions are ignored regardless of whether it is a full
		/// or partial copy.
		/// </para>
		/// <para>
		/// <b>Copy DepthStencil (Full Subresource):</b> When copying a full subresource from a depth-stencil surface, the sample positions
		/// must be set to match the sample positions used to generate the source surface. To use a different sample position, the target
		/// region must be cleared first.
		/// </para>
		/// <para>
		/// On some hardware properties of the source surface (such as stored plane equations for depth values) transfer to the destination.
		/// Therefore, if the destination surface is subsequently drawn to, the sample positions originally used to generate the source
		/// content need to be used with the destination surface. The API requires this on all hardware for consistency even if it may only
		/// apply to some.
		/// </para>
		/// <para>
		/// <b>Copy DepthStencil (Partial Subresource):</b> When copying a partial subresource from a depth-stencil surface, the sample
		/// positions must be set to match the sample positions used to generate the source surface, similarly to copying a full
		/// subresource. However, if the content of an affected destination subresources is only partially covered by the copy, the contents
		/// of the uncovered portion within those subresources becomes undefined unless all of it was generated using the same sample
		/// positions as the copy source. To use a different sample position, the target region must be cleared first.
		/// </para>
		/// <para>
		/// When copying a partial subresource from the stencil portion of a depth-stencil surface, the sample postions are ignored. It
		/// doesn�t matter what sample positions were used to generate content for any other areas of the destination buffer not covered by
		/// the copy � those contents remain valid.
		/// </para>
		/// <para>
		/// <b>Shader SamplePos:</b> The HLSL SamplePos intrinsic is not aware of programmable sample positions and results returned to
		/// shaders calling this on a surface rendered with programmable positions is undefined. Applications must pass coordinates into
		/// their shader manually if needed. Similarly evaluating attributes by sample index is undefined with programmable sample positions.
		/// </para>
		/// <para>
		/// <b>Transitioning out of DEPTH_READ or DEPTH_WRITE state:</b> If a subresource in DEPTH_READ or DEPTH_WRITE state is transitioned
		/// to any other state, including COPY_SOURCE or RESOLVE_SOURCE, some hardware might need to decompress the surface. Therefore, the
		/// sample positions must be set on the command list to match those used to generate the content in the source surface. Furthermore,
		/// for any subsequent transitions of the surface while the same depth data remains in it, the sample positions must continue to
		/// match those set on the command list. To use a different sample position, the target region must be cleared first.
		/// </para>
		/// <para>
		/// If an application wants to minimize the decompressed area when only a portion needs to be used, or just to preserve compression,
		/// ResolveSubresourceRegion() can be called in DECOMPRESS mode with a rect specified. This will decompress just the relevant area
		/// to a separate resource leaving the source intact on some hardware, though on other hardware even the source area is
		/// decompressed. The separate explicitly decompressed resource can then be transitioned to the desired state (such as SHADER_RESOURCE).
		/// </para>
		/// <para>
		/// <b>Transitioning out of RENDER_TARGET state:</b> If a subresource in RENDER_TARGET state is transitioned to anything other than
		/// COPY_SOURCE or RESOLVE_SOURCE, some implementations may need to decompress the surface. This decompression is agnostic to sample positions.
		/// </para>
		/// <para>
		/// If an application wants to minimize the decompressed area when only a portion needs to be used, or just to preserve compression,
		/// ResolveSubresourceRegion() can be called in DECOMPRESS mode with a rect specified. This will decompress just the relevant area
		/// to a separate resource leaving the source intact on some hardware, though on other hardware even the source area is
		/// decompressed. The separate explicitly decompressed resource can then be transitioned to the desired state (such as SHADER_RESOURCE).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-setsamplepositions void
		// SetSamplePositions( [in] UINT NumSamplesPerPixel, [in] UINT NumPixels, [in] D3D12_SAMPLE_POSITION *pSamplePositions );
		[PreserveSig]
		void SetSamplePositions(uint NumSamplesPerPixel, uint NumPixels,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_SAMPLE_POSITION[] pSamplePositions);

		/// <summary>Copy a region of a multisampled or compressed resource into a non-multisampled or non-compressed resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Destination resource. Must be created with the <b>D3D11_USAGE_DEFAULT</b> flag and must be single-sampled unless its to be
		/// resolved from a compressed resource ( <b>D3D12_RESOLVE_MODE_DECOMPRESS</b>); in this case it must have the same sample count as
		/// the compressed source.
		/// </para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// A zero-based index that identifies the destination subresource. Use <c>D3D12CalcSubresource</c> to calculate the subresource
		/// index if the parent resource is complex.
		/// </para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The X coordinate of the left-most edge of the destination region. The width of the destination region is the same as the width
		/// of the source rect.
		/// </para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The Y coordinate of the top-most edge of the destination region. The height of the destination region is the same as the height
		/// of the source rect.
		/// </para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Source resource. Must be multisampled or compressed.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>A zero-based index that identifies the source subresource.</para>
		/// </param>
		/// <param name="pSrcRect">
		/// <para>Type: <b>D3D12_RECT*</b></para>
		/// <para><c>SAL</c>: <c>In_opt</c></para>
		/// <para>
		/// Specifies the rectangular region of the source resource to be resolved. Passing NULL for <i>pSrcRect</i> specifies that the
		/// entire subresource is to be resolved.
		/// </para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <b>DXGI_FORMAT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>A DXGI_FORMAT that specifies how the source and destination resource formats are consolidated.</para>
		/// </param>
		/// <param name="ResolveMode">
		/// <para>Type: <b><c>D3D12_RESOLVE_MODE</c></b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Specifies the operation used to resolve the source samples.</para>
		/// <para>
		/// When using the <b>D3D12_RESOLVE_MODE_DECOMPRESS</b> operation, the sample count can be larger than 1 as long as the source and
		/// destination have the same sample count, and source and destination may specify the same resource as long as the source rect
		/// aligns with the destination X and Y coordinates, in which case decompression occurs in place.
		/// </para>
		/// <para>
		/// When using the <b>D3D12_RESOLVE_MODE_MIN</b>, <b>D3D12_RESOLVE_MODE_MAX</b>, or <b>D3D12_RESOLVE_MODE_AVERAGE</b> operation, the
		/// destination must have a sample count of 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// ResolveSubresourceRegion operates like <c>ResolveSubresource</c> but allows for only part of a resource to be resolved and for
		/// source samples to be resolved in several ways. Partial resolves can be useful in multi-adapter scenarios; for example, when the
		/// rendered area has been partitioned across adapters, each adapter might only need to resolve the portion of a subresource that
		/// corresponds to its assigned partition.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-resolvesubresourceregion void
		// ResolveSubresourceRegion( [in] ID3D12Resource *pDstResource, [in] UINT DstSubresource, [in] UINT DstX, [in] UINT DstY, [in]
		// ID3D12Resource *pSrcResource, [in] UINT SrcSubresource, [in, optional] D3D12_RECT *pSrcRect, [in] DXGI_FORMAT Format, [in]
		// D3D12_RESOLVE_MODE ResolveMode );
		[PreserveSig]
		void ResolveSubresourceRegion([In] ID3D12Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, [In] ID3D12Resource pSrcResource,
			uint SrcSubresource, [In, Optional] PRECT? pSrcRect, DXGI_FORMAT Format, D3D12_RESOLVE_MODE ResolveMode);

		/// <summary>Set a mask that controls which view instances are enabled for subsequent draws.</summary>
		/// <param name="Mask">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// A mask that specifies which views are enabled or disabled. If bit <i>i</i> starting from the least-significant bit is set, view
		/// instance <i>i</i> is enabled.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The view instance mask only affects PSOs that declare view instance masking by specifying the
		/// D3D12_VIEW_INSTANCING_FLAG_ENABLE_VIEW_INSTANCE_MASKING flag during their creation. Attempting to create a PSO that declares
		/// view instance masking will fail on adapters that don't support view instancing.
		/// </para>
		/// <para>
		/// The view instance mask defaults to 0 which disables all views. This forces applications that declare view instance masking to
		/// explicitly choose the views to enable, otherwise nothing will be rendered. If the view instance mask enabled all views by
		/// default the application might not remember to disable unused views, resulting in lost performance due to wasted work.
		/// </para>
		/// <para>
		/// Bundles don't inherit their view instance mask from their caller, defaulting to 0 instead. This is because the mask setting must
		/// be known when the bundle is recorded if it affects how an implementation records draws. The view instance mask set by a bundle
		/// does persist to the caller after the bundle completes, however. These inheritance semantics are similar to those of PSOs.
		/// </para>
		/// <para>
		/// No shader code paths that are dependent on SV_ViewID are executed at any shader stage for view instances that are masked off and
		/// no clipping, viewport processing, or rasterization is performed. Implementations that inspect the mask during rendering can
		/// incur a small performance penalty over PSOs that don't declare view instance masking at all, but usually the penalty can be
		/// overcome by the performance savings that result from skipping the work associated with the masked off views. Depending on the
		/// frequency and amount of skipped work, the performance gains can be significant.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-setviewinstancemask void
		// SetViewInstanceMask( [in] UINT Mask );
		[PreserveSig]
		void SetViewInstanceMask(uint Mask);
	}

	/// <summary>
	/// <para>
	/// Encapsulates a list of graphics commands for rendering, extending the interface to support writing immediate values directly to a buffer.
	/// </para>
	/// <para>
	/// <b>Note</b>��This interface was introduced in the Windows 10 Fall Creators Update, and as such is the latest version of the
	/// <b>ID3D12GraphicsCommandList</b> interface. Applications targeting the Windows 10 Fall Creators Update and later should use this
	/// interface instead of <c>ID3D12GraphicsCommandList1</c> or <c>ID3D12GraphicsCommandList</c>.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12graphicscommandlist2
	[PInvokeData("d3d12.h", MSDNShortId = "NN:d3d12.ID3D12GraphicsCommandList2")]
	[ComImport, Guid("38c3e585-ff17-412c-9150-4fc6f9d72a28"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12GraphicsCommandList2 : ID3D12GraphicsCommandList1
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
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::Close</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::LoadAssets() { // Create an empty root signature. { CD3DX12_ROOT_SIGNATURE_DESC rootSignatureDesc;
		/// rootSignatureDesc.Init(0, nullptr, 0, nullptr, D3D12_ROOT_SIGNATURE_FLAG_ALLOW_INPUT_ASSEMBLER_INPUT_LAYOUT);
		/// ComPtr&lt;ID3DBlob&gt; signature; ComPtr&lt;ID3DBlob&gt; error;
		/// ThrowIfFailed(D3D12SerializeRootSignature(&amp;rootSignatureDesc, D3D_ROOT_SIGNATURE_VERSION_1, &amp;signature, &amp;error));
		/// ThrowIfFailed(m_device-&gt;CreateRootSignature(0, signature-&gt;GetBufferPointer(), signature-&gt;GetBufferSize(),
		/// IID_PPV_ARGS(&amp;m_rootSignature))); } // Create the pipeline state, which includes compiling and loading shaders. {
		/// ComPtr&lt;ID3DBlob&gt; vertexShader; ComPtr&lt;ID3DBlob&gt; pixelShader; #if defined(_DEBUG) // Enable better shader debugging
		/// with the graphics debugging tools. UINT compileFlags = D3DCOMPILE_DEBUG | D3DCOMPILE_SKIP_OPTIMIZATION; #else UINT compileFlags
		/// = 0; #endif ThrowIfFailed(D3DCompileFromFile(GetAssetFullPath(L"shaders.hlsl").c_str(), nullptr, nullptr, "VSMain", "vs_5_0",
		/// compileFlags, 0, &amp;vertexShader, nullptr)); ThrowIfFailed(D3DCompileFromFile(GetAssetFullPath(L"shaders.hlsl").c_str(),
		/// nullptr, nullptr, "PSMain", "ps_5_0", compileFlags, 0, &amp;pixelShader, nullptr)); // Define the vertex input layout.
		/// D3D12_INPUT_ELEMENT_DESC inputElementDescs[] = { { "POSITION", 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0,
		/// D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, 0 }, { "COLOR", 0, DXGI_FORMAT_R32G32B32A32_FLOAT, 0, 12,
		/// D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, 0 } }; // Describe and create the graphics pipeline state object (PSO).
		/// D3D12_GRAPHICS_PIPELINE_STATE_DESC psoDesc = {}; psoDesc.InputLayout = { inputElementDescs, _countof(inputElementDescs) };
		/// psoDesc.pRootSignature = m_rootSignature.Get(); psoDesc.VS = {
		/// reinterpret_cast&lt;UINT8*&gt;(vertexShader-&gt;GetBufferPointer()), vertexShader-&gt;GetBufferSize() }; psoDesc.PS = {
		/// reinterpret_cast&lt;UINT8*&gt;(pixelShader-&gt;GetBufferPointer()), pixelShader-&gt;GetBufferSize() }; psoDesc.RasterizerState =
		/// CD3DX12_RASTERIZER_DESC(D3D12_DEFAULT); psoDesc.BlendState = CD3DX12_BLEND_DESC(D3D12_DEFAULT);
		/// psoDesc.DepthStencilState.DepthEnable = FALSE; psoDesc.DepthStencilState.StencilEnable = FALSE; psoDesc.SampleMask = UINT_MAX;
		/// psoDesc.PrimitiveTopologyType = D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE; psoDesc.NumRenderTargets = 1; psoDesc.RTVFormats[0] =
		/// DXGI_FORMAT_R8G8B8A8_UNORM; psoDesc.SampleDesc.Count = 1; ThrowIfFailed(m_device-&gt;CreateGraphicsPipelineState(&amp;psoDesc,
		/// IID_PPV_ARGS(&amp;m_pipelineState))); } // Create the command list. ThrowIfFailed(m_device-&gt;CreateCommandList(0,
		/// D3D12_COMMAND_LIST_TYPE_DIRECT, m_commandAllocator.Get(), m_pipelineState.Get(), IID_PPV_ARGS(&amp;m_commandList))); // Command
		/// lists are created in the recording state, but there is nothing // to record yet. The main loop expects it to be closed, so close
		/// it now. ThrowIfFailed(m_commandList-&gt;Close()); // Create the vertex buffer. { // Define the geometry for a triangle. Vertex
		/// triangleVertices[] = { { { 0.0f, 0.25f * m_aspectRatio, 0.0f }, { 1.0f, 0.0f, 0.0f, 1.0f } }, { { 0.25f, -0.25f * m_aspectRatio,
		/// 0.0f }, { 0.0f, 1.0f, 0.0f, 1.0f } }, { { -0.25f, -0.25f * m_aspectRatio, 0.0f }, { 0.0f, 0.0f, 1.0f, 1.0f } } }; const UINT
		/// vertexBufferSize = sizeof(triangleVertices); // Note: using upload heaps to transfer static data like vert buffers is not //
		/// recommended. Every time the GPU needs it, the upload heap will be marshalled // over. Please read up on Default Heap usage. An
		/// upload heap is used here for // code simplicity and because there are very few verts to actually transfer.
		/// ThrowIfFailed(m_device-&gt;CreateCommittedResource( &amp;CD3DX12_HEAP_PROPERTIES(D3D12_HEAP_TYPE_UPLOAD), D3D12_HEAP_FLAG_NONE,
		/// &amp;D3D12_RESOURCE_DESC::Buffer(vertexBufferSize), D3D12_RESOURCE_STATE_GENERIC_READ, nullptr,
		/// IID_PPV_ARGS(&amp;m_vertexBuffer))); // Copy the triangle data to the vertex buffer. UINT8* pVertexDataBegin; CD3DX12_RANGE
		/// readRange(0, 0); // We do not intend to read from this resource on the CPU. ThrowIfFailed(m_vertexBuffer-&gt;Map(0,
		/// &amp;readRange, reinterpret_cast&lt;void**&gt;(&amp;pVertexDataBegin))); memcpy(pVertexDataBegin, triangleVertices,
		/// sizeof(triangleVertices)); m_vertexBuffer-&gt;Unmap(0, nullptr); // Initialize the vertex buffer view.
		/// m_vertexBufferView.BufferLocation = m_vertexBuffer-&gt;GetGPUVirtualAddress(); m_vertexBufferView.StrideInBytes =
		/// sizeof(Vertex); m_vertexBufferView.SizeInBytes = vertexBufferSize; } // Create synchronization objects and wait until assets
		/// have been uploaded to the GPU. { ThrowIfFailed(m_device-&gt;CreateFence(0, D3D12_FENCE_FLAG_NONE, IID_PPV_ARGS(&amp;m_fence)));
		/// m_fenceValue = 1; // Create an event handle to use for frame synchronization. m_fenceEvent = CreateEvent(nullptr, FALSE, FALSE,
		/// nullptr); if (m_fenceEvent == nullptr) { ThrowIfFailed(HRESULT_FROM_WIN32(GetLastError())); } // Wait for the command list to
		/// execute; we are reusing the same command // list in our main loop but for now, we just want to wait for setup to // complete
		/// before continuing. WaitForPreviousFrame(); } }</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-close HRESULT Close();
		[PreserveSig]
		new HRESULT Close();

		/// <summary>Resets a command list back to its initial state as if a new command list was just created.</summary>
		/// <param name="pAllocator">
		/// <para>Type: <b>ID3D12CommandAllocator*</b></para>
		/// <para>A pointer to the <c>ID3D12CommandAllocator</c> object that the device creates command lists from.</para>
		/// </param>
		/// <param name="pInitialState">
		/// <para>Type: <b>ID3D12PipelineState*</b></para>
		/// <para>
		/// A pointer to the <c>ID3D12PipelineState</c> object that contains the initial pipeline state for the command list. This is
		/// optional and can be NULL. If NULL, the runtime sets a dummy initial pipeline state so that drivers don't have to deal with
		/// undefined state. The overhead for this is low, particularly for a command list, for which the overall cost of recording the
		/// command list likely dwarfs the cost of one initial state setting. So there is little cost in not setting the initial pipeline
		/// state parameter if it isn't convenient.
		/// </para>
		/// <para>
		/// For bundles on the other hand, it might make more sense to try to set the initial state parameter since bundles are likely
		/// smaller overall and can be reused frequently.
		/// </para>
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
		/// <remarks>
		/// <para>
		/// By using <b>Reset</b>, you can re-use command list tracking structures without any allocations. Unlike
		/// <c>ID3D12CommandAllocator::Reset</c>, you can call <b>Reset</b> while the command list is still being executed.
		/// </para>
		/// <para>You can use <b>Reset</b> for both direct command lists and bundles.</para>
		/// <para>
		/// The command allocator passed to <b>Reset</b> cannot be associated with any other currently-recording command list. The allocator
		/// type, direct command list or bundle, must match the type of command list that is being created.
		/// </para>
		/// <para>
		/// If a bundle doesn't specify a resource heap, it can't make changes to which descriptor tables are bound. Either way, bundles
		/// can't change the resource heap within the bundle. If a heap is specified for a bundle, the heap must match the calling 'parent'
		/// command list�s heap.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>
		/// Before an app calls <b>Reset</b>, the command list must be in the "closed" state. <b>Reset</b> will fail if the command list
		/// isn't in the "closed" state.
		/// </para>
		/// <para>
		/// <b>Note</b>��If a call to <c>ID3D12GraphicsCommandList::Close</c> fails, the command list can never be reset. Calling
		/// <b>Reset</b> will result in the same error being returned that <b>ID3D12GraphicsCommandList::Close</b> returned.
		/// </para>
		/// <para></para>
		/// <para>
		/// After <b>Reset</b> succeeds, the command list is left in the "recording" state. <b>Reset</b> will fail if it would cause the
		/// maximum concurrently recording command list limit, which is specified at device creation, to be exceeded.
		/// </para>
		/// <para>
		/// Apps must specify a command list allocator. The runtime will ensure that an allocator is never associated with more than one
		/// recording command list at the same time.
		/// </para>
		/// <para><b>Reset</b> fails for bundles that are referenced by a not yet submitted command list.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will also track graphics processing unit (GPU) progress and issue an error if it can't prove that there are no
		/// outstanding executions of the command list.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::Reset</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-reset HRESULT Reset( [in]
		// ID3D12CommandAllocator *pAllocator, [in, optional] ID3D12PipelineState *pInitialState );
		[PreserveSig]
		new HRESULT Reset([In] ID3D12CommandAllocator pAllocator, [In, Optional] ID3D12PipelineState? pInitialState);

		/// <summary>Resets the state of a direct command list back to the state it was in when the command list was created.</summary>
		/// <param name="pPipelineState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12PipelineState</c> object that contains the initial pipeline state for the command list.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// It is invalid to call <b>ClearState</b> on a bundle. If an app calls <b>ClearState</b> on a bundle, the call to <c>Close</c>
		/// will return <b>E_FAIL</b>.
		/// </para>
		/// <para>
		/// When <b>ClearState</b> is called, all currently bound resources are unbound. The primitive topology is set to
		/// <c>D3D_PRIMITIVE_TOPOLOGY_UNDEFINED</c>. Viewports, scissor rectangles, stencil reference value, and the blend factor are set to
		/// empty values (all zeros). Predication is disabled.
		/// </para>
		/// <para>The app-provided pipeline state object becomes bound as the currently set pipeline state object.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearstate void ClearState( [in,
		// optional] ID3D12PipelineState *pPipelineState );
		[PreserveSig]
		new void ClearState([In, Optional] ID3D12PipelineState? pPipelineState);

		/// <summary>Draws non-indexed, instanced primitives.</summary>
		/// <param name="VertexCountPerInstance">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Index of the first vertex.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors.
		/// </para>
		/// <para>
		/// The vertex data for an instanced draw call typically comes from a vertex buffer that is bound to the pipeline. But, you could
		/// also provide the vertex data from a shader that has instanced data identified with a system-value semantic (SV_InstanceID).
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::DrawInstanced</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-drawinstanced void DrawInstanced(
		// [in] UINT VertexCountPerInstance, [in] UINT InstanceCount, [in] UINT StartVertexLocation, [in] UINT StartInstanceLocation );
		[PreserveSig]
		new void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		/// <summary>Draws indexed, instanced primitives.</summary>
		/// <param name="IndexCountPerInstance">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of indices read from the index buffer for each instance.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <b><c>INT</c></b></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing might extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors. Instancing requires multiple vertex buffers: at least one
		/// for per-vertex data and a second buffer for per-instance data.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::DrawIndexedInstanced</b> as follows:</para>
		/// <para>
		/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1,
		/// ID3D12PipelineState* pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc,
		/// D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize,
		/// ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root
		/// signature of the caller, then // bindings are inherited, otherwise the bind space is reset.
		/// pCommandList-&gt;SetGraphicsRootSignature(pRootSignature); ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap,
		/// pSamplerDescriptorHeap }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); //
		/// Calculate the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
		/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset,
		/// cbvSrvDescriptorSize); BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt;
		/// m_cityColumnCount; j++) { // Alternate which PSO to use; the pixel shader is different on // each just as a PSO setting
		/// demonstration. pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and
		/// move to the next descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle);
		/// cbvSrvHandle.Offset(cbvSrvDescriptorSize); pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-drawindexedinstanced void
		// DrawIndexedInstanced( [in] UINT IndexCountPerInstance, [in] UINT InstanceCount, [in] UINT StartIndexLocation, [in] INT
		// BaseVertexLocation, [in] UINT StartInstanceLocation );
		[PreserveSig]
		new void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		/// <summary>Executes a command list from a thread group.</summary>
		/// <param name="ThreadGroupCountX">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the x direction. <i>ThreadGroupCountX</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountY">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the y direction. <i>ThreadGroupCountY</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountZ">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The number of groups dispatched in the z direction. <i>ThreadGroupCountZ</i> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535). In feature level 10 the value for <i>ThreadGroupCountZ</i> must be 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You call the <b>Dispatch</b> method to execute commands in a compute shader. A compute shader can be run on many threads in
		/// parallel, within a thread group. Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
		///  Examples The <c>D3D12nBodyGravity</c> sample uses <b>ID3D12GraphicsCommandList::Dispatch</b> as follows:</para>
		/// <para>
		/// <c>// Run the particle simulation using the compute shader. void D3D12nBodyGravity::Simulate(UINT threadIndex) {
		/// ID3D12GraphicsCommandList* pCommandList = m_computeCommandList[threadIndex].Get(); UINT srvIndex; UINT uavIndex; ID3D12Resource
		/// *pUavResource; if (m_srvIndex[threadIndex] == 0) { srvIndex = SrvParticlePosVelo0; uavIndex = UavParticlePosVelo1; pUavResource
		/// = m_particleBuffer1[threadIndex].Get(); } else { srvIndex = SrvParticlePosVelo1; uavIndex = UavParticlePosVelo0; pUavResource =
		/// m_particleBuffer0[threadIndex].Get(); } pCommandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(pUavResource, D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE,
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS)); pCommandList-&gt;SetPipelineState(m_computeState.Get());
		/// pCommandList-&gt;SetComputeRootSignature(m_computeRootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_srvUavHeap.Get()
		/// }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// srvHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), srvIndex + threadIndex, m_srvUavDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE uavHandle(m_srvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart(), uavIndex + threadIndex,
		/// m_srvUavDescriptorSize); pCommandList-&gt;SetComputeRootConstantBufferView(RootParameterCB,
		/// m_constantBufferCS-&gt;GetGPUVirtualAddress()); pCommandList-&gt;SetComputeRootDescriptorTable(RootParameterSRV, srvHandle);
		/// pCommandList-&gt;SetComputeRootDescriptorTable(RootParameterUAV, uavHandle);
		/// pCommandList-&gt;Dispatch(static_cast&lt;int&gt;(ceil(ParticleCount / 128.0f)), 1, 1); pCommandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(pUavResource, D3D12_RESOURCE_STATE_UNORDERED_ACCESS,
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE)); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-dispatch void Dispatch( [in] UINT
		// ThreadGroupCountX, [in] UINT ThreadGroupCountY, [in] UINT ThreadGroupCountZ );
		[PreserveSig]
		new void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		/// <summary>Copies a region of a buffer from one resource to another.</summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies the destination <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 offset (in bytes) into the destination resource.</para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies the source <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 offset (in bytes) into the source resource, to start the copy from.</para>
		/// </param>
		/// <param name="NumBytes">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies the number of bytes to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Consider using the <c>CopyResource</c> method when copying an entire resource, and use this method for copying regions of a resource.
		/// </para>
		/// <para>
		/// <b>CopyBufferRegion</b> may be used to initialize resources which alias the same heap memory. See <c>CreatePlacedResource</c>
		/// for more details.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::CopyBufferRegion</b> as follows:</para>
		/// <para>
		/// <c>inline UINT64 UpdateSubresources( _In_ ID3D12GraphicsCommandList* pCmdList, _In_ ID3D12Resource* pDestinationResource, _In_
		/// ID3D12Resource* pIntermediate, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources, UINT64 RequiredSize, _In_reads_(NumSubresources)
		/// const D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayouts, _In_reads_(NumSubresources) const UINT* pNumRows,
		/// _In_reads_(NumSubresources) const UINT64* pRowSizesInBytes, _In_reads_(NumSubresources) const D3D12_SUBRESOURCE_DATA* pSrcData)
		/// { // Minor validation D3D12_RESOURCE_DESC IntermediateDesc = pIntermediate-&gt;GetDesc(); D3D12_RESOURCE_DESC DestinationDesc =
		/// pDestinationResource-&gt;GetDesc(); if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER || IntermediateDesc.Width
		/// &lt; RequiredSize + pLayouts[0].Offset || RequiredSize &gt; (SIZE_T)-1 || (DestinationDesc.Dimension ==
		/// D3D12_RESOURCE_DIMENSION_BUFFER &amp;&amp; (FirstSubresource != 0 || NumSubresources != 1))) { return 0; } BYTE* pData; HRESULT
		/// hr = pIntermediate-&gt;Map(0, NULL, reinterpret_cast&lt;void**&gt;(&amp;pData)); if (FAILED(hr)) { return 0; } for (UINT i = 0;
		/// i &lt; NumSubresources; ++i) { if (pRowSizesInBytes[i] &gt; (SIZE_T)-1) return 0; D3D12_MEMCPY_DEST DestData = { pData +
		/// pLayouts[i].Offset, pLayouts[i].Footprint.RowPitch, pLayouts[i].Footprint.RowPitch * pNumRows[i] };
		/// MemcpySubresource(&amp;DestData, &amp;pSrcData[i], (SIZE_T)pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth); }
		/// pIntermediate-&gt;Unmap(0, NULL); if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION_BUFFER) { CD3DX12_BOX SrcBox( UINT(
		/// pLayouts[0].Offset ), UINT( pLayouts[0].Offset + pLayouts[0].Footprint.Width ) ); pCmdList-&gt;CopyBufferRegion(
		/// pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width); } else { for (UINT i = 0; i &lt;
		/// NumSubresources; ++i) { CD3DX12_TEXTURE_COPY_LOCATION Dst(pDestinationResource, i + FirstSubresource);
		/// CD3DX12_TEXTURE_COPY_LOCATION Src(pIntermediate, pLayouts[i]); pCmdList-&gt;CopyTextureRegion(&amp;Dst, 0, 0, 0, &amp;Src,
		/// nullptr); } } return RequiredSize; }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copybufferregion void
		// CopyBufferRegion( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset, UINT64
		// NumBytes );
		[PreserveSig]
		new void CopyBufferRegion([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, ulong NumBytes);

		/// <summary>
		/// This method uses the GPU to copy texture data between two locations. Both the source and the destination may reference texture
		/// data located within either a buffer resource or a texture resource.
		/// </summary>
		/// <param name="pDst">
		/// <para>Type: <b>const <c>D3D12_TEXTURE_COPY_LOCATION</c>*</b></para>
		/// <para>
		/// Specifies the destination <c>D3D12_TEXTURE_COPY_LOCATION</c>. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COPY_DEST state.
		/// </para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The x-coordinate of the upper left corner of the destination region.</para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The y-coordinate of the upper left corner of the destination region. For a 1D subresource, this must be zero.</para>
		/// </param>
		/// <param name="DstZ">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The z-coordinate of the upper left corner of the destination region. For a 1D or 2D subresource, this must be zero.</para>
		/// </param>
		/// <param name="pSrc">
		/// <para>Type: <b>const <c>D3D12_TEXTURE_COPY_LOCATION</c>*</b></para>
		/// <para>
		/// Specifies the source <c>D3D12_TEXTURE_COPY_LOCATION</c>. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COPY_SOURCE state.
		/// </para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <b>const <c>D3D12_BOX</c>*</b></para>
		/// <para>Specifies an optional D3D12_BOX that sets the size of the source texture to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source box must be within the size of the source resource. The destination offsets, (x, y, and z), allow the source box to
		/// be offset when writing into the destination resource; however, the dimensions of the source box and the offsets must be within
		/// the size of the resource. If you try and copy outside the destination resource or specify a source box that is larger than the
		/// source resource, the behavior of <b>CopyTextureRegion</b> is undefined. If you created a device that supports the <c>debug
		/// layer</c>, the debug output reports an error on this invalid <b>CopyTextureRegion</b> call. Invalid parameters to
		/// <b>CopyTextureRegion</b> cause undefined behavior and might result in incorrect rendering, clipping, no copy, or even the
		/// removal of the rendering device.
		/// </para>
		/// <para>If the resources are buffers, all coordinates are in bytes; if the resources are textures, all coordinates are in texels.</para>
		/// <para>
		/// <b>CopyTextureRegion</b> performs the copy on the GPU (similar to a <c>memcpy</c> by the CPU). As a consequence, the source and
		/// destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different subresources (although they can be from the same resource).</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible <c>DXGI_FORMAT</c> s (identical or from the same type group). For example, a DXGI_FORMAT_R32G32B32_FLOAT
		/// texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in the
		/// DXGI_FORMAT_R32G32B32_TYPELESS group. <b>CopyTextureRegion</b> can copy between a few format types. For more info, see <c>Format
		/// Conversion using Direct3D 10.1</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <b>CopyTextureRegion</b> only supports copy; it does not support any stretch, color key, or blend. <b>CopyTextureRegion</b> can
		/// reinterpret the resource data between a few format types.
		/// </para>
		/// <para>Note that for a depth-stencil buffer, the depth and stencil planes are <c>separate subresources</c> within the buffer.</para>
		/// <para>To copy an entire resource, rather than just a region of a subresource, we recommend to use <c>CopyResource</c> instead.</para>
		/// <para>
		/// <b>Note</b>��If you use <b>CopyTextureRegion</b> with a depth-stencil buffer or a multisampled resource, you must copy the
		/// entire subresource rectangle. In this situation, you must pass 0 to the <i>DstX</i>, <i>DstY</i>, and <i>DstZ</i> parameters and
		/// <b>NULL</b> to the <i>pSrcBox</i> parameter. In addition, source and destination resources, which are represented by the
		/// <i>pSrcResource</i> and <i>pDstResource</i> parameters, should have identical sample count values.
		/// </para>
		/// <para></para>
		/// <para>
		/// <b>CopyTextureRegion</b> may be used to initialize resources which alias the same heap memory. See <c>CreatePlacedResource</c>
		/// for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Example</para>
		/// <para>
		/// The following code snippet copies the box (located at (120,100),(200,220)) from a source texture into the region
		/// (10,20),(90,140) in a destination texture.
		/// </para>
		/// <para>
		/// <c>D3D12_BOX sourceRegion; sourceRegion.left = 120; sourceRegion.top = 100; sourceRegion.right = 200; sourceRegion.bottom = 220;
		/// sourceRegion.front = 0; sourceRegion.back = 1; pCmdList -&gt; CopyTextureRegion(pDestTexture, 10, 20, 0, pSourceTexture, &amp;sourceRegion);</c>
		/// </para>
		/// <para>Notice, that for a 2D texture, front and back are set to 0 and 1 respectively. Examples The <b>HelloTriangle</b> sample uses <b>ID3D12GraphicsCommandList::CopyTextureRegion</b> as follows:</para>
		/// <para>
		/// <c>inline UINT64 UpdateSubresources( _In_ ID3D12GraphicsCommandList* pCmdList, _In_ ID3D12Resource* pDestinationResource, _In_
		/// ID3D12Resource* pIntermediate, _In_range_(0,D3D12_REQ_SUBRESOURCES) UINT FirstSubresource,
		/// _In_range_(0,D3D12_REQ_SUBRESOURCES-FirstSubresource) UINT NumSubresources, UINT64 RequiredSize, _In_reads_(NumSubresources)
		/// const D3D12_PLACED_SUBRESOURCE_FOOTPRINT* pLayouts, _In_reads_(NumSubresources) const UINT* pNumRows,
		/// _In_reads_(NumSubresources) const UINT64* pRowSizesInBytes, _In_reads_(NumSubresources) const D3D12_SUBRESOURCE_DATA* pSrcData)
		/// { // Minor validation D3D12_RESOURCE_DESC IntermediateDesc = pIntermediate-&gt;GetDesc(); D3D12_RESOURCE_DESC DestinationDesc =
		/// pDestinationResource-&gt;GetDesc(); if (IntermediateDesc.Dimension != D3D12_RESOURCE_DIMENSION_BUFFER || IntermediateDesc.Width
		/// &lt; RequiredSize + pLayouts[0].Offset || RequiredSize &gt; (SIZE_T)-1 || (DestinationDesc.Dimension ==
		/// D3D12_RESOURCE_DIMENSION_BUFFER &amp;&amp; (FirstSubresource != 0 || NumSubresources != 1))) { return 0; } BYTE* pData; HRESULT
		/// hr = pIntermediate-&gt;Map(0, NULL, reinterpret_cast&lt;void**&gt;(&amp;pData)); if (FAILED(hr)) { return 0; } for (UINT i = 0;
		/// i &lt; NumSubresources; ++i) { if (pRowSizesInBytes[i] &gt; (SIZE_T)-1) return 0; D3D12_MEMCPY_DEST DestData = { pData +
		/// pLayouts[i].Offset, pLayouts[i].Footprint.RowPitch, pLayouts[i].Footprint.RowPitch * pNumRows[i] };
		/// MemcpySubresource(&amp;DestData, &amp;pSrcData[i], (SIZE_T)pRowSizesInBytes[i], pNumRows[i], pLayouts[i].Footprint.Depth); }
		/// pIntermediate-&gt;Unmap(0, NULL); if (DestinationDesc.Dimension == D3D12_RESOURCE_DIMENSION_BUFFER) { CD3DX12_BOX SrcBox( UINT(
		/// pLayouts[0].Offset ), UINT( pLayouts[0].Offset + pLayouts[0].Footprint.Width ) ); pCmdList-&gt;CopyBufferRegion(
		/// pDestinationResource, 0, pIntermediate, pLayouts[0].Offset, pLayouts[0].Footprint.Width); } else { for (UINT i = 0; i &lt;
		/// NumSubresources; ++i) { CD3DX12_TEXTURE_COPY_LOCATION Dst(pDestinationResource, i + FirstSubresource);
		/// CD3DX12_TEXTURE_COPY_LOCATION Src(pIntermediate, pLayouts[i]); pCmdList-&gt;CopyTextureRegion(&amp;Dst, 0, 0, 0, &amp;Src,
		/// nullptr); } } return RequiredSize; }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copytextureregion void
		// CopyTextureRegion( [in] const D3D12_TEXTURE_COPY_LOCATION *pDst, UINT DstX, UINT DstY, UINT DstZ, [in] const
		// D3D12_TEXTURE_COPY_LOCATION *pSrc, [in, optional] const D3D12_BOX *pSrcBox );
		[PreserveSig]
		new void CopyTextureRegion(in D3D12_TEXTURE_COPY_LOCATION pDst, uint DstX, uint DstY, uint DstZ, in D3D12_TEXTURE_COPY_LOCATION pSrc,
			[In, Optional] StructPointer<D3D12_BOX> pSrcBox);

		/// <summary>Copies the entire contents of the source resource to the destination resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the destination resource.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the source resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>CopyResource</b> operations are performed on the GPU, and do not incur a significant CPU workload linearly dependent on the
		/// size of the data to copy.
		/// </para>
		/// <para>
		/// <b>CopyResource</b> can be used to initialize resources that alias the same heap memory. See <c>CreatePlacedResource</c> for
		/// more details.
		/// </para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues an error if the source subresource is not in the <c>D3D12_RESOURCE_STATE_COPY_SOURCE</c> state.</para>
		/// <para>The debug layer issues an error if the destination subresource is not in the <c>D3D12_RESOURCE_STATE_COPY_DEST</c> state. Restrictions This method has a few restrictions designed for improving performance. For instance, the source and destination resources:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different resources.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same total size (bytes).</description>
		/// </item>
		/// <item>
		/// <description>Must have identical dimensions (width, height, depth) or be a compatible <c>Reinterpret Copy</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible <c>DXGI formats</c>, which means the formats must be identical or at least from the same type group. For
		/// example, a DXGI_FORMAT_R32G32B32_FLOAT texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats
		/// are in the DXGI_FORMAT_R32G32B32_TYPELESS group. <b>CopyResource</b> can copy between a few format types (see <c>Reinterpret copy</c>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>Can't be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para><b>CopyResource</b> only supports copy; it doesn't support any stretch, color key, or blend.</para>
		/// <para>
		/// <b>CopyResource</b> can reinterpret the resource data between a few format types, see <c>Reinterpret Copy</c> below for details.
		/// </para>
		/// <para>
		/// You can use a <c>depth-stencil</c> resource as either a source or a destination. Resources created with multi-sampling
		/// capability (see <c>DXGI_SAMPLE_DESC</c>) can be used as source and destination only if both source and destination have
		/// identical multi-sampled count and quality. If source and destination differ in multi-sampled count and quality or if one is
		/// multi-sampled and the other is not multi-sampled, the call to <b>CopyResource</b> fails. Use <c>ResolveSubresource</c> to
		/// resolve a multi-sampled resource to a resource that is not multi-sampled.
		/// </para>
		/// <para>
		/// The method is an asynchronous call, which may be added to the command-buffer queue. This attempts to remove pipeline stalls that
		/// may occur when copying data. For more info, see <c>performance considerations</c>.
		/// </para>
		/// <para>
		/// Consider using <c>CopyTextureRegion</c> or <c>CopyBufferRegion</c> if you only need to copy a portion of the data in a resource.
		/// </para>
		/// <para>Reinterpret copy</para>
		/// <para>
		/// The following table lists the allowable source and destination formats that you can use in the reinterpretation type of format
		/// conversion. The underlying data values are not converted or compressed/decompressed and must be encoded properly for the
		/// reinterpretation to work as expected. For more info, see <c>Format Conversion using Direct3D 10.1</c>.
		/// </para>
		/// <para>For DXGI_FORMAT_R9G9B9E5_SHAREDEXP the width and height must be equal (1 texel per block).</para>
		/// <para>
		/// Block-compressed resource width and height must be 4 times the uncompressed resource width and height (16 texels per block). For
		/// example, a uncompressed 256x256 DXGI_FORMAT_R32G32B32A32_UINT texture will map to a 1024x1024 DXGI_FORMAT_BC5_UNORM compressed texture.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Bit width</description>
		/// <description>Uncompressed resource</description>
		/// <description>Block-compressed resource</description>
		/// <description>Width / height difference</description>
		/// </listheader>
		/// <item>
		/// <description>32</description>
		/// <description>DXGI_FORMAT_R32_UINT DXGI_FORMAT_R32_SINT</description>
		/// <description>DXGI_FORMAT_R9G9B9E5_SHAREDEXP</description>
		/// <description>1:1</description>
		/// </item>
		/// <item>
		/// <description>64</description>
		/// <description>DXGI_FORMAT_R16G16B16A16_UINT DXGI_FORMAT_R16G16B16A16_SINT DXGI_FORMAT_R32G32_UINT DXGI_FORMAT_R32G32_SINT</description>
		/// <description>DXGI_FORMAT_BC1_UNORM[_SRGB] DXGI_FORMAT_BC4_UNORM DXGI_FORMAT_BC4_SNORM</description>
		/// <description>1:4</description>
		/// </item>
		/// <item>
		/// <description>128</description>
		/// <description>DXGI_FORMAT_R32G32B32A32_UINT DXGI_FORMAT_R32G32B32A32_SINT</description>
		/// <description>DXGI_FORMAT_BC2_UNORM[_SRGB] DXGI_FORMAT_BC3_UNORM[_SRGB] DXGI_FORMAT_BC5_UNORM DXGI_FORMAT_BC5_SNORM</description>
		/// <description>1:4</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copyresource void CopyResource( [in]
		// ID3D12Resource *pDstResource, [in] ID3D12Resource *pSrcResource );
		[PreserveSig]
		new void CopyResource([In] ID3D12Resource pDstResource, [In] ID3D12Resource pSrcResource);

		/// <summary>Copies tiles from buffer to tiled resource or vice versa.</summary>
		/// <param name="pTiledResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to a tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionStartCoordinate">
		/// <para>Type: <b>const <c>D3D12_TILED_RESOURCE_COORDINATE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_TILED_RESOURCE_COORDINATE</c> structure that describes the starting coordinates of the tiled resource.</para>
		/// </param>
		/// <param name="pTileRegionSize">
		/// <para>Type: <b>const <c>D3D12_TILE_REGION_SIZE</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_TILE_REGION_SIZE</c> structure that describes the size of the tiled region.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para>A pointer to an <c>ID3D12Resource</c> that represents a default, dynamic, or staging buffer.</para>
		/// </param>
		/// <param name="BufferStartOffsetInBytes">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The offset in bytes into the buffer at <i>pBuffer</i> to start the operation.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>Type: <b><c>D3D12_TILE_COPY_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_TILE_COPY_FLAGS</c>-typed values that are combined by using a bitwise OR operation and that identifies
		/// how to copy tiles.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>CopyTiles</b> drops write operations to unmapped areas and handles read operations from unmapped areas (except on Tier_1
		/// tiled resources, where reading and writing unmapped areas is invalid - refer to <c>D3D12_TILED_RESOURCES_TIER</c>).
		/// </para>
		/// <para>
		/// If a copy operation involves writing to the same memory location multiple times because multiple locations in the destination
		/// resource are mapped to the same tile memory, the resulting write operations to multi-mapped tiles are non-deterministic and
		/// non-repeatable; that is, accesses to the tile memory happen in whatever order the hardware happens to execute the copy operation.
		/// </para>
		/// <para>
		/// The tiles involved in the copy operation can't include tiles that contain packed mipmaps or results of the copy operation are
		/// undefined. To transfer data to and from mipmaps that the hardware packs into the one-or-more tiles that constitute the packed
		/// mips, you must use the standard (that is, non-tile specific) copy APIs like <c>CopyTextureRegion</c>.
		/// </para>
		/// <para><b>CopyTiles</b> does copy data in a slightly different pattern than the standard copy methods.</para>
		/// <para>
		/// The memory layout of the tiles in the non-tiled buffer resource side of the copy operation is linear in memory within 64 KB
		/// tiles, which the hardware and driver swizzle and de-swizzle per tile as appropriate when they transfer to and from a tiled
		/// resource. For multisample antialiasing (MSAA) surfaces, the hardware and driver traverse each pixel's samples in sample-index
		/// order before they move to the next pixel. For tiles that are partially filled on the right side (for a surface that has a width
		/// not a multiple of tile width in pixels), the pitch and stride to move down a row is the full size in bytes of the number pixels
		/// that would fit across the tile if the tile was full. So, there can be a gap between each row of pixels in memory. Mipmaps that
		/// are smaller than a tile are not packed together in the linear layout, which might seem to be a waste of memory space, but as
		/// mentioned you can't use <b>CopyTiles</b> to copy to mipmaps that the hardware packs together. You can just use generic copy
		/// APIs, like <c>CopyTextureRegion</c>, to copy small mipmaps individually.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-copytiles void CopyTiles( [in]
		// ID3D12Resource *pTiledResource, [in] const D3D12_TILED_RESOURCE_COORDINATE *pTileRegionStartCoordinate, [in] const
		// D3D12_TILE_REGION_SIZE *pTileRegionSize, [in] ID3D12Resource *pBuffer, UINT64 BufferStartOffsetInBytes, D3D12_TILE_COPY_FLAGS
		// Flags );
		[PreserveSig]
		new void CopyTiles([In] ID3D12Resource pTiledResource, in D3D12_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate,
			in D3D12_TILE_REGION_SIZE pTileRegionSize, [In] ID3D12Resource pBuffer, ulong BufferStartOffsetInBytes, D3D12_TILE_COPY_FLAGS Flags);

		/// <summary>Copy a multi-sampled resource into a non-multi-sampled resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: [in] <b>ID3D12Resource*</b></para>
		/// <para>Destination resource. Must be a created on a <c>D3D12_HEAP_TYPE_DEFAULT</c> heap and be single-sampled. See <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>
		/// A zero-based index, that identifies the destination subresource. Use <c>D3D12CalcSubresource</c> to calculate the subresource
		/// index if the parent resource is complex.
		/// </para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: [in] <b>ID3D12Resource*</b></para>
		/// <para>Source resource. Must be multisampled.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The source subresource of the source resource.</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: [in] <b>DXGI_FORMAT</b></para>
		/// <para>A <c>DXGI_FORMAT</c> that indicates how the multisampled resource will be resolved to a single-sampled resource. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the source view is not in the
		/// <c>D3D12_RESOURCE_STATE_RESOLVE_SOURCE</c> state.
		/// </para>
		/// <para>The debug layer will issue an error if the destination buffer is not in the <c>D3D12_RESOURCE_STATE_RESOLVE_DEST</c> state.</para>
		/// <para>
		/// The source and destination resources must be the same resource type and have the same dimensions. In addition, they must have
		/// compatible formats. There are three scenarios for this:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Scenario</description>
		/// <description>Requirements</description>
		/// </listheader>
		/// <item>
		/// <description>Source and destination are prestructured and typed</description>
		/// <description>
		/// Both the source and destination must have identical formats and that format must be specified in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>One resource is prestructured and typed and the other is prestructured and typeless</description>
		/// <description>
		/// The typed resource must have a format that is compatible with the typeless resource (i.e. the typed resource is
		/// DXGI_FORMAT_R32_FLOAT and the typeless resource is DXGI_FORMAT_R32_TYPELESS). The format of the typed resource must be specified
		/// in the Format parameter.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Source and destination are prestructured and typeless</description>
		/// <description>
		/// Both the source and destination must have the same typeless format (i.e. both must have DXGI_FORMAT_R32_TYPELESS), and the
		/// Format parameter must specify a format that is compatible with the source and destination (i.e. if both are
		/// DXGI_FORMAT_R32_TYPELESS then DXGI_FORMAT_R32_FLOAT could be specified in the Format parameter). For example, given the
		/// DXGI_FORMAT_R16G16B16A16_TYPELESS format:
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resolvesubresource void
		// ResolveSubresource( ID3D12Resource *pDstResource, UINT DstSubresource, ID3D12Resource *pSrcResource, UINT SrcSubresource,
		// DXGI_FORMAT Format );
		[PreserveSig]
		new void ResolveSubresource([In] ID3D12Resource pDstResource, uint DstSubresource, [In] ID3D12Resource pSrcResource, uint SrcSubresource,
			DXGI_FORMAT Format);

		/// <summary>Bind information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="PrimitiveTopology">
		/// <para>Type: <b>D3D12_PRIMITIVE_TOPOLOGY</b></para>
		/// <para>The type of primitive and ordering of the primitive data (see <c>D3D_PRIMITIVE_TOPOLOGY</c>).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetprimitivetopology void
		// IASetPrimitiveTopology( [in] D3D12_PRIMITIVE_TOPOLOGY PrimitiveTopology );
		[PreserveSig]
		new void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY PrimitiveTopology);

		/// <summary>Bind an array of viewports to the rasterizer stage of the pipeline.</summary>
		/// <param name="NumViewports">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Number of viewports to bind. The range of valid values is (0, D3D12_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE).</para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <b>const <c>D3D12_VIEWPORT</c>*</b></para>
		/// <para>An array of <c>D3D12_VIEWPORT</c> structures to bind to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All viewports must be set atomically as one operation. Any viewports not defined by the call are disabled.</para>
		/// <para>
		/// Which viewport to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader; if a geometry
		/// shader does not specify the semantic, Direct3D will use the first viewport in the array.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::RSSetViewports</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-rssetviewports void RSSetViewports(
		// [in] UINT NumViewports, [in] const D3D12_VIEWPORT *pViewports );
		[PreserveSig]
		new void RSSetViewports(int NumViewports, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_VIEWPORT[] pViewports);

		/// <summary>Binds an array of scissor rectangles to the rasterizer stage.</summary>
		/// <param name="NumRects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of scissor rectangles to bind.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const D3D12_RECT*</b></para>
		/// <para>An array of scissor rectangles.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All scissor rectangles must be set atomically as one operation. Any scissor rectangles not defined by the call are disabled.</para>
		/// <para>
		/// Which scissor rectangle to use is determined by the <c>SV_ViewportArrayIndex</c> semantic output by a geometry shader (see
		/// shader semantic syntax). If a geometry shader does not make use of the <c>SV_ViewportArrayIndex</c> semantic then Direct3D will
		/// use the first scissor rectangle in the array.
		/// </para>
		/// <para>Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see <c>RSSetViewports</c>). Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::RSSetScissorRects</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>// Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps
		/// should use // fences to determine GPU execution progress. ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when
		/// ExecuteCommandList() is called on a particular command // list, that command list can then be reset at any time and must be
		/// before // re-recording. ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set
		/// necessary state. m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1,
		/// &amp;m_viewport); m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a
		/// render target. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close());</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-rssetscissorrects void
		// RSSetScissorRects( [in] UINT NumRects, [in] const D3D12_RECT *pRects );
		[PreserveSig]
		new void RSSetScissorRects(int NumRects, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		/// <summary>Sets the blend factor that modulate values for a pixel shader, render target, or both.</summary>
		/// <param name="BlendFactor">
		/// <para>Type: <b>const FLOAT[4]</b></para>
		/// <para>Array of blend factors, one for each RGBA component.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If you created the blend-state object with <c>D3D12_BLEND_BLEND_FACTOR</c> or <b>D3D12_BLEND_INV_BLEND_FACTOR</b>, then the
		/// blending stage uses the non-NULL array of blend factors. Otherwise,the blending stage doesn't use the non-NULL array of blend
		/// factors; the runtime stores the blend factors.
		/// </para>
		/// <para>If you pass NULL, then the runtime uses or stores a blend factor equal to <c>{ 1, 1, 1, 1 }</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetblendfactor void
		// OMSetBlendFactor( [in, optional] const FLOAT [4] BlendFactor );
		[PreserveSig]
		new void OMSetBlendFactor([In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[]? BlendFactor);

		/// <summary>Sets the reference value for depth stencil tests.</summary>
		/// <param name="StencilRef">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Reference value to perform against when doing a depth-stencil test.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetstencilref void
		// OMSetStencilRef( [in] UINT StencilRef );
		[PreserveSig]
		new void OMSetStencilRef(uint StencilRef);

		/// <summary>Sets all shaders and programs most of the fixed-function state of the graphics processing unit (GPU) pipeline.</summary>
		/// <param name="pPipelineState">
		/// <para>Type: <b><c>ID3D12PipelineState</c>*</b></para>
		/// <para>Pointer to the <c>ID3D12PipelineState</c> containing the pipeline state data.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setpipelinestate void
		// SetPipelineState( [in] ID3D12PipelineState *pPipelineState );
		[PreserveSig]
		new void SetPipelineState([In] ID3D12PipelineState pPipelineState);

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
		/// <remarks>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// A resource to be used for the <c>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</c> state must be created in that state,
		/// and then never transitioned out of it. Nor may a resource that was created not in that state be transitioned into it. For more
		/// info, see <c>Acceleration structure memory restrictions</c> in the DirectX raytracing (DXR) functional specification on GitHub.
		/// </para>
		/// </para>
		/// <para>There are three types of barrier descriptions:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_TRANSITION_BARRIER</c> - Transition barriers indicate that a set of subresources transition between different
		/// usages. The caller must specify the <i>before</i> and <i>after</i> usages of the subresources. The
		/// D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES flag is used to transition all subresources in a resource at the same time.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_ALIASING_BARRIER</c> - Aliasing barriers indicate a transition between usages of two different resources which
		/// have mappings into the same heap. The application can specify both the before and the after resource. Note that one or both
		/// resources can be NULL (indicating that any tiled resource could cause aliasing).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <c>D3D12_RESOURCE_UAV_BARRIER</c> - Unordered access view barriers indicate all UAV accesses (read or writes) to a particular
		/// resource must complete before any future UAV accesses (read or write) can begin. The specified resource may be NULL. It is not
		/// necessary to insert a UAV barrier between two draw or dispatch calls which only read a UAV. Additionally, it is not necessary to
		/// insert a UAV barrier between two draw or dispatch calls which write to the same UAV if the application knows that it is safe to
		/// execute the UAV accesses in any order. The resource can be NULL (indicating that any UAV access could require the barrier).
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// When <b>ID3D12GraphicsCommandList::ResourceBarrier</b> is passed an array of resource barrier descriptions, the API behaves as
		/// if it was called N times (1 for each array element), in the specified order. Transitions should be batched together into a
		/// single API call when possible, as a performance optimization.
		/// </para>
		/// <para>
		/// For descriptions of the usage states a subresource can be in, see the <c>D3D12_RESOURCE_STATES</c> enumeration and the <c>Using
		/// Resource Barriers to Synchronize Resource States in Direct3D 12</c> section.
		/// </para>
		/// <para>
		/// All subresources in a resource must be in the RENDER_TARGET state, or DEPTH_WRITE state, for render targets/depth-stencil
		/// resources respectively, when <c>ID3D12GraphicsCommandList::DiscardResource</c> is called.
		/// </para>
		/// <para>
		/// When a back buffer is presented, it must be in the D3D12_RESOURCE_STATE_PRESENT state. If <c>IDXGISwapChain1::Present1</c> is
		/// called on a resource which is not in the PRESENT state, a debug layer warning will be emitted.
		/// </para>
		/// <para>The resource usage bits are group into two categories, read-only and read/write.</para>
		/// <para>The following usage bits are read-only:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_INDEX_BUFFER</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_COPY_SOURCE</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_DEPTH_READ</description>
		/// </item>
		/// </list>
		/// <para>The following usage bits are read/write:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_DEPTH_WRITE</description>
		/// </item>
		/// </list>
		/// <para>The following usage bits are write-only:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_COPY_DEST</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_RENDER_TARGET</description>
		/// </item>
		/// <item>
		/// <description>D3D12_RESOURCE_STATE_STREAM_OUT</description>
		/// </item>
		/// </list>
		/// <para>
		/// At most one write bit can be set. If any write bit is set, then no read bit may be set. If no write bit is set, then any number
		/// of read bits may be set.
		/// </para>
		/// <para>
		/// At any given time, a subresource is in exactly one state (determined by a set of flags). The application must ensure that the
		/// states are matched when making a sequence of <b>ResourceBarrier</b> calls. In other words, the before and after states in
		/// consecutive calls to <b>ResourceBarrier</b> must agree.
		/// </para>
		/// <para>
		/// To transition all subresources within a resource, the application can set the subresource index to
		/// D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES, which implies that all subresources are changed.
		/// </para>
		/// <para>
		/// For improved performance, applications should use split barriers (refer to <c>Multi-engine synchronization</c>). Your
		/// application should also batch multiple transitions into a single call whenever possible.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>The runtime will validate that the barrier type values are valid members of the <c>D3D12_RESOURCE_BARRIER_TYPE</c> enumeration.</para>
		/// <para>In addition, the runtime checks the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The resource pointer is non-NULL.</description>
		/// </item>
		/// <item>
		/// <description>The subresource index is valid</description>
		/// </item>
		/// <item>
		/// <description>
		/// The before and after states are supported by the <c>D3D12_RESOURCE_BINDING_TIER</c> and <c>D3D12_RESOURCE_FLAGS</c> flags of the resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Reserved bits in the state masks are not set.</description>
		/// </item>
		/// <item>
		/// <description>The before and after states are different.</description>
		/// </item>
		/// <item>
		/// <description>The set of bits in the before and after states are valid.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If the D3D12_RESOURCE_STATE_RESOLVE_SOURCE bit is set, then the resource sample count must be greater than 1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If the D3D12_RESOURCE_STATE_RESOLVE_DEST bit is set, then the resource sample count must be equal to 1.</description>
		/// </item>
		/// </list>
		/// <para>For aliasing barriers the runtime will validate that, if either resource pointer is non-NULL, it refers to a tiled resource.</para>
		/// <para>
		/// For UAV barriers the runtime will validate that, if the resource is non-NULL, the resource has the
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS bind flag set.
		/// </para>
		/// <para>Validation failure causes <c>ID3D12GraphicsCommandList::Close</c> to return E_INVALIDARG.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer normally issues errors where runtime validation fails:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If a subresource transition in a command list is inconsistent with previous transitions in the same command list.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If a resource is used without first calling <b>ResourceBarrier</b> to put the resource into the correct state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If a resource is illegally bound for read and write at the same time.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If the <i>before</i> states passed to the <b>ResourceBarrier</b> do not match the <i>after</i> states of previous calls to
		/// <b>ResourceBarrier</b>, including the aliasing case.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Whereas the debug layer attempts to validate the runtime rules, it operates conservatively so that debug layer errors are real
		/// errors, and in some cases real errors may not produce debug layer errors.
		/// </para>
		/// <para>The debug layer will issue warnings in the following cases:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>All of the cases where the D3D12 debug layer would issues warnings for <c>ID3D12GraphicsCommandList::ResourceBarrier</c>.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If a depth buffer is used in a non-read-only mode while the resource has the D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE usage
		/// bit set.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resourcebarrier void
		// ResourceBarrier( [in] UINT NumBarriers, [in] const D3D12_RESOURCE_BARRIER *pBarriers );
		[PreserveSig]
		new void ResourceBarrier(int NumBarriers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_RESOURCE_BARRIER[] pBarriers);

		/// <summary>Executes a bundle.</summary>
		/// <param name="pCommandList">
		/// <para>Type: <b><c>ID3D12GraphicsCommandList</c>*</b></para>
		/// <para>Specifies the <c>ID3D12GraphicsCommandList</c> that determines the bundle to be executed.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Bundles inherit all state from the parent command list on which <b>ExecuteBundle</b> is called, except the pipeline state object
		/// and primitive topology. All of the state that is set in a bundle will affect the state of the parent command list. Note that
		/// <b>ExecuteBundle</b> is not a predicated operation.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>
		/// The runtime will validate that the "callee" is a bundle and that the "caller" is a direct command list. The runtime will also
		/// validate that the bundle has been closed. If the contract is violated, the runtime will silently drop the call. Validation
		/// failure will result in <c>Close</c> returning E_INVALIDARG.
		/// </para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>
		/// The debug layer will issue a warning in the same cases where the runtime will fail. The debug layer will issue a warning if a
		/// predicate is set when <c>ExecuteCommandList</c> is called. Also, the debug layer will issue an error if it detects that any
		/// resource reference by the command list has been destroyed.
		/// </para>
		/// <para>
		/// The debug layer will also validate that the command allocator associated with the bundle has not been reset since <c>Close</c>
		/// was called on the command list. This validation occurs at <b>ExecuteBundle</b> time, and when the parent command list is
		/// executed on a command queue.
		///  Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::ExecuteBundle</b> as follows:</para>
		/// <para>
		/// <c>void D3D12Bundles::PopulateCommandList(FrameResource* pFrameResource) { // Command list allocators can only be reset when the
		/// associated // command lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a
		/// particular command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_pCurrentFrameResource-&gt;m_commandAllocator.Get(), m_pipelineState1.Get())); // Set
		/// necessary state. m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = {
		/// m_cbvSrvHeap.Get(), m_samplerHeap.Get() }; m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// m_commandList-&gt;RSSetViewports(1, &amp;m_viewport); m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate
		/// that the back buffer will be used as a render target. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;ClearDepthStencilView(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0,
		/// nullptr); if (UseBundles) { // Execute the prebuilt bundle. m_commandList-&gt;ExecuteBundle(pFrameResource-&gt;m_bundle.Get());
		/// } else { // Populate a new command list. pFrameResource-&gt;PopulateCommandList(m_commandList.Get(), m_pipelineState1.Get(),
		/// m_pipelineState2.Get(), m_currentFrameResourceIndex, m_numIndices, &amp;m_indexBufferView, &amp;m_vertexBufferView,
		/// m_cbvSrvHeap.Get(), m_cbvSrvDescriptorSize, m_samplerHeap.Get(), m_rootSignature.Get()); } // Indicate that the back buffer will
		/// now be used to present. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_RENDER_TARGET,
		/// D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-executebundle void ExecuteBundle(
		// [in] ID3D12GraphicsCommandList *pCommandList );
		[PreserveSig]
		new void ExecuteBundle([In] ID3D12GraphicsCommandList pCommandList);

		/// <summary>Changes the currently bound descriptor heaps that are associated with a command list.</summary>
		/// <param name="NumDescriptorHeaps">
		/// <para>Type: [in] <b><c>UINT</c></b></para>
		/// <para>Number of descriptor heaps to bind.</para>
		/// </param>
		/// <param name="ppDescriptorHeaps">
		/// <para>Type: [in] <b><c>ID3D12DescriptorHeap</c>*</b></para>
		/// <para>A pointer to an array of <c>ID3D12DescriptorHeap</c> objects for the heaps to set on the command list.</para>
		/// <para>You can only bind descriptor heaps of type <c><b>D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV</b></c> and <c><b>D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER</b></c>.</para>
		/// <para>
		/// Only one descriptor heap of each type can be set at one time, which means a maximum of 2 heaps (one sampler, one CBV/SRV/UAV)
		/// can be set at one time.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>SetDescriptorHeaps</b> can be called on a bundle, but the bundle descriptor heaps must match the calling command list
		/// descriptor heap. For more information on bundle restrictions, refer to <c>Creating and Recording Command Lists and Bundles</c>.
		/// </para>
		/// <para>All previously set heaps are unset by the call. At most one heap of each shader-visible type can be set in the call.</para>
		/// <para>
		/// Changing descriptor heaps can incur a pipeline flush on some hardware. Because of this, it is recommended to use a single
		/// shader-visible heap of each type, and set it once per frame, rather than regularly changing the bound descriptor heaps. Instead,
		/// use <c><b>ID3D12Device::CopyDescriptors</b></c> and <c><b>ID3D12Device::CopyDescriptorsSimple</b></c> to copy the required
		/// descriptors from shader-opaque heaps to the single shader-visible heap as required during rendering.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setdescriptorheaps void
		// SetDescriptorHeaps( UINT NumDescriptorHeaps, ID3D12DescriptorHeap * const *ppDescriptorHeaps );
		[PreserveSig]
		new void SetDescriptorHeaps(int NumDescriptorHeaps, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D12DescriptorHeap[] ppDescriptorHeaps);

		/// <summary>Sets the layout of the compute root signature.</summary>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12RootSignature</c> object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootsignature void
		// SetComputeRootSignature( [in, optional] ID3D12RootSignature *pRootSignature );
		[PreserveSig]
		new void SetComputeRootSignature([In, Optional] ID3D12RootSignature? pRootSignature);

		/// <summary>Sets the layout of the graphics root signature.</summary>
		/// <param name="pRootSignature">
		/// <para>Type: <b><c>ID3D12RootSignature</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12RootSignature</c> object.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootsignature void
		// SetGraphicsRootSignature( [in, optional] ID3D12RootSignature *pRootSignature );
		[PreserveSig]
		new void SetGraphicsRootSignature([In, Optional] ID3D12RootSignature? pRootSignature);

		/// <summary>Sets a descriptor table into the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BaseDescriptor">
		/// <para>Type: <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A GPU_descriptor_handle object for the base descriptor to set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootdescriptortable void
		// SetComputeRootDescriptorTable( [in] UINT RootParameterIndex, [in] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor );
		[PreserveSig]
		new void SetComputeRootDescriptorTable(uint RootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor);

		/// <summary>Sets a descriptor table into the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BaseDescriptor">
		/// <para>Type: <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>A GPU_descriptor_handle object for the base descriptor to set.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootdescriptortable void
		// SetGraphicsRootDescriptorTable( [in] UINT RootParameterIndex, [in] D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor );
		[PreserveSig]
		new void SetGraphicsRootDescriptorTable(uint RootParameterIndex, D3D12_GPU_DESCRIPTOR_HANDLE BaseDescriptor);

		/// <summary>Sets a constant in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="SrcData">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The source data for the constant to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The offset, in 32-bit values, to set the constant in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputeroot32bitconstant void
		// SetComputeRoot32BitConstant( [in] UINT RootParameterIndex, [in] UINT SrcData, [in] UINT DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetComputeRoot32BitConstant(uint RootParameterIndex, uint SrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a constant in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="SrcData">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The source data for the constant to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the constant in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsroot32bitconstant void
		// SetGraphicsRoot32BitConstant( [in] UINT RootParameterIndex, [in] UINT SrcData, [in] UINT DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetGraphicsRoot32BitConstant(uint RootParameterIndex, uint SrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a group of constants in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="Num32BitValuesToSet">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of constants to set in the root signature.</para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The source data for the group of constants to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the first constant of the group in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputeroot32bitconstants void
		// SetComputeRoot32BitConstants( [in] UINT RootParameterIndex, [in] UINT Num32BitValuesToSet, [in] const void *pSrcData, [in] UINT
		// DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetComputeRoot32BitConstants(uint RootParameterIndex, uint Num32BitValuesToSet,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pSrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a group of constants in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="Num32BitValuesToSet">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of constants to set in the root signature.</para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>The source data for the group of constants to set.</para>
		/// </param>
		/// <param name="DestOffsetIn32BitValues">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The offset, in 32-bit values, to set the first constant of the group in the root signature.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsroot32bitconstants void
		// SetGraphicsRoot32BitConstants( [in] UINT RootParameterIndex, [in] UINT Num32BitValuesToSet, [in] const void *pSrcData, [in] UINT
		// DestOffsetIn32BitValues );
		[PreserveSig]
		new void SetGraphicsRoot32BitConstants(uint RootParameterIndex, uint Num32BitValuesToSet,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pSrcData, uint DestOffsetIn32BitValues);

		/// <summary>Sets a CPU descriptor handle for the constant buffer in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>Specifies the D3D12_GPU_VIRTUAL_ADDRESS of the constant buffer.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootconstantbufferview
		// void SetComputeRootConstantBufferView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetComputeRootConstantBufferView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the constant buffer in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the constant buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootconstantbufferview
		// void SetGraphicsRootConstantBufferView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetGraphicsRootConstantBufferView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the shader resource in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootshaderresourceview
		// void SetComputeRootShaderResourceView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetComputeRootShaderResourceView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the shader resource in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the Buffer. Textures are not supported. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootshaderresourceview
		// void SetGraphicsRootShaderResourceView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetGraphicsRootShaderResourceView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the unordered-access-view resource in the compute root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setcomputerootunorderedaccessview
		// void SetComputeRootUnorderedAccessView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetComputeRootUnorderedAccessView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets a CPU descriptor handle for the unordered-access-view resource in the graphics root signature.</summary>
		/// <param name="RootParameterIndex">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The slot number for binding.</para>
		/// </param>
		/// <param name="BufferLocation">
		/// <para>Type: <b>D3D12_GPU_VIRTUAL_ADDRESS</b></para>
		/// <para>The GPU virtual address of the buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setgraphicsrootunorderedaccessview
		// void SetGraphicsRootUnorderedAccessView( [in] UINT RootParameterIndex, [in] D3D12_GPU_VIRTUAL_ADDRESS BufferLocation );
		[PreserveSig]
		new void SetGraphicsRootUnorderedAccessView(uint RootParameterIndex, D3D12_GPU_VIRTUAL_ADDRESS BufferLocation);

		/// <summary>Sets the view for the index buffer.</summary>
		/// <param name="pView">
		/// <para>Type: <b>const <c>D3D12_INDEX_BUFFER_VIEW</c>*</b></para>
		/// <para>
		/// The view specifies the index buffer's address, size, and <c>DXGI_FORMAT</c>, as a pointer to a <c>D3D12_INDEX_BUFFER_VIEW</c> structure.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Only one index buffer can be bound to the graphics pipeline at any one time. Examples The <c>D3D12Bundles</c> sample uses <b>ID3D12GraphicsCommandList::IASetIndexBuffer</b> as follows:</para>
		/// <para>
		/// <c>void FrameResource::PopulateCommandList(ID3D12GraphicsCommandList* pCommandList, ID3D12PipelineState* pPso1,
		/// ID3D12PipelineState* pPso2, UINT frameResourceIndex, UINT numIndices, D3D12_INDEX_BUFFER_VIEW* pIndexBufferViewDesc,
		/// D3D12_VERTEX_BUFFER_VIEW* pVertexBufferViewDesc, ID3D12DescriptorHeap* pCbvSrvDescriptorHeap, UINT cbvSrvDescriptorSize,
		/// ID3D12DescriptorHeap* pSamplerDescriptorHeap, ID3D12RootSignature* pRootSignature) { // If the root signature matches the root
		/// signature of the caller, then // bindings are inherited, otherwise the bind space is reset.
		/// pCommandList-&gt;SetGraphicsRootSignature(pRootSignature); ID3D12DescriptorHeap* ppHeaps[] = { pCbvSrvDescriptorHeap,
		/// pSamplerDescriptorHeap }; pCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// pCommandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST);
		/// pCommandList-&gt;IASetIndexBuffer(pIndexBufferViewDesc); pCommandList-&gt;IASetVertexBuffers(0, 1, pVertexBufferViewDesc);
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(0, pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart());
		/// pCommandList-&gt;SetGraphicsRootDescriptorTable(1, pSamplerDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart()); //
		/// Calculate the descriptor offset due to multiple frame resources. // 1 SRV + how many CBVs we have currently. UINT
		/// frameResourceDescriptorOffset = 1 + (frameResourceIndex * m_cityRowCount * m_cityColumnCount); CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvSrvHandle(pCbvSrvDescriptorHeap-&gt;GetGPUDescriptorHandleForHeapStart(), frameResourceDescriptorOffset,
		/// cbvSrvDescriptorSize); BOOL usePso1 = TRUE; for (UINT i = 0; i &lt; m_cityRowCount; i++) { for (UINT j = 0; j &lt;
		/// m_cityColumnCount; j++) { // Alternate which PSO to use; the pixel shader is different on // each just as a PSO setting
		/// demonstration. pCommandList-&gt;SetPipelineState(usePso1 ? pPso1 : pPso2); usePso1 = !usePso1; // Set this city's CBV table and
		/// move to the next descriptor. pCommandList-&gt;SetGraphicsRootDescriptorTable(2, cbvSrvHandle);
		/// cbvSrvHandle.Offset(cbvSrvDescriptorSize); pCommandList-&gt;DrawIndexedInstanced(numIndices, 1, 0, 0, 0); } } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetindexbuffer void
		// IASetIndexBuffer( [in, optional] const D3D12_INDEX_BUFFER_VIEW *pView );
		[PreserveSig]
		new void IASetIndexBuffer([In, Optional] StructPointer<D3D12_INDEX_BUFFER_VIEW> pView);

		/// <summary>Sets a CPU descriptor handle for the vertex buffers.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index into the device's zero-based array to begin setting vertex buffers.</para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of views in the <i>pViews</i> array.</para>
		/// </param>
		/// <param name="pViews">
		/// <para>Type: <b>const <c>D3D12_VERTEX_BUFFER_VIEW</c>*</b></para>
		/// <para>Specifies the vertex buffer views in an array of <c>D3D12_VERTEX_BUFFER_VIEW</c> structures.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-iasetvertexbuffers void
		// IASetVertexBuffers( [in] UINT StartSlot, [in] UINT NumViews, [in, optional] const D3D12_VERTEX_BUFFER_VIEW *pViews );
		[PreserveSig]
		new void IASetVertexBuffers(uint StartSlot, int NumViews, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_VERTEX_BUFFER_VIEW[] pViews);

		/// <summary>Sets the stream output buffer views.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Index into the device's zero-based array to begin setting stream output buffers.</para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of entries in the <i>pViews</i> array.</para>
		/// </param>
		/// <param name="pViews">
		/// <para>Type: <b>const <c>D3D12_STREAM_OUTPUT_BUFFER_VIEW</c>*</b></para>
		/// <para>Specifies an array of <c>D3D12_STREAM_OUTPUT_BUFFER_VIEW</c> structures.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-sosettargets void SOSetTargets( [in]
		// UINT StartSlot, [in] UINT NumViews, [in, optional] const D3D12_STREAM_OUTPUT_BUFFER_VIEW *pViews );
		[PreserveSig]
		new void SOSetTargets(uint StartSlot, int NumViews, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_STREAM_OUTPUT_BUFFER_VIEW[] pViews);

		/// <summary>Sets CPU descriptor handles for the render targets and depth stencil.</summary>
		/// <param name="NumRenderTargetDescriptors">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// The number of entries in the <i>pRenderTargetDescriptors</i> array (ranges between 0 and
		/// <b>D3D12_SIMULTANEOUS_RENDER_TARGET_COUNT</b>). If this parameter is nonzero, the number of entries in the array to which
		/// pRenderTargetDescriptors points must equal the number in this parameter.
		/// </para>
		/// </param>
		/// <param name="pRenderTargetDescriptors">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>
		/// Specifies an array of <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structures that describe the CPU descriptor handles that represents the
		/// start of the heap of render target descriptors. If this parameter is NULL and NumRenderTargetDescriptors is 0, no render targets
		/// are bound.
		/// </para>
		/// </param>
		/// <param name="RTsSingleHandleToDescriptorRange">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// <b>True</b> means the handle passed in is the pointer to a contiguous range of <i>NumRenderTargetDescriptors</i> descriptors.
		/// This case is useful if the set of descriptors to bind already happens to be contiguous in memory (so all that�s needed is a
		/// handle to the first one). For example, if <i>NumRenderTargetDescriptors</i> is 3 then the memory layout is taken as follows:
		/// </para>
		/// <para>In this case the driver dereferences the handle and then increments the memory being pointed to.</para>
		/// <para>
		/// <b>False</b> means that the handle is the first of an array of <i>NumRenderTargetDescriptors</i> handles. The false case allows
		/// an application to bind a set of descriptors from different locations at once. Again assuming that
		/// <i>NumRenderTargetDescriptors</i> is 3, the memory layout is taken as follows:
		/// </para>
		/// <para>In this case the driver dereferences three handles that are expected to be adjacent to each other in memory.</para>
		/// </param>
		/// <param name="pDepthStencilDescriptor">
		/// <para>Type: <b>const <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>*</b></para>
		/// <para>
		/// A pointer to a <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> structure that describes the CPU descriptor handle that represents the start
		/// of the heap that holds the depth stencil descriptor. If this parameter is NULL, no depth stencil descriptor is bound.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-omsetrendertargets void
		// OMSetRenderTargets( [in] UINT NumRenderTargetDescriptors, [in, optional] const D3D12_CPU_DESCRIPTOR_HANDLE
		// *pRenderTargetDescriptors, [in] BOOL RTsSingleHandleToDescriptorRange, [in, optional] const D3D12_CPU_DESCRIPTOR_HANDLE
		// *pDepthStencilDescriptor );
		[PreserveSig]
		new void OMSetRenderTargets(uint NumRenderTargetDescriptors,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_CPU_DESCRIPTOR_HANDLE[]? pRenderTargetDescriptors,
			bool RTsSingleHandleToDescriptorRange, [In, Optional] StructPointer<D3D12_CPU_DESCRIPTOR_HANDLE> pDepthStencilDescriptor);

		/// <summary>Clears the depth-stencil resource.</summary>
		/// <param name="DepthStencilView">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>Describes the CPU descriptor handle that represents the start of the heap for the depth stencil to be cleared.</para>
		/// </param>
		/// <param name="ClearFlags">
		/// <para>Type: <b><c>D3D12_CLEAR_FLAGS</c></b></para>
		/// <para>
		/// A combination of <c>D3D12_CLEAR_FLAGS</c> values that are combined by using a bitwise OR operation. The resulting value
		/// identifies the type of data to clear (depth buffer, stencil buffer, or both).
		/// </para>
		/// </param>
		/// <param name="Depth">
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>A value to clear the depth buffer with. This value will be clamped between 0 and 1.</para>
		/// </param>
		/// <param name="Stencil">
		/// <para>Type: <b>UINT8</b></para>
		/// <para>A value to clear the stencil buffer with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>The number of rectangles in the array that the <i>pRects</i> parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const <b>D3D12_RECT</b>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearDepthStencilView</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Only direct and bundle command lists support this operation.</para>
		/// <para>
		/// <b>ClearDepthStencilView</b> may be used to initialize resources which alias the same heap memory. See
		/// <c>CreatePlacedResource</c> for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).</para>
		/// <para>Validation failure will result in the call to <c>Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer will issue errors if the input colors are denormalized.</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state. For
		/// <b>ClearDepthStencilView</b>, the state must be in the state <c>D3D12_RESOURCE_STATE_DEPTH_WRITE</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-cleardepthstencilview void
		// ClearDepthStencilView( [in] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, [in] D3D12_CLEAR_FLAGS ClearFlags, [in] FLOAT Depth,
		// [in] UINT8 Stencil, [in] UINT NumRects, [in] const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearDepthStencilView([In] D3D12_CPU_DESCRIPTOR_HANDLE DepthStencilView, D3D12_CLEAR_FLAGS ClearFlags, float Depth, byte Stencil,
			[Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[]? pRects);

		/// <summary>Sets all the elements in a render target to one value.</summary>
		/// <param name="RenderTargetView">
		/// <para>Type: <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// Specifies a D3D12_CPU_DESCRIPTOR_HANDLE structure that describes the CPU descriptor handle that represents the start of the heap
		/// for the render target to be cleared.
		/// </para>
		/// </param>
		/// <param name="ColorRGBA">
		/// <para>Type: <b>const FLOAT[4]</b></para>
		/// <para>A 4-component array that represents the color to fill the render target with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the <i>pRects</i> parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <b>const D3D12_RECT*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearRenderTargetView</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>ClearRenderTargetView</b> may be used to initialize resources which alias the same heap memory. See
		/// <c>CreatePlacedResource</c> for more details.
		/// </para>
		/// <para><c></c><c></c><c></c> Runtime validation</para>
		/// <para>For floating-point inputs, the runtime will set denormalized values to 0 (while preserving NANs).</para>
		/// <para>Validation failure will result in the call to <c>Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para><c></c><c></c><c></c> Debug layer</para>
		/// <para>The debug layer will issue errors if the input colors are denormalized.</para>
		/// <para>
		/// The debug layer will issue an error if the subresources referenced by the view are not in the appropriate state. For
		/// <b>ClearRenderTargetView</b>, the state must be <c>D3D12_RESOURCE_STATE_RENDER_TARGET</c>.
		///  Examples The <c>D3D12HelloTriangle</c> sample uses <b>ID3D12GraphicsCommandList::ClearRenderTargetView</b> as follows:</para>
		/// <para>
		/// <c>D3D12_VIEWPORT m_viewport; D3D12_RECT m_scissorRect; ComPtr&lt;IDXGISwapChain3&gt; m_swapChain; ComPtr&lt;ID3D12Device&gt;
		/// m_device; ComPtr&lt;ID3D12Resource&gt; m_renderTargets[FrameCount]; ComPtr&lt;ID3D12CommandAllocator&gt; m_commandAllocator;
		/// ComPtr&lt;ID3D12CommandQueue&gt; m_commandQueue; ComPtr&lt;ID3D12RootSignature&gt; m_rootSignature;
		/// ComPtr&lt;ID3D12DescriptorHeap&gt; m_rtvHeap; ComPtr&lt;ID3D12PipelineState&gt; m_pipelineState;
		/// ComPtr&lt;ID3D12GraphicsCommandList&gt; m_commandList; UINT m_rtvDescriptorSize;</c>
		/// </para>
		/// <para>
		/// <c>void D3D12HelloTriangle::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocator-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular command // list,
		/// that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocator.Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize);
		/// m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE, nullptr); // Record commands. const float clearColor[] = { 0.0f,
		/// 0.2f, 0.4f, 1.0f }; m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLELIST); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); m_commandList-&gt;DrawInstanced(3, 1, 0, 0); // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>The <c>D3D12Multithreading</c> sample uses <b>ID3D12GraphicsCommandList::ClearRenderTargetView</b> as follows:</para>
		/// <para><c>// Frame resources. FrameResource* m_frameResources[FrameCount]; FrameResource* m_pCurrentFrameResource; int m_currentFrameResourceIndex;</c></para>
		/// <para>
		/// <c>// Assemble the CommandListPre command list. void D3D12Multithreading::BeginFrame() { m_pCurrentFrameResource-&gt;Init(); //
		/// Indicate that the back buffer will be used as a render target.
		/// m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT,
		/// D3D12_RESOURCE_STATE_RENDER_TARGET)); // Clear the render target and depth stencil. const float clearColor[] = { 0.0f, 0.0f,
		/// 0.0f, 1.0f }; CD3DX12_CPU_DESCRIPTOR_HANDLE rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex,
		/// m_rtvDescriptorSize); m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ClearRenderTargetView(rtvHandle,
		/// clearColor, 0, nullptr);
		/// m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;ClearDepthStencilView(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart(),
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr);
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandLists[CommandListPre]-&gt;Close()); } // Assemble the CommandListMid command
		/// list. void D3D12Multithreading::MidFrame() { // Transition our shadow map from the shadow pass to readable in the scene pass.
		/// m_pCurrentFrameResource-&gt;SwapBarriers();
		/// ThrowIfFailed(m_pCurrentFrameResource-&gt;m_commandLists[CommandListMid]-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearrendertargetview void
		// ClearRenderTargetView( [in] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView, [in] const FLOAT [4] ColorRGBA, [in] UINT NumRects,
		// [in] const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearRenderTargetView([In] D3D12_CPU_DESCRIPTOR_HANDLE RenderTargetView, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] ColorRGBA,
			[Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[]? pRects);

		/// <summary>
		/// <para>Sets all the elements in a unordered-access view (UAV) to the specified integer values.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <b>Dispatch</b> calls.
		/// To ensure ordering, barrier calls must be issued before and/or after the <b>ClearUnorderedAccessViewXxx</b> call as needed. It
		/// might appear on some drivers that such barriers aren't necessary. But implicit barriers are not a spec guarantee; so they can't
		/// be relied upon. This is in contrast to <b>ClearDepthStencilView</b> and <b>ClearRenderTargetView</b> which (like <b>DrawXxx</b>
		/// commands), respect command list ordering.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="ViewGPUHandleInCurrentHeap">
		/// <para>Type: [in] <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_GPU_DESCRIPTOR_HANDLE</c> that references an initialized descriptor for the unordered-access view (UAV) that is to be
		/// cleared. This descriptor must be in a shader-visible descriptor heap, which must be set on the command list via <c>SetDescriptorHeaps</c>.
		/// </para>
		/// </param>
		/// <param name="ViewCPUHandle">
		/// <para>Type: [in] <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> in a non-shader visible descriptor heap that references an initialized descriptor for the
		/// unordered-access view (UAV) that is to be cleared.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This descriptor must not be in a shader-visible descriptor heap. This is to allow drivers that implement the clear as a
		/// fixed-function hardware operation (rather than as a dispatch) to efficiently read from the descriptor, as shader-visible heaps
		/// may be created in <b>WRITE_BACK</b> memory (similar to <b>D3D12_HEAP_TYPE_UPLOAD</b> heap types), and CPU reads from this type
		/// of memory are prohibitively slow.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the unordered-access-view (UAV) resource to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: [in] <b>const UINT[4]</b></para>
		/// <para>A 4-component array that containing the values to fill the unordered-access-view resource with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the pRects parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: [in] <b>const <c>D3D12_RECT</c>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearUnorderedAccessViewUint</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Runtime validation</para>
		/// <para>Validation failure results in the call to <c>ID3D12GraphicsCommandList::Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues errors if the input values are outside of a normalized range.</para>
		/// <para>
		/// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state. For
		/// <b>ClearUnorderedAccessViewUint</b>, the state must be <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearunorderedaccessviewuint void
		// ClearUnorderedAccessViewUint( D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
		// ID3D12Resource *pResource, const UINT [4] Values, UINT NumRects, const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearUnorderedAccessViewUint([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
			[In] ID3D12Resource pResource, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] Values, int NumRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[] pRects);

		/// <summary>
		/// <para>Sets all of the elements in an unordered-access view (UAV) to the specified float values.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This behaves like a compute operation in that it isn't ordered with respect to surrounding work such as <b>Dispatch</b> calls.
		/// To ensure ordering, barrier calls must be issued before and/or after the <b>ClearUnorderedAccessViewXxx</b> call as needed. It
		/// might appear on some drivers that such barriers aren't necessary. But implicit barriers are not a spec guarantee; so they can't
		/// be relied upon. This is in contrast to <b>ClearDepthStencilView</b> and <b>ClearRenderTargetView</b> which (like <b>DrawXxx</b>
		/// commands), respect command list ordering.
		/// </para>
		/// </para>
		/// </summary>
		/// <param name="ViewGPUHandleInCurrentHeap">
		/// <para>Type: [in] <b><c>D3D12_GPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_GPU_DESCRIPTOR_HANDLE</c> that references an initialized descriptor for the unordered-access view (UAV) that is to be
		/// cleared. This descriptor must be in a shader-visible descriptor heap, which must be set on the command list via <c>SetDescriptorHeaps</c>.
		/// </para>
		/// </param>
		/// <param name="ViewCPUHandle">
		/// <para>Type: [in] <b><c>D3D12_CPU_DESCRIPTOR_HANDLE</c></b></para>
		/// <para>
		/// A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c> in a non-shader visible descriptor heap that references an initialized descriptor for the
		/// unordered-access view (UAV) that is to be cleared.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>
		/// This descriptor must not be in a shader-visible descriptor heap. This is to allow drivers that implement the clear as a
		/// fixed-function hardware operation (rather than as a dispatch) to efficiently read from the descriptor, as shader-visible heaps
		/// may be created in <b>WRITE_BACK</b> memory (similar to <b>D3D12_HEAP_TYPE_UPLOAD</b> heap types), and CPU reads from this type
		/// of memory are prohibitively slow.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface that represents the unordered-access-view (UAV) resource to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: [in] <b>const FLOAT[4]</b></para>
		/// <para>A 4-component array that containing the values to fill the unordered-access-view resource with.</para>
		/// </param>
		/// <param name="NumRects">
		/// <para>Type: [in] <b>UINT</b></para>
		/// <para>The number of rectangles in the array that the pRects parameter specifies.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: [in] <b>const <c>D3D12_RECT</c>*</b></para>
		/// <para>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource view to clear. If <b>NULL</b>,
		/// <b>ClearUnorderedAccessViewFloat</b> clears the entire resource view.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Runtime validation</para>
		/// <para>For floating-point inputs, the runtime sets denormalized values to 0 (while preserving NANs).</para>
		/// <para>If you want to clear the UAV to a specific bit pattern, consider using <c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewUint</c>.</para>
		/// <para>Validation failure results in the call to <c>ID3D12GraphicsCommandList::Close</c> returning <b>E_INVALIDARG</b>.</para>
		/// <para>Debug layer</para>
		/// <para>The debug layer issues errors if the input values are outside of a normalized range.</para>
		/// <para>
		/// The debug layer issues an error if the subresources referenced by the view aren't in the appropriate state. For
		/// <b>ClearUnorderedAccessViewFloat</b>, the state must be <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-clearunorderedaccessviewfloat void
		// ClearUnorderedAccessViewFloat( D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
		// ID3D12Resource *pResource, const FLOAT [4] Values, UINT NumRects, const D3D12_RECT *pRects );
		[PreserveSig]
		new void ClearUnorderedAccessViewFloat([In] D3D12_GPU_DESCRIPTOR_HANDLE ViewGPUHandleInCurrentHeap, [In] D3D12_CPU_DESCRIPTOR_HANDLE ViewCPUHandle,
			[In] ID3D12Resource pResource, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] Values, int NumRects,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] RECT[] pRects);

		/// <summary>
		/// Indicates that the contents of a resource don't need to be preserved. The function may re-initialize resource metadata in some cases.
		/// </summary>
		/// <param name="pResource">
		/// <para>Type: [in] <b><c>ID3D12Resource</c>*</b></para>
		/// <para>A pointer to the <c>ID3D12Resource</c> interface for the resource to discard.</para>
		/// </param>
		/// <param name="pRegion">
		/// <para>Type: [in, optional] <b>const <c>D3D12_DISCARD_REGION</c>*</b></para>
		/// <para>A pointer to a <c>D3D12_DISCARD_REGION</c> structure that describes details for the discard-resource operation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The semantics of <b>DiscardResource</b> change based on the command list type.</para>
		/// <para>For <c>D3D12_COMMAND_LIST_TYPE_DIRECT</c>, the following two rules apply:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// When a resource has the <c>D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET</c> flag, <b>DiscardResource</b> must be called when the
		/// discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_RENDER_TARGET</c> resource barrier state.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When a resource has the <c>D3D12_RESOURCE_FLAG _ALLOW_DEPTH_STENCIL</c> flag, <b>DiscardResource</b> must be called when the
		/// discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_DEPTH_WRITE</c>.
		/// </description>
		/// </item>
		/// </list>
		/// <para>For <c>D3D12_COMMAND_LIST_TYPE_COMPUTE</c>, the following rule applies:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The resource must have the <c>D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS</c> flag, and <b>DiscardResource</b> must be called
		/// when the discarded subresource regions are in the <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c> resource barrier state.
		/// </description>
		/// </item>
		/// </list>
		/// <para><b>DiscardResource</b> is not supported on command lists with either <c>D3D12_COMMAND_LIST_TYPE_BUNDLE</c> nor <b>D3D12_COMMAND_LIST_TYPE_COPY</b>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-discardresource void
		// DiscardResource( ID3D12Resource *pResource, const D3D12_DISCARD_REGION *pRegion );
		[PreserveSig]
		new void DiscardResource([In] ID3D12Resource pResource, [In, Optional] StructPointer<D3D12_DISCARD_REGION> pRegion);

		/// <summary>Starts a query running.</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the query.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="Index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the query within the query heap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>See <c>Queries</c> for more information about D3D12 queries. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::BeginQuery</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-beginquery void BeginQuery( [in]
		// ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT Index );
		[PreserveSig]
		new void BeginQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Ends a running query.</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the query.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="Index">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the index of the query in the query heap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>See <c>Queries</c> for more information about D3D12 queries. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::EndQuery</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-endquery void EndQuery( [in]
		// ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT Index );
		[PreserveSig]
		new void EndQuery([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint Index);

		/// <summary>Extracts data from a query. <b>ResolveQueryData</b> works with all heap types (default, upload, and readback).</summary>
		/// <param name="pQueryHeap">
		/// <para>Type: <b><c>ID3D12QueryHeap</c>*</b></para>
		/// <para>Specifies the <c>ID3D12QueryHeap</c> containing the queries to resolve.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type: <b><c>D3D12_QUERY_TYPE</c></b></para>
		/// <para>Specifies the type of query, one member of <c>D3D12_QUERY_TYPE</c>.</para>
		/// </param>
		/// <param name="StartIndex">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies an index of the first query to resolve.</para>
		/// </param>
		/// <param name="NumQueries">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Specifies the number of queries to resolve.</para>
		/// </param>
		/// <param name="pDestinationBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies an <c>ID3D12Resource</c> destination buffer, which must be in the state <c>D3D12_RESOURCE_STATE_COPY_DEST</c>.</para>
		/// </param>
		/// <param name="AlignedDestinationBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies an alignment offset into the destination buffer. Must be a multiple of 8 bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>ResolveQueryData</b> performs a batched operation that writes query data into a destination buffer. Query data is written
		/// contiguously to the destination buffer, and the parameter.
		/// </para>
		/// <para>
		/// <b>ResolveQueryData</b> turns application-opaque query data in an application-opaque query heap into adapter-agnostic values
		/// usable by your application. Resolving queries within a heap that have not been completed (so have had
		/// <c><b>ID3D12GraphicsCommandList::BeginQuery</b></c> called for them, but not <c><b>ID3D12GraphicsCommandList::EndQuery</b></c>),
		/// or that have been uninitialized, results in undefined behavior and might cause device hangs or removal. The debug layer will
		/// emit an error if it detects an application has resolved incomplete or uninitialized queries.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// Resolving incomplete or uninitialized queries is undefined behavior because the driver might internally store GPUVAs or other
		/// data within unresolved queries. And so attempting to resolve these queries on uninitialized data could cause a page fault or
		/// device hang. Older versions of the debug layer didn't validate this behavior.
		/// </para>
		/// </para>
		/// <para>
		/// Binary occlusion queries write 64-bits per query. The least significant bit is either 0 (the object was entirely occluded) or 1
		/// (at least 1 sample of the object would have been drawn). The rest of the bits are 0. Occlusion queries write 64-bits per query.
		/// The value is the number of samples that passed testing. Timestamp queries write 64-bits per query, which is a tick value that
		/// must be compared to the respective command queue frequency (see <c>Timing</c>).
		/// </para>
		/// <para>
		/// Pipeline statistics queries write a <c><b>D3D12_QUERY_DATA_PIPELINE_STATISTICS</b></c> structure per query. All stream-out
		/// statistics queries write a <c><b>D3D12_QUERY_DATA_SO_STATISTICS</b></c> structure per query.
		/// </para>
		/// <para>The core runtime will validate the following.</para>
		/// <list type="bullet">
		/// <item>
		/// <description><i>StartIndex</i> and <i>NumQueries</i> are within range.</description>
		/// </item>
		/// <item>
		/// <description><i>AlignedDestinationBufferOffset</i> is a multiple of 8 bytes.</description>
		/// </item>
		/// <item>
		/// <description><i>DestinationBuffer</i> is a buffer.</description>
		/// </item>
		/// <item>
		/// <description>The written data will not overflow the output buffer.</description>
		/// </item>
		/// <item>
		/// <description>The query type must be supported by the command list type.</description>
		/// </item>
		/// <item>
		/// <description>The query type must be supported by the query heap.</description>
		/// </item>
		/// </list>
		/// <para>
		/// The debug layer will issue a warning if the destination buffer is not in the D3D12_RESOURCE_STATE_COPY_DEST state, or if any
		/// queries being resolved have not had <c><b>ID3D12GraphicsCommandList::EndQuery</b></c> called on them.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-resolvequerydata void
		// ResolveQueryData( [in] ID3D12QueryHeap *pQueryHeap, [in] D3D12_QUERY_TYPE Type, [in] UINT StartIndex, [in] UINT NumQueries, [in]
		// ID3D12Resource *pDestinationBuffer, [in] UINT64 AlignedDestinationBufferOffset );
		[PreserveSig]
		new void ResolveQueryData([In] ID3D12QueryHeap pQueryHeap, D3D12_QUERY_TYPE Type, uint StartIndex, uint NumQueries,
			[In] ID3D12Resource pDestinationBuffer, ulong AlignedDestinationBufferOffset);

		/// <summary>Sets a rendering predicate.</summary>
		/// <param name="pBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>
		/// The buffer, as an <c>ID3D12Resource</c>, which must be in the <c><b>D3D12_RESOURCE_STATE_PREDICATION</b></c> or
		/// <c><b>D3D21_RESOURCE_STATE_INDIRECT_ARGUMENT</b></c> state (both values are identical, and provided as aliases for clarity), or
		/// <b>NULL</b> to disable predication.
		/// </para>
		/// </param>
		/// <param name="AlignedBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>The aligned buffer offset, as a UINT64.</para>
		/// </param>
		/// <param name="Operation">
		/// <para>Type: <b><c>D3D12_PREDICATION_OP</c></b></para>
		/// <para>Specifies a <c>D3D12_PREDICATION_OP</c>, such as D3D12_PREDICATION_OP_EQUAL_ZERO or D3D12_PREDICATION_OP_NOT_EQUAL_ZERO.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed if the
		/// resulting predicate data of the predicate is equal to the operation specified.
		/// </para>
		/// <para>
		/// Unlike Direct3D 11, in Direct3D 12 predication state is not inherited by direct command lists, and predication is always
		/// respected (there are no predication hints). All direct command lists begin with predication disabled. Bundles do inherit
		/// predication state. It is legal for the same predicate to be bound multiple times.
		/// </para>
		/// <para>
		/// Illegal API calls will result in <c>Close</c> returning an error, or <c>ID3D12CommandQueue::ExecuteCommandLists</c> dropping the
		/// command list and removing the device.
		/// </para>
		/// <para>The debug layer will issue errors whenever the runtime validation fails.</para>
		/// <para>Refer to <c>Predication</c> for more information. Examples The <c>D3D12PredicationQueries</c> sample uses <b>ID3D12GraphicsCommandList::SetPredication</b> as follows:</para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void
		/// D3D12PredicationQueries::PopulateCommandList() { // Command list allocators can only be reset when the associated // command
		/// lists have finished execution on the GPU; apps should use // fences to determine GPU execution progress.
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, &amp;m_scissorRect); // Indicate that the back buffer will be used as a render target.
		/// m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET)); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); // Draw the quads and perform the occlusion query. { CD3DX12_GPU_DESCRIPTOR_HANDLE
		/// cbvFarQuad(m_cbvHeap-&gt;GetGPUDescriptorHandleForHeapStart(), m_frameIndex * CbvCountPerFrame, m_cbvSrvDescriptorSize);
		/// CD3DX12_GPU_DESCRIPTOR_HANDLE cbvNearQuad(cbvFarQuad, m_cbvSrvDescriptorSize);
		/// m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP); m_commandList-&gt;IASetVertexBuffers(0, 1,
		/// &amp;m_vertexBufferView); // Draw the far quad conditionally based on the result of the occlusion query // from the previous
		/// frame. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad); m_commandList-&gt;SetPredication(m_queryResult.Get(), 0,
		/// D3D12_PREDICATION_OP_EQUAL_ZERO); m_commandList-&gt;DrawInstanced(4, 1, 0, 0); // Disable predication and always draw the near
		/// quad. m_commandList-&gt;SetPredication(nullptr, 0, D3D12_PREDICATION_OP_EQUAL_ZERO);
		/// m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvNearQuad); m_commandList-&gt;DrawInstanced(4, 1, 4, 0); // Run the
		/// occlusion query with the bounding box quad. m_commandList-&gt;SetGraphicsRootDescriptorTable(0, cbvFarQuad);
		/// m_commandList-&gt;SetPipelineState(m_queryState.Get()); m_commandList-&gt;BeginQuery(m_queryHeap.Get(),
		/// D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); m_commandList-&gt;DrawInstanced(4, 1, 8, 0);
		/// m_commandList-&gt;EndQuery(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0); // Resolve the occlusion query and store
		/// the results in the query result buffer // to be used on the subsequent frame. m_commandList-&gt;ResourceBarrier(1,
		/// &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(), D3D12_RESOURCE_STATE_PREDICATION,
		/// D3D12_RESOURCE_STATE_COPY_DEST)); m_commandList-&gt;ResolveQueryData(m_queryHeap.Get(), D3D12_QUERY_TYPE_BINARY_OCCLUSION, 0, 1,
		/// m_queryResult.Get(), 0); m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_queryResult.Get(),
		/// D3D12_RESOURCE_STATE_COPY_DEST, D3D12_RESOURCE_STATE_PREDICATION)); } // Indicate that the back buffer will now be used to
		/// present. m_commandList-&gt;ResourceBarrier(1, &amp;CD3DX12_RESOURCE_BARRIER::Transition(m_renderTargets[m_frameIndex].Get(),
		/// D3D12_RESOURCE_STATE_RENDER_TARGET, D3D12_RESOURCE_STATE_PRESENT)); ThrowIfFailed(m_commandList-&gt;Close()); }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setpredication void SetPredication(
		// [in, optional] ID3D12Resource *pBuffer, [in] UINT64 AlignedBufferOffset, [in] D3D12_PREDICATION_OP Operation );
		[PreserveSig]
		new void SetPredication([In, Optional] ID3D12Resource? pBuffer, ulong AlignedBufferOffset, D3D12_PREDICATION_OP Operation);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <param name="Metadata">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const void*</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="Size">
		/// <para>Type: <b>UINT</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To insert instrumentation markers at the current location within a D3D12 command list, use the <b>PIXSetMarker</b> function.�
		/// This is provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-setmarker void SetMarker( UINT
		// Metadata, [in, optional] const void *pData, UINT Size );
		[PreserveSig]
		new void SetMarker(uint Metadata, [In, Optional] IntPtr pData, uint Size);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <param name="Metadata">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <param name="Size">
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Internal.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To mark the start of an instrumentation region at the current location within a D3D12 command list, use the <b>PIXBeginEvent</b>
		/// function or <b>PIXScopedEvent</b> macro.� These are provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-beginevent void BeginEvent( UINT
		// Metadata, [in, optional] const void *pData, UINT Size );
		[PreserveSig]
		new void BeginEvent(uint Metadata, [In, Optional] IntPtr pData, uint Size);

		/// <summary>Not intended to be called directly.� Use the <c>PIX event runtime</c> to insert events into a command list.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This is a support method used internally by the PIX event runtime.� It is not intended to be called directly.</para>
		/// <para>
		/// To mark the end of an instrumentation region at the current location within a D3D12 command list, use the <b>PIXEndEvent</b>
		/// function or <b>PIXScopedEvent</b> macro.� These are provided by the <c>WinPixEventRuntime</c> NuGet package.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-endevent void EndEvent();
		[PreserveSig]
		new void EndEvent();

		/// <summary>Apps perform indirect draws/dispatches using the <b>ExecuteIndirect</b> method.</summary>
		/// <param name="pCommandSignature">
		/// <para>Type: <b><c>ID3D12CommandSignature</c>*</b></para>
		/// <para>
		/// Specifies a <c>ID3D12CommandSignature</c>. The data referenced by <i>pArgumentBuffer</i> will be interpreted depending on the
		/// contents of the command signature. Refer to <c>Indirect Drawing</c> for the APIs that are used to create a command signature.
		/// </para>
		/// </param>
		/// <param name="MaxCommandCount">
		/// <para>Type: <b>UINT</b></para>
		/// <para>There are two ways that command counts can be specified:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// If <i>pCountBuffer</i> is not NULL, then <i>MaxCommandCount</i> specifies the maximum number of operations which will be
		/// performed. The actual number of operations to be performed are defined by the minimum of this value, and a 32-bit unsigned
		/// integer contained in <i>pCountBuffer</i> (at the byte offset specified by <i>CountBufferOffset</i>).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If <i>pCountBuffer</i> is NULL, the <i>MaxCommandCount</i> specifies the exact number of operations which will be performed.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pArgumentBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies one or more <c>ID3D12Resource</c> objects, containing the command arguments.</para>
		/// </param>
		/// <param name="ArgumentBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies an offset into <i>pArgumentBuffer</i> to identify the first command argument.</para>
		/// </param>
		/// <param name="pCountBuffer">
		/// <para>Type: <b><c>ID3D12Resource</c>*</b></para>
		/// <para>Specifies a pointer to a <c>ID3D12Resource</c>.</para>
		/// </param>
		/// <param name="CountBufferOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>Specifies a UINT64 that is the offset into <i>pCountBuffer</i>, identifying the argument count.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The semantics of this API are defined with the following pseudo-code:</para>
		/// <para>Non-NULL pCountBuffer:</para>
		/// <para>
		/// <c>// Read draw count out of count buffer UINT CommandCount = pCountBuffer-&gt;ReadUINT32(CountBufferOffset); CommandCount =
		/// min(CommandCount, MaxCommandCount) // Get pointer to first Commanding argument BYTE* Arguments = pArgumentBuffer-&gt;GetBase() +
		/// ArgumentBufferOffset; for(UINT CommandIndex = 0; CommandIndex &lt; CommandCount; CommandIndex++) { // Interpret the data
		/// contained in *Arguments // according to the command signature pCommandSignature-&gt;Interpret(Arguments); Arguments +=
		/// pCommandSignature-&gt;GetByteStride(); }</c>
		/// </para>
		/// <para>NULL pCountBuffer:</para>
		/// <para>
		/// <c>// Get pointer to first Commanding argument BYTE* Arguments = pArgumentBuffer-&gt;GetBase() + ArgumentBufferOffset; for(UINT
		/// CommandIndex = 0; CommandIndex &lt; MaxCommandCount; CommandIndex++) { // Interpret the data contained in *Arguments //
		/// according to the command signature pCommandSignature-&gt;Interpret(Arguments); Arguments +=
		/// pCommandSignature-&gt;GetByteStride(); }</c>
		/// </para>
		/// <para>
		/// The debug layer will issue an error if either the count buffer or the argument buffer are not in the
		/// D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT state. The core runtime will validate:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description><i>CountBufferOffset</i> and <i>ArgumentBufferOffset</i> are 4-byte aligned</description>
		/// </item>
		/// <item>
		/// <description><i>pCountBuffer</i> and <i>pArgumentBuffer</i> are buffer resources (any heap type)</description>
		/// </item>
		/// <item>
		/// <description>
		/// The offset implied by <i>MaxCommandCount</i>, <i>ArgumentBufferOffset</i>, and the drawing program stride do not exceed the
		/// bounds of <i>pArgumentBuffer</i> (similarly for count buffer)
		/// </description>
		/// </item>
		/// <item>
		/// <description>The command list is a direct command list or a compute command list (not a copy or JPEG decode command list)</description>
		/// </item>
		/// <item>
		/// <description>The root signature of the command list matches the root signature of the command signature</description>
		/// </item>
		/// </list>
		/// <para>
		/// The functionality of two APIs from earlier versions of Direct3D, <c>DrawInstancedIndirect</c> and
		/// <c>DrawIndexedInstancedIndirect</c>, are encompassed by <b>ExecuteIndirect</b>.
		/// </para>
		/// <para><c></c><c></c><c></c> Bundles</para>
		/// <para>
		/// <b>ID3D12GraphicsCommandList::ExecuteIndirect</b> is allowed inside of bundle command lists only if all of the following are true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>CountBuffer is NULL (CPU-specified count only).</description>
		/// </item>
		/// <item>
		/// <description>
		/// The command signature contains exactly one operation. This implies that the command signature does not contain root arguments
		/// changes, nor contain VB/IB binding changes.
		/// </description>
		/// </item>
		/// </list>
		/// <para><c></c><c></c><c></c> Obtaining buffer virtual addresses</para>
		/// <para>The <c>ID3D12Resource::GetGPUVirtualAddress</c> method enables an app to retrieve the GPU virtual address of a buffer.</para>
		/// <para>
		/// Apps are free to apply byte offsets to virtual addresses before placing them in an indirect argument buffer. Note that all of
		/// the D3D12 alignment requirements for VB/IB/CB still apply to the resulting GPU virtual address.
		///  Examples The <c>D3D12ExecuteIndirect</c> sample uses <b>ID3D12GraphicsCommandList::ExecuteIndirect</b> as follows:</para>
		/// <para>
		/// <c>// Data structure to match the command signature used for ExecuteIndirect. struct IndirectCommand { D3D12_GPU_VIRTUAL_ADDRESS
		/// cbv; D3D12_DRAW_ARGUMENTS drawArguments; };</c>
		/// </para>
		/// <para>
		/// The call to <b>ExecuteIndirect</b> is near the end of this listing, below the comment "Draw the triangles that have not been culled."
		/// </para>
		/// <para>
		/// <c>// Fill the command list with all the render commands and dependent state. void D3D12ExecuteIndirect::PopulateCommandLists()
		/// { // Command list allocators can only be reset when the associated // command lists have finished execution on the GPU; apps
		/// should use // fences to determine GPU execution progress. ThrowIfFailed(m_computeCommandAllocators[m_frameIndex]-&gt;Reset());
		/// ThrowIfFailed(m_commandAllocators[m_frameIndex]-&gt;Reset()); // However, when ExecuteCommandList() is called on a particular
		/// command // list, that command list can then be reset at any time and must be before // re-recording.
		/// ThrowIfFailed(m_computeCommandList-&gt;Reset(m_computeCommandAllocators[m_frameIndex].Get(), m_computeState.Get()));
		/// ThrowIfFailed(m_commandList-&gt;Reset(m_commandAllocators[m_frameIndex].Get(), m_pipelineState.Get())); // Record the compute
		/// commands that will cull triangles and prevent them from being processed by the vertex shader. if (m_enableCulling) { UINT
		/// frameDescriptorOffset = m_frameIndex * CbvSrvUavDescriptorCountPerFrame; D3D12_GPU_DESCRIPTOR_HANDLE cbvSrvUavHandle =
		/// m_cbvSrvUavHeap-&gt;GetGPUDescriptorHandleForHeapStart();
		/// m_computeCommandList-&gt;SetComputeRootSignature(m_computeRootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = {
		/// m_cbvSrvUavHeap.Get() }; m_computeCommandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps);
		/// m_computeCommandList-&gt;SetComputeRootDescriptorTable( SrvUavTable, CD3DX12_GPU_DESCRIPTOR_HANDLE(cbvSrvUavHandle, CbvSrvOffset
		/// + frameDescriptorOffset, m_cbvSrvUavDescriptorSize)); m_computeCommandList-&gt;SetComputeRoot32BitConstants(RootConstants, 4,
		/// reinterpret_cast&lt;void*&gt;(&amp;m_csRootConstants), 0); // Reset the UAV counter for this frame.
		/// m_computeCommandList-&gt;CopyBufferRegion(m_processedCommandBuffers[m_frameIndex].Get(), CommandBufferSizePerFrame,
		/// m_processedCommandBufferCounterReset.Get(), 0, sizeof(UINT)); D3D12_RESOURCE_BARRIER barrier =
		/// CD3DX12_RESOURCE_BARRIER::Transition(m_processedCommandBuffers[m_frameIndex].Get(), D3D12_RESOURCE_STATE_COPY_DEST,
		/// D3D12_RESOURCE_STATE_UNORDERED_ACCESS); m_computeCommandList-&gt;ResourceBarrier(1, &amp;barrier);
		/// m_computeCommandList-&gt;Dispatch(static_cast&lt;UINT&gt;(ceil(TriangleCount / float(ComputeThreadBlockSize))), 1, 1); }
		/// ThrowIfFailed(m_computeCommandList-&gt;Close()); // Record the rendering commands. { // Set necessary state.
		/// m_commandList-&gt;SetGraphicsRootSignature(m_rootSignature.Get()); ID3D12DescriptorHeap* ppHeaps[] = { m_cbvSrvUavHeap.Get() };
		/// m_commandList-&gt;SetDescriptorHeaps(_countof(ppHeaps), ppHeaps); m_commandList-&gt;RSSetViewports(1, &amp;m_viewport);
		/// m_commandList-&gt;RSSetScissorRects(1, m_enableCulling ? &amp;m_cullingScissorRect : &amp;m_scissorRect); // Indicate that the
		/// command buffer will be used for indirect drawing // and that the back buffer will be used as a render target.
		/// D3D12_RESOURCE_BARRIER barriers[2] = { CD3DX12_RESOURCE_BARRIER::Transition( m_enableCulling ?
		/// m_processedCommandBuffers[m_frameIndex].Get() : m_commandBuffer.Get(), m_enableCulling ? D3D12_RESOURCE_STATE_UNORDERED_ACCESS :
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE, D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT), CD3DX12_RESOURCE_BARRIER::Transition(
		/// m_renderTargets[m_frameIndex].Get(), D3D12_RESOURCE_STATE_PRESENT, D3D12_RESOURCE_STATE_RENDER_TARGET) };
		/// m_commandList-&gt;ResourceBarrier(_countof(barriers), barriers); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// rtvHandle(m_rtvHeap-&gt;GetCPUDescriptorHandleForHeapStart(), m_frameIndex, m_rtvDescriptorSize); CD3DX12_CPU_DESCRIPTOR_HANDLE
		/// dsvHandle(m_dsvHeap-&gt;GetCPUDescriptorHandleForHeapStart()); m_commandList-&gt;OMSetRenderTargets(1, &amp;rtvHandle, FALSE,
		/// &amp;dsvHandle); // Record commands. const float clearColor[] = { 0.0f, 0.2f, 0.4f, 1.0f };
		/// m_commandList-&gt;ClearRenderTargetView(rtvHandle, clearColor, 0, nullptr); m_commandList-&gt;ClearDepthStencilView(dsvHandle,
		/// D3D12_CLEAR_FLAG_DEPTH, 1.0f, 0, 0, nullptr); m_commandList-&gt;IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY_TRIANGLESTRIP);
		/// m_commandList-&gt;IASetVertexBuffers(0, 1, &amp;m_vertexBufferView); if (m_enableCulling) { // Draw the triangles that have not
		/// been culled. m_commandList-&gt;ExecuteIndirect( m_commandSignature.Get(), TriangleCount,
		/// m_processedCommandBuffers[m_frameIndex].Get(), 0, m_processedCommandBuffers[m_frameIndex].Get(), CommandBufferSizePerFrame); }
		/// else { // Draw all of the triangles. m_commandList-&gt;ExecuteIndirect( m_commandSignature.Get(), TriangleCount,
		/// m_commandBuffer.Get(), CommandBufferSizePerFrame * m_frameIndex, nullptr, 0); } // Indicate that the command buffer may be used
		/// by the compute shader // and that the back buffer will now be used to present. barriers[0].Transition.StateBefore =
		/// D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT; barriers[0].Transition.StateAfter = m_enableCulling ? D3D12_RESOURCE_STATE_COPY_DEST :
		/// D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE; barriers[1].Transition.StateBefore = D3D12_RESOURCE_STATE_RENDER_TARGET;
		/// barriers[1].Transition.StateAfter = D3D12_RESOURCE_STATE_PRESENT; m_commandList-&gt;ResourceBarrier(_countof(barriers),
		/// barriers); ThrowIfFailed(m_commandList-&gt;Close()); } }</c>
		/// </para>
		/// <para>See <c>Example Code in the D3D12 Reference</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist-executeindirect void
		// ExecuteIndirect( [in] ID3D12CommandSignature *pCommandSignature, [in] UINT MaxCommandCount, [in] ID3D12Resource *pArgumentBuffer,
		// [in] UINT64 ArgumentBufferOffset, [in, optional] ID3D12Resource *pCountBuffer, [in] UINT64 CountBufferOffset );
		[PreserveSig]
		new void ExecuteIndirect([In] ID3D12CommandSignature pCommandSignature, uint MaxCommandCount, [In] ID3D12Resource pArgumentBuffer,
			ulong ArgumentBufferOffset, [In, Optional] ID3D12Resource? pCountBuffer, ulong CountBufferOffset);

		/// <summary>
		/// <para>Atomically copies a primary data element of type UINT from one resource to another, along with optional dependent resources.</para>
		/// <para>
		/// These 'dependent resources' are so-named because they depend upon the primary data element to locate them, typically the key
		/// element is an address, index, or other handle that refers to one or more the dependent resources indirectly.
		/// </para>
		/// <para>
		/// This function supports a primary data element of type UINT (32bit). A different version of this function,
		/// <c>AtomicCopyBufferUINT64</c>, supports a primary data element of type UINT64 (64bit).
		/// </para>
		/// </summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The resource that the UINT primary data element is copied into.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the destination resource buffer that specifies where the primary data element is copied into, in bytes. This
		/// offset combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT values.
		/// </para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The resource that the UINT primary data element is copied from. This data is typically an address, index, or other handle that
		/// shader code can use to locate the most-recent version of latency-sensitive information.
		/// </para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the source resource buffer that specifies where the primary data element is copied from, in bytes. This offset
		/// combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT values.
		/// </para>
		/// </param>
		/// <param name="Dependencies">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of dependent resources.</para>
		/// </param>
		/// <param name="ppDependentResources">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>An array of resources that contain the dependent elements of the data payload.</para>
		/// </param>
		/// <param name="pDependentSubresourceRanges">
		/// <para>Type: <b>const <c>D3D12_SUBRESOURCE_RANGE_UINT64</c>*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>
		/// An array of subresource ranges that specify the dependent elements of the data payload. These elements are completely updated
		/// before the primary data element is itself atomically copied. This ensures that the entire operation is logically atomic; that
		/// is, the primary data element never refers to an incomplete data payload.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method is typically used to update resources for which normal rendering pipeline latency can be detrimental to user
		/// experience. For example, an application can compute a view matrix from the latest user input (such as from the sensors of a
		/// head-mounted display), and use this function to update and activate this matrix in command lists already dispatched to the GPU
		/// to reduce perceived latency between input and rendering.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-atomiccopybufferuint void
		// AtomicCopyBufferUINT( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset, UINT
		// Dependencies, [in] ID3D12Resource * const *ppDependentResources, [in] const D3D12_SUBRESOURCE_RANGE_UINT64
		// *pDependentSubresourceRanges );
		[PreserveSig]
		new void AtomicCopyBufferUINT([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, int Dependencies,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D12Resource[] ppDependentResources,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_RANGE_UINT64[] pDependentSubresourceRanges);

		/// <summary>
		/// <para>Atomically copies a primary data element of type UINT64 from one resource to another, along with optional dependent resources.</para>
		/// <para>
		/// These 'dependent resources' are so-named because they depend upon the primary data element to locate them, typically the key
		/// element is an address, index, or other handle that refers to one or more the dependent resources indirectly.
		/// </para>
		/// <para>
		/// This function supports a primary data element of type UINT64 (64bit). A different version of this function,
		/// <c>AtomicCopyBufferUINT</c>, supports a primary data element of type UINT (32bit).
		/// </para>
		/// </summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The resource that the UINT64 primary data element is copied into.</para>
		/// </param>
		/// <param name="DstOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the destination resource buffer that specifies where the primary data element is copied into, in bytes. This
		/// offset combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT64 values.
		/// </para>
		/// </param>
		/// <param name="pSrcBuffer">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The resource that the UINT64 primary data element is copied from. This data is typically an address, index, or other handle that
		/// shader code can use to locate the most-recent version of latency-sensitive information.
		/// </para>
		/// </param>
		/// <param name="SrcOffset">
		/// <para>Type: <b>UINT64</b></para>
		/// <para>
		/// An offset into the source resource buffer that specifies where the primary data element is copied from, in bytes. This offset
		/// combined with the base address of the resource buffer must result in a memory address that's naturally aligned for UINT64 values.
		/// </para>
		/// </param>
		/// <param name="Dependencies">
		/// <para>Type: <b>UINT</b></para>
		/// <para>The number of dependent resources.</para>
		/// </param>
		/// <param name="ppDependentResources">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>An array of resources that contain the dependent elements of the data payload.</para>
		/// </param>
		/// <param name="pDependentSubresourceRanges">
		/// <para>Type: <b>const <c>D3D12_SUBRESOURCE_RANGE_UINT64</c>*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(Dependencies)</c></para>
		/// <para>
		/// An array of subresource ranges that specify the dependent elements of the data payload. These elements are completely updated
		/// before the primary data element is itself atomically copied. This ensures that the entire operation is logically atomic; that
		/// is, the primary data element never refers to an incomplete data payload.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method is typically used to update resources for which normal rendering pipeline latency can be detrimental to user
		/// experience. For example, an application can compute a view matrix from the latest user input (such as from the sensors of a
		/// head-mounted display), and use this function to update and activate this matrix in command lists already dispatched to the GPU
		/// to reduce perceived latency between input and rendering.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-atomiccopybufferuint64 void
		// AtomicCopyBufferUINT64( [in] ID3D12Resource *pDstBuffer, UINT64 DstOffset, [in] ID3D12Resource *pSrcBuffer, UINT64 SrcOffset,
		// UINT Dependencies, [in] ID3D12Resource * const *ppDependentResources, [in] const D3D12_SUBRESOURCE_RANGE_UINT64
		// *pDependentSubresourceRanges );
		[PreserveSig]
		new void AtomicCopyBufferUINT64([In] ID3D12Resource pDstBuffer, ulong DstOffset, [In] ID3D12Resource pSrcBuffer, ulong SrcOffset, int Dependencies,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D12Resource[] ppDependentResources,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D12_SUBRESOURCE_RANGE_UINT64[] pDependentSubresourceRanges);

		/// <summary>This method enables you to change the depth bounds dynamically.</summary>
		/// <param name="Min">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Specifies the minimum depth bounds. The default value is 0. NaN values silently convert to 0.</para>
		/// </param>
		/// <param name="Max">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Specifies the maximum depth bounds. The default value is 1. NaN values silently convert to 0.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Depth-bounds testing allows pixels and samples to be discarded if the currently-stored depth value is outside the range
		/// specified by <i>Min</i> and <i>Max</i>, inclusive. If the currently-stored depth value of the pixel or sample is inside this
		/// range, then the depth-bounds test passes and it is rendered; otherwise, the depth-bounds test fails and the pixel or sample is
		/// discarded. Note that the depth-bounds test considers the currently-stored depth value, not the depth value generated by the
		/// executing pixel shader.
		/// </para>
		/// <para>
		/// To use depth-bounds testing, the application must use the new <c>CreatePipelineState</c> method to enable depth-bounds testing
		/// on the PSO and then can use this command list method to change the depth-bounds dynamically.
		/// </para>
		/// <para>
		/// OMSetDepthBounds is an optional feature. Use the <c>CheckFeatureSupport</c> method to determine whether or not this feature is
		/// supported by the user-mode driver. Support for this feature is reported through the <c>D3D12_FEATURE_D3D12_OPTIONS2</c> structure.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-omsetdepthbounds void
		// OMSetDepthBounds( [in] FLOAT Min, [in] FLOAT Max );
		[PreserveSig]
		new void OMSetDepthBounds(float Min, float Max);

		/// <summary>This method configures the sample positions used by subsequent draw, copy, resolve, and similar operations.</summary>
		/// <param name="NumSamplesPerPixel">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Specifies the number of samples to take, per pixel. This value can be 1, 2, 4, 8, or 16, otherwise the SetSamplePosition call is
		/// dropped. The number of samples must match the sample count configured in the PSO at draw time, otherwise the behavior is undefined.
		/// </para>
		/// </param>
		/// <param name="NumPixels">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Specifies the number of pixels that sample patterns are being specified for. This value can be either 1 or 4, otherwise the
		/// SetSamplePosition call is dropped. A value of 1 configures a single sample pattern to be used for each pixel; a value of 4
		/// configures separate sample patterns for each pixel in a 2x2 pixel grid which is repeated over the render-target or viewport
		/// space, aligned to even coordinates.
		/// </para>
		/// <para>
		/// Note that the maximum number of combined samples can't exceed 16, otherwise the call is dropped. If NumPixels is set to 4,
		/// NumSamplesPerPixel can specify no more than 4 samples.
		/// </para>
		/// </param>
		/// <param name="pSamplePositions">
		/// <para>Type: <b><c>D3D12_SAMPLE_POSITION</c>*</b></para>
		/// <para><c>SAL</c>: <c>In_reads(NumSamplesPerPixel*NumPixels)</c></para>
		/// <para>
		/// Specifies an array of D3D12_SAMPLE_POSITION elements. The size of the array is NumPixels * NumSamplesPerPixel. If NumPixels is
		/// set to 4, then the first group of sample positions corresponds to the upper-left pixel in the 2x2 grid of pixels; the next group
		/// of sample positions corresponds to the upper-right pixel, the next group to the lower-left pixel, and the final group to the
		/// lower-right pixel.
		/// </para>
		/// <para>
		/// If centroid interpolation is used during rendering, the order of positions for each pixel determines centroid-sampling priority.
		/// That is, the first covered sample in the order specified is chosen as the centroid sample location.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The operational semantics of sample positions are determined by the various draw, copy, resolve, and other operations that can occur.
		/// </para>
		/// <para>
		/// <b>CommandList:</b> In the absence of any prior calls to SetSamplePositions in a CommandList, samples assume the default
		/// position based on the Pipeline State Object (PSO). The default positions are determined either by the SAMPLE_DESC portion of the
		/// PSO if it is present, or by the standard sample positions if the RASTERIZER_DESC portion of the PSO has ForcedSampleCount set to
		/// a value greater than 0.
		/// </para>
		/// <para>
		/// After SetSamplePosition has been called, subsequent draw calls must use a PSO that specifies a matching sample count either
		/// using the SAMPLE_DESC portion of the PSO, or ForcedSampleCount in the RASTERIZER_DESC portion of the PSO.
		/// </para>
		/// <para>
		/// SetSamplePositions can only be called on a graphics CommandList. It can't be called in a bundle; bundles inherit sample position
		/// state from the calling CommandList and don't modify it.
		/// </para>
		/// <para>Calling SetSamplePositions(0, 0, NULL) reverts the sample positions to their default values.</para>
		/// <para><b>Clear RenderTarget:</b> Sample positions are ignored when clearing a render target.</para>
		/// <para>
		/// <b>Clear DepthStencil:</b> When clearing the depth portion of a depth-stencil surface or any region of it, the sample positions
		/// must be set to match those of future rendering to the cleared surface or region; the contents of any uncleared regions produced
		/// using different sample positions become undefined.
		/// </para>
		/// <para>When clearing the stencil portion of a depth-stencil surface or any region of it, the sample positions are ignored.</para>
		/// <para>
		/// <b>Draw to RenderTarget:</b> When drawing to a render target the sample positions can be changed for each draw call, even when
		/// drawing to a region that overlaps previous draw calls. The current sample positions determine the operational semantics of each
		/// draw call and samples are taken from taken from the stored contents of the render target, even if the contents were produced
		/// using different sample positions.
		/// </para>
		/// <para>
		/// <b>Draw using DepthStencil:</b> When drawing to a depth-stencil surface (read or write) or any region of it, the sample
		/// positions must be set to match those used to clear the affected region previously. To use a different sample position, the
		/// target region must be cleared first. The pixels outside the clear region are unaffected.
		/// </para>
		/// <para>
		/// Hardware may store the depth portion or a depth-stencil surface as plane equations, and evaluate them to produce depth values
		/// when the application issues a read. Only the rasterizer and output-merger are required to support programmable sample positions
		/// of the depth portion of a depth-stencil surface. Any other read or write of the depth portion that has been rendered with sample
		/// positions set may ignore them and instead sample at the standard positions.
		/// </para>
		/// <para>
		/// <b>Resolve RenderTarget:</b> When resolving a render target or any region of it, the sample positions are ignored; these APIs
		/// operate only on stored color values.
		/// </para>
		/// <para>
		/// <b>Resolve DepthStencil:</b> When resolving the depth portion of a depth-stencil surface or any region of it, the sample
		/// positions must be set to match those of past rendering to the resolved surface or region. To use a different sample position,
		/// the target region must be cleared first.
		/// </para>
		/// <para>
		/// When resolving the stencil portion of a depth-stencil surface or any region of it, the sample positions are ignored; stencil
		/// resolves operate only on stored stencil values.
		/// </para>
		/// <para>
		/// <b>Copy RenderTarget:</b> When copying from a render target, the sample positions are ignored regardless of whether it is a full
		/// or partial copy.
		/// </para>
		/// <para>
		/// <b>Copy DepthStencil (Full Subresource):</b> When copying a full subresource from a depth-stencil surface, the sample positions
		/// must be set to match the sample positions used to generate the source surface. To use a different sample position, the target
		/// region must be cleared first.
		/// </para>
		/// <para>
		/// On some hardware properties of the source surface (such as stored plane equations for depth values) transfer to the destination.
		/// Therefore, if the destination surface is subsequently drawn to, the sample positions originally used to generate the source
		/// content need to be used with the destination surface. The API requires this on all hardware for consistency even if it may only
		/// apply to some.
		/// </para>
		/// <para>
		/// <b>Copy DepthStencil (Partial Subresource):</b> When copying a partial subresource from a depth-stencil surface, the sample
		/// positions must be set to match the sample positions used to generate the source surface, similarly to copying a full
		/// subresource. However, if the content of an affected destination subresources is only partially covered by the copy, the contents
		/// of the uncovered portion within those subresources becomes undefined unless all of it was generated using the same sample
		/// positions as the copy source. To use a different sample position, the target region must be cleared first.
		/// </para>
		/// <para>
		/// When copying a partial subresource from the stencil portion of a depth-stencil surface, the sample postions are ignored. It
		/// doesn�t matter what sample positions were used to generate content for any other areas of the destination buffer not covered by
		/// the copy � those contents remain valid.
		/// </para>
		/// <para>
		/// <b>Shader SamplePos:</b> The HLSL SamplePos intrinsic is not aware of programmable sample positions and results returned to
		/// shaders calling this on a surface rendered with programmable positions is undefined. Applications must pass coordinates into
		/// their shader manually if needed. Similarly evaluating attributes by sample index is undefined with programmable sample positions.
		/// </para>
		/// <para>
		/// <b>Transitioning out of DEPTH_READ or DEPTH_WRITE state:</b> If a subresource in DEPTH_READ or DEPTH_WRITE state is transitioned
		/// to any other state, including COPY_SOURCE or RESOLVE_SOURCE, some hardware might need to decompress the surface. Therefore, the
		/// sample positions must be set on the command list to match those used to generate the content in the source surface. Furthermore,
		/// for any subsequent transitions of the surface while the same depth data remains in it, the sample positions must continue to
		/// match those set on the command list. To use a different sample position, the target region must be cleared first.
		/// </para>
		/// <para>
		/// If an application wants to minimize the decompressed area when only a portion needs to be used, or just to preserve compression,
		/// ResolveSubresourceRegion() can be called in DECOMPRESS mode with a rect specified. This will decompress just the relevant area
		/// to a separate resource leaving the source intact on some hardware, though on other hardware even the source area is
		/// decompressed. The separate explicitly decompressed resource can then be transitioned to the desired state (such as SHADER_RESOURCE).
		/// </para>
		/// <para>
		/// <b>Transitioning out of RENDER_TARGET state:</b> If a subresource in RENDER_TARGET state is transitioned to anything other than
		/// COPY_SOURCE or RESOLVE_SOURCE, some implementations may need to decompress the surface. This decompression is agnostic to sample positions.
		/// </para>
		/// <para>
		/// If an application wants to minimize the decompressed area when only a portion needs to be used, or just to preserve compression,
		/// ResolveSubresourceRegion() can be called in DECOMPRESS mode with a rect specified. This will decompress just the relevant area
		/// to a separate resource leaving the source intact on some hardware, though on other hardware even the source area is
		/// decompressed. The separate explicitly decompressed resource can then be transitioned to the desired state (such as SHADER_RESOURCE).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-setsamplepositions void
		// SetSamplePositions( [in] UINT NumSamplesPerPixel, [in] UINT NumPixels, [in] D3D12_SAMPLE_POSITION *pSamplePositions );
		[PreserveSig]
		new void SetSamplePositions(uint NumSamplesPerPixel, uint NumPixels,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D12_SAMPLE_POSITION[] pSamplePositions);

		/// <summary>Copy a region of a multisampled or compressed resource into a non-multisampled or non-compressed resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// Destination resource. Must be created with the <b>D3D11_USAGE_DEFAULT</b> flag and must be single-sampled unless its to be
		/// resolved from a compressed resource ( <b>D3D12_RESOLVE_MODE_DECOMPRESS</b>); in this case it must have the same sample count as
		/// the compressed source.
		/// </para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// A zero-based index that identifies the destination subresource. Use <c>D3D12CalcSubresource</c> to calculate the subresource
		/// index if the parent resource is complex.
		/// </para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The X coordinate of the left-most edge of the destination region. The width of the destination region is the same as the width
		/// of the source rect.
		/// </para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>
		/// The Y coordinate of the top-most edge of the destination region. The height of the destination region is the same as the height
		/// of the source rect.
		/// </para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <b>ID3D12Resource*</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Source resource. Must be multisampled or compressed.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <b>UINT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>A zero-based index that identifies the source subresource.</para>
		/// </param>
		/// <param name="pSrcRect">
		/// <para>Type: <b>D3D12_RECT*</b></para>
		/// <para><c>SAL</c>: <c>In_opt</c></para>
		/// <para>
		/// Specifies the rectangular region of the source resource to be resolved. Passing NULL for <i>pSrcRect</i> specifies that the
		/// entire subresource is to be resolved.
		/// </para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <b>DXGI_FORMAT</b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>A DXGI_FORMAT that specifies how the source and destination resource formats are consolidated.</para>
		/// </param>
		/// <param name="ResolveMode">
		/// <para>Type: <b><c>D3D12_RESOLVE_MODE</c></b></para>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>Specifies the operation used to resolve the source samples.</para>
		/// <para>
		/// When using the <b>D3D12_RESOLVE_MODE_DECOMPRESS</b> operation, the sample count can be larger than 1 as long as the source and
		/// destination have the same sample count, and source and destination may specify the same resource as long as the source rect
		/// aligns with the destination X and Y coordinates, in which case decompression occurs in place.
		/// </para>
		/// <para>
		/// When using the <b>D3D12_RESOLVE_MODE_MIN</b>, <b>D3D12_RESOLVE_MODE_MAX</b>, or <b>D3D12_RESOLVE_MODE_AVERAGE</b> operation, the
		/// destination must have a sample count of 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// ResolveSubresourceRegion operates like <c>ResolveSubresource</c> but allows for only part of a resource to be resolved and for
		/// source samples to be resolved in several ways. Partial resolves can be useful in multi-adapter scenarios; for example, when the
		/// rendered area has been partitioned across adapters, each adapter might only need to resolve the portion of a subresource that
		/// corresponds to its assigned partition.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-resolvesubresourceregion void
		// ResolveSubresourceRegion( [in] ID3D12Resource *pDstResource, [in] UINT DstSubresource, [in] UINT DstX, [in] UINT DstY, [in]
		// ID3D12Resource *pSrcResource, [in] UINT SrcSubresource, [in, optional] D3D12_RECT *pSrcRect, [in] DXGI_FORMAT Format, [in]
		// D3D12_RESOLVE_MODE ResolveMode );
		[PreserveSig]
		new void ResolveSubresourceRegion([In] ID3D12Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, [In] ID3D12Resource pSrcResource,
			uint SrcSubresource, [In, Optional] PRECT? pSrcRect, DXGI_FORMAT Format, D3D12_RESOLVE_MODE ResolveMode);

		/// <summary>Set a mask that controls which view instances are enabled for subsequent draws.</summary>
		/// <param name="Mask">
		/// <para>Type: <b>UINT</b></para>
		/// <para>
		/// A mask that specifies which views are enabled or disabled. If bit <i>i</i> starting from the least-significant bit is set, view
		/// instance <i>i</i> is enabled.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The view instance mask only affects PSOs that declare view instance masking by specifying the
		/// D3D12_VIEW_INSTANCING_FLAG_ENABLE_VIEW_INSTANCE_MASKING flag during their creation. Attempting to create a PSO that declares
		/// view instance masking will fail on adapters that don't support view instancing.
		/// </para>
		/// <para>
		/// The view instance mask defaults to 0 which disables all views. This forces applications that declare view instance masking to
		/// explicitly choose the views to enable, otherwise nothing will be rendered. If the view instance mask enabled all views by
		/// default the application might not remember to disable unused views, resulting in lost performance due to wasted work.
		/// </para>
		/// <para>
		/// Bundles don't inherit their view instance mask from their caller, defaulting to 0 instead. This is because the mask setting must
		/// be known when the bundle is recorded if it affects how an implementation records draws. The view instance mask set by a bundle
		/// does persist to the caller after the bundle completes, however. These inheritance semantics are similar to those of PSOs.
		/// </para>
		/// <para>
		/// No shader code paths that are dependent on SV_ViewID are executed at any shader stage for view instances that are masked off and
		/// no clipping, viewport processing, or rasterization is performed. Implementations that inspect the mask during rendering can
		/// incur a small performance penalty over PSOs that don't declare view instance masking at all, but usually the penalty can be
		/// overcome by the performance savings that result from skipping the work associated with the masked off views. Depending on the
		/// frequency and amount of skipped work, the performance gains can be significant.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist1-setviewinstancemask void
		// SetViewInstanceMask( [in] UINT Mask );
		[PreserveSig]
		new void SetViewInstanceMask(uint Mask);

		/// <summary>Writes a number of 32-bit immediate values to the specified buffer locations directly from the command stream.</summary>
		/// <param name="Count">
		/// The number of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures that are pointed to by <i>pParams</i> and <i>pModes</i>.
		/// </param>
		/// <param name="pParams">
		/// The address of an array containing a number of <c>D3D12_WRITEBUFFERIMMEDIATE_PARAMETER</c> structures equal to <i>Count</i>.
		/// </param>
		/// <param name="pModes">
		/// The address of an array containing a number of <c>D3D12_WRITEBUFFERIMMEDIATE_MODE</c> structures equal to <i>Count</i>. The
		/// default value is <b>null</b>; passing <b>null</b> causes the system to write all immediate values using <b>D3D12_WRITEBUFFERIMMEDIATE_MODE_DEFAULT</b>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// <b>WriteBufferImmediate</b> performs <i>Count</i> number of 32-bit writes: one for each value and destination specified in <i>pParams</i>.
		/// </para>
		/// <para>
		/// The receiving buffer (resource) must be in the <b>D3D12_RESOURCE_STATE_COPY_DEST</b> state to be a valid destination for <b>WriteBufferImmediate</b>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12graphicscommandlist2-writebufferimmediate void
		// WriteBufferImmediate( UINT Count, [in] const D3D12_WRITEBUFFERIMMEDIATE_PARAMETER *pParams, [in, optional] const
		// D3D12_WRITEBUFFERIMMEDIATE_MODE *pModes );
		[PreserveSig]
		void WriteBufferImmediate(int Count, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_PARAMETER[] pParams,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D12_WRITEBUFFERIMMEDIATE_MODE[] pModes);
	}
}