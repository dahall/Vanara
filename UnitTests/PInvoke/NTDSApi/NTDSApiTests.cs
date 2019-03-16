using NUnit.Framework;
using System;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using static Vanara.PInvoke.NTDSApi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class NTDSApiTests
	{
		public SafeDsHandle hDs;
		public string dn;

		internal static object[] AuthCasesFromFile
		{
			get
			{
				const string authfn = @"C:\Temp\AuthTestCases.txt";
				var lines = File.ReadAllLines(authfn).Skip(1).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
				var ret = new object[lines.Length];
				for (var i = 0; i < lines.Length; i++)
				{
					var items = lines[i].Split('\t').Select(s => s == string.Empty ? null : s).Cast<object>().ToArray();
					if (items.Length < 9) continue;
					bool.TryParse(items[0].ToString(), out var validUser);
					items[0] = validUser;
					bool.TryParse(items[1].ToString(), out var validCred);
					items[1] = validCred;
					ret[i] = items;
				}
				return ret;
			}
		}

		[OneTimeSetUp]
		public void Setup()
		{
			dn = System.Environment.UserDomainName;
			DsBind(null, dn, out hDs).ThrowIfFailed();
		}

		[Test, TestCaseSource(typeof(NTDSApiTests), nameof(NTDSApiTests.AuthCasesFromFile))]
		public void DsBindTest(bool validUser, bool validCred, string urn, string dn, string dcn, string domain, string un, string pwd, string notes)
		{
			Assert.That(DsBind(dcn, dn, out var dsb).Succeeded && !dsb.IsInvalid, Is.EqualTo(validUser));
			Assert.That(DsBind(dcn, null, out var dsb1).Succeeded && !dsb1.IsInvalid, Is.EqualTo(validUser));
			Assert.That(DsBind(null, dn, out var dsb2).Succeeded && !dsb2.IsInvalid, Is.EqualTo(validUser));
		}

		[Test, TestCaseSource(typeof(NTDSApiTests), nameof(NTDSApiTests.AuthCasesFromFile))]
		public void DsBindByInstanceTest(bool validUser, bool validCred, string urn, string dn, string dcn, string domain, string un, string pwd, string notes)
		{
			Assert.That(DsBindByInstance(DnsDomainName: dn, AuthIdentity: SafeAuthIdentityHandle.LocalThreadIdentity, phDS: out var dsb).Succeeded && !dsb.IsInvalid, Is.EqualTo(validUser));
		}

		[Test]
		public void DsBindToISTGTest()
		{
			Assert.That(DsBindToISTG(null, out var dsb).Succeeded && !dsb.IsInvalid, Is.True);
		}

		[Test, TestCaseSource(typeof(NTDSApiTests), nameof(NTDSApiTests.AuthCasesFromFile))]
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

		[Test, TestCaseSource(typeof(NTDSApiTests), nameof(NTDSApiTests.AuthCasesFromFile))]
		public void DsCrackNamesTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string un, string pwd, string notes)
		{
			var res = DsCrackNames(hDs, new[] {un}, DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME);
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
			DS_DOMAIN_CONTROLLER_INFO_1[] s1 = null;
			Assert.That(() => s1 = DsGetDomainControllerInfo<DS_DOMAIN_CONTROLLER_INFO_1>(hDs, dn), Throws.Nothing);
			Assert.That(s1, Is.Not.Null.And.Property("Length").GreaterThan(0));
			Assert.That(s1[0].fDsEnabled);

			DS_DOMAIN_CONTROLLER_INFO_2[] s2 = null;
			Assert.That(() => s2 = DsGetDomainControllerInfo<DS_DOMAIN_CONTROLLER_INFO_2>(hDs, dn), Throws.Nothing);
			Assert.That(s2, Is.Not.Null.And.Property("Length").GreaterThan(0));
			Assert.That(s2[0].fDsEnabled);

			DS_DOMAIN_CONTROLLER_INFO_3[] s3 = null;
			Assert.That(() => s3 = DsGetDomainControllerInfo<DS_DOMAIN_CONTROLLER_INFO_3>(hDs, dn), Throws.Nothing);
			Assert.That(s3, Is.Not.Null.And.Property("Length").GreaterThan(0));
			Assert.That(s3[0].fDsEnabled);
			foreach (var i3 in s3)
				TestContext.WriteLine($"{(i3.fIsPdc?"PDC":"DC")}{(i3.fIsGc?",GC":"")}{(i3.fIsRodc?",RO":"")}:\t{i3.NetbiosName}\t{i3.DnsHostName}\t{i3.SiteName}\t{i3.SiteObjectName}\t{i3.ComputerObjectName}\t{i3.ServerObjectName}\t{i3.NtdsDsaObjectName}\t{(i3.fDsEnabled?"Enabled":"Disabled")}");
		}

		[Test]
		public void DsListRolesTest()
		{
			TestNameResult((SafeDsHandle h, out SafeDsNameResult nr) => DsListRoles(h, out nr), "Roles");
		}

		[Test]
		public void DsListDomainsInSiteTest()
		{
			var site = TestNameResult((SafeDsHandle h, out SafeDsNameResult nr) => DsListSites(h, out nr), "Sites");
			var dom = TestNameResult((SafeDsHandle h, out SafeDsNameResult nr) => DsListDomainsInSite(h, site, out nr), "Domains");
			var siteserver = TestNameResult((SafeDsHandle h, out SafeDsNameResult nr) => DsListServersInSite(h, site, out nr), "SiteServers");
			var dserver = TestNameResult((SafeDsHandle h, out SafeDsNameResult nr) => DsListServersForDomainInSite(h, dom, site, out nr), "DomServers");
			var item = TestNameResult((SafeDsHandle h, out SafeDsNameResult nr) => DsListInfoForServer(h, dserver, out nr), "SvrInfo");
		}

		private delegate Win32Error NRDel(SafeDsHandle h, out SafeDsNameResult nr);

		private string TestNameResult(NRDel f, string prefix)
		{
			var err = f(hDs, out var hnr);
			Assert.That(err, Is.EqualTo(Win32Error.ERROR_SUCCESS));
			var nrs = hnr.ToArray();
			Assert.That(nrs.Length, Is.Not.Zero);
			var nr = nrs[0];
			Assert.That(nr.pName, Is.Not.Null);
			TestContext.WriteLine(prefix + ": " + string.Join(", ", nrs));
			TestContext.WriteLine();
			return nr.pName;
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

		[Test]
		public void DsMapSchemaGuidsTest()
		{
			var guid = new Guid("2BEC133B-AE2B-4C32-A3F5-036149C4E671");
			var err = DsMapSchemaGuids(hDs, 1, new[] { guid }, out var map);
			Assert.That(err, Is.EqualTo(Win32Error.ERROR_SUCCESS));
			var items = map.GetItems(1);
			var item = items[0];
			Assert.That(item.guid, Is.EqualTo(guid));
		}

		[Test]
		public void DsQuerySitesByCostTest()
		{
			var err = DsBindToISTG(null, out var hDs);
			Assert.That(err, Is.EqualTo(Win32Error.ERROR_SUCCESS));
			err = NetApi32.DsGetSiteName(null, out var hSiteName);
			Assert.That(err, Is.EqualTo(Win32Error.ERROR_SUCCESS));
			var site = hSiteName.ToString();
			var sites = GetAllSiteNames();
			err = DsQuerySitesByCost(hDs, site, sites, (uint)sites.Length, 0, out var hnr);
			Assert.That(err, Is.EqualTo(Win32Error.ERROR_SUCCESS));
			var nrs = hnr.GetItems(sites.Length);
			Assert.That(nrs.Length, Is.EqualTo(sites.Length));
			var nr = nrs[0];
			Assert.That(nr.cost, Is.Not.Null);
			for (var i = 0; i < sites.Length; i++)
				TestContext.WriteLine($"{sites[i]}: {(nrs[i].errorCode == Win32Error.ERROR_SUCCESS ? nrs[i].cost.ToString() : "Not found")}");
		}

		private static string[] GetAllSiteNames()
		{
			var rootDSE = new DirectoryEntry("LDAP://RootDSE");
			var configNC = new DirectoryEntry("LDAP://" + rootDSE.Properties["configurationNamingContext"][0]);
			var sitesContainer = new DirectoryEntry("LDAP://CN=Sites," + configNC.Properties["distinguishedName"][0]);
			var siteFinder = new DirectorySearcher(sitesContainer, "(objectClass=site)") { PageSize = 100 };
			using (var results = siteFinder.FindAll())
				return results.Cast<SearchResult>().Select(r => r.Properties["name"][0].ToString()).ToArray();
		}
	}
}