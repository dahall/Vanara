using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_Mailslot
{
	[Test]
	public void MailslotTest()
	{
		using SafeMailslotHandle hMs = CreateMailslot("\\\\.\\mailslot\\sample_mailslot", 0, MAILSLOT_WAIT_FOREVER);
		Assert.That(hMs, ResultIs.ValidHandle);
		Assert.That(GetMailslotInfo(hMs, out uint mxSz, out uint nxSz, out uint msgCnt, out uint to), ResultIs.Successful);
		Assert.That(SetMailslotInfo(hMs, to), ResultIs.Successful);
	}
}