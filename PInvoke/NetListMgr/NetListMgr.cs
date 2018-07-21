using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global

[assembly: Guid("DCB00D01-570F-4A9B-8D69-199FDBA5723B")]
#if !NETSTANDARD2_0
[assembly: TypeLibVersion(1, 0)]
[assembly: ImportedFromTypeLib("NETWORKLIST")]
#endif
[assembly: PrimaryInteropAssembly(1, 0)]

namespace Vanara.PInvoke.NetListMgr
{
	/// <summary>The <see cref="NLM_CONNECTION_COST"/> enumeration specifies a set of cost levels and cost flags supported in Windows 8 Cost APIs.</summary>
	[Flags]
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_CONNECTION_COST : uint
	{
		/// <summary>The cost is unknown.</summary>
		NLM_CONNECTION_COST_UNKNOWN = 0x0,

		/// <summary>The connection is unlimited and is considered to be unrestricted of usage charges and capacity constraints.</summary>
		NLM_CONNECTION_COST_UNRESTRICTED = 0x1,

		/// <summary>The use of this connection is unrestricted up to a specific data transfer limit.</summary>
		NLM_CONNECTION_COST_FIXED = 0x2,

		/// <summary>This connection is regulated on a per byte basis.</summary>
		NLM_CONNECTION_COST_VARIABLE = 0x4,

		/// <summary>The connection is currently in an OverDataLimit state as it has exceeded the carrier specified data transfer limit.</summary>
		NLM_CONNECTION_COST_OVERDATALIMIT = 0x10000,

		/// <summary>The network is experiencing high traffic load and is congested.</summary>
		NLM_CONNECTION_COST_CONGESTED = 0x20000,

		/// <summary>The connection is roaming outside the network and affiliates of the home provider.</summary>
		NLM_CONNECTION_COST_ROAMING = 0x40000,

		/// <summary>The connection is approaching the data limit specified by the carrier.</summary>
		NLM_CONNECTION_COST_APPROACHINGDATALIMIT = 0x80000
	}

	/// <summary>The NLM_CONNECTION PROPERTY_CHANGE enumeration is a set of flags that define changes made to the properties of a network connection.</summary>
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_CONNECTION_PROPERTY_CHANGE
	{
		/// <summary>The Authentication (Domain Type) of this Network Connection has changed.</summary>
		NLM_CONNECTION_PROPERTY_CHANGE_AUTHENTICATION = 1
	}

	/// <summary>The NLM_Connectivity enumeration is a set of flags that provide notification whenever connectivity related parameters have changed.</summary>
	[Flags]
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_CONNECTIVITY
	{
		/// <summary>The underlying network interfaces have no connectivity to any network.</summary>
		NLM_CONNECTIVITY_DISCONNECTED = 0x0000,

		/// <summary>There is connectivity to a network, but the service cannot detect any IPv4 Network Traffic.</summary>
		NLM_CONNECTIVITY_IPV4_NOTRAFFIC = 0x0001,

		/// <summary>There is connectivity to a network, but the service cannot detect any IPv6 Network Traffic.</summary>
		NLM_CONNECTIVITY_IPV6_NOTRAFFIC = 0x0002,

		/// <summary>There is connectivity to the local subnet using the IPv4 protocol.</summary>
		NLM_CONNECTIVITY_IPV4_SUBNET = 0x0010,

		/// <summary>There is connectivity to a routed network using the IPv4 protocol.</summary>
		NLM_CONNECTIVITY_IPV4_LOCALNETWORK = 0x0020,

		/// <summary>There is connectivity to the Internet using the IPv4 protocol.</summary>
		NLM_CONNECTIVITY_IPV4_INTERNET = 0x0040,

		/// <summary>There is connectivity to the local subnet using the IPv6 protocol.</summary>
		NLM_CONNECTIVITY_IPV6_SUBNET = 0x0100,

		/// <summary>There is connectivity to a local network using the IPv6 protocol.</summary>
		NLM_CONNECTIVITY_IPV6_LOCALNETWORK = 0x0200,

		/// <summary>There is connectivity to the Internet using the IPv6 protocol.</summary>
		NLM_CONNECTIVITY_IPV6_INTERNET = 0x0400
	}

	/// <summary>The NLM_DOMAIN_TYPE enumeration is a set of flags that specify the domain type of a network.</summary>
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_DOMAIN_TYPE
	{
		/// <summary>The Network is not an Active Directory Network.</summary>
		NLM_DOMAIN_TYPE_NON_DOMAIN_NETWORK = 0x0,

		/// <summary>The Network is an Active Directory Network, but this machine is not authenticated against it.</summary>
		NLM_DOMAIN_TYPE_DOMAIN_NETWORK = 0x01,

		/// <summary>The Network is an Active Directory Network, and this machine is authenticated against it.</summary>
		NLM_DOMAIN_TYPE_DOMAIN_AUTHENTICATED = 0x02
	}

	/// <summary>The NLM_ENUM_NETWORK enumeration contains a set of flags that specify what types of networks are enumerated.</summary>
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_ENUM_NETWORK
	{
		/// <summary>Returns connected networks</summary>
		NLM_ENUM_NETWORK_CONNECTED = 0x01,

		/// <summary>Returns disconnected networks</summary>
		NLM_ENUM_NETWORK_DISCONNECTED = 0x02,

		/// <summary>Returns connected and disconnected networks</summary>
		NLM_ENUM_NETWORK_ALL = 0x03
	}

	[Flags]
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_INTERNET_CONNECTIVITY
	{
		NLM_INTERNET_CONNECTIVITY_WEBHIJACK = 0x1,
		NLM_INTERNET_CONNECTIVITY_PROXIED = 0x2,
		NLM_INTERNET_CONNECTIVITY_CORPORATE = 0x4
	}

	/// <summary>The NLM_NETWORK_CATEGORY enumeration is a set of flags that specify the category type of a network.</summary>
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_NETWORK_CATEGORY
	{
		/// <summary>The network is a public (untrusted) network.</summary>
		NLM_NETWORK_CATEGORY_PUBLIC,

		/// <summary>The network is a private (trusted) network.</summary>
		NLM_NETWORK_CATEGORY_PRIVATE,

		/// <summary>The network is authenticated against an Active Directory domain.</summary>
		NLM_NETWORK_CATEGORY_DOMAIN_AUTHENTICATED
	}

	[Flags]
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_NETWORK_CLASS
	{
		NLM_NETWORK_IDENTIFYING = 0x1,
		NLM_NETWORK_IDENTIFIED = 0x2,
		NLM_NETWORK_UNIDENTIFIED = 0x3
	}

	/// <summary>The NLM_NETWORK_PROPERTY_CHANGE enumeration is a set of flags that define changes made to the properties of a network.</summary>
	[PInvokeData("Netlistmgr.h")]
	public enum NLM_NETWORK_PROPERTY_CHANGE
	{
		/// <summary>The category of the network has changed.</summary>
		NLM_NETWORK_PROPERTY_CHANGE_CATEGORY_VALUE = 0x10,

		/// <summary>A connection to this network has been added or removed.</summary>
		NLM_NETWORK_PROPERTY_CHANGE_CONNECTION = 1,

		/// <summary>The description of the network has changed.</summary>
		NLM_NETWORK_PROPERTY_CHANGE_DESCRIPTION = 2,

		/// <summary>The icon of the network has changed.</summary>
		NLM_NETWORK_PROPERTY_CHANGE_ICON = 8,

		/// <summary>The name of the network has changed.</summary>
		NLM_NETWORK_PROPERTY_CHANGE_NAME = 4
	}

	/// <summary>
	/// The IEnumNetworkConnections interface provides a standard enumerator for network connections. It enumerates active, disconnected, or all network
	/// connections within a network. This interface can be obtained from the INetwork interface.
	/// </summary>
	/// <seealso cref="System.Collections.IEnumerable"/>
	[ComImport, TypeLibType(TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FDual), Guid("DCB00006-570F-4A9B-8D69-199FDBA5723B")]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "aa370706")]
	public interface IEnumNetworkConnections : IEnumerable
	{
		[DispId(-4)]
#if !NETSTANDARD2_0
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "", MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler), MarshalCookie = "")]
		new IEnumerator GetEnumerator();
#else
		object _NewEnum { get; }
#endif

		/// <summary>Gets the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">Number of elements requested.</param>
		/// <param name="rgelt">Pointer to a list of pointers returned by INetworkConnection.</param>
		/// <param name="pceltFetched">Pointer to the number of elements supplied. May be NULL if celt is one.</param>
		[DispId(1), PreserveSig]
		HRESULT Next(uint celt, [MarshalAs(UnmanagedType.Interface)] out INetworkConnection rgelt, out uint pceltFetched);

		/// <summary>The Skip method skips over the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">Number of elements to skip over in the enumeration.</param>
		[DispId(2), PreserveSig]
		HRESULT Skip([In] uint celt);

		/// <summary>The Reset method resets the enumeration sequence to the beginning.</summary>
		[DispId(3), PreserveSig]
		HRESULT Reset();

		/// <summary>The Clone method creates an enumerator that contains the same enumeration state as the enumerator currently in use.</summary>
		/// <returns>Pointer to new IEnumNetworkConnections interface instance.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(4)]
		IEnumNetworkConnections Clone();
	}

	/// <summary>Enumerates all networks available on the server. This interface can be obtained from the INetwork interface.</summary>
	/// <seealso cref="System.Collections.IEnumerable"/>
	[ComImport, TypeLibType(TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FDual), Guid("DCB00003-570F-4A9B-8D69-199FDBA5723B")]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "aa370735")]
	public interface IEnumNetworks : IEnumerable
	{
		[DispId(-4)]
#if !NETSTANDARD2_0
		[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "", MarshalTypeRef = typeof(System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler), MarshalCookie = "")]
		new IEnumerator GetEnumerator();
#else
		object _NewEnum { get; }
#endif

		/// <summary>Gets the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">Number of elements requested.</param>
		/// <param name="rgelt">Pointer to a list of pointers returned by INetworkConnection.</param>
		/// <param name="pceltFetched">Pointer to the number of elements supplied. May be NULL if celt is one.</param>
		[DispId(1), PreserveSig]
		HRESULT Next(uint celt, [MarshalAs(UnmanagedType.Interface)] out INetwork rgelt, out uint pceltFetched);

		/// <summary>The Skip method skips over the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="celt">Number of elements to skip over in the enumeration.</param>
		[DispId(2), PreserveSig]
		HRESULT Skip([In] uint celt);

		/// <summary>The Reset method resets the enumeration sequence to the beginning.</summary>
		[DispId(3), PreserveSig]
		HRESULT Reset();

		/// <summary>The Clone method creates an enumerator that contains the same enumeration state as the enumerator currently in use.</summary>
		/// <returns>Pointer to new IEnumNetworks interface instance.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(4)]
		IEnumNetworks Clone();
	}

	/// <summary>
	/// The INetwork interface represents a network on the local machine. It can also represent a collection of network connections with a similar network signature.
	/// </summary>
	[ComImport, TypeLibType(TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FDual), Guid("DCB00002-570F-4A9B-8D69-199FDBA5723B")]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "aa370750")]
	public interface INetwork
	{
		/// <summary>Returns the name of the network.</summary>
		/// <returns>Pointer to the name of the network.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		[DispId(1)]
		string GetName();

		/// <summary>Sets or renames the network. This change occurs immediately.</summary>
		/// <param name="szNetworkNewName">Zero-terminated string that contains the new name of the network.</param>
		[DispId(2)]
		void SetName([In, MarshalAs(UnmanagedType.BStr)] string szNetworkNewName);

		/// <summary>Returns a description string for the network.</summary>
		/// <returns>A string that specifies the text description of the network. This value must be freed using the SysFreeString API.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		[DispId(3)]
		string GetDescription();

		/// <summary>Sets a new description for the network.</summary>
		/// <param name="szDescription">Zero-terminated string that contains the description of the network.</param>
		[DispId(4)]
		void SetDescription([In, MarshalAs(UnmanagedType.BStr)] string szDescription);

		/// <summary>Returns the unique identifier of a network.</summary>
		/// <returns>Pointer to a GUID that specifies the network ID.</returns>
		[DispId(5)]
		Guid GetNetworkId();

		/// <summary>Returns the type of network.</summary>
		/// <returns>An NLM_DOMAIN_TYPE enumeration value that specifies the domain type of the network.</returns>
		[DispId(6)]
		NLM_DOMAIN_TYPE GetDomainType();

		/// <summary>
		/// Returns an enumeration of all network connections for a network. A network can have multiple connections to it from different interfaces or
		/// different links from the same interface.
		/// </summary>
		/// <returns>An IEnumNetworkConnections interface instance that enumerates the list of local connections to this network.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(7)]
		IEnumNetworkConnections GetNetworkConnections();

		/// <summary>Returns the local date and time when the network was created and connected.</summary>
		/// <param name="pdwLowDateTimeCreated">Pointer to a datetime when the network was created. Specifically, it contains the low DWORD of <see cref="FILETIME.dwLowDateTime"/>.</param>
		/// <param name="pdwHighDateTimeCreated">Pointer to a datetime when the network was created. Specifically, it contains the high DWORD of <see cref="FILETIME.dwHighDateTime"/>.</param>
		/// <param name="pdwLowDateTimeConnected">
		/// Pointer to a datetime when the network was last connected to. Specifically, it contains the low DWORD of <see cref="FILETIME.dwLowDateTime"/>.
		/// </param>
		/// <param name="pdwHighDateTimeConnected">
		/// Pointer to a datetime when the network was last connected to. Specifically, it contains the high DWORD of <see cref="FILETIME.dwHighDateTime"/>.
		/// </param>
		[DispId(8)]
		void GetTimeCreatedAndConnected(out uint pdwLowDateTimeCreated, out uint pdwHighDateTimeCreated,
			out uint pdwLowDateTimeConnected, out uint pdwHighDateTimeConnected);

		/// <summary>Specifies if the network has internet connectivity.</summary>
		/// <value>If TRUE, this network has connectivity to the internet; if FALSE, it does not.</value>
		[DispId(9)]
		bool IsConnectedToInternet { [DispId(9)] get; }

		/// <summary>Specifies if the network has any network connectivity.</summary>
		/// <value>If TRUE, this network is connected; if FALSE, it is not.</value>
		[DispId(10)]
		bool IsConnected { [DispId(10)] get; }

		/// <summary>Returns the connectivity state of the network.</summary>
		/// <returns>A NLM_CONNECTIVITY enumeration value that contains a bitmask that specifies the connectivity state of this network.</returns>
		[DispId(11)]
		NLM_CONNECTIVITY GetConnectivity();

		/// <summary>Returns the category of a network.</summary>
		/// <returns>A NLM_NETWORK_CATEGORY enumeration value that specifies the category information for the network.</returns>
		[DispId(12)]
		NLM_NETWORK_CATEGORY GetCategory();

		/// <summary>Sets the category of a network. Administrative privileges are needed for this API call.</summary>
		/// <param name="NewCategory">The new category.</param>
		[DispId(13)]
		void SetCategory([In] NLM_NETWORK_CATEGORY NewCategory);
	}

	/// <summary>The INetworkConnection interface represents a single network connection.</summary>
	[ComImport, TypeLibType(TypeLibTypeFlags.FDispatchable | TypeLibTypeFlags.FDual), Guid("DCB00005-570F-4A9B-8D69-199FDBA5723B")]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "aa370751")]
	public interface INetworkConnection
	{
		/// <summary>Returns the associated network for the connection.</summary>
		/// <returns>An INetwork interface instance that specifies the network associated with the connection.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(1)]
		INetwork GetNetwork();

		/// <summary>Specifies if the associated network connection has internet connectivity.</summary>
		/// <value>If TRUE, this network connection has connectivity to the internet; if FALSE, it does not.</value>
		[DispId(2)]
		bool IsConnectedToInternet { [DispId(2)] get; }

		/// <summary>Specifies if the associated network connection has any network connectivity.</summary>
		/// <value>If TRUE, this network connection has connectivity; if FALSE, it does not.</value>
		[DispId(3)]
		bool IsConnected { [DispId(3)] get; }

		/// <summary>Returns the connectivity state of the network.</summary>
		/// <returns>A NLM_CONNECTIVITY enumeration value that contains a bitmask that specifies the connectivity of this network connection.</returns>
		[DispId(4)]
		NLM_CONNECTIVITY GetConnectivity();

		/// <summary>Returns the Connection ID associated with this network connection.</summary>
		/// <returns>A GUID that specifies the Connection ID associated with this network connection.</returns>
		[DispId(5)]
		Guid GetConnectionId();

		/// <summary>Returns the ID of the network adapter used by this connection. There may multiple connections using the same adapter ID.</summary>
		/// <returns>A GUID that specifies the adapter ID of the TCP/IP interface used by this network connection.</returns>
		[DispId(6)]
		Guid GetAdapterId();

		/// <summary>Returns the type of network connection.</summary>
		/// <returns>An NLM_DOMAIN_TYPE enumeration value that specifies the domain type of the network.</returns>
		[DispId(7)]
		NLM_DOMAIN_TYPE GetDomainType();
	}

	/// <summary>Use this interface to query current network cost and data plan status associated with a connection.</summary>
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("DCB0000A-570F-4A9B-8D69-199FDBA5723B")]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "hh448251")]
	public interface INetworkConnectionCost
	{
		/// <summary>Retrieves the network cost associated with a connection.</summary>
		/// <returns>
		/// A DWORD value that represents the network cost of the connection. The lowest 16 bits represent the cost level and the highest 16 bits represent
		/// the cost flags. Possible values are defined by the <see cref="NLM_CONNECTION_COST"/> enumeration.
		/// </returns>
		NLM_CONNECTION_COST GetCost();

		/// <summary>Gets the data plan status.</summary>
		/// <returns>
		/// An NLM_DATAPLAN_STATUS structure that describes the status of the data plan associated with the connection. The caller supplies the memory of
		/// this structure.
		/// </returns>
		NLM_DATAPLAN_STATUS GetDataPlanStatus();
	}

	/// <summary>Use this interface to notify an application of cost and data plan status change events for a connection.</summary>
	[ComImport, Guid("DCB0000B-570F-4A9B-8D69-199FDBA5723B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(NetworkListManager))]
	[PInvokeData("Netlistmgr.h")]
	public interface INetworkConnectionCostEvents
	{
		/// <summary>The ConnectionCostChanged method notifies an application of a network cost change for a connection.</summary>
		/// <param name="connectionId">A unique ID that identifies the connection on which the cost change event occurred.</param>
		/// <param name="newCost">
		/// A DWORD value that represents the new cost of the connection. The lowest 16 bits represent the cost level, and the highest 16 bits represent the
		/// flags. Possible values are defined by the <see cref="NLM_CONNECTION_COST"/> enumeration.
		/// </param>
		void ConnectionCostChanged([In] Guid connectionId, [In] NLM_CONNECTION_COST newCost);

		/// <summary>The ConnectionDataPlanStatusChanged method notifies an application of a data plan status change on a connection.</summary>
		/// <param name="connectionId">A unique ID that identifies the connection on which the data plan status change event occurred.</param>
		void ConnectionDataPlanStatusChanged([In] Guid connectionId);
	}

	/// <summary>
	/// The INetworkConnectionEvents interface is a message sink interface that a client implements to get network connection-related events. Applications
	/// that are interested in lower-level events (such as authentication changes) must implement this interface.
	/// </summary>
	[ComImport, Guid("DCB00007-570F-4A9B-8D69-199FDBA5723B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), TypeLibType(TypeLibTypeFlags.FOleAutomation), CoClass(typeof(NetworkListManager))]
	[PInvokeData("Netlistmgr.h")]
	public interface INetworkConnectionEvents
	{
		/// <summary>
		/// The NetworkConnectionConnectivityChanged method notifies a client when connectivity change events occur on a network connection level.
		/// </summary>
		/// <param name="connectionId">A GUID that identifies the network connection on which the event occurred.</param>
		/// <param name="newConnectivity">NLM_CONNECTIVITY enumeration value that specifies the new connectivity for this network connection.</param>
		void NetworkConnectionConnectivityChanged([In] Guid connectionId, [In] NLM_CONNECTIVITY newConnectivity);

		/// <summary>
		/// The NetworkConnectionPropertyChanged method notifies a client when property change events related to a specific network connection occur.
		/// </summary>
		/// <param name="connectionId">A GUID that identifies the network connection on which the event occurred.</param>
		/// <param name="Flags">The NLM_CONNECTION_PROPERTY_CHANGE flags for this connection.</param>
		void NetworkConnectionPropertyChanged([In] Guid connectionId, [In] NLM_CONNECTION_PROPERTY_CHANGE Flags);
	}

	/// <summary>
	/// Use this interface to query for machine-wide cost and data plan status information associated with either a connection used for machine-wide Internet
	/// connectivity, or the first-hop of routing to a specific destination on a connection. Additionally, this interface enables applications to specify
	/// destination IP addresses to receive cost or data plan status change notifications for.
	/// </summary>
	[ComImport, Guid("DCB00008-570F-4A9B-8D69-199FDBA5723B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(NetworkListManager))]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "hh448257")]
	public interface INetworkCostManager
	{
		/// <summary>
		/// The GetCost method retrieves the current cost of either a machine-wide internet connection, or the first-hop of routing to a specific destination
		/// on a connection. If destIPaddr is NULL, this method instead returns the cost of the network used for machine-wide Internet connectivity.
		/// </summary>
		/// <param name="pCost">
		/// A DWORD value that indicates the cost of the connection. The lowest 16 bits represent the cost level, and the highest 16 bits represent the
		/// flags. Possible values are defined by the <see cref="NLM_CONNECTION_COST"/> enumeration.
		/// </param>
		/// <param name="pDestIPAddr">
		/// An <see cref="NLM_SOCKADDR"/> structure containing the destination IPv4/IPv6 address. If NULL, this method will instead return the cost associated with the
		/// preferred connection used for machine Internet connectivity.
		/// </param>
		void GetCost(out NLM_CONNECTION_COST pCost, [In] IntPtr pDestIPAddr);

		/// <summary>
		/// The GetDataPlanStatus retrieves the data plan status for either a machine-wide internet connection , or the first-hop of routing to a specific
		/// destination on a connection. If an IPv4/IPv6 address is not specified, this method returns the data plan status of the connection used for
		/// machine-wide Internet connectivity.
		/// </summary>
		/// <param name="pDataPlanStatus">
		/// Pointer to an NLM_DATAPLAN_STATUS structure that describes the data plan status associated with a connection used to route to a destination. If
		/// destIPAddr specifies a tunnel address, the first available data plan status in the interface stack is returned.
		/// </param>
		/// <param name="pDestIPAddr">
		/// An <see cref="NLM_SOCKADDR"/> structure containing the destination IPv4/IPv6 or tunnel address. If NULL, this method returns the cost associated with the
		/// preferred connection used for machine Internet connectivity.
		/// </param>
		void GetDataPlanStatus(out NLM_DATAPLAN_STATUS pDataPlanStatus, [In] IntPtr pDestIPAddr);

		/// <summary>
		/// The SetDestinationAddresses method registers specified destination IPv4/IPv6 addresses to receive cost or data plan status change notifications.
		/// </summary>
		/// <param name="length">The number of destination IPv4/IPv6 addresses in the list.</param>
		/// <param name="pDestIPAddrList">
		/// A <see cref="NLM_SOCKADDR"/> structure containing a list of destination IPv4/IPv6 addresses to register for cost or data plan status change notification.
		/// </param>
		/// <param name="bAppend">If true, pDestIPAddrList will be appended to the existing address list; otherwise the existing list will be overwritten.</param>
		void SetDestinationAddresses([In] uint length, [In] IntPtr pDestIPAddrList, [In] bool bAppend);
	}

	/// <summary>Use this interface to notify an application of machine-wide cost and data plan related events.</summary>
	[ComImport, Guid("DCB00009-570F-4A9B-8D69-199FDBA5723B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(NetworkListManager))]
	[PInvokeData("Netlistmgr.h")]
	public interface INetworkCostManagerEvents
	{
		/// <summary>
		/// The CostChanged method is called to indicates a cost change for either machine-wide Internet connectivity, or the first-hop of routing to a
		/// specific destination on a connection.
		/// </summary>
		/// <param name="newCost">
		/// A DWORD that represents the new cost of the connection. The lowest 16 bits represent the cost level, and the highest 16 bits represent the flags.
		/// Possible values are defined by the <see cref="NLM_CONNECTION_COST"/> enumeration.
		/// </param>
		/// <param name="pDestAddr">
		/// An <see cref="NLM_SOCKADDR"/> structure containing an IPv4/IPv6 address that identifies the destination on which the event occurred. If destAddr is NULL, the
		/// change is a machine-wide Internet connectivity change.
		/// </param>
		void CostChanged([In] NLM_CONNECTION_COST newCost, [In] ref NLM_SOCKADDR pDestAddr);

		/// <summary>
		/// The DataPlanStatusChanged method is called to indicate a change to the status of a data plan associated with either a connection used for
		/// machine-wide Internet connectivity, or the first-hop of routing to a specific destination on a connection.
		/// </summary>
		/// <param name="pDestAddr">
		/// An <see cref="NLM_SOCKADDR"/> structure containing an IPv4/IPv6 address that identifies the destination for which the event occurred. If destAddr is NULL, the
		/// change is a machine-wide Internet connectivity change.
		/// </param>
		void DataPlanStatusChanged([In] ref NLM_SOCKADDR pDestAddr);
	}

	/// <summary>
	/// INetworkEvents is a notification sink interface that a client implements to get network related events. These APIs are all callback functions that
	/// are called automatically when the respective events are raised.
	/// </summary>
	[ComImport, Guid("DCB00004-570F-4A9B-8D69-199FDBA5723B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), TypeLibType(TypeLibTypeFlags.FOleAutomation), CoClass(typeof(NetworkListManager))]
	[PInvokeData("Netlistmgr.h")]
	public interface INetworkEvents
	{
		/// <summary>The NetworkAdded method is called when a new network is added. The GUID of the new network is provided.</summary>
		/// <param name="networkId">A GUID that specifies the new network that was added.</param>
		void NetworkAdded([In] Guid networkId);

		/// <summary>The NetworkDeleted method is called when a network is deleted.</summary>
		/// <param name="networkId">GUID that contains the network ID of the network that was deleted.</param>
		void NetworkDeleted([In] Guid networkId);

		/// <summary>The NetworkConnectivityChanged method is called when network connectivity related changes occur.</summary>
		/// <param name="networkId">A GUID that specifies the new network that was added.</param>
		/// <param name="newConnectivity">NLM_CONNECTIVITY enumeration value that contains the new connectivity of this network</param>
		void NetworkConnectivityChanged([In] Guid networkId, [In] NLM_CONNECTIVITY newConnectivity);

		/// <summary>The NetworkPropertyChanged method is called when a network property change is detected.</summary>
		/// <param name="networkId">GUID that specifies the network on which this event occurred.</param>
		/// <param name="Flags">NLM_NETWORK_PROPERTY_CHANGE enumeration value that specifies the network property that changed.</param>
		void NetworkPropertyChanged([In] Guid networkId, [In] NLM_NETWORK_PROPERTY_CHANGE Flags);
	}

	/// <summary>The INetworkListManager interface provides a set of methods to perform network list management functions.</summary>
	[TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable)]
	[ComImport, Guid("DCB00000-570F-4A9B-8D69-199FDBA5723B"), CoClass(typeof(NetworkListManager))]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "aa370769")]
	public interface INetworkListManager
	{
		/// <summary>Retrieves networks based on the supplied Network IDs.</summary>
		/// <param name="Flags">NLM_ENUM_NETWORK enumeration value that specifies the flags for the network (specifically, connected or not connected).</param>
		/// <returns>An IEnumNetworks interface instance that contains the enumerator for the list of available networks.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(1)]
		IEnumNetworks GetNetworks([In] NLM_ENUM_NETWORK Flags);

		/// <summary>Retrieves a network based on a supplied Network ID.</summary>
		/// <param name="gdNetworkId">GUID that specifies the network ID.</param>
		/// <returns>The INetwork interface instance for this network.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(2)]
		INetwork GetNetwork([In] Guid gdNetworkId);

		/// <summary>Gets an enumerator that contains a complete list of the network connections that have been made.</summary>
		/// <returns>An IEnumNetworkConnections interface instance that enumerates all network connections on the machine.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(3)]
		IEnumNetworkConnections GetNetworkConnections();

		/// <summary>Retrieves a network based on a supplied Network Connection ID.</summary>
		/// <param name="gdNetworkConnectionId">A GUID that specifies the Network Connection ID.</param>
		/// <returns>A INetworkConnection object associated with the supplied gdNetworkConnectionId.</returns>
		[return: MarshalAs(UnmanagedType.Interface)]
		[DispId(4)]
		INetworkConnection GetNetworkConnection([In] Guid gdNetworkConnectionId);

		/// <summary>Specifies if the machine has Internet connectivity.</summary>
		/// <value>If TRUE, the local machine is connected to the internet; if FALSE, it is not.</value>
		[DispId(5)]
		bool IsConnectedToInternet { [DispId(5)] get; }

		/// <summary>Specifies if the local machine has network connectivity.</summary>
		/// <value>
		/// If TRUE , the network has at least local connectivity via ipv4 or ipv6 or both. The network may also have internet connectivity. Thus, the
		/// network is connected. If FALSE, the network does not have local or internet connectivity.The network is not connected.
		/// </value>
		[DispId(6)]
		bool IsConnected { [DispId(6)] get; }

		/// <summary>Returns the connectivity state of all the networks on a machine.</summary>
		/// <returns>An NLM_CONNECTIVITY enumeration value that contains a bitmask that specifies the network connectivity of this machine.</returns>
		[DispId(7)]
		NLM_CONNECTIVITY GetConnectivity();

		/// <summary>
		/// Applies a specific set of connection profile values to the internet connection profile in support of the simulation of specific metered internet
		/// connection conditions.
		/// <para>
		/// The simulation only applies in an RDP Child Session and does not affect the primary user session. The simulated internet connection profile is
		/// returned via the Windows Runtime API GetInternetConnectionProfile.
		/// </para>
		/// </summary>
		/// <param name="pSimulatedInfo">
		/// Specific connection profile values to simulate on the current internet connection profile when calling GetInternetConnectionProfile from an RDP
		/// Child Session
		/// </param>
		[DispId(8)]
		void SetSimulatedProfileInfo([In] ref NLM_SIMULATED_PROFILE_INFO pSimulatedInfo);

		/// <summary>
		/// Clears the connection profile values previously applied to the internet connection profile by SetSimulatedProfileInfo. The next internet
		/// connection query, via GetInternetConnectionProfile, will use system information.
		/// </summary>
		[DispId(9)]
		void ClearSimulatedProfileInfo();
	}

	/// <summary>
	/// INetworkListManagerEvents is a message sink interface that a client implements to get overall machine state related events. Applications that are
	/// interested on higher-level events, for example internet connectivity, implement this interface.
	/// </summary>
	[ComImport, Guid("DCB00001-570F-4A9B-8D69-199FDBA5723B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(NetworkListManager)), TypeLibType(TypeLibTypeFlags.FOleAutomation)]
	[PInvokeData("Netlistmgr.h")]
	public interface INetworkListManagerEvents
	{
		/// <summary>Called when network connectivity related changes occur.</summary>
		/// <param name="newConnectivity">An NLM_CONNECTIVITY enumeration value that contains the new connectivity settings of the machine.</param>
		void ConnectivityChanged([In] NLM_CONNECTIVITY newConnectivity);
	}

	/// <summary>The NetworkListManager class is the base CoClass for all interfaces.</summary>
	[ComImport, Guid("DCB00C01-570F-4A9B-8D69-199FDBA5723B"), ClassInterface(ClassInterfaceType.None)]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "aa370769")]
	public class NetworkListManager { }

	/// <summary>Valid property names strings for use with IPropertyBag interface calls.</summary>
	public static class NetworkPropertyName
	{
		/// <summary>Specifies that a domain network is not able to authenticate against the domain controller.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_DomainAuthenticationFailed = "NA_DomainAuthenticationFailed";
		/// <summary>Specifies the class of network.</summary>
		[CorrespondingType(typeof(uint))]
		public const string NA_NetworkClass = "NA_NetworkClass";
		/// <summary>The name of the network has been set by group policy.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_NameSetByPolicy = "NA_NameSetByPolicy";
		/// <summary>The icon of the network has been set by group policy.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_IconSetByPolicy = "NA_IconSetByPolicy";
		/// <summary>The description of the network has been set by group policy.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_DescriptionSetByPolicy = "NA_DescriptionSetByPolicy";
		/// <summary>The category of the network has been set by group policy.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_CategorySetByPolicy = "NA_CategorySetByPolicy";
		/// <summary>The name of the network is read only.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_NameReadOnly = "NA_NameReadOnly";
		/// <summary>The icon of the network is read only.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_IconReadOnly = "NA_IconReadOnly";
		/// <summary>The description of the network is read only.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_DescriptionReadOnly = "NA_DescriptionReadOnly";
		/// <summary>The category of the network is read only.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_CategoryReadOnly = "NA_CategoryReadOnly";
		/// <summary>The network can be merged with another network.</summary>
		[CorrespondingType(typeof(bool))]
		public const string NA_AllowMerge = "NA_AllowMerge";
		/// <summary>Provides details regarding IPv4 or IPv6 network connectivity.</summary>
		[CorrespondingType(typeof(uint))]
		public const string NA_InternetConnectivityV4 = "NA_InternetConnectivityV4";
		/// <summary>Provides details regarding IPv4 or IPv6 network connectivity.</summary>
		[CorrespondingType(typeof(uint))]
		public const string NA_InternetConnectivityV6 = "NA_InternetConnectivityV6";
	}

	/// <summary>The NLM_DATAPLAN_STATUS structure stores the current data plan status information supplied by the carrier.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "hh448265")]
	public struct NLM_DATAPLAN_STATUS
	{
		/// <summary>
		/// The unique ID of the interface associated with the data plan. This GUID is determined by the system when a data plan is first used by a system connection.
		/// </summary>
		public Guid InterfaceGuid;

		/// <summary>
		/// An NLM_USAGE_DATA structure containing current data usage value expressed in megabytes, as well as the system time at the moment this value was
		/// last synced.
		/// <para>
		/// If this value is not supplied, NLM_USAGE_DATA will indicate NLM_UNKNOWN_DATAPLAN_STATUS for UsageInMegabytes and a value of '0' will be set for LastSyncTime.
		/// </para>
		/// </summary>
		public NLM_USAGE_DATA UsageData;

		/// <summary>
		/// The data plan usage limit expressed in megabytes. If this value is not supplied, a default value of NLM_UNKNOWN_DATAPLAN_STATUS is set.
		/// </summary>
		public uint DataLimitInMegabytes;

		/// <summary>
		/// The maximum inbound connection bandwidth expressed in kbps. If this value is not supplied, a default value of NLM_UNKNOWN_DATAPLAN_STATUS is set.
		/// </summary>
		public uint InboundBandwidthInKbps;

		/// <summary>
		/// The maximum outbound connection bandwidth expressed in kbps. If this value is not supplied, a default value of NLM_UNKNOWN_DATAPLAN_STATUS is set.
		/// </summary>
		public uint OutboundBandwidthInKbps;

		/// <summary>The start time of the next billing cycle. If this value is not supplied, a default value of '0' is set.</summary>
		public FILETIME NextBillingCycle;

		/// <summary>
		/// The maximum suggested transfer size for this network expressed in megabytes. If this value is not supplied, a default value of
		/// NLM_UNKNOWN_DATAPLAN_STATUS is set.
		/// </summary>
		public uint MaxTransferSizeInMegabytes;

		/// <summary>Reserved for future use.</summary>
		public uint Reserved;
	}

	/// <summary>
	/// Used to specify values that are used by SetSimulatedProfileInfo to override current internet connection profile values in an RDP Child Session to
	/// support the simulation of specific metered internet connection conditions.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "dn280985")]
	public struct NLM_SIMULATED_PROFILE_INFO
	{
		/// <summary>Name for the simulated profile.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string ProfileName;

		/// <summary>The network cost.</summary>
		public NLM_CONNECTION_COST cost;

		/// <summary>The data usage.</summary>
		public uint UsageInMegabytes;

		/// <summary>The data limit of the plan.</summary>
		public uint DataLimitInMegabytes;
	}

	/// <summary>The <see cref="NLM_SOCKADDR"/> structure contains the IPv4/IPv6 destination address.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "hh448266")]
	public struct NLM_SOCKADDR
	{
		private const int dataSize = 128;

		/// <summary>An IPv4/IPv6 destination address.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = dataSize)] public byte[] data;

		/// <summary>Creates a <see cref="NLM_SOCKADDR"/> from an <see cref="IPAddress"/> instance.</summary>
		/// <param name="address">The IP address to encapsulate.</param>
		/// <returns>A <see cref="NLM_SOCKADDR"/> instance with its data field set to either the IPv4 or IPv6 address supplied by <paramref name="address"/>.</returns>
		public static NLM_SOCKADDR FromIPAddress(IPAddress address)
		{
			const ushort AF_INET = 2;
			const ushort AF_INET6 = 23;

			if (address == null) throw new ArgumentNullException(nameof(address));

			var sockAddr = new NLM_SOCKADDR { data = new byte[dataSize] };

			// Seems to be compatible with SOCKADDR_STORAGE, which in turn is compatible with SOCKADDR_IN and SOCKADDR_IN6
			using (var writer = new BinaryWriter(new MemoryStream(sockAddr.data)))
			{
				if (address.AddressFamily == AddressFamily.InterNetwork)
				{
					// AF_INT
					writer.Write(AF_INET);
					// Port
					writer.Write((ushort)0);
					// Flow Info
					writer.Write((uint)0);
					// Address
					writer.Write(address.GetAddressBytes());
				}
				else
				{
					// AF_INT6
					writer.Write(AF_INET6);
					// Port
					writer.Write((ushort)0);
					// Flow Info
					writer.Write((uint)0);
					// Address
					writer.Write(address.GetAddressBytes());
					// Scope ID
					writer.Write((ulong)address.ScopeId);
				}
			}

			return sockAddr;
		}
	}

	/// <summary>The NLM_USAGE_DATA structure stores information that indicates the data usage of a plan.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[PInvokeData("Netlistmgr.h", MSDNShortId = "hh448268")]
	public struct NLM_USAGE_DATA
	{
		/// <summary>The data usage of a plan, represented in megabytes.</summary>
		public uint UsageInMegabytes;

		/// <summary>The timestamp of last time synced with carriers about the data usage stored in this structure.</summary>
		public FILETIME LastSyncTime;
	}

#if NETSTANDARD2_0
	[Serializable, Flags, ComVisible(true)]
	internal enum TypeLibTypeFlags
	{
		FAggregatable = 0x400,
		FAppObject = 1,
		FCanCreate = 2,
		FControl = 0x20,
		FDispatchable = 0x1000,
		FDual = 0x40,
		FHidden = 0x10,
		FLicensed = 4,
		FNonExtensible = 0x80,
		FOleAutomation = 0x100,
		FPreDeclId = 8,
		FReplaceable = 0x800,
		FRestricted = 0x200,
		FReverseBind = 0x2000
	}

	[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Class, Inherited = false), ComVisible(true)]
	internal sealed class TypeLibTypeAttribute : Attribute
	{
		internal TypeLibTypeFlags _val;
		public TypeLibTypeAttribute(short flags) => _val = (TypeLibTypeFlags)flags;
		public TypeLibTypeAttribute(TypeLibTypeFlags flags) => _val = flags;
		// Properties
		public TypeLibTypeFlags Value => _val;
	}
#endif
}