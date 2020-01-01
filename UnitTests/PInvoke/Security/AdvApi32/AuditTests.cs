using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class AuditTests
	{
		private static readonly Guid objAccAudit = new Guid("6997984a-797a-11d9-bed3-505054503030");
		private static readonly Guid regAudit = new Guid("0cce921e-69ae-11d9-bed3-505054503030");
		private static SafePSID pCurSid;
		private ElevPriv secPriv;

		public static IEnumerable<Guid> Categories => AuditEnumerateCategories();


		public static SafePSID CurUserSid
		{
			get
			{
				if (null != pCurSid)
					return pCurSid;


				using var identity = WindowsIdentity.GetCurrent();

				return pCurSid = new SafePSID(identity.User.GetBytes());
			}
		}


		public static IEnumerable<PSID> PerUserPolicy => AuditEnumeratePerUserPolicy();

		public static IEnumerable<Guid> SubCategories => AuditEnumerateSubCategories();

		public static IEnumerable<Guid> GetSubCategories(Guid cat) => AuditEnumerateSubCategories(cat);

		[OneTimeSetUp]
		public void _SetupTests()
		{
			secPriv = new ElevPriv("SeSecurityPrivilege");
		}

		[OneTimeTearDown]
		public void _TearDownTests()
		{
			secPriv?.Dispose();
		}

		[Test()]
		public void AuditComputeEffectivePolicyBySidTest()
		{
			Assert.That(AuditComputeEffectivePolicyBySid(CurUserSid, new[] { regAudit }), Is.Not.Empty);
		}

		[Test()]
		public void AuditComputeEffectivePolicyByTokenTest()
		{
			using var identity = WindowsIdentity.GetCurrent();

			using var hTok = new SafeHTOKEN(identity.Token);

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
			Assert.That(h, ResultIs.ValidHandle);
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
			Assert.That(AuditLookupCategoryGuidFromCategoryId(POLICY_AUDIT_EVENT_TYPE.AuditCategoryObjectAccess, out var guid), ResultIs.Successful);
			Assert.That(guid, Is.EqualTo(objAccAudit));
		}

		[Test]
		public void AuditLookupCategoryIdFromCategoryGuidTest()
		{
			Assert.That(AuditLookupCategoryIdFromCategoryGuid(objAccAudit, out var cat), ResultIs.Successful);
			Assert.That(cat, Is.EqualTo(POLICY_AUDIT_EVENT_TYPE.AuditCategoryObjectAccess));
		}

		[Test]
		public void AuditLookupCategoryNameTest()
		{
			Assert.That(AuditLookupCategoryName(objAccAudit, out var name), ResultIs.Successful);
			Assert.That(name.ToLower(), Contains.Substring("object"));
		}

		[Test]
		public void AuditLookupSubCategoryNameTest()
		{
			Assert.That(AuditLookupSubCategoryName(regAudit, out var name), ResultIs.Successful);
			Assert.That(name.ToLower(), Contains.Substring("registry"));
		}

		[Test]
		public void AuditQuerySetGlobalSaclTest()
		{
			Assert.That(AuditQueryGlobalSacl("Key", out var orig), ResultIs.Successful);

			var explAcc = new EXPLICIT_ACCESS
			{
				grfAccessMode = ACCESS_MODE.SET_AUDIT_SUCCESS,
				grfAccessPermissions = 0x20006 /* KEY_WRITE */,
				grfInheritance = INHERIT_FLAGS.NO_INHERITANCE,
				Trustee = new TRUSTEE(SafePSID.Everyone, TRUSTEE_TYPE.TRUSTEE_IS_WELL_KNOWN_GROUP)
			};
			Assert.That(SetEntriesInAcl(1, new[] { explAcc }, PACL.NULL, out var newAcl), ResultIs.Successful);

			Assert.That(AuditSetGlobalSacl("Key", newAcl), ResultIs.Successful);
			Assert.That(AuditSetGlobalSacl("Key", orig), ResultIs.Successful);
		}

		[Test]
		public void AuditQuerySetPerUserPolicyTest()
		{
			AUDIT_POLICY_INFORMATION[] orig = null;
			Assert.That(() => orig = AuditQueryPerUserPolicy(CurUserSid, new[] { regAudit }).ToArray(), Throws.Nothing);

			var api = new AUDIT_POLICY_INFORMATION { AuditSubCategoryGuid = regAudit, AuditingInformation = AuditCondition.PER_USER_AUDIT_SUCCESS_INCLUDE };
			Assert.That(AuditSetPerUserPolicy(CurUserSid, new[] { api }, 1), ResultIs.Successful);
			Assert.That(AuditQueryPerUserPolicy(CurUserSid, new[] { regAudit }).ToArray(), Has.Length.EqualTo(1));

			if (orig.Length == 0)
				api.AuditingInformation = AuditCondition.PER_USER_AUDIT_NONE;
			else
				api = orig[0];
			Assert.That(AuditSetPerUserPolicy(CurUserSid, new[] { api }, 1), ResultIs.Successful);
		}

		[Test]
		public void AuditQuerySetSecurityTest()
		{
			Assert.That(AuditQuerySecurity(SECURITY_INFORMATION.SACL_SECURITY_INFORMATION, out var sd), ResultIs.Successful);
			Assert.That(sd, ResultIs.ValidHandle);
			Assert.That(AuditSetSecurity(SECURITY_INFORMATION.SACL_SECURITY_INFORMATION, sd), ResultIs.Successful);
		}

		[Test]
		public void AuditQuerySetSystemPolicyTest()
		{
			AUDIT_POLICY_INFORMATION[] api = null;
			Assert.That(api = AuditQuerySystemPolicy(SubCategories.ToArray()).ToArray(), Is.Not.Empty);
			Assert.That(AuditSetSystemPolicy(api, (uint)api.Length), ResultIs.Successful);
		}
	}
}