using NUnit.Framework;
using System.Windows.Forms;

namespace Vanara.Windows.Forms.Tests
{
	[TestFixture()]
	public class NetworkConnectionDialogTests
	{
		private const string remoteName = @"\\HALLAN-SVR\share";

		[Test()]
		public void NetworkConnectionDialogTest()
		{
			var ncd = new NetworkConnectionDialog { UseMostRecentPath = true };
			ncd.HideRestoreConnectionCheckBox = true;
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK).Or.EqualTo(DialogResult.Cancel));
			//Assert.That(ncd.ConnectedDeviceCount, Is.GreaterThanOrEqualTo(0));
			Assert.That(MessageBox.Show("Confirm MRU path shown and checkbox hidden", "NetworkConnectionDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);

			ncd.Reset();
			Assert.That(ncd.UseMostRecentPath, Is.False);

			ncd.RemoteNetworkName = remoteName;
			ncd.ReadOnlyPath = true;
			Assert.That(() => ncd.UseMostRecentPath = true, Throws.InvalidOperationException);
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK).Or.EqualTo(DialogResult.Cancel));
			Assert.That(MessageBox.Show("Confirm remote path shown.", "NetworkConnectionDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		}

		[Test()]
		public void NetworkDisconnectDialogTest()
		{
			const string drive = "S:";

			Vanara.PInvoke.Mpr.WNetAddConnection2(new PInvoke.Mpr.NETRESOURCE(remoteName, drive), null, null, PInvoke.Mpr.CONNECT.CONNECT_TEMPORARY | PInvoke.Mpr.CONNECT.CONNECT_UPDATE_RECENT);

			var ncd = new NetworkDisconnectDialog { LocalDeviceName = drive, RemoteNetworkName = remoteName, ForceDisconnect = false, UpdateProfile = true };
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK).Or.EqualTo(DialogResult.Cancel));
			Assert.That(MessageBox.Show("Confirm local, force and update", "NetworkDisconnectDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);

			ncd.Reset();
			Assert.That(ncd.ForceDisconnect, Is.True);
			Assert.That(ncd.LocalDeviceName, Is.Null);

			Vanara.PInvoke.Mpr.WNetAddConnection2(new PInvoke.Mpr.NETRESOURCE(remoteName, drive), null, null, PInvoke.Mpr.CONNECT.CONNECT_TEMPORARY | PInvoke.Mpr.CONNECT.CONNECT_UPDATE_RECENT);

			Assert.That(() => ncd.UpdateProfile = true, Throws.InvalidOperationException);
			ncd.LocalDeviceName = drive;
			Assert.That(ncd.ShowDialog(), Is.EqualTo(DialogResult.OK).Or.EqualTo(DialogResult.Cancel));
			Assert.That(MessageBox.Show("Confirm remote.", "NetworkDisconnectDialog Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		}
	}
}