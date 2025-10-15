using System.Threading;

namespace Vanara.PInvoke;

public static partial class Ws2_32
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public const int SO_CONNDATA = 0x7000;
	public const int SO_CONNDATALEN = 0x7004;
	/// <summary>
	/// Returns the number of seconds a socket has been connected. This socket option is valid for connection oriented protocols only.
	/// </summary>
	[CorrespondingType(typeof(uint))]
	public const int SO_CONNECT_TIME = 0x700C;
	public const int SO_CONNOPT = 0x7001;
	public const int SO_CONNOPTLEN = 0x7005;
	public const int SO_DISCDATA = 0x7002;
	public const int SO_DISCDATALEN = 0x7006;
	public const int SO_DISCOPT = 0x7003;
	public const int SO_DISCOPTLEN = 0x7007;
	public const int SO_MAXDG = 0x7009;
	public const int SO_MAXPATHDG = 0x700A;
	public const int SO_OPENTYPE = 0x7008;
	public const int SO_SYNCHRONOUS_ALERT = 0x10;
	public const int SO_SYNCHRONOUS_NONALERT = 0x20;
	public const int SO_UPDATE_ACCEPT_CONTEXT = 0x700B;
	public const int SO_UPDATE_CONNECT_CONTEXT = 0x7010;
	public const int TCP_BSDURGENT = 0x7000;
	public static readonly uint SIO_BASE_HANDLE = _WSAIOR(IOC_WS2, 34);
	public static readonly uint SIO_BSP_HANDLE = _WSAIOR(IOC_WS2, 27);
	public static readonly uint SIO_BSP_HANDLE_POLL = _WSAIOR(IOC_WS2, 29);
	public static readonly uint SIO_BSP_HANDLE_SELECT = _WSAIOR(IOC_WS2, 28);
	public static readonly uint SIO_EXT_POLL = _WSAIORW(IOC_WS2, 31);
	public static readonly uint SIO_EXT_SELECT = _WSAIORW(IOC_WS2, 30);
	public static readonly uint SIO_EXT_SENDMSG = _WSAIORW(IOC_WS2, 32);
	public static readonly uint SIO_SOCKET_CLOSE_NOTIFY = _WSAIOW(IOC_VENDOR, 13);
	public static readonly uint SIO_UDP_CONNRESET = _WSAIOW(IOC_VENDOR, 12);
	public static readonly uint SIO_UDP_NETRESET = _WSAIOW(IOC_VENDOR, 15);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSARECVMSG (WSARecvMsg) extension function.</summary>
	public static readonly Guid WSAID_WSARECVMSG = new(0xf689d7c8,0x6f1f,0x436b,0x8a,0x53,0xe5,0x4f,0xe3,0x51,0xc3,0x22);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSASENDMSG (WSASendMsg) extension function.</summary>
	public static readonly Guid WSAID_WSASENDMSG = new(0xa441e712,0x754f,0x43ca,0x84,0xa7,0x0d,0xee,0x44,0xcf,0x60,0x6d);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSACONNECTEX extension function.</summary>
	public static readonly Guid WSAID_CONNECTEX = new(0x25a207b9,0xddf3,0x4660,0x8e,0xe9,0x76,0xe5,0x8c,0x74,0x06,0x3e);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSADISCONNECTEX extension function.</summary>
	public static readonly Guid WSAID_DISCONNECTEX = new( 0x7fda2e11,0x8630,0x436f,0xa0, 0x31, 0xf5, 0x36, 0xa6, 0xee, 0xc1, 0x57);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSAPOLL extension function.</summary>
	public static readonly Guid WSAID_WSAPOLL = new(0x18C76F85,0xDC66,0x4964,0x97,0x2E,0x23,0xC2,0x72,0x38,0x31,0x2B);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSAMULTIPLE_RIO extension function.</summary>
	public static readonly Guid WSAID_MULTIPLE_RIO = new(0x8509e081,0x96dd,0x4005,0xb1,0x65,0x9e,0x2e,0xe8,0xc7,0x9e,0x3f);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSATRANSMITPACKETS extension function.</summary>
	public static readonly Guid WSAID_TRANSMITPACKETS = new( 0xd9689da0,0x1f90,0x11d3,0x99,0x71,0x00,0xc0,0x4f,0x68,0xc8,0x76);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSATRANSMITFILE extension function.</summary>
	public static readonly Guid WSAID_TRANSMITFILE = new( 0xb5367df0,0xcbac,0x11cf,0x95,0xca,0x00,0x80,0x5f,0x48,0xa1,0x92);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSAACCEPTEX (AcceptEx) extension function.</summary>
	public static readonly Guid WSAID_ACCEPTEX = new( 0xb5367df1,0xcbac,0x11cf,0x95,0xca,0x00,0x80,0x5f,0x48,0xa1,0x92);

	/// <summary>GUID value used by SIO_GET_EXTENSION_FUNCTION_POINTER to get the LPFN_WSAGETACCEPTEXSOCKADDRS extension function.</summary>
	public static readonly Guid WSAID_GETACCEPTEXSOCKADDRS = new(0xb5367df2,0xcbac,0x11cf,0x95,0xca,0x00,0x80,0x5f,0x48,0xa1,0x92);

	/// <summary/>
	public static readonly Guid NLA_NAMESPACE_GUID = new( 0x6642243a,0x3ba8,0x4aa6,0xba,0xa5,0x2e,0xb,0xd7,0x1f,0xdd,0x83);

	/// <summary/>
	public static readonly Guid NLA_SERVICE_CLASS_GUID = new(0x37e515,0xb5c9,0x4a43,0xba,0xda,0x8b,0x48,0xa8,0x7a,0xd2,0x39);

	private const string Lib_Mswsock = "mswsock.dll";

	/// <summary>
	/// The <c>ConnectEx</c> function establishes a connection to a specified socket, and optionally sends data once the connection is
	/// established. The <c>ConnectEx</c> function is only supported on connection-oriented sockets.
	/// </summary>
	/// <param name="s">A descriptor that identifies an unconnected, previously bound socket. See Remarks for more information.</param>
	/// <param name="name">
	/// A pointer to a sockaddr structure that specifies the address to which to connect. For IPv4, the <c>sockaddr</c> contains
	/// <c>AF_INET</c> for the address family, the destination IPv4 address, and the destination port. For IPv6, the <c>sockaddr</c>
	/// structure contains <c>AF_INET6</c> for the address family, the destination IPv6 address, the destination port, and may contain
	/// additional IPv6 flow and scope-id information.
	/// </param>
	/// <param name="namelen">The length, in bytes, of the sockaddr structure pointed to by the <c>name</c> parameter.</param>
	/// <param name="lpSendBuffer">
	/// A pointer to the buffer to be transferred after a connection is established. This parameter is optional. If the TCP_FASTOPEN option
	/// is enabled on <c>s</c> before <c>ConnectEx</c> is called, then some of this data may be sent during connection establishment.
	/// </param>
	/// <param name="dwSendDataLength">
	/// The length, in bytes, of data pointed to by the <c>lpSendBuffer</c> parameter. This parameter is ignored when the <c>lpSendBuffer</c>
	/// parameter is <c>NULL</c>.
	/// </param>
	/// <param name="lpdwBytesSent">
	/// On successful return, this parameter points to a <c>DWORD</c> value that indicates the number of bytes that were sent after the
	/// connection was established. The bytes sent are from the buffer pointed to by the <c>lpSendBuffer</c> parameter. This parameter is
	/// ignored when the <c>lpSendBuffer</c> parameter is <c>NULL</c>.
	/// </param>
	/// <param name="lpOverlapped">
	/// An OVERLAPPED structure used to process the request. The <c>lpOverlapped</c> parameter must be specified, and cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// On success, the <c>ConnectEx</c> function returns <c>TRUE</c>. On failure, the function returns <c>FALSE</c>. Use the WSAGetLastError
	/// function to get extended error information. If a call to the <c>WSAGetLastError</c> function returns <c>ERROR_IO_PENDING</c>, the
	/// operation initiated successfully and is in progress. Under such circumstances, the call may still fail when the overlapped operation completes.
	/// </para>
	/// <para>
	/// If the error code returned is WSAECONNREFUSED, WSAENETUNREACH, or WSAETIMEDOUT, the application can call <c>ConnectEx</c>,
	/// WSAConnect, or connect again on the same socket.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSANOTINITIALISED</c></term>
	/// <term>A successful WSAStartup function call must occur before using ConnectEx.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETDOWN</c></term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEADDRINUSE</c></term>
	/// <term>
	/// The local address of the socket is already in use, and the socket was not marked to allow address reuse with SO_REUSEADDR. This error
	/// usually occurs during a bind operation, but the error could be delayed until a ConnectEx function call, if the <c>bind</c> function
	/// was called with a wildcard address ( <c>INADDR_ANY</c> or <c>in6addr_any</c>) specified for the local IP address. A specific IP
	/// address needs to be implicitly bound by the <c>ConnectEx</c> function.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEALREADY</c></term>
	/// <term>A nonblocking connect, WSAConnect, or ConnectEx function call is in progress on the specified socket.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEADDRNOTAVAIL</c></term>
	/// <term>
	/// The remote address is not a valid address, such as ADDR_ANY (the ConnectEx function is only supported for connection-oriented sockets).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>Addresses in the specified family cannot be used with this socket.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAECONNREFUSED</c></term>
	/// <term>The attempt to connect was rejected.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The <c>name</c>, <c>lpSendBuffer</c>, or <c>lpOverlapped</c> parameter is not a valid part of the user address space, or
	/// <c>namelen</c> is too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>The parameter <c>s</c> is an unbound or a listening socket.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEISCONN</c></term>
	/// <term>The socket is already connected.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETUNREACH</c></term>
	/// <term>The network cannot be reached from this host at this time.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEHOSTUNREACH</c></term>
	/// <term>A socket operation was attempted to an unreachable host.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>No buffer space is available; the socket cannot be connected.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor is not a socket.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAETIMEDOUT</c></term>
	/// <term>The attempt to connect timed out without establishing a connection.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ConnectEx</c> function combines several socket functions into a single API/kernel transition. The following operations are
	/// performed when a call to the <c>ConnectEx</c> function completes successfully:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>A new connection is established.</term>
	/// </item>
	/// <item>
	/// <term>An optional block of data is sent after the connection is established.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For applications targeted to Windows Vista and later, consider using the WSAConnectByList or WSAConnectByName function which greatly
	/// simplify client application design.
	/// </para>
	/// <para>
	/// The <c>ConnectEx</c> function can only be used with connection-oriented sockets. The socket passed in the <c>s</c> parameter must be
	/// created with a socket type of <c>SOCK_STREAM</c>, <c>SOCK_RDM</c>, or <c>SOCK_SEQPACKET</c>.
	/// </para>
	/// <para>
	/// The <c>lpSendBuffer</c> parameter points to a buffer of data to send after the connection is established. The <c>dwSendDataLength</c>
	/// parameter specifies the length in bytes of this data to send. An application can request to send a large buffer of data using the
	/// <c>ConnectEx</c> in the same way that the send and WSASend functions can be used. But developers are strongly advised against sending
	/// a huge buffer in a single call using <c>ConnectEx</c>, because this operation uses a large amount of system memory resources until
	/// the whole buffer has been sent.
	/// </para>
	/// <para>
	/// If the <c>ConnectEx</c> function is successful, a connection was established and all of the data pointed to by the
	/// <c>lpSendBuffer</c> parameter was sent to the address specified in the <c>sockaddr</c> structure pointed to by the <c>name</c> parameter.
	/// </para>
	/// <para>
	/// <c>Note</c> The function pointer for the <c>ConnectEx</c> function must be obtained at run time by making a call to the WSAIoctl
	/// function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_CONNECTEX</c>, a globally unique identifier (GUID) whose value identifies the <c>ConnectEx</c> extension
	/// function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the <c>ConnectEx</c> function. The
	/// <c>WSAID_CONNECTEX</c> GUID is defined in the <c>Mswsock.h</c> header file.
	/// </para>
	/// <para>
	/// The <c>ConnectEx</c> function uses overlapped I/O. As a result, the <c>ConnectEx</c> function enables an application to service a
	/// large number of clients with relatively few threads. In contrast, the WSAConnect function, which does not use overlapped I/O, usually
	/// requires a separate thread to service each connection request when simultaneous requests are received.
	/// </para>
	/// <para>
	/// Connection-oriented sockets are often unable to complete their connection immediately, and therefore the operation is initiated and
	/// the function immediately returns with the ERROR_IO_PENDING or WSA_IO_PENDING error. When the connect operation completes and success
	/// or failure is achieved, status is reported using the completion notification mechanism indicated in <c>lpOverlapped</c>. As with all
	/// overlapped function calls, you can use events or completion ports as the completion notification mechanism. The
	/// <c>lpNumberOfBytesTransferred</c> parameter of the GetQueuedCompletionStatus or GetOverlappedResult or WSAGetOverlappedResult
	/// function indicates the number of bytes sent in the request.
	/// </para>
	/// <para>When the <c>ConnectEx</c> function successfully completes, socket handle <c>s</c> can be passed to only the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ReadFile</term>
	/// </item>
	/// <item>
	/// <term>WriteFile</term>
	/// </item>
	/// <item>
	/// <term>send or WSASend</term>
	/// </item>
	/// <item>
	/// <term>recv or WSARecv</term>
	/// </item>
	/// <item>
	/// <term>TransmitFile</term>
	/// </item>
	/// <item>
	/// <term>closesocket</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the TransmitFile function is called on a previously connected socket with both TF_DISCONNECT and TF_REUSE_SOCKET flags, the
	/// specified socket is returned to a state in which it is not connected, but still bound. In such cases, the handle of the socket can be
	/// passed to the <c>ConnectEx</c> function in its <c>s</c> parameter, but the socket cannot be reused in an AcceptEx function call.
	/// Similarly, the accepted socket reused using the <c>TransmitFile</c> function cannot be used in a call to <c>ConnectEx</c>. Note that
	/// in the case of a reused socket, <c>ConnectEx</c> is subject to the behavior of the underlying transport. For example, a TCP socket
	/// may be subject to the TCP TIME_WAIT state, causing the <c>ConnectEx</c> call to be delayed.
	/// </para>
	/// <para>
	/// When the <c>ConnectEx</c> function returns <c>TRUE</c>, the socket <c>s</c> is in the default state for a connected socket. The
	/// socket <c>s</c> does not enable previously set properties or options until SO_UPDATE_CONNECT_CONTEXT is set on the socket. Use the
	/// setsockopt function to set the SO_UPDATE_CONNECT_CONTEXT option.
	/// </para>
	/// <para>For example:</para>
	/// <para>
	/// The getsockopt function can be used with the <c>SO_CONNECT_TIME</c> socket option to check whether a connection has been established
	/// while <c>ConnectEx</c> is in progress. If a connection has been established, the value returned in the <c>optval</c> parameter passed
	/// to the <c>getsockopt</c> function is the number of seconds the socket has been connected. If the socket is not connected, the
	/// returned <c>optval</c> parameter contains 0xFFFFFFFF. Checking a connection in this manner is necessary to determine whether
	/// connections have been established for a period of time without sending any data; in such cases, it is recommended that such
	/// connections be terminated.
	/// </para>
	/// <para>For example:</para>
	/// <para>
	/// <c>Note</c> If a socket is opened, a setsockopt call is made, and then a sendto call is made, Windows Sockets performs an implicit
	/// bind function call.
	/// </para>
	/// <para>
	/// If the address parameter of the sockaddr structure pointed to in the <c>name</c> parameter is all zeros, <c>ConnectEx</c> returns the
	/// error WSAEADDRNOTAVAIL. Any attempt to reconnect an active connection will fail with the error code WSAEISCONN.
	/// </para>
	/// <para>
	/// When a connected socket becomes closed for any reason, it is recommended that the socket be discarded and a new socket created. The
	/// reasoning for this is that it is safest to assume that when things go awry on a connected socket for any reason, the application must
	/// discard the socket and create the needed socket again in order to return to a stable point.
	/// </para>
	/// <para>
	/// If the DisconnectEx function is called with the <c>TF_REUSE_SOCKET</c> flag, the specified socket is returned to a state in which it
	/// is not connected, but still bound. In such cases, the handle of the socket can be passed to the <c>ConnectEx</c> function in its
	/// <c>s</c> parameter.
	/// </para>
	/// <para>
	/// The interval of time that must elapse before TCP can release a closed connection and reuse its resources is known as the TIME_WAIT
	/// state or the 2MSL state. During this time, the connection can be reopened at much less cost to the client and server than
	/// establishing a new connection.
	/// </para>
	/// <para>
	/// The TIME_WAIT behavior is specified in RFC 793, which requires that TCP maintains a closed connection for an interval at least equal
	/// to twice the maximum segment lifetime (MSL) of the network. When a connection is released, its socket pair and internal resources
	/// used for the socket can be used to support another connection.
	/// </para>
	/// <para>
	/// Windows TCP reverts to a TIME_WAIT state subsequent to the closing of a connection. While in the TIME_WAIT state, a socket pair
	/// cannot be reused. The TIME_WAIT period is configurable by modifying the following <c>DWORD</c> registry setting that represents the
	/// TIME_WAIT period in seconds.
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>\ <c>System</c>\ <c>CurrentControlSet</c>\ <c>Services</c>\ <c>TCPIP</c>\ <c>Parameters</c>\ <c>TcpTimedWaitDelay</c></para>
	/// <para>
	/// By default, the MSL is defined to be 120 seconds. The TcpTimedWaitDelay registry setting defaults to a value 240 seconds, which
	/// represents 2 times the maximum segment lifetime of 120 seconds or 4 minutes. However, you can use this entry to customize the interval.
	/// </para>
	/// <para>
	/// Reducing the value of this entry allows TCP to release closed connections faster, providing more resources for new connections.
	/// However, if the value is too low, TCP might release connection resources before the connection is complete, requiring the server to
	/// use additional resources to re-establish the connection.
	/// </para>
	/// <para>This registry setting can be set from 0 to 300 seconds.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_connectex LPFN_CONNECTEX LpfnConnectex; BOOL
	// LpfnConnectex( [in] SOCKET s, [in] const sockaddr *name, [in] int namelen, [in, optional] PVOID lpSendBuffer, [in] DWORD
	// dwSendDataLength, [out] LPDWORD lpdwBytesSent, [in] LPOVERLAPPED lpOverlapped ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_CONNECTEX")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_CONNECTEX([In] SOCKET s, [In] SOCKADDR name, int namelen, [In, Optional] IntPtr lpSendBuffer,
		uint dwSendDataLength, out uint lpdwBytesSent, in NativeOverlapped lpOverlapped);

	/// <summary>
	/// <para>The <c>DisconnectEx</c> function closes a connection on a socket, and allows the socket handle to be reused.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>This function is a Microsoft-specific extension to the Windows Sockets specification.</para>
	/// </para>
	/// </summary>
	/// <param name="s">A handle to a connected, connection-oriented socket.</param>
	/// <param name="lpOverlapped">
	/// A pointer to an <c>OVERLAPPED</c> structure. If the socket handle has been opened as overlapped, specifying this parameter results in
	/// an overlapped (asynchronous) I/O operation.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that customizes processing of the function call. When this parameter is set to zero, no flags are set. The dwFlags
	/// parameter can have the following value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>TF_REUSE_SOCKET</c></term>
	/// <term>
	/// Prepares the socket handle to be reused. When the <c>DisconnectEx</c> request completes, the socket handle can be passed to the [
	/// <c>AcceptEx</c>](./nf-mswsock-acceptex.md) or [ <c>ConnectEx</c>](./nc-mswsock-lpfn_connectex.md) function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">Reserved. Must be zero. If nonzero, WSAEINVAL is returned.</param>
	/// <returns>
	/// <para>
	/// On success, the <c>DisconnectEx</c> function returns <c>TRUE</c>. On failure, the function returns <c>FALSE</c>. Use the
	/// <c>WSAGetLastError</c> function to get extended error information. If a call to the <c>WSAGetLastError</c> function returns
	/// <c>ERROR_IO_PENDING</c>, the operation initiated successfully and is in progress. Under such circumstances, the call may still fail
	/// when the operation completes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument. This error is returned if an invalid pointer
	/// value was passed in the <c>lpOverlapped</c> parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// The invalid parameter was passed. This error is returned if the <c>dwFlags</c> parameter was specified with a zero value other than <c>TF_REUSE_SOCKET</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTCONN</c></term>
	/// <term>
	/// The socket is not connected. This error is returned if the socket <c>s</c> parameter was not in a connected state. This error can
	/// also be returned if the socket was in the transmit closing state from a previous request and the <c>dwFlags</c> parameter was not set
	/// to <c>TF_REUSE_SOCKET</c> to request a reuse of the socket.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DisconnectEx</c> function does not support datagram sockets. Therefore, the socket specified by hSocket must be
	/// connection-oriented, such as a SOCK_STREAM, SOCK_SEQPACKET, or SOCK_RDM socket.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer for the <c>DisconnectEx</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c>
	/// function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_DISCONNECTEX</c>, a globally unique identifier (GUID) whose value identifies the <c>DisconnectEx</c> extension
	/// function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the <c>DisconnectEx</c> function. The
	/// <c>WSAID_DISCONNECTEX</c> GUID is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para>
	/// When <c>lpOverlapped</c> is not <c>NULL</c>, overlapped I/O might not finish before <c>DisconnectEx</c> returns, resulting in the
	/// <c>DisconnectEx</c> function returning <c>FALSE</c> and a call to the <c>WSAGetLastError</c> function returning
	/// <c>ERROR_IO_PENDING</c>. This design enables the caller to continue processing while the disconnect operation completes. Upon
	/// completion of the request, Windows sets either the event specified by the <c>hEvent</c> member of the <c>OVERLAPPED</c> structure, or
	/// the socket specified by hSocket, to the signaled state.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous operations can
	/// fail if the thread is closed before the operations complete. See <c>ExitThread</c> for more information.
	/// </para>
	/// </para>
	/// <para>
	/// The TIME_WAIT state determines the time that must elapse before TCP can release a closed connection and reuse its resources. This
	/// interval between closure and release is known as the TIME_WAIT state or 2MSL state. During this time, the connection can be reopened
	/// at much less cost to the client and server than establishing a new connection. The TIME_WAIT behavior is specified in RFC 793 which
	/// requires that TCP maintains a closed connection for an interval at least equal to twice the maximum segment lifetime (MSL) of the
	/// network. When a connection is released, its socket pair and internal resources used for the socket can be used to support another connection.
	/// </para>
	/// <para>
	/// Windows TCP reverts to a TIME_WAIT state subsequent to the closing of a connection. While in the TIME_WAIT state, a socket pair
	/// cannot be re-used. The TIME_WAIT period is configurable by modifying the following DWORD registry setting that represents the
	/// TIME_WAIT period in seconds.
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>\ <c>System</c>\ <c>CurrentControlSet</c>\ <c>Services</c>\ <c>TCPIP</c>\ <c>Parameters</c>\ <c>TcpTimedWaitDelay</c></para>
	/// <para>
	/// By default, the MSL is defined to be 120 seconds. The TcpTimedWaitDelay registry setting defaults to a value 240 seconds, which
	/// represents 2 times the maximum segment lifetime of 120 seconds or 4 minutes. However, you can use this entry to customize the
	/// interval. Reducing the value of this entry allows TCP to release closed connections faster, providing more resources for new
	/// connections. However, if the value is too low, TCP might release connection resources before the connection is complete, requiring
	/// the server to use additional resources to re-establish the connection. This registry setting can be set from 0 to 300 seconds.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_disconnectex LPFN_DISCONNECTEX LpfnDisconnectex; BOOL
	// LpfnDisconnectex( SOCKET s, LPOVERLAPPED lpOverlapped, DWORD dwFlags, DWORD dwReserved ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_DISCONNECTEX")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_DISCONNECTEX(SOCKET s, in NativeOverlapped lpOverlapped, TF dwFlags, uint dwReserved = 0);

	/// <summary>
	/// The <c>RIOCloseCompletionQueue</c> function closes an existing completion queue used for I/O completion notification by send and
	/// receive requests with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="CQ">A descriptor identifying an existing completion queue.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The <c>RIOCloseCompletionQueue</c> function closes an existing completion queue used for I/O completion. The <c>RIO_CQ</c> passed in
	/// the CQ parameter is locked for writing by the kernel. The completion queue is marked as invalid, so that new completions cannot be
	/// added. Any new completions to be added are silently dropped. The application is expected to tracking any pending send or receive operations.
	/// </para>
	/// <para>
	/// If an invalid completion queue is passed in the CQ parameter ( <c>RIO_INVALID_CQ</c>, for example), this is ignored by the
	/// <c>RIOCloseCompletionQueue</c> function.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOCloseCompletionQueue</c> function must be obtained at run time by making a call to the
	/// <c>WSAIoctl</c> function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
	/// <c>WSAIoctl</c> function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the
	/// Winsock registered I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioclosecompletionqueue LPFN_RIOCLOSECOMPLETIONQUEUE
	// LpfnRioclosecompletionqueue; void LpfnRioclosecompletionqueue( RIO_CQ CQ ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIOCLOSECOMPLETIONQUEUE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void LPFN_RIOCLOSECOMPLETIONQUEUE(RIO_CQ CQ);

	/// <summary>
	/// The <c>RIOCreateCompletionQueue</c> function creates an I/O completion queue of a specific size for use with the Winsock registered
	/// I/O extensions.
	/// </summary>
	/// <param name="QueueSize">The size, in number of entries, of the completion queue to create.</param>
	/// <param name="NotificationCompletion">
	/// <para>
	/// The type of notification completion to use based on the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure (I/O
	/// completion or event notification).
	/// </para>
	/// <para>
	/// If the <c>Type</c> member is set to <c>RIO_EVENT_COMPLETION</c>, then the <c>Event</c> member of the
	/// <c>RIO_NOTIFICATION_COMPLETION</c> structure must be set.
	/// </para>
	/// <para>
	/// If the <c>Type</c> member is set to <c>RIO_IOCP_COMPLETION</c>, then the <c>Iocp</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c>
	/// structure must be set and the <c>Iocp.Overlapped</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure must not be NULL.
	/// </para>
	/// <para>
	/// If the NotificationCompletion parameter is NULL, this specifies no notification completion is used and that polling must be used to
	/// determine completion.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOCreateCompletionQueue</c> function returns a descriptor referencing a new completion queue. Otherwise,
	/// a value of <c>RIO_INVALID_CQ</c> is returned, and a specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>The system detected an invalid pointer address in attempting to use a pointer argument in a call.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>QueueSize</c> parameter is less than 1 or greater
	/// than <c>RIO_MAX_CQ_SIZE</c> defined in the <c>Mswsockdef.h</c> header file.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// Sufficient memory could not be allocated. This error is returned if there was insufficient memory to allocate the completion queue
	/// requested based on the <c>QueueSize</c> parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RIOCreateCompletionQueue</c> function creates an I/O completion queue of a specific size. The size of the completion queue
	/// restricts the set of registered I/O sockets that can be associated with the completion queue. For more information, see the
	/// <c>RIOCreateRequestQueue</c> function.
	/// </para>
	/// <para>
	/// When creating a <c>RIO_CQ</c>, the <c>RIO_NOTIFICATION_COMPLETION</c> structure pointed to by the NotificationCompletion parameter
	/// determines how the application will receive completion queue notifications. If a <c>RIO_NOTIFICATION_COMPLETION</c> structure is
	/// provided when creating the completion queue, the application may call the <c>RIONotify</c> function to request a completion queue
	/// notification. Normally this notification occurs when the completion queue is not empty. This may happen immediately or when the next
	/// completion entry is inserted into the completion queue. However, send and receive requests may be flagged as
	/// <c>RIO_MSG_DONT_NOTIFY</c>. Completion queue notification and will never be triggered as a result of such requests. If the completion
	/// queue contains only entries with the <c>RIO_MSG_DONT_NOTIFY</c> flag set, the completion queue notification will not be triggered.
	/// Also, when a new entry enters the completion queue, the completion queue notification is only triggered if the
	/// <c>RIO_MSG_DONT_NOTIFY</c> flag was not set on the associated request. Any completed requests can still be retrieved by polling using
	/// the <c>RIODequeueCompletion</c> function. Once a completion queue notification is issued, the application must call the
	/// <c>RIONotify</c> function in order to receive another completion queue notification. When a completion queue notification occurs, the
	/// application typically calls the <c>RIODequeueCompletion</c> function to dequeue the completed send or receive requests.
	/// </para>
	/// <para>Two options are available for completion queue notification.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Event handles.</term>
	/// </item>
	/// <item>
	/// <term>I/O completion ports</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure is set to <c>RIO_EVENT_COMPLETION</c>, an event handle
	/// is used to signal completion queue notifications. An event handle is provided as the <c>EventNotify.EventHandle</c> member in the
	/// <c>RIO_NOTIFICATION_COMPLETION</c> structure passed to the <c>RIOCreateCompletionQueue</c> function. The <c>Event.EventHandle</c>
	/// member should contain the handle for an event created by the <c>WSACreateEvent</c> or <c>CreateEvent</c> function. To receive the
	/// <c>RIONotify</c> completion, the application should wait on the specified event handle using <c>WSAWaitForMultipleEvents</c> or a
	/// similar wait routine. The completion of the <c>RIONotify</c> function for this <c>RIO_CQ</c> will signal the event. The
	/// <c>Event.NotifyReset</c> member in the <c>RIO_NOTIFICATION_COMPLETION</c> structure passed to the <c>RIOCreateCompletionQueue</c>
	/// function indicates whether or not the event should be reset as part of a call to the <c>RIONotify</c> function. If the application
	/// plans to reset and reuse the event, the application can reduce overhead by setting the <c>Event.NotifyReset</c> member to a non-zero
	/// value. This causes the event to be automatically reset by the <c>RIONotify</c> function when the notification occurs. This mitigates
	/// the need to call the <c>WSAResetEvent</c> function to reset the event between calls to the <c>RIONotify</c> function.
	/// </para>
	/// <para>
	/// If the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure is set to <c>RIO_IOCP_COMPLETION</c>, an I/O completion
	/// port is used to signal completion queue notifications. An I/O completion port handle is provided as the <c>Iocp.IocpHandle</c> member
	/// in the <c>RIO_NOTIFICATION_COMPLETION</c> structure passed to the <c>RIOCreateCompletionQueue</c> function. The completion of the
	/// <c>RIONotify</c> function for this <c>RIO_CQ</c> will queue an entry to the I/O completion port which can be retrieved using the
	/// <c>GetQueuedCompletionStatus</c> or <c>GetQueuedCompletionStatusEx</c> function. A queued entry will have the returned
	/// lpCompletionKey parameter value set to the value specified in <c>Iocp.CompletionKey</c> member of the
	/// <c>RIO_NOTIFICATION_COMPLETION</c> structure and the <c>Iocp.Overlapped</c> member in the <c>RIO_NOTIFICATION_COMPLETION</c>
	/// structure will be a non-NULL value.
	/// </para>
	/// <para>
	/// In terms of its usage, completion queue notification is designed to wake up a waiting application thread so that the thread can
	/// examine the completion queue. Waking and scheduling a thread comes at a cost, so if this happens too frequently it will have a
	/// negative impact on the application performance. The <c>RIO_MSG_DONT_NOTIFY</c> flag is provided so that the application can control
	/// the frequency of these events and limit their over impact on performance.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For purposes of efficiency, access to the completion queues ( <c>RIO_CQ</c> structs) and request queues ( <c>RIO_RQ</c> structs) are
	/// not protected by synchronization primitives. If you need to access a completion or request queue from multiple threads, access should
	/// be coordinated by a critical section, slim reader write lock or similar mechanism. This locking is not needed for access by a single
	/// thread. Different threads can access separate requests/completion queues without locks. The need for synchronization occurs only when
	/// multiple threads try to access the same queue. Synchronization is also required if multiple threads issue sends and receives on the
	/// same socket because the send and receive operations use the socket’s request queue.
	/// </para>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOCreateCompletionQueue</c> function must be obtained at run time by making a call to the
	/// <c>WSAIoctl</c> function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
	/// <c>WSAIoctl</c> function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the
	/// Winsock registered I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_riocreatecompletionqueue LPFN_RIOCREATECOMPLETIONQUEUE
	// LpfnRiocreatecompletionqueue; RIO_CQ LpfnRiocreatecompletionqueue( DWORD QueueSize, PRIO_NOTIFICATION_COMPLETION
	// NotificationCompletion ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIOCREATECOMPLETIONQUEUE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate RIO_CQ LPFN_RIOCREATECOMPLETIONQUEUE(uint QueueSize, IntPtr NotificationCompletion);

	/// <summary>
	/// The <c>RIOCreateRequestQueue</c> function creates a registered I/O socket descriptor using a specified socket and I/O completion
	/// queues for use with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="Socket">A descriptor that identifies the socket.</param>
	/// <param name="MaxOutstandingReceive">
	/// <para>The maximum number of outstanding receives allowed on the socket.</para>
	/// <para>This parameter is usually a small number for most applications.</para>
	/// </param>
	/// <param name="MaxReceiveDataBuffers">
	/// <para>The maximum number of receive data buffers on the socket.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>For Windows 8 and Windows Server 2012 , this parameter must be <c>1</c>.</para>
	/// </para>
	/// </param>
	/// <param name="MaxOutstandingSend">The maximum number of outstanding sends allowed on the socket.</param>
	/// <param name="MaxSendDataBuffers">
	/// <para>The maximum number of send data buffers on the socket.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>For Windows 8 and Windows Server 2012 , this parameter must be <c>1</c>.</para>
	/// </para>
	/// </param>
	/// <param name="ReceiveCQ">A descriptor that identifies the I/O completion queue to use for receive request completions.</param>
	/// <param name="SendCQ">
	/// <para>A descriptor that identifies the I/O completion queue to use for send request completions.</para>
	/// <para>This parameter may have the same value as the ReceiveCQ parameter.</para>
	/// </param>
	/// <param name="SocketContext">The socket context to associate with this request queue.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOCreateRequestQueue</c> function returns a descriptor referencing a new request queue. Otherwise, a
	/// value of <c>RIO_INVALID_RQ</c> is returned, and a specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>ReceiveCQ</c> or <c>SendCQ</c> parameters contained
	/// <c>RIO_INVALID_CQ</c>. This error is returned if both the <c>MaxOutstandingReceive</c> and <c>MaxOutstandingSend</c> parameters are
	/// zero. This error is also returned if the socket passed in the <c>Socket</c> parameter is in the process of initializing or closing.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// Sufficient memory could not be allocated. This error is returned if there was insufficient memory to allocate the request queue based
	/// on the parameters. This error is also returned if the network session limit was exceeded.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor is not a socket. This error is returned if the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEOPNOTSUPP</c></term>
	/// <term>
	/// The attempted operation is not supported for the type of object referenced. This error is returned for a socket in the <c>Socket</c>
	/// parameter for an unsupported socket type ( <c>SOCK_RAW</c>, for example)
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RIOCreateRequestQueue</c> function creates a registered I/O socket descriptor using a specified socket and I/O completion
	/// queues. An application must call <c>RIOCreateRequestQueue</c> to obtain a <c>RIO_RQ</c> for a Winsock socket before the application
	/// can use the <c>RIOSend</c>, <c>RIOSendEx</c>, <c>RIOReceive</c>, or <c>RIOReceiveEx</c> functions. In order to obtain a
	/// <c>RIO_RQ</c>, the Winsock socket must be associated with completion queues for send and receive, although the same completion queue
	/// can be used for both.
	/// </para>
	/// <para>
	/// Due to the finite size of completion queues, a socket may only be associated with a completion queue for send and receive operations
	/// if it guarantees not to exceed the capacity for total queued completions. Therefore, socket specific limits are established by the
	/// call to the <c>RIOCreateRequestQueue</c> function. These limits are used both during the <c>RIOCreateRequestQueue</c> call to verify
	/// sufficient space in the completion queues to accommodate the socket requests and during request initiation time to make sure that the
	/// request does not cause the socket to exceed its limits.
	/// </para>
	/// <para>
	/// The send and receive queues can be associated with multiple sockets. The sizes of the send and receive queues must be greater than or
	/// equal to the send and receive sizes of all attached sockets. As request queues are closed by closing the sockets using the the
	/// <c>closesocket</c> function, those slots will be freed up for use by other sockets.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For purposes of efficiency, access to the completion queues ( <c>RIO_CQ</c> structs) and request queues ( <c>RIO_RQ</c> structs) are
	/// not protected by synchronization primitives. If you need to access a completion or request queue from multiple threads, access should
	/// be coordinated by a critical section, slim reader write lock or similar mechanism. This locking is not needed for access by a single
	/// thread. Different threads can access separate requests/completion queues without locks. The need for synchronization occurs only when
	/// multiple threads try to access the same queue. Synchronization is also required if multiple threads issue sends and receives on the
	/// same socket because the send and receive operations use the socket’s request queue.
	/// </para>
	/// </para>
	/// <para>
	/// When an application is finished using the <c>RIO_RQ</c>, the application should call the <c>closesocket</c> function to close the
	/// socket and free the associated resources.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOCreateRequestQueue</c> function must be obtained at run time by making a call to the
	/// <c>WSAIoctl</c> function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
	/// <c>WSAIoctl</c> function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the
	/// Winsock registered I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_riocreaterequestqueue LPFN_RIOCREATEREQUESTQUEUE
	// LpfnRiocreaterequestqueue; RIO_RQ LpfnRiocreaterequestqueue( SOCKET Socket, ULONG MaxOutstandingReceive, ULONG MaxReceiveDataBuffers,
	// ULONG MaxOutstandingSend, ULONG MaxSendDataBuffers, RIO_CQ ReceiveCQ, RIO_CQ SendCQ, PVOID SocketContext ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIOCREATEREQUESTQUEUE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate RIO_RQ LPFN_RIOCREATEREQUESTQUEUE(SOCKET Socket, uint MaxOutstandingReceive, uint MaxReceiveDataBuffers,
		uint MaxOutstandingSend, uint MaxSendDataBuffers, RIO_CQ ReceiveCQ, RIO_CQ SendCQ, IntPtr SocketContext);

	/// <summary>
	/// The <c>RIODequeueCompletion</c> function removes entries from an I/O completion queue for use with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="CQ">A descriptor that identifies an I/O completion queue.</param>
	/// <param name="Array">An array of <c>RIORESULT</c> structures to receive the description of the completions dequeued.</param>
	/// <param name="ArraySize">The maximum number of entries in the Array to write.</param>
	/// <returns>
	/// If no error occurs, the <c>RIODequeueCompletion</c> function returns the number of completion entries removed from the specified
	/// completion queue. Otherwise, a value of <c>RIO_CORRUPT_CQ</c> is returned to indicate that the state of the <c>RIO_CQ</c> passed in
	/// the CQ parameter has become corrupt due to memory corruption or misuse of the RIO functions.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RIODequeueCompletion</c> function removes entries from an I/O completion queue for send and receive requests with the Winsock
	/// registered I/O extensions.
	/// </para>
	/// <para>
	/// The <c>RIODequeueCompletion</c> function is the mechanism by which an application can find out about completed send and receive
	/// requests. An application normally calls the <c>RIODequeueCompletion</c> function after receiving notification based on the method
	/// registered with the <c>RIONotify</c> function when the completion queue is not empty. The notification behavior for an I/O completion
	/// queue is set when the <c>RIO_CQ</c> is created. The <c>RIO_NOTIFICATION_COMPLETION</c> structure that determines the notification
	/// behavior is passed to the <c>RIOCreateCompletionQueue</c> function when a <c>RIO_CQ</c> is created.
	/// </para>
	/// <para>
	/// When the <c>RIODequeueCompletion</c> function completes, the Array parameter contains an array of pointers to <c>RIORESULT</c>
	/// structures for the completed send and receive requests that were dequeued. The members of the returned <c>RIORESULT</c> structures
	/// provide information on the completion status of the completed request and the number of bytes that were transferred. Each returned
	/// <c>RIORESULT</c> structure also includes a socket context and an application context that can be used to identify the specific
	/// completed request.
	/// </para>
	/// <para>
	/// If the I/O completion queue passed in the CQ parameter is not valid or damaged, the <c>RIODequeueCompletion</c> function returns a
	/// count of <c>RIO_CORRUPT_CQ</c>.
	/// </para>
	/// <para>
	/// The <c>RIODequeueCompletion</c> function returns a value of zero is returned if there are no completed send or receive requests to be dequeued.
	/// </para>
	/// <para>
	/// Only after a request’s completion has been dequeued does the system release the association to its buffer and buffer registration,
	/// along with its quota charge.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// For purposes of efficiency, access to the completion queues ( <c>RIO_CQ</c> structs) and request queues ( <c>RIO_RQ</c> structs) are
	/// not protected by synchronization primitives. If you need to access a completion or request queue from multiple threads, access should
	/// be coordinated by a critical section, slim reader write lock or similar mechanism. This locking is not needed for access by a single
	/// thread. Different threads can access separate requests/completion queues without locks. The need for synchronization occurs only when
	/// multiple threads try to access the same queue. Synchronization is also required if multiple threads issue sends and receives on the
	/// same socket because the send and receive operations use the socket’s request queue.
	/// </para>
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIODequeueCompletion</c> function must be obtained at run time by making a call to the WSAIoctl
	/// function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c>
	/// function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered
	/// I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_riodequeuecompletion LPFN_RIODEQUEUECOMPLETION
	// LpfnRiodequeuecompletion; ULONG LpfnRiodequeuecompletion( RIO_CQ CQ, PRIORESULT Array, ULONG ArraySize ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIODEQUEUECOMPLETION")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate uint LPFN_RIODEQUEUECOMPLETION(RIO_CQ CQ, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] RIORESULT[] Array, uint ArraySize);

	/// <summary>The <c>RIODeregisterBuffer</c> function deregisters a registered buffer used with the Winsock registered I/O extensions.</summary>
	/// <param name="BufferId">A descriptor identifying a registered buffer.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The <c>RIODeregisterBuffer</c> function deregisters a registered buffer. When a buffer is deregistered, the application is indicating
	/// that it is done with the buffer identifier passed in the BufferId parameter. Any subsequent calls to other functions that try to use
	/// this buffer identifier will fail.
	/// </para>
	/// <para>
	/// If a buffer that is still in use is deregistered, the results are undefined. This is considered a serious error. In the
	/// <c>RIORESULT</c> structure returned by the <c>RIODequeueCompletion</c> function, the status will be unchanged from the normal status.
	/// An application developer can detect this error condition using the Application Verifier tool.
	/// </para>
	/// <para>If an invalid buffer identifier is passed in the BufferId parameter, this is ignored by the <c>RIODeregisterBuffer</c> function.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIODeregisterBuffer</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c>
	/// function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c>
	/// function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered
	/// I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioderegisterbuffer LPFN_RIODEREGISTERBUFFER
	// LpfnRioderegisterbuffer; void LpfnRioderegisterbuffer( RIO_BUFFERID BufferId ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIODEREGISTERBUFFER")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void LPFN_RIODEREGISTERBUFFER(RIO_BUFFERID BufferId);

	/// <summary>
	/// The <c>RIONotify</c> function registers the method to use for notification behavior with an I/O completion queue for use with the
	/// Winsock registered I/O extensions.
	/// </summary>
	/// <param name="CQ">A descriptor that identifies an I/O completion queue.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIONotify</c> function returns <c>ERROR_SUCCESS</c>. Otherwise, the function failed and a specific error
	/// code is returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if invalid completion queue is passed in the <c>CQ</c>
	/// parameter ( <c>RIO_INVALID_CQ</c>, for example). This error can also be returned when an internal error occurs.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEALREADY</c></term>
	/// <term>
	/// An operation was attempted on a non-blocking socket that already had an operation in progress. This error is returned if a previous
	/// <c>RIONotify</c> request has not yet completed.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RIONotify</c> function registers the method to be used for notification behavior for sending or receiving network data with
	/// the Winsock registered I/O extensions.
	/// </para>
	/// <para>
	/// The <c>RIONotify</c> function is the mechanism by which an application finds out that requests are completed and are awaiting a call
	/// to the <c>RIODequeueCompletion</c> function. The <c>RIONotify</c> function sets the method to be used for notification behavior when
	/// an I/O completion queue is not empty and contains the completion of a result.
	/// </para>
	/// <para>
	/// The notification behavior for a completion queue is set when the <c>RIO_CQ</c> is created. The <c>RIO_NOTIFICATION_COMPLETION</c>
	/// structure is passed to the <c>RIOCreateCompletionQueue</c> function when a <c>RIO_CQ</c> is created.
	/// </para>
	/// <para>
	/// For a completion queue that uses an event, the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure is set to
	/// <c>RIO_EVENT_COMPLETION</c>. The <c>Event.EventHandle</c> member should contain the handle for an event created by the
	/// <c>WSACreateEvent</c> or <c>CreateEvent</c> function. To receive the <c>RIONotify</c> completion, the application should wait on the
	/// specified event handle using <c>WSAWaitForMultipleEvents</c> or a similar wait routine. If the application plans to reset and reuse
	/// the event, the application can reduce overhead by setting the <c>Event.NotifyReset</c> member to a non-zero value. This causes the
	/// event to be automatically reset by the <c>RIONotify</c> function when the notification occurs. This mitigates the need to call the
	/// <c>WSAResetEvent</c> function to reset the event between calls to the <c>RIONotify</c> function.
	/// </para>
	/// <para>
	/// When the <c>RIONotify</c> function is called used event completion and the specified completion queue is already not empty, the event
	/// is set either synchronously or asynchronously. In both cases, additional entries do not need to enter the completion queue before the
	/// event is set. Until the completion queue contains the completion of a request that did not have the <c>RIO_MSG_DONT_NOTIFY</c> flag
	/// set, the completion queue is considered empty for the purposes of the <c>RIONotify</c> function and the event is not set. Any
	/// completed requests can still be retrieved using the <c>RIODequeueCompletion</c> function. When the event is set, the application
	/// typically calls the <c>RIODequeueCompletion</c> function to dequeue the completed send and receive requests.
	/// </para>
	/// <para>
	/// For a completion queue that uses an I/O completion port, the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure
	/// is set to <c>RIO_IOCP_COMPLETION</c>. The <c>Iocp.IocpHandle</c> member should contain the handle for an I/O completion port created
	/// by the <c>CreateIoCompletionPort</c> function. To receive the <c>RIONotify</c> completion, the application should call the
	/// <c>GetQueuedCompletionStatus</c> or <c>GetQueuedCompletionStatusEx</c> function. The application should provide a dedicated
	/// <c>OVERLAPPED</c> object for the completion queue, and it may also use the <c>Iocp.CompletionKey</c> member to distinguish
	/// <c>RIONotify</c> requests on the completion queue from other I/O completions including <c>RIONotify</c> completions for other
	/// completion queues.
	/// </para>
	/// <para>
	/// An application using thread pools can use thread pool wait objects to get <c>RIONotify</c> completions via its thread pool. In that
	/// case, the call to the <c>SetThreadpoolWait</c> function should immediately follow the call to <c>RIONotify</c>. If the
	/// <c>SetThreadpoolWait</c> function is called before <c>RIONotify</c> and the application relies on <c>RIONotify</c> to clear the event
	/// object, this may result in spurious executions of the wait object callback.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIONotify</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c> function
	/// with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered I/O
	/// extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rionotify LPFN_RIONOTIFY LpfnRionotify; INT LpfnRionotify(
	// RIO_CQ CQ ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIONOTIFY")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate WSRESULT LPFN_RIONOTIFY(RIO_CQ CQ);

	/// <summary>
	/// The <c>RIOReceive</c> function receives network data on a connected registered I/O TCP socket or a bound registered I/O UDP socket
	/// for use with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="SocketQueue">A descriptor that identifies a connected registered I/O TCP socket or a bound registered I/O UDP socket.</param>
	/// <param name="pData">
	/// <para>A description of the portion of the registered buffer in which to receive data.</para>
	/// <para>
	/// This parameter may be NULL for a bound registered I/O UDP socket if the application does not need to receive the data payload in the
	/// UDP datagram.
	/// </para>
	/// </param>
	/// <param name="DataBufferCount">
	/// <para>A data buffer count parameter that indicates if data is to be received in the buffer pointed to by the pData parameter.</para>
	/// <para>This parameter should be set to zero if the pData is NULL. Otherwise, this parameter should be set to 1.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>A set of flags that modify the behavior of the <c>RIOReceive</c> function.</para>
	/// <para>The Flags parameter can contain a combination of the following options defined in the Mswsockdef.h header file:</para>
	/// <list type="table"/>
	/// </param>
	/// <param name="RequestContext">The request context to associate with this receive operation.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOReceive</c> function returns <c>TRUE</c>. In this case, the receive operation is successfully initiated
	/// and the completion will have already been queued or the operation has been successfully initiated and the completion will be queued
	/// at a later time.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates the function failed, the operation was not successfully initiated and no completion indication will
	/// be queued. A specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if a buffer
	/// identifier is deregistered or a buffer is freed for any of the <c>RIO_BUF</c> structures passed in parameters before the operation is
	/// queued or invoked.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>SocketQueue</c> parameter is not valid, the
	/// <c>Flags</c> parameter contains a value not valid for a receive operation, or the integrity of the completion queue has been
	/// compromised. This error can also be returned for other issues with parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// Sufficient memory could not be allocated. This error is returned if the I/O completion queue associated with the <c>SocketQueue</c>
	/// parameter is full or the I/O completion queue was created with zero receive entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_OPERATION_ABORTED</c></term>
	/// <term>
	/// The operation has been canceled while the receive operation was pending. This error is returned if the socket is closed locally or
	/// remotely, or the <c>SIO_FLUSH</c> command in <c>WSAIoctl</c> is executed on this socket.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use the <c>RIOReceive</c> function to receive network data into any buffer completely contained within a single
	/// registered buffer. The <c>Offset</c> and <c>Length</c> members of the <c>RIO_BUF</c> structure pointed to by the pData parameter
	/// determine where the network data is received in the buffer.
	/// </para>
	/// <para>
	/// Once the <c>RIOReceive</c> function is called, the buffer passed in the pData parameter including the <c>RIO_BUFFERID</c> in the
	/// <c>BufferId</c> member of <c>RIO_BUF</c> structure must remain valid for the duration of the receive operation.
	/// </para>
	/// <para>
	/// In order to avoid race conditions, a buffer associated with a receive request should not be read or written before the request
	/// completes. This includes using the buffer as the source for a send request or the destination for another receive request. Portions
	/// of a registered buffer not associated with any receive request are not included in this restriction.
	/// </para>
	/// <para>
	/// The Flags parameter can be used to influence the behavior of the <c>RIOReceive</c> function invocation beyond the options specified
	/// for the associated socket. The behavior of this function is determined by a combination of any socket options set on the socket
	/// associated with the SocketQueue parameter and the values specified in the Flags parameter.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOReceive</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c> function
	/// with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered I/O
	/// extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioreceive LPFN_RIORECEIVE LpfnRioreceive; BOOL
	// LpfnRioreceive( RIO_RQ SocketQueue, PRIO_BUF pData, ULONG DataBufferCount, DWORD Flags, PVOID RequestContext ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIORECEIVE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_RIORECEIVE(RIO_RQ SocketQueue, [In, Optional] IntPtr pData, uint DataBufferCount, RIO_MSG Flags,
		IntPtr RequestContext);

	/// <summary>
	/// The <c>RIOReceiveEx</c> function receives network data on a connected registered I/O TCP socket or a bound registered I/O UDP socket
	/// with additional options for use with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="SocketQueue">A descriptor that identifies a connected registered I/O UDP socket or a bound registered I/O UDP socket.</param>
	/// <param name="pData">
	/// <para>A description of the portion of the registered buffer in which to receive data.</para>
	/// <para>
	/// This parameter may be NULL for a bound registered I/O UDP socket if the application does not need to receive a data payload in the
	/// UDP datagram.
	/// </para>
	/// </param>
	/// <param name="DataBufferCount">
	/// <para>A data buffer count parameter that indicates if data is to be received in the buffer pointed to by the pData parameter.</para>
	/// <para>This parameter should be set to zero if the pData is NULL. Otherwise, this parameter should be set to 1.</para>
	/// </param>
	/// <param name="pLocalAddress">
	/// <para>A buffer segment that on completion will hold the local address on which the network data was received.</para>
	/// <para>
	/// This parameter may be <c>NULL</c> if the application does not want to receive the local address. If this parameter is not
	/// <c>NULL</c>, then the buffer segment must be at least the size of a <c>SOCKADDR_INET</c> structure.
	/// </para>
	/// </param>
	/// <param name="pRemoteAddress">
	/// <para>A buffer segment that on completion will hold the remote address from which the network data was received.</para>
	/// <para>
	/// This parameter may be <c>NULL</c> if the application does not want to receive the remote address. If this parameter is not
	/// <c>NULL</c>, then the buffer segment must be at least the size of a <c>SOCKADDR_INET</c> structure.
	/// </para>
	/// </param>
	/// <param name="pControlContext">
	/// <para>A buffer slice that on completion will hold additional control information about the receive operation.</para>
	/// <para>This parameter may be <c>NULL</c> if the application does not want to receive the additional control information.</para>
	/// </param>
	/// <param name="pFlags"/>
	/// <param name="Flags">
	/// <para>A set of flags that modify the behavior of the <c>RIOReceiveEx</c> function.</para>
	/// <para>The Flags parameter can contain a combination of the following options defined in the Mswsockdef.h header file:</para>
	/// <list type="table"/>
	/// </param>
	/// <param name="RequestContext">The request context to associate with this receive operation.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOReceiveEx</c> function returns <c>TRUE</c>. In this case, the receive operation is successfully
	/// initiated and the completion will have already been queued or the operation has been successfully initiated and the completion will
	/// be queued at a later time.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates the function failed, the operation was not successfully initiated and no completion indication will
	/// be queued. A specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if a buffer
	/// identifier is deregistered or a buffer is freed for any of the <c>RIO_BUF</c> structures passed in parameters before the operation is
	/// queued or invoked.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>SocketQueue</c> parameter is not valid, the
	/// <c>dwFlags</c> parameter contains a value not valid for a receive operation, or the integrity of the completion queue has been
	/// compromised. This error can also be returned for other issues with parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// Sufficient memory could not be allocated. This error is returned if the I/O completion queue associated with the <c>SocketQueue</c>
	/// parameter is full or the I/O completion queue was created with zero receive entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_OPERATION_ABORTED</c></term>
	/// <term>
	/// The operation has been canceled while the receive operation was pending. This error is returned if the socket is closed locally or
	/// remotely, or the the SIO_FLUSH command in <c>WSAIoctl</c> is executed.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use the <c>RIOReceiveEx</c> function to receive network data into any buffer completely contained within a single
	/// registered buffer. The <c>Offset</c> and <c>Length</c> members of the <c>RIO_BUF</c> structure pointed to by the pData parameter
	/// determine where the network data is received in the buffer.
	/// </para>
	/// <para>
	/// Once the <c>RIOReceiveEx</c> function is called, the buffer passed in the pData parameter including the <c>RIO_BUFFERID</c> in the
	/// <c>BufferId</c> member of <c>RIO_BUF</c> structure must remain valid for the duration of the receive operation.
	/// </para>
	/// <para>
	/// In order to avoid race conditions, a buffer associated with a receive request should not be read or written before the request
	/// completes. This includes using the buffer as the source for a send request or the destination for another receive request. Portions
	/// of a registered buffer not associated with any receive request are not included in this restriction.
	/// </para>
	/// <para>
	/// The pLocalAddress parameter can be used to retrieve the local address where the data was received. The pRemoteAddress parameter can
	/// be used to retrieve the remote address from which the data was received. The local and remote addresses are returned as
	/// <c>SOCKADDR_INET</c> structures. As a result, the <c>Length</c> member of the <c>RIO_BUF</c> pointed to by pLocalAddress or
	/// pRemoteAddress parameters should be equal or greater than the size of a <c>SOCKADDR_INET</c> structure.
	/// </para>
	/// <para>
	/// The following table summarizes the various uses of control data available for use with the control information in the pControlContext member.
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
	/// firewalls when a Teredo, 6to4, or ISATAP tunnel is used for IPv4 NAT traversal. The cmsg_data[] member is a ULONG that contains the
	/// IF_INDEX defined in the <c>ifdef.h</c> header file. For more information, see the IPPROTO_IP Socket Options for the
	/// IP_ORIGINAL_ARRIVAL_IF socket option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPv4</term>
	/// <term>IPPROTO_IP</term>
	/// <term>IP_PKTINFO</term>
	/// <term>Specifies/receives packet information. For more information, see the IPPROTO_IP Socket Options for the IP_PKTINFO socket option.</term>
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
	/// <term>
	/// Specifies/receives hop limit. For more information, see the <c>IPPROTO_IPV6 Socket Options</c> for the IPV6_HOPLIMIT socket option.
	/// </term>
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
	/// <term>
	/// Specifies/receives packet information. For more information, see the <c>IPPROTO_IPV6 Socket Options</c> for the IPV6_PKTINFO socket option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPv6</term>
	/// <term>IPPROTO_IPV6</term>
	/// <term>IPV6_RTHDR</term>
	/// <term>Specifies/receives routing header.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Control data is made up of one or more control data objects, each beginning with a <c>WSACMSGHDR</c> structure, defined as the following:
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
	/// The number of bytes of data starting from the beginning of the <c>WSACMSGHDR</c> to the end of data (excluding padding bytes that may
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
	/// <para>
	/// The Flags parameter can be used to influence the behavior of the <c>RIOReceiveEx</c> function invocation beyond the options specified
	/// for the associated socket. The behavior of this function is determined by a combination of any socket options set on the socket
	/// associated with the SocketQueue parameter and the values specified in the Flags parameter.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOReceiveEx</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c>
	/// function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c>
	/// function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered
	/// I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioreceiveex LPFN_RIORECEIVEEX LpfnRioreceiveex; int
	// LpfnRioreceiveex( RIO_RQ SocketQueue, PRIO_BUF pData, ULONG DataBufferCount, PRIO_BUF pLocalAddress, PRIO_BUF pRemoteAddress, PRIO_BUF
	// pControlContext, PRIO_BUF pFlags, DWORD Flags, PVOID RequestContext ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIORECEIVEEX")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate int LPFN_RIORECEIVEEX(RIO_RQ SocketQueue, [In, Optional] PRIO_BUF pData, uint DataBufferCount, [In, Optional] PRIO_BUF pLocalAddress,
		[In, Optional] PRIO_BUF pRemoteAddress, [In, Optional] PRIO_BUF pControlContext, PRIO_BUF pFlags, RIO_MSG Flags, IntPtr RequestContext);

	/// <summary>
	/// The <c>RIORegisterBuffer</c> function registers a <c>RIO_BUFFERID</c>, a registered buffer descriptor, with a specified buffer for
	/// use with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="DataBuffer">A pointer to the beginning of the memory buffer to register.</param>
	/// <param name="DataLength">The length, in bytes, in the buffer to register.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIORegisterBuffer</c> function returns a registered buffer descriptor. Otherwise, a value of
	/// <c>RIO_INVALID_BUFFERID</c> is returned, and a specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if an
	/// invalid buffer pointer is passed in <c>DataBuffer</c> parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>An invalid parameter was passed to the function. This error is returned if the <c>DataLength</c> parameter is zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RIORegisterBuffer</c> function creates a registered buffer identifier for a specified buffer. When a buffer is registered, the
	/// virtual memory pages containing the buffer will be locked into physical memory.
	/// </para>
	/// <para>
	/// If several small, non-contiguous buffers are registered, the physical memory footprint for the buffers may effectively be as large as
	/// an entire memory page per registration. In these cases it may be beneficial to allocate multiple request buffers together.
	/// </para>
	/// <para>
	/// There is also a small amount of overhead in physical memory used for the buffer registration itself. So if there are many allocations
	/// aggregated into single larger allocation, the physical memory footprint may be reduced further by aggregating the buffer
	/// registrations as well. In this case the application may need to take extra care to ensure that the buffers are eventually
	/// deregistered, but not while any send or receive requests are outstanding.
	/// </para>
	/// <para>
	/// A portion of a registered buffer is passed to the <c>RIOSend</c>, <c>RIOSendEx</c>, <c>RIOReceive</c>, and <c>RIOReceiveEx</c>
	/// functions in the pData parameter for sending or receiving data.
	/// </para>
	/// <para>When the buffer identifier is no longer needed, call the <c>RIODeregisterBuffer</c> function to deregister the buffer identifier.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIORegisterBuffer</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c>
	/// function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c>
	/// function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered
	/// I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioregisterbuffer LPFN_RIOREGISTERBUFFER
	// LpfnRioregisterbuffer; RIO_BUFFERID LpfnRioregisterbuffer( PCHAR DataBuffer, DWORD DataLength ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIOREGISTERBUFFER")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false, CharSet = CharSet.Ansi)]
	public delegate RIO_BUFFERID LPFN_RIOREGISTERBUFFER([MarshalAs(UnmanagedType.LPStr)] StringBuilder DataBuffer, uint DataLength);

	/// <summary>
	/// The <c>RIOResizeCompletionQueue</c> function resizes an I/O completion queue to be either larger or smaller for use with the Winsock
	/// registered I/O extensions.
	/// </summary>
	/// <param name="CQ">A descriptor that identifies an existing I/O completion queue to resize.</param>
	/// <param name="QueueSize"/>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOResizeCompletionQueue</c> function returns <c>TRUE</c>. Otherwise, a value of <c>FALSE</c> is returned,
	/// and a specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if the
	/// completion queue specified in the <c>CQ</c> parameter contains an invalid pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>CQ</c> parameter is not valid (RIO_INVALID_CQ, for
	/// example). This error is also returned if the size of the queue specified in the <c>QueueSize</c> parameter is greater than <c>RIO_CQ_MAX_SIZE</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// Sufficient memory could not be allocated. This error is returned if memory could not be allocated for the queue specified in the
	/// <c>QueueSize</c> parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAETOOMANYREFS</c></term>
	/// <term>
	/// There are too many operations that still reference the I/O completion queue. Resizing of this I/O completion queue to be smaller is
	/// not possible at this time.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>RIOResizeCompletionQueue</c> function resizes an I/O completion queue to be either larger or smaller. If the I/O completion
	/// queue already contains completions, those completions will be copied over to the new completion queue.
	/// </para>
	/// <para>
	/// I/O completion queues have a required minimum size that is dependent on the number of request queues associated with the completion
	/// queue and the number of sends and receives on the request queues. If an application calls the <c>RIOResizeCompletionQueue</c>
	/// function and tries to set the queue too small for the number of existing completions in the I/O completion queue, the call will fail
	/// and the queue will not be resized.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOResizeCompletionQueue</c> function must be obtained at run time by making a call to the
	/// <c>WSAIoctl</c> function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
	/// <c>WSAIoctl</c> function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the
	/// Winsock registered I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioresizecompletionqueue LPFN_RIORESIZECOMPLETIONQUEUE
	// LpfnRioresizecompletionqueue; BOOL LpfnRioresizecompletionqueue( RIO_CQ CQ, DWORD QueueSize ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIORESIZECOMPLETIONQUEUE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_RIORESIZECOMPLETIONQUEUE(RIO_CQ CQ, uint QueueSize);

	/// <summary>
	/// The <c>RIOResizeRequestQueue</c> function resizes a request queue to be either larger or smaller for use with the Winsock registered
	/// I/O extensions.
	/// </summary>
	/// <param name="RQ">A descriptor that identifies an existing registered I/O socket descriptor (request queue) to resize.</param>
	/// <param name="MaxOutstandingReceive">
	/// <para>The maximum number of outstanding sends allowed on the socket. This value can be larger or smaller than the original number.</para>
	/// <para>This parameter is usually a small number for most applications.</para>
	/// </param>
	/// <param name="MaxOutstandingSend">
	/// The maximum number of outstanding receives allowed on the socket. This value can be larger or smaller than the original number.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOResizeRequestQueue</c> function returns <c>TRUE</c>. Otherwise, a value of <c>FALSE</c> is returned,
	/// and a specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>RQ</c> parameter is not valid (RIO_INVALID_RQ, for
	/// example). This error is also returned if both the <c>MaxOutstandingReceive</c> and <c>MaxOutstandingSend</c> parameters are zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>Sufficient memory could not be allocated. This error is returned if memory could not be allocated for the resized request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAETOOMANYREFS</c></term>
	/// <term>
	/// There are too many operations that still reference the request queue. Resizing of this request queue to be smaller is not possible at
	/// this time.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>RIOResizeRequestQueue</c> function resizes a request queue to be either larger or smaller. If the request queue already
	/// contains entries, those entries will be copied over to the new request queue.
	/// </para>
	/// <para>
	/// A request queue has a required minimum size that is dependent on the current number of entries (number of sends and receives on the
	/// request queue). If an application calls the <c>RIOResizeRequestQueue</c> function and tries to set the queue too small for the number
	/// of existing entries, the call will fail and the queue will not be resized.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOResizeRequestQueue</c> function must be obtained at run time by making a call to the
	/// <c>WSAIoctl</c> function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
	/// <c>WSAIoctl</c> function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the
	/// Winsock registered I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_rioresizerequestqueue LPFN_RIORESIZEREQUESTQUEUE
	// LpfnRioresizerequestqueue; BOOL LpfnRioresizerequestqueue( RIO_RQ RQ, DWORD MaxOutstandingReceive, DWORD MaxOutstandingSend ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIORESIZEREQUESTQUEUE")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_RIORESIZEREQUESTQUEUE(RIO_RQ RQ, uint MaxOutstandingReceive, uint MaxOutstandingSend);

	/// <summary>
	/// The <c>RIOSend</c> function sends network data on a connected registered I/O TCP socket or a bound registered I/O UDP socket for use
	/// with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="SocketQueue">A descriptor that identifies a connected registered I/O TCP socket or a bound registered I/O UDP socket.</param>
	/// <param name="pData">
	/// <para>A description of the portion of the registered buffer from which to send data.</para>
	/// <para>
	/// This parameter may be NULL for a bound registered I/O UDP socket if the application does not need to send a data payload in the UDP datagram.
	/// </para>
	/// </param>
	/// <param name="DataBufferCount">
	/// <para>A data buffer count parameter that indicates if data is to be sent in the buffer pointed to by the pData parameter.</para>
	/// <para>This parameter should be set to zero if the pData is NULL. Otherwise, this parameter should be set to 1.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>A set of flags that modify the behavior of the <c>RIOSend</c> function.</para>
	/// <para>The Flags parameter can contain a combination of the following options defined in the Mswsockdef.h header file:</para>
	/// <list type="table"/>
	/// </param>
	/// <param name="RequestContext">The request context to associate with this send operation.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOSend</c> function returns <c>TRUE</c>. In this case, the send operation is successfully initiated and
	/// the completion will have already been queued or the operation has been successfully initiated and the completion will be queued at a
	/// later time.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates the function failed, the operation was not successfully initiated and no completion indication will
	/// be queued. A specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if a buffer
	/// identifier is deregistered or a buffer is freed for any of the <c>RIO_BUF</c> structures passed in parameters before the operation is
	/// queued or invoked.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if the <c>SocketQueue</c> parameter is not valid, the
	/// <c>Flags</c> parameter contains a value not valid for a send operation, or the integrity of the completion queue has been
	/// compromised. This error can also be returned for other issues with parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// Sufficient memory could not be allocated. This error is returned if the I/O completion queue associated with the <c>SocketQueue</c>
	/// parameter is full or the I/O completion queue was created with zero send entries.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_IO_PENDING</c></term>
	/// <term>The operation has been successfully initiated and the completion will be queued at a later time.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use the <c>RIOSend</c> function to send network data from any buffer completely contained within a single
	/// registered buffer. The <c>Offset</c> and <c>Length</c> members of the <c>RIO_BUF</c> structure pointed to by the pData parameter
	/// determine the network data to be sent from the buffer.
	/// </para>
	/// <para>
	/// The buffer associated with a send operation must not be used concurrently with another send or receive operation. The buffer, and
	/// buffer registration, must remain valid for the duration of a send operation. This means that you should not pass the same PRIO_BUF to
	/// a RIOSend(Ex) request when one is already pending. Only after an in-flight RIOSend(Ex) request is complete should you re-use the same
	/// PRIO_BUF (either with the same offset or with a different offset and length). Furthermore, when send data references a registered
	/// buffer (either a portion or the entire buffer), the entire registered buffer must not be used until the send has completed. This
	/// includes using a portion of the registered buffer for a receive operation or another send operation.
	/// </para>
	/// <para>
	/// The Flags parameter can be used to influence the behavior of the <c>RIOSend</c> function beyond the options specified for the
	/// associated socket. The behavior of this function is determined by a combination of any socket options set on the socket associated
	/// with the SocketQueue parameter and the values specified in the Flags parameter.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOSend</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c> function
	/// with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered I/O
	/// extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_riosend LPFN_RIOSEND LpfnRiosend; BOOL LpfnRiosend( RIO_RQ
	// SocketQueue, PRIO_BUF pData, ULONG DataBufferCount, DWORD Flags, PVOID RequestContext ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIOSEND")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_RIOSEND(RIO_RQ SocketQueue, [In, Optional] PRIO_BUF pData, uint DataBufferCount, RIO_MSG Flags,
		IntPtr RequestContext);

	/// <summary>
	/// The <c>RIOSendEx</c> function sends network data on a connected registered I/O TCP socket or a bound registered I/O UDP socket with
	/// additional options for use with the Winsock registered I/O extensions.
	/// </summary>
	/// <param name="SocketQueue">A descriptor that identifies a connected registered I/O TCP socket or a bound registered I/O UDP socket.</param>
	/// <param name="pData">
	/// <para>
	/// A buffer segment from a registered buffer from which to send data. The <c>RIO_BUF</c> structure pointed to by this parameter can
	/// represent a portion of a registered buffer or a complete registered buffer.
	/// </para>
	/// <para>
	/// This parameter may be NULL for a bound registered I/O UDP socket if the application does not need to send a data payload in the UDP datagram.
	/// </para>
	/// </param>
	/// <param name="DataBufferCount">
	/// <para>A data buffer count parameter that indicates if data is to be sent in the buffer pointed to by the pData parameter.</para>
	/// <para>This parameter should be set to zero if the pData is NULL. Otherwise, this parameter should be set to 1.</para>
	/// </param>
	/// <param name="pLocalAddress">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="pRemoteAddress">
	/// <para>A buffer segment from a registered buffer that on input holds the remote address to which the network data is to be sent.</para>
	/// <para>This parameter may be <c>NULL</c> if the socket is connected.</para>
	/// </param>
	/// <param name="pControlContext">
	/// <para>A buffer slice that on completion will hold additional control information about the send operation.</para>
	/// <para>This parameter may be <c>NULL</c> if the application does not want to receive the additional control information.</para>
	/// </param>
	/// <param name="pFlags">
	/// <para>A buffer slice that on completion will hold additional information about the set of flags for the send operation.</para>
	/// <para>This parameter may be <c>NULL</c> if the application does not want to receive the additional flags information.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>A set of flags that modify the behavior of the <c>RIOSendEx</c> function.</para>
	/// <para>The Flags parameter can contain a combination of the following options defined in the Mswsockdef.h header file:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>RIO_MSG_COMMIT_ONLY</term>
	/// <description>
	/// <para>Previous requests added with <c>RIO_MSG_DEFER</c> flag will be committed.</para>
	/// <para>
	/// When the <c>RIO_MSG_COMMIT_ONLY</c> flag is set, no other flags may be specified. When the <c>RIO_MSG_COMMIT_ONLY</c> flag is set,
	/// the <c>pData</c>, <c>pLocalAddress</c>, <c>pRemoteAddress</c>, <c>pControlContext</c>, <c>pFlags</c>, and <c>RequestContext</c>
	/// parameters must be NULL and the <c>DataBufferCount</c> parameter must be zero.
	/// </para>
	/// <para>
	/// This flag would normally be used occasionally after a number of requests were issued with the <c>RIO_MSG_DEFER</c> flag set. This
	/// eliminates the need when using the <c>RIO_MSG_DEFER</c> flag to make the last request without the <c>RIO_MSG_DEFER</c> flag, which
	/// causes the last request to complete much slower than other requests.
	/// </para>
	/// <para>
	/// Unlike other calls to the <c>RIOSendEx</c> function, when the <c>RIO_MSG_COMMIT_ONLY</c> flag is set calls to the <c>RIOSendEx</c>
	/// function do not need to be serialized. For a single <c>RIO_RQ</c>, the <c>RIOSendEx</c> function can be called with
	/// <c>RIO_MSG_COMMIT_ONLY</c> on one thread while calling the <c>RIOSendEx</c> function on another thread.
	/// </para>
	/// </description>
	/// </item>
	/// <item>
	/// <term>RIO_MSG_DONT_NOTIFY</term>
	/// <description>
	/// The request should not trigger the <c>RIONotify</c> function when request completion is inserted into its completion queue.
	/// </description>
	/// </item>
	/// <item>
	/// <term>RIO_MSG_DEFER</term>
	/// <description>
	/// <para>
	/// The request does not need to be executed immediately. This will insert the request into the request queue, but it may or may not
	/// trigger the execution of the request.
	/// </para>
	/// <para>
	/// Sending data may be delayed until a send request is made on the <c>RIO_RQ</c> passed in the <c>SocketQueue</c> parameter without the
	/// <c>RIO_MSG_DEFER</c> flag set. To trigger execution for all sends in a send queue, call the <c>RIOSend</c> or <c>RIOSendEx</c>
	/// function without the <c>RIO_MSG_DEFER</c> flag set. <c>Note</c> The send request is charged against the outstanding I/O capacity on
	/// the <c>RIO_RQ</c> passed in the <c>SocketQueue</c> parameter regardless of whether <c>RIO_MSG_DEFER</c> is set.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// <note type="note">The receive request is charged against the outstanding I/O capacity on the [
	/// <c>RIO_RQ</c>](/windows/win32/winsock/riorqueue) passed in the SocketQueue parameter regardless of whether <c>RIO_MSG_DEFER</c> is set.</note>
	/// </param>
	/// <param name="RequestContext">The request context to associate with this send operation.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>RIOSendEx</c> function returns <c>TRUE</c>. In this case, the send operation is successfully initiated and
	/// the completion will have already been queued or the operation has been successfully initiated and the completion will be queued at a
	/// later time.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates the function failed, the operation was not successfully initiated and no completion indication will
	/// be queued. A specific error code can be retrieved by calling the <c>WSAGetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>WSAEFAULT</c></description>
	/// <description>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if a buffer
	/// identifier is deregistered or a buffer is freed for any of the <c>RIO_BUF</c> structures passed in parameters before the operation is
	/// queued or invoked.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAEINVAL</c></description>
	/// <description>
	/// An invalid parameter was passed to the function. This error is returned if the <c>SocketQueue</c> parameter is not valid, the
	/// <c>Flags</c> parameter contains a value not valid for a send operation, or the integrity of the completion queue has been
	/// compromised. This error can also be returned for other issues with parameters.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAENOBUFS</c></description>
	/// <description>
	/// Sufficient memory could not be allocated. This error is returned if the I/O completion queue associated with the <c>SocketQueue</c>
	/// parameter is full or the I/O completion queue was created with zero send entries.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSA_IO_PENDING</c></description>
	/// <description>The operation has been successfully initiated and the completion will be queued at a later time.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application can use the <c>RIOSendEx</c> function to send network data from any buffer completely contained within a single
	/// registered buffer. The <c>Offset</c> and <c>Length</c> members of the <c>RIO_BUF</c> structure pointed to by the pData parameter
	/// determine the network data to be sent from the buffer.
	/// </para>
	/// <para>
	/// The buffer associated with a send operation must not be used concurrently with another send or receive operation. The buffer, and
	/// buffer registration, must remain valid for the duration of a send operation. This means that you should not pass the same PRIO_BUF to
	/// a RIOSend(Ex) request when one is already pending. Only after an in-flight RIOSend(Ex) request is complete should you re-use the same
	/// PRIO_BUF (either with the same offset or with a different offset and length). Furthermore, when send data references a registered
	/// buffer (either a portion or the entire buffer), the entire registered buffer must not be used until the send has completed. This
	/// includes using a portion of the registered buffer for a receive operation or another send operation.
	/// </para>
	/// <para>
	/// The pLocalAddress parameter can be used to retrieve the local address from which the data was sent. The pRemoteAddress parameter can
	/// be used to retrieve the remote address to which the data was sent. The local and remote addresses are returned as
	/// <c>SOCKADDR_INET</c> structures. As a result, the <c>Length</c> member of the <c>RIO_BUF</c> pointed to by pLocalAddress or
	/// pRemoteAddress parameters should be equal or greater than the size of a <c>SOCKADDR_INET</c> structure.
	/// </para>
	/// <para>
	/// The following table summarizes the various uses of control data available for use with the control information in the pControlContext member.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Protocol</term>
	/// <term>cmsg_level</term>
	/// <term>cmsg_type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description>IPv4</description>
	/// <description>IPPROTO_IP</description>
	/// <description>IP_PKTINFO</description>
	/// <description>
	/// Specifies/receives packet information. For more information, see the IPPROTO_IP Socket Options for the IP_PKTINFO socket option.
	/// </description>
	/// </item>
	/// <item>
	/// <description>IPv6</description>
	/// <description>IPPROTO_IPV6</description>
	/// <description>IPV6_DSTOPTS</description>
	/// <description>Specifies/receives destination options.</description>
	/// </item>
	/// <item>
	/// <description>IPv6</description>
	/// <description>IPPROTO_IPV6</description>
	/// <description>IPV6_HOPLIMIT</description>
	/// <description>
	/// Specifies/receives hop limit. For more information, see the <c>IPPROTO_IPV6 Socket Options</c> for the IPV6_HOPLIMIT socket option.
	/// </description>
	/// </item>
	/// <item>
	/// <description>IPv6</description>
	/// <description>IPPROTO_IPV6</description>
	/// <description>IPV6_HOPOPTS</description>
	/// <description>Specifies/receives hop-by-hop options.</description>
	/// </item>
	/// <item>
	/// <description>IPv6</description>
	/// <description>IPPROTO_IPV6</description>
	/// <description>IPV6_NEXTHOP</description>
	/// <description>Specifies next-hop address.</description>
	/// </item>
	/// <item>
	/// <description>IPv6</description>
	/// <description>IPPROTO_IPV6</description>
	/// <description>IPV6_PKTINFO</description>
	/// <description>
	/// Specifies/receives packet information. For more information, see the <c>IPPROTO_IPV6 Socket Options</c> for the IPV6_PKTINFO socket option.
	/// </description>
	/// </item>
	/// <item>
	/// <description>IPv6</description>
	/// <description>IPPROTO_IPV6</description>
	/// <description>IPV6_RTHDR</description>
	/// <description>Specifies/receives routing header.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>
	/// Control data is made up of one or more control data objects, each beginning with a <c>WSACMSGHDR</c> structure, defined as the following:
	/// </para>
	/// <para>The members of the <c>WSACMSGHDR</c> structure are as follows:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Term</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description>cmsg_len</description>
	/// <description>
	/// The number of bytes of data starting from the beginning of the <c>WSACMSGHDR</c> to the end of data (excluding padding bytes that may
	/// follow data).
	/// </description>
	/// </item>
	/// <item>
	/// <description>cmsg_level</description>
	/// <description>The protocol that originated the control information.</description>
	/// </item>
	/// <item>
	/// <description>cmsg_type</description>
	/// <description>The protocol-specific type of control information.</description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>
	/// The Flags parameter can be used to influence the behavior of the <c>RIOSendEx</c> function beyond the options specified for the
	/// associated socket. The behavior of this function is determined by a combination of any socket options set on the socket associated
	/// with the SocketQueue parameter and the values specified in the Flags parameter.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The function pointer to the <c>RIOSendEx</c> function must be obtained at run time by making a call to the <c>WSAIoctl</c> function
	/// with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the Winsock registered I/O
	/// extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the Ws2def.h header file. The <c>WSAID_MULTIPLE_RIO</c> GUID
	/// is defined in the Mswsock.h header file.
	/// </para>
	/// </para>
	/// <para>Â</para>
	/// <para><c>WindowsÂ PhoneÂ 8:</c> This function is supported for Windows Phone Store apps on WindowsÂ PhoneÂ 8 and later.</para>
	/// <para>
	/// <c>WindowsÂ 8.1</c> and <c>Windows ServerÂ 2012Â R2</c>: This function is supported for Windows Store apps on WindowsÂ 8.1, Windows
	/// ServerÂ 2012Â R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_riosendex
	// LPFN_RIOSENDEX LpfnRiosendex; BOOL LpfnRiosendex( RIO_RQ SocketQueue, PRIO_BUF pData, ULONG DataBufferCount, PRIO_BUF pLocalAddress, PRIO_BUF pRemoteAddress, PRIO_BUF pControlContext, PRIO_BUF pFlags, DWORD Flags, PVOID RequestContext ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_RIOSENDEX")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_RIOSENDEX(RIO_RQ SocketQueue, [In, Optional] PRIO_BUF pData, uint DataBufferCount, [In, Optional] PRIO_BUF pLocalAddress,
		[In, Optional] PRIO_BUF pRemoteAddress, [In, Optional] PRIO_BUF pControlContext, [In, Optional] PRIO_BUF pFlags, RIO_MSG Flags, IntPtr RequestContext);

	/// <summary>
	/// The <c>TransmitPackets</c> function transmits in-memory data or file data over a connected socket. The <c>TransmitPackets</c>
	/// function uses the operating system cache manager to retrieve file data, locking memory for the minimum time required to transmit and
	/// resulting in efficient, high-performance transmission.
	/// </summary>
	/// <param name="hSocket">
	/// A handle to the connected socket to be used in the transmission. Although the socket does not need to be a connection-oriented
	/// circuit, the default destination/peer should have been established using the connect, WSAConnect, accept, WSAAccept, AcceptEx, or
	/// WSAJoinLeaf function.
	/// </param>
	/// <param name="lpPacketArray">An array of type TRANSMIT_PACKETS_ELEMENT, describing the data to be transmitted.</param>
	/// <param name="nElementCount">The number of elements in <c>lpPacketArray</c>.</param>
	/// <param name="nSendSize">
	/// <para>
	/// The size, in bytes, of the data block used in the send operation. Set <c>nSendSize</c> to zero to let the sockets layer select a
	/// default <c>send</c> size.
	/// </para>
	/// <para>
	/// Setting <c>nSendSize</c> to 0xFFFFFFF enables the caller to control the size and content of each send request, achieved by using the
	/// TP_ELEMENT_EOP flag in the TRANSMIT_PACKETS_ELEMENT array pointed to in the <c>lpPacketArray</c> parameter. This capability is useful
	/// for message protocols that place limitations on the size of individual <c>send</c> requests.
	/// </para>
	/// </param>
	/// <param name="lpOverlapped">
	/// A pointer to an OVERLAPPED structure. If the socket handle specified in the <c>hSocket</c> parameter has been opened as overlapped,
	/// use this parameter to achieve asynchronous (overlapped) I/O operation. Socket handles are opened as overlapped by default.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags used to customize processing of the <c>TransmitPackets</c> function. The following table outlines the use of the
	/// <c>dwFlags</c> parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description><c>TF_DISCONNECT</c></description>
	/// <description>
	/// Starts a transport-level disconnect after all the file data has been queued for transmission. Applies only to connection-oriented
	/// sockets. Specifying this flag for sockets that do not support disconnect semantics (such as datagram sockets) results in an error.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>TF_REUSE_SOCKET</c></description>
	/// <description>
	/// Prepares the socket handle to be reused. When the <c>TransmitPackets</c> function completes, the socket handle can be passed to the
	/// AcceptEx function. Valid only when a connection-oriented socket and TF_DISCONNECT are specified.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>TF_USE_DEFAULT_WORKER</c></description>
	/// <description>
	/// Directs Winsock to use the system's default thread to process long <c>TransmitPackets</c> requests. Long <c>TransmitPackets</c>
	/// requests are defined as requests that require more than a single read from the file or a cache; the long request definition therefore
	/// depends on the size of the file and the specified length of the send packet. The system default thread can be adjusted using the
	/// following registry parameter as a REG_DWORD: <c>HKEY_LOCAL_MACHINE</c>\ <c>CurrentControlSet</c>\ <c>Services</c>\ <c>AFD</c>\
	/// <c>Parameters</c>\ <c>TransmitWorker</c>
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>TF_USE_SYSTEM_THREAD</c></description>
	/// <description>
	/// Directs Winsock to use system threads to process long <c>TransmitPackets</c> requests. Long <c>TransmitPackets</c> requests are
	/// defined as requests that require more than a single read from the file or a cache; the long request definition therefore depends on
	/// the size of the file and the specified length of the send packet.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>TF_USE_KERNEL_APC</c></description>
	/// <description>
	/// Directs Winsock to use kernel Asynchronous Procedure Calls (APCs) instead of worker threads to process long <c>TransmitPackets</c>
	/// requests. Long <c>TransmitPackets</c> requests are defined as requests that require more than a single read from the file or a cache;
	/// the long request definition therefore depends on the size of the file and the specified length of the send packet. See Remarks for
	/// more information.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the <c>TransmitPackets</c> function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>. To get
	/// extended error information, call WSAGetLastError. An error code of WSA_IO_PENDING or ERROR_IO_PENDING indicates that the overlapped
	/// operation has been successfully initiated and that completion will be indicated at a later time. Any other error code indicates that
	/// the overlapped operation was not successfully initiated and no completion indication will occur. Applications should handle either
	/// ERROR_IO_PENDING or WSA_IO_PENDING in this case.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>WSAECONNABORTED</c></description>
	/// <description>
	/// An established connection was aborted by the software in your host machine. This error is returned if the virtual circuit was
	/// terminated due to a time-out or other failure.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAECONNRESET</c></description>
	/// <description>
	/// An existing connection was forcibly closed by the remote host. This error is returned for a stream socket when the virtual circuit
	/// was reset by the remote side. The application should close the socket as it is no longer usable.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAEFAULT</c></description>
	/// <description>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if the
	/// <c>lpPacketArray</c> or the <c>lpOverlapped</c> parameter is not totally contained in a valid part of the user address space.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAEINVAL</c></description>
	/// <description>
	/// An invalid argument was supplied. This error is returned if the <c>dwFlags</c> parameter has the <c>TF_REUSE_SOCKET</c> flag set, but
	/// the <c>TF_DISCONNECT</c> flag was not set. This error is also returned if the offset specified in the OVERLAPPED structure pointed to
	/// by the <c>lpOverlapped</c> is not within the file. This error is also returned if the total number of bytes to be transmitted is a
	/// value greater than 2,147,483,646, the maximum value for a 32-bit integer minus 1.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAENETDOWN</c></description>
	/// <description>A socket operation encountered a dead network.This error is returned if the network subsystem has failed.</description>
	/// </item>
	/// <item>
	/// <description><c>WSAENETRESET</c></description>
	/// <description>
	/// The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress. This error is
	/// returned for a stream socket where the connection was broken due to keep-alive activity detecting a failure.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAENOBUFS</c></description>
	/// <description>
	/// An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full. This
	/// error is also returned if the Windows Sockets provider reports a buffer deadlock.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAENOTCONN</c></description>
	/// <description>
	/// A request to send or receive data was disallowed because the socket is not connected. This error is returned for a stream socket.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAENOTSOCK</c></description>
	/// <description>
	/// An operation was attempted on something that is not a socket. This error is returned if the <c>hSocket</c> parameter is not a socket.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSAESHUTDOWN</c></description>
	/// <description>
	/// A request to send or receive data was disallowed because the socket had already been shut down in that direction with a previous
	/// shutdown call. This error is returned if a stream socket has been shut down for sending. It is not possible to call TransmitFile on a
	/// stream socket after the shutdown function has been called on the socket with the <c>how</c> parameter set to <c>SD_SEND</c> or <c>SD_BOTH</c>.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSANOTINITIALISED</c></description>
	/// <description>
	/// Either the application has not called the WSAStartup function, or <c>WSAStartup</c> failed. A successful <c>WSAStartup</c> call must
	/// occur before using the TransmitFile function.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSA_IO_PENDING</c></description>
	/// <description>
	/// An overlapped I/O operation is in progress. This value is returned if an overlapped I/O operation was successfully initiated and
	/// indicates that completion will be indicated at a later time.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>WSA_OPERATION_ABORTED</c></description>
	/// <description>
	/// The I/O operation has been aborted because of either a thread exit or an application request. This error is returned if the
	/// overlapped operation has been canceled due to the closure of the socket, the execution of the "SIO_FLUSH" command in WSAIoctl, or the
	/// thread that initiated the overlapped request exited before the operation completed.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>TransmitPackets</c> function is optimized according to the operating system on which it is used:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>On Windows server editions, the <c>TransmitPackets</c> function is optimized for high performance.</term>
	/// <description></description>
	/// </item>
	/// <item>
	/// <term>On Windows client editions, the <c>TransmitPackets</c> function is optimized for minimum memory and resource utilization.</term>
	/// <description></description>
	/// </item>
	/// </list>
	/// <para>
	/// The maximum number of bytes that can be transmitted using a single call to the <c>TransmitPackets</c> function is 2,147,483,646, the
	/// maximum value for a 32-bit integer minus 1. If an application needs to transmit data larger than 2,147,483,646 bytes, then multiple
	/// calls to the <c>TransmitPackets</c> function can be used with each call transferring no more than 2,147,483,646 bytes.
	/// </para>
	/// <note type="note">The function pointer for the <c>TransmitPackets</c> function must be obtained at run time by making a call to the
	/// WSAIoctl function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c>
	/// function must contain <c>WSAID_TRANSMITPACKETS</c>, a globally unique identifier (GUID) whose value identifies the
	/// <c>TransmitPackets</c> extension function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>TransmitPackets</c> function. The <c>WSAID_TRANSMITPACKETS</c> GUID is defined in the <c>Mswsock.h</c> header file.</note>
	/// <para>Expect better performance results when using the <c>TransmitPackets</c> function on Windows Server 2003.</para>
	/// <para>
	/// When <c>lpOverlapped</c> is not <c>NULL</c>, overlapped I/O might not finish before the <c>TransmitPackets</c> function returns. When
	/// this occurs, the <c>TransmitPackets</c> function returns fails, and a call to the WSAGetLastError function returns ERROR_IO_PENDING,
	/// allowing the caller to continue processing while the transmission completes.
	/// </para>
	/// <note type="note">All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending
	/// asynchronous operations can fail if the thread is closed before the operations complete. See ExitThread for more information.</note>
	/// <para>
	/// When the <c>TransmitPackets</c> function returns <c>TRUE</c> or returns <c>FALSE</c> and WSAGetLastError returns ERROR_IO_PENDING,
	/// Windows sets the event specified by the <c>hEvent</c> member of the OVERLAPPED structure or the socket specified by <c>hSocket</c> to
	/// the signaled state, and upon completion, delivers notification to any completion port associated with the socket. Use
	/// GetOverlappedResult, or WSAGetOverlappedResult, or GetQueuedCompletionStatus to retrieve final status and number of bytes transmitted.
	/// </para>
	/// <para>TransmitPackets and Asynchronous Procedure Calls (APCs)</para>
	/// <para>
	/// Use of the TF_USE_KERNEL_APC flag can deliver significant performance benefits. If the thread initiating the <c>TransmitPackets</c>
	/// function call is being used for heavy computations, it is possible, though unlikely, that APCs could be prevented from launching.
	/// </para>
	/// <note type="note">There is a difference between kernel and user-mode APCs:
	/// <list type="bullet">
	/// <item><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</item>
	/// <item>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </item>
	/// </list>
	/// </note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_transmitpackets LPFN_TRANSMITPACKETS LpfnTransmitpackets;
	// BOOL LpfnTransmitpackets( SOCKET hSocket, LPTRANSMIT_PACKETS_ELEMENT lpPacketArray, DWORD nElementCount, DWORD nSendSize, LPOVERLAPPED
	// lpOverlapped, DWORD dwFlags ) {...}
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_TRANSMITPACKETS")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool LPFN_TRANSMITPACKETS(SOCKET hSocket, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] TRANSMIT_PACKETS_ELEMENT[] lpPacketArray,
		uint nElementCount, uint nSendSize, [In] IntPtr lpOverlapped, TF dwFlags);

	/// <summary>
	/// <para>
	/// <c>LPFN_WSARECVMSG</c> is a function pointer type. You implement a matching <c>WSARecvMsg</c> callback function in your app. The
	/// system uses your callback function to transmit to you in-memory data, or file data, over a connected socket.
	/// </para>
	/// <para>
	/// Your <c>WSARecvMsg</c> callback function receives ancillary data/control information with a message, from connected and unconnected sockets.
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
	/// <para>A pointer to a <c>DWORD</c> containing number of bytes received by this call if the <c>WSARecvMsg</c> operation completes immediately.</para>
	/// <para>
	/// To avoid potentially erroneous results, pass <c>NULL</c> for this parameter if the lpOverlapped parameter is not <c>NULL</c> . This
	/// parameter can be <c>NULL</c> only if the lpOverlapped parameter is not <c>NULL</c>.
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
	/// If no error occurs and the receive operation has completed immediately, <c>WSARecvMsg</c> returns zero. In this case, the completion
	/// routine will have already been scheduled to be called once the calling thread is in the alertable state. Otherwise, a value of
	/// SOCKET_ERROR is returned, and a specific error code can be retrieved by calling <c>WSAGetLastError</c>. The error code
	/// <c>WSA_IO_PENDING</c> indicates that the overlapped operation has been successfully initiated and that completion will be indicated
	/// at a later time.
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
	/// <c>lpCompletionRoutine</c> parameter is not totally contained in a valid part of the user address space: the <c>lpFrom</c> buffer was
	/// too small to accommodate the peer address. This error is also returned if a <c>name</c> member of the <c>WSAMSG</c> structure pointed
	/// to by the <c>lpMsg</c> parameter was a <c>NULL</c> pointer and the <c>namelen</c> member of the <c>WSAMSG</c> structure was not set
	/// to zero. This error is also returned if a <c>Control.buf</c> member of the <c>WSAMSG</c> structure pointed to by the <c>lpMsg</c>
	/// parameter was a <c>NULL</c> pointer and the <c>Control.len</c> member of the <c>WSAMSG</c> structure was not set to zero.
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
	/// The message was too large to fit into the specified buffer and (for unreliable protocols only) any trailing portion of the message
	/// that did not fit into the buffer has been discarded.
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
	/// The socket timed out. This error is returned if the socket had a wait timeout specified using the <c>SO_RCVTIMEO</c> socket option
	/// and the timeout was exceeded.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEOPNOTSUPP</c></term>
	/// <term>
	/// The socket operation is not supported. This error is returned if the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to
	/// by the <c>lpMsg</c> parameter includes the <c>MSG_PEEK</c> control flag on a non-datagram socket.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEWOULDBLOCK</c></term>
	/// <term>
	/// <c>Windows NT:</c> Overlapped sockets: There are too many outstanding overlapped I/O requests. Non-overlapped sockets: The socket is
	/// marked as nonblocking and the receive operation cannot be completed immediately.
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
	/// optional control information from connected and unconnected sockets. The <c>WSARecvMsg</c> function can only be used with datagrams
	/// and raw sockets. The socket descriptor in the s parameter must be opened with the socket type set to <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>.
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
	/// Overlapped sockets are created with a <c>WSASocket</c> function call that has the <c>WSA_FLAG_OVERLAPPED</c> flag set. For overlapped
	/// sockets, receiving information uses overlapped I/O unless both the lpOverlapped and lpCompletionRoutine parameters are <c>NULL</c>.
	/// The socket is treated as a non-overlapped socket when both the lpOverlapped and lpCompletionRoutine parameters are <c>NULL</c>.
	/// </para>
	/// <para>
	/// A completion indication occurs with overlapped sockets. Once the buffer or buffers have been consumed by the transport, a completion
	/// routine is triggered or an event object is set. If the operation does not complete immediately, the final completion status is
	/// retrieved through the completion routine or by calling the <c>WSAGetOverlappedResult</c> function.
	/// </para>
	/// <para>
	/// For overlapped sockets, <c>WSARecvMsg</c> is used to post one or more buffers into which incoming data will be placed as it becomes
	/// available, after which the application-specified completion indication (invocation of the completion routine or setting of an event
	/// object) occurs. If the operation does not complete immediately, the final completion status is retrieved through the completion
	/// routine or the <c>WSAGetOverlappedResult</c> function.
	/// </para>
	/// <para>
	/// For non-overlapped sockets, the blocking semantics are identical to that of the standard <c>recv</c> function and the lpOverlapped
	/// and lpCompletionRoutine parameters are ignored. Any data that has already been received and buffered by the transport will be copied
	/// into the specified user buffers. In the case of a blocking socket with no data currently having been received and buffered by the
	/// transport, the call will block until data is received. Windows Sockets 2 does not define any standard blocking time-out mechanism for
	/// this function. For protocols acting as byte-stream protocols the stack tries to return as much data as possible subject to the
	/// available buffer space and amount of received data available. However, receipt of a single byte is sufficient to unblock the caller.
	/// There is no guarantee that more than a single byte will be returned. For protocols acting as message-oriented, a full message is
	/// required to unblock the caller.
	/// </para>
	/// <para><c>Note</c> The <c>SO_RCVTIMEO</c> socket option applies only to blocking sockets.</para>
	/// <para>
	/// The buffers are filled in the order in which they appear in the array pointed to by the <c>lpBuffers</c> member of the <c>WSAMSG</c>
	/// structure pointed to by the lpMsg parameter, and the buffers are packed so that no holes are created.
	/// </para>
	/// <para>
	/// If this function is completed in an overlapped manner, it is the Winsock service provider's responsibility to capture this
	/// <c>WSABUF</c> structure before returning from this call. This enables applications to build stack-based <c>WSABUF</c> arrays pointed
	/// to by the <c>lpBuffers</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter.
	/// </para>
	/// <para>
	/// For message-oriented sockets (a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>), an incoming message is placed into the buffers
	/// up to the total size of the buffers, and the completion indication occurs for overlapped sockets. If the message is larger than the
	/// buffers, the buffers are filled with the first part of the message and the excess data is lost, and <c>WSARecvMsg</c> generates the
	/// error WSAEMSGSIZE.
	/// </para>
	/// <para>
	/// When the IP_PKTINFO socket option is enabled on an IPv4 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, the <c>WSARecvMsg</c>
	/// function returns packet information in the <c>WSAMSG</c> structure pointed to by the lpMsg parameter. One of the control data objects
	/// in the returned <c>WSAMSG</c> structure will contain an <c>in_pktinfo</c> structure used to store received packet address information.
	/// </para>
	/// <para>
	/// For datagrams received over IPv4, the <c>Control</c> member of the <c>WSAMSG</c> structure received will contain a <c>WSABUF</c>
	/// structure that contains a <c>WSACMSGHDR</c> structure. The <c>cmsg_level</c> member of this <c>WSACMSGHDR</c> structure would contain
	/// <c>IPPROTO_IP</c>, the <c>cmsg_type</c> member of this structure would contain <c>IP_PKTINFO</c>, and the <c>cmsg_data</c> member
	/// would contain an <c>in_pktinfo</c> structure used to store received IPv4 packet address information. The IPv4 address in the
	/// <c>in_pktinfo</c> structure is the IPv4 address from which the packet was received.
	/// </para>
	/// <para>
	/// When the IPV6_PKTINFO socket option is enabled on an IPv6 socket of type <c>SOCK_DGRAM</c> or <c>SOCK_RAW</c>, the <c>WSARecvMsg</c>
	/// function returns packet information in the <c>WSAMSG</c> structure pointed to by the lpMsg parameter. One of the control data objects
	/// in the returned <c>WSAMSG</c> structure will contain an <c>in6_pktinfo</c> structure used to store received packet address information.
	/// </para>
	/// <para>
	/// For datagrams received over IPv6, the <c>Control</c> member of the <c>WSAMSG</c> structure received will contain a <c>WSABUF</c>
	/// structure that contains a <c>WSACMSGHDR</c> structure. The <c>cmsg_level</c> member of this <c>WSACMSGHDR</c> structure would contain
	/// <c>IPPROTO_IPV6</c>, the <c>cmsg_type</c> member of this structure would contain <c>IPV6_PKTINFO</c>, and the <c>cmsg_data</c> member
	/// would contain an <c>in6_pktinfo</c> structure used to store received IPv6 packet address information. The IPv6 address in the
	/// <c>in6_pktinfo</c> structure is the IPv6 address from which the packet was received.
	/// </para>
	/// <para>
	/// For a dual-stack datagram socket, if an application requires the <c>WSARecvMsg</c> function to return packet information in a
	/// <c>WSAMSG</c> structure for datagrams received over IPv4, then IP_PKTINFO socket option must be set to true on the socket. If only
	/// the IPV6_PKTINFO option is set to true on the socket, packet information will be provided for datagrams received over IPv6 but may
	/// not be provided for datagrams received over IPv4.
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
	/// function are determined by the socket options and the <c>dwFlags</c> member of the <c>WSAMSG</c> structure. The only possible input
	/// value for the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter is <c>MSG_PEEK</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSG_PEEK</term>
	/// <term>
	/// Peek at the incoming data. The data is copied into the buffer, but is not removed from the input queue. This flag is valid only for
	/// non-overlapped sockets.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The possible values for <c>dwFlags</c> member on input are defined in the Winsock2.h header file.</para>
	/// <para>
	/// On output, the <c>dwFlags</c> member of the <c>WSAMSG</c> structure pointed to by the lpMsg parameter may return a combination of any
	/// of the following values.
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
	/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files has
	/// changed and the possible values for the <c>dwFlags</c> member on output are defined in the Ws2def.h header file which is
	/// automatically included by the Winsock2.h header file.
	/// </para>
	/// <para>
	/// On versions of the Platform Software Development Kit (SDK) for Windows Server 2003 and earlier, the possible values for the
	/// <c>dwFlags</c> member on output are defined in the Mswsock.h header file.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>WSARecvMsg</c> with the lpOverlapped parameter set to NULL, Winsock may
	/// need to wait for a network event before the call can complete. Winsock performs an alertable wait in this situation, which can be
	/// interrupted by an asynchronous procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC
	/// that interrupted an ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by
	/// Winsock clients.
	/// </para>
	/// <para>Overlapped Socket I/O</para>
	/// <para>
	/// If an overlapped operation completes immediately, <c>WSARecvMsg</c> returns a value of zero and the lpNumberOfBytesRecvd parameter is
	/// updated with the number of bytes received and the flag bits indicated by the lpFlags parameter are also updated. If the overlapped
	/// operation is successfully initiated and will complete later, <c>WSARecvMsg</c> returns <c>SOCKET_ERROR</c> and indicates error code
	/// WSA_IO_PENDING. In this case, lpNumberOfBytesRecvd is not updated. When the overlapped operation completes, the amount of data
	/// transferred is indicated either through the cbTransferred parameter in the completion routine (if specified), or through the
	/// lpcbTransfer parameter in <c>WSAGetOverlappedResult</c>. Flag values are obtained by examining the lpdwFlags parameter of <c>WSAGetOverlappedResult</c>.
	/// </para>
	/// <para>
	/// The <c>WSARecvMsg</c> function using overlapped I/O can be called from within the completion routine of a previous <c>WSARecv</c>,
	/// <c>WSARecvFrom</c>, <c>WSARecvMsg</c>, <c>WSASend</c>, <c>WSASendMsg</c>, or <c>WSASendTo</c> function. For a given socket, I/O
	/// completion routines will not be nested. This permits time-sensitive data transmissions to occur entirely within a preemptive context.
	/// </para>
	/// <para>
	/// The lpOverlapped parameter must be valid for the duration of the overlapped operation. If multiple I/O operations are simultaneously
	/// outstanding, each must reference a separate <c>WSAOVERLAPPED</c> structure.
	/// </para>
	/// <para>
	/// If the lpCompletionRoutine parameter is <c>NULL</c>, the hEvent parameter of lpOverlapped is signaled when the overlapped operation
	/// completes if it contains a valid event object handle. An application can use <c>WSAWaitForMultipleEvents</c> or
	/// <c>WSAGetOverlappedResult</c> to wait or poll on the event object.
	/// </para>
	/// <para>
	/// If lpCompletionRoutine is not <c>NULL</c>, the hEvent parameter is ignored and can be used by the application to pass context
	/// information to the completion routine. A caller that passes a non- <c>NULL</c> lpCompletionRoutine and later calls
	/// <c>WSAGetOverlappedResult</c> for the same overlapped I/O request may not set the fWait parameter for that invocation of
	/// <c>WSAGetOverlappedResult</c> to <c>TRUE</c>. In this case the usage of the hEvent parameter is undefined, and attempting to wait on
	/// the hEvent parameter would produce unpredictable results.
	/// </para>
	/// <para>
	/// The completion routine follows the same rules as stipulated for Windows file I/O completion routines. The completion routine will not
	/// be invoked until the thread is in an alertable wait state such as can occur when the function <c>WSAWaitForMultipleEvents</c> with
	/// the fAlertable parameter set to <c>TRUE</c> is invoked.
	/// </para>
	/// <para>The prototype of the completion routine is as follows:</para>
	/// <para>
	/// <code> void CALLBACK CompletionRoutine( IN DWORD dwError, IN DWORD cbTransferred, IN LPWSAOVERLAPPED lpOverlapped, IN DWORD dwFlags );</code>
	/// </para>
	/// <para>
	/// The <c>CompletionRoutine</c> is a placeholder for an application-defined or library-defined function name. The dwError parameter
	/// specifies the completion status for the overlapped operation as indicated by the lpOverlapped parameter. The cbTransferred parameter
	/// specifies the number of bytes received. The dwFlags parameter contains information that is also returned in <c>dwFlags</c> member of
	/// the <c>WSAMSG</c> structure pointed to by the lpMsg parameter if the receive operation had completed immediately. The
	/// <c>CompletionRoutine</c> function does not return a value.
	/// </para>
	/// <para>
	/// Returning from this function allows invocation of another pending completion routine for this socket. When using
	/// <c>WSAWaitForMultipleEvents</c>, all waiting completion routines are called before the alertable thread's wait is satisfied with a
	/// return code of <c>WSA_IO_COMPLETION</c>. The completion routines can be called in any order, not necessarily in the same order the
	/// overlapped operations are completed. However, the posted buffers are guaranteed to be filled in the same order in which they are specified.
	/// </para>
	/// <para>
	/// If you are using I/O completion ports, be aware that the order of calls made to <c>WSARecvMsg</c> is also the order in which the
	/// buffers are populated. The <c>WSARecvMsg</c> function should not be called on the same socket simultaneously from different threads,
	/// because it can result in an unpredictable buffer order.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mswsock/nc-mswsock-lpfn_wsarecvmsg LPFN_WSARECVMSG LpfnWsarecvmsg; INT
	// LpfnWsarecvmsg( SOCKET s, LPWSAMSG lpMsg, LPDWORD lpdwNumberOfBytesRecvd, LPWSAOVERLAPPED lpOverlapped,
	// LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine ) {...}
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_WSARECVMSG")]
	public delegate int LPFN_WSARECVMSG(SOCKET s, ref WSAMSG lpMsg, out uint lpdwNumberOfBytesRecvd, ref WSAOVERLAPPED lpOverlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE? lpCompletionRoutine);

	/// <summary>
	/// The <c>RIO_NOTIFICATION_COMPLETION_TYPE</c> enumeration specifies the type of completion queue notifications to use with the
	/// RIONotify function when sending or receiving data using the Winsock registered I/O extensions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>RIO_NOTIFICATION_COMPLETION_TYPE</c> enumeration is used with the Winsock registered I/O extensions to specify the type of I/O
	/// completion to use with a RIO_CQ. An enumeration value is set in the RIO_NOTIFICATION_COMPLETION structure passed to the
	/// RIOCreateCompletionQueue function when the <c>RIO_CQ</c> is created.
	/// </para>
	/// <para>
	/// When creating a RIO_CQ, the RIO_NOTIFICATION_COMPLETION structure determines how the application will receive completion queue
	/// notifications. If the <c>RIO_NOTIFICATION_COMPLETION</c> structure is provided when creating the completion queue, the application
	/// may call the RIONotify function to request a completion queue notification. Normally this notification occurs when the completion
	/// queue is not empty. This may happen immediately or when the next completion entry is inserted into the completion queue. Once a
	/// completion queue notification is issued, the application must call <c>RIONotify</c> in order to receive another completion queue notification.
	/// </para>
	/// <para>Two options are available for completion queue notification.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Event handles.</term>
	/// </item>
	/// <item>
	/// <term>I/O completion ports</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>Type</c> member of the RIO_NOTIFICATION_COMPLETION structure is set to <c>RIO_EVENT_COMPLETION</c>, an event handle is used
	/// to signal completion queue notifications. An event handle is provided as the <c>EventNotify.EventHandle</c> member in the
	/// <c>RIO_NOTIFICATION_COMPLETION</c> structure passed to the RIOCreateCompletionQueue function.
	/// </para>
	/// <para>
	/// If the <c>Type</c> member of the RIO_NOTIFICATION_COMPLETION structure is set to <c>RIO_IOCP_COMPLETION</c>, an I/O completion port
	/// is used to signal completion queue notifications. An I/O completion port handle is provided as the <c>Iocp.IocpHandle</c> member in
	/// the <c>RIO_NOTIFICATION_COMPLETION</c> structure passed to the RIOCreateCompletionQueue function. The completion of the RIONotify
	/// function for this RIO_CQ will queue an entry to the I/O completion port which can be retrieved using the GetQueuedCompletionStatus or
	/// GetQueuedCompletionStatusEx function.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/ne-mswsock-rio_notification_completion_type typedef enum
	// _RIO_NOTIFICATION_COMPLETION_TYPE { RIO_EVENT_COMPLETION = 1, RIO_IOCP_COMPLETION = 2 } RIO_NOTIFICATION_COMPLETION_TYPE, *PRIO_NOTIFICATION_COMPLETION_TYPE;
	[PInvokeData("mswsock.h", MSDNShortId = "NE:mswsock._RIO_NOTIFICATION_COMPLETION_TYPE")]
	public enum RIO_NOTIFICATION_COMPLETION_TYPE
	{
		/// <summary>
		/// <para>Value: 1</para>
		/// <para>An event handle is used to signal completion queue notifications.</para>
		/// <para>
		/// An event handle is provided as the EventNotify.EventHandle member in the RIO_NOTIFICATION_COMPLETION structure passed to the
		/// RIOCreateCompletionQueue function when the RIO_CQ is created. The completion of the RIONotify function for this RIO_CQ will
		/// signal the event. The Event.NotifyReset member in the RIO_NOTIFICATION_COMPLETION structure passed to the
		/// RIOCreateCompletionQueue function when the RIO_CQ is created indicates whether or not the event should be reset as part of a call
		/// to the RIONotify function.
		/// </para>
		/// </summary>
		RIO_EVENT_COMPLETION = 1,

		/// <summary>
		/// <para>Value: 2</para>
		/// <para>An I/O completion port handle is used to signal completion queue notifications.</para>
		/// <para>
		/// An I/O completion port handle is provided as the Iocp.IocpHandle member in the RIO_NOTIFICATION_COMPLETION structure passed to
		/// the RIOCreateCompletionQueue function when the RIO_CQ is created. The completion of the RIONotify function for this RIO_CQ will
		/// queue an entry to the I/O completion port which can be retrieved using the GetQueuedCompletionStatus or
		/// GetQueuedCompletionStatusEx function. The queued entry will have the returned lpCompletionKey parameter value set to the value
		/// specified in the Iocp.CompletionKey member of the RIO_NOTIFICATION_COMPLETION and the returned lpOverlapped parameter value set
		/// to the value specified in the Iocp.Overlapped member in RIO_NOTIFICATION_COMPLETION structure. The Iocp.Overlapped member in the
		/// RIO_NOTIFICATION_COMPLETION will be a non-NULL value.
		/// </para>
		/// </summary>
		RIO_IOCP_COMPLETION,
	}

	/// <summary>A set of flags used to customize processing of the TransmitPackets function.</summary>
	[PInvokeData("mswsock.h", MSDNShortId = "NC:mswsock.LPFN_TRANSMITPACKETS")]
	[Flags]
	public enum TF : uint
	{
		/// <summary>
		/// Starts a transport-level disconnect after all the file data has been queued for transmission. Applies only to connection-oriented
		/// sockets. Specifying this flag for sockets that do not support disconnect semantics (such as datagram sockets) results in an error.
		/// </summary>
		TF_DISCONNECT = 0x01,

		/// <summary>
		/// Prepares the socket handle to be reused. When the TransmitPackets function completes, the socket handle can be passed to the AcceptEx
		/// function. Valid only when a connection-oriented socket and TF_DISCONNECT are specified.
		/// <para>
		/// <note type="note">The socket level packet transmit is subject to the behavior of the underlying transport. For example, a TCP socket
		/// may be subject to the TCP TIME_WAIT state, causing the TransmitPackets call to be delayed.</note>
		/// </para>
		/// </summary>
		TF_REUSE_SOCKET = 0x02,

		/// <summary>
		/// <para>
		/// Complete the TransmitFile request immediately, without pending. If this flag is specified and TransmitFile succeeds, then the
		/// data has been accepted by the system but not necessarily acknowledged by the remote end. Do not use this setting with the
		/// TF_DISCONNECT and TF_REUSE_SOCKET flags.
		/// </para>
		/// <note type="note">If the file being sent is not in the file system cache, the request pends.</note>
		/// </summary>
		TF_WRITE_BEHIND = 0x04,

		/// <summary>
		/// Directs Winsock to use the system's default thread to process long TransmitPackets requests. Long TransmitPackets requests are
		/// defined as requests that require more than a single read from the file or a cache; the long request definition therefore depends on
		/// the size of the file and the specified length of the send packet.
		/// <para>The system default thread can be adjusted using the following registry parameter as a REG_DWORD:HKEY_LOCAL_MACHINE\CurrentControlSet\Services\AFD\Parameters\TransmitWorker</para>
		/// </summary>
		TF_USE_DEFAULT_WORKER = 0x00,

		/// <summary>
		/// Directs Winsock to use system threads to process long TransmitPackets requests. Long TransmitPackets requests are defined as requests
		/// that require more than a single read from the file or a cache; the long request definition therefore depends on the size of the file
		/// and the specified length of the send packet.
		/// </summary>
		TF_USE_SYSTEM_THREAD = 0x10,

		/// <summary>
		/// Directs Winsock to use kernel Asynchronous Procedure Calls (APCs) instead of worker threads to process long TransmitPackets requests.
		/// Long TransmitPackets requests are defined as requests that require more than a single read from the file or a cache; the long request
		/// definition therefore depends on the size of the file and the specified length of the send packet. See Remarks for more information.
		/// </summary>
		TF_USE_KERNEL_APC = 0x20,
	}

	/// <summary>Flags used to describe the contents of the packet array element, and to customize <c>TransmitPackets</c> function processing.</summary>
	[PInvokeData("mswsock.h", MSDNShortId = "NS:mswsock._TRANSMIT_PACKETS_ELEMENT")]
	[Flags]
	public enum TP_ELEMENT : uint
	{
		/// <summary>Specifies that data resides in memory. Mutually exclusive with TP_ELEMENT_FILE.</summary>
		TP_ELEMENT_MEMORY = 1,

		/// <summary>Specifies that data resides in a file. Default setting for <c>dwElFlags</c>. Mutually exclusive with TP_ELEMENT_MEMORY.</summary>
		TP_ELEMENT_FILE = 2,

		/// <summary>
		/// Specifies that this element should not be combined with the next element in a single send request from the sockets layer to the
		/// transport. This flag is used for granular control of the content of each message on a datagram or message-oriented socket.
		/// </summary>
		TP_ELEMENT_EOP = 4,
	}

	/// <summary>
	/// The <c>AcceptEx</c> function accepts a new connection, returns the local and remote address, and receives the first block of data
	/// sent by the client application.
	/// </summary>
	/// <param name="sListenSocket">
	/// A descriptor identifying a socket that has already been called with the listen function. A server application waits for attempts to
	/// connect on this socket.
	/// </param>
	/// <param name="sAcceptSocket">
	/// A descriptor identifying a socket on which to accept an incoming connection. This socket must not be bound or connected.
	/// </param>
	/// <param name="lpOutputBuffer">
	/// A pointer to a buffer that receives the first block of data sent on a new connection, the local address of the server, and the remote
	/// address of the client. The receive data is written to the first part of the buffer starting at offset zero, while the addresses are
	/// written to the latter part of the buffer. This parameter must be specified.
	/// </param>
	/// <param name="dwReceiveDataLength">
	/// The number of bytes in <c>lpOutputBuffer</c> that will be used for actual receive data at the beginning of the buffer. This size
	/// should not include the size of the local address of the server, nor the remote address of the client; they are appended to the output
	/// buffer. If <c>dwReceiveDataLength</c> is zero, accepting the connection will not result in a receive operation. Instead,
	/// <c>AcceptEx</c> completes as soon as a connection arrives, without waiting for any data.
	/// </param>
	/// <param name="dwLocalAddressLength">
	/// The number of bytes reserved for the local address information. This value must be at least 16 bytes more than the maximum address
	/// length for the transport protocol in use.
	/// </param>
	/// <param name="dwRemoteAddressLength">
	/// The number of bytes reserved for the remote address information. This value must be at least 16 bytes more than the maximum address
	/// length for the transport protocol in use. Cannot be zero.
	/// </param>
	/// <param name="lpdwBytesReceived">
	/// A pointer to a <c>DWORD</c> that receives the count of bytes received. This parameter is set only if the operation completes
	/// synchronously. If it returns ERROR_IO_PENDING and is completed later, then this <c>DWORD</c> is never set and you must obtain the
	/// number of bytes read from the completion notification mechanism.
	/// </param>
	/// <param name="lpOverlapped">
	/// An OVERLAPPED structure that is used to process the request. This parameter must be specified; it cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If no error occurs, the <c>AcceptEx</c> function completed successfully and a value of <c>TRUE</c> is returned.</para>
	/// <para>
	/// If the function fails, <c>AcceptEx</c> returns <c>FALSE</c>. The WSAGetLastError function can then be called to return extended error
	/// information. If <c>WSAGetLastError</c> returns <c>ERROR_IO_PENDING</c>, then the operation was successfully initiated and is still in
	/// progress. If the error is WSAECONNRESET, an incoming connection was indicated, but was subsequently terminated by the remote peer
	/// prior to accepting the call.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>AcceptEx</c> function combines several socket functions into a single API/kernel transition. The <c>AcceptEx</c> function,
	/// when successful, performs three tasks:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>A new connection is accepted.</term>
	/// </item>
	/// <item>
	/// <term>Both the local and remote addresses for the connection are returned.</term>
	/// </item>
	/// <item>
	/// <term>The first block of data sent by the remote is received.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The function pointer for the <c>AcceptEx</c> function must be obtained at run time by making a call to the WSAIoctl
	/// function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_ACCEPTEX</c>, a globally unique identifier (GUID) whose value identifies the <c>AcceptEx</c> extension
	/// function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the <c>AcceptEx</c> function. The
	/// <c>WSAID_ACCEPTEX</c> GUID is defined in the <c>Mswsock.h</c> header file.
	/// </para>
	/// <para>A program can make a connection to a socket more quickly using <c>AcceptEx</c> instead of the accept function.</para>
	/// <para>A single output buffer receives the data, the local socket address (the server), and the remote socket address (the client).</para>
	/// <para>
	/// Using a single buffer improves performance. When using <c>AcceptEx</c>, the GetAcceptExSockaddrs function must be called to parse the
	/// buffer into its three distinct parts (data, local socket address, and remote socket address). On Windows XP and later, once the
	/// <c>AcceptEx</c> function completes and the <c>SO_UPDATE_ACCEPT_CONTEXT</c> option is set on the accepted socket, the local address
	/// associated with the accepted socket can also be retrieved using the getsockname function. Likewise, the remote address associated
	/// with the accepted socket can be retrieved using the getpeername function.
	/// </para>
	/// <para>
	/// The buffer size for the local and remote address must be 16 bytes more than the size of the sockaddr structure for the transport
	/// protocol in use because the addresses are written in an internal format. For example, the size of a <c>sockaddr_in</c> (the address
	/// structure for TCP/IP) is 16 bytes. Therefore, a buffer size of at least 32 bytes must be specified for the local and remote addresses.
	/// </para>
	/// <para>
	/// The <c>AcceptEx</c> function uses overlapped I/O, unlike the accept function. If your application uses <c>AcceptEx</c>, it can
	/// service a large number of clients with a relatively small number of threads. As with all overlapped Windows functions, either Windows
	/// events or completion ports can be used as a completion notification mechanism.
	/// </para>
	/// <para>
	/// Another key difference between the <c>AcceptEx</c> function and the accept function is that <c>AcceptEx</c> requires the caller to
	/// already have two sockets:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>One that specifies the socket on which to listen.</term>
	/// </item>
	/// <item>
	/// <term>One that specifies the socket on which to accept the connection.</term>
	/// </item>
	/// </list>
	/// <para>The <c>sAcceptSocket</c> parameter must be an open socket that is neither bound nor connected.</para>
	/// <para>
	/// The <c>lpNumberOfBytesTransferred</c> parameter of the GetQueuedCompletionStatus function or the GetOverlappedResult function
	/// indicates the number of bytes received in the request.
	/// </para>
	/// <para>When this operation is successfully completed, <c>sAcceptSocket</c> can be passed, but to the following functions only:</para>
	/// <list/>
	/// <para>
	/// <c>Note</c> If the TransmitFile function is called with both the TF_DISCONNECT and TF_REUSE_SOCKET flags, the specified socket has
	/// been returned to a state in which it is neither bound nor connected. The socket handle can then be passed to the <c>AcceptEx</c>
	/// function in the <c>sAcceptSocket</c> parameter, but the socket cannot be passed to the ConnectEx function.
	/// </para>
	/// <para>
	/// When the <c>AcceptEx</c> function returns, the socket <c>sAcceptSocket</c> is in the default state for a connected socket. The socket
	/// <c>sAcceptSocket</c> does not inherit the properties of the socket associated with <c>sListenSocket</c> parameter until
	/// SO_UPDATE_ACCEPT_CONTEXT is set on the socket. Use the setsockopt function to set the SO_UPDATE_ACCEPT_CONTEXT option, specifying
	/// <c>sAcceptSocket</c> as the socket handle and <c>sListenSocket</c> as the option value.
	/// </para>
	/// <para>For example:</para>
	/// <para>
	/// If a receive buffer is provided, the overlapped operation will not complete until a connection is accepted and data is read. Use the
	/// getsockopt function with the SO_CONNECT_TIME option to check whether a connection has been accepted. If it has been accepted, you can
	/// determine how long the connection has been established. The return value is the number of seconds that the socket has been connected.
	/// If the socket is not connected, the <c>getsockopt</c> returns 0xFFFFFFFF. Applications that check whether the overlapped operation
	/// has completed, in combination with the SO_CONNECT_TIME option, can determine that a connection has been accepted but no data has been
	/// received. Scrutinizing a connection in this manner enables an application to determine whether connections that have been established
	/// for a while have received no data. It is recommended such connections be terminated by closing the accepted socket, which forces the
	/// <c>AcceptEx</c> function call to complete with an error.
	/// </para>
	/// <para>For example:</para>
	/// <para>
	/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
	/// operations can fail if the thread is closed before the operations complete. See ExitThread for more information.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example uses the <c>AcceptEx</c> function using overlapped I/O and completion ports.</para>
	/// <para>Notes for QoS</para>
	/// <para>
	/// The TransmitFile function allows the setting of two flags, TF_DISCONNECT or TF_REUSE_SOCKET, that return the socket to a
	/// "disconnected, reusable" state after the file has been transmitted. These flags should not be used on a socket where quality of
	/// service has been requested, since the service provider may immediately delete any quality of service associated with the socket
	/// before the file transfer has completed. The best approach for a QoS-enabled socket is to simply call the closesocket function when
	/// the file transfer has completed, rather than relying on these flags.
	/// </para>
	/// <para>Notes for ATM</para>
	/// <para>
	/// There are important issues associated with connection setup when using Asynchronous Transfer Mode (ATM) with Windows Sockets 2.
	/// Please see the Remarks section in the accept function documentation for important ATM connection setup information.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nf-mswsock-acceptex BOOL AcceptEx( [in] SOCKET sListenSocket, [in] SOCKET
	// sAcceptSocket, [in] PVOID lpOutputBuffer, [in] DWORD dwReceiveDataLength, [in] DWORD dwLocalAddressLength, [in] DWORD
	// dwRemoteAddressLength, [out] LPDWORD lpdwBytesReceived, [in] LPOVERLAPPED lpOverlapped );
	[PInvokeData("mswsock.h", MSDNShortId = "NF:mswsock.AcceptEx")]
	[DllImport(Lib_Mswsock, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AcceptEx([In] SOCKET sListenSocket, [In] SOCKET sAcceptSocket, [In] IntPtr lpOutputBuffer,
		uint dwReceiveDataLength, uint dwLocalAddressLength, uint dwRemoteAddressLength, out uint lpdwBytesReceived,
		in NativeOverlapped lpOverlapped);

	/// <summary>
	/// The <c>GetAcceptExSockaddrs</c> function parses the data obtained from a call to the AcceptEx function and passes the local and
	/// remote addresses to a sockaddr structure.
	/// </summary>
	/// <param name="lpOutputBuffer">
	/// A pointer to a buffer that receives the first block of data sent on a connection resulting from an AcceptEx call. Must be the same
	/// <c>lpOutputBuffer</c> parameter that was passed to the <c>AcceptEx</c> function.
	/// </param>
	/// <param name="dwReceiveDataLength">
	/// The number of bytes in the buffer used for receiving the first data. This value must be equal to the <c>dwReceiveDataLength</c>
	/// parameter that was passed to the AcceptEx function.
	/// </param>
	/// <param name="dwLocalAddressLength">
	/// The number of bytes reserved for the local address information. This value must be equal to the <c>dwLocalAddressLength</c> parameter
	/// that was passed to the AcceptEx function.
	/// </param>
	/// <param name="dwRemoteAddressLength">
	/// The number of bytes reserved for the remote address information. This value must be equal to the <c>dwRemoteAddressLength</c>
	/// parameter that was passed to the AcceptEx function.
	/// </param>
	/// <param name="LocalSockaddr">
	/// A pointer to the sockaddr structure that receives the local address of the connection (the same information that would be returned by
	/// the getsockname function). This parameter must be specified.
	/// </param>
	/// <param name="LocalSockaddrLength">The size, in bytes, of the local address. This parameter must be specified.</param>
	/// <param name="RemoteSockaddr">
	/// A pointer to the sockaddr structure that receives the remote address of the connection (the same information that would be returned
	/// by the getpeername function). This parameter must be specified.
	/// </param>
	/// <param name="RemoteSockaddrLength">The size, in bytes, of the local address. This parameter must be specified.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The <c>GetAcceptExSockaddrs</c> function is used exclusively with the AcceptEx function to parse the first data that the socket
	/// receives into local and remote addresses. The <c>AcceptEx</c> function returns local and remote address information in an internal
	/// format. Application developers need to use the <c>GetAcceptExSockaddrs</c> function if there is a need for the sockaddr structures
	/// containing the local or remote addresses.
	/// </para>
	/// <para>
	/// <c>Note</c> The function pointer for the <c>GetAcceptExSockaddrs</c> function must be obtained at run time by making a call to the
	/// WSAIoctl function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c>
	/// function must contain <c>WSAID_GETACCEPTEXSOCKADDRS</c>, a globally unique identifier (GUID) whose value identifies the
	/// <c>GetAcceptExSockaddrs</c> extension function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to
	/// the <c>GetAcceptExSockaddrs</c> function. The <c>WSAID_GETACCEPTEXSOCKADDRS</c> GUID is defined in the <c>Mswsock.h</c> header file.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nf-mswsock-getacceptexsockaddrs void GetAcceptExSockaddrs( [in] PVOID
	// lpOutputBuffer, [in] DWORD dwReceiveDataLength, [in] DWORD dwLocalAddressLength, [in] DWORD dwRemoteAddressLength, [out] sockaddr
	// **LocalSockaddr, [out] LPINT LocalSockaddrLength, [out] sockaddr **RemoteSockaddr, [out] LPINT RemoteSockaddrLength );
	[PInvokeData("mswsock.h", MSDNShortId = "NF:mswsock.GetAcceptExSockaddrs")]
	[DllImport(Lib_Mswsock, SetLastError = false, ExactSpelling = true)]
	public static extern void GetAcceptExSockaddrs([In] IntPtr lpOutputBuffer, uint dwReceiveDataLength, uint dwLocalAddressLength,
		uint dwRemoteAddressLength, out IntPtr LocalSockaddr, out int LocalSockaddrLength, out IntPtr RemoteSockaddr,
		out int RemoteSockaddrLength);

	/// <summary>
	/// The <c>TransmitFile</c> function transmits file data over a connected socket handle. This function uses the operating system's cache
	/// manager to retrieve the file data, and provides high-performance file data transfer over sockets.
	/// </summary>
	/// <param name="hSocket">
	/// A handle to a connected socket. The <c>TransmitFile</c> function will transmit the file data over this socket. The socket specified
	/// by the <c>hSocket</c> parameter must be a connection-oriented socket of type <c>SOCK_STREAM</c>, <c>SOCK_SEQPACKET</c>, or <c>SOCK_RDM</c>.
	/// </param>
	/// <param name="hFile">
	/// <para>
	/// A handle to the open file that the <c>TransmitFile</c> function transmits. Since the operating system reads the file data
	/// sequentially, you can improve caching performance by opening the handle with FILE_FLAG_SEQUENTIAL_SCAN.
	/// </para>
	/// <para>
	/// The <c>hFile</c> parameter is optional. If the <c>hFile</c> parameter is <c>NULL</c>, only data in the header and/or the tail buffer
	/// is transmitted. Any additional action, such as socket disconnect or reuse, is performed as specified by the <c>dwFlags</c> parameter.
	/// </para>
	/// </param>
	/// <param name="nNumberOfBytesToWrite">
	/// <para>
	/// The number of bytes in the file to transmit. The <c>TransmitFile</c> function completes when it has sent the specified number of
	/// bytes, or when an error occurs, whichever occurs first.
	/// </para>
	/// <para>Set this parameter to zero in order to transmit the entire file.</para>
	/// </param>
	/// <param name="nNumberOfBytesPerSend">
	/// <para>
	/// The size, in bytes, of each block of data sent in each send operation. This parameter is used by Windows' sockets layer to determine
	/// the block size for send operations. To select the default send size, set this parameter to zero.
	/// </para>
	/// <para>The <c>nNumberOfBytesPerSend</c> parameter is useful for protocols that have limitations on the size of individual send requests.</para>
	/// </param>
	/// <param name="lpOverlapped">
	/// <para>
	/// A pointer to an OVERLAPPED structure. If the socket handle has been opened as overlapped, specify this parameter in order to achieve
	/// an overlapped (asynchronous) I/O operation. By default, socket handles are opened as overlapped.
	/// </para>
	/// <para>
	/// You can use the <c>lpOverlapped</c> parameter to specify a 64-bit offset within the file at which to start the file data transfer by
	/// setting the <c>Offset</c> and <c>OffsetHigh</c> member of the OVERLAPPED structure. If <c>lpOverlapped</c> is a <c>NULL</c> pointer,
	/// the transmission of data always starts at the current byte offset in the file.
	/// </para>
	/// <para>
	/// When the <c>lpOverlapped</c> is not <c>NULL</c>, the overlapped I/O might not finish before <c>TransmitFile</c> returns. In that
	/// case, the <c>TransmitFile</c> function returns <c>FALSE</c>, and WSAGetLastError returns ERROR_IO_PENDING or WSA_IO_PENDING. This
	/// enables the caller to continue processing while the file transmission operation completes. Windows will set the event specified by
	/// the <c>hEvent</c> member of the OVERLAPPED structure, or the socket specified by <c>hSocket</c>, to the signaled state upon
	/// completion of the data transmission request.
	/// </para>
	/// </param>
	/// <param name="lpTransmitBuffers">
	/// A pointer to a TRANSMIT_FILE_BUFFERS data structure that contains pointers to data to send before and after the file data is sent.
	/// This parameter should be set to a <c>NULL</c> pointer if you want to transmit only the file data.
	/// </param>
	/// <param name="dwReserved">
	/// <para>
	/// A set of flags used to modify the behavior of the <c>TransmitFile</c> function call. The <c>dwFlags</c> parameter can contain a
	/// combination of the following options defined in the <c>Mswsock.h</c> header file:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>TF_DISCONNECT</c></term>
	/// <term>Start a transport-level disconnect after all the file data has been queued for transmission.</term>
	/// </item>
	/// <item>
	/// <term><c>TF_REUSE_SOCKET</c></term>
	/// <term>
	/// Prepare the socket handle to be reused. This flag is valid only if <c>TF_DISCONNECT</c> is also specified. When the
	/// <c>TransmitFile</c> request completes, the socket handle can be passed to the function call previously used to establish the
	/// connection, such as AcceptEx or ConnectEx. Such reuse is mutually exclusive; for example, if the <c>AcceptEx</c> function was called
	/// for the socket, reuse is allowed only for subsequent calls to the <c>AcceptEx</c> function, and not allowed for a subsequent call to <c>ConnectEx</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>TF_USE_DEFAULT_WORKER</c></term>
	/// <term>
	/// Directs the Windows Sockets service provider to use the system's default thread to process long <c>TransmitFile</c> requests. The
	/// system default thread can be adjusted using the following registry parameter as a <c>REG_DWORD</c>: <c>HKEY_LOCAL_MACHINE</c>\
	/// <c>CurrentControlSet</c>\ <c>Services</c>\ <c>AFD</c>\ <c>Parameters</c>\ <c>TransmitWorker</c>
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>TF_USE_SYSTEM_THREAD</c></term>
	/// <term>Directs the Windows Sockets service provider to use system threads to process long <c>TransmitFile</c> requests.</term>
	/// </item>
	/// <item>
	/// <term><c>TF_USE_KERNEL_APC</c></term>
	/// <term>
	/// Directs the driver to use kernel asynchronous procedure calls (APCs) instead of worker threads to process long <c>TransmitFile</c>
	/// requests. Long <c>TransmitFile</c> requests are defined as requests that require more than a single read from the file or a cache;
	/// the request therefore depends on the size of the file and the specified length of the send packet. Use of TF_USE_KERNEL_APC can
	/// deliver significant performance benefits. It is possible (though unlikely), however, that the thread in which context
	/// <c>TransmitFile</c> is initiated is being used for heavy computations; this situation may prevent APCs from launching. Note that the
	/// Winsock kernel mode driver uses normal kernel APCs, which launch whenever a thread is in a wait state, which differs from user-mode
	/// APCs, which launch whenever a thread is in an alertable wait state initiated in user mode).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>TF_WRITE_BEHIND</c></term>
	/// <term>
	/// Complete the <c>TransmitFile</c> request immediately, without pending. If this flag is specified and <c>TransmitFile</c> succeeds,
	/// then the data has been accepted by the system but not necessarily acknowledged by the remote end. Do not use this setting with the
	/// TF_DISCONNECT and TF_REUSE_SOCKET flags.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the <c>TransmitFile</c> function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>. To get
	/// extended error information, call WSAGetLastError. An error code of WSA_IO_PENDING or ERROR_IO_PENDING indicates that the overlapped
	/// operation has been successfully initiated and that completion will be indicated at a later time. Any other error code indicates that
	/// the overlapped operation was not successfully initiated and no completion indication will occur. Applications should handle either
	/// ERROR_IO_PENDING or WSA_IO_PENDING in this case.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAECONNABORTED</c></term>
	/// <term>
	/// An established connection was aborted by the software in your host machine. This error is returned if the virtual circuit was
	/// terminated due to a time-out or other failure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAECONNRESET</c></term>
	/// <term>
	/// An existing connection was forcibly closed by the remote host. This error is returned for a stream socket when the virtual circuit
	/// was reset by the remote side. The application should close the socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if the
	/// <c>lpTransmitBuffers</c> or <c>lpOverlapped</c> parameter is not totally contained in a valid part of the user address space.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid argument was supplied. This error is returned if the <c>hSocket</c> parameter specified a socket of type <c>SOCK_DGRAM</c>
	/// or <c>SOCK_RAW</c>. This error is returned if the <c>dwFlags</c> parameter has the <c>TF_REUSE_SOCKET</c> flag set, but the
	/// <c>TF_DISCONNECT</c> flag was not set. This error is also returned if the offset specified in the OVERLAPPED structure pointed to by
	/// the <c>lpOverlapped</c> is not within the file. This error is also returned if the <c>nNumberOfBytesToWrite</c> parameter is set to a
	/// value greater than 2,147,483,646, the maximum value for a 32-bit integer minus 1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETDOWN</c></term>
	/// <term>A socket operation encountered a dead network.This error is returned if the network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETRESET</c></term>
	/// <term>The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full. This
	/// error is also returned if the Windows Sockets provider reports a buffer deadlock.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTCONN</c></term>
	/// <term>A request to send or receive data was disallowed because the socket is not connected.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>
	/// An operation was attempted on something that is not a socket. This error is returned if the <c>hSocket</c> parameter is not a socket.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAESHUTDOWN</c></term>
	/// <term>
	/// A request to send or receive data was disallowed because the socket had already been shut down in that direction with a previous
	/// shutdown call. This error is returned if the socket has been shut down for sending. It is not possible to call TransmitFile on a
	/// socket after the shutdown function has been called on the socket with the <c>how</c> parameter set to <c>SD_SEND</c> or <c>SD_BOTH</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSANOTINITIALISED</c></term>
	/// <term>
	/// Either the application has not called the WSAStartup function, or <c>WSAStartup</c> failed. A successful <c>WSAStartup</c> call must
	/// occur before using the TransmitFile function.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_IO_PENDING</c></term>
	/// <term>
	/// An overlapped I/O operation is in progress. This value is returned if an overlapped I/O operation was successfully initiated and
	/// indicates that completion will be indicated at a later time.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_OPERATION_ABORTED</c></term>
	/// <term>
	/// The I/O operation has been aborted because of either a thread exit or an application request. This error is returned if the
	/// overlapped operation has been canceled due to the closure of the socket, the execution of the "SIO_FLUSH" command in WSAIoctl, or the
	/// thread that initiated the overlapped request exited before the operation completed.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>TransmitFile</c> function uses the operating system's cache manager to retrieve the file data, and provide high-performance
	/// file data transfer over sockets.
	/// </para>
	/// <para>
	/// The <c>TransmitFile</c> function only supports connection-oriented sockets of type <c>SOCK_STREAM</c>, <c>SOCK_SEQPACKET</c>, and
	/// <c>SOCK_RDM</c>. Sockets of type <c>SOCK_DGRAM</c> and <c>SOCK_RAW</c> are not supported. The TransmitPackets function can be used
	/// with sockets of type <c>SOCK_DGRAM</c>.
	/// </para>
	/// <para>
	/// The maximum number of bytes that can be transmitted using a single call to the <c>TransmitFile</c> function is 2,147,483,646, the
	/// maximum value for a 32-bit integer minus 1. The maximum number of bytes to send in a single call includes any data sent before or
	/// after the file data pointed to by the <c>lpTransmitBuffers</c> parameter plus the value specified in the <c>nNumberOfBytesToWrite</c>
	/// parameter for the length of file data to send. If an application needs to transmit a file larger than 2,147,483,646 bytes, then
	/// multiple calls to the <c>TransmitFile</c> function can be used with each call transferring no more than 2,147,483,646 bytes. Setting
	/// the <c>nNumberOfBytesToWrite</c> parameter to zero for a file larger than 2,147,483,646 bytes will also fail since in this case the
	/// <c>TransmitFile</c> function will use the size of the file as the value for the number of bytes to transmit.
	/// </para>
	/// <para>
	/// <c>Note</c> The function pointer for the <c>TransmitFile</c> function must be obtained at run time by making a call to the WSAIoctl
	/// function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_TRANSMITFILE</c>, a globally unique identifier (GUID) whose value identifies the <c>TransmitFile</c> extension
	/// function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the <c>TransmitFile</c> function. The
	/// <c>WSAID_TRANSMITFILE</c> GUID is defined in the <c>Mswsock.h</c> header file.
	/// </para>
	/// <para>
	/// <c>Note</c><c>TransmitFile</c> is not functional on transports that perform their own buffering. Transports with the
	/// TDI_SERVICE_INTERNAL_BUFFERING flag set, such as ADSP, perform their own buffering. Because <c>TransmitFile</c> achieves its
	/// performance gains by sending data directly from the file cache. Transports that run out of buffer space on a particular connection
	/// are not handled by <c>TransmitFile</c>, and as a result of running out of buffer space on the connection, <c>TransmitFile</c> returns STATUS_DEVICE_NOT_READY.
	/// </para>
	/// <para>
	/// The <c>TransmitFile</c> function was primarily added to Winsock for use by high-performance server applications (web and ftp servers,
	/// for example).
	/// </para>
	/// <para>
	/// Workstation and client versions of Windows optimize the <c>TransmitFile</c> function for minimum memory and resource utilization by
	/// limiting the number of concurrent <c>TransmitFile</c> operations allowed on the system to a maximum of two. On Windows Vista, Windows
	/// XP, Windows 2000 Professional, and Windows NT Workstation 3.51 and later only two outstanding <c>TransmitFile</c> requests are
	/// handled simultaneously; the third request will wait until one of the previous requests is completed.
	/// </para>
	/// <para>
	/// Server versions of Windows optimize the <c>TransmitFile</c> function for high performance. On server versions, there are no default
	/// limits placed on the number of concurrent <c>TransmitFile</c> operations allowed on the system. Expect better performance results
	/// when using <c>TransmitFile</c> on server versions of Windows. On server versions of Windows, it is possible to set a limit on the
	/// maximum number of concurrent <c>TransmitFile</c> operations by creating a registry entry and setting a value for the following <c>REG_DWORD</c>:
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>\ <c>CurrentControlSet</c>\ <c>Services</c>\ <c>AFD</c>\ <c>Parameters</c>\ <c>MaxActiveTransmitFileCount</c></para>
	/// <para>
	/// If the <c>TransmitFile</c> function is called with TCP socket (protocol of IPPROTO_TCP) with both the <c>TF_DISCONNECT</c> and
	/// <c>TF_REUSE_SOCKET</c> flags specified, the call will not complete until the two following conditions are met.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>All pending receive data sent by remote side (received prior to a FIN from the remote side) on the TCP socket has been read.</term>
	/// </item>
	/// <item>
	/// <term>The remote side has closed the connection (completed the graceful TCP connection closure).</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>TransmitFile</c> function is called with the <c>lpOverlapped</c> parameter set to <c>NULL</c>, the operation is executed as
	/// synchronous I/O. The function will not complete until the file has been sent.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// <para>Notes for QoS</para>
	/// <para>
	/// The <c>TransmitFile</c> function allows the setting of two flags, TF_DISCONNECT or TF_REUSE_SOCKET, that return the socket to a
	/// "disconnected, reusable" state after the file has been transmitted. These flags should not be used on a socket where quality of
	/// service has been requested, since the service provider may immediately delete any quality of service associated with the socket
	/// before the file transfer has completed. The best approach for a QoS-enabled socket is to simply call the closesocket function when
	/// the file transfer has completed, rather than relying on these flags.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nf-mswsock-transmitfile BOOL TransmitFile( SOCKET hSocket, HANDLE hFile,
	// DWORD nNumberOfBytesToWrite, DWORD nNumberOfBytesPerSend, LPOVERLAPPED lpOverlapped, LPTRANSMIT_FILE_BUFFERS lpTransmitBuffers, DWORD
	// dwReserved );
	[PInvokeData("mswsock.h", MSDNShortId = "NF:mswsock.TransmitFile")]
	[DllImport(Lib_Mswsock, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TransmitFile(SOCKET hSocket, [Optional] HFILE hFile, uint nNumberOfBytesToWrite,
		uint nNumberOfBytesPerSend, in NativeOverlapped lpOverlapped, in TRANSMIT_FILE_BUFFERS lpTransmitBuffers,
		uint dwReserved = 0);

	/// <summary>
	/// The <c>TransmitFile</c> function transmits file data over a connected socket handle. This function uses the operating system's cache
	/// manager to retrieve the file data, and provides high-performance file data transfer over sockets.
	/// </summary>
	/// <param name="hSocket">
	/// A handle to a connected socket. The <c>TransmitFile</c> function will transmit the file data over this socket. The socket specified
	/// by the <c>hSocket</c> parameter must be a connection-oriented socket of type <c>SOCK_STREAM</c>, <c>SOCK_SEQPACKET</c>, or <c>SOCK_RDM</c>.
	/// </param>
	/// <param name="hFile">
	/// <para>
	/// A handle to the open file that the <c>TransmitFile</c> function transmits. Since the operating system reads the file data
	/// sequentially, you can improve caching performance by opening the handle with FILE_FLAG_SEQUENTIAL_SCAN.
	/// </para>
	/// <para>
	/// The <c>hFile</c> parameter is optional. If the <c>hFile</c> parameter is <c>NULL</c>, only data in the header and/or the tail buffer
	/// is transmitted. Any additional action, such as socket disconnect or reuse, is performed as specified by the <c>dwFlags</c> parameter.
	/// </para>
	/// </param>
	/// <param name="nNumberOfBytesToWrite">
	/// <para>
	/// The number of bytes in the file to transmit. The <c>TransmitFile</c> function completes when it has sent the specified number of
	/// bytes, or when an error occurs, whichever occurs first.
	/// </para>
	/// <para>Set this parameter to zero in order to transmit the entire file.</para>
	/// </param>
	/// <param name="nNumberOfBytesPerSend">
	/// <para>
	/// The size, in bytes, of each block of data sent in each send operation. This parameter is used by Windows' sockets layer to determine
	/// the block size for send operations. To select the default send size, set this parameter to zero.
	/// </para>
	/// <para>The <c>nNumberOfBytesPerSend</c> parameter is useful for protocols that have limitations on the size of individual send requests.</para>
	/// </param>
	/// <param name="lpOverlapped">
	/// <para>
	/// A pointer to an OVERLAPPED structure. If the socket handle has been opened as overlapped, specify this parameter in order to achieve
	/// an overlapped (asynchronous) I/O operation. By default, socket handles are opened as overlapped.
	/// </para>
	/// <para>
	/// You can use the <c>lpOverlapped</c> parameter to specify a 64-bit offset within the file at which to start the file data transfer by
	/// setting the <c>Offset</c> and <c>OffsetHigh</c> member of the OVERLAPPED structure. If <c>lpOverlapped</c> is a <c>NULL</c> pointer,
	/// the transmission of data always starts at the current byte offset in the file.
	/// </para>
	/// <para>
	/// When the <c>lpOverlapped</c> is not <c>NULL</c>, the overlapped I/O might not finish before <c>TransmitFile</c> returns. In that
	/// case, the <c>TransmitFile</c> function returns <c>FALSE</c>, and WSAGetLastError returns ERROR_IO_PENDING or WSA_IO_PENDING. This
	/// enables the caller to continue processing while the file transmission operation completes. Windows will set the event specified by
	/// the <c>hEvent</c> member of the OVERLAPPED structure, or the socket specified by <c>hSocket</c>, to the signaled state upon
	/// completion of the data transmission request.
	/// </para>
	/// </param>
	/// <param name="lpTransmitBuffers">
	/// A pointer to a TRANSMIT_FILE_BUFFERS data structure that contains pointers to data to send before and after the file data is sent.
	/// This parameter should be set to a <c>NULL</c> pointer if you want to transmit only the file data.
	/// </param>
	/// <param name="dwReserved">
	/// <para>
	/// A set of flags used to modify the behavior of the <c>TransmitFile</c> function call. The <c>dwFlags</c> parameter can contain a
	/// combination of the following options defined in the <c>Mswsock.h</c> header file:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>TF_DISCONNECT</c></term>
	/// <term>Start a transport-level disconnect after all the file data has been queued for transmission.</term>
	/// </item>
	/// <item>
	/// <term><c>TF_REUSE_SOCKET</c></term>
	/// <term>
	/// Prepare the socket handle to be reused. This flag is valid only if <c>TF_DISCONNECT</c> is also specified. When the
	/// <c>TransmitFile</c> request completes, the socket handle can be passed to the function call previously used to establish the
	/// connection, such as AcceptEx or ConnectEx. Such reuse is mutually exclusive; for example, if the <c>AcceptEx</c> function was called
	/// for the socket, reuse is allowed only for subsequent calls to the <c>AcceptEx</c> function, and not allowed for a subsequent call to <c>ConnectEx</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>TF_USE_DEFAULT_WORKER</c></term>
	/// <term>
	/// Directs the Windows Sockets service provider to use the system's default thread to process long <c>TransmitFile</c> requests. The
	/// system default thread can be adjusted using the following registry parameter as a <c>REG_DWORD</c>: <c>HKEY_LOCAL_MACHINE</c>\
	/// <c>CurrentControlSet</c>\ <c>Services</c>\ <c>AFD</c>\ <c>Parameters</c>\ <c>TransmitWorker</c>
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>TF_USE_SYSTEM_THREAD</c></term>
	/// <term>Directs the Windows Sockets service provider to use system threads to process long <c>TransmitFile</c> requests.</term>
	/// </item>
	/// <item>
	/// <term><c>TF_USE_KERNEL_APC</c></term>
	/// <term>
	/// Directs the driver to use kernel asynchronous procedure calls (APCs) instead of worker threads to process long <c>TransmitFile</c>
	/// requests. Long <c>TransmitFile</c> requests are defined as requests that require more than a single read from the file or a cache;
	/// the request therefore depends on the size of the file and the specified length of the send packet. Use of TF_USE_KERNEL_APC can
	/// deliver significant performance benefits. It is possible (though unlikely), however, that the thread in which context
	/// <c>TransmitFile</c> is initiated is being used for heavy computations; this situation may prevent APCs from launching. Note that the
	/// Winsock kernel mode driver uses normal kernel APCs, which launch whenever a thread is in a wait state, which differs from user-mode
	/// APCs, which launch whenever a thread is in an alertable wait state initiated in user mode).
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>TF_WRITE_BEHIND</c></term>
	/// <term>
	/// Complete the <c>TransmitFile</c> request immediately, without pending. If this flag is specified and <c>TransmitFile</c> succeeds,
	/// then the data has been accepted by the system but not necessarily acknowledged by the remote end. Do not use this setting with the
	/// TF_DISCONNECT and TF_REUSE_SOCKET flags.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the <c>TransmitFile</c> function succeeds, the return value is <c>TRUE</c>. Otherwise, the return value is <c>FALSE</c>. To get
	/// extended error information, call WSAGetLastError. An error code of WSA_IO_PENDING or ERROR_IO_PENDING indicates that the overlapped
	/// operation has been successfully initiated and that completion will be indicated at a later time. Any other error code indicates that
	/// the overlapped operation was not successfully initiated and no completion indication will occur. Applications should handle either
	/// ERROR_IO_PENDING or WSA_IO_PENDING in this case.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAECONNABORTED</c></term>
	/// <term>
	/// An established connection was aborted by the software in your host machine. This error is returned if the virtual circuit was
	/// terminated due to a time-out or other failure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAECONNRESET</c></term>
	/// <term>
	/// An existing connection was forcibly closed by the remote host. This error is returned for a stream socket when the virtual circuit
	/// was reset by the remote side. The application should close the socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a pointer argument in a call. This error is returned if the
	/// <c>lpTransmitBuffers</c> or <c>lpOverlapped</c> parameter is not totally contained in a valid part of the user address space.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid argument was supplied. This error is returned if the <c>hSocket</c> parameter specified a socket of type <c>SOCK_DGRAM</c>
	/// or <c>SOCK_RAW</c>. This error is returned if the <c>dwFlags</c> parameter has the <c>TF_REUSE_SOCKET</c> flag set, but the
	/// <c>TF_DISCONNECT</c> flag was not set. This error is also returned if the offset specified in the OVERLAPPED structure pointed to by
	/// the <c>lpOverlapped</c> is not within the file. This error is also returned if the <c>nNumberOfBytesToWrite</c> parameter is set to a
	/// value greater than 2,147,483,646, the maximum value for a 32-bit integer minus 1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETDOWN</c></term>
	/// <term>A socket operation encountered a dead network.This error is returned if the network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETRESET</c></term>
	/// <term>The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOBUFS</c></term>
	/// <term>
	/// An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full. This
	/// error is also returned if the Windows Sockets provider reports a buffer deadlock.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTCONN</c></term>
	/// <term>A request to send or receive data was disallowed because the socket is not connected.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>
	/// An operation was attempted on something that is not a socket. This error is returned if the <c>hSocket</c> parameter is not a socket.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAESHUTDOWN</c></term>
	/// <term>
	/// A request to send or receive data was disallowed because the socket had already been shut down in that direction with a previous
	/// shutdown call. This error is returned if the socket has been shut down for sending. It is not possible to call TransmitFile on a
	/// socket after the shutdown function has been called on the socket with the <c>how</c> parameter set to <c>SD_SEND</c> or <c>SD_BOTH</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSANOTINITIALISED</c></term>
	/// <term>
	/// Either the application has not called the WSAStartup function, or <c>WSAStartup</c> failed. A successful <c>WSAStartup</c> call must
	/// occur before using the TransmitFile function.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_IO_PENDING</c></term>
	/// <term>
	/// An overlapped I/O operation is in progress. This value is returned if an overlapped I/O operation was successfully initiated and
	/// indicates that completion will be indicated at a later time.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSA_OPERATION_ABORTED</c></term>
	/// <term>
	/// The I/O operation has been aborted because of either a thread exit or an application request. This error is returned if the
	/// overlapped operation has been canceled due to the closure of the socket, the execution of the "SIO_FLUSH" command in WSAIoctl, or the
	/// thread that initiated the overlapped request exited before the operation completed.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>TransmitFile</c> function uses the operating system's cache manager to retrieve the file data, and provide high-performance
	/// file data transfer over sockets.
	/// </para>
	/// <para>
	/// The <c>TransmitFile</c> function only supports connection-oriented sockets of type <c>SOCK_STREAM</c>, <c>SOCK_SEQPACKET</c>, and
	/// <c>SOCK_RDM</c>. Sockets of type <c>SOCK_DGRAM</c> and <c>SOCK_RAW</c> are not supported. The TransmitPackets function can be used
	/// with sockets of type <c>SOCK_DGRAM</c>.
	/// </para>
	/// <para>
	/// The maximum number of bytes that can be transmitted using a single call to the <c>TransmitFile</c> function is 2,147,483,646, the
	/// maximum value for a 32-bit integer minus 1. The maximum number of bytes to send in a single call includes any data sent before or
	/// after the file data pointed to by the <c>lpTransmitBuffers</c> parameter plus the value specified in the <c>nNumberOfBytesToWrite</c>
	/// parameter for the length of file data to send. If an application needs to transmit a file larger than 2,147,483,646 bytes, then
	/// multiple calls to the <c>TransmitFile</c> function can be used with each call transferring no more than 2,147,483,646 bytes. Setting
	/// the <c>nNumberOfBytesToWrite</c> parameter to zero for a file larger than 2,147,483,646 bytes will also fail since in this case the
	/// <c>TransmitFile</c> function will use the size of the file as the value for the number of bytes to transmit.
	/// </para>
	/// <para>
	/// <c>Note</c> The function pointer for the <c>TransmitFile</c> function must be obtained at run time by making a call to the WSAIoctl
	/// function with the <c>SIO_GET_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the <c>WSAIoctl</c> function
	/// must contain <c>WSAID_TRANSMITFILE</c>, a globally unique identifier (GUID) whose value identifies the <c>TransmitFile</c> extension
	/// function. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the <c>TransmitFile</c> function. The
	/// <c>WSAID_TRANSMITFILE</c> GUID is defined in the <c>Mswsock.h</c> header file.
	/// </para>
	/// <para>
	/// <c>Note</c><c>TransmitFile</c> is not functional on transports that perform their own buffering. Transports with the
	/// TDI_SERVICE_INTERNAL_BUFFERING flag set, such as ADSP, perform their own buffering. Because <c>TransmitFile</c> achieves its
	/// performance gains by sending data directly from the file cache. Transports that run out of buffer space on a particular connection
	/// are not handled by <c>TransmitFile</c>, and as a result of running out of buffer space on the connection, <c>TransmitFile</c> returns STATUS_DEVICE_NOT_READY.
	/// </para>
	/// <para>
	/// The <c>TransmitFile</c> function was primarily added to Winsock for use by high-performance server applications (web and ftp servers,
	/// for example).
	/// </para>
	/// <para>
	/// Workstation and client versions of Windows optimize the <c>TransmitFile</c> function for minimum memory and resource utilization by
	/// limiting the number of concurrent <c>TransmitFile</c> operations allowed on the system to a maximum of two. On Windows Vista, Windows
	/// XP, Windows 2000 Professional, and Windows NT Workstation 3.51 and later only two outstanding <c>TransmitFile</c> requests are
	/// handled simultaneously; the third request will wait until one of the previous requests is completed.
	/// </para>
	/// <para>
	/// Server versions of Windows optimize the <c>TransmitFile</c> function for high performance. On server versions, there are no default
	/// limits placed on the number of concurrent <c>TransmitFile</c> operations allowed on the system. Expect better performance results
	/// when using <c>TransmitFile</c> on server versions of Windows. On server versions of Windows, it is possible to set a limit on the
	/// maximum number of concurrent <c>TransmitFile</c> operations by creating a registry entry and setting a value for the following <c>REG_DWORD</c>:
	/// </para>
	/// <para><c>HKEY_LOCAL_MACHINE</c>\ <c>CurrentControlSet</c>\ <c>Services</c>\ <c>AFD</c>\ <c>Parameters</c>\ <c>MaxActiveTransmitFileCount</c></para>
	/// <para>
	/// If the <c>TransmitFile</c> function is called with TCP socket (protocol of IPPROTO_TCP) with both the <c>TF_DISCONNECT</c> and
	/// <c>TF_REUSE_SOCKET</c> flags specified, the call will not complete until the two following conditions are met.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>All pending receive data sent by remote side (received prior to a FIN from the remote side) on the TCP socket has been read.</term>
	/// </item>
	/// <item>
	/// <term>The remote side has closed the connection (completed the graceful TCP connection closure).</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the <c>TransmitFile</c> function is called with the <c>lpOverlapped</c> parameter set to <c>NULL</c>, the operation is executed as
	/// synchronous I/O. The function will not complete until the file has been sent.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// <para>Notes for QoS</para>
	/// <para>
	/// The <c>TransmitFile</c> function allows the setting of two flags, TF_DISCONNECT or TF_REUSE_SOCKET, that return the socket to a
	/// "disconnected, reusable" state after the file has been transmitted. These flags should not be used on a socket where quality of
	/// service has been requested, since the service provider may immediately delete any quality of service associated with the socket
	/// before the file transfer has completed. The best approach for a QoS-enabled socket is to simply call the closesocket function when
	/// the file transfer has completed, rather than relying on these flags.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nf-mswsock-transmitfile BOOL TransmitFile( SOCKET hSocket, HANDLE hFile,
	// DWORD nNumberOfBytesToWrite, DWORD nNumberOfBytesPerSend, LPOVERLAPPED lpOverlapped, LPTRANSMIT_FILE_BUFFERS lpTransmitBuffers, DWORD
	// dwReserved );
	[PInvokeData("mswsock.h", MSDNShortId = "NF:mswsock.TransmitFile")]
	[DllImport(Lib_Mswsock, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TransmitFile(SOCKET hSocket, [Optional] HFILE hFile, uint nNumberOfBytesToWrite,
		uint nNumberOfBytesPerSend, [In, Optional] IntPtr lpOverlapped, [In, Optional] IntPtr lpTransmitBuffers,
		uint dwReserved = 0);

	/// <summary>
	/// <para>
	/// The <c>WSARecvEx</c> function receives data from a connected socket or a bound connectionless socket. The <c>WSARecvEx</c> function
	/// is similar to the recv function, except that the <c>flags</c> parameter is used only to return information. When a partial message is
	/// received while using datagram protocol, the MSG_PARTIAL bit is set in the <c>flags</c> parameter on return from the function.
	/// </para>
	/// <para><c>Note</c> The <c>WSARecvEx</c> function is a Microsoft-specific extension to the Windows Sockets specification.</para>
	/// </summary>
	/// <param name="s">A descriptor that identifies a connected socket.</param>
	/// <param name="buf">A pointer to the buffer to receive the incoming data.</param>
	/// <param name="len">The length, in bytes, of the buffer pointed to by the <c>buf</c> parameter.</param>
	/// <param name="flags">An indicator specifying whether the message is fully or partially received for datagram sockets.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>WSARecvEx</c> returns the number of bytes received. If the connection has been closed, it returns zero.
	/// Additionally, if a partial message was received, the MSG_PARTIAL bit is set in the <c>flags</c> parameter. If a complete message was
	/// received, MSG_PARTIAL is not set in <c>flags</c>
	/// </para>
	/// <para>Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</para>
	/// <para>
	/// <c>Important</c> For a stream oriented-transport protocol, MSG_PARTIAL is never set on return from <c>WSARecvEx</c>. This function
	/// behaves identically to the recv function for stream-transport protocols.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAECONNABORTED</c></term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAECONNRESET</c></term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket as it is
	/// no longer usable. On a UPD-datagram socket this error would indicate that a previous send operation resulted in an ICMP "Port
	/// Unreachable" message.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>The <c>buf</c> parameter is not completely contained in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINPROGRESS</c></term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINTR</c></term>
	/// <term>The (blocking) call was canceled by the WSACancelBlockingCall call.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with SO_OOBINLINE
	/// enabled or (for byte stream sockets only) <c>len</c> was zero or negative.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETDOWN</c></term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENETRESET</c></term>
	/// <term>
	/// For a connection-oriented socket, this error indicates that the connection has been broken due to <c>keep-alive</c> activity that
	/// detected a failure while the operation was in progress. For a datagram socket, this error indicates that the time to live has expired.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTCONN</c></term>
	/// <term>The socket is not connected.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor is not a socket.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEOPNOTSUPP</c></term>
	/// <term>
	/// MSG_OOB was specified, but the socket is not stream-style such as type SOCK_STREAM, OOB data is not supported in the communication
	/// domain associated with this socket, or the socket is unidirectional and supports only send operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAESHUTDOWN</c></term>
	/// <term>
	/// The socket has been shut down; it is not possible to use WSARecvEx on a socket after shutdown has been invoked with <c>how</c> set to
	/// SD_RECEIVE or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAETIMEDOUT</c></term>
	/// <term>The connection has been dropped because of a network failure or because the peer system failed to respond.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEWOULDBLOCK</c></term>
	/// <term>The socket is marked as nonblocking and the receive operation would block.</term>
	/// </item>
	/// <item>
	/// <term><c>WSANOTINITIALISED</c></term>
	/// <term>A successful WSAStartup call must occur before using this function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSARecvEx</c> function that is part of the Microsoft implementation of Windows Sockets 2 is similar to the more common recv
	/// function except that the <c>flags</c> parameter is used for a single specific purpose. The <c>flags</c> parameter is used to indicate
	/// whether a partial or complete message is received when a message-oriented protocol is being used.
	/// </para>
	/// <para>
	/// The value pointed to by the <c>flags</c> parameter is ignored on input. So no flags can be passed to the <c>WSARecvEx</c> function to
	/// modify its behavior. The value pointed to by the <c>flags</c> parameter is set on output. This differs from the recv and WSARecv
	/// functions where the value pointed to by the <c>flags</c> parameter on input can modify the behavior of the function.
	/// </para>
	/// <para>The <c>WSARecvEx</c> and recv functions behave identically for stream-oriented protocols.</para>
	/// <para>The <c>flags</c> parameter accommodates two common situations in which a partial message will be received:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>When the application's data buffer size is smaller than the message size and the message coincidentally arrives in two pieces.</term>
	/// </item>
	/// <item>
	/// <term>When the message is rather large and must arrive in several pieces.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The MSG_PARTIAL bit is set in the value pointed to by the <c>flags</c> parameter on return from <c>WSARecvEx</c> when a partial
	/// message was received. If a complete message was received, MSG_PARTIAL is not set in the value pointed to by the <c>flags</c> parameter.
	/// </para>
	/// <para>
	/// The recv function is different from the <c>WSARecvEx</c> and WSARecv functions in that the <c>recv</c> function always receives a
	/// single message for each call for message-oriented transport protocols. The <c>recv</c> function also does not have a means to
	/// indicate to the application that the data received is only a partial message. An application must build its own protocol for checking
	/// whether a message is partial or complete by checking for the error code WSAEMSGSIZE after each call to <c>recv</c>. When the
	/// application buffer is smaller than the data being sent, as much of the message as will fit is copied into the user's buffer and
	/// <c>recv</c> returns with the error code WSAEMSGSIZE. A subsequent call to <c>recv</c> will get the next part of the message.
	/// </para>
	/// <para>
	/// Applications written for message-oriented transport protocols should be coded for this possibility if message sizing is not
	/// guaranteed by the application's data transfer protocol. An application can use recv and manage the protocol itself. Alternatively, an
	/// application can use <c>WSARecvEx</c> and check that the MSG_PARTIAL bit is set in the <c>flags</c> parameter.
	/// </para>
	/// <para>
	/// The <c>WSARecvEx</c> function provides the developer with a more effective way of checking whether a message received is partial or
	/// complete when a very large message arrives incrementally. For example, if an application sends a one-megabyte message, the transport
	/// protocol must break up the message in order to send it over the physical network. It is theoretically possible for the transport
	/// protocol on the receiving side to buffer all the data in the message, but this would be quite expensive in terms of resources.
	/// Instead, <c>WSARecvEx</c> can be used, minimizing overhead and eliminating the need for an application-based protocol.
	/// </para>
	/// <para>
	/// <c>Note</c> All I/O initiated by a given thread is canceled when that thread exits. For overlapped sockets, pending asynchronous
	/// operations can fail if the thread is closed before the operations complete. See the ExitThread function for more information.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/nf-mswsock-wsarecvex int WSARecvEx( [in] SOCKET s, [out] char *buf, [in]
	// int len, [in, out] int *flags );
	[PInvokeData("mswsock.h", MSDNShortId = "NF:mswsock.WSARecvEx")]
	[DllImport(Lib_Mswsock, SetLastError = true, ExactSpelling = true)]
	public static extern int WSARecvEx([In] SOCKET s, [Out] IntPtr buf, int len, ref int flags);

	/// <summary>
	/// The <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure contains information on the functions that implement the Winsock registered I/O extensions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure contains information on the functions that implement the Winsock registered I/O extensions.
	/// </para>
	/// <para>
	/// The function pointers for the Winsock registered I/O extension functions must be obtained at run time by making a call to the
	/// WSAIoctl function with the <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> opcode specified. The input buffer passed to the
	/// <c>WSAIoctl</c> function must contain <c>WSAID_MULTIPLE_RIO</c>, a globally unique identifier (GUID) whose value identifies the
	/// Winsock registered I/O extension functions. On success, the output returned by the <c>WSAIoctl</c> function contains a pointer to the
	/// <c>RIO_EXTENSION_FUNCTION_TABLE</c> structure that contains pointers to the Winsock registered I/O extension functions. The
	/// <c>SIO_GET_MULTIPLE_EXTENSION_FUNCTION_POINTER</c> IOCTL is defined in the <c>Ws2def.h</c> header file.The <c>WSAID_MULTIPLE_RIO</c>
	/// GUID is defined in the <c>Mswsock.h</c> header file.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/ns-mswsock-rio_extension_function_table typedef struct
	// _RIO_EXTENSION_FUNCTION_TABLE { DWORD cbSize; LPFN_RIORECEIVE RIOReceive; LPFN_RIORECEIVEEX RIOReceiveEx; LPFN_RIOSEND RIOSend;
	// LPFN_RIOSENDEX RIOSendEx; LPFN_RIOCLOSECOMPLETIONQUEUE RIOCloseCompletionQueue; LPFN_RIOCREATECOMPLETIONQUEUE
	// RIOCreateCompletionQueue; LPFN_RIOCREATEREQUESTQUEUE RIOCreateRequestQueue; LPFN_RIODEQUEUECOMPLETION RIODequeueCompletion;
	// LPFN_RIODEREGISTERBUFFER RIODeregisterBuffer; LPFN_RIONOTIFY RIONotify; LPFN_RIOREGISTERBUFFER RIORegisterBuffer;
	// LPFN_RIORESIZECOMPLETIONQUEUE RIOResizeCompletionQueue; LPFN_RIORESIZEREQUESTQUEUE RIOResizeRequestQueue; }
	// RIO_EXTENSION_FUNCTION_TABLE, *PRIO_EXTENSION_FUNCTION_TABLE;
	[PInvokeData("mswsock.h", MSDNShortId = "NS:mswsock._RIO_EXTENSION_FUNCTION_TABLE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RIO_EXTENSION_FUNCTION_TABLE
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint cbSize;

		/// <summary>A pointer to the RIOReceive function.</summary>
		public LPFN_RIORECEIVE RIOReceive;

		/// <summary>A pointer to the RIOReceiveEx function.</summary>
		public LPFN_RIORECEIVEEX RIOReceiveEx;

		/// <summary>A pointer to the RIOSend function.</summary>
		public LPFN_RIOSEND RIOSend;

		/// <summary>A pointer to the RIOSendEx function.</summary>
		public LPFN_RIOSENDEX RIOSendEx;

		/// <summary>A pointer to the RIOCloseCompletionQueue function.</summary>
		public LPFN_RIOCLOSECOMPLETIONQUEUE RIOCloseCompletionQueue;

		/// <summary>A pointer to the RIOCreateCompletionQueue function.</summary>
		public LPFN_RIOCREATECOMPLETIONQUEUE RIOCreateCompletionQueue;

		/// <summary>A pointer to the RIOCreateRequestQueue function.</summary>
		public LPFN_RIOCREATEREQUESTQUEUE RIOCreateRequestQueue;

		/// <summary>A pointer to the RIODequeueCompletion function.</summary>
		public LPFN_RIODEQUEUECOMPLETION RIODequeueCompletion;

		/// <summary>A pointer to the RIODeregisterBuffer function.</summary>
		public LPFN_RIODEREGISTERBUFFER RIODeregisterBuffer;

		/// <summary>A pointer to the RIONotify function.</summary>
		public LPFN_RIONOTIFY RIONotify;

		/// <summary>A pointer to the RIORegisterBuffer function.</summary>
		public LPFN_RIOREGISTERBUFFER RIORegisterBuffer;

		/// <summary>A pointer to the RIOResizeCompletionQueue function.</summary>
		public LPFN_RIORESIZECOMPLETIONQUEUE RIOResizeCompletionQueue;

		/// <summary>A pointer to the RIOResizeRequestQueue function.</summary>
		public LPFN_RIORESIZEREQUESTQUEUE RIOResizeRequestQueue;
	}

	/// <summary>
	/// The <c>RIO_NOTIFICATION_COMPLETION</c> structure specifies the method for I/O completion to be used with a RIONotify function for
	/// sending or receiving network data with the Winsock registered I/O extensions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>RIO_NOTIFICATION_COMPLETION</c> structure is used to specify the behavior of the RIONotify function used with the Winsock
	/// registered I/O extensions.
	/// </para>
	/// <para>
	/// The <c>RIO_NOTIFICATION_COMPLETION</c> structure is passed to the RIOCreateCompletionQueue function when a RIO_CQ is created. If an
	/// application does not call the RIONotify function for a completion queue, the completion queue can be created without a
	/// <c>RIO_NOTIFICATION_COMPLETION</c> object.
	/// </para>
	/// <para>
	/// For completion queues using an event, the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure is set to
	/// <c>RIO_EVENT_COMPLETION</c>. The <c>Event.EventHandle</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure should contain
	/// the handle for an event created by the WSACreateEvent or CreateEvent function. To receive the RIONotify completion, the application
	/// should wait on the specified event handle using WSAWaitForMultipleEvents or a similar wait routine. If the application plans to reset
	/// and reuse the event, the application can reduce overhead by setting the <c>Event.NotifyReset</c> member of the
	/// <c>RIO_NOTIFICATION_COMPLETION</c> structure to a non-zero value. This causes the event to be reset by the <c>RIONotify</c> function
	/// when notification occurs. This mitigates the need to call the WSAResetEvent function to reset the event between calls to the
	/// <c>RIONotify</c> function.
	/// </para>
	/// <para>
	/// For completion queues using an I/O completion port, the <c>Type</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure is set
	/// to <c>RIO_IOCP_COMPLETION</c>. The <c>Iocp.IocpHandle</c> member of the <c>RIO_NOTIFICATION_COMPLETION</c> structure should contain
	/// the handle for an I/O completion port created by the CreateIoCompletionPort function. To receive the RIONotify completion, the
	/// application should call the GetQueuedCompletionStatus or GetQueuedCompletionStatusEx function. The application should provide a
	/// dedicated OVERLAPPED object for the completion queue, and it may also use the <c>Iocp.CompletionKey</c> member to distinguish
	/// <c>RIONotify</c> requests on the completion queue from other I/O completions including <c>RIONotify</c> completions for other
	/// completion queues.
	/// </para>
	/// <para>
	/// An application using thread pools can use thread pool wait objects to get RIONotify completions via its thread pool. In that case,
	/// the call to the SetThreadpoolWait function should immediately follow the call to <c>RIONotify</c>. If the <c>SetThreadpoolWait</c>
	/// function is called before <c>RIONotify</c> and the application relies on <c>RIONotify</c> to clear the event object, this may result
	/// in spurious executions of the wait object callback.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/ns-mswsock-rio_notification_completion typedef struct
	// _RIO_NOTIFICATION_COMPLETION { RIO_NOTIFICATION_COMPLETION_TYPE Type; union { struct { HANDLE EventHandle; BOOL NotifyReset; } Event;
	// struct { HANDLE IocpHandle; PVOID CompletionKey; PVOID Overlapped; } Iocp; }; } RIO_NOTIFICATION_COMPLETION, *PRIO_NOTIFICATION_COMPLETION;
	[PInvokeData("mswsock.h", MSDNShortId = "NS:mswsock._RIO_NOTIFICATION_COMPLETION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RIO_NOTIFICATION_COMPLETION
	{
		/// <summary>The type of completion to use with the RIONotify function when sending or receiving data.</summary>
		public RIO_NOTIFICATION_COMPLETION_TYPE Type;

		/// <summary/>
		public UNION union;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary/>
			[FieldOffset(0)]
			public EVENT Event;

			/// <summary/>
			[FieldOffset(0)]
			public IOCP Iocp;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct EVENT
			{
				/// <summary>
				/// <para>The handle for the event to set following a completed RIONotify request.</para>
				/// <para>This value is valid when the <c>Type</c> member is set to <c>RIO_EVENT_COMPLETION</c>.</para>
				/// </summary>
				public HANDLE EventHandle;

				/// <summary>
				/// <para>
				/// The boolean value that causes the associated event to be reset when the RIONotify function is called. A non-zero value
				/// cause the associated event to be reset.
				/// </para>
				/// <para>This value is valid when the <c>Type</c> member is set to <c>RIO_EVENT_COMPLETION</c>.</para>
				/// </summary>
				public BOOL NotifyReset;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct IOCP
			{
				/// <summary>
				/// <para>The handle for the I/O completion port to use for queuing a RIONotify request completion.</para>
				/// <para>This value is valid when the <c>Type</c> member is set to <c>RIO_IOCP_COMPLETION</c>.</para>
				/// </summary>
				public HANDLE IocpHandle;

				/// <summary>
				/// <para>
				/// The value to use for <c>lpCompletionKey</c> parameter returned by the GetQueuedCompletionStatus or
				/// GetQueuedCompletionStatusEx function when queuing a RIONotify request.
				/// </para>
				/// <para>This value is valid when the <c>Type</c> member is set to <c>RIO_IOCP_COMPLETION</c>.</para>
				/// </summary>
				public IntPtr CompletionKey;

				/// <summary>
				/// <para>
				/// A pointer to the OVERLAPPED structure to use when queuing a RIONotify request completion. This member must point to a
				/// valid <c>OVERLAPPED</c> structure.
				/// </para>
				/// <para>This value is valid when the <c>Type</c> member is set to <c>RIO_IOCP_COMPLETION</c>.</para>
				/// </summary>
				public IntPtr Overlapped;
			}
		}
	}

	/// <summary>
	/// The <c>TRANSMIT_FILE_BUFFERS</c> structure specifies data to be transmitted before and after file data during a TransmitFile function
	/// file transfer operation.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/ns-mswsock-transmit_file_buffers typedef struct _TRANSMIT_FILE_BUFFERS {
	// LPVOID Head; DWORD HeadLength; LPVOID Tail; DWORD TailLength; } TRANSMIT_FILE_BUFFERS, *PTRANSMIT_FILE_BUFFERS, *LPTRANSMIT_FILE_BUFFERS;
	[PInvokeData("mswsock.h", MSDNShortId = "NS:mswsock._TRANSMIT_FILE_BUFFERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRANSMIT_FILE_BUFFERS
	{
		/// <summary>Pointer to a buffer that contains data to be transmitted before the file data is transmitted.</summary>
		public IntPtr Head;

		/// <summary>Size of the buffer pointed to by <c>Head</c>, in bytes, to be transmitted.</summary>
		public uint HeadLength;

		/// <summary>Pointer to a buffer that contains data to be transmitted after the file data is transmitted.</summary>
		public IntPtr Tail;

		/// <summary>Size of the buffer pointed to <c>Tail</c>, in bytes, to be transmitted.</summary>
		public uint TailLength;
	}

	/// <summary>
	/// The <c>TRANSMIT_PACKETS_ELEMENT</c> structure specifies a single data element to be transmitted by the TransmitPackets function.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/mswsock/ns-mswsock-transmit_packets_element typedef struct
	// _TRANSMIT_PACKETS_ELEMENT { ULONG dwElFlags; ULONG cLength; union { struct { LARGE_INTEGER nFileOffset; HANDLE hFile; }; PVOID
	// pBuffer; }; } TRANSMIT_PACKETS_ELEMENT, *PTRANSMIT_PACKETS_ELEMENT, *LPTRANSMIT_PACKETS_ELEMENT;
	[PInvokeData("mswsock.h", MSDNShortId = "NS:mswsock._TRANSMIT_PACKETS_ELEMENT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRANSMIT_PACKETS_ELEMENT
	{
		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>
		/// Flags used to describe the contents of the packet array element, and to customize <c>TransmitPackets</c> function processing. The
		/// following table lists valid flags:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TP_ELEMENT_FILE</c></term>
		/// <term>Specifies that data resides in a file. Default setting for <c>dwElFlags</c>. Mutually exclusive with TP_ELEMENT_MEMORY.</term>
		/// </item>
		/// <item>
		/// <term><c>TP_ELEMENT_MEMORY</c></term>
		/// <term>Specifies that data resides in memory. Mutually exclusive with TP_ELEMENT_FILE.</term>
		/// </item>
		/// <item>
		/// <term><c>TP_ELEMENT_EOP</c></term>
		/// <term>
		/// Specifies that this element should not be combined with the next element in a single send request from the sockets layer to the
		/// transport. This flag is used for granular control of the content of each message on a datagram or message-oriented socket.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public TP_ELEMENT dwElFlags;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The number of bytes to transmit. If zero, the entire file is transmitted.</para>
		/// </summary>
		public uint cLength;

		/// <summary>
		/// <para>Type: <c>LARGE_INTEGER</c></para>
		/// <para>
		/// The file offset, in bytes, at which to begin the transfer. Valid only if TP_ELEMENT_FILE is specified in <c>dwEIFlags</c>. When
		/// set to –1, transmission begins at the current byte offset.
		/// </para>
		/// </summary>
		public long nFileOffset;

		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>
		/// A handle to an open file to be transmitted. Valid only if TP_ELEMENT_FILE is specified in <c>dwEIFlags</c>. Windows reads the
		/// file sequentially; caching performance is improved by opening this handle with FILE_FLAG_SEQUENTIAL_SCAN.
		/// </para>
		/// </summary>
		public HFILE hFile;

		/// <summary>
		/// <para>Type: <c>PVOID</c></para>
		/// <para>A pointer to the data in memory to be sent. Valid only if TP_ELEMENT_MEMORY is specified in <c>dwEIFlags</c>.</para>
		/// </summary>
		public IntPtr pBuffer;
	}
}