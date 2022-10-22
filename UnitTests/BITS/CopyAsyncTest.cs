using System.IO;
using System.Threading;

namespace Vanara.PInvoke.Tests
{
	internal partial class BackgroundCopyTests
	{
		[Test]
		public void CopyAsyncTest()
		{
			using var tempRoot = new TemporaryDirectory();

			var srcFile = tempRoot.CreateFile().FullName;

			var dstFile = tempRoot.RandomTxtFileFullPath;

			using var cts = new CancellationTokenSource();

			Assert.That(() => BackgroundCopyManager.CopyAsync(srcFile, dstFile, cts.Token, null), Throws.Nothing);

			Assert.That(File.Exists(dstFile), Is.True);
		}
	}
}