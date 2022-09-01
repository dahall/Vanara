using NUnit.Framework;
using System.IO;

namespace Vanara.PInvoke.Tests;

partial class BackgroundCopyTests
{
	[Test]
	public void CopyTest()
	{
		using var tempRoot = new TemporaryDirectory();

		var srcFile = tempRoot.CreateFile().FullName;

		var dstFile = tempRoot.RandomTxtFileFullPath;


		Assert.That(() => BackgroundCopyManager.Copy(srcFile, dstFile), Throws.Nothing);

		Assert.That(File.Exists(dstFile));
	}
}
