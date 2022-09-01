using NUnit.Framework;
using System;
using System.Security.Principal;

namespace Vanara.PInvoke.Tests;

partial class BackgroundCopyTests
{
	[Test]
	public void PeerTest()
	{
		uint sz;
		Assert.That(sz = BackgroundCopyManager.PeerCacheAdministration.MaximumCacheSize, Is.GreaterThanOrEqualTo(0U));
		Assert.That(BackgroundCopyManager.PeerCacheAdministration.MaximumCacheSize += 256U, Is.EqualTo(sz + 256U));

		TimeSpan age;
		Assert.That(age = BackgroundCopyManager.PeerCacheAdministration.MaximumContentAge, Is.GreaterThanOrEqualTo(TimeSpan.Zero));
		Assert.That(BackgroundCopyManager.PeerCacheAdministration.MaximumContentAge += TimeSpan.FromSeconds(600), Is.EqualTo(age + TimeSpan.FromSeconds(600)));

		PeerCaching pc = BackgroundCopyManager.PeerCacheAdministration.ConfigurationFlags;
		Assert.That(pc == 0 || Enum.IsDefined(typeof(PeerCaching), pc));
		Assert.That(BackgroundCopyManager.PeerCacheAdministration.ConfigurationFlags = PeerCaching.EnableClient, Is.EqualTo(PeerCaching.EnableClient));

		Assert.That(BackgroundCopyManager.PeerCacheAdministration.Peers, Is.Unique);
		Assert.That(BackgroundCopyManager.PeerCacheAdministration.Records, Is.Unique);
	}
}
