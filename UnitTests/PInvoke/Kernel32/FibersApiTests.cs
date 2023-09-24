using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class FibersApiTests
{
	[Test]
	public void FiberTest()
	{
		TestContext.WriteLine($"IsFiber:{IsThreadAFiber()}");
		uint id = FlsAlloc(Callback);
		SafeHGlobalHandle mem = new(64);
		mem.Fill(1);
		Assert.That(FlsSetValue(id, (IntPtr)mem), Is.True);
		Assert.That(FlsGetValue(id), Is.EqualTo((IntPtr)mem));
		Assert.That(FlsFree(id), Is.True);
		mem.Dispose();
	}

	private void Callback(IntPtr lpFlsData) { }
}