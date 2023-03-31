using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Imm32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class Imm32Tests
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
	public void Test()
	{
		Assert.That(ImmEnumInputContext(0).ToList(), Has.Count.GreaterThanOrEqualTo(0));
	}

	[Test]
	public void ImmEscapeTest()
	{
		int max = GetKeyboardLayoutList(0, null);
		HKL[] layouts = new HKL[max];
		Assert.That(GetKeyboardLayoutList(max, layouts), Is.EqualTo(max));

		SafeCoTaskMemString str = new(256);
		StringBuilder sb = new(256);
		foreach (var hkl in layouts)
		{
			str.Zero();
			sb.Clear();
			var hLen = ImmEscape(hkl, default, IME_ESC.IME_ESC_GETHELPFILENAME, str).ToInt32();
			var dLen = ImmGetDescription(hkl, sb, (uint)sb.Capacity);

			TestContext.WriteLine($"hlp:{(hLen > 0 ? str.ToString() : "none")} desc:{(dLen > 0 ? sb.ToString() : "none")}");

			//ImmConfigureIME(hkl, GetActiveWindow(), IME_CONFIG.IME_CONFIG_GENERAL);
		}
	}

	[Test]
	public void ImmGetConversionListTest()
	{
		var hIMC = ImmGetContext(GetDesktopWindow());
		Assert.That(hIMC, ResultIs.ValidHandle);
		var hKL = GetKeyboardLayout(0);
		Assert.That(hKL, ResultIs.ValidHandle);
		var convList = ImmGetConversionList(hKL, hIMC, "", GCL.GCL_REVERSECONVERSION);
	}
}