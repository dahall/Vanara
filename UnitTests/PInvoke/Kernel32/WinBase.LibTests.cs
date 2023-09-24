using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

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
		LOADPARMS32 lp = new() { CmdShow = ShowWindowCommand.SW_NORMAL };
		Assert.That(LoadModule("notepad.exe", lp), Is.GreaterThan(31));
	}
}