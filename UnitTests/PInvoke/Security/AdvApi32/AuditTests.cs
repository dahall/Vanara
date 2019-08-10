using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class AuditTests
	{
		private PrivBlock secPriv;
		static SafePSID pCurSid;
		static readonly Guid regAudit = new Guid("0cce921e-69ae-11d9-bed3-505054503030");
		static readonly Guid objAccAudit = new Guid("6997984a-797a-11d9-bed3-505054503030");

		[Test()]
		public void AuditComputeEffectivePolicyBySidTest()
		{
			Assert.That(AuditComputeEffectivePolicyBySid(CurUserSid, new[] { regAudit }), Is.Not.Empty);
		}

		[Test()]
		public void AuditComputeEffectivePolicyByTokenTest()
		{
			using (var hTok = new SafeHTOKEN(WindowsIdentity.GetCurrent().Token))
				Assert.That(AuditComputeEffectivePolicyByToken(hTok, new[] { regAudit }), Is.Not.Empty);
		}

		[Test]
		public void AuditEnumerateCategoriesTest()
		{
			Assert.That(Categories, Is.Not.Empty);
		}

		[Test]
		public void AuditEnumeratePerUserPolicyTest()
		{
			Assert.That(AuditEnumeratePerUserPolicy(out var h), Is.True);
			Assert.That(h.IsInvalid, Is.False);
		}

		[Test]
		public void AuditEnumerateSubCategoriesTest()
		{
			Assert.That(SubCategories, Is.Not.Empty);
			Assert.That(GetSubCategories(Categories.First()), Is.Not.Empty);
		}

		[Test]
		public void AuditLookupCategoryGuidFromCategoryIdTest()
		{
			Assert.That(AuditLookupCategoryGuidFromCategoryId(POLICY_AUDIT_EVENT_TYPE.AuditCategoryObjectAccess, out var guid), Is.True);
			Assert.That(guid, Is.EqualTo(objAccAudit));
		}

		[Test]
		public void AuditLookupCategoryIdFromCategoryGuidTest()
		{
			Assert.That(AuditLookupCategoryIdFromCategoryGuid(objAccAudit, out var cat), Is.True);
			Assert.That(cat, Is.EqualTo(POLICY_AUDIT_EVENT_TYPE.AuditCategoryObjectAccess));
		}

		[Test]
		public void AuditLookupCategoryNameTest()
		{
			Assert.That(AuditLookupCategoryName(objAccAudit, out var name), Is.True);
			Assert.That(name.ToLower(), Contains.Substring("object"));
		}

		[Test]
		public void AuditLookupSubCategoryNameTest()
		{
			Assert.That(AuditLookupSubCategoryName(regAudit, out var name), Is.True);
			Assert.That(name.ToLower(), Contains.Substring("registry"));
		}

		[Test]
		public void AuditQuerySetGlobalSaclTest()
		{
			var b = AuditQueryGlobalSacl("Key", out var orig);
			if (!b) TestContext.WriteLine($"AuditQueryGlobalSacl:{Win32Error.GetLastError()}");
			Assert.That(b, Is.True);

			var psid = SafePSID.CreateWellKnown(WELL_KNOWN_SID_TYPE.WinWorldSid);
			var explAcc = new EXPLICIT_ACCESS
			{
				grfAccessMode = ACCESS_MODE.SET_AUDIT_SUCCESS,
				grfAccessPermissions = 0x20006 /* KEY_WRITE */,
				grfInheritance = INHERIT_FLAGS.NO_INHERITANCE,
				Trustee = new TRUSTEE(psid, TRUSTEE_TYPE.TRUSTEE_IS_WELL_KNOWN_GROUP)
			};
			SetEntriesInAcl(1, new[] { explAcc }, PACL.NULL, out var newAcl).ThrowIfFailed();
			Assert.That(AuditSetGlobalSacl("Key", newAcl), Is.True);

			Assert.That(AuditSetGlobalSacl("Key", orig), Is.True);
		}

		[Test]
		public void AuditQuerySetPerUserPolicyTest()
		{
			AUDIT_POLICY_INFORMATION[] orig = null;
			Assert.That(() => orig = AuditQueryPerUserPolicy(CurUserSid, new[] { regAudit }).ToArray(), Throws.Nothing);

			var api = new AUDIT_POLICY_INFORMATION { AuditSubCategoryGuid = regAudit, AuditingInformation = AuditCondition.PER_USER_AUDIT_SUCCESS_INCLUDE };
			Assert.That(AuditSetPerUserPolicy(CurUserSid, new[] { api }, 1), Is.True);
			Assert.That(AuditQueryPerUserPolicy(CurUserSid, new[] { regAudit }).ToArray(), Has.Length.EqualTo(1));

			if (orig.Length == 0)
				api.AuditingInformation = AuditCondition.PER_USER_AUDIT_NONE;
			else
				api = orig[0];
			Assert.That(AuditSetPerUserPolicy(CurUserSid, new[] { api }, 1), Is.True);
		}

		[Test]
		public void AuditQuerySetSecurityTest()
		{
			Assert.That(AuditQuerySecurity(SECURITY_INFORMATION.SACL_SECURITY_INFORMATION, out var sd), Is.True);
			Assert.That(sd.IsInvalid, Is.False);
			Assert.That(AuditSetSecurity(SECURITY_INFORMATION.SACL_SECURITY_INFORMATION, sd), Is.True);
		}

		[Test]
		public void AuditQuerySetSystemPolicyTest()
		{
			AUDIT_POLICY_INFORMATION[] api = null;
			Assert.That(api = AuditQuerySystemPolicy(SubCategories.ToArray()).ToArray(), Is.Not.Empty);
			Assert.That(AuditSetSystemPolicy(api, (uint)api.Length), Is.True);
		}

		[OneTimeSetUp]
		public void SetupTests()
		{
			secPriv = new PrivBlock("SeSecurityPrivilege");
		}

		[OneTimeTearDown]
		public void TearDownTests()
		{
			secPriv?.Dispose();
		}

		public static IEnumerable<Guid> Categories => AuditEnumerateCategories();

		public static IEnumerable<PSID> PerUserPolicy => AuditEnumeratePerUserPolicy();

		public static IEnumerable<Guid> SubCategories => AuditEnumerateSubCategories();

		public static IEnumerable<Guid> GetSubCategories(Guid cat) => AuditEnumerateSubCategories(cat);

		public static SafePSID CurUserSid => pCurSid ?? (pCurSid = new SafePSID(WindowsIdentity.GetCurrent().User.GetBytes()));
	}
}