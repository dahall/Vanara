using System;
using System.Runtime.InteropServices;
using Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	/// <summary>Represents a single network connection. Wraps <see cref="INetworkConnection"/>.</summary>
	public class NetworkConnection : IDisposable
	{
		private INetworkConnection conn;
		private INetworkConnectionCost cost;

		internal NetworkConnection(INetworkConnection networkConnection)
		{
			conn = networkConnection ?? throw new ArgumentNullException(nameof(networkConnection));
		}

		/// <summary>Returns the ID of the network adapter used by this connection. There may multiple connections using the same adapter ID.</summary>
		/// <returns>A GUID that specifies the adapter ID of the TCP/IP interface used by this network connection.</returns>
		public Guid AdapterId => conn.GetAdapterId();

		/// <summary>Returns the Connection ID associated with this network connection.</summary>
		/// <returns>A GUID that specifies the Connection ID associated with this network connection.</returns>
		public Guid ConnectionId => conn.GetConnectionId();

		/// <summary>Returns the connectivity state of the network.</summary>
		/// <returns>A NLM_CONNECTIVITY enumeration value that contains a bitmask that specifies the connectivity of this network connection.</returns>
		public NLM_CONNECTIVITY Connectivity => conn.GetConnectivity();

		/// <summary>Gets the network cost associated with a connection.</summary>
		/// <value>The cost.</value>
		public NLM_CONNECTION_COST Cost => (cost ?? (cost = (INetworkConnectionCost)conn)).GetCost();

		/// <summary>Gets the data plan status.</summary>
		/// <value>The data plan status.</value>
		public NLM_DATAPLAN_STATUS DataPlanStatus => (cost ?? (cost = (INetworkConnectionCost)conn)).GetDataPlanStatus();

		/// <summary>Returns the type of network connection.</summary>
		/// <returns>An NLM_DOMAIN_TYPE enumeration value that specifies the domain type of the network.</returns>
		public NLM_DOMAIN_TYPE DomainType => conn.GetDomainType();

		/// <summary>Specifies if the associated network connection has any network connectivity.</summary>
		/// <value>If TRUE, this network connection has connectivity; if FALSE, it does not.</value>
		public bool IsConnected => conn.IsConnected;

		/// <summary>Specifies if the associated network connection has internet connectivity.</summary>
		/// <value>If TRUE, this network connection has connectivity to the internet; if FALSE, it does not.</value>
		public bool IsConnectedToInternet => conn.IsConnectedToInternet;

		/// <summary>Returns the associated network for the connection.</summary>
		/// <returns>An instance that specifies the network profile associated with the connection.</returns>
		public NetworkProfile Network => new NetworkProfile(conn.GetNetwork());

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => $"{ConnectionId} : {Connectivity}";

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			if (conn == null) return;
			if (cost != null)
			{
				Marshal.FinalReleaseComObject(cost);
				cost = null;
			}
			Marshal.FinalReleaseComObject(conn);
			conn = null;
		}
	}
}