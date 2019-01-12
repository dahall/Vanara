using NUnit.Framework;
using System.Windows.Forms;

namespace Vanara.Windows.Forms.Tests
{
	[TestFixture()]
	public class ExplorerBrowserTests
	{
		[OneTimeSetUp]
		public void SetupFixture() => Application.EnableVisualStyles();

		[Test()]
		public void ExplorerBrowserTest()
		{
			var frm = MakeTestForm(out var eb);
			eb.ContentFlags = ExplorerBrowserContentSectionOptions.NoSubfolders | ExplorerBrowserContentSectionOptions.NoWebView | ExplorerBrowserContentSectionOptions.HideFileNames
				| ExplorerBrowserContentSectionOptions.NoColumnHeader | ExplorerBrowserContentSectionOptions.UseSearchFolder;
			eb.ViewMode = ExplorerBrowserViewMode.Icon;
			frm.ShowDialog();
		}

		private static Form MakeTestForm(out ExplorerBrowser eb)
		{
			var frm = new Form { Size = new System.Drawing.Size(300, 300) };
			frm.Controls.Add(eb = new ExplorerBrowser { Name = "eb", Dock = DockStyle.Fill });
			return frm;
		}
	}
}