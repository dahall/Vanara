using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace Vanara.PInvoke.Tests;

internal partial class BackgroundCopyTests
{
	[Test]
	public void CopyAsyncReportTest()
	{
		using var tempRoot = new TemporaryDirectory();
		var srcFile = tempRoot.CreateFile().FullName;
		var dstFile = tempRoot.RandomTxtFileFullPath;

		using var cts = new CancellationTokenSource();
		var collection = new Collection<string>();
		var prog = new Progress<Tuple<BackgroundCopyJobState, byte>>(t => collection.Add($"{t.Item2}% : {t.Item1}"));
		Assert.That(() => BackgroundCopyManager.CopyAsync(srcFile, dstFile, cts.Token, prog), Throws.Nothing);

		Assert.That(File.Exists(dstFile), Is.True);
		Assert.That(collection.Count, Is.GreaterThan(0));
		TestContext.Write(string.Join("\r\n", collection));
	}
}