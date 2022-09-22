using NUnit.Framework;
using NUnit.Framework.Internal;
using Vanara.InteropServices;
using static Vanara.PInvoke.HttpApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class HttpApiTests
{
	SafeHttpInitialize init;

	[OneTimeSetUp]
	public void _Setup()
	{
		init = new(HTTPAPI_VERSION.HTTPAPI_VERSION_2, HTTP_INIT.HTTP_INITIALIZE_SERVER | HTTP_INIT.HTTP_INITIALIZE_CONFIG);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		init.Dispose();
	}

	[Test]
	public void CreateTest()
	{
		Assert.That(HttpCreateServerSession(HTTPAPI_VERSION.HTTPAPI_VERSION_2, out var sessionID), ResultIs.Successful);
		Assert.That(HttpCreateUrlGroup(sessionID, out var grpId), ResultIs.Successful);
	}

	[Test]
	public void StructTest() => TestContext.Write(string.Join("\n", TestHelper.GetNestedStructSizes(typeof(HttpApi))));

	[Test]
	public void HTTP_DATA_CHUNK_Test()
	{
		Assert.That(() => new HTTP_DATA_CHUNK(new SafeCoTaskMemHandle("testing")), Throws.Nothing);
	}
}