using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.P2P;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class P2PTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
		//PeerCollabStartup().ThrowIfFailed();
		//PeerPnrpStartup().ThrowIfFailed();
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		//PeerPnrpShutdown();
		//PeerCollabShutdown();
	}

	[Test]
	public void PeerCollabEnumApplicationsTest()
	{
		SafePeerList<PEER_APPLICATION>? e = null;
		Assert.DoesNotThrow(() => e = PeerCollabEnumApplications());
		Assert.That(e, Is.Not.Null.And.Not.Empty);
		e?.WriteValues();
	}

	[Test]
	public void EndpointNameTest()
	{
		Assert.That(PeerCollabGetEndpointName(out var name), ResultIs.Successful);
		const string bogusName = "aksjdhflkajsdfkjahsdfkjhsdf";
		Assert.That(PeerCollabSetEndpointName(bogusName), ResultIs.Successful);
		Assert.That(PeerCollabSetEndpointName(name), ResultIs.Successful);
	}
}