using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	/// <summary>Represents a wireless network profile</summary>
	public class NetworkProfile : IDisposable
	{
		private INetwork inet;

		/// <summary>Initializes a new instance of the <see cref="NetworkProfile"/> class using the GUID of the network profile.</summary>
		/// <param name="guid">The GUID of the network profile.</param>
		public NetworkProfile(Guid guid)
		{
			inet = NetworkListManager.Manager.GetNetwork(guid);
		}

		/// <summary>Initializes a new instance of the <see cref="NetworkProfile"/> class.</summary>
		/// <param name="inetwork">The INetwork instance.</param>
		internal NetworkProfile(INetwork inetwork)
		{
			inet = inetwork ?? throw new ArgumentNullException(nameof(inetwork));
		}

		/// <summary>Returns the category of a network.</summary>
		/// <returns>A NLM_NETWORK_CATEGORY enumeration value that specifies the category information for the network.</returns>
		public NLM_NETWORK_CATEGORY Category { get => inet.GetCategory(); set => inet.SetCategory(value); }

		/// <summary>Gets the date and time the network was last connected to.</summary>
		/// <value>The connection time.</value>
		public DateTime ConnectionTime
		{
			get
			{
				inet.GetTimeCreatedAndConnected(out var _, out var _, out var low, out var hi);
				return FileTimeExtensions.MakeFILETIME(Vanara.PInvoke.Macros.MAKELONG64(low, hi)).ToDateTime();
			}
		}

		/// <summary>Returns the connectivity state of the network.</summary>
		/// <returns>A NLM_CONNECTIVITY enumeration value that contains a bitmask that specifies the connectivity state of this network.</returns>
		public NLM_CONNECTIVITY Connectivity => inet.GetConnectivity();

		/// <summary>Gets the date and time the network was created.</summary>
		/// <value>The creation time.</value>
		public DateTime CreationTime
		{
			get
			{
				inet.GetTimeCreatedAndConnected(out var low, out var hi, out var _, out var _);
				return FileTimeExtensions.MakeFILETIME(Vanara.PInvoke.Macros.MAKELONG64(low, hi)).ToDateTime();
			}
		}

		/// <summary>Gets or sets the description for the network profile.</summary>
		/// <value>The description.</value>
		public string Description { get => inet.GetDescription(); set => inet.SetDescription(value); }

		/// <summary>Gets the type of the network.</summary>
		/// <value>The type of the network.</value>
		public NLM_DOMAIN_TYPE DomainType => inet.GetDomainType();

		/// <summary>Gets the GUID of the profile.</summary>
		/// <value>The id.</value>
		public Guid Id => inet.GetNetworkId();

		/// <summary>Specifies if the network has any network connectivity.</summary>
		/// <value>If <see langword="true"/>, this network is connected; if <see langword="false"/>, it is not.</value>
		public bool IsConnected => inet.IsConnected;

		/// <summary>Specifies if the network has internet connectivity.</summary>
		/// <value>If <see langword="true"/>, this network has connectivity to the internet; if <see langword="false"/>, it does not.</value>
		public bool IsConnectedToInternet => inet.IsConnectedToInternet;

		/// <summary>Gets or sets the name of the network profile.</summary>
		/// <value>The name.</value>
		public string Name { get => inet.GetName(); set => inet.SetName(value); }

		/// <summary>
		/// Returns an enumeration of all network connections for a network. A network can have multiple connections to it from different
		/// interfaces or different links from the same interface.
		/// </summary>
		/// <value>The instance that enumerates the list of local connections to this network.</value>
		public NetworkListManager.IEnumerableList<NetworkConnection, Guid> NetworkConnections => new NetworkListManager.NetworkConnectionIterator(inet.GetNetworkConnections());

		/// <summary>Gets all local profiles.</summary>
		/// <returns>Array of <see cref="NetworkProfile"/> objects.</returns>
		public static IEnumerable<NetworkProfile> GetAllLocalProfiles() => NetworkListManager.Networks;

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		void IDisposable.Dispose()
		{
			if (inet == null) return;
			Marshal.FinalReleaseComObject(inet);
			inet = null;
		}

		/// <summary>Determines whether the specified <see cref="System.Object"/> is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		/// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
		public override bool Equals(object obj)
		{
			if (obj is NetworkProfile np)
				return np.Id == Id;
			else if (obj is Guid g)
				return g == Id;
			return false;
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => Id.GetHashCode();

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => Name;
	}
}