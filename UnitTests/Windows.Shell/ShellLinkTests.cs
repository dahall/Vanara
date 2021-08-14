using NUnit.Framework;
using System;
using System.IO;
using System.Windows.Forms;
using Vanara.PInvoke.Tests;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellLinkTests
	{
		[Test]
		public void UnsavedLinkTest()
		{
			using var lnk = new ShellLink(TestCaseSources.WordDoc, "/p", TestCaseSources.TempDir, "Test description");
			lnk.Properties.ReadOnly = false;
			lnk.Title = "Test title";
			lnk.HotKey = Keys.Control | Keys.T;
			lnk.RunAsAdministrator = false;
			lnk.IconLocation = new IconLocation(TestCaseSources.ResourceFile, -107);
			lnk.ShowState = FormWindowState.Minimized;

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
	}
}