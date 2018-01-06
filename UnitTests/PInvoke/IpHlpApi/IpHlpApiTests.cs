using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.IpHlpApi;

namespace Vanara.PInvoke.Tests
{
	public static class IPAddressExt
	{
		public static System.Net.IPAddress Convert(this SOCKET_ADDRESS sockAddr)
		{
			switch ((ADDRESS_FAMILY)Marshal.ReadInt16(sockAddr.lpSockAddr))
			{
				case ADDRESS_FAMILY.AF_INET:
					return new System.Net.IPAddress((long)sockAddr.lpSockAddr.ToStructure<SOCKADDR_IN>().sin_addr);
				case ADDRESS_FAMILY.AF_INET6:
					return new System.Net.IPAddress(sockAddr.lpSockAddr.ToStructure<SOCKADDR_IN6>().sin6_addr);
				default:
					throw new Exception("Non-IP address family");
			}
		}
	}

	[TestFixture()]
	public class IpHlpApiTests
	{
		private static IP_ADAPTER_ADDRESSES primaryAdapter;

		[SetUp]
		public void Setup()
		{
			primaryAdapter = GetAdaptersAddresses(GetAdaptersAddressesFlags.GAA_FLAG_INCLUDE_GATEWAYS).FirstOrDefault(r => r.OperStatus == IF_OPER_STATUS.IfOperStatusUp && r.TunnelType == TUNNEL_TYPE.TUNNEL_TYPE_NONE);
		}

		[Test]
		public void AddDeleteIPAddressTest()
		{
			var newIp = new IN_ADDR(192, 168, 0, 252);
			var mask = new IN_ADDR(255, 255, 255, 0);
#pragma warning disable CS0618 // Type or member is obsolete
			Assert.That(AddIPAddress(newIp, mask, primaryAdapter.IfIndex, out var ctx, out var inst), Is.Zero);
#pragma warning restore CS0618 // Type or member is obsolete
			Assert.That(DeleteIPAddress(ctx), Is.Zero);
		}

		[Test]
		public void CreateSetDeleteIpNetEntryTest()
		{
			var target = new IN_ADDR(192, 168, 0, 202);
			Assert.That(GetBestRoute(target, 0, out var fwdRow), Is.Zero);
			var mibrow = new MIB_IPNET_ROW2(new SOCKADDR_IN(target), fwdRow.dwForwardIfIndex, SendARP(target));
			Assert.That(GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out MIB_IPNET_TABLE2 t1), Is.Zero);
			foreach (var r in t1) Debug.WriteLine(r);
			if (HasVal(t1, mibrow))
				Assert.That(DeleteIpNetEntry2(ref mibrow), Is.Zero);
			Assert.That(CreateIpNetEntry2(ref mibrow), Is.Zero);
			GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out var t2);
			Assert.That(HasVal(t2, mibrow), Is.True);
			Assert.That(DeleteIpNetEntry2(ref mibrow), Is.Zero);
			GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out var t3);
			Assert.That(HasVal(t3, mibrow), Is.False);

			bool HasVal(IEnumerable<MIB_IPNET_ROW2> t, MIB_IPNET_ROW2 r) =>
				t.Any(tr => tr.Address.Ipv4.sin_addr == r.Address.Ipv4.sin_addr && tr.InterfaceIndex == r.InterfaceIndex && tr.PhysicalAddress.SequenceEqual(r.PhysicalAddress));
		}

		[Test]
		public void EnableUnenableRouterTest()
		{
			Assert.Fail();
		}

		[Test]
		public void GetAdapterIndexTest()
		{
			const string prefix = "\\DEVICE\\TCPIP_";
			Assert.That(GetAdapterIndex(prefix + primaryAdapter.AdapterName, out var idx), Is.Zero);
			Assert.That(idx, Is.EqualTo(primaryAdapter.IfIndex));
			Assert.That(GetAdapterIndex(primaryAdapter.AdapterName, out idx), Is.EqualTo(Win32Error.ERROR_FILE_NOT_FOUND));
			Assert.That(GetAdapterIndex("__Bogus**__", out idx), Is.EqualTo(Win32Error.ERROR_INVALID_PARAMETER));
		}

		[Test]
		public void GetAdaptersAddressesTest()
		{
			Assert.That(() =>
			{
				foreach (var addrs in GetAdaptersAddresses(GetAdaptersAddressesFlags.GAA_FLAG_INCLUDE_PREFIX, ADDRESS_FAMILY.AF_UNSPEC))
				{
					Debug.WriteLine($"{addrs.IfIndex}) {addrs.AdapterName} ({addrs.FriendlyName});{addrs.Description};MAC:{PhysicalAddressToString(addrs.PhysicalAddress)}");
					Debug.WriteLine("  Uni:" + string.Join(";", addrs.UnicastAddresses.Select(a => a.Address)));
					Debug.WriteLine("  Any:" + string.Join(";", addrs.AnycastAddresses.Select(a => a.Address)));
					Debug.WriteLine("  MCS:" + string.Join(";", addrs.MulticastAddresses.Select(a => a.Address)));
					Debug.WriteLine("  DNS:" + string.Join(";", addrs.DnsServerAddresses.Select(a => a.Address)));
					Debug.WriteLine("  Prfx:" + string.Join(";", addrs.Prefixes.Select(a => a.Address)));
					Debug.WriteLine("  WINS:" + string.Join(";", addrs.WinsServerAddresses.Select(a => a.Address)));
					Debug.WriteLine("  GTWY:" + string.Join(";", addrs.GatewayAddresses.Select(a => a.Address)));
					Debug.WriteLine("  Sufx:" + string.Join(";", addrs.DnsSuffixes.Select(a => a.String)));
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetAdaptersInfoTest()
		{
			uint len = 15000;
			var mem = new SafeCoTaskMemHandle((int)len);
#pragma warning disable CS0618 // Type or member is obsolete
			Assert.That(GetAdaptersInfo((IntPtr)mem, ref len), Is.Zero);
			Assert.That(((IntPtr)mem).LinkedListToIEnum<IP_ADAPTER_INFO>(i => i.Next), Is.Not.Empty);
#pragma warning restore CS0618 // Type or member is obsolete
		}

		[Test]
		public void GetBestInterfaceTest()
		{
#pragma warning disable CS0618 // Type or member is obsolete
			var gw = (uint)primaryAdapter.GatewayAddresses.Select(a => a.Address.Convert()).FirstOrDefault().Address;
#pragma warning restore CS0618 // Type or member is obsolete
			Assert.That(gw, Is.Not.Zero);
			Assert.That(GetBestInterface(gw, out var idx), Is.Zero);
			Assert.That(idx, Is.EqualTo(primaryAdapter.IfIndex));
		}

		[Test]
		public void GetBestInterfaceExTest()
		{
#pragma warning disable CS0618 // Type or member is obsolete
			var gw = primaryAdapter.GatewayAddresses.Select(a => a.Address.Convert()).FirstOrDefault();
#pragma warning restore CS0618 // Type or member is obsolete
			var sa = new SOCKADDR(gw.GetAddressBytes(), 0, gw.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ? 0 : (uint)gw.ScopeId);
			Assert.That(GetBestInterfaceEx(sa, out var idx), Is.Zero);
			Assert.That(idx, Is.EqualTo(primaryAdapter.IfIndex));
		}

		[Test]
		public void GetBestRoute2Test()
		{
			var addr = new SOCKADDR_INET { Ipv4 = new SOCKADDR_IN(new IN_ADDR(192,168,0,202)) };
			Assert.That(GetBestRoute2(IntPtr.Zero, primaryAdapter.IfIndex, IntPtr.Zero, ref addr, 0, out var rt, out var src), Is.Zero);
			Assert.That(rt.InterfaceIndex, Is.EqualTo(primaryAdapter.IfIndex));
			Assert.That(src.Ipv4.sin_addr, Is.EqualTo(new IN_ADDR(192,168,0,113)));
		}

		[Test]
		public void GetExtendedTcpTableTest()
		{
			Assert.That(() =>
			{
				var t1 = GetExtendedTcpTable<MIB_TCPTABLE>(TCP_TABLE_CLASS.TCP_TABLE_BASIC_ALL);
				Assert.That(t1.dwNumEntries, Is.GreaterThan(0));
				var t2 = GetExtendedTcpTable<MIB_TCPTABLE>(TCP_TABLE_CLASS.TCP_TABLE_BASIC_CONNECTIONS);
				Assert.That(t2.dwNumEntries, Is.GreaterThan(0));
				var t3 = GetExtendedTcpTable<MIB_TCPTABLE>(TCP_TABLE_CLASS.TCP_TABLE_BASIC_LISTENER);
				Assert.That(t3.dwNumEntries, Is.GreaterThan(0));
				var t4 = GetExtendedTcpTable<MIB_TCPTABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL);
				Assert.That(t4.dwNumEntries, Is.GreaterThan(0));
				var t5 = GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t5.dwNumEntries, Is.GreaterThan(0));
				var t6 = GetExtendedTcpTable<MIB_TCPTABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_CONNECTIONS);
				Assert.That(t6.dwNumEntries, Is.GreaterThan(0));
				var t7 = GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_CONNECTIONS, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t7.dwNumEntries, Is.GreaterThan(0));
				var t8 = GetExtendedTcpTable<MIB_TCPTABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_LISTENER);
				Assert.That(t8.dwNumEntries, Is.GreaterThan(0));
				var t9 = GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_LISTENER, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t9.dwNumEntries, Is.GreaterThan(0));
				var t10 = GetExtendedTcpTable<MIB_TCPTABLE_OWNER_PID>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
				Assert.That(t10.dwNumEntries, Is.GreaterThan(0));
				var t11 = GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_PID>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t11.dwNumEntries, Is.GreaterThan(0));
				var t12 = GetExtendedTcpTable<MIB_TCPTABLE_OWNER_PID>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_CONNECTIONS);
				Assert.That(t12.dwNumEntries, Is.GreaterThan(0));
				var t13 = GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_PID>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_CONNECTIONS, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t13.dwNumEntries, Is.GreaterThan(0));
				var t14 = GetExtendedTcpTable<MIB_TCPTABLE_OWNER_PID>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_LISTENER);
				Assert.That(t14.dwNumEntries, Is.GreaterThan(0));
				var t15 = GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_PID>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_LISTENER, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t15.dwNumEntries, Is.GreaterThan(0));
			}, Throws.Nothing);
			Assert.That(() => GetExtendedTcpTable<MIB_TCPTABLE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL), Throws.InvalidOperationException);
			Assert.That(() => GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL), Throws.InvalidOperationException);
			Assert.That(() => GetExtendedTcpTable<MIB_TCPTABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL, ADDRESS_FAMILY.AF_INET6), Throws.InvalidOperationException);
		}

		[Test]
		public void GetExtendedUdpTableTest()
		{
			Assert.That(() =>
			{
				var t1 = GetExtendedUdpTable<MIB_UDPTABLE>(UDP_TABLE_CLASS.UDP_TABLE_BASIC);
				Assert.That(t1.dwNumEntries, Is.GreaterThan(0));
				var t4 = GetExtendedUdpTable<MIB_UDPTABLE_OWNER_MODULE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE);
				Assert.That(t4.dwNumEntries, Is.GreaterThan(0));
				var t5 = GetExtendedUdpTable<MIB_UDP6TABLE_OWNER_MODULE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t5.dwNumEntries, Is.GreaterThan(0));
				var t10 = GetExtendedUdpTable<MIB_UDPTABLE_OWNER_PID>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID);
				Assert.That(t10.dwNumEntries, Is.GreaterThan(0));
				var t11 = GetExtendedUdpTable<MIB_UDP6TABLE_OWNER_PID>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_PID, ADDRESS_FAMILY.AF_INET6);
				Assert.That(t11.dwNumEntries, Is.GreaterThan(0));
			}, Throws.Nothing);
			Assert.That(() => GetExtendedUdpTable<MIB_UDPTABLE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE), Throws.InvalidOperationException);
			Assert.That(() => GetExtendedUdpTable<MIB_UDP6TABLE_OWNER_MODULE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE), Throws.InvalidOperationException);
			Assert.That(() => GetExtendedUdpTable<MIB_UDPTABLE_OWNER_MODULE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE, ADDRESS_FAMILY.AF_INET6), Throws.InvalidOperationException);
		}

		[Test]
		public void GetIfEntry2Test()
		{
			var row = new MIB_IF_ROW2(primaryAdapter.IfIndex);
			Assert.That(GetIfEntry2(ref row), Is.Zero);
			Assert.That(row.InterfaceLuid, Is.EqualTo(primaryAdapter.Luid));
		}

		[Test]
		public void GetIfEntry2ExTest()
		{
			return;
			var row = new MIB_IF_ROW2(primaryAdapter.IfIndex);
			Assert.That(GetIfEntry2Ex(MIB_IF_ENTRY_LEVEL.MibIfEntryNormalWithoutStatistics, ref row), Is.Zero);
			Assert.That(row.InterfaceLuid, Is.EqualTo(primaryAdapter.Luid));
		}

		[Test]
		public void GetIfTableTest()
		{
			Assert.That(() =>
			{
				var t = GetIfTable();
				Assert.That(t.dwNumEntries, Is.GreaterThan(0));
				foreach (var r in t) ;
			}, Throws.Nothing);
		}

		[Test]
		public void GetIfTable2Test()
		{
			var e = GetIfTable2(out var itbl);
			Assert.That(e.Succeeded);
			Assert.That(itbl.Elements, Is.Not.Empty);
			itbl.Dispose();
			Assert.That(itbl.IsInvalid);
		}

		[Test]
		public void GetIfTable2ExTest()
		{
			var e = GetIfTable2Ex(MIB_IF_TABLE_LEVEL.MibIfTableNormal, out var itbl);
			Assert.That(e.Succeeded);
			Assert.That(itbl.Elements, Is.Not.Empty);
			itbl.Dispose();
			Assert.That(itbl.IsInvalid);
		}

		[Test]
		public void GetInterfaceInfoTest()
		{
			Assert.That(() =>
			{
				var t = GetInterfaceInfo();
				Assert.That(t.NumAdapters, Is.GreaterThan(0));
				foreach (var r in t) ;
			}, Throws.Nothing);
		}

		[Test]
		public void GetIpAddrTableTest()
		{
			Assert.That(() =>
			{
				var t = GetIpAddrTable();
				Assert.That(t.dwNumEntries, Is.GreaterThan(0));
				foreach (var r in t) ;
			}, Throws.Nothing);
		}

		[Test]
		public void GetNetworkParamsTest()
		{
			Assert.That(() =>
			{
				var t = GetNetworkParams();
				Assert.That(t.HostName, Is.Not.Null);
			}, Throws.Nothing);
		}

		[Test]
		public void GetPerAdapterInfoTest()
		{
			Assert.That(() =>
			{
				var info = GetPerAdapterInfo(primaryAdapter.IfIndex);
				Assert.That(info.DnsServerList, Is.Not.Empty);
			}, Throws.Nothing);
		}

		[Test]
		public void GetUniDirectionalAdapterInfoTest()
		{
			Assert.That(() =>
			{
				var info = GetUniDirectionalAdapterInfo();
				Assert.That(info.Address.Length, Is.GreaterThanOrEqualTo(0));
			}, Throws.Nothing);
		}

		[Test]
		public void NotifyAddrChangeTest()
		{
			Assert.Fail();
		}

		[Test]
		public void NotifyRouteChangeTest()
		{
			Assert.Fail();
		}

		[Test]
		public void IpReleaseRenewAddressTest()
		{
			var i = GetInterfaceInfo().First();
			Assert.That(IpReleaseAddress(ref i), Is.Zero);
			Assert.That(IpRenewAddress(ref i), Is.Zero);
			var x = new IP_ADAPTER_INDEX_MAP() { Name = "Bogus" };
			Assert.That(IpReleaseAddress(ref x), Is.EqualTo(Win32Error.ERROR_INVALID_PARAMETER));
			Assert.That(IpRenewAddress(ref x), Is.EqualTo(Win32Error.ERROR_INVALID_PARAMETER));
		}

		[Test]
		public void ResolveIpNetEntry2Test()
		{
			var e = new MIB_IPNET_ROW2(new SOCKADDR_IN(new IN_ADDR(192,168,0,202)), primaryAdapter.IfIndex);
			Assert.That(ResolveIpNetEntry2(ref e), Is.Zero);
			Assert.That(e.State, Is.EqualTo(NL_NEIGHBOR_STATE.NlnsReachable));
		}

		[Test]
		public void SendARPTest()
		{
			Assert.That(() =>
			{
				var gw = primaryAdapter.GatewayAddresses.Select(a => a.Address.Convert().GetAddressBytes()).FirstOrDefault();
				var mac = SendARP(new IN_ADDR(gw));
				Assert.That(mac.Length, Is.EqualTo(6));
				Assert.That(mac, Has.Some.Not.EqualTo(0));
			}, Throws.Nothing);
		}
	}
}