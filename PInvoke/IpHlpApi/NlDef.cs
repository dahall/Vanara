using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>The NL_DAD_STATE enumeration type defines the duplicate address detection (DAD) state.</summary>
		// typedef enum { NldsInvalid, NldsTentative, NldsDuplicate, NldsDeprecated, NldsPreferred, IpDadStateInvalid = 0,
		// IpDadStateTentative, IpDadStateDuplicate, IpDadStateDeprecated, IpDadStatePreferred} NL_DAD_STATE; https://msdn.microsoft.com/en-us/library/windows/hardware/ff568758(v=vs.85).aspx
		[PInvokeData("Nldef.h", MSDNShortId = "ff568758")]
		public enum NL_DAD_STATE
		{
			/// <summary>The DAD state is invalid.</summary>
			IpDadStateInvalid,

			/// <summary>The DAD state is tentative.</summary>
			IpDadStateTentative,

			/// <summary>A duplicate IP address has been detected.</summary>
			IpDadStateDuplicate,

			/// <summary>The IP address has been deprecated.</summary>
			IpDadStateDeprecated,

			/// <summary>The IP address is the preferred address.</summary>
			IpDadStatePreferred,
		}

		/// <summary>
		/// <para>The NL_LINK_LOCAL_ADDRESS_BEHAVIOR enumeration type defines the link local address behavior.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-_nl_link_local_address_behavior typedef enum
		// _NL_LINK_LOCAL_ADDRESS_BEHAVIOR { LinkLocalAlwaysOff , LinkLocalDelayed , LinkLocalAlwaysOn , LinkLocalUnchanged } NL_LINK_LOCAL_ADDRESS_BEHAVIOR;
		[PInvokeData("nldef.h", MSDNShortId = "d3010b6a-445b-44eb-8ebb-101664f3f835")]
		public enum NL_LINK_LOCAL_ADDRESS_BEHAVIOR
		{
			/// <summary>A link local IP address should never be used.</summary>
			LinkLocalAlwaysOff = 0,

			/// <summary>
			/// A link local IP address should be used only if no other address is available. This setting is the default setting for an
			/// IPv4 interface.
			/// </summary>
			LinkLocalDelayed,

			/// <summary>A link local IP address should always be used. This setting is the default setting for an IPv6 interface.</summary>
			LinkLocalAlwaysOn,

			/// <summary>When the properties of an IP interface are being set, the value for link local address behavior should be unchanged.</summary>
			LinkLocalUnchanged = -1,
		}

		/// <summary>
		/// <para>
		/// The NL_NEIGHBOR_STATE enumeration type defines the state of a network layer neighbor IP address, as described in RFC 2461,
		/// section 7.3.2.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// For more information about RFC 2461, section 7.3.2, see the Neighbor Discovery for IP Version 6 (IPv6) memo from Network Working Group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-_nl_neighbor_state typedef enum _NL_NEIGHBOR_STATE {
		// NlnsUnreachable , NlnsIncomplete , NlnsProbe , NlnsDelay , NlnsStale , NlnsReachable , NlnsPermanent , NlnsMaximum }
		// NL_NEIGHBOR_STATE, *PNL_NEIGHBOR_STATE;
		[PInvokeData("nldef.h", MSDNShortId = "7751011b-c473-4697-b311-62e3a6d9b1ae")]
		public enum NL_NEIGHBOR_STATE
		{
			/// <summary>The IP address is unreachable.</summary>
			NlnsUnreachable,

			/// <summary>
			/// Address resolution is in progress and the link-layer address of the neighbor has not yet been determined. Specifically for
			/// IPv6, a Neighbor Solicitation message has been sent to the solicited-node multicast IP address of the target, but the
			/// corresponding neighbor advertisement has not yet been received.
			/// </summary>
			NlnsIncomplete,

			/// <summary>
			/// The neighbor is no longer known to be reachable, and probes are being sent to verify reachability. For IPv6, a reachability
			/// confirmation is actively being sought by regularly retransmitting unicast Neighbor Solicitation probes until a reachability
			/// confirmation is received.
			/// </summary>
			NlnsProbe,

			/// <summary>
			/// The neighbor is no longer known to be reachable, and traffic has recently been sent to the neighbor. However, instead of
			/// probing the neighbor immediately, sending probes is delayed for a short time to give upper layer protocols an opportunity to
			/// provide reachability confirmation. For IPv6, more time has elapsed than is specified in the ReachabilityTime.ReachableTime
			/// member of the MIB_IPNET_ROW2 structure since the last positive confirmation was received that the forward path was
			/// functioning properly and a packet was sent. If no reachability confirmation is received within a period of time (used to
			/// delay the first probe) of entering the NlnsDelay state, a IPv6 Neighbor Solicitation (NS) message is sent, and the State
			/// member of MIB_IPNET_ROW2 is changed to NlnsProbe.
			/// </summary>
			NlnsDelay,

			/// <summary>
			/// The neighbor is no longer known to be reachable, but until traffic is sent to the neighbor, no attempt should be made to
			/// verify its reachability. For IPv6, more time has elapsed than is specified in the ReachabilityTime.ReachableTime member of
			/// the MIB_IPNET_ROW2 structure since the last positive confirmation was received that the forward path was functioning
			/// properly. While the State member of MIB_IPNET_ROW2 is NlnsStale, no action occurs until a packet is sent. The NlnsStale
			/// state is entered upon receiving an unsolicited neighbor discovery message that updates the cached IP address. Receipt of
			/// such a message does not confirm reachability, and entering the NlnsStale state insures reachability is verified quickly if
			/// the entry is actually being used. However, reachability is not actually verified until the entry is actually used.
			/// </summary>
			NlnsStale,

			/// <summary>
			/// The neighbor is known to have been reachable recently (within tens of seconds ago). For IPv6, a positive confirmation was
			/// received within the time that is specified in the ReachabilityTime.ReachableTime member of the MIB_IPNET_ROW2 structure that
			/// the forward path to the neighbor was functioning properly. While the State member of MIB_IPNET_ROW2 is NlnsReachable, no
			/// special action occurs as packets are sent.
			/// </summary>
			NlnsReachable,

			/// <summary>The IP address is a permanent address.</summary>
			NlnsPermanent,

			/// <summary>A maximum value for testing purposes.</summary>
			NlnsMaximum,
		}

		/// <summary>Defines constants that specify hints about the usage charge for a network connection.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/nldef/ne-nldef-nl_network_connectivity_cost_hint typedef enum
		// _NL_NETWORK_CONNECTIVITY_COST_HINT { NetworkConnectivityCostHintUnknown, NetworkConnectivityCostHintUnrestricted,
		// NetworkConnectivityCostHintFixed, NetworkConnectivityCostHintVariable } NL_NETWORK_CONNECTIVITY_COST_HINT;
		[PInvokeData("nldef.h", MSDNShortId = "NE:nldef._NL_NETWORK_CONNECTIVITY_COST_HINT")]
		public enum NL_NETWORK_CONNECTIVITY_COST_HINT
		{
			/// <summary>Specifies a hint that cost information is not available.</summary>
			NetworkConnectivityCostHintUnknown,

			/// <summary>Specifies a hint that the connection is unlimited, and has unrestricted usage charges and capacity constraints.</summary>
			NetworkConnectivityCostHintUnrestricted,

			/// <summary>Specifies a hint that the use of the connection is unrestricted up to a specific limit.</summary>
			NetworkConnectivityCostHintFixed,

			/// <summary>Specifies a hint that the connection is charged on a per-byte basis.</summary>
			NetworkConnectivityCostHintVariable,
		}

		/// <summary>Defines constants that specify hints about a level of network connectivity.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/nldef/ne-nldef-nl_network_connectivity_level_hint typedef enum
		// _NL_NETWORK_CONNECTIVITY_LEVEL_HINT { NetworkConnectivityLevelHintUnknown, NetworkConnectivityLevelHintNone,
		// NetworkConnectivityLevelHintLocalAccess, NetworkConnectivityLevelHintInternetAccess,
		// NetworkConnectivityLevelHintConstrainedInternetAccess, NetworkConnectivityLevelHintHidden } NL_NETWORK_CONNECTIVITY_LEVEL_HINT;
		[PInvokeData("nldef.h", MSDNShortId = "NE:nldef._NL_NETWORK_CONNECTIVITY_LEVEL_HINT")]
		public enum NL_NETWORK_CONNECTIVITY_LEVEL_HINT
		{
			/// <summary>
			/// Specifies a hint for an unknown level of connectivity. There is a short window of time during Windows (or application
			/// container) boot when this value might be returned.
			/// </summary>
			NetworkConnectivityLevelHintUnknown,

			/// <summary>Specifies a hint for no connectivity.</summary>
			NetworkConnectivityLevelHintNone,

			/// <summary>Specifies a hint for local and internet access.</summary>
			NetworkConnectivityLevelHintLocalAccess,

			/// <summary>Specifies a hint for local network access only.</summary>
			NetworkConnectivityLevelHintInternetAccess,

			/// <summary>
			/// Specifies a hint for limited internet access.This value indicates captive portal connectivity, where local access to a web
			/// portal is provided, but access to the internet requires that specific credentials are provided via the portal. This level of
			/// connectivity is generally encountered when using connections hosted in public locations (for example, coffee shops and book
			/// stores).This doesn't guarantee detection of a captive portal. You should be aware that when Windows reports the connectivity
			/// level hint as NetworkConnectivityLevelHintLocalAccess, your application's network requests might be redirected, and thus
			/// receive a different response than expected. Other protocols might also be impacted; for example, HTTPS might be redirected,
			/// and fail authentication.
			/// </summary>
			NetworkConnectivityLevelHintConstrainedInternetAccess,

			/// <summary>
			/// Specifies a hint for a network interface that's hidden from normal connectivity (and is not, by default, accessible to
			/// applications). This could be because no packets are allowed at all over that network (for example, the adapter flags itself
			/// NCF_HIDDEN), or (by default) routes are ignored on that interface (for example, a cellular network is hidden when WiFi is connected).
			/// </summary>
			NetworkConnectivityLevelHintHidden,
		}

		/// <summary>The NL_PREFIX_ORIGIN enumeration type defines the origin of the prefix or network part of the IP address.</summary>
		// typedef enum { IpPrefixOriginOther = 0, IpPrefixOriginManual, IpPrefixOriginWellKnown, IpPrefixOriginDhcp,
		// IpPrefixOriginRouterAdvertisement, IpPrefixOriginUnchanged = 1 &lt;&lt; 4} NL_PREFIX_ORIGIN; https://msdn.microsoft.com/en-us/library/windows/hardware/ff568762(v=vs.85).aspx
		[PInvokeData("Nldef.h", MSDNShortId = "ff568762")]
		public enum NL_PREFIX_ORIGIN
		{
			/// <summary>
			/// The IP address prefix was configured by using a source other than those that are defined in this enumeration. This value
			/// applies to an IPv6 or IPv4 address.
			/// </summary>
			IpPrefixOriginOther = 0,

			/// <summary>The IP address prefix was configured manually. This value applies to an IPv6 or IPv4 address.</summary>
			IpPrefixOriginManual,

			/// <summary>
			/// The IP address prefix was configured by using a well-known address. This value applies to an IPv6 link-local address or an
			/// IPv6 loopback address.
			/// </summary>
			IpPrefixOriginWellKnown,

			/// <summary>
			/// The IP address prefix was configured by using DHCP. This value applies to an IPv4 address configured by using DHCP or an
			/// IPv6 address configured by using DHCPv6.
			/// </summary>
			IpPrefixOriginDhcp,

			/// <summary>
			/// The IP address prefix was configured by using router advertisement. This value applies to an anonymous IPv6 address that was
			/// generated after receiving a router advertisement.
			/// </summary>
			IpPrefixOriginRouterAdvertisement,

			/// <summary>
			/// The IP address prefix should be unchanged. This value is used when setting the properties for a unicast IP interface when
			/// the value for the IP prefix origin should be unchanged.
			/// </summary>
			IpPrefixOriginUnchanged = 1 << 4,
		}

		/// <summary>
		/// <para>The NL_ROUTE_ORIGIN enumeration type defines the origin of the IP route.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-_nl_route_origin typedef enum _NL_ROUTE_ORIGIN { NlroManual ,
		// NlroWellKnown , NlroDHCP , NlroRouterAdvertisement , Nlro6to4 } NL_ROUTE_ORIGIN, *PNL_ROUTE_ORIGIN;
		[PInvokeData("nldef.h", MSDNShortId = "15f45fe9-5a51-4b4b-ba34-cec2488cd1e0")]
		public enum NL_ROUTE_ORIGIN
		{
			/// <summary>The route is a result of manual configuration.</summary>
			NlroManual,

			/// <summary>The route is a well-known route.</summary>
			NlroWellKnown,

			/// <summary>The route is a result of DHCP configuration.</summary>
			NlroDHCP,

			/// <summary>The route is a result of router advertisement.</summary>
			NlroRouterAdvertisement,

			/// <summary>The route is a result of 6to4 tunneling.</summary>
			Nlro6to4,
		}

		/// <summary>
		/// <para>The NL_ROUTER_DISCOVERY_BEHAVIOR enumeration type defines the router discovery behavior, as described in RFC 2461.</para>
		/// </summary>
		/// <remarks>
		/// <para>For more information about RFC 2461, see the Neighbor Discovery for IP Version 6 (IPv6) memo by the Network Working Group.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-_nl_router_discovery_behavior typedef enum
		// _NL_ROUTER_DISCOVERY_BEHAVIOR { RouterDiscoveryDisabled , RouterDiscoveryEnabled , RouterDiscoveryDhcp , RouterDiscoveryUnchanged
		// } NL_ROUTER_DISCOVERY_BEHAVIOR;
		[PInvokeData("nldef.h", MSDNShortId = "d3a0d872-c90a-4eb5-9011-c5913b9912c6")]
		public enum NL_ROUTER_DISCOVERY_BEHAVIOR
		{
			/// <summary>Router discovery is disabled.</summary>
			RouterDiscoveryDisabled = 0,

			/// <summary>Router discovery is enabled. This setting is the default value for IPv6.</summary>
			RouterDiscoveryEnabled,

			/// <summary>Router discovery is configured based on DHCP. This setting is the default value for IPv4.</summary>
			RouterDiscoveryDhcp,

			/// <summary>When the properties of an IP interface are being set, the value for router discovery should be unchanged.</summary>
			RouterDiscoveryUnchanged = -1,
		}

		/// <summary>
		/// <para>
		/// The <c>IP_SUFFIX_ORIGIN</c> enumeration specifies the origin of an IPv4 or IPv6 address suffix, and is used with the
		/// IP_ADAPTER_UNICAST_ADDRESS structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_SUFFIX_ORIGIN</c> enumeration is used in the <c>SuffixOrigin</c> member of the IP_ADAPTER_UNICAST_ADDRESS structure.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>IP_SUFFIX_ORIGIN</c> enumeration is defined in the Nldef.h header file which is automatically included by
		/// the Iptypes.h header file. In order to use the <c>IP_SUFFIX_ORIGIN</c> enumeration, the Winsock2.h header file must be included
		/// before the Iptypes.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-nl_suffix_origin typedef enum NL_SUFFIX_ORIGIN { NlsoOther ,
		// NlsoManual , NlsoWellKnown , NlsoDhcp , NlsoLinkLayerAddress , NlsoRandom , IpSuffixOriginOther , IpSuffixOriginManual ,
		// IpSuffixOriginWellKnown , IpSuffixOriginDhcp , IpSuffixOriginLinkLayerAddress , IpSuffixOriginRandom , IpSuffixOriginUnchanged } ;
		[PInvokeData("nldef.h", MSDNShortId = "0ffeae3d-cfc4-472e-87f8-ae6d584fb869")]
		public enum NL_SUFFIX_ORIGIN
		{
			/// <summary>The IP address suffix was provided by a source other than those defined in this enumeration.</summary>
			IpSuffixOriginOther = 0,

			/// <summary>The IP address suffix was manually specified.</summary>
			IpSuffixOriginManual,

			/// <summary>The IP address suffix is from a well-known source.</summary>
			IpSuffixOriginWellKnown,

			/// <summary>The IP address suffix was provided by DHCP settings.</summary>
			IpSuffixOriginDhcp,

			/// <summary>The IP address suffix was obtained from the link-layer address.</summary>
			IpSuffixOriginLinkLayerAddress,

			/// <summary>The IP address suffix was obtained from a random source.</summary>
			IpSuffixOriginRandom,

			/// <summary>
			/// The IP address suffix should be unchanged. This value is used when setting the properties for a unicast IP interface when
			/// the value for the IP suffix origin should be left unchanged.
			/// </summary>
			IpSuffixOriginUnchanged = 1 << 4,
		}

		/// <summary>
		/// <para>
		/// The <c>NL_BANDWIDTH_INFORMATION</c> structure contains read-only information on the available bandwidth estimates and associated
		/// variance as determined by the TCP/IP stack.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>NL_BANDWIDTH_INFORMATION</c> structure is defined in the Nldef.h header file which is automatically included by the
		/// Iptypes.h header file which is automatically included in the Iphlpapi.h header file. The Nldef.h and Iptypes.h header files
		/// should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ns-nldef-_nl_bandwidth_information typedef struct
		// _NL_BANDWIDTH_INFORMATION { ULONG64 Bandwidth; ULONG64 Instability; BOOLEAN BandwidthPeaked; } NL_BANDWIDTH_INFORMATION, *PNL_BANDWIDTH_INFORMATION;
		[PInvokeData("nldef.h", MSDNShortId = "F5D7238A-EAE0-4D60-A0A4-D839F738EF48")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct NL_BANDWIDTH_INFORMATION
		{
			/// <summary>
			/// <para>The estimated maximum available bandwidth, in bits per second.</para>
			/// </summary>
			public ulong Bandwidth;

			/// <summary>
			/// <para>A measure of the variation based on recent bandwidth samples, in bits per second.</para>
			/// </summary>
			public ulong Instability;

			/// <summary>
			/// <para>
			/// A value that indicates if the bandwidth estimate in the <c>Bandwidth</c> member has peaked and reached its maximum value for
			/// the given network conditions.
			/// </para>
			/// <para>
			/// The TCP/IP stack uses a heuristic to set this variable. Until this variable is set, there is no guarantee that the true
			/// available maximum bandwidth is not higher than the estimated bandwidth in the <c>Bandwidth</c> member. However, it is safe
			/// to assume that maximum available bandwidth is not lower than the estimate reported in the <c>Bandwidth</c> member.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool BandwidthPeaked;
		}

		/// <summary>
		/// <para>
		/// The <c>NL_INTERFACE_OFFLOAD_ROD</c> structure specifies a set of flags that indicate the offload capabilities for an IP interface.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>NL_INTERFACE_OFFLOAD_ROD</c> structure is defined on Windows Vista and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ns-nldef-_nl_interface_offload_rod typedef struct
		// _NL_INTERFACE_OFFLOAD_ROD { BOOLEAN NlChecksumSupported : 1; BOOLEAN NlOptionsSupported : 1; BOOLEAN TlDatagramChecksumSupported
		// : 1; BOOLEAN TlStreamChecksumSupported : 1; BOOLEAN TlStreamOptionsSupported : 1; BOOLEAN FastPathCompatible : 1; BOOLEAN
		// TlLargeSendOffloadSupported : 1; BOOLEAN TlGiantSendOffloadSupported : 1; } NL_INTERFACE_OFFLOAD_ROD, *PNL_INTERFACE_OFFLOAD_ROD;
		[PInvokeData("nldef.h", MSDNShortId = "764c7f5a-00df-461d-99ee-07f9e1f77ec7")]
		[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
		public struct NL_INTERFACE_OFFLOAD_ROD
		{
			/// <summary>The flags.</summary>
			public SupportedFlags Flags;

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => Flags.ToString();

			/// <summary>The flags.</summary>
			public enum SupportedFlags : byte
			{
				/// <summary>
				/// <para>The network adapter for this network interface supports the offload of IP checksum calculations.</para>
				/// </summary>
				NlChecksumSupported = 1 << 0,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports the offload of IP checksum calculations for IPv4 packets with IP options.
				/// </para>
				/// </summary>
				NlOptionsSupported = 1 << 1,

				/// <summary>
				/// <para>The network adapter for this network interface supports the offload of UDP checksum calculations.</para>
				/// </summary>
				TlDatagramChecksumSupported = 1 << 2,

				/// <summary>
				/// <para>The network adapter for this network interface supports the offload of TCP checksum calculations.</para>
				/// </summary>
				TlStreamChecksumSupported = 1 << 3,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports the offload of TCP checksum calculations for IPv4 packets
				/// containing IP options.
				/// </para>
				/// </summary>
				TlStreamOptionsSupported = 1 << 4,

				/// <summary/>
				FastPathCompatible = 1 << 5,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports TCP Large Send Offload Version 1. With this capability, TCP can
				/// pass a buffer to be transmitted that is bigger than the maximum transmission unit (MTU) supported by the medium. Version
				/// 1 allows TCP to pass a buffer up to 64K to be transmitted.
				/// </para>
				/// </summary>
				TlLargeSendOffloadSupported = 1 << 6,

				/// <summary>
				/// <para>
				/// The network adapter for this network interface supports TCP Large Send Offload Version 2. With this capability, TCP can
				/// pass a buffer to be transmitted that is bigger than the maximum transmission unit (MTU) supported by the medium. Version
				/// 2 allows TCP to pass a buffer up to 256K to be transmitted.
				/// </para>
				/// </summary>
				TlGiantSendOffloadSupported = 1 << 7,
			}
		}

		/// <summary>
		/// <para>
		/// Describes a level of network connectivity, the usage charge for a network connection, and other members reflecting cost factors.
		/// </para>
		/// <para>
		/// The last four members of <c>NL_NETWORK_CONNECTIVITY_HINT</c> collectively work together to allow you to resolve the cost of
		/// using a connection. See the guidelines in How to manage metered network cost constraints.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/nldef/ns-nldef-nl_network_connectivity_hint typedef struct
		// _NL_NETWORK_CONNECTIVITY_HINT { NL_NETWORK_CONNECTIVITY_LEVEL_HINT ConnectivityLevel; NL_NETWORK_CONNECTIVITY_COST_HINT
		// ConnectivityCost; BOOLEAN ApproachingDataLimit; BOOLEAN OverDataLimit; BOOLEAN Roaming; } NL_NETWORK_CONNECTIVITY_HINT;
		[PInvokeData("nldef.h", MSDNShortId = "NS:nldef._NL_NETWORK_CONNECTIVITY_HINT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NL_NETWORK_CONNECTIVITY_HINT
		{
			/// <summary>
			/// <para>Type: <c>NL_NETWORK_CONNECTIVITY_LEVEL_HINT</c></para>
			/// <para>The level of network connectivity.</para>
			/// </summary>
			public NL_NETWORK_CONNECTIVITY_LEVEL_HINT ConnectivityLevel;

			/// <summary>
			/// <para>Type: <c>NL_NETWORK_CONNECTIVITY_COST_HINT</c></para>
			/// <para>The usage charge for the network connection.</para>
			/// </summary>
			public NL_NETWORK_CONNECTIVITY_COST_HINT ConnectivityCost;

			/// <summary><see langword="true"/> if the connection is approaching its data limit, otherwise <see langword="false"/>.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool ApproachingDataLimit;

			/// <summary><see langword="true"/> if the connection has exceeded its data limit, otherwise <see langword="false"/>.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool OverDataLimit;

			/// <summary><see langword="true"/> if the connection is roaming, otherwise <see langword="false"/>.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool Roaming;
		}
	}
}