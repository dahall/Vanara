using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class RecycleBinTests
{
	const string tempDir = "C:\\Temp";

	[Test]
	public void RecycleBinEnumTest()
	{
		// Setup files to delete
		var paths = new Stack<string>();
		var sb = new StringBuilder(Kernel32.MAX_PATH);
		var fileContent = new string('0', 1024);
		for (int i = 0; i < 5; i++)
			MakeFile(tempDir);

		try
		{
			var startCount = RecycleBin.Count;
			// Delete files to bin
			RecycleBin.DeleteToRecycleBin(paths, true);
			// Get details
			TestContext.WriteLine($"cnt={RecycleBin.Count}; sz={RecycleBin.Size}");
			Assert.That(RecycleBin.Count, Is.EqualTo(startCount + paths.Count));
			// Restore files
			RecycleBin.Restore(paths.Select(RecycleBin.GetItemFromOriginalPath).WhereNotNull());
			Assert.That(RecycleBin.Count, Is.EqualTo(startCount));
		}
		finally
		{
			// Delete files completely
			while (paths.Count > 0)
				File.Delete(paths.Pop());
		}

		void MakeFile(string dir)
		{
			Kernel32.GetTempFileName(dir, "tmp", 0, sb);
			paths.Push(sb.ToString());
			File.WriteAllText(paths.Peek(), fileContent);
		}
	}

	[Test]
	public void DelRestoreFolderTest()
	{
		const string dir = @"C:\Temp\Fonts\";
		RecycleBin.DeleteToRecycleBin(dir);
		Assert.That(RecycleBin.Count, Is.GreaterThan(0L));
		TestContext.WriteLine($"cnt={RecycleBin.Count}; sz={RecycleBin.Size}");
		RecycleBin.RestoreAll();
		Assert.That(RecycleBin.Count, Is.EqualTo(0L));
		Assert.That(Directory.Exists(dir));
	}

	[Test]
	public void EmptyTest()
	{
		Assert.That(RecycleBin.Count, Is.EqualTo(0L));

		// Setup files to delete
		for (int i = 0; i < 5; i++)
			RecycleBin.DeleteToRecycleBin(Path.GetTempFileName());

		Assert.That(() => RecycleBin.Empty(false, false, false), Throws.Nothing);
		Assert.That(RecycleBin.Count, Is.EqualTo(0L));

		// Setup files to delete
		for (int i = 0; i < 5; i++)
			RecycleBin.DeleteToRecycleBin(Path.GetTempFileName());

		Assert.That(() => RecycleBin.Empty(), Throws.Nothing);
		Assert.That(RecycleBin.Count, Is.EqualTo(0L));
	}
}