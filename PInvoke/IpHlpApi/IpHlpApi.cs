using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Vanara.PInvoke
{
	/// <summary>Items from the IpHlpApi.dll</summary>
	public static partial class IpHlpApi
	{
		public const int IF_MAX_PHYS_ADDRESS_LENGTH = 32;
		public const int IF_MAX_STRING_SIZE = 256;
		public const int MAX_ADAPTER_ADDRESS_LENGTH = 8;
		public const int MAX_ADAPTER_DESCRIPTION_LENGTH = 128;
		public const int MAX_ADAPTER_NAME = 128;
		public const int MAX_ADAPTER_NAME_LENGTH = 256;
		public const int MAX_DHCPV6_DUID_LENGTH = 130;
		public const int MAX_DNS_SUFFIX_STRING_LENGTH = 256;
		public const int MAX_DOMAIN_NAME_LEN = 128;
		public const int MAX_HOSTNAME_LEN = 128;
		public const int MAX_INTERFACE_NAME_LEN = 256;
		public const int MAX_SCOPE_ID_LEN = 256;
		public const int MAXLEN_IFDESCR = 256;
		public const int MAXLEN_PHYSADDR = 8;
		public const int MIB_IF_TYPE_ETHERNET = 6;
		public const int MIB_IF_TYPE_FDDI = 15;
		public const int MIB_IF_TYPE_LOOPBACK = 24;
		public const int MIB_IF_TYPE_OTHER = 1;
		public const int MIB_IF_TYPE_PPP = 23;
		public const int MIB_IF_TYPE_SLIP = 28;
		public const int MIB_IF_TYPE_TOKENRING = 9;
		public const int TCPIP_OWNING_MODULE_SIZE = 16;

		/// <summary>The type of addresses to retrieve in <see cref="GetAdaptersAddresses(GetAdaptersAddressesFlags, ADDRESS_FAMILY)"/>.</summary>
		[Flags]
		public enum GetAdaptersAddressesFlags : uint
		{
			/// <summary>Do not return unicast addresses.</summary>
			GAA_FLAG_SKIP_UNICAST = 0x0001,

			/// <summary>Do not return IPv6 anycast addresses.</summary>
			GAA_FLAG_SKIP_ANYCAST = 0x0002,

			/// <summary>Do not return multicast addresses.</summary>
			GAA_FLAG_SKIP_MULTICAST = 0x0004,

			/// <summary>Do not return addresses of DNS servers.</summary>
			GAA_FLAG_SKIP_DNS_SERVER = 0x0008,

			/// <summary>
			/// Return a list of IP address prefixes on this adapter. When this flag is set, IP address prefixes are returned for both IPv6
			/// and IPv4 addresses.
			/// <para>This flag is supported on Windows XP with SP1 and later.</para>
			/// </summary>
			GAA_FLAG_INCLUDE_PREFIX = 0x0010,

			/// <summary>Do not return the adapter friendly name.</summary>
			GAA_FLAG_SKIP_FRIENDLY_NAME = 0x0020,

			/// <summary>
			/// Return addresses of Windows Internet Name Service (WINS) servers.
			/// <para>This flag is supported on Windows Vista and later.</para>
			/// </summary>
			GAA_FLAG_INCLUDE_WINS_INFO = 0x0040,

			/// <summary>
			/// Return the addresses of default gateways.
			/// <para>This flag is supported on Windows Vista and later.</para>
			/// </summary>
			GAA_FLAG_INCLUDE_GATEWAYS = 0x0080,

			/// <summary>
			/// Return addresses for all NDIS interfaces.
			/// <para>This flag is supported on Windows Vista and later.</para>
			/// </summary>
			GAA_FLAG_INCLUDE_ALL_INTERFACES = 0x0100,

			/// <summary>
			/// Return addresses in all routing compartments.
			/// <para>This flag is not currently supported and reserved for future use.</para>
			/// </summary>
			GAA_FLAG_INCLUDE_ALL_COMPARTMENTS = 0x0200,

			/// <summary>Return the adapter addresses sorted in tunnel binding order. This flag is supported on Windows Vista and later.</summary>
			GAA_FLAG_INCLUDE_TUNNEL_BINDINGORDER = 0x0400,
		}

		/// <summary>The IF_OPER_STATUS enumeration specifies the operational status of an interface.</summary>
		public enum IF_OPER_STATUS : uint
		{
			/// <summary>The interface is up and operational. The interface is able to pass packets.</summary>
			IfOperStatusUp = 1,

			/// <summary>The interface is not down and not operational. The interface is unable to pass packets.</summary>
			IfOperStatusDown,

			/// <summary>The interface is being tested.</summary>
			IfOperStatusTesting,

			/// <summary>The interface status is unknown.</summary>
			IfOperStatusUnknown,

			/// <summary>
			/// The interface is not in a condition to pass packets. The interface is not up, but is in a pending state, waiting for some
			/// external event. This state identifies the situation where the interface is waiting for events to place it in the up state.
			/// </summary>
			IfOperStatusDormant,

			/// <summary>
			/// This state is a refinement on the down state which indicates that the interface is down specifically because some component
			/// (for example, a hardware component) is not present in the system.
			/// </summary>
			IfOperStatusNotPresent,

			/// <summary>
			/// This state is a refinement on the down state. The interface is operational, but a networking layer below the interface is not operational.
			/// </summary>
			IfOperStatusLowerLayerDown,
		}

		/// <summary>The interface type as defined by the Internet Assigned Names Authority (IANA).</summary>
		public enum IFTYPE : uint
		{
			/// <summary>Some other type of network interface.</summary>
			IF_TYPE_OTHER = 1,

			IF_TYPE_REGULAR_1822 = 2,
			IF_TYPE_HDH_1822 = 3,
			IF_TYPE_DDN_X25 = 4,
			IF_TYPE_RFC877_X25 = 5,

			/// <summary>An Ethernet network interface.</summary>
			IF_TYPE_ETHERNET_CSMACD = 6,

			IF_TYPE_IS088023_CSMACD = 7,
			IF_TYPE_ISO88024_TOKENBUS = 8,

			/// <summary>A token ring network interface.</summary>
			IF_TYPE_ISO88025_TOKENRING = 9,

			IF_TYPE_ISO88026_MAN = 10,
			IF_TYPE_STARLAN = 11,
			IF_TYPE_PROTEON_10MBIT = 12,
			IF_TYPE_PROTEON_80MBIT = 13,
			IF_TYPE_HYPERCHANNEL = 14,

			/// <summary>A Fiber Distributed Data Interface (FDDI) network interface.</summary>
			IF_TYPE_FDDI = 15,

			IF_TYPE_LAP_B = 16,
			IF_TYPE_SDLC = 17,

			/// <summary>DS1-MIB</summary>
			IF_TYPE_DS1 = 18,

			/// <summary>Obsolete; see DS1-MIB</summary>
			IF_TYPE_E1 = 19,

			IF_TYPE_BASIC_ISDN = 20,
			IF_TYPE_PRIMARY_ISDN = 21,

			/// <summary>proprietary serial</summary>
			IF_TYPE_PROP_POINT2POINT_SERIAL = 22,

			/// <summary>A PPP network interface.</summary>
			IF_TYPE_PPP = 23,

			/// <summary>A software loopback network interface.</summary>
			IF_TYPE_SOFTWARE_LOOPBACK = 24,

			/// <summary>CLNP over IP</summary>
			IF_TYPE_EON = 25,

			IF_TYPE_ETHERNET_3MBIT = 26,

			/// <summary>XNS over IP</summary>
			IF_TYPE_NSIP = 27,

			/// <summary>Generic Slip</summary>
			IF_TYPE_SLIP = 28,

			/// <summary>ULTRA Technologies</summary>
			IF_TYPE_ULTRA = 29,

			/// <summary>DS3-MIB</summary>
			IF_TYPE_DS3 = 30,

			/// <summary>SMDS, coffee</summary>
			IF_TYPE_SIP = 31,

			/// <summary>DTE only</summary>
			IF_TYPE_FRAMERELAY = 32,

			IF_TYPE_RS232 = 33,

			/// <summary>Parallel port</summary>
			IF_TYPE_PARA = 34,

			IF_TYPE_ARCNET = 35,
			IF_TYPE_ARCNET_PLUS = 36,

			/// <summary>An ATM network interface.</summary>
			IF_TYPE_ATM = 37,

			IF_TYPE_MIO_X25 = 38,

			/// <summary>SONET or SDH</summary>
			IF_TYPE_SONET = 39,

			IF_TYPE_X25_PLE = 40,
			IF_TYPE_ISO88022_LLC = 41,
			IF_TYPE_LOCALTALK = 42,
			IF_TYPE_SMDS_DXI = 43,

			/// <summary>FRNETSERV-MIB</summary>
			IF_TYPE_FRAMERELAY_SERVICE = 44,

			IF_TYPE_V35 = 45,
			IF_TYPE_HSSI = 46,
			IF_TYPE_HIPPI = 47,

			/// <summary>Generic Modem</summary>
			IF_TYPE_MODEM = 48,

			/// <summary>AAL5 over ATM</summary>
			IF_TYPE_AAL5 = 49,

			IF_TYPE_SONET_PATH = 50,
			IF_TYPE_SONET_VT = 51,

			/// <summary>SMDS InterCarrier Interface</summary>
			IF_TYPE_SMDS_ICIP = 52,

			/// <summary>Proprietary virtual/internal</summary>
			IF_TYPE_PROP_VIRTUAL = 53,

			/// <summary>Proprietary multiplexing</summary>
			IF_TYPE_PROP_MULTIPLEXOR = 54,

			/// <summary>100BaseVG</summary>
			IF_TYPE_IEEE80212 = 55,

			IF_TYPE_FIBRECHANNEL = 56,
			IF_TYPE_HIPPIINTERFACE = 57,

			/// <summary>Obsolete, use 32 or 44</summary>
			IF_TYPE_FRAMERELAY_INTERCONNECT = 58,

			/// <summary>ATM Emulated LAN for 802.3</summary>
			IF_TYPE_AFLANE_8023 = 59,

			/// <summary>ATM Emulated LAN for 802.5</summary>
			IF_TYPE_AFLANE_8025 = 60,

			/// <summary>ATM Emulated circuit</summary>
			IF_TYPE_CCTEMUL = 61,

			/// <summary>Fast Ethernet (100BaseT)</summary>
			IF_TYPE_FASTETHER = 62,

			/// <summary>ISDN and X.25</summary>
			IF_TYPE_ISDN = 63,

			/// <summary>CCITT V.11/X.21</summary>
			IF_TYPE_V11 = 64,

			/// <summary>CCITT V.36</summary>
			IF_TYPE_V36 = 65,

			/// <summary>CCITT G703 at 64Kbps</summary>
			IF_TYPE_G703_64K = 66,

			/// <summary>Obsolete; see DS1-MIB</summary>
			IF_TYPE_G703_2MB = 67,

			/// <summary>SNA QLLC</summary>
			IF_TYPE_QLLC = 68,

			/// <summary>Fast Ethernet (100BaseFX)</summary>
			IF_TYPE_FASTETHER_FX = 69,

			IF_TYPE_CHANNEL = 70,

			/// <summary>An IEEE 802.11 wireless network interface.</summary>
			IF_TYPE_IEEE80211 = 71,

			/// <summary>IBM System 360/370 OEMI Channel</summary>
			IF_TYPE_IBM370PARCHAN = 72,

			/// <summary>IBM Enterprise Systems Connection</summary>
			IF_TYPE_ESCON = 73,

			/// <summary>Data Link Switching</summary>
			IF_TYPE_DLSW = 74,

			/// <summary>ISDN S/T interface</summary>
			IF_TYPE_ISDN_S = 75,

			/// <summary>ISDN U interface</summary>
			IF_TYPE_ISDN_U = 76,

			/// <summary>Link Access Protocol D</summary>
			IF_TYPE_LAP_D = 77,

			/// <summary>IP Switching Objects</summary>
			IF_TYPE_IPSWITCH = 78,

			/// <summary>Remote Source Route Bridging</summary>
			IF_TYPE_RSRB = 79,

			/// <summary>ATM Logical Port</summary>
			IF_TYPE_ATM_LOGICAL = 80,

			/// <summary>Digital Signal Level 0</summary>
			IF_TYPE_DS0 = 81,

			/// <summary>Group of ds0s on the same ds1</summary>
			IF_TYPE_DS0_BUNDLE = 82,

			/// <summary>Bisynchronous Protocol</summary>
			IF_TYPE_BSC = 83,

			/// <summary>Asynchronous Protocol</summary>
			IF_TYPE_ASYNC = 84,

			/// <summary>Combat Net Radio</summary>
			IF_TYPE_CNR = 85,

			/// <summary>ISO 802.5r DTR</summary>
			IF_TYPE_ISO88025R_DTR = 86,

			/// <summary>Ext Pos Loc Report Sys</summary>
			IF_TYPE_EPLRS = 87,

			/// <summary>Appletalk Remote Access Protocol</summary>
			IF_TYPE_ARAP = 88,

			/// <summary>Proprietary Connectionless Proto</summary>
			IF_TYPE_PROP_CNLS = 89,

			/// <summary>CCITT-ITU X.29 PAD Protocol</summary>
			IF_TYPE_HOSTPAD = 90,

			/// <summary>CCITT-ITU X.3 PAD Facility</summary>
			IF_TYPE_TERMPAD = 91,

			/// <summary>Multiproto Interconnect over FR</summary>
			IF_TYPE_FRAMERELAY_MPI = 92,

			/// <summary>CCITT-ITU X213</summary>
			IF_TYPE_X213 = 93,

			/// <summary>Asymmetric Digital Subscrbr Loop</summary>
			IF_TYPE_ADSL = 94,

			/// <summary>Rate-Adapt Digital Subscrbr Loop</summary>
			IF_TYPE_RADSL = 95,

			/// <summary>Symmetric Digital Subscriber Loop</summary>
			IF_TYPE_SDSL = 96,

			/// <summary>Very H-Speed Digital Subscrb Loop</summary>
			IF_TYPE_VDSL = 97,

			/// <summary>ISO 802.5 CRFP</summary>
			IF_TYPE_ISO88025_CRFPRINT = 98,

			/// <summary>Myricom Myrinet</summary>
			IF_TYPE_MYRINET = 99,

			/// <summary>Voice recEive and transMit</summary>
			IF_TYPE_VOICE_EM = 100,

			/// <summary>Voice Foreign Exchange Office</summary>
			IF_TYPE_VOICE_FXO = 101,

			/// <summary>Voice Foreign Exchange Station</summary>
			IF_TYPE_VOICE_FXS = 102,

			/// <summary>Voice encapsulation</summary>
			IF_TYPE_VOICE_ENCAP = 103,

			/// <summary>Voice over IP encapsulation</summary>
			IF_TYPE_VOICE_OVERIP = 104,

			/// <summary>ATM DXI</summary>
			IF_TYPE_ATM_DXI = 105,

			/// <summary>ATM FUNI</summary>
			IF_TYPE_ATM_FUNI = 106,

			/// <summary>ATM IMA</summary>
			IF_TYPE_ATM_IMA = 107,

			/// <summary>PPP Multilink Bundle</summary>
			IF_TYPE_PPPMULTILINKBUNDLE = 108,

			/// <summary>IBM ipOverCdlc</summary>
			IF_TYPE_IPOVER_CDLC = 109,

			/// <summary>IBM Common Link Access to Workstn</summary>
			IF_TYPE_IPOVER_CLAW = 110,

			/// <summary>IBM stackToStack</summary>
			IF_TYPE_STACKTOSTACK = 111,

			/// <summary>IBM VIPA</summary>
			IF_TYPE_VIRTUALIPADDRESS = 112,

			/// <summary>IBM multi-proto channel support</summary>
			IF_TYPE_MPC = 113,

			/// <summary>IBM ipOverAtm</summary>
			IF_TYPE_IPOVER_ATM = 114,

			/// <summary>ISO 802.5j Fiber Token Ring</summary>
			IF_TYPE_ISO88025_FIBER = 115,

			/// <summary>IBM twinaxial data link control</summary>
			IF_TYPE_TDLC = 116,

			IF_TYPE_GIGABITETHERNET = 117,
			IF_TYPE_HDLC = 118,
			IF_TYPE_LAP_F = 119,
			IF_TYPE_V37 = 120,

			/// <summary>Multi-Link Protocol</summary>
			IF_TYPE_X25_MLP = 121,

			/// <summary>X.25 Hunt Group</summary>
			IF_TYPE_X25_HUNTGROUP = 122,

			IF_TYPE_TRANSPHDLC = 123,

			/// <summary>Interleave channel</summary>
			IF_TYPE_INTERLEAVE = 124,

			/// <summary>Fast channel</summary>
			IF_TYPE_FAST = 125,

			/// <summary>IP (for APPN HPR in IP networks)</summary>
			IF_TYPE_IP = 126,

			/// <summary>CATV Mac Layer</summary>
			IF_TYPE_DOCSCABLE_MACLAYER = 127,

			/// <summary>CATV Downstream interface</summary>
			IF_TYPE_DOCSCABLE_DOWNSTREAM = 128,

			/// <summary>CATV Upstream interface</summary>
			IF_TYPE_DOCSCABLE_UPSTREAM = 129,

			/// <summary>Avalon Parallel Processor</summary>
			IF_TYPE_A12MPPSWITCH = 130,

			/// <summary>A tunnel type encapsulation network interface.</summary>
			IF_TYPE_TUNNEL = 131, // Encapsulation interface

								  /// <summary>Coffee pot</summary>
			IF_TYPE_COFFEE = 132,

			/// <summary>Circuit Emulation Service</summary>
			IF_TYPE_CES = 133,

			/// <summary>ATM Sub Interface</summary>
			IF_TYPE_ATM_SUBINTERFACE = 134,

			/// <summary>Layer 2 Virtual LAN using 802.1Q</summary>
			IF_TYPE_L2_VLAN = 135,

			/// <summary>Layer 3 Virtual LAN using IP</summary>
			IF_TYPE_L3_IPVLAN = 136,

			/// <summary>Layer 3 Virtual LAN using IPX</summary>
			IF_TYPE_L3_IPXVLAN = 137,

			/// <summary>IP over Power Lines</summary>
			IF_TYPE_DIGITALPOWERLINE = 138,

			/// <summary>Multimedia Mail over IP</summary>
			IF_TYPE_MEDIAMAILOVERIP = 139,

			/// <summary>Dynamic syncronous Transfer Mode</summary>
			IF_TYPE_DTM = 140,

			/// <summary>Data Communications Network</summary>
			IF_TYPE_DCN = 141,

			/// <summary>IP Forwarding Interface</summary>
			IF_TYPE_IPFORWARD = 142,

			/// <summary>Multi-rate Symmetric DSL</summary>
			IF_TYPE_MSDSL = 143,

			/// <summary>An IEEE 1394 (Firewire) high performance serial bus network interface.</summary>
			IF_TYPE_IEEE1394 = 144, // IEEE1394 High Perf Serial Bus

			IF_TYPE_IF_GSN = 145,
			IF_TYPE_DVBRCC_MACLAYER = 146,
			IF_TYPE_DVBRCC_DOWNSTREAM = 147,
			IF_TYPE_DVBRCC_UPSTREAM = 148,
			IF_TYPE_ATM_VIRTUAL = 149,
			IF_TYPE_MPLS_TUNNEL = 150,
			IF_TYPE_SRP = 151,
			IF_TYPE_VOICEOVERATM = 152,
			IF_TYPE_VOICEOVERFRAMERELAY = 153,
			IF_TYPE_IDSL = 154,
			IF_TYPE_COMPOSITELINK = 155,
			IF_TYPE_SS7_SIGLINK = 156,
			IF_TYPE_PROP_WIRELESS_P2P = 157,
			IF_TYPE_FR_FORWARD = 158,
			IF_TYPE_RFC1483 = 159,
			IF_TYPE_USB = 160,
			IF_TYPE_IEEE8023AD_LAG = 161,
			IF_TYPE_BGP_POLICY_ACCOUNTING = 162,
			IF_TYPE_FRF16_MFR_BUNDLE = 163,
			IF_TYPE_H323_GATEKEEPER = 164,
			IF_TYPE_H323_PROXY = 165,
			IF_TYPE_MPLS = 166,
			IF_TYPE_MF_SIGLINK = 167,
			IF_TYPE_HDSL2 = 168,
			IF_TYPE_SHDSL = 169,
			IF_TYPE_DS1_FDL = 170,
			IF_TYPE_POS = 171,
			IF_TYPE_DVB_ASI_IN = 172,
			IF_TYPE_DVB_ASI_OUT = 173,
			IF_TYPE_PLC = 174,
			IF_TYPE_NFAS = 175,
			IF_TYPE_TR008 = 176,
			IF_TYPE_GR303_RDT = 177,
			IF_TYPE_GR303_IDT = 178,
			IF_TYPE_ISUP = 179,
			IF_TYPE_PROP_DOCS_WIRELESS_MACLAYER = 180,
			IF_TYPE_PROP_DOCS_WIRELESS_DOWNSTREAM = 181,
			IF_TYPE_PROP_DOCS_WIRELESS_UPSTREAM = 182,
			IF_TYPE_HIPERLAN2 = 183,
			IF_TYPE_PROP_BWA_P2MP = 184,
			IF_TYPE_SONET_OVERHEAD_CHANNEL = 185,
			IF_TYPE_DIGITAL_WRAPPER_OVERHEAD_CHANNEL = 186,
			IF_TYPE_AAL2 = 187,
			IF_TYPE_RADIO_MAC = 188,
			IF_TYPE_ATM_RADIO = 189,
			IF_TYPE_IMT = 190,
			IF_TYPE_MVL = 191,
			IF_TYPE_REACH_DSL = 192,
			IF_TYPE_FR_DLCI_ENDPT = 193,
			IF_TYPE_ATM_VCI_ENDPT = 194,
			IF_TYPE_OPTICAL_CHANNEL = 195,
			IF_TYPE_OPTICAL_TRANSPORT = 196,

			/// <summary>
			/// A mobile broadband interface for WiMax devices. <note type="note">This interface type is supported on Windows 7, Windows
			/// Server 2008 R2, and later.</note>
			/// </summary>
			IF_TYPE_IEEE80216_WMAN = 237,

			/// <summary>
			/// A mobile broadband interface for GSM-based devices. <note type="note">This interface type is supported on Windows 7, Windows
			/// Server 2008 R2, and later.</note>
			/// </summary>
			IF_TYPE_WWANPP = 243,

			/// <summary>
			/// A mobile broadband interface for CDMA-based devices. <note type="note">This interface type is supported on Windows 7, Windows
			/// Server 2008 R2, and later.</note>
			/// </summary>
			IF_TYPE_WWANPP2 = 244,

			/// <summary>IEEE 802.15.4 WPAN interface</summary>
			IF_TYPE_IEEE802154 = 259,

			IF_TYPE_XBOX_WIRELESS = 281,
		}

		/// <summary>A set of flags that provide information about an interface.</summary>
		[Flags]
		public enum InterfaceAndOperStatusFlags : byte
		{
			/// <summary>Set if the network interface is for hardware.</summary>
			HardwareInterface = 1 << 0,

			/// <summary>Set if the network interface is for a filter module.</summary>
			FilterInterface = 1 << 1,

			/// <summary>Set if a connector is present on the network interface. This value is set if there is a physical network adapter.</summary>
			ConnectorPresent = 1 << 2,

			/// <summary>
			/// Set if the default port for the network interface is not authenticated. If a network interface is not authenticated by the
			/// target, then the network interface is not in an operational mode. Although this applies to both wired and wireless network
			/// connections, authentication is more common for wireless network connections.
			/// </summary>
			NotAuthenticated = 1 << 3,

			/// <summary>
			/// Set if the network interface is not in a media-connected state. If a network cable is unplugged for a wired network, this
			/// would be set. For a wireless network, this is set for the network adapter that is not connected to a network.
			/// </summary>
			NotMediaConnected = 1 << 4,

			/// <summary>
			/// Set if the network stack for the network interface is in the paused or pausing state. This does not mean that the computer is
			/// in a hibernated state.
			/// </summary>
			Paused = 1 << 5,

			/// <summary>Set if the network interface is in a low power state.</summary>
			LowPower = 1 << 6,

			/// <summary>
			/// Set if the network interface is an endpoint device and not a true network interface that connects to a network. This can be
			/// set by devices such as smart phones which use networking infrastructure to communicate to the PC but do not provide
			/// connectivity to an external network. It is mandatory for these types of devices to set this flag.
			/// </summary>
			EndPointInterface = 1 << 7
		}

		[PInvokeData("IpTypes.h")]
		[Flags]
		public enum IP_ADAPTER_CAST_FLAGS
		{
			IP_ADAPTER_ADDRESS_DNS_ELIGIBLE = 0x01,
			IP_ADAPTER_ADDRESS_TRANSIENT = 0x02
		}

		[PInvokeData("IPTypes.h")]
		[Flags]
		public enum IP_ADAPTER_FLAGS : uint
		{
			IP_ADAPTER_DDNS_ENABLED = 0x00000001,
			IP_ADAPTER_REGISTER_ADAPTER_SUFFIX = 0x00000002,
			IP_ADAPTER_DHCP_ENABLED = 0x00000004,
			IP_ADAPTER_RECEIVE_ONLY = 0x00000008,
			IP_ADAPTER_NO_MULTICAST = 0x00000010,
			IP_ADAPTER_IPV6_OTHER_STATEFUL_CONFIG = 0x00000020,
			IP_ADAPTER_NETBIOS_OVER_TCPIP_ENABLED = 0x00000040,
			IP_ADAPTER_IPV4_ENABLED = 0x00000080,
			IP_ADAPTER_IPV6_ENABLED = 0x00000100,
			IP_ADAPTER_IPV6_MANAGE_ADDRESS_CONFIG = 0x00000200,
		}

		public enum IP_DAD_STATE : uint
		{
			IpDadStateInvalid = 0,
			IpDadStateTentative,
			IpDadStateDuplicate,
			IpDadStateDeprecated,
			IpDadStatePreferred,
		}

		public enum IP_PREFIX_ORIGIN : uint
		{
			IpPrefixOriginOther = 0,
			IpPrefixOriginManual,
			IpPrefixOriginWellKnown,
			IpPrefixOriginDhcp,
			IpPrefixOriginRouterAdvertisement,
		}

		public enum IP_SUFFIX_ORIGIN : uint
		{
			IpSuffixOriginOther = 0,
			IpSuffixOriginManual,
			IpSuffixOriginWellKnown,
			IpSuffixOriginDhcp,
			IpSuffixOriginLinkLayerAddress,
			IpSuffixOriginRandom,
		}

		[PInvokeData("netioapi.h")]
		public enum MIB_IF_ENTRY_LEVEL
		{
			MibIfEntryNormal = 0,
			MibIfEntryNormalWithoutStatistics = 2
		}

		[PInvokeData("netioapi.h")]
		public enum MIB_IF_TABLE_LEVEL
		{
			MibIfTableNormal,
			MibIfTableRaw,
			MibIfTableNormalWithoutStatistics
		}

		[PInvokeData("IpHlpApi.h")]
		[Flags]
		public enum MIB_IPADDRTYPE : ushort
		{
			MIB_IPADDR_PRIMARY = 0x0001, // Primary ipaddr
			MIB_IPADDR_DYNAMIC = 0x0004, // Dynamic ipaddr
			MIB_IPADDR_DISCONNECTED = 0x0008, // Address is on disconnected interface
			MIB_IPADDR_DELETED = 0x0040, // Address being deleted
			MIB_IPADDR_TRANSIENT = 0x0080, // Transient address
			MIB_IPADDR_DNS_ELIGIBLE = 0X0100, // Address is published in DNS.
		}

		[PInvokeData("IpHlpApi.h")]
		public enum MIB_IPFORWARD_TYPE
		{
			MIB_IPROUTE_TYPE_OTHER = 1,
			MIB_IPROUTE_TYPE_INVALID = 2,
			MIB_IPROUTE_TYPE_DIRECT = 3,
			MIB_IPROUTE_TYPE_INDIRECT = 4,
		}

		[Flags]
		public enum MIB_IPNET_ROW2_FLAGS : uint
		{
			IsRouther = 1,
			IsUnreachable = 2
		}

		[PInvokeData("IpHlpApi.h")]
		public enum MIB_IPNET_TYPE
		{
			MIB_IPNET_TYPE_OTHER = 1,
			MIB_IPNET_TYPE_INVALID = 2,
			MIB_IPNET_TYPE_DYNAMIC = 3,
			MIB_IPNET_TYPE_STATIC = 4,
		}

		[PInvokeData("IpHlpApi.h")]
		public enum MIB_IPPROTOCOL
		{
			MIB_IPPROTO_OTHER = 1,
			MIB_IPPROTO_LOCAL = 2,
			MIB_IPPROTO_NETMGMT = 3,
			MIB_IPPROTO_ICMP = 4,
			MIB_IPPROTO_EGP = 5,
			MIB_IPPROTO_GGP = 6,
			MIB_IPPROTO_HELLO = 7,
			MIB_IPPROTO_RIP = 8,
			MIB_IPPROTO_IS_IS = 9,
			MIB_IPPROTO_ES_IS = 10,
			MIB_IPPROTO_CISCO = 11,
			MIB_IPPROTO_BBN = 12,
			MIB_IPPROTO_OSPF = 13,
			MIB_IPPROTO_BGP = 14,
			MIB_IPPROTO_IDPR = 15,
			MIB_IPPROTO_EIGRP = 16,
			MIB_IPPROTO_DVMRP = 17,
			MIB_IPPROTO_RPL = 18,
			MIB_IPPROTO_DHCP = 19,
			MIB_IPPROTO_NT_AUTOSTATIC = 10002,
			MIB_IPPROTO_NT_STATIC = 10006,
			MIB_IPPROTO_NT_STATIC_NON_DOD = 10007,
		}

		// https://msdn.microsoft.com/en-us/library/aa366896.aspx
		public enum MIB_TCP_STATE
		{
			MIB_TCP_STATE_CLOSED,
			MIB_TCP_STATE_LISTEN,
			MIB_TCP_STATE_SYN_SENT,
			MIB_TCP_STATE_SYN_RCVD,
			MIB_TCP_STATE_ESTAB,
			MIB_TCP_STATE_FIN_WAIT1,
			MIB_TCP_STATE_FIN_WAIT2,
			MIB_TCP_STATE_CLOSE_WAIT,
			MIB_TCP_STATE_CLOSING,
			MIB_TCP_STATE_LAST_ACK,
			MIB_TCP_STATE_TIME_WAIT,
			MIB_TCP_STATE_DELETE_TCB
		}

		/// <summary>The NDIS_MEDIUM enumeration type identifies the medium types that NDIS drivers support.</summary>
		[PInvokeData("ntddndis.h")]
		public enum NDIS_MEDIUM
		{
			/// <summary>Specifies an Ethernet (802.3) network.</summary>
			NdisMedium802_3,

			/// <summary>Specifies a Token Ring (802.5) network. <note type="note">Not supported in Windows 8 or later.</note></summary>
			NdisMedium802_5,

			/// <summary>
			/// Specifies a Fiber Distributed Data Interface (FDDI) network. <note type="note">Not supported in Windows Vista/Windows Server
			/// 2008 or later.</note>
			/// </summary>
			NdisMediumFddi,

			/// <summary>
			/// Specifies a wide area network. This type covers various forms of point-to-point and WAN NICs, as well as variant
			/// address/header formats that must be negotiated between the protocol driver and the underlying driver after the binding is established.
			/// </summary>
			NdisMediumWan,

			/// <summary>Specifies a LocalTalk network.</summary>
			NdisMediumLocalTalk,

			/// <summary>Specifies an Ethernet network for which the drivers use the DIX Ethernet header format.</summary>
			NdisMediumDix,

			/// <summary>Specifies an ARCNET network. <note type="note">Not supported in Windows Vista/Windows Server 2008 or later.</note></summary>
			NdisMediumArcnetRaw,

			/// <summary>
			/// Specifies an ARCNET (878.2) network. <note type="note">Not supported in Windows Vista/Windows Server 2008 or later.</note>
			/// </summary>
			NdisMediumArcnet878_2,

			/// <summary>
			/// Specifies an ATM network. Connection-oriented client protocol drivers can bind themselves to an underlying miniport driver
			/// that returns this value. Otherwise, legacy protocol drivers bind themselves to the system-supplied LanE intermediate driver,
			/// which reports its medium type as either of NdisMedium802_3 or NdisMedium802_5, depending on how the LanE driver is configured
			/// by the network administrator.
			/// </summary>
			NdisMediumAtm,

			/// <summary>
			/// Specifies a wireless network. NDIS 5.X miniport drivers that support wireless LAN (WLAN) or wireless WAN (WWAN) packets
			/// declare their medium as NdisMedium802_3 and emulate Ethernet to higher-level NDIS drivers. <note type="note">Starting with
			/// Windows 7, this media type is supported and can be used for Mobile Broadband.</note>
			/// </summary>
			NdisMediumWirelessWan,

			/// <summary>Specifies an infrared (IrDA) network.</summary>
			NdisMediumIrda,

			/// <summary>Specifies a broadcast PC network.</summary>
			NdisMediumBpc,

			/// <summary>Specifies a wide area network in a connection-oriented environment.</summary>
			NdisMediumCoWan,

			/// <summary>
			/// Specifies an IEEE 1394 (fire wire) network. <note type="note">Not supported in Windows Vista/Windows Server 2008 or later.</note>
			/// </summary>
			NdisMedium1394,

			/// <summary>Specifies an InfiniBand network.</summary>
			NdisMediumInfiniBand,

			/// <summary>Specifies a tunnel network.</summary>
			NdisMediumTunnel,

			/// <summary>Specifies a native IEEE 802.11 network.</summary>
			NdisMediumNative802_11,

			/// <summary>Specifies an NDIS loopback network.</summary>
			NdisMediumLoopback,

			/// <summary>Specifies a WiMAX network.</summary>
			NdisMediumWiMAX,

			/// <summary>Specifies a generic medium that is capable of sending and receiving raw IP packets.</summary>
			NdisMediumIP,

			/// <summary>A maximum value for testing purposes.</summary>
			NdisMediumMax,
		}

		/// <summary>The NDIS physical medium type.</summary>
		[PInvokeData("ntddndis.h")]
		public enum NDIS_PHYSICAL_MEDIUM
		{
			/// <summary>
			/// The physical medium is none of the below values. For example, a one-way satellite feed is an unspecified physical medium.
			/// </summary>
			NdisPhysicalMediumUnspecified = 0,

			/// <summary>Packets are transferred over a wireless LAN network through a miniport driver that conforms to the 802.11 interface.</summary>
			NdisPhysicalMediumWirelessLan = 1,

			/// <summary>Packets are transferred over a DOCSIS-based cable network.</summary>
			NdisPhysicalMediumCableModem = 2,

			/// <summary>Packets are transferred over standard phone lines. This includes HomePNA media, for example.</summary>
			NdisPhysicalMediumPhoneLine = 3,

			/// <summary>Packets are transferred over wiring that is connected to a power distribution system.</summary>
			NdisPhysicalMediumPowerLine = 4,

			/// <summary>
			/// Packets are transferred over a Digital Subscriber Line (DSL) network. This includes ADSL, UADSL (G.Lite), and SDSL, for example.
			/// </summary>
			NdisPhysicalMediumDSL = 5,

			/// <summary>Packets are transferred over a Fibre Channel interconnect.</summary>
			NdisPhysicalMediumFibreChannel = 6,

			/// <summary>Packets are transferred over an IEEE 1394 bus.</summary>
			NdisPhysicalMedium1394 = 7,

			/// <summary>
			/// Packets are transferred over a Wireless WAN link. This includes mobile broadband devices that support CDPD, CDMA, GSM, and
			/// GPRS, for example.
			/// </summary>
			NdisPhysicalMediumWirelessWan = 8,

			/// <summary>
			/// Packets are transferred over a wireless LAN network through a miniport driver that conforms to the Native 802.11 interface.
			/// <note type="note">The Native 802.11 interface is supported in NDIS 6.0 and later versions.</note>
			/// </summary>
			NdisPhysicalMediumNative802_11 = 9,

			/// <summary>
			/// Packets are transferred over a Bluetooth network. Bluetooth is a short-range wireless technology that uses the 2.4 GHz spectrum.
			/// </summary>
			NdisPhysicalMediumBluetooth = 10,

			/// <summary>Packets are transferred over an Infiniband interconnect.</summary>
			NdisPhysicalMediumInfiniband = 11,

			/// <summary>Packets are transferred over a WiMax network.</summary>
			NdisPhysicalMediumWiMax = 12,

			/// <summary>Packets are transferred over an ultra wide band network.</summary>
			NdisPhysicalMediumUWB = 13,

			/// <summary>Packets are transferred over an Ethernet (802.3) network.</summary>
			NdisPhysicalMedium802_3 = 14,

			/// <summary>Packets are transferred over a Token Ring (802.5) network.</summary>
			NdisPhysicalMedium802_5 = 15,

			/// <summary>Packets are transferred over an infrared (IrDA) network.</summary>
			NdisPhysicalMediumIrda = 16,

			/// <summary>Packets are transferred over a wired WAN network.</summary>
			NdisPhysicalMediumWiredWAN = 17,

			/// <summary>Packets are transferred over a wide area network in a connection-oriented environment.</summary>
			NdisPhysicalMediumWiredCoWan = 18,

			/// <summary>Packets are transferred over a network that is not described by other possible values.</summary>
			NdisPhysicalMediumOther = 19,
		}

		[PInvokeData("ifdef.h")]
		public enum NET_IF_ACCESS_TYPE
		{
			NET_IF_ACCESS_LOOPBACK = 1,
			NET_IF_ACCESS_BROADCAST = 2,
			NET_IF_ACCESS_POINT_TO_POINT = 3,
			NET_IF_ACCESS_POINT_TO_MULTI_POINT = 4,
			NET_IF_ACCESS_MAXIMUM = 5
		}

		[PInvokeData("ifdef.h")]
		public enum NET_IF_ADMIN_STATUS
		{
			NET_IF_ADMIN_STATUS_UP = 1,
			NET_IF_ADMIN_STATUS_DOWN = 2,
			NET_IF_ADMIN_STATUS_TESTING = 3
		}

		[PInvokeData("ifdef.h")]
		public enum NET_IF_CONNECTION_TYPE : uint
		{
			NET_IF_CONNECTION_DEDICATED = 1,
			NET_IF_CONNECTION_PASSIVE = 2,
			NET_IF_CONNECTION_DEMAND = 3,
			NET_IF_CONNECTION_MAXIMUM = 4
		}

		[PInvokeData("ifdef.h")]
		public enum NET_IF_DIRECTION_TYPE
		{
			NET_IF_DIRECTION_SENDRECEIVE,
			NET_IF_DIRECTION_SENDONLY,
			NET_IF_DIRECTION_RECEIVEONLY,
			NET_IF_DIRECTION_MAXIMUM
		}

		[PInvokeData("ifdef.h")]
		public enum NET_IF_MEDIA_CONNECT_STATE
		{
			MediaConnectStateUnknown,
			MediaConnectStateConnected,
			MediaConnectStateDisconnected
		}

		[Flags]
		public enum NetBiosNodeType
		{
			UNKNOWN_NODETYPE = 0,
			BROADCAST_NODETYPE = 1,
			PEER_TO_PEER_NODETYPE = 2,
			MIXED_NODETYPE = 4,
			HYBRID_NODETYPE = 8
		}

		public enum NL_NEIGHBOR_STATE
		{
			NlnsUnreachable,
			NlnsIncomplete,
			NlnsProbe,
			NlnsDelay,
			NlnsStale,
			NlnsReachable,
			NlnsPermanent,
			NlnsMaximum,
		}

		[PInvokeData("Nldef.h")]
		public enum NL_ROUTE_ORIGIN
		{
			NlroManual,
			NlroWellKnown,
			NlroDHCP,
			NlroRouterAdvertisement,
			Nlro6to4,
		}

		public enum SCOPE_LEVEL : uint
		{
			ScopeLevelInterface = 1,
			ScopeLevelLink = 2,
			ScopeLevelSubnet = 3,
			ScopeLevelAdmin = 4,
			ScopeLevelSite = 5,
			ScopeLevelOrganization = 8,
			ScopeLevelGlobal = 14
		}

		public enum TCP_CONNECTION_OFFLOAD_STATE
		{
			TcpConnectionOffloadStateInHost = 0,
			TcpConnectionOffloadStateOffloading = 1,
			TcpConnectionOffloadStateOffloaded = 2,
			TcpConnectionOffloadStateUploading = 3,
			TcpConnectionOffloadStateMax = 4
		}

		public enum TCP_RTO_ALGORITHM
		{
			TcpRtoAlgorithmOther = 1,
			TcpRtoAlgorithmConstant = 2,
			TcpRtoAlgorithmRsre = 3,
			TcpRtoAlgorithmVanj = 4,
			MIB_TCP_RTO_OTHER = 1,
			MIB_TCP_RTO_CONSTANT = 2,
			MIB_TCP_RTO_RSRE = 3,
			MIB_TCP_RTO_VANJ = 4,
		}

		// https://msdn2.microsoft.com/en-us/library/aa366386.aspx
		[PInvokeData("IpHlpApi.h")]
		public enum TCP_TABLE_CLASS
		{
			[CorrespondingType(typeof(MIB_TCPTABLE), CorrepsondingAction.Get)]
			TCP_TABLE_BASIC_LISTENER,

			[CorrespondingType(typeof(MIB_TCPTABLE), CorrepsondingAction.Get)]
			TCP_TABLE_BASIC_CONNECTIONS,

			[CorrespondingType(typeof(MIB_TCPTABLE), CorrepsondingAction.Get)]
			TCP_TABLE_BASIC_ALL,

			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_PID), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_PID), CorrepsondingAction.Get)]
			TCP_TABLE_OWNER_PID_LISTENER,

			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_PID), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_PID), CorrepsondingAction.Get)]
			TCP_TABLE_OWNER_PID_CONNECTIONS,

			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_PID), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_PID), CorrepsondingAction.Get)]
			TCP_TABLE_OWNER_PID_ALL,

			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			TCP_TABLE_OWNER_MODULE_LISTENER,

			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			TCP_TABLE_OWNER_MODULE_CONNECTIONS,

			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			TCP_TABLE_OWNER_MODULE_ALL
		}

		/// <summary>
		/// The TUNNEL_TYPE enumeration type defines the encapsulation method used by a tunnel, as described by the Internet Assigned Names
		/// Authority (IANA).
		/// </summary>
		[PInvokeData("ifdef.h")]
		public enum TUNNEL_TYPE : uint
		{
			/// <summary>Indicates that a tunnel is not specified.</summary>
			TUNNEL_TYPE_NONE = 0,

			/// <summary>Indicates that none of the following tunnel types is specified.</summary>
			TUNNEL_TYPE_OTHER = 1,

			/// <summary>
			/// A packet is encapsulated directly within a normal IP header, with no intermediate header, and unicast to the remote tunnel endpoint.
			/// </summary>
			TUNNEL_TYPE_DIRECT = 2,

			/// <summary>
			/// An IPv6 packet is encapsulated directly within an IPv4 header, with no intermediate header, and unicast to the destination
			/// determined by the 6to4 protocol.
			/// </summary>
			TUNNEL_TYPE_6TO4 = 11,

			/// <summary>
			/// An IPv6 packet is encapsulated directly within an IPv4 header, with no intermediate header, and unicast to the destination
			/// determined by the ISATAP protocol.
			/// </summary>
			TUNNEL_TYPE_ISATAP = 13,

			/// <summary>Teredo encapsulation.</summary>
			TUNNEL_TYPE_TEREDO = 14,

			/// <summary>
			/// Specifies that the tunnel uses IP over Hypertext Transfer Protocol Secure (HTTPS). This tunnel type is supported in Windows 7
			/// and later versions of the Windows operating system.
			/// </summary>
			TUNNEL_TYPE_IPHTTPS = 15
		}

		[PInvokeData("IpHlpApi.h")]
		public enum UDP_TABLE_CLASS
		{
			[CorrespondingType(typeof(MIB_UDPTABLE), CorrepsondingAction.Get)]
			UDP_TABLE_BASIC,

			[CorrespondingType(typeof(MIB_UDPTABLE_OWNER_PID), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_UDP6TABLE_OWNER_PID), CorrepsondingAction.Get)]
			UDP_TABLE_OWNER_PID,

			[CorrespondingType(typeof(MIB_UDPTABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			[CorrespondingType(typeof(MIB_UDP6TABLE_OWNER_MODULE), CorrepsondingAction.Get)]
			UDP_TABLE_OWNER_MODULE,
		}

		/// <summary>
		/// <para>The <c>AddIPAddress</c> function adds the specified IPv4 address to the specified adapter.</para>
		/// </summary>
		/// <param name="Address">
		/// <para>The IPv4 address to add to the adapter, in the form of an IPAddr structure.</para>
		/// </param>
		/// <param name="IpMask">
		/// <para>
		/// The subnet mask for the IPv4 address specified in the Address parameter. The <c>IPMask</c> parameter uses the same format as an
		/// IPAddr structure.
		/// </para>
		/// </param>
		/// <param name="IfIndex">
		/// <para>The index of the adapter on which to add the IPv4 address.</para>
		/// </param>
		/// <param name="NTEContext">
		/// <para>
		/// A pointer to a <c>ULONG</c> variable. On successful return, this parameter points to the Net Table Entry (NTE) context for the
		/// IPv4 address that was added. The caller can later use this context in a call to the DeleteIPAddress function.
		/// </para>
		/// </param>
		/// <param name="NTEInstance">
		/// <para>
		/// A pointer to a <c>ULONG</c> variable. On successful return, this parameter points to the NTE instance for the IPv4 address that
		/// was added.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_DEV_NOT_EXIST</term>
		/// <term>The adapter specified by the IfIndex parameter does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_DUP_DOMAINNAME</term>
		/// <term>The IPv4 address to add that is specified in the Address parameter already exists.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_GEN_FAILURE</term>
		/// <term>
		/// A general failure. This error is returned for some values specified in the Address parameter, such as an IPv4 address normally
		/// considered to be a broadcast addresses.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_HANDLE</term>
		/// <term>The user attempting to make the function call is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One or more of the parameters is invalid. This error is returned if the NTEContext or NTEInstance parameters are NULL. This error
		/// is also returned when the IP address specified in the Address parameter is inconsistent with the interface index specified in the
		/// IfIndex parameter (for example, a loopback address on a non-loopback interface).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The function call is not supported on the version of Windows on which it was run.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AddIPAddress</c> function is used to add a new IPv4 address entry on a local computer. The IPv4 address added by the
		/// <c>AddIPAddress</c> function is not persistent. The IPv4 address exists only as long as the adapter object exists. Restarting the
		/// computer destroys the IPv4 address, as does manually resetting the network interface card (NIC). Also, certain PnP events may
		/// destroy the address.
		/// </para>
		/// <para>
		/// To create an IPv4 address that persists, the EnableStatic method of the Win32_NetworkAdapterConfiguration Class in the Windows
		/// Management Instrumentation (WMI) controls may be used. The netsh commands can also be used to create a persistent IPv4 address.
		/// </para>
		/// <para>For more information, please see the documentation on Netsh.exe in the Windows Sockets documentation.</para>
		/// <para>
		/// On Windows Server 2003, Windows XP, and Windows 2000, if the IPv4 address in the Address parameter already exists on the network,
		/// the <c>AddIPAddress</c> function returns <c>NO_ERROR</c> and the IPv4 address added is 0.0.0.0.
		/// </para>
		/// <para>
		/// On Windows Vista and later, if the IPv4 address passed in the Address parameter already exists on the network, the
		/// <c>AddIPAddress</c> function returns <c>NO_ERROR</c> and the duplicate IPv4 address is added with the <c>IP_DAD_STATE</c> member
		/// in the IP_ADAPTER_UNICAST_ADDRESS structure set to <c>IpDadStateDuplicate</c>.
		/// </para>
		/// <para>
		/// An IPv4 address that is added using the <c>AddIPAddress</c> function can later be deleted by calling the DeleteIPAddress function
		/// passing the NTEContext parameter returned by the <c>AddIPAddress</c> function.
		/// </para>
		/// <para>
		/// For information about the <c>IPAddr</c> and <c>IPMask</c> data types, see Windows Data Types. To convert an IPv4 address between
		/// dotted decimal notation and <c>IPAddr</c> format, use the inet_addr and inet_ntoa functions.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the CreateUnicastIpAddressEntry function can be used to add a new unicast IPv4 or IPv6 address entry
		/// on a local computer.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the IP address table to determine the interface index for the first adapter, then adds the IP
		/// address specified on command line to the first adapter. The IP address that was added is then deleted.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-addipaddress DWORD AddIPAddress( IPAddr Address, IPMask
		// IpMask, DWORD IfIndex, PULONG NTEContext, PULONG NTEInstance );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "669264cd-a43c-4681-9416-2704d4232685")]
		public static extern Win32Error AddIPAddress(IN_ADDR Address, IN_ADDR IpMask, uint IfIndex, out uint NTEContext, out uint NTEInstance);

		/// <summary>
		/// <para>
		/// The <c>CancelIPChangeNotify</c> function cancels notification of IPv4 address and route changes previously requested with
		/// successful calls to the NotifyAddrChange or NotifyRouteChange functions.
		/// </para>
		/// </summary>
		/// <param name="notifyOverlapped">
		/// <para>A pointer to the OVERLAPPED structure used in the previous call to NotifyAddrChange or NotifyRouteChange.</para>
		/// </param>
		/// <returns>
		/// <para>None</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CancelIPChangeNotify</c> function deregisters for a change notification previously requested for IPv4 address or route
		/// changes on a local computer. These requests to register for notification are made by calling the NotifyAddrChange or
		/// NotifyRouteChange functions.
		/// </para>
		/// <para>
		/// The OVERLAPPED structure used in the previous call to one of these notification functions is passed to
		/// <c>CancelIPChangeNotify</c> function in the notifyOverlapped parameter to deregister for notifications.
		/// </para>
		/// <para>
		/// The <c>CancelIPChangeNotify</c> can return <c>FALSE</c> if no notification request was found or an invalid notifyOverlapped
		/// parameter was passed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-cancelipchangenotify BOOL CancelIPChangeNotify(
		// LPOVERLAPPED notifyOverlapped );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "10795401-003f-45ce-80f1-ccc31659298a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool CancelIPChangeNotify(System.Threading.NativeOverlapped* notifyOverlapped);

		/// <summary>
		/// <para>
		/// The <c>CreateIpNetEntry</c> function creates an Address Resolution Protocol (ARP) entry in the ARP table on the local computer.
		/// </para>
		/// </summary>
		/// <param name="pArpEntry">
		/// <para>
		/// A pointer to a MIB_IPNETROW structure that specifies information for the new entry. The caller must specify values for all
		/// members of this structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The function returns <c>NO_ERROR</c> (zero) if the function is successful.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned on Windows Vista and Windows Server 2008 under several conditions that include the
		/// following: the user lacks the required administrative privileges on the local computer or the application is not running in an
		/// enhanced shell as the built-in Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An input parameter is invalid, no action was taken. This error is returned if the pArpEntry parameter is NULL, the dwPhysAddrLen
		/// member of MIB_IPNETROW is set to zero or a value greater than 8, the &gt;dwAddr member of the MIB_IPNETROW structure is invalid,
		/// or one of the other members of the MIB_IPNETROW structure is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To modify an existing ARP entry, use the SetIpNetEntry function. To retrieve the ARP table, call the GetIpNetTable function. To
		/// delete an existing ARP entry, call the DeleteIpNetEntry.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>CreateIpNetEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>CreateIpNetEntry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>CreateIpNetEntry</c> function can also fail because of user account control (UAC) on Windows Vista later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-createipnetentry DWORD CreateIpNetEntry( PMIB_IPNETROW
		// pArpEntry );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "607f9aad-2046-4ab2-9a62-4092f87ffa66")]
		public static extern Win32Error CreateIpNetEntry(ref MIB_IPNETROW pArpEntry);

		/// <summary>
		/// <para>The <c>CreateIpNetEntry2</c> function creates a new neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid unicast, anycast, or multicast IPv4
		/// or IPv6 address, the PhysicalAddress and PhysicalAddressLength members of the MIB_IPNET_ROW2 pointed to by the Row parameter were
		/// not set to a valid physical address, or both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the
		/// Row parameter were unspecified. This error is also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter. This error is also returned if no IPv6 stack is on
		/// the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_OBJECT_ALREADY_EXISTS</term>
		/// <term>
		/// The object already exists. This error is returned if the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter is
		/// a duplicate of an existing neighbor IP address on the interface specified by the InterfaceLuid or InterfaceIndex member of the MIB_IPNET_ROW2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>CreateIpNetEntry2</c> function is used to add a new neighbor IP address entry on a local computer.</para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid unicast,
		/// anycast, or multicast IPv4 or IPv6 address and family. The <c>PhysicalAddress</c> and <c>PhysicalAddressLength</c> members in the
		/// <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter must be initialized to a valid physical address. In addition, at
		/// least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the Row parameter must be initialized to the
		/// interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The <c>CreateIpNetEntry2</c> function will fail if the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2
		/// pointed to by the Row parameter is a duplicate of an existing neighbor IP address on the interface.
		/// </para>
		/// <para>
		/// The <c>CreateIpNetEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>CreateIpNetEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-createipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// CreateIpNetEntry2( CONST MIB_IPNET_ROW2 *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "ca92b9f8-ec3c-4889-b649-f606c3920f92")]
		public static extern Win32Error CreateIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>The <c>DeleteIPAddress</c> function deletes an IP address previously added using AddIPAddress.</para>
		/// </summary>
		/// <param name="NTEContext">
		/// <para>The Net Table Entry (NTE) context for the IP address. This context was returned by the previous call to AddIPAddress.</para>
		/// </param>
		/// <returns>
		/// <para>The function returns <c>NO_ERROR</c> (zero) if the function is successful.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned on Windows Vista and Windows Server 2008 under several conditions that include the
		/// following: the user lacks the required administrative privileges on the local computer or the application is not running in an
		/// enhanced shell as the built-in Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An input parameter is invalid, no action was taken.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// On Windows Vista and later, the <c>DeleteIPAddress</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>DeleteIPAddress</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista and later
		/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
		/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the IP address table, then adds the IP address 192.168.0.27 to the first adapter. The IP address
		/// that was added is then deleted.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-deleteipaddress DWORD DeleteIPAddress( ULONG NTEContext );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "d7ed986d-d62e-4723-ab74-85c3edfdf4ff")]
		public static extern Win32Error DeleteIPAddress(uint NTEContext);

		/// <summary>
		/// <para>The <c>DeleteIpNetEntry</c> function deletes an ARP entry from the ARP table on the local computer.</para>
		/// </summary>
		/// <param name="pArpEntry">
		/// <para>
		/// A pointer to a MIB_IPNETROW structure. The information in this structure specifies the entry to delete. The caller must specify
		/// values for at least the <c>dwIndex</c> and <c>dwAddr</c> members of this structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>The function returns <c>NO_ERROR</c> (zero) if the function is successful.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned on Windows Vista and Windows Server 2008 under several conditions that include the
		/// following: the user lacks the required administrative privileges on the local computer or the application is not running in an
		/// enhanced shell as the built-in Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An input parameter is invalid, no action was taken. This error is returned if the pArpEntry parameter is NULL or a member in the
		/// MIB_IPNETROW structure pointed to by the pArpEntry parameter is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>To retrieve the ARP table, call the GetIpNetTable function.</para>
		/// <para>
		/// On Windows Vista and later, the <c>DeleteIpNetEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>DeleteIpNetEntry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>DeleteIpNetEntry</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-deleteipnetentry DWORD DeleteIpNetEntry( PMIB_IPNETROW
		// pArpEntry );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "0d338676-b66f-410c-8022-5576096954b4")]
		public static extern Win32Error DeleteIpNetEntry(ref MIB_IPNETROW pArpEntry);

		/// <summary>
		/// <para>The <c>DeleteIpNetEntry2</c> function deletes a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this entry will be deleted.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid neighbor IPv4 or IPv6 address, or
		/// both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter. This error is also returned if no IPv6 stack is on
		/// the local computer and an IPv6 address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeleteIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>DeleteIpNetEntry2</c> function is used to delete a MIB_IPNET_ROW2 structure entry.</para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a
		/// valid neighbor IPv4 or IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c>
		/// structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output when the call is successful, <c>DeleteIpNetEntry2</c> deletes the neighbor IP address.</para>
		/// <para>The GetIpNetTable2 function can be called to enumerate the neighbor IP address entries on a local computer.</para>
		/// <para>
		/// The <c>DeleteIpNetEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>DeleteIpNetEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-deleteipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// DeleteIpNetEntry2( CONST MIB_IPNET_ROW2 *Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "85bace04-6c95-4cf2-a212-764de292aed6")]
		public static extern Win32Error DeleteIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>
		/// The <c>EnableRouter</c> function turns on IPv4 forwarding on the local computer. <c>EnableRouter</c> also increments a reference
		/// count that tracks the number of requests to enable IPv4 forwarding.
		/// </para>
		/// </summary>
		/// <param name="pHandle">
		/// <para>A pointer to a handle. This parameter is currently unused.</para>
		/// </param>
		/// <param name="pOverlapped">
		/// <para>
		/// A pointer to an OVERLAPPED structure. Except for the <c>hEvent</c> member, all members of this structure should be set to zero.
		/// The <c>hEvent</c> member should contain a handle to a valid event object. Use the CreateEvent function to create this event object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the <c>EnableRouter</c> function succeeds, the return value is ERROR_IO_PENDING.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters is invalid. This error is returned if the pOverlapped parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>EnableRouter</c> function is specific to IPv4 forwarding. If the process that calls <c>EnableRouter</c> terminates without
		/// calling UnenableRouter, the system decrements the reference count that tracks the number of requests to enable IPv4 forwarding as
		/// though the process had called <c>UnenableRouter</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-enablerouter DWORD EnableRouter( HANDLE *pHandle,
		// OVERLAPPED *pOverlapped );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "779f5840-d58d-4194-baa7-2c6a7aeb7d79")]
		public static extern unsafe Win32Error EnableRouter(ref IntPtr pHandle, System.Threading.NativeOverlapped* pOverlapped);

		/// <summary>
		/// <para>The <c>FlushIpNetTable2</c> function flushes the IP neighbor table on the local computer.</para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family to flush.</para>
		/// <para>
		/// Possible values for the address family are listed in the Winsock2.h header file. Note that the values for the AF_ address family
		/// and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and possible values for
		/// this member are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h,
		/// and should never be used directly.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c>, <c>AF_INET6</c>, and <c>AF_UNSPEC</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>
		/// The address family is unspecified. When this parameter is specified, this function flushes the neighbor IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function flushes the neighbor IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function flushes the neighbor IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The interface index. If the index is specified, flush the neighbor IP address entries on a specific interface, otherwise flush
		/// the neighbor IP address entries on all the interfaces. To ignore the interface, set this parameter to zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the Family parameter was not specified as AF_INET,
		/// AF_INET6, or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and AF_INET was specified in the
		/// Family parameter. This error is also returned if no IPv6 stack is on the local computer and AF_INET6 was specified in the Family
		/// parameter. This error is also returned on versions of Windows where this function is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>FlushIpNetTable2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>FlushIpNetTable2</c> function flushes or deletes the neighbor IP addresses on a local system. The Family parameter can be
		/// used to limit neighbor IP addresses to delete to a particular IP address family. If neighbor IP addresses for both IPv4 and IPv6
		/// should be deleted, set the Family parameter to <c>AF_UNSPEC</c>. The InterfaceIndex parameter can be used to limit neighbor IP
		/// addresses to delete to a particular interface. If neighbor IP addresses for all interfaces should be deleted, set the
		/// InterfaceIndex parameter to zero.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// The <c>FlushIpNetTable2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>FlushIpNetTable2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows Vista and
		/// later. If an application that contains this function is executed by a user logged on as a member of the Administrators group
		/// other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-flushipnettable2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// FlushIpNetTable2( ADDRESS_FAMILY Family, NET_IFINDEX InterfaceIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "6ebfca41-acc3-450c-a3c5-881b8c3fca5e")]
		public static extern Win32Error FlushIpNetTable2(ADDRESS_FAMILY Family, uint InterfaceIndex);

		/// <summary>
		/// <para>
		/// The <c>FreeMibTable</c> function frees the buffer allocated by the functions that return tables of network interfaces, addresses,
		/// and routes (GetIfTable2 and GetAnycastIpAddressTable, for example).
		/// </para>
		/// </summary>
		/// <param name="Memory">
		/// <para>A pointer to the buffer to free.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>FreeMibTable</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>FreeMibTable</c> function is used to free the internal buffers used by various functions to retrieve tables of interfaces,
		/// addresses, and routes. When these tables are no longer needed, then <c>FreeMibTable</c> should be called to release the memory
		/// used by these tables.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-freemibtable VOID NETIOAPI_API_ FreeMibTable( PVOID
		// Memory );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "31c8cdc4-73c7-4e82-8226-c90320046199")]
		public static extern void FreeMibTable(IntPtr Memory);

		/// <summary>The <c>GetAdapterIndex</c> function obtains the index of an adapter, given its name.</summary>
		/// <param name="AdapterName">A pointer to a Unicode string that specifies the name of the adapter.</param>
		/// <param name="IfIndex">A pointer to a <c>ULONG</c> variable that points to the index of the adapter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use <c>FormatMessage</c> to obtain the message string for the returned error.</para>
		/// </returns>
		// DWORD GetAdapterIndex( _In_ LPWSTR AdapterName, _Inout_ PULONG IfIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365909(v=vs.85).aspx
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("IpHlpApi.h", MSDNShortId = "aa365909")]
		// public static extern uint GetAdapterIndex([In] [MarshalAs(UnmanagedType.LPWStr)] StringBuilder AdapterName, [In, Out] ref uint IfIndex);
		public static extern Win32Error GetAdapterIndex([MarshalAs(UnmanagedType.LPWStr)] string AdapterName, out uint IfIndex);

		/// <summary>
		/// <para>The <c>GetAdaptersAddresses</c> function retrieves the addresses associated with the adapters on the local computer.</para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family of the addresses to retrieve. This parameter must be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>Return both IPv4 and IPv6 addresses associated with adapters with IPv4 or IPv6 enabled.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>Return only IPv4 addresses associated with adapters with IPv4 enabled.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>Return only IPv6 addresses associated with adapters with IPv6 enabled.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Flags">
		/// <para>
		/// The type of addresses to retrieve. The possible values are defined in the Iptypes.h header file. Note that the Iptypes.h header
		/// file is automatically included in IpHlpApi.h, and should never be used directly.
		/// </para>
		/// <para>
		/// This parameter is a combination of the following values. If this parameter is zero, then unicast, anycast, and multicast IP
		/// addresses will be returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GAA_FLAG_SKIP_UNICAST 0x0001</term>
		/// <term>Do not return unicast addresses.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_SKIP_ANYCAST 0x0002</term>
		/// <term>Do not return IPv6 anycast addresses.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_SKIP_MULTICAST 0x0004</term>
		/// <term>Do not return multicast addresses.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_SKIP_DNS_SERVER 0x0008</term>
		/// <term>Do not return addresses of DNS servers.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_INCLUDE_PREFIX 0x0010</term>
		/// <term>
		/// Return a list of IP address prefixes on this adapter. When this flag is set, IP address prefixes are returned for both IPv6 and
		/// IPv4 addresses. This flag is supported on Windows XP with SP1 and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_SKIP_FRIENDLY_NAME 0x0020</term>
		/// <term>Do not return the adapter friendly name.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_INCLUDE_WINS_INFO 0x0040</term>
		/// <term>Return addresses of Windows Internet Name Service (WINS) servers. This flag is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_INCLUDE_GATEWAYS 0x0080</term>
		/// <term>Return the addresses of default gateways. This flag is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_INCLUDE_ALL_INTERFACES 0x0100</term>
		/// <term>Return addresses for all NDIS interfaces. This flag is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_INCLUDE_ALL_COMPARTMENTS 0x0200</term>
		/// <term>Return addresses in all routing compartments. This flag is not currently supported and reserved for future use.</term>
		/// </item>
		/// <item>
		/// <term>GAA_FLAG_INCLUDE_TUNNEL_BINDINGORDER 0x0400</term>
		/// <term>Return the adapter addresses sorted in tunnel binding order. This flag is supported on Windows Vista and later.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Reserved">
		/// <para>
		/// This parameter is not currently used, but is reserved for future system use. The calling application should pass <c>NULL</c> for
		/// this parameter.
		/// </para>
		/// </param>
		/// <param name="AdapterAddresses">
		/// <para>A pointer to a buffer that contains a linked list of IP_ADAPTER_ADDRESSES structures on successful return.</para>
		/// </param>
		/// <param name="SizePointer">
		/// <para>A pointer to a variable that specifies the size of the buffer pointed to by AdapterAddresses.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c> (defined to the same value as <c>NO_ERROR</c>).</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ADDRESS_NOT_ASSOCIATED</term>
		/// <term>An address has not yet been associated with the network endpoint. DHCP lease information was available.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BUFFER_OVERFLOW</term>
		/// <term>
		/// The buffer size indicated by the SizePointer parameter is too small to hold the adapter information or the AdapterAddresses
		/// parameter is NULL. The SizePointer parameter returned points to the required size of the buffer to hold the adapter information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters is invalid. This error is returned for any of the following conditions: the SizePointer parameter is NULL,
		/// the Address parameter is not AF_INET, AF_INET6, or AF_UNSPEC, or the address information for the parameters requested is greater
		/// than ULONG_MAX.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_DATA</term>
		/// <term>No addresses were found for the requested parameters.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetAdaptersAddresses</c> function can retrieve information for IPv4 and IPv6 addresses.</para>
		/// <para>
		/// Addresses are returned as a linked list of IP_ADAPTER_ADDRESSES structures in the buffer pointed to by the AdapterAddresses
		/// parameter. The application that calls the <c>GetAdaptersAddresses</c> function must allocate the amount of memory needed to
		/// return the <c>IP_ADAPTER_ADDRESSES</c> structures pointed to by the AdapterAddresses parameter. When these returned structures
		/// are no longer required, the application should free the memory allocated. This can be accomplished by calling the HeapAlloc
		/// function to allocate memory and later calling the HeapFree function to free the allocated memory, as shown in the example code.
		/// Other memory allocation and free functions can be used as long as the same family of functions are used for both the allocation
		/// and the free function.
		/// </para>
		/// <para>
		/// <c>GetAdaptersAddresses</c> is implemented only as a synchronous function call. The <c>GetAdaptersAddresses</c> function requires
		/// a significant amount of network resources and time to complete since all of the low-level network interface tables must be traversed.
		/// </para>
		/// <para>
		/// One method that can be used to determine the memory needed to return the IP_ADAPTER_ADDRESSES structures pointed to by the
		/// AdapterAddresses parameter is to pass too small a buffer size as indicated in the SizePointer parameter in the first call to the
		/// <c>GetAdaptersAddresses</c> function, so the function will fail with <c>ERROR_BUFFER_OVERFLOW</c>. When the return value is
		/// <c>ERROR_BUFFER_OVERFLOW</c>, the SizePointer parameter returned points to the required size of the buffer to hold the adapter
		/// information. Note that it is possible for the buffer size required for the <c>IP_ADAPTER_ADDRESSES</c> structures pointed to by
		/// the AdapterAddresses parameter to change between subsequent calls to the <c>GetAdaptersAddresses</c> function if an adapter
		/// address is added or removed. However, this method of using the <c>GetAdaptersAddresses</c> function is strongly discouraged. This
		/// method requires calling the <c>GetAdaptersAddresses</c> function multiple times.
		/// </para>
		/// <para>
		/// The recommended method of calling the <c>GetAdaptersAddresses</c> function is to pre-allocate a 15KB working buffer pointed to by
		/// the AdapterAddresses parameter. On typical computers, this dramatically reduces the chances that the <c>GetAdaptersAddresses</c>
		/// function returns <c>ERROR_BUFFER_OVERFLOW</c>, which would require calling <c>GetAdaptersAddresses</c> function multiple times.
		/// The example code illustrates this method of use.
		/// </para>
		/// <para>
		/// In versions prior to Windows 10, the order in which adapters appear in the list returned by this function can be controlled from
		/// the Network Connections folder: select the Advanced Settings menu item from the Advanced menu. Starting with Windows 10, the
		/// order in which adapters appear in the list is determined by the IPv4 or IPv6 route metric.
		/// </para>
		/// <para>
		/// If the GAA_FLAG_INCLUDE_ALL_INTERFACES is set, then all NDIS adapters will be retrieved even those addresses associated with
		/// adapters not bound to an address family specified in the Family parameter. When this flag is not set, then only the addresses
		/// that are bound to an adapter enabled for the address family specified in the Family parameter are returned.
		/// </para>
		/// <para>
		/// The size of the IP_ADAPTER_ADDRESSESstructure was changed on Windows XP with Service Pack 1 (SP1) and later. Several additional
		/// members were added to this structure. The size of the <c>IP_ADAPTER_ADDRESSES</c> structure was also changed on Windows Vista and
		/// later. A number of additional members were added to this structure. The size of the <c>IP_ADAPTER_ADDRESSES</c> structure also
		/// changed on Windows Vista with Service Pack 1 (SP1)and later and onWindows Server 2008 and later. One additional member was added
		/// to this structure. The <c>Length</c> member of the <c>IP_ADAPTER_ADDRESSES</c> structure returned in the linked list of
		/// structures in the buffer pointed to by the AdapterAddresses parameter should be used to determine which version of the
		/// <c>IP_ADAPTER_ADDRESSES</c> structure is being used.
		/// </para>
		/// <para>
		/// The GetIpAddrTable function retrieves the interface–to–IPv4 address mapping table on a local computer and returns this
		/// information in an MIB_IPADDRTABLE structure.
		/// </para>
		/// <para>
		/// On the Platform Software Development Kit (SDK) released for Windows Server 2003 and earlier, the return value for the
		/// <c>GetAdaptersAddresses</c> function was defined as a <c>DWORD</c>, rather than a <c>ULONG</c>.
		/// </para>
		/// <para>
		/// The SOCKET_ADDRESS structure is used in the IP_ADAPTER_ADDRESSES structure pointed to by the AdapterAddresses parameter. On the
		/// Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files has
		/// changed and the <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file which is automatically included by the
		/// Winsock2.h header file. On the Platform SDK released for Windows Server 2003 and Windows XP, the <c>SOCKET_ADDRESS</c> structure
		/// is declared in the Winsock2.h header file. In order to use the <c>IP_ADAPTER_ADDRESSES</c> structure, the Winsock2.h header file
		/// must be included before the IpHlpApi.h header file.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// This example retrieves the IP_ADAPTER_ADDRESSES structure for the adapters associated with the system and prints some members for
		/// each adapter interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getadaptersaddresses ULONG GetAdaptersAddresses( ULONG
		// Family, ULONG Flags, PVOID Reserved, PIP_ADAPTER_ADDRESSES AdapterAddresses, PULONG SizePointer );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "7b34138f-7263-4b73-95df-9e854fd81135")]
		public static extern Win32Error GetAdaptersAddresses(uint Family, GetAdaptersAddressesFlags Flags, IntPtr Reserved, IntPtr pAdapterAddresses, ref uint pOutBufLen);

		/// <summary>The <c>GetAdaptersAddresses</c> function retrieves the addresses associated with the adapters on the local computer.</summary>
		/// <param name="Flags">
		/// The type of addresses to retrieve. If this parameter is zero, then unicast, anycast, and multicast IP addresses will be returned.
		/// </param>
		/// <param name="Family">The address family of the addresses to retrieve.</param>
		/// <returns>A list of IP_ADAPTER_ADDRESSES structures on successful return.</returns>
		public static IEnumerable<IP_ADAPTER_ADDRESSES> GetAdaptersAddresses(GetAdaptersAddressesFlags Flags = 0, ADDRESS_FAMILY Family = ADDRESS_FAMILY.AF_UNSPEC)
		{
			uint len = 0;
			Win32Error e = GetAdaptersAddresses((uint)Family, Flags, IntPtr.Zero, IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				e.ThrowIfFailed();
			}

			SafeCoTaskMemHandle mem = new SafeCoTaskMemHandle((int)len);
			GetAdaptersAddresses((uint)Family, Flags, IntPtr.Zero, (IntPtr)mem, ref len).ThrowIfFailed();
			return mem.DangerousGetHandle().LinkedListToIEnum<IP_ADAPTER_ADDRESSES>(t => t.Next);
		}

		/// <summary>
		/// <para>The <c>GetAdaptersInfo</c> function retrieves adapter information for the local computer.</para>
		/// <para><c>On Windows XP and later:</c> Use the GetAdaptersAddresses function instead of <c>GetAdaptersInfo</c>.</para>
		/// </summary>
		/// <param name="AdapterInfo">
		/// <para>A pointer to a buffer that receives a linked list of IP_ADAPTER_INFO structures.</para>
		/// </param>
		/// <param name="SizePointer">
		/// <para>
		/// A pointer to a <c>ULONG</c> variable that specifies the size of the buffer pointed to by the pAdapterInfo parameter. If this size
		/// is insufficient to hold the adapter information, <c>GetAdaptersInfo</c> fills in this variable with the required size, and
		/// returns an error code of <c>ERROR_BUFFER_OVERFLOW</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c> (defined to the same value as <c>NO_ERROR</c>).</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BUFFER_OVERFLOW</term>
		/// <term>
		/// The buffer to receive the adapter information is too small. This value is returned if the buffer size indicated by the pOutBufLen
		/// parameter is too small to hold the adapter information or the pAdapterInfo parameter was a NULL pointer. When this error code is
		/// returned, the pOutBufLen parameter points to the required buffer size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>Invalid adapter information was retrieved.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters is invalid. This error is returned if the pOutBufLen parameter is a NULL pointer, or the calling process
		/// does not have read/write access to the memory pointed to by pOutBufLen or the calling process does not have write access to the
		/// memory pointed to by the pAdapterInfo parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_DATA</term>
		/// <term>No adapter information exists for the local computer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The GetAdaptersInfo function is not supported by the operating system running on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>If the function fails, use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetAdaptersInfo</c> function can retrieve information only for IPv4 addresses.</para>
		/// <para>
		/// In versions prior to Windows 10, the order in which adapters appear in the list returned by this function can be controlled from
		/// the Network Connections folder: select the Advanced Settings menu item from the Advanced menu. Starting with Windows 10, the
		/// order is unspecified.
		/// </para>
		/// <para>
		/// The <c>GetAdaptersInfo</c> and GetInterfaceInfo functions do not return information about the IPv4 loopback interface.
		/// Information on the loopback interface is returned by the GetIpAddrTable function.
		/// </para>
		/// <para>
		/// <c>On Windows XP and later:</c> The list of adapters returned by <c>GetAdaptersInfo</c> includes unidirectional adapters. To
		/// generate a list of adapters that can both send and receive data, call GetUniDirectionalAdapterInfo, and exclude the returned
		/// adapters from the list returned by <c>GetAdaptersInfo</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>This example retrieves the adapter information and prints various properties of each adapter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getadaptersinfo ULONG GetAdaptersInfo( PIP_ADAPTER_INFO
		// AdapterInfo, PULONG SizePointer );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "8cdecc84-6566-438b-86d0-3c55490a9a59")]
		[Obsolete("On Windows XP and later: Use the GetAdaptersAddresses function instead of GetAdaptersInfo.")]
		public static extern Win32Error GetAdaptersInfo(IntPtr pAdapterInfo, ref uint pBufOutLen);

		/// <summary>
		/// <para>
		/// The <c>GetBestInterface</c> function retrieves the index of the interface that has the best route to the specified IPv4 address.
		/// </para>
		/// </summary>
		/// <param name="dwDestAddr">
		/// <para>The destination IPv4 address for which to retrieve the interface that has the best route, in the form of an IPAddr structure.</para>
		/// </param>
		/// <param name="pdwBestIfIndex">
		/// <para>
		/// A pointer to a <c>DWORD</c> variable that receives the index of the interface that has the best route to the IPv4 address
		/// specified by dwDestAddr.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_CAN_NOT_COMPLETE</term>
		/// <term>The operation could not be completed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pdwBestIfIndex
		/// parameter or if the pdwBestIfIndex points to memory that cannot be written.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetBestInterface</c> function only works with IPv4 addresses. For use with IPv6 addresses, the GetBestInterfaceEx must be used.
		/// </para>
		/// <para>
		/// For information about the <c>IPAddr</c> data type, see Windows Data Types. To convert an IP address between dotted decimal
		/// notation and <c>IPAddr</c> format, use the inet_addr and inet_ntoa functions.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the pdwBestIfIndex parameter is treated internally by IP Helper as a pointer to a <c>NET_IFINDEX</c> datatype.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getbestinterface DWORD GetBestInterface( IPAddr
		// dwDestAddr, PDWORD pdwBestIfIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "9171cdf7-4057-4a8d-a34c-1b7b1f94bcb1")]
		public static extern Win32Error GetBestInterface(IN_ADDR dwDestAddr, out uint pdwBestIfIndex);

		/// <summary>
		/// <para>
		/// The <c>GetBestInterfaceEx</c> function retrieves the index of the interface that has the best route to the specified IPv4 or IPv6 address.
		/// </para>
		/// </summary>
		/// <param name="pDestAddr">
		/// <para>
		/// The destination IPv6 or IPv4 address for which to retrieve the interface with the best route, in the form of a sockaddr structure.
		/// </para>
		/// </param>
		/// <param name="pdwBestIfIndex">
		/// <para>A pointer to the index of the interface with the best route to the IPv6 or IPv4 address specified by pDestAddr.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_CAN_NOT_COMPLETE</term>
		/// <term>The operation could not be completed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pdwBestIfIndex
		/// parameter or if the pDestAddr or pdwBestIfIndex parameters point to memory that cannot be accessed. This error can also be
		/// returned if the pdwBestIfIndex parameter points to memory that can't be written to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the pDestAddr parameter or no IPv6 stack is on the local computer and an IPv6 address was specified in the pDestAddr parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetBestInterfaceEx</c> function differs from the GetBestInterface function in that it can be used with either IPv4 or IPv6 addresses.
		/// </para>
		/// <para>
		/// The <c>Family</c> member of the sockaddr structure pointed to by the pDestAddr parameter must be set to one of the following
		/// values: <c>AF_INET</c> or <c>AF_INET6</c>.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the pdwBestIfIndex parameter is treated internally by IP Helper as a pointer to a <c>NET_IFINDEX</c> datatype.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getbestinterfaceex DWORD GetBestInterfaceEx( sockaddr
		// *pDestAddr, PDWORD pdwBestIfIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "cfd1108e-d7a0-4fe5-be3f-299189089d37")]
		public static extern Win32Error GetBestInterfaceEx(SOCKADDR pDestAddr, out uint pdwBestIfIndex);

		/// <summary>
		/// <para>The <c>GetBestRoute</c> function retrieves the best route to the specified destination IP address.</para>
		/// </summary>
		/// <param name="dwDestAddr">
		/// <para>Destination IP address for which to obtain the best route.</para>
		/// </param>
		/// <param name="dwSourceAddr">
		/// <para>
		/// Source IP address. This IP address corresponds to an interface on the local computer. If multiple best routes to the destination
		/// address exist, the function selects the route that uses this interface.
		/// </para>
		/// <para>This parameter is optional. The caller may specify zero for this parameter.</para>
		/// </param>
		/// <param name="pBestRoute">
		/// <para>Pointer to a MIB_IPFORWARDROW structure containing the best route for the IP address specified by dwDestAddr.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getbestroute DWORD GetBestRoute( DWORD dwDestAddr, DWORD
		// dwSourceAddr, PMIB_IPFORWARDROW pBestRoute );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5e507d14-f603-467d-9c37-bb048658d0b1")]
		public static extern Win32Error GetBestRoute(IN_ADDR dwDestAddr, [Optional] IN_ADDR dwSourceAddr, out MIB_IPFORWARDROW pBestRoute);

		/// <summary>
		/// <para>
		/// The <c>GetBestRoute2</c> function retrieves the IP route entry on the local computer for the best route to the specified
		/// destination IP address.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</para>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The local index value to specify the network interface associated with an IP route entry. This index value may change when a
		/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>The source IP address. This parameter may be omitted and passed as a <c>NULL</c> pointer.</para>
		/// </param>
		/// <param name="DestinationAddress">
		/// <para>The destination IP address.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>A set of options that affect how IP addresses are sorted. This parameter is not currently used.</para>
		/// </param>
		/// <param name="BestRoute">
		/// <para>A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</para>
		/// </param>
		/// <param name="BestSourceAddress">
		/// <para>A pointer to the best source IP address.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the DestinationAddress,
		/// BestSourceAddress, or the BestRoute parameter. This error is also returned if the DestinationAddress parameter does not specify
		/// an IPv4 or IPv6 address and family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address and family was
		/// specified in the DestinationAddress parameter. This error is also returned if no IPv6 stack is on the local computer and an IPv6
		/// address and family was specified in the DestinationAddress parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetBestRoute2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetBestRoute2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry for the best route from a source IP
		/// address to a destination IP address.
		/// </para>
		/// <para>
		/// On input, the DestinationAddress parameter must be initialized to a valid IPv4 or IPv6 address and family. On input, the
		/// SourceAddress parameter may be initialized to the preferred IPv4 or IPv6 address and family. In addition, at least one of the
		/// following parameters must be initialized: the InterfaceLuid or InterfaceIndex.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetBestRoute2</c> retrieves and MIB_IPFORWARD_ROW2 structure for the best route from
		/// the source IP address the destination IP address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getbestroute2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetBestRoute2( NET_LUID *InterfaceLuid, NET_IFINDEX InterfaceIndex, CONST SOCKADDR_INET *SourceAddress, CONST SOCKADDR_INET
		// *DestinationAddress, ULONG AddressSortOptions, PMIB_IPFORWARD_ROW2 BestRoute, SOCKADDR_INET *BestSourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7bc16824-c98f-4cd5-a589-e198b48b637c")]
		public static extern Win32Error GetBestRoute2(ref NET_LUID InterfaceLuid, uint InterfaceIndex, ref SOCKADDR_INET SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>
		/// <para>
		/// The <c>GetBestRoute2</c> function retrieves the IP route entry on the local computer for the best route to the specified
		/// destination IP address.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</para>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The local index value to specify the network interface associated with an IP route entry. This index value may change when a
		/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>The source IP address. This parameter may be omitted and passed as a <c>NULL</c> pointer.</para>
		/// </param>
		/// <param name="DestinationAddress">
		/// <para>The destination IP address.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>A set of options that affect how IP addresses are sorted. This parameter is not currently used.</para>
		/// </param>
		/// <param name="BestRoute">
		/// <para>A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</para>
		/// </param>
		/// <param name="BestSourceAddress">
		/// <para>A pointer to the best source IP address.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the DestinationAddress,
		/// BestSourceAddress, or the BestRoute parameter. This error is also returned if the DestinationAddress parameter does not specify
		/// an IPv4 or IPv6 address and family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address and family was
		/// specified in the DestinationAddress parameter. This error is also returned if no IPv6 stack is on the local computer and an IPv6
		/// address and family was specified in the DestinationAddress parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetBestRoute2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetBestRoute2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry for the best route from a source IP
		/// address to a destination IP address.
		/// </para>
		/// <para>
		/// On input, the DestinationAddress parameter must be initialized to a valid IPv4 or IPv6 address and family. On input, the
		/// SourceAddress parameter may be initialized to the preferred IPv4 or IPv6 address and family. In addition, at least one of the
		/// following parameters must be initialized: the InterfaceLuid or InterfaceIndex.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetBestRoute2</c> retrieves and MIB_IPFORWARD_ROW2 structure for the best route from
		/// the source IP address the destination IP address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getbestroute2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetBestRoute2( NET_LUID *InterfaceLuid, NET_IFINDEX InterfaceIndex, CONST SOCKADDR_INET *SourceAddress, CONST SOCKADDR_INET
		// *DestinationAddress, ULONG AddressSortOptions, PMIB_IPFORWARD_ROW2 BestRoute, SOCKADDR_INET *BestSourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7bc16824-c98f-4cd5-a589-e198b48b637c")]
		public static extern Win32Error GetBestRoute2(IntPtr InterfaceLuid, uint InterfaceIndex, ref SOCKADDR_INET SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>
		/// <para>
		/// The <c>GetBestRoute2</c> function retrieves the IP route entry on the local computer for the best route to the specified
		/// destination IP address.
		/// </para>
		/// </summary>
		/// <param name="InterfaceLuid">
		/// <para>The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</para>
		/// </param>
		/// <param name="InterfaceIndex">
		/// <para>
		/// The local index value to specify the network interface associated with an IP route entry. This index value may change when a
		/// network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>The source IP address. This parameter may be omitted and passed as a <c>NULL</c> pointer.</para>
		/// </param>
		/// <param name="DestinationAddress">
		/// <para>The destination IP address.</para>
		/// </param>
		/// <param name="AddressSortOptions">
		/// <para>A set of options that affect how IP addresses are sorted. This parameter is not currently used.</para>
		/// </param>
		/// <param name="BestRoute">
		/// <para>A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</para>
		/// </param>
		/// <param name="BestSourceAddress">
		/// <para>A pointer to the best source IP address.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the DestinationAddress,
		/// BestSourceAddress, or the BestRoute parameter. This error is also returned if the DestinationAddress parameter does not specify
		/// an IPv4 or IPv6 address and family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address and family was
		/// specified in the DestinationAddress parameter. This error is also returned if no IPv6 stack is on the local computer and an IPv6
		/// address and family was specified in the DestinationAddress parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetBestRoute2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetBestRoute2</c> function is used to retrieve a MIB_IPFORWARD_ROW2 structure entry for the best route from a source IP
		/// address to a destination IP address.
		/// </para>
		/// <para>
		/// On input, the DestinationAddress parameter must be initialized to a valid IPv4 or IPv6 address and family. On input, the
		/// SourceAddress parameter may be initialized to the preferred IPv4 or IPv6 address and family. In addition, at least one of the
		/// following parameters must be initialized: the InterfaceLuid or InterfaceIndex.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetBestRoute2</c> retrieves and MIB_IPFORWARD_ROW2 structure for the best route from
		/// the source IP address the destination IP address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getbestroute2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetBestRoute2( NET_LUID *InterfaceLuid, NET_IFINDEX InterfaceIndex, CONST SOCKADDR_INET *SourceAddress, CONST SOCKADDR_INET
		// *DestinationAddress, ULONG AddressSortOptions, PMIB_IPFORWARD_ROW2 BestRoute, SOCKADDR_INET *BestSourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "7bc16824-c98f-4cd5-a589-e198b48b637c")]
		public static extern Win32Error GetBestRoute2(IntPtr InterfaceLuid, uint InterfaceIndex, IntPtr SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>
		/// <para>The <c>GetExtendedTcpTable</c> function retrieves a table that contains a list of TCP endpoints available to the application.</para>
		/// </summary>
		/// <param name="pTcpTable">
		/// <para>
		/// A pointer to the table structure that contains the filtered TCP endpoints available to the application. For information about how
		/// to determine the type of table returned based on specific input parameter combinations, see the Remarks section later in this document.
		/// </para>
		/// </param>
		/// <param name="pdwSize">
		/// <para>
		/// The estimated size of the structure returned in pTcpTable, in bytes. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct size of the structure.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// <para>
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is set to <c>TRUE</c>, the TCP
		/// endpoints in the table are sorted in ascending order, starting with the lowest local IP address. If this parameter is set to
		/// <c>FALSE</c>, the TCP endpoints in the table appear in the order in which they were retrieved.
		/// </para>
		/// <para>The following values are compared (as listed) when ordering the TCP endpoints:</para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID (applicable when the ulAf parameter is set to AF_INET6)</term>
		/// </item>
		/// <item>
		/// <term>Local TCP port</term>
		/// </item>
		/// <item>
		/// <term>Remote IP address</term>
		/// </item>
		/// <item>
		/// <term>Remote scope ID (applicable when the ulAf parameter is set to AF_INET6)</term>
		/// </item>
		/// <item>
		/// <term>Remote TCP port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ulAf">
		/// <para>The version of IP used by the TCP endpoints.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>IPv4 is used.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>IPv6 is used.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="TableClass">
		/// <para>The type of the TCP table structure to retrieve. This parameter can be one of the values from the TCP_TABLE_CLASS enumeration.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the TCP_TABLE_CLASS
		/// enumeration is defined in the Iprtrmib.h header file, not in the IpHlpApi.h header file.
		/// </para>
		/// <para>
		/// The TCP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended TCP information
		/// to retrieve.
		/// </para>
		/// </param>
		/// <param name="Reserved">
		/// <para>Reserved. This value must be zero.</para>
		/// </param>
		/// <returns>
		/// <para>If the call is successful, the value <c>NO_ERROR</c> is returned.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// An insufficient amount of space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must
		/// be used in a subsequent call to this function in order to successfully retrieve the table. This error is also returned if the
		/// pTcpTable parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the TableClass parameter contains a value that is not
		/// defined in the TCP_TABLE_CLASS enumeration.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The table type returned by this function depends on the specific combination of the ulAf parameter and the TableClass parameter.
		/// </para>
		/// <para>
		/// When the ulAf parameter is set to <c>AF_INET</c>, the following table indicates the TCP table type to retrieve in the structure
		/// pointed to by the pTcpTable parameter for each possible TableClass value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>TableClass value</term>
		/// <term>pTcpTable structure</term>
		/// </listheader>
		/// <item>
		/// <term>TCP_TABLE_BASIC_ALL</term>
		/// <term>MIB_TCPTABLE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_BASIC_CONNECTIONS</term>
		/// <term>MIB_TCPTABLE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_BASIC_LISTENER</term>
		/// <term>MIB_TCPTABLE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_MODULE_ALL</term>
		/// <term>MIB_TCPTABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_MODULE_CONNECTIONS</term>
		/// <term>MIB_TCPTABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_MODULE_LISTENER</term>
		/// <term>MIB_TCPTABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_PID_ALL</term>
		/// <term>MIB_TCPTABLE_OWNER_PID</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_PID_CONNECTIONS</term>
		/// <term>MIB_TCPTABLE_OWNER_PID</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_PID_LISTENER</term>
		/// <term>MIB_TCPTABLE_OWNER_PID</term>
		/// </item>
		/// </list>
		/// <para>
		/// When the ulAf parameter is set to <c>AF_INET6</c>, the following table indicates the TCP table type to retrieve in the structure
		/// pointed to by the pTcpTable parameter for each possible TableClass value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>TableClass value</term>
		/// <term>pTcpTable structure</term>
		/// </listheader>
		/// <item>
		/// <term>TCP_TABLE_OWNER_MODULE_ALL</term>
		/// <term>MIB_TCP6TABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_MODULE_CONNECTIONS</term>
		/// <term>MIB_TCP6TABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_MODULE_LISTENER</term>
		/// <term>MIB_TCP6TABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_PID_ALL</term>
		/// <term>MIB_TCP6TABLE_OWNER_PID</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_PID_CONNECTIONS</term>
		/// <term>MIB_TCP6TABLE_OWNER_PID</term>
		/// </item>
		/// <item>
		/// <term>TCP_TABLE_OWNER_PID_LISTENER</term>
		/// <term>MIB_TCP6TABLE_OWNER_PID</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>GetExtendedTcpTable</c> function called with the ulAf parameter set to <c>AF_INET6</c> and the TableClass set to
		/// <c>TCP_TABLE_BASIC_LISTENER</c>, <c>TCP_TABLE_BASIC_CONNECTIONS</c>, or <c>TCP_TABLE_BASIC_ALL</c> is not supported and returns <c>ERROR_NOT_SUPPORTED</c>.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vistaand later, the organization of header files has changed. The various MIB_TCPTABLE
		/// structures are defined in the Tcpmib.h header file, not in the Iprtrmib.h header file. Note that the Tcpmib.h header file is
		/// automatically included in Iprtrmib.h, which is automatically included in the IpHlpApi.h header file. The Tcpmib.h and Iprtrmib.h
		/// header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getextendedtcptable DWORD GetExtendedTcpTable( PVOID
		// pTcpTable, PDWORD pdwSize, BOOL bOrder, ULONG ulAf, TCP_TABLE_CLASS TableClass, ULONG Reserved );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "96356a0e-ae0d-4000-9223-a578cbdeaa8b")]
		public static extern Win32Error GetExtendedTcpTable(IntPtr pTcpTable, ref uint dwOutBufLen, [MarshalAs(UnmanagedType.Bool)] bool bOrder, uint ulAf, TCP_TABLE_CLASS TableClass, uint Reserved = 0);

		/// <summary>The GetExtendedTcpTable function retrieves a table that contains a list of TCP endpoints available to the application.</summary>
		/// <typeparam name="T">The type that is defined as the table associated with the <paramref name="TableClass"/> value.</typeparam>
		/// <param name="TableClass">
		/// The type of the TCP table structure to retrieve. This parameter can be one of the values from the TCP_TABLE_CLASS enumeration.
		/// <para>
		/// The TCP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended TCP information
		/// to retrieve.
		/// </para>
		/// </param>
		/// <param name="ulAf">The version of IP used by the TCP endpoints. Valid values are AF_INET and AF_INET6.</param>
		/// <param name="sorted">
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is set to TRUE, the TCP endpoints in
		/// the table are sorted in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the TCP
		/// endpoints in the table appear in the order in which they were retrieved.
		/// </param>
		/// <returns>The table.</returns>
		public static T GetExtendedTcpTable<T>(TCP_TABLE_CLASS TableClass, ADDRESS_FAMILY ulAf = ADDRESS_FAMILY.AF_INET, bool sorted = false) where T : SafeHandle
		{
			if (!CorrespondingTypeAttribute.CanGet(TableClass, typeof(T)))
			{
				throw new InvalidOperationException("Type mismatch with supplied options.");
			}

			if (ulAf == ADDRESS_FAMILY.AF_INET6 && (int)TableClass > 2 && !typeof(T).Name.Contains("6"))
			{
				throw new InvalidOperationException("Type mismatch with supplied options.");
			}

			if (ulAf == ADDRESS_FAMILY.AF_INET && (int)TableClass > 2 && typeof(T).Name.Contains("6"))
			{
				throw new InvalidOperationException("Type mismatch with supplied options.");
			}

			uint len = 0;
			Win32Error e = GetExtendedTcpTable(IntPtr.Zero, ref len, false, (uint)ulAf, TableClass);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			T mem = (T)Activator.CreateInstance(typeof(T), len);
			GetExtendedTcpTable(mem.DangerousGetHandle(), ref len, sorted, (uint)ulAf, TableClass).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>The <c>GetExtendedUdpTable</c> function retrieves a table that contains a list of UDP endpoints available to the application.</para>
		/// </summary>
		/// <param name="pUdpTable">
		/// <para>
		/// A pointer to the table structure that contains the filtered UDP endpoints available to the application. For information about how
		/// to determine the type of table returned based on specific input parameter combinations, see the Remarks section later in this document.
		/// </para>
		/// </param>
		/// <param name="pdwSize">
		/// <para>
		/// The estimated size of the structure returned in pUdpTable, in bytes. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct size of the structure.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// <para>
		/// A value that specifies whether the UDP endpoint table should be sorted. If this parameter is set to <c>TRUE</c>, the UDP
		/// endpoints in the table are sorted in ascending order, starting with the lowest local IP address. If this parameter is set to
		/// <c>FALSE</c>, the UDP endpoints in the table appear in the order in which they were retrieved.
		/// </para>
		/// <para>The following values are compared as listed when ordering the UDP endpoints:</para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID (applicable when the ulAf parameter is set to AF_INET6)</term>
		/// </item>
		/// <item>
		/// <term>Local UDP port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ulAf">
		/// <para>The version of IP used by the UDP endpoint.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>IPv4 is used.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>IPv6 is used.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="TableClass">
		/// <para>The type of the UDP table structure to retrieve. This parameter can be one of the values from the UDP_TABLE_CLASS enumeration.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the UDP_TABLE_CLASS
		/// enumeration is defined in the Iprtrmib.h header file, not in the IpHlpApi.h header file.
		/// </para>
		/// <para>
		/// The UDP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended UDP information
		/// to retrieve.
		/// </para>
		/// </param>
		/// <param name="Reserved">
		/// <para>Reserved. This value must be zero.</para>
		/// </param>
		/// <returns>
		/// <para>If the call is successful, the value <c>NO_ERROR</c> is returned.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// An insufficient amount of space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must
		/// be used in a subsequent call to this function in order to successfully retrieve the table. This error is also returned if the
		/// pUdpTable parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the TableClass parameter contains a value that is not
		/// defined in the UDP_TABLE_CLASS enumeration.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The table type returned by this function depends on the specific combination of the ulAf parameter and the TableClass parameter.
		/// </para>
		/// <para>
		/// When the ulAf parameter is set to <c>AF_INET</c>, the following table indicates the UDP table type to retrieve in the structure
		/// pointed to by the pUdpTable parameter for each possible TableClass value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>TableClass value</term>
		/// <term>pUdpTable structure</term>
		/// </listheader>
		/// <item>
		/// <term>UDP_TABLE_BASIC</term>
		/// <term>MIB_UDPTABLE</term>
		/// </item>
		/// <item>
		/// <term>UDP_TABLE_OWNER_MODULE</term>
		/// <term>MIB_UDPTABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>UDP_TABLE_OWNER_PID</term>
		/// <term>MIB_UDPTABLE_OWNER_PID</term>
		/// </item>
		/// </list>
		/// <para>
		/// When the ulAf parameter is set to <c>AF_INET6</c>, the following table indicates the TCP table type to retrieve in the structure
		/// pointed to by the pUdpTable parameter for each possible TableClass value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>TableClass value</term>
		/// <term>pUdpTable structure</term>
		/// </listheader>
		/// <item>
		/// <term>UDP_TABLE_BASIC</term>
		/// <term>MIB_UDP6TABLE</term>
		/// </item>
		/// <item>
		/// <term>UDP_TABLE_OWNER_MODULE</term>
		/// <term>MIB_UDP6TABLE_OWNER_MODULE</term>
		/// </item>
		/// <item>
		/// <term>UDP_TABLE_OWNER_PID</term>
		/// <term>MIB_UDP6TABLE_OWNER_PID</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>GetExtendedUdpTable</c> function when called with the ulAf parameter set to <c>AF_INET6</c> and the TableClass set to
		/// <c>UDP_TABLE_BASIC</c> is only supported on Windows Vista and later.
		/// </para>
		/// <para>
		/// On Windows Server 2003 with Service Pack 1 (SP1) and Windows XP with Service Pack 2 (SP2), the <c>GetExtendedUdpTable</c>
		/// function called with the ulAf parameter set to <c>AF_INET6</c> and the TableClass set to <c>UDP_TABLE_BASIC</c> fails and returns <c>ERROR_NOT_SUPPORTED</c>.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vistaand later, the organization of header files has changed. The various MIB_UDPTABLE
		/// structures are defined in the Udpmib.h header file, not in the Iprtrmib.h header file. Note that the Udpmib.h header file is
		/// automatically included in Iprtrmib.h, which is automatically included in the IpHlpApi.h header file. The Udpmib.h and Iprtrmib.h
		/// header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getextendedudptable DWORD GetExtendedUdpTable( PVOID
		// pUdpTable, PDWORD pdwSize, BOOL bOrder, ULONG ulAf, UDP_TABLE_CLASS TableClass, ULONG Reserved );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "c936d5a0-ca5e-487e-b304-bfd81403ab40")]
		public static extern Win32Error GetExtendedUdpTable(IntPtr pUdpTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder, uint ulAf, UDP_TABLE_CLASS TableClass, uint Reserved = 0);

		/// <summary>The GetExtendedUdpTable function retrieves a table that contains a list of UDP endpoints available to the application.</summary>
		/// <typeparam name="T">The type that is defined as the table associated with the <paramref name="TableClass"/> value.</typeparam>
		/// <param name="TableClass">
		/// The type of the UDP table structure to retrieve. This parameter can be one of the values from the UDP_TABLE_CLASS enumeration.
		/// <para>
		/// The UDP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended UDP information
		/// to retrieve.
		/// </para>
		/// </param>
		/// <param name="ulAf">The version of IP used by the UDP endpoint.</param>
		/// <param name="sorted">
		/// A value that specifies whether the UDP endpoint table should be sorted. If this parameter is set to TRUE, the UDP endpoints in
		/// the table are sorted in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the UDP
		/// endpoints in the table appear in the order in which they were retrieved.
		/// </param>
		/// <returns>The table.</returns>
		public static T GetExtendedUdpTable<T>(UDP_TABLE_CLASS TableClass, ADDRESS_FAMILY ulAf = ADDRESS_FAMILY.AF_INET, bool sorted = false) where T : SafeHandle
		{
			if (!CorrespondingTypeAttribute.CanGet(TableClass, typeof(T)))
			{
				throw new InvalidOperationException("Type mismatch with supplied options.");
			}

			if (ulAf == ADDRESS_FAMILY.AF_INET6 && !typeof(T).Name.Contains("6"))
			{
				throw new InvalidOperationException("Type mismatch with supplied options.");
			}

			if (ulAf == ADDRESS_FAMILY.AF_INET && typeof(T).Name.Contains("6"))
			{
				throw new InvalidOperationException("Type mismatch with supplied options.");
			}

			uint len = 0;
			Win32Error e = GetExtendedUdpTable(IntPtr.Zero, ref len, false, (uint)ulAf, TableClass);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			T mem = (T)Activator.CreateInstance(typeof(T), len);
			GetExtendedUdpTable(mem.DangerousGetHandle(), ref len, sorted, (uint)ulAf, TableClass).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>The <c>GetIfEntry2</c> function retrieves information for the specified interface on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IF_ROW2 structure that, on successful return, receives information for an interface on the local computer. On
		/// input, the <c>InterfaceLuid</c> or the <c>InterfaceIndex</c> member of the <c>MIB_IF_ROW2</c> must be set to the interface for
		/// which to retrieve information.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL parameter is passed in the Row parameter. This
		/// error is also returned if the both the InterfaceLuid and InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter
		/// are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIfEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// On input, at least one of the following members in the MIB_IF_ROW2 structure passed in the Row parameter must be initialized:
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output, the remaining fields of the MIB_IF_ROW2 structure pointed to by the Row parameter are filled in.</para>
		/// <para>Note that the Netioapi.h header file is automatically included in IpHlpApi.h header file, and should never be used directly.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves a interface entry specified on the command line and prints some values from the retrieved
		/// MIB_IF_ROW2 structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getifentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API GetIfEntry2(
		// PMIB_IF_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "da787dae-5e89-4bf2-a9b6-90e727995414")]
		public static extern Win32Error GetIfEntry2(ref MIB_IF_ROW2 Row);

		/// <summary>
		/// <para>
		/// The <c>GetIfEntry2Ex</c> function retrieves the specified level of information for the specified interface on the local computer.
		/// </para>
		/// </summary>
		/// <param name="Level">
		/// <para>
		/// The level of interface information to retrieve. This parameter can be one of the values from the <c>MIB_IF_ENTRY_LEVEL</c>
		/// enumeration type defined in the Netioapi.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MibIfEntryNormal 0</term>
		/// <term>
		/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure pointed to by the Row parameter are returned
		/// from the top of the filter stack.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MibIfEntryNormalWithoutStatistics 2</term>
		/// <term>
		/// The values of state (without statistics) returned in members of the MIB_IF_ROW2 structure pointed to by the Row parameter are
		/// returned from the top of the filter stack.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IF_ROW2 structure that, on successful return, receives information for an interface on the local computer. On
		/// input, the <c>InterfaceLuid</c> or the <c>InterfaceIndex</c> member of the <c>MIB_IF_ROW2</c> must be set to the interface for
		/// which to retrieve information.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL parameter is passed in the Row parameter. This
		/// error is also returned if the both the InterfaceLuid and InterfaceIndex member of the MIB_IF_ROW2 pointed to by the Row parameter
		/// are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfEntry2Ex</c> function retrieves information for a specified interface on a local system and returns this information
		/// in a pointer to a MIB_IF_ROW2 structure. <c>GetIfEntry2Ex</c> is an enhanced version of the GetIfEntry2 function that allows
		/// selecting the level of interface information to retrieve.
		/// </para>
		/// <para>
		/// On input, at least one of the following members in the MIB_IF_ROW2 structure passed in the Row parameter must be initialized:
		/// <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>On output, the remaining fields of the MIB_IF_ROW2 structure pointed to by the Row parameter are filled in.</para>
		/// <para>Note that the Netioapi.h header file is automatically included in IpHlpApi.h header file, and should never be used directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getifentry2ex _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIfEntry2Ex( MIB_IF_ENTRY_LEVEL Level, PMIB_IF_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "98C25986-1B38-4878-B578-3D30394F49E4")]
		public static extern Win32Error GetIfEntry2Ex(MIB_IF_ENTRY_LEVEL Level, ref MIB_IF_ROW2 Row);

		/// <summary>
		/// <para>The <c>GetIfTable</c> function retrieves the MIB-II interface table.</para>
		/// </summary>
		/// <param name="pIfTable">
		/// <para>A pointer to a buffer that receives the interface table as a MIB_IFTABLE structure.</para>
		/// </param>
		/// <param name="pdwSize">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the pIfTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned interface table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// <para>
		/// A Boolean value that specifies whether the returned interface table should be sorted in ascending order by interface index. If
		/// this parameter is <c>TRUE</c>, the table is sorted.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer pointed to by the pIfTable parameter is not large enough. The required size is returned in the DWORD variable pointed
		/// to by the pdwSize parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pdwSize parameter is NULL, or GetIfTable is unable to write to the memory pointed to by the pdwSize parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system in use on the local system.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfTable</c> function enumerates physical interfaces on a local system and returns this information in a
		/// MIB_IFTABLEstructure. The physical interfaces include the software loopback interface.
		/// </para>
		/// <para>
		/// The GetIfTable2 and GetIfTable2Ex functions available on Windows Vista and later are an enhanced version of the <c>GetIfTable</c>
		/// function that enumerate both the physical and logical interfaces on a local system. Logical interfaces include various WAN
		/// Miniport interfaces used for L2TP, PPTP, PPOE, and other tunnel encapsulations.
		/// </para>
		/// <para>
		/// Interfaces are returned in a MIB_IFTABLE structure in the buffer pointed to by the pIfTable parameter. The <c>MIB_IFTABLE</c>
		/// structure contains an interface count and an array of MIB_IFROWstructures for each interface.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IFTABLE structure pointed to by the pIfTable parameter may contain padding for alignment between the
		/// <c>dwNumEntries</c> member and the first MIB_IFROW array entry in the <c>table</c> member of the <c>MIB_IFTABLE</c> structure.
		/// Padding for alignment may also be present between the <c>MIB_IFROW</c> array entries. Any access to a <c>MIB_IFROW</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the interface table and prints the number of entries in the table and some data on each entry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getiftable DWORD GetIfTable( PMIB_IFTABLE pIfTable,
		// PULONG pdwSize, BOOL bOrder );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "6a46c1df-b274-415e-b842-fc1adf6fa206")]
		public static extern Win32Error GetIfTable(IntPtr pIfTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The GetIfTable function retrieves the MIB-II interface table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned interface table should be sorted in ascending order by interface index. If
		/// this parameter is TRUE, the table is sorted.
		/// </param>
		/// <returns>The MIB-II interface table.</returns>
		public static MIB_IFTABLE GetIfTable(bool sorted = false)
		{
			uint len = 0;
			Win32Error e = GetIfTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			MIB_IFTABLE mem = new MIB_IFTABLE(len);
			GetIfTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>The <c>GetIfTable2</c> function retrieves the MIB-II interface table.</para>
		/// </summary>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of interfaces in a MIB_IF_TABLE2 structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfTable2</c> function enumerates the logical and physical interfaces on a local system and returns this information in
		/// a MIB_IF_TABLE2 structure. <c>GetIfTable2</c> is an enhanced version of the <c>GetIfTable</c> function.
		/// </para>
		/// <para>
		/// A similar GetIfTable2Ex function can be used to specify the level of interfaces to return. Calling the <c>GetIfTable2Ex</c>
		/// function with the Level parameter set to <c>MibIfTableNormal</c> retrieves the same results as calling the <c>GetIfTable2</c> function.
		/// </para>
		/// <para>
		/// Interfaces are returned in a MIB_IF_TABLE2 structure in the buffer pointed to by the Table parameter. The <c>MIB_IF_TABLE2</c>
		/// structure contains an interface count and an array of MIB_IF_ROW2 structures for each interface. Memory is allocated by the
		/// <c>GetIfTable2</c> function for the <c>MIB_IF_TABLE2</c> structure and the <c>MIB_IF_ROW2</c> entries in this structure. When
		/// these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IF_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IF_ROW2 array entry in the <c>Table</c> member of the <c>MIB_IF_TABLE2</c> structure.
		/// Padding for alignment may also be present between the <c>MIB_IF_ROW2</c> array entries. Any access to a <c>MIB_IF_ROW2</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getiftable2 _NETIOAPI_SUCCESS_ NETIOAPI_API GetIfTable2(
		// PMIB_IF_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "0153c41c-b02b-4832-87b3-88dc3a9f4ff1")]
		public static extern Win32Error GetIfTable2(out MIB_IF_TABLE2 pIfTable);

		/// <summary>
		/// <para>The <c>GetIfTable2Ex</c> function retrieves the MIB-II interface table.</para>
		/// </summary>
		/// <param name="Level">
		/// <para>
		/// The level of interface information to retrieve. This parameter can be one of the values from the <c>MIB_IF_TABLE_LEVEL</c>
		/// enumeration type defined in the Netioapi.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MibIfTableNormal</term>
		/// <term>
		/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure pointed to by
		/// the Table parameter are returned from the top of the filter stack when this parameter is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MibIfTableRaw</term>
		/// <term>
		/// The values of statistics and state returned in members of the MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure pointed to by
		/// the Table parameter are returned directly for the interface being queried.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a buffer that receives the table of interfaces in a MIB_IF_TABLE2 structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function. This error is returned if an illegal value was passed in the Level parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIfTable2Ex</c> function enumerates the logical and physical interfaces on a local system and returns this information
		/// in a MIB_IF_TABLE2 structure. <c>GetIfTable2Ex</c> is an enhanced version of the <c>GetIfTable</c> function that allows selecting
		/// the level of interface information to retrieve.
		/// </para>
		/// <para>
		/// A similar GetIfTable2 function can also be used to retrieve interfaces. but does not allow specifying the level of interfaces to
		/// return. Calling the <c>GetIfTable2Ex</c> function with the Level parameter set to <c>MibIfTableNormal</c> retrieves the same
		/// results as calling the <c>GetIfTable2</c> function.
		/// </para>
		/// <para>
		/// Interfaces are returned in a MIB_IF_TABLE2 structure in the buffer pointed to by the Table parameter. The <c>MIB_IF_TABLE2</c>
		/// structure contains an interface count and an array of MIB_IF_ROW2 structures for each interface. Memory is allocated by the
		/// GetIfTable2 function for the <c>MIB_IF_TABLE2</c> structure and the <c>MIB_IF_ROW2</c> entries in this structure. When these
		/// returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>
		/// All interfaces including NDIS intermediate driver interfaces and NDIS filter driver interfaces are returned for either of the
		/// possible values for the Level parameter. The setting for the Level parameter affects how statistics and state members of the
		/// MIB_IF_ROW2 structure in the MIB_IF_TABLE2 structure pointed to by the Table parameter for the interface are returned. For
		/// example, a network interface card (NIC) will have a NDIS miniport driver. An NDIS intermediate driver can be installed to
		/// interface between upper-level protocol drivers and NDIS miniport drivers. An NDIS filter driver (LWF) can be attached on top of
		/// the NDIS intermediate driver. Assume that the NIC reports the MediaConnectState member of the <c>MIB_IF_ROW2</c> structure as
		/// <c>MediaConnectStateConnected</c> but NDIS filter driver modifies the state and reports the state as
		/// <c>MediaConnectStateDisconnected</c>. When the interface information is queried with Level parameter set to
		/// <c>MibIfTableNormal</c>, the state at the top of the filter stack, that is <c>MediaConnectStateDisconnected</c> is reported. When
		/// the interface is queried with the Level parameter set to <c>MibIfTableRaw</c>, the state at the interface level directly, that is
		/// <c>MediaConnectStateConnected</c> is returned.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IF_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IF_ROW2 array entry in the <c>Table</c> member of the <c>MIB_IF_TABLE2</c> structure.
		/// Padding for alignment may also be present between the <c>MIB_IF_ROW2</c> array entries. Any access to a <c>MIB_IF_ROW2</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getiftable2ex _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIfTable2Ex( MIB_IF_TABLE_LEVEL Level, PMIB_IF_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "d8663894-50b1-4ca2-a1f4-6ca0970795a7")]
		public static extern Win32Error GetIfTable2Ex(MIB_IF_TABLE_LEVEL Level, out MIB_IF_TABLE2 pIfTable);

		/// <summary>
		/// <para>
		/// The <c>GetInterfaceInfo</c> function obtains the list of the network interface adapters with IPv4 enabled on the local system.
		/// </para>
		/// </summary>
		/// <param name="pIfTable">
		/// <para>
		/// A pointer to a buffer that specifies an IP_INTERFACE_INFO structure that receives the list of adapters. This buffer must be
		/// allocated by the caller.
		/// </para>
		/// </param>
		/// <param name="dwOutBufLen">
		/// <para>
		/// A pointer to a <c>DWORD</c> variable that specifies the size of the buffer pointed to by pIfTable parameter to receive the
		/// IP_INTERFACE_INFO structure. If this size is insufficient to hold the IPv4 interface information, <c>GetInterfaceInfo</c> fills
		/// in this variable with the required size, and returns an error code of <c>ERROR_INSUFFICIENT_BUFFER</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer to receive the IPv4 adapter information is too small. This value is returned if the dwOutBufLen parameter indicates
		/// that the buffer pointed to by the pIfTable parameter is too small to retrieve the IPv4 interface information. The required size
		/// is returned in the DWORD variable pointed to by the dwOutBufLen parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the dwOutBufLen parameter is NULL, or GetInterfaceInfo
		/// is unable to write to the memory pointed to by the dwOutBufLen parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_DATA</term>
		/// <term>
		/// There are no network adapters enabled for IPv4 on the local system. This value is also returned if all network adapters on the
		/// local system are disabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system in use on the local system.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetInterfaceInfo</c> function is specific to network adapters with IPv4 enabled. The function returns an IP_INTERFACE_INFO
		/// structure pointed to by the pIfTable parameter that contains the number of network adapters with IPv4 enabled on the local system
		/// and an array of IP_ADAPTER_INDEX_MAP structures with information on each network adapter with IPv4 enabled. The
		/// <c>IP_INTERFACE_INFO</c> structure returned by <c>GetInterfaceInfo</c> contains at least one <c>IP_ADAPTER_INDEX_MAP</c>
		/// structure even if the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure indicates that no network adapters with
		/// IPv4 are enabled. When the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure returned by
		/// <c>GetInterfaceInfo</c> is zero, the value of the members of the single <c>IP_ADAPTER_INDEX_MAP</c> structure returned in the
		/// <c>IP_INTERFACE_INFO</c> structure is undefined.
		/// </para>
		/// <para>
		/// If the <c>GetInterfaceInfo</c> function is called with too small a buffer to retrieve the IPv4 interface information (the
		/// dwOutBufLen parameter indicates that the buffer pointed to by the pIfTable parameter is too small), the function returns
		/// <c>ERROR_INSUFFICIENT_BUFFER</c>. The required size is returned in the <c>DWORD</c> variable pointed to by the dwOutBufLen parameter.
		/// </para>
		/// <para>
		/// The correct way to use the <c>GetInterfaceInfo</c> function is to call this function twice. In the first call, pass a <c>NULL</c>
		/// pointer in the pIfTable parameter and zero in the variable pointed to by the dwOutBufLen parameter. The call with fail with
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> and the required size for this buffer is returned in the <c>DWORD</c> variable pointed to by the
		/// dwOutBufLen parameter. A buffer can then be allocated of the required size using the value pointed by the dwOutBufLen. Then the
		/// <c>GetInterfaceInfo</c> function can be called a second time with a pointer to this buffer passed in the pIfTable parameter and
		/// the length of the buffer set to the size of this buffer.
		/// </para>
		/// <para>
		/// The GetAdaptersInfo and <c>GetInterfaceInfo</c> functions do not return information about the loopback interface. Information on
		/// the loopback interface is returned by the GetIpAddrTable function.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure returned in the IP_INTERFACE_INFO
		/// structure may be a Unicode string of the GUID for the network interface (the string begins with the '{' character).
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the list of network adapters with IPv4 enabled on the local system and prints various properties
		/// of the first network adapter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getinterfaceinfo DWORD GetInterfaceInfo(
		// PIP_INTERFACE_INFO pIfTable, PULONG dwOutBufLen );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "efc0d175-2c6d-4608-b385-1623a9e0375c")]
		public static extern Win32Error GetInterfaceInfo(IntPtr pIfTable, ref uint dwOutBufLen);

		/// <summary>
		/// The GetInterfaceInfo function obtains the list of the network interface adapters with IPv4 enabled on the local system.
		/// </summary>
		/// <returns>An IP_INTERFACE_INFO structure that receives the list of adapters.</returns>
		public static IP_INTERFACE_INFO GetInterfaceInfo()
		{
			uint len = 0;
			Win32Error e = GetInterfaceInfo(IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			IP_INTERFACE_INFO mem = new IP_INTERFACE_INFO(len);
			GetInterfaceInfo(mem, ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>The <c>GetIpAddrTable</c> function retrieves the interface–to–IPv4 address mapping table.</para>
		/// </summary>
		/// <param name="pIpAddrTable">
		/// <para>A pointer to a buffer that receives the interface–to–IPv4 address mapping table as a MIB_IPADDRTABLE structure.</para>
		/// </param>
		/// <param name="pdwSize">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the pIpAddrTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned mapping table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// <para>
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IPv4 address. If this
		/// parameter is <c>TRUE</c>, the table is sorted.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer pointed to by the pIpAddrTable parameter is not large enough. The required size is returned in the DWORD variable
		/// pointed to by the pdwSize parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pdwSize parameter is NULL, or GetIpAddrTable is unable to write to the memory pointed to by the pdwSize parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system in use on the local system.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIpAddrTable</c> function retrieves the interface–to–IPv4 address mapping table on a local computer and returns this
		/// information in an MIB_IPADDRTABLE structure.
		/// </para>
		/// <para>
		/// The IPv4 addresses returned by the <c>GetIpAddrTable</c> function are affected by the status of the network interfaces on a local
		/// computer. Manually resetting a network interface card (NIC) and certain PnP events may result in an IP address being removed or changed.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, the IPv4 addresses returned by the <c>GetIpAddrTable</c> function are also affected if the
		/// media sensing capability of the TCP/IP stack on a local computer has been disabled by calling the DisableMediaSense function.
		/// When media sensing has been disabled, the <c>GetIpAddrTable</c> function may return IPv4 addresses associated with disconnected
		/// interfaces. These Ipv4 addresses for disconnected interfaces are not valid for use.
		/// </para>
		/// <para>
		/// On Windows Server 2008 and Windows Vista, the IPv4 addresses returned by the <c>GetIpAddrTable</c> function are not affected by
		/// the media sensing capability of the TCP/IP stack on a local computer. The <c>GetIpAddrTable</c> function returns only valid IPv4 addresses.
		/// </para>
		/// <para>
		/// The GetAdaptersAddresses function available on Windows XP can be used to retrieve both IPv6 and IPv4 addresses and interface information.
		/// </para>
		/// <para>
		/// The MIB_IPADDRTABLE structure returned by the <c>GetIpAddrTable</c> function may contain padding for alignment between the
		/// <c>dwNumEntries</c> member and the first MIB_IPADDRROW array entry in the <c>table</c> member. Padding for alignment may also be
		/// present between the <c>MIB_IPADDRROW</c> array entries in the <c>table</c> member. Any access to a <c>MIB_IPADDRROW</c> array
		/// entry should assume padding may exist.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the MIB_IPADDRROW is defined in the Ipmib.h header file not in the Iprtrmib.h header file. Note that the Ipmib.h
		/// header file is automatically included in Iprtrmib.h which is automatically included in the IpHlpApi.h header file. The Ipmib.h
		/// and Iprtrmib.h header files should never be used directly.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the IP address table, then prints some members of the IP address entries in the table.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getipaddrtable DWORD GetIpAddrTable( PMIB_IPADDRTABLE
		// pIpAddrTable, PULONG pdwSize, BOOL bOrder );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "03bf5645-8237-4c78-a921-47315cab1c44")]
		public static extern Win32Error GetIpAddrTable(IntPtr pIpAddrTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The GetIpAddrTable function retrieves the interface–to–IPv4 address mapping table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IPv4 address. If this
		/// parameter is TRUE, the table is sorted.
		/// </param>
		/// <returns>The interface–to–IPv4 address mapping table as a MIB_IPADDRTABLE structure.</returns>
		public static MIB_IPADDRTABLE GetIpAddrTable(bool sorted = false)
		{
			uint len = 0;
			Win32Error e = GetIpAddrTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			MIB_IPADDRTABLE mem = new MIB_IPADDRTABLE(len);
			GetIpAddrTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>The <c>GetIpNetEntry2</c> function retrieves information for a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be
		/// updated with the properties for neighbor IP address.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned if the network interface LUID or interface index specified by
		/// the InterfaceLuid or InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not a value on the local machine.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid neighbor IPv4 or IPv6 address, or
		/// both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned if the network interface specified by the InterfaceLuid or InterfaceIndex member of the
		/// MIB_IPNET_ROW2 structure pointed to by the Row parameter does not match the neighbor IP address and address family specified in
		/// the Address member in the MIB_IPNET_ROW2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 structure pointed to by the Row parameter. This error is also returned if no IPv6
		/// stack is on the local computer and an IPv6 address was specified in the Address member of the MIB_IPNET_ROW2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>GetIpNetEntry2</c> function is used to retrieve a MIB_IPNET_ROW2 structure entry.</para>
		/// <para>
		/// On input, the <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a
		/// valid neighbor IPv4 or IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c>
		/// structure pointed to the Row parameter must be initialized: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>GetIpNetEntry2</c> retrieves the other properties for the neighbor IP address and fills
		/// out the MIB_IPNET_ROW2 structure pointed to by the Row parameter.
		/// </para>
		/// <para>The GetIpNetTable2 function can be called to enumerate the neighbor IP address entries on a local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpNetEntry2( PMIB_IPNET_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "c77e01da-2d5a-4c74-b581-62fa6ee52c9e")]
		public static extern Win32Error GetIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>The <c>GetIpNetTable</c> function retrieves the IPv4 to physical address mapping table.</para>
		/// </summary>
		/// <param name="IpNetTable">
		/// <para>A pointer to a buffer that receives the IPv4 to physical address mapping table as a MIB_IPNETTABLE structure.</para>
		/// </param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the pIpNetTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned mapping table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IP address. If this
		/// parameter is <c>TRUE</c>, the table is sorted.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR or ERROR_NO_DATA.</para>
		/// <para>If the function fails or does not return any data, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer pointed to by the pIpNetTable parameter is not large enough. The required size is returned in the DWORD variable
		/// pointed to by the pdwSize parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the pdwSize parameter is NULL, or GetIpNetTable is
		/// unable to write to the memory pointed to by the pdwSize parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_DATA</term>
		/// <term>
		/// There is no data to return. The IPv4 to physical address mapping table is empty. This return value indicates that the call to the
		/// GetIpNetTable function succeeded, but there was no data to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIpNetTable</c> function enumerates the Address Resolution Protocol (ARP) entries for IPv4 on a local system from the
		/// IPv4 to physical address mapping table and returns this information in a MIB_IPNETTABLE structure.
		/// </para>
		/// <para>
		/// The IPv4 address entries are returned in a MIB_IPNETTABLE structure in the buffer pointed to by the pIpNetTable parameter. The
		/// <c>MIB_IPNETTABLE</c> structure contains a count of ARP entries and an array of MIB_IPNETROW structures for each IPv4 address entry.
		/// </para>
		/// <para>
		/// Note that the returned MIB_IPNETTABLE structure pointed to by the pIpNetTable parameter may contain padding for alignment between
		/// the <c>dwNumEntries</c> member and the first MIB_IPNETROW array entry in the <c>table</c> member of the <c>MIB_IPNETTABLE</c>
		/// structure. Padding for alignment may also be present between the <c>MIB_IPNETROW</c> array entries. Any access to a
		/// <c>MIB_IPNETROW</c> array entry should assume padding may exist.
		/// </para>
		/// <para>
		/// on Windows Vista and later, the GetIpNetTable2 function can be used to retrieve the neighbor IP addresses for both IPv6 and IPv4.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getipnettable ULONG GetIpNetTable( PMIB_IPNETTABLE
		// IpNetTable, PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "01bcf86e-5fcc-4ce9-bb89-02d393e75d1d")]
		public static extern Win32Error GetIpNetTable(IntPtr pIpNetTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The GetIpNetTable function retrieves the IPv4 to physical address mapping table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IP address. If this
		/// parameter is TRUE, the table is sorted.
		/// </param>
		/// <returns>The IPv4 to physical address mapping table as a MIB_IPNETTABLE structure.</returns>
		public static MIB_IPNETTABLE GetIpNetTable(bool sorted = false)
		{
			uint len = 0;
			Win32Error e = GetIpNetTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			MIB_IPNETTABLE mem = new MIB_IPNETTABLE(len);
			GetIpNetTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>The <c>GetIpNetTable2</c> function retrieves the IP neighbor table on the local computer.</para>
		/// </summary>
		/// <param name="Family">
		/// <para>The address family to retrieve.</para>
		/// <para>
		/// Possible values for the address family are listed in the Winsock2.h header file. Note that the values for the AF_ address family
		/// and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and possible values for
		/// this member are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h,
		/// and should never be used directly.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c>, <c>AF_INET6</c>, and <c>AF_UNSPEC</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>
		/// The address family is unspecified. When this parameter is specified, this function returns the neighbor IP address table
		/// containing both IPv4 and IPv6 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns the neighbor IP
		/// address table containing only IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns the neighbor IP
		/// address table containing only IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Table">
		/// <para>A pointer to a MIB_IPNET_TABLE2 structure that contains a table of neighbor IP address entries on the local computer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR or ERROR_NOT_FOUND.</para>
		/// <para>If the function fails or returns no data, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Table parameter or the
		/// Family parameter was not specified as AF_INET, AF_INET6, or AF_UNSPEC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory resources are available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// No neighbor IP address entries as specified in the Family parameter were found. This return value indicates that the call to the
		/// GetIpNetTable2 function succeeded, but there was no data to return. This can occur when AF_INET is specified in the Family
		/// parameter and there are no ARP entries to return.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and AF_INET was specified in the
		/// Family parameter. This error is also returned if no IPv6 stack is on the local computer and AF_INET6 was specified in the Family
		/// parameter. This error is also returned on versions of Windows where this function is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpNetTable2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetIpNetTable2</c> function enumerates the neighbor IP addresses on a local system and returns this information in a
		/// MIB_IPNET_TABLE2 structure.
		/// </para>
		/// <para>
		/// The neighbor IP address entries are returned in a MIB_IPNET_TABLE2 structure in the buffer pointed to by the Table parameter. The
		/// <c>MIB_IPNET_TABLE2</c> structure contains a neighbor IP address entry count and an array of MIB_IPNET_ROW2 structures for each
		/// neighbor IP address entry. When these returned structures are no longer required, free the memory by calling the FreeMibTable.
		/// </para>
		/// <para>The Family parameter must be initialized to either <c>AF_INET</c>, <c>AF_INET6</c>, or <c>AF_UNSPEC</c>.</para>
		/// <para>
		/// Note that the returned MIB_IPNET_TABLE2 structure pointed to by the Table parameter may contain padding for alignment between the
		/// <c>NumEntries</c> member and the first MIB_IPNET_ROW2 array entry in the <c>Table</c> member of the <c>MIB_IPNET_TABLE2</c>
		/// structure. Padding for alignment may also be present between the <c>MIB_IPNET_ROW2</c> array entries. Any access to a
		/// <c>MIB_IPNET_ROW2</c> array entry should assume padding may exist.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the IP neighbor table, then prints the values for IP neighbor row entries in the table.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-getipnettable2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// GetIpNetTable2( ADDRESS_FAMILY Family, PMIB_IPNET_TABLE2 *Table );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "6c45d735-9a07-41ca-8d8a-919f32c98a3c")]
		public static extern Win32Error GetIpNetTable2(ADDRESS_FAMILY Family, out MIB_IPNET_TABLE2 Table);

		/// <summary>
		/// <para>The <c>GetNetworkParams</c> function retrieves network parameters for the local computer.</para>
		/// </summary>
		/// <param name="pFixedInfo">
		/// <para>
		/// A pointer to a buffer that contains a FIXED_INFO structure that receives the network parameters for the local computer, if the
		/// function was successful. This buffer must be allocated by the caller prior to calling the <c>GetNetworkParams</c> function.
		/// </para>
		/// </param>
		/// <param name="pOutBufLen">
		/// <para>
		/// A pointer to a <c>ULONG</c> variable that specifies the size of the FIXED_INFO structure. If this size is insufficient to hold
		/// the information, <c>GetNetworkParams</c> fills in this variable with the required size, and returns an error code of <c>ERROR_BUFFER_OVERFLOW</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BUFFER_OVERFLOW</term>
		/// <term>
		/// The buffer to receive the network parameter information is too small. This value is returned if the pOutBufLen parameter is too
		/// small to hold the network parameter information or the pFixedInfo parameter was a NULL pointer. When this error code is returned,
		/// the pOutBufLen parameter points to the required buffer size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the pOutBufLen parameter is a NULL pointer, the
		/// calling process does not have read/write access to the memory pointed to by pOutBufLen, or the calling process does not have
		/// write access to the memory pointed to by the pFixedInfo parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_DATA</term>
		/// <term>No network parameter information exists for the local computer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The GetNetworkParams function is not supported by the operating system running on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>If the function fails, use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetNetworkParams</c> function is used to retrieve network parameters for the local computer. Network parameters are
		/// returned in a FIXED_INFOstructure. The memory for the <c>FIXED_INFO</c> structure must be allocated by the application. It is the
		/// responsibility of the application to free this memory when it is no longer needed.
		/// </para>
		/// <para>
		/// In the Microsoft Windows Software Development Kit (SDK), the FIXED_INFO_WIN2KSP1 structure is defined. When compiling an
		/// application if the target platform is Windows 2000 with Service Pack 1 (SP1) and later (, , or ), the <c>FIXED_INFO_WIN2KSP1</c>
		/// struct is typedefed to the <c>FIXED_INFO</c> structure. When compiling an application if the target platform is not Windows 2000
		/// with SP1 and later, the <c>FIXED_INFO</c> structure is undefined.
		/// </para>
		/// <para>
		/// The <c>GetNetworkParams</c> function and the FIXED_INFO structure are supported on Windows 98and later. But to build an
		/// application for a target platform earlier than Windows 2000 with Service Pack 1 (SP1), an earlier version of the Platform
		/// Software Development Kit (SDK) must be used.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the network parameters for the local computer and prints information from the returned data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getnetworkparams DWORD GetNetworkParams( PFIXED_INFO
		// pFixedInfo, PULONG pOutBufLen );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5f54a120-5db9-4b8d-a281-1112be0042d6")]
		public static extern Win32Error GetNetworkParams(IntPtr pFixedInfo, ref uint pBufOutLen);

		/// <summary>The GetNetworkParams function retrieves network parameters for the local computer.</summary>
		/// <returns>A <see cref="FIXED_INFO"/> structure that receives the network parameters for the local computer.</returns>
		public static FIXED_INFO GetNetworkParams()
		{
			SafeCoTaskMemHandle mem = SafeCoTaskMemHandle.CreateFromStructure<FIXED_INFO>();
			uint len = (uint)mem.Size;
			Win32Error e = GetNetworkParams((IntPtr)mem, ref len);
			if (e == Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				mem.Size = (int)len;
				GetNetworkParams((IntPtr)mem, ref len).ThrowIfFailed();
			}
			else
			{
				e.ThrowIfFailed();
			}

			return mem.ToStructure<FIXED_INFO>();
		}

		/// <summary>
		/// <para>The <c>GetPerAdapterInfo</c> function retrieves information about the adapter corresponding to the specified interface.</para>
		/// </summary>
		/// <param name="IfIndex">
		/// <para>
		/// Index of an interface. The <c>GetPerAdapterInfo</c> function retrieves information for the adapter corresponding to this interface.
		/// </para>
		/// </param>
		/// <param name="pPerAdapterInfo">
		/// <para>Pointer to an IP_PER_ADAPTER_INFO structure that receives information about the adapter.</para>
		/// </param>
		/// <param name="pOutBufLen">
		/// <para>
		/// Pointer to a <c>ULONG</c> variable that specifies the size of the IP_PER_ADAPTER_INFO structure. If this size is insufficient to
		/// hold the information, <c>GetPerAdapterInfo</c> fills in this variable with the required size, and returns an error code of ERROR_BUFFER_OVERFLOW.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BUFFER_OVERFLOW</term>
		/// <term>
		/// The buffer size indicated by the pOutBufLen parameter is too small to hold the adapter information. The pOutBufLen parameter
		/// points to the required size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// The pOutBufLen parameter is NULL, or the calling process does not have read/write access to the memory pointed to by pOutBufLen,
		/// or the calling process does not have write access to the memory pointed to by the pAdapterInfo parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>GetPerAdapterInfo is not supported by the operating system running on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>If the function fails, use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An adapter index may change when the adapter is disabled and then enabled, or under other circumstances, and should not be
		/// considered persistent.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getperadapterinfo DWORD GetPerAdapterInfo( ULONG
		// IfIndex, PIP_PER_ADAPTER_INFO pPerAdapterInfo, PULONG pOutBufLen );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "fc1ae7e4-f856-4b48-8ab4-56cd511ed161")]
		public static extern Win32Error GetPerAdapterInfo(uint IfIndex, IntPtr pPerAdapterInfo, ref uint pOutBufLen);

		/// <summary>The GetPerAdapterInfo function retrieves information about the adapter corresponding to the specified interface.</summary>
		/// <param name="IfIndex">
		/// Index of an interface. The GetPerAdapterInfo function retrieves information for the adapter corresponding to this interface.
		/// </param>
		/// <returns>A PIP_PER_ADAPTER_INFO structure that receives information about the adapter.</returns>
		public static PIP_PER_ADAPTER_INFO GetPerAdapterInfo(uint IfIndex)
		{
			uint len = 0;
			Win32Error e = GetPerAdapterInfo(IfIndex, IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				e.ThrowIfFailed();
			}

			PIP_PER_ADAPTER_INFO mem = new PIP_PER_ADAPTER_INFO(len);
			GetPerAdapterInfo(IfIndex, mem, ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>
		/// The <c>GetUniDirectionalAdapterInfo</c> function retrieves information about the unidirectional adapters installed on the local
		/// computer. A unidirectional adapter is an adapter that can receive datagrams, but not transmit them.
		/// </para>
		/// </summary>
		/// <param name="pIPIfInfo">
		/// <para>
		/// Pointer to an IP_UNIDIRECTIONAL_ADAPTER_ADDRESS structure that receives information about the unidirectional adapters installed
		/// on the local computer.
		/// </para>
		/// </param>
		/// <param name="dwOutBufLen">
		/// <para>Pointer to a <c>ULONG</c> variable that receives the size of the structure pointed to by the pIPIfInfo parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getunidirectionaladapterinfo DWORD
		// GetUniDirectionalAdapterInfo( PIP_UNIDIRECTIONAL_ADAPTER_ADDRESS pIPIfInfo, PULONG dwOutBufLen );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "32aa3a8e-ae74-4da9-bc8d-b28e270d9702")]
		public static extern Win32Error GetUniDirectionalAdapterInfo(IntPtr pIPIfInfo, ref uint dwOutBufLen);

		/// <summary>
		/// The GetUniDirectionalAdapterInfo function retrieves information about the unidirectional adapters installed on the local
		/// computer. A unidirectional adapter is an adapter that can receive datagrams, but not transmit them.
		/// </summary>
		/// <returns>
		/// An IP_UNIDIRECTIONAL_ADAPTER_ADDRESS structure that receives information about the unidirectional adapters installed on the local computer.
		/// </returns>
		public static IP_UNIDIRECTIONAL_ADAPTER_ADDRESS GetUniDirectionalAdapterInfo()
		{
			uint len = 0;
			Win32Error e = GetUniDirectionalAdapterInfo(IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_MORE_DATA)
			{
				e.ThrowIfFailed();
			}

			IP_UNIDIRECTIONAL_ADAPTER_ADDRESS mem = new IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(len);
			GetUniDirectionalAdapterInfo(mem, ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// <para>
		/// The <c>IpReleaseAddress</c> function releases an IPv4 address previously obtained through the Dynamic Host Configuration Protocol (DHCP).
		/// </para>
		/// </summary>
		/// <param name="AdapterInfo">
		/// <para>A pointer to an IP_ADAPTER_INDEX_MAP structure that specifies the adapter associated with the IPv4 address to release.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters is invalid. This error is returned if the AdapterInfo parameter is NULL or if the Name member of the
		/// PIP_ADAPTER_INDEX_MAP structure pointed to by the AdapterInfo parameter is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_PROC_NOT_FOUND</term>
		/// <term>An exception occurred during the request to DHCP for the release of the IPv4 address.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IpReleaseAddress</c> function is specific to IPv4 and releases only an IPv4 address previously obtained through the
		/// Dynamic Host Configuration Protocol (DHCP). The <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure pointed to by the
		/// AdapterInfo parameter is the only member used to determine the DHCP address to release.
		/// </para>
		/// <para>
		/// An array of IP_ADAPTER_INDEX_MAP structures is returned in the IP_INTERFACE_INFO structure by the GetInterfaceInfo function. The
		/// <c>IP_INTERFACE_INFO</c> structure returned by <c>GetInterfaceInfo</c> contains at least one <c>IP_ADAPTER_INDEX_MAP</c>
		/// structure even if the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure indicates that no network adapters with
		/// IPv4 are enabled. When the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure returned by
		/// <c>GetInterfaceInfo</c> is zero, the value of the members of the single <c>IP_ADAPTER_INDEX_MAP</c> structure returned in the
		/// <c>IP_INTERFACE_INFO</c> structure is undefined.
		/// </para>
		/// <para>
		/// If the <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure pointed to by the AdapterInfo parameter is <c>NULL</c>, the
		/// <c>IpReleaseAddress</c> function returns <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// <para>
		/// There are no functions available for releasing or renewing an IPv6 address. This can only be done by executing the Ipconfig command:
		/// </para>
		/// <para><c>ipconfig /release6</c></para>
		/// <para><c>ipconfig /renew6</c></para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the list of network adapters with IPv4 enabled on the local system, then releases and renews the
		/// IPv4 address for the first adapter in the list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-ipreleaseaddress DWORD IpReleaseAddress(
		// PIP_ADAPTER_INDEX_MAP AdapterInfo );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "d937ea44-1ca3-49e0-913d-fb77888d05fc")]
		public static extern Win32Error IpReleaseAddress(ref IP_ADAPTER_INDEX_MAP AdapterInfo);

		/// <summary>
		/// <para>
		/// The <c>IpRenewAddress</c> function renews a lease on an IPv4 address previously obtained through Dynamic Host Configuration
		/// Protocol (DHCP).
		/// </para>
		/// </summary>
		/// <param name="AdapterInfo">
		/// <para>A pointer to an IP_ADAPTER_INDEX_MAP structure that specifies the adapter associated with the IP address to renew.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters is invalid. This error is returned if the AdapterInfo parameter is NULL or if the Name member of the
		/// PIP_ADAPTER_INDEX_MAP structure pointed to by the AdapterInfo parameter is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_PROC_NOT_FOUND</term>
		/// <term>An exception occurred during the request to DHCP for the renewal of the IPv4 address.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IpRenewAddress</c> function is specific to IPv4 and renews only an IPv4 address previously obtained through the Dynamic
		/// Host Configuration Protocol (DHCP). The <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure pointed to by the AdapterInfo
		/// parameter is the only member used to determine the DHCP address to renew.
		/// </para>
		/// <para>
		/// An array of IP_ADAPTER_INDEX_MAP structures are returned in the IP_INTERFACE_INFO structure by the GetInterfaceInfo function. The
		/// <c>IP_INTERFACE_INFO</c> structure returned by <c>GetInterfaceInfo</c> contains at least one <c>IP_ADAPTER_INDEX_MAP</c>
		/// structure even if the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure indicates that no network adapters with
		/// IPv4 are enabled. When the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure returned by
		/// <c>GetInterfaceInfo</c> is zero, the value of the members of the single <c>IP_ADAPTER_INDEX_MAP</c> structure returned in the
		/// <c>IP_INTERFACE_INFO</c> structure is undefined.
		/// </para>
		/// <para>
		/// If the <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure pointed to by the AdapterInfo parameter is <c>NULL</c>, the
		/// <c>IpRenewAddress</c> function returns <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// <para>
		/// There are no functions available for releasing or renewing an IPv6 address. This can only be done by executing the Ipconfig command:
		/// </para>
		/// <para><c>ipconfig /release6</c></para>
		/// <para><c>ipconfig /renew6</c></para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the list of network adapters with IPv4 enabled on the local system, then releases and renews the
		/// IPv4 address for the first adapter in the list.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-iprenewaddress DWORD IpRenewAddress(
		// PIP_ADAPTER_INDEX_MAP AdapterInfo );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "25b1bf9f-3ae1-453c-baae-5f70ae46cd24")]
		public static extern Win32Error IpRenewAddress(ref IP_ADAPTER_INDEX_MAP AdapterInfo);

		/// <summary>
		/// <para>
		/// The <c>NotifyAddrChange</c> function causes a notification to be sent to the caller whenever a change occurs in the table that
		/// maps IPv4 addresses to interfaces.
		/// </para>
		/// </summary>
		/// <param name="Handle">
		/// <para>
		/// A pointer to a <c>HANDLE</c> variable that receives a file handle for use in a subsequent call to the GetOverlappedResult function.
		/// </para>
		/// <para><c>Warning</c> Do not close this handle, and do not associate it with a completion port.</para>
		/// </param>
		/// <param name="overlapped">
		/// <para>A pointer to an OVERLAPPED structure that notifies the caller of any changes in the table that maps IP addresses to interfaces.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is NO_ERROR if the caller specifies <c>NULL</c> for the Handle and overlapped
		/// parameters. If the caller specifies non- <c>NULL</c> parameters, the return value for success is ERROR_IO_PENDING.
		/// </para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_CANCELLED</term>
		/// <term>The context is being deregistered, so the call was canceled immediately.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed. This error is returned if the both the Handle and overlapped parameters are not NULL, but the
		/// memory specified by the input parameters cannot be written by the calling process. This error is also returned if the client
		/// already has made a change notification request, so this duplicate request will fail.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// This error is returned on versions of Windows where this function is not supported such as Windows 98/95 and Windows NT 4.0.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The</para>
		/// <para><c>NotifyAddrChange</c> function may be called in two ways:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Synchronous method</term>
		/// </item>
		/// <item>
		/// <term>Asynchronous method</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the caller specifies <c>NULL</c> for the Handle and overlapped parameters, the call to <c>NotifyAddrChange</c> is synchronous
		/// and will block until an IP address change occurs. In this case if a change occurs, the <c>NotifyAddrChange</c> function completes
		/// to indicate that a change has occurred.
		/// </para>
		/// <para>
		/// If the <c>NotifyAddrChange</c> function is called synchronously, a notification will be sent on the next IPv4 address change
		/// until the application terminates.
		/// </para>
		/// <para>
		/// If the caller specifies a handle variable and an OVERLAPPED structure, then the <c>NotifyAddrChange</c> function call is
		/// asynchronous and the caller can use the returned handle with the <c>OVERLAPPED</c> structure to receive asynchronous notification
		/// of IPv4 address changes using the GetOverlappedResult function. See the following topics for information about using the handle
		/// and <c>OVERLAPPED</c> structure to receive notifications:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Synchronization and Overlapped Input and Output</term>
		/// </item>
		/// <item>
		/// <term>GetOverlappedResult</term>
		/// </item>
		/// </list>
		/// <para>
		/// The CancelIPChangeNotify function cancels notification of IPv4 address and route changes previously requested with successful
		/// calls to the <c>NotifyAddrChange</c> or NotifyRouteChange functions.
		/// </para>
		/// <para>
		/// Once an application has been notified of a change, the application can then call the GetIpAddrTable or GetAdaptersAddresses
		/// function to retrieve the table of IPv4 addresses to determine what has changed. If the application is notified and requires
		/// notification for the next change, then the <c>NotifyAddrChange</c> function must be called again.
		/// </para>
		/// <para>
		/// If the <c>NotifyAddrChange</c> function is called asynchronously, a notification will be sent on the next IPv4 address change
		/// until either the application cancels the notification by calling the CancelIPChangeNotify function or the application terminates.
		/// If the application terminates, the system will automatically cancel the registration for the notification. It is still
		/// recommended that an application explicitly cancel any notification before it terminates.
		/// </para>
		/// <para>Any registration for a notification does not persist across a system shut down or reboot.</para>
		/// <para>
		/// On Windows Vista and later, the NotifyIpInterfaceChange function can be used to register to be notified for changes to IPv4 and
		/// IPv6 interfaces on the local computer.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example waits for a change to occur in the table that maps IP addresses to interfaces.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-notifyaddrchange DWORD NotifyAddrChange( PHANDLE Handle,
		// LPOVERLAPPED overlapped );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "22ac3b5b-452c-454b-8fbd-47a873675c6c")]
		public static extern unsafe Win32Error NotifyAddrChange(out IntPtr Handle, System.Threading.NativeOverlapped* overlapped);

		/// <summary>
		/// <para>
		/// The <c>NotifyRouteChange</c> function causes a notification to be sent to the caller whenever a change occurs in the IPv4 routing table.
		/// </para>
		/// </summary>
		/// <param name="Handle">
		/// <para>A pointer to a <c>HANDLE</c> variable that receives a handle to use in asynchronous notification.</para>
		/// </param>
		/// <param name="overlapped">
		/// <para>A pointer to an OVERLAPPED structure that notifies the caller of any changes in the routing table.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is NO_ERROR if the caller specifies <c>NULL</c> for the Handle and overlapped
		/// parameters. If the caller specifies non- <c>NULL</c> parameters, the return value for success is ERROR_IO_PENDING. If the
		/// function fails, use FormatMessage to obtain the message string for the returned error.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_CANCELLED</term>
		/// <term>The context is being deregistered, so the call was canceled immediately.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed. This error is returned if the both the Handle and overlapped parameters are not NULL, but the
		/// memory specified by the input parameters cannot be written by the calling process. This error is also returned if the client
		/// already has made a change notification request, so this duplicate request will fail.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// This error is returned on versions of Windows where this function is not supported such as Windows 98/95 and Windows NT 4.0.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The</para>
		/// <para><c>NotifyRouteChange</c> function may be called in two ways:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Synchronous method</term>
		/// </item>
		/// <item>
		/// <term>Asynchronous method</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the caller specifies <c>NULL</c> for the Handle and overlapped parameters, the call to <c>NotifyRouteChange</c> is synchronous
		/// and will block until an IPv4 routing table change occurs. In this case if a change occurs, the <c>NotifyRouteChange</c> function
		/// completes to indicate that a change has occurred.
		/// </para>
		/// <para>
		/// If the <c>NotifyRouteChange</c> function is called synchronously, a notification will be sent on the next IPv4 routing change
		/// until the application terminates.
		/// </para>
		/// <para>
		/// If the caller specifies a handle variable and an OVERLAPPED structure, the caller can use the returned handle with the
		/// <c>OVERLAPPED</c> structure to receive asynchronous notification of IPv4 routing table changes. See the following topics for
		/// information about using the handle and <c>OVERLAPPED</c> structure to receive notifications:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Synchronization and Overlapped Input and Output</term>
		/// </item>
		/// <item>
		/// <term>GetQueuedCompletionStatus</term>
		/// </item>
		/// <item>
		/// <term>I/O Completion Ports</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the application receives a notification and requires notification for the next change, then the <c>NotifyRouteChange</c>
		/// function must be called again.
		/// </para>
		/// <para>
		/// The CancelIPChangeNotify function cancels notification of IP address and route changes previously requested with successful calls
		/// to the NotifyAddrChange or <c>NotifyRouteChange</c> functions.
		/// </para>
		/// <para>
		/// Once an application has been notified of a change, the application can then call the GetIpForwardTable or GetIpForwardTable2
		/// function to retrieve the IPv4 routing table to determine what has changed. If the application is notified and requires
		/// notification for the next change, then the <c>NotifyRouteChange</c> function must be called again.
		/// </para>
		/// <para>
		/// If the <c>NotifyRouteChange</c> function is called asynchronously, a notification will be sent on the next IPv4 route change
		/// until either the application cancels the notification by calling the CancelIPChangeNotify function or the application terminates.
		/// If the application terminates, the system will automatically cancel the registration for the notification. It is still
		/// recommended that an application explicitly cancel any notification before it terminates.
		/// </para>
		/// <para>Any registration for a notification does not persist across a system shut down or reboot.</para>
		/// <para>
		/// On Windows Vista and later, the NotifyRouteChange2 function can be used to register to be notified for changes to the IPv6
		/// routing table on the local computer.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example waits for a change to occur in the IP routing table.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-notifyroutechange DWORD NotifyRouteChange( PHANDLE
		// Handle, LPOVERLAPPED overlapped );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "39f2ec4d-131a-4a0a-9740-0d96aaea2dc7")]
		public static extern unsafe Win32Error NotifyRouteChange(out IntPtr Handle, System.Threading.NativeOverlapped* overlapped);

		/// <summary>Converts a 6 byte Physical Address (MAC) to string.</summary>
		/// <param name="physAddr">The physical address that must have a minimum of 6 values.</param>
		/// <returns>Dashed hex value string representation of a Physical Address (MAC).</returns>
		public static string PhysicalAddressToString(byte[] physAddr)
		{
			return $"{physAddr[0]:X}-{physAddr[1]:X}-{physAddr[2]:X}-{physAddr[3]:X}-{physAddr[4]:X}-{physAddr[5]:X}";
		}

		/// <summary>
		/// <para>The <c>ResolveIpNetEntry2</c> function resolves the physical address for a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be
		/// updated with the properties for neighbor IP address.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>
		/// A pointer to a an optional source IP address used to select the interface to send the requests on for the neighbor IP address entry.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_NET_NAME</term>
		/// <term>The network name cannot be found. This error is returned if the network with the neighbor IP address is unreachable.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid IPv4 or IPv6 address, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified. This error is
		/// also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter or no IPv6 stack is on the local computer and an IPv6
		/// address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ResolveIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>ResolveIpNetEntry2</c> function is used to resolve the physical address for a neighbor IP address entry on a local
		/// computer. This function flushes any existing neighbor entry that matches the IP address on the interface and then resolves the
		/// physical address (MAC) address by sending ARP requests for an IPv4 address or neighbor solicitation requests for an IPv6 address.
		/// If the SourceAddress parameter is specified, the <c>ResolveIpNetEntry2</c> function will select the interface with this source IP
		/// address to send the requests on. If the SourceAddress parameter is not specified (NULL was passed in this parameter), the
		/// <c>ResolveIpNetEntry2</c> function will automatically select the best interface to send the requests on.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid IPv4 or
		/// IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the
		/// Row parameter must be initialized to the interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// If the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2 pointed to by the Row parameter is a duplicate of an
		/// existing neighbor IP address on the interface, the <c>ResolveIpNetEntry2</c> function will flush the existing entry before
		/// resolving the IP address.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>ResolveIpNetEntry2</c> retrieves the other properties for the neighbor IP address and
		/// fills out the MIB_IPNET_ROW2 structure pointed to by the Row parameter. The <c>PhysicalAddress</c> and
		/// <c>PhysicalAddressLength</c> members in the <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter will be initialized
		/// to a valid physical address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-resolveipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// ResolveIpNetEntry2( PMIB_IPNET_ROW2 Row, CONST SOCKADDR_INET *SourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "37f9dc58-362d-413e-a593-4dda52fb7d8b")]
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, IntPtr SourceAddress = default(IntPtr));

		/// <summary>
		/// <para>The <c>ResolveIpNetEntry2</c> function resolves the physical address for a neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>
		/// A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be
		/// updated with the properties for neighbor IP address.
		/// </para>
		/// </param>
		/// <param name="SourceAddress">
		/// <para>
		/// A pointer to a an optional source IP address used to select the interface to send the requests on for the neighbor IP address entry.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_NET_NAME</term>
		/// <term>The network name cannot be found. This error is returned if the network with the neighbor IP address is unreachable.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid IPv4 or IPv6 address, or both the
		/// InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the Row parameter were unspecified. This error is
		/// also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter or no IPv6 stack is on the local computer and an IPv6
		/// address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ResolveIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>ResolveIpNetEntry2</c> function is used to resolve the physical address for a neighbor IP address entry on a local
		/// computer. This function flushes any existing neighbor entry that matches the IP address on the interface and then resolves the
		/// physical address (MAC) address by sending ARP requests for an IPv4 address or neighbor solicitation requests for an IPv6 address.
		/// If the SourceAddress parameter is specified, the <c>ResolveIpNetEntry2</c> function will select the interface with this source IP
		/// address to send the requests on. If the SourceAddress parameter is not specified (NULL was passed in this parameter), the
		/// <c>ResolveIpNetEntry2</c> function will automatically select the best interface to send the requests on.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid IPv4 or
		/// IPv6 address and family. In addition, at least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the
		/// Row parameter must be initialized to the interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// If the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2 pointed to by the Row parameter is a duplicate of an
		/// existing neighbor IP address on the interface, the <c>ResolveIpNetEntry2</c> function will flush the existing entry before
		/// resolving the IP address.
		/// </para>
		/// <para>
		/// On output when the call is successful, <c>ResolveIpNetEntry2</c> retrieves the other properties for the neighbor IP address and
		/// fills out the MIB_IPNET_ROW2 structure pointed to by the Row parameter. The <c>PhysicalAddress</c> and
		/// <c>PhysicalAddressLength</c> members in the <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter will be initialized
		/// to a valid physical address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-resolveipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// ResolveIpNetEntry2( PMIB_IPNET_ROW2 Row, CONST SOCKADDR_INET *SourceAddress );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "37f9dc58-362d-413e-a593-4dda52fb7d8b")]
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, ref SOCKADDR_INET SourceAddress);

		/// <summary>
		/// <para>
		/// The <c>SendARP</c> function sends an Address Resolution Protocol (ARP) request to obtain the physical address that corresponds to
		/// the specified destination IPv4 address.
		/// </para>
		/// </summary>
		/// <param name="DestIP">
		/// <para>
		/// The destination IPv4 address, in the form of an IPAddr structure. The ARP request attempts to obtain the physical address that
		/// corresponds to this IPv4 address.
		/// </para>
		/// </param>
		/// <param name="SrcIP">
		/// <para>
		/// The source IPv4 address of the sender, in the form of an IPAddr structure. This parameter is optional and is used to select the
		/// interface to send the request on for the ARP entry. The caller may specify zero corresponding to the <c>INADDR_ANY</c> IPv4
		/// address for this parameter.
		/// </para>
		/// </param>
		/// <param name="pMacAddr">
		/// <para>
		/// A pointer to an array of <c>ULONG</c> variables. This array must have at least two <c>ULONG</c> elements to hold an Ethernet or
		/// token ring physical address. The first six bytes of this array receive the physical address that corresponds to the IPv4 address
		/// specified by the DestIP parameter.
		/// </para>
		/// </param>
		/// <param name="PhyAddrLen">
		/// <para>
		/// On input, a pointer to a <c>ULONG</c> value that specifies the maximum buffer size, in bytes, the application has set aside to
		/// receive the physical address or MAC address. The buffer size should be at least 6 bytes for an Ethernet or token ring physical address
		/// </para>
		/// <para>The buffer to receive the physical address is pointed to by the pMacAddr parameter.</para>
		/// <para>
		/// On successful output, this parameter points to a value that specifies the number of bytes written to the buffer pointed to by the pMacAddr.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_BAD_NET_NAME</term>
		/// <term>
		/// The network name cannot be found. This error is returned on Windows Vista and later when an ARP reply to the SendARP request was
		/// not received. This error occurs if the destination IPv4 address could not be reached because it is not on the same subnet or the
		/// destination computer is not operating.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_BUFFER_OVERFLOW</term>
		/// <term>
		/// The file name is too long. This error is returned on Windows Vista if the ULONG value pointed to by the PhyAddrLen parameter is
		/// less than 6, the size required to store a complete physical address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_GEN_FAILURE</term>
		/// <term>
		/// A device attached to the system is not functioning. This error is returned on Windows Server 2003 and earlier when an ARP reply
		/// to the SendARP request was not received. This error can occur if destination IPv4 address could not be reached because it is not
		/// on the same subnet or the destination computer is not operating.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// One of the parameters is invalid. This error is returned on Windows Server 2003 and earlier if either the pMacAddr or PhyAddrLen
		/// parameter is a NULL pointer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned on Windows Server 2003 and earlier if
		/// the ULONG value pointed to by the PhyAddrLen parameter is zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// Element not found. This error is returned on Windows Vista if the the SrcIp parameter does not specify a source IPv4 address on
		/// an interface on the local computer or the INADDR_ANY IP address (an IPv4 address of 0.0.0.0).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The SendARP function is not supported by the operating system running on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>If the function fails, use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SendARP</c> function is used to request the physical hardware address (sometimes referred to as the MAC address) that
		/// corresponds to a specified destination IPv4 address. If the information requested is not in the ARP table on the local computer,
		/// then the <c>SendARP</c> function will cause an ARP request to be sent to obtain the physical address. If the function is
		/// successful, the physical address that corresponds to the specified destination IPv4 address is returned in the array pointed to
		/// by the pMacAddr parameter.
		/// </para>
		/// <para>
		/// The physical address of an IPv4 address is only available if the destination IPv4 address is on the local subnet (the IPv4
		/// address can be reached directly without going through any routers). The <c>SendARP</c> function will fail if the destination IPv4
		/// address is not on the local subnet.
		/// </para>
		/// <para>
		/// If the <c>SendARP</c> function is successful on Windows Vista and later, the ARP table on the local computer is updated with the
		/// results. If the <c>SendARP</c> function is successful on Windows Server 2003 and earlier, the ARP table on the local computer is
		/// not affected.
		/// </para>
		/// <para>
		/// The <c>SendARP</c> function on Windows Vista and later returns different error return values than the <c>SendARP</c> function on
		/// Windows Server 2003 and earlier.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a <c>NULL</c> pointer passed as the pMacAddr or PhyAddrLen parameter to the <c>SendARP</c> function
		/// causes an access violation and the application is terminated. If an error occurs on Windows Vista and later and
		/// <c>ERROR_BAD_NET_NAME</c>, <c>ERROR_BUFFER_OVERFLOW</c>, or <c>ERROR_NOT_FOUND</c> is returned, the <c>ULONG</c> value pointed to
		/// by the PhyAddrLen parameter is set to zero. If the <c>ULONG</c> value pointed to by the PhyAddrLen parameter is less than 6 on
		/// Windows Vista and later, <c>SendARP</c> function returns <c>ERROR_BUFFER_OVERFLOW</c> indicating the buffer to receive the
		/// physical address is too small. If the SrcIp parameter specifies an IPv4 address that is not an interface on the local computer,
		/// the <c>SendARP</c> function on Windows Vista and later returns <c>ERROR_NOT_FOUND</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and earlier, a <c>NULL</c> pointer passed as the pMacAddr or PhyAddrLen parameter to the <c>SendARP</c>
		/// function returns <c>ERROR_INVALID_PARAMETER</c>. If an error occurs on Windows Server 2003 and earlier and
		/// <c>ERROR_GEN_FAILURE</c> or <c>ERROR_INVALID_USER_BUFFER</c> is returned, the <c>ULONG</c> value pointed to by the PhyAddrLen
		/// parameter is set to zero. If the <c>ULONG</c> value pointed to by the PhyAddrLen parameter is less than 6 on Windows Server 2003
		/// and earlier, the <c>SendARP</c> function does not return an error but only returns part of the hardware address in the array
		/// pointed to by the pMacAddr parameter. So if the value pointed to by the PhyAddrLen parameter is 4, then only the first 4 bytes of
		/// the hardware address are returned in the array pointed to by the pMacAddr parameter. If the SrcIp parameter specifies an IPv4
		/// address that is not an interface on the local computer, the <c>SendARP</c> function on Windows Server 2003 and earlier ignores
		/// the SrcIp parameter and uses an IPv4 address on the local computer for the source IPv4 address.
		/// </para>
		/// <para>The GetIpNetTable function retrieves the ARP table on the local computer that maps IPv4 addresses to physical addresses.</para>
		/// <para>The CreateIpNetEntry function creates an ARP entry in the ARP table on the local computer.</para>
		/// <para>The DeleteIpNetEntry function deletes an ARP entry from the ARP table on the local computer.</para>
		/// <para>The SetIpNetEntry function modifies an existing ARP entry in the ARP table on the local computer.</para>
		/// <para>The FlushIpNetTable function deletes all ARP entries for the specified interface from the ARP table on the local computer.</para>
		/// <para>
		/// On Windows Vista and later, the ResolveIpNetEntry2 function can used to replace the <c>SendARP</c> function. An ARP request is
		/// sent if the <c>Address</c> member of the MIB_IPNET_ROW2 structure passed to the <c>ResolveIpNetEntry2</c> function is an IPv4 address.
		/// </para>
		/// <para>
		/// On Windows Vista, a new group of functions can be used to access, modify, and delete the ARP table entries when the
		/// <c>Address</c> member of the MIB_IPNET_ROW2 structure passed to these functions is an IPv4 address. The new functions include the
		/// following: GetIpNetTable2, CreateIpNetEntry2, DeleteIpNetEntry2, FlushIpNetTable2, and SetIpNetEntry2.
		/// </para>
		/// <para>
		/// For information about the <c>IPAddr</c> data type, see Windows Data Types. To convert an IP address between dotted decimal
		/// notation and <c>IPAddr</c> format, use the inet_addr and inet_ntoa functions.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code demonstrates how to obtain the hardware or media access control (MAC) address associated with a specified IPv4 address.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-sendarp DWORD SendARP( IPAddr DestIP, IPAddr SrcIP,
		// PVOID pMacAddr, PULONG PhyAddrLen );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5cbaf45a-a64e-49fd-a920-01759b5c4f81")]
		public static extern Win32Error SendARP(IN_ADDR DestIP, IN_ADDR SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

		/// <summary>
		/// The SendARP function sends an Address Resolution Protocol (ARP) request to obtain the physical address that corresponds to the
		/// specified destination IPv4 address.
		/// </summary>
		/// <param name="DestIP">
		/// The destination IPv4 address, in the form of an IPAddr structure. The ARP request attempts to obtain the physical address that
		/// corresponds to this IPv4 address.
		/// </param>
		/// <param name="SrcIP">
		/// The source IPv4 address of the sender, in the form of an IPAddr structure. This parameter is optional and is used to select the
		/// interface to send the request on for the ARP entry. The caller may specify zero corresponding to the INADDR_ANY IPv4 address for
		/// this parameter.
		/// </param>
		/// <returns>The physical address that corresponds to the IPv4 address specified by the DestIP parameter.</returns>
		public static byte[] SendARP(IN_ADDR DestIP, IN_ADDR SrcIP = default(IN_ADDR))
		{
			uint len = 6;
			byte[] ret = new byte[(int)len];
			SendARP(DestIP, SrcIP, ret, ref len).ThrowIfFailed();
			return ret;
		}

		/// <summary>
		/// <para>The <c>SetIpNetEntry</c> function modifies an existing ARP entry in the ARP table on the local computer.</para>
		/// </summary>
		/// <param name="pArpEntry">
		/// <para>
		/// A pointer to a MIB_IPNETROW structure. The information in this structure specifies the entry to modify and the new information
		/// for the entry. The caller must specify values for all members of this structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned on Windows Vista and Windows Server 2008 under several conditions that include the
		/// following: the user lacks the required administrative privileges on the local computer or the application is not running in an
		/// enhanced shell as the built-in Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// The pArpEntry parameter is NULL, or SetIpNetEntry is unable to read from the memory pointed to by pArpEntry, or one of the
		/// members of the MIB_IPNETROW structure is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// On Windows Vista and later , the <c>SetIpNetEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>SetIpNetEntry</c> is called by a user that is not a member of the Administrators group, the function
		/// call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setipnetentry DWORD SetIpNetEntry( PMIB_IPNETROW
		// pArpEntry );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "d985b749-5aa3-4b4a-ba8f-bc8edcf1b1f3")]
		public static extern Win32Error SetIpNetEntry(ref MIB_IPNETROW pArpEntry);

		/// <summary>
		/// <para>The <c>SetIpNetEntry2</c> function sets the physical address of an existing neighbor IP address entry on the local computer.</para>
		/// </summary>
		/// <param name="Row">
		/// <para>A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// Access is denied. This error is returned under several conditions that include the following: the user lacks the required
		/// administrative privileges on the local computer or the application is not running in an enhanced shell as the built-in
		/// Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the Row parameter, the
		/// Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter was not set to a valid unicast, anycast, or multicast IPv4
		/// or IPv6 address, the PhysicalAddress and PhysicalAddressLength members of the MIB_IPNET_ROW2 pointed to by the Row parameter were
		/// not set to a valid physical address, or both the InterfaceLuid or InterfaceIndex members of the MIB_IPNET_ROW2 pointed to by the
		/// Row parameter were unspecified. This error is also returned if a loopback address was passed in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface specified by the InterfaceLuid or
		/// InterfaceIndex member of the MIB_IPNET_ROW2 pointed to by the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and an IPv4 address was specified
		/// in the Address member of the MIB_IPNET_ROW2 pointed to by the Row parameter or no IPv6 stack is on the local computer and an IPv6
		/// address was specified in the Address member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetIpNetEntry2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function is used to set the physical address for an existing neighbor IP address entry on a local computer.
		/// </para>
		/// <para>
		/// The <c>Address</c> member in the MIB_IPNET_ROW2 structure pointed to by the Row parameter must be initialized to a valid unicast,
		/// anycast, or multicast IPv4 or IPv6 address and family. The <c>PhysicalAddress</c> and <c>PhysicalAddressLength</c> members in the
		/// <c>MIB_IPNET_ROW2</c> structure pointed to by the Row parameter must be initialized to a valid physical address. In addition, at
		/// least one of the following members in the <c>MIB_IPNET_ROW2</c> structure pointed to the Row parameter must be initialized to the
		/// interface: the <c>InterfaceLuid</c> or <c>InterfaceIndex</c>.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function will fail if the IP address passed in the <c>Address</c> member of the MIB_IPNET_ROW2 pointed
		/// to by the Row parameter is not an existing neighbor IP address on the interface specified.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetIpNetEntry2</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIpNetEntry2</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/netioapi/nf-netioapi-setipnetentry2 _NETIOAPI_SUCCESS_ NETIOAPI_API
		// SetIpNetEntry2( PMIB_IPNET_ROW2 Row );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("netioapi.h", MSDNShortId = "4f423700-f721-44a9-ade3-ea5b5b86e394")]
		public static extern Win32Error SetIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// <para>
		/// The <c>UnenableRouter</c> function decrements the reference count that tracks the number of requests to enable IPv4 forwarding.
		/// When this reference count reaches zero, <c>UnenableRouter</c> turns off IPv4 forwarding on the local computer.
		/// </para>
		/// </summary>
		/// <param name="pOverlapped">
		/// <para>
		/// A pointer to an OVERLAPPED structure. This structure should be the same as the one used in the call to the EnableRouter function.
		/// </para>
		/// </param>
		/// <param name="lpdwEnableCount">
		/// <para>An optional pointer to a <c>DWORD</c> variable. This variable receives the number of references remaining.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>UnenableRouter</c> function is specific to IPv4 forwarding. Each call that a process makes to <c>UnenableRouter</c> must
		/// correspond to a previous call to EnableRouter by the same process. The system returns an error on extraneous calls to
		/// <c>UnenableRouter</c>. As a result, a given process is not able to decrement the reference count that tracks the number of
		/// requests for enabling IPv4 forwarding for another process. Also, if IPv4 forwarding was enabled by a given process, it cannot be
		/// disabled by a different process.
		/// </para>
		/// <para>
		/// It is not possible to accurately determine the reference count that tracks the number of requests for enabling IPv4 forwarding
		/// since there might be other outstanding EnableRouter requests. So the value returned for the lpdwEnableCountparmameter is always a
		/// large count equal to ULONG_MAX/2.
		/// </para>
		/// <para>
		/// If the process that calls EnableRouter terminates without calling <c>UnenableRouter</c>, the system decrements the reference
		/// count that tracks requests to enable IPv4 forwarding as though the process had called <c>UnenableRouter</c>.
		/// </para>
		/// <para>
		/// After calling the <c>UnenableRouter</c>, use the CloseHandle call to close the handle to the event object in the OVERLAPPED structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-unenablerouter DWORD UnenableRouter( OVERLAPPED
		// *pOverlapped, LPDWORD lpdwEnableCount );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "95f0387f-24e8-4382-b78e-e59bcec0f2ed")]
		public static extern unsafe Win32Error UnenableRouter(System.Threading.NativeOverlapped* pOverlapped, out uint lpdwEnableCount);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/iptypes/ns-iptypes-fixed_info_w2ksp1
		// typedef struct FIXED_INFO_W2KSP1 { char HostName[MAX_HOSTNAME_LEN + 4]; char DomainName[MAX_DOMAIN_NAME_LEN + 4]; PIP_ADDR_STRING CurrentDnsServer; IP_ADDR_STRING DnsServerList; UINT NodeType; char ScopeId[MAX_SCOPE_ID_LEN + 4]; UINT EnableRouting; UINT EnableProxy; UINT EnableDns; } *PFIXED_INFO_W2KSP1;
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

			public IP_ADAPTER_ADDRESSES? GetNext()
			{
				return Next.ToNullableStructure<IP_ADAPTER_ADDRESSES>();
			}

			public static IEnumerable<IP_ADAPTER_ADDRESSES> ListFromPtr(IntPtr ptr)
			{
				return ptr.LinkedListToIEnum<IP_ADAPTER_ADDRESSES>(t => t.Next);
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_ANYCAST_ADDRESS
		{
			public uint Length;
			public IP_ADAPTER_CAST_FLAGS Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_DNS_SERVER_ADDRESS
		{
			public uint Length;
			public uint Reserved;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_DNS_SUFFIX
		{
			public IntPtr Next;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DNS_SUFFIX_STRING_LENGTH)]
			public string String;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_GATEWAY_ADDRESS
		{
			public uint Length;
			public uint Reserved;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_INDEX_MAP
		{
			public uint Index;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_NAME)]
			public string Name;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_ADAPTER_INFO
		{
			public IntPtr Next;
			public uint ComboIndex;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_NAME_LENGTH + 4)]
			public string AdapterName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_DESCRIPTION_LENGTH + 4)]
			public string AdapterDescription;

			public uint AddressLength;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ADAPTER_ADDRESS_LENGTH)]
			public byte[] Address;

			public uint Index;
			public IFTYPE Type;

			[MarshalAs(UnmanagedType.Bool)]
			public bool DhcpEnabled;

			public IntPtr CurrentIpAddress;
			public IP_ADDR_STRING IpAddressList;
			public IP_ADDR_STRING GatewayList;
			public IP_ADDR_STRING DhcpServer;

			[MarshalAs(UnmanagedType.Bool)]
			public bool HaveWins;

			public IP_ADDR_STRING PrimaryWinsServer;
			public IP_ADDR_STRING SecondaryWinsServer;
			public uint LeaseObtained;
			public uint LeaseExpires;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_MULTICAST_ADDRESS
		{
			public uint Length;
			public IP_ADAPTER_CAST_FLAGS Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_PREFIX
		{
			public uint Length;
			public uint Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
			public uint PrefixLength;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_UNICAST_ADDRESS
		{
			public uint Length;
			public uint Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
			public IP_PREFIX_ORIGIN PrefixOrigin;
			public IP_SUFFIX_ORIGIN SuffixOrigin;
			public IP_DAD_STATE DadState;
			public uint ValidLifetime;
			public uint PreferredLifetime;
			public uint LeaseLifetime;
			public byte OnLinkPrefixLength;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_WINS_SERVER_ADDRESS
		{
			public uint Length;
			public uint Reserved;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_ADDR_STRING
		{
			public IntPtr Next;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string IpAddress;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
			public string IpMask;

			public uint Context;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct IP_ADDRESS_PREFIX
		{
			public SOCKADDR_INET Prefix;
			public byte PrefixLength;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct IP_PER_ADAPTER_INFO
		{
			[MarshalAs(UnmanagedType.Bool)]
			public bool AutoconfigEnabled;

			[MarshalAs(UnmanagedType.Bool)]
			public bool AutoconfigActive;

			public IntPtr CurrentDnsServer; /* IpAddressList* */
			public IP_ADDR_STRING DnsServerList;

			public IEnumerable<IP_ADDR_STRING> DnsServers
			{
				get
				{
					if (!string.IsNullOrEmpty(DnsServerList.IpAddress))
					{
						yield return DnsServerList;
					}

					foreach (IP_ADDR_STRING i in DnsServerList.Next.LinkedListToIEnum<IP_ADDR_STRING>(s => s.Next))
					{
						yield return i;
					}
				}
			}
		}

		/// <summary>The MIB_IF_ROW2 structure stores information about a particular interface.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIB_IF_ROW2
		{
			/// <summary>The locally unique identifier (LUID) for the network interface.</summary>
			public NET_LUID InterfaceLuid;

			/// <summary>
			/// The index that identifies the network interface. This index value may change when a network adapter is disabled and then
			/// enabled, and should not be considered persistent.
			/// </summary>
			public uint InterfaceIndex;

			/// <summary>The GUID for the network interface.</summary>
			public Guid InterfaceGuid;

			/// <summary>A NULL-terminated Unicode string that contains the alias name of the network interface.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IF_MAX_STRING_SIZE + 1)]
			public string Alias;

			/// <summary>A NULL-terminated Unicode string that contains a description of the network interface.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IF_MAX_STRING_SIZE + 1)]
			public string Description;

			/// <summary>The length, in bytes, of the physical hardware address specified by the PhysicalAddress member.</summary>
			public uint physicalAddressLength;

			/// <summary>The physical hardware address of the adapter for this network interface.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;

			/// <summary>The permanent physical hardware address of the adapter for this network interface.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PermanentPhysicalAddress;

			/// <summary>The maximum transmission unit (MTU) size, in bytes, for this network interface.</summary>
			public uint Mtu;

			/// <summary>
			/// The interface type as defined by the Internet Assigned Names Authority (IANA). For more information, see
			/// http://www.iana.org/assignments/ianaiftype-mib. Possible values for the interface type are listed in the Ipifcons.h header file.
			/// </summary>
			public IFTYPE Type;

			/// <summary>
			/// The encapsulation method used by a tunnel if the Type member is IF_TYPE_TUNNEL. The tunnel type is defined by the Internet
			/// Assigned Names Authority (IANA). For more information, see http://www.iana.org/assignments/ianaiftype-mib. This member can be
			/// one of the values from the TUNNEL_TYPE enumeration type defined in the Ifdef.h header file.
			/// </summary>
			public TUNNEL_TYPE TunnelType;

			/// <summary>
			/// The NDIS media type for the interface. This member can be one of the values from the NDIS_MEDIUM enumeration type defined in
			/// the Ntddndis.h header file.
			/// </summary>
			public NDIS_MEDIUM MediaType;

			/// <summary>
			/// The NDIS physical medium type. This member can be one of the values from the NDIS_PHYSICAL_MEDIUM enumeration type defined in
			/// the Ntddndis.h header file.
			/// </summary>
			public NDIS_PHYSICAL_MEDIUM PhysicalMediumType;

			/// <summary>
			/// The interface access type. This member can be one of the values from the NET_IF_ACCESS_TYPE enumeration type defined in the
			/// Ifdef.h header file.
			/// </summary>
			public NET_IF_ACCESS_TYPE AccessType;

			/// <summary>
			/// The interface direction type. This member can be one of the values from the NET_IF_DIRECTION_TYPE enumeration type defined in
			/// the Ifdef.h header file.
			/// </summary>
			public NET_IF_DIRECTION_TYPE DirectionType;

			/// <summary>
			/// A set of flags that provide information about the interface. These flags are combined with a bitwise OR operation. If none of
			/// the flags applies, then this member is set to zero.
			/// </summary>
			public InterfaceAndOperStatusFlags InterfaceAndOperStatusFlags;

			/// <summary>
			/// The operational status for the interface as defined in RFC 2863 as IfOperStatus. For more information, see
			/// http://www.ietf.org/rfc/rfc2863.txt. This member can be one of the values from the IF_OPER_STATUS enumeration type defined in
			/// the Ifdef.h header file.
			/// </summary>
			public IF_OPER_STATUS OperStatus;

			/// <summary>
			/// The administrative status for the interface as defined in RFC 2863. For more information, see
			/// http://www.ietf.org/rfc/rfc2863.txt. This member can be one of the values from the NET_IF_ADMIN_STATUS enumeration type
			/// defined in the Ifdef.h header file.
			/// </summary>
			public NET_IF_ADMIN_STATUS AdminStatus;

			/// <summary>
			/// The connection state of the interface. This member can be one of the values from the NET_IF_MEDIA_CONNECT_STATE enumeration
			/// type defined in the Ifdef.h header file.
			/// </summary>
			public NET_IF_MEDIA_CONNECT_STATE MediaConnectState;

			/// <summary>The GUID that is associated with the network that the interface belongs to.</summary>
			public Guid NetworkGuid;

			/// <summary>
			/// The NDIS network interface connection type. This member can be one of the values from the NET_IF_CONNECTION_TYPE enumeration
			/// type defined in the Ifdef.h header file.
			/// </summary>
			public NET_IF_CONNECTION_TYPE ConnectionType;

			/// <summary>The speed in bits per second of the transmit link.</summary>
			public ulong TransmitLinkSpeed;

			/// <summary>The speed in bits per second of the receive link.</summary>
			public ulong ReceiveLinkSpeed;

			/// <summary>
			/// The number of octets of data received without errors through this interface. This value includes octets in unicast,
			/// broadcast, and multicast packets.
			/// </summary>
			public ulong InOctets;

			/// <summary>The number of unicast packets received without errors through this interface.</summary>
			public ulong InUcastPkts;

			/// <summary>
			/// The number of non-unicast packets received without errors through this interface. This value includes broadcast and multicast packets.
			/// </summary>
			public ulong InNUcastPkts;

			/// <summary>
			/// The number of inbound packets which were chosen to be discarded even though no errors were detected to prevent the packets
			/// from being deliverable to a higher-layer protocol.
			/// </summary>
			public ulong InDiscards;

			/// <summary>The number of incoming packets that were discarded because of errors.</summary>
			public ulong InErrors;

			/// <summary>The number of incoming packets that were discarded because the protocol was unknown.</summary>
			public ulong InUnknownProtos;

			/// <summary>The number of octets of data received without errors in unicast packets through this interface.</summary>
			public ulong InUcastOctets;

			/// <summary>The number of octets of data received without errors in multicast packets through this interface.</summary>
			public ulong InMulticastOctets;

			/// <summary>The number of octets of data received without errors in broadcast packets through this interface.</summary>
			public ulong InBroadcastOctets;

			/// <summary>
			/// The number of octets of data transmitted without errors through this interface. This value includes octets in unicast,
			/// broadcast, and multicast packets.
			/// </summary>
			public ulong OutOctets;

			/// <summary>The number of unicast packets transmitted without errors through this interface.</summary>
			public ulong OutUcastPkts;

			/// <summary>
			/// The number of non-unicast packets transmitted without errors through this interface. This value includes broadcast and
			/// multicast packets.
			/// </summary>
			public ulong OutNUcastPkts;

			/// <summary>The number of outgoing packets that were discarded even though they did not have errors.</summary>
			public ulong OutDiscards;

			/// <summary>The number of outgoing packets that were discarded because of errors.</summary>
			public ulong OutErrors;

			/// <summary>The number of octets of data transmitted without errors in unicast packets through this interface.</summary>
			public ulong OutUcastOctets;

			/// <summary>The number of octets of data transmitted without errors in multicast packets through this interface.</summary>
			public ulong OutMulticastOctets;

			/// <summary>The number of octets of data transmitted without errors in broadcast packets through this interface.</summary>
			public ulong OutBroadcastOctets;

			/// <summary>The transmit queue length. This field is not currently used.</summary>
			public ulong OutQLen;

			/// <summary>Initializes a new instance of the <see cref="MIB_IF_ROW2"/> struct.</summary>
			/// <param name="interfaceIndex">Index of the interface.</param>
			public MIB_IF_ROW2(uint interfaceIndex) : this()
			{
				InterfaceIndex = interfaceIndex;
			}

			/// <summary>Initializes a new instance of the <see cref="MIB_IF_ROW2"/> struct.</summary>
			/// <param name="interfaceLuid">The interface luid.</param>
			public MIB_IF_ROW2(NET_LUID interfaceLuid) : this()
			{
				InterfaceLuid = interfaceLuid;
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIB_IFROW
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_INTERFACE_NAME_LEN)]
			public string wszName;

			public uint dwIndex; // index of the interface
			public uint dwType; // type of interface
			public uint dwMtu; // max transmission unit
			public uint dwSpeed; // speed of the interface
			public uint dwPhysAddrLen; // length of physical address

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_PHYSADDR)]
			public byte[] bPhysAddr; // physical address of adapter

			public uint dwAdminStatus; // administrative status
			public uint dwOperStatus; // operational status
			public uint dwLastChange; // last time operational status changed
			public uint dwInOctets; // octets received
			public uint dwInUcastPkts; // unicast packets received
			public uint dwInNUcastPkts; // non-unicast packets received
			public uint dwInDiscards; // received packets discarded
			public uint dwInErrors; // erroneous packets received
			public uint dwInUnknownProtos; // unknown protocol packets received
			public uint dwOutOctets; // octets sent
			public uint dwOutUcastPkts; // unicast packets sent
			public uint dwOutNUcastPkts; // non-unicast packets sent
			public uint dwOutDiscards; // outgoing packets discarded
			public uint dwOutErrors; // erroneous packets sent
			public uint dwOutQLen; // output queue length
			public uint dwDescrLen; // length of bDescr member

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_IFDESCR)]
			public byte[] bDescr; // interface description
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct MIB_IPADDRROW
		{
			public IN_ADDR dwAddr;
			public uint dwIndex;
			public IN_ADDR dwMask;
			public IN_ADDR dwBCastAddr;
			public uint dwReasmSize;
			public ushort unused1;
			public MIB_IPADDRTYPE wType;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct MIB_IPFORWARD_ROW2
		{
			public NET_LUID InterfaceLuid;
			public uint InterfaceIndex;
			public IP_ADDRESS_PREFIX DestinationPrefix;
			public SOCKADDR_INET NextHop;
			public byte SitePrefixLength;
			public uint ValidLifetime;
			public uint PreferredLifetime;
			public uint Metric;
			public MIB_IPPROTOCOL Protocol;
			public byte Loopback;
			public byte AutoconfigureAddress;
			public byte Publish;
			public byte Immortal;
			public uint Age;
			public NL_ROUTE_ORIGIN Origin;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_IPFORWARDROW
		{
			public IN_ADDR dwForwardDest;
			public IN_ADDR dwForwardMask;
			public uint dwForwardPolicy;
			public IN_ADDR dwForwardNextHop;
			public uint dwForwardIfIndex;
			public MIB_IPFORWARD_TYPE dwForwardType;
			public MIB_IPPROTOCOL dwForwardProto;
			public uint dwForwardAge;
			public uint dwForwardNextHopAS;
			public uint dwForwardMetric1;
			public uint dwForwardMetric2;
			public uint dwForwardMetric3;
			public uint dwForwardMetric4;
			public uint dwForwardMetric5;
		}

		/// <summary>
		/// The MIB_IPNETROW structure contains information for an Address Resolution Protocol (ARP) table entry for an IPv4 address.
		/// </summary>
		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct MIB_IPNET_ROW2
		{
			public SOCKADDR_INET Address;
			public uint InterfaceIndex;
			public NET_LUID InterfaceLuid;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;

			public uint PhysicalAddressLength;
			public NL_NEIGHBOR_STATE State;
			public MIB_IPNET_ROW2_FLAGS Flags;
			public uint ReachabilityTime;

			private MIB_IPNET_ROW2(SOCKADDR_IN ipV4, byte[] macAddr) : this()
			{
				Address.Ipv4 = ipV4;
				SetMac(macAddr);
			}

			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV4, macAddr)
			{
				InterfaceLuid = ifLuid;
			}

			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, uint ifIdx, byte[] macAddr = null) : this(ipV4, macAddr)
			{
				InterfaceIndex = ifIdx;
			}

			private MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, byte[] macAddr) : this()
			{
				Address.Ipv6 = ipV6;
				SetMac(macAddr);
			}

			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV6, macAddr)
			{
				InterfaceLuid = ifLuid;
			}

			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, uint ifIdx, byte[] macAddr = null) : this(ipV6, macAddr)
			{
				InterfaceIndex = ifIdx;
			}

			private void SetMac(byte[] macAddr)
			{
				if (macAddr == null)
				{
					return;
				}

				PhysicalAddressLength = IF_MAX_PHYS_ADDRESS_LENGTH;
				PhysicalAddress = new byte[IF_MAX_PHYS_ADDRESS_LENGTH];
				Array.Copy(macAddr, PhysicalAddress, 6);
			}

			public override string ToString()
			{
				return $"{Address}; MAC:{PhysicalAddressToString(PhysicalAddress)}; If:{(InterfaceIndex != 0 ? InterfaceIndex.ToString() : InterfaceLuid.ToString())}";
			}
		}

		/// <summary>
		/// The MIB_IPNETROW structure contains information for an Address Resolution Protocol (ARP) table entry for an IPv4 address.
		/// </summary>
		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_IPNETROW
		{
			/// <summary>The index of the adapter.</summary>
			public uint dwIndex;

			/// <summary>The length, in bytes, of the physical address.</summary>
			public uint dwPhysAddrLen;

			/// <summary>The physical address.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAXLEN_PHYSADDR)]
			public byte[] bPhysAddr;

			/// <summary>The IPv4 address.</summary>
			public IN_ADDR dwAddr;

			/// <summary>The type of ARP entry. This type can be one of the following values.</summary>
			public MIB_IPNET_TYPE dwType;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCP6ROW
		{
			public MIB_TCP_STATE dwState;
			public IN6_ADDR LocalAddr;
			public uint dwLocalScopeId;
			public uint dwLocalPort;
			public IN6_ADDR RemoteAddr;
			public uint dwRemoteScopeId;
			public uint dwRemotePort;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCP6ROW_OWNER_MODULE
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucLocalAddr;

			public uint dwLocalScopeId;
			public uint dwLocalPort;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucRemoteAddr;

			public uint dwRemoteScopeId;
			public uint dwRemotePort;
			public MIB_TCP_STATE dwState;
			public uint dwOwningPid;
			public SYSTEMTIME liCreateTimestamp;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		// https://msdn.microsoft.com/en-us/library/aa366896
		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCP6ROW_OWNER_PID
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucLocalAddr;

			public uint dwLocalScopeId;
			public uint dwLocalPort;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucRemoteAddr;

			public uint dwRemoteScopeId;
			public uint dwRemotePort;
			public MIB_TCP_STATE dwState;
			public uint dwOwningPid;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW
		{
			public MIB_TCP_STATE dwState;
			public uint dwLocalAddr;
			public uint dwLocalPort;
			public uint dwRemoteAddr;
			public uint dwRemotePort;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW_OWNER_MODULE
		{
			public MIB_TCP_STATE dwState;
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
			public IN_ADDR dwRemoteAddr;
			public uint dwRemotePort;
			public uint dwOwningPid;
			public SYSTEMTIME liCreateTimestamp;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		// https://msdn2.microsoft.com/en-us/library/aa366913.aspx
		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW_OWNER_PID
		{
			public MIB_TCP_STATE dwState;
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
			public IN_ADDR dwRemoteAddr;
			public uint dwRemotePort;
			public uint dwOwningPid;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW2
		{
			public MIB_TCP_STATE dwState;
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
			public IN_ADDR dwRemoteAddr;
			public uint dwRemotePort;
			public uint dwOwningPid;
			public TCP_CONNECTION_OFFLOAD_STATE dwOffloadState;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPSTATS
		{
			public TCP_RTO_ALGORITHM RtoAlgorithm;
			public uint dwRtoMin;
			public uint dwRtoMax;
			public uint dwMaxConn;
			public uint dwActiveOpens;
			public uint dwPassiveOpens;
			public uint dwAttemptFails;
			public uint dwEstabResets;
			public uint dwCurrEstab;
			public uint dwInSegs;
			public uint dwOutSegs;
			public uint dwRetransSegs;
			public uint dwInErrs;
			public uint dwOutRsts;
			public uint dwNumConns;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPSTATS2
		{
			public TCP_RTO_ALGORITHM RtoAlgorithm;
			public uint dwRtoMin;
			public uint dwRtoMax;
			public uint dwMaxConn;
			public uint dwActiveOpens;
			public uint dwPassiveOpens;
			public uint dwAttemptFails;
			public uint dwEstabResets;
			public uint dwCurrEstab;
			public ulong dw64InSegs;
			public ulong dw64OutSegs;
			public uint dwRetransSegs;
			public uint dwInErrs;
			public uint dwOutRsts;
			public uint dwNumConns;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDP6ROW
		{
			public IN6_ADDR dwLocalAddr;
			public uint dwLocalScopeId;
			public uint dwLocalPort;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDP6ROW_OWNER_MODULE
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucLocalAddr;

			public uint dwLocalScopeId;
			public uint dwLocalPort;
			public uint dwOwningPid;
			public SYSTEMTIME liCreateTimestamp;
			public int SpecificPortBind;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDP6ROW_OWNER_PID
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucLocalAddr;

			public uint dwLocalScopeId;
			public uint dwLocalPort;
			public uint dwOwningPid;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPROW
		{
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPROW_OWNER_MODULE
		{
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
			public uint dwOwningPid;
			public SYSTEMTIME liCreateTimestamp;
			public int SpecificPortBind;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TCPIP_OWNING_MODULE_SIZE)]
			public ulong[] OwningModuleInfo;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPROW_OWNER_PID
		{
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
			public uint dwOwningPid;
		}

		[PInvokeData("IpHlpApi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NET_LUID
		{
			public ulong Value;

			public NET_LUID(uint index, IFTYPE type)
			{
				Value = (index << 24) | ((ulong)type << 48);
			}

			public uint NetLuidIndex
			{
				get => (uint)((Value & 0x0000FFFFFF000000) >> 24);
				set => Value = (value << 24) | Value;
			}

			public IFTYPE IfType
			{
				get => (IFTYPE)((Value & 0xFFFF000000000000) >> 48);
				set => Value = ((ulong)value << 48) | Value;
			}

			public override string ToString()
			{
				return $"{NetLuidIndex}:{IfType}";
			}
		}

		[CorrespondingType(typeof(IP_ADAPTER_INDEX_MAP))]
		[DefaultProperty(nameof(Adapter))]
		public class IP_INTERFACE_INFO : SafeElementArray<IP_ADAPTER_INDEX_MAP, int, CoTaskMemoryMethods>
		{
			public IP_INTERFACE_INFO(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public IP_ADAPTER_INDEX_MAP[] Adapter { get => Elements; set => Elements = value; }
			public int NumAdapters => Count;

			public static implicit operator IntPtr(IP_INTERFACE_INFO iii)
			{
				return iii.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(IN_ADDR))]
		[DefaultProperty(nameof(Address))]
		public class IP_UNIDIRECTIONAL_ADAPTER_ADDRESS : SafeElementArray<IN_ADDR, uint, CoTaskMemoryMethods>
		{
			public IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public IN_ADDR[] Address { get => Elements; set => Elements = value; }
			public uint NumAdapters => Count;

			public static implicit operator IntPtr(IP_UNIDIRECTIONAL_ADAPTER_ADDRESS table)
			{
				return table.DangerousGetHandle();
			}
		}

		/// <summary>The MIB_IF_TABLE2 structure contains a table of logical and physical interface entries.</summary>
		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_IF_ROW2))]
		[DefaultProperty(nameof(Elements))]
		public class MIB_IF_TABLE2 : GenericSafeHandle, IEnumerable<MIB_IF_ROW2>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_IF_TABLE2"/> class.</summary>
			public MIB_IF_TABLE2() : base(Free) { }

			/// <summary>Gets the array of MIB_IF_ROW2 structures containing interface entries.</summary>
			/// <value>An array of MIB_IF_ROW2 structures containing interface entries.</value>
			public MIB_IF_ROW2[] Elements => handle.ToArray<MIB_IF_ROW2>((int)NumEntries, Marshal.SizeOf(typeof(ulong)));

			/// <summary>Gets the number of interface entries in the array.</summary>
			/// <value>The number of interface entries in the array.</value>
			public uint NumEntries => IsInvalid ? 0 : handle.ToStructure<uint>();

			public IEnumerator<MIB_IF_ROW2> GetEnumerator()
			{
				return ((IEnumerable<MIB_IF_ROW2>)Elements).GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			private static bool Free(IntPtr handle)
			{
				FreeMibTable(handle); return true;
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_IFROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IFTABLE : SafeElementArray<MIB_IFROW, uint, CoTaskMemoryMethods>
		{
			public MIB_IFTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_IFROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_IFTABLE table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_IPADDRROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IPADDRTABLE : SafeElementArray<MIB_IPADDRROW, uint, CoTaskMemoryMethods>
		{
			public MIB_IPADDRTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_IPADDRROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_IPADDRTABLE table)
			{
				return table.DangerousGetHandle();
			}
		}

		/// <summary>The MIB_IPNET_TABLE2 structure contains a table of neighbor IP address entries.</summary>
		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_IPNET_ROW2))]
		[DefaultProperty(nameof(Elements))]
		public class MIB_IPNET_TABLE2 : GenericSafeHandle, IEnumerable<MIB_IPNET_ROW2>
		{
			/// <summary>Initializes a new instance of the <see cref="MIB_IPNET_TABLE2"/> class.</summary>
			public MIB_IPNET_TABLE2() : base(Free) { }

			/// <summary>Gets the array of MIB_IF_ROW2 structures containing interface entries.</summary>
			/// <value>An array of MIB_IF_ROW2 structures containing interface entries.</value>
			public MIB_IPNET_ROW2[] Elements => handle.ToArray<MIB_IPNET_ROW2>((int)NumEntries, Marshal.SizeOf(typeof(ulong)));

			/// <summary>Gets the number of interface entries in the array.</summary>
			/// <value>The number of interface entries in the array.</value>
			public uint NumEntries => IsInvalid ? 0 : handle.ToStructure<uint>();

			public IEnumerator<MIB_IPNET_ROW2> GetEnumerator()
			{
				return ((IEnumerable<MIB_IPNET_ROW2>)Elements).GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			private static bool Free(IntPtr handle)
			{
				FreeMibTable(handle); return true;
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_IPNETROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IPNETTABLE : SafeElementArray<MIB_IPNETROW, uint, CoTaskMemoryMethods>
		{
			public MIB_IPNETTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_IPNETROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_IPNETTABLE table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_TCP6ROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE_OWNER_MODULE : SafeElementArray<MIB_TCP6ROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_TCP6TABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_TCP6ROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCP6TABLE_OWNER_MODULE table)
			{
				return table.DangerousGetHandle();
			}
		}

		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366905
		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_TCP6ROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE_OWNER_PID : SafeElementArray<MIB_TCP6ROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_TCP6TABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_TCP6ROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCP6TABLE_OWNER_PID table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_TCPROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE : SafeElementArray<MIB_TCPROW, uint, CoTaskMemoryMethods>
		{
			public MIB_TCPTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_TCPROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCPTABLE table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_TCPROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE_OWNER_MODULE : SafeElementArray<MIB_TCPROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_TCPTABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_TCPROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCPTABLE_OWNER_MODULE table)
			{
				return table.DangerousGetHandle();
			}
		}

		// https://msdn2.microsoft.com/en-us/library/aa366921.aspx
		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_TCPROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE_OWNER_PID : SafeElementArray<MIB_TCPROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_TCPTABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_TCPROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCPTABLE_OWNER_PID table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_UDP6ROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE : SafeElementArray<MIB_UDP6ROW, uint, CoTaskMemoryMethods>
		{
			public MIB_UDP6TABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_UDP6ROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDP6TABLE table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_UDP6ROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE_OWNER_MODULE : SafeElementArray<MIB_UDP6ROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_UDP6TABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_UDP6ROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDP6TABLE_OWNER_MODULE table)
			{
				return table.DangerousGetHandle();
			}
		}

		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366905
		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_UDP6ROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE_OWNER_PID : SafeElementArray<MIB_UDP6ROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_UDP6TABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_UDP6ROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDP6TABLE_OWNER_PID table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_UDPROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE : SafeElementArray<MIB_UDPROW, uint, CoTaskMemoryMethods>
		{
			public MIB_UDPTABLE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_UDPROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDPTABLE table)
			{
				return table.DangerousGetHandle();
			}
		}

		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_UDPROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE_OWNER_MODULE : SafeElementArray<MIB_UDPROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_UDPTABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_UDPROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDPTABLE_OWNER_MODULE table)
			{
				return table.DangerousGetHandle();
			}
		}

		// https://msdn2.microsoft.com/en-us/library/aa366921.aspx
		[PInvokeData("IpHlpApi.h")]
		[CorrespondingType(typeof(MIB_UDPROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE_OWNER_PID : SafeElementArray<MIB_UDPROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_UDPTABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0)
			{
			}

			public uint dwNumEntries => Count;
			public MIB_UDPROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDPTABLE_OWNER_PID table)
			{
				return table.DangerousGetHandle();
			}
		}

		public class PIP_PER_ADAPTER_INFO : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			public PIP_PER_ADAPTER_INFO(uint byteSize) : base((int)byteSize)
			{
			}

			public bool AutoconfigActive => !IsInvalid && handle.ToStructure<IP_PER_ADAPTER_INFO>().AutoconfigActive;
			public bool AutoconfigEnabled => !IsInvalid && handle.ToStructure<IP_PER_ADAPTER_INFO>().AutoconfigEnabled;
			public IEnumerable<IP_ADDR_STRING> DnsServerList => IsInvalid ? new IP_ADDR_STRING[0] : handle.ToStructure<IP_PER_ADAPTER_INFO>().DnsServers;

			public static implicit operator IntPtr(PIP_PER_ADAPTER_INFO info)
			{
				return info.DangerousGetHandle();
			}
		}
	}
}