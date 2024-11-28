using NUnit.Framework;
using static Vanara.PInvoke.D3D12;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke.Tests;

public class D3D12Tests
{
	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(D3D12)))
			TestContext.WriteLine(ss);
	}

	[Test]
	public void BasicTest()
	{
		ID3D12Device? device = null;
		Assert.That(() => device = D3D12CreateDevice(D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_12_1), Throws.Nothing);

		//Assert.That(() => device!.GetNodeCount(), Throws.Nothing);
		//Assert.That(() => device!.CreateCommandAllocator<ID3D12CommandAllocator>(D3D12_COMMAND_LIST_TYPE.D3D12_COMMAND_LIST_TYPE_DIRECT), Throws.Nothing);
		//Assert.That(device!.CheckFeatureSupport(D3D12_FEATURE.D3D12_FEATURE_FORMAT_SUPPORT, new D3D12_FEATURE_DATA_FORMAT_SUPPORT() { Format = DXGI_FORMAT.DXGI_FORMAT_R16G16B16A16_FLOAT }), ResultIs.Successful);

		D3D12_HEAP_PROPERTIES bufferHeapProps = new() { Type = D3D12_HEAP_TYPE.D3D12_HEAP_TYPE_DEFAULT };
		D3D12_RESOURCE_DESC bufferDesc = new()
		{
			Dimension = D3D12_RESOURCE_DIMENSION.D3D12_RESOURCE_DIMENSION_BUFFER,
			Width = 4096,
			Height = 1,
			DepthOrArraySize = 1,
			MipLevels = 1,
			Format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN,
			Layout = D3D12_TEXTURE_LAYOUT.D3D12_TEXTURE_LAYOUT_ROW_MAJOR,
			SampleDesc = new() { Count = 1 }
		};
		Assert.That(() => device!.CreateCommittedResource<ID3D12Resource>(bufferHeapProps, D3D12_HEAP_FLAGS.D3D12_HEAP_FLAG_NONE,
			bufferDesc, D3D12_RESOURCE_STATES.D3D12_RESOURCE_STATE_COMMON), Throws.Nothing);

		Assert.That(() => device!.SetStablePowerState(true), Throws.Nothing);
	}
}