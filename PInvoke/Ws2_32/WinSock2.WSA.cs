#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Functions, structures and constants from ws2_32.h.</summary>
	public static partial class Ws2_32
	{
		/// <summary>The CompletionRoutine is a placeholder for an application-defined or library-defined function name.</summary>
		/// <param name="dwError">Specifies the completion status for the overlapped operation as indicated by lpOverlapped.</param>
		/// <param name="cbTransferred">Specifies the number of bytes received.</param>
		/// <param name="lpOverlapped">The overlapped operation.</param>
		/// <param name="dwFlags">Contains information that would have appeared in lpFlags if the receive operation had completed immediately.</param>
		// void (CALLBACK* LPWSAOVERLAPPED_COMPLETION_ROUTINE) ( IN DWORD dwError, IN DWORD cbTransferred, IN LPWSAOVERLAPPED lpOverlapped,
		// IN DWORD dwFlags );
		[PInvokeData("winsock2.h", MSDNShortId = "abaf367a-8f99-478c-a58c-d57e9f9cd8a1")]
		public delegate void LPWSAOVERLAPPED_COMPLETION_ROUTINE([In] uint dwError, [In] uint cbTransferred, [In] in WSAOVERLAPPED lpOverlapped, [In] uint dwFlags);

		/// <summary>Network events.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "f98a71e4-47fb-47a4-b37e-e4cc801a8f98")]
		public enum FD
		{
			/// <summary>Wants to receive notification of readiness for reading.</summary>
			FD_READ = (1 << 0),

			/// <summary>Wants to receive notification of readiness for writing.</summary>
			FD_WRITE = (1 << 1),

			/// <summary>Wants to receive notification of the arrival of OOB data.</summary>
			FD_OOB = (1 << 2),

			/// <summary>Wants to receive notification of incoming connections.</summary>
			FD_ACCEPT = (1 << 3),

			/// <summary>Wants to receive notification of completed connection or multipoint join operation.</summary>
			FD_CONNECT = (1 << 4),

			/// <summary>Wants to receive notification of socket closure.</summary>
			FD_CLOSE = (1 << 5),

			/// <summary>Wants to receive notification of socket (QoS changes.</summary>
			FD_QOS = (1 << 6),

			/// <summary>Reserved for future use with socket groups. Want to receive notification of socket group QoS changes.</summary>
			FD_GROUP_QOS = (1 << 7),

			/// <summary>Wants to receive notification of routing interface changes for the specified destination.</summary>
			FD_ROUTING_INTERFACE_CHANGE = (1 << 8),

			/// <summary>Wants to receive notification of local address list changes for the address family of the socket.</summary>
			FD_ADDRESS_LIST_CHANGE = (1 << 9),

			/// <summary>All events.</summary>
			FD_ALL_EVENTS = ((1 << 10) - 1)
		}

		/// <summary>Flags to indicate that the socket is acting as a sender (JL_SENDER_ONLY), receiver (JL_RECEIVER_ONLY), or both (JL_BOTH).</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "ef9efa03-feed-4f0d-b874-c646cce745c9")]
		[Flags]
		public enum JL
		{
			/// <summary>Acting as a sender.</summary>
			JL_SENDER_ONLY = 0x01,

			/// <summary>Acting as a receiver.</summary>
			JL_RECEIVER_ONLY = 0x02,

			/// <summary>Acting as both sender and receiver.</summary>
			JL_BOTH = 0x04,
		}

		/// <summary>Flags that control the depth of the search.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "448309ef-b9dd-4960-8016-d26691df59ec")]
		[Flags]
		public enum LUP : uint
		{
			/// <summary>Queries deep as opposed to just the first level.</summary>
			LUP_DEEP = 0x0001,

			/// <summary>Returns containers only.</summary>
			LUP_CONTAINERS = 0x0002,

			/// <summary>Do not return containers.</summary>
			LUP_NOCONTAINERS = 0x0004,

			/// <summary>If possible, returns results in the order of distance. The measure of distance is provider specific.</summary>
			LUP_NEAREST = 0x0008,

			/// <summary>Retrieves the name as lpszServiceInstanceName.</summary>
			LUP_RETURN_NAME = 0x0010,

			/// <summary>Retrieves the type as lpServiceClassId.</summary>
			LUP_RETURN_TYPE = 0x0020,

			/// <summary>Retrieves the version as lpVersion.</summary>
			LUP_RETURN_VERSION = 0x0040,

			/// <summary>Retrieves the comment as lpszComment.</summary>
			LUP_RETURN_COMMENT = 0x0080,

			/// <summary>Retrieves the addresses as lpcsaBuffer.</summary>
			LUP_RETURN_ADDR = 0x0100,

			/// <summary>Retrieves the private data as lpBlob.</summary>
			LUP_RETURN_BLOB = 0x0200,

			/// <summary>
			/// Any available alias information is to be returned in successive calls to WSALookupServiceNext, and each alias returned will
			/// have the RESULT_IS_ALIAS flag set.
			/// </summary>
			LUP_RETURN_ALIASES = 0x0400,

			/// <summary>Retrieves the query string used for the request.</summary>
			LUP_RETURN_QUERY_STRING = 0x0800,

			/// <summary>A set of flags that retrieves all of the LUP_RETURN_* values.</summary>
			LUP_RETURN_ALL = 0x0FF0,

			/// <summary>If the provider has cached information, ignore the cache and query the namespace itself.</summary>
			LUP_FLUSHCACHE = 0x1000,

			/// <summary>
			/// Used as a value for the dwControlFlags parameter in NSPLookupServiceNext. Setting this flag instructs the provider to
			/// discard the last result set, which was too large for the supplied buffer, and move on to the next result set.
			/// </summary>
			LUP_FLUSHPREVIOUS = 0x2000,

			/// <summary>Indicates that the namespace provider should included non-authoritative results for names.</summary>
			LUP_NON_AUTHORITATIVE = 0x4000,

			/// <summary>
			/// Indicates whether prime response is in the remote or local part of CSADDR_INFO structure. The other part must be usable in
			/// either case. This option applies only to service instance requests.
			/// </summary>
			LUP_RES_SERVICE = 0x8000,

			/// <summary>Indicates that the namespace provider should use a secure query. This option only applies to name query requests.</summary>
			LUP_SECURE = 0x8000,

			/// <summary>Indicates that the namespace provider should return only preferred names.</summary>
			LUP_RETURN_PREFERRED_NAMES = 0x10000,

			/// <summary>Indicates that the namespace provider should return the address configuration.</summary>
			LUP_ADDRCONFIG = 0x100000,

			/// <summary>
			/// Indicates that the namespace provider should return the dual addresses. This option only applies to dual-mode sockets (IPv6
			/// and IPv4 mapped addresses).
			/// </summary>
			LUP_DUAL_ADDR = 0x200000,

			/// <summary/>
			LUP_DNS_ONLY = 0x20000,

			/// <summary/>
			LUP_FILESERVER = 0x00400000,

			/// <summary>
			/// Indicates that the namespace provider should disable automatic International Domain Names encoding. This value is supported
			/// on Windows 8 and Windows Server 2012
			/// </summary>
			LUP_DISABLE_IDN_ENCODING = 0x00800000,

			/// <summary/>
			LUP_API_ANSI = 0x01000000,

			/// <summary/>
			LUP_RESOLUTION_HANDLE = 0x80000000,
		}

		/// <summary>
		/// The lpFlags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
		/// associated socket. That is, the semantics of this function are determined by the socket options and the lpFlags parameter.
		/// </summary>
		[PInvokeData("winsock2.h", MSDNShortId = "bfe66e11-e9a7-4321-ad55-3141113e9a03")]
		[Flags]
		public enum MsgFlags
		{
			/// <summary>Processes OOB data.</summary>
			MSG_OOB = 0x1,

			/// <summary>
			/// Peeks at the incoming data. The data is copied into the buffer, but is not removed from the input queue. This flag is valid
			/// only for nonoverlapped sockets.
			/// </summary>
			MSG_PEEK = 0x2,

			/// <summary/>
			MSG_DONTROUTE = 0x4,

			/// <summary>
			/// The receive request will complete only when one of the following events occurs: Be aware that if the underlying transport
			/// provider does not support MSG_WAITALL, or if the socket is in a non-blocking mode, then this call will fail with
			/// WSAEOPNOTSUPP. Also, if MSG_WAITALL is specified along with MSG_OOB, MSG_PEEK, or MSG_PARTIAL, then this call will fail with
			/// WSAEOPNOTSUPP. This flag is not supported on datagram sockets or message-oriented sockets.
			/// </summary>
			MSG_WAITALL = 0x8,

			/// <summary>
			/// This flag is for stream-oriented sockets only. This flag allows an application that uses stream sockets to tell the
			/// transport provider not to delay completion of partially filled pending receive requests. This is a hint to the transport
			/// provider that the application is willing to receive any incoming data as soon as possible without necessarily waiting for
			/// the remainder of the data that might still be in transit. What constitutes a partially filled pending receive request is a
			/// transport-specific matter. In the case of TCP, this refers to the case of incoming TCP segments being placed into the
			/// receive request data buffer where none of the TCP segments indicated a PUSH bit value of 1. In this case, TCP may hold the
			/// partially filled receive request a little longer to allow the remainder of the data to arrive with a TCP segment that has
			/// the PUSH bit set to 1. This flag tells TCP not to hold the receive request but to complete it immediately. Using this flag
			/// for large block transfers is not recommended since processing partial blocks is often not optimal. This flag is useful only
			/// for cases where receiving and processing the partial data immediately helps decrease processing latency. This flag is a hint
			/// rather than an actual guarantee. This flag is supported on Windows 8.1, Windows Server 2012 R2, and later.
			/// </summary>
			MSG_PUSH_IMMEDIATE = 0x20,

			/// <summary>
			/// This flag is for message-oriented sockets only. On output, this flag indicates that the data specified is a portion of the
			/// message transmitted by the sender. Remaining portions of the message will be specified in subsequent receive operations. A
			/// subsequent receive operation with the MSG_PARTIAL flag cleared indicates end of sender's message. As an input parameter,
			/// this flag indicates that the receive operation should complete even if only part of a message has been received by the
			/// transport provider.
			/// </summary>
			MSG_PARTIAL = 0x8000,

			/// <summary/>
			MSG_INTERRUPT = 0x10,

			/// <summary>The datagram was truncated. More data was present than the process allocated room for.</summary>
			MSG_TRUNC = 0x0100,

			/// <summary>The control (ancillary) data was truncated. More control data was present than the process allocated room for.</summary>
			MSG_CTRUNC = 0x0200,

			/// <summary>The datagram was received as a link-layer broadcast or with a destination IP address that is a broadcast address.</summary>
			MSG_BCAST = 0x0400,

			/// <summary>The datagram was received with a destination IP address that is a multicast address.</summary>
			MSG_MCAST = 0x0800,

			/// <summary>
			/// This flag specifies that queued errors should be received from the socket error queue. The error is passed in an ancillary
			/// message with a type dependent on the protocol (for IPv4 IP_RECVERR). The user should supply a buffer of sufficient size.See
			/// cmsg(3) and ip(7) for more information.The payload of the original packet that caused the error is passed as normal data via
			/// msg_iovec. The original destination address of the datagram that caused the error is supplied via msg_name.
			/// </summary>
			MSG_ERRQUEUE = 0x1000,
		}

		/// <summary>
		/// A set of flags that indicate the type of status being requested or, upon return from the WSAPoll function call, the results of
		/// the status query.
		/// </summary>
		[PInvokeData("winsock2.h", MSDNShortId = "88f122ce-e2ca-44ce-bd53-d73d0962e7ef")]
		[Flags]
		public enum PollFlags : short
		{
			/// <summary>Normal data may be read without blocking.</summary>
			POLLRDNORM = 0x0100,

			/// <summary>Priority band (out-of-band) data may be read without blocking.</summary>
			POLLRDBAND = 0x0200,

			/// <summary>POLLRDNORM | POLLRDBAND</summary>
			POLLIN = (POLLRDNORM | POLLRDBAND),

			/// <summary>Priority data may be read without blocking. This flag is not returned by the Microsoft Winsock provider.</summary>
			POLLPRI = 0x0400,

			/// <summary>Normal data may be written without blocking.</summary>
			POLLWRNORM = 0x0010,

			/// <summary>Normal data may be written without blocking.</summary>
			POLLOUT = (POLLWRNORM),

			/// <summary/>
			POLLWRBAND = 0x0020,

			/// <summary>An error has occurred.</summary>
			POLLERR = 0x0001,

			/// <summary>A stream-oriented connection was either disconnected or aborted.</summary>
			POLLHUP = 0x0002,

			/// <summary>An invalid socket was used.</summary>
			POLLNVAL = 0x0004,
		}

		/// <summary>Service install flags value that further controls the operation performed of the WSASetServicefunction.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "21a8ff26-4c9e-4846-a75a-1a27c746edab")]
		[Flags]
		public enum ServiceInstallFlags
		{
			/// <summary>
			/// Controls scope of operation. When this flag is not set, service addresses are managed as a group. A register or removal from
			/// the registry invalidates all existing addresses before adding the given address set. When set, the action is only performed
			/// on the given address set. A register does not invalidate existing addresses and a removal from the registry only invalidates
			/// the given set of addresses.
			/// </summary>
			SERVICE_MULTIPLE = 0x00000001,
		}

		/// <summary>A set of flags used to specify additional socket attributes.</summary>
		[PInvokeData("winsock2.h", MSDNShortId = "dcf2e543-de54-43d9-9e45-4cb935da3548")]
		[Flags]
		public enum WSA_FLAG
		{
			/// <term>
			/// Create a socket that supports overlapped I/O operations. Most sockets should be created with this flag set. Overlapped
			/// sockets can utilize WSASend, WSASendTo, WSARecv, WSARecvFrom, and WSAIoctl for overlapped I/O operations, which allow
			/// multiple operations to be initiated and in progress simultaneously. All functions that allow overlapped operation (WSASend,
			/// WSARecv, WSASendTo, WSARecvFrom, WSAIoctl) also support nonoverlapped usage on an overlapped socket if the values for
			/// parameters related to overlapped operations are NULL.
			/// </term>
			WSA_FLAG_OVERLAPPED = 0x01,

			/// <term>
			/// Create a socket that will be a c_root in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO
			/// structure for the transport provider that creates the socket supports a multipoint or multicast mechanism and the control
			/// plane for a multipoint session is rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO
			/// structure with the XP1_SUPPORT_MULTIPOINT and XP1_MULTIPOINT_CONTROL_PLANE flags set. When the lpProtocolInfo parameter is
			/// not NULL, the WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo parameter. When the
			/// lpProtocolInfo parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider selected by the values
			/// specified for the af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for additional information
			/// on a multipoint session.
			/// </term>
			WSA_FLAG_MULTIPOINT_C_ROOT = 0x02,

			/// <term>
			/// Create a socket that will be a c_leaf in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO
			/// structure for the transport provider that creates the socket supports a multipoint or multicast mechanism and the control
			/// plane for a multipoint session is non-rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO
			/// structure with the XP1_SUPPORT_MULTIPOINT flag set and the XP1_MULTIPOINT_CONTROL_PLANE flag not set. When the
			/// lpProtocolInfo parameter is not NULL, the WSAPROTOCOL_INFO structure for the transport provider is pointed to by the
			/// lpProtocolInfo parameter. When the lpProtocolInfo parameter is NULL, the WSAPROTOCOL_INFO structure is based on the
			/// transport provider selected by the values specified for the af, type, and protocol parameters. Refer to Multipoint and
			/// Multicast Semantics for additional information on a multipoint session.
			/// </term>
			WSA_FLAG_MULTIPOINT_C_LEAF = 0x04,

			/// <term>
			/// Create a socket that will be a d_root in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO
			/// structure for the transport provider that creates the socket supports a multipoint or multicast mechanism and the data plane
			/// for a multipoint session is rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO structure
			/// with the XP1_SUPPORT_MULTIPOINT and XP1_MULTIPOINT_DATA_PLANE flags set. When the lpProtocolInfo parameter is not NULL, the
			/// WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo parameter. When the lpProtocolInfo
			/// parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider selected by the values specified for
			/// the af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for additional information on a
			/// multipoint session.
			/// </term>
			WSA_FLAG_MULTIPOINT_D_ROOT = 0x08,

			/// <term>
			/// Create a socket that will be a d_leaf in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO
			/// structure for the transport provider that creates the socket supports a multipoint or multicast mechanism and the data plane
			/// for a multipoint session is non-rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO
			/// structure with the XP1_SUPPORT_MULTIPOINT flag set and the XP1_MULTIPOINT_DATA_PLANE flag not set. When the lpProtocolInfo
			/// parameter is not NULL, the WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo
			/// parameter. When the lpProtocolInfo parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider
			/// selected by the values specified for the af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for
			/// additional information on a multipoint session.
			/// </term>
			WSA_FLAG_MULTIPOINT_D_LEAF = 0x10,

			/// <term>
			/// Create a socket that allows the the ability to set a security descriptor on the socket that contains a security access
			/// control list (SACL) as opposed to just a discretionary access control list (DACL). SACLs are used for generating audits and
			/// alarms when an access check occurs on the object. For a socket, an access check occurs to determine whether the socket
			/// should be allowed to bind to a specific address specified to the bind function. The ACCESS_SYSTEM_SECURITY access right
			/// controls the ability to get or set the SACL in an object's security descriptor. The system grants this access right only if
			/// the SE_SECURITY_NAME privilege is enabled in the access token of the requesting thread.
			/// </term>
			WSA_FLAG_ACCESS_SYSTEM_SECURITY = 0x40,

			/// <term>
			/// Create a socket that is non-inheritable. A socket handle created by the WSASocket or the socket function is inheritable by
			/// default. When this flag is set, the socket handle is non-inheritable. The GetHandleInformation function can be used to
			/// determine if a socket handle was created with the WSA_FLAG_NO_HANDLE_INHERIT flag set. The GetHandleInformation function
			/// will return that the HANDLE_FLAG_INHERIT value is set. This flag is supported on Windows 7 with SP1, Windows Server 2008 R2
			/// with SP1, and later
			/// </term>
			WSA_FLAG_NO_HANDLE_INHERIT = 0x80,

			/// <summary/>
			WSA_FLAG_REGISTERED_IO = 0x100,
		}

		/// <summary>The <c>__WSAFDIsSet</c> function specifies whether a socket is included in a set of socket descriptors.</summary>
		/// <param name="arg1">TBD</param>
		/// <param name="arg2">
		/// Pointer to an fd_set structure containing the set of socket descriptors. The <c>__WSAFDIsSet</c> function determines whether the
		/// socket specified in the fd parameter is a member of that set.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-__wsafdisset int __WSAFDIsSet( SOCKET , fd_set * );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "ca420136-0b3b-45a1-85ce-83ab6ba1a70a")]
		public static extern int __WSAFDIsSet(SOCKET arg1, in fd_set arg2);

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
		/// The address of an optional, application-specified condition function that will make an accept/reject decision based on the
		/// caller information passed in as parameters, and optionally create or join a socket group by assigning an appropriate value to
		/// the result parameter g of this function. If this parameter is <c>NULL</c>, then no condition function is called.
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
		/// A blocking operation was interrupted by a call to WSACancelBlockingCall. This error is returned if a blocking Windows Sockets
		/// 1.1 call was canceled through WSACancelBlockingCall.
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
		/// A non-blocking socket operation could not be completed immediately. This error is returned if the socket is marked as
		/// nonblocking and no connections are present to be accepted.
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
		/// including asynchronous events registered with WSAAsyncSelect or with WSAEventSelect. If the condition function returns
		/// CF_REJECT, <c>WSAAccept</c> rejects the connection request. The condition function runs in the same thread as this function
		/// does, and should return as soon as possible. If the decision cannot be made immediately, the condition function should return
		/// CF_DEFER to indicate that no decision has been made, and no action about this connection request should be taken by the service
		/// provider. When the application is ready to take action on the connection request, it will invoke <c>WSAAccept</c> again and
		/// return either CF_ACCEPT or CF_REJECT as a return value from the condition function.
		/// </para>
		/// <para>
		/// A socket in default mode (blocking) will block until a connection is present when an application calls <c>WSAAccept</c> and no
		/// connections are pending on the queue.
		/// </para>
		/// <para>
		/// A socket in nonblocking mode (blocking) fails with the error WSAEWOULDBLOCK when an application calls <c>WSAAccept</c> and no
		/// connections are pending on the queue. After <c>WSAAccept</c> succeeds and returns a new socket handle, the accepted socket
		/// cannot be used to accept any more connections. The original socket remains open and listens for new connection requests.
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
		/// The lpCallerId parameter points to a WSABUF structure that contains the address of the connecting entity, where its len
		/// parameter is the length of the buffer in bytes, and its buf parameter is a pointer to the buffer. The lpCallerData is a value
		/// parameter that contains any user data. The information in these parameters is sent along with the connection request. If no
		/// caller identification or caller data is available, the corresponding parameters will be <c>NULL</c>. Many network protocols do
		/// not support connect-time caller data. Most conventional network protocols can be expected to support caller identifier
		/// information at connection-request time. The buf portion of the WSABUF pointed to by lpCallerId points to a sockaddr. The
		/// <c>sockaddr</c> structure is interpreted according to its address family (typically by casting the <c>sockaddr</c> to some type
		/// specific to the address family).
		/// </para>
		/// <para>
		/// The lpSQOS parameter references the FLOWSPEC structures for socket s specified by the caller, one for each direction, followed
		/// by any additional provider-specific parameters. The sending or receiving flow specification values will be ignored as
		/// appropriate for any unidirectional sockets. A <c>NULL</c> value indicates that there is no caller-supplied quality of service
		/// and that no negotiation is possible. A non- <c>NULL</c> lpSQOS pointer indicates that a quality of service negotiation is to
		/// occur or that the provider is prepared to accept the quality of service request without negotiation.
		/// </para>
		/// <para>
		/// The lpGQOS parameter is reserved, and should be <c>NULL</c>. (reserved for future use with socket groups) references the
		/// FLOWSPEC structure for the socket group the caller is to create, one for each direction, followed by any additional
		/// provider-specific parameters. A <c>NULL</c> value for lpGQOS indicates no caller-specified group quality of service. Quality of
		/// service information can be returned if negotiation is to occur.
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
		/// are unique across all processes for a given service provider. A socket group and its associated identifier remain valid until
		/// the last socket belonging to this socket group is closed. Socket group identifiers are unique across all processes for a given
		/// service provider. For more information on socket groups, see the Remarks for the WSASocket functions.
		/// </para>
		/// <para>
		/// The dwCallbackData parameter value passed to the condition function is the value passed as the dwCallbackData parameter in the
		/// original <c>WSAAccept</c> call. This value is interpreted only by the Windows Socket version 2 client. This allows a client to
		/// pass some context information from the <c>WSAAccept</c> call site through to the condition function. This also provides the
		/// condition function with any additional information required to determine whether to accept the connection or not. A typical
		/// usage is to pass a (suitably cast) pointer to a data structure containing references to application-defined objects with which
		/// this socket is associated.
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
		public static extern SOCKET WSAAccept(SOCKET s, SOCKADDR addr, ref int addrlen, [In, Out, Optional] ConditionFunc lpfnCondition, [In, Out, Optional] IntPtr dwCallbackData);

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
		/// A pointer to the WSAPROTOCOL_INFO structure for a particular provider. If this is parameter is <c>NULL</c>, the call is routed
		/// to the provider of the first protocol supporting the address family indicated in the lpsaAddress parameter.
		/// </param>
		/// <param name="lpszAddressString">A pointer to the buffer that receives the human-readable address string.</param>
		/// <param name="lpdwAddressStringLength">
		/// On input, this parameter specifies the length of the buffer pointed to by the lpszAddressString parameter. The length is
		/// represented in bytes for ANSI strings, and in WCHARs for Unicode strings. On output, this parameter returns the length of the
		/// string including the <c>NULL</c> terminator actually copied into the buffer pointed to by the lpszAddressString parameter. If
		/// the specified buffer is not large enough, the function fails with a specific error of WSAEFAULT and this parameter is updated
		/// with the required size.
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
		/// An invalid parameter was passed. This error is returned if the lpsaAddress, dwAddressLength, or lpdwAddressStringLength
		/// parameter are NULL. This error is also returned if the specified address is not a valid socket address, or no transport provider
		/// supports the indicated address family.
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
		/// <c>WSAAddressToString</c> function takes a socket address structure pointed to by the lpsaAddress parameter and returns a
		/// pointer to <c>NULL</c>-terminated string that represents the socket address in the lpszAddressString parameter. While the
		/// inet_ntoa function works only with IPv4 addresses, the <c>WSAAddressToString</c> function works with any socket address
		/// supported by a Winsock provider on the local computer including IPv6 addresses.
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
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAAddressToStringW</c> function is supported for Windows Store
		/// apps on Windows 8.1, Windows Server 2012 R2, and later.
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
		/// A pointer to the WSAPROTOCOL_INFO structure for a particular provider. If this is parameter is <c>NULL</c>, the call is routed
		/// to the provider of the first protocol supporting the address family indicated in the lpsaAddress parameter.
		/// </param>
		/// <param name="lpszAddressString">A pointer to the buffer that receives the human-readable address string.</param>
		/// <param name="lpdwAddressStringLength">
		/// On input, this parameter specifies the length of the buffer pointed to by the lpszAddressString parameter. The length is
		/// represented in bytes for ANSI strings, and in WCHARs for Unicode strings. On output, this parameter returns the length of the
		/// string including the <c>NULL</c> terminator actually copied into the buffer pointed to by the lpszAddressString parameter. If
		/// the specified buffer is not large enough, the function fails with a specific error of WSAEFAULT and this parameter is updated
		/// with the required size.
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
		/// An invalid parameter was passed. This error is returned if the lpsaAddress, dwAddressLength, or lpdwAddressStringLength
		/// parameter are NULL. This error is also returned if the specified address is not a valid socket address, or no transport provider
		/// supports the indicated address family.
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
		/// <c>WSAAddressToString</c> function takes a socket address structure pointed to by the lpsaAddress parameter and returns a
		/// pointer to <c>NULL</c>-terminated string that represents the socket address in the lpszAddressString parameter. While the
		/// inet_ntoa function works only with IPv4 addresses, the <c>WSAAddressToString</c> function works with any socket address
		/// supported by a Winsock provider on the local computer including IPv6 addresses.
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
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAAddressToStringW</c> function is supported for Windows Store
		/// apps on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-wsaaddresstostringa INT WSAAPI WSAAddressToStringA(
		// LPSOCKADDR lpsaAddress, DWORD dwAddressLength, LPWSAPROTOCOL_INFOA lpProtocolInfo, LPSTR lpszAddressString, LPDWORD
		// lpdwAddressStringLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "d72e55e6-79a9-4386-9e1a-24a322f13426")]
		public static extern int WSAAddressToString([In] SOCKADDR lpsaAddress, uint dwAddressLength, [Optional] IntPtr lpProtocolInfo, StringBuilder lpszAddressString, ref uint lpdwAddressStringLength);

		/// <summary>
		/// <para>The <c>WSAAsyncGetHostByAddr</c> function asynchronously retrieves host information that corresponds to an address.</para>
		/// <para>
		/// <c>Note</c> The <c>WSAAsyncGetHostByAddr</c> function is not designed to provide parallel resolution of several addresses.
		/// Therefore, applications that issue several requests should not expect them to be executed concurrently. Alternatively,
		/// applications can start another thread and use the getnameinfo function to resolve addresses in an IP-version agnostic manner.
		/// Developers creating Windows Sockets 2 applications are urged to use the <c>getnameinfo</c> function to enable smooth transition
		/// to IPv6 compatibility.
		/// </para>
		/// </summary>
		/// <param name="hWnd">[in] The handle of the window which should receive a message when the asynchronous request completes.</param>
		/// <param name="wMsg">[in] The message to be received when the asynchronous request completes.</param>
		/// <param name="addr">[in] A pointer to the network address for the host. Host addresses are stored in network byte order.</param>
		/// <param name="len">[in] The length of the address.</param>
		/// <param name="type">[in] The type of the address.</param>
		/// <param name="buf">
		/// [out] A pointer to the data area to receive the hostent data. Note that this must be larger than the size of a hostent
		/// structure. This is because the data area supplied is used by Windows Sockets to contain not only a hostent structure but any and
		/// all of the data which is referenced by members of the hostent structure. It is recommended that you supply a buffer of
		/// MAXGETHOSTSTRUCT bytes.
		/// </param>
		/// <param name="buflen">[in] The size of data area buf above.</param>
		/// <returns>
		/// <para>
		/// The return value specifies whether or not the asynchronous operation was successfully initiated. It does not imply success or
		/// failure of the operation itself.
		/// </para>
		/// <para>
		/// If no error occurs, <c>WSAAsyncGetHostByAddr</c> returns a nonzero value of type HANDLE that is the asynchronous task handle
		/// (not to be confused with a Windows HTASK) for the request. This value can be used in two ways. It can be used to cancel the
		/// operation using WSACancelAsyncRequest, or it can be used to match up asynchronous operations and completion messages by
		/// examining the wParam message parameter.
		/// </para>
		/// <para>
		/// If the asynchronous operation could not be initiated, <c>WSAAsyncGetHostByAddr</c> returns a zero value, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// The following error codes can be set when an application window receives a message. As described above, they can be extracted
		/// from the lParam in the reply message using the <c>WSAGETASYNCERROR</c> macro.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The addr or buf parameter is not in a valid part of the process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>Authoritative answer host not found.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>Nonauthoritative host not found, or SERVERFAIL.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>Nonrecoverable errors: FORMERR, REFUSED, NOTIMP.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>Valid name, no data record of requested type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following errors can occur at the time of the function call, and indicate that the asynchronous operation could not be initiated.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error Code</term>
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
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The asynchronous operation cannot be scheduled at this time due to resource or other constraints within the Windows Sockets implementation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncGetHostByAddr</c> function is an asynchronous version of gethostbyaddr. It is used to retrieve the host name and
		/// address information that corresponds to a network address. Windows Sockets initiates the operation and returns to the caller
		/// immediately, passing back an opaque, asynchronous task handle that the application can use to identify the operation. When the
		/// operation is completed, the results (if any) are copied into the buffer provided by the caller and a message is sent to the
		/// application's window.
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the application window indicated by the hWnd parameter receives message in the
		/// wMsg parameter. The wParam parameter contains the asynchronous task handle as returned by the original function call. The high
		/// 16 bits of lParam contain any error code. The error code can be any error as defined in Winsock2.h. An error code of zero
		/// indicates successful completion of the asynchronous operation.
		/// </para>
		/// <para>
		/// On successful completion, the buffer specified to the original function call contains a hostent structure. To access the members
		/// of this structure, the original buffer address is cast to a <c>hostent</c> structure pointer and accessed as appropriate.
		/// </para>
		/// <para>
		/// If the error code is WSAENOBUFS, the size of the buffer specified by buflen in the original call was too small to contain all
		/// the resulting information. In this case, the low 16 bits of lParam contain the size of buffer required to supply all the
		/// requisite information. If the application decides that the partial data is inadequate, it can reissue the
		/// <c>WSAAsyncGetHostByAddr</c> function call with a buffer large enough to receive all the desired information (that is, no
		/// smaller than the low 16 bits of lParam).
		/// </para>
		/// <para>
		/// The buffer specified to this function is used by Windows Sockets to construct a structure together with the contents of data
		/// areas referenced by members of the same hostent structure. To avoid the WSAENOBUFS error, the application should provide a
		/// buffer of at least MAXGETHOSTSTRUCT bytes (as defined in Winsock2.h).
		/// </para>
		/// <para>
		/// The error code and buffer length should be extracted from the lParam using the macros <c>WSAGETASYNCERROR</c> and
		/// <c>WSAGETASYNCBUFLEN</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsaasyncgethostbyaddr HANDLE WSAAsyncGetHostByAddr( HWND
		// hWnd, u_int wMsg, const char *addr, int len, int type, char *buf, int buflen );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "814cbb2e-8dd2-44b0-b8be-cfc5491bdc49")]
		public static extern HANDLE WSAAsyncGetHostByAddr(HWND hWnd, uint wMsg, [In] IntPtr addr, int len, int type, [Out] IntPtr buf, int buflen);

		/// <summary>
		/// <para>The <c>WSAAsyncGetHostByName</c> function asynchronously retrieves host information that corresponds to a host name.</para>
		/// <para>
		/// <c>Note</c> The <c>WSAAsyncGetHostByName</c> function is not designed to provide parallel resolution of several names.
		/// Therefore, applications that issue several requests should not expect them to be executed concurrently. Alternatively,
		/// applications can start another thread and use the getaddrinfo function to resolve names in an IP-version agnostic manner.
		/// Developers creating Windows Sockets 2 applications are urged to use the <c>getaddrinfo</c> function to enable smooth transition
		/// to IPv6 compatibility.
		/// </para>
		/// </summary>
		/// <param name="hWnd">[in] The handle of the window which should receive a message when the asynchronous request completes.</param>
		/// <param name="wMsg">[in] The message to be received when the asynchronous request completes.</param>
		/// <param name="name">[in] A pointer to the null terminated name of the host.</param>
		/// <param name="buf">
		/// [out] A pointer to the data area to receive the hostent data. Note that this must be larger than the size of a hostent
		/// structure. This is because the data area supplied is used by Windows Sockets to contain not only a hostent structure but any and
		/// all of the data which is referenced by members of the hostent structure. It is recommended that you supply a buffer of
		/// MAXGETHOSTSTRUCT bytes.
		/// </param>
		/// <param name="buflen">[in] The size of data area buf above.</param>
		/// <returns>
		/// The return value specifies whether or not the asynchronous operation was successfully initiated. Note that it does not imply
		/// success or failure of the operation itself.
		/// <para>
		/// If the operation was successfully initiated, WSAAsyncGetHostByName returns a nonzero value of type HANDLE which is the
		/// asynchronous task handle(not to be confused with a Windows HTASK) for the request.This value can be used in two ways. It can be
		/// used to cancel the operation using WSACancelAsyncRequest. It can also be used to match up asynchronous operations and completion
		/// messages, by examining the wParam message argument.
		/// </para>
		/// <para>
		/// If the asynchronous operation could not be initiated, WSAAsyncGetHostByName returns a zero value, and a specific error number
		/// can be retrieved by calling WSAGetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncGetHostByName</c> function is an asynchronous version of gethostbyname, and is used to retrieve host name and
		/// address information corresponding to a host name. Windows Sockets initiates the operation and returns to the caller immediately,
		/// passing back an opaque asynchronous task handle that which the application can use to identify the operation. When the operation
		/// is completed, the results (if any) are copied into the buffer provided by the caller and a message is sent to the application's window.
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the application window indicated by the hWnd parameter receives message in the
		/// wMsg parameter. The wParam parameter contains the asynchronous task handle as returned by the original function call. The high
		/// 16 bits of lParam contain any error code. The error code can be any error as defined in Winsock2.h. An error code of zero
		/// indicates successful completion of the asynchronous operation.
		/// </para>
		/// <para>
		/// On successful completion, the buffer specified to the original function call contains a hostent structure. To access the
		/// elements of this structure, the original buffer address should be cast to a <c>hostent</c> structure pointer and accessed as appropriate.
		/// </para>
		/// <para>
		/// If the error code is WSAENOBUFS, the size of the buffer specified by buflen in the original call was too small to contain all
		/// the resulting information. In this case, the low 16 bits of lParam contain the size of buffer required to supply all the
		/// requisite information. If the application decides that the partial data is inadequate, it can reissue the
		/// <c>WSAAsyncGetHostByName</c> function call with a buffer large enough to receive all the desired information (that is, no
		/// smaller than the low 16 bits of lParam).
		/// </para>
		/// <para>
		/// The buffer specified to this function is used by Windows Sockets to construct a hostent structure together with the contents of
		/// data areas referenced by members of the same <c>hostent</c> structure. To avoid the WSAENOBUFS error, the application should
		/// provide a buffer of at least MAXGETHOSTSTRUCT bytes (as defined in Winsock2.h).
		/// </para>
		/// <para>
		/// The error code and buffer length should be extracted from the lParam using the macros <c>WSAGETASYNCERROR</c> and
		/// <c>WSAGETASYNCBUFLEN</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// <para><c>WSAAsyncGetHostByName</c> is guaranteed to resolve the string returned by a successful call to gethostname.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wsipv6ok/nf-wsipv6ok-wsaasyncgethostbyname HANDLE WSAAsyncGetHostByName( _In_
		// HWND hWnd, _In_ u_int wMsg, _In_z_ const char FAR * name, _Out_writes_bytes_(buflen) char FAR * buf, _In_ int buflen );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("wsipv6ok.h", MSDNShortId = "1a2b9c76-6e84-4ac2-b5c1-a2268edd0c49")]
		public static extern HANDLE WSAAsyncGetHostByName(HWND hWnd, uint wMsg, [In] string name, [Out] IntPtr buf, int buflen);

		/// <summary>
		/// The <c>WSAAsyncGetProtoByName</c> function asynchronously retrieves protocol information that corresponds to a protocol name.
		/// </summary>
		/// <param name="hWnd">Handle of the window that will receive a message when the asynchronous request completes.</param>
		/// <param name="wMsg">Message to be received when the asynchronous request completes.</param>
		/// <param name="name">Pointer to the null-terminated protocol name to be resolved.</param>
		/// <param name="buf">
		/// Pointer to the data area to receive the protoent data. The data area must be larger than the size of a <c>protoent</c> structure
		/// because the data area is used by Windows Sockets to contain a <c>protoent</c> structure and all of the data that is referenced
		/// by members of the <c>protoent</c> structure. A buffer of MAXGETHOSTSTRUCT bytes is recommended.
		/// </param>
		/// <param name="buflen">Size of data area for the buf parameter, in bytes.</param>
		/// <returns>
		/// <para>
		/// The return value specifies whether or not the asynchronous operation was successfully initiated. It does not imply success or
		/// failure of the operation itself.
		/// </para>
		/// <para>
		/// If no error occurs, <c>WSAAsyncGetProtoByName</c> returns a nonzero value of type HANDLE that is the asynchronous task handle
		/// for the request (not to be confused with a Windows HTASK). This value can be used in two ways. It can be used to cancel the
		/// operation using WSACancelAsyncRequest, or it can be used to match up asynchronous operations and completion messages, by
		/// examining the wParam message parameter.
		/// </para>
		/// <para>
		/// If the asynchronous operation could not be initiated, <c>WSAAsyncGetProtoByName</c> returns a zero value, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// The following error codes can be set when an application window receives a message. As described above, they can be extracted
		/// from the lParam in the reply message using the <c>WSAGETASYNCERROR</c> macro.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The name or buf parameter is not in a valid part of the process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>Authoritative answer protocol not found.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>A nonauthoritative protocol not found, or server failure.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>Nonrecoverable errors, the protocols database is not accessible.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>Valid name, no data record of requested type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following errors can occur at the time of the function call, and indicate that the asynchronous operation could not be initiated.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The asynchronous operation cannot be scheduled at this time due to resource or other constraints within the Windows Sockets implementation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncGetProtoByName</c> function is an asynchronous version of getprotobyname. It is used to retrieve the protocol
		/// name and number from the Windows Sockets database corresponding to a given protocol name. Windows Sockets initiates the
		/// operation and returns to the caller immediately, passing back an opaque, asynchronous task handle that the application can use
		/// to identify the operation. When the operation is completed, the results (if any) are copied into the buffer provided by the
		/// caller and a message is sent to the application's window.
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the application window indicated by the hWnd parameter receives message in the
		/// wMsg parameter. The wParam parameter contains the asynchronous task handle as returned by the original function call. The high
		/// 16 bits of lParam contain any error code. The error code can be any error as defined in Winsock2.h. An error code of zero
		/// indicates successful completion of the asynchronous operation.
		/// </para>
		/// <para>
		/// On successful completion, the buffer specified to the original function call contains a protoent structure. To access the
		/// members of this structure, the original buffer address should be cast to a <c>protoent</c> structure pointer and accessed as appropriate.
		/// </para>
		/// <para>
		/// If the error code is WSAENOBUFS, the size of the buffer specified by buflen in the original call was too small to contain all
		/// the resulting information. In this case, the low 16 bits of lParam contain the size of buffer required to supply all the
		/// requisite information. If the application decides that the partial data is inadequate, it can reissue the
		/// <c>WSAAsyncGetProtoByName</c> function call with a buffer large enough to receive all the desired information (that is, no
		/// smaller than the low 16 bits of lParam).
		/// </para>
		/// <para>
		/// The buffer specified to this function is used by Windows Sockets to construct a protoent structure together with the contents of
		/// data areas referenced by members of the same <c>protoent</c> structure. To avoid the WSAENOBUFS error noted above, the
		/// application should provide a buffer of at least MAXGETHOSTSTRUCT bytes (as defined in Winsock2.h).
		/// </para>
		/// <para>
		/// The error code and buffer length should be extracted from the lParam using the macros <c>WSAGETASYNCERROR</c> and
		/// <c>WSAGETASYNCBUFLEN</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsaasyncgetprotobyname HANDLE WSAAsyncGetProtoByName( HWND
		// hWnd, u_int wMsg, const char *name, char *buf, int buflen );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("winsock.h", MSDNShortId = "747c40fd-5dc1-4533-896e-bc1c4368d7bd")]
		public static extern HANDLE WSAAsyncGetProtoByName(HWND hWnd, uint wMsg, [In] string name, [Out] IntPtr buf, int buflen);

		/// <summary>
		/// The <c>WSAAsyncGetProtoByNumber</c> function asynchronously retrieves protocol information that corresponds to a protocol number.
		/// </summary>
		/// <param name="hWnd">Handle of the window that will receive a message when the asynchronous request completes.</param>
		/// <param name="wMsg">Message to be received when the asynchronous request completes.</param>
		/// <param name="number">Protocol number to be resolved, in host byte order.</param>
		/// <param name="buf">
		/// Pointer to the data area to receive the protoent data. The data area must be larger than the size of a <c>protoent</c> structure
		/// because the data area is used by Windows Sockets to contain a <c>protoent</c> structure and all of the data that is referenced
		/// by members of the <c>protoent</c> structure. A buffer of MAXGETHOSTSTRUCT bytes is recommended.
		/// </param>
		/// <param name="buflen">Size of data area for the buf parameter, in bytes.</param>
		/// <returns>
		/// <para>
		/// The return value specifies whether or not the asynchronous operation was successfully initiated. It does not imply success or
		/// failure of the operation itself.
		/// </para>
		/// <para>
		/// If no error occurs, <c>WSAAsyncGetProtoByNumber</c> returns a nonzero value of type <c>HANDLE</c> that is the asynchronous task
		/// handle for the request (not to be confused with a Windows HTASK). This value can be used in two ways. It can be used to cancel
		/// the operation using WSACancelAsyncRequest, or it can be used to match up asynchronous operations and completion messages, by
		/// examining the wParam message parameter.
		/// </para>
		/// <para>
		/// If the asynchronous operation could not be initiated, <c>WSAAsyncGetProtoByNumber</c> returns a zero value, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// The following error codes can be set when an application window receives a message. As described above, they can be extracted
		/// from the lParam in the reply message using the <c>WSAGETASYNCERROR</c> macro.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The buf parameter is not in a valid part of the process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>Authoritative answer protocol not found.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>Nonauthoritative protocol not found, or server failure.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>Nonrecoverable errors, the protocols database is not accessible.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>Valid name, no data record of requested type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following errors can occur at the time of the function call, and indicate that the asynchronous operation could not be initiated.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The asynchronous operation cannot be scheduled at this time due to resource or other constraints within the Windows Sockets implementation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncGetProtoByNumber</c> function is an asynchronous version of getprotobynumber, and is used to retrieve the
		/// protocol name and number corresponding to a protocol number. Windows Sockets initiates the operation and returns to the caller
		/// immediately, passing back an opaque, asynchronous task handle that the application can use to identify the operation. When the
		/// operation is completed, the results (if any) are copied into the buffer provided by the caller and a message is sent to the
		/// application's window.
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the application window indicated by the hWnd parameter receives message in the
		/// wMsg parameter. The wParam parameter contains the asynchronous task handle as returned by the original function call. The high
		/// 16 bits of lParam contain any error code. The error code can be any error as defined in Winsock2.h. An error code of zero
		/// indicates successful completion of the asynchronous operation.
		/// </para>
		/// <para>
		/// On successful completion, the buffer specified to the original function call contains a protoent structure. To access the
		/// members of this structure, the original buffer address is cast to a <c>protoent</c> structure pointer and accessed as appropriate.
		/// </para>
		/// <para>
		/// If the error code is WSAENOBUFS, the size of the buffer specified by buflen in the original call was too small to contain all
		/// the resulting information. In this case, the low 16 bits of lParam contain the size of buffer required to supply all the
		/// requisite information. If the application decides that the partial data is inadequate, it can reissue the
		/// <c>WSAAsyncGetProtoByNumber</c> function call with a buffer large enough to receive all the desired information (that is, no
		/// smaller than the low 16 bits of lParam).
		/// </para>
		/// <para>
		/// The buffer specified to this function is used by Windows Sockets to construct a protoent structure together with the contents of
		/// data areas referenced by members of the same <c>protoent</c> structure. To avoid the WSAENOBUFS error noted above, the
		/// application should provide a buffer of at least MAXGETHOSTSTRUCT bytes (as defined in Winsock2.h).
		/// </para>
		/// <para>
		/// The error code and buffer length should be extracted from the lParam using the macros <c>WSAGETASYNCERROR</c> and
		/// <c>WSAGETASYNCBUFLEN</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsaasyncgetprotobynumber HANDLE WSAAsyncGetProtoByNumber(
		// HWND hWnd, u_int wMsg, int number, char *buf, int buflen );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "10f28345-c178-47c0-9d0f-87f6743131d9")]
		public static extern HANDLE WSAAsyncGetProtoByNumber(HWND hWnd, uint wMsg, int number, [Out] IntPtr buf, int buflen);

		/// <summary>
		/// The <c>WSAAsyncGetServByName</c> function asynchronously retrieves service information that corresponds to a service name and port.
		/// </summary>
		/// <param name="hWnd">Handle of the window that should receive a message when the asynchronous request completes.</param>
		/// <param name="wMsg">Message to be received when the asynchronous request completes.</param>
		/// <param name="name">Pointer to a <c>null</c>-terminated service name.</param>
		/// <param name="proto">
		/// Pointer to a protocol name. This can be <c>NULL</c>, in which case <c>WSAAsyncGetServByName</c> will search for the first
		/// service entry for which s_name or one of the s_aliases matches the given name. Otherwise, <c>WSAAsyncGetServByName</c> matches
		/// both name and proto.
		/// </param>
		/// <param name="buf">
		/// Pointer to the data area to receive the servent data. The data area must be larger than the size of a <c>servent</c> structure
		/// because the data area is used by Windows Sockets to contain a <c>servent</c> structure and all of the data that is referenced by
		/// members of the <c>servent</c> structure. A buffer of MAXGETHOSTSTRUCT bytes is recommended.
		/// </param>
		/// <param name="buflen">Size of data area for the buf parameter, in bytes.</param>
		/// <returns>
		/// <para>
		/// The return value specifies whether or not the asynchronous operation was successfully initiated. It does not imply success or
		/// failure of the operation itself.
		/// </para>
		/// <para>
		/// If no error occurs, <c>WSAAsyncGetServByName</c> returns a nonzero value of type <c>HANDLE</c> that is the asynchronous task
		/// handle for the request (not to be confused with a Windows HTASK). This value can be used in two ways. It can be used to cancel
		/// the operation using WSACancelAsyncRequest, or it can be used to match up asynchronous operations and completion messages, by
		/// examining the wParam message parameter.
		/// </para>
		/// <para>
		/// If the asynchronous operation could not be initiated, <c>WSAAsyncServByName</c> returns a zero value, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// The following error codes can be set when an application window receives a message. As described above, they can be extracted
		/// from the lParam in the reply message using the <c>WSAGETASYNCERROR</c> macro.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The buf parameter is not in a valid part of the process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>Authoritative answer host not found.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>Nonauthoritative service not found, or server failure.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>Nonrecoverable errors, the services database is not accessible.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>Valid name, no data record of requested type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following errors can occur at the time of the function call, and indicate that the asynchronous operation could not be initiated.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The asynchronous operation cannot be scheduled at this time due to resource or other constraints within the Windows Sockets implementation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncGetServByName</c> function is an asynchronous version of getservbyname and is used to retrieve service
		/// information corresponding to a service name. Windows Sockets initiates the operation and returns to the caller immediately,
		/// passing back an opaque, asynchronous task handle that the application can use to identify the operation. When the operation is
		/// completed, the results (if any) are copied into the buffer provided by the caller and a message is sent to the application's window.
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the application window indicated by the hWnd parameter receives message in the
		/// wMsg parameter. The wParam parameter contains the asynchronous task handle as returned by the original function call. The high
		/// 16 bits of lParam contain any error code. The error code can be any error as defined in Winsock2.h. An error code of zero
		/// indicates successful completion of the asynchronous operation.
		/// </para>
		/// <para>
		/// On successful completion, the buffer specified to the original function call contains a servent structure. To access the members
		/// of this structure, the original buffer address should be cast to a <c>servent</c> structure pointer and accessed as appropriate.
		/// </para>
		/// <para>
		/// If the error code is WSAENOBUFS, the size of the buffer specified by buflen in the original call was too small to contain all
		/// the resulting information. In this case, the low 16 bits of lParam contain the size of buffer required to supply all the
		/// requisite information. If the application decides that the partial data is inadequate, it can reissue the
		/// <c>WSAAsyncGetServByName</c> function call with a buffer large enough to receive all the desired information (that is, no
		/// smaller than the low 16 bits of lParam).
		/// </para>
		/// <para>
		/// The buffer specified to this function is used by Windows Sockets to construct a servent structure together with the contents of
		/// data areas referenced by members of the same <c>servent</c> structure. To avoid the WSAENOBUFS error, the application should
		/// provide a buffer of at least MAXGETHOSTSTRUCT bytes (as defined in Winsock2.h).
		/// </para>
		/// <para>
		/// The error code and buffer length should be extracted from the lParam using the macros <c>WSAGETASYNCERROR</c> and
		/// <c>WSAGETASYNCBUFLEN</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsaasyncgetservbyname HANDLE WSAAsyncGetServByName( HWND
		// hWnd, u_int wMsg, const char *name, const char *proto, char *buf, int buflen );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("winsock.h", MSDNShortId = "d3524197-cd7a-4863-8fbb-a05e6f5d38e0")]
		public static extern HANDLE WSAAsyncGetServByName(HWND hWnd, uint wMsg, [In] string name, [In, Optional] string proto, [Out] IntPtr buf, int buflen);

		/// <summary>
		/// The <c>WSAAsyncGetServByPort</c> function asynchronously retrieves service information that corresponds to a port and protocol.
		/// </summary>
		/// <param name="hWnd">Handle of the window that should receive a message when the asynchronous request completes.</param>
		/// <param name="wMsg">Message to be received when the asynchronous request completes.</param>
		/// <param name="port">Port for the service, in network byte order.</param>
		/// <param name="proto">
		/// Pointer to a protocol name. This can be <c>NULL</c>, in which case <c>WSAAsyncGetServByPort</c> will search for the first
		/// service entry for which s_port match the given port. Otherwise, <c>WSAAsyncGetServByPort</c> matches both port and proto.
		/// </param>
		/// <param name="buf">
		/// Pointer to the data area to receive the servent data. The data area must be larger than the size of a <c>servent</c> structure
		/// because the data area is used by Windows Sockets to contain a <c>servent</c> structure and all of the data that is referenced by
		/// members of the <c>servent</c> structure. A buffer of MAXGETHOSTSTRUCT bytes is recommended.
		/// </param>
		/// <param name="buflen">Size of data area for the buf parameter, in bytes.</param>
		/// <returns>
		/// <para>
		/// The return value specifies whether or not the asynchronous operation was successfully initiated. It does not imply success or
		/// failure of the operation itself.
		/// </para>
		/// <para>
		/// If no error occurs, <c>WSAAsyncGetServByPort</c> returns a nonzero value of type <c>HANDLE</c> that is the asynchronous task
		/// handle for the request (not to be confused with a Windows HTASK). This value can be used in two ways. It can be used to cancel
		/// the operation using WSACancelAsyncRequest, or it can be used to match up asynchronous operations and completion messages, by
		/// examining the wParam message parameter.
		/// </para>
		/// <para>
		/// If the asynchronous operation could not be initiated, <c>WSAAsyncGetServByPort</c> returns a zero value, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// The following error codes can be set when an application window receives a message. As described above, they can be extracted
		/// from the lParam in the reply message using the <c>WSAGETASYNCERROR</c> macro.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The proto or buf parameter is not in a valid part of the process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>Authoritative answer port not found.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>Nonauthoritative port not found, or server failure.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>Nonrecoverable errors, the services database is not accessible.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>Valid name, no data record of requested type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The following errors can occur at the time of the function call, and indicate that the asynchronous operation could not be initiated.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The asynchronous operation cannot be scheduled at this time due to resource or other constraints within the Windows Sockets implementation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncGetServByPort</c> function is an asynchronous version of getservbyport, and is used to retrieve service
		/// information corresponding to a port number. Windows Sockets initiates the operation and returns to the caller immediately,
		/// passing back an opaque, asynchronous task handle that the application can use to identify the operation. When the operation is
		/// completed, the results (if any) are copied into the buffer provided by the caller and a message is sent to the application's window.
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the application window indicated by the hWnd parameter receives message in the
		/// wMsg parameter. The wParam parameter contains the asynchronous task handle as returned by the original function call. The high
		/// 16 bits of lParam contain any error code. The error code can be any error as defined in Winsock2.h. An error code of zero
		/// indicates successful completion of the asynchronous operation.
		/// </para>
		/// <para>
		/// On successful completion, the buffer specified to the original function call contains a servent structure. To access the members
		/// of this structure, the original buffer address should be cast to a <c>servent</c> structure pointer and accessed as appropriate.
		/// </para>
		/// <para>
		/// If the error code is WSAENOBUFS, the size of the buffer specified by buflen in the original call was too small to contain all
		/// the resulting information. In this case, the low 16 bits of lParam contain the size of buffer required to supply all the
		/// requisite information. If the application decides that the partial data is inadequate, it can reissue the
		/// <c>WSAAsyncGetServByPort</c> function call with a buffer large enough to receive all the desired information (that is, no
		/// smaller than the low 16 bits of lParam).
		/// </para>
		/// <para>
		/// The buffer specified to this function is used by Windows Sockets to construct a servent structure together with the contents of
		/// data areas referenced by members of the same <c>servent</c> structure. To avoid the WSAENOBUFS error, the application should
		/// provide a buffer of at least MAXGETHOSTSTRUCT bytes (as defined in Winsock2.h).
		/// </para>
		/// <para>
		/// The error code and buffer length should be extracted from the lParam using the macros <c>WSAGETASYNCERROR</c> and
		/// <c>WSAGETASYNCBUFLEN</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaasyncgetservbyport HANDLE WSAAPI
		// WSAAsyncGetServByPort( HWND hWnd, u_int wMsg, int port, const char *proto, char *buf, int buflen );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "0d0bd09c-ea97-46fb-b7b0-6e3e0a41dbc1")]
		public static extern HANDLE WSAAsyncGetServByPort(HWND hWnd, uint wMsg, int port, [In, Optional] string proto, [Out] IntPtr buf, int buflen);

		/// <summary>
		/// <para>
		/// [The <c>WSAAsyncSelect</c> function is available for use in the operating systems specified in the Requirements section. It may
		/// be altered or unavailable in subsequent versions. Rather than use Select-style I/O, use Overlapped I/O and Event Objects with WinSock2.]
		/// </para>
		/// <para>The <c>WSAAsyncSelect</c> function requests Windows message-based notification of network events for a socket.</para>
		/// </summary>
		/// <param name="s">A descriptor that identifies the socket for which event notification is required.</param>
		/// <param name="hWnd">A handle that identifies the window that will receive a message when a network event occurs.</param>
		/// <param name="wMsg">A message to be received when a network event occurs.</param>
		/// <param name="lEvent">A bitmask that specifies a combination of network events in which the application is interested.</param>
		/// <returns>
		/// <para>
		/// If the <c>WSAAsyncSelect</c> function succeeds, the return value is zero, provided that the application's declaration of
		/// interest in the network event set was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error number can
		/// be retrieved by calling WSAGetLastError.
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
		/// <term>The network subsystem failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// One of the specified parameters was invalid, such as the window handle not referring to an existing window, or the specified
		/// socket is in an invalid state.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Additional error codes can be set when an application window receives a message. This error code is extracted from the lParam in
		/// the reply message using the <c>WSAGETSELECTERROR</c> macro. Possible error codes for each network event are listed in the
		/// following table.
		/// </para>
		/// <para>Event: FD_CONNECT</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>Addresses in the specified family cannot be used with this socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNREFUSED</term>
		/// <term>The attempt to connect was rejected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The network cannot be reached from this host at this time.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The namelen parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket is already bound to an address.</term>
		/// </item>
		/// <item>
		/// <term>WSAEISCONN</term>
		/// <term>The socket is already connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAEMFILE</term>
		/// <term>No more file descriptors are available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available. The socket cannot be connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>Attempt to connect timed out without establishing a connection.</term>
		/// </item>
		/// </list>
		/// <para>Event: FD_CLOSE</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>The connection was reset by the remote side.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNABORTED</term>
		/// <term>The connection was terminated due to a time-out or other failure.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem failed.</term>
		/// </item>
		/// </list>
		/// <para>Event: FD_ROUTING_INTERFACE_CHANGE</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The specified destination is no longer reachable.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAAsyncSelect</c> function is used to request that WS2_32.DLL should send a message to the window hWnd when it detects
		/// any network event specified by the lEvent parameter. The message that should be sent is specified by the wMsg parameter. The
		/// socket for which notification is required is identified by the s parameter.
		/// </para>
		/// <para>
		/// The <c>WSAAsyncSelect</c> function automatically sets socket s to nonblocking mode, regardless of the value of lEvent. To set
		/// socket s back to blocking mode, it is first necessary to clear the event record associated with socket s via a call to
		/// <c>WSAAsyncSelect</c> with lEvent set to zero. You can then call ioctlsocket or WSAIoctl to set the socket back to blocking
		/// mode. For more information about how to set the nonblocking socket back to blocking mode, see the <c>ioctlsocket</c> and
		/// <c>WSAIoctl</c> functions.
		/// </para>
		/// <para>The lEvent parameter is constructed by using the bitwise OR operator with any value listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FD_READ</term>
		/// <term>Set to receive notification of readiness for reading.</term>
		/// </item>
		/// <item>
		/// <term>FD_WRITE</term>
		/// <term>Wants to receive notification of readiness for writing.</term>
		/// </item>
		/// <item>
		/// <term>FD_OOB</term>
		/// <term>Wants to receive notification of the arrival of OOB data.</term>
		/// </item>
		/// <item>
		/// <term>FD_ACCEPT</term>
		/// <term>Wants to receive notification of incoming connections.</term>
		/// </item>
		/// <item>
		/// <term>FD_CONNECT</term>
		/// <term>Wants to receive notification of completed connection or multipoint join operation.</term>
		/// </item>
		/// <item>
		/// <term>FD_CLOSE</term>
		/// <term>Wants to receive notification of socket closure.</term>
		/// </item>
		/// <item>
		/// <term>FD_QOS</term>
		/// <term>Wants to receive notification of socket Quality of Service (QoS) changes.</term>
		/// </item>
		/// <item>
		/// <term>FD_GROUP_QOS</term>
		/// <term>
		/// Wants to receive notification of socket group Quality of Service (QoS) changes (reserved for future use with socket groups). Reserved.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FD_ROUTING_INTERFACE_CHANGE</term>
		/// <term>Wants to receive notification of routing interface changes for the specified destination(s).</term>
		/// </item>
		/// <item>
		/// <term>FD_ADDRESS_LIST_CHANGE</term>
		/// <term>Wants to receive notification of local address list changes for the socket protocol family.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Issuing a <c>WSAAsyncSelect</c> for a socket cancels any previous <c>WSAAsyncSelect</c> or WSAEventSelect for the same socket.
		/// For example, to receive notification for both reading and writing, the application must call <c>WSAAsyncSelect</c> with both
		/// <c>FD_READ</c> and <c>FD_WRITE</c>, as follows:
		/// </para>
		/// <para>
		/// It is not possible to specify different messages for different events. The following code will not work; the second call will
		/// cancel the effects of the first, and only <c>FD_WRITE</c> events will be reported with message wMsg2:
		/// </para>
		/// <para>
		/// To cancel all notification indicating that Windows Sockets should send no further messages related to network events on the
		/// socket, lEvent is set to zero.
		/// </para>
		/// <para>
		/// Although <c>WSAAsyncSelect</c> immediately disables event message posting for the socket in this instance, it is possible that
		/// messages could be waiting in the application message queue. Therefore, the application must be prepared to receive network event
		/// messages even after cancellation. Closing a socket with closesocket also cancels <c>WSAAsyncSelect</c> message sending, but the
		/// same caveat about messages in the queue still applies.
		/// </para>
		/// <para>
		/// The socket created by the accept function has the same properties as the listening socket used to accept it. Consequently,
		/// <c>WSAAsyncSelect</c> events set for the listening socket also apply to the accepted socket. For example, if a listening socket
		/// has <c>WSAAsyncSelect</c> events <c>FD_ACCEPT</c>, <c>FD_READ</c>, and <c>FD_WRITE</c>, then any socket accepted on that
		/// listening socket will also have <c>FD_ACCEPT</c>, <c>FD_READ</c>, and <c>FD_WRITE</c> events with the same wMsg value used for
		/// messages. If a different wMsg or events are desired, the application should call <c>WSAAsyncSelect</c>, passing the accepted
		/// socket and the desired new data.
		/// </para>
		/// <para>
		/// When one of the nominated network events occurs on the specified socket s, the application window hWnd receives message wMsg.
		/// The wParam parameter identifies the socket on which a network event has occurred. The low word of lParam specifies the network
		/// event that has occurred. The high word of lParam contains any error code. The error code be any error as defined in Winsock2.h.
		/// </para>
		/// <para>
		/// <c>Note</c> Upon receipt of an event notification message, the WSAGetLastError function cannot be used to check the error value
		/// because the error value returned can differ from the value in the high word of lParam.
		/// </para>
		/// <para>
		/// The error and event codes can be extracted from the lParam using the macros <c>WSAGETSELECTERROR</c> and
		/// <c>WSAGETSELECTEVENT</c>, defined in Winsock2.h as:
		/// </para>
		/// <para>The use of these macros will maximize the portability of the source code for the application.</para>
		/// <para>The possible network event codes that can be returned are listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FD_READ</term>
		/// <term>Socket s ready for reading.</term>
		/// </item>
		/// <item>
		/// <term>FD_WRITE</term>
		/// <term>Socket s ready for writing.</term>
		/// </item>
		/// <item>
		/// <term>FD_OOB</term>
		/// <term>OOB data ready for reading on socket s</term>
		/// </item>
		/// <item>
		/// <term>FD_ACCEPT</term>
		/// <term>Socket s ready for accepting a new incoming connection.</term>
		/// </item>
		/// <item>
		/// <term>FD_CONNECT</term>
		/// <term>Connection or multipoint join operation initiated on socket s completed.</term>
		/// </item>
		/// <item>
		/// <term>FD_CLOSE</term>
		/// <term>Connection identified by socket s has been closed.</term>
		/// </item>
		/// <item>
		/// <term>FD_QOS</term>
		/// <term>Quality of Service associated with socket s has changed.</term>
		/// </item>
		/// <item>
		/// <term>FD_GROUP_QOS</term>
		/// <term>
		/// Reserved. Quality of Service associated with the socket group to which s belongs has changed (reserved for future use with
		/// socket groups).
		/// </term>
		/// </item>
		/// <item>
		/// <term>FD_ROUTING_INTERFACE_CHANGE</term>
		/// <term>Local interface that should be used to send to the specified destination has changed.</term>
		/// </item>
		/// <item>
		/// <term>FD_ADDRESS_LIST_CHANGE</term>
		/// <term>The list of addresses of the socket protocol family to which the application client can bind has changed.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Although <c>WSAAsyncSelect</c> can be called with interest in multiple events, the application window will receive a single
		/// message for each network event.
		/// </para>
		/// <para>
		/// As in the case of the select function, <c>WSAAsyncSelect</c> will frequently be used to determine when a data transfer operation
		/// (send or recv) can be issued with the expectation of immediate success. Nevertheless, a robust application must be prepared for
		/// the possibility that it can receive a message and issue a Windows Sockets 2 call that returns WSAEWOULDBLOCK immediately. For
		/// example, the following sequence of events is possible:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Data arrives on socket s; Windows Sockets 2 posts <c>WSAAsyncSelect</c> message</term>
		/// </item>
		/// <item>
		/// <term>Application processes some other message</term>
		/// </item>
		/// <item>
		/// <term>While processing, application issues an and notices that there is data ready to be read</term>
		/// </item>
		/// <item>
		/// <term>Application issues a to read the data</term>
		/// </item>
		/// <item>
		/// <term>
		/// Application loops to process next message, eventually reaching the <c>WSAAsyncSelect</c> message indicating that data is ready
		/// to read
		/// </term>
		/// </item>
		/// <item>
		/// <term>Application issues , which fails with the error WSAEWOULDBLOCK.</term>
		/// </item>
		/// </list>
		/// <para>Other sequences are also possible.</para>
		/// <para>
		/// The WS2_32.DLL will not continually flood an application with messages for a particular network event. Having successfully
		/// posted notification of a particular event to an application window, no further message(s) for that network event will be posted
		/// to the application window until the application makes the function call that implicitly reenables notification of that network event.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Event</term>
		/// <term>Reenabling function</term>
		/// </listheader>
		/// <item>
		/// <term>FD_READ</term>
		/// <term>recv, recvfrom, WSARecv, or WSARecvFrom.</term>
		/// </item>
		/// <item>
		/// <term>FD_WRITE</term>
		/// <term>send, sendto, WSASend, or WSASendTo.</term>
		/// </item>
		/// <item>
		/// <term>FD_OOB</term>
		/// <term>recv, recvfrom, WSARecv, or WSARecvFrom.</term>
		/// </item>
		/// <item>
		/// <term>FD_ACCEPT</term>
		/// <term>accept or WSAAccept unless the error code is WSATRY_AGAIN indicating that the condition function returned CF_DEFER.</term>
		/// </item>
		/// <item>
		/// <term>FD_CONNECT</term>
		/// <term>None.</term>
		/// </item>
		/// <item>
		/// <term>FD_CLOSE</term>
		/// <term>None.</term>
		/// </item>
		/// <item>
		/// <term>FD_QOS</term>
		/// <term>WSAIoctl with command SIO_GET_QOS.</term>
		/// </item>
		/// <item>
		/// <term>FD_GROUP_QOS</term>
		/// <term>Reserved. WSAIoctl with command SIO_GET_GROUP_QOS (reserved for future use with socket groups).</term>
		/// </item>
		/// <item>
		/// <term>FD_ROUTING_INTERFACE_CHANGE</term>
		/// <term>WSAIoctl with command SIO_ROUTING_INTERFACE_CHANGE.</term>
		/// </item>
		/// <item>
		/// <term>FD_ADDRESS_LIST_CHANGE</term>
		/// <term>WSAIoctl with command SIO_ADDRESS_LIST_CHANGE.</term>
		/// </item>
		/// </list>
		/// <para>Any call to the reenabling routine, even one that fails, results in reenabling of message posting for the relevant event.</para>
		/// <para>
		/// For <c>FD_READ</c>, <c>FD_OOB</c>, and <c>FD_ACCEPT</c> events, message posting is level-triggered. This means that if the
		/// reenabling routine is called and the relevant condition is still met after the call, a <c>WSAAsyncSelect</c> message is posted
		/// to the application. This allows an application to be event-driven and not be concerned with the amount of data that arrives at
		/// any one time. Consider the following sequence:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// Network transport stack receives 100 bytes of data on socket s and causes Windows Sockets 2 to post an <c>FD_READ</c> message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The application issues recv( s, buffptr, 50, 0) to read 50 bytes.</term>
		/// </item>
		/// <item>
		/// <term>Another <c>FD_READ</c> message is posted because there is still data to be read.</term>
		/// </item>
		/// </list>
		/// <para>
		/// With these semantics, an application need not read all available data in response to an <c>FD_READ</c> message—a single recv in
		/// response to each <c>FD_READ</c> message is appropriate. If an application issues multiple <c>recv</c> calls in response to a
		/// single <c>FD_READ</c>, it can receive multiple <c>FD_READ</c> messages. Such an application can require disabling <c>FD_READ</c>
		/// messages before starting the <c>recv</c> calls by calling <c>WSAAsyncSelect</c> with the <c>FD_READ</c> event not set.
		/// </para>
		/// <para>
		/// The <c>FD_QOS</c> and <c>FD_GROUP_QOS</c> events are considered edge triggered. A message will be posted exactly once when a
		/// quality of service change occurs. Further messages will not be forthcoming until either the provider detects a further change in
		/// quality of service or the application renegotiates the quality of service for the socket.
		/// </para>
		/// <para>
		/// The <c>FD_ROUTING_INTERFACE_CHANGE</c> message is posted when the local interface that should be used to reach the destination
		/// specified in WSAIoctl with SIO_ROUTING_INTERFACE_CHANGE changes after such IOCTL has been issued.
		/// </para>
		/// <para>
		/// The <c>FD_ADDRESS_LIST_CHANGE</c> message is posted when the list of addresses to which the application can bind changes after
		/// WSAIoctl with SIO_ADDRESS_LIST_CHANGE has been issued.
		/// </para>
		/// <para>
		/// If any event has occurred when the application calls <c>WSAAsyncSelect</c> or when the reenabling function is called, then a
		/// message is posted as appropriate. For example, consider the following sequence:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>An application calls listen.</term>
		/// </item>
		/// <item>
		/// <term>A connect request is received, but not yet accepted.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The application calls <c>WSAAsyncSelect</c> specifying that it requires receiving <c>FD_ACCEPT</c> messages for the socket. Due
		/// to the persistence of events, Windows Sockets 2 posts an <c>FD_ACCEPT</c> message immediately.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>FD_WRITE</c> event is handled slightly differently. An <c>FD_WRITE</c> message is posted when a socket is first connected
		/// with connect or WSAConnect (after FD_CONNECT, if also registered) or accepted with accept or WSAAccept, and then after a send
		/// operation fails with WSAEWOULDBLOCK and buffer space becomes available. Therefore, an application can assume that sends are
		/// possible starting from the first <c>FD_WRITE</c> message and lasting until a send returns WSAEWOULDBLOCK. After such a failure
		/// the application will be notified that sends are again possible with an <c>FD_WRITE</c> message.
		/// </para>
		/// <para>
		/// The <c>FD_OOB</c> event is used only when a socket is configured to receive OOB data separately. If the socket is configured to
		/// receive OOB data inline, the OOB (expedited) data is treated as normal data and the application should register an interest in,
		/// and will receive, <c>FD_READ</c> events, not <c>FD_OOB</c> events. An application can set or inspect the way in which OOB data
		/// is to be handled by using setsockopt or getsockopt for the SO_OOBINLINE option.
		/// </para>
		/// <para>
		/// The error code in an <c>FD_CLOSE</c> message indicates whether the socket close was graceful or abortive. If the error code is
		/// zero, then the close was graceful; if the error code is WSAECONNRESET, then the socket's virtual circuit was reset. This only
		/// applies to connection-oriented sockets such as SOCK_STREAM.
		/// </para>
		/// <para>
		/// The <c>FD_CLOSE</c> message is posted when a close indication is received for the virtual circuit corresponding to the socket.
		/// In TCP terms, this means that the <c>FD_CLOSE</c> is posted when the connection goes into the TIME WAIT or CLOSE WAIT states.
		/// This results from the remote end performing a shutdown on the send side or a closesocket. <c>FD_CLOSE</c> should only be posted
		/// after all data is read from a socket, but an application should check for remaining data upon receipt of <c>FD_CLOSE</c> to
		/// avoid any possibility of losing data.
		/// </para>
		/// <para>
		/// Be aware that the application will only receive an <c>FD_CLOSE</c> message to indicate closure of a virtual circuit, and only
		/// when all the received data has been read if this is a graceful close. It will not receive an <c>FD_READ</c> message to indicate
		/// this condition.
		/// </para>
		/// <para>
		/// The <c>FD_QOS</c> or <c>FD_GROUP_QOS</c> message is posted when any parameter in the flow specification associated with socket s
		/// or the socket group that s belongs to has changed, respectively. Applications should use WSAIoctl with command SIO_GET_QOS or
		/// SIO_GET_GROUP_QOS to get the current quality of service for socket s or for the socket group s belongs to, respectively.
		/// </para>
		/// <para>
		/// The <c>FD_ROUTING_INTERFACE_CHANGE</c> and <c>FD_ADDRESS_LIST_CHANGE</c> events are considered edge triggered as well. A message
		/// will be posted exactly once when a change occurs after the application has requested the notification by issuing WSAIoctl with
		/// SIO_ROUTING_INTERFACE_CHANGE or SIO_ADDRESS_LIST_CHANGE correspondingly. Further messages will not be forthcoming until the
		/// application reissues the IOCTL and another change is detected because the IOCTL has been issued.
		/// </para>
		/// <para>Here is a summary of events and conditions for each asynchronous notification message.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>FD_READ</c>:</term>
		/// </item>
		/// <item>
		/// <term><c>FD_WRITE</c>:</term>
		/// </item>
		/// <item>
		/// <term><c>FD_OOB</c>: Only valid when setsockopt SO_OOBINLINE is disabled (default).</term>
		/// </item>
		/// <item>
		/// <term><c>FD_ACCEPT</c>:</term>
		/// </item>
		/// <item>
		/// <term><c>FD_CONNECT</c>:</term>
		/// </item>
		/// <item>
		/// <term><c>FD_CLOSE</c>: Only valid on connection-oriented sockets (for example, SOCK_STREAM)</term>
		/// </item>
		/// <item>
		/// <term><c>FD_QOS</c>:</term>
		/// </item>
		/// <item>
		/// <term><c>FD_GROUP_QOS</c>: Reserved.</term>
		/// </item>
		/// <item>
		/// <term><c>FD_ROUTING_INTERFACE_CHANGE</c>:</term>
		/// </item>
		/// <item>
		/// <term><c>FD_ADDRESS_LIST_CHANGE</c>:</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsaasyncselect int WSAAsyncSelect( SOCKET s, HWND hWnd,
		// u_int wMsg, long lEvent );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "a4d3f599-358c-4a94-91eb-7e1c80244250")]
		public static extern int WSAAsyncSelect(SOCKET s, HWND hWnd, uint wMsg, int lEvent);

		/// <summary>The <c>WSACancelAsyncRequest</c> function cancels an incomplete asynchronous operation.</summary>
		/// <param name="hAsyncTaskHandle">Handle that specifies the asynchronous operation to be canceled.</param>
		/// <returns>
		/// <para>
		/// The value returned by <c>WSACancelAsyncRequest</c> is zero if the operation was successfully canceled. Otherwise, the value
		/// SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEINVAL</term>
		/// <term>Indicates that the specified asynchronous task handle was invalid.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEALREADY</term>
		/// <term>The asynchronous routine being canceled has already completed.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> It is unclear whether the application can usefully distinguish between WSAEINVAL and WSAEALREADY, since in both
		/// cases the error indicates that there is no asynchronous operation in progress with the indicated handle. (Trivial exception:
		/// zero is always an invalid asynchronous task handle.) The Windows Sockets specification does not prescribe how a conformant
		/// Windows Sockets provider should distinguish between the two cases. For maximum portability, a Windows Sockets application should
		/// treat the two errors as equivalent.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSACancelAsyncRequest</c> function is used to cancel an asynchronous operation that was initiated by one of the
		/// <c>WSAAsyncGetXByY</c> functions such as WSAAsyncGetHostByName. The operation to be canceled is identified by the
		/// hAsyncTaskHandle parameter, which should be set to the asynchronous task handle as returned by the initiating
		/// <c>WSAAsyncGetXByY</c> function.
		/// </para>
		/// <para>
		/// An attempt to cancel an existing asynchronous <c>WSAAsyncGetXByY</c> operation can fail with an error code of WSAEALREADY for
		/// two reasons. First, the original operation has already completed and the application has dealt with the resultant message.
		/// Second, the original operation has already completed but the resultant message is still waiting in the application window queue.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsacancelasyncrequest int WSACancelAsyncRequest( HANDLE
		// hAsyncTaskHandle );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "0e53eccf-ef85-43ec-a02c-12896471a7a9")]
		public static extern int WSACancelAsyncRequest(HANDLE hAsyncTaskHandle);

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
		/// An application or DLL is required to perform a successful WSAStartup call before it can use Windows Sockets services. When it
		/// has completed the use of Windows Sockets, the application or DLL must call <c>WSACleanup</c> to deregister itself from a Windows
		/// Sockets implementation and allow the implementation to free any resources allocated on behalf of the application or DLL.
		/// </para>
		/// <para>
		/// When <c>WSACleanup</c> is called, any pending blocking or asynchronous Windows Sockets calls issued by any thread in this
		/// process are canceled without posting any notification messages or without signaling any event objects. Any pending overlapped
		/// send or receive operations (WSASend, WSASendTo, WSARecv, or WSARecvFrom with an overlapped socket, for example) issued by any
		/// thread in this process are also canceled without setting the event object or invoking the completion routine, if one was
		/// specified. In this case, the pending overlapped operations fail with the error status <c>WSA_OPERATION_ABORTED</c>.
		/// </para>
		/// <para>
		/// Sockets that were open when <c>WSACleanup</c> was called are reset and automatically deallocated as if closesocket were called.
		/// Sockets that have been closed with <c>closesocket</c> but that still have pending data to be sent can be affected when
		/// <c>WSACleanup</c> is called. In this case, the pending data can be lost if the WS2_32.DLL is unloaded from memory as the
		/// application exits. To ensure that all pending data is sent, an application should use shutdown to close the connection, then
		/// wait until the close completes before calling <c>closesocket</c> and <c>WSACleanup</c>. All resources and internal state, such
		/// as queued unposted or posted messages, must be deallocated so as to be available to the next user.
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

		/// <summary>The <c>WSACloseEvent</c> function closes an open event object handle.</summary>
		/// <param name="hEvent">Object handle identifying the open event.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To get extended error information, call WSAGetLastError.</para>
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
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The hEvent is not a valid event object handle.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSACloseEvent</c> function closes the handle to an event object and frees resources associated with the event object.
		/// This function is used to close a handle created by the WSACreateEventfunction. Once the handle to the event object is closed,
		/// further references to this handle will fail with the error WSA_INVALID_HANDLE.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsacloseevent BOOL WSAAPI WSACloseEvent( WSAEVENT hEvent );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "40cefe46-10a3-4b6a-8c89-3e16237fc685")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSACloseEvent(WSAEVENT hEvent);

		/// <summary>
		/// The <c>WSAConnect</c> function establishes a connection to another socket application, exchanges connect data, and specifies
		/// required quality of service based on the specified FLOWSPEC structure.
		/// </summary>
		/// <param name="s">A descriptor identifying an unconnected socket.</param>
		/// <param name="name">
		/// A pointer to a sockaddr structure that specifies the address to which to connect. For IPv4, the <c>sockaddr</c> contains
		/// <c>AF_INET</c> for the address family, the destination IPv4 address, and the destination port. For IPv6, the <c>sockaddr</c>
		/// structure contains <c>AF_INET6</c> for the address family, the destination IPv6 address, the destination port, and may contain
		/// additional flow and scope-id information.
		/// </param>
		/// <param name="namelen">The length, in bytes, of the sockaddr structure pointed to by the name parameter.</param>
		/// <param name="lpCallerData">
		/// A pointer to the user data that is to be transferred to the other socket during connection establishment. See Remarks.
		/// </param>
		/// <param name="lpCalleeData">
		/// A pointer to the user data that is to be transferred back from the other socket during connection establishment. See Remarks.
		/// </param>
		/// <param name="lpSQOS">A pointer to the FLOWSPEC structures for socket s, one for each direction.</param>
		/// <param name="lpGQOS">
		/// Reserved for future use with socket groups. A pointer to the FLOWSPEC structures for the socket group (if applicable). This
		/// parameter should be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAConnect</c> returns zero. Otherwise, it returns SOCKET_ERROR, and a specific error code can be
		/// retrieved by calling WSAGetLastError. On a blocking socket, the return value indicates success or failure of the connection attempt.
		/// </para>
		/// <para>
		/// With a nonblocking socket, the connection attempt cannot be completed immediately. In this case, <c>WSAConnect</c> will return
		/// SOCKET_ERROR, and WSAGetLastError will return WSAEWOULDBLOCK; the application could therefore:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Use select to determine the completion of the connection request by checking if the socket is writeable.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If your application is using WSAAsyncSelect to indicate interest in connection events, then your application will receive an
		/// FD_CONNECT notification when the connect operation is complete(successful or not).
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If your application is using WSAEventSelect to indicate interest in connection events, then the associated event object will be
		/// signaled when the connect operation is complete (successful or not).
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For a nonblocking socket, until the connection attempt completes all subsequent calls to <c>WSAConnect</c> on the same socket
		/// will fail with the error code WSAEALREADY.
		/// </para>
		/// <para>
		/// If the return error code indicates the connection attempt failed (that is, WSAECONNREFUSED, WSAENETUNREACH, WSAETIMEDOUT) the
		/// application can call <c>WSAConnect</c> again for the same socket.
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
		/// The local address of the socket is already in use and the socket was not marked to allow address reuse with SO_REUSEADDR. This
		/// error usually occurs during the execution of bind, but could be delayed until this function if the bind function operates on a
		/// partially wildcard address (involving ADDR_ANY) and if a specific address needs to be "committed" at the time of this function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>The (blocking) Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEALREADY</term>
		/// <term>A nonblocking connect or WSAConnect call is in progress on the specified socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEADDRNOTAVAIL</term>
		/// <term>The remote address is not a valid address (such as ADDR_ANY).</term>
		/// </item>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>Addresses in the specified family cannot be used with this socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNREFUSED</term>
		/// <term>The attempt to connect was rejected.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The name or the namelen parameter is not a valid part of the user address space, the namelen parameter is too small, the buffer
		/// length for lpCalleeData, lpSQOS, and lpGQOS are too small, or the buffer length for lpCallerData is too large.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// The parameter s is a listening socket, or the destination address specified is not consistent with that of the constrained group
		/// to which the socket belongs, or the lpGQOS parameter is not NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEISCONN</term>
		/// <term>The socket is already connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The network cannot be reached from this host at this time.</term>
		/// </item>
		/// <item>
		/// <term>WSAEHOSTUNREACH</term>
		/// <term>A socket operation was attempted to an unreachable host.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available. The socket cannot be connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>The FLOWSPEC structures specified in lpSQOS and lpGQOS cannot be satisfied.</term>
		/// </item>
		/// <item>
		/// <term>WSAEPROTONOSUPPORT</term>
		/// <term>The lpCallerData parameter is not supported by the service provider.</term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>Attempt to connect timed out without establishing a connection.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>The socket is marked as nonblocking and the connection cannot be completed immediately.</term>
		/// </item>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>Attempt to connect datagram socket to broadcast address failed because setsockopt SO_BROADCAST is not enabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAConnect</c> function is used to create a connection to the specified destination, and to perform a number of other
		/// ancillary operations that occur at connect time. If the socket, s, is unbound, unique values are assigned to the local
		/// association by the system, and the socket is marked as bound.
		/// </para>
		/// <para>
		/// For applications targeted to Windows Vista and later, consider using the WSAConnectByList or WSAConnectByName function which
		/// greatly simplify client application design.
		/// </para>
		/// <para>
		/// For connection-oriented sockets (for example, type SOCK_STREAM), an active connection is initiated to the foreign host using
		/// name (an address in the namespace of the socket; for a detailed description, please see bind). When this call completes
		/// successfully, the socket is ready to send/receive data. If the address parameter of the name structure is all zeroes,
		/// <c>WSAConnect</c> will return the error WSAEADDRNOTAVAIL. Any attempt to reconnect an active connection will fail with the error
		/// code WSAEISCONN.
		/// </para>
		/// <para>
		/// <c>Note</c> If a socket is opened, a setsockopt call is made, and then a sendto call is made, Windows Sockets performs an
		/// implicit bind function call.
		/// </para>
		/// <para>
		/// For connection-oriented, nonblocking sockets, it is often not possible to complete the connection immediately. In such cases,
		/// this function returns the error WSAEWOULDBLOCK. However, the operation proceeds. When the success or failure outcome becomes
		/// known, it may be reported in one of several ways depending on how the client registers for notification. If the client uses
		/// select, success is reported in the writefds set and failure is reported in the exceptfds set. If the client uses WSAAsyncSelect
		/// or WSAEventSelect, the notification is announced with FD_CONNECT and the error code associated with the FD_CONNECT indicates
		/// either success or a specific reason for failure.
		/// </para>
		/// <para>
		/// For a connectionless socket (for example, type SOCK_DGRAM), the operation performed by <c>WSAConnect</c> is merely to establish
		/// a default destination address so that the socket can be used on subsequent connection-oriented send and receive operations
		/// (send, WSASend, recv, and WSARecv). Any datagrams received from an address other than the destination address specified will be
		/// discarded. If the entire name structure is all zeros (not just the address parameter of the name structure), then the socket
		/// will be disconnected. Then, the default remote address will be indeterminate, so <c>send</c>, <c>WSASend</c>, <c>recv</c>, and
		/// <c>WSARecv</c> calls will return the error code WSAENOTCONN. However, sendto, WSASendTo, recvfrom, and WSARecvFrom can still be
		/// used. The default destination can be changed by simply calling <c>WSAConnect</c> again, even if the socket is already connected.
		/// Any datagrams queued for receipt are discarded if name is different from the previous <c>WSAConnect</c>.
		/// </para>
		/// <para>
		/// For connectionless sockets, name can indicate any valid address, including a broadcast address. However, to connect to a
		/// broadcast address, a socket must have setsockopt SO_BROADCAST enabled. Otherwise, <c>WSAConnect</c> will fail with the error
		/// code WSAEACCES.
		/// </para>
		/// <para>
		/// On connectionless sockets, exchange of user-to-user data is not possible and the corresponding parameters will be silently ignored.
		/// </para>
		/// <para>
		/// The application is responsible for allocating any memory space pointed to directly or indirectly by any of the parameters it specifies.
		/// </para>
		/// <para>
		/// The lpCallerData parameter contains a pointer to any user data that is to be sent along with the connection request (called
		/// connect data). This is additional data, not in the normal network data stream, that is sent with network requests to establish a
		/// connection. This option is used by legacy protocols such as DECNet, OSI TP4, and others.
		/// </para>
		/// <para>
		/// If lpCallerData is <c>NULL</c>, no user data will be passed to the peer. The lpCalleeData is a result parameter that will
		/// contain any user data passed back from the other socket as part of the connection establishment in a WSABUF structure. The
		/// <c>len</c> member of the <c>WSABUF</c> structure pointed to by the lpCalleeData parameter initially contains the length of the
		/// buffer allocated by the application for the <c>buf</c> member of the <c>WSABUF</c> structure. The <c>len</c> member of the
		/// <c>WSABUF</c> structure pointed to by the lpCalleeData parameter will be set to zero if no user data has been passed back. The
		/// lpCalleeData information will be valid when the connection operation is complete. For blocking sockets, the connection operation
		/// completes when the <c>WSAConnect</c> function returns. For nonblocking sockets, completion will be after the FD_CONNECT
		/// notification has occurred. If lpCalleeData is <c>NULL</c>, no user data will be passed back. The exact format of the user data
		/// is specific to the address family to which the socket belongs.
		/// </para>
		/// <para>
		/// At connect time, an application can use the lpSQOS and lpGQOS parameter to override any previous quality of service
		/// specification made for the socket through WSAIoctl with either the SIO_SET_QOS or SIO_SET_GROUP_QOS opcode.
		/// </para>
		/// <para>
		/// The lpSQOS parameter specifies the FLOWSPEC structures for socket s, one for each direction, followed by any additional
		/// provider-specific parameters. If either the associated transport provider in general or the specific type of socket in
		/// particular cannot honor the quality of service request, an error will be returned as indicated in the following. The sending or
		/// receiving flow specification values will be ignored, respectively, for any unidirectional sockets. If no provider-specific
		/// parameters are specified, the <c>buf</c> and <c>len</c> members of the WSABUF structure pointed to by the lpCalleeData parameter
		/// should be set to <c>NULL</c> and zero, respectively. A <c>NULL</c> value for lpSQOS parameter indicates no application-supplied
		/// quality of service.
		/// </para>
		/// <para>
		/// Reserved for future use with socket groups lpGQOS specifies the FLOWSPEC structures for the socket group (if applicable), one
		/// for each direction, followed by any additional provider-specific parameters. If no provider-specific parameters are specified,
		/// the <c>buf</c> and <c>len</c> members of the WSABUF structure pointed to by the lpCalleeData parameter should be set to
		/// <c>NULL</c> and zero, respectively. A <c>NULL</c> value for lpGQOS indicates no application-supplied group quality of service.
		/// This parameter will be ignored if s is not the creator of the socket group.
		/// </para>
		/// <para>
		/// When connected sockets become closed for whatever reason, they should be discarded and recreated. It is safest to assume that
		/// when things go awry for any reason on a connected socket, the application must discard and recreate the needed sockets in order
		/// to return to a stable point.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSAConnect</c>, Winsock may need to wait for a network event before
		/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaconnect int WSAAPI WSAConnect( SOCKET s, const
		// sockaddr *name, int namelen, LPWSABUF lpCallerData, LPWSABUF lpCalleeData, LPQOS lpSQOS, LPQOS lpGQOS );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "3b32cc6e-3df7-4104-a0d4-317fd445c7b2")]
		public static extern int WSAConnect(SOCKET s, [In] SOCKADDR name, int namelen, [In, Optional] IntPtr lpCallerData,
			[Out, Optional] IntPtr lpCalleeData, [Optional] IntPtr lpSQOS, [Optional] IntPtr lpGQOS);

		/// <summary>
		/// <para>
		/// The <c>WSAConnectByList</c> function establishes a connection to one out of a collection of possible endpoints represented by a
		/// set of destination addresses (host names and ports). This function takes all the destination addresses passed to it and all of
		/// the local computer's source addresses, and tries connecting using all possible address combinations before giving up.
		/// </para>
		/// <para>This function supports both IPv4 and IPv6 addresses.</para>
		/// </summary>
		/// <param name="s">
		/// A descriptor that identifies an unbound and unconnected socket. Note that unlike other Winsock calls to establish a connection
		/// (for example, WSAConnect), the <c>WSAConnectByList</c> function requires an unbound socket.
		/// </param>
		/// <param name="SocketAddress">
		/// A pointer to a SOCKET_ADDRESS_LIST structure that represents the possible destination address and port pairs to connect to a
		/// peer. It is the application's responsibility to fill in the port number in the each SOCKET_ADDRESS structure in the <c>SOCKET_ADDRESS_LIST</c>.
		/// </param>
		/// <param name="LocalAddressLength">
		/// On input, a pointer to the size, in bytes, of the LocalAddress buffer provided by the caller. On output, a pointer to the size,
		/// in bytes, of the <c>SOCKADDR</c> for the local address stored in the LocalAddress buffer filled in by the system upon successful
		/// completion of the call.
		/// </param>
		/// <param name="LocalAddress">
		/// A pointer to the <c>SOCKADDR</c> structure that receives the local address of the connection. The size of the parameter is
		/// exactly the size returned in LocalAddressLength. This is the same information that would be returned by the getsockname
		/// function. This parameter can be <c>NULL</c>, in which case, the LocalAddressLength parameter is ignored.
		/// </param>
		/// <param name="RemoteAddressLength">
		/// On input, a pointer to the size, in bytes, of the RemoteAddress buffer provided by the caller. On output, a pointer to the size,
		/// in bytes, of the <c>SOCKADDR</c> for the remote address stored in RemoteAddress buffer filled-in by the system upon successful
		/// completion of the call.
		/// </param>
		/// <param name="RemoteAddress">
		/// A pointer to the <c>SOCKADDR</c> structure that receives the remote address of the connection. This is the same information that
		/// would be returned by the <c>getpeername</c> function. This parameter can be <c>NULL</c>, in which case, the RemoteAddressLength
		/// is ignored.
		/// </param>
		/// <param name="timeout">
		/// The time, in milliseconds, to wait for a response from the remote application before aborting the call. This parameter can be
		/// <c>NULL</c> in which case <c>WSAConnectByList</c> will complete after either the connection is successfully established or after
		/// a connection was attempted and failed on all possible local-remote address pairs.
		/// </param>
		/// <param name="Reserved">Reserved for future implementation. This parameter must be set to <c>NULL</c>.</param>
		/// <returns>
		/// <para>
		/// If a connection is established, <c>WSAConnectByList</c> returns <c>TRUE</c> and LocalAddress and RemoteAddress parameters are
		/// filled in if these buffers were supplied by the caller.
		/// </para>
		/// <para>If the call fails, <c>FALSE</c> is returned. WSAGetLastError can then be called to get extended error information.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEHOSTUNREACH</term>
		/// <term>The host passed as the nodename parameter was unreachable.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>An invalid parameter was passed to the function. The Reserved parameter must be NULL.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Sufficient memory could not be allocated.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>An invalid socket was passed to the function. The s parameter must not be INVALID_SOCKET or NULL.</term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>A response from the remote application was not received before the timeout parameter was exceeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>WSAConnectByList</c> is similar to the WSAConnectByName function. Instead of taking a single host name and service name
		/// (port), <c>WSAConnectByList</c> takes a list of addresses (host addresses and ports) and connects to one of the addresses. The
		/// <c>WSAConnectByList</c> function is designed to support peer-to-peer collaboration scenarios where an application needs to
		/// connect to any available node out of a list of potential nodes. <c>WSAConnectByList</c> is compatible with both IPv6 and IPv4 versions.
		/// </para>
		/// <para>
		/// The set of possible destinations, represented by a list of addresses, is provided by the caller. <c>WSAConnectByList</c> does
		/// more than simply attempt to connect to one of possibly many destination addresses. Specifically, the function takes all remote
		/// addresses passed in by the caller, all local addresses, and then attempts a connection first using address pairs with the
		/// highest chance of success. As such, <c>WSAConnectByList</c> not only ensures that connection will be established if a connection
		/// is at all possible, but also minimizes the time to establish the connection.
		/// </para>
		/// <para>
		/// The caller can specify the LocalAddress and RemoteAddress buffers and lengths to determine the local and remote addresses for
		/// which the connection was successfully established.
		/// </para>
		/// <para>
		/// The timeout parameter allows the caller to limit the time spent by the function in establishing a connection. Internally,
		/// <c>WSAConnectByList</c> performs multiple operations (connection attempts). In between each operation, the timeout parameter is
		/// checked to see if the timeout has been exceeded and, if so, the call is aborted. Note that an individual operation (connect)
		/// will not be interrupted once the timeout is exceeded, so the <c>WSAConnectByList</c> call can take longer to time out than the
		/// value specified in the timeout parameter.
		/// </para>
		/// <para>
		/// <c>WSAConnectByList</c> has limitations: It works only for connection-oriented sockets, such as those of type SOCK_STREAM. The
		/// function does not support overlapped I/O or non-blocking behavior. <c>WSAConnectByList</c> will block even if the socket is in
		/// non-blocking mode. <c>WSAConnectByList</c> will try connecting (one-by-one) to the various addresses provided by the caller.
		/// Potentially, each of these connection attempts may fail with a different error code. Since only a single error code can be
		/// returned, the value returned is the error code from the last connection attempt.
		/// </para>
		/// <para>
		/// To enable both IPv6 and IPv4 addresses to be passed in the single address list accepted by the function, the following steps
		/// must be performed prior to calling the function:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The setsockopt function must be called on a socket created for the AF_INET6 address family to disable the <c>IPV6_V6ONLY</c>
		/// socket option before calling <c>WSAConnectByList</c>. This is accomplished by calling the <c>setsockopt</c> function on the
		/// socket with the level parameter set to <c>IPPROTO_IPV6</c> (see IPPROTO_IPV6 Socket Options), the optname parameter set to
		/// <c>IPV6_V6ONLY</c>, and the optvalue parameter value set to zero .
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Any IPv4 addresses must be represented in the IPv4-mapped IPv6 address format which enables an IPv6 only application to
		/// communicate with an IPv4 node. The IPv4-mapped IPv6 address format allows the IPv4 address of an IPv4 node to be represented as
		/// an IPv6 address. The IPv4 address is encoded into the low-order 32 bits of the IPv6 address, and the high-order 96 bits hold the
		/// fixed prefix 0:0:0:0:0:FFFF. The IPv4-mapped IPv6 address format is specified in RFC 4291. For more information, see
		/// www.ietf.org/rfc/rfc4291.txt. The IN6ADDR_SETV4MAPPED macro in Mstcpip.h can be used to convert an IPv4 address to the required
		/// IPv4-mapped IPv6 address format.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The arrays of pointers passed in the SocketAddressList parameter point to an array of SOCKET_ADDRESS structures, which are a
		/// generic data type. The RemoteAddress and the LocalAddress parameters also point to <c>SOCKADDR</c> structures. When
		/// <c>WSAConnectByList</c> is called, it is expected that a socket address type specific to the network protocol or address family
		/// being used will actually be passed in these parameters. So for IPv4 addresses, a pointer to a <c>sockaddr_in</c> structure would
		/// be cast to a pointer to <c>SOCKADDR</c> when passed as a parameter. For IPv6 addresses, a pointer to a <c>sockaddr_in6</c>
		/// structure would be cast to a pointer to <c>SOCKADDR</c> when passed as a parameter. The SocketAddressList parameter can contain
		/// pointers to a mixture of IPv4 and IPv6 addresses. So some <c>SOCKET_ADDRESS</c> pointers can be to <c>sockaddr_in</c> structures
		/// and others can be to <c>sockaddr_in6</c> structures. If it is expected that IPv6 addresses can be used, then the RemoteAddress
		/// and LocalAddress parameters should point to <c>sockaddr_in6</c> structures and be cast to <c>SOCKADDR</c> structures. The
		/// RemoteAddressLength and the LocalAddressLength parameters must represent the length of these larger structures.
		/// </para>
		/// <para>
		/// When the WSAConnectByList function returns <c>TRUE</c>, the socket s is in the default state for a connected socket. The socket
		/// s does not enable previously set properties or options until SO_UPDATE_CONNECT_CONTEXT is set on the socket. Use the setsockopt
		/// function to set the SO_UPDATE_CONNECT_CONTEXT option.
		/// </para>
		/// <para>For example:</para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as WSAConnectByList with the timeout parameter set to <c>NULL</c>, Winsock
		/// may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which
		/// can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call
		/// inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must
		/// never be attempted by Winsock clients.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// <para>Examples</para>
		/// <para>Establish a connection using <c>WSAConnectByList</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaconnectbylist BOOL WSAConnectByList( SOCKET s,
		// PSOCKET_ADDRESS_LIST SocketAddress, LPDWORD LocalAddressLength, LPSOCKADDR LocalAddress, LPDWORD RemoteAddressLength, LPSOCKADDR
		// RemoteAddress, const timeval *timeout, LPWSAOVERLAPPED Reserved );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "7323d814-e96e-44b9-8ade-a9317e4fbf17")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSAConnectByList(SOCKET s, in SOCKET_ADDRESS_LIST SocketAddress, ref uint LocalAddressLength, [Out] SOCKADDR LocalAddress,
			ref uint RemoteAddressLength, [Out] SOCKADDR RemoteAddress, [In, Optional] IntPtr timeout, IntPtr Reserved = default);

		/// <summary>
		/// <para>
		/// The <c>WSAConnectByName</c> function establishes a connection to a specified host and port. This function is provided to allow a
		/// quick connection to a network endpoint given a host name and port.
		/// </para>
		/// <para>This function supports both IPv4 and IPv6 addresses.</para>
		/// </summary>
		/// <param name="s">
		/// <para>A descriptor that identifies an unconnected socket.</para>
		/// <para>
		/// <c>Note</c> On Windows 7, Windows Server 2008 R2, and earlier, the <c>WSAConnectByName</c> function requires an unbound and
		/// unconnected socket. This differs from other Winsock calls to establish a connection (for example, WSAConnect).
		/// </para>
		/// </param>
		/// <param name="nodename">
		/// A <c>NULL</c>-terminated string that contains the name of the host or the IP address of the host on which to connect for IPv4 or IPv6.
		/// </param>
		/// <param name="servicename">
		/// <para>
		/// A <c>NULL</c>-terminated string that contains the service name or destination port of the host on which to connect for IPv4 or IPv6.
		/// </para>
		/// <para>
		/// A service name is a string alias for a port number. For example, “http” is an alias for port 80 defined by the Internet
		/// Engineering Task Force (IETF) as the default port used by web servers for the HTTP protocol. Possible values for the servicename
		/// parameter when a port number is not specified are listed in the following file:
		/// </para>
		/// <para>%WINDIR%\system32\drivers\etc\services</para>
		/// </param>
		/// <param name="LocalAddressLength">
		/// On input, a pointer to the size, in bytes, of the LocalAddress buffer provided by the caller. On output, a pointer to the size,
		/// in bytes, of the <c>SOCKADDR</c> for the local address stored in the LocalAddress buffer filled in by the system upon successful
		/// completion of the call.
		/// </param>
		/// <param name="LocalAddress">
		/// A pointer to the <c>SOCKADDR</c> structure that receives the local address of the connection. The size of the parameter is
		/// exactly the size returned in LocalAddressLength. This is the same information that would be returned by the getsockname
		/// function. This parameter can be <c>NULL</c>, in which case, the LocalAddressLength parameter is ignored.
		/// </param>
		/// <param name="RemoteAddressLength">
		/// On input, a pointer to the size, in bytes, of the RemoteAddress buffer provided by the caller. On output, a pointer to the size,
		/// in bytes, of the <c>SOCKADDR</c> for the remote address stored in RemoteAddress buffer filled-in by the system upon successful
		/// completion of the call.
		/// </param>
		/// <param name="RemoteAddress">
		/// A pointer to the <c>SOCKADDR</c> structure that receives the remote address of the connection. This is the same information that
		/// would be returned by the <c>getpeername</c> function. This parameter can be <c>NULL</c>, in which case, the RemoteAddressLength
		/// is ignored.
		/// </param>
		/// <param name="timeout">The time, in milliseconds, to wait for a response from the remote application before aborting the call.</param>
		/// <param name="Reserved">Reserved for future implementation. This parameter must be set to <c>NULL</c>.</param>
		/// <returns>
		/// <para>
		/// If a connection is established, <c>WSAConnectByName</c> returns <c>TRUE</c> and LocalAddress and RemoteAddress parameters are
		/// filled in if these buffers were supplied by the caller.
		/// </para>
		/// <para>If the call fails, <c>FALSE</c> is returned. WSAGetLastError can then be called to get extended error information.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEHOSTUNREACH</term>
		/// <term>The host passed as the nodename parameter was unreachable.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid parameter was passed to the function. The nodename or the servicename parameter must not be NULL. The Reserved
		/// parameter must be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Sufficient memory could not be allocated.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>An invalid socket was passed to the function. The s parameter must not be INVALID_SOCKET or NULL.</term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>A response from the remote application was not received before the timeout parameter was exceeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>WSAConnectByName</c> is provided to enable quick and transparent connections to remote hosts on specific ports. It is
		/// compatible with both IPv6 and IPv4 versions.
		/// </para>
		/// <para>To enable both IPv6 and IPv4 communications, use the following method:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The setsockopt function must be called on a socket created for the AF_INET6 address family to disable the <c>IPV6_V6ONLY</c>
		/// socket option before calling <c>WSAConnectByName</c>. This is accomplished by calling the <c>setsockopt</c> function on the
		/// socket with the level parameter set to <c>IPPROTO_IPV6</c> (see IPPROTO_IPV6 Socket Options), the optname parameter set to
		/// <c>IPV6_V6ONLY</c>, and the optvalue parameter value set to zero .
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>WSAConnectByName</c> has limitations: It works only for connection-oriented sockets, such as those of type SOCK_STREAM. The
		/// function does not support overlapped I/O or non-blocking behavior. <c>WSAConnectByName</c> will block even if the socket is in
		/// non-blocking mode.
		/// </para>
		/// <para>
		/// <c>WSAConnectByName</c> does not support user-provided data during the establishment of a connection. This call does not support
		/// FLOWSPEC structures, either. In cases where these features are required, WSAConnect must be used instead.
		/// </para>
		/// <para>
		/// In versions before Windows 10, if an application needs to bind to a specific local address or port, then <c>WSAConnectByName</c>
		/// cannot be used since the socket parameter to <c>WSAConnectByName</c> must be an unbound socket.
		/// </para>
		/// <para>This restriction was removed Windows 10.</para>
		/// <para>
		/// The RemoteAddress and the LocalAddress parameters point to a <c>SOCKADDR</c> structure, which is a generic data type. When
		/// <c>WSAConnectByName</c> is called, it is expected that a socket address type specific to the network protocol or address family
		/// being used will actually be passed in these parameters. So for IPv4 addresses, a pointer to a <c>sockaddr_in</c> structure would
		/// be cast to a pointer to <c>SOCKADDR</c> as the RemoteAddress and LocalAddressparameters. For IPv6 addresses, a pointer to a
		/// <c>sockaddr_in6</c> structure would be cast to a pointer to <c>SOCKADDR</c> as the RemoteAddress and LocalAddressparameters.
		/// </para>
		/// <para>
		/// When the <c>WSAConnectByName</c> function returns <c>TRUE</c>, the socket s is in the default state for a connected socket. The
		/// socket s does not enable previously set properties or options until SO_UPDATE_CONNECT_CONTEXT is set on the socket. Use the
		/// setsockopt function to set the SO_UPDATE_CONNECT_CONTEXT option.
		/// </para>
		/// <para>For example:</para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSAConnectByName</c> with the timeout parameter set to <c>NULL</c>,
		/// Winsock may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation,
		/// which can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock
		/// call inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and
		/// must never be attempted by Winsock clients.
		/// </para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSAConnectByNameW</c> function is supported for Windows Phone Store apps on Windows Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAConnectByNameW</c> function is supported for Windows Store apps
		/// on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// <para>Examples</para>
		/// <para>Establish a connection using <c>WSAConnectByName</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaconnectbynamea BOOL WSAConnectByNameA( SOCKET s,
		// LPCSTR nodename, LPCSTR servicename, LPDWORD LocalAddressLength, LPSOCKADDR LocalAddress, LPDWORD RemoteAddressLength, LPSOCKADDR
		// RemoteAddress, const timeval *timeout, LPWSAOVERLAPPED Reserved );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "6d87699f-03bd-4579-9907-ae3c29b7332b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSAConnectByName(SOCKET s, [MarshalAs(UnmanagedType.LPTStr)] string nodename, [MarshalAs(UnmanagedType.LPTStr)] string servicename, ref uint LocalAddressLength,
			[Out] SOCKADDR LocalAddress, ref uint RemoteAddressLength, [Out] SOCKADDR RemoteAddress, [In, Optional] IntPtr timeout, IntPtr Reserved = default);

		/// <summary>The <c>WSACreateEvent</c> function creates a new event object.</summary>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSACreateEvent</c> returns the handle of the event object. Otherwise, the return value is
		/// WSA_INVALID_EVENT. To get extended error information, call WSAGetLastError.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough free memory available to create the event object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSACreateEvent</c> function creates a manual-reset event object with an initial state of nonsignaled. The handle of the
		/// event object returned cannot be inherited by child processes. The event object is unnamed.
		/// </para>
		/// <para>
		/// The WSASetEvent function can be called to set the state of the event object to signaled. The WSAResetEvent function can be
		/// called to set the state of the event object to nonsignaled. When an event object is no longer needed, the WSACloseEvent function
		/// should be called to free the resources associated with the event object.
		/// </para>
		/// <para>
		/// Windows Sockets 2 event objects are system objects in Windows environments. Therefore, if a Windows application wants to use an
		/// auto-reset event rather than a manual-reset event, the application can call the CreateEvent function directly. The scope of an
		/// event object is limited to the process in which it is created.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsacreateevent WSAEVENT WSAAPI WSACreateEvent();
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "cff3bc31-f34c-4bb2-9004-5ec31d0a704a")]
		public static extern SafeWSAEVENT WSACreateEvent();

		/// <summary>
		/// The <c>WSADuplicateSocket</c> function returns a WSAPROTOCOL_INFO structure that can be used to create a new socket descriptor
		/// for a shared socket. The <c>WSADuplicateSocket</c> function cannot be used on a QOS-enabled socket.
		/// </summary>
		/// <param name="s">Descriptor identifying the local socket.</param>
		/// <param name="dwProcessId">Process identifier of the target process in which the duplicated socket will be used.</param>
		/// <param name="lpProtocolInfo">
		/// Pointer to a buffer, allocated by the client, that is large enough to contain a WSAPROTOCOL_INFO structure. The service provider
		/// copies the protocol information structure contents to this buffer.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSADuplicateSocket</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error
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
		/// <term>WSAEINVAL</term>
		/// <term>Indicates that one of the specified parameters was invalid.</term>
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
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available. The socket cannot be created.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpProtocolInfo parameter is not a valid part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSADuplicateSocket</c> function is used to enable socket sharing between processes. A source process calls
		/// <c>WSADuplicateSocket</c> to obtain a special WSAPROTOCOL_INFO structure. It uses some interprocess communications (IPC)
		/// mechanism to pass the contents of this structure to a target process, which in turn uses it in a call to WSASocket to obtain a
		/// descriptor for the duplicated socket. The special <c>WSAPROTOCOL_INFO</c> structure can only be used once by the target process.
		/// </para>
		/// <para>
		/// Sockets can be shared among threads in a given process without using the <c>WSADuplicateSocket</c> function because a socket
		/// descriptor is valid in all threads of a process.
		/// </para>
		/// <para>One possible scenario for establishing and handing off a shared socket is illustrated in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Source process</term>
		/// <term>IPC</term>
		/// <term>Destination process</term>
		/// </listheader>
		/// <item>
		/// <term>1) WSASocket, WSAConnect</term>
		/// <term/>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>2) Request target process identifier</term>
		/// <term>==&gt;</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// <term/>
		/// <term>3) Receive process identifier request and respond</term>
		/// </item>
		/// <item>
		/// <term>4) Receive process identifier</term>
		/// <term>&lt;==</term>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>5) Call WSADuplicateSocket to get a special WSAPROTOCOL_INFO structure</term>
		/// <term/>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>6) Send WSAPROTOCOL_INFO structure to target</term>
		/// <term/>
		/// <term/>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>==&gt;</term>
		/// <term>7) Receive WSAPROTOCOL_INFO structure</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term/>
		/// <term>8) Call WSASocket to create shared socket descriptor.</term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term/>
		/// <term>9) Use shared socket for data exchange</term>
		/// </item>
		/// <item>
		/// <term>10) closesocket</term>
		/// <term>&lt;==</term>
		/// <term/>
		/// </item>
		/// </list>
		/// <para>
		/// The descriptors that reference a shared socket can be used independently for I/O. However, the Windows Sockets interface does
		/// not implement any type of access control, so it is up to the processes involved to coordinate their operations on a shared
		/// socket. Shared sockets are typically used to having one process that is responsible for creating sockets and establishing
		/// connections, and other processes that are responsible for information exchange.
		/// </para>
		/// <para>
		/// All of the state information associated with a socket is held in common across all the descriptors because the socket
		/// descriptors are duplicated and not the actual socket. For example, a setsockopt operation performed using one descriptor is
		/// subsequently visible using a getsockopt from any or all descriptors. Both the source process and the destination process should
		/// pass the same flags to their respective WSASocket function calls. If the source process uses the socket function to create the
		/// socket, the destination process must pass the <c>WSA_FLAG_OVERLAPPED</c> flag to its <c>WSASocket</c> function call. A process
		/// can call closesocket on a duplicated socket and the descriptor will become deallocated. The underlying socket, however, will
		/// remain open until <c>closesocket</c> is called by the last remaining descriptor.
		/// </para>
		/// <para>
		/// Notification on shared sockets is subject to the usual constraints of WSAAsyncSelect and WSAEventSelect. Issuing either of these
		/// calls using any of the shared descriptors cancels any previous event registration for the socket, regardless of which descriptor
		/// was used to make that registration. Thus, a shared socket cannot deliver FD_READ events to process A and FD_WRITE events to
		/// process B. For situations when such tight coordination is required, developers would be advised to use threads instead of
		/// separate processes.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSADuplicateSocketW</c> function is supported for Windows Store
		/// apps on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaduplicatesocketa int WSAAPI WSADuplicateSocketA(
		// SOCKET s, DWORD dwProcessId, LPWSAPROTOCOL_INFOA lpProtocolInfo );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "d4028461-bfa6-4074-9460-5d1371790d41")]
		public static extern int WSADuplicateSocket(SOCKET s, uint dwProcessId, out WSAPROTOCOL_INFO lpProtocolInfo);

		/// <summary>The <c>WSAEnumNameSpaceProviders</c> function retrieves information on available namespace providers.</summary>
		/// <param name="lpdwBufferLength">
		/// On input, the number of bytes contained in the buffer pointed to by lpnspBuffer. On output (if the function fails, and the error
		/// is WSAEFAULT), the minimum number of bytes to pass for the lpnspBuffer to retrieve all the requested information. The buffer
		/// passed to <c>WSAEnumNameSpaceProviders</c> must be sufficient to hold all of the namespace information.
		/// </param>
		/// <param name="lpnspBuffer">
		/// A buffer that is filled with WSANAMESPACE_INFO structures. The returned structures are located consecutively at the head of the
		/// buffer. Variable sized information referenced by pointers in the structures point to locations within the buffer located between
		/// the end of the fixed sized structures and the end of the buffer. The number of structures filled in is the return value of <c>WSAEnumNameSpaceProviders</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// The <c>WSAEnumNameSpaceProviders</c> function returns the number of WSANAMESPACE_INFO structures copied into lpnspBuffer.
		/// Otherwise, the value SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpnspBuffer parameter was a NULL pointer or the buffer length, lpdwBufferLength, was too small to receive all the relevant
		/// WSANAMESPACE_INFO structures and associated information. When this error is returned, the buffer length required is returned in
		/// the lpdwBufferLength parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAEnumNameSpaceProviders</c> function returns information on available namespace providers in the buffer pointed to by
		/// the lpnspBuffer parameter. The returned buffer contains an array of WSANAMESPACE_INFO structures located consecutively at the
		/// head of the buffer. Variable sized information referenced by pointers in the <c>WSANAMESPACE_INFO</c> structures point to
		/// locations within the buffer located between the end of the fixed <c>WSANAMESPACE_INFO</c> structures and the end of the buffer.
		/// The number of <c>WSANAMESPACE_INFO</c> structures filled in is returned by the <c>WSAEnumNameSpaceProviders</c> function.
		/// </para>
		/// <para>
		/// Each WSANAMESPACE_INFO structure entry contains the provider-specific information on the namespace entry passed to the
		/// WSCInstallNameSpace and WSCInstallNameSpace32 functions when the namespace provider was installed.
		/// </para>
		/// <para>
		/// The WSAEnumNameSpaceProvidersEx function is an enhanced version of the <c>WSAEnumNameSpaceProviders</c> function. The
		/// WSCEnumNameSpaceProvidersEx32 function is an enhanced version of the <c>WSAEnumNameSpaceProviders</c> function that returns
		/// information on available 32-bit namespace providers for use on 64-bit platforms.
		/// </para>
		/// <para>Example Code</para>
		/// <para>
		/// The following example demonstrates the use of the <c>WSAEnumNameSpaceProviders</c> function to retrieve information on available
		/// namespace providers.
		/// </para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSAEnumNameSpaceProvidersW</c> function is supported for Windows Phone Store apps on Windows
		/// Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAEnumNameSpaceProvidersW</c> function is supported for Windows
		/// Store apps on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaenumnamespaceprovidersw INT WSAAPI
		// WSAEnumNameSpaceProvidersW( LPDWORD lpdwBufferLength, LPWSANAMESPACE_INFOW lpnspBuffer );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winsock2.h", MSDNShortId = "f5b6cd42-c5cb-43b6-bb96-fd260217e252")]
		public static extern int WSAEnumNameSpaceProviders(ref uint lpdwBufferLength, [Out] IntPtr lpnspBuffer);

		/// <summary>The <c>WSAEnumNameSpaceProvidersEx</c> function retrieves information on available namespace providers.</summary>
		/// <param name="lpdwBufferLength">
		/// On input, the number of bytes contained in the buffer pointed to by lpnspBuffer. On output (if the function fails, and the error
		/// is WSAEFAULT), the minimum number of bytes to allocate for the lpnspBuffer buffer to allow it to retrieve all the requested
		/// information. The buffer passed to <c>WSAEnumNameSpaceProvidersEx</c> must be sufficient to hold all of the namespace information.
		/// </param>
		/// <param name="lpnspBuffer">
		/// A buffer that is filled with WSANAMESPACE_INFOEX structures. The returned structures are located consecutively at the head of
		/// the buffer. Variable sized information referenced by pointers in the structures point to locations within the buffer located
		/// between the end of the fixed sized structures and the end of the buffer. The number of structures filled in is the return value
		/// of <c>WSAEnumNameSpaceProvidersEx</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// The <c>WSAEnumNameSpaceProvidersEx</c> function returns the number of WSANAMESPACE_INFOEX structures copied into lpnspBuffer.
		/// Otherwise, the value SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpnspBuffer parameter was a NULL pointer or the buffer length, lpdwBufferLength, was too small to receive all the relevant
		/// WSANAMESPACE_INFOEX structures and associated information. When this error is returned, the buffer length required is returned
		/// in the lpdwBufferLength parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAEnumNameSpaceProvidersEx</c> function is an enhanced version of the WSAEnumNameSpaceProviders function. The
		/// provider-specific data blob associated with the namespace entry passed in the lpProviderInfo parameter to the
		/// WSCInstallNameSpaceEx function can be queried using <c>WSAEnumNameSpaceProvidersEx</c> function.
		/// </para>
		/// <para>
		/// Currently, the only namespace provider included with Windows that sets information in the <c>ProviderSpecific</c> member of the
		/// WSANAMESPACE_INFOEX structure is the NS_EMAIL provider. The format of the <c>ProviderSpecific</c> member for an NS_EMAIL
		/// namespace provider is a NAPI_PROVIDER_INSTALLATION_BLOB structure.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>WSAEnumNameSpaceProvidersEx</c> is defined to <c>WSAEnumNameSpaceProvidersExW</c>, the
		/// Unicode version of this function. The lpnspBuffer parameter is defined to the LPSAWSANAMESPACE_INFOEXW data type and
		/// <c>WSANAMESPACE_INFOEXW</c> structures are returned on success.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>WSAEnumNameSpaceProvidersEx</c> is defined to <c>WSAEnumNameSpaceProvidersExA</c>,
		/// the ANSI version of this function. The lpnspBuffer parameter is defined to the LPSAWSANAMESPACE_INFOEXA data type and
		/// <c>WSANAMESPACE_INFOEXA</c> structures are returned on success.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAEnumNameSpaceProvidersExW</c> function is supported for Windows
		/// Store apps on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaenumnamespaceprovidersexa INT WSAAPI
		// WSAEnumNameSpaceProvidersExA( LPDWORD lpdwBufferLength, LPWSANAMESPACE_INFOEXA lpnspBuffer );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winsock2.h", MSDNShortId = "34bc96aa-63f7-4ab8-9376-6f4b979225ca")]
		public static extern int WSAEnumNameSpaceProvidersEx(ref uint lpdwBufferLength, [Out] IntPtr lpnspBuffer);

		/// <summary>
		/// The <c>WSAEnumNetworkEvents</c> function discovers occurrences of network events for the indicated socket, clear internal
		/// network event records, and reset event objects (optional).
		/// </summary>
		/// <param name="s">A descriptor identifying the socket.</param>
		/// <param name="hEventObject">An optional handle identifying an associated event object to be reset.</param>
		/// <param name="lpNetworkEvents">
		/// A pointer to a WSANETWORKEVENTS structure that is filled with a record of network events that occurred and any associated error codes.
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEINVAL</term>
		/// <term>One of the specified parameters was invalid.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpNetworkEvents parameter is not a valid part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAEnumNetworkEvents</c> function is used to discover which network events have occurred for the indicated socket since
		/// the last invocation of this function. It is intended for use in conjunction with WSAEventSelect, which associates an event
		/// object with one or more network events. The recording of network events commences when <c>WSAEventSelect</c> is called with a
		/// nonzero lNetworkEvents parameter and remains in effect until another call is made to <c>WSAEventSelect</c> with the
		/// lNetworkEvents parameter set to zero, or until a call is made to WSAAsyncSelect.
		/// </para>
		/// <para>
		/// <c>WSAEnumNetworkEvents</c> only reports network activity and errors nominated through WSAEventSelect. See the descriptions of
		/// select and WSAAsyncSelect to find out how those functions report network activity and errors.
		/// </para>
		/// <para>
		/// The socket's internal record of network events is copied to the structure referenced by lpNetworkEvents, after which the
		/// internal network events record is cleared. If the hEventObject parameter is not <c>NULL</c>, the indicated event object is also
		/// reset. The Windows Sockets provider guarantees that the operations of copying the network event record, clearing it and
		/// resetting any associated event object are atomic, such that the next occurrence of a nominated network event will cause the
		/// event object to become set. In the case of this function returning SOCKET_ERROR, the associated event object is not reset and
		/// the record of network events is not cleared.
		/// </para>
		/// <para>
		/// The <c>lNetworkEvents</c> member of the WSANETWORKEVENTS structure indicates which of the FD_XXX network events have occurred.
		/// The <c>iErrorCode</c> array is used to contain any associated error codes with the array index corresponding to the position of
		/// event bits in <c>lNetworkEvents</c>. Identifiers such as FD_READ_BIT and FD_WRITE_BIT can be used to index the <c>iErrorCode</c>
		/// array. Note that only those elements of the <c>iErrorCode</c> array are set that correspond to the bits set in lNetworkEvents
		/// parameter. Other parameters are not modified (this is important for backward compatibility with the applications that are not
		/// aware of new FD_ROUTING_INTERFACE_CHANGE and FD_ADDRESS_LIST_CHANGE events).
		/// </para>
		/// <para>The following error codes can be returned along with the corresponding network event.</para>
		/// <para><c>Event: FD_CONNECT</c></para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>Addresses in the specified family cannot be used with this socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNREFUSED</term>
		/// <term>The attempt to connect was forcefully rejected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The network cannot be reached from this host at this time.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available. The socket cannot be connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>An attempt to connect timed out without establishing a connection</term>
		/// </item>
		/// </list>
		/// <para><c>Event: FD_CLOSE</c></para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>The connection was reset by the remote side.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNABORTED</term>
		/// <term>The connection was terminated due to a time-out or other failure.</term>
		/// </item>
		/// </list>
		/// <para><c>Event: FD_ACCEPT</c></para>
		/// <para><c>Event: FD_ADDRESS_LIST_CHANGE</c></para>
		/// <para><c>Event: FD_GROUP_QOS</c></para>
		/// <para><c>Event: FD_QOS</c></para>
		/// <para><c>Event: FD_OOB</c></para>
		/// <para><c>Event: FD_READ</c></para>
		/// <para><c>Event: FD_WRITE</c></para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// </list>
		/// <para><c>Event: FD_ROUTING_INTERFACE_CHANGE</c></para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The specified destination is no longer reachable.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// </list>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the WSAEnumNetworkEvents function.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaenumnetworkevents int WSAAPI WSAEnumNetworkEvents(
		// SOCKET s, WSAEVENT hEventObject, LPWSANETWORKEVENTS lpNetworkEvents );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "2e6abccd-c82c-4a6b-8720-259986ac9984")]
		public static extern int WSAEnumNetworkEvents(SOCKET s, [Optional] WSAEVENT hEventObject, out WSANETWORKEVENTS lpNetworkEvents);

		/// <summary>The <c>WSAEnumProtocols</c> function retrieves information about available transport protocols.</summary>
		/// <param name="lpiProtocols">
		/// A <c>NULLl</c>-terminated array of iProtocol values. This parameter is optional; if lpiProtocols is <c>NULL</c>, information on
		/// all available protocols is returned. Otherwise, information is retrieved only for those protocols listed in the array.
		/// </param>
		/// <param name="lpProtocolBuffer">A pointer to a buffer that is filled with WSAPROTOCOL_INFO structures.</param>
		/// <param name="lpdwBufferLength">
		/// On input, number of bytes in the lpProtocolBuffer buffer passed to <c>WSAEnumProtocols</c>. On output, the minimum buffer size
		/// that can be passed to <c>WSAEnumProtocols</c> to retrieve all the requested information. This routine has no ability to
		/// enumerate over multiple calls; the passed-in buffer must be large enough to hold all entries in order for the routine to
		/// succeed. This reduces the complexity of the API and should not pose a problem because the number of protocols loaded on a
		/// computer is typically small.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAEnumProtocols</c> returns the number of protocols to be reported. Otherwise, a value of SOCKET_ERROR
		/// is returned and a specific error code can be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>Indicates that one of the specified parameters was invalid.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>
		/// The buffer length was too small to receive all the relevant WSAPROTOCOL_INFO structures and associated information. Pass in a
		/// buffer at least as large as the value returned in lpdwBufferLength.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// One or more of the lpiProtocols, lpProtocolBuffer, or lpdwBufferLength parameters are not a valid part of the user address space.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAEnumProtocols</c> function is used to discover information about the collection of transport protocols installed on
		/// the local computer. Layered protocols are only usable by applications when installed in protocol chains. Information on layered
		/// protocols is not returned except for any dummy layered service providers (LSPs) installed with a chain length of zero in the lpProtocolBuffer.
		/// </para>
		/// <para>
		/// <c>Note</c> Layered Service Providers are deprecated. Starting with Windows 8 and Windows Server 2012, use Windows Filtering Platform.
		/// </para>
		/// <para>
		/// The lpiProtocols parameter can be used as a filter to constrain the amount of information provided. Often, lpiProtocols will be
		/// specified as a <c>NULL</c> pointer that will cause the function to return information on all available transport protocols and
		/// protocol chains.
		/// </para>
		/// <para>
		/// The <c>WSAEnumProtocols</c> function differs from the WSCEnumProtocols and WSCEnumProtocols32 functions in that the
		/// <c>WSAEnumProtocols</c> function doesn't return WSAPROTOCOL_INFO structures for all installed protocols. The
		/// <c>WSAEnumProtocols</c> function excludes protocols that the service provider has set with the <c>PFL_HIDDEN</c> flag in the
		/// <c>dwProviderFlags</c> member of the WSAPROTOCOL_INFO structure to indicate to the Ws2_32.dll that this protocol should not be
		/// returned in the result buffer generated by <c>WSAEnumProtocols</c> function. In addition, the <c>WSAEnumProtocols</c> function
		/// does not return data for WSAPROTOCOL_INFO structures that have a chain length of one or greater (an LSP provider). The
		/// <c>WSAEnumProtocols</c> only returns information on base protocols and protocol chains that lack the <c>PFL_HIDDEN</c> flag and
		/// don't have a protocol chain length of zero.
		/// </para>
		/// <para>
		/// A WSAPROTOCOL_INFO structure is provided in the buffer pointed to by lpProtocolBuffer for each requested protocol. If the
		/// specified buffer is not large enough (as indicated by the input value of lpdwBufferLength ), the value pointed to by
		/// lpdwBufferLength will be updated to indicate the required buffer size. The application should then obtain a large enough buffer
		/// and call <c>WSAEnumProtocols</c> again.
		/// </para>
		/// <para>
		/// The order in which the WSAPROTOCOL_INFO structures appear in the buffer coincides with the order in which the protocol entries
		/// were registered by the service provider using the WS2_32.DLL, or with any subsequent reordering that occurred through the
		/// Windows Sockets application or DLL supplied for establishing default TCP/IP providers.
		/// </para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSAEnumProtocolsW</c> function is supported for Windows Phone Store apps on Windows Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSAEnumProtocolsW</c> function is supported for Windows Store apps
		/// on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates the use of the <c>WSAEnumProtocols</c> function to retrieve an array of WSAPROTOCOL_INFO
		/// structures for available transport protocols.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaenumprotocolsa int WSAAPI WSAEnumProtocolsA( LPINT
		// lpiProtocols, LPWSAPROTOCOL_INFOA lpProtocolBuffer, LPDWORD lpdwBufferLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "928b6937-41a3-4268-a3bc-14c9e04870e4")]
		public static extern int WSAEnumProtocols([Optional, MarshalAs(UnmanagedType.LPArray)] int[] lpiProtocols, [Out] IntPtr lpProtocolBuffer, ref uint lpdwBufferLength);

		/// <summary>
		/// The <c>WSAEventSelect</c> function specifies an event object to be associated with the specified set of FD_XXX network events.
		/// </summary>
		/// <param name="s">A descriptor identifying the socket.</param>
		/// <param name="hEventObject">
		/// A handle identifying the event object to be associated with the specified set of FD_XXX network events.
		/// </param>
		/// <param name="lNetworkEvents">
		/// A bitmask that specifies the combination of FD_XXX network events in which the application has interest.
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is zero if the application's specification of the network events and the associated event object was
		/// successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// As in the case of the select and WSAAsyncSelect functions, <c>WSAEventSelect</c> will frequently be used to determine when a
		/// data transfer operation (send or recv) can be issued with the expectation of immediate success. Nevertheless, a robust
		/// application must be prepared for the possibility that the event object is set and it issues a Windows Sockets call that returns
		/// WSAEWOULDBLOCK immediately. For example, the following sequence of operations is possible:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Data arrives on socket s; Windows Sockets sets the <c>WSAEventSelect</c> event object.</term>
		/// </item>
		/// <item>
		/// <term>The application does some other processing.</term>
		/// </item>
		/// <item>
		/// <term>While processing, the application issues an ioctlsocket(s, FIONREAD...) and notices that there is data ready to be read.</term>
		/// </item>
		/// <item>
		/// <term>The application issues a recv(s,...) to read the data.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The application eventually waits on the event object specified in <c>WSAEventSelect</c>, which returns immediately indicating
		/// that data is ready to read.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The application issues recv(s,...), which fails with the error WSAEWOULDBLOCK.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Having successfully recorded the occurrence of the network event (by setting the corresponding bit in the internal network event
		/// record) and signaled the associated event object, no further actions are taken for that network event until the application
		/// makes the function call that implicitly reenables the setting of that network event and signaling of the associated event object.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Network event</term>
		/// <term>Re-enabling function</term>
		/// </listheader>
		/// <item>
		/// <term>FD_READ</term>
		/// <term>The recv, recvfrom, WSARecv, WSARecvEx, or WSARecvFrom function.</term>
		/// </item>
		/// <item>
		/// <term>FD_WRITE</term>
		/// <term>The send, sendto, WSASend, or WSASendTo function.</term>
		/// </item>
		/// <item>
		/// <term>FD_OOB</term>
		/// <term>The recv, recvfrom, WSARecv, WSARecvEx, or WSARecvFrom function.</term>
		/// </item>
		/// <item>
		/// <term>FD_ACCEPT</term>
		/// <term>
		/// The accept, AcceptEx, or WSAAccept function unless the error code returned is WSATRY_AGAIN indicating that the condition
		/// function returned CF_DEFER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FD_CONNECT</term>
		/// <term>None.</term>
		/// </item>
		/// <item>
		/// <term>FD_CLOSE</term>
		/// <term>None.</term>
		/// </item>
		/// <item>
		/// <term>FD_QOS</term>
		/// <term>The WSAIoctl function with command SIO_GET_QOS.</term>
		/// </item>
		/// <item>
		/// <term>FD_GROUP_QOS</term>
		/// <term>Reserved.</term>
		/// </item>
		/// <item>
		/// <term>FD_ROUTING_ INTERFACE_CHANGE</term>
		/// <term>The WSAIoctl function with command SIO_ROUTING_INTERFACE_CHANGE.</term>
		/// </item>
		/// <item>
		/// <term>FD_ADDRESS_ LIST_CHANGE</term>
		/// <term>The WSAIoctl function with command SIO_ADDRESS_LIST_CHANGE.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Any call to the reenabling routine, even one that fails, results in reenabling of recording and signaling for the relevant
		/// network event and event object.
		/// </para>
		/// <para>
		/// For FD_READ, FD_OOB, and FD_ACCEPT network events, network event recording and event object signaling are level-triggered. This
		/// means that if the reenabling routine is called and the relevant network condition is still valid after the call, the network
		/// event is recorded and the associated event object is set. This allows an application to be event-driven and not be concerned
		/// with the amount of data that arrives at any one time. Consider the following sequence:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>
		/// The transport provider receives 100 bytes of data on socket s and causes WS2_32.DLL to record the FD_READ network event and set
		/// the associated event object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The application issues recv(s, buffptr, 50, 0) to read 50 bytes.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The transport provider causes WS2_32.DLL to record the FD_READ network event and sets the associated event object again since
		/// there is still data to be read.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// With these semantics, an application need not read all available data in response to an FD_READ network event—a single recv in
		/// response to each FD_READ network event is appropriate.
		/// </para>
		/// <para>
		/// The FD_QOS event is considered edge triggered. A message will be posted exactly once when a quality of service change occurs.
		/// Further messages will not be forthcoming until either the provider detects a further change in quality of service or the
		/// application renegotiates the quality of service for the socket.
		/// </para>
		/// <para>
		/// The FD_ROUTING_INTERFACE_CHANGE and FD_ADDRESS_LIST_CHANGE events are considered edge triggered as well. A message will be
		/// posted exactly once when a change occurs after the application has requested the notification by issuing WSAIoctl with
		/// <c>SIO_ROUTING_INTERFACE_CHANGE</c> or <c>SIO_ADDRESS_LIST_CHANGE</c> correspondingly. Other messages will not be forthcoming
		/// until the application reissues the IOCTL and another change is detected since the IOCTL has been issued.
		/// </para>
		/// <para>
		/// If a network event has already happened when the application calls <c>WSAEventSelect</c> or when the reenabling function is
		/// called, then a network event is recorded and the associated event object is set as appropriate. For example, consider the
		/// following sequence:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>An application calls listen.</term>
		/// </item>
		/// <item>
		/// <term>A connect request is received but not yet accepted.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The application calls <c>WSAEventSelect</c> specifying that it is interested in the FD_ACCEPT network event for the socket. Due
		/// to the persistence of network events, Windows Sockets records the FD_ACCEPT network event and sets the associated event object immediately.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The FD_WRITE network event is handled slightly differently. An FD_WRITE network event is recorded when a socket is first
		/// connected with a call to the connect, ConnectEx, WSAConnect, WSAConnectByList, or WSAConnectByName function or when a socket is
		/// accepted with accept, AcceptEx, or WSAAccept function and then after a send fails with WSAEWOULDBLOCK and buffer space becomes
		/// available. Therefore, an application can assume that sends are possible starting from the first FD_WRITE network event setting
		/// and lasting until a send returns WSAEWOULDBLOCK. After such a failure the application will find out that sends are again
		/// possible when an FD_WRITE network event is recorded and the associated event object is set.
		/// </para>
		/// <para>
		/// The FD_OOB network event is used only when a socket is configured to receive OOB data separately. If the socket is configured to
		/// receive OOB data inline, the OOB (expedited) data is treated as normal data and the application should register an interest in,
		/// and will get FD_READ network event, not FD_OOB network event. An application can set or inspect the way in which OOB data is to
		/// be handled by using setsockopt or getsockopt for the SO_OOBINLINE option.
		/// </para>
		/// <para>
		/// The error code in an FD_CLOSE network event indicates whether the socket close was graceful or abortive. If the error code is
		/// zero, then the close was graceful; if the error code is WSAECONNRESET, then the socket's virtual circuit was reset. This only
		/// applies to connection-oriented sockets such as SOCK_STREAM.
		/// </para>
		/// <para>
		/// The FD_CLOSE network event is recorded when a close indication is received for the virtual circuit corresponding to the socket.
		/// In TCP terms, this means that the FD_CLOSE is recorded when the connection goes into the TIME WAIT or CLOSE WAIT states. This
		/// results from the remote end performing a shutdown on the send side or a closesocket. FD_CLOSE being posted after all data is
		/// read from a socket. An application should check for remaining data upon receipt of FD_CLOSE to avoid any possibility of losing
		/// data. For more information, see the section on Graceful Shutdown, Linger Options, and Socket Closure and the <c>shutdown</c> function.
		/// </para>
		/// <para>
		/// Note that Windows Sockets will record only an FD_CLOSE network event to indicate closure of a virtual circuit. It will not
		/// record an FD_READ network event to indicate this condition.
		/// </para>
		/// <para>
		/// The FD_QOS or FD_GROUP_QOS network event is recorded when any parameter in the flow specification associated with socket s.
		/// Applications should use WSAIoctl with command <c>SIO_GET_QOS</c> to get the current quality of service for socket s.
		/// </para>
		/// <para>
		/// The FD_ROUTING_INTERFACE_CHANGE network event is recorded when the local interface that should be used to reach the destination
		/// specified in WSAIoctl with <c>SIO_ROUTING_INTERFACE_CHANGE</c> changes after such IOCTL has been issued.
		/// </para>
		/// <para>
		/// The FD_ADDRESS_LIST_CHANGE network event is recorded when the list of addresses of protocol family for the socket to which the
		/// application can bind changes after WSAIoctl with <c>SIO_ADDRESS_LIST_CHANGE</c> has been issued.
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
		/// <term>WSAEINVAL</term>
		/// <term>One of the specified parameters was invalid, or the specified socket is in an invalid state.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAEventSelect</c> function is used to specify an event object, hEventObject, to be associated with the selected FD_XXX
		/// network events, lNetworkEvents. The socket for which an event object is specified is identified by the s parameter. The event
		/// object is set when any of the nominated network events occur.
		/// </para>
		/// <para>
		/// The <c>WSAEventSelect</c> function operates very similarly to WSAAsyncSelect, the difference being the actions taken when a
		/// nominated network event occurs. The <c>WSAAsyncSelect</c> function causes an application-specified Windows message to be posted.
		/// The <c>WSAEventSelect</c> sets the associated event object and records the occurrence of this event in an internal network event
		/// record. An application can use WSAWaitForMultipleEvents to wait or poll on the event object, and use WSAEnumNetworkEvents to
		/// retrieve the contents of the internal network event record and thus determine which of the nominated network events have occurred.
		/// </para>
		/// <para>
		/// The proper way to reset the state of an event object used with the <c>WSAEventSelect</c> function is to pass the handle of the
		/// event object to the WSAEnumNetworkEvents function in the hEventObject parameter. This will reset the event object and adjust the
		/// status of active FD events on the socket in an atomic fashion.
		/// </para>
		/// <para>
		/// <c>WSAEventSelect</c> is the only function that causes network activity and errors to be recorded and retrievable through
		/// WSAEnumNetworkEvents. See the descriptions of select and WSAAsyncSelect to find out how those functions report network activity
		/// and errors.
		/// </para>
		/// <para>
		/// The <c>WSAEventSelect</c> function automatically sets socket s to nonblocking mode, regardless of the value of lNetworkEvents.
		/// To set socket s back to blocking mode, it is first necessary to clear the event record associated with socket s via a call to
		/// <c>WSAEventSelect</c> with lNetworkEvents set to zero and the hEventObject parameter set to <c>NULL</c>. You can then call
		/// ioctlsocket or WSAIoctl to set the socket back to blocking mode.
		/// </para>
		/// <para>
		/// The lNetworkEvents parameter is constructed by using the bitwise OR operator with any of the values specified in the following list.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FD_READ</term>
		/// <term>Wants to receive notification of readiness for reading.</term>
		/// </item>
		/// <item>
		/// <term>FD_WRITE</term>
		/// <term>Wants to receive notification of readiness for writing.</term>
		/// </item>
		/// <item>
		/// <term>FD_OOB</term>
		/// <term>Wants to receive notification of the arrival of OOB data.</term>
		/// </item>
		/// <item>
		/// <term>FD_ACCEPT</term>
		/// <term>Wants to receive notification of incoming connections.</term>
		/// </item>
		/// <item>
		/// <term>FD_CONNECT</term>
		/// <term>Wants to receive notification of completed connection or multipoint join operation.</term>
		/// </item>
		/// <item>
		/// <term>FD_CLOSE</term>
		/// <term>Wants to receive notification of socket closure.</term>
		/// </item>
		/// <item>
		/// <term>FD_QOS</term>
		/// <term>Wants to receive notification of socket (QoS changes.</term>
		/// </item>
		/// <item>
		/// <term>FD_GROUP_QOS</term>
		/// <term>Reserved for future use with socket groups. Want to receive notification of socket group QoS changes.</term>
		/// </item>
		/// <item>
		/// <term>FD_ROUTING_ INTERFACE_CHANGE</term>
		/// <term>Wants to receive notification of routing interface changes for the specified destination.</term>
		/// </item>
		/// <item>
		/// <term>FD_ADDRESS_ LIST_CHANGE</term>
		/// <term>Wants to receive notification of local address list changes for the address family of the socket.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Issuing a <c>WSAEventSelect</c> for a socket cancels any previous WSAAsyncSelect or <c>WSAEventSelect</c> for the same socket
		/// and clears the internal network event record. For example, to associate an event object with both reading and writing network
		/// events, the application must call <c>WSAEventSelect</c> with both FD_READ and FD_WRITE, as follows:
		/// </para>
		/// <para>
		/// It is not possible to specify different event objects for different network events. The following code will not work; the second
		/// call will cancel the effects of the first, and only the FD_WRITE network event will be associated with hEventObject2:
		/// </para>
		/// <para>
		/// To cancel the association and selection of network events on a socket, lNetworkEvents should be set to zero, in which case the
		/// hEventObject parameter will be ignored.
		/// </para>
		/// <para>
		/// Closing a socket with closesocket also cancels the association and selection of network events specified in
		/// <c>WSAEventSelect</c> for the socket. The application, however, still must call WSACloseEvent to explicitly close the event
		/// object and free any resources.
		/// </para>
		/// <para>
		/// The socket created when the accept function is called has the same properties as the listening socket used to accept it. Any
		/// <c>WSAEventSelect</c> association and network events selection set for the listening socket apply to the accepted socket. For
		/// example, if a listening socket has <c>WSAEventSelect</c> association of hEventObject with FD_ACCEPT, FD_READ, and FD_WRITE, then
		/// any socket accepted on that listening socket will also have FD_ACCEPT, FD_READ, and FD_WRITE network events associated with the
		/// same hEventObject. If a different hEventObject or network events are desired, the application should call <c>WSAEventSelect</c>,
		/// passing the accepted socket and the desired new information.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>WSAEventSelect</c> function.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaeventselect int WSAAPI WSAEventSelect( SOCKET s,
		// WSAEVENT hEventObject, long lNetworkEvents );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "f98a71e4-47fb-47a4-b37e-e4cc801a8f98")]
		public static extern int WSAEventSelect(SOCKET s, WSAEVENT hEventObject, FD lNetworkEvents);

		/// <summary>The <c>WSAGetLastError</c> function returns the error status for the last Windows Sockets operation that failed.</summary>
		/// <returns>The return value indicates the error code for this thread's last Windows Sockets operation that failed.</returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAGetLastError</c> function returns the last error that occurred for the calling thread. When a particular Windows
		/// Sockets function indicates an error has occurred, this function should be called immediately to retrieve the extended error code
		/// for the failing function call. This extended error code can be different from the error code obtained from getsockopt when
		/// called with an optname parameter of <c>SO_ERROR</c>, which is socket-specific since <c>WSAGetLastError</c> is for all
		/// thread-specific sockets.
		/// </para>
		/// <para>
		/// If a function call's return value indicates that error or other relevant data was returned in the error code,
		/// <c>WSAGetLastError</c> should be called immediately. This is necessary because some functions may reset the last extended error
		/// code to 0 if they succeed, overwriting the extended error code returned by a previously failed function. To specifically reset
		/// the extended error code, use the WSASetLastError function call with the iError parameter set to zero. A getsockopt function when
		/// called with an optname parameter of <c>SO_ERROR</c> also resets the extended error code to zero.
		/// </para>
		/// <para>
		/// The <c>WSAGetLastError</c> function should not be used to check for an extended error value on receipt of an asynchronous
		/// message. In this case, the extended error value is passed in the lParam parameter of the message, and this can differ from the
		/// value returned by <c>WSAGetLastError</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> An application can call the <c>WSAGetLastError</c> function to determine the extended error code for other Windows
		/// sockets functions as is normally done in Windows Sockets even if the WSAStartup function fails or the <c>WSAStartup</c> function
		/// was not called to properly initialize Windows Sockets before calling a Windows Sockets function. The <c>WSAGetLastError</c>
		/// function is one of the only functions in the Winsock 2.2 DLL that can be called in the case of a <c>WSAStartup</c> failure.
		/// </para>
		/// <para>
		/// The Windows Sockets extended error codes returned by this function and the text description of the error are listed under
		/// Windows Sockets Error Codes. These error codes and a short text description associated with an error code are defined in the
		/// Winerror.h header file. The FormatMessage function can be used to obtain the message string for the returned error.
		/// </para>
		/// <para>
		/// For information on how to handle error codes when porting socket applications to Winsock, see Error Codes - errno, h_errno and WSAGetLastError.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-wsagetlasterror int WSAGetLastError( );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "39e41b66-44ed-46dc-bfc2-65228b669992")]
		public static extern Win32Error WSAGetLastError();

		/// <summary>The <c>WSAGetOverlappedResult</c> function retrieves the results of an overlapped operation on the specified socket.</summary>
		/// <param name="s">
		/// <para>A descriptor identifying the socket.</para>
		/// <para>
		/// This is the same socket that was specified when the overlapped operation was started by a call to any of the Winsock functions
		/// that supports overlappped operations. These functions include AcceptEx, ConnectEx, DisconnectEx, TransmitFile, TransmitPackets,
		/// WSARecv, WSARecvFrom, WSARecvMsg, WSASend, WSASendMsg, WSASendTo, and WSAIoctl.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// A pointer to a WSAOVERLAPPED structure that was specified when the overlapped operation was started. This parameter must not be
		/// a <c>NULL</c> pointer.
		/// </param>
		/// <param name="lpcbTransfer">
		/// A pointer to a 32-bit variable that receives the number of bytes that were actually transferred by a send or receive operation,
		/// or by the WSAIoctl function. This parameter must not be a <c>NULL</c> pointer.
		/// </param>
		/// <param name="fWait">
		/// A flag that specifies whether the function should wait for the pending overlapped operation to complete. If <c>TRUE</c>, the
		/// function does not return until the operation has been completed. If <c>FALSE</c> and the operation is still pending, the
		/// function returns <c>FALSE</c> and the WSAGetLastError function returns WSA_IO_INCOMPLETE. The fWait parameter may be set to
		/// <c>TRUE</c> only if the overlapped operation selected the event-based completion notification.
		/// </param>
		/// <param name="lpdwFlags">
		/// A pointer to a 32-bit variable that will receive one or more flags that supplement the completion status. If the overlapped
		/// operation was initiated through WSARecv or WSARecvFrom, this parameter will contain the results value for lpFlags parameter.
		/// This parameter must not be a <c>NULL</c> pointer.
		/// </param>
		/// <returns>
		/// <para>
		/// If <c>WSAGetOverlappedResult</c> succeeds, the return value is <c>TRUE</c>. This means that the overlapped operation has
		/// completed successfully and that the value pointed to by lpcbTransfer has been updated.
		/// </para>
		/// <para>
		/// If <c>WSAGetOverlappedResult</c> returns <c>FALSE</c>, this means that either the overlapped operation has not completed, the
		/// overlapped operation completed but with errors, or the overlapped operation's completion status could not be determined due to
		/// errors in one or more parameters to <c>WSAGetOverlappedResult</c>. On failure, the value pointed to by lpcbTransfer will not be
		/// updated. Use WSAGetLastError to determine the cause of the failure (either by the <c>WSAGetOverlappedResult</c> function or by
		/// the associated overlapped operation).
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
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The hEvent parameter of the WSAOVERLAPPED structure does not contain a valid event object handle.</term>
		/// </item>
		/// <item>
		/// <term>WSA_INVALID_PARAMETER</term>
		/// <term>One of the parameters is unacceptable.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_INCOMPLETE</term>
		/// <term>The fWait parameter is FALSE and the I/O operation has not yet completed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// One or more of the lpOverlapped, lpcbTransfer, or lpdwFlags parameters are not in a valid part of the user address space. This
		/// error is returned if the lpOverlapped, lpcbTransfer, or lpdwFlags parameter was a NULL pointer on Windows Server 2003 and earlier.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAGetOverlappedResult</c> function reports the results of the overlapped operation specified in the lpOverlapped
		/// parameter for the socket specified in the s parameter. The <c>WSAGetOverlappedResult</c> function is passed the socket
		/// descriptor and the WSAOVERLAPPED structure that was specified when the overlapped function was called. A pending operation is
		/// indicated when the function that started the operation returns <c>FALSE</c> and the WSAGetLastError function returns
		/// WSA_IO_PENDING. When an I/O operation such as WSARecv is pending, the function that started the operation resets the hEvent
		/// member of the <c>WSAOVERLAPPED</c> structure to the nonsignaled state. Then, when the pending operation has completed, the
		/// system sets the event object to the signaled state.
		/// </para>
		/// <para>
		/// If the fWait parameter is <c>TRUE</c>, <c>WSAGetOverlappedResult</c> determines whether the pending operation has been completed
		/// by waiting for the event object to be in the signaled state. A client may set the fWait parameter to <c>TRUE</c>, but only if it
		/// selected event-based completion notification when the I/O operation was requested. If another form of notification was selected,
		/// the usage of the hEvent parameter of the WSAOVERLAPPED structure is different, and setting fWait to <c>TRUE</c> causes
		/// unpredictable results.
		/// </para>
		/// <para>
		/// If the <c>WSAGetOverlappedResult</c> function is called with the lpOverlapped, lpcbTransfer, or lpdwFlags parameter set to a
		/// <c>NULL</c> pointer on Windows Vista, this will result in an access violation. If the <c>WSAGetOverlappedResult</c> function is
		/// called with the lpOverlapped, lpcbTransfer, or lpdwFlags parameter set to a <c>NULL</c> pointer on Windows Server 2003 and
		/// earlier, this will result in the WSAEFAULT error code being returned.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O is canceled when a thread exits. For overlapped sockets, pending asynchronous operations can fail if the
		/// thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsagetoverlappedresult BOOL WSAAPI
		// WSAGetOverlappedResult( SOCKET s, LPWSAOVERLAPPED lpOverlapped, LPDWORD lpcbTransfer, BOOL fWait, LPDWORD lpdwFlags );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "3c43ccfd-0fe7-4ecc-9517-e0a1c448f7e4")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSAGetOverlappedResult(SOCKET s, in WSAOVERLAPPED lpOverlapped, out uint lpcbTransfer, [MarshalAs(UnmanagedType.Bool)] bool fWait, out uint lpdwFlags);

		/// <summary>
		/// The <c>WSAGetQOSByName</c> function initializes a QOS structure based on a named template, or it supplies a buffer to retrieve
		/// an enumeration of the available template names.
		/// </summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="lpQOSName">A pointer to a specific quality of service template.</param>
		/// <param name="lpQOS">A pointer to the QOS structure to be filled.</param>
		/// <returns>
		/// <para>
		/// If <c>WSAGetQOSByName</c> succeeds, the return value is <c>TRUE</c>. If the function fails, the return value is <c>FALSE</c>. To
		/// get extended error information, call WSAGetLastError.
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
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpQOSName or lpQOS parameter are not a valid part of the user address space, or the buffer length for lpQOS is too small.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAGetQOSByName</c> function is used by applications to initialize a QOS structure to a set of known values appropriate
		/// for a particular service class or media type. These values are stored in a template that is referenced by a well-known name. The
		/// client may retrieve these values by setting the buf parameter of the WSABUF structure indicated by lpQOSName, which points to a
		/// string of nonzero length specifying a template name. In this case, the usage of lpQOSName is IN only, and results are returned
		/// through lpQOS.
		/// </para>
		/// <para>
		/// Alternatively, the client may use this function to retrieve an enumeration of available template names. The client may do this
		/// by setting the buf parameter of the WSABUF indicated by lpQOSName to a zero-length null-terminated string. In this case the
		/// buffer indicated by buf is overwritten with a sequence of as many available, null-terminated template names up to the number of
		/// bytes available in buf as indicated by the len parameter of the <c>WSABUF</c> indicated by lpQOSName. The list of names itself
		/// is terminated by a zero-length name. When the <c>WSAGetQOSByName</c> function is used to retrieve template names, the lpQOS
		/// parameter is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsagetqosbyname BOOL WSAAPI WSAGetQOSByName( SOCKET s,
		// LPWSABUF lpQOSName, LPQOS lpQOS );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "9b586856-5441-414b-8b91-298c952c351b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSAGetQOSByName(SOCKET s, in WSABUF lpQOSName, out QOS lpQOS);

		/// <summary>
		/// The <c>WSAGetServiceClassInfo</c> function retrieves the class information (schema) pertaining to a specified service class from
		/// a specified namespace provider.
		/// </summary>
		/// <param name="lpProviderId">A pointer to a GUID that identifies a specific namespace provider.</param>
		/// <param name="lpServiceClassId">A pointer to a GUID identifying the service class.</param>
		/// <param name="lpdwBufSize">
		/// <para>On input, the number of bytes contained in the buffer pointed to by the lpServiceClassInfo parameter.</para>
		/// <para>
		/// On output, if the function fails and the error is WSAEFAULT, this parameter specifies the minimum size, in bytes, of the buffer
		/// pointed to lpServiceClassInfo needed to retrieve the record.
		/// </para>
		/// </param>
		/// <param name="lpServiceClassInfo">
		/// A pointer to a WSASERVICECLASSINFO structure that contains the service class information from the indicated namespace provider
		/// for the specified service class.
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is zero if the <c>WSAGetServiceClassInfo</c> was successful. Otherwise, the value SOCKET_ERROR is returned, and
		/// a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The calling routine does not have sufficient privileges to access the information.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The buffer pointed to by the lpServiceClassInfo parameter is too small to contain a WSASERVICECLASSINFOW. The application needs
		/// to pass in a larger buffer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// The specified service class identifier or namespace provider identifier is not valid. This error is returned if the
		/// lpProviderId, lpServiceClassId, lpdwBufSize, or lpServiceClassInfo parameters are NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// The operation is not supported for the type of object referenced. This error is returned by some namespace providers that do not
		/// support getting service class information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The requested name is valid, but no data of the requested type was found.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSATYPE_NOT_FOUND</term>
		/// <term>The specified class was not found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>WSAGetServiceClassInfo</c> function retrieves service class information from a namespace provider. The service class
		/// information retrieved from a particular namespace provider might not be the complete set of class information that was specified
		/// when the service class was installed. Individual namespace providers are only required to retain service class information that
		/// is applicable to the namespaces that they support. See the section Service Class Data Structures for more information.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsagetserviceclassinfow INT WSAAPI
		// WSAGetServiceClassInfoW( LPGUID lpProviderId, LPGUID lpServiceClassId, LPDWORD lpdwBufSize, LPWSASERVICECLASSINFOW
		// lpServiceClassInfo );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "e177bb7d-c7d3-43a4-a809-ab8212feea2e")]
		public static extern int WSAGetServiceClassInfo(in Guid lpProviderId, in Guid lpServiceClassId, ref uint lpdwBufSize, IntPtr lpServiceClassInfo);

		/// <summary>
		/// The <c>WSAGetServiceClassNameByClassId</c> function retrieves the name of the service associated with the specified type. This
		/// name is the generic service name, like FTP or SNA, and not the name of a specific instance of that service.
		/// </summary>
		/// <param name="lpServiceClassId">A pointer to the GUID for the service class.</param>
		/// <param name="lpszServiceClassName">A pointer to the service name.</param>
		/// <param name="lpdwBufferLength">
		/// On input, the length of the buffer returned by lpszServiceClassName, in characters. On output, the length of the service name
		/// copied into lpszServiceClassName, in characters.
		/// </param>
		/// <returns>
		/// <para>
		/// The <c>WSAGetServiceClassNameByClassId</c> function returns a value of zero if successful. Otherwise, the value SOCKET_ERROR is
		/// returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_INVALID_PARAMETER</term>
		/// <term>The lpServiceClassId parameter specified is invalid.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The calling routine does not have sufficient privileges to access the information.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The specified buffer pointed to by lpszServiceClassName is too small. Pass in a larger buffer.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space available.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// The operation is not supported for the type of object referenced. This error is returned by some namespace providers that do not
		/// support getting service class information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The lpServiceClassId is valid, but no data of the requested type was found.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsagetserviceclassnamebyclassida INT WSAAPI
		// WSAGetServiceClassNameByClassIdA( LPGUID lpServiceClassId, LPSTR lpszServiceClassName, LPDWORD lpdwBufferLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "0a61751e-10e5-4f91-a0b2-8c1baf477653")]
		public static extern int WSAGetServiceClassNameByClassId(in Guid lpServiceClassId, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszServiceClassName, ref uint lpdwBufferLength);

		/// <summary>The <c>WSAHtonl</c> function converts a <c>u_long</c> from host byte order to network byte order.</summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="hostlong">A 32-bit number in host byte order.</param>
		/// <param name="lpnetlong">A pointer to a 32-bit number to receive the number in network byte order.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAHtonl</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can
		/// be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpnetlong parameter is NULL or the address pointed to is not completely contained in a valid part of the user address space.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAHtonl</c> function takes a 32-bit number in host byte order and returns a 32-bit number in network byte order in the
		/// 32-bit number pointed to by the lpnetlong parameter. The socket passed in the s parameter is used to determine the network byte
		/// order required based on the Winsock catalog protocol entry associated with the socket. This feature supports Winsock providers
		/// that use different network byte orders.
		/// </para>
		/// <para>
		/// If the socket is for the AF_INET or AF_INET6 address family, the <c>WSAHtonl</c> function can be used to convert an IPv4 address
		/// in host byte order to the IPv4 address in network byte order. This function does not do any checking to determine if the
		/// hostlong parameter is a valid IPv4 address.
		/// </para>
		/// <para>
		/// The <c>WSAHtonl</c> function requires that the Winsock DLL has previously been loaded with a successful call to the WSAStartup
		/// function. For use with the AF_INET or AF_INET6 family, the htonlfunction does not require that the Winsock DLL be loaded.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsahtonl int WSAAPI WSAHtonl( IN SOCKET s, IN u_long
		// hostlong, OUT u_long *lpnetlong );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "33512f49-d576-4439-ad8d-5c87387d6214")]
		public static extern int WSAHtonl([In] SOCKET s, [In] uint hostlong, out uint lpnetlong);

		/// <summary>The <c>WSAHtons</c> function converts a <c>u_short</c> from host byte order to network byte order.</summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="hostshort">A 16-bit number in host byte order.</param>
		/// <param name="lpnetshort">A pointer to a 16-bit buffer to receive the number in network byte order.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAHtons</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can
		/// be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpnetshort parameter is NULL or the address pointed to is not completely contained in a valid part of the user address space.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAHtons</c> function takes a 16-bit number in host byte order and returns a 16-bit number in network byte order in the
		/// 16-bit number pointed to by the lpnetshort parameter. The socket passed in the s parameter is used to determine the network byte
		/// order required based on the Winsock catalog protocol entry associated with the socket. This feature supports Winsock providers
		/// that use different network byte orders.
		/// </para>
		/// <para>
		/// If the socket is for the AF_INET or AF_INET6 address family, the <c>WSAHtons</c> function can be used to convert an IP port
		/// number in host byte order to the IP port number in network byte order.
		/// </para>
		/// <para>
		/// The <c>WSAHtons</c> function requires that the Winsock DLL has previously been loaded with a successful call to the WSAStartup
		/// function. For use with the AF_INET OR AF_INET6 address family, the htonsfunction does not require that the Winsock DLL be loaded.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsahtons int WSAAPI WSAHtons( IN SOCKET s, IN u_short
		// hostshort, OUT u_short *lpnetshort );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "95fb103b-f7dd-4fa4-bf68-ed8e87cdd96b")]
		public static extern int WSAHtons([In] SOCKET s, [In] ushort hostshort, out ushort lpnetshort);

		/// <summary>
		/// The <c>WSAInstallServiceClass</c> function registers a service class schema within a namespace. This schema includes the class
		/// name, class identifier, and any namespace-specific information that is common to all instances of the service, such as the SAP
		/// identifier or object identifier.
		/// </summary>
		/// <param name="lpServiceClassInfo">
		/// <para>Service class to namespace specific–type mapping information. Multiple mappings can be handled at one time.</para>
		/// <para>See the section Service Class Data Structures for a description of pertinent data structures.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_INVALID_PARAMETER</term>
		/// <term>The namespace provider cannot supply the requested class information.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The calling function does not have sufficient privileges to install the service.</term>
		/// </item>
		/// <item>
		/// <term>WSAEALREADY</term>
		/// <term>
		/// Service class information has already been registered for this service class identifier. To modify service class information,
		/// first use WSARemoveServiceClass, and then reinstall with updated class information data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// The service class information was not valid or improperly structured. This error is returned if the lpServiceClassInfo parameter
		/// is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>The operation is not supported. This error is returned if the namespace provider does not implement this function.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The requested name is valid, but no data of the requested type was found.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsainstallserviceclassa INT WSAAPI
		// WSAInstallServiceClassA( LPWSASERVICECLASSINFOA lpServiceClassInfo );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "06760319-aeeb-4ad7-b77a-01efea7ed904")]
		public static extern int WSAInstallServiceClass(in WSASERVICECLASSINFO lpServiceClassInfo);

		/// <summary>The <c>WSAIoctl</c> function controls the mode of a socket.</summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="dwIoControlCode">The control code of operation to perform.</param>
		/// <param name="lpvInBuffer">A pointer to the input buffer.</param>
		/// <param name="cbInBuffer">The size, in bytes, of the input buffer.</param>
		/// <param name="lpvOutBuffer">A pointer to the output buffer.</param>
		/// <param name="cbOutBuffer">The size, in bytes, of the output buffer.</param>
		/// <param name="lpcbBytesReturned">A pointer to actual number of bytes of output.</param>
		/// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure (ignored for non-overlapped sockets).</param>
		/// <param name="lpCompletionRoutine">
		/// <c>Note</c> A pointer to the completion routine called when the operation has been completed (ignored for non-overlapped
		/// sockets). See Remarks.
		/// </param>
		/// <returns>
		/// <para>
		/// Upon successful completion, the <c>WSAIoctl</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific
		/// error code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpvInBuffer, lpvOutBuffer, lpcbBytesReturned, lpOverlapped, or lpCompletionRoutine parameter is not totally contained in a
		/// valid part of the user address space, or the cbInBuffer or cbOutBuffer parameter is too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// The dwIoControlCode parameter is not a valid command, or a specified input parameter is not acceptable, or the command is not
		/// applicable to the type of socket specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>The function is invoked when a callback is in progress.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor s is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// The specified IOCTL command cannot be realized. (For example, the FLOWSPEC structures specified in SIO_SET_QOS or
		/// SIO_SET_GROUP_QOS cannot be satisfied.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>The socket is marked as non-blocking and the requested operation would block.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOPROTOOPT</term>
		/// <term>
		/// The socket option is not supported on the specified protocol. For example, an attempt to use the SIO_GET_BROADCAST_ADDRESS IOCTL
		/// was made on an IPv6 socket or an attempt to use the TCP SIO_KEEPALIVE_VALS IOCTL was made on a datagram socket.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAIoctl</c> function is used to set or retrieve operating parameters associated with the socket, the transport protocol,
		/// or the communications subsystem.
		/// </para>
		/// <para>
		/// If both lpOverlapped and lpCompletionRoutine are <c>NULL</c>, the socket in this function will be treated as a non-overlapped
		/// socket. For a non-overlapped socket, lpOverlapped and lpCompletionRoutine parameters are ignored, which causes the function to
		/// behave like the standard ioctlsocket function except that the function can block if socket s is in blocking mode. If socket s is
		/// in non-blocking mode, this function can return WSAEWOULDBLOCK when the specified operation cannot be finished immediately. In
		/// this case, the application may change the socket to blocking mode and reissue the request or wait for the corresponding network
		/// event (such as FD_ROUTING_INTERFACE_CHANGE or FD_ADDRESS_LIST_CHANGE in the case of <c>SIO_ROUTING_INTERFACE_CHANGE</c> or
		/// <c>SIO_ADDRESS_LIST_CHANGE</c>) using a Windows message (using WSAAsyncSelect)-based or event (using WSAEventSelect)-based
		/// notification mechanism.
		/// </para>
		/// <para>
		/// For overlapped sockets, operations that cannot be completed immediately will be initiated, and completion will be indicated at a
		/// later time. The <c>DWORD</c> value pointed to by the lpcbBytesReturned parameter that is returned may be ignored. The final
		/// completion status and bytes returned can be retrieved when the appropriate completion method is signaled when the operation has completed.
		/// </para>
		/// <para>
		/// Any IOCTL may block indefinitely, depending on the service provider's implementation. If the application cannot tolerate
		/// blocking in a <c>WSAIoctl</c> call, overlapped I/O would be advised for IOCTLs that are especially likely to block including:
		/// </para>
		/// <para><c>SIO_ADDRESS_LIST_CHANGE</c></para>
		/// <para><c>SIO_FINDROUTE</c></para>
		/// <para><c>SIO_FLUSH</c></para>
		/// <para><c>SIO_GET_QOS</c></para>
		/// <para><c>SIO_GET_GROUP_QOS</c></para>
		/// <para><c>SIO_ROUTING_INTERFACE_CHANGE</c></para>
		/// <para><c>SIO_SET_QOS</c></para>
		/// <para><c>SIO_SET_GROUP_QOS</c></para>
		/// <para>
		/// Some protocol-specific IOCTLs may also be especially likely to block. Check the relevant protocol-specific annex for any
		/// available information.
		/// </para>
		/// <para>The prototype for the completion routine pointed to by the lpCompletionRoutine parameter is as follows:</para>
		/// <para>
		/// The CompletionRoutine is a placeholder for an application-supplied function name. The dwError parameter specifies the completion
		/// status for the overlapped operation as indicated by lpOverlapped parameter. The cbTransferred parameter specifies the number of
		/// bytes received. The dwFlags parameter is not used for this IOCTL. The completion routine does not return a value.
		/// </para>
		/// <para>
		/// It is possible to adopt an encoding scheme that preserves the currently defined ioctlsocket opcodes while providing a convenient
		/// way to partition the opcode identifier space in as much as the dwIoControlCode parameter is now a 32-bit entity. The
		/// dwIoControlCode parameter is built to allow for protocol and vendor independence when adding new control codes while retaining
		/// backward compatibility with the Windows Sockets 1.1 and Unix control codes. The dwIoControlCode parameter has the following form.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>I</term>
		/// <term>O</term>
		/// <term>V</term>
		/// <term>T</term>
		/// <term>Vendor/address family</term>
		/// <term>Code</term>
		/// </listheader>
		/// <item>
		/// <term>3</term>
		/// <term>3</term>
		/// <term>2</term>
		/// <term>2 2</term>
		/// <term>2 2 2 2 2 2 2 1 1 1 1</term>
		/// <term>1 1 1 1 1 1</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>0</term>
		/// <term>9</term>
		/// <term>8 7</term>
		/// <term>6 5 4 3 2 1 0 9 8 7 6</term>
		/// <term>5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The bits in dwIoControlCode parameter displayed in the table must be read vertically from top to bottom by column.
		/// So the left-most bit is bit 31, the next bit is bit 30, and the right-most bit is bit 0.
		/// </para>
		/// <para>I is set if the input buffer is valid for the code, as with <c>IOC_IN</c>.</para>
		/// <para>
		/// O is set if the output buffer is valid for the code, as with <c>IOC_OUT</c>. Control codes using both input and output buffers
		/// set both I and O.
		/// </para>
		/// <para>V is set if there are no parameters for the code, as with <c>IOC_VOID</c>.</para>
		/// <para>T is a 2-bit quantity that defines the type of the IOCTL. The following values are defined:</para>
		/// <para>0 The IOCTL is a standard Unix IOCTL code, as with <c>FIONREAD</c> and <c>FIONBIO</c>.</para>
		/// <para>1 The IOCTL is a generic Windows Sockets 2 IOCTL code. New IOCTL codes defined for Windows Sockets 2 will have T == 1.</para>
		/// <para>2 The IOCTL applies only to a specific address family.</para>
		/// <para>
		/// 3 The IOCTL applies only to a specific vendor's provider, as with <c>IOC_VENDOR</c>. This type allows companies to be assigned a
		/// vendor number that appears in the <c>Vendor/Address family</c> parameter. Then, the vendor can define new IOCTLs specific to
		/// that vendor without having to register the IOCTL with a clearinghouse, thereby providing vendor flexibility and privacy.
		/// </para>
		/// <para>
		/// <c>Vendor/Address family</c> An 11-bit quantity that defines the vendor who owns the code (if T == 3) or that contains the
		/// address family to which the code applies (if T == 2). If this is a Unix IOCTL code (T == 0) then this parameter has the same
		/// value as the code on Unix. If this is a generic Windows Sockets 2 IOCTL (T == 1) then this parameter can be used as an extension
		/// of the code parameter to provide additional code values.
		/// </para>
		/// <para><c>Code</c> The 16-bit quantity that contains the specific IOCTL code for the operation.</para>
		/// <para>The following Unix IOCTL codes (commands) are supported.</para>
		/// <para>The following Windows Sockets 2 commands are supported.</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSAIoctl</c> returns a value of zero and the lpcbBytesReturned parameter is
		/// updated with the number of bytes in the output buffer. If the overlapped operation is successfully initiated and will complete
		/// later, this function returns SOCKET_ERROR and indicates error code WSA_IO_PENDING. In this case, lpcbBytesReturned is not
		/// updated. When the overlapped operation completes the amount of data in the output buffer is indicated either through the
		/// cbTransferred parameter in the completion routine (if specified), or through the lpcbTransfer parameter in WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// When called with an overlapped socket, the lpOverlapped parameter must be valid for the duration of the overlapped operation.
		/// The lpOverlapped parameter contains the address of a WSAOVERLAPPED structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use WSAWaitForMultipleEvents or
		/// WSAGetOverlappedResult to wait or poll on the event object.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// WSAGetOverlappedResult for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case, the usage of the hEvent parameter is undefined, and attempting to
		/// wait on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>The prototype of the completion routine is as follows:</para>
		/// <para>
		/// This <c>CompletionRoutine</c> is a placeholder for an application-defined or library-defined function. The completion routine is
		/// invoked only if the thread is in an alertable state. To put a thread into an alertable state, use the WSAWaitForMultipleEvents,
		/// WaitForSingleObjectEx, or WaitForMultipleObjectsEx function with the fAlertable or bAlertable parameter set to <c>TRUE</c>.
		/// </para>
		/// <para>
		/// The dwError parameter of <c>CompletionRoutine</c> specifies the completion status for the overlapped operation as indicated by
		/// lpOverlapped. The cbTransferred parameter specifies the number of bytes returned. Currently, no flag values are defined and
		/// dwFlags will be zero. The <c>CompletionRoutine</c> function does not return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for this socket. The completion routines
		/// can be called in any order, not necessarily in the same order the overlapped operations are completed.
		/// </para>
		/// <para>Compatibility</para>
		/// <para>
		/// The IOCTL codes with T == 0 are a subset of the IOCTL codes used in Berkeley sockets. In particular, there is no command that is
		/// equivalent to <c>FIOASYNC</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> Some IOCTL codes require additional header files. For example, use of the <c>SIO_RCVALL</c> IOCTL requires the
		/// Mstcpip.h header file.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-wsaioctl int WSAAPI WSAIoctl( SOCKET s, DWORD
		// dwIoControlCode, LPVOID lpvInBuffer, DWORD cbInBuffer, LPVOID lpvOutBuffer, DWORD cbOutBuffer, LPDWORD lpcbBytesReturned,
		// LPWSAOVERLAPPED lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "038aeca6-d7b7-4f74-ac69-4536c2e5118b")]
		public static extern int WSAIoctl(SOCKET s, uint dwIoControlCode, [In] IntPtr lpvInBuffer, uint cbInBuffer, [Out] IntPtr lpvOutBuffer, uint cbOutBuffer, out uint lpcbBytesReturned, [Optional] IntPtr lpOverlapped, [Optional] IntPtr lpCompletionRoutine);

		/// <summary>
		/// The <c>WSAJoinLeaf</c> function joins a leaf node into a multipoint session, exchanges connect data, and specifies needed
		/// quality of service based on the specified FLOWSPEC structures.
		/// </summary>
		/// <param name="s">Descriptor identifying a multipoint socket.</param>
		/// <param name="name">Name of the peer to which the socket is to be joined.</param>
		/// <param name="namelen">Length of name, in bytes.</param>
		/// <param name="lpCallerData">Pointer to the user data that is to be transferred to the peer during multipoint session establishment.</param>
		/// <param name="lpCalleeData">
		/// Pointer to the user data that is to be transferred back from the peer during multipoint session establishment.
		/// </param>
		/// <param name="lpSQOS">Pointer to the FLOWSPEC structures for socket s, one for each direction.</param>
		/// <param name="lpGQOS">
		/// Reserved for future use with socket groups. A pointer to the FLOWSPEC structures for the socket group (if applicable).
		/// </param>
		/// <param name="dwFlags">
		/// Flags to indicate that the socket is acting as a sender (JL_SENDER_ONLY), receiver (JL_RECEIVER_ONLY), or both (JL_BOTH).
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSAJoinLeaf</c> returns a value of type SOCKET that is a descriptor for the newly created multipoint
		/// socket. Otherwise, a value of INVALID_SOCKET is returned, and a specific error code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>On a blocking socket, the return value indicates success or failure of the join operation.</para>
		/// <para>
		/// With a nonblocking socket, successful initiation of a join operation is indicated by a return of a valid socket descriptor.
		/// Subsequently, an FD_CONNECT indication will be given on the original socket s when the join operation completes, either
		/// successfully or otherwise. The application must use either WSAAsyncSelect or WSAEventSelect with interest registered for the
		/// FD_CONNECT event in order to determine when the join operation has completed and checks the associated error code to determine
		/// the success or failure of the operation. The select function cannot be used to determine when the join operation completes.
		/// </para>
		/// <para>
		/// Also, until the multipoint session join attempt completes all subsequent calls to <c>WSAJoinLeaf</c> on the same socket will
		/// fail with the error code WSAEALREADY. After the <c>WSAJoinLeaf</c> operation completes successfully, a subsequent attempt will
		/// usually fail with the error code WSAEISCONN. An exception to the WSAEISCONN rule occurs for a c_root socket that allows
		/// root-initiated joins. In such a case, another join may be initiated after a prior <c>WSAJoinLeaf</c> operation completes.
		/// </para>
		/// <para>
		/// If the return error code indicates the multipoint session join attempt failed (that is, WSAECONNREFUSED, WSAENETUNREACH,
		/// WSAETIMEDOUT) the application can call <c>WSAJoinLeaf</c> again for the same socket.
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
		/// <term>WSAEADDRINUSE</term>
		/// <term>
		/// The socket's local address is already in use and the socket was not marked to allow address reuse with SO_REUSEADDR. This error
		/// usually occurs at the time of bind, but could be delayed until this function if the bind was to a partially wildcard address
		/// (involving ADDR_ANY) and if a specific address needs to be committed at the time of this function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEADDRNOTAVAIL</term>
		/// <term>The remote address is not a valid address (such as ADDR_ANY).</term>
		/// </item>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>Addresses in the specified family cannot be used with this socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEALREADY</term>
		/// <term>A nonblocking WSAJoinLeaf call is in progress on the specified socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNREFUSED</term>
		/// <term>The attempt to join was forcefully rejected.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The name or the namelen parameter is not a valid part of the user address space, the namelen parameter is too small, the buffer
		/// length for lpCalleeData, lpSQOS, and lpGQOS are too small, or the buffer length for lpCallerData is too large.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// A WSAJoinLeaf function call was performed on a UDP socket that was opened without setting its WSA_FLAG_MULTIPOINT_C_LEAF or
		/// WSA_FLAG_MULTIPOINT_D_LEAF multipoint flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEISCONN</term>
		/// <term>The socket is already a member of the multipoint session.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The network cannot be reached from this host at this time.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>No buffer space is available. The socket cannot be joined.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>The FLOWSPEC structures specified in lpSQOS and lpGQOS cannot be satisfied.</term>
		/// </item>
		/// <item>
		/// <term>WSAEPROTONOSUPPORT</term>
		/// <term>The lpCallerData augment is not supported by the service provider.</term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>The attempt to join timed out without establishing a multipoint session.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAJoinLeaf</c> function is used to join a leaf node to a multipoint session, and to perform a number of other ancillary
		/// operations that occur at session join time as well. If the socket s is unbound, unique values are assigned to the local
		/// association by the system, and the socket is marked as bound.
		/// </para>
		/// <para>
		/// The <c>WSAJoinLeaf</c> function has the same parameters and semantics as WSAConnect except that it returns a socket descriptor
		/// (as in WSAAccept), and it has an additional dwFlags parameter. Only multipoint sockets created using WSASocket with appropriate
		/// multipoint flags set can be used for input parameter s in this function. The returned socket descriptor will not be usable until
		/// after the join operation completes. For example, if the socket is in nonblocking mode after a corresponding FD_CONNECT
		/// indication has been received from WSAAsyncSelect or WSAEventSelect on the original socket s, except that closesocket may be
		/// invoked on this new socket descriptor to cancel a pending join operation. A root application in a multipoint session may call
		/// <c>WSAJoinLeaf</c> one or more times in order to add a number of leaf nodes, however at most one multipoint connection request
		/// may be outstanding at a time. Refer to Multipoint and Multicast Semantics for additional information.
		/// </para>
		/// <para>
		/// For nonblocking sockets it is often not possible to complete the connection immediately. In such a case, this function returns
		/// an as-yet unusable socket descriptor and the operation proceeds. There is no error code such as WSAEWOULDBLOCK in this case,
		/// since the function has effectively returned a successful start indication. When the final outcome success or failure becomes
		/// known, it may be reported through WSAAsyncSelect or WSAEventSelect depending on how the client registers for notification on the
		/// original socket s. In either case, the notification is announced with FD_CONNECT and the error code associated with the
		/// FD_CONNECT indicates either success or a specific reason for failure. The select function cannot be used to detect completion
		/// notification for <c>WSAJoinLeaf</c>.
		/// </para>
		/// <para>
		/// The socket descriptor returned by <c>WSAJoinLeaf</c> is different depending on whether the input socket descriptor, s, is a
		/// c_root or a c_leaf. When used with a c_root socket, the name parameter designates a particular leaf node to be added and the
		/// returned socket descriptor is a c_leaf socket corresponding to the newly added leaf node. The newly created socket has the same
		/// properties as s, including asynchronous events registered with WSAAsyncSelect or with WSAEventSelect. It is not intended to be
		/// used for exchange of multipoint data, but rather is used to receive network event indications (for example, FD_CLOSE) for the
		/// connection that exists to the particular c_leaf. Some multipoint implementations can also allow this socket to be used for side
		/// chats between the root and an individual leaf node. An FD_CLOSE indication will be received for this socket if the corresponding
		/// leaf node calls closesocket to drop out of the multipoint session. Symmetrically, invoking <c>closesocket</c> on the c_leaf
		/// socket returned from <c>WSAJoinLeaf</c> will cause the socket in the corresponding leaf node to get an FD_CLOSE notification.
		/// </para>
		/// <para>
		/// When <c>WSAJoinLeaf</c> is invoked with a c_leaf socket, the name parameter contains the address of the root application (for a
		/// rooted control scheme) or an existing multipoint session (nonrooted control scheme), and the returned socket descriptor is the
		/// same as the input socket descriptor. In other words, a new socket descriptor is not allocated. In a rooted control scheme, the
		/// root application would put its c_root socket in listening mode by calling listen. The standard FD_ACCEPT notification will be
		/// delivered when the leaf node requests to join itself to the multipoint session. The root application uses the usual accept or
		/// WSAAccept functions to admit the new leaf node. The value returned from either <c>accept</c> or <c>WSAAccept</c> is also a
		/// c_leaf socket descriptor just like those returned from <c>WSAJoinLeaf</c>. To accommodate multipoint schemes that allow both
		/// root-initiated and leaf-initiated joins, it is acceptable for a c_root socket that is already in listening mode to be used as an
		/// input to <c>WSAJoinLeaf</c>.
		/// </para>
		/// <para>
		/// The application is responsible for allocating any memory space pointed to directly or indirectly by any of the parameters it specifies.
		/// </para>
		/// <para>
		/// The lpCallerData is a value parameter that contains any user data that is to be sent along with the multipoint session join
		/// request. If lpCallerData is <c>NULL</c>, no user data will be passed to the peer. The lpCalleeData is a result parameter that
		/// will contain any user data passed back from the peer as part of the multipoint session establishment. The <c>len</c> member of
		/// the WSABUF structure pointed to by the lpCalleeData parameter initially contains the length of the buffer allocated by the
		/// application and pointed to by the <c>buf</c> member of the <c>WSABUF</c> structure. The <c>len</c> member of the <c>WSABUF</c>
		/// structure pointed to by the lpCalleeData parameter will be set to zero if no user data has been passed back. The lpCalleeData
		/// information will be valid when the multipoint join operation is complete.
		/// </para>
		/// <para>
		/// For blocking sockets, this will be when the <c>WSAJoinLeaf</c> function returns. For nonblocking sockets, this will be after the
		/// join operation has completed. For example, this could occur after FD_CONNECT notification on the original socket s). If
		/// lpCalleeData is <c>NULL</c>, no user data will be passed back. The exact format of the user data is specific to the address
		/// family to which the socket belongs.
		/// </para>
		/// <para>
		/// At multipoint session establishment time, an application can use the lpSQOS and/or lpGQOS parameters to override any previous
		/// quality of service specification made for the socket through WSAIoctl with the SIO_SET_QOS or SIO_SET_GROUP_QOS opcodes.
		/// </para>
		/// <para>
		/// The lpSQOS parameter specifies the FLOWSPEC structures for socket s, one for each direction, followed by any additional
		/// provider-specific parameters. If either the associated transport provider in general or the specific type of socket in
		/// particular cannot honor the quality of service request, an error will be returned as indicated in the following. The respective
		/// sending or receiving flow specification values will be ignored for any unidirectional sockets. If no provider-specific
		/// parameters are specified, the <c>buf</c> and <c>len</c> members of the WSABUF structure pointed to by the lpCalleeData parameter
		/// should be set to <c>NULL</c> and zero, respectively. A <c>NULL</c> value for lpSQOS indicates no application-supplied quality of service.
		/// </para>
		/// <para>
		/// Reserved for future socket groups. The lpGQOS parameter specifies the FLOWSPEC structures for the socket group (if applicable),
		/// one for each direction, followed by any additional provider-specific parameters. If no provider-specific parameters are
		/// specified, the the <c>buf</c> and <c>len</c> members of the WSABUF structure pointed to by the lpCalleeData parameter should be
		/// set to should be set to <c>NULL</c> and zero, respectively. A <c>NULL</c> value for lpGQOS indicates no application-supplied
		/// group quality of service. This parameter will be ignored if s is not the creator of the socket group.
		/// </para>
		/// <para>
		/// When connected sockets break (that is, become closed for whatever reason), they should be discarded and recreated. It is safest
		/// to assume that when things go awry for any reason on a connected socket, the application must discard and recreate the needed
		/// sockets in order to return to a stable point.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSAJoinLeaf</c>, Winsock may need to wait for a network event before
		/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsajoinleaf SOCKET WSAAPI WSAJoinLeaf( SOCKET s, const
		// sockaddr *name, int namelen, LPWSABUF lpCallerData, LPWSABUF lpCalleeData, LPQOS lpSQOS, LPQOS lpGQOS, DWORD dwFlags );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "ef9efa03-feed-4f0d-b874-c646cce745c9")]
		public static extern SOCKET WSAJoinLeaf(SOCKET s, [In] SOCKADDR name, int namelen, [In, Optional] IntPtr lpCallerData, [Out, Optional] IntPtr lpCalleeData, [In, Optional] IntPtr lpSQOS, [In, Optional] IntPtr lpGQOS, JL dwFlags);

		/// <summary>
		/// The <c>WSALookupServiceBegin</c> function initiates a client query that is constrained by the information contained within a
		/// WSAQUERYSET structure. <c>WSALookupServiceBegin</c> only returns a handle, which should be used by subsequent calls to
		/// WSALookupServiceNext to get the actual results.
		/// </summary>
		/// <param name="lpqsRestrictions">A pointer to the search criteria. See the Remarks for details.</param>
		/// <param name="dwControlFlags">
		/// <para>A set of flags that controls the depth of the search.</para>
		/// <para>
		/// Supported values for the dwControlFlags parameter are defined in the Winsock2.h header file and can be a combination of the
		/// following options.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LUP_DEEP 0x0001</term>
		/// <term>Queries deep as opposed to just the first level.</term>
		/// </item>
		/// <item>
		/// <term>LUP_CONTAINERS 0x0002</term>
		/// <term>Returns containers only.</term>
		/// </item>
		/// <item>
		/// <term>LUP_NOCONTAINERS 0x0004</term>
		/// <term>Do not return containers.</term>
		/// </item>
		/// <item>
		/// <term>LUP_NEAREST 0x0008</term>
		/// <term>If possible, returns results in the order of distance. The measure of distance is provider specific.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_NAME 0x0010</term>
		/// <term>Retrieves the name as lpszServiceInstanceName.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_TYPE 0x0020</term>
		/// <term>Retrieves the type as lpServiceClassId.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_VERSION 0x0040</term>
		/// <term>Retrieves the version as lpVersion.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_COMMENT 0x0080</term>
		/// <term>Retrieves the comment as lpszComment.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_ADDR 0x0100</term>
		/// <term>Retrieves the addresses as lpcsaBuffer.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_BLOB 0x0200</term>
		/// <term>Retrieves the private data as lpBlob.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_ALIASES 0x0400</term>
		/// <term>
		/// Any available alias information is to be returned in successive calls to WSALookupServiceNext, and each alias returned will have
		/// the RESULT_IS_ALIAS flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_QUERY_STRING 0x0800</term>
		/// <term>Retrieves the query string used for the request.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_ALL 0x0FF0</term>
		/// <term>A set of flags that retrieves all of the LUP_RETURN_* values.</term>
		/// </item>
		/// <item>
		/// <term>LUP_FLUSHPREVIOUS 0x1000</term>
		/// <term>
		/// Used as a value for the dwControlFlags parameter in WSALookupServiceNext. Setting this flag instructs the provider to discard
		/// the last result set, which was too large for the specified buffer, and move on to the next result set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LUP_FLUSHCACHE 0x2000</term>
		/// <term>If the provider has been caching information, ignores the cache, and queries the namespace itself.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RES_SERVICE 0x8000</term>
		/// <term>
		/// This indicates whether prime response is in the remote or local part of CSADDR_INFO structure. The other part needs to be usable
		/// in either case.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lphLookup">A handle to be used when calling WSALookupServiceNext in order to start retrieving the results set.</param>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>One or more parameters were missing or invalid for this provider.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The name was found in the database but no data matching the given restrictions was located.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSASERVICE_NOT_FOUND</term>
		/// <term>
		/// No such service is known. The service cannot be found in the specified name space. This error is returned for a bluetooth
		/// service discovery request if no remote bluetooth devices were found.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The lpqsRestrictions parameter points to a buffer containing a WSAQUERYSET structure. At a minimum, the <c>dwSize</c> member of
		/// the <c>WSAQUERYSET</c> must be set to the length of the buffer before calling the <c>WSALookupServiceBegin</c> function.
		/// Applications can restrict the query by specifying other members in the <c>WSAQUERYSET</c>.
		/// </para>
		/// <para>
		/// In most instances, applications interested in only a particular transport protocol should constrain their query by address
		/// family and protocol using the <c>dwNumberOfProtocols</c> and <c>lpafpProtocols</c> members of the WSAQUERYSET rather than by
		/// specifiying the namespace in the <c>dwNameSpace</c> member.
		/// </para>
		/// <para>
		/// Information on supported network transport protocols can be retreived using the EnumProtocols, WSAEnumProtocols,
		/// WSCEnumProtocols, or WSCEnumProtocols32 function.
		/// </para>
		/// <para>
		/// It is also possible to constrain the query to a single namespace. For example, a query that only wants results from DNS (not
		/// results from the local hosts file and other naming services) would set the <c>dwNameSpace</c> member to NS_DNS. For example, a
		/// bluetooth device discovery would set the the <c>dwNameSpace</c> member to NS_BTH.
		/// </para>
		/// <para>
		/// Applications can also restrict the query to a specific namespace provider by specifying a pointer to the GUID for the provider
		/// in the <c>lpNSProviderId</c> member.
		/// </para>
		/// <para>
		/// Information on namespace providers on the local computer can be retrieved using the WSAEnumNameSpaceProviders,
		/// WSAEnumNameSpaceProvidersEx, WSCEnumNameSpaceProviders32, or WSCEnumNameSpaceProvidersEx32 function.
		/// </para>
		/// <para>
		/// If LUP_CONTAINERS is specified in a call, other restriction values should be avoided. If any are specified, it is up to the name
		/// service provider to decide if it can support this restriction over the containers. If it cannot, it should return an error.
		/// </para>
		/// <para>
		/// Some name service providers can have other means of finding containers. For example, containers might all be of some well-known
		/// type, or of a set of well-known types, and therefore a query restriction can be created for finding them. No matter what other
		/// means the name service provider has for locating containers, LUP_CONTAINERS and LUP_NOCONTAINERS take precedence. Hence, if a
		/// query restriction is given that includes containers, specifying LUP_NOCONTAINERS will prevent the container items from being
		/// returned. Similarly, no matter the query restriction, if LUP_CONTAINERS is given, only containers should be returned. If a
		/// namespace does not support containers, and LUP_CONTAINERS is specified, it should simply return WSANO_DATA.
		/// </para>
		/// <para>The preferred method of obtaining the containers within another container, is the call:</para>
		/// <para>
		/// This call is followed by the requisite number of WSALookupServiceNext calls. This will return all containers contained
		/// immediately within the starting context; that is, it is not a deep query. With this, one can map the address space structure by
		/// walking the hierarchy, perhaps enumerating the content of selected containers. Subsequent uses of <c>WSALookupServiceBegin</c>
		/// use the containers returned from a previous call.
		/// </para>
		/// <para>
		/// As mentioned above, a WSAQUERYSET structure is used as an input parameter to <c>WSALookupBegin</c> in order to qualify the
		/// query. The following table indicates how the <c>WSAQUERYSET</c> is used to construct a query. When a parameter is marked as
		/// (Optional) a <c>NULL</c> pointer can be specified, indicating that the parameter will not be used as a search criteria. See
		/// section Query-Related Data Structures for additional information.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>WSAQUERYSET member</term>
		/// <term>Query interpretation</term>
		/// </listheader>
		/// <item>
		/// <term>dwSize</term>
		/// <term>Must be set to sizeof(WSAQUERYSET). This is a versioning mechanism.</term>
		/// </item>
		/// <item>
		/// <term>dwOutputFlags</term>
		/// <term>Ignored for queries.</term>
		/// </item>
		/// <item>
		/// <term>lpszServiceInstanceName</term>
		/// <term>
		/// (Optional) Referenced string contains service name. The semantics for wildcarding within the string are not defined, but can be
		/// supported by certain namespace providers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpServiceClassId</term>
		/// <term>(Required) The GUID corresponding to the service class.</term>
		/// </item>
		/// <item>
		/// <term>lpVersion</term>
		/// <term>
		/// (Optional) References desired version number and provides version comparison semantics (that is, version must match exactly, or
		/// version must be not less than the value specified).
		/// </term>
		/// </item>
		/// <item>
		/// <term>lpszComment</term>
		/// <term>Ignored for queries.</term>
		/// </item>
		/// <item>
		/// <term>dwNameSpace See the Important note that follows.</term>
		/// <term>Identifier of a single namespace in which to constrain the search, or NS_ALL to include all namespaces.</term>
		/// </item>
		/// <item>
		/// <term>lpNSProviderId</term>
		/// <term>(Optional) References the GUID of a specific namespace provider, and limits the query to this provider only.</term>
		/// </item>
		/// <item>
		/// <term>lpszContext</term>
		/// <term>(Optional) Specifies the starting point of the query in a hierarchical namespace.</term>
		/// </item>
		/// <item>
		/// <term>dwNumberOfProtocols</term>
		/// <term>Size of the protocol constraint array, can be zero.</term>
		/// </item>
		/// <item>
		/// <term>lpafpProtocols</term>
		/// <term>(Optional) References an array of AFPROTOCOLS structure. Only services that utilize these protocols will be returned.</term>
		/// </item>
		/// <item>
		/// <term>lpszQueryString</term>
		/// <term>
		/// (Optional) Some namespaces (such as whois++) support enriched SQL-like queries that are contained in a simple text string. This
		/// parameter is used to specify that string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>dwNumberOfCsAddrs</term>
		/// <term>Ignored for queries.</term>
		/// </item>
		/// <item>
		/// <term>lpcsaBuffer</term>
		/// <term>Ignored for queries.</term>
		/// </item>
		/// <item>
		/// <term>lpBlob</term>
		/// <term>(Optional) This is a pointer to a provider-specific entity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Important</c> In most instances, applications interested in only a particular transport protocol should constrain their query
		/// by address family and protocol rather than by namespace. This would allow an application that needs to locate a TCP/IP service,
		/// for example, to have its query processed by all available namespaces such as the local hosts file, DNS, and NIS.
		/// </para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSALookupServiceBeginW</c> function is supported for Windows Phone Store apps on Windows Phone 8
		/// and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSALookupServiceBeginW</c> function is supported for Windows Store
		/// apps on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsalookupservicebegina INT WSAAPI WSALookupServiceBeginA(
		// LPWSAQUERYSETA lpqsRestrictions, DWORD dwControlFlags, LPHANDLE lphLookup );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "448309ef-b9dd-4960-8016-d26691df59ec")]
		public static extern int WSALookupServiceBegin(in WSAQUERYSET lpqsRestrictions, LUP dwControlFlags, out HANDLE lphLookup);

		/// <summary>
		/// <para>
		/// The <c>WSALookupServiceEnd</c> function is called to free the handle after previous calls to WSALookupServiceBegin and WSALookupServiceNext.
		/// </para>
		/// <para>
		/// If you call <c>WSALookupServiceEnd</c> from another thread while an existing WSALookupServiceNext is blocked, the end call will
		/// have the same effect as a cancel and will cause the <c>WSALookupServiceNext</c> call to return immediately.
		/// </para>
		/// </summary>
		/// <param name="hLookup">Handle previously obtained by calling WSALookupServiceBegin.</param>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsalookupserviceend INT WSAAPI WSALookupServiceEnd(
		// HANDLE hLookup );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "f9d2ac54-a818-464d-918e-80ebb5b1b106")]
		public static extern int WSALookupServiceEnd(HANDLE hLookup);

		/// <summary>
		/// <para>
		/// The <c>WSALookupServiceNext</c> function is called after obtaining a handle from a previous call to WSALookupServiceBegin in
		/// order to retrieve the requested service information.
		/// </para>
		/// <para>
		/// The provider will pass back a WSAQUERYSET structure in the lpqsResults buffer. The client should continue to call this function
		/// until it returns WSA_E_NO_MORE, indicating that all of <c>WSAQUERYSET</c> has been returned.
		/// </para>
		/// </summary>
		/// <param name="hLookup">A handle returned from the previous call to WSALookupServiceBegin.</param>
		/// <param name="dwControlFlags">
		/// <para>
		/// A set of flags that controls the operation. The values passed in the dwControlFlags parameter to the
		/// WSALookupServiceBeginfunction determine the possible criteria. Any values passed in the dwControlFlags parameter to the
		/// <c>WSALookupServiceNext</c> function further restrict the criteria for the service lookup.
		/// </para>
		/// <para>
		/// Currently, LUP_FLUSHPREVIOUS is defined as a means to cope with a result set that is too large. If an application does not (or
		/// cannot) supply a large enough buffer, setting LUP_FLUSHPREVIOUS instructs the provider to discard the last result set—which was
		/// too large—and move on to the next set for this call.
		/// </para>
		/// <para>
		/// Supported values for the dwControlFlags parameter are defined in the Winsock2.h header file and can be a combination of the
		/// following options.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LUP_DEEP 0x0001</term>
		/// <term>Queries deep as opposed to just the first level.</term>
		/// </item>
		/// <item>
		/// <term>LUP_CONTAINERS 0x0002</term>
		/// <term>Returns containers only.</term>
		/// </item>
		/// <item>
		/// <term>LUP_NOCONTAINERS 0x0004</term>
		/// <term>Do not return containers.</term>
		/// </item>
		/// <item>
		/// <term>LUP_NEAREST 0x0008</term>
		/// <term>If possible, returns results in the order of distance. The measure of distance is provider specific.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_NAME 0x0010</term>
		/// <term>Retrieves the name as lpszServiceInstanceName.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_TYPE 0x0020</term>
		/// <term>Retrieves the type as lpServiceClassId.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_VERSION 0x0040</term>
		/// <term>Retrieves the version as lpVersion.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_COMMENT 0x0080</term>
		/// <term>Retrieves the comment as lpszComment.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_ADDR 0x0100</term>
		/// <term>Retrieves the addresses as lpcsaBuffer.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_BLOB 0x0200</term>
		/// <term>Retrieves the private data as lpBlob.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_ALIASES 0x0400</term>
		/// <term>
		/// Any available alias information is to be returned in successive calls to WSALookupServiceNext, and each alias returned will have
		/// the RESULT_IS_ALIAS flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_QUERY_STRING 0x0800</term>
		/// <term>Retrieves the query string used for the request.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RETURN_ALL 0x0FF0</term>
		/// <term>A set of flags that retrieves all of the LUP_RETURN_* values.</term>
		/// </item>
		/// <item>
		/// <term>LUP_FLUSHPREVIOUS 0x1000</term>
		/// <term>
		/// Used as a value for the dwControlFlags parameter in WSALookupServiceNext. Setting this flag instructs the provider to discard
		/// the last result set, which was too large for the specified buffer, and move on to the next result set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LUP_FLUSHCACHE 0x2000</term>
		/// <term>If the provider has been caching information, ignores the cache, and queries the namespace itself.</term>
		/// </item>
		/// <item>
		/// <term>LUP_RES_SERVICE 0x8000</term>
		/// <term>
		/// This indicates whether prime response is in the remote or local part of CSADDR_INFO structure. The other part needs to be usable
		/// in either case.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpdwBufferLength">
		/// On input, the number of bytes contained in the buffer pointed to by lpqsResults. On output, if the function fails and the error
		/// is WSAEFAULT, then it contains the minimum number of bytes to pass for the lpqsResults to retrieve the record.
		/// </param>
		/// <param name="lpqsResults">A pointer to a block of memory, which will contain one result set in a WSAQUERYSET structure on return.</param>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_E_CANCELLED</term>
		/// <term>
		/// A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled. The data in the
		/// lpqsResults buffer is undefined. In Windows Sockets version 2, conflicting error codes are defined for WSAECANCELLED (10103) and
		/// WSA_E_CANCELLED (10111). The error code WSAECANCELLED will be removed in a future version and only WSA_E_CANCELLED will remain.
		/// For Windows Sockets version 2, however, applications should check for both WSAECANCELLED and WSA_E_CANCELLED for the widest
		/// possible compatibility with namespace providers that use either one.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_E_NO_MORE</term>
		/// <term>
		/// There is no more data available. In Windows Sockets version 2, conflicting error codes are defined for WSAENOMORE (10102) and
		/// WSA_E_NO_MORE (10110). The error code WSAENOMORE will be removed in a future version and only WSA_E_NO_MORE will remain. For
		/// Windows Sockets version 2, however, applications should check for both WSAENOMORE and WSA_E_NO_MORE for the widest possible
		/// compatibility with name-space providers that use either one.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpqsResults buffer was too small to contain a WSAQUERYSET set.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>One or more required parameters were invalid or missing.</term>
		/// </item>
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The specified Lookup handle is invalid.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The name was found in the database, but no data matching the given restrictions was located.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The dwControlFlags parameter specified in this function and the ones specified at the time of WSALookupServiceBegin are treated
		/// as restrictions for the purpose of combination. The restrictions are combined between the ones at <c>WSALookupServiceBegin</c>
		/// time and the ones at <c>WSALookupServiceNext</c> time. Therefore the flags at <c>WSALookupServiceNext</c> can never increase the
		/// amount of data returned beyond what was requested at <c>WSALookupServiceBegin</c>, although it is not an error to specify more
		/// or fewer flags. The flags specified at a given <c>WSALookupServiceNext</c> apply only to that call.
		/// </para>
		/// <para>
		/// The dwControlFlags LUP_FLUSHPREVIOUS and LUP_RES_SERVICE are exceptions to the combined restrictions rule (because they are
		/// behavior flags instead of restriction flags). If either of these flags are used in <c>WSALookupServiceNext</c> they have their
		/// defined effect regardless of the setting of the same flags at WSALookupServiceBegin.
		/// </para>
		/// <para>
		/// For example, if LUP_RETURN_VERSION is specified at WSALookupServiceBegin the service provider retrieves records including the
		/// version. If LUP_RETURN_VERSION is NOT specified at <c>WSALookupServiceNext</c>, the returned information does not include the
		/// version, even though it was available. No error is generated.
		/// </para>
		/// <para>
		/// Also for example, if LUP_RETURN_BLOB is NOT specified at WSALookupServiceBegin but is specified at <c>WSALookupServiceNext</c>,
		/// the returned information does not include the private data. No error is generated.
		/// </para>
		/// <para>
		/// If the <c>WSALookupServiceNext</c> function fails with an error of WSAEFAULT, this indicates that the buffer pointed to by the
		/// lpqsResults parameter was too small to contain the query results. A new buffer for a WSAQUERYSET should be provided with a size
		/// specified by the value pointed to by the lpdwBufferLength parameter. This new buffer for the <c>WSAQUERYSET</c> needs to have
		/// some of the members of the <c>WSAQUERYSET</c> specified before calling the <c>WSALookupServiceNext</c> function again. At a
		/// minimum, the <c>dwSize</c> member of the <c>WSAQUERYSET</c> must be set to the new size of the buffer.
		/// </para>
		/// <para>Query Results</para>
		/// <para>The following table describes how the query results are represented in the WSAQUERYSET structure.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>WSAQUERYSET member</term>
		/// <term>Result interpretation</term>
		/// </listheader>
		/// <item>
		/// <term>dwSize</term>
		/// <term>Will be set to sizeof( WSAQUERYSET). This is used as a versioning mechanism.</term>
		/// </item>
		/// <item>
		/// <term>dwOutputFlags</term>
		/// <term>RESULT_IS_ALIAS flag indicates this is an alias result.</term>
		/// </item>
		/// <item>
		/// <term>lpszServiceInstanceName</term>
		/// <term>Referenced string contains service name.</term>
		/// </item>
		/// <item>
		/// <term>lpServiceClassId</term>
		/// <term>The GUID corresponding to the service class.</term>
		/// </item>
		/// <item>
		/// <term>lpVersion</term>
		/// <term>References version number of the particular service instance.</term>
		/// </item>
		/// <item>
		/// <term>lpszComment</term>
		/// <term>Optional comment string specified by service instance.</term>
		/// </item>
		/// <item>
		/// <term>dwNameSpace</term>
		/// <term>Namespace in which the service instance was found.</term>
		/// </item>
		/// <item>
		/// <term>lpNSProviderId</term>
		/// <term>Identifies the specific namespace provider that supplied this query result.</term>
		/// </item>
		/// <item>
		/// <term>lpszContext</term>
		/// <term>Specifies the context point in a hierarchical namespace at which the service is located.</term>
		/// </item>
		/// <item>
		/// <term>dwNumberOfProtocols</term>
		/// <term>Undefined for results.</term>
		/// </item>
		/// <item>
		/// <term>lpafpProtocols</term>
		/// <term>Undefined for results, all needed protocol information is in the CSADDR_INFO structures.</term>
		/// </item>
		/// <item>
		/// <term>lpszQueryString</term>
		/// <term>
		/// When dwControlFlags includes LUP_RETURN_QUERY_STRING, this parameter returns the unparsed remainder of the
		/// lpszServiceInstanceName specified in the original query. For example, in a namespace that identifies services by hierarchical
		/// names that specify a host name and a file path within that host, the address returned might be the host address and the unparsed
		/// remainder might be the file path. If the lpszServiceInstanceName is fully parsed and LUP_RETURN_QUERY_STRING is used, this
		/// parameter is NULL or points to a zero-length string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>dwNumberOfCsAddrs</term>
		/// <term>Indicates the number of elements in the array of CSADDR_INFO structures.</term>
		/// </item>
		/// <item>
		/// <term>lpcsaBuffer</term>
		/// <term>A pointer to an array of CSADDR_INFO structures, with one complete transport address contained within each element.</term>
		/// </item>
		/// <item>
		/// <term>lpBlob</term>
		/// <term>(Optional) This is a pointer to a provider-specific entity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSALookupServiceNextW</c> function is supported for Windows Phone Store apps on Windows Phone 8
		/// and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSALookupServiceNextW</c> function is supported for Windows Store
		/// apps on Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsalookupservicenexta INT WSAAPI WSALookupServiceNextA(
		// HANDLE hLookup, DWORD dwControlFlags, LPDWORD lpdwBufferLength, LPWSAQUERYSETA lpqsResults );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "ab4f1830-b38d-4224-a6a9-6d4512245ad6")]
		public static extern int WSALookupServiceNext(HANDLE hLookup, LUP dwControlFlags, ref uint lpdwBufferLength, [Out] IntPtr lpqsResults);

		/// <summary>The Windows Sockets <c>WSANSPIoctl</c> function enables developers to make I/O control calls to a registered namespace.</summary>
		/// <param name="hLookup">The lookup handle returned from a previous call to the WSALookupServiceBegin function.</param>
		/// <param name="dwControlCode">
		/// <para>The control code of the operation to perform.</para>
		/// <para>The values that may be used for the dwControlCode parameter are determined by the namespace provider.</para>
		/// <para>
		/// The following value is supported by several Microsoft namespace providers including the Network Location Awareness (NS_NLA)
		/// namespace provider. This IOCTL is defined in the Winsock2.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SIO_NSP_NOTIFY_CHANGE</term>
		/// <term>
		/// This operation checks if the results returned with previous calls using the hLookup parameter are still valid. These previous
		/// calls include the initial call to the WSALookupServiceBegin function to retrieve the hLookup parameter. These previous calls may
		/// also include calls to the WSALookupServiceNext function using the hLookup parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpvInBuffer">A pointer to the input buffer.</param>
		/// <param name="cbInBuffer">The size, in bytes, of the input buffer.</param>
		/// <param name="lpvOutBuffer">A pointer to the output buffer.</param>
		/// <param name="cbOutBuffer">The size, in bytes, of the output buffer.</param>
		/// <param name="lpcbBytesReturned">A pointer to the number of bytes returned.</param>
		/// <param name="lpCompletion">
		/// A pointer to a WSACOMPLETION structure, used for asynchronous processing. Set lpCompletion to <c>NULL</c> to force blocking
		/// (synchronous) execution.
		/// </param>
		/// <returns>
		/// <para>
		/// Success returns NO_ERROR. Failure returns SOCKET_ERROR, and a specific error code can be retrieved by calling the
		/// WSAGetLastError function. The following table describes the error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The hLookup parameter was not a valid query handle returned by WSALookupServiceBegin.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpvInBuffer, cbInBuffer, lpvOutBuffer, cbOutBuffer, or lpCompletion argument is not totally contained in a valid part of the
		/// user address space. Alternatively, the cbInBuffer or cbOutBuffer argument is too small, and the argument is modified to reflect
		/// the required allocation size.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// A supplied parameter is not acceptable, or the operation inappropriately returns results from multiple namespaces when it does
		/// not make sense for the specified operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// The operation is not supported. This error is returned if the namespace provider does not implement this function. This error
		/// can also be returned if the specified dwControlCode is an unrecognized command.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// The socket is not using overlapped I/O (asynchronous processing), yet the lpCompletion parameter is non-NULL. This error is used
		/// as a special notification for the SIO_NSP_NOTIFY_CHANGE IOCTL when the lpCompletion parameter is NULL (a poll) to indicate that
		/// a query set remains valid.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSANSPIoctl</c> function is used to set or retrieve operating parameters associated with a query handle to a namespace
		/// provider. The hLookup parameter is a handle to the namespace provider query previously returned by the WSALookupServiceBegin
		/// function (not a socket handle).
		/// </para>
		/// <para>
		/// Any IOCTL sent to a namespace provider may block indefinitely, depending upon the implementation of the namespace. If an
		/// application cannot tolerate blocking in a <c>WSANSPIoctl</c> function call, overlapped I/O should be used and the lpCompletion
		/// parameter should point to a WSACOMPLETION structure. To make a <c>WSANSPIoctl</c> function call nonblocking and return
		/// immediately, set the <c>Type</c> member of the <c>WSACOMPLETION</c> structure to <c>NSP_NOTIFY_IMMEDIATELY</c>.
		/// </para>
		/// <para>
		/// If lpCompletion is <c>NULL</c>, the <c>WSANSPIoctl</c> function executes as a blocking call. The namespace provider should
		/// return immediately and should not block. But each namespace is responsible for enforcing this behavior.
		/// </para>
		/// <para>The following IOCTL code is supported by several Microsoft name space provider:</para>
		/// <para>
		/// Immediate poll operations are usually much less expensive since they do not require a notification object. In most cases, this
		/// is implemented as a simple Boolean variable check. Asynchronous notification, however, may necessitate the creation of dedicated
		/// worker threads and/or inter-process communication channels, depending on the implementation of the namespace provider service,
		/// and will incur processing overhead related to the notification object involved with signaling the change event.
		/// </para>
		/// <para>
		/// To cancel an asynchronous notification request, end the original query with a WSALookupServiceEnd function call on the affected
		/// query handle. Canceling the asynchronous notification for LUP_NOTIFY_HWND will not post any message, however, an overlapped
		/// operation will be completed and notification will be delivered with the error WSA_OPERATION_ABORTED.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsanspioctl INT WSAAPI WSANSPIoctl( HANDLE hLookup, DWORD
		// dwControlCode, LPVOID lpvInBuffer, DWORD cbInBuffer, LPVOID lpvOutBuffer, DWORD cbOutBuffer, LPDWORD lpcbBytesReturned,
		// LPWSACOMPLETION lpCompletion );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "6ecaedf0-0038-46d3-9916-c9cb069c5e92")]
		public static extern int WSANSPIoctl(HANDLE hLookup, uint dwControlCode, [In, Optional] IntPtr lpvInBuffer, uint cbInBuffer, [Out, Optional] IntPtr lpvOutBuffer, uint cbOutBuffer, out uint lpcbBytesReturned, [In, Optional] IntPtr lpCompletion);

		/// <summary>The <c>WSANtohl</c> function converts a <c>u_long</c> from network byte order to host byte order.</summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="netlong">A 32-bit number in network byte order.</param>
		/// <param name="lphostlong">A pointer to a 32-bit number to receive the number in host byte order.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSANtohl</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can
		/// be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lphostlong parameter is NULL or the address pointed to is not completely contained in a valid part of the user address space.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSANtohl</c> function takes a 32-bit number in network byte order and returns a 32-bit number in host byte order in the
		/// 32-bit number pointed to by the lphostlong parameter. The socket passed in the s parameter is used to determine the network byte
		/// order required based on the Winsock catalog protocol entry associated with the socket. This feature supports Winsock providers
		/// that use different network byte orders.
		/// </para>
		/// <para>
		/// If the socket is for the AF_INET or AF_INET6 address family, the <c>WSANtohl</c> function can be used to convert an IPv4 address
		/// in network byte order to the IPv4 address in host byte order. This function does not do any checking to determine if the netlong
		/// parameter is a valid IPv4 address.
		/// </para>
		/// <para>
		/// The <c>WSANtohl</c> function requires that the Winsock DLL has previously been loaded with a successful call to the WSAStartup
		/// function. For use with the AF_INET or AF_INET6 family, the ntohl function does not require that the Winsock DLL be loaded.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsantohl int WSAAPI WSANtohl( SOCKET s, u_long netlong,
		// u_long *lphostlong );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "7e3b42eb-3b93-459f-828a-c19e277882c7")]
		public static extern int WSANtohl(SOCKET s, uint netlong, out uint lphostlong);

		/// <summary>The <c>WSANtohs</c> function converts a <c>u_short</c> from network byte order to host byte order.</summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="netshort">A 16-bit number in network byte order.</param>
		/// <param name="lphostshort">A pointer to a 16-bit number to receive the number in host byte order.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSANtohs</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can
		/// be retrieved by calling WSAGetLastError.
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
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lphostshort parameter is NULL or the address pointed to is not completely contained in a valid part of the user address space.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSANtohs</c> function takes a 16-bit number in network byte order and returns a 16-bit number in host byte order in the
		/// 16-bit number pointed to by the lphostshort parameter. The socket passed in the s parameter is used to determine the network
		/// byte order required based on the Winsock catalog protocol entry associated with the socket. This feature supports Winsock
		/// providers that use different network byte orders.
		/// </para>
		/// <para>
		/// If the socket is for the AF_INET or AF_INET6 address family, the <c>WSANtohs</c> function can be used to convert an IP port
		/// number in network byte order to the IP port number in host byte order.
		/// </para>
		/// <para>
		/// The <c>WSANtohs</c> function requires that the Winsock DLL has previously been loaded with a successful call to the WSAStartup
		/// function. For use with the AF_INET OR AF_INET6 address family, the ntohsfunction does not require that the Winsock DLL be loaded.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsantohs int WSAAPI WSANtohs( SOCKET s, u_short netshort,
		// u_short *lphostshort );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "0a4bc3a9-9919-4dcb-8a37-af37e0243c8f")]
		public static extern int WSANtohs(SOCKET s, ushort netshort, out ushort lphostshort);

		/// <summary>The <c>WSAPoll</c> function determines status of one or more sockets.</summary>
		/// <param name="fdArray">
		/// An array of one or more <c>POLLFD</c> structures specifying the set of sockets for which status is requested. The array must
		/// contain at least one structure with a valid socket. Upon return, this parameter receives the updated sockets with the
		/// <c>revents</c> status flags member set on each one that matches the status query criteria.
		/// </param>
		/// <param name="fds">
		/// The number of <c>WSAPOLLFD</c> structures in fdarray. This is not necessarily the number of sockets for which status is requested.
		/// </param>
		/// <param name="timeout">
		/// <para>A value that specifies the wait behavior, based on the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>Greater than zero</term>
		/// <term>The time, in milliseconds, to wait.</term>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <term>Return immediately.</term>
		/// </item>
		/// <item>
		/// <term>Less than zero</term>
		/// <term>Wait indefinitely.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>Zero</term>
		/// <term>No sockets were in the queried state before the timer expired.</term>
		/// </item>
		/// <item>
		/// <term>Greater than zero</term>
		/// <term>The number of elements in fdarray for which an revents member of the POLLFD structure is nonzero.</term>
		/// </item>
		/// <item>
		/// <term>SOCKET_ERROR</term>
		/// <term>An error occurred. Call the WSAGetLastError function to retrieve the extended error code.</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Extended Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>An exception occurred while reading user input parameters.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid parameter was passed. This error is returned if the
		/// [WSAPOLLFD](/windows/win32/api/winsock2/ns-winsock2-wsapollfd)a&gt; structures pointed to by the fdarray parameter when
		/// requesting socket status. This error is also returned if none of the sockets specified in the fd member of any of the WSAPOLLFD
		/// structures pointed to by the fdarray parameter were valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>The function was unable to allocate sufficient memory.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>WSAPoll</c> function is defined on Windows Vista and later.</para>
		/// <para>
		/// The WSAPOLLFD structures. An application sets the appropriate flags in the <c>events</c> member of the <c>WSAPOLLFD</c>
		/// structure to specify the type of status requested for each corresponding socket. The <c>WSAPoll</c> function returns the status
		/// of a socket in the <c>revents</c> member of the <c>WSAPOLLFD</c> structure.
		/// </para>
		/// <para>
		/// For each socket, a caller can request information on read or write status. Error conditions are always returned, so information
		/// on them need not be requested.
		/// </para>
		/// <para>
		/// The WSAPOLLFD structure pointed to by the fdarray parameter. All sockets that do not meet these criteria and have no error
		/// condition will have the corresponding <c>revents</c> member set to 0.
		/// </para>
		/// <para>
		/// A combination of the following flags can be set in the WSAPOLLFD structure for a given socket when requesting status for that socket:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>POLLPRI</term>
		/// <term>Priority data may be read without blocking. This flag is not supported by the Microsoft Winsock provider.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDBAND</term>
		/// <term>Priority band (out-of-band) data may be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDNORM</term>
		/// <term>Normal data may be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLWRNORM</term>
		/// <term>Normal data may be written without blocking.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>POLLIN</c> flag is defined as the combination of the <c>POLLRDNORM</c> and <c>POLLRDBAND</c> flag values. The
		/// <c>POLLOUT</c> flag is defined as the same as the <c>POLLWRNORM</c> flag value.
		/// </para>
		/// <para>
		/// The WSAPOLLFD structure must only contain a combination of the above flags that are supported by the Winsock provider. Any other
		/// values are considered errors and <c>WSAPoll</c> will return <c>SOCKET_ERROR</c>. A subsequent call to the WSAGetLastError
		/// function will retrieve the extended error code of WSAEINVAL. If the <c>POLLPRI</c> flag is set on a socket for the Microsoft
		/// Winsock provider, the <c>WSAPoll</c> function will fail.
		/// </para>
		/// <para>When the WSAPOLLFD structures pointed to by the fdarray parameter to indicate socket status:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>POLLERR</term>
		/// <term>An error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>POLLHUP</term>
		/// <term>A stream-oriented connection was either disconnected or aborted.</term>
		/// </item>
		/// <item>
		/// <term>POLLNVAL</term>
		/// <term>An invalid socket was used.</term>
		/// </item>
		/// <item>
		/// <term>POLLPRI</term>
		/// <term>Priority data may be read without blocking. This flag is not returned by the Microsoft Winsock provider.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDBAND</term>
		/// <term>Priority band (out-of-band) data may be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDNORM</term>
		/// <term>Normal data may be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLWRNORM</term>
		/// <term>Normal data may be written without blocking.</term>
		/// </item>
		/// </list>
		/// <para>With regard to TCP and UDP sockets:</para>
		/// <list type="bullet"/>
		/// <para>
		/// The number of elements (not sockets) in fdarray is indicated by nfds. Members of fdarray which have their <c>fd</c> member set
		/// to a negative value are ignored and their <c>revents</c> will be set to <c>POLLNVAL</c> upon return. This behavior is useful to
		/// an application which maintains a fixed fdarray allocation and will not compact the array to remove unused entries or to
		/// reallocate memory. It is not necessary to clear <c>revents</c> for any element prior to calling <c>WSAPoll</c>.
		/// </para>
		/// <para>
		/// The timeout argument specifies how long the function is to wait before returning. A positive value contains the number of
		/// milliseconds to wait before returning. A zero value forces <c>WSAPoll</c> to return immediately, and a negative value indicates
		/// that <c>WSAPoll</c> should wait indefinitely.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSAPoll</c> with the timeout parameter set to a negative number,
		/// Winsock may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation,
		/// which can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock
		/// call inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and
		/// must never be attempted by Winsock clients.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsapoll int WSAAPI WSAPoll( LPWSAPOLLFD fdArray, ULONG
		// fds, INT timeout );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "3f6f872c-5cee-49f3-bf22-2e8a5d147987")]
		public static extern int WSAPoll([In, Out, MarshalAs(UnmanagedType.LPArray)] WSAPOLLFD[] fdArray, uint fds, int timeout);

		/// <summary>The <c>WSAProviderConfigChange</c> function notifies the application when the provider configuration is changed.</summary>
		/// <param name="lpNotificationHandle">
		/// Pointer to notification handle. If the notification handle is set to <c>NULL</c> (the handle value not the pointer itself), this
		/// function returns a notification handle in the location pointed to by lpNotificationHandle.
		/// </param>
		/// <param name="lpOverlapped">Pointer to a WSAOVERLAPPED structure.</param>
		/// <param name="lpCompletionRoutine">Pointer to the completion routine called when the provider change notification is received.</param>
		/// <returns>
		/// <para>
		/// If no error occurs the <c>WSAProviderConfigChange</c> returns 0. Otherwise, a value of SOCKET_ERROR is returned and a specific
		/// error code may be retrieved by calling WSAGetLastError. The error code WSA_IO_PENDING indicates that the overlapped operation
		/// has been successfully initiated and that completion (and thus change event) will be indicated at a later time.
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
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough free memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>Value pointed by lpNotificationHandle parameter is not a valid notification handle.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>Current operating system environment does not support provider installation or removal without restart.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAProviderConfigChange</c> function notifies the application of provider (both transport and namespace) installation or
		/// removal in Windows operating environments that support such configuration change without requiring a restart. When called for
		/// the first time (lpNotificationHandle parameter points to <c>NULL</c> handle), this function completes immediately and returns
		/// notification handle in the location pointed by lpNotificationHandle that can be used in subsequent calls to receive
		/// notifications of provider installation and removal. The second and any subsequent calls only complete when provider information
		/// changes since the time the call was made It is expected (but not required) that the application uses overlapped I/O on second
		/// and subsequent calls to <c>WSAProviderConfigChange</c>, in which case the call will return immediately and application will be
		/// notified of provider configuration changes using the completion mechanism chosen through specified overlapped completion parameters.
		/// </para>
		/// <para>
		/// Notification handle returned by <c>WSAProviderConfigChange</c> is like any regular operating system handle that should be closed
		/// (when no longer needed) using Windows CloseHandle call.
		/// </para>
		/// <para>
		/// The following sequence of actions can be used to guarantee that application always has current protocol configuration information:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Call <c>WSAProviderConfigChange</c></term>
		/// </item>
		/// <item>
		/// <term>Call WSAEnumProtocols and/or WSAEnumNameSpaceProviders</term>
		/// </item>
		/// <item>
		/// <term>
		/// Whenever <c>WSAProviderConfigChange</c> notifies application of provider configuration change (through blocking or overlapped
		/// I/O), the whole sequence of actions should be repeated.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaproviderconfigchange INT WSAAPI
		// WSAProviderConfigChange( LPHANDLE lpNotificationHandle, LPWSAOVERLAPPED lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE
		// lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "abaf367a-8f99-478c-a58c-d57e9f9cd8a1")]
		public static extern int WSAProviderConfigChange(ref HANDLE lpNotificationHandle, [In, Out, Optional] IntPtr lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/// <summary>The <c>WSARecv</c> function receives data from a connected socket or a bound connectionless socket.</summary>
		/// <param name="s">A descriptor identifying a connected socket.</param>
		/// <param name="lpBuffers">
		/// A pointer to an array of WSABUF structures. Each <c>WSABUF</c> structure contains a pointer to a buffer and the length, in
		/// bytes, of the buffer.
		/// </param>
		/// <param name="dwBufferCount">The number of WSABUF structures in the lpBuffers array.</param>
		/// <param name="lpNumberOfBytesRecvd">
		/// <para>A pointer to the number, in bytes, of data received by this call if the receive operation completes immediately.</para>
		/// <para>
		/// Use <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> to avoid potentially erroneous results. This
		/// parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpFlags">
		/// A pointer to flags used to modify the behavior of the <c>WSARecv</c> function call. For more information, see the Remarks section.
		/// </param>
		/// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure (ignored for nonoverlapped sockets).</param>
		/// <param name="lpCompletionRoutine">
		/// A pointer to the completion routine called when the receive operation has been completed (ignored for nonoverlapped sockets).
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs and the receive operation has completed immediately, <c>WSARecv</c> returns zero. In this case, the
		/// completion routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a
		/// value of <c>SOCKET_ERROR</c> is returned, and a specific error code can be retrieved by calling WSAGetLastError. The error code
		/// WSA_IO_PENDING indicates that the overlapped operation has been successfully initiated and that completion will be indicated at
		/// a later time. Any other error code indicates that the overlapped operation was not successfully initiated and no completion
		/// indication will occur.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAECONNABORTED</term>
		/// <term>The virtual circuit was terminated due to a time-out or other failure.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>
		/// For a stream socket, the virtual circuit was reset by the remote side. The application should close the socket as it is no
		/// longer usable. For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port
		/// Unreachable" message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEDISCON</term>
		/// <term>Socket s is message oriented and the virtual circuit was gracefully closed by the remote side.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpBuffers parameter is not completely contained in a valid part of the user address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>The (blocking) call was canceled by the WSACancelBlockingCall function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket has not been bound (for example, with bind).</term>
		/// </item>
		/// <item>
		/// <term>WSAEMSGSIZE</term>
		/// <term>
		/// The message was too large to fit into the specified buffer and (for unreliable protocols only) any trailing portion of the
		/// message that did not fit into the buffer has been discarded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETRESET</term>
		/// <term>
		/// For a connection-oriented socket, this error indicates that the connection has been broken due to keep-alive activity that
		/// detected a failure while the operation was in progress. For a datagram socket, this error indicates that the time to live has expired.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// MSG_OOB was specified, but the socket is not stream-style such as type SOCK_STREAM, OOB data is not supported in the
		/// communication domain associated with this socket, or the socket is unidirectional and supports only send operations.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAESHUTDOWN</term>
		/// <term>
		/// The socket has been shut down; it is not possible to call WSARecv on a socket after shutdown has been invoked with how set to
		/// SD_RECEIVE or SD_BOTH.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>The connection has been dropped because of a network failure or because the peer system failed to respond.</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// Windows NT: Overlapped sockets: there are too many outstanding overlapped I/O requests. Nonoverlapped sockets: The socket is
		/// marked as nonblocking and the receive operation cannot be completed immediately.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term>WSA_OPERATION_ABORTED</term>
		/// <term>The overlapped operation has been canceled due to the closure of the socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSARecv</c> function provides some additional features compared with the standard recv function in three important areas:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>It can be used in conjunction with overlapped sockets to perform overlapped recv operations.</term>
		/// </item>
		/// <item>
		/// <term>It allows multiple receive buffers to be specified making it applicable to the scatter/gather type of I/O.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The lpFlags parameter is used both on input and returned on output, allowing applications to sense the output state of the
		/// <c>MSG_PARTIAL</c> flag bit. However, the <c>MSG_PARTIAL</c> flag bit is not supported by all protocols.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>WSARecv</c> function is used on connected sockets or bound connectionless sockets specified by the s parameter and is
		/// used to read incoming data. The socket's local address must be known. For server applications, this is usually done explicitly
		/// through bind or implicitly through accept or WSAAccept. Explicit binding is discouraged for client applications. For client
		/// applications the socket can become bound implicitly to a local address through connect, WSAConnect, sendto, WSASendTo, or WSAJoinLeaf.
		/// </para>
		/// <para>
		/// For connected, connectionless sockets, this function restricts the addresses from which received messages are accepted. The
		/// function only returns messages from the remote address specified in the connection. Messages from other addresses are (silently) discarded.
		/// </para>
		/// <para>
		/// For overlapped sockets, <c>WSARecv</c> is used to post one or more buffers into which incoming data will be placed as it becomes
		/// available, after which the application-specified completion indication (invocation of the completion routine or setting of an
		/// event object) occurs. If the operation does not complete immediately, the final completion status is retrieved through the
		/// completion routine or WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para>
		/// If both lpOverlapped and lpCompletionRoutine are <c>NULL</c>, the socket in this function will be treated as a nonoverlapped socket.
		/// </para>
		/// <para>
		/// For nonoverlapped sockets, the blocking semantics are identical to that of the standard recv function and the lpOverlapped and
		/// lpCompletionRoutine parameters are ignored. Any data that has already been received and buffered by the transport will be copied
		/// into the specified user buffers. In the case of a blocking socket with no data currently having been received and buffered by
		/// the transport, the call will block until data is received. Windows Sockets 2 does not define any standard blocking time-out
		/// mechanism for this function. For protocols acting as byte-stream protocols the stack tries to return as much data as possible
		/// subject to the available buffer space and amount of received data available. However, receipt of a single byte is sufficient to
		/// unblock the caller. There is no guarantee that more than a single byte will be returned. For protocols acting as
		/// message-oriented, a full message is required to unblock the caller.
		/// </para>
		/// <para><c>Note</c> The socket options <c>SO_RCVTIMEO</c> and <c>SO_SNDTIMEO</c> apply only to blocking sockets.</para>
		/// <para>
		/// Whether or not a protocol is acting as byte stream is determined by the setting of XP1_MESSAGE_ORIENTED and XP1_PSEUDO_STREAM in
		/// its WSAPROTOCOL_INFO structure and the setting of the MSG_PARTIAL flag passed in to this function (for protocols that support
		/// it). The following table lists relevant combinations, (an asterisk (*) indicates that the setting of this bit does not matter in
		/// this case).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>XP1_MESSAGE_ORIENTED</term>
		/// <term>XP1_PSEUDO_STREAM</term>
		/// <term>MSG_PARTIAL</term>
		/// <term>Acts as</term>
		/// </listheader>
		/// <item>
		/// <term>not set</term>
		/// <term>*</term>
		/// <term>*</term>
		/// <term>Byte stream</term>
		/// </item>
		/// <item>
		/// <term>*</term>
		/// <term>Set</term>
		/// <term>*</term>
		/// <term>Byte stream</term>
		/// </item>
		/// <item>
		/// <term>set</term>
		/// <term>Not set</term>
		/// <term>set</term>
		/// <term>Byte stream</term>
		/// </item>
		/// <item>
		/// <term>set</term>
		/// <term>Not set</term>
		/// <term>not set</term>
		/// <term>Message oriented</term>
		/// </item>
		/// </list>
		/// <para>
		/// The buffers are filled in the order in which they appear in the array pointed to by lpBuffers, and the buffers are packed so
		/// that no holes are created.
		/// </para>
		/// <para>
		/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture the WSABUF
		/// structures before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays pointed to by
		/// the lpBuffers parameter.
		/// </para>
		/// <para>
		/// For byte stream-style sockets (for example, type <c>SOCK_STREAM</c>), incoming data is placed into the buffers until the buffers
		/// are filled, the connection is closed, or the internally buffered data is exhausted. Regardless of whether or not the incoming
		/// data fills all the buffers, the completion indication occurs for overlapped sockets.
		/// </para>
		/// <para>
		/// For message-oriented sockets (for example, type <c>SOCK_DGRAM</c>), an incoming message is placed into the buffers up to the
		/// total size of the buffers, and the completion indication occurs for overlapped sockets. If the message is larger than the
		/// buffers, the buffers are filled with the first part of the message. If the <c>MSG_PARTIAL</c> feature is supported by the
		/// underlying service provider, the <c>MSG_PARTIAL</c> flag is set in lpFlags and subsequent receive operations will retrieve the
		/// rest of the message. If <c>MSG_PARTIAL</c> is not supported but the protocol is reliable, <c>WSARecv</c> generates the error
		/// WSAEMSGSIZE and a subsequent receive operation with a larger buffer can be used to retrieve the entire message. Otherwise, (that
		/// is, the protocol is unreliable and does not support <c>MSG_PARTIAL</c>), the excess data is lost, and <c>WSARecv</c> generates
		/// the error WSAEMSGSIZE.
		/// </para>
		/// <para>
		/// For connection-oriented sockets, <c>WSARecv</c> can indicate the graceful termination of the virtual circuit in one of two ways
		/// that depend on whether the socket is byte stream or message oriented. For byte streams, zero bytes having been read (as
		/// indicated by a zero return value to indicate success, and lpNumberOfBytesRecvd value of zero) indicates graceful closure and
		/// that no more bytes will ever be read. For message-oriented sockets, where a zero byte message is often allowable, a failure with
		/// an error code of WSAEDISCON is used to indicate graceful closure. In any case a return error code of WSAECONNRESET indicates an
		/// abortive close has occurred.
		/// </para>
		/// <para>
		/// The lpFlags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
		/// associated socket. That is, the semantics of this function are determined by the socket options and the lpFlags parameter. The
		/// latter is constructed by using the bitwise OR operator with any of the values listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_PEEK</term>
		/// <term>
		/// Peeks at the incoming data. The data is copied into the buffer, but is not removed from the input queue. This flag is valid only
		/// for nonoverlapped sockets.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_OOB</term>
		/// <term>Processes OOB data.</term>
		/// </item>
		/// <item>
		/// <term>MSG_PARTIAL</term>
		/// <term>
		/// This flag is for message-oriented sockets only. On output, this flag indicates that the data specified is a portion of the
		/// message transmitted by the sender. Remaining portions of the message will be specified in subsequent receive operations. A
		/// subsequent receive operation with the MSG_PARTIAL flag cleared indicates end of sender's message. As an input parameter, this
		/// flag indicates that the receive operation should complete even if only part of a message has been received by the transport provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_PUSH_IMMEDIATE</term>
		/// <term>
		/// This flag is for stream-oriented sockets only. This flag allows an application that uses stream sockets to tell the transport
		/// provider not to delay completion of partially filled pending receive requests. This is a hint to the transport provider that the
		/// application is willing to receive any incoming data as soon as possible without necessarily waiting for the remainder of the
		/// data that might still be in transit. What constitutes a partially filled pending receive request is a transport-specific matter.
		/// In the case of TCP, this refers to the case of incoming TCP segments being placed into the receive request data buffer where
		/// none of the TCP segments indicated a PUSH bit value of 1. In this case, TCP may hold the partially filled receive request a
		/// little longer to allow the remainder of the data to arrive with a TCP segment that has the PUSH bit set to 1. This flag tells
		/// TCP not to hold the receive request but to complete it immediately. Using this flag for large block transfers is not recommended
		/// since processing partial blocks is often not optimal. This flag is useful only for cases where receiving and processing the
		/// partial data immediately helps decrease processing latency. This flag is a hint rather than an actual guarantee. This flag is
		/// supported on Windows 8.1, Windows Server 2012 R2, and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_WAITALL</term>
		/// <term>
		/// The receive request will complete only when one of the following events occurs: Be aware that if the underlying transport
		/// provider does not support MSG_WAITALL, or if the socket is in a non-blocking mode, then this call will fail with WSAEOPNOTSUPP.
		/// Also, if MSG_WAITALL is specified along with MSG_OOB, MSG_PEEK, or MSG_PARTIAL, then this call will fail with WSAEOPNOTSUPP.
		/// This flag is not supported on datagram sockets or message-oriented sockets.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For message-oriented sockets, the <c>MSG_PARTIAL</c> bit is set in the lpFlags parameter if a partial message is received. If a
		/// complete message is received, <c>MSG_PARTIAL</c> is cleared in lpFlags. In the case of delayed completion, the value pointed to
		/// by lpFlags is not updated. When completion has been indicated, the application should call WSAGetOverlappedResult and examine
		/// the flags indicated by the lpdwFlags parameter.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSARecv</c> with the lpOverlapped parameter set to NULL, Winsock may
		/// need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which can
		/// be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call
		/// inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must
		/// never be attempted by Winsock clients.
		/// </para>
		/// <para>Overlapped Socket I/O</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSARecv</c> returns a value of zero and the lpNumberOfBytesRecvd parameter
		/// is updated with the number of bytes received and the flag bits indicated by the lpFlags parameter are also updated. If the
		/// overlapped operation is successfully initiated and will complete later, <c>WSARecv</c> returns <c>SOCKET_ERROR</c> and indicates
		/// error code WSA_IO_PENDING. In this case, lpNumberOfBytesRecvd and lpFlags are not updated. When the overlapped operation
		/// completes, the amount of data transferred is indicated either through the cbTransferred parameter in the completion routine (if
		/// specified), or through the lpcbTransfer parameter in WSAGetOverlappedResult. Flag values are obtained by examining the lpdwFlags
		/// parameter of <c>WSAGetOverlappedResult</c>.
		/// </para>
		/// <para>
		/// The <c>WSARecv</c> function using overlapped I/O can be called from within the completion routine of a previous <c>WSARecv</c>,
		/// WSARecvFrom, WSASend or WSASendTo function. For a given socket, I/O completion routines will not be nested. This permits
		/// time-sensitive data transmissions to occur entirely within a preemptive context.
		/// </para>
		/// <para>
		/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are
		/// simultaneously outstanding, each must reference a separate WSAOVERLAPPED structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use WSAWaitForMultipleEvents or
		/// WSAGetOverlappedResult to wait or poll on the event object.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// WSAGetOverlappedResult for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case the usage of the hEvent parameter is undefined, and attempting to
		/// wait on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>
		/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine
		/// will not be invoked until the thread is in an alertable wait state such as can occur when the function WSAWaitForMultipleEvents
		/// with the fAlertable parameter set to <c>TRUE</c> is invoked.
		/// </para>
		/// <para>The prototype of the completion routine is as follows:</para>
		/// <para>
		/// CompletionRoutine is a placeholder for an application-defined or library-defined function name. The dwError specifies the
		/// completion status for the overlapped operation as indicated by lpOverlapped. The cbTransferred parameter specifies the number of
		/// bytes received. The dwFlags parameter contains information that would have appeared in lpFlags if the receive operation had
		/// completed immediately. This function does not return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for this socket. When using
		/// WSAWaitForMultipleEvents, all waiting completion routines are called before the alertable thread's wait is satisfied with a
		/// return code of <c>WSA_IO_COMPLETION</c>. The completion routines can be called in any order, not necessarily in the same order
		/// the overlapped operations are completed. However, the posted buffers are guaranteed to be filled in the same order in which they
		/// are specified.
		/// </para>
		/// <para>
		/// If you are using I/O completion ports, be aware that the order of calls made to <c>WSARecv</c> is also the order in which the
		/// buffers are populated. <c>WSARecv</c> should not be called on the same socket simultaneously from different threads, because it
		/// can result in an unpredictable buffer order.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example shows how to use the <c>WSARecv</c> function in overlapped I/O mode.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsarecv int WSAAPI WSARecv( SOCKET s, LPWSABUF lpBuffers,
		// DWORD dwBufferCount, LPDWORD lpNumberOfBytesRecvd, LPDWORD lpFlags, LPWSAOVERLAPPED lpOverlapped,
		// LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "bfe66e11-e9a7-4321-ad55-3141113e9a03")]
		public static extern int WSARecv(SOCKET s, [In] IntPtr lpBuffers, uint dwBufferCount, out uint lpNumberOfBytesRecvd, ref MsgFlags lpFlags, [In, Out, Optional] IntPtr lpOverlapped,
			[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/// <summary>
		/// The <c>WSARecvDisconnect</c> function terminates reception on a socket, and retrieves the disconnect data if the socket is
		/// connection oriented.
		/// </summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="lpInboundDisconnectData">A pointer to the incoming disconnect data.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSARecvDisconnect</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error
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
		/// <term>WSAEFAULT</term>
		/// <term>The buffer referenced by the parameter lpInboundDisconnectData is too small.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOPROTOOPT</term>
		/// <term>
		/// The disconnect data is not supported by the indicated protocol family. Note that implementations of TCP/IP that do not support
		/// disconnect data are not required to return the WSAENOPROTOOPT error code. See the remarks section for information about the
		/// Microsoft implementation of TCP/IP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSARecvDisconnect</c> function is used on connection-oriented sockets to disable reception and retrieve any incoming
		/// disconnect data from the remote party. This is equivalent to a shutdown (SD_RECEIVE), except that <c>WSARecvDisconnect</c> also
		/// allows receipt of disconnect data (in protocols that support it).
		/// </para>
		/// <para>
		/// After this function has been successfully issued, subsequent receives on the socket will be disallowed. Calling
		/// <c>WSARecvDisconnect</c> has no effect on the lower protocol layers. For TCP sockets, if there is still data queued on the
		/// socket waiting to be received, or data arrives subsequently, the connection is reset, since the data cannot be delivered to the
		/// user. For UDP, incoming datagrams are accepted and queued. In no case will an ICMP error packet be generated.
		/// </para>
		/// <para>
		/// <c>Note</c> The native implementation of TCP/IP on Windows does not support disconnect data. Disconnect data is only supported
		/// with Windows Sockets providers that have the XP1_DISCONNECT_DATA flag in their WSAPROTOCOL_INFO structure. Use the
		/// WSAEnumProtocols function to obtain <c>WSAPROTOCOL_INFO</c> structures for all installed providers.
		/// </para>
		/// <para>
		/// To successfully receive incoming disconnect data, an application must use other mechanisms to determine that the circuit has
		/// been closed. For example, an application needs to receive an FD_CLOSE notification, to receive a zero return value, or to
		/// receive a WSAEDISCON or WSAECONNRESET error code from recv/WSARecv.
		/// </para>
		/// <para>
		/// The <c>WSARecvDisconnect</c> function does not close the socket, and resources attached to the socket will not be freed until
		/// closesocket is invoked.
		/// </para>
		/// <para>The <c>WSARecvDisconnect</c> function does not block regardless of the SO_LINGER setting on the socket.</para>
		/// <para>
		/// An application should not rely on being able to reuse a socket after it has been disconnected using <c>WSARecvDisconnect</c>. In
		/// particular, a Windows Sockets provider is not required to support the use of connect or WSAConnect on such a socket.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSARecvDisconnect</c>, Winsock may need to wait for a network event
		/// before the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsarecvdisconnect int WSAAPI WSARecvDisconnect( SOCKET s,
		// LPWSABUF lpInboundDisconnectData );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "33e0fb8e-3ece-427f-b3ef-43a0f5cf0cc8")]
		public static extern int WSARecvDisconnect(SOCKET s, [In, Out, Optional] IntPtr lpInboundDisconnectData);

		/// <summary>The <c>WSARecvFrom</c> function receives a datagram and stores the source address.</summary>
		/// <param name="s">A descriptor identifying a socket.</param>
		/// <param name="lpBuffers">
		/// A pointer to an array of WSABUF structures. Each <c>WSABUF</c> structure contains a pointer to a buffer and the length of the buffer.
		/// </param>
		/// <param name="dwBufferCount">The number of WSABUF structures in the lpBuffers array.</param>
		/// <param name="lpNumberOfBytesRecvd">
		/// <para>A pointer to the number of bytes received by this call if the <c>WSARecvFrom</c> operation completes immediately.</para>
		/// <para>
		/// Use <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> to avoid potentially erroneous results. This
		/// parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpFlags">A pointer to flags used to modify the behavior of the <c>WSARecvFrom</c> function call. See remarks below.</param>
		/// <param name="lpFrom">
		/// An optional pointer to a buffer that will hold the source address upon the completion of the overlapped operation.
		/// </param>
		/// <param name="lpFromlen">A pointer to the size, in bytes, of the "from" buffer required only if lpFrom is specified.</param>
		/// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure (ignored for nonoverlapped sockets).</param>
		/// <param name="lpCompletionRoutine">
		/// A pointer to the completion routine called when the <c>WSARecvFrom</c> operation has been completed (ignored for nonoverlapped sockets).
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs and the receive operation has completed immediately, <c>WSARecvFrom</c> returns zero. In this case, the
		/// completion routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a
		/// value of <c>SOCKET_ERROR</c> is returned, and a specific error code can be retrieved by calling WSAGetLastError. The error code
		/// <c>WSA_IO_PENDING</c> indicates that the overlapped operation has been successfully initiated and that completion will be
		/// indicated at a later time. Any other error code indicates that the overlapped operation was not successfully initiated and no
		/// completion indication will occur.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>
		/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket as
		/// it is no longer usable. For a UPD datagram socket, this error would indicate that a previous send operation resulted in an ICMP
		/// "Port Unreachable" message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpBuffers, lpFlags, lpFrom, lpNumberOfBytesRecvd, lpFromlen, lpOverlapped, or lpCompletionRoutine parameter is not totally
		/// contained in a valid part of the user address space: the lpFrom buffer was too small to accommodate the peer address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket has not been bound (with bind, for example).</term>
		/// </item>
		/// <item>
		/// <term>WSAEMSGSIZE</term>
		/// <term>
		/// The message was too large for the specified buffer and (for unreliable protocols only) any trailing portion of the message that
		/// did not fit into the buffer has been discarded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETRESET</term>
		/// <term>For a datagram socket, this error indicates that the time to live has expired.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// Windows NT: Overlapped sockets: There are too many outstanding overlapped I/O requests. Nonoverlapped sockets: The socket is
		/// marked as nonblocking and the receive operation cannot be completed immediately.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated later.</term>
		/// </item>
		/// <item>
		/// <term>WSA_OPERATION_ABORTED</term>
		/// <term>The overlapped operation has been canceled due to the closure of the socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSARecvFrom</c> function provides functionality over and above the standard recvfrom function in three important areas:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>It can be used in conjunction with overlapped sockets to perform overlapped receive operations.</term>
		/// </item>
		/// <item>
		/// <term>It allows multiple receive buffers to be specified making it applicable to the scatter/gather type of I/O.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The lpFlags parameter is both an input and an output parameter, allowing applications to sense the output state of the
		/// <c>MSG_PARTIAL</c> flag bit. Be aware that the <c>MSG_PARTIAL</c> flag bit is not supported by all protocols.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>WSARecvFrom</c> function is used primarily on a connectionless socket specified by s. The socket's local address must be
		/// known. For server applications, this is usually done explicitly through bind. Explicit binding is discouraged for client
		/// applications. For client applications using this function the socket can become bound implicitly to a local address through
		/// sendto, WSASendTo, or WSAJoinLeaf.
		/// </para>
		/// <para>
		/// For overlapped sockets, this function is used to post one or more buffers into which incoming data will be placed as it becomes
		/// available on a (possibly connected) socket, after which the application-specified completion indication (invocation of the
		/// completion routine or setting of an event object) occurs. If the operation does not complete immediately, the final completion
		/// status is retrieved through the completion routine or WSAGetOverlappedResult. Also, the values indicated by lpFrom and lpFromlen
		/// are not updated until completion is itself indicated. Applications must not use or disturb these values until they have been
		/// updated, therefore the application must not use automatic (that is, stack-based) variables for these parameters.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para>
		/// If both lpOverlapped and lpCompletionRoutine are <c>NULL</c>, the socket in this function will be treated as a nonoverlapped socket.
		/// </para>
		/// <para>
		/// For nonoverlapped sockets, the blocking semantics are identical to that of the standard WSARecv function and the lpOverlapped
		/// and lpCompletionRoutine parameters are ignored. Any data that has already been received and buffered by the transport will be
		/// copied into the user buffers. For the case of a blocking socket with no data currently having been received and buffered by the
		/// transport, the call will block until data is received.
		/// </para>
		/// <para>
		/// The buffers are filled in the order in which they appear in the array indicated by lpBuffers, and the buffers are packed so that
		/// no holes are created.
		/// </para>
		/// <para>
		/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture the WSABUF
		/// structures before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays pointed to by
		/// the lpBuffers parameter.
		/// </para>
		/// <para>
		/// For connectionless socket types, the address from which the data originated is copied to the buffer indicated by lpFrom. The
		/// value pointed to by lpFromlen is initialized to the size of this buffer, and is modified on completion to indicate the actual
		/// size of the address stored there. As stated previously for overlapped sockets, the lpFrom and lpFromlen parameters are not
		/// updated until after the overlapped I/O has completed. The memory pointed to by these parameters must, therefore, remain
		/// available to the service provider and cannot be allocated on the application stack frame. The lpFrom and lpFromlen parameters
		/// are ignored for connection-oriented sockets.
		/// </para>
		/// <para>For byte stream–style sockets (for example, type SOCK_STREAM), incoming data is placed into the buffers until:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The buffers are filled.</term>
		/// </item>
		/// <item>
		/// <term>The connection is closed.</term>
		/// </item>
		/// <item>
		/// <term>The internally buffered data is exhausted.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Regardless of whether or not the incoming data fills all the buffers, the completion indication occurs for overlapped sockets.
		/// For message-oriented sockets, an incoming message is placed into the buffers up to the total size of the buffers, and the
		/// completion indication occurs for overlapped sockets. If the message is larger than the buffers, the buffers are filled with the
		/// first part of the message. If the <c>MSG_PARTIAL</c> feature is supported by the underlying service provider, the
		/// <c>MSG_PARTIAL</c> flag is set in lpFlags and subsequent receive operation(s) will retrieve the rest of the message. If
		/// <c>MSG_PARTIAL</c> is not supported, but the protocol is reliable, <c>WSARecvFrom</c> generates the error WSAEMSGSIZE and a
		/// subsequent receive operation with a larger buffer can be used to retrieve the entire message. Otherwise, (that is, the protocol
		/// is unreliable and does not support <c>MSG_PARTIAL</c>), the excess data is lost, and <c>WSARecvFrom</c> generates the error WSAEMSGSIZE.
		/// </para>
		/// <para>
		/// The lpFlags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
		/// associated socket. That is, the semantics of this function are determined by the socket options and the lpFlags parameter. The
		/// latter is constructed by using the bitwise OR operator with any of any of the values listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_PEEK</term>
		/// <term>
		/// Previews the incoming data. The data is copied into the buffer, but is not removed from the input queue. This flag is valid only
		/// for nonoverlapped sockets.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_OOB</term>
		/// <term>Processes OOB data.</term>
		/// </item>
		/// <item>
		/// <term>MSG_PARTIAL</term>
		/// <term>
		/// This flag is for message-oriented sockets only. On output, this flag indicates that the data is a portion of the message
		/// transmitted by the sender. Remaining portions of the message will be transmitted in subsequent receive operations. A subsequent
		/// receive operation with MSG_PARTIAL flag cleared indicates the end of the sender's message. As an input parameter, this flag
		/// indicates that the receive operation should complete even if only part of a message has been received by the service provider.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For message-oriented sockets, the <c>MSG_PARTIAL</c> bit is set in the lpFlags parameter if a partial message is received. If a
		/// complete message is received, <c>MSG_PARTIAL</c> is cleared in lpFlags. In the case of delayed completion, the value pointed to
		/// by lpFlags is not updated. When completion has been indicated the application should call WSAGetOverlappedResult and examine the
		/// flags pointed to by the lpdwFlags parameter.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSARecvFrom</c> with the lpOverlapped parameter set to NULL, Winsock
		/// may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which
		/// can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call
		/// inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must
		/// never be attempted by Winsock clients.
		/// </para>
		/// <para>Overlapped Socket I/O</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSARecvFrom</c> returns a value of zero and the lpNumberOfBytesRecvd
		/// parameter is updated with the number of bytes received and the flag bits pointed by the lpFlags parameter are also updated. If
		/// the overlapped operation is successfully initiated and will complete later, <c>WSARecvFrom</c> returns <c>SOCKET_ERROR</c> and
		/// indicates error code <c>WSA_IO_PENDING</c>. In this case, lpNumberOfBytesRecvd and lpFlags is not updated. When the overlapped
		/// operation completes the amount of data transferred is indicated either through the cbTransferred parameter in the completion
		/// routine (if specified), or through the lpcbTransfer parameter in WSAGetOverlappedResult. Flag values are obtained either through
		/// the dwFlags parameter of the completion routine, or by examining the lpdwFlags parameter of <c>WSAGetOverlappedResult</c>.
		/// </para>
		/// <para>
		/// The <c>WSARecvFrom</c> function can be called from within the completion routine of a previous WSARecv, <c>WSARecvFrom</c>,
		/// WSASend, or WSASendTo function. For a given socket, I/O completion routines will not be nested. This permits time-sensitive data
		/// transmissions to occur entirely within a preemptive context.
		/// </para>
		/// <para>
		/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are
		/// simultaneously outstanding, each must reference a separate WSAOVERLAPPED structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use WSAWaitForMultipleEvents or
		/// WSAGetOverlappedResult to wait or poll on the event object.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// WSAGetOverlappedResult for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case the usage of the hEvent parameter is undefined, and attempting to
		/// wait on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>
		/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine
		/// will not be invoked until the thread is in an alertable wait state such as can occur when the function WSAWaitForMultipleEvents
		/// with the fAlertable parameter set to <c>TRUE</c> is invoked.
		/// </para>
		/// <para>
		/// The transport providers allow an application to invoke send and receive operations from within the context of the socket I/O
		/// completion routine, and guarantee that, for a given socket, I/O completion routines will not be nested. This permits
		/// time-sensitive data transmissions to occur entirely within a preemptive context.
		/// </para>
		/// <para>The prototype of the completion routine is as follows.</para>
		/// <para>
		/// The <c>CompletionRoutine</c> is a placeholder for an application-defined or library-defined function name. The dwError specifies
		/// the completion status for the overlapped operation as indicated by lpOverlapped. The cbTransferred specifies the number of bytes
		/// received. The dwFlags parameter contains information that would have appeared in lpFlags if the receive operation had completed
		/// immediately. This function does not return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for this socket. When using
		/// WSAWaitForMultipleEvents, all waiting completion routines are called before the alertable thread's wait is satisfied with a
		/// return code of WSA_IO_COMPLETION. The completion routines can be called in any order, not necessarily in the same order the
		/// overlapped operations are completed. However, the posted buffers are guaranteed to be filled in the same order they are specified.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>WSARecvFrom</c> function.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsarecvfrom int WSAAPI WSARecvFrom( SOCKET s, LPWSABUF
		// lpBuffers, DWORD dwBufferCount, LPDWORD lpNumberOfBytesRecvd, LPDWORD lpFlags, sockaddr *lpFrom, LPINT lpFromlen, LPWSAOVERLAPPED
		// lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "8617dbb8-0e4e-4cd3-9597-5d20de6778f6")]
		public static extern int WSARecvFrom(SOCKET s, [In, Out, Optional, MarshalAs(UnmanagedType.LPArray)] WSABUF[] lpBuffers, uint dwBufferCount, out uint lpNumberOfBytesRecvd, ref MsgFlags lpFlags,
			[Out] SOCKADDR lpFrom, ref int lpFromlen, [In, Out, Optional] IntPtr lpOverlapped, [In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/// <summary>The <c>WSARemoveServiceClass</c> function permanently removes the service class schema from the registry.</summary>
		/// <param name="lpServiceClassId">Pointer to the GUID for the service class you want to remove.</param>
		/// <returns>
		/// <para>
		/// The return value is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is returned, and a specific error
		/// number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSATYPE_NOT_FOUND</term>
		/// <term>The specified class was not found.</term>
		/// </item>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The calling routine does not have sufficient privileges to remove the Service.</term>
		/// </item>
		/// <item>
		/// <term>WSAETOOMANYREFS</term>
		/// <term>There are service instances that still reference the class. Removal of this class is not possible at this time.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The specified GUID was not valid.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaremoveserviceclass INT WSAAPI WSARemoveServiceClass(
		// LPGUID lpServiceClassId );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "7d72f727-cca9-4a07-beb4-d64f23c1f0c1")]
		public static extern int WSARemoveServiceClass(in Guid lpServiceClassId);

		/// <summary>The <c>WSAResetEvent</c> function resets the state of the specified event object to nonsignaled.</summary>
		/// <param name="hEvent">A handle that identifies an open event object handle.</param>
		/// <returns>
		/// <para>
		/// If the <c>WSAResetEvent</c> function succeeds, the return value is <c>TRUE</c>. If the function fails, the return value is
		/// <c>FALSE</c>. To get extended error information, call WSAGetLastError.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The hEvent parameter is not a valid event object handle.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>WSAResetEvent</c> function is used to set the state of the event object to nonsignaled.</para>
		/// <para>
		/// The proper way to reset the state of an event object used with the WSAEventSelect function is to pass the handle of the event
		/// object to the WSAEnumNetworkEvents function in the hEventObject parameter. This will reset the event object and adjust the
		/// status of active FD events on the socket in an atomic fashion.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsaresetevent BOOL WSAAPI WSAResetEvent( WSAEVENT hEvent );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "99a8b0f3-977f-44cd-a224-0819d7513c90")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSAResetEvent(WSAEVENT hEvent);

		/// <summary>The <c>WSASend</c> function sends data on a connected socket.</summary>
		/// <param name="s">A descriptor that identifies a connected socket.</param>
		/// <param name="lpBuffers">
		/// A pointer to an array of WSABUF structures. Each <c>WSABUF</c> structure contains a pointer to a buffer and the length, in
		/// bytes, of the buffer. For a Winsock application, once the <c>WSASend</c> function is called, the system owns these buffers and
		/// the application may not access them. This array must remain valid for the duration of the send operation.
		/// </param>
		/// <param name="dwBufferCount">The number of WSABUF structures in the lpBuffers array.</param>
		/// <param name="lpNumberOfBytesSent">
		/// <para>A pointer to the number, in bytes, sent by this call if the I/O operation completes immediately.</para>
		/// <para>
		/// Use <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> to avoid potentially erroneous results. This
		/// parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// The flags used to modify the behavior of the <c>WSASend</c> function call. For more information, see Using dwFlags in the
		/// Remarks section.
		/// </param>
		/// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for nonoverlapped sockets.</param>
		/// <param name="lpCompletionRoutine">
		/// A pointer to the completion routine called when the send operation has been completed. This parameter is ignored for
		/// nonoverlapped sockets.
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs and the send operation has completed immediately, <c>WSASend</c> returns zero. In this case, the completion
		/// routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a value of
		/// <c>SOCKET_ERROR</c> is returned, and a specific error code can be retrieved by calling WSAGetLastError. The error code
		/// WSA_IO_PENDING indicates that the overlapped operation has been successfully initiated and that completion will be indicated at
		/// a later time. Any other error code indicates that the overlapped operation was not successfully initiated and no completion
		/// indication will occur.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAECONNABORTED</term>
		/// <term>The virtual circuit was terminated due to a time-out or other failure.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>
		/// For a stream socket, the virtual circuit was reset by the remote side. The application should close the socket as it is no
		/// longer usable. For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port
		/// Unreachable" message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpBuffers, lpNumberOfBytesSent, lpOverlapped, lpCompletionRoutine parameter is not totally contained in a valid part of the
		/// user address space.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket has not been bound with bind or the socket is not created with the overlapped flag.</term>
		/// </item>
		/// <item>
		/// <term>WSAEMSGSIZE</term>
		/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETRESET</term>
		/// <term>
		/// For a stream socket, the connection has been broken due to keep-alive activity detecting a failure while the operation was in
		/// progress. For a datagram socket, this error indicates that the time to live has expired.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>The Windows Sockets provider reports a buffer deadlock.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// MSG_OOB was specified, but the socket is not stream-style such as type SOCK_STREAM, OOB data is not supported in the
		/// communication domain associated with this socket, MSG_PARTIAL is not supported, or the socket is unidirectional and supports
		/// only receive operations.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAESHUTDOWN</term>
		/// <term>
		/// The socket has been shut down; it is not possible to WSASend on a socket after shutdown has been invoked with how set to SD_SEND
		/// or SD_BOTH.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// Windows NT: Overlapped sockets: There are too many outstanding overlapped I/O requests. Nonoverlapped sockets: The socket is
		/// marked as nonblocking and the send operation cannot be completed immediately.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term>WSA_OPERATION_ABORTED</term>
		/// <term>
		/// The overlapped operation has been canceled due to the closure of the socket, the execution of the "SIO_FLUSH" command in
		/// WSAIoctl, or the thread that initiated the overlapped request exited before the operation completed. For more information, see
		/// the Remarks section.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>WSASend</c> function provides functionality over and above the standard send function in two important areas:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>It can be used in conjunction with overlapped sockets to perform overlapped send operations.</term>
		/// </item>
		/// <item>
		/// <term>It allows multiple send buffers to be specified making it applicable to the scatter/gather type of I/O.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>WSASend</c> function is used to write outgoing data from one or more buffers on a connection-oriented socket specified by
		/// s. It can also be used, however, on connectionless sockets that have a stipulated default peer address established through the
		/// connect or WSAConnect function.
		/// </para>
		/// <para>
		/// A socket created by the socket function will have the overlapped attribute as the default. A socket created by the WSASocket
		/// function with the dwFlags parameter passed to <c>WSASocket</c> with the <c>WSA_FLAG_OVERLAPPED</c> bit set will have the
		/// overlapped attribute. For sockets with the overlapped attribute, <c>WSASend</c> uses overlapped I/O unless both the lpOverlapped
		/// and lpCompletionRoutine parameters are <c>NULL</c>. In that case, the socket is treated as a non-overlapped socket. A completion
		/// indication will occur, invoking the completion of a routine or setting of an event object, when the buffer(s) have been consumed
		/// by the transport. If the operation does not complete immediately, the final completion status is retrieved through the
		/// completion routine or WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// If both lpOverlapped and lpCompletionRoutine are <c>NULL</c>, the socket in this function will be treated as a non-overlapped socket.
		/// </para>
		/// <para>
		/// For non-overlapped sockets, the last two parameters (lpOverlapped, lpCompletionRoutine) are ignored and <c>WSASend</c> adopts
		/// the same blocking semantics as send. Data is copied from the buffer(s) into the transport's buffer. If the socket is
		/// non-blocking and stream-oriented, and there is not sufficient space in the transport's buffer, <c>WSASend</c> will return with
		/// only part of the application's buffers having been consumed. Given the same buffer situation and a blocking socket,
		/// <c>WSASend</c> will block until all of the application buffer contents have been consumed.
		/// </para>
		/// <para><c>Note</c> The socket options <c>SO_RCVTIMEO</c> and <c>SO_SNDTIMEO</c> apply only to blocking sockets.</para>
		/// <para>
		/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture the WSABUF
		/// structures before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays pointed to by
		/// the lpBuffers parameter.
		/// </para>
		/// <para>
		/// For message-oriented sockets, do not exceed the maximum message size of the underlying provider, which can be obtained by
		/// getting the value of socket option <c>SO_MAX_MSG_SIZE</c>. If the data is too long to pass atomically through the underlying
		/// protocol the error WSAEMSGSIZE is returned, and no data is transmitted.
		/// </para>
		/// <para><c>Windows Me/98/95:</c> The <c>WSASend</c> function does not support more than 16 buffers.</para>
		/// <para><c>Note</c> The successful completion of a <c>WSASend</c> does not indicate that the data was successfully delivered.</para>
		/// <para>Using dwFlags</para>
		/// <para>
		/// The dwFlags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
		/// associated socket. That is, the semantics of this function are determined by the socket options and the dwFlags parameter. The
		/// latter is constructed by using the bitwise OR operator with any of any of the values listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_DONTROUTE</term>
		/// <term>
		/// Specifies that the data should not be subject to routing. A Windows Sockets service provider can choose to ignore this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_OOB</term>
		/// <term>Send OOB data on a stream-style socket such as SOCK_STREAM only.</term>
		/// </item>
		/// <item>
		/// <term>MSG_PARTIAL</term>
		/// <term>
		/// Specifies that lpBuffers only contains a partial message. Be aware that the error code WSAEOPNOTSUPP will be returned by
		/// transports that do not support partial message transmissions.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSASend</c> with the lpOverlapped parameter set to NULL, Winsock may
		/// need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which can
		/// be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call
		/// inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must
		/// never be attempted by Winsock clients.
		/// </para>
		/// <para>Overlapped Socket I/O</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSASend</c> returns a value of zero and the lpNumberOfBytesSent parameter
		/// is updated with the number of bytes sent. If the overlapped operation is successfully initiated and will complete later,
		/// <c>WSASend</c> returns SOCKET_ERROR and indicates error code WSA_IO_PENDING. In this case, lpNumberOfBytesSent is not updated.
		/// When the overlapped operation completes the amount of data transferred is indicated either through the cbTransferred parameter
		/// in the completion routine (if specified), or through the lpcbTransfer parameter in WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. For more information, see ExitThread.
		/// </para>
		/// <para>
		/// The <c>WSASend</c> function using overlapped I/O can be called from within the completion routine of a previous WSARecv,
		/// WSARecvFrom, <c>WSASend</c>, or WSASendTo function. This enables time-sensitive data transmissions to occur entirely within a
		/// preemptive context.
		/// </para>
		/// <para>
		/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are
		/// simultaneously outstanding, each must reference a separate WSAOVERLAPPED structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use WSAWaitForMultipleEvents or
		/// WSAGetOverlappedResult to wait or poll on the event object.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// WSAGetOverlappedResult for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case the usage of the hEvent parameter is undefined, and attempting to
		/// wait on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>
		/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine
		/// will not be invoked until the thread is in an alertable wait state such as can occur when the function WSAWaitForMultipleEvents
		/// with the fAlertable parameter set to <c>TRUE</c> is invoked.
		/// </para>
		/// <para>
		/// The transport providers allow an application to invoke send and receive operations from within the context of the socket I/O
		/// completion routine, and guarantee that, for a given socket, I/O completion routines will not be nested. This permits
		/// time-sensitive data transmissions to occur entirely within a preemptive context.
		/// </para>
		/// <para>The following C++ code example is a prototype of the completion routine.</para>
		/// <para>
		/// The CompletionRoutine function is a placeholder for an application-defined or library-defined function name. The dwError
		/// parameter specifies the completion status for the overlapped operation as indicated by lpOverlapped. cbTransferred specifies the
		/// number of bytes sent. Currently there are no flag values defined and dwFlags will be zero. This function does not return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for this socket. All waiting completion
		/// routines are called before the alertable thread's wait is satisfied with a return code of <c>WSA_IO_COMPLETION</c>. The
		/// completion routines can be called in any order, not necessarily in the same order the overlapped operations are completed.
		/// However, the posted buffers are guaranteed to be sent in the same order they are specified.
		/// </para>
		/// <para>
		/// The order of calls made to <c>WSASend</c> is also the order in which the buffers are transmitted to the transport layer.
		/// <c>WSASend</c> should not be called on the same stream-oriented socket concurrently from different threads, because some Winsock
		/// providers may split a large send request into multiple transmissions, and this may lead to unintended data interleaving from
		/// multiple concurrent send requests on the same stream-oriented socket.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following code example shows how to use the <c>WSASend</c> function in overlapped I/O mode.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasend int WSAAPI WSASend( SOCKET s, LPWSABUF lpBuffers,
		// DWORD dwBufferCount, LPDWORD lpNumberOfBytesSent, DWORD dwFlags, LPWSAOVERLAPPED lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE
		// lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "764339e6-a1ac-455d-8ebd-ad0fa50dc3b0")]
		public static extern int WSASend(SOCKET s, [In, MarshalAs(UnmanagedType.LPArray)] WSABUF[] lpBuffers, uint dwBufferCount, out uint lpNumberOfBytesSent,
			MsgFlags dwFlags, [In, Out, Optional] IntPtr lpOverlapped, [In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/// <summary>
		/// The <c>WSASendDisconnect</c> function initiates termination of the connection for the socket and sends disconnect data.
		/// </summary>
		/// <param name="s">Descriptor identifying a socket.</param>
		/// <param name="lpOutboundDisconnectData">A pointer to the outgoing disconnect data.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSASendDisconnect</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error
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
		/// <term>WSAENOPROTOOPT</term>
		/// <term>The parameter lpOutboundDisconnectData is not NULL, and the disconnect data is not supported by the service provider.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpOutboundDisconnectData parameter is not completely contained in a valid part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSASendDisconnect</c> function is used on connection-oriented sockets to disable transmission and to initiate termination
		/// of the connection along with the transmission of disconnect data, if any. This is equivalent to a shutdown (SD_SEND), except
		/// that <c>WSASendDisconnect</c> also allows sending disconnect data (in protocols that support it).
		/// </para>
		/// <para>After this function has been successfully issued, subsequent sends are disallowed.</para>
		/// <para>
		/// The lpOutboundDisconnectData parameter, if not <c>NULL</c>, points to a buffer containing the outgoing disconnect data to be
		/// sent to the remote party for retrieval by using WSARecvDisconnect.
		/// </para>
		/// <para>
		/// <c>Note</c> The native implementation of TCP/IP on Windows does not support disconnect data. Disconnect data is only supported
		/// with Windows Sockets providers that have the XP1_DISCONNECT_DATA flag in their WSAPROTOCOL_INFO structure. Use the
		/// WSAEnumProtocols function to obtain <c>WSAPROTOCOL_INFO</c> structures for all installed providers.
		/// </para>
		/// <para>
		/// The <c>WSASendDisconnect</c> function does not close the socket, and resources attached to the socket will not be freed until
		/// closesocket is invoked.
		/// </para>
		/// <para>The <c>WSASendDisconnect</c> function does not block regardless of the SO_LINGER setting on the socket.</para>
		/// <para>
		/// An application should not rely on being able to reuse a socket after calling <c>WSASendDisconnect</c>. In particular, a Windows
		/// Sockets provider is not required to support the use of connect/WSAConnect on such a socket.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSASendDisconnect</c>, Winsock may need to wait for a network event
		/// before the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasenddisconnect int WSAAPI WSASendDisconnect( SOCKET s,
		// LPWSABUF lpOutboundDisconnectData );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "c05fc719-e35a-4194-ac01-a294b19ccce9")]
		public static extern int WSASendDisconnect(SOCKET s, in WSABUF lpOutboundDisconnectData);

		/// <summary>
		/// The <c>WSASendDisconnect</c> function initiates termination of the connection for the socket and sends disconnect data.
		/// </summary>
		/// <param name="s">Descriptor identifying a socket.</param>
		/// <param name="lpOutboundDisconnectData">A pointer to the outgoing disconnect data.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSASendDisconnect</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error
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
		/// <term>WSAENOPROTOOPT</term>
		/// <term>The parameter lpOutboundDisconnectData is not NULL, and the disconnect data is not supported by the service provider.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpOutboundDisconnectData parameter is not completely contained in a valid part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSASendDisconnect</c> function is used on connection-oriented sockets to disable transmission and to initiate termination
		/// of the connection along with the transmission of disconnect data, if any. This is equivalent to a shutdown (SD_SEND), except
		/// that <c>WSASendDisconnect</c> also allows sending disconnect data (in protocols that support it).
		/// </para>
		/// <para>After this function has been successfully issued, subsequent sends are disallowed.</para>
		/// <para>
		/// The lpOutboundDisconnectData parameter, if not <c>NULL</c>, points to a buffer containing the outgoing disconnect data to be
		/// sent to the remote party for retrieval by using WSARecvDisconnect.
		/// </para>
		/// <para>
		/// <c>Note</c> The native implementation of TCP/IP on Windows does not support disconnect data. Disconnect data is only supported
		/// with Windows Sockets providers that have the XP1_DISCONNECT_DATA flag in their WSAPROTOCOL_INFO structure. Use the
		/// WSAEnumProtocols function to obtain <c>WSAPROTOCOL_INFO</c> structures for all installed providers.
		/// </para>
		/// <para>
		/// The <c>WSASendDisconnect</c> function does not close the socket, and resources attached to the socket will not be freed until
		/// closesocket is invoked.
		/// </para>
		/// <para>The <c>WSASendDisconnect</c> function does not block regardless of the SO_LINGER setting on the socket.</para>
		/// <para>
		/// An application should not rely on being able to reuse a socket after calling <c>WSASendDisconnect</c>. In particular, a Windows
		/// Sockets provider is not required to support the use of connect/WSAConnect on such a socket.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSASendDisconnect</c>, Winsock may need to wait for a network event
		/// before the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
		/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
		/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasenddisconnect int WSAAPI WSASendDisconnect( SOCKET s,
		// LPWSABUF lpOutboundDisconnectData );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "c05fc719-e35a-4194-ac01-a294b19ccce9")]
		public static extern int WSASendDisconnect(SOCKET s, [In, Optional] IntPtr lpOutboundDisconnectData);

		/// <summary>The <c>WSASendMsg</c> function sends data and optional control information from connected and unconnected sockets.</summary>
		/// <param name="Handle">A descriptor identifying the socket.</param>
		/// <param name="lpMsg">A WSAMSG structure storing the Posix.1g <c>msghdr</c> structure.</param>
		/// <param name="dwFlags">
		/// The flags used to modify the behavior of the <c>WSASendMsg</c> function call. For more information, see Using dwFlags in the
		/// Remarks section.
		/// </param>
		/// <param name="lpNumberOfBytesSent">
		/// <para>A pointer to the number, in bytes, sent by this call if the I/O operation completes immediately.</para>
		/// <para>
		/// Use <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> to avoid potentially erroneous results. This
		/// parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure. Ignored for non-overlapped sockets.</param>
		/// <param name="lpCompletionRoutine">
		/// A pointer to the completion routine called when the send operation completes. Ignored for non-overlapped sockets.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns zero when successful and immediate completion occurs. When zero is returned, the specified completion routine is called
		/// when the calling thread is in the alertable state.
		/// </para>
		/// <para>
		/// A return value of <c>SOCKET_ERROR</c>, and subsequent call to WSAGetLastError that returns WSA_IO_PENDING, indicates the
		/// overlapped operation has successfully initiated; completion is then indicated through other means, such as through events or
		/// completion ports.
		/// </para>
		/// <para>
		/// Upon failure, returns <c>SOCKET_ERROR</c> and a subsequent call to WSAGetLastError returns a value other than
		/// <c>WSA_IO_PENDING</c>. The following table lists error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The requested address is a broadcast address, but the appropriate flag was not set.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>
		/// For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port Unreachable" message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpMsg, lpNumberOfBytesSent, lpOverlapped, or lpCompletionRoutine parameter is not totally contained in a valid part of the
		/// user address space. This error is also returned if a name member of the WSAMSGstructure pointed to by the lpMsg parameter was a
		/// NULL pointer and the namelen member of the WSAMSGstructure was not set to zero. This error is also returned if a Control.buf
		/// member of the WSAMSGstructure pointed to by the lpMsg parameter was a NULL pointer and the Control.len member of the
		/// WSAMSGstructure was not set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket has not been bound with bind, or the socket was not created with the overlapped flag.</term>
		/// </item>
		/// <item>
		/// <term>WSAEMSGSIZE</term>
		/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETRESET</term>
		/// <term>For a datagram socket, this error indicates that the time to live has expired.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The network is unreachable.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>The Windows Sockets provider reports a buffer deadlock.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAEOPNOTSUPP</term>
		/// <term>
		/// The socket operation is not supported. This error is returned if the dwFlags member of the WSAMSGstructure pointed to by the
		/// lpMsg parameter includes any control flags invalid for WSASendMsg.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAESHUTDOWN</term>
		/// <term>
		/// The socket has been shut down; it is not possible to call the WSASendMsg function on a socket after shutdown has been invoked
		/// with how set to SD_SEND or SD_BOTH.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAETIMEDOUT</term>
		/// <term>
		/// The socket timed out. This error is returned if the socket had a wait timeout specified using the SO_SNDTIMEO socket option and
		/// the timeout was exceeded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// Overlapped sockets: There are too many outstanding overlapped I/O requests. Nonoverlapped sockets: The socket is marked as
		/// nonblocking and the send operation cannot be completed immediately.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term>WSA_OPERATION_ABORTED</term>
		/// <term>
		/// The overlapped operation has been canceled due to the closure of the socket or due to the execution of the SIO_FLUSH command in WSAIoctl.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSASendMsg</c> function can be used in place of the WSASend and WSASendTo functions. The <c>WSASendMsg</c> function can
		/// only be used with datagrams and raw sockets. The socket descriptor in the s parameter must be opened with the socket type set to
		/// <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>.
		/// </para>
		/// <para>
		/// The dwFlags parameter can only contain a combination of the following control flags: <c>MSG_DONTROUTE</c>, <c>MSG_PARTIAL</c>,
		/// and <c>MSG_OOB</c>. The <c>dwFlags</c> member of the WSAMSGstructure pointed to by the lpMsg parameter is ignored on input and
		/// not used on output.
		/// </para>
		/// <para>
		/// <c>Note</c> The function pointer for the <c>WSASendMsg</c> function must be obtained at run time by making a call to the
		/// WSAIoctl function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
		/// <c>WSAIoctl</c> function must contain <c>WSAID_WSASENDMSG</c>, a globally unique identifier (GUID) whose value identifies the
		/// <c>WSASendMsg</c> extension function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
		/// <c>WSASendMsg</c> function. The <c>WSAID_WSASENDMSG</c> GUID is defined in the Mswsock.h header file.
		/// </para>
		/// <para>
		/// Overlapped sockets are created with a WSASocket function call that has the <c>WSA_FLAG_OVERLAPPED</c> flag set. For overlapped
		/// sockets, sending information uses overlapped I/O unless both lpOverlapped and lpCompletionRoutine are <c>NULL</c>; when
		/// lpOverlapped and lpCompletionRoutine are <c>NULL</c>, the socket is treated as a nonoverlapped socket. A completion indication
		/// occurs with overlapped sockets; once the buffer or buffers have been consumed by the transport, a completion routine is
		/// triggered or an event object is set. If the operation does not complete immediately, the final completion status is retrieved
		/// through the completion routine or by calling the WSAGetOverlappedResult function.
		/// </para>
		/// <para>
		/// For nonoverlapped sockets, the lpOverlapped and lpCompletionRoutine parameters are ignored and <c>WSASendMsg</c> adopts the same
		/// blocking semantics as the send function: data is copied from the buffer or buffers into the transport's buffer. If the socket is
		/// nonblocking and stream oriented, and there is insufficient space in the transport's buffer, <c>WSASendMsg</c> returns with only
		/// part of the application's buffers having been consumed. In contrast, this buffer situation on a blocking socket results in
		/// <c>WSASendMsg</c> blocking until all of the application's buffer contents have been consumed.
		/// </para>
		/// <para>
		/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture this
		/// WSABUF structure before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays pointed to
		/// by the <c>lpBuffers</c> member of the WSAMSGstructure pointed to by the lpMsg parameter.
		/// </para>
		/// <para>
		/// For message-oriented sockets, care must be taken not to exceed the maximum message size of the underlying provider, which can be
		/// obtained by getting the value of socket option <c>SO_MAX_MSG_SIZE</c>. If the data is too long to pass atomically through the
		/// underlying protocol, the error <c>WSAEMSGSIZE</c> is returned and no data is transmitted.
		/// </para>
		/// <para>
		/// On an IPv4 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, an application can specific the local IP source address to use
		/// for sending with the <c>WSASendMsg</c> function. One of the control data objects passed in the WSAMSG structure to the
		/// <c>WSASendMsg</c> function may contain an in_pktinfo structure used to specify the local IPv4 source address to use for sending.
		/// </para>
		/// <para>
		/// On an IPv6 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, an application can specific the local IP source address to use
		/// for sending with the <c>WSASendMsg</c> function. One of the control data objects passed in the WSAMSG structure to the
		/// <c>WSASendMsg</c> function may contain an in6_pktinfo structure used to specify the local IPv6 source address to use for sending.
		/// </para>
		/// <para>
		/// For a dual-stack socket when sending datagrams with the <c>WSASendMsg</c> function and an application wants to specify a
		/// specific local IP source address to be used, the method to handle this depends on the destination IP address. When sending to an
		/// IPv4 destination address or an IPv4-mapped IPv6 destination address, one of the control data objects passed in the WSAMSG
		/// structure pointed to by the lpMsg parameter should contain an in_pktinfo structure containing the local IPv4 source address to
		/// use for sending. When sending to an IPv6 destination address that is not a an IPv4-mapped IPv6 address, one of the control data
		/// objects passed in the <c>WSAMSG</c> structure pointed to by the lpMsg parameter should contain an in6_pktinfo structure
		/// containing the local IPv6 source address to use for sending.
		/// </para>
		/// <para><c>Note</c> The <c>SO_SNDTIMEO</c> socket option applies only to blocking sockets.</para>
		/// <para><c>Note</c> The successful completion of a <c>WSASendMsg</c> does not indicate that the data was successfully delivered.</para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSASendMsg</c> with the lpOverlapped parameter set to NULL, Winsock
		/// may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which
		/// can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call
		/// inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must
		/// never be attempted by Winsock clients.
		/// </para>
		/// <para>dwFlags</para>
		/// <para>
		/// The dwFlags input parameter can be used to influence the behavior of the function invocation beyond the options specified for
		/// the associated socket. That is, the semantics of this function are determined by the socket options and the dwFlags parameter.
		/// The latter is constructed by using the bitwise OR operator with any of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_DONTROUTE</term>
		/// <term>
		/// Specifies that the data should not be subject to routing. A Windows Sockets service provider can choose to ignore this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_PARTIAL</term>
		/// <term>
		/// Specifies that lpMsg-&gt;lpBuffers contains only a partial message. Note that the error code WSAEOPNOTSUPP will be returned by
		/// transports that do not support partial message transmissions.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The possible values for dwFlags parameter are defined in the Winsock2.h header file.</para>
		/// <para>On output, the <c>dwFlags</c> member of the WSAMSGstructure pointed to by the lpMsg parameter is not used.</para>
		/// <para>Overlapped Socket I/O</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSASendMsg</c> returns a value of zero and the lpNumberOfBytesSent
		/// parameter is updated with the number of bytes sent. If the overlapped operation is successfully initiated and will complete
		/// later, <c>WSASendMsg</c> returns SOCKET_ERROR and indicates error code WSA_IO_PENDING. In this case, lpNumberOfBytesSent is not
		/// updated. When the overlapped operation completes, the amount of data transferred is indicated either through the cbTransferred
		/// parameter in the completion routine (if specified) or through the lpcbTransfer parameter in WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para>
		/// The <c>WSASendMsg</c> function using overlapped I/O can be called from within the completion routine of a previous , WSARecv,
		/// WSARecvFrom, WSARecvMsg, WSASend, <c>WSASendMsg</c>, or WSASendTo function. This permits time-sensitive data transmissions to
		/// occur entirely within a preemptive context.
		/// </para>
		/// <para>
		/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are
		/// simultaneously outstanding, each must reference a separate WSAOVERLAPPED structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use WSAWaitForMultipleEvents or
		/// WSAGetOverlappedResult to wait or poll on the event object.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// WSAGetOverlappedResult for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case, the usage of the hEvent parameter is undefined, and attempting to
		/// wait on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>
		/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine
		/// will not be invoked until the thread is in an alertable wait state, for example, with WSAWaitForMultipleEvents called with the
		/// fAlertable parameter set to <c>TRUE</c>.
		/// </para>
		/// <para>
		/// The transport providers allow an application to invoke send and receive operations from within the context of the socket I/O
		/// completion routine, and guarantee that, for a given socket, I/O completion routines will not be nested. This permits
		/// time-sensitive data transmissions to occur entirely within a preemptive context.
		/// </para>
		/// <para>The prototype of the completion routine is as follows.</para>
		/// <para>
		/// The <c>CompletionRoutine</c> function is a placeholder for an application-defined or library-defined function name. The dwError
		/// parameter specifies the completion status for the overlapped operation as indicated by the lpOverlapped parameter. The
		/// cbTransferred parameter indicates the number of bytes sent. Currently there are no flag values defined and the dwFlags parameter
		/// will be zero. The <c>CompletionRoutine</c> function does not return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for the socket. All waiting completion
		/// routines are called before the alertable thread's wait is satisfied with a return code of WSA_IO_COMPLETION. The completion
		/// routines can be called in any order, not necessarily in the same order the overlapped operations are completed. However, the
		/// posted buffers are guaranteed to be sent in the same order they are specified.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasendmsg int WSAAPI WSASendMsg( SOCKET Handle, LPWSAMSG
		// lpMsg, DWORD dwFlags, LPDWORD lpNumberOfBytesSent, LPWSAOVERLAPPED lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE
		// lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "3b2ba645-6a70-4ba2-b4a2-5bde0c7f8d08")]
		public static extern int WSASendMsg(SOCKET Handle, in WSAMSG lpMsg, MsgFlags dwFlags, out uint lpNumberOfBytesSent, [In, Out, Optional] IntPtr lpOverlapped,
			[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/// <summary>The <c>WSASendTo</c> function sends data to a specific destination, using overlapped I/O where applicable.</summary>
		/// <param name="s">A descriptor identifying a (possibly connected) socket.</param>
		/// <param name="lpBuffers">
		/// A pointer to an array of WSABUF structures. Each <c>WSABUF</c> structure contains a pointer to a buffer and the length of the
		/// buffer, in bytes. For a Winsock application, once the <c>WSASendTo</c> function is called, the system owns these buffers and the
		/// application may not access them. This array must remain valid for the duration of the send operation.
		/// </param>
		/// <param name="dwBufferCount">The number of WSABUF structures in the lpBuffers array.</param>
		/// <param name="lpNumberOfBytesSent">
		/// <para>A pointer to the number of bytes sent by this call if the I/O operation completes immediately.</para>
		/// <para>
		/// Use <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> to avoid potentially erroneous results. This
		/// parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="dwFlags">The flags used to modify the behavior of the <c>WSASendTo</c> function call.</param>
		/// <param name="lpTo">An optional pointer to the address of the target socket in the SOCKADDR structure.</param>
		/// <param name="iTolen">The size, in bytes, of the address in the lpTo parameter.</param>
		/// <param name="lpOverlapped">A pointer to a WSAOVERLAPPED structure (ignored for nonoverlapped sockets).</param>
		/// <param name="lpCompletionRoutine">
		/// A pointer to the completion routine called when the send operation has been completed (ignored for nonoverlapped sockets).
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs and the send operation has completed immediately, <c>WSASendTo</c> returns zero. In this case, the completion
		/// routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a value of
		/// <c>SOCKET_ERROR</c> is returned, and a specific error code can be retrieved by calling WSAGetLastError. The error code
		/// WSA_IO_PENDING indicates that the overlapped operation has been successfully initiated and that completion will be indicated at
		/// a later time. Any other error code indicates that the overlapped operation was not successfully initiated and no completion
		/// indication will occur.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The requested address is a broadcast address, but the appropriate flag was not set.</term>
		/// </item>
		/// <item>
		/// <term>WSAEADDRNOTAVAIL</term>
		/// <term>The remote address is not a valid address (such as ADDR_ANY).</term>
		/// </item>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>Addresses in the specified family cannot be used with this socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAECONNRESET</term>
		/// <term>
		/// For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port Unreachable" message.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEDESTADDRREQ</term>
		/// <term>A destination address is required.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// The lpBuffers, lpTo, lpOverlapped, lpNumberOfBytesSent, or lpCompletionRoutine parameters are not part of the user address
		/// space, or the lpTo parameter is too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEHOSTUNREACH</term>
		/// <term>A socket operation was attempted to an unreachable host.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINTR</term>
		/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The socket has not been bound with bind, or the socket is not created with the overlapped flag.</term>
		/// </item>
		/// <item>
		/// <term>WSAEMSGSIZE</term>
		/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETDOWN</term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETRESET</term>
		/// <term>For a datagram socket, this error indicates that the time to live has expired.</term>
		/// </item>
		/// <item>
		/// <term>WSAENETUNREACH</term>
		/// <term>The network cannot be reached from this host at this time.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>The Windows Sockets provider reports a buffer deadlock.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTCONN</term>
		/// <term>The socket is not connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// <item>
		/// <term>WSAESHUTDOWN</term>
		/// <term>
		/// The socket has been shut down; it is not possible to WSASendTo on a socket after shutdown has been invoked with how set to
		/// SD_SEND or SD_BOTH.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEWOULDBLOCK</term>
		/// <term>
		/// Windows NT: Overlapped sockets: there are too many outstanding overlapped I/O requests. Nonoverlapped sockets: The socket is
		/// marked as nonblocking and the send operation cannot be completed immediately.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_IO_PENDING</term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term>WSA_OPERATION_ABORTED</term>
		/// <term>
		/// The overlapped operation has been canceled due to the closure of the socket, or the execution of the SIO_FLUSH command in WSAIoctl.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>WSASendTo</c> function provides enhanced features over the standard sendto function in two important areas:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>It can be used in conjunction with overlapped sockets to perform overlapped send operations.</term>
		/// </item>
		/// <item>
		/// <term>It allows multiple send buffers to be specified making it applicable to the scatter/gather type of I/O.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>WSASendTo</c> function is normally used on a connectionless socket specified by s to send a datagram contained in one or
		/// more buffers to a specific peer socket identified by the lpTo parameter. Even if the connectionless socket has been previously
		/// connected using the connect function to a specific address, lpTo overrides the destination address for that particular datagram
		/// only. On a connection-oriented socket, the lpTo and iToLen parameters are ignored; in this case, the <c>WSASendTo</c> is
		/// equivalent to WSASend.
		/// </para>
		/// <para>
		/// For overlapped sockets (created using WSASocket with flag <c>WSA_FLAG_OVERLAPPED</c>) sending data uses overlapped I/O, unless
		/// both lpOverlapped and lpCompletionRoutine are <c>NULL</c> in which case the socket is treated as a nonoverlapped socket. A
		/// completion indication will occur (invoking the completion routine or setting of an event object) when the buffer(s) have been
		/// consumed by the transport. If the operation does not complete immediately, the final completion status is retrieved through the
		/// completion routine or WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// <c>Note</c> If a socket is opened, a setsockopt call is made, and then a sendto call is made, Windows Sockets performs an
		/// implicit bind function call.
		/// </para>
		/// <para>
		/// If both lpOverlapped and lpCompletionRoutine are <c>NULL</c>, the socket in this function will be treated as a nonoverlapped socket.
		/// </para>
		/// <para>
		/// For nonoverlapped sockets, the last two parameters (lpOverlapped, lpCompletionRoutine) are ignored and <c>WSASendTo</c> adopts
		/// the same blocking semantics as send. Data is copied from the buffer(s) into the transport buffer. If the socket is nonblocking
		/// and stream oriented, and there is not sufficient space in the transport's buffer, <c>WSASendTo</c> returns with only part of the
		/// application's buffers having been consumed. Given the same buffer situation and a blocking socket, <c>WSASendTo</c> will block
		/// until all of the application's buffer contents have been consumed.
		/// </para>
		/// <para>
		/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture the WSABUF
		/// structures before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays pointed to by
		/// the lpBuffers parameter.
		/// </para>
		/// <para>
		/// For message-oriented sockets, care must be taken not to exceed the maximum message size of the underlying transport, which can
		/// be obtained by getting the value of socket option <c>SO_MAX_MSG_SIZE</c>. If the data is too long to pass atomically through the
		/// underlying protocol the error WSAEMSGSIZE is returned, and no data is transmitted.
		/// </para>
		/// <para>
		/// If the socket is unbound, unique values are assigned to the local association by the system, and the socket is then marked as bound.
		/// </para>
		/// <para>
		/// If the socket is connected, the getsockname function can be used to determine the local IP address and port associated with the socket.
		/// </para>
		/// <para>
		/// If the socket is not connected, the getsockname function can be used to determine the local port number associated with the
		/// socket but the IP address returned is set to the wildcard address for the given protocol (for example, INADDR_ANY or "0.0.0.0"
		/// for IPv4 and IN6ADDR_ANY_INIT or "::" for IPv6).
		/// </para>
		/// <para>The successful completion of a <c>WSASendTo</c> does not indicate that the data was successfully delivered.</para>
		/// <para>
		/// The dwFlags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
		/// associated socket. That is, the semantics of this function are determined by the socket options and the dwFlags parameter. The
		/// latter is constructed by using the bitwise OR operator with any of any of the values listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_DONTROUTE</term>
		/// <term>
		/// Specifies that the data should not be subject to routing. A Windows Socket service provider may choose to ignore this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MSG_OOB</term>
		/// <term>Send OOB data (stream-style socket such as SOCK_STREAM only).</term>
		/// </item>
		/// <item>
		/// <term>MSG_PARTIAL</term>
		/// <term>
		/// Specifies that lpBuffers only contains a partial message. Be aware that the error code WSAEOPNOTSUPP will be returned by
		/// transports that do not support partial message transmissions.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSASendTo</c> with the lpOverlapped parameter set to <c>NULL</c>,
		/// Winsock may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation,
		/// which can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock
		/// call inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and
		/// must never be attempted by Winsock clients.
		/// </para>
		/// <para>Overlapped Socket I/O</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSASendTo</c> returns a value of zero and the lpNumberOfBytesSent parameter
		/// is updated with the number of bytes sent. If the overlapped operation is successfully initiated and will complete later,
		/// <c>WSASendTo</c> returns <c>SOCKET_ERROR</c> and indicates error code WSA_IO_PENDING. In this case, lpNumberOfBytesSent is not
		/// updated. When the overlapped operation completes the amount of data transferred is indicated either through the cbTransferred
		/// parameter in the completion routine (if specified), or through the lpcbTransfer parameter in WSAGetOverlappedResult.
		/// </para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
		/// </para>
		/// <para>
		/// The <c>WSASendTo</c> function using overlapped I/O can be called from within the completion routine of a previous WSARecv,
		/// WSARecvFrom, WSASend, or <c>WSASendTo</c> function. This permits time-sensitive data transmissions to occur entirely within a
		/// preemptive context.
		/// </para>
		/// <para>
		/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are
		/// simultaneously outstanding, each must reference a separate WSAOVERLAPPED structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use WSAWaitForMultipleEvents or
		/// WSAGetOverlappedResult to wait or poll on the event object.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// WSAGetOverlappedResult for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case the usage of the hEvent parameter is undefined, and attempting to
		/// wait on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>
		/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine
		/// will not be invoked until the thread is in an alertable wait state such as can occur when the function WSAWaitForMultipleEvents
		/// with the fAlertable parameter set to <c>TRUE</c> is invoked.
		/// </para>
		/// <para>
		/// Transport providers allow an application to invoke send and receive operations from within the context of the socket I/O
		/// completion routine, and guarantee that, for a given socket, I/O completion routines will not be nested. This permits
		/// time-sensitive data transmissions to occur entirely within a preemptive context.
		/// </para>
		/// <para>The prototype of the completion routine is as follows.</para>
		/// <para>
		/// The CompletionRoutine function is a placeholder for an application-defined or library-defined function name. The dwError
		/// parameter specifies the completion status for the overlapped operation as indicated by lpOverlapped. The cbTransferred parameter
		/// specifies the number of bytes sent. Currently there are no flag values defined and dwFlags will be zero. This function does not
		/// return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for this socket. All waiting completion
		/// routines are called before the alertable thread's wait is satisfied with a return code of WSA_IO_COMPLETION. The completion
		/// routines can be called in any order, not necessarily in the same order in which the overlapped operations are completed.
		/// However, the posted buffers are guaranteed to be sent in the same order they are specified.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>WSASendTo</c> function using an event object.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasendto int WSAAPI WSASendTo( SOCKET s, LPWSABUF
		// lpBuffers, DWORD dwBufferCount, LPDWORD lpNumberOfBytesSent, DWORD dwFlags, const sockaddr *lpTo, int iTolen, LPWSAOVERLAPPED
		// lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "e3a11522-871c-4d6b-a2e6-ca91ffc2b698")]
		public static extern int WSASendTo(SOCKET s, [In, MarshalAs(UnmanagedType.LPArray)] WSABUF[] lpBuffers, uint dwBufferCount, out uint lpNumberOfBytesSent,
			MsgFlags dwFlags, [In, Optional] SOCKADDR lpTo, int iTolen, [In, Out, Optional] IntPtr lpOverlapped,
			[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/// <summary>The <c>WSASetEvent</c> function sets the state of the specified event object to signaled.</summary>
		/// <param name="hEvent">Handle that identifies an open event object.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To get extended error information, call WSAGetLastError.</para>
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
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>The hEvent parameter is not a valid event object handle.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>WSASetEvent</c> function sets the state of the event object to be signaled.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasetevent BOOL WSAAPI WSASetEvent( WSAEVENT hEvent );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "8a3f41fe-77da-4e4e-975d-00eec7c11446")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WSASetEvent(WSAEVENT hEvent);

		/// <summary>The <c>WSASetLastError</c> function sets the error code that can be retrieved through the WSAGetLastError function.</summary>
		/// <param name="iError">Integer that specifies the error code to be returned by a subsequent WSAGetLastError call.</param>
		/// <returns>
		/// <para>This function generates no return values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSASetLastError</c> function allows an application to set the error code to be returned by a subsequent WSAGetLastError
		/// call for the current thread. Note that any subsequent Windows Sockets routine called by the application will override the error
		/// code as set by this routine.
		/// </para>
		/// <para>
		/// The error code set by <c>WSASetLastError</c> is different from the error code reset by calling the function getsockopt with SO_ERROR.
		/// </para>
		/// <para>The Windows Sockets error codes used by this function are listed under Windows Sockets Error Codes.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-wsasetlasterror void WSASetLastError( int iError );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock.h", MSDNShortId = "596155ee-3dcc-4ae3-97ab-0653e019cbee")]
		public static extern void WSASetLastError(int iError);

		/// <summary>The <c>WSASetService</c> function registers or removes from the registry a service instance within one or more namespaces.</summary>
		/// <param name="lpqsRegInfo">A pointer to the service information for registration or deregistration.</param>
		/// <param name="essoperation">
		/// <para>
		/// A value that determines that operation requested. This parameter can be one of the values from the WSAESETSERVICEOP enumeration
		/// type defined in the Winsock2.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RNRSERVICE_REGISTER</term>
		/// <term>
		/// Register the service. For SAP, this means sending out a periodic broadcast. This is an NOP for the DNS namespace. For persistent
		/// data stores, this means updating the address information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_DEREGISTER</term>
		/// <term>
		/// Remove the service from the registry. For SAP, this means stop sending out the periodic broadcast. This is an NOP for the DNS
		/// namespace. For persistent data stores this means deleting address information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_DELETE</term>
		/// <term>
		/// Delete the service from dynamic name and persistent spaces. For services represented by multiple CSADDR_INFO structures (using
		/// the SERVICE_MULTIPLE flag), only the specified address will be deleted, and this must match exactly the corresponding
		/// CSADDR_INFO structure that was specified when the service was registered.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwControlFlags">
		/// <para>
		/// Service install flags value that further controls the operation performed of the <c>WSASetService</c> function. The possible
		/// values for this parameter are defined in the Winsock2.h header file.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_MULTIPLE</term>
		/// <term>
		/// Controls scope of operation. When this flag is not set, service addresses are managed as a group. A register or removal from the
		/// registry invalidates all existing addresses before adding the given address set. When set, the action is only performed on the
		/// given address set. A register does not invalidate existing addresses and a removal from the registry only invalidates the given
		/// set of addresses.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// The return value for <c>WSASetService</c> is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is
		/// returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEACCES</term>
		/// <term>The calling routine does not have sufficient privileges to install the Service.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>One or more required parameters were invalid or missing.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The Ws2_32.dll has not been initialized. The application must first call WSAStartup before calling any Windows Sockets functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSASetService</c> function can be used to affect a specific namespace provider, all providers associated with a specific
		/// namespace, or all providers across all namespaces.
		/// </para>
		/// <para>
		/// The available values for essOperation and dwControlFlags combine to control operation of the <c>WSASetService</c> function as
		/// shown in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Operation</term>
		/// <term>Flags</term>
		/// <term>Service already exists</term>
		/// <term>Service does not exist</term>
		/// </listheader>
		/// <item>
		/// <term>RNRSERVICE_REGISTER</term>
		/// <term>None</term>
		/// <term>Overwrites the object. Uses only addresses specified. The object is REGISTERED.</term>
		/// <term>Creates a new object. Uses only addresses specified. Object is REGISTERED.</term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_REGISTER</term>
		/// <term>SERVICE_MULTIPLE</term>
		/// <term>Updates the object. Adds new addresses to the existing set. The object is REGISTERED.</term>
		/// <term>Creates a new object. Uses all addresses specified. Object is REGISTERED.</term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_DEREGISTER</term>
		/// <term>None</term>
		/// <term>Removes all addresses, but does not remove the object from the namespace. The object is removed from the registry.</term>
		/// <term>WSASERVICE_NOT_FOUND</term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_DEREGISTER</term>
		/// <term>SERVICE_MULTIPLE</term>
		/// <term>
		/// Updates the object. Removes only addresses that are specified. Only marks the object as DEREGISTERED if no addresses are
		/// present. Does not remove the object from the namespace.
		/// </term>
		/// <term>WSASERVICE_NOT_FOUND</term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_DELETE</term>
		/// <term>None</term>
		/// <term>Removes the object from the namespace.</term>
		/// <term>WSASERVICE_NOT_FOUND</term>
		/// </item>
		/// <item>
		/// <term>RNRSERVICE_DELETE</term>
		/// <term>SERVICE_MULTIPLE</term>
		/// <term>Removes only addresses that are specified. Only removes object from the namespace if no addresses remain.</term>
		/// <term>WSASERVICE_NOT_FOUND</term>
		/// </item>
		/// </list>
		/// <para>
		/// Publishing services to directories, such as Active Directory Services, is restricted based on access control lists (ACLs). For
		/// more information, see Security Issues for Service Publication.
		/// </para>
		/// <para>
		/// When the dwControlFlags parameter is set to <c>SERVICE_MULTIPLE</c>, an application can manage its addresses independently. This
		/// is useful when the application wants to manage its protocols individually or when the service resides on more than one computer.
		/// For instance, when a service uses more than one protocol, it may find that one listening socket aborts but the other sockets
		/// remain operational. In this case, the service could remove the aborted address from the registry without affecting the other addresses.
		/// </para>
		/// <para>
		/// When the dwControlFlags parameter is set to <c>SERVICE_MULTIPLE</c>, an application must not let stale addresses remain in the
		/// object. This can happen if the application aborts without issuing a DEREGISTER request. When a service registers, it should
		/// store its addresses. On its next invocation, the service should explicitly remove these old stale addresses from the registry
		/// before registering new addresses.
		/// </para>
		/// <para>
		/// <c>Note</c> If ANSI character strings are used, there is a chance that the WSAQUERYSET data in lpqsRegInfo may not contain any
		/// results after this function returns. This is because the ANSI version of this method, <c>WSASetServiceA</c>, converts the ANSI
		/// data in <c>WSAQUERYSET</c> to Unicode internally, but does not convert the results back to ANSI. This primarily impacts
		/// transports that return a "service record handle" used to uniquely identify a record. To work around this issue, applications
		/// should use Unicode string data in <c>WSAQUERYSET</c> when calling this function.
		/// </para>
		/// <para>Service Properties</para>
		/// <para>
		/// The following table describes how service property data is represented in a WSAQUERYSET structure. Fields labeled as (Optional)
		/// can contain a null pointer.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>WSAQUERYSET member</term>
		/// <term>Service property description</term>
		/// </listheader>
		/// <item>
		/// <term>dwSize</term>
		/// <term>Must be set to sizeof (WSAQUERYSET). This is a versioning mechanism.</term>
		/// </item>
		/// <item>
		/// <term>dwOutputFlags</term>
		/// <term>Not applicable and ignored.</term>
		/// </item>
		/// <item>
		/// <term>lpszServiceInstanceName</term>
		/// <term>Referenced string contains the service instance name.</term>
		/// </item>
		/// <item>
		/// <term>lpServiceClassId</term>
		/// <term>The GUID corresponding to this service class.</term>
		/// </item>
		/// <item>
		/// <term>lpVersion</term>
		/// <term>(Optional) Supplies service instance version number.</term>
		/// </item>
		/// <item>
		/// <term>lpszComment</term>
		/// <term>(Optional) An optional comment string.</term>
		/// </item>
		/// <item>
		/// <term>dwNameSpace</term>
		/// <term>See table that follows.</term>
		/// </item>
		/// <item>
		/// <term>lpNSProviderId</term>
		/// <term>See table that follows.</term>
		/// </item>
		/// <item>
		/// <term>lpszContext</term>
		/// <term>(Optional) Specifies the starting point of the query in a hierarchical namespace.</term>
		/// </item>
		/// <item>
		/// <term>dwNumberOfProtocols</term>
		/// <term>Ignored.</term>
		/// </item>
		/// <item>
		/// <term>lpafpProtocols</term>
		/// <term>Ignored.</term>
		/// </item>
		/// <item>
		/// <term>lpszQueryString</term>
		/// <term>Ignored.</term>
		/// </item>
		/// <item>
		/// <term>dwNumberOfCsAddrs</term>
		/// <term>The number of elements in the array of CSADDR_INFO structures referenced by lpcsaBuffer.</term>
		/// </item>
		/// <item>
		/// <term>lpcsaBuffer</term>
		/// <term>A pointer to an array of CSADDR_INFO structures that contain the address(es) that the service is listening on.</term>
		/// </item>
		/// <item>
		/// <term>lpBlob</term>
		/// <term>(Optional) This is a pointer to a provider-specific entity.</term>
		/// </item>
		/// </list>
		/// <para>
		/// As illustrated in the following, the combination of the <c>dwNameSpace</c> and <c>lpNSProviderId</c> members determine that
		/// namespace providers are affected by this function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>dwNameSpace</term>
		/// <term>lpNSProviderId</term>
		/// <term>Scope of impact</term>
		/// </listheader>
		/// <item>
		/// <term>Ignored</term>
		/// <term>Non-null</term>
		/// <term>The specified name-space provider.</term>
		/// </item>
		/// <item>
		/// <term>A valid name- space identifier</term>
		/// <term>Null</term>
		/// <term>All name-space providers that support the indicated namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_ALL</term>
		/// <term>Null</term>
		/// <term>All name-space providers.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSASetServiceW</c> function is supported for Windows Phone Store apps on Windows Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSASetServiceW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasetservicea INT WSAAPI WSASetServiceA( LPWSAQUERYSETA
		// lpqsRegInfo, WSAESETSERVICEOP essoperation, DWORD dwControlFlags );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "21a8ff26-4c9e-4846-a75a-1a27c746edab")]
		public static extern int WSASetService(in WSAQUERYSET lpqsRegInfo, WSAESETSERVICEOP essoperation, ServiceInstallFlags dwControlFlags);

		/// <summary>The <c>WSASocket</c> function creates a socket that is bound to a specific transport-service provider.</summary>
		/// <param name="af">
		/// <para>The address family specification. Possible values for the address family are defined in the Winsock2.h header file.</para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and the possible values
		/// for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in
		/// Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// The values currently supported are AF_INET or AF_INET6, which are the Internet address family formats for IPv4 and IPv6. Other
		/// options for address family (AF_NETBIOS for use with NetBIOS, for example) are supported if a Windows Sockets service provider
		/// for the address family is installed. Note that the values for the AF_ address family and PF_ protocol family constants are
		/// identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
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
		/// versions of Windows. The Windows Sockets provider for NetBIOS is not supported on 64-bit versions of windows including Windows
		/// 7, Windows Server 2008, Windows Vista, Windows Server 2003, or Windows XP. The Windows Sockets provider for NetBIOS only
		/// supports sockets where the type parameter is set to SOCK_DGRAM. The Windows Sockets provider for NetBIOS is not directly related
		/// to the NetBIOS programming interface. The NetBIOS programming interface is not supported on Windows Vista, Windows Server 2008,
		/// and later.
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
		/// specified. Possible values for the protocol are defined are defined in the Winsock2.h and Wsrm.h header files.
		/// </para>
		/// <para>
		/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and this parameter can be
		/// one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h header
		/// file is automatically included in Winsock2.h, and should never be used directly.
		/// </para>
		/// <para>
		/// If a value of 0 is specified, the caller does not wish to specify a protocol and the service provider will choose the protocol
		/// to use.
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
		/// The User Datagram Protocol (UDP). This is a possible value when the af parameter is AF_INET or AF_INET6 and the type parameter
		/// is SOCK_DGRAM.
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
		/// <param name="lpProtocolInfo">
		/// A pointer to a WSAPROTOCOL_INFO structure that defines the characteristics of the socket to be created. If this parameter is not
		/// <c>NULL</c>, the socket will be bound to the provider associated with the indicated <c>WSAPROTOCOL_INFO</c> structure.
		/// </param>
		/// <param name="g">
		/// <para>An existing socket group ID or an appropriate action to take when creating a new socket and a new socket group.</para>
		/// <para>
		/// If g is an existing socket group ID, join the new socket to this socket group, provided all the requirements set by this group
		/// are met.
		/// </para>
		/// <para>If g is not an existing socket group ID, then the following values are possible.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>g</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>No group operation is performed.</term>
		/// </item>
		/// <item>
		/// <term>SG_UNCONSTRAINED_GROUP 0x01</term>
		/// <term>
		/// Create an unconstrained socket group and have the new socket be the first member. For an unconstrained group, Winsock does not
		/// constrain all sockets in the socket group to have been created with the same value for the type and protocol parameters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SG_CONSTRAINED_GROUP 0x02</term>
		/// <term>
		/// Create a constrained socket group and have the new socket be the first member. For a contrained socket group, Winsock constrains
		/// all sockets in the socket group to have been created with the same value for the type and protocol parameters. A constrained
		/// socket group may consist only of connection-oriented sockets, and requires that connections on all grouped sockets be to the
		/// same address on the same host.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The SG_UNCONSTRAINED_GROUP and SG_CONSTRAINED_GROUP constants are not currently defined in a public header file.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>A set of flags used to specify additional socket attributes.</para>
		/// <para>A combination of these flags may be set, although some combinations are not allowed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_FLAG_OVERLAPPED 0x01</term>
		/// <term>
		/// Create a socket that supports overlapped I/O operations. Most sockets should be created with this flag set. Overlapped sockets
		/// can utilize WSASend, WSASendTo, WSARecv, WSARecvFrom, and WSAIoctl for overlapped I/O operations, which allow multiple
		/// operations to be initiated and in progress simultaneously. All functions that allow overlapped operation (WSASend, WSARecv,
		/// WSASendTo, WSARecvFrom, WSAIoctl) also support nonoverlapped usage on an overlapped socket if the values for parameters related
		/// to overlapped operations are NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_FLAG_MULTIPOINT_C_ROOT 0x02</term>
		/// <term>
		/// Create a socket that will be a c_root in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO structure
		/// for the transport provider that creates the socket supports a multipoint or multicast mechanism and the control plane for a
		/// multipoint session is rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO structure with the
		/// XP1_SUPPORT_MULTIPOINT and XP1_MULTIPOINT_CONTROL_PLANE flags set. When the lpProtocolInfo parameter is not NULL, the
		/// WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo parameter. When the lpProtocolInfo
		/// parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider selected by the values specified for the
		/// af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for additional information on a multipoint session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_FLAG_MULTIPOINT_C_LEAF 0x04</term>
		/// <term>
		/// Create a socket that will be a c_leaf in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO structure
		/// for the transport provider that creates the socket supports a multipoint or multicast mechanism and the control plane for a
		/// multipoint session is non-rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO structure with
		/// the XP1_SUPPORT_MULTIPOINT flag set and the XP1_MULTIPOINT_CONTROL_PLANE flag not set. When the lpProtocolInfo parameter is not
		/// NULL, the WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo parameter. When the
		/// lpProtocolInfo parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider selected by the values
		/// specified for the af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for additional information on a
		/// multipoint session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_FLAG_MULTIPOINT_D_ROOT 0x08</term>
		/// <term>
		/// Create a socket that will be a d_root in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO structure
		/// for the transport provider that creates the socket supports a multipoint or multicast mechanism and the data plane for a
		/// multipoint session is rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO structure with the
		/// XP1_SUPPORT_MULTIPOINT and XP1_MULTIPOINT_DATA_PLANE flags set. When the lpProtocolInfo parameter is not NULL, the
		/// WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo parameter. When the lpProtocolInfo
		/// parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider selected by the values specified for the
		/// af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for additional information on a multipoint session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_FLAG_MULTIPOINT_D_LEAF 0x10</term>
		/// <term>
		/// Create a socket that will be a d_leaf in a multipoint session. This attribute is only allowed if the WSAPROTOCOL_INFO structure
		/// for the transport provider that creates the socket supports a multipoint or multicast mechanism and the data plane for a
		/// multipoint session is non-rooted. This would be indicated by the dwServiceFlags1 member of the WSAPROTOCOL_INFO structure with
		/// the XP1_SUPPORT_MULTIPOINT flag set and the XP1_MULTIPOINT_DATA_PLANE flag not set. When the lpProtocolInfo parameter is not
		/// NULL, the WSAPROTOCOL_INFO structure for the transport provider is pointed to by the lpProtocolInfo parameter. When the
		/// lpProtocolInfo parameter is NULL, the WSAPROTOCOL_INFO structure is based on the transport provider selected by the values
		/// specified for the af, type, and protocol parameters. Refer to Multipoint and Multicast Semantics for additional information on a
		/// multipoint session.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_FLAG_ACCESS_SYSTEM_SECURITY 0x40</term>
		/// <term>
		/// Create a socket that allows the the ability to set a security descriptor on the socket that contains a security access control
		/// list (SACL) as opposed to just a discretionary access control list (DACL). SACLs are used for generating audits and alarms when
		/// an access check occurs on the object. For a socket, an access check occurs to determine whether the socket should be allowed to
		/// bind to a specific address specified to the bind function. The ACCESS_SYSTEM_SECURITY access right controls the ability to get
		/// or set the SACL in an object's security descriptor. The system grants this access right only if the SE_SECURITY_NAME privilege
		/// is enabled in the access token of the requesting thread.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_FLAG_NO_HANDLE_INHERIT 0x80</term>
		/// <term>
		/// Create a socket that is non-inheritable. A socket handle created by the WSASocket or the socket function is inheritable by
		/// default. When this flag is set, the socket handle is non-inheritable. The GetHandleInformation function can be used to determine
		/// if a socket handle was created with the WSA_FLAG_NO_HANDLE_INHERIT flag set. The GetHandleInformation function will return that
		/// the HANDLE_FLAG_INHERIT value is set. This flag is supported on Windows 7 with SP1, Windows Server 2008 R2 with SP1, and later
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Important</c> For multipoint sockets, only one of <c>WSA_FLAG_MULTIPOINT_C_ROOT</c> or <c>WSA_FLAG_MULTIPOINT_C_LEAF</c>
		/// flags can be specified, and only one of <c>WSA_FLAG_MULTIPOINT_D_ROOT</c> or <c>WSA_FLAG_MULTIPOINT_D_LEAF</c> flags can be
		/// specified. Refer to Multipoint and Multicast Semantics for additional information.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>WSASocket</c> returns a descriptor referencing the new socket. Otherwise, a value of INVALID_SOCKET is
		/// returned, and a specific error code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <para><c>Note</c> This error code description is Microsoft-specific.</para>
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
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>The specified address family is not supported.</term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The lpProtocolInfo parameter is not in a valid part of the process address space.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>This value is true for any of the following conditions.</term>
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
		/// <term>WSAEMFILE</term>
		/// <term>No more socket descriptors are available.</term>
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
		/// The <c>WSASocket</c> function causes a socket descriptor and any related resources to be allocated and associated with a
		/// transport-service provider. Most sockets should be created with the <c>WSA_FLAG_OVERLAPPED</c> attribute set in the dwFlags
		/// parameter. A socket created with this attribute supports the use of overlapped I/O operations which provide higher performance.
		/// By default, a socket created with the <c>WSASocket</c> function will not have this overlapped attribute set. In contrast, the
		/// socket function creates a socket that supports overlapped I/O operations as the default behavior.
		/// </para>
		/// <para>
		/// If the lpProtocolInfo parameter is <c>NULL</c>, Winsock will utilize the first available transport-service provider that
		/// supports the requested combination of address family, socket type and protocol specified in the af, type, and protocol parameters.
		/// </para>
		/// <para>
		/// If the lpProtocolInfo parameter is not <c>NULL</c>, the socket will be bound to the provider associated with the indicated
		/// WSAPROTOCOL_INFO structure. In this instance, the application can supply the manifest constant <c>FROM_PROTOCOL_INFO</c> as the
		/// value for any of af, type, or protocol parameters. This indicates that the corresponding values from the indicated
		/// <c>WSAPROTOCOL_INFO</c> structure ( <c>iAddressFamily</c>, <c>iSocketType</c>, <c>iProtocol</c>) are to be assumed. In any case,
		/// the values specified for af, type, and protocol are passed unmodified to the transport-service provider.
		/// </para>
		/// <para>
		/// When selecting a protocol and its supporting service provider based on af, type, and protocol, this procedure will only choose a
		/// base protocol or a protocol chain, not a protocol layer by itself. Unchained protocol layers are not considered to have partial
		/// matches on type or af, either. That is, they do not lead to an error code of WSAEAFNOSUPPORT or WSAEPROTONOSUPPORT, if no
		/// suitable protocol is found.
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
		/// If a socket is created using the <c>WSASocket</c> function, then the dwFlags parameter must have the <c>WSA_FLAG_OVERLAPPED</c>
		/// attribute set for the <c>SO_RCVTIMEO</c> or <c>SO_SNDTIMEO</c> socket options to function properly. Otherwise the timeout never
		/// takes effect on the socket.
		/// </para>
		/// <para>
		/// Connection-oriented sockets such as <c>SOCK_STREAM</c> provide full-duplex connections, and must be in a connected state before
		/// any data can be sent or received on them. A connection to a specified socket is established with a connect or WSAConnect
		/// function call. Once connected, data can be transferred using send/WSASend and recv/WSARecv calls. When a session has been
		/// completed, the closesocket function should be called to release the resources associated with the socket. For
		/// connection-oriented sockets, the shutdown function should be called to stop data transfer on the socket before calling the
		/// <c>closesocket</c> function.
		/// </para>
		/// <para>
		/// The communications protocols used to implement a reliable, connection-oriented socket ensure that data is not lost or
		/// duplicated. If data for which the peer protocol has buffer space cannot be successfully transmitted within a reasonable length
		/// of time, the connection is considered broken and subsequent calls will fail with the error code set to WSAETIMEDOUT.
		/// </para>
		/// <para>
		/// Connectionless, message-oriented sockets allow sending and receiving of datagrams to and from arbitrary peers using
		/// sendto/WSASendTo and recvfrom/WSARecvFrom. If such a socket is connected to a specific peer, datagrams can be sent to that peer
		/// using send/WSASend and can be received from (only) this peer using recv/WSARecv.
		/// </para>
		/// <para>
		/// Support for sockets with type <c>SOCK_RAW</c> is not required, but service providers are encouraged to support raw sockets
		/// whenever possible.
		/// </para>
		/// <para>
		/// The <c>WSASocket</c> function can be used to create a socket to be used by a service so that if another socket tries to bind to
		/// the same port used by the service, and audit record is generared. To enable this option, an application would need to do the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Call the AdjustTokenPrivileges function to enable the <c>SE_SECURITY_NAME</c> privilege in the access token for the process.
		/// This privilege is required to set the <c>ACCESS_SYSTEM_SECURITY</c> access rights on the security descriptor for an object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the <c>WSASocket</c> function to create a socket with dwFlag with the <c>WSA_FLAG_ACCESS_SYSTEM_SECURITY</c> option set.
		/// The <c>WSASocket</c> function will fail if the AdjustTokenPrivileges function is not called first to enable the
		/// <c>SE_SECURITY_NAME</c> privilege needed for this operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the SetSecurityInfo function to set a security descriptor with a System Access Control List (SACL) on the socket. The
		/// socket handle returned by the <c>WSASocket</c> function is passed in the handle parameter. If the function succeeds, this will
		/// set the the <c>ACCESS_SYSTEM_SECURITY</c> access right on the security descriptor for the socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the bindfunction to bind the socket to a specific port. If the <c>bind</c> function succeeds, then an audit entry is
		/// generated if another socket tries to bind to the same port.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Call the AdjustTokenPrivileges function to remove the <c>SE_SECURITY_NAME</c> privilege in the access token for the process,
		/// since this is no longer needed.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For more information on <c>ACCESS_SYSTEM_SECURITY</c>, see SACL Access Right and Audit Generation in the Authorization documentation.
		/// </para>
		/// <para>Socket Groups</para>
		/// <para>
		/// WinSock 2 introduced the notion of a socket group as a means for an application, or cooperating set of applications, to indicate
		/// to an underlying service provider that a particular set of sockets are related and that the group thus formed has certain
		/// attributes. Group attributes include relative priorities of the individual sockets within the group and a group quality of
		/// service specification.
		/// </para>
		/// <para>
		/// Applications that need to exchange multimedia streams over the network are an example where being able to establish a specific
		/// relationship among a set of sockets could be beneficial. It is up to the transport on how to treat socket groups.
		/// </para>
		/// <para>
		/// The <c>WSASocket</c> and WSAAccept functions can be used to explicitly create and join a socket group when creating a new
		/// socket. The socket group ID for a socket can be retrieved by using the getsockopt function with level parameter set to
		/// SOL_SOCKET and the optname parameter set to <c>SO_GROUP_ID</c>. A socket group and its associated socket group ID remain valid
		/// until the last socket belonging to this socket group is closed. Socket group IDs are unique across all processes for a given
		/// service provider. A socket group of zero indicates that the socket is not member of a socket group.
		/// </para>
		/// <para>
		/// The relative group priority of a socket group can be accessed by using the getsockopt function with the level parameter set to
		/// SOL_SOCKET and the optname parameter set to <c>SO_GROUP_PRIORITY</c>. The relative group priority of a socket group can be set
		/// by using setsockopt with the level parameter set to SOL_SOCKET and the optname parameter set to <c>SO_GROUP_PRIORITY</c>.
		/// </para>
		/// <para>
		/// The Winsock provider included with Windows allows the creation of socket groups and it enforces the SG_CONSTRAINED_GROUP. All
		/// sockets in a constrained socket group must be created with the same value for the type and protocol parameters. A constrained
		/// socket group may consist only of connection-oriented sockets, and requires that connections on all grouped sockets be to the
		/// same address on the same host. This is the only restriction applied to a socket group by the Winsock provider included with
		/// Windows. The socket group priority is not currently used by the Winsock provider or the TCP/IP stack included with Windows.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>WSASocket</c> function.</para>
		/// <para>
		/// <c>Windows Phone 8:</c> The <c>WSASocketW</c> function is supported for Windows Phone Store apps on Windows Phone 8 and later.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>WSASocketW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsasocketa SOCKET WSAAPI WSASocketA( int af, int type,
		// int protocol, LPWSAPROTOCOL_INFOA lpProtocolInfo, GROUP g, DWORD dwFlags );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "dcf2e543-de54-43d9-9e45-4cb935da3548")]
		public static extern SOCKET WSASocket(ADDRESS_FAMILY af, SOCK type, IPPROTO protocol, in WSAPROTOCOL_INFO lpProtocolInfo, GROUP g, WSA_FLAG dwFlags);

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
		/// In order to support various Windows Sockets implementations and applications that can have functional differences from the
		/// latest version of Windows Sockets specification, a negotiation takes place in <c>WSAStartup</c>. The caller of <c>WSAStartup</c>
		/// passes in the wVersionRequested parameter the highest version of the Windows Sockets specification that the application
		/// supports. The Winsock DLL indicates the highest version of the Windows Sockets specification that it can support in its
		/// response. The Winsock DLL also replies with version of the Windows Sockets specification that it expects the caller to use.
		/// </para>
		/// <para>
		/// When an application or DLL calls the <c>WSAStartup</c> function, the Winsock DLL examines the version of the Windows Sockets
		/// specification requested by the application passed in the wVersionRequested parameter. If the version requested by the
		/// application is equal to or higher than the lowest version supported by the Winsock DLL, the call succeeds and the Winsock DLL
		/// returns detailed information in the WSADATA structure pointed to by the lpWSAData parameter. The <c>wHighVersion</c> member of
		/// the <c>WSADATA</c> structure indicates the highest version of the Windows Sockets specification that the Winsock DLL supports.
		/// The <c>wVersion</c> member of the <c>WSADATA</c> structure indicates the version of the Windows Sockets specification that the
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
		/// To get full access to the new syntax of a higher version of the Windows Sockets specification, the application must negotiate
		/// for this higher version. In this case, the wVersionRequested parameter should be set to request version 2.2. The application
		/// must also fully conform to that higher version of the Windows Socket specification, such as compiling against the appropriate
		/// header file, linking with a new library, or other special cases. The Winsock2.h header file for Winsock 2 support is included
		/// with the Microsoft Windows Software Development Kit (SDK).
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
		/// earlier to run with the same behavior on later versions of Windows. The Winsock.h header file for Winsock 1.1 support is
		/// included with the Windows SDK.
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
		/// needed. When it has finished using the services of the Winsock DLL, the application must call WSACleanup to allow the Winsock
		/// DLL to free internal Winsock resources used by the application.
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

		/// <summary>
		/// The <c>WSAStringToAddress</c> function converts a network address in its standard text presentation form into its numeric binary
		/// form in a sockaddr structure, suitable for passing to Windows Sockets routines that take such a structure.
		/// </summary>
		/// <param name="AddressString">
		/// A pointer to the zero-terminated string that contains the network address in standard text form to convert.
		/// </param>
		/// <param name="AddressFamily">The address family of the network address pointed to by the AddressString parameter.</param>
		/// <param name="lpProtocolInfo">
		/// The WSAPROTOCOL_INFO structure associated with the provider to be used. If this is <c>NULL</c>, the call is routed to the
		/// provider of the first protocol supporting the indicated AddressFamily.
		/// </param>
		/// <param name="lpAddress">
		/// A pointer to a buffer that is filled with a sockaddr structure for the address string if the function succeeds.
		/// </param>
		/// <param name="lpAddressLength">
		/// A pointer to the length, in bytes, of the buffer pointed to by the lpAddress parameter. If the function call is successful, this
		/// parameter returns a pointer to the size of the sockaddr structure returned in the lpAddress parameter. If the specified buffer
		/// is not large enough, the function fails with a specific error of WSAEFAULT and this parameter is updated with the required size
		/// in bytes.
		/// </param>
		/// <returns>
		/// <para>
		/// The return value for <c>WSAStringToAddress</c> is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is
		/// returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The buffer pointed to by the lpAddress parameter is too small. Pass in a larger buffer.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The functions was unable to translate the string into a sockaddr. See the following Remarks section for more information.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Socket functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAStringToAddress</c> function converts a network address in standard text form into its numeric binary form in a
		/// sockaddr structure.
		/// </para>
		/// <para>
		/// Any missing components of the address will be defaulted to a reasonable value, if possible. For example, a missing port number
		/// will default to zero. If the caller wants the translation to be done by a particular provider, it should supply the
		/// corresponding WSAPROTOCOL_INFO structure in the lpProtocolInfo parameter.
		/// </para>
		/// <para>
		/// The <c>WSAStringToAddress</c> function fails (and returns WSAEINVAL) if the <c>sin_family</c> member of the SOCKADDR_IN
		/// structure, which is passed in the lpAddress parameter in the form of a <c>sockaddr</c> structure, is not set to AF_INET or AF_INET6.
		/// </para>
		/// <para>
		/// Support for IPv6 addresses using the <c>WSAStringToAddress</c> function was added on Windows XP with Service Pack 1 (SP1)and
		/// later. IPv6 must also be installed on the local computer for the <c>WSAStringToAddress</c> function to support IPv6 addresses.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsastringtoaddressa INT WSAAPI WSAStringToAddressA( LPSTR
		// AddressString, INT AddressFamily, LPWSAPROTOCOL_INFOA lpProtocolInfo, LPSOCKADDR lpAddress, LPINT lpAddressLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "7b9946c3-c8b3-45ae-9bde-03faaf604bba")]
		public static extern int WSAStringToAddress([MarshalAs(UnmanagedType.LPTStr)] string AddressString, ADDRESS_FAMILY AddressFamily, in WSAPROTOCOL_INFO lpProtocolInfo, [Out] SOCKADDR lpAddress, ref int lpAddressLength);

		/// <summary>
		/// The <c>WSAStringToAddress</c> function converts a network address in its standard text presentation form into its numeric binary
		/// form in a sockaddr structure, suitable for passing to Windows Sockets routines that take such a structure.
		/// </summary>
		/// <param name="AddressString">
		/// A pointer to the zero-terminated string that contains the network address in standard text form to convert.
		/// </param>
		/// <param name="AddressFamily">The address family of the network address pointed to by the AddressString parameter.</param>
		/// <param name="lpProtocolInfo">
		/// The WSAPROTOCOL_INFO structure associated with the provider to be used. If this is <c>NULL</c>, the call is routed to the
		/// provider of the first protocol supporting the indicated AddressFamily.
		/// </param>
		/// <param name="lpAddress">
		/// A pointer to a buffer that is filled with a sockaddr structure for the address string if the function succeeds.
		/// </param>
		/// <param name="lpAddressLength">
		/// A pointer to the length, in bytes, of the buffer pointed to by the lpAddress parameter. If the function call is successful, this
		/// parameter returns a pointer to the size of the sockaddr structure returned in the lpAddress parameter. If the specified buffer
		/// is not large enough, the function fails with a specific error of WSAEFAULT and this parameter is updated with the required size
		/// in bytes.
		/// </param>
		/// <returns>
		/// <para>
		/// The return value for <c>WSAStringToAddress</c> is zero if the operation was successful. Otherwise, the value SOCKET_ERROR is
		/// returned, and a specific error number can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The buffer pointed to by the lpAddress parameter is too small. Pass in a larger buffer.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>The functions was unable to translate the string into a sockaddr. See the following Remarks section for more information.</term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>
		/// The WS2_32.DLL has not been initialized. The application must first call WSAStartup before calling any Windows Socket functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to perform the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAStringToAddress</c> function converts a network address in standard text form into its numeric binary form in a
		/// sockaddr structure.
		/// </para>
		/// <para>
		/// Any missing components of the address will be defaulted to a reasonable value, if possible. For example, a missing port number
		/// will default to zero. If the caller wants the translation to be done by a particular provider, it should supply the
		/// corresponding WSAPROTOCOL_INFO structure in the lpProtocolInfo parameter.
		/// </para>
		/// <para>
		/// The <c>WSAStringToAddress</c> function fails (and returns WSAEINVAL) if the <c>sin_family</c> member of the SOCKADDR_IN
		/// structure, which is passed in the lpAddress parameter in the form of a <c>sockaddr</c> structure, is not set to AF_INET or AF_INET6.
		/// </para>
		/// <para>
		/// Support for IPv6 addresses using the <c>WSAStringToAddress</c> function was added on Windows XP with Service Pack 1 (SP1)and
		/// later. IPv6 must also be installed on the local computer for the <c>WSAStringToAddress</c> function to support IPv6 addresses.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsastringtoaddressa INT WSAAPI WSAStringToAddressA( LPSTR
		// AddressString, INT AddressFamily, LPWSAPROTOCOL_INFOA lpProtocolInfo, LPSOCKADDR lpAddress, LPINT lpAddressLength );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winsock2.h", MSDNShortId = "7b9946c3-c8b3-45ae-9bde-03faaf604bba")]
		public static extern int WSAStringToAddress([MarshalAs(UnmanagedType.LPTStr)] string AddressString, ADDRESS_FAMILY AddressFamily, [In, Optional] IntPtr lpProtocolInfo, [Out] SOCKADDR lpAddress, ref int lpAddressLength);

		/// <summary>
		/// The <c>WSAWaitForMultipleEvents</c> function returns when one or all of the specified event objects are in the signaled state,
		/// when the time-out interval expires, or when an I/O completion routine has executed.
		/// </summary>
		/// <param name="cEvents">
		/// The number of event object handles in the array pointed to by lphEvents. The maximum number of event object handles is
		/// <c>WSA_MAXIMUM_WAIT_EVENTS</c>. One or more events must be specified.
		/// </param>
		/// <param name="lphEvents">
		/// <para>
		/// A pointer to an array of event object handles. The array can contain handles of objects of different types. It may not contain
		/// multiple copies of the same handle if the fWaitAll parameter is set to <c>TRUE</c>. If one of these handles is closed while the
		/// wait is still pending, the behavior of <c>WSAWaitForMultipleEvents</c> is undefined.
		/// </para>
		/// <para>The handles must have the <c>SYNCHRONIZE</c> access right. For more information, see Standard Access Rights.</para>
		/// </param>
		/// <param name="fWaitAll">
		/// A value that specifies the wait type. If <c>TRUE</c>, the function returns when the state of all objects in the lphEvents array
		/// is signaled. If <c>FALSE</c>, the function returns when any of the event objects is signaled. In the latter case, the return
		/// value minus <c>WSA_WAIT_EVENT_0</c> indicates the index of the event object whose state caused the function to return. If more
		/// than one event object became signaled during the call, this is the array index to the signaled event object with the smallest
		/// index value of all the signaled event objects.
		/// </param>
		/// <param name="dwTimeout">
		/// The time-out interval, in milliseconds. <c>WSAWaitForMultipleEvents</c> returns if the time-out interval expires, even if
		/// conditions specified by the fWaitAll parameter are not satisfied. If the dwTimeout parameter is zero,
		/// <c>WSAWaitForMultipleEvents</c> tests the state of the specified event objects and returns immediately. If dwTimeout is
		/// <c>WSA_INFINITE</c>, <c>WSAWaitForMultipleEvents</c> waits forever; that is, the time-out interval never expires.
		/// </param>
		/// <param name="fAlertable">
		/// A value that specifies whether the thread is placed in an alertable wait state so the system can execute I/O completion
		/// routines. If <c>TRUE</c>, the thread is placed in an alertable wait state and <c>WSAWaitForMultipleEvents</c> can return when
		/// the system executes an I/O completion routine. In this case, <c>WSA_WAIT_IO_COMPLETION</c> is returned and the event that was
		/// being waited on is not signaled yet. The application must call the <c>WSAWaitForMultipleEvents</c> function again. If
		/// <c>FALSE</c>, the thread is not placed in an alertable wait state and I/O completion routines are not executed.
		/// </param>
		/// <returns>
		/// <para>If the <c>WSAWaitForMultipleEvents</c> function succeeds, the return value upon success is one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSA_WAIT_EVENT_0 to (WSA_WAIT_EVENT_0 + cEvents - 1)</term>
		/// <term>
		/// If the fWaitAll parameter is TRUE, the return value indicates that all specified event objects is signaled. If the fWaitAll
		/// parameter is FALSE, the return value minus WSA_WAIT_EVENT_0 indicates the lphEvents array index of the signaled event object
		/// that satisfied the wait. If more than one event object became signaled during the call, the return value indicates the lphEvents
		/// array index of the signaled event object with the smallest index value of all the signaled event objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_WAIT_IO_COMPLETION</term>
		/// <term>
		/// The wait was ended by one or more I/O completion routines that were executed. The event that was being waited on is not signaled
		/// yet. The application must call the WSAWaitForMultipleEvents function again. This return value can only be returned if the
		/// fAlertable parameter is TRUE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSA_WAIT_TIMEOUT</term>
		/// <term>
		/// The time-out interval elapsed and the conditions specified by the fWaitAll parameter were not satisfied. No I/O completion
		/// routines were executed.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the <c>WSAWaitForMultipleEvents</c> function fails, the return value is <c>WSA_WAIT_FAILED</c>. The following table lists
		/// values that can be used with WSAGetLastError to get extended error information.
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
		/// <term>WSAEINPROGRESS</term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough free memory was available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>WSA_INVALID_HANDLE</term>
		/// <term>One or more of the values in the lphEvents array is not a valid event object handle.</term>
		/// </item>
		/// <item>
		/// <term>WSA_INVALID_PARAMETER</term>
		/// <term>The cEvents parameter does not contain a valid handle count.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSAWaitForMultipleEvents</c> function determines whether the wait criteria have been met. If the criteria have not been
		/// met, the calling thread enters the wait state. It uses no processor time while waiting for the criteria to be met.
		/// </para>
		/// <para>
		/// The <c>WSAWaitForMultipleEvents</c> function returns when any one or all of the specified objects are in the signaled state, or
		/// when the time-out interval elapses.
		/// </para>
		/// <para>
		/// When the bWaitAll parameter is <c>TRUE</c>, the wait operation is completed only when the states of all objects have been set to
		/// signaled. The function does not modify the states of the specified objects until the states of all objects have been set to signaled.
		/// </para>
		/// <para>
		/// When bWaitAll parameter is <c>FALSE</c>, <c>WSAWaitForMultipleEvents</c> checks the handles in the lphEvents array in order
		/// starting with index 0, until one of the objects is signaled. If multiple objects become signaled, the function returns the index
		/// of the first handle in the lphEvents array whose object was signaled.
		/// </para>
		/// <para>
		/// This function is also used to perform an alertable wait by setting the fAlertable parameter to <c>TRUE</c>. This enables the
		/// function to return when the system executes an I/O completion routine by the calling thread.
		/// </para>
		/// <para>
		/// A thread must be in an alertable wait state in order for the system to execute I/O completion routines (asynchronous procedure
		/// calls or APCs). So if an application calls <c>WSAWaitForMultipleEvents</c> when there are pending asynchronous operations that
		/// have I/O completion routines and the fAlertable parameter is <c>FALSE</c>, then those I/O completion routines will not be
		/// executed even if those I/O operations are completed.
		/// </para>
		/// <para>
		/// If the fAlertable parameter is <c>TRUE</c> and one of the pending operations completes, the APC is executed and
		/// <c>WSAWaitForMultipleEvents</c> will return <c>WSA_IO_COMPLETION</c>. The pending event is not signaled yet. The application
		/// must call the <c>WSAWaitForMultipleEvents</c> function again.
		/// </para>
		/// <para>
		/// Applications that require an alertable wait state without waiting for any event objects to be signaled should use the Windows
		/// SleepEx function.
		/// </para>
		/// <para>The current implementation of <c>WSAWaitForMultipleEvents</c> calls the WaitForMultipleObjectsEx function.</para>
		/// <para>
		/// <c>Note</c> Use caution when calling the <c>WSAWaitForMultipleEvents</c> with code that directly or indirectly creates windows.
		/// If a thread creates any windows, it must process messages. Message broadcasts are sent to all windows in the system. A thread
		/// that uses <c>WSAWaitForMultipleEvents</c> with no time-out limit (the dwTimeout parameter set to <c>WSA_INFINITE</c>) may cause
		/// the system to become deadlocked.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following code example shows how to use the <c>WSAWaitForMultipleEvents</c> function.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-wsawaitformultipleevents DWORD WSAAPI
		// WSAWaitForMultipleEvents( DWORD cEvents, const WSAEVENT *lphEvents, BOOL fWaitAll, DWORD dwTimeout, BOOL fAlertable );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsock2.h", MSDNShortId = "7a978ade-6323-455b-b655-f372f4bcadc8")]
		public static extern uint WSAWaitForMultipleEvents(uint cEvents, [In, MarshalAs(UnmanagedType.LPArray)] WSAEVENT[] lphEvents, [MarshalAs(UnmanagedType.Bool)] bool fWaitAll, uint dwTimeout, [MarshalAs(UnmanagedType.Bool)] bool fAlertable);

		/// <summary>
		/// The <c>fd_set</c> structure is used by various Windows Sockets functions and service providers, such as the select function, to
		/// place sockets into a "set" for various purposes, such as testing a given socket for readability using the readfds parameter of
		/// the <c>select</c> function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock/ns-winsock-fd_set typedef struct fd_set { u_int fd_count; SOCKET
		// fd_array[FD_SETSIZE]; } fd_set, FD_SET, *PFD_SET, *LPFD_SET;
		[PInvokeData("winsock.h", MSDNShortId = "2af5d69d-190e-4814-8d8b-438431808625")]
		[StructLayout(LayoutKind.Sequential)]
		public struct fd_set
		{
			/// <summary>The number of sockets in the set.</summary>
			public uint fd_count;

			/// <summary>An array of sockets that are in the set.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
			public SOCKET[] fd_array;
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

		/// <summary>The <c>WSANETWORKEVENTS</c> structure is used to store a socket's internal information about network events.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsanetworkevents typedef struct _WSANETWORKEVENTS { long
		// lNetworkEvents; int iErrorCode[FD_MAX_EVENTS]; } WSANETWORKEVENTS, *LPWSANETWORKEVENTS;
		[PInvokeData("winsock2.h", MSDNShortId = "72ae4aa8-4e15-4215-8dcb-45e394ac1313")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSANETWORKEVENTS
		{
			/// <summary>Indicates which of the FD_XXX network events have occurred.</summary>
			public int lNetworkEvents;

			/// <summary>
			/// Array that contains any associated error codes, with an array index that corresponds to the position of event bits in
			/// <c>lNetworkEvents</c>. The identifiers FD_READ_BIT, FD_WRITE_BIT and others can be used to index the <c>iErrorCode</c> array.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
			public int[] iErrorCode;
		}

		/// <summary>The <c>WSANSCLASSINFO</c> structure provides individual parameter information for a specific Windows Sockets namespace.</summary>
		/// <remarks>
		/// The <c>WSANSCLASSINFO</c> structure is defined differently depending on whether ANSI or UNICODE is used. The above syntax block
		/// applies to ANSI; for UNICODE, the datatype for <c>lpszName</c> is <c>LPWSTR</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsansclassinfoa typedef struct _WSANSClassInfoA { LPSTR
		// lpszName; DWORD dwNameSpace; DWORD dwValueType; DWORD dwValueSize; LPVOID lpValue; } WSANSCLASSINFOA, *PWSANSCLASSINFOA, *LPWSANSCLASSINFOA;
		[PInvokeData("winsock2.h", MSDNShortId = "b4f811ad-7967-45bd-b563-a28bb1633596")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WSANSCLASSINFO
		{
			/// <summary>String value associated with the parameter, such as SAPID, TCPPORT, and so forth.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszName;

			/// <summary>GUID associated with the namespace.</summary>
			public uint dwNameSpace;

			/// <summary>Value type for the parameter, such as REG_DWORD or REG_SZ, and so forth.</summary>
			public uint dwValueType;

			/// <summary>Size of the parameter provided in <c>lpValue</c>, in bytes.</summary>
			public uint dwValueSize;

			/// <summary>Pointer to the value of the parameter.</summary>
			public IntPtr lpValue;
		}

		/// <summary>The <c>WSAPOLLFD</c> structure stores socket information used by the WSAPoll function.</summary>
		/// <remarks>
		/// <para>The <c>WSAPOLLFD</c> structure is defined on Windows Vista and later.</para>
		/// <para>
		/// The <c>WSAPOLLFD</c> structure is used by the WSAPoll function to determine the status of one or more sockets. The set of
		/// sockets for which status is requested is specified in fdarray parameter, which is an array of <c>WSAPOLLFD</c> structures. An
		/// application sets the appropriate flags in the <c>events</c> member of the <c>WSAPOLLFD</c> structure to specify the type of
		/// status requested for each corresponding socket. The <c>WSAPoll</c> function returns the status of a socket in the <c>revents</c>
		/// member of the <c>WSAPOLLFD</c> structure.
		/// </para>
		/// <para>
		/// If the <c>fd</c> member of the <c>WSAPOLLFD</c> structure is set to a negative value, the structure is ignored by the WSAPoll
		/// function call, and the <c>revents</c> member is cleared upon return. This is useful to applications that maintain a fixed
		/// allocation for the fdarray parameter of <c>WSAPoll</c>; such applications need not waste resources compacting elements of the
		/// array for unused entries or reallocating memory. It is unnecessary to clear the <c>revents</c> member prior to calling the
		/// <c>WSAPoll</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsapollfd typedef struct pollfd { SOCKET fd; SHORT
		// events; SHORT revents; } WSAPOLLFD, *PWSAPOLLFD, *LPWSAPOLLFD;
		[PInvokeData("winsock2.h", MSDNShortId = "88f122ce-e2ca-44ce-bd53-d73d0962e7ef")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WSAPOLLFD
		{
			/// <summary>
			/// <para>Type: <c>SOCKET</c></para>
			/// <para>The identifier of the socket for which to find status. This parameter is ignored if set to a negative value. See Remarks.</para>
			/// </summary>
			public SOCKET fd;

			/// <summary>
			/// <para>Type: <c>short</c></para>
			/// <para>A set of flags indicating the type of status being requested. This must be one or more of the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>POLLPRI</term>
			/// <term>Priority data may be read without blocking. This flag is not supported by the Microsoft Winsock provider.</term>
			/// </item>
			/// <item>
			/// <term>POLLRDBAND</term>
			/// <term>Priority band (out-of-band) data can be read without blocking.</term>
			/// </item>
			/// <item>
			/// <term>POLLRDNORM</term>
			/// <term>Normal data can be read without blocking.</term>
			/// </item>
			/// <item>
			/// <term>POLLWRNORM</term>
			/// <term>Normal data can be written without blocking.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The POLLIN flag is defined as the combination of the <c>POLLRDNORM</c> and <c>POLLRDBAND</c> flag values. The POLLOUT flag
			/// is defined as the same as the <c>POLLWRNORM</c> flag value.
			/// </para>
			/// </summary>
			public PollFlags events;

			/// <summary>
			/// <para>Type: <c>short</c></para>
			/// <para>
			/// A set of flags that indicate, upon return from the WSAPoll function call, the results of the status query. This can a
			/// combination of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Flag</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>POLLERR</term>
			/// <term>An error has occurred.</term>
			/// </item>
			/// <item>
			/// <term>POLLHUP</term>
			/// <term>A stream-oriented connection was either disconnected or aborted.</term>
			/// </item>
			/// <item>
			/// <term>POLLNVAL</term>
			/// <term>An invalid socket was used.</term>
			/// </item>
			/// <item>
			/// <term>POLLPRI</term>
			/// <term>Priority data may be read without blocking. This flag is not returned by the Microsoft Winsock provider.</term>
			/// </item>
			/// <item>
			/// <term>POLLRDBAND</term>
			/// <term>Priority band (out-of-band) data may be read without blocking.</term>
			/// </item>
			/// <item>
			/// <term>POLLRDNORM</term>
			/// <term>Normal data may be read without blocking.</term>
			/// </item>
			/// <item>
			/// <term>POLLWRNORM</term>
			/// <term>Normal data may be written without blocking.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The POLLIN flag is defined as the combination of the <c>POLLRDNORM</c> and <c>POLLRDBAND</c> flag values. The POLLOUT flag
			/// is defined as the same as the <c>POLLWRNORM</c> flag value.
			/// </para>
			/// <para>
			/// For sockets that do not satisfy the status query, and have no error, the <c>revents</c> member is set to zero upon return.
			/// </para>
			/// </summary>
			public PollFlags revents;
		}

		/// <summary>
		/// The <c>WSAQUERYSET</c> structure provides relevant information about a given service, including service class ID, service name,
		/// applicable namespace identifier and protocol information, as well as a set of transport addresses at which the service listens.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WSAQUERYSET</c> structure is used as part of the original namespace provider version 1 architecture available on Windows
		/// 95 and later. A newer version 2 of the namespace architecture is available on Windows Vista and later.
		/// </para>
		/// <para>
		/// In most instances, applications interested in only a particular transport protocol should constrain their query by address
		/// family and protocol rather than by namespace. This would allow an application that needs to locate a TCP/IP service, for
		/// example, to have its query processed by all available namespaces such as the local hosts file, DNS, and NIS.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaquerysetw typedef struct _WSAQuerySetW { DWORD dwSize;
		// LPWSTR lpszServiceInstanceName; LPGUID lpServiceClassId; LPWSAVERSION lpVersion; LPWSTR lpszComment; DWORD dwNameSpace; LPGUID
		// lpNSProviderId; LPWSTR lpszContext; DWORD dwNumberOfProtocols; LPAFPROTOCOLS lpafpProtocols; LPWSTR lpszQueryString; DWORD
		// dwNumberOfCsAddrs; LPCSADDR_INFO lpcsaBuffer; DWORD dwOutputFlags; LPBLOB lpBlob; } WSAQUERYSETW, *PWSAQUERYSETW, *LPWSAQUERYSETW;
		[PInvokeData("winsock2.h", MSDNShortId = "6c81fbba-aaf4-49ca-ab79-b6fe5dfb0076")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WSAQUERYSET
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The size, in bytes, of the <c>WSAQUERYSET</c> structure. This member is used as a versioning mechanism since the size of the
			/// <c>WSAQUERYSET</c> structure has changed on later versions of Windows.
			/// </para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c>LPTSTR</c></para>
			/// <para>
			/// A pointer to an optional NULL-terminated string that contains service name. The semantics for using wildcards within the
			/// string are not defined, but can be supported by certain namespace providers.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpszServiceInstanceName;

			/// <summary>
			/// <para>Type: <c>LPGUID</c></para>
			/// <para>The GUID corresponding to the service class. This member is required to be set.</para>
			/// </summary>
			public GuidPtr lpServiceClassId;

			/// <summary>
			/// <para>Type: <c>LPWSAVERSION</c></para>
			/// <para>
			/// A pointer to an optional desired version number of the namespace provider. This member provides version comparison semantics
			/// (that is, the version requested must match exactly, or version must be not less than the value supplied).
			/// </para>
			/// </summary>
			public IntPtr lpVersion;

			/// <summary>
			/// <para>Type: <c>LPTSTR</c></para>
			/// <para>This member is ignored for queries.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpszComment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A namespace identifier that determines which namespace providers are queried. Passing a specific namespace identifier will
			/// result in only namespace providers that support the specified namespace being queried. Specifying <c>NS_ALL</c> will result
			/// in all installed and active namespace providers being queried.
			/// </para>
			/// <para>
			/// Options for the <c>dwNameSpace</c> member are listed in the Winsock2.h include file. Several new namespace providers are
			/// included with Windows Vista and later. Other namespace providers can be installed, so the following possible values are only
			/// those commonly available. Many other values are possible.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NS_ALL</term>
			/// <term>All installed and active namespaces.</term>
			/// </item>
			/// <item>
			/// <term>NS_BTH</term>
			/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>NS_DNS</term>
			/// <term>The domain name system (DNS) namespace.</term>
			/// </item>
			/// <item>
			/// <term>NS_EMAIL</term>
			/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>NS_NLA</term>
			/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
			/// </item>
			/// <item>
			/// <term>NS_PNRPNAME</term>
			/// <term>
			/// The peer-to-peer name space for a specific peer name. This namespace identifier is supported on Windows Vista and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NS_PNRPCLOUD</term>
			/// <term>
			/// The peer-to-peer name space for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public NS dwNameSpace;

			/// <summary>
			/// <para>Type: <c>LPGUID</c></para>
			/// <para>
			/// A pointer to an optional GUID of a specific namespace provider to query in the case where multiple namespace providers are
			/// registered under a single namespace such as <c>NS_DNS</c>. Passing the GUID for a specific namespace provider will result in
			/// only the specified namespace provider being queried. The WSAEnumNameSpaceProviders and WSAEnumNameSpaceProvidersEx functions
			/// can be called to retrieve the GUID for a namespace provider.
			/// </para>
			/// </summary>
			public GuidPtr lpNSProviderId;

			/// <summary>
			/// <para>Type: <c>LPTSTR</c></para>
			/// <para>A pointer to an optional starting point of the query in a hierarchical namespace.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpszContext;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size, in bytes, of the protocol constraint array. This member can be zero.</para>
			/// </summary>
			public uint dwNumberOfProtocols;

			/// <summary>
			/// <para>Type: <c>LPAFPROTOCOLS</c></para>
			/// <para>A pointer to an optional array of AFPROTOCOLS structures. Only services that utilize these protocols will be returned.</para>
			/// </summary>
			public IntPtr lpafpProtocols;

			/// <summary>
			/// <para>Type: <c>LPTSTR</c></para>
			/// <para>
			/// A pointer to an optional NULL-terminated query string. Some namespaces, such as Whois++, support enriched SQL-like queries
			/// that are contained in a simple text string. This parameter is used to specify that string.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string lpszQueryString;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is ignored for queries.</para>
			/// </summary>
			public uint dwNumberOfCsAddrs;

			/// <summary>
			/// <para>Type: <c>LPCSADDR_INFO</c></para>
			/// <para>This member is ignored for queries.</para>
			/// </summary>
			public IntPtr lpcsaBuffer;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is ignored for queries.</para>
			/// </summary>
			public uint dwOutputFlags;

			/// <summary>
			/// <para>Type: <c>LPBLOB</c></para>
			/// <para>
			/// An optional pointer to data that is used to query or set provider-specific namespace information. The format of this
			/// information is specific to the namespace provider.
			/// </para>
			/// </summary>
			public IntPtr lpBlob;

			/// <summary>Initializes a new instance of the <see cref="WSAQUERYSET"/> struct.</summary>
			/// <param name="nameSpace">The name space.</param>
			public WSAQUERYSET(NS nameSpace) : this()
			{
				dwSize = (uint)Marshal.SizeOf(this);
				dwNameSpace = nameSpace;
			}
		}

		/// <summary>
		/// The <c>WSASERVICECLASSINFO</c> structure contains information about a specified service class. For each service class in Windows
		/// Sockets 2, there is a single <c>WSASERVICECLASSINFO</c> structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaserviceclassinfow typedef struct _WSAServiceClassInfoW
		// { LPGUID lpServiceClassId; LPWSTR lpszServiceClassName; DWORD dwCount; LPWSANSCLASSINFOW lpClassInfos; } WSASERVICECLASSINFOW,
		// *PWSASERVICECLASSINFOW, *LPWSASERVICECLASSINFOW;
		[PInvokeData("winsock2.h", MSDNShortId = "02422c24-34a6-4e34-a795-66b0b687ac44")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WSASERVICECLASSINFO
		{
			/// <summary>Unique Identifier (GUID) for the service class.</summary>
			public GuidPtr lpServiceClassId;

			/// <summary>Well known name associated with the service class.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string lpszServiceClassName;

			/// <summary>Number of entries in <c>lpClassInfos</c>.</summary>
			public uint dwCount;

			/// <summary>Array of WSANSCLASSINFO structures that contains information about the service class.</summary>
			public IntPtr lpClassInfos;

			/// <summary>Marshaled array of WSANSCLASSINFO structures that contains information about the service class.</summary>
			public WSANSCLASSINFO[] ClassInfos => lpClassInfos.ToArray<WSANSCLASSINFO>((int)dwCount);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WSAEVENT"/> that is disposed using <see cref="WSACloseEvent"/>.</summary>
		public class SafeWSAEVENT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeWSAEVENT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeWSAEVENT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeWSAEVENT"/> class.</summary>
			private SafeWSAEVENT() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeWSAEVENT"/> to <see cref="WSAEVENT"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WSAEVENT(SafeWSAEVENT h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WSACloseEvent(handle);
		}
	}
}