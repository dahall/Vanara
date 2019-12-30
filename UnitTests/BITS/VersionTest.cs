using NUnit.Framework;
using System;

namespace Vanara.IO.Tests
{
	partial class BackgroundCopyTests
	{
		[Test]
		public void VersionTest() => Assert.That(BackgroundCopyManager.Version, Is.GreaterThanOrEqualTo(new Version(10, 0)));
	}
}
