global using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke;

/// <summary>Provides methods and types for working with Direct3D 11.</summary>
public static partial class D3D11
{
	/// <summary>This interface encapsulates methods for retrieving data from the GPU asynchronously.</summary>
	/// <remarks>
	/// <para>There are three types of asynchronous interfaces, all of which inherit this interface:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>ID3D11Query - Queries information from the GPU.</description>
	/// </item>
	/// <item>
	/// <description>
	/// ID3D11Predicate - Determines whether a piece of geometry should be processed or not depending on the results of a previous draw call.
	/// </description>
	/// </item>
	/// <item>
	/// <description>ID3D11Counter - Measures GPU performance.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11asynchronous
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Asynchronous")]
	[ComImport, Guid("4b35d0cd-1e15-4258-9c98-1b1333f6dd3b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Asynchronous : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the size of the data (in bytes) that is output when calling ID3D11DeviceContext::GetData.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the data (in bytes) that is output when calling GetData.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11asynchronous-getdatasize UINT GetDataSize();
		[PreserveSig]
		uint GetDataSize();
	}

	/// <summary>Provides a communication channel with the graphics driver or the Microsoft Direct3D runtime.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateAuthenticatedChannel.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11authenticatedchannel
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11AuthenticatedChannel")]
	[ComImport, Guid("3015a308-dcbd-47aa-a747-192486d14d4a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11AuthenticatedChannel : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the size of the driver's certificate chain.</summary>
		/// <param name="pCertificateSize">Receives the size of the certificate chain, in bytes.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11authenticatedchannel-getcertificatesize HRESULT
		// GetCertificateSize( [out] UINT *pCertificateSize );
		[PreserveSig]
		HRESULT GetCertificateSize(out uint pCertificateSize);

		/// <summary>Gets the driver's certificate chain.</summary>
		/// <param name="CertificateSize">
		/// The size of the <c>pCertificate</c> array, in bytes. To get the size of the certificate chain, call ID3D11CryptoSession::GetCertificateSize.
		/// </param>
		/// <param name="pCertificate">
		/// A pointer to a byte array that receives the driver's certificate chain. The caller must allocate the array.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11authenticatedchannel-getcertificate HRESULT
		// GetCertificate( [in] UINT CertificateSize, [out] BYTE *pCertificate );
		[PreserveSig]
		HRESULT GetCertificate(int CertificateSize, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pCertificate);

		/// <summary>Gets a handle to the authenticated channel.</summary>
		/// <param name="pChannelHandle">Receives a handle to the channel.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11authenticatedchannel-getchannelhandle void
		// GetChannelHandle( [out] HANDLE *pChannelHandle );
		[PreserveSig]
		void GetChannelHandle(out HANDLE pChannelHandle);
	}

	/// <summary>The blend-state interface holds a description for blending state that you can bind to the output-merger stage.</summary>
	/// <remarks>
	/// <para>
	/// Blending applies a simple function to combine output values from a pixel shader with data in a render target. You have control over
	/// how the pixels are blended by using a predefined set of blending operations and preblending operations.
	/// </para>
	/// <para>
	/// To create a blend-state object, call ID3D11Device::CreateBlendState. To bind the blend-state object to the output-merger stage, call ID3D11DeviceContext::OMSetBlendState.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11blendstate
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11BlendState")]
	[ComImport, Guid("75b68faa-347d-4159-8f45-a0640f01cd9a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11BlendState : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the description for blending state that you used to create the blend-state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_BLEND_DESC*</c></para>
		/// <para>A pointer to a D3D11_BLEND_DESC structure that receives a description of the blend state.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// You use the description for blending state in a call to the ID3D11Device::CreateBlendState method to create the blend-state object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11blendstate-getdesc void GetDesc( [out] D3D11_BLEND_DESC
		// *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_BLEND_DESC pDesc);
	}

	/// <summary>
	/// A buffer interface accesses a buffer resource, which is unstructured memory. Buffers typically store vertex or index data.
	/// </summary>
	/// <remarks>
	/// <para>There are three types of buffers: vertex, index, or a shader-constant buffer. Create a buffer resource by calling ID3D11Device::CreateBuffer.</para>
	/// <para>
	/// A buffer must be bound to the pipeline before it can be accessed. Buffers can be bound to the input-assembler stage by calls to
	/// ID3D11DeviceContext::IASetVertexBuffers and ID3D11DeviceContext::IASetIndexBuffer, to the stream-output stage by a call to
	/// ID3D11DeviceContext::SOSetTargets, and to a shader stage by calling the appropriate shader method (such as
	/// ID3D11DeviceContext::VSSetConstantBuffers for example).
	/// </para>
	/// <para>
	/// Buffers can be bound to multiple pipeline stages simultaneously for reading. A buffer can also be bound to a single pipeline stage
	/// for writing; however, the same buffer cannot be bound for reading and writing simultaneously.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11buffer
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Buffer")]
	[ComImport, Guid("48570b85-d1ee-4fcd-a250-eb350722b037"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Buffer : ID3D11Resource, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the type of the resource.</summary>
		/// <param name="pResourceDimension">
		/// <para>Type: <c>D3D11_RESOURCE_DIMENSION*</c></para>
		/// <para>Pointer to the resource type (see D3D11_RESOURCE_DIMENSION).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-gettype void GetType( [out]
		// D3D11_RESOURCE_DIMENSION *pResourceDimension );
		[PreserveSig]
		new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		/// <summary>Set the eviction priority of a resource.</summary>
		/// <param name="EvictionPriority">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Eviction priority for the resource, which is one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Resource priorities determine which resource to evict from video memory when the system has run out of video memory. The
		/// resource will not be lost; it will be removed from video memory and placed into system memory, or possibly placed onto the hard
		/// drive. The resource will be loaded back into video memory when it is required.
		/// </para>
		/// <para>
		/// A resource that is set to the maximum priority, DXGI_RESOURCE_PRIORITY_MAXIMUM, is only evicted if there is no other way of
		/// resolving the incoming memory request. The Windows Display Driver Model (WDDM) tries to split an incoming memory request to its
		/// minimum size and evict lower-priority resources before evicting a resource with maximum priority.
		/// </para>
		/// <para>
		/// Changing the priorities of resources should be done carefully. The wrong eviction priorities could be a detriment to performance
		/// rather than an improvement.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-setevictionpriority void SetEvictionPriority(
		// [in] UINT EvictionPriority );
		[PreserveSig]
		new void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority of a resource.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>One of the following values, which specifies the eviction priority for the resource:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-getevictionpriority UINT GetEvictionPriority();
		[PreserveSig]
		new uint GetEvictionPriority();

		/// <summary>Get the properties of a buffer resource.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_BUFFER_DESC*</c></para>
		/// <para>Pointer to a resource description (see D3D11_BUFFER_DESC) filled in by the method.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11buffer-getdesc void GetDesc( [out] D3D11_BUFFER_DESC
		// *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_BUFFER_DESC pDesc);
	}

	/// <summary>This interface encapsulates an HLSL class.</summary>
	/// <remarks>
	/// This interface is created by calling ID3D11ClassLinkage::CreateClassInstance. The interface is used when binding shader resources to
	/// the pipeline using APIs such as ID3D11DeviceContext::VSSetShader.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11classinstance
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11ClassInstance")]
	[ComImport, Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ClassInstance : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the ID3D11ClassLinkage object associated with the current HLSL class.</summary>
		/// <param name="ppLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage**</c></para>
		/// <para>A pointer to a ID3D11ClassLinkage interface pointer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For more information about using the ID3D11ClassInstance interface, see Dynamic Linking.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-getclasslinkage void GetClassLinkage(
		// [out] ID3D11ClassLinkage **ppLinkage );
		[PreserveSig]
		void GetClassLinkage(out ID3D11ClassLinkage ppLinkage);

		/// <summary>Gets a description of the current HLSL class.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_CLASS_INSTANCE_DESC*</c></para>
		/// <para>A pointer to a D3D11_CLASS_INSTANCE_DESC structure that describes the current HLSL class.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For more information about using the ID3D11ClassInstance interface, see Dynamic Linking.</para>
		/// <para>
		/// An instance is not restricted to being used for a single type in a single shader. An instance is flexible and can be used for
		/// any shader that used the same type name or instance name when the instance was generated.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// A created instance will work for any shader that contains a type of the same type name. For instance, a class instance created
		/// with the type name <c>DefaultShader</c> would work in any shader that contained a type <c>DefaultShader</c> even though several
		/// shaders could describe a different type.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// A gotten instance maps directly to an instance name/index in a shader. A class instance acquired using GetClassInstance will
		/// work for any shader that contains a class instance of the name used to generate the runtime instance, the instance does not have
		/// to be the same type in all of the shaders it's used in.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// An instance does not replace the importance of reflection for a particular shader since a gotten instance will not know its slot
		/// location and a created instance only specifies a type name.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-getdesc void GetDesc( [out]
		// D3D11_CLASS_INSTANCE_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_CLASS_INSTANCE_DESC pDesc);

		/// <summary>Gets the instance name of the current HLSL class.</summary>
		/// <param name="pInstanceName">
		/// <para>Type: <c>LPSTR</c></para>
		/// <para>The instance name of the current HLSL class.</para>
		/// </param>
		/// <param name="pBufferLength">
		/// <para>Type: <c>SIZE_T*</c></para>
		/// <para>The length of the <c>pInstanceName</c> parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>GetInstanceName will return a valid name only for instances acquired using ID3D11ClassLinkage::GetClassInstance.</para>
		/// <para>For more information about using the ID3D11ClassInstance interface, see Dynamic Linking.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-getinstancename void GetInstanceName(
		// [out, optional] LPSTR pInstanceName, [in, out] SIZE_T *pBufferLength );
		[PreserveSig]
		void GetInstanceName([Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pInstanceName, ref SizeT pBufferLength);

		/// <summary>Gets the type of the current HLSL class.</summary>
		/// <param name="pTypeName">
		/// <para>Type: <c>LPSTR</c></para>
		/// <para>Type of the current HLSL class.</para>
		/// </param>
		/// <param name="pBufferLength">
		/// <para>Type: <c>SIZE_T*</c></para>
		/// <para>The length of the <c>pTypeName</c> parameter.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>GetTypeName will return a valid name only for instances acquired using ID3D11ClassLinkage::GetClassInstance.</para>
		/// <para>For more information about using the ID3D11ClassInstance interface, see Dynamic Linking.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11classinstance-gettypename void GetTypeName( [out,
		// optional] LPSTR pTypeName, [in, out] SIZE_T *pBufferLength );
		[PreserveSig]
		void GetTypeName([Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pTypeName, ref SizeT pBufferLength);
	}

	/// <summary>This interface encapsulates an HLSL dynamic linkage.</summary>
	/// <remarks>
	/// <para>
	/// A class linkage object can hold up to 64K gotten instances. A gotten instance is a handle that references a variable name in any
	/// shader that is created with that linkage object. When you create a shader with a class linkage object, the runtime gathers these
	/// instances and stores them in the class linkage object. For more information about how a class linkage object is used, see Storing
	/// Variables and Types for Shaders to Share.
	/// </para>
	/// <para>An <c>ID3D11ClassLinkage</c> object is created using the ID3D11Device::CreateClassLinkage method.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11classlinkage
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11ClassLinkage")]
	[ComImport, Guid("ddf57cba-9543-46e4-a12b-f207a0fe7fed"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ClassLinkage : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the class-instance object that represents the specified HLSL class.</summary>
		/// <param name="pClassInstanceName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The name of a class for which to get the class instance.</para>
		/// </param>
		/// <param name="InstanceIndex">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The index of the class instance.</para>
		/// </param>
		/// <param name="ppInstance">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>The address of a pointer to an ID3D11ClassInstance interface to initialize.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>For more information about using the ID3D11ClassLinkage interface, see Dynamic Linking.</para>
		/// <para>
		/// A class instance must have at least 1 data member in order to be available for the runtime to use with
		/// <c>ID3D11ClassLinkage::GetClassInstance</c>. Any instance with no members will be optimized out of a compiled shader blob as a
		/// zero-sized object. If you have a class with no data members, use ID3D11ClassLinkage::CreateClassInstance instead.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11classlinkage-getclassinstance HRESULT GetClassInstance(
		// [in] LPCSTR pClassInstanceName, [in] UINT InstanceIndex, [out] ID3D11ClassInstance **ppInstance );
		[PreserveSig]
		HRESULT GetClassInstance([MarshalAs(UnmanagedType.LPStr)] string pClassInstanceName, uint InstanceIndex,
			out ID3D11ClassInstance ppInstance);

		/// <summary>Initializes a class-instance object that represents an HLSL class instance.</summary>
		/// <param name="pClassTypeName">
		/// <para>Type: <c>LPCSTR</c></para>
		/// <para>The type name of a class to initialize.</para>
		/// </param>
		/// <param name="ConstantBufferOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Identifies the constant buffer that contains the class data.</para>
		/// </param>
		/// <param name="ConstantVectorOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is
		/// not a byte offset.
		/// </para>
		/// </param>
		/// <param name="TextureOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The texture slot for the first texture; there may be multiple textures following the offset.</para>
		/// </param>
		/// <param name="SamplerOffset">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The sampler slot for the first sampler; there may be multiple samplers following the offset.</para>
		/// </param>
		/// <param name="ppInstance">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>The address of a pointer to an ID3D11ClassInstance interface to initialize.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Instances can be created (or gotten) before or after a shader is created. Use the same shader linkage object to acquire a class
		/// instance and create the shader the instance is going to be used in.
		/// </para>
		/// <para>For more information about using the ID3D11ClassLinkage interface, see Dynamic Linking.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11classlinkage-createclassinstance HRESULT
		// CreateClassInstance( [in] LPCSTR pClassTypeName, [in] UINT ConstantBufferOffset, [in] UINT ConstantVectorOffset, [in] UINT
		// TextureOffset, [in] UINT SamplerOffset, [out] ID3D11ClassInstance **ppInstance );
		[PreserveSig]
		HRESULT CreateClassInstance([MarshalAs(UnmanagedType.LPStr)] string pClassTypeName, uint ConstantBufferOffset, uint ConstantVectorOffset,
			uint TextureOffset, uint SamplerOffset, out ID3D11ClassInstance ppInstance);
	}

	/// <summary>The <c>ID3D11CommandList</c> interface encapsulates a list of graphics commands for play back.</summary>
	/// <remarks>
	/// There is no explicit creation method, simply declare an <c>ID3D11CommandList</c> interface, then call
	/// ID3D11DeviceContext::FinishCommandList to record commands or ID3D11DeviceContext::ExecuteCommandList to play back commands.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11commandlist
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11CommandList")]
	[ComImport, Guid("a24bc4d1-769e-43f7-8013-98ff566c18e2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11CommandList : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the initialization flags associated with the deferred context that created the command list.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The context flag is reserved for future use and is always 0.</para>
		/// </returns>
		/// <remarks>
		/// The GetContextFlags method gets the flags that were supplied to the <c>ContextFlags</c> parameter of
		/// ID3D11Device::CreateDeferredContext; however, the context flag is reserved for future use.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11commandlist-getcontextflags UINT GetContextFlags();
		[PreserveSig]
		uint GetContextFlags();
	}

	/// <summary>A compute-shader interface manages an executable program (a compute shader) that controls the compute-shader stage.</summary>
	/// <remarks>
	/// <para>
	/// The compute-shader interface has no methods; use HLSL to implement your shader functionality. All shaders are implemented from a
	/// common set of features referred to as the common-shader core..
	/// </para>
	/// <para>
	/// To create a compute-shader interface, call ID3D11Device::CreateComputeShader. Before using a compute shader you must bind it to the
	/// device by calling ID3D11DeviceContext::CSSetShader.
	/// </para>
	/// <para>This interface is defined in D3D11.h.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11computeshader
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11ComputeShader")]
	[ComImport, Guid("4f5b196e-c2bd-495e-bd01-1fded38e4969"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ComputeShader : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>This interface encapsulates methods for measuring GPU performance.</summary>
	/// <remarks>
	/// <para>A counter can be created with ID3D11Device::CreateCounter.</para>
	/// <para>This is a derived class of ID3D11Asynchronous.</para>
	/// <para>
	/// Counter data is gathered by issuing an ID3D11DeviceContext::Begin command, issuing some graphics commands, issuing an
	/// ID3D11DeviceContext::End command, and then calling ID3D11DeviceContext::GetData to get data about what happened in between the Begin
	/// and End calls. The data returned by GetData will be different depending on the type of counter. The call to End causes the data
	/// returned by GetData to be accurate up until the last call to End.
	/// </para>
	/// <para>Counters are best suited for profiling.</para>
	/// <para>For a list of the types of performance counters, see D3D11_COUNTER.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11counter
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Counter")]
	[ComImport, Guid("6e8c49fb-a371-4770-b440-29086022b741"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Counter : ID3D11Asynchronous, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the size of the data (in bytes) that is output when calling ID3D11DeviceContext::GetData.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the data (in bytes) that is output when calling GetData.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11asynchronous-getdatasize UINT GetDataSize();
		[PreserveSig]
		new uint GetDataSize();

		/// <summary>Get a counter description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_COUNTER_DESC*</c></para>
		/// <para>Pointer to a counter description (see D3D11_COUNTER_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11counter-getdesc void GetDesc( [out] D3D11_COUNTER_DESC
		// *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_COUNTER_DESC pDesc);
	}

	/// <summary>Represents a cryptographic session.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateCryptoSession.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11cryptosession
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11CryptoSession")]
	[ComImport, Guid("9b32f9ad-bdcc-40a6-a39d-d5c865845720"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11CryptoSession : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the type of encryption that is supported by this session.</summary>
		/// <param name="pCryptoType">
		/// <para>Receives a GUID that specifies the encryption type. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>The application specifies the encryption type when it creates the session.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11cryptosession-getcryptotype void GetCryptoType( [out]
		// GUID *pCryptoType );
		[PreserveSig]
		void GetCryptoType(out Guid pCryptoType);

		/// <summary>Gets the decoding profile of the session.</summary>
		/// <param name="pDecoderProfile">Receives the decoding profile. For a list of possible values, see ID3D11VideoDevice::GetVideoDecoderProfile.</param>
		/// <returns>None</returns>
		/// <remarks>The application specifies the profile when it creates the session.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11cryptosession-getdecoderprofile void GetDecoderProfile(
		// [out] GUID *pDecoderProfile );
		[PreserveSig]
		void GetDecoderProfile(out Guid pDecoderProfile);

		/// <summary>Gets the size of the driver's certificate chain.</summary>
		/// <param name="pCertificateSize">Receives the size of the certificate chain, in bytes.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>To get the certificate, call ID3D11CryptoSession::GetCertificate.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11cryptosession-getcertificatesize HRESULT
		// GetCertificateSize( [out] UINT *pCertificateSize );
		[PreserveSig]
		HRESULT GetCertificateSize(out uint pCertificateSize);

		/// <summary>Gets the driver's certificate chain.</summary>
		/// <param name="CertificateSize">
		/// The size of the <c>pCertificate</c> array, in bytes. To get the size of the certificate chain, call ID3D11CryptoSession::GetCertificateSize.
		/// </param>
		/// <param name="pCertificate">
		/// A pointer to a byte array that receives the driver's certificate chain. The caller must allocate the array.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11cryptosession-getcertificate HRESULT GetCertificate(
		// [in] UINT CertificateSize, [out] BYTE *pCertificate );
		[PreserveSig]
		HRESULT GetCertificate(int CertificateSize, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] pCertificate);

		/// <summary>Gets a handle to the cryptographic session.</summary>
		/// <param name="pCryptoSessionHandle">Receives a handle to the session.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// You can use this handle to associate the session with a decoder. This enables the decoder to decrypt data that is encrypted
		/// using this session.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11cryptosession-getcryptosessionhandle void
		// GetCryptoSessionHandle( [out] HANDLE *pCryptoSessionHandle );
		[PreserveSig]
		void GetCryptoSessionHandle(out HANDLE pCryptoSessionHandle);
	}

	/// <summary>
	/// The depth-stencil-state interface holds a description for depth-stencil state that you can bind to the output-merger stage.
	/// </summary>
	/// <remarks>
	/// To create a depth-stencil-state object, call ID3D11Device::CreateDepthStencilState. To bind the depth-stencil-state object to the
	/// output-merger stage, call ID3D11DeviceContext::OMSetDepthStencilState.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11depthstencilstate
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11DepthStencilState")]
	[ComImport, Guid("03823efb-8d8f-4e1c-9aa2-f64bb2cbfdf1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DepthStencilState : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the description for depth-stencil state that you used to create the depth-stencil-state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_DEPTH_STENCIL_DESC*</c></para>
		/// <para>A pointer to a D3D11_DEPTH_STENCIL_DESC structure that receives a description of the depth-stencil state.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// You use the description for depth-stencil state in a call to the ID3D11Device::CreateDepthStencilState method to create the
		/// depth-stencil-state object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11depthstencilstate-getdesc void GetDesc( [out]
		// D3D11_DEPTH_STENCIL_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_DEPTH_STENCIL_DESC pDesc);
	}

	/// <summary>A depth-stencil-view interface accesses a texture resource during depth-stencil testing.</summary>
	/// <remarks>
	/// <para>To create a depth-stencil view, call ID3D11Device::CreateDepthStencilView.</para>
	/// <para>To bind a depth-stencil view to the pipeline, call ID3D11DeviceContext::OMSetRenderTargets.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11depthstencilview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11DepthStencilView")]
	[ComImport, Guid("9fdac92a-1876-48c3-afad-25b94f84a9b6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DepthStencilView : ID3D11View, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Get the depth-stencil view.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_DEPTH_STENCIL_VIEW_DESC*</c></para>
		/// <para>Pointer to a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11depthstencilview-getdesc void GetDesc( [out]
		// D3D11_DEPTH_STENCIL_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_DEPTH_STENCIL_VIEW_DESC pDesc);
	}

	/// <summary>
	/// <para>The device interface represents a virtual adapter; it is used to create resources.</para>
	/// <para>
	/// <c>Note</c>  The latest version of this interface is ID3D11Device5 introduced in the Windows 10 Creators Update. Applications
	/// targetting Windows 10 Creators Update should use the <c>ID3D11Device5</c> interface instead of <c>ID3D11Device</c>.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>A device is created using D3D11CreateDevice.</para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11device
	[ComImport, Guid("db6f6ddb-ac77-4e88-8253-819df9bbf140"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device
	{
		/// <summary>Creates a buffer (vertex buffer, index buffer, or shader-constant buffer).</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_BUFFER_DESC*</c></para>
		/// <para>A pointer to a D3D11_BUFFER_DESC structure that describes the buffer.</para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to a D3D11_SUBRESOURCE_DATA structure that describes the initialization data; use <c>NULL</c> to allocate space only
		/// (with the exception that it cannot be <c>NULL</c> if the usage flag is <c>D3D11_USAGE_IMMUTABLE</c>).
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the buffer is undefined. In this case,
		/// you need to write the buffer content some other way before the resource is read.
		/// </para>
		/// </param>
		/// <param name="ppBuffer">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>
		/// Address of a pointer to the ID3D11Buffer interface for the buffer object created. Set this parameter to <c>NULL</c> to validate
		/// the other input parameters ( <c>S_FALSE</c> indicates a pass).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns <c>E_OUTOFMEMORY</c> if there is insufficient memory to create the buffer. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>For example code, see How to: Create a Vertex Buffer, How to: Create an Index Buffer or How to: Create a Constant Buffer.</para>
		/// <para>
		/// For a constant buffer ( <c>BindFlags</c> of D3D11_BUFFER_DESC set to D3D11_BIND_CONSTANT_BUFFER), you must set the
		/// <c>ByteWidth</c> value of <c>D3D11_BUFFER_DESC</c> in multiples of 16, and less than or equal to <c>D3D11_REQ_CONSTANT_BUFFER_ELEMENT_COUNT</c>.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems, provides the following new functionality
		/// for <c>CreateBuffer</c>:
		/// </para>
		/// <para>
		/// You can create a constant buffer that is larger than the maximum constant buffer size that a shader can access (4096
		/// 32-bit*4-component constants – 64KB). When you bind the constant buffer to the pipeline (for example, via PSSetConstantBuffers
		/// or PSSetConstantBuffers1), you can define a range of the buffer that the shader can access that fits within the 4096 constant limit.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime (available in Windows 8 and later operating systems) emulates this feature for feature level 9.1, 9.2,
		/// and 9.3; therefore, this feature is supported for feature level 9.1, 9.2, and 9.3.
		/// </para>
		/// <para>This feature is always available on new drivers for feature level 10 and higher.</para>
		/// <para>
		/// On runtimes older than Direct3D 11.1, a call to <c>CreateBuffer</c> to request a constant buffer that is larger than 4096 fails.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createbuffer HRESULT CreateBuffer( [in] const
		// D3D11_BUFFER_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Buffer **ppBuffer );
		[PreserveSig]
		HRESULT CreateBuffer(in D3D11_BUFFER_DESC pDesc, [In, Optional] StructPointer<D3D11_SUBRESOURCE_DATA> pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Buffer? ppBuffer);

		/// <summary>Creates an array of 1D textures.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_TEXTURE1D_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE1D_DESC structure that describes a 1D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 1D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources cannot be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from values in the <c>MipLevels</c> and <c>ArraySize</c> members of the
		/// D3D11_TEXTURE1D_DESC structure to which <c>pDesc</c> points by using the following calculation:
		/// </para>
		/// <para>MipLevels * ArraySize</para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture1D">
		/// <para>Type: <c>ID3D11Texture1D**</c></para>
		/// <para>
		/// A pointer to a buffer that receives a pointer to a ID3D11Texture1D interface for the created texture. Set this parameter to
		/// <c>NULL</c> to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture1D</c> creates a 1D texture resource, which can contain a number of 1D subresources. The number of textures is
		/// specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or they can use one of the D3DX texture
		/// functions such as D3DX11CreateTextureFromFile.
		/// </para>
		/// <para>For a 32 width texture with a full mipmap chain, the <c>pInitialData</c> array has the following 6 elements:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>pInitialData[0] = 32x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[1] = 16x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[2] = 8x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[3] = 4x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[4] = 2x1</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[5] = 1x1</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture1d HRESULT CreateTexture1D( [in]
		// const D3D11_TEXTURE1D_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Texture1D
		// **ppTexture1D );
		[PreserveSig]
		HRESULT CreateTexture1D(in D3D11_TEXTURE1D_DESC pDesc, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Texture1D? ppTexture1D);

		/// <summary>Create an array of 2D textures.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_TEXTURE2D_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE2D_DESC structure that describes a 2D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 2D texture resource. Applications
		/// can't specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources cannot be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from values in the <c>MipLevels</c> and <c>ArraySize</c> members of the
		/// D3D11_TEXTURE2D_DESC structure to which <c>pDesc</c> points by using the following calculation:
		/// </para>
		/// <para>MipLevels * ArraySize</para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture2D">
		/// <para>Type: <c>ID3D11Texture2D**</c></para>
		/// <para>
		/// A pointer to a buffer that receives a pointer to a ID3D11Texture2D interface for the created texture. Set this parameter to
		/// <c>NULL</c> to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture2D</c> creates a 2D texture resource, which can contain a number of 2D subresources. The number of textures is
		/// specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or it may use one of the D3DX texture
		/// functions such as D3DX11CreateTextureFromFile.
		/// </para>
		/// <para>For a 32 x 32 texture with a full mipmap chain, the <c>pInitialData</c> array has the following 6 elements:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>pInitialData[0] = 32x32</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[1] = 16x16</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[2] = 8x8</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[3] = 4x4</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[4] = 2x2</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[5] = 1x1</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture2d HRESULT CreateTexture2D( [in]
		// const D3D11_TEXTURE2D_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Texture2D
		// **ppTexture2D );
		[PreserveSig]
		HRESULT CreateTexture2D(in D3D11_TEXTURE2D_DESC pDesc, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Texture2D? ppTexture2D);

		/// <summary>Create a single 3D texture.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_TEXTURE3D_DESC*</c></para>
		/// <para>
		/// A pointer to a D3D11_TEXTURE3D_DESC structure that describes a 3D texture resource. To create a typeless resource that can be
		/// interpreted at runtime into different, compatible formats, specify a typeless format in the texture description. To generate
		/// mipmap levels automatically, set the number of mipmap levels to 0.
		/// </para>
		/// </param>
		/// <param name="pInitialData">
		/// <para>Type: <c>const D3D11_SUBRESOURCE_DATA*</c></para>
		/// <para>
		/// A pointer to an array of D3D11_SUBRESOURCE_DATA structures that describe subresources for the 3D texture resource. Applications
		/// cannot specify <c>NULL</c> for <c>pInitialData</c> when creating IMMUTABLE resources (see D3D11_USAGE). If the resource is
		/// multisampled, <c>pInitialData</c> must be <c>NULL</c> because multisampled resources cannot be initialized with data when they
		/// are created.
		/// </para>
		/// <para>
		/// If you don't pass anything to <c>pInitialData</c>, the initial content of the memory for the resource is undefined. In this
		/// case, you need to write the resource content some other way before the resource is read.
		/// </para>
		/// <para>
		/// You can determine the size of this array from the value in the <c>MipLevels</c> member of the D3D11_TEXTURE3D_DESC structure to
		/// which <c>pDesc</c> points. Arrays of 3D volume textures are not supported.
		/// </para>
		/// <para>For more information about this array size, see Remarks.</para>
		/// </param>
		/// <param name="ppTexture3D">
		/// <para>Type: <c>ID3D11Texture3D**</c></para>
		/// <para>
		/// A pointer to a buffer that receives a pointer to a ID3D11Texture3D interface for the created texture. Set this parameter to
		/// <c>NULL</c> to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateTexture3D</c> creates a 3D texture resource, which can contain a number of 3D subresources. The number of textures is
		/// specified in the texture description. All textures in a resource must have the same format, size, and number of mipmap levels.
		/// </para>
		/// <para>
		/// All resources are made up of one or more subresources. To load data into the texture, applications can supply the data initially
		/// as an array of D3D11_SUBRESOURCE_DATA structures pointed to by <c>pInitialData</c>, or they can use one of the D3DX texture
		/// functions such as D3DX11CreateTextureFromFile.
		/// </para>
		/// <para>
		/// Each element of <c>pInitialData</c> provides all of the slices that are defined for a given miplevel. For example, for a 32 x 32
		/// x 4 volume texture with a full mipmap chain, the array has the following 6 elements:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>pInitialData[0] = 32x32 with 4 slices</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[1] = 16x16 with 2 slices</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[2] = 8x8 with 1 slice</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[3] = 4x4 with 1 slice</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[4] = 2x2 with 1 slice</description>
		/// </item>
		/// <item>
		/// <description>pInitialData[5] = 1x1 with 1 slice</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createtexture3d HRESULT CreateTexture3D( [in]
		// const D3D11_TEXTURE3D_DESC *pDesc, [in, optional] const D3D11_SUBRESOURCE_DATA *pInitialData, [out, optional] ID3D11Texture3D
		// **ppTexture3D );
		[PreserveSig]
		HRESULT CreateTexture3D(in D3D11_TEXTURE3D_DESC pDesc, [In, Optional, MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[]? pInitialData,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11Texture3D? ppTexture3D);

		/// <summary>Create a shader-resource view for accessing data in a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to the resource that will serve as input to a shader. This resource must have been created with the
		/// D3D11_BIND_SHADER_RESOURCE flag.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_SHADER_RESOURCE_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to a shader-resource view description (see D3D11_SHADER_RESOURCE_VIEW_DESC). Set this parameter to <c>NULL</c> to create
		/// a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppSRView">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11ShaderResourceView. Set this parameter to <c>NULL</c> to validate the other input parameters
		/// (the method will return <c>S_FALSE</c> if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A resource is made up of one or more subresources; a view identifies which subresources to allow the pipeline to access. In
		/// addition, each resource is bound to the pipeline using a view. A shader-resource view is designed to bind any buffer or texture
		/// resource to the shader stages using the following API methods: ID3D11DeviceContext::VSSetShaderResources,
		/// ID3D11DeviceContext::GSSetShaderResources and ID3D11DeviceContext::PSSetShaderResources.
		/// </para>
		/// <para>Because a view is fully typed, this means that typeless resources become fully typed when bound to the pipeline.</para>
		/// <para>
		/// <c>Note</c>  To successfully create a shader-resource view from a typeless buffer (for example,
		/// DXGI_FORMAT_R32G32B32A32_TYPELESS), you must set the D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS flag when you create the buffer.
		/// </para>
		/// <para></para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, allows you to use <c>CreateShaderResourceView</c> for the
		/// following new purpose.
		/// </para>
		/// <para>
		/// You can create shader-resource views of video resources so that Direct3D shaders can process those shader-resource views. These
		/// video resources are either Texture2D or Texture2DArray. The value in the <c>ViewDimension</c> member of the
		/// D3D11_SHADER_RESOURCE_VIEW_DESC structure for a created shader-resource view must match the type of video resource,
		/// D3D11_SRV_DIMENSION_TEXTURE2D for Texture2D and D3D11_SRV_DIMENSION_TEXTURE2DARRAY for Texture2DArray. Additionally, the format
		/// of the underlying video resource restricts the formats that the view can use. The video resource format values on the
		/// DXGI_FORMAT reference page specify the format values that views are restricted to.
		/// </para>
		/// <para>
		/// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same
		/// time) treats views of different parts of the same video surface as conflicting for simplicity. Therefore, the runtime does not
		/// allow an application to read from luma while the application simultaneously renders to chroma in the same surface even though
		/// the hardware might allow these simultaneous operations.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createshaderresourceview HRESULT
		// CreateShaderResourceView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_SHADER_RESOURCE_VIEW_DESC *pDesc, [out,
		// optional] ID3D11ShaderResourceView **ppSRView );
		[PreserveSig]
		HRESULT CreateShaderResourceView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_SHADER_RESOURCE_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11ShaderResourceView? ppSRView);

		/// <summary>Creates a view for accessing an unordered access resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Pointer to an ID3D11Resource that represents a resources that will serve as an input to a shader.</para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_UNORDERED_ACCESS_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to an D3D11_UNORDERED_ACCESS_VIEW_DESC that represents a shader-resource view description. Set this parameter to
		/// <c>NULL</c> to create a view that accesses the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppUAView">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11UnorderedAccessView that represents an unordered-access view. Set this parameter to <c>NULL</c>
		/// to validate the other input parameters (the method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, allows you to use <c>CreateUnorderedAccessView</c> for
		/// the following new purpose.
		/// </para>
		/// <para>
		/// You can create unordered-access views of video resources so that Direct3D shaders can process those unordered-access views.
		/// These video resources are either Texture2D or Texture2DArray. The value in the <c>ViewDimension</c> member of the
		/// D3D11_UNORDERED_ACCESS_VIEW_DESC structure for a created unordered-access view must match the type of video resource,
		/// D3D11_UAV_DIMENSION_TEXTURE2D for Texture2D and D3D11_UAV_DIMENSION_TEXTURE2DARRAY for Texture2DArray. Additionally, the format
		/// of the underlying video resource restricts the formats that the view can use. The video resource format values on the
		/// DXGI_FORMAT reference page specify the format values that views are restricted to.
		/// </para>
		/// <para>
		/// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same
		/// time) treats views of different parts of the same video surface as conflicting for simplicity. Therefore, the runtime does not
		/// allow an application to read from luma while the application simultaneously renders to chroma in the same surface even though
		/// the hardware might allow these simultaneous operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createunorderedaccessview HRESULT
		// CreateUnorderedAccessView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_UNORDERED_ACCESS_VIEW_DESC *pDesc, [out,
		// optional] ID3D11UnorderedAccessView **ppUAView );
		[PreserveSig]
		HRESULT CreateUnorderedAccessView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_UNORDERED_ACCESS_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11UnorderedAccessView? ppUAView);

		/// <summary>Creates a render-target view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to a ID3D11Resource that represents a render target. This resource must have been created with the
		/// D3D11_BIND_RENDER_TARGET flag.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_RENDER_TARGET_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to a D3D11_RENDER_TARGET_VIEW_DESC that represents a render-target view description. Set this parameter to <c>NULL</c>
		/// to create a view that accesses all of the subresources in mipmap level 0.
		/// </para>
		/// </param>
		/// <param name="ppRTView">
		/// <para>Type: <c>ID3D11RenderTargetView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11RenderTargetView. Set this parameter to <c>NULL</c> to validate the other input parameters (the
		/// method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>A render-target view can be bound to the output-merger stage by calling ID3D11DeviceContext::OMSetRenderTargets.</para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, allows you to use <c>CreateRenderTargetView</c> for the
		/// following new purpose.
		/// </para>
		/// <para>
		/// You can create render-target views of video resources so that Direct3D shaders can process those render-target views. These
		/// video resources are either Texture2D or Texture2DArray. The value in the <c>ViewDimension</c> member of the
		/// D3D11_RENDER_TARGET_VIEW_DESC structure for a created render-target view must match the type of video resource,
		/// D3D11_RTV_DIMENSION_TEXTURE2D for Texture2D and D3D11_RTV_DIMENSION_TEXTURE2DARRAY for Texture2DArray. Additionally, the format
		/// of the underlying video resource restricts the formats that the view can use. The video resource format values on the
		/// DXGI_FORMAT reference page specify the format values that views are restricted to.
		/// </para>
		/// <para>
		/// The runtime read+write conflict prevention logic (which stops a resource from being bound as an SRV and RTV or UAV at the same
		/// time) treats views of different parts of the same video surface as conflicting for simplicity. Therefore, the runtime does not
		/// allow an application to read from luma while the application simultaneously renders to chroma in the same surface even though
		/// the hardware might allow these simultaneous operations.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createrendertargetview HRESULT
		// CreateRenderTargetView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_RENDER_TARGET_VIEW_DESC *pDesc, [out,
		// optional] ID3D11RenderTargetView **ppRTView );
		[PreserveSig]
		HRESULT CreateRenderTargetView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_RENDER_TARGET_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11RenderTargetView? ppRTView);

		/// <summary>Create a depth-stencil view for accessing resource data.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>
		/// Pointer to the resource that will serve as the depth-stencil surface. This resource must have been created with the
		/// D3D11_BIND_DEPTH_STENCIL flag.
		/// </para>
		/// </param>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_DEPTH_STENCIL_VIEW_DESC*</c></para>
		/// <para>
		/// Pointer to a depth-stencil-view description (see D3D11_DEPTH_STENCIL_VIEW_DESC). Set this parameter to <c>NULL</c> to create a
		/// view that accesses mipmap level 0 of the entire resource (using the format the resource was created with).
		/// </para>
		/// </param>
		/// <param name="ppDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11DepthStencilView. Set this parameter to <c>NULL</c> to validate the other input parameters (the
		/// method will return S_FALSE if the other input parameters pass validation).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>A depth-stencil view can be bound to the output-merger stage by calling ID3D11DeviceContext::OMSetRenderTargets.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdepthstencilview HRESULT
		// CreateDepthStencilView( [in] ID3D11Resource *pResource, [in, optional] const D3D11_DEPTH_STENCIL_VIEW_DESC *pDesc, [out,
		// optional] ID3D11DepthStencilView **ppDepthStencilView );
		[PreserveSig]
		HRESULT CreateDepthStencilView([In] ID3D11Resource pResource, [In, Optional] StructPointer<D3D11_DEPTH_STENCIL_VIEW_DESC> pDesc,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11DepthStencilView? ppDepthStencilView);

		/// <summary>Create an input-layout object to describe the input-buffer data for the input-assembler stage.</summary>
		/// <param name="pInputElementDescs">
		/// <para>Type: <c>const D3D11_INPUT_ELEMENT_DESC*</c></para>
		/// <para>An array of the input-assembler stage input data types; each type is described by an element description (see D3D11_INPUT_ELEMENT_DESC).</para>
		/// </param>
		/// <param name="NumElements">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of input-data types in the array of input-elements.</para>
		/// </param>
		/// <param name="pShaderBytecodeWithInputSignature">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// A pointer to the compiled shader. The compiled shader code contains a input signature which is validated against the array of
		/// elements. See remarks.
		/// </para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader.</para>
		/// </param>
		/// <param name="ppInputLayout">
		/// <para>Type: <c>ID3D11InputLayout**</c></para>
		/// <para>
		/// A pointer to the input-layout object created (see ID3D11InputLayout). To validate the other input parameters, set this pointer
		/// to be <c>NULL</c> and verify that the method returns S_FALSE.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, the return code is S_OK. See Direct3D 11 Return Codes for failing error codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>After creating an input layout object, it must be bound to the input-assembler stage before calling a draw API.</para>
		/// <para>
		/// Once an input-layout object is created from a shader signature, the input-layout object can be reused with any other shader that
		/// has an identical input signature (semantics included). This can simplify the creation of input-layout objects when you are
		/// working with many shaders with identical inputs.
		/// </para>
		/// <para>
		/// If a data type in the input-layout declaration does not match the data type in a shader-input signature, CreateInputLayout will
		/// generate a warning during compilation. The warning is simply to call attention to the fact that the data may be reinterpreted
		/// when read from a register. You may either disregard this warning (if reinterpretation is intentional) or make the data types
		/// match in both declarations to eliminate the warning.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createinputlayout HRESULT CreateInputLayout( [in]
		// const D3D11_INPUT_ELEMENT_DESC *pInputElementDescs, [in] uint NumElements, [in] const void *pShaderBytecodeWithInputSignature,
		// [in] SIZE_T BytecodeLength, [out, optional] ID3D11InputLayout **ppInputLayout );
		[PreserveSig]
		HRESULT CreateInputLayout([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_INPUT_ELEMENT_DESC[] pInputElementDescs,
			int NumElements, [In] IntPtr pShaderBytecodeWithInputSignature, [In] IntPtr BytecodeLength,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11InputLayout? ppInputLayout);

		/// <summary>Create a vertex-shader object from a compiled shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled vertex shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppVertexShader">
		/// <para>Type: <c>ID3D11VertexShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11VertexShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return <c>S_FALSE</c> instead of <c>S_OK</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateVertexShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a vertex shader, you can successfully pass the compiled
		/// vertex shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateVertexShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateVertexShader</c> fails. <c>CreateVertexShader</c> also fails if the shader tries to use a UAV slot beyond the set of
		/// UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createvertexshader HRESULT CreateVertexShader(
		// [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11VertexShader **ppVertexShader );
		[PreserveSig]
		HRESULT CreateVertexShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, [In, Optional] ID3D11ClassLinkage? pClassLinkage,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11VertexShader? ppVertexShader);

		/// <summary>Create a geometry shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled geometry shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppGeometryShader">
		/// <para>Type: <c>ID3D11GeometryShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11GeometryShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>After it is created, the shader can be set to the device by calling ID3D11DeviceContext::GSSetShader.</para>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateGeometryShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a geometry shader, you can successfully pass the compiled
		/// geometry shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateGeometryShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateGeometryShader</c> fails. <c>CreateGeometryShader</c> also fails if the shader tries to use a UAV slot beyond the set
		/// of UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>Usage Example</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-creategeometryshader HRESULT
		// CreateGeometryShader( [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage
		// *pClassLinkage, [out, optional] ID3D11GeometryShader **ppGeometryShader );
		[PreserveSig]
		HRESULT CreateGeometryShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, [In, Optional] ID3D11ClassLinkage? pClassLinkage,
			[MarshalAs(UnmanagedType.Interface)] out ID3D11GeometryShader? ppGeometryShader);

		/// <summary>Creates a geometry shader that can write to streaming output buffers.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// A pointer to the compiled geometry shader for a standard geometry shader plus stream output. For info on how to get this
		/// pointer, see Getting a Pointer to a Compiled Shader.
		/// </para>
		/// <para>
		/// To create the stream output without using a geometry shader, pass a pointer to the output signature for the prior stage. To
		/// obtain this output signature, call the D3DGetOutputSignatureBlob compiler function. You can also pass a pointer to the compiled
		/// shader for the prior stage (for example, the vertex-shader stage or domain-shader stage). This compiled shader provides the
		/// output signature for the data.
		/// </para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled geometry shader.</para>
		/// </param>
		/// <param name="pSODeclaration">
		/// <para>Type: <c>const D3D11_SO_DECLARATION_ENTRY*</c></para>
		/// <para>Pointer to a D3D11_SO_DECLARATION_ENTRY array. Cannot be <c>NULL</c> if NumEntries &gt; 0.</para>
		/// </param>
		/// <param name="NumEntries">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of entries in the stream output declaration ( ranges from 0 to D3D11_SO_STREAM_COUNT *
		/// D3D11_SO_OUTPUT_COMPONENT_COUNT ).
		/// </para>
		/// </param>
		/// <param name="pBufferStrides">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>An array of buffer strides; each stride is the size of an element for that buffer.</para>
		/// </param>
		/// <param name="NumStrides">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of strides (or buffers) in <c>pBufferStrides</c> (ranges from 0 to D3D11_SO_BUFFER_SLOT_COUNT).</para>
		/// </param>
		/// <param name="RasterizedStream">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The index number of the stream to be sent to the rasterizer stage (ranges from 0 to D3D11_SO_STREAM_COUNT - 1). Set to
		/// D3D11_SO_NO_RASTERIZED_STREAM if no stream is to be rasterized.
		/// </para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppGeometryShader">
		/// <para>Type: <c>ID3D11GeometryShader**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11GeometryShader interface, representing the geometry shader that was created. Set this to
		/// <c>NULL</c> to validate the other parameters; if validation passes, the method will return S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For more info about using <c>CreateGeometryShaderWithStreamOutput</c>, see Create a Geometry-Shader Object with Stream Output.
		/// </para>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateGeometryShaderWithStreamOutput</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a geometry shader, you can successfully pass the compiled
		/// geometry shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateGeometryShaderWithStreamOutput</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateGeometryShaderWithStreamOutput</c> fails. <c>CreateGeometryShaderWithStreamOutput</c> also fails if the shader tries to
		/// use a UAV slot beyond the set of UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-creategeometryshaderwithstreamoutput HRESULT
		// CreateGeometryShaderWithStreamOutput( [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] const
		// D3D11_SO_DECLARATION_ENTRY *pSODeclaration, [in] uint NumEntries, [in, optional] const uint *pBufferStrides, [in] uint
		// NumStrides, [in] uint RasterizedStream, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional] ID3D11GeometryShader
		// **ppGeometryShader );
		[PreserveSig]
		HRESULT CreateGeometryShaderWithStreamOutput([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_SO_DECLARATION_ENTRY[]? pSODeclaration,
			int NumEntries, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[]? pBufferStrides,
			int NumStrides, uint RasterizedStream, [In, Optional] ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11GeometryShader? ppGeometryShader);

		/// <summary>Create a pixel shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled pixel shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppPixelShader">
		/// <para>Type: <c>ID3D11PixelShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11PixelShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>After creating the pixel shader, you can set it to the device using ID3D11DeviceContext::PSSetShader.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createpixelshader HRESULT CreatePixelShader( [in]
		// const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11PixelShader **ppPixelShader );
		[PreserveSig]
		HRESULT CreatePixelShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11PixelShader? ppPixelShader);

		/// <summary>Create a hull shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppHullShader">
		/// <para>Type: <c>ID3D11HullShader**</c></para>
		/// <para>Address of a pointer to a ID3D11HullShader interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateHullShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a hull shader, you can successfully pass the compiled hull
		/// shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateHullShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateHullShader</c> fails. <c>CreateHullShader</c> also fails if the shader tries to use a UAV slot beyond the set of UAV
		/// slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createhullshader HRESULT CreateHullShader( [in]
		// const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11HullShader **ppHullShader );
		[PreserveSig]
		HRESULT CreateHullShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11HullShader? ppHullShader);

		/// <summary>Create a domain shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a class linkage interface (see ID3D11ClassLinkage); the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppDomainShader">
		/// <para>Type: <c>ID3D11DomainShader**</c></para>
		/// <para>
		/// Address of a pointer to a ID3D11DomainShader interface. If this is <c>NULL</c>, all other parameters will be validated, and if
		/// all parameters pass validation this API will return <c>S_FALSE</c> instead of <c>S_OK</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The Direct3D 11.1 runtime, which is available starting with Windows 8, provides the following new functionality for <c>CreateDomainShader</c>.</para>
		/// <para>
		/// The following shader model 5.0 instructions are available to just pixel shaders and compute shaders in the Direct3D 11.0
		/// runtime. For the Direct3D 11.1 runtime, because unordered access views (UAV) are available at all shader stages, you can use
		/// these instructions in all shader stages.
		/// </para>
		/// <para>
		/// Therefore, if you use the following shader model 5.0 instructions in a domain shader, you can successfully pass the compiled
		/// domain shader to <c>pShaderBytecode</c>. That is, the call to <c>CreateDomainShader</c> succeeds.
		/// </para>
		/// <para>
		/// If you pass a compiled shader to <c>pShaderBytecode</c> that uses any of the following instructions on a device that doesn’t
		/// support UAVs at every shader stage (including existing drivers that are not implemented to support UAVs at every shader stage),
		/// <c>CreateDomainShader</c> fails. <c>CreateDomainShader</c> also fails if the shader tries to use a UAV slot beyond the set of
		/// UAV slots that the hardware supports.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>dcl_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_raw</description>
		/// </item>
		/// <item>
		/// <description>dcl_uav_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_raw</description>
		/// </item>
		/// <item>
		/// <description>ld_structured</description>
		/// </item>
		/// <item>
		/// <description>ld_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>store_raw</description>
		/// </item>
		/// <item>
		/// <description>store_structured</description>
		/// </item>
		/// <item>
		/// <description>store_uav_typed</description>
		/// </item>
		/// <item>
		/// <description>sync_uglobal</description>
		/// </item>
		/// <item>
		/// <description>All atomics and immediate atomics (for example, atomic_and and imm_atomic_and)</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdomainshader HRESULT CreateDomainShader(
		// [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11DomainShader **ppDomainShader );
		[PreserveSig]
		HRESULT CreateDomainShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11DomainShader? ppDomainShader);

		/// <summary>Create a compute shader.</summary>
		/// <param name="pShaderBytecode">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to a compiled shader.</para>
		/// </param>
		/// <param name="BytecodeLength">
		/// <para>Type: <c>SIZE_T</c></para>
		/// <para>Size of the compiled shader in <c>pShaderBytecode</c>.</para>
		/// </param>
		/// <param name="pClassLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage*</c></para>
		/// <para>A pointer to a ID3D11ClassLinkage, which represents class linkage interface; the value can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="ppComputeShader">
		/// <para>Type: <c>ID3D11ComputeShader**</c></para>
		/// <para>
		/// Address of a pointer to an ID3D11ComputeShader interface. If this is <c>NULL</c>, all other parameters will be validated; if
		/// validation passes, CreateComputeShader returns S_FALSE instead of S_OK.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the compute shader. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>For an example, see How To: Create a Compute Shader and HDRToneMappingCS11 Sample.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createcomputeshader HRESULT CreateComputeShader(
		// [in] const void *pShaderBytecode, [in] SIZE_T BytecodeLength, [in, optional] ID3D11ClassLinkage *pClassLinkage, [out, optional]
		// ID3D11ComputeShader **ppComputeShader );
		[PreserveSig]
		HRESULT CreateComputeShader([In] IntPtr pShaderBytecode, [In] IntPtr BytecodeLength, ID3D11ClassLinkage? pClassLinkage, [MarshalAs(UnmanagedType.Interface)] out ID3D11ComputeShader? ppComputeShader);

		/// <summary>Creates class linkage libraries to enable dynamic shader linkage.</summary>
		/// <param name="ppLinkage">
		/// <para>Type: <c>ID3D11ClassLinkage**</c></para>
		/// <para>A pointer to a class-linkage interface pointer (see ID3D11ClassLinkage).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The ID3D11ClassLinkage interface returned in <c>ppLinkage</c> is associated with a shader by passing it as a parameter to one of
		/// the ID3D11Device create shader methods such as ID3D11Device::CreatePixelShader.
		/// </para>
		/// <para>Examples</para>
		/// <para>Using CreateClassLinkage</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createclasslinkage HRESULT CreateClassLinkage(
		// [out] ID3D11ClassLinkage **ppLinkage );
		[PreserveSig]
		HRESULT CreateClassLinkage([MarshalAs(UnmanagedType.Interface)] out ID3D11ClassLinkage ppLinkage);

		/// <summary>Create a blend-state object that encapsulates blend state for the output-merger stage.</summary>
		/// <param name="pBlendStateDesc">
		/// <para>Type: <c>const D3D11_BLEND_DESC*</c></para>
		/// <para>Pointer to a blend-state description (see D3D11_BLEND_DESC).</para>
		/// </param>
		/// <param name="ppBlendState">
		/// <para>Type: <c>ID3D11BlendState**</c></para>
		/// <para>Address of a pointer to the blend-state object created (see ID3D11BlendState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the blend-state object. See Direct3D 11 Return Codes
		/// for other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can create up to 4096 unique blend-state objects. For each object created, the runtime checks to see if a
		/// previous object has the same state. If such a previous object exists, the runtime will return a pointer to previous instance
		/// instead of creating a duplicate object.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createblendstate HRESULT CreateBlendState( [in]
		// const D3D11_BLEND_DESC *pBlendStateDesc, [out, optional] ID3D11BlendState **ppBlendState );
		[PreserveSig]
		HRESULT CreateBlendState(in D3D11_BLEND_DESC pBlendStateDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11BlendState? ppBlendState);

		/// <summary>Create a depth-stencil state object that encapsulates depth-stencil test information for the output-merger stage.</summary>
		/// <param name="pDepthStencilDesc">
		/// <para>Type: <c>const D3D11_DEPTH_STENCIL_DESC*</c></para>
		/// <para>Pointer to a depth-stencil state description (see D3D11_DEPTH_STENCIL_DESC).</para>
		/// </param>
		/// <param name="ppDepthStencilState">
		/// <para>Type: <c>ID3D11DepthStencilState**</c></para>
		/// <para>Address of a pointer to the depth-stencil state object created (see ID3D11DepthStencilState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>4096 unique depth-stencil state objects can be created on a device at a time.</para>
		/// <para>
		/// If an application attempts to create a depth-stencil-state interface with the same state as an existing interface, the same
		/// interface will be returned and the total number of unique depth-stencil state objects will stay the same.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdepthstencilstate HRESULT
		// CreateDepthStencilState( [in] const D3D11_DEPTH_STENCIL_DESC *pDepthStencilDesc, [out, optional] ID3D11DepthStencilState
		// **ppDepthStencilState );
		[PreserveSig]
		HRESULT CreateDepthStencilState(in D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11DepthStencilState? ppDepthStencilState);

		/// <summary>Create a rasterizer state object that tells the rasterizer stage how to behave.</summary>
		/// <param name="pRasterizerDesc">
		/// <para>Type: <c>const D3D11_RASTERIZER_DESC*</c></para>
		/// <para>Pointer to a rasterizer state description (see D3D11_RASTERIZER_DESC).</para>
		/// </param>
		/// <param name="ppRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState**</c></para>
		/// <para>Address of a pointer to the rasterizer state object created (see ID3D11RasterizerState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the compute shader. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>4096 unique rasterizer state objects can be created on a device at a time.</para>
		/// <para>
		/// If an application attempts to create a rasterizer-state interface with the same state as an existing interface, the same
		/// interface will be returned and the total number of unique rasterizer state objects will stay the same.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createrasterizerstate HRESULT
		// CreateRasterizerState( [in] const D3D11_RASTERIZER_DESC *pRasterizerDesc, [out, optional] ID3D11RasterizerState
		// **ppRasterizerState );
		[PreserveSig]
		HRESULT CreateRasterizerState(in D3D11_RASTERIZER_DESC pRasterizerDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11RasterizerState? ppRasterizerState);

		/// <summary>Create a sampler-state object that encapsulates sampling information for a texture.</summary>
		/// <param name="pSamplerDesc">
		/// <para>Type: <c>const D3D11_SAMPLER_DESC*</c></para>
		/// <para>Pointer to a sampler state description (see D3D11_SAMPLER_DESC).</para>
		/// </param>
		/// <param name="ppSamplerState">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Address of a pointer to the sampler state object created (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>4096 unique sampler state objects can be created on a device at a time.</para>
		/// <para>
		/// If an application attempts to create a sampler-state interface with the same state as an existing interface, the same interface
		/// will be returned and the total number of unique sampler state objects will stay the same.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createsamplerstate HRESULT CreateSamplerState(
		// [in] const D3D11_SAMPLER_DESC *pSamplerDesc, [out, optional] ID3D11SamplerState **ppSamplerState );
		[PreserveSig]
		HRESULT CreateSamplerState(in D3D11_SAMPLER_DESC pSamplerDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11SamplerState? ppSamplerState);

		/// <summary>This interface encapsulates methods for querying information from the GPU.</summary>
		/// <param name="pQueryDesc">
		/// <para>Type: <c>const D3D11_QUERY_DESC*</c></para>
		/// <para>Pointer to a query description (see D3D11_QUERY_DESC).</para>
		/// </param>
		/// <param name="ppQuery">
		/// <para>Type: <c>ID3D11Query**</c></para>
		/// <para>Address of a pointer to the query object created (see ID3D11Query).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns E_OUTOFMEMORY if there is insufficient memory to create the query object. See Direct3D 11 Return Codes for
		/// other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createquery HRESULT CreateQuery( [in] const
		// D3D11_QUERY_DESC *pQueryDesc, [out, optional] ID3D11Query **ppQuery );
		[PreserveSig]
		HRESULT CreateQuery(in D3D11_QUERY_DESC pQueryDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11Query? ppQuery);

		/// <summary>Creates a predicate.</summary>
		/// <param name="pPredicateDesc">
		/// <para>Type: <c>const D3D11_QUERY_DESC*</c></para>
		/// <para>
		/// Pointer to a query description where the type of query must be a D3D11_QUERY_SO_OVERFLOW_PREDICATE or
		/// D3D11_QUERY_OCCLUSION_PREDICATE (see D3D11_QUERY_DESC).
		/// </para>
		/// </param>
		/// <param name="ppPredicate">
		/// <para>Type: <c>ID3D11Predicate**</c></para>
		/// <para>Address of a pointer to a predicate (see ID3D11Predicate).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createpredicate HRESULT CreatePredicate( [in]
		// const D3D11_QUERY_DESC *pPredicateDesc, [out, optional] ID3D11Predicate **ppPredicate );
		[PreserveSig]
		HRESULT CreatePredicate(in D3D11_QUERY_DESC pPredicateDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11Predicate? ppPredicate);

		/// <summary>Create a counter object for measuring GPU performance.</summary>
		/// <param name="pCounterDesc">
		/// <para>Type: <c>const D3D11_COUNTER_DESC*</c></para>
		/// <para>Pointer to a counter description (see D3D11_COUNTER_DESC).</para>
		/// </param>
		/// <param name="ppCounter">
		/// <para>Type: <c>ID3D11Counter**</c></para>
		/// <para>Address of a pointer to a counter (see ID3D11Counter).</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If this function succeeds, it will return S_OK. If it fails, possible return values are: S_FALSE, E_OUTOFMEMORY,
		/// DXGI_ERROR_UNSUPPORTED, DXGI_ERROR_NONEXCLUSIVE, or E_INVALIDARG.
		/// </para>
		/// <para>
		/// DXGI_ERROR_UNSUPPORTED is returned whenever the application requests to create a well-known counter, but the current device does
		/// not support it.
		/// </para>
		/// <para>
		/// DXGI_ERROR_NONEXCLUSIVE indicates that another device object is currently using the counters, so they cannot be used by this
		/// device at the moment.
		/// </para>
		/// <para>
		/// E_INVALIDARG is returned whenever an out-of-range well-known or device-dependent counter is requested, or when the
		/// simulataneously active counters have been exhausted.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createcounter HRESULT CreateCounter( [in] const
		// D3D11_COUNTER_DESC *pCounterDesc, [out, optional] ID3D11Counter **ppCounter );
		[PreserveSig]
		HRESULT CreateCounter(in D3D11_COUNTER_DESC pCounterDesc, [MarshalAs(UnmanagedType.Interface)] out ID3D11Counter? ppCounter);

		/// <summary>Creates a deferred context, which can record command lists.</summary>
		/// <param name="ContextFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Reserved for future use. Pass 0.</para>
		/// </param>
		/// <param name="ppDeferredContext">
		/// <para>Type: <c>ID3D11DeviceContext**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext interface pointer is initialized.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if the video card has been physically removed from the system, or a driver upgrade for
		/// the video card has occurred. If this error occurs, you should destroy and recreate the device.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns <c>DXGI_ERROR_INVALID_CALL</c> if the <c>CreateDeferredContext</c> method cannot be called from the current context. For
		/// example, if the device was created with the D3D11_CREATE_DEVICE_SINGLETHREADED value, <c>CreateDeferredContext</c> returns <c>DXGI_ERROR_INVALID_CALL</c>.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_INVALIDARG</c> if the <c>ContextFlags</c> parameter is invalid.</description>
		/// </item>
		/// <item>
		/// <description>Returns <c>E_OUTOFMEMORY</c> if the application has exhausted available memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A deferred context is a thread-safe context that you can use to record graphics commands on a thread other than the main
		/// rendering thread. Using a deferred context, you can record graphics commands into a command list that is encapsulated by the
		/// ID3D11CommandList interface. After all scene items are recorded, you can then submit them to the main render thread for final
		/// rendering. In this manner, you can perform rendering tasks concurrently across multiple threads and potentially improve
		/// performance in multi-core CPU scenarios.
		/// </para>
		/// <para>You can create multiple deferred contexts.</para>
		/// <para>
		/// <c>Note</c>  If you use the D3D11_CREATE_DEVICE_SINGLETHREADED value to create the device that is represented by ID3D11Device,
		/// the <c>CreateDeferredContext</c> method will fail, and you will not be able to create a deferred context.
		/// </para>
		/// <para></para>
		/// <para>For more information about deferred contexts, see Immediate and Deferred Rendering.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-createdeferredcontext HRESULT
		// CreateDeferredContext( uint ContextFlags, [out, optional] ID3D11DeviceContext **ppDeferredContext );
		[PreserveSig]
		HRESULT CreateDeferredContext([Optional] uint ContextFlags, [MarshalAs(UnmanagedType.Interface)] out ID3D11DeviceContext? ppDeferredContext);

		/// <summary>Give a device access to a shared resource created on a different device.</summary>
		/// <param name="hResource">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A resource handle. See remarks.</para>
		/// </param>
		/// <param name="ReturnedInterface">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The globally unique identifier (GUID) for the resource interface. See remarks.</para>
		/// </param>
		/// <param name="ppResource">
		/// <para>Type: <c>void**</c></para>
		/// <para>Address of a pointer to the resource we are gaining access to.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The REFIID, or GUID, of the interface to the resource can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D11Buffer) will get the GUID of the interface to a buffer resource.
		/// </para>
		/// <para>
		/// The unique handle of the resource is obtained differently depending on the type of device that originally created the resource.
		/// </para>
		/// <para>
		/// To share a resource between two Direct3D 11 devices the resource must have been created with the D3D11_RESOURCE_MISC_SHARED
		/// flag, if it was created using the ID3D11Device interface. If it was created using a DXGI device interface, then the resource is
		/// always shared.
		/// </para>
		/// <para>
		/// The REFIID, or GUID, of the interface to the resource can be obtained by using the __uuidof() macro. For example,
		/// __uuidof(ID3D11Buffer) will get the GUID of the interface to a buffer resource.
		/// </para>
		/// <para>
		/// When sharing a resource between two Direct3D 10/11 devices the unique handle of the resource can be obtained by querying the
		/// resource for the IDXGIResource interface and then calling GetSharedHandle.
		/// </para>
		/// <para>The only resources that can be shared are 2D non-mipmapped textures.</para>
		/// <para>
		/// To share a resource between a Direct3D 9 device and a Direct3D 11 device the texture must have been created using the
		/// <c>pSharedHandle</c> argument of CreateTexture. The shared Direct3D 9 handle is then passed to OpenSharedResource in the
		/// <c>hResource</c> argument.
		/// </para>
		/// <para>The following code illustrates the method calls involved.</para>
		/// <para>Textures being shared from D3D9 to D3D11 have the following restrictions.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Textures must be 2D</description>
		/// </item>
		/// <item>
		/// <description>Only 1 mip level is allowed</description>
		/// </item>
		/// <item>
		/// <description>Texture must have default usage</description>
		/// </item>
		/// <item>
		/// <description>Texture must be write only</description>
		/// </item>
		/// <item>
		/// <description>MSAA textures are not allowed</description>
		/// </item>
		/// <item>
		/// <description>Bind flags must have SHADER_RESOURCE and RENDER_TARGET set</description>
		/// </item>
		/// <item>
		/// <description>Only R10G10B10A2_UNORM, R16G16B16A16_FLOAT and R8G8B8A8_UNORM formats are allowed</description>
		/// </item>
		/// </list>
		/// <para>If a shared texture is updated on one device ID3D11DeviceContext::Flush must be called on that device.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-opensharedresource HRESULT OpenSharedResource(
		// [in] HANDLE hResource, [in] REFIID ReturnedInterface, [out, optional] void **ppResource );
		[PreserveSig]
		HRESULT OpenSharedResource([In] IntPtr hResource, in Guid ReturnedInterface, [MarshalAs(UnmanagedType.Interface)] out object? ppResource);

		/// <summary>Get the support of a given format on the installed video device.</summary>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A DXGI_FORMAT enumeration that describes a format for which to check for support.</para>
		/// </param>
		/// <param name="pFormatSupport">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A bitfield of D3D11_FORMAT_SUPPORT enumeration values describing how the specified format is supported on the installed device.
		/// The values are ORed together.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns E_INVALIDARG if the <c>Format</c> parameter is <c>NULL</c>, or returns E_FAIL if
		/// the described format does not exist.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkformatsupport HRESULT CheckFormatSupport(
		// [in] DXGI_FORMAT Format, [out] uint *pFormatSupport );
		[PreserveSig]
		HRESULT CheckFormatSupport(DXGI_FORMAT Format, out D3D11_FORMAT_SUPPORT pFormatSupport);

		/// <summary>Get the number of quality levels available during multisampling.</summary>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>The texture format. See DXGI_FORMAT.</para>
		/// </param>
		/// <param name="SampleCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of samples during multisampling.</para>
		/// </param>
		/// <param name="pNumQualityLevels">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Number of quality levels supported by the adapter. See <c>Remarks</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When multisampling a texture, the number of quality levels available for an adapter is dependent on the texture format used and
		/// the number of samples requested. The maximum number of quality levels is defined by <c>D3D11_MAX_MULTISAMPLE_SAMPLE_COUNT</c> in
		/// . If this method returns 0 (S_OK), and the output parameter receives a positive value, then the format and sample count
		/// combination is supported for the device. When the combination is not supported, this method returns a failure <c>HRESULT</c>
		/// code (that is, a negative integer), or sets output parameter to zero, or both.
		/// </para>
		/// <para>
		/// Furthermore, the definition of a quality level is left to each hardware vendor to define; however no facility is provided by
		/// Direct3D to help discover this information.
		/// </para>
		/// <para>
		/// Note that FEATURE_LEVEL_10_1 devices are required to support 4x MSAA for all render targets except R32G32B32A32 and R32G32B32.
		/// FEATURE_LEVEL_11_0 devices are required to support 4x MSAA for all render target formats, and 8x MSAA for all render target
		/// formats except R32G32B32A32 formats.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkmultisamplequalitylevels HRESULT
		// CheckMultisampleQualityLevels( [in] DXGI_FORMAT Format, [in] uint SampleCount, [out] uint *pNumQualityLevels );
		[PreserveSig]
		HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);

		/// <summary>Get a counter's information.</summary>
		/// <param name="pCounterInfo">
		/// <para>Type: <c>D3D11_COUNTER_INFO*</c></para>
		/// <para>Pointer to counter information (see D3D11_COUNTER_INFO).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkcounterinfo void CheckCounterInfo( [out]
		// D3D11_COUNTER_INFO *pCounterInfo );
		[PreserveSig]
		void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);

		/// <summary>Get the type, name, units of measure, and a description of an existing counter.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>const D3D11_COUNTER_DESC*</c></para>
		/// <para>Pointer to a counter description (see D3D11_COUNTER_DESC). Specifies which counter information is to be retrieved about.</para>
		/// </param>
		/// <param name="pType">
		/// <para>Type: <c>D3D11_COUNTER_TYPE*</c></para>
		/// <para>Pointer to the data type of a counter (see D3D11_COUNTER_TYPE). Specifies the data type of the counter being retrieved.</para>
		/// </param>
		/// <param name="pActiveCounters">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// Pointer to the number of hardware counters that are needed for this counter type to be created. All instances of the same
		/// counter type use the same hardware counters.
		/// </para>
		/// </param>
		/// <param name="szName">
		/// <para>Type: <c>LPSTR</c></para>
		/// <para>
		/// String to be filled with a brief name for the counter. May be <c>NULL</c> if the application is not interested in the name of
		/// the counter.
		/// </para>
		/// </param>
		/// <param name="pNameLength">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Length of the string returned to szName. Can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="szUnits">
		/// <para>Type: <c>LPSTR</c></para>
		/// <para>
		/// Name of the units a counter measures, provided the memory the pointer points to has enough room to hold the string. Can be
		/// <c>NULL</c>. The returned string will always be in English.
		/// </para>
		/// </param>
		/// <param name="pUnitsLength">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Length of the string returned to szUnits. Can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="szDescription">
		/// <para>Type: <c>LPSTR</c></para>
		/// <para>
		/// A description of the counter, provided the memory the pointer points to has enough room to hold the string. Can be <c>NULL</c>.
		/// The returned string will always be in English.
		/// </para>
		/// </param>
		/// <param name="pDescriptionLength">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Length of the string returned to szDescription. Can be <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Length parameters can be <c>NULL</c>, which indicates the application is not interested in the length nor the corresponding
		/// string value. When a length parameter is non- <c>NULL</c> and the corresponding string is <c>NULL</c>, the input value of the
		/// length parameter is ignored, and the length of the corresponding string (including terminating <c>NULL</c>) will be returned
		/// through the length parameter. When length and the corresponding parameter are both non- <c>NULL</c>, the input value of length
		/// is checked to ensure there is enough room, and then the length of the string (including terminating <c>NULL</c> character) is
		/// passed out through the length parameter.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkcounter HRESULT CheckCounter( [in] const
		// D3D11_COUNTER_DESC *pDesc, [out] D3D11_COUNTER_TYPE *pType, [out] uint *pActiveCounters, [out, optional] LPSTR szName, [in, out,
		// optional] uint *pNameLength, [out, optional] LPSTR szUnits, [in, out, optional] uint *pUnitsLength, [out, optional] LPSTR
		// szDescription, [in, out, optional] uint *pDescriptionLength );
		[PreserveSig]
		HRESULT CheckCounter(in D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? szName, [Optional] in uint pNameLength,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? szUnits, [Optional] in uint pUnitsLength,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPStr)] StringBuilder? szDescription, [Optional] in uint pDescriptionLength);

		/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
		/// <param name="Feature">
		/// <para>Type: <c>D3D11_FEATURE</c></para>
		/// <para>A member of the D3D11_FEATURE enumerated type that describes which feature to query for support.</para>
		/// </param>
		/// <param name="pFeatureSupportData">
		/// <para>Type: <c>void*</c></para>
		/// <para>Upon completion of the method, the passed structure is filled with data that describes the feature support.</para>
		/// </param>
		/// <param name="FeatureSupportDataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>The size of the structure passed to the <c>pFeatureSupportData</c> parameter.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// Returns S_OK if successful; otherwise, returns E_INVALIDARG if an unsupported data type is passed to the
		/// <c>pFeatureSupportData</c> parameter or a size mismatch is detected for the <c>FeatureSupportDataSize</c> parameter.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To query for multi-threading support, pass the <c>D3D11_FEATURE_THREADING</c> value to the <c>Feature</c> parameter, pass the
		/// D3D11_FEATURE_DATA_THREADING structure to the <c>pFeatureSupportData</c> parameter, and pass the size of the
		/// <c>D3D11_FEATURE_DATA_THREADING</c> structure to the <c>FeatureSupportDataSize</c> parameter.
		/// </para>
		/// <para>
		/// Calling CheckFeatureSupport with <c>Feature</c> set to D3D11_FEATURE_FORMAT_SUPPORT causes the method to return the same
		/// information that would be returned by ID3D11Device::CheckFormatSupport.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-checkfeaturesupport HRESULT CheckFeatureSupport(
		// D3D11_FEATURE Feature, [out] void *pFeatureSupportData, uint FeatureSupportDataSize );
		[PreserveSig]
		HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		/// <summary>Get application-defined data from a device.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device if <c>pDataSize</c> points to a value that
		/// specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [In, Optional] IntPtr pData);

		/// <summary>Set data to a device and associate that data with a guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device. If pData is <c>NULL</c>, DataSize must also be 0, and any data previously
		/// associated with the guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device with this method can be retrieved with ID3D11Device::GetPrivateData.</para>
		/// <para>The data and guid set with this method will typically be application-defined.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the feature level of the hardware device.</summary>
		/// <returns>
		/// <para>Type: <c>D3D_FEATURE_LEVEL</c></para>
		/// <para>A member of the D3D_FEATURE_LEVEL enumerated type that describes the feature level of the hardware device.</para>
		/// </returns>
		/// <remarks>Feature levels determine the capabilities of your device.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getfeaturelevel D3D_FEATURE_LEVEL GetFeatureLevel();
		[PreserveSig]
		D3D_FEATURE_LEVEL GetFeatureLevel();

		/// <summary>Get the flags used during the call to create the device with D3D11CreateDevice.</summary>
		/// <returns>
		/// <para>Type: <c>uint</c></para>
		/// <para>A bitfield containing the flags used to create the device. See D3D11_CREATE_DEVICE_FLAG.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getcreationflags uint GetCreationFlags();
		[PreserveSig]
		D3D11_CREATE_DEVICE_FLAG GetCreationFlags();

		/// <summary>Get the reason why the device was removed.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Possible return values include:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_HUNG</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_REMOVED</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_DEVICE_RESET</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_DRIVER_INTERNAL_ERROR</description>
		/// </item>
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL</description>
		/// </item>
		/// <item>
		/// <description>S_OK</description>
		/// </item>
		/// </list>
		/// <para>For more detail on these return codes, see DXGI_ERROR.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getdeviceremovedreason HRESULT GetDeviceRemovedReason();
		[PreserveSig]
		HRESULT GetDeviceRemovedReason();

		/// <summary>Gets an immediate context, which can play back command lists.</summary>
		/// <param name="ppImmediateContext">
		/// <para>Type: <c>ID3D11DeviceContext**</c></para>
		/// <para>Upon completion of the method, the passed pointer to an ID3D11DeviceContext interface pointer is initialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>GetImmediateContext</c> method returns an ID3D11DeviceContext object that represents an immediate context which is used
		/// to perform rendering that you want immediately submitted to a device. For most applications, an immediate context is the primary
		/// object that is used to draw your scene.
		/// </para>
		/// <para>
		/// The <c>GetImmediateContext</c> method increments the reference count of the immediate context by one. Therefore, you must call
		/// Release on the returned interface pointer when you are done with it to avoid a memory leak.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getimmediatecontext void GetImmediateContext(
		// [out] ID3D11DeviceContext **ppImmediateContext );
		[PreserveSig]
		void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);

		/// <summary>Get the exception-mode flags.</summary>
		/// <param name="RaiseFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// A value that contains one or more exception flags; each flag specifies a condition which will cause an exception to be raised.
		/// The flags are listed in D3D11_RAISE_FLAG. A default value of 0 means there are no flags.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>Set an exception-mode flag to elevate an error condition to a non-continuable exception.</para>
		/// <para>
		/// Whenever an error occurs, a Direct3D device enters the DEVICEREMOVED state and if the appropriate exception flag has been set,
		/// an exception is raised. A raised exception is designed to terminate an application. Before termination, the last chance an
		/// application has to persist data is by using an UnhandledExceptionFilter (see Structured Exception Handling). In general,
		/// UnhandledExceptionFilters are leveraged to try to persist data when an application is crashing (to disk, for example). Any code
		/// that executes during an UnhandledExceptionFilter is not guaranteed to reliably execute (due to possible process corruption). Any
		/// data that the UnhandledExceptionFilter manages to persist, before the UnhandledExceptionFilter crashes again, should be treated
		/// as suspect, and therefore inspected by a new, non-corrupted process to see if it is usable.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-setexceptionmode HRESULT SetExceptionMode( uint
		// RaiseFlags );
		[PreserveSig]
		HRESULT SetExceptionMode(D3D11_RAISE_FLAG RaiseFlags);

		/// <summary>Get the exception-mode flags.</summary>
		/// <returns>
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// A value that contains one or more exception flags; each flag specifies a condition which will cause an exception to be raised.
		/// The flags are listed in D3D11_RAISE_FLAG. A default value of 0 means there are no flags.
		/// </para>
		/// </returns>
		/// <remarks>An exception-mode flag is used to elevate an error condition to a non-continuable exception.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11device-getexceptionmode uint GetExceptionMode();
		[PreserveSig]
		D3D11_RAISE_FLAG GetExceptionMode();
	}

	/// <summary>A device-child interface accesses data used by a device.</summary>
	/// <remarks>
	/// <para>
	/// There are several types of device child interfaces, all of which inherit this interface. They include shaders, state objects, and
	/// input layouts.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11devicechild
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11DeviceChild")]
	[ComImport, Guid("1841e5c8-16b0-489b-bcc8-44cfb0d5deae"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>
	/// <para>The <c>ID3D11DeviceContext</c> interface represents a device context which generates rendering commands.</para>
	/// <para>
	/// <c>Note</c>  The latest version of this interface is ID3D11DeviceContext4 introduced in the Windows 10 Creators Update. Applications
	/// targetting Windows 10 Creators Update should use the <c>ID3D11DeviceContext4</c> interface instead of <c>ID3D11DeviceContext</c>.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11devicecontext
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11DeviceContext")]
	[ComImport, Guid("c0bfa96c-e089-44fb-8eaf-26f8796190da"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DeviceContext : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Sets the constant buffers used by the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 4*32-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 4*32-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the VSSetConstantBuffers1 method instead.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetconstantbuffers void
		// VSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		void VSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an array of shader resources to the pixel shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a rendertarget, then this API will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetshaderresources void
		// PSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		void PSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Sets a pixel shader to the device.</summary>
		/// <param name="pPixelShader">
		/// <para>Type: <c>ID3D11PixelShader*</c></para>
		/// <para>Pointer to a pixel shader (see ID3D11PixelShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// <para>
		/// Set ppClassInstances to <c>NULL</c> if no interfaces are used in the shader. If it is not <c>NULL</c>, the number of class
		/// instances must match the number of interfaces used in the shader. Furthermore, each interface pointer must have a corresponding
		/// class instance or the assigned shader will be disabled.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetshader void PSSetShader( [in,
		// optional] ID3D11PixelShader *pPixelShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		void PSSetShader(ID3D11PixelShader? pPixelShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>State</description>
		/// <description>Default Value</description>
		/// </listheader>
		/// <item>
		/// <description>Filter</description>
		/// <description>D3D11_FILTER_MIN_MAG_MIP_LINEAR</description>
		/// </item>
		/// <item>
		/// <description>AddressU</description>
		/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
		/// </item>
		/// <item>
		/// <description>AddressV</description>
		/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
		/// </item>
		/// <item>
		/// <description>AddressW</description>
		/// <description>D3D11_TEXTURE_ADDRESS_CLAMP</description>
		/// </item>
		/// <item>
		/// <description>MipLODBias</description>
		/// <description>0</description>
		/// </item>
		/// <item>
		/// <description>MaxAnisotropy</description>
		/// <description>1</description>
		/// </item>
		/// <item>
		/// <description>ComparisonFunc</description>
		/// <description>D3D11_COMPARISON_NEVER</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[0]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[1]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[2]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>BorderColor[3]</description>
		/// <description>1.0f</description>
		/// </item>
		/// <item>
		/// <description>MinLOD</description>
		/// <description>-FLT_MAX</description>
		/// </item>
		/// <item>
		/// <description>MaxLOD</description>
		/// <description>FLT_MAX</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetsamplers void PSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		void PSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Set a vertex shader to the device.</summary>
		/// <param name="pVertexShader">
		/// <para>Type: <c>ID3D11VertexShader*</c></para>
		/// <para>Pointer to a vertex shader (see ID3D11VertexShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetshader void VSSetShader( [in,
		// optional] ID3D11VertexShader *pVertexShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		void VSSetShader(ID3D11VertexShader? pVertexShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Draw indexed, non-instanced primitives.</summary>
		/// <param name="IndexCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of indices to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <c>INT</c></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>If the sum of both indices is negative, the result of the function call is undefined.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawindexed void DrawIndexed( [in] uint
		// IndexCount, [in] uint StartIndexLocation, [in] INT BaseVertexLocation );
		[PreserveSig]
		void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);

		/// <summary>Draw non-indexed, non-instanced primitives.</summary>
		/// <param name="VertexCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>Index of the first vertex, which is usually an offset in a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c>Draw</c> submits work to the rendering pipeline.</para>
		/// <para>The vertex data for a draw call normally comes from a vertex buffer that is bound to the pipeline.</para>
		/// <para>
		/// Even without any vertex buffer bound to the pipeline, you can generate your own vertex data in your vertex shader by using the
		/// SV_VertexID system-value semantic to determine the current vertex that the runtime is processing.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-draw void Draw( [in] uint VertexCount,
		// [in] uint StartVertexLocation );
		[PreserveSig]
		void Draw(uint VertexCount, uint StartVertexLocation);

		/// <summary>Gets a pointer to the data contained in a subresource, and denies the GPU access to that subresource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to a ID3D11Resource interface.</para>
		/// </param>
		/// <param name="Subresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>Index number of the subresource.</para>
		/// </param>
		/// <param name="MapType">
		/// <para>Type: <c>D3D11_MAP</c></para>
		/// <para>A D3D11_MAP-typed value that specifies the CPU's read and write permissions for a resource.</para>
		/// </param>
		/// <param name="MapFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Flag that specifies what the CPU does when the GPU is busy. This flag is optional.</para>
		/// </param>
		/// <param name="pMappedResource">
		/// <para>Type: <c>D3D11_MAPPED_SUBRESOURCE*</c></para>
		/// <para>
		/// A pointer to the D3D11_MAPPED_SUBRESOURCE structure for the mapped subresource. See the Remarks section regarding NULL pointers.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// <para>
		/// This method also returns <c>DXGI_ERROR_WAS_STILL_DRAWING</c> if <c>MapFlags</c> specifies <c>D3D11_MAP_FLAG_DO_NOT_WAIT</c> and
		/// the GPU is not yet finished with the resource.
		/// </para>
		/// <para>
		/// This method also returns <c>DXGI_ERROR_DEVICE_REMOVED</c> if <c>MapType</c> allows any CPU read access and the video card has
		/// been removed.
		/// </para>
		/// <para>For more information about these error codes, see DXGI_ERROR.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call <c>Map</c> on a deferred context, you can only pass D3D11_MAP_WRITE_DISCARD, D3D11_MAP_WRITE_NO_OVERWRITE, or both
		/// to the <c>MapType</c> parameter. Other <c>D3D11_MAP</c>-typed values are not supported for a deferred context.
		/// </para>
		/// <note>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, enables mapping dynamic constant buffers and
		/// shader resource views (SRVs) of dynamic buffers with D3D11_MAP_WRITE_NO_OVERWRITE. The Direct3D 11 and earlier runtimes limited
		/// mapping to vertex or index buffers. To determine if a Direct3D device supports these features, call
		/// ID3D11Device::CheckFeatureSupport with D3D11_FEATURE_D3D11_OPTIONS. <c>CheckFeatureSupport</c> fills members of a
		/// D3D11_FEATURE_DATA_D3D11_OPTIONS structure with the device's features. The relevant members here are
		/// <c>MapNoOverwriteOnDynamicConstantBuffer</c> and <c>MapNoOverwriteOnDynamicBufferSRV</c>.
		/// </note>
		/// <para>For info about how to use <c>Map</c>, see How to: Use dynamic resources.</para>
		/// <h2>NULL pointers for pMappedResource</h2>
		/// <para>
		/// The <c>pMappedResource</c> parameter may be NULL when a texture is provided that was created with D3D11_USAGE_DEFAULT, and the
		/// API is called on an immediate context. This allows a default texture to be mapped, even if it was created using
		/// D3D11_TEXTURE_LAYOUT_UNDEFINED. Following this API call, the texture may be accessed using
		/// ID3D11DeviceContext3::WriteToSubresource and/or ID3D11DeviceContext3::ReadFromSubresource.
		/// </para>
		/// <h2>Don't read from a subresource mapped for writing</h2>
		/// <para>
		/// When you pass D3D11_MAP_WRITE, D3D11_MAP_WRITE_DISCARD, or D3D11_MAP_WRITE_NO_OVERWRITE to the <c>MapType</c> parameter, you
		/// must ensure that your app does not read the subresource data to which the <c>pData</c> member of D3D11_MAPPED_SUBRESOURCE points
		/// because doing so can cause a significant performance penalty. The memory region to which <c>pData</c> points can be allocated
		/// with PAGE_WRITECOMBINE, and your app must honor all restrictions that are associated with such memory.
		/// </para>
		/// <note>  
		/// <para>
		/// Even the following C++ code can read from memory and trigger the performance penalty because the code can expand to the
		/// following x86 assembly code.
		/// </para>
		/// <code language="cpp">*((int*)MappedResource.pData) = 0;</code>
		/// <code language="none">AND DWORD PTR [EAX],0</code>
		/// </note>
		/// <para>
		/// Use the appropriate optimization settings and language constructs to help avoid this performance penalty. For example, you can
		/// avoid the xor optimization by using a <c>volatile</c> pointer or by optimizing for code speed instead of code size.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-map HRESULT Map( [in] ID3D11Resource
		// *pResource, [in] uint Subresource, [in] D3D11_MAP MapType, [in] uint MapFlags, [out, optional] D3D11_MAPPED_SUBRESOURCE
		// *pMappedResource );
		[PreserveSig]
		HRESULT Map([In] ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, [Optional] D3D11_MAP_FLAG MapFlags, out D3D11_MAPPED_SUBRESOURCE pMappedResource);

		/// <summary>Invalidate the pointer to a resource and reenable the GPU's access to that resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to a ID3D11Resource interface.</para>
		/// </param>
		/// <param name="Subresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>A subresource to be unmapped.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For info about how to use <c>Unmap</c>, see How to: Use dynamic resources.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-unmap void Unmap( [in] ID3D11Resource
		// *pResource, [in] uint Subresource );
		[PreserveSig]
		void Unmap(ID3D11Resource pResource, uint Subresource);

		/// <summary>Sets the constant buffers used by the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available on Windows 8 and later operating systems, can bind a larger number of ID3D11Buffer
		/// resources to the shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components
		/// each). When you bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer,
		/// as if 4096 constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// To enable the shader to access other parts of the buffer, call PSSetConstantBuffers1 instead of <c>PSSetConstantBuffers</c>.
		/// <c>PSSetConstantBuffers1</c> has additional parameters <c>pFirstConstant</c> and <c>pNumConstants</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-pssetconstantbuffers void
		// PSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		void PSSetConstantBuffers(uint StartSlot, int NumBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an input-layout object to the input-assembler stage.</summary>
		/// <param name="pInputLayout">
		/// <para>Type: <c>ID3D11InputLayout*</c></para>
		/// <para>
		/// A pointer to the input-layout object (see ID3D11InputLayout), which describes the input buffers that will be read by the IA stage.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Input-layout objects describe how vertex buffer data is streamed into the IA pipeline stage. To create an input-layout object,
		/// call ID3D11Device::CreateInputLayout.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetinputlayout void IASetInputLayout(
		// [in, optional] ID3D11InputLayout *pInputLayout );
		[PreserveSig]
		void IASetInputLayout(ID3D11InputLayout? pInputLayout);

		/// <summary>Bind an array of vertex buffers to the input-assembler stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The first input slot for binding. The first vertex buffer is explicitly bound to the start slot; this causes each additional
		/// vertex buffer in the array to be implicitly bound to each subsequent input slot. The maximum of 16 or 32 input slots (ranges
		/// from 0 to D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT - 1) are available; the maximum number of input slots depends on the feature level.
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of vertex buffers in the array. The number of buffers (plus the starting slot) can't exceed the total number of
		/// IA-stage input slots (ranges from 0 to D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppVertexBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// A pointer to an array of vertex buffers (see ID3D11Buffer). The vertex buffers must have been created with the
		/// D3D11_BIND_VERTEX_BUFFER flag.
		/// </para>
		/// </param>
		/// <param name="pStrides">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// Pointer to an array of stride values; one stride value for each buffer in the vertex-buffer array. Each stride is the size (in
		/// bytes) of the elements that are to be used from that vertex buffer.
		/// </para>
		/// </param>
		/// <param name="pOffsets">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// Pointer to an array of offset values; one offset value for each buffer in the vertex-buffer array. Each offset is the number of
		/// bytes between the first element of a vertex buffer and the first element that will be used.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For info about creating vertex buffers, see How to: Create a Vertex Buffer.</para>
		/// <para>
		/// Calling this method using a buffer that is currently bound for writing (that is, bound to the stream output pipeline stage) will
		/// effectively bind <c>NULL</c> instead because a buffer can't be bound as both an input and an output at the same time.
		/// </para>
		/// <para>
		/// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an
		/// output, but this will not prevent invalid data from being used by the runtime.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetvertexbuffers void
		// IASetVertexBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppVertexBuffers, [in,
		// optional] const uint *pStrides, [in, optional] const uint *pOffsets );
		[PreserveSig]
		void IASetVertexBuffers(uint StartSlot, int NumBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppVertexBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pStrides,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pOffsets);

		/// <summary>Bind an index buffer to the input-assembler stage.</summary>
		/// <param name="pIndexBuffer">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// A pointer to an ID3D11Buffer object, that contains indices. The index buffer must have been created with the
		/// D3D11_BIND_INDEX_BUFFER flag.
		/// </para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>
		/// A DXGI_FORMAT that specifies the format of the data in the index buffer. The only formats allowed for index buffer data are
		/// 16-bit (DXGI_FORMAT_R16_UINT) and 32-bit (DXGI_FORMAT_R32_UINT) integers.
		/// </para>
		/// </param>
		/// <param name="Offset">
		/// <para>Type: <c>uint</c></para>
		/// <para>Offset (in bytes) from the start of the index buffer to the first index to use.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For information about creating index buffers, see How to: Create an Index Buffer.</para>
		/// <para>
		/// Calling this method using a buffer that is currently bound for writing (i.e. bound to the stream output pipeline stage) will
		/// effectively bind <c>NULL</c> instead because a buffer cannot be bound as both an input and an output at the same time.
		/// </para>
		/// <para>
		/// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an
		/// output, but this will not prevent invalid data from being used by the runtime.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetindexbuffer void IASetIndexBuffer(
		// [in, optional] ID3D11Buffer *pIndexBuffer, [in] DXGI_FORMAT Format, [in] uint Offset );
		[PreserveSig]
		void IASetIndexBuffer(ID3D11Buffer? pIndexBuffer, DXGI_FORMAT Format, uint Offset);

		/// <summary>Draw indexed, instanced primitives.</summary>
		/// <param name="IndexCountPerInstance">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of indices read from the index buffer for each instance.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartIndexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>The location of the first index read by the GPU from the index buffer.</para>
		/// </param>
		/// <param name="BaseVertexLocation">
		/// <para>Type: <c>INT</c></para>
		/// <para>A value added to each index before reading a vertex from the vertex buffer.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing may extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors. Instancing requires multiple vertex buffers: at least one
		/// for per-vertex data and a second buffer for per-instance data.
		/// </para>
		/// <para>
		/// The second buffer is needed only if the input layout that you use has elements that use D3D11_INPUT_PER_INSTANCE_DATA as the
		/// input element classification buffer for per-instance data.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawindexedinstanced void
		// DrawIndexedInstanced( [in] uint IndexCountPerInstance, [in] uint InstanceCount, [in] uint StartIndexLocation, [in] INT
		// BaseVertexLocation, [in] uint StartInstanceLocation );
		[PreserveSig]
		void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		/// <summary>Draw non-indexed, instanced primitives.</summary>
		/// <param name="VertexCountPerInstance">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of vertices to draw.</para>
		/// </param>
		/// <param name="InstanceCount">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of instances to draw.</para>
		/// </param>
		/// <param name="StartVertexLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>Index of the first vertex.</para>
		/// </param>
		/// <param name="StartInstanceLocation">
		/// <para>Type: <c>uint</c></para>
		/// <para>A value added to each index before reading per-instance data from a vertex buffer.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A draw API submits work to the rendering pipeline.</para>
		/// <para>
		/// Instancing may extend performance by reusing the same geometry to draw multiple objects in a scene. One example of instancing
		/// could be to draw the same object with different positions and colors.
		/// </para>
		/// <para>
		/// The vertex data for an instanced draw call normally comes from a vertex buffer that is bound to the pipeline. However, you could
		/// also provide the vertex data from a shader that has instanced data identified with a system-value semantic (SV_InstanceID).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawinstanced void DrawInstanced( [in]
		// uint VertexCountPerInstance, [in] uint InstanceCount, [in] uint StartVertexLocation, [in] uint StartInstanceLocation );
		[PreserveSig]
		void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		/// <summary>Sets the constant buffers used by the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// You can't use the ID3D11ShaderReflectionConstantBuffer interface to get information about what is currently bound to the
		/// pipeline in the device context. But you can use <c>ID3D11ShaderReflectionConstantBuffer</c> to get information from a compiled
		/// shader. For example, you can use <c>ID3D11ShaderReflectionConstantBuffer</c> and ID3D11ShaderReflectionVariable to determine the
		/// slot in which a geometry shader expects a constant buffer. You can then pass this slot number to <c>GSSetConstantBuffers</c> to
		/// set the constant buffer. You can call the D3D11Reflect function to retrieve the address of a pointer to the
		/// ID3D11ShaderReflection interface and then call ID3D11ShaderReflection::GetConstantBufferByName to get a pointer to <c>ID3D11ShaderReflectionConstantBuffer</c>.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the GSSetConstantBuffers1 method instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetconstantbuffers void
		// GSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		void GSSetConstantBuffers(uint StartSlot, int NumBuffers,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Set a geometry shader to the device.</summary>
		/// <param name="pShader">
		/// <para>Type: <c>ID3D11GeometryShader*</c></para>
		/// <para>
		/// Pointer to a geometry shader (see ID3D11GeometryShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.
		/// </para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetshader void GSSetShader( [in,
		// optional] ID3D11GeometryShader *pShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		void GSSetShader(ID3D11GeometryShader? pShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Bind information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="Topology">
		/// <para>Type: <c>D3D11_PRIMITIVE_TOPOLOGY</c></para>
		/// <para>The type of primitive and ordering of the primitive data (see D3D11_PRIMITIVE_TOPOLOGY).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iasetprimitivetopology void
		// IASetPrimitiveTopology( [in] D3D11_PRIMITIVE_TOPOLOGY Topology );
		[PreserveSig]
		void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);

		/// <summary>Bind an array of shader resources to the vertex-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (range is from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources (range is from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a rendertarget, then this API will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// In order to unbind resource slots, you must pass an array containing null values. For example, to clear the first 4 slots, use:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetshaderresources void
		// VSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		void VSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set an array of sampler states to the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vssetsamplers void VSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		void VSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Mark the beginning of a series of commands.</summary>
		/// <param name="pAsync">
		/// <para>Type: <c>ID3D11Asynchronous*</c></para>
		/// <para>A pointer to an ID3D11Asynchronous interface.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Use ID3D11DeviceContext::End to mark the ending of the series of commands.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-begin void Begin( [in] ID3D11Asynchronous
		// *pAsync );
		[PreserveSig]
		void Begin([In] ID3D11Asynchronous pAsync);

		/// <summary>Mark the end of a series of commands.</summary>
		/// <param name="pAsync">
		/// <para>Type: <c>ID3D11Asynchronous*</c></para>
		/// <para>A pointer to an ID3D11Asynchronous interface.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Use ID3D11DeviceContext::Begin to mark the beginning of the series of commands.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-end void End( [in] ID3D11Asynchronous
		// *pAsync );
		[PreserveSig]
		void End([In] ID3D11Asynchronous pAsync);

		/// <summary>Get data from the graphics processing unit (GPU) asynchronously.</summary>
		/// <param name="pAsync">
		/// <para>Type: <c>ID3D11Asynchronous*</c></para>
		/// <para>A pointer to an ID3D11Asynchronous interface for the object about which <c>GetData</c> retrieves data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// Address of memory that will receive the data. If <c>NULL</c>, <c>GetData</c> will be used only to check status. The type of data
		/// output depends on the type of asynchronous interface.
		/// </para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data to retrieve or 0. Must be 0 when <c>pData</c> is <c>NULL</c>.</para>
		/// </param>
		/// <param name="GetDataFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Optional flags. Can be 0 or any combination of the flags enumerated by D3D11_ASYNC_GETDATA_FLAG.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns one of the Direct3D 11 Return Codes. A return value of S_OK indicates that the data at <c>pData</c> is
		/// available for the calling application to access. A return value of S_FALSE indicates that the data is not yet available. If the
		/// data is not yet available, the application must call <c>GetData</c> until the data is available.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Queries in a deferred context are limited to predicated drawing. That is, you cannot call <c>ID3D11DeviceContext::GetData</c> on
		/// a deferred context to get data about a query; you can only call <c>GetData</c> on the immediate context to get data about a
		/// query. For predicated drawing, the results of a predication-type query are used by the GPU and not returned to an application.
		/// For more information about predication and predicated drawing, see D3D11DeviceContext::SetPredication.
		/// </para>
		/// <para>
		/// <c>GetData</c> retrieves the data that the runtime collected between calls to ID3D11DeviceContext::Begin and
		/// ID3D11DeviceContext::End. Certain queries only require a call to <c>ID3D11DeviceContext::End</c> in which case the data returned
		/// by <c>GetData</c> is accurate up to the last call to <c>ID3D11DeviceContext::End</c>. For information about the queries that
		/// only require a call to <c>ID3D11DeviceContext::End</c> and about the type of data that <c>GetData</c> retrieves for each query,
		/// see D3D11_QUERY.
		/// </para>
		/// <para>If <c>DataSize</c> is 0, <c>GetData</c> is only used to check status.</para>
		/// <para>
		/// An application gathers counter data by calling ID3D11DeviceContext::Begin, issuing some graphics commands, calling
		/// ID3D11DeviceContext::End, and then calling <c>ID3D11DeviceContext::GetData</c> to get data about what happened in between the
		/// <c>Begin</c> and <c>End</c> calls. For information about performance counter types, see D3D11_COUNTER.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getdata HRESULT GetData( [in]
		// ID3D11Asynchronous *pAsync, [out, optional] void *pData, [in] uint DataSize, [in] uint GetDataFlags );
		[PreserveSig]
		HRESULT GetData(ID3D11Asynchronous pAsync, [In, Optional] IntPtr pData, uint DataSize, D3D11_ASYNC_GETDATA_FLAG GetDataFlags);

		/// <summary>Set a rendering predicate.</summary>
		/// <param name="pPredicate">
		/// <para>Type: <c>ID3D11Predicate*</c></para>
		/// <para>
		/// A pointer to the ID3D11Predicate interface that represents the rendering predicate. A <c>NULL</c> value indicates "no"
		/// predication; in this case, the value of <c>PredicateValue</c> is irrelevant but will be preserved for ID3D11DeviceContext::GetPredication.
		/// </para>
		/// </param>
		/// <param name="PredicateValue">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, rendering will be affected by when the predicate's conditions are met. If <c>FALSE</c>, rendering will be
		/// affected when the conditions are not met.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The predicate must be in the "issued" or "signaled" state to be used for predication. While the predicate is set for
		/// predication, calls to ID3D11DeviceContext::Begin and ID3D11DeviceContext::End are invalid.
		/// </para>
		/// <para>
		/// Use this method to denote that subsequent rendering and resource manipulation commands are not actually performed if the
		/// resulting predicate data of the predicate is equal to the <c>PredicateValue</c>. However, some predicates are only hints, so
		/// they may not actually prevent operations from being performed.
		/// </para>
		/// <para>
		/// The primary usefulness of predication is to allow an application to issue rendering and resource manipulation commands without
		/// taking the performance hit of spinning, waiting for ID3D11DeviceContext::GetData to return. So, predication can occur while
		/// <c>ID3D11DeviceContext::GetData</c> returns <c>S_FALSE</c>. Another way to think of it: an application can also use predication
		/// as a fallback, if it is possible that <c>ID3D11DeviceContext::GetData</c> returns <c>S_FALSE</c>. If
		/// <c>ID3D11DeviceContext::GetData</c> returns <c>S_OK</c>, the application can skip calling the rendering and resource
		/// manipulation commands manually with its own application logic.
		/// </para>
		/// <para>
		/// Rendering and resource manipulation commands for Direct3D 11 include these Draw, Dispatch, Copy, Update, Clear, Generate, and
		/// Resolve operations.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Draw</description>
		/// </item>
		/// <item>
		/// <description>DrawAuto</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexed</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexedInstanced</description>
		/// </item>
		/// <item>
		/// <description>DrawIndexedInstancedIndirect</description>
		/// </item>
		/// <item>
		/// <description>DrawInstanced</description>
		/// </item>
		/// <item>
		/// <description>DrawInstancedIndirect</description>
		/// </item>
		/// <item>
		/// <description>Dispatch</description>
		/// </item>
		/// <item>
		/// <description>DispatchIndirect</description>
		/// </item>
		/// <item>
		/// <description>CopyResource</description>
		/// </item>
		/// <item>
		/// <description>CopyStructureCount</description>
		/// </item>
		/// <item>
		/// <description>CopySubresourceRegion</description>
		/// </item>
		/// <item>
		/// <description>CopySubresourceRegion1</description>
		/// </item>
		/// <item>
		/// <description>CopyTiles</description>
		/// </item>
		/// <item>
		/// <description>CopyTileMappings</description>
		/// </item>
		/// <item>
		/// <description>UpdateSubresource</description>
		/// </item>
		/// <item>
		/// <description>UpdateSubresource1</description>
		/// </item>
		/// <item>
		/// <description>UpdateTiles</description>
		/// </item>
		/// <item>
		/// <description>UpdateTileMappings</description>
		/// </item>
		/// <item>
		/// <description>ClearRenderTargetView</description>
		/// </item>
		/// <item>
		/// <description>ClearUnorderedAccessViewFloat</description>
		/// </item>
		/// <item>
		/// <description>ClearUnorderedAccessViewUint</description>
		/// </item>
		/// <item>
		/// <description>ClearView</description>
		/// </item>
		/// <item>
		/// <description>ClearDepthStencilView</description>
		/// </item>
		/// <item>
		/// <description>GenerateMips</description>
		/// </item>
		/// <item>
		/// <description>ResolveSubresource</description>
		/// </item>
		/// </list>
		/// <para>
		/// You can set a rendering predicate on an immediate or a deferred context. For info about immediate and deferred contexts, see
		/// Immediate and Deferred Rendering.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-setpredication void SetPredication( [in,
		// optional] ID3D11Predicate *pPredicate, [in] BOOL PredicateValue );
		[PreserveSig]
		void SetPredication([In, Optional] ID3D11Predicate? pPredicate, bool PredicateValue);

		/// <summary>Bind an array of shader resources to the geometry shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetshaderresources void
		// GSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		void GSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set an array of sampler states to the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gssetsamplers void GSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		void GSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Bind one or more render targets atomically and the depth-stencil buffer to the output-merger stage.</summary>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of render targets to bind (ranges between 0 and <c>D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT</c>). If this parameter is
		/// nonzero, the number of entries in the array to which <c>ppRenderTargetViews</c> points must equal the number in this parameter.
		/// </para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView*</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetView that represent the render targets to bind to the device. If this parameter is
		/// <c>NULL</c> and <c>NumViews</c> is 0, no render targets are bound.
		/// </para>
		/// </param>
		/// <param name="pDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView*</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView that represents the depth-stencil view to bind to the device. If this parameter is
		/// <c>NULL</c>, the depth-stencil view is not bound.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The maximum number of active render targets a device can have active at any given time is set by a #define in D3D11.h called
		/// <c>D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT</c>. It is invalid to try to set the same subresource to multiple render target slots.
		/// Any render targets not defined by this call are set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// If any subresources are also currently bound for reading in a different stage or writing (perhaps in a different part of the
		/// pipeline), those bind points will be set to <c>NULL</c>, in order to prevent the same subresource from being read and written
		/// simultaneously in a single rendering operation.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// If the render-target views were created from an array resource type, all of the render-target views must have the same array
		/// size. This restriction also applies to the depth-stencil view, its array size must match that of the render-target views being bound.
		/// </para>
		/// <para>
		/// The pixel shader must be able to simultaneously render to at least eight separate render targets. All of these render targets
		/// must access the same type of resource: Buffer, Texture1D, Texture1DArray, Texture2D, Texture2DArray, Texture3D, or TextureCube.
		/// All render targets must have the same size in all dimensions (width and height, and depth for 3D or array size for *Array
		/// types). If render targets use multisample anti-aliasing, all bound render targets and depth buffer must be the same form of
		/// multisample resource (that is, the sample counts must be the same). Each render target can have a different data format. These
		/// render target formats are not required to have identical bit-per-element counts.
		/// </para>
		/// <para>Any combination of the eight slots for render targets can have a render target set or not set.</para>
		/// <para>
		/// The same resource view cannot be bound to multiple render target slots simultaneously. However, you can set multiple
		/// non-overlapping resource views of a single resource as simultaneous multiple render targets.
		/// </para>
		/// <para>
		/// Note that unlike some other resource methods in Direct3D, all currently bound render targets will be unbound by calling .
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetrendertargets void
		// OMSetRenderTargets( [in] uint NumViews, [in, optional] ID3D11RenderTargetView * const *ppRenderTargetViews, [in, optional]
		// ID3D11DepthStencilView *pDepthStencilView );
		[PreserveSig]
		void OMSetRenderTargets(int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			[In, Optional] ID3D11DepthStencilView? pDepthStencilView);

		/// <summary>Binds resources to the output-merger stage.</summary>
		/// <param name="NumRTVs">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of render targets to bind (ranges between 0 and <c>D3D11_SIMULTANEOUS_RENDER_TARGET_COUNT</c>). If this parameter is
		/// nonzero, the number of entries in the array to which <c>ppRenderTargetViews</c> points must equal the number in this parameter.
		/// If you set <c>NumRTVs</c> to D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL (0xffffffff), this method does not modify the currently
		/// bound render-target views (RTVs) and also does not modify depth-stencil view (DSV).
		/// </para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView*</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetViews that represent the render targets to bind to the device. If this parameter is
		/// <c>NULL</c> and <c>NumRTVs</c> is 0, no render targets are bound.
		/// </para>
		/// </param>
		/// <param name="pDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView*</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView that represents the depth-stencil view to bind to the device. If this parameter is
		/// <c>NULL</c>, the depth-stencil view is not bound.
		/// </para>
		/// </param>
		/// <param name="UAVStartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin setting unordered-access views (ranges from 0 to D3D11_PS_CS_UAV_REGISTER_COUNT - 1).
		/// </para>
		/// <para>
		/// For the Direct3D 11.1 runtime, which is available starting with Windows 8, this value can range from 0 to D3D11_1_UAV_SLOT_COUNT
		/// - 1. D3D11_1_UAV_SLOT_COUNT is defined as 64.
		/// </para>
		/// <para>For pixel shaders, <c>UAVStartSlot</c> should be equal to the number of render-target views being bound.</para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of unordered-access views (UAVs) in <c>ppUnorderedAccessViews</c>. If you set <c>NumUAVs</c> to
		/// D3D11_KEEP_UNORDERED_ACCESS_VIEWS (0xffffffff), this method does not modify the currently bound unordered-access views.
		/// </para>
		/// <para>
		/// For the Direct3D 11.1 runtime, which is available starting with Windows 8, this value can range from 0 to D3D11_1_UAV_SLOT_COUNT
		/// - <c>UAVStartSlot</c>.
		/// </para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>
		/// Pointer to an array of ID3D11UnorderedAccessViews that represent the unordered-access views to bind to the device. If this
		/// parameter is <c>NULL</c> and <c>NumUAVs</c> is 0, no unordered-access views are bound.
		/// </para>
		/// </param>
		/// <param name="pUAVInitialCounts">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// An array of append and consume buffer offsets. A value of -1 indicates to keep the current offset. Any other values set the
		/// hidden counter for that appendable and consumable UAV. <c>pUAVInitialCounts</c> is relevant only for UAVs that were created with
		/// either D3D11_BUFFER_UAV_FLAG_APPEND or <c>D3D11_BUFFER_UAV_FLAG_COUNTER</c> specified when the UAV was created; otherwise, the
		/// argument is ignored.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// For pixel shaders, the render targets and unordered-access views share the same resource slots when being written out. This
		/// means that UAVs must be given an offset so that they are placed in the slots after the render target views that are being bound.
		/// </para>
		/// <para><c>Note</c>  RTVs, DSV, and UAVs cannot be set independently; they all need to be set at the same time.</para>
		/// <para></para>
		/// <para>Two RTVs conflict if they share a subresource (and therefore share the same resource).</para>
		/// <para>Two UAVs conflict if they share a subresource (and therefore share the same resource).</para>
		/// <para>An RTV conflicts with a UAV if they share a subresource or share a bind point.</para>
		/// <para><c>OMSetRenderTargetsAndUnorderedAccessViews</c> operates properly in the following situations:</para>
		/// <list type="number">
		/// <item>
		/// <description><c>NumRTVs</c> != D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL and <c>NumUAVs</c> != D3D11_KEEP_UNORDERED_ACCESS_VIEWS
		/// <para>
		/// The following conditions must be true for <c>OMSetRenderTargetsAndUnorderedAccessViews</c> to succeed and for the runtime to
		/// pass the bind information to the driver:
		/// </para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> performs the following tasks:
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>NumRTVs</c> == D3D11_KEEP_RENDER_TARGETS_AND_DEPTH_STENCIL
		/// <para>In this situation, <c>OMSetRenderTargetsAndUnorderedAccessViews</c> binds only UAVs.</para>
		/// <para>
		/// The following conditions must be true for <c>OMSetRenderTargetsAndUnorderedAccessViews</c> to succeed and for the runtime to
		/// pass the bind information to the driver:
		/// </para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> unbinds the following items: <c>OMSetRenderTargetsAndUnorderedAccessViews</c>
		/// binds <c>ppUnorderedAccessViews</c>.
		/// <para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> ignores <c>ppDepthStencilView</c>, and the current depth-stencil view remains bound.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>NumUAVs</c> == D3D11_KEEP_UNORDERED_ACCESS_VIEWS
		/// <para>In this situation, <c>OMSetRenderTargetsAndUnorderedAccessViews</c> binds only RTVs and DSV.</para>
		/// <para>
		/// The following conditions must be true for <c>OMSetRenderTargetsAndUnorderedAccessViews</c> to succeed and for the runtime to
		/// pass the bind information to the driver:
		/// </para>
		/// <c>OMSetRenderTargetsAndUnorderedAccessViews</c> unbinds the following items: <c>OMSetRenderTargetsAndUnorderedAccessViews</c>
		/// binds <c>ppRenderTargetViews</c> and <c>ppDepthStencilView</c>.
		/// <para><c>OMSetRenderTargetsAndUnorderedAccessViews</c> ignores <c>UAVStartSlot</c>.</para>
		/// </description>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetrendertargetsandunorderedaccessviews
		// void OMSetRenderTargetsAndUnorderedAccessViews( [in] uint NumRTVs, [in, optional] ID3D11RenderTargetView * const
		// *ppRenderTargetViews, [in, optional] ID3D11DepthStencilView *pDepthStencilView, [in] uint UAVStartSlot, [in] uint NumUAVs, [in,
		// optional] ID3D11UnorderedAccessView * const *ppUnorderedAccessViews, [in, optional] const uint *pUAVInitialCounts );
		[PreserveSig]
		void OMSetRenderTargetsAndUnorderedAccessViews(int NumRTVs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			[In, Optional] ID3D11DepthStencilView? pDepthStencilView, uint UAVStartSlot, int NumUAVs, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[]? pUAVInitialCounts);

		/// <summary>Set the blend state of the output-merger stage.</summary>
		/// <param name="pBlendState">
		/// <para>Type: <c>ID3D11BlendState*</c></para>
		/// <para>
		/// Pointer to a blend-state interface (see ID3D11BlendState). Pass <c>NULL</c> for a default blend state. For more info about
		/// default blend state, see Remarks.
		/// </para>
		/// </param>
		/// <param name="BlendFactor">
		/// <para>Type: <c>const FLOAT[4]</c></para>
		/// <para>
		/// Array of blend factors, one for each RGBA component. The blend factors modulate values for the pixel shader, render target, or
		/// both. If you created the blend-state object with D3D11_BLEND_BLEND_FACTOR or D3D11_BLEND_INV_BLEND_FACTOR, the blending stage
		/// uses the non-NULL array of blend factors. If you didn't create the blend-state object with <c>D3D11_BLEND_BLEND_FACTOR</c> or
		/// <c>D3D11_BLEND_INV_BLEND_FACTOR</c>, the blending stage does not use the non-NULL array of blend factors; the runtime stores the
		/// blend factors, and you can later call ID3D11DeviceContext::OMGetBlendState to retrieve the blend factors. If you pass
		/// <c>NULL</c>, the runtime uses or stores a blend factor equal to { 1, 1, 1, 1 }.
		/// </para>
		/// </param>
		/// <param name="SampleMask">
		/// <para>Type: <c>uint</c></para>
		/// <para>32-bit sample coverage. The default value is 0xffffffff. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Blend state is used by the output-merger stage to determine how to blend together two RGB pixel values and two alpha values. The
		/// two RGB pixel values and two alpha values are the RGB pixel value and alpha value that the pixel shader outputs and the RGB
		/// pixel value and alpha value already in the output render target. The blend option controls the data source that the blending
		/// stage uses to modulate values for the pixel shader, render target, or both. The blend operation controls how the blending stage
		/// mathematically combines these modulated values.
		/// </para>
		/// <para>To create a blend-state interface, call ID3D11Device::CreateBlendState.</para>
		/// <para>
		/// Passing in <c>NULL</c> for the blend-state interface indicates to the runtime to set a default blending state. The following
		/// table indicates the default blending parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>State</description>
		/// <description>Default Value</description>
		/// </listheader>
		/// <item>
		/// <description>AlphaToCoverageEnable</description>
		/// <description><c>FALSE</c></description>
		/// </item>
		/// <item>
		/// <description>IndependentBlendEnable</description>
		/// <description><c>FALSE</c></description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].BlendEnable</description>
		/// <description><c>FALSE</c></description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].SrcBlend</description>
		/// <description>D3D11_BLEND_ONE</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].DestBlend</description>
		/// <description>D3D11_BLEND_ZERO</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].BlendOp</description>
		/// <description>D3D11_BLEND_OP_ADD</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].SrcBlendAlpha</description>
		/// <description>D3D11_BLEND_ONE</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].DestBlendAlpha</description>
		/// <description>D3D11_BLEND_ZERO</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].BlendOpAlpha</description>
		/// <description>D3D11_BLEND_OP_ADD</description>
		/// </item>
		/// <item>
		/// <description>RenderTarget[0].RenderTargetWriteMask</description>
		/// <description>D3D11_COLOR_WRITE_ENABLE_ALL</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>
		/// A sample mask determines which samples get updated in all the active render targets. The mapping of bits in a sample mask to
		/// samples in a multisample render target is the responsibility of an individual application. A sample mask is always applied; it
		/// is independent of whether multisampling is enabled, and does not depend on whether an application uses multisample render targets.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetblendstate void OMSetBlendState( [in,
		// optional] ID3D11BlendState *pBlendState, [in, optional] const FLOAT [4] BlendFactor, [in] uint SampleMask );
		[PreserveSig]
		void OMSetBlendState([In, Optional] ID3D11BlendState? pBlendState, [In, Optional, MarshalAs(UnmanagedType.LPArray)] float[]? BlendFactor, uint SampleMask = uint.MaxValue);

		/// <summary>Sets the depth-stencil state of the output-merger stage.</summary>
		/// <param name="pDepthStencilState">
		/// <para>Type: <c>ID3D11DepthStencilState*</c></para>
		/// <para>
		/// Pointer to a depth-stencil state interface (see ID3D11DepthStencilState) to bind to the device. Set this to <c>NULL</c> to use
		/// the default state listed in D3D11_DEPTH_STENCIL_DESC.
		/// </para>
		/// </param>
		/// <param name="StencilRef">
		/// <para>Type: <c>uint</c></para>
		/// <para>Reference value to perform against when doing a depth-stencil test. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To create a depth-stencil state interface, call ID3D11Device::CreateDepthStencilState.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omsetdepthstencilstate void
		// OMSetDepthStencilState( [in, optional] ID3D11DepthStencilState *pDepthStencilState, [in] uint StencilRef );
		[PreserveSig]
		void OMSetDepthStencilState([In, Optional] ID3D11DepthStencilState? pDepthStencilState, uint StencilRef);

		/// <summary>Set the target output buffers for the stream-output stage of the pipeline.</summary>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of buffer to bind to the device. A maximum of four output buffers can be set. If less than four are defined by the
		/// call, the remaining buffer slots are set to <c>NULL</c>. See Remarks.
		/// </para>
		/// </param>
		/// <param name="ppSOTargets">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// The array of output buffers (see ID3D11Buffer) to bind to the device. The buffers must have been created with the
		/// D3D11_BIND_STREAM_OUTPUT flag.
		/// </para>
		/// </param>
		/// <param name="pOffsets">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// Array of offsets to the output buffers from <c>ppSOTargets</c>, one offset for each buffer. The offset values must be in bytes.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// An offset of -1 will cause the stream output buffer to be appended, continuing after the last location written to the buffer in
		/// a previous stream output pass.
		/// </para>
		/// <para>
		/// Calling this method using a buffer that is currently bound for writing will effectively bind <c>NULL</c> instead because a
		/// buffer cannot be bound as both an input and an output at the same time.
		/// </para>
		/// <para>
		/// The debug layer will generate a warning whenever a resource is prevented from being bound simultaneously as an input and an
		/// output, but this will not prevent invalid data from being used by the runtime.
		/// </para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>Note that unlike some other resource methods in Direct3D, all currently bound targets will be unbound by calling .</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-sosettargets void SOSetTargets( [in] uint
		// NumBuffers, [in, optional] ID3D11Buffer * const *ppSOTargets, [in, optional] const uint *pOffsets );
		[PreserveSig]
		void SOSetTargets([Optional] int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11Buffer[]? ppSOTargets,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[]? pOffsets);

		/// <summary>Draw geometry of an unknown size.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// A draw API submits work to the rendering pipeline. This API submits work of an unknown size that was processed by the input
		/// assembler, vertex shader, and stream-output stages; the work may or may not have gone through the geometry-shader stage.
		/// </para>
		/// <para>
		/// After data has been streamed out to stream-output stage buffers, those buffers can be again bound to the Input Assembler stage
		/// at input slot 0 and DrawAuto will draw them without the application needing to know the amount of data that was written to the
		/// buffers. A measurement of the amount of data written to the SO stage buffers is maintained internally when the data is streamed
		/// out. This means that the CPU does not need to fetch the measurement before re-binding the data that was streamed as input data.
		/// Although this amount is tracked internally, it is still the responsibility of applications to use input layouts to describe the
		/// format of the data in the SO stage buffers so that the layouts are available when the buffers are again bound to the input assembler.
		/// </para>
		/// <para>The following diagram shows the DrawAuto process.</para>
		/// <para>Calling DrawAuto does not change the state of the streaming-output buffers that were bound again as inputs.</para>
		/// <para>
		/// DrawAuto only works when drawing with one input buffer bound as an input to the IA stage at slot 0. Applications must create the
		/// SO buffer resource with both binding flags, D3D11_BIND_VERTEX_BUFFER and <c>D3D11_BIND_STREAM_OUTPUT</c>.
		/// </para>
		/// <para>This API does not support indexing or instancing.</para>
		/// <para>
		/// If an application needs to retrieve the size of the streaming-output buffer, it can query for statistics on streaming output by
		/// using D3D11_QUERY_SO_STATISTICS.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawauto void DrawAuto();
		[PreserveSig]
		void DrawAuto();

		/// <summary>Draw indexed, instanced, GPU-generated primitives.</summary>
		/// <param name="pBufferForArgs">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer, which is a buffer containing the GPU-generated primitives.</para>
		/// </param>
		/// <param name="AlignedByteOffsetForArgs">
		/// <para>Type: <c>uint</c></para>
		/// <para>A DWORD-aligned byte offset in <c>pBufferForArgs</c> to the start of the GPU generated primitives.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// When an application creates a buffer that is associated with the ID3D11Buffer interface that pBufferForArgs points to, your
		/// application must set the D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS flag in the MiscFlags member of the D3D11_BUFFER_DESC structure
		/// that describes the buffer. To create the buffer, your application should call the ID3D11Device::CreateBuffer method, and pass a
		/// pointer to a <c>D3D11_BUFFER_DESC</c> in the pDesc parameter.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawindexedinstancedindirect void
		// DrawIndexedInstancedIndirect( [in] ID3D11Buffer *pBufferForArgs, [in] uint AlignedByteOffsetForArgs );
		[PreserveSig]
		void DrawIndexedInstancedIndirect([In] ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		/// <summary>Draw instanced, GPU-generated primitives.</summary>
		/// <param name="pBufferForArgs">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer, which is a buffer containing the GPU generated primitives.</para>
		/// </param>
		/// <param name="AlignedByteOffsetForArgs">
		/// <para>Type: <c>uint</c></para>
		/// <para>Offset in <c>pBufferForArgs</c> to the start of the GPU generated primitives.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When an application creates a buffer that is associated with the ID3D11Buffer interface that <c>pBufferForArgs</c> points to,
		/// the application must set the D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS flag in the <c>MiscFlags</c> member of the D3D11_BUFFER_DESC
		/// structure that describes the buffer. To create the buffer, the application calls the ID3D11Device::CreateBuffer method and in
		/// this call passes a pointer to <c>D3D11_BUFFER_DESC</c> in the <c>pDesc</c> parameter.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-drawinstancedindirect void
		// DrawInstancedIndirect( [in] ID3D11Buffer *pBufferForArgs, [in] uint AlignedByteOffsetForArgs );
		[PreserveSig]
		void DrawInstancedIndirect([In] ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		/// <summary>Execute a command list from a thread group.</summary>
		/// <param name="ThreadGroupCountX">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of groups dispatched in the x direction. <c>ThreadGroupCountX</c> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountY">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of groups dispatched in the y direction. <c>ThreadGroupCountY</c> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535).
		/// </para>
		/// </param>
		/// <param name="ThreadGroupCountZ">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of groups dispatched in the z direction. <c>ThreadGroupCountZ</c> must be less than or equal to
		/// D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION (65535). In feature level 10 the value for <c>ThreadGroupCountZ</c> must be 1.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You call the <c>Dispatch</c> method to execute commands in a compute shader. A compute shader can be run on many threads in
		/// parallel, within a thread group. Index a particular thread, within a thread group using a 3D vector given by (x,y,z).
		/// </para>
		/// <para>
		/// In the following illustration, assume a thread group with 50 threads where the size of the group is given by (5,5,2). A single
		/// thread is identified from a thread group with 50 threads in it, using the vector (4,1,1).
		/// </para>
		/// <para>
		/// The following illustration shows the relationship between the parameters passed to <c>ID3D11DeviceContext::Dispatch</c>,
		/// Dispatch(5,3,2), the values specified in the numthreads attribute, numthreads(10,8,3), and values that will passed to the
		/// compute shader for the thread-related system values (SV_GroupIndex,SV_DispatchThreadID,SV_GroupThreadID,SV_GroupID).
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dispatch void Dispatch( [in] uint
		// ThreadGroupCountX, [in] uint ThreadGroupCountY, [in] uint ThreadGroupCountZ );
		[PreserveSig]
		void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		/// <summary>Execute a command list over one or more thread groups.</summary>
		/// <param name="pBufferForArgs">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>A pointer to an ID3D11Buffer, which must be loaded with data that matches the argument list for ID3D11DeviceContext::Dispatch.</para>
		/// </param>
		/// <param name="AlignedByteOffsetForArgs">
		/// <para>Type: <c>uint</c></para>
		/// <para>A byte-aligned offset between the start of the buffer and the arguments.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>You call the <c>DispatchIndirect</c> method to execute commands in a compute shader.</para>
		/// <para>
		/// When an application creates a buffer that is associated with the ID3D11Buffer interface that <c>pBufferForArgs</c> points to,
		/// the application must set the D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS flag in the <c>MiscFlags</c> member of the D3D11_BUFFER_DESC
		/// structure that describes the buffer. To create the buffer, the application calls the ID3D11Device::CreateBuffer method and in
		/// this call passes a pointer to <c>D3D11_BUFFER_DESC</c> in the <c>pDesc</c> parameter.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dispatchindirect void DispatchIndirect(
		// [in] ID3D11Buffer *pBufferForArgs, [in] uint AlignedByteOffsetForArgs );
		[PreserveSig]
		void DispatchIndirect([In] ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		/// <summary>Set the rasterizer state for the rasterizer stage of the pipeline.</summary>
		/// <param name="pRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState*</c></para>
		/// <para>Pointer to a rasterizer-state interface (see ID3D11RasterizerState) to bind to the pipeline.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To create a rasterizer state interface, call ID3D11Device::CreateRasterizerState.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rssetstate void RSSetState( [in, optional]
		// ID3D11RasterizerState *pRasterizerState );
		[PreserveSig]
		void RSSetState([In, Optional] ID3D11RasterizerState? pRasterizerState);

		/// <summary>Bind an array of viewports to the rasterizer stage of the pipeline.</summary>
		/// <param name="NumViewports">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of viewports to bind.</para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <c>const D3D11_VIEWPORT*</c></para>
		/// <para>
		/// An array of D3D11_VIEWPORT structures to bind to the device. See the structure page for details about how the viewport size is
		/// dependent on the device feature level which has changed between Direct3D 11 and Direct3D 10.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All viewports must be set atomically as one operation. Any viewports not defined by the call are disabled.</para>
		/// <para>
		/// Which viewport to use is determined by the SV_ViewportArrayIndex semantic output by a geometry shader; if a geometry shader does
		/// not specify the semantic, Direct3D will use the first viewport in the array.
		/// </para>
		/// <para>
		/// <c>Note</c>  Even though you specify float values to the members of the D3D11_VIEWPORT structure for the <c>pViewports</c> array
		/// in a call to <c>ID3D11DeviceContext::RSSetViewports</c> for feature levels 9_x, <c>RSSetViewports</c> uses DWORDs internally.
		/// Because of this behavior, when you use a negative top left corner for the viewport, the call to <c>RSSetViewports</c> for
		/// feature levels 9_x fails. This failure occurs because <c>RSSetViewports</c> for 9_x casts the floating point values into
		/// unsigned integers without validation, which results in integer overflow.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rssetviewports void RSSetViewports( [in]
		// uint NumViewports, [in, optional] const D3D11_VIEWPORT *pViewports );
		[PreserveSig]
		void RSSetViewports([Optional] int NumViewports, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[]? pViewports);

		/// <summary>Bind an array of scissor rectangles to the rasterizer stage.</summary>
		/// <param name="NumRects">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of scissor rectangles to bind.</para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <c>const D3D11_RECT*</c></para>
		/// <para>An array of scissor rectangles (see D3D11_RECT).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>All scissor rects must be set atomically as one operation. Any scissor rects not defined by the call are disabled.</para>
		/// <para>The scissor rectangles will only be used if ScissorEnable is set to true in the rasterizer state (see D3D11_RASTERIZER_DESC).</para>
		/// <para>
		/// Which scissor rectangle to use is determined by the SV_ViewportArrayIndex semantic output by a geometry shader (see shader
		/// semantic syntax). If a geometry shader does not make use of the SV_ViewportArrayIndex semantic then Direct3D will use the first
		/// scissor rectangle in the array.
		/// </para>
		/// <para>Each scissor rectangle in the array corresponds to a viewport in an array of viewports (see ID3D11DeviceContext::RSSetViewports).</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rssetscissorrects void RSSetScissorRects(
		// [in] uint NumRects, [in, optional] const D3D11_RECT *pRects );
		[PreserveSig]
		void RSSetScissorRects([Optional] int NumRects, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[]? pRects);

		/// <summary>Copy a region from a source resource to a destination resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>Destination subresource index.</para>
		/// </param>
		/// <param name="DstX">
		/// <para>Type: <c>uint</c></para>
		/// <para>The x-coordinate of the upper left corner of the destination region.</para>
		/// </param>
		/// <param name="DstY">
		/// <para>Type: <c>uint</c></para>
		/// <para>The y-coordinate of the upper left corner of the destination region. For a 1D subresource, this must be zero.</para>
		/// </param>
		/// <param name="DstZ">
		/// <para>Type: <c>uint</c></para>
		/// <para>The z-coordinate of the upper left corner of the destination region. For a 1D or 2D subresource, this must be zero.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the source resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>Source subresource index.</para>
		/// </param>
		/// <param name="pSrcBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a 3D box (see D3D11_BOX) that defines the source subresource that can be copied. If <c>NULL</c>, the entire source
		/// subresource is copied. The box must fit within the source resource.
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, <c>CopySubresourceRegion</c> doesn't perform a copy operation.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source box must be within the size of the source resource. The destination offsets, (x, y, and z), allow the source box to
		/// be offset when writing into the destination resource; however, the dimensions of the source box and the offsets must be within
		/// the size of the resource. If you try and copy outside the destination resource or specify a source box that is larger than the
		/// source resource, the behavior of <c>CopySubresourceRegion</c> is undefined. If you created a device that supports the debug
		/// layer, the debug output reports an error on this invalid <c>CopySubresourceRegion</c> call. Invalid parameters to
		/// <c>CopySubresourceRegion</c> cause undefined behavior and might result in incorrect rendering, clipping, no copy, or even the
		/// removal of the rendering device.
		/// </para>
		/// <para>
		/// If the resources are buffers, all coordinates are in bytes; if the resources are textures, all coordinates are in texels.
		/// D3D11CalcSubresource is a helper function for calculating subresource indexes.
		/// </para>
		/// <para>
		/// <c>CopySubresourceRegion</c> performs the copy on the GPU (similar to a memcpy by the CPU). As a consequence, the source and
		/// destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different subresources (although they can be from the same resource).</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible DXGI formats (identical or from the same type group). For example, a DXGI_FORMAT_R32G32B32_FLOAT texture
		/// can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in the DXGI_FORMAT_R32G32B32_TYPELESS
		/// group. <c>CopySubresourceRegion</c> can copy between a few format types. For more info, see Format Conversion using Direct3D 10.1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>May not be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para>
		/// **CopySubresourceRegion** only supports copy; it doesn't support any stretch, color key, or blend. **CopySubresourceRegion** can
		///   reinterpret the resource data between a few format types. For more info, see [Format conversion using Direct3D 10.1](/windows/win32/direct3d10/d3d10-graphics-programming-guide-resources-block-compression#format-conversion-using-direct3d-101).
		/// </para>
		/// <para>If your app needs to copy an entire resource, we recommend to use ID3D11DeviceContext::CopyResource instead.</para>
		/// <para>
		/// <c>CopySubresourceRegion</c> is an asynchronous call, which may be added to the command-buffer queue, this attempts to remove
		/// pipeline stalls that may occur when copying data. For more information about pipeline stalls, see performance considerations.
		/// </para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> If you use ID3D11DeviceContext::UpdateSubresource or
		/// <c>CopySubresourceRegion</c> to copy from a staging resource to a default resource, you can corrupt the destination contents.
		/// This occurs if you pass a <c>NULL</c> source box and if the source resource has different dimensions from those of the
		/// destination resource or if you use destination offsets, (x, y, and z). In this situation, always pass a source box that is the
		/// full size of the source resource.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> You can't use <c>CopySubresourceRegion</c> to copy mipmapped
		/// volume textures.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature levels 9_x</c> Subresources created with the D3D11_BIND_DEPTH_STENCIL flag can only be
		/// used as a source for <c>CopySubresourceRegion</c>.
		/// </para>
		/// <para></para>
		/// <para>
		/// <c>Note</c>  If you use <c>CopySubresourceRegion</c> with a depth-stencil buffer or a multisampled resource, you must copy the
		/// whole subresource. In this situation, you must pass 0 to the <c>DstX</c>, <c>DstY</c>, and <c>DstZ</c> parameters and
		/// <c>NULL</c> to the <c>pSrcBox</c> parameter. In addition, source and destination resources, which are represented by the
		/// <c>pSrcResource</c> and <c>pDstResource</c> parameters, should have identical sample count values.
		/// </para>
		/// <para></para>
		/// <para>Example</para>
		/// <para>
		/// The following code snippet copies a box (located at (120,100),(200,220)) from a source texture into a region (10,20),(90,140) in
		/// a destination texture.
		/// </para>
		/// <para>Notice, that for a 2D texture, front and back are set to 0 and 1 respectively.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-copysubresourceregion void
		// CopySubresourceRegion( [in] ID3D11Resource *pDstResource, [in] uint DstSubresource, [in] uint DstX, [in] uint DstY, [in] uint
		// DstZ, [in] ID3D11Resource *pSrcResource, [in] uint SrcSubresource, [in, optional] const D3D11_BOX *pSrcBox );
		[PreserveSig]
		void CopySubresourceRegion([In] ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ,
			[In] ID3D11Resource pSrcResource, uint SrcSubresource, [In, Optional] StructPointer<D3D11_BOX> pSrcBox);

		/// <summary>Copy the entire contents of the source resource to the destination resource using the GPU.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the ID3D11Resource interface that represents the destination resource.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the ID3D11Resource interface that represents the source resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method is unusual in that it causes the GPU to perform the copy operation (similar to a memcpy by the CPU). As a result, it
		/// has a few restrictions designed for improving performance. For instance, the source and destination resources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Must be different resources.</description>
		/// </item>
		/// <item>
		/// <description>Must be the same type.</description>
		/// </item>
		/// <item>
		/// <description>Must have identical dimensions (including width, height, depth, and size as appropriate).</description>
		/// </item>
		/// <item>
		/// <description>
		/// Must have compatible DXGI formats, which means the formats must be identical or at least from the same type group. For example,
		/// a DXGI_FORMAT_R32G32B32_FLOAT texture can be copied to a DXGI_FORMAT_R32G32B32_UINT texture since both of these formats are in
		/// the DXGI_FORMAT_R32G32B32_TYPELESS group. CopyResource can copy between a few format types. For more info, see Format Conversion
		/// using Direct3D 10.1.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Can't be currently mapped.</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>CopyResource</c> only supports copy; it doesn't support any stretch, color key, or blend. CopyResource can reinterpret the
		/// resource data between a few format types. For more info, see Format Conversion using Direct3D 10.1.
		/// </para>
		/// <para>
		/// You can't use an Immutable resource as a destination. You can use a depth-stencil resource as either a source or a destination
		/// provided that the feature level is D3D_FEATURE_LEVEL_10_1 or greater. For feature levels 9_x, resources created with the
		/// D3D11_BIND_DEPTH_STENCIL flag can only be used as a source for CopyResource. Resources created with multisampling capability
		/// (see DXGI_SAMPLE_DESC) can be used as source and destination only if both source and destination have identical multisampled
		/// count and quality. If source and destination differ in multisampled count and quality or if one is multisampled and the other is
		/// not multisampled, the call to <c>ID3D11DeviceContext::CopyResource</c> fails. Use ID3D11DeviceContext::ResolveSubresource to
		/// resolve a multisampled resource to a resource that is not multisampled.
		/// </para>
		/// <para>
		/// The method is an asynchronous call, which may be added to the command-buffer queue. This attempts to remove pipeline stalls that
		/// may occur when copying data. For more info, see performance considerations.
		/// </para>
		/// <para>
		/// We recommend to use ID3D11DeviceContext::CopySubresourceRegion instead if you only need to copy a portion of the data in a resource.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-copyresource void CopyResource( [in]
		// ID3D11Resource *pDstResource, [in] ID3D11Resource *pSrcResource );
		[PreserveSig]
		void CopyResource([In] ID3D11Resource pDstResource, [In] ID3D11Resource pSrcResource);

		/// <summary>
		/// <para>See the Basic hologram sample.</para>
		/// <para>The CPU copies data from memory to a subresource created in non-mappable memory.</para>
		/// </summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to the destination resource (see ID3D11Resource).</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. See D3D11CalcSubresource for more details.</para>
		/// </param>
		/// <param name="pDstBox">
		/// <para>Type: <c>const D3D11_BOX*</c></para>
		/// <para>
		/// A pointer to a box that defines the portion of the destination subresource to copy the resource data into. Coordinates are in
		/// bytes for buffers and in texels for textures. If <c>NULL</c>, the data is written to the destination subresource with no offset.
		/// The dimensions of the source must fit the destination (see D3D11_BOX).
		/// </para>
		/// <para>
		/// An empty box results in a no-op. A box is empty if the top value is greater than or equal to the bottom value, or the left value
		/// is greater than or equal to the right value, or the front value is greater than or equal to the back value. When the box is
		/// empty, <c>UpdateSubresource</c> doesn't perform an update operation.
		/// </para>
		/// </param>
		/// <param name="pSrcData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A pointer to the source data in memory.</para>
		/// </param>
		/// <param name="SrcRowPitch">
		/// <para>Type: <c>uint</c></para>
		/// <para>The size of one row of the source data.</para>
		/// </param>
		/// <param name="SrcDepthPitch">
		/// <para>Type: <c>uint</c></para>
		/// <para>The size of one depth slice of source data.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// For a shader-constant buffer; set <c>pDstBox</c> to <c>NULL</c>. It is not possible to use this method to partially update a
		/// shader-constant buffer.
		/// </para>
		/// <para>A resource cannot be used as a destination if:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>the resource is created with immutable or dynamic usage.</description>
		/// </item>
		/// <item>
		/// <description>the resource is created as a depth-stencil resource.</description>
		/// </item>
		/// <item>
		/// <description>the resource is created with multisampling capability (see DXGI_SAMPLE_DESC).</description>
		/// </item>
		/// </list>
		/// <para>
		/// When <c>UpdateSubresource</c> returns, the application is free to change or even free the data pointed to by <c>pSrcData</c>
		/// because the method has already copied/snapped away the original contents.
		/// </para>
		/// <para>
		/// The performance of <c>UpdateSubresource</c> depends on whether or not there is contention for the destination resource. For
		/// example, contention for a vertex buffer resource occurs when the application executes a <c>Draw</c> call and later calls
		/// <c>UpdateSubresource</c> on the same vertex buffer before the <c>Draw</c> call is actually executed by the GPU.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// When there is contention for the resource, <c>UpdateSubresource</c> will perform 2 copies of the source data. First, the data is
		/// copied by the CPU to a temporary storage space accessible by the command buffer. This copy happens before the method returns. A
		/// second copy is then performed by the GPU to copy the source data into non-mappable memory. This second copy happens
		/// asynchronously because it is executed by GPU when the command buffer is flushed.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// When there is no resource contention, the behavior of <c>UpdateSubresource</c> is dependent on which is faster (from the CPU's
		/// perspective): copying the data to the command buffer and then having a second copy execute when the command buffer is flushed,
		/// or having the CPU copy the data to the final resource location. This is dependent on the architecture of the underlying system.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>   <c>Applies only to feature level 9_x hardware</c> If you use <c>UpdateSubresource</c> or
		/// ID3D11DeviceContext::CopySubresourceRegion to copy from a staging resource to a default resource, you can corrupt the
		/// destination contents. This occurs if you pass a <c>NULL</c> source box and if the source resource has different dimensions from
		/// those of the destination resource or if you use destination offsets, (x, y, and z). In this situation, always pass a source box
		/// that is the full size of the source resource.
		/// </para>
		/// <para></para>
		/// <para>
		/// To better understand the source row pitch and source depth pitch parameters, the following illustration shows a 3D volume texture.
		/// </para>
		/// <para>
		/// Each block in this visual represents an element of data, and the size of each element is dependent on the resource's format. For
		/// example, if the resource format is DXGI_FORMAT_R32G32B32A32_FLOAT, the size of each element would be 128 bits, or 16 bytes. This
		/// 3D volume texture has a width of two, a height of three, and a depth of four.
		/// </para>
		/// <para>To calculate the source row pitch and source depth pitch for a given resource, use the following formulas:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Source Row Pitch = [size of one element in bytes] * [number of elements in one row]</description>
		/// </item>
		/// <item>
		/// <description>Source Depth Pitch = [Source Row Pitch] * [number of rows (height)]</description>
		/// </item>
		/// </list>
		/// <para>In the case of this example 3D volume texture where the size of each element is 16 bytes, the formulas are as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Source Row Pitch = 16 * 2 = 32</description>
		/// </item>
		/// <item>
		/// <description>Source Depth Pitch = 16 * 2 * 3 = 96</description>
		/// </item>
		/// </list>
		/// <para>The following illustration shows the resource as it is laid out in memory.</para>
		/// <para>
		/// For example, the following code snippet shows how to specify a destination region in a 2D texture. Assume the destination
		/// texture is 512x512 and the operation will copy the data pointed to by <c>pData</c> to [(120,100)..(200,220)] in the destination
		/// texture. Also assume that <c>rowPitch</c> has been initialized with the proper value (as explained above). <c>front</c> and
		/// <c>back</c> are set to 0 and 1 respectively, because by having <c>front</c> equal to <c>back</c>, the box is technically empty.
		/// </para>
		/// <para>
		/// The 1D case is similar. The following snippet shows how to specify a destination region in a 1D texture. Use the same
		/// assumptions as above, except that the texture is 512 in length.
		/// </para>
		/// <para>
		/// For info about various resource types and how <c>UpdateSubresource</c> might work with each resource type, see Introduction to a
		/// Resource in Direct3D 11.
		/// </para>
		/// <para>Calling UpdateSubresource on a Deferred Context</para>
		/// <para>
		/// If your application calls <c>UpdateSubresource</c> on a deferred context with a destination box—to which <c>pDstBox</c>
		/// points—that has a non-(0,0,0) offset, and if the driver does not support command lists, <c>UpdateSubresource</c> inappropriately
		/// applies that destination-box offset to the <c>pSrcData</c> parameter. To work around this behavior, use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-updatesubresource void UpdateSubresource(
		// [in] ID3D11Resource *pDstResource, [in] uint DstSubresource, [in, optional] const D3D11_BOX *pDstBox, [in] const void *pSrcData,
		// [in] uint SrcRowPitch, [in] uint SrcDepthPitch );
		[PreserveSig]
		void UpdateSubresource([In] ID3D11Resource pDstResource, uint DstSubresource, [In, Optional] StructPointer<D3D11_BOX> pDstBox,
			[In] IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		/// <summary>Copies data from a buffer holding variable length data.</summary>
		/// <param name="pDstBuffer">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>
		/// Pointer to ID3D11Buffer. This can be any buffer resource that other copy commands, such as ID3D11DeviceContext::CopyResource or
		/// ID3D11DeviceContext::CopySubresourceRegion, are able to write to.
		/// </para>
		/// </param>
		/// <param name="DstAlignedByteOffset">
		/// <para>Type: <c>uint</c></para>
		/// <para>Offset from the start of <c>pDstBuffer</c> to write 32-bit uint structure (vertex) count from <c>pSrcView</c>.</para>
		/// </param>
		/// <param name="pSrcView">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>
		/// Pointer to an ID3D11UnorderedAccessView of a Structured Buffer resource created with either D3D11_BUFFER_UAV_FLAG_APPEND or
		/// <c>D3D11_BUFFER_UAV_FLAG_COUNTER</c> specified when the UAV was created. These types of resources have hidden counters tracking
		/// "how many" records have been written.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-copystructurecount void
		// CopyStructureCount( [in] ID3D11Buffer *pDstBuffer, [in] uint DstAlignedByteOffset, [in] ID3D11UnorderedAccessView *pSrcView );
		[PreserveSig]
		void CopyStructureCount([In] ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, [In] ID3D11UnorderedAccessView pSrcView);

		/// <summary>Set all the elements in a render target to one value.</summary>
		/// <param name="pRenderTargetView">
		/// <para>Type: <c>ID3D11RenderTargetView*</c></para>
		/// <para>Pointer to the render target.</para>
		/// </param>
		/// <param name="ColorRGBA">
		/// <para>Type: <c>const FLOAT[4]</c></para>
		/// <para>A 4-component array that represents the color to fill the render target with.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Applications that wish to clear a render target to a specific integer value bit pattern should render a screen-aligned quad
		/// instead of using this method. The reason for this is because this method accepts as input a floating point value, which may not
		/// have the same bit pattern as the original integer.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>
		/// Differences between Direct3D 9 and Direct3D 11/10: Unlike Direct3D 9, the full extent of the resource view is always cleared.
		/// Viewport and scissor settings are not applied.
		/// </description>
		/// </listheader>
		/// </list>
		/// <para></para>
		/// <para>
		/// When using D3D_FEATURE_LEVEL_9_x, ClearRenderTargetView only clears the first array slice in the render target view. This can
		/// impact (for example) cube map rendering scenarios. Applications should create a render target view for each face or array slice,
		/// then clear each view individually.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearrendertargetview void
		// ClearRenderTargetView( [in] ID3D11RenderTargetView *pRenderTargetView, [in] const FLOAT [4] ColorRGBA );
		[PreserveSig]
		void ClearRenderTargetView([In] ID3D11RenderTargetView pRenderTargetView, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[] ColorRGBA);

		/// <summary>Clears an unordered access resource with bit-precise values.</summary>
		/// <param name="pUnorderedAccessView">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>The ID3D11UnorderedAccessView to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: <c>const uint[4]</c></para>
		/// <para>Values to copy to corresponding channels, see remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This API copies the lower n bits from each array element i to the corresponding channel, where n is the number of bits in the
		/// ith channel of the resource format (for example, R8G8B8_FLOAT has 8 bits for the first 3 channels). This works on any UAV with
		/// no format conversion. For a raw or structured buffer view, only the first array element value is used.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearunorderedaccessviewuint void
		// ClearUnorderedAccessViewUint( [in] ID3D11UnorderedAccessView *pUnorderedAccessView, [in] const uint [4] Values );
		[PreserveSig]
		void ClearUnorderedAccessViewUint([In] ID3D11UnorderedAccessView pUnorderedAccessView, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] uint[] Values);

		/// <summary>Clears an unordered access resource with a float value.</summary>
		/// <param name="pUnorderedAccessView">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>The ID3D11UnorderedAccessView to clear.</para>
		/// </param>
		/// <param name="Values">
		/// <para>Type: <c>const FLOAT[4]</c></para>
		/// <para>Values to copy to corresponding channels, see remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This API works on FLOAT, UNORM, and SNORM unordered access views (UAVs), with format conversion from FLOAT to *NORM where
		/// appropriate. On other UAVs, the operation is invalid and the call will not reach the driver.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearunorderedaccessviewfloat void
		// ClearUnorderedAccessViewFloat( [in] ID3D11UnorderedAccessView *pUnorderedAccessView, [in] const FLOAT [4] Values );
		[PreserveSig]
		void ClearUnorderedAccessViewFloat([In] ID3D11UnorderedAccessView pUnorderedAccessView, [In, Out, MarshalAs(UnmanagedType.LPArray)] float[] Values);

		/// <summary>Clears the depth-stencil resource.</summary>
		/// <param name="pDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView*</c></para>
		/// <para>Pointer to the depth stencil to be cleared.</para>
		/// </param>
		/// <param name="ClearFlags">
		/// <para>Type: <c>uint</c></para>
		/// <para>Identify the type of data to clear (see D3D11_CLEAR_FLAG).</para>
		/// </param>
		/// <param name="Depth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Clear the depth buffer with this value. This value will be clamped between 0 and 1.</para>
		/// </param>
		/// <param name="Stencil">
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Clear the stencil buffer with this value.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <list type="table">
		/// <listheader>
		/// <description>
		/// Differences between Direct3D 9 and Direct3D 11/10: Unlike Direct3D 9, the full extent of the resource view is always cleared.
		/// Viewport and scissor settings are not applied.
		/// </description>
		/// </listheader>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cleardepthstencilview void
		// ClearDepthStencilView( [in] ID3D11DepthStencilView *pDepthStencilView, [in] uint ClearFlags, [in] FLOAT Depth, [in] UINT8 Stencil );
		[PreserveSig]
		void ClearDepthStencilView([In] ID3D11DepthStencilView pDepthStencilView, D3D11_CLEAR_FLAG ClearFlags, float Depth, byte Stencil);

		/// <summary>Generates mipmaps for the given shader resource.</summary>
		/// <param name="pShaderResourceView">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>A pointer to an ID3D11ShaderResourceView interface that represents the shader resource.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// You can call <c>GenerateMips</c> on any shader-resource view to generate the lower mipmap levels for the shader resource.
		/// <c>GenerateMips</c> uses the largest mipmap level of the view to recursively generate the lower levels of the mip and stops with
		/// the smallest level that is specified by the view. If the base resource wasn't created with D3D11_BIND_RENDER_TARGET,
		/// D3D11_BIND_SHADER_RESOURCE, and D3D11_RESOURCE_MISC_GENERATE_MIPS, the call to <c>GenerateMips</c> has no effect.
		/// </para>
		/// <para>Feature levels 9.1, 9.2, and 9.3 can't support automatic generation of mipmaps for 3D (volume) textures.</para>
		/// <para>Video adapters that support feature level 9.1 and higher support generating mipmaps if you use any of these formats:</para>
		/// <para>
		/// Video adapters that support feature level 9.2 and higher support generating mipmaps if you use any of these formats in addition
		/// to any of the formats for feature level 9.1:
		/// </para>
		/// <para>
		/// Video adapters that support feature level 9.3 and higher support generating mipmaps if you use any of these formats in addition
		/// to any of the formats for feature levels 9.1 and 9.2:
		/// </para>
		/// <para>
		/// Video adapters that support feature level 10 and higher support generating mipmaps if you use any of these formats in addition
		/// to any of the formats for feature levels 9.1, 9.2, and 9.3:
		/// </para>
		/// <para>For all other unsupported formats, <c>GenerateMips</c> will silently fail.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-generatemips void GenerateMips( [in]
		// ID3D11ShaderResourceView *pShaderResourceView );
		[PreserveSig]
		void GenerateMips([In] ID3D11ShaderResourceView pShaderResourceView);

		/// <summary>Sets the minimum level-of-detail (LOD) for a resource.</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to an ID3D11Resource that represents the resource.</para>
		/// </param>
		/// <param name="MinLOD">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The level-of-detail, which ranges between 0 and the maximum number of mipmap levels of the resource. For example, the maximum
		/// number of mipmap levels of a 1D texture is specified in the <c>MipLevels</c> member of the D3D11_TEXTURE1D_DESC structure.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use a resource with <c>SetResourceMinLOD</c>, you must set the D3D11_RESOURCE_MISC_RESOURCE_CLAMP flag when you create that resource.
		/// </para>
		/// <para>
		/// For Direct3D 10 and Direct3D 10.1, when sampling from a texture resource in a shader, the sampler can define a minimum LOD clamp
		/// to force sampling from less detailed mip levels. For Direct3D 11, this functionality is extended from the sampler to the entire
		/// resource. Therefore, the application can specify the highest-resolution mip level of a resource that is available for access.
		/// This restricts the set of mip levels that are required to be resident in GPU memory, thereby saving memory.
		/// </para>
		/// <para>The set of mip levels resident per-resource in GPU memory can be specified by the user.</para>
		/// <para>Minimum LOD affects all of the resident mip levels. Therefore, only the resident mip levels can be updated and read from.</para>
		/// <para>All methods that access texture resources must adhere to minimum LOD clamps.</para>
		/// <para>Empty-set accesses are handled as out-of-bounds cases.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-setresourceminlod void SetResourceMinLOD(
		// [in] ID3D11Resource *pResource, FLOAT MinLOD );
		[PreserveSig]
		void SetResourceMinLOD([In] ID3D11Resource pResource, float MinLOD);

		/// <summary>Gets the minimum level-of-detail (LOD).</summary>
		/// <param name="pResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>A pointer to an ID3D11Resource which represents the resource.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the minimum LOD.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getresourceminlod FLOAT GetResourceMinLOD(
		// [in] ID3D11Resource *pResource );
		[PreserveSig]
		float GetResourceMinLOD([In] ID3D11Resource pResource);

		/// <summary>Copy a multisampled resource into a non-multisampled resource.</summary>
		/// <param name="pDstResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Destination resource. Must be a created with the D3D11_USAGE_DEFAULT flag and be single-sampled. See ID3D11Resource.</para>
		/// </param>
		/// <param name="DstSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>A zero-based index, that identifies the destination subresource. Use D3D11CalcSubresource to calculate the index.</para>
		/// </param>
		/// <param name="pSrcResource">
		/// <para>Type: <c>ID3D11Resource*</c></para>
		/// <para>Source resource. Must be multisampled.</para>
		/// </param>
		/// <param name="SrcSubresource">
		/// <para>Type: <c>uint</c></para>
		/// <para>The source subresource of the source resource.</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT</c></para>
		/// <para>A DXGI_FORMAT that indicates how the multisampled resource will be resolved to a single-sampled resource. See remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This API is most useful when re-using the resulting rendertarget of one render pass as an input to a second render pass.</para>
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
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-resolvesubresource void
		// ResolveSubresource( [in] ID3D11Resource *pDstResource, [in] uint DstSubresource, [in] ID3D11Resource *pSrcResource, [in] uint
		// SrcSubresource, [in] DXGI_FORMAT Format );
		[PreserveSig]
		void ResolveSubresource([In] ID3D11Resource pDstResource, uint DstSubresource, [In] ID3D11Resource pSrcResource,
			uint SrcSubresource, DXGI_FORMAT Format);

		/// <summary>Queues commands from a command list onto a device.</summary>
		/// <param name="pCommandList">
		/// <para>Type: <c>ID3D11CommandList*</c></para>
		/// <para>A pointer to an ID3D11CommandList interface that encapsulates a command list.</para>
		/// </param>
		/// <param name="RestoreContextState">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that determines whether the target context state is saved prior to and restored after the execution of a command
		/// list. Use <c>TRUE</c> to indicate that the runtime needs to save and restore the state. Use <c>FALSE</c> to indicate that no
		/// state shall be saved or restored, which causes the target context to return to its default state after the command list
		/// executes. Applications should typically use <c>FALSE</c> unless they will restore the state to be nearly equivalent to the state
		/// that the runtime would restore if <c>TRUE</c> were passed. When applications use <c>FALSE</c>, they can avoid unnecessary and
		/// inefficient state transitions.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Use this method to play back a command list that was recorded by a deferred context on any thread.</para>
		/// <para>
		/// A call to <c>ExecuteCommandList</c> of a command list from a deferred context onto the immediate context is required for the
		/// recorded commands to be executed on the graphics processing unit (GPU). A call to <c>ExecuteCommandList</c> of a command list
		/// from a deferred context onto another deferred context can be used to merge recorded lists. But to run the commands from the
		/// merged deferred command list on the GPU, you need to execute them on the immediate context.
		/// </para>
		/// <para>
		/// This method performs some runtime validation related to queries. Queries that are begun in a device context cannot be
		/// manipulated indirectly by executing a command list (that is, Begin or End was invoked against the same query by the deferred
		/// context which generated the command list). If such a condition occurs, the ExecuteCommandList method does not execute the
		/// command list. However, the state of the device context is still maintained, as would be expected
		/// (ID3D11DeviceContext::ClearState is performed, unless the application indicates to preserve the device context state).
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-executecommandlist void
		// ExecuteCommandList( [in] ID3D11CommandList *pCommandList, BOOL RestoreContextState );
		[PreserveSig]
		void ExecuteCommandList([In] ID3D11CommandList pCommandList, bool RestoreContextState);

		/// <summary>Bind an array of shader resources to the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetshaderresources void
		// HSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		void HSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set a hull shader to the device.</summary>
		/// <param name="pHullShader">
		/// <para>Type: <c>ID3D11HullShader*</c></para>
		/// <para>Pointer to a hull shader (see ID3D11HullShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetshader void HSSetShader( [in,
		// optional] ID3D11HullShader *pHullShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		void HSSetShader([In, Optional] ID3D11HullShader? pHullShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetsamplers void HSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		void HSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Set the constant buffers used by the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the HSSetConstantBuffers1 method instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hssetconstantbuffers void
		// HSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		void HSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an array of shader resources to the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetshaderresources void
		// DSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		void DSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Set a domain shader to the device.</summary>
		/// <param name="pDomainShader">
		/// <para>Type: <c>ID3D11DomainShader*</c></para>
		/// <para>Pointer to a domain shader (see ID3D11DomainShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetshader void DSSetShader( [in,
		// optional] ID3D11DomainShader *pDomainShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint NumClassInstances );
		[PreserveSig]
		void DSSetShader([In, Optional] ID3D11DomainShader? pDomainShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetsamplers void DSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		void DSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Sets the constant buffers used by the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 432-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 432-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the DSSetConstantBuffers1 method instead.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dssetconstantbuffers void
		// DSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		void DSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Bind an array of shader resources to the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting shader resources to (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of shader resources to set. Up to a maximum of 128 slots are available for shader resources(ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView*</c></para>
		/// <para>Array of shader resource view interfaces to set to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If an overlapping resource view is already bound to an output slot, such as a render target, then the method will fill the
		/// destination shader resource slot with <c>NULL</c>.
		/// </para>
		/// <para>For information about creating shader-resource views, see ID3D11Device::CreateShaderResourceView.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetshaderresources void
		// CSSetShaderResources( [in] uint StartSlot, [in] uint NumViews, [in, optional] ID3D11ShaderResourceView * const
		// *ppShaderResourceViews );
		[PreserveSig]
		void CSSetShaderResources(uint StartSlot, int NumViews, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Sets an array of views for an unordered resource.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index of the first element in the zero-based array to begin setting (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - 1).
		/// D3D11_1_UAV_SLOT_COUNT is defined as 64.
		/// </para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of views to set (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>A pointer to an array of ID3D11UnorderedAccessView pointers to be set by the method.</para>
		/// </param>
		/// <param name="pUAVInitialCounts">
		/// <para>Type: <c>const uint*</c></para>
		/// <para>
		/// An array of append and consume buffer offsets. A value of -1 indicates to keep the current offset. Any other values set the
		/// hidden counter for that appendable and consumable UAV. <c>pUAVInitialCounts</c> is only relevant for UAVs that were created with
		/// either D3D11_BUFFER_UAV_FLAG_APPEND or <c>D3D11_BUFFER_UAV_FLAG_COUNTER</c> specified when the UAV was created; otherwise, the
		/// argument is ignored.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetunorderedaccessviews void
		// CSSetUnorderedAccessViews( [in] uint StartSlot, [in] uint NumUAVs, [in, optional] ID3D11UnorderedAccessView * const
		// *ppUnorderedAccessViews, [in, optional] const uint *pUAVInitialCounts );
		[PreserveSig]
		void CSSetUnorderedAccessViews(uint StartSlot, int NumUAVs, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pUAVInitialCounts);

		/// <summary>Set a compute shader to the device.</summary>
		/// <param name="pComputeShader">
		/// <para>Type: <c>ID3D11ComputeShader*</c></para>
		/// <para>Pointer to a compute shader (see ID3D11ComputeShader). Passing in <c>NULL</c> disables the shader for this pipeline stage.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance*</c></para>
		/// <para>
		/// A pointer to an array of class-instance interfaces (see ID3D11ClassInstance). Each interface used by a shader must have a
		/// corresponding class instance or the shader will get disabled. Set ppClassInstances to <c>NULL</c> if the shader does not use any interfaces.
		/// </para>
		/// </param>
		/// <param name="NumClassInstances">
		/// <para>Type: <c>uint</c></para>
		/// <para>The number of class-instance interfaces in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>The maximum number of instances a shader can have is 256.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetshader void CSSetShader( [in,
		// optional] ID3D11ComputeShader *pComputeShader, [in, optional] ID3D11ClassInstance * const *ppClassInstances, uint
		// NumClassInstances );
		[PreserveSig]
		void CSSetShader(ID3D11ComputeShader? pComputeShader, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, int NumClassInstances);

		/// <summary>Set an array of sampler states to the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin setting samplers to (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers in the array. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState*</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState). See Remarks.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Any sampler may be set to <c>NULL</c>; this invokes the default state, which is defined to be the following.</para>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetsamplers void CSSetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [in, optional] ID3D11SamplerState * const *ppSamplers );
		[PreserveSig]
		void CSSetSamplers(uint StartSlot, int NumSamplers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Sets the constant buffers used by the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the zero-based array to begin setting constant buffers to (ranges from 0 to
		/// <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to set (ranges from 0 to <c>D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT</c> - <c>StartSlot</c>).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer*</c></para>
		/// <para>Array of constant buffers (see ID3D11Buffer) being given to the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The method will hold a reference to the interfaces passed in. This differs from the device state behavior in Direct3D 10.
		/// </para>
		/// <para>
		/// The Direct3D 11.1 runtime, which is available starting with Windows 8, can bind a larger number of ID3D11Buffer resources to the
		/// shader than the maximum constant buffer size that is supported by shaders (4096 constants – 4*32-bit components each). When you
		/// bind such a large buffer, the shader can access only the first 4096 4*32-bit component constants in the buffer, as if 4096
		/// constants is the full size of the buffer.
		/// </para>
		/// <para>
		/// If the application wants the shader to access other parts of the buffer, it must call the CSSetConstantBuffers1 method instead.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-cssetconstantbuffers void
		// CSSetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [in, optional] ID3D11Buffer * const *ppConstantBuffers );
		[PreserveSig]
		void CSSetConstantBuffers(uint StartSlot, int NumBuffers, [In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the constant buffers used by the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetconstantbuffers void
		// VSGetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the pixel shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetshaderresources void
		// PSGetShaderResources( [in] uint StartSlot, [in] uint NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		void PSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get the pixel shader currently set on the device.</summary>
		/// <param name="ppPixelShader">
		/// <para>Type: <c>ID3D11PixelShader**</c></para>
		/// <para>Address of a pointer to a pixel shader (see ID3D11PixelShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>uint*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed, to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetshader void PSGetShader( [out]
		// ID3D11PixelShader **ppPixelShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] uint
		// *pNumClassInstances );
		[PreserveSig]
		void PSGetShader(out ID3D11PixelShader? ppPixelShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances,
			ref uint pNumClassInstances);

		/// <summary>Get an array of sampler states from the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Array of sampler-state interface pointers (see ID3D11SamplerState) to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetsamplers void PSGetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		void PSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the vertex shader currently set on the device.</summary>
		/// <param name="ppVertexShader">
		/// <para>Type: <c>ID3D11VertexShader**</c></para>
		/// <para>Address of a pointer to a vertex shader (see ID3D11VertexShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>uint*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetshader void VSGetShader( [out]
		// ID3D11VertexShader **ppVertexShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] uint
		// *pNumClassInstances );
		[PreserveSig]
		void VSGetShader(out ID3D11VertexShader? ppVertexShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances, ref uint pNumClassInstances);

		/// <summary>Get the constant buffers used by the pixel shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-psgetconstantbuffers void
		// PSGetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get a pointer to the input-layout object that is bound to the input-assembler stage.</summary>
		/// <param name="ppInputLayout">
		/// <para>Type: <c>ID3D11InputLayout**</c></para>
		/// <para>
		/// A pointer to the input-layout object (see ID3D11InputLayout), which describes the input buffers that will be read by the IA stage.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>For information about creating an input-layout object, see Creating the Input-Layout Object.</para>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetinputlayout void IAGetInputLayout(
		// [out] ID3D11InputLayout **ppInputLayout );
		[PreserveSig]
		void IAGetInputLayout(out ID3D11InputLayout? ppInputLayout);

		/// <summary>Get the vertex buffers bound to the input-assembler stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The input slot of the first vertex buffer to get. The first vertex buffer is explicitly bound to the start slot; this causes
		/// each additional vertex buffer in the array to be implicitly bound to each subsequent input slot. The maximum of 16 or 32 input
		/// slots (ranges from 0 to D3D11_IA_VERTEX_INPUT_RESOURCE_SLOT_COUNT - 1) are available; the maximum number of input slots depends
		/// on the feature level.
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of vertex buffers to get starting at the offset. The number of buffers (plus the starting slot) cannot exceed the
		/// total number of IA-stage input slots.
		/// </para>
		/// </param>
		/// <param name="ppVertexBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>A pointer to an array of vertex buffers returned by the method (see ID3D11Buffer).</para>
		/// </param>
		/// <param name="pStrides">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// Pointer to an array of stride values returned by the method; one stride value for each buffer in the vertex-buffer array. Each
		/// stride value is the size (in bytes) of the elements that are to be used from that vertex buffer.
		/// </para>
		/// </param>
		/// <param name="pOffsets">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// Pointer to an array of offset values returned by the method; one offset value for each buffer in the vertex-buffer array. Each
		/// offset is the number of bytes between the first element of a vertex buffer and the first element that will be used.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetvertexbuffers void
		// IAGetVertexBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppVertexBuffers, [out, optional]
		// uint *pStrides, [out, optional] uint *pOffsets );
		[PreserveSig]
		void IAGetVertexBuffers(uint StartSlot, int NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppVertexBuffers,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pStrides, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[]? pOffsets);

		/// <summary>Get a pointer to the index buffer that is bound to the input-assembler stage.</summary>
		/// <param name="pIndexBuffer">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>A pointer to an index buffer returned by the method (see ID3D11Buffer).</para>
		/// </param>
		/// <param name="Format">
		/// <para>Type: <c>DXGI_FORMAT*</c></para>
		/// <para>
		/// Specifies format of the data in the index buffer (see DXGI_FORMAT). These formats provide the size and type of the data in the
		/// buffer. The only formats allowed for index buffer data are 16-bit (DXGI_FORMAT_R16_UINT) and 32-bit (DXGI_FORMAT_R32_UINT) integers.
		/// </para>
		/// </param>
		/// <param name="Offset">
		/// <para>Type: <c>uint*</c></para>
		/// <para>Offset (in bytes) from the start of the index buffer, to the first index to use.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetindexbuffer void IAGetIndexBuffer(
		// [out, optional] ID3D11Buffer **pIndexBuffer, [out, optional] DXGI_FORMAT *Format, [out, optional] uint *Offset );
		[PreserveSig]
		void IAGetIndexBuffer(out ID3D11Buffer? pIndexBuffer, out DXGI_FORMAT Format, out uint Offset);

		/// <summary>Get the constant buffers used by the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetconstantbuffers void
		// GSGetConstantBuffers( [in] uint StartSlot, [in] uint NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the geometry shader currently set on the device.</summary>
		/// <param name="ppGeometryShader">
		/// <para>Type: <c>ID3D11GeometryShader**</c></para>
		/// <para>Address of a pointer to a geometry shader (see ID3D11GeometryShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>uint*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetshader void GSGetShader( [out]
		// ID3D11GeometryShader **ppGeometryShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] uint
		// *pNumClassInstances );
		[PreserveSig]
		void GSGetShader(out ID3D11GeometryShader? ppGeometryShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ClassInstance[]? ppClassInstances,
			ref uint pNumClassInstances);

		/// <summary>Get information about the primitive type, and data order that describes input data for the input assembler stage.</summary>
		/// <param name="pTopology">
		/// <para>Type: <c>D3D11_PRIMITIVE_TOPOLOGY*</c></para>
		/// <para>A pointer to the type of primitive, and ordering of the primitive data (see D3D11_PRIMITIVE_TOPOLOGY).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-iagetprimitivetopology void
		// IAGetPrimitiveTopology( [out] D3D11_PRIMITIVE_TOPOLOGY *pTopology );
		[PreserveSig]
		void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);

		/// <summary>Get the vertex shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetshaderresources void
		// VSGetShaderResources( [in] uint StartSlot, [in] uint NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		void VSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get an array of sampler states from the vertex shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Array of sampler-state interface pointers (see ID3D11SamplerState) to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-vsgetsamplers void VSGetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		void VSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the rendering predicate state.</summary>
		/// <param name="ppPredicate">
		/// <para>Type: <c>ID3D11Predicate**</c></para>
		/// <para>Address of a pointer to a predicate (see ID3D11Predicate). Value stored here will be <c>NULL</c> upon device creation.</para>
		/// </param>
		/// <param name="pPredicateValue">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>Address of a boolean to fill with the predicate comparison value. <c>FALSE</c> upon device creation.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getpredication void GetPredication( [out,
		// optional] ID3D11Predicate **ppPredicate, [out, optional] BOOL *pPredicateValue );
		[PreserveSig]
		void GetPredication(out ID3D11Predicate? ppPredicate, [MarshalAs(UnmanagedType.Bool)] out bool pPredicateValue);

		/// <summary>Get the geometry shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetshaderresources void
		// GSGetShaderResources( [in] uint StartSlot, [in] uint NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		void GSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get an array of sampler state interfaces from the geometry shader pipeline stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>uint</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gsgetsamplers void GSGetSamplers( [in]
		// uint StartSlot, [in] uint NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		void GSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get pointers to the resources bound to the output-merger stage.</summary>
		/// <param name="NumViews">
		/// <para>Type: <c>uint</c></para>
		/// <para>Number of render targets to retrieve.</para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView**</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetViews which represent render target views. Specify <c>NULL</c> for this parameter when
		/// retrieval of a render target is not needed.
		/// </para>
		/// </param>
		/// <param name="ppDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView**</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView, which represents a depth-stencil view. Specify <c>NULL</c> for this parameter when
		/// retrieval of the depth-stencil view is not needed.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetrendertargets void
		// OMGetRenderTargets( [in] uint NumViews, [out, optional] ID3D11RenderTargetView **ppRenderTargetViews, [out, optional]
		// ID3D11DepthStencilView **ppDepthStencilView );
		[PreserveSig]
		void OMGetRenderTargets(uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			out ID3D11DepthStencilView? ppDepthStencilView);

		/// <summary>Get pointers to the resources bound to the output-merger stage.</summary>
		/// <param name="NumRTVs">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of render-target views to retrieve.</para>
		/// </param>
		/// <param name="ppRenderTargetViews">
		/// <para>Type: <c>ID3D11RenderTargetView**</c></para>
		/// <para>
		/// Pointer to an array of ID3D11RenderTargetViews, which represent render-target views. Specify <c>NULL</c> for this parameter when
		/// retrieval of render-target views is not required.
		/// </para>
		/// </param>
		/// <param name="ppDepthStencilView">
		/// <para>Type: <c>ID3D11DepthStencilView**</c></para>
		/// <para>
		/// Pointer to a ID3D11DepthStencilView, which represents a depth-stencil view. Specify <c>NULL</c> for this parameter when
		/// retrieval of the depth-stencil view is not required.
		/// </para>
		/// </param>
		/// <param name="UAVStartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin retrieving unordered-access views (ranges from 0 to D3D11_PS_CS_UAV_REGISTER_COUNT - 1).
		/// For pixel shaders <c>UAVStartSlot</c> should be equal to the number of render-target views that are bound.
		/// </para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of unordered-access views to return in <c>ppUnorderedAccessViews</c>. This number ranges from 0 to
		/// D3D11_PS_CS_UAV_REGISTER_COUNT - <c>UAVStartSlot</c>.
		/// </para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>
		/// Pointer to an array of ID3D11UnorderedAccessViews, which represent unordered-access views that are retrieved. Specify
		/// <c>NULL</c> for this parameter when retrieval of unordered-access views is not required.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetrendertargetsandunorderedaccessviews
		// void OMGetRenderTargetsAndUnorderedAccessViews( [in] UINT NumRTVs, [out, optional] ID3D11RenderTargetView **ppRenderTargetViews,
		// [out, optional] ID3D11DepthStencilView **ppDepthStencilView, [in] UINT UAVStartSlot, [in] UINT NumUAVs, [out, optional]
		// ID3D11UnorderedAccessView **ppUnorderedAccessViews );
		[PreserveSig]
		void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11RenderTargetView[]? ppRenderTargetViews,
			out ID3D11DepthStencilView? ppDepthStencilView, uint UAVStartSlot, uint NumUAVs,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 4)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews);

		/// <summary>Get the blend state of the output-merger stage.</summary>
		/// <param name="ppBlendState">
		/// <para>Type: <c>ID3D11BlendState**</c></para>
		/// <para>Address of a pointer to a blend-state interface (see ID3D11BlendState).</para>
		/// </param>
		/// <param name="BlendFactor">
		/// <para>Type: <c>FLOAT[4]</c></para>
		/// <para>Array of blend factors, one for each RGBA component.</para>
		/// </param>
		/// <param name="pSampleMask">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer to a sample mask.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The reference count of the returned interface will be incremented by one when the blend state is retrieved. Applications must
		/// release returned pointer(s) when they are no longer needed, or else there will be a memory leak.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetblendstate void OMGetBlendState(
		// [out, optional] ID3D11BlendState **ppBlendState, [out, optional] FLOAT [4] BlendFactor, [out, optional] UINT *pSampleMask );
		[PreserveSig]
		void OMGetBlendState(out ID3D11BlendState? ppBlendState, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeConst = 4)] float[]? BlendFactor,
			out uint pSampleMask);

		/// <summary>Gets the depth-stencil state of the output-merger stage.</summary>
		/// <param name="ppDepthStencilState">
		/// <para>Type: <c>ID3D11DepthStencilState**</c></para>
		/// <para>
		/// Address of a pointer to a depth-stencil state interface (see ID3D11DepthStencilState) to be filled with information from the device.
		/// </para>
		/// </param>
		/// <param name="pStencilRef">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>Pointer to the stencil reference value used in the depth-stencil test.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-omgetdepthstencilstate void
		// OMGetDepthStencilState( [out, optional] ID3D11DepthStencilState **ppDepthStencilState, [out, optional] UINT *pStencilRef );
		[PreserveSig]
		void OMGetDepthStencilState(out ID3D11DepthStencilState? ppDepthStencilState, out uint pStencilRef);

		/// <summary>Get the target output buffers for the stream-output stage of the pipeline.</summary>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to get.</para>
		/// </param>
		/// <param name="ppSOTargets">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>An array of output buffers (see ID3D11Buffer) to be retrieved from the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A maximum of four output buffers can be retrieved.</para>
		/// <para>
		/// The offsets to the output buffers pointed to in the returned <c>ppSOTargets</c> array may be assumed to be -1 (append), as
		/// defined for use in ID3D11DeviceContext::SOSetTargets.
		/// </para>
		/// <para>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-sogettargets void SOGetTargets( [in] UINT
		// NumBuffers, [out, optional] ID3D11Buffer **ppSOTargets );
		[PreserveSig]
		void SOGetTargets(uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11Buffer[]? ppSOTargets);

		/// <summary>Get the rasterizer state from the rasterizer stage of the pipeline.</summary>
		/// <param name="ppRasterizerState">
		/// <para>Type: <c>ID3D11RasterizerState**</c></para>
		/// <para>Address of a pointer to a rasterizer-state interface (see ID3D11RasterizerState) to fill with information from the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rsgetstate void RSGetState( [out]
		// ID3D11RasterizerState **ppRasterizerState );
		[PreserveSig]
		void RSGetState(out ID3D11RasterizerState? ppRasterizerState);

		/// <summary>Gets the array of viewports bound to the rasterizer stage.</summary>
		/// <param name="pNumViewports">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// A pointer to a variable that, on input, specifies the number of viewports (ranges from 0 to
		/// <c>D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE</c>) in the <c>pViewports</c> array; on output, the variable
		/// contains the actual number of viewports that are bound to the rasterizer stage. If <c>pViewports</c> is <c>NULL</c>,
		/// <c>RSGetViewports</c> fills the variable with the number of viewports currently bound.
		/// </para>
		/// <para>
		/// <c>Note</c>  In some versions of the Windows SDK, a debug device will raise an exception if the input value in the variable to
		/// which <c>pNumViewports</c> points is greater than <c>D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE</c> even if
		/// <c>pViewports</c> is <c>NULL</c>. The regular runtime ignores the value in the variable to which <c>pNumViewports</c> points
		/// when <c>pViewports</c> is <c>NULL</c>. This behavior of a debug device might be corrected in a future release of the Windows SDK.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="pViewports">
		/// <para>Type: <c>D3D11_VIEWPORT*</c></para>
		/// <para>
		/// An array of D3D11_VIEWPORT structures for the viewports that are bound to the rasterizer stage. If the number of viewports (in
		/// the variable to which <c>pNumViewports</c> points) is greater than the actual number of viewports currently bound, unused
		/// elements of the array contain 0. For info about how the viewport size depends on the device feature level, which has changed
		/// between Direct3D 11 and Direct3D 10, see <c>D3D11_VIEWPORT</c>.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rsgetviewports void RSGetViewports( [in,
		// out] UINT *pNumViewports, [out, optional] D3D11_VIEWPORT *pViewports );
		[PreserveSig]
		void RSGetViewports(ref int pNumViewports, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[]? pViewports);

		/// <summary>Get the array of scissor rectangles bound to the rasterizer stage.</summary>
		/// <param name="pNumRects">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>
		/// The number of scissor rectangles (ranges between 0 and D3D11_VIEWPORT_AND_SCISSORRECT_OBJECT_COUNT_PER_PIPELINE) bound; set
		/// <c>pRects</c> to <c>NULL</c> to use <c>pNumRects</c> to see how many rectangles would be returned.
		/// </para>
		/// </param>
		/// <param name="pRects">
		/// <para>Type: <c>D3D11_RECT*</c></para>
		/// <para>
		/// An array of scissor rectangles (see D3D11_RECT). If NumRects is greater than the number of scissor rects currently bound, then
		/// unused members of the array will contain 0.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-rsgetscissorrects void RSGetScissorRects(
		// [in, out] UINT *pNumRects, [out, optional] D3D11_RECT *pRects );
		[PreserveSig]
		void RSGetScissorRects(ref int pNumRects, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[]? pRects);

		/// <summary>Get the hull-shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetshaderresources void
		// HSGetShaderResources( [in] UINT StartSlot, [in] UINT NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		void HSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get the hull shader currently set on the device.</summary>
		/// <param name="ppHullShader">
		/// <para>Type: <c>ID3D11HullShader**</c></para>
		/// <para>Address of a pointer to a hull shader (see ID3D11HullShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetshader void HSGetShader( [out]
		// ID3D11HullShader **ppHullShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] UINT
		// *pNumClassInstances );
		[PreserveSig]
		void HSGetShader(out ID3D11HullShader? ppHullShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] ID3D11ClassInstance[]? ppClassInstances,
			ref uint pNumClassInstances);

		/// <summary>Get an array of sampler state interfaces from the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetsamplers void HSGetSamplers( [in]
		// UINT StartSlot, [in] UINT NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		void HSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the constant buffers used by the hull-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-hsgetconstantbuffers void
		// HSGetConstantBuffers( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the domain-shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetshaderresources void
		// DSGetShaderResources( [in] UINT StartSlot, [in] UINT NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		void DSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Get the domain shader currently set on the device.</summary>
		/// <param name="ppDomainShader">
		/// <para>Type: <c>ID3D11DomainShader**</c></para>
		/// <para>Address of a pointer to a domain shader (see ID3D11DomainShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetshader void DSGetShader( [out]
		// ID3D11DomainShader **ppDomainShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] UINT
		// *pNumClassInstances );
		[PreserveSig]
		void DSGetShader(out ID3D11DomainShader ppDomainShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances,
			[Optional] ref uint pNumClassInstances);

		/// <summary>Get an array of sampler state interfaces from the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetsamplers void DSGetSamplers( [in]
		// UINT StartSlot, [in] UINT NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		void DSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the constant buffers used by the domain-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-dsgetconstantbuffers void
		// DSGetConstantBuffers( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Get the compute-shader resources.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin getting shader resources from (ranges from 0 to
		/// D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumViews">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The number of resources to get from the device. Up to a maximum of 128 slots are available for shader resources (ranges from 0
		/// to D3D11_COMMONSHADER_INPUT_RESOURCE_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppShaderResourceViews">
		/// <para>Type: <c>ID3D11ShaderResourceView**</c></para>
		/// <para>Array of shader resource view interfaces to be returned by the device.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetshaderresources void
		// CSGetShaderResources( [in] UINT StartSlot, [in] UINT NumViews, [out, optional] ID3D11ShaderResourceView **ppShaderResourceViews );
		[PreserveSig]
		void CSGetShaderResources(uint StartSlot, uint NumViews, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11ShaderResourceView[]? ppShaderResourceViews);

		/// <summary>Gets an array of views for an unordered resource.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Index of the first element in the zero-based array to return (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - 1).</para>
		/// </param>
		/// <param name="NumUAVs">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of views to get (ranges from 0 to D3D11_1_UAV_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppUnorderedAccessViews">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>A pointer to an array of interface pointers (see ID3D11UnorderedAccessView) to get.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call <c>IUnknown::Release</c> on
		/// the returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetunorderedaccessviews void
		// CSGetUnorderedAccessViews( [in] UINT StartSlot, [in] UINT NumUAVs, [out, optional] ID3D11UnorderedAccessView
		// **ppUnorderedAccessViews );
		[PreserveSig]
		void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11UnorderedAccessView[]? ppUnorderedAccessViews);

		/// <summary>Get the compute shader currently set on the device.</summary>
		/// <param name="ppComputeShader">
		/// <para>Type: <c>ID3D11ComputeShader**</c></para>
		/// <para>Address of a pointer to a Compute shader (see ID3D11ComputeShader) to be returned by the method.</para>
		/// </param>
		/// <param name="ppClassInstances">
		/// <para>Type: <c>ID3D11ClassInstance**</c></para>
		/// <para>Pointer to an array of class instance interfaces (see ID3D11ClassInstance).</para>
		/// </param>
		/// <param name="pNumClassInstances">
		/// <para>Type: <c>UINT*</c></para>
		/// <para>The number of class-instance elements in the array.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetshader void CSGetShader( [out]
		// ID3D11ComputeShader **ppComputeShader, [out, optional] ID3D11ClassInstance **ppClassInstances, [in, out, optional] UINT
		// *pNumClassInstances );
		[PreserveSig]
		void CSGetShader(out ID3D11ComputeShader? ppComputeShader, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 2)] ID3D11ClassInstance[]? ppClassInstances,
			[Optional] ref uint pNumClassInstances);

		/// <summary>Get an array of sampler state interfaces from the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into a zero-based array to begin getting samplers from (ranges from 0 to D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumSamplers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Number of samplers to get from a device context. Each pipeline stage has a total of 16 sampler slots available (ranges from 0 to
		/// D3D11_COMMONSHADER_SAMPLER_SLOT_COUNT - StartSlot).
		/// </para>
		/// </param>
		/// <param name="ppSamplers">
		/// <para>Type: <c>ID3D11SamplerState**</c></para>
		/// <para>Pointer to an array of sampler-state interfaces (see ID3D11SamplerState).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetsamplers void CSGetSamplers( [in]
		// UINT StartSlot, [in] UINT NumSamplers, [out, optional] ID3D11SamplerState **ppSamplers );
		[PreserveSig]
		void CSGetSamplers(uint StartSlot, uint NumSamplers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11SamplerState[]? ppSamplers);

		/// <summary>Get the constant buffers used by the compute-shader stage.</summary>
		/// <param name="StartSlot">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Index into the device's zero-based array to begin retrieving constant buffers from (ranges from 0 to
		/// D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - 1).
		/// </para>
		/// </param>
		/// <param name="NumBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers to retrieve (ranges from 0 to D3D11_COMMONSHADER_CONSTANT_BUFFER_API_SLOT_COUNT - StartSlot).</para>
		/// </param>
		/// <param name="ppConstantBuffers">
		/// <para>Type: <c>ID3D11Buffer**</c></para>
		/// <para>Array of constant buffer interface pointers (see ID3D11Buffer) to be returned by the method.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one. Applications should call IUnknown::Release on the
		/// returned interfaces when they are no longer needed to avoid memory leaks.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-csgetconstantbuffers void
		// CSGetConstantBuffers( [in] UINT StartSlot, [in] UINT NumBuffers, [out, optional] ID3D11Buffer **ppConstantBuffers );
		[PreserveSig]
		void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 1)] ID3D11Buffer[]? ppConstantBuffers);

		/// <summary>Restore all default settings.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method resets any device context to the default settings. This sets all input/output resource slots, shaders, input
		/// layouts, predications, scissor rectangles, depth-stencil state, rasterizer state, blend state, sampler state, and viewports to
		/// <c>NULL</c>. The primitive topology is set to UNDEFINED.
		/// </para>
		/// <para>
		/// For a scenario where you would like to clear a list of commands recorded so far, call ID3D11DeviceContext::FinishCommandList and
		/// throw away the resulting ID3D11CommandList.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-clearstate void ClearState();
		[PreserveSig]
		void ClearState();

		/// <summary>Sends queued-up commands in the command buffer to the graphics processing unit (GPU).</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Most applications don't need to call this method. If an application calls this method when not necessary, it incurs a
		/// performance penalty. Each call to <c>Flush</c> incurs a significant amount of overhead.
		/// </para>
		/// <para>
		/// When Microsoft Direct3D state-setting, present, or draw commands are called by an application, those commands are queued into an
		/// internal command buffer. <c>Flush</c> sends those commands to the GPU for processing. Typically, the Direct3D runtime sends
		/// these commands to the GPU automatically whenever the runtime determines that they need to be sent, such as when the command
		/// buffer is full or when an application maps a resource. <c>Flush</c> sends the commands manually.
		/// </para>
		/// <para>
		/// We recommend that you use <c>Flush</c> when the CPU waits for an arbitrary amount of time (such as when you call the Sleep function).
		/// </para>
		/// <para>
		/// Because <c>Flush</c> operates asynchronously, it can return either before or after the GPU finishes executing the queued
		/// graphics commands. However, the graphics commands eventually always complete. You can call the ID3D11Device::CreateQuery method
		/// with the D3D11_QUERY_EVENT value to create an event query; you can then use that event query in a call to the
		/// ID3D11DeviceContext::GetData method to determine when the GPU is finished processing the graphics commands.
		/// </para>
		/// <para>
		/// Microsoft Direct3D 11 defers the destruction of objects. Therefore, an application can't rely upon objects immediately being
		/// destroyed. By calling <c>Flush</c>, you destroy any objects whose destruction was deferred. If an application requires
		/// synchronous destruction of an object, we recommend that the application release all its references, call
		/// ID3D11DeviceContext::ClearState, and then call <c>Flush</c>.
		/// </para>
		/// <para>Deferred Destruction Issues with Flip Presentation Swap Chains</para>
		/// <para>
		/// Direct3D 11 defers the destruction of objects like views and resources until it can efficiently destroy them. This deferred
		/// destruction can cause problems with flip presentation model swap chains. Flip presentation model swap chains have the
		/// DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL flag set. When you create a flip presentation model swap chain, you can associate only one swap
		/// chain at a time with an HWND, <c>IWindow</c>, or composition surface. If an application attempts to destroy a flip presentation
		/// model swap chain and replace it with another swap chain, the original swap chain is not destroyed when the application
		/// immediately frees all of the original swap chain's references.
		/// </para>
		/// <para>
		/// Most applications typically use the IDXGISwapChain::ResizeBuffers method for the majority of scenarios where they replace new
		/// swap chain buffers for old swap chain buffers. However, if an application must actually destroy an old swap chain and create a
		/// new swap chain, the application must force the destruction of all objects that the application freed. To force the destruction,
		/// call ID3D11DeviceContext::ClearState (or otherwise ensure no views are bound to pipeline state), and then call <c>Flush</c> on
		/// the immediate context. You must force destruction before you call IDXGIFactory2::CreateSwapChainForHwnd,
		/// IDXGIFactory2::CreateSwapChainForCoreWindow, or IDXGIFactory2::CreateSwapChainForComposition again to create a new swap chain.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-flush void Flush();
		[PreserveSig]
		void Flush();

		/// <summary>Gets the type of device context.</summary>
		/// <returns>
		/// <para>Type: <c>D3D11_DEVICE_CONTEXT_TYPE</c></para>
		/// <para>A member of D3D11_DEVICE_CONTEXT_TYPE that indicates the type of device context.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-gettype D3D11_DEVICE_CONTEXT_TYPE GetType();
		[PreserveSig]
		D3D11_DEVICE_CONTEXT_TYPE GetType();

		/// <summary>Gets the initialization flags associated with the current deferred context.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// The GetContextFlags method gets the flags that were supplied to the <c>ContextFlags</c> parameter of
		/// ID3D11Device::CreateDeferredContext; however, the context flag is reserved for future use.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-getcontextflags UINT GetContextFlags();
		[PreserveSig]
		uint GetContextFlags();

		/// <summary>Create a command list and record graphics commands into it.</summary>
		/// <param name="RestoreDeferredContextState">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that determines whether the runtime saves deferred context state before it executes <c>FinishCommandList</c> and
		/// restores it afterwards. Use <c>TRUE</c> to indicate that the runtime needs to save and restore the state. Use <c>FALSE</c> to
		/// indicate that the runtime will not save or restore any state. In this case, the deferred context will return to its default
		/// state after the call to <c>FinishCommandList</c> completes. For information about default state, see
		/// ID3D11DeviceContext::ClearState. Typically, use <c>FALSE</c> unless you restore the state to be nearly equivalent to the state
		/// that the runtime would restore if you passed <c>TRUE</c>. When you use <c>FALSE</c>, you can avoid unnecessary and inefficient
		/// state transitions.
		/// </para>
		/// <para>
		/// <c>Note</c>  This parameter does not affect the command list that the current call to <c>FinishCommandList</c> returns. However,
		/// this parameter affects the command list of the next call to <c>FinishCommandList</c> on the same deferred context.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="ppCommandList">
		/// <para>Type: <c>ID3D11CommandList**</c></para>
		/// <para>
		/// Upon completion of the method, the passed pointer to an ID3D11CommandList interface pointer is initialized with the recorded
		/// command list information. The resulting <c>ID3D11CommandList</c> object is immutable and can only be used with ID3D11DeviceContext::ExecuteCommandList.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Returns DXGI_ERROR_DEVICE_REMOVED if the video card has been physically removed from the system, or a driver upgrade for the
		/// video card has occurred. If this error occurs, you should destroy and recreate the device.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// Returns DXGI_ERROR_INVALID_CALL if <c>FinishCommandList</c> cannot be called from the current context. See remarks.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Returns E_OUTOFMEMORY if the application has exhausted available memory.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Create a command list from a deferred context and record commands into it by calling <c>FinishCommandList</c>. Play back a
		/// command list with an immediate context by calling ID3D11DeviceContext::ExecuteCommandList.
		/// </para>
		/// <para>
		/// Immediate context state is cleared before and after a command list is executed. A command list has no concept of inheritance.
		/// Each call to <c>FinishCommandList</c> will record only the state set since any previous call to <c>FinishCommandList</c>.
		/// </para>
		/// <para>
		/// For example, the state of a device context is its render state or pipeline state. To retrieve device context state, an
		/// application can call ID3D11DeviceContext::GetData or ID3D11DeviceContext::GetPredication.
		/// </para>
		/// <para>For more information about how to use <c>FinishCommandList</c>, see How to: Record a Command List.</para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicecontext-finishcommandlist HRESULT
		// FinishCommandList( BOOL RestoreDeferredContextState, [out, optional] ID3D11CommandList **ppCommandList );
		[PreserveSig]
		HRESULT FinishCommandList([MarshalAs(UnmanagedType.Bool)] bool RestoreDeferredContextState,
			[Optional, MarshalAs(UnmanagedType.Interface)] out ID3D11CommandList? ppCommandList);
	}

	/// <summary>A domain-shader interface manages an executable program (a domain shader) that controls the domain-shader stage.</summary>
	/// <remarks>
	/// <para>
	/// The domain-shader interface has no methods; use HLSL to implement your shader functionality. All shaders are implemented from a
	/// common set of features referred to as the common-shader core..
	/// </para>
	/// <para>
	/// To create a domain-shader interface, call ID3D11Device::CreateDomainShader. Before using a domain shader you must bind it to the
	/// device by calling ID3D11DeviceContext::DSSetShader.
	/// </para>
	/// <para>This interface is defined in D3D11.h.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11domainshader
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11DomainShader")]
	[ComImport, Guid("f582c508-0f36-490c-9977-31eece268cfa"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DomainShader : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>A geometry-shader interface manages an executable program (a geometry shader) that controls the geometry-shader stage.</summary>
	/// <remarks>
	/// <para>
	/// The geometry-shader interface has no methods; use HLSL to implement your shader functionality. All shaders are implemented from a
	/// common set of features referred to as the common-shader core..
	/// </para>
	/// <para>
	/// To create a geometry shader interface, call either ID3D11Device::CreateGeometryShader or
	/// ID3D11Device::CreateGeometryShaderWithStreamOutput. Before using a geometry shader you must bind it to the device by calling ID3D11DeviceContext::GSSetShader.
	/// </para>
	/// <para>This interface is defined in D3D11.h.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11geometryshader
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11GeometryShader")]
	[ComImport, Guid("38325b96-effb-4022-ba02-2e795b70275c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11GeometryShader : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>A hull-shader interface manages an executable program (a hull shader) that controls the hull-shader stage.</summary>
	/// <remarks>
	/// <para>
	/// The hull-shader interface has no methods; use HLSL to implement your shader functionality. All shaders are implemented from a common
	/// set of features referred to as the common-shader core..
	/// </para>
	/// <para>
	/// To create a hull-shader interface, call ID3D11Device::CreateHullShader. Before using a hull shader you must bind it to the device by
	/// calling ID3D11DeviceContext::HSSetShader.
	/// </para>
	/// <para>This interface is defined in D3D11.h.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11hullshader
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11HullShader")]
	[ComImport, Guid("8e5c6061-628a-4c8e-8264-bbe45cb3d5dd"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11HullShader : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>
	/// An input-layout interface holds a definition of how to feed vertex data that is laid out in memory into the input-assembler stage of
	/// the graphics pipeline.
	/// </summary>
	/// <remarks>
	/// To create an input-layout object, call ID3D11Device::CreateInputLayout. To bind the input-layout object to the input-assembler
	/// stage, call ID3D11DeviceContext::IASetInputLayout.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11inputlayout
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11InputLayout")]
	[ComImport, Guid("e4819ddc-4cf0-4025-bd26-5de82a3e07b7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11InputLayout : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>A pixel-shader interface manages an executable program (a pixel shader) that controls the pixel-shader stage.</summary>
	/// <remarks>
	/// <para>
	/// The pixel-shader interface has no methods; use HLSL to implement your shader functionality. All shaders in are implemented from a
	/// common set of features referred to as the common-shader core..
	/// </para>
	/// <para>
	/// To create a pixel shader interface, call ID3D11Device::CreatePixelShader. Before using a pixel shader you must bind it to the device
	/// by calling ID3D11DeviceContext::PSSetShader.
	/// </para>
	/// <para>This interface is defined in D3D11.h.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11pixelshader
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11PixelShader")]
	[ComImport, Guid("ea82e40d-51dc-4f33-93d4-db7c9125ae8c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11PixelShader : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>A predicate interface determines whether geometry should be processed depending on the results of a previous draw call.</summary>
	/// <remarks>
	/// <para>To create a predicate object, call ID3D11Device::CreatePredicate. To set the predicate object, call ID3D11DeviceContext::SetPredication.</para>
	/// <para>
	/// There are two types of predicates: stream-output-overflow predicates and occlusion predicates. Stream-output-overflow predicates
	/// cause any geometry residing in stream-output buffers that were overflowed to not be processed. Occlusion predicates cause any
	/// geometry that did not have a single sample pass the depth/stencil tests to not be processed.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11predicate
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Predicate")]
	[ComImport, Guid("9eb576dd-9f77-4d86-81aa-8bab5fe490e2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Predicate : ID3D11Query, ID3D11Asynchronous, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the size of the data (in bytes) that is output when calling ID3D11DeviceContext::GetData.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the data (in bytes) that is output when calling GetData.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11asynchronous-getdatasize UINT GetDataSize();
		[PreserveSig]
		new uint GetDataSize();

		/// <summary>Get a query description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_QUERY_DESC*</c></para>
		/// <para>Pointer to a query description (see D3D11_QUERY_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11query-getdesc void GetDesc( [out] D3D11_QUERY_DESC
		// *pDesc );
		[PreserveSig]
		new void GetDesc(out D3D11_QUERY_DESC pDesc);
	}

	/// <summary>A query interface queries information from the GPU.</summary>
	/// <remarks>
	/// <para>A query can be created with ID3D11Device::CreateQuery.</para>
	/// <para>
	/// Query data is typically gathered by issuing an ID3D11DeviceContext::Begin command, issuing some graphics commands, issuing an
	/// ID3D11DeviceContext::End command, and then calling ID3D11DeviceContext::GetData to get data about what happened in between the Begin
	/// and End calls. The data returned by <c>GetData</c> will be different depending on the type of query.
	/// </para>
	/// <para>There are, however, some queries that do not require calls to Begin. For a list of possible queries see D3D11_QUERY.</para>
	/// <para>A query is typically executed as shown in the following code:</para>
	/// <para>
	/// When using a query that does not require a call to Begin, it still requires a call to End. The call to <c>End</c> causes the data
	/// returned by GetData to be accurate up until the last call to <c>End</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11query
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Query")]
	[ComImport, Guid("d6c00747-87b7-425e-b84d-44d108560afd"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Query : ID3D11Asynchronous, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the size of the data (in bytes) that is output when calling ID3D11DeviceContext::GetData.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of the data (in bytes) that is output when calling GetData.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11asynchronous-getdatasize UINT GetDataSize();
		[PreserveSig]
		new uint GetDataSize();

		/// <summary>Get a query description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_QUERY_DESC*</c></para>
		/// <para>Pointer to a query description (see D3D11_QUERY_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11query-getdesc void GetDesc( [out] D3D11_QUERY_DESC
		// *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_QUERY_DESC pDesc);
	}

	/// <summary>The rasterizer-state interface holds a description for rasterizer state that you can bind to the rasterizer stage.</summary>
	/// <remarks>
	/// To create a rasterizer-state object, call ID3D11Device::CreateRasterizerState. To bind the rasterizer-state object to the rasterizer
	/// stage, call ID3D11DeviceContext::RSSetState.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11rasterizerstate
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11RasterizerState")]
	[ComImport, Guid("9bb4ab81-ab1a-4d8f-b506-fc04200b6ee7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11RasterizerState : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the description for rasterizer state that you used to create the rasterizer-state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_RASTERIZER_DESC*</c></para>
		/// <para>A pointer to a D3D11_RASTERIZER_DESC structure that receives a description of the rasterizer state.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// You use the description for rasterizer state in a call to the ID3D11Device::CreateRasterizerState method to create the
		/// rasterizer-state object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11rasterizerstate-getdesc void GetDesc( [out]
		// D3D11_RASTERIZER_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_RASTERIZER_DESC pDesc);
	}

	/// <summary>A render-target-view interface identifies the render-target subresources that can be accessed during rendering.</summary>
	/// <remarks>
	/// <para>
	/// To create a render-target view, call ID3D11Device::CreateRenderTargetView. To bind a render-target view to the pipeline, call ID3D11DeviceContext::OMSetRenderTargets.
	/// </para>
	/// <para>
	/// A rendertarget is a resource that can be written by the output-merger stage at the end of a render pass. Each render-target should
	/// also have a corresponding depth-stencil view.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11rendertargetview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11RenderTargetView")]
	[ComImport, Guid("dfdba067-0b8d-4865-875b-d7b4516cc164"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11RenderTargetView : ID3D11View, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Get the properties of a render target view.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_RENDER_TARGET_VIEW_DESC*</c></para>
		/// <para>Pointer to the description of a render target view (see D3D11_RENDER_TARGET_VIEW_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11rendertargetview-getdesc void GetDesc( [out]
		// D3D11_RENDER_TARGET_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_RENDER_TARGET_VIEW_DESC pDesc);
	}

	/// <summary>A resource interface provides common actions on all resources.</summary>
	/// <remarks>
	/// You don't directly create a resource interface; instead, you create buffers and textures that inherit from a resource interface. For
	/// more info, see How to: Create a Vertex Buffer, How to: Create an Index Buffer, How to: Create a Constant Buffer, and How to: Create
	/// a Texture.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11resource
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Resource")]
	[ComImport, Guid("dc8e63f3-d12b-4952-b47b-5e45026a862d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Resource : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the type of the resource.</summary>
		/// <param name="pResourceDimension">
		/// <para>Type: <c>D3D11_RESOURCE_DIMENSION*</c></para>
		/// <para>Pointer to the resource type (see D3D11_RESOURCE_DIMENSION).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-gettype void GetType( [out]
		// D3D11_RESOURCE_DIMENSION *pResourceDimension );
		[PreserveSig]
		void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		/// <summary>Set the eviction priority of a resource.</summary>
		/// <param name="EvictionPriority">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Eviction priority for the resource, which is one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Resource priorities determine which resource to evict from video memory when the system has run out of video memory. The
		/// resource will not be lost; it will be removed from video memory and placed into system memory, or possibly placed onto the hard
		/// drive. The resource will be loaded back into video memory when it is required.
		/// </para>
		/// <para>
		/// A resource that is set to the maximum priority, DXGI_RESOURCE_PRIORITY_MAXIMUM, is only evicted if there is no other way of
		/// resolving the incoming memory request. The Windows Display Driver Model (WDDM) tries to split an incoming memory request to its
		/// minimum size and evict lower-priority resources before evicting a resource with maximum priority.
		/// </para>
		/// <para>
		/// Changing the priorities of resources should be done carefully. The wrong eviction priorities could be a detriment to performance
		/// rather than an improvement.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-setevictionpriority void SetEvictionPriority(
		// [in] UINT EvictionPriority );
		[PreserveSig]
		void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority of a resource.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>One of the following values, which specifies the eviction priority for the resource:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-getevictionpriority UINT GetEvictionPriority();
		[PreserveSig]
		uint GetEvictionPriority();
	}

	/// <summary>
	/// The sampler-state interface holds a description for sampler state that you can bind to any shader stage of the pipeline for
	/// reference by texture sample operations.
	/// </summary>
	/// <remarks>
	/// <para>To create a sampler-state object, call ID3D11Device::CreateSamplerState.</para>
	/// <para>To bind a sampler-state object to any pipeline shader stage, call the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>ID3D11DeviceContext::VSSetSamplers</description>
	/// </item>
	/// <item>
	/// <description>ID3D11DeviceContext::HSSetSamplers</description>
	/// </item>
	/// <item>
	/// <description>ID3D11DeviceContext::DSSetSamplers</description>
	/// </item>
	/// <item>
	/// <description>ID3D11DeviceContext::GSSetSamplers</description>
	/// </item>
	/// <item>
	/// <description>ID3D11DeviceContext::PSSetSamplers</description>
	/// </item>
	/// <item>
	/// <description>ID3D11DeviceContext::CSSetSamplers</description>
	/// </item>
	/// </list>
	/// <para>You can bind the same sampler-state object to multiple shader stages simultaneously.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11samplerstate
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11SamplerState")]
	[ComImport, Guid("da6fea51-564c-4487-9810-f0d0f9b4e3a5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11SamplerState : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the description for sampler state that you used to create the sampler-state object.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SAMPLER_DESC*</c></para>
		/// <para>A pointer to a D3D11_SAMPLER_DESC structure that receives a description of the sampler state.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// You use the description for sampler state in a call to the ID3D11Device::CreateSamplerState method to create the sampler-state object.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11samplerstate-getdesc void GetDesc( [out]
		// D3D11_SAMPLER_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_SAMPLER_DESC pDesc);
	}

	/// <summary>
	/// A shader-resource-view interface specifies the subresources a shader can access during rendering. Examples of shader resources
	/// include a constant buffer, a texture buffer, and a texture.
	/// </summary>
	/// <remarks>
	/// <para>To create a shader-resource view, call ID3D11Device::CreateShaderResourceView.</para>
	/// <para>
	/// A shader-resource view is required when binding a resource to a shader stage; the binding occurs by calling
	/// ID3D11DeviceContext::GSSetShaderResources, ID3D11DeviceContext::VSSetShaderResources or ID3D11DeviceContext::PSSetShaderResources.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11shaderresourceview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11ShaderResourceView")]
	[ComImport, Guid("b0e06fe0-8192-4e1a-b1ca-36d7414710b2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderResourceView : ID3D11View, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Get the shader resource view's description.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_SHADER_RESOURCE_VIEW_DESC*</c></para>
		/// <para>A pointer to a D3D11_SHADER_RESOURCE_VIEW_DESC structure to be filled with data about the shader resource view.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11shaderresourceview-getdesc void GetDesc( [out]
		// D3D11_SHADER_RESOURCE_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_SHADER_RESOURCE_VIEW_DESC pDesc);
	}

	/// <summary>A 1D texture interface accesses texel data, which is structured memory.</summary>
	/// <remarks>
	/// <para>
	/// To create an empty 1D texture, call ID3D11Device::CreateTexture1D. For info about how to create a 2D texture, which is similar to
	/// creating a 1D texture, see How to: Create a Texture.
	/// </para>
	/// <para>
	/// Textures cannot be bound directly to the pipeline; instead, a view must be created and bound. Using a view, texture data can be
	/// interpreted at run time within certain restrictions. To use the texture as a render target or depth-stencil resource, call
	/// ID3D11Device::CreateRenderTargetView, and ID3D11Device::CreateDepthStencilView, respectively. To use the texture as an input to a
	/// shader, create a by calling ID3D11Device::CreateShaderResourceView.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11texture1d
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Texture1D")]
	[ComImport, Guid("f8fb5c27-c6b3-4f75-a4c8-439af2ef564c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Texture1D : ID3D11Resource, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the type of the resource.</summary>
		/// <param name="pResourceDimension">
		/// <para>Type: <c>D3D11_RESOURCE_DIMENSION*</c></para>
		/// <para>Pointer to the resource type (see D3D11_RESOURCE_DIMENSION).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-gettype void GetType( [out]
		// D3D11_RESOURCE_DIMENSION *pResourceDimension );
		[PreserveSig]
		new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		/// <summary>Set the eviction priority of a resource.</summary>
		/// <param name="EvictionPriority">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Eviction priority for the resource, which is one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Resource priorities determine which resource to evict from video memory when the system has run out of video memory. The
		/// resource will not be lost; it will be removed from video memory and placed into system memory, or possibly placed onto the hard
		/// drive. The resource will be loaded back into video memory when it is required.
		/// </para>
		/// <para>
		/// A resource that is set to the maximum priority, DXGI_RESOURCE_PRIORITY_MAXIMUM, is only evicted if there is no other way of
		/// resolving the incoming memory request. The Windows Display Driver Model (WDDM) tries to split an incoming memory request to its
		/// minimum size and evict lower-priority resources before evicting a resource with maximum priority.
		/// </para>
		/// <para>
		/// Changing the priorities of resources should be done carefully. The wrong eviction priorities could be a detriment to performance
		/// rather than an improvement.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-setevictionpriority void SetEvictionPriority(
		// [in] UINT EvictionPriority );
		[PreserveSig]
		new void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority of a resource.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>One of the following values, which specifies the eviction priority for the resource:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-getevictionpriority UINT GetEvictionPriority();
		[PreserveSig]
		new uint GetEvictionPriority();

		/// <summary>Get the properties of the texture resource.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_TEXTURE1D_DESC*</c></para>
		/// <para>Pointer to a resource description (see D3D11_TEXTURE1D_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11texture1d-getdesc void GetDesc( [out]
		// D3D11_TEXTURE1D_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_TEXTURE1D_DESC pDesc);
	}

	/// <summary>A 2D texture interface manages texel data, which is structured memory.</summary>
	/// <remarks>
	/// <para>
	/// To create an empty Texture2D resource, call ID3D11Device::CreateTexture2D. For info about how to create a 2D texture, see How to:
	/// Create a Texture.
	/// </para>
	/// <para>
	/// Textures cannot be bound directly to the pipeline; instead, a view must be created and bound. Using a view, texture data can be
	/// interpreted at run time within certain restrictions. To use the texture as a render target or depth-stencil resource, call
	/// ID3D11Device::CreateRenderTargetView, and ID3D11Device::CreateDepthStencilView, respectively. To use the texture as an input to a
	/// shader, create a by calling ID3D11Device::CreateShaderResourceView.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11texture2d
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Texture2D")]
	[ComImport, Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Texture2D : ID3D11Resource, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the type of the resource.</summary>
		/// <param name="pResourceDimension">
		/// <para>Type: <c>D3D11_RESOURCE_DIMENSION*</c></para>
		/// <para>Pointer to the resource type (see D3D11_RESOURCE_DIMENSION).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-gettype void GetType( [out]
		// D3D11_RESOURCE_DIMENSION *pResourceDimension );
		[PreserveSig]
		new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		/// <summary>Set the eviction priority of a resource.</summary>
		/// <param name="EvictionPriority">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Eviction priority for the resource, which is one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Resource priorities determine which resource to evict from video memory when the system has run out of video memory. The
		/// resource will not be lost; it will be removed from video memory and placed into system memory, or possibly placed onto the hard
		/// drive. The resource will be loaded back into video memory when it is required.
		/// </para>
		/// <para>
		/// A resource that is set to the maximum priority, DXGI_RESOURCE_PRIORITY_MAXIMUM, is only evicted if there is no other way of
		/// resolving the incoming memory request. The Windows Display Driver Model (WDDM) tries to split an incoming memory request to its
		/// minimum size and evict lower-priority resources before evicting a resource with maximum priority.
		/// </para>
		/// <para>
		/// Changing the priorities of resources should be done carefully. The wrong eviction priorities could be a detriment to performance
		/// rather than an improvement.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-setevictionpriority void SetEvictionPriority(
		// [in] UINT EvictionPriority );
		[PreserveSig]
		new void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority of a resource.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>One of the following values, which specifies the eviction priority for the resource:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-getevictionpriority UINT GetEvictionPriority();
		[PreserveSig]
		new uint GetEvictionPriority();

		/// <summary>Get the properties of the texture resource.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_TEXTURE2D_DESC*</c></para>
		/// <para>Pointer to a resource description (see D3D11_TEXTURE2D_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11texture2d-getdesc void GetDesc( [out]
		// D3D11_TEXTURE2D_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_TEXTURE2D_DESC pDesc);
	}

	/// <summary>A 3D texture interface accesses texel data, which is structured memory.</summary>
	/// <remarks>
	/// <para>
	/// To create an empty Texture3D resource, call ID3D11Device::CreateTexture3D. For info about how to create a 2D texture, which is
	/// similar to creating a 3D texture, see How to: Create a Texture.
	/// </para>
	/// <para>
	/// Textures cannot be bound directly to the pipeline; instead, a view must be created and bound. Using a view, texture data can be
	/// interpreted at run time within certain restrictions. To use the texture as a render target or depth-stencil resource, call
	/// ID3D11Device::CreateRenderTargetView, and ID3D11Device::CreateDepthStencilView, respectively. To use the texture as an input to a
	/// shader, create a by calling ID3D11Device::CreateShaderResourceView.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11texture3d
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11Texture3D")]
	[ComImport, Guid("037e866e-f56d-4357-a8af-9dabbe6e250e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Texture3D : ID3D11Resource, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the type of the resource.</summary>
		/// <param name="pResourceDimension">
		/// <para>Type: <c>D3D11_RESOURCE_DIMENSION*</c></para>
		/// <para>Pointer to the resource type (see D3D11_RESOURCE_DIMENSION).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks><c>Windows Phone 8:</c> This API is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-gettype void GetType( [out]
		// D3D11_RESOURCE_DIMENSION *pResourceDimension );
		[PreserveSig]
		new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		/// <summary>Set the eviction priority of a resource.</summary>
		/// <param name="EvictionPriority">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Eviction priority for the resource, which is one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Resource priorities determine which resource to evict from video memory when the system has run out of video memory. The
		/// resource will not be lost; it will be removed from video memory and placed into system memory, or possibly placed onto the hard
		/// drive. The resource will be loaded back into video memory when it is required.
		/// </para>
		/// <para>
		/// A resource that is set to the maximum priority, DXGI_RESOURCE_PRIORITY_MAXIMUM, is only evicted if there is no other way of
		/// resolving the incoming memory request. The Windows Display Driver Model (WDDM) tries to split an incoming memory request to its
		/// minimum size and evict lower-priority resources before evicting a resource with maximum priority.
		/// </para>
		/// <para>
		/// Changing the priorities of resources should be done carefully. The wrong eviction priorities could be a detriment to performance
		/// rather than an improvement.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-setevictionpriority void SetEvictionPriority(
		// [in] UINT EvictionPriority );
		[PreserveSig]
		new void SetEvictionPriority(uint EvictionPriority);

		/// <summary>Get the eviction priority of a resource.</summary>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>One of the following values, which specifies the eviction priority for the resource:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MINIMUM</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_LOW</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_NORMAL</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_HIGH</description>
		/// </item>
		/// <item>
		/// <description>DXGI_RESOURCE_PRIORITY_MAXIMUM</description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11resource-getevictionpriority UINT GetEvictionPriority();
		[PreserveSig]
		new uint GetEvictionPriority();

		/// <summary>Get the properties of the texture resource.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_TEXTURE3D_DESC*</c></para>
		/// <para>Pointer to a resource description (see D3D11_TEXTURE3D_DESC).</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11texture3d-getdesc void GetDesc( [out]
		// D3D11_TEXTURE3D_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_TEXTURE3D_DESC pDesc);
	}

	/// <summary>A view interface specifies the parts of a resource the pipeline can access during rendering.</summary>
	/// <remarks>
	/// <para>To create a view for an unordered access resource, call ID3D11Device::CreateUnorderedAccessView.</para>
	/// <para>
	/// All resources must be bound to the pipeline before they can be accessed. Call ID3D11DeviceContext::CSSetUnorderedAccessViews to bind
	/// an unordered access view to a compute shader; call ID3D11DeviceContext::OMSetRenderTargetsAndUnorderedAccessViews to bind an
	/// unordered access view to a pixel shader.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11unorderedaccessview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11UnorderedAccessView")]
	[ComImport, Guid("28acf509-7f5c-48f6-8611-f316010a6380"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11UnorderedAccessView : ID3D11View
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Get a description of the resource.</summary>
		/// <param name="pDesc">
		/// <para>Type: <c>D3D11_UNORDERED_ACCESS_VIEW_DESC*</c></para>
		/// <para>Pointer to a resource description (see D3D11_UNORDERED_ACCESS_VIEW_DESC.)</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11unorderedaccessview-getdesc void GetDesc( [out]
		// D3D11_UNORDERED_ACCESS_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc);
	}

	/// <summary>A vertex-shader interface manages an executable program (a vertex shader) that controls the vertex-shader stage.</summary>
	/// <remarks>
	/// <para>
	/// The vertex-shader interface has no methods; use HLSL to implement your shader functionality. All shaders are implemented from a
	/// common set of features referred to as the common-shader core..
	/// </para>
	/// <para>
	/// To create a vertex shader interface, call ID3D11Device::CreateVertexShader. Before using a vertex shader you must bind it to the
	/// device by calling ID3D11DeviceContext::VSSetShader.
	/// </para>
	/// <para>This interface is defined in D3D11.h.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11vertexshader
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VertexShader")]
	[ComImport, Guid("3b301d64-d678-4289-8897-22f8928b72f3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VertexShader : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);
	}

	/// <summary>Provides the video functionality of a Microsoft Direct3D 11 device.</summary>
	/// <remarks>
	/// <para>To get a pointer to this interface, call QueryInterface with an ID3D11DeviceContext interface pointer.</para>
	/// <para>This interface provides access to several areas of Microsoft Direct3Dvideo functionality:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Hardware-accelerated video decoding</description>
	/// </item>
	/// <item>
	/// <description>Video processing</description>
	/// </item>
	/// <item>
	/// <description>GPU-based content protection</description>
	/// </item>
	/// <item>
	/// <description>Video encryption and decryption</description>
	/// </item>
	/// </list>
	/// <para>In Microsoft Direct3D 9, the equivalent functions were distributed across several interfaces:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>IDirect3DAuthenticatedChannel9</description>
	/// </item>
	/// <item>
	/// <description>IDirect3DCryptoSession9</description>
	/// </item>
	/// <item>
	/// <description>IDirectXVideoDecoder</description>
	/// </item>
	/// <item>
	/// <description>IDirectXVideoProcessor</description>
	/// </item>
	/// <item>
	/// <description>IDXVAHD_VideoProcessor</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videocontext
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoContext")]
	[ComImport, Guid("61f21c45-3c0e-4a74-9cea-67100d9ad5e4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoContext : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets a pointer to a decoder buffer.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="Type">The type of buffer to retrieve, specified as a member of the D3D11_VIDEO_DECODER_BUFFER_TYPE enumeration.</param>
		/// <param name="pBufferSize">Receives the size of the buffer, in bytes.</param>
		/// <param name="ppBuffer">Receives a pointer to the start of the memory buffer.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// The graphics driver allocates the buffers that are used for decoding. This method locks the Microsoft Direct3Dsurface that
		/// contains the buffer. When you are done using the buffer, call ID3D11VideoContext::ReleaseDecoderBuffer to unlock the surface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-getdecoderbuffer HRESULT GetDecoderBuffer(
		// [in] ID3D11VideoDecoder *pDecoder, [in] D3D11_VIDEO_DECODER_BUFFER_TYPE Type, [out] UINT *pBufferSize, [out] void **ppBuffer );
		[PreserveSig]
		HRESULT GetDecoderBuffer([In] ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);

		/// <summary>Releases a buffer that was obtained by calling the ID3D11VideoContext::GetDecoderBuffer method.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="Type">
		/// The type of buffer to release. Specify the same value that was used in the <c>Type</c> parameter of the GetDecoderBuffer method.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-releasedecoderbuffer HRESULT
		// ReleaseDecoderBuffer( [in] ID3D11VideoDecoder *pDecoder, [in] D3D11_VIDEO_DECODER_BUFFER_TYPE Type );
		[PreserveSig]
		HRESULT ReleaseDecoderBuffer([In] ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);

		/// <summary>Starts a decoding operation to decode a video frame.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="pView">
		/// A pointer to the ID3D11VideoDecoderOutputView interface. This interface describes the resource that will receive the decoded
		/// frame. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoderOutputView.
		/// </param>
		/// <param name="ContentKeySize">
		/// The size of the content key that is specified in <c>pContentKey</c>. If <c>pContentKey</c> is NULL, set <c>ContentKeySize</c> to zero.
		/// </param>
		/// <param name="pContentKey">
		/// An optional pointer to a content key that was used to encrypt the frame data. If no content key was used, set this parameter to
		/// <c>NULL</c>. If the caller provides a content key, the caller must use the session key to encrypt the content key.
		/// </param>
		/// <returns>
		/// If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.
		/// <c>D3DERR_WASSTILLDRAWING</c> or <c>E_PENDING</c> is returned if the hardware is busy, in which case the decoder should try to
		/// make the call again.
		/// </returns>
		/// <remarks>
		/// <para>
		/// After this method is called, call ID3D11VideoContext::SubmitDecoderBuffers to perform decoding operations. When all decoding
		/// operations have been executed, call ID3D11VideoContext::DecoderEndFrame.
		/// </para>
		/// <para>
		/// Each call to <c>DecoderBeginFrame</c> must have a matching call to DecoderEndFrame. In most cases you cannot nest
		/// <c>DecoderBeginFrame</c> calls, but some codecs, such as like VC-1, can have nested <c>DecoderBeginFrame</c> calls for special
		/// operations like post processing.
		/// </para>
		/// <para>The following encryption scenarios are supported through the content key:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The decoder can choose to not encrypt every frame, for example it may only encrypt the I frames and not encrypt the P/B frames.
		/// In these scenario, the decoder will specify pContentKey = NULL and ContentKeySize = 0 for those frames that it does not encrypt.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The decoder can choose to encrypt the compressed buffers using the session key. In this scenario, the decoder will specify a
		/// content key containing all zeros.
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The decoder can choose to encrypt the compressed buffers using a separate content key. In this scenario, the decoder will ECB
		/// encrypt the content key using the session key and pass the encrypted content key.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderbeginframe HRESULT
		// DecoderBeginFrame( [in] ID3D11VideoDecoder *pDecoder, [in] ID3D11VideoDecoderOutputView *pView, [in] UINT ContentKeySize, [in]
		// const void *pContentKey );
		[PreserveSig]
		HRESULT DecoderBeginFrame([In] ID3D11VideoDecoder pDecoder, [In] ID3D11VideoDecoderOutputView pView, uint ContentKeySize, [In] IntPtr pContentKey);

		/// <summary>Signals the end of a decoding operation.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderendframe HRESULT DecoderEndFrame(
		// [in] ID3D11VideoDecoder *pDecoder );
		[PreserveSig]
		HRESULT DecoderEndFrame([In] ID3D11VideoDecoder pDecoder);

		/// <summary>Submits one or more buffers for decoding.</summary>
		/// <param name="pDecoder">
		/// A pointer to the ID3D11VideoDecoder interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoDecoder method.
		/// </param>
		/// <param name="NumBuffers">The number of buffers submitted for decoding.</param>
		/// <param name="pBufferDesc">
		/// A pointer to an array of D3D11_VIDEO_DECODER_BUFFER_DESC structures. The <c>NumBuffers</c> parameter specifies the number of
		/// elements in the array. Each element in the array describes a compressed buffer for decoding.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// <para>
		/// When using feature levels 9_x, all partially encrypted buffers must use the same EncryptedBlockInfo, and partial encryption
		/// cannot be turned off on a per frame basis.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-submitdecoderbuffers HRESULT
		// SubmitDecoderBuffers( [in] ID3D11VideoDecoder *pDecoder, [in] UINT NumBuffers, [in] const D3D11_VIDEO_DECODER_BUFFER_DESC
		// *pBufferDesc );
		[PreserveSig]
		HRESULT SubmitDecoderBuffers([In] ID3D11VideoDecoder pDecoder, int NumBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc);

		/// <summary>Performs an extended function for decoding. This method enables extensions to the basic decoder functionality.</summary>
		/// <param name="pDecoder">A pointer to the ID3D11VideoDecoder interface. To get this pointer, call ID3D11VideoDevice::CreateVideoDecoder.</param>
		/// <param name="pExtensionData">A pointer to a D3D11_VIDEO_DECODER_EXTENSION structure that contains data for the function.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decoderextension APP_DEPRECATED_HRESULT
		// DecoderExtension( [in] ID3D11VideoDecoder *pDecoder, [in] const D3D11_VIDEO_DECODER_EXTENSION *pExtensionData );
		[PreserveSig]
		int DecoderExtension([In] ID3D11VideoDecoder pDecoder, in D3D11_VIDEO_DECODER_EXTENSION pExtensionData);

		/// <summary>Sets the target rectangle for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">Specifies whether to apply the target rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the target rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The target rectangle is the area within the destination surface where the output will be drawn. The target rectangle is given in
		/// pixel coordinates, relative to the destination surface.
		/// </para>
		/// <para>
		/// If this method is never called, or if the <c>Enable</c> parameter is <c>FALSE</c>, the video processor writes to the entire
		/// destination surface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputtargetrect void
		// VideoProcessorSetOutputTargetRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL Enable, [in] const RECT *pRect );
		[PreserveSig]
		void VideoProcessorSetOutputTargetRect([In] ID3D11VideoProcessor pVideoProcessor, bool Enable, [In, Optional] PRECT? pRect);

		/// <summary>Sets the background color for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="YCbCr">If <c>TRUE</c>, the color is specified as a YCbCr value. Otherwise, the color is specified as an RGB value.</param>
		/// <param name="pColor">A pointer to a D3D11_VIDEO_COLOR structure that specifies the background color.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// The video processor uses the background color to fill areas of the target rectangle that do not contain a video image. Areas
		/// outside the target rectangle are not affected.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputbackgroundcolor void
		// VideoProcessorSetOutputBackgroundColor( [in] ID3D11VideoProcessor *pVideoProcessor, [in] BOOL YCbCr, [in] const D3D11_VIDEO_COLOR
		// *pColor );
		[PreserveSig]
		void VideoProcessorSetOutputBackgroundColor([In] ID3D11VideoProcessor pVideoProcessor, bool YCbCr, in D3D11_VIDEO_COLOR pColor);

		/// <summary>Sets the output color space for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pColorSpace">A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputcolorspace void
		// VideoProcessorSetOutputColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const D3D11_VIDEO_PROCESSOR_COLOR_SPACE
		// *pColorSpace );
		[PreserveSig]
		void VideoProcessorSetOutputColorSpace([In] ID3D11VideoProcessor pVideoProcessor, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Sets the alpha fill mode for data that the video processor writes to the render target.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="AlphaFillMode">The alpha fill mode, specified as a D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE value.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of an input stream. This parameter is used if <c>AlphaFillMode</c> is
		/// <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM</c>. Otherwise, the parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To find out which fill modes the device supports, call the ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps method. If the
		/// driver reports the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_FILL</c> capability, the driver supports all of the fill modes.
		/// Otherwise, the <c>AlphaFillMode</c> parameter must be <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE</c>.
		/// </para>
		/// <para>The default fill mode is <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_OPAQUE</c>.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputalphafillmode void
		// VideoProcessorSetOutputAlphaFillMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
		// AlphaFillMode, [in] UINT StreamIndex );
		[PreserveSig]
		void VideoProcessorSetOutputAlphaFillMode([In] ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);

		/// <summary>Sets the amount of downsampling to perform on the output.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">
		/// If <c>TRUE</c>, downsampling is enabled. Otherwise, downsampling is disabled and the <c>Size</c> member is ignored.
		/// </param>
		/// <param name="Size">The sampling size.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Downsampling is sometimes used to reduce the quality of premium content when other forms of content protection are not
		/// available. By default, downsampling is disabled.
		/// </para>
		/// <para>
		/// If the <c>Enable</c> parameter is <c>TRUE</c>, the driver downsamples the composed image to the specified size, and then scales
		/// it back to the size of the target rectangle.
		/// </para>
		/// <para>
		/// The width and height of <c>Size</c> must be greater than zero. If the size is larger than the target rectangle, downsampling
		/// does not occur.
		/// </para>
		/// <para>
		/// To use this feature, the driver must support downsampling, indicated by the
		/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_CONSTRICTION</c> capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputconstriction void
		// VideoProcessorSetOutputConstriction( [in] ID3D11VideoProcessor *pVideoProcessor, BOOL Enable, SIZE Size );
		[PreserveSig]
		void VideoProcessorSetOutputConstriction([In] ID3D11VideoProcessor pVideoProcessor, bool Enable, SIZE Size);

		/// <summary>Specifies whether the video processor produces stereo video frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enable">If <c>TRUE</c>, stereo output is enabled. Otherwise, the video processor produces mono video frames.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>By default, the video processor produces mono video frames.</para>
		/// <para>
		/// To use this feature, the driver must support stereo video, indicated by the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_STEREO</c>
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputstereomode void
		// VideoProcessorSetOutputStereoMode( [in] ID3D11VideoProcessor *pVideoProcessor, BOOL Enable );
		[PreserveSig]
		void VideoProcessorSetOutputStereoMode([In] ID3D11VideoProcessor pVideoProcessor, bool Enable);

		/// <summary>Sets a driver-specific video processing state.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the operation. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a buffer that contains private state data. The method passes this buffer directly to the driver without validation.
		/// It is the responsibility of the driver to validate the data.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetoutputextension
		// APP_DEPRECATED_HRESULT VideoProcessorSetOutputExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const GUID
		// *pExtensionGuid, [in] UINT DataSize, [in] void *pData );
		[PreserveSig]
		int VideoProcessorSetOutputExtension([In] ID3D11VideoProcessor pVideoProcessor, in Guid pExtensionGuid, uint DataSize, [In] IntPtr pData);

		/// <summary>Gets the current target rectangle for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="Enabled">
		/// Receives the value <c>TRUE</c> if the target rectangle was explicitly set using the
		/// ID3D11VideoContext::VideoProcessorSetOutputTargetRect method. Receives the value FALSE if the target rectangle was disabled or
		/// was never set.
		/// </param>
		/// <param name="pRect">
		/// If <c>Enabled</c> receives the value <c>TRUE</c>, this parameter receives the target rectangle. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputtargetrect void
		// VideoProcessorGetOutputTargetRect( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *Enabled, [out] RECT *pRect );
		[PreserveSig]
		void VideoProcessorGetOutputTargetRect([In] ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);

		/// <summary>Gets the current background color for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pYCbCr">
		/// Receives the value <c>TRUE</c> if the background color is a YCbCr color, or <c>FALSE</c> if the background color is an RGB color.
		/// </param>
		/// <param name="pColor">A pointer to a D3D11_VIDEO_COLOR structure. The method fills in the structure with the background color.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputbackgroundcolor void
		// VideoProcessorGetOutputBackgroundColor( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pYCbCr, [out] D3D11_VIDEO_COLOR
		// *pColor );
		[PreserveSig]
		void VideoProcessorGetOutputBackgroundColor([In] ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);

		/// <summary>Gets the current output color space for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pColorSpace">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure. The method fills in the structure with the output color space.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputcolorspace void
		// VideoProcessorGetOutputColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [out] D3D11_VIDEO_PROCESSOR_COLOR_SPACE
		// *pColorSpace );
		[PreserveSig]
		void VideoProcessorGetOutputColorSpace([In] ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Gets the current alpha fill mode for the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pAlphaFillMode">Receives the alpha fill mode, as a D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE value.</param>
		/// <param name="pStreamIndex">
		/// If the alpha fill mode is <c>D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE_SOURCE_STREAM</c>, this parameter receives the zero-based
		/// index of an input stream. The input stream provides the alpha values for the alpha fill.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputalphafillmode void
		// VideoProcessorGetOutputAlphaFillMode( [in] ID3D11VideoProcessor *pVideoProcessor, [out] D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE
		// *pAlphaFillMode, [out] UINT *pStreamIndex );
		[PreserveSig]
		void VideoProcessorGetOutputAlphaFillMode([In] ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);

		/// <summary>Gets the current level of downsampling that is performed by the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pEnabled">
		/// Receives the value <c>TRUE</c> if downsampling was explicitly enabled using the
		/// ID3D11VideoContext::VideoProcessorSetOutputConstriction method. Receives the value <c>FALSE</c> if the downsampling was disabled
		/// or was never set.
		/// </param>
		/// <param name="pSize">
		/// If <c>Enabled</c> receives the value <c>TRUE</c>, this parameter receives the downsampling size. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputconstriction void
		// VideoProcessorGetOutputConstriction( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pEnabled, [out] SIZE *pSize );
		[PreserveSig]
		void VideoProcessorGetOutputConstriction([In] ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out SIZE pSize);

		/// <summary>Queries whether the video processor produces stereo video frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if stereo output is enabled, or <c>FALSE</c> otherwise.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputstereomode void
		// VideoProcessorGetOutputStereoMode( [in] ID3D11VideoProcessor *pVideoProcessor, [out] BOOL *pEnabled );
		[PreserveSig]
		void VideoProcessorGetOutputStereoMode([In] ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);

		/// <summary>Gets private state data from the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the state. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">A pointer to a buffer that receives the private state data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetoutputextension
		// APP_DEPRECATED_HRESULT VideoProcessorGetOutputExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] const GUID
		// *pExtensionGuid, [in] UINT DataSize, [out] void *pData );
		[PreserveSig]
		int VideoProcessorGetOutputExtension([In] ID3D11VideoProcessor pVideoProcessor, in Guid pExtensionGuid, uint DataSize, [Out] IntPtr pData);

		/// <summary>Specifies whether an input stream on the video processor contains interlaced or progressive frames.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="FrameFormat">A D3D11_VIDEO_FRAME_FORMAT value that specifies the interlacing.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamframeformat void
		// VideoProcessorSetStreamFrameFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, D3D11_VIDEO_FRAME_FORMAT
		// FrameFormat );
		[PreserveSig]
		void VideoProcessorSetStreamFrameFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);

		/// <summary>Sets the color space for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pColorSpace">A pointer to a D3D11_VIDEO_PROCESSOR_COLOR_SPACE structure that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamcolorspace void
		// VideoProcessorSetStreamColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] const
		// D3D11_VIDEO_PROCESSOR_COLOR_SPACE *pColorSpace );
		[PreserveSig]
		void VideoProcessorSetStreamColorSpace([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Sets the rate at which the video processor produces output frames for an input stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="OutputRate">The output rate, specified as a D3D11_VIDEO_PROCESSOR_OUTPUT_RATE value.</param>
		/// <param name="RepeatFrame">
		/// <para>Specifies how the driver performs frame-rate conversion, if required.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Repeat frames.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Interpolate frames.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pCustomRate">
		/// A pointer to a DXGI_RATIONAL structure. If <c>OutputRate</c> is <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM</c>, this parameter
		/// specifies the exact output rate. Otherwise, this parameter is ignored and can be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The standard output rates are normal frame-rate ( <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_NORMAL</c>) and half frame-rate (
		/// <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_HALF</c>). In addition, the driver might support custom rates for rate conversion or
		/// inverse telecine. To get the list of custom rates, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCustomRate.
		/// </para>
		/// <para>
		/// Depending on the output rate, the driver might need to convert the frame rate. If so, the value of <c>RepeatFrame</c> controls
		/// whether the driver creates interpolated frames or simply repeats input frames.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamoutputrate void
		// VideoProcessorSetStreamOutputRate( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, [in] BOOL RepeatFrame, [in] const DXGI_RATIONAL *pCustomRate );
		[PreserveSig]
		void VideoProcessorSetStreamOutputRate([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate,
			bool RepeatFrame, [Optional] in DXGI_RATIONAL pCustomRate);

		/// <summary>Sets the source rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether to apply the source rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the source rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The source rectangle is the portion of the input surface that is blitted to the destination surface. The source rectangle is
		/// given in pixel coordinates, relative to the input surface.
		/// </para>
		/// <para>
		/// If this method is never called, or if the <c>Enable</c> parameter is <c>FALSE</c>, the video processor reads from the entire
		/// input surface.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamsourcerect void
		// VideoProcessorSetStreamSourceRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in]
		// const RECT *pRect );
		[PreserveSig]
		void VideoProcessorSetStreamSourceRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, [Optional] in RECT pRect);

		/// <summary>Sets the destination rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether to apply the destination rectangle.</param>
		/// <param name="pRect">
		/// A pointer to a RECT structure that specifies the destination rectangle. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The destination rectangle is the portion of the output surface that receives the blit for this stream. The destination rectangle
		/// is given in pixel coordinates, relative to the output surface.
		/// </para>
		/// <para>
		/// The default destination rectangle is an empty rectangle (0, 0, 0, 0). If this method is never called, or if the <c>Enable</c>
		/// parameter is <c>FALSE</c>, no data is written from this stream.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamdestrect void
		// VideoProcessorSetStreamDestRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] const
		// RECT *pRect );
		[PreserveSig]
		void VideoProcessorSetStreamDestRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, [Optional] in RECT pRect);

		/// <summary>Sets the planar alpha for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether alpha blending is enabled.</param>
		/// <param name="Alpha">
		/// The planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque). If <c>Enable</c> is <c>FALSE</c>, this
		/// parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use this feature, the driver must support stereo video, indicated by the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALHPA_STREAM
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// <para>Alpha blending is disabled by default.</para>
		/// <para>For each pixel, the destination color value is computed as follows:</para>
		/// <para>where:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>= The color value of the destination pixel</description>
		/// </item>
		/// <item>
		/// <description>= The color value of the source pixel</description>
		/// </item>
		/// <item>
		/// <description>= The per-pixel source alpha</description>
		/// </item>
		/// <item>
		/// <description>= The planar alpha value</description>
		/// </item>
		/// <item>
		/// <description>= The palette-entry alpha value, or 1.0 (see Note)</description>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c>  Palette-entry alpha values apply only to palettized color formats, and only when the device supports the
		/// <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE</c> capability. Otherwise, this factor equals 1.0.
		/// </para>
		/// <para></para>
		/// <para>The destination alpha value is computed according to the alpha fill mode. For more information, see ID3D11VideoContext::VideoProcessorSetOutputAlphaFillMode.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamalpha void
		// VideoProcessorSetStreamAlpha( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] FLOAT
		// Alpha );
		[PreserveSig]
		void VideoProcessorSetStreamAlpha([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);

		/// <summary>Sets the color-palette entries for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Count">The number of elements in the <c>pEntries</c> array.</param>
		/// <param name="pEntries">
		/// A pointer to an array of palette entries. For RGB streams, the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c>
		/// representation. For YCbCr streams, the palette entries use the <c>DXGI_FORMAT_AYUV</c> representation. The caller allocates the array.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method applies only to input streams that have a palettized color format. Palettized formats with 4 bits per pixel (bpp)
		/// use the first 16 entries in the list. Formats with 8 bpp use the first 256 entries.
		/// </para>
		/// <para>
		/// If a pixel has a palette index greater than the number of entries, the device treats the pixel as white with opaque alpha. For
		/// full-range RGB, this value is (255, 255, 255, 255); for YCbCr the value is (255, 235, 128, 128).
		/// </para>
		/// <para>
		/// If the driver does not report the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ALPHA_PALETTE</c> capability flag, every palette entry
		/// must have an alpha value of 0xFF (opaque). To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreampalette void
		// VideoProcessorSetStreamPalette( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] UINT Count, [in] const
		// UINT *pEntries );
		[PreserveSig]
		void VideoProcessorSetStreamPalette([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		/// <summary>Sets the pixel aspect ratio for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// Specifies whether the <c>pSourceAspectRatio</c> and <c>pDestinationAspectRatio</c> parameters contain valid values. Otherwise,
		/// the pixel aspect ratios are unspecified.
		/// </param>
		/// <param name="pSourceAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure that contains the pixel aspect ratio of the source rectangle. If <c>Enable</c> is
		/// <c>FALSE</c>, this parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pDestinationAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure that contains the pixel aspect ratio of the destination rectangle. If <c>Enable</c> is
		/// <c>FALSE</c>, this parameter can be <c>NULL</c>.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This function can only be called if the driver reports the D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_PIXEL_ASPECT_RATIO capability. If
		/// this capability is not set, this function will have no effect.
		/// </para>
		/// <para>Pixel aspect ratios of the form 0/n and n/0 are not valid.</para>
		/// <para>The default pixel aspect ratio is 1:1 (square pixels).</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreampixelaspectratio
		// void VideoProcessorSetStreamPixelAspectRatio( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL
		// Enable, [in] const DXGI_RATIONAL *pSourceAspectRatio, [in] const DXGI_RATIONAL *pDestinationAspectRatio );
		[PreserveSig]
		void VideoProcessorSetStreamPixelAspectRatio([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable,
			[Optional] in DXGI_RATIONAL pSourceAspectRatio, [Optional] in DXGI_RATIONAL pDestinationAspectRatio);

		/// <summary>Sets the luma key for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies whether luma keying is enabled.</param>
		/// <param name="Lower">
		/// The lower bound for the luma key. The valid range is [0…1]. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <param name="Upper">
		/// The upper bound for the luma key. The valid range is [0…1]. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// To use this feature, the driver must support luma keying, indicated by the <c>D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_LUMA_KEY</c>
		/// capability flag. To query for this capability, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps. In addition, if the
		/// input format is RGB, the device must support the <c>D3D11_VIDEO_PROCESSOR_FORMAT_CAPS_RGB_LUMA_KEY</c> capability.
		/// </para>
		/// <para>
		/// The values of <c>Lower</c> and <c>Upper</c> give the lower and upper bounds of the luma key, using a nominal range of [0...1].
		/// Given a format with <c>n</c> bits per channel, these values are converted to luma values as follows:
		/// </para>
		/// <para>Any pixel whose luma value falls within the upper and lower bounds (inclusive) is treated as transparent.</para>
		/// <para>For example, if the pixel format uses 8-bit luma, the upper bound is calculated as follows:</para>
		/// <para>Note that the value is clamped to the range [0...1] before multiplying by 255.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamlumakey void
		// VideoProcessorSetStreamLumaKey( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in] FLOAT
		// Lower, [in] FLOAT Upper );
		[PreserveSig]
		void VideoProcessorSetStreamLumaKey([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);

		/// <summary>
		/// Enables or disables stereo 3D video for an input stream on the video processor. In addition, this method specifies the layout of
		/// the video frames in memory.
		/// </summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// Specifies whether stereo 3D is enabled for this stream. If the value is <c>FALSE</c>, the remaining parameters of this method
		/// are ignored.
		/// </param>
		/// <param name="Format">Specifies the layout of the two stereo views in memory, as a D3D11_VIDEO_PROCESSOR_STEREO_FORMAT value.</param>
		/// <param name="LeftViewFrame0">
		/// <para>If <c>TRUE</c>, frame 0 contains the left view. Otherwise, frame 0 contains the right view.</para>
		/// <para>This parameter is ignored for the following stereo formats:</para>
		/// <list type="bullet">
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO</c></item>
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c></item>
		/// </list>
		/// </param>
		/// <param name="BaseViewFrame0">
		/// <para>If <c>TRUE</c>, frame 0 contains the base view. Otherwise, frame 1 contains the base view.</para>
		/// <para>This parameter is ignored for the following stereo formats:</para>
		/// <list type="bullet">
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO</c></item>
		/// <item><c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c></item>
		/// <item>
		/// When <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_SEPARATE</c> is used and the application wants to convert the stereo data to mono,
		/// it can either:
		/// </item>
		/// </list>
		/// </param>
		/// <param name="FlipMode">
		/// A flag from the D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE enumeration, specifying whether one of the views is flipped.
		/// </param>
		/// <param name="MonoOffset">
		/// <para>
		/// For <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c> format, this parameter specifies how to generate the left and right views:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// If <c>MonoOffset</c> is positive, the right view is shifted to the right by that many pixels, and the left view is shifted to
		/// the left by the same amount.
		/// </item>
		/// <item>
		/// If <c>MonoOffset</c> is negative, the right view is shifted to the left by that many pixels, and the left view is shifted to
		/// right by the same amount.
		/// </item>
		/// </list>
		/// <para>If Format is not D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET, this parameter must be zero.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamstereoformat void
		// VideoProcessorSetStreamStereoFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL Enable, [in]
		// D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, [in] BOOL LeftViewFrame0, [in] BOOL BaseViewFrame0, [in]
		// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, [in] int MonoOffset );
		[PreserveSig]
		void VideoProcessorSetStreamStereoFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format,
			bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);

		/// <summary>Enables or disables automatic processing features on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">
		/// If <c>TRUE</c>, automatic processing features are enabled. If <c>FALSE</c>, the driver disables any extra video processing that
		/// it might be performing.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// By default, the driver might perform certain processing tasks automatically during the video processor blit. This method enables
		/// the application to disable these extra video processing features. For example, if you provide your own pixel shader for the
		/// video processor, you might want to disable the driver's automatic processing.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamautoprocessingmode
		// void VideoProcessorSetStreamAutoProcessingMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] BOOL
		// Enable );
		[PreserveSig]
		void VideoProcessorSetStreamAutoProcessingMode([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);

		/// <summary>Enables or disables an image filter for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Filter">
		/// <para>The filter, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</para>
		/// <para>To query which filters the driver supports, call ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps.</para>
		/// </param>
		/// <param name="Enable">Specifies whether to enable the filter.</param>
		/// <param name="Level">
		/// <para>The filter level. If <c>Enable</c> is <c>FALSE</c>, this parameter is ignored.</para>
		/// <para>To find the valid range of levels for a specified filter, call ID3D11VideoProcessorEnumerator::GetVideoProcessorFilterRange.</para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamfilter void
		// VideoProcessorSetStreamFilter( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_FILTER Filter, [in] BOOL Enable, [in] int Level );
		[PreserveSig]
		void VideoProcessorSetStreamFilter([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);

		/// <summary>Sets a driver-specific state on a video processing stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the operation. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a buffer that contains private state data. The method passes this buffer directly to the driver without validation.
		/// It is the responsibility of the driver to validate the data.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamextension
		// APP_DEPRECATED_HRESULT VideoProcessorSetStreamExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// const GUID *pExtensionGuid, [in] UINT DataSize, [in] void *pData );
		[PreserveSig]
		int VideoProcessorSetStreamExtension([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in Guid pExtensionGuid, uint DataSize, [In] IntPtr pData);

		/// <summary>Gets the format of an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pFrameFormat">
		/// Receives a D3D11_VIDEO_FRAME_FORMAT value that specifies whether the stream contains interlaced or progressive frames.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamframeformat void
		// VideoProcessorGetStreamFrameFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// D3D11_VIDEO_FRAME_FORMAT *pFrameFormat );
		[PreserveSig]
		void VideoProcessorGetStreamFrameFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);

		/// <summary>Gets the color space for an input stream of the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pColorSpace">Receives a D3D11_VIDEO_PROCESSOR_COLOR_SPACE value that specifies the color space.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamcolorspace void
		// VideoProcessorGetStreamColorSpace( [in] ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, [out]
		// D3D11_VIDEO_PROCESSOR_COLOR_SPACE *pColorSpace );
		[PreserveSig]
		void VideoProcessorGetStreamColorSpace([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		/// <summary>Gets the rate at which the video processor produces output frames for an input stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pOutputRate">Receives a D3D11_VIDEO_PROCESSOR_OUTPUT_RATE value that specifies the output rate.</param>
		/// <param name="pRepeatFrame">
		/// <para>Receives a Boolean value that specifies how the driver performs frame-rate conversion, if required.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Repeat frames.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Interpolate frames.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pCustomRate">
		/// A pointer to a DXGI_RATIONAL structure. If the output rate is <c>D3D11_VIDEO_PROCESSOR_OUTPUT_RATE_CUSTOM</c>, the method fills
		/// in this structure with the exact output rate. Otherwise, this parameter is ignored.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamoutputrate void
		// VideoProcessorGetStreamOutputRate( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_RATE *pOutputRate, [out] BOOL *pRepeatFrame, [out] DXGI_RATIONAL *pCustomRate );
		[PreserveSig]
		void VideoProcessorGetStreamOutputRate([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate,
			out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);

		/// <summary>Gets the source rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the source rectangle is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pRect">A pointer to a RECT structure that receives the source rectangle.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamsourcerect void
		// VideoProcessorGetStreamSourceRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// RECT *pRect );
		[PreserveSig]
		void VideoProcessorGetStreamSourceRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		/// <summary>Gets the destination rectangle for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the destination rectangle is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pRect">A pointer to a RECT structure that receives the destination rectangle.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamdestrect void
		// VideoProcessorGetStreamDestRect( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// RECT *pRect );
		[PreserveSig]
		void VideoProcessorGetStreamDestRect([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		/// <summary>Gets the planar alpha for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if planar alpha is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pAlpha">Receives the planar alpha value. The value can range from 0.0 (transparent) to 1.0 (opaque).</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamalpha void
		// VideoProcessorGetStreamAlpha( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// FLOAT *pAlpha );
		[PreserveSig]
		void VideoProcessorGetStreamAlpha([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);

		/// <summary>Gets the color-palette entries for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Count">The number of entries in the <c>pEntries</c> array.</param>
		/// <param name="pEntries">
		/// A pointer to a <c>UINT</c> array allocated by the caller. The method fills the array with the palette entries. For RGB streams,
		/// the palette entries use the <c>DXGI_FORMAT_B8G8R8A8</c> representation. For YCbCr streams, the palette entries use the
		/// <c>DXGI_FORMAT_AYUV</c> representation.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method applies only to input streams that have a palettized color format. Palettized formats with 4 bits per pixel (bpp)
		/// use 16 palette entries. Formats with 8 bpp use 256 entries.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreampalette void
		// VideoProcessorGetStreamPalette( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in] UINT Count, [out] UINT
		// *pEntries );
		[PreserveSig]
		void VideoProcessorGetStreamPalette([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		/// <summary>Gets the pixel aspect ratio for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">
		/// Receives the value <c>TRUE</c> if the pixel aspect ratio is specified. Otherwise, receives the value <c>FALSE</c>.
		/// </param>
		/// <param name="pSourceAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure. If * <c>pEnabled</c> is <c>TRUE</c>, this parameter receives the pixel aspect ratio of
		/// the source rectangle.
		/// </param>
		/// <param name="pDestinationAspectRatio">
		/// A pointer to a DXGI_RATIONAL structure. If * <c>pEnabled</c> is <c>TRUE</c>, this parameter receives the pixel aspect ratio of
		/// the destination rectangle.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When the method returns, if <c>*pEnabled</c> is <c>TRUE</c>, the <c>pSourceAspectRatio</c> and <c>pDestinationAspectRatio</c>
		/// parameters contain the pixel aspect ratios. Otherwise, the default pixel aspect ratio is 1:1 (square pixels).
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreampixelaspectratio
		// void VideoProcessorGetStreamPixelAspectRatio( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL
		// *pEnabled, [out] DXGI_RATIONAL *pSourceAspectRatio, [out] DXGI_RATIONAL *pDestinationAspectRatio );
		[PreserveSig]
		void VideoProcessorGetStreamPixelAspectRatio([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled,
			out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);

		/// <summary>Gets the luma key for an input stream of the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if luma keying is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pLower">Receives the lower bound for the luma key. The valid range is [0…1].</param>
		/// <param name="pUpper">Receives the upper bound for the luma key. The valid range is [0…1].</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamlumakey void
		// VideoProcessorGetStreamLumaKey( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnabled, [out]
		// FLOAT *pLower, [out] FLOAT *pUpper );
		[PreserveSig]
		void VideoProcessorGetStreamLumaKey([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);

		/// <summary>Gets the stereo 3D format for an input stream on the video processor</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnable">
		/// Receives the value <c>TRUE</c> if stereo 3D is enabled for this stream, or <c>FALSE</c> otherwise. If the value is <c>FALSE</c>,
		/// ignore the remaining parameters.
		/// </param>
		/// <param name="pFormat">
		/// Receives a D3D11_VIDEO_PROCESSOR_STEREO_FORMAT value that specifies the layout of the two stereo views in memory.
		/// </param>
		/// <param name="pLeftViewFrame0">
		/// <para>Receives a Boolean value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Frame 0 contains the left view.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Frame 0 contains the right view.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBaseViewFrame0">
		/// <para>Receives a Boolean value.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>TRUE</c></description>
		/// <description>Frame 0 contains the base view.</description>
		/// </item>
		/// <item>
		/// <description><c>FALSE</c></description>
		/// <description>Frame 1 contains the base view.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pFlipMode">
		/// Receives a D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE value. This value specifies whether one of the views is flipped.
		/// </param>
		/// <param name="MonoOffset">
		/// Receives the pixel offset used for <c>D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO_OFFSET</c> format. This parameter is ignored for
		/// other stereo formats.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamstereoformat void
		// VideoProcessorGetStreamStereoFormat( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL *pEnable,
		// [out] D3D11_VIDEO_PROCESSOR_STEREO_FORMAT *pFormat, [out] BOOL *pLeftViewFrame0, [out] BOOL *pBaseViewFrame0, [out]
		// D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE *pFlipMode, [out] int *MonoOffset );
		[PreserveSig]
		void VideoProcessorGetStreamStereoFormat([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable,
			out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0,
			out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);

		/// <summary>Queries whether automatic processing features of the video processor are enabled.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if automatic processing features are enabled, or <c>FALSE</c> otherwise.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// Automatic processing refers to additional image processing that drivers might have performed on the image data prior to the
		/// application receiving the data.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamautoprocessingmode
		// void VideoProcessorGetStreamAutoProcessingMode( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [out] BOOL
		// *pEnabled );
		[PreserveSig]
		void VideoProcessorGetStreamAutoProcessingMode([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);

		/// <summary>Gets the image filter settings for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Filter">The filter to query, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</param>
		/// <param name="pEnabled">Receives the value <c>TRUE</c> if the image filter is enabled, or <c>FALSE</c> otherwise.</param>
		/// <param name="pLevel">Receives the filter level.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamfilter void
		// VideoProcessorGetStreamFilter( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// D3D11_VIDEO_PROCESSOR_FILTER Filter, [out] BOOL *pEnabled, [out] int *pLevel );
		[PreserveSig]
		void VideoProcessorGetStreamFilter([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);

		/// <summary>Gets a driver-specific state for a video processing stream.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pExtensionGuid">
		/// A pointer to a GUID that identifies the state. The meaning of this GUID is defined by the graphics driver.
		/// </param>
		/// <param name="DataSize">The size of the <c>pData</c> buffer, in bytes.</param>
		/// <param name="pData">A pointer to a buffer that receives the private state data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamextension
		// APP_DEPRECATED_HRESULT VideoProcessorGetStreamExtension( [in] ID3D11VideoProcessor *pVideoProcessor, [in] UINT StreamIndex, [in]
		// const GUID *pExtensionGuid, [in] UINT DataSize, [out] void *pData );
		[PreserveSig]
		int VideoProcessorGetStreamExtension([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, in Guid pExtensionGuid, uint DataSize, [Out] IntPtr pData);

		/// <summary>Performs a video processing operation on one or more input samples, and writes the result to a Direct3D surface.</summary>
		/// <param name="pVideoProcessor">
		/// A pointer to the ID3D11VideoProcessor interface. To get this pointer, call the ID3D11VideoDevice::CreateVideoProcessor method.
		/// </param>
		/// <param name="pView">
		/// A pointer to the ID3D11VideoProcessorOutputView interface for the output surface. The output of the video processing operation
		/// will be written to this surface.
		/// </param>
		/// <param name="OutputFrame">The frame number of the output video frame, indexed from zero.</param>
		/// <param name="StreamCount">The number of input streams to process.</param>
		/// <param name="pStreams">
		/// A pointer to an array of D3D11_VIDEO_PROCESSOR_STREAM structures that contain information about the input streams. The caller
		/// allocates the array and fills in each structure. The number of elements in the array is given in the StreamCount parameter.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// The maximum value of <c>StreamCount</c> is given in the <c>MaxStreamStates</c> member of the D3D11_VIDEO_PROCESSOR_CAPS
		/// structure. The maximum number of streams that can be enabled at one time is given in the <c>MaxInputStreams</c> member of that structure.
		/// </para>
		/// <para>If the output stereo mode is <c>TRUE</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The output view must contain a texture array of two elements.</description>
		/// </item>
		/// <item>
		/// <description>At least one stereo stream must be specified.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If multiple input streams are enabled, it is possible that one or more of the input streams may contain mono data.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Otherwise:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The output view must contain a single element.</description>
		/// </item>
		/// <item>
		/// <description>The stereo format cannot be D3D11_VIDEO_PROCESSOR_STEREO_FORMAT_MONO .</description>
		/// </item>
		/// </list>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorblt HRESULT
		// VideoProcessorBlt( [in] ID3D11VideoProcessor *pVideoProcessor, [in] ID3D11VideoProcessorOutputView *pView, [in] UINT OutputFrame,
		// [in] UINT StreamCount, [in] const D3D11_VIDEO_PROCESSOR_STREAM *pStreams );
		[PreserveSig]
		HRESULT VideoProcessorBlt([In] ID3D11VideoProcessor pVideoProcessor, [In] ID3D11VideoProcessorOutputView pView, uint OutputFrame,
			int StreamCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams);

		/// <summary>Establishes the session key for a cryptographic session.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface of the cryptographic session.</param>
		/// <param name="DataSize">The size of the <c>pData</c> byte array, in bytes.</param>
		/// <param name="pData">A pointer to a byte array that contains the encrypted session key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>The key exchange mechanism depends on the type of cryptographic session.</para>
		/// <para>
		/// For RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP), the software decoder generates the secret key,
		/// encrypts the secret key by using the public key with RSAES-OAEP, and places the cipher text in the <c>pData</c> parameter. The
		/// actual size of the buffer for RSAES-OAEP is 256 bytes.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-negotiatecryptosessionkeyexchange HRESULT
		// NegotiateCryptoSessionKeyExchange( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT DataSize, [in, out] void *pData );
		[PreserveSig]
		HRESULT NegotiateCryptoSessionKeyExchange([In] ID3D11CryptoSession pCryptoSession, uint DataSize, [In, Out] IntPtr pData);

		/// <summary>Reads encrypted data from a protected surface.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface of the cryptographic session.</param>
		/// <param name="pSrcSurface">A pointer to the ID3D11Texture2D interface of the protected surface.</param>
		/// <param name="pDstSurface">A pointer to the ID3D11Texture2D interface of the surface that receives the encrypted data.</param>
		/// <param name="IVSize">The size of the <c>pIV</c> buffer, in bytes.</param>
		/// <param name="pIV">
		/// <para>
		/// A pointer to a buffer that receives the initialization vector (IV). The caller allocates this buffer, but the driver generates
		/// the IV.
		/// </para>
		/// <para>
		/// For 128-bit AES-CTR encryption, <c>pIV</c> points to a D3D11_AES_CTR_IV structure. When the driver generates the first IV, it
		/// initializes the structure to a random number. For each subsequent IV, the driver simply increments the <c>IV</c> member of the
		/// structure, ensuring that the value always increases. The application can validate that the same IV is never used more than once
		/// with the same key pair.
		/// </para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Not all drivers support this method. To query the driver capabilities, call ID3D11VideoDevice::GetContentProtectionCaps and
		/// check for the <c>D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK</c> flag in the <c>Caps</c> member of the
		/// D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure.
		/// </para>
		/// <para>
		/// Some drivers might require a separate key to decrypt the data that is read back. To check for this requirement, call
		/// GetContentProtectionCaps and check for the <c>D3D11_CONTENT_PROTECTION_CAPS_ENCRYPTED_READ_BACK_KEY</c> flag. If this flag is
		/// present, call ID3D11VideoContext::GetEncryptionBltKey to get the decryption key.
		/// </para>
		/// <para>This method has the following limitations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Reading back sub-rectangles is not supported.</description>
		/// </item>
		/// <item>
		/// <description>Reading back partially encrypted surfaces is not supported.</description>
		/// </item>
		/// <item>
		/// <description>The protected surface must be either an off-screen plain surface or a render target.</description>
		/// </item>
		/// <item>
		/// <description>The destination surface must be a D3D11_USAGE_STAGING resource.</description>
		/// </item>
		/// <item>
		/// <description>The protected surface cannot be multisampled.</description>
		/// </item>
		/// <item>
		/// <description>Stretching and colorspace conversion are not supported.</description>
		/// </item>
		/// </list>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-encryptionblt void EncryptionBlt( [in]
		// ID3D11CryptoSession *pCryptoSession, [in] ID3D11Texture2D *pSrcSurface, [in] ID3D11Texture2D *pDstSurface, [in] UINT IVSize, [in]
		// void *pIV );
		[PreserveSig]
		void EncryptionBlt([In] ID3D11CryptoSession pCryptoSession, [In] ID3D11Texture2D pSrcSurface, [In] ID3D11Texture2D pDstSurface, uint IVSize, [In] IntPtr pIV);

		/// <summary>Writes encrypted data to a protected surface.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="pSrcSurface">A pointer to the surface that contains the source data.</param>
		/// <param name="pDstSurface">A pointer to the protected surface where the encrypted data is written.</param>
		/// <param name="pEncryptedBlockInfo">
		/// <para>A pointer to a D3D11_ENCRYPTED_BLOCK_INFO structure, or <c>NULL</c>.</para>
		/// <para>
		/// If the driver supports partially encrypted buffers, <c>pEncryptedBlockInfo</c> indicates which portions of the buffer are
		/// encrypted. If the entire surface is encrypted, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para>
		/// To check whether the driver supports partially encrypted buffers, call ID3D11VideoDevice::GetContentProtectionCaps and check for
		/// the <c>D3D11_CONTENT_PROTECTION_CAPS_PARTIAL_DECRYPTION</c> capabilities flag. If the driver does not support partially
		/// encrypted buffers, set this parameter to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="ContentKeySize">The size of the encrypted content key, in bytes.</param>
		/// <param name="pContentKey">
		/// <para>
		/// A pointer to a buffer that contains a content encryption key, or <c>NULL</c>. To query whether the driver supports the use of
		/// content keys, call ID3D11VideoDevice::GetContentProtectionCaps and check for the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_CONTENT_KEY</c> capabilities flag.
		/// </para>
		/// <para>
		/// If the driver supports content keys, use the content key to encrypt the surface. Encrypt the content key using the session key,
		/// and place the resulting cipher text in <c>pContentKey</c>. If the driver does not support content keys, use the session key to
		/// encrypt the surface and set <c>pContentKey</c> to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="IVSize">The size of the <c>pIV</c> buffer, in bytes.</param>
		/// <param name="pIV">
		/// <para>A pointer to a buffer that contains the initialization vector (IV).</para>
		/// <para>
		/// For 128-bit AES-CTR encryption, <c>pIV</c> points to a D3D11_AES_CTR_IV structure. The caller allocates the structure and
		/// generates the IV. When you generate the first IV, initialize the structure to a random number. For each subsequent IV, simply
		/// increment the <c>IV</c> member of the structure, ensuring that the value always increases. This procedure enables the driver to
		/// validate that the same IV is never used more than once with the same key pair.
		/// </para>
		/// <para>For other encryption types, a different structure might be used, or the encryption might not use an IV.</para>
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Not all hardware or drivers support this functionality for all cryptographic types. This function can only be called when the
		/// D3D11_CONTENT_PROTECTION_CAPS_DECRYPTION_BLT cap is reported.
		/// </para>
		/// <para>This method does not support writing to sub-rectangles of the surface.</para>
		/// <para>If the hardware and driver support a content key:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>The data is encrypted by the caller using the content key.</description>
		/// </item>
		/// <item>
		/// <description>The content key is encrypted by the caller using the session key.</description>
		/// </item>
		/// <item>
		/// <description>The encrypted content key is passed to the driver.</description>
		/// </item>
		/// </list>
		/// <para>Otherwise, the data is encrypted by the caller using the session key and NULL is passed as the content key.</para>
		/// <para>
		/// If the driver and hardware support partially encrypted buffers, <c>pEncryptedBlockInfo</c> indicates which portions of the
		/// buffer are encrypted and which is not. If the entire buffer is encrypted, <c>pEncryptedBlockinfo</c> should be <c>NULL</c>.
		/// </para>
		/// <para>
		/// The D3D11_ENCRYPTED_BLOCK_INFO allows the application to indicate which bytes in the buffer are encrypted. This is specified in
		/// bytes, so the application must ensure that the encrypted blocks match the GPU’s crypto block alignment.
		/// </para>
		/// <para>This function does not honor a D3D11 predicate that may have been set.</para>
		/// <para>
		/// If the application uses D3D11 queries, this function may not be accounted for with <c>D3D11_QUERY_EVENT</c> and
		/// <c>D3D11_QUERY_TIMESTAMP</c> when using feature levels lower than 11. <c>D3D11_QUERY_PIPELINE_STATISTICS</c> will not include
		/// this function for any feature level.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-decryptionblt void DecryptionBlt( [in]
		// ID3D11CryptoSession *pCryptoSession, [in] ID3D11Texture2D *pSrcSurface, [in] ID3D11Texture2D *pDstSurface, [in]
		// D3D11_ENCRYPTED_BLOCK_INFO *pEncryptedBlockInfo, [in] UINT ContentKeySize, [in] const void *pContentKey, [in] UINT IVSize, [in]
		// void *pIV );
		[PreserveSig]
		void DecryptionBlt([In] ID3D11CryptoSession pCryptoSession, [In] ID3D11Texture2D pSrcSurface, [In] ID3D11Texture2D pDstSurface,
			in D3D11_ENCRYPTED_BLOCK_INFO pEncryptedBlockInfo, uint ContentKeySize, [In] IntPtr pContentKey, uint IVSize, [In] IntPtr pIV);

		/// <summary>Gets a random number that can be used to refresh the session key.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="RandomNumberSize">
		/// The size of the <c>pRandomNumber</c> array, in bytes. The size should match the size of the session key.
		/// </param>
		/// <param name="pRandomNumber">A pointer to a byte array that receives a random number.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// To generate a new session key, perform a bitwise <c>XOR</c> between the previous session key and the random number. The new
		/// session key does not take affect until the application calls ID3D11VideoContext::FinishSessionKeyRefresh.
		/// </para>
		/// <para>
		/// To query whether the driver supports this method, call ID3D11VideoDevice::GetContentProtectionCaps and check for the
		/// <c>D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY</c> capabilities flag.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-startsessionkeyrefresh void
		// StartSessionKeyRefresh( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT RandomNumberSize, [out] void *pRandomNumber );
		[PreserveSig]
		void StartSessionKeyRefresh([In] ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, [Out] IntPtr pRandomNumber);

		/// <summary>Switches to a new session key.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This function can only be called when the D3D11_CONTENT_PROTECTION_CAPS_FRESHEN_SESSION_KEY cap is reported.</para>
		/// <para>
		/// Before calling this method, call ID3D11VideoContext::StartSessionKeyRefresh. The <c>StartSessionKeyRefresh</c> method gets a
		/// random number from the driver, which is used to create a new session key. The new session key does not become active until the
		/// application calls <c>FinishSessionKeyRefresh</c>. After the application calls <c>FinishSessionKeyRefresh</c>, all protected
		/// surfaces are encrypted using the new session key.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-finishsessionkeyrefresh void
		// FinishSessionKeyRefresh( [in] ID3D11CryptoSession *pCryptoSession );
		[PreserveSig]
		void FinishSessionKeyRefresh([In] ID3D11CryptoSession pCryptoSession);

		/// <summary>Gets the cryptographic key to decrypt the data returned by the ID3D11VideoContext::EncryptionBlt method.</summary>
		/// <param name="pCryptoSession">A pointer to the ID3D11CryptoSession interface.</param>
		/// <param name="KeySize">The size of the <c>pReadbackKey</c> array, in bytes. The size should match the size of the session key.</param>
		/// <param name="pReadbackKey">A pointer to a byte array that receives the key. The key is encrypted using the session key.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// This method applies only when the driver requires a separate content key for the EncryptionBlt method. For more information, see
		/// the Remarks for <c>EncryptionBlt</c>.
		/// </para>
		/// <para>Each time this method is called, the driver generates a new key.</para>
		/// <para>The <c>KeySize</c> should match the size of the session key.</para>
		/// <para>The read back key is encrypted by the driver/hardware using the session key.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-getencryptionbltkey HRESULT
		// GetEncryptionBltKey( [in] ID3D11CryptoSession *pCryptoSession, [in] UINT KeySize, [out] void *pReadbackKey );
		[PreserveSig]
		HRESULT GetEncryptionBltKey([In] ID3D11CryptoSession pCryptoSession, uint KeySize, [Out] IntPtr pReadbackKey);

		/// <summary>Establishes a session key for an authenticated channel.</summary>
		/// <param name="pChannel">
		/// A pointer to the ID3D11AuthenticatedChannel interface. This method will fail if the channel type is
		/// D3D11_AUTHENTICATED_CHANNEL_D3D11, because the Direct3D11 channel does not support authentication.
		/// </param>
		/// <param name="DataSize">The size of the data in the <c>pData</c> array, in bytes.</param>
		/// <param name="pData">
		/// A pointer to a byte array that contains the encrypted session key. The buffer must contain 256 bytes of data, encrypted using
		/// RSA Encryption Scheme - Optimal Asymmetric Encryption Padding (RSAES-OAEP).
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// This method will fail if the channel type is D3D11_AUTHENTICATED_CHANNEL_D3D11, because the Direct3D11 channel does not support authentication.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-negotiateauthenticatedchannelkeyexchange
		// HRESULT NegotiateAuthenticatedChannelKeyExchange( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT DataSize, [in, out] void
		// *pData );
		[PreserveSig]
		HRESULT NegotiateAuthenticatedChannelKeyExchange([In] ID3D11AuthenticatedChannel pChannel, uint DataSize, [In, Out] IntPtr pData);

		/// <summary>Sends a query to an authenticated channel.</summary>
		/// <param name="pChannel">A pointer to the ID3D11AuthenticatedChannel interface.</param>
		/// <param name="InputSize">The size of the <c>pInput</c> array, in bytes.</param>
		/// <param name="pInput">
		/// A pointer to a byte array that contains input data for the query. This array always starts with a
		/// D3D11_AUTHENTICATED_QUERY_INPUT structure. The <c>QueryType</c> member of the structure specifies the query and defines the
		/// meaning of the rest of the array.
		/// </param>
		/// <param name="OutputSize">The size of the <c>pOutput</c> array, in bytes.</param>
		/// <param name="pOutput">
		/// A pointer to a byte array that receives the result of the query. This array always starts with a
		/// D3D11_AUTHENTICATED_QUERY_OUTPUT structure. The meaning of the rest of the array depends on the query.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-queryauthenticatedchannel HRESULT
		// QueryAuthenticatedChannel( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT InputSize, [in] const void *pInput, [in] UINT
		// OutputSize, [out] void *pOutput );
		[PreserveSig]
		HRESULT QueryAuthenticatedChannel([In] ID3D11AuthenticatedChannel pChannel, uint InputSize, [In] IntPtr pInput, uint OutputSize, [Out] IntPtr pOutput);

		/// <summary>Sends a configuration command to an authenticated channel.</summary>
		/// <param name="pChannel">A pointer to the ID3D11AuthenticatedChannel interface.</param>
		/// <param name="InputSize">The size of the <c>pInput</c> array, in bytes.</param>
		/// <param name="pInput">
		/// A pointer to a byte array that contains input data for the command. This buffer always starts with a
		/// D3D11_AUTHENTICATED_CONFIGURE_INPUT structure. The <c>ConfigureType</c> member of the structure specifies the command and
		/// defines the meaning of the rest of the buffer.
		/// </param>
		/// <param name="pOutput">A pointer to a D3D11_AUTHENTICATED_CONFIGURE_OUTPUT structure that receives the response to the command.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-configureauthenticatedchannel HRESULT
		// ConfigureAuthenticatedChannel( [in] ID3D11AuthenticatedChannel *pChannel, [in] UINT InputSize, [in] const void *pInput, [out]
		// D3D11_AUTHENTICATED_CONFIGURE_OUTPUT *pOutput );
		[PreserveSig]
		HRESULT ConfigureAuthenticatedChannel([In] ID3D11AuthenticatedChannel pChannel, uint InputSize, [In] IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);

		/// <summary>Sets the stream rotation for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="Enable">Specifies if the stream is to be rotated in a clockwise orientation.</param>
		/// <param name="Rotation">Specifies the rotation of the stream.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This is an optional state and the application should only use it if D3D11_VIDEO_PROCESSOR_FEATURE_CAPS_ROTATION is reported in D3D11_VIDEO_PROCESSOR_CAPS.FeatureCaps.
		/// </para>
		/// <para>
		/// The stream source rectangle will be specified in the pre-rotation coordinates (typically landscape) and the stream destination
		/// rectangle will be specified in the post-rotation coordinates (typically portrait). The application must update the stream
		/// destination rectangle correctly when using a rotation value other than 0° and 180°.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorsetstreamrotation void
		// VideoProcessorSetStreamRotation( ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, BOOL Enable,
		// D3D11_VIDEO_PROCESSOR_ROTATION Rotation );
		[PreserveSig]
		void VideoProcessorSetStreamRotation([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);

		/// <summary>Gets the stream rotation for an input stream on the video processor.</summary>
		/// <param name="pVideoProcessor">A pointer to the ID3D11VideoProcessor interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessor.</param>
		/// <param name="StreamIndex">
		/// The zero-based index of the input stream. To get the maximum number of streams, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>MaxStreamStates</c> structure member.
		/// </param>
		/// <param name="pEnable">Specifies if the stream is rotated.</param>
		/// <param name="pRotation">Specifies the rotation of the stream in a clockwise orientation.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videocontext-videoprocessorgetstreamrotation void
		// VideoProcessorGetStreamRotation( ID3D11VideoProcessor *pVideoProcessor, UINT StreamIndex, BOOL *pEnable,
		// D3D11_VIDEO_PROCESSOR_ROTATION *pRotation );
		[PreserveSig]
		void VideoProcessorGetStreamRotation([In] ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);
	}

	/// <summary>Represents a hardware-accelerated video decoder for Microsoft Direct3D 11.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateVideoDecoder.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videodecoder
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoDecoder")]
	[ComImport, Guid("3c9c5b51-995d-48d1-9b8d-fa5caeded65c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoDecoder : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the parameters that were used to create the decoder.</summary>
		/// <param name="pVideoDesc">A pointer to a D3D11_VIDEO_DECODER_DESC structure that receives a description of the video stream.</param>
		/// <param name="pConfig">A pointer to a D3D11_VIDEO_DECODER_CONFIG structure that receives the decoder configuration.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodecoder-getcreationparameters HRESULT
		// GetCreationParameters( [out] D3D11_VIDEO_DECODER_DESC *pVideoDesc, [out] D3D11_VIDEO_DECODER_CONFIG *pConfig );
		[PreserveSig]
		HRESULT GetCreationParameters(out D3D11_VIDEO_DECODER_DESC pVideoDesc, out D3D11_VIDEO_DECODER_CONFIG pConfig);

		/// <summary>Gets a handle to the driver.</summary>
		/// <param name="pDriverHandle">Receives a handle to the driver.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The driver handle can be used to configure content protection.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodecoder-getdriverhandle HRESULT GetDriverHandle(
		// [out] HANDLE *pDriverHandle );
		[PreserveSig]
		HRESULT GetDriverHandle(out HANDLE pDriverHandle);
	}

	/// <summary>Identifies the output surfaces that can be accessed during video decoding.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateVideoDecoderOutputView.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videodecoderoutputview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoDecoderOutputView")]
	[ComImport, Guid("c2931aea-2a85-4f20-860f-fba1fd256e18"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoDecoderOutputView : ID3D11View, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Gets the properties of the video decoder output view.</summary>
		/// <param name="pDesc">
		/// A pointer to a D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC structure. The method fills the structure with the view properties.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodecoderoutputview-getdesc void GetDesc( [out]
		// D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc);
	}

	/// <summary>Provides the video decoding and video processing capabilities of a Microsoft Direct3D 11 device.</summary>
	/// <remarks>
	/// <para>
	/// The Direct3D 11 device supports this interface. To get a pointer to this interface, call QueryInterface with an ID3D11Device
	/// interface pointer.
	/// </para>
	/// <para>
	/// If you query an ID3D11Device for <c>ID3D11VideoDevice</c> and the Direct3D 11 device created is using the reference rasterizer or
	/// WARP, or is a hardware device and you are using the Microsoft Basic Display Adapter, <c>E_NOINTERFACE</c> is returned.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videodevice
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoDevice")]
	[ComImport, Guid("10ec4d5b-975a-4689-b9e4-d0aac30fe333"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoDevice
	{
		/// <summary>Creates a video decoder device for Microsoft Direct3D 11.</summary>
		/// <param name="pVideoDesc">
		/// A pointer to a D3D11_VIDEO_DECODER_DESC structure that describes the video stream and the decoder profile.
		/// </param>
		/// <param name="pConfig">A pointer to a D3D11_VIDEO_DECODER_CONFIG structure that specifies the decoder configuration.</param>
		/// <param name="ppDecoder">Receives a pointer to the ID3D11VideoDecoder interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>This method allocates the necessary decoder buffers.</para>
		/// <para>The ID3D11DeviceContext::ClearState method does not affect the internal state of the video decoder.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideodecoder HRESULT
		// CreateVideoDecoder( [in] const D3D11_VIDEO_DECODER_DESC *pVideoDesc, [in] const D3D11_VIDEO_DECODER_CONFIG *pConfig, [out]
		// ID3D11VideoDecoder **ppDecoder );
		[PreserveSig]
		HRESULT CreateVideoDecoder(in D3D11_VIDEO_DECODER_DESC pVideoDesc, in D3D11_VIDEO_DECODER_CONFIG pConfig, out ID3D11VideoDecoder ppDecoder);

		/// <summary>Creates a video processor device for Microsoft Direct3D 11.</summary>
		/// <param name="pEnum">A pointer to the ID3D11VideoProcessorEnumerator interface. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.</param>
		/// <param name="RateConversionIndex">
		/// Specifies the frame-rate conversion capabilities for the video processor. The value is a zero-based index that corresponds to
		/// the <c>TypeIndex</c> parameter of the ID3D11VideoProcessorEnumerator::GetVideoProcessorRateConversionCaps method.
		/// </param>
		/// <param name="ppVideoProcessor">Receives a pointer to the ID3D11VideoProcessor interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The ID3D11DeviceContext::ClearState method does not affect the internal state of the video processor.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessor HRESULT
		// CreateVideoProcessor( [in] ID3D11VideoProcessorEnumerator *pEnum, [in] UINT RateConversionIndex, [out] ID3D11VideoProcessor
		// **ppVideoProcessor );
		[PreserveSig]
		HRESULT CreateVideoProcessor([In] ID3D11VideoProcessorEnumerator pEnum, uint RateConversionIndex, out ID3D11VideoProcessor ppVideoProcessor);

		/// <summary>
		/// Creates a channel to communicate with the Microsoft Direct3D device or the graphics driver. The channel can be used to send
		/// commands and queries for content protection.
		/// </summary>
		/// <param name="ChannelType">Specifies the type of channel, as a member of the D3D11_AUTHENTICATED_CHANNEL_TYPE enumeration.</param>
		/// <param name="ppAuthenticatedChannel">
		/// Receives a pointer to the ID3D11AuthenticatedChannel interface. The caller must release the interface.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// If the <c>ChannelType</c> parameter is <c>D3D11_AUTHENTICATED_CHANNEL_D3D11</c>, the method creates a channel with the Direct3D
		/// device. This type of channel does not support authentication.
		/// </para>
		/// <para>
		/// If <c>ChannelType</c> is <c>D3D11_AUTHENTICATED_CHANNEL_DRIVER_SOFTWARE</c> or
		/// <c>D3D11_AUTHENTICATED_CHANNEL_DRIVER_HARDWARE</c>, the method creates an authenticated channel with the graphics driver.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createauthenticatedchannel HRESULT
		// CreateAuthenticatedChannel( [in] D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, [out] ID3D11AuthenticatedChannel
		// **ppAuthenticatedChannel );
		[PreserveSig]
		HRESULT CreateAuthenticatedChannel(D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, out ID3D11AuthenticatedChannel ppAuthenticatedChannel);

		/// <summary>Creates a cryptographic session to encrypt video content that is sent to the graphics driver.</summary>
		/// <param name="pCryptoType">
		/// <para>A pointer to a GUID that specifies the type of encryption to use. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDecoderProfile">
		/// A pointer to a GUID that specifies the decoding profile. For a list of possible values, see
		/// ID3D11VideoDevice::GetVideoDecoderProfile. If decoding will not be used, set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="pKeyExchangeType">
		/// <para>A pointer to a GUID that specifies the type of key exchange.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_KEY_EXCHANGE_RSAES_OAEP</c></description>
		/// <description>
		/// The caller will create the session key, encrypt it with RSA Encryption Scheme - Optimal Asymmetric Encryption Padding
		/// (RSAES-OAEP) by using the driver's public key, and pass the session key to the driver.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppCryptoSession">Receives a pointer to the ID3D11CryptoSession interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>The ID3D11DeviceContext::ClearState method does not affect the internal state of the cryptographic session.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createcryptosession HRESULT
		// CreateCryptoSession( [in] const GUID *pCryptoType, [in] const GUID *pDecoderProfile, [in] const GUID *pKeyExchangeType, [out]
		// ID3D11CryptoSession **ppCryptoSession );
		[PreserveSig]
		HRESULT CreateCryptoSession(in Guid pCryptoType, in Guid pDecoderProfile, in Guid pKeyExchangeType, out ID3D11CryptoSession ppCryptoSession);

		/// <summary>Creates a resource view for a video decoder, describing the output sample for the decoding operation.</summary>
		/// <param name="pResource">
		/// A pointer to the ID3D11Resource interface of the decoder surface. The resource must be created with the
		/// <c>D3D11_BIND_DECODER</c> flag. See D3D11_BIND_FLAG.
		/// </param>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC structure that describes the view.</param>
		/// <param name="ppVDOVView">
		/// Receives a pointer to the ID3D11VideoDecoderOutputView interface. The caller must release the interface. If this parameter is
		/// <c>NULL</c>, the method checks whether the view is supported, but does not create the view.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>Set the <c>ppVDOVView</c> parameter to <c>NULL</c> to test whether a view is supported.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideodecoderoutputview HRESULT
		// CreateVideoDecoderOutputView( [in] ID3D11Resource *pResource, [in] const D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC *pDesc, [out]
		// ID3D11VideoDecoderOutputView **ppVDOVView );
		[PreserveSig]
		HRESULT CreateVideoDecoderOutputView([In] ID3D11Resource pResource, in D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoDecoderOutputView ppVDOVView);

		/// <summary>Creates a resource view for a video processor, describing the input sample for the video processing operation.</summary>
		/// <param name="pResource">A pointer to the ID3D11Resource interface of the input surface.</param>
		/// <param name="pEnum">
		/// A pointer to the ID3D11VideoProcessorEnumerator interface that specifies the video processor. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.
		/// </param>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC structure that describes the view.</param>
		/// <param name="ppVPIView">
		/// Receives a pointer to the ID3D11VideoProcessorInputView interface. The caller must release the resource. If this parameter is
		/// <c>NULL</c>, the method checks whether the view is supported, but does not create the view.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>Set the <c>ppVPIView</c> parameter to <c>NULL</c> to test whether a view is supported.</para>
		/// <para>
		/// The surface format is given in the <c>FourCC</c> member of the D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC structure. The method fails
		/// if the video processor does not support this format as an input sample. An app must specify 0 when using 9_1, 9_2, or 9_3
		/// feature levels.
		/// </para>
		/// <para>Resources used for video processor input views must use the following bind flag combinations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// Any combination of bind flags that includes D3D11_BIND_DECODER, <c>D3D11_BIND_VIDEO_ENCODER</c>,
		/// <c>D3D11_BIND_RENDER_TARGET</c>, and <c>D3D11_BIND_UNORDERED_ACCESS_VIEW</c> can be used as for video processor input views
		/// (regardless of what other bind flags may be set).
		/// </description>
		/// </item>
		/// <item>
		/// <description>Bind flags = 0 is also allowed for a video processor input view.</description>
		/// </item>
		/// <item>
		/// <description>Other restrictions will apply such as:</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessorinputview HRESULT
		// CreateVideoProcessorInputView( [in] ID3D11Resource *pResource, [in] ID3D11VideoProcessorEnumerator *pEnum, [in] const
		// D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC *pDesc, [out] ID3D11VideoProcessorInputView **ppVPIView );
		[PreserveSig]
		HRESULT CreateVideoProcessorInputView([In] ID3D11Resource pResource, [In] ID3D11VideoProcessorEnumerator pEnum, in D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorInputView ppVPIView);

		/// <summary>Creates a resource view for a video processor, describing the output sample for the video processing operation.</summary>
		/// <param name="pResource">
		/// A pointer to the ID3D11Resource interface of the output surface. The resource must be created with the
		/// <c>D3D11_BIND_RENDER_TARGET</c> flag. See D3D11_BIND_FLAG.
		/// </param>
		/// <param name="pEnum">
		/// A pointer to the ID3D11VideoProcessorEnumerator interface that specifies the video processor. To get this pointer, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.
		/// </param>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC structure that describes the view.</param>
		/// <param name="ppVPOView">
		/// Receives a pointer to the ID3D11VideoProcessorOutputView interface. The caller must release the resource. If this parameter is
		/// <c>NULL</c>, the method checks whether the view is supported, but does not create the view.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>Set the <c>ppVPOView</c> parameter to <c>NULL</c> to test whether a view is supported.</para>
		/// <para>Resources used for video processor output views must use the following D3D11_BIND_FLAG combinations:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// D3D11_BIND_RENDER_TARGET indicates that it can be used for a video processor output view. The following bind flags are allowed
		/// to be set with <c>D3D11_BIND_RENDER_TARGET</c>:
		/// </description>
		/// </item>
		/// <item>
		/// <description>Other restrictions will apply such as:</description>
		/// </item>
		/// <item>
		/// <description>
		/// Some YUV formats can be supported as a video processor output view, but might not be supported as a 3D render target. D3D11 will
		/// allow the D3D11_BIND_RENDER_TARGET flag for these formats, but CreateRenderTargetView will not be allowed for these formats.
		/// </description>
		/// </item>
		/// </list>
		/// <para>If stereo output is enabled, the output view must have 2 array elements. Otherwise, it must only have a single array element.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessoroutputview HRESULT
		// CreateVideoProcessorOutputView( [in] ID3D11Resource *pResource, [in] ID3D11VideoProcessorEnumerator *pEnum, [in] const
		// D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC *pDesc, [out] ID3D11VideoProcessorOutputView **ppVPOView );
		[PreserveSig]
		HRESULT CreateVideoProcessorOutputView([In] ID3D11Resource pResource, [In] ID3D11VideoProcessorEnumerator pEnum, in D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorOutputView ppVPOView);

		/// <summary>Enumerates the video processor capabilities of the driver.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_CONTENT_DESC structure that describes the video content.</param>
		/// <param name="ppEnum">Receives a pointer to the ID3D11VideoProcessorEnumerator interface. The caller must release the interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// To create the video processor device, pass the ID3D11VideoProcessorEnumerator pointer to the
		/// ID3D11VideoDevice::CreateVideoProcessor method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-createvideoprocessorenumerator HRESULT
		// CreateVideoProcessorEnumerator( [in] const D3D11_VIDEO_PROCESSOR_CONTENT_DESC *pDesc, [out] ID3D11VideoProcessorEnumerator
		// **ppEnum );
		[PreserveSig]
		HRESULT CreateVideoProcessorEnumerator(in D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc, out ID3D11VideoProcessorEnumerator ppEnum);

		/// <summary>Gets the number of profiles that are supported by the driver.</summary>
		/// <returns>Returns the number of profiles.</returns>
		/// <remarks>To enumerate the profiles, call ID3D11VideoDevice::GetVideoDecoderProfile.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderprofilecount UINT GetVideoDecoderProfileCount();
		[PreserveSig]
		uint GetVideoDecoderProfileCount();

		/// <summary>Gets a profile that is supported by the driver.</summary>
		/// <param name="Index">The zero-based index of the profile. To get the number of profiles that the driver supports, call ID3D11VideoDevice::GetVideoDecoderProfileCount.</param>
		/// <param name="pDecoderProfile">Receives a GUID that identifies the profile.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderprofile HRESULT
		// GetVideoDecoderProfile( [in] UINT Index, [out] GUID *pDecoderProfile );
		[PreserveSig]
		HRESULT GetVideoDecoderProfile(uint Index, out Guid pDecoderProfile);

		/// <summary>Given aprofile, checks whether the driver supports a specified output format.</summary>
		/// <param name="pDecoderProfile">
		/// A pointer to a GUID that identifies the profile. To get the list of supported profiles, call ID3D11VideoDevice::GetVideoDecoderProfile.
		/// </param>
		/// <param name="Format">
		/// A DXGI_FORMAT value that specifies the output format. Typical values include <c>DXGI_FORMAT_NV12</c> and <c>DXGI_FORMAT_420_OPAQUE</c>.
		/// </param>
		/// <param name="pSupported">Receives the value <c>TRUE</c> if the format is supported, or <c>FALSE</c> otherwise.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// If the driver does not support the profile given in <c>pDecoderProfile</c>, the method returns <c>E_INVALIDARG</c>. If the
		/// driver supports the profile, but the DXGI format is not compatible with the profile, the method succeeds but returns the value
		/// <c>FALSE</c> in <c>pSupported</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-checkvideodecoderformat HRESULT
		// CheckVideoDecoderFormat( [in] const GUID *pDecoderProfile, [in] DXGI_FORMAT Format, [out] BOOL *pSupported );
		[PreserveSig]
		HRESULT CheckVideoDecoderFormat(in Guid pDecoderProfile, DXGI_FORMAT Format, out bool pSupported);

		/// <summary>Gets the number of decoder configurations that the driver supports for a specified video description.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_DECODER_DESC structure that describes the video stream.</param>
		/// <param name="pCount">Receives the number of decoder configurations.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>To enumerate the decoder configurations, call ID3D11VideoDevice::GetVideoDecoderConfig.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderconfigcount HRESULT
		// GetVideoDecoderConfigCount( [in] const D3D11_VIDEO_DECODER_DESC *pDesc, [out] UINT *pCount );
		[PreserveSig]
		HRESULT GetVideoDecoderConfigCount(in D3D11_VIDEO_DECODER_DESC pDesc, out uint pCount);

		/// <summary>Gets a decoder configuration that is supported by the driver.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_DECODER_DESC structure that describes the video stream.</param>
		/// <param name="Index">
		/// The zero-based index of the decoder configuration. To get the number of configurations that the driver supports, call ID3D11VideoDevice::GetVideoDecoderConfigCount.
		/// </param>
		/// <param name="pConfig">
		/// A pointer to a D3D11_VIDEO_DECODER_CONFIG structure. The method fills in the structure with the decoder configuration.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getvideodecoderconfig HRESULT
		// GetVideoDecoderConfig( [in] const D3D11_VIDEO_DECODER_DESC *pDesc, [in] UINT Index, [out] D3D11_VIDEO_DECODER_CONFIG *pConfig );
		[PreserveSig]
		HRESULT GetVideoDecoderConfig(in D3D11_VIDEO_DECODER_DESC pDesc, uint Index, out D3D11_VIDEO_DECODER_CONFIG pConfig);

		/// <summary>Queries the driver for its content protection capabilities.</summary>
		/// <param name="pCryptoType">
		/// <para>A pointer to a GUID that specifies the type of encryption to be used. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// <para></para>
		/// <para>If no encryption will be used, set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <param name="pDecoderProfile">
		/// <para>
		/// A pointer to a GUID that specifies the decoding profile. To get profiles that the driver supports, call
		/// ID3D11VideoDevice::GetVideoDecoderProfile. If decoding will not be used, set this parameter to <c>NULL</c>.
		/// </para>
		/// <para>The driver might disallow some combinations of encryption type and profile.</para>
		/// </param>
		/// <param name="pCaps">
		/// A pointer to a D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure. The method fills in this structure with the driver's content
		/// protection capabilities.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-getcontentprotectioncaps HRESULT
		// GetContentProtectionCaps( [in] const GUID *pCryptoType, [in] const GUID *pDecoderProfile, [out]
		// D3D11_VIDEO_CONTENT_PROTECTION_CAPS *pCaps );
		[PreserveSig]
		HRESULT GetContentProtectionCaps(in Guid pCryptoType, in Guid pDecoderProfile, out D3D11_VIDEO_CONTENT_PROTECTION_CAPS pCaps);

		/// <summary>Gets a cryptographic key-exchange mechanism that is supported by the driver.</summary>
		/// <param name="pCryptoType">
		/// <para>A pointer to a GUID that specifies the type of encryption to be used. The following GUIDs are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>D3D11_CRYPTO_TYPE_AES128_CTR</c></description>
		/// <description>128-bit Advanced Encryption Standard CTR mode (AES-CTR) block cipher.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pDecoderProfile">
		/// A pointer to a GUID that specifies the decoding profile. To get profiles that the driver supports, call
		/// ID3D11VideoDevice::GetVideoDecoderProfile. If decoding will not be used, set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="Index">
		/// The zero-based index of the key-exchange type. The driver reports the number of types in the <c>KeyExchangeTypeCount</c> member
		/// of the D3D11_VIDEO_CONTENT_PROTECTION_CAPS structure.
		/// </param>
		/// <param name="pKeyExchangeType">Receives a GUID that identifies the type of key exchange.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-checkcryptokeyexchange HRESULT
		// CheckCryptoKeyExchange( [in] const GUID *pCryptoType, [in] const GUID *pDecoderProfile, [in] UINT Index, [out] GUID
		// *pKeyExchangeType );
		[PreserveSig]
		HRESULT CheckCryptoKeyExchange(in Guid pCryptoType, in Guid pDecoderProfile, uint Index, out Guid pKeyExchangeType);

		/// <summary>Sets private data on the video device and associates that data with a GUID.</summary>
		/// <param name="guid">The GUID associated with the data.</param>
		/// <param name="DataSize">The size of the data, in bytes.</param>
		/// <param name="pData">A pointer to the data.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] UINT DataSize, [in] const void *pData );
		[PreserveSig]
		HRESULT SetPrivateData(in Guid guid, uint DataSize, [In] IntPtr pData);

		/// <summary>Sets a private IUnknown pointer on the video device and associates that pointer with a GUID.</summary>
		/// <param name="guid">The GUID associated with the pointer.</param>
		/// <param name="pData">A pointer to the IUnknown interface.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videodevice-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in] const IUnknown *pData );
		[PreserveSig]
		HRESULT SetPrivateDataInterface(in Guid guid, [In, MarshalAs(UnmanagedType.Interface)] object pData);
	}

	/// <summary>Represents a video processor for Microsoft Direct3D 11.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateVideoProcessor.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videoprocessor
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoProcessor")]
	[ComImport, Guid("1d7b0652-185f-41c6-85ce-0c5be3d4ae6c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoProcessor : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the content description that was used to create the video processor.</summary>
		/// <param name="pDesc">A pointer to a D3D11_VIDEO_PROCESSOR_CONTENT_DESC structure that receives the content description.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessor-getcontentdesc void GetContentDesc( [out]
		// D3D11_VIDEO_PROCESSOR_CONTENT_DESC *pDesc );
		[PreserveSig]
		void GetContentDesc(out D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc);

		/// <summary>Gets the rate conversion capabilities of the video processor.</summary>
		/// <param name="pCaps">A pointer to a D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS structure that receives the rate conversion capabilities.</param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessor-getrateconversioncaps void
		// GetRateConversionCaps( [out] D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS *pCaps );
		[PreserveSig]
		void GetRateConversionCaps(out D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS pCaps);
	}

	/// <summary>Enumerates the video processor capabilities of a Microsoft Direct3D 11 device.</summary>
	/// <remarks>
	/// <para>To get a pointer to this interface, call ID3D11VideoDevice::CreateVideoProcessorEnumerator.</para>
	/// <para>
	/// To create an instance of the video processor, pass the <c>ID3D11VideoProcessorEnumerator</c> pointer to the
	/// ID3D11VideoDevice::CreateVideoProcessor method.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videoprocessorenumerator
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoProcessorEnumerator")]
	[ComImport, Guid("31627037-53ab-4200-9061-05faa9ab45f9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoProcessorEnumerator : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Gets the content description that was used to create this enumerator.</summary>
		/// <param name="pContentDesc">A pointer to a D3D11_VIDEO_PROCESSOR_CONTENT_DESC structure that receives the content description.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorenumerator-getvideoprocessorcontentdesc
		// HRESULT GetVideoProcessorContentDesc( [out] D3D11_VIDEO_PROCESSOR_CONTENT_DESC *pContentDesc );
		[PreserveSig]
		HRESULT GetVideoProcessorContentDesc(out D3D11_VIDEO_PROCESSOR_CONTENT_DESC pContentDesc);

		/// <summary>Queries whether the video processor supports a specified video format.</summary>
		/// <param name="Format">The video format to query, specified as a DXGI_FORMAT value.</param>
		/// <param name="pFlags">Receives a bitwise <c>OR</c> of zero or more flags from the D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT enumeration.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorenumerator-checkvideoprocessorformat
		// HRESULT CheckVideoProcessorFormat( [in] DXGI_FORMAT Format, [out] UINT *pFlags );
		[PreserveSig]
		HRESULT CheckVideoProcessorFormat(DXGI_FORMAT Format, out D3D11_VIDEO_PROCESSOR_FORMAT_SUPPORT pFlags);

		/// <summary>Gets the capabilities of the video processor.</summary>
		/// <param name="pCaps">A pointer to a D3D11_VIDEO_PROCESSOR_CAPS structure that receives the capabilities.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorenumerator-getvideoprocessorcaps HRESULT
		// GetVideoProcessorCaps( [out] D3D11_VIDEO_PROCESSOR_CAPS *pCaps );
		[PreserveSig]
		HRESULT GetVideoProcessorCaps(out D3D11_VIDEO_PROCESSOR_CAPS pCaps);

		/// <summary>
		/// Returns a group of video processor capabilities that are associated with frame-rate conversion, including deinterlacing and
		/// inverse telecine.
		/// </summary>
		/// <param name="TypeIndex">
		/// The zero-based index of the group to retrieve. To get the maximum index, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>RateConversionCapsCount</c> member of the
		/// D3D11_VIDEO_PROCESSOR_CAPS structure.
		/// </param>
		/// <param name="pCaps">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS structure that receives the frame-rate conversion capabilities.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// The capabilities defined in the D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS structure are interdependent. Therefore, the driver
		/// can support multiple, distinct groups of these capabilities.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorenumerator-getvideoprocessorrateconversioncaps
		// HRESULT GetVideoProcessorRateConversionCaps( [in] UINT TypeIndex, [out] D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS *pCaps );
		[PreserveSig]
		HRESULT GetVideoProcessorRateConversionCaps(uint TypeIndex, out D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS pCaps);

		/// <summary>Gets a list of custom frame rates that a video processor supports.</summary>
		/// <param name="TypeIndex">
		/// The zero-based index of the frame-rate capability group. To get the maxmum index, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorCaps and check the <c>RateConversionCapsCount</c> member of the
		/// D3D11_VIDEO_PROCESSOR_CAPS structure.
		/// </param>
		/// <param name="CustomRateIndex">
		/// <para>
		/// The zero-based index of the custom rate to retrieve. To get the maximum index, call
		/// ID3D11VideoProcessorEnumerator::GetVideoProcessorRateConversionCaps and check the <c>CustomRateCount</c> member of the
		/// D3D11_VIDEO_PROCESSOR_RATE_CONVERSION_CAPS structure.
		/// </para>
		/// <para>This index value is always relative to the capability group specified in the <c>TypeIndex</c> parameter.</para>
		/// </param>
		/// <param name="pRate">A pointer to a D3D11_VIDEO_PROCESSOR_CUSTOM_RATE structure that receives the custom rate.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorenumerator-getvideoprocessorcustomrate
		// HRESULT GetVideoProcessorCustomRate( [in] UINT TypeIndex, [in] UINT CustomRateIndex, [out] D3D11_VIDEO_PROCESSOR_CUSTOM_RATE
		// *pRate );
		[PreserveSig]
		HRESULT GetVideoProcessorCustomRate(uint TypeIndex, uint CustomRateIndex, out D3D11_VIDEO_PROCESSOR_CUSTOM_RATE pRate);

		/// <summary>Gets the range of values for an image filter.</summary>
		/// <param name="Filter">The type of image filter, specified as a D3D11_VIDEO_PROCESSOR_FILTER value.</param>
		/// <param name="pRange">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_FILTER_RANGE structure. The method fills the structure with the range of values for the
		/// specified filter.
		/// </param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorenumerator-getvideoprocessorfilterrange
		// HRESULT GetVideoProcessorFilterRange( [in] D3D11_VIDEO_PROCESSOR_FILTER Filter, [out] D3D11_VIDEO_PROCESSOR_FILTER_RANGE *pRange );
		[PreserveSig]
		HRESULT GetVideoProcessorFilterRange(D3D11_VIDEO_PROCESSOR_FILTER Filter, out D3D11_VIDEO_PROCESSOR_FILTER_RANGE pRange);
	}

	/// <summary>Identifies the input surfaces that can be accessed during video processing.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateVideoProcessorInputView.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videoprocessorinputview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoProcessorInputView")]
	[ComImport, Guid("11ec5a5f-51dc-4945-ab34-6e8c21300ea5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoProcessorInputView : ID3D11View, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Gets the properties of the video processor input view.</summary>
		/// <param name="pDesc">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC structure. The method fills the structure with the view properties.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessorinputview-getdesc void GetDesc( [out]
		// D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc);
	}

	/// <summary>Identifies the output surfaces that can be accessed during video processing.</summary>
	/// <remarks>To get a pointer to this interface, call ID3D11VideoDevice::CreateVideoProcessorOutputView.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11videoprocessoroutputview
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11VideoProcessorOutputView")]
	[ComImport, Guid("a048285e-25a9-4527-bd93-d68b68c44254"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoProcessorOutputView : ID3D11View, ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		new void GetResource(out ID3D11Resource ppResource);

		/// <summary>Gets the properties of the video processor output view.</summary>
		/// <param name="pDesc">
		/// A pointer to a D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC structure. The method fills the structure with the view properties.
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11videoprocessoroutputview-getdesc void GetDesc( [out]
		// D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC *pDesc );
		[PreserveSig]
		void GetDesc(out D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc);
	}

	/// <summary>A view interface specifies the parts of a resource the pipeline can access during rendering.</summary>
	/// <remarks>
	/// <para>
	/// A view interface is the base interface for all views. There are four types of views; a depth-stencil view, a render-target view, a
	/// shader-resource view, and an unordered-access view.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>To create a render-target view, call ID3D11Device::CreateRenderTargetView.</description>
	/// </item>
	/// <item>
	/// <description>To create a depth-stencil view, call ID3D11Device::CreateDepthStencilView.</description>
	/// </item>
	/// <item>
	/// <description>To create a shader-resource view, call ID3D11Device::CreateShaderResourceView.</description>
	/// </item>
	/// <item>
	/// <description>To create an unordered-access view, call ID3D11Device::CreateUnorderedAccessView.</description>
	/// </item>
	/// </list>
	/// <para>All resources must be bound to the pipeline before they can be accessed.</para>
	/// <list type="bullet">
	/// <item>
	/// <description>To bind a render-target view or a depth-stencil view, call ID3D11DeviceContext::OMSetRenderTargets.</description>
	/// </item>
	/// <item>
	/// <description>To bind a shader resource, call ID3D11DeviceContext::VSSetShaderResources.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nn-d3d11-id3d11view
	[PInvokeData("d3d11.h", MSDNShortId = "NN:d3d11.ID3D11View")]
	[ComImport, Guid("839d1216-bb2e-412b-b7f4-a9dbebe08ed1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11View : ID3D11DeviceChild
	{
		/// <summary>Get a pointer to the device that created this interface.</summary>
		/// <param name="ppDevice">
		/// <para>Type: <c>ID3D11Device**</c></para>
		/// <para>Address of a pointer to a device (see ID3D11Device).</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
		/// pointer(s) before they are freed or else you will have a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getdevice void GetDevice( [out] ID3D11Device
		// **ppDevice );
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		/// <summary>Get application-defined data from a device child.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="pDataSize">
		/// <para>Type: <c>uint*</c></para>
		/// <para>
		/// A pointer to a variable that on input contains the size, in bytes, of the buffer that <c>pData</c> points to, and on output
		/// contains the size, in bytes, of the amount of data that <c>GetPrivateData</c> retrieved.
		/// </para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to a buffer that <c>GetPrivateData</c> fills with data from the device child if <c>pDataSize</c> points to a value
		/// that specifies a buffer large enough to hold the data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
		/// <para>
		/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
		/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This API is supported.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-getprivatedata HRESULT GetPrivateData( [in]
		// REFGUID guid, [in, out] uint *pDataSize, [out, optional] void *pData );
		[PreserveSig]
		new HRESULT GetPrivateData(in Guid guid, ref uint pDataSize, [Out, Optional] IntPtr pData);

		/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the data.</para>
		/// </param>
		/// <param name="DataSize">
		/// <para>Type: <c>uint</c></para>
		/// <para>Size of the data.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, DataSize must also be 0, and any data
		/// previously associated with the specified guid will be destroyed.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
		/// <para>
		/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The
		/// default friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object
		/// interface pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the
		/// <c>WKPDID_D3DDebugObjectName</c> GUID that is in D3Dcommon.h. For example, to give pContext a friendly name of <c>My name</c>,
		/// use the following code:
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedata HRESULT SetPrivateData( [in]
		// REFGUID guid, [in] uint DataSize, [in, optional] const void *pData );
		[PreserveSig]
		new HRESULT SetPrivateData(in Guid guid, uint DataSize, [In, Optional] IntPtr pData);

		/// <summary>
		/// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
		/// </summary>
		/// <param name="guid">
		/// <para>Type: <c>REFGUID</c></para>
		/// <para>Guid associated with the interface.</para>
		/// </param>
		/// <param name="pData">
		/// <para>Type: <c>const IUnknown*</c></para>
		/// <para>Pointer to an IUnknown-derived interface to be associated with the device child.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// When this method is called ::addref() will be called on the IUnknown-derived interface, and when the device child is destroyed
		/// ::release() will be called on the IUnknown-derived interface.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11devicechild-setprivatedatainterface HRESULT
		// SetPrivateDataInterface( [in] REFGUID guid, [in, optional] const IUnknown *pData );
		[PreserveSig]
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.Interface)] object? pData);

		/// <summary>Get the resource that is accessed through this view.</summary>
		/// <param name="ppResource">
		/// <para>Type: <c>ID3D11Resource**</c></para>
		/// <para>Address of a pointer to the resource that is accessed through this view. (See ID3D11Resource.)</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This function increments the reference count of the resource by one, so it is necessary to call <c>Release</c> on the returned
		/// pointer when the application is done with it. Destroying (or losing) the returned pointer before <c>Release</c> is called will
		/// result in a memory leak.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11/nf-d3d11-id3d11view-getresource void GetResource( [out] ID3D11Resource
		// **ppResource );
		[PreserveSig]
		void GetResource(out ID3D11Resource ppResource);
	}

	/// <summary>Performs an action while within a map created via <see cref="ID3D11DeviceContext"/>.</summary>
	/// <param name="context">The <see cref="ID3D11DeviceContext"/> instance.</param>
	/// <param name="resource">A pointer to a ID3D11Resource interface.</param>
	/// <param name="subResource">Index number of the subresource.</param>
	/// <param name="mapType">A D3D11_MAP-typed value that specifies the CPU's read and write permissions for a resource.</param>
	/// <param name="action">
	/// The action to perform while mapped. It receives, as a single parameter, a copy of the <see cref="D3D11_MAPPED_SUBRESOURCE"/>
	/// returned by the <see cref="ID3D11DeviceContext.Map"/> method.
	/// </param>
	/// <param name="mapFlag">Flag that specifies what the CPU does when the GPU is busy. This flag is optional.</param>
	/// <exception cref="System.ArgumentNullException">action</exception>
	public static void ActionWhileMapped(this ID3D11DeviceContext context, ID3D11Resource resource, uint subResource, D3D11_MAP mapType,
		Action<D3D11_MAPPED_SUBRESOURCE> action, D3D11_MAP_FLAG mapFlag = 0)
	{
		if (action == null)
			throw new ArgumentNullException(nameof(action));
		context.Map(resource, subResource, mapType, mapFlag, out D3D11_MAPPED_SUBRESOURCE mapped).ThrowIfFailed();
		try
		{
			action(mapped);
		}
		finally
		{
			context.Unmap(resource, subResource);
		}
	}

	/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
	/// <typeparam name="T">The type of the structure associated with <paramref name="Feature"/>.</typeparam>
	/// <param name="device">The <see cref="ID3D11Device"/> instance.</param>
	/// <param name="pFeatureSupportData"><para>Type: <c>void*</c></para>
	/// <para>Upon completion of the method, the passed structure is filled with data that describes the feature support.</para></param>
	/// <param name="Feature"><para>Type: <c>D3D11_FEATURE</c></para>
	/// <para>A member of the D3D11_FEATURE enumerated type that describes which feature to query for support.</para></param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns S_OK if successful; otherwise, returns E_INVALIDARG if an unsupported data type is passed to the
	/// <c>pFeatureSupportData</c> parameter or a size mismatch is detected for the <c>FeatureSupportDataSize</c> parameter.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To query for multi-threading support, pass the <c>D3D11_FEATURE_THREADING</c> value to the <c>Feature</c> parameter, pass the
	/// D3D11_FEATURE_DATA_THREADING structure to the <c>pFeatureSupportData</c> parameter, and pass the size of the
	/// <c>D3D11_FEATURE_DATA_THREADING</c> structure to the <c>FeatureSupportDataSize</c> parameter.
	/// </para>
	/// <para>
	/// Calling CheckFeatureSupport with <c>Feature</c> set to D3D11_FEATURE_FORMAT_SUPPORT causes the method to return the same
	/// information that would be returned by ID3D11Device::CheckFormatSupport.
	/// </para>
	/// </remarks>
	public static HRESULT CheckFeatureSupport<T>(this ID3D11Device device, in T? pFeatureSupportData, D3D11_FEATURE? Feature = null) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<T, D3D11_FEATURE>(Feature, out var f))
			return HRESULT.E_INVALIDARG;
		using SafeCoTaskMemStruct<T> mem = pFeatureSupportData;
		return device.CheckFeatureSupport(f, mem, mem.Size);
	}

	/// <summary>Gets information about the features that are supported by the current graphics driver.</summary>
	/// <typeparam name="T">The type of the structure associated with <paramref name="Feature"/>.</typeparam>
	/// <param name="device">The <see cref="ID3D11Device"/> instance.</param>
	/// <param name="pFeatureSupportData"><para>Type: <c>void*</c></para>
	/// <para>Upon completion of the method, the passed structure is filled with data that describes the feature support.</para></param>
	/// <param name="Feature"><para>Type: <c>D3D11_FEATURE</c></para>
	/// <para>A member of the D3D11_FEATURE enumerated type that describes which feature to query for support.</para></param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>
	/// Returns S_OK if successful; otherwise, returns E_INVALIDARG if an unsupported data type is passed to the
	/// <c>pFeatureSupportData</c> parameter or a size mismatch is detected for the <c>FeatureSupportDataSize</c> parameter.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To query for multi-threading support, pass the <c>D3D11_FEATURE_THREADING</c> value to the <c>Feature</c> parameter, pass the
	/// D3D11_FEATURE_DATA_THREADING structure to the <c>pFeatureSupportData</c> parameter, and pass the size of the
	/// <c>D3D11_FEATURE_DATA_THREADING</c> structure to the <c>FeatureSupportDataSize</c> parameter.
	/// </para>
	/// <para>
	/// Calling CheckFeatureSupport with <c>Feature</c> set to D3D11_FEATURE_FORMAT_SUPPORT causes the method to return the same
	/// information that would be returned by ID3D11Device::CheckFormatSupport.
	/// </para>
	/// </remarks>
	public static HRESULT CheckFeatureSupport<T>(this ID3D11Device device, ref T pFeatureSupportData, D3D11_FEATURE? Feature = null) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<T, D3D11_FEATURE>(Feature, out var f))
			return HRESULT.E_INVALIDARG;
		using SafeCoTaskMemStruct<T> mem = pFeatureSupportData;
		var hr = device.CheckFeatureSupport(f, mem, mem.Size);
		pFeatureSupportData = mem.Value;
		return hr;
	}

	/// <summary>Get a pointer to the device that created this interface.</summary>
	/// <typeparam name="T">The device interface type.</typeparam>
	/// <param name="pChild">The <see cref="ID3D11DeviceChild"/> instance.</param>
	/// <returns>The interface to the device that created this device.</returns>
	/// <remarks>
	/// Any returned interfaces will have their reference count incremented by one, so be sure to call ::release() on the returned
	/// pointer(s) before they are freed or else you will have a memory leak.
	/// </remarks>
	public static T GetDevice<T>(this ID3D11DeviceChild pChild) where T : class, ID3D11Device
	{
		if (pChild is null) throw new ArgumentNullException(nameof(pChild));
		pChild.GetDevice(out var pDev);
		return (T)pDev;
	}

	/// <summary>Gets the data from <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/> during a Map/Unmap operation.</summary>
	/// <param name="context">The <see cref="ID3D11DeviceContext" /> instance.</param>
	/// <param name="resource">A pointer to a ID3D11Resource interface.</param>
	/// <param name="subResource">Index number of the subresource.</param>
	/// <param name="mapType">A D3D11_MAP-typed value that specifies the CPU's read and write permissions for a resource.</param>
	/// <param name="size">The number of bytes to copy from <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/>.</param>
	/// <param name="mapFlag">Flag that specifies what the CPU does when the GPU is busy. This flag is optional.</param>
	/// <returns>The copied memory from <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/>.</returns>
	public static SafeCoTaskMemHandle GetMappedData(this ID3D11DeviceContext context, ID3D11Resource resource, uint subResource, D3D11_MAP mapType,
		SizeT size, D3D11_MAP_FLAG mapFlag = 0)
	{
		SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.Null;
		ActionWhileMapped(context, resource, subResource, mapType, action, mapFlag);
		return mem;

		void action(D3D11_MAPPED_SUBRESOURCE mapped) => mem = mapped.pData == IntPtr.Zero ? SafeCoTaskMemHandle.Null : new SafeCoTaskMemHandle(mapped.pData.ToByteArray(size)!);
	}

	/// <summary>Get application-defined data from a device child.</summary>
	/// <typeparam name="T">The data type.</typeparam>
	/// <param name="pChild">The <see cref="ID3D11DeviceChild"/> instance.</param>
	/// <param name="guid">
	/// <para>Type: <c>REFGUID</c></para>
	/// <para>Guid associated with the data.</para>
	/// </param>
	/// <returns>The value that <c>GetPrivateData</c> fills with data from the device child.</returns>
	/// <remarks>
	/// <para>The data stored in the device child is set by calling ID3D11DeviceChild::SetPrivateData.</para>
	/// <para>
	/// If the data returned is a pointer to an IUnknown, or one of its derivative classes, which was previously set by
	/// SetPrivateDataInterface, that interface will have its reference count incremented before the private data is returned.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This API is supported.</para>
	/// </remarks>
	public static T? GetPrivateData<T>(this ID3D11DeviceChild pChild, in Guid guid)
	{
		uint sz = 0;
		HRESULT hr = pChild.GetPrivateData(guid, ref sz, IntPtr.Zero);
		if (hr.Succeeded)
			return default;
		using SafeCoTaskMemHandle mem = new(sz);
		IntPtr p = mem.DangerousGetHandle();
		pChild.GetPrivateData(guid, ref sz, p).ThrowIfFailed();
		return p.Convert<T>(sz);
	}

	/// <summary>Sets the data using <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/> during a Map/Unmap operation.</summary>
	/// <param name="context">The <see cref="ID3D11DeviceContext" /> instance.</param>
	/// <param name="resource">A pointer to a ID3D11Resource interface.</param>
	/// <param name="subResource">Index number of the subresource.</param>
	/// <param name="mapType">A D3D11_MAP-typed value that specifies the CPU's read and write permissions for a resource.</param>
	/// <param name="data">The data to copy to <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/>.</param>
	/// <param name="mapFlag">Flag that specifies what the CPU does when the GPU is busy. This flag is optional.</param>
	public static void SetMappedData(this ID3D11DeviceContext context, ID3D11Resource resource, uint subResource, D3D11_MAP mapType, SafeAllocatedMemoryHandleBase data, D3D11_MAP_FLAG mapFlag = 0) => ActionWhileMapped(context, resource, subResource, mapType, m => data.DangerousGetHandle().CopyTo(m.pData, data.Size), mapFlag);

	/// <summary>Sets the data using <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/> during a Map/Unmap operation.</summary>
	/// <param name="context">The <see cref="ID3D11DeviceContext" /> instance.</param>
	/// <param name="resource">A pointer to a ID3D11Resource interface.</param>
	/// <param name="subResource">Index number of the subresource.</param>
	/// <param name="mapType">A D3D11_MAP-typed value that specifies the CPU's read and write permissions for a resource.</param>
	/// <param name="data">The data to copy to <see cref="D3D11_MAPPED_SUBRESOURCE.pData"/>.</param>
	/// <param name="mapFlag">Flag that specifies what the CPU does when the GPU is busy. This flag is optional.</param>
	public static void SetMappedData<T>(this ID3D11DeviceContext context, ID3D11Resource resource, uint subResource, D3D11_MAP mapType, T data, D3D11_MAP_FLAG mapFlag = 0)
	{
		using SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure(data);
		SetMappedData(context, resource, subResource, mapType, mem, mapFlag);
	}

	/// <summary>Set application-defined data to a device child and associate that data with an application-defined guid.</summary>
	/// <typeparam name="T">The data type.</typeparam>
	/// <param name="pChild">The <see cref="ID3D11DeviceChild"/> instance.</param>
	/// <param name="guid">
	/// <para>Type: <c>REFGUID</c></para>
	/// <para>Guid associated with the data.</para>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>const void*</c></para>
	/// <para>
	/// Pointer to the data to be stored with this device child. If pData is <c>NULL</c>, any data previously associated with the specified
	/// guid will be destroyed.
	/// </para>
	/// </param>
	/// <remarks>
	/// <para>The data stored in the device child with this method can be retrieved with ID3D11DeviceChild::GetPrivateData.</para>
	/// <para>
	/// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names. The default
	/// friendly name is "&lt;unnamed&gt;". You can set the friendly name so that you can determine if the corresponding object interface
	/// pointer caused the leak. To set the friendly name, use the <c>SetPrivateData</c> method and the <c>WKPDID_D3DDebugObjectName</c>
	/// GUID that is in D3Dcommon.h.
	/// </para>
	/// </remarks>
	public static void SetPrivateData<T>(this ID3D11DeviceChild pChild, in Guid guid, T? pData) where T : struct
	{
		using var mem = pData is null ? SafeHGlobalHandle.Null : SafeHGlobalHandle.CreateFromStructure(pData);
		pChild.SetPrivateData(guid, (uint)mem.Size, mem).ThrowIfFailed();
	}
}