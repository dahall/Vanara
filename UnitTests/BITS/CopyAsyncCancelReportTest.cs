using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace Vanara.PInvoke.Tests;

internal partial class BackgroundCopyTests
{
	[Test]
	public void CopyAsyncCancelReportTest()
	{
		using var tempRoot = new TemporaryDirectory();

		var srcFile = tempRoot.CreateFile(100 * TemporaryDirectory.OneMebibyte).FullName;

		var dstFile = tempRoot.RandomTxtFileFullPath;

		using var cts = new CancellationTokenSource();

		var collection = new Collection<string>();

		var prog = new Progress<Tuple<BackgroundCopyJobState, byte>>(t => collection.Add($"{t.Item2}% : {t.Item1}"));

		cts.CancelAfter(TimeSpan.FromMilliseconds(50));

		Assert.That(() => BackgroundCopyManager.CopyAsync(srcFile, dstFile, cts.Token, prog), Throws.TypeOf<OperationCanceledException>());

		Assert.That(File.Exists(dstFile), Is.False);

		Assert.That(collection.Count, Is.GreaterThanOrEqualTo(0));

		TestContext.Write(string.Join("\r\n", collection));
	}
}