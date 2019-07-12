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
	public class NamedPipeApiTests
	{
		[Test]
		public void CreatePipeTest()
		{
			var saAttr = new SECURITY_ATTRIBUTES { bInheritHandle = true };
			Assert.That(CreatePipe(out var g_hChildStd_OUT_Rd, out var g_hChildStd_OUT_Wr, saAttr, 0), ResultIs.Successful);
		}

		[Test]
		public void CreateNamedPipeTest()
		{
			//Assert.That(CreateNamedPipe(), Is.Zero);
		}
	}
}