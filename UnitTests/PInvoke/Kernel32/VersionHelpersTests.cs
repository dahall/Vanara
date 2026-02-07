using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VersionHelpersTests
{
	[Test]
	public void IsActiveSessionCountLimitedTest() => Assert.That(IsActiveSessionCountLimited(), Is.True);

	[Test]
	public void IsWindowsTests()
	{
		Assert.That(IsWindows10OrGreater(), Is.True);
		Assert.That(IsWindows7OrGreater(), Is.True);
		Assert.That(IsWindows7SP1OrGreater(), Is.True);
		Assert.That(IsWindows8OrGreater(), Is.True);
		Assert.That(IsWindows8Point1OrGreater(), Is.True);
		Assert.That(IsWindowsServer(), Is.False);
		Assert.That(IsWindowsThresholdOrGreater(), Is.True);
		Assert.That(IsWindowsVistaOrGreater(), Is.True);
		Assert.That(IsWindowsVistaSP1OrGreater(), Is.True);
		Assert.That(IsWindowsVistaSP2OrGreater(), Is.True);
		Assert.That(IsWindowsXPOrGreater(), Is.True);
		Assert.That(IsWindowsXPSP1OrGreater(), Is.True);
		Assert.That(IsWindowsXPSP2OrGreater(), Is.True);
		Assert.That(IsWindowsXPSP3OrGreater(), Is.True);
	}
}