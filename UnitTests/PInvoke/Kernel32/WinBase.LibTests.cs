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
	public partial class WinBaseTests_Lib
	{
		[Test]
		public void GetSetDllDirectoryTest()
		{
			string dlldir = "";
			Assert.That(() => dlldir = GetDllDirectory(), Throws.Nothing);
			Assert.That(dlldir, Is.Not.Empty);
			TestContext.Write(dlldir);
			Assert.That(SetDllDirectory(dlldir), ResultIs.Successful);
		}

		[Test]
		public void LoadModuleTest()
		{
			var lp = new LOADPARMS32() { CmdShow = ShowWindowCommand.SW_NORMAL };
			Assert.That(LoadModule("notepad.exe", lp), Is.GreaterThan(31));
		}
	}
}