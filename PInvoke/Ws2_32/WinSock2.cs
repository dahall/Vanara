using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
		public const int SOMAXCONN = 0x7fffffff;

		/// <summary>The application-specified callback function for <see cref="WSAAccept"/>.</summary>
		/// <param name="lpCallerId">
		/// A WSABUF structure that contains the address of the connecting entity, where its len parameter is the length of the buffer in
		/// bytes, and its buf parameter is a pointer to the buffer..
		/// </param>
		/// <param name="lpCallerData">
		/// A value parameter that contains any user data. The information in these parameters is sent along with the connection request. If
		/// no caller identification or caller data is available, the corresponding parameters will be NULL. Many network protocols do not
		/// support connect-time caller data. Most conventional network protocols can be expected to support caller identifier information at
		/// connection-request time. The buf portion of the WSABUF pointed to by lpCallerId points to a sockaddr. The sockaddr structure is
		/// interpreted according to its address family (typically by casting the sockaddr to some type specific to the address family).
		/// </param>
		/// <param name="lpSQOS">
		/// References the FLOWSPEC structures for socket s specified by the caller, one for each direction, followed by any additional
		/// provider-specific parameters. The sending or receiving flow specification values will be ignored as appropriate for any
		/// unidirectional sockets. A NULL value indicates that there is no caller-supplied quality of service and that no negotiation is
		/// possible. A non-NULL lpSQOS pointer indicates that a quality of service negotiation is to occur or that the provider is prepared
		/// to accept the quality of service request without negotiation.
		/// </param>
		/// <param name="lpGQOS">
		/// Reserved, and should be NULL. (reserved for future use with socket groups) references the FLOWSPEC structure for the socket group
		/// the caller is to create, one for each direction, followed by any additional provider-specific parameters. A NULL value for lpGQOS
		/// indicates no caller-specified group quality of service. Quality of service information can be returned if negotiation is to occur.
		/// </param>
		/// <param name="lpCalleeId">
		/// Contains the local address of the connected entity. The buf portion of the WSABUF pointed to by lpCalleeId points to a sockaddr
		/// structure. The sockaddr structure is interpreted according to its address family (typically by casting the sockaddr to some type
		/// specific to the address family such as struct sockaddr_in).
		/// </param>
		/// <param name="lpCalleeData">
		/// A result parameter used by the condition function to supply user data back to the connecting entity. The lpCalleeData-&gt;len
		/// initially contains the length of the buffer allocated by the service provider and pointed to by lpCalleeData-&gt;buf. A value of
		/// zero means passing user data back to the caller is not supported. The condition function should copy up to lpCalleeData-&gt;len
		/// bytes of data into lpCalleeData-&gt;buf, and then update lpCalleeData-&gt;len to indicate the actual number of bytes transferred.
		/// If no user data is to be passed back to the caller, the condition function should set lpCalleeData-&gt;len to zero. The format of
		/// all address and user data is specific to the address family to which the socket belongs.
		/// </param>
		/// <param name="g">
		/// <para>Assigned within the condition function to indicate any of the following actions:</para>
		/// <list type="bullet">
		/// <item>
		/// If g is an existing socket group identifier, add s to this group, provided all the requirements set by this group are met.
		/// </item>
		/// <item>If g = SG_UNCONSTRAINED_GROUP, create an unconstrained socket group and have s as the first member.</item>
		/// <item>If g = SG_CONSTRAINED_GROUP, create a constrained socket group and have s as the first member.</item>
		/// <item>If g = zero, no group operation is performed.</item>
		/// </list>
		/// <para>
		/// For unconstrained groups, any set of sockets can be grouped together as long as they are supported by a single service provider.
		/// A constrained socket group can consist only of connection-oriented sockets, and requires that connections on all grouped sockets
		/// be to the same address on the same host.For newly created socket groups, the new group identifier can be retrieved by using
		/// getsockopt function with level parameter set to SOL_SOCKET and the optname parameter set to SO_GROUP_ID.A socket group and its
		/// associated socket group ID remain valid until the last socket belonging to this socket group is closed.Socket group IDs are
		/// unique across all processes for a given service provider. A socket group and its associated identifier remain valid until the
		/// last socket belonging to this socket group is closed.Socket group identifiers are unique across all processes for a given service
		/// provider. For more information on socket groups, see the Remarks for the WSASocket functions.
		/// </para>
		/// </param>
		/// <param name="dwCallbackData">
		/// Value passed to the condition function is the value passed as the dwCallbackData parameter in the original WSAAccept call. This
		/// value is interpreted only by the Windows Socket version 2 client. This allows a client to pass some context information from the
		/// WSAAccept call site through to the condition function. This also provides the condition function with any additional information
		/// required to determine whether to accept the connection or not. A typical usage is to pass a (suitably cast) pointer to a data
		/// structure containing references to application-defined objects with which this socket is associated.
		/// </param>
		/// <returns></returns>
		[PInvokeData("winsock2.h", MSDNShortId = "f385f63f-49b2-4eb7-8717-ad4cca1a2252")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		public delegate CF LPCONDITIONPROC(in WSABUF lpCallerId, in WSABUF lpCallerData, IntPtr lpSQOS, IntPtr lpGQOS, in WSABUF lpCalleeId, in WSABUF lpCalleeData, out GROUP g, IntPtr dwCallbackData);

		[PInvokeData("winsock2.h")]
		public enum ADDRESS_FAMILY : ushort
		{
			/// <summary>Unspecified address family.</summary>
			AF_UNSPEC = 0,

			/// <summary>Unix local to host address.</summary>
			AF_UNIX = 1,

			/// <summary>Address for IP version 4.</summary>
			AF_INET = 2,

			/// <summary>ARPANET IMP address.</summary>
			AF_IMPLINK = 3,

			/// <summary>Address for PUP protocols.</summary>
			AF_PUP = 4,

			/// <summary>Address for MIT CHAOS protocols.</summary>
			AF_CHAOS = 5,

			/// <summary>Address for Xerox NS protocols.</summary>
			AF_NS = 6,

			/// <summary>IPX or SPX address.</summary>
			AF_IPX = AF_NS,

			/// <summary>Address for ISO protocols.</summary>
			AF_ISO = 7,

			/// <summary>Address for OSI protocols.</summary>
			AF_OSI = AF_ISO,

			/// <summary>European Computer Manufacturers Association (ECMA) address.</summary>
			AF_ECMA = 8,

			/// <summary>Address for Datakit protocols.</summary>
			AF_DATAKIT = 9,

			/// <summary>Addresses for CCITT protocols, such as X.25.</summary>
			AF_CCITT = 10,

			/// <summary>IBM SNA address.</summary>
			AF_SNA = 11,

			/// <summary>DECnet address.</summary>
			AF_DECnet = 12,

			/// <summary>Direct data-link interface address.</summary>
			AF_DLI = 13,

			/// <summary>LAT address.</summary>
			AF_LAT = 14,

			/// <summary>NSC Hyperchannel address.</summary>
			AF_HYLINK = 15,

			/// <summary>AppleTalk address.</summary>
			AF_APPLETALK = 16,

			/// <summary>NetBios address.</summary>
			AF_NETBIOS = 17,

			/// <summary>VoiceView address.</summary>
			AF_VOICEVIEW = 18,

			/// <summary>FireFox address.</summary>
			AF_FIREFOX = 19,

			/// <summary>Undocumented.</summary>
			AF_UNKNOWN1 = 20,

			/// <summary>Banyan address.</summary>
			AF_BAN = 21,

			/// <summary>Native ATM services address.</summary>
			AF_ATM = 22,

			/// <summary>Address for IP version 6.</summary>
			AF_INET6 = 23,

			/// <summary>Address for Microsoft cluster products.</summary>
			AF_CLUSTER = 24,

			/// <summary>IEEE 1284.4 workgroup address.</summary>
			AF_12844 = 25,

			/// <summary>IrDA address.</summary>
			AF_IRDA = 26,

			/// <summary>Address for Network Designers OSI gateway-enabled protocols.</summary>
			AF_NETDES = 28,

			/// <summary>Undocumented.</summary>
			AF_TCNPROCESS = 29,

			/// <summary>Undocumented.</summary>
			AF_TCNMESSAGE = 30,

			/// <summary>Undocumented.</summary>
			AF_ICLFXBM = 31,

			/// <summary>Bluetooth RFCOMM/L2CAP protocols.</summary>
			AF_BTH = 32,

			/// <summary>Link layer interface.</summary>
			AF_LINK = 33,

			/// <summary>Windows Hyper-V.</summary>
			AF_HYPERV = 34,
		}

		/// <summary>Possible return values to WSAAccept from the LPCONDITIONPROC.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "f385f63f-49b2-4eb7-8717-ad4cca1a2252")]
		public enum CF
		{
			/// <summary>
			/// WSAAccept creates a new socket. The newly created socket has the same properties as socket s including asynchronous events
			/// registered with WSAAsyncSelect or with WSAEventSelect.
			/// </summary>
			CF_ACCEPT = 0x0000,

			/// <summary>
			/// WSAAccept rejects the connection request. The condition function runs in the same thread as this function does, and should
			/// return as soon as possible.
			/// </summary>
			CF_REJECT = 0x0001,

			/// <summary>
			/// If the decision cannot be made immediately, the condition function should return CF_DEFER to indicate that no decision has
			/// been made, and no action about this connection request should be taken by the service provider. When the application is ready
			/// to take action on the connection request, it will invoke WSAAccept again and return either CF_ACCEPT or CF_REJECT as a return
			/// value from the condition function.
			/// </summary>
			CF_DEFER = 0x0002
		}

		/// <summary>Socket group flags.</summary>
		[PInvokeData("winsock2.h")]
		[Flags]
		public enum GROUP : uint
		{
			/// <summary>
			/// Create an unconstrained socket group and have the new socket be the first member. For an unconstrained group, Winsock does
			/// not constrain all sockets in the socket group to have been created with the same value for the type and protocol parameters.
			/// </summary>
			SG_UNCONSTRAINED_GROUP = 0x01,

			/// <summary>
			/// Create a constrained socket group and have the new socket be the first member. For a contrained socket group, Winsock
			/// constrains all sockets in the socket group to have been created with the same value for the type and protocol parameters. A
			/// constrained socket group may consist only of connection-oriented sockets, and requires that connections on all grouped
			/// sockets be to the same address on the same host.
			/// </summary>
			SG_CONSTRAINED_GROUP = 0x02
		}

		/// <summary>Protocols. The IPv6 defines are specified in RFC 2292.</summary>
		public enum IPPROTO
		{
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

			IPPROTO_IPV4 = 4,
			IPPROTO_ST = 5,

			/// <summary>
			/// The Transmission Control Protocol (TCP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type
			/// parameter is SOCK_STREAM.
			/// </summary>
			IPPROTO_TCP = 6,

			IPPROTO_CBT = 7,
			IPPROTO_EGP = 8,
			IPPROTO_IGP = 9,
			IPPROTO_PUP = 12,

			/// <summary>
			/// The User Datagram Protocol (UDP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type
			/// parameter is SOCK_DGRAM.
			/// </summary>
			IPPROTO_UDP = 17,

			IPPROTO_IDP = 22,
			IPPROTO_RDP = 27,
			IPPROTO_IPV6 = 41,
			IPPROTO_ROUTING = 43,
			IPPROTO_FRAGMENT = 44,
			IPPROTO_ESP = 50,
			IPPROTO_AH = 51,

			/// <summary>
			/// The Internet Control Message Protocol Version 6 (ICMPv6). This is a possible value when the af parameter is AF_UNSPEC,
			/// AF_INET, or AF_INET6 and the type parameter is SOCK_RAW or unspecified.
			/// <para>This protocol value is supported on Windows XP and later.</para>
			/// </summary>
			IPPROTO_ICMPV6 = 58,

			IPPROTO_NONE = 59,
			IPPROTO_DSTOPTS = 60,
			IPPROTO_ND = 77,
			IPPROTO_ICLFXBM = 78,
			IPPROTO_PIM = 103,

			/// <summary>
			/// The PGM protocol for reliable multicast. This is a possible value when the af parameter is AF_INET and the type parameter is
			/// SOCK_RDM. On the Windows SDK released for Windows Vista and later, this protocol is also called IPPROTO_PGM.
			/// <para>This protocol value is only supported if the Reliable Multicast Protocol is installed.</para>
			/// </summary>
			IPPROTO_PGM = 113,

			IPPROTO_L2TP = 115,
			IPPROTO_SCTP = 132,
			IPPROTO_RAW = 255,
			IPPROTO_MAX = 256,
			IPPROTO_RESERVED_RAW = 257,
			IPPROTO_RESERVED_IPSEC = 258,
			IPPROTO_RESERVED_IPSECOFFLOAD = 259,
			IPPROTO_RESERVED_WNV = 260,
			IPPROTO_RESERVED_MAX = 261
		}

		/// <summary>The type specification for the new socket.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "6bf6e6c4-6268-479c-86a6-52e90cf317db")]
		public enum SOCK
		{
			/// <summary>
			/// A socket type that provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission
			/// mechanism. This socket type uses the Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6).
			/// </summary>
			SOCK_STREAM = 1,

			/// <summary>
			/// A socket type that supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum
			/// length. This socket type uses the User Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
			/// </summary>
			SOCK_DGRAM = 2,

			/// <summary>
			/// A socket type that provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To
			/// manipulate the IPv4 header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the
			/// IPV6_HDRINCL socket option must be set on the socket.
			/// </summary>
			SOCK_RAW = 3,

			/// <summary>
			/// A socket type that provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM)
			/// multicast protocol implementation in Windows, often referred to as reliable multicast programming.
			/// <para>This type value is only supported if the Reliable Multicast Protocol is installed.</para>
			/// </summary>
			SOCK_RDM = 4,

			/// <summary>A socket type that provides a pseudo-stream packet based on datagrams.</summary>
			SOCK_SEQPACKET = 5,
		}

		/// <summary>The <c>bind</c> function associates a local address with a socket.</summary>
		/// <param name="s">A descriptor identifying an unbound socket.</param>
		/// <param name="addr">TBD</param>
		/// <param name="namelen">The length, in bytes, of the value pointed to by the name parameter.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>bind</c> returns zero. Otherwise, it returns SOCKET_ERROR, and a specific error code can be retrieved by
		/// calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term></term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>
		/// An attempt was made to access a socket in a way forbidden by its access permissions. This error is returned if nn attempt to bind
		/// a datagram socket to the broadcast address failed because the setsockopt option SO_BROADCAST is not enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEADDRINUSE</term>
		/// <term>
		/// Only one usage of each socket address (protocol/network address/port) is normally permitted. This error is returned if a process
		/// on the computer is already bound to the same fully qualified address and the socket has not been marked to allow address reuse
		/// with SO_REUSEADDR. For example, the IP address and port specified in the name parameter are already bound to another socket being
		/// used by another application. For more information, see the SO_REUSEADDR socket option in the SOL_SOCKET Socket Options reference,
		/// Using SO_REUSEADDR and SO_EXCLUSIVEADDRUSE, and SO_EXCLUSIVEADDRUSE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEADDRNOTAVAIL</term>
		/// <term>
		/// The requested address is not valid in its context. This error is returned if the specified address pointed to by the name
		/// parameter is not a valid local IP address on this computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if the
		/// name parameter is NULL, the name or namelen parameter is not a valid part of the user address space, the namelen parameter is too
		/// small, the name parameter contains an incorrect address format for the associated address family, or the first two bytes of the
		/// memory block specified by name do not match the address family associated with the socket descriptor s.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>An invalid argument was supplied. This error is returned of the socket s is already bound to an address.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>
		/// An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full.
		/// This error is returned of not enough buffers are available or there are too many connections.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>
		/// An operation was attempted on something that is not a socket. This error is returned if the descriptor in the s parameter is not
		/// a socket.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>bind</c> function is required on an unconnected socket before subsequent calls to the listen function. It is normally used
		/// to bind to either connection-oriented (stream) or connectionless (datagram) sockets. The <c>bind</c> function may also be used to
		/// bind to a raw socket (the socket was created by calling the socketfunction with the type parameter set to SOCK_RAW). The
		/// <c>bind</c> function may also be used on an unconnected socket before subsequent calls to the connect, ConnectEx, WSAConnect,
		/// WSAConnectByList, or WSAConnectByName functions before send operations.
		/// </para>
		/// <para>
		/// When a socket is created with a call to the socket function, it exists in a namespace (address family), but it has no name
		/// assigned to it. Use the <c>bind</c> function to establish the local association of the socket by assigning a local name to an
		/// unnamed socket.
		/// </para>
		/// <para>A name consists of three parts when using the Internet address family:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The address family.</term>
		/// </item>
		/// <item>
		/// <term>A host address.</term>
		/// </item>
		/// <item>
		/// <term>A port number that identifies the application.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows Sockets 2, the name parameter is not strictly interpreted as a pointer to a sockaddr structure. It is cast this way
		/// for Windows Sockets 1.1 compatibility. Service providers are free to regard it as a pointer to a block of memory of size namelen.
		/// The first 2 bytes in this block (corresponding to the <c>sa_family</c> member of the <c>sockaddr</c> structure, the
		/// <c>sin_family</c> member of the <c>sockaddr_in</c> structure, or the <c>sin6_family</c> member of the <c>sockaddr_in6</c>
		/// structure) must contain the address family that was used to create the socket. Otherwise, an error WSAEFAULT occurs.
		/// </para>
		/// <para>
		/// If an application does not care what local address is assigned, specify the constant value <c>INADDR_ANY</c> for an IPv4 local
		/// address or the constant value <c>in6addr_any</c> for an IPv6 local address in the <c>sa_data</c> member of the name parameter.
		/// This allows the underlying service provider to use any appropriate network address, potentially simplifying application
		/// programming in the presence of multihomed hosts (that is, hosts that have more than one network interface and address).
		/// </para>
		/// <para>
		/// For TCP/IP, if the port is specified as zero, the service provider assigns a unique port to the application from the dynamic
		/// client port range. On Windows Vista and later, the dynamic client port range is a value between 49152 and 65535. This is a change
		/// from Windows Server 2003 and earlier where the dynamic client port range was a value between 1025 and 5000. The maximum value for
		/// the client dynamic port range can be changed by setting a value under the following registry key:
		/// </para>
		/// <para><c>HKLM\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters</c></para>
		/// <para>
		/// The <c>MaxUserPort</c> registry value sets the value to use for the maximum value of the dynamic client port range. You must
		/// restart the computer for this setting to take effect.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the dynamic client port range can be viewed and changed using <c>netsh</c> commands. The dynamic
		/// client port range can be set differently for UDP and TCP and also for IPv4 and IPv6. For more information, see KB 929851.
		/// </para>
		/// <para>
		/// The application can use getsockname after calling <c>bind</c> to learn the address and the port that has been assigned to the
		/// socket. If the Internet address is equal to <c>INADDR_ANY</c> or <c>in6addr_any</c>, <c>getsockname</c> cannot necessarily supply
		/// the address until the socket is connected, since several addresses can be valid if the host is multihomed. Binding to a specific
		/// port number other than port 0 is discouraged for client applications, since there is a danger of conflicting with another socket
		/// already using that port number on the local computer.
		/// </para>
		/// <para>
		/// For multicast operations, the preferred method is to call the <c>bind</c> function to associate a socket with a local IP address
		/// and then join the multicast group. Although this order of operations is not mandatory, it is strongly recommended. So a multicast
		/// application would first select an IPv4 or IPv6 address on the local computer, the wildcard IPv4 address ( <c>INADDR_ANY</c>), or
		/// the wildcard IPv6 address ( <c>in6addr_any</c>). The the multicast application would then call the <c>bind</c> function with this
		/// address in the in the <c>sa_data</c> member of the name parameter to associate the local IP address with the socket. If a
		/// wildcard address was specified, then Windows will select the local IP address to use. After the <c>bind</c> function completes,
		/// an application would then join the multicast group of interest. For more information on how to join a multicast group, see the
		/// section on Multicast Programming. This socket can then be used to receive multicast packets from the multicast group using the
		/// recv, recvfrom, WSARecv, WSARecvEx, WSARecvFrom, or WSARecvMsg functions.
		/// </para>
		/// <para>
		/// The <c>bind</c> function is not normally required for send operations to a multicast group. The sendto,WSASendMsg, and WSASendTo
		/// functions implicitly bind the socket to the wildcard address if the socket is not already bound. The <c>bind</c> function is
		/// required before the use of the send or WSASend functions which do not perform an implicit bind and are allowed only on connected
		/// sockets, which means the socket must have already been bound for it to be connected. The <c>bind</c> function might be used
		/// before send operations using the <c>sendto</c>, <c>WSASendMsg</c>, or <c>WSASendTo</c> functions if an application wanted to
		/// select a specific local IP address on a local computer with multiple network interfaces and local IP addresses. Otherwise an
		/// implicit bind to the wildcard address using the <c>sendto</c>, <c>WSASendMsg</c> , or <c>WSASendTo</c> functions might result in
		/// a different local IP address being used for send operations.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>bind</c>, Winsock may need to wait for a network event before the
		/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
		/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing blocking
		/// Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// <para>Notes for IrDA Sockets</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Af_irda.h header file must be explicitly included.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Local names are not exposed in IrDA. IrDA client sockets therefore, must never call the <c>bind</c> function before the connect
		/// function. If the IrDA socket was previously bound to a service name using <c>bind</c>, the <c>connect</c> function will fail with SOCKET_ERROR.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the service name is of the form "LSAP-SELxxx," where xxx is a decimal integer in the range 1-127, the address indicates a
		/// specific LSAP-SEL xxx rather than a service name. Service names such as these allow server applications to accept incoming
		/// connections directed to a specific LSAP-SEL, without first performing an ISA service name query to get the associated LSAP-SEL.
		/// One example of this service name type is a non-Windows device that does not support IAS.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates the use of the <c>bind</c> function. For another example that uses the <c>bind</c> function,
		/// see Getting Started With Winsock.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-bind int bind( SOCKET s, const sockaddr *addr, int namelen );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "3a651daa-7404-4ef7-8cff-0d3dff41a8e8")]
		public static extern int bind(SOCKET s, [In] SOCKADDR addr, int namelen);

		/// <summary>The <c>closesocket</c> function closes an existing socket.</summary>
		/// <param name="s">A descriptor identifying the socket to close.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>closesocket</c> returns zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error
		/// code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>The (blocking) Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The socket is marked as nonblocking, but the l_onoff member of the linger structure is set to nonzero and the l_linger member of
		/// the linger structure is set to a nonzero timeout value.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>closesocket</c> function closes a socket. Use it to release the socket descriptor passed in the s parameter. Note that the
		/// socket descriptor passed in the s parameter may immediately be reused by the system as soon as <c>closesocket</c> function is
		/// issued. As a result, it is not reliable to expect further references to the socket descriptor passed in the s parameter to fail
		/// with the error WSAENOTSOCK. A Winsock client must never issue <c>closesocket</c> on s concurrently with another Winsock function call.
		/// </para>
		/// <para>
		/// Any pending overlapped send and receive operations ( WSASend/ WSASendTo/ WSARecv/ WSARecvFrom with an overlapped socket) issued
		/// by any thread in this process are also canceled. Any event, completion routine, or completion port action specified for these
		/// overlapped operations is performed. The pending overlapped operations fail with the error status WSA_OPERATION_ABORTED.
		/// </para>
		/// <para>
		/// An application should not assume that any outstanding I/O operations on a socket will all be guaranteed to completed when
		/// <c>closesocket</c> returns. The <c>closesocket</c> function will initiate cancellation on the outstanding I/O operations, but
		/// that does not mean that an application will receive I/O completion for these I/O operations by the time the <c>closesocket</c>
		/// function returns. Thus, an application should not cleanup any resources (WSAOVERLAPPED structures, for example) referenced by the
		/// outstanding I/O requests until the I/O requests are indeed completed.
		/// </para>
		/// <para>
		/// An application should always have a matching call to <c>closesocket</c> for each successful call to socket to return any socket
		/// resources to the system.
		/// </para>
		/// <para>
		/// The linger structure maintains information about a specific socket that specifies how that socket should behave when data is
		/// queued to be sent and the <c>closesocket</c> function is called on the socket.
		/// </para>
		/// <para>
		/// The <c>l_onoff</c> member of the <c>linger</c> structure determines whether a socket should remain open for a specified amount of
		/// time after a <c>closesocket</c> function call to enable queued data to be sent. This member can be modified in two ways:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Call the setsockopt function with the optname parameter set to <c>SO_DONTLINGER</c>. The optval parameter determines how the
		/// <c>l_onoff</c> member is modified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the setsockopt function with the optname parameter set to <c>SO_LINGER</c>. The optval parameter specifies how both the
		/// <c>l_onoff</c> and <c>l_linger</c> members are modified.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>l_linger</c> member of the <c>linger</c> structure determines the amount of time, in seconds, a socket should remain open.
		/// This member is only applicable if the <c>l_onoff</c> member of the <c>linger</c> structure is nonzero.
		/// </para>
		/// <para>
		/// The default parameters for a socket are the <c>l_onoff</c> member of the <c>linger</c> structure is zero, indicating that the
		/// socket should not remain open. The default value for the <c>l_linger</c> member of the <c>linger</c> structure is zero, but this
		/// value is ignored when the <c>l_onoff</c> member is set to zero.
		/// </para>
		/// <para>
		/// To enable a socket to remain open, an application should set the <c>l_onoff</c> member to a nonzero value and set the
		/// <c>l_linger</c> member to the desired timeout in seconds. To disable a socket from remaining open, an application only needs to
		/// set the <c>l_onoff</c> member of the <c>linger</c> structure to zero.
		/// </para>
		/// <para>
		/// If an application calls the setsockopt function with the optname parameter set to <c>SO_DONTLINGER</c> to set the <c>l_onoff</c>
		/// member to a nonzero value, the value for the <c>l_linger</c> member is not specified. In this case, the timeout used is
		/// implementation dependent. If a previous timeout has been established for a socket (by previously calling the <c>setsockopt</c>
		/// function with the optname parameter set to <c>SO_LINGER</c>), this timeout value should be reinstated by the service provider.
		/// </para>
		/// <para>
		/// The semantics of the <c>closesocket</c> function are affected by the socket options that set members of <c>linger</c> structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>l_onoff</term>
		/// <term>l_linger</term>
		/// <term>Type of close</term>
		/// <term>Wait for close?</term>
		/// </listheader>
		/// <item>
		/// <term>zero</term>
		/// <term>Do not care</term>
		/// <term>Graceful close</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>nonzero</term>
		/// <term>zero</term>
		/// <term>Hard</term>
		/// <term>No</term>
		/// </item>
		/// <item>
		/// <term>nonzero</term>
		/// <term>nonzero</term>
		/// <term>
		/// Graceful if all data is sent within timeout value specified in the l_linger member. Hard if all data could not be sent within
		/// timeout value specified in the l_linger member.
		/// </term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the <c>l_onoff</c> member of the LINGER structure is zero on a stream socket, the <c>closesocket</c> call will return
		/// immediately and does not receive WSAEWOULDBLOCK whether the socket is blocking or nonblocking. However, any data queued for
		/// transmission will be sent, if possible, before the underlying socket is closed. This is also called a graceful disconnect or
		/// close. In this case, the Windows Sockets provider cannot release the socket and other resources for an arbitrary period, thus
		/// affecting applications that expect to use all available sockets. This is the default behavior for a socket.
		/// </para>
		/// <para>
		/// If the <c>l_onoff</c> member of the linger structure is nonzero and <c>l_linger</c> member is zero, <c>closesocket</c> is not
		/// blocked even if queued data has not yet been sent or acknowledged. This is called a hard or abortive close, because the socket's
		/// virtual circuit is reset immediately, and any unsent data is lost. On Windows, any <c>recv</c> call on the remote side of the
		/// circuit will fail with WSAECONNRESET.
		/// </para>
		/// <para>
		/// If the <c>l_onoff</c> member of the linger structure is set to nonzero and <c>l_linger</c> member is set to a nonzero timeout on
		/// a blocking socket, the <c>closesocket</c> call blocks until the remaining data has been sent or until the timeout expires. This
		/// is called a graceful disconnect or close if all of the data is sent within timeout value specified in the <c>l_linger</c> member.
		/// If the timeout expires before all data has been sent, the Windows Sockets implementation terminates the connection before
		/// <c>closesocket</c> returns and this is called a hard or abortive close.
		/// </para>
		/// <para>
		/// Setting the <c>l_onoff</c> member of the linger structure to nonzero and the <c>l_linger</c> member with a nonzero timeout
		/// interval on a nonblocking socket is not recommended. In this case, the call to <c>closesocket</c> will fail with an error of
		/// WSAEWOULDBLOCK if the close operation cannot be completed immediately. If <c>closesocket</c> fails with WSAEWOULDBLOCK the socket
		/// handle is still valid, and a disconnect is not initiated. The application must call <c>closesocket</c> again to close the socket.
		/// </para>
		/// <para>
		/// If the <c>l_onoff</c> member of the linger structure is nonzero and the <c>l_linger</c> member is a nonzero timeout interval on a
		/// blocking socket, the result of the <c>closesocket</c> function can't be used to determine whether all data has been sent to the
		/// peer. If the data is sent before the timeout specified in the <c>l_linger</c> member expires or if the connection was aborted,
		/// the <c>closesocket</c> function won't return an error code (the return value from the <c>closesocket</c> function is zero).
		/// </para>
		/// <para>
		/// The <c>closesocket</c> call will only block until all data has been delivered to the peer or the timeout expires. If the
		/// connection is reset because the timeout expires, then the socket will not go into TIME_WAIT state. If all data is sent within the
		/// timeout period, then the socket can go into TIME_WAIT state.
		/// </para>
		/// <para>
		/// If the <c>l_onoff</c> member of the linger structure is nonzero and the <c>l_linger</c> member is a zero timeout interval on a
		/// blocking socket, then a call to <c>closesocket</c> will reset the connection. The socket will not go to the TIME_WAIT state.
		/// </para>
		/// <para>
		/// The getsockopt function can be called with the optname parameter set to <c>SO_LINGER</c> to retrieve the current value of the
		/// <c>linger</c> structure associated with a socket.
		/// </para>
		/// <para>
		/// <c>Note</c> To assure that all data is sent and received on a connection, an application should call shutdown before calling
		/// <c>closesocket</c> (see Graceful shutdown, linger options, and socket closure for more information). Also note, an FD_CLOSE
		/// network event is not posted after <c>closesocket</c> is called.
		/// </para>
		/// <para>Here is a summary of <c>closesocket</c> behavior:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the <c>l_onoff</c> member of the LINGER structure is zero (the default for a socket), <c>closesocket</c> returns immediately
		/// and the connection is gracefully closed in the background.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the <c>l_onoff</c> member of the linger structure is set to nonzero and the <c>l_linger</c> member is set to zero (no timeout)
		/// <c>closesocket</c> returns immediately and the connection is reset or terminated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the <c>l_onoff</c> member of the linger structure is set to nonzero and the <c>l_linger</c> member is set to a nonzero
		/// timeout:– For a blocking socket, <c>closesocket</c> blocks until all data is sent or the timeout expires.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For additional information please see Graceful Shutdown, Linger Options, and Socket Closure for more information.</para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>closesocket</c>, Winsock may need to wait for a network event before
		/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// <para>Notes for IrDA Sockets</para>
		/// <para>Keep the following in mind:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Af_irda.h header file must be explicitly included.</term>
		/// </item>
		/// <item>
		/// <term>The standard linger options are supported.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Although IrDA does not provide a graceful close, IrDA will defer closing until receive queues are purged. Thus, an application
		/// can send data and immediately call the socket function, and be confident that the receiver will copy the data before receiving an
		/// FD_CLOSE message.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Notes for ATM</para>
		/// <para>
		/// The following are important issues associated with connection teardown when using Asynchronous Transfer Mode (ATM) and Windows
		/// Sockets 2:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Using the <c>closesocket</c> or shutdown functions with SD_SEND or SD_BOTH results in a RELEASE signal being sent out on the
		/// control channel. Due to ATM's use of separate signal and data channels, it is possible that a RELEASE signal could reach the
		/// remote end before the last of the data reaches its destination, resulting in a loss of that data. One possible solutions is
		/// programming a sufficient delay between the last data sent and the <c>closesocket</c> or shutdown function calls for an ATM socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Half close is not supported by ATM.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Both abortive and graceful disconnects result in a RELEASE signal being sent out with the same cause field. In either case,
		/// received data at the remote end of the socket is still delivered to the application. See Graceful Shutdown, Linger Options, and
		/// Socket Closure for more information.
		/// </term>
		/// </item>
		/// </list>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-closesocket int closesocket( IN SOCKET s );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "2f357aa8-389b-4c92-8a9f-289e048cc41c")]
		public static extern int closesocket([In] SOCKET s);

		/// <summary>
		/// <para>
		/// The <c>inet_ntoa</c> function converts an (Ipv4) Internet network address into an ASCII string in Internet standard
		/// dotted-decimal format.
		/// </para>
		/// </summary>
		/// <param name="a">An Internet address structure</param>
		/// <returns>
		/// <para>
		/// If no error occurs, inet_ntoa returns a character pointer to a static buffer containing the text address in standard ".''
		/// notation. Otherwise, it returns NULL.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>inet_ntoa</c> function takes an Internet address structure specified by the in parameter and returns a
		/// <c>NULL</c>-terminated ASCII string that represents the address in "." (dot) notation as in "192.168.16.0", an example of an IPv4
		/// address in dotted-decimal notation. The string returned by <c>inet_ntoa</c> resides in memory that is allocated by Windows
		/// Sockets. The application should not make any assumptions about the way in which the memory is allocated. The string returned is
		/// guaranteed to be valid only until the next Windows Sockets function call is made within the same thread. Therefore, the data
		/// should be copied before another Windows Sockets call is made.
		/// </para>
		/// <para>
		/// The WSAAddressToString function can be used to convert a sockaddr structure containing an IPv4 address to a string representation
		/// of an IPv4 address in Internet standard dotted-decimal notation. The advantage of the <c>WSAAddressToString</c> function is that
		/// it supports both IPv4 and IPv6 addresses. Another advantage of the <c>WSAAddressToString</c> function is that there are both
		/// ASCII and Unicode versions of this function.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4AddressToString function can be used to convert an IPv4 address represented as an IN_ADDR
		/// structure to a string representation of an IPv4 address in Internet standard dotted-decimal notation. On Windows Vista and later,
		/// the RtlIpv6AddressToString function can be used to convert an IPv6 address represented as an <c>IN6_ADDR</c> structure to a
		/// string representation of an IPv6 address.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wsipv6ok/nf-wsipv6ok-inet_ntoa void inet_ntoa( a );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("wsipv6ok.h", MSDNShortId = "01cd32e7-a01d-40e8-afb5-69223d643a0e")]
		public static extern string inet_ntoa(IN_ADDR a);

		/// <summary>The <c>listen</c> function places a socket in a state in which it is listening for an incoming connection.</summary>
		/// <param name="s">A descriptor identifying a bound, unconnected socket.</param>
		/// <param name="backlog">
		/// <para>
		/// The maximum length of the queue of pending connections. If set to <c>SOMAXCONN</c>, the underlying service provider responsible
		/// for socket s will set the backlog to a maximum reasonable value. If set to <c>SOMAXCONN_HINT(N)</c> (where N is a number), the
		/// backlog value will be N, adjusted to be within the range (200, 65535). Note that <c>SOMAXCONN_HINT</c> can be used to set the
		/// backlog to a larger value than possible with SOMAXCONN.
		/// </para>
		/// <para>
		/// <c>SOMAXCONN_HINT</c> is only supported by the Microsoft TCP/IP service provider. There is no standard provision to obtain the
		/// actual backlog value.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>listen</c> returns zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
		/// can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEADDRINUSE</term>
		/// <term>
		/// The socket's local address is already in use and the socket was not marked to allow address reuse with SO_REUSEADDR. This error
		/// usually occurs during execution of the bind function, but could be delayed until this function if the bind was to a partially
		/// wildcard address (involving ADDR_ANY) and if a specific address needs to be committed at the time of this function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket has not been bound with bind.</term>
		/// </item>
		/// <item>
		/// <term>WSAEISCONN</term>
		/// <term>The socket is already connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAEMFILE</term>
		/// <term>No more socket descriptors are available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>The referenced socket is not of a type that supports the listen operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To accept connections, a socket is first created with the socket function and bound to a local address with the bind function. A
		/// backlog for incoming connections is specified with <c>listen</c>, and then the connections are accepted with the accept function.
		/// Sockets that are connection oriented, those of type <c>SOCK_STREAM</c> for example, are used with <c>listen</c>. The socket s is
		/// put into passive mode where incoming connection requests are acknowledged and queued pending acceptance by the process.
		/// </para>
		/// <para>
		/// A value for the backlog of <c>SOMAXCONN</c> is a special constant that instructs the underlying service provider responsible for
		/// socket s to set the length of the queue of pending connections to a maximum reasonable value.
		/// </para>
		/// <para>On Windows Sockets 2, this maximum value defaults to a large value (typically several hundred or more).</para>
		/// <para>
		/// When calling the <c>listen</c> function in a Bluetooth application, it is strongly recommended that a much lower value be used
		/// for the backlog parameter (typically 2 to 4), since only a few client connections are accepted. This reduces the system resources
		/// that are allocated for use by the listening socket. This same recommendation applies to other network applications that expect
		/// only a few client connections.
		/// </para>
		/// <para>
		/// The <c>listen</c> function is typically used by servers that can have more than one connection request at a time. If a connection
		/// request arrives and the queue is full, the client will receive an error with an indication of WSAECONNREFUSED.
		/// </para>
		/// <para>
		/// If there are no available socket descriptors, <c>listen</c> attempts to continue to function. If descriptors become available, a
		/// later call to <c>listen</c> or accept will refill the queue to the current or most recent value specified for the backlog
		/// parameter, if possible, and resume listening for incoming connections.
		/// </para>
		/// <para>
		/// If the <c>listen</c> function is called on an already listening socket, it will return success without changing the value for the
		/// backlog parameter. Setting the backlog parameter to 0 in a subsequent call to <c>listen</c> on a listening socket is not
		/// considered a proper reset, especially if there are connections on the socket.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>listen</c>, Winsock may need to wait for a network event before the
		/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
		/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing blocking
		/// Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>listen</c> function.</para>
		/// <para>Example Code</para>
		/// <para>For another example that uses the <c>listen</c> function, see Getting Started With Winsock.</para>
		/// <para>Notes for IrDA Sockets</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Af_irda.h header file must be explicitly included.</term>
		/// </item>
		/// </list>
		/// <para>Compatibility</para>
		/// <para>
		/// The backlog parameter is limited (silently) to a reasonable value as determined by the underlying service provider. Illegal
		/// values are replaced by the nearest legal value. There is no standard provision to find out the actual backlog value.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-listen int WSAAPI listen( SOCKET s, int backlog );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "1233feeb-a8c1-49ac-ab34-82af224ecf00")]
		public static extern int listen(SOCKET s, int backlog);

		/// <summary>The <c>socket</c> function creates a socket that is bound to a specific transport service provider.</summary>
		/// <param name="af">
		/// <para>The address family specification. Possible values for the address family are defined in the Winsock2.h header file.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the possible values for
		/// the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in
		/// Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// The values currently supported are AF_INET or AF_INET6, which are the Internet address family formats for IPv4 and IPv6. Other
		/// options for address family (AF_NETBIOS for use with NetBIOS, for example) are supported if a Windows Sockets service provider for
		/// the address family is installed. Note that the values for the AF_ address family and PF_ protocol family constants are identical
		/// (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The table below lists common values for address family although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Af</term>
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
		/// <term>AF_IPX 6</term>
		/// <term>
		/// The IPX/SPX address family. This address family is only supported if the NWLink IPX/SPX NetBIOS Compatible Transport protocol is
		/// installed. This address family is not supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_APPLETALK 16</term>
		/// <term>
		/// The AppleTalk address family. This address family is only supported if the AppleTalk protocol is installed. This address family
		/// is not supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_NETBIOS 17</term>
		/// <term>
		/// The NetBIOS address family. This address family is only supported if the Windows Sockets provider for NetBIOS is installed. The
		/// Windows Sockets provider for NetBIOS is supported on 32-bit versions of Windows. This provider is installed by default on 32-bit
		/// versions of Windows. The Windows Sockets provider for NetBIOS is not supported on 64-bit versions of windows including Windows 7,
		/// Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP. The Windows Sockets provider for NetBIOS only supports
		/// sockets where the type parameter is set to SOCK_DGRAM. The Windows Sockets provider for NetBIOS is not directly related to the
		/// NetBIOS programming interface. The NetBIOS programming interface is not supported on Windows Vista, Windows Server 2008, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
		/// </item>
		/// <item>
		/// <term>AF_IRDA 26</term>
		/// <term>
		/// The Infrared Data Association (IrDA) address family. This address family is only supported if the computer has an infrared port
		/// and driver installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_BTH 32</term>
		/// <term>
		/// The Bluetooth address family. This address family is supported on Windows XP with SP2 or later if the computer has a Bluetooth
		/// adapter and driver installed.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="type">
		/// <para>The type specification for the new socket.</para>
		/// <para>Possible values for the socket type are defined in the Winsock2.h header file.</para>
		/// <para>The following table lists the possible values for the type parameter supported for Windows Sockets 2:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SOCK_STREAM 1</term>
		/// <term>
		/// A socket type that provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission mechanism.
		/// This socket type uses the Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_DGRAM 2</term>
		/// <term>
		/// A socket type that supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum length.
		/// This socket type uses the User Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RAW 3</term>
		/// <term>
		/// A socket type that provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To
		/// manipulate the IPv4 header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the
		/// IPV6_HDRINCL socket option must be set on the socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_RDM 4</term>
		/// <term>
		/// A socket type that provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM)
		/// multicast protocol implementation in Windows, often referred to as reliable multicast programming. This type value is only
		/// supported if the Reliable Multicast Protocol is installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SOCK_SEQPACKET 5</term>
		/// <term>A socket type that provides a pseudo-stream packet based on datagrams.</term>
		/// </item>
		/// </list>
		/// <para>
		/// In Windows Sockets 2, new socket types were introduced. An application can dynamically discover the attributes of each available
		/// transport protocol through the WSAEnumProtocols function. So an application can determine the possible socket type and protocol
		/// options for an address family and use this information when specifying this parameter. Socket type definitions in the Winsock2.h
		/// and Ws2def.h header files will be periodically updated as new socket types, address families, and protocols are defined.
		/// </para>
		/// <para>In Windows Sockets 1.1, the only possible socket types are <c>SOCK_DGRAM</c> and <c>SOCK_STREAM</c>.</para>
		/// </param>
		/// <param name="protocol">
		/// <para>
		/// The protocol to be used. The possible options for the protocol parameter are specific to the address family and socket type
		/// specified. Possible values for the protocol are defined in the Winsock2.h and Wsrm.h header files.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and this parameter can be
		/// one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h header
		/// file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// If a value of 0 is specified, the caller does not wish to specify a protocol and the service provider will choose the protocol to use.
		/// </para>
		/// <para>
		/// When the af parameter is AF_INET or AF_INET6 and the type is <c>SOCK_RAW</c>, the value specified for the protocol is set in the
		/// protocol field of the IPv6 or IPv4 packet header.
		/// </para>
		/// <para>The table below lists common values for the protocol although many other values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>protocol</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IPPROTO_ICMP 1</term>
		/// <term>
		/// The Internet Control Message Protocol (ICMP). This is a possible value when the af parameter is AF_UNSPEC, AF_INET, or AF_INET6
		/// and the type parameter is SOCK_RAW or unspecified. This protocol value is supported on Windows XP and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_IGMP 2</term>
		/// <term>
		/// The Internet Group Management Protocol (IGMP). This is a possible value when the af parameter is AF_UNSPEC, AF_INET, or AF_INET6
		/// and the type parameter is SOCK_RAW or unspecified. This protocol value is supported on Windows XP and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BTHPROTO_RFCOMM 3</term>
		/// <term>
		/// The Bluetooth Radio Frequency Communications (Bluetooth RFCOMM) protocol. This is a possible value when the af parameter is
		/// AF_BTH and the type parameter is SOCK_STREAM. This protocol value is supported on Windows XP with SP2 or later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_TCP 6</term>
		/// <term>
		/// The Transmission Control Protocol (TCP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type
		/// parameter is SOCK_STREAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_UDP 17</term>
		/// <term>
		/// The User Datagram Protocol (UDP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type parameter is SOCK_DGRAM.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_ICMPV6 58</term>
		/// <term>
		/// The Internet Control Message Protocol Version 6 (ICMPv6). This is a possible value when the af parameter is AF_UNSPEC, AF_INET,
		/// or AF_INET6 and the type parameter is SOCK_RAW or unspecified. This protocol value is supported on Windows XP and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IPPROTO_RM 113</term>
		/// <term>
		/// The PGM protocol for reliable multicast. This is a possible value when the af parameter is AF_INET and the type parameter is
		/// SOCK_RDM. On the Windows SDK released for Windows Vista and later, this protocol is also called IPPROTO_PGM. This protocol value
		/// is only supported if the Reliable Multicast Protocol is installed.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>socket</c> returns a descriptor referencing the new socket. Otherwise, a value of INVALID_SOCKET is
		/// returned, and a specific error code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem or the associated service provider has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The specified address family is not supported. For example, an application tried to create a socket for the AF_IRDA address
		/// family but an infrared adapter and device driver is not installed on the local computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEMFILE</term>
		/// <term>No more socket descriptors are available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid argument was supplied. This error is returned if the af parameter is set to AF_UNSPEC and the type and protocol
		/// parameter are unspecified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVALIDPROVIDER</term>
		/// <term>The service provider returned a version other than 2.2.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVALIDPROCTABLE</term>
		/// <term>The service provider returned an invalid or incomplete procedure table to the WSPStartup.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available. The socket cannot be created.</term>
		/// </item>
		/// <item>
		/// <term>WSAEPROTONOSUPPORT</term>
		/// <term>The specified protocol is not supported.</term>
		/// </item>
		/// <item>
		/// <term>WSAEPROTOTYPE</term>
		/// <term>The specified protocol is the wrong type for this socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEPROVIDERFAILEDINIT</term>
		/// <term>
		/// The service provider failed to initialize. This error is returned if a layered service provider (LSP) or namespace provider was
		/// improperly installed or the provider fails to operate correctly.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAESOCKTNOSUPPORT</term>
		/// <term>The specified socket type is not supported in this address family.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>socket</c> function causes a socket descriptor and any related resources to be allocated and bound to a specific
		/// transport-service provider. Winsock will utilize the first available service provider that supports the requested combination of
		/// address family, socket type and protocol parameters. The socket that is created will have the overlapped attribute as a default.
		/// For Windows, the Microsoft-specific socket option, SO_OPENTYPE, defined in Mswsock.h can affect this default. See
		/// Microsoft-specific documentation for a detailed description of SO_OPENTYPE.
		/// </para>
		/// <para>
		/// Sockets without the overlapped attribute can be created by using WSASocket. All functions that allow overlapped operation
		/// (WSASend, WSARecv, WSASendTo, WSARecvFrom, and WSAIoctl) also support nonoverlapped usage on an overlapped socket if the values
		/// for parameters related to overlapped operation are <c>NULL</c>.
		/// </para>
		/// <para>
		/// When selecting a protocol and its supporting service provider this procedure will only choose a base protocol or a protocol
		/// chain, not a protocol layer by itself. Unchained protocol layers are not considered to have partial matches on type or af either.
		/// That is, they do not lead to an error code of WSAEAFNOSUPPORT or WSAEPROTONOSUPPORT if no suitable protocol is found.
		/// </para>
		/// <para>
		/// <c>Note</c> The manifest constant <c>AF_UNSPEC</c> continues to be defined in the header file but its use is strongly
		/// discouraged, as this can cause ambiguity in interpreting the value of the protocol parameter.
		/// </para>
		/// <para>
		/// Applications are encouraged to use <c>AF_INET6</c> for the af parameter and create a dual-mode socket that can be used with both
		/// IPv4 and IPv6.
		/// </para>
		/// <para>
		/// Connection-oriented sockets such as <c>SOCK_STREAM</c> provide full-duplex connections, and must be in a connected state before
		/// any data can be sent or received on it. A connection to another socket is created with a connect call. Once connected, data can
		/// be transferred using send and recv calls. When a session has been completed, a closesocket must be performed.
		/// </para>
		/// <para>
		/// The communications protocols used to implement a reliable, connection-oriented socket ensure that data is not lost or duplicated.
		/// If data for which the peer protocol has buffer space cannot be successfully transmitted within a reasonable length of time, the
		/// connection is considered broken and subsequent calls will fail with the error code set to WSAETIMEDOUT.
		/// </para>
		/// <para>
		/// Connectionless, message-oriented sockets allow sending and receiving of datagrams to and from arbitrary peers using sendto and
		/// recvfrom. If such a socket is connected to a specific peer, datagrams can be sent to that peer using send and can be received
		/// only from this peer using recv.
		/// </para>
		/// <para>
		/// IPv6 and IPv4 operate differently when receiving a socket with a type of <c>SOCK_RAW</c>. The IPv4 receive packet includes the
		/// packet payload, the next upper-level header (for example, the IP header for a TCP or UDP packet), and the IPv4 packet header. The
		/// IPv6 receive packet includes the packet payload and the next upper-level header. The IPv6 receive packet never includes the IPv6
		/// packet header.
		/// </para>
		/// <para><c>Note</c> On Windows NT, raw socket support requires administrative privileges.</para>
		/// <para>
		/// A socket with a type parameter of <c>SOCK_SEQPACKET</c> is based on datagrams, but functions as a pseudo-stream protocol. For
		/// both send and receive packets, separate datagrams are used. However, Windows Sockets can coalesce multiple receive packets into a
		/// single packet. So an application can issue a receive call (for example, recv or WSARecvEx) and retrieve the data from several
		/// coalesced multiple packets in single call. The AF_NETBIOS address family supports a type parameter of <c>SOCK_SEQPACKET</c>.
		/// </para>
		/// <para>
		/// When the af parameter is <c>AF_NETBIOS</c> for NetBIOS over TCP/IP, the type parameter can be <c>SOCK_DGRAM</c> or
		/// <c>SOCK_SEQPACKET</c>. For the <c>AF_NETBIOS</c> address family, the protocol parameter is the LAN adapter number represented as
		/// a negative number.
		/// </para>
		/// <para>
		/// On Windows XP and later, the following command can be used to list the Windows Sockets catalog to determine the service providers
		/// installed and the address family, socket type, and protocols that are supported.
		/// </para>
		/// <para><c>netsh winsock show catalog</c></para>
		/// <para>
		/// Support for sockets with type <c>SOCK_RAW</c> is not required, but service providers are encouraged to support raw sockets as practicable.
		/// </para>
		/// <para>Notes for IrDA Sockets</para>
		/// <para>Keep the following in mind:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The Af_irda.h header file must be explicitly included.</term>
		/// </item>
		/// <item>
		/// <term>Only <c>SOCK_STREAM</c> is supported; the <c>SOCK_DGRAM</c> type is not supported by IrDA.</term>
		/// </item>
		/// <item>
		/// <term>The protocol parameter is always set to 0 for IrDA.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A socket for use with the AF_IRDA address family can only be created if the local computer has an infrared port and driver
		/// installed. Otherwise, a call to the <c>socket</c> function with af parameter set to AF_IRDA will fail and WSAGetLastError returns WSAEPROTONOSUPPORT.
		/// </para>
		/// <para>Example Code</para>
		/// <para>
		/// The following example demonstrates the use of the <c>socket</c> function to create a socket that is bound to a specific transport
		/// service provider..
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-socket SOCKET WSAAPI socket( int af, int type, int
		// protocol );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "6bf6e6c4-6268-479c-86a6-52e90cf317db")]
		public static extern SOCKET socket([MarshalAs(UnmanagedType.I4)] ADDRESS_FAMILY af, SOCK type, IPPROTO protocol);

		public static int SOMAXCONN_HINT(int b) => -b;

		/// <summary>
		/// The <c>WSAAccept</c> function conditionally accepts a connection based on the return value of a condition function, provides
		/// quality of service flow specifications, and allows the transfer of connection data.
		/// </summary>
		/// <param name="s">A descriptor that identifies a socket that is listening for connections after a call to the listen function.</param>
		/// <param name="addr">
		/// An optional pointer to an sockaddr structure that receives the address of the connecting entity, as known to the communications
		/// layer. The exact format of the addr parameter is determined by the address family established when the socket was created.
		/// </param>
		/// <param name="addrlen">
		/// An optional pointer to an integer that contains the length of the sockaddr structure pointed to by the addr parameter, in bytes.
		/// </param>
		/// <param name="lpfnCondition">
		/// The address of an optional, application-specified condition function that will make an accept/reject decision based on the caller
		/// information passed in as parameters, and optionally create or join a socket group by assigning an appropriate value to the result
		/// parameter g of this function. If this parameter is <c>NULL</c>, then no condition function is called.
		/// </param>
		/// <param name="dwCallbackData">
		/// Callback data passed back to the application-specified condition function as the value of the dwCallbackData parameter passed to
		/// the condition function. This parameter is only applicable if the lpfnCondition parameter is not <c>NULL</c>. This parameter is
		/// not interpreted by Windows Sockets.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAAccept</c> returns a value of type SOCKET that is a descriptor for the accepted socket. Otherwise, a
		/// value of INVALID_SOCKET is returned, and a specific error code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// The integer referred to by addrlen initially contains the amount of space pointed to by addr. On return it will contain the
		/// actual length in bytes of the address returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>
		/// An attempt was made to access a socket in a way forbidden by its access permissions. This error is returned if the connection
		/// request that was offered has timed out or been withdrawn.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAECONNREFUSED</term>
		/// <term>
		/// No connection could be made because the target machine actively refused it. This error is returned if the connection request was
		/// forcefully rejected as indicated in the return value of the condition function (CF_REJECT).
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>
		/// An existing connection was forcibly closed by the remote host. This error is returned of an incoming connection was indicated,
		/// but was subsequently terminated by the remote peer prior to accepting the call.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned of the
		/// addrlen parameter is too small or the addr or lpfnCondition is not part of the user address space.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>
		/// A blocking operation was interrupted by a call to WSACancelBlockingCall. This error is returned if a blocking Windows Sockets 1.1
		/// call was canceled through WSACancelBlockingCall.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking operation is currently executing. This error is returned if a blocking Windows Sockets 1.1 call is in progress.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid argument was supplied. This error is returned if listen was not invoked prior to WSAAccept, the return value of the
		/// condition function is not a valid one, or any case where the specified socket is in an invalid state.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEMFILE</term>
		/// <term>
		/// Too many open sockets. This error is returned if the queue is nonempty upon entry to WSAAccept and there are no socket
		/// descriptors available.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>A socket operation encountered a dead network. This error is returned if the network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>
		/// An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full.
		/// This error is returned if no buffer space is available.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>
		/// An operation was attempted on something that is not a socket. This error is returned if the socket descriptor passed in the s
		/// parameter is not a socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// The protocol family has not been configured into the system or no implementation for it exists. This error is returned if the
		/// referenced socket is not a type that supports connection-oriented service.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// A non-blocking socket operation could not be completed immediately. This error is returned if the socket is marked as nonblocking
		/// and no connections are present to be accepted.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// Either the application has not called WSAStartup, or WSAStartup failed. This error is returned of a successful call to the
		/// WSAStartup function dit not occur before using this function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>
		/// This is usually a temporary error during hostname resolution and means that the local server did not receive a response from an
		/// authoritative server. This error is returned if the acceptance of the connection request was deferred as indicated in the return
		/// value of the condition function (CF_DEFER).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAccept</c> function extracts the first connection on the queue of pending connections on socket s, and checks it
		/// against the condition function, provided the condition function is specified (that is, not <c>NULL</c>). If the condition
		/// function returns CF_ACCEPT, <c>WSAAccept</c> creates a new socket. The newly created socket has the same properties as socket s
		/// including asynchronous events registered with WSAAsyncSelect or with WSAEventSelect. If the condition function returns CF_REJECT,
		/// <c>WSAAccept</c> rejects the connection request. The condition function runs in the same thread as this function does, and should
		/// return as soon as possible. If the decision cannot be made immediately, the condition function should return CF_DEFER to indicate
		/// that no decision has been made, and no action about this connection request should be taken by the service provider. When the
		/// application is ready to take action on the connection request, it will invoke <c>WSAAccept</c> again and return either CF_ACCEPT
		/// or CF_REJECT as a return value from the condition function.
		/// </para>
		/// <para>
		/// A socket in default mode (blocking) will block until a connection is present when an application calls <c>WSAAccept</c> and no
		/// connections are pending on the queue.
		/// </para>
		/// <para>
		/// A socket in nonblocking mode (blocking) fails with the error WSAEWOULDBLOCK when an application calls <c>WSAAccept</c> and no
		/// connections are pending on the queue. After <c>WSAAccept</c> succeeds and returns a new socket handle, the accepted socket cannot
		/// be used to accept any more connections. The original socket remains open and listens for new connection requests.
		/// </para>
		/// <para>
		/// The addr parameter is a result parameter that is filled in with the address of the connecting entity, as known to the
		/// communications layer. The exact format of the addr parameter is determined by the address family in which the communication is
		/// occurring. The addrlen is a value-result parameter; it should initially contain the amount of space pointed to by addr. On
		/// return, it will contain the actual length (in bytes) of the address returned. This call is used with connection-oriented socket
		/// types such as SOCK_STREAM. If addr and/or addrlen are equal to <c>NULL</c>, then no information about the remote address of the
		/// accepted socket is returned. Otherwise, these two parameters will be filled in if the connection is successfully accepted.
		/// </para>
		/// <para>A prototype of the condition function is defined in the Winsock2.h header file as the <c>LPCONDITIONPROC</c> as follows:</para>
		/// <para>
		/// The <c>ConditionFunc</c> is a placeholder for the application-specified callback function. The actual condition function must
		/// reside in a DLL or application module. It is exported in the module definition file.
		/// </para>
		/// <para>
		/// The lpCallerId parameter points to a WSABUF structure that contains the address of the connecting entity, where its len parameter
		/// is the length of the buffer in bytes, and its buf parameter is a pointer to the buffer. The lpCallerData is a value parameter
		/// that contains any user data. The information in these parameters is sent along with the connection request. If no caller
		/// identification or caller data is available, the corresponding parameters will be <c>NULL</c>. Many network protocols do not
		/// support connect-time caller data. Most conventional network protocols can be expected to support caller identifier information at
		/// connection-request time. The buf portion of the WSABUF pointed to by lpCallerId points to a sockaddr. The <c>sockaddr</c>
		/// structure is interpreted according to its address family (typically by casting the <c>sockaddr</c> to some type specific to the
		/// address family).
		/// </para>
		/// <para>
		/// The lpSQOS parameter references the FLOWSPEC structures for socket s specified by the caller, one for each direction, followed by
		/// any additional provider-specific parameters. The sending or receiving flow specification values will be ignored as appropriate
		/// for any unidirectional sockets. A <c>NULL</c> value indicates that there is no caller-supplied quality of service and that no
		/// negotiation is possible. A non- <c>NULL</c> lpSQOS pointer indicates that a quality of service negotiation is to occur or that
		/// the provider is prepared to accept the quality of service request without negotiation.
		/// </para>
		/// <para>
		/// The lpGQOS parameter is reserved, and should be <c>NULL</c>. (reserved for future use with socket groups) references the FLOWSPEC
		/// structure for the socket group the caller is to create, one for each direction, followed by any additional provider-specific
		/// parameters. A <c>NULL</c> value for lpGQOS indicates no caller-specified group quality of service. Quality of service information
		/// can be returned if negotiation is to occur.
		/// </para>
		/// <para>
		/// The lpCalleeId is a parameter that contains the local address of the connected entity. The buf portion of the WSABUF pointed to
		/// by lpCalleeId points to a sockaddr structure. The <c>sockaddr</c> structure is interpreted according to its address family
		/// (typically by casting the <c>sockaddr</c> to some type specific to the address family such as struct <c>sockaddr_in</c>).
		/// </para>
		/// <para>
		/// The lpCalleeData is a result parameter used by the condition function to supply user data back to the connecting entity. The
		/// lpCalleeData-&gt;len initially contains the length of the buffer allocated by the service provider and pointed to by
		/// lpCalleeData-&gt;buf. A value of zero means passing user data back to the caller is not supported. The condition function should
		/// copy up to lpCalleeData-&gt;len bytes of data into lpCalleeData-&gt;buf, and then update lpCalleeData-&gt;len to indicate the
		/// actual number of bytes transferred. If no user data is to be passed back to the caller, the condition function should set
		/// lpCalleeData-&gt;len to zero. The format of all address and user data is specific to the address family to which the socket belongs.
		/// </para>
		/// <para>The g parameter is assigned within the condition function to indicate any of the following actions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If g is an existing socket group identifier, add s to this group, provided all the requirements set by this group are met.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If g = SG_UNCONSTRAINED_GROUP, create an unconstrained socket group and have s as the first member.</term>
		/// </item>
		/// <item>
		/// <term>If g = SG_CONSTRAINED_GROUP, create a constrained socket group and have s as the first member.</term>
		/// </item>
		/// <item>
		/// <term>If g = zero, no group operation is performed.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For unconstrained groups, any set of sockets can be grouped together as long as they are supported by a single service provider.
		/// A constrained socket group can consist only of connection-oriented sockets, and requires that connections on all grouped sockets
		/// be to the same address on the same host. For newly created socket groups, the new group identifier can be retrieved by using
		/// getsockopt function with level parameter set to SOL_SOCKET and the optname parameter set to <c>SO_GROUP_ID</c>. A socket group
		/// and its associated socket group ID remain valid until the last socket belonging to this socket group is closed. Socket group IDs
		/// are unique across all processes for a given service provider. A socket group and its associated identifier remain valid until the
		/// last socket belonging to this socket group is closed. Socket group identifiers are unique across all processes for a given
		/// service provider. For more information on socket groups, see the Remarks for the WSASocket functions.
		/// </para>
		/// <para>
		/// The dwCallbackData parameter value passed to the condition function is the value passed as the dwCallbackData parameter in the
		/// original <c>WSAAccept</c> call. This value is interpreted only by the Windows Socket version 2 client. This allows a client to
		/// pass some context information from the <c>WSAAccept</c> call site through to the condition function. This also provides the
		/// condition function with any additional information required to determine whether to accept the connection or not. A typical usage
		/// is to pass a (suitably cast) pointer to a data structure containing references to application-defined objects with which this
		/// socket is associated.
		/// </para>
		/// <para>
		/// <c>Note</c> To protect use of the <c>WSAAccept</c> function from SYN attacks, applications must perform full TCP handshakes
		/// (SYN-SYNACK-ACK) before reporting the connection request. Protecting against SYN attacks in this manner results in the
		/// SO_CONDITIONAL_ACCEPT socket option becoming inoperative; the conditional function is still called, and the <c>WSAAccept</c>
		/// function operates properly, but server applications that rely on clients being unable to perform the handshake will not operate properly.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSAAccept</c>, Winsock may need to wait for a network event before
		/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>WSAAccept</c> function.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-wsaaccept SOCKET WSAAPI WSAAccept( SOCKET s, sockaddr
		// *addr, LPINT addrlen, LPCONDITIONPROC lpfnCondition, DWORD_PTR dwCallbackData );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "f385f63f-49b2-4eb7-8717-ad4cca1a2252")]
		public static extern SOCKET WSAAccept(SOCKET s, SOCKADDR addr, ref int addrlen, [In, Out, Optional] LPCONDITIONPROC lpfnCondition, [In, Out, Optional] IntPtr dwCallbackData);

		/// <summary>
		/// <para>
		/// The <c>WSAAddressToString</c> function converts all components of a sockaddr structure into a human-readable string
		/// representation of the address.
		/// </para>
		/// <para>
		/// This is intended to be used mainly for display purposes. If the caller requires that the translation to be performed by a
		/// particular provider, it should supply the corresponding WSAPROTOCOL_INFO structure in the lpProtocolInfo parameter.
		/// </para>
		/// </summary>
		/// <param name="lpsaAddress">A pointer to the sockaddr structure to translate into a string.</param>
		/// <param name="dwAddressLength">
		/// The length, in bytes, of the address in the sockaddr structure pointed to by the lpsaAddress parameter. The dwAddressLength
		/// parameter may vary in size with different protocols.
		/// </param>
		/// <param name="lpProtocolInfo">
		/// A pointer to the WSAPROTOCOL_INFO structure for a particular provider. If this is parameter is <c>NULL</c>, the call is routed to
		/// the provider of the first protocol supporting the address family indicated in the lpsaAddress parameter.
		/// </param>
		/// <param name="lpszAddressString">A pointer to the buffer that receives the human-readable address string.</param>
		/// <param name="lpdwAddressStringLength">
		/// On input, this parameter specifies the length of the buffer pointed to by the lpszAddressString parameter. The length is
		/// represented in bytes for ANSI strings, and in WCHARs for Unicode strings. On output, this parameter returns the length of the
		/// string including the <c>NULL</c> terminator actually copied into the buffer pointed to by the lpszAddressString parameter. If the
		/// specified buffer is not large enough, the function fails with a specific error of WSAEFAULT and this parameter is updated with
		/// the required size.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAAddressToString</c> returns a value of zero. Otherwise, the value SOCKET_ERROR is returned, and a
		/// specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The specified lpcsAddress, lpProtocolInfo, and lpszAddressString parameters point to memory that is not all in the address space
		/// of the process, or the buffer pointed to by the lpszAddressString parameter is too small. Pass in a larger buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid parameter was passed. This error is returned if the lpsaAddress, dwAddressLength, or lpdwAddressStringLength parameter
		/// are NULL. This error is also returned if the specified address is not a valid socket address, or no transport provider supports
		/// the indicated address family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The Winsock 2 DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAddressToString</c> function provides a protocol-independent address-to-string translation. The
		/// <c>WSAAddressToString</c> function takes a socket address structure pointed to by the lpsaAddress parameter and returns a pointer
		/// to <c>NULL</c>-terminated string that represents the socket address in the lpszAddressString parameter. While the inet_ntoa
		/// function works only with IPv4 addresses, the <c>WSAAddressToString</c> function works with any socket address supported by a
		/// Winsock provider on the local computer including IPv6 addresses.
		/// </para>
		/// <para>
		/// If the lpsaAddress parameter points to an IPv4 socket address (the address family is <c>AF_INET</c>), then the address string
		/// returned in the buffer pointed to by the lpszAddressString parameter is in dotted-decimal notation as in "192.168.16.0", an
		/// example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the lpsaAddress parameter points to an IPv6 socket address (the address family is <c>AF_INET6</c>), then the address string
		/// returned in the buffer pointed to by the lpszAddressString parameter is in Internet standard format. The basic string
		/// representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero numbers is replaced with a
		/// double-colon. There can only be one double-colon in the string representation of the IPv6 address.
		/// </para>
		/// <para>
		/// If the length of the buffer pointed to by the lpszAddressString parameter is not large enough to receive the string
		/// representation of the socket address, <c>WSAAddressToString</c> returns WSAEFAULT.
		/// </para>
		/// <para>
		/// Support for IPv6 addresses using the <c>WSAAddressToString</c> function was added on Windows XP with Service Pack 1 (SP1)and
		/// later. IPv6 must also be installed on the local computer for the <c>WSAAddressToString</c> function to support IPv6 addresses.
		/// </para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSAAddressToStringW</c> function is supported for Windows Phone Store apps on Windows Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAAddressToStringW</c> function is supported for Windows Store apps
		/// on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-wsaaddresstostringa INT WSAAPI WSAAddressToStringA(
		// LPSOCKADDR lpsaAddress, DWORD dwAddressLength, LPWSAPROTOCOL_INFOA lpProtocolInfo, LPSTR lpszAddressString, LPDWORD
		// lpdwAddressStringLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "d72e55e6-79a9-4386-9e1a-24a322f13426")]
		public static extern int WSAAddressToString([In] SOCKADDR lpsaAddress, uint dwAddressLength, in WSAPROTOCOL_INFO lpProtocolInfo, StringBuilder lpszAddressString, ref uint lpdwAddressStringLength);

		/// <summary>
		/// <para>
		/// The <c>WSAAddressToString</c> function converts all components of a sockaddr structure into a human-readable string
		/// representation of the address.
		/// </para>
		/// <para>
		/// This is intended to be used mainly for display purposes. If the caller requires that the translation to be performed by a
		/// particular provider, it should supply the corresponding WSAPROTOCOL_INFO structure in the lpProtocolInfo parameter.
		/// </para>
		/// </summary>
		/// <param name="lpsaAddress">A pointer to the sockaddr structure to translate into a string.</param>
		/// <param name="dwAddressLength">
		/// The length, in bytes, of the address in the sockaddr structure pointed to by the lpsaAddress parameter. The dwAddressLength
		/// parameter may vary in size with different protocols.
		/// </param>
		/// <param name="lpProtocolInfo">
		/// A pointer to the WSAPROTOCOL_INFO structure for a particular provider. If this is parameter is <c>NULL</c>, the call is routed to
		/// the provider of the first protocol supporting the address family indicated in the lpsaAddress parameter.
		/// </param>
		/// <param name="lpszAddressString">A pointer to the buffer that receives the human-readable address string.</param>
		/// <param name="lpdwAddressStringLength">
		/// On input, this parameter specifies the length of the buffer pointed to by the lpszAddressString parameter. The length is
		/// represented in bytes for ANSI strings, and in WCHARs for Unicode strings. On output, this parameter returns the length of the
		/// string including the <c>NULL</c> terminator actually copied into the buffer pointed to by the lpszAddressString parameter. If the
		/// specified buffer is not large enough, the function fails with a specific error of WSAEFAULT and this parameter is updated with
		/// the required size.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAAddressToString</c> returns a value of zero. Otherwise, the value SOCKET_ERROR is returned, and a
		/// specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The specified lpcsAddress, lpProtocolInfo, and lpszAddressString parameters point to memory that is not all in the address space
		/// of the process, or the buffer pointed to by the lpszAddressString parameter is too small. Pass in a larger buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid parameter was passed. This error is returned if the lpsaAddress, dwAddressLength, or lpdwAddressStringLength parameter
		/// are NULL. This error is also returned if the specified address is not a valid socket address, or no transport provider supports
		/// the indicated address family.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The Winsock 2 DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAddressToString</c> function provides a protocol-independent address-to-string translation. The
		/// <c>WSAAddressToString</c> function takes a socket address structure pointed to by the lpsaAddress parameter and returns a pointer
		/// to <c>NULL</c>-terminated string that represents the socket address in the lpszAddressString parameter. While the inet_ntoa
		/// function works only with IPv4 addresses, the <c>WSAAddressToString</c> function works with any socket address supported by a
		/// Winsock provider on the local computer including IPv6 addresses.
		/// </para>
		/// <para>
		/// If the lpsaAddress parameter points to an IPv4 socket address (the address family is <c>AF_INET</c>), then the address string
		/// returned in the buffer pointed to by the lpszAddressString parameter is in dotted-decimal notation as in "192.168.16.0", an
		/// example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the lpsaAddress parameter points to an IPv6 socket address (the address family is <c>AF_INET6</c>), then the address string
		/// returned in the buffer pointed to by the lpszAddressString parameter is in Internet standard format. The basic string
		/// representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero numbers is replaced with a
		/// double-colon. There can only be one double-colon in the string representation of the IPv6 address.
		/// </para>
		/// <para>
		/// If the length of the buffer pointed to by the lpszAddressString parameter is not large enough to receive the string
		/// representation of the socket address, <c>WSAAddressToString</c> returns WSAEFAULT.
		/// </para>
		/// <para>
		/// Support for IPv6 addresses using the <c>WSAAddressToString</c> function was added on Windows XP with Service Pack 1 (SP1)and
		/// later. IPv6 must also be installed on the local computer for the <c>WSAAddressToString</c> function to support IPv6 addresses.
		/// </para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSAAddressToStringW</c> function is supported for Windows Phone Store apps on Windows Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAAddressToStringW</c> function is supported for Windows Store apps
		/// on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-wsaaddresstostringa INT WSAAPI WSAAddressToStringA(
		// LPSOCKADDR lpsaAddress, DWORD dwAddressLength, LPWSAPROTOCOL_INFOA lpProtocolInfo, LPSTR lpszAddressString, LPDWORD
		// lpdwAddressStringLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "d72e55e6-79a9-4386-9e1a-24a322f13426")]
		public static extern int WSAAddressToString([In] SOCKADDR lpsaAddress, uint dwAddressLength, [Optional] IntPtr lpProtocolInfo, StringBuilder lpszAddressString, ref uint lpdwAddressStringLength);

		/// <summary>The <c>WSACleanup</c> function terminates use of the Winsock 2 DLL (Ws2_32.dll).</summary>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>In a multithreaded environment, <c>WSACleanup</c> terminates Windows Sockets operations for all threads.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application or DLL is required to perform a successful WSAStartup call before it can use Windows Sockets services. When it has
		/// completed the use of Windows Sockets, the application or DLL must call <c>WSACleanup</c> to deregister itself from a Windows
		/// Sockets implementation and allow the implementation to free any resources allocated on behalf of the application or DLL.
		/// </para>
		/// <para>
		/// When <c>WSACleanup</c> is called, any pending blocking or asynchronous Windows Sockets calls issued by any thread in this process
		/// are canceled without posting any notification messages or without signaling any event objects. Any pending overlapped send or
		/// receive operations (WSASend, WSASendTo, WSARecv, or WSARecvFrom with an overlapped socket, for example) issued by any thread in
		/// this process are also canceled without setting the event object or invoking the completion routine, if one was specified. In this
		/// case, the pending overlapped operations fail with the error status <c>WSA_OPERATION_ABORTED</c>.
		/// </para>
		/// <para>
		/// Sockets that were open when <c>WSACleanup</c> was called are reset and automatically deallocated as if closesocket were called.
		/// Sockets that have been closed with <c>closesocket</c> but that still have pending data to be sent can be affected when
		/// <c>WSACleanup</c> is called. In this case, the pending data can be lost if the WS2_32.DLL is unloaded from memory as the
		/// application exits. To ensure that all pending data is sent, an application should use shutdown to close the connection, then wait
		/// until the close completes before calling <c>closesocket</c> and <c>WSACleanup</c>. All resources and internal state, such as
		/// queued unposted or posted messages, must be deallocated so as to be available to the next user.
		/// </para>
		/// <para>
		/// There must be a call to <c>WSACleanup</c> for each successful call to WSAStartup. Only the final <c>WSACleanup</c> function call
		/// performs the actual cleanup. The preceding calls simply decrement an internal reference count in the WS2_32.DLL.
		/// </para>
		/// <para>
		/// <c>Note</c><c>WSACleanup</c> does not unregister names (peer names, for example) that may have been registered with a Windows
		/// Sockets namespace provider such as Peer Name Resolution Protocol (PNRP) namespace provider.
		/// </para>
		/// <para>
		/// In Windows Sockets 1.1, attempting to call <c>WSACleanup</c> from within a blocking hook and then failing to check the return
		/// code was a common programming error. If a Winsock 1.1 application needs to quit while a blocking call is outstanding, the
		/// application has to first cancel the blocking call with WSACancelBlockingCall then issue the <c>WSACleanup</c> call once control
		/// has been returned to the application. In Windows Sockets 2, this issue does not exist and the <c>WSACancelBlockingCall</c>
		/// function has been removed.
		/// </para>
		/// <para>
		/// The <c>WSACleanup</c> function typically leads to protocol-specific helper DLLs being unloaded. As a result, the
		/// <c>WSACleanup</c> function should not be called from the DllMain function in a application DLL. This can potentially cause
		/// deadlocks. For more information, please see the DLL Main Function.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-wsacleanup int WSACleanup( );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "72b7cc3e-be34-41e7-acbf-61742149ec8b")]
		public static extern int WSACleanup();

		/// <summary>The <c>WSAStartup</c> function initiates use of the Winsock DLL by a process.</summary>
		/// <param name="wVersionRequired">TBD</param>
		/// <param name="lpWSAData">A pointer to the WSADATA data structure that is to receive details of the Windows Sockets implementation.</param>
		/// <returns>
		/// <para>If successful, the <c>WSAStartup</c> function returns zero. Otherwise, it returns one of the error codes listed below.</para>
		/// <para>
		/// The <c>WSAStartup</c> function directly returns the extended error code in the return value for this function. A call to the
		/// WSAGetLastError function is not needed and should not be used.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSASYSNOTREADY</term>
		/// <term>The underlying network subsystem is not ready for network communication.</term>
		/// </item>
		/// <item>
		/// <term>WSAVERNOTSUPPORTED</term>
		/// <term>The version of Windows Sockets support requested is not provided by this particular Windows Sockets implementation.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 operation is in progress.</term>
		/// </item>
		/// <item>
		/// <term>WSAEPROCLIM</term>
		/// <term>A limit on the number of tasks supported by the Windows Sockets implementation has been reached.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpWSAData parameter is not a valid pointer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAStartup</c> function must be the first Windows Sockets function called by an application or DLL. It allows an
		/// application or DLL to specify the version of Windows Sockets required and retrieve details of the specific Windows Sockets
		/// implementation. The application or DLL can only issue further Windows Sockets functions after successfully calling <c>WSAStartup</c>.
		/// </para>
		/// <para>
		/// In order to support various Windows Sockets implementations and applications that can have functional differences from the latest
		/// version of Windows Sockets specification, a negotiation takes place in <c>WSAStartup</c>. The caller of <c>WSAStartup</c> passes
		/// in the wVersionRequested parameter the highest version of the Windows Sockets specification that the application supports. The
		/// Winsock DLL indicates the highest version of the Windows Sockets specification that it can support in its response. The Winsock
		/// DLL also replies with version of the Windows Sockets specification that it expects the caller to use.
		/// </para>
		/// <para>
		/// When an application or DLL calls the <c>WSAStartup</c> function, the Winsock DLL examines the version of the Windows Sockets
		/// specification requested by the application passed in the wVersionRequested parameter. If the version requested by the application
		/// is equal to or higher than the lowest version supported by the Winsock DLL, the call succeeds and the Winsock DLL returns
		/// detailed information in the WSADATA structure pointed to by the lpWSAData parameter. The <c>wHighVersion</c> member of the
		/// <c>WSADATA</c> structure indicates the highest version of the Windows Sockets specification that the Winsock DLL supports. The
		/// <c>wVersion</c> member of the <c>WSADATA</c> structure indicates the version of the Windows Sockets specification that the
		/// Winsock DLL expects the caller to use.
		/// </para>
		/// <para>
		/// If the <c>wVersion</c> member of the WSADATA structure is unacceptable to the caller, the application or DLL should call
		/// WSACleanup to release the Winsock DLL resources and fail to initialize the Winsock application. In order to support this
		/// application or DLL, it will be necessary to search for an updated version of the Winsock DLL to install on the platform.
		/// </para>
		/// <para>
		/// The current version of the Windows Sockets specification is version 2.2. The current Winsock DLL, Ws2_32.dll, supports
		/// applications that request any of the following versions of Windows Sockets specification:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>1.0</term>
		/// </item>
		/// <item>
		/// <term>1.1</term>
		/// </item>
		/// <item>
		/// <term>2.0</term>
		/// </item>
		/// <item>
		/// <term>2.1</term>
		/// </item>
		/// <item>
		/// <term>2.2</term>
		/// </item>
		/// </list>
		/// <para>
		/// To get full access to the new syntax of a higher version of the Windows Sockets specification, the application must negotiate for
		/// this higher version. In this case, the wVersionRequested parameter should be set to request version 2.2. The application must
		/// also fully conform to that higher version of the Windows Socket specification, such as compiling against the appropriate header
		/// file, linking with a new library, or other special cases. The Winsock2.h header file for Winsock 2 support is included with the
		/// Microsoft Windows Software Development Kit (SDK).
		/// </para>
		/// <para>
		/// Windows Sockets version 2.2 is supported on Windows Server 2008, Windows Vista, Windows Server 2003, Windows XP, Windows 2000,
		/// Windows NT 4.0 with Service Pack 4 (SP4) and later, Windows Me, Windows 98, and Windows 95 OSR2. Windows Sockets version 2.2 is
		/// also supported on Windows 95 with the Windows Socket 2 Update. Applications on these platforms should normally request Winsock
		/// 2.2 by setting the wVersionRequested parameter accordingly.
		/// </para>
		/// <para>
		/// On Windows 95 and versions of Windows NT 3.51 and earlier, Windows Sockets version 1.1 is the highest version of the Windows
		/// Sockets specification supported.
		/// </para>
		/// <para>
		/// It is legal and possible for an application or DLL written to use a lower version of the Windows Sockets specification that is
		/// supported by the Winsock DLL to successfully negotiate this lower version using the <c>WSAStartup</c> function. For example, an
		/// application can request version 1.1 in the wVersionRequested parameter passed to the <c>WSAStartup</c> function on a platform
		/// with the Winsock 2.2 DLL. In this case, the application should only rely on features that fit within the version requested. New
		/// Ioctl codes, new behavior of existing functions, and new functions should not be used. The version negotiation provided by the
		/// <c>WSAStartup</c> was primarily used to allow older Winsock 1.1 applications developed for Windows 95 and Windows NT 3.51 and
		/// earlier to run with the same behavior on later versions of Windows. The Winsock.h header file for Winsock 1.1 support is included
		/// with the Windows SDK.
		/// </para>
		/// <para>
		/// This negotiation in the <c>WSAStartup</c> function allows both the application or DLL that uses Windows Sockets and the Winsock
		/// DLL to support a range of Windows Sockets versions. An application or DLL can use the Winsock DLL if there is any overlap in the
		/// version ranges. Detailed information on the Windows Sockets implementation is provided in the WSADATA structure returned by the
		/// <c>WSAStartup</c> function.
		/// </para>
		/// <para>The following table shows how <c>WSAStartup</c> works with different applications and Winsock DLL versions.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Caller version support</term>
		/// <term>Winsock DLL version support</term>
		/// <term>wVersion requested</term>
		/// <term>wVersion returned</term>
		/// <term>wHighVersion returned</term>
		/// <term>End result</term>
		/// </listheader>
		/// <item>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>use 1.1</term>
		/// </item>
		/// <item>
		/// <term>1.0 1.1</term>
		/// <term>1.0</term>
		/// <term>1.1</term>
		/// <term>1.0</term>
		/// <term>1.0</term>
		/// <term>use 1.0</term>
		/// </item>
		/// <item>
		/// <term>1.0</term>
		/// <term>1.0 1.1</term>
		/// <term>1.0</term>
		/// <term>1.0</term>
		/// <term>1.1</term>
		/// <term>use 1.0</term>
		/// </item>
		/// <item>
		/// <term>1.1</term>
		/// <term>1.0 1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>use 1.1</term>
		/// </item>
		/// <item>
		/// <term>1.1</term>
		/// <term>1.0</term>
		/// <term>1.1</term>
		/// <term>1.0</term>
		/// <term>1.0</term>
		/// <term>Application fails</term>
		/// </item>
		/// <item>
		/// <term>1.0</term>
		/// <term>1.1</term>
		/// <term>1.0</term>
		/// <term>—</term>
		/// <term>—</term>
		/// <term>WSAVERNOTSUPPORTED</term>
		/// </item>
		/// <item>
		/// <term>1.0 1.1</term>
		/// <term>1.0 1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>use 1.1</term>
		/// </item>
		/// <item>
		/// <term>1.1 2.0</term>
		/// <term>1.0 1.1</term>
		/// <term>2.0</term>
		/// <term>1.1</term>
		/// <term>1.1</term>
		/// <term>use 1.1</term>
		/// </item>
		/// <item>
		/// <term>2.0</term>
		/// <term>1.0 1.1 2.0</term>
		/// <term>2.0</term>
		/// <term>2.0</term>
		/// <term>2.0</term>
		/// <term>use 2.0</term>
		/// </item>
		/// <item>
		/// <term>2.0 2.2</term>
		/// <term>1.0 1.1 2.0</term>
		/// <term>2.2</term>
		/// <term>2.0</term>
		/// <term>2.0</term>
		/// <term>use 2.0</term>
		/// </item>
		/// <item>
		/// <term>2.2</term>
		/// <term>1.0 1.1 2.0 2.1 2.2</term>
		/// <term>2.2</term>
		/// <term>2.2</term>
		/// <term>2.2</term>
		/// <term>use 2.2</term>
		/// </item>
		/// </list>
		/// <para>
		/// Once an application or DLL has made a successful <c>WSAStartup</c> call, it can proceed to make other Windows Sockets calls as
		/// needed. When it has finished using the services of the Winsock DLL, the application must call WSACleanup to allow the Winsock DLL
		/// to free internal Winsock resources used by the application.
		/// </para>
		/// <para>
		/// An application can call <c>WSAStartup</c> more than once if it needs to obtain the WSADATA structure information more than once.
		/// On each such call, the application can specify any version number supported by the Winsock DLL.
		/// </para>
		/// <para>
		/// The <c>WSAStartup</c> function typically leads to protocol-specific helper DLLs being loaded. As a result, the <c>WSAStartup</c>
		/// function should not be called from the DllMain function in a application DLL. This can potentially cause deadlocks. For more
		/// information, please see the DLL Main Function.
		/// </para>
		/// <para>
		/// An application must call the WSACleanup function for every successful time the <c>WSAStartup</c> function is called. This means,
		/// for example, that if an application calls <c>WSAStartup</c> three times, it must call <c>WSACleanup</c> three times. The first
		/// two calls to <c>WSACleanup</c> do nothing except decrement an internal counter; the final <c>WSACleanup</c> call for the task
		/// does all necessary resource deallocation for the task.
		/// </para>
		/// <para>
		/// <c>Note</c> An application can call the WSAGetLastError function to determine the extended error code for other Windows sockets
		/// functions as is normally done in Windows Sockets even if the <c>WSAStartup</c> function fails or the <c>WSAStartup</c> function
		/// was not called to properly initialize Windows Sockets before calling a Windows Sockets function. The <c>WSAGetLastError</c>
		/// function is one of the only functions in the Winsock 2.2 DLL that can be called in the case of a <c>WSAStartup</c> failure.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code fragment demonstrates how an application that supports only version 2.2 of Windows Sockets makes a
		/// <c>WSAStartup</c> call:
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-wsastartup int WSAStartup( WORD wVersionRequired,
		// LPWSADATA lpWSAData );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "08299592-867c-491d-9769-d16602133659")]
		public static extern int WSAStartup(ushort wVersionRequired, out WSADATA lpWSAData);

		/*WSAAsyncGetHostByAddr function
		WSAAsyncGetHostByName function
		WSAAsyncGetProtoByName function
		WSAAsyncGetProtoByNumber function
		WSAAsyncGetServByName function
		WSAAsyncGetServByPort function
		WSAAsyncSelect function
		WSACancelAsyncRequest function
		WSACancelBlockingCall function
		WSACloseEvent function
		WSAConnect function
		WSAConnectByList function
		WSAConnectByNameA function
		WSAConnectByNameW function
		WSACreateEvent function
		WSADuplicateSocketA function
		WSADuplicateSocketW function
		WSAEnumNameSpaceProvidersA function
		WSAEnumNameSpaceProvidersExA function
		WSAEnumNameSpaceProvidersExW function
		WSAEnumNameSpaceProvidersW function
		WSAEnumNetworkEvents function
		WSAEnumProtocolsA function
		WSAEnumProtocolsW function
		WSAEventSelect function
		WSAGetLastError function
		WSAGetOverlappedResult function
		WSAGetQOSByName function
		WSAGetServiceClassInfoA function
		WSAGetServiceClassInfoW function
		WSAGetServiceClassNameByClassIdA function
		WSAGetServiceClassNameByClassIdW function
		WSAHtonl function
		WSAHtons function
		WSAInstallServiceClassA function
		WSAInstallServiceClassW function
		WSAIoctl function
		WSAIsBlocking function
		WSAJoinLeaf function
		WSALookupServiceBeginA function
		WSALookupServiceBeginW function
		WSALookupServiceEnd function
		WSALookupServiceNextA function
		WSALookupServiceNextW function
		WSANSPIoctl function
		WSANtohl function
		WSANtohs function
		WSAPoll function
		WSAProviderConfigChange function
		WSARecv function
		WSARecvDisconnect function
		WSARecvFrom function
		WSARemoveServiceClass function
		WSAResetEvent function
		WSASend function
		WSASendDisconnect function
		WSASendMsg function
		WSASendTo function
		WSASetBlockingHook function
		WSASetEvent function
		WSASetLastError function
		WSASetServiceA function
		WSASetServiceW function
		WSASocketA function
		WSASocketW function
		WSAStringToAddressA function
		WSAStringToAddressW function
		WSAUnhookBlockingHook function
		WSAWaitForMultipleEvents function*/

		/// <summary>The IN_ADDR structure represents an IPv4 address.</summary>
		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IN_ADDR
		{
			/// <summary>An IPv4 address formatted as a u_long.</summary>
			public uint S_addr;

			/// <summary>Initializes a new instance of the <see cref="IN_ADDR"/> struct.</summary>
			/// <param name="v4addr">An IPv4 address.</param>
			public IN_ADDR(uint v4addr) => S_addr = v4addr;

			/// <summary>Initializes a new instance of the <see cref="IN_ADDR"/> struct.</summary>
			/// <param name="v4addr">An IPv4 address</param>
			/// <exception cref="ArgumentException">Byte array must have 4 items. - v4addr</exception>
			public IN_ADDR(byte[] v4addr)
			{
				if (v4addr == null && v4addr.Length != 4)
					throw new ArgumentException("Byte array must have 4 items.", nameof(v4addr));
				S_addr = BitConverter.ToUInt32(v4addr, 0);
			}

			/// <summary>Initializes a new instance of the <see cref="IN_ADDR"/> struct.</summary>
			/// <param name="b1">The first byte.</param>
			/// <param name="b2">The second byte.</param>
			/// <param name="b3">The third byte.</param>
			/// <param name="b4">The fourth byte.</param>
			public IN_ADDR(byte b1, byte b2, byte b3, byte b4) => S_addr = b1 | (uint)b2 << 8 | (uint)b3 << 16 | (uint)b4 << 24;

			/// <summary>Gets the address represented as four bytes.</summary>
			/// <value>An IPv4 address formatted as four u_chars.</value>
			public byte[] S_un_b => BitConverter.GetBytes(S_addr);

			/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="System.UInt32"/>.</summary>
			/// <param name="a">An IN_ADDR value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator uint(IN_ADDR a) => a.S_addr;

			/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="System.Int64"/>.</summary>
			/// <param name="a">An IN_ADDR value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator long(IN_ADDR a) => a.S_addr;

			/// <summary>Performs an implicit conversion from <see cref="IN_ADDR"/> to <see cref="T:byte[]"/>.</summary>
			/// <param name="a">An IN_ADDR value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator byte[] (IN_ADDR a) => BitConverter.GetBytes(a.S_addr);

			/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="IN_ADDR"/>.</summary>
			/// <param name="a">A UInt32 value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IN_ADDR(uint a) => new IN_ADDR(a);

			/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="IN_ADDR"/>.</summary>
			/// <param name="a">An Int64 value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IN_ADDR(long a) => new IN_ADDR((uint)a);

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString()
			{
				var b = S_un_b;
				return $"{b[0]}.{b[1]}.{b[2]}.{b[3]}";
			}
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Size = IN6_ADDR_SIZE)]
		public struct IN6_ADDR : IEquatable<IN6_ADDR>
		{
			private const int IN6_ADDR_SIZE = 16;

			private ulong lower;
			private ulong upper;

			public static readonly IN6_ADDR Loopback = new IN6_ADDR { lower = 0xff_01_00_00_00_00_00_00, upper = 0x00_00_00_00_00_00_00_01 };
			public static readonly IN6_ADDR Unspecified = new IN6_ADDR { lower = 0, upper = 0 };

			public IN6_ADDR(byte[] v6addr)
			{
				lower = upper = 0;
				bytes = v6addr;
			}

			public unsafe byte[] bytes
			{
				get
				{
					var v6addr = new byte[IN6_ADDR_SIZE];
					fixed (byte* usp = &v6addr[0])
					{
						var ulp2 = (ulong*)usp;
						ulp2[0] = lower;
						ulp2[1] = upper;
					}
					return v6addr;
				}
				set
				{
					if (value == null) value = new byte[IN6_ADDR_SIZE];
					if (value.Length != IN6_ADDR_SIZE)
						throw new ArgumentException("Byte array must have 16 items.", nameof(value));
					fixed (byte* bp = &value[0])
					{
						var ulp = (ulong*)bp;
						lower = ulp[0];
						upper = ulp[1];
					}
				}
			}

			public unsafe ushort[] words
			{
				get
				{
					var v6addr = new ushort[IN6_ADDR_SIZE / 2];
					fixed (ushort* usp = &v6addr[0])
					{
						var ulp2 = (ulong*)usp;
						ulp2[0] = lower;
						ulp2[1] = upper;
					}
					return v6addr;
				}
				set
				{
					if (value == null) value = new ushort[IN6_ADDR_SIZE / 2];
					if (value.Length != IN6_ADDR_SIZE / 2)
						throw new ArgumentException("UInt16 array must have 8 items.", nameof(value));
					fixed (ushort* bp = &value[0])
					{
						var ulp = (ulong*)bp;
						lower = ulp[0];
						upper = ulp[1];
					}
				}
			}

			public static implicit operator IN6_ADDR(byte[] a) => new IN6_ADDR(a);

			public static implicit operator byte[] (IN6_ADDR a) => a.bytes;

			public override string ToString()
			{
				const string numberFormat = "{0:x4}:{1:x4}:{2:x4}:{3:x4}:{4:x4}:{5:x4}:{6}.{7}.{8}.{9}";
				var m_Numbers = words;
				return string.Format(System.Globalization.CultureInfo.InvariantCulture, numberFormat,
					m_Numbers[0], m_Numbers[1], m_Numbers[2], m_Numbers[3], m_Numbers[4], m_Numbers[5],
					((m_Numbers[6] >> 8) & 0xFF), (m_Numbers[6] & 0xFF), ((m_Numbers[7] >> 8) & 0xFF), (m_Numbers[7] & 0xFF));
			}

			public bool Equals(IN6_ADDR other) => lower == other.lower && upper == other.upper;
		}

		/// <summary>
		/// The <c>QOS</c> structure provides the means by which QOS-enabled applications can specify quality of service parameters for sent
		/// and received traffic on a particular flow.
		/// </summary>
		/// <remarks>
		/// Most applications can fulfill their quality of service requirements without using the ProviderSpecific buffer. However, if the
		/// application must provide information not available with standard Windows 2000 QOS parameters, the ProviderSpecific buffer allows
		/// the application to provide additional parameters for RSVP and/or traffic control.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/ns-winsock2-_qualityofservice typedef struct _QualityOfService {
		// FLOWSPEC SendingFlowspec; FLOWSPEC ReceivingFlowspec; WSABUF ProviderSpecific; } QOS, *LPQOS;
		[PInvokeData("winsock2.h", MSDNShortId = "859faa13-bd66-46ee-8452-6ff5d53d66c9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct QOS
		{
			/// <summary>
			/// Specifies QOS parameters for the sending direction of a particular flow. SendingFlowspec is sent in the form of a FLOWSPEC structure.
			/// </summary>
			public FLOWSPEC SendingFlowspec;

			/// <summary>
			/// Specifies QOS parameters for the receiving direction of a particular flow. ReceivingFlowspec is sent in the form of a
			/// FLOWSPEC structure.
			/// </summary>
			public FLOWSPEC ReceivingFlowspec;

			/// <summary>
			/// Pointer to a structure of type WSABUF that can provide additional provider-specific quality of service parameters to the RSVP
			/// SP for a given flow.
			/// </summary>
			public WSABUF ProviderSpecific;
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct SOCKADDR_IN
		{
			public ADDRESS_FAMILY sin_family;
			public ushort sin_port;
			public IN_ADDR sin_addr;
			public ulong sin_zero;

			public SOCKADDR_IN(IN_ADDR addr, ushort port = 0)
			{
				sin_family = ADDRESS_FAMILY.AF_INET;
				sin_port = port;
				sin_addr = addr;
				sin_zero = 0;
			}

			public static implicit operator SOCKADDR_IN(IN_ADDR addr) => new SOCKADDR_IN(addr);

			public override string ToString() => $"{sin_addr}:{sin_port}";
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		public struct SOCKADDR_IN6
		{
			public ADDRESS_FAMILY sin6_family;
			public ushort sin6_port;
			public uint sin6_flowinfo;
			public IN6_ADDR sin6_addr;
			public uint sin6_scope_id;

			public SOCKADDR_IN6(byte[] addr, uint scope_id, ushort port = 0) : this(new IN6_ADDR(addr), scope_id, port)
			{
			}

			public SOCKADDR_IN6(IN6_ADDR addr, uint scope_id, ushort port = 0)
			{
				sin6_family = ADDRESS_FAMILY.AF_INET6;
				sin6_port = port;
				sin6_flowinfo = 0;
				sin6_addr = addr;
				sin6_scope_id = scope_id;
			}

			public static implicit operator SOCKADDR_IN6(IN6_ADDR addr) => new SOCKADDR_IN6(addr, 0);

			public override string ToString() => $"{sin6_addr}" + (sin6_scope_id == 0 ? "" : "%" + sin6_scope_id.ToString()) + $":{sin6_port}";
		}

		/// <summary>
		/// <para>
		/// The <c>SOCKADDR_IN6_PAIR</c> structure contains pointers to a pair of IP addresses that represent a source and destination
		/// address pair.
		/// </para>
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
			private IntPtr _SourceAddress;
			private IntPtr _DestinationAddress;

			/// <summary>
			/// <para>
			/// A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the
			/// IPv6 address, port, flow information, and zone ID are in network byte order.
			/// </para>
			/// </summary>
			public SOCKADDR_IN6 SourceAddress => _SourceAddress.ToStructure<SOCKADDR_IN6>();

			/// <summary>
			/// <para>
			/// A pointer to an IP source address represented as a SOCKADDR_IN6 structure. The address family is in host byte order and the
			/// IPv6 address, port, flow information, and zone ID are in network byte order.
			/// </para>
			/// </summary>
			public SOCKADDR_IN6 DestinationAddress => _DestinationAddress.ToStructure<SOCKADDR_IN6>();
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Explicit)]
		public struct SOCKADDR_INET : IEquatable<SOCKADDR_INET>, IEquatable<SOCKADDR_IN>, IEquatable<SOCKADDR_IN6>
		{
			[FieldOffset(0)]
			public SOCKADDR_IN Ipv4;

			[FieldOffset(0)]
			public SOCKADDR_IN6 Ipv6;

			[FieldOffset(0)]
			public ADDRESS_FAMILY si_family;

			public bool Equals(SOCKADDR_INET other) => (si_family == ADDRESS_FAMILY.AF_INET && Ipv4.Equals(other.Ipv4)) || (si_family == ADDRESS_FAMILY.AF_INET6 && Ipv6.Equals(other.Ipv6));

			public bool Equals(SOCKADDR_IN other) => si_family == ADDRESS_FAMILY.AF_INET && Ipv4.Equals(other);

			public bool Equals(SOCKADDR_IN6 other) => si_family == ADDRESS_FAMILY.AF_INET6 && Ipv6.Equals(other);

			public static implicit operator SOCKADDR_INET(SOCKADDR_IN address) => new SOCKADDR_INET { Ipv4 = address };

			public static implicit operator SOCKADDR_INET(SOCKADDR_IN6 address) => new SOCKADDR_INET { Ipv6 = address };

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

		/// <summary>Provides a handle to a socket.</summary>
		/// <seealso cref="Vanara.PInvoke.IHandle"/>
		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKET : IHandle
		{
			/// <summary>The handle</summary>
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="SOCKET"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SOCKET(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="SOCKET"/> object with <see cref="IntPtr.Zero"/>.</summary>
			/// <value>Returns a <see cref="SOCKET"/> value.</value>
			public static SOCKET NULL => new SOCKET(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			/// <value><see langword="true"/> if this instance is null; otherwise, <see langword="false"/>.</value>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="SOCKET"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(SOCKET h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SOCKET"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SOCKET(IntPtr h) => new SOCKET(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(SOCKET h1, SOCKET h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(SOCKET h1, SOCKET h2) => h1.Equals(h2);

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is SOCKET h ? handle == h.handle : false;

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <summary>Returns the value of the handle field.</summary>
			/// <returns>An IntPtr representing the value of the handle field.</returns>
			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKET_ADDRESS
		{
			public IntPtr lpSockAddr;
			public int iSockaddrLength;

			public SOCKADDR_INET GetSOCKADDR() => lpSockAddr.ToStructure<SOCKADDR_INET>();

			public override string ToString() => GetSOCKADDR().ToString();
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

		/// <summary>The <c>WSADATA</c> structure contains information about the Windows Sockets implementation.</summary>
		/// <remarks>
		/// <para>
		/// The WSAStartup function initiates the use of the Windows Sockets DLL by a process. The <c>WSAStartup</c> function returns a
		/// pointer to the <c>WSADATA</c> structure in the lpWSADataparameter.
		/// </para>
		/// <para>The current version of the Windows Sockets specification returned in the <c>wHighVersion</c> member of the</para>
		/// <para>
		/// <c>WSADATA</c> structure is version 2.2 encoded with the major version number in the low-byte and the minor version number in the
		/// high-byte. This version of the current Winsock DLL, Ws2_32.dll, supports applications that request any of the following versions
		/// of the Windows Sockets specification:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>1.0</term>
		/// </item>
		/// <item>
		/// <term>1.1</term>
		/// </item>
		/// <item>
		/// <term>2.0</term>
		/// </item>
		/// <item>
		/// <term>2.1</term>
		/// </item>
		/// <item>
		/// <term>2.2</term>
		/// </item>
		/// </list>
		/// <para>
		/// Depending on the version requested by the application, one of the above version numbers is the value encoded as the major version
		/// number in the low-byte and the minor version number in the high-byte that is returned in the <c>wVersion</c> member of the
		/// <c>WSADATA</c> structure.
		/// </para>
		/// <para>
		/// <c>Note</c> An application should ignore the <c>iMaxsockets</c>, <c>iMaxUdpDg</c>, and <c>lpVendorInfo</c> members in
		/// <c>WSADATA</c> if the value in <c>wVersion</c> after a successful call to WSAStartup is at least 2. This is because the
		/// architecture of Windows Sockets changed in version 2 to support multiple providers, and <c>WSADATA</c> no longer applies to a
		/// single vendor's stack. Two new socket options are introduced to supply provider-specific information: SO_MAX_MSG_SIZE (replaces
		/// the <c>iMaxUdpDg</c> member) and PVD_CONFIG (allows any other provider-specific configuration to occur).
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example demonstrates the use of the <c>WSADATA</c> structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/ns-winsock-wsadata typedef struct WSAData { WORD wVersion; WORD
		// wHighVersion; unsigned short iMaxSockets; unsigned short iMaxUdpDg; char *lpVendorInfo; char szDescription[WSADESCRIPTION_LEN +
		// 1]; char szSystemStatus[WSASYS_STATUS_LEN + 1]; } WSADATA;
		[PInvokeData("winsock.h", MSDNShortId = "c3c4c0d6-c8b3-4991-bedb-f45816cc8160")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct WSADATA
		{
			private const int WSADESCRIPTION_LEN = 256;
			private const int WSASYS_STATUS_LEN = 128;

			/// <summary>
			/// <para>Type: <c>WORD</c></para>
			/// <para>
			/// The version of the Windows Sockets specification that the Ws2_32.dll expects the caller to use. The high-order byte specifies
			/// the minor version number; the low-order byte specifies the major version number.
			/// </para>
			/// </summary>
			public ushort wVersion;

			/// <summary>
			/// <para>Type: <c>WORD</c></para>
			/// <para>
			/// The highest version of the Windows Sockets specification that the Ws2_32.dll can support. The high-order byte specifies the
			/// minor version number; the low-order byte specifies the major version number.
			/// </para>
			/// <para>
			/// This is the same value as the <c>wVersion</c> member when the version requested in the wVersionRequested parameter passed to
			/// the WSAStartup function is the highest version of the Windows Sockets specification that the Ws2_32.dll can support.
			/// </para>
			/// </summary>
			public ushort wHighVersion;

			/// <summary>
			/// <para>Type: <c>unsigned short</c></para>
			/// <para>
			/// The maximum number of sockets that may be opened. This member should be ignored for Windows Sockets version 2 and later.
			/// </para>
			/// <para>
			/// The <c>iMaxSockets</c> member is retained for compatibility with Windows Sockets specification 1.1, but should not be used
			/// when developing new applications. No single value can be appropriate for all underlying service providers. The architecture
			/// of Windows Sockets changed in version 2 to support multiple providers, and the <c>WSADATA</c> structure no longer applies to
			/// a single vendor's stack.
			/// </para>
			/// </summary>
			public ushort iMaxSockets;

			/// <summary>
			/// <para>Type: <c>unsigned short</c></para>
			/// <para>The maximum datagram message size. This member is ignored for Windows Sockets version 2 and later.</para>
			/// <para>
			/// The <c>iMaxUdpDg</c> member is retained for compatibility with Windows Sockets specification 1.1, but should not be used when
			/// developing new applications. The architecture of Windows Sockets changed in version 2 to support multiple providers, and the
			/// <c>WSADATA</c> structure no longer applies to a single vendor's stack. For the actual maximum message size specific to a
			/// particular Windows Sockets service provider and socket type, applications should use getsockopt to retrieve the value of
			/// option SO_MAX_MSG_SIZE after a socket has been created.
			/// </para>
			/// </summary>
			public ushort iMaxUdpDg;

			/// <summary>
			/// <para>Type: <c>char FAR*</c></para>
			/// <para>A pointer to vendor-specific information. This member should be ignored for Windows Sockets version 2 and later.</para>
			/// <para>
			/// The <c>lpVendorInfo</c> member is retained for compatibility with Windows Sockets specification 1.1. The architecture of
			/// Windows Sockets changed in version 2 to support multiple providers, and the <c>WSADATA</c> structure no longer applies to a
			/// single vendor's stack. Applications needing to access vendor-specific configuration information should use getsockopt to
			/// retrieve the value of option PVD_CONFIG for vendor-specific information.
			/// </para>
			/// </summary>
			public IntPtr lpVendorInfo;

			/// <summary>
			/// <para>Type: <c>char[WSADESCRIPTION_LEN+1]</c></para>
			/// <para>
			/// A <c>NULL</c>-terminated ASCII string into which the Ws2_32.dll copies a description of the Windows Sockets implementation.
			/// The text (up to 256 characters in length) can contain any characters except control and formatting characters. The most
			/// likely use that an application would have for this member is to display it (possibly truncated) in a status message.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WSADESCRIPTION_LEN + 1)]
			public string szDescription;

			/// <summary>
			/// <para>Type: <c>char[WSASYS_STATUS_LEN+1]</c></para>
			/// <para>
			/// A <c>NULL</c>-terminated ASCII string into which the Ws2_32.dll copies relevant status or configuration information. The
			/// Ws2_32.dll should use this parameter only if the information might be useful to the user or support staff. This member should
			/// not be considered as an extension of the <c>szDescription</c> parameter.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WSASYS_STATUS_LEN + 1)]
			public string szSystemStatus;
		}

		/// <summary>
		/// <para>The <c>WSAPROTOCOL_INFO</c> structure is used to store or retrieve complete information for a given protocol.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/ns-winsock2-_wsaprotocol_infoa typedef struct _WSAPROTOCOL_INFOA {
		// DWORD dwServiceFlags1; DWORD dwServiceFlags2; DWORD dwServiceFlags3; DWORD dwServiceFlags4; DWORD dwProviderFlags; GUID
		// ProviderId; DWORD dwCatalogEntryId; WSAPROTOCOLCHAIN ProtocolChain; int iVersion; int iAddressFamily; int iMaxSockAddr; int
		// iMinSockAddr; int iSocketType; int iProtocol; int iProtocolMaxOffset; int iNetworkByteOrder; int iSecurityScheme; DWORD
		// dwMessageSize; DWORD dwProviderReserved; CHAR szProtocol[WSAPROTOCOL_LEN + 1]; } WSAPROTOCOL_INFOA, *LPWSAPROTOCOL_INFOA;
		[PInvokeData("winsock2.h", MSDNShortId = "758c5553-056f-4ea5-a851-30ef641ffb14")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WSAPROTOCOL_INFO
		{
			private const int WSAPROTOCOL_LEN = 255;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A bitmask that describes the services provided by the protocol. The possible values for this member are defined in the
			/// Winsock2.h header file.
			/// </para>
			/// <para>The following values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>XP1_CONNECTIONLESS 0x00000001</term>
			/// <term>Provides connectionless (datagram) service. If not set, the protocol supports connection-oriented data transfer.</term>
			/// </item>
			/// <item>
			/// <term>XP1_GUARANTEED_DELIVERY 0x00000002</term>
			/// <term>Guarantees that all data sent will reach the intended destination.</term>
			/// </item>
			/// <item>
			/// <term>XP1_GUARANTEED_ORDER 0x00000004</term>
			/// <term>
			/// Guarantees that data only arrives in the order in which it was sent and that it is not duplicated. This characteristic does
			/// not necessarily mean that the data is always delivered, but that any data that is delivered is delivered in the order in
			/// which it was sent.
			/// </term>
			/// </item>
			/// <item>
			/// <term>XP1_MESSAGE_ORIENTED 0x00000008</term>
			/// <term>Honors message boundaries—as opposed to a stream-oriented protocol where there is no concept of message boundaries.</term>
			/// </item>
			/// <item>
			/// <term>XP1_PSEUDO_STREAM 0x00000010</term>
			/// <term>
			/// A message-oriented protocol, but message boundaries are ignored for all receipts. This is convenient when an application does
			/// not desire message framing to be done by the protocol.
			/// </term>
			/// </item>
			/// <item>
			/// <term>XP1_GRACEFUL_CLOSE 0x00000020</term>
			/// <term>Supports two-phase (graceful) close. If not set, only abortive closes are performed.</term>
			/// </item>
			/// <item>
			/// <term>XP1_EXPEDITED_DATA 0x00000040</term>
			/// <term>Supports expedited (urgent) data.</term>
			/// </item>
			/// <item>
			/// <term>XP1_CONNECT_DATA 0x00000080</term>
			/// <term>Supports connect data.</term>
			/// </item>
			/// <item>
			/// <term>XP1_DISCONNECT_DATA 0x00000100</term>
			/// <term>Supports disconnect data.</term>
			/// </item>
			/// <item>
			/// <term>XP1_SUPPORT_BROADCAST 0x00000200</term>
			/// <term>Supports a broadcast mechanism.</term>
			/// </item>
			/// <item>
			/// <term>XP1_SUPPORT_MULTIPOINT 0x00000400</term>
			/// <term>Supports a multipoint or multicast mechanism. Control and data plane attributes are indicated below.</term>
			/// </item>
			/// <item>
			/// <term>XP1_MULTIPOINT_CONTROL_PLANE 0x00000800</term>
			/// <term>Indicates whether the control plane is rooted (value = 1) or nonrooted (value = 0).</term>
			/// </item>
			/// <item>
			/// <term>XP1_MULTIPOINT_DATA_PLANE 0x00001000</term>
			/// <term>Indicates whether the data plane is rooted (value = 1) or nonrooted (value = 0).</term>
			/// </item>
			/// <item>
			/// <term>XP1_QOS_SUPPORTED 0x00002000</term>
			/// <term>Supports quality of service requests.</term>
			/// </item>
			/// <item>
			/// <term>XP1_INTERRUPT</term>
			/// <term>Bit is reserved.</term>
			/// </item>
			/// <item>
			/// <term>XP1_UNI_SEND 0x00008000</term>
			/// <term>Protocol is unidirectional in the send direction.</term>
			/// </item>
			/// <item>
			/// <term>XP1_UNI_RECV 0x00010000</term>
			/// <term>Protocol is unidirectional in the recv direction.</term>
			/// </item>
			/// <item>
			/// <term>XP1_IFS_HANDLES 0x00020000</term>
			/// <term>Socket descriptors returned by the provider are operating system Installable File System (IFS) handles.</term>
			/// </item>
			/// <item>
			/// <term>XP1_PARTIAL_MESSAGE 0x00040000</term>
			/// <term>The MSG_PARTIAL flag is supported in WSASend and WSASendTo.</term>
			/// </item>
			/// <item>
			/// <term>XP1_SAN_SUPPORT_SDP 0x00080000</term>
			/// <term>The protocol provides support for SAN. This value is supported on Windows 7 and Windows Server 2008 R2.</term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>Note</c> Only one of XP1_UNI_SEND or XP1_UNI_RECV values may be set. If a protocol can be unidirectional in either
			/// direction, two WSAPROTOCOL_INFOW structures should be used. When neither bit is set, the protocol is considered to be bidirectional.
			/// </para>
			/// </summary>
			public uint dwServiceFlags1;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved for additional protocol-attribute definitions.</para>
			/// </summary>
			public uint dwServiceFlags2;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved for additional protocol-attribute definitions.</para>
			/// </summary>
			public uint dwServiceFlags3;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A set of flags that provides information on how this protocol is represented in the Winsock catalog. The possible values for
			/// this member are defined in the Winsock2.h header file.
			/// </para>
			/// <para>The following flag values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PFL_MULTIPLE_PROTO_ENTRIES 0x00000001</term>
			/// <term>
			/// Indicates that this is one of two or more entries for a single protocol (from a given provider) which is capable of
			/// implementing multiple behaviors. An example of this is SPX which, on the receiving side, can behave either as a
			/// message-oriented or a stream-oriented protocol.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PFL_RECOMMENDED_PROTO_ENTRY 0x00000002</term>
			/// <term>
			/// Indicates that this is the recommended or most frequently used entry for a protocol that is capable of implementing multiple behaviors.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PFL_HIDDEN 0x00000004</term>
			/// <term>
			/// Set by a provider to indicate to the Ws2_32.dll that this protocol should not be returned in the result buffer generated by
			/// WSAEnumProtocols. Obviously, a Windows Sockets 2 application should never see an entry with this bit set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PFL_MATCHES_PROTOCOL_ZERO 0x00000008</term>
			/// <term>Indicates that a value of zero in the protocol parameter of socket or WSASocket matches this protocol entry.</term>
			/// </item>
			/// <item>
			/// <term>PFL_NETWORKDIRECT_PROVIDER 0x00000010</term>
			/// <term>
			/// Set by a provider to indicate support for network direct access. This value is supported on Windows 7 and Windows Server 2008 R2.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwServiceFlags4;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved for additional protocol-attribute definitions.</para>
			/// </summary>
			public uint dwProviderFlags;

			/// <summary>
			/// <para>Type: <c>GUID</c></para>
			/// <para>
			/// A globally unique identifier (GUID) assigned to the provider by the service provider vendor. This value is useful for
			/// instances where more than one service provider is able to implement a particular protocol. An application can use the
			/// <c>ProviderId</c> member to distinguish between providers that might otherwise be indistinguishable.
			/// </para>
			/// </summary>
			public Guid ProviderId;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A unique identifier assigned by the WS2_32.DLL for each <c>WSAPROTOCOL_INFO</c> structure.</para>
			/// </summary>
			public uint dwCatalogEntryId;

			/// <summary>
			/// <para>Type: <c>WSAPROTOCOLCHAIN</c></para>
			/// <para>
			/// The WSAPROTOCOLCHAIN structure associated with the protocol. If the length of the chain is 0, this <c>WSAPROTOCOL_INFO</c>
			/// entry represents a layered protocol which has Windows Sockets 2 SPI as both its top and bottom edges. If the length of the
			/// chain equals 1, this entry represents a base protocol whose Catalog Entry identifier is in the <c>dwCatalogEntryId</c> member
			/// of the <c>WSAPROTOCOL_INFO</c> structure. If the length of the chain is larger than 1, this entry represents a protocol chain
			/// which consists of one or more layered protocols on top of a base protocol. The corresponding Catalog Entry identifiers are in
			/// the ProtocolChain.ChainEntries array starting with the layered protocol at the top (the zero element in the
			/// ProtocolChain.ChainEntries array) and ending with the base protocol. Refer to the Windows Sockets 2 Service Provider
			/// Interface specification for more information on protocol chains.
			/// </para>
			/// </summary>
			public WSAPROTOCOLCHAIN ProtocolChain;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The protocol version identifier.</para>
			/// </summary>
			public int iVersion;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// A value to pass as the address family parameter to the socket or WSASocket function in order to open a socket for this
			/// protocol. This value also uniquely defines the structure of a protocol address for a sockaddr used by the protocol.
			/// </para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the possible values for the address family are defined in the
			/// Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly.
			/// </para>
			/// <para>
			/// On versions of the Platform SDK for Windows Server 2003 and older, the possible values for the address family are defined in
			/// the Winsock2.h header file.
			/// </para>
			/// <para>
			/// The values currently supported are AF_INET or AF_INET6, which are the Internet address family formats for IPv4 and IPv6.
			/// Other options for address family (AF_NETBIOS for use with NetBIOS, for example) are supported if a Windows Sockets service
			/// provider for the address family is installed. Note that the values for the AF_ address family and PF_ protocol family
			/// constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
			/// </para>
			/// <para>The table below lists common values for address family although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>iAddressFamily</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_INET 2</term>
			/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
			/// </item>
			/// <item>
			/// <term>AF_IPX 6</term>
			/// <term>
			/// The IPX/SPX address family. This address family is only supported if the NWLink IPX/SPX NetBIOS Compatible Transport protocol
			/// is installed. This address family is not supported on Windows Vista and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AF_APPLETALK 16</term>
			/// <term>
			/// The AppleTalk address family. This address family is only supported if the AppleTalk protocol is installed. This address
			/// family is not supported on Windows Vista and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AF_NETBIOS 17</term>
			/// <term>
			/// The NetBIOS address family. This address family is only supported if the Windows Sockets provider for NetBIOS is installed.
			/// The Windows Sockets provider for NetBIOS is supported on 32-bit versions of Windows. This provider is installed by default on
			/// 32-bit versions of Windows. The Windows Sockets provider for NetBIOS is not supported on 64-bit versions of windows including
			/// Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP. The Windows Sockets provider for NetBIOS
			/// only supports sockets where the type parameter is set to SOCK_DGRAM. The Windows Sockets provider for NetBIOS is not directly
			/// related to the NetBIOS programming interface. The NetBIOS programming interface is not supported on Windows Vista, Windows
			/// Server 2008, and later.
			/// </term>
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
			/// The Bluetooth address family. This address family is supported on Windows XP with SP2 or later if the computer has a
			/// Bluetooth adapter and driver installed.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public int iAddressFamily;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The maximum address length, in bytes.</para>
			/// </summary>
			public int iMaxSockAddr;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The minimum address length, in bytes.</para>
			/// </summary>
			public int iMinSockAddr;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// A value to pass as the socket type parameter to the socket or WSASocket function in order to open a socket for this protocol.
			/// Possible values for the socket type are defined in the Winsock2.h header file.
			/// </para>
			/// <para>The following table lists the possible values for the <c>iSocketType</c> member supported for Windows Sockets 2:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>iSocketType</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SOCK_STREAM 1</term>
			/// <term>
			/// A socket type that provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission
			/// mechanism. This socket type uses the Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6).
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_DGRAM 2</term>
			/// <term>
			/// A socket type that supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum
			/// length. This socket type uses the User Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_RAW 3</term>
			/// <term>
			/// A socket type that provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To
			/// manipulate the IPv4 header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the
			/// IPV6_HDRINCL socket option must be set on the socket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_RDM 4</term>
			/// <term>
			/// A socket type that provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM)
			/// multicast protocol implementation in Windows, often referred to as reliable multicast programming. This value is only
			/// supported if the Reliable Multicast Protocol is installed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_SEQPACKET 5</term>
			/// <term>A socket type that provides a pseudo-stream packet based on datagrams.</term>
			/// </item>
			/// </list>
			/// </summary>
			public int iSocketType;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// A value to pass as the protocol parameter to the socket or WSASocket function in order to open a socket for this protocol.
			/// The possible options for the <c>iProtocol</c> member are specific to the address family and socket type specified.
			/// </para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, this member can be one of the values from the <c>IPPROTO</c>
			/// enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in
			/// Winsock2.h, and should never be used directly.
			/// </para>
			/// <para>
			/// On versions of the Platform SDK for Windows Server 2003 and earlier, the possible values for the <c>iProtocol</c> member are
			/// defined in the Winsock2.h and Wsrm.h header files.
			/// </para>
			/// <para>The table below lists common values for the <c>iProtocol</c> although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>iProtocol</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IPPROTO_ICMP 1</term>
			/// <term>The Internet Control Message Protocol (ICMP). This value is supported on Windows XP and later.</term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_IGMP 2</term>
			/// <term>The Internet Group Management Protocol (IGMP). This value is supported on Windows XP and later.</term>
			/// </item>
			/// <item>
			/// <term>BTHPROTO_RFCOMM 3</term>
			/// <term>
			/// The Bluetooth Radio Frequency Communications (Bluetooth RFCOMM) protocol. This value is supported on Windows XP with SP2 or later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_TCP 6</term>
			/// <term>The Transmission Control Protocol (TCP).</term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_UDP 17</term>
			/// <term>The User Datagram Protocol (UDP).</term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_ICMPV6 58</term>
			/// <term>The Internet Control Message Protocol Version 6 (ICMPv6). This value is supported on Windows XP and later.</term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_RM 113</term>
			/// <term>
			/// The PGM protocol for reliable multicast. On the Windows SDK released for Windows Vista and later, this protocol is also
			/// called IPPROTO_PGM. This value is only supported if the Reliable Multicast Protocol is installed.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public int iProtocol;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// The maximum value that may be added to <c>iProtocol</c> when supplying a value for the protocol parameter to socket or
			/// WSASocket function. Not all protocols allow a range of values. When this is the case <c>iProtocolMaxOffset</c> is zero.
			/// </para>
			/// </summary>
			public int iProtocolMaxOffset;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// Currently these values are manifest constants (BIGENDIAN and LITTLEENDIAN) that indicate either big-endian or little-endian
			/// with the values 0 and 1 respectively.
			/// </para>
			/// </summary>
			public int iNetworkByteOrder;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// The type of security scheme employed (if any). A value of SECURITY_PROTOCOL_NONE (0) is used for protocols that do not
			/// incorporate security provisions.
			/// </para>
			/// </summary>
			public int iSecurityScheme;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The maximum message size, in bytes, supported by the protocol. This is the maximum size that can be sent from any of the
			/// host's local interfaces. For protocols that do not support message framing, the actual maximum that can be sent to a given
			/// address may be less. There is no standard provision to determine the maximum inbound message size. The following special
			/// values are defined.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>The protocol is stream-oriented and hence the concept of message size is not relevant.</term>
			/// </item>
			/// <item>
			/// <term>0x1</term>
			/// <term>
			/// The maximum outbound (send) message size is dependent on the underlying network MTU (maximum sized transmission unit) and
			/// hence cannot be known until after a socket is bound. Applications should use getsockopt to retrieve the value of
			/// SO_MAX_MSG_SIZE after the socket has been bound to a local address.
			/// </term>
			/// </item>
			/// <item>
			/// <term>0xFFFFFFFF</term>
			/// <term>The protocol is message-oriented, but there is no maximum limit to the size of messages that may be transmitted.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwMessageSize;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>Reserved for use by service providers.</para>
			/// </summary>
			public uint dwProviderReserved;

			/// <summary>
			/// <para>Type: <c>TCHAR[WSAPROTOCOL_LEN+1]</c></para>
			/// <para>
			/// An array of characters that contains a human-readable name identifying the protocol, for example "MSAFD Tcpip [UDP/IP]". The
			/// maximum number of characters allowed is WSAPROTOCOL_LEN, which is defined to be 255.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WSAPROTOCOL_LEN + 1)]
			public string szProtocol;
		}

		/// <summary>
		/// <para>The <c>WSAPROTOCOLCHAIN</c> structure contains a counted list of Catalog Entry identifiers that comprise a protocol chain.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the length of the chain is larger than 1, this structure represents a protocol chain which consists of one or more layered
		/// protocols on top of a base protocol. The corresponding Catalog Entry IDs are in the ProtocolChain.ChainEntries array starting
		/// with the layered protocol at the top (the zeroth element in the ProtocolChain.ChainEntries array) and ending with the base
		/// protocol. Refer to Windows Sockets 2 Service Provider Interface for more information on protocol chains.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/ns-winsock2-wsaprotocolchain typedef struct _WSAPROTOCOLCHAIN { int
		// ChainLen; DWORD ChainEntries[MAX_PROTOCOL_CHAIN]; } WSAPROTOCOLCHAIN, *LPWSAPROTOCOLCHAIN;
		[PInvokeData("winsock2.h", MSDNShortId = "c0676f45-e3e3-45f2-9b34-d7318fddc282")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WSAPROTOCOLCHAIN
		{
			private const int MAX_PROTOCOL_CHAIN = 7;

			/// <summary>
			/// <para>Length of the chain, in bytes. The following settings apply:</para>
			/// <para>Setting <c>ChainLen</c> to zero indicates a layered protocol</para>
			/// <para>Setting <c>ChainLen</c> to one indicates a base protocol</para>
			/// <para>Setting <c>ChainLen</c> to greater than one indicates a protocol chain</para>
			/// </summary>
			public int ChainLen;

			/// <summary>
			/// <para>Array of protocol chain entries.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PROTOCOL_CHAIN)]
			public uint[] ChainEntries;
		}

		[PInvokeData("winsock2.h")]
		public class SOCKADDR : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			public SOCKADDR(uint addr, ushort port = 0) : this(BitConverter.GetBytes(addr), port)
			{
			}

			public SOCKADDR(byte[] addr, ushort port = 0, uint scopeId = 0) :
				base(addr.Length == 4 ? Marshal.SizeOf(typeof(SOCKADDR_IN)) : Marshal.SizeOf(typeof(SOCKADDR_IN6)))
			{
				if (addr.Length == 4)
				{
					var in4 = new SOCKADDR_IN(new IN_ADDR(addr), port);
					Marshal.StructureToPtr(in4, handle, false);
				}
				else if (addr.Length == 16)
				{
					var in6 = new SOCKADDR_IN6(addr, scopeId, port);
					Marshal.StructureToPtr(in6, handle, false);
				}
				else
					throw new ArgumentOutOfRangeException(nameof(addr));
			}

			public byte[] sa_data => GetBytes(2, 14);
			public ushort sa_family => handle.ToStructure<ushort>();
		}
	}
}