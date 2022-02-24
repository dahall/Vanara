using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
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

		[Test]
		public void WTSEnumerateSessionsExTest()
		{
			Assert.That(WTSEnumerateSessionsEx(HWTSSERVER.WTS_CURRENT_SERVER_HANDLE, out var sessionList), ResultIs.Successful);
			foreach (var session in sessionList)
			{
				Assert.That(WTSQuerySessionInformation(HWTSSERVER.WTS_CURRENT_SERVER_HANDLE, session.SessionId, WTS_INFO_CLASS.WTSSessionInfo, out var pSessionInfo, out var size), ResultIs.Successful);
				Assert.That(Marshal.SizeOf<WTSINFO>(), Is.EqualTo((int)size));
				var si = pSessionInfo.ToStructure<WTSINFO>(size);
				TestContext.WriteLine($"{si.WinStationName} : {si.CurrentTime.ToDateTime()}");
			}
		}
	}
}