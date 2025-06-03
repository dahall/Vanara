using NUnit.Framework;
using static Vanara.PInvoke.D2d1;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

public class Direct2DTests
{
	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(D2d1)))
			TestContext.WriteLine(ss);
	}

	[Test]
	public void DXGITest()
	{
		using var pFactory = ComReleaserFactory.Create(D2D1CreateFactory<ID2D1Factory>());
		using var pRenderTarget = ComReleaserFactory.Create(pFactory.Item.CreateHwndRenderTarget(RenderTargetProperties(), HwndRenderTargetProperties(GetDesktopWindow(), new(1000, 1000))));
		Assert.That(() => pRenderTarget.Item.GetSize(out var x), Throws.Nothing);
		Assert.That(() => pRenderTarget.Item.GetPixelSize(out var x), Throws.Nothing);
	}
}