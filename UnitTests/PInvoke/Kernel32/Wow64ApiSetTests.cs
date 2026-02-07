using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class Wow64ApiSetTests
{
	[Test]
	public void GetSystemWow64Directory2Test()
	{
		Assert.That(GetSystemWow64Directory2(out var sb, IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_I386), ResultIs.Not.Value(0));
		TestContext.Write(sb);
	}

	[Test]
	public void GetSystemWow64DirectoryTest()
	{
		Assert.That(GetSystemWow64Directory(out var sb), ResultIs.Not.Value(0));
		TestContext.Write(sb);
	}

	[Test]
	public void IsWow64GuestMachineSupportedTest()
	{
		foreach (IMAGE_FILE_MACHINE m in Enum.GetValues(typeof(IMAGE_FILE_MACHINE)))
		{
			Assert.That(IsWow64GuestMachineSupported(m, out bool ok), ResultIs.Successful);
			TestContext.WriteLine($"{m} = {ok}");
		}
	}

	[Test]
	public void IsWow64Process2Test()
	{
		Assert.That(IsWow64Process2(GetCurrentProcess(), out IMAGE_FILE_MACHINE pm, out IMAGE_FILE_MACHINE nm), ResultIs.Successful);
		(pm, nm).WriteValues();
	}

	[Test]
	public void IsWow64ProcessTest()
	{
		Assert.That(IsWow64Process(GetCurrentProcess(), out bool ok), ResultIs.Successful);
		Assert.That(ok, Is.False);
	}

	[Test]
	public void Wow64DisableRevertWow64FsRedirectionTest()
	{
		Assert.That(Wow64DisableWow64FsRedirection(out IntPtr ptr), ResultIs.FailureCode(Win32Error.ERROR_INVALID_FUNCTION));
		Assert.That(Wow64RevertWow64FsRedirection(ptr), ResultIs.FailureCode(Win32Error.ERROR_INVALID_FUNCTION));
	}

	[Test]
	public void Wow64SetThreadDefaultGuestMachineTest() => Assert.That(() => Wow64SetThreadDefaultGuestMachine(IMAGE_FILE_MACHINE.IMAGE_FILE_MACHINE_AMD64), Throws.Nothing);
}