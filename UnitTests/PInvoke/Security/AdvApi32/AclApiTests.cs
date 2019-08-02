using NUnit.Framework;
using System;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class AclApiTests
	{
		public const SECURITY_INFORMATION SecInfoAll = SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.SACL_SECURITY_INFORMATION;
		public static readonly string localAdmins = $"{Environment.MachineName}\\Administrators";
		public static readonly SafePSECURITY_DESCRIPTOR pSd;
		public static readonly string userName = $"{Environment.UserDomainName}\\{Environment.UserName}";

		static AclApiTests()
		{
			using (new PrivBlock("SeSecurityPrivilege"))
				pSd = AdvApi32Tests.GetSD(AdvApi32Tests.fn, SecInfoAll);
		}

		[Test]
		public void BuildExplicitAccessWithNameTest()
		{
			EXPLICIT_ACCESS ea = default;
			Assert.That(() => BuildExplicitAccessWithName(out ea, userName, 0x10000000, ACCESS_MODE.SET_ACCESS, INHERIT_FLAGS.SUB_CONTAINERS_AND_OBJECTS_INHERIT), Throws.Nothing);
			Assert.That(ea.grfAccessMode, Is.Not.Zero);
			ea.WriteValues();
		}

		[Test]
		public void BuildSecurityDescriptorTest()
		{
			SafePSECURITY_DESCRIPTOR pSd = null;
			Assert.That(() =>
			{
				BuildTrusteeWithName(out var trustee, userName);
				BuildTrusteeWithName(out var grpTrustee, localAdmins);
				BuildExplicitAccessWithName(out var ea, userName, 0x10000000, ACCESS_MODE.SET_ACCESS, INHERIT_FLAGS.SUB_CONTAINERS_AND_OBJECTS_INHERIT);
				BuildSecurityDescriptor(trustee, grpTrustee, 1, new[] { ea }, 0, null, PSECURITY_DESCRIPTOR.NULL, out var sz, out pSd);
			}, Throws.Nothing);
			Assert.That(pSd, Is.Not.Null);
			Assert.That(pSd.IsInvalid, Is.False);
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
			Assert.That(GetSecurityDescriptorSacl(pSd, out var ok, out var pSacl, out _), ResultIs.Successful);
			BuildTrusteeWithName(out var trustee, userName);
			Assert.That(GetAuditedPermissionsFromAcl(pSacl, trustee, out var smask, out var fmask), ResultIs.Successful);
			(smask, fmask).WriteValues();
		}

		[Test]
		public void GetExplicitEntriesFromAclTest()
		{
			Assert.That(GetSecurityDescriptorDacl(pSd, out var ok, out var pDacl, out _), ResultIs.Successful);
			Assert.That(GetExplicitEntriesFromAcl(pDacl, out var cnt, out var memList), ResultIs.Successful);
			using (memList)
				Assert.That(() => memList.ToArray<EXPLICIT_ACCESS>((int)cnt).WriteValues(), Throws.Nothing);
		}

		[Test]
		public void GetSetSecurityInfoTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_ALL_ACCESS, System.IO.FileShare.Read))
			{
				Assert.That(GetSecurityInfo(tmp.hFile.DangerousGetHandle(), SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, out var owner, out _, out _, out _, out var plsd), ResultIs.Successful);
				Assert.That(SetSecurityInfo(tmp.hFile.DangerousGetHandle(), SE_OBJECT_TYPE.SE_FILE_OBJECT, SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION, owner), ResultIs.Successful);
			}
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
			var entries = new[] { ea };
			Assert.That(SetEntriesInAcl((uint)entries.Length, entries, pDacl, out var pNewAcl), ResultIs.FailureCode(Win32Error.ERROR_NONE_MAPPED));
		}

		[Test]
		public void TreeResetNamedSecurityInfoTest()
		{
			var counter = 0;
			using (new PrivBlock("SeSecurityPrivilege"))
			{
				Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, out var pOwnSid, out var pGrpSid, out var dacl, out var sacl, out var plsd), ResultIs.Successful);
				Assert.That(TreeResetNamedSecurityInfo(@"C:\Temp\Temp\", SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, pOwnSid, pGrpSid, dacl, sacl, false, OnProgress, PROG_INVOKE_SETTING.ProgressInvokeEveryObject), ResultIs.Successful);
			}
			Assert.That(counter, Is.GreaterThan(0));

			void OnProgress(string pObjectName, uint Status, ref PROG_INVOKE_SETTING pInvokeSetting, IntPtr Args, bool SecuritySet) { counter++; }
		}

		[Test]
		public void TreeSetNamedSecurityInfoTest()
		{
			var counter = 0;
			using (new PrivBlock("SeSecurityPrivilege"))
			{
				Assert.That(GetNamedSecurityInfo(AdvApi32Tests.fn, SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, out var pOwnSid, out var pGrpSid, out var dacl, out var sacl, out var plsd), ResultIs.Successful);
				Assert.That(TreeSetNamedSecurityInfo(@"C:\Temp\Temp\", SE_OBJECT_TYPE.SE_FILE_OBJECT, SecInfoAll, pOwnSid, pGrpSid, dacl, sacl, TREE_SEC_INFO.TREE_SEC_INFO_SET, OnProgress, PROG_INVOKE_SETTING.ProgressInvokeEveryObject), ResultIs.Successful);
			}
			Assert.That(counter, Is.GreaterThan(0));

			void OnProgress(string pObjectName, uint Status, ref PROG_INVOKE_SETTING pInvokeSetting, IntPtr Args, bool SecuritySet) { counter++; }
		}
	}
}