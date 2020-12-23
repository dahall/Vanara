using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.WTSApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class WTSApi32Tests
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
		public void WTSEnumerateServersTest()
		{
			Assert.That(WTSEnumerateServers(null, out var servers), ResultIs.Successful);
			servers.WriteValues();
		}
	}
}