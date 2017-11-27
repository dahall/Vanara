using NUnit.Framework;
using NUnit.Framework.Constraints;
using static Vanara.PInvoke.NTDSApi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class NTDSApiTests
	{
		/*[TestCase(null, null)]
		[TestCase("americas.cpqcorp.net", "G1W7436.americas.hpqcorp.net")]
		[TestCase("americas.cpqcorp.net", null)]
		[TestCase(null, "G1W7436.americas.hpqcorp.net")]*/
		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.AuthCasesFromFile))]
		public void DsBindTest(bool validUser, bool validCred, string urn, string dn, string dcn, string domain, string un, string pwd, string notes)
		{
			SafeDsHandle dsb = null;
			Assert.That(() => { using (dsb = new SafeDsHandle()) Assert.That(dsb.IsInvalid, Is.False); }, Throws.Nothing);
			Assert.That(() => { using (dsb = new SafeDsHandle(dn, dcn)) Assert.That(dsb.IsInvalid, Is.EqualTo(!validUser)); }, validUser ? (IResolveConstraint)new ThrowsNothingConstraint() : new ThrowsExceptionConstraint());
			Assert.That(() => { using (dsb = new SafeDsHandle(dn, null)) Assert.That(dsb.IsInvalid, Is.EqualTo(!validUser)); }, validUser ? (IResolveConstraint)new ThrowsNothingConstraint() : new ThrowsExceptionConstraint());
			Assert.That(() => { using (dsb = new SafeDsHandle(null, dcn)) Assert.That(dsb.IsInvalid, Is.EqualTo(!validUser)); }, validUser ? (IResolveConstraint)new ThrowsNothingConstraint() : new ThrowsExceptionConstraint());
			Assert.That(dsb?.IsInvalid ?? true);
		}

		/*
		[TestCase(null, null, null, null, null)]
		[TestCase(null, "dahall", "americas.cpqcorp.net", "Itsdav1df", null)]
		[TestCase(null, "david.a.hall@hpe.com", null, "Itsdav1df", null)]
		[TestCase(null, "david.a.hall@hpe.com", "americas.cpqcorp.net", "Itsdav1df", "G1W7436.americas.hpqcorp.net")]
		[TestCase(typeof(UnauthorizedAccessException), "XXXdahall", "americas.cpqcorp.net", "x", null)]
		[TestCase(typeof(UnauthorizedAccessException), "dahall", "americas.cpqcorp.net", "x", null)]
		[TestCase(typeof(UnauthorizedAccessException), "dahal+", "americas.cpqcorp.net", "x", null)]
		[TestCase(typeof(ArgumentException), "dahall", null, null, null)]
		[TestCase(typeof(ArgumentException), "dahall", null, "pwd", null)]
		[TestCase(typeof(ArgumentException), null, "americas.cpqcorp.net", null, null)]*/
		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.AuthCasesFromFile))]
		public void DsBindWithCredTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string un, string pwd, string notes)
		{
			void Meth()
			{
				SafeDsHandle dsb;
				using (var cred = new SafeDsPasswordCredentialsHandle(un, dn, pwd))
				using (dsb = new SafeDsHandle(cred, dn, dc))
					Assert.That(dsb.IsInvalid, Is.False);
				Assert.That(dsb.IsInvalid);
			}
			if (!validUser || !validCred)
				Assert.That(Meth, Throws.Exception);
			else
				Assert.That(Meth, Throws.Nothing);
		}

		/*[TestCase("dahall", DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME, "DS_NAME_ERROR_NOT_FOUND")]
		[TestCase("david.a.hall@hpe.com", DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME, "AMERICAS\\dahall")]
		[TestCase("david.a.hall@hpe.com", DS_NAME_FORMAT.DS_DISPLAY_NAME, "Hall, David (Acct CT)")]
		[TestCase("AMERICAS\\dahall", DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME, "david.a.hall@hpe.com")]
		[TestCase("DAHALL17\\hpadmin", DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME, "DS_NAME_ERROR_NOT_FOUND")]*/
		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.AuthCasesFromFile))]
		public void DsCrackNamesTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string un, string pwd, string notes)
		{
			using (var dsb = new SafeDsHandle())
			{
				var res = DsCrackNames(dsb, new[] {un}, DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME);
				Assert.That(res, Has.Exactly(1).Items);
				//Assert.That(res[0].ToString(), Is.EqualTo(o));
				for (var i = 0; i < res.Length; i++)
					TestContext.WriteLine($"{i}) {res[i]}");
			}
		}
	}
}