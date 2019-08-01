using NUnit.Framework;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class ProcessEnvTests
	{
		[Test]
		public void ExpandEnvironmentStringsTest()
		{
			var sb = new StringBuilder(MAX_PATH);
			Assert.That(ExpandEnvironmentStrings("%USERDOMAIN%", sb, MAX_PATH), Is.Not.Zero);
			Assert.That(sb.ToString(), Is.EqualTo("AMERICAS"));
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
			var es = GetEnvironmentStrings();
			Assert.That(es, Is.Not.Empty);
			TestContext.WriteLine(string.Join("\r\n", es));
			Assert.That(SetEnvironmentStrings(es), ResultIs.Successful);
		}

		[Test]
		public void GetSetCurrentDirectoryTest()
		{
			var sb = new StringBuilder(MAX_PATH);
			Assert.That(GetCurrentDirectory((uint)sb.Capacity, sb), Is.GreaterThan(0));
			Assert.That(sb.ToString().StartsWith("C:"));
			TestContext.WriteLine(sb);

			Assert.That(SetCurrentDirectory(@"C:\Temp"), Is.True);

			var sb2 = new StringBuilder(MAX_PATH);
			Assert.That(GetCurrentDirectory((uint)sb2.Capacity, sb2), Is.GreaterThan(0));
			Assert.That(sb2.ToString(), Is.EqualTo(@"C:\Temp"));

			Assert.That(SetCurrentDirectory(sb.ToString()));
		}

		[Test]
		public void GetSetEnvironmentVariableTest()
		{
			var str = System.IO.Path.GetRandomFileName();
			Assert.That(SetEnvironmentVariable(str, "Value"), Is.True);

			var sb = new StringBuilder(MAX_PATH);
			Assert.That(GetEnvironmentVariable(str, sb, (uint)sb.Capacity), Is.Not.Zero);
			Assert.That(sb.ToString(), Is.EqualTo("Value"));

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
			var sb = new StringBuilder(MAX_PATH);
			Assert.That(SearchPath(null, "notepad.exe", null, (uint)sb.Capacity, sb, out var ptr), Is.Not.Zero);
			Assert.That(sb.ToString().StartsWith("C:"));
			Assert.That(Marshal.PtrToStringAuto(ptr), Is.EqualTo("notepad.exe"));
		}
	}
}