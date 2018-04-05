using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	/// <summary>Represents a single network connection. Wraps <see cref="INetworkConnection"/>.</summary>
	public class NetworkConnection : IDisposable
	{
		private INetworkConnection conn;

		internal NetworkConnection(INetworkConnection networkConnection)
		{
			if (conn == null) throw new ArgumentNullException(nameof(networkConnection));
			conn = networkConnection;
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

		/// <summary>Returns the type of network connection.</summary>
		/// <returns>An NLM_DOMAIN_TYPE enumeration value that specifies the domain type of the network.</returns>
		public NLM_DOMAIN_TYPE DomainType => conn.GetDomainType();

		/// <summary>Specifies if the associated network connection has any network connectivity.</summary>
		/// <value>If TRUE, this network connection has connectivity; if FALSE, it does not.</value>
		public bool IsConnected => conn.IsConnected;

		/// <summary>Specifies if the associated network connection has internet connectivity.</summary>
		/// <value>If TRUE, this network connection has connectivity to the internet; if FALSE, it does not.</value>
		public bool IsConnectedToInternet => conn.IsConnectedToInternet;

		internal INetwork Network => conn.GetNetwork();

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			if (conn == null) return;
			Marshal.FinalReleaseComObject(conn);
			conn = null;
		}
	}
}