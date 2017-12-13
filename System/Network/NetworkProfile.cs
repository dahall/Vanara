using System;
using System.Collections.Generic;
using static Vanara.PInvoke.NetListMgr;

namespace Vanara.Network
{
	/// <summary>
	/// Represents a wireless network profile
	/// </summary>
	public class NetworkProfile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NetworkProfile"/> class using the GUID of the network profile.
		/// </summary>
		/// <param name="guid">The GUID of the network profile.</param>
		/// <param name="name">The name of the network profile.</param>
		public NetworkProfile(Guid guid, string name)
		{
			Name = name;
			Id = guid;
		}

		internal static NetworkProfile FromINetwork(INetwork net) => net == null ? null : new NetworkProfile(net.GetNetworkId(), net.GetName());

		private NetworkProfile(string guid, string name) : this(new Guid(guid), name) { }

		/// <summary>
		/// Gets the name of the profile.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; }

		/// <summary>
		/// Gets the GUID of the profile.
		/// </summary>
		/// <value>The id.</value>
		public Guid Id { get; }

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="obj"/> parameter is null.
		/// </exception>
		public override bool Equals(object obj)
		{
			if (obj is NetworkProfile)
				return ((NetworkProfile)obj).Id == Id;
			else if (obj is Guid)
				return ((Guid)obj) == Id;
			return false;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode() => Id.GetHashCode();

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString() => Name;

		/// <summary>
		/// Gets all local profiles.
		/// </summary>
		/// <returns>Array of <see cref="NetworkProfile"/> objects.</returns>
		public static IEnumerable<NetworkProfile> GetAllLocalProfiles() => NetworkListManager.Networks;
	}
}