namespace Vanara.PInvoke.Tests;

internal partial class BackgroundCopyTests
{
	[Test]
	public void FileCollTest()
	{
		using var tempRoot = new TemporaryDirectory();

		var srcFile = tempRoot.CreateFile().FullName;

		var dstFile = tempRoot.RandomTxtFileFullPath;

		using var job = BackgroundCopyManager.Jobs.Add(GetCurrentMethodName());

		Assert.That(() => job.Files.Add(srcFile, dstFile), Throws.Nothing);

		Assert.That(job.Files.Count, Is.EqualTo(1));

		Assert.That(job.Files.Count(), Is.EqualTo(1));

		Assert.That(job.Files.First().LocalFilePath, Is.EqualTo(dstFile));

		Assert.That(job.Cancel, Throws.Nothing);
	}
}