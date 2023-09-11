using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Vanara.Extensions;
using Vanara.Security;
using static Vanara.PInvoke.Mpr;

namespace Vanara;

/// <summary>Information about a remote resource, usually in reference to a connection to that resource.</summary>
public class NetworkDeviceConnection : IEquatable<NetworkDeviceConnection>
{
	internal readonly NETRESOURCE netRes = default;
	internal WindowsIdentity identity;
	private NetworkDeviceConnectionCollection children;

	internal NetworkDeviceConnection(NETRESOURCE r, WindowsIdentity user)
	{
		if (r is null) throw new ArgumentNullException(nameof(r));
		netRes = r;
		identity = user;
	}

	internal NetworkDeviceConnection(string remoteName, string localName = null, string provider = null, NETRESOURCEType type = NETRESOURCEType.RESOURCETYPE_ANY)
	{
		if (string.IsNullOrEmpty(remoteName)) throw new ArgumentNullException(nameof(remoteName));
		netRes = new NETRESOURCE(remoteName, localName, provider) { dwType = type };
	}

	/// <summary>Gets the children of this resource if it is a container.</summary>
	/// <value>The children resources.</value>
	public NetworkDeviceConnectionCollection Children => children ??= new NetworkDeviceConnectionCollection(identity, netRes);

	/// <summary>A string that contains a comment supplied by the network provider.</summary>
	public string Comment => netRes.lpComment;

	/// <summary>
	/// A string that contains the name of the provider that owns the resource. This member can be <see langword="null"/> if the
	/// provider name is unknown.
	/// </summary>
	public string Provider => netRes.lpProvider;

	/// <summary>The display options for the network object in a network browsing user interface.</summary>
	public NETRESOURCEDisplayType ResourceDisplayType => netRes.dwDisplayType;

	/// <summary>The type of resource.</summary>
	public NETRESOURCEType ResourceType => netRes.dwType;

	/// <summary>A set of flags describing how the resource can be used.</summary>
	public NETRESOURCEUsage Use => netRes.dwUsage;

	/// <summary>The name of a local device. This member is <see langword="null"/> if the connection does not use a device.</summary>
	public string LocalName => netRes.lpLocalName;

	/// <summary>
	/// If the entry is a network resource, this member is a string that specifies the remote network name.
	/// <para>If the entry is a current or persistent connection, this member is the network name associated with <see cref="LocalName"/>.</para>
	/// </summary>
	public string RemoteName => netRes.lpRemoteName;

	/// <summary>Makes a connection to a network resource and can redirect a local device to the network resource.</summary>
	/// <param name="remoteName">
	/// A string that specifies the network resource to connect to. The string must follow the network provider's naming conventions.
	/// </param>
	/// <param name="localName">
	/// A string that specifies the name of a local device to redirect, such as "F:" or "LPT1". The string is treated in a
	/// case-insensitive manner. If the string is empty or <see langword="null"/>, the function makes a connection to the network
	/// resource without redirecting a local device.
	/// </param>
	/// <param name="userName">
	/// <para>A pointer to a constant <c>null</c>-terminated string that specifies a user name for making the connection.</para>
	/// <para>
	/// If lpUserName is <c>NULL</c>, the function uses the default user name. (The user context for the process provides the default
	/// user name.)
	/// </para>
	/// <para>
	/// The lpUserName parameter is specified when users want to connect to a network resource for which they have been assigned a user
	/// name or account other than the default user name or account.
	/// </para>
	/// <para>The user-name string represents a security context. It may be specific to a network provider.</para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="password">
	/// <para>A pointer to a constant <c>null</c>-terminated string that specifies a password to be used in making the network connection.</para>
	/// <para>
	/// If lpPassword is <c>NULL</c>, the function uses the current default password associated with the user specified by the
	/// lpUserName parameter.
	/// </para>
	/// <para>If lpPassword points to an empty string, the function does not use a password.</para>
	/// <para>
	/// If the connection fails because of an invalid password and the CONNECT_INTERACTIVE value is set in the dwFlags parameter, the
	/// function displays a dialog box asking the user to type the password.
	/// </para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="isPrinter">if set to <see langword="true"/>, the resource specified in <paramref name="remoteName"/> is a printer.</param>
	/// <param name="flags">A set of connection options.</param>
	/// <param name="provider">
	/// A string that specifies the network provider to connect to. If <see langword="null"/>, or an empty string, the operating system
	/// attempts to determine the correct provider by parsing the string provided in <paramref name="remoteName"/>. If this member is
	/// not <see langword="null"/>, the operating system attempts to make a connection only to the named network provider. You should
	/// set this member only if you know the network provider you want to use. Otherwise, let the operating system determine which
	/// provider the network name maps to.
	/// </param>
	/// <returns>An instance of <see cref="NetworkDeviceConnection"/> for the created connection.</returns>
	public static NetworkDeviceConnection Create(string remoteName, string localName = null, string userName = null, string password = null, bool isPrinter = false, CONNECT flags = 0, string provider = null)
	{
		if (localName == "*")
		{
			var sbSz = 261U;
			var sb = new StringBuilder((int)sbSz);
			var nr = new NETRESOURCE(remoteName, null, provider) { dwType = NETRESOURCEType.RESOURCETYPE_DISK };
			WNetUseConnection(default, nr, password, userName, flags | CONNECT.CONNECT_REDIRECT, sb, ref sbSz, out _).WNetThrowIfFailed();
			nr.lpLocalName = sb.ToString();
			return new NetworkDeviceConnection(nr, WindowsIdentity.GetCurrent());
		}
		else
		{
			var nr = new NETRESOURCE(remoteName, localName, provider) { dwType = isPrinter ? NETRESOURCEType.RESOURCETYPE_PRINT : (localName is null ? NETRESOURCEType.RESOURCETYPE_ANY : NETRESOURCEType.RESOURCETYPE_DISK) };
			WNetAddConnection2(nr, password, userName, flags).WNetThrowIfFailed();
			return new NetworkDeviceConnection(nr, WindowsIdentity.GetCurrent());
		}
	}

	/// <summary>Implements the operator !=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(NetworkDeviceConnection left, NetworkDeviceConnection right) => !(left == right);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(NetworkDeviceConnection left, NetworkDeviceConnection right) => EqualityComparer<NetworkDeviceConnection>.Default.Equals(left, right);

	/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
	/// <returns><see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
	public override bool Equals(object? obj) => Equals(obj as NetworkDeviceConnection);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(NetworkDeviceConnection other) => other != null && LocalName == other.LocalName && RemoteName == other.RemoteName;

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => netRes.GetHashCode();
}

/// <summary>Provides access to the local machine's remote connections.</summary>
/// <seealso cref="System.Collections.Generic.ICollection{T}"/>
public class NetworkDeviceConnectionCollection : ICollection<NetworkDeviceConnection>
{
	internal WindowsIdentity identity;
	private NETRESOURCE root;

	/// <summary>Initializes a new instance of the <see cref="NetworkDeviceConnectionCollection"/> class.</summary>
	public NetworkDeviceConnectionCollection() { }

	internal NetworkDeviceConnectionCollection(WindowsIdentity user, NETRESOURCE root)
	{
		identity = user;
		this.root = root;
	}

	/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</summary>
	public bool IsReadOnly => false;

	/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
	public int Count => Enumerate().Count();

	/// <summary>
	/// Removes an existing network connection. You can also call the function to remove remembered network connections that are not
	/// currently connected.
	/// </summary>
	/// <param name="name">
	/// <para>A string that specifies the name of either the redirected local device or the remote network resource to disconnect from.</para>
	/// <para>
	/// If this parameter specifies a redirected local device, the function cancels only the specified device redirection. If the
	/// parameter specifies a remote network resource, all connections without devices are canceled.
	/// </para>
	/// </param>
	/// <param name="removePersistence">
	/// <para>
	/// If <see langword="true"/>, the system updates the user profile with the information that the connection is no longer a
	/// persistent one. The system will not restore this connection during subsequent logon operations. (Disconnecting resources using
	/// remote names has no effect on persistent connections.)
	/// </para>
	/// <para>
	/// If <see langword="false"/>, the system does not update information about the connection. If the connection was marked as
	/// persistent in the registry, the system continues to restore the connection at the next logon.
	/// </para>
	/// </param>
	/// <param name="force">
	/// Specifies whether the disconnection should occur if there are open files or jobs on the connection. If this parameter is <see
	/// langword="false"/>, the function fails if there are open files or jobs.
	/// </param>
	public static void RemoveConnection(string name, bool force = false, bool removePersistence = true) =>
		WNetCancelConnection2(name, removePersistence ? CONNECT.CONNECT_UPDATE_PROFILE : 0, force).WNetThrowIfFailed();

	/// <summary>Makes a connection to a network resource and can redirect a local device to the network resource.</summary>
	/// <param name="remoteName">
	/// A string that specifies the network resource to connect to. The string must follow the network provider's naming conventions.
	/// </param>
	/// <param name="localName">
	/// A string that specifies the name of a local device to redirect, such as "F:" or "LPT1". The string is treated in a
	/// case-insensitive manner. If the string is empty or <see langword="null"/>, the function makes a connection to the network
	/// resource without redirecting a local device.
	/// </param>
	/// <param name="isPrinter">if set to <see langword="true"/>, the resource specified in <paramref name="remoteName"/> is a printer.</param>
	/// <param name="password">
	/// <para>A pointer to a constant <c>null</c>-terminated string that specifies a password to be used in making the network connection.</para>
	/// <para>
	/// If lpPassword is <c>NULL</c>, the function uses the current default password associated with the user specified by the
	/// lpUserName parameter.
	/// </para>
	/// <para>If lpPassword points to an empty string, the function does not use a password.</para>
	/// <para>
	/// If the connection fails because of an invalid password and the CONNECT_INTERACTIVE value is set in the dwFlags parameter, the
	/// function displays a dialog box asking the user to type the password.
	/// </para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="userName">
	/// <para>A pointer to a constant <c>null</c>-terminated string that specifies a user name for making the connection.</para>
	/// <para>
	/// If lpUserName is <c>NULL</c>, the function uses the default user name. (The user context for the process provides the default
	/// user name.)
	/// </para>
	/// <para>
	/// The lpUserName parameter is specified when users want to connect to a network resource for which they have been assigned a user
	/// name or account other than the default user name or account.
	/// </para>
	/// <para>The user-name string represents a security context. It may be specific to a network provider.</para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="flags">A set of connection options.</param>
	/// <param name="provider">
	/// A string that specifies the network provider to connect to. If <see langword="null"/>, or an empty string, the operating system
	/// attempts to determine the correct provider by parsing the string provided in <paramref name="remoteName"/>. If this member is
	/// not <see langword="null"/>, the operating system attempts to make a connection only to the named network provider. You should
	/// set this member only if you know the network provider you want to use. Otherwise, let the operating system determine which
	/// provider the network name maps to.
	/// </param>
	public string Add(string remoteName, string localName = null, string userName = null, string password = null, bool isPrinter = false, CONNECT flags = 0, string provider = null)
	{
		var nr = identity.Run(() => NetworkDeviceConnection.Create(remoteName, localName, userName, password, isPrinter, flags, provider));
		nr.identity = identity;
		return nr.LocalName;
	}

	/// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
	public void Clear()
	{
		foreach (var r in Enumerate().ToList())
			Remove(r);
	}

	/// <summary>
	/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting
	/// at a particular <see cref="T:System.Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see
	/// cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	public void CopyTo(NetworkDeviceConnection[] array, int arrayIndex)
	{
		var arr = Enumerate().ToArray();
		Array.Copy(arr, 0, array, arrayIndex, arr.Length);
	}

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<NetworkDeviceConnection> GetEnumerator() => Enumerate().GetEnumerator();

	/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
	/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>;
	/// otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
	/// </returns>
	public bool Remove(NetworkDeviceConnection item) { try { Remove(item.RemoteName, false, true); return true; } catch { return false; } }

	/// <summary>
	/// Removes an existing network connection. You can also call the function to remove remembered network connections that are not
	/// currently connected.
	/// </summary>
	/// <param name="name">
	/// <para>A string that specifies the name of either the redirected local device or the remote network resource to disconnect from.</para>
	/// <para>
	/// If this parameter specifies a redirected local device, the function cancels only the specified device redirection. If the
	/// parameter specifies a remote network resource, all connections without devices are canceled.
	/// </para>
	/// </param>
	/// <param name="removePersistence">
	/// <para>
	/// If <see langword="true"/>, the system updates the user profile with the information that the connection is no longer a
	/// persistent one. The system will not restore this connection during subsequent logon operations. (Disconnecting resources using
	/// remote names has no effect on persistent connections.)
	/// </para>
	/// <para>
	/// If <see langword="false"/>, the system does not update information about the connection. If the connection was marked as
	/// persistent in the registry, the system continues to restore the connection at the next logon.
	/// </para>
	/// </param>
	/// <param name="force">
	/// Specifies whether the disconnection should occur if there are open files or jobs on the connection. If this parameter is <see
	/// langword="false"/>, the function fails if there are open files or jobs.
	/// </param>
	public void Remove(string name, bool force = false, bool removePersistence = true) => identity.Run(() => RemoveConnection(name, force, removePersistence));

	/// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
	/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
	void ICollection<NetworkDeviceConnection>.Add(NetworkDeviceConnection item) => WNetAddConnection2(item.netRes, null, null, 0);

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
	/// </returns>
	bool ICollection<NetworkDeviceConnection>.Contains(NetworkDeviceConnection item) => Enumerate().Contains(item);

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private IEnumerable<NetworkDeviceConnection> Enumerate()
	{
		return identity.Run(() =>
			root is null || root.dwUsage.IsFlagSet(NETRESOURCEUsage.RESOURCEUSAGE_CONTAINER) ? 
				WNetEnumResources(root, NETRESOURCEScope.RESOURCE_CONNECTED).Select(r => new NetworkDeviceConnection(r, identity)) :
				new NetworkDeviceConnection[0]);
	}
}