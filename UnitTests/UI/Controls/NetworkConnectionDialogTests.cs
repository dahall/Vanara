using NUnit.Framework;
using System.Windows.Forms;

namespace Vanara.Windows.Forms.Tests
{
	[TestFixture()]
	public class NetworkConnectionDialogTests
	{
		[Test()]
		public void NetworkConnectionDialogTest()
		{
			var ncd = new NetworkConnectionDialog { UseMostRecentPath = true };
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK));
			Assert.That(ncd.ConnectedDeviceCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(MessageBox.Show("Confirm MRU path shown", "NetworkConnectionDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);

			ncd.Reset();
			Assert.That(ncd.UseMostRecentPath, Is.False);

			ncd.RemoteNetworkName = @"\\HALLAN-SVR\share";
			Assert.That(() => ncd.UseMostRecentPath = true, Throws.InvalidOperationException);
			ncd.HideRestoreConnectionCheckBox = true;
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK));
			Assert.That(MessageBox.Show("Confirm remote path shown and checkbox hidden.", "NetworkConnectionDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		}

		[Test()]
		public void NetworkDisconnectDialogTest()
		{
			var ncd = new NetworkDisconnectDialog { LocalDeviceName = "S:", ForceDisconnect = true, UpdateProfile = true };
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK));
			Assert.That(MessageBox.Show("Confirm local, force and update", "NetworkDisconnectDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);

			ncd.Reset();
			Assert.That(ncd.ForceDisconnect, Is.False);
			Assert.That(ncd.LocalDeviceName, Is.Null);

			ncd.RemoteNetworkName = @"\\HALLAN-SVR\share";
			Assert.That(() => ncd.UpdateProfile = true, Throws.InvalidOperationException);
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK));
			Assert.That(MessageBox.Show("Confirm remote.", "NetworkDisconnectDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		}
	}
}