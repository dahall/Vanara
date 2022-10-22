using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>Flags for an IP address.</summary>
		[PInvokeData("IpTypes.h")]
		[Flags]
		public enum IP_ADAPTER_CAST_FLAGS
		{
			/// <summary>The IP address is legal to appear in DNS.</summary>
			IP_ADAPTER_ADDRESS_DNS_ELIGIBLE = 0x01,

			/// <summary>The IP address is a cluster address and should not be used by most applications.</summary>
			IP_ADAPTER_ADDRESS_TRANSIENT = 0x02
		}

		/// <summary>Flags for <see cref="IP_ADAPTER_ADDRESSES"/>.</summary>
		[PInvokeData("IPTypes.h")]
		[Flags]
		public enum IP_ADAPTER_FLAGS : uint
		{
			/// <summary>Dynamic DNS is enabled on this adapter.</summary>
			IP_ADAPTER_DDNS_ENABLED = 0x00000001,

			/// <summary>Register the DNS suffix for this adapter.</summary>
			IP_ADAPTER_REGISTER_ADAPTER_SUFFIX = 0x00000002,

			/// <summary>Dynamic Host Configuration Protocol is enabled on this adapter.</summary>
			IP_ADAPTER_DHCP_ENABLED = 0x00000004,

			/// <summary>The adapter is a receive-only adapter.</summary>
			IP_ADAPTER_RECEIVE_ONLY = 0x00000008,

			/// <summary>The adapter is not a multicast recipient.</summary>
			IP_ADAPTER_NO_MULTICAST = 0x00000010,

			/// <summary>The adapter contains other IPv6-specific stateful configuration information.</summary>
			IP_ADAPTER_IPV6_OTHER_STATEFUL_CONFIG = 0x00000020,

			/// <summary>
			/// The adapter is enabled for NetBIOS over TCP/IP. <note type="note">This flag is only supported on Windows Vista and later when
			/// the application has been compiled for a target platform with an NTDDI version equal or greater than NTDDI_LONGHORN. This flag
			/// is defined in the IP_ADAPTER_ADDRESSES_LH structure as the NetbiosOverTcpipEnabled bitfield.</note>
			/// </summary>
			IP_ADAPTER_NETBIOS_OVER_TCPIP_ENABLED = 0x00000040,

			/// <summary>
			/// The adapter is enabled for IPv4. <note type="note">This flag is only supported on Windows Vista and later when the
			/// application has been compiled for a target platform with an NTDDI version equal or greater than NTDDI_LONGHORN. This flag is
			/// defined in the IP_ADAPTER_ADDRESSES_LH structure as the Ipv4Enabled bitfield.</note>
			/// </summary>
			IP_ADAPTER_IPV4_ENABLED = 0x00000080,

			/// <summary>
			/// The adapter is enabled for IPv6. <note type="note">This flag is only supported on Windows Vista and later when the
			/// application has been compiled for a target platform with an NTDDI version equal or greater than NTDDI_LONGHORN. This flag is
			/// defined in the IP_ADAPTER_ADDRESSES_LH structure as the Ipv6Enabled bitfield.</note>
			/// </summary>
			IP_ADAPTER_IPV6_ENABLED = 0x00000100,

			/// <summary>
			/// The adapter is enabled for IPv6 managed address configuration. <note type="note">This flag is only supported on Windows Vista
			/// and later when the application has been compiled for a target platform with an NTDDI version equal or greater than
			/// NTDDI_LONGHORN. This flag is defined in the IP_ADAPTER_ADDRESSES_LH structure as the Ipv6ManagedAddressConfigurationSupported bitfield.</note>
			/// </summary>
			IP_ADAPTER_IPV6_MANAGE_ADDRESS_CONFIG = 0x00000200,
		}

		/// <summary>Identifies a class or structure that supports a linked-list model.</summary>
		/// <typeparam name="T">The type of the element in the list.</typeparam>
		public interface ILinkedListElement<T> where T : struct
		{
			/// <summary>Gets the next element in the list.</summary>
			/// <returns>A nullable type. A <see langword="null"/> value indicates the end of the list.</returns>
			T? GetNext();
		}

		private static IEnumerable<T> GetLinkedList<T>(this T start, Func<T, bool> includeFirst) where T : struct, ILinkedListElement<T>
		{
			if (includeFirst(start))
				yield return start;
			for (var cur = ((ILinkedListElement<T>)start).GetNext(); cur != null; cur = ((ILinkedListElement<T>)cur).GetNext())
				yield return cur.Value;
		}

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
					if (DnsServerList.IpAddress.String != null)
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
		public struct IP_ADAPTER_ADDRESSES : ILinkedListElement<IP_ADAPTER_ADDRESSES>
		{
			/// <summary/>
			public uint Length;

			/// <summary/>
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

			/// <summary/>
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
			public uint Ipv6IfIndex;

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

			/// <summary>A sequence of IP_ADAPTER_UNICAST_ADDRESS structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_UNICAST_ADDRESS> UnicastAddresses => FirstUnicastAddress.LinkedListToIEnum<IP_ADAPTER_UNICAST_ADDRESS>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_ANYCAST_ADDRESS structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_ANYCAST_ADDRESS> AnycastAddresses => FirstAnycastAddress.LinkedListToIEnum<IP_ADAPTER_ANYCAST_ADDRESS>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_MULTICAST_ADDRESS structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_MULTICAST_ADDRESS> MulticastAddresses => FirstMulticastAddress.LinkedListToIEnum<IP_ADAPTER_MULTICAST_ADDRESS>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_DNS_SERVER_ADDRESS structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_DNS_SERVER_ADDRESS> DnsServerAddresses => FirstDnsServerAddress.LinkedListToIEnum<IP_ADAPTER_DNS_SERVER_ADDRESS>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_PREFIX structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_PREFIX> Prefixes => FirstPrefix.LinkedListToIEnum<IP_ADAPTER_PREFIX>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_WINS_SERVER_ADDRESS structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_WINS_SERVER_ADDRESS> WinsServerAddresses => FirstWinsServerAddress.LinkedListToIEnum<IP_ADAPTER_WINS_SERVER_ADDRESS>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_GATEWAY_ADDRESS structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_GATEWAY_ADDRESS> GatewayAddresses => FirstGatewayAddress.LinkedListToIEnum<IP_ADAPTER_GATEWAY_ADDRESS>(t => t.Next);

			/// <summary>A sequence of IP_ADAPTER_DNS_SUFFIX structures for the adapter.</summary>
			public IEnumerable<IP_ADAPTER_DNS_SUFFIX> DnsSuffixes => FirstDnsSuffix.LinkedListToIEnum<IP_ADAPTER_DNS_SUFFIX>(t => t.Next);

			/// <summary>Gets the next element in the linked list.</summary>
			/// <returns>A nullable type. A <see langword="null"/> value indicates the end of the list.</returns>
			public IP_ADAPTER_ADDRESSES? GetNext() => Next.ToNullableStructure<IP_ADAPTER_ADDRESSES>();
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_ANYCAST_ADDRESS</c> structure stores a single anycast IP address in a linked list of addresses for a particular adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstAnycastAddress</c> member of
		/// the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_ANYCAST_ADDRESS</c> structures.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_ANYCAST_ADDRESS</c> structure. On the Microsoft Windows Software
		/// Development Kit (SDK) released for Windows Vista and later, the organization of header files has changed and the
		/// <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header
		/// file. On the Platform Software Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c>
		/// structure is declared in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_ANYCAST_ADDRESS</c> structure, the
		/// Winsock2.h header file must be included before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_anycast_address_xp typedef struct
		// _IP_ADAPTER_ANYCAST_ADDRESS_XP { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Flags; }; }; struct
		// _IP_ADAPTER_ANYCAST_ADDRESS_XP *Next; SOCKET_ADDRESS Address; } IP_ADAPTER_ANYCAST_ADDRESS_XP, *PIP_ADAPTER_ANYCAST_ADDRESS_XP;
		[PInvokeData("iptypes.h", MSDNShortId = "2626fc86-e29b-4162-8625-207c709d67ed")]
		[StructLayout(LayoutKind.Sequential, Pack = 8,
#if x64
		Size = 32)]
#else
		Size = 24)]
#endif
		public struct IP_ADAPTER_ANYCAST_ADDRESS : ILinkedListElement<IP_ADAPTER_ANYCAST_ADDRESS>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>Specifies flags for this address.</summary>
			public IP_ADAPTER_CAST_FLAGS Flags;

			/// <summary>
			/// <para>Type: <c>struct _IP_ADAPTER_ANYCAST_ADDRESS*</c></para>
			/// <para>A pointer to the next anycast IP address structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>The IP address for this anycast IP address entry. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_ANYCAST_ADDRESS</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_ANYCAST_ADDRESS? GetNext() => Next.ToNullableStructure<IP_ADAPTER_ANYCAST_ADDRESS>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_DNS_SERVER_ADDRESS</c> structure stores a single DNS server address in a linked list of DNS server addresses
		/// for a particular adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstDnsServerAddress</c> member of
		/// the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_DNS_SERVER_ADDRESS</c> structures.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_DNS_SERVER_ADDRESS</c> structure. On the Microsoft Windows Software
		/// Development Kit (SDK) released for Windows Vista and later, the organization of header files has changed and the
		/// <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header
		/// file. On the Platform Software Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c>
		/// structure is declared in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_DNS_SERVER_ADDRESS</c> structure, the
		/// Winsock2.h header file must be included before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_dns_server_address_xp typedef struct
		// _IP_ADAPTER_DNS_SERVER_ADDRESS_XP { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Reserved; }; }; struct
		// _IP_ADAPTER_DNS_SERVER_ADDRESS_XP *Next; SOCKET_ADDRESS Address; } IP_ADAPTER_DNS_SERVER_ADDRESS_XP, *PIP_ADAPTER_DNS_SERVER_ADDRESS_XP;
		[PInvokeData("iptypes.h", MSDNShortId = "96855386-9010-40df-8260-16b43ad6646f")]
		[StructLayout(LayoutKind.Sequential, Pack = 8,
#if x64
		Size = 32)]
#else
		Size = 24)]
#endif
		public struct IP_ADAPTER_DNS_SERVER_ADDRESS : ILinkedListElement<IP_ADAPTER_DNS_SERVER_ADDRESS>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>Reserved.</summary>
			public uint Reserved;

			/// <summary>
			/// <para>A pointer to the next DNS server address structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>The IP address for this DNS server entry. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_DNS_SERVER_ADDRESS</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_DNS_SERVER_ADDRESS? GetNext() => Next.ToNullableStructure<IP_ADAPTER_DNS_SERVER_ADDRESS>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// <para>The <c>IP_ADAPTER_DNS_SUFFIX</c> structure stores a DNS suffix in a linked list of DNS suffixes for a particular adapter.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstDnsSuffix</c> member of the
		/// <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_DNS_SUFFIX</c> structures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_dns_suffix typedef struct
		// _IP_ADAPTER_DNS_SUFFIX { struct _IP_ADAPTER_DNS_SUFFIX *Next; WCHAR String[MAX_DNS_SUFFIX_STRING_LENGTH]; } IP_ADAPTER_DNS_SUFFIX, *PIP_ADAPTER_DNS_SUFFIX;
		[PInvokeData("iptypes.h", MSDNShortId = "3730a406-2995-48f7-b70e-1cf8258ee4a6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_DNS_SUFFIX : ILinkedListElement<IP_ADAPTER_DNS_SUFFIX>
		{
			/// <summary>
			/// <para>A pointer to the next DNS suffix in the linked list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>The DNS suffix for this DNS suffix entry.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DNS_SUFFIX_STRING_LENGTH)]
			public string String;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_DNS_SUFFIX</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_DNS_SUFFIX? GetNext() => Next.ToNullableStructure<IP_ADAPTER_DNS_SUFFIX>();

			/// <inheritdoc/>
			public override string ToString() => String;
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_GATEWAY_ADDRESS</c> structure stores a single gateway address in a linked list of gateway addresses for a
		/// particular adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstGatewayAddress</c> member of
		/// the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_GATEWAY_ADDRESS</c> structures.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_GATEWAY_ADDRESS</c> structure. On the Microsoft Windows Software
		/// Development Kit (SDK) released for Windows Vista and later, the organization of header files has changed and the
		/// <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header
		/// file. On the Platform Software Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c>
		/// structure is declared in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_GATEWAY_ADDRESS</c> structure, the
		/// Winsock2.h header file must be included before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_gateway_address_lh typedef struct
		// _IP_ADAPTER_GATEWAY_ADDRESS_LH { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Reserved; }; }; struct
		// _IP_ADAPTER_GATEWAY_ADDRESS_LH *Next; SOCKET_ADDRESS Address; } IP_ADAPTER_GATEWAY_ADDRESS_LH, *PIP_ADAPTER_GATEWAY_ADDRESS_LH;
		[PInvokeData("iptypes.h", MSDNShortId = "CA38504A-1CC9-4ABA-BD4E-1B2EAD6F588B")]
		[StructLayout(LayoutKind.Sequential, Pack = 8,
#if x64
		Size = 32)]
#else
		Size = 24)]
#endif
		public struct IP_ADAPTER_GATEWAY_ADDRESS : ILinkedListElement<IP_ADAPTER_GATEWAY_ADDRESS>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>Reserved.</summary>
			public uint Reserved;

			/// <summary>
			/// <para>A pointer to the next gateway address structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>The IP address for this gateway entry. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_GATEWAY_ADDRESS</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_GATEWAY_ADDRESS? GetNext() => Next.ToNullableStructure<IP_ADAPTER_GATEWAY_ADDRESS>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// <para>The <c>IP_ADAPTER_INFO</c> structure contains information about a particular network adapter on the local computer.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IP_ADAPTER_INFO</c> structure is limited to IPv4 information about a particular network adapter on the local computer. The
		/// <c>IP_ADAPTER_INFO</c> structure is retrieved by calling the GetAdaptersInfofunction.
		/// </para>
		/// <para>
		/// When using Visual Studio 2005 and later, the <c>time_t</c> datatype defaults to an 8-byte datatype, not the 4-byte datatype used
		/// for the <c>LeaseObtained</c> and <c>LeaseExpires</c> members on a 32-bit platform. To properly use the <c>IP_ADAPTER_INFO</c>
		/// structure on a 32-bit platform, define <c>_USE_32BIT_TIME_T</c> (use as an option, for example) when compiling the application to
		/// force the <c>time_t</c> datatype to a 4-byte datatype.
		/// </para>
		/// <para>
		/// For use on Windows XP and later, the IP_ADAPTER_ADDRESSES structure contains both IPv4 and IPv6 information. The
		/// GetAdaptersAddresses function retrieves IPv4 and IPv6 adapter information.
		/// </para>
		/// <para>Examples</para>
		/// <para>This example retrieves the adapter information and prints various properties of each adapter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_info typedef struct _IP_ADAPTER_INFO { struct
		// _IP_ADAPTER_INFO *Next; DWORD ComboIndex; char AdapterName[MAX_ADAPTER_NAME_LENGTH + 4]; char
		// Description[MAX_ADAPTER_DESCRIPTION_LENGTH + 4]; UINT AddressLength; BYTE Address[MAX_ADAPTER_ADDRESS_LENGTH]; DWORD Index; UINT
		// Type; UINT DhcpEnabled; PIP_ADDR_STRING CurrentIpAddress; IP_ADDR_STRING IpAddressList; IP_ADDR_STRING GatewayList; IP_ADDR_STRING
		// DhcpServer; BOOL HaveWins; IP_ADDR_STRING PrimaryWinsServer; IP_ADDR_STRING SecondaryWinsServer; time_t LeaseObtained; time_t
		// LeaseExpires; } IP_ADAPTER_INFO, *PIP_ADAPTER_INFO;
		[PInvokeData("iptypes.h", MSDNShortId = "f8035801-ca0c-4d86-bfc5-8e2d746af1b4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_ADAPTER_INFO : ILinkedListElement<IP_ADAPTER_INFO>
		{
			/// <summary>
			/// <para>Type: <c>struct _IP_ADAPTER_INFO*</c></para>
			/// <para>A pointer to the next adapter in the list of adapters.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public uint ComboIndex;

			/// <summary>
			/// <para>Type: <c>char[MAX_ADAPTER_NAME_LENGTH + 4]</c></para>
			/// <para>An ANSI character string of the name of the adapter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_NAME_LENGTH + 4)]
			public string AdapterName;

			/// <summary>
			/// <para>Type: <c>char[MAX_ADAPTER_DESCRIPTION_LENGTH + 4]</c></para>
			/// <para>An ANSI character string that contains the description of the adapter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_DESCRIPTION_LENGTH + 4)]
			public string AdapterDescription;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The length, in bytes, of the hardware address for the adapter.</para>
			/// </summary>
			public uint AddressLength;

			/// <summary>
			/// <para>Type: <c>BYTE[MAX_ADAPTER_ADDRESS_LENGTH]</c></para>
			/// <para>The hardware address for the adapter represented as a <c>BYTE</c> array.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ADAPTER_ADDRESS_LENGTH)]
			public byte[] Address;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The adapter index.</para>
			/// <para>
			/// The adapter index may change when an adapter is disabled and then enabled, or under other circumstances, and should not be
			/// considered persistent.
			/// </para>
			/// </summary>
			public uint Index;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>The adapter type. Possible values for the adapter type are listed in the Ipifcons.h header file.</para>
			/// <para>The table below lists common values for the adapter type although other values are possible on Windows Vista and later.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MIB_IF_TYPE_OTHER 1</term>
			/// <term>Some other type of network interface.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IF_TYPE_ETHERNET 6</term>
			/// <term>An Ethernet network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_ISO88025_TOKENRING 9</term>
			/// <term>MIB_IF_TYPE_TOKENRING</term>
			/// </item>
			/// <item>
			/// <term>MIB_IF_TYPE_PPP 23</term>
			/// <term>A PPP network interface.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IF_TYPE_LOOPBACK 24</term>
			/// <term>A software loopback network interface.</term>
			/// </item>
			/// <item>
			/// <term>MIB_IF_TYPE_SLIP 28</term>
			/// <term>An ATM network interface.</term>
			/// </item>
			/// <item>
			/// <term>IF_TYPE_IEEE80211 71</term>
			/// <term>An IEEE 802.11 wireless network interface.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IFTYPE Type;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>An option value that specifies whether the dynamic host configuration protocol (DHCP) is enabled for this adapter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool DhcpEnabled;

			/// <summary>
			/// <para>Type: <c>PIP_ADDR_STRING</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public IntPtr CurrentIpAddress;

			/// <summary>
			/// <para>Type: <c>IP_ADDR_STRING</c></para>
			/// <para>
			/// The list of IPv4 addresses associated with this adapter represented as a linked list of <c>IP_ADDR_STRING</c> structures. An
			/// adapter can have multiple IPv4 addresses assigned to it.
			/// </para>
			/// </summary>
			public IP_ADDR_STRING IpAddressList;

			/// <summary>
			/// <para>Type: <c>IP_ADDR_STRING</c></para>
			/// <para>
			/// The IPv4 address of the gateway for this adapter represented as a linked list of <c>IP_ADDR_STRING</c> structures. An adapter
			/// can have multiple IPv4 gateway addresses assigned to it. This list usually contains a single entry for IPv4 address of the
			/// default gateway for this adapter.
			/// </para>
			/// </summary>
			public IP_ADDR_STRING GatewayList;

			/// <summary>
			/// <para>Type: <c>IP_ADDR_STRING</c></para>
			/// <para>
			/// The IPv4 address of the DHCP server for this adapter represented as a linked list of <c>IP_ADDR_STRING</c> structures. This
			/// list contains a single entry for the IPv4 address of the DHCP server for this adapter. A value of 255.255.255.255 indicates
			/// the DHCP server could not be reached, or is in the process of being reached.
			/// </para>
			/// <para>This member is only valid when the <c>DhcpEnabled</c> member is nonzero.</para>
			/// </summary>
			public IP_ADDR_STRING DhcpServer;

			/// <summary>
			/// <para>Type: <c>BOOL</c></para>
			/// <para>An option value that specifies whether this adapter uses the Windows Internet Name Service (WINS).</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool HaveWins;

			/// <summary>
			/// <para>Type: <c>IP_ADDR_STRING</c></para>
			/// <para>
			/// The IPv4 address of the primary WINS server represented as a linked list of <c>IP_ADDR_STRING</c> structures. This list
			/// contains a single entry for the IPv4 address of the primary WINS server for this adapter.
			/// </para>
			/// <para>This member is only valid when the <c>HaveWins</c> member is <c>TRUE</c>.</para>
			/// </summary>
			public IP_ADDR_STRING PrimaryWinsServer;

			/// <summary>
			/// <para>Type: <c>IP_ADDR_STRING</c></para>
			/// <para>
			/// The IPv4 address of the secondary WINS server represented as a linked list of <c>IP_ADDR_STRING</c> structures. An adapter
			/// can have multiple secondary WINS server addresses assigned to it.
			/// </para>
			/// <para>This member is only valid when the <c>HaveWins</c> member is <c>TRUE</c>.</para>
			/// </summary>
			public IP_ADDR_STRING SecondaryWinsServer;

			/// <summary>
			/// <para>Type: <c>time_t</c></para>
			/// <para>The time when the current DHCP lease was obtained.</para>
			/// <para>This member is only valid when the <c>DhcpEnabled</c> member is nonzero.</para>
			/// </summary>
			public time_t LeaseObtained;

			/// <summary>
			/// <para>Type: <c>time_t</c></para>
			/// <para>The time when the current DHCP lease expires.</para>
			/// <para>This member is only valid when the <c>DhcpEnabled</c> member is nonzero.</para>
			/// </summary>
			public time_t LeaseExpires;

			/// <summary>Gets a sequence of IP_ADDR_STRING values representing IP addresses.</summary>
			public IEnumerable<IP_ADDR_STRING> IpAddresses => IpAddressList.GetLinkedList(s => s.IpAddress.String != null);

			/// <summary>Gets a sequence of IP_ADDR_STRING values representing gateways.</summary>
			public IEnumerable<IP_ADDR_STRING> Gateways => GatewayList.GetLinkedList(s => s.IpAddress.String != null);

			/// <summary>Gets a sequence of IP_ADDR_STRING values representing DHCP servers.</summary>
			public IEnumerable<IP_ADDR_STRING> DhcpServers => DhcpServer.GetLinkedList(s => s.IpAddress.String != null);

			/// <summary>Gets a sequence of IP_ADDR_STRING values representing primary WINS servers.</summary>
			public IEnumerable<IP_ADDR_STRING> PrimaryWinsServers => PrimaryWinsServer.GetLinkedList(s => s.IpAddress.String != null);

			/// <summary>Gets a sequence of IP_ADDR_STRING values representing secondary WINS servers.</summary>
			public IEnumerable<IP_ADDR_STRING> SecondaryWinsServers => SecondaryWinsServer.GetLinkedList(s => s.IpAddress.String != null);

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_INFO</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_INFO? GetNext() => Next.ToNullableStructure<IP_ADAPTER_INFO>();
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_MULTICAST_ADDRESS</c> structure stores a single multicast address in a linked-list of addresses for a
		/// particular adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstMulticastAddress</c> member of
		/// the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_MULTICAST_ADDRESS</c> structures.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_MULTICAST_ADDRESS</c> structure. On the Microsoft Windows Software
		/// Development Kit (SDK) released for Windows Vista and later, the organization of header files has changed and the
		/// <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header
		/// file. On the Platform Software Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c>
		/// structure is declared in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_MULTICAST_ADDRESS</c> structure, the
		/// Winsock2.h header file must be included before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_multicast_address_xp typedef struct
		// _IP_ADAPTER_MULTICAST_ADDRESS_XP { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Flags; }; }; struct
		// _IP_ADAPTER_MULTICAST_ADDRESS_XP *Next; SOCKET_ADDRESS Address; } IP_ADAPTER_MULTICAST_ADDRESS_XP, *PIP_ADAPTER_MULTICAST_ADDRESS_XP;
		[PInvokeData("iptypes.h", MSDNShortId = "b85a6e0a-df2c-4608-b07a-191b34440a43")]
		[StructLayout(LayoutKind.Sequential, Pack = 8,
#if x64
		Size = 32)]
#else
		Size = 24)]
#endif
		public struct IP_ADAPTER_MULTICAST_ADDRESS : ILinkedListElement<IP_ADAPTER_MULTICAST_ADDRESS>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>Specifies flags for this address.</summary>
			public IP_ADAPTER_CAST_FLAGS Flags;

			/// <summary>
			/// <para>Type: <c>struct _IP_ADAPTER_MULTICAST_ADDRESS*</c></para>
			/// <para>A pointer to the next multicast IP address structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>The IP address for this multicast IP address entry. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_MULTICAST_ADDRESS</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_MULTICAST_ADDRESS? GetNext() => Next.ToNullableStructure<IP_ADAPTER_MULTICAST_ADDRESS>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// <para>The <c>IP_ADAPTER_PREFIX</c> structure stores an IP address prefix.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. On Windows XP with Service Pack 1 (SP1) and
		/// later, the <c>FirstPrefix</c> member of the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of
		/// <c>IP_ADAPTER_PREFIX</c> structures.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_PREFIX</c> structure. On the Microsoft Windows Software Development Kit
		/// (SDK) released for Windows Vista and later, the organization of header files has changed and the <c>SOCKET_ADDRESS</c> structure
		/// is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header file. On the Platform Software
		/// Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c> structure is declared in the
		/// Winsock2.h header file. In order to use the <c>IP_ADAPTER_PREFIX</c> structure, the Winsock2.h header file must be included
		/// before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_prefix_xp typedef struct _IP_ADAPTER_PREFIX_XP
		// { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Flags; }; }; struct _IP_ADAPTER_PREFIX_XP *Next; SOCKET_ADDRESS
		// Address; ULONG PrefixLength; } IP_ADAPTER_PREFIX_XP, *PIP_ADAPTER_PREFIX_XP;
		[PInvokeData("iptypes.h", MSDNShortId = "680b412d-2352-421d-ae58-dcf34ee6cf31")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_PREFIX : ILinkedListElement<IP_ADAPTER_PREFIX>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>This member is reserved and should be set to zero.</summary>
			public uint Flags;

			/// <summary>
			/// <para>A pointer to the next adapter prefix structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>The address prefix, in the form of a SOCKET_ADDRESS structure.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>The length of the prefix, in bits.</para>
			/// </summary>
			public uint PrefixLength;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_PREFIX</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_PREFIX? GetNext() => Next.ToNullableStructure<IP_ADAPTER_PREFIX>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure stores a single unicast IP address in a linked list of IP addresses for a
		/// particular adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstUnicastAddress</c> member of
		/// the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_UNICAST_ADDRESS</c> structures.
		/// </para>
		/// <para>
		/// The size of the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure changed on Windows Vista and later. The <c>Length</c> member should
		/// be used to determine which version of the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure is being used.
		/// </para>
		/// <para>
		/// The version of the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure on Windows Vista and later has the following new member added: <c>OnLinkPrefixLength</c>.
		/// </para>
		/// <para>
		/// When this structure is used with the GetAdaptersAddresses function and similar management functions, all configured addresses are
		/// shown, including duplicate addresses. Such duplicate address entries can occur when addresses are configured statically. Such
		/// reporting facilitates administrator troubleshooting. The <c>DadState</c> member is effective in identifying and troubleshooting
		/// such situations.
		/// </para>
		/// <para>
		/// In the Windows SDK, the version of the structure for use on Windows Vista and later is defined as
		/// <c>IP_ADAPTER_UNICAST_ADDRESS_LH</c>. In the Windows SDK, the version of this structure to be used on earlier systems including
		/// Windows XP with Service Pack 1 (SP1) and later is defined as <c>IP_ADAPTER_UNICAST_ADDRESS_XP</c>. When compiling an application
		/// if the target platform is Windows Vista and later (, , or ), the <c>IP_ADAPTER_UNICAST_ADDRESS_LH</c> structure is typedefed to
		/// the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure. When compiling an application if the target platform is not Windows Vista and
		/// later, the <c>IP_ADAPTER_UNICAST_ADDRESS_XP</c> structure is typedefed to the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure. On the Microsoft Windows Software
		/// Development Kit (SDK) released for Windows Vista and later, the organization of header files has changed and the
		/// <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header
		/// file. On the Platform Software Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c>
		/// structure is declared in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure, the
		/// Winsock2.h header file must be included before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_unicast_address_lh typedef struct
		// _IP_ADAPTER_UNICAST_ADDRESS_LH { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Flags; }; }; struct
		// _IP_ADAPTER_UNICAST_ADDRESS_LH *Next; SOCKET_ADDRESS Address; IP_PREFIX_ORIGIN PrefixOrigin; IP_SUFFIX_ORIGIN SuffixOrigin;
		// IP_DAD_STATE DadState; ULONG ValidLifetime; ULONG PreferredLifetime; ULONG LeaseLifetime; UINT8 OnLinkPrefixLength; }
		// IP_ADAPTER_UNICAST_ADDRESS_LH, *PIP_ADAPTER_UNICAST_ADDRESS_LH;
		[PInvokeData("iptypes.h", MSDNShortId = "65c3648c-89bd-417b-8a9b-feefa6149c4a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_UNICAST_ADDRESS : ILinkedListElement<IP_ADAPTER_UNICAST_ADDRESS>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>This member is reserved and should be set to zero.</summary>
			public uint Flags;

			/// <summary>
			/// <para>Type: <c>struct _IP_ADAPTER_UNICAST_ADDRESS*</c></para>
			/// <para>A pointer to the next IP adapter address structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>The IP address for this unicast IP address entry. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>Type: <c>IP_PREFIX_ORIGIN</c></para>
			/// <para>
			/// The prefix or network part of IP the address. This member can be one of the values from the IP_PREFIX_ORIGIN enumeration type
			/// defined in the Iptypes.h header file.
			/// </para>
			/// </summary>
			public IP_PREFIX_ORIGIN PrefixOrigin;

			/// <summary>
			/// <para>Type: <c>IP_SUFFIX_ORIGIN</c></para>
			/// <para>
			/// The suffix or host part of the IP address. This member can be one of the values from the IP_SUFFIX_ORIGIN enumeration type
			/// defined in the Iptypes.h header file.
			/// </para>
			/// </summary>
			public IP_SUFFIX_ORIGIN SuffixOrigin;

			/// <summary>
			/// <para>Type: <c>IP_DAD_STATE</c></para>
			/// <para>
			/// The duplicate address detection (DAD) state. This member can be one of the values from the IP_DAD_STATE enumeration type
			/// defined in the Iptypes.h header file. Duplicate address detection is available for both IPv4 and IPv6 addresses.
			/// </para>
			/// </summary>
			public IP_DAD_STATE DadState;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The maximum lifetime, in seconds, that the IP address is valid. A value of 0xffffffff is considered to be infinite.</para>
			/// </summary>
			public uint ValidLifetime;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The preferred lifetime, in seconds, that the IP address is valid. A value of 0xffffffff is considered to be infinite.</para>
			/// </summary>
			public uint PreferredLifetime;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The lease lifetime, in seconds, that the IP address is valid.</para>
			/// </summary>
			public uint LeaseLifetime;

			/// <summary>
			/// <para>Type: <c>UINT8</c></para>
			/// <para>
			/// The length, in bits, of the prefix or network part of the IP address. For a unicast IPv4 address, any value greater than 32
			/// is an illegal value. For a unicast IPv6 address, any value greater than 128 is an illegal value. A value of 255 is commonly
			/// used to represent an illegal value.
			/// </para>
			/// <para><c>Note</c> This structure member is only available on Windows Vista and later.</para>
			/// </summary>
			public byte OnLinkPrefixLength;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_UNICAST_ADDRESS</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_UNICAST_ADDRESS? GetNext() => Next.ToNullableStructure<IP_ADAPTER_UNICAST_ADDRESS>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_WINS_SERVER_ADDRESS</c> structure stores a single Windows Internet Name Service (WINS) server address in a
		/// linked list of WINS server addresses for a particular adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The IP_ADAPTER_ADDRESSES structure is retrieved by the GetAdaptersAddresses function. The <c>FirstWinsServerAddress</c> member of
		/// the <c>IP_ADAPTER_ADDRESSES</c> structure is a pointer to a linked list of <c>IP_ADAPTER_WINS_SERVER_ADDRESS</c> structures.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the IP_ADAPTER_GATEWAY_ADDRESS structure. On the Microsoft Windows Software Development
		/// Kit (SDK) released for Windows Vista and later, the organization of header files has changed and the <c>SOCKET_ADDRESS</c>
		/// structure is defined in the Ws2def.h header file which is automatically included by the Winsock2.h header file. On the Platform
		/// Software Development Kit (SDK) released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c> structure is declared
		/// in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_GATEWAY_ADDRESS</c> structure, the Winsock2.h header file must
		/// be included before the Iphlpapi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_adapter_wins_server_address_lh typedef struct
		// _IP_ADAPTER_WINS_SERVER_ADDRESS_LH { union { ULONGLONG Alignment; struct { ULONG Length; DWORD Reserved; }; }; struct
		// _IP_ADAPTER_WINS_SERVER_ADDRESS_LH *Next; SOCKET_ADDRESS Address; } IP_ADAPTER_WINS_SERVER_ADDRESS_LH, *PIP_ADAPTER_WINS_SERVER_ADDRESS_LH;
		[PInvokeData("iptypes.h", MSDNShortId = "AF9A40C4-63DB-4830-A689-1DFE4DC2CAB7")]
		[StructLayout(LayoutKind.Sequential, Pack = 8,
#if x64
		Size = 32)]
#else
		Size = 24)]
#endif
		public struct IP_ADAPTER_WINS_SERVER_ADDRESS : ILinkedListElement<IP_ADAPTER_WINS_SERVER_ADDRESS>
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>This member is reserved and should be set to zero.</summary>
			public uint Reserved;

			/// <summary>
			/// <para>A pointer to the next WINS server address structure in the list.</para>
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// <para>The IP address for this WINS server entry. This member can be an IPv6 address or an IPv4 address.</para>
			/// </summary>
			public SOCKET_ADDRESS Address;

			/// <summary>
			/// <para>Gets a reference to the next <c>IP_ADAPTER_WINS_SERVER_ADDRESS</c> structure in the list.</para>
			/// </summary>
			public IP_ADAPTER_WINS_SERVER_ADDRESS? GetNext() => Next.ToNullableStructure<IP_ADAPTER_WINS_SERVER_ADDRESS>();

			/// <inheritdoc/>
			public override string ToString() => Address.ToString();
		}

		/// <summary>
		/// The <c>IP_ADDR_STRING</c> structure represents a node in a linked-list of IPv4 addresses.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.IpHlpApi.ILinkedListElement{T}" />
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_addr_string typedef struct _IP_ADDR_STRING { struct
		// _IP_ADDR_STRING *Next; IP_ADDRESS_STRING IpAddress; IP_MASK_STRING IpMask; DWORD Context; } IP_ADDR_STRING, *PIP_ADDR_STRING;
		[PInvokeData("iptypes.h", MSDNShortId = "783c383d-7fd3-45bc-90f6-2e8ce01db3c3")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_ADDR_STRING : ILinkedListElement<IP_ADDR_STRING>
		{
			/// <summary>
			/// A pointer to the next <c>IP_ADDR_STRING</c> structure in the list.
			/// </summary>
			public IntPtr Next;

			/// <summary>
			/// A value that specifies a structure type with a single member, <c>String</c>. The <c>String</c> member is a <c>char</c> array
			/// of size 16. This array holds an IPv4 address in dotted decimal notation.
			/// </summary>
			public IP_ADDRESS_STRING IpAddress;

			/// <summary>
			/// A value that specifies a structure type with a single member, <c>String</c>. The <c>String</c> member is a <c>char</c> array
			/// of size 16. This array holds the IPv4 subnet mask in dotted decimal notation.
			/// </summary>
			public IP_ADDRESS_STRING IpMask;

			/// <summary>
			/// A network table entry (NTE). This value corresponds to the NTEContext parameters in the <see cref="AddIPAddress"/> and <see
			/// cref="DeleteIPAddress"/> functions.
			/// </summary>
			public uint Context;

			/// <summary>
			/// Gets a reference to the next <c>IP_ADDR_STRING</c> structure in the list.
			/// </summary>
			/// <returns>
			/// A nullable type. A <see langword="null" /> value indicates the end of the list.
			/// </returns>
			public IP_ADDR_STRING? GetNext() => Next.ToNullableStructure<IP_ADDR_STRING>();
		}

		/// <summary>
		/// The <c>IP_ADDRESS_STRING</c> structure stores an IPv4 address in dotted decimal notation. The <c>IP_ADDRESS_STRING</c> structure
		/// definition is also the type definition for the <c>IP_MASK_STRING</c> structure.
		/// </summary>
		/// <remarks>The <c>IP_ADDRESS_STRING</c> structure is used as a parameter in the IP_ADDR_STRING structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-ip_address_string typedef struct { char *String[4 4]; }
		// IP_ADDRESS_STRING, *PIP_ADDRESS_STRING, IP_MASK_STRING, *PIP_MASK_STRING;
		[PInvokeData("iptypes.h", MSDNShortId = "f426b22f-66e4-43e4-8852-357359df6f88")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_ADDRESS_STRING
		{
			/// <summary>A character string that represents an IPv4 address or an IPv4 subnet mask in dotted decimal notation.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string String;

			/// <inheritdoc/>
			public override string ToString() => String ?? "";
		}

		/// <summary>The <c>IP_INTERFACE_NAME_INFO</c> structure contains information about an IPv4 interface on the local computer.</summary>
		/// <remarks>
		/// <para>
		/// In the Microsoft Windows Software Development Kit (SDK), the version of the structure for use on Windows 2000 with Service Pack 1
		/// (SP1) and later is defined as <c>IP_INTERFACE_NAME_INFO_W2KSP1</c>. When compiling an application if the target platform is
		/// Windows 2000 with SP1 and later (, , or ), the <c>IP_INTERFACE_NAME_INFO_W2KSP1</c> structure is typedefed to the
		/// <c>IP_INTERFACE_NAME_INFO</c> structure.
		/// </para>
		/// <para>
		/// The <c>MediaType</c>, <c>ConnectionType</c>, and <c>AccessType</c> members, definitions and assigned values are available from
		/// the Ipifcons.h header file.
		/// </para>
		/// <para>
		/// The optional <c>InterfaceGuid</c> member is often set for dial-up interfaces, and can be used to distinguish multiple dial-up
		/// interfaces that share the same device GUID.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-ip_interface_name_info_w2ksp1 typedef struct
		// ip_interface_name_info_w2ksp1 { ULONG Index; ULONG MediaType; UCHAR ConnectionType; UCHAR AccessType; GUID DeviceGuid; GUID
		// InterfaceGuid; } IP_INTERFACE_NAME_INFO_W2KSP1, *PIP_INTERFACE_NAME_INFO_W2KSP1;
		[PInvokeData("iptypes.h", MSDNShortId = "c113e97d-6f41-490a-a872-20d662fd763b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_INTERFACE_NAME_INFO
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The index of the IP interface for the active instance.</para>
			/// </summary>
			public uint Index;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The interface type as defined by the Internet Assigned Names Authority (IANA). Possible values for the interface type are
			/// listed in the Ipifcons.h header file.
			/// </para>
			/// <para>The table below lists common values for the interface type; although, many other values are possible.</para>
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
			/// IF_TYPE_IEEE80211. Windows Server 2003, Windows 2000 Server with SP1 and Windows XP/2000: Wireless network cards are reported
			/// as IF_TYPE_ETHERNET_CSMACD.
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
			public IFTYPE MediaType;

			private byte _ConnectionType;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>The interface connection type for the adapter.</para>
			/// <para>The possible values for this member are defined in the Ipifcons.h header file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IF_CONNECTION_DEDICATED 1</term>
			/// <term>
			/// The connection type is dedicated. The connection comes up automatically when media sense is TRUE. For example, an Ethernet
			/// connection is dedicated.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IF_CONNECTION_PASSIVE 2</term>
			/// <term>
			/// The connection type is passive. The remote end must bring up the connection to the local station. For example, a RAS
			/// interface is passive.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IF_CONNECTION_DEMAND 3</term>
			/// <term>
			/// The connection type is demand-dial. A connection of this type comes up in response to a local action (sending a packet, for example).
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public NET_IF_CONNECTION_TYPE ConnectionType { get => (NET_IF_CONNECTION_TYPE)_ConnectionType; set => _ConnectionType = (byte)value; }

			private byte _AccessType;

			/// <summary>
			/// <para>Type: <c>UCHAR</c></para>
			/// <para>A value of the IF_ACCESS_TYPE enumeration that specifies the access type for the interface.</para>
			/// <para>
			/// <c>Windows Server 2003, Windows 2000 Server with SP1 and Windows XP/2000:</c> The possible values for this member are defined
			/// in the Ipifcons.h header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IF_ACCESS_LOOPBACK 1</term>
			/// <term>The loopback access type. This value indicates that the interface loops back transmit data as receive data.</term>
			/// </item>
			/// <item>
			/// <term>IF_ACCESS_BROADCAST 2</term>
			/// <term>
			/// The LAN access type which includes Ethernet. This value indicates that the interface provides native support for multicast or
			/// broadcast services.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IF_ACCESS_POINT_TO_POINT 3</term>
			/// <term>
			/// The point to point access type. This value indicates support for CoNDIS/WAN, except for non-broadcast multi-access (NBMA)
			/// interfaces. Windows Server 2003, Windows 2000 Server with SP1 and Windows XP/2000: This value was defined as
			/// IF_ACCESS_POINTTOPOINT in the Ipifcons.h header file.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IF_ACCESS_POINT_TO_MULTI_POINT 4</term>
			/// <term>
			/// The point to multipoint access type. This value indicates support for non-broadcast multi-access media, including the RAS
			/// internal interface and native ATM. Windows Server 2003, Windows 2000 Server with SP1 and Windows XP/2000: This value was
			/// defined as IF_ACCESS_POINTTOMULTIPOINT in the Ipifcons.h header file.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public NET_IF_ACCESS_TYPE AccessType { get => (NET_IF_ACCESS_TYPE)_AccessType; set => _AccessType = (byte)value; }

			/// <summary>
			/// <para>Type: <c>GUID</c></para>
			/// <para>The GUID that identifies the underlying device for the interface. This member can be a zero GUID.</para>
			/// </summary>
			public Guid DeviceGuid;

			/// <summary>
			/// <para>Type: <c>GUID</c></para>
			/// <para>The GUID that identifies the interface mapped to the device. Optional. This member can be a zero GUID.</para>
			/// </summary>
			public Guid InterfaceGuid;
		}

		/// <summary>
		/// <para>The <c>IP_PER_ADAPTER_INFO</c> structure contains information specific to a particular adapter.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// APIPA enables automatic IP address configuration on networks without DHCP servers, using the IANA-reserved Class B network
		/// 169.254.0.0, with a subnet mask of 255.255.0.0. Clients send ARP messages to ensure the selected address is not currently in use.
		/// Clients auto-configured in this fashion continue to poll for a valid DHCP server every five minutes, and if found, the DHCP
		/// server configuration overrides all auto-configuration settings.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_per_adapter_info_w2ksp1 typedef struct
		// _IP_PER_ADAPTER_INFO_W2KSP1 { UINT AutoconfigEnabled; UINT AutoconfigActive; PIP_ADDR_STRING CurrentDnsServer; IP_ADDR_STRING
		// DnsServerList; } IP_PER_ADAPTER_INFO_W2KSP1, *PIP_PER_ADAPTER_INFO_W2KSP1;
		[PInvokeData("iptypes.h", MSDNShortId = "10cfdded-4184-4d34-9ccd-85446c13d497")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_PER_ADAPTER_INFO
		{
			/// <summary>
			/// <para>Specifies whether IP address auto-configuration (APIPA) is enabled on this adapter. See Remarks.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool AutoconfigEnabled;

			/// <summary>
			/// <para>Specifies whether this adapter's IP address is currently auto-configured by APIPA.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool AutoconfigActive;

			/// <summary>
			/// <para>Reserved. Use the <c>DnsServerList</c> member to obtain the DNS servers for the local computer.</para>
			/// </summary>
			public IntPtr CurrentDnsServer; /* IpAddressList* */

			/// <summary>
			/// <para>A linked list of IP_ADDR_STRING structures that specify the set of DNS servers used by the local computer.</para>
			/// </summary>
			public IP_ADDR_STRING DnsServerList;

			/// <summary>
			/// <para>
			/// A list of IP_ADDR_STRING structures pulled from <see cref="DnsServerList"/> that specify the set of DNS servers used by the
			/// local computer.
			/// </para>
			/// </summary>
			public IEnumerable<IP_ADDR_STRING> DnsServers => DnsServerList.GetLinkedList(s => s.IpAddress.String != null);
		}

		/// <summary>
		/// <para>The <c>IP_PER_ADAPTER_INFO</c> structure contains information specific to a particular adapter.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// APIPA enables automatic IP address configuration on networks without DHCP servers, using the IANA-reserved Class B network
		/// 169.254.0.0, with a subnet mask of 255.255.0.0. Clients send ARP messages to ensure the selected address is not currently in use.
		/// Clients auto-configured in this fashion continue to poll for a valid DHCP server every five minutes, and if found, the DHCP
		/// server configuration overrides all auto-configuration settings.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-_ip_per_adapter_info_w2ksp1 typedef struct
		// _IP_PER_ADAPTER_INFO_W2KSP1 { UINT AutoconfigEnabled; UINT AutoconfigActive; PIP_ADDR_STRING CurrentDnsServer; IP_ADDR_STRING
		// DnsServerList; } IP_PER_ADAPTER_INFO_W2KSP1, *PIP_PER_ADAPTER_INFO_W2KSP1;
		[PInvokeData("iptypes.h", MSDNShortId = "10cfdded-4184-4d34-9ccd-85446c13d497")]
		public class PIP_PER_ADAPTER_INFO : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="PIP_PER_ADAPTER_INFO"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public PIP_PER_ADAPTER_INFO(uint byteSize) : base((int)byteSize)
			{
			}

			/// <summary>
			/// <para>Specifies whether this adapter's IP address is currently auto-configured by APIPA.</para>
			/// </summary>
			public bool AutoconfigActive => !IsInvalid && handle.ToStructure<IP_PER_ADAPTER_INFO>().AutoconfigActive;

			/// <summary>
			/// <para>Specifies whether IP address auto-configuration (APIPA) is enabled on this adapter. See Remarks.</para>
			/// </summary>
			public bool AutoconfigEnabled => !IsInvalid && handle.ToStructure<IP_PER_ADAPTER_INFO>().AutoconfigEnabled;

			/// <summary>
			/// <para>A linked list of IP_ADDR_STRING structures that specify the set of DNS servers used by the local computer.</para>
			/// </summary>
			public IEnumerable<IP_ADDR_STRING> DnsServerList => IsInvalid ? new IP_ADDR_STRING[0] : handle.ToStructure<IP_PER_ADAPTER_INFO>().DnsServers;

			/// <summary>Performs an implicit conversion from <see cref="PIP_PER_ADAPTER_INFO"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="info">The PIP_PER_ADAPTER_INFO instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(PIP_PER_ADAPTER_INFO info) => info.DangerousGetHandle();
		}
	}
}