using System;
using static Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	public class NetworkConnection
	{
		private readonly INetworkConnection conn;

		internal NetworkConnection(INetworkConnection networkConnection)
		{
			if (conn == null) throw new ArgumentNullException(nameof(networkConnection));
			conn = networkConnection;
		}

		public Guid AdapterId => conn.GetAdapterId();

		public Guid ConnectionId => conn.GetConnectionId();

		public NLM_CONNECTIVITY Connectivity => conn.GetConnectivity();

		public NLM_DOMAIN_TYPE DomainType => conn.GetDomainType();

		public bool IsConnected => conn.IsConnected;
		public bool IsConnectedToInternet => conn.IsConnectedToInternet;
		internal INetwork Network => conn.GetNetwork();
	}
}