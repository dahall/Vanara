using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
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
			public ADDRESS_FAMILY ai_family { get => (ADDRESS_FAMILY)_ai_family; set => _ai_family = (ushort)value; }

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
			public SOCKADDR addr => new SOCKADDR(ai_addr, false, ai_addrlen);

			/// <inheritdoc/>
			public override string ToString() => $"{ai_fqdn}::{ai_canonname}:{ai_flags},{ai_family},{ai_socktype},{ai_protocol},{addr}";
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
			public ADDRESS_FAMILY ai_family { get => (ADDRESS_FAMILY)_ai_family; set => _ai_family = (ushort)value; }

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
			public SOCKADDR addr => new SOCKADDR(ai_addr, false, ai_addrlen);

			/// <inheritdoc/>
			public override string ToString() => $"{ai_canonname}:{ai_flags},{ai_family},{ai_socktype},{ai_protocol},{addr}";
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
			public ADDRESS_FAMILY ai_family { get => (ADDRESS_FAMILY)_ai_family; set => _ai_family = (ushort)value; }

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
			public SOCKADDR addr => new SOCKADDR(ai_addr, false, ai_addrlen);

			/// <inheritdoc/>
			public override string ToString() => $"{ai_canonname}:{ai_flags},{ai_family},{ai_socktype},{ai_protocol},{addr}";
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
				get => BitHelper.GetBits(Value, 0, 28);
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
				get => (byte)BitHelper.GetBits(Value, 28, 4);
				set => BitHelper.SetBits(ref Value, 28, 4, value);
			}
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
		}
	}
}