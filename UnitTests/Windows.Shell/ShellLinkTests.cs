using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

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

			var fn = System.IO.Path.GetTempFileName() + ".lnk";
			lnk.SaveAs(fn);
			Assert.That(System.IO.File.Exists(fn), Is.True);
			lnk.ViewInExplorer();
			System.IO.File.Delete(fn);
		}
	}
}