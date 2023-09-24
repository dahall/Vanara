using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class DebugApiTests
{
	[Test]
	public void CheckRemoteDebuggerPresentTest()
	{
		Assert.That(CheckRemoteDebuggerPresent(GetCurrentProcess(), out bool present), ResultIs.Successful);
		Assert.That(present, Is.False);
	}

	[Test]
	public void IsDebuggerPresentTest()
	{
		Assert.That(IsDebuggerPresent(), Is.False);
	}

	[Test]
	public void OutputDebugStringTest()
	{
		OutputDebugString("Hello");
	}

	// TODO: Figure out how WaitForDebugEvent works
	// [Test]
	public void TestMethod()
	{
		System.Diagnostics.Process p = CSharpRunner.RunProcess(typeof(DebugProcess));
		uint pid = (uint)p.Id;
		Assert.That(DebugActiveProcess(pid), ResultIs.Successful);
		//Assert.That(ContinueDebugEvent(pid, ))
		Assert.That(WaitForDebugEvent(out DEBUG_EVENT evt, 2000));
		DebugActiveProcessStop(pid);
	}
}

public static class DebugProcess
{
	public static int Main()
	{
		Sleep(2000);
		DebugBreak();
		return 0;
	}
}