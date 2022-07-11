#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
		/// <summary>An optional pointer to a function to be invoked upon successful completion for asynchronous operations.</summary>
		/// <param name="dwError">Set to a Winsock error code.</param>
		/// <param name="dwBytes">Reserved for future use and must be ignored.</param>
		/// <param name="lpOverlapped">
		/// the value of lpOverlapped parameter passed to GetAddrInfoEx. The Pointer member of the OVERLAPPED structure will be set to the
		/// value of the ppResult parameter of the original call. If the Pointer member points to a non-NULL pointer to the addrinfoex
		/// structure, it is the caller’s responsibility to call FreeAddrInfoEx to free the addrinfoex structure.
		/// </param>
		[PInvokeData("ws2tcpip.h", MSDNShortId = "cc4ccb2d-ea5a-48bd-a3ae-f70432ab2c39")]
		public unsafe delegate void LPLOOKUPSERVICE_COMPLETION_ROUTINE(uint dwError, uint dwBytes, NativeOverlapped* lpOverlapped);

		/// <summary>
		/// The <c>FreeAddrInfoEx</c> function frees address information that the GetAddrInfoEx function dynamically allocates in addrinfoex structures.
		/// </summary>
		/// <param name="pAddrInfoEx">
		/// A pointer to the addrinfoex structure or linked list of <c>addrinfoex</c> structures to be freed. All dynamic storage pointed to
		/// within the <c>addrinfoex</c> structure or structures is also freed.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// The <c>FreeAddrInfoEx</c> function frees addrinfoex structures dynamically allocated by the GetAddrInfoEx function. The
		/// <c>FreeAddrInfoEx</c> function frees the initial <c>addrinfoex</c> structure pointed to in the pAddrInfo parameter, including
		/// any buffers to which structure members point, then continues freeing any <c>addrinfoex</c> structures linked by the
		/// <c>ai_next</c> member of the <c>addrinfoex</c> structure. The <c>FreeAddrInfoEx</c> function continues freeing linked structures
		/// until a <c>NULL</c><c>ai_next</c> member is encountered.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>FreeAddrInfoEx</c> is defined to <c>FreeAddrInfoExW</c>, the Unicode version of the
		/// function, and <c>ADDRINFOEX</c> is defined to the addrinfoexW structure. When UNICODE or _UNICODE is not defined,
		/// <c>FreeAddrInfoEx</c> is defined to <c>FreeAddrInfoExA</c>, the ANSI version of the function, and <c>ADDRINFOEX</c> is defined
		/// to the <c>addrinfoexA</c> structure.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>FreeAddrInfoExW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-freeaddrinfoex void WSAAPI FreeAddrInfoEx( PADDRINFOEXA
		// pAddrInfoEx );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "bc3d7ba7-ec00-4ee0-ad7d-d46641043a7b")]
		public static extern void FreeAddrInfoExW(IntPtr pAddrInfoEx);

		/// <summary>
		/// The <c>FreeAddrInfoW</c> function frees address information that the GetAddrInfoW function dynamically allocates in addrinfoW structures.
		/// </summary>
		/// <param name="pAddrInfo">
		/// A pointer to the addrinfoW structure or linked list of <c>addrinfoW</c> structures to be freed. All dynamic storage pointed to
		/// within the <c>addrinfoW</c> structure or structures is also freed.
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>FreeAddrInfoW</c> function frees addrinfoW structures dynamically allocated by the Unicode GetAddrInfoW function. The
		/// <c>FreeAddrInfoW</c> function frees the initial <c>addrinfoW</c> structure pointed to in the pAddrInfo parameter, including any
		/// buffers to which structure members point, then continues freeing any <c>addrinfoW</c> structures linked by the <c>ai_next</c>
		/// member of the <c>addrinfoW</c> structure. The <c>FreeAddrInfoW</c> function continues freeing linked structures until a
		/// <c>NULL</c><c>ai_next</c> member is encountered.
		/// </para>
		/// <para>
		/// Macros in the Winsock header file define a mixed-case function name of <c>FreeAddrInfo</c> and an <c>ADDRINFOT</c> structure.
		/// This <c>FreeAddrInfo</c> function should be called with the pAddrInfo parameter of a pointer of type <c>ADDRINFOT</c>. When
		/// UNICODE or _UNICODE is defined, <c>FreeAddrInfo</c> is defined to <c>FreeAddrInfoW</c>, the Unicode version of the function, and
		/// <c>ADDRINFOT</c> is defined to the addrinfoW structure. When UNICODE or _UNICODE is not defined, <c>FreeAddrInfo</c> is defined
		/// to freeaddrinfo, the ANSI version of the function, and <c>ADDRINFOT</c> is defined to the addrinfo structure.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-freeaddrinfow VOID WSAAPI FreeAddrInfoW( PADDRINFOW
		// pAddrInfo );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "0a2a226c-2068-4538-b499-04cfbfd65b8a")]
		public static extern void FreeAddrInfoW(IntPtr pAddrInfo);

		/// <summary>
		/// The <c>gai_strerror</c> function assists in printing error messages based on the EAI_* errors returned by the getaddrinfo
		/// function. Note that the <c>gai_strerror</c> function is not thread safe, and therefore, use of traditional Windows Sockets
		/// functions such as the WSAGetLastError function is recommended.
		/// </summary>
		/// <param name="ecode">
		/// Error code from the list of available getaddrinfo error codes. For a complete listing of error codes, see the <c>getaddrinfo</c> function.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// If the ecode parameter is not an error code value that getaddrinfo returns, the <c>gai_strerror</c> function returns a pointer
		/// to a string that indicates an unknown error.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-gai_strerrora char * gai_strerrorA( int ecode );
		[PInvokeData("ws2tcpip.h", MSDNShortId = "00b4c5de-89c9-419f-bff8-822ef0446697")]
		public static string gai_strerror(int ecode) =>
			Kernel32.FormatMessage((uint)ecode, flags: Kernel32.FormatMessageFlags.FORMAT_MESSAGE_MAX_WIDTH_MASK);

		/// <summary>The <c>GetAddrInfoExCancel</c> function cancels an asynchronous operation by the GetAddrInfoEx function.</summary>
		/// <param name="lpHandle">
		/// The handle of the asynchronous operation to cancel. This is the handle returned in the lpNameHandle parameter by the
		/// GetAddrInfoEx function.
		/// </param>
		/// <returns>
		/// On success, <c>GetAddrInfoExCancel</c> returns <c>NO_ERROR</c> (0). Failure returns a nonzero Windows Sockets error code, as
		/// found in the Windows Sockets Error Codes.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetAddrInfoExCancel</c> function cancels an asynchronous GetAddrInfoEx operation. The result is that the user's
		/// completion mechanism, either a callback or an event, is immediately invoked. No results are returned, and the error code
		/// returned for the <c>GetAddrInfoEx</c> asynchronous operation is set to <c>WSA_E_CANCELLED</c>. If the <c>GetAddrInfoEx</c>
		/// request has already completed or timed out, or the handle is invalid, and <c>WSA_INVALID_HANDLE</c> will be returned by
		/// <c>GetAddrInfoExCancel</c> function.
		/// </para>
		/// <para>
		/// Since many of the underlying operations (legacy name service providers, for example) are synchronous, these operations will not
		/// actually be cancelled. These operations will continue running and consuming resources. Once the last outstanding name service
		/// provider request has completed, the resources will be released.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getaddrinfoexcancel INT WSAAPI GetAddrInfoExCancel(
		// LPHANDLE lpHandle );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "A4DE552D-DEA7-44F5-865F-5B02C9BB4AB6")]
		public static extern SocketError GetAddrInfoExCancel(in HANDLE lpHandle);

		/// <summary>
		/// The <c>GetAddrInfoExOverlappedResult</c> function gets the return code for an <c>OVERLAPPED</c> structure used by an
		/// asynchronous operation for the GetAddrInfoEx function.
		/// </summary>
		/// <param name="lpOverlapped">A pointer to an <c>OVERLAPPED</c> structure for the asynchronous operation.</param>
		/// <returns>
		/// On success, the <c>GetAddrInfoExOverlappedResult</c> function returns <c>NO_ERROR</c> (0). When the underlying operation hasn't
		/// yet completed, the <c>GetAddrInfoExOverlappedResult</c> function returns <c>WSAEINPROGRESS</c>. On failure, the
		/// <c>GetAddrInfoExOverlappedResult</c> function returns <c>WSAEINVAL</c>.
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetAddrInfoExOverlappedResult</c> function is used with the GetAddrInfoEx function for asynchronous operations.</para>
		/// <para>
		/// If the <c>GetAddrInfoExOverlappedResult</c> function returns <c>WSAEINVAL</c>, the only way to distinguish whether
		/// <c>GetAddrInfoExOverlappedResult</c> function or the asynchronous operation returned the error is to check that the lpOverlapped
		/// parameter was not NULL. If the lpOverlapped parameter was NULL, then the <c>GetAddrInfoExOverlappedResult</c> function was
		/// passed a NULL pointer and failed.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getaddrinfoexoverlappedresult INT WSAAPI
		// GetAddrInfoExOverlappedResult( LPOVERLAPPED lpOverlapped );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "BBA6E407-561C-4B3C-9218-0047477E82DE")]
		public static extern SocketError GetAddrInfoExOverlappedResult(IntPtr lpOverlapped);

		/// <summary>
		/// The <c>GetAddrInfoExOverlappedResult</c> function gets the return code for an <c>OVERLAPPED</c> structure used by an
		/// asynchronous operation for the GetAddrInfoEx function.
		/// </summary>
		/// <param name="lpOverlapped">A pointer to an <c>OVERLAPPED</c> structure for the asynchronous operation.</param>
		/// <returns>
		/// On success, the <c>GetAddrInfoExOverlappedResult</c> function returns <c>NO_ERROR</c> (0). When the underlying operation hasn't
		/// yet completed, the <c>GetAddrInfoExOverlappedResult</c> function returns <c>WSAEINPROGRESS</c>. On failure, the
		/// <c>GetAddrInfoExOverlappedResult</c> function returns <c>WSAEINVAL</c>.
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetAddrInfoExOverlappedResult</c> function is used with the GetAddrInfoEx function for asynchronous operations.</para>
		/// <para>
		/// If the <c>GetAddrInfoExOverlappedResult</c> function returns <c>WSAEINVAL</c>, the only way to distinguish whether
		/// <c>GetAddrInfoExOverlappedResult</c> function or the asynchronous operation returned the error is to check that the lpOverlapped
		/// parameter was not NULL. If the lpOverlapped parameter was NULL, then the <c>GetAddrInfoExOverlappedResult</c> function was
		/// passed a NULL pointer and failed.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getaddrinfoexoverlappedresult INT WSAAPI
		// GetAddrInfoExOverlappedResult( LPOVERLAPPED lpOverlapped );
		[DllImport(Lib.Ws2_32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "BBA6E407-561C-4B3C-9218-0047477E82DE")]
		public static unsafe extern SocketError GetAddrInfoExOverlappedResult(NativeOverlapped* lpOverlapped);

		/// <summary>
		/// The <c>GetAddrInfoEx</c> function provides protocol-independent name resolution with additional parameters to qualify which
		/// namespace providers should handle the request.
		/// </summary>
		/// <param name="pName">
		/// A pointer to a <c>NULL</c>-terminated string containing a host (node) name or a numeric host address string. For the Internet
		/// protocol, the numeric host address string is a dotted-decimal IPv4 address or an IPv6 hex address.
		/// </param>
		/// <param name="pServiceName">
		/// <para>
		/// A pointer to an optional <c>NULL</c>-terminated string that contains either a service name or port number represented as a string.
		/// </para>
		/// <para>
		/// A service name is a string alias for a port number. For example, “http” is an alias for port 80 defined by the Internet
		/// Engineering Task Force (IETF) as the default port used by web servers for the HTTP protocol. Possible values for the
		/// pServiceName parameter when a port number is not specified are listed in the following file:
		/// </para>
		/// <para><c>%WINDIR%\system32\drivers\etc\services</c></para>
		/// </param>
		/// <param name="dwNameSpace">
		/// <para>
		/// An optional namespace identifier that determines which namespace providers are queried. Passing a specific namespace identifier
		/// will result in only namespace providers that support the specified namespace being queried. Specifying <c>NS_ALL</c> will result
		/// in all installed and active namespace providers being queried.
		/// </para>
		/// <para>
		/// Options for the dwNameSpace parameter are listed in the Winsock2.h include file. Several namespace providers are added on
		/// Windows Vista and later. Other namespace providers can be installed, so the following possible values are only those commonly
		/// available. Many other values are possible.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NS_ALL 0</term>
		/// <term>All installed and active namespaces.</term>
		/// </item>
		/// <item>
		/// <term>NS_DNS 12</term>
		/// <term>The domain name system (DNS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_NETBT 13</term>
		/// <term>The NetBIOS over TCP/IP (NETBT) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_WINS 14</term>
		/// <term>The Windows Internet Naming Service (NS_WINS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_NLA 15</term>
		/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_BTH 16</term>
		/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NTDS 32</term>
		/// <term>The Windows NT Directory Services (NS_NTDS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_EMAIL 37</term>
		/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPNAME 38</term>
		/// <term>The peer-to-peer namespace for a specific peer name. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD 39</term>
		/// <term>
		/// The peer-to-peer namespace for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpNspId">
		/// A pointer to an optional GUID of a specific namespace provider to query in the case where multiple namespace providers are
		/// registered under a single namespace such as <c>NS_DNS</c>. Passing the GUID for specific namespace provider will result in only
		/// the specified namespace provider being queried. The WSAEnumNameSpaceProviders function can be called to retrieve the GUID for a
		/// namespace provider.
		/// </param>
		/// <param name="hints">
		/// <para>A pointer to an addrinfoex structure that provides hints about the type of socket the caller supports.</para>
		/// <para>
		/// The <c>ai_addrlen</c>, <c>ai_canonname</c>, <c>ai_addr</c>, and <c>ai_next</c> members of the addrinfoex structure pointed to by
		/// the pHints parameter must be zero or <c>NULL</c>. Otherwise the <c>GetAddrInfoEx</c> function will fail with WSANO_RECOVERY.
		/// </para>
		/// <para>See the Remarks for more details.</para>
		/// </param>
		/// <param name="ppResult">
		/// A pointer to a linked list of one or more addrinfoex structures that contains response information about the host.
		/// </param>
		/// <param name="timeout">
		/// <para>
		/// An optional parameter indicating the time, in milliseconds, to wait for a response from the namespace provider before aborting
		/// the call.
		/// </para>
		/// <para>
		/// This parameter is only supported when the <c>UNICODE</c> or <c>_UNICODE</c> macro has been defined in the sources before calling
		/// the <c>GetAddrInfoEx</c> function. Otherwise, this parameter is currently reserved and must be set to <c>NULL</c> since a
		/// timeout option is not supported.
		/// </para>
		/// </param>
		/// <param name="lpOverlapped">
		/// <para>An optional pointer to an overlapped structure used for asynchronous operation.</para>
		/// <para>
		/// This parameter is only supported when the <c>UNICODE</c> or <c>_UNICODE</c> macro has been defined in the sources before calling
		/// the <c>GetAddrInfoEx</c> function.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, if no lpCompletionRoutine parameter is specified, the <c>hEvent</c> member of the
		/// <c>OVERLAPPED</c> structure must be set to a manual-reset event to be called upon completion of an asynchronous call. If a
		/// completion routine has been specified, the <c>hEvent</c> member must be NULL. When the event specified by <c>hEvent</c> has been
		/// set, the result of the operation can be retrieved by calling GetAddrInfoExOverlappedResult function.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012 whenever the <c>UNICODE</c> or <c>_UNICODE</c> macro is not defined, this parameter is
		/// currently reserved and must be set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// On Windows 7 and Windows Server 2008 R2 or earlier, this parameter is currently reserved and must be set to <c>NULL</c> since
		/// asynchronous operations are not supported.
		/// </para>
		/// </param>
		/// <param name="lpCompletionRoutine">
		/// <para>An optional pointer to a function to be invoked upon successful completion for asynchronous operations.</para>
		/// <para>
		/// This parameter is only supported when the <c>UNICODE</c> or <c>_UNICODE</c> macro has been defined in the sources before calling
		/// the <c>GetAddrInfoEx</c> function.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, if this parameter is specified, it must be a pointer to a function with the following signature:
		/// </para>
		/// <para>
		/// When the asynchronous operation has completed, the completion routine will be invoked with lpOverlapped parameter set to the
		/// value of lpOverlapped parameter passed to <c>GetAddrInfoEx</c>. The <c>Pointer</c> member of the OVERLAPPED structure will be
		/// set to the value of the ppResult parameter of the original call. If the <c>Pointer</c> member points to a non-NULL pointer to
		/// the addrinfoex structure, it is the caller’s responsibility to call FreeAddrInfoEx to free the <c>addrinfoex</c> structure. The
		/// dwError parameter passed to the completion routine will be set to a Winsock error code. The dwBytes parameter is reserved for
		/// future use and must be ignored.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012 whenever the <c>UNICODE</c> or <c>_UNICODE</c> macro is not defined, this parameter is
		/// currently reserved and must be set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// On Windows 7 and Windows Server 2008 R2 or earlier, this parameter is currently reserved and must be set to <c>NULL</c> since
		/// asynchronous operations are not supported.
		/// </para>
		/// </param>
		/// <param name="lpNameHandle">
		/// <para>An optional pointer used only for asynchronous operations.</para>
		/// <para>
		/// This parameter is only supported when the <c>UNICODE</c> or <c>_UNICODE</c> macro has been defined in the sources before calling
		/// the <c>GetAddrInfoEx</c> function.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, if the <c>GetAddrInfoEx</c> function will complete asynchronously, the pointer returned in
		/// this field may be used with the <c>GetAddrInfoExCancel</c> function. The handle returned is valid when <c>GetAddrInfoEx</c>
		/// returns until the completion routine is called, the event is triggered, or GetAddrInfoExCancel function is called with this handle.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012 whenever the <c>UNICODE</c> or <c>_UNICODE</c> macro is not defined, this parameter is
		/// currently reserved and must be set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// On Windows 7 and Windows Server 2008 R2 or earlier, this parameter is currently reserved and must be set to <c>NULL</c> since
		/// asynchronous operations are not supported.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>GetAddrInfoEx</c> returns <c>NO_ERROR</c> (0). Failure returns a nonzero Windows Sockets error code, as found in
		/// the Windows Sockets Error Codes.
		/// </para>
		/// <para>
		/// Most nonzero error codes returned by the <c>GetAddrInfoEx</c> function map to the set of errors outlined by Internet Engineering
		/// Task Force (IETF) recommendations. The following table shows these error codes and their WSA equivalents. It is recommended that
		/// the WSA error codes be used, as they offer familiar and comprehensive error information for Winsock programmers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error value</term>
		/// <term>WSA equivalent</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>EAI_AGAIN</term>
		/// <term>WSATRY_AGAIN</term>
		/// <term>A temporary failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_BADFLAGS</term>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid parameter was provided. This error is returned if any of the reserved parameters are not NULL. This error is also
		/// returned if an invalid value was provided for the ai_flags member of the pHints parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EAI_FAIL</term>
		/// <term>WSANO_RECOVERY</term>
		/// <term>A nonrecoverable failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_FAMILY</term>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>The ai_family member of the pHints parameter is not supported.</term>
		/// </item>
		/// <item>
		/// <term>EAI_MEMORY</term>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_NONAME</term>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>The name does not resolve for the supplied parameters or the pName and pServiceName parameters were not provided.</term>
		/// </item>
		/// <item>
		/// <term>EAI_SERVICE</term>
		/// <term>WSATYPE_NOT_FOUND</term>
		/// <term>The pServiceName parameter is not supported for the specified ai_socktype member of the pHints parameter.</term>
		/// </item>
		/// <item>
		/// <term>EAI_SOCKTYPE</term>
		/// <term>WSAESOCKTNOSUPPORT</term>
		/// <term>The ai_socktype member of the pHints parameter is not supported.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Use the gai_strerror function to print error messages based on the EAI codes returned by the <c>GetAddrInfoEx</c> function. The
		/// <c>gai_strerror</c> function is provided for compliance with IETF recommendations, but it is not thread safe. Therefore, use of
		/// traditional Windows Sockets functions such as WSAGetLastError is recommended.
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
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// An address incompatible with the requested protocol was used. This error is returned if the ai_family member of the
		/// addrinfoexstructure pointed to by the pHints parameter is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid argument was supplied. This error is returned if an invalid value was provided for the ai_flags member of the
		/// addrinfoex structure pointed to by the pHints parameter. This error is also returned when the dwNameSpace parameter is
		/// NS_PNRPNAME or NS_PNRPCLOUD and the peer-to-peer name service is not operating.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAESOCKTNOSUPPORT</term>
		/// <term>
		/// The support for the specified socket type does not exist in this address family. This error is returned if the ai_socktype
		/// member of the addrinfoex structure pointed to by the pHints parameter is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>
		/// No such host is known. This error is returned if the name does not resolve for the supplied parameters or the pName and
		/// pServiceName parameters were not provided.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The requested name is valid, but no data of the requested type was found.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>
		/// A nonrecoverable error occurred during a database lookup. This error is returned if nonrecoverable error in name resolution occurred.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSASERVICE_NOT_FOUND</term>
		/// <term>
		/// No such service is known. The service cannot be found in the specified name space. This error is returned if the pName or
		/// pServiceName parameter is not found for the namespace specified in the dwNameSpace parameter or the namespace specified in the
		/// dwNameSpace parameter is not installed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>
		/// This is usually a temporary error during hostname resolution and means that the local server did not receive a response from an
		/// authoritative server. This error is returned when a temporary failure in name resolution occurred.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSATYPE_NOT_FOUND</term>
		/// <term>
		/// The specified class was not found. The pServiceName parameter is not supported for the specified ai_socktype member of the
		/// addrinfoexstructure pointed to by the pHints parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetAddrInfoEx</c> function provides protocol-independent translation from host name to address and from service name to
		/// port number. The <c>GetAddrInfoEx</c> function is an enhanced version of the getaddrinfo and GetAddrInfoW functions. The
		/// <c>GetAddrInfoEx</c> function allows specifying the namespace provider to resolve the query.
		/// </para>
		/// <para>
		/// The <c>GetAddrInfoEx</c> function aggregates and returns results from multiple namespace providers, unless a specific namespace
		/// provider is specified. For use with the IPv6 and IPv4 protocol, name resolution can be by the Domain Name System (DNS), a local
		/// hosts file, an email provider (the <c>NS_EMAIL</c> namespace), or by other naming mechanisms.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>GetAddrInfoEx</c> is defined to <c>GetAddrInfoExW</c>, the Unicode version of this
		/// function. The string parameters are defined to the <c>PWSTR</c> data type and the <c>ADDRINFOEXW</c> structure is used. On
		/// Windows 8 and Windows Server 2012, the timeout, lpOverlapped, lpCompletionRoutine, and lpNameHandle parameters may be used to
		/// call the <c>GetAddrInfoEx</c> function so that it can complete asynchronously.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>GetAddrInfoEx</c> is defined to <c>GetAddrInfoExA</c>, the ANSI version of this
		/// function. The string parameters are of the <c>PCSTR</c> data type and the <c>ADDRINFOEXA</c> structure is used. The timeout,
		/// lpOverlapped, lpCompletionRoutine, and lpNameHandle parameters must be set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// One or both of the pName or pServiceName parameters must point to a <c>NULL</c>-terminated string. Generally both are provided.
		/// </para>
		/// <para>
		/// Upon success, a linked list of addrinfoex structures is returned in the ppResult parameter. The list can be processed by
		/// following the pointer provided in the <c>ai_next</c> member of each returned <c>addrinfoex</c> structure until a <c>NULL</c>
		/// pointer is encountered. In each returned <c>addrinfoex</c> structure, the <c>ai_family</c>, <c>ai_socktype</c>, and
		/// <c>ai_protocol</c> members correspond to respective arguments in a socket or WSASocket function call. Also, the <c>ai_addr</c>
		/// member in each returned <c>addrinfoex</c> structure points to a filled-in socket address structure, the length of which is
		/// specified in its <c>ai_addrlen</c> member.
		/// </para>
		/// <para>
		/// If the pName parameter points to a computer name, all permanent addresses for the computer that can be used as a source address
		/// are returned. On Windows Vista and later, these addresses would include all unicast IP addresses returned by the
		/// GetUnicastIpAddressTable or GetUnicastIpAddressEntry functions in which the <c>SkipAsSource</c> member is set to false in the
		/// MIB_UNICASTIPADDRESS_ROW structure.
		/// </para>
		/// <para>If the pName parameter points to a string equal to "localhost", all loopback addresses on the local computer are returned.</para>
		/// <para>If the pName parameter contains an empty string, all registered addresses on the local computer are returned.</para>
		/// <para>
		/// On Windows Server 2003 and later if the pName parameter points to a string equal to "..localmachine", all registered addresses
		/// on the local computer are returned.
		/// </para>
		/// <para>
		/// If the pName parameter refers to a cluster virtual server name, only virtual server addresses are returned. On Windows Vista and
		/// later, these addresses would include all unicast IP addresses returned by the GetUnicastIpAddressTable or
		/// GetUnicastIpAddressEntry functions in which the <c>SkipAsSource</c> member is set to true in the MIB_UNICASTIPADDRESS_ROW
		/// structure. See Windows Clustering for more information about clustering.
		/// </para>
		/// <para>
		/// Windows 7 with Service Pack 1 (SP1) and Windows Server 2008 R2 with Service Pack 1 (SP1) add support to Netsh.exe for setting
		/// the SkipAsSource attribute on an IP address. This also changes the behavior such that if the <c>SkipAsSource</c> member in the
		/// MIB_UNICASTIPADDRESS_ROW structure is set to false, the IP address will be registered in DNS. If the <c>SkipAsSource</c> member
		/// is set to true, the IP address is not registered in DNS.
		/// </para>
		/// <para>
		/// A hotfix is available for Windows 7 and Windows Server 2008 R2 that adds support to Netsh.exe for setting the SkipAsSource
		/// attribute on an IP address. This hotfix also changes behavior such that if the <c>SkipAsSource</c> member in the
		/// MIB_UNICASTIPADDRESS_ROW structure is set to false, the IP address will be registered in DNS. If the <c>SkipAsSource</c> member
		/// is set to true, the IP address is not registered in DNS. For more information, see Knowledge Base (KB) 2386184.
		/// </para>
		/// <para>
		/// A similar hotfix is also available for Windows Vista with Service Pack 2 (SP2) and Windows Server 2008 with Service Pack 2 (SP2)
		/// that adds support to Netsh.exe for setting the SkipAsSource attribute on an IP address. This hotfix also changes behavior such
		/// that if the <c>SkipAsSource</c> member in the MIB_UNICASTIPADDRESS_ROW structure is set to false, the IP address will be
		/// registered in DNS. If the <c>SkipAsSource</c> member is set to true, the IP address is not registered in DNS. For more
		/// information, see Knowledge Base (KB) 975808.
		/// </para>
		/// <para>
		/// Callers of the <c>GetAddrInfoEx</c> function can provide hints about the type of socket supported through an addrinfoex
		/// structure pointed to by the pHints parameter. When the pHints parameter is used, the following rules apply to its associated
		/// <c>addrinfoex</c> structure:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// A value of <c>AF_UNSPEC</c> for <c>ai_family</c> indicates the caller will accept only the <c>AF_INET</c> and <c>AF_INET6</c>
		/// address families. Note that <c>AF_UNSPEC</c> and <c>PF_UNSPEC</c> are the same.
		/// </term>
		/// </item>
		/// <item>
		/// <term>A value of zero for <c>ai_socktype</c> indicates the caller will accept any socket type.</term>
		/// </item>
		/// <item>
		/// <term>A value of zero for <c>ai_protocol</c> indicates the caller will accept any protocol.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_addrlen</c> member must be set to zero.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_canonname</c> member must be set to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_addr</c> member must be set to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_next</c> member must be set to <c>NULL</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Other values in the addrinfoex structure provided in the pHints parameter indicate specific requirements. For example, if the
		/// caller handles only IPv4 and does not handle IPv6, the <c>ai_family</c> member should be set to <c>AF_INET</c>. For another
		/// example, if the caller handles only TCP and does not handle UDP, the <c>ai_socktype</c> member should be set to <c>SOCK_STREAM</c>.
		/// </para>
		/// <para>
		/// If the pHints parameter is a <c>NULL</c> pointer, the <c>GetAddrInfoEx</c> function treats it as if the addrinfoex structure in
		/// pHints were initialized with its <c>ai_family</c> member set to <c>AF_UNSPEC</c> and all other members set to <c>NULL</c> or zero.
		/// </para>
		/// <para>
		/// When <c>GetAddrInfoEx</c> is called from a service, if the operation is the result of a user process calling the service, the
		/// service should impersonate the user. This is to allow security to be properly enforced.
		/// </para>
		/// <para>
		/// The <c>GetAddrInfoEx</c> function can be used to convert a text string representation of an IP address to an addrinfoexstructure
		/// that contains a sockaddr structure for the IP address and other information. To be used in this way, the string pointed to by
		/// the pName parameter must contain a text representation of an IP address and the <c>addrinfoex</c> structure pointed to by the
		/// pHints parameter must have the AI_NUMERICHOST flag set in the <c>ai_flags</c> member. The string pointed to by the pName
		/// parameter may contain a text representation of either an IPv4 or an IPv6 address. The text IP address is converted to an
		/// <c>addrinfoex</c> structure pointed to by the ppResult parameter. The returned <c>addrinfoex</c> structure contains a
		/// <c>sockaddr</c> structure for the IP address along with additional information about the IP address.
		/// </para>
		/// <para>
		/// Multiple namespace providers may be installed on a local computer for the same namespace. For example, the base Windows TCP/IP
		/// networking software registers for the NS_DNS namespace. The Microsoft Forefront Threat Management Gateway (TMG) and the older
		/// Microsoft Internet Security and Acceleration (ISA) Server include Firewall Client software that also registers for the NS_DNS
		/// namespace. When the dwNameSpace parameter is set to a value (NS_DNS, for example) and the lpNspId parameter is <c>NULL</c>, the
		/// results returned by the <c>GetAddrInfoEx</c> function are the merged results from all namespace providers that register for the
		/// specified namespace with duplicate results eliminated. The lpNspId parameter should be set to the GUID of the specific namespace
		/// provider if only a single namespace provider is to be queried.
		/// </para>
		/// <para>
		/// If the pNameSpace parameter is set to NS_ALL, then the results from querying all namespace providers is merged and returned. In
		/// this case, duplicate responses may be returned in the results pointed to by the ppResult parameter if multiple namespace
		/// providers return the same information.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, if the <c>GetAddrInfoEx</c> function will complete asynchronously, the pointer returned in
		/// the lpNameHandle parameter may be used with the <c>GetAddrInfoExCancel</c> function. The handle returned is valid when
		/// <c>GetAddrInfoEx</c> returns until the completion routine is called, the event is triggered, or GetAddrInfoExCancel function is
		/// called with this handle.
		/// </para>
		/// <para>Freeing Address Information from Dynamic Allocation</para>
		/// <para>
		/// All information returned by the <c>GetAddrInfoEx</c> function pointed to by the ppResult parameter is dynamically allocated,
		/// including all addrinfoex structures, socket address structures, and canonical host name strings pointed to by <c>addrinfoex</c>
		/// structures. Memory allocated by a successful call to this function must be released with a subsequent call to FreeAddrInfoEx.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>GetAddrInfoEx</c> function.</para>
		/// <para>
		/// The following example demonstrates how to use the <c>GetAddrInfoEx</c> function asynchronous to resolve a name to an IP address..
		/// </para>
		/// <para>
		/// <c>Note</c> Ensure that the development environment targets the newest version of Ws2tcpip.h which includes structure and
		/// function definitions for addrinfoex and <c>GetAddrInfoEx</c>, respectively.
		/// </para>
		/// <para>Internationalized Domain Names</para>
		/// <para>Internet host names typically consist of a very restricted set of characters:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Upper and lower case ASCII letters from the English alphabet.</term>
		/// </item>
		/// <item>
		/// <term>Digits from 0 to 9.</term>
		/// </item>
		/// <item>
		/// <term>ASCII hyphen characters.</term>
		/// </item>
		/// </list>
		/// <para>
		/// With the growth of the Internet, there is a growing need to identify Internet host names for other languages not represented by
		/// the ASCII character set. Identifiers which facilitate this need and allow non-ASCII characters (Unicode) to be represented as
		/// special ASCII character strings are known as Internationalized Domain Names (IDNs). A mechanism called Internationalizing Domain
		/// Names in Applications (IDNA) is used to handle IDNs in a standard fashion. The specifications for IDNs and IDNA are documented
		/// in RFC 3490, RTF 5890, and RFC 6365 published by the Internet Engineering Task Force (IETF).
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, the <c>GetAddrInfoEx</c> function provides support for Internationalized Domain Name (IDN)
		/// parsing applied to the name passed in the pName parameter. Winsock performs Punycode/IDN encoding and conversion. This behavior
		/// can be disabled using the <c>AI_DISABLE_IDN_ENCODING</c> flag discussed below.
		/// </para>
		/// <para>
		/// On Windows 7 and Windows Server 2008 R2 or earlier, the <c>GetAddrInfoEx</c> function does not currently provide support for IDN
		/// parsing applied to the name passed in the pName parameter. The wide character version of the <c>GetAddrInfoEx</c> function does
		/// not use Punycode to convert an IDN Punycode format as per RFC 3490. The wide character version of the <c>GetAddrInfoEx</c>
		/// function when querying DNS encodes the Unicode name in UTF-8 format, the format used by Microsoft DNS servers in an enterprise environment.
		/// </para>
		/// <para>
		/// Several functions on Windows Vista and later support conversion between Unicode labels in an IDN to their ASCII equivalents. The
		/// resulting representation of each Unicode label contains only ASCII characters and starts with the xn-- prefix if the Unicode
		/// label contained any non-ASCII characters. The reason for this is to support existing DNS servers on the Internet, since some DNS
		/// tools and servers only support ASCII characters (see RFC 3490).
		/// </para>
		/// <para>
		/// The IdnToAscii function uses Punycode to convert an IDN to the ASCII representation of the original Unicode string using the
		/// standard algorithm defined in RFC 3490. The IdnToUnicode function converts the ASCII form of an IDN to the normal Unicode UTF-16
		/// encoding syntax. For more information and links to related draft standards, see Handling Internationalized Domain Names (IDNs).
		/// </para>
		/// <para>
		/// The IdnToAscii function can be used to convert an IDN name to an ASCII form that then can be passed in the pName parameter to
		/// the <c>GetAddrInfoEx</c> function when the ASCII version of this function is used (when UNICODE and _UNICODE are not defined).
		/// To pass this IDN name to the <c>GetAddrInfoEx</c> function when the wide character version of this function is used (when
		/// UNICODE or _UNICODE is defined), you can use the MultiByteToWideChar function to convert the <c>CHAR</c> string into a
		/// <c>WCHAR</c> string.
		/// </para>
		/// <para>Use of ai_flags in the hints parameter</para>
		/// <para>
		/// Flags in the <c>ai_flags</c> member of the optional addrinfoex structure provided in the hints parameter modify the behavior of
		/// the function.
		/// </para>
		/// <para>
		/// These flag bits are defined in the Ws2def.h header file on the Microsoft Windows Software Development Kit (SDK) for Windows 7.
		/// These flag bits are defined in the Ws2tcpip.h header file on the Windows SDK for Windows Server 2008 and Windows Vista. These
		/// flag bits are defined in the Ws2tcpip.h header file on the Platform Software Development Kit (SDK) for Windows Server 2003, and
		/// Windows XP.
		/// </para>
		/// <para>The flag bits can be a combination of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AI_PASSIVE</term>
		/// <term>
		/// Setting the AI_PASSIVE flag indicates the caller intends to use the returned socket address structure in a call to the bind
		/// function. When the AI_PASSIVE flag is set and pName is a NULL pointer, the IP address portion of the socket address structure is
		/// set to INADDR_ANY for IPv4 addresses and IN6ADDR_ANY_INIT for IPv6 addresses. When the AI_PASSIVE flag is not set, the returned
		/// socket address structure is ready for a call to the connect function for a connection-oriented protocol, or ready for a call to
		/// either the connect, sendto, or send functions for a connectionless protocol. If the pName parameter is a NULL pointer in this
		/// case, the IP address portion of the socket address structure is set to the loopback address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_CANONNAME</term>
		/// <term>
		/// If neither AI_CANONNAME nor AI_NUMERICHOST is used, the GetAddrInfoEx function attempts resolution. If a literal string is
		/// passed GetAddrInfoEx attempts to convert the string, and if a host name is passed the GetAddrInfoEx function attempts to resolve
		/// the name to an address or multiple addresses. When the AI_CANONNAME bit is set, the pName parameter cannot be NULL. Otherwise
		/// the GetAddrInfoEx function will fail with WSANO_RECOVERY. When the AI_CANONNAME bit is set and the GetAddrInfoEx function
		/// returns success, the ai_canonname member in the ppResult parameter points to a NULL-terminated string that contains the
		/// canonical name of the specified node.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICHOST</term>
		/// <term>
		/// When the AI_NUMERICHOST bit is set, the pName parameter must contain a non-NULL numeric host address string, otherwise the
		/// EAI_NONAME error is returned. This flag prevents a name resolution service from being called.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICSERV</term>
		/// <term>
		/// When the AI_NUMERICSERV bit is set, the pServiceName parameter must contain a non-NULL numeric port number, otherwise the
		/// EAI_NONAME error is returned. This flag prevents a name resolution service from being called. The AI_NUMERICSERV flag is defined
		/// on Windows SDK for Windows Vista and later. The AI_NUMERICSERV flag is not supported by Microsoft providers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ALL</term>
		/// <term>
		/// If the AI_ALL bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. The AI_ALL flag is defined
		/// on the Windows SDK for Windows Vista and later. The AI_ALL flag is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ADDRCONFIG</term>
		/// <term>
		/// If the AI_ADDRCONFIG bit is set, GetAddrInfoEx will resolve only if a global address is configured. If AI_ADDRCONFIG flag is
		/// specified, IPv4 addresses shall be returned only if an IPv4 address is configured on the local system, and IPv6 addresses shall
		/// be returned only if an IPv6 address is configured on the local system. The IPv4 or IPv6 loopback address is not considered a
		/// valid global address. The AI_ADDRCONFIG flag is defined on the Windows SDK for Windows Vista and later. The AI_ADDRCONFIG flag
		/// is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_V4MAPPED</term>
		/// <term>
		/// If the AI_V4MAPPED bit is set and a request for IPv6 addresses fails, a name service request is made for IPv4 addresses and
		/// these addresses are converted to IPv4-mapped IPv6 address format. The AI_V4MAPPED flag is defined on the Windows SDK for Windows
		/// Vista and later. The AI_V4MAPPED flag is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NON_AUTHORITATIVE</term>
		/// <term>
		/// If the AI_NON_AUTHORITATIVE bit is set, the NS_EMAIL namespace provider returns both authoritative and non-authoritative
		/// results. If the AI_NON_AUTHORITATIVE bit is not set, the NS_EMAIL namespace provider returns only authoritative results. The
		/// AI_NON_AUTHORITATIVE flag is defined on the Windows SDK for Windows Vista and later. The AI_NON_AUTHORITATIVE flag is supported
		/// on Windows Vista and later and applies only to the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_SECURE</term>
		/// <term>
		/// If the AI_SECURE bit is set, the NS_EMAIL namespace provider will return results that were obtained with enhanced security to
		/// minimize possible spoofing. The AI_SECURE flag is defined on the Windows SDK for Windows Vista and later. The AI_SECURE flag is
		/// supported on Windows Vista and later and applies only to the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_RETURN_PREFERRED_NAMES</term>
		/// <term>
		/// If the AI_RETURN_PREFERRED_NAMES is set, then no name should be provided in the pName parameter. The NS_EMAIL namespace provider
		/// will return preferred names for publication. The AI_RETURN_PREFERRED_NAMES flag is defined on the Windows SDK for Windows Vista
		/// and later. The AI_RETURN_PREFERRED_NAMES flag is supported on Windows Vista and later and applies only to the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FQDN</term>
		/// <term>
		/// If the AI_FQDN is set and a flat name (single label) is specified, GetAddrInfoEx will return the fully qualified domain name
		/// that the name eventually resolved to. The fully qualified domain name is returned in the ai_canonname member in the associated
		/// addrinfoex structure. This is different than AI_CANONNAME bit flag that returns the canonical name registered in DNS which may
		/// be different than the fully qualified domain name that the flat name resolved to. When the AI_FQDN bit is set, the pName
		/// parameter cannot be NULL. Otherwise the GetAddrInfoEx function will fail with WSANO_RECOVERY. On Windows 8 and Windows Server
		/// 2012, both the AI_FQDN and AI_CANONNAME bits can be set. If the GetAddrInfoEx function is called with both the AI_FQDN and
		/// AI_CANONNAME bits, the ppResult parameter returns a pointer to an addrinfoex2 structure, not an addrinfoex structure. On Windows
		/// 7 and Windows Server 2008 R2, only one of the AI_FQDN and AI_CANONNAME bits can be set. The GetAddrInfoEx function will fail if
		/// both flags are present with EAI_BADFLAGS. Windows 7: The AI_FQDN flag is defined on the Windows SDK for Windows 7 and later. The
		/// AI_FQDN flag is supported on Windows 7 and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FILESERVER</term>
		/// <term>
		/// If the AI_FILESERVER is set, this is a hint to the namespace provider that the hostname being queried is being used in file
		/// share scenario. The namespace provider may ignore this hint. Windows 7: The AI_FILESERVER flag is defined on the Windows SDK for
		/// Windows 7 and later. The AI_FILESERVER flag is supported on Windows 7 and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_DISABLE_IDN_ENCODING</term>
		/// <term>
		/// If the AI_DISABLE_IDN_ENCODING is set, this disables the automatic International Domain Name encoding using Punycode in the name
		/// resolution functions called by the GetAddrInfoEx function. Windows 8: The AI_DISABLE_IDN_ENCODING flag is defined on the Windows
		/// SDK for Windows 8 and later. The AI_DISABLE_IDN_ENCODING flag is supported on Windows 8 and later.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getaddrinfoexa INT WSAAPI GetAddrInfoExA( PCSTR pName,
		// PCSTR pServiceName, DWORD dwNameSpace, LPGUID lpNspId, const ADDRINFOEXA *hints, PADDRINFOEXA *ppResult, timeval *timeout,
		// LPOVERLAPPED lpOverlapped, LPLOOKUPSERVICE_COMPLETION_ROUTINE lpCompletionRoutine, LPHANDLE lpNameHandle );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "cc4ccb2d-ea5a-48bd-a3ae-f70432ab2c39")]
		public static unsafe extern SocketError GetAddrInfoExW([Optional, MarshalAs(UnmanagedType.LPWStr)] string pName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pServiceName,
			[Optional] NS dwNameSpace, [In, Optional] Guid* lpNspId, [In, Optional] ADDRINFOEXW* hints, out SafeADDRINFOEXWArray ppResult, [In, Optional] TIMEVAL* timeout, [In, Optional] NativeOverlapped* lpOverlapped,
			[In, Optional] LPLOOKUPSERVICE_COMPLETION_ROUTINE lpCompletionRoutine, [Out, Optional] HANDLE* lpNameHandle);

		/// <summary>The <c>GetAddrInfoW</c> function provides protocol-independent translation from a Unicode host name to an address.</summary>
		/// <param name="pNodeName">
		/// A pointer to a <c>NULL</c>-terminated Unicode string that contains a host (node) name or a numeric host address string. For the
		/// Internet protocol, the numeric host address string is a dotted-decimal IPv4 address or an IPv6 hex address.
		/// </param>
		/// <param name="pServiceName">
		/// <para>
		/// A pointer to a <c>NULL</c>-terminated Unicode string that contains either a service name or port number represented as a string.
		/// </para>
		/// <para>
		/// A service name is a string alias for a port number. For example, “http” is an alias for port 80 defined by the Internet
		/// Engineering Task Force (IETF) as the default port used by web servers for the HTTP protocol. Possible values for the
		/// pServiceName parameter when a port number is not specified are listed in the following file:
		/// </para>
		/// </param>
		/// <param name="pHints">
		/// <para>A pointer to an addrinfoW structure that provides hints about the type of socket the caller supports.</para>
		/// <para>
		/// The <c>ai_addrlen</c>, <c>ai_canonname</c>, <c>ai_addr</c>, and <c>ai_next</c> members of the addrinfoW structure pointed to by
		/// the pHints parameter must be zero or <c>NULL</c>. Otherwise the GetAddrInfoEx function will fail with WSANO_RECOVERY.
		/// </para>
		/// <para>See the Remarks for more details.</para>
		/// </param>
		/// <param name="ppResult">
		/// A pointer to a linked list of one or more addrinfoW structures that contains response information about the host.
		/// </param>
		/// <returns>
		/// <para>Success returns zero. Failure returns a nonzero Windows Sockets error code, as found in the Windows Sockets Error Codes.</para>
		/// <para>
		/// Most nonzero error codes returned by the <c>GetAddrInfoW</c> function map to the set of errors outlined by Internet Engineering
		/// Task Force (IETF) recommendations. The following table lists these error codes and their WSA equivalents. It is recommended that
		/// the WSA error codes be used, as they offer familiar and comprehensive error information for Winsock programmers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error value</term>
		/// <term>WSA equivalent</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>EAI_AGAIN</term>
		/// <term>WSATRY_AGAIN</term>
		/// <term>A temporary failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_BADFLAGS</term>
		/// <term>WSAEINVAL</term>
		/// <term>An invalid value was provided for the ai_flags member of the pHints parameter.</term>
		/// </item>
		/// <item>
		/// <term>EAI_FAIL</term>
		/// <term>WSANO_RECOVERY</term>
		/// <term>A nonrecoverable failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_FAMILY</term>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>The ai_family member of the pHints parameter is not supported.</term>
		/// </item>
		/// <item>
		/// <term>EAI_MEMORY</term>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_NONAME</term>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>The name does not resolve for the supplied parameters or the pNodeName and pServiceName parameters were not provided.</term>
		/// </item>
		/// <item>
		/// <term>EAI_SERVICE</term>
		/// <term>WSATYPE_NOT_FOUND</term>
		/// <term>The pServiceName parameter is not supported for the specified ai_socktype member of the pHints parameter.</term>
		/// </item>
		/// <item>
		/// <term>EAI_SOCKTYPE</term>
		/// <term>WSAESOCKTNOSUPPORT</term>
		/// <term>The ai_socktype member of the pHints parameter is not supported.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Use the gai_strerror function to print error messages based on the EAI_* codes returned by the <c>GetAddrInfoW</c> function. The
		/// <c>gai_strerror</c> function is provided for compliance with IETF recommendations, but it is not thread safe. Therefore, use of
		/// a traditional Windows Sockets function, such as WSAGetLastError, is recommended.
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
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// An address incompatible with the requested protocol was used. This error is returned if the ai_family member of the
		/// addrinfoWstructure pointed to by the hints parameter is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// An invalid argument was supplied. This error is returned if an invalid value was provided for the ai_flags member of the
		/// addrinfoWstructure pointed to by the hints parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAESOCKTNOSUPPORT</term>
		/// <term>
		/// The support for the specified socket type does not exist in this address family. This error is returned if the ai_socktype
		/// member of the addrinfoWstructure pointed to by the hints parameter is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>
		/// No such host is known. This error is returned if the name does not resolve for the supplied parameters or the pNodename and
		/// pServicename parameters were not provided.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANO_DATA</term>
		/// <term>The requested name is valid, but no data of the requested type was found.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>
		/// A nonrecoverable error occurred during a database lookup. This error is returned if nonrecoverable error in name resolution occurred.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSANOTINITIALISED</term>
		/// <term>A successful WSAStartup call must occur before using this function.</term>
		/// </item>
		/// <item>
		/// <term>WSATRY_AGAIN</term>
		/// <term>
		/// This is usually a temporary error during hostname resolution and means that the local server did not receive a response from an
		/// authoritative server. This error is returned when a temporary failure in name resolution occurred.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSATYPE_NOT_FOUND</term>
		/// <term>
		/// The specified class was not found. The pServiceName parameter is not supported for the specified ai_socktype member of the
		/// addrinfoWstructure pointed to by the hints parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetAddrInfoW</c> function is the Unicode version of a function that provides protocol-independent translation from host
		/// name to address. The ANSI version of this function is getaddrinfo.
		/// </para>
		/// <para>
		/// The <c>GetAddrInfoW</c> function returns results for the <c>NS_DNS</c> namespace. The <c>GetAddrInfoW</c> function aggregates
		/// all responses if more than one namespace provider returns information. For use with the IPv6 and IPv4 protocol, name resolution
		/// can be by the Domain Name System (DNS), a local hosts file, or by other naming mechanisms for the <c>NS_DNS</c> namespace.
		/// </para>
		/// <para>
		/// Macros in the Winsock header file define a mixed-case function name of <c>GetAddrInfo</c> and a <c>ADDRINFOT</c> structure. This
		/// <c>GetAddrInfo</c> function should be called with the pNodeName and pServiceName parameters of a pointer of type <c>TCHAR</c>
		/// and the pHints and ppResult parameters of a pointer of type <c>ADDRINFOT</c>. When UNICODE or _UNICODE is defined,
		/// <c>GetAddrInfo</c> is defined to <c>GetAddrInfoW</c>, the Unicode version of the function, and <c>ADDRINFOT</c> is defined to
		/// the addrinfoW structure. When UNICODE or _UNICODE is not defined, <c>GetAddrInfo</c> is defined to getaddrinfo, the ANSI version
		/// of the function, and <c>ADDRINFOT</c> is defined to the addrinfo structure.
		/// </para>
		/// <para>
		/// One or both of the pNodeName or pServiceName parameters must point to a <c>NULL</c>-terminated Unicode string; generally both
		/// are provided.
		/// </para>
		/// <para>
		/// Upon success, a linked list of addrinfoW structures is returned in the ppResult parameter. The list can be processed by
		/// following the pointer provided in the <c>ai_next</c> member of each returned <c>addrinfoW</c> structure until a <c>NULL</c>
		/// pointer is encountered. In each returned <c>addrinfoW</c> structure, the <c>ai_family</c>, <c>ai_socktype</c>, and
		/// <c>ai_protocol</c> members correspond to respective arguments in a socket or WSASocket function call. Also, the <c>ai_addr</c>
		/// member in each returned <c>addrinfoW</c> structure points to a filled-in socket address structure, the length of which is
		/// specified in its <c>ai_addrlen</c> member.
		/// </para>
		/// <para>
		/// If the pNodeName parameter points to a computer name, all permanent addresses for the computer that can be used as a source
		/// address are returned. On Windows Vista and later, these addresses would include all unicast IP addresses returned by the
		/// GetUnicastIpAddressTable or GetUnicastIpAddressEntry functions in which the <c>SkipAsSource</c> member is set to false in the
		/// MIB_UNICASTIPADDRESS_ROW structure.
		/// </para>
		/// <para>If the pNodeName parameter points to a string equal to "localhost", all loopback addresses on the local computer are returned.</para>
		/// <para>If the pNodeName parameter contains an empty string, all registered addresses on the local computer are returned.</para>
		/// <para>
		/// On Windows Server 2003 and later if the pNodeName parameter points to a string equal to "..localmachine", all registered
		/// addresses on the local computer are returned.
		/// </para>
		/// <para>
		/// If the pNodeName parameter refers to a cluster virtual server name, only virtual server addresses are returned. On Windows Vista
		/// and later, these addresses would include all unicast IP addresses returned by the GetUnicastIpAddressTable or
		/// GetUnicastIpAddressEntry functions in which the <c>SkipAsSource</c> member is set to true in the MIB_UNICASTIPADDRESS_ROW
		/// structure. See Windows Clustering for more information about clustering.
		/// </para>
		/// <para>
		/// Windows 7 with Service Pack 1 (SP1) and Windows Server 2008 R2 with Service Pack 1 (SP1) add support to Netsh.exe for setting
		/// the SkipAsSource attribute on an IP address. This also changes the behavior such that if the <c>SkipAsSource</c> member in the
		/// MIB_UNICASTIPADDRESS_ROW structure is set to false, the IP address will be registered in DNS. If the <c>SkipAsSource</c> member
		/// is set to true, the IP address is not registered in DNS.
		/// </para>
		/// <para>
		/// A hotfix is available for Windows 7 and Windows Server 2008 R2 that adds support to Netsh.exe for setting the SkipAsSource
		/// attribute on an IP address. This hotfix also changes behavior such that if the <c>SkipAsSource</c> member in the
		/// MIB_UNICASTIPADDRESS_ROW structure is set to false, the IP address will be registered in DNS. If the <c>SkipAsSource</c> member
		/// is set to true, the IP address is not registered in DNS. For more information, see Knowledge Base (KB) 2386184.
		/// </para>
		/// <para>
		/// A similar hotfix is also available for Windows Vista with Service Pack 2 (SP2) and Windows Server 2008 with Service Pack 2 (SP2)
		/// that adds support to Netsh.exe for setting the SkipAsSource attribute on an IP address. This hotfix also changes behavior such
		/// that if the <c>SkipAsSource</c> member in the MIB_UNICASTIPADDRESS_ROW structure is set to false, the IP address will be
		/// registered in DNS. If the <c>SkipAsSource</c> member is set to true, the IP address is not registered in DNS. For more
		/// information, see Knowledge Base (KB) 975808.
		/// </para>
		/// <para>
		/// Callers of the <c>GetAddrInfoW</c> function can provide hints about the type of socket supported through an addrinfoW structure
		/// pointed to by the pHints parameter. When the pHints parameter is used, the following rules apply to its associated
		/// <c>addrinfoW</c> structure:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// A value of <c>AF_UNSPEC</c> for <c>ai_family</c> indicates the caller will accept only the <c>AF_INET</c> and <c>AF_INET6</c>
		/// address families. Note that <c>AF_UNSPEC</c> and <c>PF_UNSPEC</c> are the same.
		/// </term>
		/// </item>
		/// <item>
		/// <term>A value of zero for <c>ai_socktype</c> indicates the caller will accept any socket type.</term>
		/// </item>
		/// <item>
		/// <term>A value of zero for <c>ai_protocol</c> indicates the caller will accept any protocol.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_addrlen</c> member must be set to zero.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_canonname</c> member must be set to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_addr</c> member must be set to <c>NULL</c>.</term>
		/// </item>
		/// <item>
		/// <term>The <c>ai_next</c> member must be set to <c>NULL</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Other values in the addrinfoW structure provided in the pHints parameter indicate specific requirements. For example, if the
		/// caller handles only IPv4 and does not handle IPv6, the <c>ai_family</c> member should be set to <c>AF_INET</c>. For another
		/// example, if the caller handles only TCP and does not handle UDP, the <c>ai_socktype</c> member should be set to <c>SOCK_STREAM</c>.
		/// </para>
		/// <para>
		/// If the pHints parameter is a <c>NULL</c> pointer, the <c>GetAddrInfoW</c> function handles it as if the addrinfoW structure in
		/// pHints were initialized with its <c>ai_family</c> member set to <c>AF_UNSPEC</c> and all other members set to zero.
		/// </para>
		/// <para>
		/// On Windows Vista and later when <c>GetAddrInfoW</c> is called from a service, if the operation is the result of a user process
		/// calling the service, then the service should impersonate the user. This is to allow security to be properly enforced.
		/// </para>
		/// <para>
		/// The <c>GetAddrInfoW</c> function can be used to convert a text string representation of an IP address to an addrinfoWstructure
		/// that contains a sockaddr structure for the IP address and other information. To be used in this way, the string pointed to by
		/// the pNodeName parameter must contain a text representation of an IP address and the <c>addrinfoW</c> structure pointed to by the
		/// pHints parameter must have the <c>AI_NUMERICHOST</c> flag set in the <c>ai_flags</c> member. The string pointed to by the
		/// pNodeName parameter may contain a text representation of either an IPv4 or an IPv6 address. The text IP address is converted to
		/// an <c>addrinfoW</c> structure pointed to by the ppResult parameter. The returned <c>addrinfoW</c> structure contains a
		/// <c>sockaddr</c> structure for the IP address along with additional information about the IP address. For this method to work
		/// with an IPv6 address string on Windows Server 2003 and Windows XP, the IPv6 protocol must be installed on the local computer.
		/// Otherwise, the WSAHOST_NOT_FOUND error is returned.
		/// </para>
		/// <para>Freeing Address Information from Dynamic Allocation</para>
		/// <para>
		/// All information returned by the <c>GetAddrInfoW</c> function pointed to by the ppResult parameter is dynamically allocated,
		/// including all addrinfoW structures, socket address structures, and canonical host name strings pointed to by <c>addrinfoW</c>
		/// structures. Memory allocated by a successful call to this function must be released with a subsequent call to FreeAddrInfoW.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following code example shows how to use the <c>GetAddrInfoW</c> function.</para>
		/// <para>
		/// <c>Note</c> Ensure that the development environment targets the newest version of Ws2tcpip.h which includes structure and
		/// function definitions for addrinfoW and <c>GetAddrInfoW</c>, respectively.
		/// </para>
		/// <para>Internationalized Domain Names</para>
		/// <para>Internet host names typically consist of a very restricted set of characters:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Upper and lower case ASCII letters from the English alphabet.</term>
		/// </item>
		/// <item>
		/// <term>Digits from 0 to 9.</term>
		/// </item>
		/// <item>
		/// <term>ASCII hyphen characters.</term>
		/// </item>
		/// </list>
		/// <para>
		/// With the growth of the Internet, there is a growing need to identify Internet host names for other languages not represented by
		/// the ASCII character set. Identifiers which facilitate this need and allow non-ASCII characters (Unicode) to be represented as
		/// special ASCII character strings are known as Internationalized Domain Names (IDNs). A mechanism called Internationalizing Domain
		/// Names in Applications (IDNA) is used to handle IDNs in a standard fashion. The specifications for IDNs and IDNA are documented
		/// in RFC 3490, RTF 5890, and RFC 6365 published by the Internet Engineering Task Force (IETF).
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, the <c>GetAddrInfoW</c> function provides support for Internationalized Domain Name (IDN)
		/// parsing applied to the name passed in the pNodeName parameter. Winsock performs Punycode/IDN encoding and conversion. This
		/// behavior can be disabled using the <c>AI_DISABLE_IDN_ENCODING</c> flag discussed below.
		/// </para>
		/// <para>
		/// On Windows 7 and Windows Server 2008 R2 or earlier, the <c>GetAddrInfoW</c> function does not currently provide support for IDN
		/// parsing applied to the name passed in the pNodeName parameter. Winsock does not perform any Punycode/IDN conversion. The
		/// <c>GetAddrInfoW</c> function does not use Punycode to convert an IDN as per RFC 3490. The <c>GetAddrInfoW</c> function when
		/// querying DNS encodes the Unicode name in UTF-8 format, the format used by Microsoft DNS servers in an enterprise environment.
		/// </para>
		/// <para>
		/// Several functions on Windows Vista and later support conversion between Unicode labels in an IDN to their ASCII equivalents. The
		/// resulting representation of each Unicode label contains only ASCII characters and starts with the xn-- prefix if the Unicode
		/// label contained any non-ASCII characters. The reason for this is to support existing DNS servers on the Internet, since some DNS
		/// tools and servers only support ASCII characters (see RFC 3490).
		/// </para>
		/// <para>
		/// The IdnToAscii function use Punycode to convert an IDN to the ASCII representation of the original Unicode string using the
		/// standard algorithm defined in RFC 3490. The IdnToUnicode function converts the ASCII form of an IDN to the normal Unicode UTF-16
		/// encoding syntax. For more information and links to related draft standards, see Handling Internationalized Domain Names (IDNs).
		/// </para>
		/// <para>
		/// The IdnToAscii function can be used to convert an IDN name to the ASCII form. To pass this ASCII form to the <c>GetAddrInfoW</c>
		/// function, you can use the MultiByteToWideChar function to convert the <c>CHAR</c> string into a <c>WCHAR</c> string that then
		/// can be passed in the pNodeName parameter to the <c>GetAddrInfoW</c> function.
		/// </para>
		/// <para>Use of ai_flags in the hints parameter</para>
		/// <para>
		/// Flags in the <c>ai_flags</c> member of the optional addrinfoW structure provided in the pHints parameter modify the behavior of
		/// the function.
		/// </para>
		/// <para>
		/// These flag bits are defined in the Ws2def.h header file on the Microsoft Windows Software Development Kit (SDK) for Windows 7.
		/// These flag bits are defined in the Ws2tcpip.h header file on the Windows SDK for Windows Server 2008 and Windows Vista. These
		/// flag bits are defined in the Ws2tcpip.h header file on the Platform Software Development Kit (SDK) for Windows Server 2003, and
		/// Windows XP.
		/// </para>
		/// <para>The flag bits can be a combination of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag Bits</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>AI_PASSIVE</term>
		/// <term>
		/// Setting the AI_PASSIVE flag indicates the caller intends to use the returned socket address structure in a call to the bind
		/// function. When the AI_PASSIVE flag is set and pNodeName is a NULL pointer, the IP address portion of the socket address
		/// structure is set to INADDR_ANY for IPv4 addresses and IN6ADDR_ANY_INIT for IPv6 addresses. When the AI_PASSIVE flag is not set,
		/// the returned socket address structure is ready for a call to the connect function for a connection-oriented protocol, or ready
		/// for a call to either the connect, sendto, or send functions for a connectionless protocol. If the pNodeName parameter is a NULL
		/// pointer in this case, the IP address portion of the socket address structure is set to the loopback address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_CANONNAME</term>
		/// <term>
		/// If neither AI_CANONNAME nor AI_NUMERICHOST is used, the GetAddrInfoW function attempts resolution. If a literal string is passed
		/// GetAddrInfoW attempts to convert the string, and if a host name is passed the GetAddrInfoW function attempts to resolve the name
		/// to an address or multiple addresses. When the AI_CANONNAME bit is set, the pNodeName parameter cannot be NULL. Otherwise the
		/// GetAddrInfoEx function will fail with WSANO_RECOVERY. When the AI_CANONNAME bit is set and the GetAddrInfoW function returns
		/// success, the ai_canonname member in the ppResult parameter points to a NULL-terminated string that contains the canonical name
		/// of the specified node.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICHOST</term>
		/// <term>
		/// When the AI_NUMERICHOST bit is set, the pNodeName parameter must contain a non-NULL numeric host address string, otherwise the
		/// EAI_NONAME error is returned. This flag prevents a name resolution service from being called.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NUMERICSERV</term>
		/// <term>
		/// When the AI_NUMERICSERV bit is set, the pServiceName parameter must contain a non-NULL numeric port number, otherwise the
		/// EAI_NONAME error is returned. This flag prevents a name resolution service from being called. The AI_NUMERICSERV flag is defined
		/// on Windows SDK for Windows Vista and later. The AI_NUMERICSERV flag is not supported by Microsoft providers.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ALL</term>
		/// <term>
		/// If the AI_ALL bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. The AI_ALL flag is defined
		/// on the Windows SDK for Windows Vista and later. The AI_ALL flag is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ADDRCONFIG</term>
		/// <term>
		/// If the AI_ADDRCONFIG bit is set, GetAddrInfoW will resolve only if a global address is configured. If AI_ADDRCONFIG flag is
		/// specified, IPv4 addresses shall be returned only if an IPv4 address is configured on the local system, and IPv6 addresses shall
		/// be returned only if an IPv6 address is configured on the local system. The IPv4 or IPv6 loopback address is not considered a
		/// valid global address. The AI_ADDRCONFIG flag is defined on the Windows SDK for Windows Vista and later. The AI_ADDRCONFIG flag
		/// is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_V4MAPPED</term>
		/// <term>
		/// If the AI_V4MAPPED bit is set and a request for IPv6 addresses fails, a name service request is made for IPv4 addresses and
		/// these addresses are converted to IPv4-mapped IPv6 address format. The AI_V4MAPPED flag is defined on the Windows SDK for Windows
		/// Vista and later. The AI_V4MAPPED flag is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NON_AUTHORITATIVE</term>
		/// <term>
		/// If the AI_NON_AUTHORITATIVE bit is set, the NS_EMAIL namespace provider returns both authoritative and non-authoritative
		/// results. If the AI_NON_AUTHORITATIVE bit is not set, the NS_EMAIL namespace provider returns only authoritative results. The
		/// AI_NON_AUTHORITATIVE flag is defined on the Windows SDK for Windows Vista and later. The AI_NON_AUTHORITATIVE flag is supported
		/// on Windows Vista and later and applies only to the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_SECURE</term>
		/// <term>
		/// If the AI_SECURE bit is set, the NS_EMAIL namespace provider will return results that were obtained with enhanced security to
		/// minimize possible spoofing. The AI_SECURE flag is defined on the Windows SDK for Windows Vista and later. The AI_SECURE flag is
		/// supported on Windows Vista and later and applies only to the NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_RETURN_PREFERRED_NAMES</term>
		/// <term>
		/// If the AI_RETURN_PREFERRED_NAMES is set, then no name should be provided in the pNodeName parameter. The NS_EMAIL namespace
		/// provider will return preferred names for publication. The AI_RETURN_PREFERRED_NAMES flag is defined on the Windows SDK for
		/// Windows Vista and later. The AI_RETURN_PREFERRED_NAMES flag is supported on Windows Vista and later and applies only to the
		/// NS_EMAIL namespace.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FQDN</term>
		/// <term>
		/// If the AI_FQDN is set and a flat name (single label) is specified, GetAddrInfoW will return the fully qualified domain name that
		/// the name eventually resolved to. The fully qualified domain name is returned in the ai_canonname member in the associated
		/// addrinfoW structure. This is different than AI_CANONNAME bit flag that returns the canonical name registered in DNS which may be
		/// different than the fully qualified domain name that the flat name resolved to. Only one of the AI_FQDN and AI_CANONNAME bits can
		/// be set. The GetAddrInfoW function will fail if both flags are present with EAI_BADFLAGS. When the AI_FQDN bit is set, the
		/// pNodeName parameter cannot be NULL. Otherwise the GetAddrInfoEx function will fail with WSANO_RECOVERY. Windows 7: The AI_FQDN
		/// flag is defined on the Windows SDK for Windows 7 and later. The AI_FQDN flag is supported on Windows 7 and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_FILESERVER</term>
		/// <term>
		/// If the AI_FILESERVER is set, this is a hint to the namespace provider that the hostname being queried is being used in file
		/// share scenario. The namespace provider may ignore this hint. Windows 7: The AI_FILESERVER flag is defined on the Windows SDK for
		/// Windows 7 and later. The AI_FILESERVER flag is supported on Windows 7 and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_DISABLE_IDN_ENCODING</term>
		/// <term>
		/// If the AI_DISABLE_IDN_ENCODING is set, this disables the automatic International Domain Name encoding using Punycode in the name
		/// resolution functions called by the GetAddrInfoW function. Windows 8: The AI_DISABLE_IDN_ENCODING flag is defined on the Windows
		/// SDK for Windows 8 and later. The AI_DISABLE_IDN_ENCODING flag is supported on Windows 8 and later.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-getaddrinfow INT WSAAPI GetAddrInfoW( PCWSTR pNodeName,
		// PCWSTR pServiceName, const ADDRINFOW *pHints, PADDRINFOW *ppResult );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "82436a88-5b37-4758-a5c9-b60dd1cbc36c")]
		public static extern SocketError GetAddrInfoW([Optional] string pNodeName, [Optional] string pServiceName, [Optional] in ADDRINFOW pHints, out SafeADDRINFOWArray ppResult);

		/// <summary>The <c>getipv4sourcefilter</c> inline function retrieves the multicast filter state for an IPv4 socket.</summary>
		/// <param name="Socket">A descriptor that identifies a multicast socket.</param>
		/// <param name="Interface">
		/// <para>The local IPv4 address of the interface or the interface index on which the multicast group should be joined or dropped.</para>
		/// <para>
		/// This value is in network byte order. If this member specifies an IPv4 address of 0.0.0.0, the default IPv4 multicast interface
		/// is used.
		/// </para>
		/// <para>
		/// Any IP address in the 0.x.x.x block (first octet of 0) except IPv4 address 0.0.0.0 is treated as an interface index. An
		/// interface index is a 24-bit number, and the 0.0.0.0/8 IPv4 address block is not used (this range is reserved).
		/// </para>
		/// <para>To use an interface index of 1 would be the same as an IP address of 0.0.0.1.</para>
		/// </param>
		/// <param name="Group">The IPv4 address of the multicast group.</param>
		/// <param name="FilterMode">
		/// A pointer to a value to receive the multicast filter mode for multicast group address when the function returns.
		/// </param>
		/// <param name="SourceCount">
		/// <para>
		/// On input, a pointer to a value that indicates the maximum number of source addresses that will fit in the buffer pointed to by
		/// the SourceList parameter.
		/// </para>
		/// <para>On output, a pointer to a value that indicates the total number of source addresses associated with the multicast filter.</para>
		/// </param>
		/// <param name="SourceList">
		/// <para>A pointer to a buffer to receive the list of IP addresses associated with the multicast filter.</para>
		/// <para>If SourceCount is zero on input, a <c>NULL</c> pointer may be supplied.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>getipv4sourcefilter</c> returns NO_ERROR (0). Any nonzero return value indicates failure and a specific error
		/// code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>getipv4sourcefilter</c> inline function is used to retrieve the multicast filter state for an IPv4 socket.</para>
		/// <para>
		/// If the app does not know the size of the source list beforehand, it can make a guess (zero, for example). If upon completion,
		/// the SourceCount parameter holds a larger value, the operation can be repeated with a large enough buffer.
		/// </para>
		/// <para>
		/// On return, the SourceCount parameter is always updated to be the total number of sources in the filter, while the buffer pointed
		/// to by the SourceList parameter will hold as many source addresses as fit, up to the minimum of the array size passed in as the
		/// original SourceCount value and the total number of sources in the filter.
		/// </para>
		/// <para>
		/// This function is part of socket interface extensions for multicast source filters defined in RFC 3678. An app can use these
		/// functions to retrieve and set the multicast source address filters associated with a socket.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getipv4sourcefilter int getipv4sourcefilter( SOCKET
		// Socket, IN_ADDR Interface, IN_ADDR Group, MULTICAST_MODE_TYPE *FilterMode, ULONG *SourceCount, IN_ADDR *SourceList );
		[PInvokeData("ws2tcpip.h", MSDNShortId = "17D35D24-C419-4787-AB93-E6B1B6B13807")]
		public static SocketError getipv4sourcefilter(SOCKET Socket, IN_ADDR Interface, IN_ADDR Group, out MULTICAST_MODE_TYPE FilterMode, ref int SourceCount, IN_ADDR[] SourceList)
		{
			FilterMode = MULTICAST_MODE_TYPE.MCAST_INCLUDE;

			if (SourceCount > (SourceList?.Length ?? 0))
			{
				WSASetLastError(System.Net.Sockets.SocketError.NoBufferSpaceAvailable);
				return System.Net.Sockets.SocketError.SocketError;
			}

			var Filter = new IP_MSFILTER
			{
				imsf_multiaddr = Group,
				imsf_interface = Interface,
				imsf_numsrc = (uint)SourceCount
			};
			using var pFilter = SafeHGlobalHandle.CreateFromStructure(Filter);
			pFilter.Size = IP_MSFILTER_SIZE(SourceCount);

			var err = WSAIoctl(Socket, SIOCGIPMSFILTER, pFilter, pFilter.Size, pFilter, pFilter.Size, out var Returned);
			if (err == 0)
			{
				Filter = pFilter.ToStructure<IP_MSFILTER>();
				if (SourceCount > 0)
				{
					Array.Copy(Filter.imsf_slist, SourceList, Math.Min(SourceCount, Filter.imsf_numsrc));
					SourceCount = (int)Filter.imsf_numsrc;
				}
				FilterMode = Filter.imsf_fmode;
			}
			return err;
		}

		/// <summary>
		/// The <c>GetNameInfoW</c> function provides protocol-independent name resolution from an address to a Unicode host name and from a
		/// port number to the Unicode service name.
		/// </summary>
		/// <param name="pSockaddr">
		/// A pointer to a socket address structure containing the IP address and port number of the socket. For IPv4, the pSockaddr
		/// parameter points to a sockaddr_in structure. For IPv6, the pSockaddr parameter points to a <c>sockaddr_in6</c> structure.
		/// </param>
		/// <param name="SockaddrLength">The length, in bytes, of the structure pointed to by the pSockaddr parameter.</param>
		/// <param name="pNodeBuffer">
		/// A pointer to a Unicode string to hold the host name. On success, a pointer to the Unicode host name is returned as a Fully
		/// Qualified Domain Name (FQDN) by default. If the pNodeBuffer parameter is <c>NULL</c>, this indicates the caller does not want to
		/// receive a host name string.
		/// </param>
		/// <param name="NodeBufferSize">
		/// The number of <c>WCHAR</c> characters in the buffer pointed to by the pNodeBuffer parameter. The caller must provide a buffer
		/// large enough to hold the Unicode host name, including the terminating <c>NULL</c> character.
		/// </param>
		/// <param name="pServiceBuffer">
		/// A pointer to a Unicode string to hold the service name. On success, a pointer is returned to a Unicode string representing the
		/// service name associated with the port number. If the pServiceBuffer parameter is <c>NULL</c>, this indicates the caller does not
		/// want to receive a service name string.
		/// </param>
		/// <param name="ServiceBufferSize">
		/// The number of <c>WCHAR</c> characters in the buffer pointed to by the pServiceBuffer parameter. The caller must provide a buffer
		/// large enough to hold the Unicode service name, including the terminating <c>NULL</c> character.
		/// </param>
		/// <param name="Flags">A value used to customize processing of the <c>GetNameInfoW</c> function. See the Remarks section.</param>
		/// <returns>
		/// <para>
		/// On success, <c>GetNameInfoW</c> returns zero. Any nonzero return value indicates failure and a specific error code can be
		/// retrieved by calling WSAGetLastError.
		/// </para>
		/// <para>
		/// Nonzero error codes returned by the <c>GetNameInfoW</c> function also map to the set of errors outlined by Internet Engineering
		/// Task Force (IETF) recommendations. The following table shows these error codes and their WSA equivalents. It is recommended that
		/// the WSA error codes be used, as they offer familiar and comprehensive error information for Winsock programmers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error value</term>
		/// <term>WSA equivalent</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>EAI_AGAIN</term>
		/// <term>WSATRY_AGAIN</term>
		/// <term>A temporary failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_BADFLAGS</term>
		/// <term>WSAEINVAL</term>
		/// <term>
		/// One or more invalid parameters was passed to the GetNameInfoW function. This error is returned if a host name was requested but
		/// the NodeBufferSize parameter was zero or if a service name was requested but the ServiceBufferSize parameter was zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>EAI_FAIL</term>
		/// <term>WSANO_RECOVERY</term>
		/// <term>A nonrecoverable failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_FAMILY</term>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>The sa_family member of socket address structure pointed to by the pSockaddr parameter is not supported.</term>
		/// </item>
		/// <item>
		/// <term>EAI_MEMORY</term>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>EAI_NONAME</term>
		/// <term>WSAHOST_NOT_FOUND</term>
		/// <term>
		/// A service name was requested, but no port number was found in the structure pointed to by the pSockaddr parameter or no service
		/// name matching the port number was found. NI_NAMEREQD is set and the host's name cannot be located, or both the pNodeBuffer and
		/// pServiceBuffer parameters were NULL.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// You can use the gai_strerror function to print error messages based on the EAI codes returned by the <c>GetNameInfoW</c>
		/// function. The <c>gai_strerror</c> function is provided for compliance with IETF recommendations, but it is not thread safe.
		/// Therefore, use of traditional Windows Sockets functions such as WSAGetLastError is recommended.
		/// </para>
		/// <para>In addition, the following error codes can be returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>
		/// This error is returned if the pSockaddr parameter is NULL or the SockaddrLength parameter is less than the length needed for the
		/// size of sockaddr_in structure for IPv4 or the sockaddr_in6 structure for IPv6.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetNameInfoW</c> function is the Unicode version of a function that provides protocol-independent name resolution. The
		/// <c>GetNameInfoW</c> function is used to translate the contents of a socket address structure to a node name and/or a service name.
		/// </para>
		/// <para>
		/// For the IPv6 and IPv4 protocols, name resolution can be by the Domain Name System (DNS), a local hosts file, or by other naming
		/// mechanisms. This function can be used to determine the host name for an IPv4 or IPv6 address, a reverse DNS lookup, or determine
		/// the service name for a port number. The <c>GetNameInfoW</c> function can also be used to convert an IP address or a port number
		/// in a <c>SOCKADDR</c> structure to an Unicode string. This function can also be used to determine the IP address for a host name.
		/// </para>
		/// <para>The ANSI version of this function is getnameinfo.</para>
		/// <para>
		/// Macros in the Winsock header file define a mixed-case function name of <c>GetNameInfo</c> that can be used when the application
		/// is targeted for Windows XP with Service Pack 2 (SP2) and later (_WIN32_WINNT &gt;= 0x0502). This <c>GetNameInfo</c> function
		/// should be called with the pNodeBuffer and pServiceBuffer parameters of a pointer of type <c>TCHAR</c>. When UNICODE or _UNICODE
		/// is defined, <c>GetNameInfo</c> is defined to the Unicode version and <c>GetNameInfoW</c> is called with the host and serv
		/// parameters of a pointer of type <c>char</c>. When UNICODE or _UNICODE is not defined, <c>GetNameInfo</c> is defined to the ANSI
		/// version and getnameinfo is called with the pNodeBuffer and pServiceBuffer parameters of a pointer of type <c>PWCHAR</c>.
		/// </para>
		/// <para>
		/// To simplify determining buffer requirements for the pNodeBuffer and pServiceBuffer parameters, the following values for maximum
		/// host name length and maximum service name are defined in the Ws2tcpip.h header file:
		/// </para>
		/// <para>The Flags parameter can be used to customize processing of the <c>GetNameInfoW</c> function. The following flags are available:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>NI_NOFQDN</term>
		/// </item>
		/// <item>
		/// <term>NI_NUMERICHOST</term>
		/// </item>
		/// <item>
		/// <term>NI_NAMEREQD</term>
		/// </item>
		/// <item>
		/// <term>NI_NUMERICSERV</term>
		/// </item>
		/// <item>
		/// <term>NI_DGRAM</term>
		/// </item>
		/// </list>
		/// <para>When the <c>NI_NAMEREQD</c> flag is set, a host name that cannot be resolved by the DNS results in an error.</para>
		/// <para>
		/// Setting the <c>NI_NOFQDN</c> flag results in local hosts having only their Relative Distinguished Name (RDN) returned in the
		/// pNodeBuffer parameter.
		/// </para>
		/// <para>
		/// Setting the <c>NI_NUMERICHOST</c> flag returns the numeric form of the host name instead of its name. The numeric form of the
		/// host name is also returned if the host name cannot be resolved by DNS.
		/// </para>
		/// <para>
		/// Setting the <c>NI_NUMERICSERV</c> flag returns the port number of the service instead of its name. Also, if a host name is not
		/// found for an IP address (127.0.0.2, for example), the hostname is returned as the IP address.
		/// </para>
		/// <para>
		/// On Windows Vista and later, if <c>NI_NUMERICSERV</c> is not specified in the flags parameter, and the port number contained in
		/// <c>sockaddr</c> structure pointed to by the sa parameter does not resolve to a well known service, the <c>GetNameInfoW</c>
		/// function returns the numeric form of the service address (the port number) as a numeric string. When <c>NI_NUMERICSERV</c> is
		/// specified, the port number is returned as a numeric string. This behavior is specified in section 6.2 of RFC 3493. For more
		/// information, see www.ietf.org/rfc/rfc3493.txt
		/// </para>
		/// <para>
		/// On Windows Server 2003 and earlier, if <c>NI_NUMERICSERV</c> is not specified in the flags parameter and the port number
		/// contained in sockaddr structure pointed to by the sa parameter does not resolve to a well known service, the <c>GetNameInfoW</c>
		/// function fails. When <c>NI_NUMERICSERV</c> is specified, the port number is returned as a numeric string.
		/// </para>
		/// <para>
		/// Setting the <c>NI_DGRAM</c> flag indicates that the service is a datagram service. This flag is necessary for the few services
		/// that provide different port numbers for UDP and TCP service.
		/// </para>
		/// <para>
		/// <c>Note</c> The capability to perform reverse DNS lookups using the <c>GetNameInfoW</c> function is convenient, but such lookups
		/// are considered inherently unreliable, and should be used only as a hint.
		/// </para>
		/// <para><c>Note</c><c>GetNameInfoW</c> cannot be used to resolve alias names.</para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// <para>Example Code</para>
		/// <para>The following example demonstrates the use of the <c>GetNameInfoW</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getnameinfow INT WSAAPI GetNameInfoW( const SOCKADDR
		// *pSockaddr, socklen_t SockaddrLength, PWCHAR pNodeBuffer, DWORD NodeBufferSize, PWCHAR pServiceBuffer, DWORD ServiceBufferSize,
		// INT Flags );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "5630a49a-c182-440c-ad54-6ff3ba4274c6")]
		public static extern SocketError GetNameInfoW([In] SOCKADDR pSockaddr, int SockaddrLength, StringBuilder pNodeBuffer, uint NodeBufferSize, StringBuilder pServiceBuffer, uint ServiceBufferSize, NI Flags);

		/// <summary>The <c>getsourcefilter</c> inline function retrieves the multicast filter state for an IPv4 or IPv6 socket.</summary>
		/// <param name="Socket">A descriptor that identifies a multicast socket.</param>
		/// <param name="Interface">The interface index of the multicast interface.</param>
		/// <param name="Group">A pointer to the socket address of the multicast group.</param>
		/// <param name="GroupLength">The length, in bytes, of the socket address pointed to by the Group parameter.</param>
		/// <param name="FilterMode">
		/// A pointer to a value to receive the multicast filter mode for the multicast group address when the function returns.
		/// </param>
		/// <param name="SourceCount">
		/// <para>
		/// On input, a pointer to a value that indicates the maximum number of source addresses that will fit in the buffer pointed to by
		/// the SourceList parameter.
		/// </para>
		/// <para>On output, a pointer to a value that indicates the total number of source addresses associated with the multicast filter.</para>
		/// </param>
		/// <param name="SourceList">
		/// <para>A pointer to a buffer to receive the list of IP addresses associated with the multicast filter.</para>
		/// <para>If SourceCount is zero on input, a <c>NULL</c> pointer may be supplied.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>getsourcefilter</c> returns NO_ERROR (0). Any nonzero return value indicates failure and a specific error code
		/// can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>getsourcefilter</c> inline function is used to retrieve the multicast filter state for an IPv4 or IPv6 socket.</para>
		/// <para>
		/// If the app does not know the size of the source list beforehand, it can make a guess (zero, for example). If upon completion,
		/// the SourceCount parameter holds a larger value, the operation can be repeated with a large enough buffer.
		/// </para>
		/// <para>
		/// On return, the SourceCount parameter is always updated to be the total number of sources in the filter, while the buffer pointed
		/// to by the SourceList parameter will hold as many source addresses as fit, up to the minimum of the array size passed in as the
		/// original SourceCount value and the total number of sources in the filter.
		/// </para>
		/// <para>
		/// This function is part of socket interface extensions for multicast source filters defined in RFC 3678. An app can use these
		/// functions to retrieve and set the multicast source address filters associated with a socket.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-getsourcefilter int getsourcefilter( SOCKET Socket, ULONG
		// Interface, const SOCKADDR *Group, int GroupLength, MULTICAST_MODE_TYPE *FilterMode, ULONG *SourceCount, SOCKADDR_STORAGE
		// *SourceList );
		[PInvokeData("ws2tcpip.h", MSDNShortId = "2CA84000-F114-439D-BEDE-9990044C7785")]
		public static SocketError getsourcefilter(SOCKET Socket, uint Interface, [In] SOCKADDR Group, int GroupLength, out MULTICAST_MODE_TYPE FilterMode, ref int SourceCount, SOCKADDR_STORAGE[] SourceList)
		{
			FilterMode = MULTICAST_MODE_TYPE.MCAST_INCLUDE;

			if (SourceCount > SourceList.Length || GroupLength > Group.Size)
			{
				WSASetLastError(System.Net.Sockets.SocketError.NoBufferSpaceAvailable);
				return System.Net.Sockets.SocketError.SocketError;
			}

			var Filter = new GROUP_FILTER
			{
				gf_interface = Interface,
				gf_numsrc = (uint)SourceCount
			};
			using var pFilter = SafeHGlobalHandle.CreateFromStructure(Filter);
			pFilter.Size = GROUP_FILTER_SIZE(SourceCount);
			Group.DangerousGetHandle().CopyTo(pFilter.DangerousGetHandle().Offset(4), Group.Size);

			var Error = WSAIoctl(Socket, SIOCGMSFILTER, pFilter, pFilter.Size, pFilter, pFilter.Size, out var Returned);
			if (Error == 0)
			{
				Filter = pFilter.ToStructure<GROUP_FILTER>();
				if (SourceCount > 0)
				{
					Array.Copy(Filter.gf_slist, SourceList, Math.Min(SourceCount, Filter.gf_numsrc));
					SourceCount = (int)Filter.gf_numsrc;
				}
				FilterMode = Filter.gf_fmode;
			}

			return Error;
		}

		/// <summary>
		/// The <c>InetNtop</c> function converts an IPv4 or IPv6 Internet network address into a string in Internet standard format. The
		/// ANSI version of this function is <c>inet_ntop</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns an IPv4 address string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns an IPv6 address string.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAddr">
		/// <para>A pointer to the IP address in network byte to convert to a string.</para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address
		/// to convert.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address
		/// to convert.
		/// </para>
		/// </param>
		/// <param name="pStringBuf">
		/// <para>A pointer to a buffer in which to store the <c>NULL</c>-terminated string representation of the IP address.</para>
		/// <para>For an IPv4 address, this buffer should be large enough to hold at least 16 characters.</para>
		/// <para>For an IPv6 address, this buffer should be large enough to hold at least 46 characters.</para>
		/// </param>
		/// <param name="StringBufSize">On input, the length, in characters, of the buffer pointed to by the pStringBuf parameter.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>InetNtop</c> function returns a pointer to a buffer containing the string representation of IP address in
		/// standard format.
		/// </para>
		/// <para>
		/// Otherwise, a value of <c>NULL</c> is returned, and a specific error code can be retrieved by calling the WSAGetLastError for
		/// extended error information.
		/// </para>
		/// <para>If the function fails, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pStringBuf or the
		/// StringBufSize parameter is zero. This error is also returned if the length of the buffer pointed to by the pStringBuf parameter
		/// is not large enough to receive the string representation of the IP address.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetNtop</c> function is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>InetNtop</c> function provides a protocol-independent address-to-string translation. The <c>InetNtop</c> function takes
		/// an Internet address structure specified by the pAddr parameter and returns a <c>NULL</c>-terminated string that represents the
		/// IP address. While the inet_ntoa function works only with IPv4 addresses, the <c>InetNtop</c> function works with either IPv4 or
		/// IPv6 addresses.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_ntop</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>The <c>InetNtop</c> function does not require that the Windows Sockets DLL be loaded to perform IP address to string conversion.</para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in dotted-decimal
		/// notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in Internet standard
		/// format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero
		/// numbers is replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address.
		/// The last 32 bits are represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.
		/// </para>
		/// <para>
		/// If the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of
		/// the IP address, <c>InetNtop</c> returns ERROR_INVALID_PARAMETER.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetNtop</c> is defined to <c>InetNtopW</c>, the Unicode version of this function. The
		/// pStringBuf parameter is defined to the <c>PSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetNtop</c> is defined to <c>InetNtopA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as <c>inet_ntop</c>. The pStringBuf parameter is defined to the <c>PWSTR</c>
		/// data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4AddressToString and RtlIpv4AddressToStringEx functions can be used to convert an IPv4
		/// address represented as an IN_ADDR structure to a string representation of an IPv4 address in Internet standard dotted-decimal
		/// notation. On Windows Vista and later, the RtlIpv6AddressToString and RtlIpv6AddressToStringEx functions can be used to convert
		/// an IPv6 address represented as an IN6_ADDR structure to a string representation of an IPv6 address. The
		/// <c>RtlIpv6AddressToStringEx</c> function is more flexible since it also converts an IPv6 address, scope ID, and port to a IPv6
		/// string in standard format.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetNtopW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_ntop PCSTR WSAAPI inet_ntop( INT Family, const
		// VOID *pAddr, PSTR pStringBuf, size_t StringBufSize );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "1e26b88c-808f-4807-8641-e5c6b10853ad")]
		public static extern StrPtrAnsi inet_ntop(ADDRESS_FAMILY Family, in IN_ADDR pAddr, StringBuilder pStringBuf, SizeT StringBufSize);

		/// <summary>
		/// The <c>InetNtop</c> function converts an IPv4 or IPv6 Internet network address into a string in Internet standard format. The
		/// ANSI version of this function is <c>inet_ntop</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns an IPv4 address string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns an IPv6 address string.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAddr">
		/// <para>A pointer to the IP address in network byte to convert to a string.</para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address
		/// to convert.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address
		/// to convert.
		/// </para>
		/// </param>
		/// <param name="pStringBuf">
		/// <para>A pointer to a buffer in which to store the <c>NULL</c>-terminated string representation of the IP address.</para>
		/// <para>For an IPv4 address, this buffer should be large enough to hold at least 16 characters.</para>
		/// <para>For an IPv6 address, this buffer should be large enough to hold at least 46 characters.</para>
		/// </param>
		/// <param name="StringBufSize">On input, the length, in characters, of the buffer pointed to by the pStringBuf parameter.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>InetNtop</c> function returns a pointer to a buffer containing the string representation of IP address in
		/// standard format.
		/// </para>
		/// <para>
		/// Otherwise, a value of <c>NULL</c> is returned, and a specific error code can be retrieved by calling the WSAGetLastError for
		/// extended error information.
		/// </para>
		/// <para>If the function fails, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pStringBuf or the
		/// StringBufSize parameter is zero. This error is also returned if the length of the buffer pointed to by the pStringBuf parameter
		/// is not large enough to receive the string representation of the IP address.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetNtop</c> function is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>InetNtop</c> function provides a protocol-independent address-to-string translation. The <c>InetNtop</c> function takes
		/// an Internet address structure specified by the pAddr parameter and returns a <c>NULL</c>-terminated string that represents the
		/// IP address. While the inet_ntoa function works only with IPv4 addresses, the <c>InetNtop</c> function works with either IPv4 or
		/// IPv6 addresses.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_ntop</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>The <c>InetNtop</c> function does not require that the Windows Sockets DLL be loaded to perform IP address to string conversion.</para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in dotted-decimal
		/// notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in Internet standard
		/// format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero
		/// numbers is replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address.
		/// The last 32 bits are represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.
		/// </para>
		/// <para>
		/// If the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of
		/// the IP address, <c>InetNtop</c> returns ERROR_INVALID_PARAMETER.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetNtop</c> is defined to <c>InetNtopW</c>, the Unicode version of this function. The
		/// pStringBuf parameter is defined to the <c>PSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetNtop</c> is defined to <c>InetNtopA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as <c>inet_ntop</c>. The pStringBuf parameter is defined to the <c>PWSTR</c>
		/// data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4AddressToString and RtlIpv4AddressToStringEx functions can be used to convert an IPv4
		/// address represented as an IN_ADDR structure to a string representation of an IPv4 address in Internet standard dotted-decimal
		/// notation. On Windows Vista and later, the RtlIpv6AddressToString and RtlIpv6AddressToStringEx functions can be used to convert
		/// an IPv6 address represented as an IN6_ADDR structure to a string representation of an IPv6 address. The
		/// <c>RtlIpv6AddressToStringEx</c> function is more flexible since it also converts an IPv6 address, scope ID, and port to a IPv6
		/// string in standard format.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetNtopW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_ntop PCSTR WSAAPI inet_ntop( INT Family, const
		// VOID *pAddr, PSTR pStringBuf, size_t StringBufSize );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "1e26b88c-808f-4807-8641-e5c6b10853ad")]
		public static extern StrPtrAnsi inet_ntop(ADDRESS_FAMILY Family, in IN6_ADDR pAddr, StringBuilder pStringBuf, SizeT StringBufSize);

		/// <summary>
		/// The <c>InetPton</c> function converts an IPv4 or IPv6 Internet network address in its standard text presentation form into its
		/// numeric binary form. The ANSI version of this function is <c>inet_pton</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv4 address and the pAddrBuf parameter returns a pointer to an IN_ADDR structure that represents
		/// the IPv4 address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv6 address and the pAddrBuf parameter returns a pointer to an IN6_ADDR structure that
		/// represents the IPv6 address.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pszAddrString">
		/// <para>
		/// A pointer to the <c>NULL</c>-terminated string that contains the text representation of the IP address to convert to numeric
		/// binary form.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pszAddrString parameter must point to a text representation of an IPv4
		/// address in standard dotted-decimal notation.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pszAddrString parameter must point to a text representation of an IPv6
		/// address in standard notation.
		/// </para>
		/// </param>
		/// <param name="pAddrBuf">
		/// <para>
		/// A pointer to a buffer in which to store the numeric binary representation of the IP address. The IP address is returned in
		/// network byte order.
		/// </para>
		/// <para>When the Family parameter is <c>AF_INET</c>, this buffer should be large enough to hold an IN_ADDR structure.</para>
		/// <para>When the Family parameter is <c>AF_INET6</c>, this buffer should be large enough to hold an IN6_ADDR structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, the <c>InetPton</c> function returns a value of 1 and the buffer pointed to by the pAddrBuf parameter
		/// contains the binary numeric IP address in network byte order.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function returns a value of 0 if the pAddrBuf parameter points to a string that is not a valid IPv4
		/// dotted-decimal string or a valid IPv6 address string. Otherwise, a value of -1 is returned, and a specific error code can be
		/// retrieved by calling the WSAGetLastError for extended error information.
		/// </para>
		/// <para>If the function has an error, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The pszAddrString or pAddrBuf parameters are NULL or are not part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetPton</c> function is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>InetPton</c> function provides a protocol-independent conversion of an Internet network address in its standard text
		/// presentation form into its numeric binary form. The <c>InetPton</c> function takes a text representation of an Internet address
		/// pointed to by the pszAddrString parameter and returns a pointer to the numeric binary IP address in the pAddrBuf parameter.
		/// While the inet_addrfunction works only with IPv4 address strings, the <c>InetPton</c> function works with either IPv4 or IPv6
		/// address strings.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_pton</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function does not require that the Windows Sockets DLL be loaded to perform conversion of a text string that
		/// represents an IP address to a numeric binary IP address.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pszAddrString parameter must point a text string of an IPv4
		/// address in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pszAddrString parameter must point a text string of an IPv6
		/// address in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A
		/// string of consecutive zero numbers may be replaced with a double-colon. There can only be one double-colon in the string
		/// representation of the IPv6 address. The last 32 bits may be represented in IPv4-style dotted-octet notation if the address is a
		/// IPv4-compatible address.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetPton</c> is defined to <c>InetPtonW</c>, the Unicode version of this function. The
		/// pszAddrString parameter is defined to the <c>PCWSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetPton</c> is defined to <c>InetPtonA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as inet_pton. The pszAddrString parameter is defined to the <c>PCSTR</c> data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4StringToAddress and RtlIpv4StringToAddressEx functions can be used to convert a text
		/// representation of an IPv4 address in Internet standard dotted-decimal notation to a numeric binary address represented as an
		/// IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress and RtlIpv6StringToAddressEx functions can be used to
		/// convert a string representation of an IPv6 address to a numeric binary IPv6 address represented as an IN6_ADDR structure. The
		/// <c>RtlIpv6StringToAddressEx</c> function is more flexible since it also converts a string representation of an IPv6 address that
		/// can include a scope ID and port in standard notation to a numeric binary form.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetPtonW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_pton INT WSAAPI inet_pton( INT Family, PCSTR
		// pszAddrString, PVOID pAddrBuf );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "d0705997-0dc7-443b-a43f-611301cc9169")]
		public static extern SocketError inet_pton(ADDRESS_FAMILY Family, string pszAddrString, out IN_ADDR pAddrBuf);

		/// <summary>
		/// The <c>InetPton</c> function converts an IPv4 or IPv6 Internet network address in its standard text presentation form into its
		/// numeric binary form. The ANSI version of this function is <c>inet_pton</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv4 address and the pAddrBuf parameter returns a pointer to an IN_ADDR structure that represents
		/// the IPv4 address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv6 address and the pAddrBuf parameter returns a pointer to an IN6_ADDR structure that
		/// represents the IPv6 address.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pszAddrString">
		/// <para>
		/// A pointer to the <c>NULL</c>-terminated string that contains the text representation of the IP address to convert to numeric
		/// binary form.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pszAddrString parameter must point to a text representation of an IPv4
		/// address in standard dotted-decimal notation.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pszAddrString parameter must point to a text representation of an IPv6
		/// address in standard notation.
		/// </para>
		/// </param>
		/// <param name="pAddrBuf">
		/// <para>
		/// A pointer to a buffer in which to store the numeric binary representation of the IP address. The IP address is returned in
		/// network byte order.
		/// </para>
		/// <para>When the Family parameter is <c>AF_INET</c>, this buffer should be large enough to hold an IN_ADDR structure.</para>
		/// <para>When the Family parameter is <c>AF_INET6</c>, this buffer should be large enough to hold an IN6_ADDR structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, the <c>InetPton</c> function returns a value of 1 and the buffer pointed to by the pAddrBuf parameter
		/// contains the binary numeric IP address in network byte order.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function returns a value of 0 if the pAddrBuf parameter points to a string that is not a valid IPv4
		/// dotted-decimal string or a valid IPv6 address string. Otherwise, a value of -1 is returned, and a specific error code can be
		/// retrieved by calling the WSAGetLastError for extended error information.
		/// </para>
		/// <para>If the function has an error, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The pszAddrString or pAddrBuf parameters are NULL or are not part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetPton</c> function is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>InetPton</c> function provides a protocol-independent conversion of an Internet network address in its standard text
		/// presentation form into its numeric binary form. The <c>InetPton</c> function takes a text representation of an Internet address
		/// pointed to by the pszAddrString parameter and returns a pointer to the numeric binary IP address in the pAddrBuf parameter.
		/// While the inet_addrfunction works only with IPv4 address strings, the <c>InetPton</c> function works with either IPv4 or IPv6
		/// address strings.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_pton</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function does not require that the Windows Sockets DLL be loaded to perform conversion of a text string that
		/// represents an IP address to a numeric binary IP address.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pszAddrString parameter must point a text string of an IPv4
		/// address in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pszAddrString parameter must point a text string of an IPv6
		/// address in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A
		/// string of consecutive zero numbers may be replaced with a double-colon. There can only be one double-colon in the string
		/// representation of the IPv6 address. The last 32 bits may be represented in IPv4-style dotted-octet notation if the address is a
		/// IPv4-compatible address.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetPton</c> is defined to <c>InetPtonW</c>, the Unicode version of this function. The
		/// pszAddrString parameter is defined to the <c>PCWSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetPton</c> is defined to <c>InetPtonA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as inet_pton. The pszAddrString parameter is defined to the <c>PCSTR</c> data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4StringToAddress and RtlIpv4StringToAddressEx functions can be used to convert a text
		/// representation of an IPv4 address in Internet standard dotted-decimal notation to a numeric binary address represented as an
		/// IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress and RtlIpv6StringToAddressEx functions can be used to
		/// convert a string representation of an IPv6 address to a numeric binary IPv6 address represented as an IN6_ADDR structure. The
		/// <c>RtlIpv6StringToAddressEx</c> function is more flexible since it also converts a string representation of an IPv6 address that
		/// can include a scope ID and port in standard notation to a numeric binary form.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetPtonW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_pton INT WSAAPI inet_pton( INT Family, PCSTR
		// pszAddrString, PVOID pAddrBuf );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "d0705997-0dc7-443b-a43f-611301cc9169")]
		public static extern SocketError inet_pton(ADDRESS_FAMILY Family, string pszAddrString, out IN6_ADDR pAddrBuf);

		/// <summary>
		/// The <c>InetNtop</c> function converts an IPv4 or IPv6 Internet network address into a string in Internet standard format. The
		/// ANSI version of this function is <c>inet_ntop</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns an IPv4 address string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns an IPv6 address string.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAddr">
		/// <para>A pointer to the IP address in network byte to convert to a string.</para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address
		/// to convert.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address
		/// to convert.
		/// </para>
		/// </param>
		/// <param name="pStringBuf">
		/// <para>A pointer to a buffer in which to store the <c>NULL</c>-terminated string representation of the IP address.</para>
		/// <para>For an IPv4 address, this buffer should be large enough to hold at least 16 characters.</para>
		/// <para>For an IPv6 address, this buffer should be large enough to hold at least 46 characters.</para>
		/// </param>
		/// <param name="StringBufSize">On input, the length, in characters, of the buffer pointed to by the pStringBuf parameter.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>InetNtop</c> function returns a pointer to a buffer containing the string representation of IP address in
		/// standard format.
		/// </para>
		/// <para>
		/// Otherwise, a value of <c>NULL</c> is returned, and a specific error code can be retrieved by calling the WSAGetLastError for
		/// extended error information.
		/// </para>
		/// <para>If the function fails, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pStringBuf or the
		/// StringBufSize parameter is zero. This error is also returned if the length of the buffer pointed to by the pStringBuf parameter
		/// is not large enough to receive the string representation of the IP address.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetNtop</c> function is supported on Windows Vista and later.</para>
		/// <para>
		/// The <c>InetNtop</c> function provides a protocol-independent address-to-string translation. The <c>InetNtop</c> function takes
		/// an Internet address structure specified by the pAddr parameter and returns a <c>NULL</c>-terminated string that represents the
		/// IP address. While the inet_ntoa function works only with IPv4 addresses, the <c>InetNtop</c> function works with either IPv4 or
		/// IPv6 addresses.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_ntop</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>The <c>InetNtop</c> function does not require that the Windows Sockets DLL be loaded to perform IP address to string conversion.</para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in dotted-decimal
		/// notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in Internet standard
		/// format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero
		/// numbers is replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address.
		/// The last 32 bits are represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.
		/// </para>
		/// <para>
		/// If the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of
		/// the IP address, <c>InetNtop</c> returns ERROR_INVALID_PARAMETER.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetNtop</c> is defined to <c>InetNtopW</c>, the Unicode version of this function. The
		/// pStringBuf parameter is defined to the <c>PSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetNtop</c> is defined to <c>InetNtopA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as <c>inet_ntop</c>. The pStringBuf parameter is defined to the <c>PWSTR</c>
		/// data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4AddressToString and RtlIpv4AddressToStringEx functions can be used to convert an IPv4
		/// address represented as an IN_ADDR structure to a string representation of an IPv4 address in Internet standard dotted-decimal
		/// notation. On Windows Vista and later, the RtlIpv6AddressToString and RtlIpv6AddressToStringEx functions can be used to convert
		/// an IPv6 address represented as an IN6_ADDR structure to a string representation of an IPv6 address. The
		/// <c>RtlIpv6AddressToStringEx</c> function is more flexible since it also converts an IPv6 address, scope ID, and port to a IPv6
		/// string in standard format.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetNtopW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-inetntopw PCWSTR WSAAPI InetNtopW( INT Family, const VOID
		// *pAddr, PWSTR pStringBuf, size_t StringBufSize );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "1e26b88c-808f-4807-8641-e5c6b10853ad")]
		public static extern StrPtrUni InetNtopW(ADDRESS_FAMILY Family, in IN_ADDR pAddr, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pStringBuf, SizeT StringBufSize);

		/// <summary>
		/// The <c>InetNtop</c> function converts an IPv4 or IPv6 Internet network address into a string in Internet standard format. The
		/// ANSI version of this function is <c>inet_ntop</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns an IPv4 address string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns an IPv6 address string.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pAddr">
		/// <para>A pointer to the IP address in network byte to convert to a string.</para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address
		/// to convert.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address
		/// to convert.
		/// </para>
		/// </param>
		/// <param name="pStringBuf">
		/// <para>A pointer to a buffer in which to store the <c>NULL</c>-terminated string representation of the IP address.</para>
		/// <para>For an IPv4 address, this buffer should be large enough to hold at least 16 characters.</para>
		/// <para>For an IPv6 address, this buffer should be large enough to hold at least 46 characters.</para>
		/// </param>
		/// <param name="StringBufSize">On input, the length, in characters, of the buffer pointed to by the pStringBuf parameter.</param>
		/// <returns>
		/// <para>
		/// If no error occurs, <c>InetNtop</c> function returns a pointer to a buffer containing the string representation of IP address in
		/// standard format.
		/// </para>
		/// <para>
		/// Otherwise, a value of <c>NULL</c> is returned, and a specific error code can be retrieved by calling the WSAGetLastError for
		/// extended error information.
		/// </para>
		/// <para>If the function fails, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pStringBuf or the
		/// StringBufSize parameter is zero. This error is also returned if the length of the buffer pointed to by the pStringBuf parameter
		/// is not large enough to receive the string representation of the IP address.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetNtop</c> function is supported on Windows Vista and later.</para>
		/// <para>
		/// The <c>InetNtop</c> function provides a protocol-independent address-to-string translation. The <c>InetNtop</c> function takes
		/// an Internet address structure specified by the pAddr parameter and returns a <c>NULL</c>-terminated string that represents the
		/// IP address. While the inet_ntoa function works only with IPv4 addresses, the <c>InetNtop</c> function works with either IPv4 or
		/// IPv6 addresses.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_ntop</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>The <c>InetNtop</c> function does not require that the Windows Sockets DLL be loaded to perform IP address to string conversion.</para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in dotted-decimal
		/// notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6
		/// address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in Internet standard
		/// format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero
		/// numbers is replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address.
		/// The last 32 bits are represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.
		/// </para>
		/// <para>
		/// If the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of
		/// the IP address, <c>InetNtop</c> returns ERROR_INVALID_PARAMETER.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetNtop</c> is defined to <c>InetNtopW</c>, the Unicode version of this function. The
		/// pStringBuf parameter is defined to the <c>PSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetNtop</c> is defined to <c>InetNtopA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as <c>inet_ntop</c>. The pStringBuf parameter is defined to the <c>PWSTR</c>
		/// data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4AddressToString and RtlIpv4AddressToStringEx functions can be used to convert an IPv4
		/// address represented as an IN_ADDR structure to a string representation of an IPv4 address in Internet standard dotted-decimal
		/// notation. On Windows Vista and later, the RtlIpv6AddressToString and RtlIpv6AddressToStringEx functions can be used to convert
		/// an IPv6 address represented as an IN6_ADDR structure to a string representation of an IPv6 address. The
		/// <c>RtlIpv6AddressToStringEx</c> function is more flexible since it also converts an IPv6 address, scope ID, and port to a IPv6
		/// string in standard format.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetNtopW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-inetntopw PCWSTR WSAAPI InetNtopW( INT Family, const VOID
		// *pAddr, PWSTR pStringBuf, size_t StringBufSize );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "1e26b88c-808f-4807-8641-e5c6b10853ad")]
		public static extern StrPtrUni InetNtopW(ADDRESS_FAMILY Family, in IN6_ADDR pAddr, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pStringBuf, SizeT StringBufSize);

		/// <summary>
		/// The <c>InetPton</c> function converts an IPv4 or IPv6 Internet network address in its standard text presentation form into its
		/// numeric binary form. The ANSI version of this function is <c>inet_pton</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv4 address and the pAddrBuf parameter returns a pointer to an IN_ADDR structure that represents
		/// the IPv4 address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv6 address and the pAddrBuf parameter returns a pointer to an IN6_ADDR structure that
		/// represents the IPv6 address.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pszAddrString">
		/// <para>
		/// A pointer to the <c>NULL</c>-terminated string that contains the text representation of the IP address to convert to numeric
		/// binary form.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pszAddrString parameter must point to a text representation of an IPv4
		/// address in standard dotted-decimal notation.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pszAddrString parameter must point to a text representation of an IPv6
		/// address in standard notation.
		/// </para>
		/// </param>
		/// <param name="pAddrBuf">
		/// <para>
		/// A pointer to a buffer in which to store the numeric binary representation of the IP address. The IP address is returned in
		/// network byte order.
		/// </para>
		/// <para>When the Family parameter is <c>AF_INET</c>, this buffer should be large enough to hold an IN_ADDR structure.</para>
		/// <para>When the Family parameter is <c>AF_INET6</c>, this buffer should be large enough to hold an IN6_ADDR structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, the <c>InetPton</c> function returns a value of 1 and the buffer pointed to by the pAddrBuf parameter
		/// contains the binary numeric IP address in network byte order.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function returns a value of 0 if the pAddrBuf parameter points to a string that is not a valid IPv4
		/// dotted-decimal string or a valid IPv6 address string. Otherwise, a value of -1 is returned, and a specific error code can be
		/// retrieved by calling the WSAGetLastError for extended error information.
		/// </para>
		/// <para>If the function has an error, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The pszAddrString or pAddrBuf parameters are NULL or are not part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetPton</c> function is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>InetPton</c> function provides a protocol-independent conversion of an Internet network address in its standard text
		/// presentation form into its numeric binary form. The <c>InetPton</c> function takes a text representation of an Internet address
		/// pointed to by the pszAddrString parameter and returns a pointer to the numeric binary IP address in the pAddrBuf parameter.
		/// While the inet_addrfunction works only with IPv4 address strings, the <c>InetPton</c> function works with either IPv4 or IPv6
		/// address strings.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_pton</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function does not require that the Windows Sockets DLL be loaded to perform conversion of a text string that
		/// represents an IP address to a numeric binary IP address.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pszAddrString parameter must point a text string of an IPv4
		/// address in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pszAddrString parameter must point a text string of an IPv6
		/// address in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A
		/// string of consecutive zero numbers may be replaced with a double-colon. There can only be one double-colon in the string
		/// representation of the IPv6 address. The last 32 bits may be represented in IPv4-style dotted-octet notation if the address is a
		/// IPv4-compatible address.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetPton</c> is defined to <c>InetPtonW</c>, the Unicode version of this function. The
		/// pszAddrString parameter is defined to the <c>PCWSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetPton</c> is defined to <c>InetPtonA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as inet_pton. The pszAddrString parameter is defined to the <c>PCSTR</c> data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4StringToAddress and RtlIpv4StringToAddressEx functions can be used to convert a text
		/// representation of an IPv4 address in Internet standard dotted-decimal notation to a numeric binary address represented as an
		/// IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress and RtlIpv6StringToAddressEx functions can be used to
		/// convert a string representation of an IPv6 address to a numeric binary IPv6 address represented as an IN6_ADDR structure. The
		/// <c>RtlIpv6StringToAddressEx</c> function is more flexible since it also converts a string representation of an IPv6 address that
		/// can include a scope ID and port in standard notation to a numeric binary form.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetPtonW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-inetptonw INT WSAAPI InetPtonW( INT Family, PCWSTR
		// pszAddrString, PVOID pAddrBuf );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "d0705997-0dc7-443b-a43f-611301cc9169")]
		public static extern SocketError InetPtonW(ADDRESS_FAMILY Family, [MarshalAs(UnmanagedType.LPWStr)] string pszAddrString, out IN_ADDR pAddrBuf);

		/// <summary>
		/// The <c>InetPton</c> function converts an IPv4 or IPv6 Internet network address in its standard text presentation form into its
		/// numeric binary form. The ANSI version of this function is <c>inet_pton</c>.
		/// </summary>
		/// <param name="Family">
		/// <para>The address family.</para>
		/// <para>
		/// Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is
		/// automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_
		/// protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.
		/// </para>
		/// <para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AF_INET 2</term>
		/// <term>
		/// The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv4 address and the pAddrBuf parameter returns a pointer to an IN_ADDR structure that represents
		/// the IPv4 address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AF_INET6 23</term>
		/// <term>
		/// The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the pszAddrString parameter must point
		/// to a text representation of an IPv6 address and the pAddrBuf parameter returns a pointer to an IN6_ADDR structure that
		/// represents the IPv6 address.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pszAddrString">
		/// <para>
		/// A pointer to the <c>NULL</c>-terminated string that contains the text representation of the IP address to convert to numeric
		/// binary form.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET</c>, then the pszAddrString parameter must point to a text representation of an IPv4
		/// address in standard dotted-decimal notation.
		/// </para>
		/// <para>
		/// When the Family parameter is <c>AF_INET6</c>, then the pszAddrString parameter must point to a text representation of an IPv6
		/// address in standard notation.
		/// </para>
		/// </param>
		/// <param name="pAddrBuf">
		/// <para>
		/// A pointer to a buffer in which to store the numeric binary representation of the IP address. The IP address is returned in
		/// network byte order.
		/// </para>
		/// <para>When the Family parameter is <c>AF_INET</c>, this buffer should be large enough to hold an IN_ADDR structure.</para>
		/// <para>When the Family parameter is <c>AF_INET6</c>, this buffer should be large enough to hold an IN6_ADDR structure.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If no error occurs, the <c>InetPton</c> function returns a value of 1 and the buffer pointed to by the pAddrBuf parameter
		/// contains the binary numeric IP address in network byte order.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function returns a value of 0 if the pAddrBuf parameter points to a string that is not a valid IPv4
		/// dotted-decimal string or a valid IPv6 address string. Otherwise, a value of -1 is returned, and a specific error code can be
		/// retrieved by calling the WSAGetLastError for extended error information.
		/// </para>
		/// <para>If the function has an error, the extended error code returned by WSAGetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAEAFNOSUPPORT</term>
		/// <term>
		/// The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified
		/// was not AF_INET or AF_INET6.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WSAEFAULT</term>
		/// <term>The pszAddrString or pAddrBuf parameters are NULL or are not part of the user address space.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>InetPton</c> function is supported on Windows Vistaand later.</para>
		/// <para>
		/// The <c>InetPton</c> function provides a protocol-independent conversion of an Internet network address in its standard text
		/// presentation form into its numeric binary form. The <c>InetPton</c> function takes a text representation of an Internet address
		/// pointed to by the pszAddrString parameter and returns a pointer to the numeric binary IP address in the pAddrBuf parameter.
		/// While the inet_addrfunction works only with IPv4 address strings, the <c>InetPton</c> function works with either IPv4 or IPv6
		/// address strings.
		/// </para>
		/// <para>
		/// The ANSI version of this function is <c>inet_pton</c> as defined in RFC 2553. For more information, see RFC 2553 available at
		/// the IETF website.
		/// </para>
		/// <para>
		/// The <c>InetPton</c> function does not require that the Windows Sockets DLL be loaded to perform conversion of a text string that
		/// represents an IP address to a numeric binary IP address.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET</c>, then the pszAddrString parameter must point a text string of an IPv4
		/// address in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.
		/// </para>
		/// <para>
		/// If the Family parameter specified is <c>AF_INET6</c>, then the pszAddrString parameter must point a text string of an IPv6
		/// address in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A
		/// string of consecutive zero numbers may be replaced with a double-colon. There can only be one double-colon in the string
		/// representation of the IPv6 address. The last 32 bits may be represented in IPv4-style dotted-octet notation if the address is a
		/// IPv4-compatible address.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is defined, <c>InetPton</c> is defined to <c>InetPtonW</c>, the Unicode version of this function. The
		/// pszAddrString parameter is defined to the <c>PCWSTR</c> data type.
		/// </para>
		/// <para>
		/// When UNICODE or _UNICODE is not defined, <c>InetPton</c> is defined to <c>InetPtonA</c>, the ANSI version of this function. The
		/// ANSI version of this function is always defined as inet_pton. The pszAddrString parameter is defined to the <c>PCSTR</c> data type.
		/// </para>
		/// <para>The IN_ADDR structure is defined in the Inaddr.h header file.</para>
		/// <para>The IN6_ADDR structure is defined in the In6addr.h header file.</para>
		/// <para>
		/// On Windows Vista and later, the RtlIpv4StringToAddress and RtlIpv4StringToAddressEx functions can be used to convert a text
		/// representation of an IPv4 address in Internet standard dotted-decimal notation to a numeric binary address represented as an
		/// IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress and RtlIpv6StringToAddressEx functions can be used to
		/// convert a string representation of an IPv6 address to a numeric binary IPv6 address represented as an IN6_ADDR structure. The
		/// <c>RtlIpv6StringToAddressEx</c> function is more flexible since it also converts a string representation of an IPv6 address that
		/// can include a scope ID and port in standard notation to a numeric binary form.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetPtonW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-inetptonw INT WSAAPI InetPtonW( INT Family, PCWSTR
		// pszAddrString, PVOID pAddrBuf );
		[DllImport(Lib.Ws2_32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "d0705997-0dc7-443b-a43f-611301cc9169")]
		public static extern SocketError InetPtonW(ADDRESS_FAMILY Family, [MarshalAs(UnmanagedType.LPWStr)] string pszAddrString, out IN6_ADDR pAddrBuf);

		/// <summary>
		/// The <c>SetAddrInfoEx</c> function registers or deregisters a name, a service name, and associated addresses with a specific
		/// namespace provider.
		/// </summary>
		/// <param name="pName">
		/// A pointer to a <c>NULL</c>-terminated string containing a name under which addresses are to be registered or deregistered. The
		/// interpretation of this parameter specific to the namespace provider.
		/// </param>
		/// <param name="pServiceName">
		/// A pointer to an optional <c>NULL</c>-terminated string that contains the service name associated with the name being registered.
		/// The interpretation of this parameter is specific to the namespace provider.
		/// </param>
		/// <param name="pAddresses">A pointer to an optional list of addresses to register with the namespace provider.</param>
		/// <param name="dwAddressCount">
		/// The number of addresses passed in pAddresses parameter. If this parameter is zero, the pName parameter is deregistered from the
		/// namespace provider.
		/// </param>
		/// <param name="lpBlob">
		/// An optional pointer to data that is used to set provider-specific namespace information that is associated with the pName
		/// parameter beyond a list of addresses. Any information that cannot be passed in the pAddresses parameter can be passed in the
		/// lpBlob parameter. The format of this information is specific to the namespace provider.
		/// </param>
		/// <param name="dwFlags">
		/// A set of flags controlling how the pName and pServiceName parameters are to be registered with the namespace provider. The
		/// interpretation of this information is specific to the namespace provider.
		/// </param>
		/// <param name="dwNameSpace">
		/// <para>
		/// A namespace identifier that determines which namespace provider to register this information with. Passing a specific namespace
		/// identifier will result in registering this information only with the namespace providers that support the specified namespace.
		/// Specifying NS_ALL will result in registering the information with all installed and active namespace providers.
		/// </para>
		/// <para>
		/// Options for the dwNameSpace parameter are listed in the Winsock2.h include file. Several namespace providers are included with
		/// Windows Vista and later. Other namespace providers can be installed, so the following possible values are only those commonly
		/// available. Many others are possible.
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
		/// <term>The peer-to-peer namespace for a specific peer name. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer namespace for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpNspId">
		/// A pointer to an optional GUID of a specific namespace provider to register this information with in the case where multiple
		/// namespace providers are registered under a single namespace such as NS_DNS. Passing the GUID for a specific namespace provider
		/// will result in the information being registered with only the specified namespace provider. The WSAEnumNameSpaceProviders
		/// function can be called to retrieve the GUID for a namespace provider.
		/// </param>
		/// <param name="timeout">
		/// An optional parameter indicating the time, in milliseconds, to wait for a response from the namespace provider before aborting
		/// the call. This parameter is currently reserved and must be set to <c>NULL</c> since a timeout option is not supported.
		/// </param>
		/// <param name="lpOverlapped">
		/// An optional pointer to an overlapped structure used for asynchronous operation. This parameter is currently reserved and must be
		/// set to <c>NULL</c> since asynchronous operations are not supported.
		/// </param>
		/// <param name="lpCompletionRoutine">
		/// An optional pointer to a function to be invoked upon successful completion for asynchronous operations. This parameter is
		/// currently reserved and must be set to <c>NULL</c> since asynchronous operations are not supported.
		/// </param>
		/// <param name="lpNameHandle">
		/// An optional pointer used only for asynchronous operations. This parameter is currently reserved and must be set to <c>NULL</c>
		/// since asynchronous operations are not supported.
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>SetAddrInfoEx</c> returns NO_ERROR (0). Failure returns a nonzero Windows Sockets error code, as found in the
		/// Windows Sockets Error Codes.
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
		/// <term>WSATRY_AGAIN</term>
		/// <term>A temporary failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>An invalid parameter was provided. This error is returned if any of the reserved parameters are not NULL.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>A nonrecoverable failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetAddrInfoEx</c> function provides a protocol-independent method to register or deregister a name and one or more
		/// addresses with a namespace provider. The NS_EMAIL namespace provider in Windows Vista and later supports registration and
		/// deregistration of addresses. The default NS_DNS, NS_PNRPNAME, and NS_PNRPNAME namespace providers do not currently support name registration.
		/// </para>
		/// <para>
		/// If the <c>SetAddrInfoEx</c> function is called with NS_ALL set as the dwNameSpace parameter and the lpNspId parameter
		/// unspecified, then <c>SetAddrInfoEx</c> will attempt to register or deregister the name and associated addresses with all
		/// installed and active namespaces. The <c>SetAddrInfoEx</c> function will return success if any of the namespace providers
		/// successfully registered or deregistered the name, but there will not be any indication of which namespace provider succeeded or
		/// which ones failed the request.
		/// </para>
		/// <para>
		/// When <c>UNICODE</c> or <c>_UNICODE</c> is defined, <c>SetAddrInfoEx</c> is defined to SetAddrInfoExW, the Unicode version of
		/// this function. The string parameters are defined to the <c>PWSTR</c> data type.
		/// </para>
		/// <para>
		/// When <c>UNICODE</c> or <c>_UNICODE</c> is not defined, <c>SetAddrInfoEx</c> is defined to SetAddrInfoExA, the ANSI version of
		/// this function. The string parameters are of the <c>PCSTR</c> data type.
		/// </para>
		/// <para>
		/// Information that is registered with a namespace provider can be returned by calling the GetAddrInfoEx, getaddrinfo, or
		/// GetAddrInfoWfunctions. The <c>GetAddrInfoEx</c> function is an enhanced version of the <c>getaddrinfo</c> and
		/// <c>GetAddrInfoW</c> functions.
		/// </para>
		/// <para>
		/// On Windows Vista and later, when <c>SetAddrInfoEx</c> is called from a service, if the operation is the result of a user process
		/// calling the service, then the service should impersonate the user. This is to allow security and routing compartments to be
		/// properly enforced.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>SetAddrInfoExW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-setaddrinfoexa INT WSAAPI SetAddrInfoExA( PCSTR pName,
		// PCSTR pServiceName, SOCKET_ADDRESS *pAddresses, DWORD dwAddressCount, LPBLOB lpBlob, DWORD dwFlags, DWORD dwNameSpace, LPGUID
		// lpNspId, timeval *timeout, LPOVERLAPPED lpOverlapped, LPLOOKUPSERVICE_COMPLETION_ROUTINE lpCompletionRoutine, LPHANDLE
		// lpNameHandle );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "6d3c5b97-32ce-4eb5-a047-d9b37c37cdda")]
		public static extern SocketError SetAddrInfoEx([MarshalAs(UnmanagedType.LPTStr)] string pName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string pServiceName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] SOCKET_ADDRESS[] pAddresses, [Optional] uint dwAddressCount, [In, Optional] IntPtr lpBlob, [Optional] uint dwFlags, [Optional] NS dwNameSpace,
			in Guid lpNspId, in TIMEVAL timeout, [In, Optional] IntPtr lpOverlapped, [In, Optional] LPLOOKUPSERVICE_COMPLETION_ROUTINE lpCompletionRoutine, out HANDLE lpNameHandle);

		/// <summary>
		/// The <c>SetAddrInfoEx</c> function registers or deregisters a name, a service name, and associated addresses with a specific
		/// namespace provider.
		/// </summary>
		/// <param name="pName">
		/// A pointer to a <c>NULL</c>-terminated string containing a name under which addresses are to be registered or deregistered. The
		/// interpretation of this parameter specific to the namespace provider.
		/// </param>
		/// <param name="pServiceName">
		/// A pointer to an optional <c>NULL</c>-terminated string that contains the service name associated with the name being registered.
		/// The interpretation of this parameter is specific to the namespace provider.
		/// </param>
		/// <param name="pAddresses">A pointer to an optional list of addresses to register with the namespace provider.</param>
		/// <param name="dwAddressCount">
		/// The number of addresses passed in pAddresses parameter. If this parameter is zero, the pName parameter is deregistered from the
		/// namespace provider.
		/// </param>
		/// <param name="lpBlob">
		/// An optional pointer to data that is used to set provider-specific namespace information that is associated with the pName
		/// parameter beyond a list of addresses. Any information that cannot be passed in the pAddresses parameter can be passed in the
		/// lpBlob parameter. The format of this information is specific to the namespace provider.
		/// </param>
		/// <param name="dwFlags">
		/// A set of flags controlling how the pName and pServiceName parameters are to be registered with the namespace provider. The
		/// interpretation of this information is specific to the namespace provider.
		/// </param>
		/// <param name="dwNameSpace">
		/// <para>
		/// A namespace identifier that determines which namespace provider to register this information with. Passing a specific namespace
		/// identifier will result in registering this information only with the namespace providers that support the specified namespace.
		/// Specifying NS_ALL will result in registering the information with all installed and active namespace providers.
		/// </para>
		/// <para>
		/// Options for the dwNameSpace parameter are listed in the Winsock2.h include file. Several namespace providers are included with
		/// Windows Vista and later. Other namespace providers can be installed, so the following possible values are only those commonly
		/// available. Many others are possible.
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
		/// <term>The peer-to-peer namespace for a specific peer name. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer namespace for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpNspId">
		/// A pointer to an optional GUID of a specific namespace provider to register this information with in the case where multiple
		/// namespace providers are registered under a single namespace such as NS_DNS. Passing the GUID for a specific namespace provider
		/// will result in the information being registered with only the specified namespace provider. The WSAEnumNameSpaceProviders
		/// function can be called to retrieve the GUID for a namespace provider.
		/// </param>
		/// <param name="timeout">
		/// An optional parameter indicating the time, in milliseconds, to wait for a response from the namespace provider before aborting
		/// the call. This parameter is currently reserved and must be set to <c>NULL</c> since a timeout option is not supported.
		/// </param>
		/// <param name="lpOverlapped">
		/// An optional pointer to an overlapped structure used for asynchronous operation. This parameter is currently reserved and must be
		/// set to <c>NULL</c> since asynchronous operations are not supported.
		/// </param>
		/// <param name="lpCompletionRoutine">
		/// An optional pointer to a function to be invoked upon successful completion for asynchronous operations. This parameter is
		/// currently reserved and must be set to <c>NULL</c> since asynchronous operations are not supported.
		/// </param>
		/// <param name="lpNameHandle">
		/// An optional pointer used only for asynchronous operations. This parameter is currently reserved and must be set to <c>NULL</c>
		/// since asynchronous operations are not supported.
		/// </param>
		/// <returns>
		/// <para>
		/// On success, <c>SetAddrInfoEx</c> returns NO_ERROR (0). Failure returns a nonzero Windows Sockets error code, as found in the
		/// Windows Sockets Error Codes.
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
		/// <term>WSATRY_AGAIN</term>
		/// <term>A temporary failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>WSAEINVAL</term>
		/// <term>An invalid parameter was provided. This error is returned if any of the reserved parameters are not NULL.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSANO_RECOVERY</term>
		/// <term>A nonrecoverable failure in name resolution occurred.</term>
		/// </item>
		/// <item>
		/// <term>WSA_NOT_ENOUGH_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetAddrInfoEx</c> function provides a protocol-independent method to register or deregister a name and one or more
		/// addresses with a namespace provider. The NS_EMAIL namespace provider in Windows Vista and later supports registration and
		/// deregistration of addresses. The default NS_DNS, NS_PNRPNAME, and NS_PNRPNAME namespace providers do not currently support name registration.
		/// </para>
		/// <para>
		/// If the <c>SetAddrInfoEx</c> function is called with NS_ALL set as the dwNameSpace parameter and the lpNspId parameter
		/// unspecified, then <c>SetAddrInfoEx</c> will attempt to register or deregister the name and associated addresses with all
		/// installed and active namespaces. The <c>SetAddrInfoEx</c> function will return success if any of the namespace providers
		/// successfully registered or deregistered the name, but there will not be any indication of which namespace provider succeeded or
		/// which ones failed the request.
		/// </para>
		/// <para>
		/// When <c>UNICODE</c> or <c>_UNICODE</c> is defined, <c>SetAddrInfoEx</c> is defined to SetAddrInfoExW, the Unicode version of
		/// this function. The string parameters are defined to the <c>PWSTR</c> data type.
		/// </para>
		/// <para>
		/// When <c>UNICODE</c> or <c>_UNICODE</c> is not defined, <c>SetAddrInfoEx</c> is defined to SetAddrInfoExA, the ANSI version of
		/// this function. The string parameters are of the <c>PCSTR</c> data type.
		/// </para>
		/// <para>
		/// Information that is registered with a namespace provider can be returned by calling the GetAddrInfoEx, getaddrinfo, or
		/// GetAddrInfoWfunctions. The <c>GetAddrInfoEx</c> function is an enhanced version of the <c>getaddrinfo</c> and
		/// <c>GetAddrInfoW</c> functions.
		/// </para>
		/// <para>
		/// On Windows Vista and later, when <c>SetAddrInfoEx</c> is called from a service, if the operation is the result of a user process
		/// calling the service, then the service should impersonate the user. This is to allow security and routing compartments to be
		/// properly enforced.
		/// </para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>SetAddrInfoExW</c> function is supported for Windows Store apps on
		/// Windows 8.1, Windows Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-setaddrinfoexa INT WSAAPI SetAddrInfoExA( PCSTR pName,
		// PCSTR pServiceName, SOCKET_ADDRESS *pAddresses, DWORD dwAddressCount, LPBLOB lpBlob, DWORD dwFlags, DWORD dwNameSpace, LPGUID
		// lpNspId, timeval *timeout, LPOVERLAPPED lpOverlapped, LPLOOKUPSERVICE_COMPLETION_ROUTINE lpCompletionRoutine, LPHANDLE
		// lpNameHandle );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "6d3c5b97-32ce-4eb5-a047-d9b37c37cdda")]
		public static unsafe extern SocketError SetAddrInfoEx([MarshalAs(UnmanagedType.LPTStr)] string pName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string pServiceName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] SOCKET_ADDRESS[] pAddresses, [Optional] uint dwAddressCount, [In, Optional] IntPtr lpBlob,
			[Optional] uint dwFlags, [Optional] NS dwNameSpace, [In, Optional] Guid* lpNspId, [In, Optional] TIMEVAL* timeout,
			[In, Optional] NativeOverlapped* lpOverlapped, [In, Optional] LPLOOKUPSERVICE_COMPLETION_ROUTINE lpCompletionRoutine, [Out, Optional] HANDLE* lpNameHandle);

		/// <summary>The <c>setipv4sourcefilter</c> inline function sets the multicast filter state for an IPv4 socket.</summary>
		/// <param name="Socket">A descriptor that identifies a multicast socket.</param>
		/// <param name="Interface">
		/// <para>The local IPv4 address of the interface or the interface index on which the multicast group should be joined or dropped.</para>
		/// <para>
		/// This value is in network byte order. If this member specifies an IPv4 address of 0.0.0.0, the default IPv4 multicast interface
		/// is used.
		/// </para>
		/// <para>
		/// Any IP address in the 0.x.x.x block (first octet of 0) except IPv4 address 0.0.0.0 is treated as an interface index. An
		/// interface index is a 24-bit number, and the 0.0.0.0/8 IPv4 address block is not used (this range is reserved).
		/// </para>
		/// <para>To use an interface index of 1 would be the same as an IP address of 0.0.0.1.</para>
		/// </param>
		/// <param name="Group">The IPv4 address of the multicast group.</param>
		/// <param name="FilterMode">The multicast filter mode for multicast group address.</param>
		/// <param name="SourceCount">The number of source addresses in the buffer pointed to by the SourceList parameter.</param>
		/// <param name="SourceList">A pointer to a buffer with the IP addresses to associate with the multicast filter.</param>
		/// <returns>
		/// <para>
		/// On success, <c>setipv4sourcefilter</c> returns NO_ERROR (0). Any nonzero return value indicates failure and a specific error
		/// code can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>setipv4sourcefilter</c> inline function is used to set the multicast filter state for an IPv4 socket.</para>
		/// <para>
		/// This function is part of socket interface extensions for multicast source filters defined in RFC 3678. An app can use these
		/// functions to retrieve and set the multicast source address filters associated with a socket.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-setipv4sourcefilter int setipv4sourcefilter( SOCKET
		// Socket, IN_ADDR Interface, IN_ADDR Group, MULTICAST_MODE_TYPE FilterMode, ULONG SourceCount, const IN_ADDR *SourceList );
		[PInvokeData("ws2tcpip.h", MSDNShortId = "C296D050-9195-42B5-8EBE-C6004F2DA855")]
		public static SocketError setipv4sourcefilter(SOCKET Socket, IN_ADDR Interface, IN_ADDR Group, MULTICAST_MODE_TYPE FilterMode, uint SourceCount, IN_ADDR[] SourceList)
		{
			if (SourceCount > SourceList.Length)
			{
				WSASetLastError(System.Net.Sockets.SocketError.NoBufferSpaceAvailable);
				return System.Net.Sockets.SocketError.SocketError;
			}

			var Filter = new IP_MSFILTER
			{
				imsf_multiaddr = Group,
				imsf_interface = Interface,
				imsf_fmode = FilterMode,
				imsf_numsrc = SourceCount,
				imsf_slist = SourceList
			};
			using var pFilter = SafeHGlobalHandle.CreateFromStructure(Filter);
			return WSAIoctl(Socket, SIOCSIPMSFILTER, pFilter, pFilter.Size, default, 0, out _);
		}

		/// <summary>The <c>setsourcefilter</c> inline function sets the multicast filter state for an IPv4 or IPv6 socket.</summary>
		/// <param name="Socket">A descriptor that identifies a multicast socket.</param>
		/// <param name="Interface">The interface index of the multicast interface.</param>
		/// <param name="Group">A pointer to the socket address of the multicast group.</param>
		/// <param name="GroupLength">The length, in bytes, of the socket address pointed to by the Group parameter.</param>
		/// <param name="FilterMode">The multicast filter mode for the multicast group address.</param>
		/// <param name="SourceCount">The number of source addresses in the buffer pointed to by the SourceList parameter.</param>
		/// <param name="SourceList">A pointer to a buffer with the IP addresses to associate with the multicast filter.</param>
		/// <returns>
		/// <para>
		/// On success, <c>setsourcefilter</c> returns NO_ERROR (0). Any nonzero return value indicates failure and a specific error code
		/// can be retrieved by calling WSAGetLastError.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Error code</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WSAENOBUFS</term>
		/// <term>Insufficient buffer space is available.</term>
		/// </item>
		/// <item>
		/// <term>WSAENOTSOCK</term>
		/// <term>The descriptor is not a socket.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>setsourcefilter</c> inline function is used to set the multicast filter state for an IPv4 or IPv6 socket.</para>
		/// <para>
		/// This function is part of socket interface extensions for multicast source filters defined in RFC 3678. An app can use these
		/// functions to retrieve and set the multicast source address filters associated with a socket.
		/// </para>
		/// <para><c>Windows Phone 8:</c> This function is supported for Windows Phone Store apps on Windows Phone 8 and later.</para>
		/// <para>
		/// <c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: This function is supported for Windows Store apps on Windows 8.1, Windows
		/// Server 2012 R2, and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ws2tcpip/nf-ws2tcpip-setsourcefilter int setsourcefilter( SOCKET Socket, ULONG
		// Interface, const SOCKADDR *Group, int GroupLength, MULTICAST_MODE_TYPE FilterMode, ULONG SourceCount, const SOCKADDR_STORAGE
		// *SourceList );
		[PInvokeData("ws2tcpip.h", MSDNShortId = "320455F3-FDFB-46C6-9F26-3C60064A2CB0")]
		public static SocketError setsourcefilter(SOCKET Socket, uint Interface, [In] SOCKADDR Group, int GroupLength, MULTICAST_MODE_TYPE FilterMode, uint SourceCount, SOCKADDR_STORAGE[] SourceList)
		{
			if (SourceCount > SourceList.Length || GroupLength > Group.Size)
			{
				WSASetLastError(System.Net.Sockets.SocketError.NoBufferSpaceAvailable);
				return System.Net.Sockets.SocketError.SocketError;
			}

			var Filter = new GROUP_FILTER
			{
				gf_interface = Interface,
				gf_fmode = FilterMode,
				gf_numsrc = SourceCount,
				gf_slist = SourceList
			};
			using var pFilter = SafeHGlobalHandle.CreateFromStructure(Filter);
			Group.DangerousGetHandle().CopyTo(pFilter.DangerousGetHandle().Offset(4), Group.Size);
			return WSAIoctl(Socket, SIOCSMSFILTER, pFilter, pFilter.Size, default, 0, out _);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for an array of <see cref="ADDRINFOW"/> that is disposed using <see cref="FreeAddrInfoW"/>.</summary>
		public class SafeADDRINFOWArray : SafeHANDLE, IEnumerable<ADDRINFOW>
		{
			/// <summary>Initializes a new instance of the <see cref="SafeADDRINFOWArray"/> class.</summary>
			private SafeADDRINFOWArray() : base() { }

			/// <summary>Gets the number of elements contained in the <see cref="SafeADDRINFOWArray"/>.</summary>
			public int Length => IsInvalid ? 0 : Items.Count();

			/// <summary>Enumerates the elements.</summary>
			/// <returns>An enumeration of values from the pointer.</returns>
			protected virtual IEnumerable<ADDRINFOW> Items => handle.LinkedListToIEnum<ADDRINFOW>(ai => ai.ai_next);

			/// <summary>Gets or sets the <see cref="ADDRINFOW"/> value at the specified index.</summary>
			/// <param name="index">The index of the info within the array.</param>
			/// <returns>The <see cref="ADDRINFOW"/> value.</returns>
			/// <exception cref="ArgumentOutOfRangeException">index or index</exception>
			public ADDRINFOW this[int index] => Items.ElementAt(index);

			/// <summary>Determines whether this instance contains the object.</summary>
			/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
			/// <returns>
			/// <see langword="true"/> if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>;
			/// otherwise, <see langword="false"/>.
			/// </returns>
			public bool Contains(ADDRINFOW item) => Items.Contains(item);

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<ADDRINFOW> GetEnumerator() => Items.GetEnumerator();

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { FreeAddrInfoW(handle); return true; }
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for an array of <see cref="ADDRINFOEXW"/> that is disposed using <see cref="FreeAddrInfoW"/>.</summary>
		public class SafeADDRINFOEXWArray : SafeHANDLE, IEnumerable<ADDRINFOEXW>
		{
			/// <summary>Initializes a new instance of the <see cref="SafeADDRINFOEXWArray"/> class.</summary>
			private SafeADDRINFOEXWArray() : base() { }

			/// <summary>Gets the number of elements contained in the <see cref="SafeADDRINFOEXWArray"/>.</summary>
			public int Length => IsInvalid ? 0 : Items.Count();

			/// <summary>Enumerates the elements.</summary>
			/// <returns>An enumeration of values from the pointer.</returns>
			protected virtual IEnumerable<ADDRINFOEXW> Items => handle.LinkedListToIEnum<ADDRINFOEXW>(ai => ai.ai_next);

			/// <summary>Gets or sets the <see cref="ADDRINFOEXW"/> value at the specified index.</summary>
			/// <param name="index">The index of the info within the array.</param>
			/// <returns>The <see cref="ADDRINFOEXW"/> value.</returns>
			/// <exception cref="ArgumentOutOfRangeException">index or index</exception>
			public ADDRINFOEXW this[int index] => Items.ElementAt(index);

			/// <summary>Determines whether this instance contains the object.</summary>
			/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
			/// <returns>
			/// <see langword="true"/> if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>;
			/// otherwise, <see langword="false"/>.
			/// </returns>
			public bool Contains(ADDRINFOEXW item) => Items.Contains(item);

			/// <summary>Returns an enumerator that iterates through the collection.</summary>
			/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
			public IEnumerator<ADDRINFOEXW> GetEnumerator() => Items.GetEnumerator();

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { FreeAddrInfoExW(handle); return true; }
		}
	}
}

#pragma warning restore IDE1006 // Naming Styles