using NUnit.Framework;
using static Vanara.PInvoke.D2d1;

namespace Vanara.PInvoke.Tests;

public class Direct2DTests
{
	[Test]
	public void DXGITest()
	{
		using var pFactory = ComReleaserFactory.Create(D2D1CreateFactory<ID2D1Factory>());

		using var form = new System.Windows.Forms.Form { Text = "Sample App" };
	}
}