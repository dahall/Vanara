using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

#pragma warning disable IDE1006 // Naming Styles
namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
		/// <summary/>
		public const uint IOC_IN = 0x80000000;

		/// <summary/>
		public const uint IOC_INOUT = IOC_IN | IOC_OUT;

		/// <summary/>
		public const uint IOC_OUT = 0x40000000;

		/// <summary/>
		public const uint IOC_VOID = 0x20000000;

		/// <summary/>
		public const uint IOCPARM_MASK = 0x7f;

		/// <summary>
		/// It is used to return information about each interface on the local machine. Nothing is required on input, but on output, an array of INTERFACE_INFO structures is returned.
		/// </summary>
		public static readonly uint SIO_GET_INTERFACE_LIST = _IOR('t', 127, typeof(uint));

		/// <summary>
		/// This ioctl is the same as SIO_GET_INTERFACE_LIST except the structure returned contains embedded SOCKET_ADDRESS structure to describe each local interface, as opposed to SOCKADDR_GEN structure. This removes the dependency the size of the socket address structure.
		/// </summary>
		public static readonly uint SIO_GET_INTERFACE_LIST_EX = _IOR('t', 126, typeof(uint));

		/// <summary>
		/// This ioctl retrieves the multicast filter set on a given socket. The multicast state is set with the SIO_SET_MULTICAST_FILTER ioctl. This ioctl requires an IGMPv3-enabled network and is supported in only Windows XP.
		/// </summary>
		public static readonly uint SIO_GET_MULTICAST_FILTER = _IOW('t', 124 | IOC_IN, typeof(uint));

		/// <summary>
		/// This ioctl sets the multicast state. The input parameter is a struct ip_msfilter.
		/// </summary>
		public static readonly uint SIO_SET_MULTICAST_FILTER = _IOW('t', 125, typeof(uint));

		/// <summary>
		/// This ioctl retrieves the multicast filter set on a given socket. The multicast state is set with the SIO_SET_MULTICAST_FILTER ioctl. This ioctl requires an IGMPv3-enabled network and is supported in only Windows XP.
		/// </summary>
		public static readonly uint SIOCGIPMSFILTER = SIO_GET_MULTICAST_FILTER;

		/// <summary>
		/// Enables an application to retrieve a list of the IPv4 or IPv6 source addresses that comprise the source filter along with the current mode on a given interface index and a multicast group for a socket. The source filter may either include or exclude the set of source address, depending on the filter mode (MCAST_INCLUDE or MCAST_EXCLUDE), which is defined in the GROUP_FILTER structure.
		/// </summary>
		public static readonly uint SIOCGMSFILTER = _IOW('t', 127 | IOC_IN, typeof(uint));

		/// <summary>
		/// This ioctl sets the multicast state. The input parameter is a struct ip_msfilter.
		/// </summary>
		public static readonly uint SIOCSIPMSFILTER = SIO_SET_MULTICAST_FILTER;

		/// <summary>
		/// Enables an application to specify or modify a list of IPv4 or IPv6 source addresses on a given interface index and to specify or modify a multicast group for a socket. The source filter can include or exclude the set of source address, depending on the filter mode (MCAST_INCLUDE or MCAST_EXCLUDE), which is defined in the GROUP_FILTER structure of the BPXYIOCC macro. The application can join multiple source multicast groups on a single socket; it also can join the same group on multiple interfaces on the same socket. However, there is a maximum limit of 20 groups per single UDP socket and there is a maximum limit of 256 groups per single RAW socket.
		/// </summary>
		public static readonly uint SIOCSMSFILTER = _IOW('t', 126, typeof(uint));

		/// <summary>The <c>MULTICAST_MODE_TYPE</c> enumeration specifies the filter mode for multicast group addresses.</summary>
		/// <remarks>
		/// <para>This enumeration is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>MULTICAST_MODE_TYPE</c> enumeration is used in the <c>gf_fmode</c> member of the GROUP_SOURCE_REQ structure to determine
		/// if a list of IP addresses should included or excluded. The values from this enumeration can also be used in the
		/// <c>imsf_fmode</c> member of the ip_msfilter structure.
		/// </para>
		/// <para>
		/// The <c>MULTICAST_MODE_TYPE</c> enumeration is defined in the Ws2ipdef.h header file which is automatically included in the
		/// Ws2tcpip.h header file. The Ws2ipdef.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ne-ws2ipdef-multicast_mode_type typedef enum { MCAST_INCLUDE,
		// MCAST_EXCLUDE } MULTICAST_MODE_TYPE;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "7ca9cb9b-618a-4e73-9e2a-18e55e5c00c0")]
		public enum MULTICAST_MODE_TYPE
		{
			/// <summary>The filter contains a list of IP addresses to include.</summary>
			MCAST_INCLUDE,

			/// <summary>The filter contains a list of IP addresses to exclude.</summary>
			MCAST_EXCLUDE,
		}

		/// <summary>
		/// Used for an ioctl that reads data from the device driver. The driver will be allowed to return sizeof(data_type) bytes to the user.
		/// </summary>
		/// <param name="x">The type.</param>
		/// <param name="y">The value.</param>
		/// <param name="t">The type from which a size is extracted.</param>
		/// <returns>IOCtrl value.</returns>
		public static uint _IOR(char x, uint y, Type t) => IOC_OUT | (((uint)Marshal.SizeOf(t) & IOCPARM_MASK) << 16) | ((uint)x) << 8 | (y);

		/// <summary>Used for an ioctl that writes data to the device driver.</summary>
		/// <param name="x">The type.</param>
		/// <param name="y">The value.</param>
		/// <param name="t">The type from which a size is extracted.</param>
		/// <returns>IOCtrl value.</returns>
		public static uint _IOW(char x, uint y, Type t) => IOC_IN | (((uint)Marshal.SizeOf(t) & IOCPARM_MASK) << 16) | ((uint)x) << 8 | (y);

		/// <summary>Gets the size, in bytes, of an GROUP_FILTER with a number of SOCKADDR_STORAGE items.</summary>
		/// <param name="numsrc">The number of SOCKADDR_STORAGE sources.</param>
		/// <returns>Size, in bytes.</returns>
		[PInvokeData("ws2ipdef.h")]
		public static int GROUP_FILTER_SIZE(int numsrc) => Marshal.SizeOf(typeof(GROUP_FILTER)) - Marshal.SizeOf(typeof(SOCKADDR_STORAGE)) + numsrc * Marshal.SizeOf(typeof(SOCKADDR_STORAGE));

		/// <summary>Gets the size, in bytes, of an IP_MSFILTER with a number of IN_ADDR items.</summary>
		/// <param name="NumSources">The number of IN_ADDR sources.</param>
		/// <returns>Size, in bytes.</returns>
		[PInvokeData("ws2ipdef.h")]
		public static int IP_MSFILTER_SIZE(int NumSources) => Marshal.SizeOf(typeof(IP_MSFILTER)) - Marshal.SizeOf(typeof(IN_ADDR)) + NumSources * Marshal.SizeOf(typeof(IN_ADDR));

		/// <summary>The <c>GROUP_FILTER</c> structure provides multicast filtering parameters for multicast IPv6 or IPv4 addresses.</summary>
		/// <remarks>
		/// <para>
		/// The <c>GROUP_FILTER</c> structure is used with either IPv6 or IPv4 multicast addresses. The <c>GROUP_FILTER</c> structure is
		/// passed as an argument for the <c>SIOCGMSFILTER</c> and <c>SIOCSMSFILTER</c> IOCTLs.
		/// </para>
		/// <para>
		/// The <c>GROUP_FILTER</c> structure and related structures used for multicast programming are based on IETF recommendations in
		/// sections 5 and 8.2 of RFC 3768. For more information, see http://www.ietf.org/rfc/rfc3678.txt.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a set of socket options are available for multicast programming that support IPv6 and IPv4
		/// addresses. These socket options are IP agnostic and can be used on both IPv6 and IPv4. These IP agnostic options use the
		/// GROUP_REQ and the GROUP_SOURCE_REQ structures and are the preferred socket options for multicast programming on Windows Vista
		/// and later.
		/// </para>
		/// <para>The GetAdaptersAddresses function can be used to obtain interface index information required for the gf_interface member.</para>
		/// <para>
		/// The <c>GROUP_FILTER</c> structure and the Ioctls that use this structure are only valid on datagram and raw sockets (the socket
		/// type must be <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>).
		/// </para>
		/// <para>
		/// The <c>GROUP_FILTER</c> structure is defined in the Ws2ipdef.h header file which is automatically included in the Ws2tcpip.h
		/// header file. The Ws2ipdef.h header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-group_filter typedef struct group_filter { ULONG
		// gf_interface; SOCKADDR_STORAGE gf_group; MULTICAST_MODE_TYPE gf_fmode; ULONG gf_numsrc; SOCKADDR_STORAGE gf_slist[1]; }
		// GROUP_FILTER, *PGROUP_FILTER;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "09aa1f67-c858-4bef-9a98-ce25ebcc1d4e")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IP_MSFILTER>), "gf_numsrc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct GROUP_FILTER
		{
			/// <summary>The interface index of the local interface for the multicast group to filter.</summary>
			public uint gf_interface;

			/// <summary>The multicast address group that should be filtered. This may be either an IPv6 or IPv4 multicast address.</summary>
			public SOCKADDR_STORAGE gf_group;

			/// <summary>
			/// <para>The multicast filter mode.</para>
			/// <para>
			/// This member can be one of the values from the MULTICAST_MODE_TYPE enumeration type defined in the Ws2ipdef.h header file.
			/// This member determines if the list of IP addresses in the <c>gf_numsrc</c> member should be included or excluded.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>MCAST_INCLUDE</term>
			/// <term>The filter contains a list of IP addresses to include.</term>
			/// </item>
			/// <item>
			/// <term>MCAST_EXCLUDE</term>
			/// <term>The filter contains a list of IP addresses to exclude.</term>
			/// </item>
			/// </list>
			/// </summary>
			public MULTICAST_MODE_TYPE gf_fmode;

			/// <summary>The number of multicast filter source address entries in the <c>gf_slist</c> member.</summary>
			public uint gf_numsrc;

			/// <summary>
			/// An array of SOCKADDR_STORAGE structures specifying the multicast source addresses to include or exclude. These IP addresses
			/// may be either IPv6 or IPv4 addresses, but they must be the same address family (IPv6 or IPv4) as the address specified in
			/// the <c>gf_group</c> member..
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public SOCKADDR_STORAGE[] gf_slist;
		}

		/// <summary>
		/// The <c>in_pktinfo</c> structure is used to store received packet address information, and is used by Windows to return
		/// information about received packets and also allows specifying the local IPv4 address to use for sending packets.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IP_PKTINFO socket option is set on a socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, one of the control data objects
		/// returned by the LPFN_WSARECVMSG (WSARecvMsg) function will contain an <c>in_pktinfo</c> structure used to store received packet
		/// address information.
		/// </para>
		/// <para>
		/// On an IPv4 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, an application can specific the local IP address to use for
		/// sending with the WSASendMsg function. One of the control data objects passed in the WSAMSG structure to the <c>WSASendMsg</c>
		/// function may contain an <c>in_pktinfo</c> structure used to specify the local IPv4 address to use for sending.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>in_pktinfo</c> structure is defined in the <c>Ws2ipdef.h</c> header file which is automatically included
		/// in the <c>Ws2tcpip.h</c> header file. The <c>Ws2ipdef.h</c> header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-in_pktinfo typedef struct in_pktinfo { IN_ADDR ipi_addr;
		// ULONG ipi_ifindex; } IN_PKTINFO, *PIN_PKTINFO;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "NS:ws2ipdef.in_pktinfo")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IN_PKTINFO
		{
			/// <summary>
			/// The destination IPv4 address from the IP header of the received packet when used with the LPFN_WSARECVMSG (WSARecvMsg)
			/// function. The local source IPv4 address to set in the IP header when used with the WSASendMsg function.
			/// </summary>
			public IN_ADDR ipi_addr;

			/// <summary>
			/// The interface on which the packet was received when used with the LPFN_WSARECVMSG (WSARecvMsg) function. The interface on
			/// which the packet should be sent when used with the WSASendMsg function.
			/// </summary>
			public uint ipi_ifindex;
		}

		/// <summary>
		/// The <c>in6_pktinfo</c> structure is used to store received IPv6 packet address information, and is used by Windows to return
		/// information about received packets and also allows specifying the local IPv6 address to use for sending packets.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the IPV6_PKTINFO socket option is set on a socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, one of the control data
		/// objects returned by the LPFN_WSARECVMSG (WSARecvMsg) function will contain an <c>in6_pktinfo</c> structure used to store received
		/// packet address information.
		/// </para>
		/// <para>
		/// On an IPv6 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, an application can specific the local IP source address to use
		/// for sending with the WSASendMsg function. One of the control data objects passed in the WSAMSG structure to the <c>WSASendMsg</c>
		/// function may contain an <c>in6_pktinfo</c> structure used to specify the local IPv6 address to use for sending.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>in6_pktinfo</c> structure is defined in the <c>Ws2ipdef.h</c> header file which is automatically included
		/// in the <c>Ws2tcpip.h</c> header file. The <c>Ws2ipdef.h</c> header files should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-in6_pktinfo typedef struct in6_pktinfo { IN6_ADDR
		// ipi6_addr; ULONG ipi6_ifindex; } IN6_PKTINFO, *PIN6_PKTINFO;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "NS:ws2ipdef.in6_pktinfo")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IN6_PKTINFO
		{
			/// <summary>
			/// The destination IPv6 address from the IP header of the received packet when used with the LPFN_WSARECVMSG (WSARecvMsg)
			/// function. The local source IPv6 address to set in the IP header when used with the WSASendMsg function.
			/// </summary>
			public IN6_ADDR ipi6_addr;

			/// <summary>
			/// The interface on which the packet was received when used with the LPFN_WSARECVMSG (WSARecvMsg) function. The interface on
			/// which the packet should be sent when used with the WSASendMsg function.
			/// </summary>
			public uint ipi6_ifindex;
		}

		/// <summary>The <c>ip_mreq</c> structure provides multicast group information for IPv4 addresses.</summary>
		/// <remarks>
		/// <para>
		/// The <c>ip_mreq</c> structure is used with IPv4 addresses. The <c>ip_mreq</c> structure is used with the IP_ADD_MEMBERSHIP and
		/// <c>IP_DROP_MEMBERSHIP</c> socket options.
		/// </para>
		/// <para>
		/// The <c>ip_mreq</c> structure and related structures used for IPv4 multicast programming are based on IETF recommendations in
		/// sections 4 and 8.1 of RFC 3768. For more information, see http://www.ietf.org/rfc/rfc3678.txt.
		/// </para>
		/// <para>
		/// For more configurable multicast capabilities with IPv4, use the ip_mreq_source structure. See Multicast Programming for more information.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a set of socket options are available for multicast programming that support IPv6 and IPv4 addresses.
		/// These socket options are IP agnostic and can be used on both IPv6 and IPv4. These IP agnostic options use the GROUP_REQ and the
		/// GROUP_SOURCE_REQ structures and are the preferred socket options for multicast programming on Windows Vista and later.
		/// </para>
		/// <para>The <c>ip_mreq</c> structure is the IPv4 equivalent of the IPv6-based ipv6_mreq structure.</para>
		/// <para>
		/// The <c>imr_interface</c> member can be an interface index. Any IP address in the 0.x.x.x block (first octet of 0) except for the
		/// IP address of 0.0.0.0 is treated as an interface index. An interface index is a 24-bit number. The 0.0.0.0/8 IPv4 address block
		/// is not used (this range is reserved). The GetAdaptersAddresses function can be used to obtain interface index information to use
		/// for the <c>imr_interface</c> member.
		/// </para>
		/// <para>
		/// It is recommended that a local IPv4 address or interface index always be specified in the <c>imr_interface</c> member of the
		/// <c>ip_mreq</c> structure, rather than use the default interface. This is particularly important on computers with multiple
		/// network interfaces and multiple public IPv4 addresses.
		/// </para>
		/// <para>
		/// The default interface used for IPv4 multicast is determined by the networking stack in Windows. An application can determine the
		/// default interface used for IPv4 multicast using the GetIpForwardTable function to retrieve the IPv4 routing table. The network
		/// interface with the lowest value for the routing metric for a destination IP address of 224.0.0.0 is the default interface for
		/// IPv4 multicast. The routing table can also be displayed from the command prompt with the following command:
		/// </para>
		/// <para><c>route print</c></para>
		/// <para>
		/// The IP_MULTICAST_IF socket option can be used to set the default interface to send IPv4 multicast packets. This socket option
		/// does not change the default interface used to receive IPv4 multicast packets.
		/// </para>
		/// <para>
		/// A typical IPv4 multicast application would use the IP_ADD_MEMBERSHIP socket option with the <c>ip_mreq</c> structure to join a
		/// multicast group and listen for multicast packets on a specific interface. The <c>IP_MULTICAST_IF</c> socket option would be used
		/// to set the interface to send IPv4 multicast packets to the multicast group. The most common scenario would be a multicast
		/// application that listens and sends on the same interface for a multicast group. Multiple sockets might be used by a multicast
		/// application with one socket for listening and one or more sockets for sending.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>ip_mreq</c> structure is defined in the <c>Ws2ipdef.h</c> header file which is automatically included in
		/// the <c>Ws2tcpip.h</c> header file. The <c>Ws2ipdef.h</c> header files should never be used directly.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>IP_MREQ</c> and <c>PIP_MREQ</c> derived structures are only defined on the Windows SDK released with Windows
		/// Vista and later. The <c>ip_mreq</c> structure should be used on earlier versions of the Windows SDK.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-ip_mreq typedef struct ip_mreq { IN_ADDR imr_multiaddr;
		// IN_ADDR imr_interface; } IP_MREQ, *PIP_MREQ;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "NS:ws2ipdef.ip_mreq")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_MREQ
		{
			/// <summary>The address of the IPv4 multicast group.</summary>
			public IN_ADDR imr_multiaddr;

			/// <summary>
			/// <para>
			/// The local IPv4 address of the interface or the interface index on which the multicast group should be joined or dropped. This
			/// value is in network byte order. If this member specifies an IPv4 address of 0.0.0.0, the default IPv4 multicast interface is used.
			/// </para>
			/// <para>To use an interface index of 1 would be the same as an IP address of 0.0.0.1.</para>
			/// </summary>
			public IN_ADDR imr_interface;
		}

		/// <summary>The <c>ip_msfilter</c> structure provides multicast filtering parameters for IPv4 addresses.</summary>
		/// <remarks>
		/// <para>
		/// The <c>ip_msfilter</c> structure is used with IPv4 addresses. The <c>ip_msfilter</c> structure is passed as an argument for the
		/// <c>SIO_GET_MULTICAST_FILTER</c> and <c>SIO_SET_MULTICAST_FILTER</c> IOCTLs.
		/// </para>
		/// <para>
		/// The <c>ip_msfilter</c> structure and related structures used for IPv4 multicast programming are based on IETF recommendations in
		/// sections 4 and 8.1 of RFC 3768. For more information, see http://www.ietf.org/rfc/rfc3678.txt.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a set of socket options are available for multicast programming that support IPv6 and IPv4
		/// addresses. These socket options are IP agnostic and can be used on both IPv6 and IPv4. These IP agnostic options use the
		/// GROUP_REQ and the GROUP_SOURCE_REQ structures and the <c>SIOCSMSFILTER</c> and <c>SIOCGMSFILTER</c> IOCTLs. These are the
		/// preferred socket options and IOCTLs for multicast programming on Windows Vista and later.
		/// </para>
		/// <para>
		/// The <c>imsf_interface</c> member can be an interface index. Any IPv4 address in the 0.x.x.x block (first octet of 0) except for
		/// the IPv4 address of 0.0.0.0 is treated as an interface index. An interface index is a 24-bit number. The 0.0.0.0/8 IPv4 address
		/// block is not used (this range is reserved). The GetAdaptersAddresses function can be used to obtain interface index information
		/// to use for the <c>imsf_interface</c> member.
		/// </para>
		/// <para>
		/// It is recommended that a local IPv4 address or interface index always be specified in the <c>imsf_interface</c> member of the
		/// <c>ip_msfilter</c> structure, rather than use the default interface. This is particularly important on computers with multiple
		/// network interfaces and multiple public IPv4 addresses.
		/// </para>
		/// <para>
		/// The default interface used for IPv4 multicast is determined by the networking stack in Windows. An application can determine the
		/// default interface used for IPv4 multicast using the GetIpForwardTable function to retrieve the IPv4 routing table. The network
		/// interface with the lowest value for the routing metric for a destination IP address of 224.0.0.0 is the default interface for
		/// IPv4 multicast. The routing table can also be displayed from the command prompt with the following command:
		/// </para>
		/// <para><c>route print</c></para>
		/// <para>
		/// The IP_MULTICAST_IF socket option can be used to set the default interface to send IPv4 multicast packets. This socket option
		/// does not change the default interface used to receive IPv4 multicast packets.
		/// </para>
		/// <para>
		/// A typical IPv4 multicast application would use the IP_ADD_MEMBERSHIP socket option with the ip_mreq structure or the
		/// <c>IP_ADD_SOURCE_MEMBERSHIP</c> socket option with the ip_mreq_source structure to join a multicast group and listen for
		/// multicast packets on a specific interface. The <c>IP_MULTICAST_IF</c> socket option would be used to set the interface to send
		/// IPv4 multicast packets to the multicast group. The most common scenario would be a multicast application that listens and sends
		/// on the same interface for a multicast group. Multiple sockets might be used by a multicast application with one socket for
		/// listening and one or more sockets for sending.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>ip_msfilter</c> structure is defined in the Ws2ipdef.h header file which is automatically included in the
		/// Ws2tcpip.h header file. The Ws2ipdef.h header files should never be used directly.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>IP_MSFILTER</c> and <c>PIP_MSFILTER</c> derived structures are only defined on the Windows SDK released with
		/// Windows Vista and later. The <c>ip_msfilter</c> structure should be used on earlier versions of the Windows SDK.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-ip_msfilter typedef struct ip_msfilter { IN_ADDR
		// imsf_multiaddr; IN_ADDR imsf_interface; MULTICAST_MODE_TYPE imsf_fmode; ULONG imsf_numsrc; IN_ADDR imsf_slist[1]; } IP_MSFILTER, *PIP_MSFILTER;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "8d9d515e-9369-4d71-9614-6cbeb5557a5d")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<IP_MSFILTER>), "imsf_numsrc")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IP_MSFILTER
		{
			/// <summary>The IPv4 address of the multicast group.</summary>
			public IN_ADDR imsf_multiaddr;

			/// <summary>
			/// <para>
			/// The local IPv4 address of the interface or the interface index on which the multicast group should be filtered. This value
			/// is in network byte order. If this member specifies an IPv4 address of 0.0.0.0, the default IPv4 multicast interface is used.
			/// </para>
			/// <para>To use an interface index of 1 would be the same as an IP address of 0.0.0.1.</para>
			/// </summary>
			public IN_ADDR imsf_interface;

			/// <summary>
			/// <para>
			/// The multicast filter mode to be used. This parameter can be either MCAST_INCLUDE (value of 0) to include particular
			/// multicast sources, or MCAST_EXCLUDE (value of 1) to exclude traffic from specified sources.
			/// </para>
			/// <para>On Windows Server 2003 and Windows XP, these values are defined in the Ws2tcpip.h header file.</para>
			/// <para>
			/// On Windows Vistaand later, these values are defined as enumeration values in the MULTICAST_MODE_TYPE enumeration defined in
			/// the Ws2ipdef.h header file.
			/// </para>
			/// </summary>
			public MULTICAST_MODE_TYPE imsf_fmode;

			/// <summary>The number of sources in the <c>imsf_slist</c> member.</summary>
			public uint imsf_numsrc;

			/// <summary>An array of in_addr structures that specify the IPv4 multicast source addresses to include or exclude.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public IN_ADDR[] imsf_slist;
		}

		/// <summary>The <c>ipv6_mreq</c> structure provides multicast group information for IPv6 addresses.</summary>
		/// <remarks>
		/// <para>
		/// The <c>ipv6_mreq</c> structure is used with IPv6 addresses. The <c>ipv6_mreq</c> structure is used with the IPV6_ADD_MEMBERSHIP,
		/// <c>IPV6_DROP_MEMBERSHIP</c>, <c>IPV6_JOIN_GROUP</c>, and <c>IPV6_LEAVE_GROUP</c> socket options. The <c>IPV6_JOIN_GROUP</c> and
		/// <c>IPV6_ADD_MEMBERSHIP</c> socket options are defined to be the same. The <c>IPV6_LEAVE_GROUP</c> and <c>IPV6_DROP_MEMBERSHIP</c>
		/// socket options are defined to be the same.
		/// </para>
		/// <para>
		/// On Windows Vista and later, a set of socket options are available for multicast programming that support IPv6 and IPv4 addresses.
		/// These socket options are IP agnostic and can be used on both IPv6 and IPv4. These IP agnostic options use the GROUP_REQ and the
		/// GROUP_SOURCE_REQ structures and are the preferred socket options for multicast programming on Windows Vista and later.
		/// </para>
		/// <para>The <c>ipv6_mreq</c> structure is the IPv6 equivalent of the IPv4-based ip_mreq structure.</para>
		/// <para>
		/// The GetAdaptersAddresses function can be used to obtain interface index information required for the <c>ipv6mr_interface</c> member.
		/// </para>
		/// <para>
		/// The <c>ipv6_mreq</c> structure and the <c>IPPROTO_IPV6</c> level socket options that use this structure are only valid on
		/// datagram and raw sockets (the socket type must be <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>).
		/// </para>
		/// <para>
		/// It is recommended that a local IPv6 interface index always be specified in the <c>ipv6mr_interface</c> member of the
		/// <c>ipv6_mreq</c> structure, rather than use the default interface. This is particularly important on computers with multiple
		/// network interfaces and multiple public IPv6 addresses.
		/// </para>
		/// <para>
		/// The default interface used for IPv6 multicast is determined by the networking stack in Windows. On Windows Vista and later, an
		/// application can determine the default interface used for IPv6 multicast using the GetIpForwardTable2 function to retrieve the
		/// IPv6 routing table. The network interface with the lowest value for the routing metric for a destination IPv6 multicast address
		/// (the FF00::/8 IPv6 address block) is the default interface for IPv6 multicast. The routing table can also be displayed from the
		/// command prompt with the following command:
		/// </para>
		/// <para><c>route print</c></para>
		/// <para>
		/// The IPV6_MULTICAST_IF socket option can be used to set the default interface to send IPv6 multicast packets. This socket option
		/// does not change the default interface used to receive IPv6 multicast packets.
		/// </para>
		/// <para>
		/// A typical IPv6 multicast application would use the IPV6_ADD_MEMBERSHIP or <c>IPV6_JOIN_GROUP</c> socket option with the
		/// <c>ipv6_mreq</c> structure to join a multicast group and listen for multicast packets on a specific interface. The
		/// <c>IPV6_MULTICAST_IF</c> socket option would be used to set the interface to send IPv6 multicast packets to the multicast group.
		/// The most common scenario would be a multicast application that listens and sends on the same interface for a multicast group.
		/// Multiple sockets might be used by a multicast application with one socket for listening and one or more sockets for sending.
		/// </para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>ipv6_mreq</c> structure is defined in the <c>Ws2ipdef.h</c> header file which is automatically included in
		/// the <c>Ws2tcpip.h</c> header file. The <c>Ws2ipdef.h</c> header files should never be used directly.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>PIP6_MREQ</c> derived structure is only defined on the Windows SDK released with Windows Vista and later. The
		/// GROUP_REQ and the GROUP_SOURCE_REQ structures and are the preferred socket options for multicast programming on Windows Vista and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-ipv6_mreq typedef struct ipv6_mreq { IN6_ADDR
		// ipv6mr_multiaddr; ULONG ipv6mr_interface; } IPV6_MREQ, *PIPV6_MREQ;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "NS:ws2ipdef.ipv6_mreq")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IPV6_MREQ
		{
			/// <summary>The address of the IPv6 multicast group.</summary>
			public IN6_ADDR ipv6mr_multiaddr;

			/// <summary>
			/// The interface index of the local interface on which the multicast group should be joined or dropped. If this member specifies
			/// an interface index of 0, the default multicast interface is used.
			/// </summary>
			public uint ipv6mr_interface;
		}

		/// <summary>The SOCKADDR_IN6 structure specifies a transport address and port for the AF_INET6 address family.</summary>
		/// <remarks>
		/// <para>
		/// All of the data in the SOCKADDR_IN6 structure, except for the address family, must be specified in network-byte-order (big-endian).
		/// </para>
		/// <para>
		/// The size of the SOCKADDR_IN6 structure is too large to fit in the memory space that is provided by a SOCKADDR structure. For a
		/// structure that is guaranteed to be large enough to contain a transport address for all possible address families, see SOCKADDR_STORAGEa&gt;.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-sockaddr_in6_lh typedef struct sockaddr_in6 {
		// ADDRESS_FAMILY sin6_family; USHORT sin6_port; ULONG sin6_flowinfo; IN6_ADDR sin6_addr; union { ULONG sin6_scope_id; SCOPE_ID
		// sin6_scope_struct; }; } SOCKADDR_IN6_LH, *PSOCKADDR_IN6_LH, *LPSOCKADDR_IN6_LH;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "ef2955d2-5dc1-420b-a9e0-32a584059d5a")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct SOCKADDR_IN6
		{
			/// <summary>The address family for the transport address. This member should always be set to AF_INET6.</summary>
			public ADDRESS_FAMILY sin6_family;

			/// <summary>A transport protocol port number.</summary>
			public ushort sin6_port;

			/// <summary>The IPv6 flow information.</summary>
			public uint sin6_flowinfo;

			/// <summary>An IN6_ADDR structure that contains an IPv6 transport address.</summary>
			public IN6_ADDR sin6_addr;

			/// <summary>A ULONG representation of the IPv6 scope identifier that is defined in the <c>sin6_scope_struct</c> member.</summary>
			public uint sin6_scope_id;

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR_IN6"/> struct.</summary>
			/// <param name="addr">A byte array that contains an IPv6 transport address.</param>
			/// <param name="scope_id">
			/// A ULONG representation of the IPv6 scope identifier that is defined in the <c>sin6_scope_struct</c> member.
			/// </param>
			/// <param name="port">A transport protocol port number.</param>
			public SOCKADDR_IN6(byte[] addr, uint scope_id, ushort port = 0) : this(new IN6_ADDR(addr), scope_id, port)
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR_IN6"/> struct.</summary>
			/// <param name="addr">An IN6_ADDR structure that contains an IPv6 transport address.</param>
			/// <param name="scope_id">
			/// A ULONG representation of the IPv6 scope identifier that is defined in the <c>sin6_scope_struct</c> member.
			/// </param>
			/// <param name="port">A transport protocol port number.</param>
			public SOCKADDR_IN6(IN6_ADDR addr, uint scope_id, ushort port = 0)
			{
				sin6_family = ADDRESS_FAMILY.AF_INET6;
				sin6_port = port;
				sin6_flowinfo = 0;
				sin6_addr = addr;
				sin6_scope_id = scope_id;
			}

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR_IN6"/> struct from a <see cref="SOCKADDR_IN"/>.</summary>
			/// <param name="v4">The IPv4 socket address.</param>
			public SOCKADDR_IN6(SOCKADDR_IN v4) : this(new IN6_ADDR(v4.sin_addr), 0, v4.sin_port) { }

			/// <summary>Performs an implicit conversion from <see cref="IN6_ADDR"/> to <see cref="SOCKADDR_IN6"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR_IN6"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR_IN6(IN6_ADDR addr) => new(addr, 0);

			/// <inheritdoc/>
			public override string ToString() => $"{sin6_addr}" + (sin6_scope_id == 0 ? "" : "%" + sin6_scope_id.ToString()) + $":{sin6_port}";
		}

		/// <summary>
		/// The <c>SOCKADDR_IN6_PAIR</c> structure contains pointers to a pair of IP addresses that represent a source and destination
		/// address pair.
		/// </summary>
		/// <remarks>
		/// <para>The <c>SOCKADDR_IN6_PAIR</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// Any IPv4 addresses in the <c>SOCKADDR_IN6_PAIR</c> structure must be represented in the IPv4-mapped IPv6 address format which
		/// enables an IPv6 only application to communicate with an IPv4 node. For more information on the IPv4-mapped IPv6 address format,
		/// see Dual-Stack Sockets.
		/// </para>
		/// <para>The <c>SOCKADDR_IN6_PAIR</c> structure is used by the CreateSortedAddressPairs function.</para>
		/// <para>Note that the Ws2ipdef.h header file is automatically included in Ws2tcpip.h header file, and should never be used directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2ipdef/ns-ws2ipdef-_sockaddr_in6_pair typedef struct _sockaddr_in6_pair {
		// PSOCKADDR_IN6 SourceAddress; PSOCKADDR_IN6 DestinationAddress; } SOCKADDR_IN6_PAIR, *PSOCKADDR_IN6_PAIR;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "0265f8e0-8b35-4d9d-bf22-e98e9ff36a17")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKADDR_IN6_PAIR
		{
			/// <summary>The source address</summary>
			private readonly IntPtr _SourceAddress;

			/// <summary>The destination address</summary>
			private readonly IntPtr _DestinationAddress;

			/// <summary>
			/// A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the
			/// IPv6 address, port, flow information, and zone ID are in network byte order.
			/// </summary>
			/// <value>The source address.</value>
			public SOCKADDR_IN6 SourceAddress => _SourceAddress.ToStructure<SOCKADDR_IN6>();

			/// <summary>
			/// A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the
			/// IPv6 address, port, flow information, and zone ID are in network byte order.
			/// </summary>
			/// <value>The destination address.</value>
			public SOCKADDR_IN6 DestinationAddress => _DestinationAddress.ToStructure<SOCKADDR_IN6>();

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR_IN6_PAIR"/> to <see cref="SOCKADDR_IN6_PAIR_NATIVE"/>.</summary>
			/// <param name="unmgd">The unmanaged value.</param>
			/// <returns>The resulting <see cref="SOCKADDR_IN6_PAIR_NATIVE"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR_IN6_PAIR_NATIVE(SOCKADDR_IN6_PAIR unmgd) =>
				new()
				{ SourceAddress = unmgd.SourceAddress, DestinationAddress = unmgd.DestinationAddress };

			/// <summary>Converts to string.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			/// <inheritdoc/>
			public override string ToString() => $"{SourceAddress} : {DestinationAddress}";
		}

		/// <summary>
		/// The <c>SOCKADDR_IN6_PAIR</c> structure contains pointers to a pair of IP addresses that represent a source and destination
		/// address pair.
		/// </summary>
		/// <remarks>
		/// <para>The <c>SOCKADDR_IN6_PAIR</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// Any IPv4 addresses in the <c>SOCKADDR_IN6_PAIR</c> structure must be represented in the IPv4-mapped IPv6 address format which
		/// enables an IPv6 only application to communicate with an IPv4 node. For more information on the IPv4-mapped IPv6 address format,
		/// see Dual-Stack Sockets.
		/// </para>
		/// <para>The <c>SOCKADDR_IN6_PAIR</c> structure is used by the CreateSortedAddressPairs function.</para>
		/// <para>Note that the Ws2ipdef.h header file is automatically included in Ws2tcpip.h header file, and should never be used directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2ipdef/ns-ws2ipdef-_sockaddr_in6_pair typedef struct _sockaddr_in6_pair {
		// PSOCKADDR_IN6 SourceAddress; PSOCKADDR_IN6 DestinationAddress; } SOCKADDR_IN6_PAIR, *PSOCKADDR_IN6_PAIR;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "0265f8e0-8b35-4d9d-bf22-e98e9ff36a17")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKADDR_IN6_PAIR_NATIVE
		{
			/// <summary>
			/// A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the
			/// IPv6 address, port, flow information, and zone ID are in network byte order.
			/// </summary>
			public SOCKADDR_IN6 SourceAddress;

			/// <summary>
			/// A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the
			/// IPv6 address, port, flow information, and zone ID are in network byte order.
			/// </summary>
			public SOCKADDR_IN6 DestinationAddress;

			/// <summary>Converts to string.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			/// <inheritdoc/>
			public override string ToString() => $"{SourceAddress} : {DestinationAddress}";
		}

		/// <summary>The <c>SOCKADDR_INET</c> union contains an IPv4, an IPv6 address, or an address family.</summary>
		/// <remarks>
		/// <para>The <c>SOCKADDR_INET</c> union is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>SOCKADDR_INET</c> union is a convenience structure for accessing an IPv4 address, an IPv6 address, or the IP address
		/// family without having to cast the sockaddr structure.
		/// </para>
		/// <para>The <c>SOCKADDR_INET</c> union is the data type of the <c>Prefix</c> member in the IP_ADDRESS_PREFIX structure</para>
		/// <para>Note that the Ws2ipdef.h header file is automatically included in Ws2tcpip.h header file, and should never be used directly.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2ipdef/ns-ws2ipdef-sockaddr_inet typedef union _SOCKADDR_INET { SOCKADDR_IN
		// Ipv4; SOCKADDR_IN6 Ipv6; ADDRESS_FAMILY si_family; } SOCKADDR_INET, *PSOCKADDR_INET;
		[PInvokeData("ws2ipdef.h", MSDNShortId = "7278dcb4-65c6-4aea-a474-cb7fae4d7672")]
		[StructLayout(LayoutKind.Explicit)]
		public struct SOCKADDR_INET : IEquatable<SOCKADDR_INET>, IEquatable<SOCKADDR_IN>, IEquatable<SOCKADDR_IN6>
		{
			/// <summary>
			/// An IPv4 address represented as a SOCKADDR_IN structure containing the address family and the IPv4 address. The address
			/// family is in host byte order and the IPv4 address is in network byte order.
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the SOCKADDR_IN
			/// structure is defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in
			/// Winsock2.h, and should never be used directly.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public SOCKADDR_IN Ipv4;

			/// <summary>
			/// An IPv6 address represented as a SOCKADDR_IN6 structure containing the address family and the IPv6 address. The address
			/// family is in host byte order and the IPv6 address is in network byte order.
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the SOCKADDR_IN6
			/// structure is defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in
			/// Winsock2.h, and should never be used directly.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public SOCKADDR_IN6 Ipv6;

			/// <summary>
			/// The address family.
			/// <para>
			/// Possible values for the address family are listed in the Ws2def.h header file. Note that the values for the AF_ address
			/// family and PF_ protocol family constants are identical (for example, AF_INET and PF_INET), so either constant can be
			/// used.The Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public ADDRESS_FAMILY si_family;

			/// <summary>Gets the size of the actual address (not necessarily the size of the structure).</summary>
			public int Size => si_family == ADDRESS_FAMILY.AF_INET ? Marshal.SizeOf(typeof(SOCKADDR_IN)) : Marshal.SizeOf(typeof(SOCKADDR_IN6));

			/// <summary>Specifies whether this instance is equal to the specified object.</summary>
			/// <param name="other">The object to test for equality.</param>
			/// <returns><see langword="true"/> if <paramref name="other"/> is equal to this instance.</returns>
			public bool Equals(SOCKADDR_INET other) => (si_family == ADDRESS_FAMILY.AF_INET && Ipv4.Equals(other.Ipv4)) || (si_family == ADDRESS_FAMILY.AF_INET6 && Ipv6.Equals(other.Ipv6));

			/// <summary>Specifies whether this instance is equal to the specified object.</summary>
			/// <param name="other">The object to test for equality.</param>
			/// <returns><see langword="true"/> if <paramref name="other"/> is equal to this instance.</returns>
			public bool Equals(SOCKADDR_IN other) => si_family == ADDRESS_FAMILY.AF_INET && Ipv4.Equals(other);

			/// <summary>Specifies whether this instance is equal to the specified object.</summary>
			/// <param name="other">The object to test for equality.</param>
			/// <returns><see langword="true"/> if <paramref name="other"/> is equal to this instance.</returns>
			public bool Equals(SOCKADDR_IN6 other) => si_family == ADDRESS_FAMILY.AF_INET6 && Ipv6.Equals(other);

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR_IN"/> to <see cref="SOCKADDR_INET"/>.</summary>
			/// <param name="address">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR_INET"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR_INET(SOCKADDR_IN address) => new() { Ipv4 = address };

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR_IN6"/> to <see cref="SOCKADDR_INET"/>.</summary>
			/// <param name="address">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR_INET"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR_INET(SOCKADDR_IN6 address) => new() { Ipv6 = address };

			/// <summary>Converts to string.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString()
			{
				var sb = new System.Text.StringBuilder($"{si_family}");
				if (si_family == ADDRESS_FAMILY.AF_INET)
					sb.Append(":").Append(Ipv4);
				else if (si_family == ADDRESS_FAMILY.AF_INET6)
					sb.Append(":").Append(Ipv6);
				return sb.ToString();
			}
		}
	}
}