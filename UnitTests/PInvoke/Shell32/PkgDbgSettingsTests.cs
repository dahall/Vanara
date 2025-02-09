using NUnit.Framework;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class PkgDbgSettingsTests
{
	const string pkgName = "Microsoft.WindowsStore_12006.1001.1.0_x64__8wekyb3d8bbwe";

	[Test]
	public void EnumTest()
	{
		using var pSetting = ComReleaserFactory.Create(new IPackageDebugSettings());
		try
		{
			var state = pSetting.Item.GetPackageExecutionState(pkgName);
			state.WriteValues();

			pSetting.Item.EnumerateBackgroundTasks(pkgName, out var cnt, out var tasks, out var names);
			Assert.That((int)cnt, Is.EqualTo(tasks.Length));
			for (var i = 0; i < cnt; i++)
				TestContext.WriteLine($"{tasks[i]} = {names[i]}");

			((IPackageDebugSettings2)pSetting.Item).EnumerateApps(pkgName, out cnt, out var ids, out var dispNames);
			Assert.That((int)cnt, Is.EqualTo(ids.Length));
			for (var i = 0; i < cnt; i++)
				TestContext.WriteLine($"{ids[i]} = {dispNames[i]}");
		}
		catch (COMException comex)
		{
			Assert.That((HRESULT)comex.HResult, ResultIs.Successful);
		}
	}
}