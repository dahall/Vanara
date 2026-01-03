using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class ShellItemChangeWatcherTests
{
	private string? testDirectory;

	[SetUp]
	public void Setup()
	{
		testDirectory = Path.Combine(Path.GetTempPath(), $"ShellWatcherTest_{Guid.NewGuid()}");
		Directory.CreateDirectory(testDirectory);
	}

	[TearDown]
	public void Cleanup()
	{
		try { Directory.Delete(testDirectory!, true); } catch { }
	}

	[Test]
	public void ConstructorTest()
	{
		using var watcher = new ShellItemChangeWatcher();
		Assert.That(watcher.EnableRaisingEvents, Is.False);
		Assert.That(watcher.IncludeChildren, Is.False);
		Assert.That(watcher.NotifyFilter, Is.EqualTo(ChangeFilters.AllEvents));
	}

	[Test]
	public void ConstructorWithItemTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		using var watcher = new ShellItemChangeWatcher(item, true);
		Assert.That(watcher.Item, Is.EqualTo(item));
		Assert.That(watcher.IncludeChildren, Is.True);
		Assert.That(watcher.EnableRaisingEvents, Is.False);
	}

	[Test]
	public void ItemPropertyTest()
	{
		using var watcher = new ShellItemChangeWatcher();
		using var item = ShellItem.Open(testDirectory!);

		watcher.Item = item;
		Assert.That(watcher.Item, Is.EqualTo(item));
	}

	[Test]
	public void ItemPropertyNullThrowsTest()
	{
		using var watcher = new ShellItemChangeWatcher();
		Assert.That(() => watcher.Item = null!, Throws.ArgumentNullException);
	}

	[Test]
	public void PathPropertyTest()
	{
		using var watcher = new ShellItemChangeWatcher();
		watcher.Path = testDirectory!;
		Assert.That(watcher.Path, Is.EqualTo(testDirectory));
	}

	[Test]
	public void EnableRaisingEventsTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		using var watcher = new ShellItemChangeWatcher(item);
		
		Assert.That(watcher.EnableRaisingEvents, Is.False);
		
		watcher.EnableRaisingEvents = true;
		Assert.That(watcher.EnableRaisingEvents, Is.True);
		
		watcher.EnableRaisingEvents = false;
		Assert.That(watcher.EnableRaisingEvents, Is.False);
	}

	[Test]
	public void IncludeChildrenPropertyTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		using var watcher = new ShellItemChangeWatcher(item);
		
		Assert.That(watcher.IncludeChildren, Is.False);
		
		watcher.IncludeChildren = true;
		Assert.That(watcher.IncludeChildren, Is.True);
	}

	[Test]
	public void NotifyFilterPropertyTest()
	{
		using var watcher = new ShellItemChangeWatcher();
		
		Assert.That(watcher.NotifyFilter, Is.EqualTo(ChangeFilters.AllEvents));
		
		watcher.NotifyFilter = ChangeFilters.ItemCreated | ChangeFilters.ItemDeleted;
		Assert.That(watcher.NotifyFilter, Is.EqualTo(ChangeFilters.ItemCreated | ChangeFilters.ItemDeleted));
	}

	[Test]
	public void BeginInitEndInitTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		using var watcher = new ShellItemChangeWatcher(item);
		
		Assert.That(watcher.BeginInit, Throws.Nothing);
		Assert.That(watcher.EndInit, Throws.Nothing);
	}

	[Test]
	public void DisposeTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		ShellItemChangeWatcher watcher = new(item) { EnableRaisingEvents = true };

		Assert.That(watcher.Dispose, Throws.Nothing);
	}

	[Test]
	public async Task FileCreatedEventTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		using var watcher = new ShellItemChangeWatcher(item)
		{
			NotifyFilter = ChangeFilters.ItemCreated,
			EnableRaisingEvents = true
		};

		var eventRaised = new TaskCompletionSource<bool>();
		watcher.Changed += (s, e) =>
		{
			if (e.ChangeType == ChangeFilters.ItemCreated)
				eventRaised.TrySetResult(true);
		};

		var testFile = Path.Combine(testDirectory!, "test.txt");
		File.WriteAllText(testFile, "test");

		var result = await Task.WhenAny(eventRaised.Task, Task.Delay(5000));
		Assert.That(result, Is.EqualTo(eventRaised.Task));
		Assert.That(await eventRaised.Task, Is.True);
	}

	[Test]
	public async Task FileDeletedEventTest()
	{
		using var item = ShellItem.Open(testDirectory!);
		//using var item = new ShellFolder(PInvoke.Shell32.KNOWNFOLDERID.FOLDERID_LocalDocuments);
		var subDir = Path.Combine(item.FileSystemPath!, $"SubDir{Guid.NewGuid():N}");
		Directory.CreateDirectory(subDir);

		using ShellItemChangeWatcher watcher = new(item, true) { NotifyFilter = ChangeFilters.AllDiskEvents };
		var eventRaised = new TaskCompletionSource<bool>();
		watcher.Changed += (s, e) =>
		{
			if (e.ChangeType == ChangeFilters.FolderDeleted)
				eventRaised.TrySetResult(true);
		};
		watcher.EnableRaisingEvents = true;

		Directory.Delete(subDir);

		var result = await Task.WhenAny(eventRaised.Task, Task.Delay(5000));
		Assert.That(result, Is.EqualTo(eventRaised.Task));
		Assert.That(await eventRaised.Task, Is.True);
	}
}