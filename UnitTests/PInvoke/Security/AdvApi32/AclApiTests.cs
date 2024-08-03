using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class AclApiTests
{
	public const SECURITY_INFORMATION SecInfoAll = SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.SACL_SECURITY_INFORMATION;
	public static readonly string localAdmins = $"{Environment.MachineName}\\Administrators";
	public static readonly SafePSECURITY_DESCRIPTOR pSd;
	public static readonly string userName = $"{Environment.UserDomainName}\\{Environment.UserName}";

	static AclApiTests()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
			pSd = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SecInfoAll);
	}

	[Test]
	public void BuildExplicitAccessWithNameTest()
	{
		EXPLICIT_ACCESS ea = default;
		Assert.That(() => BuildExplicitAccessWithName(out ea, userName, ACCESS_MASK.GENERIC_ALL, ACCESS_MODE.SET_ACCESS, INHERIT_FLAGS.SUB_CONTAINERS_AND_OBJECTS_INHERIT), Throws.Nothing);
		Assert.AreEqual(ea.grfAccessMode, ACCESS_MODE.SET_ACCESS);
		Assert.AreEqual(userName, ea.Trustee.Name);
		ea.WriteValues();
	}

	[Test]
	public void BuildSecurityDescriptorTest()
	{
		SafePSECURITY_DESCRIPTOR? pSd = null;
		Assert.That(() =>
		{
			BuildTrusteeWithName(out var trustee, userName);
			BuildTrusteeWithName(out var grpTrustee, localAdmins);
			BuildExplicitAccessWithName(out var ea, userName, 0x10000000, ACCESS_MODE.SET_ACCESS, INHERIT_FLAGS.SUB_CONTAINERS_AND_OBJECTS_INHERIT);
			BuildSecurityDescriptor(trustee, grpTrustee, 1, new[] { ea }, 0, null, PSECURITY_DESCRIPTOR.NULL, out var sz, out pSd);
		}, Throws.Nothing);
		Assert.That(pSd, Is.Not.Null);
		Assert.That(pSd!.IsInvalid, Is.False);
		pSd.Dispose();
	}

	[Test]
	public void BuildTrusteeWithObjectsAndNameTest()
	{
		Assert.That(() => BuildTrusteeWithObjectsAndName(out var t, default, SE_OBJECT_TYPE.SE_FILE_OBJECT, "", "", "Name"), Throws.Nothing);
	}

	[Test]
	public void BuildTrusteeWithObjectsAndSidTest()
	{
		Assert.That(() => BuildTrusteeWithObjectsAndSid(out var t, default, default, default, PSID.NULL), Throws.Nothing);
	}

	[Test]
	public void BuildTrusteeWithSidTest()
	{
		Assert.That(() => BuildTrusteeWithSid(out var t, PSID.NULL), Throws.Nothing);
	}

	[Test]
	public void GetAuditedPermissionsFromAclTest()
	{
		Assert.That(GetSecurityDescriptorSacl(pSd, out _, out var pSacl, out _), ResultIs.Successful);
		BuildTrusteeWithName(out var trustee, userName);
		Assert.That(GetAuditedPermissionsFromAcl(pSacl, trustee, out var smask, out var fmask), ResultIs.Successful);
		(smask, fmask).WriteValues();
	}

	[Test]
	public void GetExplicitEntriesFromAclTest()
	{
		Assert.That(GetSecurityDescriptorDacl(pSd, out var ok, out var pDacl, out _), ResultIs.Successful);
		Assert.That(GetExplicitEntriesFromAcl(pDacl, out var memList), ResultIs.Successful);
		Assert.That(() => memList?.WriteValues(), Throws.Nothing);
	}

	[Test]
	public void GetNamedSecurityInfoTest()
	{
		using var priv = new ElevPriv("SeSecurityPrivilege");
		Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, out var pOwnSid, out var pGrpSid, out var dacl, out var sacl, out var plsd), ResultIs.Successful);
		Assert.That(() => plsd?.Dispose(), Throws.Nothing);
	}

	[Test]
	public void GetSetSecurityInfoTest()
	{
		using var tmp = new TempFile(Kernel32.FileAccess.FILE_ALL_ACCESS, System.IO.FileShare.Read);
		Assert.That(GetSecurityInfo(tmp.hFile!.DangerousGetHandle(), SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, out var owner, out _, out _, out _, out var plsd), ResultIs.Successful);
		Assert.That(SetSecurityInfo(tmp.hFile.DangerousGetHandle(), SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, owner), ResultIs.Successful);
	}

	[Test]
	public void GetTrusteeFormTest()
	{
		BuildTrusteeWithName(out var trustee, userName);
		Assert.That(GetTrusteeForm(trustee), ResultIs.Value(TRUSTEE_FORM.TRUSTEE_IS_NAME));
	}

	[Test]
	public void GetTrusteeNameTest()
	{
		BuildTrusteeWithName(out var trustee, userName);
		var s = GetTrusteeName(trustee);
		Assert.That(s.ToString(), ResultIs.Value(userName));
	}

	[Test]
	public void GetTrusteeTypeTest()
	{
		BuildTrusteeWithName(out var trustee, userName);
		Assert.That(GetTrusteeType(trustee), ResultIs.Value(TRUSTEE_TYPE.TRUSTEE_IS_UNKNOWN));
	}

	[Test]
	public void LookupSecurityDescriptorPartsTest()
	{
		Assert.That(LookupSecurityDescriptorParts(out var ptOwner, out var ptGrp, out var cnt, out var plEntries, out var acnt, out var plAEntries, pSd), ResultIs.Successful);
		ptOwner.ToStructure<TRUSTEE>().WriteValues();
		ptGrp.ToStructure<TRUSTEE>().WriteValues();
		plEntries.ToArray<EXPLICIT_ACCESS>((int)cnt).WriteValues();
		plAEntries.ToArray<EXPLICIT_ACCESS>((int)acnt).WriteValues();
	}

	[Test]
	public void SetEntriesInAclTest()
	{
		Assert.That(GetSecurityDescriptorDacl(pSd, out _, out var pDacl, out _), ResultIs.Successful);
		BuildExplicitAccessWithName(out var ea, $"{Environment.MachineName}\\Invalid", 0x10000000, ACCESS_MODE.SET_ACCESS, 0);
		EXPLICIT_ACCESS[] entries = [ ea ];
		Assert.That(SetEntriesInAcl((uint)entries.Length, entries, pDacl, out _), ResultIs.FailureCode(Win32Error.ERROR_NONE_MAPPED));
	}

	[Test]
	public void CloneAclTest()
	{
		Assert.That(GetSecurityDescriptorDacl(pSd, out _, out var pDacl, out _), ResultIs.Successful);
		using SafePACL dacl = pDacl;
		using SafePACE ace0 = dacl[0];
		var aceCount = dacl.Count;
		dacl.RemoveAt(0);
		Assert.That(dacl.Count, Is.EqualTo(aceCount - 1));
		using SafePACL dacl2 = dacl.Clone();
		Assert.That(dacl.Equals(dacl2), Is.True);
		dacl2.Insert(0, ace0);
		Assert.That(dacl2.Count, Is.EqualTo(aceCount));
	}

	[Test]
	public void SafePACETest()
	{
		Assert.That(GetSecurityDescriptorDacl(pSd, out _, out var pDacl, out _), ResultIs.Successful);
		using SafePACL dacl = pDacl;
		List<SafePACE> aces = [.. dacl];
		using SafePACE ace = aces[0];

		var c = dacl.Count;
		var l = dacl.BytesInUse;
		Assert.That(dacl.BytesInUse, Is.GreaterThan(0));
		Assert.That(dacl.IndexOf(ace), Is.EqualTo(0));
		Assert.That(dacl.Remove(ace), Is.True);
		Assert.That(dacl.Count, Is.LessThan(c));
		Assert.That(dacl.BytesInUse, Is.LessThan(l));

		dacl.Clear();
		Assert.That(dacl.AceCount, Is.Zero);
		Assert.That(dacl.BytesInUse, Is.LessThan(16));

		aces.ForEach(a => dacl.Add(a));
		Assert.That(dacl.AceCount, Is.EqualTo(aces.Count));
	}

	[Test]
	public void SafePACLTest()
	{
		EXPLICIT_ACCESS[] ea = [
			new(ACCESS_MASK.GENERIC_ALL, ACCESS_MODE.GRANT_ACCESS, 0, Environment.UserName),
			new(ACCESS_MASK.GENERIC_EXECUTE, ACCESS_MODE.DENY_ACCESS, 0, Environment.UserName),
		];
		using SafePACL pacl = new(ea);
		Assert.That(pacl.Count, Is.EqualTo(ea.Length));
		Assert.That(pacl[0].GetAceType(), Is.EqualTo(AceType.AccessDenied));
		var bl = pacl.BytesInUse;

		using SafePACE newAce2 = new(ACE_TYPE.ACCESS_DENIED_ACE_TYPE, ACCESS_MASK.GENERIC_EXECUTE, SafePSID.Current);
		Assert.That(newAce2.CompareTo(pacl[0]), Is.Zero);

		pacl.RemoveAt(1);
		Assert.That(bl, Is.GreaterThan(pacl.BytesInUse));

		using SafePACL pacl2 = pacl.Clone();
		Assert.That(pacl.BytesInUse, Is.EqualTo(pacl2.BytesInUse));
		Assert.That(pacl.BytesInUse, Is.EqualTo(pacl2.Length));
	}

	[Test]
	public void SortAclAcesTest()
	{
		Assert.That(GetSecurityDescriptorDacl(pSd, out _, out var pDacl, out _), ResultIs.Successful);
		using SafePACL dacl = pDacl;
		List<SafePACE> aces = [.. dacl];
		var icnt = aces.Count(a => a.IsInherited);
		Assert.That(aces.Count, Is.EqualTo(dacl.AceCount));

		using SafePACE newAce = new(ACE_TYPE.ACCESS_ALLOWED_ACE_TYPE, ACCESS_MASK.GENERIC_ALL, SafePSID.Current, appData: BitConverter.GetBytes(long.MaxValue));
		aces.Add(newAce);
		using SafePACE newAce2 = new(ACE_TYPE.ACCESS_DENIED_ACE_TYPE, ACCESS_MASK.GENERIC_EXECUTE, SafePSID.Current);
		aces.Add(newAce2);

		aces.Sort(SafePACE.Comparer);
		Assert.That(aces.IndexOf(newAce), Is.GreaterThan(aces.IndexOf(newAce2)));
		Assert.That(aces.IndexOf(newAce), Is.LessThan(aces.Count - icnt));
		Assert.That(aces[^1].IsInherited, Is.True);

		using SafePACL newDacl = new(aces);
		Assert.That(newDacl.IsValidAcl, Is.True);
	}

	[Test]
	public void TreeResetNamedSecurityInfoTest()
	{
		var counter = 0;
		using (new ElevPriv("SeSecurityPrivilege"))
		{
			Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, out var pOwnSid, out var pGrpSid, out var dacl, out var sacl, out var plsd), ResultIs.Successful);
			Assert.That(TreeResetNamedSecurityInfo(TestCaseSources.TempChildDirWhack, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, pOwnSid, pGrpSid, dacl, sacl, false, OnProgress, PROG_INVOKE_SETTING.ProgressInvokeEveryObject), ResultIs.Successful);
		}
		Assert.That(counter, Is.GreaterThan(0));

		void OnProgress(string pObjectName, uint Status, ref PROG_INVOKE_SETTING pInvokeSetting, IntPtr Args, bool SecuritySet) => counter++;
	}

	[Test]
	public void TreeSetNamedSecurityInfoTest()
	{
		var counter = 0;
		using (new ElevPriv("SeSecurityPrivilege"))
		{
			Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, out var pOwnSid, out var pGrpSid, out var dacl, out var sacl, out var plsd), ResultIs.Successful);
			Assert.That(TreeSetNamedSecurityInfo(TestCaseSources.TempChildDirWhack, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, pOwnSid, pGrpSid, dacl, sacl, TREE_SEC_INFO.TREE_SEC_INFO_SET, OnProgress, PROG_INVOKE_SETTING.ProgressInvokeEveryObject), ResultIs.Successful);
		}
		Assert.That(counter, Is.GreaterThan(0));

		void OnProgress(string pObjectName, uint Status, ref PROG_INVOKE_SETTING pInvokeSetting, IntPtr Args, bool SecuritySet) => counter++;
	}
}