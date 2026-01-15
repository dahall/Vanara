using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.UrlMon;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class UrlMonTests
{
	[Test]
	public void CreateUriTest()
	{
		Assert.That(CreateUri("https://microsoft.com", 0, default, out var iUri), ResultIs.Successful);
		using var pUri = ComReleaserFactory.Create(iUri);
		var sb = new StringBuilder();
		foreach (var mi in typeof(IUri).GetMethods().Where(t => t.Name.StartsWith("Get") && t.GetParameters().Length == 0))
		{
			try
			{
				var obj = mi.Invoke(iUri, null);
				if (obj is not null)
					sb.Append($"{mi.Name.Substring(3)}={obj}; ");
			}
			catch { }
		}
		TestContext.WriteLine(sb.ToString());
		Assert.That(iUri.HasProperty(Uri_PROPERTY.Uri_PROPERTY_DOMAIN));
		string? str = null;
		Assert.That(() => iUri.GetPropertyBSTR(Uri_PROPERTY.Uri_PROPERTY_DOMAIN, out str), Throws.Nothing);
		Assert.That(str, Is.EqualTo("microsoft.com"));
		uint i = 0;
		Assert.That(() => iUri.GetPropertyDWORD(Uri_PROPERTY.Uri_PROPERTY_PORT, out i), Throws.Nothing);
		Assert.That(i, Is.EqualTo(443U));
	}

	[Test]
	public void CreateIUriBuilderTest()
	{
		Assert.That(CreateUri("https://microsoft.com", 0, default, out var iUri), ResultIs.Successful);
		using var pUri = ComReleaserFactory.Create(iUri);

		Assert.That(CreateIUriBuilder(ppIUriBuilder: out var iBld), ResultIs.Successful);
		using var pBld = ComReleaserFactory.Create(iBld);
		iBld.SetHost("microsoft.com");
		iBld.SetSchemeName("https");
		using var pUri2 = ComReleaserFactory.Create(iBld.CreateUri(Uri_CREATE.Uri_CREATE_ALLOW_RELATIVE));
		Assert.That(iUri.IsEqual(pUri2.Item));

		PWSTR sch = default;
		Assert.That(() => iBld.GetSchemeName(out _, out sch), Throws.Nothing);
		Assert.That((string?)sch, Is.EqualTo("https"));
	}
}