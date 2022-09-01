namespace Vanara.PInvoke;

public static partial class FwpUClnt
{
	/// <summary>
	/// The <c>WSADeleteSocketPeerTargetName</c> function removes the association between a peer target name and an IP address for a socket.
	/// After a successful return, there will be no future association between the IP address and the target name.
	/// </summary>
	/// <param name="Socket">A descriptor identifying a socket on which the peer target name is being deleted.</param>
	/// <param name="PeerAddr">The IP address of the peer for which the target name is being deleted.</param>
	/// <param name="PeerAddrLen">The size, in bytes, of the <c>PeerAddr</c> parameter.</param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is 0. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code can
	/// be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid address pointer in attempting to use a pointer argument of a call. This error is returned if the
	/// <c>PeerAddr</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSADeleteSocketPeerTargetName</c> function provides a method to remove the association between a peer target name and an IP
	/// address for a socket. This function is used to delete a peer target name that was previously set with the WSASetSocketPeerTargetName
	/// function. After the <c>WSADeleteSocketPeerTargetName</c> function returns, no future authentication to the IP address will use the
	/// previously specified target name. This function is primarily designed to be used by connectionless clients (for example, a socket
	/// created with the type set to SOCK_DGRAM or the protocol set to IPPROTO_UDP) after they have terminated the connection with the IP
	/// address associated with the peer target name. For connection oriented clients (for example, a socket created with the type set to
	/// SOCK_STREAM or protocol set to IPPROTO_TCP), this function should not be called.
	/// </para>
	/// <para>
	/// The <c>WSADeleteSocketPeerTargetName</c> function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c>
	/// parameter set to <c>SIO_DELETE_PEER_TARGET_NAME</c>.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsadeletesocketpeertargetname INT WSAAPI
	// WSADeleteSocketPeerTargetName( [in] SOCKET Socket, [in] const sockaddr *PeerAddr, [in] ULONG PeerAddrLen, [in, optional]
	// LPWSAOVERLAPPED Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSADeleteSocketPeerTargetName")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSADeleteSocketPeerTargetName([In] SOCKET Socket, [In] SOCKADDR PeerAddr, uint PeerAddrLen,
		in WSAOVERLAPPED Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>
	/// The <c>WSADeleteSocketPeerTargetName</c> function removes the association between a peer target name and an IP address for a socket.
	/// After a successful return, there will be no future association between the IP address and the target name.
	/// </summary>
	/// <param name="Socket">A descriptor identifying a socket on which the peer target name is being deleted.</param>
	/// <param name="PeerAddr">The IP address of the peer for which the target name is being deleted.</param>
	/// <param name="PeerAddrLen">The size, in bytes, of the <c>PeerAddr</c> parameter.</param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is 0. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code can
	/// be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid address pointer in attempting to use a pointer argument of a call. This error is returned if the
	/// <c>PeerAddr</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSADeleteSocketPeerTargetName</c> function provides a method to remove the association between a peer target name and an IP
	/// address for a socket. This function is used to delete a peer target name that was previously set with the WSASetSocketPeerTargetName
	/// function. After the <c>WSADeleteSocketPeerTargetName</c> function returns, no future authentication to the IP address will use the
	/// previously specified target name. This function is primarily designed to be used by connectionless clients (for example, a socket
	/// created with the type set to SOCK_DGRAM or the protocol set to IPPROTO_UDP) after they have terminated the connection with the IP
	/// address associated with the peer target name. For connection oriented clients (for example, a socket created with the type set to
	/// SOCK_STREAM or protocol set to IPPROTO_TCP), this function should not be called.
	/// </para>
	/// <para>
	/// The <c>WSADeleteSocketPeerTargetName</c> function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c>
	/// parameter set to <c>SIO_DELETE_PEER_TARGET_NAME</c>.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsadeletesocketpeertargetname INT WSAAPI
	// WSADeleteSocketPeerTargetName( [in] SOCKET Socket, [in] const sockaddr *PeerAddr, [in] ULONG PeerAddrLen, [in, optional]
	// LPWSAOVERLAPPED Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSADeleteSocketPeerTargetName")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSADeleteSocketPeerTargetName([In] SOCKET Socket, [In] SOCKADDR PeerAddr, uint PeerAddrLen,
		[In, Optional] IntPtr Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>
	/// The <c>WSAImpersonateSocketPeer</c> function is used to impersonate the security principal corresponding to a socket peer in order to
	/// perform application-level authorization.
	/// </summary>
	/// <param name="Socket">Identifies the application socket.</param>
	/// <param name="PeerAddr">
	/// The IP address of the peer to be impersonated. For connection-oriented sockets, the connected socket uniquely identifies a peer. In
	/// this case, this parameter is ignored.
	/// </param>
	/// <param name="PeerAddrLen">The size, in bytes, of the <c>PeerAddress</c> parameter.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is 0. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code can
	/// be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid address pointer in attempting to use a pointer argument of a call. This error is returned if the
	/// <c>PeerAddr</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSAImpersonateSocketPeer</c> function provides an application the ability to impersonate the security principal corresponding
	/// to a socket peer in order to perform application-level authorization. If peer user (impersonation) token is available then it will be
	/// used for impersonation, otherwise the peer computer token will be used. The <c>WSAImpersonateSocketPeer</c> function can be called
	/// only for blocking, non-overlapped sockets. After performing any authorization checks, an application must call the
	/// WSARevertImpersonation function to terminate the impersonation.
	/// </para>
	/// <para>
	/// For connection-oriented sockets, the <c>WSAImpersonateSocketPeer</c> function should be called after a connection is established. For
	/// a server application using connection-oriented sockets, the <c>WSAImpersonateSocketPeer</c> should be called after the accept,
	/// AcceptEx, or WSAAccept function returns.
	/// </para>
	/// <para>
	/// For connectionless sockets, the application should call the <c>WSAImpersonateSocketPeer</c> function immediately after the recv,
	/// recvfrom, WSARecv, WSARecvEx, WSARecvFrom, or LPFN_WSARECVMSG (WSARecvMsg) function returns for a new peer address.
	/// </para>
	/// <para>The <c>WSAImpersonateSocketPeer</c> function can be called multiple times for a single socket.</para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// <para>The WSARevertImpersonation function must be called to end the impersonation.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsaimpersonatesocketpeer INT WSAAPI WSAImpersonateSocketPeer(
	// [in] SOCKET Socket, [in, optional] const sockaddr *PeerAddr, [in] ULONG PeerAddrLen );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSAImpersonateSocketPeer")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSAImpersonateSocketPeer([In] SOCKET Socket, [In, Optional] SOCKADDR PeerAddr,
		uint PeerAddrLen);

	/// <summary>The <c>WSAQuerySocketSecurity</c> function queries information about the security applied to a connection on a socket.</summary>
	/// <param name="Socket">A descriptor identifying a socket for which security information is being queried.</param>
	/// <param name="SecurityQueryTemplate">
	/// <para>A pointer to a SOCKET_SECURITY_QUERY_TEMPLATE structure that specifies the type of query information to return.</para>
	/// <para>
	/// A SOCKET_SECURITY_QUERY_TEMPLATE structure pointed to by this parameter may contain zeroes for all members to request default
	/// security information. On successful return, only the <c>Flags</c> member in the SOCKET_SECURITY_QUERY_INFO will be set in the
	/// returned <c>SecurityQueryInfo</c> parameter.
	/// </para>
	/// <para>
	/// This parameter may be a <c>NULL</c> pointer if the <c>Socket</c> parameter was created with a protocol of <c>IPPROTO_TCP</c>. In this
	/// case, the information returned is the same as if a SOCKET_SECURITY_QUERY_TEMPLATE structure with all values set to zero was passed.
	/// This parameter should be specified for a socket with protocol of <c>IPPROTO_TCP</c> if more than the default security information is required.
	/// </para>
	/// <para>
	/// If the SOCKET_SECURITY_QUERY_TEMPLATE structure is specified with the <c>PeerTokenAccessMask</c> member not specified (set to zero),
	/// then the <c>WSAQuerySocketSecurity</c> function will not return the <c>PeerApplicationAccessTokenHandle</c> and
	/// <c>PeerMachineAccessTokenHandle</c> members in the SOCKET_SECURITY_QUERY_INFO structure.
	/// </para>
	/// <para>
	/// If a <c>Socket</c> parameter was created with a protocol not equal to <c>IPPROTO_TCP</c>, the <c>SecurityQueryTemplate</c> parameter
	/// must be specified. In these cases, the <c>PeerAddress</c> member of the SOCKET_SECURITY_QUERY_TEMPLATE structure must specify an
	/// address family of AF_INET or AF_INET6 along with peer IP address and port number.
	/// </para>
	/// </param>
	/// <param name="SecurityQueryTemplateLen">
	/// <para>The size, in bytes, of the <c>SecurityQueryTemplate</c> parameter.</para>
	/// <para>
	/// This parameter may be a zero if the <c>Socket</c> parameter was created with a protocol of <c>IPPROTO_TCP</c>. Otherwise, this
	/// parameter must be the size of a SOCKET_SECURITY_QUERY_TEMPLATE structure.
	/// </para>
	/// </param>
	/// <param name="SecurityQueryInfo">
	/// A pointer to a buffer that will receive a SOCKET_SECURITY_QUERY_INFO structure containing the information queried. This value can be
	/// set to <c>NULL</c> to query the size of the output buffer.
	/// </param>
	/// <param name="SecurityQueryInfoLen">
	/// On input, a pointer to the size, in bytes, of the <c>SecurityQueryInfo</c> parameter. If the buffer is too small to receive the
	/// queried information, the call will return SOCKET_ERROR, and the number of bytes needed to return the queried information will be set
	/// in the value pointed to by this parameter. On a successful call, the number of bytes copied is returned.
	/// </param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAECONNRESET</c></term>
	/// <term>
	/// For a stream socket, the virtual circuit was reset by the remote side. The application should close the socket as it is no longer
	/// usable. For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port Unreachable" message.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a parameter. This error is returned if the
	/// <c>SecurityQueryInfoLen</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>
	/// A buffer passed was too small. This error is returned for a <c>Socket</c> parameter when the protocol was not <c>IPPROTO_TCP</c> if
	/// the <c>SecurityQueryInfo</c> parameter is a <c>NULL</c> pointer or the <c>SecurityQueryTemplateLen</c> parameter is less than the
	/// size of a SOCKET_SECURITY_QUERY_TEMPLATE structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSAQuerySocketSecurity</c> function provides a method to query the current security settings on a socket. After a connection
	/// is established, the <c>WSAQuerySocketSecurity</c> function allows an application to query the security properties of the connection,
	/// which can include information on peer access tokens.
	/// </para>
	/// <para>
	/// For connection-oriented sockets, it is preferred to call the <c>WSAQuerySocketSecurity</c> function immediately after a connection is
	/// established. For connectionless sockets, it is preferred to call the <c>WSAQuerySocketSecurity</c> function immediately after data is
	/// sent to a new peer address or received from a new peer address. The <c>WSAQuerySocketSecurity</c> function can be called multiple
	/// times on a single socket.
	/// </para>
	/// <para>This function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c> parameter set to <c>SIO_QUERY_SECURITY</c>.</para>
	/// <para>
	/// The <c>WSAQuerySocketSecurity</c> function may be called on a <c>Socket</c> parameter created with an address family of
	/// <c>AF_INET</c> or <c>AF_INET6</c>.
	/// </para>
	/// <para>
	/// If the <c>Socket</c> parameter was created with a protocol of <c>IPPROTO_TCP</c>, the <c>SecurityQueryTemplate</c> parameter may be
	/// <c>NULL</c> and the <c>SecurityQueryTemplateLen</c> parameter may be zero. Otherwise, the <c>SecurityQueryTemplate</c> parameter must
	/// point to a SOCKET_SECURITY_QUERY_TEMPLATE structure.
	/// </para>
	/// <para>
	/// For a client application using connection-oriented sockets (socket created with a protocol of <c>IPPROTO_TCP</c>), the
	/// <c>WSAQuerySocketSecurity</c> function should be called after the connect, ConnectEx, or WSAConnect function returns. For a server
	/// application using connection-oriented sockets (protocol of <c>IPPROTO_TCP</c>), the <c>WSAQuerySocketSecurity</c> function should be
	/// called after the accept, AcceptEx, or WSAAccept function returns.
	/// </para>
	/// <para>
	/// For connectionless sockets (socket created with a protocol of <c>IPPROTO_UDP</c>), the application should call the
	/// <c>WSAQuerySocketSecurity</c> function immediately after WSASendTo or WSARecvFrom call returns for a new peer address.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsaquerysocketsecurity INT WSAAPI WSAQuerySocketSecurity( [in]
	// SOCKET Socket, [in, optional] const SOCKET_SECURITY_QUERY_TEMPLATE *SecurityQueryTemplate, [in] ULONG SecurityQueryTemplateLen, [out,
	// optional] SOCKET_SECURITY_QUERY_INFO *SecurityQueryInfo, [in, out] ULONG *SecurityQueryInfoLen, [in, optional] LPWSAOVERLAPPED
	// Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSAQuerySocketSecurity")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSAQuerySocketSecurity([In] SOCKET Socket, ref SOCKET_SECURITY_QUERY_TEMPLATE SecurityQueryTemplate,
		uint SecurityQueryTemplateLen, SafeCoTaskMemStruct<SOCKET_SECURITY_QUERY_INFO> SecurityQueryInfo, ref uint SecurityQueryInfoLen,
		in WSAOVERLAPPED Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>The <c>WSAQuerySocketSecurity</c> function queries information about the security applied to a connection on a socket.</summary>
	/// <param name="Socket">A descriptor identifying a socket for which security information is being queried.</param>
	/// <param name="SecurityQueryTemplate">
	/// <para>A pointer to a SOCKET_SECURITY_QUERY_TEMPLATE structure that specifies the type of query information to return.</para>
	/// <para>
	/// A SOCKET_SECURITY_QUERY_TEMPLATE structure pointed to by this parameter may contain zeroes for all members to request default
	/// security information. On successful return, only the <c>Flags</c> member in the SOCKET_SECURITY_QUERY_INFO will be set in the
	/// returned <c>SecurityQueryInfo</c> parameter.
	/// </para>
	/// <para>
	/// This parameter may be a <c>NULL</c> pointer if the <c>Socket</c> parameter was created with a protocol of <c>IPPROTO_TCP</c>. In this
	/// case, the information returned is the same as if a SOCKET_SECURITY_QUERY_TEMPLATE structure with all values set to zero was passed.
	/// This parameter should be specified for a socket with protocol of <c>IPPROTO_TCP</c> if more than the default security information is required.
	/// </para>
	/// <para>
	/// If the SOCKET_SECURITY_QUERY_TEMPLATE structure is specified with the <c>PeerTokenAccessMask</c> member not specified (set to zero),
	/// then the <c>WSAQuerySocketSecurity</c> function will not return the <c>PeerApplicationAccessTokenHandle</c> and
	/// <c>PeerMachineAccessTokenHandle</c> members in the SOCKET_SECURITY_QUERY_INFO structure.
	/// </para>
	/// <para>
	/// If a <c>Socket</c> parameter was created with a protocol not equal to <c>IPPROTO_TCP</c>, the <c>SecurityQueryTemplate</c> parameter
	/// must be specified. In these cases, the <c>PeerAddress</c> member of the SOCKET_SECURITY_QUERY_TEMPLATE structure must specify an
	/// address family of AF_INET or AF_INET6 along with peer IP address and port number.
	/// </para>
	/// </param>
	/// <param name="SecurityQueryTemplateLen">
	/// <para>The size, in bytes, of the <c>SecurityQueryTemplate</c> parameter.</para>
	/// <para>
	/// This parameter may be a zero if the <c>Socket</c> parameter was created with a protocol of <c>IPPROTO_TCP</c>. Otherwise, this
	/// parameter must be the size of a SOCKET_SECURITY_QUERY_TEMPLATE structure.
	/// </para>
	/// </param>
	/// <param name="SecurityQueryInfo">
	/// A pointer to a buffer that will receive a SOCKET_SECURITY_QUERY_INFO structure containing the information queried. This value can be
	/// set to <c>NULL</c> to query the size of the output buffer.
	/// </param>
	/// <param name="SecurityQueryInfoLen">
	/// On input, a pointer to the size, in bytes, of the <c>SecurityQueryInfo</c> parameter. If the buffer is too small to receive the
	/// queried information, the call will return SOCKET_ERROR, and the number of bytes needed to return the queried information will be set
	/// in the value pointed to by this parameter. On a successful call, the number of bytes copied is returned.
	/// </param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAECONNRESET</c></term>
	/// <term>
	/// For a stream socket, the virtual circuit was reset by the remote side. The application should close the socket as it is no longer
	/// usable. For a UDP datagram socket, this error would indicate that a previous send operation resulted in an ICMP "Port Unreachable" message.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid pointer address in attempting to use a parameter. This error is returned if the
	/// <c>SecurityQueryInfoLen</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>
	/// A buffer passed was too small. This error is returned for a <c>Socket</c> parameter when the protocol was not <c>IPPROTO_TCP</c> if
	/// the <c>SecurityQueryInfo</c> parameter is a <c>NULL</c> pointer or the <c>SecurityQueryTemplateLen</c> parameter is less than the
	/// size of a SOCKET_SECURITY_QUERY_TEMPLATE structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSAQuerySocketSecurity</c> function provides a method to query the current security settings on a socket. After a connection
	/// is established, the <c>WSAQuerySocketSecurity</c> function allows an application to query the security properties of the connection,
	/// which can include information on peer access tokens.
	/// </para>
	/// <para>
	/// For connection-oriented sockets, it is preferred to call the <c>WSAQuerySocketSecurity</c> function immediately after a connection is
	/// established. For connectionless sockets, it is preferred to call the <c>WSAQuerySocketSecurity</c> function immediately after data is
	/// sent to a new peer address or received from a new peer address. The <c>WSAQuerySocketSecurity</c> function can be called multiple
	/// times on a single socket.
	/// </para>
	/// <para>This function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c> parameter set to <c>SIO_QUERY_SECURITY</c>.</para>
	/// <para>
	/// The <c>WSAQuerySocketSecurity</c> function may be called on a <c>Socket</c> parameter created with an address family of
	/// <c>AF_INET</c> or <c>AF_INET6</c>.
	/// </para>
	/// <para>
	/// If the <c>Socket</c> parameter was created with a protocol of <c>IPPROTO_TCP</c>, the <c>SecurityQueryTemplate</c> parameter may be
	/// <c>NULL</c> and the <c>SecurityQueryTemplateLen</c> parameter may be zero. Otherwise, the <c>SecurityQueryTemplate</c> parameter must
	/// point to a SOCKET_SECURITY_QUERY_TEMPLATE structure.
	/// </para>
	/// <para>
	/// For a client application using connection-oriented sockets (socket created with a protocol of <c>IPPROTO_TCP</c>), the
	/// <c>WSAQuerySocketSecurity</c> function should be called after the connect, ConnectEx, or WSAConnect function returns. For a server
	/// application using connection-oriented sockets (protocol of <c>IPPROTO_TCP</c>), the <c>WSAQuerySocketSecurity</c> function should be
	/// called after the accept, AcceptEx, or WSAAccept function returns.
	/// </para>
	/// <para>
	/// For connectionless sockets (socket created with a protocol of <c>IPPROTO_UDP</c>), the application should call the
	/// <c>WSAQuerySocketSecurity</c> function immediately after WSASendTo or WSARecvFrom call returns for a new peer address.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsaquerysocketsecurity INT WSAAPI WSAQuerySocketSecurity( [in]
	// SOCKET Socket, [in, optional] const SOCKET_SECURITY_QUERY_TEMPLATE *SecurityQueryTemplate, [in] ULONG SecurityQueryTemplateLen, [out,
	// optional] SOCKET_SECURITY_QUERY_INFO *SecurityQueryInfo, [in, out] ULONG *SecurityQueryInfoLen, [in, optional] LPWSAOVERLAPPED
	// Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSAQuerySocketSecurity")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSAQuerySocketSecurity([In] SOCKET Socket, [In, Optional] IntPtr SecurityQueryTemplate,
		uint SecurityQueryTemplateLen, [Out, Optional] IntPtr SecurityQueryInfo, ref uint SecurityQueryInfoLen,
		[In, Optional] IntPtr Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>
	/// The <c>WSARevertImpersonation</c> function terminates the impersonation of a socket peer. This must be called after calling
	/// WSAImpersonateSocketPeer and finishing any access checks.
	/// </summary>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSASYSCALLFAILURE</c></term>
	/// <term>A system call that should never fail has failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSARevertImpersonation</c> function causes the calling thread to discontinue the impersonation of a socket peer. If the thread
	/// is not currently impersonating a socket peer, no action is taken.
	/// </para>
	/// <para>
	/// The <c>WSARevertImpersonation</c> function should be called after calling WSAImpersonateSocketPeer and all access checks are finished.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsarevertimpersonation INT WSAAPI WSARevertImpersonation();
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSARevertImpersonation")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSARevertImpersonation();

	/// <summary>
	/// The <c>WSASetSocketPeerTargetName</c> function is used to specify the peer target name (SPN) that corresponds to a peer IP address.
	/// This target name is meant to be specified by client applications to securely identify the peer that should be authenticated.
	/// </summary>
	/// <param name="Socket">A descriptor identifying a socket on which the peer target name is being assigned.</param>
	/// <param name="PeerTargetName">A pointer to a SOCKET_PEER_TARGET_NAME structure that defines the peer target name.</param>
	/// <param name="PeerTargetNameLen">The size, in bytes, of the <c>PeerTargetName</c> parameter.</param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid address pointer in attempting to use a pointer argument of a call. This error is returned if the
	/// <c>PeerTargetName</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>. This error is
	/// also returned for a connectionless socket if the IP address and port are zero in the <c>PeerAddress</c> member of the
	/// SOCKET_PEER_TARGET_NAME structure pointed to by the <c>PeerTargetName</c> parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEISCONN</c></term>
	/// <term>
	/// The socket is connected. This function is not permitted with a connected socket, whether the socket is connection oriented or connectionless.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSASetSocketPeerTargetName</c> function provides a method to specify the target name that corresponds to a peer security
	/// principal. This function is meant to be used by a client application to identify the peer that should be authenticated. A client
	/// application should specify the peer target name in order to prevent trusted man-in-the-middle attacks. For connectionless sockets, an
	/// application can call the <c>WSASetSocketPeerTargetName</c> function multiple times to specify different target names for different
	/// peer IP addresses.
	/// </para>
	/// <para>This function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c> parameter set to <c>SIO_SET_PEER_TARGET_NAME</c>.</para>
	/// <para>
	/// For connection-oriented sockets, the <c>WSASetSocketPeerTargetName</c> function should be called before WSAConnect. For
	/// connectionless sockets, this function should be called before <c>WSAConnect</c> or before the first WSASendTo call directed to the
	/// peer address.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsasetsocketpeertargetname INT WSAAPI
	// WSASetSocketPeerTargetName( [in] SOCKET Socket, [in] const SOCKET_PEER_TARGET_NAME *PeerTargetName, [in] ULONG PeerTargetNameLen, [in,
	// optional] LPWSAOVERLAPPED Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSASetSocketPeerTargetName")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSASetSocketPeerTargetName([In] SOCKET Socket, in SOCKET_PEER_TARGET_NAME PeerTargetName,
		uint PeerTargetNameLen, in WSAOVERLAPPED Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>
	/// The <c>WSASetSocketPeerTargetName</c> function is used to specify the peer target name (SPN) that corresponds to a peer IP address.
	/// This target name is meant to be specified by client applications to securely identify the peer that should be authenticated.
	/// </summary>
	/// <param name="Socket">A descriptor identifying a socket on which the peer target name is being assigned.</param>
	/// <param name="PeerTargetName">A pointer to a SOCKET_PEER_TARGET_NAME structure that defines the peer target name.</param>
	/// <param name="PeerTargetNameLen">The size, in bytes, of the <c>PeerTargetName</c> parameter.</param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEFAULT</c></term>
	/// <term>
	/// The system detected an invalid address pointer in attempting to use a pointer argument of a call. This error is returned if the
	/// <c>PeerTargetName</c> parameter was a <c>NULL</c> pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>. This error is
	/// also returned for a connectionless socket if the IP address and port are zero in the <c>PeerAddress</c> member of the
	/// SOCKET_PEER_TARGET_NAME structure pointed to by the <c>PeerTargetName</c> parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEISCONN</c></term>
	/// <term>
	/// The socket is connected. This function is not permitted with a connected socket, whether the socket is connection oriented or connectionless.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WSASetSocketPeerTargetName</c> function provides a method to specify the target name that corresponds to a peer security
	/// principal. This function is meant to be used by a client application to identify the peer that should be authenticated. A client
	/// application should specify the peer target name in order to prevent trusted man-in-the-middle attacks. For connectionless sockets, an
	/// application can call the <c>WSASetSocketPeerTargetName</c> function multiple times to specify different target names for different
	/// peer IP addresses.
	/// </para>
	/// <para>This function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c> parameter set to <c>SIO_SET_PEER_TARGET_NAME</c>.</para>
	/// <para>
	/// For connection-oriented sockets, the <c>WSASetSocketPeerTargetName</c> function should be called before WSAConnect. For
	/// connectionless sockets, this function should be called before <c>WSAConnect</c> or before the first WSASendTo call directed to the
	/// peer address.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsasetsocketpeertargetname INT WSAAPI
	// WSASetSocketPeerTargetName( [in] SOCKET Socket, [in] const SOCKET_PEER_TARGET_NAME *PeerTargetName, [in] ULONG PeerTargetNameLen, [in,
	// optional] LPWSAOVERLAPPED Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSASetSocketPeerTargetName")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSASetSocketPeerTargetName([In] SOCKET Socket, in SOCKET_PEER_TARGET_NAME PeerTargetName,
		uint PeerTargetNameLen, [In, Optional] IntPtr Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>The <c>WSASetSocketSecurity</c> function enables and applies security for a socket.</summary>
	/// <param name="Socket">A descriptor that identifies a socket on which security settings are being applied.</param>
	/// <param name="SecuritySettings">
	/// A pointer to a SOCKET_SECURITY_SETTINGS structure that specifies the security settings to be applied to the socket's traffic. If this
	/// parameter is <c>NULL</c>, default settings will be applied to the socket.
	/// </param>
	/// <param name="SecuritySettingsLen">The size, in bytes, of the <c>SecuritySettings</c> parameter.</param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>. This error is
	/// also returned if the SOCKET_SECURITY_SETTINGS structure pointed to by the <c>SecuritySettings</c> parameter has an incorrect value.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEISCONN</c></term>
	/// <term>
	/// The socket is connected. This function is not permitted with a connected socket, whether the socket is connection oriented or connectionless.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The primary purpose of the <c>WSASetSocketSecurity</c> function is to turn on security for a socket if it is not already enabled by
	/// administrative policy. For IPsec, this means that appropriate IPsec filters and policies will be instantiated that will be used to
	/// secure this socket. the <c>WSASetSocketSecurity</c> function can also be used to set specific security requirements for the socket.
	/// </para>
	/// <para>This function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c> parameter set to <c>SIO_SET_SECURITY</c>.</para>
	/// <para>
	/// The <c>WSASetSocketSecurity</c> function may be called on a <c>Socket</c> parameter created with an address family of <c>AF_INET</c>
	/// or <c>AF_INET6</c>.
	/// </para>
	/// <para>
	/// For a client application using connection-oriented sockets (protocol of <c>IPPROTO_TCP</c>), the <c>WSASetSocketSecurity</c> function
	/// should be called before the connect, ConnectEx, or WSAConnect function is called. If the <c>WSASetSocketSecurity</c> function is
	/// called after the <c>connect</c>, <c>ConnectEx</c>, or <c>WSAConnect</c> function, <c>WSASetSocketSecurity</c> should fail.
	/// </para>
	/// <para>
	/// For a server application using connection-oriented sockets (protocol of <c>IPPROTO_TCP</c>), the <c>WSASetSocketSecurity</c> function
	/// should be called before the bind function is called. If the <c>WSASetSocketSecurity</c> function is called after the <c>bind</c>
	/// function, <c>WSASetSocketSecurity</c> should fail.
	/// </para>
	/// <para>
	/// For connectionless sockets (protocol of <c>IPPROTO_UDP</c>), the application should call the <c>WSASetSocketSecurity</c> function
	/// immediately after socket or WSASocket call returns.
	/// </para>
	/// <para>
	/// Server applications should call the setsockopt function to acquire exclusive access to the port used by the socket. This prevents
	/// other applications from using the same port. The <c>setsockopt</c> function would be called with the <c>level</c> parameter set to
	/// SOL_SOCKET, the <c>optname</c> parameter set to SO_EXCLUSIVEADDRUSE, and the <c>value</c> parameter set to nonzero. The
	/// <c>WSASetSocketSecurity</c> function internally calls the <c>setsockopt</c> with SO_EXCLUSIVEADDRUSE to obtain exclusive access to
	/// the port. This is to ensure that the socket is not vulnerable to attacks by other applications running on the local computer.
	/// </para>
	/// <para>
	/// Security settings not set using the <c>WSASetSocketSecurity</c> are derived from the system default policy or the administratively
	/// configured policy. It is recommended that most applications specify a value of <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c> for the
	/// SOCKET_SECURITY_PROTOCOL enumeration in the <c>SecurityProtocol</c> member of the <c>SOCKET_SECURITY_PROTOCOL</c> pointed to by the
	/// <c>SecuritySettings</c> parameter. This makes the application neutral to security protocols and allows easier deployments among
	/// different systems.
	/// </para>
	/// <para>
	/// When the <c>SecuritySettings</c> parameter points to a SOCKET_SECURITY_SETTINGS_IPSEC structure, the <c>SecurityProtocol</c> member
	/// of the structure must be set to <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c>, not <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c>.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// <item>
	/// <term>The application must set its security settings before calling the bind, connect, ConnectEx, or WSAConnect functions.</term>
	/// </item>
	/// <item>
	/// <term>The <c>WSASetSocketSecurity</c> function can only be called once per socket.</term>
	/// </item>
	/// </list>
	/// <para>Default Secure Socket IPsec Policy</para>
	/// <para>
	/// If the <c>SecuritySettings</c> parameter is set to <c>NULL</c>, and there is no other administratively specified IPsec policy on the
	/// computer, a default security policy based on IPsec will be used to secure the application's traffic. Some type of authentication
	/// credential (a user certificate or domain membership, for example) must be present for IPsec to succeed with a default policy.
	/// </para>
	/// <para>The default IPsec policy has been designed so that IPsec security can be negotiated in as many scenarios as possible.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsasetsocketsecurity INT WSAAPI WSASetSocketSecurity( [in]
	// SOCKET Socket, [in, optional] const SOCKET_SECURITY_SETTINGS *SecuritySettings, [in] ULONG SecuritySettingsLen, [in, optional]
	// LPWSAOVERLAPPED Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSASetSocketSecurity")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSASetSocketSecurity([In] SOCKET Socket, in SOCKET_SECURITY_SETTINGS SecuritySettings,
		uint SecuritySettingsLen, in WSAOVERLAPPED Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);

	/// <summary>The <c>WSASetSocketSecurity</c> function enables and applies security for a socket.</summary>
	/// <param name="Socket">A descriptor that identifies a socket on which security settings are being applied.</param>
	/// <param name="SecuritySettings">
	/// A pointer to a SOCKET_SECURITY_SETTINGS structure that specifies the security settings to be applied to the socket's traffic. If this
	/// parameter is <c>NULL</c>, default settings will be applied to the socket.
	/// </param>
	/// <param name="SecuritySettingsLen">The size, in bytes, of the <c>SecuritySettings</c> parameter.</param>
	/// <param name="Overlapped">A pointer to a WSAOVERLAPPED structure. This parameter is ignored for non-overlapped sockets.</param>
	/// <param name="CompletionRoutine">
	/// A pointer to the completion routine called when the operation has been completed. This parameter is ignored for non-overlapped sockets.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is zero. Otherwise, a value of <c>SOCKET_ERROR</c> is returned, and a specific error code
	/// can be retrieved by calling WSAGetLastError.
	/// </para>
	/// <para>Some possible error codes are listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WSAEAFNOSUPPORT</c></term>
	/// <term>The specified address family is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAEINVAL</c></term>
	/// <term>
	/// An invalid parameter was passed. This error is returned if the socket passed in the <c>Socket</c> parameter was not created with an
	/// address family of the <c>AF_INET</c> or <c>AF_INET6</c> and a socket type of <c>SOCK_DGRAM</c> or <c>SOCK_STREAM</c>. This error is
	/// also returned if the SOCKET_SECURITY_SETTINGS structure pointed to by the <c>SecuritySettings</c> parameter has an incorrect value.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEISCONN</c></term>
	/// <term>
	/// The socket is connected. This function is not permitted with a connected socket, whether the socket is connection oriented or connectionless.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WSAEMSGSIZE</c></term>
	/// <term>A buffer passed was too small.</term>
	/// </item>
	/// <item>
	/// <term><c>WSAENOTSOCK</c></term>
	/// <term>The descriptor passed in the <c>Socket</c> parameter is not a valid socket.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The primary purpose of the <c>WSASetSocketSecurity</c> function is to turn on security for a socket if it is not already enabled by
	/// administrative policy. For IPsec, this means that appropriate IPsec filters and policies will be instantiated that will be used to
	/// secure this socket. the <c>WSASetSocketSecurity</c> function can also be used to set specific security requirements for the socket.
	/// </para>
	/// <para>This function simplifies having to call the WSAIoctl function with a <c>dwIoControlCode</c> parameter set to <c>SIO_SET_SECURITY</c>.</para>
	/// <para>
	/// The <c>WSASetSocketSecurity</c> function may be called on a <c>Socket</c> parameter created with an address family of <c>AF_INET</c>
	/// or <c>AF_INET6</c>.
	/// </para>
	/// <para>
	/// For a client application using connection-oriented sockets (protocol of <c>IPPROTO_TCP</c>), the <c>WSASetSocketSecurity</c> function
	/// should be called before the connect, ConnectEx, or WSAConnect function is called. If the <c>WSASetSocketSecurity</c> function is
	/// called after the <c>connect</c>, <c>ConnectEx</c>, or <c>WSAConnect</c> function, <c>WSASetSocketSecurity</c> should fail.
	/// </para>
	/// <para>
	/// For a server application using connection-oriented sockets (protocol of <c>IPPROTO_TCP</c>), the <c>WSASetSocketSecurity</c> function
	/// should be called before the bind function is called. If the <c>WSASetSocketSecurity</c> function is called after the <c>bind</c>
	/// function, <c>WSASetSocketSecurity</c> should fail.
	/// </para>
	/// <para>
	/// For connectionless sockets (protocol of <c>IPPROTO_UDP</c>), the application should call the <c>WSASetSocketSecurity</c> function
	/// immediately after socket or WSASocket call returns.
	/// </para>
	/// <para>
	/// Server applications should call the setsockopt function to acquire exclusive access to the port used by the socket. This prevents
	/// other applications from using the same port. The <c>setsockopt</c> function would be called with the <c>level</c> parameter set to
	/// SOL_SOCKET, the <c>optname</c> parameter set to SO_EXCLUSIVEADDRUSE, and the <c>value</c> parameter set to nonzero. The
	/// <c>WSASetSocketSecurity</c> function internally calls the <c>setsockopt</c> with SO_EXCLUSIVEADDRUSE to obtain exclusive access to
	/// the port. This is to ensure that the socket is not vulnerable to attacks by other applications running on the local computer.
	/// </para>
	/// <para>
	/// Security settings not set using the <c>WSASetSocketSecurity</c> are derived from the system default policy or the administratively
	/// configured policy. It is recommended that most applications specify a value of <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c> for the
	/// SOCKET_SECURITY_PROTOCOL enumeration in the <c>SecurityProtocol</c> member of the <c>SOCKET_SECURITY_PROTOCOL</c> pointed to by the
	/// <c>SecuritySettings</c> parameter. This makes the application neutral to security protocols and allows easier deployments among
	/// different systems.
	/// </para>
	/// <para>
	/// When the <c>SecuritySettings</c> parameter points to a SOCKET_SECURITY_SETTINGS_IPSEC structure, the <c>SecurityProtocol</c> member
	/// of the structure must be set to <c>SOCKET_SECURITY_PROTOCOL_IPSEC</c>, not <c>SOCKET_SECURITY_PROTOCOL_DEFAULT</c>.
	/// </para>
	/// <para>An error will be returned if the following conditions are not met.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The address family of the <c>Socket</c> parameter must be either AF_INET or AF_INET6.</term>
	/// </item>
	/// <item>
	/// <term>The socket type must be either SOCK_STREAM or SOCK_DGRAM.</term>
	/// </item>
	/// <item>
	/// <term>The application must set its security settings before calling the bind, connect, ConnectEx, or WSAConnect functions.</term>
	/// </item>
	/// <item>
	/// <term>The <c>WSASetSocketSecurity</c> function can only be called once per socket.</term>
	/// </item>
	/// </list>
	/// <para>Default Secure Socket IPsec Policy</para>
	/// <para>
	/// If the <c>SecuritySettings</c> parameter is set to <c>NULL</c>, and there is no other administratively specified IPsec policy on the
	/// computer, a default security policy based on IPsec will be used to secure the application's traffic. Some type of authentication
	/// credential (a user certificate or domain membership, for example) must be present for IPsec to succeed with a default policy.
	/// </para>
	/// <para>The default IPsec policy has been designed so that IPsec security can be negotiated in as many scenarios as possible.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-wsasetsocketsecurity INT WSAAPI WSASetSocketSecurity( [in]
	// SOCKET Socket, [in, optional] const SOCKET_SECURITY_SETTINGS *SecuritySettings, [in] ULONG SecuritySettingsLen, [in, optional]
	// LPWSAOVERLAPPED Overlapped, [in, optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine );
	[PInvokeData("ws2tcpip.h", MSDNShortId = "NF:ws2tcpip.WSASetSocketSecurity")]
	[DllImport(Lib_Fwpuclnt, SetLastError = true, ExactSpelling = true)]
	public static extern WSRESULT WSASetSocketSecurity([In] SOCKET Socket, [In, Optional] IntPtr SecuritySettings,
		uint SecuritySettingsLen, [In, Optional] IntPtr Overlapped, [In, Optional] LPWSAOVERLAPPED_COMPLETION_ROUTINE CompletionRoutine);
}