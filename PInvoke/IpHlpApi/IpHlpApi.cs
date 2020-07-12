using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	/// <summary>Items from the IpHlpApi.dll</summary>
	public static partial class IpHlpApi
	{
		/// <summary/>
		public const int IF_MAX_PHYS_ADDRESS_LENGTH = 32;
		/// <summary/>
		public const int IF_MAX_STRING_SIZE = 256;
		/// <summary/>
		public const int MAX_ADAPTER_ADDRESS_LENGTH = 8;
		/// <summary/>
		public const int MAX_ADAPTER_DESCRIPTION_LENGTH = 128;
		/// <summary/>
		public const int MAX_ADAPTER_NAME = 128;
		/// <summary/>
		public const int MAX_ADAPTER_NAME_LENGTH = 256;
		/// <summary/>
		public const int MAX_DHCPV6_DUID_LENGTH = 130;
		/// <summary/>
		public const int MAX_DNS_SUFFIX_STRING_LENGTH = 256;
		/// <summary/>
		public const int MAX_DOMAIN_NAME_LEN = 128;
		/// <summary/>
		public const int MAX_HOSTNAME_LEN = 128;
		/// <summary/>
		public const int MAX_INTERFACE_NAME_LEN = 256;
		/// <summary/>
		public const int MAX_SCOPE_ID_LEN = 256;
		/// <summary/>
		public const int MAXLEN_IFDESCR = 256;
		/// <summary/>
		public const int MAXLEN_PHYSADDR = 8;
		/// <summary/>
		public const int MIB_IF_TYPE_ETHERNET = 6;
		/// <summary/>
		public const int MIB_IF_TYPE_FDDI = 15;
		/// <summary/>
		public const int MIB_IF_TYPE_LOOPBACK = 24;
		/// <summary/>
		public const int MIB_IF_TYPE_OTHER = 1;
		/// <summary/>
		public const int MIB_IF_TYPE_PPP = 23;
		/// <summary/>
		public const int MIB_IF_TYPE_SLIP = 28;
		/// <summary/>
		public const int MIB_IF_TYPE_TOKENRING = 9;
		/// <summary/>
		public const int TCPIP_OWNING_MODULE_SIZE = 16;

		/// <summary>The type of addresses to retrieve in <see cref="GetAdaptersAddresses(GetAdaptersAddressesFlags, ADDRESS_FAMILY)"/>.</summary>
		[PInvokeData("iptypes.h")]
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

		/// <summary>The interface type as defined by the Internet Assigned Names Authority (IANA).</summary>
		[PInvokeData("ipifcons.h")]
		public enum IFTYPE : uint
		{
			/// <summary>Some other type of network interface.</summary>
			IF_TYPE_OTHER = 1,

			/// <summary/>
			IF_TYPE_REGULAR_1822 = 2,
			/// <summary/>
			IF_TYPE_HDH_1822 = 3,
			/// <summary/>
			IF_TYPE_DDN_X25 = 4,
			/// <summary/>
			IF_TYPE_RFC877_X25 = 5,

			/// <summary>An Ethernet network interface.</summary>
			IF_TYPE_ETHERNET_CSMACD = 6,

			/// <summary/>
			IF_TYPE_IS088023_CSMACD = 7,
			/// <summary/>
			IF_TYPE_ISO88024_TOKENBUS = 8,

			/// <summary>A token ring network interface.</summary>
			IF_TYPE_ISO88025_TOKENRING = 9,

			/// <summary/>
			IF_TYPE_ISO88026_MAN = 10,
			/// <summary/>
			IF_TYPE_STARLAN = 11,
			/// <summary/>
			IF_TYPE_PROTEON_10MBIT = 12,
			/// <summary/>
			IF_TYPE_PROTEON_80MBIT = 13,
			/// <summary/>
			IF_TYPE_HYPERCHANNEL = 14,

			/// <summary>A Fiber Distributed Data Interface (FDDI) network interface.</summary>
			IF_TYPE_FDDI = 15,

			/// <summary/>
			IF_TYPE_LAP_B = 16,
			/// <summary/>
			IF_TYPE_SDLC = 17,

			/// <summary>DS1-MIB</summary>
			IF_TYPE_DS1 = 18,

			/// <summary>Obsolete; see DS1-MIB</summary>
			IF_TYPE_E1 = 19,

			/// <summary/>
			IF_TYPE_BASIC_ISDN = 20,
			/// <summary/>
			IF_TYPE_PRIMARY_ISDN = 21,

			/// <summary>proprietary serial</summary>
			IF_TYPE_PROP_POINT2POINT_SERIAL = 22,

			/// <summary>A PPP network interface.</summary>
			IF_TYPE_PPP = 23,

			/// <summary>A software loopback network interface.</summary>
			IF_TYPE_SOFTWARE_LOOPBACK = 24,

			/// <summary>CLNP over IP</summary>
			IF_TYPE_EON = 25,

			/// <summary/>
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

			/// <summary/>
			IF_TYPE_RS232 = 33,

			/// <summary>Parallel port</summary>
			IF_TYPE_PARA = 34,

			/// <summary/>
			IF_TYPE_ARCNET = 35,
			/// <summary/>
			IF_TYPE_ARCNET_PLUS = 36,

			/// <summary>An ATM network interface.</summary>
			IF_TYPE_ATM = 37,

			/// <summary/>
			IF_TYPE_MIO_X25 = 38,

			/// <summary>SONET or SDH</summary>
			IF_TYPE_SONET = 39,

			/// <summary/>
			IF_TYPE_X25_PLE = 40,
			/// <summary/>
			IF_TYPE_ISO88022_LLC = 41,
			/// <summary/>
			IF_TYPE_LOCALTALK = 42,
			/// <summary/>
			IF_TYPE_SMDS_DXI = 43,

			/// <summary>FRNETSERV-MIB</summary>
			IF_TYPE_FRAMERELAY_SERVICE = 44,

			/// <summary/>
			IF_TYPE_V35 = 45,
			/// <summary/>
			IF_TYPE_HSSI = 46,
			/// <summary/>
			IF_TYPE_HIPPI = 47,

			/// <summary>Generic Modem</summary>
			IF_TYPE_MODEM = 48,

			/// <summary>AAL5 over ATM</summary>
			IF_TYPE_AAL5 = 49,

			/// <summary/>
			IF_TYPE_SONET_PATH = 50,
			/// <summary/>
			IF_TYPE_SONET_VT = 51,

			/// <summary>SMDS InterCarrier Interface</summary>
			IF_TYPE_SMDS_ICIP = 52,

			/// <summary>Proprietary virtual/internal</summary>
			IF_TYPE_PROP_VIRTUAL = 53,

			/// <summary>Proprietary multiplexing</summary>
			IF_TYPE_PROP_MULTIPLEXOR = 54,

			/// <summary>100BaseVG</summary>
			IF_TYPE_IEEE80212 = 55,

			/// <summary/>
			IF_TYPE_FIBRECHANNEL = 56,
			/// <summary/>
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

			/// <summary/>
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

			/// <summary/>
			IF_TYPE_GIGABITETHERNET = 117,
			/// <summary/>
			IF_TYPE_HDLC = 118,
			/// <summary/>
			IF_TYPE_LAP_F = 119,
			/// <summary/>
			IF_TYPE_V37 = 120,

			/// <summary>Multi-Link Protocol</summary>
			IF_TYPE_X25_MLP = 121,

			/// <summary>X.25 Hunt Group</summary>
			IF_TYPE_X25_HUNTGROUP = 122,

			/// <summary/>
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

			/// <summary/>
			IF_TYPE_IF_GSN = 145,
			/// <summary/>
			IF_TYPE_DVBRCC_MACLAYER = 146,
			/// <summary/>
			IF_TYPE_DVBRCC_DOWNSTREAM = 147,
			/// <summary/>
			IF_TYPE_DVBRCC_UPSTREAM = 148,
			/// <summary/>
			IF_TYPE_ATM_VIRTUAL = 149,
			/// <summary/>
			IF_TYPE_MPLS_TUNNEL = 150,
			/// <summary/>
			IF_TYPE_SRP = 151,
			/// <summary/>
			IF_TYPE_VOICEOVERATM = 152,
			/// <summary/>
			IF_TYPE_VOICEOVERFRAMERELAY = 153,
			/// <summary/>
			IF_TYPE_IDSL = 154,
			/// <summary/>
			IF_TYPE_COMPOSITELINK = 155,
			/// <summary/>
			IF_TYPE_SS7_SIGLINK = 156,
			/// <summary/>
			IF_TYPE_PROP_WIRELESS_P2P = 157,
			/// <summary/>
			IF_TYPE_FR_FORWARD = 158,
			/// <summary/>
			IF_TYPE_RFC1483 = 159,
			/// <summary/>
			IF_TYPE_USB = 160,
			/// <summary/>
			IF_TYPE_IEEE8023AD_LAG = 161,
			/// <summary/>
			IF_TYPE_BGP_POLICY_ACCOUNTING = 162,
			/// <summary/>
			IF_TYPE_FRF16_MFR_BUNDLE = 163,
			/// <summary/>
			IF_TYPE_H323_GATEKEEPER = 164,
			/// <summary/>
			IF_TYPE_H323_PROXY = 165,
			/// <summary/>
			IF_TYPE_MPLS = 166,
			/// <summary/>
			IF_TYPE_MF_SIGLINK = 167,
			/// <summary/>
			IF_TYPE_HDSL2 = 168,
			/// <summary/>
			IF_TYPE_SHDSL = 169,
			/// <summary/>
			IF_TYPE_DS1_FDL = 170,
			/// <summary/>
			IF_TYPE_POS = 171,
			/// <summary/>
			IF_TYPE_DVB_ASI_IN = 172,
			/// <summary/>
			IF_TYPE_DVB_ASI_OUT = 173,
			/// <summary/>
			IF_TYPE_PLC = 174,
			/// <summary/>
			IF_TYPE_NFAS = 175,
			/// <summary/>
			IF_TYPE_TR008 = 176,
			/// <summary/>
			IF_TYPE_GR303_RDT = 177,
			/// <summary/>
			IF_TYPE_GR303_IDT = 178,
			/// <summary/>
			IF_TYPE_ISUP = 179,
			/// <summary/>
			IF_TYPE_PROP_DOCS_WIRELESS_MACLAYER = 180,
			/// <summary/>
			IF_TYPE_PROP_DOCS_WIRELESS_DOWNSTREAM = 181,
			/// <summary/>
			IF_TYPE_PROP_DOCS_WIRELESS_UPSTREAM = 182,
			/// <summary/>
			IF_TYPE_HIPERLAN2 = 183,
			/// <summary/>
			IF_TYPE_PROP_BWA_P2MP = 184,
			/// <summary/>
			IF_TYPE_SONET_OVERHEAD_CHANNEL = 185,
			/// <summary/>
			IF_TYPE_DIGITAL_WRAPPER_OVERHEAD_CHANNEL = 186,
			/// <summary/>
			IF_TYPE_AAL2 = 187,
			/// <summary/>
			IF_TYPE_RADIO_MAC = 188,
			/// <summary/>
			IF_TYPE_ATM_RADIO = 189,
			/// <summary/>
			IF_TYPE_IMT = 190,
			/// <summary/>
			IF_TYPE_MVL = 191,
			/// <summary/>
			IF_TYPE_REACH_DSL = 192,
			/// <summary/>
			IF_TYPE_FR_DLCI_ENDPT = 193,
			/// <summary/>
			IF_TYPE_ATM_VCI_ENDPT = 194,
			/// <summary/>
			IF_TYPE_OPTICAL_CHANNEL = 195,
			/// <summary/>
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

			/// <summary/>
			IF_TYPE_XBOX_WIRELESS = 281,
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
		/// The <c>NET_ADDRESS_FORMAT</c> enumeration specifies the format of a network address returned by the ParseNetworkString function.
		/// </summary>
		/// <remarks>
		/// <para>The <c>NET_ADDRESS_FORMAT</c> enumeration is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>NET_ADDRESS_FORMAT</c> enumeration is used in the NET_ADDRESS_INFO structure returned by the ParseNetworkString function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/ne-iphlpapi-net_address_format_ typedef enum NET_ADDRESS_FORMAT_ {
		// NET_ADDRESS_FORMAT_UNSPECIFIED, NET_ADDRESS_DNS_NAME, NET_ADDRESS_IPV4, NET_ADDRESS_IPV6 } NET_ADDRESS_FORMAT;
		[PInvokeData("iphlpapi.h", MSDNShortId = "a99df758-d46e-452d-acf8-d2cb5a6fa22e")]
		public enum NET_ADDRESS_FORMAT
		{
			/// <summary>The format of the network address is unspecified.</summary>
			NET_ADDRESS_FORMAT_UNSPECIFIED,

			/// <summary>The format of the network address is a DNS name.</summary>
			NET_ADDRESS_DNS_NAME,

			/// <summary>The format of the network address is a string in Internet standard dotted-decimal notation for IPv4.</summary>
			NET_ADDRESS_IPV4,

			/// <summary>The format of the network address is a string in Internet standard hexadecimal encoding for IPv6.</summary>
			NET_ADDRESS_IPV6,
		}

		/// <summary>Flags used by the <see cref="ParseNetworkString(string, NET_STRING, IntPtr, IntPtr, IntPtr)"/> function.</summary>
		[PInvokeData("iphlpapi.h", MSDNShortId = "43bc866f-7776-4f59-9ed6-4c6fc4da7f83")]
		[Flags]
		public enum NET_STRING
		{
			/// <summary>
			/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation. A network port or
			/// prefix must not be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>192.168.100.10</para>
			/// </summary>
			NET_STRING_IPV4_ADDRESS = 0x00000001,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 service using Internet standard dotted-decimal notation. A network port is
			/// required as part of the network string. A prefix must not be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>192.168.100.10:80</para>
			/// </summary>
			NET_STRING_IPV4_SERVICE = 0x00000002,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 network using Internet standard dotted-decimal notation. A network prefix that
			/// uses the Classless Inter-Domain Routing (CIDR) notation is required as part of the network string. A network port must not be
			/// present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>192.168.100/24</para>
			/// </summary>
			NET_STRING_IPV4_NETWORK = 0x00000004,

			/// <summary>
			/// The NetworkString parameter points to an IPv6 address using Internet standard hexadecimal encoding. An IPv6 scope ID may be
			/// present in the network string. A network port or prefix must not be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A%2</para>
			/// </summary>
			NET_STRING_IPV6_ADDRESS = 0x00000008,

			/// <summary>
			/// The NetworkString parameter points to an IPv6 address using Internet standard hexadecimal encoding. An IPv6 scope ID must not
			/// be present in the network string. A network port or prefix must not be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A</para>
			/// </summary>
			NET_STRING_IPV6_ADDRESS_NO_SCOPE = 0x00000010,

			/// <summary>
			/// The NetworkString parameter points to an IPv6 service using Internet standard hexadecimal encoding. A network port is
			/// required as part of the network string. An IPv6 scope ID may be present in the network string. A prefix must not be present
			/// in the network string.
			/// <para>An example network string with a scope ID is the following:</para>
			/// <para>[21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A%2]:8080</para>
			/// </summary>
			NET_STRING_IPV6_SERVICE = 0x00000020,

			/// <summary>
			/// The NetworkString parameter points to an IPv6 service using Internet standard hexadecimal encoding. A network port is
			/// required as part of the network string. An IPv6 scope ID must not be present in the network string. A prefix must not be
			/// present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A:8080</para>
			/// </summary>
			NET_STRING_IPV6_SERVICE_NO_SCOPE = 0x00000040,

			/// <summary>
			/// The NetworkString parameter points to an IPv6 network using Internet standard hexadecimal encoding. A network prefix in CIDR
			/// notation is required as part of the network string. A network port or scope ID must not be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>21DA:D3::/48</para>
			/// </summary>
			NET_STRING_IPV6_NETWORK = 0x00000080,

			/// <summary>
			/// The NetworkString parameter points to an Internet address using a Domain Name System (DNS) name. A network port or prefix
			/// must not be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>www.microsoft.com</para>
			/// </summary>
			NET_STRING_NAMED_ADDRESS = 0x00000100,

			/// <summary>
			/// The NetworkString parameter points to an Internet service using a DNS name. A network port must be present in the network string.
			/// <para>An example network string is the following:</para>
			/// <para>www.microsoft.com:80</para>
			/// </summary>
			NET_STRING_NAMED_SERVICE = 0x00000200,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation or an IPv6 address
			/// using the Internet standard hexadecimal encoding. An IPv6 scope ID may be present in the network string. A network port or
			/// prefix must not be present in the network string.
			/// <para>This type matches either the NET_STRING_IPV4_ADDRESS or NET_STRING_IPV6_ADDRESS types.</para>
			/// </summary>
			NET_STRING_IP_ADDRESS = 0x00000009,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation or an IPv6 address
			/// using Internet standard hexadecimal encoding. An IPv6 scope ID must not be present in the network string. A network port or
			/// prefix must not be present in the network string.
			/// <para>This type matches either the NET_STRING_IPV4_ADDRESS or NET_STRING_IPV6_ADDRESS_NO_SCOPE types.</para>
			/// </summary>
			NET_STRING_IP_ADDRESS_NO_SCOPE = 0x00000011,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 service or IPv6 service. A network port is required as part of the network
			/// string. An IPv6 scope ID may be present in the network string. A prefix must not be present in the network string.
			/// <para>This type matches either the NET_STRING_IPV4_SERVICE or NET_STRING_IPV6_SERVICE types.</para>
			/// </summary>
			NET_STRING_IP_SERVICE = 0x00000022,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 service or IPv6 service. A network port is required as part of the network
			/// string. An IPv6 scope ID must not be present in the network string. A prefix must not be present in the network string.
			/// <para>This type matches either the NET_STRING_IPV4_SERVICE or NET_STRING_IPV6_SERVICE_NO_SCOPE types.</para>
			/// </summary>
			NET_STRING_IP_SERVICE_NO_SCOPE = 0x00000042,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 or IPv6 network. A network prefix in CIDR notation is required as part of the
			/// network string. A network port or scope ID must not be present in the network.
			/// <para>This type matches either the NET_STRING_IPV4_NETWORK or NET_STRING_IPV6_NETWORK types.</para>
			/// </summary>
			NET_STRING_IP_NETWORK = 0x00000084,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 address in Internet standard dotted-decimal notation, an IPv6 address in
			/// Internet standard hexadecimal encoding, or a DNS name. An IPv6 scope ID may be present in the network string for an IPv6
			/// address. A network port or prefix must not be present in the network string.
			/// <para>This type matches either the NET_STRING_NAMED_ADDRESS or NET_STRING_IP_ADDRESS types.</para>
			/// </summary>
			NET_STRING_ANY_ADDRESS = 0x00000209,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 address in Internet standard dotted-decimal notation, an IPv6 address in
			/// Internet standard hexadecimal encoding, or a DNS name. An IPv6 scope ID must not be present in the network string for an IPv6
			/// address. A network port or prefix must not be present in the network string.
			/// <para>This type matches either the NET_STRING_NAMED_ADDRESS or NET_STRING_IP_ADDRESS_NO_SCOPE types.</para>
			/// </summary>
			NET_STRING_ANY_ADDRESS_NO_SCOPE = 0x00000211,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 service or IPv6 service using IP address notation or a DNS name. A network port
			/// is required as part of the network string. An IPv6 scope ID may be present in the network string. A prefix must not be
			/// present in the network string.
			/// <para>This type matches either the NET_STRING_NAMED_SERVICE or NET_STRING_IP_SERVICE types.</para>
			/// </summary>
			NET_STRING_ANY_SERVICE = 0x00000222,

			/// <summary>
			/// The NetworkString parameter points to an IPv4 service or IPv6 service using IP address notation or a DNS name. A network port
			/// is required as part of the network string. An IPv6 scope ID must not be present in the network string. A prefix must not be
			/// present in the network string.
			/// <para>This type matches either the NET_STRING_NAMED_SERVICE or NET_STRING_IP_SERVICE_NO_SCOPE types.</para>
			/// </summary>
			NET_STRING_ANY_SERVICE_NO_SCOPE = 0x00000242,
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

		/// <summary>The <c>CreateIpForwardEntry</c> function creates a route in the local computer's IPv4 routing table.</summary>
		/// <param name="pRoute">
		/// A pointer to a MIB_IPFORWARDROW structure that specifies the information for the new route. The caller must specify values for
		/// all members of this structure. The caller must specify <c>MIB_IPPROTO_NETMGMT</c> for the <c>dwForwardProto</c> member of <c>MIB_IPFORWARDROW</c>.
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
		/// An input parameter is invalid, no action was taken. This error is returned if the pRoute parameter is NULL, the dwForwardProto
		/// member of MIB_IPFORWARDROW was not set to MIB_IPPROTO_NETMGMT, the dwForwardMask member of the PMIB_IPFORWARDROW structure is not
		/// a valid IPv4 subnet mask, or one of the other members of the MIB_IPFORWARDROW structure is invalid.
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
		/// The <c>dwForwardProto</c> member of MIB_IPFORWARDROW structure pointed to by the route parameter must be set to
		/// <c>MIB_IPPROTO_NETMGMT</c> otherwise <c>CreateIpForwardEntry</c> will fail. Routing protocol identifiers are used to identify
		/// route information for the specified routing protocol. For example, <c>MIB_IPPROTO_NETMGMT</c> is used to identify route
		/// information for IP routing set through network management such as the Dynamic Host Configuration Protocol (DHCP), the Simple
		/// Network Management Protocol (SNMP), or by calls to the <c>CreateIpForwardEntry</c>, DeleteIpForwardEntry, or SetIpForwardEntry functions.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the route metric specified in the <c>dwForwardMetric1</c> member of the
		/// MIB_IPFORWARDROW structure pointed to by pRoute parameter represents a combination of the route metric added to the interface
		/// metric specified in the <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. So the
		/// <c>dwForwardMetric1</c> member of the <c>MIB_IPFORWARDROW</c> structure should be equal to or greater than <c>Metric</c> member
		/// of the associated <c>MIB_IPINTERFACE_ROW</c> structure. If an application would like to set the route metric to 0, then the
		/// <c>dwForwardMetric1</c> member of the <c>MIB_IPFORWARDROW</c> structure should be set equal to the value of the interface metric
		/// specified in the <c>Metric</c> member of the associated <c>MIB_IPINTERFACE_ROW</c> structure. An application can retrieve the
		/// interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the <c>CreateIpForwardEntry</c> only works on interfaces with a single sub-interface
		/// (where the interface LUID and sub-interface LUID are the same). The <c>dwForwardIfIndex</c> member of the MIB_IPFORWARDROW
		/// structure specifies the interface.
		/// </para>
		/// <para>
		/// A number of members of the MIB_IPFORWARDROW structure pointed to by the route parameter are not currently used by
		/// <c>CreateIpForwardEntry</c>. These members include <c>dwForwardPolicy</c>, <c>dwForwardType</c>, <c>dwForwardAge</c>,
		/// <c>dwForwardNextHopAS</c>, <c>dwForwardMetric2</c>, <c>dwForwardMetric3</c>, <c>dwForwardMetric4</c>, and <c>dwForwardMetric5</c>.
		/// </para>
		/// <para>
		/// A new route created by <c>CreateIpForwardEntry</c> will automatically have a default value for <c>dwForwardAge</c> of INFINITE.
		/// </para>
		/// <para>
		/// To modify an existing route in the IPv4 routing table, use the SetIpForwardEntry function. To retrieve the IPv4 routing table,
		/// call the GetIpForwardTable function.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>CreateIpForwardEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>CreateIpForwardEntry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>CreateIpForwardEntry</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
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
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates how to change the default gateway to NewGateway. Simply calling GetIpForwardTable, changing
		/// the gateway, and then calling SetIpForwardEntry will not change the route, but rather will just add a new one. If for some reason
		/// there are multiple default gateways present, this code will delete them. Note that the new gateway must be viable; otherwise,
		/// TCP/IP will ignore the change.
		/// </para>
		/// <para><c>Note</c> Executing this code will change your IP routing tables and will likely cause network activity to fail.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-createipforwardentry DWORD CreateIpForwardEntry(
		// PMIB_IPFORWARDROW pRoute );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "72243390-c3b8-41c3-8771-a5fb1d6383ae")]
		public static extern Win32Error CreateIpForwardEntry(in MIB_IPFORWARDROW pRoute);

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
		public static extern Win32Error CreateIpNetEntry(in MIB_IPNETROW pArpEntry);

		/// <summary>
		/// The <c>CreatePersistentTcpPortReservation</c> function creates a persistent TCP port reservation for a consecutive block of TCP
		/// ports on the local computer.
		/// </summary>
		/// <param name="StartPort">The starting TCP port number in network byte order.</param>
		/// <param name="NumberOfPorts">The number of TCP port numbers to reserve.</param>
		/// <param name="Token">A pointer to a port reservation token that is returned if the function succeeds.</param>
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
		/// An invalid parameter was passed to the function. This error is returned if zero is passed in the StartPort or NumberOfPorts
		/// parameters. This error is also returned if the NumberOfPorts parameter is too large a block of ports depending on the StartPort
		/// parameter that the allocable block of ports would exceed the maximum port that can be allocated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_SHARING_VIOLATION</term>
		/// <term>
		/// The process cannot access the file because it is being used by another process. This error is returned if a TCP port in the block
		/// of TCP ports specified by the StartPort and NumberOfPorts parameters is already being used. This error is also returned if a
		/// persistent reservation for a block of TCP ports specified by the StartPort and NumberOfPorts parameters matches or overlaps a
		/// persistent reservation for a block of TCP ports that was already created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreatePersistentTcpPortReservation</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>CreatePersistentTcpPortReservation</c> function is used to add a persistent reservation for a block of TCP ports.</para>
		/// <para>
		/// Applications and services which need to reserve ports fall into two categories. The first category includes components which need
		/// a particular port as part of their operation. Such components will generally prefer to specify their required port at
		/// installation time (in an application manifest, for example). The second category includes components which need any available
		/// port or block of ports at runtime.
		/// </para>
		/// <para>
		/// These two categories correspond to specific and wildcard port reservation requests. Specific reservation requests may be
		/// persistent or runtime, while wildcard port reservation requests are only supported at runtime.
		/// </para>
		/// <para>
		/// The <c>CreatePersistentTcpPortReservation</c> function provides the ability for an application or service to reserve a persistent
		/// block of TCP ports. Persistent TCP port reservations are recorded in a persistent store for the TCP module in Windows.
		/// </para>
		/// <para>
		/// A caller obtains a persistent port reservation by specifying how many ports are required and whether a specific range is needed.
		/// If the request can be satisfied, the <c>CreatePersistentTcpPortReservation</c> function returns a unique opaque ULONG64 token,
		/// which subsequently identifies the reservation. A persistent TCP port reservation may be released by calling the
		/// DeletePersistentTcpPortReservation function. Note that the token for a given persistent TCP port reservation may change each time
		/// the system is restarted.
		/// </para>
		/// <para>
		/// Windows does not implement inter-component security for persistent reservations obtained using these functions. This means that
		/// if a component is granted the ability to obtain any persistent port reservations, that component automatically gains the ability
		/// to consume any persistent port reservations granted to any other component on the system. Process-level security is enforced for
		/// runtime reservations, but such control cannot be extended to persistent port reservations created using the
		/// <c>CreatePersistentTcpPortReservation</c> or CreatePersistentUdpPortReservation function.
		/// </para>
		/// <para>
		/// Once a persistent TCP port reservation has been obtained, an application can request port assignments from the TCP port
		/// reservation by opening a TCP socket, then calling the WSAIoctl function specifying the SIO_ASSOCIATE_PORT_RESERVATION IOCTL and
		/// passing the reservation token before issuing a call to the bind function on the socket.
		/// </para>
		/// <para>
		/// The SIO_ACQUIRE_PORT_RESERVATION IOCTL can be used to request a runtime reservation for a block of TCP or UDP ports. For runtime
		/// port reservations, the port pool requires that reservations be consumed from the process on whose socket the reservation was
		/// granted. Runtime port reservations last only as long as the lifetime of the socket on which the
		/// <c>SIO_ACQUIRE_PORT_RESERVATION</c> IOCTL was called. In contrast, persistent port reservations created using the
		/// <c>CreatePersistentTcpPortReservation</c> function may be consumed by any process with the ability to obtain persistent reservations.
		/// </para>
		/// <para>
		/// The <c>CreatePersistentTcpPortReservation</c> function can only be called by a user logged on as a member of the Administrators
		/// group. If <c>CreatePersistentTcpPortReservation</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example creates a persistent TCP port reservation, then creates a socket and allocates a port from the port
		/// reservation, and then closes the socket and deletes the TCP port reservation.
		/// </para>
		/// <para>
		/// This example must be run by a user that is a member of the Administrators group. The simplest way to run this example is in an
		/// enhanced shell as the built-in Administrator (RunAs administrator).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-createpersistenttcpportreservation ULONG
		// CreatePersistentTcpPortReservation( USHORT StartPort, USHORT NumberOfPorts, PULONG64 Token );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "19DAF828-B0E4-49E2-843D-7350C8083C45")]
		public static extern Win32Error CreatePersistentTcpPortReservation(ushort StartPort, ushort NumberOfPorts, out ulong Token);

		/// <summary>
		/// The <c>CreatePersistentUdpPortReservation</c> function creates a persistent UDP port reservation for a consecutive block of UDP
		/// ports on the local computer.
		/// </summary>
		/// <param name="StartPort">The starting UDP port number in network byte order.</param>
		/// <param name="NumberOfPorts">The number of UDP port numbers to reserve.</param>
		/// <param name="Token">A pointer to a port reservation token that is returned if the function succeeds.</param>
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
		/// An invalid parameter was passed to the function. This error is returned if zero is passed in the StartPort or NumberOfPorts
		/// parameters. This error is also returned if the NumberOfPorts parameter is too large a block of ports depending on the StartPort
		/// parameter that the allocable block of ports would exceed the maximum port that can be allocated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_SHARING_VIOLATION</term>
		/// <term>
		/// The process cannot access the file because it is being used by another process. This error is returned if a UDP port in the block
		/// of UDP ports specified by the StartPort and NumberOfPorts parameters is already being used. This error is also returned if a
		/// persistent reservation for a block of UDP ports specified by the StartPort and NumberOfPorts parameters matches or overlaps a
		/// persistent reservation for a block of UDP ports that was already created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreatePersistentUdpPortReservation</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>CreatePersistentUdpPortReservation</c> function is used to add a persistent reservation for a block of UDP ports.</para>
		/// <para>
		/// Applications and services which need to reserve ports fall into two categories. The first category includes components which need
		/// a particular port as part of their operation. Such components will generally prefer to specify their required port at
		/// installation time (in an application manifest, for example). The second category includes components which need any available
		/// port or block of ports at runtime.
		/// </para>
		/// <para>
		/// These two categories correspond to specific and wildcard port reservation requests. Specific reservation requests may be
		/// persistent or runtime, while wildcard port reservation requests are only supported at runtime.
		/// </para>
		/// <para>
		/// The <c>CreatePersistentUdpPortReservation</c> function provides the ability for an application or service to reserve persistently
		/// a block of UDP ports. Persistent TCP reservations are recorded in a persistent store for the UDP module in Windows.
		/// </para>
		/// <para>
		/// A caller obtains a persistent port reservation by specifying how many ports are required and whether a specific range is needed.
		/// If the request can be satisfied, the <c>CreatePersistentUdpPortReservation</c> function returns a unique opaque ULONG64 token,
		/// which subsequently identifies the reservation. A persistent UDP port reservation may be released by calling the
		/// DeletePersistentUdpPortReservation function. Note that the token for a given persistent UDP port reservation may change each time
		/// the system is restarted.
		/// </para>
		/// <para>
		/// Windows does not implement inter-component security for persistent reservations obtained using these functions. This means that
		/// if a component is granted the ability to obtain any persistent port reservations, that component automatically gains the ability
		/// to consume any persistent port reservations granted to any other component on the system. Process-level security is enforced for
		/// runtime reservations, but such control cannot be extended to persistent reservations created using the created using the
		/// CreatePersistentTcpPortReservation or <c>CreatePersistentUdpPortReservation</c> function.
		/// </para>
		/// <para>
		/// Once a persistent UDP port reservation has been obtained, an application can request port assignments from the UDP port
		/// reservation by opening a UDP socket, then calling the WSAIoctl function specifying the SIO_ASSOCIATE_PORT_RESERVATION IOCTL and
		/// passing the reservation token before issuing a call to the bind function on the socket.
		/// </para>
		/// <para>
		/// The SIO_ACQUIRE_PORT_RESERVATION IOCTL can be used to request a runtime reservation for a block of TCP or UDP ports. For runtime
		/// port reservations, the port pool requires that reservations be consumed from the process on whose socket the reservation was
		/// granted. Runtime port reservations last only as long as the lifetime of the socket on which the
		/// <c>SIO_ACQUIRE_PORT_RESERVATION</c> IOCTL was called. In contrast, persistent port reservations created using the
		/// <c>CreatePersistentUdpPortReservation</c> function may be consumed by any process with the ability to obtain persistent reservations.
		/// </para>
		/// <para>
		/// The <c>CreatePersistentUdpPortReservation</c> function can only be called by a user logged on as a member of the Administrators
		/// group. If <c>CreatePersistentUdpPortReservation</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-createpersistentudpportreservation ULONG
		// CreatePersistentUdpPortReservation( USHORT StartPort, USHORT NumberOfPorts, PULONG64 Token );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "AFD2EFD1-55AF-49C9-8109-D4D1B7BB7C94")]
		public static extern Win32Error CreatePersistentUdpPortReservation(ushort StartPort, ushort NumberOfPorts, out ulong Token);

		/// <summary>
		/// The <c>CreateProxyArpEnry</c> function creates a Proxy Address Resolution Protocol (PARP) entry on the local computer for the
		/// specified IPv4 address.
		/// </summary>
		/// <param name="dwAddress">The IPv4 address for which this computer acts as a proxy.</param>
		/// <param name="dwMask">The subnet mask for the IPv4 address specified in dwAddress.</param>
		/// <param name="dwIfIndex">
		/// The index of the interface on which to proxy ARP for the IPv4 address identified by dwAddress. In other words, when an ARP
		/// request for dwAddress is received on this interface, the local computer responds with the physical address of this interface. If
		/// this interface is of a type that does not support ARP, such as PPP, then the call fails.
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
		/// An input parameter is invalid, no action was taken. This error is returned if the dwAddress parameter is zero or an invalid
		/// value, one of the other parameters is invalid.
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
		/// <para>To retrieve the ARP table, call the GetIpNetTable function. To delete an existing PARP entry, call the DeleteProxyArpEntry.</para>
		/// <para>
		/// On Windows Vista and later, the <c>CreateProxyArpEnry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>CreateProxyArpEnry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista and later
		/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
		/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> This function executes a privileged operation. For this function to execute successfully, the caller must be logged
		/// on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-createproxyarpentry DWORD CreateProxyArpEntry( DWORD
		// dwAddress, DWORD dwMask, DWORD dwIfIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "a0e90c0a-9403-40cb-906e-6e1e2f8e73c4")]
		public static extern Win32Error CreateProxyArpEntry(uint dwAddress, uint dwMask, uint dwIfIndex);

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

		/// <summary>The <c>DeleteIpForwardEntry</c> function deletes an existing route in the local computer's IPv4 routing table.</summary>
		/// <param name="pRoute">
		/// A pointer to an MIB_IPFORWARDROW structure. This structure specifies information that identifies the route to delete. The caller
		/// must specify values for the <c>dwForwardIfIndex</c>, <c>dwForwardDest</c>, <c>dwForwardMask</c>, <c>dwForwardNextHop</c>, and
		/// <c>dwForwardProto</c> members of the structure.
		/// </param>
		/// <returns>
		/// <para>The function returns <c>NO_ERROR</c> (zero) if the routine is successful.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
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
		/// An input parameter is invalid, no action was taken. This error is returned if the pRoute parameter is NULL, the dwForwardMask
		/// member of the PMIB_IPFORWARDROW structure is not a valid IPv4 subnet mask, the dwForwardIfIndex member is NULL, or one of the
		/// other members of the MIB_IPFORWARDROW structure is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>The pRoute parameter points to a route entry that does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>(other)</term>
		/// <term>The function may return other error codes.</term>
		/// </item>
		/// </list>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>dwForwardProto</c> member of MIB_IPFORWARDROW structure pointer to by the route parameter must be set to
		/// <c>MIB_IPPROTO_NETMGMT</c> otherwise <c>DeleteIpForwardEntry</c> will fail. Routing protocol identifiers are used to identify
		/// route information for the specified routing protocol. For example, <c>MIB_IPPROTO_NETMGMT</c> is used to identify route
		/// information for IP routing set through network management such as the Dynamic Host Configuration Protocol (DHCP), the Simple
		/// Network Management Protocol (SNMP), or by calls to the CreateIpForwardEntry, <c>DeleteIpForwardEntry</c> , or SetIpForwardEntry functions.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the <c>DeleteIpForwardEntry</c> only works on interfaces with a single sub-interface
		/// (where the interface LUID and sub-interface LUID are the same). The <c>dwForwardIfIndex</c> member of the MIB_IPFORWARDROW
		/// structure specifies the interface.
		/// </para>
		/// <para>
		/// A number of members of the MIB_IPFORWARDROW structure pointed to by the route parameter are not currently used by
		/// CreateIpForwardEntry. These members include <c>dwForwardPolicy</c>, <c>dwForwardType</c>, <c>dwForwardAge</c>,
		/// <c>dwForwardNextHopAS</c>, <c>dwForwardMetric1</c>, <c>dwForwardMetric2</c>, <c>dwForwardMetric3</c>, <c>dwForwardMetric4</c>,
		/// and <c>dwForwardMetric5</c>.
		/// </para>
		/// <para>
		/// To modify an existing route in the IPv4 routing table, use the SetIpForwardEntry function. To retrieve the IPv4 routing table,
		/// call the GetIpForwardTable function.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>DeleteIpForwardEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>DeleteIpForwardEntry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>DeleteIpForwardEntry</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
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
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to change the default gateway to NewGateway. By calling GetIpForwardTable, changing the
		/// gateway, and then calling SetIpForwardEntry will not change the route, but will add a new one. If multiple default gateways
		/// exist, this code will delete them. Be aware that the new gateway must be viable; otherwise, TCP/IP will ignore the change.
		/// </para>
		/// <para><c>Note</c> Executing this code will change your IP routing tables and will likely cause network activity to fail.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-deleteipforwardentry DWORD DeleteIpForwardEntry(
		// PMIB_IPFORWARDROW pRoute );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "70bcfd71-34dd-465d-890b-1dd829632fb0")]
		public static extern Win32Error DeleteIpForwardEntry(in MIB_IPFORWARDROW pRoute);

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
		public static extern Win32Error DeleteIpNetEntry(in MIB_IPNETROW pArpEntry);

		/// <summary>
		/// The <c>DeletePersistentTcpPortReservation</c> function deletes a persistent TCP port reservation for a consecutive block of TCP
		/// ports on the local computer.
		/// </summary>
		/// <param name="StartPort">The starting TCP port number in network byte order.</param>
		/// <param name="NumberOfPorts">The number of TCP port numbers to delete.</param>
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
		/// An invalid parameter was passed to the function. This error is returned if zero is passed in the StartPort or NumberOfPorts parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The element was not found. This error is returned if persistent port block specified by the StartPort and NumberOfPorts
		/// parameters could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeletePersistentTcpPortReservation</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>DeletePersistentTcpPortReservation</c> function is used to delete a persistent reservation for a block of TCP ports.</para>
		/// <para>
		/// The <c>DeletePersistentTcpPortReservation</c> function can only be called by a user logged on as a member of the Administrators
		/// group. If <c>DeletePersistentTcpPortReservation</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example deletes a persistent TCP port reservation.</para>
		/// <para>
		/// This example must be run by a user that is a member of the Administrators group. The simplest way to run this example is in an
		/// enhanced shell as the built-in Administrator (RunAs administrator).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-deletepersistenttcpportreservation ULONG
		// DeletePersistentTcpPortReservation( USHORT StartPort, USHORT NumberOfPorts );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "533F8B35-6EC1-43BB-B8E6-EB086A9C646C")]
		public static extern Win32Error DeletePersistentTcpPortReservation(ushort StartPort, ushort NumberOfPorts);

		/// <summary>
		/// The <c>DeletePersistentUdpPortReservation</c> function deletes a persistent TCP port reservation for a consecutive block of TCP
		/// ports on the local computer.
		/// </summary>
		/// <param name="StartPort">The starting UDP port number in network byte order.</param>
		/// <param name="NumberOfPorts">The number of UDP port numbers to delete.</param>
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
		/// An invalid parameter was passed to the function. This error is returned if zero is passed in the StartPort or NumberOfPorts parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The element was not found. This error is returned if persistent port block specified by the StartPort and NumberOfPorts
		/// parameters could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeletePersistentUdpPortReservation</c> function is defined on Windows Vista and later.</para>
		/// <para>The <c>DeletePersistentUdpPortReservation</c> function is used to delete a persistent reservation for a block of UDP ports.</para>
		/// <para>
		/// The <c>DeletePersistentUdpPortReservation</c> function can only be called by a user logged on as a member of the Administrators
		/// group. If <c>DeletePersistentUdpPortReservation</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a
		/// user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-deletepersistentudpportreservation ULONG
		// DeletePersistentUdpPortReservation( USHORT StartPort, USHORT NumberOfPorts );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "E6539B3F-48DA-41AA-8AD4-2EBBAF98069F")]
		public static extern Win32Error DeletePersistentUdpPortReservation(ushort StartPort, ushort NumberOfPorts);

		/// <summary>
		/// The <c>DeleteProxyArpEntry</c> function deletes the PARP entry on the local computer specified by the dwAddress and dwIfIndex parameters.
		/// </summary>
		/// <param name="dwAddress">The IPv4 address for which this computer is acting as a proxy.</param>
		/// <param name="dwMask">The subnet mask for the IPv4 address specified in the dwAddress parameter.</param>
		/// <param name="dwIfIndex">
		/// The index of the interface on which this computer is supporting proxy ARP for the IP address specified by the dwAddress parameter.
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
		/// <para>To retrieve the ARP table, call the GetIpNetTable function.</para>
		/// <para>
		/// On Windows Vista and later, the <c>DeleteProxyArpEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>DeleteProxyArpEntry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista and later
		/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
		/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> This function executes a privileged operation. For this function to execute successfully, the caller must be logged
		/// on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-deleteproxyarpentry DWORD DeleteProxyArpEntry( DWORD
		// dwAddress, DWORD dwMask, DWORD dwIfIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "26e08e4d-ac69-49f8-8a1a-1ba1a04d085c")]
		public static extern Win32Error DeleteProxyArpEntry(uint dwAddress, uint dwMask, uint dwIfIndex);

		/// <summary>The <c>DisableMediaSense</c> function disables the media sensing capability of the TCP/IP stack on a local computer.</summary>
		/// <param name="pHandle">
		/// <para>
		/// A pointer to a variable that is used to store a handle. If the pOverlapped parameter is not <c>NULL</c>, this variable will be
		/// used internally to store a handle required to call the IP driver and disable the media sensing capability.
		/// </para>
		/// <para>
		/// An application should not use the value pointed to by this variable. This handle is for internal use and should not be closed.
		/// </para>
		/// </param>
		/// <param name="pOverLapped">
		/// A pointer to an OVERLAPPED structure. Except for the <c>hEvent</c> member, all members of this structure must be set to zero. The
		/// <c>hEvent</c> member requires a handle to a valid event object. Use the CreateEvent function to create this event object.
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
		/// <term>An invalid parameter was passed to the function. This error is returned if an pOverlapped parameter is a bad pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>The operation is in progress. This value is returned by a successful asynchronous call to DisableMediaSense.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_OPEN_FAILED</term>
		/// <term>The handle pointed to by the pHandle parameter was invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If the pHandle or pOverlapped parameters are <c>NULL</c>, the <c>DisableMediaSense</c> function is executed synchronously.</para>
		/// <para>
		/// If both the pHandle and pOverlapped parameters are not <c>NULL</c>, the <c>DisableMediaSense</c> function is executed
		/// asynchronously using the OVERLAPPED structure pointed to by the pOverlapped parameter.
		/// </para>
		/// <para>
		/// The <c>DisableMediaSense</c> function does not complete until the RestoreMediaSense function is called later to restore the media
		/// sensing capability. Until then, an I/O request packet (IRP) remains queued up. Alternatively, when the process that called
		/// <c>DisableMediaSense</c> exits, the IRP is canceled and a cancel routine is called that would again restore the media sensing capability.
		/// </para>
		/// <para>
		/// To call <c>DisableMediaSense</c> synchronously, an application needs to create a separate thread for this call. Otherwise it
		/// would keep waiting for IRP completion and the function will block.
		/// </para>
		/// <para>
		/// To call <c>DisableMediaSense</c> asynchronously, an application needs to allocate an OVERLAPPED structure. Except for the
		/// <c>hEvent</c> member, all members of this structure must be set to zero. The <c>hEvent</c> member requires a handle to a valid
		/// event object. Use the CreateEvent function to create this event. When called asynchronously, <c>DisableMediaSense</c> always
		/// returns ERROR_IO_PENDING. The IRP will be completed only when RestoreMediaSense is called later. Use the CloseHandle function to
		/// close the handle to the event object when it is no longer needed. The system closes the handle automatically when the process
		/// terminates. The event object is destroyed when its last handle has been closed.
		/// </para>
		/// <para>
		/// On Windows Server 2003and Windows XP, the TCP/IP stack implements a policy of deleting all IP addresses on an interface in
		/// response to a media sense disconnect event from an underlying network interface. If a network switch or hub that the local
		/// computer is connected to is powered off, or a network cable is disconnected, the network interface will deliver disconnection
		/// events. IP configuration information associated with the network interface is lost. As a result, the TCP/IP stack implements a
		/// policy of hiding disconnected interfaces so these interfaces and their associated IP addresses do not show up in configuration
		/// information retrieved through IP helper. This policy prevents some applications from easily detecting that a network interface is
		/// merely disconnected, rather than removed from the system.
		/// </para>
		/// <para>
		/// This behavior does not normally impact a local client computer if it is using DHCP requests to a DHCP server for IP configuration
		/// information. But this can have a serious impact on server computers, particularly computers used as part of clusters. The
		/// <c>DisableMediaSense</c> function can be used to temporarily disable the media sensing capability for these cases. At some later
		/// time, the RestoreMediaSense function would be called to restore the media sensing capability.
		/// </para>
		/// <para>The following registry setting is related to the <c>DisableMediaSense</c> and RestoreMediaSense functions:</para>
		/// <para><c>System</c>&lt;b&gt;CurrentControlSet&lt;b&gt;Services&lt;b&gt;Tcpip&lt;b&gt;Parameters&lt;b&gt;DisableDHCPMediaSense</para>
		/// <para>
		/// There is an internal flag in Windows that is set if this registry key exists when the machine first boots up. The same internal
		/// flag also gets set and reset by calling <c>DisableMediaSense</c> and RestoreMediaSense. However with registry setting, you need
		/// to reboot the machine for the changes to take place.
		/// </para>
		/// <para>
		/// The TCP/IP stack on Windows Vista and later was changed to not hide disconnected interfaces when a disconnect event occurs. So on
		/// Windows Vista and later, the <c>DisableMediaSense</c> and RestoreMediaSense functions don't do anything and always returns NO_ERROR.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to call the <c>DisableMediaSense</c> and RestoreMediaSense functions asynchronously. This sample
		/// is only useful on Windows Server 2003and Windows XP where the <c>DisableMediaSense</c> and <c>RestoreMediaSense</c> functions do
		/// something useful.
		/// </para>
		/// <para>
		/// The sample first calls the <c>DisableMediaSense</c> function, sleeps for 60 seconds to allow the user to disconnect a network
		/// cable, retrieves the IP address table and prints some members of the IP address entries in the table, calls the RestoreMediaSense
		/// function, retrieves the IP address table again, and prints some members of the IP address entries in the table. The impact of
		/// disabling the media sensing capability can be seen in the difference in the IP address table entries.
		/// </para>
		/// <para>
		/// For an example that shows how to call the <c>DisableMediaSense</c> and RestoreMediaSense functions synchronously, see the
		/// <c>RestoreMediaSense</c> function reference.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-disablemediasense DWORD DisableMediaSense( HANDLE
		// *pHandle, OVERLAPPED *pOverLapped );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "ec845db8-d544-4291-8221-0fde82c2de27")]
		public static extern unsafe Win32Error DisableMediaSense(out HANDLE pHandle, [In] System.Threading.NativeOverlapped* pOverLapped);

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
		public static extern unsafe Win32Error EnableRouter(out HANDLE pHandle, System.Threading.NativeOverlapped* pOverlapped);

		/// <summary>
		/// The <c>FlushIpNetTable</c> function deletes all ARP entries for the specified interface from the ARP table on the local computer.
		/// </summary>
		/// <param name="dwIfIndex">The index of the interface for which to delete all ARP entries.</param>
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
		/// <term>An input parameter is invalid, no action was taken. This error is returned if the dwIfIndex parameter is invalid.</term>
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
		/// On Windows Vista and later, the <c>FlushIpNetTable</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>FlushIpNetTable</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control
		/// (UAC) on Windows Vista and later. If an application that contains this function is executed by a user logged on as a member of
		/// the Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista and later
		/// lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in Administrator must
		/// then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> This function executes a privileged operation. For this function to execute successfully, the caller must be logged
		/// on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-flushipnettable DWORD FlushIpNetTable( DWORD dwIfIndex );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "cf4dea10-552d-4730-a452-9302ef3761ff")]
		public static extern Win32Error FlushIpNetTable(uint dwIfIndex);

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
		public static extern Win32Error GetAdapterIndex([MarshalAs(UnmanagedType.LPWStr)] string AdapterName, out uint IfIndex);

		/// <summary>
		/// The <c>GetAdapterOrderMap</c> function obtains an adapter order map that indicates priority for interfaces on the local computer.
		/// </summary>
		/// <returns>
		/// Returns an IP_ADAPTER_ORDER_MAP structure filled with adapter priority information. See the <c>IP_ADAPTER_ORDER_MAP</c> structure
		/// for more information.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Interface indices appear in the order specified in the Adapters and Bindings dialog box in the Advanced Settings property sheet.
		/// This ordering is used as a tie breaker controlling the sequence in which interfaces are used on multihomed systems for situations
		/// including route selection, DNS name resolution, and other network related operations.
		/// </para>
		/// <para>
		/// This function should not be called directly. Instead, use the IP_ADAPTER_INFO structure returned in a GetAdaptersInfo function call.
		/// </para>
		/// <para><c>Note</c> The caller is responsible for calling the LocalFree function to free the array returned by <c>GetAdapterOrderMap</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getadapterordermap PIP_ADAPTER_ORDER_MAP
		// GetAdapterOrderMap( );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "43d7429b-6874-4ea6-bbf0-67456af520bc")]
		public static extern IP_ADAPTER_ORDER_MAP GetAdapterOrderMap();

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
		public static extern Win32Error GetAdaptersAddresses(uint Family, GetAdaptersAddressesFlags Flags, IntPtr Reserved, IntPtr AdapterAddresses, ref uint SizePointer);

		/// <summary>The <c>GetAdaptersAddresses</c> function retrieves the addresses associated with the adapters on the local computer.</summary>
		/// <param name="Flags">
		/// The type of addresses to retrieve. If this parameter is zero, then unicast, anycast, and multicast IP addresses will be returned.
		/// </param>
		/// <param name="Family">The address family of the addresses to retrieve.</param>
		/// <returns>A list of IP_ADAPTER_ADDRESSES structures on successful return.</returns>
		public static IP_ADAPTER_ADDRESSES_RESULT GetAdaptersAddresses(GetAdaptersAddressesFlags Flags = 0, ADDRESS_FAMILY Family = ADDRESS_FAMILY.AF_UNSPEC) =>
			GetTable((IntPtr p, ref uint l) => GetAdaptersAddresses((uint)Family, Flags, IntPtr.Zero, p, ref l), l => new IP_ADAPTER_ADDRESSES_RESULT(l), Win32Error.ERROR_BUFFER_OVERFLOW);

		/// <summary>
		/// <para>The <c>GetAdaptersInfo</c> function retrieves adapter information for the local computer.</para>
		/// <para><c>On Windows XP and later:</c> Use the GetAdaptersAddresses function instead of <c>GetAdaptersInfo</c>.</para>
		/// </summary>
		/// <param name="AdapterInfo">A pointer to a buffer that receives a linked list of IP_ADAPTER_INFO structures.</param>
		/// <param name="SizePointer">
		/// A pointer to a <c>ULONG</c> variable that specifies the size of the buffer pointed to by the pAdapterInfo parameter. If this size
		/// is insufficient to hold the adapter information, <c>GetAdaptersInfo</c> fills in this variable with the required size, and
		/// returns an error code of <c>ERROR_BUFFER_OVERFLOW</c>.
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
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getadaptersinfo ULONG GetAdaptersInfo( PIP_ADAPTER_INFO
		// AdapterInfo, PULONG SizePointer );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "8cdecc84-6566-438b-86d0-3c55490a9a59")]
		[Obsolete("On Windows XP and later: Use the GetAdaptersAddresses function instead of GetAdaptersInfo.")]
		public static extern Win32Error GetAdaptersInfo(IntPtr AdapterInfo, ref uint SizePointer);

		/// <summary>
		/// <para>The <c>GetAdaptersInfo</c> function retrieves adapter information for the local computer.</para>
		/// <para><c>On Windows XP and later:</c> Use the GetAdaptersAddresses function instead of <c>GetAdaptersInfo</c>.</para>
		/// </summary>
		/// <returns>A linked list of IP_ADAPTER_INFO structures.</returns>
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
		/// </remarks>
		[PInvokeData("iphlpapi.h", MSDNShortId = "8cdecc84-6566-438b-86d0-3c55490a9a59")]
		[Obsolete("On Windows XP and later: Use the GetAdaptersAddresses function instead of GetAdaptersInfo.")]
		public static IEnumerable<IP_ADAPTER_INFO> GetAdaptersInfo() =>
			GetTable((IntPtr p, ref uint l) => GetAdaptersInfo(p, ref l), l => new IP_ADAPTER_INFO_RESULT(l), Win32Error.ERROR_BUFFER_OVERFLOW);

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
		public static extern Win32Error GetExtendedTcpTable(IntPtr pTcpTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder, uint ulAf, TCP_TABLE_CLASS TableClass, uint Reserved = 0);

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
				throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET6 && (int)TableClass > 2 && !typeof(T).Name.Contains("6"))
				throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET && (int)TableClass > 2 && typeof(T).Name.Contains("6"))
				throw new InvalidOperationException("Type mismatch with supplied options.");

			return GetTable((IntPtr p, ref uint len) => GetExtendedTcpTable(p, ref len, sorted, (uint)ulAf, TableClass), len => (T)Activator.CreateInstance(typeof(T), len));
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
		[PInvokeData("iphlpapi.h", MSDNShortId = "c936d5a0-ca5e-487e-b304-bfd81403ab40")]
		public static T GetExtendedUdpTable<T>(UDP_TABLE_CLASS TableClass, ADDRESS_FAMILY ulAf = ADDRESS_FAMILY.AF_INET, bool sorted = false) where T : SafeHandle
		{
			if (!CorrespondingTypeAttribute.CanGet(TableClass, typeof(T)))
				throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET6 && !typeof(T).Name.Contains("6"))
				throw new InvalidOperationException("Type mismatch with supplied options.");
			if (ulAf == ADDRESS_FAMILY.AF_INET && typeof(T).Name.Contains("6"))
				throw new InvalidOperationException("Type mismatch with supplied options.");
			return GetTable((IntPtr p, ref uint len) => GetExtendedUdpTable(p, ref len, sorted, (uint)ulAf, TableClass), len => (T)Activator.CreateInstance(typeof(T), len));
		}

		/// <summary>
		/// The <c>GetFriendlyIfIndex</c> function takes an interface index and returns a backward-compatible interface index, that is, an
		/// index that uses only the lower 24 bits.
		/// </summary>
		/// <param name="IfIndex">The interface index from which the backward-compatible or "friendly" interface index is derived.</param>
		/// <returns>A backward-compatible interface index that uses only the lower 24 bits.</returns>
		// DWORD GetFriendlyIfIndex( _In_ DWORD IfIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/aa365931(v=vs.85).aspx
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("IpHlpApi.h", MSDNShortId = "aa365931")]
		public static extern uint GetFriendlyIfIndex([In] uint IfIndex);

		/// <summary>
		/// The <c>GetIcmpStatistics</c> function retrieves the Internet Control Message Protocol (ICMP) for IPv4 statistics for the local computer.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_ICMP structure that receives the ICMP statistics for the local computer.</param>
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
		/// <term>The pStats parameter is NULL, or GetIcmpStatistics is unable to write to the memory pointed to by the pStats parameter.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIcmpStatistics</c> function returns the ICMP statistics for IPv4 on the local computer. On Windows XP and later, the
		/// GetIpStatisticsEx can be used to obtain the ICMP statistics for either IPv4 or IPv6 on the local computer.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the ICMP for IPv4 statistics for the local computer and prints some information from the returned data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-geticmpstatistics ULONG GetIcmpStatistics( PMIB_ICMP
		// Statistics );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "b10ec58b-54fe-4068-beb9-6909ad7cecf7")]
		public static extern Win32Error GetIcmpStatistics(out MIB_ICMP Statistics);

		/// <summary>
		/// The <c>GetIcmpStatisticsEx</c> function retrieves Internet Control Message Protocol (ICMP) statistics for the local computer. The
		/// <c>GetIcmpStatisticsEx</c> function is capable of retrieving IPv6 ICMP statistics.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_ICMP_EX structure that contains ICMP statistics for the local computer.</param>
		/// <param name="Family">
		/// <para>The protocol family for which to retrieve ICMP statistics. Must be one of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>Internet Protocol version 4 (IPv4).</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Internet Protocol version 6 (IPv6).</term>
		/// </item>
		/// </list>
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
		/// <term>The pStats parameter is NULL or does not point to valid memory, or the dwFamily parameter is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system on which the function call was made.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The GetIpStatisticsEx can be used to obtain the ICMP statistics for either IPv4 or IPv6 on the local computer.</para>
		/// <para>The GetIcmpStatistics function returns the ICMP statistics for only IPv4 on the local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-geticmpstatisticsex ULONG GetIcmpStatisticsEx(
		// PMIB_ICMP_EX Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "b074650a-0f03-448c-8828-c7bcec9d6030")]
		public static extern Win32Error GetIcmpStatisticsEx(out MIB_ICMP_EX Statistics, ADDRESS_FAMILY Family);

		/// <summary>The <c>GetIfEntry</c> function retrieves information for the specified interface on the local computer.</summary>
		/// <param name="pIfRow">
		/// A pointer to a MIB_IFROW structure that, on successful return, receives information for an interface on the local computer. On
		/// input, set the <c>dwIndex</c> member of <c>MIB_IFROW</c> to the index of the interface for which to retrieve information. The
		/// value for the <c>dwIndex</c> must be retrieved by a previous call to the GetIfTable, GetIfTable2, or GetIfTable2Ex function.
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
		/// <term>The request could not be completed. This is an internal error.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>
		/// The data is invalid. This error is returned if the network interface index specified by the dwIndex member of the MIB_IFROW
		/// structure pointed to by the pIfRow parameter is not a valid interface index on the local computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pIfRow parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The specified interface could not be found. This error is returned if the network interface index specified by the dwIndex member
		/// of the MIB_IFROW structure pointed to by the pIfRow parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if IPv4 is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIfEntry</c> function retrieves information for an interface on a local computer.</para>
		/// <para>
		/// The <c>dwIndex</c> member in the MIB_IFROW structure pointed to by the pIfRow parameter must be initialized to a valid network
		/// interface index retrieved by a previous call to the GetIfTable, GetIfTable2, or GetIfTable2Ex function.
		/// </para>
		/// <para>
		/// The <c>GetIfEntry</c> function will fail if the <c>dwIndex</c> member of the MIB_IFROW pointed to by the pIfRow parameter does
		/// not match an existing interface index on the local computer.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the entries from the interface table and prints some of the information available for that entry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getifentry DWORD GetIfEntry( PMIB_IFROW pIfRow );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "bf16588d-3756-469e-afa2-e2e3dd537047")]
		public static extern Win32Error GetIfEntry(ref MIB_IFROW pIfRow);

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
		[PInvokeData("iphlpapi.h", MSDNShortId = "6a46c1df-b274-415e-b842-fc1adf6fa206")]
		public static MIB_IFTABLE GetIfTable(bool sorted = false) => GetTable((IntPtr p, ref uint len) => GetIfTable(p, ref len, sorted), len => new MIB_IFTABLE(len));

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
		[PInvokeData("iphlpapi.h", MSDNShortId = "efc0d175-2c6d-4608-b385-1623a9e0375c")]
		public static IP_INTERFACE_INFO GetInterfaceInfo() => GetTable((IntPtr p, ref uint len) => GetInterfaceInfo(p, ref len), len => new IP_INTERFACE_INFO(len));

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
		[PInvokeData("iphlpapi.h", MSDNShortId = "03bf5645-8237-4c78-a921-47315cab1c44")]
		public static MIB_IPADDRTABLE GetIpAddrTable(bool sorted = false) => GetTable((IntPtr p, ref uint len) => GetIpAddrTable(p, ref len, sorted), len => new MIB_IPADDRTABLE(len));

		/// <summary>The <c>GetIpErrorString</c> function retrieves an IP Helper error string.</summary>
		/// <param name="ErrorCode">
		/// The error code to be retrieved. The possible values for this parameter are defined in the Ipexport.h header file.
		/// </param>
		/// <param name="Buffer">A pointer to the buffer that contains the error code string if the function returns with NO_ERROR.</param>
		/// <param name="Size">A pointer to a <c>DWORD</c> that specifies the length, in bytes, of the buffer pointed to by Buffer parameter.</param>
		/// <returns>
		/// <para>Returns NO_ERROR upon success.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIpErrorString</c> function can be used to retrieve an IP Helper error string for an IP error code. The <c>IP_STATUS</c>
		/// error code passed in the ErrorCode parameter is returned in the <c>Status</c> member of the ICMP_ECHO_REPLY, ICMP_ECHO_REPLY32,
		/// and ICMPV6_ECHO_REPLY structures used by the ICMP and ICMPv6 functions. The functions that use these structures include
		/// Icmp6ParseReplies, Icmp6SendEcho2, IcmpParseReplies, IcmpSendEcho, IcmpSendEcho2, and IcmpSendEcho2Ex.
		/// </para>
		/// <para>
		/// The syntax for the <c>GetIpErrorString</c> function was slightly changed on the Microsoft Windows Software Development Kit (SDK)
		/// released for Windows Vista and later. The data type for the Buffer parameter was changed from <c>PWCHAR</c> to <c>PWSTR</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getiperrorstring DWORD GetIpErrorString( IP_STATUS
		// ErrorCode, PWSTR Buffer, PDWORD Size );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "4f71777a-2e87-4411-89fd-12c165d4d8ae")]
		public static extern Win32Error GetIpErrorString(Win32Error ErrorCode, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Buffer, ref uint Size);

		/// <summary>The <c>GetIpForwardTable</c> function retrieves the IPv4 routing table.</summary>
		/// <param name="pIpForwardTable">A pointer to a buffer that receives the IPv4 routing table as a MIB_IPFORWARDTABLE structure.</param>
		/// <param name="pdwSize">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the pIpForwardTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned routing table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// </param>
		/// <param name="bOrder">
		/// <para>
		/// A Boolean value that specifies whether the returned table should be sorted. If this parameter is <c>TRUE</c>, the table is sorted
		/// in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Destination address</term>
		/// </item>
		/// <item>
		/// <term>Protocol that generated the route</term>
		/// </item>
		/// <item>
		/// <term>Multipath routing policy</term>
		/// </item>
		/// <item>
		/// <term>Next-hop address</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>NO_ERROR</c> (zero).</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer pointed to by the pIpForwardTable parameter is not large enough. The required size is returned in the DWORD variable
		/// pointed to by the pdwSize parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pdwSize parameter is NULL, or GetIpForwardTable is unable to write to the memory pointed to by the pdwSize parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_DATA</term>
		/// <term>No data is available. This error is returned if there are no routes present on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// This function is not supported on the operating system in use on the local system. This error is returned if there is no IP stack
		/// installed on the local computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>dwForwardProto</c> member of the MIB_IPFORWARDROW structure specifies the protocol or routing mechanism that generated the
		/// route. See Protocol Identifiers for a list of possible protocols and routing mechanisms.
		/// </para>
		/// <para>
		/// The <c>dwForwardDest</c>, <c>dwForwardMask</c>, and <c>dwForwardNextHop</c> members of the MIB_IPFORWARDROW structure represent
		/// an IPv4 address in network byte order.
		/// </para>
		/// <para>
		/// An IPv4 address of 0.0.0.0 in the <c>dwForwardDest</c> member of the MIB_IPFORWARDROW structure is considered a default route.
		/// The MIB_IPFORWARDTABLE may contain multiple <c>MIB_IPFORWARDROW</c> entries with the <c>dwForwardDest</c> member set to 0.0.0.0
		/// when there are multiple network adapters installed.
		/// </para>
		/// <para>When <c>dwForwardAge</c> is set to <c>INFINITE</c>, the route will not be removed based on a timeout</para>
		/// <para>
		/// value. Any other value for <c>dwForwardAge</c> specifies the number of seconds since the route was added or modified in the
		/// network routing table.
		/// </para>
		/// <para>
		/// On Windows Server 2003 or Windows 2000 Server when the Routing and Remote Access Service (RRAS) is running, the MIB_IPFORWARDROW
		/// entries returned have the <c>dwForwardType</c> and <c>dwForwardAge</c> members set to zero.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the route metric specified in the <c>dwForwardMetric1</c> member of the
		/// MIB_IPFORWARDROW structure represents a combination of the route metric added to the interface metric specified in the
		/// <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. So the <c>dwForwardMetric1</c> member of
		/// the <c>MIB_IPFORWARDROW</c> structure should be equal to or greater than <c>Metric</c> member of the associated
		/// <c>MIB_IPINTERFACE_ROW</c> structure. If an application would like to set the route metric to 0 on Windows Vista and Windows
		/// Server 2008, then the <c>dwForwardMetric1</c> member of the <c>MIB_IPFORWARDROW</c> structure should be set equal to the value of
		/// the interface metric specified in the <c>Metric</c> member of the associated <c>MIB_IPINTERFACE_ROW</c> structure. An application
		/// can retrieve the interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// A number of members of the MIB_IPFORWARDROW structure entries returned by <c>GetIpForwardTable</c> are not currently used by IPv4
		/// routing. These members include <c>dwForwardPolicy</c>, <c>dwForwardNextHopAS</c>, <c>dwForwardMetric2</c>,
		/// <c>dwForwardMetric3</c>, <c>dwForwardMetric4</c>, and <c>dwForwardMetric5</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the IP routing table then prints some fields for each route in the table.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getipforwardtable DWORD GetIpForwardTable(
		// PMIB_IPFORWARDTABLE pIpForwardTable, PULONG pdwSize, BOOL bOrder );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5d645353-7c87-4f8a-b7fd-149675a94743")]
		public static extern Win32Error GetIpForwardTable(IntPtr pIpForwardTable, ref uint pdwSize, [MarshalAs(UnmanagedType.Bool)] bool bOrder);

		/// <summary>The <c>GetIpForwardTable</c> function retrieves the IPv4 routing table.</summary>
		/// <param name="sorted">
		/// <para>
		/// A Boolean value that specifies whether the returned table should be sorted. If this parameter is <c>TRUE</c>, the table is sorted
		/// in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Destination address</term>
		/// </item>
		/// <item>
		/// <term>Protocol that generated the route</term>
		/// </item>
		/// <item>
		/// <term>Multipath routing policy</term>
		/// </item>
		/// <item>
		/// <term>Next-hop address</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The IPv4 routing table as a MIB_IPFORWARDTABLE structure.</returns>
		/// <remarks>
		/// <para>
		/// The <c>dwForwardProto</c> member of the MIB_IPFORWARDROW structure specifies the protocol or routing mechanism that generated the
		/// route. See Protocol Identifiers for a list of possible protocols and routing mechanisms.
		/// </para>
		/// <para>
		/// The <c>dwForwardDest</c>, <c>dwForwardMask</c>, and <c>dwForwardNextHop</c> members of the MIB_IPFORWARDROW structure represent
		/// an IPv4 address in network byte order.
		/// </para>
		/// <para>
		/// An IPv4 address of 0.0.0.0 in the <c>dwForwardDest</c> member of the MIB_IPFORWARDROW structure is considered a default route.
		/// The MIB_IPFORWARDTABLE may contain multiple <c>MIB_IPFORWARDROW</c> entries with the <c>dwForwardDest</c> member set to 0.0.0.0
		/// when there are multiple network adapters installed.
		/// </para>
		/// <para>When <c>dwForwardAge</c> is set to <c>INFINITE</c>, the route will not be removed based on a timeout</para>
		/// <para>
		/// value. Any other value for <c>dwForwardAge</c> specifies the number of seconds since the route was added or modified in the
		/// network routing table.
		/// </para>
		/// <para>
		/// On Windows Server 2003 or Windows 2000 Server when the Routing and Remote Access Service (RRAS) is running, the MIB_IPFORWARDROW
		/// entries returned have the <c>dwForwardType</c> and <c>dwForwardAge</c> members set to zero.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the route metric specified in the <c>dwForwardMetric1</c> member of the
		/// MIB_IPFORWARDROW structure represents a combination of the route metric added to the interface metric specified in the
		/// <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. So the <c>dwForwardMetric1</c> member of
		/// the <c>MIB_IPFORWARDROW</c> structure should be equal to or greater than <c>Metric</c> member of the associated
		/// <c>MIB_IPINTERFACE_ROW</c> structure. If an application would like to set the route metric to 0 on Windows Vista and Windows
		/// Server 2008, then the <c>dwForwardMetric1</c> member of the <c>MIB_IPFORWARDROW</c> structure should be set equal to the value of
		/// the interface metric specified in the <c>Metric</c> member of the associated <c>MIB_IPINTERFACE_ROW</c> structure. An application
		/// can retrieve the interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// A number of members of the MIB_IPFORWARDROW structure entries returned by <c>GetIpForwardTable</c> are not currently used by IPv4
		/// routing. These members include <c>dwForwardPolicy</c>, <c>dwForwardNextHopAS</c>, <c>dwForwardMetric2</c>,
		/// <c>dwForwardMetric3</c>, <c>dwForwardMetric4</c>, and <c>dwForwardMetric5</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the IP routing table then prints some fields for each route in the table.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getipforwardtable DWORD GetIpForwardTable(
		// PMIB_IPFORWARDTABLE pIpForwardTable, PULONG pdwSize, BOOL bOrder );
		[PInvokeData("iphlpapi.h", MSDNShortId = "5d645353-7c87-4f8a-b7fd-149675a94743")]
		public static MIB_IPFORWARDTABLE GetIpForwardTable(bool sorted = false) => GetTable((IntPtr p, ref uint len) => GetIpForwardTable(p, ref len, sorted), len => new MIB_IPFORWARDTABLE(len));

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
		public static extern Win32Error GetIpNetTable(IntPtr IpNetTable, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The GetIpNetTable function retrieves the IPv4 to physical address mapping table.</summary>
		/// <param name="sorted">
		/// A Boolean value that specifies whether the returned mapping table should be sorted in ascending order by IP address. If this
		/// parameter is TRUE, the table is sorted.
		/// </param>
		/// <returns>The IPv4 to physical address mapping table as a MIB_IPNETTABLE structure.</returns>
		[PInvokeData("iphlpapi.h", MSDNShortId = "01bcf86e-5fcc-4ce9-bb89-02d393e75d1d")]
		public static MIB_IPNETTABLE GetIpNetTable(bool sorted = false) => GetTable((IntPtr p, ref uint len) => GetIpNetTable(p, ref len, sorted), len => new MIB_IPNETTABLE(len));

		/// <summary>The <c>GetIpStatistics</c> function retrieves the IP statistics for the current computer.</summary>
		/// <param name="Statistics">A pointer to a MIB_IPSTATS structure that receives the IP statistics for the local computer.</param>
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
		/// <term>The pStats parameter is NULL, or GetIpStatistics is unable to write to the memory pointed to by the pStats parameter.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetIpStatistics</c> function returns the statistics for IPv4 on the current computer. On Windows XP and later, the
		/// GetIpStatisticsEx can be used to obtain the IP statistics for either IPv4 or IPv6.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the IPv4 statistics for the local computer and prints values from the returned data.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getipstatistics ULONG GetIpStatistics( PMIB_IPSTATS
		// Statistics );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "15daaa34-2011-462a-9543-f8d7ccb9f6fd")]
		public static extern Win32Error GetIpStatistics(out MIB_IPSTATS Statistics);

		/// <summary>
		/// The <c>GetIpStatisticsEx</c> function retrieves the Internet Protocol (IP) statistics for the current computer. The
		/// <c>GetIpStatisticsEx</c> function differs from the GetIpStatistics function in that <c>GetIpStatisticsEx</c> also supports the
		/// Internet Protocol version 6 (IPv6) protocol family.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_IPSTATS structure that receives the IP statistics for the local computer.</param>
		/// <param name="Family">
		/// <para>The protocol family for which to retrieve statistics. This parameter must be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>Internet Protocol version 4 (IPv4).</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Internet Protocol version 6 (IPv6).</term>
		/// </item>
		/// </list>
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
		/// <term>The pStats parameter is NULL or does not point to valid memory, or the dwFamily parameter is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system on which the function call was made.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetIpStatisticsEx</c> can be used to obtain the IP statistics for either IPv4 or IPv6 on the local computer.</para>
		/// <para>The GetIpStatistics function returns the statistics for only IPv4 on the local computer.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getipstatisticsex ULONG GetIpStatisticsEx( PMIB_IPSTATS
		// Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "da9143cd-ccc9-4229-aa1e-d9949bbcb736")]
		public static extern Win32Error GetIpStatisticsEx(out MIB_IPSTATS Statistics, ADDRESS_FAMILY Family);

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
		public static extern Win32Error GetNetworkParams(IntPtr pFixedInfo, ref uint pOutBufLen);

		/// <summary>The GetNetworkParams function retrieves network parameters for the local computer.</summary>
		/// <returns>A <see cref="FIXED_INFO"/> structure that receives the network parameters for the local computer.</returns>
		[PInvokeData("iphlpapi.h", MSDNShortId = "5f54a120-5db9-4b8d-a281-1112be0042d6")]
		public static FIXED_INFO GetNetworkParams()
		{
			var mem = SafeCoTaskMemHandle.CreateFromStructure<FIXED_INFO>();
			var len = (uint)mem.Size;
			var e = GetNetworkParams(mem, ref len);
			if (e == Win32Error.ERROR_BUFFER_OVERFLOW)
			{
				mem.Size = (int)len;
				GetNetworkParams(mem, ref len).ThrowIfFailed();
			}
			else
			{
				e.ThrowIfFailed();
			}

			return mem.ToStructure<FIXED_INFO>();
		}

		/// <summary>The <c>GetNumberOfInterfaces</c> functions retrieves the number of interfaces on the local computer.</summary>
		/// <param name="pdwNumIf">Pointer to a <c>DWORD</c> variable that receives the number of interfaces on the local computer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		/// <remarks>
		/// The <c>GetNumberOfInterfaces</c> function returns the number of interfaces on the local computer, including the loopback
		/// interface. This number is one more than the number of adapters returned by the GetAdaptersInfo and GetInterfaceInfo functions
		/// because these functions do not return information about the loopback interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getnumberofinterfaces DWORD GetNumberOfInterfaces(
		// PDWORD pdwNumIf );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "655d63eb-455a-4a5e-97e2-7b7588eee4d9")]
		public static extern Win32Error GetNumberOfInterfaces(out uint pdwNumIf);

		/// <summary>Gets the owner module from pid and information. (Undocumented)</summary>
		/// <param name="ulPid">The pid.</param>
		/// <param name="pInfo">The information.</param>
		/// <param name="Class">
		///   <para>
		/// A TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module. The
		/// <c>TCPIP_OWNER_MODULE_INFO_CLASS</c> enumeration is defined in the Iprtrmib.h header file.
		/// </para>
		///   <para>This parameter must be set to <c>TCPIP_OWNER_MODULE_INFO_BASIC</c>.</para>
		/// </param>
		/// <param name="pBuffer">
		///   <para>
		/// A pointer to a buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data
		/// returned in this buffer is indicated by the value of the Class parameter.
		/// </para>
		///   <para>The following structures are used for the data in Buffer when Class is set to the corresponding value.</para>
		/// </param>
		/// <param name="pdwSize">
		/// The estimated size of the structure returned in Buffer, in bytes. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct structure size.
		/// </param>
		/// <returns>Undocumented.</returns>
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h")]
		public static extern Win32Error GetOwnerModuleFromPidAndInfo(uint ulPid, ulong[] pInfo, TCPIP_OWNER_MODULE_INFO_CLASS Class, [Out] IntPtr pBuffer, ref uint pdwSize);

		/// <summary>
		/// The <c>GetOwnerModuleFromTcp6Entry</c> function retrieves data about the module that issued the context bind for a specific IPv6
		/// TCP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pTcpEntry">
		/// A pointer to a MIB_TCP6ROW_OWNER_MODULE structure that contains the IPv6 TCP endpoint entry used to obtain the owner module.
		/// </param>
		/// <param name="Class">
		/// <para>
		/// A TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module. The
		/// <c>TCPIP_OWNER_MODULE_INFO_CLASS</c> enumeration is defined in the Iprtrmib.h header file.
		/// </para>
		/// <para>This parameter must be set to <c>TCPIP_OWNER_MODULE_INFO_BASIC</c>.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>
		/// A pointer to a buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data
		/// returned in this buffer is indicated by the value of the Class parameter.
		/// </para>
		/// <para>The following structures are used for the data in Buffer when Class is set to the corresponding value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Class enumeration value</term>
		/// <term>Buffer data format</term>
		/// </listheader>
		/// <item>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwSize">
		/// The estimated size of the structure returned in Buffer, in bytes. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct structure size.
		/// </param>
		/// <returns>
		/// <para>If the function call is successful, the value <c>NO_ERROR</c> is returned.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// Insufficient space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must be used in a
		/// subsequent call to this function in order to successfully retrieve the table.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This value is returned if either of the pTcpEntry or pdwSize parameters are NULL. This value is also
		/// returned if the Class parameter is not equal to TCPIP_OWNER_MODULE_INFO_BASIC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The element was not found. This value is returned if the dwOwningPid member of the MIB_TCP6ROW_OWNER_MODULE pointed to by the
		/// pTcpEntry parameter was zero or could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_PARTIAL_COPY</term>
		/// <term>Only part of a request was completed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Buffer parameter contains not only a structure with pointers to specific data, for example, pointers to the zero-terminated
		/// strings that contain the name and path of the owner module, but the actual data itself; that is the name and path strings.
		/// Therefore, when calculating the size of the buffer, ensure that you have enough space for both the structure as well as the data
		/// the members of the structure point to.
		/// </para>
		/// <para>
		/// The resolution of TCP table entries to owner modules is a best practice. In a few cases, the owner module name returned in the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure can be a process name (such as "svchost.exe"), a service name (such as "RPC"), or a
		/// component name (such as "timer.dll").
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO retrieved by GetOwnerModuleFromTcpEntry function may point to an empty string for some TCP
		/// connections. Applications that start TCP connections located in the Windows system folder (C:\Windows\System32, by default) are
		/// considered protected. If the <c>GetOwnerModuleFromTcpEntry</c> function is called by a user that is not a member of the
		/// Administrators group, the function call will succeed but the <c>pModuleName</c> and <c>pModulePath</c> members will point to
		/// memory that contains an empty string for the TCP connections started by protected applications.
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, accessing the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure is limited by user account control (UAC). If an application that calls this function is
		/// executed by a user logged on as a member of the Administrators group other than the built-in Administrator, this call will
		/// succeed but access to these members returns an empty string unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or later lacks this manifest
		/// file, a user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for access to the protected
		/// <c>pModuleName</c> and <c>pModulePath</c> members to be allowed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromtcp6entry DWORD
		// GetOwnerModuleFromTcp6Entry( PMIB_TCP6ROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD
		// pdwSize );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "021679fc-91de-4e3b-956d-bb00b1856f20")]
		public static extern Win32Error GetOwnerModuleFromTcp6Entry(in MIB_TCP6ROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr pBuffer, ref uint pdwSize);

		/// <summary>
		/// The <c>GetOwnerModuleFromTcp6Entry</c> function retrieves data about the module that issued the context bind for a specific IPv6
		/// TCP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pTcpEntry">
		/// A pointer to a MIB_TCP6ROW_OWNER_MODULE structure that contains the IPv6 TCP endpoint entry used to obtain the owner module.
		/// </param>
		/// <returns>
		/// <para>
		/// A pointer to a buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data
		/// returned in this buffer is indicated by the value of the Class parameter.
		/// </para>
		/// <para>The following structures are used for the data in Buffer when Class is set to the corresponding value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Class enumeration value</term>
		/// <term>Buffer data format</term>
		/// </listheader>
		/// <item>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromtcp6entry
		[PInvokeData("iphlpapi.h", MSDNShortId = "021679fc-91de-4e3b-956d-bb00b1856f20")]
		public static TCPIP_OWNER_MODULE_BASIC_INFO GetOwnerModuleFromTcp6Entry(in MIB_TCP6ROW_OWNER_MODULE pTcpEntry)
		{
			var s = pTcpEntry;
			return FunctionHelper.CallMethodWithTypedBuf<TCPIP_OWNER_MODULE_BASIC_INFO, uint>(
				(IntPtr p, ref uint l) => GetOwnerModuleFromTcp6Entry(s, TCPIP_OWNER_MODULE_INFO_CLASS.TCPIP_OWNER_MODULE_INFO_BASIC, p, ref l),
				null, (p, l) => p.ToStructure<TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD>(), Win32Error.ERROR_INSUFFICIENT_BUFFER);
		}

		/// <summary>
		/// The <c>GetOwnerModuleFromTcpEntry</c> function retrieves data about the module that issued the context bind for a specific IPv4
		/// TCP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pTcpEntry">
		/// A pointer to a MIB_TCPROW_OWNER_MODULE structure that contains the IPv4 TCP endpoint entry used to obtain the owner module.
		/// </param>
		/// <param name="Class">
		/// <para>
		/// A TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module. The
		/// <c>TCPIP_OWNER_MODULE_INFO_CLASS</c> enumeration is defined in the Iprtrmib.h header file.
		/// </para>
		/// <para>This parameter must be set to <c>TCPIP_OWNER_MODULE_INFO_BASIC</c>.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>
		/// A pointer a buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned
		/// in this buffer is indicated by the value of the Class parameter.
		/// </para>
		/// <para>The following structures are used for the data in Buffer when Class is set to the corresponding value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Class enumeration value</term>
		/// <term>Buffer data format</term>
		/// </listheader>
		/// <item>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwSize">
		/// The estimated size, in bytes, of the structure returned in Buffer. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct size of the buffer. The
		/// size required is the size of the corresponding structure plus an additional number of bytes equal to the length of data pointed
		/// to in the structure (for example, the name and path strings).
		/// </param>
		/// <returns>
		/// <para>If the function call is successful, the value <c>NO_ERROR</c> is returned.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// Insufficient space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must be used in a
		/// subsequent call to this function in order to successfully retrieve the table.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This value is returned if either of the pTcpEntry or pdwSize parameters are NULL. This value is also
		/// returned if the Class parameter is not equal to TCPIP_OWNER_MODULE_INFO_BASIC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// A element was no found. This value is returned if the dwOwningPid member of the MIB_TCPROW_OWNER_MODULE structure pointed to by
		/// the pTcpEntry parameter was zero or could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_PARTIAL_COPY</term>
		/// <term>Only part of a request was completed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Buffer parameter contains not only a structure with pointers to specific data, for example, pointers to the zero-terminated
		/// strings that contain the name and path of the owner module, but the actual data itself; that is the name and path strings.
		/// Therefore, when calculating the buffer size, ensure that you have enough space for both the structure as well as the data the
		/// members of the structure point to.
		/// </para>
		/// <para>
		/// The resolution of TCP table entries to owner modules is a best practice. In a few cases, the owner module name returned in the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure can be a process name, such as "svchost.exe", a service name (such as "RPC"), or a
		/// component name, such as "timer.dll".
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO retrieved by <c>GetOwnerModuleFromTcpEntry</c> function may point to an empty string for some TCP
		/// connections. Applications that start TCP connections located in the Windows system folder (C:\Windows\System32, by default) are
		/// considered protected. If the <c>GetOwnerModuleFromTcpEntry</c> function is called by a user that is not a member of the
		/// Administrators group, the function call will succeed but the <c>pModuleName</c> and <c>pModulePath</c> members will point to
		/// memory that contains an empty string for the TCP connections started by protected applications.
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, accessing the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure is limited by user account control (UAC). If an application that calls this function is
		/// executed by a user logged on as a member of the Administrators group other than the built-in Administrator, this call will
		/// succeed but access to these members returns an empty string unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or later lacks this manifest
		/// file, a user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for access to the protected
		/// <c>pModuleName</c> and <c>pModulePath</c> members to be allowed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromtcpentry DWORD
		// GetOwnerModuleFromTcpEntry( PMIB_TCPROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD pdwSize );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "12162f0a-56c1-4f81-a1f5-3cd5ad975d0d")]
		public static extern Win32Error GetOwnerModuleFromTcpEntry(in MIB_TCPROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr pBuffer, ref uint pdwSize);

		/// <summary>
		/// The <c>GetOwnerModuleFromTcpEntry</c> function retrieves data about the module that issued the context bind for a specific IPv4
		/// TCP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pTcpEntry">
		/// A pointer to a MIB_TCPROW_OWNER_MODULE structure that contains the IPv4 TCP endpoint entry used to obtain the owner module.
		/// </param>
		/// <returns>
		/// <para>If the function call is successful, the value <c>NO_ERROR</c> is returned.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// Insufficient space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must be used in a
		/// subsequent call to this function in order to successfully retrieve the table.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This value is returned if either of the pTcpEntry or pdwSize parameters are NULL. This value is also
		/// returned if the Class parameter is not equal to TCPIP_OWNER_MODULE_INFO_BASIC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// A element was no found. This value is returned if the dwOwningPid member of the MIB_TCPROW_OWNER_MODULE structure pointed to by
		/// the pTcpEntry parameter was zero or could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_PARTIAL_COPY</term>
		/// <term>Only part of a request was completed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Buffer parameter contains not only a structure with pointers to specific data, for example, pointers to the zero-terminated
		/// strings that contain the name and path of the owner module, but the actual data itself; that is the name and path strings.
		/// Therefore, when calculating the buffer size, ensure that you have enough space for both the structure as well as the data the
		/// members of the structure point to.
		/// </para>
		/// <para>
		/// The resolution of TCP table entries to owner modules is a best practice. In a few cases, the owner module name returned in the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure can be a process name, such as "svchost.exe", a service name (such as "RPC"), or a
		/// component name, such as "timer.dll".
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO retrieved by <c>GetOwnerModuleFromTcpEntry</c> function may point to an empty string for some TCP
		/// connections. Applications that start TCP connections located in the Windows system folder (C:\Windows\System32, by default) are
		/// considered protected. If the <c>GetOwnerModuleFromTcpEntry</c> function is called by a user that is not a member of the
		/// Administrators group, the function call will succeed but the <c>pModuleName</c> and <c>pModulePath</c> members will point to
		/// memory that contains an empty string for the TCP connections started by protected applications.
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, accessing the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure is limited by user account control (UAC). If an application that calls this function is
		/// executed by a user logged on as a member of the Administrators group other than the built-in Administrator, this call will
		/// succeed but access to these members returns an empty string unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or later lacks this manifest
		/// file, a user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for access to the protected
		/// <c>pModuleName</c> and <c>pModulePath</c> members to be allowed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromtcpentry DWORD
		// GetOwnerModuleFromTcpEntry( PMIB_TCPROW_OWNER_MODULE pTcpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD pdwSize );
		[PInvokeData("iphlpapi.h", MSDNShortId = "12162f0a-56c1-4f81-a1f5-3cd5ad975d0d")]
		public static TCPIP_OWNER_MODULE_BASIC_INFO GetOwnerModuleFromTcpEntry(in MIB_TCPROW_OWNER_MODULE pTcpEntry)
		{
			var s = pTcpEntry;
			return FunctionHelper.CallMethodWithTypedBuf<TCPIP_OWNER_MODULE_BASIC_INFO, uint>(
				(IntPtr p, ref uint l) => GetOwnerModuleFromTcpEntry(s, TCPIP_OWNER_MODULE_INFO_CLASS.TCPIP_OWNER_MODULE_INFO_BASIC, p, ref l),
				null, (p, l) => p.ToStructure<TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD>(), Win32Error.ERROR_INSUFFICIENT_BUFFER);
		}

		/// <summary>
		/// The <c>GetOwnerModuleFromUdp6Entry</c> function retrieves data about the module that issued the context bind for a specific IPv6
		/// UDP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pUdpEntry">
		/// A pointer to a MIB_UDP6ROW_OWNER_MODULE structure that contains the IPv6 UDP endpoint entry used to obtain the owner module.
		/// </param>
		/// <param name="Class">
		/// TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module.
		/// </param>
		/// <param name="pBuffer">
		/// <para>
		/// The buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned in this
		/// buffer is indicated by the value of the Class parameter.
		/// </para>
		/// <para>The following structures are used for the data in Buffer when Class is set to the corresponding value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Class enumeration value</term>
		/// <term>Buffer data format</term>
		/// </listheader>
		/// <item>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwSize">
		/// The estimated size, in bytes, of the structure returned in Buffer. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct size of the structure.
		/// </param>
		/// <returns>
		/// <para>If the call is successful, the value <c>NO_ERROR</c> is returned. Otherwise, the following error is returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// An insufficient amount of space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must
		/// be used in a subsequent call to this function in order to successfully retrieve the table.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Buffer parameter contains not only a structure with pointers to specific data, for example, pointers to the zero-terminated
		/// strings that contain the name and path of the owner module, but the actual data itself; that is the name and path strings.
		/// Therefore, when calculating the buffer size, ensure that you have enough space for both the structure as well as the data the
		/// members of the structure point to.
		/// </para>
		/// <para>
		/// The resolution of UDP table entries to owner modules is a best practice. In a few cases, the owner module name returned in the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure can be a process name, such as "svchost.exe", a service name, such as "RPC", or a
		/// component name, such as "timer.dll".
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, accessing the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure is limited by user account control (UAC). If an application that calls this function is
		/// executed by a user logged on as a member of the Administrators group other than the built-in Administrator, this call will
		/// succeed but access to these members returns an empty string unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or later lacks this manifest
		/// file, a user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for access to the protected
		/// <c>pModuleName</c> and <c>pModulePath</c> members to be allowed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromudp6entry DWORD
		// GetOwnerModuleFromUdp6Entry( PMIB_UDP6ROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD
		// pdwSize );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "01ed27b6-3ca6-4c9c-8910-a71a073c2ca2")]
		public static extern Win32Error GetOwnerModuleFromUdp6Entry(in MIB_UDP6ROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr pBuffer, ref uint pdwSize);

		/// <summary>
		/// The <c>GetOwnerModuleFromUdp6Entry</c> function retrieves data about the module that issued the context bind for a specific IPv6
		/// UDP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pUdpEntry">
		/// A pointer to a MIB_UDP6ROW_OWNER_MODULE structure that contains the IPv6 UDP endpoint entry used to obtain the owner module.
		/// </param>
		/// <returns>The buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromudp6entry DWORD
		// GetOwnerModuleFromUdp6Entry( PMIB_UDP6ROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD
		// pdwSize );
		[PInvokeData("iphlpapi.h", MSDNShortId = "01ed27b6-3ca6-4c9c-8910-a71a073c2ca2")]
		public static TCPIP_OWNER_MODULE_BASIC_INFO GetOwnerModuleFromUdp6Entry(in MIB_UDP6ROW_OWNER_MODULE pUdpEntry)
		{
			var s = pUdpEntry;
			return FunctionHelper.CallMethodWithTypedBuf<TCPIP_OWNER_MODULE_BASIC_INFO, uint>(
				(IntPtr p, ref uint l) => GetOwnerModuleFromUdp6Entry(s, TCPIP_OWNER_MODULE_INFO_CLASS.TCPIP_OWNER_MODULE_INFO_BASIC, p, ref l),
				null, (p, l) => p.ToStructure<TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD>(), Win32Error.ERROR_INSUFFICIENT_BUFFER);
		}

		/// <summary>
		/// The <c>GetOwnerModuleFromUdpEntry</c> function retrieves data about the module that issued the context bind for a specific IPv4
		/// UDP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pUdpEntry">
		/// A pointer to a MIB_UDPROW_OWNER_MODULE structure that contains the IPv4 UDP endpoint entry used to obtain the owner module.
		/// </param>
		/// <param name="Class">
		/// A TCPIP_OWNER_MODULE_INFO_CLASS enumeration value that indicates the type of data to obtain regarding the owner module.
		/// </param>
		/// <param name="pBuffer">
		/// <para>
		/// The buffer that contains a TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data. The type of data returned in this
		/// buffer is indicated by the value of the Class parameter.
		/// </para>
		/// <para>The following structures are used for the data in Buffer when Class is set to the corresponding value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Class enumeration value</term>
		/// <term>Buffer data format</term>
		/// </listheader>
		/// <item>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// <term>TCPIP_OWNER_MODULE_BASIC_INFO</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwSize">
		/// The estimated size, in bytes, of the structure returned in Buffer. If this value is set too small,
		/// <c>ERROR_INSUFFICIENT_BUFFER</c> is returned by this function, and this field will contain the correct structure size.
		/// </param>
		/// <returns>
		/// <para>If the call is successful, the value <c>NO_ERROR</c> is returned. Otherwise, the following error is returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// Insufficient space was allocated for the table. The size of the table is returned in the pdwSize parameter, and must be used in a
		/// subsequent call to this function in order to successfully retrieve the table.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Buffer parameter contains not only a structure with pointers to specific data, for example, pointers to the zero-terminated
		/// strings that contain the name and path of the owner module, but also the actual data itself; that is the name and path strings.
		/// Therefore, when calculating the buffer size, ensure that you have enough space for both the structure as well as the data the
		/// members of the structure point to.
		/// </para>
		/// <para>
		/// The resolution of UDP table entries to owner modules is a best practice. In a few cases, the owner module name returned in the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure can be a process name, such as "svchost.exe", a service name, such as "RPC", or a
		/// component name, such as "timer.dll".
		/// </para>
		/// <para>
		/// For computers running on Windows Vista or later, accessing the <c>pModuleName</c> and <c>pModulePath</c> members of the
		/// TCPIP_OWNER_MODULE_BASIC_INFO structure is limited by user account control (UAC). If an application that calls this function is
		/// executed by a user logged on as a member of the Administrators group other than the built-in Administrator, this call will
		/// succeed but access to these members returns an empty string unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or later lacks this manifest
		/// file, a user logged on as a member of the Administrators group other than the built-in Administrator must then be executing the
		/// application in an enhanced shell as the built-in Administrator (RunAs administrator) for access to the protected
		/// <c>pModuleName</c> and <c>pModulePath</c> members to be allowed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromudpentry DWORD
		// GetOwnerModuleFromUdpEntry( PMIB_UDPROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD pdwSize );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "bd8f82b0-4a2d-48f1-8ae7-85257c6ae656")]
		public static extern Win32Error GetOwnerModuleFromUdpEntry(in MIB_UDPROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, IntPtr pBuffer, ref uint pdwSize);

		/// <summary>
		/// The <c>GetOwnerModuleFromUdpEntry</c> function retrieves data about the module that issued the context bind for a specific IPv4
		/// UDP endpoint in a MIB table row.
		/// </summary>
		/// <param name="pUdpEntry">
		/// A pointer to a MIB_UDPROW_OWNER_MODULE structure that contains the IPv4 UDP endpoint entry used to obtain the owner module.
		/// </param>
		/// <returns>A TCPIP_OWNER_MODULE_BASIC_INFO structure with the owner module data.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getownermodulefromudpentry DWORD
		// GetOwnerModuleFromUdpEntry( PMIB_UDPROW_OWNER_MODULE pUdpEntry, TCPIP_OWNER_MODULE_INFO_CLASS Class, PVOID pBuffer, PDWORD pdwSize );
		[PInvokeData("iphlpapi.h", MSDNShortId = "bd8f82b0-4a2d-48f1-8ae7-85257c6ae656")]
		public static TCPIP_OWNER_MODULE_BASIC_INFO GetOwnerModuleFromUdpEntry(in MIB_UDPROW_OWNER_MODULE pUdpEntry)
		{
			var s = pUdpEntry;
			return FunctionHelper.CallMethodWithTypedBuf<TCPIP_OWNER_MODULE_BASIC_INFO, uint>(
				(IntPtr p, ref uint l) => GetOwnerModuleFromUdpEntry(s, TCPIP_OWNER_MODULE_INFO_CLASS.TCPIP_OWNER_MODULE_INFO_BASIC, p, ref l),
				null, (p, l) => p.ToStructure<TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD>(), Win32Error.ERROR_INSUFFICIENT_BUFFER);
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
		[PInvokeData("iphlpapi.h", MSDNShortId = "fc1ae7e4-f856-4b48-8ab4-56cd511ed161")]
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

		/// <summary>The <c>GetPerTcp6ConnectionEStats</c> function retrieves extended statistics for an IPv6 TCP connection.</summary>
		/// <param name="Row">A pointer to a MIB_TCP6ROW structure for an IPv6 TCP connection.</param>
		/// <param name="EstatsType">
		/// <para>
		/// The type of extended statistics for TCP requested. This parameter determines the data and format of information that is returned
		/// in the Rw, Rod, and Ros parameters if the call is successful.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsSynOpts</term>
		/// <term>
		/// This value requests SYN exchange information for a TCP connection. Only read-only static information is available for this
		/// enumeration value. If the Ros parameter was not NULL and the function succeeds, the buffer pointed to by the Ros parameter should
		/// contain a TCP_ESTATS_SYN_OPTS_ROS_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>
		/// This value requests extended data transfer information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_DATA_RW_v0 structure. If extended data transfer information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_DATA_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>
		/// This value requests sender congestion for a TCP connection. All three types of information (read-only static, read-only dynamic,
		/// and read/write information) are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds,
		/// the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_SND_CONG_RW_v0 structure. If the Ros parameter was not NULL
		/// and the function succeeds, the buffer pointed to by the Ros parameter should contain a TCP_ESTATS_SND_CONG_ROS_v0 structure. If
		/// sender congestion information was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the
		/// buffer pointed to by the Rod parameter should contain a TCP_ESTATS_SND_CONG_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>
		/// This value requests extended path measurement information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_PATH_RW_v0 structure. If extended path measurement information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_PATH_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>
		/// This value requests extended output-queuing information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_SEND_BUFF_RW_v0 structure. If extended output-queuing information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_SEND_BUFF_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>
		/// This value requests extended local-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_REC_RW_v0 structure. If extended local-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_REC_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>
		/// This value requests extended remote-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_OBS_REC_RW_v0 structure. If extended remote-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_OBS_REC_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>
		/// This value requests bandwidth estimation statistics for a TCP connection on bandwidth. Only read-only dynamic information and
		/// read/write information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the
		/// buffer pointed to by the Rw parameter should contain a TCP_ESTATS_BANDWIDTH_RW_v0 structure. If bandwidth estimation statistics
		/// was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_BANDWIDTH_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>
		/// This value requests fine-grained round-trip time (RTT) estimation statistics for a TCP connection. Only read-only dynamic
		/// information and read/write information are available for this enumeration value. If the Rw parameter was not NULL and the
		/// function succeeds, the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_FINE_RTT_RW_v0 structure. If
		/// fine-grained RTT estimation statistics was enabled for this TCP connection, the Rod parameter was not NULL, and the function
		/// succeeds, the buffer pointed to by the Rod parameter should contain a TCP_ESTATS_FINE_RTT_ROD_v0 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Rw">
		/// A pointer to a buffer to receive the read/write information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read/write information for the TCP connection.
		/// </param>
		/// <param name="RwVersion">The version of the read/write information requested. The current supported value is a version of zero.</param>
		/// <param name="RwSize">The size, in bytes, of the buffer pointed to by Rw parameter.</param>
		/// <param name="Ros">
		/// A pointer to a buffer to receive read-only static information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read-only static information for the TCP connection.
		/// </param>
		/// <param name="RosVersion">
		/// The version of the read-only static information requested. The current supported value is a version of zero.
		/// </param>
		/// <param name="RosSize">The size, in bytes, of the buffer pointed to by the Ros parameter.</param>
		/// <param name="Rod">
		/// A pointer to a buffer to receive read-only dynamic information. This parameter may be a <c>NULL</c> pointer if an application
		/// does not want to retrieve read-only dynamic information for the TCP connection.
		/// </param>
		/// <param name="RodVersion">
		/// The version of the read-only dynamic information requested. The current supported value is a version of zero..
		/// </param>
		/// <param name="RodSize">The size, in bytes, of the buffer pointed to by the Rod parameter.</param>
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
		/// A buffer passed to a function is too small. This error is returned if the buffer pointed to by the Rw, Ros, or Rod parameters is
		/// not large enough to receive the data. This error also returned if one of the given buffers pointed to by the Rw, Ros, or Rod
		/// parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. This error value is returned on
		/// Windows Vista and Windows Server 2008.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if one of the given buffers pointed to
		/// by the Rw, Ros, or Rod parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. As a result,
		/// this error is returned if any of the following conditions are met: This error value is returned on Windows 7 and Windows Server
		/// 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the RwVersion, RosVersion, or RodVersion parameter is not set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetPerTcp6ConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetPerTcp6ConnectionEStats</c> function is designed to use TCP to diagnose performance problems in both the network and
		/// the application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// The <c>GetPerTcp6ConnectionEStats</c> function retrieves extended statistics for the IPv6 TCP connection passed in the Row
		/// parameter. The type of extended statistics that is retrieved is specified in the EstatsType parameter. Extended statistics on
		/// this TCP connection must have previously been enabled by calls to the SetPerTcp6ConnectionEStats function for all TCP_ESTATS_TYPE
		/// values except when <c>TcpConnectionEstatsSynOpts</c> is passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The GetTcp6Table function is used to retrieve the IPv6 TCP connection table on the local computer. This function returns a
		/// MIB_TCP6TABLE structure that contain an array of MIB_TCP6ROW entries. The Row parameter passed to the
		/// <c>GetPerTcp6ConnectionEStats</c> function must be an entry for an existing IPv6 TCP connection.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion, RosVersion, and RodVersion
		/// parameters passed to <c>GetPerTcp6ConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv4 connection, see the GetPerTcpConnectionEStats and SetPerTcpConnectionEStats functions.
		/// </para>
		/// <para>
		/// The SetPerTcp6ConnectionEStats function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcp6ConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and later. If an application that contains this function is executed by a user logged on as a member of the Administrators
		/// group other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with
		/// a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// An application that uses the <c>GetPerTcp6ConnectionEStats</c> function to retrieve extended statistics for an IPv6 TCP
		/// connection must check that the previous call to the SetPerTcp6ConnectionEStats function to enabled extended statistics returned
		/// with success. If the <c>SetPerTcp6ConnectionEStats</c> function to enable extended statistics failed, subsequent calls to the
		/// <c>GetPerTcp6ConnectionEStats</c> will still return numbers in the returned structures. However the returned numbers are
		/// meaningless random data and don't represent extended TCP statistics. This behavior can be observed by running the example below
		/// as both an administrator and a normal user.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP extended statistics for an IPv4 and IPv6 TCP connection and prints values from the
		/// returned data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getpertcp6connectionestats ULONG
		// GetPerTcp6ConnectionEStats( PMIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, PUCHAR Ros,
		// ULONG RosVersion, ULONG RosSize, PUCHAR Rod, ULONG RodVersion, ULONG RodSize );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "291aabe7-a4e7-4cc7-9cf3-4a4bc021e15e")]
		public static extern Win32Error GetPerTcp6ConnectionEStats(in MIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, [Out, Optional] IntPtr Rw, uint RwVersion, uint RwSize,
			[Out, Optional] IntPtr Ros, uint RosVersion, uint RosSize, [Out, Optional] IntPtr Rod, uint RodVersion, uint RodSize);

		/// <summary>
		/// The <c>GetPerTcp6ConnectionEStats</c> function retrieves extended statistics for an IPv6 TCP connection.
		/// </summary>
		/// <param name="Row">A pointer to a MIB_TCP6ROW structure for an IPv6 TCP connection.</param>
		/// <param name="EstatsType"><para>
		/// The type of extended statistics for TCP requested. This parameter determines the data and format of information that is returned
		/// in the Rw, Rod, and Ros parameters if the call is successful.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>TcpConnectionEstatsSynOpts</term>
		///     <term>
		/// This value requests SYN exchange information for a TCP connection. Only read-only static information is available for this
		/// enumeration value. If the Ros parameter was not NULL and the function succeeds, the buffer pointed to by the Ros parameter should
		/// contain a TCP_ESTATS_SYN_OPTS_ROS_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsData</term>
		///     <term>
		/// This value requests extended data transfer information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_DATA_RW_v0 structure. If extended data transfer information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_DATA_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsSndCong</term>
		///     <term>
		/// This value requests sender congestion for a TCP connection. All three types of information (read-only static, read-only dynamic,
		/// and read/write information) are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds,
		/// the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_SND_CONG_RW_v0 structure. If the Ros parameter was not NULL
		/// and the function succeeds, the buffer pointed to by the Ros parameter should contain a TCP_ESTATS_SND_CONG_ROS_v0 structure. If
		/// sender congestion information was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the
		/// buffer pointed to by the Rod parameter should contain a TCP_ESTATS_SND_CONG_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsPath</term>
		///     <term>
		/// This value requests extended path measurement information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_PATH_RW_v0 structure. If extended path measurement information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_PATH_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsSendBuff</term>
		///     <term>
		/// This value requests extended output-queuing information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_SEND_BUFF_RW_v0 structure. If extended output-queuing information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_SEND_BUFF_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsRec</term>
		///     <term>
		/// This value requests extended local-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_REC_RW_v0 structure. If extended local-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_REC_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsObsRec</term>
		///     <term>
		/// This value requests extended remote-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_OBS_REC_RW_v0 structure. If extended remote-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_OBS_REC_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsBandwidth</term>
		///     <term>
		/// This value requests bandwidth estimation statistics for a TCP connection on bandwidth. Only read-only dynamic information and
		/// read/write information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the
		/// buffer pointed to by the Rw parameter should contain a TCP_ESTATS_BANDWIDTH_RW_v0 structure. If bandwidth estimation statistics
		/// was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_BANDWIDTH_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsFineRtt</term>
		///     <term>
		/// This value requests fine-grained round-trip time (RTT) estimation statistics for a TCP connection. Only read-only dynamic
		/// information and read/write information are available for this enumeration value. If the Rw parameter was not NULL and the
		/// function succeeds, the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_FINE_RTT_RW_v0 structure. If
		/// fine-grained RTT estimation statistics was enabled for this TCP connection, the Rod parameter was not NULL, and the function
		/// succeeds, the buffer pointed to by the Rod parameter should contain a TCP_ESTATS_FINE_RTT_ROD_v0 structure.
		/// </term>
		///   </item>
		/// </list></param>
		/// <param name="Rw">A pointer to a buffer to receive the read/write information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read/write information for the TCP connection.</param>
		/// <param name="Ros">A pointer to a buffer to receive read-only static information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read-only static information for the TCP connection.</param>
		/// <param name="Rod">A pointer to a buffer to receive read-only dynamic information. This parameter may be a <c>NULL</c> pointer if an application
		/// does not want to retrieve read-only dynamic information for the TCP connection.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>ERROR_INSUFFICIENT_BUFFER</term>
		///     <term>
		/// A buffer passed to a function is too small. This error is returned if the buffer pointed to by the Rw, Ros, or Rod parameters is
		/// not large enough to receive the data. This error also returned if one of the given buffers pointed to by the Rw, Ros, or Rod
		/// parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. This error value is returned on
		/// Windows Vista and Windows Server 2008.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ERROR_INVALID_PARAMETER</term>
		///     <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_INVALID_USER_BUFFER</term>
		///     <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if one of the given buffers pointed to
		/// by the Rw, Ros, or Rod parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. As a result,
		/// this error is returned if any of the following conditions are met: This error value is returned on Windows 7 and Windows Server
		/// 2008 R2.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_FOUND</term>
		///     <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_SUPPORTED</term>
		///     <term>
		/// The request is not supported. This error is returned if the RwVersion, RosVersion, or RodVersion parameter is not set to zero.
		/// </term>
		///   </item>
		///   <item>
		///     <term>Other</term>
		///     <term>Use FormatMessage to obtain the message string for the returned error.</term>
		///   </item>
		/// </list></returns>
		/// <remarks>
		/// <para>The <c>GetPerTcp6ConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetPerTcp6ConnectionEStats</c> function is designed to use TCP to diagnose performance problems in both the network and
		/// the application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// The <c>GetPerTcp6ConnectionEStats</c> function retrieves extended statistics for the IPv6 TCP connection passed in the Row
		/// parameter. The type of extended statistics that is retrieved is specified in the EstatsType parameter. Extended statistics on
		/// this TCP connection must have previously been enabled by calls to the SetPerTcp6ConnectionEStats function for all TCP_ESTATS_TYPE
		/// values except when <c>TcpConnectionEstatsSynOpts</c> is passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The GetTcp6Table function is used to retrieve the IPv6 TCP connection table on the local computer. This function returns a
		/// MIB_TCP6TABLE structure that contain an array of MIB_TCP6ROW entries. The Row parameter passed to the
		/// <c>GetPerTcp6ConnectionEStats</c> function must be an entry for an existing IPv6 TCP connection.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion, RosVersion, and RodVersion
		/// parameters passed to <c>GetPerTcp6ConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv4 connection, see the GetPerTcpConnectionEStats and SetPerTcpConnectionEStats functions.
		/// </para>
		/// <para>
		/// The SetPerTcp6ConnectionEStats function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcp6ConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and later. If an application that contains this function is executed by a user logged on as a member of the Administrators
		/// group other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with
		/// a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// An application that uses the <c>GetPerTcp6ConnectionEStats</c> function to retrieve extended statistics for an IPv6 TCP
		/// connection must check that the previous call to the SetPerTcp6ConnectionEStats function to enabled extended statistics returned
		/// with success. If the <c>SetPerTcp6ConnectionEStats</c> function to enable extended statistics failed, subsequent calls to the
		/// <c>GetPerTcp6ConnectionEStats</c> will still return numbers in the returned structures. However the returned numbers are
		/// meaningless random data and don't represent extended TCP statistics. This behavior can be observed by running the example below
		/// as both an administrator and a normal user.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getpertcp6connectionestats ULONG
		// GetPerTcp6ConnectionEStats( PMIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, PUCHAR Ros,
		// ULONG RosVersion, ULONG RosSize, PUCHAR Rod, ULONG RodVersion, ULONG RodSize );
		[PInvokeData("iphlpapi.h", MSDNShortId = "291aabe7-a4e7-4cc7-9cf3-4a4bc021e15e")]
		public static Win32Error GetPerTcp6ConnectionEStats(in MIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, out object Rw, out object Ros, out object Rod)
		{
			var types = CorrespondingTypeAttribute.GetCorrespondingTypes(EstatsType);
			var trw = types.FirstOrDefault(t => t.Name.Contains("_RW_"));
			var tros = types.FirstOrDefault(t => t.Name.Contains("_ROS_"));
			var trod = types.FirstOrDefault(t => t.Name.Contains("_ROD_"));
			var srw = trw != null ? (uint)Marshal.SizeOf(trw) : 0;
			var sros = tros != null ? (uint)Marshal.SizeOf(tros) : 0;
			var srod = trod != null ? (uint)Marshal.SizeOf(trod) : 0;
			var mrw = new SafeCoTaskMemHandle((int)srw);
			var mros = new SafeCoTaskMemHandle((int)sros);
			var mrod = new SafeCoTaskMemHandle((int)srod);
			var ret = GetPerTcp6ConnectionEStats(Row, EstatsType, mrw, 0, srw, mros, 0, sros, mrod, 0, srod);
			Rw = ret.Failed || srw == 0 ? null : Marshal.PtrToStructure(mrw, trw);
			Ros = ret.Failed || sros == 0 ? null : Marshal.PtrToStructure(mros, tros);
			Rod = ret.Failed || srod == 0 ? null : Marshal.PtrToStructure(mrod, trod);
			return ret;
		}

		/// <summary>The <c>GetPerTcpConnectionEStats</c> function retrieves extended statistics for an IPv4 TCP connection.</summary>
		/// <param name="Row">A pointer to a MIB_TCPROW structure for an IPv4 TCP connection.</param>
		/// <param name="EstatsType">
		/// <para>
		/// The type of extended statistics for TCP requested. This parameter determines the data and format of information that is returned
		/// in the Rw, Rod, and Ros parameters if the call is successful.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsSynOpts</term>
		/// <term>
		/// This value requests SYN exchange information for a TCP connection. Only read-only static information is available for this
		/// enumeration value. If the Ros parameter was not NULL and the function succeeds, the buffer pointed to by the Ros parameter should
		/// contain a TCP_ESTATS_SYN_OPTS_ROS_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>
		/// This value requests extended data transfer information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_DATA_RW_v0 structure. If extended data transfer information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_DATA_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>
		/// This value requests sender congestion for a TCP connection. All three types of information (read-only static, read-only dynamic,
		/// and read/write information) are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds,
		/// the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_SND_CONG_RW_v0 structure. If the Ros parameter was not NULL
		/// and the function succeeds, the buffer pointed to by the Ros parameter should contain a TCP_ESTATS_SND_CONG_ROS_v0 structure. If
		/// sender congestion information was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the
		/// buffer pointed to by the Rod parameter should contain a TCP_ESTATS_SND_CONG_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>
		/// This value requests extended path measurement information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_PATH_RW_v0 structure. If extended path measurement information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_PATH_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>
		/// This value requests extended output-queuing information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_SEND_BUFF_RW_v0 structure. If extended output-queuing information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_SEND_BUFF_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>
		/// This value requests extended local-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_REC_RW_v0 structure. If extended local-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_REC_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>
		/// This value requests extended remote-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_OBS_REC_RW_v0 structure. If extended remote-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_OBS_REC_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>
		/// This value requests bandwidth estimation statistics for a TCP connection on bandwidth. Only read-only dynamic information and
		/// read/write information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the
		/// buffer pointed to by the Rw parameter should contain a TCP_ESTATS_BANDWIDTH_RW_v0 structure. If bandwidth estimation statistics
		/// was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_BANDWIDTH_ROD_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>
		/// This value requests fine-grained round-trip time (RTT) estimation statistics for a TCP connection. Only read-only dynamic
		/// information and read/write information are available for this enumeration value. If the Rw parameter was not NULL and the
		/// function succeeds, the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_FINE_RTT_RW_v0 structure. If
		/// fine-grained RTT estimation statistics was enabled for this TCP connection, the Rod parameter was not NULL, and the function
		/// succeeds, the buffer pointed to by the Rod parameter should contain a TCP_ESTATS_FINE_RTT_ROD_v0 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Rw">
		/// A pointer to a buffer to receive the read/write information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read/write information for the TCP connection.
		/// </param>
		/// <param name="RwVersion">The version of the read/write information requested. The current supported value is a version of zero.</param>
		/// <param name="RwSize">The size, in bytes, of the buffer pointed to by Rw parameter.</param>
		/// <param name="Ros">
		/// A pointer to a buffer to receive read-only static information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read-only static information for the TCP connection.
		/// </param>
		/// <param name="RosVersion">
		/// The version of the read-only static information requested. The current supported value is a version of zero.
		/// </param>
		/// <param name="RosSize">The size, in bytes, of the buffer pointed to by the Ros parameter.</param>
		/// <param name="Rod">
		/// A pointer to a buffer to receive read-only dynamic information. This parameter may be a <c>NULL</c> pointer if an application
		/// does not want to retrieve read-only dynamic information for the TCP connection.
		/// </param>
		/// <param name="RodVersion">
		/// The version of the read-only dynamic information requested. The current supported value is a version of zero.
		/// </param>
		/// <param name="RodSize">The size, in bytes, of the buffer pointed to by the Rod parameter.</param>
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
		/// A buffer passed to a function is too small. This error is returned if the buffer pointed to by the Rw, Ros, or Rod parameters is
		/// not large enough to receive the data. This error also returned if one of the given buffers pointed to by the Rw, Ros, or Rod
		/// parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. This error value is returned on
		/// Windows Vista and Windows Server 2008.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if one of the given buffers pointed to
		/// by the Rw, Ros, or Rod parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. As a result,
		/// this error is returned if any of the following conditions are met: This error value is returned on Windows 7 and Windows Server
		/// 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if the RwVersion, RosVersion, or RodVersion parameter is not set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetPerTcpConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetPerTcpConnectionEStats</c> function is designed to use TCP to diagnose performance problems in both the network and the
		/// application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// The <c>GetPerTcpConnectionEStats</c> function retrieves extended statistics for the IPv4 TCP connection passed in the Row
		/// parameter. The type of extended statistics that is retrieved is specified in the EstatsType parameter. Extended statistics on
		/// this TCP connection must have previously been enabled by calls to the SetPerTcpConnectionEStats function for all TCP_ESTATS_TYPE
		/// values except when <c>TcpConnectionEstatsSynOpts</c> is passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The GetTcpTable function is used to retrieve the IPv4 TCP connection table on the local computer. This function returns a
		/// MIB_TCPTABLE structure that contain an array of MIB_TCPROW entries. The Row parameter passed to the
		/// <c>GetPerTcpConnectionEStats</c> function must be an entry for an existing IPv4 TCP connection.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion, RosVersion, and RodVersion
		/// parameters passed to <c>GetPerTcpConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv6 connection, see the GetPerTcp6ConnectionEStats and
		/// SetPerTcp6ConnectionEStats functions.
		/// </para>
		/// <para>
		/// The SetPerTcpConnectionEStats function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcpConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and later. If an application that contains this function is executed by a user logged on as a member of the Administrators
		/// group other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with
		/// a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// An application that uses the <c>GetPerTcpConnectionEStats</c> function to retrieve extended statistics for an IPv4 TCP connection
		/// must check that the previous call to the SetPerTcpConnectionEStats function to enabled extended statistics returned with success.
		/// If the <c>SetPerTcpConnectionEStats</c> function to enable extended statistics failed, subsequent calls to the
		/// <c>GetPerTcpConnectionEStats</c> will still return numbers in the returned structures. However the returned numbers are
		/// meaningless random data and don't represent extended TCP statistics. This behavior can be observed by running the example below
		/// as both an administrator and a normal user.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example retrieves the TCP extended statistics for an IPv4 and IPv6 TCP connection and prints values from the
		/// returned data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getpertcpconnectionestats ULONG
		// GetPerTcpConnectionEStats( PMIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, PUCHAR Ros,
		// ULONG RosVersion, ULONG RosSize, PUCHAR Rod, ULONG RodVersion, ULONG RodSize );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "71b9d795-6050-4a1a-9949-2c970801f52c")]
		public static extern Win32Error GetPerTcpConnectionEStats(in MIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, [Out, Optional] IntPtr Rw, uint RwVersion, uint RwSize,
			[Out, Optional] IntPtr Ros, uint RosVersion, uint RosSize, [Out, Optional] IntPtr Rod, uint RodVersion, uint RodSize);

		/// <summary>
		/// The <c>GetPerTcp6ConnectionEStats</c> function retrieves extended statistics for an IPv6 TCP connection.
		/// </summary>
		/// <param name="Row">A pointer to a MIB_TCP6ROW structure for an IPv6 TCP connection.</param>
		/// <param name="EstatsType"><para>
		/// The type of extended statistics for TCP requested. This parameter determines the data and format of information that is returned
		/// in the Rw, Rod, and Ros parameters if the call is successful.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>TcpConnectionEstatsSynOpts</term>
		///     <term>
		/// This value requests SYN exchange information for a TCP connection. Only read-only static information is available for this
		/// enumeration value. If the Ros parameter was not NULL and the function succeeds, the buffer pointed to by the Ros parameter should
		/// contain a TCP_ESTATS_SYN_OPTS_ROS_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsData</term>
		///     <term>
		/// This value requests extended data transfer information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_DATA_RW_v0 structure. If extended data transfer information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_DATA_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsSndCong</term>
		///     <term>
		/// This value requests sender congestion for a TCP connection. All three types of information (read-only static, read-only dynamic,
		/// and read/write information) are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds,
		/// the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_SND_CONG_RW_v0 structure. If the Ros parameter was not NULL
		/// and the function succeeds, the buffer pointed to by the Ros parameter should contain a TCP_ESTATS_SND_CONG_ROS_v0 structure. If
		/// sender congestion information was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the
		/// buffer pointed to by the Rod parameter should contain a TCP_ESTATS_SND_CONG_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsPath</term>
		///     <term>
		/// This value requests extended path measurement information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_PATH_RW_v0 structure. If extended path measurement information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_PATH_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsSendBuff</term>
		///     <term>
		/// This value requests extended output-queuing information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_SEND_BUFF_RW_v0 structure. If extended output-queuing information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_SEND_BUFF_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsRec</term>
		///     <term>
		/// This value requests extended local-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_REC_RW_v0 structure. If extended local-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_REC_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsObsRec</term>
		///     <term>
		/// This value requests extended remote-receiver information for a TCP connection. Only read-only dynamic information and read/write
		/// information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the buffer
		/// pointed to by the Rw parameter should contain a TCP_ESTATS_OBS_REC_RW_v0 structure. If extended remote-receiver information was
		/// enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_OBS_REC_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsBandwidth</term>
		///     <term>
		/// This value requests bandwidth estimation statistics for a TCP connection on bandwidth. Only read-only dynamic information and
		/// read/write information are available for this enumeration value. If the Rw parameter was not NULL and the function succeeds, the
		/// buffer pointed to by the Rw parameter should contain a TCP_ESTATS_BANDWIDTH_RW_v0 structure. If bandwidth estimation statistics
		/// was enabled for this TCP connection, the Rod parameter was not NULL, and the function succeeds, the buffer pointed to by the Rod
		/// parameter should contain a TCP_ESTATS_BANDWIDTH_ROD_v0 structure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>TcpConnectionEstatsFineRtt</term>
		///     <term>
		/// This value requests fine-grained round-trip time (RTT) estimation statistics for a TCP connection. Only read-only dynamic
		/// information and read/write information are available for this enumeration value. If the Rw parameter was not NULL and the
		/// function succeeds, the buffer pointed to by the Rw parameter should contain a TCP_ESTATS_FINE_RTT_RW_v0 structure. If
		/// fine-grained RTT estimation statistics was enabled for this TCP connection, the Rod parameter was not NULL, and the function
		/// succeeds, the buffer pointed to by the Rod parameter should contain a TCP_ESTATS_FINE_RTT_ROD_v0 structure.
		/// </term>
		///   </item>
		/// </list></param>
		/// <param name="Rw">A pointer to a buffer to receive the read/write information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read/write information for the TCP connection.</param>
		/// <param name="Ros">A pointer to a buffer to receive read-only static information. This parameter may be a <c>NULL</c> pointer if an application does
		/// not want to retrieve read-only static information for the TCP connection.</param>
		/// <param name="Rod">A pointer to a buffer to receive read-only dynamic information. This parameter may be a <c>NULL</c> pointer if an application
		/// does not want to retrieve read-only dynamic information for the TCP connection.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>ERROR_INSUFFICIENT_BUFFER</term>
		///     <term>
		/// A buffer passed to a function is too small. This error is returned if the buffer pointed to by the Rw, Ros, or Rod parameters is
		/// not large enough to receive the data. This error also returned if one of the given buffers pointed to by the Rw, Ros, or Rod
		/// parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. This error value is returned on
		/// Windows Vista and Windows Server 2008.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ERROR_INVALID_PARAMETER</term>
		///     <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		///   </item>
		///   <item>
		///     <term>ERROR_INVALID_USER_BUFFER</term>
		///     <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if one of the given buffers pointed to
		/// by the Rw, Ros, or Rod parameters is NULL, but a length was specified in the associated RwSize, RosSize, or RodSize. As a result,
		/// this error is returned if any of the following conditions are met: This error value is returned on Windows 7 and Windows Server
		/// 2008 R2.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_FOUND</term>
		///     <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ERROR_NOT_SUPPORTED</term>
		///     <term>
		/// The request is not supported. This error is returned if the RwVersion, RosVersion, or RodVersion parameter is not set to zero.
		/// </term>
		///   </item>
		///   <item>
		///     <term>Other</term>
		///     <term>Use FormatMessage to obtain the message string for the returned error.</term>
		///   </item>
		/// </list></returns>
		/// <remarks>
		/// <para>The <c>GetPerTcp6ConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetPerTcp6ConnectionEStats</c> function is designed to use TCP to diagnose performance problems in both the network and
		/// the application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// The <c>GetPerTcp6ConnectionEStats</c> function retrieves extended statistics for the IPv6 TCP connection passed in the Row
		/// parameter. The type of extended statistics that is retrieved is specified in the EstatsType parameter. Extended statistics on
		/// this TCP connection must have previously been enabled by calls to the SetPerTcp6ConnectionEStats function for all TCP_ESTATS_TYPE
		/// values except when <c>TcpConnectionEstatsSynOpts</c> is passed in the EstatsType parameter.
		/// </para>
		/// <para>
		/// The GetTcp6Table function is used to retrieve the IPv6 TCP connection table on the local computer. This function returns a
		/// MIB_TCP6TABLE structure that contain an array of MIB_TCP6ROW entries. The Row parameter passed to the
		/// <c>GetPerTcp6ConnectionEStats</c> function must be an entry for an existing IPv6 TCP connection.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion, RosVersion, and RodVersion
		/// parameters passed to <c>GetPerTcp6ConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv4 connection, see the GetPerTcpConnectionEStats and SetPerTcpConnectionEStats functions.
		/// </para>
		/// <para>
		/// The SetPerTcp6ConnectionEStats function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcp6ConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and later. If an application that contains this function is executed by a user logged on as a member of the Administrators
		/// group other than the built-in Administrator, this call will fail unless the application has been marked in the manifest file with
		/// a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// An application that uses the <c>GetPerTcp6ConnectionEStats</c> function to retrieve extended statistics for an IPv6 TCP
		/// connection must check that the previous call to the SetPerTcp6ConnectionEStats function to enabled extended statistics returned
		/// with success. If the <c>SetPerTcp6ConnectionEStats</c> function to enable extended statistics failed, subsequent calls to the
		/// <c>GetPerTcp6ConnectionEStats</c> will still return numbers in the returned structures. However the returned numbers are
		/// meaningless random data and don't represent extended TCP statistics. This behavior can be observed by running the example below
		/// as both an administrator and a normal user.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getpertcp6connectionestats ULONG
		// GetPerTcp6ConnectionEStats( PMIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, PUCHAR Ros,
		// ULONG RosVersion, ULONG RosSize, PUCHAR Rod, ULONG RodVersion, ULONG RodSize );
		[PInvokeData("iphlpapi.h", MSDNShortId = "291aabe7-a4e7-4cc7-9cf3-4a4bc021e15e")]
		public static Win32Error GetPerTcpConnectionEStats(in MIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, out object Rw, out object Ros, out object Rod)
		{
			var types = CorrespondingTypeAttribute.GetCorrespondingTypes(EstatsType);
			var trw = types.FirstOrDefault(t => t.Name.Contains("_RW_"));
			var tros = types.FirstOrDefault(t => t.Name.Contains("_ROS_"));
			var trod = types.FirstOrDefault(t => t.Name.Contains("_ROD_"));
			var srw = trw != null ? (uint)Marshal.SizeOf(trw) : 0;
			var sros = tros != null ? (uint)Marshal.SizeOf(tros) : 0;
			var srod = trod != null ? (uint)Marshal.SizeOf(trod) : 0;
			var mrw = new SafeCoTaskMemHandle((int)srw);
			var mros = new SafeCoTaskMemHandle((int)sros);
			var mrod = new SafeCoTaskMemHandle((int)srod);
			var ret = GetPerTcpConnectionEStats(Row, EstatsType, mrw, 0, srw, mros, 0, sros, mrod, 0, srod);
			Rw = ret.Failed || srw == 0 ? null : Marshal.PtrToStructure(mrw, trw);
			Ros = ret.Failed || sros == 0 ? null : Marshal.PtrToStructure(mros, tros);
			Rod = ret.Failed || srod == 0 ? null : Marshal.PtrToStructure(mrod, trod);
			return ret;
		}

		/// <summary>The <c>GetRTTAndHopCount</c> function determines the round-trip time (RTT) and hop count to the specified destination.</summary>
		/// <param name="DestIpAddress">
		/// IP address of the destination for which to determine the RTT and hop count, in the form of an IPAddr structure.
		/// </param>
		/// <param name="HopCount">
		/// Pointer to a <c>ULONG</c> variable. This variable receives the hop count to the destination specified by the DestIpAddress parameter.
		/// </param>
		/// <param name="MaxHops">
		/// Maximum number of hops to search for the destination. If the number of hops to the destination exceeds this number, the function
		/// terminates the search and returns <c>FALSE</c>.
		/// </param>
		/// <param name="RTT">Round-trip time, in milliseconds, to the destination specified by DestIpAddress.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. Call GetLastError to obtain the error code for the failure.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For information about the <c>IPAddr</c> data type, see Windows Data Types. To convert an IP address between dotted decimal
		/// notation and <c>IPAddr</c> format, use the inet_addr and inet_ntoa functions.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves and prints the round trip time and hop count to the destination IP address 127.0.0.1.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getrttandhopcount BOOL GetRTTAndHopCount( IPAddr
		// DestIpAddress, PULONG HopCount, ULONG MaxHops, PULONG RTT );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "4e84fe6f-40bd-4f0e-bb78-4180e13577aa")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetRTTAndHopCount(IN_ADDR DestIpAddress, out uint HopCount, uint MaxHops, out uint RTT);

		/// <summary>The <c>GetTcp6Table</c> function retrieves the TCP connection table for IPv6.</summary>
		/// <param name="TcpTable">A pointer to a buffer that receives the TCP connection table for IPv6 as a MIB_TCP6TABLE structure.</param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the TcpTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned TCP connection table, the function sets this parameter equal to
		/// the required buffer size in bytes.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is
		/// sorted in ascending order, starting with the lowest local IP address. If this parameter is <c>FALSE</c>, the table appears in the
		/// order in which they were retrieved.
		/// </para>
		/// <para>The following values are compared (as listed) when ordering the TCP endpoints:</para>
		/// <list type="number">
		/// <item>
		/// <term>Local IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Remote scope ID</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
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
		/// The buffer pointed to by the TcpTable parameter is not large enough. The required size is returned in the variable pointed to by
		/// the SizePointer parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The SizePointer parameter is NULL, or GetTcp6Table is unable to write to the memory pointed to by the SizePointer parameter.</term>
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
		/// <para>The <c>GetTcp6Table</c> function is defined on Windows Vista and later.</para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the TCP connection table for IPv6 and prints the state of each connection.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcp6table ULONG GetTcp6Table( PMIB_TCP6TABLE
		// TcpTable, PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "77150609-d06d-4492-bbd7-21eecd825bde")]
		public static extern Win32Error GetTcp6Table(IntPtr TcpTable, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The <c>GetTcp6Table</c> function retrieves the TCP connection table for IPv6.</summary>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is
		/// sorted in ascending order, starting with the lowest local IP address. If this parameter is <c>FALSE</c>, the table appears in the
		/// order in which they were retrieved.
		/// </para>
		/// <para>The following values are compared (as listed) when ordering the TCP endpoints:</para>
		/// <list type="number">
		/// <item>
		/// <term>Local IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Remote scope ID</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The TCP connection table for IPv6 as a MIB_TCP6TABLE structure.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcp6table ULONG GetTcp6Table( PMIB_TCP6TABLE
		// TcpTable, PULONG SizePointer, BOOL Order );
		[PInvokeData("iphlpapi.h", MSDNShortId = "77150609-d06d-4492-bbd7-21eecd825bde")]
		public static MIB_TCP6TABLE GetTcp6Table(bool Order = false) => GetTable((IntPtr p, ref uint l) => GetTcp6Table(p, ref l, Order), l => new MIB_TCP6TABLE(l));

		/// <summary>The <c>GetTcp6Table2</c> function retrieves the TCP connection table for IPv6.</summary>
		/// <param name="TcpTable">A pointer to a buffer that receives the TCP connection table for IPv6 as a MIB_TCP6TABLE2 structure.</param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size of the buffer pointed to by the TcpTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned TCP connection table, the function sets this parameter equal to
		/// the required buffer size.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is sorted
		/// in ascending order, starting with the lowest local IP address. If this parameter is <c>FALSE</c>, the table appears in the order
		/// in which they were retrieved.
		/// </para>
		/// <para>The following values are compared (as listed) when ordering the TCP endpoints:</para>
		/// <list type="number">
		/// <item>
		/// <term>Local IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Remote scope ID</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
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
		/// The buffer pointed to by the TcpTable parameter is not large enough. The required size is returned in the variable pointed to by
		/// the SizePointer parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The SizePointer parameter is NULL, or GetTcp6Table2 is unable to write to the memory pointed to by the SizePointer parameter.</term>
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
		/// <para>The <c>GetTcp6Table2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetTcp6Table2</c> function is an enhanced version of the GetTcp6Table function that also retrieves information on the TCP
		/// offload state of the TCP connection.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcp6table2 ULONG GetTcp6Table2( PMIB_TCP6TABLE2
		// TcpTable, PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "435b9198-b921-407c-9441-31cfe77c03f1")]
		public static extern Win32Error GetTcp6Table2(IntPtr TcpTable, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The <c>GetTcp6Table2</c> function retrieves the TCP connection table for IPv6.</summary>
		/// <param name="Order">
		/// <para>
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is sorted
		/// in ascending order, starting with the lowest local IP address. If this parameter is <c>FALSE</c>, the table appears in the order
		/// in which they were retrieved.
		/// </para>
		/// <para>The following values are compared (as listed) when ordering the TCP endpoints:</para>
		/// <list type="number">
		/// <item>
		/// <term>Local IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Remote scope ID</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The TCP connection table for IPv6 as a MIB_TCP6TABLE2 structure.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcp6table2 ULONG GetTcp6Table2( PMIB_TCP6TABLE2
		// TcpTable, PULONG SizePointer, BOOL Order );
		[PInvokeData("iphlpapi.h", MSDNShortId = "435b9198-b921-407c-9441-31cfe77c03f1")]
		public static MIB_TCP6TABLE2 GetTcp6Table2(bool Order = false) => GetTable((IntPtr p, ref uint l) => GetTcp6Table(p, ref l, Order), l => new MIB_TCP6TABLE2(l));

		/// <summary>The <c>GetTcpStatistics</c> function retrieves the TCP statistics for the local computer.</summary>
		/// <param name="Statistics">A pointer to a MIB_TCPSTATS structure that receives the TCP statistics for the local computer.</param>
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
		/// <term>The pStats parameter is NULL, or GetTcpStatistics is unable to write to the memory pointed to by the pStats parameter.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use the FormatMessage function to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetTcpStatistics</c> function returns the TCP statistics for IPv4 on the current computer. On Windows XP and later, the
		/// GetTcpStatisticsEx can be used to obtain the TCP statistics for either IPv4 or IPv6.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the TCP statistics for the local computer and prints some values from the returned data.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcpstatistics ULONG GetTcpStatistics( PMIB_TCPSTATS
		// Statistics );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "841cdeaa-6284-4b39-a218-69937eca1982")]
		public static extern Win32Error GetTcpStatistics(out MIB_TCPSTATS Statistics);

		/// <summary>
		/// The <c>GetTcpStatisticsEx</c> function retrieves the Transmission Control Protocol (TCP) statistics for the current computer. The
		/// <c>GetTcpStatisticsEx</c> function differs from the <c>GetTcpStatistics</c> function in that <c>GetTcpStatisticsEx</c> also
		/// supports the Internet Protocol version 6 (IPv6) protocol family.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_TCPSTATS structure that receives the TCP statistics for the local computer.</param>
		/// <param name="Family">
		/// <para>The protocol family for which to retrieve statistics. This parameter must be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>Internet Protocol version 4 (IPv4).</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Internet Protocol version 6 (IPv6).</term>
		/// </item>
		/// </list>
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
		/// <term>The pStats parameter is NULL or does not point to valid memory, or the dwFamily parameter is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system on which the function call was made.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcpstatisticsex ULONG GetTcpStatisticsEx(
		// PMIB_TCPSTATS Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "78cfc69d-eae8-49c1-a460-6527a61f773d")]
		public static extern Win32Error GetTcpStatisticsEx(out MIB_TCPSTATS Statistics, ADDRESS_FAMILY Family);

		/// <summary>
		/// The <c>GetTcpStatisticsEx2</c> function retrieves the Transmission Control Protocol (TCP) statistics for the current computer.
		/// The <c>GetTcpStatisticsEx2</c> function differs from the GetTcpStatisticsEx function in that it uses a new output structure that
		/// contains 64-bit counters, rather than 32-bit counters.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_TCPSTATS2 structure that receives the TCP statistics for the local computer.</param>
		/// <param name="Family">
		/// <para>The protocol family for which to retrieve statistics. This parameter must be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>Internet Protocol version 4 (IPv4).</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Internet Protocol version 6 (IPv6).</term>
		/// </item>
		/// </list>
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
		/// <term>The pStats parameter is NULL or does not point to valid memory, or the dwFamily parameter is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system on which the function call was made.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/IpHlpApi/nf-iphlpapi-gettcpstatisticsex2 ULONG GetTcpStatisticsEx2(
		// PMIB_TCPSTATS2 Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "E7D988E3-4CE9-4BD3-96C7-4C16D2D6FA9C")]
		public static extern Win32Error GetTcpStatisticsEx2(out MIB_TCPSTATS2 Statistics, ADDRESS_FAMILY Family);

		/// <summary>The <c>GetTcpTable</c> function retrieves the IPv4 TCP connection table.</summary>
		/// <param name="TcpTable">A pointer to a buffer that receives the TCP connection table as a MIB_TCPTABLE structure.</param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the pTcpTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned connection table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the data type for this parameter is changed to a <c>PULONG</c> which is
		/// equivalent to a <c>PDWORD</c>.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is
		/// sorted in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IP address</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
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
		/// The buffer pointed to by the pTcpTable parameter is not large enough. The required size is returned in the DWORD variable pointed
		/// to by the pdwSize parameter. This error is also returned if the pTcpTable parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pdwSize parameter is NULL, or GetTcpTable is unable to write to the memory pointed to by the pdwSize parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system in use on the local system.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_UNSUCCESSFUL</term>
		/// <term>
		/// If you receive this return code then calling the function again is usually enough to clear the issue and get the desired result.
		/// This return code can be a consequence of the system being under high load. For example, if the size of the TCP connection table
		/// changes by more than 2 additional items 3 consecutive times.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the return value from the <c>GetTcpTable</c> function is changed to a
		/// data type of <c>ULONG</c> which is equivalent to a <c>DWORD</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the TCP connection table for IPv4 and prints the state of each connection.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcptable ULONG GetTcpTable( PMIB_TCPTABLE TcpTable,
		// PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "e90c5aa0-3126-489b-af44-bf86cb45a6d1")]
		public static extern Win32Error GetTcpTable(IntPtr TcpTable, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The <c>GetTcpTable</c> function retrieves the IPv4 TCP connection table.</summary>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is
		/// sorted in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IP address</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The TCP connection table as a MIB_TCPTABLE structure.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcptable ULONG GetTcpTable( PMIB_TCPTABLE TcpTable,
		// PULONG SizePointer, BOOL Order );
		[PInvokeData("iphlpapi.h", MSDNShortId = "e90c5aa0-3126-489b-af44-bf86cb45a6d1")]
		public static MIB_TCPTABLE GetTcpTable(bool Order = false) => GetTable((IntPtr p, ref uint l) => GetTcpTable(p, ref l, Order), l => new MIB_TCPTABLE(l));

		/// <summary>The <c>GetTcpTable2</c> function retrieves the IPv4 TCP connection table.</summary>
		/// <param name="TcpTable">A pointer to a buffer that receives the TCP connection table as a MIB_TCPTABLE2 structure.</param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size of the buffer pointed to by the TcpTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned connection table, the function sets this parameter equal to the
		/// required buffer size.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is sorted
		/// in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IP address</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
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
		/// The buffer pointed to by the TcpTable parameter is not large enough. The required size is returned in the PULONG variable pointed
		/// to by the SizePointer parameter. This error is also returned if the pTcpTable parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The SizePointer parameter is NULL, or GetTcpTable2 is unable to write to the memory pointed to by the SizePointer parameter.</term>
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
		/// <para>The <c>GetTcpTable2</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>GetTcpTable2</c> function is an enhanced version of the GetTcpTable function that also retrieves information on the TCP
		/// offload state of the TCP connection.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example retrieves the TCP connection table for IPv4 and prints the state of each connection.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcptable2 ULONG GetTcpTable2( PMIB_TCPTABLE2
		// TcpTable, PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "942e8cb6-545f-45ab-919a-246e3b2d4c6a")]
		public static extern Win32Error GetTcpTable2(IntPtr TcpTable, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The <c>GetTcpTable2</c> function retrieves the IPv4 TCP connection table.</summary>
		/// <param name="Order">
		/// <para>
		/// A value that specifies whether the TCP connection table should be sorted. If this parameter is <c>TRUE</c>, the table is sorted
		/// in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// <item>
		/// <term>Remote IP address</term>
		/// </item>
		/// <item>
		/// <term>Remote port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The TCP connection table as a MIB_TCPTABLE2 structure.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-gettcptable2 ULONG GetTcpTable2( PMIB_TCPTABLE2
		// TcpTable, PULONG SizePointer, BOOL Order );
		[PInvokeData("iphlpapi.h", MSDNShortId = "942e8cb6-545f-45ab-919a-246e3b2d4c6a")]
		public static MIB_TCPTABLE2 GetTcpTable2(bool Order = false) => GetTable((IntPtr p, ref uint l) => GetTcpTable2(p, ref l, Order), l => new MIB_TCPTABLE2(l));

		/// <summary>The <c>GetUdp6Table</c> function retrieves the IPv6 User Datagram Protocol (UDP) listener table.</summary>
		/// <param name="Udp6Table">A pointer to a buffer that receives the IPv6 UDP listener table as a MIB_UDP6TABLE structure.</param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the Udp6Table parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned listener table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the returned UDP listener table should be sorted. If this parameter is <c>TRUE</c>, the
		/// table is sorted in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// </list>
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
		/// The buffer pointed to by the Udp6Table parameter is not large enough. The required size is returned in the ULONG variable pointed
		/// to by the SizePointer parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The SizePointer parameter is NULL, or GetUdp6Table is unable to write to the memory pointed to by the SizePointer parameter.</term>
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
		/// <remarks>The <c>GetUdp6Table</c> function is defined on Windows Vista and later.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudp6table ULONG GetUdp6Table( PMIB_UDP6TABLE
		// Udp6Table, PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5e86483c-aa39-4d6c-a9b4-9b046b3dcc74")]
		public static extern Win32Error GetUdp6Table(IntPtr Udp6Table, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The <c>GetUdp6Table</c> function retrieves the IPv6 User Datagram Protocol (UDP) listener table.</summary>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the returned UDP listener table should be sorted. If this parameter is <c>TRUE</c>, the
		/// table is sorted in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IPv6 address</term>
		/// </item>
		/// <item>
		/// <term>Local scope ID</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The IPv6 UDP listener table as a MIB_UDP6TABLE structure.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudp6table ULONG GetUdp6Table( PMIB_UDP6TABLE
		// Udp6Table, PULONG SizePointer, BOOL Order );
		[PInvokeData("iphlpapi.h", MSDNShortId = "5e86483c-aa39-4d6c-a9b4-9b046b3dcc74")]
		public static MIB_UDP6TABLE GetUdp6Table(bool Order = false) => GetTable((IntPtr p, ref uint l) => GetUdp6Table(p, ref l, Order), l => new MIB_UDP6TABLE(l));

		/// <summary>The <c>GetUdpStatistics</c> function retrieves the User Datagram Protocol (UDP) statistics for the local computer.</summary>
		/// <param name="Stats">Pointer to a MIB_UDPSTATS structure that receives the UDP statistics for the local computer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NO_ERROR.</para>
		/// <para>If the function fails, use FormatMessage to obtain the message string for the returned error.</para>
		/// </returns>
		/// <remarks>
		/// <c>Windows Server 2003 and Windows XP:</c> Use the GetUdpStatisticsEx function to obtain the UDP statistics for the IPv6 protocol.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudpstatistics ULONG GetUdpStatistics( PMIB_UDPSTATS
		// Stats );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "a86e5758-a984-4483-8e9c-c482a7676a20")]
		public static extern Win32Error GetUdpStatistics(out MIB_UDPSTATS Stats);

		/// <summary>
		/// The <c>GetUdpStatisticsEx</c> function retrieves the User Datagram Protocol (UDP) statistics for the current computer. The
		/// <c>GetUdpStatisticsEx</c> function differs from the <c>GetUdpStatistics</c> function in that <c>GetUdpStatisticsEx</c> also
		/// supports the Internet Protocol version 6 (IPv6) protocol family.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_UDPSTATS structure that receives the UDP statistics for the local computer.</param>
		/// <param name="Family">
		/// <para>The protocol family for which to retrieve statistics. This parameter must be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>Internet Protocol version 4 (IPv4).</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Internet Protocol version 6 (IPv6).</term>
		/// </item>
		/// </list>
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
		/// <term>The pStats parameter is NULL or does not point to valid memory, or the dwFamily parameter is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system on which the function call was made.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudpstatisticsex ULONG GetUdpStatisticsEx(
		// PMIB_UDPSTATS Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "9de7fa95-6bda-4fcc-b563-aed2e61fc1c7")]
		public static extern Win32Error GetUdpStatisticsEx(out MIB_UDPSTATS Statistics, ADDRESS_FAMILY Family);

		/// <summary>
		/// The <c>GetUdpStatisticsEx2</c> function retrieves the User Datagram Protocol (UDP) statistics for the current computer. The
		/// <c>GetUdpStatisticsEx2</c> function differs from the GetUdpStatisticsEx function in that <c>GetUdpStatisticsEx2</c> uses a new
		/// output structure that contains 64-bit counters, rather than 32-bit counters.
		/// </summary>
		/// <param name="Statistics">A pointer to a MIB_UDPSTATS2 structure that receives the UDP statistics for the local computer.</param>
		/// <param name="Family">
		/// <para>The protocol family for which to retrieve statistics. This parameter must be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET</term>
		/// <term>Internet Protocol version 4 (IPv4).</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6</term>
		/// <term>Internet Protocol version 6 (IPv6).</term>
		/// </item>
		/// </list>
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
		/// <term>The Statistics parameter is NULL or does not point to valid memory, or the Family parameter is not a valid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>This function is not supported on the operating system on which the function call was made.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudpstatisticsex2 ULONG GetUdpStatisticsEx2(
		// PMIB_UDPSTATS2 Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "8DE392C5-90EF-490D-B53A-58D75A854138")]
		public static extern Win32Error GetUdpStatisticsEx2(out MIB_UDPSTATS2 Statistics, ADDRESS_FAMILY Family);

		/// <summary>The <c>GetUdpTable</c> function retrieves the IPv4 User Datagram Protocol (UDP) listener table.</summary>
		/// <param name="UdpTable">A pointer to a buffer that receives the IPv4 UDP listener table as a MIB_UDPTABLE structure.</param>
		/// <param name="SizePointer">
		/// <para>On input, specifies the size in bytes of the buffer pointed to by the UdpTable parameter.</para>
		/// <para>
		/// On output, if the buffer is not large enough to hold the returned listener table, the function sets this parameter equal to the
		/// required buffer size in bytes.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the data type for this parameter is changed to a <c>PULONG</c> which is
		/// equivalent to a <c>PDWORD</c>.
		/// </para>
		/// </param>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the returned UDP listener table should be sorted. If this parameter is <c>TRUE</c>, the
		/// table is sorted in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// </list>
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
		/// The buffer pointed to by the pUdpTable parameter is not large enough. The required size is returned in the ULONG variable pointed
		/// to by the pdwSize parameter. This error is also returned if the pUdpTable parameter is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The pdwSize parameter is NULL, or GetUdpTable is unable to write to the memory pointed to by the pdwSize parameter.</term>
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
		/// On the Windows SDK released for Windows Vista and later, the return value from the <c>GetUdpTable</c> function is changed to a
		/// data type of <c>ULONG</c> which is equivalent to a <c>DWORD</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudptable ULONG GetUdpTable( PMIB_UDPTABLE UdpTable,
		// PULONG SizePointer, BOOL Order );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "00e80e90-1a6d-426d-90cd-20b967ebbb8e")]
		public static extern Win32Error GetUdpTable(IntPtr UdpTable, ref uint SizePointer, [MarshalAs(UnmanagedType.Bool)] bool Order);

		/// <summary>The <c>GetUdpTable</c> function retrieves the IPv4 User Datagram Protocol (UDP) listener table.</summary>
		/// <param name="Order">
		/// <para>
		/// A Boolean value that specifies whether the returned UDP listener table should be sorted. If this parameter is <c>TRUE</c>, the
		/// table is sorted in the order of:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Local IP address</term>
		/// </item>
		/// <item>
		/// <term>Local port</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The IPv4 UDP listener table as a MIB_UDPTABLE structure.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-getudptable ULONG GetUdpTable( PMIB_UDPTABLE UdpTable,
		// PULONG SizePointer, BOOL Order );
		[PInvokeData("iphlpapi.h", MSDNShortId = "00e80e90-1a6d-426d-90cd-20b967ebbb8e")]
		public static MIB_UDPTABLE GetUdpTable(bool Order = false) => GetTable((IntPtr p, ref uint l) => GetUdpTable(p, ref l, Order), l => new MIB_UDPTABLE(l));

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
		[PInvokeData("iphlpapi.h", MSDNShortId = "32aa3a8e-ae74-4da9-bc8d-b28e270d9702")]
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
		/// The <c>LookupPersistentTcpPortReservation</c> function looks up the token for a persistent TCP port reservation for a consecutive
		/// block of TCP ports on the local computer.
		/// </summary>
		/// <param name="StartPort">The starting TCP port number in network byte order.</param>
		/// <param name="NumberOfPorts">The number of TCP port numbers that were reserved.</param>
		/// <param name="Token">A pointer to a port reservation token that is returned if the function succeeds.</param>
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
		/// An invalid parameter was passed to the function. This error is returned if zero is passed in the StartPort or NumberOfPorts parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The element was not found. This error is returned if persistent port block specified by the StartPort and NumberOfPorts
		/// parameters could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>LookupPersistentTcpPortReservation</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>LookupPersistentTcpPortReservation</c> function is used to lookup the token for a persistent reservation for a block of
		/// TCP ports.
		/// </para>
		/// <para>
		/// A persistent reservation for a block of TCP ports is created by a call to the CreatePersistentTcpPortReservation function. The
		/// StartPort or NumberOfPorts parameters passed to the <c>LookupPersistentTcpPortReservation</c> function must match the values used
		/// when the persistent reservation for a block of TCP ports was created by the <c>CreatePersistentTcpPortReservation</c> function.
		/// </para>
		/// <para>
		/// If the <c>LookupPersistentTcpPortReservation</c> function succeeds, the Token parameter returned will point to the token for the
		/// persistent port reservation for the block of TCP ports. Note that the token for a given persistent reservation for a block of TCP
		/// ports may change each time the system is restarted.
		/// </para>
		/// <para>
		/// An application can request port assignments from the TCP port reservation by opening a TCP socket, then calling the WSAIoctl
		/// function specifying the SIO_ASSOCIATE_PORT_RESERVATION IOCTL and passing the reservation token before issuing a call to the bind
		/// function on the socket.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example looks up a persistent TCP port reservation and then creates a socket and allocates a port from the port reservation.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-lookuppersistenttcpportreservation IPHLPAPI_DLL_LINKAGE
		// ULONG LookupPersistentTcpPortReservation( USHORT StartPort, USHORT NumberOfPorts, PULONG64 Token );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5EBEB774-13A2-49C2-92ED-5271081615AA")]
		public static extern Win32Error LookupPersistentTcpPortReservation(ushort StartPort, ushort NumberOfPorts, out ulong Token);

		/// <summary>
		/// The <c>LookupPersistentUdpPortReservation</c> function looks up the token for a persistent UDP port reservation for a consecutive
		/// block of TCP ports on the local computer.
		/// </summary>
		/// <param name="StartPort">The starting UDP port number in network byte order.</param>
		/// <param name="NumberOfPorts">The number of UDP port numbers that were reserved.</param>
		/// <param name="Token">A pointer to a port reservation token that is returned if the function succeeds.</param>
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
		/// An invalid parameter was passed to the function. This error is returned if zero is passed in the StartPort or NumberOfPorts parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The element was not found. This error is returned if persistent port block specified by the StartPort and NumberOfPorts
		/// parameters could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>LookupPersistentUdpPortReservation</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>LookupPersistentUdpPortReservation</c> function is used to lookup the token for a persistent reservation for a block of
		/// UDP ports.
		/// </para>
		/// <para>
		/// A persistent reservation for a block of UDP ports is created by a call to the CreatePersistentUdpPortReservation function. The
		/// StartPort or NumberOfPorts parameters passed to the <c>LookupPersistentUdpPortReservation</c> function must match the values used
		/// when the persistent reservation for a block of TCP ports was created by the <c>CreatePersistentUdpPortReservation</c> function.
		/// </para>
		/// <para>
		/// If the <c>LookupPersistentUdpPortReservation</c> function succeeds, the Token parameter returned will point to the token for the
		/// persistent port reservation for the block of UDP ports. Note that the token for a given persistent reservation for a block of TCP
		/// ports may change each time the system is restarted.
		/// </para>
		/// <para>
		/// An application can request port assignments from the UDP port reservation by opening a UDP socket, then calling the WSAIoctl
		/// function specifying the SIO_ASSOCIATE_PORT_RESERVATION IOCTL and passing the reservation token before issuing a call to the bind
		/// function on the socket.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-lookuppersistentudpportreservation IPHLPAPI_DLL_LINKAGE
		// ULONG LookupPersistentUdpPortReservation( USHORT StartPort, USHORT NumberOfPorts, PULONG64 Token );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "621C732E-9A42-455C-A1A8-F1997D6EF0D7")]
		public static extern Win32Error LookupPersistentUdpPortReservation(ushort StartPort, ushort NumberOfPorts, out ulong Token);

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

		/// <summary>
		/// The <c>ParseNetworkString</c> function parses the input network string and checks whether it is a legal representation of the
		/// specified IP network string type. If the string matches a type and its specification, the function can optionally return the
		/// parsed result.
		/// </summary>
		/// <param name="NetworkString">A pointer to the NULL-terminated network string to parse.</param>
		/// <param name="Types">
		/// <para>
		/// The type of IP network string to parse. This parameter consists of one of network string types as defined in the IpHlpApi.h
		/// header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NET_STRING_IPV4_ADDRESS 0x00000001</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation. A network port or prefix
		/// must not be present in the network string. An example network string is the following: 192.168.100.10
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV4_SERVICE 0x00000002</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service using Internet standard dotted-decimal notation. A network port is required
		/// as part of the network string. A prefix must not be present in the network string. An example network string is the following: 192.168.100.10:80
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV4_NETWORK 0x00000004</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 network using Internet standard dotted-decimal notation. A network prefix that uses
		/// the Classless Inter-Domain Routing (CIDR) notation is required as part of the network string. A network port must not be present
		/// in the network string. An example network string is the following: 192.168.100/24
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_ADDRESS 0x00000008</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 address using Internet standard hexadecimal encoding. An IPv6 scope ID may be
		/// present in the network string. A network port or prefix must not be present in the network string. An example network string is
		/// the following: 21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A%2
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_ADDRESS_NO_SCOPE 0x00000008</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 address using Internet standard hexadecimal encoding. An IPv6 scope ID must not be
		/// present in the network string. A network port or prefix must not be present in the network string. An example network string is
		/// the following: 21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_SERVICE 0x00000020</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 service using Internet standard hexadecimal encoding. A network port is required as
		/// part of the network string. An IPv6 scope ID may be present in the network string. A prefix must not be present in the network
		/// string. An example network string with a scope ID is the following: [21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A%2]:8080
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_SERVICE_NO_SCOPE 0x00000040</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 service using Internet standard hexadecimal encoding. A network port is required as
		/// part of the network string. An IPv6 scope ID must not be present in the network string. A prefix must not be present in the
		/// network string. An example network string is the following: 21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A:8080
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_NETWORK 0x00000080</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 network using Internet standard hexadecimal encoding. A network prefix in CIDR
		/// notation is required as part of the network string. A network port or scope ID must not be present in the network string. An
		/// example network string is the following: 21DA:D3::/48
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_NAMED_ADDRESS 0x00000100</term>
		/// <term>
		/// The NetworkString parameter points to an Internet address using a Domain Name System (DNS) name. A network port or prefix must
		/// not be present in the network string. An example network string is the following: www.microsoft.com
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_NAMED_SERVICE 0x00000200</term>
		/// <term>
		/// The NetworkString parameter points to an Internet service using a DNS name. A network port must be present in the network string.
		/// An example network string is the following: www.microsoft.com:80
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_ADDRESS 0x00000009</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation or an IPv6 address using
		/// the Internet standard hexadecimal encoding. An IPv6 scope ID may be present in the network string. A network port or prefix must
		/// not be present in the network string. This type matches either the NET_STRING_IPV4_ADDRESS or NET_STRING_IPV6_ADDRESS types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_ADDRESS_NO_SCOPE 0x00000011</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation or an IPv6 address using
		/// Internet standard hexadecimal encoding. An IPv6 scope ID must not be present in the network string. A network port or prefix must
		/// not be present in the network string. This type matches either the NET_STRING_IPV4_ADDRESS or NET_STRING_IPV6_ADDRESS_NO_SCOPE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_SERVICE 0x00000022</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service. A network port is required as part of the network string.
		/// An IPv6 scope ID may be present in the network string. A prefix must not be present in the network string. This type matches
		/// either the NET_STRING_IPV4_SERVICE or NET_STRING_IPV6_SERVICE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_SERVICE_NO_SCOPE 0x00000042</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service. A network port is required as part of the network string.
		/// An IPv6 scope ID must not be present in the network string. A prefix must not be present in the network string. This type matches
		/// either the NET_STRING_IPV4_SERVICE or NET_STRING_IPV6_SERVICE_NO_SCOPE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_NETWORK 0x00000084</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 or IPv6 network. A network prefix in CIDR notation is required as part of the
		/// network string. A network port or scope ID must not be present in the network. This type matches either the
		/// NET_STRING_IPV4_NETWORK or NET_STRING_IPV6_NETWORK types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_ADDRESS 0x00000209</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address in Internet standard dotted-decimal notation, an IPv6 address in Internet
		/// standard hexadecimal encoding, or a DNS name. An IPv6 scope ID may be present in the network string for an IPv6 address. A
		/// network port or prefix must not be present in the network string. This type matches either the NET_STRING_NAMED_ADDRESS or
		/// NET_STRING_IP_ADDRESS types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_ADDRESS_NO_SCOPE 0x00000211</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address in Internet standard dotted-decimal notation, an IPv6 address in Internet
		/// standard hexadecimal encoding, or a DNS name. An IPv6 scope ID must not be present in the network string for an IPv6 address. A
		/// network port or prefix must not be present in the network string. This type matches either the NET_STRING_NAMED_ADDRESS or
		/// NET_STRING_IP_ADDRESS_NO_SCOPE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_SERVICE 0x00000222</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service using IP address notation or a DNS name. A network port is
		/// required as part of the network string. An IPv6 scope ID may be present in the network string. A prefix must not be present in
		/// the network string. This type matches either the NET_STRING_NAMED_SERVICE or NET_STRING_IP_SERVICE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_SERVICE_NO_SCOPE 0x00000242</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service using IP address notation or a DNS name. A network port is
		/// required as part of the network string. An IPv6 scope ID must not be present in the network string. A prefix must not be present
		/// in the network string. This type matches either the NET_STRING_NAMED_SERVICE or NET_STRING_IP_SERVICE_NO_SCOPE types.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AddressInfo">
		/// On success, the function returns a pointer to a <c>NET_ADDRESS_INFO</c> structure that contains the parsed IP address information
		/// if a <c>NULL</c> pointer was not passed in this parameter.
		/// </param>
		/// <param name="PortNumber">
		/// On success, the function returns a pointer to the parsed network port in host order if a <c>NULL</c> pointer was not passed in
		/// this parameter. If a network port was not present in the NetworkString parameter, then a pointer to a value of zero is returned.
		/// </param>
		/// <param name="PrefixLength">
		/// On success, the function returns a pointer to the parsed prefix length if a <c>NULL</c> pointer was not passed in this parameter.
		/// If a prefix was not present in the NetworkString parameter, then a pointer to a value of -1 is returned.
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
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer passed to the function is too small. This error is returned if the buffer pointed to by the AddressInfo parameter is
		/// too small to hold the parsed network address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the NetworkString parameter
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ParseNetworkString</c> function parses the input network string passed in the NetworkString parameter and checks whether
		/// it is a legal representation of one of the string types as specified in the Types argument. If the string matches a type and its
		/// specification, the function succeeds and can optionally return the parsed result to the caller in the optional AddressInfo,
		/// PortNumber, and PrefixLength parameters when these parameters are not <c>NULL</c> pointers.
		/// </para>
		/// <para>
		/// The <c>ParseNetworkString</c> function can parse representations of IPv4 or IPv6 addresses, services, and networks, as well as
		/// named Internet addresses and services using DNS names.
		/// </para>
		/// <para>
		/// The SOCKADDR_IN, SOCKADDR_IN6, and SOCKADDR structures are used in the NET_ADDRESS_INFO structure pointed to by the AddressInfo
		/// parameter. The SOCKADDR_IN and SOCKADDR structures are defined in the Ws2def.h header file which is automatically included by the
		/// Winsock2.h header file. The SOCKADDR_IN6 structure is defined in the Ws2ipdef.h header file which is automatically included by
		/// the Ws2tcpip.h header file. In order to use the <c>ParseNetworkString</c> function and the <c>NET_ADDRESS_INFO</c> structure, the
		/// Winsock2.h and Ws2tcpip.h header files must be included before the IpHlpApi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-parsenetworkstring IPHLPAPI_DLL_LINKAGE DWORD
		// ParseNetworkString( const WCHAR *NetworkString, DWORD Types, PNET_ADDRESS_INFO AddressInfo, USHORT *PortNumber, BYTE *PrefixLength );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "43bc866f-7776-4f59-9ed6-4c6fc4da7f83")]
		public static extern Win32Error ParseNetworkString([MarshalAs(UnmanagedType.LPWStr)] string NetworkString, NET_STRING Types, out NET_ADDRESS_INFO AddressInfo, out ushort PortNumber, out byte PrefixLength);

		/// <summary>
		/// The <c>ParseNetworkString</c> function parses the input network string and checks whether it is a legal representation of the
		/// specified IP network string type. If the string matches a type and its specification, the function can optionally return the
		/// parsed result.
		/// </summary>
		/// <param name="NetworkString">A pointer to the NULL-terminated network string to parse.</param>
		/// <param name="Types">
		/// <para>
		/// The type of IP network string to parse. This parameter consists of one of network string types as defined in the IpHlpApi.h
		/// header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NET_STRING_IPV4_ADDRESS 0x00000001</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation. A network port or prefix
		/// must not be present in the network string. An example network string is the following: 192.168.100.10
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV4_SERVICE 0x00000002</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service using Internet standard dotted-decimal notation. A network port is required
		/// as part of the network string. A prefix must not be present in the network string. An example network string is the following: 192.168.100.10:80
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV4_NETWORK 0x00000004</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 network using Internet standard dotted-decimal notation. A network prefix that uses
		/// the Classless Inter-Domain Routing (CIDR) notation is required as part of the network string. A network port must not be present
		/// in the network string. An example network string is the following: 192.168.100/24
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_ADDRESS 0x00000008</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 address using Internet standard hexadecimal encoding. An IPv6 scope ID may be
		/// present in the network string. A network port or prefix must not be present in the network string. An example network string is
		/// the following: 21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A%2
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_ADDRESS_NO_SCOPE 0x00000008</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 address using Internet standard hexadecimal encoding. An IPv6 scope ID must not be
		/// present in the network string. A network port or prefix must not be present in the network string. An example network string is
		/// the following: 21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_SERVICE 0x00000020</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 service using Internet standard hexadecimal encoding. A network port is required as
		/// part of the network string. An IPv6 scope ID may be present in the network string. A prefix must not be present in the network
		/// string. An example network string with a scope ID is the following: [21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A%2]:8080
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_SERVICE_NO_SCOPE 0x00000040</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 service using Internet standard hexadecimal encoding. A network port is required as
		/// part of the network string. An IPv6 scope ID must not be present in the network string. A prefix must not be present in the
		/// network string. An example network string is the following: 21DA:00D3:0000:2F3B:02AA:00FF:FE28:9C5A:8080
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IPV6_NETWORK 0x00000080</term>
		/// <term>
		/// The NetworkString parameter points to an IPv6 network using Internet standard hexadecimal encoding. A network prefix in CIDR
		/// notation is required as part of the network string. A network port or scope ID must not be present in the network string. An
		/// example network string is the following: 21DA:D3::/48
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_NAMED_ADDRESS 0x00000100</term>
		/// <term>
		/// The NetworkString parameter points to an Internet address using a Domain Name System (DNS) name. A network port or prefix must
		/// not be present in the network string. An example network string is the following: www.microsoft.com
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_NAMED_SERVICE 0x00000200</term>
		/// <term>
		/// The NetworkString parameter points to an Internet service using a DNS name. A network port must be present in the network string.
		/// An example network string is the following: www.microsoft.com:80
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_ADDRESS 0x00000009</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation or an IPv6 address using
		/// the Internet standard hexadecimal encoding. An IPv6 scope ID may be present in the network string. A network port or prefix must
		/// not be present in the network string. This type matches either the NET_STRING_IPV4_ADDRESS or NET_STRING_IPV6_ADDRESS types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_ADDRESS_NO_SCOPE 0x00000011</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address using Internet standard dotted-decimal notation or an IPv6 address using
		/// Internet standard hexadecimal encoding. An IPv6 scope ID must not be present in the network string. A network port or prefix must
		/// not be present in the network string. This type matches either the NET_STRING_IPV4_ADDRESS or NET_STRING_IPV6_ADDRESS_NO_SCOPE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_SERVICE 0x00000022</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service. A network port is required as part of the network string.
		/// An IPv6 scope ID may be present in the network string. A prefix must not be present in the network string. This type matches
		/// either the NET_STRING_IPV4_SERVICE or NET_STRING_IPV6_SERVICE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_SERVICE_NO_SCOPE 0x00000042</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service. A network port is required as part of the network string.
		/// An IPv6 scope ID must not be present in the network string. A prefix must not be present in the network string. This type matches
		/// either the NET_STRING_IPV4_SERVICE or NET_STRING_IPV6_SERVICE_NO_SCOPE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_IP_NETWORK 0x00000084</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 or IPv6 network. A network prefix in CIDR notation is required as part of the
		/// network string. A network port or scope ID must not be present in the network. This type matches either the
		/// NET_STRING_IPV4_NETWORK or NET_STRING_IPV6_NETWORK types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_ADDRESS 0x00000209</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address in Internet standard dotted-decimal notation, an IPv6 address in Internet
		/// standard hexadecimal encoding, or a DNS name. An IPv6 scope ID may be present in the network string for an IPv6 address. A
		/// network port or prefix must not be present in the network string. This type matches either the NET_STRING_NAMED_ADDRESS or
		/// NET_STRING_IP_ADDRESS types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_ADDRESS_NO_SCOPE 0x00000211</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 address in Internet standard dotted-decimal notation, an IPv6 address in Internet
		/// standard hexadecimal encoding, or a DNS name. An IPv6 scope ID must not be present in the network string for an IPv6 address. A
		/// network port or prefix must not be present in the network string. This type matches either the NET_STRING_NAMED_ADDRESS or
		/// NET_STRING_IP_ADDRESS_NO_SCOPE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_SERVICE 0x00000222</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service using IP address notation or a DNS name. A network port is
		/// required as part of the network string. An IPv6 scope ID may be present in the network string. A prefix must not be present in
		/// the network string. This type matches either the NET_STRING_NAMED_SERVICE or NET_STRING_IP_SERVICE types.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NET_STRING_ANY_SERVICE_NO_SCOPE 0x00000242</term>
		/// <term>
		/// The NetworkString parameter points to an IPv4 service or IPv6 service using IP address notation or a DNS name. A network port is
		/// required as part of the network string. An IPv6 scope ID must not be present in the network string. A prefix must not be present
		/// in the network string. This type matches either the NET_STRING_NAMED_SERVICE or NET_STRING_IP_SERVICE_NO_SCOPE types.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AddressInfo">
		/// On success, the function returns a pointer to a <c>NET_ADDRESS_INFO</c> structure that contains the parsed IP address information
		/// if a <c>NULL</c> pointer was not passed in this parameter.
		/// </param>
		/// <param name="PortNumber">
		/// On success, the function returns a pointer to the parsed network port in host order if a <c>NULL</c> pointer was not passed in
		/// this parameter. If a network port was not present in the NetworkString parameter, then a pointer to a value of zero is returned.
		/// </param>
		/// <param name="PrefixLength">
		/// On success, the function returns a pointer to the parsed prefix length if a <c>NULL</c> pointer was not passed in this parameter.
		/// If a prefix was not present in the NetworkString parameter, then a pointer to a value of -1 is returned.
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
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer passed to the function is too small. This error is returned if the buffer pointed to by the AddressInfo parameter is
		/// too small to hold the parsed network address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the NetworkString parameter
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ParseNetworkString</c> function parses the input network string passed in the NetworkString parameter and checks whether
		/// it is a legal representation of one of the string types as specified in the Types argument. If the string matches a type and its
		/// specification, the function succeeds and can optionally return the parsed result to the caller in the optional AddressInfo,
		/// PortNumber, and PrefixLength parameters when these parameters are not <c>NULL</c> pointers.
		/// </para>
		/// <para>
		/// The <c>ParseNetworkString</c> function can parse representations of IPv4 or IPv6 addresses, services, and networks, as well as
		/// named Internet addresses and services using DNS names.
		/// </para>
		/// <para>
		/// The SOCKADDR_IN, SOCKADDR_IN6, and SOCKADDR structures are used in the NET_ADDRESS_INFO structure pointed to by the AddressInfo
		/// parameter. The SOCKADDR_IN and SOCKADDR structures are defined in the Ws2def.h header file which is automatically included by the
		/// Winsock2.h header file. The SOCKADDR_IN6 structure is defined in the Ws2ipdef.h header file which is automatically included by
		/// the Ws2tcpip.h header file. In order to use the <c>ParseNetworkString</c> function and the <c>NET_ADDRESS_INFO</c> structure, the
		/// Winsock2.h and Ws2tcpip.h header files must be included before the IpHlpApi.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-parsenetworkstring IPHLPAPI_DLL_LINKAGE DWORD
		// ParseNetworkString( const WCHAR *NetworkString, DWORD Types, PNET_ADDRESS_INFO AddressInfo, USHORT *PortNumber, BYTE *PrefixLength );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "43bc866f-7776-4f59-9ed6-4c6fc4da7f83")]
		public static extern Win32Error ParseNetworkString([MarshalAs(UnmanagedType.LPWStr)] string NetworkString, NET_STRING Types, [Optional] IntPtr AddressInfo, [Optional] IntPtr PortNumber, [Optional] IntPtr PrefixLength);

		/// <summary>Converts a 6 byte Physical Address (MAC) to string.</summary>
		/// <param name="physAddr">The physical address that must have a minimum of 6 values.</param>
		/// <returns>Dashed hex value string representation of a Physical Address (MAC).</returns>
		public static string PhysicalAddressToString(byte[] physAddr) => $"{physAddr[0]:X}-{physAddr[1]:X}-{physAddr[2]:X}-{physAddr[3]:X}-{physAddr[4]:X}-{physAddr[5]:X}";

		/// <inheritdoc cref="PhysicalAddressToString(byte[])"/>
		public static unsafe string PhysicalAddressToString(byte* physAddr) => $"{physAddr[0]:X}-{physAddr[1]:X}-{physAddr[2]:X}-{physAddr[3]:X}-{physAddr[4]:X}-{physAddr[5]:X}";

		/// <summary>
		/// The <c>RestoreMediaSense</c> function restores the media sensing capability of the TCP/IP stack on a local computer on which the
		/// DisableMediaSense function was previously called.
		/// </summary>
		/// <param name="pOverlapped">
		/// A pointer to an OVERLAPPED structure. Except for the <c>hEvent</c> member, all members of this structure must be set to zero. The
		/// <c>hEvent</c> member should contain a handle to a valid event object. Use the CreateEvent function to create this event object.
		/// </param>
		/// <param name="lpdwEnableCount">
		/// An optional pointer to a DWORD variable that receives the number of references remaining if the <c>RestoreMediaSense</c> function
		/// succeeds. The variable is also used by the EnableRouter and UnenableRouter functions.
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
		/// An invalid parameter was passed to the function. This error is returned if an pOverlapped parameter is a bad pointer. This error
		/// is also returned if the DisableMediaSense function was not called prior to calling the RestoreMediaSense function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>The operation is in progress. This value may be returned by a successful asynchronous call to RestoreMediaSense.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_OPEN_FAILED</term>
		/// <term>An internal handle to the driver was invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If the pOverlapped parameter is <c>NULL</c>, the <c>RestoreMediaSense</c> function is executed synchronously.</para>
		/// <para>
		/// If the pOverlapped parameter is not <c>NULL</c>, the <c>RestoreMediaSense</c> function is executed asynchronously using the
		/// OVERLAPPED structure pointed to by the pOverlapped parameter.
		/// </para>
		/// <para>
		/// The DisableMediaSense function does not complete until the <c>RestoreMediaSense</c> function is called later to restore the media
		/// sensing capability. Until then, an I/O request packet (IRP) remains queued up. Alternatively, when the process that called
		/// <c>DisableMediaSense</c> exits, the IRP is canceled and a cancel routine is called that would again restore the media sensing capability.
		/// </para>
		/// <para>
		/// To call <c>RestoreMediaSense</c> synchronously, an application needs to pass a <c>NULL</c> pointer in the pOverlapped parameter.
		/// When <c>RestoreMediaSense</c> is called synchronously, the function returns when the I/O request packet (IRP) to restore the
		/// media sense has completed.
		/// </para>
		/// <para>
		/// To call <c>RestoreMediaSense</c> asynchronously, an application needs to allocate an OVERLAPPED structure. Except for the
		/// <c>hEvent</c> member, all members of this structure must be set to zero. The <c>hEvent</c> member requires a handle to a valid
		/// event object. Use the CreateEvent function to create this event. When called asynchronously, <c>RestoreMediaSense</c> can return
		/// return ERROR_IO_PENDING. The IRP completes when the media sensing capability has been restored. Use the CloseHandle function to
		/// close the handle to the event object when it is no longer needed. The system closes the handle automatically when the process
		/// terminates. The event object is destroyed when its last handle has been closed.
		/// </para>
		/// <para>If DisableMediaSense was not called prior to calling <c>RestoreMediaSense</c>, then <c>RestoreMediaSense</c> returns ERROR_INVALID_PARAMETER.</para>
		/// <para>
		/// On Windows Server 2003and Windows XP, the TCP/IP stack implements a policy of deleting all IP addresses on an interface in
		/// response to a media sense disconnect event from an underlying network interface. If a network switch or hub that the local
		/// computer is connected to is powered off, or a network cable is disconnected, the network interface will deliver disconnection
		/// events. IP configuration information associated with the network interface is lost. As a result, the TCP/IP stack implements a
		/// policy of hiding disconnected interfaces so these interfaces and their associated IP addresses do not show up in configuration
		/// information retrieved through IP helper. This policy prevents some applications from easily detecting that a network interface is
		/// merely disconnected, rather than removed from the system.
		/// </para>
		/// <para>
		/// This behavior does not normally impact a local client computer if it is using DHCP requests to a DHCP server for IP configuration
		/// information. But this can have a serious impact on server computers, particularly computers used as part of clusters. The
		/// DisableMediaSense function can be used to temporarily disable the media sense capability for these cases. At some later time, the
		/// <c>RestoreMediaSense</c> function would be called to restore the media sensing capability.
		/// </para>
		/// <para>The following registry setting is related to the DisableMediaSense and <c>RestoreMediaSense</c> functions:</para>
		/// <para><c>System</c>&lt;b&gt;CurrentControlSet&lt;b&gt;Services&lt;b&gt;Tcpip&lt;b&gt;Parameters&lt;b&gt;DisableDHCPMediaSense</para>
		/// <para>
		/// There is an internal flag in Windows that is set if this registry key exists when the machine first boots up. The same internal
		/// flag also gets set and reset by calling DisableMediaSense and <c>RestoreMediaSense</c>. However with registry setting, you need
		/// to reboot the machine for the changes to take place.
		/// </para>
		/// <para>
		/// The TCP/IP stack on Windows Vista and later was changed to not hide disconnected interfaces when a disconnect event occurs. So on
		/// Windows Vista and later, the DisableMediaSense and <c>RestoreMediaSense</c> functions don't do anything and always returns NO_ERROR.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how to call the DisableMediaSense and <c>RestoreMediaSense</c> functions synchronously. This sample
		/// is only useful on Windows Server 2003and Windows XP where the <c>DisableMediaSense</c> and <c>RestoreMediaSense</c> functions do
		/// something useful.
		/// </para>
		/// <para>
		/// The sample first creates a separate thread that calls the DisableMediaSense function synchronously, the main thread sleeps for 60
		/// seconds to allow the user to disconnect a network cable, retrieves the IP address table and prints some members of the IP address
		/// entries in the table, calls the <c>RestoreMediaSense</c> function synchronously, retrieves the IP address table again, and prints
		/// some members of the IP address entries in the table. The impact of disabling the media sensing capability can be seen in the
		/// difference in the IP address table entries.
		/// </para>
		/// <para>
		/// For an example that shows how to call the DisableMediaSense and <c>RestoreMediaSense</c> functions asynchronously, see the
		/// <c>DisableMediaSense</c> function reference.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-restoremediasense IPHLPAPI_DLL_LINKAGE DWORD
		// RestoreMediaSense( OVERLAPPED *pOverlapped, LPDWORD lpdwEnableCount );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "1a959da7-5fdb-4749-a4be-5d44e80ca2ea")]
		public static extern unsafe Win32Error RestoreMediaSense([In] System.Threading.NativeOverlapped* pOverlapped, out uint lpdwEnableCount);

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
		public static byte[] SendARP(IN_ADDR DestIP, IN_ADDR SrcIP = default)
		{
			uint len = 6;
			var ret = new byte[(int)len];
			SendARP(DestIP, SrcIP, ret, ref len).ThrowIfFailed();
			return ret;
		}

		/// <summary>The <c>SetIfEntry</c> function sets the administrative status of an interface.</summary>
		/// <param name="pIfRow">
		/// <para>
		/// A pointer to a MIB_IFROW structure. The <c>dwIndex</c> member of this structure specifies the interface on which to set
		/// administrative status. The <c>dwAdminStatus</c> member specifies the new administrative status. The <c>dwAdminStatus</c> member
		/// can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MIB_IF_ADMIN_STATUS_UP</term>
		/// <term>The interface is administratively enabled.</term>
		/// </item>
		/// <item>
		/// <term>MIB_IF_ADMIN_STATUS_DOWN</term>
		/// <term>The interface is administratively disabled.</term>
		/// </item>
		/// </list>
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
		/// Access is denied. This error is returned on Windows Vista and later under several conditions that include the following: the user
		/// lacks the required administrative privileges on the local computer or the application is not running in an enhanced shell as the
		/// built-in Administrator (RunAs administrator).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned on Windows Vista and later if the network interface specified
		/// by the dwIndex member of the MIB_IFROW structure pointed to by the pIfRow parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pIfRow parameter, or
		/// the dwIndex member of the MIB_IFROW pointed to by the pIfRow parameter was unspecified. This error is also returned on Windows
		/// Server 2003 and earlier if the network interface specified by the dwIndex member of the MIB_IFROW structure pointed to by the
		/// pIfRow parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned on Windows Server 2003 and earlier if no TCP/IP stack is configured on the
		/// local computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetIfEntry</c> function is used to set the administrative status of an interface on a local computer.</para>
		/// <para>
		/// The <c>dwIndex</c> member in the MIB_IFROW structure pointed to by the pIfRow parameter must be initialized to the interface index.
		/// </para>
		/// <para>
		/// The <c>SetIfEntry</c> function will fail if the <c>dwIndex</c> member of the MIB_IFROW pointed to by the pIfRow parameter does
		/// not match an existing interface on the local computer.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>SetIfEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>SetIfEntry</c> is called by a user that is not a member of the Administrators group, the function
		/// call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIfEntry</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an application
		/// that contains this function is executed by a user logged on as a member of the Administrators group other than the built-in
		/// Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setifentry IPHLPAPI_DLL_LINKAGE DWORD SetIfEntry(
		// PMIB_IFROW pIfRow );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "67a18ef2-a7af-4fc1-8416-053aa8388f9e")]
		public static extern Win32Error SetIfEntry(in MIB_IFROW pIfRow);

		/// <summary>The <c>SetIpForwardEntry</c> function modifies an existing route in the local computer's IPv4 routing table.</summary>
		/// <param name="pRoute">
		/// A pointer to a MIB_IPFORWARDROW structure that specifies the new information for the existing route. The caller must specify
		/// <c>MIB_IPPROTO_NETMGMT</c> for the <c>dwForwardProto</c> member of this structure. The caller must also specify values for the
		/// <c>dwForwardIfIndex</c>, <c>dwForwardDest</c>, <c>dwForwardMask</c>, <c>dwForwardNextHop</c>, and <c>dwForwardPolicy</c> members
		/// of the structure.
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
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>
		/// The system cannot find the file specified. This error is returned on Windows Vista and later if the network interface specified
		/// by the dwForwardIfIndex member of the MIB_IPFORWARDROW structure pointed to by the pRoute parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// The pRoute parameter is NULL, or SetIpForwardEntry is unable to read from the memory pointed to by pRoute, or one of the members
		/// of the MIB_IPFORWARDROW structure is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// The element is not found. The error is returned on Windows Vista and later when the DeleteIpForwardEntry function and then the
		/// SetIpForwardEntry function are called for the same IPv4 route table entry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This value is returned if the IPv4 transport is not configured on the local computer. This error is
		/// also returned on Windows Server 2003 and earlier if no TCP/IP stack is configured on the local computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>dwForwardProto</c> member of MIB_IPFORWARDROW structure pointed to by the route parameter must be set to
		/// <c>MIB_IPPROTO_NETMGMT</c> otherwise <c>SetIpForwardEntry</c> will fail. Routing protocol identifiers are used to identify route
		/// information for the specified routing protocol. For example, <c>MIB_IPPROTO_NETMGMT</c> is used to identify route information for
		/// IP routing set through network management such as the Dynamic Host Configuration Protocol (DHCP), the Simple Network Management
		/// Protocol (SNMP), or by calls to the CreateIpForwardEntry, DeleteIpForwardEntry, or <c>SetIpForwardEntry</c> functions.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the route metric specified in the <c>dwForwardMetric1</c> member of the
		/// MIB_IPFORWARDROW structure pointed to by pRoute parameter represents a combination of the route metric added to the interface
		/// metric specified in the <c>Metric</c> member of the MIB_IPINTERFACE_ROW structure of the associated interface. So the
		/// <c>dwForwardMetric1</c> member of the <c>MIB_IPFORWARDROW</c> structure should be equal to or greater than <c>Metric</c> member
		/// of the associated <c>MIB_IPINTERFACE_ROW</c> structure. If an application would like to set the route metric to 0, then the
		/// <c>dwForwardMetric1</c> member of the <c>MIB_IPFORWARDROW</c> structure should be set equal to the value of the interface metric
		/// specified in the <c>Metric</c> member of the associated <c>MIB_IPINTERFACE_ROW</c> structure. An application can retrieve the
		/// interface metric by calling the GetIpInterfaceEntry function.
		/// </para>
		/// <para>
		/// On Windows Vista and Windows Server 2008, the <c>SetIpForwardEntry</c> function only works on interfaces with a single
		/// sub-interface (where the interface LUID and subinterface LUID are the same). The <c>dwForwardIfIndex</c> member of the
		/// MIB_IPFORWARDROW structure specifies the interface.
		/// </para>
		/// <para>
		/// The <c>dwForwardAge</c> member the MIB_IPFORWARDROW structure pointed to by the route parameter is not currently used by
		/// <c>SetIpForwardEntry</c>. The <c>dwForwardAge</c> member is used only if the Routing and Remote Access Service (RRAS)is running,
		/// and then only for routes of type <c>MIB_IPPROTO_NETMGMT</c> as defined on the Protocol Identifiers reference page. When
		/// <c>dwForwardAge</c> is set to <c>INFINITE</c>, the route will not be removed based on a timeout
		/// </para>
		/// <para>
		/// value. Any other value for <c>dwForwardAge</c> specifies the number of seconds until the TCP/IP stack will remove the route from
		/// the network routing table.
		/// </para>
		/// <para>A route modified by <c>SetIpForwardEntry</c> will automatically have a default value for <c>dwForwardAge</c> of INFINITE.</para>
		/// <para>
		/// A number of members of the MIB_IPFORWARDROW structure pointed to by the route parameter are not currently used by
		/// <c>SetIpForwardEntry</c>. These members include <c>dwForwardPolicy</c>, <c>dwForwardType</c>, <c>dwForwardAge</c>,
		/// <c>dwForwardNextHopAS</c>, <c>dwForwardMetric1</c>, <c>dwForwardMetric2</c>, <c>dwForwardMetric3</c>, <c>dwForwardMetric4</c>,
		/// and <c>dwForwardMetric5</c>.
		/// </para>
		/// <para>
		/// To create a new route in the IP routing table, use the CreateIpForwardEntry function. To retrieve the IP routing table, call the
		/// GetIpForwardTable function.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the <c>SetIpForwardEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>SetIpForwardEntry</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// This function can also fail because of user account control (UAC) on Windows Vista and later. If an application that contains
		/// this function is executed by a user logged on as a member of the Administrators group other than the built-in Administrator, this
		/// call will fail unless the application has been marked in the manifest file with a <c>requestedExecutionLevel</c> set to
		/// requireAdministrator. If the application lacks this manifest file, a user logged on as a member of the Administrators group other
		/// than the built-in Administrator must then be executing the application in an enhanced shell as the built-in Administrator (RunAs
		/// administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates how to change the default gateway to NewGateway. Simply calling GetIpForwardTable, changing
		/// the gateway and then calling <c>SetIpForwardEntry</c> will not change the route, but rather will just add a new one. If for some
		/// reason there are multiple default gateways present, this code will delete them. Note that the new gateway must be viable;
		/// otherwise, TCP/IP will ignore the change.
		/// </para>
		/// <para><c>Note</c> Executing this code will change your IP routing tables and will likely cause network activity to fail.</para>
		/// <para>
		/// <c>Windows Vista and later:</c> When the DeleteIpForwardEntry function and then <c>SetIpForwardEntry</c> function are called for
		/// the same route table entry on Windows Vista and later, ERROR_NOT_FOUND is returned. The proper way to replicate this example on
		/// Windows Vista and later is to use the CreateIpForwardEntry function to create the new route table entry and then delete the old
		/// route table entry by calling the <c>DeleteIpForwardEntry</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setipforwardentry IPHLPAPI_DLL_LINKAGE DWORD
		// SetIpForwardEntry( PMIB_IPFORWARDROW pRoute );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "a98de796-8fa2-4835-8d15-07d86d89c348")]
		public static extern Win32Error SetIpForwardEntry(in MIB_IPFORWARDROW pRoute);

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
		public static extern Win32Error SetIpNetEntry(in MIB_IPNETROW pArpEntry);

		/// <summary>
		/// The <c>SetIpStatistics</c> function toggles IP forwarding on or off and sets the default time-to-live (TTL) value for the local computer.
		/// </summary>
		/// <param name="pIpStats">
		/// A pointer to a MIB_IPSTATS structure. The caller should set the <c>dwForwarding</c> and <c>dwDefaultTTL</c> members of this
		/// structure to the new values. To keep one of the members at its current value, use MIB_USE_CURRENT_TTL or MIB_USE_CURRENT_FORWARDING.
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
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pIpStats parameter.
		/// This error is also returned if the dwForwarding member in the MIB_IPSTATS structure pointed to by the pIpStats parameter contains
		/// a value other than MIB_IP_NOT_FORWARDING, MIB_IP_FORWARDING, or MIB_USE_CURRENT_FORWARDING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>To set only the default TTL, the caller can also use the SetIpTTL function.</para>
		/// <para>
		/// On Windows Vista and later, the <c>SetIpStatistics</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>SetIpStatistics</c> is called by a user that is not a member of the Administrators group, the
		/// function call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIpStatistics</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setipstatistics IPHLPAPI_DLL_LINKAGE DWORD
		// SetIpStatistics( PMIB_IPSTATS pIpStats );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "d857ee04-38b8-4d98-a3e7-6ca8657ac9ed")]
		public static extern Win32Error SetIpStatistics(in MIB_IPSTATS pIpStats);

		/// <summary>
		/// The <c>SetIpStatisticsEx</c> function toggles IP forwarding on or off and sets the default time-to-live (TTL) value for the local computer.
		/// </summary>
		/// <param name="Statistics">
		/// A pointer to a MIB_IPSTATS structure. The caller should set the <c>dwForwarding</c> and <c>dwDefaultTTL</c> members of this
		/// structure to the new values. To keep one of the members at its current value, use MIB_USE_CURRENT_TTL or MIB_USE_CURRENT_FORWARDING.
		/// </param>
		/// <param name="Family">
		/// <para>The address family for which forwarding and TTL is to be set.</para>
		/// <para>
		/// Possible values for the address family are listed in the Winsock2.h header file. Note that the values for the AF_ address family
		/// and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and possible values for
		/// this member are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h,
		/// and should never be used directly.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c>, and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function sets forwarding and TTL
		/// options for IPv4 entries.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function sets forwarding and TTL
		/// options for IPv6 entries.
		/// </term>
		/// </item>
		/// </list>
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
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pIpStats parameter or
		/// the Family parameter was not set to AF_INET, and AF_INET6. This error is also returned if the dwForwarding member in the
		/// MIB_IPSTATS structure pointed to by the pIpStats parameter contains a value other than MIB_IP_NOT_FORWARDING, MIB_IP_FORWARDING,
		/// or MIB_USE_CURRENT_FORWARDING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>
		/// The request is not supported. This error is returned if no IPv4 stack is on the local computer and AF_INET was specified in the
		/// Family parameter or no IPv6 stack is on the local computer and AF_INET6 was specified in the Family member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>To set only the default TTL, the caller can also use the SetIpTTL function.</para>
		/// <para>
		/// The <c>SetIpStatisticsEx</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetIpStatisticsEx</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetIpStatisticsEx</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an
		/// application that contains this function is executed by a user logged on as a member of the Administrators group other than the
		/// built-in Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setipstatisticsex IPHLPAPI_DLL_LINKAGE ULONG
		// SetIpStatisticsEx( PMIB_IPSTATS Statistics, ULONG Family );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "13b52016-5bdb-4546-af53-d3ae2708653b")]
		public static extern Win32Error SetIpStatisticsEx(in MIB_IPSTATS Statistics, ADDRESS_FAMILY Family);

		/// <summary>The <c>SetIpTTL</c> function sets the default time-to-live (TTL) value for the local computer.</summary>
		/// <param name="nTTL">The new TTL value for the local computer.</param>
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
		/// <term>An invalid parameter was passed to the function. This error is returned if the nTTL parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The default TTL can also be set using the SetIpStatistics function.</para>
		/// <para>
		/// On Windows Vista and later, the <c>SetIpTTL</c> function can only be called by a user logged on as a member of the Administrators
		/// group. If <c>SetIpTTL</c> is called by a user that is not a member of the Administrators group, the function call will fail and
		/// <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The SetIpStatistics function can also fail because of user account control (UAC) on Windows Vista and later. If an application
		/// that contains this function is executed by a user logged on as a member of the Administrators group other than the built-in
		/// Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// <para>
		/// <c>Note</c> On Windows NT 4.0 and Windows 2000 and later, this function executes a privileged operation. For this function to
		/// execute successfully, the caller must be logged on as a member of the Administrators group or the NetworkConfigurationOperators group.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setipttl IPHLPAPI_DLL_LINKAGE DWORD SetIpTTL( UINT nTTL );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "dfde8712-f68f-4fa4-b939-ea36e23b5b1e")]
		public static extern Win32Error SetIpTTL(uint nTTL);

		/// <summary>
		/// The <c>SetPerTcp6ConnectionEStats</c> function sets a value in the read/write information for an IPv6 TCP connection. This
		/// function is used to enable or disable extended statistics for an IPv6 TCP connection.
		/// </summary>
		/// <param name="Row">A pointer to a MIB_TCP6ROW structure for an IPv6 TCP connection.</param>
		/// <param name="EstatsType">
		/// <para>
		/// The type of extended statistics for TCP to set. This parameter determines the data and format of information that is expected in
		/// the Rw parameter.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>
		/// This value specifies extended data transfer information for a TCP connection. When this value is specified, the buffer pointed to
		/// by the Rw parameter should point to a TCP_ESTATS_DATA_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>
		/// This value specifies sender congestion for a TCP connection. When this value is specified, the buffer pointed to by the Rw
		/// parameter should point to a TCP_ESTATS_SND_CONG_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>
		/// This value specifies extended path measurement information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_PATH_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>
		/// This value specifies extended output-queuing information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_SEND_BUFF_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>
		/// This value specifies extended local-receiver information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_REC_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>
		/// This value specifies extended remote-receiver information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_OBS_REC_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>
		/// This value specifies bandwidth estimation statistics for a TCP connection on bandwidth. When this value is specified, the buffer
		/// pointed to by the Rw parameter should point to a TCP_ESTATS_BANDWIDTH_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>
		/// This value specifies fine-grained round-trip time (RTT) estimation statistics for a TCP connection. When this value is specified,
		/// the buffer pointed to by the Rw parameter should point to a TCP_ESTATS_FINE_RTT_RW_v0 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Rw">
		/// A pointer to a buffer that contains the read/write information to set. The buffer should contain a value from the
		/// TCP_BOOLEAN_OPTIONAL enumeration for each structure member that specifies how each member should be updated.
		/// </param>
		/// <param name="RwVersion">
		/// The version of the read/write information to be set. This parameter should be set to zero for Windows Vista, Windows Server 2008,
		/// and Windows 7.
		/// </param>
		/// <param name="RwSize">The size, in bytes, of the buffer pointed to by the Rw parameter.</param>
		/// <param name="Offset">
		/// The offset, in bytes, to the member in the structure pointed to by the Rw parameter to be set. This parameter is currently unused
		/// and must be set to zero.
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
		/// <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if the Row parameter is a NULL pointer
		/// and the RwSize parameter is nonzero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if the RwVersion or the Offset parameter is not set to 0.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetPerTcp6ConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SetPerTcp6ConnectionEStats</c> function is used to enable or disable extended statistics for the IPv6 TCP connection
		/// passed in the Row parameter. Extended statistics on a TCP connection are disabled by default.
		/// </para>
		/// <para>
		/// The <c>SetPerTcp6ConnectionEStats</c> function is used to set the value of a member in the read/write information for extended
		/// statistics for an IPv6 TCP connection. The type and format of the structure to be set is specified by the EstatsType parameter.
		/// The Rw parameter contains a pointer to the structure being passed. The member to set in this structure is specified by the Offset
		/// parameter. All members in the structure pointed to by Rw parameter must be specified.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion parameter passed to
		/// <c>SetPerTcp6ConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// The structure pointed to by the Rw parameter passed this function depends on the enumeration value passed in the EstatsType
		/// parameter. The following table below indicates the structure type that should be passed in the Rw parameter for each possible
		/// EstatsType parameter type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>EstatsType</term>
		/// <term>Structure pointed to by Rw</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>TCP_ESTATS_DATA_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>TCP_ESTATS_SND_CONG_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>TCP_ESTATS_PATH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>TCP_ESTATS_SEND_BUFF_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>TCP_ESTATS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>TCP_ESTATS_OBS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>TCP_ESTATS_BANDWIDTH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>TCP_ESTATS_FINE_RTT_RW_v0</term>
		/// </item>
		/// </list>
		/// <para>
		/// The Offset parameter is currently unused. The possible structures pointed to by the Rw parameter all have a single member except
		/// for the TCP_ESTATS_BANDWIDTH_RW_v0 structure. When the EstatsType parameter is set to <c>TcpConnectionEstatsBandwidth</c>, the
		/// <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure pointed to by the Rw parameter must have both structure members set to the preferred
		/// values in a single call to the <c>SetPerTcp6ConnectionEStats</c> function.
		/// </para>
		/// <para>
		/// If the RwSize parameter is set to 0, the <c>SetPerTcp6ConnectionEStats</c> function returns NO_ERROR and makes no changes tothe
		/// extended statistics status.
		/// </para>
		/// <para>
		/// The GetTcp6Table function is used to retrieve the IPv6 TCP connection table on the local computer. This function returns a
		/// MIB_TCP6TABLE structure that contain an array of MIB_TCP6ROW entries. The Row parameter passed to the
		/// <c>SetPerTcp6ConnectionEStats</c> function must be an entry for an existing IPv6 TCP connection.
		/// </para>
		/// <para>
		/// Once extended statistics are enabled on a TCP connection for IPv6, an application calls the GetPerTcp6ConnectionEStats function
		/// to retrieve extended statistics on the TCP connection.
		/// </para>
		/// <para>
		/// The GetPerTcp6ConnectionEStats function is designed to use TCP to diagnose performance problems in both the network and the
		/// application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv4 connection, see the GetPerTcpConnectionEStats and SetPerTcpConnectionEStats functions.
		/// </para>
		/// <para>
		/// The <c>SetPerTcp6ConnectionEStats</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcp6ConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and Windows Server 2008. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or Windows
		/// Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in
		/// Administrator must then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for
		/// this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setpertcp6connectionestats ULONG
		// SetPerTcp6ConnectionEStats( PMIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, ULONG Offset );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "89ace750-ec32-46cb-8526-233f847ba9f4")]
		public static extern Win32Error SetPerTcp6ConnectionEStats(in MIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, [In] byte[] Rw, uint RwVersion, uint RwSize, uint Offset);

		/// <summary>
		/// The <c>SetPerTcp6ConnectionEStats</c> function sets a value in the read/write information for an IPv6 TCP connection. This
		/// function is used to enable or disable extended statistics for an IPv6 TCP connection.
		/// </summary>
		/// <param name="Row">A pointer to a MIB_TCP6ROW structure for an IPv6 TCP connection.</param>
		/// <param name="EstatsType">
		/// <para>
		/// The type of extended statistics for TCP to set. This parameter determines the data and format of information that is expected in
		/// the Rw parameter.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>
		/// This value specifies extended data transfer information for a TCP connection. When this value is specified, the buffer pointed to
		/// by the Rw parameter should point to a TCP_ESTATS_DATA_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>
		/// This value specifies sender congestion for a TCP connection. When this value is specified, the buffer pointed to by the Rw
		/// parameter should point to a TCP_ESTATS_SND_CONG_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>
		/// This value specifies extended path measurement information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_PATH_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>
		/// This value specifies extended output-queuing information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_SEND_BUFF_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>
		/// This value specifies extended local-receiver information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_REC_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>
		/// This value specifies extended remote-receiver information for a TCP connection. When this value is specified, the buffer pointed
		/// to by the Rw parameter should point to a TCP_ESTATS_OBS_REC_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>
		/// This value specifies bandwidth estimation statistics for a TCP connection on bandwidth. When this value is specified, the buffer
		/// pointed to by the Rw parameter should point to a TCP_ESTATS_BANDWIDTH_RW_v0 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>
		/// This value specifies fine-grained round-trip time (RTT) estimation statistics for a TCP connection. When this value is specified,
		/// the buffer pointed to by the Rw parameter should point to a TCP_ESTATS_FINE_RTT_RW_v0 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Rw">
		/// A pointer to a buffer that contains the read/write information to set. The buffer should contain a value from the
		/// TCP_BOOLEAN_OPTIONAL enumeration for each structure member that specifies how each member should be updated.
		/// </param>
		/// <param name="RwVersion">
		/// The version of the read/write information to be set. This parameter should be set to zero for Windows Vista, Windows Server 2008,
		/// and Windows 7.
		/// </param>
		/// <param name="RwSize">The size, in bytes, of the buffer pointed to by the Rw parameter.</param>
		/// <param name="Offset">
		/// The offset, in bytes, to the member in the structure pointed to by the Rw parameter to be set. This parameter is currently unused
		/// and must be set to zero.
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
		/// <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if the Row parameter is a NULL pointer
		/// and the RwSize parameter is nonzero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if the RwVersion or the Offset parameter is not set to 0.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetPerTcp6ConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SetPerTcp6ConnectionEStats</c> function is used to enable or disable extended statistics for the IPv6 TCP connection
		/// passed in the Row parameter. Extended statistics on a TCP connection are disabled by default.
		/// </para>
		/// <para>
		/// The <c>SetPerTcp6ConnectionEStats</c> function is used to set the value of a member in the read/write information for extended
		/// statistics for an IPv6 TCP connection. The type and format of the structure to be set is specified by the EstatsType parameter.
		/// The Rw parameter contains a pointer to the structure being passed. The member to set in this structure is specified by the Offset
		/// parameter. All members in the structure pointed to by Rw parameter must be specified.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion parameter passed to
		/// <c>SetPerTcp6ConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// The structure pointed to by the Rw parameter passed this function depends on the enumeration value passed in the EstatsType
		/// parameter. The following table below indicates the structure type that should be passed in the Rw parameter for each possible
		/// EstatsType parameter type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>EstatsType</term>
		/// <term>Structure pointed to by Rw</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>TCP_ESTATS_DATA_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>TCP_ESTATS_SND_CONG_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>TCP_ESTATS_PATH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>TCP_ESTATS_SEND_BUFF_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>TCP_ESTATS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>TCP_ESTATS_OBS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>TCP_ESTATS_BANDWIDTH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>TCP_ESTATS_FINE_RTT_RW_v0</term>
		/// </item>
		/// </list>
		/// <para>
		/// The Offset parameter is currently unused. The possible structures pointed to by the Rw parameter all have a single member except
		/// for the TCP_ESTATS_BANDWIDTH_RW_v0 structure. When the EstatsType parameter is set to <c>TcpConnectionEstatsBandwidth</c>, the
		/// <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure pointed to by the Rw parameter must have both structure members set to the preferred
		/// values in a single call to the <c>SetPerTcp6ConnectionEStats</c> function.
		/// </para>
		/// <para>
		/// If the RwSize parameter is set to 0, the <c>SetPerTcp6ConnectionEStats</c> function returns NO_ERROR and makes no changes tothe
		/// extended statistics status.
		/// </para>
		/// <para>
		/// The GetTcp6Table function is used to retrieve the IPv6 TCP connection table on the local computer. This function returns a
		/// MIB_TCP6TABLE structure that contain an array of MIB_TCP6ROW entries. The Row parameter passed to the
		/// <c>SetPerTcp6ConnectionEStats</c> function must be an entry for an existing IPv6 TCP connection.
		/// </para>
		/// <para>
		/// Once extended statistics are enabled on a TCP connection for IPv6, an application calls the GetPerTcp6ConnectionEStats function
		/// to retrieve extended statistics on the TCP connection.
		/// </para>
		/// <para>
		/// The GetPerTcp6ConnectionEStats function is designed to use TCP to diagnose performance problems in both the network and the
		/// application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv4 connection, see the GetPerTcpConnectionEStats and SetPerTcpConnectionEStats functions.
		/// </para>
		/// <para>
		/// The <c>SetPerTcp6ConnectionEStats</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcp6ConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and Windows Server 2008. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or Windows
		/// Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in
		/// Administrator must then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for
		/// this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setpertcp6connectionestats ULONG
		// SetPerTcp6ConnectionEStats( PMIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, ULONG Offset );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "89ace750-ec32-46cb-8526-233f847ba9f4")]
		public static extern Win32Error SetPerTcp6ConnectionEStats(in MIB_TCP6ROW Row, TCP_ESTATS_TYPE EstatsType, [In] IntPtr Rw, uint RwVersion, uint RwSize, uint Offset);

		/// <summary>
		/// The <c>SetPerTcpConnectionEStats</c> function sets a value in the read/write information for an IPv4 TCP connection. This
		/// function is used to enable or disable extended statistics for an IPv4 TCP connection.
		/// </summary>
		/// <param name="Row">A pointer to a MIB_TCPROW structure for an IPv4 TCP connection.</param>
		/// <param name="EstatsType">
		/// <para>
		/// The type of extended statistics for TCP to set. This parameter determines the data and format of information that is expected in
		/// the Rw parameter.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// </param>
		/// <param name="Rw">
		/// A pointer to a buffer that contains the read/write information to set. The buffer should contain a value from the
		/// TCP_BOOLEAN_OPTIONAL enumeration for each structure member that specifies how each member should be updated.
		/// </param>
		/// <param name="RwVersion">
		/// The version of the read/write information to be set. This parameter should be set to zero for Windows Vista, Windows Server 2008,
		/// and Windows 7.
		/// </param>
		/// <param name="RwSize">The size, in bytes, of the buffer pointed to by the Rw parameter.</param>
		/// <param name="Offset">
		/// The offset, in bytes, to the member in the structure pointed to by the Rw parameter to be set. This parameter is currently unused
		/// and must be set to zero.
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
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if the Row parameter is a NULL pointer
		/// and the RwSize parameter is nonzero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if the RwVersion or the Offset parameter is not set to 0.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetPerTcpConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SetPerTcpConnectionEStats</c> function is used to enable or disable extended statistics on an IPv4 TCP connection passed
		/// in the Row parameter. Extended statistics on a TCP connection are disabled by default. The <c>SetPerTcpConnectionEStats</c>
		/// function is used to set the value of a member in the read/write information for extended statistics for an IPv4 TCP connection.
		/// The type and format of the structure to be set is specified by the EstatsType parameter. The Rw parameter contains a pointer to
		/// the structure being passed. All members in the structure pointed to by Rw parameter must be specified.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion parameter passed to
		/// <c>SetPerTcpConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// The structure pointed to by the Rw parameter passed this function depends on the enumeration value passed in the EstatsType
		/// parameter. The following table below indicates the structure type that should be passed in the Rw parameter for each possible
		/// EstatsType parameter type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>EstatsType</term>
		/// <term>Structure pointed to by Rw</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>TCP_ESTATS_DATA_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>TCP_ESTATS_SND_CONG_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>TCP_ESTATS_PATH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>TCP_ESTATS_SEND_BUFF_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>TCP_ESTATS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>TCP_ESTATS_OBS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>TCP_ESTATS_BANDWIDTH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>TCP_ESTATS_FINE_RTT_RW_v0</term>
		/// </item>
		/// </list>
		/// <para>
		/// The Offset parameter is currently unused and must be set to 0. The possible structures pointed to by the Rw parameter all have a
		/// single member except for the TCP_ESTATS_BANDWIDTH_RW_v0 structure. When the EstatsType parameter is set to
		/// <c>TcpConnectionEstatsBandwidth</c>, the <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure pointed to by the Rw parameter must have
		/// both structure members set to the preferred values in a single call to the <c>SetPerTcpConnectionEStats</c> function.
		/// </para>
		/// <para>
		/// If the RwSize parameter is set to 0, the <c>SetPerTcpConnectionEStats</c> function returns NO_ERROR and makes no changes tothe
		/// extended statistics status.
		/// </para>
		/// <para>
		/// The GetTcpTable function is used to retrieve the IPv4 TCP connection table on the local computer. This function returns a
		/// MIB_TCPTABLE structure that contain an array of MIB_TCPROW entries. The Row parameter passed to the
		/// <c>SetPerTcpConnectionEStats</c> function must be an entry for an existing IPv4 TCP connection.
		/// </para>
		/// <para>
		/// Once extended statistics are enabled on a TCP connection for IPv4, applications call the GetPerTcpConnectionEStats function to
		/// retrieve extended statistics on the TCP connection.
		/// </para>
		/// <para>
		/// The GetPerTcpConnectionEStats function is designed to use TCP to diagnose performance problems in both the network and the
		/// application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv6 connection, see the GetPerTcp6ConnectionEStats and
		/// SetPerTcp6ConnectionEStats functions.
		/// </para>
		/// <para>
		/// The <c>SetPerTcpConnectionEStats</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcpConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and Windows Server 2008. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or Windows
		/// Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in
		/// Administrator must then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for
		/// this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setpertcpconnectionestats IPHLPAPI_DLL_LINKAGE ULONG
		// SetPerTcpConnectionEStats( PMIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, ULONG Offset );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "96d838ca-69e3-4a73-b969-3e6e810a0a69")]
		public static extern Win32Error SetPerTcpConnectionEStats(in MIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, [In] byte[] Rw, uint RwVersion, uint RwSize, uint Offset);

		/// <summary>
		/// The <c>SetPerTcpConnectionEStats</c> function sets a value in the read/write information for an IPv4 TCP connection. This
		/// function is used to enable or disable extended statistics for an IPv4 TCP connection.
		/// </summary>
		/// <param name="Row">A pointer to a MIB_TCPROW structure for an IPv4 TCP connection.</param>
		/// <param name="EstatsType">
		/// <para>
		/// The type of extended statistics for TCP to set. This parameter determines the data and format of information that is expected in
		/// the Rw parameter.
		/// </para>
		/// <para>This parameter can be one of the values from the TCP_ESTATS_TYPE enumeration type defined in the Tcpestats.h header file.</para>
		/// </param>
		/// <param name="Rw">
		/// A pointer to a buffer that contains the read/write information to set. The buffer should contain a value from the
		/// TCP_BOOLEAN_OPTIONAL enumeration for each structure member that specifies how each member should be updated.
		/// </param>
		/// <param name="RwVersion">
		/// The version of the read/write information to be set. This parameter should be set to zero for Windows Vista, Windows Server 2008,
		/// and Windows 7.
		/// </param>
		/// <param name="RwSize">The size, in bytes, of the buffer pointed to by the Rw parameter.</param>
		/// <param name="Offset">
		/// The offset, in bytes, to the member in the structure pointed to by the Rw parameter to be set. This parameter is currently unused
		/// and must be set to zero.
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
		/// <term>ERROR_INVALID_USER_BUFFER</term>
		/// <term>
		/// The supplied user buffer is not valid for the requested operation. This error is returned if the Row parameter is a NULL pointer
		/// and the RwSize parameter is nonzero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The parameter is incorrect. This error is returned if the Row parameter is a NULL pointer.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_FOUND</term>
		/// <term>
		/// This requested entry was not found. This error is returned if the TCP connection specified in the Row parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if the RwVersion or the Offset parameter is not set to 0.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SetPerTcpConnectionEStats</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SetPerTcpConnectionEStats</c> function is used to enable or disable extended statistics on an IPv4 TCP connection passed
		/// in the Row parameter. Extended statistics on a TCP connection are disabled by default. The <c>SetPerTcpConnectionEStats</c>
		/// function is used to set the value of a member in the read/write information for extended statistics for an IPv4 TCP connection.
		/// The type and format of the structure to be set is specified by the EstatsType parameter. The Rw parameter contains a pointer to
		/// the structure being passed. All members in the structure pointed to by Rw parameter must be specified.
		/// </para>
		/// <para>
		/// The only version of TCP connection statistics currently supported is version zero. So the RwVersion parameter passed to
		/// <c>SetPerTcpConnectionEStats</c> should be set to 0.
		/// </para>
		/// <para>
		/// The structure pointed to by the Rw parameter passed this function depends on the enumeration value passed in the EstatsType
		/// parameter. The following table below indicates the structure type that should be passed in the Rw parameter for each possible
		/// EstatsType parameter type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>EstatsType</term>
		/// <term>Structure pointed to by Rw</term>
		/// </listheader>
		/// <item>
		/// <term>TcpConnectionEstatsData</term>
		/// <term>TCP_ESTATS_DATA_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSndCong</term>
		/// <term>TCP_ESTATS_SND_CONG_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsPath</term>
		/// <term>TCP_ESTATS_PATH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsSendBuff</term>
		/// <term>TCP_ESTATS_SEND_BUFF_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsRec</term>
		/// <term>TCP_ESTATS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsObsRec</term>
		/// <term>TCP_ESTATS_OBS_REC_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsBandwidth</term>
		/// <term>TCP_ESTATS_BANDWIDTH_RW_v0</term>
		/// </item>
		/// <item>
		/// <term>TcpConnectionEstatsFineRtt</term>
		/// <term>TCP_ESTATS_FINE_RTT_RW_v0</term>
		/// </item>
		/// </list>
		/// <para>
		/// The Offset parameter is currently unused and must be set to 0. The possible structures pointed to by the Rw parameter all have a
		/// single member except for the TCP_ESTATS_BANDWIDTH_RW_v0 structure. When the EstatsType parameter is set to
		/// <c>TcpConnectionEstatsBandwidth</c>, the <c>TCP_ESTATS_BANDWIDTH_RW_v0</c> structure pointed to by the Rw parameter must have
		/// both structure members set to the preferred values in a single call to the <c>SetPerTcpConnectionEStats</c> function.
		/// </para>
		/// <para>
		/// If the RwSize parameter is set to 0, the <c>SetPerTcpConnectionEStats</c> function returns NO_ERROR and makes no changes tothe
		/// extended statistics status.
		/// </para>
		/// <para>
		/// The GetTcpTable function is used to retrieve the IPv4 TCP connection table on the local computer. This function returns a
		/// MIB_TCPTABLE structure that contain an array of MIB_TCPROW entries. The Row parameter passed to the
		/// <c>SetPerTcpConnectionEStats</c> function must be an entry for an existing IPv4 TCP connection.
		/// </para>
		/// <para>
		/// Once extended statistics are enabled on a TCP connection for IPv4, applications call the GetPerTcpConnectionEStats function to
		/// retrieve extended statistics on the TCP connection.
		/// </para>
		/// <para>
		/// The GetPerTcpConnectionEStats function is designed to use TCP to diagnose performance problems in both the network and the
		/// application. If a network based application is performing poorly, TCP can determine if the bottleneck is in the sender, the
		/// receiver or the network itself. If the bottleneck is in the network, TCP can provide specific information about its nature.
		/// </para>
		/// <para>
		/// For information on extended TCP statistics on an IPv6 connection, see the GetPerTcp6ConnectionEStats and
		/// SetPerTcp6ConnectionEStats functions.
		/// </para>
		/// <para>
		/// The <c>SetPerTcpConnectionEStats</c> function can only be called by a user logged on as a member of the Administrators group. If
		/// <c>SetPerTcpConnectionEStats</c> is called by a user that is not a member of the Administrators group, the function call will
		/// fail and <c>ERROR_ACCESS_DENIED</c> is returned. This function can also fail because of user account control (UAC) on Windows
		/// Vista and Windows Server 2008. If an application that contains this function is executed by a user logged on as a member of the
		/// Administrators group other than the built-in Administrator, this call will fail unless the application has been marked in the
		/// manifest file with a <c>requestedExecutionLevel</c> set to requireAdministrator. If the application on Windows Vista or Windows
		/// Server 2008 lacks this manifest file, a user logged on as a member of the Administrators group other than the built-in
		/// Administrator must then be executing the application in an enhanced shell as the built-in Administrator (RunAs administrator) for
		/// this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-setpertcpconnectionestats IPHLPAPI_DLL_LINKAGE ULONG
		// SetPerTcpConnectionEStats( PMIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, PUCHAR Rw, ULONG RwVersion, ULONG RwSize, ULONG Offset );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "96d838ca-69e3-4a73-b969-3e6e810a0a69")]
		public static extern Win32Error SetPerTcpConnectionEStats(in MIB_TCPROW Row, TCP_ESTATS_TYPE EstatsType, [In] IntPtr Rw, uint RwVersion, uint RwSize, uint Offset);

		/// <summary>The <c>SetTcpEntry</c> function sets the state of a TCP connection.</summary>
		/// <param name="pTcpRow">
		/// A pointer to a MIB_TCPROW structure. This structure specifies information to identify the TCP connection to modify. It also
		/// specifies the new state for the TCP connection. The caller must specify values for all the members in this structure.
		/// </param>
		/// <returns>
		/// <para>The function returns <c>NO_ERROR</c> (zero) if the function is successful.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
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
		/// An input parameter is invalid, no action was taken. This error is returned if the pTcpRow parameter is NULL or the Row member in
		/// the MIB_TCPROW structure pointed to by the pTcpRow parameter is not set to MIB_TCP_STATE_DELETE_TCB.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The IPv4 transport is not configured on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>317</term>
		/// <term>The function is unable to set the TCP entry since the application is running non-elevated.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Currently, the only state to which a TCP connection can be set is MIB_TCP_STATE_DELETE_TCB.</para>
		/// <para>
		/// On Windows Vista and later, the <c>SetTcpEntry</c> function can only be called by a user logged on as a member of the
		/// Administrators group. If <c>SetTcpEntry</c> is called by a user that is not a member of the Administrators group, the function
		/// call will fail and <c>ERROR_ACCESS_DENIED</c> is returned.
		/// </para>
		/// <para>
		/// The <c>SetTcpEntry</c> function can also fail because of user account control (UAC) on Windows Vista and later. If an application
		/// that contains this function is executed by a user logged on as a member of the Administrators group other than the built-in
		/// Administrator, this call will fail unless the application has been marked in the manifest file with a
		/// <c>requestedExecutionLevel</c> set to requireAdministrator. If the application lacks this manifest file, a user logged on as a
		/// member of the Administrators group other than the built-in Administrator must then be executing the application in an enhanced
		/// shell as the built-in Administrator (RunAs administrator) for this function to succeed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iphlpapi/nf-iphlpapi-settcpentry IPHLPAPI_DLL_LINKAGE DWORD SetTcpEntry(
		// PMIB_TCPROW pTcpRow );
		[DllImport(Lib.IpHlpApi, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("iphlpapi.h", MSDNShortId = "5916f66d-3c85-406d-b6f9-6c1c84161be4")]
		public static extern Win32Error SetTcpEntry(in MIB_TCPROW pTcpRow);

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

		private static TRet GetTable<TRet>(FunctionHelper.PtrFunc<uint> func, Func<uint, TRet> make, uint memErr = Win32Error.ERROR_INSUFFICIENT_BUFFER) where TRet : SafeHandle
		{
			uint len = 0;
			var e = func(IntPtr.Zero, ref len);
			if (e != memErr)
				e.ThrowIfFailed();

			var mem = make(len);
			func(mem.DangerousGetHandle(), ref len).ThrowIfFailed();
			return mem;
		}

		/// <summary>Describes a network address.</summary>
		// typedef struct NET_ADDRESS_INFO_ { NET_ADDRESS_FORMAT Format; union { struct { WCHAR Address[DNS_MAX_NAME_BUFFER_LENGTH]; WCHAR
		// Port[6]; } NamedAddress; SOCKADDR_IN Ipv4Address; SOCKADDR_IN6 Ipv6Address; SOCKADDR IpAddress; };} NET_ADDRESS_INFO,
		// *PNET_ADDRESS_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773346(v=vs.85).aspx
		[PInvokeData("IpHlpApi.h", MSDNShortId = "bb773346")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_ADDRESS_INFO
		{
			/// <summary>
			/// <para>Type: <c>NET_ADDRESS_FORMAT</c></para>
			/// <para>One of the following values that indicates the format of the address provided in the remainder of this structure.</para>
			/// </summary>
			public NET_ADDRESS_FORMAT Format;

			/// <summary>
			/// A structure that contains a named address. A network string that represents an Internet host/router cannot specify a port.
			/// However, a network string that represents an Internet service must specify a port, for example, www.example.com:443.
			/// </summary>
			public NAMEDADDRESS NamedAddress;

			/// <summary>
			/// <para>Type: <c>SOCKADDR_IN</c></para>
			/// <para>A structure to describe a IP version 4 (IPv4) address.</para>
			/// </summary>
			public SOCKADDR_IN Ipv4Address;

			/// <summary>
			/// <para>Type: <c>SOCKADDR_IN6</c></para>
			/// <para>A structure to describe a IP version 6 (IPv6) address. For the definition of this structure, see Ws2ipdef.h.</para>
			/// </summary>
			public SOCKADDR_IN6 Ipv6Address;

			/// <summary>
			/// <para>Type: <c>SOCKADDR</c></para>
			/// <para>
			/// A structure that describes an address that is independent of the IP version in use; for instance, an address defined at the
			/// application layer using Windows Sockets 2. Once a network string is parsed successfully, an application can connect using
			/// this address.
			/// </para>
			/// </summary>
			public SOCKADDR IpAddress;

			/// <summary>
			/// A structure that contains a named address. A network string that represents an Internet host/router cannot specify a port.
			/// However, a network string that represents an Internet service must specify a port, for example, www.example.com:443.
			/// </summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct NAMEDADDRESS
			{
				/// <summary>
				/// A DNS name formatted as a NULL-terminated wide character string. The maximum length of this string is the
				/// DNS_MAX_NAME_BUFFER_LENGTH constant defined in the Windns.h header file.
				/// </summary>
				[FieldOffset(0), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
				public string Address;

				/// <summary>The network port formatted as a NULL-terminated wide character string.</summary>
				[FieldOffset(0), MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
				public string Port;
			}
		}

		/// <summary>Represents a linked list of IP_ADAPTER_ADDRESSES structures returned by <see cref="GetAdaptersAddresses(GetAdaptersAddressesFlags, ADDRESS_FAMILY)"/>.</summary>
		public class IP_ADAPTER_ADDRESSES_RESULT : SafeNativeLinkedList<IP_ADAPTER_ADDRESSES, HGlobalMemoryMethods>
		{
			internal IP_ADAPTER_ADDRESSES_RESULT(uint byteCount) : base((int)byteCount, s => s.Next)
			{
			}
		}

		/// <summary>Represents a linked list of IP_ADAPTER_INFO structures returned by <see cref="GetAdaptersInfo()"/>.</summary>
		public class IP_ADAPTER_INFO_RESULT : SafeNativeLinkedList<IP_ADAPTER_INFO, HGlobalMemoryMethods>
		{
			internal IP_ADAPTER_INFO_RESULT(uint byteCount) : base((int)byteCount, s => s.Next)
			{
			}
		}
	}
}