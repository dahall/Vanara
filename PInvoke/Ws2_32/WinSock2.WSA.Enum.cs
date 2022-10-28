#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Data;
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		[PInvokeData("winsock2.h")]
		public enum WSACOMPLETIONTYPE
		{
			NSP_NOTIFY_IMMEDIATELY,
			NSP_NOTIFY_HWND,
			NSP_NOTIFY_EVENT,
			NSP_NOTIFY_PORT,
			NSP_NOTIFY_APC,
		}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}
}