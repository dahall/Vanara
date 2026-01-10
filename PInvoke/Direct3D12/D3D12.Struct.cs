using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Items from the Direct3D12.dll.</summary>
public static partial class D3D12
{
	/// <summary>
	/// <para>
	/// Represents Device Removed Extended Data (DRED) auto-breadcrumb data as a node in a linked list. Each
	/// <c>D3D12_AUTO_BREADCRUMB_NODE</c> object is singly linked to the next via its <see cref="pNext"/> member; except for the last node
	/// in the list, which has its <see cref="pNext"/> set to <see langword="null"/>.
	/// </para>
	/// <para>
	/// The Direct3D 12 runtime creates one of these for each graphics command list, and tracks them in the command allocator associated
	/// with the list. When a command list is executed, the command queue information is set. After device removal is detected, the Direct3D
	/// 12 runtime links together the auto-breadcrumb nodes for any GPU work that is still outstanding.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_auto_breadcrumb_node typedef struct
	// D3D12_AUTO_BREADCRUMB_NODE { const char *pCommandListDebugNameA; const wchar_t *pCommandListDebugNameW; const char
	// *pCommandQueueDebugNameA; const wchar_t *pCommandQueueDebugNameW; ID3D12GraphicsCommandList *pCommandList; ID3D12CommandQueue
	// *pCommandQueue; UINT32 BreadcrumbCount; const UINT32 *pLastBreadcrumbValue; const D3D12_AUTO_BREADCRUMB_OP *pCommandHistory; const
	// D3D12_AUTO_BREADCRUMB_NODE *pNext; struct D3D12_AUTO_BREADCRUMB_NODE; } D3D12_AUTO_BREADCRUMB_NODE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_AUTO_BREADCRUMB_NODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_AUTO_BREADCRUMB_NODE
	{
		/// <summary>A pointer to the ANSI debug name of the outstanding command list (if any).</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pCommandListDebugNameA;

		/// <summary>A pointer to the wide debug name of the outstanding command list (if any).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pCommandListDebugNameW;

		/// <summary>A pointer to the ANSI debug name of the outstanding command queue (if any).</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pCommandQueueDebugNameA;

		/// <summary>A pointer to the wide debug name of the outstanding command queue (if any).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pCommandQueueDebugNameW;

		/// <summary>A pointer to the ID3D12GraphicsCommandList interface representing the outstanding command list at the time of execution.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12GraphicsCommandList pCommandList;

		/// <summary>A pointer to the ID3D12CommandQueue interface representing the outstanding command queue.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12CommandQueue pCommandQueue;

		/// <summary>A <c>UINT32</c> containing the count of D3D12_AUTO_BREADCRUMB_OP values in the array pointed to by .</summary>
		public uint BreadcrumbCount;

		/// <summary>
		/// A pointer to a constant <c>UINT32</c> containing the number of pCommandHistory breadcrumbs ops completed. As such, the last
		/// successfully completed breadcrumb op is at index in pCommandHistory.
		/// </summary>
		public StructPointer<uint> pLastBreadcrumbValue;

		/// <summary>
		/// A pointer to a constant array of D3D12_AUTO_BREADCRUMB_OP values representing all of the render/compute operations recorded into
		/// the associated command list.
		/// </summary>
		public ArrayPointer<D3D12_AUTO_BREADCRUMB_OP> pCommandHistory;

		/// <summary>
		/// A pointer to a constant <c>D3D12_AUTO_BREADCRUMB_NODE</c> representing the next auto-breadcrumb node in the list, or if this is
		/// the last node.
		/// </summary>
		public ManagedStructPointer<D3D12_AUTO_BREADCRUMB_NODE> pNext;
	}

	/// <summary>
	/// <para>
	/// Represents Device Removed Extended Data (DRED) auto-breadcrumb data as a node in a linked list. Each
	/// <c>D3D12_AUTO_BREADCRUMB_NODE</c> object is singly linked to the next via its <see cref="pNext"/> member; except for the last node
	/// in the list, which has its <see cref="pNext"/> set to <see langword="null"/>.
	/// </para>
	/// <para>
	/// The Direct3D 12 runtime creates one of these for each graphics command list, and tracks them in the command allocator associated
	/// with the list. When a command list is executed, the command queue information is set. After device removal is detected, the Direct3D
	/// 12 runtime links together the auto-breadcrumb nodes for any GPU work that is still outstanding.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_auto_breadcrumb_node1 typedef struct
	// D3D12_AUTO_BREADCRUMB_NODE1 { const char *pCommandListDebugNameA; const wchar_t *pCommandListDebugNameW; const char
	// *pCommandQueueDebugNameA; const wchar_t *pCommandQueueDebugNameW; ID3D12GraphicsCommandList *pCommandList; ID3D12CommandQueue
	// *pCommandQueue; UINT BreadcrumbCount; const UINT *pLastBreadcrumbValue; const D3D12_AUTO_BREADCRUMB_OP *pCommandHistory; const
	// D3D12_AUTO_BREADCRUMB_NODE1 *pNext; struct D3D12_AUTO_BREADCRUMB_NODE1; UINT BreadcrumbContextsCount; D3D12_DRED_BREADCRUMB_CONTEXT
	// *pBreadcrumbContexts; } D3D12_AUTO_BREADCRUMB_NODE1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_AUTO_BREADCRUMB_NODE1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_AUTO_BREADCRUMB_NODE1
	{
		/// <summary>A pointer to the ANSI debug name of the outstanding command list (if any).</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pCommandListDebugNameA;

		/// <summary>A pointer to the wide debug name of the outstanding command list (if any).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pCommandListDebugNameW;

		/// <summary>A pointer to the ANSI debug name of the outstanding command queue (if any).</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pCommandQueueDebugNameA;

		/// <summary>A pointer to the wide debug name of the outstanding command queue (if any).</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pCommandQueueDebugNameW;

		/// <summary>A pointer to the ID3D12GraphicsCommandList interface representing the outstanding command list at the time of execution.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12GraphicsCommandList pCommandList;

		/// <summary>A pointer to the ID3D12CommandQueue interface representing the outstanding command queue.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12CommandQueue pCommandQueue;

		/// <summary>A <c>UINT32</c> containing the count of D3D12_AUTO_BREADCRUMB_OP values in the array pointed to by .</summary>
		public uint BreadcrumbCount;

		/// <summary>
		/// A pointer to a constant <c>UINT32</c> containing the number of pCommandHistory breadcrumbs ops completed. As such, the last
		/// successfully completed breadcrumb op is at index in pCommandHistory.
		/// </summary>
		public StructPointer<uint> pLastBreadcrumbValue;

		/// <summary>
		/// A pointer to a constant array of D3D12_AUTO_BREADCRUMB_OP values representing all of the render/compute operations recorded into
		/// the associated command list.
		/// </summary>
		public ArrayPointer<D3D12_AUTO_BREADCRUMB_OP> pCommandHistory;

		/// <summary>
		/// A pointer to a constant <c>D3D12_AUTO_BREADCRUMB_NODE</c> representing the next auto-breadcrumb node in the list, or if this is
		/// the last node.
		/// </summary>
		public IntPtr /* D3D12_AUTO_BREADCRUMB_NODE* */ pNext;

		/// <summary>Number of D3D12_DRED_BREADCRUMB_CONTEXT elements in the array pointed to by pBreadcrumbContexts.</summary>
		public uint BreadcrumbContextsCount;

		/// <summary>Pointer to an array of D3D12_DRED_BREADCRUMB_CONTEXT structures.</summary>
		public ManagedArrayPointer<D3D12_DRED_BREADCRUMB_CONTEXT> pBreadcrumbContexts;
	}

	/// <summary>Describes a group of barriers of a given type.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_barrier_group typedef struct D3D12_BARRIER_GROUP {
	// D3D12_BARRIER_TYPE Type; UINT32 NumBarriers; union { const D3D12_GLOBAL_BARRIER *pGlobalBarriers; const D3D12_TEXTURE_BARRIER
	// *pTextureBarriers; const D3D12_BUFFER_BARRIER *pBufferBarriers; }; } D3D12_BARRIER_GROUP;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BARRIER_GROUP")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_BARRIER_GROUP
	{
		/// <summary>The type of barriers in the group.</summary>
		[FieldOffset(0)]
		public D3D12_BARRIER_TYPE Type;

		/// <summary>The number of barriers in the group.</summary>
		[FieldOffset(4)]
		public uint NumBarriers;

		/// <summary>A pointer to an array of <c>D3D12_GLOBAL_BARRIER</c> structures, if Type is <b>D3D12_BARRIER_TYPE::D3D12_BARRIER_TYPE_GLOBAL</b>.</summary>
		[FieldOffset(8)]
		public ManagedArrayPointer<D3D12_GLOBAL_BARRIER> pGlobalBarriers;

		/// <summary>A pointer to an array of <c>D3D12_TEXTURE_BARRIER</c> structures, if Type is <b>D3D12_BARRIER_TYPE::D3D12_BARRIER_TYPE_TEXTURE</b>.</summary>
		[FieldOffset(8)]
		public ManagedArrayPointer<D3D12_TEXTURE_BARRIER> pTextureBarriers;

		/// <summary>A pointer to an array of <c>D3D12_BUFFER_BARRIER</c> structures, if Type is <b>D3D12_BARRIER_TYPE::D3D12_BARRIER_TYPE_BUFFER</b>.</summary>
		[FieldOffset(8)]
		public ManagedArrayPointer<D3D12_BUFFER_BARRIER> pBufferBarriers;

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_GROUP"/> struct.</summary>
		/// <param name="pBarriers">The barriers.</param>
		/// <param name="memoryHandle">A memory handle holding the converted barriers.</param>
		public D3D12_BARRIER_GROUP(D3D12_GLOBAL_BARRIER[] pBarriers, out SafeAllocatedMemoryHandle memoryHandle)
		{
			Type = D3D12_BARRIER_TYPE.D3D12_BARRIER_TYPE_GLOBAL;
			NumBarriers = (uint?)pBarriers?.Length ?? 0;
			pGlobalBarriers = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pBarriers ?? []);
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_GROUP"/> struct.</summary>
		/// <param name="pBarriers">The barriers.</param>
		/// <param name="memoryHandle">A memory handle holding the converted barriers.</param>
		public D3D12_BARRIER_GROUP(D3D12_TEXTURE_BARRIER[] pBarriers, out SafeAllocatedMemoryHandle memoryHandle)
		{
			Type = D3D12_BARRIER_TYPE.D3D12_BARRIER_TYPE_TEXTURE;
			NumBarriers = (uint?)pBarriers?.Length ?? 0;
			pTextureBarriers = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pBarriers ?? []);
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_GROUP"/> struct.</summary>
		/// <param name="pBarriers">The barriers.</param>
		/// <param name="memoryHandle">A memory handle holding the converted barriers.</param>
		public D3D12_BARRIER_GROUP(D3D12_BUFFER_BARRIER[] pBarriers, out SafeAllocatedMemoryHandle memoryHandle)
		{
			Type = D3D12_BARRIER_TYPE.D3D12_BARRIER_TYPE_BUFFER;
			NumBarriers = (uint?)pBarriers?.Length ?? 0;
			pBufferBarriers = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pBarriers ?? []);
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_GROUP"/> struct.</summary>
		/// <param name="numBarriers">The number of barriers.</param>
		/// <param name="pBarriers">The barriers.</param>
		public D3D12_BARRIER_GROUP(SizeT numBarriers, ManagedArrayPointer<D3D12_GLOBAL_BARRIER> pBarriers)
		{
			Type = D3D12_BARRIER_TYPE.D3D12_BARRIER_TYPE_GLOBAL;
			NumBarriers = numBarriers;
			pGlobalBarriers = pBarriers;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_GROUP"/> struct.</summary>
		/// <param name="numBarriers">The number of barriers.</param>
		/// <param name="pBarriers">The barriers.</param>
		public D3D12_BARRIER_GROUP(SizeT numBarriers, ManagedArrayPointer<D3D12_TEXTURE_BARRIER> pBarriers)
		{
			Type = D3D12_BARRIER_TYPE.D3D12_BARRIER_TYPE_TEXTURE;
			NumBarriers = numBarriers;
			pTextureBarriers = pBarriers;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_GROUP"/> struct.</summary>
		/// <param name="numBarriers">The number of barriers.</param>
		/// <param name="pBarriers">The barriers.</param>
		public D3D12_BARRIER_GROUP(SizeT numBarriers, ManagedArrayPointer<D3D12_BUFFER_BARRIER> pBarriers)
		{
			Type = D3D12_BARRIER_TYPE.D3D12_BARRIER_TYPE_BUFFER;
			NumBarriers = numBarriers;
			pBufferBarriers = pBarriers;
		}
	}

	/// <summary>Allows you to transition logically-adjacent ranges of subresources.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_barrier_subresource_range typedef struct
	// D3D12_BARRIER_SUBRESOURCE_RANGE { UINT IndexOrFirstMipLevel; UINT NumMipLevels; UINT FirstArraySlice; UINT NumArraySlices; UINT
	// FirstPlane; UINT NumPlanes; } D3D12_BARRIER_SUBRESOURCE_RANGE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BARRIER_SUBRESOURCE_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BARRIER_SUBRESOURCE_RANGE(uint indexOrFirstMipLevel, uint numMipLevels, uint firstArraySlice, uint numArraySlices, uint firstPlane = 0, uint numPlanes = 1)
	{
		/// <summary>
		/// The index of the first mip level in the range; or a subresource index, if NumMipLevels is zero. If a subresource index, then you
		/// can use the value <c>0xffffffff</c> to specify all subresources.
		/// </summary>
		public uint IndexOrFirstMipLevel = indexOrFirstMipLevel;

		/// <summary>Number of mip levels in the range, or zero to indicate that IndexOrFirstMipLevel is a subresource index.</summary>
		public uint NumMipLevels = numMipLevels;

		/// <summary>Index of first array slice in the range. Ignored if NumMipLevels is zero.</summary>
		public uint FirstArraySlice = firstArraySlice;

		/// <summary>Number of array slices in the range. Ignored if NumMipLevels is zero.</summary>
		public uint NumArraySlices = numArraySlices;

		/// <summary>First plane slice in the range. Ignored if NumMipLevels is zero.</summary>
		public uint FirstPlane = firstPlane;

		/// <summary>Number of plane slices in the range. Ignored if NumMipLevels is zero.</summary>
		public uint NumPlanes = numPlanes;

		/// <summary>Initializes a new instance of the <see cref="D3D12_BARRIER_SUBRESOURCE_RANGE"/> struct.</summary>
		/// <param name="subresource">The subresource.</param>
		public D3D12_BARRIER_SUBRESOURCE_RANGE(uint subresource) : this(subresource, 0, 0, 0, 0, 0) { }
	}

	/// <summary>Describes the blend state.</summary>
	/// <remarks>
	/// <para>
	/// A <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> object contains a blend-state structure that controls blending by the output-merger stage.
	/// </para>
	/// <para>Here are the default values for blend state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>AlphaToCoverageEnable</description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description>IndependentBlendEnable</description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].BlendEnable</description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].LogicOpEnable</description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].SrcBlend</description>
	/// <description>D3D12_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].DestBlend</description>
	/// <description>D3D12_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].BlendOp</description>
	/// <description>D3D12_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].SrcBlendAlpha</description>
	/// <description>D3D12_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].DestBlendAlpha</description>
	/// <description>D3D12_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].BlendOpAlpha</description>
	/// <description>D3D12_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].LogicOp</description>
	/// <description>D3D12_LOGIC_OP_NOOP</description>
	/// </item>
	/// <item>
	/// <description>RenderTarget[0].RenderTargetWriteMask</description>
	/// <description>D3D12_COLOR_WRITE_ENABLE_ALL</description>
	/// </item>
	/// </list>
	/// <para>
	/// When you set the <b>LogicOpEnable</b> member of the first element of the <b>RenderTarget</b> array ( <b>RenderTarget</b>[0]) to
	/// <b>TRUE</b>, you must also set the <b>BlendEnable</b> member of <b>RenderTarget</b>[0] to <b>FALSE</b>, and the
	/// <b>IndependentBlendEnable</b> member of this structure to <b>FALSE</b>. This reflects the limitation in hardware that you can't mix
	/// logic operations with blending across multiple render targets, and that when you use a logic operation, you must apply the same
	/// logic operation to all render targets.
	/// </para>
	/// <para>Note the helper structure, <c>CD3DX12_BLEND_DESC</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_blend_desc typedef struct D3D12_BLEND_DESC { BOOL
	// AlphaToCoverageEnable; BOOL IndependentBlendEnable; D3D12_RENDER_TARGET_BLEND_DESC RenderTarget[8]; } D3D12_BLEND_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BLEND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BLEND_DESC
	{
		/// <summary>
		/// Specifies whether to use alpha-to-coverage as a multisampling technique when setting a pixel to a render target. For more info
		/// about using alpha-to-coverage, see <c>Alpha-To-Coverage</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AlphaToCoverageEnable;

		/// <summary>
		/// <para>
		/// Specifies whether to enable independent blending in simultaneous render targets. Set to <b>TRUE</b> to enable independent
		/// blending. If set to <b>FALSE</b>, only the <b>RenderTarget</b>[0] members are used; <b>RenderTarget</b>[1..7] are ignored.
		/// </para>
		/// <para>See the <b>Remarks</b> section for restrictions.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool IndependentBlendEnable;

		/// <summary>
		/// An array of <c>D3D12_RENDER_TARGET_BLEND_DESC</c> structures that describe the blend states for render targets; these correspond
		/// to the eight render targets that can be bound to the <c>output-merger stage</c> at one time.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public D3D12_RENDER_TARGET_BLEND_DESC[] _RenderTarget;

		/// <summary>
		/// Sets the array of <c>D3D12_RENDER_TARGET_BLEND_DESC</c> structures that describe the blend states for render targets; these
		/// correspond to the eight render targets that can be bound to the <c>output-merger stage</c> at one time. This method ensures that
		/// the structure's value always has a length of 8.
		/// </summary>
		/// <param name="value">The array of <c>D3D12_RENDER_TARGET_BLEND_DESC</c> structures.</param>
		[MemberNotNull(nameof(_RenderTarget))]
		public void SetRenderTarget(params D3D12_RENDER_TARGET_BLEND_DESC[] value)
		{
			_RenderTarget = new D3D12_RENDER_TARGET_BLEND_DESC[8];
			if (value is null || value.Length == 0) return;
			Array.ConstrainedCopy(value, 0, _RenderTarget, 0, Math.Min(value.Length, 8));
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_BLEND_DESC"/> struct with standard (not default) values.</summary>
		public D3D12_BLEND_DESC()
		{
			AlphaToCoverageEnable = IndependentBlendEnable = false;
			D3D12_RENDER_TARGET_BLEND_DESC def = new()
			{
				BlendEnable = false,
				LogicOpEnable = false,
				SrcBlend = D3D12_BLEND.D3D12_BLEND_ONE,
				DestBlend = D3D12_BLEND.D3D12_BLEND_ZERO,
				BlendOp = D3D12_BLEND_OP.D3D12_BLEND_OP_ADD,
				SrcBlendAlpha = D3D12_BLEND.D3D12_BLEND_ONE,
				DestBlendAlpha = D3D12_BLEND.D3D12_BLEND_ZERO,
				BlendOpAlpha = D3D12_BLEND_OP.D3D12_BLEND_OP_ADD,
				LogicOp = D3D12_LOGIC_OP.D3D12_LOGIC_OP_NOOP,
				RenderTargetWriteMask = D3D12_COLOR_WRITE_ENABLE.D3D12_COLOR_WRITE_ENABLE_ALL
			};
			_RenderTarget = new D3D12_RENDER_TARGET_BLEND_DESC[8];
			for (var i = 0; i < 8; i++)
				_RenderTarget[i] = def;
		}
	}

	/// <summary>
	/// Describes a buffer memory access barrier. Used by buffer barriers to indicate when resource memory must be made visible for a
	/// specific access type.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_barrier typedef struct D3D12_BUFFER_BARRIER {
	// D3D12_BARRIER_SYNC SyncBefore; D3D12_BARRIER_SYNC SyncAfter; D3D12_BARRIER_ACCESS AccessBefore; D3D12_BARRIER_ACCESS AccessAfter;
	// ID3D12Resource *pResource; UINT64 Offset; UINT64 Size; } D3D12_BUFFER_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUFFER_BARRIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUFFER_BARRIER(D3D12_BARRIER_SYNC syncBefore, D3D12_BARRIER_SYNC syncAfter, D3D12_BARRIER_ACCESS accessBefore,
		D3D12_BARRIER_ACCESS accessAfter, ID3D12Resource pResource)
	{
		/// <summary>Synchronization scope of all preceding GPU work that must be completed before executing the barrier.</summary>
		public D3D12_BARRIER_SYNC SyncBefore = syncBefore;

		/// <summary>Synchronization scope of all subsequent GPU work that must wait until the barrier execution is finished.</summary>
		public D3D12_BARRIER_SYNC SyncAfter = syncAfter;

		/// <summary>
		/// Access bits corresponding with resource usage since the preceding barrier, or the start of <b>ExecuteCommandLists</b> scope.
		/// </summary>
		public D3D12_BARRIER_ACCESS AccessBefore = accessBefore;

		/// <summary>Access bits corresponding with resource usage after the barrier completes.</summary>
		public D3D12_BARRIER_ACCESS AccessAfter = accessAfter;

		/// <summary>Pointer to the buffer resource being using the barrier.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12Resource pResource = pResource;

		/// <summary>Must be 0.</summary>
		public ulong Offset = 0;

		/// <summary>Must be either <b>UINT64_MAX</b> or the size of the buffer in bytes.</summary>
		public ulong Size = ulong.MaxValue;
	}

	/// <summary>Describes the elements in a buffer resource to use in a render-target view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as a buffer.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_rtv typedef struct D3D12_BUFFER_RTV { UINT64
	// FirstElement; UINT NumElements; } D3D12_BUFFER_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUFFER_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUFFER_RTV
	{
		/// <summary>Number of elements between the beginning of the buffer and the first element to access.</summary>
		public ulong FirstElement;

		/// <summary>The total number of elements in the view.</summary>
		public uint NumElements;
	}

	/// <summary>Describes the elements in a buffer resource to use in a shader-resource view.</summary>
	/// <remarks>
	/// <para>This structure is used by <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c> to create a view of a buffer.</para>
	/// <para>
	/// If the value of StructureByteStride is not 0, then a view of a structured buffer is created, and then the
	/// D3D12_SHADER_RESOURCE_VIEW_DESC::Format field must be <b>DXGI_FORMAT_UNKNOWN</b>. If StructureByteStride is 0, then a typed view of
	/// a buffer is created, and then a format must be supplied. The specified format for the typed view must be supported by the hardware.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_srv typedef struct D3D12_BUFFER_SRV { UINT64
	// FirstElement; UINT NumElements; UINT StructureByteStride; D3D12_BUFFER_SRV_FLAGS Flags; } D3D12_BUFFER_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUFFER_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUFFER_SRV
	{
		/// <summary>The index of the first element to be accessed by the view.</summary>
		public ulong FirstElement;

		/// <summary>The number of elements in the resource.</summary>
		public uint NumElements;

		/// <summary>
		/// The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer. The size must match
		/// the struct size declared in shaders that access the view.
		/// </summary>
		public uint StructureByteStride;

		/// <summary>
		/// A <c>D3D12_BUFFER_SRV_FLAGS</c>-typed value that identifies view options for the buffer. Currently, the only option is to
		/// identify a raw view of the buffer. For more info about raw viewing of buffers, see <c>Raw Views of Buffers</c>.
		/// </summary>
		public D3D12_BUFFER_SRV_FLAGS Flags;
	}

	/// <summary>Describes the elements in a buffer to use in a unordered-access view.</summary>
	/// <remarks>
	/// <para>Use this structure with a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure to view the resource as a buffer.</para>
	/// <para>
	/// If <i>StructureByteStride</i> value is not 0, a view of a structured buffer is created and the
	/// D3D12_UNORDERED_ACCESS_VIEW_DESC::Format field must be DXGI_FORMAT_UNKNOWN. If <i>StructureByteStride</i> is 0, a typed view of a
	/// buffer is created and a format must be supplied. The specified format for the typed view must be supported by the hardware. More
	/// information on this topic can be found in the <c>Typed unordered access view (UAV) loads</c> page.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_buffer_uav typedef struct D3D12_BUFFER_UAV { UINT64
	// FirstElement; UINT NumElements; UINT StructureByteStride; UINT64 CounterOffsetInBytes; D3D12_BUFFER_UAV_FLAGS Flags; } D3D12_BUFFER_UAV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUFFER_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUFFER_UAV
	{
		/// <summary>The zero-based index of the first element to be accessed.</summary>
		public ulong FirstElement;

		/// <summary>The number of elements in the resource. For structured buffers, this is the number of structures in the buffer.</summary>
		public uint NumElements;

		/// <summary>The size of each element in the buffer structure (in bytes) when the buffer represents a structured buffer.</summary>
		public uint StructureByteStride;

		/// <summary>The counter offset, in bytes.</summary>
		public ulong CounterOffsetInBytes;

		/// <summary>A <c>D3D12_BUFFER_UAV_FLAGS</c>-typed value that specifies the view options for the resource.</summary>
		public D3D12_BUFFER_UAV_FLAGS Flags;
	}

	/// <summary>
	/// Describes a raytracing acceleration structure. Pass this structure into
	/// <c>ID3D12GraphicsCommandList4::BuildRaytracingAccelerationStructure</c> to describe the acceleration structure to be built.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_build_raytracing_acceleration_structure_desc typedef struct
	// D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_DESC { D3D12_GPU_VIRTUAL_ADDRESS DestAccelerationStructureData;
	// D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS Inputs; D3D12_GPU_VIRTUAL_ADDRESS SourceAccelerationStructureData;
	// D3D12_GPU_VIRTUAL_ADDRESS ScratchAccelerationStructureData; } D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_DESC
	{
		/// <summary>
		/// <para>
		/// Location to store resulting acceleration structure. <c>ID3D12Device5::GetRaytracingAccelerationStructurePrebuildInfo</c> reports
		/// the amount of memory required for the result here given a set of acceleration structure build parameters.
		/// </para>
		/// <para>The address must be aligned to 256 bytes, defined as <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BYTE_ALIGNMENT</c>.</para>
		/// <para>
		/// <para>Important</para>
		/// <para>The memory must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.</para>
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS DestAccelerationStructureData;

		/// <summary>
		/// Description of the input data for the acceleration structure build. This is data is stored in a separate structure because it is
		/// also used with <b>GetRaytracingAccelerationStructurePrebuildInfo</b>.
		/// </summary>
		public D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS Inputs;

		/// <summary>
		/// <para>
		/// Address of an existing acceleration structure if an acceleration structure update (an incremental build) is being requested, by
		/// setting <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_PERFORM_UPDATE</c> in the Flags parameter. Otherwise this address
		/// must be NULL.
		/// </para>
		/// <para>
		/// If this address is the same as <i>DestAccelerationStructureData</i>, the update is to be performed in-place. Any other form of
		/// overlap of the source and destination memory is invalid and produces undefined behavior.
		/// </para>
		/// <para>
		/// The address must be aligned to 256 bytes, defined as <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BYTE_ALIGNMENT</c>, which should
		/// automatically be the case because any existing acceleration structure passed in here would have already been required to be
		/// placed with such alignment.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>The memory must be in state <c><b>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</b></c>.</para>
		/// </para>
		/// <para>ScratchAccelerationStructureData</para>
		/// <para>
		/// Location where the build will store temporary data. <b>GetRaytracingAccelerationStructurePrebuildInfo</b> reports the amount of
		/// scratch memory the implementation will need for a given set of acceleration structure build parameters.
		/// </para>
		/// <para>
		/// <para>Important</para>
		/// <para>The memory must be in state <c><b>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</b></c>.</para>
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS SourceAccelerationStructureData;

		/// <summary/>
		public D3D12_GPU_VIRTUAL_ADDRESS ScratchAccelerationStructureData;
	}

	/// <summary>
	/// Defines the inputs for a raytracing acceleration structure build operation. This structure is used by
	/// <c>ID3D12GraphicsCommandList4::BuildRaytracingAccelerationStructure</c> and <c>ID3D12Device5::GetRaytracingAccelerationStructurePrebuildInfo</c>.
	/// </summary>
	/// <remarks>
	/// When used with <c>GetRaytracingAccelerationStructurePrebuildInfo</c>, which actually perform a build, any parameter that is
	/// referenced via <c>D3D12_GPU_VIRTUAL_ADDRESS</c> (an address in GPU memory), like <i>InstanceDescs</i>, will not be accessed by the
	/// operation. So this memory does not need to be initialized yet or be in a particular resource state. Whether GPU addresses are null
	/// or not can be inspected by the operation, even though the pointers are not dereferenced.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_build_raytracing_acceleration_structure_inputs typedef
	// struct D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS { D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE Type;
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAGS Flags; UINT NumDescs; D3D12_ELEMENTS_LAYOUT DescsLayout; union {
	// D3D12_GPU_VIRTUAL_ADDRESS InstanceDescs; const D3D12_RAYTRACING_GEOMETRY_DESC *pGeometryDescs; const D3D12_RAYTRACING_GEOMETRY_DESC
	// const * * ppGeometryDescs; }; } D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS
	{
		/// <summary>The type of acceleration structure to build.</summary>
		public D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE Type;

		/// <summary>The build flags.</summary>
		public D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAGS Flags;

		/// <summary>
		/// <para>
		/// If <i>Type</i> is <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TOP_LEVEL</b>, this value is the number of instances, laid out
		/// based on <i>DescsLayout</i>.
		/// </para>
		/// <para>
		/// If <i>Type</i> is <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BOTTOM_LEVEL</b>, this value is the number of elements referred to
		/// by <i>pGeometryDescs</i> or <i>ppGeometryDescs</i>. Which of these fields is used depends on <i>DescsLayout</i>.
		/// </para>
		/// </summary>
		public uint NumDescs;

		/// <summary>How geometry descriptions are specified; either an array of descriptions or an array of pointers to descriptions.</summary>
		public D3D12_ELEMENTS_LAYOUT DescsLayout;

		private IntPtr union;

		/// <summary>
		/// <para>
		/// If <i>Type</i> is <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TOP_LEVEL</b>, this refers to
		/// <i>NumDescs</i><c>D3D12_RAYTRACING_INSTANCE_DESC</c> structures in GPU memory describing instances. Each instance must be
		/// aligned to 16 bytes, defined as <c>D3D12_RAYTRACING_INSTANCE_DESC_BYTE_ALIGNMENT</c>.
		/// </para>
		/// <para>If <i>Type</i> is not <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TOP_LEVEL</b>, this parameter is unused.</para>
		/// <para>
		/// If <i>DescLayout</i> is <b>D3D12_ELEMENTS_LAYOUT_ARRAY</b>, <i>InstanceDescs</i> points to an array of instance descriptions in
		/// GPU memory.
		/// </para>
		/// <para>
		/// If <i>DescLayout</i> is <b>D3D12_ELEMENTS_LAYOUT_ARRAY_OF_POINTERS</b>, <i>InstanceDescs</i> points to an array in GPU memory of
		/// <c>D3D12_GPU_VIRTUAL_ADDRESS</c> pointers to instance descriptions.
		/// </para>
		/// <para>The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>.</para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS InstanceDescs { readonly get => (ulong)union; set => union = (IntPtr)value; }

		/// <summary>
		/// <para>
		/// If <i>Type</i> is <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BOTTOM_LEVEL</b>, and <i>DescsLayout</i> is
		/// <b>D3D12_ELEMENTS_LAYOUT_ARRAY</b>, this field is used and points to <i>NumDescs</i> contiguous
		/// <b>D3D12_RAYTRACING_GEOMETRY_DESC</b> structures on the CPU, describing individual geometries.
		/// </para>
		/// <para>
		/// If <i>Type</i> is not <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BOTTOM_LEVEL</b> or <i>DescsLayout</i> is not
		/// <b>D3D12_ELEMENTS_LAYOUT_ARRAY</b>, this parameter is unused.
		/// </para>
		/// </summary>
		public Span<D3D12_RAYTRACING_GEOMETRY_DESC> pGeometryDescs => Type == D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL &&
			DescsLayout == D3D12_ELEMENTS_LAYOUT.D3D12_ELEMENTS_LAYOUT_ARRAY && NumDescs > 0 ? union.AsSpan<D3D12_RAYTRACING_GEOMETRY_DESC>(NumDescs) : [];

		/// <summary>
		/// If <i>Type</i> is <b>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BOTTOM_LEVEL</b>, and <i>DescsLayout</i> is
		/// <b>D3D12_ELEMENTS_LAYOUT_ARRAY_OF_POINTERS</b>, this field is used and points to an array of <i>NumDescs</i> pointers to
		/// <c>D3D12_RAYTRACING_GEOMETRY_DESC</c> structures on the CPU, describing individual geometries.
		/// </summary>
		public unsafe D3D12_RAYTRACING_GEOMETRY_DESC*[] ppGeometryDescs
		{
			get
			{
				if (Type == D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL &&
					DescsLayout == D3D12_ELEMENTS_LAYOUT.D3D12_ELEMENTS_LAYOUT_ARRAY_OF_POINTERS && NumDescs > 0)
				{
					var pa = union.ToArray<IntPtr>(NumDescs)!;
					var ret = new D3D12_RAYTRACING_GEOMETRY_DESC*[NumDescs];
					for (var i = 0; i < NumDescs; i++)
						ret[i] = (D3D12_RAYTRACING_GEOMETRY_DESC*)pa[i];
					return ret;
				}
				return [];
			}
		}
	}

	/// <summary>Describes the GPU memory layout of an acceleration structure visualization.</summary>
	/// <remarks>
	/// This structure functions like the inverse of the inputs to an acceleration structure build, focused on the instance or geometry
	/// details, depending on the acceleration structure type.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_build_raytracing_acceleration_structure_tools_visualization_header
	// typedef struct D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_TOOLS_VISUALIZATION_HEADER {
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE Type; UINT NumDescs; } D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_TOOLS_VISUALIZATION_HEADER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_TOOLS_VISUALIZATION_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_TOOLS_VISUALIZATION_HEADER
	{
		/// <summary>The type of acceleration structure.</summary>
		public D3D12_RAYTRACING_ACCELERATION_STRUCTURE_TYPE Type;

		/// <summary>The number of descriptions.</summary>
		public uint NumDescs;
	}

	/// <summary>Stores a pipeline state.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used by the <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure, and the <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> structure.
	/// </para>
	/// <para>
	/// This structure is intended to be filled with the data retrieved from <c>ID3D12PipelineState::GetCachedBlob</c>. This cached PSO
	/// contains data specific to the hardware, driver, and machine that it was retrieved from. Compilation using this data should be faster
	/// than compilation without. The rest of the data in the PSO needs to still be valid, and needs to match the cached PSO, otherwise
	/// E_INVALIDARG might be returned.
	/// </para>
	/// <para>
	/// If the driver has been upgraded to a D3D12 driver after the PSO was cached, you might see a D3D12_ERROR_DRIVER_VERSION_MISMATCH
	/// return code, or if you’re running on a different GPU, the D3D12_ERROR_ADAPTER_NOT_FOUND return code.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_cached_pipeline_state typedef struct
	// D3D12_CACHED_PIPELINE_STATE { const void *pCachedBlob; SIZE_T CachedBlobSizeInBytes; } D3D12_CACHED_PIPELINE_STATE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_CACHED_PIPELINE_STATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_CACHED_PIPELINE_STATE
	{
		/// <summary>Specifies pointer that references the memory location of the cache.</summary>
		public IntPtr pCachedBlob;

		/// <summary>Specifies the size of the cache in bytes.</summary>
		public SizeT CachedBlobSizeInBytes;
	}

	/// <summary>Describes a value used to optimize clear operations for a particular resource.</summary>
	/// <remarks>
	/// <para>This structure is optionally passed into the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12Device::CreateCommittedResource</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreatePlacedResource</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateReservedResource</c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_clear_value typedef struct D3D12_CLEAR_VALUE { DXGI_FORMAT
	// Format; union { FLOAT Color[4]; D3D12_DEPTH_STENCIL_VALUE DepthStencil; }; } D3D12_CLEAR_VALUE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_CLEAR_VALUE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_CLEAR_VALUE : IEquatable<D3D12_CLEAR_VALUE>
	{
		/// <summary>
		/// <para>Specifies one member of the <c>DXGI_FORMAT</c> enum.</para>
		/// <para>
		/// The format of the commonly cleared color follows the same validation rules as a view/ descriptor creation. In general, the
		/// format of the clear color can be any format in the same typeless group that the resource format belongs to.
		/// </para>
		/// <para>
		/// This <i>Format</i> must match the format of the view used during the clear operation. It indicates whether the <i>Color</i> or
		/// the <i>DepthStencil</i> member is valid and how to convert the values for usage with the resource.
		/// </para>
		/// </summary>
		public DXGI_FORMAT Format;

		private UNION u;

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public D3DCOLORVALUE Color;

			[FieldOffset(0)]
			public D3D12_DEPTH_STENCIL_VALUE DepthStencil;
		}

		/// <summary>
		/// Specifies a 4-entry array of float values, determining the RGBA value. The order of RGBA matches the order used with <c>ClearRenderTargetView</c>.
		/// </summary>
		public float[] Color { readonly get => (float[])u.Color; set => u.Color = value; }

		/// <summary>
		/// Specifies one member of <c>D3D12_DEPTH_STENCIL_VALUE</c>. These values match the semantics of <i>Depth</i> and <i>Stencil</i> in <c>ClearDepthStencilView</c>.
		/// </summary>
		public D3D12_DEPTH_STENCIL_VALUE DepthStencil { readonly get => u.DepthStencil; set => u.DepthStencil = value; }

		/// <summary>Initializes a new instance of the <see cref="D3D12_CLEAR_VALUE"/> struct.</summary>
		/// <param name="format">Specifies one member of the <c>DXGI_FORMAT</c> enum.</param>
		/// <param name="color">Specifies a 4-entry array of float values, determining the RGBA value.</param>
		public D3D12_CLEAR_VALUE(DXGI_FORMAT format, in D3DCOLORVALUE color)
		{
			Format = format;
			u.Color = color;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_CLEAR_VALUE"/> struct.</summary>
		/// <param name="format">Specifies one member of the <c>DXGI_FORMAT</c> enum.</param>
		/// <param name="depth">Specifies the depth value.</param>
		/// <param name="stencil">Specifies the stencil value.</param>
		public D3D12_CLEAR_VALUE(DXGI_FORMAT format, float depth, byte stencil)
		{
			Format = format;
			u.DepthStencil = new() { Depth = depth, Stencil = stencil };
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_CLEAR_VALUE vALUE && Equals(vALUE);

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_CLEAR_VALUE other) => Format == other.Format &&
			Format is DXGI_FORMAT.DXGI_FORMAT_D24_UNORM_S8_UINT or DXGI_FORMAT.DXGI_FORMAT_D16_UNORM or DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT or
			DXGI_FORMAT.DXGI_FORMAT_D32_FLOAT_S8X24_UINT ? u.DepthStencil.Depth == other.u.DepthStencil.Depth && u.DepthStencil.Stencil == other.u.DepthStencil.Stencil :
			u.Color.Equals(other.u.Color);

		/// <inheritdoc/>
		public override int GetHashCode() => (Format, u.Color).GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_CLEAR_VALUE left, D3D12_CLEAR_VALUE right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_CLEAR_VALUE left, D3D12_CLEAR_VALUE right) => !(left == right);
	}

	/// <summary>Describes a command queue.</summary>
	/// <remarks>
	/// <para>This structure is passed into <c>CreateCommandQueue</c>.</para>
	/// <para>This structure is returned by <c>ID3D12CommandQueue::GetDesc</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_command_queue_desc typedef struct D3D12_COMMAND_QUEUE_DESC {
	// D3D12_COMMAND_LIST_TYPE Type; INT Priority; D3D12_COMMAND_QUEUE_FLAGS Flags; UINT NodeMask; } D3D12_COMMAND_QUEUE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_COMMAND_QUEUE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_COMMAND_QUEUE_DESC
	{
		/// <summary>Specifies one member of <c>D3D12_COMMAND_LIST_TYPE</c>.</summary>
		public D3D12_COMMAND_LIST_TYPE Type;

		/// <summary>
		/// The priority for the command queue, as a <see cref="D3D12_COMMAND_QUEUE_PRIORITY"/> enumeration constant to select normal or
		/// high priority.
		/// </summary>
		public D3D12_COMMAND_QUEUE_PRIORITY Priority;

		/// <summary>Specifies any flags from the <c>D3D12_COMMAND_QUEUE_FLAGS</c> enumeration.</summary>
		public D3D12_COMMAND_QUEUE_FLAGS Flags;

		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the command queue applies. Each bit in the mask corresponds to a single node. Only 1 bit must be set.
		/// Refer to <c>Multi-adapter systems</c>.
		/// </summary>
		public uint NodeMask;
	}

	/// <summary>Describes the arguments (parameters) of a command signature.</summary>
	/// <remarks>Use this structure by <c>CreateCommandSignature</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_command_signature_desc typedef struct
	// D3D12_COMMAND_SIGNATURE_DESC { UINT ByteStride; UINT NumArgumentDescs; const D3D12_INDIRECT_ARGUMENT_DESC *pArgumentDescs; UINT
	// NodeMask; } D3D12_COMMAND_SIGNATURE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_COMMAND_SIGNATURE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_COMMAND_SIGNATURE_DESC
	{
		/// <summary>Specifies the size of each command in the drawing buffer, in bytes.</summary>
		public uint ByteStride;

		/// <summary>Specifies the number of arguments in the command signature.</summary>
		public uint NumArgumentDescs;

		/// <summary>
		/// An array of <c>D3D12_INDIRECT_ARGUMENT_DESC</c> structures, containing details of the arguments, including whether the argument
		/// is a vertex buffer, constant, constant buffer view, shader resource view, or unordered access view.
		/// </summary>
		public ArrayPointer<D3D12_INDIRECT_ARGUMENT_DESC> pArgumentDescs;

		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set bits to identify the nodes (the device's
		/// physical adapters) for which the command signature is to apply. Each bit in the mask corresponds to a single node. Refer to
		/// <c>Multi-adapter systems</c>.
		/// </summary>
		public uint NodeMask;
	}

	/// <summary>Describes a compute pipeline state object.</summary>
	/// <remarks>This structure is used by <c>CreateComputePipelineState</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_compute_pipeline_state_desc typedef struct
	// D3D12_COMPUTE_PIPELINE_STATE_DESC { ID3D12RootSignature *pRootSignature; D3D12_SHADER_BYTECODE CS; UINT NodeMask;
	// D3D12_CACHED_PIPELINE_STATE CachedPSO; D3D12_PIPELINE_STATE_FLAGS Flags; } D3D12_COMPUTE_PIPELINE_STATE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_COMPUTE_PIPELINE_STATE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_COMPUTE_PIPELINE_STATE_DESC
	{
		/// <summary>A pointer to the <c>ID3D12RootSignature</c> object.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12RootSignature pRootSignature;

		/// <summary>A <c>D3D12_SHADER_BYTECODE</c> structure that describes the compute shader.</summary>
		public D3D12_SHADER_BYTECODE CS;

		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set bits to identify the nodes (the device's
		/// physical adapters) for which the compute pipeline state is to apply. Each bit in the mask corresponds to a single node. Refer to
		/// <c>Multi-adapter systems</c>.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// A cached pipeline state object, as a <c>D3D12_CACHED_PIPELINE_STATE</c> structure. pCachedBlob and CachedBlobSizeInBytes may be
		/// set to NULL and 0 respectively.
		/// </summary>
		public D3D12_CACHED_PIPELINE_STATE CachedPSO;

		/// <summary>A <c>D3D12_PIPELINE_STATE_FLAGS</c> enumeration constant such as for "tool debug".</summary>
		public D3D12_PIPELINE_STATE_FLAGS Flags;
	}

	/// <summary>Describes a constant buffer to view.</summary>
	/// <remarks>This structure is used by <c>CreateConstantBufferView</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_constant_buffer_view_desc typedef struct
	// D3D12_CONSTANT_BUFFER_VIEW_DESC { D3D12_GPU_VIRTUAL_ADDRESS BufferLocation; UINT SizeInBytes; } D3D12_CONSTANT_BUFFER_VIEW_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_CONSTANT_BUFFER_VIEW_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_CONSTANT_BUFFER_VIEW_DESC
	{
		/// <summary>The D3D12_GPU_VIRTUAL_ADDRESS of the constant buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd alias of UINT64.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

		/// <summary>The size in bytes of the constant buffer.</summary>
		public uint SizeInBytes;
	}

	/// <summary>Describes a CPU descriptor handle.</summary>
	/// <remarks>
	/// <para>This structure is returned by the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12DescriptorHeap::GetCPUDescriptorHandleForHeapStart</c></description>
	/// </item>
	/// </list>
	/// <para>This structure is passed into the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12Device::CopyDescriptors</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CopyDescriptorsSimple</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateConstantBufferView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateShaderResourceView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateUnorderedAccessView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateRenderTargetView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateDepthStencilView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateSampler</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::ClearDepthStencilView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::ClearRenderTargetView</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewUint</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewFloat</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::OMSetRenderTargets</c></description>
	/// </item>
	/// </list>
	/// <para>To get the handle increment size use <c>ID3D12Device.GetDescriptorHandleIncrementSize</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_cpu_descriptor_handle typedef struct
	// D3D12_CPU_DESCRIPTOR_HANDLE { SIZE_T ptr; } D3D12_CPU_DESCRIPTOR_HANDLE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_CPU_DESCRIPTOR_HANDLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_CPU_DESCRIPTOR_HANDLE : IEquatable<D3D12_CPU_DESCRIPTOR_HANDLE>
	{
		/// <summary>The address of the descriptor.</summary>
		public SizeT ptr;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_CPU_DESCRIPTOR_HANDLE hANDLE && Equals(hANDLE);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_CPU_DESCRIPTOR_HANDLE other) => ptr.Equals(other.ptr);

		/// <inheritdoc/>
		public override int GetHashCode() => 53357169 + ptr.GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_CPU_DESCRIPTOR_HANDLE left, D3D12_CPU_DESCRIPTOR_HANDLE right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_CPU_DESCRIPTOR_HANDLE left, D3D12_CPU_DESCRIPTOR_HANDLE right) => !(left == right);

		/// <summary>Initializes a new instance of the <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> struct.</summary>
		/// <param name="h">The handle.</param>
		/// <param name="offsetScaledByIncrementSize">Size of the offset scaled by increment.</param>
		public D3D12_CPU_DESCRIPTOR_HANDLE(in D3D12_CPU_DESCRIPTOR_HANDLE h, int offsetScaledByIncrementSize = 0) => ptr = h.ptr + offsetScaledByIncrementSize;

		/// <summary>Initializes a new instance of the <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> struct.</summary>
		/// <param name="h">The handle.</param>
		/// <param name="offsetInDescriptors">The offset in descriptors.</param>
		/// <param name="descriptorIncrementSize">Size of the descriptor increment.</param>
		public D3D12_CPU_DESCRIPTOR_HANDLE(in D3D12_CPU_DESCRIPTOR_HANDLE h, int offsetInDescriptors, uint descriptorIncrementSize) => ptr = h.ptr + offsetInDescriptors * descriptorIncrementSize;

		/// <summary>Offsets the specified offset in descriptors.</summary>
		/// <param name="offsetInDescriptors">The offset in descriptors.</param>
		/// <param name="descriptorIncrementSize">Size of the descriptor increment.</param>
		/// <returns></returns>
		public D3D12_CPU_DESCRIPTOR_HANDLE Offset(int offsetInDescriptors, uint descriptorIncrementSize)
		{
			ptr += offsetInDescriptors * descriptorIncrementSize;
			return this;
		}

		/// <summary>Offsets the specified offset scaled by increment size.</summary>
		/// <param name="offsetScaledByIncrementSize">Size of the offset scaled by increment.</param>
		/// <returns></returns>
		public D3D12_CPU_DESCRIPTOR_HANDLE Offset(int offsetScaledByIncrementSize)
		{
			ptr += offsetScaledByIncrementSize;
			return this;
		}
	}

	/// <summary>Describes depth-stencil state.</summary>
	/// <remarks>
	/// <para>
	/// A <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> object contains a depth-stencil-state structure that controls how depth-stencil testing
	/// is performed by the output-merger stage.
	/// </para>
	/// <para>This table shows the default values of depth-stencil states.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>DepthEnable</description>
	/// <description>TRUE</description>
	/// </item>
	/// <item>
	/// <description>DepthWriteMask</description>
	/// <description>D3D12_DEPTH_WRITE_MASK_ALL</description>
	/// </item>
	/// <item>
	/// <description>DepthFunc</description>
	/// <description>D3D12_COMPARISON_FUNC_LESS</description>
	/// </item>
	/// <item>
	/// <description>StencilEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// <item>
	/// <description>StencilReadMask</description>
	/// <description>D3D12_DEFAULT_STENCIL_READ_MASK</description>
	/// </item>
	/// <item>
	/// <description>StencilWriteMask</description>
	/// <description>D3D12_DEFAULT_STENCIL_WRITE_MASK</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilFailOp and BackFace.StencilFailOp</description>
	/// <description>D3D12_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilDepthFailOp and BackFace.StencilDepthFailOp</description>
	/// <description>D3D12_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilPassOp and BackFace.StencilPassOp</description>
	/// <description>D3D12_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilFunc and BackFace.StencilFunc</description>
	/// <description>D3D12_COMPARISON_FUNC_ALWAYS</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>The formats that support stenciling are DXGI_FORMAT_D24_UNORM_S8_UINT and DXGI_FORMAT_D32_FLOAT_S8X24_UINT.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_desc typedef struct D3D12_DEPTH_STENCIL_DESC {
	// BOOL DepthEnable; D3D12_DEPTH_WRITE_MASK DepthWriteMask; D3D12_COMPARISON_FUNC DepthFunc; BOOL StencilEnable; UINT8 StencilReadMask;
	// UINT8 StencilWriteMask; D3D12_DEPTH_STENCILOP_DESC FrontFace; D3D12_DEPTH_STENCILOP_DESC BackFace; } D3D12_DEPTH_STENCIL_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEPTH_STENCIL_DESC")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct D3D12_DEPTH_STENCIL_DESC
	{
		/// <summary>Specifies whether to enable depth testing. Set this member to <b>TRUE</b> to enable depth testing.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthEnable;

		/// <summary>
		/// A <c>D3D12_DEPTH_WRITE_MASK</c>-typed value that identifies a portion of the depth-stencil buffer that can be modified by depth data.
		/// </summary>
		public D3D12_DEPTH_WRITE_MASK DepthWriteMask;

		/// <summary>
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies a function that compares depth data against existing depth data.
		/// </summary>
		public D3D12_COMPARISON_FUNC DepthFunc;

		/// <summary>Specifies whether to enable stencil testing. Set this member to <b>TRUE</b> to enable stencil testing.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool StencilEnable;

		/// <summary>Identify a portion of the depth-stencil buffer for reading stencil data.</summary>
		public byte StencilReadMask;

		/// <summary>Identify a portion of the depth-stencil buffer for writing stencil data.</summary>
		public byte StencilWriteMask;

		/// <summary>
		/// A <c>D3D12_DEPTH_STENCILOP_DESC</c> structure that describes how to use the results of the depth test and the stencil test for
		/// pixels whose surface normal is facing towards the camera.
		/// </summary>
		public D3D12_DEPTH_STENCILOP_DESC FrontFace;

		/// <summary>
		/// A <c>D3D12_DEPTH_STENCILOP_DESC</c> structure that describes how to use the results of the depth test and the stencil test for
		/// pixels whose surface normal is facing away from the camera.
		/// </summary>
		public D3D12_DEPTH_STENCILOP_DESC BackFace;

		/// <summary>Initializes a new instance of the <see cref="D3D12_DEPTH_STENCIL_DESC"/> struct.</summary>
		/// <param name="depthEnable">Specifies whether to enable depth testing. Set this member to <b>TRUE</b> to enable depth testing.</param>
		/// <param name="depthWriteMask">
		/// A <c>D3D12_DEPTH_WRITE_MASK</c>-typed value that identifies a portion of the depth-stencil buffer that can be modified by depth data.
		/// </param>
		/// <param name="depthFunc">
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies a function that compares depth data against existing depth data.
		/// </param>
		/// <param name="stencilEnable">Specifies whether to enable stencil testing. Set this member to <b>TRUE</b> to enable stencil testing.</param>
		/// <param name="stencilReadMask">Identify a portion of the depth-stencil buffer for reading stencil data.</param>
		/// <param name="stencilWriteMask">Identify a portion of the depth-stencil buffer for writing stencil data.</param>
		/// <param name="frontStencilFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the front stencil operation to perform when stencil testing fails.
		/// </param>
		/// <param name="frontStencilDepthFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the front stencil operation to perform when stencil testing passes and
		/// depth testing fails.
		/// </param>
		/// <param name="frontStencilPassOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the front stencil operation to perform when stencil testing and depth
		/// testing both pass.
		/// </param>
		/// <param name="frontStencilFunc">
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies the function that compares front stencil data against existing
		/// stencil data.
		/// </param>
		/// <param name="backStencilFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the back stencil operation to perform when stencil testing fails.
		/// </param>
		/// <param name="backStencilDepthFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the back stencil operation to perform when stencil testing passes and
		/// depth testing fails.
		/// </param>
		/// <param name="backStencilPassOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the back stencil operation to perform when stencil testing and depth
		/// testing both pass.
		/// </param>
		/// <param name="backStencilFunc">
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies the function that compares back stencil data against existing stencil data.
		/// </param>
		public D3D12_DEPTH_STENCIL_DESC(bool depthEnable, D3D12_DEPTH_WRITE_MASK depthWriteMask = 0, D3D12_COMPARISON_FUNC depthFunc = 0,
			bool stencilEnable = false, byte stencilReadMask = 0, byte stencilWriteMask = 0, D3D12_STENCIL_OP frontStencilFailOp = 0,
			D3D12_STENCIL_OP frontStencilDepthFailOp = 0, D3D12_STENCIL_OP frontStencilPassOp = 0, D3D12_COMPARISON_FUNC frontStencilFunc = 0,
			D3D12_STENCIL_OP backStencilFailOp = 0,  D3D12_STENCIL_OP backStencilDepthFailOp = 0, D3D12_STENCIL_OP backStencilPassOp = 0,
			D3D12_COMPARISON_FUNC backStencilFunc = 0)
		{
			DepthEnable = depthEnable;
			DepthWriteMask = depthWriteMask;
			DepthFunc = depthFunc;
			StencilEnable = stencilEnable;
			StencilReadMask = stencilReadMask;
			StencilWriteMask = stencilWriteMask;
			FrontFace = new()
			{
				StencilDepthFailOp = frontStencilDepthFailOp,
				StencilFailOp = frontStencilFailOp,
				StencilPassOp = frontStencilPassOp,
				StencilFunc = frontStencilFunc,
			};
			BackFace = new()
			{
				StencilDepthFailOp = backStencilDepthFailOp,
				StencilFailOp = backStencilFailOp,
				StencilPassOp = backStencilPassOp,
				StencilFunc = backStencilFunc,
			};
		}

		/// <summary>Gets an instance filled with D3D12_DEFAULT values.</summary>
		public static D3D12_DEPTH_STENCIL_DESC Default => new(
			true, D3D12_DEPTH_WRITE_MASK.D3D12_DEPTH_WRITE_MASK_ALL, D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_LESS, false,
			D3D12_DEFAULT_STENCIL_READ_MASK, D3D12_DEFAULT_STENCIL_WRITE_MASK, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP,
			D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP,
			D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_ALWAYS, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP,
			D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP,
			D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_ALWAYS);
	}

	/// <summary>Describes depth-stencil state.</summary>
	/// <remarks>
	/// <para>
	/// A <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> object contains a depth-stencil-state structure that controls how depth-stencil testing
	/// is performed by the output-merger stage.
	/// </para>
	/// <para>This table shows the default values of depth-stencil states.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>DepthEnable</description>
	/// <description>TRUE</description>
	/// </item>
	/// <item>
	/// <description>DepthWriteMask</description>
	/// <description>D3D12_DEPTH_WRITE_MASK_ALL</description>
	/// </item>
	/// <item>
	/// <description>DepthFunc</description>
	/// <description>D3D12_COMPARISON_LESS</description>
	/// </item>
	/// <item>
	/// <description>StencilEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// <item>
	/// <description>StencilReadMask</description>
	/// <description>D3D12_DEFAULT_STENCIL_READ_MASK</description>
	/// </item>
	/// <item>
	/// <description>StencilWriteMask</description>
	/// <description>D3D12_DEFAULT_STENCIL_WRITE_MASK</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilFunc and BackFace.StencilFunc</description>
	/// <description>D3D12_COMPARISON_ALWAYS</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilDepthFailOp and BackFace.StencilDepthFailOp</description>
	/// <description>D3D12_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilPassOp and BackFace.StencilPassOp</description>
	/// <description>D3D12_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>FrontFace.StencilFailOp and BackFace.StencilFailOp</description>
	/// <description>D3D12_STENCIL_OP_KEEP</description>
	/// </item>
	/// <item>
	/// <description>DepthBoundsTestEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>The formats that support stenciling are DXGI_FORMAT_D24_UNORM_S8_UINT and DXGI_FORMAT_D32_FLOAT_S8X24_UINT.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_desc1 typedef struct D3D12_DEPTH_STENCIL_DESC1
	// { BOOL DepthEnable; D3D12_DEPTH_WRITE_MASK DepthWriteMask; D3D12_COMPARISON_FUNC DepthFunc; BOOL StencilEnable; UINT8
	// StencilReadMask; UINT8 StencilWriteMask; D3D12_DEPTH_STENCILOP_DESC FrontFace; D3D12_DEPTH_STENCILOP_DESC BackFace; BOOL
	// DepthBoundsTestEnable; } D3D12_DEPTH_STENCIL_DESC1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEPTH_STENCIL_DESC1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DEPTH_STENCIL_DESC1
	{
		/// <summary>Specifies whether to enable depth testing. Set this member to <b>TRUE</b> to enable depth testing.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthEnable;

		/// <summary>
		/// A <c>D3D12_DEPTH_WRITE_MASK</c>-typed value that identifies a portion of the depth-stencil buffer that can be modified by depth data.
		/// </summary>
		public D3D12_DEPTH_WRITE_MASK DepthWriteMask;

		/// <summary>
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies a function that compares depth data against existing depth data.
		/// </summary>
		public D3D12_COMPARISON_FUNC DepthFunc;

		/// <summary>Specifies whether to enable stencil testing. Set this member to <b>TRUE</b> to enable stencil testing.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool StencilEnable;

		/// <summary>Identify a portion of the depth-stencil buffer for reading stencil data.</summary>
		public byte StencilReadMask;

		/// <summary>Identify a portion of the depth-stencil buffer for writing stencil data.</summary>
		public byte StencilWriteMask;

		/// <summary>
		/// A <c>D3D12_DEPTH_STENCILOP_DESC</c> structure that describes how to use the results of the depth test and the stencil test for
		/// pixels whose surface normal is facing towards the camera.
		/// </summary>
		public D3D12_DEPTH_STENCILOP_DESC FrontFace;

		/// <summary>
		/// A <c>D3D12_DEPTH_STENCILOP_DESC</c> structure that describes how to use the results of the depth test and the stencil test for
		/// pixels whose surface normal is facing away from the camera.
		/// </summary>
		public D3D12_DEPTH_STENCILOP_DESC BackFace;

		/// <summary>TRUE to enable depth-bounds testing; otherwise, FALSE. The default value is FALSE.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthBoundsTestEnable;

		/// <summary>Initializes a new instance of the <see cref="D3D12_DEPTH_STENCIL_DESC1"/> struct.</summary>
		/// <param name="desc">The version 0 description.</param>
		public D3D12_DEPTH_STENCIL_DESC1(in D3D12_DEPTH_STENCIL_DESC desc) :
			this(desc.DepthEnable, desc.DepthWriteMask, desc.DepthFunc, desc.StencilEnable, desc.StencilReadMask, desc.StencilWriteMask,
				desc.FrontFace.StencilFailOp, desc.FrontFace.StencilDepthFailOp, desc.FrontFace.StencilPassOp, desc.FrontFace.StencilFunc,
				desc.BackFace.StencilFailOp, desc.BackFace.StencilDepthFailOp, desc.BackFace.StencilPassOp, desc.BackFace.StencilFunc, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_DEPTH_STENCIL_DESC1"/> struct with default values (not all default).</summary>
		public D3D12_DEPTH_STENCIL_DESC1() : this(true, D3D12_DEPTH_WRITE_MASK.D3D12_DEPTH_WRITE_MASK_ALL, D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_LESS,
			false, D3D12_DEFAULT_STENCIL_READ_MASK, D3D12_DEFAULT_STENCIL_WRITE_MASK, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP,
			D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP, D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_ALWAYS, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP,
			D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP, D3D12_STENCIL_OP.D3D12_STENCIL_OP_KEEP, D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_ALWAYS, false)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_DEPTH_STENCIL_DESC1"/> struct.</summary>
		/// <param name="depthEnable">Specifies whether to enable depth testing. Set this member to <b>TRUE</b> to enable depth testing.</param>
		/// <param name="depthWriteMask">
		/// A <c>D3D12_DEPTH_WRITE_MASK</c>-typed value that identifies a portion of the depth-stencil buffer that can be modified by depth data.
		/// </param>
		/// <param name="depthFunc">
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies a function that compares depth data against existing depth data.
		/// </param>
		/// <param name="stencilEnable">Specifies whether to enable stencil testing. Set this member to <b>TRUE</b> to enable stencil testing.</param>
		/// <param name="stencilReadMask">Identify a portion of the depth-stencil buffer for reading stencil data.</param>
		/// <param name="stencilWriteMask">Identify a portion of the depth-stencil buffer for writing stencil data.</param>
		/// <param name="frontStencilFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the front stencil operation to perform when stencil testing fails.
		/// </param>
		/// <param name="frontStencilDepthFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the front stencil operation to perform when stencil testing passes and
		/// depth testing fails.
		/// </param>
		/// <param name="frontStencilPassOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the front stencil operation to perform when stencil testing and depth
		/// testing both pass.
		/// </param>
		/// <param name="frontStencilFunc">
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies the function that compares front stencil data against existing
		/// stencil data.
		/// </param>
		/// <param name="backStencilFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the back stencil operation to perform when stencil testing fails.
		/// </param>
		/// <param name="backStencilDepthFailOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the back stencil operation to perform when stencil testing passes and
		/// depth testing fails.
		/// </param>
		/// <param name="backStencilPassOp">
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the back stencil operation to perform when stencil testing and depth
		/// testing both pass.
		/// </param>
		/// <param name="backStencilFunc">
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies the function that compares back stencil data against existing stencil data.
		/// </param>
		/// <param name="depthBoundsTestEnable">
		/// <see langword="true"/> to enable depth-bounds testing; otherwise, <see langword="false"/>. The default value is <see langword="false"/>.
		/// </param>
		public D3D12_DEPTH_STENCIL_DESC1(bool depthEnable, D3D12_DEPTH_WRITE_MASK depthWriteMask, D3D12_COMPARISON_FUNC depthFunc, bool stencilEnable,
			byte stencilReadMask, byte stencilWriteMask, D3D12_STENCIL_OP frontStencilFailOp,
			D3D12_STENCIL_OP frontStencilDepthFailOp, D3D12_STENCIL_OP frontStencilPassOp, D3D12_COMPARISON_FUNC frontStencilFunc,
			D3D12_STENCIL_OP backStencilFailOp, D3D12_STENCIL_OP backStencilDepthFailOp, D3D12_STENCIL_OP backStencilPassOp,
			D3D12_COMPARISON_FUNC backStencilFunc, bool depthBoundsTestEnable)
		{
			DepthEnable = depthEnable;
			DepthWriteMask = depthWriteMask;
			DepthFunc = depthFunc;
			StencilEnable = stencilEnable;
			StencilReadMask = stencilReadMask;
			StencilWriteMask = stencilWriteMask;
			FrontFace = new()
			{
				StencilDepthFailOp = frontStencilDepthFailOp,
				StencilFailOp = frontStencilFailOp,
				StencilPassOp = frontStencilPassOp,
				StencilFunc = frontStencilFunc,
			};
			BackFace = new()
			{
				StencilDepthFailOp = backStencilDepthFailOp,
				StencilFailOp = backStencilFailOp,
				StencilPassOp = backStencilPassOp,
				StencilFunc = backStencilFunc,
			};
			DepthBoundsTestEnable = depthBoundsTestEnable;
		}

		/// <summary>Performs an explicit conversion from <see cref="D3D12_DEPTH_STENCIL_DESC1"/> to <see cref="D3D12_DEPTH_STENCIL_DESC"/>.</summary>
		/// <param name="desc">The description.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator D3D12_DEPTH_STENCIL_DESC(D3D12_DEPTH_STENCIL_DESC1 desc) =>
			new()
			{
				DepthEnable = desc.DepthEnable,
				DepthWriteMask = desc.DepthWriteMask,
				DepthFunc = desc.DepthFunc,
				StencilEnable = desc.StencilEnable,
				StencilReadMask = desc.StencilReadMask,
				StencilWriteMask = desc.StencilWriteMask,
				FrontFace = desc.FrontFace,
				BackFace = desc.BackFace,
			};
	}

	/// <summary>Specifies a depth and stencil value.</summary>
	/// <remarks>This structure is used in the <c>D3D12_CLEAR_VALUE</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_value typedef struct D3D12_DEPTH_STENCIL_VALUE
	// { FLOAT Depth; UINT8 Stencil; } D3D12_DEPTH_STENCIL_VALUE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEPTH_STENCIL_VALUE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DEPTH_STENCIL_VALUE
	{
		/// <summary>Specifies the depth value.</summary>
		public float Depth;

		/// <summary>Specifies the stencil value.</summary>
		public byte Stencil;
	}

	/// <summary>Describes the subresources of a texture that are accessible from a depth-stencil view.</summary>
	/// <remarks>
	/// <para>These are valid formats for a depth-stencil view:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>DXGI_FORMAT_D16_UNORM</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_D24_UNORM_S8_UINT</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_D32_FLOAT</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_D32_FLOAT_S8X24_UINT</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_UNKNOWN</description>
	/// </item>
	/// </list>
	/// <para>
	/// A depth-stencil view can't use a typeless format. If the format chosen is DXGI_FORMAT_UNKNOWN, the format of the parent resource is used.
	/// </para>
	/// <para>Pass a depth-stencil-view description into <c>ID3D12Device::CreateDepthStencilView</c> to create a depth-stencil view.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_view_desc typedef struct
	// D3D12_DEPTH_STENCIL_VIEW_DESC { DXGI_FORMAT Format; D3D12_DSV_DIMENSION ViewDimension; D3D12_DSV_FLAGS Flags; union { D3D12_TEX1D_DSV
	// Texture1D; D3D12_TEX1D_ARRAY_DSV Texture1DArray; D3D12_TEX2D_DSV Texture2D; D3D12_TEX2D_ARRAY_DSV Texture2DArray; D3D12_TEX2DMS_DSV
	// Texture2DMS; D3D12_TEX2DMS_ARRAY_DSV Texture2DMSArray; }; } D3D12_DEPTH_STENCIL_VIEW_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEPTH_STENCIL_VIEW_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_DEPTH_STENCIL_VIEW_DESC
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value that specifies the viewing format. For allowable formats, see Remarks.</summary>
		[FieldOffset(0)]
		public DXGI_FORMAT Format;

		/// <summary>
		/// A <c>D3D12_DSV_DIMENSION</c>-typed value that specifies how the depth-stencil resource will be accessed. This member also
		/// determines which _DSV to use in the following union.
		/// </summary>
		[FieldOffset(4)]
		public D3D12_DSV_DIMENSION ViewDimension;

		/// <summary>
		/// A combination of <c>D3D12_DSV_FLAGS</c> enumeration constants that are combined by using a bitwise OR operation. The resulting
		/// value specifies whether the texture is read only. Pass 0 to specify that it isn't read only; otherwise, pass one or more of the
		/// members of the <b>D3D12_DSV_FLAGS</b> enumerated type.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_DSV_FLAGS Flags;

		/// <summary>A <c>D3D12_TEX1D_DSV</c> structure that specifies a 1D texture subresource.</summary>
		[FieldOffset(12)]
		public D3D12_TEX1D_DSV Texture1D;

		/// <summary>A <c>D3D12_TEX1D_ARRAY_DSV</c> structure that specifies an array of 1D texture subresources.</summary>
		[FieldOffset(12)]
		public D3D12_TEX1D_ARRAY_DSV Texture1DArray;

		/// <summary>A <c>D3D12_TEX2D_DSV</c> structure that specifies a 2D texture subresource.</summary>
		[FieldOffset(12)]
		public D3D12_TEX2D_DSV Texture2D;

		/// <summary>A <c>D3D12_TEX2D_ARRAY_DSV</c> structure that specifies an array of 2D texture subresources.</summary>
		[FieldOffset(12)]
		public D3D12_TEX2D_ARRAY_DSV Texture2DArray;

		/// <summary>A <c>D3D12_TEX2DMS_DSV</c> structure that specifies a multisampled 2D texture.</summary>
		[FieldOffset(12)]
		public D3D12_TEX2DMS_DSV Texture2DMS;

		/// <summary>A <c>D3D12_TEX2DMS_ARRAY_DSV</c> structure that specifies an array of multisampled 2D textures.</summary>
		[FieldOffset(12)]
		public D3D12_TEX2DMS_ARRAY_DSV Texture2DMSArray;
	}

	/// <summary>Describes stencil operations that can be performed based on the results of stencil test.</summary>
	/// <remarks>
	/// <para>
	/// All stencil operations are specified as a <c>D3D12_STENCIL_OP</c>-typed value. Each stencil operation can be set differently based
	/// on the outcome of the stencil test, which is referred to as <b>StencilFunc</b>, in the stencil test portion of depth-stencil testing.
	/// </para>
	/// <para>Members of <c>D3D12_DEPTH_STENCIL_DESC</c> have this structure for their data type.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencilop_desc typedef struct
	// D3D12_DEPTH_STENCILOP_DESC { D3D12_STENCIL_OP StencilFailOp; D3D12_STENCIL_OP StencilDepthFailOp; D3D12_STENCIL_OP StencilPassOp;
	// D3D12_COMPARISON_FUNC StencilFunc; } D3D12_DEPTH_STENCILOP_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEPTH_STENCILOP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DEPTH_STENCILOP_DESC
	{
		/// <summary>A <c>D3D12_STENCIL_OP</c>-typed value that identifies the stencil operation to perform when stencil testing fails.</summary>
		public D3D12_STENCIL_OP StencilFailOp;

		/// <summary>
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the stencil operation to perform when stencil testing passes and depth
		/// testing fails.
		/// </summary>
		public D3D12_STENCIL_OP StencilDepthFailOp;

		/// <summary>
		/// A <c>D3D12_STENCIL_OP</c>-typed value that identifies the stencil operation to perform when stencil testing and depth testing
		/// both pass.
		/// </summary>
		public D3D12_STENCIL_OP StencilPassOp;

		/// <summary>
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that identifies the function that compares stencil data against existing stencil data.
		/// </summary>
		public D3D12_COMPARISON_FUNC StencilFunc;
	}

	/// <summary>Describes the descriptor heap.</summary>
	/// <remarks>
	/// <para>This structure is used by the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12DescriptorHeap::GetDesc</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateDescriptorHeap</c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_descriptor_heap_desc typedef struct
	// D3D12_DESCRIPTOR_HEAP_DESC { D3D12_DESCRIPTOR_HEAP_TYPE Type; UINT NumDescriptors; D3D12_DESCRIPTOR_HEAP_FLAGS Flags; UINT NodeMask;
	// } D3D12_DESCRIPTOR_HEAP_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DESCRIPTOR_HEAP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DESCRIPTOR_HEAP_DESC
	{
		/// <summary>A <c>D3D12_DESCRIPTOR_HEAP_TYPE</c>-typed value that specifies the types of descriptors in the heap.</summary>
		public D3D12_DESCRIPTOR_HEAP_TYPE Type;

		/// <summary>The number of descriptors in the heap.</summary>
		public uint NumDescriptors;

		/// <summary>
		/// A combination of <c>D3D12_DESCRIPTOR_HEAP_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The
		/// resulting value specifies options for the heap.
		/// </summary>
		public D3D12_DESCRIPTOR_HEAP_FLAGS Flags;

		/// <summary>
		/// For single-adapter operation, set this to zero. If there are multiple adapter nodes, set a bit to identify the node (one of the
		/// device's physical adapters) to which the descriptor heap applies. Each bit in the mask corresponds to a single node. Only one
		/// bit must be set. See <c>Multi-adapter systems</c>.
		/// </summary>
		public uint NodeMask;
	}

	/// <summary>Describes a descriptor range.</summary>
	/// <remarks>This structure is a member of the <c>D3D12_ROOT_DESCRIPTOR_TABLE</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_descriptor_range typedef struct D3D12_DESCRIPTOR_RANGE {
	// D3D12_DESCRIPTOR_RANGE_TYPE RangeType; UINT NumDescriptors; UINT BaseShaderRegister; UINT RegisterSpace; UINT
	// OffsetInDescriptorsFromTableStart; } D3D12_DESCRIPTOR_RANGE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DESCRIPTOR_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DESCRIPTOR_RANGE(D3D12_DESCRIPTOR_RANGE_TYPE rangeType, uint numDescriptors, uint baseShaderRegister, uint registerSpace = 0,
		uint offsetInDescriptorsFromTableStart = D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND)
	{
		/// <summary>A <c>D3D12_DESCRIPTOR_RANGE_TYPE</c>-typed value that specifies the type of descriptor range.</summary>
		public D3D12_DESCRIPTOR_RANGE_TYPE RangeType = rangeType;

		/// <summary>
		/// The number of descriptors in the range. Use -1 or UINT_MAX to specify an unbounded size. If a given descriptor range is
		/// unbounded, then it must either be the last range in the table definition, or else the following range in the table definition
		/// must have a value for OffsetInDescriptorsFromTableStart that is not <c>D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND</c>.
		/// </summary>
		public uint NumDescriptors = numDescriptors;

		/// <summary>
		/// The base shader register in the range. For example, for shader-resource views (SRVs), 3 maps to ": register(t3);" in HLSL.
		/// </summary>
		public uint BaseShaderRegister = baseShaderRegister;

		/// <summary>
		/// The register space. Can typically be 0, but allows multiple descriptor arrays of unknown size to not appear to overlap. For
		/// example, for SRVs, by extending the example in the <b>BaseShaderRegister</b> member description, 5 maps to ":
		/// register(t3,space5);" in HLSL.
		/// </summary>
		public uint RegisterSpace = registerSpace;

		/// <summary>
		/// The offset in descriptors, from the start of the descriptor table which was set as the root argument value for this parameter
		/// slot. This value can be <b>D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND</b>, which indicates this range should immediately follow the
		/// preceding range.
		/// </summary>
		public uint OffsetInDescriptorsFromTableStart = offsetInDescriptorsFromTableStart;
	}

	/// <summary>Describes a descriptor range, with flags to determine their volatility.</summary>
	/// <remarks>
	/// <para>This structure is a member of the <c>D3D12_ROOT_DESCRIPTOR_TABLE1</c> structure.</para>
	/// <para>Refer to the helper structure <c>CD3DX12_DESCRIPTOR_RANGE1</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_descriptor_range1 typedef struct D3D12_DESCRIPTOR_RANGE1 {
	// D3D12_DESCRIPTOR_RANGE_TYPE RangeType; UINT NumDescriptors; UINT BaseShaderRegister; UINT RegisterSpace; D3D12_DESCRIPTOR_RANGE_FLAGS
	// Flags; UINT OffsetInDescriptorsFromTableStart; } D3D12_DESCRIPTOR_RANGE1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DESCRIPTOR_RANGE1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DESCRIPTOR_RANGE1(D3D12_DESCRIPTOR_RANGE_TYPE rangeType, uint numDescriptors, uint baseShaderRegister, uint registerSpace = 0,
		D3D12_DESCRIPTOR_RANGE_FLAGS flags = D3D12_DESCRIPTOR_RANGE_FLAGS.D3D12_DESCRIPTOR_RANGE_FLAG_NONE,
		uint offsetInDescriptorsFromTableStart = D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND)
	{
		/// <summary>A <c>D3D12_DESCRIPTOR_RANGE_TYPE</c>-typed value that specifies the type of descriptor range.</summary>
		public D3D12_DESCRIPTOR_RANGE_TYPE RangeType = rangeType;

		/// <summary>
		/// The number of descriptors in the range. Use -1 or UINT_MAX to specify unbounded size. Only the last entry in a table can have
		/// unbounded size.
		/// </summary>
		public uint NumDescriptors = numDescriptors;

		/// <summary>
		/// The base shader register in the range. For example, for shader-resource views (SRVs), 3 maps to ": register(t3);" in HLSL.
		/// </summary>
		public uint BaseShaderRegister = baseShaderRegister;

		/// <summary>
		/// The register space. Can typically be 0, but allows multiple descriptor arrays of unknown size to not appear to overlap. For
		/// example, for SRVs, by extending the example in the <b>BaseShaderRegister</b> member description, 5 maps to ":
		/// register(t3,space5);" in HLSL.
		/// </summary>
		public uint RegisterSpace = registerSpace;

		/// <summary>Specifies the <c>D3D12_DESCRIPTOR_RANGE_FLAGS</c> that determine descriptor and data volatility.</summary>
		public D3D12_DESCRIPTOR_RANGE_FLAGS Flags = flags;

		/// <summary>
		/// The offset in descriptors from the start of the root signature. This value can be <b>D3D12_DESCRIPTOR_RANGE_OFFSET_APPEND</b>,
		/// which indicates this range should immediately follow the preceding range.
		/// </summary>
		public uint OffsetInDescriptorsFromTableStart = offsetInDescriptorsFromTableStart;

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.D3D12.D3D12_DESCRIPTOR_RANGE1"/> to <see cref="Vanara.PInvoke.D3D12.D3D12_DESCRIPTOR_RANGE"/>.</summary>
		/// <param name="r">The D3D12_DESCRIPTOR_RANGE1.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D3D12_DESCRIPTOR_RANGE(D3D12_DESCRIPTOR_RANGE1 r) => new(r.RangeType, r.NumDescriptors, r.BaseShaderRegister, r.RegisterSpace, r.OffsetInDescriptorsFromTableStart);
	}

	/// <summary>
	/// <para>Note</para>
	/// <para>
	/// As of Windows 10, version 1903, <b>D3D12_DEVICE_REMOVED_EXTENDED_DATA</b> is deprecated, and it may not be available in future
	/// versions of Windows. Use <c><b>D3D12_DEVICE_REMOVED_EXTENDED_DATA1</b></c>, instead.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_device_removed_extended_data typedef struct
	// D3D12_DEVICE_REMOVED_EXTENDED_DATA { D3D12_DRED_FLAGS Flags; D3D12_AUTO_BREADCRUMB_NODE *pHeadAutoBreadcrumbNode; } D3D12_DEVICE_REMOVED_EXTENDED_DATA;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEVICE_REMOVED_EXTENDED_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_DEVICE_REMOVED_EXTENDED_DATA
	{
		/// <summary>An input parameter of type <c>D3D12_DRED_FLAGS</c>, specifying control flags for the Direct3D runtime.</summary>
		public D3D12_DRED_FLAGS Flags;

		/// <summary>
		/// An output parameter of type pointer to <c>D3D12_AUTO_BREADCRUMB_NODE</c> representing the returned auto-breadcrumb object(s).
		/// This is a pointer to the head of a linked list of auto-breadcrumb objects. All of the nodes in the linked list represent
		/// potentially incomplete command list execution on the GPU at the time of the device-removal event.
		/// </summary>
		public ManagedStructPointer<D3D12_AUTO_BREADCRUMB_NODE> pHeadAutoBreadcrumbNode;
	}

	/// <summary>
	/// <para>
	/// Represents Device Removed Extended Data (DRED) version 1.1 device removal data, so that debuggers and debugger extensions can access
	/// DRED data. Also see <c>D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA</c>.
	/// </para>
	/// <para>This structure is not used by any interface methods, and it provides no runtime API access.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_device_removed_extended_data1 typedef struct
	// D3D12_DEVICE_REMOVED_EXTENDED_DATA1 { HRESULT DeviceRemovedReason; D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT AutoBreadcrumbsOutput;
	// D3D12_DRED_PAGE_FAULT_OUTPUT PageFaultOutput; } D3D12_DEVICE_REMOVED_EXTENDED_DATA1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEVICE_REMOVED_EXTENDED_DATA1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DEVICE_REMOVED_EXTENDED_DATA1
	{
		/// <summary>
		/// An <c>HRESULT</c> containing the reason the device was removed (matches the return value of <c>GetDeviceRemovedReason</c>). Also
		/// see <c>COM Error Codes (UI, Audio, DirectX, Codec)</c>.
		/// </summary>
		public HRESULT DeviceRemovedReason;

		/// <summary>A <c>D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT</c> value that contains the auto-breadcrumb state prior to device removal.</summary>
		public D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT AutoBreadcrumbsOutput;

		/// <summary>
		/// A <c>D3D12_DRED_PAGE_FAULT_OUTPUT</c> value that contains page fault data if device removal was the result of a GPU page fault.
		/// </summary>
		public D3D12_DRED_PAGE_FAULT_OUTPUT PageFaultOutput;
	}

	/// <summary>
	/// <para><c>DeviceRemovedReason</c></para>
	/// <para><c>AutoBreadcrumbsOutput</c></para>
	/// <para><c>PageFaultOutput</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_device_removed_extended_data2 typedef struct
	// D3D12_DEVICE_REMOVED_EXTENDED_DATA2 { HRESULT DeviceRemovedReason; D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 AutoBreadcrumbsOutput;
	// D3D12_DRED_PAGE_FAULT_OUTPUT1 PageFaultOutput; } D3D12_DEVICE_REMOVED_EXTENDED_DATA2;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEVICE_REMOVED_EXTENDED_DATA2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DEVICE_REMOVED_EXTENDED_DATA2
	{
		/// <summary/>
		public HRESULT DeviceRemovedReason;

		/// <summary/>
		public D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 AutoBreadcrumbsOutput;

		/// <summary/>
		public D3D12_DRED_PAGE_FAULT_OUTPUT1 PageFaultOutput;
	}

	/// <summary>
	/// <para><c>DeviceRemovedReason</c></para>
	/// <para><c>AutoBreadcrumbsOutput</c></para>
	/// <para><c>PageFaultOutput</c></para>
	/// <para><c>DeviceState</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_device_removed_extended_data3 typedef struct
	// D3D12_DEVICE_REMOVED_EXTENDED_DATA3 { HRESULT DeviceRemovedReason; D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 AutoBreadcrumbsOutput;
	// D3D12_DRED_PAGE_FAULT_OUTPUT2 PageFaultOutput; D3D12_DRED_DEVICE_STATE DeviceState; } D3D12_DEVICE_REMOVED_EXTENDED_DATA3;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DEVICE_REMOVED_EXTENDED_DATA3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DEVICE_REMOVED_EXTENDED_DATA3
	{
		/// <summary/>
		public HRESULT DeviceRemovedReason;

		/// <summary/>
		public D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 AutoBreadcrumbsOutput;

		/// <summary/>
		public D3D12_DRED_PAGE_FAULT_OUTPUT2 PageFaultOutput;

		/// <summary/>
		public D3D12_DRED_DEVICE_STATE DeviceState;
	}

	/// <summary>Describes details for the discard-resource operation.</summary>
	/// <remarks>
	/// <para>This structure is used by the <c>ID3D12GraphicsCommandList::DiscardResource</c> method.</para>
	/// <para>
	/// If rectangles are supplied in this structure, the resource must have 2D subresources with all specified subresources the same dimension.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_discard_region typedef struct D3D12_DISCARD_REGION { UINT
	// NumRects; const D3D12_RECT *pRects; UINT FirstSubresource; UINT NumSubresources; } D3D12_DISCARD_REGION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DISCARD_REGION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DISCARD_REGION
	{
		/// <summary>The number of rectangles in the array that the <b>pRects</b> member specifies.</summary>
		public uint NumRects;

		/// <summary>
		/// An array of <b>D3D12_RECT</b> structures for the rectangles in the resource to discard. If <b>NULL</b>, <c>DiscardResource</c>
		/// discards the entire resource.
		/// </summary>
		public StructPointer<D3D12_RECT> pRects;

		/// <summary>Index of the first subresource in the resource to discard.</summary>
		public uint FirstSubresource;

		/// <summary>The number of subresources in the resource to discard.</summary>
		public uint NumSubresources;
	}

	/// <summary>Describes dispatch parameters, for use by the compute shader.</summary>
	/// <remarks>
	/// <para>The members of this structure serve the same purpose as the parameters of <c>Dispatch</c>.</para>
	/// <para>
	/// A compiled compute shader defines the set of instructions to execute per thread and the number of threads to run per group. The
	/// thread-group parameters indicate how many thread groups to execute. Each thread group contains the same number of threads, as
	/// defined by the compiled compute shader. The thread groups are organized in a three-dimensional grid. The total number of thread
	/// groups that the compiled compute shader executes is determined by the following calculation:
	/// </para>
	/// <para><c>ThreadGroupCountX * ThreadGroupCountY * ThreadGroupCountZ</c></para>
	/// <para>In particular, if any of the values in the thread-group parameters are 0, nothing will happen.</para>
	/// <para>The maximum size of any dimension is 65535.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dispatch_arguments typedef struct D3D12_DISPATCH_ARGUMENTS {
	// UINT ThreadGroupCountX; UINT ThreadGroupCountY; UINT ThreadGroupCountZ; } D3D12_DISPATCH_ARGUMENTS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DISPATCH_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DISPATCH_ARGUMENTS
	{
		/// <summary>The size, in thread groups, of the x-dimension of the thread-group grid.</summary>
		public uint ThreadGroupCountX;

		/// <summary>The size, in thread groups, of the y-dimension of the thread-group grid.</summary>
		public uint ThreadGroupCountY;

		/// <summary>The size, in thread groups, of the z-dimension of the thread-group grid.</summary>
		public uint ThreadGroupCountZ;
	}

	/// <summary>
	/// <para><c>ThreadGroupCountX</c></para>
	/// <para><c>ThreadGroupCountY</c></para>
	/// <para><c>ThreadGroupCountZ</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dispatch_mesh_arguments typedef struct
	// D3D12_DISPATCH_MESH_ARGUMENTS { UINT ThreadGroupCountX; UINT ThreadGroupCountY; UINT ThreadGroupCountZ; } D3D12_DISPATCH_MESH_ARGUMENTS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DISPATCH_MESH_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DISPATCH_MESH_ARGUMENTS
	{
		/// <summary/>
		public uint ThreadGroupCountX;

		/// <summary/>
		public uint ThreadGroupCountY;

		/// <summary/>
		public uint ThreadGroupCountZ;
	}

	/// <summary>Describes the properties of a ray dispatch operation initiated with a call to <c>ID3D12GraphicsCommandList4::DispatchRays</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dispatch_rays_desc typedef struct D3D12_DISPATCH_RAYS_DESC {
	// D3D12_GPU_VIRTUAL_ADDRESS_RANGE RayGenerationShaderRecord; D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE MissShaderTable;
	// D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE HitGroupTable; D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE CallableShaderTable; UINT Width;
	// UINT Height; UINT Depth; } D3D12_DISPATCH_RAYS_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DISPATCH_RAYS_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DISPATCH_RAYS_DESC
	{
		/// <summary>
		/// <para>The shader record for the ray generation shader to use.</para>
		/// <para>The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>.</para>
		/// <para>
		/// The address must be aligned to 64 bytes, defined as <c>D3D12_RAYTRACING_SHADER_TABLE_BYTE_ALIGNMENT</c>, and in the range
		/// [0...4096] bytes.
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS_RANGE RayGenerationShaderRecord;

		/// <summary>
		/// <para>The shader table for miss shaders.</para>
		/// <para>
		/// The stride is record stride, and must be aligned to 32 bytes, defined as <c>D3D12_RAYTRACING_SHADER_RECORD_BYTE_ALIGNMENT</c>,
		/// and in the range [0...4096] bytes. 0 is allowed.
		/// </para>
		/// <para>The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>.</para>
		/// <para>The address must be aligned to 64 bytes, defined as <c>D3D12_RAYTRACING_SHADER_TABLE_BYTE_ALIGNMENT</c>.</para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE MissShaderTable;

		/// <summary>
		/// <para>The shader table for hit groups.</para>
		/// <para>
		/// The stride is record stride, and must be aligned to 32 bytes, defined as <c>D3D12_RAYTRACING_SHADER_RECORD_BYTE_ALIGNMENT</c>,
		/// and in the range [0...4096] bytes. 0 is allowed.
		/// </para>
		/// <para>The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>.</para>
		/// <para>The address must be aligned to 64 bytes, defined as <c>D3D12_RAYTRACING_SHADER_TABLE_BYTE_ALIGNMENT</c>.</para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE HitGroupTable;

		/// <summary>
		/// <para>The shader table for callable shaders.</para>
		/// <para>
		/// The stride is record stride, and must be aligned to 32 bytes, defined as <c>D3D12_RAYTRACING_SHADER_RECORD_BYTE_ALIGNMENT</c>. 0
		/// is allowed.
		/// </para>
		/// <para>The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>.</para>
		/// <para>The address must be aligned to 64 bytes, defined as <c>D3D12_RAYTRACING_SHADER_TABLE_BYTE_ALIGNMENT</c>.</para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE CallableShaderTable;

		/// <summary>The width of the generation shader thread grid.</summary>
		public uint Width;

		/// <summary>The height of the generation shader thread grid.</summary>
		public uint Height;

		/// <summary>The depth of the generation shader thread grid.</summary>
		public uint Depth;
	}

	/// <summary>Describes parameters for drawing instances.</summary>
	/// <remarks>The members of this structure serve the same purpose as the parameters of <c>DrawInstanced</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_draw_arguments typedef struct D3D12_DRAW_ARGUMENTS { UINT
	// VertexCountPerInstance; UINT InstanceCount; UINT StartVertexLocation; UINT StartInstanceLocation; } D3D12_DRAW_ARGUMENTS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRAW_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRAW_ARGUMENTS
	{
		/// <summary>Specifies the number of vertices to draw, per instance.</summary>
		public uint VertexCountPerInstance;

		/// <summary>Specifies the number of instances.</summary>
		public uint InstanceCount;

		/// <summary>Specifies an index to the first vertex to start drawing from.</summary>
		public uint StartVertexLocation;

		/// <summary>Specifies an index to the first instance to start drawing from.</summary>
		public uint StartInstanceLocation;
	}

	/// <summary>Describes parameters for drawing indexed instances.</summary>
	/// <remarks>The members of this structure serve the same purpose as the parameters of <c>DrawIndexedInstanced</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_draw_indexed_arguments typedef struct
	// D3D12_DRAW_INDEXED_ARGUMENTS { UINT IndexCountPerInstance; UINT InstanceCount; UINT StartIndexLocation; INT BaseVertexLocation; UINT
	// StartInstanceLocation; } D3D12_DRAW_INDEXED_ARGUMENTS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRAW_INDEXED_ARGUMENTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRAW_INDEXED_ARGUMENTS
	{
		/// <summary>The number of indices read from the index buffer for each instance.</summary>
		public uint IndexCountPerInstance;

		/// <summary>The number of instances to draw.</summary>
		public uint InstanceCount;

		/// <summary>The location of the first index read by the GPU from the index buffer.</summary>
		public uint StartIndexLocation;

		/// <summary>A value added to each index before reading a vertex from the vertex buffer.</summary>
		public int BaseVertexLocation;

		/// <summary>A value added to each index before reading per-instance data from a vertex buffer.</summary>
		public uint StartInstanceLocation;
	}

	/// <summary>
	/// <para>
	/// Describes, as a node in a linked list, data about an allocation tracked by Device Removed Extended Data (DRED). This data includes
	/// the GPU VA allocation ranges, and an associated runtime object debug name and type. Each <b>D3D12_DRED_ALLOCATION_NODE</b> object is
	/// singly linked to the next via its <c>pNext</c> member; except for the last node in the list, which has its <c>pNext</c> set to
	/// <c>nullptr</c>. A linked list structure is necessary because a runtime object can share allocation ranges with other objects.
	/// </para>
	/// <para>
	/// If device removal is caused by a GPU page fault—and DRED page fault reporting is enabled—then DRED builds a list of
	/// D3D12_DRED_ALLOCATION_NODE structs that includes all matching allocation nodes for active and recently-freed runtime objects.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_allocation_node typedef struct
	// D3D12_DRED_ALLOCATION_NODE { const char *ObjectNameA; const wchar_t *ObjectNameW; D3D12_DRED_ALLOCATION_TYPE AllocationType; const
	// D3D12_DRED_ALLOCATION_NODE *pNext; struct D3D12_DRED_ALLOCATION_NODE; } D3D12_DRED_ALLOCATION_NODE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_ALLOCATION_NODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_ALLOCATION_NODE
	{
		/// <summary>A pointer to the ANSI debug name of the allocated runtime object.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string ObjectNameA;

		/// <summary>A pointer to the wide debug name of the allocated runtime object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectNameW;

		/// <summary>A <c>D3D12_DRED_ALLOCATION_TYPE</c> value representing the runtime object's allocation type.</summary>
		public D3D12_DRED_ALLOCATION_TYPE AllocationType;

		/// <summary>
		/// A pointer to a constant <b>D3D12_DRED_ALLOCATION_NODE</b> representing the next allocation node in the list, or <c>nullptr</c>
		/// if this is the last node.
		/// </summary>
		public IntPtr pNext;
	}

	/// <summary>
	/// <para><c>ObjectNameA</c></para>
	/// <para><c>ObjectNameW</c></para>
	/// <para><c>AllocationType</c></para>
	/// <para><c>pNext</c></para>
	/// <para><c>D3D12_DRED_ALLOCATION_NODE1</c></para>
	/// <para><c>pObject</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_allocation_node1 typedef struct
	// D3D12_DRED_ALLOCATION_NODE1 { const char *ObjectNameA; const wchar_t *ObjectNameW; D3D12_DRED_ALLOCATION_TYPE AllocationType; const
	// D3D12_DRED_ALLOCATION_NODE1 *pNext; struct D3D12_DRED_ALLOCATION_NODE1; const IUnknown *pObject; } D3D12_DRED_ALLOCATION_NODE1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_ALLOCATION_NODE1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_ALLOCATION_NODE1
	{
		/// <summary>A pointer to the ANSI debug name of the allocated runtime object.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string ObjectNameA;

		/// <summary>A pointer to the wide debug name of the allocated runtime object.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ObjectNameW;

		/// <summary>A <c>D3D12_DRED_ALLOCATION_TYPE</c> value representing the runtime object's allocation type.</summary>
		public D3D12_DRED_ALLOCATION_TYPE AllocationType;

		/// <summary>
		/// A pointer to a constant <b>D3D12_DRED_ALLOCATION_NODE</b> representing the next allocation node in the list, or <c>nullptr</c>
		/// if this is the last node.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE> pNext;

		/// <summary/>
		public IntPtr pObject;
	}

	/// <summary>
	/// Contains a pointer to the head of a linked list of <c>D3D12_AUTO_BREADCRUMB_NODE</c> objects. The list represents the
	/// auto-breadcrumb state prior to device removal.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_auto_breadcrumbs_output typedef struct
	// D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT { const D3D12_AUTO_BREADCRUMB_NODE *pHeadAutoBreadcrumbNode; } D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT
	{
		/// <summary>
		/// A pointer to a constant <c>D3D12_AUTO_BREADCRUMB_NODE</c> object representing the head of a linked list of auto-breadcrumb
		/// nodes, or <c>nullptr</c> if the list is empty.
		/// </summary>
		public IntPtr pHeadAutoBreadcrumbNode;
	}

	/// <summary>
	/// Contains a pointer to the head of a linked list of D3D12_AUTO_BREADCRUMB_NODE1 objects. The list represents the auto-breadcrumb
	/// state prior to device removal.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_auto_breadcrumbs_output1 typedef struct
	// D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1 { const D3D12_AUTO_BREADCRUMB_NODE1 *pHeadAutoBreadcrumbNode; } D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_AUTO_BREADCRUMBS_OUTPUT1
	{
		/// <summary>Points to the head of a linked list of D3D12_AUTO_BREADCRUMB_NODE1 structures.</summary>
		public IntPtr pHeadAutoBreadcrumbNode;
	}

	/// <summary>Provides access to the context string associated with a command list op breadcrumb.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_breadcrumb_context typedef struct
	// D3D12_DRED_BREADCRUMB_CONTEXT { UINT BreadcrumbIndex; const wchar_t *pContextString; } D3D12_DRED_BREADCRUMB_CONTEXT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_BREADCRUMB_CONTEXT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_BREADCRUMB_CONTEXT
	{
		/// <summary>
		/// Index of the command list operation in the command history of the associated command list. The command history is the array
		/// pointed to by the pCommandHistory member of the D3D12_AUTO_BREADCRUMB_NODE1 structure.
		/// </summary>
		public uint BreadcrumbIndex;

		/// <summary>Pointer to the null-terminated wide-character context string.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pContextString;
	}

	/// <summary>
	/// Describes allocation data related to a GPU page fault on a given virtual address (VA). Contains the VA of a GPU page fault, together
	/// with a list of matching allocation nodes for active objects, and a list of allocation nodes for recently deleted objects.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_page_fault_output typedef struct
	// D3D12_DRED_PAGE_FAULT_OUTPUT { D3D12_GPU_VIRTUAL_ADDRESS PageFaultVA; const D3D12_DRED_ALLOCATION_NODE *pHeadExistingAllocationNode;
	// const D3D12_DRED_ALLOCATION_NODE *pHeadRecentFreedAllocationNode; } D3D12_DRED_PAGE_FAULT_OUTPUT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_PAGE_FAULT_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_PAGE_FAULT_OUTPUT
	{
		/// <summary>
		/// A <c>D3D12_GPU_VIRTUAL_ADDRESS</c> containing the GPU virtual address (VA) of the faulting operation if device removal was due
		/// to a GPU page fault.
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS PageFaultVA;

		/// <summary>
		/// A pointer to a constant <c>D3D12_DRED_ALLOCATION_NODE</c> object representing the head of a linked list of allocation nodes for
		/// active allocated runtime objects with virtual address (VA) ranges that match the faulting VA ( <c>PageFaultVA</c>). Has a value
		/// of <c>nullptr</c> if the list is empty.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE> pHeadExistingAllocationNode;

		/// <summary>
		/// A pointer to a constant <c>D3D12_DRED_ALLOCATION_NODE</c> object representing the head of a linked list of allocation nodes for
		/// recently freed runtime objects with virtual address (VA) ranges that match the faulting VA ( <c>PageFaultVA</c>). Has a value of
		/// <c>nullptr</c> if the list is empty.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE> pHeadRecentFreedAllocationNode;
	}

	/// <summary>
	/// Describes allocation data related to a GPU page fault on a given virtual address (VA). Contains the VA of a GPU page fault, together
	/// with a list of matching allocation nodes for active objects, and a list of allocation nodes for recently deleted objects.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_page_fault_output1 typedef struct
	// D3D12_DRED_PAGE_FAULT_OUTPUT1 { D3D12_GPU_VIRTUAL_ADDRESS PageFaultVA; const D3D12_DRED_ALLOCATION_NODE1
	// *pHeadExistingAllocationNode; const D3D12_DRED_ALLOCATION_NODE1 *pHeadRecentFreedAllocationNode; } D3D12_DRED_PAGE_FAULT_OUTPUT1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_PAGE_FAULT_OUTPUT1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_PAGE_FAULT_OUTPUT1
	{
		/// <summary>
		/// A <c>D3D12_GPU_VIRTUAL_ADDRESS</c> containing the GPU virtual address (VA) of the faulting operation if device removal was due
		/// to a GPU page fault.
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS PageFaultVA;

		/// <summary>
		/// A pointer to a constant <c>D3D12_DRED_ALLOCATION_NODE1</c> object representing the head of a linked list of allocation nodes for
		/// active allocated runtime objects with virtual address (VA) ranges that match the faulting VA ( <c>PageFaultVA</c>). Has a value
		/// of <c>nullptr</c> if the list is empty.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE1> pHeadExistingAllocationNode;

		/// <summary>
		/// A pointer to a constant <c>D3D12_DRED_ALLOCATION_NODE1</c> object representing the head of a linked list of allocation nodes for
		/// recently freed runtime objects with virtual address (VA) ranges that match the faulting VA ( <c>PageFaultVA</c>). Has a value of
		/// <c>nullptr</c> if the list is empty.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE1> pHeadRecentFreedAllocationNode;
	}

	/// <summary>
	/// <para><c>PageFaultVA</c></para>
	/// <para><c>pHeadExistingAllocationNode</c></para>
	/// <para><c>pHeadRecentFreedAllocationNode</c></para>
	/// <para><c>PageFaultFlags</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dred_page_fault_output2 typedef struct
	// D3D12_DRED_PAGE_FAULT_OUTPUT2 { D3D12_GPU_VIRTUAL_ADDRESS PageFaultVA; const D3D12_DRED_ALLOCATION_NODE1
	// *pHeadExistingAllocationNode; const D3D12_DRED_ALLOCATION_NODE1 *pHeadRecentFreedAllocationNode; D3D12_DRED_PAGE_FAULT_FLAGS
	// PageFaultFlags; } D3D12_DRED_PAGE_FAULT_OUTPUT2;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DRED_PAGE_FAULT_OUTPUT2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DRED_PAGE_FAULT_OUTPUT2
	{
		/// <summary>
		/// A <c>D3D12_GPU_VIRTUAL_ADDRESS</c> containing the GPU virtual address (VA) of the faulting operation if device removal was due
		/// to a GPU page fault.
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS PageFaultVA;

		/// <summary>
		/// A pointer to a constant <c>D3D12_DRED_ALLOCATION_NODE1</c> object representing the head of a linked list of allocation nodes for
		/// active allocated runtime objects with virtual address (VA) ranges that match the faulting VA ( <c>PageFaultVA</c>). Has a value
		/// of <c>nullptr</c> if the list is empty.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE1> pHeadExistingAllocationNode;

		/// <summary>
		/// A pointer to a constant <c>D3D12_DRED_ALLOCATION_NODE1</c> object representing the head of a linked list of allocation nodes for
		/// recently freed runtime objects with virtual address (VA) ranges that match the faulting VA ( <c>PageFaultVA</c>). Has a value of
		/// <c>nullptr</c> if the list is empty.
		/// </summary>
		public ManagedStructPointer<D3D12_DRED_ALLOCATION_NODE1> pHeadRecentFreedAllocationNode;

		/// <summary/>
		public D3D12_DRED_PAGE_FAULT_FLAGS PageFaultFlags;
	}

	/// <summary>Describes a DXIL library state subobject that can be included in a state object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dxil_library_desc typedef struct D3D12_DXIL_LIBRARY_DESC {
	// D3D12_SHADER_BYTECODE DXILLibrary; UINT NumExports; const D3D12_EXPORT_DESC *pExports; } D3D12_DXIL_LIBRARY_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DXIL_LIBRARY_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DXIL_LIBRARY_DESC
	{
		/// <summary>
		/// The library to include in the state object. Must have been compiled with library target 6.3 or higher. It is fine to specify the
		/// same library multiple times either in the same state object / collection or across multiple, as long as the names exported each
		/// time don’t conflict in a given state object.
		/// </summary>
		public D3D12_SHADER_BYTECODE DXILLibrary;

		/// <summary>
		/// <para>The size of <i>pExports</i> array. If 0, everything gets exported from the library.</para>
		/// <para>pExports</para>
		/// <para>Optional exports array. For more information, see <c>D3D12_EXPORT_DESC</c>.</para>
		/// </summary>
		public uint NumExports;

		/// <summary/>
		public ManagedArrayPointer<D3D12_EXPORT_DESC> pExports;
	}

	/// <summary>This subobject is unsupported in the current release.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_dxil_subobject_to_exports_association typedef struct
	// D3D12_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION { LPCWSTR SubobjectToAssociate; UINT NumExports; LPCWSTR *pExports; } D3D12_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_DXIL_SUBOBJECT_TO_EXPORTS_ASSOCIATION
	{
		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string SubobjectToAssociate;

		/// <summary>
		/// Size of the <i>pExports</i> array. If 0, this is being explicitly defined as a default association. Another way to define a
		/// default association is to omit this subobject association for that subobject completely.
		/// </summary>
		public uint NumExports;

		/// <summary>The array of exports with which the subobject is associated.</summary>
		public LPCWSTRArrayPointer pExports;
	}

	/// <summary>A state subobject describing an existing collection that can be included in a state object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_existing_collection_desc typedef struct
	// D3D12_EXISTING_COLLECTION_DESC { ID3D12StateObject *pExistingCollection; UINT NumExports; const D3D12_EXPORT_DESC *pExports; } D3D12_EXISTING_COLLECTION_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_EXISTING_COLLECTION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_EXISTING_COLLECTION_DESC
	{
		/// <summary>The collection to include in a state object. The enclosing state object holds a reference to the existing collection.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12StateObject pExistingCollection;

		/// <summary>
		/// <para>Size of the <i>pExports</i> array. If 0, all of the collection’s exports get exported.</para>
		/// <para>pExports</para>
		/// <para>Optional exports array. For more information, see <c>D3D12_EXPORT_DESC</c>.</para>
		/// </summary>
		public uint NumExports;

		/// <summary/>
		public ManagedArrayPointer<D3D12_EXPORT_DESC> pExports;
	}

	/// <summary>Describes an export from a state subobject such as a DXIL library or a collection state object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_export_desc typedef struct D3D12_EXPORT_DESC { LPCWSTR Name;
	// LPCWSTR ExportToRename; D3D12_EXPORT_FLAGS Flags; } D3D12_EXPORT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_EXPORT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_EXPORT_DESC(string name, string? exportToRename = null)
	{
		/// <summary>
		/// <para>
		/// The name to be exported. If the name refers to a function that is overloaded, a modified version of the name (e.g. encoding
		/// function parameter information in name string) can be provided to disambiguate which overload to use. The modified name for a
		/// function can be retrieved using HLSL compiler reflection.
		/// </para>
		/// <para>
		/// If the <i>ExportToRename</i> field is non-null, <i>Name</i> refers to the new name to use for it when exported. In this case
		/// <i>Name</i> must be the unmodified name, whereas <i>ExportToRename</i> can be either a modified or unmodified name. A given
		/// internal name may be exported multiple times with different renames (and/or not renamed).
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name = name;

		/// <summary>
		/// <para>If non-null, this is the name of an export to use but then rename when exported.</para>
		/// <para>Flags</para>
		/// <para>The flags to apply to the export.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? ExportToRename = exportToRename;

		/// <summary/>
		public D3D12_EXPORT_FLAGS Flags = 0;
	}

	/// <summary>
	/// <para>Provides detail about the adapter architecture, so that your application can better optimize for certain adapter properties.</para>
	/// <para>
	/// <b>Note</b>  This structure has been superseded by the <c>D3D12_FEATURE_DATA_ARCHITECTURE1</c> structure. If your application
	/// targets Windows 10, version 1703 (Creators' Update) or higher, then use <b>D3D12_FEATURE_DATA_ARCHITECTURE1</b> (and
	/// <c>D3D12_FEATURE_ARCHITECTURE1</c>) instead.
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>How to use UMA and CacheCoherentUMA</para>
	/// <para>
	/// D3D12 apps should be concerned about managing memory residency and providing the optimal heap properties. D3D12 apps can stay
	/// simplified and run reasonably well across many GPU architectures by only managing the residency for resources in
	/// <c>D3D12_HEAP_TYPE</c> _DEFAULT heaps. Those apps only need to call <c>IDXGIAdapter3::QueryVideoMemoryInfo</c> for
	/// DXGI_MEMORY_SEGMENT_GROUP_LOCAL, and they must be tolerant that D3D12_HEAP_TYPE_UPLOAD and D3D12_HEAP_TYPE_READBACK come from that
	/// same memory segment group.
	/// </para>
	/// <para>
	/// However, such a simple design is too constraining for applications that push the limits. So, D3D12_FEATURE_DATA_ARCHITECTURE helps
	/// applications better optimize for the underlying adapter properties.
	/// </para>
	/// <para>
	/// Some applications may want to better optimize for discrete adapters, and take on the additional complexity of managing both system
	/// memory and video memory budgets. If the size of upload heaps rivals the size of default textures, a near doubling of memory
	/// utilization is available. When supporting such optimizations, an application can either detect two residency budgets or recognize
	/// <b>UMA</b> is <b>false</b>.
	/// </para>
	/// <para>
	/// Some applications may want to better optimize for integrated/ UMA adapters, especially those that are interested in extending
	/// battery life on mobile device. Simple D3D12 applications are forced into copying data between heaps with different attributions,
	/// when it isn't always necessary on UMA. However, the UMA property, by itself, encompasses a reasonably vague grey area of GPU
	/// designs. Do not assume UMA means all GPU-accessible memory can be freely made CPU-accessible, because it doesn't. There's a property
	/// that more closely aligns to that type of thinking: <b>CacheCoherentUMA</b>.
	/// </para>
	/// <para>
	/// When <b>CacheCoherentUMA</b> is <b>false</b>, a single residency budget is available but the UMA design commonly benefits from the
	/// three heap attributions. Opportunities do exist to remove resource copying through wise usage of upload and readback resources and
	/// heaps, that provide CPU-access to the memory. Such opportunities are not clear-cut, though. So, applications should be cautious; and
	/// experimentation across a variety of "UMA" systems is advisable, as resorting to enabling or precluding certain device IDs may be
	/// warranted. An understanding of the GPU memory architecture and how heap types translate to cache properties is recommended. The
	/// feasibility of success is likely dependent on how often each processor either reads or writes the data, the size and locality of
	/// data accesses, etc. For advanced developers: when <b>UMA</b> is true and <b>CacheCoherentUMA</b> is <b>false</b>, the most unique
	/// characteristic for these adapters is that upload heaps are still write-combined. However, some UMA adapters benefit from both the
	/// no-CPU-access and write-combine properties of default and upload heaps. See <c>GetCustomHeapProperties</c> for more details.
	/// </para>
	/// <para>
	/// When <b>CacheCoherentUMA</b> is true, applications can more strongly entertain abandoning the attribution of heaps and using the
	/// custom heap equivalent of upload heaps everywhere. Zero-copy UMA optimizations are more generally encouraged as more scenarios will
	/// just benefit from shared usage. The memory model is very conducive to more scenarios and wider adoption. Some corner cases may still
	/// exist where benefits are not easily obtained, but they should be much rarer and less detrimental than other options. For advanced
	/// developers: <b>CacheCoherentUMA</b> means that a significant amount of the caches in the memory hierarchy are also unified or
	/// integrated between the CPU and GPU. The most unique observable characteristic is that upload heaps are actually write-back on
	/// <b>CacheCoherentUMA</b>. For these architecture, the usage of write-combine on upload heaps is commonly a detriment.
	/// </para>
	/// <para>
	/// The low-level details should be ignored by a vast majority of single-adapter applications. As usual, single-adapter applications can
	/// simplify the landscape and ensure that the CPU writes to upload heaps use patterns that are write-combine-friendly. The lower-level
	/// details help reinforce the concepts for multi-adapter applications. Multi-adapter applications likely need to understand adapter
	/// architecture properties well enough to choose the optimal custom heap properties to efficiently move data between adapters.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_architecture typedef struct
	// D3D12_FEATURE_DATA_ARCHITECTURE { UINT NodeIndex; BOOL TileBasedRenderer; BOOL UMA; BOOL CacheCoherentUMA; } D3D12_FEATURE_DATA_ARCHITECTURE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_ARCHITECTURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_ARCHITECTURE
	{
		/// <summary>
		/// In multi-adapter operation, this indicates which physical adapter of the device is relevant. See <c>Multi-adapter systems</c>.
		/// <b>NodeIndex</b> is filled out by the application before calling <c>CheckFeatureSupport</c>, as the application can retrieve
		/// details about the architecture of each adapter.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// Specifies whether the hardware and driver support a tile-based renderer. The runtime sets this member to <b>TRUE</b> if the
		/// hardware and driver support a tile-based renderer.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TileBasedRenderer;

		/// <summary>
		/// Specifies whether the hardware and driver support UMA. The runtime sets this member to <b>TRUE</b> if the hardware and driver
		/// support UMA.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool UMA;

		/// <summary>
		/// Specifies whether the hardware and driver support cache-coherent UMA. The runtime sets this member to <b>TRUE</b> if the
		/// hardware and driver support cache-coherent UMA.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool CacheCoherentUMA;
	}

	/// <summary>
	/// <para>
	/// Provides detail about each adapter's architectural details, so that your application can better optimize for certain adapter properties.
	/// </para>
	/// <para>
	/// <b>Note</b>  This structure, introduced in Windows 10, version 1703 (Creators' Update), supersedes the
	/// <c>D3D12_FEATURE_DATA_ARCHITECTURE</c> structure. If your application targets Windows 10, version 1703 (Creators' Update) or higher,
	/// then use <b>D3D12_FEATURE_DATA_ARCHITECTURE1</b> (and <c>D3D12_FEATURE_ARCHITECTURE1</c>).
	/// </para>
	/// <para></para>
	/// </summary>
	/// <remarks>
	/// <para>How to use UMA and CacheCoherentUMA</para>
	/// <para>
	/// D3D12 apps should be concerned about managing memory residency and providing the optimal heap properties. D3D12 apps can stay
	/// simplified and run reasonably well across many GPU architectures by only managing the residency for resources in
	/// <c>D3D12_HEAP_TYPE</c> _DEFAULT heaps. Those apps only need to call <c>IDXGIAdapter3::QueryVideoMemoryInfo</c> for
	/// DXGI_MEMORY_SEGMENT_GROUP_LOCAL, and they must be tolerant that D3D12_HEAP_TYPE_UPLOAD and D3D12_HEAP_TYPE_READBACK come from that
	/// same memory segment group.
	/// </para>
	/// <para>
	/// However, such a simple design is too constraining for applications that push the limits. So, D3D12_FEATURE_DATA_ARCHITECTURE helps
	/// applications better optimize for the underlying adapter properties.
	/// </para>
	/// <para>
	/// Some applications may want to better optimize for discrete adapters, and take on the additional complexity of managing both system
	/// memory and video memory budgets. If the size of upload heaps rivals the size of default textures, a near doubling of memory
	/// utilization is available. When supporting such optimizations, an application can either detect two residency budgets or recognize
	/// <b>UMA</b> is <b>false</b>.
	/// </para>
	/// <para>
	/// Some applications may want to better optimize for integrated/ UMA adapters, especially those that are interested in extending
	/// battery life on mobile device. Simple D3D12 applications are forced into copying data between heaps with different attributions,
	/// when it isn't always necessary on UMA. However, the UMA property, by itself, encompasses a reasonably vague grey area of GPU
	/// designs. Do not assume UMA means all GPU-accessible memory can be freely made CPU-accessible, because it doesn't. There's a property
	/// that more closely aligns to that type of thinking: <b>CacheCoherentUMA</b>.
	/// </para>
	/// <para>
	/// When <b>CacheCoherentUMA</b> is <b>false</b>, a single residency budget is available but the UMA design commonly benefits from the
	/// three heap attributions. Opportunities do exist to remove resource copying through wise usage of upload and readback resources and
	/// heaps, that provide CPU-access to the memory. Such opportunities are not clear-cut, though. So, applications should be cautious; and
	/// experimentation across a variety of "UMA" systems is advisable, as resorting to enabling or precluding certain device IDs may be
	/// warranted. An understanding of the GPU memory architecture and how heap types translate to cache properties is recommended. The
	/// feasibility of success is likely dependent on how often each processor either reads or writes the data, the size and locality of
	/// data accesses, etc. For advanced developers: when <b>UMA</b> is true and <b>CacheCoherentUMA</b> is <b>false</b>, the most unique
	/// characteristic for these adapters is that upload heaps are still write-combined. However, some UMA adapters benefit from both the
	/// no-CPU-access and write-combine properties of default and upload heaps. See <c>GetCustomHeapProperties</c> for more details.
	/// </para>
	/// <para>
	/// When <b>CacheCoherentUMA</b> is true, applications can more strongly entertain abandoning the attribution of heaps and using the
	/// custom heap equivalent of upload heaps everywhere. Zero-copy UMA optimizations such those offered by <c>WriteToSubresource</c> are
	/// more generally encouraged as more scenarios will just benefit from shared usage. The memory model is very conducive to more
	/// scenarios and wider adoption. Some corner cases may still exist where benefits are not easily obtained, but they should be much
	/// rarer and less detrimental than other options. For advanced developers: <b>CacheCoherentUMA</b> means that a significant amount of
	/// the caches in the memory hierarchy are also unified or integrated between the CPU and GPU. The most unique observable characteristic
	/// is that upload heaps are actually write-back on <b>CacheCoherentUMA</b>. For these architecture, the usage of write-combine on
	/// upload heaps is commonly a detriment.
	/// </para>
	/// <para>
	/// The low-level details should be ignored by a vast majority of single-adapter applications. As usual, single-adapter applications can
	/// simplify the landscape and ensure that the CPU writes to upload heaps use patterns that are write-combine-friendly. The lower-level
	/// details help reinforce the concepts for multi-adapter applications. Multi-adapter applications likely need to understand adapter
	/// architecture properties well enough to choose the optimal custom heap properties to efficiently move data between adapters.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_architecture1 typedef struct
	// D3D12_FEATURE_DATA_ARCHITECTURE1 { UINT NodeIndex; BOOL TileBasedRenderer; BOOL UMA; BOOL CacheCoherentUMA; BOOL IsolatedMMU; } D3D12_FEATURE_DATA_ARCHITECTURE1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_ARCHITECTURE1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_ARCHITECTURE1
	{
		/// <summary>
		/// In multi-adapter operation, this indicates which physical adapter of the device is relevant. See <c>Multi-adapter systems</c>.
		/// <b>NodeIndex</b> is filled out by the application before calling <c>CheckFeatureSupport</c>, as the application can retrieve
		/// details about the architecture of each adapter.
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// Specifies whether the hardware and driver support a tile-based renderer. The runtime sets this member to <b>TRUE</b> if the
		/// hardware and driver support a tile-based renderer.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TileBasedRenderer;

		/// <summary>
		/// Specifies whether the hardware and driver support UMA. The runtime sets this member to <b>TRUE</b> if the hardware and driver
		/// support UMA.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool UMA;

		/// <summary>
		/// Specifies whether the hardware and driver support cache-coherent UMA. The runtime sets this member to <b>TRUE</b> if the
		/// hardware and driver support cache-coherent UMA.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool CacheCoherentUMA;

		/// <summary>
		/// <para><c>SAL</c>: <c>Out</c></para>
		/// <para>
		/// Specifies whether the hardware and driver support isolated Memory Management Unit (MMU). The runtime sets this member to
		/// <b>TRUE</b> if the GPU honors CPU page table properties like <b>MEM_WRITE_WATCH</b> (for more information, see
		/// <c>VirtualAlloc</c>) and <b>PAGE_READONLY</b> (for more information, see <c>Memory Protection Constants</c>).
		/// </para>
		/// <para>
		/// If <b>TRUE</b>, the application must take care to no use memory with these page table properties with the GPU, as the GPU might
		/// trigger these page table properties in unexpected ways. For example, GPU write operations might be coarser than the application
		/// expects, particularly writes from within shaders. Certain write-watch pages might appear dirty, even when it isn't obvious how
		/// GPU writes may have affected them. GPU operations associated with upload and readback heap usage scenarios work well with
		/// write-watch pages, but might occasionally generate false positives that can be safely ignored.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool IsolatedMMU;
	}

	/// <summary>Details the adapter's support for prioritization of different command queue types.</summary>
	/// <remarks>
	/// <para>Use this structure with <c>CheckFeatureSupport</c> to determine the priority levels supported by various command queue types.</para>
	/// <para>See the enumeration constant <b>D3D12_FEATURE_COMMAND_QUEUE_PRIORITY</b> in the <c>D3D12_FEATURE</c> enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_command_queue_priority typedef struct
	// D3D12_FEATURE_DATA_COMMAND_QUEUE_PRIORITY { D3D12_COMMAND_LIST_TYPE CommandListType; UINT Priority; BOOL PriorityForTypeIsSupported;
	// } D3D12_FEATURE_DATA_COMMAND_QUEUE_PRIORITY;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_COMMAND_QUEUE_PRIORITY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_COMMAND_QUEUE_PRIORITY
	{
		/// <summary>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The type of the command list you're interested in.</para>
		/// </summary>
		public D3D12_COMMAND_LIST_TYPE CommandListType;

		/// <summary>
		/// <para><c>SAL</c>: <c>In</c></para>
		/// <para>The priority level you're interested in.</para>
		/// </summary>
		public uint Priority;

		/// <summary>
		/// <para><c>SAL</c>: <c>Out</c></para>
		/// <para>On return, contains true if the specfied command list type supports the specified priority level; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool PriorityForTypeIsSupported;
	}

	/// <summary>Indicates the level of support for the sharing of resources between different adapters—for example, multiple GPUs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_cross_node typedef struct
	// D3D12_FEATURE_DATA_CROSS_NODE { D3D12_CROSS_NODE_SHARING_TIER SharingTier; BOOL AtomicShaderInstructions; } D3D12_FEATURE_DATA_CROSS_NODE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_CROSS_NODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_CROSS_NODE
	{
		/// <summary>
		/// <para>Type: <b><c>D3D12_CROSS_NODE_SHARING_TIER</c></b></para>
		/// <para>Indicates the tier of cross-adapter sharing support.</para>
		/// </summary>
		public D3D12_CROSS_NODE_SHARING_TIER SharingTier;

		/// <summary>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>Indicates there is support for shader instructions which operate across adapters.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AtomicShaderInstructions;
	}

	/// <summary>Describes Direct3D 12 feature options in the current graphics driver.</summary>
	/// <remarks>See <c>D3D12_FEATURE</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS { BOOL DoublePrecisionFloatShaderOps; BOOL OutputMergerLogicOp; D3D12_SHADER_MIN_PRECISION_SUPPORT
	// MinPrecisionSupport; D3D12_TILED_RESOURCES_TIER TiledResourcesTier; D3D12_RESOURCE_BINDING_TIER ResourceBindingTier; BOOL
	// PSSpecifiedStencilRefSupported; BOOL TypedUAVLoadAdditionalFormats; BOOL ROVsSupported; D3D12_CONSERVATIVE_RASTERIZATION_TIER
	// ConservativeRasterizationTier; UINT MaxGPUVirtualAddressBitsPerResource; BOOL StandardSwizzle64KBSupported;
	// D3D12_CROSS_NODE_SHARING_TIER CrossNodeSharingTier; BOOL CrossAdapterRowMajorTextureSupported; BOOL
	// VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation; D3D12_RESOURCE_HEAP_TIER ResourceHeapTier; } D3D12_FEATURE_DATA_D3D12_OPTIONS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS
	{
		/// <summary>
		/// <para>
		/// Specifies whether <b>double</b> types are allowed for shader operations. If <b>TRUE</b>, double types are allowed; otherwise
		/// <b>FALSE</b>. The supported operations are equivalent to Direct3D 11's <b>ExtendedDoublesShaderInstructions</b> member of the
		/// <c>D3D11_FEATURE_DATA_D3D11_OPTIONS</c> structure.
		/// </para>
		/// <para>
		/// To use any HLSL shader that is compiled with a <b>double</b> type, the runtime must set <b>DoublePrecisionFloatShaderOps</b> to <b>TRUE</b>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DoublePrecisionFloatShaderOps;

		/// <summary>
		/// Specifies whether logic operations are available in blend state. The runtime sets this member to <b>TRUE</b> if logic operations
		/// are available in blend state and <b>FALSE</b> otherwise. This member is <b>FALSE</b> for feature level 9.1, 9.2, and 9.3. This
		/// member is optional for feature level 10, 10.1, and 11. This member is <b>TRUE</b> for feature level 11.1 and 12.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool OutputMergerLogicOp;

		/// <summary>
		/// A combination of <c>D3D12_SHADER_MIN_PRECISION_SUPPORT</c>-typed values that are combined by using a bitwise OR operation. The
		/// resulting value specifies minimum precision levels that the driver supports for shader stages. A value of zero indicates that
		/// the driver supports only full 32-bit precision for all shader stages.
		/// </summary>
		public D3D12_SHADER_MIN_PRECISION_SUPPORT MinPrecisionSupport;

		/// <summary>
		/// Specifies whether the hardware and driver support tiled resources. The runtime sets this member to a
		/// <c>D3D12_TILED_RESOURCES_TIER</c>-typed value that indicates if the hardware and driver support tiled resources and at what tier level.
		/// </summary>
		public D3D12_TILED_RESOURCES_TIER TiledResourcesTier;

		/// <summary>
		/// Specifies the level at which the hardware and driver support resource binding. The runtime sets this member to a
		/// <c>D3D12_RESOURCE_BINDING_TIER</c>-typed value that indicates the tier level.
		/// </summary>
		public D3D12_RESOURCE_BINDING_TIER ResourceBindingTier;

		/// <summary>Specifies whether pixel shader stencil ref is supported. If <b>TRUE</b>, it's supported; otherwise <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool PSSpecifiedStencilRefSupported;

		/// <summary>
		/// Specifies whether the loading of additional formats for typed unordered-access views (UAVs) is supported. If <b>TRUE</b>, it's
		/// supported; otherwise <b>FALSE</b>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TypedUAVLoadAdditionalFormats;

		/// <summary>
		/// Specifies whether <c>Rasterizer Order Views</c> (ROVs) are supported. If <b>TRUE</b>, they're supported; otherwise <b>FALSE</b>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool ROVsSupported;

		/// <summary>
		/// Specifies the level at which the hardware and driver support conservative rasterization. The runtime sets this member to a
		/// <c>D3D12_CONSERVATIVE_RASTERIZATION_TIER</c>-typed value that indicates the tier level.
		/// </summary>
		public D3D12_CONSERVATIVE_RASTERIZATION_TIER ConservativeRasterizationTier;

		/// <summary>
		/// Don't use this field; instead, use the <c>D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT</c> query (a structure with a
		/// <b>MaxGPUVirtualAddressBitsPerResource</b> member), which is more accurate.
		/// </summary>
		public uint MaxGPUVirtualAddressBitsPerResource;

		/// <summary>
		/// TRUE if the hardware supports textures with the 64KB standard swizzle pattern. Support for this pattern enables zero-copy
		/// texture optimizations while providing near-equilateral locality for each dimension within the texture. For texture swizzle
		/// options and restrictions, see <c>D3D12_TEXTURE_LAYOUT</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool StandardSwizzle64KBSupported;

		/// <summary>
		/// A <c>D3D12_CROSS_NODE_SHARING_TIER</c> enumeration constant that specifies the level of sharing across nodes of an adapter that
		/// has multiple nodes, such as Tier 1 Emulated, Tier 1, or Tier 2.
		/// </summary>
		public D3D12_CROSS_NODE_SHARING_TIER CrossNodeSharingTier;

		/// <summary>
		/// FALSE means the device only supports copy operations to and from cross-adapter row-major textures. TRUE means the device
		/// supports shader resource views, unordered access views, and render target views of cross-adapter row-major textures.
		/// "Cross-adapter" means between multiple adapters (even from different IHVs).
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool CrossAdapterRowMajorTextureSupported;

		/// <summary>
		/// Whether the viewport (VP) and Render Target (RT) array index from any shader feeding the rasterizer are supported without
		/// geometry shader emulation. Compare the <b>VPAndRTArrayIndexFromAnyShaderFeedingRasterizer</b> member of the
		/// <c>D3D11_FEATURE_DATA_D3D11_OPTIONS3</c> structure. In <c>ID3D12ShaderReflection::GetRequiresFlags</c>, see the #define D3D_SHADER_REQUIRES_VIEWPORT_AND_RT_ARRAY_INDEX_FROM_ANY_SHADER_FEEDING_RASTERIZER.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool VPAndRTArrayIndexFromAnyShaderFeedingRasterizerSupportedWithoutGSEmulation;

		/// <summary>
		/// Specifies the level at which the hardware and driver require heap attribution related to resource type. The runtime sets this
		/// member to a <c>D3D12_RESOURCE_HEAP_TIER</c> enumeration constant.
		/// </summary>
		public D3D12_RESOURCE_HEAP_TIER ResourceHeapTier;
	}

	/// <summary>Describes the level of support for HLSL 6.0 wave operations.</summary>
	/// <remarks>
	/// <para>
	/// A "lane" is single thread of execution. The shader models before version 6.0 expose only one of these at the language level, leaving
	/// expansion to parallel SIMD processing entirely up to the implementation.
	/// </para>
	/// <para>
	/// A "wave" is set of lanes (threads) executed simultaneously in the processor. No explicit barriers are required to guarantee that
	/// they execute in parallel. Similar concepts include "warp" and "wavefront".
	/// </para>
	/// <para>This structure is used with the D3D12_FEATURE_D3D12_OPTIONS1 member of <c>D3D12_FEATURE</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options1 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS1 { BOOL WaveOps; UINT WaveLaneCountMin; UINT WaveLaneCountMax; UINT TotalLaneCount; BOOL
	// ExpandedComputeResourceStates; BOOL Int64ShaderOps; } D3D12_FEATURE_DATA_D3D12_OPTIONS1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS1
	{
		/// <summary>True if the driver supports HLSL 6.0 wave operations.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool WaveOps;

		/// <summary>
		/// Specifies the baseline number of lanes in the SIMD wave that this implementation can support. This term is sometimes known as
		/// "wavefront size" or "warp width". Currently apps should rely only on this minimum value for sizing workloads.
		/// </summary>
		public uint WaveLaneCountMin;

		/// <summary>Specifies the maximum number of lanes in the SIMD wave that this implementation can support.</summary>
		public uint WaveLaneCountMax;

		/// <summary>Specifies the total number of SIMD lanes on the hardware.</summary>
		public uint TotalLaneCount;

		/// <summary>
		/// Indicates transitions are possible in and out of the CBV, and indirect argument states, on compute command lists. If
		/// <c>CheckFeatureSupport</c> succeeds this value will always be true.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool ExpandedComputeResourceStates;

		/// <summary>Indicates that 64bit integer operations are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Int64ShaderOps;
	}

	/// <summary>Indicates whether or not the SUM combiner can be used, and whether or not SV_ShadingRate can be set from a mesh shader.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options10 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS10 { BOOL VariableRateShadingSumCombinerSupported; BOOL MeshShaderPerPrimitiveShadingRateSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS10;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS10")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS10
	{
		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not the SUM combiner can be used (this relates to <c>variable-rate shading</c> Tier 2). <c>true</c> if it
		/// can, otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool VariableRateShadingSumCombinerSupported;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not SV_ShadingRate can be set from a mesh shader (this relates to <c>variable-rate shading</c> Tier 2).
		/// <c>true</c> if it can, otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool MeshShaderPerPrimitiveShadingRateSupported;
	}

	/// <summary>Indicates whether or not 64-bit integer atomics on resources in descriptor heaps are supported.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options11 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS11 { BOOL AtomicInt64OnDescriptorHeapResourceSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS11;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS11")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS11
	{
		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not 64-bit integer atomics on resources in descriptor heaps are supported. <c>true</c> if supported,
		/// otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AtomicInt64OnDescriptorHeapResourceSupported;
	}

	/// <summary>Indicates whether or not Enhanced Barriers are supported.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options12 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS12 { D3D12_TRI_STATE MSPrimitivesPipelineStatisticIncludesCulledPrimitives; BOOL
	// EnhancedBarriersSupported; BOOL RelaxedFormatCastingSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS12;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS12")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS12
	{
		/// <summary>
		/// <para>Type: _Out_ <b><c>D3D12_TRI_STATE</c></b></para>
		/// <para>TBD</para>
		/// </summary>
		public D3D12_TRI_STATE MSPrimitivesPipelineStatisticIncludesCulledPrimitives;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>Indicates whether or not Enhanced Barriers are supported. <c>true</c> if supported, otherwise <c>false</c>.</para>
		/// <para>
		/// Enhanced Barriers is not currently a hardware or driver requirement. So before using command list Barrier APIs, or resource
		/// creation APIs using the InitialLayout parameter, you must check for optional driver support via EnhancedBarriersSupported.
		/// </para>
		/// <para>Requires the DirectX 12 Agility SDK 1.7 or later; otherwise, the value is always <c>FALSE</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool EnhancedBarriersSupported;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>Technically used to indicate support for the functionality that enables integer aliasing.</para>
		/// <para>Requires the DirectX 12 Agility SDK 1.7 or later; otherwise, the value is always <c>FALSE</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool RelaxedFormatCastingSupported;
	}

	/// <summary>
	/// <para><c>UnrestrictedBufferTextureCopyPitchSupported</c></para>
	/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
	/// <para><c>UnrestrictedVertexElementAlignmentSupported</c></para>
	/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
	/// <para><c>InvertedViewportHeightFlipsYSupported</c></para>
	/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
	/// <para><c>InvertedViewportDepthFlipsZSupported</c></para>
	/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
	/// <para><c>TextureCopyBetweenDimensionsSupported</c></para>
	/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
	/// <para><c>AlphaBlendFactorSupported</c></para>
	/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options13 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS13 { BOOL UnrestrictedBufferTextureCopyPitchSupported; BOOL
	// UnrestrictedVertexElementAlignmentSupported; BOOL InvertedViewportHeightFlipsYSupported; BOOL InvertedViewportDepthFlipsZSupported;
	// BOOL TextureCopyBetweenDimensionsSupported; BOOL AlphaBlendFactorSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS13;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS13")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS13
	{
		/// <summary>Type: _Out_ <b><c>BOOL</c></b></summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool UnrestrictedBufferTextureCopyPitchSupported;

		/// <summary>Type: _Out_ <b><c>BOOL</c></b></summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool UnrestrictedVertexElementAlignmentSupported;

		/// <summary>Type: _Out_ <b><c>BOOL</c></b></summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool InvertedViewportHeightFlipsYSupported;

		/// <summary>Type: _Out_ <b><c>BOOL</c></b></summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool InvertedViewportDepthFlipsZSupported;

		/// <summary>Type: _Out_ <b><c>BOOL</c></b></summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool TextureCopyBetweenDimensionsSupported;

		/// <summary>Type: _Out_ <b><c>BOOL</c></b></summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AlphaBlendFactorSupported;
	}

	/// <summary>Indicates the level of support that the adapter provides for depth-bounds tests and programmable sample positions.</summary>
	/// <remarks>
	/// <para>
	/// Use this structure with <c>CheckFeatureSupport</c> to determine the level of support offered for the optional Depth-bounds test and
	/// programmable sample positions features.
	/// </para>
	/// <para>See the enumeration constant D3D12_FEATURE_D3D12_OPTIONS2 in the <c>D3D12_FEATURE</c> enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options2 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS2 { BOOL DepthBoundsTestSupported; D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER
	// ProgrammableSamplePositionsTier; } D3D12_FEATURE_DATA_D3D12_OPTIONS2;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS2
	{
		/// <summary>
		/// <para><c>SAL</c>: <c>Out</c></para>
		/// <para>On return, contains true if depth-bounds tests are supported; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthBoundsTestSupported;

		/// <summary>
		/// <para><c>SAL</c>: <c>Out</c></para>
		/// <para>On return, contains a value that indicates the level of support offered for programmable sample positions.</para>
		/// </summary>
		public D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER ProgrammableSamplePositionsTier;
	}

	/// <summary>
	/// Indicates the level of support that the adapter provides for timestamp queries, format-casting, immediate write, view instancing,
	/// and barycentrics.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options3 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS3 { BOOL CopyQueueTimestampQueriesSupported; BOOL CastingFullyTypedFormatSupported;
	// D3D12_COMMAND_LIST_SUPPORT_FLAGS WriteBufferImmediateSupportFlags; D3D12_VIEW_INSTANCING_TIER ViewInstancingTier; BOOL
	// BarycentricsSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS3;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS3
	{
		/// <summary>Indicates whether timestamp queries are supported on copy queues.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool CopyQueueTimestampQueriesSupported;

		/// <summary>Indicates whether casting from one fully typed format to another, compatible, format is supported.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool CastingFullyTypedFormatSupported;

		/// <summary>
		/// Indicates the kinds of command lists that support the ability to write an immediate value directly from the command stream into
		/// a specified buffer.
		/// </summary>
		public D3D12_COMMAND_LIST_SUPPORT_FLAGS WriteBufferImmediateSupportFlags;

		/// <summary>Indicates the level of support the adapter has for view instancing.</summary>
		public D3D12_VIEW_INSTANCING_TIER ViewInstancingTier;

		/// <summary>Indicates whether barycentrics are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool BarycentricsSupported;
	}

	/// <summary>Indicates the level of support for 64KB-aligned MSAA textures, cross-API sharing, and native 16-bit shader operations.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options4 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS4 { BOOL MSAA64KBAlignedTextureSupported; D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER
	// SharedResourceCompatibilityTier; BOOL Native16BitShaderOpsSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS4;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS4
	{
		/// <summary>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>Indicates whether 64KB-aligned MSAA textures are supported.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool MSAA64KBAlignedTextureSupported;

		/// <summary>
		/// <para>Type: <b><c>D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER</c></b></para>
		/// <para>Indicates the tier of cross-API sharing support.</para>
		/// </summary>
		public D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER SharedResourceCompatibilityTier;

		/// <summary>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates native 16-bit shader operations are supported. These operations require shader model 6_2. For more information, see
		/// the <c>16-Bit Scalar Types</c> HLSL reference.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Native16BitShaderOpsSupported;
	}

	/// <summary>
	/// Indicates the level of support that the adapter provides for render passes, ray tracing, and shader-resource view tier 3 tiled resources.
	/// </summary>
	/// <remarks>
	/// Pass <c>D3D12_FEATURE_D3D12_OPTIONS5</c> to <c>ID3D12Device::CheckFeatureSupport</c> to retrieve a
	/// <b>D3D12_FEATURE_DATA_D3D12_OPTIONS5</b> structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options5 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS5 { BOOL SRVOnlyTiledResourceTier3; D3D12_RENDER_PASS_TIER RenderPassesTier; D3D12_RAYTRACING_TIER
	// RaytracingTier; } D3D12_FEATURE_DATA_D3D12_OPTIONS5;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS5
	{
		/// <summary>
		/// A boolean value indicating whether the options require shader-resource view tier 3 tiled resource support. For more information,
		/// see <c>D3D12_TILED_RESOURCES_TIER</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool SRVOnlyTiledResourceTier3;

		/// <summary>
		/// <para>The extent to which a device driver and/or the hardware efficiently supports render passes. See <c>D3D12_RENDERPASS_TIER</c>.</para>
		/// <para>RaytracingTier</para>
		/// <para>Specifies the level of ray tracing support on the graphics device. See <c>D3D12_RAYTRACING_TIER</c>.</para>
		/// </summary>
		public D3D12_RENDER_PASS_TIER RenderPassesTier;

		/// <summary/>
		public D3D12_RAYTRACING_TIER RaytracingTier;
	}

	/// <summary>
	/// Indicates the level of support that the adapter provides for variable-rate shading (VRS), and indicates whether or not background
	/// processing is supported. For more info, see <c>Variable-rate shading (VRS)</c>, and the <c>Direct3D 12 background processing spec</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options6 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS6 { BOOL AdditionalShadingRatesSupported; BOOL PerPrimitiveShadingRateSupportedWithViewportIndexing;
	// D3D12_VARIABLE_SHADING_RATE_TIER VariableShadingRateTier; UINT ShadingRateImageTileSize; BOOL BackgroundProcessingSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS6;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS6
	{
		/// <summary>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether 2x4, 4x2, and 4x4 coarse pixel sizes are supported for single-sampled rendering; and whether coarse pixel size
		/// 2x4 is supported for 2x MSAA. <c>true</c> if those sizes are supported, otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AdditionalShadingRatesSupported;

		/// <summary>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether the per-provoking-vertex (also known as per-primitive) rate can be used with more than one viewport. If so,
		/// then, in that case, that rate can be used when <c>SV_ViewportIndex</c> is written to. <c>true</c> if that rate can be used with
		/// more than one viewport, otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool PerPrimitiveShadingRateSupportedWithViewportIndexing;

		/// <summary>
		/// <para>Type: <b><c>D3D12_VARIABLE_SHADING_RATE_TIER</c></b></para>
		/// <para>Indicates the shading rate tier.</para>
		/// </summary>
		public D3D12_VARIABLE_SHADING_RATE_TIER VariableShadingRateTier;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Indicates the tile size of the screen-space image as a <b>UINT</b>.</para>
		/// </summary>
		public uint ShadingRateImageTileSize;

		/// <summary>
		/// <para>Type: <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not background processing is supported. <c>true</c> if background processing is supported, otherwise
		/// <c>false</c>. For more info, see the <c>Direct3D 12 background processing spec</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool BackgroundProcessingSupported;
	}

	/// <summary>Indicates the level of support that the adapter provides for mesh and amplification shaders, and for sampler feedback.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options7 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS7 { D3D12_MESH_SHADER_TIER MeshShaderTier; D3D12_SAMPLER_FEEDBACK_TIER SamplerFeedbackTier; } D3D12_FEATURE_DATA_D3D12_OPTIONS7;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS7
	{
		/// <summary>
		/// <para>Type: _Out_ <b><c>D3D12_MESH_SHADER_TIER</c></b></para>
		/// <para>Indicates the level of support for mesh and amplification shaders.</para>
		/// </summary>
		public D3D12_MESH_SHADER_TIER MeshShaderTier;

		/// <summary>
		/// <para>Type: _Out_ <b><c>D3D12_SAMPLER_FEEDBACK_TIER</c></b></para>
		/// <para>Indicates the level of support for sampler feedback.</para>
		/// </summary>
		public D3D12_SAMPLER_FEEDBACK_TIER SamplerFeedbackTier;
	}

	/// <summary>Indicates whether or not unaligned block-compressed textures are supported.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options8 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS8 { BOOL UnalignedBlockTexturesSupported; } D3D12_FEATURE_DATA_D3D12_OPTIONS8;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS8
	{
		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>Indicates whether or not unaligned block-compressed textures are supported.</para>
		/// <para>
		/// If <c>false</c>, then Direct3D 12 requires that the dimensions of the top-level mip of a block-compressed texture are aligned to
		/// multiples of 4 (such alignment requirements do not apply to less-detailed mips). If <c>true</c>, then no such alignment
		/// requirement applies to any mip level of a block-compressed texture.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool UnalignedBlockTexturesSupported;
	}

	/// <summary>
	/// Indicates whether or not support exists for mesh shaders, values of SV_RenderTargetArrayIndex that are 8 or greater, typed resource
	/// 64-bit integer atomics, derivative and derivative-dependent texture sample operations, and the level of support for WaveMMA
	/// (wave_matrix) operations.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options9 typedef struct
	// D3D12_FEATURE_DATA_D3D12_OPTIONS9 { BOOL MeshShaderPipelineStatsSupported; BOOL MeshShaderSupportsFullRangeRenderTargetArrayIndex;
	// BOOL AtomicInt64OnTypedResourceSupported; BOOL AtomicInt64OnGroupSharedSupported; BOOL
	// DerivativesInMeshAndAmplificationShadersSupported; D3D12_WAVE_MMA_TIER WaveMMATier; } D3D12_FEATURE_DATA_D3D12_OPTIONS9;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_D3D12_OPTIONS9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_D3D12_OPTIONS9
	{
		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>Indicates whether or not mesh shaders are supported. <c>true</c> if supported, otherwise <c>false</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool MeshShaderPipelineStatsSupported;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not values of SV_RenderTargetArrayIndex that are 8 or greater are supported. <c>true</c> if supported,
		/// otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool MeshShaderSupportsFullRangeRenderTargetArrayIndex;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>Indicates whether or not typed resource 64-bit integer atomics are supported. <c>true</c> if supported, otherwise <c>false</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AtomicInt64OnTypedResourceSupported;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not 64-bit integer atomics are supported on <c>groupshared</c> variables. <c>true</c> if supported,
		/// otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AtomicInt64OnGroupSharedSupported;

		/// <summary>
		/// <para>Type: _Out_ <b><c>BOOL</c></b></para>
		/// <para>
		/// Indicates whether or not derivative and derivative-dependent texture sample operations are supported. <c>true</c> if supported,
		/// otherwise <c>false</c>.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DerivativesInMeshAndAmplificationShadersSupported;

		/// <summary>
		/// <para>Type: _Out_ <b><c>D3D12_WAVE_MMA_TIER</c></b></para>
		/// <para>Indicates the level of support for WaveMMA (wave_matrix) operations.</para>
		/// </summary>
		public D3D12_WAVE_MMA_TIER WaveMMATier;
	}

	/// <summary>This feature is currently in preview.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_displayable typedef struct
	// D3D12_FEATURE_DATA_DISPLAYABLE { BOOL DisplayableTexture; D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER SharedResourceCompatibilityTier; } D3D12_FEATURE_DATA_DISPLAYABLE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_DISPLAYABLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_DISPLAYABLE
	{
		/// <summary/>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DisplayableTexture;

		/// <summary/>
		public D3D12_SHARED_RESOURCE_COMPATIBILITY_TIER SharedResourceCompatibilityTier;
	}

	/// <summary>
	/// Provides detail about whether the adapter supports creating heaps from existing system memory. Such heaps are not intended for
	/// general use, but are exceptionally useful for diagnostic purposes, because they are guaranteed to persist even after the adapter
	/// faults or experiences a device-removal event. Persistence is not guaranteed for heaps returned by <c>ID3D12Device::CreateHeap</c> or
	/// <c>ID3D12Device::CreateCommittedResource</c>, even when the heap resides in system memory.
	/// </summary>
	/// <remarks>
	/// For a variety of performance and compatibility reasons, applications should not make use of this feature except for diagnostic
	/// purposes. In particular, heaps created using this feature only support system-memory heaps with cross-adapter properties, which
	/// precludes many optimization opportunities that typical application scenarios could otherwise take advantage of.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_existing_heaps typedef struct
	// D3D12_FEATURE_DATA_EXISTING_HEAPS { BOOL Supported; } D3D12_FEATURE_DATA_EXISTING_HEAPS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_EXISTING_HEAPS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_EXISTING_HEAPS
	{
		/// <summary><b>TRUE</b> if the adapter can create a heap from existing system memory. Otherwise, <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool Supported;
	}

	/// <summary>Describes info about the <c>feature levels</c> supported by the current graphics driver.</summary>
	/// <remarks>See <c>D3D12_FEATURE</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_feature_levels typedef struct
	// D3D12_FEATURE_DATA_FEATURE_LEVELS { UINT NumFeatureLevels; const D3D_FEATURE_LEVEL *pFeatureLevelsRequested; D3D_FEATURE_LEVEL
	// MaxSupportedFeatureLevel; } D3D12_FEATURE_DATA_FEATURE_LEVELS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_FEATURE_LEVELS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_FEATURE_LEVELS
	{
		/// <summary>The number of <c>feature levels</c> in the array at <b>pFeatureLevelsRequested</b>.</summary>
		public uint NumFeatureLevels;

		/// <summary>
		/// A pointer to an array of <c>D3D_FEATURE_LEVEL</c> s that the application is requesting for the driver and hardware to evaluate.
		/// </summary>
		public ArrayPointer<D3D_FEATURE_LEVEL> pFeatureLevelsRequested;

		/// <summary>The maximum <c>feature level</c> that the driver and hardware support.</summary>
		public D3D_FEATURE_LEVEL MaxSupportedFeatureLevel;
	}

	/// <summary>Describes a DXGI data format and plane count.</summary>
	/// <remarks>
	/// <para>See <c>D3D12_FEATURE</c>.</para>
	/// <para>Examples</para>
	/// <para>
	/// <c>inline UINT8 D3D12GetFormatPlaneCount( _In_ ID3D12Device* pDevice, DXGI_FORMAT Format ) { D3D12_FEATURE_DATA_FORMAT_INFO
	/// formatInfo{ Format }; if (FAILED(pDevice-&gt;CheckFeatureSupport(D3D12_FEATURE_FORMAT_INFO, &amp;formatInfo, sizeof(formatInfo)))) {
	/// return 0; } return formatInfo.PlaneCount; }</c>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_format_info typedef struct
	// D3D12_FEATURE_DATA_FORMAT_INFO { DXGI_FORMAT Format; UINT8 PlaneCount; } D3D12_FEATURE_DATA_FORMAT_INFO;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_FORMAT_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_FORMAT_INFO
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value for the format to return info about.</summary>
		public DXGI_FORMAT Format;

		/// <summary>The number of planes to provide information about.</summary>
		public byte PlaneCount;
	}

	/// <summary>Describes which resources are supported by the current graphics driver for a given format.</summary>
	/// <remarks>
	/// <para>Refer to <c>Typed unordered access view loads</c> for an example use of this structure.</para>
	/// <para>Also see <c>D3D12_FEATURE</c>.</para>
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
	/// <description><c>Hardware Support for Direct3D 10.1 Formats</c></description>
	/// </item>
	/// <item>
	/// <description><c>Hardware Support for Direct3D 10 Formats</c></description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_format_support typedef struct
	// D3D12_FEATURE_DATA_FORMAT_SUPPORT { DXGI_FORMAT Format; D3D12_FORMAT_SUPPORT1 Support1; D3D12_FORMAT_SUPPORT2 Support2; } D3D12_FEATURE_DATA_FORMAT_SUPPORT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_FORMAT_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_FORMAT_SUPPORT
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value for the format to return info about.</summary>
		public DXGI_FORMAT Format;

		/// <summary>
		/// A combination of <c>D3D12_FORMAT_SUPPORT1</c>-typed values that are combined by using a bitwise OR operation. The resulting
		/// value specifies which resources are supported.
		/// </summary>
		public D3D12_FORMAT_SUPPORT1 Support1;

		/// <summary>
		/// A combination of <c>D3D12_FORMAT_SUPPORT2</c>-typed values that are combined by using a bitwise OR operation. The resulting
		/// value specifies which unordered resource options are supported.
		/// </summary>
		public D3D12_FORMAT_SUPPORT2 Support2;
	}

	/// <summary>Details the adapter's GPU virtual address space limitations, including maximum address bits per resource and per process.</summary>
	/// <remarks>See the enumeration constant D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT in the <c>D3D12_FEATURE</c> enumeration.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_gpu_virtual_address_support typedef struct
	// D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT { UINT MaxGPUVirtualAddressBitsPerResource; UINT MaxGPUVirtualAddressBitsPerProcess; } D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT
	{
		/// <summary>
		/// <para>The maximum GPU virtual address bits per resource.</para>
		/// <para>
		/// Some adapters have significantly less bits available per resource than per process, while other adapters have significantly
		/// greater bits available per resource than per process. The latter scenario tends to happen in less common scenarios, like when
		/// running a 32-bit process on certain UMA adapters. When per resource capabilities are greater than per process, the greater per
		/// resource capabilities can only be leveraged by reserved resources or NULL mapped pages.
		/// </para>
		/// </summary>
		public uint MaxGPUVirtualAddressBitsPerResource;

		/// <summary>
		/// <para>The maximum GPU virtual address bits per process.</para>
		/// <para>
		/// When this value is nearly equal to the available residency budget, <c>Evict</c> will not be a feasible option to manage
		/// residency. See <c>MakeResident</c> for more details.
		/// </para>
		/// </summary>
		public uint MaxGPUVirtualAddressBitsPerProcess;
	}

	/// <summary>Describes the multi-sampling image quality levels for a given format and sample count.</summary>
	/// <remarks>See <c>D3D12_FEATURE</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_multisample_quality_levels typedef struct
	// D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS { DXGI_FORMAT Format; UINT SampleCount; D3D12_MULTISAMPLE_QUALITY_LEVEL_FLAGS Flags;
	// UINT NumQualityLevels; } D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value for the format to return info about.</summary>
		public DXGI_FORMAT Format;

		/// <summary>The number of multi-samples per pixel to return info about.</summary>
		public uint SampleCount;

		/// <summary>
		/// Flags to control quality levels, as a bitwise-OR'd combination of <c>D3D12_MULTISAMPLE_QUALITY_LEVEL_FLAGS</c> enumeration
		/// constants. The resulting value specifies options for determining quality levels.
		/// </summary>
		public D3D12_MULTISAMPLE_QUALITY_LEVEL_FLAGS Flags;

		/// <summary>The number of quality levels.</summary>
		public uint NumQualityLevels;
	}

	/// <summary>Indicates the level of support for protected resource sessions.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_protected_resource_session_support typedef
	// struct D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_SUPPORT { UINT NodeIndex; D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAGS
	// Support; } D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_SUPPORT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_SUPPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_SUPPORT
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>An input field, indicating the adapter index to query.</para>
		/// </summary>
		public uint NodeIndex;

		/// <summary/>
		public D3D12_PROTECTED_RESOURCE_SESSION_SUPPORT_FLAGS Support;
	}

	/// <summary>Indicates a count of protected resource session types.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_protected_resource_session_type_count typedef
	// struct D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPE_COUNT { UINT NodeIndex; UINT Count; } D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPE_COUNT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPE_COUNT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPE_COUNT
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// An input parameter which, in multi-adapter operation, indicates which physical adapter of the device this operation applies to.
		/// </para>
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>An output parameter containing the number of protected resource session types supported by the driver.</para>
		/// </summary>
		public uint Count;
	}

	/// <summary>Indicates a list of protected resource session types.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_protected_resource_session_types typedef struct
	// D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPES { UINT NodeIndex; UINT Count; GUID *pTypes; } D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPES;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_PROTECTED_RESOURCE_SESSION_TYPES
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// An input parameter which, in multi-adapter operation, indicates which physical adapter of the device this operation applies to.
		/// </para>
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// An input parameter indicating the size of the pTypes array. This must match the count returned through the
		/// <c>D3D12_FEATURE_PROTECTED_RESOURCE_SESSION_TYPE_COUNT</c> query.
		/// </para>
		/// </summary>
		public uint Count;

		/// <summary>
		/// <para>Type: <b><c>GUID</c>*</b></para>
		/// <para>An output parameter containing an array populated with the supported protected resource session types.</para>
		/// </summary>
		public ArrayPointer<Guid> pTypes;
	}

	/// <summary>Indicates the level of support that the adapter provides for metacommands.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_query_meta_command typedef struct
	// D3D12_FEATURE_DATA_QUERY_META_COMMAND { GUID CommandId; UINT NodeMask; const void *pQueryInputData; SIZE_T QueryInputDataSizeInBytes;
	// void *pQueryOutputData; SIZE_T QueryOutputDataSizeInBytes; } D3D12_FEATURE_DATA_QUERY_META_COMMAND;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_QUERY_META_COMMAND")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_QUERY_META_COMMAND
	{
		/// <summary>
		/// <para>Type: <b><c>GUID</c></b></para>
		/// <para>The fixed GUID that identifies the metacommand to query about.</para>
		/// </summary>
		public Guid CommandId;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For single GPU operation, this is zero. If there are multiple GPU nodes, a bit is set to identify a node (the device's physical
		/// adapter). Each bit in the mask corresponds to a single node. Only 1 bit must be set. Refer to <c>Multi-adapter systems</c>.
		/// </para>
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// <para>Type: <b>const <c>void</c>*</b></para>
		/// <para>A pointer to a buffer containing the query input data. Allocate QueryInputDataSizeInBytes bytes.</para>
		/// </summary>
		public IntPtr pQueryInputData;

		/// <summary>
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>The size of the buffer pointed to by pQueryInputData, in bytes.</para>
		/// </summary>
		public SizeT QueryInputDataSizeInBytes;

		/// <summary>
		/// <para>Type: <b><c>void</c>*</b></para>
		/// <para>A pointer to a buffer containing the query output data.</para>
		/// </summary>
		public IntPtr pQueryOutputData;

		/// <summary>
		/// <para>Type: <b><c>SIZE_T</c></b></para>
		/// <para>The size of the buffer pointed to by pQueryOutputData, in bytes.</para>
		/// </summary>
		public SizeT QueryOutputDataSizeInBytes;
	}

	/// <summary>Indicates root signature version support.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_root_signature typedef struct
	// D3D12_FEATURE_DATA_ROOT_SIGNATURE { D3D_ROOT_SIGNATURE_VERSION HighestVersion; } D3D12_FEATURE_DATA_ROOT_SIGNATURE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_ROOT_SIGNATURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_ROOT_SIGNATURE
	{
		/// <summary>
		/// On input, specifies the highest version <c>D3D_ROOT_SIGNATURE_VERSION</c> to check for. On output specifies the highest version,
		/// up to the input version specified, actually available.
		/// </summary>
		public D3D_ROOT_SIGNATURE_VERSION HighestVersion;
	}

	/// <summary>Indicates the level of support for heap serialization.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_serialization typedef struct
	// D3D12_FEATURE_DATA_SERIALIZATION { UINT NodeIndex; D3D12_HEAP_SERIALIZATION_TIER HeapSerializationTier; } D3D12_FEATURE_DATA_SERIALIZATION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_SERIALIZATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_SERIALIZATION
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>An input field, indicating the adapter index to query.</para>
		/// </summary>
		public uint NodeIndex;

		/// <summary>
		/// <para>Type: <b><c>D3D12_HEAP_SERIALIZATION_TIER</c></b></para>
		/// <para>An output field, indicating the tier of heap serialization support.</para>
		/// </summary>
		public D3D12_HEAP_SERIALIZATION_TIER HeapSerializationTier;
	}

	/// <summary>Describes the level of shader caching supported in the current graphics driver.</summary>
	/// <remarks>
	/// <para>
	/// Use this structure with <c>CheckFeatureSupport</c> to determine the level of support offered for the optional shader-caching features.
	/// </para>
	/// <para>See the enumeration constant D3D12_FEATURE_SHADER_CACHE in the <c>D3D12_FEATURE</c> enumeration.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_shader_cache typedef struct
	// D3D12_FEATURE_DATA_SHADER_CACHE { D3D12_SHADER_CACHE_SUPPORT_FLAGS SupportFlags; } D3D12_FEATURE_DATA_SHADER_CACHE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_SHADER_CACHE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_SHADER_CACHE
	{
		/// <summary>
		/// <para>Type: <c><b>D3D12_SHADER_CACHE_SUPPORT_FLAGS</b></c></para>
		/// <para><c>SAL</c>: <c>Out</c></para>
		/// <para>Indicates the level of caching supported.</para>
		/// </summary>
		public D3D12_SHADER_CACHE_SUPPORT_FLAGS SupportFlags;
	}

	/// <summary>Contains the supported shader model.</summary>
	/// <remarks>
	/// <para>Refer to the enumeration constant D3D12_FEATURE_SHADER_MODEL in the <c>D3D12_FEATURE</c>.</para>
	/// <para>
	/// When used with the <c>ID3D12Device::CheckFeatureSupport</c> function, before calling the function initialize the HighestShaderModel
	/// field to the highest shader model that your application understands. After the function completes successfully, the
	/// HighestShaderModel field contains the highest shader model that is both supported by the device and no higher than the shader model
	/// passed in.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// <b>ID3D12Device::CheckFeatureSupport</b> returns <b>E_INVALIDARG</b> if HighestShaderModel isn't known by the current runtime. For
	/// that reason, we recommend that you call this in a loop with decreasing shader models to determine the highest supported shader
	/// model. Alternatively, use the caps checking helper to simplify this; see the blog post <c>Introducing a New API for Checking Feature
	/// Support in Direct3D 12</c>.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_shader_model typedef struct
	// D3D12_FEATURE_DATA_SHADER_MODEL { D3D_SHADER_MODEL HighestShaderModel; } D3D12_FEATURE_DATA_SHADER_MODEL;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_FEATURE_DATA_SHADER_MODEL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_FEATURE_DATA_SHADER_MODEL
	{
		/// <summary>Specifies one member of <c>D3D_SHADER_MODEL</c> that indicates the maximum supported shader model.</summary>
		public D3D_SHADER_MODEL HighestShaderModel;
	}

	/// <summary>
	/// Describes a resource memory access barrier. Used by global, texture, and buffer barriers to indicate when resource memory must be
	/// made visible for a specific access type.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_global_barrier typedef struct D3D12_GLOBAL_BARRIER {
	// D3D12_BARRIER_SYNC SyncBefore; D3D12_BARRIER_SYNC SyncAfter; D3D12_BARRIER_ACCESS AccessBefore; D3D12_BARRIER_ACCESS AccessAfter; } D3D12_GLOBAL_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GLOBAL_BARRIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GLOBAL_BARRIER(D3D12_BARRIER_SYNC syncBefore, D3D12_BARRIER_SYNC syncAfter, D3D12_BARRIER_ACCESS accessBefore, D3D12_BARRIER_ACCESS accessAfter)
	{
		/// <summary>Synchronization scope of all preceding GPU work that must be completed before executing the barrier.</summary>
		public D3D12_BARRIER_SYNC SyncBefore = syncBefore;

		/// <summary>Synchronization scope of all subsequent GPU work that must wait until the barrier execution is finished.</summary>
		public D3D12_BARRIER_SYNC SyncAfter = syncAfter;

		/// <summary>
		/// Access bits corresponding with any relevant resource usage since the preceding barrier or the start of
		/// <b>ExecuteCommandLists</b> scope.
		/// </summary>
		public D3D12_BARRIER_ACCESS AccessBefore = accessBefore;

		/// <summary>Access bits corresponding with any relevant resource usage after the barrier completes.</summary>
		public D3D12_BARRIER_ACCESS AccessAfter = accessAfter;
	}

	/// <summary>Defines a global root signature state suboject that will be used with associated shaders.</summary>
	/// <remarks>
	/// <para>
	/// The presence of this subobject in a state object is optional. The combination of global and/or local root signatures associated with
	/// any given shader function must define all resource bindings declared by the shader with no overlap across global and local root signatures.
	/// </para>
	/// <para>
	/// If any given function in a call graph is associated with a particular global root signature, any other functions in the graph must
	/// either be associated with the same global root signature or none, and the shader entry (the root of the call graph) must be
	/// associated with the global root signature.
	/// </para>
	/// <para>
	/// Different shaders can use different global root signatures (or none) within a state object, however any shaders referenced during a
	/// particular <c>DispatchRays</c> operation from a command list must have specified the same global root signature as what has been set
	/// on the command list as the compute root signature. So it is valid to define a single large state object with multiple global root
	/// signatures associated with different subsets of the shaders. Apps are not forced to split their state object just because some
	/// shaders use different global root signatures.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_global_root_signature typedef struct
	// D3D12_GLOBAL_ROOT_SIGNATURE { ID3D12RootSignature *pGlobalRootSignature; } D3D12_GLOBAL_ROOT_SIGNATURE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GLOBAL_ROOT_SIGNATURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GLOBAL_ROOT_SIGNATURE
	{
		/// <summary>The root signature that will function as a global root signature. A state object holds a reference to this signature.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12RootSignature pGlobalRootSignature;
	}

	/// <summary>Describes a GPU descriptor handle.</summary>
	/// <remarks>
	/// <para>This structure is returned by <c>ID3D12DescriptorHeap::GetGPUDescriptorHandleForHeapStart</c>.</para>
	/// <para>This structure is passed into the following methods:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewFloat</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::ClearUnorderedAccessViewUint</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList:SetComputeRootDescriptorTable</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12GraphicsCommandList::SetGraphicsRootDescriptorTable</c></description>
	/// </item>
	/// </list>
	/// <para>To get the handle increment size use <c>ID3D12Device.GetDescriptorHandleIncrementSize</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_gpu_descriptor_handle typedef struct
	// D3D12_GPU_DESCRIPTOR_HANDLE { UINT64 ptr; } D3D12_GPU_DESCRIPTOR_HANDLE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GPU_DESCRIPTOR_HANDLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GPU_DESCRIPTOR_HANDLE : IEquatable<D3D12_GPU_DESCRIPTOR_HANDLE>
	{
		/// <summary>The address of the descriptor.</summary>
		public SizeT ptr;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_GPU_DESCRIPTOR_HANDLE hANDLE && Equals(hANDLE);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_GPU_DESCRIPTOR_HANDLE other) => ptr.Equals(other.ptr);

		/// <inheritdoc/>
		public override int GetHashCode() => 53357169 + ptr.GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_GPU_DESCRIPTOR_HANDLE left, D3D12_GPU_DESCRIPTOR_HANDLE right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_GPU_DESCRIPTOR_HANDLE left, D3D12_GPU_DESCRIPTOR_HANDLE right) => !(left == right);

		/// <summary>Initializes a new instance of the <see cref="D3D12_CPU_DESCRIPTOR_HANDLE"/> struct.</summary>
		/// <param name="h">The handle.</param>
		/// <param name="offsetScaledByIncrementSize">Size of the offset scaled by increment.</param>
		public D3D12_GPU_DESCRIPTOR_HANDLE(in D3D12_GPU_DESCRIPTOR_HANDLE h, int offsetScaledByIncrementSize) => ptr = h.ptr + offsetScaledByIncrementSize;

		/// <summary>Initializes a new instance of the <see cref="D3D12_GPU_DESCRIPTOR_HANDLE"/> struct.</summary>
		/// <param name="h">The handle.</param>
		/// <param name="offsetInDescriptors">The offset in descriptors.</param>
		/// <param name="descriptorIncrementSize">Size of the descriptor increment.</param>
		public D3D12_GPU_DESCRIPTOR_HANDLE(in D3D12_GPU_DESCRIPTOR_HANDLE h, int offsetInDescriptors, uint descriptorIncrementSize) => ptr = h.ptr + offsetInDescriptors * descriptorIncrementSize;

		/// <summary>Offsets the specified offset in descriptors.</summary>
		/// <param name="offsetInDescriptors">The offset in descriptors.</param>
		/// <param name="descriptorIncrementSize">Size of the descriptor increment.</param>
		/// <returns></returns>
		public D3D12_GPU_DESCRIPTOR_HANDLE Offset(int offsetInDescriptors, uint descriptorIncrementSize)
		{
			ptr += offsetInDescriptors * descriptorIncrementSize;
			return this;
		}

		/// <summary>Offsets the specified offset scaled by increment size.</summary>
		/// <param name="offsetScaledByIncrementSize">Size of the offset scaled by increment.</param>
		/// <returns></returns>
		public D3D12_GPU_DESCRIPTOR_HANDLE Offset(int offsetScaledByIncrementSize)
		{
			ptr += offsetScaledByIncrementSize;
			return this;
		}
	}

	/// <summary>Represents a GPU virtual address and indexing stride.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_gpu_virtual_address_and_stride typedef struct
	// D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE { D3D12_GPU_VIRTUAL_ADDRESS StartAddress; UINT64 StrideInBytes; } D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE
	{
		/// <summary>The beginning of the virtual address range.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS StartAddress;

		/// <summary>
		/// Defines indexing stride, such as for vertices. Only the bottom 32 bits are used. The field is 64 bits to make alignment of
		/// containing structures consistent everywhere.
		/// </summary>
		public ulong StrideInBytes;
	}

	/// <summary>Represents a GPU virtual address range.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_gpu_virtual_address_range typedef struct
	// D3D12_GPU_VIRTUAL_ADDRESS_RANGE { D3D12_GPU_VIRTUAL_ADDRESS StartAddress; UINT64 SizeInBytes; } D3D12_GPU_VIRTUAL_ADDRESS_RANGE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GPU_VIRTUAL_ADDRESS_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GPU_VIRTUAL_ADDRESS_RANGE
	{
		/// <summary>The beginning of the virtual address range.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS StartAddress;

		/// <summary>The size of the virtual address range, in bytes.</summary>
		public ulong SizeInBytes;
	}

	/// <summary>Represents a GPU virtual address range and stride.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_gpu_virtual_address_range_and_stride typedef struct
	// D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE { D3D12_GPU_VIRTUAL_ADDRESS StartAddress; UINT64 SizeInBytes; UINT64 StrideInBytes; } D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GPU_VIRTUAL_ADDRESS_RANGE_AND_STRIDE
	{
		/// <summary>The beginning of the virtual address range.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS StartAddress;

		/// <summary>The size of the virtual address range, in bytes.</summary>
		public ulong SizeInBytes;

		/// <summary>Defines the record-indexing stride within the memory range.</summary>
		public ulong StrideInBytes;
	}

	/// <summary>Describes a graphics pipeline state object.</summary>
	/// <remarks>
	/// <para>This structure is used by the <c>CreateGraphicsPipelineState</c> method.</para>
	/// <para>The runtime validates:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Whether the linkage between the shader stages is correct.</description>
	/// </item>
	/// <item>
	/// <description>
	/// If the <b>HS</b> and <b>DS</b> members are specified, the <b>PrimitiveTopologyType</b> member for topology type must be set to <c>D3D12_PRIMITIVE_TOPOLOGY_TYPE_PATCH</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description>Whether sample frequency execution isn't allowed with the center multi-sample anti-aliasing (MSAA) pattern.</description>
	/// </item>
	/// <item>
	/// <description>Whether anti-aliasing lines aren't allowed with the center MSAA pattern.</description>
	/// </item>
	/// <item>
	/// <description>
	/// If the <b>ForcedSampleCount</b> member of <c>D3D12_RASTERIZER_DESC</c> that <b>RasterizerState</b> specifies isn't zero:
	/// </description>
	/// </item>
	/// <item>
	/// <description>Whether blend state is compatible with render target formats.</description>
	/// </item>
	/// <item>
	/// <description>Whether pixel shader output type is compatible with render target format.</description>
	/// </item>
	/// <item>
	/// <description>Whether the sample count and quality are supported for the render target/depth stencil formats.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_graphics_pipeline_state_desc typedef struct
	// D3D12_GRAPHICS_PIPELINE_STATE_DESC { ID3D12RootSignature *pRootSignature; D3D12_SHADER_BYTECODE VS; D3D12_SHADER_BYTECODE PS;
	// D3D12_SHADER_BYTECODE DS; D3D12_SHADER_BYTECODE HS; D3D12_SHADER_BYTECODE GS; D3D12_STREAM_OUTPUT_DESC StreamOutput; D3D12_BLEND_DESC
	// BlendState; UINT SampleMask; D3D12_RASTERIZER_DESC RasterizerState; D3D12_DEPTH_STENCIL_DESC DepthStencilState;
	// D3D12_INPUT_LAYOUT_DESC InputLayout; D3D12_INDEX_BUFFER_STRIP_CUT_VALUE IBStripCutValue; D3D12_PRIMITIVE_TOPOLOGY_TYPE
	// PrimitiveTopologyType; UINT NumRenderTargets; DXGI_FORMAT RTVFormats[8]; DXGI_FORMAT DSVFormat; DXGI_SAMPLE_DESC SampleDesc; UINT
	// NodeMask; D3D12_CACHED_PIPELINE_STATE CachedPSO; D3D12_PIPELINE_STATE_FLAGS Flags; } D3D12_GRAPHICS_PIPELINE_STATE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_GRAPHICS_PIPELINE_STATE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_GRAPHICS_PIPELINE_STATE_DESC
	{
		/// <summary>A pointer to the <c>ID3D12RootSignature</c> object.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12RootSignature pRootSignature;

		/// <summary>A <c>D3D12_SHADER_BYTECODE</c> structure that describes the vertex shader.</summary>
		public D3D12_SHADER_BYTECODE VS;

		/// <summary>A <c>D3D12_SHADER_BYTECODE</c> structure that describes the pixel shader.</summary>
		public D3D12_SHADER_BYTECODE PS;

		/// <summary>A <c>D3D12_SHADER_BYTECODE</c> structure that describes the domain shader.</summary>
		public D3D12_SHADER_BYTECODE DS;

		/// <summary>A <c>D3D12_SHADER_BYTECODE</c> structure that describes the hull shader.</summary>
		public D3D12_SHADER_BYTECODE HS;

		/// <summary>A <c>D3D12_SHADER_BYTECODE</c> structure that describes the geometry shader.</summary>
		public D3D12_SHADER_BYTECODE GS;

		/// <summary>A <c>D3D12_STREAM_OUTPUT_DESC</c> structure that describes a streaming output buffer.</summary>
		public D3D12_STREAM_OUTPUT_DESC StreamOutput;

		/// <summary>A <c>D3D12_BLEND_DESC</c> structure that describes the blend state.</summary>
		public D3D12_BLEND_DESC BlendState;

		/// <summary>The sample mask for the blend state.</summary>
		public uint SampleMask;

		/// <summary>A <c>D3D12_RASTERIZER_DESC</c> structure that describes the rasterizer state.</summary>
		public D3D12_RASTERIZER_DESC RasterizerState;

		/// <summary>A <c>D3D12_DEPTH_STENCIL_DESC</c> structure that describes the depth-stencil state.</summary>
		public D3D12_DEPTH_STENCIL_DESC DepthStencilState;

		/// <summary>A <c>D3D12_INPUT_LAYOUT_DESC</c> structure that describes the input-buffer data for the input-assembler stage.</summary>
		public D3D12_INPUT_LAYOUT_DESC InputLayout;

		/// <summary>Specifies the properties of the index buffer in a <c>D3D12_INDEX_BUFFER_STRIP_CUT_VALUE</c> structure.</summary>
		public D3D12_INDEX_BUFFER_STRIP_CUT_VALUE IBStripCutValue;

		/// <summary>A <c>D3D12_PRIMITIVE_TOPOLOGY_TYPE</c>-typed value for the type of primitive, and ordering of the primitive data.</summary>
		public D3D12_PRIMITIVE_TOPOLOGY_TYPE PrimitiveTopologyType;

		/// <summary>The number of render target formats in the <b>RTVFormats</b> member.</summary>
		public uint NumRenderTargets;

		/// <summary>An array of <c>DXGI_FORMAT</c>-typed values for the render target formats.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public DXGI_FORMAT[] RTVFormats;

		/// <summary>A <c>DXGI_FORMAT</c>-typed value for the depth-stencil format.</summary>
		public DXGI_FORMAT DSVFormat;

		/// <summary>A <c>DXGI_SAMPLE_DESC</c> structure that specifies multisampling parameters.</summary>
		public DXGI_SAMPLE_DESC SampleDesc;

		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set bits to identify the nodes (the device's
		/// physical adapters) for which the graphics pipeline state is to apply. Each bit in the mask corresponds to a single node. Refer
		/// to <c>Multi-adapter systems</c>.
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// A cached pipeline state object, as a <c>D3D12_CACHED_PIPELINE_STATE</c> structure. pCachedBlob and CachedBlobSizeInBytes may be
		/// set to NULL and 0 respectively.
		/// </summary>
		public D3D12_CACHED_PIPELINE_STATE CachedPSO;

		/// <summary>A <c>D3D12_PIPELINE_STATE_FLAGS</c> enumeration constant such as for "tool debug".</summary>
		public D3D12_PIPELINE_STATE_FLAGS Flags;

		/// <summary>
		/// Sets the number of render targets and the render target formats ensuring that the <see cref="RTVFormats"/> array is correctly sized.
		/// </summary>
		/// <param name="value">The render targets.</param>
		[MemberNotNull(nameof(RTVFormats))]
		public void SetRTVFormats(params DXGI_FORMAT[] value)
		{
			RTVFormats = new DXGI_FORMAT[8];
			if (value is null || value.Length == 0)
			{
				NumRenderTargets = 0;
			}
			else
			{
				Array.ConstrainedCopy(value, 0, RTVFormats, 0, (int)(NumRenderTargets = (uint)Math.Min(value.Length, RTVFormats.Length)));
			}
		}
	}

	/// <summary>Describes a heap.</summary>
	/// <remarks>This structure is used by the <c>CreateHeap</c> method, and returned by the <c>GetDesc</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_heap_desc typedef struct D3D12_HEAP_DESC { UINT64
	// SizeInBytes; D3D12_HEAP_PROPERTIES Properties; UINT64 Alignment; D3D12_HEAP_FLAGS Flags; } D3D12_HEAP_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_HEAP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_HEAP_DESC : IEquatable<D3D12_HEAP_DESC>
	{
		/// <summary>
		/// The size, in bytes, of the heap. To avoid wasting memory, applications should pass <i>SizeInBytes</i> values which are multiples
		/// of the effective <i>Alignment</i>; but non-aligned <i>SizeInBytes</i> is also supported, for convenience. To find out how large
		/// a heap must be to support textures with undefined layouts and adapter-specific sizes, call <c>ID3D12Device::GetResourceAllocationInfo</c>.
		/// </summary>
		public ulong SizeInBytes;

		/// <summary>A <c>D3D12_HEAP_PROPERTIES</c> structure that describes the heap properties.</summary>
		public D3D12_HEAP_PROPERTIES Properties;

		/// <summary>
		/// <para>The alignment value for the heap. Valid values:</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>0</description>
		/// <description>An alias for 64KB.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT</description>
		/// <description>#defined as 64KB.</description>
		/// </item>
		/// <item>
		/// <description>D3D12_DEFAULT_MSAA_RESOURCE_PLACEMENT_ALIGNMENT</description>
		/// <description>
		/// #defined as 4MB. An application must decide whether the heap will contain multi-sample anti-aliasing (MSAA), in which case, the
		/// application must choose D3D12_DEFAULT_MSAA_RESOURCE_PLACEMENT_ALIGNMENT.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public ulong Alignment;

		/// <summary>
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </summary>
		public D3D12_HEAP_FLAGS Flags;

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_DESC"/> struct.</summary>
		/// <param name="size">The size, in bytes, of the heap.</param>
		/// <param name="properties">A <c>D3D12_HEAP_PROPERTIES</c> structure that describes the heap properties.</param>
		/// <param name="alignment">The alignment value for the heap.</param>
		/// <param name="flags">
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </param>
		public D3D12_HEAP_DESC(ulong size, D3D12_HEAP_PROPERTIES properties, ulong alignment, D3D12_HEAP_FLAGS flags = D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE)
		{
			SizeInBytes = size;
			Properties = properties;
			Alignment = alignment;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_DESC"/> struct.</summary>
		/// <param name="size">The size, in bytes, of the heap.</param>
		/// <param name="type">A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the type of heap.</param>
		/// <param name="alignment">The alignment value for the heap.</param>
		/// <param name="flags">
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </param>
		public D3D12_HEAP_DESC(ulong size, D3D12_HEAP_TYPE type, ulong alignment, D3D12_HEAP_FLAGS flags = D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE)
		{
			SizeInBytes = size;
			Properties = new(type);
			Alignment = alignment;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_DESC"/> struct.</summary>
		/// <param name="size">The size, in bytes, of the heap.</param>
		/// <param name="cpuPageProperty">A <c>D3D12_CPU_PAGE_PROPERTY</c>-typed value that specifies the CPU-page properties for the heap.</param>
		/// <param name="memoryPoolPreference">The memory pool preference.</param>
		/// <param name="alignment">The alignment value for the heap.</param>
		/// <param name="flags">
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </param>
		public D3D12_HEAP_DESC(ulong size, D3D12_CPU_PAGE_PROPERTY cpuPageProperty, D3D12_MEMORY_POOL memoryPoolPreference, ulong alignment, D3D12_HEAP_FLAGS flags = D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE)
		{
			SizeInBytes = size;
			Properties = new(cpuPageProperty, memoryPoolPreference);
			Alignment = alignment;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_DESC"/> struct.</summary>
		/// <param name="resAllocInfo">A <see cref="D3D12_RESOURCE_ALLOCATION_INFO"/> that describes the resource allocation.</param>
		/// <param name="properties">A <c>D3D12_HEAP_PROPERTIES</c> structure that describes the heap properties.</param>
		/// <param name="flags">
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </param>
		public D3D12_HEAP_DESC(in D3D12_RESOURCE_ALLOCATION_INFO resAllocInfo, in D3D12_HEAP_PROPERTIES properties, D3D12_HEAP_FLAGS flags = D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE)
		{
			SizeInBytes = resAllocInfo.SizeInBytes;
			Properties = properties;
			Alignment = resAllocInfo.Alignment;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_DESC"/> struct.</summary>
		/// <param name="resAllocInfo">A <see cref="D3D12_RESOURCE_ALLOCATION_INFO"/> that describes the resource allocation.</param>
		/// <param name="type">A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the type of heap.</param>
		/// <param name="flags">
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </param>
		public D3D12_HEAP_DESC(in D3D12_RESOURCE_ALLOCATION_INFO resAllocInfo, D3D12_HEAP_TYPE type, D3D12_HEAP_FLAGS flags = D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE)
		{
			SizeInBytes = resAllocInfo.SizeInBytes;
			Properties = new(type);
			Alignment = resAllocInfo.Alignment;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_DESC"/> struct.</summary>
		/// <param name="resAllocInfo">A <see cref="D3D12_RESOURCE_ALLOCATION_INFO"/> that describes the resource allocation.</param>
		/// <param name="cpuPageProperty">A <c>D3D12_CPU_PAGE_PROPERTY</c>-typed value that specifies the CPU-page properties for the heap.</param>
		/// <param name="memoryPoolPreference">The memory pool preference.</param>
		/// <param name="flags">
		/// A combination of <c>D3D12_HEAP_FLAGS</c>-typed values that are combined by using a bitwise-OR operation. The resulting value
		/// identifies heap options. When creating heaps to support adapters with resource heap tier 1, an application must choose some flags.
		/// </param>
		public D3D12_HEAP_DESC(in D3D12_RESOURCE_ALLOCATION_INFO resAllocInfo, D3D12_CPU_PAGE_PROPERTY cpuPageProperty, D3D12_MEMORY_POOL memoryPoolPreference, D3D12_HEAP_FLAGS flags = D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE)
		{
			SizeInBytes = resAllocInfo.SizeInBytes;
			Properties = new(cpuPageProperty, memoryPoolPreference);
			Alignment = resAllocInfo.Alignment;
			Flags = flags;
		}

		/// <summary>Gets a value indicating whether this instance is cpu accessible.</summary>
		/// <value><c>true</c> if this instance is cpu accessible; otherwise, <c>false</c>.</value>
		public readonly bool IsCPUAccessible => Properties.IsCPUAccessible;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_HEAP_DESC dESC && Equals(dESC);

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_HEAP_DESC other) => SizeInBytes == other.SizeInBytes && Properties.Equals(other.Properties) && Alignment == other.Alignment && Flags == other.Flags;

		/// <inheritdoc/>
		public override int GetHashCode() => (SizeInBytes, Properties, Alignment, Flags).GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_HEAP_DESC left, D3D12_HEAP_DESC right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_HEAP_DESC left, D3D12_HEAP_DESC right) => !(left == right);
	}

	/// <summary>Describes heap properties.</summary>
	/// <remarks>
	/// <para>This structure is used by the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>D3D12_HEAP_DESC</c> structure</description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Resource::GetHeapProperties</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::GetCustomHeapProperties</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateCommittedResource</c></description>
	/// </item>
	/// </list>
	/// <para>Valid combinations of struct member values:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>
	/// When <b>Type</b> is <c>D3D12_HEAP_TYPE</c> _CUSTOM, <b>CPUPageProperty</b> and <b>MemoryPoolPreference</b> must not be ..._UNKNOWN.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// When <b>Type</b> is not D3D12_HEAP_TYPE_CUSTOM, <b>CPUPageProperty</b> and <b>MemoryPoolPreference</b> must be ..._UNKNOWN.
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// When using D3D12_HEAP_TYPE_CUSTOM and <c>D3D12_MEMORY_POOL</c> _L1, on NUMA adapters, <b>CPUPageProperty</b> must be
	/// <c>D3D12_CPU_PAGE_PROPERTY</c> _NOT_AVAILABLE. To differentiate NUMA from UMA adapters, see <c>D3D12_FEATURE</c> _ARCHITECTURE and <c>D3D12_FEATURE_DATA_ARCHITECTURE</c>.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_heap_properties typedef struct D3D12_HEAP_PROPERTIES {
	// D3D12_HEAP_TYPE Type; D3D12_CPU_PAGE_PROPERTY CPUPageProperty; D3D12_MEMORY_POOL MemoryPoolPreference; UINT CreationNodeMask; UINT
	// VisibleNodeMask; } D3D12_HEAP_PROPERTIES;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_HEAP_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_HEAP_PROPERTIES : IEquatable<D3D12_HEAP_PROPERTIES>
	{
		/// <summary>A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the type of heap.</summary>
		public D3D12_HEAP_TYPE Type;

		/// <summary>A <c>D3D12_CPU_PAGE_PROPERTY</c>-typed value that specifies the CPU-page properties for the heap.</summary>
		public D3D12_CPU_PAGE_PROPERTY CPUPageProperty;

		/// <summary>A <c>D3D12_MEMORY_POOL</c>-typed value that specifies the memory pool for the heap.</summary>
		public D3D12_MEMORY_POOL MemoryPoolPreference;

		/// <summary>
		/// <para>For multi-adapter operation, this indicates the node where the resource should be created.</para>
		/// <para>Exactly one bit of this UINT must be set. See <c>Multi-adapter systems</c>.</para>
		/// <para>Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.</para>
		/// </summary>
		public uint CreationNodeMask;

		/// <summary>
		/// <para>For multi-adapter operation, this indicates the set of nodes where the resource is visible.</para>
		/// <para>
		/// <i>VisibleNodeMask</i> must have the same bit set that is set in <i>CreationNodeMask</i>. <i>VisibleNodeMask</i> can also have
		/// additional bits set for cross-node resources, but doing so can potentially reduce performance for resource accesses, so you
		/// should do so only when needed.
		/// </para>
		/// <para>Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.</para>
		/// </summary>
		public uint VisibleNodeMask;

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_PROPERTIES"/> struct.</summary>
		/// <param name="cpuPageProperty">A <c>D3D12_CPU_PAGE_PROPERTY</c>-typed value that specifies the CPU-page properties for the heap.</param>
		/// <param name="memoryPoolPreference">The memory pool preference.</param>
		/// <param name="creationNodeMask">
		/// <para>For multi-adapter operation, this indicates the node where the resource should be created.</para>
		/// <para>Exactly one bit of this UINT must be set. See <c>Multi-adapter systems</c>.</para>
		/// <para>Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.</para>
		/// </param>
		/// <param name="nodeMask">
		/// <para>For multi-adapter operation, this indicates the set of nodes where the resource is visible.</para>
		/// <para>
		/// <i>VisibleNodeMask</i> must have the same bit set that is set in <i>CreationNodeMask</i>. <i>VisibleNodeMask</i> can also have
		/// additional bits set for cross-node resources, but doing so can potentially reduce performance for resource accesses, so you
		/// should do so only when needed.
		/// </para>
		/// <para>Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.</para>
		/// </param>
		public D3D12_HEAP_PROPERTIES(D3D12_CPU_PAGE_PROPERTY cpuPageProperty, D3D12_MEMORY_POOL memoryPoolPreference, uint creationNodeMask = 1, uint nodeMask = 1)
		{
			Type = D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_CUSTOM;
			CPUPageProperty = cpuPageProperty;
			MemoryPoolPreference = memoryPoolPreference;
			CreationNodeMask = creationNodeMask;
			VisibleNodeMask = nodeMask;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_HEAP_PROPERTIES"/> struct.</summary>
		/// <param name="type">A <c>D3D12_HEAP_TYPE</c>-typed value that specifies the type of heap.</param>
		/// <param name="creationNodeMask">
		/// <para>For multi-adapter operation, this indicates the node where the resource should be created.</para>
		/// <para>Exactly one bit of this UINT must be set. See <c>Multi-adapter systems</c>.</para>
		/// <para>Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.</para>
		/// </param>
		/// <param name="visibleNodeMask">
		/// <para>For multi-adapter operation, this indicates the set of nodes where the resource is visible.</para>
		/// <para>
		/// <i>VisibleNodeMask</i> must have the same bit set that is set in <i>CreationNodeMask</i>. <i>VisibleNodeMask</i> can also have
		/// additional bits set for cross-node resources, but doing so can potentially reduce performance for resource accesses, so you
		/// should do so only when needed.
		/// </para>
		/// <para>Passing zero is equivalent to passing one, in order to simplify the usage of single-GPU adapters.</para>
		/// </param>
		public D3D12_HEAP_PROPERTIES(D3D12_HEAP_TYPE type, uint creationNodeMask = 1, uint visibleNodeMask = 1)
		{
			Type = type;
			CPUPageProperty = D3D12_CPU_PAGE_PROPERTY.D3D12_CPU_PAGE_PROPERTY_UNKNOWN;
			MemoryPoolPreference = D3D12_MEMORY_POOL.D3D12_MEMORY_POOL_UNKNOWN;
			CreationNodeMask = creationNodeMask;
			VisibleNodeMask = visibleNodeMask;
		}

		/// <summary>Gets a value indicating whether this instance is CPU accessible.</summary>
		/// <value><c>true</c> if this instance is cpu accessible; otherwise, <c>false</c>.</value>
		public readonly bool IsCPUAccessible => Type is D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_UPLOAD or D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_READBACK or
			D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_GPU_UPLOAD or D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_CUSTOM &&
			CPUPageProperty is D3D12_CPU_PAGE_PROPERTY.D3D12_CPU_PAGE_PROPERTY_WRITE_COMBINE or D3D12_CPU_PAGE_PROPERTY.D3D12_CPU_PAGE_PROPERTY_WRITE_BACK;

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_HEAP_PROPERTIES pROPERTIES && Equals(pROPERTIES);

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_HEAP_PROPERTIES other) => Type == other.Type && CPUPageProperty == other.CPUPageProperty && MemoryPoolPreference == other.MemoryPoolPreference && CreationNodeMask == other.CreationNodeMask && VisibleNodeMask == other.VisibleNodeMask;

		/// <inheritdoc/>
		public override int GetHashCode() => (Type, CPUPageProperty, MemoryPoolPreference, CreationNodeMask, VisibleNodeMask).GetHashCode();

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_HEAP_PROPERTIES left, D3D12_HEAP_PROPERTIES right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_HEAP_PROPERTIES left, D3D12_HEAP_PROPERTIES right) => !(left == right);
	}

	/// <summary>Describes a raytracing hit group state subobject that can be included in a state object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_hit_group_desc typedef struct D3D12_HIT_GROUP_DESC { LPCWSTR
	// HitGroupExport; D3D12_HIT_GROUP_TYPE Type; LPCWSTR AnyHitShaderImport; LPCWSTR ClosestHitShaderImport; LPCWSTR
	// IntersectionShaderImport; } D3D12_HIT_GROUP_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_HIT_GROUP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_HIT_GROUP_DESC
	{
		/// <summary>The name of the hit group.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string HitGroupExport;

		/// <summary>A value from the <c>D3D12_HIT_GROUP_TYPE</c> enumeration specifying the type of the hit group.</summary>
		public D3D12_HIT_GROUP_TYPE Type;

		/// <summary>Optional name of the any-hit shader associated with the hit group. This field can be used with all hit group types.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string AnyHitShaderImport;

		/// <summary>
		/// Optional name of the closest-hit shader associated with the hit group. This field can be used with all hit group types.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string ClosestHitShaderImport;

		/// <summary>
		/// Optional name of the intersection shader associated with the hit group. This field can only be used with hit groups of type
		/// procedural primitive.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string IntersectionShaderImport;
	}

	/// <summary>Describes the index buffer to view.</summary>
	/// <remarks>This structure is passed into <c>ID3D12GraphicsCommandList::IASetIndexBuffer</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_index_buffer_view typedef struct D3D12_INDEX_BUFFER_VIEW {
	// D3D12_GPU_VIRTUAL_ADDRESS BufferLocation; UINT SizeInBytes; DXGI_FORMAT Format; } D3D12_INDEX_BUFFER_VIEW;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_INDEX_BUFFER_VIEW")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct D3D12_INDEX_BUFFER_VIEW
	{
		/// <summary>The GPU virtual address of the index buffer. D3D12_GPU_VIRTUAL_ADDRESS is a typedef'd synonym of UINT64.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

		/// <summary>The size in bytes of the index buffer.</summary>
		public uint SizeInBytes;

		/// <summary>A <c>DXGI_FORMAT</c>-typed value for the index-buffer format.</summary>
		public DXGI_FORMAT Format;
	}

	/// <summary>Describes an indirect argument (an indirect parameter), for use with a command signature.</summary>
	/// <remarks>Use this structure with the <c>D3D12_COMMAND_SIGNATURE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_indirect_argument_desc typedef struct
	// D3D12_INDIRECT_ARGUMENT_DESC { D3D12_INDIRECT_ARGUMENT_TYPE Type; union { struct { UINT Slot; } VertexBuffer; struct { UINT
	// RootParameterIndex; UINT DestOffsetIn32BitValues; UINT Num32BitValuesToSet; } Constant; struct { UINT RootParameterIndex; }
	// ConstantBufferView; struct { UINT RootParameterIndex; } ShaderResourceView; struct { UINT RootParameterIndex; } UnorderedAccessView;
	// struct { UINT RootParameterIndex; UINT DestOffsetIn32BitValues; } IncrementingConstant; }; } D3D12_INDIRECT_ARGUMENT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_INDIRECT_ARGUMENT_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_INDIRECT_ARGUMENT_DESC
	{
		/// <summary>A single <c>D3D12_INDIRECT_ARGUMENT_TYPE</c> enumeration constant.</summary>
		[FieldOffset(0)]
		public D3D12_INDIRECT_ARGUMENT_TYPE Type;

		/// <summary/>
		[FieldOffset(4)]
		public VERTEXBUFFER VertexBuffer;

		/// <summary/>
		[FieldOffset(4)]
		public CONSTANT Constant;

		/// <summary/>
		[FieldOffset(4)]
		public CONSTANTBUFFERVIEW ConstantBufferView;

		/// <summary/>
		[FieldOffset(4)]
		public SHADERRESOURCEVIEW ShaderResourceView;

		/// <summary/>
		[FieldOffset(4)]
		public UNORDEREDACCESSVIEW UnorderedAccessView;

		/// <summary/>
		[FieldOffset(4)]
		public INCREMENTINGCONSTANT IncrementingConstant;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct VERTEXBUFFER
		{
			/// <summary>Specifies the slot containing the vertex buffer address.</summary>
			public uint Slot;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct CONSTANT
		{
			/// <summary>Specifies the root index of the constant.</summary>
			public uint RootParameterIndex;

			/// <summary>
			/// The offset, in 32-bit values, to set the first constant of the group. Supports multi-value constants at a given root index.
			/// Root constant entries must be sorted from smallest to largest DestOffsetIn32BitValues.
			/// </summary>
			public uint DestOffsetIn32BitValues;

			/// <summary>
			/// The number of 32-bit constants that are set at the given root index. Supports multi-value constants at a given root index.
			/// </summary>
			public uint Num32BitValuesToSet;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct CONSTANTBUFFERVIEW
		{
			/// <summary>Specifies the root index of the CBV.</summary>
			public uint RootParameterIndex;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct SHADERRESOURCEVIEW
		{
			/// <summary>Specifies the root index of the SRV.</summary>
			public uint RootParameterIndex;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct UNORDEREDACCESSVIEW
		{
			/// <summary>Specifies the root index of the UAV.</summary>
			public uint RootParameterIndex;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct INCREMENTINGCONSTANT
		{
			/// <summary/>
			public uint RootParameterIndex;

			/// <summary/>
			public uint DestOffsetIn32BitValues;
		}
	}

	/// <summary>Describes a single element for the input-assembler stage of the graphics pipeline.</summary>
	/// <remarks>
	/// This structure is a member of the <c>D3D12_INPUT_LAYOUT_DESC</c> structure. A pipeline state object contains a input-layout
	/// structure that defines one element being read from an input slot.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_input_element_desc typedef struct D3D12_INPUT_ELEMENT_DESC {
	// LPCSTR SemanticName; UINT SemanticIndex; DXGI_FORMAT Format; UINT InputSlot; UINT AlignedByteOffset; D3D12_INPUT_CLASSIFICATION
	// InputSlotClass; UINT InstanceDataStepRate; } D3D12_INPUT_ELEMENT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_INPUT_ELEMENT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_INPUT_ELEMENT_DESC(string semanticName, DXGI_FORMAT format, uint alignedByteOffset = 0,
		D3D12_INPUT_CLASSIFICATION inputSlotClass = D3D12_INPUT_CLASSIFICATION.D3D12_INPUT_CLASSIFICATION_PER_VERTEX_DATA, uint semanticIndex = 0,
		uint inputSlot = 0, uint instanceDataStepRate = 0)
	{
		/// <summary>The HLSL semantic associated with this element in a shader input-signature. See <c>HLSL Semantics</c> for more info.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string SemanticName = semanticName;

		/// <summary>
		/// The semantic index for the element. A semantic index modifies a semantic, with an integer index number. A semantic index is only
		/// needed in a case where there is more than one element with the same semantic. For example, a 4x4 matrix would have four
		/// components each with the semantic name <b>matrix</b>, however each of the four component would have different semantic indices
		/// (0, 1, 2, and 3).
		/// </summary>
		public uint SemanticIndex = semanticIndex;

		/// <summary>A <c>DXGI_FORMAT</c>-typed value that specifies the format of the element data.</summary>
		public DXGI_FORMAT Format = format;

		/// <summary>
		/// An integer value that identifies the input-assembler. For more info, see <c>Input Slots</c>. Valid values are between 0 and 15.
		/// </summary>
		public uint InputSlot = inputSlot;

		/// <summary>
		/// Optional. Offset, in bytes, to this element from the start of the vertex. Use D3D12_APPEND_ALIGNED_ELEMENT (0xffffffff) for
		/// convenience to define the current element directly after the previous one, including any packing if necessary.
		/// </summary>
		public uint AlignedByteOffset = alignedByteOffset;

		/// <summary>A value that identifies the input data class for a single input slot.</summary>
		public D3D12_INPUT_CLASSIFICATION InputSlotClass = inputSlotClass;

		/// <summary>
		/// The number of instances to draw using the same per-instance data before advancing in the buffer by one element. This value must
		/// be 0 for an element that contains per-vertex data (the slot class is set to the D3D12_INPUT_PER_VERTEX_DATA member of <c>D3D12_INPUT_CLASSIFICATION</c>).
		/// </summary>
		public uint InstanceDataStepRate = instanceDataStepRate;
	}

	/// <summary>Describes the input-buffer data for the input-assembler stage.</summary>
	/// <remarks>This structure is a member of the <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_input_layout_desc typedef struct D3D12_INPUT_LAYOUT_DESC {
	// const D3D12_INPUT_ELEMENT_DESC *pInputElementDescs; UINT NumElements; } D3D12_INPUT_LAYOUT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_INPUT_LAYOUT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_INPUT_LAYOUT_DESC
	{
		/// <summary>An array of <c>D3D12_INPUT_ELEMENT_DESC</c> structures that describe the data types of the input-assembler stage.</summary>
		[SizeDef(nameof(NumElements))]
		public ManagedArrayPointer<D3D12_INPUT_ELEMENT_DESC> pInputElementDescs;

		/// <summary>The number of input-data types in the array of input elements that the <b>pInputElementDescs</b> member points to.</summary>
		public uint NumElements;

		/// <summary>Initializes a new instance of the <see cref="D3D12_INPUT_LAYOUT_DESC"/> struct.</summary>
		/// <param name="elements">The elements.</param>
		/// <param name="memoryHandle">The memory handle allocated for the elements.</param>
		public D3D12_INPUT_LAYOUT_DESC(D3D12_INPUT_ELEMENT_DESC[] elements, out SafeAllocatedMemoryHandle memoryHandle)
		{
			NumElements = (uint)(elements?.Length ?? 0);
			pInputElementDescs = memoryHandle = NumElements > 0 ? SafeCoTaskMemHandle.CreateFromList(elements!) : SafeCoTaskMemHandle.Null;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_INPUT_LAYOUT_DESC" /> struct.</summary>
		/// <param name="numElements">The number of elements.</param>
		/// <param name="elements">The elements.</param>
		public D3D12_INPUT_LAYOUT_DESC(SizeT numElements, ManagedArrayPointer<D3D12_INPUT_ELEMENT_DESC> elements)
		{
			NumElements = numElements;
			pInputElementDescs = elements;
		}
	}

	/// <summary>Defines a local root signature state subobject that will be used with associated shaders.</summary>
	/// <remarks>
	/// <para>
	/// The presence of this subobject in a state object is optional. The combination of global and/or local root signatures associated with
	/// any given shader function must define all resource bindings declared by the shader (with no overlap across global and local root signatures).
	/// </para>
	/// <para>
	/// If any given function in a call graph (not counting calls across shader tables) is associated with a particular local root
	/// signature, any other functions in the graph must either be associated with the same local root signature or none, and the shader
	/// entry (the root of the call graph) must be associated with the local root signature. This is due to the fact that the set of code
	/// reachable from a given shader entry gets invoked from a shader identifier in a shader record, where a single set of local root
	/// arguments apply. Of course different shaders can use different local root signatures (or none), as their shader identifiers will be
	/// in different shader records.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_local_root_signature typedef struct
	// D3D12_LOCAL_ROOT_SIGNATURE { ID3D12RootSignature *pLocalRootSignature; } D3D12_LOCAL_ROOT_SIGNATURE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_LOCAL_ROOT_SIGNATURE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_LOCAL_ROOT_SIGNATURE
	{
		/// <summary>The root signature that will function as a local root signature. A state object holds a reference to this signature.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12RootSignature pLocalRootSignature;
	}

	/// <summary>Describes the destination of a memory copy operation.</summary>
	/// <remarks>This structure is used by a number of helper methods, refer to <c>Helper Structures and Functions for D3D12</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_memcpy_dest typedef struct D3D12_MEMCPY_DEST { void *pData;
	// SIZE_T RowPitch; SIZE_T SlicePitch; } D3D12_MEMCPY_DEST;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_MEMCPY_DEST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_MEMCPY_DEST
	{
		/// <summary>A pointer to a memory block that receives the copied data.</summary>
		public IntPtr pData;

		/// <summary>The row pitch, or width, or physical size, in bytes, of the subresource data.</summary>
		public SizeT RowPitch;

		/// <summary>The slice pitch, or width, or physical size, in bytes, of the subresource data.</summary>
		public SizeT SlicePitch;
	}

	/// <summary>Describes a meta command.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_meta_command_desc typedef struct D3D12_META_COMMAND_DESC {
	// GUID Id; LPCWSTR Name; D3D12_GRAPHICS_STATES InitializationDirtyState; D3D12_GRAPHICS_STATES ExecutionDirtyState; } D3D12_META_COMMAND_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_META_COMMAND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_META_COMMAND_DESC
	{
		/// <summary>
		/// <para>Type: <b><c>GUID</c></b></para>
		/// <para>A <c>GUID</c> uniquely identifying the meta command.</para>
		/// </summary>
		public Guid Id;

		/// <summary>
		/// <para>Type: <b><c>LPCWSTR</c></b></para>
		/// <para>The meta command name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		/// <summary>
		/// <para>Type: <b><c>D3D12_GRAPHICS_STATES</c></b></para>
		/// <para>
		/// Declares the command list states that are modified by the call to initialize the meta command. If all state bits are set, then
		/// that's equivalent to calling <c>ID3D12GraphicsCommandList::ClearState</c>.
		/// </para>
		/// </summary>
		public D3D12_GRAPHICS_STATES InitializationDirtyState;

		/// <summary>
		/// <para>Type: <b><c>D3D12_GRAPHICS_STATES</c></b></para>
		/// <para>
		/// Declares the command list states that are modified by the call to execute the meta command. If all state bits are set, then
		/// that's equivalent to calling <c>ID3D12GraphicsCommandList::ClearState</c>.
		/// </para>
		/// </summary>
		public D3D12_GRAPHICS_STATES ExecutionDirtyState;
	}

	/// <summary>Describes a parameter to a meta command.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_meta_command_parameter_desc typedef struct
	// D3D12_META_COMMAND_PARAMETER_DESC { LPCWSTR Name; D3D12_META_COMMAND_PARAMETER_TYPE Type; D3D12_META_COMMAND_PARAMETER_FLAGS Flags;
	// D3D12_RESOURCE_STATES RequiredResourceState; UINT StructureOffset; } D3D12_META_COMMAND_PARAMETER_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_META_COMMAND_PARAMETER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_META_COMMAND_PARAMETER_DESC
	{
		/// <summary>
		/// <para>Type: <b><c>LPCWSTR</c></b></para>
		/// <para>The parameter name.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		/// <summary>
		/// <para>Type: <b><c>D3D12_META_COMMAND_PARAMETER_TYPE</c></b></para>
		/// <para>A <c>D3D12_META_COMMAND_PARAMETER_TYPE</c> specifying the parameter type.</para>
		/// </summary>
		public D3D12_META_COMMAND_PARAMETER_TYPE Type;

		/// <summary>
		/// <para>Type: <b><c>D3D12_META_COMMAND_PARAMETER_FLAGS</c></b></para>
		/// <para>A <c>D3D12_META_COMMAND_PARAMETER_FLAGS</c> specifying the parameter flags.</para>
		/// </summary>
		public D3D12_META_COMMAND_PARAMETER_FLAGS Flags;

		/// <summary>
		/// <para>Type: <b><c>D3D12_RESOURCE_STATES</c></b></para>
		/// <para>A <c>D3D12_RESOURCE_STATES</c> specifying the expected state of a resource parameter.</para>
		/// </summary>
		public D3D12_RESOURCE_STATES RequiredResourceState;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The 4-byte aligned offset for this parameter, within the structure containing the parameter values, which you pass when
		/// creating/initializing/executing the meta command, as appropriate.
		/// </para>
		/// </summary>
		public uint StructureOffset;
	}

	/// <summary>Describes the dimensions of a mip region.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_mip_region typedef struct D3D12_MIP_REGION { UINT Width;
	// UINT Height; UINT Depth; } D3D12_MIP_REGION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_MIP_REGION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_MIP_REGION
	{
		/// <summary>The width of the mip region.</summary>
		public uint Width;

		/// <summary>The height of the mip region.</summary>
		public uint Height;

		/// <summary>The depth of the mip region.</summary>
		public uint Depth;
	}

	/// <summary>A state subobject that identifies the GPU nodes to which the state object applies.</summary>
	/// <remarks>
	/// <para>
	/// This subobject is optional. In its absence, the state object applies to all available nodes. If a node mask subobject has been
	/// associated with any part of a state object, a node mask association must be made to all exports in a state object (including
	/// imported collections) and all node mask subobjects that are referenced must have matching content.
	/// </para>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// On some versions of the DirectX Runtime, specifying a node via <b>D3D12_NODE_MASK</b> in a <c><b>D3D12_STATE_SUBOBJECT</b></c> with
	/// type <c><b>D3D12_STATE_SUBOBJECT_TYPE_NODE_MASK</b></c>, the runtime will incorrectly handle a node mask value of <c>0</c>, which
	/// should use node #1, which will lead to errors when attempting to use the state object later. Specify an explicit node value of 1, or
	/// omit the <b>D3D12_NODE_MASK</b> subobject to avoid this issue.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_node_mask typedef struct D3D12_NODE_MASK { UINT NodeMask; } D3D12_NODE_MASK;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_NODE_MASK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_NODE_MASK
	{
		/// <summary>The node mask.</summary>
		public uint NodeMask;
	}

	/// <summary>Describes the tile structure of a tiled resource with mipmaps.</summary>
	/// <remarks>This structure is used by the <c>GetResourceTiling</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_packed_mip_info typedef struct D3D12_PACKED_MIP_INFO { UINT8
	// NumStandardMips; UINT8 NumPackedMips; UINT NumTilesForPackedMips; UINT StartTileIndexInOverallResource; } D3D12_PACKED_MIP_INFO;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_PACKED_MIP_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_PACKED_MIP_INFO(byte numStandardMips, byte numPackedMips, uint numTilesForPackedMips, uint startTileIndexInOverallResource)
	{
		/// <summary>The number of standard mipmaps in the tiled resource.</summary>
		public byte NumStandardMips = numStandardMips;

		/// <summary>
		/// <para>The number of packed mipmaps in the tiled resource.</para>
		/// <para>
		/// This number starts from the least detailed mipmap (either sharing tiles or using non standard tile layout). This number is 0 if
		/// no such packing is in the resource. For array surfaces, this value is the number of mipmaps that are packed for a given array
		/// slice where each array slice repeats the same packing.
		/// </para>
		/// <para>
		/// On Tier_2 tiled resources hardware, mipmaps that fill at least one standard shaped tile in all dimensions are not allowed to be
		/// included in the set of packed mipmaps. On Tier_1 hardware, mipmaps that are an integer multiple of one standard shaped tile in
		/// all dimensions are not allowed to be included in the set of packed mipmaps. Mipmaps with at least one dimension less than the
		/// standard tile shape may or may not be packed. When a given mipmap needs to be packed, all coarser mipmaps for a given array
		/// slice are considered packed as well.
		/// </para>
		/// </summary>
		public byte NumPackedMips = numPackedMips;

		/// <summary>
		/// <para>The number of tiles for the packed mipmaps in the tiled resource.</para>
		/// <para>
		/// If there is no packing, this value is meaningless and is set to 0. Otherwise, it is set to the number of tiles that are needed
		/// to represent the set of packed mipmaps. The pixel layout within the packed mipmaps is hardware specific. If apps define only
		/// partial mappings for the set of tiles in packed mipmaps, read and write behavior is vendor specific and undefined. For arrays,
		/// this value is only the count of packed mipmaps within the subresources for each array slice.
		/// </para>
		/// </summary>
		public uint NumTilesForPackedMips = numTilesForPackedMips;

		/// <summary>
		/// <para>
		/// The offset of the first packed tile for the resource in the overall range of tiles. If <b>NumPackedMips</b> is 0, this value is
		/// meaningless and is 0. Otherwise, it is the offset of the first packed tile for the resource in the overall range of tiles for
		/// the resource. A value of 0 for <b>StartTileIndexInOverallResource</b> means the entire resource is packed. For array surfaces,
		/// this is the offset for the tiles that contain the packed mipmaps for the first array slice. Packed mipmaps for each array slice
		/// in arrayed surfaces are at this offset past the beginning of the tiles for each array slice.
		/// </para>
		/// <para>
		/// <b>Note</b>  The number of overall tiles, packed or not, for a given array slice is simply the total number of tiles for the
		/// resource divided by the resource's array size, so it is easy to locate the range of tiles for any given array slice, out of
		/// which <b>StartTileIndexInOverallResource</b> identifies which of those are packed.
		/// </para>
		/// <para></para>
		/// </summary>
		public uint StartTileIndexInOverallResource = startTileIndexInOverallResource;
	}

	/// <summary>Describes a pipeline state stream.</summary>
	/// <remarks>
	/// <para>Use this structure with the <b><c>ID3D12Device2::CreatePipelineState</c></b> method to create pipeline state objects.</para>
	/// <para>
	/// The format of the provided stream should consist of an alternating set of <b><c>D3D12_PIPELINE_STATE_SUBOBJECT_TYPE</c></b>, and the
	/// corresponding subobject types for them (for example, <b>D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER</b> pairs with
	/// <b><c>D3D12_RASTERIZER_DESC</c></b>. In terms of alignment, the D3D12 runtime expects subobjects to be individual struct pairs of
	/// enum-struct, rather than a continuous set of fields. It also expects them to be aligned to the natural word alignment of the system.
	/// This can be achieved either using <c>alignas(void*)</c>, or making a <c>union</c> of the enum + subobject and a <c>void*</c>.
	/// </para>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// It isn't sufficient to simply union the <b>D3D12_PIPELINE_STATE_SUBOBJECT_TYPE</b> with a <b>void*</b>, because this will result in
	/// certain subobjects being misaligned. For example, <b>D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_PRIMITIVE_TOPOLOGY</b> is followed by a
	/// <b><c>D3D12_PRIMITIVE_TOPOLOGY_TYPE</c></b> enum. If the subobject type is unioned with a <b>void*</b>, then there will be
	/// additional padding between these 2 members, resulting in corruption of the stream. Because of this, you should union the entire
	/// subobject struct with a <b>void*</b>, when <c>alignas</c> is not available
	/// </para>
	/// </para>
	/// <para>An example of a suitable subobject for use with <b><c>D3D12_RASTERIZER_DESC</c></b> is shown here:</para>
	/// <para>
	/// <c>struct alignas(void*) StreamingRasterizerDesc { private: D3D12_PIPELINE_STATE_SUBOBJECT_TYPE Type =
	/// D3D12_PIPELINE_STATE_SUBOBJECT_TYPE_RASTERIZER; public: D3D12_RASTERIZER_DESC Desc; }</c>
	/// </para>
	/// <para>
	/// The runtime will determine the type of a pipeline stream (valid types being <b>COMPUTE</b>, <b>GRAPHICS</b>, and <b>MESH</b>), by
	/// which subobject type, out of <b>VS</b> (vertex shader), <b>CS</b> (compute shader), and <b>MS</b> (mesh shader), is found. If the
	/// runtime finds none of these shaders, it will fail pipeline creation. If it finds multiple of these shaders which are not null, it
	/// will also fail. This means it is legal to have both, for example, a <b>CS</b> and <b>VS</b> in your stream object, provided only one
	/// has a non-null pointer for the shader bytecode for any given call to <b><c>ID3D12Device2::CreatePipelineState</c></b>. Subobject
	/// types irrelevant to the pipeline (e.g a compute shader subobject in a graphics stream) will be ignored. If a subobject is not
	/// provided (excluding the above required subobjects), the runtime will provide a default value for it.
	/// </para>
	/// <para>
	/// Consider using the <c>d3dx12.h</c> extensions for C++, which provide a set of helper structs for all pipeline subobjects (for
	/// example, the above struct is very similar to <c>CD3DX12_PIPELINE_STATE_STREAM_RASTERIZER</c>). This header can be found under the
	/// <b><c>DirectX-Headers</c></b> repo on github.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_pipeline_state_stream_desc typedef struct
	// D3D12_PIPELINE_STATE_STREAM_DESC { SIZE_T SizeInBytes; void *pPipelineStateSubobjectStream; } D3D12_PIPELINE_STATE_STREAM_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_PIPELINE_STATE_STREAM_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_PIPELINE_STATE_STREAM_DESC
	{
		/// <summary>Specifies the size of the opaque data structure pointed to by the pPipelineStateSubobjectStream member, in bytes.</summary>
		public SizeT SizeInBytes;

		/// <summary>Specifies the address of a data structure that describes as a bytestream an arbitrary pipeline state subobject.</summary>
		public IntPtr pPipelineStateSubobjectStream;

		/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="D3D12.D3D12_PIPELINE_STATE_STREAM_DESC"/>.</summary>
		/// <param name="h">The <see cref="SafeAllocatedMemoryHandle"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D3D12_PIPELINE_STATE_STREAM_DESC(SafeAllocatedMemoryHandle h) => new() { SizeInBytes = h.Size, pPipelineStateSubobjectStream = h.DangerousGetHandle() };
	}

	/// <summary>Describes the footprint of a placed subresource, including the offset and the D3D12_SUBRESOURCE_FOOTPRINT.</summary>
	/// <remarks>
	/// <para>This structure is used in the <c>D3D12_TEXTURE_COPY_LOCATION</c> structure, and by <c>ID3D12Device::GetCopyableFootprints</c>.</para>
	/// <para>
	/// All the data referenced by the footprint structure must fit within the bounds of the parent resource. If you use
	/// <c>GetCopyableFootprints</c> to fill out the structure, the <i>pTotalBytes</i> output field indicates the required size of the resource.
	/// </para>
	/// <para>This structure is also used a number of helper functions (refer to <c>Helper Structures and Functions for D3D12</c>).</para>
	/// <para>When copying textures, use this structure along with <c>D3D12_TEXTURE_COPY_LOCATION</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_placed_subresource_footprint typedef struct
	// D3D12_PLACED_SUBRESOURCE_FOOTPRINT { UINT64 Offset; D3D12_SUBRESOURCE_FOOTPRINT Footprint; } D3D12_PLACED_SUBRESOURCE_FOOTPRINT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_PLACED_SUBRESOURCE_FOOTPRINT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_PLACED_SUBRESOURCE_FOOTPRINT
	{
		/// <summary>
		/// The offset of the subresource within the parent resource, in bytes. The offset between the start of the parent resource and this subresource.
		/// </summary>
		public ulong Offset;

		/// <summary>The format, width, height, depth, and row-pitch of the subresource, as a <c>D3D12_SUBRESOURCE_FOOTPRINT</c> structure.</summary>
		public D3D12_SUBRESOURCE_FOOTPRINT Footprint;
	}

	/// <summary>Describes flags for a protected resource session, per adapter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_protected_resource_session_desc typedef struct
	// D3D12_PROTECTED_RESOURCE_SESSION_DESC { UINT NodeMask; D3D12_PROTECTED_RESOURCE_SESSION_FLAGS Flags; } D3D12_PROTECTED_RESOURCE_SESSION_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_PROTECTED_RESOURCE_SESSION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_PROTECTED_RESOURCE_SESSION_DESC
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The node mask. For single GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node
		/// (the device's physical adapter) to which the protected session applies. Each bit in the mask corresponds to a single node. Only
		/// 1 bit may be set.
		/// </para>
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// <para>Type: <b><c>D3D12_PROTECTED_RESOURCE_SESSION_FLAGS</c></b></para>
		/// <para>Specifies the supported crypto sessions options.</para>
		/// </summary>
		public D3D12_PROTECTED_RESOURCE_SESSION_FLAGS Flags;
	}

	/// <summary>Describes flags and protection type for a protected resource session, per adapter.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_protected_resource_session_desc1 typedef struct
	// D3D12_PROTECTED_RESOURCE_SESSION_DESC1 { UINT NodeMask; D3D12_PROTECTED_RESOURCE_SESSION_FLAGS Flags; GUID ProtectionType; } D3D12_PROTECTED_RESOURCE_SESSION_DESC1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_PROTECTED_RESOURCE_SESSION_DESC1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_PROTECTED_RESOURCE_SESSION_DESC1
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The node mask. For single GPU operation, set this to zero. If there are multiple GPU nodes, then set a bit to identify the node
		/// (the device's physical adapter) to which the protected session applies. Each bit in the mask corresponds to a single node. Only
		/// 1 bit may be set.
		/// </para>
		/// </summary>
		public uint NodeMask;

		/// <summary>
		/// <para>Type: <b><c>D3D12_PROTECTED_RESOURCE_SESSION_FLAGS</c></b></para>
		/// <para>Specifies the supported crypto sessions options.</para>
		/// </summary>
		public D3D12_PROTECTED_RESOURCE_SESSION_FLAGS Flags;

		/// <summary>
		/// <para>Type: <b><c>GUID</c></b></para>
		/// <para>The GUID that represents the protection type. Microsoft defines <b>D3D12_PROTECTED_RESOURCES_SESSION_HARDWARE_PROTECTED</b>.</para>
		/// <para>Using the <b>D3D12_PROTECTED_RESOURCES_SESSION_HARDWARE_PROTECTED</b> GUID is equivalent to calling <c><b>ID3D12Device4::CreateProtectedResourceSession</b></c>.</para>
		/// </summary>
		public Guid ProtectionType;
	}

	/// <summary>Query information about graphics-pipeline activity in between calls to <c>BeginQuery</c> and <c>EndQuery</c>.</summary>
	/// <remarks>Use this structure with <c>D3D12_QUERY_HEAP_TYPE</c> and <c>CreateQueryHeap</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_query_data_pipeline_statistics typedef struct
	// D3D12_QUERY_DATA_PIPELINE_STATISTICS { UINT64 IAVertices; UINT64 IAPrimitives; UINT64 VSInvocations; UINT64 GSInvocations; UINT64
	// GSPrimitives; UINT64 CInvocations; UINT64 CPrimitives; UINT64 PSInvocations; UINT64 HSInvocations; UINT64 DSInvocations; UINT64
	// CSInvocations; } D3D12_QUERY_DATA_PIPELINE_STATISTICS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_QUERY_DATA_PIPELINE_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_QUERY_DATA_PIPELINE_STATISTICS
	{
		/// <summary>Number of vertices read by input assembler.</summary>
		public ulong IAVertices;

		/// <summary>
		/// Number of primitives read by the input assembler. This number can be different depending on the primitive topology used. For
		/// example, a triangle strip with 6 vertices will produce 4 triangles, however a triangle list with 6 vertices will produce 2 triangles.
		/// </summary>
		public ulong IAPrimitives;

		/// <summary>Specifies the number of vertex shader invocations. Direct3D invokes the vertex shader once per vertex.</summary>
		public ulong VSInvocations;

		/// <summary>
		/// Specifies the number of geometry shader invocations. When the geometry shader is set to NULL, this statistic may or may not
		/// increment depending on the graphics adapter.
		/// </summary>
		public ulong GSInvocations;

		/// <summary>Specifies the number of geometry shader output primitives.</summary>
		public ulong GSPrimitives;

		/// <summary>Number of primitives that were sent to the rasterizer. When the rasterizer is disabled, this will not increment.</summary>
		public ulong CInvocations;

		/// <summary>
		/// Number of primitives that were rendered. This may be larger or smaller than CInvocations because after a primitive is clipped
		/// sometimes it is either broken up into more than one primitive or completely culled.
		/// </summary>
		public ulong CPrimitives;

		/// <summary>Specifies the number of pixel shader invocations.</summary>
		public ulong PSInvocations;

		/// <summary>Specifies the number of hull shader invocations.</summary>
		public ulong HSInvocations;

		/// <summary>Specifies the number of domain shader invocations.</summary>
		public ulong DSInvocations;

		/// <summary>Specifies the number of compute shader invocations.</summary>
		public ulong CSInvocations;
	}

	/// <summary>
	/// <para><c>IAVertices</c></para>
	/// <para><c>IAPrimitives</c></para>
	/// <para><c>VSInvocations</c></para>
	/// <para><c>GSInvocations</c></para>
	/// <para><c>GSPrimitives</c></para>
	/// <para><c>CInvocations</c></para>
	/// <para><c>CPrimitives</c></para>
	/// <para><c>PSInvocations</c></para>
	/// <para><c>HSInvocations</c></para>
	/// <para><c>DSInvocations</c></para>
	/// <para><c>CSInvocations</c></para>
	/// <para><c>ASInvocations</c></para>
	/// <para><c>MSInvocations</c></para>
	/// <para><c>MSPrimitives</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_query_data_pipeline_statistics1 typedef struct
	// D3D12_QUERY_DATA_PIPELINE_STATISTICS1 { UINT64 IAVertices; UINT64 IAPrimitives; UINT64 VSInvocations; UINT64 GSInvocations; UINT64
	// GSPrimitives; UINT64 CInvocations; UINT64 CPrimitives; UINT64 PSInvocations; UINT64 HSInvocations; UINT64 DSInvocations; UINT64
	// CSInvocations; UINT64 ASInvocations; UINT64 MSInvocations; UINT64 MSPrimitives; } D3D12_QUERY_DATA_PIPELINE_STATISTICS1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_QUERY_DATA_PIPELINE_STATISTICS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_QUERY_DATA_PIPELINE_STATISTICS1
	{
		/// <summary/>
		public ulong IAVertices;

		/// <summary/>
		public ulong IAPrimitives;

		/// <summary/>
		public ulong VSInvocations;

		/// <summary/>
		public ulong GSInvocations;

		/// <summary/>
		public ulong GSPrimitives;

		/// <summary/>
		public ulong CInvocations;

		/// <summary/>
		public ulong CPrimitives;

		/// <summary/>
		public ulong PSInvocations;

		/// <summary/>
		public ulong HSInvocations;

		/// <summary/>
		public ulong DSInvocations;

		/// <summary/>
		public ulong CSInvocations;

		/// <summary/>
		public ulong ASInvocations;

		/// <summary/>
		public ulong MSInvocations;

		/// <summary/>
		public ulong MSPrimitives;
	}

	/// <summary>Describes query data about the amount of data streamed out to the stream-output buffers.</summary>
	/// <remarks>Use this structure with <c>D3D12_QUERY_HEAP_TYPE</c> and <c>CreateQueryHeap</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_query_data_so_statistics typedef struct
	// D3D12_QUERY_DATA_SO_STATISTICS { UINT64 NumPrimitivesWritten; UINT64 PrimitivesStorageNeeded; } D3D12_QUERY_DATA_SO_STATISTICS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_QUERY_DATA_SO_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_QUERY_DATA_SO_STATISTICS
	{
		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The number of primitives (that is, points, lines, and triangles) that were actually written to the stream output resource.</para>
		/// </summary>
		public ulong NumPrimitivesWritten;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// If the stream output resource is large enough, then PrimitivesStorageNeeded represents the total number of primitives written to
		/// the stream output resource. Otherwise, it represents the total number of primitives that would have been written to the
		/// stream-output resource had there been enough space for them all.
		/// </para>
		/// </summary>
		public ulong PrimitivesStorageNeeded;
	}

	/// <summary>Describes the purpose of a query heap. A query heap contains an array of individual queries.</summary>
	/// <remarks>Use this structure with <c>CreateQueryHeap</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_query_heap_desc typedef struct D3D12_QUERY_HEAP_DESC {
	// D3D12_QUERY_HEAP_TYPE Type; UINT Count; UINT NodeMask; } D3D12_QUERY_HEAP_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_QUERY_HEAP_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_QUERY_HEAP_DESC
	{
		/// <summary>Specifies one member of <c>D3D12_QUERY_HEAP_TYPE</c>.</summary>
		public D3D12_QUERY_HEAP_TYPE Type;

		/// <summary>Specifies the number of queries the heap should contain.</summary>
		public uint Count;

		/// <summary>
		/// For single GPU operation, set this to zero. If there are multiple GPU nodes, set a bit to identify the node (the device's
		/// physical adapter) to which the query heap applies. Each bit in the mask corresponds to a single node. Only 1 bit must be set.
		/// Refer to <c>Multi-adapter systems</c>.
		/// </summary>
		public uint NodeMask;
	}

	/// <summary>Describes a memory range.</summary>
	/// <remarks>
	/// <para>
	/// <b>End</b> is one-past-the-end. When <b>Begin</b> equals <b>End</b>, the range is empty. The size of the range is ( <b>End</b> - <b>Begin</b>).
	/// </para>
	/// <para>This structure is used by the <c>Map</c> and <c>Unmap</c> methods.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_range typedef struct D3D12_RANGE { SIZE_T Begin; SIZE_T End;
	// } D3D12_RANGE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RANGE(SizeT begin, SizeT end)
	{
		/// <summary>The offset, in bytes, denoting the beginning of a memory range.</summary>
		public SizeT Begin = begin;

		/// <summary>The offset, in bytes, denoting the end of a memory range. <b>End</b> is one-past-the-end.</summary>
		public SizeT End = end;
	}

	/// <summary>Describes a memory range in a 64-bit address space.</summary>
	/// <remarks>
	/// <para>
	/// <b>End</b> is one-past-the-end. When <b>Begin</b> equals <b>End</b>, the range is empty. The size of the range is ( <b>End</b> - <b>Begin</b>).
	/// </para>
	/// <para>This structure is used by the <c>D3D12_SUBRESOURCE_RANGE_UINT64</c> structure.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_range_uint64 typedef struct D3D12_RANGE_UINT64 { UINT64
	// Begin; UINT64 End; } D3D12_RANGE_UINT64;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RANGE_UINT64")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RANGE_UINT64(ulong begin, ulong end)
	{
		/// <summary>The offset, in bytes, denoting the beginning of a memory range.</summary>
		public ulong Begin = begin;

		/// <summary>The offset, in bytes, denoting the end of a memory range. <b>End</b> is one-past-the-end.</summary>
		public ulong End = end;
	}

	/// <summary>Describes rasterizer state.</summary>
	/// <remarks>
	/// <para>A <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> contains a rasterizer-state structure.</para>
	/// <para>Rasterizer state defines the behavior of the rasterizer stage.</para>
	/// <para>If you do not specify some rasterizer state, the Direct3D runtime uses the following default values for rasterizer state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description><b>FillMode</b></description>
	/// <description>D3D12_FILL_MODE_SOLID</description>
	/// </item>
	/// <item>
	/// <description><b>CullMode</b></description>
	/// <description>D3D12_CULL_MODE_BACK</description>
	/// </item>
	/// <item>
	/// <description><b>FrontCounterClockwise</b></description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description><b>DepthBias</b></description>
	/// <description>0</description>
	/// </item>
	/// <item>
	/// <description><b>DepthBiasClamp</b></description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description><b>SlopeScaledDepthBias</b></description>
	/// <description>0.0f</description>
	/// </item>
	/// <item>
	/// <description><b>DepthClipEnable</b></description>
	/// <description><b>TRUE</b></description>
	/// </item>
	/// <item>
	/// <description><b>MultisampleEnable</b></description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description><b>AntialiasedLineEnable</b></description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description><b>ForcedSampleCount</b></description>
	/// <description>0</description>
	/// </item>
	/// <item>
	/// <description><b>ConservativeRaster</b></description>
	/// <description><b>D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF</b></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// <b>Note</b>  For <c>feature levels</c> 9.1, 9.2, 9.3, and 10.0, if you set <b>MultisampleEnable</b> to <b>FALSE</b>, the runtime
	/// renders all points, lines, and triangles without anti-aliasing even for render targets with a sample count greater than 1. For
	/// feature levels 10.1 and higher, the setting of <b>MultisampleEnable</b> has no effect on points and triangles with regard to MSAA
	/// and impacts only the selection of the line-rendering algorithm as shown in this table:
	/// </para>
	/// <para></para>
	/// <list type="table">
	/// <listheader>
	/// <description>Line-rendering algorithm</description>
	/// <description><b>MultisampleEnable</b></description>
	/// <description><b>AntialiasedLineEnable</b></description>
	/// </listheader>
	/// <item>
	/// <description>Aliased</description>
	/// <description><b>FALSE</b></description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description>Alpha antialiased</description>
	/// <description><b>FALSE</b></description>
	/// <description><b>TRUE</b></description>
	/// </item>
	/// <item>
	/// <description>Quadrilateral</description>
	/// <description><b>TRUE</b></description>
	/// <description><b>FALSE</b></description>
	/// </item>
	/// <item>
	/// <description>Quadrilateral</description>
	/// <description><b>TRUE</b></description>
	/// <description><b>TRUE</b></description>
	/// </item>
	/// </list>
	/// <para></para>
	/// <para>
	/// The settings of the <b>MultisampleEnable</b> and <b>AntialiasedLineEnable</b> members apply only to multisample antialiasing (MSAA)
	/// render targets (that is, render targets with sample counts greater than 1). Because of the differences in <c>feature-level</c>
	/// behavior and as long as you aren’t performing any line drawing or don’t mind that lines render as quadrilaterals, we recommend that
	/// you always set <b>MultisampleEnable</b> to <b>TRUE</b> whenever you render on MSAA render targets.
	/// </para>
	/// </remarks>
	/// <remarks>Initializes a new instance of the <see cref="D3D12_RASTERIZER_DESC"/> struct.</remarks>
	/// <param name="fillMode">A <c>D3D12_FILL_MODE</c>-typed value that specifies the fill mode to use when rendering.</param>
	/// <param name="cullMode">
	/// A <c>D3D12_CULL_MODE</c>-typed value that specifies that triangles facing the specified direction are not drawn.
	/// </param>
	/// <param name="frontCounterClockwise">
	/// Determines if a triangle is front- or back-facing. If this member is <b>TRUE</b>, a triangle will be considered front-facing if
	/// its vertices are counter-clockwise on the render target and considered back-facing if they are clockwise. If this parameter is
	/// <b>FALSE</b>, the opposite is true.
	/// </param>
	/// <param name="depthBias">Depth value added to a given pixel. For info about depth bias, see <c>Depth Bias</c>.</param>
	/// <param name="depthBiasClamp">Maximum depth bias of a pixel. For info about depth bias, see <c>Depth Bias</c>.</param>
	/// <param name="slopeScaledDepthBias">Scalar on a given pixel's slope. For info about depth bias, see <c>Depth Bias</c>.</param>
	/// <param name="depthClipEnable">Specifies whether to enable clipping based on distance.</param>
	/// <param name="multisampleEnable">
	/// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render
	/// targets. Set to <b>TRUE</b> to use the quadrilateral line anti-aliasing algorithm and to <b>FALSE</b> to use the alpha line
	/// anti-aliasing algorithm. For more info about this member, see Remarks.
	/// </param>
	/// <param name="antialiasedLineEnable">
	/// Specifies whether to enable line antialiasing; only applies if doing line drawing and <b>MultisampleEnable</b> is <b>FALSE</b>.
	/// For more info about this member, see Remarks.
	/// </param>
	/// <param name="forcedSampleCount">
	/// The sample count that is forced while UAV rendering or rasterizing. Valid values are 0, 1, 4, 8, and optionally 16. 0 indicates
	/// that the sample count is not forced.
	/// </param>
	/// <param name="conservativeRaster">
	/// A <c>D3D12_CONSERVATIVE_RASTERIZATION_MODE</c>-typed value that identifies whether conservative rasterization is on or off.
	/// </param>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_rasterizer_desc typedef struct D3D12_RASTERIZER_DESC {
	// D3D12_FILL_MODE FillMode; D3D12_CULL_MODE CullMode; BOOL FrontCounterClockwise; INT DepthBias; FLOAT DepthBiasClamp; FLOAT
	// SlopeScaledDepthBias; BOOL DepthClipEnable; BOOL MultisampleEnable; BOOL AntialiasedLineEnable; UINT ForcedSampleCount;
	// D3D12_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster; } D3D12_RASTERIZER_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RASTERIZER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RASTERIZER_DESC(D3D12.D3D12_FILL_MODE fillMode, D3D12.D3D12_CULL_MODE cullMode, bool frontCounterClockwise, int depthBias,
		float depthBiasClamp, float slopeScaledDepthBias, bool depthClipEnable, bool multisampleEnable,
		bool antialiasedLineEnable, uint forcedSampleCount, D3D12.D3D12_CONSERVATIVE_RASTERIZATION_MODE conservativeRaster)
	{
		/// <summary>A <c>D3D12_FILL_MODE</c>-typed value that specifies the fill mode to use when rendering.</summary>
		public D3D12_FILL_MODE FillMode = fillMode;

		/// <summary>A <c>D3D12_CULL_MODE</c>-typed value that specifies that triangles facing the specified direction are not drawn.</summary>
		public D3D12_CULL_MODE CullMode = cullMode;

		/// <summary>
		/// Determines if a triangle is front- or back-facing. If this member is <b>TRUE</b>, a triangle will be considered front-facing if
		/// its vertices are counter-clockwise on the render target and considered back-facing if they are clockwise. If this parameter is
		/// <b>FALSE</b>, the opposite is true.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool FrontCounterClockwise = frontCounterClockwise;

		/// <summary>Depth value added to a given pixel. For info about depth bias, see <c>Depth Bias</c>.</summary>
		public int DepthBias = depthBias;

		/// <summary>Maximum depth bias of a pixel. For info about depth bias, see <c>Depth Bias</c>.</summary>
		public float DepthBiasClamp = depthBiasClamp;

		/// <summary>Scalar on a given pixel's slope. For info about depth bias, see <c>Depth Bias</c>.</summary>
		public float SlopeScaledDepthBias = slopeScaledDepthBias;

		/// <summary>
		/// <para>Specifies whether to enable clipping based on distance.</para>
		/// <para>
		/// The hardware always performs x and y clipping of rasterized coordinates. When <b>DepthClipEnable</b> is set to the default–
		/// <b>TRUE</b>, the hardware also clips the z value (that is, the hardware performs the last step of the following algorithm).
		/// </para>
		/// <code language="none">
		///0 &lt; w<br />-w &lt;= x &lt;= w (or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)<br />-w &lt;= y &lt;= w (or arbitrarily wider range if implementation uses a guard band to reduce clipping burden)<br />0 &lt;= z &lt;= w
		/// </code>
		/// <para>
		/// When you set <b>DepthClipEnable</b> to <b>FALSE</b>, the hardware skips the z clipping (that is, the last step in the preceding
		/// algorithm). However, the hardware still performs the "0 &lt; w" clipping. When z clipping is disabled, improper depth ordering
		/// at the pixel level might result. However, when z clipping is disabled, stencil shadow implementations are simplified. In other
		/// words, you can avoid complex special-case handling for geometry that goes beyond the back clipping plane.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool DepthClipEnable = depthClipEnable;

		/// <summary>
		/// Specifies whether to use the quadrilateral or alpha line anti-aliasing algorithm on multisample antialiasing (MSAA) render
		/// targets. Set to <b>TRUE</b> to use the quadrilateral line anti-aliasing algorithm and to <b>FALSE</b> to use the alpha line
		/// anti-aliasing algorithm. For more info about this member, see Remarks.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool MultisampleEnable = multisampleEnable;

		/// <summary>
		/// Specifies whether to enable line antialiasing; only applies if doing line drawing and <b>MultisampleEnable</b> is <b>FALSE</b>.
		/// For more info about this member, see Remarks.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool AntialiasedLineEnable = antialiasedLineEnable;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// The sample count that is forced while UAV rendering or rasterizing. Valid values are 0, 1, 4, 8, and optionally 16. 0 indicates
		/// that the sample count is not forced.
		/// </para>
		/// <note>If you want to render with <b>ForcedSampleCount</b> set to 1 or greater, you must follow these guidelines: Otherwise,
		/// rendering behavior is undefined.</note>
		/// </summary>
		public uint ForcedSampleCount = forcedSampleCount;

		/// <summary>
		/// A <c>D3D12_CONSERVATIVE_RASTERIZATION_MODE</c>-typed value that identifies whether conservative rasterization is on or off.
		/// </summary>
		public D3D12_CONSERVATIVE_RASTERIZATION_MODE ConservativeRaster = conservativeRaster;

		/// <summary>Initializes a new instance of the <see cref="D3D12_RASTERIZER_DESC"/> struct with standard (not default) values.</summary>
		public D3D12_RASTERIZER_DESC() :
			this(D3D12_FILL_MODE.D3D12_FILL_MODE_SOLID, D3D12_CULL_MODE.D3D12_CULL_MODE_BACK, false, D3D12_DEFAULT_DEPTH_BIAS,
				D3D12_DEFAULT_DEPTH_BIAS_CLAMP, D3D12_DEFAULT_SLOPE_SCALED_DEPTH_BIAS, true, false, false, 0,
				D3D12_CONSERVATIVE_RASTERIZATION_MODE.D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF)
		{
		}
	}

	/// <summary>Represents an axis-aligned bounding box (AABB) used as raytracing geometry.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_aabb typedef struct D3D12_RAYTRACING_AABB { FLOAT
	// MinX; FLOAT MinY; FLOAT MinZ; FLOAT MaxX; FLOAT MaxY; FLOAT MaxZ; } D3D12_RAYTRACING_AABB;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_AABB")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_AABB
	{
		/// <summary>The minimum X coordinate of the box.</summary>
		public float MinX;

		/// <summary>The minimum Y coordinate of the box.</summary>
		public float MinY;

		/// <summary>The minimum Z coordinate of the box.</summary>
		public float MinZ;

		/// <summary>The maximum X coordinate of the box.</summary>
		public float MaxX;

		/// <summary>The maximum Y coordinate of the box.</summary>
		public float MaxY;

		/// <summary>The maximum Z coordinate of the box.</summary>
		public float MaxZ;
	}

	/// <summary>Describes the space requirement for acceleration structure after compaction.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_postbuild_info_compacted_size_desc
	// typedef struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE_DESC { UINT64 CompactedSizeInBytes; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE_DESC
	{
		/// <summary>
		/// <para>The space requirement for acceleration structure after compaction.</para>
		/// <para>
		/// It is guaranteed that a compacted acceleration structure doesn’t consume more space than a non-compacted acceleration structure.
		/// </para>
		/// <para>
		/// Pre-compaction, it is guaranteed that the size requirements reported by <c>GetRaytracingAccelerationStructurePrebuildInfo</c>
		/// for a given build configuration (triangle counts etc.) will be sufficient to store any acceleration structure whose build inputs
		/// are reduced (e.g. reducing triangle counts). This non-increasing property for smaller builds does not apply post-compaction,
		/// however. In other words, it is not guaranteed that having fewer items in an acceleration structure means it compresses to a
		/// smaller size than compressing an acceleration structure with more items.
		/// </para>
		/// </summary>
		public ulong CompactedSizeInBytes;
	}

	/// <summary>Describes the space currently used by an acceleration structure..</summary>
	/// <remarks>
	/// The information in this structure is useful for tools to be able to determine how much memory is occupied by an arbitrary
	/// acceleration structure currently sitting in memory.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_postbuild_info_current_size_desc
	// typedef struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE_DESC { UINT64 CurrentSizeInBytes; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_CURRENT_SIZE_DESC
	{
		/// <summary>
		/// Space currently used by an acceleration structure. If the acceleration structure hasn’t had a compaction operation performed on
		/// it, this size is the same one reported by <c>GetRaytracingAccelerationStructurePrebuildInfo</c>, and if it has been compacted
		/// this size is the same reported for post-build info with <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_COMPACTED_SIZE</c>.
		/// </summary>
		public ulong CurrentSizeInBytes;
	}

	/// <summary>
	/// Description of the post-build information to generate from an acceleration structure. Use this structure in calls to
	/// <c>EmitRaytracingAccelerationStructurePostbuildInfo</c> and <c>BuildRaytracingAccelerationStructure</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_postbuild_info_desc
	// typedef struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_DESC { D3D12_GPU_VIRTUAL_ADDRESS DestBuffer;
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TYPE InfoType; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_DESC
	{
		/// <summary>
		/// <para>
		/// Storage for the post-build info result. Size required and the layout of the contents written by the system depend on the value
		/// of the <i>InfoType</i> field.
		/// </para>
		/// <para>
		/// The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_UNORDERED_ACCESS</c>. The memory must be aligned to the natural
		/// alignment for the members of the particular output structure being generated (e.g. 8 bytes for a struct with the largest members
		/// being UINT64).
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS DestBuffer;

		/// <summary>
		/// A <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TYPE</c> value specifying the type of post-build information to retrieve.
		/// </summary>
		public D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TYPE InfoType;
	}

	/// <summary>Describes the size and layout of the serialized acceleration structure and header</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_postbuild_info_serialization_desc
	// typedef struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC { UINT64 SerializedSizeInBytes; UINT64
	// NumBottomLevelAccelerationStructurePointers; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC
	{
		/// <summary>
		/// The size of the serialized acceleration structure, including a header. The header is
		/// <c>D3D12_SERIALIZED_RAYTRACING_ACCELERATION_STRUCTURE_HEADER</c> followed by followed by a list of pointers to bottom-level
		/// acceleration structures.
		/// </summary>
		public ulong SerializedSizeInBytes;

		/// <summary>
		/// <para>
		/// The number of 64-bit GPU virtual addresses that will be at the start of the serialized acceleration structure, after the
		/// <c>D3D12_SERIALIZED_RAYTRACING_ACCELERATION_STRUCTURE_HEADER</c>. For a bottom-level acceleration structure this will be 0. For
		/// a top-level acceleration structure, the pointers indicate the acceleration structures being referred to.
		/// </para>
		/// <para>
		/// When deserialization occurs, these pointers to bottom-level pointers must be initialized by the app in the serialized data (just
		/// after the header) to the new locations where the bottom level acceleration structures will reside. It is not required that these
		/// new locations to have already been populated with bottom-level acceleration structures at deserialization time, as long as they
		/// are initialized with the expected deserialized data structures before being used in raytracing. During deserialization, the
		/// driver reads the new pointers, using them to produce an equivalent top-level acceleration structure to the original.
		/// </para>
		/// </summary>
		public ulong NumBottomLevelAccelerationStructurePointers;
	}

	/// <summary>Describes the space requirement for decoding an acceleration structure into a form that can be visualized by tools.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_postbuild_info_tools_visualization_desc
	// typedef struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION_DESC { UINT64 DecodedSizeInBytes; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_TOOLS_VISUALIZATION_DESC
	{
		/// <summary>The space requirement for decoding an acceleration structure into a form that can be visualized by tools.</summary>
		public ulong DecodedSizeInBytes;
	}

	/// <summary>
	/// Represents prebuild information about a raytracing acceleration structure. Get an instance of this structure by calling <c>GetRaytracingAccelerationStructurePrebuildInfo</c>.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_prebuild_info typedef
	// struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO { UINT64 ResultDataMaxSizeInBytes; UINT64 ScratchDataSizeInBytes; UINT64
	// UpdateScratchDataSizeInBytes; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_PREBUILD_INFO
	{
		/// <summary>Size required to hold the result of an acceleration structure build based on the specified inputs.</summary>
		public ulong ResultDataMaxSizeInBytes;

		/// <summary>
		/// <para>Scratch storage on the GPU required during acceleration structure build based on the specified inputs.</para>
		/// <para>UpdateScratchDataSizeInBytes</para>
		/// <para>
		/// Scratch storage on GPU required during an acceleration structure update based on the specified inputs. This only needs to be
		/// called for the original acceleration structure build, and defines the scratch storage requirement for every acceleration
		/// structure update, other than the initial build.
		/// </para>
		/// <para>
		/// If the <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BUILD_FLAG_ALLOW_UPDATE</c> flag is not specified when calling
		/// <c>GetRaytracingAccelerationStructurePrebuildInfo</c>, the returned value of this field is 0.
		/// </para>
		/// </summary>
		public ulong ScratchDataSizeInBytes;

		/// <summary/>
		public ulong UpdateScratchDataSizeInBytes;
	}

	/// <summary>A shader resource view (SRV) structure for storing a raytracing acceleration structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_srv typedef struct
	// D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV { D3D12_GPU_VIRTUAL_ADDRESS Location; } D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV
	{
		/// <summary>The GPU virtual address of the SRV.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS Location;
	}

	/// <summary>
	/// Describes a set of Axis-aligned bounding boxes that are used in the <c>D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS</c>
	/// structure to provide input data to a raytracing acceleration structure build operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_geometry_aabbs_desc typedef struct
	// D3D12_RAYTRACING_GEOMETRY_AABBS_DESC { UINT64 AABBCount; D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE AABBs; } D3D12_RAYTRACING_GEOMETRY_AABBS_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_GEOMETRY_AABBS_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_GEOMETRY_AABBS_DESC
	{
		/// <summary>The number of AABBs pointed to in the contiguous array at <i>AABBs</i>.</summary>
		public ulong AABBCount;

		/// <summary>
		/// the GPU memory location where an array of AABB descriptions is to be found, including the data stride between AABBs. The address
		/// and stride must each be aligned to 8 bytes, defined as The address must be aligned to 16 bytes, defined as
		/// <c>D3D12_RAYTRACING_AABB_BYTE_ALIGNMENT</c>. The stride can be 0.
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE AABBs;
	}

	/// <summary>
	/// Describes a set of geometry that is used in the <c>D3D12_BUILD_RAYTRACING_ACCELERATION_STRUCTURE_INPUTS</c> structure to provide
	/// input data to a raytracing acceleration structure build operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_geometry_desc typedef struct
	// D3D12_RAYTRACING_GEOMETRY_DESC { D3D12_RAYTRACING_GEOMETRY_TYPE Type; D3D12_RAYTRACING_GEOMETRY_FLAGS Flags; union {
	// D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC Triangles; D3D12_RAYTRACING_GEOMETRY_AABBS_DESC AABBs; }; } D3D12_RAYTRACING_GEOMETRY_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_GEOMETRY_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_RAYTRACING_GEOMETRY_DESC
	{
		/// <summary>The type of geometry.</summary>
		[FieldOffset(0)]
		public D3D12_RAYTRACING_GEOMETRY_TYPE Type;

		/// <summary>The geometry flags</summary>
		[FieldOffset(4)]
		public D3D12_RAYTRACING_GEOMETRY_FLAGS Flags;

		/// <summary>
		/// A <c>D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC</c> describing triangle geometry, if <i>Type</i> is
		/// <c>D3D12_RAYTRACING_GEOMETRY_TYPE_TRIANGLES</c>. Otherwise this parameter is unused.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC Triangles;

		/// <summary>
		/// A <c>D3D12_RAYTRACING_GEOMETRY_AABBS_DESC</c> describing triangle geometry, if <i>Type</i> is
		/// <c>D3D12_RAYTRACING_GEOMETRY_TYPE_PROCEDURAL_PRIMITIVE_AABBS</c>. Otherwise this parameter is unused.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_RAYTRACING_GEOMETRY_AABBS_DESC AABBs;
	}

	/// <summary>
	/// Describes a set of triangles used as raytracing geometry. The geometry pointed to by this struct are always in triangle list form,
	/// indexed or non-indexed. Triangle strips are not supported.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_geometry_triangles_desc typedef struct
	// D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC { D3D12_GPU_VIRTUAL_ADDRESS Transform3x4; DXGI_FORMAT IndexFormat; DXGI_FORMAT VertexFormat;
	// UINT IndexCount; UINT VertexCount; D3D12_GPU_VIRTUAL_ADDRESS IndexBuffer; D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE VertexBuffer; } D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_GEOMETRY_TRIANGLES_DESC
	{
		/// <summary>
		/// <para>
		/// Address of a 3x4 affine transform matrix in row-major layout to be applied to the vertices in the <i>VertexBuffer</i> during an
		/// acceleration structure build. The contents of <i>VertexBuffer</i> are not modified. If a 2D vertex format is used, the
		/// transformation is applied with the third vertex component assumed to be zero.
		/// </para>
		/// <para>
		/// If <i>Transform3x4</i> is NULL the vertices will not be transformed. Using <i>Transform3x4</i> may result in increased
		/// computation and/or memory requirements for the acceleration structure build.
		/// </para>
		/// <para>
		/// The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>. The address must be aligned to 16
		/// bytes, defined as <c>D3D12_RAYTRACING_TRANSFORM3X4_BYTE_ALIGNMENT</c>.
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS Transform3x4;

		/// <summary>
		/// <para>Format of the indices in the <i>IndexBuffer</i>. Must be one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>DXGI_FORMAT_UNKNOWN</b> - when IndexBuffer is NULL</description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R32_UINT</b></description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R16_UINT</b></description>
		/// </item>
		/// </list>
		/// </summary>
		public DXGI_FORMAT IndexFormat;

		/// <summary>
		/// <para>Format of the vertices in <i>VertexBuffer</i>. Must be one of the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <description><b>DXGI_FORMAT_R32G32_FLOAT</b> - third component is assumed 0</description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R32G32B32_FLOAT</b></description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R16G16_FLOAT</b> - third component is assumed 0</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>DXGI_FORMAT_R16G16B16A16_FLOAT</b> - A16 component is ignored, other data can be packed there, such as setting vertex stride
		/// to 6 bytes.
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R16G16_SNORM</b> - third component is assumed 0</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>DXGI_FORMAT_R16G16B16A16_SNORM</b> - A16 component is ignored, other data can be packed there, such as setting vertex stride
		/// to 6 bytes.
		/// </description>
		/// </item>
		/// </list>
		/// <para>Tier 1.1 devices support the following additional formats:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <b>DXGI_FORMAT_R16G16B16A16_UNORM</b> - A16 component is ignored, other data can be packed there, such as setting vertex stride
		/// to 6 bytes
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R16G16_UNORM</b> - third component assumed 0</description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R10G10B10A2_UNORM</b> - A2 component is ignored, stride must be 4 bytes</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>DXGI_FORMAT_R8G8B8A8_UNORM</b> - A8 component is ignored, other data can be packed there, such as setting vertex stride to 3 bytes
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R8G8_UNORM</b> - third component assumed 0</description>
		/// </item>
		/// <item>
		/// <description>
		/// <b>DXGI_FORMAT_R8G8B8A8_SNORM</b> - A8 component is ignored, other data can be packed there, such as setting vertex stride to 3 bytes
		/// </description>
		/// </item>
		/// <item>
		/// <description><b>DXGI_FORMAT_R8G8_SNORM</b> - third component assumed 0</description>
		/// </item>
		/// </list>
		/// </summary>
		public DXGI_FORMAT VertexFormat;

		/// <summary>Number of indices in <i>IndexBuffer</i>. Must be 0 if <i>IndexBuffer</i> is NULL.</summary>
		public uint IndexCount;

		/// <summary>Number of vertices in <i>VertexBuffer</i>.</summary>
		public uint VertexCount;

		/// <summary>
		/// <para>
		/// Array of vertex indices. If NULL, triangles are non-indexed. Just as with graphics, the address must be aligned to the size of <i>IndexFormat</i>.
		/// </para>
		/// <para>
		/// The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>. Note that if an app wants to share
		/// index buffer inputs between graphics input assembler and raytracing acceleration structure build input, it can always put a
		/// resource into a combination of read states simultaneously, e.g. <b>D3D12_RESOURCE_STATE_INDEX_BUFFER</b> | <b>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</b>.
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS IndexBuffer;

		/// <summary>
		/// <para>
		/// Array of vertices including a stride. The alignment on the address and stride must be a multiple of the component size, so 4
		/// bytes for formats with 32bit components and 2 bytes for formats with 16bit components. Unlike graphics, there is no constraint
		/// on the stride, other than that the bottom 32bits of the value are all that are used – the field is UINT64 purely to make
		/// neighboring fields align cleanly/obviously everywhere. Each vertex position is expected to be at the start address of the stride
		/// range and any excess space is ignored by acceleration structure builds. This excess space might contain other app data such as
		/// vertex attributes, which the app is responsible for manually fetching in shaders, whether it is interleaved in vertex buffers or elsewhere.
		/// </para>
		/// <para>
		/// The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</c>. Note that if an app wants to share
		/// vertex buffer inputs between graphics input assembler and raytracing acceleration structure build input, it can always put a
		/// resource into a combination of read states simultaneously, e.g. <b>D3D12_RESOURCE_STATE_VERTEX_AND_CONSTANT_BUFFER</b> | <b>D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE</b>
		/// </para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS_AND_STRIDE VertexBuffer;
	}

	/// <summary>
	/// Describes an instance of a raytracing acceleration structure used in GPU memory during the acceleration structure build process.
	/// </summary>
	/// <remarks>
	/// This C++ struct definition is useful if you're generating instance data on the CPU first, then uploading to the GPU. But your
	/// application is also free to generate instance descriptions directly into GPU memory (from compute shaders, for instance) following
	/// the same layout.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_instance_desc typedef struct
	// D3D12_RAYTRACING_INSTANCE_DESC { FLOAT Transform[3][4]; UINT InstanceID : 24; UINT InstanceMask : 8; UINT
	// InstanceContributionToHitGroupIndex : 24; UINT Flags : 8; D3D12_GPU_VIRTUAL_ADDRESS AccelerationStructure; } D3D12_RAYTRACING_INSTANCE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_INSTANCE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_INSTANCE_DESC
	{
		private unsafe fixed float _Transform[12];

		/// <summary>
		/// <para>Type: <b><c>FLOAT</c> [3][4]</b></para>
		/// <para>
		/// A 3x4 transform matrix in row-major layout representing the instance-to-world transformation. Implementations transform rays, as
		/// opposed to transforming all of the geometry or AABBs.
		/// </para>
		/// <note>The layout of <c>Transform</c> is a transpose of how affine matrices are typically stored in memory. Instead of four
		/// 3-vectors, <c>Transform</c> is laid out as three 4-vectors.</note>
		/// </summary>
		public float[,] Transform
		{
			get
			{
				var ret = new float[3, 4];
				unsafe
				{
					fixed (float* p = _Transform)
					{
						for (var i = 0; i < 3; i++)
							for (var j = 0; j < 4; j++)
								ret[i, j] = p[i * 4 + j];
					}
				}
				return ret;
			}
			set
			{
				unsafe
				{
					if (value.GetLength(0) != 3 || value.GetLength(1) != 4)
						throw new ArgumentException("The array must be 3x4.");
					fixed (float* p = _Transform)
					{
						for (var i = 0; i < 3; i++)
							for (var j = 0; j < 4; j++)
								p[i * 4 + j] = value[i, j];
					}
				}
			}
		}

		private ulong bits;

		/// <summary>
		/// <para>Type: <b><c>UINT</c> : 24</b></para>
		/// <para>An arbitrary 24-bit value that can be accessed using the <c>InstanceID</c> intrinsic function in supported shader types.</para>
		/// </summary>
		public uint InstanceID { readonly get => (uint)(bits & 0xFFFFFF); set => bits = (bits & 0xFFFFFFFFFF000000) | value; }

		/// <summary>
		/// <para>Type: <b><c>UINT</c> : 8</b></para>
		/// <para>
		/// An 8-bit mask assigned to the instance, which can be used to include/reject groups of instances on a per-ray basis. If the value
		/// is zero, then the instance will never be included, so typically this should be set to some non-zero value. For more information
		/// see, the <c>InstanceInclusionMask</c> parameter to the <c>TraceRay</c> function.
		/// </para>
		/// </summary>
		public uint InstanceMask { readonly get => (uint)((bits >> 24) & 0xFF); set => bits = (bits & 0xFFFFFFFF00FFFFFF) | ((ulong)value << 24); }

		/// <summary>
		/// <para>Type: <b><c>UINT</c> : 24</b></para>
		/// <para>
		/// An arbitrary 24-bit value representing per-instance contribution to add into shader table indexing to select the hit group to use.
		/// </para>
		/// </summary>
		public uint InstanceContributionToHitGroupIndex { readonly get => (uint)((bits >> 32) & 0xFFFFFF); set => bits = (bits & 0xFF000000FFFFFFFF) | ((ulong)value << 32); }

		/// <summary>
		/// <para>Type: <b><c>UINT</c> : 8</b></para>
		/// <para>An 8-bit mask representing flags from <c>D3D12_RAYTRACING_INSTANCE_FLAGS</c> to apply to the instance.</para>
		/// </summary>
		public D3D12_RAYTRACING_INSTANCE_FLAGS Flags { readonly get => (D3D12_RAYTRACING_INSTANCE_FLAGS)((bits >> 56) & 0xFF); set => bits = (bits & 0x00FFFFFFFFFFFFFF) | ((ulong)value << 56); }

		/// <summary>
		/// <para>Type: <b><c>D3D12_GPU_VIRTUAL_ADDRESS</c></b></para>
		/// <para>
		/// Address of the bottom-level acceleration structure that is being instanced. The address must be aligned to 256 bytes, defined as
		/// <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_BYTE_ALIGNMENT</c>. Any existing acceleration structure passed in here would already
		/// have been required to be placed with such alignment.
		/// </para>
		/// <para>The memory pointed to must be in state <c>D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE</c>.</para>
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS AccelerationStructure;
	}

	/// <summary>A state subobject that represents a raytracing pipeline configuration.</summary>
	/// <remarks>
	/// A raytracing pipeline needs one raytracing pipeline configuration. If multiple pipeline configurations are present, then they must
	/// all match in content. But there's no benefit to such duplication. For example, defining it once per collection doesn't help drivers
	/// do early shader compilation before a raytracing pipeline is created. This is unlike <c>D3D12_RAYTRACING_SHADER_CONFIG</c>, which
	/// does benefit from duplication per collection.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_pipeline_config typedef struct
	// D3D12_RAYTRACING_PIPELINE_CONFIG { UINT MaxTraceRecursionDepth; } D3D12_RAYTRACING_PIPELINE_CONFIG;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_PIPELINE_CONFIG")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_PIPELINE_CONFIG
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// Limit on ray recursion for the raytracing pipeline. It must be in the range of 0 to 31. Below the maximum recursion depth,
		/// shader invocations such as closest hit or miss shaders can call <b>TraceRay</b> any number of times. At the maximum recursion
		/// depth, <b>TraceRay</b> calls result in the device going into removed state.
		/// </para>
		/// </summary>
		public uint MaxTraceRecursionDepth;
	}

	/// <summary>
	/// <para>A state subobject that represents a raytracing pipeline configuration, with flags.</para>
	/// <para><b>D3D12_RAYTRACING_PIPELINE_CONFIG1</b> requires Tier 1.1 raytracing support (see <c>D3D12_RAYTRACING_TIER</c>).</para>
	/// </summary>
	/// <remarks>
	/// A raytracing pipeline needs one raytracing pipeline configuration. If multiple pipeline configurations are present, then they must
	/// all match in content. But there's no benefit to such duplication. For example, defining it once per collection doesn't help drivers
	/// do early shader compilation before a raytracing pipeline is created. This is unlike <c>D3D12_RAYTRACING_SHADER_CONFIG</c>, which
	/// does benefit from duplication per collection.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_pipeline_config1 typedef struct
	// D3D12_RAYTRACING_PIPELINE_CONFIG1 { UINT MaxTraceRecursionDepth; D3D12_RAYTRACING_PIPELINE_FLAGS Flags; } D3D12_RAYTRACING_PIPELINE_CONFIG1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_PIPELINE_CONFIG1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_PIPELINE_CONFIG1
	{
		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// Limit on ray recursion for the raytracing pipeline. It must be in the range of 0 to 31. Below the maximum recursion depth,
		/// shader invocations such as closest hit or miss shaders can call <b>TraceRay</b> any number of times. At the maximum recursion
		/// depth, <b>TraceRay</b> calls result in the device going into removed state.
		/// </para>
		/// </summary>
		public uint MaxTraceRecursionDepth;

		/// <summary>
		/// <para>Type: <b><c>D3D12_RAYTRACING_PIPELINE_FLAGS</c></b></para>
		/// <para>Configuration flags for the raytracing pipeline.</para>
		/// </summary>
		public D3D12_RAYTRACING_PIPELINE_FLAGS Flags;
	}

	/// <summary>A state subobject that represents a shader configuration.</summary>
	/// <remarks>
	/// A raytracing pipeline needs one raytracing shader configuration. If multiple shader configurations are present, such as one in each
	/// collection to enable independent driver compilation for each one, they must all match when combined into a raytracing pipeline.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_shader_config typedef struct
	// D3D12_RAYTRACING_SHADER_CONFIG { UINT MaxPayloadSizeInBytes; UINT MaxAttributeSizeInBytes; } D3D12_RAYTRACING_SHADER_CONFIG;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RAYTRACING_SHADER_CONFIG")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RAYTRACING_SHADER_CONFIG
	{
		/// <summary>
		/// The maximum storage for scalars (counted as 4 bytes each) in ray payloads in raytracing pipelines that contain this program.
		/// </summary>
		public uint MaxPayloadSizeInBytes;

		/// <summary>
		/// The maximum number of scalars (counted as 4 bytes each) that can be used for attributes in pipelines that contain this shader.
		/// The value cannot exceed <c>D3D12_RAYTRACING_MAX_ATTRIBUTE_SIZE_IN_BYTES</c>.
		/// </summary>
		public uint MaxAttributeSizeInBytes;
	}

	/// <summary>Describes the access to resource(s) that is requested by an application at the transition into a render pass.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_beginning_access typedef struct
	// D3D12_RENDER_PASS_BEGINNING_ACCESS { D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE Type; union {
	// D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS Clear; D3D12_RENDER_PASS_BEGINNING_ACCESS_PRESERVE_LOCAL_PARAMETERS
	// PreserveLocal; }; } D3D12_RENDER_PASS_BEGINNING_ACCESS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_BEGINNING_ACCESS")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_RENDER_PASS_BEGINNING_ACCESS
	{
		/// <summary>A <c>D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE</c>. The type of access being requested.</summary>
		[FieldOffset(0)]
		public D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE Type;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS</c>. Appropriate when <b>Type</b> is
		/// <c>D3D12_RENDER_PASS_BEGINNING_ACCESS_TYPE_CLEAR</c>. The clear value to which resource(s) should be cleared.
		/// </summary>
		[FieldOffset(4)]
		public D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS Clear;

		/// <summary/>
		[FieldOffset(4)]
		public D3D12_RENDER_PASS_BEGINNING_ACCESS_PRESERVE_LOCAL_PARAMETERS PreserveLocal;
	}

	/// <summary>Describes the clear value to which resource(s) should be cleared at the beginning of a render pass.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_beginning_access_clear_parameters typedef struct
	// D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS { D3D12_CLEAR_VALUE ClearValue; } D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_BEGINNING_ACCESS_CLEAR_PARAMETERS
	{
		/// <summary>A <c>D3D12_CLEAR_VALUE</c>. The clear value to which the resource(s) should be cleared.</summary>
		public D3D12_CLEAR_VALUE ClearValue;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("d3d12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_BEGINNING_ACCESS_PRESERVE_LOCAL_PARAMETERS
	{
		/// <summary/>
		public uint AdditionalWidth;

		/// <summary/>
		public uint AdditionalHeight;
	}

	/// <summary>
	/// Describes a binding (fixed for the duration of the render pass) to a depth stencil view (DSV), as well as its beginning and ending
	/// access characteristics.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_depth_stencil_desc typedef struct
	// D3D12_RENDER_PASS_DEPTH_STENCIL_DESC { D3D12_CPU_DESCRIPTOR_HANDLE cpuDescriptor; D3D12_RENDER_PASS_BEGINNING_ACCESS
	// DepthBeginningAccess; D3D12_RENDER_PASS_BEGINNING_ACCESS StencilBeginningAccess; D3D12_RENDER_PASS_ENDING_ACCESS DepthEndingAccess;
	// D3D12_RENDER_PASS_ENDING_ACCESS StencilEndingAccess; } D3D12_RENDER_PASS_DEPTH_STENCIL_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_DEPTH_STENCIL_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_DEPTH_STENCIL_DESC
	{
		/// <summary>A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>. The CPU descriptor handle corresponding to the depth stencil view (DSV).</summary>
		public D3D12_CPU_DESCRIPTOR_HANDLE cpuDescriptor;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_BEGINNING_ACCESS</c>. The access to the depth buffer requested at the transition into a render pass.
		/// </summary>
		public D3D12_RENDER_PASS_BEGINNING_ACCESS DepthBeginningAccess;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_BEGINNING_ACCESS</c>. The access to the stencil buffer requested at the transition into a render pass.
		/// </summary>
		public D3D12_RENDER_PASS_BEGINNING_ACCESS StencilBeginningAccess;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_ENDING_ACCESS</c>. The access to the depth buffer requested at the transition out of a render pass.
		/// </summary>
		public D3D12_RENDER_PASS_ENDING_ACCESS DepthEndingAccess;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_ENDING_ACCESS</c>. The access to the stencil buffer requested at the transition out of a render pass.
		/// </summary>
		public D3D12_RENDER_PASS_ENDING_ACCESS StencilEndingAccess;
	}

	/// <summary>Describes the access to resource(s) that is requested by an application at the transition out of a render pass.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_ending_access typedef struct
	// D3D12_RENDER_PASS_ENDING_ACCESS { D3D12_RENDER_PASS_ENDING_ACCESS_TYPE Type; union {
	// D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS Resolve; D3D12_RENDER_PASS_ENDING_ACCESS_PRESERVE_LOCAL_PARAMETERS PreserveLocal;
	// }; } D3D12_RENDER_PASS_ENDING_ACCESS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_ENDING_ACCESS")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_RENDER_PASS_ENDING_ACCESS
	{
		/// <summary>A <c>D3D12_RENDER_PASS_ENDING_ACCESS_TYPE</c>. The type of access being requested.</summary>
		[FieldOffset(0)]
		public D3D12_RENDER_PASS_ENDING_ACCESS_TYPE Type;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS</c>. Appropriate when <b>Type</b> is
		/// <c>D3D12_RENDER_PASS_ENDING_ACCESS_TYPE_RESOLVE</c>. Description of the resource to resolve to.
		/// </summary>
		[FieldOffset(4)]
		public D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS Resolve;

		/// <summary/>
		[FieldOffset(4)]
		public D3D12_RENDER_PASS_ENDING_ACCESS_PRESERVE_LOCAL_PARAMETERS PreserveLocal;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("d3d12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_ENDING_ACCESS_PRESERVE_LOCAL_PARAMETERS
	{
		/// <summary/>
		public uint AdditionalWidth;

		/// <summary/>
		public uint AdditionalHeight;
	}

	/// <summary>Describes a resource to resolve to at the conclusion of a render pass.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_ending_access_resolve_parameters typedef struct
	// D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS { ID3D12Resource *pSrcResource; ID3D12Resource *pDstResource; UINT
	// SubresourceCount; const D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS *pSubresourceParameters; DXGI_FORMAT Format;
	// D3D12_RESOLVE_MODE ResolveMode; BOOL PreserveResolveSource; } D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_PARAMETERS
	{
		/// <summary>A pointer to an <c>ID3D12Resource</c>. The source resource.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12Resource pSrcResource;

		/// <summary>A pointer to an <c>ID3D12Resource</c>. The destination resource.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12Resource pDstResource;

		/// <summary>A <b>UINT</b>. The number of subresources.</summary>
		public uint SubresourceCount;

		/// <summary>
		/// <para>
		/// A pointer to a constant array of <c>D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS</c>. These subresources can
		/// be a subset of the render target's array slices, but you can't target subresources that aren't part of the render target view
		/// (RTV) or the depth/stencil view (DSV).
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// This pointer is directly referenced by the command list, and the memory for this array must remain alive and intact until
		/// <c>EndRenderPass</c> is called.
		/// </para>
		/// </para>
		/// </summary>
		public StructPointer<D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS> pSubresourceParameters;

		/// <summary>A <c>DXGI_FORMAT</c>. The data format of the resources.</summary>
		public DXGI_FORMAT Format;

		/// <summary>A <c>D3D12_RESOLVE_MODE</c>. The resolve operation.</summary>
		public D3D12_RESOLVE_MODE ResolveMode;

		/// <summary>A <b>BOOL</b>. <b>TRUE</b> to preserve the resolve source, otherwise <b>FALSE</b>.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool PreserveResolveSource;
	}

	/// <summary>Describes the subresources involved in resolving at the conclusion of a render pass.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_ending_access_resolve_subresource_parameters
	// typedef struct D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS { UINT SrcSubresource; UINT DstSubresource; UINT DstX;
	// UINT DstY; D3D12_RECT SrcRect; } D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_ENDING_ACCESS_RESOLVE_SUBRESOURCE_PARAMETERS
	{
		/// <summary>A <b>UINT</b>. The source subresource.</summary>
		public uint SrcSubresource;

		/// <summary>A <b>UINT</b>. The destination subresource.</summary>
		public uint DstSubresource;

		/// <summary>A <b>UINT</b>. The x coordinate within the destination subresource.</summary>
		public uint DstX;

		/// <summary>A <b>UINT</b>. The y coordinate within the destination subresource.</summary>
		public uint DstY;

		/// <summary>A <c>D3D12_RECT</c>. The rectangle within the source subresource.</summary>
		public D3D12_RECT SrcRect;
	}

	/// <summary>
	/// Describes bindings (fixed for the duration of the render pass) to one or more render target views (RTVs), as well as their beginning
	/// and ending access characteristics.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_pass_render_target_desc typedef struct
	// D3D12_RENDER_PASS_RENDER_TARGET_DESC { D3D12_CPU_DESCRIPTOR_HANDLE cpuDescriptor; D3D12_RENDER_PASS_BEGINNING_ACCESS BeginningAccess;
	// D3D12_RENDER_PASS_ENDING_ACCESS EndingAccess; } D3D12_RENDER_PASS_RENDER_TARGET_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_PASS_RENDER_TARGET_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_PASS_RENDER_TARGET_DESC
	{
		/// <summary>A <c>D3D12_CPU_DESCRIPTOR_HANDLE</c>. The CPU descriptor handle corresponding to the render target view(s) (RTVs).</summary>
		public D3D12_CPU_DESCRIPTOR_HANDLE cpuDescriptor;

		/// <summary>
		/// A <c>D3D12_RENDER_PASS_BEGINNING_ACCESS</c>. The access to the RTV(s) requested at the transition into a render pass.
		/// </summary>
		public D3D12_RENDER_PASS_BEGINNING_ACCESS BeginningAccess;

		/// <summary>A <c>D3D12_RENDER_PASS_ENDING_ACCESS</c>. The access to the RTV(s) requested at the transition out of a render pass.</summary>
		public D3D12_RENDER_PASS_ENDING_ACCESS EndingAccess;
	}

	/// <summary>Describes the blend state for a render target.</summary>
	/// <remarks>
	/// <para>
	/// <para>Note</para>
	/// <para>It's not valid for LogicOpEnable and BlendEnable to both be <b>TRUE</b>.</para>
	/// </para>
	/// <para>
	/// You specify an array of <b>D3D12_RENDER_TARGET_BLEND_DESC</b> structures in the <b>RenderTarget</b> member of the
	/// <c>D3D12_BLEND_DESC</c> structure to describe the blend states for render targets; you can bind up to eight render targets to the
	/// <c>output-merger stage</c> at one time.
	/// </para>
	/// <para>For info about how blending is done, see the <c>output-merger stage</c>.</para>
	/// <para>Here are the default values for blend state.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>State</description>
	/// <description>Default Value</description>
	/// </listheader>
	/// <item>
	/// <description>BlendEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// <item>
	/// <description>LogicOpEnable</description>
	/// <description>FALSE</description>
	/// </item>
	/// <item>
	/// <description>SrcBlend</description>
	/// <description>D3D12_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>DestBlend</description>
	/// <description>D3D12_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>BlendOp</description>
	/// <description>D3D12_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>SrcBlendAlpha</description>
	/// <description>D3D12_BLEND_ONE</description>
	/// </item>
	/// <item>
	/// <description>DestBlendAlpha</description>
	/// <description>D3D12_BLEND_ZERO</description>
	/// </item>
	/// <item>
	/// <description>BlendOpAlpha</description>
	/// <description>D3D12_BLEND_OP_ADD</description>
	/// </item>
	/// <item>
	/// <description>LogicOp</description>
	/// <description>D3D12_LOGIC_OP_NOOP</description>
	/// </item>
	/// <item>
	/// <description>RenderTargetWriteMask</description>
	/// <description>D3D12_COLOR_WRITE_ENABLE_ALL</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_target_blend_desc typedef struct
	// D3D12_RENDER_TARGET_BLEND_DESC { BOOL BlendEnable; BOOL LogicOpEnable; D3D12_BLEND SrcBlend; D3D12_BLEND DestBlend; D3D12_BLEND_OP
	// BlendOp; D3D12_BLEND SrcBlendAlpha; D3D12_BLEND DestBlendAlpha; D3D12_BLEND_OP BlendOpAlpha; D3D12_LOGIC_OP LogicOp; UINT8
	// RenderTargetWriteMask; } D3D12_RENDER_TARGET_BLEND_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_TARGET_BLEND_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RENDER_TARGET_BLEND_DESC
	{
		/// <summary>
		/// <para>Specifies whether to enable (or disable) blending. Set to <b>TRUE</b> to enable blending.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>It's not valid for LogicOpEnable and BlendEnable to both be <b>TRUE</b>.</para>
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool BlendEnable;

		/// <summary>
		/// <para>Specifies whether to enable (or disable) a logical operation. Set to <b>TRUE</b> to enable a logical operation.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>It's not valid for LogicOpEnable and BlendEnable to both be <b>TRUE</b>.</para>
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool LogicOpEnable;

		/// <summary>
		/// A <c>D3D12_BLEND</c>-typed value that specifies the operation to perform on the RGB value that the pixel shader outputs. The
		/// <b>BlendOp</b> member defines how to combine the <b>SrcBlend</b> and <b>DestBlend</b> operations.
		/// </summary>
		public D3D12_BLEND SrcBlend;

		/// <summary>
		/// A <c>D3D12_BLEND</c>-typed value that specifies the operation to perform on the current RGB value in the render target. The
		/// <b>BlendOp</b> member defines how to combine the <b>SrcBlend</b> and <b>DestBlend</b> operations.
		/// </summary>
		public D3D12_BLEND DestBlend;

		/// <summary>A <c>D3D12_BLEND_OP</c>-typed value that defines how to combine the <b>SrcBlend</b> and <b>DestBlend</b> operations.</summary>
		public D3D12_BLEND_OP BlendOp;

		/// <summary>
		/// A <c>D3D12_BLEND</c>-typed value that specifies the operation to perform on the alpha value that the pixel shader outputs. Blend
		/// options that end in _COLOR are not allowed. The <b>BlendOpAlpha</b> member defines how to combine the <b>SrcBlendAlpha</b> and
		/// <b>DestBlendAlpha</b> operations.
		/// </summary>
		public D3D12_BLEND SrcBlendAlpha;

		/// <summary>
		/// A <c>D3D12_BLEND</c>-typed value that specifies the operation to perform on the current alpha value in the render target. Blend
		/// options that end in _COLOR are not allowed. The <b>BlendOpAlpha</b> member defines how to combine the <b>SrcBlendAlpha</b> and
		/// <b>DestBlendAlpha</b> operations.
		/// </summary>
		public D3D12_BLEND DestBlendAlpha;

		/// <summary>
		/// A <c>D3D12_BLEND_OP</c>-typed value that defines how to combine the <b>SrcBlendAlpha</b> and <b>DestBlendAlpha</b> operations.
		/// </summary>
		public D3D12_BLEND_OP BlendOpAlpha;

		/// <summary>A <c>D3D12_LOGIC_OP</c>-typed value that specifies the logical operation to configure for the render target.</summary>
		public D3D12_LOGIC_OP LogicOp;

		/// <summary>
		/// A combination of <see cref="D3D12_COLOR_WRITE_ENABLE"/>-typed values that are combined by using a bitwise OR operation. The
		/// resulting value specifies a write mask.
		/// </summary>
		public D3D12_COLOR_WRITE_ENABLE RenderTargetWriteMask;
	}

	/// <summary>Describes the subresources from a resource that are accessible by using a render-target view.</summary>
	/// <remarks>
	/// <para>Pass a render-target-view description into <c>ID3D12Device::CreateRenderTargetView</c> to create a render-target view.</para>
	/// <para>A render-target view can't use the following formats:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Any typeless format.</description>
	/// </item>
	/// <item>
	/// <description>DXGI_FORMAT_R32G32B32 if the view will be used to bind a buffer (vertex, index, constant, or stream-output).</description>
	/// </item>
	/// </list>
	/// <para>If the format is set to DXGI_FORMAT_UNKNOWN, then the format of the resource that the view binds to the pipeline will be used.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_target_view_desc typedef struct
	// D3D12_RENDER_TARGET_VIEW_DESC { DXGI_FORMAT Format; D3D12_RTV_DIMENSION ViewDimension; union { D3D12_BUFFER_RTV Buffer;
	// D3D12_TEX1D_RTV Texture1D; D3D12_TEX1D_ARRAY_RTV Texture1DArray; D3D12_TEX2D_RTV Texture2D; D3D12_TEX2D_ARRAY_RTV Texture2DArray;
	// D3D12_TEX2DMS_RTV Texture2DMS; D3D12_TEX2DMS_ARRAY_RTV Texture2DMSArray; D3D12_TEX3D_RTV Texture3D; }; } D3D12_RENDER_TARGET_VIEW_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RENDER_TARGET_VIEW_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_RENDER_TARGET_VIEW_DESC
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value that specifies the viewing format.</summary>
		[FieldOffset(0)]
		public DXGI_FORMAT Format;

		/// <summary>
		/// A <c>D3D12_RTV_DIMENSION</c>-typed value that specifies how the render-target resource will be accessed. This type specifies how
		/// the resource will be accessed. This member also determines which _RTV to use in the following union.
		/// </summary>
		[FieldOffset(4)]
		public D3D12_RTV_DIMENSION ViewDimension;

		/// <summary>A <c>D3D12_BUFFER_RTV</c> structure that specifies which buffer elements can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_BUFFER_RTV Buffer;

		/// <summary>A <c>D3D12_TEX1D_RTV</c> structure that specifies the subresources in a 1D texture that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX1D_RTV Texture1D;

		/// <summary>A <c>D3D12_TEX1D_ARRAY_RTV</c> structure that specifies the subresources in a 1D texture array that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX1D_ARRAY_RTV Texture1DArray;

		/// <summary>A <c>D3D12_TEX2D_RTV</c> structure that specifies the subresources in a 2D texture that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX2D_RTV Texture2D;

		/// <summary>A <c>D3D12_TEX2D_ARRAY_RTV</c> structure that specifies the subresources in a 2D texture array that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX2D_ARRAY_RTV Texture2DArray;

		/// <summary>
		/// A <c>D3D12_TEX2DMS_RTV</c> structure that specifies a single subresource because a multisampled 2D texture only contains one subresource.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_TEX2DMS_RTV Texture2DMS;

		/// <summary>
		/// A <c>D3D12_TEX2DMS_ARRAY_RTV</c> structure that specifies the subresources in a multisampled 2D texture array that can be accessed.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_TEX2DMS_ARRAY_RTV Texture2DMSArray;

		/// <summary>A <c>D3D12_TEX3D_RTV</c> structure that specifies subresources in a 3D texture that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX3D_RTV Texture3D;
	}

	/// <summary>Describes the transition between usages of two different resources that have mappings into the same heap.</summary>
	/// <remarks>
	/// <para>This structure is a member of the <c>D3D12_RESOURCE_BARRIER</c> structure.</para>
	/// <para>
	/// Both the before and the after resources can be specified or one or both resources can be <b>NULL</b>, which indicates that any
	/// placed or reserved resource could cause aliasing.
	/// </para>
	/// <para>Refer to the usage models described in <c>CreatePlacedResource</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_aliasing_barrier typedef struct
	// D3D12_RESOURCE_ALIASING_BARRIER { ID3D12Resource *pResourceBefore; ID3D12Resource *pResourceAfter; } D3D12_RESOURCE_ALIASING_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_ALIASING_BARRIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_ALIASING_BARRIER
	{
		/// <summary>A pointer to the <c>ID3D12Resource</c> object that represents the before resource used in the transition.</summary>
		public IUnknownPointer<ID3D12Resource> pResourceBefore;

		/// <summary>A pointer to the <c>ID3D12Resource</c> object that represents the after resource used in the transition.</summary>
		public IUnknownPointer<ID3D12Resource> pResourceAfter;
	}

	/// <summary>Describes parameters needed to allocate resources.</summary>
	/// <remarks>
	/// This structure is used by the <c>ID3D12Device::GetResourceAllocationInfo</c> and <c>ID3D12Device::GetResourceAllocationInfo1</c> methods.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_allocation_info typedef struct
	// D3D12_RESOURCE_ALLOCATION_INFO { UINT64 SizeInBytes; UINT64 Alignment; } D3D12_RESOURCE_ALLOCATION_INFO;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_ALLOCATION_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_ALLOCATION_INFO(ulong sizeInBytes, ulong alignment)
	{
		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The size, in bytes, of the resource.</para>
		/// </summary>
		public ulong SizeInBytes = sizeInBytes;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The alignment value for the resource; one of 4KB (4096), 64KB (65536), or 4MB (4194304) alignment.</para>
		/// </summary>
		public ulong Alignment = alignment;
	}

	/// <summary>Describes parameters needed to allocate resources, including offset.</summary>
	/// <remarks>This structure is used by the <c>ID3D12Device::GetResourceAllocationInfo1</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_allocation_info1 typedef struct
	// D3D12_RESOURCE_ALLOCATION_INFO1 { UINT64 Offset; UINT64 Alignment; UINT64 SizeInBytes; } D3D12_RESOURCE_ALLOCATION_INFO1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_ALLOCATION_INFO1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_ALLOCATION_INFO1
	{
		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The offset, in bytes, of the resource.</para>
		/// </summary>
		public ulong Offset;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The alignment value for the resource; one of 4KB (4096), 64KB (65536), or 4MB (4194304) alignment.</para>
		/// </summary>
		public ulong Alignment;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>The size, in bytes, of the resource.</para>
		/// </summary>
		public ulong SizeInBytes;
	}

	/// <summary>Describes a resource barrier (transition in resource use).</summary>
	/// <remarks>This structure is used by the <c>ID3D12GraphicsCommandList::ResourceBarrier</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_barrier typedef struct D3D12_RESOURCE_BARRIER {
	// D3D12_RESOURCE_BARRIER_TYPE Type; D3D12_RESOURCE_BARRIER_FLAGS Flags; union { D3D12_RESOURCE_TRANSITION_BARRIER Transition;
	// D3D12_RESOURCE_ALIASING_BARRIER Aliasing; D3D12_RESOURCE_UAV_BARRIER UAV; }; } D3D12_RESOURCE_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_BARRIER")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_RESOURCE_BARRIER
	{
		/// <summary>
		/// A <c>D3D12_RESOURCE_BARRIER_TYPE</c>-typed value that specifies the type of resource barrier. This member determines which type
		/// to use in the union below.
		/// </summary>
		[FieldOffset(0)]
		public D3D12_RESOURCE_BARRIER_TYPE Type;

		/// <summary>Specifies a <c>D3D12_RESOURCE_BARRIER_FLAGS</c> enumeration constant such as for "begin only" or "end only".</summary>
		[FieldOffset(4)]
		public D3D12_RESOURCE_BARRIER_FLAGS Flags;

		/// <summary>
		/// A <c>D3D12_RESOURCE_TRANSITION_BARRIER</c> structure that describes the transition of subresources between different usages.
		/// Members specify the before and after usages of the subresources.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_RESOURCE_TRANSITION_BARRIER Transition;

		/// <summary>
		/// A <c>D3D12_RESOURCE_ALIASING_BARRIER</c> structure that describes the transition between usages of two different resources that
		/// have mappings into the same heap.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_RESOURCE_ALIASING_BARRIER Aliasing;

		/// <summary>
		/// A <c>D3D12_RESOURCE_UAV_BARRIER</c> structure that describes a resource in which all UAV accesses (reads or writes) must
		/// complete before any future UAV accesses (read or write) can begin.
		/// </summary>
		[FieldOffset(8)]
		public D3D12_RESOURCE_UAV_BARRIER UAV;

		/// <summary>Creates aliasing barrier.</summary>
		public static D3D12_RESOURCE_BARRIER CreateAliasing(ID3D12Resource? pResourceBefore, ID3D12Resource? pResourceAfter) => new()
		{
			Type = D3D12_RESOURCE_BARRIER_TYPE.D3D12_RESOURCE_BARRIER_TYPE_ALIASING,
			Aliasing = new()
			{
				pResourceBefore = new(pResourceBefore),
				pResourceAfter = new(pResourceAfter)
			}
		};

		/// <summary>Creates transition barrier.</summary>
		public static D3D12_RESOURCE_BARRIER CreateTransition(ID3D12Resource pResource, D3D12_RESOURCE_STATES stateBefore, D3D12_RESOURCE_STATES stateAfter,
			uint subresource = D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES, D3D12_RESOURCE_BARRIER_FLAGS flags = D3D12_RESOURCE_BARRIER_FLAGS.D3D12_RESOURCE_BARRIER_FLAG_NONE) =>
				new()
				{
					Type = D3D12_RESOURCE_BARRIER_TYPE.D3D12_RESOURCE_BARRIER_TYPE_TRANSITION,
					Flags = flags,
					Transition = new()
					{
						pResource = new(pResource),
						StateBefore = stateBefore,
						StateAfter = stateAfter,
						Subresource = subresource,
					}
				};

		/// <summary>Creates UAV barrier.</summary>
		public static D3D12_RESOURCE_BARRIER CreateUAV(ID3D12Resource? pResource) => new()
		{
			Type = D3D12_RESOURCE_BARRIER_TYPE.D3D12_RESOURCE_BARRIER_TYPE_UAV,
			UAV = new() { pResource = new(pResource) }
		};
	}

	/// <summary>Describes a resource, such as a texture. This structure is used extensively.</summary>
	/// <remarks>
	/// <para>Use this structure with:</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>ID3D12Resource::GetDesc</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::GetResourceAllocationInfo</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateCommittedResource</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreatePlacedResource</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::CreateReservedResource</c></description>
	/// </item>
	/// <item>
	/// <description><c>ID3D12Device::GetCopyableFootprints</c></description>
	/// </item>
	/// <item>
	/// <description>A number of the helper functions, refer to <c>Helper Structures and Functions for D3D12</c>.</description>
	/// </item>
	/// </list>
	/// <para>Two common resources are buffers and textures, which both use this structure, but with quite different uses of the fields.</para>
	/// <para><c></c><c></c><c></c> Buffers</para>
	/// <para>
	/// Buffers are a contiguous memory region. <i>Width</i> may be between 1 and either the <i>MaxGPUVirtualAddressBitsPerResource</i>
	/// field of <c>D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT</c> for reserved resources or the
	/// <i>MaxGPUVirtualAddressBitsPerProcess</i> field for committed resources. However, exhaustion of GPU virtual address space, memory
	/// residency budget (see <c>IDXGIAdapter3::QueryVideoMemoryInfo</c>), and or system memory may easily occur first.
	/// </para>
	/// <para><i>Alignment</i> must be 64KB (D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT) or 0, which is effectively 64KB.</para>
	/// <para><i>Height</i>, <i>DepthOrArraySize</i>, and <i>MipLevels</i> must be 1.</para>
	/// <para><i>Format</i> must be DXGI_FORMAT_UNKNOWN.</para>
	/// <para><i>SampleDesc.Count</i> must be 1 and <i>Quality</i> must be 0.</para>
	/// <para>
	/// <i>Layout</i> must be D3D12_TEXTURE_LAYOUT_ROW_MAJOR, as buffer memory layouts are understood by applications and row-major texture
	/// data is commonly marshaled through buffers.
	/// </para>
	/// <para>
	/// <i>Flags</i> must still be accurately filled out by applications for buffers, with minor exceptions. However, applications can use
	/// the most amount of capability support without concern about the efficiency impact on buffers. The flags field is meant to control
	/// properties related to textures.
	/// </para>
	/// <para><c></c><c></c><c></c> Textures</para>
	/// <para>
	/// Textures are a multi-dimensional arrangement of texels in a contiguous region of memory, heavily optimized to maximize bandwidth for
	/// rendering and sampling. Texture sizes are hard to predict and vary from adapter to adapter. Applications must use
	/// <c>ID3D12Device::GetResourceAllocationInfo</c> to accurately understand their size.
	/// </para>
	/// <para>
	/// TEXTURE1D, TEXTURE2D, and TEXTURE3D are not supported orthogonally on every format. See the use of D3D12_FORMAT_SUPPORT1_TEXTURE1D,
	/// D3D12_FORMAT_SUPPORT1_TEXTURE2D, and D3D12_FORMAT_SUPPORT1_TEXTURE3D in <c>D3D12_FORMAT_SUPPORT1</c>.
	/// </para>
	/// <para>
	/// <i>Width</i>, <i>Height</i>, and <i>DepthOrArraySize</i> must be between 1 and the maximum dimension supported for the particular
	/// feature level and texture dimension. However, exhaustion of GPU virtual address space, memory residency budget (see
	/// <c>IDXGIAdapter3::QueryVideoMemoryInfo</c>), and or system memory may easily occur first. For compressed formats, these dimensions
	/// are logical. For example:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>For TEXTURE1D:</description>
	/// </item>
	/// <item>
	/// <description>For TEXTURE2D:</description>
	/// </item>
	/// <item>
	/// <description>For TEXTURE3D:</description>
	/// </item>
	/// </list>
	/// <para>The following notes are for all texture sizes.</para>
	/// <para><c></c><c></c><c></c> Alignment</para>
	/// <para><i>Alignment</i> may be one of 0, 4KB, 64KB or 4MB.</para>
	/// <para>
	/// If <i>Alignment</i> is set to 0, the runtime will use 4MB for MSAA textures and 64KB for everything else. The application may choose
	/// smaller alignments than these defaults for a couple of texture types when the texture is small. Textures with UNKNOWN layout and
	/// MSAA may be created with 64KB alignment (if they pass the small size restriction detailed below).
	/// </para>
	/// <para>
	/// Textures with UNKNOWN layout without MSAA and without render-target nor depth-stencil flags may be created with 4KB Alignment
	/// (again, passing the small size restriction).
	/// </para>
	/// <para>
	/// Applications can create smaller aligned resources when the estimated size of the most-detailed mip level is a total of the larger
	/// alignment restriction or less. The runtime will use an architecture-independent mechanism of size-estimation, that mimics the way
	/// standard swizzle and D3D12 tiled resources are sized. However, the tile sizes will be of the smaller alignment restriction for such
	/// calculations. Using the non-render-target and non-depth-stencil texture as an example, the runtime will assume near-equilateral tile
	/// shapes of 4KB, and calculate the number of tiles needed for the most-detailed mip level. If the number of tiles is equal to or less
	/// than 16, then the application can create a 4KB aligned resource. So, a mipped tex2d array of any array size and any number of mip
	/// levels can be 4KB, as long as the width and height are small enough for the particular format and MSAA.
	/// </para>
	/// <para><c></c><c></c><c></c> MipLevels</para>
	/// <para>
	/// <i>MipLevels</i> may be 0, or 1 to the maximum mip levels supported by the <i>Width</i>, <i>Height</i> , and <i>DepthOrArraySize</i>
	/// dimensions. When 0 is used, the API will automatically calculate the maximum mip levels supported and use that. But, some resource
	/// and heap properties preclude mip levels, so the app must specify the value as 1.
	/// </para>
	/// <para>
	/// Refer to the D3D12_FORMAT_SUPPORT1_MIP field of <c>D3D12_FORMAT_SUPPORT1</c> for per-format restrictions. MSAA resources, textures
	/// with D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER, and heaps with D3D12_HEAP_FLAG_ALLOW_DISPLAY all preclude mip levels.
	/// </para>
	/// <para><c></c><c></c><c></c> Format</para>
	/// <para><i>Format</i> must be a valid format supported at the feature level of the device.</para>
	/// <para><c></c><c></c><c></c> SampleDesc</para>
	/// <para>
	/// A <i>SampleDesc.Count</i> greater than 1 and/ or non-zero <i>Quality</i> are only supported for TEXTURE2D and when either
	/// D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET or D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL are set.
	/// </para>
	/// <para>The following are unsupported:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE,</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS,</description>
	/// </item>
	/// <item>
	/// <description>D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS,</description>
	/// </item>
	/// <item>
	/// <description>D3D12_HEAP_FLAG_ALLOW_DISPLAY</description>
	/// </item>
	/// </list>
	/// <para>See <c>D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS</c> for determining valid <i>Count</i> and <i>Quality</i> values.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_desc typedef struct D3D12_RESOURCE_DESC {
	// D3D12_RESOURCE_DIMENSION Dimension; UINT64 Alignment; UINT64 Width; UINT Height; UINT16 DepthOrArraySize; UINT16 MipLevels;
	// DXGI_FORMAT Format; DXGI_SAMPLE_DESC SampleDesc; D3D12_TEXTURE_LAYOUT Layout; D3D12_RESOURCE_FLAGS Flags; } D3D12_RESOURCE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_DESC")]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct D3D12_RESOURCE_DESC(D3D12_RESOURCE_DIMENSION dimension, ulong alignment, ulong width, uint height, ushort depthOrArraySize,
		ushort mipLevels, DXGI_FORMAT format, uint sampleCount, uint sampleQuality, D3D12_TEXTURE_LAYOUT layout, D3D12_RESOURCE_FLAGS flags) : IEquatable<D3D12_RESOURCE_DESC>
	{
		/// <summary>
		/// One member of <c>D3D12_RESOURCE_DIMENSION</c>, specifying the dimensions of the resource (for example,
		/// D3D12_RESOURCE_DIMENSION_TEXTURE1D), or whether it is a buffer ((D3D12_RESOURCE_DIMENSION_BUFFER).
		/// </summary>
		public D3D12_RESOURCE_DIMENSION Dimension = dimension;

		/// <summary>Specifies the alignment.</summary>
		public ulong Alignment = alignment;

		/// <summary>Specifies the width of the resource.</summary>
		public ulong Width = width;

		/// <summary>Specifies the height of the resource.</summary>
		public uint Height = height;

		/// <summary>Specifies the depth of the resource, if it is 3D, or the array size if it is an array of 1D or 2D resources.</summary>
		public ushort DepthOrArraySize = depthOrArraySize;

		/// <summary>Specifies the number of MIP levels.</summary>
		public ushort MipLevels = mipLevels;

		/// <summary>Specifies one member of <c>DXGI_FORMAT</c>.</summary>
		public DXGI_FORMAT Format = format;

		/// <summary>Specifies a <c>DXGI_SAMPLE_DESC</c> structure.</summary>
		public DXGI_SAMPLE_DESC SampleDesc = new() { Count = sampleCount, Quality = sampleQuality };

		/// <summary>Specifies one member of <c>D3D12_TEXTURE_LAYOUT</c>.</summary>
		public D3D12_TEXTURE_LAYOUT Layout = layout;

		/// <summary>Bitwise-OR'd flags, as <c>D3D12_RESOURCE_FLAGS</c> enumeration constants.</summary>
		public D3D12_RESOURCE_FLAGS Flags = flags;

		internal static uint D3D12CalcSubresource(uint MipSlice, uint ArraySlice, uint PlaneSlice, uint MipLevels, uint ArraySize) =>
			MipSlice + ArraySlice * MipLevels + PlaneSlice * MipLevels * ArraySize;

		internal static byte D3D12GetFormatPlaneCount([In] ID3D12Device pDevice, DXGI_FORMAT Format)
		{
			D3D12_FEATURE_DATA_FORMAT_INFO formatInfo = new() { Format = Format };
			return pDevice.CheckFeatureSupport(ref formatInfo, D3D12_FEATURE.D3D12_FEATURE_FORMAT_INFO).Failed ? (byte)0 : formatInfo.PlaneCount;
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_RESOURCE_DESC desc && Equals(desc);

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_RESOURCE_DESC other) => Dimension == other.Dimension && Alignment == other.Alignment && Width == other.Width &&
			Height == other.Height && DepthOrArraySize == other.DepthOrArraySize && MipLevels == other.MipLevels && Format == other.Format &&
			EqualityComparer<DXGI_SAMPLE_DESC>.Default.Equals(SampleDesc, other.SampleDesc) && Layout == other.Layout && Flags == other.Flags;

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_RESOURCE_DESC left, D3D12_RESOURCE_DESC right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_RESOURCE_DESC left, D3D12_RESOURCE_DESC right) => !(left == right);

		/// <summary>Creates a buffer instance.</summary>
		/// <param name="resAllocInfo">The resource alloc information.</param>
		/// <param name="flags">The flags.</param>
		/// <returns></returns>
		public static D3D12_RESOURCE_DESC Buffer(in D3D12_RESOURCE_ALLOCATION_INFO resAllocInfo, D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE) =>
			new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, resAllocInfo.Alignment, resAllocInfo.SizeInBytes,
				1, 1, 1, DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, 1, 0, D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR, flags);

		/// <summary>Creates a buffer instance.</summary>
		/// <param name="width">The width.</param>
		/// <param name="flags">The flags.</param>
		/// <param name="alignment">The alignment.</param>
		/// <returns></returns>
		public static D3D12_RESOURCE_DESC Buffer(ulong width, D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE, ulong alignment = 0) =>
			new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, alignment, width, 1, 1, 1,
				DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, 1, 0, D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR, flags);

		/// <summary>Creates a 1D texture instance.</summary>
		/// <param name="format">The format.</param>
		/// <param name="width">The width.</param>
		/// <param name="arraySize">Size of the array.</param>
		/// <param name="mipLevels">The mip levels.</param>
		/// <param name="flags">The flags.</param>
		/// <param name="layout">The layout.</param>
		/// <param name="alignment">The alignment.</param>
		/// <returns></returns>
		public static D3D12_RESOURCE_DESC Tex1D(DXGI_FORMAT format, ulong width, ushort arraySize = 1, ushort mipLevels = 0,
			D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE,
			D3D12_TEXTURE_LAYOUT layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN, ulong alignment = 0) =>
			new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE1D, alignment, width, 1, arraySize,
			mipLevels, format, 1, 0, layout, flags);

		/// <summary>Creates a 2D texture instance.</summary>
		/// <param name="format">The format.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="arraySize">Size of the array.</param>
		/// <param name="mipLevels">The mip levels.</param>
		/// <param name="sampleCount">The sample count.</param>
		/// <param name="sampleQuality">The sample quality.</param>
		/// <param name="flags">The flags.</param>
		/// <param name="layout">The layout.</param>
		/// <param name="alignment">The alignment.</param>
		/// <returns></returns>
		public static D3D12_RESOURCE_DESC Tex2D(DXGI_FORMAT format, ulong width, uint height, ushort arraySize = 1, ushort mipLevels = 0,
			uint sampleCount = 1, uint sampleQuality = 0, D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE,
			D3D12_TEXTURE_LAYOUT layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN, ulong alignment = 0) =>
			new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE2D, alignment, width, height, arraySize,
			mipLevels, format, sampleCount, sampleQuality, layout, flags);

		/// <summary>Creates a 3D texture instance.</summary>
		/// <param name="format">The format.</param>
		/// <param name="width">The width.</param>
		/// <param name="height">The height.</param>
		/// <param name="depth">The depth.</param>
		/// <param name="mipLevels">The mip levels.</param>
		/// <param name="flags">The flags.</param>
		/// <param name="layout">The layout.</param>
		/// <param name="alignment">The alignment.</param>
		/// <returns></returns>
		public static D3D12_RESOURCE_DESC Tex3D(DXGI_FORMAT format, ulong width, uint height, ushort depth, ushort mipLevels = 0,
			D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE,
			D3D12_TEXTURE_LAYOUT layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN, ulong alignment = 0) =>
			new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D, alignment, width, height, depth,
			mipLevels, format, 1, 0, layout, flags);

		/// <summary>Gets the depth.</summary>
		public ushort Depth => (ushort)(Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D ? DepthOrArraySize : 1u);

		/// <summary>Gets the size of the array.</summary>
		public ushort ArraySize => (ushort)(Dimension != D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D ? DepthOrArraySize : 1u);

		/// <summary>Gets the number of planes.</summary>
		public byte PlaneCount([In] ID3D12Device pDevice) => D3D12GetFormatPlaneCount(pDevice, Format);

		/// <summary>Get the number of subresourceses.</summary>
		public uint Subresources([In] ID3D12Device pDevice) => (uint)MipLevels * ArraySize * PlaneCount(pDevice);

		/// <summary>Calculates a subresource index.</summary>
		public uint CalcSubresource(uint MipSlice, uint ArraySlice, uint PlaneSlice) => D3D12CalcSubresource(MipSlice, ArraySlice, PlaneSlice, MipLevels, ArraySize);

		/// <inheritdoc/>
		public override int GetHashCode() => (Dimension, Alignment, Width, Height, DepthOrArraySize, MipLevels, Format, SampleDesc, Layout, Flags).GetHashCode();
	}

	/// <summary>Describes a resource, such as a texture, including a mip region. This structure is used in several methods.</summary>
	/// <remarks>For remarks, see <c>D3D12_RESOURCE_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_desc1 typedef struct D3D12_RESOURCE_DESC1 {
	// D3D12_RESOURCE_DIMENSION Dimension; UINT64 Alignment; UINT64 Width; UINT Height; UINT16 DepthOrArraySize; UINT16 MipLevels;
	// DXGI_FORMAT Format; DXGI_SAMPLE_DESC SampleDesc; D3D12_TEXTURE_LAYOUT Layout; D3D12_RESOURCE_FLAGS Flags; D3D12_MIP_REGION
	// SamplerFeedbackMipRegion; } D3D12_RESOURCE_DESC1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_DESC1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_DESC1(D3D12_RESOURCE_DIMENSION dimension, ulong alignment, ulong width, uint height, ushort depthOrArraySize,
		ushort mipLevels, DXGI_FORMAT format, uint sampleCount, uint sampleQuality, D3D12_TEXTURE_LAYOUT layout, D3D12_RESOURCE_FLAGS flags,
		uint samplerFeedbackMipRegionWidth = 0, uint samplerFeedbackMipRegionHeight = 0, uint samplerFeedbackMipRegionDepth = 0) : IEquatable<D3D12_RESOURCE_DESC1>
	{
		/// <summary>
		/// One member of <c>D3D12_RESOURCE_DIMENSION</c>, specifying the dimensions of the resource (for example,
		/// D3D12_RESOURCE_DIMENSION_TEXTURE1D), or whether it is a buffer ((D3D12_RESOURCE_DIMENSION_BUFFER).
		/// </summary>
		public D3D12_RESOURCE_DIMENSION Dimension = dimension;

		/// <summary>Specifies the alignment.</summary>
		public ulong Alignment = alignment;

		/// <summary>Specifies the width of the resource.</summary>
		public ulong Width = width;

		/// <summary>Specifies the height of the resource.</summary>
		public uint Height = height;

		/// <summary>Specifies the depth of the resource, if it is 3D, or the array size if it is an array of 1D or 2D resources.</summary>
		public ushort DepthOrArraySize = depthOrArraySize;

		/// <summary>Specifies the number of MIP levels.</summary>
		public ushort MipLevels = mipLevels;

		/// <summary>Specifies one member of <c>DXGI_FORMAT</c>.</summary>
		public DXGI_FORMAT Format = format;

		/// <summary>Specifies a <c>DXGI_SAMPLE_DESC</c> structure.</summary>
		public DXGI_SAMPLE_DESC SampleDesc = new() { Count = sampleCount, Quality = sampleQuality };

		/// <summary>Specifies one member of <c>D3D12_TEXTURE_LAYOUT</c>.</summary>
		public D3D12_TEXTURE_LAYOUT Layout = layout;

		/// <summary>Bitwise-OR'd flags, as <c>D3D12_RESOURCE_FLAGS</c> enumeration constants.</summary>
		public D3D12_RESOURCE_FLAGS Flags = flags;

		/// <summary>A <c>D3D12_MIP_REGION</c> struct.</summary>
		public D3D12_MIP_REGION SamplerFeedbackMipRegion = new() { Width = samplerFeedbackMipRegionWidth, Height = samplerFeedbackMipRegionHeight, Depth = samplerFeedbackMipRegionDepth };

		/// <summary>Initializes a new instance of the <see cref="D3D12_RESOURCE_DESC1"/> struct.</summary>
		/// <param name="desc">A <see cref="D3D12_RESOURCE_DESC"/> instance.</param>
		public D3D12_RESOURCE_DESC1(in D3D12_RESOURCE_DESC desc) : this(desc.Dimension, desc.Alignment, desc.Width, desc.Height,
			desc.DepthOrArraySize, desc.MipLevels, desc.Format, desc.SampleDesc.Count, desc.SampleDesc.Quality, desc.Layout, desc.Flags)
		{ }

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is D3D12_RESOURCE_DESC1 desc && Equals(desc);

		/// <summary>Determines whether the specified object is equal to the current object.</summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public bool Equals(D3D12_RESOURCE_DESC1 other) => Dimension == other.Dimension && Alignment == other.Alignment && Width == other.Width &&
			Height == other.Height && DepthOrArraySize == other.DepthOrArraySize && MipLevels == other.MipLevels && Format == other.Format &&
			EqualityComparer<DXGI_SAMPLE_DESC>.Default.Equals(SampleDesc, other.SampleDesc) && Layout == other.Layout && Flags == other.Flags &&
			EqualityComparer<D3D12_MIP_REGION>.Default.Equals(SamplerFeedbackMipRegion, other.SamplerFeedbackMipRegion);

		/// <summary>Implements the operator op_Equality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(D3D12_RESOURCE_DESC1 left, D3D12_RESOURCE_DESC1 right) => left.Equals(right);

		/// <summary>Implements the operator op_Inequality.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(D3D12_RESOURCE_DESC1 left, D3D12_RESOURCE_DESC1 right) => !(left == right);

		/// <summary>Creates a buffer instance.</summary>
		public static D3D12_RESOURCE_DESC1 Buffer(in D3D12_RESOURCE_ALLOCATION_INFO resAllocInfo, D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE) => new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, resAllocInfo.Alignment, resAllocInfo.SizeInBytes,
				1, 1, 1, DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, 1, 0, D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR, flags);

		/// <summary>Creates a buffer instance.</summary>
		public static D3D12_RESOURCE_DESC1 Buffer(ulong width, D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE, ulong alignment = 0) => new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER, alignment, width, 1, 1, 1,
			DXGI_FORMAT.DXGI_FORMAT_UNKNOWN, 1, 0, D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR, flags);

		/// <summary>Creates a 1D texture instance.</summary>
		public static D3D12_RESOURCE_DESC1 Tex1D(DXGI_FORMAT format, ulong width, ushort arraySize = 1, ushort mipLevels = 0,
			D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE,
			D3D12_TEXTURE_LAYOUT layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN, ulong alignment = 0) => new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE1D, alignment, width, 1, arraySize,
			mipLevels, format, 1, 0, layout, flags);

		/// <summary>Creates a 2D texture instance.</summary>
		public static D3D12_RESOURCE_DESC1 Tex2D(DXGI_FORMAT format, ulong width, uint height, ushort arraySize = 1, ushort mipLevels = 0,
			uint sampleCount = 1, uint sampleQuality = 0, D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE,
			D3D12_TEXTURE_LAYOUT layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN, ulong alignment = 0,
			uint samplerFeedbackMipRegionWidth = 0, uint samplerFeedbackMipRegionHeight = 0, uint samplerFeedbackMipRegionDepth = 0) => new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE2D, alignment, width, height, arraySize,
			mipLevels, format, sampleCount, sampleQuality, layout, flags, samplerFeedbackMipRegionWidth, samplerFeedbackMipRegionHeight, samplerFeedbackMipRegionDepth);

		/// <summary>Creates a 3D texture instance.</summary>
		public static D3D12_RESOURCE_DESC1 Tex3D(DXGI_FORMAT format, ulong width, uint height, ushort depth, ushort mipLevels = 0,
			D3D12_RESOURCE_FLAGS flags = D3D12_RESOURCE_FLAGS.D3D12_RESOURCE_FLAG_NONE,
			D3D12_TEXTURE_LAYOUT layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_UNKNOWN, ulong alignment = 0) => new(D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D, alignment, width, height, depth,
			mipLevels, format, 1, 0, layout, flags);

		/// <summary>Gets the depth.</summary>
		public ushort Depth => (ushort)(Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D ? DepthOrArraySize : 1u);

		/// <summary>Gets the size of the array.</summary>
		public ushort ArraySize => (ushort)(Dimension != D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D ? DepthOrArraySize : 1u);

		/// <summary>Gets the number of planes.</summary>
		public byte PlaneCount([In] ID3D12Device pDevice) => D3D12_RESOURCE_DESC.D3D12GetFormatPlaneCount(pDevice, Format);

		/// <summary>Get the number of subresourceses.</summary>
		public uint Subresources([In] ID3D12Device pDevice) => (uint)MipLevels * ArraySize * PlaneCount(pDevice);

		/// <summary>Calculates a subresource index.</summary>
		public uint CalcSubresource(uint MipSlice, uint ArraySlice, uint PlaneSlice) => D3D12_RESOURCE_DESC.D3D12CalcSubresource(MipSlice, ArraySlice, PlaneSlice, MipLevels, ArraySize);

		/// <inheritdoc/>
		public override int GetHashCode() => (Dimension, Alignment, Width, Height, DepthOrArraySize, MipLevels, Format, SampleDesc, Layout, Flags, SamplerFeedbackMipRegion).GetHashCode();

		/// <summary>
		/// Fills in the mipmap and alignment values of pDesc when either members are zero. Used to replace an implicit field to an explicit
		/// (0 mip map = max mip map level). If expansion has occured, returns LclDesc, else returns the original pDesc
		/// </summary>
		public static ref readonly D3D12_RESOURCE_DESC1 D3DX12ConditionallyExpandAPIDesc(ref D3D12_RESOURCE_DESC1 LclDesc, in D3D12_RESOURCE_DESC1 pDesc)
		{
			if (pDesc.MipLevels == 0 || pDesc.Alignment == 0)
			{
				LclDesc = pDesc;

				if (pDesc.MipLevels == 0)
				{
					ulong uiMaxDimension = Math.Max((LclDesc.Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D) ? LclDesc.DepthOrArraySize : 1UL, Math.Max(LclDesc.Width, LclDesc.Height));
					ushort uiRet = 0;

					while (uiMaxDimension > 0)
					{
						uiRet++;
						uiMaxDimension >>= 1;
					}

					LclDesc.MipLevels = uiRet;
				}

				if (pDesc.Alignment == 0)
				{
					LclDesc.Alignment = pDesc.Layout is D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE or D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE
						? D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT
						: (pDesc.SampleDesc.Count > 1) ? D3D12_DEFAULT_MSAA_RESOURCE_PLACEMENT_ALIGNMENT : (ulong)D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT;
				}

				return ref LclDesc;
			}
			else
			{
				return ref pDesc;
			}
		}
	}

	/// <summary>Describes the transition of subresources between different usages.</summary>
	/// <remarks>This struct is used by the <b>Transition</b> member of the <c>D3D12_RESOURCE_BARRIER</c> struct.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_transition_barrier typedef struct
	// D3D12_RESOURCE_TRANSITION_BARRIER { ID3D12Resource *pResource; UINT Subresource; D3D12_RESOURCE_STATES StateBefore;
	// D3D12_RESOURCE_STATES StateAfter; } D3D12_RESOURCE_TRANSITION_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_TRANSITION_BARRIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_TRANSITION_BARRIER
	{
		/// <summary>A pointer to the <c>ID3D12Resource</c> object that represents the resource used in the transition.</summary>
		public IUnknownPointer<ID3D12Resource> pResource;

		/// <summary>
		/// The index of the subresource for the transition. Use the <b>D3D12_RESOURCE_BARRIER_ALL_SUBRESOURCES</b> flag ( 0xffffffff ) to
		/// transition all subresources in a resource at the same time.
		/// </summary>
		public uint Subresource;

		/// <summary>
		/// The "before" usages of the subresources, as a bitwise-OR'd combination of <c>D3D12_RESOURCE_STATES</c> enumeration constants.
		/// </summary>
		public D3D12_RESOURCE_STATES StateBefore;

		/// <summary>
		/// The "after" usages of the subresources, as a bitwise-OR'd combination of <c>D3D12_RESOURCE_STATES</c> enumeration constants.
		/// </summary>
		public D3D12_RESOURCE_STATES StateAfter;
	}

	/// <summary>Represents a resource in which all UAV accesses must complete before any future UAV accesses can begin.</summary>
	/// <remarks>
	/// <para>
	/// This struct represents a resource in which all unordered access view (UAV) accesses (reads or writes) must complete before any
	/// future UAV accesses (read or write) can begin.
	/// </para>
	/// <para>This structure is a member of the <c>D3D12_RESOURCE_BARRIER</c> structure.</para>
	/// <para>
	/// You don't need to insert a UAV barrier between 2 draw or dispatch calls that only read a UAV. Additionally, you don't need to insert
	/// a UAV barrier between 2 draw or dispatch calls that write to the same UAV if you know that it's safe to execute the UAV accesses in
	/// any order. The resource can be <b>NULL</b>, which indicates that any UAV access could require the barrier.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_uav_barrier typedef struct
	// D3D12_RESOURCE_UAV_BARRIER { ID3D12Resource *pResource; } D3D12_RESOURCE_UAV_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RESOURCE_UAV_BARRIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RESOURCE_UAV_BARRIER
	{
		/// <summary>The resource used in the transition, as a pointer to <c>ID3D12Resource</c>.</summary>
		public IUnknownPointer<ID3D12Resource> pResource;
	}

	/// <summary>Describes constants inline in the root signature that appear in shaders as one constant buffer.</summary>
	/// <remarks>
	/// <para>Refer to <c>Resource Binding in HLSL</c> for more information on shader registers and spaces.</para>
	/// <para>
	/// <b>D3D12_ROOT_CONSTANTS</b> is the data type of the <b>Constants</b> member of <c>D3D12_ROOT_PARAMETER</c>. Use a
	/// <b>D3D12_ROOT_CONSTANTS</b> when you set <b>D3D12_ROOT_PARAMETER</b>'s <b>SlotType</b> field to the
	/// D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS member of <c>D3D12_ROOT_PARAMETER_TYPE</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_constants typedef struct D3D12_ROOT_CONSTANTS { UINT
	// ShaderRegister; UINT RegisterSpace; UINT Num32BitValues; } D3D12_ROOT_CONSTANTS;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_CONSTANTS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_CONSTANTS(uint shaderRegister, uint registerSpace, uint num32BitValues)
	{
		/// <summary>The shader register.</summary>
		public uint ShaderRegister = shaderRegister;

		/// <summary>The register space.</summary>
		public uint RegisterSpace = registerSpace;

		/// <summary>
		/// The number of constants that occupy a single shader slot (these constants appear like a single constant buffer). All constants
		/// occupy a single root signature bind slot.
		/// </summary>
		public uint Num32BitValues = num32BitValues;
	}

	/// <summary>Describes descriptors inline in the root signature version 1.0 that appear in shaders.</summary>
	/// <remarks>
	/// <b>D3D12_ROOT_DESCRIPTOR</b> is the data type of the <b>Descriptor</b> member of <c>D3D12_ROOT_PARAMETER</c>. Use a
	/// <b>D3D12_ROOT_DESCRIPTOR</b> when you set <b>D3D12_ROOT_PARAMETER</b>'s <b>ParameterType</b> field to the
	/// D3D12_ROOT_PARAMETER_TYPE_CBV, D3D12_ROOT_PARAMETER_TYPE_SRV, or D3D12_ROOT_PARAMETER_TYPE_UAV members of <c>D3D12_ROOT_PARAMETER_TYPE</c>.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_descriptor typedef struct D3D12_ROOT_DESCRIPTOR { UINT
	// ShaderRegister; UINT RegisterSpace; } D3D12_ROOT_DESCRIPTOR;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_DESCRIPTOR(uint shaderRegister, uint registerSpace)
	{
		/// <summary>The shader register.</summary>
		public uint ShaderRegister = shaderRegister;

		/// <summary>The register space.</summary>
		public uint RegisterSpace = registerSpace;
	}

	/// <summary>
	/// Describes the root signature 1.0 layout of a descriptor table as a collection of descriptor ranges that are all relative to a single
	/// base descriptor handle.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Samplers are not allowed in the same descriptor table as constant-buffer views (CBVs), unordered-access views (UAVs), and
	/// shader-resource views (SRVs).
	/// </para>
	/// <para>
	/// <b>D3D12_ROOT_DESCRIPTOR_TABLE</b> is the data type of the <b>DescriptorTable</b> member of <c>D3D12_ROOT_PARAMETER</c>. Use a
	/// <b>D3D12_ROOT_DESCRIPTOR_TABLE</b> when you set <b>D3D12_ROOT_PARAMETER</b>'s <b>ParameterType</b> member to <c>D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_descriptor_table typedef struct
	// D3D12_ROOT_DESCRIPTOR_TABLE { UINT NumDescriptorRanges; const D3D12_DESCRIPTOR_RANGE *pDescriptorRanges; } D3D12_ROOT_DESCRIPTOR_TABLE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_DESCRIPTOR_TABLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_DESCRIPTOR_TABLE
	{
		/// <summary>The number of descriptor ranges in the table layout.</summary>
		public uint NumDescriptorRanges;

		/// <summary>An array of <c>D3D12_DESCRIPTOR_RANGE</c> structures that describe the descriptor ranges.</summary>
		public ArrayPointer<D3D12_DESCRIPTOR_RANGE> pDescriptorRanges;

		/// <summary>Creates a new instance of a D3D12_ROOT_DESCRIPTOR_TABLE.</summary>
		/// <param name="ranges">The descriptor ranges.</param>
		/// <param name="h">The allocated memory holding the data in <paramref name="ranges"/>.</param>
		/// <returns>An initialized D3D12_ROOT_DESCRIPTOR_TABLE.</returns>
		public static D3D12_ROOT_DESCRIPTOR_TABLE Init(D3D12_DESCRIPTOR_RANGE[] ranges, out SafeAllocatedMemoryHandle h) =>
			new() { NumDescriptorRanges = (uint)ranges.Length, pDescriptorRanges = h = SafeCoTaskMemHandle.CreateFromList(ranges) };

		/// <summary>Creates a new instance of a D3D12_ROOT_DESCRIPTOR_TABLE.</summary>
		/// <param name="numRanges">The number of descriptor ranges in the table layout.</param>
		/// <param name="ranges">The descriptor ranges.</param>
		/// <returns>An initialized D3D12_ROOT_DESCRIPTOR_TABLE.</returns>
		public static D3D12_ROOT_DESCRIPTOR_TABLE Init(SizeT numRanges, ArrayPointer<D3D12_DESCRIPTOR_RANGE> ranges) =>
			new() { NumDescriptorRanges = numRanges, pDescriptorRanges = ranges };
	}

	/// <summary>
	/// Describes the root signature 1.1 layout of a descriptor table as a collection of descriptor ranges that are all relative to a single
	/// base descriptor handle.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Samplers are not allowed in the same descriptor table as constant-buffer views (CBVs), unordered-access views (UAVs), and
	/// shader-resource views (SRVs).
	/// </para>
	/// <para>
	/// <b>D3D12_ROOT_DESCRIPTOR_TABLE1</b> is the data type of the <b>DescriptorTable</b> member of <c>D3D12_ROOT_PARAMETER1</c>. Use a
	/// <b>D3D12_ROOT_DESCRIPTOR_TABLE1</b> when you set <b>D3D12_ROOT_PARAMETER1</b>'s <b>SlotType</b> member to <c>D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE</c>.
	/// </para>
	/// <para>Refer to the helper structure <c>CD3DX12_ROOT_DESCRIPTOR_TABLE1</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_descriptor_table1 typedef struct
	// D3D12_ROOT_DESCRIPTOR_TABLE1 { UINT NumDescriptorRanges; const D3D12_DESCRIPTOR_RANGE1 *pDescriptorRanges; } D3D12_ROOT_DESCRIPTOR_TABLE1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_DESCRIPTOR_TABLE1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_DESCRIPTOR_TABLE1
	{
		/// <summary>The number of descriptor ranges in the table layout.</summary>
		public uint NumDescriptorRanges;

		/// <summary>An array of <c>D3D12_DESCRIPTOR_RANGE1</c> structures that describe the descriptor ranges.</summary>
		public ArrayPointer<D3D12_DESCRIPTOR_RANGE1> pDescriptorRanges;

		/// <summary>Creates a new instance of a D3D12_ROOT_DESCRIPTOR_TABLE1.</summary>
		/// <param name="ranges">The descriptor ranges.</param>
		/// <param name="h">The allocated memory holding the data in <paramref name="ranges"/>.</param>
		/// <returns>An initialized D3D12_ROOT_DESCRIPTOR_TABLE1.</returns>
		public static D3D12_ROOT_DESCRIPTOR_TABLE1 Init(D3D12_DESCRIPTOR_RANGE1[] ranges, out SafeAllocatedMemoryHandle h) =>
			new() { NumDescriptorRanges = (uint)ranges.Length, pDescriptorRanges = h = SafeCoTaskMemHandle.CreateFromList(ranges) };

		/// <summary>Creates a new instance of a D3D12_ROOT_DESCRIPTOR_TABLE1.</summary>
		/// <param name="numRanges">The number of descriptor ranges in the table layout.</param>
		/// <param name="ranges">The descriptor ranges.</param>
		/// <returns>An initialized D3D12_ROOT_DESCRIPTOR_TABLE1.</returns>
		public static D3D12_ROOT_DESCRIPTOR_TABLE1 Init(SizeT numRanges, ArrayPointer<D3D12_DESCRIPTOR_RANGE1> ranges) =>
			new() { NumDescriptorRanges = numRanges, pDescriptorRanges = ranges };
	}

	/// <summary>Describes descriptors inline in the root signature version 1.1 that appear in shaders.</summary>
	/// <remarks>
	/// <para>
	/// <b>D3D12_ROOT_DESCRIPTOR1</b> is the data type of the <b>Descriptor</b> member of <c>D3D12_ROOT_PARAMETER1</c>. Use a
	/// <b>D3D12_ROOT_DESCRIPTOR1</b> when you set <b>D3D12_ROOT_PARAMETER1</b>'s <b>ParameterType</b> field to the
	/// D3D12_ROOT_PARAMETER_TYPE_CBV, D3D12_ROOT_PARAMETER_TYPE_SRV, or D3D12_ROOT_PARAMETER_TYPE_UAV members of <c>D3D12_ROOT_PARAMETER_TYPE</c>.
	/// </para>
	/// <para>Refer to the helper structure <c>CD3DX12_ROOT_DESCRIPTOR1</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_descriptor1 typedef struct D3D12_ROOT_DESCRIPTOR1 {
	// UINT ShaderRegister; UINT RegisterSpace; D3D12_ROOT_DESCRIPTOR_FLAGS Flags; } D3D12_ROOT_DESCRIPTOR1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_DESCRIPTOR1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_DESCRIPTOR1(uint shaderRegister, uint registerSpace, D3D12_ROOT_DESCRIPTOR_FLAGS flags)
	{
		/// <summary>The shader register.</summary>
		public uint ShaderRegister = shaderRegister;

		/// <summary>The register space.</summary>
		public uint RegisterSpace = registerSpace;

		/// <summary>
		/// Specifies the <c>D3D12_ROOT_DESCRIPTOR_FLAGS</c> that determine the volatility of descriptors and the data they reference.
		/// </summary>
		public D3D12_ROOT_DESCRIPTOR_FLAGS Flags = flags;

		/// <summary>Performs an implicit conversion from <see cref="Vanara.PInvoke.D3D12.D3D12_ROOT_DESCRIPTOR1"/> to <see cref="Vanara.PInvoke.D3D12.D3D12_ROOT_DESCRIPTOR"/>.</summary>
		/// <param name="rd">The D3D12_ROOT_DESCRIPTOR1.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D3D12_ROOT_DESCRIPTOR(D3D12_ROOT_DESCRIPTOR1 rd) => new(rd.ShaderRegister, rd.RegisterSpace);
	}

	/// <summary>Describes the slot of a root signature version 1.0.</summary>
	/// <remarks>
	/// A <c>D3D12_ROOT_SIGNATURE_DESC</c> can contain descriptor tables and inline constants. More capable hardware could support inline
	/// descriptors in the root signature as well. The number of bind slots in the root signature are most efficient if kept below a certain
	/// size, and can have an upper bound as well.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_parameter typedef struct D3D12_ROOT_PARAMETER {
	// D3D12_ROOT_PARAMETER_TYPE ParameterType; union { D3D12_ROOT_DESCRIPTOR_TABLE DescriptorTable; D3D12_ROOT_CONSTANTS Constants;
	// D3D12_ROOT_DESCRIPTOR Descriptor; }; D3D12_SHADER_VISIBILITY ShaderVisibility; } D3D12_ROOT_PARAMETER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_PARAMETER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_PARAMETER
	{
		/// <summary>
		/// A <c>D3D12_ROOT_PARAMETER_TYPE</c>-typed value that specifies the type of root signature slot. This member determines which type
		/// to use in the union below.
		/// </summary>
		public D3D12_ROOT_PARAMETER_TYPE ParameterType;

		private UNION u;

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public D3D12_ROOT_DESCRIPTOR_TABLE DescriptorTable;

			[FieldOffset(0)]
			public D3D12_ROOT_CONSTANTS Constants;

			[FieldOffset(0)]
			public D3D12_ROOT_DESCRIPTOR Descriptor;
		}

		/// <summary>
		/// A <c>D3D12_SHADER_VISIBILITY</c>-typed value that specifies the shaders that can access the contents of the root signature slot.
		/// </summary>
		public D3D12_SHADER_VISIBILITY ShaderVisibility;

		/// <summary>
		/// A <c>D3D12_ROOT_DESCRIPTOR_TABLE</c> structure that describes the layout of a descriptor table as a collection of descriptor
		/// ranges that appear one after the other in a descriptor heap.
		/// </summary>
		public D3D12_ROOT_DESCRIPTOR_TABLE DescriptorTable { readonly get => u.DescriptorTable; set => u = new UNION { DescriptorTable = value }; }

		/// <summary>
		/// A <c>D3D12_ROOT_CONSTANTS</c> structure that describes constants inline in the root signature that appear in shaders as one
		/// constant buffer.
		/// </summary>
		public D3D12_ROOT_CONSTANTS Constants { readonly get => u.Constants; set => u = new UNION { Constants = value }; }

		/// <summary>
		/// A <c>D3D12_ROOT_DESCRIPTOR</c> structure that describes descriptors inline in the root signature that appear in shaders.
		/// </summary>
		public D3D12_ROOT_DESCRIPTOR Descriptor { readonly get => u.Descriptor; set => u = new UNION { Descriptor = value }; }

		/// <summary>Initializes with a descriptor table.</summary>
		/// <param name="pDescriptorRanges">The descriptor ranges.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <param name="h">The allocated memory for <paramref name="pDescriptorRanges"/>.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER"/>.</returns>
		public static D3D12_ROOT_PARAMETER InitAsDescriptorTable([In] D3D12_DESCRIPTOR_RANGE[] pDescriptorRanges,
			[Optional] D3D12_SHADER_VISIBILITY visibility, out SafeAllocatedMemoryHandle h) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE,
				ShaderVisibility = visibility,
				u = new() { DescriptorTable = D3D12_ROOT_DESCRIPTOR_TABLE.Init(pDescriptorRanges, out h) }
			};

		/// <summary>Initializes with a descriptor table.</summary>
		/// <param name="numRanges">The number of descriptor ranges in the table layout.</param>
		/// <param name="pDescriptorRanges">The descriptor ranges.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER"/>.</returns>
		public static D3D12_ROOT_PARAMETER InitAsDescriptorTable(SizeT numRanges, [In] ArrayPointer<D3D12_DESCRIPTOR_RANGE> pDescriptorRanges,
			[Optional] D3D12_SHADER_VISIBILITY visibility) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE,
				ShaderVisibility = visibility,
				u = new() { DescriptorTable = D3D12_ROOT_DESCRIPTOR_TABLE.Init(numRanges, pDescriptorRanges) }
			};

		/// <summary>Initializes with constants.</summary>
		/// <param name="num32BitValues">
		/// The number of constants that occupy a single shader slot (these constants appear like a single constant buffer). All constants
		/// occupy a single root signature bind slot.
		/// </param>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER"/>.</returns>
		public static D3D12_ROOT_PARAMETER InitAsConstants(uint num32BitValues, uint shaderRegister, uint registerSpace = 0,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS,
				ShaderVisibility = visibility,
				u = new() { Constants = new(shaderRegister, registerSpace, num32BitValues) }
			};

		/// <summary>Initializes with constants for a buffer view.</summary>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER"/>.</returns>
		public static D3D12_ROOT_PARAMETER InitAsConstantBufferView(uint shaderRegister, uint registerSpace = 0,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_CBV,
				ShaderVisibility = visibility,
				u = new() { Descriptor = new(shaderRegister, registerSpace) }
			};

		/// <summary>Initializes with constants for a shader view.</summary>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER"/>.</returns>
		public static D3D12_ROOT_PARAMETER InitAsShaderResourceView(uint shaderRegister, uint registerSpace = 0,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_SRV,
				ShaderVisibility = visibility,
				u = new() { Descriptor = new(shaderRegister, registerSpace) }
			};

		/// <summary>Initializes with constants for an access view.</summary>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER"/>.</returns>
		public static D3D12_ROOT_PARAMETER InitAsUnorderedAccessView(uint shaderRegister, uint registerSpace = 0,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_UAV,
				ShaderVisibility = visibility,
				u = new() { Descriptor = new(shaderRegister, registerSpace) }
			};
	}

	/// <summary>Describes the slot of a root signature version 1.1.</summary>
	/// <remarks>
	/// <para>Use this structure with the <c>D3D12_ROOT_SIGNATURE_DESC1</c> structure.</para>
	/// <para>Refer to the helper structure <c>CD3DX12_ROOT_PARAMETER1</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_parameter1 typedef struct D3D12_ROOT_PARAMETER1 {
	// D3D12_ROOT_PARAMETER_TYPE ParameterType; union { D3D12_ROOT_DESCRIPTOR_TABLE1 DescriptorTable; D3D12_ROOT_CONSTANTS Constants;
	// D3D12_ROOT_DESCRIPTOR1 Descriptor; }; D3D12_SHADER_VISIBILITY ShaderVisibility; } D3D12_ROOT_PARAMETER1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_PARAMETER1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_PARAMETER1
	{
		/// <summary>
		/// A <c>D3D12_ROOT_PARAMETER_TYPE</c>-typed value that specifies the type of root signature slot. This member determines which type
		/// to use in the union below.
		/// </summary>
		public D3D12_ROOT_PARAMETER_TYPE ParameterType;

		private UNION u;

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public D3D12_ROOT_DESCRIPTOR_TABLE1 DescriptorTable;

			[FieldOffset(0)]
			public D3D12_ROOT_CONSTANTS Constants;

			[FieldOffset(0)]
			public D3D12_ROOT_DESCRIPTOR1 Descriptor;
		}

		/// <summary>
		/// A <c>D3D12_SHADER_VISIBILITY</c>-typed value that specifies the shaders that can access the contents of the root signature slot.
		/// </summary>
		public D3D12_SHADER_VISIBILITY ShaderVisibility;

		/// <summary>
		/// A <c>D3D12_ROOT_DESCRIPTOR_TABLE1</c> structure that describes the layout of a descriptor table as a collection of descriptor
		/// ranges that appear one after the other in a descriptor heap.
		/// </summary>
		public D3D12_ROOT_DESCRIPTOR_TABLE1 DescriptorTable { readonly get => u.DescriptorTable; set => u = new UNION { DescriptorTable = value }; }

		/// <summary>
		/// A <c>D3D12_ROOT_CONSTANTS</c> structure that describes constants inline in the root signature that appear in shaders as one
		/// constant buffer.
		/// </summary>
		public D3D12_ROOT_CONSTANTS Constants { readonly get => u.Constants; set => u = new UNION { Constants = value }; }

		/// <summary>
		/// A <c>D3D12_ROOT_DESCRIPTOR1</c> structure that describes descriptors inline in the root signature that appear in shaders.
		/// </summary>
		public D3D12_ROOT_DESCRIPTOR1 Descriptor { readonly get => u.Descriptor; set => u = new UNION { Descriptor = value }; }

		/// <summary>Initializes with a descriptor table.</summary>
		/// <param name="pDescriptorRanges">The descriptor ranges.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <param name="h">The allocated memory for <paramref name="pDescriptorRanges"/>.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER1"/>.</returns>
		public static D3D12_ROOT_PARAMETER1 InitAsDescriptorTable([In] D3D12_DESCRIPTOR_RANGE1[] pDescriptorRanges,
			[Optional] D3D12_SHADER_VISIBILITY visibility, out SafeAllocatedMemoryHandle h) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE,
				ShaderVisibility = visibility,
				u = new() { DescriptorTable = D3D12_ROOT_DESCRIPTOR_TABLE1.Init(pDescriptorRanges, out h) }
			};

		/// <summary>Initializes with a descriptor table.</summary>
		/// <param name="numRanges">The number of descriptor ranges in the table layout.</param>
		/// <param name="pDescriptorRanges">The descriptor ranges.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER1"/>.</returns>
		public static D3D12_ROOT_PARAMETER1 InitAsDescriptorTable(SizeT numRanges, [In] ArrayPointer<D3D12_DESCRIPTOR_RANGE1> pDescriptorRanges,
			[Optional] D3D12_SHADER_VISIBILITY visibility) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_DESCRIPTOR_TABLE,
				ShaderVisibility = visibility,
				u = new() { DescriptorTable = D3D12_ROOT_DESCRIPTOR_TABLE1.Init(numRanges, pDescriptorRanges) }
			};

		/// <summary>Initializes with constants.</summary>
		/// <param name="num32BitValues">
		/// The number of constants that occupy a single shader slot (these constants appear like a single constant buffer). All constants
		/// occupy a single root signature bind slot.
		/// </param>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER1"/>.</returns>
		public static D3D12_ROOT_PARAMETER1 InitAsConstants(uint num32BitValues, uint shaderRegister, uint registerSpace,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_32BIT_CONSTANTS,
				ShaderVisibility = visibility,
				u = new() { Constants = new D3D12_ROOT_CONSTANTS(shaderRegister, registerSpace, num32BitValues) }
			};

		/// <summary>Initializes with constants for a buffer view.</summary>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="flags">
		/// Specifies the <c>D3D12_ROOT_DESCRIPTOR_FLAGS</c> that determine the volatility of descriptors and the data they reference.
		/// </param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER1"/>.</returns>
		public static D3D12_ROOT_PARAMETER1 InitAsConstantBufferView(uint shaderRegister, uint registerSpace,
			D3D12_ROOT_DESCRIPTOR_FLAGS flags = D3D12_ROOT_DESCRIPTOR_FLAGS.D3D12_ROOT_DESCRIPTOR_FLAG_NONE,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_CBV,
				ShaderVisibility = visibility,
				u = new() { Descriptor = new(shaderRegister, registerSpace, flags) }
			};

		/// <summary>Initializes with constants for a shader view.</summary>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="flags">
		/// Specifies the <c>D3D12_ROOT_DESCRIPTOR_FLAGS</c> that determine the volatility of descriptors and the data they reference.
		/// </param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER1"/>.</returns>
		public static D3D12_ROOT_PARAMETER1 InitAsShaderResourceView(uint shaderRegister, uint registerSpace,
			D3D12_ROOT_DESCRIPTOR_FLAGS flags = D3D12_ROOT_DESCRIPTOR_FLAGS.D3D12_ROOT_DESCRIPTOR_FLAG_NONE,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_SRV,
				ShaderVisibility = visibility,
				u = new() { Descriptor = new(shaderRegister, registerSpace, flags) }
			};

		/// <summary>Initializes with constants for a shader view.</summary>
		/// <param name="shaderRegister">The shader register.</param>
		/// <param name="registerSpace">The register space.</param>
		/// <param name="flags">
		/// Specifies the <c>D3D12_ROOT_DESCRIPTOR_FLAGS</c> that determine the volatility of descriptors and the data they reference.
		/// </param>
		/// <param name="visibility">Specifies the shaders that can access the contents of the root signature slot.</param>
		/// <returns>An initialized <see cref="D3D12_ROOT_PARAMETER1"/>.</returns>
		public static D3D12_ROOT_PARAMETER1 InitAsUnorderedAccessView(uint shaderRegister, uint registerSpace,
			D3D12_ROOT_DESCRIPTOR_FLAGS flags = D3D12_ROOT_DESCRIPTOR_FLAGS.D3D12_ROOT_DESCRIPTOR_FLAG_NONE,
			D3D12_SHADER_VISIBILITY visibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL) => new()
			{
				ParameterType = D3D12_ROOT_PARAMETER_TYPE.D3D12_ROOT_PARAMETER_TYPE_UAV,
				ShaderVisibility = visibility,
				u = new() { Descriptor = new(shaderRegister, registerSpace, flags) }
			};
	}

	/// <summary>Describes the layout of a root signature version 1.0.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used by the <c>D3D12SerializeRootSignature</c> function and is returned by the
	/// <c>ID3D12RootSignatureDeserializer::GetRootSignatureDesc</c> method.
	/// </para>
	/// <para>There is one graphics root signature, and one compute root signature.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_signature_desc typedef struct D3D12_ROOT_SIGNATURE_DESC
	// { UINT NumParameters; const D3D12_ROOT_PARAMETER *pParameters; UINT NumStaticSamplers; const D3D12_STATIC_SAMPLER_DESC
	// *pStaticSamplers; D3D12_ROOT_SIGNATURE_FLAGS Flags; } D3D12_ROOT_SIGNATURE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_SIGNATURE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_SIGNATURE_DESC
	{
		/// <summary>
		/// The number of slots in the root signature. This number is also the number of elements in the <i>pParameters</i> array.
		/// </summary>
		public uint NumParameters;

		/// <summary>An array of <c>D3D12_ROOT_PARAMETER</c> structures for the slots in the root signature.</summary>
		public ArrayPointer<D3D12_ROOT_PARAMETER> pParameters;

		/// <summary>Specifies the number of static samplers.</summary>
		public uint NumStaticSamplers;

		/// <summary>Pointer to one or more <c>D3D12_STATIC_SAMPLER_DESC</c> structures.</summary>
		public ArrayPointer<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers;

		/// <summary>
		/// A combination of <c>D3D12_ROOT_SIGNATURE_FLAGS</c>-typed values that are combined by using a bitwise OR operation. The resulting
		/// value specifies options for the root signature layout.
		/// </summary>
		public D3D12_ROOT_SIGNATURE_FLAGS Flags;

		/// <summary>Initializes a new instance of the <see cref="D3D12_ROOT_SIGNATURE_DESC"/> struct.</summary>
		/// <param name="cParameters">The number of elements in the <i>pParameters</i> array.</param>
		/// <param name="pParameters">A pointer to an array of <c>D3D12_ROOT_PARAMETER</c> structures for the slots in the root signature.</param>
		/// <param name="cStaticSamplers">Specifies the number of static samplers.</param>
		/// <param name="pStaticSamplers">Pointer to one or more <c>D3D12_STATIC_SAMPLER_DESC</c> structures.</param>
		/// <param name="flags">Specifies the <c>D3D12_ROOT_SIGNATURE_FLAGS</c> that determine the data volatility.</param>
		public D3D12_ROOT_SIGNATURE_DESC(SizeT cParameters, ArrayPointer<D3D12_ROOT_PARAMETER> pParameters, SizeT cStaticSamplers = default,
			ArrayPointer<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers = default,
			D3D12_ROOT_SIGNATURE_FLAGS flags = D3D12_ROOT_SIGNATURE_FLAGS.D3D12_ROOT_SIGNATURE_FLAG_NONE)
		{
			NumParameters = cParameters;
			this.pParameters = pParameters;
			NumStaticSamplers = cStaticSamplers;
			this.pStaticSamplers = pStaticSamplers;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_ROOT_SIGNATURE_DESC"/> struct.</summary>
		/// <param name="pParameters">An array of <c>D3D12_ROOT_PARAMETER</c> structures for the slots in the root signature.</param>
		/// <param name="pStaticSamplers">Optional array of one or more <c>D3D12_STATIC_SAMPLER_DESC</c> structures.</param>
		/// <param name="flags">Specifies options for the root signature layout.</param>
		/// <param name="memoryHandle">The memory allocated for the arrays.</param>
		public D3D12_ROOT_SIGNATURE_DESC([Optional] D3D12_ROOT_PARAMETER[]? pParameters, [Optional] D3D12_STATIC_SAMPLER_DESC[]? pStaticSamplers,
			[Optional] D3D12_ROOT_SIGNATURE_FLAGS flags, out SafeAllocatedMemoryHandle memoryHandle)
		{
			NumParameters = (uint?)pParameters?.Length ?? 0;
			NumStaticSamplers = (uint?)pStaticSamplers?.Length ?? 0; ;
			if (NumStaticSamplers == 0)
			{
				this.pStaticSamplers = default;
				this.pParameters = memoryHandle = NumParameters > 0 ? SafeCoTaskMemHandle.CreateFromList(pParameters!) : SafeCoTaskMemHandle.Null;
			}
			else
			{
				if (NumParameters == 0)
				{
					this.pStaticSamplers = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pStaticSamplers!);
					this.pParameters = default;
				}
				else
				{
					memoryHandle = SafeCoTaskMemHandle.CreateFromList(pParameters!);
					var sz = memoryHandle.Size;
					var addMem = SafeCoTaskMemHandle.CreateFromList(pStaticSamplers!);
					memoryHandle.Size += addMem.Size;
					addMem.DangerousGetHandle().CopyTo(memoryHandle.DangerousGetHandle().Offset(sz), addMem.Size);
					this.pParameters = memoryHandle;
					this.pStaticSamplers = memoryHandle.DangerousGetHandle().Offset(sz);
				}
			}
			Flags = flags;
		}
	}

	/// <summary>Describes the layout of a root signature version 1.1.</summary>
	/// <remarks>Use this structure with the <c>D3D12_VERSIONED_ROOT_SIGNATURE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_root_signature_desc1 typedef struct
	// D3D12_ROOT_SIGNATURE_DESC1 { UINT NumParameters; const D3D12_ROOT_PARAMETER1 *pParameters; UINT NumStaticSamplers; const
	// D3D12_STATIC_SAMPLER_DESC *pStaticSamplers; D3D12_ROOT_SIGNATURE_FLAGS Flags; } D3D12_ROOT_SIGNATURE_DESC1;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_ROOT_SIGNATURE_DESC1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_SIGNATURE_DESC1
	{
		/// <summary>
		/// The number of slots in the root signature. This number is also the number of elements in the <i>pParameters</i> array.
		/// </summary>
		public uint NumParameters;

		/// <summary>An array of <c>D3D12_ROOT_PARAMETER1</c> structures for the slots in the root signature.</summary>
		public ArrayPointer<D3D12_ROOT_PARAMETER1> pParameters;

		/// <summary>Specifies the number of static samplers.</summary>
		public uint NumStaticSamplers;

		/// <summary>Pointer to one or more <c>D3D12_STATIC_SAMPLER_DESC</c> structures.</summary>
		public ArrayPointer<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers;

		/// <summary>Specifies the <c>D3D12_ROOT_SIGNATURE_FLAGS</c> that determine the data volatility.</summary>
		public D3D12_ROOT_SIGNATURE_FLAGS Flags;

		/// <summary>Initializes a new instance of the <see cref="D3D12_ROOT_SIGNATURE_DESC1"/> struct.</summary>
		/// <param name="cParameters">The number of elements in the <i>pParameters</i> array.</param>
		/// <param name="pParameters">A pointer to an array of <c>D3D12_ROOT_PARAMETER1</c> structures for the slots in the root signature.</param>
		/// <param name="cStaticSamplers">Specifies the number of static samplers.</param>
		/// <param name="pStaticSamplers">Pointer to one or more <c>D3D12_STATIC_SAMPLER_DESC</c> structures.</param>
		/// <param name="flags">Specifies the <c>D3D12_ROOT_SIGNATURE_FLAGS</c> that determine the data volatility.</param>
		public D3D12_ROOT_SIGNATURE_DESC1(SizeT cParameters, ArrayPointer<D3D12_ROOT_PARAMETER1> pParameters, SizeT cStaticSamplers = default,
			ArrayPointer<D3D12_STATIC_SAMPLER_DESC> pStaticSamplers = default,
			D3D12_ROOT_SIGNATURE_FLAGS flags = D3D12_ROOT_SIGNATURE_FLAGS.D3D12_ROOT_SIGNATURE_FLAG_NONE)
		{
			NumParameters = cParameters;
			this.pParameters = pParameters;
			NumStaticSamplers = cStaticSamplers;
			this.pStaticSamplers = pStaticSamplers;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_ROOT_SIGNATURE_DESC1"/> struct.</summary>
		/// <param name="pParameters">An array of <c>D3D12_ROOT_PARAMETER1</c> structures for the slots in the root signature.</param>
		/// <param name="pStaticSamplers">Optional array of one or more <c>D3D12_STATIC_SAMPLER_DESC</c> structures.</param>
		/// <param name="flags">Specifies options for the root signature layout.</param>
		/// <param name="memoryHandle">The memory allocated for the arrays.</param>
		public D3D12_ROOT_SIGNATURE_DESC1([Optional] D3D12_ROOT_PARAMETER1[]? pParameters, [Optional] D3D12_STATIC_SAMPLER_DESC[]? pStaticSamplers,
			[Optional] D3D12_ROOT_SIGNATURE_FLAGS flags, out SafeAllocatedMemoryHandle memoryHandle)
		{
			NumParameters = (uint?)pParameters?.Length ?? 0;
			NumStaticSamplers = (uint?)pStaticSamplers?.Length ?? 0; ;
			if (NumStaticSamplers == 0)
			{
				this.pStaticSamplers = default;
				this.pParameters = memoryHandle = NumParameters > 0 ? SafeCoTaskMemHandle.CreateFromList(pParameters!) : SafeCoTaskMemHandle.Null;
			}
			else
			{
				if (NumParameters == 0)
				{
					this.pStaticSamplers = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pStaticSamplers!);
					this.pParameters = default;
				}
				else
				{
					memoryHandle = SafeCoTaskMemHandle.CreateFromList(pParameters!);
					var sz = memoryHandle.Size;
					var addMem = SafeCoTaskMemHandle.CreateFromList(pStaticSamplers!);
					memoryHandle.Size += addMem.Size;
					addMem.DangerousGetHandle().CopyTo(memoryHandle.DangerousGetHandle().Offset(sz), addMem.Size);
					this.pParameters = memoryHandle;
					this.pStaticSamplers = memoryHandle.DangerousGetHandle().Offset(sz);
				}
			}
			Flags = flags;
		}

	}

	/// <summary>Undocumented</summary>
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VERSIONED_ROOT_SIGNATURE_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_ROOT_SIGNATURE_DESC2
	{
		/// <summary>
		/// The number of slots in the root signature. This number is also the number of elements in the <i>pParameters</i> array.
		/// </summary>
		public uint NumParameters;

		/// <summary>An array of <c>D3D12_ROOT_PARAMETER1</c> structures for the slots in the root signature.</summary>
		public ArrayPointer<D3D12_ROOT_PARAMETER1> pParameters;

		/// <summary>Specifies the number of static samplers.</summary>
		public uint NumStaticSamplers;

		/// <summary>Pointer to one or more <c>D3D12_STATIC_SAMPLER_DESC1</c> structures.</summary>
		public ArrayPointer<D3D12_STATIC_SAMPLER_DESC1> pStaticSamplers;

		/// <summary>Specifies the <c>D3D12_ROOT_SIGNATURE_FLAGS</c> that determine the data volatility.</summary>
		public D3D12_ROOT_SIGNATURE_FLAGS Flags;

		/// <summary>Initializes a new instance of the <see cref="D3D12_ROOT_SIGNATURE_DESC2"/> struct.</summary>
		/// <param name="cParameters">The number of elements in the <i>pParameters</i> array.</param>
		/// <param name="pParameters">A pointer to an array of <c>D3D12_ROOT_PARAMETER1</c> structures for the slots in the root signature.</param>
		/// <param name="cStaticSamplers">Specifies the number of static samplers.</param>
		/// <param name="pStaticSamplers">Pointer to one or more <c>D3D12_STATIC_SAMPLER_DESC1</c> structures.</param>
		/// <param name="flags">Specifies the <c>D3D12_ROOT_SIGNATURE_FLAGS</c> that determine the data volatility.</param>
		public D3D12_ROOT_SIGNATURE_DESC2(SizeT cParameters, ArrayPointer<D3D12_ROOT_PARAMETER1> pParameters, SizeT cStaticSamplers = default,
			ArrayPointer<D3D12_STATIC_SAMPLER_DESC1> pStaticSamplers = default,
			D3D12_ROOT_SIGNATURE_FLAGS flags = D3D12_ROOT_SIGNATURE_FLAGS.D3D12_ROOT_SIGNATURE_FLAG_NONE)
		{
			NumParameters = cParameters;
			this.pParameters = pParameters;
			NumStaticSamplers = cStaticSamplers;
			this.pStaticSamplers = pStaticSamplers;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_ROOT_SIGNATURE_DESC2"/> struct.</summary>
		/// <param name="pParameters">An array of <c>D3D12_ROOT_PARAMETER1</c> structures for the slots in the root signature.</param>
		/// <param name="pStaticSamplers">Optional array of one or more <c>D3D12_STATIC_SAMPLER_DESC1</c> structures.</param>
		/// <param name="flags">Specifies options for the root signature layout.</param>
		/// <param name="memoryHandle">The memory allocated for the arrays.</param>
		public D3D12_ROOT_SIGNATURE_DESC2([Optional] D3D12_ROOT_PARAMETER1[]? pParameters, [Optional] D3D12_STATIC_SAMPLER_DESC1[]? pStaticSamplers,
			[Optional] D3D12_ROOT_SIGNATURE_FLAGS flags, out SafeAllocatedMemoryHandle memoryHandle)
		{
			NumParameters = (uint?)pParameters?.Length ?? 0;
			NumStaticSamplers = (uint?)pStaticSamplers?.Length ?? 0; ;
			if (NumStaticSamplers == 0)
			{
				this.pStaticSamplers = default;
				this.pParameters = memoryHandle = NumParameters > 0 ? SafeCoTaskMemHandle.CreateFromList(pParameters!) : SafeCoTaskMemHandle.Null;
			}
			else
			{
				if (NumParameters == 0)
				{
					this.pStaticSamplers = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pStaticSamplers!);
					this.pParameters = default;
				}
				else
				{
					memoryHandle = SafeCoTaskMemHandle.CreateFromList(pParameters!);
					var sz = memoryHandle.Size;
					var addMem = SafeCoTaskMemHandle.CreateFromList(pStaticSamplers!);
					memoryHandle.Size += addMem.Size;
					addMem.DangerousGetHandle().CopyTo(memoryHandle.DangerousGetHandle().Offset(sz), addMem.Size);
					this.pParameters = memoryHandle;
					this.pStaticSamplers = memoryHandle.DangerousGetHandle().Offset(sz);
				}
			}
			Flags = flags;
		}
	}

	/// <summary>Wraps an array of render target formats.</summary>
	/// <remarks>
	/// This structure is primarily intended to be used when creating pipeline state stream descriptions that contain multiple contiguous
	/// render target format descriptions.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_rt_format_array struct D3D12_RT_FORMAT_ARRAY { DXGI_FORMAT
	// RTFormats[8]; UINT NumRenderTargets; };
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_RT_FORMAT_ARRAY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_RT_FORMAT_ARRAY
	{
		/// <summary>Specifies a fixed-size array of DXGI_FORMAT values that define the format of up to 8 render targets.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public DXGI_FORMAT[] RTFormats;

		/// <summary>Specifies the number of render target formats stored in the array.</summary>
		public uint NumRenderTargets;

		/// <summary>Initializes a new instance of the <see cref="D3D12_RT_FORMAT_ARRAY"/> struct.</summary>
		/// <param name="formats">An array of DXGI_FORMAT values that define the format of up to 8 render targets.</param>
		public D3D12_RT_FORMAT_ARRAY(DXGI_FORMAT[] formats)
		{
			if (formats.Length > 8)
				throw new ArgumentOutOfRangeException(nameof(formats), "Array length must be 8 or less.");
			RTFormats = new DXGI_FORMAT[8];
			Array.ConstrainedCopy(formats, 0, RTFormats, 0, formats.Length);
			NumRenderTargets = (uint)formats.Length;
		}
	}

	/// <summary>Describes a sub-pixel sample position for use with programmable sample positions.</summary>
	/// <remarks>
	/// <para>
	/// Sample positions have the origin (0, 0) at the pixel center. Each of the X and Y coordinates are signed values in the range -8
	/// (top/left) to 7 (bottom/right). Values outside this range are invalid.
	/// </para>
	/// <para>
	/// Each increment of these integer values represents 1/16th of a pixel. For example, X and Y values of -8 and 4, respectively,
	/// correspond to floating-point values of -0.5 and 0.25, a point located on the left-most edge of the pixel, half-way between its
	/// center-line and the bottom edge. Because of this, the bottom-most and right-most edge of a pixel are not reachable by sampling
	/// (these positions are reachable as the top-most and left-most edges of the neighboring pixels).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_sample_position typedef struct D3D12_SAMPLE_POSITION { INT8
	// X; INT8 Y; } D3D12_SAMPLE_POSITION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SAMPLE_POSITION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SAMPLE_POSITION
	{
		/// <summary>A signed sub-pixel coordinate value in the X axis.</summary>
		public sbyte X;

		/// <summary>A signed sub-pixel coordinate value in the Y axis.</summary>
		public sbyte Y;
	}

	/// <summary>Describes a sampler state.</summary>
	/// <remarks>This structure is used by <c>CreateSampler</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_sampler_desc typedef struct D3D12_SAMPLER_DESC {
	// D3D12_FILTER Filter; D3D12_TEXTURE_ADDRESS_MODE AddressU; D3D12_TEXTURE_ADDRESS_MODE AddressV; D3D12_TEXTURE_ADDRESS_MODE AddressW;
	// FLOAT MipLODBias; UINT MaxAnisotropy; D3D12_COMPARISON_FUNC ComparisonFunc; FLOAT BorderColor[4]; FLOAT MinLOD; FLOAT MaxLOD; } D3D12_SAMPLER_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SAMPLER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SAMPLER_DESC
	{
		/// <summary>A <c>D3D12_FILTER</c>-typed value that specifies the filtering method to use when sampling a texture.</summary>
		public D3D12_FILTER Filter;

		/// <summary>
		/// A <c>D3D12_TEXTURE_ADDRESS_MODE</c>-typed value that specifies the method to use for resolving a u texture coordinate that is
		/// outside the 0 to 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressU;

		/// <summary>
		/// A <c>D3D12_TEXTURE_ADDRESS_MODE</c>-typed value that specifies the method to use for resolving a v texture coordinate that is
		/// outside the 0 to 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressV;

		/// <summary>
		/// A <c>D3D12_TEXTURE_ADDRESS_MODE</c>-typed value that specifies the method to use for resolving a w texture coordinate that is
		/// outside the 0 to 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressW;

		/// <summary>
		/// Offset from the calculated mipmap level. For example, if the runtime calculates that a texture should be sampled at mipmap level
		/// 3 and <b>MipLODBias</b> is 2, the texture will be sampled at mipmap level 5.
		/// </summary>
		public float MipLODBias;

		/// <summary>
		/// Clamping value used if <b>D3D12_FILTER_ANISOTROPIC</b> or <b>D3D12_FILTER_COMPARISON_ANISOTROPIC</b> is specified in
		/// <b>Filter</b>. Valid values are between 1 and 16.
		/// </summary>
		public uint MaxAnisotropy;

		/// <summary>
		/// A <c>D3D12_COMPARISON_FUNC</c>-typed value that specifies a function that compares sampled data against existing sampled data.
		/// </summary>
		public D3D12_COMPARISON_FUNC ComparisonFunc;

		/// <summary>
		/// RGBA border color to use if <c>D3D12_TEXTURE_ADDRESS_MODE_BORDER</c> is specified for <b>AddressU</b>, <b>AddressV</b>, or
		/// <b>AddressW</b>. Range must be between 0.0 and 1.0 inclusive.
		/// </summary>
		public D3DCOLORVALUE BorderColor;

		/// <summary>
		/// Lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed.
		/// </summary>
		public float MinLOD;

		/// <summary>
		/// Upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed. This value must be greater than or equal to <b>MinLOD</b>. To have no upper limit on LOD, set this
		/// member to a large value.
		/// </summary>
		public float MaxLOD;
	}

	/// <summary>
	/// Opaque data structure describing driver versioning for a serialized acceleration structure. Pass this structure into a call to
	/// <c>ID3D12Device5::CheckDriverMatchingIdentifier</c> to determine if a previously serialized acceleration structure is compatible
	/// with the current driver/device, and can therefore be deserialized and used for raytracing.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_serialized_data_driver_matching_identifier typedef struct
	// D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER { GUID DriverOpaqueGUID; BYTE DriverOpaqueVersioningData[16]; } D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER
	{
		/// <summary>The opaque identifier of the driver.</summary>
		public Guid DriverOpaqueGUID;

		/// <summary>The opaque driver versioning data.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] DriverOpaqueVersioningData;

		/// <summary>Initializes a new instance of the <see cref="D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER"/> struct.</summary>
		/// <param name="driverOpaqueGUID">The opaque identifier of the driver.</param>
		/// <param name="driverOpaqueVersioningData">The opaque driver versioning data.</param>
		/// <exception cref="ArgumentOutOfRangeException">nameof(driverOpaqueVersioningData), Array length must be 16 or less.</exception>
		public D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER(Guid driverOpaqueGUID, byte[] driverOpaqueVersioningData)
		{
			DriverOpaqueGUID = driverOpaqueGUID;
			DriverOpaqueVersioningData = new byte[16];
			if (driverOpaqueVersioningData.Length > 16)
				throw new ArgumentOutOfRangeException(nameof(driverOpaqueVersioningData), "Array length must be 16 or less.");
			if (driverOpaqueVersioningData is null || driverOpaqueVersioningData.Length == 0)
				return;
			Array.ConstrainedCopy(driverOpaqueVersioningData, 0, DriverOpaqueVersioningData, 0, driverOpaqueVersioningData.Length);
		}
	}

	/// <summary>Defines the header for a serialized raytracing acceleration structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_serialized_raytracing_acceleration_structure_header typedef
	// struct D3D12_SERIALIZED_RAYTRACING_ACCELERATION_STRUCTURE_HEADER { D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER
	// DriverMatchingIdentifier; UINT64 SerializedSizeInBytesIncludingHeader; UINT64 DeserializedSizeInBytes; UINT64
	// NumBottomLevelAccelerationStructurePointersAfterHeader; } D3D12_SERIALIZED_RAYTRACING_ACCELERATION_STRUCTURE_HEADER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SERIALIZED_RAYTRACING_ACCELERATION_STRUCTURE_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SERIALIZED_RAYTRACING_ACCELERATION_STRUCTURE_HEADER
	{
		/// <summary>The driver-matching identifier.</summary>
		public D3D12_SERIALIZED_DATA_DRIVER_MATCHING_IDENTIFIER DriverMatchingIdentifier;

		/// <summary>The size of serialized data.</summary>
		public ulong SerializedSizeInBytesIncludingHeader;

		/// <summary>
		/// Size of the memory that will be consumed when the acceleration structure is deserialized. This value is less than or equal to
		/// the size of the original acceleration structure before it was serialized.
		/// </summary>
		public ulong DeserializedSizeInBytes;

		/// <summary>Size of the array of <c>D3D12_GPU_VIRTUAL_ADDRESS</c> values that follow the header. For more information, see <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_POSTBUILD_INFO_SERIALIZATION_DESC</c>.</summary>
		public ulong NumBottomLevelAccelerationStructurePointersAfterHeader;
	}

	/// <summary>Describes shader data.</summary>
	/// <remarks>
	/// <para>
	/// The <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> and <c>D3D12_COMPUTE_PIPELINE_STATE_DESC</c> objects contain
	/// <b>D3D12_SHADER_BYTECODE</b> structures that describe various shader types.
	/// </para>
	/// <para>When loading a shader from FXC/DXC, this may be the entire compiled blob as is loaded from disk.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_shader_bytecode typedef struct D3D12_SHADER_BYTECODE { const
	// void *pShaderBytecode; SIZE_T BytecodeLength; } D3D12_SHADER_BYTECODE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SHADER_BYTECODE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_BYTECODE(IntPtr pShaderBytecode, SizeT bytecodeLength)
	{
		/// <summary>A pointer to a memory block that contains the shader data.</summary>
		public IntPtr pShaderBytecode = pShaderBytecode;

		/// <summary>The size, in bytes, of the shader data that the <b>pShaderBytecode</b> member points to.</summary>
		public SizeT BytecodeLength = bytecodeLength;

		/// <summary>Initializes a new instance of the <see cref="D3D12_SHADER_BYTECODE"/> struct.</summary>
		/// <param name="pShaderBlob">The <see cref="ID3DBlob"/> with shader data.</param>
		public D3D12_SHADER_BYTECODE(ID3DBlob pShaderBlob) : this(pShaderBlob.GetBufferPointer(), pShaderBlob.GetBufferSize()) { }
	}

	/// <summary>Describes a shader cache session.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_shader_cache_session_desc typedef struct
	// D3D12_SHADER_CACHE_SESSION_DESC { GUID Identifier; D3D12_SHADER_CACHE_MODE Mode; D3D12_SHADER_CACHE_FLAGS Flags; UINT
	// MaximumInMemoryCacheSizeBytes; UINT MaximumInMemoryCacheEntries; UINT MaximumValueFileSizeBytes; UINT64 Version; } D3D12_SHADER_CACHE_SESSION_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SHADER_CACHE_SESSION_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SHADER_CACHE_SESSION_DESC
	{
		/// <summary>
		/// <para>Type: <b><c>GUID</c></b></para>
		/// <para>
		/// A unique identifier to give to this specific cache. Caches with different identifiers are stored side by side. Caches with the
		/// same identifier are shared across all sessions in the same process. Creating a disk cache with the same identifier as an
		/// already-existing cache opens that cache, unless the <b>Version</b> doesn't matches. In that case, if there are no other sessions
		/// open to that cache, it is cleared and re-created. If there are existing sessions, then
		/// <c>ID3D12Device9::CreateShaderCacheSession</c> returns <b>DXGI_ERROR_ALREADY_EXISTS</b>.
		/// </para>
		/// </summary>
		public Guid Identifier;

		/// <summary>
		/// <para>Type: <b><c>D3D12_SHADER_CACHE_MODE</c></b></para>
		/// <para>Specifies the kind of cache.</para>
		/// </summary>
		public D3D12_SHADER_CACHE_MODE Mode;

		/// <summary>
		/// <para>Type: <b><c>D3D12_SHADER_CACHE_FLAGS</c></b></para>
		/// <para>Modifies the behavior of the cache.</para>
		/// </summary>
		public D3D12_SHADER_CACHE_FLAGS Flags;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>
		/// For in-memory caches, this is the only storage available. For disk caches, all entries that are stored or found are temporarily
		/// stored in memory, until evicted by newer entries. This value determines the size of that temporary storage. Defaults to 1KB.
		/// </para>
		/// </summary>
		public uint MaximumInMemoryCacheSizeBytes;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>Specifies how many entries can be stored in memory. Defaults to 128.</para>
		/// </summary>
		public uint MaximumInMemoryCacheEntries;

		/// <summary>
		/// <para>Type: <b><c>UINT</c></b></para>
		/// <para>For disk caches, controls the maximum file size. Defaults to 128MB.</para>
		/// </summary>
		public uint MaximumValueFileSizeBytes;

		/// <summary>
		/// <para>Type: <b><c>UINT64</c></b></para>
		/// <para>
		/// Can be used to implicitly clear caches when an application or component update is done. If the version doesn't match the version
		/// stored in the cache, then it will be wiped and re-created.
		/// </para>
		/// </summary>
		public ulong Version;
	}

	/// <summary>Describes a shader-resource view (SRV).</summary>
	/// <remarks>
	/// <para>
	/// A view is a format-specific way to look at the data in a resource. The view determines what data to look at, and how it is cast when read.
	/// </para>
	/// <para>
	/// When viewing a resource, the resource-view description must specify a typed format, that is compatible with the resource format. So
	/// that means that you can't create a resource-view description using any format with _TYPELESS in the name. You can however view a
	/// typeless resource by specifying a typed format for the view. For example, a DXGI_FORMAT_R32G32B32_TYPELESS resource can be viewed
	/// with one of these typed formats: DXGI_FORMAT_R32G32B32_FLOAT, DXGI_FORMAT_R32G32B32_UINT, and DXGI_FORMAT_R32G32B32_SINT, since
	/// these typed formats are compatible with the typeless resource.
	/// </para>
	/// <para>Create a shader-resource-view description by calling <c>ID3D12Device::CreateShaderResourceView</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_shader_resource_view_desc typedef struct
	// D3D12_SHADER_RESOURCE_VIEW_DESC { DXGI_FORMAT Format; D3D12_SRV_DIMENSION ViewDimension; UINT Shader4ComponentMapping; union {
	// D3D12_BUFFER_SRV Buffer; D3D12_TEX1D_SRV Texture1D; D3D12_TEX1D_ARRAY_SRV Texture1DArray; D3D12_TEX2D_SRV Texture2D;
	// D3D12_TEX2D_ARRAY_SRV Texture2DArray; D3D12_TEX2DMS_SRV Texture2DMS; D3D12_TEX2DMS_ARRAY_SRV Texture2DMSArray; D3D12_TEX3D_SRV
	// Texture3D; D3D12_TEXCUBE_SRV TextureCube; D3D12_TEXCUBE_ARRAY_SRV TextureCubeArray; D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV
	// RaytracingAccelerationStructure; }; } D3D12_SHADER_RESOURCE_VIEW_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SHADER_RESOURCE_VIEW_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_SHADER_RESOURCE_VIEW_DESC
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value that specifies the viewing format. See remarks.</summary>
		[FieldOffset(0)]
		public DXGI_FORMAT Format;

		/// <summary>
		/// A <c>D3D12_SRV_DIMENSION</c>-typed value that specifies the resource type of the view. This type is the same as the resource
		/// type of the underlying resource. This member also determines which _SRV to use in the union below.
		/// </summary>
		[FieldOffset(4)]
		public D3D12_SRV_DIMENSION ViewDimension;

		/// <summary>
		/// A value, constructed using the <c>D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING</c> macro. The <b>D3D12_SHADER_COMPONENT_MAPPING</b>
		/// enumeration specifies what values from memory should be returned when the texture is accessed in a shader via this shader
		/// resource view (SRV). For example, it can route component 1 (green) from memory, or the constant <c>0</c>, into component 2 (
		/// <c>.b</c>) of the value given to the shader.
		/// </summary>
		[FieldOffset(8)]
		public uint Shader4ComponentMapping;

		/// <summary>A <c>D3D12_BUFFER_SRV</c> structure that views the resource as a buffer.</summary>
		[FieldOffset(16)]
		public D3D12_BUFFER_SRV Buffer;

		/// <summary>A <c>D3D12_TEX1D_SRV</c> structure that views the resource as a 1D texture.</summary>
		[FieldOffset(16)]
		public D3D12_TEX1D_SRV Texture1D;

		/// <summary>A <c>D3D12_TEX1D_ARRAY_SRV</c> structure that views the resource as a 1D-texture array.</summary>
		[FieldOffset(16)]
		public D3D12_TEX1D_ARRAY_SRV Texture1DArray;

		/// <summary>A <c>D3D12_TEX2D_SRV</c> structure that views the resource as a 2D-texture.</summary>
		[FieldOffset(16)]
		public D3D12_TEX2D_SRV Texture2D;

		/// <summary>A <c>D3D12_TEX2D_ARRAY_SRV</c> structure that views the resource as a 2D-texture array.</summary>
		[FieldOffset(16)]
		public D3D12_TEX2D_ARRAY_SRV Texture2DArray;

		/// <summary>A <c>D3D12_TEX2DMS_SRV</c> structure that views the resource as a 2D-multisampled texture.</summary>
		[FieldOffset(16)]
		public D3D12_TEX2DMS_SRV Texture2DMS;

		/// <summary>A <c>D3D12_TEX2DMS_ARRAY_SRV</c> structure that views the resource as a 2D-multisampled-texture array.</summary>
		[FieldOffset(16)]
		public D3D12_TEX2DMS_ARRAY_SRV Texture2DMSArray;

		/// <summary>A <c>D3D12_TEX3D_SRV</c> structure that views the resource as a 3D texture.</summary>
		[FieldOffset(16)]
		public D3D12_TEX3D_SRV Texture3D;

		/// <summary>A <c>D3D12_TEXCUBE_SRV</c> structure that views the resource as a 3D-cube texture.</summary>
		[FieldOffset(16)]
		public D3D12_TEXCUBE_SRV TextureCube;

		/// <summary>A <c>D3D12_TEXCUBE_ARRAY_SRV</c> structure that views the resource as a 3D-cube-texture array.</summary>
		[FieldOffset(16)]
		public D3D12_TEXCUBE_ARRAY_SRV TextureCubeArray;

		/// <summary>
		/// A <c>D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV</c> structure that views the resource as a raytracing acceleration structure.
		/// </summary>
		[FieldOffset(16)]
		public D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV RaytracingAccelerationStructure;
	}

	/// <summary>Describes a vertex element in a vertex buffer in an output slot.</summary>
	/// <remarks>
	/// Specify an array of <b>D3D12_SO_DECLARATION_ENTRY</b> structures in the <b>pSODeclaration</b> member of a
	/// <c>D3D12_STREAM_OUTPUT_DESC</c> structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_so_declaration_entry typedef struct
	// D3D12_SO_DECLARATION_ENTRY { UINT Stream; LPCSTR SemanticName; UINT SemanticIndex; BYTE StartComponent; BYTE ComponentCount; BYTE
	// OutputSlot; } D3D12_SO_DECLARATION_ENTRY;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SO_DECLARATION_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SO_DECLARATION_ENTRY
	{
		/// <summary>Zero-based, stream number.</summary>
		public uint Stream;

		/// <summary>
		/// Type of output element; possible values include: <b>"POSITION"</b>, <b>"NORMAL"</b>, or <b>"TEXCOORD0"</b>. Note that if
		/// <b>SemanticName</b> is <b>NULL</b> then <b>ComponentCount</b> can be greater than 4 and the described entry will be a gap in the
		/// stream out where no data will be written.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string SemanticName;

		/// <summary>
		/// Output element's zero-based index. Use, for example, if you have more than one texture coordinate stored in each vertex.
		/// </summary>
		public uint SemanticIndex;

		/// <summary>
		/// The component of the entry to begin writing out to. Valid values are 0 to 3. For example, if you only wish to output to the y
		/// and z components of a position, <b>StartComponent</b> is 1 and <b>ComponentCount</b> is 2.
		/// </summary>
		public byte StartComponent;

		/// <summary>
		/// The number of components of the entry to write out to. Valid values are 1 to 4. For example, if you only wish to output to the y
		/// and z components of a position, <b>StartComponent</b> is 1 and <b>ComponentCount</b> is 2. Note that if <b>SemanticName</b> is
		/// <b>NULL</b> then <b>ComponentCount</b> can be greater than 4 and the described entry will be a gap in the stream out where no
		/// data will be written.
		/// </summary>
		public byte ComponentCount;

		/// <summary>
		/// The associated stream output buffer that is bound to the pipeline. The valid range for <b>OutputSlot</b> is 0 to 3.
		/// </summary>
		public byte OutputSlot;
	}

	/// <summary>Defines general properties of a state object.</summary>
	/// <remarks>
	/// The presence of this subobject in a state object is optional. If present, all exports in the state object must be associated with
	/// the same subobject (or one with a matching definition). This consistency requirement does not apply across existing collections that
	/// are included in a larger state object.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_state_object_config typedef struct D3D12_STATE_OBJECT_CONFIG
	// { D3D12_STATE_OBJECT_FLAGS Flags; } D3D12_STATE_OBJECT_CONFIG;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STATE_OBJECT_CONFIG")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_STATE_OBJECT_CONFIG
	{
		/// <summary>
		/// A value from the <c>D3D12_STATE_OBJECT_FLAGS</c> flags enumeration that specifies the requirements for the state object.
		/// </summary>
		public D3D12_STATE_OBJECT_FLAGS Flags;
	}

	/// <summary>Description of a state object. Pass a value of this structure type to <c>ID3D12Device5::CreateStateObject</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_state_object_desc typedef struct D3D12_STATE_OBJECT_DESC {
	// D3D12_STATE_OBJECT_TYPE Type; UINT NumSubobjects; const D3D12_STATE_SUBOBJECT *pSubobjects; } D3D12_STATE_OBJECT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STATE_OBJECT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_STATE_OBJECT_DESC
	{
		/// <summary>The type of the state object.</summary>
		public D3D12_STATE_OBJECT_TYPE Type;

		/// <summary>Size of the <i>pSubobjects</i> array.</summary>
		public uint NumSubobjects;

		/// <summary>An array of subobject definitions.</summary>
		public ArrayPointer<D3D12_STATE_SUBOBJECT> pSubobjects;

		/// <summary>Initializes a new instance of the <see cref="D3D12_STATE_OBJECT_DESC"/> struct.</summary>
		/// <param name="type">The type of the state object.</param>
		public D3D12_STATE_OBJECT_DESC(D3D12_STATE_OBJECT_TYPE type) : this() => this.Type = type;
	}

	/// <summary>Description of a state object. Pass a value of this structure type to <c>ID3D12Device5::CreateStateObject</c>.</summary>
	/// <remarks>Initializes a new instance of the <see cref="D3D12_STATE_OBJECT_DESC_MGD"/> class.</remarks>
	/// <param name="type">The type of the state object.</param>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_state_object_desc typedef struct D3D12_STATE_OBJECT_DESC {
	// D3D12_STATE_OBJECT_TYPE Type; UINT NumSubobjects; const D3D12_STATE_SUBOBJECT *pSubobjects; } D3D12_STATE_OBJECT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STATE_OBJECT_DESC")]
	public class D3D12_STATE_OBJECT_DESC_MGD(D3D12_STATE_OBJECT_TYPE type = D3D12_STATE_OBJECT_TYPE.D3D12_STATE_OBJECT_TYPE_COLLECTION) : IVanaraMarshaler
	{
		/// <summary>The type of the state object.</summary>
		public D3D12_STATE_OBJECT_TYPE Type = type;

		/// <summary>A list of subobject definitions.</summary>
		public List<(D3D12_STATE_SUBOBJECT_TYPE type, object desc)> pSubobjects { get; } = [];

		/// <summary>Initializes a new instance of the <see cref="D3D12_STATE_OBJECT_DESC"/> struct.</summary>
		/// <summary>Adds the specified subobject to <see cref="pSubobjects"/>.</summary>
		/// <typeparam name="T">The type of the subobject</typeparam>
		/// <param name="subobject">The subobject value.</param>
		/// <exception cref="ArgumentException">Subobject type is not valid., nameof(subobject)</exception>
		public void Add<T>(T subobject) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanSet<T, D3D12_STATE_SUBOBJECT_TYPE>(out var sotype))
				throw new ArgumentException("Subobject type is not valid.", nameof(subobject));
			pSubobjects.Add((sotype, subobject));
		}

		/// <summary>Gets the unmanaged version of this structure and returns the allocated memory behind the subobjects.</summary>
		/// <param name="mem">The allocated memory.</param>
		/// <returns>A <see cref="D3D12_STATE_OBJECT_DESC"/> instance.</returns>
		public D3D12_STATE_OBJECT_DESC GetUnmanaged(out SafeAllocatedMemoryHandle mem)
		{
			mem = ((IVanaraMarshaler)this).MarshalManagedToNative(this);
			return mem.DangerousGetHandle().ToStructure<D3D12_STATE_OBJECT_DESC>();
		}

		private int[] GetSizes() => [ Marshal.SizeOf<D3D12_STATE_OBJECT_DESC>(), pSubobjects.Count * Marshal.SizeOf<D3D12_STATE_SUBOBJECT>(),
			pSubobjects.Sum(o => Marshal.SizeOf(o.desc)) ];

		/// <inheritdoc/>
		SizeT IVanaraMarshaler.GetNativeSize() => GetSizes().Sum();

		/// <inheritdoc/>
		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
		{
			D3D12_STATE_OBJECT_DESC_MGD mdesc = managedObject as D3D12_STATE_OBJECT_DESC_MGD ?? throw new ArgumentException("Must be D3D12_STATE_OBJECT_DESC_MGD.", nameof(managedObject));

			// Get sizes and allocate memory
			int[] sz = mdesc.GetSizes();
			SafeCoTaskMemHandle mem = new(sz.Sum());

			// Write each subobject to memory
			IntPtr soarray = mem.DangerousGetHandle().Offset(sz[1]);
			IntPtr sop = mem.DangerousGetHandle().Offset(sz[2]);
			for (int i = 0, poffset = 0, sooffset = 0; i < mdesc.pSubobjects.Count; i++)
			{
				(D3D12_STATE_SUBOBJECT_TYPE type, object sodesc) = mdesc.pSubobjects[i];
				var psz = sop.Write(sodesc, poffset);
				sooffset += soarray.Write(new D3D12_STATE_SUBOBJECT { Type = type, pDesc = sop.Offset(poffset) }, sooffset);
				poffset += psz;
			}

			// Write primary description
			D3D12_STATE_OBJECT_DESC desc = new()
			{
				Type = mdesc.Type,
				NumSubobjects = (uint)mdesc.pSubobjects.Count,
				pSubobjects = mem.DangerousGetHandle().Offset(Marshal.OffsetOf(typeof(D3D12_STATE_OBJECT_DESC), "pSubobjects").ToInt64())
			};
			mem.Write(desc);

			return mem;
		}

		/// <inheritdoc/>
		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes) => throw new NotImplementedException();
	}

	/// <summary>Represents a subobject within a state object description. Use with <c>D3D12_STATE_OBJECT_DESC</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_state_subobject typedef struct D3D12_STATE_SUBOBJECT {
	// D3D12_STATE_SUBOBJECT_TYPE Type; const void *pDesc; } D3D12_STATE_SUBOBJECT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STATE_SUBOBJECT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_STATE_SUBOBJECT
	{
		/// <summary>A <c>D3D12_STATE_SUBOBJECT_TYPE</c> specifying the type of the state subobject.</summary>
		public D3D12_STATE_SUBOBJECT_TYPE Type;

		/// <summary>Pointer to state object description of the type specified in the Type parameter.</summary>
		public IntPtr pDesc;
	}

	/// <summary>Describes a static sampler.</summary>
	/// <remarks>Use this structure with the <c>D3D12_ROOT_SIGNATURE_DESC</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_static_sampler_desc typedef struct D3D12_STATIC_SAMPLER_DESC
	// { D3D12_FILTER Filter; D3D12_TEXTURE_ADDRESS_MODE AddressU; D3D12_TEXTURE_ADDRESS_MODE AddressV; D3D12_TEXTURE_ADDRESS_MODE AddressW;
	// FLOAT MipLODBias; UINT MaxAnisotropy; D3D12_COMPARISON_FUNC ComparisonFunc; D3D12_STATIC_BORDER_COLOR BorderColor; FLOAT MinLOD;
	// FLOAT MaxLOD; UINT ShaderRegister; UINT RegisterSpace; D3D12_SHADER_VISIBILITY ShaderVisibility; } D3D12_STATIC_SAMPLER_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STATIC_SAMPLER_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_STATIC_SAMPLER_DESC(uint shaderRegister, D3D12_FILTER filter = D3D12_FILTER.D3D12_FILTER_ANISOTROPIC,
		D3D12_TEXTURE_ADDRESS_MODE addressU = D3D12_TEXTURE_ADDRESS_MODE.D3D12_TEXTURE_ADDRESS_MODE_WRAP,
		D3D12_TEXTURE_ADDRESS_MODE addressV = D3D12_TEXTURE_ADDRESS_MODE.D3D12_TEXTURE_ADDRESS_MODE_WRAP,
		D3D12_TEXTURE_ADDRESS_MODE addressW = D3D12_TEXTURE_ADDRESS_MODE.D3D12_TEXTURE_ADDRESS_MODE_WRAP,
		float mipLODBias = 0f, uint maxAnisotropy = 16, D3D12_COMPARISON_FUNC comparisonFunc = D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_LESS_EQUAL,
		D3D12_STATIC_BORDER_COLOR borderColor = D3D12_STATIC_BORDER_COLOR.D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE, float minLOD = 0f,
		float maxLOD = D3D12_FLOAT32_MAX, D3D12_SHADER_VISIBILITY shaderVisibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL,
		uint registerSpace = 0)
	{
		/// <summary>The filtering method to use when sampling a texture, as a <c>D3D12_FILTER</c> enumeration constant.</summary>
		public D3D12_FILTER Filter = filter;

		/// <summary>
		/// Specifies the <c>D3D12_TEXTURE_ADDRESS_MODE</c> mode to use for resolving a <i>u</i> texture coordinate that is outside the 0 to
		/// 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressU = addressU;

		/// <summary>
		/// Specifies the <c>D3D12_TEXTURE_ADDRESS_MODE</c> mode to use for resolving a <i>v</i> texture coordinate that is outside the 0 to
		/// 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressV = addressV;

		/// <summary>
		/// Specifies the <c>D3D12_TEXTURE_ADDRESS_MODE</c> mode to use for resolving a <i>w</i> texture coordinate that is outside the 0 to
		/// 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressW = addressW;

		/// <summary>
		/// Offset from the calculated mipmap level. For example, if Direct3D calculates that a texture should be sampled at mipmap level 3
		/// and MipLODBias is 2, then the texture will be sampled at mipmap level 5.
		/// </summary>
		public float MipLODBias = mipLODBias;

		/// <summary>
		/// Clamping value used if D3D12_FILTER_ANISOTROPIC or D3D12_FILTER_COMPARISON_ANISOTROPIC is specified as the filter. Valid values
		/// are between 1 and 16.
		/// </summary>
		public uint MaxAnisotropy = maxAnisotropy;

		/// <summary>A function that compares sampled data against existing sampled data. The function options are listed in <c>D3D12_COMPARISON_FUNC</c>.</summary>
		public D3D12_COMPARISON_FUNC ComparisonFunc = comparisonFunc;

		/// <summary>
		/// One member of <c>D3D12_STATIC_BORDER_COLOR</c>, the border color to use if D3D12_TEXTURE_ADDRESS_MODE_BORDER is specified for
		/// AddressU, AddressV, or AddressW. Range must be between 0.0 and 1.0 inclusive.
		/// </summary>
		public D3D12_STATIC_BORDER_COLOR BorderColor = borderColor;

		/// <summary>
		/// Lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed.
		/// </summary>
		public float MinLOD = minLOD;

		/// <summary>
		/// Upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed. This value must be greater than or equal to MinLOD. To have no upper limit on LOD set this to a
		/// large value such as D3D12_FLOAT32_MAX.
		/// </summary>
		public float MaxLOD = maxLOD;

		/// <summary>
		/// The <i>ShaderRegister</i> and <i>RegisterSpace</i> parameters correspond to the binding syntax of HLSL. For example, in HLSL:
		/// <code language="none">Texture2D&lt;float4&gt; a : register(t2, space3);</code>
		/// <para>This corresponds to a <i>ShaderRegister</i> of 2 (indicating the type is SRV), and <i>RegisterSpace</i> is 3.</para>
		/// <para>
		/// The <i>ShaderRegister</i> and <i>RegisterSpace</i> pair is needed to establish correspondence between shader resources and
		/// runtime heap descriptors, using the root signature data structure.
		/// </para>
		/// </summary>
		public uint ShaderRegister = shaderRegister;

		/// <summary>See the description for <i>ShaderRegister</i>. Register space is optional; the default register space is 0.</summary>
		public uint RegisterSpace = registerSpace;

		/// <summary>Specifies the visibility of the sampler to the pipeline shaders, one member of <c>D3D12_SHADER_VISIBILITY</c>.</summary>
		public D3D12_SHADER_VISIBILITY ShaderVisibility = shaderVisibility;
	}

	/// <summary>Describes a static sampler.</summary>
	/// <remarks>Use this structure with the <c>D3D12_ROOT_SIGNATURE_DESC2</c> structure.</remarks>
	[PInvokeData("d3d12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_STATIC_SAMPLER_DESC1(uint shaderRegister, D3D12_FILTER filter = D3D12_FILTER.D3D12_FILTER_ANISOTROPIC,
		D3D12_TEXTURE_ADDRESS_MODE addressU = D3D12_TEXTURE_ADDRESS_MODE.D3D12_TEXTURE_ADDRESS_MODE_WRAP,
		D3D12_TEXTURE_ADDRESS_MODE addressV = D3D12_TEXTURE_ADDRESS_MODE.D3D12_TEXTURE_ADDRESS_MODE_WRAP,
		D3D12_TEXTURE_ADDRESS_MODE addressW = D3D12_TEXTURE_ADDRESS_MODE.D3D12_TEXTURE_ADDRESS_MODE_WRAP,
		float mipLODBias = 0f, uint maxAnisotropy = 16, D3D12_COMPARISON_FUNC comparisonFunc = D3D12_COMPARISON_FUNC.D3D12_COMPARISON_FUNC_LESS_EQUAL,
		D3D12_STATIC_BORDER_COLOR borderColor = D3D12_STATIC_BORDER_COLOR.D3D12_STATIC_BORDER_COLOR_OPAQUE_WHITE, float minLOD = 0f,
		float maxLOD = D3D12_FLOAT32_MAX, D3D12_SHADER_VISIBILITY shaderVisibility = D3D12_SHADER_VISIBILITY.D3D12_SHADER_VISIBILITY_ALL,
		uint registerSpace = 0, D3D12_SAMPLER_FLAGS flags = D3D12_SAMPLER_FLAGS.D3D12_SAMPLER_FLAG_NONE)
	{
		/// <summary>The filtering method to use when sampling a texture, as a <c>D3D12_FILTER</c> enumeration constant.</summary>
		public D3D12_FILTER Filter = filter;

		/// <summary>
		/// Specifies the <c>D3D12_TEXTURE_ADDRESS_MODE</c> mode to use for resolving a <i>u</i> texture coordinate that is outside the 0 to
		/// 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressU = addressU;

		/// <summary>
		/// Specifies the <c>D3D12_TEXTURE_ADDRESS_MODE</c> mode to use for resolving a <i>v</i> texture coordinate that is outside the 0 to
		/// 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressV = addressV;

		/// <summary>
		/// Specifies the <c>D3D12_TEXTURE_ADDRESS_MODE</c> mode to use for resolving a <i>w</i> texture coordinate that is outside the 0 to
		/// 1 range.
		/// </summary>
		public D3D12_TEXTURE_ADDRESS_MODE AddressW = addressW;

		/// <summary>
		/// Offset from the calculated mipmap level. For example, if Direct3D calculates that a texture should be sampled at mipmap level 3
		/// and MipLODBias is 2, then the texture will be sampled at mipmap level 5.
		/// </summary>
		public float MipLODBias = mipLODBias;

		/// <summary>
		/// Clamping value used if D3D12_FILTER_ANISOTROPIC or D3D12_FILTER_COMPARISON_ANISOTROPIC is specified as the filter. Valid values
		/// are between 1 and 16.
		/// </summary>
		public uint MaxAnisotropy = maxAnisotropy;

		/// <summary>A function that compares sampled data against existing sampled data. The function options are listed in <c>D3D12_COMPARISON_FUNC</c>.</summary>
		public D3D12_COMPARISON_FUNC ComparisonFunc = comparisonFunc;

		/// <summary>
		/// One member of <c>D3D12_STATIC_BORDER_COLOR</c>, the border color to use if D3D12_TEXTURE_ADDRESS_MODE_BORDER is specified for
		/// AddressU, AddressV, or AddressW. Range must be between 0.0 and 1.0 inclusive.
		/// </summary>
		public D3D12_STATIC_BORDER_COLOR BorderColor = borderColor;

		/// <summary>
		/// Lower end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed.
		/// </summary>
		public float MinLOD = minLOD;

		/// <summary>
		/// Upper end of the mipmap range to clamp access to, where 0 is the largest and most detailed mipmap level and any level higher
		/// than that is less detailed. This value must be greater than or equal to MinLOD. To have no upper limit on LOD set this to a
		/// large value such as D3D12_FLOAT32_MAX.
		/// </summary>
		public float MaxLOD = maxLOD;

		/// <summary>
		/// The <i>ShaderRegister</i> and <i>RegisterSpace</i> parameters correspond to the binding syntax of HLSL. For example, in HLSL:
		/// <code language="none">Texture2D&lt;float4&gt; a : register(t2, space3);</code>
		/// <para>This corresponds to a <i>ShaderRegister</i> of 2 (indicating the type is SRV), and <i>RegisterSpace</i> is 3.</para>
		/// <para>
		/// The <i>ShaderRegister</i> and <i>RegisterSpace</i> pair is needed to establish correspondence between shader resources and
		/// runtime heap descriptors, using the root signature data structure.
		/// </para>
		/// </summary>
		public uint ShaderRegister = shaderRegister;

		/// <summary>See the description for <i>ShaderRegister</i>. Register space is optional; the default register space is 0.</summary>
		public uint RegisterSpace = registerSpace;

		/// <summary>Specifies the visibility of the sampler to the pipeline shaders, one member of <c>D3D12_SHADER_VISIBILITY</c>.</summary>
		public D3D12_SHADER_VISIBILITY ShaderVisibility = shaderVisibility;

		/// <summary/>
		public D3D12_SAMPLER_FLAGS Flags = flags;

		/// <summary>Performs an implicit conversion from <see cref="D3D12_STATIC_SAMPLER_DESC1"/> to <see cref="D3D12_STATIC_SAMPLER_DESC"/>.</summary>
		/// <param name="desc">The D3D12_STATIC_SAMPLER_DESC1.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D3D12_STATIC_SAMPLER_DESC(D3D12_STATIC_SAMPLER_DESC1 desc) => new(desc.ShaderRegister,
			desc.Filter, desc.AddressU, desc.AddressV, desc.AddressW, desc.MipLODBias, desc.MaxAnisotropy, desc.ComparisonFunc, desc.BorderColor,
			desc.MinLOD, desc.MaxLOD, desc.ShaderVisibility, desc.RegisterSpace);
	}

	/// <summary>Describes a stream output buffer.</summary>
	/// <remarks>Use this structure with <c>SOSetTargets</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_stream_output_buffer_view typedef struct
	// D3D12_STREAM_OUTPUT_BUFFER_VIEW { D3D12_GPU_VIRTUAL_ADDRESS BufferLocation; UINT64 SizeInBytes; D3D12_GPU_VIRTUAL_ADDRESS
	// BufferFilledSizeLocation; } D3D12_STREAM_OUTPUT_BUFFER_VIEW;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STREAM_OUTPUT_BUFFER_VIEW")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct D3D12_STREAM_OUTPUT_BUFFER_VIEW
	{
		/// <summary>
		/// A D3D12_GPU_VIRTUAL_ADDRESS (a UINT64) that points to the stream output buffer. If <b>SizeInBytes</b> is 0, this member isn't
		/// used and can be any value.
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

		/// <summary>The size of the stream output buffer in bytes.</summary>
		public ulong SizeInBytes;

		/// <summary>
		/// The location of the value of how much data has been filled into the buffer, as a D3D12_GPU_VIRTUAL_ADDRESS (a UINT64). This
		/// member can't be NULL; a filled size location must be supplied (which the hardware will increment as data is output). If
		/// <b>SizeInBytes</b> is 0, this member isn't used and can be any value.
		/// </summary>
		public D3D12_GPU_VIRTUAL_ADDRESS BufferFilledSizeLocation;
	}

	/// <summary>Describes a streaming output buffer.</summary>
	/// <remarks>A <c>D3D12_GRAPHICS_PIPELINE_STATE_DESC</c> object contains a <b>D3D12_STREAM_OUTPUT_DESC</b> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_stream_output_desc typedef struct D3D12_STREAM_OUTPUT_DESC {
	// const D3D12_SO_DECLARATION_ENTRY *pSODeclaration; UINT NumEntries; const UINT *pBufferStrides; UINT NumStrides; UINT
	// RasterizedStream; } D3D12_STREAM_OUTPUT_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_STREAM_OUTPUT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_STREAM_OUTPUT_DESC
	{
		/// <summary>An array of <c>D3D12_SO_DECLARATION_ENTRY</c> structures. Can't be <b>NULL</b> if <b>NumEntries</b> &gt; 0.</summary>
		public ManagedArrayPointer<D3D12_SO_DECLARATION_ENTRY> pSODeclaration;

		/// <summary>The number of entries in the stream output declaration array that the <b>pSODeclaration</b> member points to.</summary>
		public uint NumEntries;

		/// <summary>An array of buffer strides; each stride is the size of an element for that buffer.</summary>
		public ArrayPointer<uint> pBufferStrides;

		/// <summary>The number of strides (or buffers) that the <b>pBufferStrides</b> member points to.</summary>
		public uint NumStrides;

		/// <summary>The index number of the stream to be sent to the rasterizer stage.</summary>
		public uint RasterizedStream;
	}

	/// <summary>Associates a subobject defined directly in a state object with shader exports.</summary>
	/// <remarks>
	/// Depending on the flags specified in the optional <c>D3D12_STATE_OBJECT_CONFIG</c> subobject for opting into cross linkage, the
	/// exports being associated don’t necessarily have to be present in the current state object, or one that has been seen yet, to be
	/// resolved later, on raytracing pipeline state object (RTPSO) creation for example.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subobject_to_exports_association typedef struct
	// D3D12_SUBOBJECT_TO_EXPORTS_ASSOCIATION { const D3D12_STATE_SUBOBJECT *pSubobjectToAssociate; UINT NumExports; LPCWSTR *pExports; } D3D12_SUBOBJECT_TO_EXPORTS_ASSOCIATION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SUBOBJECT_TO_EXPORTS_ASSOCIATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SUBOBJECT_TO_EXPORTS_ASSOCIATION
	{
		/// <summary>Pointer to the subobject in current state object to define an association to.</summary>
		public StructPointer<D3D12_STATE_SUBOBJECT> pSubobjectToAssociate;

		/// <summary>
		/// Size of the <i>pExports</i> array. If 0, this is being explicitly defined as a default association. Another way to define a
		/// default association is to omit this subobject association for that subobject completely.
		/// </summary>
		public uint NumExports;

		/// <summary>The array of exports with which the subobject is associated.</summary>
		public LPCWSTRArrayPointer pExports;
	}

	/// <summary>Describes subresource data.</summary>
	/// <remarks>This structure is used by a number of the helper functions, refer to <c>Helper Structures and Functions for D3D12</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_data typedef struct D3D12_SUBRESOURCE_DATA {
	// const void *pData; LONG_PTR RowPitch; LONG_PTR SlicePitch; } D3D12_SUBRESOURCE_DATA;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SUBRESOURCE_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct D3D12_SUBRESOURCE_DATA(IntPtr pData, SizeT rowPitch, SizeT slicePitch)
	{
		/// <summary>A pointer to a memory block that contains the subresource data.</summary>
		public IntPtr pData = pData;

		/// <summary>The row pitch, or width, or physical size, in bytes, of the subresource data.</summary>
		public SizeT RowPitch = rowPitch;

		/// <summary>The depth pitch, or width, or physical size, in bytes, of the subresource data.</summary>
		public SizeT SlicePitch = slicePitch;
	}

	/// <summary>Describes the format, width, height, depth, and row-pitch of the subresource into the parent resource.</summary>
	/// <remarks>
	/// <para>Use this structure in the <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c> structure.</para>
	/// <para>The helper structure is <c>CD3DX12_SUBRESOURCE_FOOTPRINT</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_footprint typedef struct
	// D3D12_SUBRESOURCE_FOOTPRINT { DXGI_FORMAT Format; UINT Width; UINT Height; UINT Depth; UINT RowPitch; } D3D12_SUBRESOURCE_FOOTPRINT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SUBRESOURCE_FOOTPRINT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SUBRESOURCE_FOOTPRINT(DXGI.DXGI_FORMAT format, uint width, uint height, uint depth, uint rowPitch)
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value that specifies the viewing format.</summary>
		public DXGI_FORMAT Format = format;

		/// <summary>The width of the subresource.</summary>
		public uint Width = width;

		/// <summary>The height of the subresource.</summary>
		public uint Height = height;

		/// <summary>The depth of the subresource.</summary>
		public uint Depth = depth;

		/// <summary>
		/// The row pitch, or width, or physical size, in bytes, of the subresource data. This must be a multiple of
		/// D3D12_TEXTURE_DATA_PITCH_ALIGNMENT (256), and must be greater than or equal to the size of the data within a row.
		/// </summary>
		public uint RowPitch = rowPitch;

		/// <summary>Initializes a new instance of the <see cref="D3D12_SUBRESOURCE_FOOTPRINT"/> struct.</summary>
		/// <param name="resDesc">A <see cref="D3D12_RESOURCE_DESC"/> instance.</param>
		/// <param name="rowPitch">The row pitch, or width, or physical size, in bytes, of the subresource data.</param>
		public D3D12_SUBRESOURCE_FOOTPRINT(in D3D12_RESOURCE_DESC resDesc, uint rowPitch) :
			this(resDesc.Format, (uint)resDesc.Width, resDesc.Height,
				resDesc.Dimension == D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D ? resDesc.DepthOrArraySize : 1u, rowPitch)
		{ }
	}

	/// <summary>Describes subresource data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_info typedef struct D3D12_SUBRESOURCE_INFO {
	// UINT64 Offset; UINT RowPitch; UINT DepthPitch; } D3D12_SUBRESOURCE_INFO;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SUBRESOURCE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SUBRESOURCE_INFO
	{
		/// <summary>Offset, in bytes, between the start of the parent resource and this subresource.</summary>
		public ulong Offset;

		/// <summary>The row pitch, or width, or physical size, in bytes, of the subresource data.</summary>
		public uint RowPitch;

		/// <summary>The depth pitch, or width, or physical size, in bytes, of the subresource data.</summary>
		public uint DepthPitch;
	}

	/// <summary>Describes a subresource memory range.</summary>
	/// <remarks>This structure is used by the <c>AtomicCopyBufferUINT</c> and <c>AtomicCopyBufferUINT64</c> methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_range_uint64 typedef struct
	// D3D12_SUBRESOURCE_RANGE_UINT64 { UINT Subresource; D3D12_RANGE_UINT64 Range; } D3D12_SUBRESOURCE_RANGE_UINT64;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SUBRESOURCE_RANGE_UINT64")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SUBRESOURCE_RANGE_UINT64(uint subresource, in D3D12_RANGE_UINT64 range)
	{
		/// <summary>The index of the subresource.</summary>
		public uint Subresource = subresource;

		/// <summary>A memory range within the subresource.</summary>
		public D3D12_RANGE_UINT64 Range = range;

		/// <summary>Initializes a new instance of the <see cref="D3D12_SUBRESOURCE_RANGE_UINT64"/> struct.</summary>
		/// <param name="subresource">The index of the subresource.</param>
		/// <param name="begin">The offset, in bytes, denoting the beginning of a memory range.</param>
		/// <param name="end">The offset, in bytes, denoting the end of a memory range.</param>
		public D3D12_SUBRESOURCE_RANGE_UINT64(uint subresource, ulong begin, ulong end) :
			this(subresource, new D3D12_RANGE_UINT64 { Begin = begin, End = end })
		{
		}
	}

	/// <summary>Describes a tiled subresource volume.</summary>
	/// <remarks>This structure is used by the <c>GetResourceTiling</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_subresource_tiling typedef struct D3D12_SUBRESOURCE_TILING {
	// UINT WidthInTiles; UINT16 HeightInTiles; UINT16 DepthInTiles; UINT StartTileIndexInOverallResource; } D3D12_SUBRESOURCE_TILING;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_SUBRESOURCE_TILING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_SUBRESOURCE_TILING(uint widthInTiles, ushort heightInTiles, ushort depthInTiles, uint startTileIndexInOverallResource)
	{
		/// <summary>The width in tiles of the subresource.</summary>
		public uint WidthInTiles = widthInTiles;

		/// <summary>The height in tiles of the subresource.</summary>
		public ushort HeightInTiles = heightInTiles;

		/// <summary>The depth in tiles of the subresource.</summary>
		public ushort DepthInTiles = depthInTiles;

		/// <summary>The index of the tile in the overall tiled subresource to start with.</summary>
		public uint StartTileIndexInOverallResource = startTileIndexInOverallResource;
	}

	/// <summary>Describes the subresources from an array of 1D textures to use in a depth-stencil view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure to view the resource as an array of 1D textures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_array_dsv typedef struct D3D12_TEX1D_ARRAY_DSV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX1D_ARRAY_DSV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_ARRAY_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_ARRAY_DSV
	{
		/// <summary>The index of the first mipmap level to use.</summary>
		public uint MipSlice;

		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures to use.</summary>
		public uint ArraySize;
	}

	/// <summary>Describes the subresources from an array of 1D textures to use in a render-target view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as an array of 1D textures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_array_rtv typedef struct D3D12_TEX1D_ARRAY_RTV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX1D_ARRAY_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_ARRAY_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_ARRAY_RTV
	{
		/// <summary>The index of the mipmap level to use mip slice.</summary>
		public uint MipSlice;

		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures to use.</summary>
		public uint ArraySize;
	}

	/// <summary>Describes the subresources from an array of 1D textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_array_srv typedef struct D3D12_TEX1D_ARRAY_SRV { UINT
	// MostDetailedMip; UINT MipLevels; UINT FirstArraySlice; UINT ArraySize; FLOAT ResourceMinLODClamp; } D3D12_TEX1D_ARRAY_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_ARRAY_SRV
	{
		/// <summary>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> (from the original Texture1D for
		/// which <c>ID3D12Device::CreateShaderResourceView</c> creates a view) -1.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in <c>D3D12_TEX1D_SRV</c>.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures in the array.</summary>
		public uint ArraySize;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>Describes an array of unordered-access 1D texture resources.</summary>
	/// <remarks>Use this structure with a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure to view the resource as an array of 1D textures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_array_uav typedef struct D3D12_TEX1D_ARRAY_UAV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX1D_ARRAY_UAV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_ARRAY_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_ARRAY_UAV
	{
		/// <summary>The mipmap slice index.</summary>
		public uint MipSlice;

		/// <summary>The zero-based index of the first array slice to be accessed.</summary>
		public uint FirstArraySlice;

		/// <summary>The number of slices in the array.</summary>
		public uint ArraySize;
	}

	/// <summary>Describes the subresource from a 1D texture that is accessible to a depth-stencil view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure to view the resource as a 1D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_dsv typedef struct D3D12_TEX1D_DSV { UINT MipSlice; } D3D12_TEX1D_DSV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_DSV
	{
		/// <summary>The index of the first mipmap level to use.</summary>
		public uint MipSlice;
	}

	/// <summary>Describes the subresource from a 1D texture to use in a render-target view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as a 1D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_rtv typedef struct D3D12_TEX1D_RTV { UINT MipSlice; } D3D12_TEX1D_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_RTV
	{
		/// <summary>The index of the mipmap level to use mip slice.</summary>
		public uint MipSlice;
	}

	/// <summary>Specifies the subresource from a 1D texture to use in a shader-resource view.</summary>
	/// <remarks>
	/// <para>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</para>
	/// <para>
	/// As an example, assuming <b>MostDetailedMip</b> = 6 and <b>MipLevels</b> = 2, the view will have access to 2 mipmap levels, 6 and 7,
	/// of the original texture for which <c>ID3D12Device::CreateShaderResourceView</c> creates the view. In this situation,
	/// <b>MostDetailedMip</b> is greater than the <b>MipLevels</b> in the view. However, <b>MostDetailedMip</b> is not greater than the
	/// <b>MipLevels</b> in the original resource.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_srv typedef struct D3D12_TEX1D_SRV { UINT
	// MostDetailedMip; UINT MipLevels; FLOAT ResourceMinLODClamp; } D3D12_TEX1D_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_SRV
	{
		/// <summary>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> (from the original Texture1D for
		/// which <c>ID3D12Device::CreateShaderResourceView</c> creates a view) -1.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>Describes a unordered-access 1D texture resource.</summary>
	/// <remarks>Use this structure with a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure to view the resource as a 1D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex1d_uav typedef struct D3D12_TEX1D_UAV { UINT MipSlice; } D3D12_TEX1D_UAV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX1D_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX1D_UAV
	{
		/// <summary>The mipmap slice index.</summary>
		public uint MipSlice;
	}

	/// <summary>Describes the subresources from an array of 2D textures that are accessible to a depth-stencil view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure to view the resource as an array of 2D textures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_array_dsv typedef struct D3D12_TEX2D_ARRAY_DSV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX2D_ARRAY_DSV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_ARRAY_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_ARRAY_DSV
	{
		/// <summary>The index of the first mipmap level to use.</summary>
		public uint MipSlice;

		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures to use.</summary>
		public uint ArraySize;
	}

	/// <summary>Describes the subresources from an array of 2D textures to use in a render-target view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as an array of 2D textures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_array_rtv typedef struct D3D12_TEX2D_ARRAY_RTV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; UINT PlaneSlice; } D3D12_TEX2D_ARRAY_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_ARRAY_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_ARRAY_RTV
	{
		/// <summary>The index of the mipmap level to use mip slice.</summary>
		public uint MipSlice;

		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures in the array to use in the render target view, starting from <b>FirstArraySlice</b>.</summary>
		public uint ArraySize;

		/// <summary>The index (plane slice number) of the plane to use in an array of textures.</summary>
		public uint PlaneSlice;
	}

	/// <summary>Describes the subresources from an array of 2D textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_array_srv typedef struct D3D12_TEX2D_ARRAY_SRV { UINT
	// MostDetailedMip; UINT MipLevels; UINT FirstArraySlice; UINT ArraySize; UINT PlaneSlice; FLOAT ResourceMinLODClamp; } D3D12_TEX2D_ARRAY_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_ARRAY_SRV
	{
		/// <summary>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> -1 (where <b>MipLevels</b> is from
		/// the original Texture2D for which <c>ID3D12Device::CreateShaderResourceView</c> creates a view).
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in <c>D3D12_TEX1D_SRV</c>.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures in the array.</summary>
		public uint ArraySize;

		/// <summary>The index (plane slice number) of the plane to use in an array of textures.</summary>
		public uint PlaneSlice;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>Describes an array of unordered-access 2D texture resources.</summary>
	/// <remarks>Use this structure with a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure to view the resource as an array of 2D textures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_array_uav typedef struct D3D12_TEX2D_ARRAY_UAV { UINT
	// MipSlice; UINT FirstArraySlice; UINT ArraySize; UINT PlaneSlice; } D3D12_TEX2D_ARRAY_UAV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_ARRAY_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_ARRAY_UAV
	{
		/// <summary>The mipmap slice index.</summary>
		public uint MipSlice;

		/// <summary>The zero-based index of the first array slice to be accessed.</summary>
		public uint FirstArraySlice;

		/// <summary>The number of slices in the array.</summary>
		public uint ArraySize;

		/// <summary>The index (plane slice number) of the plane to use in an array of textures.</summary>
		public uint PlaneSlice;
	}

	/// <summary>Describes the subresource from a 2D texture that is accessible to a depth-stencil view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure to view the resource as a 2D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_dsv typedef struct D3D12_TEX2D_DSV { UINT MipSlice; } D3D12_TEX2D_DSV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_DSV
	{
		/// <summary>The index of the first mipmap level to use.</summary>
		public uint MipSlice;
	}

	/// <summary>Describes the subresource from a 2D texture to use in a render-target view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as a 2D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_rtv typedef struct D3D12_TEX2D_RTV { UINT MipSlice;
	// UINT PlaneSlice; } D3D12_TEX2D_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_RTV
	{
		/// <summary>The index of the mipmap level to use.</summary>
		public uint MipSlice;

		/// <summary>The index (plane slice number) of the plane to use in the texture.</summary>
		public uint PlaneSlice;
	}

	/// <summary>Describes the subresource from a 2D texture to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_srv typedef struct D3D12_TEX2D_SRV { UINT
	// MostDetailedMip; UINT MipLevels; UINT PlaneSlice; FLOAT ResourceMinLODClamp; } D3D12_TEX2D_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_SRV
	{
		/// <summary>
		/// The index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> (from the original Texture2D
		/// for which <c>ID3D12Device::CreateShaderResourceView</c> creates a view) -1.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// The maximum number of mipmap levels for the view of the texture. See the remarks in <c>D3D12_TEX1D_SRV</c>. Set to -1 to
		/// indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.
		/// </summary>
		public uint MipLevels;

		/// <summary>The index (plane slice number) of the plane to use in the texture.</summary>
		public uint PlaneSlice;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>Describes a unordered-access 2D texture resource.</summary>
	/// <remarks>Use this structure with a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure to view the resource as a 2D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2d_uav typedef struct D3D12_TEX2D_UAV { UINT MipSlice;
	// UINT PlaneSlice; } D3D12_TEX2D_UAV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2D_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2D_UAV
	{
		/// <summary>The mipmap slice index.</summary>
		public uint MipSlice;

		/// <summary>The index (plane slice number) of the plane to use in the texture.</summary>
		public uint PlaneSlice;
	}

	/// <summary>Describes the subresources from an array of multi sampled 2D textures for a depth-stencil view.</summary>
	/// <remarks>
	/// Use this structure with a <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure to view the resource as an array of multi sampled 2D textures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_array_dsv typedef struct D3D12_TEX2DMS_ARRAY_DSV {
	// UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX2DMS_ARRAY_DSV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2DMS_ARRAY_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_ARRAY_DSV
	{
		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures to use.</summary>
		public uint ArraySize;
	}

	/// <summary>Describes the subresources from an array of multi sampled 2D textures to use in a render-target view.</summary>
	/// <remarks>
	/// Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as an array of multi sampled 2D textures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_array_rtv typedef struct D3D12_TEX2DMS_ARRAY_RTV {
	// UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX2DMS_ARRAY_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2DMS_ARRAY_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_ARRAY_RTV
	{
		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>The number of textures to use.</summary>
		public uint ArraySize;
	}

	/// <summary>Describes the subresources from an array of multi sampled 2D textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_array_srv typedef struct D3D12_TEX2DMS_ARRAY_SRV {
	// UINT FirstArraySlice; UINT ArraySize; } D3D12_TEX2DMS_ARRAY_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2DMS_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_ARRAY_SRV
	{
		/// <summary>The index of the first texture to use in an array of textures.</summary>
		public uint FirstArraySlice;

		/// <summary>Number of textures to use.</summary>
		public uint ArraySize;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("d3d12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_ARRAY_UAV
	{
		/// <summary/>
		public uint FirstArraySlice;

		/// <summary/>
		public uint ArraySize;
	}

	/// <summary>Describes the subresource from a multi sampled 2D texture that is accessible to a depth-stencil view.</summary>
	/// <remarks>
	/// <para>This structure is a member of the <c>D3D12_DEPTH_STENCIL_VIEW_DESC</c> structure.</para>
	/// <para>
	/// Because a multi sampled 2D texture contains a single subresource, there is nothing to specify in <b>D3D12_TEX2DMS_DSV</b>.
	/// Consequently, <b>UnusedField_NothingToDefine</b> is included so that this structure will compile in C.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_dsv typedef struct D3D12_TEX2DMS_DSV { UINT
	// UnusedField_NothingToDefine; } D3D12_TEX2DMS_DSV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2DMS_DSV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_DSV
	{
		/// <summary>Unused.</summary>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Describes the subresource from a multi sampled 2D texture to use in a render-target view.</summary>
	/// <remarks>
	/// <para>This structure is a member of the <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure.</para>
	/// <para>
	/// Because a multi sampled 2D texture contains a single subresource, there is actually nothing to specify in <b>D3D12_TEX2DMS_RTV</b>.
	/// Consequently, <b>UnusedField_NothingToDefine</b> is included so that this structure will compile in C.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_rtv typedef struct D3D12_TEX2DMS_RTV { UINT
	// UnusedField_NothingToDefine; } D3D12_TEX2DMS_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2DMS_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_RTV
	{
		/// <summary>Integer of any value. See remarks.</summary>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Describes the subresources from a multi sampled 2D texture to use in a shader-resource view.</summary>
	/// <remarks>
	/// <para>This structure is a member of the <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c> structure.</para>
	/// <para>
	/// Since a multi sampled 2D texture contains a single subresource, there is actually nothing to specify in <b>D3D12_TEX2DMS_SRV</b>.
	/// Consequently, <b>UnusedField_NothingToDefine</b> is included so that this structure will compile in C.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex2dms_srv typedef struct D3D12_TEX2DMS_SRV { UINT
	// UnusedField_NothingToDefine; } D3D12_TEX2DMS_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX2DMS_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_SRV
	{
		/// <summary>Integer of any value. See remarks.</summary>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("d3d12.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX2DMS_UAV
	{
		/// <summary/>
		public uint UnusedField_NothingToDefine;
	}

	/// <summary>Describes the subresources from a 3D texture to use in a render-target view.</summary>
	/// <remarks>Use this structure with a <c>D3D12_RENDER_TARGET_VIEW_DESC</c> structure to view the resource as a 3D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex3d_rtv typedef struct D3D12_TEX3D_RTV { UINT MipSlice;
	// UINT FirstWSlice; UINT WSize; } D3D12_TEX3D_RTV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX3D_RTV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX3D_RTV
	{
		/// <summary>The index of the mipmap level to use mip slice.</summary>
		public uint MipSlice;

		/// <summary>First depth level to use.</summary>
		public uint FirstWSlice;

		/// <summary>
		/// Number of depth levels to use in the render-target view, starting from <b>FirstWSlice</b>. A value of -1 indicates all of the
		/// slices along the w axis, starting from <b>FirstWSlice</b>.
		/// </summary>
		public uint WSize;
	}

	/// <summary>Describes the subresources from a 3D texture to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex3d_srv typedef struct D3D12_TEX3D_SRV { UINT
	// MostDetailedMip; UINT MipLevels; FLOAT ResourceMinLODClamp; } D3D12_TEX3D_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX3D_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX3D_SRV
	{
		/// <summary>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> (from the original Texture3D for
		/// which <c>ID3D12Device::CreateShaderResourceView</c> creates a view) -1.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in <c>D3D12_TEX1D_SRV</c>.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>Describes a unordered-access 3D texture resource.</summary>
	/// <remarks>Use this structure with a <c>D3D12_UNORDERED_ACCESS_VIEW_DESC</c> structure to view the resource as a 3D texture.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tex3d_uav typedef struct D3D12_TEX3D_UAV { UINT MipSlice;
	// UINT FirstWSlice; UINT WSize; } D3D12_TEX3D_UAV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEX3D_UAV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEX3D_UAV
	{
		/// <summary>The mipmap slice index.</summary>
		public uint MipSlice;

		/// <summary>The zero-based index of the first depth slice to be accessed.</summary>
		public uint FirstWSlice;

		/// <summary>
		/// <para>The number of depth slices.</para>
		/// <para>Set to -1 to indicate all the depth slices from <b>FirstWSlice</b> to the last slice.</para>
		/// </summary>
		public uint WSize;
	}

	/// <summary>Describes the subresources from an array of cube textures to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_texcube_array_srv typedef struct D3D12_TEXCUBE_ARRAY_SRV {
	// UINT MostDetailedMip; UINT MipLevels; UINT First2DArrayFace; UINT NumCubes; FLOAT ResourceMinLODClamp; } D3D12_TEXCUBE_ARRAY_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEXCUBE_ARRAY_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEXCUBE_ARRAY_SRV
	{
		/// <summary>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> (from the original TextureCube for
		/// which <c>ID3D12Device::CreateShaderResourceView</c> creates a view) -1.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in <c>D3D12_TEX1D_SRV</c>.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>Index of the first 2D texture to use.</summary>
		public uint First2DArrayFace;

		/// <summary>Number of cube textures in the array.</summary>
		public uint NumCubes;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>Describes the subresource from a cube texture to use in a shader-resource view.</summary>
	/// <remarks>This structure is one member of a shader-resource-view description, <c>D3D12_SHADER_RESOURCE_VIEW_DESC</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_texcube_srv typedef struct D3D12_TEXCUBE_SRV { UINT
	// MostDetailedMip; UINT MipLevels; FLOAT ResourceMinLODClamp; } D3D12_TEXCUBE_SRV;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEXCUBE_SRV")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEXCUBE_SRV
	{
		/// <summary>
		/// Index of the most detailed mipmap level to use; this number is between 0 and <b>MipLevels</b> (from the original TextureCube for
		/// which <c>ID3D12Device::CreateShaderResourceView</c> creates a view) -1.
		/// </summary>
		public uint MostDetailedMip;

		/// <summary>
		/// <para>The maximum number of mipmap levels for the view of the texture. See the remarks in <c>D3D12_TEX1D_SRV</c>.</para>
		/// <para>Set to -1 to indicate all the mipmap levels from <b>MostDetailedMip</b> on down to least detailed.</para>
		/// </summary>
		public uint MipLevels;

		/// <summary>
		/// <para>
		/// Specifies the minimum mipmap level that you can access. Specifying 0.0f means that you can access all of the mipmap levels.
		/// Specifying 3.0f means that you can access mipmap levels from 3.0f to MipCount - 1.
		/// </para>
		/// <para>
		/// We recommend that you don't set MostDetailedMip and ResourceMinLODClamp at the same time. Instead, set one of those two members
		/// to 0 (to get default behavior). That's because MipLevels is interpreted differently in conjunction with different fields:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>For MostDetailedMip, mips are in the range [MostDetailedMip, MostDetailedMip + MipLevels - 1].</description>
		/// </item>
		/// <item>
		/// <description>For ResourceMinLODClamp, mips are in the range [ResourceMinLODClamp, MipLevels - 1].</description>
		/// </item>
		/// </list>
		/// </summary>
		public float ResourceMinLODClamp;
	}

	/// <summary>
	/// Describes a texture memory access barrier. Used by texture barriers to indicate when resource memory must be made visible for a
	/// specific access type. Layout transitions are needed only for textures.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_texture_barrier typedef struct D3D12_TEXTURE_BARRIER {
	// D3D12_BARRIER_SYNC SyncBefore; D3D12_BARRIER_SYNC SyncAfter; D3D12_BARRIER_ACCESS AccessBefore; D3D12_BARRIER_ACCESS AccessAfter;
	// D3D12_BARRIER_LAYOUT LayoutBefore; D3D12_BARRIER_LAYOUT LayoutAfter; ID3D12Resource *pResource; D3D12_BARRIER_SUBRESOURCE_RANGE
	// Subresources; D3D12_TEXTURE_BARRIER_FLAGS Flags; } D3D12_TEXTURE_BARRIER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEXTURE_BARRIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEXTURE_BARRIER(D3D12_BARRIER_SYNC syncBefore, D3D12_BARRIER_SYNC syncAfter, D3D12_BARRIER_ACCESS accessBefore,
		D3D12_BARRIER_ACCESS accessAfter, D3D12_BARRIER_LAYOUT layoutBefore, D3D12_BARRIER_LAYOUT layoutAfter, ID3D12Resource resource,
		in D3D12_BARRIER_SUBRESOURCE_RANGE subresources, D3D12_TEXTURE_BARRIER_FLAGS flags = 0)
	{
		/// <summary>Synchronization scope of all preceding GPU work that must be completed before executing the barrier.</summary>
		public D3D12_BARRIER_SYNC SyncBefore = syncBefore;

		/// <summary>Synchronization scope of all subsequent GPU work that must wait until the barrier execution is finished.</summary>
		public D3D12_BARRIER_SYNC SyncAfter = syncAfter;

		/// <summary>
		/// Access bits corresponding with resource usage since the preceding barrier or the start of <b>ExecuteCommandLists</b> scope.
		/// </summary>
		public D3D12_BARRIER_ACCESS AccessBefore = accessBefore;

		/// <summary>Access bits corresponding with resource usage after the barrier completes.</summary>
		public D3D12_BARRIER_ACCESS AccessAfter = accessAfter;

		/// <summary>Layout of texture preceding the barrier execution.</summary>
		public D3D12_BARRIER_LAYOUT LayoutBefore = layoutBefore;

		/// <summary>Layout of texture upon completion of barrier execution.</summary>
		public D3D12_BARRIER_LAYOUT LayoutAfter = layoutAfter;

		/// <summary>Pointer to the buffer resource being using the barrier.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12Resource pResource = resource;

		/// <summary>Range of texture subresources being barriered.</summary>
		public D3D12_BARRIER_SUBRESOURCE_RANGE Subresources = subresources;

		/// <summary>Optional flags values.</summary>
		public D3D12_TEXTURE_BARRIER_FLAGS Flags = flags;
	}

	/// <summary>Describes a portion of a texture for the purpose of texture copies.</summary>
	/// <remarks>Use this structure with <c>CopyTextureRegion</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_texture_copy_location typedef struct
	// D3D12_TEXTURE_COPY_LOCATION { ID3D12Resource *pResource; D3D12_TEXTURE_COPY_TYPE Type; union { D3D12_PLACED_SUBRESOURCE_FOOTPRINT
	// PlacedFootprint; UINT SubresourceIndex; }; } D3D12_TEXTURE_COPY_LOCATION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TEXTURE_COPY_LOCATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TEXTURE_COPY_LOCATION
	{
		/// <summary>
		/// <para>Specifies the resource which will be used for the copy operation.</para>
		/// <para>When Type is D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT, pResource must point to a buffer resource.</para>
		/// <para>When Type is D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX, pResource must point to a texture resource.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Interface)]
		public ID3D12Resource pResource;

		/// <summary>
		/// Specifies which type of resource location this is: a subresource of a texture, or a description of a texture layout which can be
		/// applied to a buffer. This <c>D3D12_TEXTURE_COPY_TYPE</c> enum indicates which union member to use.
		/// </summary>
		public D3D12_TEXTURE_COPY_TYPE Type;

		private UNION _union;

		/// <summary>
		/// Specifies a texture layout, with offset, dimensions, and pitches, for the hardware to understand how to treat a section of a
		/// buffer resource as a multi-dimensional texture. To fill-in the correct data for a <c>CopyTextureRegion</c> call, see <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>.
		/// </summary>
		public D3D12_PLACED_SUBRESOURCE_FOOTPRINT PlacedFootprint { readonly get => _union.PlacedFootprint; set => _union.PlacedFootprint = value; }

		/// <summary>
		/// Specifies the index of the subresource of an arrayed, mip-mapped, or planar texture should be used for the copy operation.
		/// </summary>
		public uint SubresourceIndex { readonly get => _union.SubresourceIndex; set => _union.SubresourceIndex = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public D3D12_PLACED_SUBRESOURCE_FOOTPRINT PlacedFootprint;

			[FieldOffset(0)]
			public uint SubresourceIndex;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_TEXTURE_COPY_LOCATION"/> struct.</summary>
		/// <param name="resource">Specifies the resource which will be used for the copy operation.</param>
		/// <param name="subresourceIndex">
		/// Specifies the index of the subresource of an arrayed, mip-mapped, or planar texture should be used for the copy operation.
		/// </param>
		public D3D12_TEXTURE_COPY_LOCATION(ID3D12Resource resource, uint subresourceIndex = 0)
		{
			pResource = resource;
			Type = D3D12_TEXTURE_COPY_TYPE.D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX;
			_union = new UNION { SubresourceIndex = subresourceIndex };
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_TEXTURE_COPY_LOCATION"/> struct.</summary>
		/// <param name="resource">Specifies the resource which will be used for the copy operation.</param>
		/// <param name="placedFootprint">
		/// Specifies a texture layout, with offset, dimensions, and pitches, for the hardware to understand how to treat a section of a
		/// buffer resource as a multi-dimensional texture. To fill-in the correct data for a <c>CopyTextureRegion</c> call, see <c>D3D12_PLACED_SUBRESOURCE_FOOTPRINT</c>.
		/// </param>
		public D3D12_TEXTURE_COPY_LOCATION(ID3D12Resource resource, in D3D12_PLACED_SUBRESOURCE_FOOTPRINT placedFootprint)
		{
			pResource = resource;
			Type = D3D12_TEXTURE_COPY_TYPE.D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT;
			_union = new UNION { PlacedFootprint = placedFootprint };
		}
	}

	/// <summary>Describes the size of a tiled region.</summary>
	/// <remarks>This structure is used by the CopyTiles, CopyTileMappings and UpdateTileMappings methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tile_region_size typedef struct D3D12_TILE_REGION_SIZE {
	// UINT NumTiles; BOOL UseBox; UINT Width; UINT16 Height; UINT16 Depth; } D3D12_TILE_REGION_SIZE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TILE_REGION_SIZE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TILE_REGION_SIZE(uint numTiles, bool useBox, uint width, ushort height, ushort depth)
	{
		/// <summary>The number of tiles in the tiled region.</summary>
		public uint NumTiles = numTiles;

		/// <summary>
		/// <para>Specifies whether the runtime uses the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members to define the region.</para>
		/// <para>
		/// If <c>TRUE</c>, the runtime uses the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members to define the region. In this case,
		/// <c>NumTiles</c> should be equal to <c>Width</c> * <c>Height</c> * <c>Depth</c>.
		/// </para>
		/// <para>
		/// If <c>FALSE</c>, the runtime ignores the <c>Width</c>, <c>Height</c>, and <c>Depth</c> members and uses the <c>NumTiles</c>
		/// member to traverse tiles in the resource linearly across x, then y, then z (as applicable) and then spills over mipmaps/arrays
		/// in subresource order. For example, use this technique to map an entire resource at once.
		/// </para>
		/// <para>
		/// Regardless of whether you specify <c>TRUE</c> or <c>FALSE</c> for <c>UseBox</c>, you use a D3D12_TILED_RESOURCE_COORDINATE
		/// structure to specify the starting location for the region within the resource as a separate parameter outside of this structure
		/// by using x, y, and z coordinates.
		/// </para>
		/// <para>
		/// When the region includes mipmaps that are packed with nonstandard tiling, <c>UseBox</c> must be <c>FALSE</c> because tile
		/// dimensions are not standard and the app only knows a count of how many tiles are consumed by the packed area, which is per array
		/// slice. The corresponding (separate) starting location parameter uses x to offset into the flat range of tiles in this case, and
		/// y and z coordinates must each be 0.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool UseBox = useBox;

		/// <summary>The width of the tiled region, in tiles. Used for buffer and 1D, 2D, and 3D textures.</summary>
		public uint Width = width;

		/// <summary>The height of the tiled region, in tiles. Used for 2D and 3D textures.</summary>
		public ushort Height = height;

		/// <summary>
		/// The depth of the tiled region, in tiles. Used for 3D textures or arrays. For arrays, used for advancing in depth jumps to next
		/// slice of same mipmap size, which isn't contiguous in the subresource counting space if there are multiple mipmaps.
		/// </summary>
		public ushort Depth = depth;
	}

	/// <summary>Describes the shape of a tile by specifying its dimensions.</summary>
	/// <remarks>This structure is used by the <c>GetResourceTiling</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tile_shape typedef struct D3D12_TILE_SHAPE { UINT
	// WidthInTexels; UINT HeightInTexels; UINT DepthInTexels; } D3D12_TILE_SHAPE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TILE_SHAPE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TILE_SHAPE(uint widthInTexels, uint heightInTexels, uint depthInTexels)
	{
		/// <summary>The width in texels of the tile.</summary>
		public uint WidthInTexels = widthInTexels;

		/// <summary>The height in texels of the tile.</summary>
		public uint HeightInTexels = heightInTexels;

		/// <summary>The depth in texels of the tile.</summary>
		public uint DepthInTexels = depthInTexels;
	}

	/// <summary>Describes the coordinates of a tiled resource.</summary>
	/// <remarks>This structure is used by the CopyTiles, CopyTileMappings and UpdateTileMappings methods.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tiled_resource_coordinate typedef struct
	// D3D12_TILED_RESOURCE_COORDINATE { UINT X; UINT Y; UINT Z; UINT Subresource; } D3D12_TILED_RESOURCE_COORDINATE;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_TILED_RESOURCE_COORDINATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_TILED_RESOURCE_COORDINATE(uint x, uint y, uint z, uint subresource)
	{
		/// <summary>The x-coordinate of the tiled resource.</summary>
		public uint X = x;

		/// <summary>The y-coordinate of the tiled resource.</summary>
		public uint Y = y;

		/// <summary>The z-coordinate of the tiled resource.</summary>
		public uint Z = z;

		/// <summary>
		/// <para>The index of the subresource for the tiled resource.</para>
		/// <para>
		/// For mipmaps that use nonstandard tiling, or are packed, or both use nonstandard tiling and are packed, any subresource value
		/// that indicates any of the packed mipmaps all refer to the same tile. Additionally, the X coordinate is used to indicate a tile
		/// within the packed mip region, rather than a logical region of a single subresource. The Y and Z coordinates must be zero.
		/// </para>
		/// </summary>
		public uint Subresource = subresource;
	}

	/// <summary>Describes the subresources from a resource that are accessible by using an unordered-access view.</summary>
	/// <remarks>Pass an unordered-access-view description into <c>ID3D12Device::CreateUnorderedAccessView</c> to create a view.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_unordered_access_view_desc typedef struct
	// D3D12_UNORDERED_ACCESS_VIEW_DESC { DXGI_FORMAT Format; D3D12_UAV_DIMENSION ViewDimension; union { D3D12_BUFFER_UAV Buffer;
	// D3D12_TEX1D_UAV Texture1D; D3D12_TEX1D_ARRAY_UAV Texture1DArray; D3D12_TEX2D_UAV Texture2D; D3D12_TEX2D_ARRAY_UAV Texture2DArray;
	// D3D12_TEX2DMS_UAV Texture2DMS; D3D12_TEX2DMS_ARRAY_UAV Texture2DMSArray; D3D12_TEX3D_UAV Texture3D; }; } D3D12_UNORDERED_ACCESS_VIEW_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_UNORDERED_ACCESS_VIEW_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_UNORDERED_ACCESS_VIEW_DESC
	{
		/// <summary>A <c>DXGI_FORMAT</c>-typed value that specifies the viewing format.</summary>
		[FieldOffset(0)]
		public DXGI_FORMAT Format;

		/// <summary>
		/// A <c>D3D12_UAV_DIMENSION</c>-typed value that specifies the resource type of the view. This type specifies how the resource will
		/// be accessed. This member also determines which _UAV to use in the union below.
		/// </summary>
		[FieldOffset(4)]
		public D3D12_UAV_DIMENSION ViewDimension;

		/// <summary>A <c>D3D12_BUFFER_UAV</c> structure that specifies which buffer elements can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_BUFFER_UAV Buffer;

		/// <summary>A <c>D3D12_TEX1D_UAV</c> structure that specifies the subresources in a 1D texture that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX1D_UAV Texture1D;

		/// <summary>A <c>D3D12_TEX1D_ARRAY_UAV</c> structure that specifies the subresources in a 1D texture array that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX1D_ARRAY_UAV Texture1DArray;

		/// <summary>A <c>D3D12_TEX2D_UAV</c> structure that specifies the subresources in a 2D texture that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX2D_UAV Texture2D;

		/// <summary>A <c>D3D12_TEX2D_ARRAY_UAV</c> structure that specifies the subresources in a 2D texture array that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX2D_ARRAY_UAV Texture2DArray;

		/// <summary/>
		[FieldOffset(8)]
		public D3D12_TEX2DMS_UAV Texture2DMS;

		/// <summary/>
		[FieldOffset(8)]
		public D3D12_TEX2DMS_ARRAY_UAV Texture2DMSArray;

		/// <summary>A <c>D3D12_TEX3D_UAV</c> structure that specifies subresources in a 3D texture that can be accessed.</summary>
		[FieldOffset(8)]
		public D3D12_TEX3D_UAV Texture3D;
	}

	/// <summary>
	/// Represents versioned Device Removed Extended Data (DRED) data, so that debuggers and debugger extensions can access DRED data.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_versioned_device_removed_extended_data typedef struct
	// D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA { D3D12_DRED_VERSION Version; union { D3D12_DEVICE_REMOVED_EXTENDED_DATA Dred_1_0;
	// D3D12_DEVICE_REMOVED_EXTENDED_DATA1 Dred_1_1; D3D12_DEVICE_REMOVED_EXTENDED_DATA2 Dred_1_2; D3D12_DEVICE_REMOVED_EXTENDED_DATA3
	// Dred_1_3; }; } D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
	public struct D3D12_VERSIONED_DEVICE_REMOVED_EXTENDED_DATA
	{
		/// <summary>
		/// A <c>D3D12_DRED_VERSION</c> value, specifying a DRED version. This value determines which inner data member (of the union) is active.
		/// </summary>
		[FieldOffset(0)]
		public D3D12_DRED_VERSION Version;

		/// <summary>A <c>D3D12_DEVICE_REMOVED_EXTENDED_DATA</c> value, containing DRED version 1.0 data.</summary>
		[FieldOffset(8)]
		public D3D12_DEVICE_REMOVED_EXTENDED_DATA Dred_1_0;

		/// <summary>A <c>D3D12_DEVICE_REMOVED_EXTENDED_DATA1</c> value, containing DRED version 1.1 data.</summary>
		[FieldOffset(8)]
		public D3D12_DEVICE_REMOVED_EXTENDED_DATA1 Dred_1_1;

		/// <summary/>
		[FieldOffset(8)]
		public D3D12_DEVICE_REMOVED_EXTENDED_DATA2 Dred_1_2;

		/// <summary/>
		[FieldOffset(8)]
		public D3D12_DEVICE_REMOVED_EXTENDED_DATA3 Dred_1_3;
	}

	/// <summary>Holds any version of a root signature description, and is designed to be used with serialization/deserialization functions.</summary>
	/// <remarks>
	/// <para>Use this structure with the following methods.</para>
	/// <list type="bullet">
	/// <item>
	/// <description><c>GetRootSignatureDescAtVersion</c></description>
	/// </item>
	/// <item>
	/// <description><c>GetUnconvertedRootSignatureDesc</c></description>
	/// </item>
	/// <item>
	/// <description><c>D3D12SerializeVersionedRootSignature</c></description>
	/// </item>
	/// </list>
	/// <para>Refer to the helper structure <c>CD3DX12_VERSIONED_ROOT_SIGNATURE_DESC</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_versioned_root_signature_desc typedef struct
	// D3D12_VERSIONED_ROOT_SIGNATURE_DESC { D3D_ROOT_SIGNATURE_VERSION Version; union { D3D12_ROOT_SIGNATURE_DESC Desc_1_0;
	// D3D12_ROOT_SIGNATURE_DESC1 Desc_1_1; D3D12_ROOT_SIGNATURE_DESC2 Desc_1_2; }; } D3D12_VERSIONED_ROOT_SIGNATURE_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VERSIONED_ROOT_SIGNATURE_DESC")]
	[StructLayout(LayoutKind.Explicit)]
	public struct D3D12_VERSIONED_ROOT_SIGNATURE_DESC
	{
		/// <summary>Specifies one member of D3D_ROOT_SIGNATURE_VERSION that determines the contents of the union.</summary>
		[FieldOffset(0)]
		public D3D_ROOT_SIGNATURE_VERSION Version = D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_1;

		/// <summary>Specifies a <c>D3D12_ROOT_SIGNATURE_DESC</c> (version 1.0).</summary>
		[FieldOffset(8)]
		public D3D12_ROOT_SIGNATURE_DESC Desc_1_0;

		/// <summary>Specifies a <c>D3D12_ROOT_SIGNATURE_DESC1</c> (version 1.1).</summary>
		[FieldOffset(8)]
		public D3D12_ROOT_SIGNATURE_DESC1 Desc_1_1;

		/// <summary/>
		[FieldOffset(8)]
		public D3D12_ROOT_SIGNATURE_DESC2 Desc_1_2;

		/// <summary>Initializes a new instance of the <see cref="D3D12_VERSIONED_ROOT_SIGNATURE_DESC"/> struct.</summary>
		/// <param name="Flags">Specifies options for the root signature layout.</param>
		public D3D12_VERSIONED_ROOT_SIGNATURE_DESC(D3D12_ROOT_SIGNATURE_FLAGS Flags) : this()
		{
			Version = D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_1;
			Desc_1_1 = new(null, null, Flags, out _);
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_VERSIONED_ROOT_SIGNATURE_DESC"/> struct.</summary>
		/// <param name="desc">A <c>D3D12_ROOT_SIGNATURE_DESC</c> structure for the root signature.</param>
		public D3D12_VERSIONED_ROOT_SIGNATURE_DESC(in D3D12_ROOT_SIGNATURE_DESC desc)
		{
			Version = D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_0;
			Desc_1_0 = desc;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_VERSIONED_ROOT_SIGNATURE_DESC"/> struct.</summary>
		/// <param name="desc">A <c>D3D12_ROOT_SIGNATURE_DESC1</c> structure for the root signature.</param>
		public D3D12_VERSIONED_ROOT_SIGNATURE_DESC(in D3D12_ROOT_SIGNATURE_DESC1 desc)
		{
			Version = D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_1;
			Desc_1_1 = desc;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_VERSIONED_ROOT_SIGNATURE_DESC"/> struct.</summary>
		/// <param name="desc">A <c>D3D12_ROOT_SIGNATURE_DESC2</c> structure for the root signature.</param>
		public D3D12_VERSIONED_ROOT_SIGNATURE_DESC(in D3D12_ROOT_SIGNATURE_DESC2 desc)
		{
			Version = D3D_ROOT_SIGNATURE_VERSION.D3D_ROOT_SIGNATURE_VERSION_1_2;
			Desc_1_2 = desc;
		}
	}

	/// <summary>Describes a vertex buffer view.</summary>
	/// <remarks>Use this structure with the <c>IASetVertexBuffers</c> method.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_vertex_buffer_view typedef struct D3D12_VERTEX_BUFFER_VIEW {
	// D3D12_GPU_VIRTUAL_ADDRESS BufferLocation; UINT SizeInBytes; UINT StrideInBytes; } D3D12_VERTEX_BUFFER_VIEW;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VERTEX_BUFFER_VIEW")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct D3D12_VERTEX_BUFFER_VIEW
	{
		/// <summary>Specifies a D3D12_GPU_VIRTUAL_ADDRESS that identifies the address of the buffer.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS BufferLocation;

		/// <summary>Specifies the size in bytes of the buffer.</summary>
		public uint SizeInBytes;

		/// <summary>Specifies the size in bytes of each vertex entry.</summary>
		public uint StrideInBytes;
	}

	/// <summary>Specifies the viewport/stencil and render target associated with a view instance.</summary>
	/// <remarks>
	/// <para>
	/// The values specified in a view instance location structure can be added to ViewportArrayIndex and RenderTargetArrayIndex values
	/// output by the shader prior to rasterization to compute the final effective index of the viewport and render target to send
	/// primitives to. If a computed index is out of range (that is, when the index is larger than the number of viewport or render target
	/// elements in their respective arrays) then the effective index becomes 0.
	/// </para>
	/// <para>
	/// For shaders that dynamically select the viewport or render target indices, an application can set all the view instance locations
	/// declared in a PSO to the same value to act as a uniform base value for all views.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_view_instance_location typedef struct
	// D3D12_VIEW_INSTANCE_LOCATION { UINT ViewportArrayIndex; UINT RenderTargetArrayIndex; } D3D12_VIEW_INSTANCE_LOCATION;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VIEW_INSTANCE_LOCATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIEW_INSTANCE_LOCATION
	{
		/// <summary>The index of the viewport in the viewports array to be used by the view instance associated with this location.</summary>
		public uint ViewportArrayIndex;

		/// <summary>
		/// The index of the render target in the render targets array to be used by the view instance associated with this location.
		/// </summary>
		public uint RenderTargetArrayIndex;
	}

	/// <summary>Specifies parameters used during view instancing configuration.</summary>
	/// <remarks>
	/// <para>
	/// View instancing is declared in a PSO using this structure. The view instance count is set in the PSO to allow whole-pipeline
	/// optimization based on the number of views.
	/// </para>
	/// <para>
	/// View instancing is disabled when it's not declared in the PSO or when ViewInstanceCount is set to 0. When disabled, rendering
	/// behaves as if view instancing is enabled and ViewInstanceCount is set to 1; shaders only see a value of 0 in SV_ViewID and just one
	/// view instance is produced. This allows shaders that are aware of view instancing to still be used in PSOs that disable it. Some
	/// adapters might support shader model 6.1 (which exposes SV_ViewID) but not view instancing; these adapters must still support shaders
	/// that input SV_ViewID in PSOs that declare ViewInstanceCount as 0 or 1.
	/// </para>
	/// <para>
	/// The shader prior to rasterization can output SV_RenderTargetArrayIndex and SV_ViewportArrayIndex values which don't have to depend
	/// on SV_ViewID. To compute the final effective index of the viewport and render target where primitives will be sent, these values,
	/// when present, are added to the ViewportArrayIndex and RenderTargetArrayIndex values of the view instance locations declared in the
	/// PSO. If a computed index is out of range (that is, when the index is larger than the number of viewport or render target elements in
	/// their respective arrays) then the effective index becomes 0.
	/// </para>
	/// <para>
	/// For shaders that dynamically select the viewport or render target indices, an application can set all the view instance locations
	/// declared in the PSO to a single value (such as 0) to act as a uniform base index to which the dynamically-selected
	/// SV_RenderTargetArrayIndex and SV_ViewportArrayIndex values are added.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_view_instancing_desc typedef struct
	// D3D12_VIEW_INSTANCING_DESC { UINT ViewInstanceCount; const D3D12_VIEW_INSTANCE_LOCATION *pViewInstanceLocations;
	// D3D12_VIEW_INSTANCING_FLAGS Flags; } D3D12_VIEW_INSTANCING_DESC;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VIEW_INSTANCING_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIEW_INSTANCING_DESC
	{
		/// <summary>Specifies the number of views to be used, up to D3D12_MAX_VIEW_INSTANCE_COUNT.</summary>
		public uint ViewInstanceCount;

		/// <summary>
		/// The address of a memory location that contains <b>ViewInstanceCount</b> view instance location structures that specify the
		/// location of viewport/scissor and render target details of each view instance.
		/// </summary>
		public ArrayPointer<D3D12_VIEW_INSTANCE_LOCATION> pViewInstanceLocations;

		/// <summary>Configures view instancing with additional options.</summary>
		public D3D12_VIEW_INSTANCING_FLAGS Flags;

		/// <summary>Initializes a new instance of the <see cref="D3D12_VIEW_INSTANCING_DESC"/> struct.</summary>
		/// <param name="cViewInstance">The number of views to be used, up to D3D12_MAX_VIEW_INSTANCE_COUNT.</param>
		/// <param name="pViewInstanceLocations">The view instance locations.</param>
		/// <param name="flags">Configures view instancing with additional options.</param>
		public D3D12_VIEW_INSTANCING_DESC([Optional] SizeT cViewInstance, [In, Optional] ArrayPointer<D3D12_VIEW_INSTANCE_LOCATION> pViewInstanceLocations,
			[Optional] D3D12_VIEW_INSTANCING_FLAGS flags)
		{
			ViewInstanceCount = cViewInstance;
			this.pViewInstanceLocations = pViewInstanceLocations;
			Flags = flags;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_VIEW_INSTANCING_DESC"/> struct.</summary>
		/// <param name="pViewInstanceLocations">The view instance locations.</param>
		/// <param name="flags">Configures view instancing with additional options.</param>
		/// <param name="memoryHandle">A memory handle to allocated memory for <paramref name="pViewInstanceLocations"/>.</param>
		public D3D12_VIEW_INSTANCING_DESC([In] D3D12_VIEW_INSTANCE_LOCATION[]? pViewInstanceLocations, D3D12_VIEW_INSTANCING_FLAGS flags, out SafeAllocatedMemoryHandle memoryHandle)
		{
			ViewInstanceCount = (uint?)pViewInstanceLocations?.Length ?? 0;
			this.pViewInstanceLocations = memoryHandle = SafeCoTaskMemHandle.CreateFromList(pViewInstanceLocations ?? []);
			Flags = flags;
		}
	}

	/// <summary>Describes the dimensions of a viewport.</summary>
	/// <remarks>
	/// Pass an array of these structures to the <i>pViewports</i> parameter in a call to <c>ID3D12GraphicsCommandList::RSSetViewports</c>
	/// to set viewports for the display.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_viewport typedef struct D3D12_VIEWPORT { FLOAT TopLeftX;
	// FLOAT TopLeftY; FLOAT Width; FLOAT Height; FLOAT MinDepth; FLOAT MaxDepth; } D3D12_VIEWPORT;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_VIEWPORT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_VIEWPORT
	{
		/// <summary>X position of the left hand side of the viewport.</summary>
		public float TopLeftX;

		/// <summary>Y position of the top of the viewport.</summary>
		public float TopLeftY;

		/// <summary>Width of the viewport.</summary>
		public float Width;

		/// <summary>Height of the viewport.</summary>
		public float Height;

		/// <summary>Minimum depth of the viewport. Ranges between 0 and 1.</summary>
		public float MinDepth;

		/// <summary>Maximum depth of the viewport. Ranges between 0 and 1.</summary>
		public float MaxDepth;

		/// <summary>Initializes a new instance of the <see cref="D3D12_VIEWPORT"/> struct.</summary>
		/// <param name="topLeftX">X position of the left hand side of the viewport.</param>
		/// <param name="topLeftY">Y position of the top of the viewport.</param>
		/// <param name="width">Width of the viewport.</param>
		/// <param name="height">Height of the viewport.</param>
		/// <param name="minDepth">Minimum depth of the viewport. Ranges between 0 and 1.</param>
		/// <param name="maxDepth">Maximum depth of the viewport. Ranges between 0 and 1.</param>
		public D3D12_VIEWPORT(float topLeftX, float topLeftY, float width, float height, float minDepth = D3D12_MIN_DEPTH, float maxDepth = D3D12_MAX_DEPTH)
		{
			TopLeftX = topLeftX;
			TopLeftY = topLeftY;
			Width = width;
			Height = height;
			MinDepth = minDepth;
			MaxDepth = maxDepth;
		}

		/// <summary>Initializes a new instance of the <see cref="D3D12_VIEWPORT"/> struct.</summary>
		/// <param name="pResource">The resource.</param>
		/// <param name="mipSlice">The mip slice.</param>
		/// <param name="topLeftX">X position of the left hand side of the viewport.</param>
		/// <param name="topLeftY">Y position of the top of the viewport.</param>
		/// <param name="minDepth">Minimum depth of the viewport. Ranges between 0 and 1.</param>
		/// <param name="maxDepth">Maximum depth of the viewport. Ranges between 0 and 1.</param>
		public D3D12_VIEWPORT(ID3D12Resource pResource, int mipSlice = 0, float topLeftX = 0.0f, float topLeftY = 0.0f, float minDepth = D3D12_MIN_DEPTH, float maxDepth = D3D12_MAX_DEPTH)
		{
			pResource.GetDesc(out var Desc);
			ulong SubresourceWidth = Desc.Width >> mipSlice;
			ulong SubresourceHeight = Desc.Height >> mipSlice;
			switch (Desc.Dimension)
			{
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER:
					TopLeftX = topLeftX;
					TopLeftY = 0.0f;
					Width = Desc.Width - topLeftX;
					Height = 1.0f;
					break;

				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE1D:
					TopLeftX = topLeftX;
					TopLeftY = 0.0f;
					Width = (SubresourceWidth != 0 ? SubresourceWidth : 1.0f) - topLeftX;
					Height = 1.0f;
					break;

				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE2D:
				case D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_TEXTURE3D:
					TopLeftX = topLeftX;
					TopLeftY = topLeftY;
					Width = (SubresourceWidth != 0 ? SubresourceWidth : 1.0f) - topLeftX;
					Height = (SubresourceHeight != 0 ? SubresourceHeight : 1.0f) - topLeftY;
					break;

				default: break;
			}
			MinDepth = minDepth;
			MaxDepth = maxDepth;
		}
	}

	/// <summary>Specifies the immediate value and destination address written using <c>ID3D12GraphicsCommandList2::WriteBufferImmediate</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_writebufferimmediate_parameter typedef struct
	// D3D12_WRITEBUFFERIMMEDIATE_PARAMETER { D3D12_GPU_VIRTUAL_ADDRESS Dest; UINT32 Value; } D3D12_WRITEBUFFERIMMEDIATE_PARAMETER;
	[PInvokeData("d3d12.h", MSDNShortId = "NS:d3d12.D3D12_WRITEBUFFERIMMEDIATE_PARAMETER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D3D12_WRITEBUFFERIMMEDIATE_PARAMETER
	{
		/// <summary>The GPU virtual address at which to write the value. The address must be aligned to a 32-bit (4-byte) boundary.</summary>
		public D3D12_GPU_VIRTUAL_ADDRESS Dest;

		/// <summary>The 32-bit value to write.</summary>
		public uint Value;
	}
}