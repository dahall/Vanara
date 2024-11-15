namespace Vanara.PInvoke;

public static partial class D3D11
{
	/// <summary>
	/// The device interface represents a virtual adapter; it is used to create resources. <c>ID3D11Device4</c> adds new methods to those in
	/// ID3D11Device3, such as <c>RegisterDeviceRemovedEvent</c> and <c>UnregisterDeviceRemoved</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11device4
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11Device4")]
	[ComImport, Guid("8992ab71-02e6-4b8d-ba48-b056dcda42c4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device4 : ID3D11Device3, ID3D11Device2, ID3D11Device1, ID3D11Device
	{
		[PreserveSig]
		new HRESULT CreateBuffer(ref D3D11_BUFFER_DESC pDesc, IntPtr pInitialData, out ID3D11Buffer ppBuffer);

		[PreserveSig]
		new HRESULT CreateTexture1D(ref D3D11_TEXTURE1D_DESC pDesc, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture1D ppTexture1D);

		[PreserveSig]
		new HRESULT CreateTexture2D(ref D3D11_TEXTURE2D_DESC pDesc, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture2D ppTexture2D);

		[PreserveSig]
		new HRESULT CreateTexture3D(ref D3D11_TEXTURE3D_DESC pDesc, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture3D ppTexture3D);

		[PreserveSig]
		new HRESULT CreateShaderResourceView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11ShaderResourceView ppSRView);

		[PreserveSig]
		new HRESULT CreateUnorderedAccessView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11UnorderedAccessView ppUAView);

		[PreserveSig]
		new HRESULT CreateRenderTargetView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11RenderTargetView ppRTView);

		[PreserveSig]
		new HRESULT CreateDepthStencilView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11DepthStencilView ppDepthStencilView);

		[PreserveSig]
		new HRESULT CreateInputLayout([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_INPUT_ELEMENT_DESC[] pInputElementDescs, int NumElements, IntPtr pShaderBytecodeWithInputSignature, IntPtr BytecodeLength, out ID3D11InputLayout ppInputLayout);

		[PreserveSig]
		new HRESULT CreateVertexShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11VertexShader ppVertexShader);

		[PreserveSig]
		new HRESULT CreateGeometryShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11GeometryShader ppGeometryShader);

		[PreserveSig]
		new HRESULT CreateGeometryShaderWithStreamOutput(IntPtr pShaderBytecode, IntPtr BytecodeLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_SO_DECLARATION_ENTRY[] pSODeclaration, int NumEntries, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pBufferStrides, int NumStrides, uint RasterizedStream, ID3D11ClassLinkage pClassLinkage, out ID3D11GeometryShader ppGeometryShader);

		[PreserveSig]
		new HRESULT CreatePixelShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11PixelShader ppPixelShader);

		[PreserveSig]
		new HRESULT CreateHullShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11HullShader ppHullShader);

		[PreserveSig]
		new HRESULT CreateDomainShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11DomainShader ppDomainShader);

		[PreserveSig]
		new HRESULT CreateComputeShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11ComputeShader ppComputeShader);

		[PreserveSig]
		new HRESULT CreateClassLinkage(out ID3D11ClassLinkage ppLinkage);

		[PreserveSig]
		new HRESULT CreateBlendState(ref D3D11_BLEND_DESC pBlendStateDesc, out ID3D11BlendState ppBlendState);

		[PreserveSig]
		new HRESULT CreateDepthStencilState(ref D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, out ID3D11DepthStencilState ppDepthStencilState);

		[PreserveSig]
		new HRESULT CreateRasterizerState(ref D3D11_RASTERIZER_DESC pRasterizerDesc, out ID3D11RasterizerState ppRasterizerState);

		[PreserveSig]
		new HRESULT CreateSamplerState(ref D3D11_SAMPLER_DESC pSamplerDesc, out ID3D11SamplerState ppSamplerState);

		[PreserveSig]
		new HRESULT CreateQuery(ref D3D11_QUERY_DESC pQueryDesc, out ID3D11Query ppQuery);

		[PreserveSig]
		new HRESULT CreatePredicate(ref D3D11_QUERY_DESC pPredicateDesc, out ID3D11Predicate ppPredicate);

		[PreserveSig]
		new HRESULT CreateCounter(ref D3D11_COUNTER_DESC pCounterDesc, out ID3D11Counter ppCounter);

		[PreserveSig]
		new HRESULT CreateDeferredContext(uint ContextFlags, out ID3D11DeviceContext ppDeferredContext);

		[PreserveSig]
		new HRESULT OpenSharedResource(IntPtr hResource, [MarshalAs(UnmanagedType.LPStruct)] Guid ReturnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

		[PreserveSig]
		new HRESULT CheckFormatSupport(DXGI_FORMAT Format, out uint pFormatSupport);

		[PreserveSig]
		new HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);

		[PreserveSig]
		new void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);

		[PreserveSig]
		new HRESULT CheckCounter(ref D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters, [MarshalAs(UnmanagedType.LPStr)] string szName, IntPtr pNameLength, [MarshalAs(UnmanagedType.LPStr)] string szUnits, IntPtr pUnitsLength, [MarshalAs(UnmanagedType.LPStr)] string szDescription, IntPtr pDescriptionLength);

		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		[PreserveSig]
		new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);

		[PreserveSig]
		new D3D_FEATURE_LEVEL GetFeatureLevel();

		[PreserveSig]
		new uint GetCreationFlags();

		[PreserveSig]
		new HRESULT GetDeviceRemovedReason();

		[PreserveSig]
		new void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);

		[PreserveSig]
		new HRESULT SetExceptionMode(uint RaiseFlags);

		[PreserveSig]
		new uint GetExceptionMode();

		[PreserveSig]
		new void GetImmediateContext1(out ID3D11DeviceContext1 ppImmediateContext);

		[PreserveSig]
		new HRESULT CreateDeferredContext1(uint ContextFlags, out ID3D11DeviceContext1 ppDeferredContext);

		[PreserveSig]
		new HRESULT CreateBlendState1(ref D3D11_BLEND_DESC1 pBlendStateDesc, out ID3D11BlendState1 ppBlendState);

		[PreserveSig]
		new HRESULT CreateRasterizerState1(ref D3D11_RASTERIZER_DESC1 pRasterizerDesc, out ID3D11RasterizerState1 ppRasterizerState);

		[PreserveSig]
		new HRESULT CreateDeviceContextState(uint Flags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D_FEATURE_LEVEL[] pFeatureLevels, int FeatureLevels, uint SDKVersion, [MarshalAs(UnmanagedType.LPStruct)] Guid EmulatedInterface, IntPtr pChosenFeatureLevel, out ID3DDeviceContextState ppContextState);

		[PreserveSig]
		new HRESULT OpenSharedResource1(IntPtr hResource, [MarshalAs(UnmanagedType.LPStruct)] Guid returnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

		[PreserveSig]
		new HRESULT OpenSharedResourceByName([MarshalAs(UnmanagedType.LPWStr)] string lpName, uint dwDesiredAccess, [MarshalAs(UnmanagedType.LPStruct)] Guid returnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

		[PreserveSig]
		new void GetImmediateContext2(out ID3D11DeviceContext2 ppImmediateContext);

		[PreserveSig]
		new HRESULT CreateDeferredContext2(uint ContextFlags, out ID3D11DeviceContext2 ppDeferredContext);

		[PreserveSig]
		new void GetResourceTiling(ID3D11Resource pTiledResource, IntPtr pNumTilesForEntireResource, IntPtr pPackedMipDesc, IntPtr pStandardTileShapeForNonPackedMips, IntPtr pNumSubresourceTilings, uint FirstSubresourceTilingToGet, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D11_SUBRESOURCE_TILING[] pSubresourceTilingsForNonPackedMips);

		[PreserveSig]
		new HRESULT CheckMultisampleQualityLevels1(DXGI_FORMAT Format, uint SampleCount, uint Flags, out uint pNumQualityLevels);

		[PreserveSig]
		new HRESULT CreateTexture2D1(ref D3D11_TEXTURE2D_DESC1 pDesc1, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture2D1 ppTexture2D);

		[PreserveSig]
		new HRESULT CreateTexture3D1(ref D3D11_TEXTURE3D_DESC1 pDesc1, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture3D1 ppTexture3D);

		[PreserveSig]
		new HRESULT CreateRasterizerState2(ref D3D11_RASTERIZER_DESC2 pRasterizerDesc, out ID3D11RasterizerState2 ppRasterizerState);

		[PreserveSig]
		new HRESULT CreateShaderResourceView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11ShaderResourceView1 ppSRView1);

		[PreserveSig]
		new HRESULT CreateUnorderedAccessView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11UnorderedAccessView1 ppUAView1);

		[PreserveSig]
		new HRESULT CreateRenderTargetView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11RenderTargetView1 ppRTView1);

		[PreserveSig]
		new HRESULT CreateQuery1(ref D3D11_QUERY_DESC1 pQueryDesc1, out ID3D11Query1 ppQuery1);

		[PreserveSig]
		new void GetImmediateContext3(out ID3D11DeviceContext3 ppImmediateContext);

		[PreserveSig]
		new HRESULT CreateDeferredContext3(uint ContextFlags, out ID3D11DeviceContext3 ppDeferredContext);

		[PreserveSig]
		new void WriteToSubresource(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		[PreserveSig]
		new void ReadFromSubresource(out IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox);

		[PreserveSig]
		HRESULT RegisterDeviceRemovedEvent(IntPtr hEvent, out uint pdwCookie);

		[PreserveSig]
		void UnregisterDeviceRemoved(uint dwCookie);
	}

	/// <summary>
	/// <para>
	/// The device interface represents a virtual adapter; it is used to create resources. <c>ID3D11Device5</c> adds new methods to those in ID3D11Device4.
	/// </para>
	/// <para>
	/// <c>Note</c>  This interface, introduced in the Windows 10 Creators Update, is the latest version of the ID3D11Device interface.
	/// Applications targetting Windows 10 Creators Update should use this interface instead of earlier versions.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11device5
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11Device5")]
	[ComImport, Guid("8ffde202-a0e7-45df-9e01-e837801b5ea0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device5 : ID3D11Device4, ID3D11Device3, ID3D11Device2, ID3D11Device1, ID3D11Device
	{
		[PreserveSig]
		new HRESULT CreateBuffer(ref D3D11_BUFFER_DESC pDesc, IntPtr pInitialData, out ID3D11Buffer ppBuffer);

		[PreserveSig]
		new HRESULT CreateTexture1D(ref D3D11_TEXTURE1D_DESC pDesc, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture1D ppTexture1D);

		[PreserveSig]
		new HRESULT CreateTexture2D(ref D3D11_TEXTURE2D_DESC pDesc, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture2D ppTexture2D);

		[PreserveSig]
		new HRESULT CreateTexture3D(ref D3D11_TEXTURE3D_DESC pDesc, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture3D ppTexture3D);

		[PreserveSig]
		new HRESULT CreateShaderResourceView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11ShaderResourceView ppSRView);

		[PreserveSig]
		new HRESULT CreateUnorderedAccessView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11UnorderedAccessView ppUAView);

		[PreserveSig]
		new HRESULT CreateRenderTargetView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11RenderTargetView ppRTView);

		[PreserveSig]
		new HRESULT CreateDepthStencilView(ID3D11Resource pResource, IntPtr pDesc, out ID3D11DepthStencilView ppDepthStencilView);

		[PreserveSig]
		new HRESULT CreateInputLayout([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_INPUT_ELEMENT_DESC[] pInputElementDescs, int NumElements, IntPtr pShaderBytecodeWithInputSignature, IntPtr BytecodeLength, out ID3D11InputLayout ppInputLayout);

		[PreserveSig]
		new HRESULT CreateVertexShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11VertexShader ppVertexShader);

		[PreserveSig]
		new HRESULT CreateGeometryShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11GeometryShader ppGeometryShader);

		[PreserveSig]
		new HRESULT CreateGeometryShaderWithStreamOutput(IntPtr pShaderBytecode, IntPtr BytecodeLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_SO_DECLARATION_ENTRY[] pSODeclaration, int NumEntries, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pBufferStrides, int NumStrides, uint RasterizedStream, ID3D11ClassLinkage pClassLinkage, out ID3D11GeometryShader ppGeometryShader);

		[PreserveSig]
		new HRESULT CreatePixelShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11PixelShader ppPixelShader);

		[PreserveSig]
		new HRESULT CreateHullShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11HullShader ppHullShader);

		[PreserveSig]
		new HRESULT CreateDomainShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11DomainShader ppDomainShader);

		[PreserveSig]
		new HRESULT CreateComputeShader(IntPtr pShaderBytecode, IntPtr BytecodeLength, ID3D11ClassLinkage pClassLinkage, out ID3D11ComputeShader ppComputeShader);

		[PreserveSig]
		new HRESULT CreateClassLinkage(out ID3D11ClassLinkage ppLinkage);

		[PreserveSig]
		new HRESULT CreateBlendState(ref D3D11_BLEND_DESC pBlendStateDesc, out ID3D11BlendState ppBlendState);

		[PreserveSig]
		new HRESULT CreateDepthStencilState(ref D3D11_DEPTH_STENCIL_DESC pDepthStencilDesc, out ID3D11DepthStencilState ppDepthStencilState);

		[PreserveSig]
		new HRESULT CreateRasterizerState(ref D3D11_RASTERIZER_DESC pRasterizerDesc, out ID3D11RasterizerState ppRasterizerState);

		[PreserveSig]
		new HRESULT CreateSamplerState(ref D3D11_SAMPLER_DESC pSamplerDesc, out ID3D11SamplerState ppSamplerState);

		[PreserveSig]
		new HRESULT CreateQuery(ref D3D11_QUERY_DESC pQueryDesc, out ID3D11Query ppQuery);

		[PreserveSig]
		new HRESULT CreatePredicate(ref D3D11_QUERY_DESC pPredicateDesc, out ID3D11Predicate ppPredicate);

		[PreserveSig]
		new HRESULT CreateCounter(ref D3D11_COUNTER_DESC pCounterDesc, out ID3D11Counter ppCounter);

		[PreserveSig]
		new HRESULT CreateDeferredContext(uint ContextFlags, out ID3D11DeviceContext ppDeferredContext);

		[PreserveSig]
		new HRESULT OpenSharedResource(IntPtr hResource, [MarshalAs(UnmanagedType.LPStruct)] Guid ReturnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

		[PreserveSig]
		new HRESULT CheckFormatSupport(DXGI_FORMAT Format, out uint pFormatSupport);

		[PreserveSig]
		new HRESULT CheckMultisampleQualityLevels(DXGI_FORMAT Format, uint SampleCount, out uint pNumQualityLevels);

		[PreserveSig]
		new void CheckCounterInfo(out D3D11_COUNTER_INFO pCounterInfo);

		[PreserveSig]
		new HRESULT CheckCounter(ref D3D11_COUNTER_DESC pDesc, out D3D11_COUNTER_TYPE pType, out uint pActiveCounters, [MarshalAs(UnmanagedType.LPStr)] string szName, IntPtr pNameLength, [MarshalAs(UnmanagedType.LPStr)] string szUnits, IntPtr pUnitsLength, [MarshalAs(UnmanagedType.LPStr)] string szDescription, IntPtr pDescriptionLength);

		[PreserveSig]
		new HRESULT CheckFeatureSupport(D3D11_FEATURE Feature, IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		[PreserveSig]
		new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);

		[PreserveSig]
		new D3D_FEATURE_LEVEL GetFeatureLevel();

		[PreserveSig]
		new uint GetCreationFlags();

		[PreserveSig]
		new HRESULT GetDeviceRemovedReason();

		[PreserveSig]
		new void GetImmediateContext(out ID3D11DeviceContext ppImmediateContext);

		[PreserveSig]
		new HRESULT SetExceptionMode(uint RaiseFlags);

		[PreserveSig]
		new uint GetExceptionMode();

		[PreserveSig]
		new void GetImmediateContext1(out ID3D11DeviceContext1 ppImmediateContext);

		[PreserveSig]
		new HRESULT CreateDeferredContext1(uint ContextFlags, out ID3D11DeviceContext1 ppDeferredContext);

		[PreserveSig]
		new HRESULT CreateBlendState1(ref D3D11_BLEND_DESC1 pBlendStateDesc, out ID3D11BlendState1 ppBlendState);

		[PreserveSig]
		new HRESULT CreateRasterizerState1(ref D3D11_RASTERIZER_DESC1 pRasterizerDesc, out ID3D11RasterizerState1 ppRasterizerState);

		[PreserveSig]
		new HRESULT CreateDeviceContextState(uint Flags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D3D_FEATURE_LEVEL[] pFeatureLevels, int FeatureLevels, uint SDKVersion, [MarshalAs(UnmanagedType.LPStruct)] Guid EmulatedInterface, IntPtr pChosenFeatureLevel, out ID3DDeviceContextState ppContextState);

		[PreserveSig]
		new HRESULT OpenSharedResource1(IntPtr hResource, [MarshalAs(UnmanagedType.LPStruct)] Guid returnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

		[PreserveSig]
		new HRESULT OpenSharedResourceByName([MarshalAs(UnmanagedType.LPWStr)] string lpName, uint dwDesiredAccess, [MarshalAs(UnmanagedType.LPStruct)] Guid returnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppResource);

		[PreserveSig]
		new void GetImmediateContext2(out ID3D11DeviceContext2 ppImmediateContext);

		[PreserveSig]
		new HRESULT CreateDeferredContext2(uint ContextFlags, out ID3D11DeviceContext2 ppDeferredContext);

		[PreserveSig]
		new void GetResourceTiling(ID3D11Resource pTiledResource, IntPtr pNumTilesForEntireResource, IntPtr pPackedMipDesc, IntPtr pStandardTileShapeForNonPackedMips, IntPtr pNumSubresourceTilings, uint FirstSubresourceTilingToGet, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D11_SUBRESOURCE_TILING[] pSubresourceTilingsForNonPackedMips);

		[PreserveSig]
		new HRESULT CheckMultisampleQualityLevels1(DXGI_FORMAT Format, uint SampleCount, uint Flags, out uint pNumQualityLevels);

		[PreserveSig]
		new HRESULT CreateTexture2D1(ref D3D11_TEXTURE2D_DESC1 pDesc1, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture2D1 ppTexture2D);

		[PreserveSig]
		new HRESULT CreateTexture3D1(ref D3D11_TEXTURE3D_DESC1 pDesc1, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture3D1 ppTexture3D);

		[PreserveSig]
		new HRESULT CreateRasterizerState2(ref D3D11_RASTERIZER_DESC2 pRasterizerDesc, out ID3D11RasterizerState2 ppRasterizerState);

		[PreserveSig]
		new HRESULT CreateShaderResourceView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11ShaderResourceView1 ppSRView1);

		[PreserveSig]
		new HRESULT CreateUnorderedAccessView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11UnorderedAccessView1 ppUAView1);

		[PreserveSig]
		new HRESULT CreateRenderTargetView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11RenderTargetView1 ppRTView1);

		[PreserveSig]
		new HRESULT CreateQuery1(ref D3D11_QUERY_DESC1 pQueryDesc1, out ID3D11Query1 ppQuery1);

		[PreserveSig]
		new void GetImmediateContext3(out ID3D11DeviceContext3 ppImmediateContext);

		[PreserveSig]
		new HRESULT CreateDeferredContext3(uint ContextFlags, out ID3D11DeviceContext3 ppDeferredContext);

		[PreserveSig]
		new void WriteToSubresource(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		[PreserveSig]
		new void ReadFromSubresource(out IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox);

		[PreserveSig]
		new HRESULT RegisterDeviceRemovedEvent(IntPtr hEvent, out uint pdwCookie);

		[PreserveSig]
		new void UnregisterDeviceRemoved(uint dwCookie);

		[PreserveSig]
		HRESULT OpenSharedFence(IntPtr hFence, [MarshalAs(UnmanagedType.LPStruct)] Guid ReturnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppFence);

		[PreserveSig]
		HRESULT CreateFence(ulong InitialValue, D3D11_FENCE_FLAG Flags, [MarshalAs(UnmanagedType.LPStruct)] Guid ReturnedInterface, [MarshalAs(UnmanagedType.IUnknown)] out object ppFence);
	}

	/// <summary>Provides threading protection for critical sections of a multi-threaded application.</summary>
	/// <remarks>
	/// <para>
	/// This interface is obtained by querying it from an immediate device context created with the ID3D11DeviceContext (or later versions
	/// of this) interface using IUnknown::QueryInterface.
	/// </para>
	/// <para>
	/// Unlike D3D10, there is no multithreaded layer in D3D11. By default, multithread protection is turned off. Use
	/// SetMultithreadProtected to turn it on, then Enter and Leave to encapsulate graphics commands that must be executed in a specific order.
	/// </para>
	/// <para>
	/// By default in D3D11, applications can only use one thread with the immediate context at a time. But, applications can use this
	/// interface to change that restriction. The interface can turn on threading protection for the immediate context, which will increase
	/// the overhead of each immediate context call in order to share one context with multiple threads.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11multithread
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11Multithread")]
	[ComImport, Guid("9b7e4e00-342c-4106-a19f-4f2704f689f0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Multithread
	{
		/// <summary>Enter a device's critical section.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If SetMultithreadProtected is set to true, then entering a device's critical section prevents other threads from simultaneously
		/// calling that device's methods, calling DXGI methods, and calling the methods of all resource, view, shader, state, and
		/// asynchronous interfaces.
		/// </para>
		/// <para>
		/// This function should be used in multithreaded applications when there is a series of graphics commands that must happen in
		/// order. This function is typically called at the beginning of the series of graphics commands, and Leave is typically called
		/// after those graphics commands.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-enter void Enter();
		[PreserveSig]
		void Enter();

		/// <summary>Leave a device's critical section.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// This function is typically used in multithreaded applications when there is a series of graphics commands that must happen in
		/// order. Enter is typically called at the beginning of a series of graphics commands, and this function is typically called after
		/// those graphics commands.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-leave void Leave();
		[PreserveSig]
		void Leave();

		/// <summary>Turns multithread protection on or off.</summary>
		/// <param name="bMTProtect">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Set to true to turn multithread protection on, false to turn it off.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>True if multithread protection was already turned on prior to calling this method, false otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-setmultithreadprotected BOOL
		// SetMultithreadProtected( [in] BOOL bMTProtect );
		[PreserveSig]
		bool SetMultithreadProtected([MarshalAs(UnmanagedType.Bool)] bool bMTProtect);

		/// <summary>Find out if multithread protection is turned on or not.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns true if multithread protection is turned on, false otherwise.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nf-d3d11_4-id3d11multithread-getmultithreadprotected BOOL GetMultithreadProtected();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool GetMultithreadProtected();
	}

	/// <summary>Provides the video functionality of a Microsoft Direct3D 11 device.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11videocontext2
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11VideoContext2")]
	[ComImport, Guid("c4e7374c-6243-4d1b-ae87-52b4f740e261"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoContext2 : ID3D11VideoContext1, ID3D11VideoContext, ID3D11DeviceChild
	{
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		[PreserveSig]
		new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);

		[PreserveSig]
		new HRESULT GetDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);

		[PreserveSig]
		new HRESULT ReleaseDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);

		[PreserveSig]
		new HRESULT DecoderBeginFrame(ID3D11VideoDecoder pDecoder, ID3D11VideoDecoderOutputView pView, uint ContentKeySize, IntPtr pContentKey);

		[PreserveSig]
		new HRESULT DecoderEndFrame(ID3D11VideoDecoder pDecoder);

		[PreserveSig]
		new HRESULT SubmitDecoderBuffers(ID3D11VideoDecoder pDecoder, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc);

		[PreserveSig]
		new int DecoderExtension(ID3D11VideoDecoder pDecoder, ref D3D11_VIDEO_DECODER_EXTENSION pExtensionData);

		[PreserveSig]
		new void VideoProcessorSetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, bool Enable, IntPtr pRect);

		[PreserveSig]
		new void VideoProcessorSetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, bool YCbCr, ref D3D11_VIDEO_COLOR pColor);

		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, ref D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorSetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);

		[PreserveSig]
		new void VideoProcessorSetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, bool Enable, tagSIZE Size);

		[PreserveSig]
		new void VideoProcessorSetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, bool Enable);

		[PreserveSig]
		new int VideoProcessorSetOutputExtension(ID3D11VideoProcessor pVideoProcessor, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void VideoProcessorGetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);

		[PreserveSig]
		new void VideoProcessorGetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);

		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);

		[PreserveSig]
		new void VideoProcessorGetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out tagSIZE pSize);

		[PreserveSig]
		new void VideoProcessorGetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);

		[PreserveSig]
		new int VideoProcessorGetOutputExtension(ID3D11VideoProcessor pVideoProcessor, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void VideoProcessorSetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);

		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, ref D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorSetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, bool RepeatFrame, IntPtr pCustomRate);

		[PreserveSig]
		new void VideoProcessorSetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pRect);

		[PreserveSig]
		new void VideoProcessorSetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pRect);

		[PreserveSig]
		new void VideoProcessorSetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);

		[PreserveSig]
		new void VideoProcessorSetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		[PreserveSig]
		new void VideoProcessorSetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pSourceAspectRatio, IntPtr pDestinationAspectRatio);

		[PreserveSig]
		new void VideoProcessorSetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);

		[PreserveSig]
		new void VideoProcessorSetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);

		[PreserveSig]
		new void VideoProcessorSetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);

		[PreserveSig]
		new void VideoProcessorSetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);

		[PreserveSig]
		new int VideoProcessorSetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void VideoProcessorGetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);

		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate, out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);

		[PreserveSig]
		new void VideoProcessorGetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		[PreserveSig]
		new void VideoProcessorGetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		[PreserveSig]
		new void VideoProcessorGetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);

		[PreserveSig]
		new void VideoProcessorGetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		[PreserveSig]
		new void VideoProcessorGetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);

		[PreserveSig]
		new void VideoProcessorGetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);

		[PreserveSig]
		new void VideoProcessorGetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0, out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);

		[PreserveSig]
		new void VideoProcessorGetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);

		[PreserveSig]
		new void VideoProcessorGetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);

		[PreserveSig]
		new int VideoProcessorGetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT VideoProcessorBlt(ID3D11VideoProcessor pVideoProcessor, ID3D11VideoProcessorOutputView pView, uint OutputFrame, int StreamCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams);

		[PreserveSig]
		new HRESULT NegotiateCryptoSessionKeyExchange(ID3D11CryptoSession pCryptoSession, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void EncryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, uint IVSize, IntPtr pIV);

		[PreserveSig]
		new void DecryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, IntPtr pEncryptedBlockInfo, uint ContentKeySize, IntPtr pContentKey, uint IVSize, IntPtr pIV);

		[PreserveSig]
		new void StartSessionKeyRefresh(ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, IntPtr pRandomNumber);

		[PreserveSig]
		new void FinishSessionKeyRefresh(ID3D11CryptoSession pCryptoSession);

		[PreserveSig]
		new HRESULT GetEncryptionBltKey(ID3D11CryptoSession pCryptoSession, uint KeySize, IntPtr pReadbackKey);

		[PreserveSig]
		new HRESULT NegotiateAuthenticatedChannelKeyExchange(ID3D11AuthenticatedChannel pChannel, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT QueryAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, uint OutputSize, IntPtr pOutput);

		[PreserveSig]
		new HRESULT ConfigureAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);

		[PreserveSig]
		new void VideoProcessorSetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);

		[PreserveSig]
		new void VideoProcessorGetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);

		[PreserveSig]
		new HRESULT SubmitDecoderBuffers1(ID3D11VideoDecoder pDecoder, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC1[] pBufferDesc);

		[PreserveSig]
		new HRESULT GetDataForNewHardwareKey(ID3D11CryptoSession pCryptoSession, uint PrivateInputSize, IntPtr pPrivatInputData, out ulong pPrivateOutputData);

		[PreserveSig]
		new HRESULT CheckCryptoSessionStatus(ID3D11CryptoSession pCryptoSession, out D3D11_CRYPTO_SESSION_STATUS pStatus);

		[PreserveSig]
		new HRESULT DecoderEnableDownsampling(ID3D11VideoDecoder pDecoder, DXGI_COLOR_SPACE_TYPE InputColorSpace, ref D3D11_VIDEO_SAMPLE_DESC pOutputDesc, uint ReferenceFrameCount);

		[PreserveSig]
		new HRESULT DecoderUpdateDownsampling(ID3D11VideoDecoder pDecoder, ref D3D11_VIDEO_SAMPLE_DESC pOutputDesc);

		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace1(ID3D11VideoProcessor pVideoProcessor, DXGI_COLOR_SPACE_TYPE ColorSpace);

		[PreserveSig]
		new void VideoProcessorSetOutputShaderUsage(ID3D11VideoProcessor pVideoProcessor, bool ShaderUsage);

		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace1(ID3D11VideoProcessor pVideoProcessor, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetOutputShaderUsage(ID3D11VideoProcessor pVideoProcessor, out bool pShaderUsage);

		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace1(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_COLOR_SPACE_TYPE ColorSpace);

		[PreserveSig]
		new void VideoProcessorSetStreamMirror(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, bool FlipHorizontal, bool FlipVertical);

		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace1(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetStreamMirror(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out bool pFlipHorizontal, out bool pFlipVertical);

		[PreserveSig]
		new HRESULT VideoProcessorGetBehaviorHints(ID3D11VideoProcessor pVideoProcessor, uint OutputWidth, uint OutputHeight, DXGI_FORMAT OutputFormat, int StreamCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT[] pStreams, out uint pBehaviorHints);

		[PreserveSig]
		void VideoProcessorSetOutputHDRMetaData(ID3D11VideoProcessor pVideoProcessor, DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pHDRMetaData);

		[PreserveSig]
		void VideoProcessorGetOutputHDRMetaData(ID3D11VideoProcessor pVideoProcessor, out DXGI_HDR_METADATA_TYPE pType, uint Size, IntPtr pMetaData);

		[PreserveSig]
		void VideoProcessorSetStreamHDRMetaData(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pHDRMetaData);

		[PreserveSig]
		void VideoProcessorGetStreamHDRMetaData(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_HDR_METADATA_TYPE pType, uint Size, IntPtr pMetaData);
	}

	/// <summary>
	/// Provides the video functionality of a Microsoft Direct3D 11 device. This interface provides the DecoderBeginFrame1 method, which
	/// provides support for decode histograms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11videocontext3
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11VideoContext3")]
	[ComImport, Guid("a9e2faa0-cb39-418f-a0b7-d8aad4de672e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoContext3 : ID3D11VideoContext2, ID3D11VideoContext1, ID3D11VideoContext, ID3D11DeviceChild
	{
		[PreserveSig]
		new void GetDevice(out ID3D11Device ppDevice);

		[PreserveSig]
		new HRESULT GetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, ref uint pDataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);

		[PreserveSig]
		new HRESULT GetDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type, out uint pBufferSize, out IntPtr ppBuffer);

		[PreserveSig]
		new HRESULT ReleaseDecoderBuffer(ID3D11VideoDecoder pDecoder, D3D11_VIDEO_DECODER_BUFFER_TYPE Type);

		[PreserveSig]
		new HRESULT DecoderBeginFrame(ID3D11VideoDecoder pDecoder, ID3D11VideoDecoderOutputView pView, uint ContentKeySize, IntPtr pContentKey);

		[PreserveSig]
		new HRESULT DecoderEndFrame(ID3D11VideoDecoder pDecoder);

		[PreserveSig]
		new HRESULT SubmitDecoderBuffers(ID3D11VideoDecoder pDecoder, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC[] pBufferDesc);

		[PreserveSig]
		new int DecoderExtension(ID3D11VideoDecoder pDecoder, ref D3D11_VIDEO_DECODER_EXTENSION pExtensionData);

		[PreserveSig]
		new void VideoProcessorSetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, bool Enable, IntPtr pRect);

		[PreserveSig]
		new void VideoProcessorSetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, bool YCbCr, ref D3D11_VIDEO_COLOR pColor);

		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, ref D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorSetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE AlphaFillMode, uint StreamIndex);

		[PreserveSig]
		new void VideoProcessorSetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, bool Enable, tagSIZE Size);

		[PreserveSig]
		new void VideoProcessorSetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, bool Enable);

		[PreserveSig]
		new int VideoProcessorSetOutputExtension(ID3D11VideoProcessor pVideoProcessor, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void VideoProcessorGetOutputTargetRect(ID3D11VideoProcessor pVideoProcessor, out bool Enabled, out RECT pRect);

		[PreserveSig]
		new void VideoProcessorGetOutputBackgroundColor(ID3D11VideoProcessor pVideoProcessor, out bool pYCbCr, out D3D11_VIDEO_COLOR pColor);

		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetOutputAlphaFillMode(ID3D11VideoProcessor pVideoProcessor, out D3D11_VIDEO_PROCESSOR_ALPHA_FILL_MODE pAlphaFillMode, out uint pStreamIndex);

		[PreserveSig]
		new void VideoProcessorGetOutputConstriction(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled, out tagSIZE pSize);

		[PreserveSig]
		new void VideoProcessorGetOutputStereoMode(ID3D11VideoProcessor pVideoProcessor, out bool pEnabled);

		[PreserveSig]
		new int VideoProcessorGetOutputExtension(ID3D11VideoProcessor pVideoProcessor, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void VideoProcessorSetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_FRAME_FORMAT FrameFormat);

		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, ref D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorSetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_OUTPUT_RATE OutputRate, bool RepeatFrame, IntPtr pCustomRate);

		[PreserveSig]
		new void VideoProcessorSetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pRect);

		[PreserveSig]
		new void VideoProcessorSetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pRect);

		[PreserveSig]
		new void VideoProcessorSetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Alpha);

		[PreserveSig]
		new void VideoProcessorSetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		[PreserveSig]
		new void VideoProcessorSetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, IntPtr pSourceAspectRatio, IntPtr pDestinationAspectRatio);

		[PreserveSig]
		new void VideoProcessorSetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, float Lower, float Upper);

		[PreserveSig]
		new void VideoProcessorSetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_STEREO_FORMAT Format, bool LeftViewFrame0, bool BaseViewFrame0, D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE FlipMode, int MonoOffset);

		[PreserveSig]
		new void VideoProcessorSetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable);

		[PreserveSig]
		new void VideoProcessorSetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, bool Enable, int Level);

		[PreserveSig]
		new int VideoProcessorSetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void VideoProcessorGetStreamFrameFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_FRAME_FORMAT pFrameFormat);

		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_COLOR_SPACE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetStreamOutputRate(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out D3D11_VIDEO_PROCESSOR_OUTPUT_RATE pOutputRate, out bool pRepeatFrame, out DXGI_RATIONAL pCustomRate);

		[PreserveSig]
		new void VideoProcessorGetStreamSourceRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		[PreserveSig]
		new void VideoProcessorGetStreamDestRect(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out RECT pRect);

		[PreserveSig]
		new void VideoProcessorGetStreamAlpha(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pAlpha);

		[PreserveSig]
		new void VideoProcessorGetStreamPalette(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, int Count, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] uint[] pEntries);

		[PreserveSig]
		new void VideoProcessorGetStreamPixelAspectRatio(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out DXGI_RATIONAL pSourceAspectRatio, out DXGI_RATIONAL pDestinationAspectRatio);

		[PreserveSig]
		new void VideoProcessorGetStreamLumaKey(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled, out float pLower, out float pUpper);

		[PreserveSig]
		new void VideoProcessorGetStreamStereoFormat(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_STEREO_FORMAT pFormat, out bool pLeftViewFrame0, out bool pBaseViewFrame0, out D3D11_VIDEO_PROCESSOR_STEREO_FLIP_MODE pFlipMode, out int MonoOffset);

		[PreserveSig]
		new void VideoProcessorGetStreamAutoProcessingMode(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnabled);

		[PreserveSig]
		new void VideoProcessorGetStreamFilter(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, D3D11_VIDEO_PROCESSOR_FILTER Filter, out bool pEnabled, out int pLevel);

		[PreserveSig]
		new int VideoProcessorGetStreamExtension(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, [MarshalAs(UnmanagedType.LPStruct)] Guid pExtensionGuid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT VideoProcessorBlt(ID3D11VideoProcessor pVideoProcessor, ID3D11VideoProcessorOutputView pView, uint OutputFrame, int StreamCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] D3D11_VIDEO_PROCESSOR_STREAM[] pStreams);

		[PreserveSig]
		new HRESULT NegotiateCryptoSessionKeyExchange(ID3D11CryptoSession pCryptoSession, uint DataSize, IntPtr pData);

		[PreserveSig]
		new void EncryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, uint IVSize, IntPtr pIV);

		[PreserveSig]
		new void DecryptionBlt(ID3D11CryptoSession pCryptoSession, ID3D11Texture2D pSrcSurface, ID3D11Texture2D pDstSurface, IntPtr pEncryptedBlockInfo, uint ContentKeySize, IntPtr pContentKey, uint IVSize, IntPtr pIV);

		[PreserveSig]
		new void StartSessionKeyRefresh(ID3D11CryptoSession pCryptoSession, uint RandomNumberSize, IntPtr pRandomNumber);

		[PreserveSig]
		new void FinishSessionKeyRefresh(ID3D11CryptoSession pCryptoSession);

		[PreserveSig]
		new HRESULT GetEncryptionBltKey(ID3D11CryptoSession pCryptoSession, uint KeySize, IntPtr pReadbackKey);

		[PreserveSig]
		new HRESULT NegotiateAuthenticatedChannelKeyExchange(ID3D11AuthenticatedChannel pChannel, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT QueryAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, uint OutputSize, IntPtr pOutput);

		[PreserveSig]
		new HRESULT ConfigureAuthenticatedChannel(ID3D11AuthenticatedChannel pChannel, uint InputSize, IntPtr pInput, out D3D11_AUTHENTICATED_CONFIGURE_OUTPUT pOutput);

		[PreserveSig]
		new void VideoProcessorSetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, D3D11_VIDEO_PROCESSOR_ROTATION Rotation);

		[PreserveSig]
		new void VideoProcessorGetStreamRotation(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out D3D11_VIDEO_PROCESSOR_ROTATION pRotation);

		[PreserveSig]
		new HRESULT SubmitDecoderBuffers1(ID3D11VideoDecoder pDecoder, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC1[] pBufferDesc);

		[PreserveSig]
		new HRESULT GetDataForNewHardwareKey(ID3D11CryptoSession pCryptoSession, uint PrivateInputSize, IntPtr pPrivatInputData, out ulong pPrivateOutputData);

		[PreserveSig]
		new HRESULT CheckCryptoSessionStatus(ID3D11CryptoSession pCryptoSession, out D3D11_CRYPTO_SESSION_STATUS pStatus);

		[PreserveSig]
		new HRESULT DecoderEnableDownsampling(ID3D11VideoDecoder pDecoder, DXGI_COLOR_SPACE_TYPE InputColorSpace, ref D3D11_VIDEO_SAMPLE_DESC pOutputDesc, uint ReferenceFrameCount);

		[PreserveSig]
		new HRESULT DecoderUpdateDownsampling(ID3D11VideoDecoder pDecoder, ref D3D11_VIDEO_SAMPLE_DESC pOutputDesc);

		[PreserveSig]
		new void VideoProcessorSetOutputColorSpace1(ID3D11VideoProcessor pVideoProcessor, DXGI_COLOR_SPACE_TYPE ColorSpace);

		[PreserveSig]
		new void VideoProcessorSetOutputShaderUsage(ID3D11VideoProcessor pVideoProcessor, bool ShaderUsage);

		[PreserveSig]
		new void VideoProcessorGetOutputColorSpace1(ID3D11VideoProcessor pVideoProcessor, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetOutputShaderUsage(ID3D11VideoProcessor pVideoProcessor, out bool pShaderUsage);

		[PreserveSig]
		new void VideoProcessorSetStreamColorSpace1(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_COLOR_SPACE_TYPE ColorSpace);

		[PreserveSig]
		new void VideoProcessorSetStreamMirror(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, bool Enable, bool FlipHorizontal, bool FlipVertical);

		[PreserveSig]
		new void VideoProcessorGetStreamColorSpace1(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_COLOR_SPACE_TYPE pColorSpace);

		[PreserveSig]
		new void VideoProcessorGetStreamMirror(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out bool pEnable, out bool pFlipHorizontal, out bool pFlipVertical);

		[PreserveSig]
		new HRESULT VideoProcessorGetBehaviorHints(ID3D11VideoProcessor pVideoProcessor, uint OutputWidth, uint OutputHeight, DXGI_FORMAT OutputFormat, int StreamCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D3D11_VIDEO_PROCESSOR_STREAM_BEHAVIOR_HINT[] pStreams, out uint pBehaviorHints);

		[PreserveSig]
		new void VideoProcessorSetOutputHDRMetaData(ID3D11VideoProcessor pVideoProcessor, DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pHDRMetaData);

		[PreserveSig]
		new void VideoProcessorGetOutputHDRMetaData(ID3D11VideoProcessor pVideoProcessor, out DXGI_HDR_METADATA_TYPE pType, uint Size, IntPtr pMetaData);

		[PreserveSig]
		new void VideoProcessorSetStreamHDRMetaData(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, DXGI_HDR_METADATA_TYPE Type, uint Size, IntPtr pHDRMetaData);

		[PreserveSig]
		new void VideoProcessorGetStreamHDRMetaData(ID3D11VideoProcessor pVideoProcessor, uint StreamIndex, out DXGI_HDR_METADATA_TYPE pType, uint Size, IntPtr pMetaData);

		[PreserveSig]
		HRESULT DecoderBeginFrame1(ID3D11VideoDecoder pDecoder, ID3D11VideoDecoderOutputView pView, uint ContentKeySize, IntPtr pContentKey, int NumComponentHistograms, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pHistogramOffsets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ID3D11Buffer[] ppHistogramBuffers);

		[PreserveSig]
		HRESULT SubmitDecoderBuffers2(ID3D11VideoDecoder pDecoder, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_VIDEO_DECODER_BUFFER_DESC2[] pBufferDesc);
	}

	/// <summary>
	/// Provides the video decoding and video processing capabilities of a Microsoft Direct3D 11 device. Adds the CheckFeatureSupport method
	/// for querying for decoding capabilities.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/nn-d3d11_4-id3d11videodevice2
	[PInvokeData("d3d11_4.h", MSDNShortId = "NN:d3d11_4.ID3D11VideoDevice2")]
	[ComImport, Guid("59c0cb01-35f0-4a70-8f67-87905c906a53"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11VideoDevice2 : ID3D11VideoDevice1, ID3D11VideoDevice
	{
		[PreserveSig]
		new HRESULT CreateVideoDecoder(ref D3D11_VIDEO_DECODER_DESC pVideoDesc, ref D3D11_VIDEO_DECODER_CONFIG pConfig, out ID3D11VideoDecoder ppDecoder);

		[PreserveSig]
		new HRESULT CreateVideoProcessor(ID3D11VideoProcessorEnumerator pEnum, uint RateConversionIndex, out ID3D11VideoProcessor ppVideoProcessor);

		[PreserveSig]
		new HRESULT CreateAuthenticatedChannel(D3D11_AUTHENTICATED_CHANNEL_TYPE ChannelType, out ID3D11AuthenticatedChannel ppAuthenticatedChannel);

		[PreserveSig]
		new HRESULT CreateCryptoSession([MarshalAs(UnmanagedType.LPStruct)] Guid pCryptoType, IntPtr pDecoderProfile, [MarshalAs(UnmanagedType.LPStruct)] Guid pKeyExchangeType, out ID3D11CryptoSession ppCryptoSession);

		[PreserveSig]
		new HRESULT CreateVideoDecoderOutputView(ID3D11Resource pResource, ref D3D11_VIDEO_DECODER_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoDecoderOutputView ppVDOVView);

		[PreserveSig]
		new HRESULT CreateVideoProcessorInputView(ID3D11Resource pResource, ID3D11VideoProcessorEnumerator pEnum, ref D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorInputView ppVPIView);

		[PreserveSig]
		new HRESULT CreateVideoProcessorOutputView(ID3D11Resource pResource, ID3D11VideoProcessorEnumerator pEnum, ref D3D11_VIDEO_PROCESSOR_OUTPUT_VIEW_DESC pDesc, out ID3D11VideoProcessorOutputView ppVPOView);

		[PreserveSig]
		new HRESULT CreateVideoProcessorEnumerator(ref D3D11_VIDEO_PROCESSOR_CONTENT_DESC pDesc, out ID3D11VideoProcessorEnumerator ppEnum);

		[PreserveSig]
		new uint GetVideoDecoderProfileCount();

		[PreserveSig]
		new HRESULT GetVideoDecoderProfile(uint Index, out Guid pDecoderProfile);

		[PreserveSig]
		new HRESULT CheckVideoDecoderFormat([MarshalAs(UnmanagedType.LPStruct)] Guid pDecoderProfile, DXGI_FORMAT Format, out bool pSupported);

		[PreserveSig]
		new HRESULT GetVideoDecoderConfigCount(ref D3D11_VIDEO_DECODER_DESC pDesc, out uint pCount);

		[PreserveSig]
		new HRESULT GetVideoDecoderConfig(ref D3D11_VIDEO_DECODER_DESC pDesc, uint Index, out D3D11_VIDEO_DECODER_CONFIG pConfig);

		[PreserveSig]
		new HRESULT GetContentProtectionCaps(IntPtr pCryptoType, IntPtr pDecoderProfile, out D3D11_VIDEO_CONTENT_PROTECTION_CAPS pCaps);

		[PreserveSig]
		new HRESULT CheckCryptoKeyExchange([MarshalAs(UnmanagedType.LPStruct)] Guid pCryptoType, IntPtr pDecoderProfile, uint Index, out Guid pKeyExchangeType);

		[PreserveSig]
		new HRESULT SetPrivateData([MarshalAs(UnmanagedType.LPStruct)] Guid guid, uint DataSize, IntPtr pData);

		[PreserveSig]
		new HRESULT SetPrivateDataInterface([MarshalAs(UnmanagedType.LPStruct)] Guid guid, IntPtr pData);

		[PreserveSig]
		new HRESULT GetCryptoSessionPrivateDataSize([MarshalAs(UnmanagedType.LPStruct)] Guid pCryptoType, IntPtr pDecoderProfile, [MarshalAs(UnmanagedType.LPStruct)] Guid pKeyExchangeType, out uint pPrivateInputSize, out uint pPrivateOutputSize);

		[PreserveSig]
		new HRESULT GetVideoDecoderCaps([MarshalAs(UnmanagedType.LPStruct)] Guid pDecoderProfile, uint SampleWidth, uint SampleHeight, ref DXGI_RATIONAL pFrameRate, uint BitRate, IntPtr pCryptoType, out uint pDecoderCaps);

		[PreserveSig]
		new HRESULT CheckVideoDecoderDownsampling(ref D3D11_VIDEO_DECODER_DESC pInputDesc, DXGI_COLOR_SPACE_TYPE InputColorSpace, ref D3D11_VIDEO_DECODER_CONFIG pInputConfig, ref DXGI_RATIONAL pFrameRate, ref D3D11_VIDEO_SAMPLE_DESC pOutputDesc, out bool pSupported, out bool pRealTimeHint);

		[PreserveSig]
		new HRESULT RecommendVideoDecoderDownsampleParameters(ref D3D11_VIDEO_DECODER_DESC pInputDesc, DXGI_COLOR_SPACE_TYPE InputColorSpace, ref D3D11_VIDEO_DECODER_CONFIG pInputConfig, ref DXGI_RATIONAL pFrameRate, out D3D11_VIDEO_SAMPLE_DESC pRecommendedOutputDesc);

		[PreserveSig]
		HRESULT CheckFeatureSupport(D3D11_FEATURE_VIDEO Feature, IntPtr pFeatureSupportData, uint FeatureSupportDataSize);

		[PreserveSig]
		HRESULT NegotiateCryptoSessionKeyExchangeMT(ID3D11CryptoSession pCryptoSession, D3D11_CRYPTO_SESSION_KEY_EXCHANGE_FLAGS flags, uint DataSize, IntPtr pData);
	}

	/// <summary>Describes Direct3D 11.4 feature options in the current graphics driver.</summary>
	/// <remarks>
	/// <para>Use this structure with the D3D11_FEATURE_D3D11_OPTIONS4 member of D3D11_FEATURE.</para>
	/// <para>Refer to the section on NV12 in Direct3D 11.4 Features.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_4/ns-d3d11_4-d3d11_feature_data_d3d11_options4 typedef struct
	// D3D11_FEATURE_DATA_D3D11_OPTIONS4 { BOOL ExtendedNV12SharedTextureSupported; } D3D11_FEATURE_DATA_D3D11_OPTIONS4;
	[PInvokeData("d3d11_4.h", MSDNShortId = "NS:d3d11_4.D3D11_FEATURE_DATA_D3D11_OPTIONS4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_FEATURE_DATA_D3D11_OPTIONS4
	{
		/// <summary>Specifies a BOOL that determines if NV12 textures can be shared across processes and D3D devices.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ExtendedNV12SharedTextureSupported;
	}

	/*
	D3D11_FEATURE_VIDEO
	D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT
	D3D11_VIDEO_DECODER_HISTOGRAM_COMPONENT_FLAGS

	D3D11_FEATURE_DATA_VIDEO_DECODER_HISTOGRAM
	*/
}