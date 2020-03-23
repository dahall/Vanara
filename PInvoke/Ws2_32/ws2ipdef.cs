using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

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
	}
}