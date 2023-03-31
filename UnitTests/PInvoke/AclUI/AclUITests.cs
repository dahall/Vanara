using NUnit.Framework;
using System;
using static Vanara.PInvoke.AclUI;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class AclUITests
{
	[Test()]
	public void COMBINE_PAGE_ACTIVATIONTest()
	{
		Assert.That(COMBINE_PAGE_ACTIVATION(SI_PAGE_TYPE.SI_PAGE_PERM, SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT), Is.EqualTo(0));
		Assert.That(COMBINE_PAGE_ACTIVATION(SI_PAGE_TYPE.SI_PAGE_OWNER, SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT), Is.EqualTo(3));
		Assert.That(COMBINE_PAGE_ACTIVATION(SI_PAGE_TYPE.SI_PAGE_PERM, SI_PAGE_ACTIVATED.SI_SHOW_AUDIT_ACTIVATED), Is.EqualTo(131072));
	}

	[Test()]
	public void EditSecurityTest()
	{
		Assert.That(EditSecurity(IntPtr.Zero, null), Is.False);
	}

	[Test()]
	public void EditSecurityAdvancedTest()
	{
		Assert.That(EditSecurityAdvanced(IntPtr.Zero, null, SI_PAGE_TYPE.SI_PAGE_PERM, SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT).Failed);
	}
}