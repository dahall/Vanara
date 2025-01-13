using NUnit.Framework;
using static Vanara.PInvoke.D2d1;

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
	}
}