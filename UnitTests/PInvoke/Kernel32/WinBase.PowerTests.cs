using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_Power
{
	[Test]
	public void GetSetDevicePowerStateTest()
	{
		using TempFile tmp = new(FileAccess.GENERIC_READ, System.IO.FileShare.Read);
		Assert.That(GetDevicePowerState(tmp.hFile!.DangerousGetHandle(), out bool on), ResultIs.Successful);
		Assert.That(on);
	}

	[Test]
	public void GetSystemPowerStatusTest()
	{
		Assert.That(GetSystemPowerStatus(out SYSTEM_POWER_STATUS status), ResultIs.Successful);
		status.WriteValues();
	}

	[Test]
	public void IsSystemResumeAutomaticTest()
	{
		Assert.That(IsSystemResumeAutomatic(), Is.False);
	}

	[Test]
	public void RequestWakeupLatencyTest()
	{
		Assert.That(RequestWakeupLatency(LATENCY_TIME.LT_DONT_CARE), Is.False);
	}

	// [Test] This works but suspends the PC
	public void SetSystemPowerStateTest()
	{
		using (new ElevPriv("SeShutdownPrivilege"))
			Assert.That(SetSystemPowerState(true), ResultIs.Successful);
	}
}