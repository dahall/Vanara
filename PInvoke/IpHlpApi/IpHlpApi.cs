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

		[Flags]
		public enum GetAdaptersAddressesFlags : uint
		{
			GAA_FLAG_SKIP_UNICAST = 0x0001,
			GAA_FLAG_SKIP_ANYCAST = 0x0002,
			GAA_FLAG_SKIP_MULTICAST = 0x0004,
			GAA_FLAG_SKIP_DNS_SERVER = 0x0008,
			GAA_FLAG_INCLUDE_PREFIX = 0x0010,
			GAA_FLAG_SKIP_FRIENDLY_NAME = 0x0020,
			GAA_FLAG_INCLUDE_WINS_INFO = 0x0040,
			GAA_FLAG_INCLUDE_GATEWAYS = 0x0080,
			GAA_FLAG_INCLUDE_ALL_INTERFACES = 0x0100,
			GAA_FLAG_INCLUDE_ALL_COMPARTMENTS = 0x0200,
			GAA_FLAG_INCLUDE_TUNNEL_BINDINGORDER = 0x0400,
		}

		public enum IF_OPER_STATUS : uint
		{
			IfOperStatusUp = 1,
			IfOperStatusDown,
			IfOperStatusTesting,
			IfOperStatusUnknown,
			IfOperStatusDormant,
			IfOperStatusNotPresent,
			IfOperStatusLowerLayerDown,
		}

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
			IF_TYPE_FDDI = 15,
			IF_TYPE_LAP_B = 16,
			IF_TYPE_SDLC = 17,
			IF_TYPE_DS1 = 18,  // DS1-MIB
			IF_TYPE_E1 = 19,  // Obsolete; see DS1-MIB
			IF_TYPE_BASIC_ISDN = 20,
			IF_TYPE_PRIMARY_ISDN = 21,
			IF_TYPE_PROP_POINT2POINT_SERIAL = 22,  // proprietary serial
			/// <summary>A PPP network interface.</summary>
			IF_TYPE_PPP = 23,
			/// <summary>A software loopback network interface.</summary>
			IF_TYPE_SOFTWARE_LOOPBACK = 24,
			IF_TYPE_EON = 25,  // CLNP over IP
			IF_TYPE_ETHERNET_3MBIT = 26,
			IF_TYPE_NSIP = 27,  // XNS over IP
			IF_TYPE_SLIP = 28,  // Generic Slip
			IF_TYPE_ULTRA = 29,  // ULTRA Technologies
			IF_TYPE_DS3 = 30,  // DS3-MIB
			IF_TYPE_SIP = 31,  // SMDS, coffee
			IF_TYPE_FRAMERELAY = 32,  // DTE only
			IF_TYPE_RS232 = 33,
			IF_TYPE_PARA = 34,  // Parallel port
			IF_TYPE_ARCNET = 35,
			IF_TYPE_ARCNET_PLUS = 36,
			/// <summary>An ATM network interface.</summary>
			IF_TYPE_ATM = 37,  // ATM cells
			IF_TYPE_MIO_X25 = 38,
			IF_TYPE_SONET = 39,  // SONET or SDH
			IF_TYPE_X25_PLE = 40,
			IF_TYPE_ISO88022_LLC = 41,
			IF_TYPE_LOCALTALK = 42,
			IF_TYPE_SMDS_DXI = 43,
			IF_TYPE_FRAMERELAY_SERVICE = 44,  // FRNETSERV-MIB
			IF_TYPE_V35 = 45,
			IF_TYPE_HSSI = 46,
			IF_TYPE_HIPPI = 47,
			IF_TYPE_MODEM = 48,  // Generic Modem
			IF_TYPE_AAL5 = 49,  // AAL5 over ATM
			IF_TYPE_SONET_PATH = 50,
			IF_TYPE_SONET_VT = 51,
			IF_TYPE_SMDS_ICIP = 52,  // SMDS InterCarrier Interface
			IF_TYPE_PROP_VIRTUAL = 53,  // Proprietary virtual/internal
			IF_TYPE_PROP_MULTIPLEXOR = 54,  // Proprietary multiplexing
			IF_TYPE_IEEE80212 = 55,  // 100BaseVG
			IF_TYPE_FIBRECHANNEL = 56,
			IF_TYPE_HIPPIINTERFACE = 57,
			IF_TYPE_FRAMERELAY_INTERCONNECT = 58,  // Obsolete, use 32 or 44
			IF_TYPE_AFLANE_8023 = 59,  // ATM Emulated LAN for 802.3
			IF_TYPE_AFLANE_8025 = 60,  // ATM Emulated LAN for 802.5
			IF_TYPE_CCTEMUL = 61,  // ATM Emulated circuit
			IF_TYPE_FASTETHER = 62,  // Fast Ethernet (100BaseT)
			IF_TYPE_ISDN = 63,  // ISDN and X.25
			IF_TYPE_V11 = 64,  // CCITT V.11/X.21
			IF_TYPE_V36 = 65,  // CCITT V.36
			IF_TYPE_G703_64K = 66,  // CCITT G703 at 64Kbps
			IF_TYPE_G703_2MB = 67,  // Obsolete; see DS1-MIB
			IF_TYPE_QLLC = 68,  // SNA QLLC
			IF_TYPE_FASTETHER_FX = 69,  // Fast Ethernet (100BaseFX)
			IF_TYPE_CHANNEL = 70,
			/// <summary>An IEEE 802.11 wireless network interface.</summary>
			IF_TYPE_IEEE80211 = 71,  // Radio spread spectrum
			IF_TYPE_IBM370PARCHAN = 72,  // IBM System 360/370 OEMI Channel
			IF_TYPE_ESCON = 73,  // IBM Enterprise Systems Connection
			IF_TYPE_DLSW = 74,  // Data Link Switching
			IF_TYPE_ISDN_S = 75,  // ISDN S/T interface
			IF_TYPE_ISDN_U = 76,  // ISDN U interface
			IF_TYPE_LAP_D = 77,  // Link Access Protocol D
			IF_TYPE_IPSWITCH = 78,  // IP Switching Objects
			IF_TYPE_RSRB = 79,  // Remote Source Route Bridging
			IF_TYPE_ATM_LOGICAL = 80,  // ATM Logical Port
			IF_TYPE_DS0 = 81,  // Digital Signal Level 0
			IF_TYPE_DS0_BUNDLE = 82,  // Group of ds0s on the same ds1
			IF_TYPE_BSC = 83,  // Bisynchronous Protocol
			IF_TYPE_ASYNC = 84,  // Asynchronous Protocol
			IF_TYPE_CNR = 85,  // Combat Net Radio
			IF_TYPE_ISO88025R_DTR = 86,  // ISO 802.5r DTR
			IF_TYPE_EPLRS = 87,  // Ext Pos Loc Report Sys
			IF_TYPE_ARAP = 88,  // Appletalk Remote Access Protocol
			IF_TYPE_PROP_CNLS = 89,  // Proprietary Connectionless Proto
			IF_TYPE_HOSTPAD = 90,  // CCITT-ITU X.29 PAD Protocol
			IF_TYPE_TERMPAD = 91,  // CCITT-ITU X.3 PAD Facility
			IF_TYPE_FRAMERELAY_MPI = 92,  // Multiproto Interconnect over FR
			IF_TYPE_X213 = 93,  // CCITT-ITU X213
			IF_TYPE_ADSL = 94,  // Asymmetric Digital Subscrbr Loop
			IF_TYPE_RADSL = 95,  // Rate-Adapt Digital Subscrbr Loop
			IF_TYPE_SDSL = 96,  // Symmetric Digital Subscriber Loop
			IF_TYPE_VDSL = 97,  // Very H-Speed Digital Subscrb Loop
			IF_TYPE_ISO88025_CRFPRINT = 98,  // ISO 802.5 CRFP
			IF_TYPE_MYRINET = 99,  // Myricom Myrinet
			IF_TYPE_VOICE_EM = 100, // Voice recEive and transMit
			IF_TYPE_VOICE_FXO = 101, // Voice Foreign Exchange Office
			IF_TYPE_VOICE_FXS = 102, // Voice Foreign Exchange Station
			IF_TYPE_VOICE_ENCAP = 103, // Voice encapsulation
			IF_TYPE_VOICE_OVERIP = 104, // Voice over IP encapsulation
			IF_TYPE_ATM_DXI = 105, // ATM DXI
			IF_TYPE_ATM_FUNI = 106, // ATM FUNI
			IF_TYPE_ATM_IMA = 107, // ATM IMA
			IF_TYPE_PPPMULTILINKBUNDLE = 108, // PPP Multilink Bundle
			IF_TYPE_IPOVER_CDLC = 109, // IBM ipOverCdlc
			IF_TYPE_IPOVER_CLAW = 110, // IBM Common Link Access to Workstn
			IF_TYPE_STACKTOSTACK = 111, // IBM stackToStack
			IF_TYPE_VIRTUALIPADDRESS = 112, // IBM VIPA
			IF_TYPE_MPC = 113, // IBM multi-proto channel support
			IF_TYPE_IPOVER_ATM = 114, // IBM ipOverAtm
			IF_TYPE_ISO88025_FIBER = 115, // ISO 802.5j Fiber Token Ring
			IF_TYPE_TDLC = 116, // IBM twinaxial data link control
			IF_TYPE_GIGABITETHERNET = 117,
			IF_TYPE_HDLC = 118,
			IF_TYPE_LAP_F = 119,
			IF_TYPE_V37 = 120,
			IF_TYPE_X25_MLP = 121, // Multi-Link Protocol
			IF_TYPE_X25_HUNTGROUP = 122, // X.25 Hunt Group
			IF_TYPE_TRANSPHDLC = 123,
			IF_TYPE_INTERLEAVE = 124, // Interleave channel
			IF_TYPE_FAST = 125, // Fast channel
			IF_TYPE_IP = 126, // IP (for APPN HPR in IP networks)
			IF_TYPE_DOCSCABLE_MACLAYER = 127, // CATV Mac Layer
			IF_TYPE_DOCSCABLE_DOWNSTREAM = 128, // CATV Downstream interface
			IF_TYPE_DOCSCABLE_UPSTREAM = 129, // CATV Upstream interface
			IF_TYPE_A12MPPSWITCH = 130, // Avalon Parallel Processor			
			/// <summary>A tunnel type encapsulation network interface.</summary>
			IF_TYPE_TUNNEL = 131, // Encapsulation interface
			IF_TYPE_COFFEE = 132, // Coffee pot
			IF_TYPE_CES = 133, // Circuit Emulation Service
			IF_TYPE_ATM_SUBINTERFACE = 134, // ATM Sub Interface
			IF_TYPE_L2_VLAN = 135, // Layer 2 Virtual LAN using 802.1Q
			IF_TYPE_L3_IPVLAN = 136, // Layer 3 Virtual LAN using IP
			IF_TYPE_L3_IPXVLAN = 137, // Layer 3 Virtual LAN using IPX
			IF_TYPE_DIGITALPOWERLINE = 138, // IP over Power Lines
			IF_TYPE_MEDIAMAILOVERIP = 139, // Multimedia Mail over IP
			IF_TYPE_DTM = 140, // Dynamic syncronous Transfer Mode
			IF_TYPE_DCN = 141, // Data Communications Network
			IF_TYPE_IPFORWARD = 142, // IP Forwarding Interface
			IF_TYPE_MSDSL = 143, // Multi-rate Symmetric DSL			
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
			IF_TYPE_IEEE80216_WMAN = 237,
			IF_TYPE_WWANPP = 243, // WWAN devices based on GSM technology
			IF_TYPE_WWANPP2 = 244, // WWAN devices based on CDMA technology
			IF_TYPE_IEEE802154 = 259, // IEEE 802.15.4 WPAN interface
			IF_TYPE_XBOX_WIRELESS = 281,
		}

		[Flags]
		public enum InterfaceAndOperStatusFlags : byte
		{
			HardwareInterface = 1 << 0,
			FilterInterface = 1 << 1,
			ConnectorPresent = 1 << 2,
			NotAuthenticated = 1 << 3,
			NotMediaConnected = 1 << 4,
			Paused = 1 << 5,
			LowPower = 1 << 6,
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		public enum MIB_IPFORWARD_TYPE
		{
			MIB_IPROUTE_TYPE_OTHER = 1,
			MIB_IPROUTE_TYPE_INVALID = 2,
			MIB_IPROUTE_TYPE_DIRECT = 3,
			MIB_IPROUTE_TYPE_INDIRECT = 4,
		}
		
		[PInvokeData("Iphlpapi.h")]
		public enum MIB_IPNET_TYPE
		{
			MIB_IPNET_TYPE_OTHER = 1,
			MIB_IPNET_TYPE_INVALID = 2,
			MIB_IPNET_TYPE_DYNAMIC = 3,
			MIB_IPNET_TYPE_STATIC = 4,
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("ntddndis.h")]
		public enum NDIS_MEDIUM
		{
			NdisMedium802_3,
			NdisMedium802_5,
			NdisMediumFddi,
			NdisMediumWan,
			NdisMediumLocalTalk,
			NdisMediumDix,              // defined for convenience, not a real medium
			NdisMediumArcnetRaw,
			NdisMediumArcnet878_2,
			NdisMediumAtm,
			NdisMediumWirelessWan,
			NdisMediumIrda,
			NdisMediumBpc,
			NdisMediumCoWan,
			NdisMedium1394,
			NdisMediumInfiniBand,
			NdisMediumTunnel,
			NdisMediumNative802_11,
			NdisMediumLoopback,
			NdisMediumWiMAX,
			NdisMediumIP
		}

		[PInvokeData("ntddndis.h")]
		public enum NDIS_PHYSICAL_MEDIUM
		{
			NdisPhysicalMediumUnspecified,
			NdisPhysicalMediumWirelessLan,
			NdisPhysicalMediumCableModem,
			NdisPhysicalMediumPhoneLine,
			NdisPhysicalMediumPowerLine,
			NdisPhysicalMediumDSL,      // includes ADSL and UADSL (G.Lite)
			NdisPhysicalMediumFibreChannel,
			NdisPhysicalMedium1394,
			NdisPhysicalMediumWirelessWan,
			NdisPhysicalMediumNative802_11,
			NdisPhysicalMediumBluetooth,
			NdisPhysicalMediumInfiniband,
			NdisPhysicalMediumWiMax,
			NdisPhysicalMediumUWB,
			NdisPhysicalMedium802_3,
			NdisPhysicalMedium802_5,
			NdisPhysicalMediumIrda,
			NdisPhysicalMediumWiredWAN,
			NdisPhysicalMediumWiredCoWan,
			NdisPhysicalMediumOther,
			NdisPhysicalMediumNative802_15_4,
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
		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("ifdef.h")]
		public enum TUNNEL_TYPE : uint
		{
			TUNNEL_TYPE_NONE = 0,
			TUNNEL_TYPE_OTHER = 1,
			TUNNEL_TYPE_DIRECT = 2,
			TUNNEL_TYPE_6TO4 = 11,
			TUNNEL_TYPE_ISATAP = 13,
			TUNNEL_TYPE_TEREDO = 14,
			TUNNEL_TYPE_IPHTTPS = 15
		}

		[PInvokeData("Iphlpapi.h")]
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

		/// <summary>The AddIPAddress function adds the specified IPv4 address to the specified adapter.</summary>
		/// <param name="Address">The IPv4 address to add to the adapter, in the form of an IPAddr structure.</param>
		/// <param name="IpMask">
		/// The subnet mask for the IPv4 address specified in the Address parameter. The IPMask parameter uses the same format as an IPAddr structure.
		/// </param>
		/// <param name="IfIndex">The index of the adapter on which to add the IPv4 address.</param>
		/// <param name="NTEContext">
		/// A pointer to a ULONG variable. On successful return, this parameter points to the Net Table Entry (NTE) context for the IPv4 address that was added.
		/// The caller can later use this context in a call to the DeleteIPAddress function.
		/// </param>
		/// <param name="NTEInstance">
		/// A pointer to a ULONG variable. On successful return, this parameter points to the NTE instance for the IPv4 address that was added.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error AddIPAddress(IN_ADDR Address, IN_ADDR IpMask, uint IfIndex, out uint NTEContext, out uint NTEInstance);

		/// <summary>
		/// The CancelIPChangeNotify function cancels notification of IPv4 address and route changes previously requested with successful calls to the
		/// NotifyAddrChange or NotifyRouteChange functions.
		/// </summary>
		/// <param name="notifyOverlapped">A pointer to the OVERLAPPED structure used in the previous call to NotifyAddrChange or NotifyRouteChange.</param>
		/// <returns>The CancelIPChangeNotify can return FALSE if no notification request was found or an invalid notifyOverlapped parameter was passed.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern unsafe bool CancelIPChangeNotify(System.Threading.NativeOverlapped* notifyOverlapped);

		/// <summary>The CreateIpNetEntry function creates an Address Resolution Protocol (ARP) entry in the ARP table on the local computer.</summary>
		/// <param name="pArpEntry">
		/// A pointer to a MIB_IPNETROW structure that specifies information for the new entry. The caller must specify values for all members of this structure.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error CreateIpNetEntry(ref MIB_IPNETROW pArpEntry);
	
		/// <summary>The CreateIpNetEntry2 function creates a new neighbor IP address entry on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error CreateIpNetEntry2(ref MIB_IPNET_ROW2 Row);
	
		/// <summary>The DeleteIPAddress function deletes an IP address previously added using AddIPAddress.</summary>
		/// <param name="NTEContext">The Net Table Entry (NTE) context for the IP address. This context was returned by the previous call to AddIPAddress.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error DeleteIPAddress(uint NTEContext);

		/// <summary>The DeleteIpNetEntry function deletes an ARP entry from the ARP table on the local computer.</summary>
		/// <param name="pArpEntry">A pointer to a MIB_IPNETROW structure. The information in this structure specifies the entry to delete. The caller must specify values for at least the dwIndex and dwAddr members of this structure.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error DeleteIpNetEntry(ref MIB_IPNETROW pArpEntry);

		/// <summary>The DeleteIpNetEntry2 function deletes a neighbor IP address entry on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this entry will be deleted.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error DeleteIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// The EnableRouter function turns on IPv4 forwarding on the local computer. EnableRouter also increments a reference count that tracks the number of
		/// requests to enable IPv4 forwarding.
		/// </summary>
		/// <param name="pHandle">A pointer to a handle. This parameter is currently unused.</param>
		/// <param name="pOverlapped">
		/// A pointer to an OVERLAPPED structure. Except for the hEvent member, all members of this structure should be set to zero. The hEvent member should
		/// contain a handle to a valid event object. Use the CreateEvent function to create this event object.
		/// </param>
		/// <returns>If the EnableRouter function succeeds, the return value is ERROR_IO_PENDING. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern unsafe Win32Error EnableRouter(IntPtr pHandle, System.Threading.NativeOverlapped* pOverlapped);

		/// <summary>The FlushIpNetTable2 function flushes the IP neighbor table on the local computer.</summary>
		/// <param name="Family">The address family to flush.</param>
		/// <param name="InterfaceIndex">The interface index. If the index is specified, flush the neighbor IP address entries on a specific interface, otherwise flush the neighbor IP address entries on all the interfaces. To ignore the interface, set this parameter to zero.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error FlushIpNetTable2(ADDRESS_FAMILY Family, uint InterfaceIndex);

		/// <summary>
		/// The FreeMibTable function frees the buffer allocated by the functions that return tables of network interfaces, addresses, and routes (GetIfTable2
		/// and GetAnycastIpAddressTable, for example).
		/// </summary>
		/// <param name="Memory">A pointer to the buffer to free.</param>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern void FreeMibTable(IntPtr Memory);

		/// <summary>The GetAdapterIndex function obtains the index of an adapter, given its name.</summary>
		/// <param name="AdapterName">A pointer to a Unicode string that specifies the name of the adapter.</param>
		/// <param name="IfIndex">A pointer to a ULONG variable that points to the index of the adapter.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetAdapterIndex([MarshalAs(UnmanagedType.LPWStr)] string AdapterName, out uint IfIndex);

		/// <summary>The GetAdaptersAddresses function retrieves the addresses associated with the adapters on the local computer.</summary>
		/// <param name="Family">The address family of the addresses to retrieve.</param>
		/// <param name="Flags">The type of addresses to retrieve. If this parameter is zero, then unicast, anycast, and multicast IP addresses will be returned.</param>
		/// <param name="Reserved">
		/// This parameter is not currently used, but is reserved for future system use. The calling application should pass NULL for this parameter.
		/// </param>
		/// <param name="pAdapterAddresses">A pointer to a buffer that contains a linked list of IP_ADAPTER_ADDRESSES structures on successful return.</param>
		/// <param name="pOutBufLen">A pointer to a variable that specifies the size of the buffer pointed to by AdapterAddresses.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetAdaptersAddresses(uint Family, GetAdaptersAddressesFlags Flags, IntPtr Reserved, IntPtr pAdapterAddresses, ref uint pOutBufLen);

		/// <summary>The GetAdaptersAddresses function retrieves the addresses associated with the adapters on the local computer.</summary>
		/// <param name="Flags">The type of addresses to retrieve. If this parameter is zero, then unicast, anycast, and multicast IP addresses will be returned.</param>
		/// <param name="Family">The address family of the addresses to retrieve.</param>
		/// <returns>A list of IP_ADAPTER_ADDRESSES structures on successful return.</returns>
		public static IEnumerable<IP_ADAPTER_ADDRESSES> GetAdaptersAddresses(GetAdaptersAddressesFlags Flags = 0, ADDRESS_FAMILY Family = ADDRESS_FAMILY.AF_UNSPEC)
		{
			uint len = 0;
			var e = GetAdaptersAddresses((uint)Family, Flags, IntPtr.Zero, IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_BUFFER_OVERFLOW) e.ThrowIfFailed();
			var mem = new SafeCoTaskMemHandle((int)len);
			GetAdaptersAddresses((uint)Family, Flags, IntPtr.Zero, (IntPtr)mem, ref len).ThrowIfFailed();
			return mem.DangerousGetHandle().LinkedListToIEnum<IP_ADAPTER_ADDRESSES>(t => t.Next);
		}

		/// <summary>The GetAdaptersInfo function retrieves adapter information for the local computer.</summary>
		/// <param name="pAdapterInfo">A pointer to a buffer that receives a linked list of IP_ADAPTER_INFO structures.</param>
		/// <param name="pBufOutLen">
		/// A pointer to a ULONG variable that specifies the size of the buffer pointed to by the pAdapterInfo parameter. If this size is insufficient to hold
		/// the adapter information, GetAdaptersInfo fills in this variable with the required size, and returns an error code of ERROR_BUFFER_OVERFLOW.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		[Obsolete("On Windows XP and later: Use the GetAdaptersAddresses function instead of GetAdaptersInfo.")]
		public static extern Win32Error GetAdaptersInfo(IntPtr pAdapterInfo, ref uint pBufOutLen);

		/// <summary>The GetBestInterface function retrieves the index of the interface that has the best route to the specified IPv4 address.</summary>
		/// <param name="dwDestAddr">The destination IPv4 address for which to retrieve the interface that has the best route, in the form of an IPAddr structure.</param>
		/// <param name="pdwBestIfIndex">
		/// A pointer to a DWORD variable that receives the index of the interface that has the best route to the IPv4 address specified by dwDestAddr.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetBestInterface(IN_ADDR dwDestAddr, out uint pdwBestIfIndex);

		/// <summary>The GetBestInterfaceEx function retrieves the index of the interface that has the best route to the specified IPv4 or IPv6 address.</summary>
		/// <param name="pDestAddr">The destination IPv6 or IPv4 address for which to retrieve the interface with the best route, in the form of a byte array.</param>
		/// <param name="pdwBestIfIndex">A pointer to the index of the interface with the best route to the IPv6 or IPv4 address specified by pDestAddr.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetBestInterfaceEx(SOCKADDR pDestAddr, out uint pdwBestIfIndex);

		/// <summary>The GetBestRoute function retrieves the best route to the specified destination IP address.</summary>
		/// <param name="dwDestAddr">Destination IP address for which to obtain the best route.</param>
		/// <param name="dwSourceAddr">Source IP address. This IP address corresponds to an interface on the local computer. If multiple best routes to the destination address exist, the function selects the route that uses this interface.</param>
		/// <param name="pBestRoute">Pointer to a MIB_IPFORWARDROW structure containing the best route for the IP address specified by dwDestAddr.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetBestRoute(IN_ADDR dwDestAddr, [Optional] IN_ADDR dwSourceAddr, out MIB_IPFORWARDROW pBestRoute);

		/// <summary>The GetBestRoute2 function retrieves the IP route entry on the local computer for the best route to the specified destination IP address.</summary>
		/// <param name="InterfaceLuid">The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</param>
		/// <param name="InterfaceIndex">The local index value to specify the network interface associated with an IP route entry. This index value may change when a network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.</param>
		/// <param name="SourceAddress">The source IP address. This parameter may be omitted and passed as a NULL pointer.</param>
		/// <param name="DestinationAddress">The destination IP address.</param>
		/// <param name="AddressSortOptions">A set of options that affect how IP addresses are sorted. This parameter is not currently used.</param>
		/// <param name="BestRoute">A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</param>
		/// <param name="BestSourceAddress">A pointer to the best source IP address.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetBestRoute2(ref NET_LUID InterfaceLuid, uint InterfaceIndex, ref SOCKADDR_INET SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>The GetBestRoute2 function retrieves the IP route entry on the local computer for the best route to the specified destination IP address.</summary>
		/// <param name="InterfaceLuid">The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</param>
		/// <param name="InterfaceIndex">The local index value to specify the network interface associated with an IP route entry. This index value may change when a network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.</param>
		/// <param name="SourceAddress">The source IP address. This parameter may be omitted and passed as a NULL pointer.</param>
		/// <param name="DestinationAddress">The destination IP address.</param>
		/// <param name="AddressSortOptions">A set of options that affect how IP addresses are sorted. This parameter is not currently used.</param>
		/// <param name="BestRoute">A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</param>
		/// <param name="BestSourceAddress">A pointer to the best source IP address.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetBestRoute2(IntPtr InterfaceLuid, uint InterfaceIndex, ref SOCKADDR_INET SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>The GetBestRoute2 function retrieves the IP route entry on the local computer for the best route to the specified destination IP address.</summary>
		/// <param name="InterfaceLuid">The locally unique identifier (LUID) to specify the network interface associated with an IP route entry.</param>
		/// <param name="InterfaceIndex">The local index value to specify the network interface associated with an IP route entry. This index value may change when a network adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.</param>
		/// <param name="SourceAddress">The source IP address. This parameter may be omitted and passed as a NULL pointer.</param>
		/// <param name="DestinationAddress">The destination IP address.</param>
		/// <param name="AddressSortOptions">A set of options that affect how IP addresses are sorted. This parameter is not currently used.</param>
		/// <param name="BestRoute">A pointer to the MIB_IPFORWARD_ROW2 for the best route from the source IP address to the destination IP address.</param>
		/// <param name="BestSourceAddress">A pointer to the best source IP address.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetBestRoute2(IntPtr InterfaceLuid, uint InterfaceIndex, IntPtr SourceAddress, ref SOCKADDR_INET DestinationAddress, uint AddressSortOptions, out MIB_IPFORWARD_ROW2 BestRoute, out SOCKADDR_INET BestSourceAddress);

		/// <summary>The GetExtendedTcpTable function retrieves a table that contains a list of TCP endpoints available to the application.</summary>
		/// <param name="pTcpTable">
		/// A pointer to the table structure that contains the filtered TCP endpoints available to the application. For information about how to determine the
		/// type of table returned based on specific input parameter combinations, see the Remarks section later in this document.
		/// </param>
		/// <param name="dwOutBufLen">
		/// The estimated size of the structure returned in pTcpTable, in bytes. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this
		/// function, and this field will contain the correct size of the structure.
		/// </param>
		/// <param name="bOrder">
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is set to TRUE, the TCP endpoints in the table are sorted
		/// in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the TCP endpoints in the table appear in the order
		/// in which they were retrieved.
		/// </param>
		/// <param name="ulAf">The version of IP used by the TCP endpoints.</param>
		/// <param name="TableClass">
		/// The type of the TCP table structure to retrieve. This parameter can be one of the values from the TCP_TABLE_CLASS enumeration.
		/// <para>The TCP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended TCP information to retrieve.</para>
		/// </param>
		/// <param name="Reserved">Reserved. This value must be zero.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetExtendedTcpTable(IntPtr pTcpTable, ref uint dwOutBufLen, [MarshalAs(UnmanagedType.Bool)] bool bOrder, uint ulAf, TCP_TABLE_CLASS TableClass, uint Reserved = 0);

		/// <summary>The GetExtendedTcpTable function retrieves a table that contains a list of TCP endpoints available to the application.</summary>
		/// <typeparam name="T">The type that is defined as the table associated with the <paramref name="TableClass"/> value.</typeparam>
		/// <param name="TableClass">
		/// The type of the TCP table structure to retrieve. This parameter can be one of the values from the TCP_TABLE_CLASS enumeration.
		/// <para>The TCP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended TCP information to retrieve.</para>
		/// </param>
		/// <param name="ulAf">The version of IP used by the TCP endpoints. Valid values are AF_INET and AF_INET6.</param>
		/// <param name="sorted">
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is set to TRUE, the TCP endpoints in the table are sorted
		/// in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the TCP endpoints in the table appear in the order
		/// in which they were retrieved.
		/// </param>
		/// <returns>The table.</returns>
		public static T GetExtendedTcpTable<T>(TCP_TABLE_CLASS TableClass, ADDRESS_FAMILY ulAf = ADDRESS_FAMILY.AF_INET, bool sorted = false) where T : SafeHandle
		{
			if (!CorrespondingTypeAttribute.CanGet(TableClass, typeof(T))) throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET6 && (int)TableClass > 2 && !typeof(T).Name.Contains("6")) throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET && (int)TableClass > 2 && typeof(T).Name.Contains("6")) throw new InvalidOperationException("Type mismatch with supplied options.");
			uint len = 0;
			var e = GetExtendedTcpTable(IntPtr.Zero, ref len, false, (uint)ulAf, TableClass);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER) e.ThrowIfFailed();
			var mem = (T)Activator.CreateInstance(typeof(T), len);
			GetExtendedTcpTable(mem.DangerousGetHandle(), ref len, sorted, (uint)ulAf, TableClass).ThrowIfFailed();
			return mem;
		}

		/// <summary>The GetExtendedUdpTable function retrieves a table that contains a list of UDP endpoints available to the application.</summary>
		/// <param name="pUdpTable">
		/// A pointer to the table structure that contains the filtered UDP endpoints available to the application. For information about how to determine the
		/// type of table returned based on specific input parameter combinations, see the Remarks section later in this document.
		/// </param>
		/// <param name="pdwSize">
		/// The estimated size of the structure returned in pUdpTable, in bytes. If this value is set too small, ERROR_INSUFFICIENT_BUFFER is returned by this
		/// function, and this field will contain the correct size of the structure.
		/// </param>
		/// <param name="bOrder">
		/// A value that specifies whether the UDP endpoint table should be sorted. If this parameter is set to TRUE, the UDP endpoints in the table are sorted
		/// in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the UDP endpoints in the table appear in the order
		/// in which they were retrieved.
		/// </param>
		/// <param name="ulAf">The version of IP used by the UDP endpoint.</param>
		/// <param name="TableClass">
		/// The type of the UDP table structure to retrieve. This parameter can be one of the values from the UDP_TABLE_CLASS enumeration.
		/// <para>The UDP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended UDP information to retrieve.</para>
		/// </param>
		/// <param name="Reserved">Reserved. This value must be zero.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetExtendedUdpTable(IntPtr pUdpTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder, uint ulAf, UDP_TABLE_CLASS TableClass, uint Reserved = 0);

		/// <summary>The GetExtendedUdpTable function retrieves a table that contains a list of UDP endpoints available to the application.</summary>
		/// <typeparam name="T">The type that is defined as the table associated with the <paramref name="TableClass"/> value.</typeparam>
		/// <param name="TableClass">
		/// The type of the UDP table structure to retrieve. This parameter can be one of the values from the UDP_TABLE_CLASS enumeration.
		/// <para>The UDP_TABLE_CLASS enumeration value is combined with the value of the ulAf parameter to determine the extended UDP information to retrieve.</para>
		/// </param>
		/// <param name="ulAf">The version of IP used by the UDP endpoint.</param>
		/// <param name="sorted">
		/// A value that specifies whether the UDP endpoint table should be sorted. If this parameter is set to TRUE, the UDP endpoints in the table are sorted
		/// in ascending order, starting with the lowest local IP address. If this parameter is set to FALSE, the UDP endpoints in the table appear in the order
		/// in which they were retrieved.
		/// </param>
		/// <returns>The table.</returns>
		public static T GetExtendedUdpTable<T>(UDP_TABLE_CLASS TableClass, ADDRESS_FAMILY ulAf = ADDRESS_FAMILY.AF_INET, bool sorted = false) where T : SafeHandle
		{
			if (!CorrespondingTypeAttribute.CanGet(TableClass, typeof(T))) throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET6 && !typeof(T).Name.Contains("6")) throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET && typeof(T).Name.Contains("6")) throw new InvalidOperationException("Type mismatch with supplied options.");
			uint len = 0;
			var e = GetExtendedUdpTable(IntPtr.Zero, ref len, false, (uint)ulAf, TableClass);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER) e.ThrowIfFailed();
			var mem = (T)Activator.CreateInstance(typeof(T), len);
			GetExtendedUdpTable(mem.DangerousGetHandle(), ref len, sorted, (uint)ulAf, TableClass).ThrowIfFailed();
			return mem;
		}

		/// <summary>The GetIfEntry2 function retrieves information for the specified interface on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IF_ROW2 structure that, on successful return, receives information for an interface on the local computer. On input, the InterfaceLuid or the InterfaceIndex member of the MIB_IF_ROW2 must be set to the interface for which to retrieve information.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIfEntry2(ref MIB_IF_ROW2 Row);

		/// <summary>The GetIfEntry2Ex function retrieves the specified level of information for the specified interface on the local computer.</summary>
		/// <param name="Level">The level of interface information to retrieve.</param>
		/// <param name="Row">A pointer to a MIB_IF_ROW2 structure that, on successful return, receives information for an interface on the local computer. On input, the InterfaceLuid or the InterfaceIndex member of the MIB_IF_ROW2 must be set to the interface for which to retrieve information.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h", MinClient = PInvokeClient.Windows10)]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIfEntry2Ex(MIB_IF_ENTRY_LEVEL Level, ref MIB_IF_ROW2 Row);

		/// <summary>The GetIfTable function retrieves the MIB-II interface table.</summary>
		/// <param name="pIfTable">A pointer to a buffer that receives the interface table as a MIB_IFTABLE structure.</param>
		/// <param name="pdwSize">
		/// On input, specifies the size in bytes of the buffer pointed to by the pIfTable parameter.
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned interface table, the function sets this parameter equal to the required buffer size
		/// in bytes.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// A Boolean value that specifies whether the returned interface table should be sorted in ascending order by interface index. If this parameter is
		/// TRUE, the table is sorted.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIfTable(IntPtr pIfTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The GetIfTable function retrieves the MIB-II interface table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned interface table should be sorted in ascending order by interface index. If this parameter is
		/// TRUE, the table is sorted.
		/// </param>
		/// <returns>The MIB-II interface table.</returns>
		public static MIB_IFTABLE GetIfTable(bool sorted = false)
		{
			uint len = 0;
			var e = GetIfTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER) e.ThrowIfFailed();
			var mem = new MIB_IFTABLE(len);
			GetIfTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}
		/// <summary>The GetIfTable2 function retrieves the MIB-II interface table.</summary>
		/// <param name="pIfTable">A pointer to a buffer that receives the table of interfaces in a MIB_IF_TABLE2 structure.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIfTable2(out MIB_IF_TABLE2 pIfTable);

		/// <summary>The GetIfTable2Ex function retrieves the MIB-II interface table.</summary>
		/// <param name="Level">The level of interface information to retrieve.</param>
		/// <param name="pIfTable">A pointer to a buffer that receives the table of interfaces in a MIB_IF_TABLE2 structure.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIfTable2Ex(MIB_IF_TABLE_LEVEL Level, out MIB_IF_TABLE2 pIfTable);

		/// <summary>The GetInterfaceInfo function obtains the list of the network interface adapters with IPv4 enabled on the local system.</summary>
		/// <param name="pIfTable">
		/// A pointer to a buffer that specifies an IP_INTERFACE_INFO structure that receives the list of adapters. This buffer must be allocated by the caller.
		/// </param>
		/// <param name="dwOutBufLen">
		/// A pointer to a DWORD variable that specifies the size of the buffer pointed to by pIfTable parameter to receive the IP_INTERFACE_INFO structure. If
		/// this size is insufficient to hold the IPv4 interface information, GetInterfaceInfo fills in this variable with the required size, and returns an
		/// error code of ERROR_INSUFFICIENT_BUFFER.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetInterfaceInfo(IntPtr pIfTable, ref uint dwOutBufLen);

		/// <summary>The GetInterfaceInfo function obtains the list of the network interface adapters with IPv4 enabled on the local system.</summary>
		/// <returns>An IP_INTERFACE_INFO structure that receives the list of adapters.</returns>
		public static IP_INTERFACE_INFO GetInterfaceInfo()
		{
			uint len = 0;
			var e = GetInterfaceInfo(IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER) e.ThrowIfFailed();
			var mem = new IP_INTERFACE_INFO(len);
			GetInterfaceInfo(mem, ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>The GetIpAddrTable function retrieves the interface–to–IPv4 address mapping table.</summary>
		/// <param name="pIpAddrTable">A pointer to a buffer that receives the interface–to–IPv4 address mapping table as a MIB_IPADDRTABLE structure.</param>
		/// <param name="pdwSize">
		/// On input, specifies the size in bytes of the buffer pointed to by the pIpAddrTable parameter.
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned mapping table, the function sets this parameter equal to the required buffer size
		/// in bytes.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IPv4 address. If this parameter is TRUE, the
		/// table is sorted.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIpAddrTable(IntPtr pIpAddrTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The GetIpAddrTable function retrieves the interface–to–IPv4 address mapping table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IPv4 address. If this parameter is TRUE, the
		/// table is sorted.
		/// </param>
		/// <returns>The interface–to–IPv4 address mapping table as a MIB_IPADDRTABLE structure.</returns>
		public static MIB_IPADDRTABLE GetIpAddrTable(bool sorted = false)
		{
			uint len = 0;
			var e = GetIpAddrTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER) e.ThrowIfFailed();
			var mem = new MIB_IPADDRTABLE(len);
			GetIpAddrTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

		/// <summary>The GetIpNetEntry2 function retrieves information for a neighbor IP address entry on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be updated with the properties for neighbor IP address.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>The GetIpNetTable function retrieves the IPv4 to physical address mapping table.</summary>
		/// <param name="pIpNetTable">A pointer to a buffer that receives the IPv4 to physical address mapping table as a MIB_IPNETTABLE structure.</param>
		/// <param name="pdwSize">
		/// On input, specifies the size in bytes of the buffer pointed to by the pIpNetTable parameter.
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned mapping table, the function sets this parameter equal to the required buffer size
		/// in bytes.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IP address. If this parameter is TRUE, the
		/// table is sorted.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR or ERROR_NO_DATA. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIpNetTable(IntPtr pIpNetTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The GetIpNetTable function retrieves the IPv4 to physical address mapping table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IP address. If this parameter is TRUE, the
		/// table is sorted.
		/// </param>
		/// <returns>The IPv4 to physical address mapping table as a MIB_IPNETTABLE structure.</returns>
		public static MIB_IPNETTABLE GetIpNetTable(bool sorted = false)
		{
			uint len = 0;
			var e = GetIpNetTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER) e.ThrowIfFailed();
			var mem = new MIB_IPNETTABLE(len);
			GetIpNetTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

		/// <summary>The GetIpNetTable2 function retrieves the IP neighbor table on the local computer.</summary>
		/// <param name="Family">The address family to retrieve.</param>
		/// <param name="Table">A pointer to a MIB_IPNET_TABLE2 structure that contains a table of neighbor IP address entries on the local computer.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetIpNetTable2(ADDRESS_FAMILY Family, out MIB_IPNET_TABLE2 Table);

		/// <summary>The GetNetworkParams function retrieves network parameters for the local computer.</summary>
		/// <param name="pFixedInfo">
		/// A pointer to a buffer that contains a <see cref="FIXED_INFO"/> structure that receives the network parameters for the local computer, if the function
		/// was successful. This buffer must be allocated by the caller prior to calling the GetNetworkParams function.
		/// </param>
		/// <param name="pBufOutLen">
		/// A pointer to a ULONG variable that specifies the size of the <see cref="FIXED_INFO"/> structure. If this size is insufficient to hold the
		/// information, GetNetworkParams fills in this variable with the required size, and returns an error code of ERROR_BUFFER_OVERFLOW.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetNetworkParams(IntPtr pFixedInfo, ref uint pBufOutLen);

		/// <summary>The GetNetworkParams function retrieves network parameters for the local computer.</summary>
		/// <returns>A <see cref="FIXED_INFO"/> structure that receives the network parameters for the local computer.</returns>
		public static FIXED_INFO GetNetworkParams()
		{
			var mem = SafeCoTaskMemHandle.CreateFromStructure<FIXED_INFO>();
			uint len = (uint)mem.Size;
			var e = GetNetworkParams((IntPtr)mem, ref len);
			if (e == Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				mem.Size = (int)len;
				GetNetworkParams((IntPtr)mem, ref len).ThrowIfFailed();
			}
			else
				e.ThrowIfFailed();
			return mem.ToStructure<FIXED_INFO>();
		}

		/// <summary>The GetPerAdapterInfo function retrieves information about the adapter corresponding to the specified interface.</summary>
		/// <param name="IfIndex">Index of an interface. The GetPerAdapterInfo function retrieves information for the adapter corresponding to this interface.</param>
		/// <param name="pPerAdapterInfo">Pointer to an IP_PER_ADAPTER_INFO structure that receives information about the adapter.</param>
		/// <param name="pOutBufLen">
		/// Pointer to a ULONG variable that specifies the size of the IP_PER_ADAPTER_INFO structure. If this size is insufficient to hold the information,
		/// GetPerAdapterInfo fills in this variable with the required size, and returns an error code of ERROR_BUFFER_OVERFLOW.
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetPerAdapterInfo(uint IfIndex, IntPtr pPerAdapterInfo, ref uint pOutBufLen);

		/// <summary>The GetPerAdapterInfo function retrieves information about the adapter corresponding to the specified interface.</summary>
		/// <param name="IfIndex">Index of an interface. The GetPerAdapterInfo function retrieves information for the adapter corresponding to this interface.</param>
		/// <returns>A PIP_PER_ADAPTER_INFO structure that receives information about the adapter.</returns>
		public static PIP_PER_ADAPTER_INFO GetPerAdapterInfo(uint IfIndex)
		{
			uint len = 0;
			var e = GetPerAdapterInfo(IfIndex, IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_BUFFER_OVERFLOW) e.ThrowIfFailed();
			var mem = new PIP_PER_ADAPTER_INFO(len);
			GetPerAdapterInfo(IfIndex, mem, ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>
		/// The GetUniDirectionalAdapterInfo function retrieves information about the unidirectional adapters installed on the local computer. A unidirectional
		/// adapter is an adapter that can receive datagrams, but not transmit them.
		/// </summary>
		/// <param name="pIPIfInfo">
		/// Pointer to an IP_UNIDIRECTIONAL_ADAPTER_ADDRESS structure that receives information about the unidirectional adapters installed on the local computer.
		/// </param>
		/// <param name="dwOutBufLen">Pointer to a ULONG variable that receives the size of the structure pointed to by the pIPIfInfo parameter.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error GetUniDirectionalAdapterInfo(IntPtr pIPIfInfo, ref uint dwOutBufLen);

		/// <summary>
		/// The GetUniDirectionalAdapterInfo function retrieves information about the unidirectional adapters installed on the local computer. A unidirectional
		/// adapter is an adapter that can receive datagrams, but not transmit them.
		/// </summary>
		/// <returns>An IP_UNIDIRECTIONAL_ADAPTER_ADDRESS structure that receives information about the unidirectional adapters installed on the local computer.</returns>
		public static IP_UNIDIRECTIONAL_ADAPTER_ADDRESS GetUniDirectionalAdapterInfo()
		{
			uint len = 0;
			var e = GetUniDirectionalAdapterInfo(IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_MORE_DATA) e.ThrowIfFailed();
			var mem = new IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(len);
			GetUniDirectionalAdapterInfo(mem, ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>The IpReleaseAddress function releases an IPv4 address previously obtained through the Dynamic Host Configuration Protocol (DHCP).</summary>
		/// <param name="AdapterInfo">A pointer to an IP_ADAPTER_INDEX_MAP structure that specifies the adapter associated with the IPv4 address to release.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error IpReleaseAddress(ref IP_ADAPTER_INDEX_MAP AdapterInfo);

		/// <summary>The IpRenewAddress function renews a lease on an IPv4 address previously obtained through Dynamic Host Configuration Protocol (DHCP).</summary>
		/// <param name="AdapterInfo">A pointer to an IP_ADAPTER_INDEX_MAP structure that specifies the adapter associated with the IP address to renew.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error IpRenewAddress(ref IP_ADAPTER_INDEX_MAP AdapterInfo);

		/// <summary>
		/// The NotifyAddrChange function causes a notification to be sent to the caller whenever a change occurs in the table that maps IPv4 addresses to interfaces.
		/// </summary>
		/// <param name="Handle">A pointer to a HANDLE variable that receives a file handle for use in a subsequent call to the GetOverlappedResult function.</param>
		/// <param name="overlapped">A pointer to an OVERLAPPED structure that notifies the caller of any changes in the table that maps IP addresses to interfaces.</param>
		/// <returns>
		/// If the function succeeds, the return value is NO_ERROR if the caller specifies NULL for the Handle and overlapped parameters. If the caller specifies
		/// non-NULL parameters, the return value for success is ERROR_IO_PENDING.
		/// </returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern unsafe Win32Error NotifyAddrChange(out IntPtr Handle, System.Threading.NativeOverlapped* overlapped);

		/// <summary>The NotifyRouteChange function causes a notification to be sent to the caller whenever a change occurs in the IPv4 routing table.</summary>
		/// <param name="Handle">A pointer to a HANDLE variable that receives a handle to use in asynchronous notification.</param>
		/// <param name="overlapped">A pointer to an OVERLAPPED structure that notifies the caller of any changes in the routing table.</param>
		/// <returns>
		/// If the function succeeds, the return value is NO_ERROR if the caller specifies NULL for the Handle and overlapped parameters. If the caller specifies
		/// non-NULL parameters, the return value for success is ERROR_IO_PENDING.
		/// </returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern unsafe Win32Error NotifyRouteChange(out IntPtr Handle, System.Threading.NativeOverlapped* overlapped);

		/// <summary>Converts a 6 byte Physical Address (MAC) to string.</summary>
		/// <param name="physAddr">The physical address that must have a minimum of 6 values.</param>
		/// <returns>Dashed hex value string representation of a Physical Address (MAC).</returns>
		public static string PhysicalAddressToString(byte[] physAddr) => $"{physAddr[0]:X}-{physAddr[1]:X}-{physAddr[2]:X}-{physAddr[3]:X}-{physAddr[4]:X}-{physAddr[5]:X}";

		/// <summary>The ResolveIpNetEntry2 function resolves the physical address for a neighbor IP address entry on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be updated with the properties for neighbor IP address.</param>
		/// <param name="SourceAddress">A pointer to a an optional source IP address used to select the interface to send the requests on for the neighbor IP address entry.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, IntPtr SourceAddress = default(IntPtr));

		/// <summary>The ResolveIpNetEntry2 function resolves the physical address for a neighbor IP address entry on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry. On successful return, this structure will be updated with the properties for neighbor IP address.</param>
		/// <param name="SourceAddress">A pointer to a an optional source IP address used to select the interface to send the requests on for the neighbor IP address entry.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error ResolveIpNetEntry2(ref MIB_IPNET_ROW2 Row, ref SOCKADDR_INET SourceAddress);

		/// <summary>
		/// The SendARP function sends an Address Resolution Protocol (ARP) request to obtain the physical address that corresponds to the specified destination
		/// IPv4 address.
		/// </summary>
		/// <param name="DestIP">
		/// The destination IPv4 address, in the form of an IPAddr structure. The ARP request attempts to obtain the physical address that corresponds to this
		/// IPv4 address.
		/// </param>
		/// <param name="SrcIP">
		/// The source IPv4 address of the sender, in the form of an IPAddr structure. This parameter is optional and is used to select the interface to send the
		/// request on for the ARP entry. The caller may specify zero corresponding to the INADDR_ANY IPv4 address for this parameter.
		/// </param>
		/// <param name="pMacAddr">
		/// A pointer to an array of ULONG variables. This array must have at least two ULONG elements to hold an Ethernet or token ring physical address. The
		/// first six bytes of this array receive the physical address that corresponds to the IPv4 address specified by the DestIP parameter.
		/// </param>
		/// <param name="PhyAddrLen">
		/// On input, a pointer to a ULONG value that specifies the maximum buffer size, in bytes, the application has set aside to receive the physical address
		/// or MAC address. The buffer size should be at least 6 bytes for an Ethernet or token ring physical address
		/// <para>The buffer to receive the physical address is pointed to by the pMacAddr parameter.</para>
		/// <para>On successful output, this parameter points to a value that specifies the number of bytes written to the buffer pointed to by the pMacAddr.</para>
		/// </param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error SendARP(IN_ADDR DestIP, IN_ADDR SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);

		/// <summary>
		/// The SendARP function sends an Address Resolution Protocol (ARP) request to obtain the physical address that corresponds to the specified destination
		/// IPv4 address.
		/// </summary>
		/// <param name="DestIP">
		/// The destination IPv4 address, in the form of an IPAddr structure. The ARP request attempts to obtain the physical address that corresponds to this
		/// IPv4 address.
		/// </param>
		/// <param name="SrcIP">
		/// The source IPv4 address of the sender, in the form of an IPAddr structure. This parameter is optional and is used to select the interface to send the
		/// request on for the ARP entry. The caller may specify zero corresponding to the INADDR_ANY IPv4 address for this parameter.
		/// </param>
		/// <returns>The physical address that corresponds to the IPv4 address specified by the DestIP parameter.</returns>
		public static byte[] SendARP(IN_ADDR DestIP, IN_ADDR SrcIP = default(IN_ADDR))
		{
			uint len = 6;
			var ret = new byte[(int)len];
			SendARP(DestIP, SrcIP, ret, ref len).ThrowIfFailed();
			return ret;
		}

		/// <summary>The SetIpNetEntry function modifies an existing ARP entry in the ARP table on the local computer.</summary>
		/// <param name="pArpEntry">A pointer to a MIB_IPNETROW structure. The information in this structure specifies the entry to modify and the new information for the entry. The caller must specify values for all members of this structure.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error SetIpNetEntry(ref MIB_IPNETROW pArpEntry);

		/// <summary>The SetIpNetEntry2 function sets the physical address of an existing neighbor IP address entry on the local computer.</summary>
		/// <param name="Row">A pointer to a MIB_IPNET_ROW2 structure entry for a neighbor IP address entry.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern Win32Error SetIpNetEntry2(ref MIB_IPNET_ROW2 Row);

		/// <summary>
		/// The UnenableRouter function decrements the reference count that tracks the number of requests to enable IPv4 forwarding. When this reference count
		/// reaches zero, UnenableRouter turns off IPv4 forwarding on the local computer.
		/// </summary>
		/// <param name="pOverlapped">
		/// A pointer to an OVERLAPPED structure. This structure should be the same as the one used in the call to the EnableRouter function.
		/// </param>
		/// <param name="lpdwEnableCount">An optional pointer to a DWORD variable. This variable receives the number of references remaining.</param>
		/// <returns>If the function succeeds, the return value is NO_ERROR. If the function fails, the return value is an error code.</returns>
		[PInvokeData("Iphlpapi.h")]
		[DllImport(Lib.IpHlpApi, ExactSpelling = true)]
		public static extern unsafe Win32Error UnenableRouter(System.Threading.NativeOverlapped* pOverlapped, out uint lpdwEnableCount);

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct FIXED_INFO
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HOSTNAME_LEN + 4)]
			public string HostName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_HOSTNAME_LEN + 4)]
			public string DomainName;
			public IntPtr CurrentDnsServer;
			public IP_ADDR_STRING DnsServerList;
			public NetBiosNodeType NodeType;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_SCOPE_ID_LEN + 4)]
			public string ScopeId;
			[MarshalAs(UnmanagedType.Bool)]
			public bool EnableRouting;
			[MarshalAs(UnmanagedType.Bool)]
			public bool EnableProxy;
			[MarshalAs(UnmanagedType.Bool)]
			public bool EnableDns;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_ADDRESSES
		{
			public uint Length;
			public uint IfIndex;
			public IntPtr Next;
			[MarshalAs(UnmanagedType.LPStr)]
			public string AdapterName;
			public IntPtr FirstUnicastAddress;
			public IntPtr FirstAnycastAddress;
			public IntPtr FirstMulticastAddress;
			public IntPtr FirstDnsServerAddress;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string DnsSuffix;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string Description;
			[MarshalAs(UnmanagedType.LPWStr)]
			public string FriendlyName;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ADAPTER_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;
			public uint PhysicalAddressLength;
			public IP_ADAPTER_FLAGS Flags;
			public uint Mtu;
			public IFTYPE IfType;
			public IF_OPER_STATUS OperStatus;
			private uint Ipv6IfIndex;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public SCOPE_LEVEL[] ZoneIndices;
			public IntPtr FirstPrefix;
			public ulong TrasmitLinkSpeed;
			public ulong ReceiveLinkSpeed;
			public IntPtr FirstWinsServerAddress;
			public IntPtr FirstGatewayAddress;
			public uint Ipv4Metric;
			public uint Ipv6Metric;
			public NET_LUID Luid;
			public SOCKET_ADDRESS Dhcpv4Server;
			public uint CompartmentId;
			public Guid NetworkGuid;
			public NET_IF_CONNECTION_TYPE ConnectionType;
			public TUNNEL_TYPE TunnelType;
			public SOCKET_ADDRESS Dhcpv6Server;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DHCPV6_DUID_LENGTH)]
			public byte[] Dhcpv6ClientDuid;
			public uint Dhcpv6ClientDuidLength;
			public uint Dhcpv6Iaid;
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_ANYCAST_ADDRESS
		{
			public uint Length;
			public IP_ADAPTER_CAST_FLAGS Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_DNS_SERVER_ADDRESS
		{
			public uint Length;
			public uint Reserved;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_DNS_SUFFIX
		{
			public IntPtr Next;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_DNS_SUFFIX_STRING_LENGTH)]
			public string String;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_GATEWAY_ADDRESS
		{
			public uint Length;
			public uint Reserved;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_INDEX_MAP
		{
			public uint Index;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_NAME)]
			public string Name;
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_MULTICAST_ADDRESS
		{
			public uint Length;
			public IP_ADAPTER_CAST_FLAGS Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_PREFIX
		{
			public uint Length;
			public uint Flags;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
			public uint PrefixLength;
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_ADAPTER_WINS_SERVER_ADDRESS
		{
			public uint Length;
			public uint Reserved;
			public IntPtr Next;
			public SOCKET_ADDRESS Address;
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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
						yield return DnsServerList;
					foreach (var i in DnsServerList.Next.LinkedListToIEnum<IP_ADDR_STRING>(s => s.Next))
						yield return i;
				}
			}
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIB_IF_ROW2
		{
			public NET_LUID InterfaceLuid;
			public uint InterfaceIndex;
			public Guid InterfaceGuid;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IF_MAX_STRING_SIZE + 1)]
			public string Alias;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = IF_MAX_STRING_SIZE + 1)]
			public string Description;
			public uint physicalAddressLength;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PhysicalAddress;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = IF_MAX_PHYS_ADDRESS_LENGTH)]
			public byte[] PermanentPhysicalAddress;
			public uint Mtu;
			public IFTYPE Type;
			public TUNNEL_TYPE TunnelType;
			public NDIS_MEDIUM MediaType;
			public NDIS_PHYSICAL_MEDIUM PhysicalMediumType;
			public NET_IF_ACCESS_TYPE AccessType;
			public NET_IF_DIRECTION_TYPE DirectionType;
			public InterfaceAndOperStatusFlags InterfaceAndOperStatusFlags;
			public IF_OPER_STATUS OperStatus;
			public NET_IF_ADMIN_STATUS AdminStatus;
			public NET_IF_MEDIA_CONNECT_STATE MediaConnectState;
			public Guid NetworkGuid;
			public NET_IF_CONNECTION_TYPE ConnectionType;
			public ulong TransmitLinkSpeed;
			public ulong ReceiveLinkSpeed;
			public ulong InOctets;
			public ulong InUcastPkts;
			public ulong InNUcastPkts;
			public ulong InDiscards;
			public ulong InErrors;
			public ulong InUnknownProtos;
			public ulong InUcastOctets;
			public ulong InMulticastOctets;
			public ulong InBroadcastOctets;
			public ulong OutOctets;
			public ulong OutUcastPkts;
			public ulong OutNUcastPkts;
			public ulong OutDiscards;
			public ulong OutErrors;
			public ulong OutUcastOctets;
			public ulong OutMulticastOctets;
			public ulong OutBroadcastOctets;
			public ulong OutQLen;

			public MIB_IF_ROW2(uint interfaceIndex) : this()
			{
				InterfaceIndex = interfaceIndex;
			}

			public MIB_IF_ROW2(NET_LUID interfaceLuid) : this()
			{
				InterfaceLuid = interfaceLuid;
			}
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[Flags]
		public enum MIB_IPNET_ROW2_FLAGS : uint
		{
			IsRouther = 1,
			IsUnreachable = 2
		}

		/// <summary>The MIB_IPNETROW structure contains information for an Address Resolution Protocol (ARP) table entry for an IPv4 address.</summary>
		[PInvokeData("Iphlpapi.h")]
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

			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV4, macAddr) { InterfaceLuid = ifLuid; }

			public MIB_IPNET_ROW2(SOCKADDR_IN ipV4, uint ifIdx, byte[] macAddr = null) : this(ipV4, macAddr) { InterfaceIndex = ifIdx; }

			private MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, byte[] macAddr) : this()
			{
				Address.Ipv6 = ipV6;
				SetMac(macAddr);
			}

			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, NET_LUID ifLuid, byte[] macAddr = null) : this(ipV6, macAddr) { InterfaceLuid = ifLuid; }

			public MIB_IPNET_ROW2(SOCKADDR_IN6 ipV6, uint ifIdx, byte[] macAddr = null) : this(ipV6, macAddr) { InterfaceIndex = ifIdx; }

			private void SetMac(byte[] macAddr)
			{
				if (macAddr == null) return;
				PhysicalAddressLength = IF_MAX_PHYS_ADDRESS_LENGTH;
				PhysicalAddress = new byte[IF_MAX_PHYS_ADDRESS_LENGTH];
				Array.Copy(macAddr, PhysicalAddress, 6);
			}

			public override string ToString() => $"{Address}; MAC:{PhysicalAddressToString(PhysicalAddress)}; If:{(InterfaceIndex != 0 ? InterfaceIndex.ToString() : InterfaceLuid.ToString())}";
		}

		/// <summary>The MIB_IPNETROW structure contains information for an Address Resolution Protocol (ARP) table entry for an IPv4 address.</summary>
		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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
		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_TCPROW
		{
			public MIB_TCP_STATE dwState;
			public uint dwLocalAddr;
			public uint dwLocalPort;
			public uint dwRemoteAddr;
			public uint dwRemotePort;
		}

		[PInvokeData("Iphlpapi.h")]
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
		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDP6ROW
		{
			public IN6_ADDR dwLocalAddr;
			public uint dwLocalScopeId;
			public uint dwLocalPort;
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDP6ROW_OWNER_PID
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public byte[] ucLocalAddr;
			public uint dwLocalScopeId;
			public uint dwLocalPort;
			public uint dwOwningPid;
		}

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPROW
		{
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
		}

		[PInvokeData("Iphlpapi.h")]
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

		[PInvokeData("Iphlpapi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MIB_UDPROW_OWNER_PID
		{
			public IN_ADDR dwLocalAddr;
			public uint dwLocalPort;
			public uint dwOwningPid;
		}

		[PInvokeData("Iphlpapi.h")]
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

			public override string ToString() => $"{NetLuidIndex}:{IfType}";
		}

		[CorrespondingType(typeof(IP_ADAPTER_INDEX_MAP))]
		[DefaultProperty(nameof(Adapter))]
		public class IP_INTERFACE_INFO : SafeElementArray<IP_ADAPTER_INDEX_MAP, int, CoTaskMemoryMethods>
		{
			public IP_INTERFACE_INFO(uint byteSize) : base((int)byteSize, 0) { }

			public IP_ADAPTER_INDEX_MAP[] Adapter { get => Elements; set => Elements = value; }
			public int NumAdapters => Count;

			public static implicit operator IntPtr(IP_INTERFACE_INFO iii) => iii.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(IN_ADDR))]
		[DefaultProperty(nameof(Address))]
		public class IP_UNIDIRECTIONAL_ADAPTER_ADDRESS : SafeElementArray<IN_ADDR, uint, CoTaskMemoryMethods>
		{
			public IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(uint byteSize) : base((int)byteSize, 0) { }

			public IN_ADDR[] Address { get => Elements; set => Elements = value; }
			public uint NumAdapters => Count;

			public static implicit operator IntPtr(IP_UNIDIRECTIONAL_ADAPTER_ADDRESS table) => table.DangerousGetHandle();
		}

		/// <summary>The MIB_IF_TABLE2 structure contains a table of logical and physical interface entries.</summary>
		[PInvokeData("Iphlpapi.h")]
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

			public IEnumerator<MIB_IF_ROW2> GetEnumerator() => ((IEnumerable<MIB_IF_ROW2>)Elements).GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			private static bool Free(IntPtr handle) { FreeMibTable(handle); return true; }
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_IFROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IFTABLE : SafeElementArray<MIB_IFROW, uint, CoTaskMemoryMethods>
		{
			public MIB_IFTABLE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_IFROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_IFTABLE table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_IPADDRROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IPADDRTABLE : SafeElementArray<MIB_IPADDRROW, uint, CoTaskMemoryMethods>
		{
			public MIB_IPADDRTABLE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_IPADDRROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_IPADDRTABLE table) => table.DangerousGetHandle();
		}

		/// <summary>The MIB_IPNET_TABLE2 structure contains a table of neighbor IP address entries.</summary>
		[PInvokeData("Iphlpapi.h")]
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

			public IEnumerator<MIB_IPNET_ROW2> GetEnumerator() => ((IEnumerable<MIB_IPNET_ROW2>)Elements).GetEnumerator();

			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			private static bool Free(IntPtr handle) { FreeMibTable(handle); return true; }
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_IPNETROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_IPNETTABLE : SafeElementArray<MIB_IPNETROW, uint, CoTaskMemoryMethods>
		{
			public MIB_IPNETTABLE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_IPNETROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_IPNETTABLE table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_TCP6ROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE_OWNER_MODULE : SafeElementArray<MIB_TCP6ROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_TCP6TABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_TCP6ROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCP6TABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366905
		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_TCP6ROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCP6TABLE_OWNER_PID : SafeElementArray<MIB_TCP6ROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_TCP6TABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_TCP6ROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCP6TABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_TCPROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE : SafeElementArray<MIB_TCPROW, uint, CoTaskMemoryMethods>
		{
			public MIB_TCPTABLE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_TCPROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCPTABLE table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_TCPROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE_OWNER_MODULE : SafeElementArray<MIB_TCPROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_TCPTABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_TCPROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCPTABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		// https://msdn2.microsoft.com/en-us/library/aa366921.aspx
		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_TCPROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_TCPTABLE_OWNER_PID : SafeElementArray<MIB_TCPROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_TCPTABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_TCPROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_TCPTABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_UDP6ROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE : SafeElementArray<MIB_UDP6ROW, uint, CoTaskMemoryMethods>
		{
			public MIB_UDP6TABLE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_UDP6ROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDP6TABLE table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_UDP6ROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE_OWNER_MODULE : SafeElementArray<MIB_UDP6ROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_UDP6TABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_UDP6ROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDP6TABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366905
		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_UDP6ROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDP6TABLE_OWNER_PID : SafeElementArray<MIB_UDP6ROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_UDP6TABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_UDP6ROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDP6TABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_UDPROW))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE : SafeElementArray<MIB_UDPROW, uint, CoTaskMemoryMethods>
		{
			public MIB_UDPTABLE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_UDPROW[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDPTABLE table) => table.DangerousGetHandle();
		}

		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_UDPROW_OWNER_MODULE))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE_OWNER_MODULE : SafeElementArray<MIB_UDPROW_OWNER_MODULE, uint, CoTaskMemoryMethods>
		{
			public MIB_UDPTABLE_OWNER_MODULE(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_UDPROW_OWNER_MODULE[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDPTABLE_OWNER_MODULE table) => table.DangerousGetHandle();
		}

		// https://msdn2.microsoft.com/en-us/library/aa366921.aspx
		[PInvokeData("Iphlpapi.h")]
		[CorrespondingType(typeof(MIB_UDPROW_OWNER_PID))]
		[DefaultProperty(nameof(table))]
		public class MIB_UDPTABLE_OWNER_PID : SafeElementArray<MIB_UDPROW_OWNER_PID, uint, CoTaskMemoryMethods>
		{
			public MIB_UDPTABLE_OWNER_PID(uint byteSize) : base((int)byteSize, 0) { }

			public uint dwNumEntries => Count;
			public MIB_UDPROW_OWNER_PID[] table { get => Elements; set => Elements = value; }

			public static implicit operator IntPtr(MIB_UDPTABLE_OWNER_PID table) => table.DangerousGetHandle();
		}

		public class PIP_PER_ADAPTER_INFO : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			public PIP_PER_ADAPTER_INFO(uint byteSize) : base((int)byteSize) { }

			public bool AutoconfigActive => !IsInvalid && handle.ToStructure<IP_PER_ADAPTER_INFO>().AutoconfigActive;
			public bool AutoconfigEnabled => !IsInvalid && handle.ToStructure<IP_PER_ADAPTER_INFO>().AutoconfigEnabled;
			public IEnumerable<IP_ADDR_STRING> DnsServerList => IsInvalid ? new IP_ADDR_STRING[0] : handle.ToStructure<IP_PER_ADAPTER_INFO>().DnsServers;
			public static implicit operator IntPtr(PIP_PER_ADAPTER_INFO info) => info.DangerousGetHandle();
		}
	}
}