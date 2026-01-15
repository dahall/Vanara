#pragma warning disable IDE1006 // Naming Styles

using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from ws2_32.h.</summary>
public static partial class Ws2_32
{
	/// <summary>A flag that describes what types of operation will no longer be allowed.</summary>
	[PInvokeData("winsock.h", MSDNShortId = "6998f0c6-adc9-481f-b9fb-75f9c9f5caaf")]
	public enum SD
	{
		/// <summary>Shutdown receive operations.</summary>
		SD_RECEIVE = 0,

		/// <summary>Shutdown send operations.</summary>
		SD_SEND = 1,

		/// <summary>Shutdown both send and receive operations.</summary>
		SD_BOTH = 2,
	}

	/// <summary>The <c>accept</c> function permits an incoming connection attempt on a socket.</summary>
	/// <param name="s">
	/// A descriptor that identifies a socket that has been placed in a listening state with the listen function. The connection is
	/// actually made with the socket that is returned by <c>accept</c>.
	/// </param>
	/// <param name="addr">
	/// An optional pointer to a buffer that receives the address of the connecting entity, as known to the communications layer. The
	/// exact format of the addr parameter is determined by the address family that was established when the socket from the sockaddr
	/// structure was created.
	/// </param>
	/// <param name="addrlen">An optional pointer to an integer that contains the length of structure pointed to by the addr parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>accept</c> returns a value of type <c>SOCKET</c> that is a descriptor for the new socket. This returned
	/// value is a handle for the socket on which the actual connection is made.
	/// </para>
	/// <para>Otherwise, a value of <c>INVALID_SOCKET</c> is returned, and a specific error code can be retrieved by calling WSAGetLastError.</para>
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
	/// <term>WSANOTINITIALISED</term>
	/// <term>A successful WSAStartup call must occur before using this function.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>An incoming connection was indicated, but was subsequently terminated by the remote peer prior to accepting the call.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The addrlen parameter is too small or addr is not a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Sockets 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The listen function was not invoked prior to accept.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMFILE</term>
	/// <term>The queue is nonempty upon entry to accept and there are no descriptors available.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
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
	/// <term>The referenced socket is not a type that supports connection-oriented service.</term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and no connections are present to be accepted.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>accept</c> function extracts the first connection on the queue of pending connections on socket s. It then creates and
	/// returns a handle to the new socket. The newly created socket is the socket that will handle the actual connection; it has the
	/// same properties as socket s, including the asynchronous events registered with the WSAAsyncSelect or WSAEventSelect functions.
	/// </para>
	/// <para>
	/// The <c>accept</c> function can block the caller until a connection is present if no pending connections are present on the
	/// queue, and the socket is marked as blocking. If the socket is marked as nonblocking and no pending connections are present on
	/// the queue, <c>accept</c> returns an error as described in the following. After the successful completion of <c>accept</c>
	/// returns a new socket handle, the accepted socket cannot be used to accept more connections. The original socket remains open and
	/// listens for new connection requests.
	/// </para>
	/// <para>
	/// The parameter addr is a result parameter that is filled in with the address of the connecting entity, as known to the
	/// communications layer. The exact format of the addr parameter is determined by the address family in which the communication is
	/// occurring. The addrlen is a value-result parameter; it should initially contain the amount of space pointed to by addr; on
	/// return it will contain the actual length (in bytes) of the address returned.
	/// </para>
	/// <para>
	/// The <c>accept</c> function is used with connection-oriented socket types such as SOCK_STREAM. If addr and/or addrlen are equal
	/// to <c>NULL</c>, then no information about the remote address of the accepted socket is returned.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>accept</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>accept</c> function.</para>
	/// <para>For another example that uses the <c>accept</c> function, see Getting Started With Winsock.</para>
	/// <para>Notes for ATM</para>
	/// <para>
	/// The following are important issues associated with connection setup, and must be considered when using Asynchronous Transfer
	/// Mode (ATM) with Windows Sockets 2:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The <c>accept</c> and WSAAccept functions do not necessarily set the remote address and address length parameters. Therefore,
	/// when using ATM, the caller should use the <c>WSAAccept</c> function and place ATM_CALLING_PARTY_NUMBER_IE in the
	/// <c>ProviderSpecific</c> member of the QoS structure, which itself is included in the lpSQOS parameter of the callback function
	/// used in accordance with <c>WSAAccept</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When using the <c>accept</c> function, realize that the function may return before connection establishment has traversed the
	/// entire distance between sender and receiver. This is because the <c>accept</c> function returns as soon as it receives a CONNECT
	/// ACK message; in ATM, a CONNECT ACK message is returned by the next switch in the path as soon as a CONNECT message is processed
	/// (rather than the CONNECT ACK being sent by the end node to which the connection is ultimately established). As such,
	/// applications should realize that if data is sent immediately following receipt of a CONNECT ACK message, data loss is possible,
	/// since the connection may not have been established all the way between sender and receiver.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-accept SOCKET WSAAPI accept( SOCKET s, sockaddr *addr,
	// int *addrlen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "72246263-4806-4ab2-9b26-89a1782a954b")]
	public static extern SafeSOCKET accept(SOCKET s, SOCKADDR addr, ref int addrlen);

	/// <summary>The <c>accept</c> function permits an incoming connection attempt on a socket.</summary>
	/// <param name="s">
	/// A descriptor that identifies a socket that has been placed in a listening state with the listen function. The connection is
	/// actually made with the socket that is returned by <c>accept</c>.
	/// </param>
	/// <param name="addr">
	/// An optional pointer to a buffer that receives the address of the connecting entity, as known to the communications layer. The
	/// exact format of the addr parameter is determined by the address family that was established when the socket from the sockaddr
	/// structure was created.
	/// </param>
	/// <param name="addrlen">An optional pointer to an integer that contains the length of structure pointed to by the addr parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>accept</c> returns a value of type <c>SOCKET</c> that is a descriptor for the new socket. This returned
	/// value is a handle for the socket on which the actual connection is made.
	/// </para>
	/// <para>Otherwise, a value of <c>INVALID_SOCKET</c> is returned, and a specific error code can be retrieved by calling WSAGetLastError.</para>
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
	/// <term>WSANOTINITIALISED</term>
	/// <term>A successful WSAStartup call must occur before using this function.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>An incoming connection was indicated, but was subsequently terminated by the remote peer prior to accepting the call.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The addrlen parameter is too small or addr is not a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Sockets 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The listen function was not invoked prior to accept.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMFILE</term>
	/// <term>The queue is nonempty upon entry to accept and there are no descriptors available.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
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
	/// <term>The referenced socket is not a type that supports connection-oriented service.</term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and no connections are present to be accepted.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>accept</c> function extracts the first connection on the queue of pending connections on socket s. It then creates and
	/// returns a handle to the new socket. The newly created socket is the socket that will handle the actual connection; it has the
	/// same properties as socket s, including the asynchronous events registered with the WSAAsyncSelect or WSAEventSelect functions.
	/// </para>
	/// <para>
	/// The <c>accept</c> function can block the caller until a connection is present if no pending connections are present on the
	/// queue, and the socket is marked as blocking. If the socket is marked as nonblocking and no pending connections are present on
	/// the queue, <c>accept</c> returns an error as described in the following. After the successful completion of <c>accept</c>
	/// returns a new socket handle, the accepted socket cannot be used to accept more connections. The original socket remains open and
	/// listens for new connection requests.
	/// </para>
	/// <para>
	/// The parameter addr is a result parameter that is filled in with the address of the connecting entity, as known to the
	/// communications layer. The exact format of the addr parameter is determined by the address family in which the communication is
	/// occurring. The addrlen is a value-result parameter; it should initially contain the amount of space pointed to by addr; on
	/// return it will contain the actual length (in bytes) of the address returned.
	/// </para>
	/// <para>
	/// The <c>accept</c> function is used with connection-oriented socket types such as SOCK_STREAM. If addr and/or addrlen are equal
	/// to <c>NULL</c>, then no information about the remote address of the accepted socket is returned.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>accept</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>accept</c> function.</para>
	/// <para>For another example that uses the <c>accept</c> function, see Getting Started With Winsock.</para>
	/// <para>Notes for ATM</para>
	/// <para>
	/// The following are important issues associated with connection setup, and must be considered when using Asynchronous Transfer
	/// Mode (ATM) with Windows Sockets 2:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The <c>accept</c> and WSAAccept functions do not necessarily set the remote address and address length parameters. Therefore,
	/// when using ATM, the caller should use the <c>WSAAccept</c> function and place ATM_CALLING_PARTY_NUMBER_IE in the
	/// <c>ProviderSpecific</c> member of the QoS structure, which itself is included in the lpSQOS parameter of the callback function
	/// used in accordance with <c>WSAAccept</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// When using the <c>accept</c> function, realize that the function may return before connection establishment has traversed the
	/// entire distance between sender and receiver. This is because the <c>accept</c> function returns as soon as it receives a CONNECT
	/// ACK message; in ATM, a CONNECT ACK message is returned by the next switch in the path as soon as a CONNECT message is processed
	/// (rather than the CONNECT ACK being sent by the end node to which the connection is ultimately established). As such,
	/// applications should realize that if data is sent immediately following receipt of a CONNECT ACK message, data loss is possible,
	/// since the connection may not have been established all the way between sender and receiver.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-accept SOCKET WSAAPI accept( SOCKET s, sockaddr *addr,
	// int *addrlen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "72246263-4806-4ab2-9b26-89a1782a954b")]
	public static extern SafeSOCKET accept(SOCKET s, [Optional] IntPtr addr, [Optional] IntPtr addrlen);

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
	/// An attempt was made to access a socket in a way forbidden by its access permissions. This error is returned if nn attempt to
	/// bind a datagram socket to the broadcast address failed because the setsockopt option SO_BROADCAST is not enabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEADDRINUSE</term>
	/// <term>
	/// Only one usage of each socket address (protocol/network address/port) is normally permitted. This error is returned if a process
	/// on the computer is already bound to the same fully qualified address and the socket has not been marked to allow address reuse
	/// with SO_REUSEADDR. For example, the IP address and port specified in the name parameter are already bound to another socket
	/// being used by another application. For more information, see the SO_REUSEADDR socket option in the SOL_SOCKET Socket Options
	/// reference, Using SO_REUSEADDR and SO_EXCLUSIVEADDRUSE, and SO_EXCLUSIVEADDRUSE.
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
	/// name parameter is NULL, the name or namelen parameter is not a valid part of the user address space, the namelen parameter is
	/// too small, the name parameter contains an incorrect address format for the associated address family, or the first two bytes of
	/// the memory block specified by name do not match the address family associated with the socket descriptor s.
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
	/// The <c>bind</c> function is required on an unconnected socket before subsequent calls to the listen function. It is normally
	/// used to bind to either connection-oriented (stream) or connectionless (datagram) sockets. The <c>bind</c> function may also be
	/// used to bind to a raw socket (the socket was created by calling the socketfunction with the type parameter set to SOCK_RAW). The
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
	/// for Windows Sockets 1.1 compatibility. Service providers are free to regard it as a pointer to a block of memory of size
	/// namelen. The first 2 bytes in this block (corresponding to the <c>sa_family</c> member of the <c>sockaddr</c> structure, the
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
	/// client port range. On Windows Vista and later, the dynamic client port range is a value between 49152 and 65535. This is a
	/// change from Windows Server 2003 and earlier where the dynamic client port range was a value between 1025 and 5000. The maximum
	/// value for the client dynamic port range can be changed by setting a value under the following registry key:
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
	/// socket. If the Internet address is equal to <c>INADDR_ANY</c> or <c>in6addr_any</c>, <c>getsockname</c> cannot necessarily
	/// supply the address until the socket is connected, since several addresses can be valid if the host is multihomed. Binding to a
	/// specific port number other than port 0 is discouraged for client applications, since there is a danger of conflicting with
	/// another socket already using that port number on the local computer.
	/// </para>
	/// <para>
	/// For multicast operations, the preferred method is to call the <c>bind</c> function to associate a socket with a local IP address
	/// and then join the multicast group. Although this order of operations is not mandatory, it is strongly recommended. So a
	/// multicast application would first select an IPv4 or IPv6 address on the local computer, the wildcard IPv4 address (
	/// <c>INADDR_ANY</c>), or the wildcard IPv6 address ( <c>in6addr_any</c>). The the multicast application would then call the
	/// <c>bind</c> function with this address in the in the <c>sa_data</c> member of the name parameter to associate the local IP
	/// address with the socket. If a wildcard address was specified, then Windows will select the local IP address to use. After the
	/// <c>bind</c> function completes, an application would then join the multicast group of interest. For more information on how to
	/// join a multicast group, see the section on Multicast Programming. This socket can then be used to receive multicast packets from
	/// the multicast group using the recv, recvfrom, WSARecv, WSARecvEx, WSARecvFrom, or WSARecvMsg functions.
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
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Notes for IrDA Sockets</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Local names are not exposed in IrDA. IrDA client sockets therefore, must never call the <c>bind</c> function before the connect
	/// function. If the IrDA socket was previously bound to a service name using <c>bind</c>, the <c>connect</c> function will fail
	/// with SOCKET_ERROR.
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
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-bind int bind( SOCKET s, const sockaddr *addr, int
	// namelen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "3a651daa-7404-4ef7-8cff-0d3dff41a8e8")]
	public static extern WSRESULT bind(SOCKET s, [In] SOCKADDR addr, int namelen);

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
	/// The <c>closesocket</c> function closes a socket. Use it to release the socket descriptor passed in the s parameter. Note that
	/// the socket descriptor passed in the s parameter may immediately be reused by the system as soon as <c>closesocket</c> function
	/// is issued. As a result, it is not reliable to expect further references to the socket descriptor passed in the s parameter to
	/// fail with the error WSAENOTSOCK. A Winsock client must never issue <c>closesocket</c> on s concurrently with another Winsock
	/// function call.
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
	/// function returns. Thus, an application should not cleanup any resources (WSAOVERLAPPED structures, for example) referenced by
	/// the outstanding I/O requests until the I/O requests are indeed completed.
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
	/// The <c>l_onoff</c> member of the <c>linger</c> structure determines whether a socket should remain open for a specified amount
	/// of time after a <c>closesocket</c> function call to enable queued data to be sent. This member can be modified in two ways:
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
	/// is called a graceful disconnect or close if all of the data is sent within timeout value specified in the <c>l_linger</c>
	/// member. If the timeout expires before all data has been sent, the Windows Sockets implementation terminates the connection
	/// before <c>closesocket</c> returns and this is called a hard or abortive close.
	/// </para>
	/// <para>
	/// Setting the <c>l_onoff</c> member of the linger structure to nonzero and the <c>l_linger</c> member with a nonzero timeout
	/// interval on a nonblocking socket is not recommended. In this case, the call to <c>closesocket</c> will fail with an error of
	/// WSAEWOULDBLOCK if the close operation cannot be completed immediately. If <c>closesocket</c> fails with WSAEWOULDBLOCK the
	/// socket handle is still valid, and a disconnect is not initiated. The application must call <c>closesocket</c> again to close the socket.
	/// </para>
	/// <para>
	/// If the <c>l_onoff</c> member of the linger structure is nonzero and the <c>l_linger</c> member is a nonzero timeout interval on
	/// a blocking socket, the result of the <c>closesocket</c> function can't be used to determine whether all data has been sent to
	/// the peer. If the data is sent before the timeout specified in the <c>l_linger</c> member expires or if the connection was
	/// aborted, the <c>closesocket</c> function won't return an error code (the return value from the <c>closesocket</c> function is zero).
	/// </para>
	/// <para>
	/// The <c>closesocket</c> call will only block until all data has been delivered to the peer or the timeout expires. If the
	/// connection is reset because the timeout expires, then the socket will not go into TIME_WAIT state. If all data is sent within
	/// the timeout period, then the socket can go into TIME_WAIT state.
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
	/// If the <c>l_onoff</c> member of the linger structure is set to nonzero and the <c>l_linger</c> member is set to zero (no
	/// timeout) <c>closesocket</c> returns immediately and the connection is reset or terminated.
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
	/// can send data and immediately call the socket function, and be confident that the receiver will copy the data before receiving
	/// an FD_CLOSE message.
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
	public static extern WSRESULT closesocket([In] SOCKET s);

	/// <summary>The <c>connect</c> function establishes a connection to a specified socket.</summary>
	/// <param name="s">A descriptor identifying an unconnected socket.</param>
	/// <param name="name">A pointer to the sockaddr structure to which the connection should be established.</param>
	/// <param name="namelen">The length, in bytes, of the sockaddr structure pointed to by the name parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>connect</c> returns zero. Otherwise, it returns SOCKET_ERROR, and a specific error code can be retrieved
	/// by calling WSAGetLastError.
	/// </para>
	/// <para>On a blocking socket, the return value indicates success or failure of the connection attempt.</para>
	/// <para>
	/// With a nonblocking socket, the connection attempt cannot be completed immediately. In this case, <c>connect</c> will return
	/// SOCKET_ERROR, and WSAGetLastError will return WSAEWOULDBLOCK. In this case, there are three possible scenarios:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Use the select function to determine the completion of the connection request by checking to see if the socket is writeable.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the application is using WSAAsyncSelect to indicate interest in connection events, then the application will receive an
	/// FD_CONNECT notification indicating that the <c>connect</c> operation is complete (successfully or not).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the application is using WSAEventSelect to indicate interest in connection events, then the associated event object will be
	/// signaled indicating that the <c>connect</c> operation is complete (successfully or not).
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Until the connection attempt completes on a nonblocking socket, all subsequent calls to <c>connect</c> on the same socket will
	/// fail with the error code WSAEALREADY, and WSAEISCONN when the connection completes successfully. Due to ambiguities in version
	/// 1.1 of the Windows Sockets specification, error codes returned from <c>connect</c> while a connection is already pending may
	/// vary among implementations. As a result, it is not recommended that applications use multiple calls to connect to detect
	/// connection completion. If they do, they must be prepared to handle WSAEINVAL and WSAEWOULDBLOCK error values the same way that
	/// they handle WSAEALREADY, to assure robust operation.
	/// </para>
	/// <para>
	/// If the error code returned indicates the connection attempt failed (that is, WSAECONNREFUSED, WSAENETUNREACH, WSAETIMEDOUT) the
	/// application can call <c>connect</c> again for the same socket.
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
	/// usually occurs when executing bind, but could be delayed until the connect function if the bind was to a wildcard address
	/// (INADDR_ANY or in6addr_any) for the local IP address. A specific address needs to be implicitly bound by the connect function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>The blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEALREADY</term>
	/// <term>A nonblocking connect call is in progress on the specified socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAEADDRNOTAVAIL</term>
	/// <term>The remote address is not a valid address (such as INADDR_ANY or in6addr_any) .</term>
	/// </item>
	/// <item>
	/// <term>WSAEAFNOSUPPORT</term>
	/// <term>Addresses in the specified family cannot be used with this socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNREFUSED</term>
	/// <term>The attempt to connect was forcefully rejected.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The sockaddr structure pointed to by the name contains incorrect address format for the associated address family or the namelen
	/// parameter is too small. This error is also returned if the sockaddr structure pointed to by the name parameter with a length
	/// specified in the namelen parameter is not in a valid part of the user address space.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The parameter s is a listening socket.</term>
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
	/// <term></term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor specified in the s parameter is not a socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>An attempt to connect timed out without establishing a connection.</term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the connection cannot be completed immediately.</term>
	/// </item>
	/// <item>
	/// <term>WSAEACCES</term>
	/// <term>An attempt to connect a datagram socket to broadcast address failed because setsockopt option SO_BROADCAST is not enabled.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>connect</c> function is used to create a connection to the specified destination. If socket s, is unbound, unique values
	/// are assigned to the local association by the system, and the socket is marked as bound.
	/// </para>
	/// <para>
	/// For connection-oriented sockets (for example, type SOCK_STREAM), an active connection is initiated to the foreign host using
	/// name (an address in the namespace of the socket; for a detailed description, see bind and sockaddr).
	/// </para>
	/// <para>
	/// When the socket call completes successfully, the socket is ready to send and receive data. If the address member of the
	/// structure specified by the name parameter is filled with zeros, <c>connect</c> will return the error WSAEADDRNOTAVAIL. Any
	/// attempt to reconnect an active connection will fail with the error code WSAEISCONN.
	/// </para>
	/// <para>
	/// For connection-oriented, nonblocking sockets, it is often not possible to complete the connection immediately. In such a case,
	/// this function returns the error WSAEWOULDBLOCK. However, the operation proceeds.
	/// </para>
	/// <para>
	/// When the success or failure outcome becomes known, it may be reported in one of two ways, depending on how the client registers
	/// for notification.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the client uses the select function, success is reported in the writefds set and failure is reported in the exceptfds set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the client uses the functions WSAAsyncSelect or WSAEventSelect, the notification is announced with FD_CONNECT and the error
	/// code associated with the FD_CONNECT indicates either success or a specific reason for failure.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// For a connectionless socket (for example, type SOCK_DGRAM), the operation performed by <c>connect</c> is merely to establish a
	/// default destination address that can be used on subsequent send/ WSASend and recv/ WSARecv calls. Any datagrams received from an
	/// address other than the destination address specified will be discarded. If the address member of the structure specified by name
	/// is filled with zeros, the socket will be disconnected. Then, the default remote address will be indeterminate, so send/ WSASend
	/// and recv/ WSARecv calls will return the error code WSAENOTCONN. However, sendto/ WSASendTo and recvfrom/ WSARecvFrom can still
	/// be used. The default destination can be changed by simply calling <c>connect</c> again, even if the socket is already connected.
	/// Any datagrams queued for receipt are discarded if name is different from the previous <c>connect</c>.
	/// </para>
	/// <para>
	/// For connectionless sockets, name can indicate any valid address, including a broadcast address. However, to connect to a
	/// broadcast address, a socket must use setsockopt to enable the SO_BROADCAST option. Otherwise, <c>connect</c> will fail with the
	/// error code WSAEACCES.
	/// </para>
	/// <para>
	/// When a connection between sockets is broken, the socket that was connected should be discarded and new socket should be created.
	/// When a problem develops on a connected socket, the application must discard the socket and create the socket again in order to
	/// return to a stable point.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>connect</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>connect</c> function.</para>
	/// <para>For another example that uses the <c>connect</c> function, see Getting Started With Winsock.</para>
	/// <para>Notes for IrDA Sockets</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// <item>
	/// <term>If an existing IrDA connection is detected at the media-access level, WSAENETDOWN is returned.</term>
	/// </item>
	/// <item>
	/// <term>If active connections to a device with a different address exist, WSAEADDRINUSE is returned.</term>
	/// </item>
	/// <item>
	/// <term>If the socket is already connected or an exclusive/multiplexed mode change failed, WSAEISCONN is returned.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the socket was previously bound to a local service name to accept incoming connections using bind, WSAEINVAL is returned.
	/// Note that once a socket is bound, it cannot be used for establishing an outbound connection.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// IrDA implements the connect function with addresses of the form sockaddr_irda. Typically, a client application will create a
	/// socket with the socket function, scan the immediate vicinity for IrDA devices with the IRLMP_ENUMDEVICES socket option, choose a
	/// device from the returned list, form an address, and then call <c>connect</c>. There is no difference between blocking and
	/// nonblocking semantics.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsock2/nf-winsock2-connect int WSAAPI connect( SOCKET s, const sockaddr
	// *name, int namelen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "13468139-dc03-45bd-850c-7ac2dbcb6e60")]
	public static extern WSRESULT connect(SOCKET s, SOCKADDR name, int namelen);

	/// <summary>The <c>gethostname</c> function retrieves the standard host name for the local computer.</summary>
	/// <param name="name">A pointer to a buffer that receives the local host name.</param>
	/// <param name="namelen">The length, in bytes, of the buffer pointed to by the name parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>gethostname</c> returns zero. Otherwise, it returns SOCKET_ERROR and a specific error code can be
	/// retrieved by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The name parameter is a NULL pointer or is not a valid part of the user address space. This error is also returned if the buffer
	/// size specified by namelen parameter is too small to hold the complete host name.
	/// </term>
	/// </item>
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
	/// The <c>gethostname</c> function returns the name of the local host into the buffer specified by the name parameter. The host
	/// name is returned as a <c>null</c>-terminated string. The form of the host name is dependent on the Windows Sockets provider—it
	/// can be a simple host name, or it can be a fully qualified domain name. However, it is guaranteed that the name returned will be
	/// successfully parsed by gethostbyname and WSAAsyncGetHostByName.
	/// </para>
	/// <para>The maximum length of the name returned in the buffer pointed to by the name parameter is dependent on the namespace provider.</para>
	/// <para>
	/// If the <c>gethostname</c> function is used on a cluster resource on Windows Server 2008, Windows Server 2003, or Windows 2000
	/// Server and the CLUSTER_NETWORK_NAME environment variable is defined, then the value in this environment variable overrides the
	/// actual hostname and is returned. On a cluster resource, the CLUSTER_NETWORK_NAME environment variable contains the name of the cluster.
	/// </para>
	/// <para>
	/// The <c>gethostname</c> function queries namespace providers to determine the local host name using the SVCID_HOSTNAME GUID
	/// defined in the Svgguid.h header file. If no namespace provider responds, then the <c>gethostname</c> function returns the
	/// NetBIOS name of the local computer.
	/// </para>
	/// <para>
	/// The maximum length, in bytes, of the string returned in the buffer pointed to by the name parameter is dependent on the
	/// namespace provider, but this string must be 256 bytes or less. So if a buffer of 256 bytes is passed in the name parameter and
	/// the namelen parameter is set to 256, the buffer size will always be adequate.
	/// </para>
	/// <para>
	/// <c>Note</c> If no local host name has been configured, <c>gethostname</c> must succeed and return a token host name that
	/// gethostbyname or WSAAsyncGetHostByName can resolve.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-gethostname int gethostname( char *name, int namelen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("winsock.h", MSDNShortId = "8fa40b60-0e93-493b-aee1-cea6cf595707")]
	public static extern WSRESULT gethostname(StringBuilder name, int namelen);

	/// <summary>The <c>GetHostNameW</c> function retrieves the standard host name for the local computer as a Unicode string.</summary>
	/// <param name="name">A pointer to a buffer that receives the local host name as a <c>null</c>-terminated Unicode string.</param>
	/// <param name="namelen">The length, in wide characters, of the buffer pointed to by the name parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>GetHostNameW</c> returns zero. Otherwise, it returns <c>SOCKET_ERROR</c> and a specific error code can be
	/// retrieved by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The name parameter is a NULL pointer or is not a valid part of the user address space. This error is also returned if the buffer
	/// size specified by namelen parameter is too small to hold the complete host name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>A successful WSAStartup call must occur before using this function.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetHostNameW</c> function returns the name of the local host into the buffer specified by the name parameter in Unicode
	/// (UTF-16). The host name is returned as a <c>null</c>-terminated Unicode string. The form of the host name is dependent on the
	/// Windows Sockets provider—it can be a simple host name, or it can be a fully qualified domain name. However, it is guaranteed
	/// that the name returned will be successfully parsed by GetAddrInfoW.
	/// </para>
	/// <para>
	/// With the growth of the Internet, there is a growing need to identify Internet host names for other languages not represented by
	/// the ASCII character set. Identifiers which facilitate this need and allow non-ASCII characters (Unicode) to be represented as
	/// special ASCII character strings (Punycode) are known as Internationalized Domain Names (IDNs). A mechanism called
	/// Internationalizing Domain Names in Applications (IDNA) is used to handle IDNs in a standard fashion. The <c>GetHostNameW</c>
	/// function does not convert the local hostname between Punycode and Unicode. The GetAddrInfoW function provides support for
	/// Internationalized Domain Name (IDN) parsing and performs Punycode/IDN encoding and conversion.
	/// </para>
	/// <para>
	/// If the <c>GetHostNameW</c> function is used on a cluster resource on Windows Server 2012 and the CLUSTER_NETWORK_NAME
	/// environment variable is defined, then the value in this environment variable overrides the actual hostname and is returned. On a
	/// cluster resource, the CLUSTER_NETWORK_NAME environment variable contains the name of the cluster.
	/// </para>
	/// <para>
	/// The <c>GetHostNameW</c> function queries namespace providers to determine the local host name using the SVCID_HOSTNAME GUID
	/// defined in the Svgguid.h header file. If no namespace provider responds, then the <c>GetHostNameW</c> function returns the
	/// NetBIOS name of the local computer in Unicode.
	/// </para>
	/// <para>
	/// The maximum length, in wide characters, of the string returned in the buffer pointed to by the name parameter is dependent on
	/// the namespace provider, but this string must be 256 wide characters or less. So if a buffer of 256 wide characters is passed in
	/// the name parameter and the namelen parameter is set to 256, the buffer size will always be adequate.
	/// </para>
	/// <para>
	/// <c>Note</c> If no local host name has been configured, <c>GetHostNameW</c> must succeed and return a token host name that
	/// GetAddrInfoW can resolve.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-gethostnamew int WSAAPI GetHostNameW( PWSTR name, int
	// namelen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("winsock2.h", MSDNShortId = "787EB209-5944-4F0A-8550-FE1115C2298A")]
	public static extern WSRESULT GetHostNameW(StringBuilder name, int namelen);

	/// <summary>The <c>getpeername</c> function retrieves the address of the peer to which a socket is connected.</summary>
	/// <param name="s">A descriptor identifying a connected socket.</param>
	/// <param name="name">The SOCKADDR structure that receives the address of the peer.</param>
	/// <param name="namelen">A pointer to the size, in bytes, of the name parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getpeername</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code
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
	/// <term>WSAEFAULT</term>
	/// <term>The name or the namelen parameter is not in a valid part of the user address space, or the namelen parameter is too small.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTCONN</term>
	/// <term>The socket is not connected.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor is not a socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>getpeername</c> function retrieves the address of the peer connected to the socket s and stores the address in the
	/// SOCKADDR structure identified by the name parameter. This function works with any address family and it simply returns the
	/// address to which the socket is connected. The <c>getpeername</c> function can be used only on a connected socket.
	/// </para>
	/// <para>
	/// For datagram sockets, only the address of a peer specified in a previous connect call will be returned. Any address specified by
	/// a previous sendto call will not be returned by <c>getpeername</c>.
	/// </para>
	/// <para>
	/// On call, the namelen parameter contains the size, in bytes, of the name buffer. On return, the namelen parameter contains the
	/// actual size, in bytes, of the name parameter returned.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-getpeername int getpeername( SOCKET s, sockaddr *name, int
	// *namelen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "df2679a5-cdd9-468b-823a-f98044189f65")]
	public static extern WSRESULT getpeername(SOCKET s, SOCKADDR name, ref int namelen);

	/// <summary>The <c>getprotobyname</c> function retrieves the protocol information corresponding to a protocol name.</summary>
	/// <param name="name">Pointer to a null-terminated protocol name.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getprotobyname</c> returns a pointer to the protoent. Otherwise, it returns a null pointer and a specific
	/// error number can be retrieved by calling WSAGetLastError.
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
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The name parameter is not a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>getprotobyname</c> function returns a pointer to the protoent structure containing the name(s) and protocol number that
	/// correspond to the protocol specified in the name parameter. All strings are null-terminated. The <c>protoent</c> structure is
	/// allocated by the Windows Sockets library. An application must never attempt to modify this structure or to free any of its
	/// components. Furthermore, like hostent, only one copy of this structure is allocated per thread, so the application should copy
	/// any information that it needs before issuing any other Windows Sockets function calls.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-getprotobyname protoent * getprotobyname( const char *name );
	[DllImport(Lib.Ws2_32, SetLastError = true, EntryPoint = "getprotobyname", CharSet = CharSet.Ansi)]
	[PInvokeData("winsock.h", MSDNShortId = "00669525-d477-4607-beaa-61ef5a8dbd4f")]
	public static extern unsafe PROTOENT* getprotobyname_unsafe(string name);

	/// <summary>The <c>getprotobyname</c> function retrieves the protocol information corresponding to a protocol name.</summary>
	/// <param name="name">Pointer to a null-terminated protocol name.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getprotobyname</c> returns a pointer to the protoent. Otherwise, it returns a null pointer and a specific
	/// error number can be retrieved by calling WSAGetLastError.
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
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The name parameter is not a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>getprotobyname</c> function returns a pointer to the protoent structure containing the name(s) and protocol number that
	/// correspond to the protocol specified in the name parameter. All strings are null-terminated. The <c>protoent</c> structure is
	/// allocated by the Windows Sockets library. An application must never attempt to modify this structure or to free any of its
	/// components. Furthermore, like hostent, only one copy of this structure is allocated per thread, so the application should copy
	/// any information that it needs before issuing any other Windows Sockets function calls.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-getprotobyname protoent * getprotobyname( const char *name );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("winsock.h", MSDNShortId = "00669525-d477-4607-beaa-61ef5a8dbd4f")]
	public static extern IntPtr getprotobyname(string name);

	/// <summary>The <c>getprotobynumber</c> function retrieves protocol information corresponding to a protocol number.</summary>
	/// <param name="number"/>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getprotobynumber</c> returns a pointer to the protoent structure. Otherwise, it returns a null pointer
	/// and a specific error number can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAHOST_NOT_FOUND</term>
	/// <term>Authoritative answer protocol not found.</term>
	/// </item>
	/// <item>
	/// <term>WSATRY_AGAIN</term>
	/// <term>A nonauthoritative Protocol not found, or server failure.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>Nonrecoverable errors, the protocols database is not accessible.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_DATA</term>
	/// <term>Valid name, no data record of requested type.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This <c>getprotobynumber</c> function returns a pointer to the protoent structure as previously described in getprotobyname. The
	/// contents of the structure correspond to the given protocol number.
	/// </para>
	/// <para>
	/// The pointer that is returned points to the structure allocated by Windows Sockets. The application must never attempt to modify
	/// this structure or to free any of its components. Furthermore, only one copy of this structure is allocated per thread, so the
	/// application should copy any information that it needs before issuing any other Windows Sockets function calls.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-getprotobynumber protoent *WSAAPI getprotobynumber( int
	// number );
	[DllImport(Lib.Ws2_32, SetLastError = true, EntryPoint = "getprotobynumber")]
	[PInvokeData("winsock2.h", MSDNShortId = "f1f55ab7-01ca-4ed7-b8f9-e7ddbaa95855")]
	public static extern unsafe PROTOENT* getprotobynumber_unsafe(int number);

	/// <summary>The <c>getprotobynumber</c> function retrieves protocol information corresponding to a protocol number.</summary>
	/// <param name="number"/>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getprotobynumber</c> returns a pointer to the protoent structure. Otherwise, it returns a null pointer
	/// and a specific error number can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAHOST_NOT_FOUND</term>
	/// <term>Authoritative answer protocol not found.</term>
	/// </item>
	/// <item>
	/// <term>WSATRY_AGAIN</term>
	/// <term>A nonauthoritative Protocol not found, or server failure.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>Nonrecoverable errors, the protocols database is not accessible.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_DATA</term>
	/// <term>Valid name, no data record of requested type.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This <c>getprotobynumber</c> function returns a pointer to the protoent structure as previously described in getprotobyname. The
	/// contents of the structure correspond to the given protocol number.
	/// </para>
	/// <para>
	/// The pointer that is returned points to the structure allocated by Windows Sockets. The application must never attempt to modify
	/// this structure or to free any of its components. Furthermore, only one copy of this structure is allocated per thread, so the
	/// application should copy any information that it needs before issuing any other Windows Sockets function calls.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-getprotobynumber protoent *WSAAPI getprotobynumber( int
	// number );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "f1f55ab7-01ca-4ed7-b8f9-e7ddbaa95855")]
	public static extern IntPtr getprotobynumber(int number);

	/// <summary>The <c>getservbyname</c> function retrieves service information corresponding to a service name and protocol.</summary>
	/// <param name="name">A pointer to a <c>null</c>-terminated service name.</param>
	/// <param name="proto">
	/// A pointer to a <c>null</c>-terminated protocol name. If this pointer is <c>NULL</c>, the <c>getservbyname</c> function returns
	/// the first service entry where name matches the <c>s_name</c> member of the servent structure or the <c>s_aliases</c> member of
	/// the <c>servent</c> structure. Otherwise, <c>getservbyname</c> matches both the name and the proto.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getservbyname</c> returns a pointer to the servent structure. Otherwise, it returns a <c>null</c> pointer
	/// and a specific error number can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAHOST_NOT_FOUND</term>
	/// <term>Authoritative Answer Service not found.</term>
	/// </item>
	/// <item>
	/// <term>WSATRY_AGAIN</term>
	/// <term>A nonauthoritative Service not found, or server failure.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>Nonrecoverable errors, the services database is not accessible.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_DATA</term>
	/// <term>Valid name, no data record of requested type.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>getservbyname</c> function returns a pointer to the servent structure containing the name(s) and service number that
	/// match the string in the name parameter. All strings are <c>null</c>-terminated.
	/// </para>
	/// <para>
	/// The pointer that is returned points to the <c>servent</c> structure allocated by the Windows Sockets library. The application
	/// must never attempt to modify this structure or to free any of its components. Furthermore, only one copy of this structure is
	/// allocated per thread, so the application should copy any information it needs before issuing any other Windows Sockets function calls.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-getservbyname servent * getservbyname( const char *name,
	// const char *proto );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("winsock.h", MSDNShortId = "730fa372-f620-4d21-99b9-3e7b79932792")]
	public static extern IntPtr getservbyname(string name, [Optional] string? proto);

	/// <summary>The <c>getservbyport</c> function retrieves service information corresponding to a port and protocol.</summary>
	/// <param name="port">Port for a service, in network byte order.</param>
	/// <param name="proto">
	/// Optional pointer to a protocol name. If this is null, <c>getservbyport</c> returns the first service entry for which the port
	/// matches the <c>s_port</c> of the servent structure. Otherwise, <c>getservbyport</c> matches both the port and the proto parameters.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getservbyport</c> returns a pointer to the servent structure. Otherwise, it returns a null pointer and a
	/// specific error number can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAHOST_NOT_FOUND</term>
	/// <term>Authoritative Answer Service not found.</term>
	/// </item>
	/// <item>
	/// <term>WSATRY_AGAIN</term>
	/// <term>A nonauthoritative Service not found, or server failure.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_RECOVERY</term>
	/// <term>Nonrecoverable errors, the services database is not accessible.</term>
	/// </item>
	/// <item>
	/// <term>WSANO_DATA</term>
	/// <term>Valid name, no data record of requested type.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The proto parameter is not a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Socket 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>getservbyport</c> function returns a pointer to a servent structure as it does in the getservbyname function.</para>
	/// <para>
	/// The <c>servent</c> structure is allocated by Windows Sockets. The application must never attempt to modify this structure or to
	/// free any of its components. Furthermore, only one copy of this structure is allocated per thread, so the application should copy
	/// any information it needs before issuing any other Windows Sockets function calls.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-getservbyport servent * getservbyport( int port, const char
	// *proto );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("winsock.h", MSDNShortId = "afd63c2d-4f77-49df-aeff-bfe56598fcbf")]
	public static extern IntPtr getservbyport(int port, [Optional] string? proto);

	/// <summary>The <c>getsockname</c> function retrieves the local name for a socket.</summary>
	/// <param name="s">Descriptor identifying a socket.</param>
	/// <param name="name">Pointer to a SOCKADDR structure that receives the address (name) of the socket.</param>
	/// <param name="namelen">Size of the name buffer, in bytes.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getsockname</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>A successful WSAStartup call must occur before using this API.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The name or the namelen parameter is not a valid part of the user address space, or the namelen parameter is too small.</term>
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
	/// <term>WSAEINVAL</term>
	/// <term>The socket has not been bound to an address with bind, or ADDR_ANY is specified in bind but connection has not yet occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>getsockname</c> function retrieves the current name for the specified socket descriptor in name. It is used on the bound
	/// or connected socket specified by the s parameter. The local association is returned. This call is especially useful when a
	/// connect call has been made without doing a bind first; the <c>getsockname</c> function provides the only way to determine the
	/// local association that has been set by the system.
	/// </para>
	/// <para>
	/// On call, the namelen parameter contains the size of the name buffer, in bytes. On return, the namelen parameter contains the
	/// actual size in bytes of the name parameter.
	/// </para>
	/// <para>
	/// The <c>getsockname</c> function does not always return information about the host address when the socket has been bound to an
	/// unspecified address, unless the socket has been connected with connect or accept (for example, using ADDR_ANY). A Windows
	/// Sockets application must not assume that the address will be specified unless the socket is connected. The address that will be
	/// used for the socket is unknown unless the socket is connected when used in a multihomed host. If the socket is using a
	/// connectionless protocol, the address may not be available until I/O occurs on the socket.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winsock/nf-winsock-getsockname int getsockname( SOCKET s, sockaddr *name,
	// int *namelen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "be20a731-cdfc-48ae-90b2-43f2cf9ecf6d")]
	public static extern WSRESULT getsockname(SOCKET s, SOCKADDR name, ref int namelen);

	/// <summary>The <c>getsockopt</c> function retrieves a socket option.</summary>
	/// <param name="s">A descriptor identifying a socket.</param>
	/// <param name="level">The level at which the option is defined. Example: SOL_SOCKET.</param>
	/// <param name="optname">
	/// The socket option for which the value is to be retrieved. Example: SO_ACCEPTCONN. The optname value must be a socket option
	/// defined within the specified level, or behavior is undefined.
	/// </param>
	/// <param name="optval">A pointer to the buffer in which the value for the requested option is to be returned.</param>
	/// <param name="optlen">A pointer to the size, in bytes, of the optval buffer.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>getsockopt</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code
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
	/// <term/>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>
	/// One of the optval or the optlen parameters is not a valid part of the user address space, or the optlen parameter is too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The level parameter is unknown or invalid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOPROTOOPT</term>
	/// <term>The option is unknown or unsupported by the indicated protocol family.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor is not a socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>getsockopt</c> function retrieves the current value for a socket option associated with a socket of any type, in any
	/// state, and stores the result in optval. Options can exist at multiple protocol levels, but they are always present at the
	/// uppermost socket level. Options affect socket operations, such as the packet routing and OOB data transfer.
	/// </para>
	/// <para>
	/// The value associated with the selected option is returned in the buffer optval. The integer pointed to by optlen should
	/// originally contain the size of this buffer; on return, it will be set to the size of the value returned. For SO_LINGER, this
	/// will be the size of a LINGER structure. For most other options, it will be the size of an integer.
	/// </para>
	/// <para>
	/// The application is responsible for allocating any memory space pointed to directly or indirectly by any of the parameters it specified.
	/// </para>
	/// <para>If the option was never set with setsockopt, then <c>getsockopt</c> returns the default value for the option.</para>
	/// <para>The following options are supported for <c>getsockopt</c>. The Type column identifies the type of data addressed by optval.</para>
	/// <para>For more information on socket options, see Socket Options.</para>
	/// <para>The following table of value for the optname parameter are valid when the level parameter is set to <c>SOL_SOCKET</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SO_ACCEPTCONN</term>
	/// <term>BOOL</term>
	/// <term>The socket is listening.</term>
	/// </item>
	/// <item>
	/// <term>SO_BROADCAST</term>
	/// <term>BOOL</term>
	/// <term>The socket is configured for the transmission and receipt of broadcast messages.</term>
	/// </item>
	/// <item>
	/// <term>SO_BSP_STATE</term>
	/// <term>CSADDR_INFO</term>
	/// <term>Returns the local address, local port, remote address, remote port, socket type, and protocol used by a socket.</term>
	/// </item>
	/// <item>
	/// <term>SO_CONDITIONAL_ACCEPT</term>
	/// <term>BOOL</term>
	/// <term>Returns current socket state, either from a previous call to setsockopt or the system default.</term>
	/// </item>
	/// <item>
	/// <term>SO_CONNECT_TIME</term>
	/// <term>DWORD</term>
	/// <term>
	/// Returns the number of seconds a socket has been connected. This socket option is valid for connection oriented protocols only.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_DEBUG</term>
	/// <term>BOOL</term>
	/// <term>Debugging is enabled.</term>
	/// </item>
	/// <item>
	/// <term>SO_DONTLINGER</term>
	/// <term>BOOL</term>
	/// <term>If TRUE, the SO_LINGER option is disabled.</term>
	/// </item>
	/// <item>
	/// <term>SO_DONTROUTE</term>
	/// <term>BOOL</term>
	/// <term>
	/// Routing is disabled. Setting this succeeds but is ignored on AF_INET sockets; fails on AF_INET6 sockets with WSAENOPROTOOPT.
	/// This option is not supported on ATM sockets.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_ERROR</term>
	/// <term>int</term>
	/// <term>Retrieves error status and clear.</term>
	/// </item>
	/// <item>
	/// <term>SO_EXCLUSIVEADDRUSE</term>
	/// <term>BOOL</term>
	/// <term>Prevents any other socket from binding to the same address and port. This option must be set before calling the bind function.</term>
	/// </item>
	/// <item>
	/// <term>SO_GROUP_ID</term>
	/// <term>GROUP</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SO_GROUP_PRIORITY</term>
	/// <term>int</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SO_KEEPALIVE</term>
	/// <term>BOOL</term>
	/// <term>Keep-alives are being sent. Not supported on ATM sockets.</term>
	/// </item>
	/// <item>
	/// <term>SO_LINGER</term>
	/// <term>LINGER structure</term>
	/// <term>Returns the current linger options.</term>
	/// </item>
	/// <item>
	/// <term>SO_MAX_MSG_SIZE</term>
	/// <term>unsigned int</term>
	/// <term>
	/// The maximum size of a message for message-oriented socket types (for example, SOCK_DGRAM). Has no meaning for stream oriented sockets.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_OOBINLINE</term>
	/// <term>BOOL</term>
	/// <term>
	/// OOB data is being received in the normal data stream. (See section Windows Sockets 1.1 Blocking Routines and EINPROGRESS for a
	/// discussion of this topic.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_PORT_SCALABILITY</term>
	/// <term>BOOL</term>
	/// <term>
	/// Enables local port scalability for a socket by allowing port allocation to be maximized by allocating wildcard ports multiple
	/// times for different local address port pairs on a local machine.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_PROTOCOL_INFO</term>
	/// <term>WSAPROTOCOL_INFO</term>
	/// <term>A description of the protocol information for the protocol that is bound to this socket.</term>
	/// </item>
	/// <item>
	/// <term>SO_RCVBUF</term>
	/// <term>int</term>
	/// <term>
	/// The total per-socket buffer space reserved for receives. This is unrelated to SO_MAX_MSG_SIZE and does not necessarily
	/// correspond to the size of the TCP receive window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_REUSEADDR</term>
	/// <term>BOOL</term>
	/// <term>The socket can be bound to an address which is already in use. Not applicable for ATM sockets.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDBUF</term>
	/// <term>int</term>
	/// <term>
	/// The total per-socket buffer space reserved for sends. This is unrelated to SO_MAX_MSG_SIZE and does not necessarily correspond
	/// to the size of a TCP send window.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_TYPE</term>
	/// <term>int</term>
	/// <term>The type of the socket (for example, SOCK_STREAM).</term>
	/// </item>
	/// <item>
	/// <term>PVD_CONFIG</term>
	/// <term>Service Provider Dependent</term>
	/// <term>
	/// An opaque data structure object from the service provider associated with socket s. This object stores the current configuration
	/// information of the service provider. The exact format of this data structure is service provider specific.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The following table of value for the optname parameter are valid when the level parameter is set to <c>IPPROTO_TCP</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TCP_NODELAY</term>
	/// <term>BOOL</term>
	/// <term>Disables the Nagle algorithm for send coalescing.</term>
	/// </item>
	/// </list>
	/// <para>The following table of value for the optname parameter are valid when the level parameter is set to <c>NSPROTO_IPX</c>.</para>
	/// <para><c>Note</c> Windows NT supports all IPX options. Windows Me, Windows 98, and Windows 95 support only the following options:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IPX_PTYPE</term>
	/// <term>int</term>
	/// <term>Retrieves the IPX packet type.</term>
	/// </item>
	/// <item>
	/// <term>IPX_FILTERPTYPE</term>
	/// <term>int</term>
	/// <term>Retrieves the receive filter packet type</term>
	/// </item>
	/// <item>
	/// <term>IPX_DSTYPE</term>
	/// <term>int</term>
	/// <term>Obtains the value of the data stream field in the SPX header on every packet sent.</term>
	/// </item>
	/// <item>
	/// <term>IPX_EXTENDED_ADDRESS</term>
	/// <term>BOOL</term>
	/// <term>Finds out whether extended addressing is enabled.</term>
	/// </item>
	/// <item>
	/// <term>IPX_RECVHDR</term>
	/// <term>BOOL</term>
	/// <term>Finds out whether the protocol header is sent up on all receive headers.</term>
	/// </item>
	/// <item>
	/// <term>IPX_MAXSIZE</term>
	/// <term>int</term>
	/// <term>Obtains the maximum data size that can be sent.</term>
	/// </item>
	/// <item>
	/// <term>IPX_ADDRESS</term>
	/// <term>IPX_ADDRESS_DATA structure</term>
	/// <term>
	/// Obtains information about a specific adapter to which IPX is bound. Adapter numbering is base zero. The adapternum member is
	/// filled in upon return.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPX_GETNETINFO</term>
	/// <term>IPX_NETNUM_DATA structure</term>
	/// <term>Obtains information about a specific IPX network number. If not available in the cache, uses RIP to obtain information.</term>
	/// </item>
	/// <item>
	/// <term>IPX_GETNETINFO_NORIP</term>
	/// <term>IPX_NETNUM_DATA structure</term>
	/// <term>
	/// Obtains information about a specific IPX network number. If not available in the cache, will not use RIP to obtain information,
	/// and returns error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPX_SPXGETCONNECTIONSTATUS</term>
	/// <term>IPX_SPXCONNSTATUS_DATA structure</term>
	/// <term>Retrieves information about a connected SPX socket.</term>
	/// </item>
	/// <item>
	/// <term>IPX_ADDRESS_NOTIFY</term>
	/// <term>IPX_ADDRESS_DATA structure</term>
	/// <term>Retrieves status notification when changes occur on an adapter to which IPX is bound.</term>
	/// </item>
	/// <item>
	/// <term>IPX_MAX_ADAPTER_NUM</term>
	/// <term>int</term>
	/// <term>Retrieves maximum number of adapters present, numbered as base zero.</term>
	/// </item>
	/// <item>
	/// <term>IPX_RERIPNETNUMBER</term>
	/// <term>IPX_NETNUM_DATA structure</term>
	/// <term>Similar to IPX_GETNETINFO, but forces IPX to use RIP for resolution, even if the network information is in the local cache.</term>
	/// </item>
	/// <item>
	/// <term>IPX_IMMEDIATESPXACK</term>
	/// <term>BOOL</term>
	/// <term>
	/// Directs SPX connections not to delay before sending an ACK. Applications without back-and-forth traffic should set this to TRUE
	/// to increase performance.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TCP_MAXSEG</term>
	/// <term>int</term>
	/// <term>Receives TCP maximum-segment size. Supported in Windows 10 and newer versions.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following table lists value for the optname that represent BSD socket options that are not supported by the
	/// <c>getsockopt</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SO_RCVLOWAT</term>
	/// <term>int</term>
	/// <term>Receives low watermark.</term>
	/// </item>
	/// <item>
	/// <term>SO_RCVTIMEO</term>
	/// <term>int</term>
	/// <term>Receives time-out.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDLOWAT</term>
	/// <term>int</term>
	/// <term>Sends low watermark.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDTIMEO</term>
	/// <term>int</term>
	/// <term>Sends time-out.</term>
	/// </item>
	/// <item>
	/// <term>TCP_MAXSEG</term>
	/// <term>int</term>
	/// <term>Receives TCP maximum-segment size. Not supported in versions before Windows 10.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When using the recv function, if no data arrives during the period specified in SO_RCVTIMEO, the <c>recv</c>
	/// function completes. In Windows versions prior to Windows 2000, any data received subsequently fails with WSAETIMEDOUT. In
	/// Windows 2000 and later, if no data arrives within the period specified in SO_RCVTIMEO, the <c>recv</c> function returns
	/// WSAETIMEDOUT, and if data is received, <c>recv</c> returns SUCCESS.
	/// </para>
	/// <para>
	/// Calling <c>getsockopt</c> with an unsupported option will result in an error code of WSAENOPROTOOPT being returned from WSAGetLastError.
	/// </para>
	/// <para>
	/// More detailed information on some of the socket options for the optname parameter supported by the <c>getsockopt</c> function
	/// are listed below.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>getsockopt</c>, Winsock may need to wait for a network event before
	/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
	/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
	/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following code sample demonstrates the use of the <c>getsockopt</c> function.</para>
	/// <para>Notes for IrDA Sockets</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Windows returns WSAENETDOWN to indicate the underlying transceiver driver failed to initialize with the IrDA protocol stack.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IrDA supports several special socket options:</term>
	/// </item>
	/// </list>
	/// <para>
	/// Before an IrDA socket connection can be initiated, a device address must be obtained by performing a
	/// <c>getsockopt</c>(,,IRLMP_ENUMDEVICES,,) function call, which returns a list of all available IrDA devices. A device address
	/// returned from the function call is copied into a SOCKADDR_IRDA structure, which in turn is used by a subsequent call to the
	/// connect function call.
	/// </para>
	/// <para>Discovery can be performed in two ways:</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// First, performing a getsockopt function call with the IRLMP_ENUMDEVICES option causes a single discovery to be run on each idle
	/// adapter. The list of discovered devices and cached devices (on active adapters) is returned immediately.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The second approach to performing discovery of IrDA device addresses is to perform a lazy discovery; in this approach, the
	/// application is not notified until the discovered devices list changes from the last discovery run by the stack.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>DEVICELIST</c> structure shown in the Type column in the previous table is an extendible array of device descriptions.
	/// IrDA fills in as many device descriptions as can fit in the specified buffer. The device description consists of a device
	/// identifier necessary to form a sockaddr_irda structure, and a displayable string describing the device.
	/// </para>
	/// <para>
	/// The <c>IAS_QUERY</c> structure shown in the Type column in the previous table is used to retrieve a single attribute of a single
	/// class from a peer device's IAS database. The application specifies the device and class to query and the attribute and attribute
	/// type. Note that the device would have been obtained previously by a call to <c>getsockopt</c>(IRLMP_ENUMDEVICES). It is expected
	/// that the application allocates a buffer, of the necessary size, for the returned parameters.
	/// </para>
	/// <para>Many level socket options are not meaningful to IrDA; only SO_LINGER and SO_DONTLINGER are specifically supported.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-getsockopt int getsockopt( SOCKET s, int level, int
	// optname, char *optval, int *optlen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("winsock.h", MSDNShortId = "25bc511d-7a9f-41c1-8983-1af1e3f8bf2d")]
	public static extern WSRESULT getsockopt(SOCKET s, int level, int optname, [Optional] IntPtr optval, ref int optlen);

	/// <summary>The <c>htonl</c> function converts a <c>u_long</c> from host to TCP/IP network byte order (which is big-endian).</summary>
	/// <param name="hostlong">A 32-bit number in host byte order.</param>
	/// <returns>The <c>htonl</c> function returns the value in TCP/IP's network byte order.</returns>
	/// <remarks>
	/// <para>
	/// The <c>htonl</c> function takes a 32-bit number in host byte order and returns a 32-bit number in the network byte order used in
	/// TCP/IP networks (the AF_INET or AF_INET6 address family).
	/// </para>
	/// <para>
	/// The <c>htonl</c> function can be used to convert an IPv4 address in host byte order to the IPv4 address in network byte order.
	/// This function does not do any checking to determine if the hostlong parameter is a valid IPv4 address.
	/// </para>
	/// <para>
	/// The <c>htonl</c> function does not require that the Winsock DLL has previously been loaded with a successful call to the
	/// WSAStartup function.
	/// </para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-htonl u_long htonl( u_long hostlong );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "e3a18c5e-7efb-43d9-9abc-9d573bbb1923")]
	public static extern uint htonl(uint hostlong);

	/// <summary>The <c>htons</c> function converts a <c>u_short</c> from host to TCP/IP network byte order (which is big-endian).</summary>
	/// <param name="hostshort">A 16-bit number in host byte order.</param>
	/// <returns>The <c>htons</c> function returns the value in TCP/IP network byte order.</returns>
	/// <remarks>
	/// <para>
	/// The <c>htons</c> function takes a 16-bit number in host byte order and returns a 16-bit number in network byte order used in
	/// TCP/IP networks (the AF_INET or AF_INET6 address family).
	/// </para>
	/// <para>
	/// The <c>htons</c> function can be used to convert an IP port number in host byte order to the IP port number in network byte order.
	/// </para>
	/// <para>
	/// The <c>htons</c> function does not require that the Winsock DLL has previously been loaded with a successful call to the
	/// WSAStartup function.
	/// </para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-htons u_short htons( u_short hostshort );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "3dae2655-2b3c-41d9-9650-125ac393d64a")]
	public static extern ushort htons(ushort hostshort);

	/// <summary>
	/// The <c>inet_addr</c> function converts a string containing an IPv4 dotted-decimal address into a proper address for the IN_ADDR structure.
	/// </summary>
	/// <param name="cp">TBD</param>
	/// <returns>
	/// <para>
	/// If no error occurs, the <c>inet_addr</c> function returns an unsigned long value containing a suitable binary representation of
	/// the Internet address given.
	/// </para>
	/// <para>
	/// If the string in the cp parameter does not contain a legitimate Internet address, for example if a portion of an "a.b.c.d"
	/// address exceeds 255, then <c>inet_addr</c> returns the value <c>INADDR_NONE</c>.
	/// </para>
	/// <para>
	/// On Windows Server 2003and later if the string in the cp parameter is an empty string, then <c>inet_addr</c> returns the value
	/// <c>INADDR_NONE</c>. If <c>NULL</c> is passed in the cp parameter, then <c>inet_addr</c> returns the value <c>INADDR_NONE</c>.
	/// </para>
	/// <para>
	/// On Windows XPand earlier if the string in the cp parameter is an empty string, then <c>inet_addr</c> returns the value
	/// <c>INADDR_ANY</c>. If <c>NULL</c> is passed in the cp parameter, then <c>inet_addr</c> returns the value <c>INADDR_NONE</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>inet_addr</c> function interprets the character string specified by the cp parameter. This string represents a numeric
	/// Internet address expressed in the Internet standard ".'' notation. The value returned is a number suitable for use as an
	/// Internet address. All Internet addresses are returned in IP's network order (bytes ordered from left to right). If you pass in "
	/// " (a space) to the <c>inet_addr</c> function, <c>inet_addr</c> returns zero.
	/// </para>
	/// <para>
	/// On Windows Vista and later, the RtlIpv4StringToAddress function can be used to convert a string representation of an IPv4
	/// address to a binary IPv4 address represented as an IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress
	/// function can be used to convert a string representation of an IPv6 address to a binary IPv6 address represented as an
	/// <c>IN6_ADDR</c> structure.
	/// </para>
	/// <para>Internet Addresses</para>
	/// <para>Values specified using the ".'' notation take one of the following forms:</para>
	/// <para>a.b.c.d a.b.c a.b a</para>
	/// <para>
	/// When four parts are specified, each is interpreted as a byte of data and assigned, from left to right, to the 4 bytes of an
	/// Internet address. When an Internet address is viewed as a 32-bit integer quantity on the Intel architecture, the bytes referred
	/// to above appear as "d.c.b.a''. That is, the bytes on an Intel processor are ordered from right to left.
	/// </para>
	/// <para>
	/// The parts that make up an address in "." notation can be decimal, octal or hexadecimal as specified in the C language. Numbers
	/// that start with "0x" or "0X" imply hexadecimal. Numbers that start with "0" imply octal. All other numbers are interpreted as decimal.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Internet address value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>"4.3.2.16"</term>
	/// <term>Decimal</term>
	/// </item>
	/// <item>
	/// <term>"004.003.002.020"</term>
	/// <term>Octal</term>
	/// </item>
	/// <item>
	/// <term>"0x4.0x3.0x2.0x10"</term>
	/// <term>Hexadecimal</term>
	/// </item>
	/// <item>
	/// <term>"4.003.002.0x10"</term>
	/// <term>Mix</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>inet_addr</c> function supports the decimal, octal, hexadecimal, and mixed notations for the string passed in the cp parameter.
	/// </para>
	/// <para>
	/// <c>Note</c> The following notations are only used by Berkeley software, and nowhere else on the Internet. For compatibility with
	/// Berkeley software, the <c>inet_addr</c> function also supports the additional notations specified below.
	/// </para>
	/// <para>
	/// When a three-part address is specified, the last part is interpreted as a 16-bit quantity and placed in the right-most 2 bytes
	/// of the network address. This makes the three-part address format convenient for specifying Class B network addresses as "128.net.host''
	/// </para>
	/// <para>
	/// When a two-part address is specified, the last part is interpreted as a 24-bit quantity and placed in the right-most 3 bytes of
	/// the network address. This makes the two-part address format convenient for specifying Class A network addresses as "net.host''.
	/// </para>
	/// <para>When only one part is given, the value is stored directly in the network address without any byte rearrangement.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to use the <c>inet_addr</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-inet_addr unsigned long WSAAPI inet_addr( const char *cp );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("winsock2.h", MSDNShortId = "7d6df658-9d83-45c7-97e7-b2a016a73847")]
	public static extern uint inet_addr(string? cp);

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
	/// <c>NULL</c>-terminated ASCII string that represents the address in "." (dot) notation as in "192.168.16.0", an example of an
	/// IPv4 address in dotted-decimal notation. The string returned by <c>inet_ntoa</c> resides in memory that is allocated by Windows
	/// Sockets. The application should not make any assumptions about the way in which the memory is allocated. The string returned is
	/// guaranteed to be valid only until the next Windows Sockets function call is made within the same thread. Therefore, the data
	/// should be copied before another Windows Sockets call is made.
	/// </para>
	/// <para>
	/// The WSAAddressToString function can be used to convert a sockaddr structure containing an IPv4 address to a string
	/// representation of an IPv4 address in Internet standard dotted-decimal notation. The advantage of the <c>WSAAddressToString</c>
	/// function is that it supports both IPv4 and IPv6 addresses. Another advantage of the <c>WSAAddressToString</c> function is that
	/// there are both ASCII and Unicode versions of this function.
	/// </para>
	/// <para>
	/// On Windows Vista and later, the RtlIpv4AddressToString function can be used to convert an IPv4 address represented as an IN_ADDR
	/// structure to a string representation of an IPv4 address in Internet standard dotted-decimal notation. On Windows Vista and
	/// later, the RtlIpv6AddressToString function can be used to convert an IPv6 address represented as an <c>IN6_ADDR</c> structure to
	/// a string representation of an IPv6 address.
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
	public static extern LPSTR inet_ntoa(IN_ADDR a);

	/// <summary>The <c>ioctlsocket</c> function controls the I/O mode of a socket.</summary>
	/// <param name="s">A descriptor identifying a socket.</param>
	/// <param name="cmd">A command to perform on the socket s.</param>
	/// <param name="argp">A pointer to a parameter for cmd.</param>
	/// <returns>
	/// <para>
	/// Upon successful completion, the <c>ioctlsocket</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific
	/// error code can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor s is not a socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The argp parameter is not a valid part of the user address space.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ioctlsocket</c> function can be used on any socket in any state. It is used to set or retrieve some operating parameters
	/// associated with the socket, independent of the protocol and communications subsystem. Here are the supported commands to use in
	/// the cmd parameter and their semantics:
	/// </para>
	/// <para>
	/// The WSAIoctl function is used to set or retrieve operating parameters associated with the socket, the transport protocol, or the
	/// communications subsystem.
	/// </para>
	/// <para>
	/// The <c>WSAIoctl</c> function is more powerful than the <c>ioctlsocket</c> function and supports a large number of possible
	/// values for the operating parameters to set or retrieve.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>ioctlsocket</c> function.</para>
	/// <para>Compatibility</para>
	/// <para>
	/// This <c>ioctlsocket</c> function performs only a subset of functions on a socket when compared to the <c>ioctl</c> function
	/// found in Berkeley sockets. The <c>ioctlsocket</c> function has no command parameter equivalent to the FIOASYNC of <c>ioctl</c>,
	/// and SIOCATMARK is the only socket-level command that is supported by <c>ioctlsocket</c>.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-ioctlsocket int ioctlsocket( SOCKET s, long cmd, u_long
	// *argp );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "048fcb8d-acd3-4917-a997-dd133db399f8")]
	public static extern WSRESULT ioctlsocket(SOCKET s, uint cmd, IntPtr argp);

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
	/// backlog for incoming connections is specified with <c>listen</c>, and then the connections are accepted with the accept
	/// function. Sockets that are connection oriented, those of type <c>SOCK_STREAM</c> for example, are used with <c>listen</c>. The
	/// socket s is put into passive mode where incoming connection requests are acknowledged and queued pending acceptance by the process.
	/// </para>
	/// <para>
	/// A value for the backlog of <c>SOMAXCONN</c> is a special constant that instructs the underlying service provider responsible for
	/// socket s to set the length of the queue of pending connections to a maximum reasonable value.
	/// </para>
	/// <para>On Windows Sockets 2, this maximum value defaults to a large value (typically several hundred or more).</para>
	/// <para>
	/// When calling the <c>listen</c> function in a Bluetooth application, it is strongly recommended that a much lower value be used
	/// for the backlog parameter (typically 2 to 4), since only a few client connections are accepted. This reduces the system
	/// resources that are allocated for use by the listening socket. This same recommendation applies to other network applications
	/// that expect only a few client connections.
	/// </para>
	/// <para>
	/// The <c>listen</c> function is typically used by servers that can have more than one connection request at a time. If a
	/// connection request arrives and the queue is full, the client will receive an error with an indication of WSAECONNREFUSED.
	/// </para>
	/// <para>
	/// If there are no available socket descriptors, <c>listen</c> attempts to continue to function. If descriptors become available, a
	/// later call to <c>listen</c> or accept will refill the queue to the current or most recent value specified for the backlog
	/// parameter, if possible, and resume listening for incoming connections.
	/// </para>
	/// <para>
	/// If the <c>listen</c> function is called on an already listening socket, it will return success without changing the value for
	/// the backlog parameter. Setting the backlog parameter to 0 in a subsequent call to <c>listen</c> on a listening socket is not
	/// considered a proper reset, especially if there are connections on the socket.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>listen</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
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
	public static extern WSRESULT listen(SOCKET s, int backlog);

	/// <summary>
	/// The <c>ntohl</c> function converts a <c>u_long</c> from TCP/IP network order to host byte order (which is little-endian on Intel processors).
	/// </summary>
	/// <param name="netlong">A 32-bit number in TCP/IP network byte order.</param>
	/// <returns>
	/// The <c>ntohl</c> function returns the value supplied in the netlong parameter with the byte order reversed. If netlong is
	/// already in host byte order, then this function will reverse it. It is up to the application to determine if the byte order must
	/// be reversed.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ntohl</c> function takes a 32-bit number in TCP/IP network byte order (the AF_INET or AF_INET6 address family) and
	/// returns a 32-bit number in host byte order.
	/// </para>
	/// <para>
	/// The <c>ntohl</c> function can be used to convert an IPv4 address in network byte order to the IPv4 address in host byte order.
	/// This function does not do any checking to determine if the netlong parameter is a valid IPv4 address.
	/// </para>
	/// <para>
	/// The <c>ntohl</c> function does not require that the Winsock DLL has previously been loaded with a successful call to the
	/// WSAStartup function.
	/// </para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-ntohl u_long ntohl( u_long netlong );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "04673bef-22c6-424f-a5ae-689fb648b54e")]
	public static extern uint ntohl(uint netlong);

	/// <summary>
	/// The <c>ntohs</c> function converts a <c>u_short</c> from TCP/IP network byte order to host byte order (which is little-endian on
	/// Intel processors).
	/// </summary>
	/// <param name="netshort">A 16-bit number in TCP/IP network byte order.</param>
	/// <returns>
	/// The <c>ntohs</c> function returns the value in host byte order. If the netshort parameter is already in host byte order, then
	/// this function will reverse it. It is up to the application to determine if the byte order must be reversed.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ntohs</c> function takes a 16-bit number in TCP/IP network byte order (the AF_INET or AF_INET6 address family) and
	/// returns a 16-bit number in host byte order.
	/// </para>
	/// <para>
	/// The <c>ntohs</c> function can be used to convert an IP port number in network byte order to the IP port number in host byte order.
	/// </para>
	/// <para>
	/// The <c>ntohs</c> function does not require that the Winsock DLL has previously been loaded with a successful call to the
	/// WSAStartup function.
	/// </para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-ntohs u_short ntohs( u_short netshort );
	[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "9946df13-3b40-4bcb-91ca-10684b3fc9a5")]
	public static extern ushort ntohs(ushort netshort);

	/// <summary>The <c>recv</c> function receives data from a connected socket or a bound connectionless socket.</summary>
	/// <param name="s">The descriptor that identifies a connected socket.</param>
	/// <param name="buf">A pointer to the buffer to receive the incoming data.</param>
	/// <param name="len">The length, in bytes, of the buffer pointed to by the buf parameter.</param>
	/// <param name="flags">
	/// A set of flags that influences the behavior of this function. See remarks below. See the Remarks section for details on the
	/// possible value for this parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>recv</c> returns the number of bytes received and the buffer pointed to by the buf parameter will contain
	/// this data received. If the connection has been gracefully closed, the return value is zero.
	/// </para>
	/// <para>Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</para>
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
	/// <term>The buf parameter is not completely contained in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTCONN</term>
	/// <term>The socket is not connected.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>The (blocking) call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>
	/// For a connection-oriented socket, this error indicates that the connection has been broken due to keep-alive activity that
	/// detected a failure while the operation was in progress. For a datagram socket, this error indicates that the time to live has expired.
	/// </term>
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
	/// The socket has been shut down; it is not possible to receive on a socket after shutdown has been invoked with how set to
	/// SD_RECEIVE or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the receive operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The message was too large to fit into the specified buffer and was truncated.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with
	/// SO_OOBINLINE enabled or (for byte stream sockets only) len was zero or negative.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>The connection has been dropped because of a network failure or because the peer system failed to respond.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket as
	/// it is no longer usable. On a UDP-datagram socket, this error would indicate that a previous send operation resulted in an ICMP
	/// "Port Unreachable" message.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>recv</c> function is used to read incoming data on connection-oriented sockets, or connectionless sockets. When using a
	/// connection-oriented protocol, the sockets must be connected before calling <c>recv</c>. When using a connectionless protocol,
	/// the sockets must be bound before calling <c>recv</c>.
	/// </para>
	/// <para>
	/// The local address of the socket must be known. For server applications, use an explicit bind function or an implicit accept or
	/// WSAAccept function. Explicit binding is discouraged for client applications. For client applications, the socket can become
	/// bound implicitly to a local address using connect, WSAConnect, sendto, WSASendTo, or WSAJoinLeaf.
	/// </para>
	/// <para>
	/// For connected or connectionless sockets, the <c>recv</c> function restricts the addresses from which received messages are
	/// accepted. The function only returns messages from the remote address specified in the connection. Messages from other addresses
	/// are (silently) discarded.
	/// </para>
	/// <para>
	/// For connection-oriented sockets (type SOCK_STREAM for example), calling <c>recv</c> will return as much data as is currently
	/// available—up to the size of the buffer specified. If the socket has been configured for in-line reception of OOB data (socket
	/// option SO_OOBINLINE) and OOB data is yet unread, only OOB data will be returned. The application can use the ioctlsocket or
	/// WSAIoctl <c>SIOCATMARK</c> command to determine whether any more OOB data remains to be read.
	/// </para>
	/// <para>
	/// For connectionless sockets (type SOCK_DGRAM or other message-oriented sockets), data is extracted from the first enqueued
	/// datagram (message) from the destination address specified by the connect function.
	/// </para>
	/// <para>
	/// If the datagram or message is larger than the buffer specified, the buffer is filled with the first part of the datagram, and
	/// <c>recv</c> generates the error WSAEMSGSIZE. For unreliable protocols (for example, UDP) the excess data is lost; for reliable
	/// protocols, the data is retained by the service provider until it is successfully read by calling <c>recv</c> with a large enough buffer.
	/// </para>
	/// <para>
	/// If no incoming data is available at the socket, the <c>recv</c> call blocks and waits for data to arrive according to the
	/// blocking rules defined for WSARecv with the MSG_PARTIAL flag not set unless the socket is nonblocking. In this case, a value of
	/// SOCKET_ERROR is returned with the error code set to WSAEWOULDBLOCK. The select, WSAAsyncSelect, or WSAEventSelect functions can
	/// be used to determine when more data arrives.
	/// </para>
	/// <para>
	/// If the socket is connection oriented and the remote side has shut down the connection gracefully, and all data has been
	/// received, a <c>recv</c> will complete immediately with zero bytes received. If the connection has been reset, a <c>recv</c> will
	/// fail with the error WSAECONNRESET.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
	/// associated socket. The semantics of this function are determined by the socket options and the flags parameter. The possible
	/// value of flags parameter is constructed by using the bitwise OR operator with any of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSG_PEEK</term>
	/// <term>
	/// Peeks at the incoming data. The data is copied into the buffer, but is not removed from the input queue. The function
	/// subsequently returns the amount of data that can be read in a single call to the recv (or recvfrom) function, which may not be
	/// the same as the total amount of data queued on the socket. The amount of data that can actually be read in a single call to the
	/// recv (or recvfrom) function is limited to the data size written in the send or sendto function call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSG_OOB</term>
	/// <term>Processes Out Of Band (OOB) data.</term>
	/// </item>
	/// <item>
	/// <term>MSG_WAITALL</term>
	/// <term>
	/// The receive request will complete only when one of the following events occurs:Note that if the underlying transport does not
	/// support MSG_WAITALL, or if the socket is in a non-blocking mode, then this call will fail with WSAEOPNOTSUPP. Also, if
	/// MSG_WAITALL is specified along with MSG_OOB, MSG_PEEK, or MSG_PARTIAL, then this call will fail with WSAEOPNOTSUPP. This flag is
	/// not supported on datagram sockets or message-oriented sockets.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>recv</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following code example shows the use of the <c>recv</c> function.</para>
	/// <para>Example Code</para>
	/// <para>For more information, and another example of the <c>recv</c> function, see Getting Started With Winsock.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-recv int recv( SOCKET s, char *buf, int len, int flags );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "8c247cd3-479f-45d0-a038-a24e80cc7c73")]
	public static extern int recv(SOCKET s, IntPtr buf, int len, MsgFlags flags);

	/// <summary>The <c>recv</c> function receives data from a connected socket or a bound connectionless socket.</summary>
	/// <param name="s">The descriptor that identifies a connected socket.</param>
	/// <param name="buf">A pointer to the buffer to receive the incoming data.</param>
	/// <param name="len">The length, in bytes, of the buffer pointed to by the buf parameter.</param>
	/// <param name="flags">
	/// A set of flags that influences the behavior of this function. See remarks below. See the Remarks section for details on the
	/// possible value for this parameter.
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>recv</c> returns the number of bytes received and the buffer pointed to by the buf parameter will contain
	/// this data received. If the connection has been gracefully closed, the return value is zero.
	/// </para>
	/// <para>Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.</para>
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
	/// <term>The buf parameter is not completely contained in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTCONN</term>
	/// <term>The socket is not connected.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>The (blocking) call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>
	/// For a connection-oriented socket, this error indicates that the connection has been broken due to keep-alive activity that
	/// detected a failure while the operation was in progress. For a datagram socket, this error indicates that the time to live has expired.
	/// </term>
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
	/// The socket has been shut down; it is not possible to receive on a socket after shutdown has been invoked with how set to
	/// SD_RECEIVE or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the receive operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The message was too large to fit into the specified buffer and was truncated.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with
	/// SO_OOBINLINE enabled or (for byte stream sockets only) len was zero or negative.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>The connection has been dropped because of a network failure or because the peer system failed to respond.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket as
	/// it is no longer usable. On a UDP-datagram socket, this error would indicate that a previous send operation resulted in an ICMP
	/// "Port Unreachable" message.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>recv</c> function is used to read incoming data on connection-oriented sockets, or connectionless sockets. When using a
	/// connection-oriented protocol, the sockets must be connected before calling <c>recv</c>. When using a connectionless protocol,
	/// the sockets must be bound before calling <c>recv</c>.
	/// </para>
	/// <para>
	/// The local address of the socket must be known. For server applications, use an explicit bind function or an implicit accept or
	/// WSAAccept function. Explicit binding is discouraged for client applications. For client applications, the socket can become
	/// bound implicitly to a local address using connect, WSAConnect, sendto, WSASendTo, or WSAJoinLeaf.
	/// </para>
	/// <para>
	/// For connected or connectionless sockets, the <c>recv</c> function restricts the addresses from which received messages are
	/// accepted. The function only returns messages from the remote address specified in the connection. Messages from other addresses
	/// are (silently) discarded.
	/// </para>
	/// <para>
	/// For connection-oriented sockets (type SOCK_STREAM for example), calling <c>recv</c> will return as much data as is currently
	/// available—up to the size of the buffer specified. If the socket has been configured for in-line reception of OOB data (socket
	/// option SO_OOBINLINE) and OOB data is yet unread, only OOB data will be returned. The application can use the ioctlsocket or
	/// WSAIoctl <c>SIOCATMARK</c> command to determine whether any more OOB data remains to be read.
	/// </para>
	/// <para>
	/// For connectionless sockets (type SOCK_DGRAM or other message-oriented sockets), data is extracted from the first enqueued
	/// datagram (message) from the destination address specified by the connect function.
	/// </para>
	/// <para>
	/// If the datagram or message is larger than the buffer specified, the buffer is filled with the first part of the datagram, and
	/// <c>recv</c> generates the error WSAEMSGSIZE. For unreliable protocols (for example, UDP) the excess data is lost; for reliable
	/// protocols, the data is retained by the service provider until it is successfully read by calling <c>recv</c> with a large enough buffer.
	/// </para>
	/// <para>
	/// If no incoming data is available at the socket, the <c>recv</c> call blocks and waits for data to arrive according to the
	/// blocking rules defined for WSARecv with the MSG_PARTIAL flag not set unless the socket is nonblocking. In this case, a value of
	/// SOCKET_ERROR is returned with the error code set to WSAEWOULDBLOCK. The select, WSAAsyncSelect, or WSAEventSelect functions can
	/// be used to determine when more data arrives.
	/// </para>
	/// <para>
	/// If the socket is connection oriented and the remote side has shut down the connection gracefully, and all data has been
	/// received, a <c>recv</c> will complete immediately with zero bytes received. If the connection has been reset, a <c>recv</c> will
	/// fail with the error WSAECONNRESET.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
	/// associated socket. The semantics of this function are determined by the socket options and the flags parameter. The possible
	/// value of flags parameter is constructed by using the bitwise OR operator with any of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSG_PEEK</term>
	/// <term>
	/// Peeks at the incoming data. The data is copied into the buffer, but is not removed from the input queue. The function
	/// subsequently returns the amount of data that can be read in a single call to the recv (or recvfrom) function, which may not be
	/// the same as the total amount of data queued on the socket. The amount of data that can actually be read in a single call to the
	/// recv (or recvfrom) function is limited to the data size written in the send or sendto function call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSG_OOB</term>
	/// <term>Processes Out Of Band (OOB) data.</term>
	/// </item>
	/// <item>
	/// <term>MSG_WAITALL</term>
	/// <term>
	/// The receive request will complete only when one of the following events occurs:Note that if the underlying transport does not
	/// support MSG_WAITALL, or if the socket is in a non-blocking mode, then this call will fail with WSAEOPNOTSUPP. Also, if
	/// MSG_WAITALL is specified along with MSG_OOB, MSG_PEEK, or MSG_PARTIAL, then this call will fail with WSAEOPNOTSUPP. This flag is
	/// not supported on datagram sockets or message-oriented sockets.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>recv</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following code example shows the use of the <c>recv</c> function.</para>
	/// <para>Example Code</para>
	/// <para>For more information, and another example of the <c>recv</c> function, see Getting Started With Winsock.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-recv int recv( SOCKET s, char *buf, int len, int flags );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "8c247cd3-479f-45d0-a038-a24e80cc7c73")]
	public static extern int recv(SOCKET s, byte[] buf, int len, MsgFlags flags);

	/// <summary>The <c>recvfrom</c> function receives a datagram and stores the source address.</summary>
	/// <param name="s">A descriptor identifying a bound socket.</param>
	/// <param name="buf">A buffer for the incoming data.</param>
	/// <param name="len">The length, in bytes, of the buffer pointed to by the buf parameter.</param>
	/// <param name="flags">
	/// A set of options that modify the behavior of the function call beyond the options specified for the associated socket. See the
	/// Remarks below for more details.
	/// </param>
	/// <param name="from">An optional pointer to a buffer in a sockaddr structure that will hold the source address upon return.</param>
	/// <param name="fromlen">An optional pointer to the size, in bytes, of the buffer pointed to by the from parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>recvfrom</c> returns the number of bytes received. If the connection has been gracefully closed, the
	/// return value is zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.
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
	/// <term>
	/// The buffer pointed to by the buf or from parameters are not in the user address space, or the fromlen parameter is too small to
	/// accommodate the source address of the peer address.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>The (blocking) call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with
	/// SO_OOBINLINE enabled, or (for byte stream-style sockets only) len was zero or negative.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEISCONN</term>
	/// <term>
	/// The socket is connected. This function is not permitted with a connected socket, whether the socket is connection oriented or connectionless.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>For a datagram socket, this error indicates that the time to live has expired.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor in the s parameter is not a socket.</term>
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
	/// The socket has been shut down; it is not possible to recvfrom on a socket after shutdown has been invoked with how set to
	/// SD_RECEIVE or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the recvfrom operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The message was too large to fit into the buffer pointed to by the buf parameter and was truncated.</term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>
	/// The connection has been dropped, because of a network failure or because the system on the other end went down without notice.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket; it
	/// is no longer usable. On a UDP-datagram socket this error indicates a previous send operation resulted in an ICMP Port
	/// Unreachable message.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>recvfrom</c> function reads incoming data on both connected and unconnected sockets and captures the address from which
	/// the data was sent. This function is typically used with connectionless sockets. The local address of the socket must be known.
	/// For server applications, this is usually done explicitly through bind. Explicit binding is discouraged for client applications.
	/// For client applications using this function, the socket can become bound implicitly to a local address through sendto,
	/// WSASendTo, or WSAJoinLeaf.
	/// </para>
	/// <para>
	/// For stream-oriented sockets such as those of type SOCK_STREAM, a call to <c>recvfrom</c> returns as much information as is
	/// currently available—up to the size of the buffer specified. If the socket has been configured for inline reception of OOB data
	/// (socket option SO_OOBINLINE) and OOB data is yet unread, only OOB data will be returned. The application can use the ioctlsocket
	/// or WSAIoctl <c>SIOCATMARK</c> command to determine whether any more OOB data remains to be read. The from and fromlen parameters
	/// are ignored for connection-oriented sockets.
	/// </para>
	/// <para>
	/// For message-oriented sockets, data is extracted from the first enqueued message, up to the size of the buffer specified. If the
	/// datagram or message is larger than the buffer specified, the buffer is filled with the first part of the datagram, and
	/// <c>recvfrom</c> generates the error WSAEMSGSIZE. For unreliable protocols (for example, UDP) the excess data is lost. For UDP if
	/// the packet received contains no data (empty), the return value from the <c>recvfrom</c> function function is zero.
	/// </para>
	/// <para>
	/// If the from parameter is nonzero and the socket is not connection oriented, (type SOCK_DGRAM for example), the network address
	/// of the peer that sent the data is copied to the corresponding sockaddr structure. The value pointed to by fromlen is initialized
	/// to the size of this structure and is modified, on return, to indicate the actual size of the address stored in the
	/// <c>sockaddr</c> structure.
	/// </para>
	/// <para>
	/// If no incoming data is available at the socket, the <c>recvfrom</c> function blocks and waits for data to arrive according to
	/// the blocking rules defined for WSARecv with the MSG_PARTIAL flag not set unless the socket is nonblocking. In this case, a value
	/// of SOCKET_ERROR is returned with the error code set to WSAEWOULDBLOCK. The select, WSAAsyncSelect, or WSAEventSelect can be used
	/// to determine when more data arrives.
	/// </para>
	/// <para>
	/// If the socket is connection oriented and the remote side has shut down the connection gracefully, the call to <c>recvfrom</c>
	/// will complete immediately with zero bytes received. If the connection has been reset <c>recvfrom</c> will fail with the error WSAECONNRESET.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
	/// associated socket. The semantics of this function are determined by the socket options and the flags parameter. The latter is
	/// constructed by using the bitwise OR operator with any of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSG_PEEK</term>
	/// <term>
	/// Peeks at the incoming data. The data is copied into the buffer but is not removed from the input queue. The function
	/// subsequently returns the amount of data that can be read in a single call to the recvfrom (or recv) function, which may not be
	/// the same as the total amount of data queued on the socket. The amount of data that can actually be read in a single call to the
	/// recvfrom (or recv) function is limited to the data size written in the send or sendto function call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSG_OOB</term>
	/// <term>Processes Out Of Band (OOB) data.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>recvfrom</c>, Winsock may need to wait for a network event before
	/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
	/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
	/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>recvfrom</c> function.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-recvfrom int recvfrom( SOCKET s, char *buf, int len, int
	// flags, sockaddr *from, int *fromlen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "3e4282e0-3ed0-43e7-9b27-72ec36b9cfa1")]
	public static extern int recvfrom(SOCKET s, [Optional] IntPtr buf, [Optional] int len, int flags, SOCKADDR from, ref int fromlen);

	/// <summary>The <c>recvfrom</c> function receives a datagram and stores the source address.</summary>
	/// <param name="s">A descriptor identifying a bound socket.</param>
	/// <param name="buf">A buffer for the incoming data.</param>
	/// <param name="len">The length, in bytes, of the buffer pointed to by the buf parameter.</param>
	/// <param name="flags">
	/// A set of options that modify the behavior of the function call beyond the options specified for the associated socket. See the
	/// Remarks below for more details.
	/// </param>
	/// <param name="from">An optional pointer to a buffer in a sockaddr structure that will hold the source address upon return.</param>
	/// <param name="fromlen">An optional pointer to the size, in bytes, of the buffer pointed to by the from parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>recvfrom</c> returns the number of bytes received. If the connection has been gracefully closed, the
	/// return value is zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.
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
	/// <term>
	/// The buffer pointed to by the buf or from parameters are not in the user address space, or the fromlen parameter is too small to
	/// accommodate the source address of the peer address.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>The (blocking) call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with
	/// SO_OOBINLINE enabled, or (for byte stream-style sockets only) len was zero or negative.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEISCONN</term>
	/// <term>
	/// The socket is connected. This function is not permitted with a connected socket, whether the socket is connection oriented or connectionless.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>For a datagram socket, this error indicates that the time to live has expired.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor in the s parameter is not a socket.</term>
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
	/// The socket has been shut down; it is not possible to recvfrom on a socket after shutdown has been invoked with how set to
	/// SD_RECEIVE or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the recvfrom operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The message was too large to fit into the buffer pointed to by the buf parameter and was truncated.</term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>
	/// The connection has been dropped, because of a network failure or because the system on the other end went down without notice.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket; it
	/// is no longer usable. On a UDP-datagram socket this error indicates a previous send operation resulted in an ICMP Port
	/// Unreachable message.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>recvfrom</c> function reads incoming data on both connected and unconnected sockets and captures the address from which
	/// the data was sent. This function is typically used with connectionless sockets. The local address of the socket must be known.
	/// For server applications, this is usually done explicitly through bind. Explicit binding is discouraged for client applications.
	/// For client applications using this function, the socket can become bound implicitly to a local address through sendto,
	/// WSASendTo, or WSAJoinLeaf.
	/// </para>
	/// <para>
	/// For stream-oriented sockets such as those of type SOCK_STREAM, a call to <c>recvfrom</c> returns as much information as is
	/// currently available—up to the size of the buffer specified. If the socket has been configured for inline reception of OOB data
	/// (socket option SO_OOBINLINE) and OOB data is yet unread, only OOB data will be returned. The application can use the ioctlsocket
	/// or WSAIoctl <c>SIOCATMARK</c> command to determine whether any more OOB data remains to be read. The from and fromlen parameters
	/// are ignored for connection-oriented sockets.
	/// </para>
	/// <para>
	/// For message-oriented sockets, data is extracted from the first enqueued message, up to the size of the buffer specified. If the
	/// datagram or message is larger than the buffer specified, the buffer is filled with the first part of the datagram, and
	/// <c>recvfrom</c> generates the error WSAEMSGSIZE. For unreliable protocols (for example, UDP) the excess data is lost. For UDP if
	/// the packet received contains no data (empty), the return value from the <c>recvfrom</c> function function is zero.
	/// </para>
	/// <para>
	/// If the from parameter is nonzero and the socket is not connection oriented, (type SOCK_DGRAM for example), the network address
	/// of the peer that sent the data is copied to the corresponding sockaddr structure. The value pointed to by fromlen is initialized
	/// to the size of this structure and is modified, on return, to indicate the actual size of the address stored in the
	/// <c>sockaddr</c> structure.
	/// </para>
	/// <para>
	/// If no incoming data is available at the socket, the <c>recvfrom</c> function blocks and waits for data to arrive according to
	/// the blocking rules defined for WSARecv with the MSG_PARTIAL flag not set unless the socket is nonblocking. In this case, a value
	/// of SOCKET_ERROR is returned with the error code set to WSAEWOULDBLOCK. The select, WSAAsyncSelect, or WSAEventSelect can be used
	/// to determine when more data arrives.
	/// </para>
	/// <para>
	/// If the socket is connection oriented and the remote side has shut down the connection gracefully, the call to <c>recvfrom</c>
	/// will complete immediately with zero bytes received. If the connection has been reset <c>recvfrom</c> will fail with the error WSAECONNRESET.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
	/// associated socket. The semantics of this function are determined by the socket options and the flags parameter. The latter is
	/// constructed by using the bitwise OR operator with any of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSG_PEEK</term>
	/// <term>
	/// Peeks at the incoming data. The data is copied into the buffer but is not removed from the input queue. The function
	/// subsequently returns the amount of data that can be read in a single call to the recvfrom (or recv) function, which may not be
	/// the same as the total amount of data queued on the socket. The amount of data that can actually be read in a single call to the
	/// recvfrom (or recv) function is limited to the data size written in the send or sendto function call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>MSG_OOB</term>
	/// <term>Processes Out Of Band (OOB) data.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>recvfrom</c>, Winsock may need to wait for a network event before
	/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
	/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
	/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>recvfrom</c> function.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-recvfrom int recvfrom( SOCKET s, char *buf, int len, int
	// flags, sockaddr *from, int *fromlen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "3e4282e0-3ed0-43e7-9b27-72ec36b9cfa1")]
	public static extern int recvfrom(SOCKET s, [Optional] byte[]? buf, [Optional] int len, int flags, SOCKADDR from, ref int fromlen);

	/// <summary>
	/// The <c>select</c> function determines the status of one or more sockets, waiting if necessary, to perform synchronous I/O.
	/// </summary>
	/// <param name="nfds">Ignored. The nfds parameter is included only for compatibility with Berkeley sockets.</param>
	/// <param name="readfds">An optional pointer to a set of sockets to be checked for readability.</param>
	/// <param name="writefds">An optional pointer to a set of sockets to be checked for writability.</param>
	/// <param name="exceptfds">An optional pointer to a set of sockets to be checked for errors.</param>
	/// <param name="timeout">
	/// The maximum time for <c>select</c> to wait, provided in the form of a TIMEVAL structure. Set the timeout parameter to
	/// <c>null</c> for blocking operations.
	/// </param>
	/// <returns>
	/// <para>
	/// The <c>select</c> function returns the total number of socket handles that are ready and contained in the fd_set structures,
	/// zero if the time limit expired, or SOCKET_ERROR if an error occurred. If the return value is SOCKET_ERROR, WSAGetLastError can
	/// be used to retrieve a specific error code.
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
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The Windows Sockets implementation was unable to allocate needed resources for its internal operations, or the readfds,
	/// writefds, exceptfds, or timeval parameters are not part of the user address space.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The time-out value is not valid, or all three descriptor parameters were null.</term>
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
	/// <term>WSAENOTSOCK</term>
	/// <term>One of the descriptor sets contains an entry that is not a socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>select</c> function is used to determine the status of one or more sockets. For each socket, the caller can request
	/// information on read, write, or error status. The set of sockets for which a given status is requested is indicated by an fd_set
	/// structure. The sockets contained within the <c>fd_set</c> structures must be associated with a single service provider. For the
	/// purpose of this restriction, sockets are considered to be from the same service provider if the WSAPROTOCOL_INFO structures
	/// describing their protocols have the same providerId value. Upon return, the structures are updated to reflect the subset of
	/// these sockets that meet the specified condition. The <c>select</c> function returns the number of sockets meeting the
	/// conditions. A set of macros is provided for manipulating an <c>fd_set</c> structure. These macros are compatible with those used
	/// in the Berkeley software, but the underlying representation is completely different.
	/// </para>
	/// <para>
	/// The parameter readfds identifies the sockets that are to be checked for readability. If the socket is currently in the listen
	/// state, it will be marked as readable if an incoming connection request has been received such that an accept is guaranteed to
	/// complete without blocking. For other sockets, readability means that queued data is available for reading such that a call to
	/// recv, WSARecv, WSARecvFrom, or recvfrom is guaranteed not to block.
	/// </para>
	/// <para>
	/// For connection-oriented sockets, readability can also indicate that a request to close the socket has been received from the
	/// peer. If the virtual circuit was closed gracefully, and all data was received, then a recv will return immediately with zero
	/// bytes read. If the virtual circuit was reset, then a <c>recv</c> will complete immediately with an error code such as
	/// WSAECONNRESET. The presence of OOB data will be checked if the socket option SO_OOBINLINE has been enabled (see setsockopt).
	/// </para>
	/// <para>
	/// The parameter writefds identifies the sockets that are to be checked for writability. If a socket is processing a connect call
	/// (nonblocking), a socket is writeable if the connection establishment successfully completes. If the socket is not processing a
	/// <c>connect</c> call, writability means a send, sendto, or WSASendto are guaranteed to succeed. However, they can block on a
	/// blocking socket if the len parameter exceeds the amount of outgoing system buffer space available. It is not specified how long
	/// these guarantees can be assumed to be valid, particularly in a multithreaded environment.
	/// </para>
	/// <para>
	/// The parameter exceptfds identifies the sockets that are to be checked for the presence of OOB data or any exceptional error conditions.
	/// </para>
	/// <para>
	/// <c>Note</c> Out-of-band data will only be reported in this way if the option SO_OOBINLINE is <c>FALSE</c>. If a socket is
	/// processing a connect call (nonblocking), failure of the connect attempt is indicated in exceptfds (application must then call
	/// getsockopt SO_ERROR to determine the error value to describe why the failure occurred). This document does not define which
	/// other errors will be included.
	/// </para>
	/// <para>
	/// Any two of the parameters, readfds, writefds, or exceptfds, can be given as <c>null</c>. At least one must be non- <c>null</c>,
	/// and any non- <c>null</c> descriptor set must contain at least one handle to a socket.
	/// </para>
	/// <para>In summary, a socket will be identified in a particular set when <c>select</c> returns if:</para>
	/// <para>readfds:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If listen has been called and a connection is pending, accept will succeed.</term>
	/// </item>
	/// <item>
	/// <term>Data is available for reading (includes OOB data if SO_OOBINLINE is enabled).</term>
	/// </item>
	/// <item>
	/// <term>Connection has been closed/reset/terminated.</term>
	/// </item>
	/// </list>
	/// <para>writefds:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If processing a connect call (nonblocking), connection has succeeded.</term>
	/// </item>
	/// <item>
	/// <term>Data can be sent.</term>
	/// </item>
	/// </list>
	/// <para>exceptfds:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If processing a <c>connect</c> call (nonblocking), connection attempt failed.</term>
	/// </item>
	/// <item>
	/// <term>OOB data is available for reading (only if SO_OOBINLINE is disabled).</term>
	/// </item>
	/// </list>
	/// <para>
	/// Four macros are defined in the header file Winsock2.h for manipulating and checking the descriptor sets. The variable FD_SETSIZE
	/// determines the maximum number of descriptors in a set. (The default value of FD_SETSIZE is 64, which can be modified by defining
	/// FD_SETSIZE to another value before including Winsock2.h.) Internally, socket handles in an fd_set structure are not represented
	/// as bit flags as in Berkeley Unix. Their data representation is opaque. Use of these macros will maintain software portability
	/// between different socket environments. The macros to manipulate and check <c>fd_set</c> contents are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>FD_ZERO(*set) - Initializes set to the empty set. A set should always be cleared before using.</term>
	/// </item>
	/// <item>
	/// <term>FD_CLR(s, *set) - Removes socket s from set.</term>
	/// </item>
	/// <item>
	/// <term>FD_ISSET(s, *set) - Checks to see if s is a member of set and returns TRUE if so.</term>
	/// </item>
	/// <item>
	/// <term>FD_SET(s, *set) - Adds socket s to set.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The parameter time-out controls how long the <c>select</c> can take to complete. If time-out is a <c>null</c> pointer,
	/// <c>select</c> will block indefinitely until at least one descriptor meets the specified criteria. Otherwise, time-out points to
	/// a TIMEVAL structure that specifies the maximum time that <c>select</c> should wait before returning. When <c>select</c> returns,
	/// the contents of the <c>TIMEVAL</c> structure are not altered. If <c>TIMEVAL</c> is initialized to {0, 0}, <c>select</c> will
	/// return immediately; this is used to poll the state of the selected sockets. If <c>select</c> returns immediately, then the
	/// <c>select</c> call is considered nonblocking and the standard assumptions for nonblocking calls apply. For example, the blocking
	/// hook will not be called, and Windows Sockets will not yield.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>select</c> function has no effect on the persistence of socket events registered with WSAAsyncSelect or WSAEventSelect.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>select</c> with the timeout parameter set to <c>NULL</c>, Winsock
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
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-select int WSAAPI select( int nfds, fd_set *readfds,
	// fd_set *writefds, fd_set *exceptfds, const timeval *timeout );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "NF:winsock2.select")]
	public static extern WSRESULT select([Optional] int nfds, ref fd_set readfds, ref fd_set writefds, ref fd_set exceptfds, in TIMEVAL timeout);

	/// <summary>
	/// The <c>select</c> function determines the status of one or more sockets, waiting if necessary, to perform synchronous I/O.
	/// </summary>
	/// <param name="nfds">Ignored. The nfds parameter is included only for compatibility with Berkeley sockets.</param>
	/// <param name="readfds">An optional pointer to a set of sockets to be checked for readability.</param>
	/// <param name="writefds">An optional pointer to a set of sockets to be checked for writability.</param>
	/// <param name="exceptfds">An optional pointer to a set of sockets to be checked for errors.</param>
	/// <param name="timeout">
	/// The maximum time for <c>select</c> to wait, provided in the form of a TIMEVAL structure. Set the timeout parameter to
	/// <c>null</c> for blocking operations.
	/// </param>
	/// <returns>
	/// <para>
	/// The <c>select</c> function returns the total number of socket handles that are ready and contained in the fd_set structures,
	/// zero if the time limit expired, or SOCKET_ERROR if an error occurred. If the return value is SOCKET_ERROR, WSAGetLastError can
	/// be used to retrieve a specific error code.
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
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The Windows Sockets implementation was unable to allocate needed resources for its internal operations, or the readfds,
	/// writefds, exceptfds, or timeval parameters are not part of the user address space.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The time-out value is not valid, or all three descriptor parameters were null.</term>
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
	/// <term>WSAENOTSOCK</term>
	/// <term>One of the descriptor sets contains an entry that is not a socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>select</c> function is used to determine the status of one or more sockets. For each socket, the caller can request
	/// information on read, write, or error status. The set of sockets for which a given status is requested is indicated by an fd_set
	/// structure. The sockets contained within the <c>fd_set</c> structures must be associated with a single service provider. For the
	/// purpose of this restriction, sockets are considered to be from the same service provider if the WSAPROTOCOL_INFO structures
	/// describing their protocols have the same providerId value. Upon return, the structures are updated to reflect the subset of
	/// these sockets that meet the specified condition. The <c>select</c> function returns the number of sockets meeting the
	/// conditions. A set of macros is provided for manipulating an <c>fd_set</c> structure. These macros are compatible with those used
	/// in the Berkeley software, but the underlying representation is completely different.
	/// </para>
	/// <para>
	/// The parameter readfds identifies the sockets that are to be checked for readability. If the socket is currently in the listen
	/// state, it will be marked as readable if an incoming connection request has been received such that an accept is guaranteed to
	/// complete without blocking. For other sockets, readability means that queued data is available for reading such that a call to
	/// recv, WSARecv, WSARecvFrom, or recvfrom is guaranteed not to block.
	/// </para>
	/// <para>
	/// For connection-oriented sockets, readability can also indicate that a request to close the socket has been received from the
	/// peer. If the virtual circuit was closed gracefully, and all data was received, then a recv will return immediately with zero
	/// bytes read. If the virtual circuit was reset, then a <c>recv</c> will complete immediately with an error code such as
	/// WSAECONNRESET. The presence of OOB data will be checked if the socket option SO_OOBINLINE has been enabled (see setsockopt).
	/// </para>
	/// <para>
	/// The parameter writefds identifies the sockets that are to be checked for writability. If a socket is processing a connect call
	/// (nonblocking), a socket is writeable if the connection establishment successfully completes. If the socket is not processing a
	/// <c>connect</c> call, writability means a send, sendto, or WSASendto are guaranteed to succeed. However, they can block on a
	/// blocking socket if the len parameter exceeds the amount of outgoing system buffer space available. It is not specified how long
	/// these guarantees can be assumed to be valid, particularly in a multithreaded environment.
	/// </para>
	/// <para>
	/// The parameter exceptfds identifies the sockets that are to be checked for the presence of OOB data or any exceptional error conditions.
	/// </para>
	/// <para>
	/// <c>Note</c> Out-of-band data will only be reported in this way if the option SO_OOBINLINE is <c>FALSE</c>. If a socket is
	/// processing a connect call (nonblocking), failure of the connect attempt is indicated in exceptfds (application must then call
	/// getsockopt SO_ERROR to determine the error value to describe why the failure occurred). This document does not define which
	/// other errors will be included.
	/// </para>
	/// <para>
	/// Any two of the parameters, readfds, writefds, or exceptfds, can be given as <c>null</c>. At least one must be non- <c>null</c>,
	/// and any non- <c>null</c> descriptor set must contain at least one handle to a socket.
	/// </para>
	/// <para>In summary, a socket will be identified in a particular set when <c>select</c> returns if:</para>
	/// <para>readfds:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If listen has been called and a connection is pending, accept will succeed.</term>
	/// </item>
	/// <item>
	/// <term>Data is available for reading (includes OOB data if SO_OOBINLINE is enabled).</term>
	/// </item>
	/// <item>
	/// <term>Connection has been closed/reset/terminated.</term>
	/// </item>
	/// </list>
	/// <para>writefds:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If processing a connect call (nonblocking), connection has succeeded.</term>
	/// </item>
	/// <item>
	/// <term>Data can be sent.</term>
	/// </item>
	/// </list>
	/// <para>exceptfds:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If processing a <c>connect</c> call (nonblocking), connection attempt failed.</term>
	/// </item>
	/// <item>
	/// <term>OOB data is available for reading (only if SO_OOBINLINE is disabled).</term>
	/// </item>
	/// </list>
	/// <para>
	/// Four macros are defined in the header file Winsock2.h for manipulating and checking the descriptor sets. The variable FD_SETSIZE
	/// determines the maximum number of descriptors in a set. (The default value of FD_SETSIZE is 64, which can be modified by defining
	/// FD_SETSIZE to another value before including Winsock2.h.) Internally, socket handles in an fd_set structure are not represented
	/// as bit flags as in Berkeley Unix. Their data representation is opaque. Use of these macros will maintain software portability
	/// between different socket environments. The macros to manipulate and check <c>fd_set</c> contents are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>FD_ZERO(*set) - Initializes set to the empty set. A set should always be cleared before using.</term>
	/// </item>
	/// <item>
	/// <term>FD_CLR(s, *set) - Removes socket s from set.</term>
	/// </item>
	/// <item>
	/// <term>FD_ISSET(s, *set) - Checks to see if s is a member of set and returns TRUE if so.</term>
	/// </item>
	/// <item>
	/// <term>FD_SET(s, *set) - Adds socket s to set.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The parameter time-out controls how long the <c>select</c> can take to complete. If time-out is a <c>null</c> pointer,
	/// <c>select</c> will block indefinitely until at least one descriptor meets the specified criteria. Otherwise, time-out points to
	/// a TIMEVAL structure that specifies the maximum time that <c>select</c> should wait before returning. When <c>select</c> returns,
	/// the contents of the <c>TIMEVAL</c> structure are not altered. If <c>TIMEVAL</c> is initialized to {0, 0}, <c>select</c> will
	/// return immediately; this is used to poll the state of the selected sockets. If <c>select</c> returns immediately, then the
	/// <c>select</c> call is considered nonblocking and the standard assumptions for nonblocking calls apply. For example, the blocking
	/// hook will not be called, and Windows Sockets will not yield.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>select</c> function has no effect on the persistence of socket events registered with WSAAsyncSelect or WSAEventSelect.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>select</c> with the timeout parameter set to <c>NULL</c>, Winsock
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
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-select int WSAAPI select( int nfds, fd_set *readfds,
	// fd_set *writefds, fd_set *exceptfds, const timeval *timeout );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "NF:winsock2.select")]
	public static extern WSRESULT select([Optional] int nfds, [In, Out, Optional] IntPtr readfds, [In, Out, Optional] IntPtr writefds, [In, Out, Optional] IntPtr exceptfds, [In, Optional] IntPtr timeout);

	/// <summary>The <c>send</c> function sends data on a connected socket.</summary>
	/// <param name="s">A descriptor identifying a connected socket.</param>
	/// <param name="buf">A pointer to a buffer containing the data to be transmitted.</param>
	/// <param name="len">The length, in bytes, of the data in buffer pointed to by the buf parameter.</param>
	/// <param name="flags">
	/// <para>
	/// A set of flags that specify the way in which the call is made. This parameter is constructed by using the bitwise OR operator
	/// with any of the following values.
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
	/// <term>Sends OOB data (stream-style socket such as SOCK_STREAM only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>send</c> returns the total number of bytes sent, which can be less than the number requested to be sent
	/// in the len parameter. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAEACCES</term>
	/// <term>
	/// The requested address is a broadcast address, but the appropriate flag was not set. Call setsockopt with the SO_BROADCAST socket
	/// option to enable use of the broadcast address.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Sockets 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The buf parameter is not completely contained in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>The connection has been broken due to the keep-alive activity detecting a failure while the operation was in progress.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>No buffer space is available.</term>
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
	/// communication domain associated with this socket, or the socket is unidirectional and supports only receive operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAESHUTDOWN</term>
	/// <term>
	/// The socket has been shut down; it is not possible to send on a socket after shutdown has been invoked with how set to SD_SEND or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the requested operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
	/// </item>
	/// <item>
	/// <term>WSAEHOSTUNREACH</term>
	/// <term>The remote host cannot be reached from this host at this time.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with
	/// SO_OOBINLINE enabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. For UDP sockets, the remote host was unable
	/// to deliver a previously sent UDP datagram and responded with a "Port Unreachable" ICMP packet. The application should close the
	/// socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>
	/// The connection has been dropped, because of a network failure or because the system on the other end went down without notice.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>send</c> function is used to write outgoing data on a connected socket.</para>
	/// <para>
	/// For message-oriented sockets (address family of <c>AF_INET</c> or <c>AF_INET6</c>, type of <c>SOCK_DGRAM</c>, and protocol of
	/// <c>IPPROTO_UDP</c>, for example), care must be taken not to exceed the maximum packet size of the underlying provider. The
	/// maximum message packet size for a provider can be obtained by calling getsockopt with the optname parameter set to
	/// <c>SO_MAX_MSG_SIZE</c> to retrieve the value of socket option. If the data is too long to pass atomically through the underlying
	/// protocol, the error WSAEMSGSIZE is returned, and no data is transmitted.
	/// </para>
	/// <para>
	/// The successful completion of a <c>send</c> function does not indicate that the data was successfully delivered and received to
	/// the recipient. This function only indicates the data was successfully sent.
	/// </para>
	/// <para>
	/// If no buffer space is available within the transport system to hold the data to be transmitted, <c>send</c> will block unless
	/// the socket has been placed in nonblocking mode. On nonblocking stream oriented sockets, the number of bytes written can be
	/// between 1 and the requested length, depending on buffer availability on both the client and server computers. The select,
	/// WSAAsyncSelect or WSAEventSelect functions can be used to determine when it is possible to send more data.
	/// </para>
	/// <para>
	/// Calling <c>send</c> with a len parameter of zero is permissible and will be treated by implementations as successful. In such
	/// cases, <c>send</c> will return zero as a valid value. For message-oriented sockets, a zero-length transport datagram is sent.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function beyond the options specified for the associated
	/// socket. The semantics of the <c>send</c> function are determined by any options previously set on the socket specified in the s
	/// parameter and the flags parameter passed to the <c>send</c> function.
	/// </para>
	/// <para>
	/// The order of calls made to <c>send</c> is also the order in which the buffers are transmitted to the transport layer.
	/// <c>send</c> should not be called on the same stream-oriented socket concurrently from different threads, because some Winsock
	/// providers may split a large send request into multiple transmissions, and this may lead to unintended data interleaving from
	/// multiple concurrent send requests on the same stream-oriented socket.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>send</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>send</c> function.</para>
	/// <para>Example Code</para>
	/// <para>For a another example that uses the <c>send</c> function, see Getting Started With Winsock.</para>
	/// <para>Notes for IrDA Sockets</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// </list>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-send int WSAAPI send( SOCKET s, const char *buf, int len,
	// int flags );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "902bb9cf-d847-43fc-8282-394d619b8f1b")]
	public static extern int send(SOCKET s, IntPtr buf, int len, int flags);

	/// <summary>The <c>send</c> function sends data on a connected socket.</summary>
	/// <param name="s">A descriptor identifying a connected socket.</param>
	/// <param name="buf">A pointer to a buffer containing the data to be transmitted.</param>
	/// <param name="len">The length, in bytes, of the data in buffer pointed to by the buf parameter.</param>
	/// <param name="flags">
	/// <para>
	/// A set of flags that specify the way in which the call is made. This parameter is constructed by using the bitwise OR operator
	/// with any of the following values.
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
	/// <term>Sends OOB data (stream-style socket such as SOCK_STREAM only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>send</c> returns the total number of bytes sent, which can be less than the number requested to be sent
	/// in the len parameter. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAEACCES</term>
	/// <term>
	/// The requested address is a broadcast address, but the appropriate flag was not set. Call setsockopt with the SO_BROADCAST socket
	/// option to enable use of the broadcast address.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Sockets 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The buf parameter is not completely contained in a valid part of the user address space.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>The connection has been broken due to the keep-alive activity detecting a failure while the operation was in progress.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>No buffer space is available.</term>
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
	/// communication domain associated with this socket, or the socket is unidirectional and supports only receive operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAESHUTDOWN</term>
	/// <term>
	/// The socket has been shut down; it is not possible to send on a socket after shutdown has been invoked with how set to SD_SEND or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the requested operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
	/// </item>
	/// <item>
	/// <term>WSAEHOSTUNREACH</term>
	/// <term>The remote host cannot be reached from this host at this time.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The socket has not been bound with bind, or an unknown flag was specified, or MSG_OOB was specified for a socket with
	/// SO_OOBINLINE enabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. For UDP sockets, the remote host was unable
	/// to deliver a previously sent UDP datagram and responded with a "Port Unreachable" ICMP packet. The application should close the
	/// socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAETIMEDOUT</term>
	/// <term>
	/// The connection has been dropped, because of a network failure or because the system on the other end went down without notice.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>send</c> function is used to write outgoing data on a connected socket.</para>
	/// <para>
	/// For message-oriented sockets (address family of <c>AF_INET</c> or <c>AF_INET6</c>, type of <c>SOCK_DGRAM</c>, and protocol of
	/// <c>IPPROTO_UDP</c>, for example), care must be taken not to exceed the maximum packet size of the underlying provider. The
	/// maximum message packet size for a provider can be obtained by calling getsockopt with the optname parameter set to
	/// <c>SO_MAX_MSG_SIZE</c> to retrieve the value of socket option. If the data is too long to pass atomically through the underlying
	/// protocol, the error WSAEMSGSIZE is returned, and no data is transmitted.
	/// </para>
	/// <para>
	/// The successful completion of a <c>send</c> function does not indicate that the data was successfully delivered and received to
	/// the recipient. This function only indicates the data was successfully sent.
	/// </para>
	/// <para>
	/// If no buffer space is available within the transport system to hold the data to be transmitted, <c>send</c> will block unless
	/// the socket has been placed in nonblocking mode. On nonblocking stream oriented sockets, the number of bytes written can be
	/// between 1 and the requested length, depending on buffer availability on both the client and server computers. The select,
	/// WSAAsyncSelect or WSAEventSelect functions can be used to determine when it is possible to send more data.
	/// </para>
	/// <para>
	/// Calling <c>send</c> with a len parameter of zero is permissible and will be treated by implementations as successful. In such
	/// cases, <c>send</c> will return zero as a valid value. For message-oriented sockets, a zero-length transport datagram is sent.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function beyond the options specified for the associated
	/// socket. The semantics of the <c>send</c> function are determined by any options previously set on the socket specified in the s
	/// parameter and the flags parameter passed to the <c>send</c> function.
	/// </para>
	/// <para>
	/// The order of calls made to <c>send</c> is also the order in which the buffers are transmitted to the transport layer.
	/// <c>send</c> should not be called on the same stream-oriented socket concurrently from different threads, because some Winsock
	/// providers may split a large send request into multiple transmissions, and this may lead to unintended data interleaving from
	/// multiple concurrent send requests on the same stream-oriented socket.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>send</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>send</c> function.</para>
	/// <para>Example Code</para>
	/// <para>For a another example that uses the <c>send</c> function, see Getting Started With Winsock.</para>
	/// <para>Notes for IrDA Sockets</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// </list>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/nf-winsock2-send int WSAAPI send( SOCKET s, const char *buf, int len,
	// int flags );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock2.h", MSDNShortId = "902bb9cf-d847-43fc-8282-394d619b8f1b")]
	public static extern int send(SOCKET s, byte[] buf, int len, int flags);

	/// <summary>The <c>sendto</c> function sends data to a specific destination.</summary>
	/// <param name="s">A descriptor identifying a (possibly connected) socket.</param>
	/// <param name="buf">A pointer to a buffer containing the data to be transmitted.</param>
	/// <param name="len">The length, in bytes, of the data pointed to by the buf parameter.</param>
	/// <param name="flags">A set of flags that specify the way in which the call is made.</param>
	/// <param name="to">An optional pointer to a sockaddr structure that contains the address of the target socket.</param>
	/// <param name="tolen">The size, in bytes, of the address pointed to by the to parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>sendto</c> returns the total number of bytes sent, which can be less than the number indicated by len.
	/// Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAEACCES</term>
	/// <term>
	/// The requested address is a broadcast address, but the appropriate flag was not set. Call setsockopt with the SO_BROADCAST
	/// parameter to allow the use of the broadcast address.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>An unknown flag was specified, or MSG_OOB was specified for a socket with SO_OOBINLINE enabled.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Sockets 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The buf or to parameters are not part of the user address space, or the tolen parameter is too small.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>No buffer space is available.</term>
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
	/// <term>WSAEOPNOTSUPP</term>
	/// <term>
	/// MSG_OOB was specified, but the socket is not stream-style such as type SOCK_STREAM, OOB data is not supported in the
	/// communication domain associated with this socket, or the socket is unidirectional and supports only receive operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAESHUTDOWN</term>
	/// <term>
	/// The socket has been shut down; it is not possible to sendto on a socket after shutdown has been invoked with how set to SD_SEND
	/// or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the requested operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
	/// </item>
	/// <item>
	/// <term>WSAEHOSTUNREACH</term>
	/// <term>The remote host cannot be reached from this host at this time.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. For UPD sockets, the remote host was unable
	/// to deliver a previously sent UDP datagram and responded with a "Port Unreachable" ICMP packet. The application should close the
	/// socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEADDRNOTAVAIL</term>
	/// <term>The remote address is not a valid address, for example, ADDR_ANY.</term>
	/// </item>
	/// <item>
	/// <term>WSAEAFNOSUPPORT</term>
	/// <term>Addresses in the specified family cannot be used with this socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAEDESTADDRREQ</term>
	/// <term>A destination address is required.</term>
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
	/// <term>WSAETIMEDOUT</term>
	/// <term>
	/// The connection has been dropped, because of a network failure or because the system on the other end went down without notice.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>sendto</c> function is used to write outgoing data on a socket. For message-oriented sockets, care must be taken not to
	/// exceed the maximum packet size of the underlying subnets, which can be obtained by using getsockopt to retrieve the value of
	/// socket option SO_MAX_MSG_SIZE. If the data is too long to pass atomically through the underlying protocol, the error WSAEMSGSIZE
	/// is returned and no data is transmitted.
	/// </para>
	/// <para>
	/// The to parameter can be any valid address in the socket's address family, including a broadcast or any multicast address. To
	/// send to a broadcast address, an application must have used setsockopt with SO_BROADCAST enabled. Otherwise, <c>sendto</c> will
	/// fail with the error code WSAEACCES. For TCP/IP, an application can send to any multicast address (without becoming a group member).
	/// </para>
	/// <para>
	/// <c>Note</c> If a socket is opened, a setsockopt call is made, and then a <c>sendto</c> call is made, Windows Sockets performs an
	/// implicit <c>bind</c> function call.
	/// </para>
	/// <para>
	/// If the socket is unbound, unique values are assigned to the local association by the system, and the socket is then marked as
	/// bound. If the socket is connected, the getsockname function can be used to determine the local IP address and port associated
	/// with the socket.
	/// </para>
	/// <para>
	/// If the socket is not connected, the getsockname function can be used to determine the local port number associated with the
	/// socket but the IP address returned is set to the wildcard address for the given protocol (for example, INADDR_ANY or "0.0.0.0"
	/// for IPv4 and IN6ADDR_ANY_INIT or "::" for IPv6).
	/// </para>
	/// <para>The successful completion of a <c>sendto</c> does not indicate that the data was successfully delivered.</para>
	/// <para>
	/// The <c>sendto</c> function is normally used on a connectionless socket to send a datagram to a specific peer socket identified
	/// by the to parameter. Even if the connectionless socket has been previously connected to a specific address, the to parameter
	/// overrides the destination address for that particular datagram only. On a connection-oriented socket, the to and tolen
	/// parameters are ignored, making <c>sendto</c> equivalent to send.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>sendto</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>sendto</c> function.</para>
	/// <para>For Sockets Using IP (Version 4)</para>
	/// <para>
	/// To send a broadcast (on a SOCK_DGRAM only), the address pointed to by the to parameter can be constructed to contain the special
	/// IPv4 address INADDR_BROADCAST (defined in Winsock2.h), together with the intended port number. If the address pointed to by the
	/// to parameter contains the INADDR_BROADCAST address and intended port, then the broadcast will be sent out on all interfaces to
	/// that port.
	/// </para>
	/// <para>
	/// If the broadcast should be sent out only on a specific interface, then the address pointed to by the to parameter should contain
	/// the subnet broadcast address for the interface and the intended port. For example, an IPv4 network address of 192.168.1.0 with a
	/// subnet mask of 255.255.255.0 would use a subnet broadcast address of 192.168.1.255.
	/// </para>
	/// <para>
	/// It is generally inadvisable for a broadcast datagram to exceed the size at which fragmentation can occur, which implies that the
	/// data portion of the datagram (excluding headers) should not exceed 512 bytes.
	/// </para>
	/// <para>
	/// If no buffer space is available within the transport system to hold the data to be transmitted, <c>sendto</c> will block unless
	/// the socket has been placed in a nonblocking mode. On nonblocking, stream oriented sockets, the number of bytes written can be
	/// between 1 and the requested length, depending on buffer availability on both the client and server systems. The select,
	/// WSAAsyncSelect or WSAEventSelect function can be used to determine when it is possible to send more data.
	/// </para>
	/// <para>
	/// Calling <c>sendto</c> with a len of zero is permissible and will return zero as a valid value. For message-oriented sockets, a
	/// zero-length transport datagram is sent.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
	/// associated socket. The semantics of this function are determined by the socket options and the flags parameter. The latter is
	/// constructed by using the bitwise OR operator with any of the following values.
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
	/// <term>Sends OOB data (stream-style socket such as SOCK_STREAM only).</term>
	/// </item>
	/// </list>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-sendto int sendto( SOCKET s, const char *buf, int len, int
	// flags, const sockaddr *to, int tolen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "a1c89c6b-d11d-4d3e-a664-af2beed0cd09")]
	public static extern int sendto(SOCKET s, IntPtr buf, int len, int flags, SOCKADDR to, int tolen);

	/// <summary>The <c>sendto</c> function sends data to a specific destination.</summary>
	/// <param name="s">A descriptor identifying a (possibly connected) socket.</param>
	/// <param name="buf">A pointer to a buffer containing the data to be transmitted.</param>
	/// <param name="len">The length, in bytes, of the data pointed to by the buf parameter.</param>
	/// <param name="flags">A set of flags that specify the way in which the call is made.</param>
	/// <param name="to">An optional pointer to a sockaddr structure that contains the address of the target socket.</param>
	/// <param name="tolen">The size, in bytes, of the address pointed to by the to parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>sendto</c> returns the total number of bytes sent, which can be less than the number indicated by len.
	/// Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can be retrieved by calling WSAGetLastError.
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
	/// <term>WSAEACCES</term>
	/// <term>
	/// The requested address is a broadcast address, but the appropriate flag was not set. Call setsockopt with the SO_BROADCAST
	/// parameter to allow the use of the broadcast address.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>An unknown flag was specified, or MSG_OOB was specified for a socket with SO_OOBINLINE enabled.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINTR</term>
	/// <term>A blocking Windows Sockets 1.1 call was canceled through WSACancelBlockingCall.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEFAULT</term>
	/// <term>The buf or to parameters are not part of the user address space, or the tolen parameter is too small.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOBUFS</term>
	/// <term>No buffer space is available.</term>
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
	/// <term>WSAEOPNOTSUPP</term>
	/// <term>
	/// MSG_OOB was specified, but the socket is not stream-style such as type SOCK_STREAM, OOB data is not supported in the
	/// communication domain associated with this socket, or the socket is unidirectional and supports only receive operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAESHUTDOWN</term>
	/// <term>
	/// The socket has been shut down; it is not possible to sendto on a socket after shutdown has been invoked with how set to SD_SEND
	/// or SD_BOTH.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEWOULDBLOCK</term>
	/// <term>The socket is marked as nonblocking and the requested operation would block.</term>
	/// </item>
	/// <item>
	/// <term>WSAEMSGSIZE</term>
	/// <term>The socket is message oriented, and the message is larger than the maximum supported by the underlying transport.</term>
	/// </item>
	/// <item>
	/// <term>WSAEHOSTUNREACH</term>
	/// <term>The remote host cannot be reached from this host at this time.</term>
	/// </item>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. For UPD sockets, the remote host was unable
	/// to deliver a previously sent UDP datagram and responded with a "Port Unreachable" ICMP packet. The application should close the
	/// socket as it is no longer usable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEADDRNOTAVAIL</term>
	/// <term>The remote address is not a valid address, for example, ADDR_ANY.</term>
	/// </item>
	/// <item>
	/// <term>WSAEAFNOSUPPORT</term>
	/// <term>Addresses in the specified family cannot be used with this socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAEDESTADDRREQ</term>
	/// <term>A destination address is required.</term>
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
	/// <term>WSAETIMEDOUT</term>
	/// <term>
	/// The connection has been dropped, because of a network failure or because the system on the other end went down without notice.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>sendto</c> function is used to write outgoing data on a socket. For message-oriented sockets, care must be taken not to
	/// exceed the maximum packet size of the underlying subnets, which can be obtained by using getsockopt to retrieve the value of
	/// socket option SO_MAX_MSG_SIZE. If the data is too long to pass atomically through the underlying protocol, the error WSAEMSGSIZE
	/// is returned and no data is transmitted.
	/// </para>
	/// <para>
	/// The to parameter can be any valid address in the socket's address family, including a broadcast or any multicast address. To
	/// send to a broadcast address, an application must have used setsockopt with SO_BROADCAST enabled. Otherwise, <c>sendto</c> will
	/// fail with the error code WSAEACCES. For TCP/IP, an application can send to any multicast address (without becoming a group member).
	/// </para>
	/// <para>
	/// <c>Note</c> If a socket is opened, a setsockopt call is made, and then a <c>sendto</c> call is made, Windows Sockets performs an
	/// implicit <c>bind</c> function call.
	/// </para>
	/// <para>
	/// If the socket is unbound, unique values are assigned to the local association by the system, and the socket is then marked as
	/// bound. If the socket is connected, the getsockname function can be used to determine the local IP address and port associated
	/// with the socket.
	/// </para>
	/// <para>
	/// If the socket is not connected, the getsockname function can be used to determine the local port number associated with the
	/// socket but the IP address returned is set to the wildcard address for the given protocol (for example, INADDR_ANY or "0.0.0.0"
	/// for IPv4 and IN6ADDR_ANY_INIT or "::" for IPv6).
	/// </para>
	/// <para>The successful completion of a <c>sendto</c> does not indicate that the data was successfully delivered.</para>
	/// <para>
	/// The <c>sendto</c> function is normally used on a connectionless socket to send a datagram to a specific peer socket identified
	/// by the to parameter. Even if the connectionless socket has been previously connected to a specific address, the to parameter
	/// overrides the destination address for that particular datagram only. On a connection-oriented socket, the to and tolen
	/// parameters are ignored, making <c>sendto</c> equivalent to send.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>sendto</c>, Winsock may need to wait for a network event before the
	/// call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous procedure
	/// call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an ongoing
	/// blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the use of the <c>sendto</c> function.</para>
	/// <para>For Sockets Using IP (Version 4)</para>
	/// <para>
	/// To send a broadcast (on a SOCK_DGRAM only), the address pointed to by the to parameter can be constructed to contain the special
	/// IPv4 address INADDR_BROADCAST (defined in Winsock2.h), together with the intended port number. If the address pointed to by the
	/// to parameter contains the INADDR_BROADCAST address and intended port, then the broadcast will be sent out on all interfaces to
	/// that port.
	/// </para>
	/// <para>
	/// If the broadcast should be sent out only on a specific interface, then the address pointed to by the to parameter should contain
	/// the subnet broadcast address for the interface and the intended port. For example, an IPv4 network address of 192.168.1.0 with a
	/// subnet mask of 255.255.255.0 would use a subnet broadcast address of 192.168.1.255.
	/// </para>
	/// <para>
	/// It is generally inadvisable for a broadcast datagram to exceed the size at which fragmentation can occur, which implies that the
	/// data portion of the datagram (excluding headers) should not exceed 512 bytes.
	/// </para>
	/// <para>
	/// If no buffer space is available within the transport system to hold the data to be transmitted, <c>sendto</c> will block unless
	/// the socket has been placed in a nonblocking mode. On nonblocking, stream oriented sockets, the number of bytes written can be
	/// between 1 and the requested length, depending on buffer availability on both the client and server systems. The select,
	/// WSAAsyncSelect or WSAEventSelect function can be used to determine when it is possible to send more data.
	/// </para>
	/// <para>
	/// Calling <c>sendto</c> with a len of zero is permissible and will return zero as a valid value. For message-oriented sockets, a
	/// zero-length transport datagram is sent.
	/// </para>
	/// <para>
	/// The flags parameter can be used to influence the behavior of the function invocation beyond the options specified for the
	/// associated socket. The semantics of this function are determined by the socket options and the flags parameter. The latter is
	/// constructed by using the bitwise OR operator with any of the following values.
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
	/// <term>Sends OOB data (stream-style socket such as SOCK_STREAM only).</term>
	/// </item>
	/// </list>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-sendto int sendto( SOCKET s, const char *buf, int len, int
	// flags, const sockaddr *to, int tolen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "a1c89c6b-d11d-4d3e-a664-af2beed0cd09")]
	public static extern int sendto(SOCKET s, byte[] buf, int len, int flags, SOCKADDR to, int tolen);

	/// <summary>The <c>setsockopt</c> function sets a socket option.</summary>
	/// <param name="s">A descriptor that identifies a socket.</param>
	/// <param name="level">The level at which the option is defined (for example, SOL_SOCKET).</param>
	/// <param name="optname">
	/// The socket option for which the value is to be set (for example, SO_BROADCAST). The optname parameter must be a socket option
	/// defined within the specified level, or behavior is undefined.
	/// </param>
	/// <param name="optval">A pointer to the buffer in which the value for the requested option is specified.</param>
	/// <param name="optlen">The size, in bytes, of the buffer pointed to by the optval parameter.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>setsockopt</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code
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
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The buffer pointed to by the optval parameter is not in a valid part of the process address space or the optlen parameter is too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The level parameter is not valid, or the information in the buffer pointed to by the optval parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>The connection has timed out when SO_KEEPALIVE is set.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOPROTOOPT</term>
	/// <term>The option is unknown or unsupported for the specified provider or socket (see SO_GROUP_PRIORITY limitations).</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTCONN</term>
	/// <term>The connection has been reset when SO_KEEPALIVE is set.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor is not a socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>setsockopt</c> function sets the current value for a socket option associated with a socket of any type, in any state.
	/// Although options can exist at multiple protocol levels, they are always present at the uppermost socket level. Options affect
	/// socket operations, such as whether expedited data (OOB data for example) is received in the normal data stream, and whether
	/// broadcast messages can be sent on the socket.
	/// </para>
	/// <para>
	/// <c>Note</c> If the <c>setsockopt</c> function is called before the bind function, TCP/IP options will not be checked by using
	/// TCP/IP until the <c>bind</c> occurs. In this case, the <c>setsockopt</c> function call will always succeed, but the <c>bind</c>
	/// function call can fail because of an early <c>setsockopt</c> call failing.
	/// </para>
	/// <para>
	/// <c>Note</c> If a socket is opened, a <c>setsockopt</c> call is made, and then a sendto call is made, Windows Sockets performs an
	/// implicit bind function call.
	/// </para>
	/// <para>
	/// There are two types of socket options: Boolean options that enable or disable a feature or behavior, and options that require an
	/// integer value or structure. To enable a Boolean option, the optval parameter points to a nonzero integer. To disable the option
	/// optval points to an integer equal to zero. The optlen parameter should be equal to for Boolean options. For other options,
	/// optval points to an integer or structure that contains the desired value for the option, and optlen is the length of the integer
	/// or structure.
	/// </para>
	/// <para>
	/// The following tables list some of the common options supported by the <c>setsockopt</c> function. The Type column identifies the
	/// type of data addressed by optval parameter. The Description column provides some basic information about the socket option. For
	/// more complete lists of socket options and more detailed information (default values, for example), see the detailed topics under
	/// Socket Options.
	/// </para>
	/// <para>level = <c>SOL_SOCKET</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>SO_BROADCAST</term>
	/// <term>BOOL</term>
	/// <term>Configures a socket for sending broadcast data.</term>
	/// </item>
	/// <item>
	/// <term>SO_CONDITIONAL_ACCEPT</term>
	/// <term>BOOL</term>
	/// <term>Enables incoming connections are to be accepted or rejected by the application, not by the protocol stack.</term>
	/// </item>
	/// <item>
	/// <term>SO_DEBUG</term>
	/// <term>BOOL</term>
	/// <term>Enables debug output. Microsoft providers currently do not output any debug information.</term>
	/// </item>
	/// <item>
	/// <term>SO_DONTLINGER</term>
	/// <term>BOOL</term>
	/// <term>
	/// Does not block close waiting for unsent data to be sent. Setting this option is equivalent to setting SO_LINGER with l_onoff set
	/// to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_DONTROUTE</term>
	/// <term>BOOL</term>
	/// <term>
	/// Sets whether outgoing data should be sent on interface the socket is bound to and not a routed on some other interface. This
	/// option is not supported on ATM sockets (results in an error).
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_GROUP_PRIORITY</term>
	/// <term>int</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SO_KEEPALIVE</term>
	/// <term>BOOL</term>
	/// <term>Enables sending keep-alive packets for a socket connection. Not supported on ATM sockets (results in an error).</term>
	/// </item>
	/// <item>
	/// <term>SO_LINGER</term>
	/// <term>LINGER</term>
	/// <term>Lingers on close if unsent data is present.</term>
	/// </item>
	/// <item>
	/// <term>SO_OOBINLINE</term>
	/// <term>BOOL</term>
	/// <term>
	/// Indicates that out-of-bound data should be returned in-line with regular data. This option is only valid for connection-oriented
	/// protocols that support out-of-band data. For a discussion of this topic, see Protocol Independent Out-Of-band Data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_RCVBUF</term>
	/// <term>int</term>
	/// <term>Specifies the total per-socket buffer space reserved for receives.</term>
	/// </item>
	/// <item>
	/// <term>SO_REUSEADDR</term>
	/// <term>BOOL</term>
	/// <term>
	/// Allows the socket to be bound to an address that is already in use. For more information, see bind. Not applicable on ATM sockets.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_EXCLUSIVEADDRUSE</term>
	/// <term>BOOL</term>
	/// <term>Enables a socket to be bound for exclusive access. Does not require administrative privilege.</term>
	/// </item>
	/// <item>
	/// <term>SO_RCVTIMEO</term>
	/// <term>DWORD</term>
	/// <term>Sets the timeout, in milliseconds, for blocking receive calls.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDBUF</term>
	/// <term>int</term>
	/// <term>Specifies the total per-socket buffer space reserved for sends.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDTIMEO</term>
	/// <term>DWORD</term>
	/// <term>The timeout, in milliseconds, for blocking send calls.</term>
	/// </item>
	/// <item>
	/// <term>SO_UPDATE_ACCEPT_CONTEXT</term>
	/// <term>int</term>
	/// <term>Updates the accepting socket with the context of the listening socket.</term>
	/// </item>
	/// <item>
	/// <term>PVD_CONFIG</term>
	/// <term>Service Provider Dependent</term>
	/// <term>
	/// This object stores the configuration information for the service provider associated with socket s. The exact format of this
	/// data structure is service provider specific.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For more complete and detailed information about socket options for level = <c>SOL_SOCKET</c>, see SOL_SOCKET Socket Options.</para>
	/// <para>level = <c>IPPROTO_TCP</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TCP_NODELAY</term>
	/// <term>BOOL</term>
	/// <term>
	/// Disables the Nagle algorithm for send coalescing.This socket option is included for backward compatibility with Windows Sockets 1.1
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// For more complete and detailed information about socket options for level = <c>IPPROTO_TCP</c>, see IPPROTO_TCP Socket Options.
	/// </para>
	/// <para>level = <c>NSPROTO_IPX</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IPX_PTYPE</term>
	/// <term>int</term>
	/// <term>Sets the IPX packet type.</term>
	/// </item>
	/// <item>
	/// <term>IPX_FILTERPTYPE</term>
	/// <term>int</term>
	/// <term>Sets the receive filter packet type</term>
	/// </item>
	/// <item>
	/// <term>IPX_STOPFILTERPTYPE</term>
	/// <term>int</term>
	/// <term>Stops filtering the filter type set with IPX_FILTERTYPE</term>
	/// </item>
	/// <item>
	/// <term>IPX_DSTYPE</term>
	/// <term>int</term>
	/// <term>Sets the value of the data stream field in the SPX header on every packet sent.</term>
	/// </item>
	/// <item>
	/// <term>IPX_EXTENDED_ADDRESS</term>
	/// <term>BOOL</term>
	/// <term>Sets whether extended addressing is enabled.</term>
	/// </item>
	/// <item>
	/// <term>IPX_RECVHDR</term>
	/// <term>BOOL</term>
	/// <term>Sets whether the protocol header is sent up on all receive headers.</term>
	/// </item>
	/// <item>
	/// <term>IPX_RECEIVE_BROADCAST</term>
	/// <term>BOOL</term>
	/// <term>
	/// Indicates broadcast packets are likely on the socket. Set to TRUE by default. Applications that do not use broadcasts should set
	/// this to FALSE for better system performance.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPX_IMMEDIATESPXACK</term>
	/// <term>BOOL</term>
	/// <term>
	/// Directs SPX connections not to delay before sending an ACK. Applications without back-and-forth traffic should set this to TRUE
	/// to increase performance.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// For more complete and detailed information about socket options for level = <c>NSPROTO_IPX</c>, see NSPROTO_IPX Socket Options.
	/// </para>
	/// <para>BSD options not supported for <c>setsockopt</c> are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>SO_ACCEPTCONN</term>
	/// <term>BOOL</term>
	/// <term>
	/// Returns whether a socket is in listening mode. This option is only Valid for connection-oriented protocols. This socket option
	/// is not supported for the setting.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_RCVLOWAT</term>
	/// <term>int</term>
	/// <term>
	/// A socket option from BSD UNIX included for backward compatibility. This option sets the minimum number of bytes to process for
	/// socket input operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_SNDLOWAT</term>
	/// <term>int</term>
	/// <term>
	/// A socket option from BSD UNIX included for backward compatibility. This option sets the minimum number of bytes to process for
	/// socket output operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_TYPE</term>
	/// <term>int</term>
	/// <term>
	/// Returns the socket type for the given socket (SOCK_STREAM or SOCK_DGRAM, for example This socket option is not supported for the
	/// setting the socket type.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>setsockopt</c>, Winsock may need to wait for a network event before
	/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
	/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
	/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the <c>setsockopt</c> function.</para>
	/// <para>Notes for IrDA Sockets</para>
	/// <para>When developing applications using Windows sockets for IrDA, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// <item>
	/// <term>IrDA provides the following socket option:</term>
	/// </item>
	/// </list>
	/// <para>
	/// The IRLMP_IAS_SET socket option enables the application to set a single attribute of a single class in the local IAS. The
	/// application specifies the class to set, the attribute, and attribute type. The application is expected to allocate a buffer of
	/// the necessary size for the passed parameters.
	/// </para>
	/// <para>
	/// IrDA provides an IAS database that stores IrDA-based information. Limited access to the IAS database is available through the
	/// Windows Sockets 2 interface, but such access is not normally used by applications, and exists primarily to support connections
	/// to non-Windows devices that are not compliant with the Windows Sockets 2 IrDA conventions.
	/// </para>
	/// <para>The following structure, <c>IAS_SET</c>, is used with the IRLMP_IAS_SET setsockopt option to manage the local IAS database:</para>
	/// <para>The following structure, <c>IAS_QUERY</c>, is used with the IRLMP_IAS_QUERY setsockopt option to query a peer's IAS database:</para>
	/// <para>Many SO_ level socket options are not meaningful to IrDA. Only SO_LINGER is specifically supported.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-setsockopt int setsockopt( SOCKET s, int level, int
	// optname, const char *optval, int optlen );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "3a6960c9-0c04-4403-aee1-ce250459dc30")]
	public static extern WSRESULT setsockopt(SOCKET s, int level, int optname, IntPtr optval, int optlen);

	/// <summary>The <c>setsockopt</c> function sets a socket option.</summary>
	/// <param name="s">A descriptor that identifies a socket.</param>
	/// <param name="level">The level at which the option is defined (for example, SOL_SOCKET).</param>
	/// <param name="optname">
	/// The socket option for which the value is to be set (for example, SO_BROADCAST). The optname parameter must be a socket option
	/// defined within the specified level, or behavior is undefined.
	/// </param>
	/// <param name="optval">The value for the requested option is specified.</param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>setsockopt</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code
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
	/// <term>WSAEFAULT</term>
	/// <term>
	/// The buffer pointed to by the optval parameter is not in a valid part of the process address space or the optlen parameter is too small.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>The level parameter is not valid, or the information in the buffer pointed to by the optval parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>WSAENETRESET</term>
	/// <term>The connection has timed out when SO_KEEPALIVE is set.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOPROTOOPT</term>
	/// <term>The option is unknown or unsupported for the specified provider or socket (see SO_GROUP_PRIORITY limitations).</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTCONN</term>
	/// <term>The connection has been reset when SO_KEEPALIVE is set.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term>The descriptor is not a socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>setsockopt</c> function sets the current value for a socket option associated with a socket of any type, in any state.
	/// Although options can exist at multiple protocol levels, they are always present at the uppermost socket level. Options affect
	/// socket operations, such as whether expedited data (OOB data for example) is received in the normal data stream, and whether
	/// broadcast messages can be sent on the socket.
	/// </para>
	/// <para>
	/// <c>Note</c> If the <c>setsockopt</c> function is called before the bind function, TCP/IP options will not be checked by using
	/// TCP/IP until the <c>bind</c> occurs. In this case, the <c>setsockopt</c> function call will always succeed, but the <c>bind</c>
	/// function call can fail because of an early <c>setsockopt</c> call failing.
	/// </para>
	/// <para>
	/// <c>Note</c> If a socket is opened, a <c>setsockopt</c> call is made, and then a sendto call is made, Windows Sockets performs an
	/// implicit bind function call.
	/// </para>
	/// <para>
	/// There are two types of socket options: Boolean options that enable or disable a feature or behavior, and options that require an
	/// integer value or structure. To enable a Boolean option, the optval parameter points to a nonzero integer. To disable the option
	/// optval points to an integer equal to zero. The optlen parameter should be equal to for Boolean options. For other options,
	/// optval points to an integer or structure that contains the desired value for the option, and optlen is the length of the integer
	/// or structure.
	/// </para>
	/// <para>
	/// The following tables list some of the common options supported by the <c>setsockopt</c> function. The Type column identifies the
	/// type of data addressed by optval parameter. The Description column provides some basic information about the socket option. For
	/// more complete lists of socket options and more detailed information (default values, for example), see the detailed topics under
	/// Socket Options.
	/// </para>
	/// <para>level = <c>SOL_SOCKET</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>SO_BROADCAST</term>
	/// <term>BOOL</term>
	/// <term>Configures a socket for sending broadcast data.</term>
	/// </item>
	/// <item>
	/// <term>SO_CONDITIONAL_ACCEPT</term>
	/// <term>BOOL</term>
	/// <term>Enables incoming connections are to be accepted or rejected by the application, not by the protocol stack.</term>
	/// </item>
	/// <item>
	/// <term>SO_DEBUG</term>
	/// <term>BOOL</term>
	/// <term>Enables debug output. Microsoft providers currently do not output any debug information.</term>
	/// </item>
	/// <item>
	/// <term>SO_DONTLINGER</term>
	/// <term>BOOL</term>
	/// <term>
	/// Does not block close waiting for unsent data to be sent. Setting this option is equivalent to setting SO_LINGER with l_onoff set
	/// to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_DONTROUTE</term>
	/// <term>BOOL</term>
	/// <term>
	/// Sets whether outgoing data should be sent on interface the socket is bound to and not a routed on some other interface. This
	/// option is not supported on ATM sockets (results in an error).
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_GROUP_PRIORITY</term>
	/// <term>int</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>SO_KEEPALIVE</term>
	/// <term>BOOL</term>
	/// <term>Enables sending keep-alive packets for a socket connection. Not supported on ATM sockets (results in an error).</term>
	/// </item>
	/// <item>
	/// <term>SO_LINGER</term>
	/// <term>LINGER</term>
	/// <term>Lingers on close if unsent data is present.</term>
	/// </item>
	/// <item>
	/// <term>SO_OOBINLINE</term>
	/// <term>BOOL</term>
	/// <term>
	/// Indicates that out-of-bound data should be returned in-line with regular data. This option is only valid for connection-oriented
	/// protocols that support out-of-band data. For a discussion of this topic, see Protocol Independent Out-Of-band Data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_RCVBUF</term>
	/// <term>int</term>
	/// <term>Specifies the total per-socket buffer space reserved for receives.</term>
	/// </item>
	/// <item>
	/// <term>SO_REUSEADDR</term>
	/// <term>BOOL</term>
	/// <term>
	/// Allows the socket to be bound to an address that is already in use. For more information, see bind. Not applicable on ATM sockets.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_EXCLUSIVEADDRUSE</term>
	/// <term>BOOL</term>
	/// <term>Enables a socket to be bound for exclusive access. Does not require administrative privilege.</term>
	/// </item>
	/// <item>
	/// <term>SO_RCVTIMEO</term>
	/// <term>DWORD</term>
	/// <term>Sets the timeout, in milliseconds, for blocking receive calls.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDBUF</term>
	/// <term>int</term>
	/// <term>Specifies the total per-socket buffer space reserved for sends.</term>
	/// </item>
	/// <item>
	/// <term>SO_SNDTIMEO</term>
	/// <term>DWORD</term>
	/// <term>The timeout, in milliseconds, for blocking send calls.</term>
	/// </item>
	/// <item>
	/// <term>SO_UPDATE_ACCEPT_CONTEXT</term>
	/// <term>int</term>
	/// <term>Updates the accepting socket with the context of the listening socket.</term>
	/// </item>
	/// <item>
	/// <term>PVD_CONFIG</term>
	/// <term>Service Provider Dependent</term>
	/// <term>
	/// This object stores the configuration information for the service provider associated with socket s. The exact format of this
	/// data structure is service provider specific.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For more complete and detailed information about socket options for level = <c>SOL_SOCKET</c>, see SOL_SOCKET Socket Options.</para>
	/// <para>level = <c>IPPROTO_TCP</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TCP_NODELAY</term>
	/// <term>BOOL</term>
	/// <term>
	/// Disables the Nagle algorithm for send coalescing.This socket option is included for backward compatibility with Windows Sockets 1.1
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// For more complete and detailed information about socket options for level = <c>IPPROTO_TCP</c>, see IPPROTO_TCP Socket Options.
	/// </para>
	/// <para>level = <c>NSPROTO_IPX</c></para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IPX_PTYPE</term>
	/// <term>int</term>
	/// <term>Sets the IPX packet type.</term>
	/// </item>
	/// <item>
	/// <term>IPX_FILTERPTYPE</term>
	/// <term>int</term>
	/// <term>Sets the receive filter packet type</term>
	/// </item>
	/// <item>
	/// <term>IPX_STOPFILTERPTYPE</term>
	/// <term>int</term>
	/// <term>Stops filtering the filter type set with IPX_FILTERTYPE</term>
	/// </item>
	/// <item>
	/// <term>IPX_DSTYPE</term>
	/// <term>int</term>
	/// <term>Sets the value of the data stream field in the SPX header on every packet sent.</term>
	/// </item>
	/// <item>
	/// <term>IPX_EXTENDED_ADDRESS</term>
	/// <term>BOOL</term>
	/// <term>Sets whether extended addressing is enabled.</term>
	/// </item>
	/// <item>
	/// <term>IPX_RECVHDR</term>
	/// <term>BOOL</term>
	/// <term>Sets whether the protocol header is sent up on all receive headers.</term>
	/// </item>
	/// <item>
	/// <term>IPX_RECEIVE_BROADCAST</term>
	/// <term>BOOL</term>
	/// <term>
	/// Indicates broadcast packets are likely on the socket. Set to TRUE by default. Applications that do not use broadcasts should set
	/// this to FALSE for better system performance.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IPX_IMMEDIATESPXACK</term>
	/// <term>BOOL</term>
	/// <term>
	/// Directs SPX connections not to delay before sending an ACK. Applications without back-and-forth traffic should set this to TRUE
	/// to increase performance.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// For more complete and detailed information about socket options for level = <c>NSPROTO_IPX</c>, see NSPROTO_IPX Socket Options.
	/// </para>
	/// <para>BSD options not supported for <c>setsockopt</c> are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Type</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>SO_ACCEPTCONN</term>
	/// <term>BOOL</term>
	/// <term>
	/// Returns whether a socket is in listening mode. This option is only Valid for connection-oriented protocols. This socket option
	/// is not supported for the setting.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_RCVLOWAT</term>
	/// <term>int</term>
	/// <term>
	/// A socket option from BSD UNIX included for backward compatibility. This option sets the minimum number of bytes to process for
	/// socket input operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_SNDLOWAT</term>
	/// <term>int</term>
	/// <term>
	/// A socket option from BSD UNIX included for backward compatibility. This option sets the minimum number of bytes to process for
	/// socket output operations.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SO_TYPE</term>
	/// <term>int</term>
	/// <term>
	/// Returns the socket type for the given socket (SOCK_STREAM or SOCK_DGRAM, for example This socket option is not supported for the
	/// setting the socket type.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>setsockopt</c>, Winsock may need to wait for a network event before
	/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
	/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
	/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Example Code</para>
	/// <para>The following example demonstrates the <c>setsockopt</c> function.</para>
	/// <para>Notes for IrDA Sockets</para>
	/// <para>When developing applications using Windows sockets for IrDA, note the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The Af_irda.h header file must be explicitly included.</term>
	/// </item>
	/// <item>
	/// <term>IrDA provides the following socket option:</term>
	/// </item>
	/// </list>
	/// <para>
	/// The IRLMP_IAS_SET socket option enables the application to set a single attribute of a single class in the local IAS. The
	/// application specifies the class to set, the attribute, and attribute type. The application is expected to allocate a buffer of
	/// the necessary size for the passed parameters.
	/// </para>
	/// <para>
	/// IrDA provides an IAS database that stores IrDA-based information. Limited access to the IAS database is available through the
	/// Windows Sockets 2 interface, but such access is not normally used by applications, and exists primarily to support connections
	/// to non-Windows devices that are not compliant with the Windows Sockets 2 IrDA conventions.
	/// </para>
	/// <para>The following structure, <c>IAS_SET</c>, is used with the IRLMP_IAS_SET setsockopt option to manage the local IAS database:</para>
	/// <para>The following structure, <c>IAS_QUERY</c>, is used with the IRLMP_IAS_QUERY setsockopt option to query a peer's IAS database:</para>
	/// <para>Many SO_ level socket options are not meaningful to IrDA. Only SO_LINGER is specifically supported.</para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-setsockopt int setsockopt( SOCKET s, int level, int
	// optname, const char *optval, int optlen );
	[PInvokeData("winsock.h", MSDNShortId = "3a6960c9-0c04-4403-aee1-ce250459dc30")]
	public static WSRESULT setsockopt<TLvl, TIn>(SOCKET s, TLvl level, int optname, in TIn optval) where TIn : struct where TLvl : IConvertible
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure(optval);
		return setsockopt(s, level.ToInt32(null), optname, mem, mem.Size);
	}

	/// <summary>The <c>shutdown</c> function disables sends or receives on a socket.</summary>
	/// <param name="s">A descriptor identifying a socket.</param>
	/// <param name="how">
	/// <para>
	/// A flag that describes what types of operation will no longer be allowed. Possible values for this flag are listed in the
	/// Winsock2.h header file.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SD_RECEIVE 0</term>
	/// <term>Shutdown receive operations.</term>
	/// </item>
	/// <item>
	/// <term>SD_SEND 1</term>
	/// <term>Shutdown send operations.</term>
	/// </item>
	/// <item>
	/// <term>SD_BOTH 2</term>
	/// <term>Shutdown both send and receive operations.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If no error occurs, <c>shutdown</c> returns zero. Otherwise, a value of SOCKET_ERROR is returned, and a specific error code can
	/// be retrieved by calling WSAGetLastError.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WSAECONNABORTED</term>
	/// <term>
	/// The virtual circuit was terminated due to a time-out or other failure. The application should close the socket as it is no
	/// longer usable. This error applies only to a connection-oriented socket.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAECONNRESET</term>
	/// <term>
	/// The virtual circuit was reset by the remote side executing a hard or abortive close. The application should close the socket as
	/// it is no longer usable. This error applies only to a connection-oriented socket.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAEINPROGRESS</term>
	/// <term>A blocking Windows Sockets 1.1 call is in progress, or the service provider is still processing a callback function.</term>
	/// </item>
	/// <item>
	/// <term>WSAEINVAL</term>
	/// <term>
	/// The how parameter is not valid, or is not consistent with the socket type. For example, SD_SEND is used with a UNI_RECV socket type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>WSAENETDOWN</term>
	/// <term>The network subsystem has failed.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTCONN</term>
	/// <term>The socket is not connected. This error applies only to a connection-oriented socket.</term>
	/// </item>
	/// <item>
	/// <term>WSAENOTSOCK</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>WSANOTINITIALISED</term>
	/// <term>A successful WSAStartup call must occur before using this function.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>shutdown</c> function is used on all types of sockets to disable reception, transmission, or both.</para>
	/// <para>
	/// If the how parameter is SD_RECEIVE, subsequent calls to the recv function on the socket will be disallowed. This has no effect
	/// on the lower protocol layers. For TCP sockets, if there is still data queued on the socket waiting to be received, or data
	/// arrives subsequently, the connection is reset, since the data cannot be delivered to the user. For UDP sockets, incoming
	/// datagrams are accepted and queued. In no case will an ICMP error packet be generated.
	/// </para>
	/// <para>
	/// If the how parameter is SD_SEND, subsequent calls to the send function are disallowed. For TCP sockets, a FIN will be sent after
	/// all data is sent and acknowledged by the receiver.
	/// </para>
	/// <para>Setting how to SD_BOTH disables both sends and receives as described above.</para>
	/// <para>
	/// The <c>shutdown</c> function does not close the socket. Any resources attached to the socket will not be freed until closesocket
	/// is invoked.
	/// </para>
	/// <para>
	/// To assure that all data is sent and received on a connected socket before it is closed, an application should use
	/// <c>shutdown</c> to close connection before calling closesocket. One method to wait for notification that the remote end has sent
	/// all its data and initiated a graceful disconnect uses the WSAEventSelect function as follows :
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call WSAEventSelect to register for FD_CLOSE notification.</term>
	/// </item>
	/// <item>
	/// <term>Call <c>shutdown</c> with how=SD_SEND.</term>
	/// </item>
	/// <item>
	/// <term>
	/// When FD_CLOSE received, call the recv or WSARecv until the function completes with success and indicates that zero bytes were
	/// received. If SOCKET_ERROR is returned, then the graceful disconnect is not possible.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call closesocket.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Another method to wait for notification that the remote end has sent all its data and initiated a graceful disconnect uses
	/// overlapped receive calls follows :
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Call <c>shutdown</c> with how=SD_SEND.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Call recv or WSARecv until the function completes with success and indicates zero bytes were received. If SOCKET_ERROR is
	/// returned, then the graceful disconnect is not possible.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Call closesocket.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> The <c>shutdown</c> function does not block regardless of the SO_LINGER setting on the socket.</para>
	/// <para>For more information, see the section on Graceful Shutdown, Linger Options, and Socket Closure.</para>
	/// <para>
	/// Once the <c>shutdown</c> function is called to disable send, receive, or both, there is no method to re-enable send or receive
	/// for the existing socket connection.
	/// </para>
	/// <para>
	/// An application should not rely on being able to reuse a socket after it has been shut down. In particular, a Windows Sockets
	/// provider is not required to support the use of connect on a socket that has been shut down.
	/// </para>
	/// <para>
	/// If an application wants to reuse a socket, then the DisconnectEx function should be called with the dwFlags parameter set to
	/// <c>TF_REUSE_SOCKET</c> to close a connection on a socket and prepare the socket handle to be reused. When the
	/// <c>DisconnectEx</c> request completes, the socket handle can be passed to the AcceptEx or ConnectEx function.
	/// </para>
	/// <para>
	/// If an application wants to reuse a socket, the TransmitFile or TransmitPackets functions can be called with the dwFlags
	/// parameter set with <c>TF_DISCONNECT</c> and <c>TF_REUSE_SOCKET</c> to disconnect after all the data has been queued for
	/// transmission and prepare the socket handle to be reused. When the <c>TransmitFile</c> request completes, the socket handle can
	/// be passed to the function call previously used to establish the connection, such as AcceptEx or ConnectEx. When the
	/// <c>TransmitPackets</c> function completes, the socket handle can be passed to the <c>AcceptEx</c> function.
	/// </para>
	/// <para>
	/// <c>Note</c> The socket level disconnect is subject to the behavior of the underlying transport. For example, a TCP socket may be
	/// subject to the TCP TIME_WAIT state, causing the DisconnectEx, TransmitFile, or TransmitPackets call to be delayed.
	/// </para>
	/// <para>
	/// <c>Note</c> When issuing a blocking Winsock call such as <c>shutdown</c>, Winsock may need to wait for a network event before
	/// the call can complete. Winsock performs an alertable wait in this situation, which can be interrupted by an asynchronous
	/// procedure call (APC) scheduled on the same thread. Issuing another blocking Winsock call inside an APC that interrupted an
	/// ongoing blocking Winsock call on the same thread will lead to undefined behavior, and must never be attempted by Winsock clients.
	/// </para>
	/// <para>Notes for ATM</para>
	/// <para>
	/// There are important issues associated with connection teardown when using Asynchronous Transfer Mode (ATM) and Windows Sockets
	/// 2. For more information about these important considerations, see the section titled Notes for ATM in the Remarks section of the
	/// closesocket function reference.
	/// </para>
	/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
	/// <para>
	/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
	/// Server 2012 R2, and later.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/nf-winsock-shutdown int shutdown( SOCKET s, int how );
	[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winsock.h", MSDNShortId = "6998f0c6-adc9-481f-b9fb-75f9c9f5caaf")]
	public static extern WSRESULT shutdown(SOCKET s, SD how);

	/// <summary>The <c>socket</c> function creates a socket that is bound to a specific transport service provider.</summary>
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
	/// specified. Possible values for the protocol are defined in the Winsock2.h and Wsrm.h header files.
	/// </para>
	/// <para>
	/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and this parameter can be
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
	/// chain, not a protocol layer by itself. Unchained protocol layers are not considered to have partial matches on type or af
	/// either. That is, they do not lead to an error code of WSAEAFNOSUPPORT or WSAEPROTONOSUPPORT if no suitable protocol is found.
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
	/// The communications protocols used to implement a reliable, connection-oriented socket ensure that data is not lost or
	/// duplicated. If data for which the peer protocol has buffer space cannot be successfully transmitted within a reasonable length
	/// of time, the connection is considered broken and subsequent calls will fail with the error code set to WSAETIMEDOUT.
	/// </para>
	/// <para>
	/// Connectionless, message-oriented sockets allow sending and receiving of datagrams to and from arbitrary peers using sendto and
	/// recvfrom. If such a socket is connected to a specific peer, datagrams can be sent to that peer using send and can be received
	/// only from this peer using recv.
	/// </para>
	/// <para>
	/// IPv6 and IPv4 operate differently when receiving a socket with a type of <c>SOCK_RAW</c>. The IPv4 receive packet includes the
	/// packet payload, the next upper-level header (for example, the IP header for a TCP or UDP packet), and the IPv4 packet header.
	/// The IPv6 receive packet includes the packet payload and the next upper-level header. The IPv6 receive packet never includes the
	/// IPv6 packet header.
	/// </para>
	/// <para><c>Note</c> On Windows NT, raw socket support requires administrative privileges.</para>
	/// <para>
	/// A socket with a type parameter of <c>SOCK_SEQPACKET</c> is based on datagrams, but functions as a pseudo-stream protocol. For
	/// both send and receive packets, separate datagrams are used. However, Windows Sockets can coalesce multiple receive packets into
	/// a single packet. So an application can issue a receive call (for example, recv or WSARecvEx) and retrieve the data from several
	/// coalesced multiple packets in single call. The AF_NETBIOS address family supports a type parameter of <c>SOCK_SEQPACKET</c>.
	/// </para>
	/// <para>
	/// When the af parameter is <c>AF_NETBIOS</c> for NetBIOS over TCP/IP, the type parameter can be <c>SOCK_DGRAM</c> or
	/// <c>SOCK_SEQPACKET</c>. For the <c>AF_NETBIOS</c> address family, the protocol parameter is the LAN adapter number represented as
	/// a negative number.
	/// </para>
	/// <para>
	/// On Windows XP and later, the following command can be used to list the Windows Sockets catalog to determine the service
	/// providers installed and the address family, socket type, and protocols that are supported.
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
	/// installed. Otherwise, a call to the <c>socket</c> function with af parameter set to AF_IRDA will fail and WSAGetLastError
	/// returns WSAEPROTONOSUPPORT.
	/// </para>
	/// <para>Example Code</para>
	/// <para>
	/// The following example demonstrates the use of the <c>socket</c> function to create a socket that is bound to a specific
	/// transport service provider..
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
	public static extern SafeSOCKET socket(ADDRESS_FAMILY af, SOCK type, IPPROTO protocol);

	/// <summary>The <c>socket</c> function creates a socket that is bound to a specific transport service provider.</summary>
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
	/// specified. Possible values for the protocol are defined in the Winsock2.h and Wsrm.h header files.
	/// </para>
	/// <para>
	/// On the Windows SDK released for Windows Vista and later, the organization of header files has changed and this parameter can be
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
	/// chain, not a protocol layer by itself. Unchained protocol layers are not considered to have partial matches on type or af
	/// either. That is, they do not lead to an error code of WSAEAFNOSUPPORT or WSAEPROTONOSUPPORT if no suitable protocol is found.
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
	/// The communications protocols used to implement a reliable, connection-oriented socket ensure that data is not lost or
	/// duplicated. If data for which the peer protocol has buffer space cannot be successfully transmitted within a reasonable length
	/// of time, the connection is considered broken and subsequent calls will fail with the error code set to WSAETIMEDOUT.
	/// </para>
	/// <para>
	/// Connectionless, message-oriented sockets allow sending and receiving of datagrams to and from arbitrary peers using sendto and
	/// recvfrom. If such a socket is connected to a specific peer, datagrams can be sent to that peer using send and can be received
	/// only from this peer using recv.
	/// </para>
	/// <para>
	/// IPv6 and IPv4 operate differently when receiving a socket with a type of <c>SOCK_RAW</c>. The IPv4 receive packet includes the
	/// packet payload, the next upper-level header (for example, the IP header for a TCP or UDP packet), and the IPv4 packet header.
	/// The IPv6 receive packet includes the packet payload and the next upper-level header. The IPv6 receive packet never includes the
	/// IPv6 packet header.
	/// </para>
	/// <para><c>Note</c> On Windows NT, raw socket support requires administrative privileges.</para>
	/// <para>
	/// A socket with a type parameter of <c>SOCK_SEQPACKET</c> is based on datagrams, but functions as a pseudo-stream protocol. For
	/// both send and receive packets, separate datagrams are used. However, Windows Sockets can coalesce multiple receive packets into
	/// a single packet. So an application can issue a receive call (for example, recv or WSARecvEx) and retrieve the data from several
	/// coalesced multiple packets in single call. The AF_NETBIOS address family supports a type parameter of <c>SOCK_SEQPACKET</c>.
	/// </para>
	/// <para>
	/// When the af parameter is <c>AF_NETBIOS</c> for NetBIOS over TCP/IP, the type parameter can be <c>SOCK_DGRAM</c> or
	/// <c>SOCK_SEQPACKET</c>. For the <c>AF_NETBIOS</c> address family, the protocol parameter is the LAN adapter number represented as
	/// a negative number.
	/// </para>
	/// <para>
	/// On Windows XP and later, the following command can be used to list the Windows Sockets catalog to determine the service
	/// providers installed and the address family, socket type, and protocols that are supported.
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
	/// installed. Otherwise, a call to the <c>socket</c> function with af parameter set to AF_IRDA will fail and WSAGetLastError
	/// returns WSAEPROTONOSUPPORT.
	/// </para>
	/// <para>Example Code</para>
	/// <para>
	/// The following example demonstrates the use of the <c>socket</c> function to create a socket that is bound to a specific
	/// transport service provider..
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
	public static extern SafeSOCKET socket(ADDRESS_FAMILY af, SOCK type, uint protocol = 0U);

	/// <summary>
	/// The <c>protoent</c> structure contains the name and protocol numbers that correspond to a given protocol name. Applications must
	/// never attempt to modify this structure or to free any of its components. Furthermore, only one copy of this structure is
	/// allocated per thread, and therefore, the application should copy any information it needs before issuing any other Windows
	/// Sockets function calls.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/ns-winsock-protoent typedef struct protoent { char *p_name; char
	// **p_aliases; short p_proto; } PROTOENT, *PPROTOENT, *LPPROTOENT;
	[PInvokeData("winsock.h", MSDNShortId = "8fc729dd-5a73-42a1-9c3f-adc68d83d863")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PROTOENT
	{
		/// <summary>Official name of the protocol.</summary>
		public LPSTR p_name;

		/// <summary>Null-terminated array of alternate names.</summary>
		public IntPtr p_aliases;

		/// <summary>Protocol number, in host byte order.</summary>
		public short p_proto;

		/// <summary>Array of alternate names extracted from <see cref="p_aliases"/>.</summary>
		public readonly string?[] Aliases => p_aliases.ToStringEnum(p_aliases.GetNulledPtrArrayLength(), CharSet.Ansi).ToArray();
	}

	/// <summary>The <c>servent</c> structure is used to store or return the name and service number for a given service name.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/ns-winsock-servent typedef struct servent { char *s_name; char
	// **s_aliases; #if ... char *s_proto; #if ... short s_port; #else short s_port; #endif #else char *s_proto; #endif } SERVENT,
	// *PSERVENT, *LPSERVENT;
	[PInvokeData("winsock.h", MSDNShortId = "8696b854-4d37-4d1b-8383-169b5dc7a2ae")]
	[VanaraMarshaler(typeof(SERVENT))]
	public struct SERVENT : IVanaraMarshaler
	{
		/// <summary>The official name of the service.</summary>
		public string? s_name;

		/// <summary>An array of alternate names.</summary>
		public string[] s_aliases;

		/// <summary>The port number at which the service can be contacted. Port numbers are returned in network byte order.</summary>
		public short s_port;

		/// <summary>The name of the protocol to use when contacting the service.</summary>
		public string? s_proto;

		/// <summary>Use this method to address different structure layouts on 64-bit systems.</summary>
		/// <param name="ptr">The ptr to convert.</param>
		/// <returns>A SERVENT structure aligned correctly.</returns>
		public static SERVENT FromIntPtr(IntPtr ptr)
		{
			if (IntPtr.Size == 8)
			{
				var x = ptr.ToStructure<SERVENTx64>();
				return new SERVENT { s_name = x.s_name, s_aliases = x.s_aliases.ToStringEnum(x.s_aliases.GetNulledPtrArrayLength(), CharSet.Ansi).Where(s => s is not null).ToArray()!, s_port = x.s_port, s_proto = x.s_proto };
			}
			var s = ptr.ToStructure<SERVENTx32>();
			return new SERVENT { s_name = s.s_name, s_aliases = s.s_aliases.ToStringEnum(s.s_aliases.GetNulledPtrArrayLength(), CharSet.Ansi).Where(s => s is not null).ToArray()!, s_port = s.s_port, s_proto = s.s_proto };
		}

		readonly SIZE_T IVanaraMarshaler.GetNativeSize() => IntPtr.Size == 8 ? Marshal.SizeOf(typeof(SERVENTx64)) : Marshal.SizeOf(typeof(SERVENT));

		readonly SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
		{
			if (managedObject is SERVENT s)
			{
				var mem = new SafeHGlobalHandle(64);
				using (var str = new NativeMemoryStream(mem, 64L))
				{
					str.WriteReference(s.s_name);
					str.WriteReferenceObject(s.s_aliases);
					if (IntPtr.Size == 8)
					{
						str.WriteReference(s.s_proto);
						str.Write((int)s.s_port);
					}
					else
					{
						str.WriteReference(s.s_proto);
						str.Write((int)s.s_port);
					}
				}
				return mem;
			}
			throw new ArgumentException("Object must be of type SERVENT.", nameof(managedObject));
		}

		object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SIZE_T allocatedBytes) => FromIntPtr(pNativeData);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct SERVENTx32
		{
			public LPSTR s_name;
			public IntPtr s_aliases;
			public short s_port;
			public LPSTR s_proto;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct SERVENTx64
		{
			public LPSTR s_name;
			public IntPtr s_aliases;
			public LPSTR s_proto;
			public short s_port;
		}
	}
}