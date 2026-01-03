using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.Tests;

[TestFixture, Apartment(ApartmentState.STA)]
public class ShellContextMenuTests
{
	private static string[][] CreateSources()
	{
		var shi = TestCaseSources.LogFile;
		return
		[
			[TestCaseSources.TempDir], // Folder
			[shi], // Single file
			[shi, TestCaseSources.Image2File], // Multiple files, same parent
			[shi, System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "notepad.exe")], // Multiple files, different parents
		];
	}

	[TestCaseSource(nameof(CreateSources))]
	public void CreateTest(string[] input)
	{
		var shis = Array.ConvertAll(input, ShellItem.Open);
		using var menu = ShellContextMenu.CreateFromItems(shis, out var d);
		menu.PopulateMenu(CMF.CMF_EXTENDEDVERBS);
		int c = 0;
		foreach (var i in menu.GetItems())
			ShowMII(i, c++);

		static void ShowMII(ShellContextMenu.MenuItemInfo mii, int c, int indent = 0)
		{
			if (mii.Text is "" or "-")
				TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}");
			else
				TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}; Tooltip={mii.HelpText}; IconLoc={mii.VerbIconLocation}");
			for (int j = 0; j < mii.SubMenus.Length; j++)
				ShowMII(mii.SubMenus[j], j, indent + 1);
		}
	}

	[Test]
	public void InvokeVerbTest()
	{
		using var shi = ShellItem.Open(TestCaseSources.ImageFile);
		shi.ContextMenu.InvokeVerb("properties");
	}

	[Test]
	public void InvokeVerbTest2()
	{
		using var shi = ShellItem.Open(TestCaseSources.TempDir);
		Assert.That(shi.IsFolder);
		shi.ContextMenu.InvokeVerb("properties");
	}

	[Test]
	public async Task ShowTest()
	{
		//using var shi = ShellItem.Open(TestCaseSources.ImageFile);
		//shi.ContextMenu.ShowContextMenu(new(100,100), onMenuItemClicked: (m, i, w) => shi.InvokeVerb(shi.ContextMenu.GetVerbForCommand(i) ?? "open"));

		var pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.ImageFile);
		Assert.That(pshi, Is.Not.Null);
		var pcm = pshi!.BindToHandler<IContextMenu>(null, BHID.BHID_SFUIObject);

		var eventRaised = new TaskCompletionSource<bool>();
		new ShellContextMenu(pcm).ShowContextMenu(new(100, 100), onMenuItemClicked: (m, i, w) => eventRaised.TrySetResult(true));
		Assert.That(Task.WhenAny(eventRaised.Task, Task.Delay(5000)).Result, Is.EqualTo(eventRaised.Task));
		Assert.That(await eventRaised.Task, Is.True);

	}

	[Test]
	public async Task ShowTest2()
	{
		var pshi = SHCreateItemFromParsingName<IShellItem>(TestCaseSources.ImageFile);
		Assert.That(pshi, Is.Not.Null);
		var pcm = pshi!.BindToHandler<IContextMenu>(null, BHID.BHID_SFUIObject);

		var eventRaised = new TaskCompletionSource<bool>();
		new ShellContextMenu(pcm).ShowContextMenu(new(100, 100), onMenuItemClicked: (m, i, w) => eventRaised.TrySetResult(true));
		Assert.That(Task.WhenAny(eventRaised.Task, Task.Delay(5000)).Result, Is.EqualTo(eventRaised.Task));
		Assert.That(await eventRaised.Task, Is.True);
	}

	[Test]
	public async Task ShowTest3()
	{
		using var shi = ShellItem.Open(TestCaseSources.ImageFile);
		var pcm = shi.IShellItem.BindToHandler<IContextMenu>(null, BHID.BHID_SFUIObject);

		var eventRaised = new TaskCompletionSource<bool>();
		new ShellContextMenu(pcm).ShowContextMenu(new(100, 100), onMenuItemClicked: (m, i, w) => eventRaised.TrySetResult(true));
		Assert.That(Task.WhenAny(eventRaised.Task, Task.Delay(5000)).Result, Is.EqualTo(eventRaised.Task));
		Assert.That(await eventRaised.Task, Is.True);

	}

	[Test]
	public async Task ShowTest4()
	{
		using var shi = ShellItem.Open(TestCaseSources.ImageFile);

		var eventRaised = new TaskCompletionSource<bool>();
		shi.ContextMenu.ShowContextMenu(new(100, 100), onMenuItemClicked: (m, i, w) => eventRaised.TrySetResult(true));
		Assert.That(Task.WhenAny(eventRaised.Task, Task.Delay(5000)).Result, Is.EqualTo(eventRaised.Task));
		Assert.That(await eventRaised.Task, Is.True);

	}

	[Test]
	public async Task ShowTest5()
	{
		using var shi = ShellItem.Open(TestCaseSources.ImageFile);
		shi.ContextMenu.ShowContextMenu(new(100, 100));
	}

	[Test]
	public void TestRepeatFail()
	{
		for (int i = 0; i < 20; i++)
		{
			using ShellItem Item = ShellItem.Open(TestCaseSources.ImageFile);
			using var ContextMenu = ShellContextMenu.CreateFromItems([Item], out var d);
		}
	}
}