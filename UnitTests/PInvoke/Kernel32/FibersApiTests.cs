using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class FibersApiTests
	{
		[Test]
		public void FiberTest()
		{
			TestContext.WriteLine($"IsFiber:{IsThreadAFiber()}");
			var id = FlsAlloc(Callback);
			var mem = new SafeHGlobalHandle(64);
			mem.Fill(1);
			Assert.That(FlsSetValue(id, (IntPtr)mem), Is.True);
			Assert.That(FlsGetValue(id), Is.EqualTo((IntPtr)mem));
			Assert.That(FlsFree(id), Is.True);
			mem.Dispose();
		}

		private void Callback(IntPtr lpFlsData) { }
	}
}