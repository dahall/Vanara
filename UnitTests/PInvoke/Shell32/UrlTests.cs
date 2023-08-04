using NUnit.Framework;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Url;

namespace Vanara.PInvoke.Tests;

[TestFixture, Apartment(System.Threading.ApartmentState.STA)]
public class UrlTests
{
	const string url = "http://docs.microsoft.com/";
	private static readonly Guid FMTID_InternetSite = new Guid("000214a1-0000-0000-c000-000000000046");

	[Test]
	public void IUniformResourceLocatorTest()
	{
		using var tmp = new TempFile();

		// WRite it out
		var iUrl = new IUniformResourceLocator();
		Assert.That(() => iUrl.SetUrl(url), Throws.Nothing);
		IPersistFile? ipf = null;
		Assert.That(ipf = iUrl as IPersistFile, Is.Not.Null);
		Assert.That(() => ipf?.Save(tmp.FullName, false), Throws.Nothing);

		// Validate file
		var fi = new System.IO.FileInfo(tmp.FullName);
		Assert.That(fi.Length, Is.GreaterThan(10));

		// Read it back
		var iUrl2 = new IUniformResourceLocator();
		IPersistFile? ipf2 = null;
		Assert.That(ipf2 = iUrl2 as IPersistFile, Is.Not.Null);
		Assert.That(() => ipf2?.Load(tmp.FullName, 0), Throws.Nothing);
		var url2 = string.Empty;
		Assert.That(() => iUrl2.GetUrl(out url2), Throws.Nothing);
		Assert.That(url2, Is.EqualTo(url));

		// Open it
		Assert.That(() => iUrl2.InvokeCommand(new URLINVOKECOMMANDINFO("open")), Throws.Nothing);
	}

	[Test]
	public void InetIsOfflineTest()
	{
		Assert.That(InetIsOffline(), Is.False);
	}

	[Test]
	public void TranslateURLTest()
	{
		Assert.That(TranslateURL(url, TRANSLATEURL_IN_FLAGS.TRANSLATEURL_FL_GUESS_PROTOCOL, out var newUrl), ResultIs.Successful);
		Assert.That(url, Is.EqualTo(newUrl));
	}
}