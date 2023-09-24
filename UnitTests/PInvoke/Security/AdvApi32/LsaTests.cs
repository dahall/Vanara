using NUnit.Framework;
using System.Linq;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.AdvApi32;

namespace Security.AdvApi32;

[TestFixture]
public class LsaTests
{
	public SafeLSA_HANDLE? hPol;
	public SafePSID? pSid;

	[OneTimeSetUp]
	public void _Setup()
	{
		hPol = LsaOpenPolicy(LsaPolicyRights.POLICY_ALL_ACCESS);
		pSid = SafePSID.Current;
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		hPol?.Dispose();
		pSid?.Dispose();
	}

	[Test]
	public void LsaAddEnumRemoveAccountRightsTest()
	{
		var rights = new[] { "SeAuditPrivilege", "SeBatchLogonRight", "SeRemoteInteractiveLogonRight" };
		Assert.That(LsaAddAccountRights(hPol!, pSid!, rights), ResultIs.Successful);
		string[]? erights = null;
		Assert.That(() => erights = LsaEnumerateAccountRights(hPol!, pSid!).ToArray(), Throws.Nothing);
		Assert.That(erights, Is.EquivalentTo(rights));
		Assert.That(LsaRemoveAccountRights(hPol!, pSid!, false, rights), ResultIs.Successful);
	}

	[Test]
	public void LsaCreateAccountTest()
	{
		Assert.That(LsaCreateAccount(hPol!, pSid!, LsaAccountAccessMask.ACCOUNT_ALL_ACCESS, out SafeLSA_HANDLE hAcct), ResultIs.Successful);
		hAcct.Dispose();
	}

	[Test]
	public void LsaCreateTrustedDomainExTest()
	{
		var tdi = new TRUSTED_DOMAIN_INFORMATION_EX
		{
			Name = new SafeLSA_UNICODE_STRING("MINE"),
			Sid = pSid!,
			TrustType = TrustType.TRUST_TYPE_MIT,
			TrustAttributes = TrustAttributes.TRUST_ATTRIBUTE_TREAT_AS_EXTERNAL,
			TrustDirection = TrustDirection.TRUST_DIRECTION_DISABLED
		};
		var tdai = new TRUSTED_DOMAIN_AUTH_INFORMATION { };
		Assert.That(LsaCreateTrustedDomainEx(hPol!, tdi, tdai, ACCESS_MASK.GENERIC_ALL, out _), ResultIs.Failure);
	}

	[Test]
	public void LsaDeleteTrustedDomainTest() => Assert.That(LsaDeleteTrustedDomain(hPol!, pSid!), ResultIs.Failure);

	[Test]
	public void LsaEnumerateAccountsWithUserRightTest()
	{
		using SafeLSA_HANDLE hPol = LsaOpenPolicy(LsaPolicyRights.POLICY_LOOKUP_NAMES | LsaPolicyRights.POLICY_VIEW_LOCAL_INFORMATION);
		PSID[]? sids = null;
		Assert.That(() => sids = LsaEnumerateAccountsWithUserRight(hPol).ToArray(), Throws.Nothing);
		Assert.That(sids, Is.Not.Empty);
		TestContext.Write(string.Join("\n", sids.Select(ConvertSidToStringSid)));
		Assert.That(() => sids = LsaEnumerateAccountsWithUserRight(hPol!, "SeBackupPrivilege").ToArray(), Throws.Nothing);
		Assert.That(sids, Is.Not.Empty);
		TestContext.Write(string.Join("\n", sids.Select(ConvertSidToStringSid)));
	}

	[Test]
	public void LsaEnumerateTrustedDomainsTest()
	{
		LSA_TRUST_INFORMATION[]? tis = null;
		Assert.That(() => tis = LsaEnumerateTrustedDomains(hPol!).ToArray(), Throws.Nothing);
		tis.WriteValues();
	}

	[Test]
	public void LsaGetAppliedCAPIDsTest() => Assert.That(() => LsaGetAppliedCAPIDs().WriteValues(), Throws.Nothing);

	[Test]
	public void LsaLookupNames2Test()
	{
		var names = new[] { Environment.UserDomainName, Environment.UserName };
		Assert.That(LsaLookupNames2(hPol!, LsaLookupNamesFlags.LSA_LOOKUP_ISOLATED_AS_LOCAL, (uint)names.Length, names,
			out SafeLsaMemoryHandle memDoms, out SafeLsaMemoryHandle memSids), ResultIs.Successful);
		using (memDoms)
		using (memSids)
		{
			LSA_TRUST_INFORMATION[]? doms = memDoms.ToStructure<LSA_REFERENCED_DOMAIN_LIST>().DomainList.ToArray();
			LSA_TRANSLATED_SID2[]? sids = memSids.ToArray<LSA_TRANSLATED_SID2>(names.Length);
			for (var i = 0; i < names.Length; i++)
				TestContext.WriteLine((names[i], sids[i].Use, (SafePSID)sids[i].Sid, sids[i].DomainIndex == -1 ? (string?)null : doms[sids[i].DomainIndex].Name));
		}
	}

	[Test]
	public void LsaLookupNamesTest()
	{
		var names = new[] { Environment.UserDomainName, Environment.UserName };
		Assert.That(LsaLookupNames(hPol!, (uint)names.Length, names, out SafeLsaMemoryHandle memDoms, out SafeLsaMemoryHandle memSids), ResultIs.Successful);
		using (memDoms)
		using (memSids)
		{
			LSA_TRUST_INFORMATION[]? doms = memDoms.ToStructure<LSA_REFERENCED_DOMAIN_LIST>().DomainList.ToArray();
			LSA_TRANSLATED_SID[]? sids = memSids.ToArray<LSA_TRANSLATED_SID>(names.Length);
			for (var i = 0; i < names.Length; i++)
				TestContext.WriteLine((names[i], sids[i].Use, sids[i].RelativeId, doms[sids[i].DomainIndex].Name));
		}
	}

	[Test]
	public void LsaLookupPrivilegeValueTest() => Assert.That(LsaLookupPrivilegeValue(hPol!, "SeSecurityPrivilege", out _), ResultIs.Successful);

	[Test]
	public void LsaLookupSids2Test()
	{
		var sids = new PSID[] { pSid! };
		Assert.That(LsaLookupSids2(hPol!, LsaLookupSidsFlags.LSA_LOOKUP_PREFER_INTERNET_NAMES, (uint)sids.Length, sids, out SafeLsaMemoryHandle memDoms, out SafeLsaMemoryHandle memNames), ResultIs.Successful);
		using (memDoms)
		using (memNames)
		{
			LSA_TRUST_INFORMATION[]? doms = memDoms.ToStructure<LSA_REFERENCED_DOMAIN_LIST>().DomainList.ToArray();
			LSA_TRANSLATED_NAME[]? names = memNames.ToArray<LSA_TRANSLATED_NAME>(sids.Length);
			for (var i = 0; i < sids.Length; i++)
				TestContext.WriteLine(((SafePSID)sids[i], names[i].Use, names[i].Name, names[i].DomainIndex == -1 ? (string?)null : doms[names[i].DomainIndex].Name));
		}
	}

	[Test]
	public void LsaLookupSidsTest()
	{
		var sids = new PSID[] { pSid! };
		Assert.That(LsaLookupSids(hPol!, (uint)sids.Length, sids, out SafeLsaMemoryHandle memDoms, out SafeLsaMemoryHandle memNames), ResultIs.Successful);
		using (memDoms)
		using (memNames)
		{
			LSA_TRUST_INFORMATION[]? doms = memDoms.ToStructure<LSA_REFERENCED_DOMAIN_LIST>().DomainList.ToArray();
			LSA_TRANSLATED_NAME[]? names = memNames.ToArray<LSA_TRANSLATED_NAME>(sids.Length);
			for (var i = 0; i < sids.Length; i++)
				TestContext.WriteLine(((SafePSID)sids[i], names[i].Use, names[i].Name, names[i].DomainIndex == -1 ? (string?)null : doms[names[i].DomainIndex].Name));
		}
	}

	[Test]
	public void LsaOpenGetSetSystemAccessAccountTest()
	{
		Assert.That(LsaOpenAccount(hPol!, pSid!, LsaAccountAccessMask.ACCOUNT_ALL_ACCESS, out SafeLSA_HANDLE hAcct), ResultIs.Successful);
		using (hAcct)
		{
			Assert.That(LsaGetSystemAccessAccount(hAcct, out var access), ResultIs.Successful);
			access.WriteValues();
			Assert.That(LsaSetSystemAccessAccount(hAcct, access), ResultIs.Successful);
		}
	}

	[Test]
	public void LsaOpenPolicyRemoteTest()
	{
		NTStatus stat = LsaOpenPolicy(TestCaseSources.GetValueOrDefault("RemoteComputer"), LSA_OBJECT_ATTRIBUTES.Empty, LsaPolicyRights.POLICY_ALL_ACCESS, out SafeLSA_HANDLE h);
		Assert.That(stat, ResultIs.Successful);
		h.Dispose();
	}

	[Test]
	public void LsaOpenTrustedDomainByNameTest() => Assert.That(LsaOpenTrustedDomainByName(hPol!, Environment.UserDomainName, ACCESS_MASK.GENERIC_READ, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_OBJECT_NAME_NOT_FOUND));

	[Test]
	public void LsaQueryCAPsTest()
	{
		var ppsids = new PSID[] { pSid! };
		Assert.That(LsaQueryCAPs(ppsids, (uint)ppsids.Length, out _, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_INVALID_ID_AUTHORITY));
	}

	[Test]
	public void LsaQuerySetDomainInformationPolicyTest()
	{
		Assert.That(LsaQueryDomainInformationPolicy(hPol!, POLICY_DOMAIN_INFORMATION_CLASS.PolicyDomainEfsInformation, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_OBJECT_NAME_NOT_FOUND));
		using var input = SafeHGlobalHandle.CreateFromStructure(new POLICY_DOMAIN_QUALITY_OF_SERVICE_INFO { QualityOfService = POLICY_QOS.POLICY_QOS_DHCP_SERVER_ALLOWED });
		Assert.That(LsaSetDomainInformationPolicy(hPol!, POLICY_DOMAIN_INFORMATION_CLASS.PolicyDomainQualityOfServiceInformation, input), ResultIs.FailureCode((NTStatus)NTStatus.RPC_NT_INVALID_TAG));
	}

	[Test]
	public void LsaQuerySetForestTrustInformationTest()
	{
		Assert.That(LsaQueryForestTrustInformation(hPol!, Environment.UserDomainName, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_INVALID_DOMAIN_STATE));
		LSA_FOREST_TRUST_INFORMATION fti = default;
		Assert.That(LsaSetForestTrustInformation(hPol!, Environment.UserDomainName, fti, false, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_INVALID_DOMAIN_STATE));
	}

	[Test]
	public void LsaQuerySetInformationPolicyTest()
	{
		Assert.That(LsaQueryInformationPolicy(hPol!, POLICY_INFORMATION_CLASS.PolicyDnsDomainInformation, out SafeLsaMemoryHandle mem), ResultIs.Successful);
		mem.ToStructure<POLICY_DNS_DOMAIN_INFO>().WriteValues();
		Assert.That(LsaSetInformationPolicy(hPol!, POLICY_INFORMATION_CLASS.PolicyDnsDomainInformation, mem.DangerousGetHandle()), ResultIs.Successful);
	}

	[Test]
	public void LsaQuerySetTrustedDomainInfoByNameTest()
	{
		Assert.That(LsaQueryTrustedDomainInfoByName(hPol!, Environment.UserDomainName, TRUSTED_INFORMATION_CLASS.TrustedDomainNameInformation, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_OBJECT_NAME_NOT_FOUND));
		using var hGl = SafeHGlobalHandle.CreateFromStructure<TRUSTED_DOMAIN_NAME_INFO>();
		Assert.That(LsaSetTrustedDomainInfoByName(hPol!, Environment.UserDomainName, TRUSTED_INFORMATION_CLASS.TrustedDomainNameInformation, hGl), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_INVALID_INFO_CLASS));
	}

	[Test]
	public void LsaQuerySetTrustedDomainInfoTest()
	{
		SafePSID dsid = GetDomainSid();
		Assert.That(LsaQueryTrustedDomainInfo(hPol!, dsid, TRUSTED_INFORMATION_CLASS.TrustedDomainNameInformation, out _), ResultIs.FailureCode((NTStatus)NTStatus.STATUS_INVALID_HANDLE));
		using var hGl = SafeHGlobalHandle.CreateFromStructure<TRUSTED_DOMAIN_NAME_INFO>();
		Assert.That(LsaSetTrustedDomainInformation(hPol!, dsid, TRUSTED_INFORMATION_CLASS.TrustedDomainNameInformation, hGl), ResultIs.Failure);
	}

	[Test]
	public void LsaStoreRetrievePrivateDataTest()
	{
		const string keyName = "Random";
		Assert.That(LsaStorePrivateData(hPol!, keyName, keyName), ResultIs.Successful);
		Assert.That(LsaRetrievePrivateData(hPol!, keyName, out SafeLsaMemoryHandle privData), ResultIs.Successful); //FailureCode((NTStatus)NTStatus.STATUS_OBJECT_NAME_NOT_FOUND));
		Assert.That(privData.ToStructure<LSA_UNICODE_STRING>().ToString(), Is.EqualTo(keyName));
	}

	private SafePSID GetDomainSid(string? name = null)
	{
		var names = new[] { name ?? Environment.UserDomainName };
		Assert.That(LsaLookupNames2(hPol!, LsaLookupNamesFlags.LSA_LOOKUP_ISOLATED_AS_LOCAL, (uint)names.Length, names,
			out SafeLsaMemoryHandle memDoms, out SafeLsaMemoryHandle memSids), ResultIs.Successful);
		using (memDoms)
		using (memSids)
		{
			LSA_TRUST_INFORMATION[]? doms = memDoms.ToStructure<LSA_REFERENCED_DOMAIN_LIST>().DomainList.ToArray();
			return doms.Length == 0 ? SafePSID.Null : new SafePSID(doms[0].Sid);
		}
	}
}