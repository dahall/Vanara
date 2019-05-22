using NUnit.Framework;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class DebugApiTests
	{
		[Test]
		public void TestMethod()
		{
			TestContext.WriteLine($"EXCEPTION_RECORD: {Marshal.SizeOf(typeof(EXCEPTION_RECORD))}");
			TestContext.WriteLine($"DEBUG_EVENT.EXCEPTION_DEBUG_INFO: {Marshal.SizeOf(typeof(DEBUG_EVENT.EXCEPTION_DEBUG_INFO))}");
			TestContext.WriteLine($"DEBUG_EVENT.EXCEPTION_INFO: {Marshal.SizeOf(typeof(DEBUG_EVENT.EXCEPTION_INFO))}");
			var pid = GetCurrentProcessId();
			DebugActiveProcess(pid);
			{
				Assert.That(WaitForDebugEvent(out var evt, 2000));
				DebugActiveProcessStop(pid);
			}
		}
	}
}