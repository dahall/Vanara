using NUnit.Framework;
using System;
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
		using var lnk = new ShellLink(TestCaseSources.WordDoc, "/p", TestCaseSources.TempDir, "Test description");
		lnk.Properties.ReadOnly = false;
		lnk.Title = "Test title";
		lnk.HotKey = MakeHotKey(VK.VK_T, HOTKEYF.HOTKEYF_CONTROL);
		lnk.RunAsAdministrator = false;
		lnk.IconLocation = new IconLocation(TestCaseSources.ResourceFile, -107);
		lnk.ShowState = WindowStateToSW(System.Windows.Forms.FormWindowState.Minimized);

		using var fn = new TempFile("lnk", null);
		lnk.SaveAs(fn.FullName);
		Assert.IsTrue(File.Exists(fn.FullName));
		lnk.ViewInExplorer();
	}

	[Test]
	public void TestPaths()
	{
		const string lnkPath = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Word.lnk";
		const string targetPath = @"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE";
		using var lnk = new ShellLink(lnkPath);
		StringAssert.AreEqualIgnoringCase(targetPath, lnk.TargetPath);
	}

	private static ushort MakeHotKey(VK key, HOTKEYF modifier) => Vanara.PInvoke.Macros.MAKEWORD((byte)key, (byte)modifier);
	private static PInvoke.ShowWindowCommand WindowStateToSW(System.Windows.Forms.FormWindowState state) => (PInvoke.ShowWindowCommand)state;
	private static PInvoke.HWND ToHWND(System.Windows.Forms.IWin32Window win) => win?.Handle ?? PInvoke.HWND.NULL;
}