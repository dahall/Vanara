using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
[TestFixture, SingleThreaded]
public class ShellFolderTests
{
	private static readonly string testFile = ShellItemTests.testDoc;
	private static readonly string testFld = Path.GetDirectoryName(testFile)!;

	[Test]
	public void ShellFolderTest1()
	{
		Assert.That(() => { Assert.That(new ShellFolder(testFld).FileSystemPath, Is.EqualTo(testFld)); }, Throws.Nothing);
		Assert.That(() => new ShellFolder((string?)null), Throws.Exception);
		Assert.That(() => new ShellFolder(@"C:\Tamp"), Throws.Exception);
		Assert.That(() => new ShellFolder(testFile), Throws.Nothing);
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
		using var pidl = new PIDL(testFld);
		Assert.That(() => { Assert.That(new ShellFolder(pidl).FileSystemPath, Is.EqualTo(testFld)); }, Throws.Nothing);
		Assert.That(() => new ShellFolder((PIDL?)null), Throws.Exception);
		Assert.That(() => new ShellFolder(new PIDL(@"C:\Tamp")), Throws.Exception);
		Assert.That(() => new ShellFolder(new PIDL(testFile)), Throws.Nothing);
	}

	[Test]
	public void ShellFolderTest4()
	{
		Assert.That(() => { Assert.That(new ShellFolder(new ShellItem(testFld)).FileSystemPath, Is.EqualTo(testFld)); }, Throws.Nothing);
		Assert.That(() => new ShellFolder((ShellItem?)null), Throws.Exception);
		Assert.That(() => new ShellFolder(new ShellItem(testFile)), Throws.Nothing);
	}

	[Test]
	public void PropTest()
	{
		using (var si = new ShellItem(testFile))
		{
			using var i = new ShellFolder(testFld);
			Assert.That(i[Path.GetFileName(testFile)], Is.EqualTo(si));
			Assert.That(() => i[testFile], Throws.Exception);
			Assert.That(() => i[(string?)null], Throws.Exception);
			Assert.That(() => i[""], Throws.Exception);
			Assert.That(() => i["bad.bad"], Throws.Exception);

			using (var pidl = new PIDL(testFile))
			{
				Assert.That(i[pidl.LastId], Is.EqualTo(si));
				Assert.That(i[pidl], Is.EqualTo(si));
			}
			Assert.That(() => i[(PIDL?)null], Throws.Exception);
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
			using var d = new ShellFolder(@"C:\");
			using var libs = (ShellFolder)d["Temp"];
			Assert.That(libs, Is.Not.Null.And.InstanceOf<ShellFolder>());
			Assert.True(libs["Test.lnk"] is ShellItem);
		}, Throws.Nothing);
		Assert.That(() => new ShellFolder(KNOWNFOLDERID.FOLDERID_Windows).EnumerateChildren((FolderItemFilter)0x80000), Is.Empty);
	}

	[Test]
	public void EnumerateLibTest()
	{
		using ShellFolder ie1 = new(KNOWNFOLDERID.FOLDERID_Desktop);
		List<ShellItem> ie2 = ie1.EnumerateChildren(FolderItemFilter.NonFolders | FolderItemFilter.Folders).ToList();
		TestContext.WriteLine(string.Join('\n', ie2.Select(i => $"{i.Name} - {i.GetType().Name}")));
		Assert.That(ie2, Has.Count.GreaterThan(0));
		ShellFolder? libs = ie2.Find(i => i.Name == "Libraries") as ShellFolder;
		Assert.That(libs, Is.Not.Null);
		List<ShellItem> il = libs!.EnumerateChildren(FolderItemFilter.Folders | FolderItemFilter.IncludeHidden | FolderItemFilter.NonFolders | FolderItemFilter.IncludeSuperHidden).ToList();
		TestContext.WriteLine('\n' + string.Join('\n', il.Select(i => i.PIDL.ToString())));
	}

	[Test]
	public void EnumComputerTest()
	{
		using var computer = new ShellFolder(KNOWNFOLDERID.FOLDERID_ComputerFolder);
		foreach (var si in computer)
		{
			TestContext.WriteLine(si.ParsingName);
			si.Dispose();
		}
	}

	[Test]
	public void GetDisplayNameTest()
	{
		using (var i = new ShellFolder(PInvoke.Tests.TestCaseSources.TempDir))
		{
			Assert.That(i.GetDisplayName(ShellItemDisplayString.FileSysPath), Is.EqualTo(PInvoke.Tests.TestCaseSources.TempDir).IgnoreCase);
			foreach (ShellItemDisplayString e in Enum.GetValues(typeof(ShellItemDisplayString)))
				Assert.That(() => TestContext.WriteLine($"{e}={i.GetDisplayName(e)}"), Throws.Nothing);
			Assert.That(i.GetDisplayName((ShellItemDisplayString)0x8fffffff), Is.EqualTo(i.GetDisplayName(0)));
		}

		using (var i = new ShellFolder(KNOWNFOLDERID.FOLDERID_DocumentsLibrary))
		{
			foreach (ShellItemDisplayString e in Enum.GetValues(typeof(ShellItemDisplayString)))
				Assert.That(() => TestContext.WriteLine($"{e}={i.GetDisplayName(e)}"), Throws.Nothing);
			Assert.That(i.GetDisplayName((ShellItemDisplayString)0x8fffffff), Is.EqualTo(i.GetDisplayName(0)));
		}
	}

	[Test]
	public void GetObjectTest()
	{
		using var f = new ShellFolder(testFld);
		using var i = new ShellItem(testFile);
		var qi = f.GetChildrenUIObjects<IQueryInfo>(default, i);
		Assert.That(qi, Is.Not.Null.And.InstanceOf<IQueryInfo>());
		Marshal.ReleaseComObject(qi);
		var sv = f.GetViewObject<IShellView>(default);
		Assert.That(sv, Is.Not.Null.And.InstanceOf<IShellView>());
		Assert.That(() => f.GetChildrenUIObjects<IShellLibrary>(default, i), Throws.TypeOf<NotImplementedException>());
		Assert.That(() => f.GetViewObject<IShellLibrary>(default), Throws.TypeOf<InvalidCastException>());
	}

	[Test]
	public void CategoryTest()
	{
		using var ie = new ShellFolder(KNOWNFOLDERID.FOLDERID_DocumentsLibrary);
		if (Vanara.PInvoke.PInvokeClient.Windows11.IsPlatformSupported())
			return;
		Assert.That(ie.Categories, Is.Not.Empty);
		Assert.That(ie.Categories.DefaultCategory?.Name, Is.Not.Null);
		foreach (var c in ie.Categories)
			TestContext.WriteLine($"{c.Name}");
	}
}