namespace Vanara.PInvoke;

public static partial class D3D11
{
	/// <summary>Identifies whether conservative rasterization is on or off.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_conservative_rasterization_mode typedef enum
	// D3D11_CONSERVATIVE_RASTERIZATION_MODE { D3D11_CONSERVATIVE_RASTERIZATION_MODE_OFF = 0, D3D11_CONSERVATIVE_RASTERIZATION_MODE_ON = 1 } ;
	[PInvokeData("d3d11_3.h", MSDNShortId = "NE:d3d11_3.D3D11_CONSERVATIVE_RASTERIZATION_MODE")]
	public enum D3D11_CONSERVATIVE_RASTERIZATION_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Conservative rasterization is off.</para>
		/// </summary>
		D3D11_CONSERVATIVE_RASTERIZATION_MODE_OFF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Conservative rasterization is on.</para>
		/// </summary>
		D3D11_CONSERVATIVE_RASTERIZATION_MODE_ON,
	}

	/// <summary>Specifies the context in which a query occurs.</summary>
	/// <remarks>
	/// <para>This enum is used by the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D11_QUERY_DESC1 structure</description>
	/// </item>
	/// <item>
	/// <description>A CD3D11_QUERY_DESC1 constructor.</description>
	/// </item>
	/// <item>
	/// <description>ID3D11DeviceContext3::Flush1 method</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_context_type typedef enum D3D11_CONTEXT_TYPE {
	// D3D11_CONTEXT_TYPE_ALL = 0, D3D11_CONTEXT_TYPE_3D = 1, D3D11_CONTEXT_TYPE_COMPUTE = 2, D3D11_CONTEXT_TYPE_COPY = 3,
	// D3D11_CONTEXT_TYPE_VIDEO = 4 } ;
	[PInvokeData("d3d11_3.h", MSDNShortId = "NE:d3d11_3.D3D11_CONTEXT_TYPE")]
	public enum D3D11_CONTEXT_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The query can occur in all contexts.</para>
		/// </summary>
		D3D11_CONTEXT_TYPE_ALL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The query occurs in the context of a 3D command queue.</para>
		/// </summary>
		D3D11_CONTEXT_TYPE_3D,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The query occurs in the context of a 3D compute queue.</para>
		/// </summary>
		D3D11_CONTEXT_TYPE_COMPUTE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The query occurs in the context of a 3D copy queue.</para>
		/// </summary>
		D3D11_CONTEXT_TYPE_COPY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The query occurs in the context of video.</para>
		/// </summary>
		D3D11_CONTEXT_TYPE_VIDEO,
	}

	/// <summary>Specifies fence options.</summary>
	/// <remarks>This enum is used by the ID3D11Device::CreateFence method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_fence_flag typedef enum D3D11_FENCE_FLAG {
	// D3D11_FENCE_FLAG_NONE = 0, D3D11_FENCE_FLAG_SHARED = 0x2, D3D11_FENCE_FLAG_SHARED_CROSS_ADAPTER = 0x4, D3D11_FENCE_FLAG_NON_MONITORED
	// = 0x8 } ;
	[PInvokeData("d3d11_3.h", MSDNShortId = "NE:d3d11_3.D3D11_FENCE_FLAG")]
	[Flags]
	public enum D3D11_FENCE_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No options are specified.</para>
		/// </summary>
		D3D11_FENCE_FLAG_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x2</para>
		/// <para>The fence is shared.</para>
		/// </summary>
		D3D11_FENCE_FLAG_SHARED = 0x2,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x4</para>
		/// <para>The fence is shared with another GPU adapter.</para>
		/// </summary>
		D3D11_FENCE_FLAG_SHARED_CROSS_ADAPTER = 0x4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x8</para>
		/// </summary>
		D3D11_FENCE_FLAG_NON_MONITORED = 0x8,
	}

	/// <summary>
	/// The device interface represents a virtual adapter; it is used to create resources. <c>ID3D11Device3</c> adds new methods to those in ID3D11Device2.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11device3
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11Device3")]
	[ComImport, Guid("a05c8c37-d2c6-4732-b3a0-9ce0b0dc9ae6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Device3 : ID3D11Device2, ID3D11Device1, ID3D11Device
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
		HRESULT CreateTexture2D1(ref D3D11_TEXTURE2D_DESC1 pDesc1, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture2D1 ppTexture2D);

		[PreserveSig]
		HRESULT CreateTexture3D1(ref D3D11_TEXTURE3D_DESC1 pDesc1, [MarshalAs(UnmanagedType.LPArray)] D3D11_SUBRESOURCE_DATA[] pInitialData, out ID3D11Texture3D1 ppTexture3D);

		[PreserveSig]
		HRESULT CreateRasterizerState2(ref D3D11_RASTERIZER_DESC2 pRasterizerDesc, out ID3D11RasterizerState2 ppRasterizerState);

		[PreserveSig]
		HRESULT CreateShaderResourceView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11ShaderResourceView1 ppSRView1);

		[PreserveSig]
		HRESULT CreateUnorderedAccessView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11UnorderedAccessView1 ppUAView1);

		[PreserveSig]
		HRESULT CreateRenderTargetView1(ID3D11Resource pResource, IntPtr pDesc1, out ID3D11RenderTargetView1 ppRTView1);

		[PreserveSig]
		HRESULT CreateQuery1(ref D3D11_QUERY_DESC1 pQueryDesc1, out ID3D11Query1 ppQuery1);

		[PreserveSig]
		void GetImmediateContext3(out ID3D11DeviceContext3 ppImmediateContext);

		[PreserveSig]
		HRESULT CreateDeferredContext3(uint ContextFlags, out ID3D11DeviceContext3 ppDeferredContext);

		[PreserveSig]
		void WriteToSubresource(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		[PreserveSig]
		void ReadFromSubresource(out IntPtr pDstData, uint DstRowPitch, uint DstDepthPitch, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox);
	}

	/// <summary>
	/// The device context interface represents a device context; it is used to render commands. <c>ID3D11DeviceContext3</c> adds new
	/// methods to those in ID3D11DeviceContext2.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11devicecontext3
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11DeviceContext3")]
	[ComImport, Guid("b4e3c01d-e79e-4637-91b2-510e9f4c9b8f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DeviceContext3 : ID3D11DeviceContext2, ID3D11DeviceContext1, ID3D11DeviceContext, ID3D11DeviceChild
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
		new void VSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void PSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void PSSetShader(ID3D11PixelShader pPixelShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void PSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void VSSetShader(ID3D11VertexShader pVertexShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);

		[PreserveSig]
		new void Draw(uint VertexCount, uint StartVertexLocation);

		[PreserveSig]
		new HRESULT Map(ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, IntPtr pMappedResource);

		[PreserveSig]
		new void Unmap(ID3D11Resource pResource, uint Subresource);

		[PreserveSig]
		new void PSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void IASetInputLayout(ID3D11InputLayout pInputLayout);

		[PreserveSig]
		new void IASetVertexBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppVertexBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pStrides, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pOffsets);

		[PreserveSig]
		new void IASetIndexBuffer(ID3D11Buffer pIndexBuffer, DXGI_FORMAT Format, uint Offset);

		[PreserveSig]
		new void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		[PreserveSig]
		new void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		[PreserveSig]
		new void GSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void GSSetShader(ID3D11GeometryShader pShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);

		[PreserveSig]
		new void VSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void VSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void Begin(ID3D11Asynchronous pAsync);

		[PreserveSig]
		new void End(ID3D11Asynchronous pAsync);

		[PreserveSig]
		new HRESULT GetData(ID3D11Asynchronous pAsync, IntPtr pData, uint DataSize, uint GetDataFlags);

		[PreserveSig]
		new void SetPredication(ID3D11Predicate pPredicate, bool PredicateValue);

		[PreserveSig]
		new void GSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void GSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void OMSetRenderTargets(int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);

		[PreserveSig]
		new void OMSetRenderTargetsAndUnorderedAccessViews(int NumRTVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView, uint UAVStartSlot, int NumUAVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ID3D11UnorderedAccessView[] ppUnorderedAccessViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pUAVInitialCounts);

		[PreserveSig]
		new void OMSetBlendState(ID3D11BlendState pBlendState, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, uint SampleMask);

		[PreserveSig]
		new void OMSetDepthStencilState(ID3D11DepthStencilState pDepthStencilState, uint StencilRef);

		[PreserveSig]
		new void SOSetTargets(int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11Buffer[] ppSOTargets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pOffsets);

		[PreserveSig]
		new void DrawAuto();

		[PreserveSig]
		new void DrawIndexedInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void DrawInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		[PreserveSig]
		new void DispatchIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void RSSetState(ID3D11RasterizerState pRasterizerState);

		[PreserveSig]
		new void RSSetViewports(int NumViewports, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[] pViewports);

		[PreserveSig]
		new void RSSetScissorRects(int NumRects, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		[PreserveSig]
		new void CopySubresourceRegion(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox);

		[PreserveSig]
		new void CopyResource(ID3D11Resource pDstResource, ID3D11Resource pSrcResource);

		[PreserveSig]
		new void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		[PreserveSig]
		new void CopyStructureCount(ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ID3D11UnorderedAccessView pSrcView);

		[PreserveSig]
		new void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] ColorRGBA);

		[PreserveSig]
		new void ClearUnorderedAccessViewUint(ID3D11UnorderedAccessView pUnorderedAccessView, [In][Out][MarshalAs(UnmanagedType.LPArray)] uint[] Values);

		[PreserveSig]
		new void ClearUnorderedAccessViewFloat(ID3D11UnorderedAccessView pUnorderedAccessView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] Values);

		[PreserveSig]
		new void ClearDepthStencilView(ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, byte Stencil);

		[PreserveSig]
		new void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);

		[PreserveSig]
		new void SetResourceMinLOD(ID3D11Resource pResource, float MinLOD);

		[PreserveSig]
		new float GetResourceMinLOD(ID3D11Resource pResource);

		[PreserveSig]
		new void ResolveSubresource(ID3D11Resource pDstResource, uint DstSubresource, ID3D11Resource pSrcResource, uint SrcSubresource, DXGI_FORMAT Format);

		[PreserveSig]
		new void ExecuteCommandList(ID3D11CommandList pCommandList, bool RestoreContextState);

		[PreserveSig]
		new void HSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void HSSetShader(ID3D11HullShader pHullShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void HSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void HSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void DSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void DSSetShader(ID3D11DomainShader pDomainShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void DSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void DSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void CSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void CSSetUnorderedAccessViews(uint StartSlot, int NumUAVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11UnorderedAccessView[] ppUnorderedAccessViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pUAVInitialCounts);

		[PreserveSig]
		new void CSSetShader(ID3D11ComputeShader pComputeShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void CSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void CSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void PSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void PSGetShader(out ID3D11PixelShader ppPixelShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void PSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void VSGetShader(out ID3D11VertexShader ppVertexShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);

		[PreserveSig]
		new void IAGetVertexBuffers(uint StartSlot, int NumBuffers, IntPtr ppVertexBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pStrides, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pOffsets);

		[PreserveSig]
		new void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, IntPtr Format, IntPtr Offset);

		[PreserveSig]
		new void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void GSGetShader(out ID3D11GeometryShader ppGeometryShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);

		[PreserveSig]
		new void VSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void VSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void GetPredication(out ID3D11Predicate ppPredicate, IntPtr pPredicateValue);

		[PreserveSig]
		new void GSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void GSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void OMGetRenderTargets(uint NumViews, IntPtr ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);

		[PreserveSig]
		new void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, IntPtr ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, IntPtr ppUnorderedAccessViews);

		[PreserveSig]
		new void OMGetBlendState(out ID3D11BlendState ppBlendState, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, IntPtr pSampleMask);

		[PreserveSig]
		new void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, IntPtr pStencilRef);

		[PreserveSig]
		new void SOGetTargets(uint NumBuffers, IntPtr ppSOTargets);

		[PreserveSig]
		new void RSGetState(out ID3D11RasterizerState ppRasterizerState);

		[PreserveSig]
		new void RSGetViewports(ref int pNumViewports, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[] pViewports);

		[PreserveSig]
		new void RSGetScissorRects(ref int pNumRects, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		[PreserveSig]
		new void HSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void HSGetShader(out ID3D11HullShader ppHullShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void HSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void DSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void DSGetShader(out ID3D11DomainShader ppDomainShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void DSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void CSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, IntPtr ppUnorderedAccessViews);

		[PreserveSig]
		new void CSGetShader(out ID3D11ComputeShader ppComputeShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void CSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void ClearState();

		[PreserveSig]
		new void Flush();

		[PreserveSig]
		new D3D11_DEVICE_CONTEXT_TYPE GetType();

		[PreserveSig]
		new uint GetContextFlags();

		[PreserveSig]
		new HRESULT FinishCommandList(bool RestoreDeferredContextState, out ID3D11CommandList ppCommandList);

		[PreserveSig]
		new void CopySubresourceRegion1(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox, uint CopyFlags);

		[PreserveSig]
		new void UpdateSubresource1(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch, uint CopyFlags);

		[PreserveSig]
		new void DiscardResource(ID3D11Resource pResource);

		[PreserveSig]
		new void DiscardView(ID3D11View pResourceView);

		[PreserveSig]
		new void VSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void HSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void DSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void GSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void PSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void CSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void VSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void HSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void DSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void GSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void PSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void CSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void SwapDeviceContextState(ID3DDeviceContextState pState, out ID3DDeviceContextState ppPreviousState);

		[PreserveSig]
		new void ClearView(ID3D11View pView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] Color, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] RECT[] pRect, int NumRects);

		[PreserveSig]
		new void DiscardView1(ID3D11View pResourceView, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] pRects, int NumRects);

		[PreserveSig]
		new HRESULT UpdateTileMappings(ID3D11Resource pTiledResource, int NumTiledResourceRegions, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILED_RESOURCE_COORDINATE[] pTiledResourceRegionStartCoordinates, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILE_REGION_SIZE[] pTiledResourceRegionSizes, ID3D11Buffer pTilePool, int NumRanges, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pRangeFlags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pTilePoolStartOffsets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pRangeTileCounts, uint Flags);

		[PreserveSig]
		new HRESULT CopyTileMappings(ID3D11Resource pDestTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pDestRegionStartCoordinate, ID3D11Resource pSourceTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pSourceRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pTileRegionSize, uint Flags);

		[PreserveSig]
		new void CopyTiles(ID3D11Resource pTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pTileRegionSize, ID3D11Buffer pBuffer, ulong BufferStartOffsetInBytes, uint Flags);

		[PreserveSig]
		new void UpdateTiles(ID3D11Resource pDestTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pDestTileRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pDestTileRegionSize, IntPtr pSourceTileData, uint Flags);

		[PreserveSig]
		new HRESULT ResizeTilePool(ID3D11Buffer pTilePool, ulong NewSizeInBytes);

		[PreserveSig]
		new void TiledResourceBarrier(ID3D11DeviceChild pTiledResourceOrViewAccessBeforeBarrier, ID3D11DeviceChild pTiledResourceOrViewAccessAfterBarrier);

		[PreserveSig]
		new bool IsAnnotationEnabled();

		[PreserveSig]
		new void SetMarkerInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		[PreserveSig]
		new void BeginEventInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		[PreserveSig]
		new void EndEvent();

		[PreserveSig]
		void Flush1(D3D11_CONTEXT_TYPE ContextType, IntPtr hEvent);

		[PreserveSig]
		void SetHardwareProtectionState(bool HwProtectionEnable);

		[PreserveSig]
		void GetHardwareProtectionState(out bool pHwProtectionEnable);
	}

	/// <summary>
	/// <para>
	/// The device context interface represents a device context; it is used to render commands. <c>ID3D11DeviceContext4</c> adds new
	/// methods to those in ID3D11DeviceContext3.
	/// </para>
	/// <note>This interface, introduced in the Windows 10 Creators Update, is the latest version of the ID3D11DeviceContext interface.
	/// Applications targetting Windows 10 Creators Update should use this interface instead of earlier versions.</note>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11devicecontext4
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11DeviceContext4")]
	[ComImport, Guid("917600da-f58c-4c33-98d8-3e15b390fa24"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11DeviceContext4 : ID3D11DeviceContext3, ID3D11DeviceContext2, ID3D11DeviceContext1, ID3D11DeviceContext, ID3D11DeviceChild
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
		new void VSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void PSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void PSSetShader(ID3D11PixelShader pPixelShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void PSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void VSSetShader(ID3D11VertexShader pVertexShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void DrawIndexed(uint IndexCount, uint StartIndexLocation, int BaseVertexLocation);

		[PreserveSig]
		new void Draw(uint VertexCount, uint StartVertexLocation);

		[PreserveSig]
		new HRESULT Map(ID3D11Resource pResource, uint Subresource, D3D11_MAP MapType, uint MapFlags, IntPtr pMappedResource);

		[PreserveSig]
		new void Unmap(ID3D11Resource pResource, uint Subresource);

		[PreserveSig]
		new void PSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void IASetInputLayout(ID3D11InputLayout pInputLayout);

		[PreserveSig]
		new void IASetVertexBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppVertexBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pStrides, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pOffsets);

		[PreserveSig]
		new void IASetIndexBuffer(ID3D11Buffer pIndexBuffer, DXGI_FORMAT Format, uint Offset);

		[PreserveSig]
		new void DrawIndexedInstanced(uint IndexCountPerInstance, uint InstanceCount, uint StartIndexLocation, int BaseVertexLocation, uint StartInstanceLocation);

		[PreserveSig]
		new void DrawInstanced(uint VertexCountPerInstance, uint InstanceCount, uint StartVertexLocation, uint StartInstanceLocation);

		[PreserveSig]
		new void GSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void GSSetShader(ID3D11GeometryShader pShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void IASetPrimitiveTopology(D3D_PRIMITIVE_TOPOLOGY Topology);

		[PreserveSig]
		new void VSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void VSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void Begin(ID3D11Asynchronous pAsync);

		[PreserveSig]
		new void End(ID3D11Asynchronous pAsync);

		[PreserveSig]
		new HRESULT GetData(ID3D11Asynchronous pAsync, IntPtr pData, uint DataSize, uint GetDataFlags);

		[PreserveSig]
		new void SetPredication(ID3D11Predicate pPredicate, bool PredicateValue);

		[PreserveSig]
		new void GSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void GSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void OMSetRenderTargets(int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView);

		[PreserveSig]
		new void OMSetRenderTargetsAndUnorderedAccessViews(int NumRTVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11RenderTargetView[] ppRenderTargetViews, ID3D11DepthStencilView pDepthStencilView, uint UAVStartSlot, int NumUAVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ID3D11UnorderedAccessView[] ppUnorderedAccessViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] pUAVInitialCounts);

		[PreserveSig]
		new void OMSetBlendState(ID3D11BlendState pBlendState, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, uint SampleMask);

		[PreserveSig]
		new void OMSetDepthStencilState(ID3D11DepthStencilState pDepthStencilState, uint StencilRef);

		[PreserveSig]
		new void SOSetTargets(int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11Buffer[] ppSOTargets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] pOffsets);

		[PreserveSig]
		new void DrawAuto();

		[PreserveSig]
		new void DrawIndexedInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void DrawInstancedIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void Dispatch(uint ThreadGroupCountX, uint ThreadGroupCountY, uint ThreadGroupCountZ);

		[PreserveSig]
		new void DispatchIndirect(ID3D11Buffer pBufferForArgs, uint AlignedByteOffsetForArgs);

		[PreserveSig]
		new void RSSetState(ID3D11RasterizerState pRasterizerState);

		[PreserveSig]
		new void RSSetViewports(int NumViewports, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[] pViewports);

		[PreserveSig]
		new void RSSetScissorRects(int NumRects, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		[PreserveSig]
		new void CopySubresourceRegion(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox);

		[PreserveSig]
		new void CopyResource(ID3D11Resource pDstResource, ID3D11Resource pSrcResource);

		[PreserveSig]
		new void UpdateSubresource(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch);

		[PreserveSig]
		new void CopyStructureCount(ID3D11Buffer pDstBuffer, uint DstAlignedByteOffset, ID3D11UnorderedAccessView pSrcView);

		[PreserveSig]
		new void ClearRenderTargetView(ID3D11RenderTargetView pRenderTargetView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] ColorRGBA);

		[PreserveSig]
		new void ClearUnorderedAccessViewUint(ID3D11UnorderedAccessView pUnorderedAccessView, [In][Out][MarshalAs(UnmanagedType.LPArray)] uint[] Values);

		[PreserveSig]
		new void ClearUnorderedAccessViewFloat(ID3D11UnorderedAccessView pUnorderedAccessView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] Values);

		[PreserveSig]
		new void ClearDepthStencilView(ID3D11DepthStencilView pDepthStencilView, uint ClearFlags, float Depth, byte Stencil);

		[PreserveSig]
		new void GenerateMips(ID3D11ShaderResourceView pShaderResourceView);

		[PreserveSig]
		new void SetResourceMinLOD(ID3D11Resource pResource, float MinLOD);

		[PreserveSig]
		new float GetResourceMinLOD(ID3D11Resource pResource);

		[PreserveSig]
		new void ResolveSubresource(ID3D11Resource pDstResource, uint DstSubresource, ID3D11Resource pSrcResource, uint SrcSubresource, DXGI_FORMAT Format);

		[PreserveSig]
		new void ExecuteCommandList(ID3D11CommandList pCommandList, bool RestoreContextState);

		[PreserveSig]
		new void HSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void HSSetShader(ID3D11HullShader pHullShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void HSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void HSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void DSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void DSSetShader(ID3D11DomainShader pDomainShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void DSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void DSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void CSSetShaderResources(uint StartSlot, int NumViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11ShaderResourceView[] ppShaderResourceViews);

		[PreserveSig]
		new void CSSetUnorderedAccessViews(uint StartSlot, int NumUAVs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11UnorderedAccessView[] ppUnorderedAccessViews, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pUAVInitialCounts);

		[PreserveSig]
		new void CSSetShader(ID3D11ComputeShader pComputeShader, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11ClassInstance[] ppClassInstances, int NumClassInstances);

		[PreserveSig]
		new void CSSetSamplers(uint StartSlot, int NumSamplers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11SamplerState[] ppSamplers);

		[PreserveSig]
		new void CSSetConstantBuffers(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers);

		[PreserveSig]
		new void VSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void PSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void PSGetShader(out ID3D11PixelShader ppPixelShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void PSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void VSGetShader(out ID3D11VertexShader ppVertexShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void PSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void IAGetInputLayout(out ID3D11InputLayout ppInputLayout);

		[PreserveSig]
		new void IAGetVertexBuffers(uint StartSlot, int NumBuffers, IntPtr ppVertexBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pStrides, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pOffsets);

		[PreserveSig]
		new void IAGetIndexBuffer(out ID3D11Buffer pIndexBuffer, IntPtr Format, IntPtr Offset);

		[PreserveSig]
		new void GSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void GSGetShader(out ID3D11GeometryShader ppGeometryShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void IAGetPrimitiveTopology(out D3D_PRIMITIVE_TOPOLOGY pTopology);

		[PreserveSig]
		new void VSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void VSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void GetPredication(out ID3D11Predicate ppPredicate, IntPtr pPredicateValue);

		[PreserveSig]
		new void GSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void GSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void OMGetRenderTargets(uint NumViews, IntPtr ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView);

		[PreserveSig]
		new void OMGetRenderTargetsAndUnorderedAccessViews(uint NumRTVs, IntPtr ppRenderTargetViews, out ID3D11DepthStencilView ppDepthStencilView, uint UAVStartSlot, uint NumUAVs, IntPtr ppUnorderedAccessViews);

		[PreserveSig]
		new void OMGetBlendState(out ID3D11BlendState ppBlendState, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] BlendFactor, IntPtr pSampleMask);

		[PreserveSig]
		new void OMGetDepthStencilState(out ID3D11DepthStencilState ppDepthStencilState, IntPtr pStencilRef);

		[PreserveSig]
		new void SOGetTargets(uint NumBuffers, IntPtr ppSOTargets);

		[PreserveSig]
		new void RSGetState(out ID3D11RasterizerState ppRasterizerState);

		[PreserveSig]
		new void RSGetViewports(ref int pNumViewports, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] D3D11_VIEWPORT[] pViewports);

		[PreserveSig]
		new void RSGetScissorRects(ref int pNumRects, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RECT[] pRects);

		[PreserveSig]
		new void HSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void HSGetShader(out ID3D11HullShader ppHullShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void HSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void HSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void DSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void DSGetShader(out ID3D11DomainShader ppDomainShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void DSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void DSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void CSGetShaderResources(uint StartSlot, uint NumViews, IntPtr ppShaderResourceViews);

		[PreserveSig]
		new void CSGetUnorderedAccessViews(uint StartSlot, uint NumUAVs, IntPtr ppUnorderedAccessViews);

		[PreserveSig]
		new void CSGetShader(out ID3D11ComputeShader ppComputeShader, IntPtr ppClassInstances, IntPtr pNumClassInstances);

		[PreserveSig]
		new void CSGetSamplers(uint StartSlot, uint NumSamplers, IntPtr ppSamplers);

		[PreserveSig]
		new void CSGetConstantBuffers(uint StartSlot, uint NumBuffers, IntPtr ppConstantBuffers);

		[PreserveSig]
		new void ClearState();

		[PreserveSig]
		new void Flush();

		[PreserveSig]
		new D3D11_DEVICE_CONTEXT_TYPE GetType();

		[PreserveSig]
		new uint GetContextFlags();

		[PreserveSig]
		new HRESULT FinishCommandList(bool RestoreDeferredContextState, out ID3D11CommandList ppCommandList);

		[PreserveSig]
		new void CopySubresourceRegion1(ID3D11Resource pDstResource, uint DstSubresource, uint DstX, uint DstY, uint DstZ, ID3D11Resource pSrcResource, uint SrcSubresource, IntPtr pSrcBox, uint CopyFlags);

		[PreserveSig]
		new void UpdateSubresource1(ID3D11Resource pDstResource, uint DstSubresource, IntPtr pDstBox, IntPtr pSrcData, uint SrcRowPitch, uint SrcDepthPitch, uint CopyFlags);

		[PreserveSig]
		new void DiscardResource(ID3D11Resource pResource);

		[PreserveSig]
		new void DiscardView(ID3D11View pResourceView);

		[PreserveSig]
		new void VSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void HSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void DSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void GSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void PSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void CSSetConstantBuffers1(uint StartSlot, int NumBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ID3D11Buffer[] ppConstantBuffers, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void VSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void HSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void DSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void GSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void PSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void CSGetConstantBuffers1(uint StartSlot, int NumBuffers, IntPtr ppConstantBuffers, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pFirstConstant, [Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] pNumConstants);

		[PreserveSig]
		new void SwapDeviceContextState(ID3DDeviceContextState pState, out ID3DDeviceContextState ppPreviousState);

		[PreserveSig]
		new void ClearView(ID3D11View pView, [In][Out][MarshalAs(UnmanagedType.LPArray)] float[] Color, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] RECT[] pRect, int NumRects);

		[PreserveSig]
		new void DiscardView1(ID3D11View pResourceView, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RECT[] pRects, int NumRects);

		[PreserveSig]
		new HRESULT UpdateTileMappings(ID3D11Resource pTiledResource, int NumTiledResourceRegions, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILED_RESOURCE_COORDINATE[] pTiledResourceRegionStartCoordinates, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D3D11_TILE_REGION_SIZE[] pTiledResourceRegionSizes, ID3D11Buffer pTilePool, int NumRanges, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pRangeFlags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pTilePoolStartOffsets, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] pRangeTileCounts, uint Flags);

		[PreserveSig]
		new HRESULT CopyTileMappings(ID3D11Resource pDestTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pDestRegionStartCoordinate, ID3D11Resource pSourceTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pSourceRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pTileRegionSize, uint Flags);

		[PreserveSig]
		new void CopyTiles(ID3D11Resource pTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pTileRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pTileRegionSize, ID3D11Buffer pBuffer, ulong BufferStartOffsetInBytes, uint Flags);

		[PreserveSig]
		new void UpdateTiles(ID3D11Resource pDestTiledResource, ref D3D11_TILED_RESOURCE_COORDINATE pDestTileRegionStartCoordinate, ref D3D11_TILE_REGION_SIZE pDestTileRegionSize, IntPtr pSourceTileData, uint Flags);

		[PreserveSig]
		new HRESULT ResizeTilePool(ID3D11Buffer pTilePool, ulong NewSizeInBytes);

		[PreserveSig]
		new void TiledResourceBarrier(ID3D11DeviceChild pTiledResourceOrViewAccessBeforeBarrier, ID3D11DeviceChild pTiledResourceOrViewAccessAfterBarrier);

		[PreserveSig]
		new bool IsAnnotationEnabled();

		[PreserveSig]
		new void SetMarkerInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		[PreserveSig]
		new void BeginEventInt([MarshalAs(UnmanagedType.LPWStr)] string pLabel, int Data);

		[PreserveSig]
		new void EndEvent();

		[PreserveSig]
		new void Flush1(D3D11_CONTEXT_TYPE ContextType, IntPtr hEvent);

		[PreserveSig]
		new void SetHardwareProtectionState(bool HwProtectionEnable);

		[PreserveSig]
		new void GetHardwareProtectionState(out bool pHwProtectionEnable);

		[PreserveSig]
		HRESULT Signal(ID3D11Fence pFence, ulong Value);

		[PreserveSig]
		HRESULT Wait(ID3D11Fence pFence, ulong Value);
	}

	/// <summary>
	/// <para>Represents a fence, an object used for synchronization of the CPU and one or more GPUs.</para>
	/// <para>
	/// This interface is equivalent to the Direct3D 12 ID3D12Fence interface, and is also used for synchronization between Direct3D 11 and
	/// Direct3D 12 in interop scenarios.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11fence
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11Fence")]
	[ComImport, Guid("affde9d1-1df7-4bb7-8a34-0f46251dab80"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Fence : ID3D11DeviceChild
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
		new HRESULT SetPrivateDataInterface(in Guid guid, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pData);

		/// <summary>
		/// <para>Creates a shared handle to a fence object.</para>
		/// <para>
		/// This method is equivalent to the Direct3D 12 ID3D12Device::CreateSharedHandle method, and it applies in scenarios involving
		/// interoperation between Direct3D 11 and Direct3D 12. In DirecX 11, you can open the shared fence handle with the
		/// ID3D11Device5::OpenSharedFence method. In DirecX 12, you can open the shared fence handle with the
		/// ID3D12Device::OpenSharedHandle method.
		/// </para>
		/// </summary>
		/// <param name="pAttributes">
		/// <para>Type: <c>const SECURITY_ATTRIBUTES*</c></para>
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members: an optional security
		/// descriptor, and a <c>Boolean</c> value that determines whether child processes can inherit the returned handle.
		/// </para>
		/// <para>
		/// Set this parameter to <c>NULL</c> if you want child processes that the application might create to not inherit the handle
		/// returned by <c>CreateSharedHandle</c>, and if you want the resource that is associated with the returned handle to get a default
		/// security descriptor.
		/// </para>
		/// <para>
		/// The <c>lpSecurityDescriptor</c> member of the structure specifies a SECURITY_DESCRIPTOR for the resource. Set this member to
		/// <c>NULL</c> if you want the runtime to assign a default security descriptor to the resource that is associated with the returned
		/// handle. The ACLs in the default security descriptor for the resource come from the primary or impersonation token of the
		/// creator. For more info, see Synchronization Object Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="dwAccess">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Currently the only value this parameter accepts is GENERIC_ALL.</para>
		/// </param>
		/// <param name="lpName">
		/// <para>Type: <c>LPCWSTR</c></para>
		/// <para>
		/// A <c>NULL</c>-terminated <c>UNICODE</c> string that contains the name to associate with the shared heap. The name is limited to
		/// MAX_PATH characters. Name comparison is case-sensitive.
		/// </para>
		/// <para>
		/// If <c>Name</c> matches the name of an existing resource, <c>CreateSharedHandle</c> fails with DXGI_ERROR_NAME_ALREADY_EXISTS.
		/// This occurs because these objects share the same namespace.
		/// </para>
		/// <para>
		/// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace. The remainder
		/// of the name can contain any character except the backslash character (\). For more information, see Kernel Object Namespaces.
		/// Fast user switching is implemented using Terminal Services sessions. Kernel object names must follow the guidelines outlined for
		/// Terminal Services so that applications can support multiple users.
		/// </para>
		/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
		/// </param>
		/// <param name="pHandle">
		/// <para>Type: <c>HANDLE*</c></para>
		/// <para>
		/// A pointer to a variable that receives the NT HANDLE value to the resource to share. You can use this handle in calls to access
		/// the resource.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful; otherwise, returns one of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>DXGI_ERROR_INVALID_CALL if one of the parameters is invalid.</description>
		/// </item>
		/// <item>
		/// <description>
		/// DXGI_ERROR_NAME_ALREADY_EXISTS if the supplied name of the resource to share is already associated with another resource.
		/// </description>
		/// </item>
		/// <item>
		/// <description>E_ACCESSDENIED if the object is being created in a protected namespace.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY if sufficient memory is not available to create the handle.</description>
		/// </item>
		/// <item>
		/// <description>Possibly other error codes that are described in the Direct3D 11 Return Codes topic.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// In order to create a shared handle for the specified fence, the fence must have been created with either the
		/// <c>D3D11_FENCE_FLAG_SHARED</c> or <c>D3D11_FENCE_FLAG_SHARED_CROSS_ADAPTER</c> flags. For more information see the
		/// D3D11_FENCE_FLAG enumeration.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11fence-createsharedhandle HRESULT CreateSharedHandle(
		// [in, optional] const SECURITY_ATTRIBUTES *pAttributes, DWORD dwAccess, [in, optional] LPCWSTR lpName, [out] HANDLE *pHandle );
		[PreserveSig]
		HRESULT CreateSharedHandle([In, Optional] SECURITY_ATTRIBUTES? pAttributes, ACCESS_MASK dwAccess,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string? lpName, out HANDLE pHandle);

		/// <summary>
		/// <para>Gets the current value of the fence.</para>
		/// <para>
		/// This member function is equivalent to the Direct3D 12 ID3D12Fence::GetCompletedValue member function, and applies between
		/// Direct3D 11 and Direct3D 12 in interop scenarios.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>Returns the current value of the fence.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11fence-getcompletedvalue UINT64 GetCompletedValue();
		[PreserveSig]
		ulong GetCompletedValue();

		/// <summary>
		/// <para>Specifies an event that should be fired when the fence reaches a certain value.</para>
		/// <para>
		/// This member function is equivalent to the Direct3D 12 ID3D12Fence::SetEventOnCompletion member function, and applies between
		/// Direct3D 11 and Direct3D 12 in interop scenarios.
		/// </para>
		/// </summary>
		/// <param name="Value">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The fence value when the event is to be signaled.</para>
		/// </param>
		/// <param name="hEvent">
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the event object.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns <c>E_OUTOFMEMORY</c> if the kernel components don’t have sufficient memory to store the event in a list. See
		/// Direct3D 11 Return Codes for other possible return values.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nf-d3d11_3-id3d11fence-seteventoncompletion HRESULT
		// SetEventOnCompletion( UINT64 Value, HANDLE hEvent );
		[PreserveSig]
		HRESULT SetEventOnCompletion(ulong Value, HEVENT hEvent);
	}

	/// <summary>Represents a query object for querying information from the graphics processing unit (GPU).</summary>
	/// <remarks>
	/// <para>A query can be created with ID3D11Device3::CreateQuery1.</para>
	/// <para>
	/// Query data is typically gathered by issuing an ID3D11DeviceContext::Begin command, issuing some graphics commands, issuing an
	/// ID3D11DeviceContext::End command, and then calling ID3D11DeviceContext::GetData to get data about what happened in between the Begin
	/// and End calls. The data returned by <c>GetData</c> will be different depending on the type of query.
	/// </para>
	/// <para>There are, however, some queries that do not require calls to Begin. For a list of possible queries see D3D11_QUERY.</para>
	/// <para>
	/// When using a query that does not require a call to Begin, it still requires a call to End. The call to <c>End</c> causes the data
	/// returned by GetData to be accurate up until the last call to <c>End</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11query1
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11Query1")]
	[ComImport, Guid("631b4766-36dc-461d-8db6-c47e13e60916"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Query1 : ID3D11Query, ID3D11Asynchronous, ID3D11DeviceChild
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
		new uint GetDataSize();

		[PreserveSig]
		new void GetDesc(out D3D11_QUERY_DESC pDesc);

		[PreserveSig]
		void GetDesc1(out D3D11_QUERY_DESC1 pDesc1);
	}

	/// <summary>
	/// The rasterizer-state interface holds a description for rasterizer state that you can bind to the rasterizer stage. This
	/// rasterizer-state interface supports forced sample count and conservative rasterization mode.
	/// </summary>
	/// <remarks>
	/// To create a rasterizer-state object, call ID3D11Device3::CreateRasterizerState2. To bind the rasterizer-state object to the
	/// rasterizer stage, call ID3D11DeviceContext::RSSetState.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11rasterizerstate2
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11RasterizerState2")]
	[ComImport, Guid("6fbd02fb-209f-46c4-b059-2ed15586a6ac"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11RasterizerState2 : ID3D11RasterizerState1, ID3D11RasterizerState, ID3D11DeviceChild
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
		new void GetDesc(out D3D11_RASTERIZER_DESC pDesc);

		[PreserveSig]
		new void GetDesc1(out D3D11_RASTERIZER_DESC1 pDesc);

		[PreserveSig]
		void GetDesc2(out D3D11_RASTERIZER_DESC2 pDesc);
	}

	/// <summary>A render-target-view interface represents the render-target subresources that can be accessed during rendering.</summary>
	/// <remarks>
	/// <para>
	/// To create a render-target view, call ID3D11Device3::CreateRenderTargetView1. To bind a render-target view to the pipeline, call ID3D11DeviceContext::OMSetRenderTargets.
	/// </para>
	/// <para>
	/// A render target is a resource that can be written by the output-merger stage at the end of a render pass. Each render target can
	/// also have a corresponding depth-stencil view.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11rendertargetview1
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11RenderTargetView1")]
	[ComImport, Guid("ffbe2e23-f011-418a-ac56-5ceed7c5b94b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11RenderTargetView1 : ID3D11RenderTargetView, ID3D11View, ID3D11DeviceChild
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
		new void GetResource(out ID3D11Resource ppResource);

		[PreserveSig]
		new void GetDesc(out D3D11_RENDER_TARGET_VIEW_DESC pDesc);

		[PreserveSig]
		void GetDesc1(out D3D11_RENDER_TARGET_VIEW_DESC1 pDesc1);
	}

	/// <summary>
	/// A shader-resource-view interface represents the subresources a shader can access during rendering. Examples of shader resources
	/// include a constant buffer, a texture buffer, and a texture.
	/// </summary>
	/// <remarks>
	/// <para>To create a shader-resource view, call ID3D11Device3::CreateShaderResourceView1.</para>
	/// <para>
	/// A shader-resource view is required when binding a resource to a shader stage; the binding occurs by calling
	/// ID3D11DeviceContext::GSSetShaderResources, ID3D11DeviceContext::VSSetShaderResources or ID3D11DeviceContext::PSSetShaderResources.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11shaderresourceview1
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11ShaderResourceView1")]
	[ComImport, Guid("91308b87-9040-411d-8c67-c39253ce3802"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11ShaderResourceView1 : ID3D11ShaderResourceView, ID3D11View, ID3D11DeviceChild
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
		new void GetResource(out ID3D11Resource ppResource);

		[PreserveSig]
		new void GetDesc(out D3D11_SHADER_RESOURCE_VIEW_DESC pDesc);

		[PreserveSig]
		void GetDesc1(out D3D11_SHADER_RESOURCE_VIEW_DESC1 pDesc1);
	}

	/// <summary>A 2D texture interface represents texel data, which is structured memory.</summary>
	/// <remarks>
	/// <para>
	/// To create an empty Texture2D resource, call ID3D11Device3::CreateTexture2D1. For info about how to create a 2D texture, see How to:
	/// Create a Texture.
	/// </para>
	/// <para>
	/// Textures can't be bound directly to the pipeline; instead, a view must be created and bound. Using a view, texture data can be
	/// interpreted at run time within certain restrictions. To use the texture as a render-target or depth-stencil resource, call
	/// ID3D11Device3::CreateRenderTargetView1, and ID3D11Device::CreateDepthStencilView, respectively. To use the texture as an input to a
	/// shader, call ID3D11Device3::CreateShaderResourceView1.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11texture2d1
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11Texture2D1")]
	[ComImport, Guid("51218251-1e33-4617-9ccb-4d3a4367e7bb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Texture2D1 : ID3D11Texture2D, ID3D11Resource, ID3D11DeviceChild
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
		new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		[PreserveSig]
		new void SetEvictionPriority(uint EvictionPriority);

		[PreserveSig]
		new uint GetEvictionPriority();

		[PreserveSig]
		new void GetDesc(out D3D11_TEXTURE2D_DESC pDesc);

		[PreserveSig]
		void GetDesc1(out D3D11_TEXTURE2D_DESC1 pDesc);
	}

	/// <summary>A 3D texture interface represents texel data, which is structured memory.</summary>
	/// <remarks>
	/// <para>
	/// To create an empty Texture3D resource, call ID3D11Device3::CreateTexture3D1. For info about how to create a 2D texture, which is
	/// similar to creating a 3D texture, see How to: Create a Texture.
	/// </para>
	/// <para>
	/// Textures can't be bound directly to the pipeline; instead, a view must be created and bound. Using a view, texture data can be
	/// interpreted at run time within certain restrictions. To use the texture as a render-target or depth-stencil resource, call
	/// ID3D11Device3::CreateRenderTargetView1, and ID3D11Device::CreateDepthStencilView, respectively. To use the texture as an input to a
	/// shader, call ID3D11Device3::CreateShaderResourceView1.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11texture3d1
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11Texture3D1")]
	[ComImport, Guid("0c711683-2853-4846-9bb0-f3e60639e46a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11Texture3D1 : ID3D11Texture3D, ID3D11Resource, ID3D11DeviceChild
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
		new void GetType(out D3D11_RESOURCE_DIMENSION pResourceDimension);

		[PreserveSig]
		new void SetEvictionPriority(uint EvictionPriority);

		[PreserveSig]
		new uint GetEvictionPriority();

		[PreserveSig]
		new void GetDesc(out D3D11_TEXTURE3D_DESC pDesc);

		[PreserveSig]
		void GetDesc1(out D3D11_TEXTURE3D_DESC1 pDesc);
	}

	/// <summary>An unordered-access-view interface represents the parts of a resource the pipeline can access during rendering.</summary>
	/// <remarks>
	/// <para>To create a view for an unordered access resource, call ID3D11Device3::CreateUnorderedAccessView1.</para>
	/// <para>
	/// All resources must be bound to the pipeline before they can be accessed. Call ID3D11DeviceContext::CSSetUnorderedAccessViews to bind
	/// an unordered access view to a compute shader; call ID3D11DeviceContext::OMSetRenderTargetsAndUnorderedAccessViews to bind an
	/// unordered access view to a pixel shader.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/nn-d3d11_3-id3d11unorderedaccessview1
	[PInvokeData("d3d11_3.h", MSDNShortId = "NN:d3d11_3.ID3D11UnorderedAccessView1")]
	[ComImport, Guid("7b3b6153-a886-4544-ab37-6537c8500403"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D11UnorderedAccessView1 : ID3D11UnorderedAccessView, ID3D11View, ID3D11DeviceChild
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
		new void GetResource(out ID3D11Resource ppResource);

		[PreserveSig]
		new void GetDesc(out D3D11_UNORDERED_ACCESS_VIEW_DESC pDesc);

		[PreserveSig]
		void GetDesc1(out D3D11_UNORDERED_ACCESS_VIEW_DESC1 pDesc1);
	}

	/// <summary>Describes a query.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_query_desc1 typedef struct D3D11_QUERY_DESC1 {
	// D3D11_QUERY Query; UINT MiscFlags; D3D11_CONTEXT_TYPE ContextType; } D3D11_QUERY_DESC1;
	[PInvokeData("d3d11_3.h", MSDNShortId = "NS:d3d11_3.D3D11_QUERY_DESC1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_QUERY_DESC1
	{
		/// <summary>A D3D11_QUERY-typed value that specifies the type of query.</summary>
		public D3D11_QUERY Query;

		/// <summary>
		/// A combination of D3D11_QUERY_MISC_FLAG-typed values that are combined by using a bitwise OR operation. The resulting value
		/// specifies query behavior.
		/// </summary>
		public D3D11_QUERY_MISC_FLAG MiscFlags;

		/// <summary>A D3D11_CONTEXT_TYPE-typed value that specifies the context for the query.</summary>
		public D3D11_CONTEXT_TYPE ContextType;
	}

	/// <summary>Describes rasterizer state.</summary>
	/// <remarks>
	/// <para>
	/// Rasterizer state defines the behavior of the rasterizer stage. To create a rasterizer-state object, call
	/// ID3D11Device3::CreateRasterizerState2. To set rasterizer state, call ID3D11DeviceContext::RSSetState.
	/// </para>
	/// <para>If you do not specify some rasterizer state, the Direct3D runtime uses the following default values for rasterizer state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description><c>FillMode</c></description>
	/// <description>Solid</description>
	/// </item>
	/// <item>
	/// <description><c>CullMode</c></description>
	/// <description>Back</description>
	/// </item>
	/// <item>
	/// <description><c>FrontCounterClockwise</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>DepthBias</c></description>
	/// <description>0</description>
	/// </item>
	/// <item>
	/// <description><c>SlopeScaledDepthBias</c></description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description><c>DepthBiasClamp</c></description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description><c>DepthClipEnable</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// <item>
	/// <description><c>ScissorEnable</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>MultisampleEnable</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>AntialiasedLineEnable</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description><c>ForcedSampleCount</c></description>
	/// <description>0</description>
	/// </item>
	/// <item>
	/// <description><c>ConservativeRaster</c></description>
	/// <description><c>D3D11_CONSERVATIVE_RASTERIZATION_MODE_OFF</c></description>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c>  For feature levels 9.1, 9.2, 9.3, and 10.0, if you set <c>MultisampleEnable</c> to <c>FALSE</c>, the runtime renders
	/// all points, lines, and triangles without anti-aliasing even for render targets with a sample count greater than 1. For feature
	/// levels 10.1 and higher, the setting of <c>MultisampleEnable</c> has no effect on points and triangles with regard to MSAA and
	/// impacts only the selection of the line-rendering algorithm as shown in this table:
	/// </para>
	/// <para></para>
	/// <list type="table">
	/// <listheader>
	/// <description>Line-rendering algorithm</description>
	/// <description><c>MultisampleEnable</c></description>
	/// <description><c>AntialiasedLineEnable</c></description>
	/// </listheader>
	/// <item>
	/// <description>Aliased</description>
	/// <description><c>FALSE</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>Alpha antialiased</description>
	/// <description><c>FALSE</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// <item>
	/// <description>Quadrilateral</description>
	/// <description><c>TRUE</c></description>
	/// <description><c>FALSE</c></description>
	/// </item>
	/// <item>
	/// <description>Quadrilateral</description>
	/// <description><c>TRUE</c></description>
	/// <description><c>TRUE</c></description>
	/// </item>
	/// </list>
	/// <para>
	/// The settings of the <c>MultisampleEnable</c> and <c>AntialiasedLineEnable</c> members apply only to multisample antialiasing (MSAA)
	/// render targets (that is, render targets with sample counts greater than 1). Because of the differences in feature-level behavior and
	/// as long as you aren’t performing any line drawing or don’t mind that lines render as quadrilaterals, we recommend that you always
	/// set <c>MultisampleEnable</c> to <c>TRUE</c> whenever you render on MSAA render targets.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_rasterizer_desc2 typedef struct D3D11_RASTERIZER_DESC2 {
	// D3D11_FILL_MODE FillMode; D3D11_CULL_MODE CullMode; BOOL FrontCounterClockwise; INT DepthBias; FLOAT DepthBiasClamp; FLOAT
	// SlopeScaledDepthBias; BOOL DepthClipEnable; BOOL ScissorEnable; BOOL MultisampleEnable; BOOL AntialiasedLineEnable; UINT
	// ForcedSampleCount; D3D11_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster; } D3D11_RASTERIZER_DESC2;
	[PInvokeData("d3d11_3.h", MSDNShortId = "NS:d3d11_3.D3D11_RASTERIZER_DESC2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D11_RASTERIZER_DESC2
	{
		/// <summary>A D3D11_FILL_MODE-typed value that determines the fill mode to use when rendering.</summary>
		public D3D11_FILL_MODE FillMode;

		/// <summary>A D3D11_CULL_MODE-typed value that indicates that triangles facing the specified direction are not drawn.</summary>
		public D3D11_CULL_MODE CullMode;

		/// <summary>
		/// Specifies whether a triangle is front- or back-facing. If <c>TRUE</c>, a triangle will be considered front-facing if its
		/// vertices are counter-clockwise on the render target and considered back-facing if they are clockwise. If <c>FALSE</c>, the
		/// opposite is true.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool FrontCounterClockwise;

		/// <summary>Depth value added to a given pixel. For info about depth bias, see Depth Bias.</summary>
		public int DepthBias;

		/// <summary>Maximum depth bias of a pixel. For info about depth bias, see Depth Bias.</summary>
		public float DepthBiasClamp;

		/// <summary>Scalar on a given pixel's slope. For info about depth bias, see Depth Bias.</summary>
		public float SlopeScaledDepthBias;

		/// <summary>
		///   <para>Type: <c>BOOL</c></para>
		///   <para>Specifies whether to enable clipping based on distance.</para>
		///   <para>The hardware always performs x and y clipping of rasterized coordinates. When <c>DepthClipEnable</c> is set to the default–<c>TRUE</c>, the hardware also clips the z value (that is, the hardware performs the last step of the following algorithm).</para>
		///   <code language="none" title="syntax"><![CDATA[0 < w
		///-w <= x <= w(or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
		///-w <= y <= w(or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)
		///0 <= z <= w]]></code>
		///   <para>When you set <c>DepthClipEnable</c> to <c>FALSE</c>, the hardware skips the z clipping (that is, the last step in the preceding algorithm). However, the hardware still performs the "0 &lt; w" clipping. When z clipping is disabled, improper depth ordering at the pixel level might result. However, when z clipping is disabled, stencil shadow implementations are simplified. In other words, you can avoid complex special-case handling for geometry that goes beyond the back clipping plane.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DepthClipEnable;

		/// <summary>Specifies whether to enable scissor-rectangle culling. All pixels outside an active scissor rectangle are culled.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ScissorEnable;

		/// <summary>
		/// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render
		/// targets. Set to <c>TRUE</c> to use the quadrilateral line anti-aliasing algorithm and to <c>FALSE</c> to use the alpha line
		/// anti-aliasing algorithm. For more info about this member, see Remarks.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool MultisampleEnable;

		/// <summary>
		/// Specifies whether to enable line antialiasing; only applies if doing line drawing and <c>MultisampleEnable</c> is <c>FALSE</c>.
		/// For more info about this member, see Remarks.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool AntialiasedLineEnable;

		/// <summary>
		/// <para>
		/// The sample count that is forced while UAV rendering or rasterizing. Valid values are 0, 1, 2, 4, 8, and optionally 16. 0
		/// indicates that the sample count is not forced.
		/// </para>
		/// <para>
		/// <c>Note</c>  If you want to render with <c>ForcedSampleCount</c> set to 1 or greater, you must follow these guidelines:
		/// Otherwise, rendering behavior is undefined. For info about how to configure depth-stencil, see Configuring Depth-Stencil Functionality.
		/// </para>
		/// <para></para>
		/// </summary>
		public uint ForcedSampleCount;

		/// <summary>
		/// A D3D11_CONSERVATIVE_RASTERIZATION_MODE-typed value that identifies whether conservative rasterization is on or off.
		/// </summary>
		public D3D11_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster;
	}

	/*
	D3D11_TEXTURE_LAYOUT

	CD3D11_QUERY_DESC1
	CD3D11_RASTERIZER_DESC2
	CD3D11_RENDER_TARGET_VIEW_DESC1
	CD3D11_SHADER_RESOURCE_VIEW_DESC1
	CD3D11_TEXTURE2D_DESC1
	CD3D11_TEXTURE3D_DESC1
	CD3D11_UNORDERED_ACCESS_VIEW_DESC1
	D3D11_RENDER_TARGET_VIEW_DESC1
	D3D11_SHADER_RESOURCE_VIEW_DESC1
	D3D11_TEX2D_ARRAY_RTV1
	D3D11_TEX2D_ARRAY_SRV1
	D3D11_TEX2D_ARRAY_UAV1
	D3D11_TEX2D_RTV1
	D3D11_TEX2D_SRV1
	D3D11_TEX2D_UAV1
	D3D11_TEXTURE2D_DESC1
	D3D11_TEXTURE3D_DESC1
	D3D11_UNORDERED_ACCESS_VIEW_DESC1
	*/
}