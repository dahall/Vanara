using NUnit.Framework;

namespace Vanara.Network.Tests;

[TestFixture]
public class NetworkListTests
{
	[Test]
	public void TestNetworkList()
	{
		TestContext.WriteLine($"Network: {NetworkListManager.IsConnected}");
		TestContext.WriteLine($"Internet: {NetworkListManager.IsConnectedToInternet}");
		TestContext.WriteLine($"State: {NetworkListManager.Connectivity}");
		foreach (var n in NetworkListManager.Networks)
			TestContext.WriteLine(NetInfo(n));
		foreach (var n in NetworkListManager.NetworkConnections)
			TestContext.WriteLine(ConnInfo(n));

		string ConnInfo(NetworkConnection nc)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Conn: {nc.ConnectionId}, Adapter:{nc.AdapterId}");
			sb.AppendLine($"      Conn:{nc.IsConnected}, Internet:{nc.IsConnectedToInternet}");
			sb.AppendLine($"      Cntv:{nc.Connectivity}, Net:{nc.Network.Name}");
			sb.AppendLine($"      Type:{nc.DomainType}, Cost:{nc.Cost}, Plan:{DPToString(nc.DataPlanStatus)}");
			return sb.ToString();
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		string DPToString(PInvoke.NetListMgr.NLM_DATAPLAN_STATUS dp) => string.Format(Formatter.Default().Add<ByteSizeFormatter>(), "Bandwidth:{0:B}/{1:B}; Use:{2:B}", dp.InboundBandwidthInKbps * 1024L, dp.OutboundBandwidthInKbps * 1024L, dp.UsageData.UsageInMegabytes * 1024 * 1024L);

		string NetInfo(NetworkProfile np)
		{
			var sb = new StringBuilder();
			sb.AppendLine($"Net: {np.Name} ({np.Description})");
			sb.AppendLine($"     Conn:{np.IsConnected}, Internet:{np.IsConnectedToInternet}");
			sb.AppendLine($"     Created:{np.CreationTime}, Conn:{np.ConnectionTime}");
			sb.AppendLine($"     Cat:{np.Category}, Cntv:{np.Connectivity}");
			sb.AppendLine($"     Type:{np.DomainType}, Id:{np.Id}");
			return sb.ToString();
		}
	}
}
