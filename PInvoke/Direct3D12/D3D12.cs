namespace Vanara.PInvoke;

/// <summary>Items from the Direct3D12.dll.</summary>
public static partial class D3D12
{
	/// <summary>Defines constants that specify the state of a resource regarding how the resource is being used.</summary>
	/// <remarks>
	/// <para>This enum is used by the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>CreateCommittedResource</description>
	/// </item>
	/// <item>
	/// <description>CreatePlacedResource</description>
	/// </item>
	/// <item>
	/// <description>CreateReservedResource</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_states
	// typedef enum D3D12_RESOURCE_STATES { D3D12_RESOURCE_STATE_COMMON = 0, D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER = 0x1, D3D12_RESOURCE_STATE_INDEX_BUFFER = 0x2, D3D12_RESOURCE_STATE_RENDER_TARGET = 0x4, D3D12_RESOURCE_STATE_UNORDERED_ACCESS = 0x8, D3D12_RESOURCE_STATE_DEPTH_WRITE = 0x10, D3D12_RESOURCE_STATE_DEPTH_READ = 0x20, D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE = 0x40, D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE = 0x80, D3D12_RESOURCE_STATE_STREAM_OUT = 0x100, D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT = 0x200, D3D12_RESOURCE_STATE_COPY_DEST = 0x400, D3D12_RESOURCE_STATE_COPY_SOURCE = 0x800, D3D12_RESOURCE_STATE_RESOLVE_DEST = 0x1000, D3D12_RESOURCE_STATE_RESOLVE_SOURCE = 0x2000, D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE = 0x400000, D3D12_RESOURCE_STATE_SHADING_RATE_SOURCE = 0x1000000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_8000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_4000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_100000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_40000000, D3D12_RESOURCE_STATE_RESERVED_INTERNAL_80000000, D3D12_RESOURCE_STATE_GENERIC_READ, D3D12_RESOURCE_STATE_ALL_SHADER_RESOURCE, D3D12_RESOURCE_STATE_PRESENT = 0, D3D12_RESOURCE_STATE_PREDICATION = 0x200, D3D12_RESOURCE_STATE_VIDEO_DECODE_READ = 0x10000, D3D12_RESOURCE_STATE_VIDEO_DECODE_WRITE = 0x20000, D3D12_RESOURCE_STATE_VIDEO_PROCESS_READ = 0x40000, D3D12_RESOURCE_STATE_VIDEO_PROCESS_WRITE = 0x80000, D3D12_RESOURCE_STATE_VIDEO_ENCODE_READ = 0x200000, D3D12_RESOURCE_STATE_VIDEO_ENCODE_WRITE = 0x800000 } ;
	[PInvokeData("d3d12.h", MSDNShortId = "NE:d3d12.D3D12_RESOURCE_STATES")]
	[Flags]
	public enum D3D12_RESOURCE_STATES : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Your application should transition to this state only for accessing a resource across different graphics engine types.</para>
		///   <para>Specifically, a resource must be in the COMMON state before being used on a COPY queue (when previously used on DIRECT/COMPUTE), and before being used on DIRECT/COMPUTE (when previously used on COPY). This restriction doesn't exist when accessing data between DIRECT and COMPUTE queues.</para>
		///   <para>The COMMON state can be used for all usages on a Copy queue using the implicit state transitions. For more info, in</para>
		///   <para>Multi-engine synchronization</para>
		///   <para>, find "common".</para>
		///   <para>Additionally, textures must be in the COMMON state for CPU access to be legal, assuming the texture was created in a CPU-visible heap in the first place.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_COMMON = 0x0,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x1</para>
		///   <para>A subresource must be in this state when it is accessed by the GPU as a vertex buffer or constant buffer. This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER = 0x1,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x2</para>
		///   <para>A subresource must be in this state when it is accessed by the 3D pipeline as an index buffer. This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_INDEX_BUFFER = 0x2,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x4</para>
		///   <para>The resource is used as a render target. A subresource must be in this state when it is rendered to, or when it is cleared with</para>
		///   <para>ID3D12GraphicsCommandList::ClearRenderTargetView</para>
		///   <para>.</para>
		///   <para>This is a write-only state. To read from a render target as a shader resource, the resource must be in either</para>
		///   <para>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</para>
		///   <para>or</para>
		///   <para>D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</para>
		///   <para>.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_RENDER_TARGET = 0x4,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x8</para>
		///   <para>The resource is used for unordered access. A subresource must be in this state when it is accessed by the GPU via an unordered access view. A subresource must also be in this state when it is cleared with</para>
		///   <para>ID3D12GraphicsCommandList::ClearUnorderedAccessViewInt</para>
		///   <para>or</para>
		///   <para>ID3D12GraphicsCommandList::ClearUnorderedAccessViewFloat</para>
		///   <para>. This is a read/write state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_UNORDERED_ACCESS = 0x8,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x10</para>
		///   <para>D3D12_RESOURCE_STATE_DEPTH_WRITE</para>
		///   <para>is a state that is mutually exclusive with other states. You should use it for</para>
		///   <para>ID3D12GraphicsCommandList::ClearDepthStencilView</para>
		///   <para>when the flags (see</para>
		///   <para>D3D12_CLEAR_FLAGS</para>
		///   <para>) indicate a given subresource should be cleared (otherwise the subresource state doesn't matter), or when using it in a writable depth stencil view (see</para>
		///   <para>D3D12_DSV_FLAGS</para>
		///   <para>) when the PSO has depth write enabled (see</para>
		///   <para>D3D12_DEPTH_STENCIL_DESC</para>
		///   <para>).</para>
		/// </summary>
		D3D12_RESOURCE_STATE_DEPTH_WRITE = 0x10,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x20</para>
		///   <para>DEPTH_READ is a state that can be combined with other states. It should be used when the subresource is in a read-only depth stencil view, or when depth write of</para>
		///   <para>D3D12_DEPTH_STENCIL_DESC</para>
		///   <para>is disabled. It can be combined with other read states (for example,</para>
		///   <para>D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</para>
		///   <para>), such that the resource can be used for the depth or stencil test, and accessed by a shader within the same draw call. Using it when depth will be written by a draw call or clear command is invalid.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_DEPTH_READ = 0x20,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x40</para>
		///   <para>The resource is used with a shader other than the pixel shader. A subresource must be in this state before being read by any stage (except for the pixel shader stage) via a shader resource view. You can still use the resource in a pixel shader with this flag as long as it also has the flag</para>
		///   <para>D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</para>
		///   <para>set. This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE = 0x40,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80</para>
		///   <para>The resource is used with a pixel shader. A subresource must be in this state before being read by the pixel shader via a shader resource view. This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE = 0x80,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x100</para>
		///   <para>The resource is used with stream output. A subresource must be in this state when it is accessed by the 3D pipeline as a stream-out target. This is a write-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_STREAM_OUT = 0x100,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x200</para>
		///   <para>The resource is used as an indirect argument.</para>
		///   <para>Subresources must be in this state when they are used as the argument buffer passed to the indirect drawing method</para>
		///   <para>ID3D12GraphicsCommandList::ExecuteIndirect</para>
		///   <para>.</para>
		///   <para>This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_INDIRECT_ARGUMENT = 0x200,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x400</para>
		///   <para>The resource is used as the destination in a copy operation.</para>
		///   <para>Subresources must be in this state when they are used as the destination of copy operation, or a blt operation.</para>
		///   <para>This is a write-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_COPY_DEST = 0x400,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x800</para>
		///   <para>The resource is used as the source in a copy operation.</para>
		///   <para>Subresources must be in this state when they are used as the source of copy operation, or a blt operation.</para>
		///   <para>This is a read-only state.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_COPY_SOURCE = 0x800,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x1000</para>
		///   <para>The resource is used as the destination in a resolve operation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_RESOLVE_DEST = 0x1000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x2000</para>
		///   <para>The resource is used as the source in a resolve operation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_RESOLVE_SOURCE = 0x2000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x400000</para>
		///   <para>When a buffer is created with this as its initial state, it indicates that the resource is a raytracing acceleration structure, for use in</para>
		///   <para>ID3D12GraphicsCommandList4::BuildRaytracingAccelerationStructure</para>
		///   <para>,</para>
		///   <para>ID3D12GraphicsCommandList4::CopyRaytracingAccelerationStructure</para>
		///   <para>, or</para>
		///   <para>ID3D12Device::CreateShaderResourceView</para>
		///   <para>for the</para>
		///   <para>D3D12_SRV_DIMENSION_RAYTRACING_ACCELERATION_STRUCTURE</para>
		///   <para>dimension.</para>
		///   <para>
		///     <para>NOTE</para>
		///     <para>A resource to be used for the <c>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</c> state must be created in that state, and then never transitioned out of it. Nor may a resource that was created not in that state be transitioned into it. For more info, see Acceleration structure memory restrictions in the DirectX raytracing (DXR) functional specification on GitHub.</para>
		///   </para>
		/// </summary>
		D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE = 0x400000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x1000000</para>
		///   <para>Starting with Windows 10, version 1903 (10.0; Build 18362), indicates that the resource is a screen-space shading-rate image for variable-rate shading (VRS). For more info, see</para>
		///   <para>Variable-rate shading (VRS)</para>
		///   <para>.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_SHADING_RATE_SOURCE = 0x1000000,
		/// <summary>D3D12_RESOURCE_STATE_GENERIC_READ is a logically OR'd combination of other read-state bits. This is the required starting state for an upload heap. Your application should generally avoid transitioning to D3D12_RESOURCE_STATE_GENERIC_READ when possible, since that can result in premature cache flushes, or resource layout changes (for example, compress/decompress), causing unnecessary pipeline stalls. You should instead transition resources only to the actually-used states.</summary>
		D3D12_RESOURCE_STATE_GENERIC_READ,
		/// <summary>
		///   <para>Equivalent to</para>
		///   <para>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE | D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE</para>
		///   <para>.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_ALL_SHADER_RESOURCE = D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE | D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Synonymous with D3D12_RESOURCE_STATE_COMMON.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_PRESENT = D3D12_RESOURCE_STATE_COMMON,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x200</para>
		///   <para>The resource is used for</para>
		///   <para>Predication</para>
		///   <para>.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_PREDICATION = 0x200,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x10000</para>
		///   <para>The resource is used as a source in a decode operation. Examples include reading the compressed bitstream and reading from decode references,</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_DECODE_READ = 0x10000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x20000</para>
		///   <para>The resource is used as a destination in the decode operation. This state is used for decode output and histograms.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_DECODE_WRITE = 0x20000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x40000</para>
		///   <para>The resource is used to read video data during video processing; that is, the resource is used as the source in a processing operation such as video encoding (compression).</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_PROCESS_READ = 0x40000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000</para>
		///   <para>The resource is used to write video data during video processing; that is, the resource is used as the destination in a processing operation such as video encoding (compression).</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_PROCESS_WRITE = 0x80000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x200000</para>
		///   <para>The resource is used as the source in an encode operation. This state is used for the input and reference of motion estimation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_ENCODE_READ = 0x200000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x800000</para>
		///   <para>This resource is used as the destination in an encode operation. This state is used for the destination texture of a resolve motion vector heap operation.</para>
		/// </summary>
		D3D12_RESOURCE_STATE_VIDEO_ENCODE_WRITE = 0x800000,
	}

	/// <summary>Describes the coordinates of a tiled resource.</summary>
	/// <remarks>This structure is used by the CopyTiles, CopyTileMappings and UpdateTileMappings methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tiled_resource_coordinate
	// typedef struct D3D12_TILED_RESOURCE_COORDINATE { UINT X; UINT Y; UINT Z; UINT Subresource; } D3D12_TILED_RESOURCE_COORDINATE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TILED_RESOURCE_COORDINATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TILED_RESOURCE_COORDINATE
	{
		/// <summary>The x-coordinate of the tiled resource.</summary>
		public uint X;
		/// <summary>The y-coordinate of the tiled resource.</summary>
		public uint Y;
		/// <summary>The z-coordinate of the tiled resource.</summary>
		public uint Z;
		/// <summary>
		///   <para>The index of the subresource for the tiled resource.</para>
		///   <para>For mipmaps that use nonstandard tiling, or are packed, or both use nonstandard tiling and are packed, any subresource value that indicates any of the packed mipmaps all refer to the same tile. Additionally, the X coordinate is used to indicate a tile within the packed mip region, rather than a logical region of a single subresource. The Y and Z coordinates must be zero.</para>
		/// </summary>
		public uint Subresource;
	}

	/// <summary>Describes the size of a tiled region.</summary>
	/// <remarks>This structure is used by the CopyTiles, CopyTileMappings and UpdateTileMappings methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tile_region_size
	// typedef struct D3D12_TILE_REGION_SIZE { UINT NumTiles; BOOL UseBox; UINT Width; UINT16 Height; UINT16 Depth; } D3D12_TILE_REGION_SIZE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TILE_REGION_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TILE_REGION_SIZE
	{
		/// <summary>The number of tiles in the tiled region.</summary>
		public uint NumTiles;
		/// <summary>
		///   <para>Specifies whether the runtime uses the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members to define the region.</para>
		///   <para>If <c>TRUE</c>, the runtime uses the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members to define the region. In this case, <c>NumTiles</c> should be equal to <c>Width</c> * <c>Height</c> * <c>Depth</c>.</para>
		///   <para>If <c>FALSE</c>, the runtime ignores the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members and uses the <c>NumTiles</c> member to traverse tiles in the resource linearly across x, then y, then z (as applicable) and then spills over mipmaps/arrays in subresource order. For example, use this technique to map an entire resource at once.</para>
		///   <para>Regardless of whether you specify <c>TRUE</c> or <c>FALSE</c> for <c>UseBox</c>, you use a D3D12_TILED_RESOURCE_COORDINATE structure to specify the starting location for the region within the resource as a separate parameter outside of this structure by using x, y, and z coordinates.</para>
		///   <para>When the region includes mipmaps that are packed with nonstandard tiling, <c>UseBox</c> must be <c>FALSE</c> because tile dimensions are not standard and the app only knows a count of how many tiles are consumed by the packed area, which is per array slice. The corresponding (separate) starting location parameter uses x to offset into the flat range of tiles in this case, and y and z coordinates must each be 0.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool UseBox;
		/// <summary>The width of the tiled region, in tiles. Used for buffer and 1D, 2D, and 3D textures.</summary>
		public uint Width;
		/// <summary>The height of the tiled region, in tiles. Used for 2D and 3D textures.</summary>
		public ushort Height;
		/// <summary>The depth of the tiled region, in tiles. Used for 3D textures or arrays. For arrays, used for advancing in depth jumps to next slice of same mipmap size, which isn't contiguous in the subresource counting space if there are multiple mipmaps.</summary>
		public ushort Depth;
	}


}