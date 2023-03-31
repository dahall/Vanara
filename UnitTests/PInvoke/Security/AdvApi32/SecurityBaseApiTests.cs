using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SecurityBaseApiTests
{
	[Test]
	public void AccessCheckByTypeResultListTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION);
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation);
		var ps = PRIVILEGE_SET.InitializeWithCapacity(100);
		var psSz = ps.SizeInBytes;
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		var otl = new[] { new OBJECT_TYPE_LIST(ObjectTypeListLevel.ACCESS_OBJECT_GUID) };
		var access = new ACCESS_MASK[otl.Length];
		var status = new uint[otl.Length];
		Assert.That(AccessCheckByTypeResultList(pSD, default, hTok, accessMask, otl, (uint)otl.Length, gm, ps, ref psSz, access, status), ResultIs.Successful);
		Assert.That(ps.PrivilegeCount, Is.GreaterThanOrEqualTo(0));
		Assert.That(access[0], Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		Assert.That(status[0], Is.Zero);
	}

	[Test]
	public void AccessCheckByTypeTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION);
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation);
		var ps = PRIVILEGE_SET.InitializeWithCapacity(100);
		var psSz = ps.SizeInBytes;
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		var otl = new[] { new OBJECT_TYPE_LIST(ObjectTypeListLevel.ACCESS_OBJECT_GUID) };
		Assert.That(AccessCheckByType(pSD, default, hTok, accessMask, otl, (uint)otl.Length, gm, ps, ref psSz, out var access, out var status), ResultIs.Successful);
		Assert.That(ps.PrivilegeCount, Is.GreaterThanOrEqualTo(0));
		Assert.That(access, Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		Assert.That(status, Is.True);
	}

	[Test]
	public void AccessCheckTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION);
		using var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_READ).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation);
		var ps = PRIVILEGE_SET.InitializeWithCapacity(10);
		var psSz = ps.SizeInBytes;
		var gm = GENERIC_MAPPING.GenericFileMapping;
		ACCESS_MASK accessMask = ACCESS_MASK.GENERIC_READ;
		MapGenericMask(ref accessMask, gm);
		Assert.That(AccessCheck(pSD, hTok, accessMask, gm, ps, ref psSz, out var access, out var status), ResultIs.Successful);
		Assert.That(ps.PrivilegeCount, Is.GreaterThanOrEqualTo(0));
		Assert.That(access, Is.EqualTo((uint)FileAccess.FILE_GENERIC_READ));
		Assert.That(status, Is.True);
	}

	[Test]
	public void AddAccessAllowedAceExTest()
	{
		using var pACL = GetAcl();
		Assert.That(AddAccessAllowedAceEx(pACL, ACL_REVISION, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessAllowedAceTest()
	{
		using var pACL = GetAcl();
		Assert.That(AddAccessAllowedAce(pACL, ACL_REVISION, (uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessAllowedObjectAceTest()
	{
		var objTypeGuid = IntPtr.Zero;
		var inhObjTypeGuid = IntPtr.Zero;
		using var pACL = GetAcl();
		Assert.That(AddAccessAllowedObjectAce(pACL, ACL_REVISION, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, objTypeGuid, inhObjTypeGuid, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessAllowedObjectAceTest2()
	{
		var objTypeGuid = Guid.NewGuid();
		var inhObjTypeGuid = Guid.NewGuid();
		using var pACL = GetAcl();
		Assert.That(AddAccessAllowedObjectAce(pACL, ACL_REVISION_DS, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, objTypeGuid, inhObjTypeGuid, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessDeniedAceExTest()
	{
		using var pACL = GetAcl();
		Assert.That(AddAccessDeniedAceEx(pACL, ACL_REVISION, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessDeniedAceTest()
	{
		using var pACL = GetAcl();
		Assert.That(AddAccessDeniedAce(pACL, ACL_REVISION, (uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessDeniedObjectAceTest()
	{
		var objTypeGuid = IntPtr.Zero;
		var inhObjTypeGuid = IntPtr.Zero;
		using var pACL = GetAcl();
		Assert.That(AddAccessDeniedObjectAce(pACL, ACL_REVISION, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, objTypeGuid, inhObjTypeGuid, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAccessDeniedObjectAceTest2()
	{
		var objTypeGuid = Guid.NewGuid();
		var inhObjTypeGuid = Guid.NewGuid();
		using var pACL = GetAcl();
		Assert.That(AddAccessDeniedObjectAce(pACL, ACL_REVISION_DS, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, objTypeGuid, inhObjTypeGuid, SafePSID.Everyone), ResultIs.Successful);
	}

	[Test]
	public void AddAuditAccessAceExTest()
	{
		using var pACL = GetAcl();
		Assert.That(AddAuditAccessAceEx(pACL, ACL_REVISION, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone, false, true), ResultIs.Successful);
	}

	[Test]
	public void AddAuditAccessAceTest()
	{
		using var pACL = GetAcl();
		Assert.That(AddAuditAccessAce(pACL, ACL_REVISION, (uint)FileAccess.FILE_GENERIC_READ, SafePSID.Everyone, false, true), ResultIs.Successful);
	}

	[Test]
	public void AddAuditAccessObjectAceTest()
	{
		var objTypeGuid = IntPtr.Zero;
		var inhObjTypeGuid = IntPtr.Zero;
		using var pACL = GetAcl();
		Assert.That(AddAuditAccessObjectAce(pACL, ACL_REVISION, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, objTypeGuid, inhObjTypeGuid, SafePSID.Everyone, false, true), ResultIs.Successful);
	}

	[Test]
	public void AddAuditAccessObjectAceTest2()
	{
		var objTypeGuid = Guid.NewGuid();
		var inhObjTypeGuid = Guid.NewGuid();
		using var pACL = GetAcl();
		Assert.That(AddAuditAccessObjectAce(pACL, ACL_REVISION_DS, AceFlags.None, (uint)FileAccess.FILE_GENERIC_READ, objTypeGuid, inhObjTypeGuid, SafePSID.Everyone, false, true), ResultIs.Successful);
	}

	[Test]
	public void AddGetAceTest()
	{
		Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, out _, out _, out var acl, out _, out var pSD), ResultIs.Successful);
		using (pSD)
		using (var pACL = new SafePACL(acl))
		{
			// The resize action gets all the ACEs from the current ACL and adds them to the newly allocated space.
			pACL.Size *= 2;

			Assert.That(pACL.AceCount, Is.EqualTo(GetAceCount(acl)));
		}

		uint GetAceCount(PACL pACL) => IsValidAcl(pACL) && GetAclInformation(pACL, out ACL_SIZE_INFORMATION si) ? si.AceCount : 0;
	}

	[Test]
	public void AddMandatoryAceTest()
	{
		using var mSid = SafePSID.Init(KnownSIDAuthority.SECURITY_MANDATORY_LABEL_AUTHORITY, 1, KnownSIDRelativeID.SECURITY_MANDATORY_LOW_RID);
		using var pACL = GetAcl();
		Assert.That(AddMandatoryAce(pACL, ACL_REVISION_DS, AceFlags.None, SYSTEM_MANDATORY_LABEL.SYSTEM_MANDATORY_LABEL_NO_READ_UP, mSid), ResultIs.Successful);
	}

	[Test]
	public void AddResourceAttributeAceTest()
	{
		using var pNewSacl = GetAcl();
		using (var capId = new SafePSID("S-1-17-22"))
			Assert.That(AddScopedPolicyIDAce(pNewSacl, ACL_REVISION, 0, 0, capId), ResultIs.Successful);

		var attrValues = new[] { 12L, 32L };
		using var pattrValues = SafeHGlobalHandle.CreateFromList(attrValues);
		var csattr = new CLAIM_SECURITY_ATTRIBUTE_V1
		{
			Name = "Int",
			ValueType = CLAIM_SECURITY_ATTRIBUTE_TYPE.CLAIM_SECURITY_ATTRIBUTE_TYPE_INT64,
			ValueCount = (uint)attrValues.Length,
			Values = new CLAIM_SECURITY_ATTRIBUTE_V1.VALUESUNION { pInt64 = pattrValues }
		};
		var attr = new[] { csattr };
		using var pattr = SafeHGlobalHandle.CreateFromList(attr);
		var csi = CLAIM_SECURITY_ATTRIBUTES_INFORMATION.Default;
		csi.AttributeCount = (uint)attr.Length;
		csi.Attribute.pAttributeV1 = pattr;
		var len = 0U;
		Assert.That(AddResourceAttributeAce(pNewSacl, ACL_REVISION, 0, 0, SafePSID.Everyone, csi, ref len), ResultIs.Successful);
	}

	[Test]
	public void AdjustTokenGroupsTest()
	{
		using var t = SafeHTOKEN.FromThread(SafeHTHREAD.Current, TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_ADJUST_GROUPS | TokenAccess.TOKEN_QUERY);
		var tg = new TOKEN_GROUPS(SafePSID.Everyone);
		Assert.That(AdjustTokenGroups(t, tg, out var old), ResultIs.Successful);
		Assert.That((int)old.GroupCount, Is.EqualTo(old.Groups.Length));
	}

	[Test]
	public void AdjustTokenPrivilegesTest()
	{
		using var t = SafeHTOKEN.FromThread(SafeHTHREAD.Current, TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY);
		Assert.That(LookupPrivilegeValue(null, "SeShutdownPrivilege", out var luid));
		var ptp = new TOKEN_PRIVILEGES(luid, PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
		Assert.That(AdjustTokenPrivileges(t, false, ptp, out var old), ResultIs.Successful);
		Assert.That((int)old.PrivilegeCount, Is.EqualTo(old.Privileges.Length));
	}

	[Test]
	public void AllocateLocallyUniqueIdTest()
	{
		Assert.That(AllocateLocallyUniqueId(out var luid));
		TestContext.WriteLine($"{luid.LowPart:X} {luid.HighPart:X}");
		Assert.That(luid.LowPart, Is.Not.Zero);
	}

	[Test]
	public void AreAccessesGrantedTest()
	{
		Assert.That(AreAllAccessesGranted((uint)FileAccess.FILE_ALL_ACCESS, (uint)FileAccess.FILE_READ_DATA), Is.True);
		Assert.That(AreAnyAccessesGranted((uint)FileAccess.FILE_READ_DATA, (uint)FileAccess.FILE_ALL_ACCESS), Is.True);
	}

	[Test]
	public void CheckTokenCapabilityTest() => Assert.That(CheckTokenCapability(HTOKEN.NULL, SafePSID.CreateCapability(KnownSIDCapability.SECURITY_CAPABILITY_DOCUMENTS_LIBRARY), out var has), ResultIs.Successful);

	[Test]
	public void CheckTokenMembershipExTest() => Assert.That(CheckTokenMembershipEx(default, SafePSID.Current, CTMF.CTMF_INCLUDE_APPCONTAINER, out var mbr), ResultIs.Successful);

	[Test]
	public void CheckTokenMembershipTest() => Assert.That(CheckTokenMembership(default, SafePSID.Current, out var mbr), ResultIs.Successful);

	[Test]
	public void ConvertToAutoInheritPrivateObjectSecurityTest()
	{
		const SECURITY_INFORMATION si = SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION;
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var pParentSD = AdvApi32Tests.GetSD(System.IO.Path.GetDirectoryName(AdvApi32Tests.fn), si))
		using (var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, si))
		{
			TestContext.WriteLine(ConvertSecurityDescriptorToStringSecurityDescriptor(pSD, si));
			Assert.That(ConvertToAutoInheritPrivateObjectSecurity(pParentSD, pSD, out var pos, IntPtr.Zero, false, GENERIC_MAPPING.GenericFileMapping), ResultIs.Successful);
			TestContext.Write(ConvertSecurityDescriptorToStringSecurityDescriptor(pos, si));
		}
	}

	[Test]
	public void CreateGetSetPrivateObjectSecurityExTest()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var pParentSD = AdvApi32Tests.GetSD(System.IO.Path.GetDirectoryName(AdvApi32Tests.fn)))
		using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation))
		{
			Assert.That(CreatePrivateObjectSecurityEx(pParentSD, default, out var spod, IntPtr.Zero, false, SEF.SEF_MACL_NO_READ_UP, hTok, GENERIC_MAPPING.GenericFileMapping), ResultIs.Successful);
			using (spod)
			{
				TestContext.Write(ConvertSecurityDescriptorToStringSecurityDescriptor(spod, AdvApi32Tests.AllSI));

				using var pSD = new SafePSECURITY_DESCRIPTOR(4096);
				Assert.That(GetPrivateObjectSecurity(spod, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, pSD, pSD.Size, out _), ResultIs.Successful);
				var hspod = (PSECURITY_DESCRIPTOR)spod;
				Assert.That(SetPrivateObjectSecurity(SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, pSD, ref spod.DangerousGetRefHandle(), GENERIC_MAPPING.GenericFileMapping, hTok), ResultIs.Successful);
				TestContext.WriteLine($"Before: {hspod.DangerousGetHandle().ToInt32().ToString("X")}, After: {spod.DangerousGetHandle().ToInt32().ToString("X")}");
			}
		}
	}

	[Test]
	public void CreatePrivateObjectSecurityTest()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var pParentSD = AdvApi32Tests.GetSD(System.IO.Path.GetDirectoryName(AdvApi32Tests.fn)))
		using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation))
		{
			Assert.That(CreatePrivateObjectSecurity(pParentSD, default, out var spod, false, hTok, GENERIC_MAPPING.GenericFileMapping), ResultIs.Successful);
			TestContext.Write(ConvertSecurityDescriptorToStringSecurityDescriptor(spod, AdvApi32Tests.AllSI));
		}
	}

	[Test]
	public void CreatePrivateObjectSecurityWithMultipleInheritanceTest()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var pParentSD = AdvApi32Tests.GetSD(System.IO.Path.GetDirectoryName(AdvApi32Tests.fn)))
		using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY).Duplicate(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation))
		{
			Assert.That(CreatePrivateObjectSecurityWithMultipleInheritance(pParentSD, default, out var spod, null, 0, false, SEF.SEF_MACL_NO_READ_UP, hTok, GENERIC_MAPPING.GenericFileMapping), ResultIs.Successful);
			TestContext.Write(ConvertSecurityDescriptorToStringSecurityDescriptor(spod, AdvApi32Tests.AllSI));
		}
	}

	[Test]
	public void CreateRestrictedTokenTest()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS))
		{
			Assert.That(IsTokenRestricted(hTok), Is.False);
			Assert.That(CreateRestrictedToken(hTok, RestrictedPrivilegeOptions.DISABLE_MAX_PRIVILEGE | RestrictedPrivilegeOptions.LUA_TOKEN, NewTokenHandle: out var hNewTok), ResultIs.Successful);
			hNewTok.Dispose();
		}
	}

	[Test]
	public void CveEventWriteTest() => Assert.That(CveEventWrite("CVE-2016-7654321"), ResultIs.Successful);

	[Test]
	public void DeleteAceTest()
	{
		Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, out _, out _, out var acl, out _, out var pSD), ResultIs.Successful);
		using (pSD)
		{
			Assert.That(DeleteAce(acl, 0), ResultIs.Successful);
		}
	}

	[Test]
	public void DeriveCapabilitySidsFromNameTest()
	{
		Assert.That(DeriveCapabilitySidsFromName("internetClient", out var capGrpSids, out var nCapGrpSids, out var capSids, out var nCapSids), ResultIs.Successful);
		Assert.That(() =>
		{
			capGrpSids.Count = nCapGrpSids;
			capSids.Count = nCapSids;
		}, Throws.Nothing);
		Assert.That(capGrpSids.Count, Is.EqualTo(nCapGrpSids));
		Assert.That(capGrpSids, Is.Not.Empty);
		Assert.That(capSids, Is.Not.Empty);
		TestContext.WriteLine(string.Join("\n", capGrpSids.Select(s => s.ToString("P"))));
		TestContext.WriteLine(string.Join("\n", capSids.Select(s => s.ToString("P"))));
	}

	[Test]
	public void DuplicateTokenTest()
	{
		using var pval = SafeHTOKEN.FromProcess(Process.GetCurrentProcess());
		Assert.That(pval.IsInvalid, Is.False);
		Assert.That(DuplicateToken(pval, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, out var dtok));
		Assert.That(dtok.IsInvalid, Is.False);
		dtok.Close();
	}

	[Test]
	public void DuplicateTokenExTest()
	{
		using var pval = SafeHTOKEN.FromProcess(Process.GetCurrentProcess());
		Assert.That(pval.IsInvalid, Is.False);
		Assert.That(DuplicateTokenEx(pval, TokenAccess.TOKEN_IMPERSONATE, null, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenImpersonation, out var dtok));
		Assert.That(dtok.IsInvalid, Is.False);
		dtok.Close();
	}

	[Test]
	public void FindFirstFreeAceTest()
	{
		Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, out _, out _, out var acl, out _, out var pSD), ResultIs.Successful);
		using (pSD)
			Assert.That(FindFirstFreeAce(acl, out var pAce), ResultIs.Successful);
	}

	[Test, TestCaseSource(typeof(TestCaseSources), nameof(TestCaseSources.AuthCasesFromFile))]
	public void GetAceTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string username, string password, string notes)
	{
		var fun = $"{domain}\\{username}";

		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn);
		Assert.That(GetSecurityDescriptorDacl(pSD, out var daclPresent, out var pAcl, out var defaulted), ResultIs.Successful);
		Assert.That(daclPresent, Is.True);
		Assert.That(pAcl, Is.Not.EqualTo(IntPtr.Zero));
		var hardAcl = ((IntPtr)pAcl).ToStructure<ACL>();
		Assert.That(GetAclInformation(pAcl, out ACL_REVISION_INFORMATION ari, (uint)Marshal.SizeOf(typeof(ACL_REVISION_INFORMATION)), ACL_INFORMATION_CLASS.AclRevisionInformation), ResultIs.Successful);
		Assert.That(ari.AclRevision, Is.EqualTo(hardAcl.AclRevision));
		Assert.That(GetAclInformation(pAcl, out ACL_SIZE_INFORMATION asi, (uint)Marshal.SizeOf(typeof(ACL_SIZE_INFORMATION)), ACL_INFORMATION_CLASS.AclSizeInformation), ResultIs.Successful);
		Assert.That(asi.AceCount, Is.EqualTo(hardAcl.AceCount));
		for (var i = 0U; i < asi.AceCount; i++)
		{
			Assert.That(GetAce(pAcl, i, out var pAce), ResultIs.Successful);

			var accountSize = 1024;
			var domainSize = 1024;
			var outuser = new StringBuilder(accountSize, accountSize);
			var outdomain = new StringBuilder(domainSize, domainSize);
			Assert.That(LookupAccountSid(null, pAce.GetSid(), outuser, ref accountSize, outdomain, ref domainSize, out _), ResultIs.Successful);
			TestContext.WriteLine($"Ace{i}: {pAce.GetHeader().AceType}={outdomain}\\{outuser}; {pAce.GetMask()}");
		}

		BuildTrusteeWithName(out var pTrustee, fun);
		Assert.That((uint)GetEffectiveRightsFromAcl(pAcl, pTrustee, out var accessRights), Is.EqualTo(Win32Error.ERROR_NONE_MAPPED).Or.Zero);
		var ifArray = new SafeInheritedFromArray(hardAcl.AceCount);
		Assert.That(GetInheritanceSource(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, false, null,
			0, pAcl, IntPtr.Zero, GENERIC_MAPPING.GenericFileMapping, ifArray), ResultIs.Successful);
		TestContext.WriteLine($"{hardAcl.AceCount}: {string.Join("; ", ifArray.Results.Select(i => i.ToString()))}");
		Assert.That(() => ifArray.Dispose(), Throws.Nothing);
	}

	[Test]
	public void GetSetKernelObjectSecurityTest()
	{
		HANDLE hProc = (IntPtr)GetCurrentProcess();
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var pSD = new SafePSECURITY_DESCRIPTOR(2048))
		{
			// Get self-relative SD with DACL
			Assert.That(GetKernelObjectSecurity(hProc, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, pSD, pSD.Size, out var req), ResultIs.Successful);

			// Get the DACL and insert a new ACE
			Assert.That(GetSecurityDescriptorDacl(pSD, out var present, out var pDacl, out var def), ResultIs.Successful);
			using var pSafeDacl = new SafePACL(pDacl);
			pSafeDacl.Size += GetRequiredAceSize<ACCESS_DENIED_ACE>(SafePSID.Everyone, out _);
			Assert.That(InsertAccessDeniedAce(pSafeDacl, ACL_REVISION, 0, AceFlags.None, (uint)ProcessAccess.PROCESS_ALL_ACCESS, SafePSID.Everyone), ResultIs.Successful);

			// Since SD is self-relative, convert to absolute
			var pAbsSD = pSD.MakeAbsolute();

			// Set the DACL on the new absolute SD
			Assert.That(SetSecurityDescriptorDacl(pAbsSD.pAbsoluteSecurityDescriptor, true, pSafeDacl, def), ResultIs.Successful);

			// Try to apply updated absolute SD to kernel object
			Assert.That(SetKernelObjectSecurity(hProc, SECURITY_INFORMATION.DACL_SECURITY_INFORMATION, pAbsSD.pAbsoluteSecurityDescriptor), ResultIs.Successful);
		}
	}

	[Test]
	public void GetSecurityDescriptorControlTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn);
		Assert.That(GetSecurityDescriptorControl(pSD, out var ctrl, out var rev), ResultIs.Successful);
		Assert.That(ctrl.IsFlagSet(SECURITY_DESCRIPTOR_CONTROL.SE_DACL_PRESENT));
		Assert.That(rev == SDDL_REVISION.SDDL_REVISION_1);
	}

	[Test]
	public void GetSecurityDescriptorGroupTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION);
		Assert.That(GetSecurityDescriptorGroup(pSD, out var pGroup, out var def), ResultIs.Successful);
		Assert.That(pGroup.IsValidSid());
	}

	[Test]
	public void GetSecurityDescriptorLengthTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn);
		Assert.That(GetSecurityDescriptorLength(pSD), ResultIs.Not.Value(0U));
	}

	[Test]
	public void GetSecurityDescriptorOwnerTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION);
		Assert.That(GetSecurityDescriptorOwner(pSD, out var pOwner, out var def), ResultIs.Successful);
		Assert.That(pOwner.IsValidSid());
	}

	[Test]
	public void GetSecurityDescriptorRMControlTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn);
		Assert.That(GetSecurityDescriptorRMControl(pSD, out var ctrl), ResultIs.Successful);
	}

	[Test]
	public void GetSecurityDescriptorSaclTest()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
		using (var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SECURITY_INFORMATION.SACL_SECURITY_INFORMATION))
		{
			Assert.That(GetSecurityDescriptorSacl(pSD, out var present, out var pSacl, out var def), ResultIs.Successful);
			Assert.That(present);
			Assert.That(!pSacl.IsNull);
		}
	}

	[Test]
	public void GetSetTokenInformationTest()
	{
		using (var t = SafeHTOKEN.FromProcess(Process.GetCurrentProcess(), TokenAccess.TOKEN_QUERY))
		{
			Assert.That(t, Is.Not.Null);

			var p = t.GetInfo<TOKEN_PRIVILEGES>();
			Assert.That(p, Is.Not.Null);
			Assert.That(p.PrivilegeCount, Is.GreaterThan(0));
			TestContext.WriteLine("Privs: " + string.Join("; ", p.Privileges.Select(i => i.ToString())));

			using var hMem = new SafeAnysizeStruct<TOKEN_PRIVILEGES>(2048);
			Assert.That(GetTokenInformation(t, TOKEN_INFORMATION_CLASS.TokenPrivileges, hMem, hMem.Size, out var sz), ResultIs.Successful);
			Assert.That(hMem.Value.PrivilegeCount, Is.EqualTo(p.PrivilegeCount));
			Assert.That(p.Privileges, Is.EquivalentTo(hMem.Value.Privileges));

			var g = t.GetInfo(TOKEN_INFORMATION_CLASS.TokenGroups);
			Assert.That(g, Is.Not.Null);
			var tg = g.DangerousGetHandle().Convert<TOKEN_GROUPS>(g.Size);
			Assert.That(tg.GroupCount, Is.GreaterThan(0));
			TestContext.WriteLine("Grps: " + string.Join("; ", tg.Groups.Select(i => i.ToString())));
		}

		using (new ElevPriv("SeSecurityPrivilege"))
		using (var t = SafeHTOKEN.FromThread(GetCurrentThread(), TokenAccess.TOKEN_ALL_ACCESS))
		using (var mem = new SafeHGlobalHandle(8192))
		{
			var getmi = typeof(AdvApi32).GetMethod("GetTokenInformation", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
			Assert.That(getmi, Is.Not.Null);
			var setmi = typeof(AdvApi32).GetMethod("SetTokenInformation", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, null,
				new[] { typeof(HTOKEN), typeof(TOKEN_INFORMATION_CLASS), typeof(IntPtr), typeof(uint) }, null);
			Assert.That(setmi, Is.Not.Null);
			foreach (TOKEN_INFORMATION_CLASS cls in Enum.GetValues(typeof(TOKEN_INFORMATION_CLASS)))
			{
				TestContext.WriteLine(cls);
				uint sz = 0;

				var gettype = CorrespondingTypeAttribute.GetCorrespondingTypes(cls, CorrespondingAction.Get).FirstOrDefault();
				if (gettype != null)
				{
					var insz = (int)mem.Size;
					if (cls == TOKEN_INFORMATION_CLASS.TokenLinkedToken || cls == TOKEN_INFORMATION_CLASS.TokenElevation)
						insz = 4;
					var param = new object[] { (HTOKEN)t, cls, (IntPtr)mem, insz, null };
					var res = getmi.Invoke(null, param);
					if ((bool)res)
					{
						sz = (uint)(int)param[4];
						TestContext.Write($">> Get =");
						try
						{
							((IntPtr)mem).Convert(mem.Size, gettype).WriteValues();
						}
						catch
						{
							TestContext.WriteLine($"Unable to convert {gettype.Name}");
						}
					}
					else
						TestContext.WriteLine($">> Get Error = {Win32Error.GetLastError()}");
				}

				var settype = CorrespondingTypeAttribute.GetCorrespondingTypes(cls, CorrespondingAction.Set).FirstOrDefault();
				if (settype != null)
				{
					if (sz == 0)
					{
						try
						{
							var inst = Activator.CreateInstance(settype);
							mem.Write(inst);
						}
						catch
						{
							TestContext.WriteLine($">> Set Unable to get default {settype.Name}");
						}
						sz = (uint)Marshal.SizeOf(settype);
					}
					if (sz == 0) continue;
					var param = new object[] { (HTOKEN)t, cls, (IntPtr)mem, sz };

					var res = setmi.Invoke(null, param);
					if ((bool)res)
						TestContext.WriteLine($">> Set = OK");
					else
						TestContext.WriteLine($">> Set Error = {Win32Error.GetLastError()}");
				}
			}

			var id = t.GetInfo<uint>(TOKEN_INFORMATION_CLASS.TokenSessionId);
			Assert.That(id, Is.Not.Zero);
			TestContext.WriteLine($"SessId: {id}");

			var ve = t.GetInfo<uint>(TOKEN_INFORMATION_CLASS.TokenVirtualizationEnabled);
			Assert.That(ve, Is.Zero);
			TestContext.WriteLine($"VirtEnable: {ve}");

			var et = t.GetInfo<TOKEN_ELEVATION_TYPE>(TOKEN_INFORMATION_CLASS.TokenElevationType);
			Assert.That(et, Is.Not.Zero);
			TestContext.WriteLine($"ElevType: {et}");

			var e = t.GetInfo<TOKEN_ELEVATION>(TOKEN_INFORMATION_CLASS.TokenElevation);
			Assert.That(e, Is.Not.Zero);
			TestContext.WriteLine($"Elev: {e.TokenIsElevated}");
		}
	}

	[Test]
	public void ImpersonateAnonymousTokenTest()
	{
		Assert.That(ImpersonateAnonymousToken(GetCurrentThread()), ResultIs.Successful);
		Assert.That(RevertToSelf(), ResultIs.Successful);
	}

	[Test]
	public void ImpersonateLoggedOnUserTest()
	{
		using (var t = SafeHTOKEN.FromProcess(Process.GetCurrentProcess(), TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_IMPERSONATE))
			Assert.That(ImpersonateLoggedOnUser(t), ResultIs.Successful);
		Assert.That(RevertToSelf(), ResultIs.Successful);
	}

	[Test]
	public void ImpersonateSelfTest()
	{
		Assert.That(ImpersonateSelf(SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation), ResultIs.Successful);
		Assert.That(RevertToSelf(), ResultIs.Successful);
	}

	[Test]
	public void InitializeSecurityDescriptorTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(128);
		Assert.That(InitializeSecurityDescriptor(pSD, SECURITY_DESCRIPTOR_REVISION), ResultIs.Successful);
		Assert.That(pSD.IsValidSecurityDescriptor, Is.True);
	}

	[Test]
	public void MakeAbsoluteSelfRelativeSDTest()
	{
		using var pSD = AdvApi32Tests.GetSD(AdvApi32Tests.fn);
		(SafePSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor, SafePACL pDacl, SafePACL pSacl, SafePSID pOwner, SafePSID pPrimaryGroup) ret = default;
		Assert.That(() => ret = pSD.MakeAbsolute(), Throws.Nothing);
		try
		{
			SafePSECURITY_DESCRIPTOR newSD = null;
			Assert.That(() => newSD = new SafePSECURITY_DESCRIPTOR(ret.pAbsoluteSecurityDescriptor, false), Throws.Exception);
			Assert.That(() => newSD = new SafePSECURITY_DESCRIPTOR(ret.pAbsoluteSecurityDescriptor, true), Throws.Nothing);
			newSD.Dispose();
		}
		finally
		{
			ret.pAbsoluteSecurityDescriptor.Dispose();
			ret.pDacl.Dispose();
			ret.pSacl.Dispose();
			ret.pOwner.Dispose();
			ret.pPrimaryGroup.Dispose();
		}
	}

	[Test]
	public void PrivilegeCheckTest()
	{
		using var t = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_QUERY);
		Assert.That(LookupPrivilegeValue(null, "SeDebugPrivilege", out var luid));
		var ps = new PRIVILEGE_SET(PrivilegeSetControl.PRIVILEGE_SET_ALL_NECESSARY, luid, PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
		Assert.That(PrivilegeCheck(t, ps, out var res));
		Assert.That((uint)ps.Privilege[0].Attributes, Is.Not.Zero);
		TestContext.WriteLine($"Has {luid}={res}, {ps.Privilege[0].Attributes}");

		Assert.That(LookupPrivilegeValue(null, "SeChangeNotifyPrivilege", out luid));
		ps = new PRIVILEGE_SET(PrivilegeSetControl.PRIVILEGE_SET_ALL_NECESSARY, new[] { new LUID_AND_ATTRIBUTES(luid, PrivilegeAttributes.SE_PRIVILEGE_ENABLED_BY_DEFAULT), new LUID_AND_ATTRIBUTES(luid, PrivilegeAttributes.SE_PRIVILEGE_ENABLED) });
		Assert.That(PrivilegeCheck(t, ps, out res));
		Assert.That((uint)ps.Privilege[0].Attributes, Is.Not.Zero);
		TestContext.WriteLine($"Has {luid}={res}, {ps.Privilege[0].Attributes}/{ps.Privilege[1].Attributes}");

		Assert.That(LookupPrivilegeValue(null, "SeShutdownPrivilege", out luid));
		ps = new PRIVILEGE_SET(PrivilegeSetControl.PRIVILEGE_SET_ALL_NECESSARY, luid, PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
		Assert.That(PrivilegeCheck(t, ps, out res));
		Assert.That((uint)ps.Privilege[0].Attributes, Is.Not.Zero);
		TestContext.WriteLine($"Has {luid}={res}, {ps.Privilege[0].Attributes}");
	}

	[Test]
	public void QuerySecurityAccessMaskTest()
	{
		QuerySecurityAccessMask(SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, out var oMask);
		Assert.That((uint)oMask, Is.Not.Zero);
		QuerySecurityAccessMask(SECURITY_INFORMATION.SACL_SECURITY_INFORMATION, out var sMask);
		Assert.That((uint)sMask, Is.Not.Zero);
		(oMask, sMask).WriteValues();
		Assert.That(oMask, Is.Not.EqualTo(sMask));
	}

	[Test]
	public void SetAclInformationTest()
	{
		using var pAcl = GetAcl();
		Assert.That(SetAclInformation(pAcl, new ACL_REVISION_INFORMATION { AclRevision = ACL_REVISION }), ResultIs.Successful);
	}

	[Test]
	public void SetSecurityAccessMaskTest()
	{
		SetSecurityAccessMask(SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, out var ownMask);
		SetSecurityAccessMask(SECURITY_INFORMATION.SACL_SECURITY_INFORMATION, out var saclMask);
		Assert.That((uint)saclMask, Is.Not.Zero.And.Not.EqualTo((uint)ownMask));
	}

	[Test]
	public void SetSecurityDescriptorControlTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(48);
		Assert.That(SetSecurityDescriptorControl(pSD, SECURITY_DESCRIPTOR_CONTROL.SE_DACL_AUTO_INHERIT_REQ, 0), ResultIs.Successful);
	}

	[Test]
	public void SetSecurityDescriptorDaclTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(256);
		using var pAcl = new SafePACL(128);
		Assert.That(AddAccessAllowedAce(pAcl, ACL_REVISION, ACCESS_MASK.GENERIC_ALL, SafePSID.Everyone), ResultIs.Successful);
		Assert.That(SetSecurityDescriptorDacl(pSD, true, pAcl, false), ResultIs.Successful);
	}

	[Test]
	public void SetSecurityDescriptorGroupTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(256);
		Assert.That(SetSecurityDescriptorGroup(pSD, SafePSID.Everyone, false), ResultIs.Successful);
	}

	[Test]
	public void SetSecurityDescriptorSaclTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(256);
		using var pAcl = new SafePACL(128);
		Assert.That(AddAuditAccessAce(pAcl, ACL_REVISION, ACCESS_MASK.GENERIC_ALL, SafePSID.Everyone, false, false), ResultIs.Successful);
		Assert.That(SetSecurityDescriptorSacl(pSD, true, pAcl, false), ResultIs.Successful);
	}

	[Test]
	public void SetSecurityDescriptorOwnerTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(256);
		Assert.That(SetSecurityDescriptorOwner(pSD, SafePSID.Everyone, false), ResultIs.Successful);
	}

	[Test]
	public void SetSecurityDescriptorRMControlTest()
	{
		using var pSD = new SafePSECURITY_DESCRIPTOR(256);
		Assert.That(SetSecurityDescriptorRMControl(pSD, 0), ResultIs.Successful);
	}

	private SafePACL GetAcl() => new SafePACL(256);
}