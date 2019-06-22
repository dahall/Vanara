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
			Tester.Test(() => CreatePipe(out var g_hChildStd_OUT_Rd, out var g_hChildStd_OUT_Wr, saAttr, 0));
		}

		[Test]
		public void CreateNamedPipeTest()
		{
			Assert.That(CreateNamedPipe(), Is.Zero);
		}
	}

	public static class Tester
	{
		public static void Test<TRet>(Func<TRet> f, TRet? expected = default) where TRet : struct
		{
			TRet ret = f();
			switch (ret)
			{
				case bool b:
					if (!b)
						TestContext.WriteLine(Win32Error.GetLastError());
					Assert.That(b, Is.EqualTo(true));
					break;
				case Win32Error we:
					if (we.Failed)
						TestContext.WriteLine(we);
					Assert.That(we, Is.EqualTo((Win32Error)0));
					break;
				case HRESULT hr:
					if (hr.Failed)
						TestContext.WriteLine(hr);
					Assert.That(hr, Is.EqualTo((HRESULT)0));
					break;
				default:
					if (expected.HasValue)
						Assert.That(ret, Is.EqualTo(expected.Value));
					else
						Assert.Fail();
					break;
			}
		}
	}
}