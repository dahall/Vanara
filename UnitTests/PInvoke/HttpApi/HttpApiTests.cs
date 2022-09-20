using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.HttpApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class HttpApiTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		using SafeHttpInitialize init = new(HTTPAPI_VERSION.HTTPAPI_VERSION_2, HTTP_INIT.HTTP_INITIALIZE_SERVER | HTTP_INIT.HTTP_INITIALIZE_CONFIG);
		Assert.That(HttpCreateServerSession(HTTPAPI_VERSION.HTTPAPI_VERSION_2, out var sessionID), ResultIs.Successful);
		Assert.That(HttpCreateUrlGroup(sessionID, out var grpId), ResultIs.Successful);
	}
}