using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class ShlDispTests
{
	[Test]
	public void DetatilsTest()
	{
		var objShell = new IShellDispatch();
		var objFolder = objShell.NameSpace(ShellSpecialFolderConstants.ssfWINDOWS);
		Assert.That(objFolder, Is.Not.Null);
		var objFolderItems = objFolder!.Items() as FolderItems3;
		Assert.That(objFolderItems, Is.Not.Null);
		var objFolderItem = objFolderItems!.Item("NOTEPAD.EXE");
		Assert.That(objFolderItem, Is.Not.Null);
		TestContext.WriteLine(objFolderItem!.Path);
		TestContext.WriteLine($"Verbs: {string.Join(',', objFolderItem.Verbs().Cast<FolderItemVerb>().Select(v => v.Name))}");
		Assert.That(() => objFolderItem.InvokeVerb(), Throws.Nothing);
		Assert.That(() => objFolderItem.InvokeVerb("open"), Throws.Nothing);
	}
}