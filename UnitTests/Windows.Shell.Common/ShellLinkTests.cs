using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.IO;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellLinkTests
{
	[Test]
	public void UnsavedLinkTest()
	{
		using ShellLink lnk = new(TestCaseSources.WordDoc, "/p", TestCaseSources.TempDir, "Test description");
		lnk.Properties.ReadOnly = false;
		lnk.Title = "Test title";
		lnk.HotKey = MakeHotKey(VK.VK_T, HOTKEYF.HOTKEYF_CONTROL);
		lnk.RunAsAdministrator = false;
		lnk.IconLocation = new IconLocation(TestCaseSources.ResourceFile, -107);
		lnk.ShowState = PInvoke.ShowWindowCommand.SW_SHOWMINIMIZED;
		lnk.Properties["System.Author"] = new string[] { "TestAuthor" };
		lnk.Properties["System.Title"] = null;
		lnk.Properties.Commit();

		using TempFile fn = new("lnk", null);
		lnk.WriteValues(false);
		lnk.SaveAs(fn.FullName);
		Assert.That(File.Exists(fn.FullName));
		lnk.ViewInExplorer();
	}

	[Test]
	public void TestPaths()
	{
		const string lnkPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Word.lnk";
		const string targetPath = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
		using ShellLink lnk = new(lnkPath);
		StringAssert.AreEqualIgnoringCase(targetPath, lnk.TargetPath);
	}

	private static ushort MakeHotKey(VK key, HOTKEYF modifier) => PInvoke.Macros.MAKEWORD((byte)key, (byte)modifier);
}