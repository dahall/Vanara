using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShelViewTests
	{
		//[Test]
		public void CreateTest()
		{
			var form = new System.Windows.Forms.Form() { Size = new System.Drawing.Size(200, 200) };
			var shvw = new ShellBrowser() { Dock = System.Windows.Forms.DockStyle.Fill };
			shvw.BrowseObject(new ShellFolder(TestCaseSources.TempDir).PIDL.DangerousGetHandle(), SBSP.SBSP_ABSOLUTE);
			form.Controls.Add(shvw);
			form.ShowDialog();
		}
	}
}