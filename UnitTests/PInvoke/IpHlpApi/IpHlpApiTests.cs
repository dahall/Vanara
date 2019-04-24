using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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
	public partial class IpHlpApiTests
	{
		private static readonly IntPtr NotifyData = new IntPtr(8943934);
		private static SOCKADDR_IN localv4;
		private static SOCKADDR_IN6 localv6;
		private static IP_ADAPTER_ADDRESSES primaryAdapter;
		private static SOCKADDR_IN LocalAddrV4 => localv4.sin_family == 0 ? (localv4 = primaryAdapter.UnicastAddresses.Select(r => r.Address.GetSOCKADDR()).First(a => a.si_family == ADDRESS_FAMILY.AF_INET).Ipv4) : localv4;
		private static SOCKADDR_IN6 LocalAddrV6 => localv6.sin6_family == 0 ? (localv6 = primaryAdapter.UnicastAddresses.Select(r => r.Address.GetSOCKADDR()).First(a => a.si_family == ADDRESS_FAMILY.AF_INET6).Ipv6) : localv6;

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
		public void CreateDelPersistentTcpPortReservationTest()
		{
			const ushort start = 5000;
			const ushort num = 20;
			Assert.That(CreatePersistentTcpPortReservation(start, num, out var tok), Is.Zero);
			Assert.That(LookupPersistentTcpPortReservation(start, num, out var tok2), Is.Zero);
			Assert.That(tok, Is.EqualTo(tok2));
			Assert.That(DeletePersistentTcpPortReservation(start, num), Is.Zero);
		}

		[Test]
		public void CreateDelPersistentUdpPortReservationTest()
		{
			const ushort start = 5000;
			const ushort num = 20;
			Assert.That(CreatePersistentUdpPortReservation(start, num, out var tok), Is.Zero);
			Assert.That(LookupPersistentUdpPortReservation(start, num, out var tok2), Is.Zero);
			Assert.That(tok, Is.EqualTo(tok2));
			Assert.That(DeletePersistentUdpPortReservation(start, num), Is.Zero);
		}

		// [Test] TODO - Figure out which parameters work
		public void CreateDelProxyArpEntryTest()
		{
			var target = primaryAdapter.MulticastAddresses.First().Address.GetSOCKADDR().Ipv4.sin_addr; // new IN_ADDR(192, 168, 0, 202);
			uint a = target.S_addr, m = 0x00FFFFFF, i = primaryAdapter.IfIndex;
			Assert.That(CreateProxyArpEntry(a, m, i), Is.Zero);
			Assert.That(DeleteProxyArpEntry(a, m, i), Is.Zero);
		}

		[Test]
		public void CreateSetDeleteIpForwardEntryTest()
		{
			Assert.That(() =>
			{
				MIB_IPFORWARDROW row = default;
				foreach (var rrow in GetIpForwardTable(true).Where(r => r.dwForwardDest == 0))
				{
					if (row.dwForwardType == 0) row = rrow;
					DeleteIpForwardEntry(rrow).ThrowIfFailed();
				}

				row.dwForwardNextHop = 0xDDBBCCAA;
				CreateIpForwardEntry(row).ThrowIfFailed();

				//row.dwForwardProto = MIB_IPFORWARD_PROTO.MIB_IPPROTO_DHCP;
				SetIpForwardEntry(row).ThrowIfFailed();

				DeleteIpForwardEntry(row).ThrowIfFailed();
			}, Throws.Nothing);
		}

		[Test]
		public void CreateSetDeleteIpNetEntryTest()
		{
			var target = new IN_ADDR(192, 168, 0, 202);
			Assert.That(GetBestRoute(target, 0, out var fwdRow), Is.Zero);
			var mibrow = new MIB_IPNETROW(target, fwdRow.dwForwardIfIndex, SendARP(target), MIB_IPNET_TYPE.MIB_IPNET_TYPE_DYNAMIC);

			MIB_IPNETTABLE t1 = null;
			Assert.That(() => t1 = GetIpNetTable(true), Throws.Nothing);
			if (t1 != null && HasVal(t1, mibrow))
				Assert.That(DeleteIpNetEntry(mibrow), Is.Zero);

			Assert.That(CreateIpNetEntry(mibrow), Is.Zero);
			var t = GetIpNetTable(true);
			Assert.That(HasVal(t, mibrow), Is.True);

			Assert.That(SetIpNetEntry(mibrow), Is.Zero);

			Assert.That(DeleteIpNetEntry(mibrow), Is.Zero);
			var t3 = GetIpNetTable(true);
			Assert.That(HasVal(t3, mibrow), Is.False);

			bool HasVal(IEnumerable<MIB_IPNETROW> tb, MIB_IPNETROW r) =>
				tb.Any(tr => tr.dwAddr.S_addr == r.dwAddr.S_addr && tr.dwIndex == r.dwIndex && tr.bPhysAddr.SequenceEqual(r.bPhysAddr));
		}
		[Test]
		public void DisableRestoreMediaSenseTest()
		{
			var hEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset);
			var pOverLapped = new System.Threading.NativeOverlapped { EventHandle = hEvent.SafeWaitHandle.DangerousGetHandle() };
			unsafe
			{
				Assert.That(DisableMediaSense(out _, &pOverLapped), Is.Zero.Or.EqualTo(Win32Error.ERROR_IO_PENDING));
				Assert.That(RestoreMediaSense(&pOverLapped, out _), Is.Zero.Or.EqualTo(Win32Error.ERROR_IO_PENDING));
			}
		}

		[Test]
		public void EnableUnenableRouterTest()
		{
			var hEvent = new System.Threading.EventWaitHandle(false, System.Threading.EventResetMode.ManualReset);
			var pOverLapped = new System.Threading.NativeOverlapped { EventHandle = hEvent.SafeWaitHandle.DangerousGetHandle() };
			unsafe
			{
				Assert.That(EnableRouter(out _, &pOverLapped), Is.Zero.Or.EqualTo(Win32Error.ERROR_IO_PENDING));
				Assert.That(UnenableRouter(&pOverLapped, out _), Is.Zero.Or.EqualTo(Win32Error.ERROR_IO_PENDING));
			}
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
		public void GetAdapterOrderMapTest()
		{
			var map = GetAdapterOrderMap();
			Assert.That(map, Is.Not.Null);
			Assert.That(map.NumAdapters, Is.GreaterThan(0));
		}

		[Test]
		public void GetAdaptersAddressesTest()
		{
			Assert.That(() =>
			{
				foreach (var addrs in GetAdaptersAddresses(GetAdaptersAddressesFlags.GAA_FLAG_INCLUDE_PREFIX, ADDRESS_FAMILY.AF_UNSPEC))
				{
					TestContext.WriteLine($"{addrs.IfIndex}) {addrs.AdapterName} ({addrs.FriendlyName});{addrs.Description};MAC:{PhysicalAddressToString(addrs.PhysicalAddress)}");
					TestContext.WriteLine("  Uni:" + string.Join(";", addrs.UnicastAddresses.Select(a => a.Address)));
					TestContext.WriteLine("  Any:" + string.Join(";", addrs.AnycastAddresses.Select(a => a.Address)));
					TestContext.WriteLine("  MCS:" + string.Join(";", addrs.MulticastAddresses.Select(a => a.Address)));
					TestContext.WriteLine("  DNS:" + string.Join(";", addrs.DnsServerAddresses.Select(a => a.Address)));
					TestContext.WriteLine("  Prfx:" + string.Join(";", addrs.Prefixes.Select(a => a.Address)));
					TestContext.WriteLine("  WINS:" + string.Join(";", addrs.WinsServerAddresses.Select(a => a.Address)));
					TestContext.WriteLine("  GTWY:" + string.Join(";", addrs.GatewayAddresses.Select(a => a.Address)));
					TestContext.WriteLine("  Sufx:" + string.Join(";", addrs.DnsSuffixes.Select(a => a.String)));
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
		public void GetFriendlyIfIndexTest()
		{
			Assert.That(GetFriendlyIfIndex(primaryAdapter.IfIndex), Is.Not.Zero);
		}

		[Test]
		public void GetIcmpStatisticsTest()
		{
			Assert.That(GetIcmpStatistics(out var stat), Is.Zero);
			Assert.That(stat.stats.icmpInStats.dwMsgs, Is.Not.Zero);
			Assert.That(GetIcmpStatisticsEx(out var statx, ADDRESS_FAMILY.AF_INET), Is.Zero);
			Assert.That(statx.icmpInStats.dwMsgs, Is.Not.Zero);
		}

		[Test]
		public void GetIfTableTest()
		{
			Assert.That(() =>
			{
				var t = GetIfTable();
				Assert.That(t.dwNumEntries, Is.GreaterThan(0));
				foreach (var r in t)
				{
					var r2 = new MIB_IFROW(r.dwIndex);
					Assert.That(GetIfEntry(ref r2), Is.Zero);
					Assert.That(r.wszName, Is.EqualTo(r2.wszName));
					Assert.That(SetIfEntry(r2), Is.Zero);
				}
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
		public void GetIpErrorStringTest()
		{
			var sz = 1024U;
			var sb = new StringBuilder((int)sz);
			Assert.That(GetIpErrorString(Win32Error.ERROR_CAN_NOT_COMPLETE, sb, ref sz), Is.Zero);
			Assert.That(sb.Length, Is.GreaterThan(0));
		}

		[Test]
		public void GetSetIpStatisticsTest()
		{
			Assert.That(GetIpStatistics(out var stat), Is.Zero);
			Assert.That(stat.dwNumIf, Is.Not.Zero);

			var sstat = new MIB_IPSTATS { Forwarding = MIB_IPSTATS_FORWARDING.MIB_USE_CURRENT_FORWARDING, dwDefaultTTL = stat.dwDefaultTTL + 1 };
			Assert.That(SetIpStatisticsEx(sstat, ADDRESS_FAMILY.AF_INET), Is.Zero);

			Assert.That(GetIpStatisticsEx(out var statx, ADDRESS_FAMILY.AF_INET), Is.Zero);
			Assert.That(statx.dwDefaultTTL, Is.EqualTo(stat.dwDefaultTTL + 1));

			sstat.dwDefaultTTL = stat.dwDefaultTTL;
			Assert.That(SetIpStatistics(sstat), Is.Zero);
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
		public void GetNumberOfInterfacesTest()
		{
			Assert.That(GetNumberOfInterfaces(out var num), Is.Zero);
			Assert.That(num, Is.GreaterThan(0));
		}

		[Test]
		public void GetOwnerModuleFromPidAndInfoTest()
		{
			foreach (var om in GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL, ADDRESS_FAMILY.AF_INET6))
			{
				uint sz = 0;
				var err = GetOwnerModuleFromPidAndInfo(om.dwOwningPid, om.OwningModuleInfo, TCPIP_OWNER_MODULE_INFO_CLASS.TCPIP_OWNER_MODULE_INFO_BASIC, IntPtr.Zero, ref sz);
				TestContext.WriteLine($"{om.dwOwningPid} {string.Join(":", om.OwningModuleInfo)} {sz} {err}");
			}
		}

		[Test]
		public void GetOwnerModuleFromTcp6EntryTest()
		{
			Assert.That(() =>
			{
				foreach (var om in GetExtendedTcpTable<MIB_TCP6TABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL, ADDRESS_FAMILY.AF_INET6, true))
				{
					try
					{
						var info = GetOwnerModuleFromTcp6Entry(om);
						Assert.That(info.pModuleName, Is.Not.Null);
						TestContext.WriteLine($"{om.dwOwningPid} {om.ucLocalAddr}=>{om.ucRemoteAddr} {info.pModuleName}");
					}
					catch (Exception ex)
					{
						TestContext.WriteLine($"{om.dwOwningPid} {om.ucLocalAddr}=>{om.ucRemoteAddr} {ex.HResult}");
						//Assert.That(ex.HResult, Is.EqualTo(((Win32Error)Win32Error.ERROR_NOT_FOUND).ToHRESULT()));
					}
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetOwnerModuleFromTcpEntryTest()
		{
			Assert.That(() =>
			{
				foreach (var om in GetExtendedTcpTable<MIB_TCPTABLE_OWNER_MODULE>(TCP_TABLE_CLASS.TCP_TABLE_OWNER_MODULE_ALL, ADDRESS_FAMILY.AF_INET, true))
				{
					try
					{
						var info = GetOwnerModuleFromTcpEntry(om);
						Assert.That(info.pModuleName, Is.Not.Null);
						TestContext.WriteLine($"{om.dwOwningPid} {om.dwLocalAddr}=>{om.dwRemoteAddr} {info.pModuleName}");
					}
					catch (Exception ex)
					{
						TestContext.WriteLine($"{om.dwOwningPid} {om.dwLocalAddr}=>{om.dwRemoteAddr} {ex.HResult}");
						//Assert.That(ex.HResult, Is.EqualTo(((Win32Error)Win32Error.ERROR_NOT_FOUND).ToHRESULT()));
					}
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetOwnerModuleFromUdp6EntryTest()
		{
			Assert.That(() =>
			{
				foreach (var om in GetExtendedUdpTable<MIB_UDP6TABLE_OWNER_MODULE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE, ADDRESS_FAMILY.AF_INET6))
				{
					try
					{
						var info = GetOwnerModuleFromUdp6Entry(om);
						Assert.That(info.pModuleName, Is.Not.Null);
						TestContext.WriteLine($"{om.dwOwningPid} {om.ucLocalAddr} {info.pModuleName}");
					}
					catch (Exception ex)
					{
						TestContext.WriteLine($"{om.dwOwningPid} {om.ucLocalAddr} {ex.HResult}");
						//Assert.That(ex.HResult, Is.EqualTo(((Win32Error)Win32Error.ERROR_NOT_FOUND).ToHRESULT()));
					}
				}
			}, Throws.Nothing);
		}

		[Test]
		public void GetOwnerModuleFromUdpEntryTest()
		{
			Assert.That(() =>
			{
				foreach (var om in GetExtendedUdpTable<MIB_UDPTABLE_OWNER_MODULE>(UDP_TABLE_CLASS.UDP_TABLE_OWNER_MODULE, ADDRESS_FAMILY.AF_INET))
				{
					try
					{
						var info = GetOwnerModuleFromUdpEntry(om);
						Assert.That(info.pModuleName, Is.Not.Null);
						TestContext.WriteLine($"{om.dwOwningPid} {om.dwLocalAddr} {info.pModuleName}");
					}
					catch (Exception ex)
					{
						TestContext.WriteLine($"{om.dwOwningPid} {om.dwLocalAddr} {ex.HResult}");
						//Assert.That(ex.HResult, Is.EqualTo(((Win32Error)Win32Error.ERROR_NOT_FOUND).ToHRESULT()));
					}
				}
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
		public void GetPerTcp6ConnectionEStatsTest()
		{
			var addr = LocalAddrV6.sin6_addr;
			var row = GetTcp6Table(true).First(r => r.LocalAddr == addr && r.dwLocalPort != 0 && r.dwRemotePort != 0);
			ToggleAllEstats(row, true);
			foreach (TCP_ESTATS_TYPE type in Enum.GetValues(typeof(TCP_ESTATS_TYPE)))
			{
				if (type == TCP_ESTATS_TYPE.TcpConnectionEstatsSynOpts) continue;
				Assert.That(GetPerTcp6ConnectionEStats(row, type, out var srw, out _, out _), Is.Zero);
				Console.Write(GetStats(srw));
			}
			ToggleAllEstats(row, false);
		}

		[Test]
		public void GetPerTcpConnectionEStatsTest()
		{
			var addr = LocalAddrV4.sin_addr;
			var row = GetTcpTable(true).First(r => r.dwLocalAddr == addr && r.dwLocalPort != 0 && r.dwRemotePort != 0);
			ToggleAllEstats(row, true);
			foreach (TCP_ESTATS_TYPE type in Enum.GetValues(typeof(TCP_ESTATS_TYPE)))
			{
				if (type == TCP_ESTATS_TYPE.TcpConnectionEstatsSynOpts) continue;
				Assert.That(GetPerTcpConnectionEStats(row, type, out var srw, out _, out _), Is.Zero);
				Console.Write(GetStats(srw));
			}
			ToggleAllEstats(row, false);
		}

		[Test]
		public void GetRTTAndHopCountTest()
		{
			var target = new IN_ADDR(192, 168, 0, 202);
			Assert.That(GetRTTAndHopCount(target, out var hops, uint.MaxValue, out var rtt), Is.True);
			TestContext.WriteLine($"{target}: hops={hops} rtt={rtt}");
			Assert.That(hops, Is.GreaterThan(0));
			Assert.That(rtt, Is.GreaterThanOrEqualTo(0));
		}

		[Test]
		public void GetTcpStatisticsTest()
		{
			Assert.That(GetTcpStatistics(out var stats), Is.Zero);
			Assert.That(stats.dwNumConns, Is.GreaterThan(0));
		}

		[Test]
		public void GetTcpStatisticsExTest()
		{
			Assert.That(GetTcpStatisticsEx(out var stats, ADDRESS_FAMILY.AF_INET), Is.Zero);
			Assert.That(stats.dwNumConns, Is.GreaterThan(0));
		}

		[Test]
		public void GetTcpStatisticsEx2Test()
		{
			Assert.That(GetTcpStatisticsEx2(out var stats, ADDRESS_FAMILY.AF_INET), Is.Zero);
			Assert.That(stats.dwNumConns, Is.GreaterThan(0));
		}

		[Test]
		public void GetUdpStatisticsTest()
		{
			Assert.That(GetUdpStatistics(out var stats), Is.Zero);
			Assert.That(stats.dwNumAddrs, Is.GreaterThan(0));
		}

		[Test]
		public void GetUdpStatisticsExTest()
		{
			Assert.That(GetUdpStatisticsEx(out var stats, ADDRESS_FAMILY.AF_INET), Is.Zero);
			Assert.That(stats.dwNumAddrs, Is.GreaterThan(0));
		}

		[Test]
		public void GetUdpStatisticsEx2Test()
		{
			Assert.That(GetUdpStatisticsEx2(out var stats, ADDRESS_FAMILY.AF_INET), Is.Zero);
			Assert.That(stats.dwNumAddrs, Is.GreaterThan(0));
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
		public void IpReleaseRenewAddressTest()
		{
			var i = GetInterfaceInfo().First();
			Assert.That(IpReleaseAddress(ref i), Is.Zero);
			Assert.That(IpRenewAddress(ref i), Is.Zero);
			var x = new IP_ADAPTER_INDEX_MAP() { Name = "Bogus" };
			Assert.That(IpReleaseAddress(ref x), Is.EqualTo(Win32Error.ERROR_INVALID_PARAMETER));
			Assert.That(IpRenewAddress(ref x), Is.EqualTo(Win32Error.ERROR_INVALID_PARAMETER));
		}

		// TODO: [Test]
		public void NotifyAddrChangeTest()
		{
			throw new NotImplementedException();
		}

		// TODO: [Test]
		public void NotifyRouteChangeTest()
		{
			throw new NotImplementedException();
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
			primaryAdapter = GetAdaptersAddresses(GetAdaptersAddressesFlags.GAA_FLAG_INCLUDE_GATEWAYS).FirstOrDefault(r => r.OperStatus == IF_OPER_STATUS.IfOperStatusUp && r.TunnelType == TUNNEL_TYPE.TUNNEL_TYPE_NONE && r.FirstGatewayAddress != IntPtr.Zero);
		}

		private static Win32Error CreateTcpConnection(bool v6, out SafeSOCKET serviceSocket, out SafeSOCKET clientSocket, out SOCKET acceptSocket, out ushort serverPort, out ushort clientPort)
		{
			Win32Error status;
			var aiFamily = v6 ? ADDRESS_FAMILY.AF_INET6 : ADDRESS_FAMILY.AF_INET;
			var hints = new ADDRINFOW
			{
				ai_family = aiFamily,
				ai_socktype = SOCK.SOCK_STREAM,
				ai_protocol = IPPROTO.IPPROTO_TCP
			};
			var loopback = v6 ? "::1" : "127.0.0.1";

			serviceSocket = SafeSOCKET.INVALID_SOCKET;
			clientSocket = SafeSOCKET.INVALID_SOCKET;
			acceptSocket = SOCKET.INVALID_SOCKET;
			serverPort = clientPort = 0;

			status = GetAddrInfoW(loopback, "", hints, out var result);
			if (status.Failed)
				goto bail;

			using (result)
			{
				var localhost = result.FirstOrDefault();

				serviceSocket = socket(aiFamily, SOCK.SOCK_STREAM, IPPROTO.IPPROTO_TCP);
				clientSocket = socket(aiFamily, SOCK.SOCK_STREAM, IPPROTO.IPPROTO_TCP);
				if (serviceSocket == SOCKET.INVALID_SOCKET || clientSocket == SOCKET.INVALID_SOCKET)
					goto bail;

				status = bind(serviceSocket, localhost.addr, localhost.ai_addrlen);
				if (status.Failed)
					goto bail;
			}

			var serverSockName = SOCKADDR.Empty;
			var nameLen = serverSockName.Size;
			status = getsockname(serviceSocket, serverSockName, ref nameLen);
			if (status.Failed)
				goto bail;
			serverPort = v6 ? ((SOCKADDR_IN6)serverSockName).sin6_port : ((SOCKADDR_IN)serverSockName).sin_port;

			status = listen(serviceSocket, SOMAXCONN);
			if (status.Failed)
				goto bail;

			status = connect(clientSocket, serverSockName, nameLen);
			if (status.Failed)
				goto bail;

			var clientSockName = SOCKADDR.Empty;
			nameLen = clientSockName.Size;
			status = getsockname(clientSocket, clientSockName, ref nameLen);
			if (status.Failed)
				goto bail;

			clientPort = v6 ? ((SOCKADDR_IN6)clientSockName).sin6_port : ((SOCKADDR_IN)clientSockName).sin_port;

			acceptSocket = accept(serviceSocket);
			if (acceptSocket == SOCKET.INVALID_SOCKET)
				goto bail;

			return Win32Error.ERROR_SUCCESS;

		bail:
			return status == -1 ? WSAGetLastError() : status;
		}

		private static SafeAllocatedMemoryHandle GetRwForType(TCP_ESTATS_TYPE type, bool enable)
		{
			switch (type)
			{
				case TCP_ESTATS_TYPE.TcpConnectionEstatsData:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_DATA_RW_v0 { EnableCollection = enable });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsSndCong:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_SND_CONG_RW_v0 { EnableCollection = enable });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsPath:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_PATH_RW_v0 { EnableCollection = enable });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsSendBuff:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_SEND_BUFF_RW_v0 { EnableCollection = enable });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsRec:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_REC_RW_v0 { EnableCollection = enable });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsObsRec:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_OBS_REC_RW_v0 { EnableCollection = enable });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsBandwidth:
					var operation = enable ? TCP_BOOLEAN_OPTIONAL.TcpBoolOptEnabled : TCP_BOOLEAN_OPTIONAL.TcpBoolOptDisabled;
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_BANDWIDTH_RW_v0 { EnableCollectionInbound = operation, EnableCollectionOutbound = operation });
				case TCP_ESTATS_TYPE.TcpConnectionEstatsFineRtt:
					return SafeHGlobalHandle.CreateFromStructure(new TCP_ESTATS_FINE_RTT_RW_v0 { EnableCollection = enable });
				default:
					return null;
			}
		}

		private static string GetStats(object rw)
		{
			var sb = new StringBuilder();
			foreach (var fi in rw.GetType().GetFields())
				sb.AppendLine($"{rw.GetType().Name}.{fi.Name} = {fi.GetValue(rw)}");
			return sb.ToString();
		}

		private static void ToggleAllEstats(in MIB_TCP6ROW row, bool enable)
		{
			foreach (TCP_ESTATS_TYPE type in Enum.GetValues(typeof(TCP_ESTATS_TYPE)))
			{
				using (var mem = GetRwForType(type, enable))
					if (mem != null)
						SetPerTcp6ConnectionEStats(row, type, (IntPtr)mem, 0, (uint)mem.Size, 0);
			}
		}

		private static void ToggleAllEstats(in MIB_TCPROW row, bool enable)
		{
			foreach (TCP_ESTATS_TYPE type in Enum.GetValues(typeof(TCP_ESTATS_TYPE)))
			{
				using (var mem = GetRwForType(type, enable))
					if (mem != null)
						SetPerTcpConnectionEStats(row, type, (IntPtr)mem, 0, (uint)mem.Size, 0);
			}
		}

		//[Test] -- BROKEN
		private void BrokenGetPerTcp6ConnectionEStatsTest()
		{
			CreateTcpConnection(true, out var serviceSocket, out var clientSocket, out var acceptSocket, out var serverPort, out var clientPort).ThrowIfFailed();
			var serverConnectRow = GetTcp6Row(serverPort, clientPort, MIB_TCP_STATE.MIB_TCP_STATE_ESTAB);
			var clientConnectRow = GetTcp6Row(clientPort, serverPort, MIB_TCP_STATE.MIB_TCP_STATE_ESTAB);
			ToggleAllEstats(serverConnectRow, true);
			ToggleAllEstats(clientConnectRow, true);
			foreach (TCP_ESTATS_TYPE type in Enum.GetValues(typeof(TCP_ESTATS_TYPE)))
			{
				if (type == TCP_ESTATS_TYPE.TcpConnectionEstatsSynOpts) continue;
				Assert.That(GetPerTcp6ConnectionEStats(serverConnectRow, type, out var srw, out _, out _), Is.Zero);
				Console.Write(GetStats(srw));
				Assert.That(GetPerTcp6ConnectionEStats(clientConnectRow, type, out var crw, out _, out _), Is.Zero);
				Console.Write(GetStats(crw));
			}
		}
		private MIB_TCP6ROW GetTcp6Row(ushort localPort, ushort remotePort, MIB_TCP_STATE state) =>
			GetTcp6Table(true).First(r => r.dwLocalPort == localPort && r.dwRemotePort == remotePort && r.dwState == state);

		private MIB_TCPROW GetTcpRow(ushort localPort, ushort remotePort, MIB_TCP_STATE state) =>
					GetTcpTable(true).First(r => r.dwLocalPort == localPort && r.dwRemotePort == remotePort && r.dwState == state);
	}
}