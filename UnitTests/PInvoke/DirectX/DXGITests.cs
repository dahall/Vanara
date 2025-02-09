using NUnit.Framework;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke.Tests;

public class DXGITests
{
	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(DXGI)))
			TestContext.WriteLine(ss);
	}

	[Test]
	public void EnumTest()
	{
		var factory = CreateDXGIFactory2<IDXGIFactory6>();
		IDXGIAdapter1? first = null;
		foreach (var adp in factory.EnumAdapterByGpuPreference<IDXGIAdapter4>(DXGI_GPU_PREFERENCE.DXGI_GPU_PREFERENCE_HIGH_PERFORMANCE))
		{
			Assert.That(adp, Is.Not.Null);
			first ??= adp;
			var desc = adp.GetDesc3();
			desc.WriteValues();
		}

		Assert.That(first, Is.Not.Null);
		Assert.That(D3D12.D3D12CreateDevice(first, D3D_FEATURE_LEVEL.D3D_FEATURE_LEVEL_11_0, typeof(D3D12.ID3D12Device).GUID).Succeeded);
	}
}