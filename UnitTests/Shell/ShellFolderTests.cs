using System;
using NUnit.Framework;
using static Vanara.PInvoke.Shell32;
using System.IO;
using System.Linq;

namespace Vanara.Windows.Shell.Tests
{
	[TestFixture]
	public class ShellFolderTests
	{
		private const string testFile = ShellItemTests.testDoc;
		private static string testFld = Path.GetDirectoryName(testFile);

		[Test]
		public void ShellFolderTest1()
		{
			Assert.That(() =>
			{
				var i = new ShellFolder(testFld);
				Assert.That(i.FileSystemPath, Is.EqualTo(testFld));
			}, Throws.Nothing);
			Assert.That(() => new ShellFolder((string) null), Throws.Exception);
			Assert.That(() => new ShellFolder(@"C:\Tamp"), Throws.Exception);
			Assert.That(() => new ShellFolder(testFile), Throws.Exception);
		}

		[Test]
		public void ShellFolderTest2()
		{
			Assert.That(() =>
			{
				var d = new ShellFolder(KNOWNFOLDERID.FOLDERID_Desktop);
				Assert.That(d, Is.EqualTo(ShellFolder.Desktop));
				var i = new ShellFolder(KNOWNFOLDERID.FOLDERID_ProgramFiles);
				Assert.That(i.FileSystemPath, Is.EqualTo(Environment.GetEnvironmentVariable("ProgramFiles")));
			}, Throws.Nothing);
			Assert.That(() => new ShellFolder((KNOWNFOLDERID)int.MaxValue), Throws.TypeOf<FileNotFoundException>());
		}

		[Test]
		public void ShellFolderTest3()
		{
			var pidl = new PIDL(testFld);
			Assert.That(() =>
			{
				var i = new ShellFolder(pidl);
				Assert.That(i.FileSystemPath, Is.EqualTo(testFld));
			}, Throws.Nothing);
			Assert.That(() => new ShellFolder((PIDL)null), Throws.Exception);
			Assert.That(() => new ShellFolder(new PIDL(@"C:\Tamp")), Throws.Exception);
			Assert.That(() => new ShellFolder(new PIDL(testFile)), Throws.Exception);
		}

		[Test]
		public void ShellFolderTest4()
		{
			Assert.That(() =>
			{
				var i = new ShellFolder(new ShellItem(testFld));
				Assert.That(i.FileSystemPath, Is.EqualTo(testFld));
			}, Throws.Nothing);
			Assert.That(() => new ShellFolder((ShellItem) null), Throws.Exception);
			Assert.That(() => new ShellFolder(new ShellItem(testFile)), Throws.Exception);
		}

		[Test]
		public void PropTest()
		{
			using (var si = new ShellItem(testFile))
			{
				using (var i = new ShellFolder(testFld))
				{
					Assert.That(i[Path.GetFileName(testFile)], Is.EqualTo(si));
					Assert.That(() => i[testFile], Throws.Exception);
					Assert.That(() => i[(string)null], Throws.Exception);
					Assert.That(() => i[""], Throws.Exception);
					Assert.That(() => i["bad.bad"], Throws.Exception);

					using (var pidl = new PIDL(testFile))
					{
						Assert.That(i[pidl.LastId], Is.EqualTo(si));
						Assert.That(i[pidl], Is.EqualTo(si));
					}
					Assert.That(() => i[(PIDL)null], Throws.Exception);
				}
			}
			using (var i = new ShellFolder(KNOWNFOLDERID.FOLDERID_Desktop))
				Assert.That(i, Is.EqualTo(ShellFolder.Desktop));
		}

		[Test]
		public void EnumerateTest()
		{
			Assert.That(() =>
			{
				using (var ie1 = new ShellFolder(KNOWNFOLDERID.FOLDERID_Windows))
				{
					var ie2 = ie1.EnumerateChildren(FolderItemFilter.NonFolders);
					Assert.That(ie1.Intersect(ie2).OrderBy(s => s.Name), Is.EquivalentTo(ie2.OrderBy(s => s.Name)));
				}
				using (var d = new ShellFolder(@"C:\"))
				{
					using (var libs = (ShellFolder)d["Temp"])
					{
						Assert.That(libs, Is.Not.Null.And.InstanceOf<ShellFolder>());
						using (var lnk = libs["Test.lnk"])
							Assert.That(lnk, Is.Not.Null.And.InstanceOf<ShellLink>());
					}
				}
			}, Throws.Nothing);
			Assert.That(() => new ShellFolder(KNOWNFOLDERID.FOLDERID_Windows).EnumerateChildren((FolderItemFilter)0x80000), Is.Empty);
		}

		[Test]
		public void GetObjectTest()
		{
			using (var f = new ShellFolder(testFld))
			using (var i = new ShellItem(testFile))
			{
				var qi = f.GetChildrenUIObjects<IQueryInfo>(null, i);
				Assert.That(qi, Is.Not.Null.And.InstanceOf<IQueryInfo>());
				System.Runtime.InteropServices.Marshal.ReleaseComObject(qi);
				var sv = f.GetViewObject<IShellView>(null);
				Assert.That(sv, Is.Not.Null.And.InstanceOf<IShellView>());
				Assert.That(() => f.GetChildrenUIObjects<IShellLibrary>(null, i), Throws.TypeOf<NotImplementedException>());
				Assert.That(() => f.GetViewObject<IShellLibrary>(null), Throws.TypeOf<NotImplementedException>());
			}
		}
	}
}