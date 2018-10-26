using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

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

		/// <summary>
		/// <para>
		/// The <c>IP_DAD_STATE</c> enumeration specifies information about the duplicate address detection (DAD) state for an IPv4 or IPv6 address.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_DAD_STATE</c> enumeration is used in the <c>DadState</c> member of the IP_ADAPTER_UNICAST_ADDRESS structure.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>IP_DAD_STATE</c> enumeration is defined in the Nldef.h header file which is automatically included by the
		/// Iptypes.h header file. The Nldef.h and Iptypes.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-nl_dad_state typedef enum NL_DAD_STATE { NldsInvalid ,
		// NldsTentative , NldsDuplicate , NldsDeprecated , NldsPreferred , IpDadStateInvalid , IpDadStateTentative , IpDadStateDuplicate ,
		// IpDadStateDeprecated , IpDadStatePreferred } ;
		[PInvokeData("nldef.h", MSDNShortId = "2c67215c-6349-418e-9004-b869d6f5baef")]
		public enum IP_DAD_STATE : uint
		{
			/// <summary>The DAD state is invalid.</summary>
			IpDadStateInvalid = 0,

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
		/// <para>
		/// The <c>IP_PREFIX_ORIGIN</c> enumeration specifies the origin of an IPv4 or IPv6 address prefix, and is used with the
		/// IP_ADAPTER_UNICAST_ADDRESS structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_PREFIX_ORIGIN</c> enumeration is used in the <c>PrefixOrigin</c> member of the IP_ADAPTER_UNICAST_ADDRESS structure.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>IP_PREFIX_ORIGIN</c> enumeration is defined in the Nldef.h header file which is automatically included by
		/// the Iptypes.h header file. In order to use the <c>IP_PREFIX_ORIGIN</c> enumeration, the Winsock2.h header file must be included
		/// before the Iptypes.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/nldef/ne-nldef-nl_prefix_origin typedef enum NL_PREFIX_ORIGIN {
		// IpPrefixOriginOther , IpPrefixOriginManual , IpPrefixOriginWellKnown , IpPrefixOriginDhcp , IpPrefixOriginRouterAdvertisement ,
		// IpPrefixOriginUnchanged } ;
		[PInvokeData("nldef.h", MSDNShortId = "fd7e7bbb-8596-4a72-ba63-d898f0048a11")]
		public enum IP_PREFIX_ORIGIN : uint
		{
			/// <summary>The IP prefix was provided by a source other than those defined in this enumeration.</summary>
			IpPrefixOriginOther = 0,

			/// <summary>The IP address prefix was manually specified.</summary>
			IpPrefixOriginManual,

			/// <summary>The IP address prefix is from a well known source.</summary>
			IpPrefixOriginWellKnown,

			/// <summary>The IP address prefix was provided by DHCP settings.</summary>
			IpPrefixOriginDhcp,

			/// <summary>The IP address prefix was obtained through a router advertisement (RA).</summary>
			IpPrefixOriginRouterAdvertisement,

			/// <summary>
			/// The IP address prefix should be unchanged. This value is used when setting the properties for a unicast IP interface when the
			/// value for the IP prefix origin should be left unchanged.
			/// </summary>
			IpPrefixOriginUnchanged,
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
		public enum IP_SUFFIX_ORIGIN : uint
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
			/// The IP address suffix should be unchanged. This value is used when setting the properties for a unicast IP interface when the
			/// value for the IP suffix origin should be left unchanged.
			/// </summary>
			IpSuffixOriginUnchanged,
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

		/// <summary>
		/// <para>The NET_IF_ACCESS_TYPE enumeration type specifies the NDIS network interface access type.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_access_type typedef enum _NET_IF_ACCESS_TYPE {
		// NET_IF_ACCESS_LOOPBACK , NET_IF_ACCESS_BROADCAST , NET_IF_ACCESS_POINT_TO_POINT , NET_IF_ACCESS_POINT_TO_MULTI_POINT ,
		// NET_IF_ACCESS_MAXIMUM } NET_IF_ACCESS_TYPE, *PNET_IF_ACCESS_TYPE;
		[PInvokeData("ifdef.h", MSDNShortId = "0f8c0866-5ecb-4632-b3bf-cadeee74ce5f")]
		public enum NET_IF_ACCESS_TYPE
		{
			/// <summary>
			/// Specifies the loopback access type. This access type indicates that the interface loops back transmit data as receive data.
			/// </summary>
			NET_IF_ACCESS_LOOPBACK = 1,

			/// <summary>
			/// Specifies the LAN access type, which includes Ethernet. This access type indicates that the interface provides native support
			/// for multicast or broadcast services.
			/// </summary>
			NET_IF_ACCESS_BROADCAST,

			/// <summary>Specifies point-to-point access that supports CoNDIS and WAN, except for non-broadcast multi-access (NBMA) interfaces.</summary>
			NET_IF_ACCESS_POINT_TO_POINT,

			/// <summary>
			/// Specifies point-to-multipoint access that supports non-broadcast multi-access (NBMA) media, including the "RAS Internal"
			/// interface, and native (non-LANE) ATM.
			/// </summary>
			NET_IF_ACCESS_POINT_TO_MULTI_POINT,

			/// <summary>A maximum value for testing purposes.</summary>
			NET_IF_ACCESS_MAXIMUM,
		}

		/// <summary>
		/// <para>
		/// The NET_IF_ADMIN_STATUS enumeration type specifies the NDIS network interface administrative status, as described in RFC 2863.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>For more information on RFC 2863, see "The Interfaces Group MIB".</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_admin_status typedef enum _NET_IF_ADMIN_STATUS {
		// NET_IF_ADMIN_STATUS_UP , NET_IF_ADMIN_STATUS_DOWN , NET_IF_ADMIN_STATUS_TESTING } NET_IF_ADMIN_STATUS, *PNET_IF_ADMIN_STATUS;
		[PInvokeData("ifdef.h", MSDNShortId = "9f6978a9-a779-49c6-b642-c411fa764972")]
		public enum NET_IF_ADMIN_STATUS
		{
			/// <summary>
			/// Specifies that the interface is initialized and enabled, but the interface is not necessarily ready to transmit and receive
			/// network data because that depends on the operational status of the interface. For more information about the operational
			/// status of an interface, see OID_GEN_OPERATIONAL_STATUS.
			/// </summary>
			NET_IF_ADMIN_STATUS_UP = 1,

			/// <summary>Specifies that the interface is down, and this interface cannot be used to transmit or receive network data.</summary>
			NET_IF_ADMIN_STATUS_DOWN,

			/// <summary>Specifies that the interface is in a test mode, and no network data can be transmitted or received.</summary>
			NET_IF_ADMIN_STATUS_TESTING,
		}

		/// <summary>
		/// <para>The NET_IF_CONNECTION_TYPE enumeration type specifies the NDIS network interface connection type.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_connection_type typedef enum _NET_IF_CONNECTION_TYPE {
		// NET_IF_CONNECTION_DEDICATED , NET_IF_CONNECTION_PASSIVE , NET_IF_CONNECTION_DEMAND , NET_IF_CONNECTION_MAXIMUM }
		// NET_IF_CONNECTION_TYPE, *PNET_IF_CONNECTION_TYPE;
		[PInvokeData("ifdef.h", MSDNShortId = "af1ffcf2-65cf-4d80-b702-a843b6d19fdc")]
		public enum NET_IF_CONNECTION_TYPE : uint
		{
			/// <summary>
			/// Specifies the dedicated connection type. The connection comes up automatically when media sense is TRUE. For example, an
			/// Ethernet connection is dedicated.
			/// </summary>
			NET_IF_CONNECTION_DEDICATED = 1,

			/// <summary>
			/// Specifies the passive connection type. The other end must bring up the connection to the local station. For example, the RAS
			/// interface is passive.
			/// </summary>
			NET_IF_CONNECTION_PASSIVE,

			/// <summary>
			/// Specifies the demand-dial connection type. A demand-dial connection comes up in response to a local action--for example,
			/// sending a packet.
			/// </summary>
			NET_IF_CONNECTION_DEMAND,

			/// <summary>A maximum value for testing purposes.</summary>
			NET_IF_CONNECTION_MAXIMUM,
		}

		/// <summary>
		/// <para>The NET_IF_ACCESS_TYPE enumeration type specifies the NDIS network interface direction type.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_direction_type typedef enum _NET_IF_DIRECTION_TYPE {
		// NET_IF_DIRECTION_SENDRECEIVE , NET_IF_DIRECTION_SENDONLY , NET_IF_DIRECTION_RECEIVEONLY , NET_IF_DIRECTION_MAXIMUM }
		// NET_IF_DIRECTION_TYPE, *PNET_IF_DIRECTION_TYPE;
		[PInvokeData("ifdef.h", MSDNShortId = "e9f80162-5a1c-44c8-af31-a0c0f986edc2")]
		public enum NET_IF_DIRECTION_TYPE
		{
			/// <summary>
			/// Indicates the send and receive direction type. This direction type indicates that the NDIS network interface can send and
			/// receive data.
			/// </summary>
			NET_IF_DIRECTION_SENDRECEIVE,

			/// <summary>
			/// Indicates the send only direction type. This direction type indicates that the NDIS network interface can only send data.
			/// </summary>
			NET_IF_DIRECTION_SENDONLY,

			/// <summary>
			/// Indicates the receive only direction type. This direction type indicates that the NDIS network interface can only receive data.
			/// </summary>
			NET_IF_DIRECTION_RECEIVEONLY,

			/// <summary>A maximum value for testing purposes.</summary>
			NET_IF_DIRECTION_MAXIMUM,
		}

		/// <summary>
		/// <para>The NET_IF_MEDIA_CONNECT_STATE enumeration type specifies the NDIS network interface connection state.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The NDIS_MEDIA_CONNECT_STATE enumeration type, used to describe NDIS interface providers in the OID_GEN_MEDIA_CONNECT_STATUS_EX
		/// OID, is equivalent to this enumeration.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ifdef/ne-ifdef-_net_if_media_connect_state typedef enum
		// _NET_IF_MEDIA_CONNECT_STATE { MediaConnectStateUnknown , MediaConnectStateConnected , MediaConnectStateDisconnected }
		// NET_IF_MEDIA_CONNECT_STATE, *PNET_IF_MEDIA_CONNECT_STATE;
		[PInvokeData("ifdef.h", MSDNShortId = "5af5e050-4b2b-45a9-8549-3a3818d7b06f")]
		public enum NET_IF_MEDIA_CONNECT_STATE
		{
			/// <summary>The connection state of the interface is unknown.</summary>
			MediaConnectStateUnknown,

			/// <summary>The interface is connected to the network.</summary>
			MediaConnectStateConnected,

			/// <summary>The interface is not connected to the network.</summary>
			MediaConnectStateDisconnected,
		}

		/// <summary>The node type of the local computer.</summary>
		[Flags]
		public enum NetBiosNodeType
		{
			/// <summary>The unknown node type.</summary>
			UNKNOWN_NODETYPE = 0,

			/// <summary>A broadcast node type.</summary>
			BROADCAST_NODETYPE = 1,

			/// <summary>A peer to peer node type.</summary>
			PEER_TO_PEER_NODETYPE = 2,

			/// <summary>A mixed node type.</summary>
			MIXED_NODETYPE = 4,

			/// <summary>A hybrid node type.</summary>
			HYBRID_NODETYPE = 8
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
			/// properly. While the State member of MIB_IPNET_ROW2 is NlnsStale, no action occurs until a packet is sent. The NlnsStale state
			/// is entered upon receiving an unsolicited neighbor discovery message that updates the cached IP address. Receipt of such a
			/// message does not confirm reachability, and entering the NlnsStale state insures reachability is verified quickly if the entry
			/// is actually being used. However, reachability is not actually verified until the entry is actually used.
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
		/// <para>The <c>SCOPE_LEVEL</c> enumeration is used with the IP_ADAPTER_ADDRESSES structure to identify scope levels for IPv6 addresses.</para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>SCOPE_LEVEL</c> enumeration is used in the <c>ZoneIndices</c> member of the IP_ADAPTER_ADDRESSES structure.</para>
		/// <para>
		/// On Windows Vista and later as well as on the Microsoft Windows Software Development Kit (SDK), the organization of header files
		/// has changed and the <c>SCOPE_LEVEL</c> enumeration type is defined in the Ws2def.h header file. Note that the Ws2def.h header
		/// file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2def/ne-ws2def-scope_level typedef enum SCOPE_LEVEL { ScopeLevelInterface ,
		// ScopeLevelLink , ScopeLevelSubnet , ScopeLevelAdmin , ScopeLevelSite , ScopeLevelOrganization , ScopeLevelGlobal , ScopeLevelCount
		// } ;
		[PInvokeData("ws2def.h", MSDNShortId = "714ab69e-b1fa-42a2-a92c-e4051b969a19")]
		public enum SCOPE_LEVEL : uint
		{
			/// <summary>The scope is interface-level.</summary>
			ScopeLevelInterface = 1,

			/// <summary>The scope is link-level.</summary>
			ScopeLevelLink = 2,

			/// <summary>The scope is subnet-level.</summary>
			ScopeLevelSubnet = 3,

			/// <summary>The scope is admin-level.</summary>
			ScopeLevelAdmin = 4,

			/// <summary>The scope is site-level.</summary>
			ScopeLevelSite = 5,

			/// <summary>The scope is organization-level.</summary>
			ScopeLevelOrganization = 8,

			/// <summary>The scope is global.</summary>
			ScopeLevelGlobal = 14
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

		public interface ILinkedListElement<T> where T : struct
		{
			T? GetNext();
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
			var e = GetAdaptersAddresses((uint)Family, Flags, IntPtr.Zero, IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				e.ThrowIfFailed();
			}

			var mem = new SafeCoTaskMemHandle((int)len);
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
			var e = GetExtendedTcpTable(IntPtr.Zero, ref len, false, (uint)ulAf, TableClass);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			var mem = (T)Activator.CreateInstance(typeof(T), len);
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
			var e = GetExtendedUdpTable(IntPtr.Zero, ref len, false, (uint)ulAf, TableClass);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			var mem = (T)Activator.CreateInstance(typeof(T), len);
			GetExtendedUdpTable(mem.DangerousGetHandle(), ref len, sorted, (uint)ulAf, TableClass).ThrowIfFailed();
			return mem;
		}

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
			var e = GetIfTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			var mem = new MIB_IFTABLE(len);
			GetIfTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

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
			var e = GetInterfaceInfo(IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			var mem = new IP_INTERFACE_INFO(len);
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
			var e = GetIpAddrTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			var mem = new MIB_IPADDRTABLE(len);
			GetIpAddrTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

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
			var e = GetIpNetTable(IntPtr.Zero, ref len, false);
			if (e != Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				e.ThrowIfFailed();
			}

			var mem = new MIB_IPNETTABLE(len);
			GetIpNetTable(mem, ref len, sorted).ThrowIfFailed();
			return mem;
		}

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
			var mem = SafeCoTaskMemHandle.CreateFromStructure<FIXED_INFO>();
			var len = (uint)mem.Size;
			var e = GetNetworkParams((IntPtr)mem, ref len);
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
			var e = GetPerAdapterInfo(IfIndex, IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				e.ThrowIfFailed();
			}

			var mem = new PIP_PER_ADAPTER_INFO(len);
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
			var e = GetUniDirectionalAdapterInfo(IntPtr.Zero, ref len);
			if (e != Win32Error.ERROR_MORE_DATA)
			{
				e.ThrowIfFailed();
			}

			var mem = new IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(len);
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
		public static string PhysicalAddressToString(byte[] physAddr) => $"{physAddr[0]:X}-{physAddr[1]:X}-{physAddr[2]:X}-{physAddr[3]:X}-{physAddr[4]:X}-{physAddr[5]:X}";

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
			var ret = new byte[(int)len];
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

		private static IEnumerable<T> GetLinkedList<T>(this T start, Func<T, bool> includeFirst) where T : struct, ILinkedListElement<T>
		{
			if (includeFirst(start))
				yield return start;
			for (var cur = ((ILinkedListElement<T>)start).GetNext(); cur != null; cur = ((ILinkedListElement<T>)cur).GetNext())
				yield return cur.Value;
			yield break;
		}

		/// <summary>
		/// <para>
		/// The <c>IP_ADAPTER_INDEX_MAP</c> structure stores the interface index associated with a network adapter with IPv4 enabled together
		/// with the name of the network adapter.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>The <c>IP_ADAPTER_INDEX_MAP</c> structure is specific to network adapters with IPv4 enabled.</para>
		/// <para>
		/// An adapter index may change when the adapter is disabled and then enabled, or under other circumstances, and should not be
		/// considered persistent.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>Name</c> member of the <c>IP_ADAPTER_INDEX_MAP</c> structure may be a Unicode string of the
		/// GUID for the network interface (the string begins with the '{' character).
		/// </para>
		/// <para>
		/// This structure is defined in the Ipexport.h header file which is automatically included in the Iphlpapi.h header file. The
		/// Ipexport.h header file should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_adapter_index_map typedef struct
		// _IP_ADAPTER_INDEX_MAP { ULONG Index; WCHAR Name[MAX_ADAPTER_NAME]; } IP_ADAPTER_INDEX_MAP, *PIP_ADAPTER_INDEX_MAP;
		[PInvokeData("ipexport.h", MSDNShortId = "83d95ef3-13a4-4124-84cd-3016e9fb4446")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct IP_ADAPTER_INDEX_MAP
		{
			/// <summary>
			/// <para>The interface index associated with the network adapter.</para>
			/// </summary>
			public uint Index;

			/// <summary>
			/// <para>A pointer to a Unicode string that contains the name of the adapter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_ADAPTER_NAME)]
			public string Name;

			/// <inheritdoc/>
			public override string ToString() => Name;
		}

		/// <summary>
		/// A <c>NET_LUID</c> union can be accessed as a 64-bit value that identifies an NDIS network interface or as a structure that
		/// contains the associated interface index and type.
		/// </summary>
		/// <returns></returns>
		// union NET_LUID { ULONG64 Value; struct { ULONG64 Reserved :24; ULONG64 NetLuidIndex :24; ULONG64 IfType :16; } Info;}; https://msdn.microsoft.com/en-us/library/windows/hardware/ff568747(v=vs.85).aspx
		[PInvokeData("Ifdef.h", MSDNShortId = "ff568747")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NET_LUID
		{
			/// <summary>The complete NET_LUID 64 bit value that includes an index and interface type.</summary>
			public ulong Value;

			/// <summary>Initializes a new instance of the <see cref="NET_LUID"/> struct.</summary>
			/// <param name="index">
			/// A 24-bit index that NDIS allocates when an interface provider calls the NdisIfAllocateNetLuidIndex function. This index is
			/// used to distinguish between multiple interfaces that have the same interface type. Therefore, this value is unique within the
			/// local computer.
			/// </param>
			/// <param name="type">
			/// A 16-bit value that specifies an Internet Assigned Numbers Authority (IANA) interface type. For example,
			/// IF_TYPE_ETHERNET_CSMACD (6) is the value for IfType that is assigned to any Ethernet-like interface. For a list of interface
			/// types, see NDIS Interface Types.
			/// </param>
			public NET_LUID(uint index, IFTYPE type) => Value = (index << 24) | ((ulong)type << 48);

			/// <summary>
			/// A 24-bit index that NDIS allocates when an interface provider calls the NdisIfAllocateNetLuidIndex function. This index is
			/// used to distinguish between multiple interfaces that have the same interface type. Therefore, this value is unique within the
			/// local computer.
			/// </summary>
			public uint NetLuidIndex
			{
				get => (uint)((Value & 0x0000FFFFFF000000) >> 24);
				set => Value = (value << 24) | Value;
			}

			/// <summary>
			/// A 16-bit value that specifies an Internet Assigned Numbers Authority (IANA) interface type. For example,
			/// IF_TYPE_ETHERNET_CSMACD (6) is the value for IfType that is assigned to any Ethernet-like interface. For a list of interface
			/// types, see NDIS Interface Types.
			/// </summary>
			public IFTYPE IfType
			{
				get => (IFTYPE)((Value & 0xFFFF000000000000) >> 48);
				set => Value = ((ulong)value << 48) | Value;
			}

			/// <inheritdoc/>
			public override string ToString() => $"{NetLuidIndex}:{IfType}";
		}

		/// <summary>
		/// <para>
		/// The <c>IP_INTERFACE_INFO</c> structure contains a list of the network interface adapters with IPv4 enabled on the local system.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IP_INTERFACE_INFO</c> structure is specific to network adapters with IPv4 enabled. The <c>IP_INTERFACE_INFO</c> structure
		/// contains the number of network adapters with IPv4 enabled on the local system and an array of IP_ADAPTER_INDEX_MAP structures
		/// with information on each network adapter with IPv4 enabled. The <c>IP_INTERFACE_INFO</c> structure contains at least one
		/// <c>IP_ADAPTER_INDEX_MAP</c> structure even if the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure indicates
		/// that no network adapters with IPv4 are enabled. When the <c>NumAdapters</c> member of the <c>IP_INTERFACE_INFO</c> structure is
		/// zero, the value of the members of the single <c>IP_ADAPTER_INDEX_MAP</c> structure returned in the <c>IP_INTERFACE_INFO</c>
		/// structure is undefined.
		/// </para>
		/// <para>The <c>IP_INTERFACE_INFO</c> structure can't be used to return information about the loopback interface.</para>
		/// <para>
		/// On Windows Vista and later, the <c>Name</c> member of the IP_ADAPTER_INDEX_MAP structure in the <c>IP_INTERFACE_INFO</c>
		/// structure may be a Unicode string of the GUID for the network interface (the string begins with the '{' character).
		/// </para>
		/// <para>
		/// This structure is defined in the Ipexport.h header file which is automatically included in the Iphlpapi.h header file. The
		/// Ipexport.h header file should never be used directly.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the list of network adapters with IPv4 enabled on the local system and prints various properties
		/// of the first adapter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_interface_info typedef struct _IP_INTERFACE_INFO {
		// LONG NumAdapters; IP_ADAPTER_INDEX_MAP Adapter[1]; } IP_INTERFACE_INFO, *PIP_INTERFACE_INFO;
		[PInvokeData("ipexport.h", MSDNShortId = "287a4574-0a0f-4f20-932b-22bb6f40401d")]
		[CorrespondingType(typeof(IP_ADAPTER_INDEX_MAP))]
		[DefaultProperty(nameof(Adapter))]
		public class IP_INTERFACE_INFO : SafeElementArray<IP_ADAPTER_INDEX_MAP, int, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="IP_INTERFACE_INFO"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public IP_INTERFACE_INFO(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>
			/// An array of IP_ADAPTER_INDEX_MAP structures. Each structure maps an adapter index to that adapter's name. The adapter index
			/// may change when an adapter is disabled and then enabled, or under other circumstances, and should not be considered persistent.
			/// </para>
			/// </summary>
			public IP_ADAPTER_INDEX_MAP[] Adapter { get => Elements; set => Elements = value; }

			/// <summary>
			/// <para>The number of adapters listed in the array pointed to by the <c>Adapter</c> member.</para>
			/// </summary>
			public int NumAdapters => Count;

			/// <summary>Performs an implicit conversion from <see cref="IP_INTERFACE_INFO"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="iii">The IP_INTERFACE_INFO instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(IP_INTERFACE_INFO iii) => iii.DangerousGetHandle();
		}

		/// <summary>
		/// <para>The <c>IP_UNIDIRECTIONAL_ADAPTER_ADDRESS</c> structure stores the IPv4 addresses associated with a unidirectional adapter.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>IP_UNIDIRECTIONAL_ADAPTER_ADDRESS</c> structure is retrieved by the GetUnidirectionalAdapterInfofunction. A unidirectional
		/// adapter is an adapter that can receive IPv4 datagrams, but can't transmit them.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ipexport/ns-ipexport-_ip_unidirectional_adapter_address typedef struct
		// _IP_UNIDIRECTIONAL_ADAPTER_ADDRESS { ULONG NumAdapters; IPAddr Address[1]; } IP_UNIDIRECTIONAL_ADAPTER_ADDRESS, *PIP_UNIDIRECTIONAL_ADAPTER_ADDRESS;
		[PInvokeData("ipexport.h", MSDNShortId = "225b93ae-e34f-4e5b-a699-1fdd342265c6")]
		[CorrespondingType(typeof(IN_ADDR))]
		[DefaultProperty(nameof(Address))]
		public class IP_UNIDIRECTIONAL_ADAPTER_ADDRESS : SafeElementArray<IN_ADDR, uint, CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="IP_UNIDIRECTIONAL_ADAPTER_ADDRESS"/> class.</summary>
			/// <param name="byteSize">Amount of space, in bytes, to reserve.</param>
			public IP_UNIDIRECTIONAL_ADAPTER_ADDRESS(uint byteSize) : base((int)byteSize, 0)
			{
			}

			/// <summary>
			/// <para>
			/// An array of variables of type IPAddr. Each element of the array specifies an IPv4 address associated with this unidirectional adapter.
			/// </para>
			/// </summary>
			public IN_ADDR[] Address { get => Elements; set => Elements = value; }

			/// <summary>
			/// <para>The number of IPv4 addresses pointed to by the <c>Address</c> member.</para>
			/// </summary>
			public uint NumAdapters => Count;

			/// <summary>Performs an implicit conversion from <see cref="IP_UNIDIRECTIONAL_ADAPTER_ADDRESS"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="table">The IP_UNIDIRECTIONAL_ADAPTER_ADDRESS instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IntPtr(IP_UNIDIRECTIONAL_ADAPTER_ADDRESS table) => table.DangerousGetHandle();
		}
	}
}