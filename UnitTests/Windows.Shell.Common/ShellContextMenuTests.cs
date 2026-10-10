using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Vanara.Collections;
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

	private static void ShowMII(ShellContextMenu.MenuItemInfo mii, int c, int indent = 0)
	{
		if (mii.Text is "" or "-")
			TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}");
		else
			TestContext.WriteLine($"{new string(' ', indent * 3)}{c + 1}) \"{mii.Text}\" (#{mii.Id}) - Type={mii.Type}; State={mii.State}; Verb={mii.Verb}; Tooltip={mii.HelpText}; IconLoc={mii.VerbIconLocation}");
		for (int j = 0; j < mii.SubMenus.Length; j++)
			ShowMII(mii.SubMenus[j], j, indent + 1);
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
	}

	// Test to pull standard menu and then pull extended menu items using IExplorerCommandProvider interface and enumerate
	// installed packages with PackageManager.FindPackagesForUser and parse each manifest for the file explorer context menu
	// extension. This is a different code path than the one used in CreateTest above.
	[TestCaseSource(nameof(CreateSources))]
	public void CreateExtTest(string[] input)
	{
		ShellItem[] shis = Array.ConvertAll(input, ShellItem.Open);
		//using var menu = ShellContextMenu.CreateFromItems(shis, out var d);
		//menu.PopulateMenu(CMF.CMF_EXTENDEDVERBS);

		// Get the extended menu items using IExplorerCommandProvider interface
		PIDL[] pidls = Array.ConvertAll(shis, si => si.PIDL);
		using PIDL parent = PIDL.FindCommonParent(pidls);
		using ShellFolder parentFolder = new(parent);
		try
		{
			IExplorerCommandProvider? provider = parentFolder.GetViewObject<IExplorerCommandProvider>(User32.GetDesktopWindow());
			if (provider is not null)
			{
				Assert.That(provider.GetCommands(null, out IEnumExplorerCommand? ppv), ResultIs.Successful);
				using ShellItemArray shArray = new(parent, pidls);
				foreach (IExplorerCommand cmd in IEnumFromCom<IExplorerCommand>.Create(ppv!))
				{
					Assert.That(cmd.GetFlags(out var flags), ResultIs.Successful);
					if (flags.HasFlag(EXPCMDFLAGS.ECF_ISSEPARATOR))
					{
						TestContext.WriteLine(new string('-', 20));
						continue;
					}
					Assert.That(cmd.GetTitle(shArray.IShellItemArray!, out var title), ResultIs.Successful);
					TestContext.WriteLine($"{title} : {flags}");
				}
			}
		}
		catch
		{
			TestContext.WriteLine($"No provider");
		}

		// Add package manifest menus
		using var sid = AdvApi32.SafePSID.Current;
		foreach (var (name, _) in EnumPackageManifestForSid(sid))
		{
			if (Kernel32.OpenPackageInfoByFullName(name, out var pkgRef).Succeeded)
			{
				using (pkgRef)
				{
					if (Kernel32.GetPackageInfo(pkgRef, Kernel32.PACKAGE_INFORMATION.PACKAGE_INFORMATION_FULL, out var infoBuf).Succeeded)
					{
						Assert.That(infoBuf, Has.Length.GreaterThan(0));
						string path = Path.Combine(infoBuf[0].path, "AppxManifest.xml");
						bool wrote = false;
						Assert.That(File.Exists(path), Is.True);
						XDocument doc = XDocument.Load(path);
						foreach (var elem in doc.XPathSelectElements("//*[local-name()='Extension'][@Category='windows.fileExplorerContextMenus']//*[local-name()='ItemType']"))
						{
							if (!wrote) { TestContext.WriteLine($"<{infoBuf[0].packageId.name}> {path}"); wrote = true; }
							TestContext.WriteLine($"@ {elem.Attribute("Type")?.Value}");
							foreach (var verb in elem.XPathSelectElements("*[local-name()='Verb']"))
								TestContext.WriteLine($"> {verb.Attribute("Id")?.Value} - {verb.Attribute("Clsid")?.Value}");
						}
					}
				}
			}
		}

		static IEnumerable<(string name, string xml)> EnumPackageManifestForSid(PSID sid)
		{
			const string root = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Appx\AppxAllUserStore\";
			if (AdvApi32.RegOpenKeyEx(HKEY.HKEY_LOCAL_MACHINE, root + sid.ToString("D"), 0, AdvApi32.REGSAM.KEY_READ | AdvApi32.REGSAM.KEY_QUERY_VALUE | AdvApi32.REGSAM.KEY_WOW64_64KEY, out var hKey).Failed)
				yield break;
			using (hKey)
			{
				foreach (var (name, cls, lastWrite) in AdvApi32.RegEnumKeyEx(hKey))
				{
					if (AdvApi32.RegGetValue(hKey, name, "Path", AdvApi32.RRF.RRF_RT_ANY, out _, out var data).Succeeded)
					{
						yield return (name, Encoding.Unicode.GetString(data!).TrimEnd('\0'));
					}
				}
			}
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