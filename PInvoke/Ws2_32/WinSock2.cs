#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Net;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Functions, structures and constants from ws2_32.h.</summary>
	public static partial class Ws2_32
	{
		/// <summary>
		/// An opaque data structure object from the service provider associated with socket s. This object stores the current configuration
		/// information of the service provider. The exact format of this data structure is service provider specific.
		/// </summary>
		public const int PVD_CONFIG = 0x3001;

		/// <summary>The socket is listening.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_ACCEPTCONN = 0x0002;

		/// <summary>The socket is configured for the transmission and receipt of broadcast messages.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_BROADCAST = 0x0020;

		/// <summary>Returns the local address, local port, remote address, remote port, socket type, and protocol used by a socket.</summary>
		[CorrespondingType(typeof(CSADDR_INFO))]
		public const int SO_BSP_STATE = 0x1009;

		/// <summary>Returns current socket state, either from a previous call to setsockopt or the system default.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_CONDITIONAL_ACCEPT = 0x3002;

		/// <summary></summary>
		public const int SO_CONNDATA = 0x7000;

		/// <summary></summary>
		public const int SO_CONNDATALEN = 0x7004;

		/// <summary>
		/// Returns the number of seconds a socket has been connected. This socket option is valid for connection oriented protocols only.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const int SO_CONNECT_TIME = 0x700C;

		/// <summary></summary>
		public const int SO_CONNOPT = 0x7001;

		/// <summary></summary>
		public const int SO_CONNOPTLEN = 0x7005;

		/// <summary>Debugging is enabled.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_DEBUG = 0x0001;

		/// <summary></summary>
		public const int SO_DISCDATA = 0x7002;

		/// <summary></summary>
		public const int SO_DISCDATALEN = 0x7006;

		/// <summary></summary>
		public const int SO_DISCOPT = 0x7003;

		/// <summary></summary>
		public const int SO_DISCOPTLEN = 0x7007;

		/// <summary>If TRUE, the SO_LINGER option is disabled.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_DONTLINGER = (int)(~SO_LINGER);

		/// <summary>
		/// Routing is disabled. Setting this succeeds but is ignored on AF_INET sockets; fails on AF_INET6 sockets with WSAENOPROTOOPT.
		/// This option is not supported on ATM sockets.
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_DONTROUTE = 0x0010;

		/// <summary>Retrieves error status and clear.</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_ERROR = 0x1007;

		/// <summary>
		/// Prevents any other socket from binding to the same address and port. This option must be set before calling the bind function.
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_EXCLUSIVEADDRUSE = ((int)(~SO_REUSEADDR));

		/// <summary>Reserved.</summary>
		[CorrespondingType(typeof(GROUP))]
		public const int SO_GROUP_ID = 0x2001;

		/// <summary>Reserved.</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_GROUP_PRIORITY = 0x2002;

		/// <summary>Keep-alives are being sent. Not supported on ATM sockets.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_KEEPALIVE = 0x0008;

		/// <summary>Returns the current linger options.</summary>
		[CorrespondingType(typeof(LINGER))]
		public const int SO_LINGER = 0x0080;

		/// <summary>
		/// The maximum size of a message for message-oriented socket types (for example, SOCK_DGRAM). Has no meaning for stream oriented sockets.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const int SO_MAX_MSG_SIZE = 0x2003;

		/// <summary></summary>
		public const int SO_MAXDG = 0x7009;

		/// <summary></summary>
		public const int SO_MAXPATHDG = 0x700A;

		/// <summary>
		/// OOB data is being received in the normal data stream. (See section Windows Sockets 1.1 Blocking Routines and EINPROGRESS for a
		/// discussion of this topic.)
		/// </summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_OOBINLINE = 0x0100;

		/// <summary>A description of the protocol information for the protocol that is bound to this socket.</summary>
		[CorrespondingType(typeof(WSAPROTOCOL_INFO))]
		public const int SO_PROTOCOL_INFO = SO_PROTOCOL_INFOW;

		/// <summary>A description of the protocol information for the protocol that is bound to this socket.</summary>
		[CorrespondingType(typeof(WSAPROTOCOL_INFO))]
		public const int SO_PROTOCOL_INFOA = 0x2004;

		/// <summary>A description of the protocol information for the protocol that is bound to this socket.</summary>
		[CorrespondingType(typeof(WSAPROTOCOL_INFO))]
		public const int SO_PROTOCOL_INFOW = 0x2005;

		/// <summary>
		/// The total per-socket buffer space reserved for receives. This is unrelated to SO_MAX_MSG_SIZE and does not necessarily
		/// correspond to the size of the TCP receive window.
		/// </summary>
		[CorrespondingType(typeof(int))]
		public const int SO_RCVBUF = 0x1002;

		/// <summary>Receives low watermark.</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_RCVLOWAT = 0x1004;

		/// <summary>Receives time-out.</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_RCVTIMEO = 0x1006;

		/// <summary>The socket can be bound to an address which is already in use. Not applicable for ATM sockets.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int SO_REUSEADDR = 0x0004;

		/// <summary>
		/// The total per-socket buffer space reserved for sends. This is unrelated to SO_MAX_MSG_SIZE and does not necessarily correspond
		/// to the size of a TCP send window.
		/// </summary>
		[CorrespondingType(typeof(int))]
		public const int SO_SNDBUF = 0x1001;

		/// <summary>Sends low watermark.</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_SNDLOWAT = 0x1003;

		/// <summary>Sends time-out.</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_SNDTIMEO = 0x1005;

		/// <summary>The type of the socket (for example, SOCK_STREAM).</summary>
		[CorrespondingType(typeof(int))]
		public const int SO_TYPE = 0x1008;

		/// <summary></summary>
		public const int SO_UPDATE_ACCEPT_CONTEXT = 0x700B;

		/// <summary></summary>
		public const int SO_USELOOPBACK = 0x0040;

		/// <summary>A value that indicates a function failure.</summary>
		public const int SOCKET_ERROR = -1;

		/// <summary>The socket option level.</summary>
		public const int SOL_SOCKET = 0xffff;

		/// <summary>Maximum queue length specifiable by listen.</summary>
		public const int SOMAXCONN = 0x7fffffff;

		/// <summary></summary>
		public const int TCP_BSDURGENT = 0x7000;

		/// <summary>Disables the Nagle algorithm for send coalescing.</summary>
		[CorrespondingType(typeof(BOOL))]
		public const int TCP_NODELAY = 0x0001;

		/// <summary>The application-specified callback function for <see cref="WSAAccept"/>.</summary>
		/// <param name="lpCallerId">
		/// A WSABUF structure that contains the address of the connecting entity, where its len parameter is the length of the buffer in
		/// bytes, and its buf parameter is a pointer to the buffer..
		/// </param>
		/// <param name="lpCallerData">
		/// A value parameter that contains any user data. The information in these parameters is sent along with the connection request. If
		/// no caller identification or caller data is available, the corresponding parameters will be NULL. Many network protocols do not
		/// support connect-time caller data. Most conventional network protocols can be expected to support caller identifier information
		/// at connection-request time. The buf portion of the WSABUF pointed to by lpCallerId points to a sockaddr. The sockaddr structure
		/// is interpreted according to its address family (typically by casting the sockaddr to some type specific to the address family).
		/// </param>
		/// <param name="lpSQOS">
		/// References the FLOWSPEC structures for socket s specified by the caller, one for each direction, followed by any additional
		/// provider-specific parameters. The sending or receiving flow specification values will be ignored as appropriate for any
		/// unidirectional sockets. A NULL value indicates that there is no caller-supplied quality of service and that no negotiation is
		/// possible. A non-NULL lpSQOS pointer indicates that a quality of service negotiation is to occur or that the provider is prepared
		/// to accept the quality of service request without negotiation.
		/// </param>
		/// <param name="lpGQOS">
		/// Reserved, and should be NULL. (reserved for future use with socket groups) references the FLOWSPEC structure for the socket
		/// group the caller is to create, one for each direction, followed by any additional provider-specific parameters. A NULL value for
		/// lpGQOS indicates no caller-specified group quality of service. Quality of service information can be returned if negotiation is
		/// to occur.
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
		/// bytes of data into lpCalleeData-&gt;buf, and then update lpCalleeData-&gt;len to indicate the actual number of bytes
		/// transferred. If no user data is to be passed back to the caller, the condition function should set lpCalleeData-&gt;len to zero.
		/// The format of all address and user data is specific to the address family to which the socket belongs.
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
		/// last socket belonging to this socket group is closed.Socket group identifiers are unique across all processes for a given
		/// service provider. For more information on socket groups, see the Remarks for the WSASocket functions.
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
		public delegate CF ConditionFunc(in WSABUF lpCallerId, in WSABUF lpCallerData, IntPtr lpSQOS, IntPtr lpGQOS, in WSABUF lpCalleeId, in WSABUF lpCalleeData, out GROUP g, IntPtr dwCallbackData);

		/// <summary>The address family specification.</summary>
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
			/// been made, and no action about this connection request should be taken by the service provider. When the application is
			/// ready to take action on the connection request, it will invoke WSAAccept again and return either CF_ACCEPT or CF_REJECT as a
			/// return value from the condition function.
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

		/// <summary>Indicate either big-endian or little-endian with the values 0 and 1 respectively.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "be5f3e81-1442-43c7-9e4e-9eb2b2a05132")]
		public enum NetworkByteOrder
		{
			/// <summary>The bigendian</summary>
			BIGENDIAN = 0x0000,

			/// <summary>The littleendian</summary>
			LITTLEENDIAN = 0x0001
		}

		/// <summary>Namespace identifier.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "cc4ccb2d-ea5a-48bd-a3ae-f70432ab2c39")]
		public enum NS
		{
			/// <summary>All installed and active namespaces.</summary>
			NS_ALL = 0,

			/// <summary/>
			NS_SAP = (1),

			/// <summary/>
			NS_NDS = (2),

			/// <summary/>
			NS_PEER_BROWSE = (3),

			/// <summary/>
			NS_SLP = (5),

			/// <summary/>
			NS_DHCP = (6),

			/// <summary/>
			NS_TCPIP_LOCAL = (10),

			/// <summary/>
			NS_TCPIP_HOSTS = (11),

			/// <summary>The domain name system (DNS) namespace.</summary>
			NS_DNS = 12,

			/// <summary>The NetBIOS over TCP/IP (NETBT) namespace.</summary>
			NS_NETBT = 13,

			/// <summary>The Windows Internet Naming Service (NS_WINS) namespace.</summary>
			NS_WINS = 14,

			/// <summary>
			/// The network location awareness (NLA) namespace.
			/// <para>This namespace identifier is supported on Windows XP and later.</para>
			/// </summary>
			NS_NLA = 15,

			/// <summary>
			/// The Bluetooth namespace.
			/// <para>This namespace identifier is supported on Windows Vista and later.</para>
			/// </summary>
			NS_BTH = 16,

			/// <summary/>
			NS_LOCALNAME = (19),

			/// <summary/>
			NS_NBP = (20),

			/// <summary/>
			NS_MS = (30),

			/// <summary/>
			NS_STDA = (31),

			/// <summary>The Windows NT Directory Services (NS_NTDS) namespace.</summary>
			NS_NTDS = 32,

			/// <summary>
			/// The email namespace.
			/// <para>This namespace identifier is supported on Windows Vista and later.</para>
			/// </summary>
			NS_EMAIL = 37,

			/// <summary>
			/// The peer-to-peer namespace for a specific peer name.
			/// <para>This namespace identifier is supported on Windows Vista and later.</para>
			/// </summary>
			NS_PNRPNAME = 38,

			/// <summary>
			/// The peer-to-peer namespace for a collection of peer names.
			/// <para>This namespace identifier is supported on Windows Vista and later.</para>
			/// </summary>
			NS_PNRPCLOUD = 39,

			/// <summary/>
			NS_X500 = (40),

			/// <summary/>
			NS_NIS = (41),

			/// <summary/>
			NS_NISPLUS = (42),

			/// <summary/>
			NS_WRQ = (50),

			/// <summary/>
			NS_NETDES = (60)
		}

		/// <summary>A set of flags that provides information on how this protocol is represented in the Winsock catalog.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "be5f3e81-1442-43c7-9e4e-9eb2b2a05132")]
		[Flags]
		public enum PFL : uint
		{
			/// <summary>
			/// Indicates that this is one of two or more entries for a single protocol (from a given provider) which is capable of
			/// implementing multiple behaviors. An example of this is SPX which, on the receiving side, can behave either as a
			/// message-oriented or a stream-oriented protocol.
			/// </summary>
			PFL_MULTIPLE_PROTO_ENTRIES = 0x00000001,

			/// <summary>
			/// Indicates that this is the recommended or most frequently used entry for a protocol that is capable of implementing multiple behaviors.
			/// </summary>
			PFL_RECOMMENDED_PROTO_ENTRY = 0x00000002,

			/// <summary>
			/// Set by a provider to indicate to the Ws2_32.dll that this protocol should not be returned in the result buffer generated by
			/// WSAEnumProtocols. Obviously, a Windows Sockets 2 application should never see an entry with this bit set.
			/// </summary>
			PFL_HIDDEN = 0x00000004,

			/// <summary>Indicates that a value of zero in the protocol parameter of socket or WSASocket matches this protocol entry.</summary>
			PFL_MATCHES_PROTOCOL_ZERO = 0x00000008,

			/// <summary>
			/// Set by a provider to indicate support for network direct access.
			/// <para>This value is supported on Windows 7 and Windows Server 2008 R2.</para>
			/// </summary>
			PFL_NETWORKDIRECT_PROVIDER = 0x00000010,
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

		/// <summary>a bitmask of the notification events for the socket.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "NS:winsock2.SOCK_NOTIFY_REGISTRATION")]
		[Flags]
		public enum SOCK_NOTIFY_EVENT : ushort
		{
			/// <summary>Input is available from the socket without blocking.</summary>
			SOCK_NOTIFY_EVENT_IN = SOCK_NOTIFY_REGISTER_EVENT.SOCK_NOTIFY_REGISTER_EVENT_IN,

			/// <summary>Output can be provided to the socket without blocking.</summary>
			SOCK_NOTIFY_EVENT_OUT = SOCK_NOTIFY_REGISTER_EVENT.SOCK_NOTIFY_REGISTER_EVENT_OUT,

			/// <summary>The socket connection has terminated.</summary>
			SOCK_NOTIFY_EVENT_HANGUP = SOCK_NOTIFY_REGISTER_EVENT.SOCK_NOTIFY_REGISTER_EVENT_HANGUP,

			/// <summary>The socket is in an error state.</summary>
			SOCK_NOTIFY_EVENT_ERR = 0x40,

			/// <summary>The notification has been deregistered.</summary>
			SOCK_NOTIFY_EVENT_REMOVE = 0x80,

			/// <summary>All events.</summary>
			SOCK_NOTIFY_EVENTS_ALL = SOCK_NOTIFY_REGISTER_EVENT.SOCK_NOTIFY_REGISTER_EVENTS_ALL | SOCK_NOTIFY_EVENT_ERR | SOCK_NOTIFY_EVENT_REMOVE,
		}

		/// <summary>Indicates the operation to perform on a registration. At most one operation may be performed at a time.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "NS:winsock2.SOCK_NOTIFY_REGISTRATION")]
		[Flags]
		public enum SOCK_NOTIFY_OP : byte
		{
			/// <summary>
			/// No registration operations should take place. Use this if your application calls ProcessSocketNotifications and is only
			/// interested in receiving notifications.
			/// </summary>
			SOCK_NOTIFY_OP_NONE = 0x00,

			/// <summary>
			/// Enables the registration. Notifications must not be re-enabled until the SOCK_NOTIFY_EVENT_DISABLE notification is received.
			/// </summary>
			SOCK_NOTIFY_OP_ENABLE = 0x01,

			/// <summary>
			/// Disables the registration, but doesn't destroy the underlying data structures. Note that this doesn't remove the
			/// registration, it merely suppresses queuing of new notifications. Notifications that have already been queued might still be
			/// delivered until the SOCK_NOTIFY_EVENT_DISABLE event is received.
			/// </summary>
			SOCK_NOTIFY_OP_DISABLE = 0x02,

			/// <summary>
			/// Removes a previously-registered notification. Both enabled and disabled notifications may be removed. The
			/// SOCK_NOTIFY_EVENT_REMOVE notification is issued, with the guarantee that no more notifications will be issued afterwards for
			/// that completion key unless it is re-registered.
			/// </summary>
			SOCK_NOTIFY_OP_REMOVE = 0x04,
		}

		/// <summary>A set of flags indicating the notifications being requested.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "NS:winsock2.SOCK_NOTIFY_REGISTRATION")]
		[Flags]
		public enum SOCK_NOTIFY_REGISTER_EVENT : ushort
		{
			/// <summary>Notifications should not be issued.</summary>
			SOCK_NOTIFY_REGISTER_EVENT_NONE = 0x00,

			/// <summary>A notification should be issued when data can be read without blocking.</summary>
			SOCK_NOTIFY_REGISTER_EVENT_IN = 0x01,

			/// <summary>A notification should be issued when data can be written without blocking.</summary>
			SOCK_NOTIFY_REGISTER_EVENT_OUT = 0x02,

			/// <summary>A notification should be issued when a stream-oriented connection was either disconnected or aborted.</summary>
			SOCK_NOTIFY_REGISTER_EVENT_HANGUP = 0x04,

			/// <summary>All flags.</summary>
			SOCK_NOTIFY_REGISTER_EVENTS_ALL = SOCK_NOTIFY_REGISTER_EVENT_IN | SOCK_NOTIFY_REGISTER_EVENT_OUT | SOCK_NOTIFY_REGISTER_EVENT_HANGUP
		}

		/// <summary>A set of flags indicating the trigger behavior.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "NS:winsock2.SOCK_NOTIFY_REGISTRATION")]
		[Flags]
		public enum SOCK_NOTIFY_TRIGGER : byte
		{
			/// <summary>The registration will be disabled (not removed) upon delivery of the next notification.</summary>
			SOCK_NOTIFY_TRIGGER_ONESHOT = 0x01,

			/// <summary>The registration will remain active until it is explicitly disabled or removed.</summary>
			SOCK_NOTIFY_TRIGGER_PERSISTENT = 0x02,

			/// <summary>
			/// The registration is for level-triggered notifications. Not compatible with edge-triggered. One of edge- or level-triggered
			/// must be supplied.
			/// </summary>
			SOCK_NOTIFY_TRIGGER_LEVEL = 0x04,

			/// <summary>
			/// The registration is for edge-triggered notifications. Not compatible with level-triggered. One of edge- or level-triggered
			/// must be supplied.
			/// </summary>
			SOCK_NOTIFY_TRIGGER_EDGE = 0x08,

			/// <summary>All triggers.</summary>
			SOCK_NOTIFY_TRIGGER_ALL = SOCK_NOTIFY_TRIGGER_ONESHOT | SOCK_NOTIFY_TRIGGER_PERSISTENT | SOCK_NOTIFY_TRIGGER_LEVEL | SOCK_NOTIFY_TRIGGER_EDGE,
		}

		/// <summary>
		/// The Windows Sockets <c>WSAECOMPARATOR</c> enumeration type is used for version-comparison semantics in Windows Sockets 2.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ne-winsock2-wsaecomparator typedef enum _WSAEcomparator { COMP_EQUAL,
		// COMP_NOTLESS } WSAECOMPARATOR, *PWSAECOMPARATOR, *LPWSAECOMPARATOR;
		[PInvokeData("winsock2.h", MSDNShortId = "a1de171e-42d7-4d57-b241-1db9989dbd8e")]
		public enum WSAECOMPARATOR
		{
			/// <summary>Used for determining whether version values are equal.</summary>
			COMP_EQUAL,

			/// <summary>Used for determining whether a version value is no less than a specified value.</summary>
			COMP_NOTLESS,
		}

		/// <summary>A value that determines that operation requested.</summary>
		[PInvokeData("winsock2.h")]
		public enum WSAESETSERVICEOP
		{
			/// <summary>
			/// Register the service. For SAP, this means sending out a periodic broadcast. This is an NOP for the DNS namespace. For
			/// persistent data stores, this means updating the address information.
			/// </summary>
			RNRSERVICE_REGISTER = 0,

			/// <summary>
			/// Remove the service from the registry. For SAP, this means stop sending out the periodic broadcast. This is an NOP for the
			/// DNS namespace. For persistent data stores this means deleting address information.
			/// </summary>
			RNRSERVICE_DEREGISTER,

			/// <summary>
			/// Delete the service from dynamic name and persistent spaces. For services represented by multiple CSADDR_INFO structures
			/// (using the SERVICE_MULTIPLE flag), only the specified address will be deleted, and this must match exactly the corresponding
			/// CSADDR_INFO structure that was specified when the service was registered.
			/// </summary>
			RNRSERVICE_DELETE
		}

		/// <summary>A bitmask that describes the services provided by the protocol.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "be5f3e81-1442-43c7-9e4e-9eb2b2a05132")]
		[Flags]
		public enum XP1
		{
			/// <summary>Provides connectionless (datagram) service. If not set, the protocol supports connection-oriented data transfer.</summary>
			XP1_CONNECTIONLESS = 0x00000001,

			/// <summary>Guarantees that all data sent will reach the intended destination.</summary>
			XP1_GUARANTEED_DELIVERY = 0x00000002,

			/// <summary>
			/// Guarantees that data only arrives in the order in which it was sent and that it is not duplicated. This characteristic does
			/// not necessarily mean that the data is always delivered, but that any data that is delivered is delivered in the order in
			/// which it was sent.
			/// </summary>
			XP1_GUARANTEED_ORDER = 0x00000004,

			/// <summary>Honors message boundaries—as opposed to a stream-oriented protocol where there is no concept of message boundaries.</summary>
			XP1_MESSAGE_ORIENTED = 0x00000008,

			/// <summary>
			/// A message-oriented protocol, but message boundaries are ignored for all receipts. This is convenient when an application
			/// does not desire message framing to be done by the protocol.
			/// </summary>
			XP1_PSEUDO_STREAM = 0x00000010,

			/// <summary>Supports two-phase (graceful) close. If not set, only abortive closes are performed.</summary>
			XP1_GRACEFUL_CLOSE = 0x00000020,

			/// <summary>Supports expedited (urgent) data.</summary>
			XP1_EXPEDITED_DATA = 0x00000040,

			/// <summary>Supports connect data.</summary>
			XP1_CONNECT_DATA = 0x00000080,

			/// <summary>Supports disconnect data.</summary>
			XP1_DISCONNECT_DATA = 0x00000100,

			/// <summary>Supports a broadcast mechanism.</summary>
			XP1_SUPPORT_BROADCAST = 0x00000200,

			/// <summary>Supports a multipoint or multicast mechanism. Control and data plane attributes are indicated below.</summary>
			XP1_SUPPORT_MULTIPOINT = 0x00000400,

			/// <summary>Indicates whether the control plane is rooted (value = 1) or nonrooted (value = 0).</summary>
			XP1_MULTIPOINT_CONTROL_PLANE = 0x00000800,

			/// <summary>Indicates whether the data plane is rooted (value = 1) or nonrooted (value = 0).</summary>
			XP1_MULTIPOINT_DATA_PLANE = 0x00001000,

			/// <summary>Supports quality of service requests.</summary>
			XP1_QOS_SUPPORTED = 0x00002000,

			/// <summary>Bit is reserved.</summary>
			XP1_INTERRUPT = 0x00004000,

			/// <summary>Protocol is unidirectional in the send direction.</summary>
			XP1_UNI_SEND = 0x00008000,

			/// <summary>Protocol is unidirectional in the recv direction.</summary>
			XP1_UNI_RECV = 0x00010000,

			/// <summary>Socket descriptors returned by the provider are operating system Installable File System (IFS) handles.</summary>
			XP1_IFS_HANDLES = 0x00020000,

			/// <summary>The MSG_PARTIAL flag is supported in WSASend and WSASendTo.</summary>
			XP1_PARTIAL_MESSAGE = 0x00040000,

			/// <summary>
			/// The protocol provides support for SAN.
			/// <para>This value is supported on Windows 7 and Windows Server 2008 R2.</para>
			/// </summary>
			XP1_SAN_SUPPORT_SDP = 0x00080000,
		}

		/// <summary>
		/// <para>
		/// Associates a set of sockets with a completion port, and retrieves any notifications that are already pending on that port. Once
		/// associated, the completion port receives the socket state notifications that were specified. Only Microsoft Winsock provider
		/// sockets are supported.
		/// </para>
		/// <para>
		/// To reduce system call overhead, you can register for notifications and retrieve them in a single call to
		/// <c>ProcessSocketNotifications</c>. Alternatively, you can retrieve them explicitly by calling the usual I/O completion port
		/// functions, such as GetQueuedCompletionStatus. Notifications retrieved using <c>ProcessSocketNotifications</c> are the same as
		/// those retrieved using GetQueuedCompletionStatusEx, which might include notification packets other than socket state changes.
		/// </para>
		/// <para>
		/// The notification event flags are the integer value of the dwNumberOfBytesTransferred fields of the returned OVERLAPPED_ENTRY
		/// structures. This is similar to using JOBOBJECT_ASSOCIATE_COMPLETION_PORT, which also uses the dwNumberOfBytesTransferred field
		/// to send integer messages. Call the SocketNotificationRetrieveEvents function to obtain them.
		/// </para>
		/// <para>
		/// A socket handle can be registered to only one IOCP at a time. Re-registering a previously-registered socket handle overwrites
		/// the existing registration. Before you close a handle used for registration, you should explicitly remove registration, and wait
		/// for the <c>SOCK_NOTIFY_EVENT_REMOVE</c> notification (see <c>Remarks</c> in this topic).
		/// </para>
		/// <para>For more info, and code examples, see Winsock socket state notifications.</para>
		/// </summary>
		/// <param name="completionPort">
		/// <para>Type: _In_ <c>HANDLE</c></para>
		/// <para>
		/// A handle to an I/O completion port created using the CreateIoCompletionPort function. The port will be used in the
		/// CompletionPort parameter of the PostQueuedCompletionStatus function when messages are sent on behalf of the socket.
		/// </para>
		/// </param>
		/// <param name="registrationCount">
		/// <para>Type: _In_ <c>UINT32</c></para>
		/// <para>The number of registrations supplied by registrationInfos.</para>
		/// </param>
		/// <param name="registrationInfos">
		/// <para>Type: _Inout_updates_opt_(registrationCount) <c>SOCK_NOTIFY_REGISTRATION*</c></para>
		/// <para>
		/// A pointer to an array of SOCK_NOTIFY_REGISTRATION structures that define the notification registration parameters. These include
		/// the socket of interest, the notification events of interest, and the operation flags. On success, you must inspect the elements
		/// for whether the registration was processed successfully. This argument must be <c>NULL</c> if registrationCount is 0.
		/// </para>
		/// </param>
		/// <param name="timeoutMs">
		/// <para>Type: _In_ <c>UINT32</c></para>
		/// <para>
		/// The time in milliseconds that you're willing to wait for a completion packet to appear at the completion port. If a completion
		/// packet doesn't appear within the specified time, then the function times out and returns <c>ERROR_TIMEOUT</c>.
		/// </para>
		/// <para>
		/// If timeoutMs is <c>INFINITE</c> (0xFFFFFFFF), then the function will never time out. If timeoutMs is 0, and there is no I/O
		/// operation to dequeue, then the function will time out immediately.
		/// </para>
		/// <para>The value of timeoutMs must be 0 if completionCount is 0.</para>
		/// </param>
		/// <param name="completionCount">
		/// <para>Type: _In_ <c>ULONG</c></para>
		/// <para>
		/// The maximum number of OVERLAPPED_ENTRY structures to remove. If 0 is specified, then only registration operations will be processed.
		/// </para>
		/// </param>
		/// <param name="completionPortEntries">
		/// <para>Type: _Out_writes_to_opt_(completionCount, *receivedEntryCount) <c>OVERLAPPED_ENTRY*</c></para>
		/// <para>
		/// On input, points to a pre-allocated array of OVERLAPPED_ENTRY structures. The array mustn't overlap with the registrationInfos
		/// array. The value of completionPortEntries must be <c>NULL</c> if completionCount is 0.
		/// </para>
		/// <para>
		/// On output, receives an array of OVERLAPPED_ENTRY structures that hold the entries. The number of array elements is provided by
		/// ReceivedEntryCount. The dwNumberOfBytesTransferred fields of the structures are integer masks of received events. The
		/// lpOverlapped fields are reserved and must not be used as pointers.
		/// </para>
		/// </param>
		/// <param name="receivedEntryCount">
		/// <para>Type: _Out_opt_ <c>UINT32*</c></para>
		/// <para>A pointer to a variable that receives the number of entries removed. Must be <c>NULL</c> if completionCount is 0.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If successful, returns <c>ERROR_SUCCESS</c>. If the function succeeded and you supplied a non-0 completionCount, but no
		/// completion packets appeared within the specified time, returns <c>WAIT_TIMEOUT</c>. Otherwise, returns an appropriate
		/// <c>WSAE*</c> error code.
		/// </para>
		/// <para>
		/// If <c>ERROR_SUCCESS</c> or <c>WAIT_TIMEOUT</c> is returned, then you must inspect the individual registration infos'
		/// registration results. Otherwise, the entire operation failed, and no changes occurred.
		/// </para>
		/// </returns>
		/// <remarks>See SocketNotificationRetrieveEvents for the events that are possible when a notification is received.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-processsocketnotifications DWORD WSAAPI
		// ProcessSocketNotifications( HANDLE completionPort, UINT32 registrationCount, SOCK_NOTIFY_REGISTRATION *registrationInfos, UINT32
		// timeoutMs, ULONG completionCount, OVERLAPPED_ENTRY *completionPortEntries, UINT32 *receivedEntryCount );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "NF:winsock2.ProcessSocketNotifications")]
		public static extern uint ProcessSocketNotifications(HFILE completionPort, uint registrationCount,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SOCK_NOTIFY_REGISTRATION[] registrationInfos,
			uint timeoutMs, uint completionCount,
			[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] Kernel32.OVERLAPPED_ENTRY[] completionPortEntries, out uint receivedEntryCount);

		/// <summary>
		/// <para>
		/// Associates a set of sockets with a completion port, and retrieves any notifications that are already pending on that port. Once
		/// associated, the completion port receives the socket state notifications that were specified. Only Microsoft Winsock provider
		/// sockets are supported.
		/// </para>
		/// <para>
		/// To reduce system call overhead, you can register for notifications and retrieve them in a single call to
		/// <c>ProcessSocketNotifications</c>. Alternatively, you can retrieve them explicitly by calling the usual I/O completion port
		/// functions, such as GetQueuedCompletionStatus. Notifications retrieved using <c>ProcessSocketNotifications</c> are the same as
		/// those retrieved using GetQueuedCompletionStatusEx, which might include notification packets other than socket state changes.
		/// </para>
		/// <para>
		/// The notification event flags are the integer value of the dwNumberOfBytesTransferred fields of the returned OVERLAPPED_ENTRY
		/// structures. This is similar to using JOBOBJECT_ASSOCIATE_COMPLETION_PORT, which also uses the dwNumberOfBytesTransferred field
		/// to send integer messages. Call the SocketNotificationRetrieveEvents function to obtain them.
		/// </para>
		/// <para>
		/// A socket handle can be registered to only one IOCP at a time. Re-registering a previously-registered socket handle overwrites
		/// the existing registration. Before you close a handle used for registration, you should explicitly remove registration, and wait
		/// for the <c>SOCK_NOTIFY_EVENT_REMOVE</c> notification (see <c>Remarks</c> in this topic).
		/// </para>
		/// <para>For more info, and code examples, see Winsock socket state notifications.</para>
		/// </summary>
		/// <param name="completionPort">
		/// <para>Type: _In_ <c>HANDLE</c></para>
		/// <para>
		/// A handle to an I/O completion port created using the CreateIoCompletionPort function. The port will be used in the
		/// CompletionPort parameter of the PostQueuedCompletionStatus function when messages are sent on behalf of the socket.
		/// </para>
		/// </param>
		/// <param name="registrationCount">
		/// <para>Type: _In_ <c>UINT32</c></para>
		/// <para>The number of registrations supplied by registrationInfos.</para>
		/// </param>
		/// <param name="registrationInfos">
		/// <para>Type: _Inout_updates_opt_(registrationCount) <c>SOCK_NOTIFY_REGISTRATION*</c></para>
		/// <para>
		/// A pointer to an array of SOCK_NOTIFY_REGISTRATION structures that define the notification registration parameters. These include
		/// the socket of interest, the notification events of interest, and the operation flags. On success, you must inspect the elements
		/// for whether the registration was processed successfully. This argument must be <c>NULL</c> if registrationCount is 0.
		/// </para>
		/// </param>
		/// <param name="timeoutMs">
		/// <para>Type: _In_ <c>UINT32</c></para>
		/// <para>
		/// The time in milliseconds that you're willing to wait for a completion packet to appear at the completion port. If a completion
		/// packet doesn't appear within the specified time, then the function times out and returns <c>ERROR_TIMEOUT</c>.
		/// </para>
		/// <para>
		/// If timeoutMs is <c>INFINITE</c> (0xFFFFFFFF), then the function will never time out. If timeoutMs is 0, and there is no I/O
		/// operation to dequeue, then the function will time out immediately.
		/// </para>
		/// <para>The value of timeoutMs must be 0 if completionCount is 0.</para>
		/// </param>
		/// <param name="completionCount">
		/// <para>Type: _In_ <c>ULONG</c></para>
		/// <para>
		/// The maximum number of OVERLAPPED_ENTRY structures to remove. If 0 is specified, then only registration operations will be processed.
		/// </para>
		/// </param>
		/// <param name="completionPortEntries">
		/// <para>Type: _Out_writes_to_opt_(completionCount, *receivedEntryCount) <c>OVERLAPPED_ENTRY*</c></para>
		/// <para>
		/// On input, points to a pre-allocated array of OVERLAPPED_ENTRY structures. The array mustn't overlap with the registrationInfos
		/// array. The value of completionPortEntries must be <c>NULL</c> if completionCount is 0.
		/// </para>
		/// <para>
		/// On output, receives an array of OVERLAPPED_ENTRY structures that hold the entries. The number of array elements is provided by
		/// ReceivedEntryCount. The dwNumberOfBytesTransferred fields of the structures are integer masks of received events. The
		/// lpOverlapped fields are reserved and must not be used as pointers.
		/// </para>
		/// </param>
		/// <param name="receivedEntryCount">
		/// <para>Type: _Out_opt_ <c>UINT32*</c></para>
		/// <para>A pointer to a variable that receives the number of entries removed. Must be <c>NULL</c> if completionCount is 0.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If successful, returns <c>ERROR_SUCCESS</c>. If the function succeeded and you supplied a non-0 completionCount, but no
		/// completion packets appeared within the specified time, returns <c>WAIT_TIMEOUT</c>. Otherwise, returns an appropriate
		/// <c>WSAE*</c> error code.
		/// </para>
		/// <para>
		/// If <c>ERROR_SUCCESS</c> or <c>WAIT_TIMEOUT</c> is returned, then you must inspect the individual registration infos'
		/// registration results. Otherwise, the entire operation failed, and no changes occurred.
		/// </para>
		/// </returns>
		/// <remarks>See SocketNotificationRetrieveEvents for the events that are possible when a notification is received.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-processsocketnotifications DWORD WSAAPI
		// ProcessSocketNotifications( HANDLE completionPort, UINT32 registrationCount, SOCK_NOTIFY_REGISTRATION *registrationInfos, UINT32
		// timeoutMs, ULONG completionCount, OVERLAPPED_ENTRY *completionPortEntries, UINT32 *receivedEntryCount );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "NF:winsock2.ProcessSocketNotifications")]
		public static extern Win32Error ProcessSocketNotifications(HFILE completionPort, uint registrationCount,
			[In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SOCK_NOTIFY_REGISTRATION[] registrationInfos,
			uint timeoutMs, [Optional] uint completionCount, [In, Optional] IntPtr completionPortEntries, [In, Optional] IntPtr receivedEntryCount);

		/// <summary/>
		/// <param name="b"/>
		/// <returns/>
		public static int SOMAXCONN_HINT(int b) => -b;

		/// <summary>
		/// The <c>CSADDR_INFO</c> structure contains Windows Sockets address information for a socket, network service, or namespace provider.
		/// </summary>
		/// <remarks>
		/// <para>The GetAddressByName function obtains Windows Sockets address information using <c>CSADDR_INFO</c> structures.</para>
		/// <para>
		/// The getsockopt function called with the SO_BSP_STATE socket option retrieves a <c>CSADDR_INFO</c> structure for the specified socket.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/nspapi/ns-nspapi-csaddr_info typedef struct _CSADDR_INFO { SOCKET_ADDRESS
		// LocalAddr; SOCKET_ADDRESS RemoteAddr; INT iSocketType; INT iProtocol; } CSADDR_INFO, *PCSADDR_INFO, *LPCSADDR_INFO;
		[PInvokeData("nspapi.h", MSDNShortId = "9cad3586-e315-4f6f-9045-7c95502bb768")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CSADDR_INFO
		{
			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>The Windows Sockets local address.</para>
			/// <para>In a client application, pass this address to the <c>bind</c> function to obtain access to a network service.</para>
			/// <para>
			/// In a network service, pass this address to the <c>bind</c> function so that the service is bound to the appropriate local address.
			/// </para>
			/// </summary>
			public SOCKET_ADDRESS LocalAddr;

			/// <summary>
			/// <para>Type: <c>SOCKET_ADDRESS</c></para>
			/// <para>Windows Sockets remote address.</para>
			/// <para>There are several uses for this remote address:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// You can use this remote address to connect to the service through the connect function. This is useful if an application
			/// performs send/receive operations that involve connection-oriented protocols.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// You can use this remote address with the sendto function when you are communicating over a connectionless (datagram)
			/// protocol. If you are using a connectionless protocol, such as UDP, <c>sendto</c> is typically the way you pass data to the
			/// remote system.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public SOCKET_ADDRESS RemoteAddr;

			/// <summary>
			/// <para>Type: <c>INT</c></para>
			/// <para>The type of Windows socket. Possible values for the socket type are defined in the Winsock2.h header file.</para>
			/// <para>The following table lists the possible values supported for Windows Sockets 2:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SOCK_STREAM</term>
			/// <term>
			/// A stream socket. This is a protocol that sends data as a stream of bytes, with no message boundaries. This socket type
			/// provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission mechanism. This socket
			/// type uses the Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6).
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_DGRAM</term>
			/// <term>
			/// A datagram socket. This socket type supports datagrams, which are connectionless, unreliable buffers of a fixed (typically
			/// small) maximum length. This socket type uses the User Datagram Protocol (UDP) for the Internet address family (AF_INET or
			/// AF_INET6). Services use recvfrom function to obtain datagrams. The listen and accept functions do not work with datagrams.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_RDM</term>
			/// <term>
			/// A reliable message datagram socket. This socket type preserves message boundaries in data. An example of this type is the
			/// Pragmatic General Multicast (PGM) multicast protocol implementation in Windows, often referred to as reliable multicast programming.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_SEQPACKET</term>
			/// <term>A sequenced packet stream socket. This socket type provides a pseudo-stream packet based on datagrams.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SOCK iSocketType;

			/// <summary>
			/// <para>Type: <c>INT</c></para>
			/// <para>
			/// The protocol used. The possible options for the protocol parameter are specific to the address family and socket type
			/// specified. Possible values are defined in the Winsock2.h and Wsrm.h header files.
			/// </para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and this parameter can
			/// be one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h
			/// header file is automatically included in Winsock2.h, and should never be used directly.
			/// </para>
			/// <para>The table below lists common values for the protocol although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>protocol</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IPPROTO_TCP 6</term>
			/// <term>
			/// The Transmission Control Protocol (TCP). This is a possible value when the address family is AF_INET or AF_INET6 and the
			/// iSocketType member is SOCK_STREAM.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_UDP 17</term>
			/// <term>
			/// The User Datagram Protocol (UDP). This is a possible value when the address family is AF_INET or AF_INET6 and the
			/// iSocketType member is SOCK_DGRAM.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_RM 113</term>
			/// <term>
			/// The PGM protocol for reliable multicast. This is a possible value when the address family is AF_INET and the iSocketType
			/// member is SOCK_RDM. On the Windows SDK released for Windows Vista and later, this value is also called IPPROTO_PGM.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public IPPROTO iProtocol;
		}

		/// <summary>The IN_ADDR structure represents an IPv4 address.</summary>
		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IN_ADDR : IEquatable<IN_ADDR>
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

			/// <summary/>
			public static readonly IN_ADDR INADDR_ANY = new(0U);

			/// <summary/>
			public static readonly IN_ADDR INADDR_LOOPBACK = new(0x7f000001);

			/// <summary/>
			public static readonly IN_ADDR INADDR_BROADCAST = new(0xffffffff);

			/// <summary/>
			public static readonly IN_ADDR INADDR_NONE = new(0xffffffff);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="left">The left.</param>
			/// <param name="right">The right.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(IN_ADDR left, IN_ADDR right) => left.Equals(right);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="left">The left.</param>
			/// <param name="right">The right.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(IN_ADDR left, IN_ADDR right) => !left.Equals(right);

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
			public static implicit operator byte[](IN_ADDR a) => BitConverter.GetBytes(a.S_addr);

			/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="IN_ADDR"/>.</summary>
			/// <param name="a">A UInt32 value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IN_ADDR(uint a) => new(a);

			/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="IN_ADDR"/>.</summary>
			/// <param name="a">An Int64 value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator IN_ADDR(long a) => new((uint)a);

			/// <summary>Performs an explicit conversion from <see cref="IN_ADDR"/> to <see cref="IN6_ADDR"/>.</summary>
			/// <param name="ipv4">The ipv4.</param>
			/// <returns>The resulting <see cref="IN6_ADDR"/> instance from the conversion.</returns>
			public static explicit operator IN6_ADDR(IN_ADDR ipv4) => new(ipv4);

			/// <summary>Determines equality between this instance and <paramref name="other"/>.</summary>
			/// <param name="other">The other value to compare.</param>
			/// <returns><see langword="true"/> if <paramref name="other"/> is equal to this instance.</returns>
			public bool Equals(IN_ADDR other) => S_addr == other.S_addr;

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified <see cref="object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public override bool Equals(object obj) => obj is IN_ADDR i ? Equals(i) : base.Equals(obj);

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => S_addr.GetHashCode();

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString()
			{
				var b = S_un_b;
				return $"{b[0]}.{b[1]}.{b[2]}.{b[3]}";
			}
		}

		/// <summary>The IN6_ADDR structure represents an IPv6 address.</summary>
		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential, Size = IN6_ADDR_SIZE)]
		public struct IN6_ADDR : IEquatable<IN6_ADDR>
		{
			private const int IN6_ADDR_SIZE = 16;

			private ulong lower;
			private ulong upper;

			/// <summary>The IPv6 standard loopback address (<c>IN6ADDR_LOOPBACK_INIT</c>).</summary>
			public static readonly IN6_ADDR Loopback = new(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 });

			/// <summary>The IPv6 standard unspecified address (<c>IN6ADDR_ANY_INIT</c>).</summary>
			public static readonly IN6_ADDR Unspecified = new();

			/// <summary>Initializes a new instance of the <see cref="IN6_ADDR"/> struct.</summary>
			/// <param name="v6addr">The IPv6 address as an array of bytes.</param>
			public IN6_ADDR(byte[] v6addr)
			{
				lower = upper = 0;
				bytes = v6addr;
			}

			/// <summary>Initializes a new instance of the <see cref="IN6_ADDR"/> struct from an <see cref="IN_ADDR"/>.</summary>
			/// <param name="ipv4">The ipv4 address.</param>
			public IN6_ADDR(IN_ADDR ipv4)
			{
				lower = 0;
				upper = Macros.MAKELONG64(0xffff0000, ipv4.S_addr);
			}

			/// <summary>Gets or sets the byte array representing the IPv6 address.</summary>
			/// <value>The bytes.</value>
			/// <exception cref="ArgumentException">Byte array must have 16 items. - value</exception>
			public byte[] bytes
			{
				get
				{
					unsafe
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
				}
				set
				{
					unsafe
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
			}

			/// <summary>Gets or sets the array of WORD (ushort) values representing the IPv6 address.</summary>
			/// <value>The array of WORD values.</value>
			/// <exception cref="ArgumentException">UInt16 array must have 8 items. - value</exception>
			public ushort[] words
			{
				get
				{
					unsafe
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
				}
				set
				{
					unsafe
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
			}

			/// <summary>Implements the operator ==.</summary>
			/// <param name="left">The left.</param>
			/// <param name="right">The right.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(IN6_ADDR left, IN6_ADDR right) => left.Equals(right);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="left">The left.</param>
			/// <param name="right">The right.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(IN6_ADDR left, IN6_ADDR right) => !left.Equals(right);

			/// <summary>Performs an implicit conversion from <see cref="byte"/>[] to <see cref="IN6_ADDR"/>.</summary>
			/// <param name="a">The byte array.</param>
			/// <returns>The resulting <see cref="IN6_ADDR"/> instance from the conversion.</returns>
			public static implicit operator IN6_ADDR(byte[] a) => new(a);

			/// <summary>Performs an implicit conversion from <see cref="IN6_ADDR"/> to <see cref="byte"/>[].</summary>
			/// <param name="a">The <see cref="IN6_ADDR"/> instance.</param>
			/// <returns>The resulting <see cref="byte"/>[] instance from the conversion.</returns>
			public static implicit operator byte[](IN6_ADDR a) => a.bytes;

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified <see cref="object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public override bool Equals(object obj) => obj is IN6_ADDR i ? Equals(i) : base.Equals(obj);

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => (lower, upper).GetHashCode();

			/// <summary>Converts to string.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString()
			{
				const string numberFormat = "{0:x4}:{1:x4}:{2:x4}:{3:x4}:{4:x4}:{5:x4}:{6}.{7}.{8}.{9}";
				var m_Numbers = words;
				return string.Format(System.Globalization.CultureInfo.InvariantCulture, numberFormat,
					m_Numbers[0], m_Numbers[1], m_Numbers[2], m_Numbers[3], m_Numbers[4], m_Numbers[5],
					((m_Numbers[6] >> 8) & 0xFF), (m_Numbers[6] & 0xFF), ((m_Numbers[7] >> 8) & 0xFF), (m_Numbers[7] & 0xFF));
			}

			/// <summary>Determines whether the specified <paramref name="other"/> value is equal to this instance.</summary>
			/// <param name="other">The value to compare with this instance.</param>
			/// <returns><see langword="true"/> if the specified value is equal to this instance; otherwise, <see langword="false"/>.</returns>
			public bool Equals(IN6_ADDR other) => lower == other.lower && upper == other.upper;
		}

		/// <summary>
		/// The <c>linger</c> structure maintains information about a specific socket that specifies how that socket should behave when data
		/// is queued to be sent and the closesocket function is called on the socket.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>l_onoff</c> member of the <c>linger</c> structure determines whether a socket should remain open for a specified amount
		/// of time after a closesocket function call to enable queued data to be sent. Somewhat confusing is that this member can be
		/// modified in two ways:
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
		/// The <c>l_linger</c> member of the <c>linger</c> structure determines the amount of time, in seconds, a socket should remain
		/// open. This member is only applicable if the <c>l_onoff</c> member of the <c>linger</c> structure is nonzero.
		/// </para>
		/// <para>
		/// To enable a socket to remain open, an application should set the <c>l_onoff</c> member to a nonzero value and set the
		/// <c>l_linger</c> member to the desired time-out in seconds. To disable a socket from remaining open, an application only needs to
		/// set the <c>l_onoff</c> member of the <c>linger</c> structure to zero.
		/// </para>
		/// <para>
		/// If an application calls the setsockopt function with the optname parameter set to <c>SO_DONTLINGER</c> to set the <c>l_onoff</c>
		/// member to a nonzero value, the value for the <c>l_linger</c> member is not specified. In this case, the time-out used is
		/// implementation dependent. If a previous time-out has been established for a socket (by enabling SO_LINGER), this time-out value
		/// should be reinstated by the service provider.
		/// </para>
		/// <para>Note that enabling a nonzero timeout on a nonblocking socket is not recommended.</para>
		/// <para>
		/// The getsockopt function can be called with the optname parameter set to <c>SO_LINGER</c> to retrieve the current value of the
		/// <c>linger</c> structure associated with a socket.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/ns-winsock-linger typedef struct linger { u_short l_onoff; u_short
		// l_linger; } LINGER, *PLINGER, *LPLINGER;
		[PInvokeData("winsock.h", MSDNShortId = "c1dbabcf-b5cd-4a9d-9bf9-b04c62117d74")]
		[StructLayout(LayoutKind.Sequential)]
		public struct LINGER
		{
			/// <summary>
			/// <para>Type: <c>u_short</c></para>
			/// <para>
			/// Specifies whether a socket should remain open for a specified amount of time after a closesocket function call to enable
			/// queued data to be sent. This member can have one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>
			/// The socket will not remain open. This is the value set if the setsockopt function is called with the optname parameter set
			/// to SO_DONTLINGER and the optval parameter is zero. This value is also set if the setsockopt function is called with the
			/// optname parameter set to SO_LINGER and the linger structure passed in the optval parameter has the l_onoff member set to 0.
			/// </term>
			/// </item>
			/// <item>
			/// <term>nonzero</term>
			/// <term>
			/// The socket will remain open for a specified amount of time. This value is set if the setsockopt function is called with the
			/// optname parameter set to SO_DONTLINGER and the optval parameter is nonzero. This value is also set if the setsockopt
			/// function is called with the optname parameter set to SO_LINGER and the linger structure passed in the optval parameter has
			/// the l_onoff member set to a nonzero value.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort l_onoff;

			/// <summary>
			/// <para>Type: <c>u_short</c></para>
			/// <para>
			/// The linger time in seconds. This member specifies how long to remain open after a closesocket function call to enable queued
			/// data to be sent. This member is only applicable if the <c>l_onoff</c> member of the <c>linger</c> structure is set to a
			/// nonzero value.
			/// </para>
			/// <para>
			/// This value is set if the setsockopt function is called with the optname parameter set to <c>SO_LINGER</c>. The optval
			/// parameter passed to the <c>setsockopt</c> function must contain a <c>linger</c> structure that is copied to the internal
			/// <c>linger</c> structure maintained for the socket.
			/// </para>
			/// </summary>
			public ushort l_linger;
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
			/// Pointer to a structure of type WSABUF that can provide additional provider-specific quality of service parameters to the
			/// RSVP SP for a given flow.
			/// </summary>
			public WSABUF ProviderSpecific;
		}

		/// <summary>
		/// <para>Represents info supplied to the ProcessSocketNotifications function.</para>
		/// <para>For more info, and code examples, see Winsock socket state notifications.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-sock_notify_registration typedef struct
		// SOCK_NOTIFY_REGISTRATION { SOCKET socket; PVOID completionKey; UINT16 eventFilter; UINT8 operation; UINT8 triggerFlags; DWORD
		// registrationResult; } SOCK_NOTIFY_REGISTRATION;
		[PInvokeData("winsock2.h", MSDNShortId = "NS:winsock2.SOCK_NOTIFY_REGISTRATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCK_NOTIFY_REGISTRATION
		{
			/// <summary>
			/// <para>Type: <c>SOCKET</c></para>
			/// <para>
			/// A handle to a Winsock socket opened by any of the WSASocket, socket, WSAAccept, accept, or WSADuplicateSocket functions.
			/// Only Microsoft Winsock provider sockets are supported.
			/// </para>
			/// </summary>
			public SOCKET socket;

			/// <summary>
			/// <para>Type: <c>PVOID</c></para>
			/// <para>
			/// The value to use in the dwCompletionKey parameter of the PostQueuedCompletionStatus function when notifications are sent on
			/// behalf of the socket. This parameter is used upon registration creation. To change the completion key, remove the
			/// registration and re-register it.
			/// </para>
			/// </summary>
			public IntPtr completionKey;

			/// <summary>
			/// <para>Type: <c>UINT16</c></para>
			/// <para>
			/// A set of flags indicating the notifications being requested. This must be one or more of the following values (defined in
			/// <code>WinSock2.h</code>
			/// ).
			/// </para>
			/// <para>
			/// <c>SOCK_NOTIFY_REGISTER_EVENT_NONE</c>. Notifications should not be issued. <c>SOCK_NOTIFY_REGISTER_EVENT_IN</c>. A
			/// notification should be issued when data can be read without blocking. <c>SOCK_NOTIFY_REGISTER_EVENT_OUT</c>. A notification
			/// should be issued when data can be written without blocking. <c>SOCK_NOTIFY_REGISTER_EVENT_HANGUP</c>. A notification should
			/// be issued when a stream-oriented connection was either disconnected or aborted. <c>SOCK_NOTIFY_REGISTER_EVENTS_ALL</c>. Has
			/// the value
			/// <code>(SOCK_NOTIFY_REGISTER_EVENT_IN | SOCK_NOTIFY_REGISTER_EVENT_OUT | SOCK_NOTIFY_REGISTER_EVENT_HANGUP)</code>
			/// .
			/// </para>
			/// </summary>
			public SOCK_NOTIFY_REGISTER_EVENT eventFilter;

			/// <summary>
			/// <para>Type: <c>UINT8</c></para>
			/// <para>
			/// Indicates the operation to perform on a registration. At most one operation may be performed at a time. These values are
			/// defined in
			/// <code>WinSock2.h</code>
			/// .
			/// </para>
			/// <para>
			/// <c>SOCK_NOTIFY_OP_NONE</c>. No registration operations should take place. Use this if your application calls
			/// ProcessSocketNotifications and is only interested in receiving notifications. <c>SOCK_NOTIFY_OP_ENABLE</c>. Enables the
			/// registration. Notifications must not be re-enabled until the <c>SOCK_NOTIFY_EVENT_DISABLE</c> notification is received.
			/// <c>SOCK_NOTIFY_OP_DISABLE</c>. Disables the registration, but doesn't destroy the underlying data structures. Note that this
			/// doesn't remove the registration, it merely suppresses queuing of new notifications. Notifications that have already been
			/// queued might still be delivered until the <c>SOCK_NOTIFY_EVENT_DISABLE</c> event is received. <c>SOCK_NOTIFY_OP_REMOVE</c>.
			/// Removes a previously-registered notification. Both enabled and disabled notifications may be removed. The
			/// <c>SOCK_NOTIFY_EVENT_REMOVE</c> notification is issued, with the guarantee that no more notifications will be issued
			/// afterwards for that completion key unless it is re-registered.
			/// </para>
			/// </summary>
			public SOCK_NOTIFY_OP operation;

			/// <summary>
			/// <para>Type: <c>UINT8</c></para>
			/// <para>A set of flags indicating the trigger behavior (defined in
			/// <code>WinSock2.h</code>
			/// ).
			/// </para>
			/// <para>
			/// <c>SOCK_NOTIFY_TRIGGER_ONESHOT</c>. The registration will be disabled (not removed) upon delivery of the next notification.
			/// <c>SOCK_NOTIFY_TRIGGER_PERSISTENT</c>. The registration will remain active until it is explicitly disabled or removed.
			/// <c>SOCK_NOTIFY_TRIGGER_LEVEL</c>. The registration is for level-triggered notifications. Not compatible with edge-triggered.
			/// One of edge- or level-triggered must be supplied. <c>SOCK_NOTIFY_TRIGGER_EDGE</c>. The registration is for edge-triggered
			/// notifications. Not compatible with level-triggered. One of edge- or level-triggered must be supplied.
			/// </para>
			/// <para>
			/// Notifications are only supplied when the registration is enabled. Notifications are not queued up while the registration is
			/// disabled. As notifications are queued up for a given socket, they are coalesced into a single notification. Therefore,
			/// multiple events may be described by a single event mask for the socket.
			/// </para>
			/// <para>Given the registration is enabled, level-triggered notifications are supplied whenever the desired conditions hold.</para>
			/// <para>
			/// Given the registration is enabled, edge-triggered notifications are supplied whenever a condition changes from not holding
			/// to holding. The condition must change while the registration is enabled for a notification to be queued. As such, after
			/// registering, the socket's receive buffer must be completely drained to ensure a notification is received.
			/// </para>
			/// </summary>
			public SOCK_NOTIFY_TRIGGER triggerFlags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// After a successful call to ProcessSocketNotifications, registrationResult contains a code indicating the success or failure
			/// of the registration. A value of <c>ERROR_SUCCESS</c> indicates that registration was successful.
			/// </para>
			/// </summary>
			public Win32Error registrationResult;
		}

		/// <summary>Provides a handle to a socket.</summary>
		/// <seealso cref="Vanara.PInvoke.IHandle"/>
		[PInvokeData("winsock2.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SOCKET : IHandle
		{
			/// <summary>The handle</summary>
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="SOCKET"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SOCKET(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Represents an invalid socket which is different than a null socket.</summary>
			/// <value>The invalid socket.</value>
			public static SOCKET INVALID_SOCKET => new(new IntPtr(-1));

			/// <summary>Returns an invalid handle by instantiating a <see cref="SOCKET"/> object with <see cref="IntPtr.Zero"/>.</summary>
			/// <value>Returns a <see cref="SOCKET"/> value.</value>
			public static SOCKET NULL => new(IntPtr.Zero);

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
			public static implicit operator SOCKET(IntPtr h) => new(h);

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
			/// <returns>
			/// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
			/// </returns>
			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is SOCKET h && handle == h.handle;

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <summary>Returns the value of the handle field.</summary>
			/// <returns>An IntPtr representing the value of the handle field.</returns>
			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;

			/// <inheritdoc/>
			public override string ToString() => handle.ToString();
		}

		/// <summary>
		/// The <c>timeval</c> structure is used to specify a time interval. It is associated with the Berkeley Software Distribution (BSD)
		/// Time.h header file.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>timeval</c> structure is used in Windows Sockets by the select function to specify the maximum time the function can take
		/// to complete. The time interval is a combination of the values in <c>tv_sec</c> and <c>tv_usec</c> members.
		/// </para>
		/// <para>
		/// Several functions are added on Windows Vista and later that use the <c>timeval</c> structure. These functions include
		/// GetAddrInfoEx, SetAddrInfoEx, WSAConnectByList, and WSAConnectByName.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/ns-winsock-timeval typedef struct timeval { long tv_sec; long tv_usec;
		// } TIMEVAL, *PTIMEVAL, *LPTIMEVAL;
		[PInvokeData("winsock.h", MSDNShortId = "3024c961-bb47-40ac-a49c-b12cd431e4e7")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TIMEVAL
		{
			/// <summary>Time interval, in seconds.</summary>
			public int tv_sec;

			/// <summary>
			/// Time interval, in microseconds. This value is used in combination with the <c>tv_sec</c> member to represent time interval
			/// values that are not a multiple of seconds.
			/// </summary>
			public int tv_usec;

			/// <summary>Performs an explicit conversion from <see cref="TimeSpan"/> to <see cref="TIMEVAL"/>.</summary>
			/// <param name="timeSpan">The time span.</param>
			/// <returns>The resulting <see cref="TIMEVAL"/> instance from the conversion.</returns>
			public static explicit operator TIMEVAL(TimeSpan timeSpan)
			{
				var tr = Math.Truncate(timeSpan.TotalSeconds);
				return new TIMEVAL { tv_sec = (int)tr, tv_usec = (int)((timeSpan.Ticks - TimeSpan.TicksPerSecond * (long)tr) / TimeSpan.TicksPerMillisecond) };
			}
		}

		/// <summary>The <c>WSADATA</c> structure contains information about the Windows Sockets implementation.</summary>
		/// <remarks>
		/// <para>
		/// The WSAStartup function initiates the use of the Windows Sockets DLL by a process. The <c>WSAStartup</c> function returns a
		/// pointer to the <c>WSADATA</c> structure in the lpWSADataparameter.
		/// </para>
		/// <para>The current version of the Windows Sockets specification returned in the <c>wHighVersion</c> member of the</para>
		/// <para>
		/// <c>WSADATA</c> structure is version 2.2 encoded with the major version number in the low-byte and the minor version number in
		/// the high-byte. This version of the current Winsock DLL, Ws2_32.dll, supports applications that request any of the following
		/// versions of the Windows Sockets specification:
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
		/// Depending on the version requested by the application, one of the above version numbers is the value encoded as the major
		/// version number in the low-byte and the minor version number in the high-byte that is returned in the <c>wVersion</c> member of
		/// the <c>WSADATA</c> structure.
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
			/// The version of the Windows Sockets specification that the Ws2_32.dll expects the caller to use. The high-order byte
			/// specifies the minor version number; the low-order byte specifies the major version number.
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
			/// The <c>iMaxUdpDg</c> member is retained for compatibility with Windows Sockets specification 1.1, but should not be used
			/// when developing new applications. The architecture of Windows Sockets changed in version 2 to support multiple providers,
			/// and the <c>WSADATA</c> structure no longer applies to a single vendor's stack. For the actual maximum message size specific
			/// to a particular Windows Sockets service provider and socket type, applications should use getsockopt to retrieve the value
			/// of option SO_MAX_MSG_SIZE after a socket has been created.
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
			/// Ws2_32.dll should use this parameter only if the information might be useful to the user or support staff. This member
			/// should not be considered as an extension of the <c>szDescription</c> parameter.
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
			/// A message-oriented protocol, but message boundaries are ignored for all receipts. This is convenient when an application
			/// does not desire message framing to be done by the protocol.
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
			public XP1 dwServiceFlags1;

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
			/// Set by a provider to indicate support for network direct access. This value is supported on Windows 7 and Windows Server
			/// 2008 R2.
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
			/// chain equals 1, this entry represents a base protocol whose Catalog Entry identifier is in the <c>dwCatalogEntryId</c>
			/// member of the <c>WSAPROTOCOL_INFO</c> structure. If the length of the chain is larger than 1, this entry represents a
			/// protocol chain which consists of one or more layered protocols on top of a base protocol. The corresponding Catalog Entry
			/// identifiers are in the ProtocolChain.ChainEntries array starting with the layered protocol at the top (the zero element in
			/// the ProtocolChain.ChainEntries array) and ending with the base protocol. Refer to the Windows Sockets 2 Service Provider
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
			/// The IPX/SPX address family. This address family is only supported if the NWLink IPX/SPX NetBIOS Compatible Transport
			/// protocol is installed. This address family is not supported on Windows Vista and later.
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
			/// The Windows Sockets provider for NetBIOS is supported on 32-bit versions of Windows. This provider is installed by default
			/// on 32-bit versions of Windows. The Windows Sockets provider for NetBIOS is not supported on 64-bit versions of windows
			/// including Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP. The Windows Sockets provider
			/// for NetBIOS only supports sockets where the type parameter is set to SOCK_DGRAM. The Windows Sockets provider for NetBIOS is
			/// not directly related to the NetBIOS programming interface. The NetBIOS programming interface is not supported on Windows
			/// Vista, Windows Server 2008, and later.
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
			/// A value to pass as the socket type parameter to the socket or WSASocket function in order to open a socket for this
			/// protocol. Possible values for the socket type are defined in the Winsock2.h header file.
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
			public SOCK iSocketType;

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
			public IPPROTO iProtocol;

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

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="SOCKET"/> that is disposed using <see cref="closesocket"/>.</summary>
		public class SafeSOCKET : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSOCKET"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeSOCKET(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSOCKET"/> class.</summary>
			private SafeSOCKET() : base() { }

			/// <summary>Represents an invalid socket which is different than a null socket.</summary>
			/// <value>The invalid socket.</value>
			public static SafeSOCKET INVALID_SOCKET => new(new IntPtr(-1), false);

			/// <summary>Returns an invalid handle by instantiating a <see cref="SafeSOCKET"/> object with <see cref="IntPtr.Zero"/>.</summary>
			/// <value>Returns a <see cref="SafeSOCKET"/> value.</value>
			public static SafeSOCKET NULL => new(IntPtr.Zero, false);

			/// <summary>Performs an implicit conversion from <see cref="SafeSOCKET"/> to <see cref="SOCKET"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SOCKET(SafeSOCKET h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => closesocket(this) == 0;
		}

		/// <summary>
		/// <para>
		/// The sockaddr structure varies depending on the protocol selected. Except for the sin*_family parameter, sockaddr contents are
		/// expressed in network byte order.
		/// </para>
		/// <para>
		/// Winsock functions using sockaddr are not strictly interpreted to be pointers to a sockaddr structure. The structure is
		/// interpreted differently in the context of different address families. The only requirements are that the first <c>u_short</c> is
		/// the address family and the total size of the memory buffer in bytes is namelen.
		/// </para>
		/// <para>
		/// The <c>SOCKADDR_STORAGE</c> structure also stores socket address information and the structure is sufficiently large to store
		/// IPv4 or IPv6 address information. The use of the <c>SOCKADDR_STORAGE</c> structure promotes protocol-family and protocol-version
		/// independence, and simplifies development. It is recommended that the <c>SOCKADDR_STORAGE</c> structure be used in place of the
		/// sockaddr structure. The <c>SOCKADDR_STORAGE</c> structure is supported on Windows Server 2003 and later.
		/// </para>
		/// <para>The sockaddr structure and sockaddr_in structures below are used with IPv4. Other protocols use similar structures.</para>
		/// <para>The sockaddr_in6 and sockaddr_in6_old structures below are used with IPv6.</para>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, <c>SOCKADDR</c> and
		/// <c>SOCKADDR_IN</c> typedef tags are defined for sockaddr and sockaddr_in structures as follows:
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the sockaddr and
		/// sockaddr_in structures are defined in the Ws2def.h header file, not the Winsock2.h header file. The Ws2def.h header file is
		/// automatically included by the Winsock2.h header file. The sockaddr_in6 structure is defined in the Ws2ipdef.h header file, not
		/// the Ws2tcpip.h header file. The Ws2ipdef.h header file is automatically included by the Ws2tcpip.h header file. The Ws2def.h and
		/// Ws2ipdef.h header files should never be used directly.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/winsock/sockaddr-2
		[PInvokeData("winsock2.h", MSDNShortId = "d1392e1c-2b20-425a-8adf-38e665fb6275")]
		public class SOCKADDR : SafeMemoryHandle<CoTaskMemoryMethods>
		{
			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="handle">The handle to the memory with the address.</param>
			/// <param name="ownsHandle">if set to <see langword="true"/> this class with dispose the memory.</param>
			/// <param name="size">The size of the memory pointed to by <paramref name="handle"/>.</param>
			public SOCKADDR(IntPtr handle, bool ownsHandle = false, int size = 0) : base(handle, size, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="addr">The IPv4 address value.</param>
			/// <param name="port">The port.</param>
			public SOCKADDR(uint addr, ushort port = 0) : this(BitConverter.GetBytes(addr), port)
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="addr">The IPv4 or IPv6 address as a byte array.</param>
			/// <param name="port">The port.</param>
			/// <param name="scopeId">The scope identifier for IPv6 addresses.</param>
			/// <exception cref="ArgumentOutOfRangeException">addr</exception>
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

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="addr">The <see cref="SOCKADDR_IN"/> value to assign.</param>
			public SOCKADDR(SOCKADDR_IN addr) : base(Marshal.SizeOf(typeof(SOCKADDR_IN))) => Marshal.StructureToPtr(addr, handle, false);

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="addr">The <see cref="SOCKADDR_IN6"/> value to assign.</param>
			public SOCKADDR(SOCKADDR_IN6 addr) : base(Marshal.SizeOf(typeof(SOCKADDR_IN6))) => Marshal.StructureToPtr(addr, handle, false);

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="ipAddress">The ip address.</param>
			public SOCKADDR(IPAddress ipAddress) : this(ipAddress.GetAddressBytes()) { }

			/// <summary>Initializes a new instance of the <see cref="SOCKADDR"/> class.</summary>
			/// <param name="endPoint">The socket address.</param>
			public SOCKADDR(IPEndPoint endPoint) : this(endPoint.Address.GetAddressBytes(), (ushort)endPoint.Port) { }

			/// <summary>Gets an instance that represents an empty address.</summary>
			public static SOCKADDR Empty => new(new byte[Marshal.SizeOf(typeof(IN6_ADDR))]);

			/// <summary>Gets the data behind this address as a byte array.</summary>
			/// <value>The address data.</value>
			public byte[] sa_data => GetBytes(2, 14);

			/// <summary>Gets the <see cref="ADDRESS_FAMILY"/> of this address.</summary>
			/// <value>The address family.</value>
			public ADDRESS_FAMILY sa_family => (ADDRESS_FAMILY)handle.ToStructure<ushort>();

			/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
			/// <typeparam name="T">Native type</typeparam>
			/// <param name="value">The value.</param>
			/// <returns><see cref="SOCKADDR"/> object to an native (unmanaged) memory block the size of T.</returns>
			public static SOCKADDR CreateFromStructure<T>(T value = default) => new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out int s), true, s);

			/// <summary>Performs an explicit conversion from <see cref="SOCKADDR"/> to <see cref="SOCKADDR_IN"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR_IN"/> instance from the conversion.</returns>
			/// <exception cref="InvalidCastException"></exception>
			public static explicit operator SOCKADDR_IN(SOCKADDR addr) => addr.sa_family == ADDRESS_FAMILY.AF_INET ? addr.handle.ToStructure<SOCKADDR_IN>() : throw new InvalidCastException();

			/// <summary>Performs an explicit conversion from <see cref="SOCKADDR"/> to <see cref="SOCKADDR_IN6"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR_IN6"/> instance from the conversion.</returns>
			/// <exception cref="InvalidCastException"></exception>
			public static explicit operator SOCKADDR_IN6(SOCKADDR addr) => addr.sa_family == ADDRESS_FAMILY.AF_INET6 ? addr.handle.ToStructure<SOCKADDR_IN6>() : (SOCKADDR_IN6)(SOCKADDR_IN)addr;

			/// <summary>Performs an explicit conversion from <see cref="SOCKADDR"/> to <see cref="SOCKADDR_INET"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR_INET"/> instance from the conversion.</returns>
			/// <exception cref="InvalidCastException"></exception>
			public static explicit operator SOCKADDR_INET(SOCKADDR addr) => addr.sa_family == ADDRESS_FAMILY.AF_INET6 ? addr.handle.ToStructure<SOCKADDR_INET>() : (SOCKADDR_INET)(SOCKADDR_IN)addr;

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="IntPtr"/> instance from the conversion.</returns>
			public static implicit operator IntPtr(SOCKADDR addr) => addr.DangerousGetHandle();

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR_IN"/> to <see cref="SOCKADDR"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR(SOCKADDR_IN addr) => new(addr);

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR_IN6"/> to <see cref="SOCKADDR"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR(SOCKADDR_IN6 addr) => new(addr);

			/// <summary>Performs an implicit conversion from <see cref="SOCKADDR_INET"/> to <see cref="SOCKADDR"/>.</summary>
			/// <param name="addr">The address.</param>
			/// <returns>The resulting <see cref="SOCKADDR"/> instance from the conversion.</returns>
			public static implicit operator SOCKADDR(SOCKADDR_INET addr) => CreateFromStructure(addr);

			/// <summary>Provides a copy of <see cref="SOCKADDR"/> as an array of bytes.</summary>
			/// <value>The array of bytes from this instance.</value>
			public byte[] GetAddressBytes() => GetBytes(0, Size);

			/// <inheritdoc/>
			public override string ToString() => sa_family == ADDRESS_FAMILY.AF_INET ? ((SOCKADDR_IN)this).ToString() : ((SOCKADDR_IN6)this).ToString();
		}
	}
}