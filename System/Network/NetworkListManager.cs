using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	public static class NetworkListManager
	{
		private static NetworkConnectionIterator connIter;
		private static INetworkListManager manager;
		private static NetworkIterator netIter;

		public static NLM_CONNECTIVITY Connectivity => Manager?.GetConnectivity() ?? NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED;

		public static bool IsConnected => Manager?.IsConnected ?? false;

		public static bool IsConnectedToInternet => Manager?.IsConnectedToInternet ?? false;

		public static IEnumerableList<NetworkConnection, Guid> NetworkConnections => connIter ?? (connIter = new NetworkConnectionIterator());

		public static IEnumerableList<NetworkProfile, Guid> Networks => netIter ?? (netIter = new NetworkIterator());

		private static INetworkListManager Manager
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

		public interface IEnumerableList<T, in TLookup> : IEnumerable<T>
		{
			int Length { get; }
			T this[TLookup id] { get; }
		}

		private class NetworkConnectionIterator : IEnumerableList<NetworkConnection, Guid>
		{
			internal NetworkConnectionIterator()
			{
			}

			public int Length => Items.Count();

			private static IEnumerable<NetworkConnection> Items
			{
				get
				{
					IEnumerable<NetworkConnection> ie = null;
					try
					{
						ie = Manager?.GetNetworkConnections().Cast<INetworkConnection>().Select(i => new NetworkConnection(i));
					}
					catch (UnauthorizedAccessException) { }
					catch (ExternalException) { }
					return ie;
				}
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
						ie = Manager?.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_ALL).Cast<INetwork>().Select(NetworkProfile.FromINetwork);
					}
					catch (UnauthorizedAccessException) { }
					catch (ExternalException) { }
					return ie;
				}
			}

			public NetworkProfile this[Guid id] => NetworkProfile.FromINetwork(Manager?.GetNetwork(id));

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