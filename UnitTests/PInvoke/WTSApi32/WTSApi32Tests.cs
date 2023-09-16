using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.WTSApi32;

namespace Vanara.PInvoke.Tests;

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
		servers!.WriteValues();
	}

	[Test]
	public void WTSEnumerateSessionsExTest()
	{
		Assert.That(WTSEnumerateSessionsEx(HWTSSERVER.WTS_CURRENT_SERVER_HANDLE, out var sessionList),
			ResultIs.Successful);

		foreach (var session in sessionList!)
		{
			if (WTSQuerySessionInformation(
				    HWTSSERVER.WTS_CURRENT_SERVER_HANDLE,
				    session.SessionId,
				    WTS_INFO_CLASS.WTSSessionInfo,
				    out var pSessionInfo,
				    out var bytesReturned))
			{
				using (pSessionInfo)
				{
					var wtsInfo = pSessionInfo.ToStructure<WTSINFO>(bytesReturned);
					Assert.That(() => _ = wtsInfo.SessionId, Throws.Nothing);
					Assert.That(() => _ = wtsInfo.UserName, Throws.Nothing);
					Assert.That(() => _ = wtsInfo.CurrentTime, Throws.Nothing);
					Assert.That(() => _ = wtsInfo.ConnectTime, Throws.Nothing);
					Assert.That(() => _ = wtsInfo.LastInputTime, Throws.Nothing);
				}
			}
		}
	}
	
	[Test]
	public void WTSEnumerateSessionsExSessionInfoExTest()
	{
		Assert.That(WTSEnumerateSessionsEx(HWTSSERVER.WTS_CURRENT_SERVER_HANDLE, out var sessionList),
			ResultIs.Successful);

		foreach (var session in sessionList!)
		{
			if (WTSQuerySessionInformation(
				    HWTSSERVER.WTS_CURRENT_SERVER_HANDLE,
				    session.SessionId,
				    WTS_INFO_CLASS.WTSSessionInfoEx,
				    out var pSessionInfo,
				    out var bytesReturned))
			{
				using (pSessionInfo)
				{
					var wtsInfoEx = pSessionInfo.ToStructure<WTSINFOEX>(bytesReturned);
					if (wtsInfoEx.Level == 1)
					{
						Assert.That(() => _ = wtsInfoEx.Data.WTSInfoExLevel1.SessionId, Throws.Nothing);
						Assert.That(() => _ = wtsInfoEx.Data.WTSInfoExLevel1.UserName, Throws.Nothing);
						Assert.That(() => _ = wtsInfoEx.Data.WTSInfoExLevel1.CurrentTime, Throws.Nothing);
						Assert.That(() => _ = wtsInfoEx.Data.WTSInfoExLevel1.ConnectTime, Throws.Nothing);
						Assert.That(() => _ = wtsInfoEx.Data.WTSInfoExLevel1.LastInputTime, Throws.Nothing);
					}
				}
			}
		}
	}
}