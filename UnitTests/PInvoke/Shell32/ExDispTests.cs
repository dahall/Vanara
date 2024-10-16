using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Shell32;
using IServiceProvider = Vanara.PInvoke.Shell32.IServiceProvider;

namespace Vanara.PInvoke.Tests;

[TestFixture, Apartment(System.Threading.ApartmentState.STA)]
public class ExpDispTests
{
	[Test]
	public void FindWindowTest()
	{
		IShellWindows sw = new();
		IServiceProvider? sp = null;
		Assert.That(() => sp = sw.FindWindowSW<IServiceProvider>(CSIDL.CSIDL_DESKTOP, ShellWindowTypeConstants.SWC_DESKTOP), Throws.Nothing);
		Assert.That(sp, Is.Not.Null);
	}

	[Test]
	public void WindowEnumTest()
	{
		IShellWindows sw = new();
		foreach (var sp in sw.Cast<IServiceProvider>())
		{
			IShellView? view = null;
			Assert.That(() => sp.QueryService<IShellBrowser>(SID_STopLevelBrowser)?.QueryActiveShellView(out view).ThrowIfFailed(), Throws.Nothing);
			IFolderView? fv = view as IFolderView;
			Assert.That(fv, Is.Not.Null);
			PIDL pidl = PIDL.Null;
			Assert.That(() => pidl = fv!.Item(fv!.GetFocusedItem()), Throws.Nothing);
			Assert.That(pidl.IsInvalid, Is.False);
			Assert.That(SHGetNameFromIDList(pidl, SIGDN.SIGDN_NORMALDISPLAY, out var name), ResultIs.Successful);
			TestContext.WriteLine(name);
		}
	}
}