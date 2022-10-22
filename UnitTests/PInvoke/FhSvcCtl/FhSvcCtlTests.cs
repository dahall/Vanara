using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.FhSvcCtl;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class FhSvcCtlTests
	{
		[Test]
		public void TestIntf()
		{
			var mgr = new IFhConfigMgr();
			mgr.LoadConfiguration();
		}

		[Test]
		public void TestFn()
		{
			Assert.That(FhServiceOpenPipe(true, out var hPipe), ResultIs.Successful);
			Assert.That(FhServiceReloadConfiguration(hPipe), ResultIs.Successful);
			Assert.That(FhServiceStartBackup(hPipe, true), ResultIs.Successful);
			Assert.That(FhServiceBlockBackup(hPipe), ResultIs.Successful);
			Assert.That(FhServiceUnblockBackup(hPipe), ResultIs.Successful);
			Assert.That(FhServiceStopBackup(hPipe, false), ResultIs.Successful);
			Assert.That(() => hPipe.Dispose(), Throws.Nothing);
		}
	}
}