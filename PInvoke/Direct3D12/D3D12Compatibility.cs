#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.PInvoke;

public static partial class D3D12
{
	/// <summary>Undocumented</summary>
	[PInvokeData("d3d12compatibility.h")]
	[ComImport, Guid("8f1c0e3c-fae3-4a82-b098-bfe1708207ff"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID3D12CompatibilityDevice
	{
		[PreserveSig]
		HRESULT CreateSharedResource(in D3D12_HEAP_PROPERTIES pHeapProperties, D3D12_HEAP_FLAGS HeapFlags,
			in D3D12_RESOURCE_DESC pDesc, D3D12_RESOURCE_STATES InitialResourceState, [In, Optional] StructPointer<D3D12_CLEAR_VALUE> pOptimizedClearValue,
			[In, Optional] StructPointer<D3D11_RESOURCE_FLAGS> pFlags11, D3D12_COMPATIBILITY_SHARED_FLAGS CompatibilityFlags,
			[In, Optional] ID3D12LifetimeTracker? pLifetimeTracker, [In, Optional] ID3D12SwapChainAssistant? pOwningSwapchain, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 9)] out object? ppResource);

		[PreserveSig]
		HRESULT CreateSharedHeap(in D3D12_HEAP_DESC pHeapDesc, D3D12_COMPATIBILITY_SHARED_FLAGS CompatibilityFlags, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppHeap);

		[PreserveSig]
		HRESULT ReflectSharedProperties([In] ID3D12Object pHeapOrResource, D3D12_REFLECT_SHARED_PROPERTY ReflectType, [Out] IntPtr pData, uint DataSize);
	}

	[PInvokeData("d3d12compatibility.h")]
	[Flags]
	public enum D3D12_COMPATIBILITY_SHARED_FLAGS
	{
		D3D12_COMPATIBILITY_SHARED_FLAG_NONE = 0,
		D3D12_COMPATIBILITY_SHARED_FLAG_NON_NT_HANDLE = 0x1,
		D3D12_COMPATIBILITY_SHARED_FLAG_KEYED_MUTEX = 0x2,
		D3D12_COMPATIBILITY_SHARED_FLAG_9_ON_12 = 0x4,

	}

	[PInvokeData("d3d12compatibility.h")]
	public enum D3D12_REFLECT_SHARED_PROPERTY
	{
		D3D12_REFLECT_SHARED_PROPERTY_D3D11_RESOURCE_FLAGS,       // D3D11_RESOURCE_FLAGS
		D3D12_REFELCT_SHARED_PROPERTY_COMPATIBILITY_SHARED_FLAGS, // D3D12_COMPATIBILITY_SHARED_FLAGS
		D3D12_REFLECT_SHARED_PROPERTY_NON_NT_SHARED_HANDLE,       // HANDLE
	}
}