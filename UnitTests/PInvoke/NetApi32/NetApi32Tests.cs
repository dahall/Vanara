using NUnit.Framework;
using System.Linq;
using System.Security.Principal;
using static Vanara.PInvoke.NetApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class NetApi32Tests
{
	[Test]
	public void DsGetDcName_DsGetDcEnum_DsAddressToSiteNamesEx_DsGetDcSiteCoverage_Test()
	{
		var dci = DsGetDcName(DsGetDcNameFlags.DS_RETURN_DNS_NAME);
		Assert.NotNull(dci.DomainControllerName);
		foreach (var (dnsHostName, sockets) in DsGetDcEnum(dci.DomainName))
		{
			TestContext.WriteLine($"{dnsHostName} = {string.Join(",", sockets)}");
			foreach (var(address, site, subnet) in DsAddressToSiteNamesEx(dnsHostName!, sockets))
				TestContext.WriteLine($"  Site={site}; Subnet={subnet}");
			TestContext.WriteLine($"   SiteCov={string.Join(",", DsGetDcSiteCoverage(dnsHostName))}");
		}
	}

	[Test]
	public void DsEnumerateDomainTrustsTest()
	{
		foreach (var t in DsEnumerateDomainTrusts(DomainTrustFlag.DS_DOMAIN_IN_FOREST))
			TestContext.WriteLine($"{t.DnsDomainName} = {t.TrustType}");
	}

	[Test]
	public void DsGetForestTrustInformationTest()
	{
		var i = DsGetForestTrustInformation("funkytown", null);
		Assert.That(i.Entries.Count, Is.GreaterThan(0));
		foreach (var e in i.Entries)
			TestContext.WriteLine(e);
	}

	[Test]
	public void DsRoleGetPrimaryDomainInformationTest()
	{
		Assert.That(() => DsRoleGetPrimaryDomainInformation<DSROLE_UPGRADE_STATUS_INFO>(null, DSROLE_PRIMARY_DOMAIN_INFO_LEVEL.DsRoleOperationState), Throws.ArgumentException);
		var op = DsRoleGetPrimaryDomainInformation<DSROLE_PRIMARY_DOMAIN_INFO_BASIC>("funkytown", DSROLE_PRIMARY_DOMAIN_INFO_LEVEL.DsRolePrimaryDomainInfoBasic);
		Assert.That(op.DomainNameDns, Is.Not.Null);
	}

	[Test()]
	public void NetApiBufferFreeTest()
	{
		Assert.That(NetServerGetInfo(null, 100, out var bufptr).Succeeded);
		bufptr.Dispose();
		Assert.True(bufptr.IsClosed);
	}

	[Test]
	public void NetGetAadJoinInformationTest()
	{
		Assert.That(NetGetAadJoinInformation(null, out var joinInfo), ResultIs.Successful);
		joinInfo!.WriteValues();
	}

	[Test]
	public void NetServerDiskEnumTest()
	{
		Assert.That(NetServerDiskEnum(), Contains.Item("C:"));
	}

	[Test()]
	public void NetServerEnumTest()
	{
		var l = NetServerEnum<SERVER_INFO_101>().ToList();
		Assert.NotZero(l.Count);
		Assert.NotNull(l[0].sv101_name);
	}

	[Test()]
	public void NetServerGetInfoTest()
	{
		var i = NetServerGetInfo<SERVER_INFO_100>(null);
		Assert.AreEqual(i.sv100_name, Environment.MachineName);
	}

	[Test]
	public void NetServerTransportEnumTest()
	{
		Assert.That(NetServerTransportEnum<SERVER_TRANSPORT_INFO_1>(), Is.Not.Empty);
	}

	[Test]
	public void NetEnumerateComputerNamesTest()
	{
		Assert.That(NetEnumerateComputerNames(), Is.Not.Empty);
	}

	[Test]
	public void NetGetJoinableOUsTest()
	{
		Assert.That(NetGetJoinableOUs("AMERICAS"), Is.Not.Empty);
	}

	[Test]
	public void NetConnectionEnumTest()
	{
		Assert.That(NetConnectionEnum<CONNECTION_INFO_0>(null, "Users"), Is.Not.Empty);
	}

	[Test]
	public void NetFileEnumTest()
	{
		Assert.That(NetFileEnum<FILE_INFO_2>(null), Is.Not.Empty);
	}

	[Test]
	public void NetUseTest()
	{
		const string dl = "S:";
		NetUseAdd(null, new USE_INFO_1 { ui1_local = dl, ui1_remote = @"\\HALLAN-SVR\share", ui1_asg_type = NetUseType.USE_DISKDEV, ui1_usecount = 1 });
		var e = NetUseEnum<USE_INFO_0>();
		Assert.That(e, Is.Not.Empty);
		Assert.That(() => e.First(i => i.ui0_local == dl), Throws.Nothing);
		var ui1 = NetUseGetInfo<USE_INFO_1>(null, dl);
		Assert.That(ui1.ui1_local, Is.EqualTo(dl));
		Assert.That(() => NetUseDel(null, dl, NetUseForce.USE_LOTS_OF_FORCE).ThrowIfFailed(), Throws.Nothing);
		e = NetUseEnum<USE_INFO_0>();
		Assert.That(() => e.First(i => i.ui0_local == dl), Throws.Exception);
	}

	[Test]
	public void NetGroupTest()
	{
		const string val = "Dummy";
		NetGroupAdd(null, new GROUP_INFO_3 { grpi3_name = val, grpi3_comment = val });
		var e = NetGroupEnum<GROUP_INFO_0>();
		Assert.That(e, Is.Not.Empty);
		Assert.That(() => e.First(i => i.grpi0_name == val), Throws.Nothing);
		var info = NetGroupGetInfo<GROUP_INFO_1>(null, val);
		Assert.That(info.grpi1_name, Is.EqualTo(val));
		Assert.That(() => NetGroupDel(null, val).ThrowIfFailed(), Throws.Nothing);
		e = NetGroupEnum<GROUP_INFO_0>();
		Assert.That(() => e.First(i => i.grpi0_name == val), Throws.Exception);
	}

	[Test]
	public void NetLocalGroupTest()
	{
		const string val = "Dummy";
		NetLocalGroupDel(null, val);
		NetLocalGroupAdd(null, new LOCALGROUP_INFO_1 { lgrpi1_name = val, lgrpi1_comment = val });
		var e = NetLocalGroupEnum<LOCALGROUP_INFO_0>();
		Assert.That(e, Is.Not.Empty);
		Assert.That(() => e.First(i => i.lgrpi0_name == val), Throws.Nothing);
		var info = NetLocalGroupGetInfo<LOCALGROUP_INFO_1>(null, val);
		Assert.That(info.lgrpi1_name, Is.EqualTo(val));

		using var identity = WindowsIdentity.GetCurrent();
		Assert.NotNull(identity.User);
		var sidmem = new SafeHGlobalHandle(identity.User!.GetBytes());

		NetLocalGroupAddMembers(null, val, new[] { new LOCALGROUP_MEMBERS_INFO_0 { lgrmi0_sid = (IntPtr)sidmem } });
		var m = NetLocalGroupGetMembers<LOCALGROUP_MEMBERS_INFO_3>(null, val);
		Assert.That(m, Is.Not.Empty);
		NetLocalGroupDelMembers(null, val, m.ToArray());
		Assert.That(NetLocalGroupGetMembers<LOCALGROUP_MEMBERS_INFO_3>(null, val), Is.Empty);
		Assert.That(() => NetLocalGroupDel(null, val).ThrowIfFailed(), Throws.Nothing);
		e = NetLocalGroupEnum<LOCALGROUP_INFO_0>();
		Assert.That(() => e.First(i => i.lgrpi0_name == val), Throws.Exception);
	}

	[Test]
	public void NetUserTest()
	{
		const string val = "Dummy";
		NetUserDel(null, val);
		NetUserAdd(null, new USER_INFO_1 { usri1_name = val, usri1_password = "BigLongPwd0!", usri1_priv = UserPrivilege.USER_PRIV_USER, usri1_flags = UserAcctCtrlFlags.UF_ACCOUNTDISABLE });
		var e = NetUserEnum<USER_INFO_1>();
		Assert.That(e, Is.Not.Empty);
		Assert.That(() => e.First(i => i.usri1_name == val), Throws.Nothing);
		var info = NetUserGetInfo<USER_INFO_1>(null, val);
		Assert.That(info.usri1_name, Is.EqualTo(val));
		Assert.That(NetUserGetGroups<GROUP_USERS_INFO_0>(null, val), Is.Not.Empty);
		Assert.That(NetUserGetLocalGroups<LOCALGROUP_USERS_INFO_0>(null, val, 0), Is.Empty);
		//Assert.That(NetUserModalsGet<USER_MODALS_INFO_0>(null), Is.Empty);
		Assert.That(() => NetUserDel(null, val).ThrowIfFailed(), Throws.Nothing);
		e = NetUserEnum<USER_INFO_1>();
		Assert.That(() => e.First(i => i.usri1_name == val), Throws.Exception);
	}

}

public static class UtilExt
{
	public static byte[] GetBytes(this SecurityIdentifier si)
	{
		if (si == null) return new byte[0];
		var sidLen = si.BinaryLength;
		var bytes = new byte[sidLen];
		si.GetBinaryForm(bytes, 0);
		return bytes;
	}
}