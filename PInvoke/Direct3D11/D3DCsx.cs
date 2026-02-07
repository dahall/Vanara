namespace Vanara.PInvoke;

/// <summary>Provides methods and types for working with Direct3D 11.</summary>
public static partial class D3D11
{
	/// <summary/>
	public const int D3DX11_FFT_MAX_DIMENSIONS = 32;

	/// <summary/>
	public const int D3DX11_FFT_MAX_PRECOMPUTE_BUFFERS = 4;

	/// <summary/>
	public const int D3DX11_FFT_MAX_TEMP_BUFFERS = 4;

	private const string Lib_D3dcsx = "d3dcsx.dll";

	/// <summary>FFT creation flags.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ne-d3dcsx-d3dx11_fft_create_flag typedef enum D3DX11_FFT_CREATE_FLAG {
	// D3DX11_FFT_CREATE_FLAG_NO_PRECOMPUTE_BUFFERS = 0x01L } ;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NE:d3dcsx.D3DX11_FFT_CREATE_FLAG")]
	[Flags]
	public enum D3DX11_FFT_CREATE_FLAG
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x01L</para>
		/// <para>Do not AddRef or Release temp and precompute buffers, caller is responsible for holding references to these buffers.</para>
		/// </summary>
		D3DX11_FFT_CREATE_FLAG_NO_PRECOMPUTE_BUFFERS = 0x1,
	}

	/// <summary>FFT data types.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ne-d3dcsx-d3dx11_fft_data_type typedef enum D3DX11_FFT_DATA_TYPE {
	// D3DX11_FFT_DATA_TYPE_REAL, D3DX11_FFT_DATA_TYPE_COMPLEX } ;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NE:d3dcsx.D3DX11_FFT_DATA_TYPE")]
	public enum D3DX11_FFT_DATA_TYPE
	{
		/// <summary>Real numbers.</summary>
		D3DX11_FFT_DATA_TYPE_REAL,

		/// <summary>Complex numbers.</summary>
		D3DX11_FFT_DATA_TYPE_COMPLEX,
	}

	/// <summary>Number of dimensions for FFT data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ne-d3dcsx-d3dx11_fft_dim_mask typedef enum D3DX11_FFT_DIM_MASK {
	// D3DX11_FFT_DIM_MASK_1D = 0x1, D3DX11_FFT_DIM_MASK_2D = 0x3, D3DX11_FFT_DIM_MASK_3D = 0x7 } ;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NE:d3dcsx.D3DX11_FFT_DIM_MASK")]
	[Flags]
	public enum D3DX11_FFT_DIM_MASK
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x1</para>
		/// <para>One dimension.</para>
		/// </summary>
		D3DX11_FFT_DIM_MASK_1D = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x3</para>
		/// <para>Two dimensions.</para>
		/// </summary>
		D3DX11_FFT_DIM_MASK_2D = 0x3,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x7</para>
		/// <para>Three dimensions.</para>
		/// </summary>
		D3DX11_FFT_DIM_MASK_3D = 0x7,
	}

	/// <summary>Type for scan data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ne-d3dcsx-d3dx11_scan_data_type typedef enum D3DX11_SCAN_DATA_TYPE {
	// D3DX11_SCAN_DATA_TYPE_FLOAT = 1, D3DX11_SCAN_DATA_TYPE_INT, D3DX11_SCAN_DATA_TYPE_UINT } ;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NE:d3dcsx.D3DX11_SCAN_DATA_TYPE")]
	public enum D3DX11_SCAN_DATA_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>FLOAT data.</para>
		/// </summary>
		[CorrespondingType(typeof(float))]
		D3DX11_SCAN_DATA_TYPE_FLOAT = 1,

		/// <summary>INT data.</summary>
		[CorrespondingType(typeof(int))]
		D3DX11_SCAN_DATA_TYPE_INT,

		/// <summary>UINT data.</summary>
		[CorrespondingType(typeof(uint))]
		D3DX11_SCAN_DATA_TYPE_UINT,
	}

	/// <summary>Direction to perform scan in.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ne-d3dcsx-d3dx11_scan_direction typedef enum D3DX11_SCAN_DIRECTION {
	// D3DX11_SCAN_DIRECTION_FORWARD = 1, D3DX11_SCAN_DIRECTION_BACKWARD } ;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NE:d3dcsx.D3DX11_SCAN_DIRECTION")]
	public enum D3DX11_SCAN_DIRECTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Scan forward.</para>
		/// </summary>
		D3DX11_SCAN_DIRECTION_FORWARD = 1,

		/// <summary>Scan backward.</summary>
		D3DX11_SCAN_DIRECTION_BACKWARD,
	}

	/// <summary>Scan opcodes.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ne-d3dcsx-d3dx11_scan_opcode typedef enum D3DX11_SCAN_OPCODE {
	// D3DX11_SCAN_OPCODE_ADD = 1, D3DX11_SCAN_OPCODE_MIN, D3DX11_SCAN_OPCODE_MAX, D3DX11_SCAN_OPCODE_MUL, D3DX11_SCAN_OPCODE_AND,
	// D3DX11_SCAN_OPCODE_OR, D3DX11_SCAN_OPCODE_XOR } ;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NE:d3dcsx.D3DX11_SCAN_OPCODE")]
	public enum D3DX11_SCAN_OPCODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Add values.</para>
		/// </summary>
		D3DX11_SCAN_OPCODE_ADD = 1,

		/// <summary>Take the minimum value.</summary>
		D3DX11_SCAN_OPCODE_MIN,

		/// <summary>Take the maximum value.</summary>
		D3DX11_SCAN_OPCODE_MAX,

		/// <summary>Multiply the values.</summary>
		D3DX11_SCAN_OPCODE_MUL,

		/// <summary>Perform a logical AND on the values.</summary>
		D3DX11_SCAN_OPCODE_AND,

		/// <summary>Perform a logical OR on the values.</summary>
		D3DX11_SCAN_OPCODE_OR,

		/// <summary>Perform a logical XOR on the values.</summary>
		D3DX11_SCAN_OPCODE_XOR,
	}

	/// <summary>Encapsulates forward and inverse FFTs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nn-d3dcsx-id3dx11fft
	[PInvokeData("d3dcsx.h", MSDNShortId = "NN:d3dcsx.ID3DX11FFT")]
	[ComImport, Guid("b3f7a938-4c93-4310-a675-b30d6de50553"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3DX11FFT
	{
		/// <summary>Sets the scale used for forward transforms.</summary>
		/// <param name="ForwardScale">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The scale to use for forward transforms. Setting <c>ForwardScale</c> to 0 causes the default values of 1 to be used.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks><c>SetForwardScale</c> sets the scale used by ID3DX11FFT::ForwardTransform.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-setforwardscale HRESULT SetForwardScale( [in]
		// FLOAT ForwardScale );
		[PreserveSig]
		HRESULT SetForwardScale(float ForwardScale);

		/// <summary>Gets the scale for forward transforms.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Scale for forward transforms.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-getforwardscale FLOAT GetForwardScale();
		[PreserveSig]
		float GetForwardScale();

		/// <summary>Sets the scale used for inverse transforms.</summary>
		/// <param name="InverseScale">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Scale used for inverse transforms. Setting <c>InverseScale</c> to 0 causes the default value of 1/N to be used, where N is the
		/// product of the transformed dimension lengths.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks><c>SetInverseScale</c> sets the scale used by ID3DX11FFT::InverseTransform.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-setinversescale HRESULT SetInverseScale( [in]
		// FLOAT InverseScale );
		[PreserveSig]
		HRESULT SetInverseScale(float InverseScale);

		/// <summary>Get the scale for inverse transforms.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Scale for inverse transforms.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-getinversescale FLOAT GetInverseScale();
		[PreserveSig]
		float GetInverseScale();

		/// <summary>Attaches buffers to an FFT context and performs any required precomputations.</summary>
		/// <param name="NumTempBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers in <c>ppTempBuffers</c>.</para>
		/// </param>
		/// <param name="ppTempBuffers">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>
		/// A pointer to an array of ID3D11UnorderedAccessView pointers for the temporary buffers to attach. The FFT object might use these
		/// temporary buffers for its algorithm.
		/// </para>
		/// </param>
		/// <param name="NumPrecomputeBuffers">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of buffers in <c>ppPrecomputeBuffers</c>.</para>
		/// </param>
		/// <param name="ppPrecomputeBufferSizes">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>
		/// A pointer to an array of ID3D11UnorderedAccessView pointers for the precompute buffers to attach. The FFT object might store
		/// precomputed data in these buffers.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The D3DX11_FFT_BUFFER_INFO structure is initialized by a call to one of the create-FFT functions (for example, D3DX11CreateFFT).
		/// For more create-FFT functions, see D3DCSX 11 Functions.
		/// </para>
		/// <para>
		/// Use the info in D3DX11_FFT_BUFFER_INFO to allocate raw buffers of the specified (or larger) sizes and then call the
		/// <c>AttachBuffersAndPrecompute</c> to register the buffers with the FFT object.
		/// </para>
		/// <para>
		/// Although you can share temporary buffers between multiple device contexts, we recommend not to concurrently execute multiple FFT
		/// objects that share temporary buffers.
		/// </para>
		/// <para>
		/// Some FFT algorithms benefit from precomputing sin and cos. The FFT object might store precomputed data in the user-supplied
		/// precompute buffers.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-attachbuffersandprecompute HRESULT
		// AttachBuffersAndPrecompute( [in] UINT NumTempBuffers, [in] ID3D11UnorderedAccessView * const *ppTempBuffers, [in] UINT
		// NumPrecomputeBuffers, [in] ID3D11UnorderedAccessView * const *ppPrecomputeBufferSizes );
		[PreserveSig]
		HRESULT AttachBuffersAndPrecompute(int NumTempBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ID3D11UnorderedAccessView[] ppTempBuffers,
			int NumPrecomputeBuffers, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ID3D11UnorderedAccessView[] ppPrecomputeBufferSizes);

		/// <summary>Performs a forward FFT.</summary>
		/// <param name="pInputBuffer">
		/// <para>Type: <c>const ID3D11UnorderedAccessView*</c></para>
		/// <para>Pointer to ID3D11UnorderedAccessView onto the input buffer.</para>
		/// </param>
		/// <param name="ppOutputBuffer">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>
		/// Pointer to a ID3D11UnorderedAccessView pointer. If * <c>ppOutputBuffer</c> is <c>NULL</c>, the computation will switch between
		/// temp buffers; in addition, the last buffer written to is stored at * <c>ppOutputBuffer</c>. Otherwise, * <c>ppOutputBuffer</c>
		/// is used as the output buffer (which might incur an extra copy).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>ForwardTransform</c> can be called after buffers have been attached to the context using
		/// ID3DX11FFT::AttachBuffersAndPrecompute. The combination of <c>pInputBuffer</c> and * <c>ppOutputBuffer</c> can be one of the
		/// temp buffers.
		/// </para>
		/// <para>
		/// The format of complex data is interleaved components (for example, (Real0, Imag0), (Real1, Imag1) ... , and so on). Data is
		/// stored in row major order.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-forwardtransform HRESULT ForwardTransform( [in]
		// const ID3D11UnorderedAccessView *pInputBuffer, [in, out] ID3D11UnorderedAccessView **ppOutputBuffer );
		[PreserveSig]
		HRESULT ForwardTransform(ID3D11UnorderedAccessView pInputBuffer, out ID3D11UnorderedAccessView ppOutputBuffer);

		/// <summary>Performs an inverse FFT.</summary>
		/// <param name="pInputBuffer">
		/// <para>Type: <c>const ID3D11UnorderedAccessView*</c></para>
		/// <para>Pointer to ID3D11UnorderedAccessView onto the input buffer.</para>
		/// </param>
		/// <param name="ppOutputBuffer">
		/// <para>Type: <c>ID3D11UnorderedAccessView**</c></para>
		/// <para>
		/// Pointer to a ID3D11UnorderedAccessView pointer. If * <c>ppOutput</c> is <c>NULL</c>, then the computation will switch between
		/// temp buffers; in addition, the last buffer written to is stored at * <c>ppOutput</c>. Otherwise, * <c>ppOutput</c> is used as
		/// the output buffer (which might incur an extra copy).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11fft-inversetransform HRESULT InverseTransform( [in]
		// const ID3D11UnorderedAccessView *pInputBuffer, [in, out] ID3D11UnorderedAccessView **ppOutputBuffer );
		[PreserveSig]
		HRESULT InverseTransform(ID3D11UnorderedAccessView pInputBuffer, out ID3D11UnorderedAccessView ppOutputBuffer);
	}

	/// <summary>Scan context.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nn-d3dcsx-id3dx11scan
	[PInvokeData("d3dcsx.h", MSDNShortId = "NN:d3dcsx.ID3DX11Scan")]
	[ComImport, Guid("5089b68f-e71d-4d38-be8e-f363b95a9405"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public partial interface ID3DX11Scan
	{
		/// <summary>Sets which direction to perform scans in.</summary>
		/// <param name="Direction">
		/// <para>Type: <c>D3DX11_SCAN_DIRECTION</c></para>
		/// <para>Direction to perform scans in. See D3DX11_SCAN_DIRECTION.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks><c>SetScanDirection</c> sets the direction ID3DX11Scan::Scan and ID3DX11Scan::Multiscan will performed scans in.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11scan-setscandirection HRESULT SetScanDirection( [in]
		// D3DX11_SCAN_DIRECTION Direction );
		[PreserveSig]
		HRESULT SetScanDirection(D3DX11_SCAN_DIRECTION Direction);

		/// <summary>Performs an unsegmented scan of a sequence.</summary>
		/// <param name="ElementType">
		/// <para>Type: <c>D3DX11_SCAN_DATA_TYPE</c></para>
		/// <para>The type of element in the sequence. See D3DX11_SCAN_DATA_TYPE for more information.</para>
		/// </param>
		/// <param name="OpCode">
		/// <para>Type: <c>D3DX11_SCAN_OPCODE</c></para>
		/// <para>The binary operation to perform. See D3DX11_SCAN_OPCODE for more information.</para>
		/// </param>
		/// <param name="ElementScanSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of scan in elements.</para>
		/// </param>
		/// <param name="pSrc">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Input sequence on the device. Set <c>pSrc</c> and <c>pDst</c> to the same value for in-place scans.</para>
		/// </param>
		/// <param name="pDst">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Output sequence on the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// You must point the parameters <c>pSrc</c> and <c>pDst</c> to typed buffers (and not to raw or structured buffers). For
		/// information about buffer types, see Types of Resources. The format of these typed buffers must be DXGI_FORMAT_R32_FLOAT,
		/// <c>DXGI_FORMAT_R32_UINT</c>, or <c>DXGI_FORMAT_R32_INT</c>. In addition, the format of these typed buffers must match the scan
		/// data type that you specify in the <c>ElementType</c> parameter. For example, if the scan data type is
		/// D3DX11_SCAN_DATA_TYPE_UINT, the buffer formats must be <c>DXGI_FORMAT_R32_UINT</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11scan-scan HRESULT Scan( [in] D3DX11_SCAN_DATA_TYPE
		// ElementType, [in] D3DX11_SCAN_OPCODE OpCode, [in] UINT ElementScanSize, [in] ID3D11UnorderedAccessView *pSrc, [in]
		// ID3D11UnorderedAccessView *pDst );
		[PreserveSig]
		HRESULT Scan(D3DX11_SCAN_DATA_TYPE ElementType, D3DX11_SCAN_OPCODE OpCode, uint ElementScanSize, [In] ID3D11UnorderedAccessView pSrc,
			[In] ID3D11UnorderedAccessView pDst);

		/// <summary>Performs a multiscan of a sequence.</summary>
		/// <param name="ElementType">
		/// <para>Type: <c>D3DX11_SCAN_DATA_TYPE</c></para>
		/// <para>The type of element in the sequence. See D3DX11_SCAN_DATA_TYPE for more information.</para>
		/// </param>
		/// <param name="OpCode">
		/// <para>Type: <c>D3DX11_SCAN_OPCODE</c></para>
		/// <para>The binary operation to perform. See D3DX11_SCAN_OPCODE for more information.</para>
		/// </param>
		/// <param name="ElementScanSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of scan in elements.</para>
		/// </param>
		/// <param name="ElementScanPitch">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Pitch of the next scan in elements.</para>
		/// </param>
		/// <param name="ScanCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of scans in the multiscan.</para>
		/// </param>
		/// <param name="pSrc">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Input sequence on the device. Set <c>pSrc</c> and <c>pDst</c> to the same value for in-place scans.</para>
		/// </param>
		/// <param name="pDst">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Output sequence on the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// You must point the parameters <c>pSrc</c> and <c>pDst</c> to typed buffers (and not to raw or structured buffers). For
		/// information about buffer types, see Types of Resources. The format of these typed buffers must be DXGI_FORMAT_R32_FLOAT,
		/// <c>DXGI_FORMAT_R32_UINT</c>, or <c>DXGI_FORMAT_R32_INT</c>. In addition, the format of these typed buffers must match the scan
		/// data type that you specify in the <c>ElementType</c> parameter. For example, if the scan data type is
		/// D3DX11_SCAN_DATA_TYPE_UINT, the buffer formats must be <c>DXGI_FORMAT_R32_UINT</c>.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11scan-multiscan HRESULT Multiscan( [in]
		// D3DX11_SCAN_DATA_TYPE ElementType, [in] D3DX11_SCAN_OPCODE OpCode, [in] UINT ElementScanSize, [in] UINT ElementScanPitch, [in]
		// UINT ScanCount, [in] ID3D11UnorderedAccessView *pSrc, [in] ID3D11UnorderedAccessView *pDst );
		[PreserveSig]
		HRESULT Multiscan(D3DX11_SCAN_DATA_TYPE ElementType, D3DX11_SCAN_OPCODE OpCode, uint ElementScanSize, uint ElementScanPitch,
			uint ScanCount, [In] ID3D11UnorderedAccessView pSrc, [In] ID3D11UnorderedAccessView pDst);
	}

	/// <summary>Segmented scan context.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nn-d3dcsx-id3dx11segmentedscan
	[PInvokeData("d3dcsx.h", MSDNShortId = "NN:d3dcsx.ID3DX11SegmentedScan")]
	[ComImport, Guid("a915128c-d954-4c79-bfe1-64db923194d6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3DX11SegmentedScan
	{
		/// <summary>Sets which direction to perform scans in.</summary>
		/// <param name="Direction">
		/// <para>Type: <c>D3DX11_SCAN_DIRECTION</c></para>
		/// <para>Direction to perform scans in. See D3DX11_SCAN_DIRECTION.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks><c>SetScanDirection</c> sets the direction ID3DX11SegmentedScan::SegScan will performed scans in.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11segmentedscan-setscandirection HRESULT
		// SetScanDirection( [in] D3DX11_SCAN_DIRECTION Direction );
		[PreserveSig]
		HRESULT SetScanDirection(D3DX11_SCAN_DIRECTION Direction);

		/// <summary>Performs a segmented scan of a sequence.</summary>
		/// <param name="ElementType">
		/// <para>Type: <c>D3DX11_SCAN_DATA_TYPE</c></para>
		/// <para>The type of element in the sequence. See D3DX11_SCAN_DATA_TYPE for more information.</para>
		/// </param>
		/// <param name="OpCode">
		/// <para>Type: <c>D3DX11_SCAN_OPCODE</c></para>
		/// <para>The binary operation to perform. See D3DX11_SCAN_OPCODE for more information.</para>
		/// </param>
		/// <param name="ElementScanSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Size of scan in elements.</para>
		/// </param>
		/// <param name="pSrc">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Input sequence on the device. Set <c>pSrc</c> and <c>pDst</c> to the same value for in-place scans.</para>
		/// </param>
		/// <param name="pSrcElementFlags">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Compact array of bits with one bit per element of <c>pSrc</c>. A set value indicates the start of a new segment.</para>
		/// </param>
		/// <param name="pDst">
		/// <para>Type: <c>ID3D11UnorderedAccessView*</c></para>
		/// <para>Output sequence on the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the return codes described in the topic Direct3D 11 Return Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You must point the parameters <c>pSrc</c> and <c>pDst</c> to typed buffers (and not to raw or structured buffers). For
		/// information about buffer types, see Types of Resources. The format of these typed buffers must be DXGI_FORMAT_R32_FLOAT,
		/// <c>DXGI_FORMAT_R32_UINT</c>, or <c>DXGI_FORMAT_R32_INT</c>. In addition, the format of these typed buffers must match the scan
		/// data type that you specify in the <c>ElementType</c> parameter. For example, if the scan data type is
		/// D3DX11_SCAN_DATA_TYPE_UINT, the buffer formats must be <c>DXGI_FORMAT_R32_UINT</c>.
		/// </para>
		/// <para>The format of the resource view to which the <c>pSrcElementFlags</c> parameter points must be DXGI_FORMAT_R32_UINT.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-id3dx11segmentedscan-segscan HRESULT SegScan( [in]
		// D3DX11_SCAN_DATA_TYPE ElementType, [in] D3DX11_SCAN_OPCODE OpCode, [in] UINT ElementScanSize, [in] ID3D11UnorderedAccessView
		// *pSrc, [in] ID3D11UnorderedAccessView *pSrcElementFlags, [in] ID3D11UnorderedAccessView *pDst );
		[PreserveSig]
		HRESULT SegScan(D3DX11_SCAN_DATA_TYPE ElementType, D3DX11_SCAN_OPCODE OpCode, uint ElementScanSize,
			[In, Optional] ID3D11UnorderedAccessView? pSrc, [In] ID3D11UnorderedAccessView pSrcElementFlags,
			[In] ID3D11UnorderedAccessView pDst);
	}

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="pDesc">
	/// <para>Type: <c>const D3DX11_FFT_DESC*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_DESC structure that describes the shape of the FFT data as well as the scaling factors that should be used
	/// for forward and inverse transforms.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>One of the Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft HRESULT D3DX11CreateFFT( ID3D11DeviceContext
	// *pDeviceContext, [in] const D3DX11_FFT_DESC *pDesc, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT(ID3D11DeviceContext pDeviceContext, in D3DX11_FFT_DESC pDesc,
		uint Flags, out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the first dimension of the FFT.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft1dcomplex HRESULT D3DX11CreateFFT1DComplex(
	// ID3D11DeviceContext *pDeviceContext, UINT X, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT1DComplex")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT1DComplex(ID3D11DeviceContext pDeviceContext, uint X, uint Flags,
		out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the first dimension of the FFT.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft1dreal HRESULT D3DX11CreateFFT1DReal(
	// ID3D11DeviceContext *pDeviceContext, UINT X, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT1DReal")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT1DReal(ID3D11DeviceContext pDeviceContext, uint X, uint Flags,
		out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the first dimension of the FFT.</para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the second dimension of the FFT.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft2dcomplex HRESULT D3DX11CreateFFT2DComplex(
	// ID3D11DeviceContext *pDeviceContext, UINT X, UINT Y, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT2DComplex")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT2DComplex(ID3D11DeviceContext pDeviceContext, uint X, uint Y,
		uint Flags, out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the first dimension of the FFT.</para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the second dimension of the FFT.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft2dreal HRESULT D3DX11CreateFFT2DReal(
	// ID3D11DeviceContext *pDeviceContext, UINT X, UINT Y, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT2DReal")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT2DReal(ref ID3D11DeviceContext pDeviceContext, uint X, uint Y, uint Flags,
		out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the first dimension of the FFT.</para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the second dimension of the FFT.</para>
	/// </param>
	/// <param name="Z">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the third dimension of the FFT.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft3dcomplex HRESULT D3DX11CreateFFT3DComplex(
	// ID3D11DeviceContext *pDeviceContext, UINT X, UINT Y, UINT Z, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT
	// **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT3DComplex")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT3DComplex(ref ID3D11DeviceContext pDeviceContext, uint X, uint Y, uint Z,
		uint Flags, out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates an ID3DX11FFT COM interface object.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>A pointer to the ID3D11DeviceContext interface to use for the FFT.</para>
	/// </param>
	/// <param name="X">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the first dimension of the FFT.</para>
	/// </param>
	/// <param name="Y">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the second dimension of the FFT.</para>
	/// </param>
	/// <param name="Z">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Length of the third dimension of the FFT.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Flags that affect the behavior of the FFT, can be 0 or a combination of flags from D3DX11_FFT_CREATE_FLAG.</para>
	/// </param>
	/// <param name="pBufferInfo">
	/// <para>Type: <c>D3DX11_FFT_BUFFER_INFO*</c></para>
	/// <para>
	/// A pointer to a D3DX11_FFT_BUFFER_INFO structure that receives the buffer requirements to execute the FFT algorithms. Use this info
	/// to allocate raw buffers of the specified (or larger) sizes and then call the ID3DX11FFT::AttachBuffersAndPrecompute method to
	/// register the buffers with the FFT object.
	/// </para>
	/// </param>
	/// <param name="ppFFT">
	/// <para>Type: <c>ID3DX11FFT**</c></para>
	/// <para>A pointer to a variable that receives a pointer to the ID3DX11FFT interface for the created FFT object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createfft3dreal HRESULT D3DX11CreateFFT3DReal(
	// ID3D11DeviceContext *pDeviceContext, UINT X, UINT Y, UINT Z, UINT Flags, [out] D3DX11_FFT_BUFFER_INFO *pBufferInfo, [out] ID3DX11FFT
	// **ppFFT );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateFFT3DReal")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateFFT3DReal(ref ID3D11DeviceContext pDeviceContext, uint X, uint Y, uint Z,
		uint Flags, out D3DX11_FFT_BUFFER_INFO pBufferInfo, [MarshalAs(UnmanagedType.Interface)] out ID3DX11FFT ppFFT);

	/// <summary>Creates a scan context.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>The ID3D11DeviceContext the scan is associated with.</para>
	/// </param>
	/// <param name="MaxElementScanSize">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Maximum single scan size, in elements (FLOAT, UINT, or INT).</para>
	/// </param>
	/// <param name="MaxScanCount">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Maximum number of scans in multiscan.</para>
	/// </param>
	/// <param name="ppScan">
	/// <para>Type: <c>ID3DX11Scan**</c></para>
	/// <para>Pointer to a ID3DX11Scan Interface pointer that will be set to the created interface object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createscan HRESULT D3DX11CreateScan( [in]
	// ID3D11DeviceContext *pDeviceContext, UINT MaxElementScanSize, UINT MaxScanCount, [out] ID3DX11Scan **ppScan );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateScan")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateScan(in ID3D11DeviceContext pDeviceContext, uint MaxElementScanSize,
		uint MaxScanCount, [MarshalAs(UnmanagedType.Interface)] out ID3DX11Scan ppScan);

	/// <summary>Creates a segmented scan context.</summary>
	/// <param name="pDeviceContext">
	/// <para>Type: <c>ID3D11DeviceContext*</c></para>
	/// <para>Pointer to an ID3D11DeviceContext interface.</para>
	/// </param>
	/// <param name="MaxElementScanSize">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Maximum single scan size, in elements (FLOAT, UINT, or INT).</para>
	/// </param>
	/// <param name="ppScan">
	/// <para>Type: <c>ID3DX11SegmentedScan**</c></para>
	/// <para>Pointer to a ID3DX11SegmentedScan Interface pointer that will be set to the created interface object.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>The return value is one of the values listed in Direct3D 11 Return Codes.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/nf-d3dcsx-d3dx11createsegmentedscan HRESULT D3DX11CreateSegmentedScan(
	// [in] ID3D11DeviceContext *pDeviceContext, UINT MaxElementScanSize, [out] ID3DX11SegmentedScan **ppScan );
	[PInvokeData("d3dcsx.h", MSDNShortId = "NF:d3dcsx.D3DX11CreateSegmentedScan")]
	[DllImport(Lib_D3dcsx, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT D3DX11CreateSegmentedScan(in ID3D11DeviceContext pDeviceContext, uint MaxElementScanSize,
		[MarshalAs(UnmanagedType.Interface)] out ID3DX11SegmentedScan ppScan);

	/// <summary>Describes buffer requirements for an FFT.</summary>
	/// <remarks>
	/// <para>
	/// The <c>D3DX11_FFT_BUFFER_INFO</c> structure is initialized by a call to one of the create-FFT functions (for example,
	/// D3DX11CreateFFT). For more create-FFT functions, see D3DCSX 11 Functions.
	/// </para>
	/// <para>
	/// Use the info in <c>D3DX11_FFT_BUFFER_INFO</c> to allocate raw buffers of the specified (or larger) sizes and then call the
	/// ID3DX11FFT::AttachBuffersAndPrecompute method to register the buffers with the FFT object.
	/// </para>
	/// <para>
	/// Some FFT algorithms benefit from precomputing sin and cos. The FFT object might store precomputed data in the user-supplied buffers.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ns-d3dcsx-d3dx11_fft_buffer_info typedef struct D3DX11_FFT_BUFFER_INFO {
	// UINT NumTempBufferSizes; UINT TempBufferFloatSizes[D3DX11_FFT_MAX_TEMP_BUFFERS]; UINT NumPrecomputeBufferSizes; UINT
	// PrecomputeBufferFloatSizes[D3DX11_FFT_MAX_PRECOMPUTE_BUFFERS]; } D3DX11_FFT_BUFFER_INFO;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NS:d3dcsx.D3DX11_FFT_BUFFER_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3DX11_FFT_BUFFER_INFO
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of temporary buffers needed. Allowed range is 0 to <c>D3DX11_FFT_MAX_TEMP_BUFFERS</c>.</para>
		/// </summary>
		public uint NumTempBufferSizes;

		/// <summary>
		/// <para>Type: <c>UINT[D3DX11_FFT_MAX_TEMP_BUFFERS]</c></para>
		/// <para>Minimum sizes (in FLOATs) of temporary buffers.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = D3DX11_FFT_MAX_TEMP_BUFFERS)]
		public uint[] TempBufferFloatSizes;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of precompute buffers required. Allowed range is 0 to <c>D3DX11_FFT_MAX_PRECOMPUTE_BUFFERS</c>.</para>
		/// </summary>
		public uint NumPrecomputeBufferSizes;

		/// <summary>
		/// <para>Type: <c>UINT[D3DX11_FFT_MAX_PRECOMPUTE_BUFFERS]</c></para>
		/// <para>Minimum sizes (in FLOATs) for precompute buffers.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = D3DX11_FFT_MAX_PRECOMPUTE_BUFFERS)]
		public uint[] PrecomputeBufferFloatSizes;
	}

	/// <summary>Describes an FFT.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3dcsx/ns-d3dcsx-d3dx11_fft_desc typedef struct D3DX11_FFT_DESC { UINT
	// NumDimensions; UINT ElementLengths[D3DX11_FFT_MAX_DIMENSIONS]; UINT DimensionMask; D3DX11_FFT_DATA_TYPE Type; } D3DX11_FFT_DESC;
	[PInvokeData("d3dcsx.h", MSDNShortId = "NS:d3dcsx.D3DX11_FFT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3DX11_FFT_DESC
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Number of dimension in the FFT.</para>
		/// </summary>
		public uint NumDimensions;

		/// <summary>
		/// <para>Type: <c>UINT[D3DX11_FFT_MAX_DIMENSIONS]</c></para>
		/// <para>Length of each dimension in the FFT.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = D3DX11_FFT_MAX_DIMENSIONS)]
		public uint[] ElementLengths;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>Combination of D3DX11_FFT_DIM_MASK flags indicating the dimensions to transform.</para>
		/// </summary>
		public uint DimensionMask;

		/// <summary>
		/// <para>Type: <c>D3DX11_FFT_DATA_TYPE</c></para>
		/// <para>D3DX11_FFT_DATA_TYPE flag indicating the type of data being transformed.</para>
		/// </summary>
		public D3DX11_FFT_DATA_TYPE Type;
	}
}