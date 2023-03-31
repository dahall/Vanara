using NUnit.Framework;
using System;
using System.Text;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.UserEnv;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class UserEnvTests
{
	private const string localAcct = "test";
	private const string localAcctPwd = "Passw0rd!";

	[Test]
	public void CreateAppContainerProfileTest()
	{
		const string cname = "MySillyImpossibleAppName098";

		try
		{
			Assert.That(CreateAppContainerProfile(cname, "My silly display name", "Silly", null, 0, out var sid), ResultIs.Successful);
			Assert.That(DeriveAppContainerSidFromAppContainerName(cname, out var sid2), ResultIs.Successful);
			Assert.That(EqualSid(sid, sid2));
			var ssid = ((PSID)sid2).ToString("D");
			sid.Dispose();
			sid2.Dispose();

			Assert.That(GetAppContainerFolderPath(ssid, out var path), ResultIs.Successful);
			Assert.That(path.Length, Is.GreaterThan(0));
			TestContext.WriteLine(path);

		}
		finally
		{
			Assert.That(DeleteAppContainerProfile(cname), ResultIs.Successful);
		}
	}

	[Test]
	public void CreateEnvironmentBlockTest_And_DestroyEnvironmentBlockTest()
	{
		using var hToken = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ);
		Assert.That(hToken.IsInvalid, Is.False);

		Assert.That(CreateEnvironmentBlock(out string[] environmentBlock, hToken, false), ResultIs.Successful);
		Assert.That(environmentBlock, Is.Not.Empty);

		// Validate same environment variables count as .NET method
		// Assert.That(Environment.GetEnvironmentVariables().Count, Is.EqualTo(environmentBlock.Length));
		TestContext.Write(string.Join("\r\n", environmentBlock));
	}

	[Test]
	public void CreateProfileTest()
	{
		var curSid = SafePSID.Current;
		var sb = new StringBuilder(260);
		Assert.That(CreateProfile(curSid.ToString("D"), curSid.ToString("N"), sb, (uint)sb.Length), ResultIs.Failure);

		Assert.That(LogonUser(localAcct, ".", localAcctPwd, LogonUserType.LOGON32_LOGON_INTERACTIVE, LogonUserProvider.LOGON32_PROVIDER_DEFAULT, out var hTok), ResultIs.Successful);
		using var id = new System.Security.Principal.WindowsIdentity(hTok.DangerousGetHandle());
		try
		{
			Assert.That(CreateProfile(id.User.Value, localAcct, sb, (uint)sb.Capacity), ResultIs.Successful);

			var pi = new PROFILEINFO(localAcct);
			Assert.That(LoadUserProfile(hTok, ref pi), ResultIs.Successful);
			Assert.That(UnloadUserProfile(hTok, pi.hProfile), ResultIs.Successful);
		}
		finally
		{
			Assert.That(DeleteProfile(id.User.Value), ResultIs.Successful);
			hTok.Dispose();
		}
	}

	[Test]
	public void EnterCriticalPolicySectionTest()
	{
		SafeCriticalPolicySectionHandle h;
		Assert.That(h = EnterCriticalPolicySection(false), ResultIs.ValidHandle);
		Assert.That(() => h.Dispose(), Throws.Nothing);
	}

	[Test]
	public void ExpandEnvironmentStringsForUserTest()
	{
		Assert.That(LogonUser(localAcct, ".", localAcctPwd, LogonUserType.LOGON32_LOGON_INTERACTIVE, LogonUserProvider.LOGON32_PROVIDER_DEFAULT, out var hTok), ResultIs.Successful);
		try
		{
			var sb = new StringBuilder(260);
			Assert.That(ExpandEnvironmentStringsForUser(hTok, "TEMP", sb, (uint)sb.Capacity), ResultIs.Successful);
			Assert.That(sb.Length, Is.GreaterThan(0));
		}
		finally
		{
			hTok.Dispose();
		}
	}

	[Test]
	public void GetAllUsersProfileDirectoryTest()
	{
		var sb = new StringBuilder(260);
		var sbl = (uint)sb.Capacity;
		Assert.That(GetAllUsersProfileDirectory(sb, ref sbl), ResultIs.Successful);
		Assert.That(sb.Length, Is.GreaterThan(0));
	}

	[Test]
	public void GetAppContainerRegistryLocationTest()
	{
		Assert.That(GetAppContainerRegistryLocation(REGSAM.KEY_ALL_ACCESS, out var hKey), ResultIs.Successful);
		Assert.That(hKey, ResultIs.ValidHandle);
	}
	[Test]
	public void GetAppliedGPOListTest1()
	{
		var guid = new Guid("{35378EAC-683F-11D2-A89A-00C04FBBCFA2}");
		Assert.That(GetAppliedGPOList(0, default, default, guid, out GROUP_POLICY_OBJECT[] gpos), ResultIs.Successful);
		Assert.That(gpos, Is.Not.Empty);
	}

	[Test]
	public void GetAppliedGPOListTest2()
	{
		var guid = new Guid("{35378EAC-683F-11D2-A89A-00C04FBBCFA2}");
		Assert.That(GetAppliedGPOList(0, default, default, guid, out IntPtr ptr), ResultIs.Successful);
		Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(FreeGPOList(ptr), ResultIs.Successful);
	}

	[Test]
	public void GetDefaultUserProfileDirectoryTest()
	{
		var sb = new StringBuilder(260);
		var sbl = (uint)sb.Capacity;
		Assert.That(GetDefaultUserProfileDirectory(sb, ref sbl), ResultIs.Successful);
		Assert.That(sb.Length, Is.GreaterThan(0));
	}

	[Test]
	public void GetGPOListTest()
	{
		using var hToken = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation);
		Assert.That(GetGPOList(hToken, null, null, null, 0, out GROUP_POLICY_OBJECT[] gpos), ResultIs.Successful);
		Assert.That(gpos, Is.Not.Empty);
		gpos.WriteValues();
	}

	[Test]
	public void GetProfilesDirectoryTest()
	{
		var sb = new StringBuilder(260);
		var sbl = (uint)sb.Capacity;
		Assert.That(GetProfilesDirectory(sb, ref sbl), ResultIs.Successful);
		Assert.That(sb.Length, Is.GreaterThan(0));
	}

	[Test]
	public void GetProfileTypeTest()
	{
		Assert.That(GetProfileType(out var type), ResultIs.Successful);
		Assert.That((int)type, Is.GreaterThanOrEqualTo(0));
	}

	[Test]
	public void GetUserProfileDirectoryTest()
	{
		using var hToken = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_QUERY);
		var sb = new StringBuilder(260);
		var sbl = (uint)sb.Capacity;
		Assert.That(GetUserProfileDirectory(hToken, sb, ref sbl), ResultIs.Successful);
		Assert.That(sb.Length, Is.GreaterThan(0));
	}

	[Test]
	public void RefreshPolicyExTest()
	{
		Assert.That(RefreshPolicyEx(false, RefreshPolicyOption.RP_FORCE), ResultIs.Successful);
	}

	[Test]
	public void RefreshPolicyTest()
	{
		Assert.That(RefreshPolicy(false), ResultIs.Successful);
	}

	[Test]
	public void RegisterGPNotificationTest()
	{
		using var hEvt = CreateEvent(null, false, false);
		Assert.That(hEvt, ResultIs.ValidHandle);
		Assert.That(RegisterGPNotification(hEvt, false), ResultIs.Successful);
		Assert.That(UnregisterGPNotification(hEvt), ResultIs.Successful);
	}
}