using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Vanara.PInvoke.IpHlpApi;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke.Tests;

public partial class IpHlpApiTests
{
	[Test]
	public void ConversionTests()
	{
		var luid = primaryAdapter.Luid;
		const int sblen = 1024;
		var sb = new StringBuilder(sblen, sblen);

		Assert.That(ConvertInterfaceLuidToAlias(luid, sb, sblen), ResultIs.Successful);
		Assert.That(sb.ToString(), Is.EqualTo(primaryAdapter.FriendlyName));
		var alias = sb.ToString();
		TestContext.WriteLine($"LUID=>Alias = {alias}");

		Assert.That(ConvertInterfaceLuidToGuid(luid, out var ifGuid), ResultIs.Successful);
		Assert.That(ifGuid, Is.EqualTo(Guid.Parse(primaryAdapter.AdapterName)));
		TestContext.WriteLine($"LUID=>GUID = {ifGuid}");

		Assert.That(ConvertInterfaceLuidToIndex(luid, out var ifIdx), ResultIs.Successful);
		Assert.That(ifIdx, Is.EqualTo(primaryAdapter.IfIndex));
		TestContext.WriteLine($"LUID=>Idx = {ifIdx}");

		sb.Clear();
		Assert.That(ConvertInterfaceLuidToName(luid, sb, sblen), ResultIs.Successful);
		var name = sb.ToString();
		TestContext.WriteLine($"LUID=>Name = {name}");

		Assert.That(ConvertInterfaceAliasToLuid(alias, out var luid2), ResultIs.Successful);
		Assert.That(luid2, Is.EqualTo(luid));

		Assert.That(ConvertInterfaceGuidToLuid(ifGuid, out luid2), ResultIs.Successful);
		Assert.That(luid2, Is.EqualTo(luid));

		Assert.That(ConvertInterfaceIndexToLuid(ifIdx, out luid2), ResultIs.Successful);
		Assert.That(luid2, Is.EqualTo(luid));

		Assert.That(ConvertInterfaceNameToLuid(name, out luid2), ResultIs.Successful);
		Assert.That(luid2, Is.EqualTo(luid));

		uint mask = 0x00FFFFFF; // 255.255.255.0
		Assert.That(ConvertIpv4MaskToLength(mask, out var maskLen), ResultIs.Successful);
		Assert.That(maskLen, Is.EqualTo(24));
		Assert.That(ConvertLengthToIpv4Mask(maskLen, out var mask2), ResultIs.Successful);
		Assert.That(mask2, Is.EqualTo(mask));
	}

	[Test]
	public void CreateGetDeleteAnycastIpAddressEntryTest()
	{
		var mibrow = new MIB_ANYCASTIPADDRESS_ROW(GetV6Addr(), primaryAdapter.Luid);
		Assert.That(GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t1), ResultIs.Successful);
		if (t1.Contains(mibrow))
			Assert.That(DeleteAnycastIpAddressEntry(ref mibrow), ResultIs.Successful);

		Assert.That(CreateAnycastIpAddressEntry(ref mibrow), ResultIs.Successful);
		GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t2);
		Assert.That(t2, Has.Member(mibrow));

		Assert.That(GetAnycastIpAddressEntry(ref mibrow), ResultIs.Successful);

		Assert.That(DeleteAnycastIpAddressEntry(ref mibrow), ResultIs.Successful);
		GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t3);
		Assert.That(t3, Has.No.Member(mibrow));
	}

	[Test]
	public void CreateSetDeleteIpForwardEntry2Test()
	{
		var mibrow = new MIB_IPFORWARD_ROW2(new IP_ADDRESS_PREFIX((SOCKADDR_IN6)IN6_ADDR.Unspecified, 128), GetV6Addr(), primaryAdapter.Luid)
		{
			Protocol = MIB_IPFORWARD_PROTO.MIB_IPPROTO_NETMGMT,
			Metric = 1
		};
		DeleteIpForwardEntry2(ref mibrow);

		Assert.That(CreateIpForwardEntry2(ref mibrow), ResultIs.Successful);

		mibrow.PreferredLifetime = 500000;
		Assert.That(SetIpForwardEntry2(mibrow), ResultIs.Successful);
		Assert.That(GetIpForwardEntry2(ref mibrow), ResultIs.Successful);

		Assert.That(DeleteIpForwardEntry2(ref mibrow), ResultIs.Successful);
	}

	[Test]
	public void CreateSetDeleteIpNetEntry2Test()
	{
		var target = knwIP;
		Assert.That(GetBestRoute(target, 0, out var fwdRow), ResultIs.Successful);
		var mibrow = new MIB_IPNET_ROW2(new SOCKADDR_IN(target), fwdRow.dwForwardIfIndex, SendARP(target));
		Assert.That(GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out var t1), ResultIs.Successful);
		if (HasVal(t1, mibrow))
			Assert.That(DeleteIpNetEntry2(ref mibrow), ResultIs.Successful);

		Assert.That(CreateIpNetEntry2(ref mibrow), ResultIs.Successful);
		GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out var t2);
		Assert.That(HasVal(t2, mibrow), Is.True);

		Assert.That(DeleteIpNetEntry2(ref mibrow), ResultIs.Successful);
		GetIpNetTable2(ADDRESS_FAMILY.AF_INET, out var t3);
		Assert.That(HasVal(t3, mibrow), Is.False);

		bool HasVal(IEnumerable<MIB_IPNET_ROW2> t, MIB_IPNET_ROW2 r) =>
			t.Any(tr => tr.Address.Ipv4.sin_addr == r.Address.Ipv4.sin_addr && tr.InterfaceIndex == r.InterfaceIndex && tr.PhysicalAddress.SequenceEqual(r.PhysicalAddress));
	}

	[Test]
	public unsafe void CreateSetDeleteIpNetEntry2UnmanagedPointerTest()
	{
		var target = knwIP;
		Assert.That(GetBestRoute(target, 0, out var fwdRow), ResultIs.Successful);
		var mibrow = new MIB_IPNET_ROW2(new SOCKADDR_IN(target), fwdRow.dwForwardIfIndex, SendARP(target));
		Assert.That(GetIpNetTable2_Unmanaged(ADDRESS_FAMILY.AF_INET, out var t1), ResultIs.Successful);
		if (HasVal(t1.AsUnmanagedArrayPointer(), mibrow, t1.NumEntries))
			Assert.That(DeleteIpNetEntry2(ref mibrow), ResultIs.Successful);

		Assert.That(CreateIpNetEntry2(ref mibrow), ResultIs.Successful);
		GetIpNetTable2_Unmanaged(ADDRESS_FAMILY.AF_INET, out var t2);
		Assert.That(HasVal(t2.AsUnmanagedArrayPointer(), mibrow, t1.NumEntries), Is.True);

		Assert.That(DeleteIpNetEntry2(ref mibrow), ResultIs.Successful);
		GetIpNetTable2_Unmanaged(ADDRESS_FAMILY.AF_INET, out var t3);
		Assert.That(HasVal(t3.AsUnmanagedArrayPointer(), mibrow, t1.NumEntries), Is.False);

		static bool HasVal(MIB_IPNET_ROW2_Unmanaged* tr, MIB_IPNET_ROW2 r, uint numEntries)
		{
			for (uint i = 0; i < numEntries; i++, tr++)
			{
				if (tr->Address.Ipv4.sin_addr == r.Address.Ipv4.sin_addr &&
					tr->InterfaceIndex == r.InterfaceIndex &&
					CompareArrays(tr->PhysicalAddress, r.PhysicalAddress))
				{
					return true;
				}
			}

			return false;
		}

		static bool CompareArrays(byte* left, byte[] right) => !right.Where((t, i) => left[i] != t).Any();
	}

	[Test]
	public void CreateSetDeleteIpNetEntry2UnmanagedSpanTest()
	{
		var target = knwIP;
		Assert.That(GetBestRoute(target, 0, out var fwdRow), ResultIs.Successful);
		var mibrow = new MIB_IPNET_ROW2(new SOCKADDR_IN(target), fwdRow.dwForwardIfIndex, SendARP(target));
		Assert.That(GetIpNetTable2_Unmanaged(ADDRESS_FAMILY.AF_INET, out var t1), ResultIs.Successful);
		if (HasVal(ref t1, mibrow))
			Assert.That(DeleteIpNetEntry2(ref mibrow), ResultIs.Successful);

		Assert.That(CreateIpNetEntry2(ref mibrow), ResultIs.Successful);
		GetIpNetTable2_Unmanaged(ADDRESS_FAMILY.AF_INET, out var t2);
		Assert.That(HasVal(ref t2, mibrow), Is.True);

		Assert.That(DeleteIpNetEntry2(ref mibrow), ResultIs.Successful);
		GetIpNetTable2_Unmanaged(ADDRESS_FAMILY.AF_INET, out var t3);
		Assert.That(HasVal(ref t3, mibrow), Is.False);

		static bool HasVal(ref MIB_IPNET_TABLE2_Unmanaged t, MIB_IPNET_ROW2 r)
		{
			foreach (ref MIB_IPNET_ROW2_Unmanaged tr in t)
			{
				unsafe
				{
					fixed (byte* physicalAddress = tr.PhysicalAddress)
					{
						if (tr.Address.Ipv4.sin_addr == r.Address.Ipv4.sin_addr &&
							tr.InterfaceIndex == r.InterfaceIndex &&
							CompareArrays(physicalAddress, r.PhysicalAddress))
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		static unsafe bool CompareArrays(byte* left, byte[] right) => !right.Where((t, i) => left[i] != t).Any();
	}

	[Test]
	public void CreateSetGetDeleteUnicastIpAddressEntryTest()
	{
		Assert.That(GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t1), ResultIs.Successful);
		var mibrow = t1.First();
		Assert.That(DeleteUnicastIpAddressEntry(ref mibrow), ResultIs.Successful);

		Assert.That(CreateUnicastIpAddressEntry(ref mibrow), ResultIs.Successful);
		GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t2);
		Assert.That(t2, Has.Member(mibrow));

		mibrow.PreferredLifetime = 500000;
		Assert.That(SetUnicastIpAddressEntry(mibrow), ResultIs.Successful);
		Assert.That(GetUnicastIpAddressEntry(ref mibrow), ResultIs.Successful);

		Assert.That(DeleteUnicastIpAddressEntry(ref mibrow), ResultIs.Successful);
		GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_INET6, out var t4);
		Assert.That(t4, Has.No.Member(mibrow));
	}

	[Test]
	public void CreateSortedAddressPairsTest()
	{
		// var dest = primaryAdapter.MulticastAddresses.Select(ma => ma.Address.GetSOCKADDR().Ipv6).ToArray();
		var destRaw = primaryAdapter.MulticastAddresses.ToArray();
		var destAll = Array.ConvertAll(destRaw, i => i.Address.GetSOCKADDR());
		var dest = destAll.Select(i => i.Ipv6).ToArray();
		TestContext.WriteLine(string.Join("\r\n", dest));
		SOCKADDR_IN6_PAIR_NATIVE[]? result = null;
		Assert.That(() => result = CreateSortedAddressPairs(dest), Throws.Nothing);
		TestContext.WriteLine("\r\n" + string.Join("\r\n", result!));
		Assert.That(result, Has.Length.GreaterThan(0));
	}

	[Test]
	public void FlushIpNetTable2Test()
	{
		Assert.That(FlushIpNetTable2(ADDRESS_FAMILY.AF_INET6, primaryAdapter.IfIndex), ResultIs.Successful);
	}

	[Test]
	public void FlushIpPathTableTest()
	{
		Assert.That(FlushIpPathTable(ADDRESS_FAMILY.AF_INET6), ResultIs.Successful);
	}

	[Test]
	public void GetAnycastIpAddressEntryTableTest()
	{
		Assert.That(GetAnycastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.Zero);

		var row = new MIB_ANYCASTIPADDRESS_ROW();
		Assert.That(GetAnycastIpAddressEntry(ref row), Is.Not.Zero);
	}

	[Test]
	public void GetBestRoute2Test()
	{
		var addr = new SOCKADDR_INET { Ipv4 = new SOCKADDR_IN(knwIP) };
		Assert.That(GetBestRoute2(IntPtr.Zero, primaryAdapter.IfIndex, IntPtr.Zero, addr, 0, out var rt, out var src), ResultIs.Successful);
		Assert.That(rt.InterfaceIndex, Is.EqualTo(primaryAdapter.IfIndex));
		Assert.That(src.si_family, Is.EqualTo(ADDRESS_FAMILY.AF_INET));
	}

	[Test]
	public void GetIfEntry2ExTest()
	{
		var row = new MIB_IF_ROW2(primaryAdapter.IfIndex);
		Assert.That(GetIfEntry2Ex(MIB_IF_ENTRY_LEVEL.MibIfEntryNormal, ref row), ResultIs.Successful);
		Assert.That(row.InterfaceLuid, Is.EqualTo(primaryAdapter.Luid));
	}

	[Test]
	public void GetIfEntry2Test()
	{
		var row = new MIB_IF_ROW2(primaryAdapter.IfIndex);
		Assert.That(GetIfEntry2(ref row), ResultIs.Successful);
		Assert.That(row.InterfaceLuid, Is.EqualTo(primaryAdapter.Luid));
	}

	[Test]
	public void GetIfStackTableTest()
	{
		Assert.That(GetIfStackTable(out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(table.Table!.Length, Is.EqualTo(table.NumEntries));
	}

	[Test]
	public void GetIfStackTable_Span_Test()
	{
		Assert.That(GetIfStackTable(out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(table.TableAsSpan.Length, Is.EqualTo(table.NumEntries));
	}

	[Test]
	public void GetIfTable2ExTest()
	{
		Assert.That(GetIfTable2Ex(MIB_IF_TABLE_LEVEL.MibIfTableNormal, out var itbl), ResultIs.Successful);
		Assert.That(itbl.Table!.Length, Is.GreaterThan(0));
		itbl.Dispose();
		Assert.That(itbl.IsInvalid);
	}

	[Test]
	public void GetIfTable2Test()
	{
		Assert.That(GetIfTable2(out var itbl), ResultIs.Successful);
		Assert.That(itbl.Table!.Length, Is.GreaterThan(0));
		itbl.Dispose();
		Assert.That(itbl.IsInvalid);
	}

	[Test]
	public void GetInvertedIfStackTableTest()
	{
		Assert.That(GetInvertedIfStackTable(out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);
	}

	[Test]
	public void GetIpForwardEntryTable2Test()
	{
		Assert.That(GetIpForwardTable2(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);

		var goodRow = table.Table![0];
		var row = new MIB_IPFORWARD_ROW2 { DestinationPrefix = goodRow.DestinationPrefix, NextHop = goodRow.NextHop, InterfaceLuid = goodRow.InterfaceLuid };
		Assert.That(GetIpForwardEntry2(ref row), ResultIs.Successful);
		Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
	}

	[Test]
	public void GetIpInterfaceEntryTableTest()
	{
		Assert.That(GetIpInterfaceTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);

		var goodRow = table.Table![0];
		var row = new MIB_IPINTERFACE_ROW { Family = goodRow.Family, InterfaceLuid = goodRow.InterfaceLuid };
		Assert.That(GetIpInterfaceEntry(ref row), ResultIs.Successful);
		Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
	}

	[Test]
	public void GetIpNetworkConnectionBandwidthEstimatesTest()
	{
		Assert.That(GetIpNetworkConnectionBandwidthEstimates(primaryAdapter.IfIndex, ADDRESS_FAMILY.AF_INET, out var est), ResultIs.Successful);
		Assert.That(est.InboundBandwidthInformation.Bandwidth, Is.GreaterThan(0));
		Assert.That(est.OutboundBandwidthInformation.Bandwidth, Is.GreaterThan(0));
	}

	[Test]
	public void GetIpPathEntryTableTest()
	{
		Assert.That(GetIpPathTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);

		var goodRow = table.Table![0];
		var row = new MIB_IPPATH_ROW { Destination = goodRow.Destination, InterfaceLuid = goodRow.InterfaceLuid };
		Assert.That(GetIpPathEntry(ref row), ResultIs.Successful);
		Assert.That((int)row.Source.si_family, Is.Not.Zero);
	}

	[Test]
	public void GetMulticastIpAddressEntryTableTest()
	{
		Assert.That(GetMulticastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);

		var goodRow = table.Table![0];
		var row = new MIB_MULTICASTIPADDRESS_ROW { Address = goodRow.Address, InterfaceLuid = goodRow.InterfaceLuid };
		Assert.That(GetMulticastIpAddressEntry(ref row), ResultIs.Successful);
		Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));
	}

	[Test]
	public void GetSetIpInterfaceEntryTest()
	{
		var mibrow = new MIB_IPINTERFACE_ROW(ADDRESS_FAMILY.AF_INET, primaryAdapter.Luid);
		Assert.That(GetIpInterfaceEntry(ref mibrow), ResultIs.Successful);
		var prev = mibrow.SitePrefixLength;
		mibrow.SitePrefixLength = 0;
		Assert.That(SetIpInterfaceEntry(mibrow), ResultIs.Successful);

		mibrow = new MIB_IPINTERFACE_ROW(ADDRESS_FAMILY.AF_INET, primaryAdapter.Luid);
		Assert.That(GetIpInterfaceEntry(ref mibrow), ResultIs.Successful);
		Assert.That(mibrow.PathMtuDiscoveryTimeout, Is.EqualTo(600000));

		mibrow.SitePrefixLength = prev;
		Assert.That(SetIpInterfaceEntry(mibrow), ResultIs.Successful);
	}

	[Test]
	public void GetSetIpNetEntryTable2Test()
	{
		Assert.That(GetIpNetTable2(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);

		var goodRow = table.Table![0];
		var row = new MIB_IPNET_ROW2 { Address = goodRow.Address, InterfaceLuid = goodRow.InterfaceLuid };
		Assert.That(GetIpNetEntry2(ref row), ResultIs.Successful);
		Assert.That(row.InterfaceIndex, Is.Not.Zero.And.EqualTo(goodRow.InterfaceIndex));

		row = new MIB_IPNET_ROW2 { Address = primaryAdapter.MulticastAddresses.First().Address.GetSOCKADDR(), InterfaceIndex = primaryAdapter.IfIndex };
		Assert.That(() => SetIpNetEntry2(row), Throws.Nothing); // This call always fails w/ ERROR_NOT_FOUND, but it works
	}

	[Test]
	public void GetTeredoPortTest()
	{
		Assert.That((uint)GetTeredoPort(out _), Is.Zero.Or.EqualTo(Win32Error.ERROR_NOT_READY));
	}

	[Test]
	public void GetUnicastIpAddressEntryTableTest()
	{
		Assert.That(GetUnicastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table), ResultIs.Successful);
		Assert.That(table.NumEntries, Is.GreaterThan(0));
		Assert.That(() => table.Table, Throws.Nothing);

		var goodRow = table.Table![0];
		var row = new MIB_UNICASTIPADDRESS_ROW { Address = goodRow.Address, InterfaceLuid = goodRow.InterfaceLuid };
		Assert.That(GetUnicastIpAddressEntry(ref row), ResultIs.Successful);
		Assert.That(row.CreationTimeStamp, Is.Not.Zero.And.EqualTo(goodRow.CreationTimeStamp));
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
	public void NotifyIpInterfaceChangeTest()
	{
		var fired = new ManualResetEvent(false);
		var done = new ManualResetEvent(false);
		new Thread(() =>
		{
			try
			{
				Assert.That(NotifyIpInterfaceChange(ADDRESS_FAMILY.AF_UNSPEC, NotifyFunc, NotifyData, true, out var hNot), ResultIs.Successful);
				fired.WaitOne(3000);
				Assert.That(CancelMibChangeNotify2(hNot), ResultIs.Successful);
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
				Assert.That(NotifyRouteChange2(ADDRESS_FAMILY.AF_UNSPEC, NotifyFunc, NotifyData, true, out var hNot), ResultIs.Successful);
				fired.WaitOne(3000);
				Assert.That(CancelMibChangeNotify2(hNot), ResultIs.Successful);
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
	public void NotifyStableUnicastIpAddressTableTest()
	{
		var fired = new ManualResetEvent(false);
		var done = new ManualResetEvent(false);
		new Thread(() =>
		{
			try
			{
				Assert.That((uint)NotifyStableUnicastIpAddressTable(ADDRESS_FAMILY.AF_UNSPEC, out var table, NotifyFunc, NotifyData, out var hNot), ResultIs.Successful.Or.EqualTo(Win32Error.ERROR_IO_PENDING));
				if (table == IntPtr.Zero)
				{
					fired.WaitOne(3000);
					Assert.That(CancelMibChangeNotify2(hNot), ResultIs.Successful);
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
				Assert.That(NotifyTeredoPortChange(NotifyFunc, NotifyData, true, out var hNot), ResultIs.Successful);
				fired.WaitOne(3000);
				Assert.That(CancelMibChangeNotify2(hNot), ResultIs.Successful);
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
				Assert.That(NotifyUnicastIpAddressChange(ADDRESS_FAMILY.AF_UNSPEC, NotifyFunc, NotifyData, true, out var hNot), ResultIs.Successful);
				fired.WaitOne(3000);
				Assert.That(CancelMibChangeNotify2(hNot), ResultIs.Successful);
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
		//Assert.Fail("This method is not working. Some of the functions are corrupting memory.");
		var e = new MIB_IPNET_ROW2(new SOCKADDR_IN(knwIP), primaryAdapter.IfIndex);
		Assert.That(ResolveIpNetEntry2(ref e), ResultIs.Successful);
		Assert.That(e.State, Is.EqualTo(NL_NEIGHBOR_STATE.NlnsReachable));
	}

	[Test]
	public void FutureUseTest()
	{
		Assert.That(SetCurrentThreadCompartmentId(1), Is.GreaterThanOrEqualTo(0));
		Assert.That(SetNetworkInformation(Guid.NewGuid(), 1, "Fred"), Is.GreaterThanOrEqualTo(0));
		Assert.That(SetSessionCompartmentId(1, 1), Is.GreaterThanOrEqualTo(0));
	}

	private SOCKADDR_IN6 GetV6Addr() => new(new IN6_ADDR(new byte[] { 0xfe, 0x3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0x00 }), 0);
}