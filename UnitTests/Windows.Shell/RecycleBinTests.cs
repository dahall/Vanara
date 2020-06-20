using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class RecycleBinTests
	{
		const string tempDir = "C:\\Temp";
		const string tempDir2 = "D:\\";

		[Test]
		public void RecycleBinEnumTest()
		{
			// Setup files to delete
			var paths = new Stack<string>();
			var sb = new StringBuilder(Kernel32.MAX_PATH);
			var fileContent = new string('0', 1024);
			for (int i = 0; i < 5; i++)
				MakeFile(tempDir);
			for (int i = 0; i < 5; i++)
				MakeFile(tempDir2);

			try
			{
				// Delete files to bin
				RecycleBin.DeleteToRecycleBin(paths, true);
				// Get details
				TestContext.WriteLine($"cnt={RecycleBin.Count}; sz={RecycleBin.Size}");
				// Restore files
				RecycleBin.Restore(paths.Select(p => RecycleBin.GetItemFromOriginalPath(p)));
				Assert.That(RecycleBin.Count, Is.EqualTo(0L));
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
			Assert.IsTrue(Directory.Exists(dir));
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
}