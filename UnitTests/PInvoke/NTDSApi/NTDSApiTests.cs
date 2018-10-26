using NUnit.Framework;
using System.Linq;
using System.Text;
using static Vanara.PInvoke.NTDSApi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class NTDSApiTests
	{
		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.AuthCasesFromFile))]
		public void DsBindTest(bool validUser, bool validCred, string urn, string dn, string dcn, string domain, string un, string pwd, string notes)
		{
			Assert.That(DsBind(dn, dcn, out var dsb).Succeeded && !dsb.IsInvalid, Is.EqualTo(validUser && validCred));
			Assert.That(DsBind(dn, null, out var dsb1).Succeeded && !dsb1.IsInvalid, Is.EqualTo(validUser && validCred));
			Assert.That(DsBind(null, dcn, out var dsb2).Succeeded && !dsb2.IsInvalid, Is.EqualTo(validUser && validCred));
		}

		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.AuthCasesFromFile))]
		public void DsBindWithCredTest(bool validUser, bool validCred, string urn, string dn, string dcn, string domain, string un, string pwd, string notes)
		{
			void Meth()
			{
				DsMakePasswordCredentials(un, dn, pwd, out var cred).ThrowIfFailed();
				DsBindWithCred(dcn, dn, cred, out var hds).ThrowIfFailed();
			}
			if (!validUser || !validCred)
				Assert.That(Meth, Throws.Exception);
			else
				Assert.That(Meth, Throws.Nothing);
		}

		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.AuthCasesFromFile))]
		public void DsCrackNamesTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string un, string pwd, string notes)
		{
			DsBind(null, null, out var dsb).ThrowIfFailed();
			var res = DsCrackNames(dsb, new[] {un}, DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME);
			Assert.That(res, Has.Exactly(1).Items);
			for (var i = 0; i < res.Length; i++)
				TestContext.WriteLine($"{i}) {res[i]}");
		}

		[Test]
		public void DsSpnTest()
		{
			const string spn = @"MyService/host1.contoso.com:80/CN=Server1,OU=Servers,DC=Contoso,DC=com";
			uint szSC = 1, szSN = 1, szIN = 1, szSPN = 0;
			var tmp = new StringBuilder(1);
			var ret = DsCrackSpn(spn, ref szSC, tmp, ref szSN, tmp, ref szIN, tmp, out var port);
			StringBuilder sSC = new StringBuilder((int)szSC), sSN = new StringBuilder((int)szSN), sIN = new StringBuilder((int)szIN);
			ret = DsCrackSpn(spn, ref szSC, sSC, ref szSN, sSN, ref szIN, sIN, out port);
			ret.ThrowIfFailed();

			ret = DsMakeSpn(sSC.ToString(), sSN.ToString(), sIN.ToString(), port, null, ref szSPN, null);
			var sSPN = new StringBuilder((int)szSPN);
			ret = DsMakeSpn(sSC.ToString(), sSN.ToString(), sIN.ToString(), port, null, ref szSPN, sSPN);
			ret.ThrowIfFailed();
			Assert.That(sSPN.ToString(), Is.EqualTo(spn));

			uint uSpn = 1;
			ret = DsGetSpn(DS_SPN_NAME_TYPE.DS_SPN_NB_HOST, "cxhndl", null, 0, 0, null, null, ref uSpn, out var hA);
			ret.ThrowIfFailed();
			DsFreeSpnArray(uSpn, ref hA);
		}

		[Test]
		public void DsGetDCInfoTest()
		{
			DsBind(null, null, out var dsb).ThrowIfFailed();
			var ret = DsGetDomainControllerInfo(dsb, "americas", 1, out var u1, out var i1);
			ret.ThrowIfFailed();
			var s1 = i1.ToIEnum<DS_DOMAIN_CONTROLLER_INFO_1>(u1).ToArray();
			Assert.That(s1[0].fDsEnabled);
			DsFreeDomainControllerInfo(1, u1, i1);
		}

		[Test]
		public void DsGetRdnTest()
		{
			var ret = DsGetRdnW("dc=corp,dc=fabrikam,dc=com", out var dn, out var key, out var val);
			ret.ThrowIfFailed();
			Assert.That(dn, Is.EqualTo(",dc=fabrikam,dc=com"));
			Assert.That(key, Is.EqualTo("dc"));
			Assert.That(val, Is.EqualTo("corp"));
		}
	}
}