using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.IpHlpApi;
using static Vanara.PInvoke.Ws2_32;

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
		private static readonly IntPtr NotifyData = new IntPtr(8943934);
		private static IP_ADAPTER_ADDRESSES primaryAdapter;

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
		public void SetGetIpInterfaceEntryTest()
		{
			var mibrow = new MIB_IPINTERFACE_ROW(ADDRESS_FAMILY.AF_INET, primaryAdapter.Luid);
			Assert.That(GetIpInterfaceEntry(ref mibrow), Is.Zero);
			var prev = mibrow.SitePrefixLength;
			mibrow.SitePrefixLength = 0;
			Assert.That(SetIpInterfaceEntry(mibrow), Is.Zero);

			mibrow = new MIB_IPINTERFACE_ROW(ADDRESS_FAMILY.AF_INET, primaryAdapter.Luid);
			Assert.That(GetIpInterfaceEntry(ref mibrow), Is.Zero);
			Assert.That(mibrow.PathMtuDiscoveryTimeout, Is.Zero);

			mibrow.SitePrefixLength = prev;
			Assert.That(SetIpInterfaceEntry(mibrow), Is.Zero);
		}

		[Test]
		public void CreateSetDeleteIpNetEntry2Test()
		{
			var target = new IN_ADDR(192, 168, 0, 202);
			Assert.That(GetBestRoute(target, 0, out var fwdRow), Is.Zero);
			var mibrow = new MIB_IPNET_ROW2(new SOCKADDR_IN(target), fwdRow.dwForwardIfIndex, SendARP(target));
			Assert.That(GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out var t1), Is.Zero);
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
		public void CreateGetDeleteAnycastIpAddressEntryTest()
		{
			var target = new IN6_ADDR(new byte[] { 0xfe, 0x3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0x00 });
			var mibrow = new MIB_ANYCASTIPADDRESS_ROW(new SOCKADDR_IN6(target, 0), primaryAdapter.Luid);
			Assert.That(GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t1), Is.Zero);
			if (t1.Contains(mibrow))
				Assert.That(DeleteAnycastIpAddressEntry(ref mibrow), Is.Zero);

			Assert.That(CreateAnycastIpAddressEntry(ref mibrow), Is.Zero);
			GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t2);
			Assert.That(t2, Has.Member(mibrow));

			Assert.That(GetAnycastIpAddressEntry(ref mibrow), Is.Zero);

			Assert.That(DeleteAnycastIpAddressEntry(ref mibrow), Is.Zero);
			GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t3);
			Assert.That(t3, Has.No.Member(mibrow));
		}

		[Test]
		public void CreateSetGetDeleteUnicastIpAddressEntryTest()
		{
			var target = new IN6_ADDR(new byte[] { 0xfe, 0x3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0x00 });
			var mibrow = new MIB_UNICASTIPADDRESS_ROW(new SOCKADDR_IN6(target, 0), primaryAdapter.Luid);
			Assert.That(GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t1), Is.Zero);
			if (t1.Contains(mibrow))
				Assert.That(DeleteUnicastIpAddressEntry(ref mibrow), Is.Zero);

			Assert.That(CreateUnicastIpAddressEntry(ref mibrow), Is.Zero);
			GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t2);
			Assert.That(t2, Has.Member(mibrow));

			mibrow.PreferredLifetime = 500000;
			Assert.That(SetUnicastIpAddressEntry(mibrow), Is.Zero);
			Assert.That(GetUnicastIpAddressEntry(ref mibrow), Is.Zero);

			Assert.That(DeleteUnicastIpAddressEntry(ref mibrow), Is.Zero);
			GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t4);
			Assert.That(t4, Has.No.Member(mibrow));
		}

		[Test]
		public void CreateSetDeleteIpForwardEntry2Test()
		{
			var target = new IN6_ADDR(new byte[] { 0xfe, 0x3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0x00 });
			var mibrow = new MIB_IPFORWARD_ROW2(new IP_ADDRESS_PREFIX((SOCKADDR_IN6)IN6_ADDR.Unspecified, 128), (SOCKADDR_IN6)target, primaryAdapter.Luid)
			{
				Protocol = MIB_IPFORWARD_PROTO.MIB_IPPROTO_NETMGMT,
				Metric = 1
			};
			DeleteIpForwardEntry2(ref mibrow);

			Assert.That(CreateIpForwardEntry2(ref mibrow), Is.Zero);

			mibrow.PreferredLifetime = 500000;
			Assert.That(SetIpForwardEntry2(mibrow), Is.Zero);
			Assert.That(GetIpForwardEntry2(ref mibrow), Is.Zero);

			Assert.That(DeleteIpForwardEntry2(ref mibrow), Is.Zero);
		}

		[Test]
		public void EnableUnenableRouterTest()
		{
			Assert.Fail();
		}

		[Test]
		public void FlushIpNetTable2Test()
		{
			Assert.That(FlushIpNetTable2(ADDRESS_FAMILY.AF_INET6, primaryAdapter.IfIndex), Is.Zero);
		}

		[Test]
		public void FlushIpPathTableTest()
		{
			Assert.That(FlushIpPathTable(ADDRESS_FAMILY.AF_INET6), Is.Zero);
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
		public void GetAnycastIpAddressEntryTableTest()
		{
			Assert.That(GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.Zero);

			var row = new MIB_ANYCASTIPADDRESS_ROW();
			Assert.That(GetAnycastIpAddressEntry(ref row), Is.Not.Zero);
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
		public void GetBestRoute2Test()
		{
			var addr = new SOCKADDR_INET { Ipv4 = new SOCKADDR_IN(new IN_ADDR(192, 168, 0, 202)) };
			Assert.That(GetBestRoute2(IntPtr.Zero, primaryAdapter.IfIndex, IntPtr.Zero, ref addr, 0, out var rt, out var src), Is.Zero);
			Assert.That(rt.InterfaceIndex, Is.EqualTo(primaryAdapter.IfIndex));
			Assert.That(src.Ipv4.sin_addr, Is.EqualTo(new IN_ADDR(192, 168, 0, 203)));
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
		public void GetIfEntry2ExTest()
		{
			var row = new MIB_IF_ROW2(primaryAdapter.IfIndex);
			Assert.That(GetIfEntry2Ex(MIB_IF_ENTRY_LEVEL.MibIfEntryNormalWithoutStatistics, ref row), Is.Zero);
			Assert.That(row.InterfaceLuid, Is.EqualTo(primaryAdapter.Luid));
		}

		[Test]
		public void GetIfEntry2Test()
		{
			var row = new MIB_IF_ROW2(primaryAdapter.IfIndex);
			Assert.That(GetIfEntry2(ref row), Is.Zero);
			Assert.That(row.InterfaceLuid, Is.EqualTo(primaryAdapter.Luid));
		}

		[Test]
		public void GetIfStackTableTest()
		{
			Assert.That(GetIfStackTable(out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);
		}

		[Test]
		public void GetIfTable2ExTest()
		{
			var e = GetIfTable2Ex(MIB_IF_TABLE_LEVEL.MibIfTableNormal, out var itbl);
			Assert.That(e.Succeeded);
			Assert.That(itbl.Table, Is.Not.Empty);
			itbl.Dispose();
			Assert.That(itbl.IsInvalid);
		}

		[Test]
		public void GetIfTable2Test()
		{
			var e = GetIfTable2(out var itbl);
			Assert.That(e.Succeeded);
			Assert.That(itbl.Table, Is.Not.Empty);
			itbl.Dispose();
			Assert.That(itbl.IsInvalid);
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
		public void GetInvertedIfStackTableTest()
		{
			Assert.That(GetInvertedIfStackTable(out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);
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
		public void GetIpForwardEntryTable2Test()
		{
			Assert.That(GetIpForwardTable2(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);

			var goodRow = table.Table[0];
			var row = new MIB_IPFORWARD_ROW2 { DestinationPrefix = goodRow.DestinationPrefix, NextHop = goodRow.NextHop, InterfaceLuid = goodRow.InterfaceLuid };
			Assert.That(GetIpForwardEntry2(ref row), Is.Zero);
			Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
		}

		[Test]
		public void GetIpInterfaceEntryTableTest()
		{
			Assert.That(GetIpInterfaceTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);

			var goodRow = table.Table[0];
			var row = new MIB_IPINTERFACE_ROW { Family = goodRow.Family, InterfaceLuid = goodRow.InterfaceLuid };
			Assert.That(GetIpInterfaceEntry(ref row), Is.Zero);
			Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
		}

		[Test]
		public void GetIpNetEntryTable2Test()
		{
			Assert.That(GetIpNetTable2(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);

			var goodRow = table.Table[0];
			var row = new MIB_IPNET_ROW2 { Address = goodRow.Address, InterfaceLuid = goodRow.InterfaceLuid };
			Assert.That(GetIpNetEntry2(ref row), Is.Zero);
			Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
		}

		[Test]
		public void GetIpNetworkConnectionBandwidthEstimatesTest()
		{
			Assert.That(GetIpNetworkConnectionBandwidthEstimates(primaryAdapter.IfIndex, ADDRESS_FAMILY.AF_INET, out var est), Is.Zero);
			Assert.That(est.InboundBandwidthInformation.Bandwidth, Is.GreaterThan(0));
			Assert.That(est.OutboundBandwidthInformation.Bandwidth, Is.GreaterThan(0));
		}

		[Test]
		public void GetIpPathEntryTableTest()
		{
			Assert.That(GetIpPathTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);

			var goodRow = table.Table[0];
			var row = new MIB_IPPATH_ROW { Destination = goodRow.Destination, InterfaceLuid = goodRow.InterfaceLuid };
			Assert.That(GetIpPathEntry(ref row), Is.Zero);
			Assert.That((int)row.Source.si_family, Is.Not.Zero);
		}

		[Test]
		public void GetMulticastIpAddressEntryTableTest()
		{
			Assert.That(GetMulticastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);

			var goodRow = table.Table[0];
			var row = new MIB_MULTICASTIPADDRESS_ROW { Address = goodRow.Address, InterfaceLuid = goodRow.InterfaceLuid };
			Assert.That(GetMulticastIpAddressEntry(ref row), Is.Zero);
			Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
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
		public void GetTeredoPortTest()
		{
			Assert.That(GetTeredoPort(out var port), Is.Zero.Or.EqualTo(Win32Error.ERROR_NOT_READY));
		}

		[Test]
		public void GetUnicastIpAddressEntryTableTest()
		{
			Assert.That(GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), Is.Zero);
			Assert.That(table.NumEntries, Is.GreaterThan(0));
			Assert.That(() => table.Table, Throws.Nothing);

			var goodRow = table.Table[0];
			var row = new MIB_UNICASTIPADDRESS_ROW { Address = goodRow.Address, InterfaceLuid = goodRow.InterfaceLuid };
			Assert.That(GetUnicastIpAddressEntry(ref row), Is.Zero);
			Assert.That(row.CreationTimeStamp, Is.Not.Zero.And.EqualTo(goodRow.CreationTimeStamp));
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
		public void if_indextonameANDif_nametoindexTest()
		{
			var sb = new StringBuilder(IF_MAX_STRING_SIZE, IF_MAX_STRING_SIZE);
			Assert.That(if_indextoname(primaryAdapter.IfIndex, sb), Is.Not.EqualTo(IntPtr.Zero));
			TestContext.WriteLine(sb);
			Assert.That(if_nametoindex(sb.ToString()), Is.EqualTo(primaryAdapter.IfIndex));
		}

		[Test]
		public void InitializeIpForwardEntryTest()
		{
			InitializeIpForwardEntry(out var entry);
			Assert.That(entry.ValidLifetime, Is.Not.Zero);
			Assert.That(entry.Loopback, Is.True);
		}

		[Test]
		public void InitializeIpInterfaceEntryTest()
		{
			InitializeIpInterfaceEntry(out var entry);
			Assert.That((int)entry.Family, Is.Zero);
			Assert.That(entry.InterfaceIdentifier, Is.Not.Zero);
			Assert.That(entry.SupportsNeighborDiscovery, Is.True);
		}

		[Test]
		public void InitializeUnicastIpAddressEntryTest()
		{
			InitializeUnicastIpAddressEntry(out var entry);
			Assert.That(entry.ValidLifetime, Is.Not.Zero);
			Assert.That(entry.PrefixOrigin, Is.EqualTo(NL_PREFIX_ORIGIN.IpPrefixOriginUnchanged));
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
		public void NotifyAddrChangeTest()
		{
			Assert.Fail();
		}

		[Test]
		public void NotifyIpInterfaceChangeTest()
		{
			var fired = new ManualResetEvent(false);
			var done = new ManualResetEvent(false);
			new Thread(() =>
			{
				try
				{
					Assert.That(NotifyIpInterfaceChange(ADDRESS_FAMILY.AF_UNSPEC, NotifyFunc, NotifyData, true, out var hNot), Is.Zero);
					fired.WaitOne(3000);
					Assert.That(CancelMibChangeNotify2(hNot), Is.Zero);
				}
				finally
				{
					done.Set();
				}
			}).Start();
			Assert.That(done.WaitOne(5000), Is.True);

			void NotifyFunc(IntPtr CallerContext, IntPtr Row, MIB_NOTIFICATION_TYPE NotificationType)
			{
				Assert.That(CallerContext, Is.EqualTo(NotifyData));
				TestContext.WriteLine(Row.ToString());
				Assert.That(NotificationType, Is.EqualTo(MIB_NOTIFICATION_TYPE.MibInitialNotification));
				fired.Set();
			}
		}

		[Test]
		public void NotifyRouteChange2Test()
		{
			var fired = new ManualResetEvent(false);
			var done = new ManualResetEvent(false);
			new Thread(() =>
			{
				try
				{
					Assert.That(NotifyRouteChange2(ADDRESS_FAMILY.AF_UNSPEC, NotifyFunc, NotifyData, true, out var hNot), Is.Zero);
					fired.WaitOne(3000);
					Assert.That(CancelMibChangeNotify2(hNot), Is.Zero);
				}
				finally
				{
					done.Set();
				}
			}).Start();
			Assert.That(done.WaitOne(5000), Is.True);

			void NotifyFunc(IntPtr CallerContext, ref MIB_IPFORWARD_ROW2 Row, MIB_NOTIFICATION_TYPE NotificationType)
			{
				Assert.That(CallerContext, Is.EqualTo(NotifyData));
				TestContext.WriteLine(Row.ToString());
				Assert.That(NotificationType, Is.EqualTo(MIB_NOTIFICATION_TYPE.MibInitialNotification));
				fired.Set();
			}
		}

		[Test]
		public void NotifyRouteChangeTest()
		{
			Assert.Fail();
		}

		[Test]
		public void NotifyStableUnicastIpAddressTableTest()
		{
			var fired = new ManualResetEvent(false);
			var done = new ManualResetEvent(false);
			new Thread(() =>
			{
				try
				{
					Assert.That(NotifyStableUnicastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table, NotifyFunc, NotifyData, out var hNot), Is.Zero.Or.EqualTo(Win32Error.ERROR_IO_PENDING));
					if (table == IntPtr.Zero)
					{
						fired.WaitOne(3000);
						Assert.That(CancelMibChangeNotify2(hNot), Is.Zero);
					}
				}
				finally
				{
					done.Set();
				}
			}).Start();
			Assert.That(done.WaitOne(5000), Is.True);

			void NotifyFunc(IntPtr CallerContext, IntPtr Table)
			{
				Assert.That(CallerContext, Is.EqualTo(NotifyData));
				TestContext.WriteLine(Table.ToString());
				fired.Set();
			}
		}

		[Test]
		public void NotifyTeredoPortChangeTest()
		{
			var fired = new ManualResetEvent(false);
			var done = new ManualResetEvent(false);
			new Thread(() =>
			{
				try
				{
					Assert.That(NotifyTeredoPortChange(NotifyFunc, NotifyData, true, out var hNot), Is.Zero);
					fired.WaitOne(3000);
					Assert.That(CancelMibChangeNotify2(hNot), Is.Zero);
				}
				finally
				{
					done.Set();
				}
			}).Start();
			Assert.That(done.WaitOne(5000), Is.True);

			void NotifyFunc(IntPtr CallerContext, ushort Port, MIB_NOTIFICATION_TYPE NotificationType)
			{
				Assert.That(CallerContext, Is.EqualTo(NotifyData));
				TestContext.WriteLine(Port.ToString());
				Assert.That(NotificationType, Is.EqualTo(MIB_NOTIFICATION_TYPE.MibInitialNotification));
				fired.Set();
			}
		}

		[Test]
		public void NotifyUnicastIpAddressChangeTest()
		{
			var fired = new ManualResetEvent(false);
			var done = new ManualResetEvent(false);
			new Thread(() =>
			{
				try
				{
					Assert.That(NotifyUnicastIpAddressChange(ADDRESS_FAMILY.AF_UNSPEC, NotifyFunc, NotifyData, true, out var hNot), Is.Zero);
					fired.WaitOne(3000);
					Assert.That(CancelMibChangeNotify2(hNot), Is.Zero);
				}
				finally
				{
					done.Set();
				}
			}).Start();
			Assert.That(done.WaitOne(5000), Is.True);

			void NotifyFunc(IntPtr CallerContext, IntPtr Row, MIB_NOTIFICATION_TYPE NotificationType)
			{
				Assert.That(CallerContext, Is.EqualTo(NotifyData));
				TestContext.WriteLine(Row.ToString());
				Assert.That(NotificationType, Is.EqualTo(MIB_NOTIFICATION_TYPE.MibInitialNotification));
				fired.Set();
			}
		}

		[Test]
		public void ResolveIpNetEntry2Test()
		{
			var e = new MIB_IPNET_ROW2(new SOCKADDR_IN(new IN_ADDR(192, 168, 0, 202)), primaryAdapter.IfIndex);
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

		[SetUp]
		public void Setup()
		{
			primaryAdapter = GetAdaptersAddresses(GetAdaptersAddressesFlags.GAA_FLAG_INCLUDE_GATEWAYS).FirstOrDefault(r => r.OperStatus == IF_OPER_STATUS.IfOperStatusUp && r.TunnelType == TUNNEL_TYPE.TUNNEL_TYPE_NONE);
		}
	}
}
 