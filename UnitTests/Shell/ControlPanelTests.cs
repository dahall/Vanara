using NUnit.Framework;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ControlPanelTests
	{
		[Test]
		public void ControlPanelOpenTest()
		{
			Assert.That(() => ControlPanel.Open(ControlPanelItem.BitLockerDriveEncryption), Throws.Nothing);
			Assert.That(() => ControlPanel.Open((ControlPanelItem)0xFFFF), Throws.Exception);
			Assert.That(() => ControlPanel.Open(ControlPanelItem.DefaultPrograms, "pageFileAssoc"), Throws.Nothing);
			Assert.That(() => ControlPanel.Open(ControlPanelItem.DefaultPrograms, "XX"), Throws.Exception);
		}
	}
}