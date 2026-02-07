using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ProcessEnvTests
{
	[Test]
	public void ExpandEnvironmentStringsTest()
	{
		Assert.That(ExpandEnvironmentStrings("%USERDOMAIN%", out var sb), Is.Not.Zero);
		Assert.That(sb, Is.EqualTo(Environment.UserDomainName));
	}

	[Test]
	public void GetCommandLineTest()
	{
		Assert.That(GetCommandLine(), Is.Not.Null);
		TestContext.WriteLine(GetCommandLine());
	}

	[Test]
	public void GetSetEnvironmentStringsTest()
	{
		string[] es = GetEnvironmentStrings();
		Assert.That(es, Is.Not.Empty);
		TestContext.WriteLine(string.Join("\r\n", es));
		Assert.That(SetEnvironmentStrings(es), ResultIs.Successful);
	}

	[Test]
	public void GetSetCurrentDirectoryTest()
	{
		Assert.That(GetCurrentDirectory(out var sb), Is.GreaterThan(0));
		Assert.That(sb!.StartsWith("C:"));
		TestContext.WriteLine(sb);

		Assert.That(SetCurrentDirectory(TestCaseSources.TempDir), Is.True);

		Assert.That(GetCurrentDirectory(out var sb2), Is.GreaterThan(0));
		Assert.That(sb2, Is.EqualTo(TestCaseSources.TempDir));

		Assert.That(SetCurrentDirectory(sb));
	}

	[Test]
	public void GetSetEnvironmentVariableTest()
	{
		string str = System.IO.Path.GetRandomFileName();
		Assert.That(SetEnvironmentVariable(str, "Value"), Is.True);

		Assert.That(GetEnvironmentVariable(str, out var sb), Is.Not.Zero);
		Assert.That(sb, Is.EqualTo("Value"));

		Assert.That(SetEnvironmentVariable(str), Is.True);
	}

	[Test]
	public void GetStdHandleTest()
	{
		Assert.That(GetStdHandle(StdHandleType.STD_ERROR_HANDLE).IsInvalid, Is.False);
		Assert.That(GetStdHandle(StdHandleType.STD_INPUT_HANDLE).IsInvalid, Is.False);
		Assert.That(GetStdHandle(StdHandleType.STD_OUTPUT_HANDLE).IsInvalid, Is.False);
	}

	[Test]
	public void NeedCurrentDirectoryForExePathTest()
	{
		Assert.That(NeedCurrentDirectoryForExePath("cmd.exe"), Is.True);
		Assert.That(NeedCurrentDirectoryForExePath(@"testApp.exe"), Is.True);
	}

	[Test]
	public void SearchPathTest()
	{
		string? sb;
		Assert.That(sb = SearchPath(null, "notepad.exe", null, out var idx), Is.Not.Null);
		Assert.That(sb!.StartsWith("C:"));
		Assert.That(sb.Substring(idx), Is.EqualTo("notepad.exe"));
	}
}