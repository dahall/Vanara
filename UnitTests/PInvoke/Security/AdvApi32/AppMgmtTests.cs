using NUnit.Framework;
using System;
using System.Linq;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class AppMgmtTests
{
	[Test] // TODO: Figure out how to test
	public void GetLocalManagedApplicationsTest()
	{
		var l = GetLocalManagedApplications(true).ToArray();
		TestContext.WriteLine("; ", l.Select(i => i.pszDeploymentName));
		l = GetLocalManagedApplications(false).ToArray();
		TestContext.WriteLine("; ", l.Select(i => i.pszDeploymentName));
	}

	[Test] // TODO: Figure out how to test
	public void GetManagedApplicationCategoriesTest()
	{
		var l = GetManagedApplicationCategories().ToArray();
		TestContext.WriteLine("; ", l.Select(i => i.pszDescription));
		Assert.That(l, Is.Not.Empty);
	}

	[Test] // TODO: Figure out how to test
	public void GetManagedApplicationsTest()
	{
		var l = GetManagedApplications(null).ToArray();
		TestContext.WriteLine("; ", l.Select(i => i.pszPackageName));
		Assert.That(l, Is.Not.Empty);
	}

	[Test]
	public void InstallApplicationTest()
	{
		var id = new INSTALLDATA { Type = INSTALLSPECTYPE.FILEEXT };
		var pExt = new SafeCoTaskMemString("*.jpg");
		id.Spec = new INSTALLSPEC { FileExt = (IntPtr)pExt };
		Assert.That(InstallApplication(id), ResultIs.Successful);
	}
}