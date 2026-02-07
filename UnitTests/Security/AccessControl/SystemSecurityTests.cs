using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.Security.Principal;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl.Tests;

[TestFixture()]
public class SystemSecurityTests
{
	[Test()]
	public void EnumerateAccountsWithRightTest()
	{
		SystemSecurity ss;
		using (ss = new SystemSecurity(SystemSecurity.DesiredAccess.ViewLocalInformation | SystemSecurity.DesiredAccess.LookupNames))
			Assert.That(ss.EnumerateAccountsWithRight(SystemPrivilege.Backup), Is.Not.Empty);
	}

	[TestCase("SYSTEM")]
	[TestCase("Administrators")]
	[TestCase("Everyone")]
	[TestCase("%USERNAME%")]
	[TestCase("%USERDOMAIN%\\%USERNAME%")]
	[TestCase("USER12", false)]
	public void GetAccountInfoTest(string acctName, bool valid = true)
	{
		if (acctName.Contains('%'))
			acctName = Environment.ExpandEnvironmentVariables(acctName);
		SystemSecurity ss;
		using (ss = new SystemSecurity(SystemSecurity.DesiredAccess.LookupNames))
		{
			SystemSecurity.SystemAccountInfo? sai = null;
			Assert.That(() => sai = ss.GetAccountInfo(acctName), valid ? (IResolveConstraint)Throws.Nothing : Throws.Exception);
			TestContext.WriteLine($"{sai?.SidType ?? SID_NAME_USE.SidTypeUnknown}:{sai?.Name}");
		}
	}

	[Test()]
	public void GetAccountInfoTest1()
	{
		SystemSecurity ss;
		using (ss = new SystemSecurity(SystemSecurity.DesiredAccess.LookupNames))
		{
			IList<SystemSecurity.SystemAccountInfo>? sa = null;
			Assert.That(() => sa = ss.GetAccountInfo(false, "SYSTEM", "Administrator", "Everyone", "dahall", "AMERICAS\\dahall", "AAADELETE", "DAHALL17", "DAHALL12"), Throws.Nothing);
			foreach (var sai in sa!)
				TestContext.WriteLine($"{sai.SidType}:{sai.Name}");
		}
	}

	[Test()]
	public void GetAccountInfoTest2()
	{
		SystemSecurity ss;
		using (ss = new SystemSecurity(SystemSecurity.DesiredAccess.LookupNames))
		{
			IList<SystemSecurity.SystemAccountInfo>? sa = null;

			using var identity = WindowsIdentity.GetCurrent();

			Assert.That(() => sa = ss.GetAccountInfo(false, false, identity.User!, new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null)), Throws.Nothing);

			foreach (var sai in sa!)
				TestContext.WriteLine($"{sai.SidType}:{sai.Name}");
		}
	}

	[Test()]
	public void GetAvailableCAPIDsTest()
	{
		using var ss = SystemSecurity.Local;
		Assert.That(() => ss.GetAvailableCAPIDs(), Throws.Nothing);
	}

	[Test()]
	public void UserLogonRightsTest()
	{
		using var ss = SystemSecurity.Local;
		SystemSecurity.LogonRights? r = null;
		Assert.That(() => r = ss.UserLogonRights(null), Throws.Nothing);
		TestContext.WriteLine($"{r}");
	}

	[Test()]
	public void UserPrivilegesTest()
	{
		using var ss = SystemSecurity.Local;
		SystemSecurity.AccountPrivileges? p = null;
		Assert.That(() => p = ss.UserPrivileges(null), Throws.Nothing);
		TestContext.WriteLine($"{p}");
	}
}