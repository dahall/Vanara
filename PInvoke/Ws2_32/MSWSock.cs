using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
		/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSARECVMSG (WSARecvMsg) extension function.</summary>
		public static readonly Guid WSAID_WSARECVMSG = new("{0xf689d7c8,0x6f1f,0x436b,{0x8a,0x53,0xe5,0x4f,0xe3,0x51,0xc3,0x22}}");

		/// <summary>
		/// <para>
		/// <c>LPFN_WSARECVMSG</c> is a function pointer type. You implement a matching <c>WSARecvMsg</c> callback function in your app. The
		/// system uses your callback function to transmit to you in-memory data, or file data, over a connected socket.
		/// </para>
		/// <para>
		/// Your <c>WSARecvMsg</c> callback function receives ancillary data/control information with a message, from connected and
		/// unconnected sockets.
		/// </para>
		/// <para>
		/// <para>Note</para>
		/// <para>This function is a Microsoft-specific extension to the Windows Sockets specification.</para>
		/// </para>
		/// </summary>
		/// <param name="s">
		/// <para>Type: _In_ <c>SOCKET</c></para>
		/// <para>A descriptor that identifies the socket.</para>
		/// </param>
		/// <param name="lpMsg">
		/// <para>Type: _Inout_ <c>LPWSAMSG</c></para>
		/// <para>A pointer to a <c>WSAMSG</c> structure based on the Posix.1g specification for the msghdr structure.</para>
		/// </param>
		/// <param name="lpdwNumberOfBytesRecvd">
		/// <para>Type: _Out_opt_ <c>LPDWORD</c></para>
		/// <para>
		/// A pointer to a <c>DWORD</c> containing number of bytes received by this call if the <c>WSARecvMsg</c> operation completes immediately.
		/// </para>
		/// <para>
		/// To avoid potentially erroneous results, pass <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> .
		/// This parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>Type: _Inout_opt_ <c>LPWSAOVERLAPPED</c></para>
		/// <para>A pointer to a <c>WSAOVERLAPPED</c> structure. Ignored for non-overlapped structures.</para>
		/// </param>
		/// <param name="lpCompletionRoutine">
		/// <para>Type: _In_opt_ <c>LPWSAOVERLAPPED_COMPLETION_ROUTINE</c></para>
		/// <para>A pointer to the completion routine called when the receive operation completes. Ignored for non-overlapped structures.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs and the receive operation has completed immediately, <c>WSARecvMsg</c> returns zero. In this case, the
		/// completion routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a
		/// value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling <c>WSAGetLastError</c>. The error code
		/// <c>WSA_IO_PENDING</c> indicates that the overlapped operation has been successfully initiated and that completion will be
		/// indicated at a later time.
		/// </para>
		/// <para>
		/// Any other error code indicates that the operation was not successfully initiated and no completion indication will occur if an
		/// overlapped operation was requested.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>WSAECONNRESET</c></term>
		/// <term>
		/// For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port Unreachable" message.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WSAEFAULT</c></term>
		/// <term>
		/// The <c>lpBuffers</c>, <c>lpFlags</c>, <c>lpFrom</c>, <c>lpNumberOfBytesRecvd</c>, <c>lpFromlen</c>, <c>lpOverlapped</c>, or
		/// <c>lpCompletionRoutine</c> parameter is not totally contained in a valid part of the user address space: the <c>lpFrom</c> buffer
		/// was too small to accommodate the peer address. This error is also returned if a <c>name</c> member of the <c>WSAMSG</c> structure
		/// pointed to by the <c>lpMsg</c> parameter was a <c>NULL</c> pointer and the <c>namelen</c> member of the <c>WSAMSG</c> structure
		/// was not set to zero. This error is also returned if a <c>Control.buf</c> member of the <c>WSAMSG</c> structure pointed to by the
		/// <c>lpMsg</c> parameter was a <c>NULL</c> pointer and the <c>Control.len</c> member of the <c>WSAMSG</c> structure was not set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WSAEINPROGRESS</c></term>
		/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
		/// </item>
		/// <item>
		/// <term><c>WSAEINTR</c></term>
		/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
		/// </item>
		/// <item>
		/// <term><c>WSAEINVAL</c></term>
		/// <term>The socket has not been bound (with <c>bind</c>, for example).</term>
		/// </item>
		/// <item>
		/// <term><c>WSAEMSGSIZE</c></term>
		/// <term>
		/// The message was too large to fit into the specified buffer and (for unreliable protocols only) any trailing portion of the
		/// message that did not fit into the buffer has been discarded.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WSAENETDOWN</c></term>
		/// <term>The network subsystem has failed.</term>
		/// </item>
		/// <item>
		/// <term><c>WSAENETRESET</c></term>
		/// <term>For a datagram socket, this error indicates that the time to live has expired.</term>
		/// </item>
		/// <item>
		/// <term><c>WSAENOTCONN</c></term>
		/// <term>The socket is not connected (connection-oriented sockets only).</term>
		/// </item>
		/// <item>
		/// <term><c>WSAETIMEDOUT</c></term>
		/// <term>
		/// The socket timed out. This error is returned if the socket had a wait timeout specified using the <c>SO_RCVTIMEO</c> socket
		/// option and the timeout was exceeded.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WSAEOPNOTSUPP</c></term>
		/// <term>
		/// The socket operation is not supported. This error is returned if the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed
		/// to by the <c>lpMsg</c> parameter includes the <c>MSG_PEEK</c> control flag on a non-datagram socket.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WSAEWOULDBLOCK</c></term>
		/// <term>
		/// <c>Windows NT:</c> Overlapped sockets: There are too many outstanding overlapped I/O requests. Non-overlapped sockets: The socket
		/// is marked as nonblocking and the receive operation cannot be completed immediately.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>WSANOTINITIALISED</c></term>
		/// <term>A successful <c>WSAStartup</c> call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term><c>WSA_IO_PENDING</c></term>
		/// <term>An overlapped operation was successfully initiated and completion will be indicated at a later time.</term>
		/// </item>
		/// <item>
		/// <term><c>WSA_OPERATION_ABORTED</c></term>
		/// <term>The overlapped operation has been canceled due to the closure of the socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WSARecvMsg</c> function can be used in place of the <c>WSARecv</c> and <c>WSARecvFrom</c> functions to receive data and
		/// optional control information from connected and unconnected sockets. The <c>WSARecvMsg</c> function can only be used with
		/// datagrams and raw sockets. The socket descriptor in the s parameter must be opened with the socket type set to <c>SOCK_DGRAM</c>
		/// or <c>SOCK_RAW</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> The function pointer for the <c>WSARecvMsg</c> function must be obtained at run time by making a call to the
		/// <c>WSAIoctl</c> function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
		/// <c>WSAIoctl</c> function must contain <c>WSAID_WSARECVMSG</c>, a globally unique identifier (GUID) whose value identifies the
		/// <c>WSARecvMsg</c> extension function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
		/// <c>WSARecvMsg</c> function. The <c>WSAID_WSARECVMSG</c> GUID is defined in the Mswsock.h header file.
		/// </para>
		/// <para>
		/// The <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter may only contain the <c>MSG_PEEK</c>
		/// control flag on input.
		/// </para>
		/// <para>
		/// Overlapped sockets are created with a <c>WSASocket</c> function call that has the <c>WSA_FLAG_OVERLAPPED</c> flag set. For
		/// overlapped sockets, receiving information uses overlapped I/O unless both the lpOverlapped and lpCompletionRoutine parameters are
		/// <c>NULL</c>. The socket is treated as a non-overlapped socket when both the lpOverlapped and lpCompletionRoutine parameters are <c>NULL</c>.
		/// </para>
		/// <para>
		/// A completion indication occurs with overlapped sockets. Once the buffer or buffers have been consumed by the transport, a
		/// completion routine is triggered or an event object is set. If the operation does not complete immediately, the final completion
		/// status is retrieved through the completion routine or by calling the <c>WSAGetOverlappedResult</c> function.
		/// </para>
		/// <para>
		/// For overlapped sockets, <c>WSARecvMsg</c> is used to post one or more buffers into which incoming data will be placed as it
		/// becomes available, after which the application-specified completion indication (invocation of the completion routine or setting
		/// of an event object) occurs. If the operation does not complete immediately, the final completion status is retrieved through the
		/// completion routine or the <c>WSAGetOverlappedResult</c> function.
		/// </para>
		/// <para>
		/// For non-overlapped sockets, the blocking semantics are identical to that of the standard <c>recv</c> function and the
		/// lpOverlapped and lpCompletionRoutine parameters are ignored. Any data that has already been received and buffered by the
		/// transport will be copied into the specified user buffers. In the case of a blocking socket with no data currently having been
		/// received and buffered by the transport, the call will block until data is received. Windows Sockets 2 does not define any
		/// standard blocking time-out mechanism for this function. For protocols acting as byte-stream protocols the stack tries to return
		/// as much data as possible subject to the available buffer space and amount of received data available. However, receipt of a
		/// single byte is sufficient to unblock the caller. There is no guarantee that more than a single byte will be returned. For
		/// protocols acting as message-oriented, a full message is required to unblock the caller.
		/// </para>
		/// <para><c>Note</c> The <c>SO_RCVTIMEO</c> socket option applies only to blocking sockets.</para>
		/// <para>
		/// The buffers are filled in the order in which they appear in the array pointed to by the <c>lpBuffers</c> member of the
		/// <c>WSAMSG</c> structure pointed to by the lpMsg parameter, and the buffers are packed so that no holes are created.
		/// </para>
		/// <para>
		/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture this
		/// <c>WSABUF</c> structure before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays
		/// pointed to by the <c>lpBuffers</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter.
		/// </para>
		/// <para>
		/// For message-oriented sockets (a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>), an incoming message is placed into the
		/// buffers up to the total size of the buffers, and the completion indication occurs for overlapped sockets. If the message is
		/// larger than the buffers, the buffers are filled with the first part of the message and the excess data is lost, and
		/// <c>WSARecvMsg</c> generates the error WSAEMSGSIZE.
		/// </para>
		/// <para>
		/// When the IP_PKTINFO socket option is enabled on an IPv4 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, the
		/// <c>WSARecvMsg</c> function returns packet information in the <c>WSAMSG</c> structure pointed to by the lpMsg parameter. One of
		/// the control data objects in the returned <c>WSAMSG</c> structure will contain an <c>in_pktinfo</c> structure used to store
		/// received packet address information.
		/// </para>
		/// <para>
		/// For datagrams received over IPv4, the <c>Control</c> member of the <c>WSAMSG</c> structure received will contain a <c>WSABUF</c>
		/// structure that contains a <c>WSACMSGHDR</c> structure. The <c>cmsg_level</c> member of this <c>WSACMSGHDR</c> structure would
		/// contain <c>IPPROTO_IP</c>, the <c>cmsg_type</c> member of this structure would contain <c>IP_PKTINFO</c>, and the
		/// <c>cmsg_data</c> member would contain an <c>in_pktinfo</c> structure used to store received IPv4 packet address information. The
		/// IPv4 address in the <c>in_pktinfo</c> structure is the IPv4 address from which the packet was received.
		/// </para>
		/// <para>
		/// When the IPV6_PKTINFO socket option is enabled on an IPv6 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, the
		/// <c>WSARecvMsg</c> function returns packet information in the <c>WSAMSG</c> structure pointed to by the lpMsg parameter. One of
		/// the control data objects in the returned <c>WSAMSG</c> structure will contain an <c>in6_pktinfo</c> structure used to store
		/// received packet address information.
		/// </para>
		/// <para>
		/// For datagrams received over IPv6, the <c>Control</c> member of the <c>WSAMSG</c> structure received will contain a <c>WSABUF</c>
		/// structure that contains a <c>WSACMSGHDR</c> structure. The <c>cmsg_level</c> member of this <c>WSACMSGHDR</c> structure would
		/// contain <c>IPPROTO_IPV6</c>, the <c>cmsg_type</c> member of this structure would contain <c>IPV6_PKTINFO</c>, and the
		/// <c>cmsg_data</c> member would contain an <c>in6_pktinfo</c> structure used to store received IPv6 packet address information. The
		/// IPv6 address in the <c>in6_pktinfo</c> structure is the IPv6 address from which the packet was received.
		/// </para>
		/// <para>
		/// For a dual-stack datagram socket, if an application requires the <c>WSARecvMsg</c> function to return packet information in a
		/// <c>WSAMSG</c> structure for datagrams received over IPv4, then IP_PKTINFO socket option must be set to true on the socket. If
		/// only the IPV6_PKTINFO option is set to true on the socket, packet information will be provided for datagrams received over IPv6
		/// but may not be provided for datagrams received over IPv4.
		/// </para>
		/// <para>Note that the Ws2ipdef.h header file is automatically included in Ws2tcpip.h, and should never be used directly.</para>
		/// <para>
		/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
		/// operations can fail if the thread is closed before the operations complete. For more information, see <c>ExitThread</c>.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// <para>dwFlags</para>
		/// <para>
		/// On input, the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter can be used to influence the
		/// behavior of the function invocation beyond the socket options specified for the associated socket. That is, the semantics of this
		/// function are determined by the socket options and the <c>dwFlags</c> member of the <c>WSAMSG</c> structure. The only possible
		/// input value for the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter is <c>MSG_PEEK</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_PEEK</term>
		/// <term>
		/// Peek at the incoming data. The data is copied into the buffer, but is not removed from the input queue. This flag is valid only
		/// for non-overlapped sockets.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The possible values for <c>dwFlags</c> member on input are defined in the Winsock2.h header file.</para>
		/// <para>
		/// On output, the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter may return a combination of
		/// any of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MSG_BCAST</term>
		/// <term>The datagram was received as a link-layer broadcast or with a destination IP address that is a broadcast address.</term>
		/// </item>
		/// <item>
		/// <term>MSG_CTRUNC</term>
		/// <term>The control (ancillary) data was truncated. More control data was present than the process allocated room for.</term>
		/// </item>
		/// <item>
		/// <term>MSG_MCAST</term>
		/// <term>The datagram was received with a destination IP address that is a multicast address.</term>
		/// </item>
		/// <item>
		/// <term>MSG_TRUNC</term>
		/// <term>The datagram was truncated. More data was present than the process allocated room for.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the possible values for the <c>dwFlags</c> member on output are defined in the Ws2def.h header file which is
		/// automatically included by the Winsock2.h header file.
		/// </para>
		/// <para>
		/// On versions of the Platform Software Development Kit (SDK) for Windows Server 2003 and earlier, the possible values for the
		/// <c>dwFlags</c> member on output are defined in the Mswsock.h header file.
		/// </para>
		/// <para>
		/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSARecvMsg</c> with the lpOverlapped parameter set to NULL, Winsock
		/// may need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which
		/// can be interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call
		/// inside an APC that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must
		/// never be attempted by Winsock clients.
		/// </para>
		/// <para>Overlapped Socket I/O</para>
		/// <para>
		/// If an overlapped operation completes immediately, <c>WSARecvMsg</c> returns a value of zero and the lpNumberOfBytesRecvd
		/// parameter is updated with the number of bytes received and the flag bits indicated by the lpFlags parameter are also updated. If
		/// the overlapped operation is successfully initiated and will complete later, <c>WSARecvMsg</c> returns <c>SOCKET_ERROR</c> and
		/// indicates error code WSA_IO_PENDING. In this case, lpNumberOfBytesRecvd is not updated. When the overlapped operation completes,
		/// the amount of data transferred is indicated either through the cbTransferred parameter in the completion routine (if specified),
		/// or through the lpcbTransfer parameter in <c>WSAGetOverlappedResult</c>. Flag values are obtained by examining the lpdwFlags
		/// parameter of <c>WSAGetOverlappedResult</c>.
		/// </para>
		/// <para>
		/// The <c>WSARecvMsg</c> function using overlapped I/O can be called from within the completion routine of a previous
		/// <c>WSARecv</c>, <c>WSARecvFrom</c>, <c>WSARecvMsg</c>, <c>WSASend</c>, <c>WSASendMsg</c>, or <c>WSASendTo</c> function. For a
		/// given socket, I/O completion routines will not be nested. This permits time-sensitive data transmissions to occur entirely within
		/// a preemptive context.
		/// </para>
		/// <para>
		/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are
		/// simultaneously outstanding, each must reference a separate <c>WSAOVERLAPPED</c> structure.
		/// </para>
		/// <para>
		/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped
		/// operation completes if it contains a valid event object handle. An application can use <c>WSAWaitForMultipleEvents</c> or
		/// <c>WSAGetOverlappedResult</c> to wait or poll on the event object.
		/// </para>
		/// <para>
		/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
		/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
		/// <c>WSAGetOverlappedResult</c> for the same overlapped I/O request may not set the fWait parameter for that invocation of
		/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case the usage of the hEvent parameter is undefined, and attempting to wait
		/// on the hEvent parameter would produce unpredictable results.
		/// </para>
		/// <para>
		/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine will
		/// not be invoked until the thread is in an alertable wait state such as can occur when the function <c>WSAWaitForMultipleEvents</c>
		/// with the fAlertable parameter set to <c>TRUE</c> is invoked.
		/// </para>
		/// <para>The prototype of the completion routine is as follows:</para>
		/// <para>
		/// <code> void CALLBACK CompletionRoutine( IN DWORD dwError, IN DWORD cbTransferred, IN LPWSAOVERLAPPED lpOverlapped, IN DWORD dwFlags );</code>
		/// </para>
		/// <para>
		/// The <c>CompletionRoutine</c> is a placeholder for an application-defined or library-defined function name. The dwError parameter
		/// specifies the completion status for the overlapped operation as indicated by the lpOverlapped parameter. The cbTransferred
		/// parameter specifies the number of bytes received. The dwFlags parameter contains information that is also returned in
		/// <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter if the receive operation had completed
		/// immediately. The <c>CompletionRoutine</c> function does not return a value.
		/// </para>
		/// <para>
		/// Returning from this function allows invocation of another pending completion routine for this socket. When using
		/// <c>WSAWaitForMultipleEvents</c>, all waiting completion routines are called before the alertable thread's wait is satisfied with
		/// a return code of <c>WSA_IO_COMPLETION</c>. The completion routines can be called in any order, not necessarily in the same order
		/// the overlapped operations are completed. However, the posted buffers are guaranteed to be filled in the same order in which they
		/// are specified.
		/// </para>
		/// <para>
		/// If you are using I/O completion ports, be aware that the order of calls made to <c>WSARecvMsg</c> is also the order in which the
		/// buffers are populated. The <c>WSARecvMsg</c> function should not be called on the same socket simultaneously from different
		/// threads, because it can result in an unpredictable buffer order.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_wsarecvmsg
		// LPFN_WSARECVMSG LpfnWsarecvmsg; INT LpfnWsarecvmsg( SOCKET s, LPWSAMSG lpMsg, LPDWORD lpdwNumberOfBytesRecvd, LPWSAOVERLAPPED lpOverlapped, LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine ) {...}
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_WSARECVMSG")]
		public delegate int LPFN_WSARECVMSG(SOCKET s, ref WSAMSG lpMsg, out uint lpdwNumberOfBytesRecvd, ref WSAOVERLAPPED lpOverlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);

		/*
		AcceptEx function
		GetAcceptExSockaddrs function
		LPFN_CONNECTEX callback function
		LPFN_DISCONNECTEX callback function
		LPFN_RIOCLOSECOMPLETIONQUEUE callback function
		LPFN_RIOCREATECOMPLETIONQUEUE callback function
		LPFN_RIOCREATEREQUESTQUEUE callback function
		LPFN_RIODEQUEUECOMPLETION callback function
		LPFN_RIODEREGISTERBUFFER callback function
		LPFN_RIONOTIFY callback function
		LPFN_RIORECEIVE callback function
		LPFN_RIORECEIVEEX callback function
		LPFN_RIOREGISTERBUFFER callback function
		LPFN_RIORESIZECOMPLETIONQUEUE callback function
		LPFN_RIORESIZEREQUESTQUEUE callback function
		LPFN_RIOSEND callback function
		LPFN_RIOSENDEX callback function
		LPFN_TRANSMITPACKETS callback function
		RIO_EXTENSION_FUNCTION_TABLE structure
		RIO_NOTIFICATION_COMPLETION structure
		RIO_NOTIFICATION_COMPLETION_TYPE enumeration
		TRANSMIT_FILE_BUFFERS structure
		TRANSMIT_PACKETS_ELEMENT structure
		TransmitFile function
		WSARecvEx function
		*/
	}
}