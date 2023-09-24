using System.Linq;
using System.Net;

#pragma warning disable IDE1006 // Naming Styles
namespace Vanara.PInvoke;

public static partial class Ws2_32
{
	public const uint IOC_UNIX                      = 0x00000000;
	public const uint IOC_WS2                       = 0x08000000;
	public const uint IOC_PROTOCOL                  = 0x10000000;
	public const uint IOC_VENDOR                    = 0x18000000;
	public const uint IOC_WSK                       = 0x0F000000;
	public static uint _WSAIO(uint x, uint y) => IOC_VOID|x|y;
	public static uint _WSAIOR(uint x, uint y) => IOC_OUT|x|y;
	public static uint _WSAIOW(uint x, uint y) => IOC_IN|x|y;
	public static uint _WSAIORW(uint x, uint y) => IOC_INOUT|x|y;
	public static readonly uint SIO_ASSOCIATE_HANDLE          = _WSAIOW(IOC_WS2,1);
	public static readonly uint SIO_ENABLE_CIRCULAR_QUEUEING  = _WSAIO(IOC_WS2,2);
	public static readonly uint SIO_FIND_ROUTE                = _WSAIOR(IOC_WS2,3);
	public static readonly uint SIO_FLUSH                     = _WSAIO(IOC_WS2,4);
	public static readonly uint SIO_GET_BROADCAST_ADDRESS     = _WSAIOR(IOC_WS2,5);
	public static readonly uint SIO_GET_EXTENSION_FUNCTION_POINTER  = _WSAIORW(IOC_WS2,6);
	public static readonly uint SIO_GET_QOS                   = _WSAIORW(IOC_WS2,7);
	public static readonly uint SIO_GET_GROUP_QOS             = _WSAIORW(IOC_WS2,8);
	public static readonly uint SIO_MULTIPOINT_LOOPBACK       = _WSAIOW(IOC_WS2,9);
	public static readonly uint SIO_MULTICAST_SCOPE           = _WSAIOW(IOC_WS2,10);
	public static readonly uint SIO_SET_QOS                   = _WSAIOW(IOC_WS2,11);
	public static readonly uint SIO_SET_GROUP_QOS             = _WSAIOW(IOC_WS2,12);
	public static readonly uint SIO_TRANSLATE_HANDLE          = _WSAIORW(IOC_WS2,13);
	public static readonly uint SIO_ROUTING_INTERFACE_QUERY   = _WSAIORW(IOC_WS2,20);
	public static readonly uint SIO_ROUTING_INTERFACE_CHANGE  = _WSAIOW(IOC_WS2,21);
	public static readonly uint SIO_ADDRESS_LIST_QUERY        = _WSAIOR(IOC_WS2,22);
	public static readonly uint SIO_ADDRESS_LIST_CHANGE       = _WSAIO(IOC_WS2,23);
	public static readonly uint SIO_QUERY_TARGET_PNP_HANDLE   = _WSAIOR(IOC_WS2,24);
	public static readonly uint SIO_QUERY_RSS_PROCESSOR_INFO  = _WSAIOR(IOC_WS2,37);
	public static readonly uint SIO_ADDRESS_LIST_SORT         = _WSAIORW(IOC_WS2,25);
	public static readonly uint SIO_RESERVED_1                = _WSAIOW(IOC_WS2,26);
	public static readonly uint SIO_RESERVED_2                = _WSAIOW(IOC_WS2,33);
	public static readonly uint SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER = _WSAIORW(IOC_WS2, 36);

	/// <summary>Flags that indicate options used in the GetAddrInfoW function.</summary>
	[PInvokeData("ws2def.h", MSDNShortId = "a4896eac-68ae-4a08-8647-36be65fe4478")]
	[Flags]
	public enum ADDRINFO_FLAGS : uint
	{
		/// <summary>The socket address will be used in a call to the bindfunction.</summary>
		AI_PASSIVE = 0x01,

		/// <summary>The canonical name is returned in the first ai_canonname member.</summary>
		AI_CANONNAME = 0x02,

		/// <summary>The nodename parameter passed to the GetAddrInfoW function must be a numeric string.</summary>
		AI_NUMERICHOST = 0x04,

		/// <summary>Servicename must be a numeric port number.</summary>
		AI_NUMERICSERV = 0x08,

		/// <summary>
		/// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED.
		/// <para>This option is supported on Windows Vista and later.</para>
		/// </summary>
		AI_ALL = 0x0100,

		/// <summary>
		/// The GetAddrInfoW will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered a
		/// valid global address. This option is only supported on Windows Vista and later.
		/// </summary>
		AI_ADDRCONFIG = 0x0400,

		/// <summary>
		/// If the GetAddrInfoW request for an IPv6 addresses fails, a name service request is made for IPv4 addresses and these
		/// addresses are converted to IPv4-mapped IPv6 address format.
		/// <para>This option is supported on Windows Vista and later.</para>
		/// </summary>
		AI_V4MAPPED = 0x0800,

		/// <summary>
		/// The address information can be from a non-authoritative namespace provider.
		/// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
		/// </summary>
		AI_NON_AUTHORITATIVE = 0x04000,

		/// <summary>
		/// The address information is from a secure channel.
		/// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
		/// </summary>
		AI_SECURE = 0x08000,

		/// <summary>
		/// The address information is for a preferred name for a user.
		/// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
		/// </summary>
		AI_RETURN_PREFERRED_NAMES = 0x010000,

		/// <summary>
		/// If a flat name (single label) is specified, GetAddrInfoW will return the fully qualified domain name that the name
		/// eventually resolved to. The fully qualified domain name is returned in the ai_canonname member.
		/// <para>
		/// This is different than AI_CANONNAME bit flag that returns the canonical name registered in DNS which may be different than
		/// the fully qualified domain name that the flat name resolved to.
		/// </para>
		/// <para>
		/// Only one of the AI_FQDN and AI_CANONNAME bits can be set. The GetAddrInfoW function will fail if both flags are present with EAI_BADFLAGS.
		/// </para>
		/// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		AI_FQDN = 0x00020000,

		/// <summary>
		/// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
		/// provider may ignore this hint.
		/// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
		/// </summary>
		AI_FILESERVER = 0x00040000,

		/// <summary>
		/// Disable the automatic International Domain Name encoding using Punycode in the name resolution functions called by the
		/// GetAddrInfoW function.
		/// <para>This option is supported on Windows 8, Windows Server 2012, and later.</para>
		/// </summary>
		AI_DISABLE_IDN_ENCODING = 0x00080000,

		/// <summary>Indicates this is extended ADDRINFOEX(2/..) struct</summary>
		AI_EXTENDED = 0x80000000,

		/// <summary>Request resolution handle</summary>
		AI_RESOLUTION_HANDLE = 0x40000000,
	}

	/// <summary>Protocols. The IPv6 defines are specified in RFC 2292.</summary>
	[PInvokeData("ws2def.h")]
	public enum IPPROTO
	{
		/// <summary/>
		IPPROTO_IP = 0,

		/// <summary/>
		IPPROTO_HOPOPTS = 0,

		/// <summary>
		/// The Internet Control Message Protocol (ICMP). This is a possible value when the af parameter is AF_UNSPEC, AF_INET, or
		/// AF_INET6 and the type parameter is SOCK_RAW or unspecified.
		/// <para>This protocol value is supported on Windows XP and later.</para>
		/// </summary>
		IPPROTO_ICMP = 1,

		/// <summary>
		/// The Internet Group Management Protocol (IGMP). This is a possible value when the af parameter is AF_UNSPEC, AF_INET, or
		/// AF_INET6 and the type parameter is SOCK_RAW or unspecified.
		/// <para>This protocol value is supported on Windows XP and later.</para>
		/// </summary>
		IPPROTO_IGMP = 2,

		/// <summary>
		/// The Bluetooth Radio Frequency Communications (Bluetooth RFCOMM) protocol. This is a possible value when the af parameter is
		/// AF_BTH and the type parameter is SOCK_STREAM.
		/// <para>This protocol value is supported on Windows XP with SP2 or later.</para>
		/// </summary>
		IPPROTO_GGP = 3,

		/// <summary/>
		IPPROTO_IPV4 = 4,

		/// <summary/>
		IPPROTO_ST = 5,

		/// <summary>
		/// The Transmission Control Protocol (TCP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type
		/// parameter is SOCK_STREAM.
		/// </summary>
		IPPROTO_TCP = 6,

		/// <summary/>
		IPPROTO_CBT = 7,

		/// <summary/>
		IPPROTO_EGP = 8,

		/// <summary/>
		IPPROTO_IGP = 9,

		/// <summary/>
		IPPROTO_PUP = 12,

		/// <summary>
		/// The User Datagram Protocol (UDP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type
		/// parameter is SOCK_DGRAM.
		/// </summary>
		IPPROTO_UDP = 17,

		/// <summary/>
		IPPROTO_IDP = 22,

		/// <summary/>
		IPPROTO_RDP = 27,

		/// <summary/>
		IPPROTO_IPV6 = 41,

		/// <summary/>
		IPPROTO_ROUTING = 43,

		/// <summary/>
		IPPROTO_FRAGMENT = 44,

		/// <summary/>
		IPPROTO_ESP = 50,

		/// <summary/>
		IPPROTO_AH = 51,

		/// <summary>
		/// The Internet Control Message Protocol Version 6 (ICMPv6). This is a possible value when the af parameter is AF_UNSPEC,
		/// AF_INET, or AF_INET6 and the type parameter is SOCK_RAW or unspecified.
		/// <para>This protocol value is supported on Windows XP and later.</para>
		/// </summary>
		IPPROTO_ICMPV6 = 58,

		/// <summary/>
		IPPROTO_NONE = 59,

		/// <summary/>
		IPPROTO_DSTOPTS = 60,

		/// <summary/>
		IPPROTO_ND = 77,

		/// <summary/>
		IPPROTO_ICLFXBM = 78,

		/// <summary/>
		IPPROTO_PIM = 103,

		/// <summary>
		/// The PGM protocol for reliable multicast. This is a possible value when the af parameter is AF_INET and the type parameter is
		/// SOCK_RDM. On the Windows SDK released for Windows Vista and later, this protocol is also called IPPROTO_PGM.
		/// <para>This protocol value is only supported if the Reliable Multicast Protocol is installed.</para>
		/// </summary>
		IPPROTO_PGM = 113,

		/// <summary/>
		IPPROTO_L2TP = 115,

		/// <summary/>
		IPPROTO_SCTP = 132,

		/// <summary/>
		IPPROTO_RAW = 255,

		/// <summary/>
		IPPROTO_MAX = 256,

		/// <summary/>
		IPPROTO_RESERVED_RAW = 257,

		/// <summary/>
		IPPROTO_RESERVED_IPSEC = 258,

		/// <summary/>
		IPPROTO_RESERVED_IPSECOFFLOAD = 259,

		/// <summary/>
		IPPROTO_RESERVED_WNV = 260,

		/// <summary/>
		IPPROTO_RESERVED_MAX = 261
	}

	/// <summary>Customize processing of the GetNameInfoW function.</summary>
	[PInvokeData("ws2def.h", MSDNShortId = "5630a49a-c182-440c-ad54-6ff3ba4274c6")]
	public enum NI
	{
		/// <summary>Results in local hosts having only their Relative Distinguished Name (RDN) returned in the pNodeBuffer parameter.</summary>
		NI_NOFQDN = 0x01  /* Only return nodename portion for local hosts */,

		/// <summary>
		/// Returns the numeric form of the host name instead of its name. The numeric form of the host name is also returned if the
		/// host name cannot be resolved by DNS.
		/// </summary>
		NI_NUMERICHOST = 0x02  /* Return numeric form of the host's address */,

		/// <summary>A host name that cannot be resolved by the DNS results in an error.</summary>
		NI_NAMEREQD = 0x04  /* Error if the host's name not in DNS */,

		/// <summary>
		/// Returns the port number of the service instead of its name. Also, if a host name is not found for an IP address (127.0.0.2,
		/// for example), the hostname is returned as the IP address.
		/// </summary>
		NI_NUMERICSERV = 0x08  /* Return numeric form of the service (port #) */,

		/// <summary>
		/// Indicates that the service is a datagram service. This flag is necessary for the few services that provide different port
		/// numbers for UDP and TCP service.
		/// </summary>
		NI_DGRAM = 0x10  /* Service is a datagram service */,
	}

	/// <summary>The scope of the IPv6 transport address.</summary>
	[PInvokeData("ws2def.h")]
	public enum SCOPE_LEVEL
	{
		/// <summary>The transport address has interface-local scope.</summary>
		ScopeLevelInterface = 1,

		/// <summary>The transport address has link-local scope.</summary>
		ScopeLevelLink = 2,

		/// <summary>The transport address has subnet-local scope.</summary>
		ScopeLevelSubnet = 3,

		/// <summary>The transport address has admin-local scope.</summary>
		ScopeLevelAdmin = 4,

		/// <summary>The transport address has site-local scope.</summary>
		ScopeLevelSite = 5,

		/// <summary>The transport address has organization-local scope.</summary>
		ScopeLevelOrganization = 8,

		/// <summary>The transport address has global scope.</summary>
		ScopeLevelGlobal = 14,

		/// <summary>The scope level count.</summary>
		ScopeLevelCount = 16
	}

	/// <summary>Gets the size, in bytes, of a <see cref="SOCKET_ADDRESS_LIST"/> given a number of address.</summary>
	/// <param name="AddressCount">The address count.</param>
	/// <returns>The size, in bytes, required to hold the structure. This does not include allocation for the addresses pointed to by each <see cref="SOCKET_ADDRESS"/>.</returns>
	[PInvokeData("ws2def.h")]
	public static SizeT SIZEOF_SOCKET_ADDRESS_LIST(SizeT AddressCount) => Marshal.OffsetOf(typeof(SOCKET_ADDRESS_LIST), "Address").ToInt32() + Marshal.SizeOf(typeof(SOCKET_ADDRESS)) * AddressCount;

	/// <summary>The maximum natural alignment</summary>
	public static readonly SizeT MAX_NATURAL_ALIGNMENT = IntPtr.Size;

	[StructLayout(LayoutKind.Sequential)]
	private struct AlignedStruct<T> where T : struct
	{
		private readonly byte b;
		public readonly T type;
	}

	/// <summary>Returns the alignment in bytes of the specified type as a value of type <see cref="SizeT"/>.</summary>
	/// <typeparam name="T">The type for which to get the alignment.</typeparam>
	/// <returns>The alignment in bytes of the specified type.</returns>
	public static SizeT TYPE_ALIGNMENT<T>() where T : struct => Marshal.OffsetOf(typeof(AlignedStruct<T>), "type").ToInt64();

	/// <summary>Returns the alignment in bytes of padding as a value of type <see cref="SizeT"/>.</summary>
	/// <param name="length">The padding length.</param>
	/// <returns>The alignment in bytes.</returns>
	public static SizeT WSA_CMSGDATA_ALIGN(SizeT length) => (length + MAX_NATURAL_ALIGNMENT-1) & (~(MAX_NATURAL_ALIGNMENT-1));

	/// <summary>Returns the alignment in bytes of WSACMSGHDR with padding as a value of type <see cref="SizeT"/>.</summary>
	/// <param name="length">The padding length.</param>
	/// <returns>The alignment in bytes.</returns>
	public static SizeT WSA_CMSGHDR_ALIGN(SizeT length) =>
		(length + TYPE_ALIGNMENT<WSACMSGHDR>()-1) & (~(TYPE_ALIGNMENT<WSACMSGHDR>()-1));

	/// <summary>
	/// Returns a pointer to the first byte of data (what is referred to as the cmsg_data member though it is not defined in the structure).
	/// </summary>
	/// <param name="cmsg">The WSACMSGHDR instance.</param>
	/// <returns>The pointer.</returns>
	public static unsafe byte* WSA_CMSG_DATA(WSACMSGHDR* cmsg) => (byte*)cmsg + WSA_CMSGDATA_ALIGN(Marshal.SizeOf(typeof(WSACMSGHDR)));

	/// <summary>
	/// Returns the first ancillary data object, or a null if there is no ancillary data in the control buffer of the WSAMSG structure.
	/// </summary>
	/// <param name="msg">The message.</param>
	/// <returns>The first ancillary data object, or a null.</returns>
	public static unsafe WSACMSGHDR* WSA_CMSG_FIRSTHDR(in WSAMSG msg) =>
		(msg.Control.len >= Marshal.SizeOf(typeof(WSACMSGHDR))) ? (WSACMSGHDR*)msg.Control.buf : default;

	/// <summary>Returns the value to store in cmsg_len given the amount of data.</summary>
	/// <param name="length">The length.</param>
	/// <returns>The data length.</returns>
	public static SizeT WSA_CMSG_LEN(SizeT length) => WSA_CMSGDATA_ALIGN(Marshal.SizeOf(typeof(WSACMSGHDR))) + length;

	/// <summary>Returns the next ancillary data object, or a null if there are no more data objects.</summary>
	/// <param name="msg">The message.</param>
	/// <param name="cmsg">The message header.</param>
	/// <returns>The next header.</returns>
	public static unsafe WSACMSGHDR* WSA_CMSG_NXTHDR(in WSAMSG msg, WSACMSGHDR* cmsg)
	{
		if (cmsg is null)
			return WSA_CMSG_FIRSTHDR(msg);
		unsafe
		{
			var len = (byte*)cmsg + WSA_CMSGHDR_ALIGN(cmsg->cmsg_len) + Marshal.SizeOf(typeof(WSACMSGHDR));
			return len > (byte*)msg.Control.buf + msg.Control.len ? null : (WSACMSGHDR*)((byte*)cmsg + WSA_CMSGHDR_ALIGN(cmsg->cmsg_len));
		}
	}

	/// <summary>Returns total size of an ancillary data object given the amount of data. Used to allocate the correct amount of space.</summary>
	/// <param name="length">The length.</param>
	/// <returns>Total size</returns>
	public static SizeT WSA_CMSG_SPACE(SizeT length) => WSA_CMSGDATA_ALIGN(Marshal.SizeOf(typeof(WSACMSGHDR)) + WSA_CMSGHDR_ALIGN(length));

	/// <summary>
	/// The addrinfoex2 structure is used by the GetAddrInfoEx function to hold host address information when both a canonical name and
	/// a fully qualified domain name have been requested.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-addrinfoex2w typedef struct addrinfoex2W { int ai_flags; int
	// ai_family; int ai_socktype; int ai_protocol; size_t ai_addrlen; PWSTR ai_canonname; struct sockaddr *ai_addr; void *ai_blob;
	// size_t ai_bloblen; LPGUID ai_provider; struct addrinfoex2W *ai_next; int ai_version; PWSTR ai_fqdn; } ADDRINFOEX2W,
	// *PADDRINFOEX2W, *LPADDRINFOEX2W;
	[PInvokeData("ws2def.h", MSDNShortId = "9CB33347-A838-473D-B5CD-1149D6632CF2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ADDRINFOEX2W
	{
		/// <summary>
		/// <para>Flags that indicate options used in the GetAddrInfoEx function.</para>
		/// <para>
		/// Supported values for the <c>ai_flags</c> member are defined in the Winsock2.h include file and can be a combination of the
		/// following options.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AI_PASSIVE 0x01</term>
		/// <term>The socket address will be used in a call to the bindfunction.</term>
		/// </item>
		/// <item>
		/// <term>AI_CANONNAME 0x02</term>
		/// <term>The canonical name is returned in the first ai_canonname member.</term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICHOST 0x04</term>
		/// <term>The nodename parameter passed to the GetAddrInfoEx function must be a numeric string.</term>
		/// </item>
		/// <item>
		/// <term>AI_ALL 0x0100</term>
		/// <term>
		/// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. This option is supported on
		/// Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ADDRCONFIG 0x0400</term>
		/// <term>
		/// The GetAddrInfoEx will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered
		/// a valid global address. This option is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_V4MAPPED 0x0800</term>
		/// <term>
		/// If the GetAddrInfoEx request for an IPv6 addresses fails, a name service request is made for IPv4 addresses and these
		/// addresses are converted to IPv4-mapped IPv6 address format. This option is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NON_AUTHORITATIVE 0x04000</term>
		/// <term>
		/// The address information is from non-authoritative results. When this option is set in the pHints parameter of GetAddrInfoEx,
		/// the NS_EMAIL namespace provider returns both authoritative and non-authoritative results. If this option is not set, then
		/// only authoritative results are returned. This option is only supported on Windows Vista and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_SECURE 0x08000</term>
		/// <term>
		/// The address information is from a secure channel. If the AI_SECURE bit is set, the NS_EMAIL namespace provider will return
		/// results that were obtained with enhanced security to minimize possible spoofing. When this option is set in the pHints
		/// parameter of GetAddrInfoEx, the NS_EMAIL namespace provider returns only results that were obtained with enhanced security
		/// to minimize possible spoofing. This option is only supported on Windows Vista and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_RETURN_PREFERRED_NAMES 0x010000</term>
		/// <term>
		/// The address information is for a preferred names for publication with a specific namespace. When this option is set in the
		/// pHints parameter of GetAddrInfoEx, no name should be provided in the pName parameter and the NS_EMAIL namespace provider
		/// will return preferred names for publication. This option is only supported on Windows Vista and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FQDN 0x00020000</term>
		/// <term>
		/// The fully qualified domain name is returned in the first ai_fqdn member. When this option is set in the pHints parameter of
		/// GetAddrInfoEx and a flat name (single label) is specified in the pName parameter, the fully qualified domain name that the
		/// name eventually resolved to will be returned. This option is supported on Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FILESERVER 0x00040000</term>
		/// <term>
		/// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
		/// provider may ignore this hint. This option is supported on Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_DISABLE_IDN_ENCODING 0x00080000</term>
		/// <term>
		/// Disable the automatic International Domain Name encoding using Punycode in the name resolution functions called by the
		/// GetAddrInfoEx function. This option is supported on Windows 8, Windows Server 2012, and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ADDRINFO_FLAGS ai_flags;

		private uint _ai_family;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The address family. Possible values for the address family are defined in the Winsock2.h include file.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and the possible
		/// values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically
		/// included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// The values currently supported are <c>AF_INET</c> or <c>AF_INET6</c>, which are the Internet address family formats for IPv4
		/// and IPv6. Other options for address family ( <c>AF_NETBIOS</c> for use with NetBIOS, for example) are supported if a Windows
		/// Sockets service provider for the address family is installed. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_UNSPEC</c> and <c>PF_UNSPEC</c>), so either constant can be used.
		/// </para>
		/// <para>The table below lists common values for the address family although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>The address family is unspecified.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_NETBIOS 17</term>
		/// <term>The NetBIOS address family. This address family is only supported if a Windows Sockets provider for NetBIOS is installed.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_IRDA 26</term>
		/// <term>
		/// The Infrared Data Association (IrDA) address family. This address family is only supported if the computer has an infrared
		/// port and driver installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_BTH 32</term>
		/// <term>
		/// The Bluetooth address family. This address family is only supported if a Bluetooth adapter is installed on Windows Server
		/// 2003 or later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ADDRESS_FAMILY ai_family { readonly get => (ADDRESS_FAMILY)_ai_family; set => _ai_family = (ushort)value; }

		/// <summary>
		/// <para>The socket type. Possible values for the socket type are defined in the Winsock2.h include file.</para>
		/// <para>The following table lists the possible values for the socket type supported for Windows Sockets 2:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SOCK_STREAM 1</term>
		/// <term>
		/// Provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission mechanism. Uses the
		/// Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6). If the ai_family member is
		/// AF_IRDA, then SOCK_STREAM is the only supported socket type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_DGRAM 2</term>
		/// <term>
		/// Supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum length. Uses the User
		/// Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RAW 3</term>
		/// <term>
		/// Provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To manipulate the IPv4
		/// header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the IPV6_HDRINCL socket
		/// option must be set on the socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RDM 4</term>
		/// <term>
		/// Provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM) multicast protocol
		/// implementation in Windows, often referred to as reliable multicast programming.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_SEQPACKET 5</term>
		/// <term>Provides a pseudo-stream packet based on datagrams.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows Sockets 2, new socket types were introduced. An application can dynamically discover the attributes of each
		/// available transport protocol through the WSAEnumProtocols function. So an application can determine the possible socket type
		/// and protocol options for an address family and use this information when specifying this parameter. Socket type definitions
		/// in the Winsock2.h and Ws2def.h header files will be periodically updated as new socket types, address families, and
		/// protocols are defined.
		/// </para>
		/// <para>In Windows Sockets 1.1, the only possible socket types are <c>SOCK_DATAGRAM</c> and <c>SOCK_STREAM</c>.</para>
		/// </summary>
		public SOCK ai_socktype;

		/// <summary>
		/// <para>
		/// The protocol type. The possible options are specific to the address family and socket type specified. Possible values for
		/// the <c>ai_protocol</c> are defined in Winsock2.h and the Wsrm.h header files.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and this member can
		/// be one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h
		/// header file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// If a value of 0 is specified for <c>ai_protocol</c>, the caller does not wish to specify a protocol and the service provider
		/// will choose the <c>ai_protocol</c> to use. For protocols other than IPv4 and IPv6, set <c>ai_protocol</c> to zero.
		/// </para>
		/// <para>The following table lists common values for the <c>ai_protocol</c> member although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IPPROTO_TCP 6</term>
		/// <term>
		/// The Transmission Control Protocol (TCP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the
		/// ai_socktype member is SOCK_STREAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_UDP 17</term>
		/// <term>
		/// The User Datagram Protocol (UDP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the type
		/// parameter is SOCK_DGRAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_RM 113</term>
		/// <term>
		/// The PGM protocol for reliable multicast. This is a possible value when the ai_family member is AF_INET and the ai_socktype
		/// member is SOCK_RDM. On the Windows SDK released for Windows Vista and later, this value is also called IPPROTO_PGM.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the <c>ai_family</c> member is <c>AF_IRDA</c>, then the <c>ai_protocol</c> must be 0.</para>
		/// </summary>
		public IPPROTO ai_protocol;

		/// <summary>The length, in bytes, of the buffer pointed to by the <c>ai_addr</c> member.</summary>
		public SizeT ai_addrlen;

		/// <summary>The canonical name for the host.</summary>
		public StrPtrUni ai_canonname;

		/// <summary>
		/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned <c>addrinfoex2</c> structure points to a
		/// filled-in socket address structure. The length, in bytes, of each returned <c>addrinfoex2</c> structure is specified in the
		/// <c>ai_addrlen</c> member.
		/// </summary>
		public IntPtr ai_addr;

		/// <summary>
		/// A pointer to data that is used to return provider-specific namespace information that is associated with the name beyond a
		/// list of addresses. The length, in bytes, of the buffer pointed to by <c>ai_blob</c> must be specified in the
		/// <c>ai_bloblen</c> member.
		/// </summary>
		public IntPtr ai_blob;

		/// <summary>The length, in bytes, of the <c>ai_blob</c> member.</summary>
		public SizeT ai_bloblen;

		/// <summary>A pointer to the GUID of a specific namespace provider.</summary>
		public GuidPtr ai_provider;

		/// <summary>
		/// A pointer to the next structure in a linked list. This parameter is set to <c>NULL</c> in the last <c>addrinfoex2</c>
		/// structure of a linked list.
		/// </summary>
		public IntPtr ai_next;

		/// <summary>The version number of this structure. The value currently used for this version of the structure is 2.</summary>
		public int ai_version;

		/// <summary>The fully qualified domain name for the host.</summary>
		public StrPtrUni ai_fqdn;

		/// <summary>
		/// <para>Type: <c>struct sockaddr*</c></para>
		/// <para>
		/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned ADDRINFOW structure points to a filled-in
		/// socket address structure. The length, in bytes, of each returned <c>ADDRINFOW</c> structure is specified in the
		/// <c>ai_addrlen</c> member.
		/// </para>
		/// </summary>
		public readonly SOCKADDR addr => new(ai_addr, false, ai_addrlen);

		/// <inheritdoc/>
		public override readonly string ToString() => $"{ai_fqdn}::{ai_canonname}:{ai_flags},{ai_family},{ai_socktype},{ai_protocol},{addr}";
	}

	/// <summary>The <c>addrinfoex</c> structure is used by the GetAddrInfoEx function to hold host address information.</summary>
	/// <remarks>
	/// <para>
	/// The <c>addrinfoex</c> structure is used by the GetAddrInfoEx function to hold host address information. The <c>addrinfoex</c>
	/// structure is an enhanced version of the addrinfo and addrinfoW structures. The extra structure members are for blob data and the
	/// GUID for the namespace provider. The blob data is used to return additional provider-specific namespace information associated
	/// with a name. The format of data in the <c>ai_blob</c> member is specific to a particular namespace provider. Currently, blob
	/// data is used by the <c>NS_EMAIL</c> namespace provider to supply additional information.
	/// </para>
	/// <para>
	/// The <c>addrinfoex</c> structure is an enhanced version of the addrinfo and addrinfoW structure used with GetAddrInfoEx function.
	/// The <c>GetAddrInfoEx</c> function allows specifying the namespace provider to resolve the query. For use with the IPv6 and IPv4
	/// protocol, name resolution can be by the Domain Name System (DNS), a local hosts file, an email provider (the <c>NS_EMAIL</c>
	/// namespace), or by other naming mechanisms.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is defined, <c>addrinfoex</c> is defined to <c>addrinfoexW</c>, the Unicode version of this structure.
	/// The string parameters are defined to the <c>PWSTR</c> data type and the <c>addrinfoexW</c> structure is used.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is not defined, <c>addrinfoex</c> is defined to <c>addrinfoexA</c>, the ANSI version of this structure.
	/// The string parameters are of the <c>PCSTR</c> data type and the <c>addrinfoexA</c> structure is used.
	/// </para>
	/// <para>
	/// Upon a successful call to GetAddrInfoEx, a linked list of <c>addrinfoex</c> structures is returned in the ppResult parameter
	/// passed to the <c>GetAddrInfoEx</c> function. The list can be processed by following the pointer provided in the <c>ai_next</c>
	/// member of each returned <c>addrinfoex</c> structure until a <c>NULL</c> pointer is encountered. In each returned
	/// <c>addrinfoex</c> structure, the <c>ai_family</c>, <c>ai_socktype</c>, and <c>ai_protocol</c> members correspond to respective
	/// arguments in a socket or WSASocket function call. Also, the <c>ai_addr</c> member in each returned <c>addrinfoex</c> structure
	/// points to a filled-in socket address structure, the length of which is specified in its <c>ai_addrlen</c> member.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example demonstrates the use of the <c>addrinfoex</c> structure.</para>
	/// <para>
	/// <c>Note</c> Ensure that the development environment targets the newest version of Ws2tcpip.h which includes structure and
	/// function definitions for <c>ADDRINFOEX</c> and GetAddrInfoEx, respectively.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-addrinfoexa typedef struct addrinfoexA { int ai_flags; int
	// ai_family; int ai_socktype; int ai_protocol; size_t ai_addrlen; char *ai_canonname; struct sockaddr *ai_addr; void *ai_blob;
	// size_t ai_bloblen; LPGUID ai_provider; struct addrinfoexA *ai_next; } ADDRINFOEXA, *PADDRINFOEXA, *LPADDRINFOEXA;
	[PInvokeData("ws2def.h", MSDNShortId = "1077e03d-a1a4-45ab-a5d2-29a67e03f5df")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public unsafe struct ADDRINFOEXW
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Flags that indicate options used in the GetAddrInfoEx function.</para>
		/// <para>
		/// Supported values for the <c>ai_flags</c> member are defined in the Winsock2.h include file and can be a combination of the
		/// following options.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AI_PASSIVE 0x01</term>
		/// <term>The socket address will be used in a call to the bindfunction.</term>
		/// </item>
		/// <item>
		/// <term>AI_CANONNAME 0x02</term>
		/// <term>
		/// The canonical name is returned in the first ai_canonname member. When both the AI_CANONNAME and AI_FQDN bits are set, an
		/// addrinfoex2 structure is returned not the addrinfoex structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICHOST 0x04</term>
		/// <term>The nodename parameter passed to the GetAddrInfoEx function must be a numeric string.</term>
		/// </item>
		/// <item>
		/// <term>AI_ALL 0x0100</term>
		/// <term>
		/// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. This option is supported on
		/// Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ADDRCONFIG 0x0400</term>
		/// <term>
		/// The GetAddrInfoEx will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered
		/// a valid global address. This option is only supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_V4MAPPED 0x0800</term>
		/// <term>
		/// If the GetAddrInfoEx request for an IPv6 addresses fails, a name service request is made for IPv4 addresses and these
		/// addresses are converted to IPv4-mapped IPv6 address format. This option is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NON_AUTHORITATIVE 0x04000</term>
		/// <term>
		/// The address information is from non-authoritative results. When this option is set in the pHints parameter of GetAddrInfoEx,
		/// the NS_EMAIL namespace provider returns both authoritative and non-authoritative results. If this option is not set, then
		/// only authoritative results are returned. In the ppResults parameter returned by GetAddrInfoEx, this flag is set in the
		/// ai_flags member of the addrinfoex structure for non-authoritative results. This option is only supported on Windows Vista
		/// and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_SECURE 0x08000</term>
		/// <term>
		/// The address information is from a secure channel. If the AI_SECURE bit is set, the NS_EMAIL namespace provider will return
		/// results that were obtained with enhanced security to minimize possible spoofing. When this option is set in the pHints
		/// parameter of GetAddrInfoEx, the NS_EMAIL namespace provider returns only results that were obtained with enhanced security
		/// to minimize possible spoofing. In the ppResults parameter returned by GetAddrInfoEx, this flag is set in the ai_flags member
		/// of the addrinfoex structure for results returned with enhanced security to minimize possible spoofing. This option is only
		/// supported on Windows Vista and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_RETURN_PREFERRED_NAMES 0x010000</term>
		/// <term>
		/// The address information is for a preferred names for publication with a specific namespace. When this option is set in the
		/// pHints parameter of GetAddrInfoEx, no name should be provided in the pName parameter and the NS_EMAIL namespace provider
		/// will return preferred names for publication. In the ppResults parameter returned by GetAddrInfoEx, this flag is set in the
		/// ai_flags member of the addrinfoex structure for results returned for preferred names for publication. This option is only
		/// supported on Windows Vista and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FQDN 0x00020000</term>
		/// <term>
		/// The fully qualified domain name is returned in the first ai_canonicalname member. When this option is set in the pHints
		/// parameter of GetAddrInfoEx and a flat name (single label) is specified in the pName parameter, the fully qualified domain
		/// name that the name eventually resolved to will be returned. When both the AI_CANONNAME and AI_FQDN bits are set, an
		/// addrinfoex2 structure is returned not the addrinfoex structure. This option is supported on Windows 7, Windows Server 2008
		/// R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FILESERVER 0x00040000</term>
		/// <term>
		/// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
		/// provider may ignore this hint. This option is supported on Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_DISABLE_IDN_ENCODING 0x00080000</term>
		/// <term>
		/// Disable the automatic International Domain Name encoding using Punycode in the name resolution functions called by the
		/// GetAddrInfoEx function. This option is supported on Windows 8, Windows Server 2012, and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ADDRINFO_FLAGS ai_flags;

		private uint _ai_family;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The address family. Possible values for the address family are defined in the Winsock2.h include file.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and the possible
		/// values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically
		/// included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// The values currently supported are <c>AF_INET</c> or <c>AF_INET6</c>, which are the Internet address family formats for IPv4
		/// and IPv6. Other options for address family ( <c>AF_NETBIOS</c> for use with NetBIOS, for example) are supported if a Windows
		/// Sockets service provider for the address family is installed. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_UNSPEC</c> and <c>PF_UNSPEC</c>), so either constant can be used.
		/// </para>
		/// <para>The table below lists common values for the address family although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>The address family is unspecified.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_NETBIOS 17</term>
		/// <term>The NetBIOS address family. This address family is only supported if a Windows Sockets provider for NetBIOS is installed.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_IRDA 26</term>
		/// <term>
		/// The Infrared Data Association (IrDA) address family. This address family is only supported if the computer has an infrared
		/// port and driver installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_BTH 32</term>
		/// <term>
		/// The Bluetooth address family. This address family is only supported if a Bluetooth adapter is installed on Windows Server
		/// 2003 or later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ADDRESS_FAMILY ai_family { readonly get => (ADDRESS_FAMILY)_ai_family; set => _ai_family = (ushort)value; }

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The socket type. Possible values for the socket type are defined in the Winsock2.h include file.</para>
		/// <para>The following table lists the possible values for the socket type supported for Windows Sockets 2:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SOCK_STREAM 1</term>
		/// <term>
		/// Provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission mechanism. Uses the
		/// Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6). If the ai_family member is
		/// AF_IRDA, then SOCK_STREAM is the only supported socket type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_DGRAM 2</term>
		/// <term>
		/// Supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum length. Uses the User
		/// Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RAW 3</term>
		/// <term>
		/// Provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To manipulate the IPv4
		/// header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the IPV6_HDRINCL socket
		/// option must be set on the socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RDM 4</term>
		/// <term>
		/// Provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM) multicast protocol
		/// implementation in Windows, often referred to as reliable multicast programming.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_SEQPACKET 5</term>
		/// <term>Provides a pseudo-stream packet based on datagrams.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows Sockets 2, new socket types were introduced. An application can dynamically discover the attributes of each
		/// available transport protocol through the WSAEnumProtocols function. So an application can determine the possible socket type
		/// and protocol options for an address family and use this information when specifying this parameter. Socket type definitions
		/// in the Winsock2.h and Ws2def.h header files will be periodically updated as new socket types, address families, and
		/// protocols are defined.
		/// </para>
		/// <para>In Windows Sockets 1.1, the only possible socket types are <c>SOCK_DATAGRAM</c> and <c>SOCK_STREAM</c>.</para>
		/// </summary>
		public SOCK ai_socktype;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The protocol type. The possible options are specific to the address family and socket type specified. Possible values for
		/// the <c>ai_protocol</c> are defined in Winsock2.h and the Wsrm.h header files.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and this member can
		/// be one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h
		/// header file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// If a value of 0 is specified for <c>ai_protocol</c>, the caller does not wish to specify a protocol and the service provider
		/// will choose the <c>ai_protocol</c> to use. For protocols other than IPv4 and IPv6, set <c>ai_protocol</c> to zero.
		/// </para>
		/// <para>The following table lists common values for the <c>ai_protocol</c> member although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IPPROTO_TCP 6</term>
		/// <term>
		/// The Transmission Control Protocol (TCP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the
		/// ai_socktype member is SOCK_STREAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_UDP 17</term>
		/// <term>
		/// The User Datagram Protocol (UDP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the type
		/// parameter is SOCK_DGRAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_RM 113</term>
		/// <term>
		/// The PGM protocol for reliable multicast. This is a possible value when the ai_family member is AF_INET and the ai_socktype
		/// member is SOCK_RDM. On the Windows SDK released for Windows Vista and later, this value is also called IPPROTO_PGM.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the <c>ai_family</c> member is <c>AF_IRDA</c>, then the <c>ai_protocol</c> must be 0.</para>
		/// </summary>
		public IPPROTO ai_protocol;

		/// <summary>
		/// <para>Type: <c>size_t</c></para>
		/// <para>The length, in bytes, of the buffer pointed to by the <c>ai_addr</c> member.</para>
		/// </summary>
		public SizeT ai_addrlen;

		/// <summary>
		/// <para>Type: <c>PCTSTR</c></para>
		/// <para>The canonical name for the host.</para>
		/// </summary>
		public StrPtrUni ai_canonname;

		/// <summary>
		/// <para>Type: <c>struct sockaddr*</c></para>
		/// <para>
		/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned <c>addrinfoex</c> structure points to a
		/// filled-in socket address structure. The length, in bytes, of each returned <c>addrinfoex</c> structure is specified in the
		/// <c>ai_addrlen</c> member.
		/// </para>
		/// </summary>
		public IntPtr ai_addr;

		/// <summary>
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// A pointer to data that is used to return provider-specific namespace information that is associated with the name beyond a
		/// list of addresses. The length, in bytes, of the buffer pointed to by <c>ai_blob</c> must be specified in the
		/// <c>ai_bloblen</c> member.
		/// </para>
		/// </summary>
		public IntPtr ai_blob;

		/// <summary>
		/// <para>Type: <c>size_t</c></para>
		/// <para>The length, in bytes, of the <c>ai_blob</c> member.</para>
		/// </summary>
		public SizeT ai_bloblen;

		/// <summary>
		/// <para>Type: <c>LPGUID</c></para>
		/// <para>A pointer to the GUID of a specific namespace provider.</para>
		/// </summary>
		public Guid* ai_provider;

		/// <summary>
		/// <para>Type: <c>struct addrinfoex*</c></para>
		/// <para>
		/// A pointer to the next structure in a linked list. This parameter is set to <c>NULL</c> in the last <c>addrinfoex</c>
		/// structure of a linked list.
		/// </para>
		/// </summary>
		public IntPtr ai_next;

		/// <summary>
		/// <para>Type: <c>struct sockaddr*</c></para>
		/// <para>
		/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned ADDRINFOW structure points to a filled-in
		/// socket address structure. The length, in bytes, of each returned <c>ADDRINFOW</c> structure is specified in the
		/// <c>ai_addrlen</c> member.
		/// </para>
		/// </summary>
		public readonly SOCKADDR addr => new(ai_addr, false, ai_addrlen);

		/// <inheritdoc/>
		public override readonly string ToString() => $"{ai_canonname}:{ai_flags},{ai_family},{ai_socktype},{ai_protocol},{addr}";
	}

	/// <summary>
	/// The <c>addrinfoex2</c> structure is used by the GetAddrInfoEx function to hold host address information when both a canonical
	/// name and a fully qualified domain name have been requested.
	/// </summary>
	/// <remarks>
	/// <para>The <c>addrinfoex2</c> structure is supported on Windows 8 and Windows Server 2012</para>
	/// <para>
	/// The <c>addrinfoex2</c> structure is used by the GetAddrInfoEx function to hold host address information when both the
	/// <c>AI_FQDN</c> and <c>AI_CANONNAME</c> bits are set in the <c>ai_flags</c> member of the optional addrinfoex structure provided
	/// in the hints parameter to the <c>GetAddrInfoEx</c> function. The <c>addrinfoex2</c> structure is an enhanced version of the
	/// <c>addrinfoex</c> structure that can return both the canonical name and the fully qualified domain name for the host. The extra
	/// structure members are for a version number of the structure and the fully qualified domain name for the host.
	/// </para>
	/// <para>
	/// The <c>addrinfoex2</c> structure used with GetAddrInfoEx function is an enhanced version of the addrinfo and addrinfoW
	/// structures used with the getaddrinfo and GetAddrInfoW functions. The <c>GetAddrInfoEx</c> function allows specifying the
	/// namespace provider to resolve the query. For use with the IPv6 and IPv4 protocol, name resolution can be by the Domain Name
	/// System (DNS), a local hosts file, an email provider (the <c>NS_EMAIL</c> namespace), or by other naming mechanisms.
	/// </para>
	/// <para>
	/// The blob data in tha <c>ai_blob</c> member is used to return additional provider-specific namespace information associated with
	/// a name. The format of data in the <c>ai_blob</c> member is specific to a particular namespace provider. Currently, blob data is
	/// used by the <c>NS_EMAIL</c> namespace provider to supply additional information.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is defined, <c>addrinfoex2</c> is defined to <c>addrinfoex2W</c>, the Unicode version of this
	/// structure. The string parameters are defined to the <c>PWSTR</c> data type and the <c>addrinfoex2W</c> structure is used.
	/// </para>
	/// <para>
	/// When UNICODE or _UNICODE is not defined, <c>addrinfoex2</c> is defined to <c>addrinfoex2A</c>, the ANSI version of this
	/// structure. The string parameters are of the <c>char *</c> data type and the <c>addrinfoex2A</c> structure is used.
	/// </para>
	/// <para>
	/// Upon a successful call to GetAddrInfoEx, a linked list of <c>addrinfoex2</c> structures is returned in the ppResult parameter
	/// passed to the <c>GetAddrInfoEx</c> function. The list can be processed by following the pointer provided in the <c>ai_next</c>
	/// member of each returned <c>addrinfoex2</c> structure until a <c>NULL</c> pointer is encountered. In each returned
	/// <c>addrinfoex2</c> structure, the <c>ai_family</c>, <c>ai_socktype</c>, and <c>ai_protocol</c> members correspond to respective
	/// arguments in a socket or WSASocket function call. Also, the <c>ai_addr</c> member in each returned <c>addrinfoex2</c> structure
	/// points to a filled-in socket address structure, the length of which is specified in its <c>ai_addrlen</c> member.
	/// </para>
	/// </remarks>
	/// <summary>The <c>addrinfo</c> structure is used by the getaddrinfo function to hold host address information.</summary>
	/// <remarks>
	/// <para>The <c>addrinfo</c> structure is used by the ANSI getaddrinfo function to hold host address information.</para>
	/// <para>The addrinfoW structure is the version of this structure used by the Unicode GetAddrInfoW function.</para>
	/// <para>
	/// Macros in the Ws2tcpip.h header file define a <c>ADDRINFOT</c> structure and a mixed-case function name of <c>GetAddrInfo</c>.
	/// The <c>GetAddrInfo</c> function should be called with the nodename and servname parameters of a pointer of type <c>TCHAR</c> and
	/// the hints and res parameters of a pointer of type <c>ADDRINFOT</c>. When UNICODE or _UNICODE is not defined, <c>ADDRINFOT</c> is
	/// defined to the <c>addrinfo</c> structure and <c>GetAddrInfo</c> is defined to getaddrinfo, the ANSI version of this function.
	/// When UNICODE or _UNICODE is defined, <c>ADDRINFOT</c> is defined to the addrinfoW structure and <c>GetAddrInfo</c> is defined to
	/// GetAddrInfoW, the Unicode version of this function.
	/// </para>
	/// <para>
	/// Upon a successful call to getaddrinfo, a linked list of <c>addrinfo</c> structures is returned in the res parameter passed to
	/// the <c>getaddrinfo</c> function. The list can be processed by following the pointer provided in the <c>ai_next</c> member of
	/// each returned <c>addrinfo</c> structure until a <c>NULL</c> pointer is encountered. In each returned <c>addrinfo</c> structure,
	/// the <c>ai_family</c>, <c>ai_socktype</c>, and <c>ai_protocol</c> members correspond to respective arguments in a socket or
	/// WSASocket function call. Also, the <c>ai_addr</c> member in each returned <c>addrinfo</c> structure points to a filled-in socket
	/// address structure, the length of which is specified in its <c>ai_addrlen</c> member.
	/// </para>
	/// <para>Support for getaddrinfo and the addrinfo struct on older versions of Windows</para>
	/// <para>
	/// The getaddrinfo function that uses the <c>addrinfo</c> structure was added to the Ws2_32.dll on Windows XP and later. The
	/// <c>addrinfo</c> structure is defined in the Ws2tcpip.h header file included with the Platform SDK released for Windows XP and
	/// later and the Windows SDK released for Windows Vista and later.
	/// </para>
	/// <para>
	/// To execute an application that uses the getaddrinfo function and the <c>addrinfo</c> structure on earlier versions of Windows
	/// (Windows 2000), then you need to include the Ws2tcpip.h and Wspiapi.h files. When the Wspiapi.h include file is added, the
	/// <c>getaddrinfo</c> function is defined to the WspiapiGetAddrInfo inline function in the Wspiapi.h file. At runtime, the
	/// WspiapiGetAddrInfo function is implemented in such a way that if the Ws2_32.dll or the Wship6.dll (the file containing
	/// <c>getaddrinfo</c> in the IPv6 Technology Preview for Windows 2000) does not include <c>getaddrinfo</c>, then a version of
	/// <c>getaddrinfo</c> is implemented inline based on code in the Wspiapi.h header file. This inline code will be used on older
	/// Windows platforms that do not natively support the <c>getaddrinfo</c> function.
	/// </para>
	/// <para>
	/// The IPv6 protocol is supported on Windows 2000 when the IPv6 Technology Preview for Windows 2000 is installed. Otherwise
	/// getaddrinfo support on versions of Windows earlier than Windows XP is limited to handling IPv4 name resolution.
	/// </para>
	/// <para>
	/// The GetAddrInfoW function that uses the addrinfoW structure is the Unicode version of the getaddrinfo function and associated
	/// <c>addrinfo</c> structure. The <c>GetAddrInfoW</c> function was added to the Ws2_32.dll in Windows XP with Service Pack 2 (SP2).
	/// The <c>GetAddrInfoW</c> function and the <c>addrinfoW</c> structure cannot be used on versions of Windows earlier than Windows
	/// XP with SP2.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows the use of the <c>addrinfo</c> structure.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-addrinfoa typedef struct addrinfo { int ai_flags; int
	// ai_family; int ai_socktype; int ai_protocol; size_t ai_addrlen; char *ai_canonname; struct sockaddr *ai_addr; struct addrinfo
	// *ai_next; } ADDRINFOA, *PADDRINFOA;
	[PInvokeData("ws2def.h", MSDNShortId = "4df914ab-59b0-4110-bc81-59e5f6722b8d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct ADDRINFOW
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Flags that indicate options used in the getaddrinfo function.</para>
		/// <para>
		/// Supported values for the <c>ai_flags</c> member are defined in the Ws2def.h header file on the Windows SDK for Windows 7 and
		/// later. These values are defined in the Ws2tcpip.h header file on the Windows SDK for Windows Server 2008 and Windows Vista.
		/// These values are defined in the Ws2tcpip.h header file on the Platform SDK for Windows Server 2003, and Windows XP.
		/// Supported values for the <c>ai_flags</c> member can be a combination of the following options.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AI_PASSIVE 0x01</term>
		/// <term>The socket address will be used in a call to the bindfunction.</term>
		/// </item>
		/// <item>
		/// <term>AI_CANONNAME 0x02</term>
		/// <term>The canonical name is returned in the first ai_canonname member.</term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICHOST 0x04</term>
		/// <term>The nodename parameter passed to the getaddrinfo function must be a numeric string.</term>
		/// </item>
		/// <item>
		/// <term>AI_ALL 0x0100</term>
		/// <term>
		/// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. This option is supported on
		/// Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ADDRCONFIG 0x0400</term>
		/// <term>
		/// The getaddrinfo will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered a
		/// valid global address. This option is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_V4MAPPED 0x0800</term>
		/// <term>
		/// If the getaddrinfo request for IPv6 addresses fails, a name service request is made for IPv4 addresses and these addresses
		/// are converted to IPv4-mapped IPv6 address format. This option is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NON_AUTHORITATIVE 0x04000</term>
		/// <term>
		/// The address information can be from a non-authoritative namespace provider. This option is only supported on Windows Vista
		/// and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_SECURE 0x08000</term>
		/// <term>
		/// The address information is from a secure channel. This option is only supported on Windows Vista and later for the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_RETURN_PREFERRED_NAMES 0x010000</term>
		/// <term>
		/// The address information is for a preferred name for a user. This option is only supported on Windows Vista and later for the
		/// NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FQDN 0x00020000</term>
		/// <term>
		/// If a flat name (single label) is specified, getaddrinfo will return the fully qualified domain name that the name eventually
		/// resolved to. The fully qualified domain name is returned in the ai_canonname member. This is different than AI_CANONNAME bit
		/// flag that returns the canonical name registered in DNS which may be different than the fully qualified domain name that the
		/// flat name resolved to. Only one of the AI_FQDN and AI_CANONNAME bits can be set. The getaddrinfo function will fail if both
		/// flags are present with EAI_BADFLAGS. This option is supported on Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FILESERVER 0x00040000</term>
		/// <term>
		/// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
		/// provider may ignore this hint. This option is supported on Windows 7, Windows Server 2008 R2, and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ADDRINFO_FLAGS ai_flags;

		private uint _ai_family;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The address family. Possible values for the address family are defined in the Winsock2.h include file.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and the possible
		/// values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically
		/// included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// The values currently supported are <c>AF_INET</c> or <c>AF_INET6</c>, which are the Internet address family formats for IPv4
		/// and IPv6. Other options for address family ( <c>AF_NETBIOS</c> for use with NetBIOS, for example) are supported if a Windows
		/// Sockets service provider for the address family is installed. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_UNSPEC</c> and <c>PF_UNSPEC</c>), so either constant can be used.
		/// </para>
		/// <para>The table below lists common values for the address family although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_UNSPEC 0</term>
		/// <term>The address family is unspecified.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_NETBIOS 17</term>
		/// <term>The NetBIOS address family. This address family is only supported if a Windows Sockets provider for NetBIOS is installed.</term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_IRDA 26</term>
		/// <term>
		/// The Infrared Data Association (IrDA) address family. This address family is only supported if the computer has an infrared
		/// port and driver installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_BTH 32</term>
		/// <term>
		/// The Bluetooth address family. This address family is only supported if a Bluetooth adapter is installed on Windows Server
		/// 2003 or later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ADDRESS_FAMILY ai_family { readonly get => (ADDRESS_FAMILY)_ai_family; set => _ai_family = (ushort)value; }

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The socket type. Possible values for the socket type are defined in the Winsock2.h header file.</para>
		/// <para>The following table lists the possible values for the socket type supported for Windows Sockets 2:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SOCK_STREAM 1</term>
		/// <term>
		/// Provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission mechanism. Uses the
		/// Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6). If the ai_family member is
		/// AF_IRDA, then SOCK_STREAM is the only supported socket type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_DGRAM 2</term>
		/// <term>
		/// Supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum length. Uses the User
		/// Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RAW 3</term>
		/// <term>
		/// Provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To manipulate the IPv4
		/// header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the IPV6_HDRINCL socket
		/// option must be set on the socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RDM 4</term>
		/// <term>
		/// Provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM) multicast protocol
		/// implementation in Windows, often referred to as reliable multicast programming.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_SEQPACKET 5</term>
		/// <term>Provides a pseudo-stream packet based on datagrams.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows Sockets 2, new socket types were introduced. An application can dynamically discover the attributes of each
		/// available transport protocol through the WSAEnumProtocols function. So an application can determine the possible socket type
		/// and protocol options for an address family and use this information when specifying this parameter. Socket type definitions
		/// in the Winsock2.h and Ws2def.h header files will be periodically updated as new socket types, address families, and
		/// protocols are defined.
		/// </para>
		/// <para>In Windows Sockets 1.1, the only possible socket types are <c>SOCK_DATAGRAM</c> and <c>SOCK_STREAM</c>.</para>
		/// </summary>
		public SOCK ai_socktype;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The protocol type. The possible options are specific to the address family and socket type specified. Possible values for
		/// the <c>ai_protocol</c> are defined in the Winsock2.h and Wsrm.h header files.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and this member can be
		/// one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h
		/// header file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// If a value of 0 is specified for <c>ai_protocol</c>, the caller does not wish to specify a protocol and the service provider
		/// will choose the <c>ai_protocol</c> to use. For protocols other than IPv4 and IPv6, set <c>ai_protocol</c> to zero.
		/// </para>
		/// <para>The following table lists common values for the <c>ai_protocol</c> member although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IPPROTO_TCP 6</term>
		/// <term>
		/// The Transmission Control Protocol (TCP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the
		/// ai_socktype member is SOCK_STREAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_UDP 17</term>
		/// <term>
		/// The User Datagram Protocol (UDP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the type
		/// parameter is SOCK_DGRAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_RM 113</term>
		/// <term>
		/// The PGM protocol for reliable multicast. This is a possible value when the ai_family member is AF_INET and the ai_socktype
		/// member is SOCK_RDM. On the Windows SDK released for Windows Vista and later, this value is also called IPPROTO_PGM.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the <c>ai_family</c> member is <c>AF_IRDA</c>, then the <c>ai_protocol</c> must be 0.</para>
		/// </summary>
		public IPPROTO ai_protocol;

		/// <summary>
		/// <para>Type: <c>size_t</c></para>
		/// <para>The length, in bytes, of the buffer pointed to by the <c>ai_addr</c> member.</para>
		/// </summary>
		public SizeT ai_addrlen;

		/// <summary>
		/// <para>Type: <c>char*</c></para>
		/// <para>The canonical name for the host.</para>
		/// </summary>
		public StrPtrUni ai_canonname;

		/// <summary>
		/// <para>Type: <c>struct sockaddr*</c></para>
		/// <para>
		/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned <c>addrinfo</c> structure points to a
		/// filled-in socket address structure. The length, in bytes, of each returned <c>addrinfo</c> structure is specified in the
		/// <c>ai_addrlen</c> member.
		/// </para>
		/// </summary>
		public IntPtr ai_addr;

		/// <summary>
		/// <para>Type: <c>struct addrinfo*</c></para>
		/// <para>
		/// A pointer to the next structure in a linked list. This parameter is set to <c>NULL</c> in the last <c>addrinfo</c> structure
		/// of a linked list.
		/// </para>
		/// </summary>
		public IntPtr ai_next;

		/// <summary>
		/// <para>Type: <c>struct sockaddr*</c></para>
		/// <para>
		/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned ADDRINFOW structure points to a filled-in
		/// socket address structure. The length, in bytes, of each returned <c>ADDRINFOW</c> structure is specified in the
		/// <c>ai_addrlen</c> member.
		/// </para>
		/// </summary>
		public readonly SOCKADDR addr => new(ai_addr, false, ai_addrlen);

		/// <inheritdoc/>
		public override readonly string ToString() => $"{ai_canonname}:{ai_flags},{ai_family},{ai_socktype},{ai_protocol},{addr}";
	}

	/// <summary>The scope identifier for the IPv6 transport address.</summary>
	[PInvokeData("ws2def.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCOPE_ID
	{
		/// <summary>A ULONG representation of the IPv6 scope identifier.</summary>
		public uint Value;

		/// <summary>
		/// <para>
		/// The zone index that identifies the zone to which the transport address pertains. Zones of the different scopes are
		/// instantiated as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>Each interface on a node comprises a single zone of interface-local scope.</item>
		/// <item>Each link, and the interfaces attached to that link, comprise a single zone of link-local scope.</item>
		/// <item>There is a single zone of global scope that comprises all of the links and interfaces in the Internet.</item>
		/// <item>The boundaries of zones of scope other than interface-local, link-local, and global are defined by network administrators.</item>
		/// </list>
		/// <para>A value of zero specifies the default zone.</para>
		/// </summary>
		/// <value>The zone index.</value>
		public uint Zone
		{
			readonly get => BitHelper.GetBits(Value, 0, 28);
			set => BitHelper.SetBits(ref Value, 0, 28, value);
		}

		/// <summary>
		/// <para>
		/// The scope of the IPv6 transport address. This scope must be the same as the IPv6 scope value that is embedded in the IPv6
		/// transport address. This member can be one of the following:
		/// </para>
		/// <para><strong>ScopeLevelInterface</strong></para>
		/// <para>The transport address has interface-local scope.</para>
		/// <para><strong>ScopeLevelLink</strong></para>
		/// <para>The transport address has link-local scope.</para>
		/// <para><strong>ScopeLevelSubnet</strong></para>
		/// <para>The transport address has subnet-local scope.</para>
		/// <para><strong>ScopeLevelAdmin</strong></para>
		/// <para>The transport address has admin-local scope.</para>
		/// <para><strong>ScopeLevelSite</strong></para>
		/// <para>The transport address has site-local scope.</para>
		/// <para><strong>ScopeLevelOrganization</strong></para>
		/// <para>The transport address has organization-local scope.</para>
		/// <para><strong>ScopeLevelGlobal</strong></para>
		/// <para>The transport address has global scope.</para>
		/// </summary>
		/// <value>The level.</value>
		public byte Level
		{
			readonly get => (byte)BitHelper.GetBits(Value, 28, 4);
			set => BitHelper.SetBits(ref Value, 28, 4, value);
		}
	}

	/// <summary>The SOCKADDR_IN structure specifies a transport address and port for the AF_INET address family.</summary>
	/// <remarks>
	/// All of the data in the SOCKADDR_IN structure, except for the address family, must be specified in network-byte-order (big-endian).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-sockaddr_in typedef struct sockaddr_in { #if ... short
	// sin_family; #else ADDRESS_FAMILY sin_family; #endif USHORT sin_port; IN_ADDR sin_addr; CHAR sin_zero[8]; } SOCKADDR_IN, *PSOCKADDR_IN;
	[PInvokeData("ws2def.h", MSDNShortId = "96379562-403f-451c-ac7a-f0eec34bfe5e")]
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct SOCKADDR_IN
	{
		/// <summary>The address family for the transport address. This member should always be set to AF_INET.</summary>
		public ADDRESS_FAMILY sin_family;

		/// <summary>A transport protocol port number.</summary>
		public ushort sin_port;

		/// <summary>An IN_ADDR structure that contains an IPv4 transport address.</summary>
		public IN_ADDR sin_addr;

		/// <summary>Reserved for system use. A WSK application should set the contents of this array to zero.</summary>
		public ulong sin_zero;

		/// <summary>Initializes a new instance of the <see cref="SOCKADDR_IN"/> struct.</summary>
		/// <param name="addr">An IN_ADDR structure that contains an IPv4 transport address.</param>
		/// <param name="port">A transport protocol port number.</param>
		public SOCKADDR_IN(IN_ADDR addr, ushort port = 0)
		{
			sin_family = ADDRESS_FAMILY.AF_INET;
			sin_port = port;
			sin_addr = addr;
			sin_zero = 0;
		}

		/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="SOCKADDR_IN"/>.</summary>
		/// <param name="addr">The addr.</param>
		/// <returns>The resulting <see cref="SOCKADDR_IN"/> instance from the conversion.</returns>
		public static implicit operator SOCKADDR_IN(IN_ADDR addr) => new(addr);

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_IN"/> to <see cref="SOCKADDR_IN6"/>.</summary>
		/// <param name="ipv4">The ipv4 address.</param>
		/// <returns>The resulting <see cref="SOCKADDR_IN6"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_IN6(SOCKADDR_IN ipv4) => new(ipv4);

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override readonly string ToString() => $"{sin_addr}:{sin_port}";
	}

	/// <summary>The SOCKADDR_STORAGE structure is a generic structure that specifies a transport address.</summary>
	/// <remarks>
	/// A WSK application typically does not directly access any of the members of the SOCKADDR_STORAGE structure except for the
	/// <c>ss_family</c> member. Instead, a pointer to a SOCKADDR_STORAGE structure is normally cast to a pointer to the specific
	/// SOCKADDR structure type that corresponds to a particular address family.
	/// </remarks>
	// https://docs.microsoft.com/ja-jp/windows/desktop/api/ws2def/ns-ws2def-sockaddr_storage_lh typedef struct sockaddr_storage {
	// ADDRESS_FAMILY ss_family; CHAR __ss_pad1[_SS_PAD1SIZE]; __int64 __ss_align; CHAR __ss_pad2[_SS_PAD2SIZE]; } SOCKADDR_STORAGE_LH,
	// *PSOCKADDR_STORAGE_LH, *LPSOCKADDR_STORAGE_LH;
	[PInvokeData("ws2def.h", MSDNShortId = "27e56c1a-ce11-4cdb-9be8-25ed2f94fb37")]
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	public struct SOCKADDR_STORAGE
	{
		/// <summary>
		/// The address family for the transport address. For more information about supported address families, see WSK Address Families.
		/// </summary>
		public ADDRESS_FAMILY ss_family;

		/// <summary>A padding of 6 bytes that puts the <c>__ss_align</c> member on an eight-byte boundary within the structure.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public byte[] __ss_pad1;

		/// <summary>A 64-bit value that forces the structure to be 8-byte aligned.</summary>
		public long __ss_align;

		/// <summary>A padding of an additional 112 bytes that brings the total size of the SOCKADDR_STORAGE structure to 128 bytes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
		public byte[] __ss_pad2;

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_IN6"/> to <see cref="SOCKADDR_STORAGE"/>.</summary>
		/// <param name="addr">The address.</param>
		/// <returns>The resulting <see cref="SOCKADDR_STORAGE"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_STORAGE(in SOCKADDR_IN6 addr)
		{
			using var mem = SafeHGlobalHandle.CreateFromStructure(addr);
			mem.Size = Marshal.SizeOf(typeof(SOCKADDR_STORAGE));
			return mem.ToStructure<SOCKADDR_STORAGE>();
		}

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_IN"/> to <see cref="SOCKADDR_STORAGE"/>.</summary>
		/// <param name="addr">The address.</param>
		/// <returns>The resulting <see cref="SOCKADDR_STORAGE"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_STORAGE(in SOCKADDR_IN addr)
		{
			using var mem = SafeHGlobalHandle.CreateFromStructure(addr);
			mem.Size = Marshal.SizeOf(typeof(SOCKADDR_STORAGE));
			return mem.ToStructure<SOCKADDR_STORAGE>();
		}

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR"/> to <see cref="SOCKADDR_STORAGE"/>.</summary>
		/// <param name="addr">The address.</param>
		/// <returns>The resulting <see cref="SOCKADDR_STORAGE"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_STORAGE(SOCKADDR addr)
		{
			using var mem = new SafeHGlobalHandle(addr.GetAddressBytes());
			mem.Size = Marshal.SizeOf(typeof(SOCKADDR_STORAGE));
			return mem.ToStructure<SOCKADDR_STORAGE>();
		}

		/// <summary>Performs an explicit conversion from <see cref="IPAddress"/> to <see cref="SOCKADDR_STORAGE"/>.</summary>
		/// <param name="addr">The address.</param>
		/// <returns>The resulting <see cref="SOCKADDR_STORAGE"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_STORAGE(IPAddress addr)
		{
			using var mem = new SafeHGlobalHandle(addr.GetAddressBytes());
			mem.Size = Marshal.SizeOf(typeof(SOCKADDR_STORAGE));
			return mem.ToStructure<SOCKADDR_STORAGE>();
		}

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_INET"/> to <see cref="SOCKADDR_STORAGE"/>.</summary>
		/// <param name="addr">The address.</param>
		/// <returns>The resulting <see cref="SOCKADDR_STORAGE"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_STORAGE(SOCKADDR_INET addr)
		{
			using var mem = SafeHGlobalHandle.CreateFromStructure(addr);
			mem.Size = Marshal.SizeOf(typeof(SOCKADDR_STORAGE));
			return mem.ToStructure<SOCKADDR_STORAGE>();
		}

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_STORAGE"/> to <see cref="SOCKADDR"/>.</summary>
		/// <param name="addr">The addr.</param>
		/// <returns>The resulting <see cref="SOCKADDR"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR(SOCKADDR_STORAGE addr) => SOCKADDR.CreateFromStructure(addr);

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_STORAGE"/> to <see cref="SOCKADDR_IN"/>.</summary>
		/// <param name="addr">The addr.</param>
		/// <returns>The resulting <see cref="SOCKADDR_IN"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_IN(SOCKADDR_STORAGE addr) => (SOCKADDR_IN)SOCKADDR.CreateFromStructure(addr);

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_STORAGE"/> to <see cref="SOCKADDR_IN6"/>.</summary>
		/// <param name="addr">The addr.</param>
		/// <returns>The resulting <see cref="SOCKADDR_IN6"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_IN6(SOCKADDR_STORAGE addr) => (SOCKADDR_IN6)SOCKADDR.CreateFromStructure(addr);

		/// <summary>Performs an explicit conversion from <see cref="SOCKADDR_STORAGE"/> to <see cref="SOCKADDR_INET"/>.</summary>
		/// <param name="addr">The addr.</param>
		/// <returns>The resulting <see cref="SOCKADDR_INET"/> instance from the conversion.</returns>
		public static explicit operator SOCKADDR_INET(SOCKADDR_STORAGE addr) => (SOCKADDR_INET)SOCKADDR.CreateFromStructure(addr);
	}

	/// <summary>The <c>SOCKET_ADDRESS</c> structure stores protocol-specific address information.</summary>
	/// <remarks>
	/// <para>
	/// The SOCKADDR structure pointed to by the <c>lpSockaddr</c> member varies depending on the protocol or address family selected.
	/// For example, the <c>sockaddr_in6</c> structure is used for an IPv6 socket address while the <c>sockaddr_in4</c> structure is
	/// used for an IPv4 socket address. The address family is the first member of all of the <c>SOCKADDR</c> structures. The address
	/// family is used to determine which structure is used.
	/// </para>
	/// <para>
	/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
	/// has changed and the <c>SOCKET_ADDRESS</c> structure is defined in the Ws2def.h header file. Note that the Ws2def.h header file
	/// is automatically included in Winsock2.h, and should never be used directly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-socket_address typedef struct _SOCKET_ADDRESS { LPSOCKADDR
	// lpSockaddr; INT iSockaddrLength; } SOCKET_ADDRESS, *PSOCKET_ADDRESS, *LPSOCKET_ADDRESS;
	[PInvokeData("ws2def.h", MSDNShortId = "37fbcb96-a859-4eca-8928-8051f95407b9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_ADDRESS
	{
		/// <summary>A pointer to a socket address represented as a SOCKADDR structure.</summary>
		public IntPtr lpSockaddr;

		private IntPtr len;

		/// <summary>The length, in bytes, of the socket address.</summary>
		public int iSockaddrLength { readonly get => len.ToInt32(); set => len = new(value); }

		/// <summary>Gets the <see cref="SOCKADDR_INET"/> from this instance.</summary>
		/// <returns>The <see cref="SOCKADDR_INET"/> value pointed to by this instance.</returns>
		public readonly SOCKADDR_INET GetSOCKADDR() => iSockaddrLength == 16 ? lpSockaddr.ToStructure<SOCKADDR_IN>(iSockaddrLength) : lpSockaddr.ToStructure<SOCKADDR_INET>(iSockaddrLength);

		/// <summary>Performs an implicit conversion from <see cref="SOCKET_ADDRESS"/> to <see cref="SOCKADDR"/>.</summary>
		/// <param name="address">The address.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SOCKADDR(SOCKET_ADDRESS address) => new(address);

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => GetSOCKADDR().ToString();
	}

	/// <summary>The SOCKET_ADDRESS_LIST structure defines a variable-sized list of transport addresses.</summary>
	/// <remarks>
	/// <para>
	/// A WSK application passes a buffer to the WskControlSocket function when the WSK application queries the current list of local
	/// transport addresses that match a socket's address family. If the call to the <c>WskControlSocket</c> function succeeds, the
	/// buffer contains a SOCKET_ADDRESS_LIST structure followed by the SOCKADDR structures for each of the local transport addresses
	/// that match the socket's address family. The WSK subsystem fills in the <c>Address</c> array and sets the <c>iAddressCount</c>
	/// member to the number of entries in the array. The <c>lpSockaddr</c> pointers in each of the SOCKET_ADDRESS structures in the
	/// array point to the specific SOCKADDR structure type that corresponds to the address family that the WSK application specified
	/// when it created the socket.
	/// </para>
	/// <para>For more information about querying the current list of local transport addresses, see SIO_ADDRESS_LIST_QUERY.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-socket_address_list typedef struct _SOCKET_ADDRESS_LIST { INT
	// iAddressCount; SOCKET_ADDRESS Address[1]; } SOCKET_ADDRESS_LIST, *PSOCKET_ADDRESS_LIST, *LPSOCKET_ADDRESS_LIST;
	[PInvokeData("ws2def.h", MSDNShortId = "b005200b-b0c2-4f19-8765-cd26fbfc0cff")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<SOCKET_ADDRESS_LIST>), nameof(iAddressCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_ADDRESS_LIST
	{
		/// <summary>The number of transport addresses in the list.</summary>
		public int iAddressCount;

		/// <summary>A variable-sized array of SOCKET_ADDRESS structures. The SOCKET_ADDRESS structure is defined as follows:</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public SOCKET_ADDRESS[] Address;

		/// <summary>Packs this instance into a single memory block so that it can be passed as a pointer to other API methods.</summary>
		/// <returns>
		/// A <see cref="SafeCoTaskMemStruct{T}"/> instance that contains this structure and all memeroy assigned to its <see
		/// cref="Address"/> elements.
		/// </returns>
		public SafeCoTaskMemStruct<SOCKET_ADDRESS_LIST> Pack()
		{
			var addrOffset = Marshal.OffsetOf(typeof(SOCKET_ADDRESS_LIST), "Address").ToInt32();
			var eosOffset = addrOffset + iAddressCount * Marshal.SizeOf(typeof(SOCKET_ADDRESS));
			var cbAddressList = eosOffset + Address.Sum(a => a.iSockaddrLength);

			var addressList = new SafeCoTaskMemStruct<SOCKET_ADDRESS_LIST>(cbAddressList);
			((IntPtr)addressList).Write(iAddressCount);
			var newAddr = new SOCKET_ADDRESS[iAddressCount];
			var ptr = ((IntPtr)addressList).Offset(eosOffset);
			for (int i = 0; i < iAddressCount; i++)
			{
				newAddr[i] = new SOCKET_ADDRESS { iSockaddrLength = Address[i].iSockaddrLength, lpSockaddr = ptr };
				Address[i].lpSockaddr.CopyTo(ptr, Address[i].iSockaddrLength);
				ptr = ptr.Offset(Address[i].iSockaddrLength);
			}
			((IntPtr)addressList).Write(newAddr, addrOffset);
			return addressList;
		}
	}

	/// <summary>
	/// The <c>SOCKET_PROCESSOR_AFFINITY</c> structure contains the association between a socket and an RSS processor core and NUMA node..
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>SOCKET_PROCESSOR_AFFINITY</c> structure is supported on Windows 8, and Windows Server 2012, and later versions of the
	/// operating system.
	/// </para>
	/// <para>
	/// The SIO_QUERY_RSS_PROCESSOR_INFO IOCTL is used to determine the association between a socket and an RSS processor core and NUMA
	/// node. This IOCTL returns a <c>SOCKET_PROCESSOR_AFFINITY</c> structure that contains the processor number and the NUMA node ID.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-socket_processor_affinity typedef struct
	// _SOCKET_PROCESSOR_AFFINITY { PROCESSOR_NUMBER Processor; USHORT NumaNodeId; USHORT Reserved; } SOCKET_PROCESSOR_AFFINITY, *PSOCKET_PROCESSOR_AFFINITY;
	[PInvokeData("ws2def.h", MSDNShortId = "CB1E9F79-C6BD-40C2-8D0F-36B24B1BBBF4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SOCKET_PROCESSOR_AFFINITY
	{
		/// <summary>
		/// A structure to represent a system wide processor number. This PROCESSOR_NUMBER structure contains a group number and
		/// relative processor number within the group.
		/// </summary>
		public Kernel32.PROCESSOR_NUMBER Processor;

		/// <summary>The NUMA node ID.</summary>
		public ushort NumaNodeId;

		/// <summary>A value reserved for future use.</summary>
		public ushort Reserved;
	}

	/// <summary>The <c>WSABUF</c> structure enables the creation or manipulation of a data buffer used by some Winsock functions.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ws2def/ns-ws2def-_wsabuf typedef struct _WSABUF { ULONG len; CHAR *buf; }
	// WSABUF, *LPWSABUF;
	[PInvokeData("ws2def.h", MSDNShortId = "a012c3ba-67fd-4fcf-84d1-85e9d495c29c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WSABUF
	{
		/// <summary>The length of the buffer, in bytes.</summary>
		public uint len;

		/// <summary>A pointer to the buffer.</summary>
		public IntPtr buf;
	}

	/// <summary>The CMSGHDR structure defines the header for a control data object that is associated with a datagram.</summary>
	/// <remarks>
	/// The control information data that is associated with a datagram is made up of one or more control data objects. Each object
	/// begins with a CMSGHDR structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-wsacmsghdr typedef struct _WSACMSGHDR { SIZE_T cmsg_len; INT
	// cmsg_level; INT cmsg_type; } WSACMSGHDR, *PWSACMSGHDR, *LPWSACMSGHDR;
	[PInvokeData("ws2def.h", MSDNShortId = "NS:ws2def._WSACMSGHDR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSACMSGHDR
	{
		/// <summary>
		/// <para>The number of bytes from the beginning of the CMSGHDR structure to the end of the control data.</para>
		/// <para><c>Note</c> The value of the <c>cmsg_len</c> member does not account for any padding that may follow the control data.</para>
		/// </summary>
		public SizeT cmsg_len;

		/// <summary>The protocol that originated the control information.</summary>
		public int cmsg_level;

		/// <summary>The protocol-specific type of control information.</summary>
		public int cmsg_type;
	}

	/// <summary>
	/// The <c>WSAMSG</c> structure is used with the WSARecvMsg and WSASendMsg functions to store address and optional control
	/// information about connected and unconnected sockets as well as an array of buffers used to store message data.
	/// </summary>
	/// <remarks>
	/// <para>
	/// In the Microsoft Windows Software Development Kit (SDK), the version of this structure for use on Windows Vistais defined with
	/// the data type for the <c>dwBufferCount</c> and <c>dwFlags</c> members as a <c>ULONG</c>. When compiling an application if the
	/// target platform is Windows Vista and later ( <c>NTDDI_VERSION &gt;= NTDDI_LONGHORN, _WIN32_WINNT &gt;= 0x0600</c>, or <c>WINVER
	/// &gt;= 0x0600</c>), the data type for the <c>dwBufferCount</c> and <c>dwFlags</c> members is a <c>ULONG</c>.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> When compiling an application, the data type for the <c>dwBufferCount</c> and
	/// <c>dwFlags</c> members is a <c>DWORD</c>.
	/// </para>
	/// <para>
	/// On the Windows SDK released for Windows Vista and later, the <c>WSAMSG</c> structure is defined in the Ws2def.h header file.
	/// Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly
	/// </para>
	/// <para>
	/// If the datagram or control data is truncated during the transmission, the function being used in association with the
	/// <c>WSAMSG</c> structure returns SOCKET_ERROR and a call to the WSAGetLastError function returns WSAEMSGSIZE. It is up to the
	/// application to determine what was truncated by checking for MSG_TRUNC and/or MSG_CTRUNC flags.
	/// </para>
	/// <para>Use of the Control Member</para>
	/// <para>
	/// The following table summarizes the various uses of control data available for use in the <c>Control</c> member for IPv4 and IPv6.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Protocol</term>
	/// <term>cmsg_level</term>
	/// <term>cmsg_type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IPv4</term>
	/// <term>IPPROTO_IP</term>
	/// <term>IP_ORIGINAL_ARRIVAL_IF</term>
	/// <term>
	/// Receives the original IPv4 arrival interface where the packet was received for datagram sockets. This control data is used by
	/// firewalls when a Teredo, 6to4, or ISATAP tunnel is used for IPv4 NAT traversal. The cmsg_data[] member in the WSAMSG structure
	/// is a ULONG that contains the IF_INDEX defined in the Ifdef.h header file. For more information, see the IPPROTO_IP Socket
	/// Options for the IP_ORIGINAL_ARRIVAL_IF socket option. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
	/// The IP_ORIGINAL_ARRIVAL_IF cmsg_type is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPv4</term>
	/// <term>IPPROTO_IP</term>
	/// <term>IP_PKTINFO</term>
	/// <term>Specifies/receives packet information for an IPv4 socket. For more information, see the IP_PKTINFO socket option.</term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_DSTOPTS</term>
	/// <term>Specifies/receives destination options.</term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_HOPLIMIT</term>
	/// <term>Specifies/receives hop limit. For more information, see the IPPROTO_IPV6 Socket Options for the IPV6_HOPLIMIT socket option.</term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_HOPOPTS</term>
	/// <term>Specifies/receives hop-by-hop options.</term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_NEXTHOP</term>
	/// <term>Specifies next-hop address.</term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_PKTINFO</term>
	/// <term>Specifies/receives packet information for an IPv6 socket. For more information, see the IPV6_PKTINFO socket option.</term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_RTHDR</term>
	/// <term>Specifies/receives routing header.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Control data is made up of one or more control data objects, each beginning with a <c>WSACMSGHDR</c> structure, defined as the following.
	/// </para>
	/// <para>
	/// <c>Note</c> The transport, not the application, fills out the header information in the <c>WSACMSGHDR</c> structure. The
	/// application simply sets the needed socket options and provides the adequate buffer size.
	/// </para>
	/// <para>The members of the <c>WSACMSGHDR</c> structure are as follows:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Term</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>cmsg_len</term>
	/// <term>
	/// The number of bytes of data starting from the beginning of the WSACMSGHDR to the end of data (excluding padding bytes that may
	/// follow data).
	/// </term>
	/// </item>
	/// <item>
	/// <term>cmsg_level</term>
	/// <term>The protocol that originated the control information.</term>
	/// </item>
	/// <item>
	/// <term>cmsg_type</term>
	/// <term>The protocol-specific type of control information.</term>
	/// </item>
	/// </list>
	/// <para>The following macros are used to navigate the data objects:</para>
	/// <para>
	/// Returns a pointer to the first control data object. Returns a <c>NULL</c> pointer if there is no control data in the
	/// <c>WSAMSG</c> structure, such as when the <c>Control</c> member is a <c>NULL</c> pointer.
	/// </para>
	/// <para>
	/// Returns a pointer to the next control data object, or <c>NULL</c> if there are no more data objects. If the pcmsg parameter is
	/// <c>NULL</c>, a pointer to the first control data object is returned.
	/// </para>
	/// <para>
	/// Returns a pointer to the first byte of data (referred to as the <c>cmsg_data</c> member, though it is not defined in the structure).
	/// </para>
	/// <para>
	/// Returns the total size of a control data object, given the amount of data. Used to allocate the correct amount of buffer space.
	/// Includes alignment padding.
	/// </para>
	/// <para>Returns the value in <c>cmsg_len</c> given the amount of data. Includes alignment padding.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2def/ns-ws2def-wsamsg typedef struct _WSAMSG { LPSOCKADDR name; INT namelen;
	// LPWSABUF lpBuffers; #if ... ULONG dwBufferCount; #else DWORD dwBufferCount; #endif WSABUF Control; #if ... ULONG dwFlags; #else
	// DWORD dwFlags; #endif } WSAMSG, *PWSAMSG, *LPWSAMSG;
	[PInvokeData("ws2def.h", MSDNShortId = "105a6e2c-1edf-4ec0-a1c2-ac0bcafeda30")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSAMSG
	{
		/// <summary>
		/// <para>Type: <c>LPSOCKADDR</c></para>
		/// <para>
		/// A pointer to a SOCKET_ADDRESS structure that stores information about the remote address. Used only with unconnected sockets.
		/// </para>
		/// </summary>
		public IntPtr name;

		/// <summary>
		/// <para>Type: <c>INT</c></para>
		/// <para>
		/// The length, in bytes, of the SOCKET_ADDRESS structure pointed to in the <c>pAddr</c> member. Used only with unconnected sockets.
		/// </para>
		/// </summary>
		public int namelen;

		/// <summary>
		/// <para>Type: <c>LPWSABUF</c></para>
		/// <para>
		/// An array of WSABUF structures used to receive the message data. The capability of the <c>lpBuffers</c> member to contain
		/// multiple buffers enables the use of scatter/gather I/O.
		/// </para>
		/// </summary>
		public IntPtr lpBuffers;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of buffers pointed to in the <c>lpBuffers</c> member.</para>
		/// </summary>
		public uint dwBufferCount;

		/// <summary>
		/// <para>Type: <c>WSABUF</c></para>
		/// <para>A structure of WSABUF type used to specify optional control data. See Remarks.</para>
		/// </summary>
		public WSABUF Control;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// One or more control flags, specified as the logical <c>OR</c> of values. The possible values for <c>dwFlags</c> member on
		/// input are defined in the Winsock2.h header file. The possible values for <c>dwFlags</c> member on output are defined in the
		/// Ws2def.h header file which is automatically included by the Winsock2.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flags on input</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_PEEK</term>
		/// <term>
		/// Peek at the incoming data. The data is copied into the buffer, but is not removed from the input queue. This flag is valid
		/// only for non-overlapped sockets.
		/// </term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag returned</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_BCAST</term>
		/// <term>The datagram was received as a link-layer broadcast or with a destination IP address that is a broadcast address.</term>
		/// </item>
		/// <item>
		/// <term>MSG_MCAST</term>
		/// <term>The datagram was received with a destination IP address that is a multicast address.</term>
		/// </item>
		/// <item>
		/// <term>MSG_TRUNC</term>
		/// <term>The datagram was truncated. More data was present than the process allocated room for.</term>
		/// </item>
		/// <item>
		/// <term>MSG_CTRUNC</term>
		/// <term>The control (ancillary) data was truncated. More control data was present than the process allocated room for.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MsgFlags dwFlags;
	}

	/// <summary>
	/// <para>
	/// Some of the socket IOCTL opcodes for Windows Sockets 2 are summarized in the following table. More detailed information is in
	/// the Winsock reference on <c>Winsock IOCTLs</c> and the <c>WSPIoctl</c> function. There are other new protocol-specific IOCTL
	/// opcodes that can be found in the protocol-specific annex.
	/// </para>
	/// <para>A complete list of <c>Winsock IOCTLs</c> are available in the Winsock reference.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/winsock/summary-of-socket-ioctl-opcodes-2
	[PInvokeData("ws2def.h", MSDNShortId = "fb6447b4-28f5-4ab7-bbdc-5a57ed38a994")]
	public static class WinSockIOControlCode
	{
		/// <summary>
		/// Determine the amount of data that can be read atomically from socket s. The lpvOutBuffer parameter points at an unsigned long
		/// in which WSAIoctl stores the result.
		/// <para>
		/// If the socket passed in the s parameter is stream oriented(for example, type SOCK_STREAM), FIONREAD returns the total amount
		/// of data that can be read in a single receive operation; this is normally the same as the total amount of data queued on the
		/// socket(since a data stream is byte-oriented, this is not guaranteed).
		/// </para>
		/// <para>
		/// If the socket passed in the s parameter is message oriented(for example, type SOCK_DGRAM), FIONREAD returns the reports the
		/// total number of bytes available to read, not the size of the first datagram(message) queued on the socket.
		/// </para>
		/// </summary>
		public static readonly uint FIONREAD = _IOR('f', 127); /* get # bytes to read */

		/// <summary>
		/// Enable or disable non-blocking mode on socket s. The lpvInBuffer parameter points at an unsigned long (QoS), which is nonzero
		/// if non-blocking mode is to be enabled and zero if it is to be disabled. When a socket is created, it operates in blocking
		/// mode (that is, non-blocking mode is disabled). This is consistent with BSD sockets.
		/// <para>
		/// The WSAAsyncSelect or WSAEventSelect routine automatically sets a socket to non-blocking mode.If WSAAsyncSelect or
		/// WSAEventSelect has been issued on a socket, then any attempt to use WSAIoctl to set the socket back to blocking mode will
		/// fail with WSAEINVAL. To set the socket back to blocking mode, an application must first disable WSAAsyncSelect by calling
		/// WSAAsyncSelect with the lEvent parameter equal to zero, or disable WSAEventSelect by calling WSAEventSelect with the
		/// lNetworkEvents parameter equal to zero.
		/// </para>
		/// </summary>
		public static readonly uint FIONBIO = _IOW('f', 126); /* set/clear non-blocking i/o */

		/// <summary>Enable notification for when data is waiting to be received.</summary>
		public static readonly uint FIOASYNC = _IOW('f', 125); /* set/clear async i/o */

		/// <summary>Requests notification of changes in information reported through SIO_ADDRESS_LIST_QUERY</summary>
		public static readonly uint SIO_ADDRESS_LIST_CHANGE = _WSAIO(IOC_WS2, 23);

		/// <summary>
		/// Obtains a list of local transport addresses of the socket's protocol family to which the application can bind. The list of
		/// addresses varies based on address family and some addresses are excluded from the list.
		/// </summary>
		[CorrespondingType(typeof(SOCKET_ADDRESS), CorrespondingAction.Get)]
		public static readonly uint SIO_ADDRESS_LIST_QUERY = _WSAIOR(IOC_WS2, 22);

		/// <summary>
		/// Allows application developers to sort a list of IPv6 and IPv4 destination addresses to determine the best available address
		/// for making a connection.
		/// </summary>
		[CorrespondingType(typeof(SOCKET_ADDRESS_LIST), CorrespondingAction.GetSet)]
		public static readonly uint SIO_ADDRESS_LIST_SORT = _WSAIORW(IOC_WS2, 25);

		/// <summary>Associates the socket with the specified handle of a companion interface.</summary>
		public static readonly uint SIO_ASSOCIATE_HANDLE = _WSAIOW(IOC_WS2, 1);

		/// <summary>Enables circular queuing.</summary>
		public static readonly uint SIO_ENABLE_CIRCULAR_QUEUEING = _WSAIO(IOC_WS2, 2);

		/// <summary>Requests the route to the specified address to be discovered.</summary>
		[CorrespondingType(typeof(SOCKADDR), CorrespondingAction.Set)]
		public static readonly uint SIO_FIND_ROUTE = _WSAIOR(IOC_WS2, 3);

		/// <summary>Discards current contents of the sending queue.</summary>
		public static readonly uint SIO_FLUSH = _WSAIO(IOC_WS2, 4);

		/// <summary>Retrieves the protocol-specific broadcast address to be used in WSPSendTo.</summary>
		[CorrespondingType(typeof(SOCKADDR), CorrespondingAction.Get)]
		public static readonly uint SIO_GET_BROADCAST_ADDRESS = _WSAIOR(IOC_WS2, 5);

		/// <summary>Gets the function pointer for the WSASendMsg function obtained at run time.</summary>
		public static readonly uint SIO_GET_EXTENSION_FUNCTION_POINTER = _WSAIORW(IOC_WS2, 6);

		/// <summary>Reserved.</summary>
		[CorrespondingType(typeof(QOS), CorrespondingAction.Get)]
		public static readonly uint SIO_GET_GROUP_QOS = _WSAIORW(IOC_WS2, 8);

		/// <summary>Retrieves current flow specifications for the socket.</summary>
		[CorrespondingType(typeof(QOS), CorrespondingAction.Get)]
		public static readonly uint SIO_GET_QOS = _WSAIORW(IOC_WS2, 7);

		/// <summary>Specifies the scope over which multicast transmissions will occur.</summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Set)]
		public static readonly uint SIO_MULTICAST_SCOPE = _WSAIOW(IOC_WS2, 10);

		/// <summary>Controls whether data sent in a multipoint session will also be received by the same socket on the local host.</summary>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
		public static readonly uint SIO_MULTIPOINT_LOOPBACK = _WSAIOW(IOC_WS2, 9);

		/// <summary>Queries the association between a socket and an RSS processor core and NUMA node.</summary>
		[CorrespondingType(typeof(SOCKET_PROCESSOR_AFFINITY), CorrespondingAction.Get)]
		public static readonly uint SIO_QUERY_RSS_PROCESSOR_INFO = _WSAIOR(IOC_WS2, 37);

		/// <summary>Obtains socket descriptor of the next provider in the chain on which current socket depends in regards to PnP.</summary>
		[CorrespondingType(typeof(SOCKET), CorrespondingAction.Get)]
		public static readonly uint SIO_QUERY_TARGET_PNP_HANDLE = _WSAIOR(IOC_WS2, 24);

		/// <summary>
		/// Requests notification of changes in information reported through SIO_ROUTING_INTERFACE_QUERY for the specified address.
		/// </summary>
		[CorrespondingType(typeof(SOCKADDR), CorrespondingAction.Set)]
		public static readonly uint SIO_ROUTING_INTERFACE_CHANGE = _WSAIOW(IOC_WS2, 21);

		/// <summary>Obtains the address of the local interface that should be used to send to the specified address.</summary>
		[CorrespondingType(typeof(SOCKADDR), CorrespondingAction.GetSet)]
		public static readonly uint SIO_ROUTING_INTERFACE_QUERY = _WSAIORW(IOC_WS2, 20);

		/// <summary>Reserved.</summary>
		[CorrespondingType(typeof(QOS), CorrespondingAction.Set)]
		public static readonly uint SIO_SET_GROUP_QOS = _WSAIOW(IOC_WS2, 12);

		/// <summary>Establishes new flow specifications for the socket.</summary>
		[CorrespondingType(typeof(QOS), CorrespondingAction.Set)]
		public static readonly uint SIO_SET_QOS = _WSAIOW(IOC_WS2, 11);

		/// <summary>Obtains a corresponding handle for socket s that is valid in the context of a companion interface.</summary>
		[CorrespondingType(typeof(int), CorrespondingAction.Set)]
		public static readonly uint SIO_TRANSLATE_HANDLE = _WSAIORW(IOC_WS2, 13);

		/// <summary>set high watermark</summary>
		public static readonly uint SIOCSHIWAT = _IOW('s', 0); /* set high watermark */

		/// <summary>get high watermark</summary>
		public static readonly uint SIOCGHIWAT = _IOR('s', 1); /* get high watermark */

		/// <summary>set low watermark</summary>
		public static readonly uint SIOCSLOWAT = _IOW('s', 2); /* set low watermark */

		/// <summary>get low watermark</summary>
		public static readonly uint SIOCGLOWAT = _IOR('s', 3); /* get low watermark */

		/// <summary>
		/// Determine whether or not all OOB data has been read. This applies only to a socket of stream-style (for example, type
		/// SOCK_STREAM) that has been configured for inline reception of any OOB data (SO_OOBINLINE). If no OOB data is waiting to be
		/// read, the operation returns TRUE. Otherwise, it returns FALSE, and the next receive operation performed on the socket will
		/// retrieve some or all of the data preceding the mark; the application should use the SIOCATMARK operation to determine whether
		/// any remains. If there is any normal data preceding the urgent (out of band) data, it will be received in order. (Note that
		/// recv operations will never mix OOB and normal data in the same call.) lpvOutBuffer points at a BOOL in which WSAIoctl stores
		/// the result.
		/// </summary>
		public static readonly uint SIOCATMARK = _IOR('s', 7); /* at oob mark? */

		private const uint IOCPARM_MASK = 0x7f;            /* parameters must be < 128 bytes */
		private const uint IOC_VOID = 0x20000000;      /* no parameters */
		private const uint IOC_OUT = 0x40000000;      /* copy out parameters */
		private const uint IOC_IN = 0x80000000;      /* copy in parameters */
		private const uint IOC_INOUT = IOC_IN|IOC_OUT;
		private const uint IOC_PROTOCOL = 0x10000000;
		private const uint IOC_UNIX = 0x00000000;
		private const uint IOC_VENDOR = 0x18000000;
		private const uint IOC_WS2 = 0x08000000;
		private const uint IOC_WSK = IOC_WS2 | 0x07000000;

		private static uint _IO(uint x, uint y) => (IOC_VOID|((x)<<8)|(y));

		private static uint _IOR(uint x, uint y) => (IOC_OUT|((sizeof(uint)&IOCPARM_MASK)<<16)|((x)<<8)|(y));

		private static uint _IOW(uint x, uint y) => (IOC_IN|((sizeof(uint)&IOCPARM_MASK)<<16)|((x)<<8)|(y));

		private static uint _WSAIO(uint x, uint y) => IOC_VOID | (x) | (y);

		private static uint _WSAIOR(uint x, uint y) => IOC_OUT | (x) | (y);

		private static uint _WSAIORW(uint x, uint y) => IOC_INOUT | (x) | (y);

		private static uint _WSAIOW(uint x, uint y) => IOC_IN | (x) | (y);
	}
}