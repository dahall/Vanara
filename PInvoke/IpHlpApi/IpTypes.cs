using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>
		/// <para>The <c>FIXED_INFO</c> structure contains information that is the same across all the interfaces on a computer.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>FIXED_INFO</c> structure is retrieved by the GetNetworkParams function.</para>
		/// <para>
		/// In the Microsoft Windows Software Development Kit (SDK), the <c>FIXED_INFO_WIN2KSP1</c> structure is defined. When compiling an
		/// application if the target platform is Windows 2000 with Service Pack 1 (SP1) and later (, , or ), the <c>FIXED_INFO_WIN2KSP1</c>
		/// struct is typedefed to the <c>FIXED_INFO</c> structure. When compiling an application if the target platform is not Windows 2000
		/// with SP1 and later, the <c>FIXED_INFO</c> structure is undefined.
		/// </para>
		/// <para>
		/// The GetNetworkParams function and the <c>FIXED_INFO</c> structure are supported on Windows 98and later. But to build an
		/// application for a target platform earlier than Windows 2000 with Service Pack 1 (SP1), an earlier version of the Platform
		/// Software Development Kit (SDK) must be used.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code retrieves a <c>FIXED_INFO</c> structure that contains network configuration information for the local
		/// computer. The code prints selected members from the structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-fixed_info_w2ksp1 typedef struct FIXED_INFO_W2KSP1 { char
		// HostName[MAX_HOSTNAME_LEN + 4]; char DomainName[MAX_DOMAIN_NAME_LEN + 4]; PIP_ADDR_STRING CurrentDnsServer; IP_ADDR_STRING
		// DnsServerList; UINT NodeType; char ScopeId[MAX_SCOPE_ID_LEN + 4]; UINT EnableRouting; UINT EnableProxy; UINT EnableDns; } *PFIXED_INFO_W2KSP1;
		[PInvokeData("iptypes.h", MSDNShortId = "6dcf33c6-33dc-4583-9b04-5231948d3d9a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct FIXED_INFO
		{
			/// <summary>
			/// <para>Type: <c>char[MAX_HOSTNAME_LEN + 4]</c></para>
			/// <para>
			/// The hostname for the local computer. This may be the fully qualified hostname (including the domain) for a computer that is
			/// joined to a domain.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HOSTNAME_LEN + 4)]
			public string HostName;

			/// <summary>
			/// <para>Type: <c>char[MAX_DOMAIN_NAME_LEN + 4]</c></para>
			/// <para>The domain in which the local computer is registered.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HOSTNAME_LEN + 4)]
			public string DomainName;

			/// <summary>
			/// <para>Type: <c>PIP_ADDR_STRING</c></para>
			/// <para>Reserved. Use the <c>DnsServerList</c> member to obtain the DNS servers for the local computer.</para>
			/// </summary>
			public IntPtr CurrentDnsServer;

			/// <summary>
			/// <para>Type: <c>IP_ADDR_STRING</c></para>
			/// <para>A linked list of IP_ADDR_STRING structures that specify the set of DNS servers used by the local computer.</para>
			/// </summary>
			public IP_ADDR_STRING DnsServerList;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The node type of the local computer. These values are defined in the Iptypes.h header file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>NodeType</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BROADCAST_NODETYPE 0x0001</term>
			/// <term>A broadcast nodetype.</term>
			/// </item>
			/// <item>
			/// <term>PEER_TO_PEER_NODETYPE 0x0002</term>
			/// <term>A peer to peer nodetype.</term>
			/// </item>
			/// <item>
			/// <term>MIXED_NODETYPE 0x0004</term>
			/// <term>A mixed nodetype.</term>
			/// </item>
			/// <item>
			/// <term>HYBRID_NODETYPE 0x0008</term>
			/// <term>A hybrid nodetype.</term>
			/// </item>
			/// </list>
			/// </summary>
			public NetBiosNodeType NodeType;

			/// <summary>
			/// <para>Type: <c>char[MAX_SCOPE_ID_LEN + 4]</c></para>
			/// <para>The DHCP scope name.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SCOPE_ID_LEN + 4)]
			public string ScopeId;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>A Boolean value that specifies whether routing is enabled on the local computer.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool EnableRouting;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>A Boolean value that specifies whether the local computer is acting as an ARP proxy.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool EnableProxy;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>A Boolean value that specifies whether DNS is enabled on the local computer.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool EnableDns;

			/// <summary>
			/// <para>A list of IP_ADDR_STRING structures that specify the set of DNS servers used by the local computer.</para>
			/// </summary>
			public IEnumerable<IP_ADDR_STRING> DnsServers
			{
				get
				{
					if (DnsServerList.IpAddress != null)
						yield return DnsServerList;
					var next = DnsServerList.GetNext();
					while (next != null)
					{
						yield return next.Value;
						next = next.Value.GetNext();
					}
				}
			}
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_ADDRESSES</c> structure is the header node for a linked list of addresses for a particular adapter. This
		/// structure can simultaneously be used as part of a linked list of <c>IP_ADAPTER_ADDRESSES</c> structures.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The GetAdaptersAddresses function retrieves information for IPv4 and IPv6 addresses and returns this information as a linked list
		/// of <c>IP_ADAPTER_ADDRESSES</c> structures
		/// </para>
		/// <para>
		/// The adapter index values specified in the <c>IfIndex</c> and <c>Ipv6IfIndex</c> members may change when an adapter is disabled
		/// and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// <para>
		/// The values for the <c>IfType</c> member are defined in the Ipifcons.h header file. Only the possible values listed in the
		/// description of the <c>IfType</c> member are currently supported.
		/// </para>
		/// <para>
		/// The size of the <c>IP_ADAPTER_ADDRESSES</c> structure changed on Windows XP with SP1 and later. The size of the
		/// <c>IP_ADAPTER_ADDRESSES</c> structure also changed on Windows Vista and later. The size of the <c>IP_ADAPTER_ADDRESSES</c>
		/// structure also changed on Windows Vista with SP1and later and onWindows Server 2008 and later. The <c>Length</c> member should be
		/// used to determine which version of the <c>IP_ADAPTER_ADDRESSES</c> structure is being used.
		/// </para>
		/// <para>
		/// The version of the <c>IP_ADAPTER_ADDRESSES</c> structure on Windows XP with SP1 and later has the following new members added:
		/// <c>Ipv6IfIndex</c>, <c>ZoneIndices</c>, and <c>FirstPrefix</c>.
		/// </para>
		/// <para>
		/// The version of the <c>IP_ADAPTER_ADDRESSES</c> structure on Windows Vista and later has the following new members added:
		/// <c>TransmitLinkSpeed</c>, <c>ReceiveLinkSpeed</c>, <c>FirstWinsServerAddress</c>, <c>FirstGatewayAddress</c>, <c>Ipv4Metric</c>,
		/// <c>Ipv6Metric</c>, <c>Luid</c>, <c>Dhcpv4Server</c>, <c>CompartmentId</c>, <c>NetworkGuid</c>, <c>ConnectionType</c>,
		/// <c>TunnelType</c>, <c>Dhcpv6Server</c>, <c>Dhcpv6ClientDuid</c>, <c>Dhcpv6ClientDuidLength</c>, and <c>Dhcpv6Iaid</c>.
		/// </para>
		/// <para>
		/// The version of the <c>IP_ADAPTER_ADDRESSES</c> structure on Windows Vista with SP1and later and on Windows Server 2008 and later
		/// has the following new member added: <c>FirstDnsSuffix</c>.
		/// </para>
		/// <para>
		/// The <c>Ipv4Metric</c> and <c>Ipv6Metric</c> members are used to prioritize route metrics for routes connected to multiple
		/// interfaces on the local computer.
		/// </para>
		/// <para>
		/// The order of linked IP_ADAPTER_UNICAST_ADDRESS structures pointed to by the <c>FirstUnicastAddress</c> member that are returned
		/// by the GetAdaptersAddresses function does not reflect the order that IP addresses were added to an adapter and may vary between
		/// versions of Windows. Similarly, the order of linked <c>IP_ADAPTER_ANYCAST_ADDRESS</c> structures pointed to by the
		/// <c>FirstAnycastAddress</c> member and the order of linked <c>IP_ADAPTER_MULTICAST_ADDRESS</c> structures pointed to by the
		/// <c>FirstMulticastAddress</c> member do not reflect the order that IP addresses were added to an adapter and may vary between
		/// versions of Windows.
		/// </para>
		/// <para>
		/// In addition, the linked IP_ADAPTER_UNICAST_ADDRESS structures pointed to by the <c>FirstUnicastAddress</c> member and the linked
		/// IP_ADAPTER_PREFIXstructures pointed to by the <c>FirstPrefix</c> member are maintained as separate internal linked lists by the
		/// operating system. As a result, the order of linked <c>IP_ADAPTER_UNICAST_ADDRESS</c> structures pointed to by the
		/// <c>FirstUnicastAddress</c> member does not have any relationship with the order of linked <c>IP_ADAPTER_PREFIX</c> structures
		/// pointed to by the <c>FirstPrefix</c> member.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the linked IP_ADAPTER_PREFIXstructures pointed to by the <c>FirstPrefix</c> member include three IP
		/// adapter prefixes for each IP address assigned to the adapter. These include the host IP address prefix, the subnet IP address
		/// prefix, and the subnet broadcast IP address prefix. In addition, for each adapter there is a multicast address prefix and a
		/// broadcast address prefix.
		/// </para>
		/// <para>
		/// On Windows XP with SP1 and later prior to Windows Vista, the linked IP_ADAPTER_PREFIXstructures pointed to by the
		/// <c>FirstPrefix</c> member include only a single IP adapter prefix for each IP address assigned to the adapter.
		/// </para>
		/// <para>
		/// In the Windows SDK, the version of the structure for use on Windows Vista and later is defined as <c>IP_ADAPTER_ADDRESSES_LH</c>.
		/// In the Microsoft Windows Software Development Kit (SDK), the version of this structure to be used on earlier systems including
		/// Windows XP with SP1 and later is defined as <c>IP_ADAPTER_ADDRESSES_XP</c>. When compiling an application if the target platform
		/// is Windows Vista and later (, , or ), the <c>IP_ADAPTER_ADDRESSES_LH</c> structure is typedefed to the
		/// <c>IP_ADAPTER_ADDRESSES</c> structure. When compiling an application if the target platform is not Windows Vista and later, the
		/// <c>IP_ADAPTER_ADDRESSES_XP</c> structure is typedefed to the <c>IP_ADAPTER_ADDRESSES</c> structure.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_ADDRESSES</c> structure. On the Windows SDK released for Windows Vista
		/// and later, the organization of header files has changed and the <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header
		/// file which is automatically included by the Winsock2.h header file. On the Platform Software Development Kit (SDK) released for
		/// Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c> structure is declared in the Winsock2.h header file. In order to
		/// use the <c>IP_ADAPTER_ADDRESSES</c> structure, the Winsock2.h header file must be included before the Iphlpapi.h header file.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// This example retrieves the <c>IP_ADAPTER_ADDRESSES</c> structure for the adapters associated with the system and prints some
		/// members for each adapter interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_addresses_lh typedef struct
		// _IP_ADAPTER_ADDRESSES_LH { union { ULONGLONG Alignment; struct { ULONG Length; IF_INDEX IfIndex; }; }; struct
		// _IP_ADAPTER_ADDRESSES_LH *Next; PCHAR AdapterName; PIP_ADAPTER_UNICAST_ADDRESS_LH FirstUnicastAddress;
		// PIP_ADAPTER_ANYCAST_ADDRESS_XP FirstAnycastAddress; PIP_ADAPTER_MULTICAST_ADDRESS_XP FirstMulticastAddress;
		// PIP_ADAPTER_DNS_SERVER_ADDRESS_XP FirstDnsServerAddress; PWCHAR DnsSuffix; PWCHAR Description; PWCHAR FriendlyName; BYTE
		// PhysicalAddress[MAX_ADAPTER_ADDRESS_LENGTH]; ULONG PhysicalAddressLength; union { ULONG Flags; struct { ULONG DdnsEnabled : 1;
		// ULONG RegisterAdapterSuffix : 1; ULONG Dhcpv4Enabled : 1; ULONG ReceiveOnly : 1; ULONG NoMulticast : 1; ULONG
		// Ipv6OtherStatefulConfig : 1; ULONG NetbiosOverTcpipEnabled : 1; ULONG Ipv4Enabled : 1; ULONG Ipv6Enabled : 1; ULONG
		// Ipv6ManagedAddressConfigurationSupported : 1; }; }; ULONG Mtu; IFTYPE IfType; IF_OPER_STATUS OperStatus; IF_INDEX Ipv6IfIndex;
		// ULONG ZoneIndices[16]; PIP_ADAPTER_PREFIX_XP FirstPrefix; ULONG64 TransmitLinkSpeed; ULONG64 ReceiveLinkSpeed;
		// PIP_ADAPTER_WINS_SERVER_ADDRESS_LH FirstWinsServerAddress; PIP_ADAPTER_GATEWAY_ADDRESS_LH FirstGatewayAddress; ULONG Ipv4Metric;
		// ULONG Ipv6Metric; IF_LUID Luid; SOCKET_ADDRESS Dhcpv4Server; NET_IF_COMPARTMENT_ID CompartmentId; NET_IF_NETWORK_GUID NetworkGuid;
		// NET_IF_CONNECTION_TYPE ConnectionType; TUNNEL_TYPE TunnelType; SOCKET_ADDRESS Dhcpv6Server; BYTE
		// Dhcpv6ClientDuid[MAX_DHCPV6_DUID_LENGTH]; ULONG Dhcpv6ClientDuidLength; ULONG Dhcpv6Iaid; PIP_ADAPTER_DNS_SUFFIX FirstDnsSuffix; }
		// IP_ADAPTER_ADDRESSES_LH, *PIP_ADAPTER_ADDRESSES_LH;
		[PInvokeData("iptypes.h", MSDNShortId = "a2df3749-6c75-40c0-8952-1656bbe639a6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_ADDRESSES
		{
			public uint Length;
			public uint IfIndex;

			/// <summary>
			/// <para>Type: <c>struct _IP_ADAPTER_ADDRESSES*</c></para>
			/// <para>A pointer to the next adapter addresses structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>Type: <c>PCHAR</c></para>
			/// <para>
			/// An array of characters that contains the name of the adapter with which these addresses are associated. Unlike an adapter's
			/// friendly name, the adapter name specified in <c>AdapterName</c> is permanent and cannot be modified by the user.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string AdapterName;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_UNICAST_ADDRESS</c></para>
			/// <para>A pointer to the first IP_ADAPTER_UNICAST_ADDRESS structure in a linked list of IP unicast addresses for the adapter.</para>
			/// </summary>
			public IntPtr FirstUnicastAddress;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_ANYCAST_ADDRESS</c></para>
			/// <para>A pointer to the first IP_ADAPTER_ANYCAST_ADDRESS structure in a linked list of IP anycast addresses for the adapter.</para>
			/// </summary>
			public IntPtr FirstAnycastAddress;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_MULTICAST_ADDRESS</c></para>
			/// <para>A pointer to the first IP_ADAPTER_MULTICAST_ADDRESS structure in a list of IP multicast addresses for the adapter.</para>
			/// </summary>
			public IntPtr FirstMulticastAddress;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_DNS_SERVER_ADDRESS</c></para>
			/// <para>A pointer to the first IP_ADAPTER_DNS_SERVER_ADDRESS structure in a linked list of DNS server addresses for the adapter.</para>
			/// </summary>
			public IntPtr FirstDnsServerAddress;

			/// <summary>
			/// <para>Type: <c>PWCHAR</c></para>
			/// <para>The Domain Name System (DNS) suffix associated with this adapter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string DnsSuffix;

			/// <summary>
			/// <para>Type: <c>PWCHAR</c></para>
			/// <para>A description for the adapter. This member is read-only.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Description;

			/// <summary>
			/// <para>Type: <c>PWCHAR</c></para>
			/// <para>
			/// A user-friendly name for the adapter. For example: "Local Area Connection 1." This name appears in contexts such as the
			/// <c>ipconfig</c> command line program and the Connection folder. This member is read only and can't be modified using any IP
			/// Helper functions.
			/// </para>
			/// <para>
			/// This member is the ifAlias field used by NDIS as described in RFC 2863. The ifAlias field can be set by an NDIS interface
			/// provider when the NDIS driver is installed. For NDIS miniport drivers, this field is set by NDIS.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string FriendlyName;

			/// <summary>
			/// <para>Type: <c>BYTE[MAX_ADAPTER_ADDRESS_LENGTH]</c></para>
			/// <para>
			/// The Media Access Control (MAC) address for the adapter. For example, on an Ethernet network this member would specify the
			/// Ethernet hardware address.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ADAPTER_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The length, in bytes, of the address specified in the <c>PhysicalAddress</c> member. For interfaces that do not have a
			/// data-link layer, this value is zero.
			/// </para>
			/// </summary>
			public uint PhysicalAddressLength;

			public IP_ADAPTER_FLAGS Flags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum transmission unit (MTU) size, in bytes.</para>
			/// </summary>
			public uint Mtu;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The interface type as defined by the Internet Assigned Names Authority (IANA). Possible values for the interface type are
			/// listed in the Ipifcons.h header file.
			/// </para>
			/// <para>The table below lists common values for the interface type although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IF_TYPE_OTHER 1</term>
			/// <term>Some other type of network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ETHERNET_CSMACD 6</term>
			/// <term>An Ethernet network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ISO88025_TOKENRING 9</term>
			/// <term>A token ring network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_PPP 23</term>
			/// <term>A PPP network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_SOFTWARE_LOOPBACK 24</term>
			/// <term>A software loopback network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ATM 37</term>
			/// <term>An ATM network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_IEEE80211 71</term>
			/// <term>
			/// An IEEE 802.11 wireless network interface. On Windows Vista and later, wireless network cards are reported as
			/// IF_TYPE_IEEE80211. On earlier versions of Windows, wireless network cards are reported as IF_TYPE_ETHERNET_CSMACD. On Windows
			/// XP with SP3 and on Windows XP with SP2 x86 with the Wireless LAN API for Windows XP with SP2 installed, the
			/// WlanEnumInterfaces function can be used to enumerate wireless interfaces on the local computer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_TUNNEL 131</term>
			/// <term>A tunnel type encapsulation network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_IEEE1394 144</term>
			/// <term>An IEEE 1394 (Firewire) high performance serial bus network interface.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IFTYPE IfType;

			/// <summary>
			/// <para>Type: <c>IF_OPER_STATUS</c></para>
			/// <para>
			/// The operational status for the interface as defined in RFC 2863. For more information, see
			/// http://www.ietf.org/rfc/rfc2863.txt. This member can be one of the values from the <c>IF_OPER_STATUS</c> enumeration type
			/// defined in the Iftypes.h header file. On Windows Vista and later, the header files were reorganized and this enumeration is
			/// defined in the Ifdef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IfOperStatusUp 1</term>
			/// <term>The interface is up and able to pass packets.</term>
			/// </item>
			/// <item>
			/// <term>IfOperStatusDown 2</term>
			/// <term>
			/// The interface is down and not in a condition to pass packets. The IfOperStatusDown state has two meanings, depending on the
			/// value of AdminStatus member. If AdminStatus is not set to NET_IF_ADMIN_STATUS_DOWN and ifOperStatus is set to
			/// IfOperStatusDown then a fault condition is presumed to exist on the interface. If AdminStatus is set to IfOperStatusDown,
			/// then ifOperStatus will normally also be set to IfOperStatusDown or IfOperStatusNotPresent and there is not necessarily a
			/// fault condition on the interface.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IfOperStatusTesting 3</term>
			/// <term>The interface is in testing mode.</term>
			/// </item>
			/// <item>
			/// <term>IfOperStatusUnknown 4</term>
			/// <term>The operational status of the interface is unknown.</term>
			/// </item>
			/// <item>
			/// <term>IfOperStatusDormant 5</term>
			/// <term>
			/// The interface is not actually in a condition to pass packets (it is not up), but is in a pending state, waiting for some
			/// external event. For on-demand interfaces, this new state identifies the situation where the interface is waiting for events
			/// to place it in the IfOperStatusUp state.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IfOperStatusNotPresent 6</term>
			/// <term>
			/// A refinement on the IfOperStatusDown state which indicates that the relevant interface is down specifically because some
			/// component (typically, a hardware component) is not present in the managed system.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IfOperStatusLowerLayerDown 7</term>
			/// <term>
			/// A refinement on the IfOperStatusDown state. This new state indicates that this interface runs on top of one or more other
			/// interfaces and that this interface is down specifically because one or more of these lower-layer interfaces are down.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public IF_OPER_STATUS OperStatus;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The interface index for the IPv6 IP address. This member is zero if IPv6 is not available on the interface.</para>
			/// <para><c>Note</c> This structure member is only available on Windows XP with SP1 and later.</para>
			/// </summary>
			private readonly uint Ipv6IfIndex;

			/// <summary>
			/// <para>Type: <c>DWORD[16]</c></para>
			/// <para>
			/// An array of scope IDs for each scope level used for composing sockaddr structures. The SCOPE_LEVEL enumeration is used to
			/// index the array. On IPv6, a single interface may be assigned multiple IPv6 multicast addresses based on a scope ID.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows XP with SP1 and later.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public SCOPE_LEVEL[] ZoneIndices;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_PREFIX</c></para>
			/// <para>A pointer to the first IP_ADAPTER_PREFIX structure in a linked list of IP adapter prefixes for the adapter.</para>
			/// <para><c>Note</c> This structure member is only available on Windows XP with SP1 and later.</para>
			/// </summary>
			public IntPtr FirstPrefix;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The current speed in bits per second of the transmit link for the adapter.</para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public ulong TrasmitLinkSpeed;

			/// <summary>
			/// <para>Type: <c>ULONG64</c></para>
			/// <para>The current speed in bits per second of the receive link for the adapter.</para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public ulong ReceiveLinkSpeed;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_WINS_SERVER_ADDRESS_LH</c></para>
			/// <para>
			/// A pointer to the first IP_ADAPTER_WINS_SERVER_ADDRESS structure in a linked list of Windows Internet Name Service (WINS)
			/// server addresses for the adapter.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public IntPtr FirstWinsServerAddress;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_GATEWAY_ADDRESS_LH</c></para>
			/// <para>A pointer to the first IP_ADAPTER_GATEWAY_ADDRESS structure in a linked list of gateways for the adapter.</para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public IntPtr FirstGatewayAddress;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The IPv4 interface metric for the adapter address. This member is only applicable to an IPv4 adapter address.</para>
			/// <para>
			/// The actual route metric used to compute the route preferences for IPv4 is the summation of the route metric offset specified
			/// in the <c>Metric</c> member of the MIB_IPFORWARD_ROW2 structure and the interface metric specified in this member for IPv4.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public uint Ipv4Metric;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The IPv6 interface metric for the adapter address. This member is only applicable to an IPv6 adapter address.</para>
			/// <para>
			/// The actual route metric used to compute the route preferences for IPv6 is the summation of the route metric offset specified
			/// in the <c>Metric</c> member of the MIB_IPFORWARD_ROW2 structure and the interface metric specified in this member for IPv4.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public uint Ipv6Metric;

			/// <summary>
			/// <para>Type: <c>IF_LUID</c></para>
			/// <para>The interface LUID for the adapter address.</para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public NET_LUID Luid;

			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>
			/// The IPv4 address of the DHCP server for the adapter address. This member is only applicable to an IPv4 adapter address
			/// configured using DHCP.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public SOCKET_ADDRESS Dhcpv4Server;

			/// <summary>
			/// <para>Type: <c>NET_IF_COMPARTMENT_ID</c></para>
			/// <para>The routing compartment ID for the adapter address.</para>
			/// <para>
			/// <c>Note</c> This structure member is only available on Windows Vista and later. This member is not currently supported and is
			/// reserved for future use.
			/// </para>
			/// </summary>
			public uint CompartmentId;

			/// <summary>
			/// <para>Type: <c>NET_IF_NETWORK_GUID</c></para>
			/// <para>The <c>GUID</c> that is associated with the network that the interface belongs to.</para>
			/// <para>
			/// If the interface provider cannot provide the network GUID, this member can be a zero <c>GUID</c>. In this case, the interface
			/// was registered by NDIS in the default network.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public Guid NetworkGuid;

			/// <summary>
			/// <para>Type: <c>NET_IF_CONNECTION_TYPE</c></para>
			/// <para>The interface connection type for the adapter address.</para>
			/// <para>
			/// This member can be one of the values from the <c>NET_IF_CONNECTION_TYPE</c> enumeration type defined in the Ifdef.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NET_IF_CONNECTION_DEDICATED 1</term>
			/// <term>
			/// The connection type is dedicated. The connection comes up automatically when media sense is TRUE. For example, an Ethernet
			/// connection is dedicated.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NET_IF_CONNECTION_PASSIVE 2</term>
			/// <term>
			/// The connection type is passive. The remote end must bring up the connection to the local station. For example, a RAS
			/// interface is passive.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NET_IF_CONNECTION_DEMAND 3</term>
			/// <term>
			/// The connection type is demand-dial. A connection of this type comes up in response to a local action (sending a packet, for example).
			/// </term>
			/// </item>
			/// <item>
			/// <term>NET_IF_CONNECTION_MAXIMUM 4</term>
			/// <term>
			/// The maximum possible value for the NET_IF_CONNECTION_TYPE enumeration type. This is not a legal value for ConnectionType member.
			/// </term>
			/// </item>
			/// </list>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public NET_IF_CONNECTION_TYPE ConnectionType;

			/// <summary>
			/// <para>Type: <c>TUNNEL_TYPE</c></para>
			/// <para>The encapsulation method used by a tunnel if the adapter address is a tunnel.</para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// <para>The tunnel type is defined by the Internet Assigned Names Authority (IANA). For more information, see</para>
			/// <para>http://www.iana.org/assignments/ianaiftype-mib</para>
			/// <para>. This member can be one of the values from the</para>
			/// <para>TUNNEL_TYPE</para>
			/// <para>enumeration type defined in the</para>
			/// <para>Ifdef.h</para>
			/// <para>header file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TUNNEL_TYPE_NONE 0</term>
			/// <term>Not a tunnel.</term>
			/// </item>
			/// <item>
			/// <term>TUNNEL_TYPE_OTHER 1</term>
			/// <term>None of the following tunnel types.</term>
			/// </item>
			/// <item>
			/// <term>TUNNEL_TYPE_DIRECT 2</term>
			/// <term>
			/// A packet is encapsulated directly within a normal IP header, with no intermediate header, and unicast to the remote tunnel endpoint.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TUNNEL_TYPE_6TO4 11</term>
			/// <term>
			/// An IPv6 packet is encapsulated directly within an IPv4 header, with no intermediate header, and unicast to the destination
			/// determined by the 6to4 protocol.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TUNNEL_TYPE_ISATAP 13</term>
			/// <term>
			/// An IPv6 packet is encapsulated directly within an IPv4 header, with no intermediate header, and unicast to the destination
			/// determined by the ISATAP protocol.
			/// </term>
			/// </item>
			/// <item>
			/// <term>TUNNEL_TYPE_TEREDO 14</term>
			/// <term>Teredo encapsulation for IPv6 packets.</term>
			/// </item>
			/// <item>
			/// <term>TUNNEL_TYPE_IPHTTPS 15</term>
			/// <term>IP over HTTPS encapsulation for IPv6 packets.</term>
			/// </item>
			/// </list>
			/// </summary>
			public TUNNEL_TYPE TunnelType;

			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>
			/// The IPv6 address of the DHCPv6 server for the adapter address. This member is only applicable to an IPv6 adapter address
			/// configured using DHCPv6. This structure member is not currently supported and is reserved for future use.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public SOCKET_ADDRESS Dhcpv6Server;

			/// <summary>
			/// <para>Type: <c>BYTE[MAX_DHCPV6_DUID_LENGTH]</c></para>
			/// <para>
			/// The DHCP unique identifier (DUID) for the DHCPv6 client. This member is only applicable to an IPv6 adapter address configured
			/// using DHCPv6.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DHCPV6_DUID_LENGTH)]
			public byte[] Dhcpv6ClientDuid;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The length, in bytes, of the DHCP unique identifier (DUID) for the DHCPv6 client. This member is only applicable to an IPv6
			/// adapter address configured using DHCPv6.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public uint Dhcpv6ClientDuidLength;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The identifier for an identity association chosen by the DHCPv6 client. This member is only applicable to an IPv6 adapter
			/// address configured using DHCPv6.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public uint Dhcpv6Iaid;

			/// <summary>
			/// <para>Type: <c>PIP_ADAPTER_DNS_SUFFIX</c></para>
			/// <para>A pointer to the first IP_ADAPTER_DNS_SUFFIX structure in a linked list of DNS suffixes for the adapter.</para>
			/// <para>
			/// <c>Note</c> This structure member is only available on Windows Vista with SP1and later and on Windows Server 2008 and later.
			/// </para>
			/// </summary>
			public IntPtr FirstDnsSuffix;

			public IEnumerable<IP_ADAPTER_UNICAST_ADDRESS> UnicastAddresses => FirstUnicastAddress.LinkedListToIEnum<IP_ADAPTER_UNICAST_ADDRESS>(t => t.Next);
			public IEnumerable<IP_ADAPTER_ANYCAST_ADDRESS> AnycastAddresses => FirstAnycastAddress.LinkedListToIEnum<IP_ADAPTER_ANYCAST_ADDRESS>(t => t.Next);
			public IEnumerable<IP_ADAPTER_MULTICAST_ADDRESS> MulticastAddresses => FirstMulticastAddress.LinkedListToIEnum<IP_ADAPTER_MULTICAST_ADDRESS>(t => t.Next);
			public IEnumerable<IP_ADAPTER_DNS_SERVER_ADDRESS> DnsServerAddresses => FirstDnsServerAddress.LinkedListToIEnum<IP_ADAPTER_DNS_SERVER_ADDRESS>(t => t.Next);
			public IEnumerable<IP_ADAPTER_PREFIX> Prefixes => FirstPrefix.LinkedListToIEnum<IP_ADAPTER_PREFIX>(t => t.Next);
			public IEnumerable<IP_ADAPTER_WINS_SERVER_ADDRESS> WinsServerAddresses => FirstWinsServerAddress.LinkedListToIEnum<IP_ADAPTER_WINS_SERVER_ADDRESS>(t => t.Next);
			public IEnumerable<IP_ADAPTER_GATEWAY_ADDRESS> GatewayAddresses => FirstGatewayAddress.LinkedListToIEnum<IP_ADAPTER_GATEWAY_ADDRESS>(t => t.Next);
			public IEnumerable<IP_ADAPTER_DNS_SUFFIX> DnsSuffixes => FirstDnsSuffix.LinkedListToIEnum<IP_ADAPTER_DNS_SUFFIX>(t => t.Next);

			public IP_ADAPTER_ADDRESSES? GetNext() => Next.ToNullableStructure<IP_ADAPTER_ADDRESSES>();

			public static IEnumerable<IP_ADAPTER_ADDRESSES> ListFromPtr(IntPtr ptr) => ptr.LinkedListToIEnum<IP_ADAPTER_ADDRESSES>(t => t.Next);
		}
	}
}