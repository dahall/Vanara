using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Vanara.PInvoke.NetListMgr;

//using NETWORKLIST;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class NetListMgrTests
{
	private static INetworkListManager? mgr;
	private static INetworkCostManager? coster;

	[OneTimeSetUp]
	public static void OneTimeSetup()
	{
		mgr = new INetworkListManager();
		coster = new INetworkCostManager();
	}

	[Test]
	public void GetNetworksTest()
	{
		var ns = mgr!.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED);
		Assert.That(ns, Is.Not.Null);
		var n = ns.Cast<INetwork>().FirstOrDefault();
		Assert.That(n, Is.Not.Null);
		Assert.That(mgr!.IsConnected, Is.True);
		Assert.That(mgr!.IsConnectedToInternet, Is.True);
		Assert.That((int)mgr!.GetConnectivity(), Is.GreaterThan(0));
	}

	[Test]
	public void GetNetworksTest1()
	{
		using var ns = ComReleaserFactory.Create(mgr!.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED));
		Assert.That(ns.Item, Is.Not.Null);
		var connections = new INetwork[5];
		ns.Item.Next((uint)connections.Length, connections, out uint fetched);
		Assert.That(fetched, Is.LessThanOrEqualTo(connections.Length));
		for (int i = 0; i < fetched; i++)
			Marshal.ReleaseComObject(connections[i]);
	}

	[Test]
	public void GetNetworkConnectionsTest()
	{
		var ns = mgr!.GetNetworkConnections();
		Assert.That(ns, Is.Not.Null);
		var n = ns.Cast<INetworkConnection>().FirstOrDefault();
		Assert.That(n, Is.Not.Null);
	}

	[Test]
	public void GetNetworkConnectionsTest1()
	{
		var ns = ComReleaserFactory.Create(mgr!.GetNetworkConnections());
		Assert.That(ns.Item, Is.Not.Null);
		var connections = new INetworkConnection[5];
		ns.Item.Next((uint)connections.Length, connections, out uint fetched);
		Assert.That(fetched, Is.LessThanOrEqualTo(connections.Length));
		for (int i = 0; i < fetched; i++)
			Marshal.ReleaseComObject(connections[i]);
	}

	[Test]
	public void GetNetworkTest()
	{
		var ns = mgr!.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED);
		Assert.That(ns, Is.Not.Null);
		var n = ns.Cast<INetwork>().FirstOrDefault();
		Assert.That(n, Is.Not.Null);
		var g = n!.GetNetworkId();
		var n1 = mgr!.GetNetwork(g);
		Assert.That(n.GetName() == n1.GetName());
		Assert.That(n.GetName(), Is.Not.Null);
		var nm = n.GetName();
		n.SetName("XXXX");
		Assert.That(n.GetName(), Is.EqualTo("XXXX"));
		n.SetName(nm);
		var de = n.GetDescription();
		n.SetDescription("XXXX");
		Assert.That(n.GetDescription(), Is.EqualTo("XXXX"));
		n.SetDescription(de);
		Assert.That((int)n.GetDomainType(), Is.InRange(0, 2));
		n.GetTimeCreatedAndConnected(out uint pdwLowDateTimeCreated, out uint pdwHighDateTimeCreated, out uint pdwLowDateTimeConnected, out uint pdwHighDateTimeConnected);
		var cft = new FILETIME { dwHighDateTime = (int)pdwHighDateTimeCreated, dwLowDateTime = (int)pdwLowDateTimeCreated };
		var nft = new FILETIME { dwHighDateTime = (int)pdwHighDateTimeConnected, dwLowDateTime = (int)pdwLowDateTimeConnected };
		Assert.That(cft.ToDateTime(), Is.GreaterThan(new DateTime(2000,1,1)));
		Assert.That(nft.ToDateTime(), Is.GreaterThan(new DateTime(2000,1,1)));
		Assert.That(n.IsConnected, Is.True);
		Assert.That(n.IsConnectedToInternet, Is.True);
		Assert.That((int)n.GetConnectivity(), Is.GreaterThan(0));
		Assert.That((int)n.GetCategory(), Is.InRange(0, 2));
		Assert.That(n.GetNetworkConnections(), Is.Not.Empty);
		TestContext.WriteLine($"{nm} ({n.GetNetworkId()}): '{de}'");
		TestContext.WriteLine($"  CrD:{cft.ToString("s")}; CnD:{nft.ToString("s")}; Cn:{n.IsConnected}; Int:{n.IsConnectedToInternet}; Dom:{n.GetDomainType()}");
		TestContext.WriteLine($"  Cnt:{n.GetConnectivity()}; Cat:{n.GetCategory()}");
	}

	[Test]
	public void GetNetworkConnectionTest()
	{
		var ns = mgr!.GetNetworkConnections();
		Assert.That(ns, Is.Not.Null);
		var n = ns.Cast<INetworkConnection>().FirstOrDefault();
		Assert.That(n, Is.Not.Null);
		var g = n!.GetConnectionId();
		var n1 = mgr!.GetNetworkConnection(g);
		Assert.That(n.GetConnectionId() == n1.GetConnectionId());
		Assert.That(n.GetAdapterId() == n1.GetAdapterId());
		Assert.That(n.GetNetwork(), Is.Not.Null);
		Assert.That(n.IsConnected, Is.True);
		Assert.That(n.IsConnectedToInternet, Is.True);
		Assert.That((int)n.GetConnectivity(), Is.GreaterThan(0));
		Assert.That((int)n.GetDomainType(), Is.InRange(0, 2));

		// Test network cost
		var ncost = (INetworkConnectionCost) n;
		Assert.That(ncost, Is.Not.Null);
		var ret = ncost.GetCost();
		TestContext.WriteLine($"Cost:{ret}");
		Assert.That((int)ret, Is.GreaterThan(0));
	}

	[Test]
	public void GetCostTest()
	{
		NLM_CONNECTION_COST ret = 0;
		Assert.That(() => coster!.GetCost(out ret), Throws.Nothing);
		TestContext.WriteLine($"Cost:{ret}");
		Assert.That((int)ret, Is.GreaterThan(0));
		var status = new NLM_DATAPLAN_STATUS();
		Assert.That(() => coster!.GetDataPlanStatus(out status), Throws.Nothing);
		Assert.That(status.InterfaceGuid, Is.Not.EqualTo(Guid.Empty));
		TestContext.WriteLine($"Guid:{status.InterfaceGuid}; Limit:{status.DataLimitInMegabytes:X}; Xfer:{status.MaxTransferSizeInMegabytes:X}");
	}
}