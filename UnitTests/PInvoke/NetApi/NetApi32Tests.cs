using NUnit.Framework;
using System;
using System.Linq;
using static Vanara.PInvoke.NetApi32;

namespace Vanara.PInvoke.Tests
{
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
				foreach (var(address, site, subnet) in DsAddressToSiteNamesEx(dnsHostName, sockets))
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
	}
}