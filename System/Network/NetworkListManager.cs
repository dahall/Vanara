using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	/// <summary>Provides a set of methods to perform network list management functions.</summary>
	public static partial class NetworkListManager
	{
		private static NetworkConnectionIterator connIter;
		private static INetworkCostManager costmgr;
		private static INetworkListManager manager;
		private static NetworkIterator netIter;

		/// <summary>An enumerable list that supports a length and indexer.</summary>
		/// <typeparam name="T">The type of the item.</typeparam>
		/// <typeparam name="TLookup">The type of the parameter used by the indexer.</typeparam>
		/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
		public interface IEnumerableList<T, in TLookup> : IEnumerable<T>
		{
			/// <summary>Gets the length of the list.</summary>
			int Length { get; }

			/// <summary>Gets the with the specified identifier.</summary>
			/// <value>The found item type.</value>
			/// <param name="id">The identifier.</param>
			/// <returns>The item found by the identifier.</returns>
			T this[TLookup id] { get; }
		}

		/// <summary>Gets the current connectivity state.</summary>
		/// <value>The connectivity state.</value>
		public static NLM_CONNECTIVITY Connectivity => Manager?.GetConnectivity() ?? NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED;

		/// <summary>Gets a value indicating whether a network is connected.</summary>
		/// <value><c>true</c> if a network is connected; otherwise, <c>false</c>.</value>
		public static bool IsConnected => Manager?.IsConnected ?? false;

		/// <summary>Gets a value indicating whether connectivity to the Internet is available.</summary>
		/// <value><c>true</c> if connectivity to the Internet is available; otherwise, <c>false</c>.</value>
		public static bool IsConnectedToInternet => Manager?.IsConnectedToInternet ?? false;

		/// <summary>Gets the network connections for this device.</summary>
		/// <value>The network connections.</value>
		public static IEnumerableList<NetworkConnection, Guid> NetworkConnections => connIter ?? (connIter = new NetworkConnectionIterator());

		/// <summary>Gets the active networks available.</summary>
		/// <value>The networks.</value>
		public static IEnumerableList<NetworkProfile, Guid> Networks => netIter ?? (netIter = new NetworkIterator());

		/// <summary>
		/// Gets the current cost of either a machine-wide internet connection, or the first-hop of routing to a specific destination on a
		/// connection. If destIPaddr is NULL, this method instead returns the cost of the network used for machine-wide Internet connectivity.
		/// </summary>
		/// <param name="destIPAddr">
		/// The destination IPv4/IPv6 address. If <see langword="null"/>, this method will instead return the cost associated with the
		/// preferred connection used for machine Internet connectivity.
		/// </param>
		/// <returns>The cost of the connection.</returns>
		public static NLM_CONNECTION_COST GetConnectionCost(IPAddress destIPAddr = null)
		{
			var addr = NLM_SOCKADDR.FromIPAddress(destIPAddr);
			var cost = NLM_CONNECTION_COST.NLM_CONNECTION_COST_UNKNOWN;
			(costmgr ?? (costmgr = (INetworkCostManager)Manager))?.GetCost(out cost, addr);
			return cost;
		}

		/// <summary>
		/// Gets the data plan status for either a machine-wide internet connection , or the first-hop of routing to a specific destination
		/// on a connection. If an IPv4/IPv6 address is not specified, this method returns the data plan status of the connection used for
		/// machine-wide Internet connectivity.
		/// </summary>
		/// <param name="destIPAddr">
		/// The destination IPv4/IPv6 address. If <see langword="null"/>, this method will instead return the data plan status of the
		/// connection used for machine-wide Internet connectivity.
		/// </param>
		/// <returns>
		/// An NLM_DATAPLAN_STATUS structure that describes the data plan status associated with a connection used to route to a destination.
		/// If destIPAddr specifies a tunnel address, the first available data plan status in the interface stack is returned.
		/// </returns>
		public static NLM_DATAPLAN_STATUS GetConnectionDataPlanStatus(IPAddress destIPAddr = null)
		{
			var addr = NLM_SOCKADDR.FromIPAddress(destIPAddr);
			var cost = new NLM_DATAPLAN_STATUS();
			(costmgr ?? (costmgr = (INetworkCostManager)Manager))?.GetDataPlanStatus(out cost, addr);
			return cost;
		}

		/// <summary>Gets a value indicating whether the data plan status values are default values, or provided by the MNO.</summary>
		/// <value><c>true</c> if this instance is available; otherwise, <c>false</c>.</value>
		public static bool IsDefined(this NLM_DATAPLAN_STATUS status)
		{
			const uint NLM_UNKNOWN_DATAPLAN_STATUS = 0xFFFFFFFF;

			// usage data is valid only if both planUsage and lastUpdatedTime are valid
			if (status.UsageData.UsageInMegabytes != NLM_UNKNOWN_DATAPLAN_STATUS && (status.UsageData.LastSyncTime.dwHighDateTime != 0 || status.UsageData.LastSyncTime.dwLowDateTime != 0))
				return true;
			if (status.DataLimitInMegabytes != NLM_UNKNOWN_DATAPLAN_STATUS)
				return true;
			if (status.InboundBandwidthInKbps != NLM_UNKNOWN_DATAPLAN_STATUS)
				return true;
			if (status.OutboundBandwidthInKbps != NLM_UNKNOWN_DATAPLAN_STATUS)
				return true;
			if (status.NextBillingCycle.dwHighDateTime != 0 || status.NextBillingCycle.dwLowDateTime != 0)
				return true;
			if (status.MaxTransferSizeInMegabytes != NLM_UNKNOWN_DATAPLAN_STATUS)
				return true;
			return false;
		}

		internal static INetworkListManager Manager
		{
			get
			{
				if (manager != null) return manager;
				try
				{
					manager = new INetworkListManager();
				}
				catch (UnauthorizedAccessException) { }
				catch (ExternalException) { }
				return manager;
			}
		}

		internal class NetworkConnectionIterator : IEnumerableList<NetworkConnection, Guid>, IDisposable
		{
			private IEnumNetworkConnections conns;

			internal NetworkConnectionIterator(IEnumNetworkConnections conns = null)
			{
				this.conns = conns;
			}

			public int Length => Items.Count();

			private IEnumerable<NetworkConnection> Items => GetItems(conns);

			private static IEnumerable<NetworkConnection> GetItems(IEnumNetworkConnections conns)
			{
				IEnumerable<NetworkConnection> ie = null;
				try
				{
					ie = (conns ?? Manager?.GetNetworkConnections()).Cast<INetworkConnection>().Select(i => new NetworkConnection(i));
				}
				catch (UnauthorizedAccessException) { }
				catch (ExternalException) { }
				return ie;
			}

			public NetworkConnection this[Guid id] => new NetworkConnection(Manager?.GetNetworkConnection(id));

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			public IEnumerator<NetworkConnection> GetEnumerator()
			{
				var ie = Items;
				if (ie == null) yield break;
				foreach (var conn in ie)
					yield return conn;
			}

			void IDisposable.Dispose()
			{
				if (conns == null) return;
				Marshal.FinalReleaseComObject(conns);
				conns = null;
			}
		}

		private class NetworkIterator : IEnumerableList<NetworkProfile, Guid>
		{
			internal NetworkIterator()
			{
			}

			public int Length => Items.Count();

			private static IEnumerable<NetworkProfile> Items
			{
				get
				{
					IEnumerable<NetworkProfile> ie = null;
					try
					{
						ie = Manager?.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_ALL).Cast<INetwork>().Select(i => new NetworkProfile(i));
					}
					catch (UnauthorizedAccessException) { }
					catch (ExternalException) { }
					return ie;
				}
			}

			public NetworkProfile this[Guid id] => new NetworkProfile(Manager?.GetNetwork(id));

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			public IEnumerator<NetworkProfile> GetEnumerator()
			{
				var ie = Items;
				if (ie == null) yield break;
				foreach (var networkProfile in ie)
					yield return networkProfile;
			}
		}
	}
}