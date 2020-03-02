using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
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
		/// Engineering Task Force (IETF) as the default port used by web servers for the HTTP protocol. Possible values for the pServiceName
		/// parameter when a port number is not specified are listed in the following file:
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
		/// <c>gai_strerror</c> function is provided for compliance with IETF recommendations, but it is not thread safe. Therefore, use of a
		/// traditional Windows Sockets function, such as WSAGetLastError, is recommended.
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
		/// The support for the specified socket type does not exist in this address family. This error is returned if the ai_socktype member
		/// of the addrinfoWstructure pointed to by the hints parameter is not supported.
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
		/// The <c>GetAddrInfoW</c> function returns results for the <c>NS_DNS</c> namespace. The <c>GetAddrInfoW</c> function aggregates all
		/// responses if more than one namespace provider returns information. For use with the IPv6 and IPv4 protocol, name resolution can
		/// be by the Domain Name System (DNS), a local hosts file, or by other naming mechanisms for the <c>NS_DNS</c> namespace.
		/// </para>
		/// <para>
		/// Macros in the Winsock header file define a mixed-case function name of <c>GetAddrInfo</c> and a <c>ADDRINFOT</c> structure. This
		/// <c>GetAddrInfo</c> function should be called with the pNodeName and pServiceName parameters of a pointer of type <c>TCHAR</c> and
		/// the pHints and ppResult parameters of a pointer of type <c>ADDRINFOT</c>. When UNICODE or _UNICODE is defined, <c>GetAddrInfo</c>
		/// is defined to <c>GetAddrInfoW</c>, the Unicode version of the function, and <c>ADDRINFOT</c> is defined to the addrinfoW
		/// structure. When UNICODE or _UNICODE is not defined, <c>GetAddrInfo</c> is defined to getaddrinfo, the ANSI version of the
		/// function, and <c>ADDRINFOT</c> is defined to the addrinfo structure.
		/// </para>
		/// <para>
		/// One or both of the pNodeName or pServiceName parameters must point to a <c>NULL</c>-terminated Unicode string; generally both are provided.
		/// </para>
		/// <para>
		/// Upon success, a linked list of addrinfoW structures is returned in the ppResult parameter. The list can be processed by following
		/// the pointer provided in the <c>ai_next</c> member of each returned <c>addrinfoW</c> structure until a <c>NULL</c> pointer is
		/// encountered. In each returned <c>addrinfoW</c> structure, the <c>ai_family</c>, <c>ai_socktype</c>, and <c>ai_protocol</c>
		/// members correspond to respective arguments in a socket or WSASocket function call. Also, the <c>ai_addr</c> member in each
		/// returned <c>addrinfoW</c> structure points to a filled-in socket address structure, the length of which is specified in its
		/// <c>ai_addrlen</c> member.
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
		/// Windows 7 with Service Pack 1 (SP1) and Windows Server 2008 R2 with Service Pack 1 (SP1) add support to Netsh.exe for setting the
		/// SkipAsSource attribute on an IP address. This also changes the behavior such that if the <c>SkipAsSource</c> member in the
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
		/// that contains a sockaddr structure for the IP address and other information. To be used in this way, the string pointed to by the
		/// pNodeName parameter must contain a text representation of an IP address and the <c>addrinfoW</c> structure pointed to by the
		/// pHints parameter must have the <c>AI_NUMERICHOST</c> flag set in the <c>ai_flags</c> member. The string pointed to by the
		/// pNodeName parameter may contain a text representation of either an IPv4 or an IPv6 address. The text IP address is converted to
		/// an <c>addrinfoW</c> structure pointed to by the ppResult parameter. The returned <c>addrinfoW</c> structure contains a
		/// <c>sockaddr</c> structure for the IP address along with additional information about the IP address. For this method to work with
		/// an IPv6 address string on Windows Server 2003 and Windows XP, the IPv6 protocol must be installed on the local computer.
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
		/// Names in Applications (IDNA) is used to handle IDNs in a standard fashion. The specifications for IDNs and IDNA are documented in
		/// RFC 3490, RTF 5890, and RFC 6365 published by the Internet Engineering Task Force (IETF).
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
		/// function, you can use the MultiByteToWideChar function to convert the <c>CHAR</c> string into a <c>WCHAR</c> string that then can
		/// be passed in the pNodeName parameter to the <c>GetAddrInfoW</c> function.
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
		/// function. When the AI_PASSIVE flag is set and pNodeName is a NULL pointer, the IP address portion of the socket address structure
		/// is set to INADDR_ANY for IPv4 addresses and IN6ADDR_ANY_INIT for IPv6 addresses. When the AI_PASSIVE flag is not set, the
		/// returned socket address structure is ready for a call to the connect function for a connection-oriented protocol, or ready for a
		/// call to either the connect, sendto, or send functions for a connectionless protocol. If the pNodeName parameter is a NULL pointer
		/// in this case, the IP address portion of the socket address structure is set to the loopback address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_CANONNAME</term>
		/// <term>
		/// If neither AI_CANONNAME nor AI_NUMERICHOST is used, the GetAddrInfoW function attempts resolution. If a literal string is passed
		/// GetAddrInfoW attempts to convert the string, and if a host name is passed the GetAddrInfoW function attempts to resolve the name
		/// to an address or multiple addresses. When the AI_CANONNAME bit is set, the pNodeName parameter cannot be NULL. Otherwise the
		/// GetAddrInfoEx function will fail with WSANO_RECOVERY. When the AI_CANONNAME bit is set and the GetAddrInfoW function returns
		/// success, the ai_canonname member in the ppResult parameter points to a NULL-terminated string that contains the canonical name of
		/// the specified node.
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
		/// If the AI_ALL bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. The AI_ALL flag is defined on
		/// the Windows SDK for Windows Vista and later. The AI_ALL flag is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_ADDRCONFIG</term>
		/// <term>
		/// If the AI_ADDRCONFIG bit is set, GetAddrInfoW will resolve only if a global address is configured. If AI_ADDRCONFIG flag is
		/// specified, IPv4 addresses shall be returned only if an IPv4 address is configured on the local system, and IPv6 addresses shall
		/// be returned only if an IPv6 address is configured on the local system. The IPv4 or IPv6 loopback address is not considered a
		/// valid global address. The AI_ADDRCONFIG flag is defined on the Windows SDK for Windows Vista and later. The AI_ADDRCONFIG flag is
		/// supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_V4MAPPED</term>
		/// <term>
		/// If the AI_V4MAPPED bit is set and a request for IPv6 addresses fails, a name service request is made for IPv4 addresses and these
		/// addresses are converted to IPv4-mapped IPv6 address format. The AI_V4MAPPED flag is defined on the Windows SDK for Windows Vista
		/// and later. The AI_V4MAPPED flag is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>AI_NON_AUTHORITATIVE</term>
		/// <term>
		/// If the AI_NON_AUTHORITATIVE bit is set, the NS_EMAIL namespace provider returns both authoritative and non-authoritative results.
		/// If the AI_NON_AUTHORITATIVE bit is not set, the NS_EMAIL namespace provider returns only authoritative results. The
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
		/// If the AI_FILESERVER is set, this is a hint to the namespace provider that the hostname being queried is being used in file share
		/// scenario. The namespace provider may ignore this hint. Windows 7: The AI_FILESERVER flag is defined on the Windows SDK for
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
		public static extern int GetAddrInfoW([Optional] string pNodeName, [Optional] string pServiceName, in ADDRINFOW pHints, out SafeADDRINFOWArray ppResult);

		/// <summary>
		/// The <c>InetNtop</c> function converts an IPv4 or IPv6 Internet network address into a string in Internet standard format. The ANSI version of this function is <c>inet_ntop</c>.
		/// </summary>
		/// <param name="Family"><para>The address family.</para><para>Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.</para><para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term> AF_INET 2 </term><term>The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns an IPv4 address string.</term></item><item><term> AF_INET6 23 </term><term>The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns an IPv6 address string.</term></item></list></param>
		/// <param name="pAddr"><para>A pointer to the IP address in network byte to convert to a string.</para><para>When the Family parameter is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address to convert.</para><para>When the Family parameter is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address to convert.</para></param>
		/// <param name="pStringBuf"><para>A pointer to a buffer in which to store the <c>NULL</c>-terminated string representation of the IP address.</para><para>For an IPv4 address, this buffer should be large enough to hold at least 16 characters.</para><para>For an IPv6 address, this buffer should be large enough to hold at least 46 characters.</para></param>
		/// <param name="StringBufSize">On input, the length, in characters, of the buffer pointed to by the pStringBuf parameter.</param>
		/// <returns>
		///   <para>If no error occurs, <c>InetNtop</c> function returns a pointer to a buffer containing the string representation of IP address in standard format.</para><para>Otherwise, a value of <c>NULL</c> is returned, and a specific error code can be retrieved by calling the WSAGetLastError for extended error information.</para><para>If the function fails, the extended error code returned by WSAGetLastError can be one of the following values.</para><list type="table"><listheader><term>Error code</term><term>Meaning</term></listheader><item><term> WSAEAFNOSUPPORT </term><term> The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified was not AF_INET or AF_INET6. </term></item><item><term> ERROR_INVALID_PARAMETER </term><term> An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pStringBuf or the StringBufSize parameter is zero. This error is also returned if the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of the IP address. </term></item></list>
		/// </returns>
		/// <remarks>
		///   <para>The <c>InetNtop</c> function is supported on Windows Vistaand later.</para><para>The <c>InetNtop</c> function provides a protocol-independent address-to-string translation. The <c>InetNtop</c> function takes an Internet address structure specified by the pAddr parameter and returns a <c>NULL</c>-terminated string that represents the IP address. While the inet_ntoa function works only with IPv4 addresses, the <c>InetNtop</c> function works with either IPv4 or IPv6 addresses.</para><para>The ANSI version of this function is <c>inet_ntop</c> as defined in RFC 2553. For more information, see RFC 2553 available at the IETF website.</para><para>The <c>InetNtop</c> function does not require that the Windows Sockets DLL be loaded to perform IP address to string conversion.</para><para>If the Family parameter specified is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.</para><para>If the Family parameter specified is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero numbers is replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address. The last 32 bits are represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.</para><para>If the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of the IP address, <c>InetNtop</c> returns ERROR_INVALID_PARAMETER.</para><para>When UNICODE or _UNICODE is defined, <c>InetNtop</c> is defined to <c>InetNtopW</c>, the Unicode version of this function. The pStringBuf parameter is defined to the <c>PSTR</c> data type.</para><para>When UNICODE or _UNICODE is not defined, <c>InetNtop</c> is defined to <c>InetNtopA</c>, the ANSI version of this function. The ANSI version of this function is always defined as <c>inet_ntop</c>. The pStringBuf parameter is defined to the <c>PWSTR</c> data type.</para><para>The IN_ADDR structure is defined in the Inaddr.h header file.</para><para>The IN6_ADDR structure is defined in the In6addr.h header file.</para><para>On Windows Vista and later, the RtlIpv4AddressToString and RtlIpv4AddressToStringEx functions can be used to convert an IPv4 address represented as an IN_ADDR structure to a string representation of an IPv4 address in Internet standard dotted-decimal notation. On Windows Vista and later, the RtlIpv6AddressToString and RtlIpv6AddressToStringEx functions can be used to convert an IPv6 address represented as an IN6_ADDR structure to a string representation of an IPv6 address. The <c>RtlIpv6AddressToStringEx</c> function is more flexible since it also converts an IPv6 address, scope ID, and port to a IPv6 string in standard format.</para><para><c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetNtopW</c> function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_ntop
		// PCSTR WSAAPI inet_ntop( INT Family, const VOID *pAddr, PSTR pStringBuf, size_t StringBufSize );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "1e26b88c-808f-4807-8641-e5c6b10853ad")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern string inet_ntop([MarshalAs(UnmanagedType.U4)] ADDRESS_FAMILY Family, in IN_ADDR pAddr, StringBuilder pStringBuf, SizeT StringBufSize);

		/// <summary>
		/// The <c>InetNtop</c> function converts an IPv4 or IPv6 Internet network address into a string in Internet standard format. The ANSI version of this function is <c>inet_ntop</c>.
		/// </summary>
		/// <param name="Family"><para>The address family.</para><para>Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.</para><para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term> AF_INET 2 </term><term>The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, this function returns an IPv4 address string.</term></item><item><term> AF_INET6 23 </term><term>The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, this function returns an IPv6 address string.</term></item></list></param>
		/// <param name="pAddr"><para>A pointer to the IP address in network byte to convert to a string.</para><para>When the Family parameter is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address to convert.</para><para>When the Family parameter is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address to convert.</para></param>
		/// <param name="pStringBuf"><para>A pointer to a buffer in which to store the <c>NULL</c>-terminated string representation of the IP address.</para><para>For an IPv4 address, this buffer should be large enough to hold at least 16 characters.</para><para>For an IPv6 address, this buffer should be large enough to hold at least 46 characters.</para></param>
		/// <param name="StringBufSize">On input, the length, in characters, of the buffer pointed to by the pStringBuf parameter.</param>
		/// <returns>
		///   <para>If no error occurs, <c>InetNtop</c> function returns a pointer to a buffer containing the string representation of IP address in standard format.</para><para>Otherwise, a value of <c>NULL</c> is returned, and a specific error code can be retrieved by calling the WSAGetLastError for extended error information.</para><para>If the function fails, the extended error code returned by WSAGetLastError can be one of the following values.</para><list type="table"><listheader><term>Error code</term><term>Meaning</term></listheader><item><term> WSAEAFNOSUPPORT </term><term> The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified was not AF_INET or AF_INET6. </term></item><item><term> ERROR_INVALID_PARAMETER </term><term> An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the pStringBuf or the StringBufSize parameter is zero. This error is also returned if the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of the IP address. </term></item></list>
		/// </returns>
		/// <remarks>
		///   <para>The <c>InetNtop</c> function is supported on Windows Vistaand later.</para><para>The <c>InetNtop</c> function provides a protocol-independent address-to-string translation. The <c>InetNtop</c> function takes an Internet address structure specified by the pAddr parameter and returns a <c>NULL</c>-terminated string that represents the IP address. While the inet_ntoa function works only with IPv4 addresses, the <c>InetNtop</c> function works with either IPv4 or IPv6 addresses.</para><para>The ANSI version of this function is <c>inet_ntop</c> as defined in RFC 2553. For more information, see RFC 2553 available at the IETF website.</para><para>The <c>InetNtop</c> function does not require that the Windows Sockets DLL be loaded to perform IP address to string conversion.</para><para>If the Family parameter specified is <c>AF_INET</c>, then the pAddr parameter must point to an IN_ADDR structure with the IPv4 address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.</para><para>If the Family parameter specified is <c>AF_INET6</c>, then the pAddr parameter must point to an IN6_ADDR structure with the IPv6 address to convert. The address string returned in the buffer pointed to by the pStringBuf parameter is in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero numbers is replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address. The last 32 bits are represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.</para><para>If the length of the buffer pointed to by the pStringBuf parameter is not large enough to receive the string representation of the IP address, <c>InetNtop</c> returns ERROR_INVALID_PARAMETER.</para><para>When UNICODE or _UNICODE is defined, <c>InetNtop</c> is defined to <c>InetNtopW</c>, the Unicode version of this function. The pStringBuf parameter is defined to the <c>PSTR</c> data type.</para><para>When UNICODE or _UNICODE is not defined, <c>InetNtop</c> is defined to <c>InetNtopA</c>, the ANSI version of this function. The ANSI version of this function is always defined as <c>inet_ntop</c>. The pStringBuf parameter is defined to the <c>PWSTR</c> data type.</para><para>The IN_ADDR structure is defined in the Inaddr.h header file.</para><para>The IN6_ADDR structure is defined in the In6addr.h header file.</para><para>On Windows Vista and later, the RtlIpv4AddressToString and RtlIpv4AddressToStringEx functions can be used to convert an IPv4 address represented as an IN_ADDR structure to a string representation of an IPv4 address in Internet standard dotted-decimal notation. On Windows Vista and later, the RtlIpv6AddressToString and RtlIpv6AddressToStringEx functions can be used to convert an IPv6 address represented as an IN6_ADDR structure to a string representation of an IPv6 address. The <c>RtlIpv6AddressToStringEx</c> function is more flexible since it also converts an IPv6 address, scope ID, and port to a IPv6 string in standard format.</para><para><c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetNtopW</c> function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_ntop
		// PCSTR WSAAPI inet_ntop( INT Family, const VOID *pAddr, PSTR pStringBuf, size_t StringBufSize );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "1e26b88c-808f-4807-8641-e5c6b10853ad")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern string inet_ntop([MarshalAs(UnmanagedType.U4)] ADDRESS_FAMILY Family, in IN6_ADDR pAddr, StringBuilder pStringBuf, SizeT StringBufSize);

		/// <summary>
		/// The <c>InetPton</c> function converts an IPv4 or IPv6 Internet network address in its standard text presentation form into its numeric binary form. The ANSI version of this function is <c>inet_pton</c>.
		/// </summary>
		/// <param name="Family"><para>The address family.</para><para>Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.</para><para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term> AF_INET 2 </term><term> The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the pszAddrString parameter must point to a text representation of an IPv4 address and the pAddrBuf parameter returns a pointer to an IN_ADDR structure that represents the IPv4 address. </term></item><item><term> AF_INET6 23 </term><term> The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the pszAddrString parameter must point to a text representation of an IPv6 address and the pAddrBuf parameter returns a pointer to an IN6_ADDR structure that represents the IPv6 address. </term></item></list></param>
		/// <param name="pszAddrString"><para>A pointer to the <c>NULL</c>-terminated string that contains the text representation of the IP address to convert to numeric binary form.</para><para>When the Family parameter is <c>AF_INET</c>, then the pszAddrString parameter must point to a text representation of an IPv4 address in standard dotted-decimal notation.</para><para>When the Family parameter is <c>AF_INET6</c>, then the pszAddrString parameter must point to a text representation of an IPv6 address in standard notation.</para></param>
		/// <param name="pAddrBuf"><para>A pointer to a buffer in which to store the numeric binary representation of the IP address. The IP address is returned in network byte order.</para><para>When the Family parameter is <c>AF_INET</c>, this buffer should be large enough to hold an IN_ADDR structure.</para><para>When the Family parameter is <c>AF_INET6</c>, this buffer should be large enough to hold an IN6_ADDR structure.</para></param>
		/// <returns>
		///   <para>If no error occurs, the <c>InetPton</c> function returns a value of 1 and the buffer pointed to by the pAddrBuf parameter contains the binary numeric IP address in network byte order.</para><para>The <c>InetPton</c> function returns a value of 0 if the pAddrBuf parameter points to a string that is not a valid IPv4 dotted-decimal string or a valid IPv6 address string. Otherwise, a value of -1 is returned, and a specific error code can be retrieved by calling the WSAGetLastError for extended error information.</para><para>If the function has an error, the extended error code returned by WSAGetLastError can be one of the following values.</para><list type="table"><listheader><term>Error code</term><term>Meaning</term></listheader><item><term> WSAEAFNOSUPPORT </term><term> The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified was not AF_INET or AF_INET6. </term></item><item><term> WSAEFAULT </term><term> The pszAddrString or pAddrBuf parameters are NULL or are not part of the user address space. </term></item></list>
		/// </returns>
		/// <remarks>
		///   <para>The <c>InetPton</c> function is supported on Windows Vistaand later.</para><para>The <c>InetPton</c> function provides a protocol-independent conversion of an Internet network address in its standard text presentation form into its numeric binary form. The <c>InetPton</c> function takes a text representation of an Internet address pointed to by the pszAddrString parameter and returns a pointer to the numeric binary IP address in the pAddrBuf parameter. While the inet_addrfunction works only with IPv4 address strings, the <c>InetPton</c> function works with either IPv4 or IPv6 address strings.</para><para>The ANSI version of this function is <c>inet_pton</c> as defined in RFC 2553. For more information, see RFC 2553 available at the IETF website.</para><para>The <c>InetPton</c> function does not require that the Windows Sockets DLL be loaded to perform conversion of a text string that represents an IP address to a numeric binary IP address.</para><para>If the Family parameter specified is <c>AF_INET</c>, then the pszAddrString parameter must point a text string of an IPv4 address in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.</para><para>If the Family parameter specified is <c>AF_INET6</c>, then the pszAddrString parameter must point a text string of an IPv6 address in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero numbers may be replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address. The last 32 bits may be represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.</para><para>When UNICODE or _UNICODE is defined, <c>InetPton</c> is defined to <c>InetPtonW</c>, the Unicode version of this function. The pszAddrString parameter is defined to the <c>PCWSTR</c> data type.</para><para>When UNICODE or _UNICODE is not defined, <c>InetPton</c> is defined to <c>InetPtonA</c>, the ANSI version of this function. The ANSI version of this function is always defined as inet_pton. The pszAddrString parameter is defined to the <c>PCSTR</c> data type.</para><para>The IN_ADDR structure is defined in the Inaddr.h header file.</para><para>The IN6_ADDR structure is defined in the In6addr.h header file.</para><para>On Windows Vista and later, the RtlIpv4StringToAddress and RtlIpv4StringToAddressEx functions can be used to convert a text representation of an IPv4 address in Internet standard dotted-decimal notation to a numeric binary address represented as an IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress and RtlIpv6StringToAddressEx functions can be used to convert a string representation of an IPv6 address to a numeric binary IPv6 address represented as an IN6_ADDR structure. The <c>RtlIpv6StringToAddressEx</c> function is more flexible since it also converts a string representation of an IPv6 address that can include a scope ID and port in standard notation to a numeric binary form.</para><para><c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetPtonW</c> function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_pton
		// INT WSAAPI inet_pton( INT Family, PCSTR pszAddrString, PVOID pAddrBuf );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "d0705997-0dc7-443b-a43f-611301cc9169")]
		public static extern int inet_pton([MarshalAs(UnmanagedType.U4)] ADDRESS_FAMILY Family, string pszAddrString, out IN_ADDR pAddrBuf);

		/// <summary>
		/// The <c>InetPton</c> function converts an IPv4 or IPv6 Internet network address in its standard text presentation form into its numeric binary form. The ANSI version of this function is <c>inet_pton</c>.
		/// </summary>
		/// <param name="Family"><para>The address family.</para><para>Possible values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically included in Winsock2.h, and should never be used directly. Note that the values for the AF_ address family and PF_ protocol family constants are identical (for example, <c>AF_INET</c> and <c>PF_INET</c>), so either constant can be used.</para><para>The values currently supported are <c>AF_INET</c> and <c>AF_INET6</c>.</para><list type="table"><listheader><term>Value</term><term>Meaning</term></listheader><item><term> AF_INET 2 </term><term> The Internet Protocol version 4 (IPv4) address family. When this parameter is specified, the pszAddrString parameter must point to a text representation of an IPv4 address and the pAddrBuf parameter returns a pointer to an IN_ADDR structure that represents the IPv4 address. </term></item><item><term> AF_INET6 23 </term><term> The Internet Protocol version 6 (IPv6) address family. When this parameter is specified, the pszAddrString parameter must point to a text representation of an IPv6 address and the pAddrBuf parameter returns a pointer to an IN6_ADDR structure that represents the IPv6 address. </term></item></list></param>
		/// <param name="pszAddrString"><para>A pointer to the <c>NULL</c>-terminated string that contains the text representation of the IP address to convert to numeric binary form.</para><para>When the Family parameter is <c>AF_INET</c>, then the pszAddrString parameter must point to a text representation of an IPv4 address in standard dotted-decimal notation.</para><para>When the Family parameter is <c>AF_INET6</c>, then the pszAddrString parameter must point to a text representation of an IPv6 address in standard notation.</para></param>
		/// <param name="pAddrBuf"><para>A pointer to a buffer in which to store the numeric binary representation of the IP address. The IP address is returned in network byte order.</para><para>When the Family parameter is <c>AF_INET</c>, this buffer should be large enough to hold an IN_ADDR structure.</para><para>When the Family parameter is <c>AF_INET6</c>, this buffer should be large enough to hold an IN6_ADDR structure.</para></param>
		/// <returns>
		///   <para>If no error occurs, the <c>InetPton</c> function returns a value of 1 and the buffer pointed to by the pAddrBuf parameter contains the binary numeric IP address in network byte order.</para><para>The <c>InetPton</c> function returns a value of 0 if the pAddrBuf parameter points to a string that is not a valid IPv4 dotted-decimal string or a valid IPv6 address string. Otherwise, a value of -1 is returned, and a specific error code can be retrieved by calling the WSAGetLastError for extended error information.</para><para>If the function has an error, the extended error code returned by WSAGetLastError can be one of the following values.</para><list type="table"><listheader><term>Error code</term><term>Meaning</term></listheader><item><term> WSAEAFNOSUPPORT </term><term> The address family specified in the Family parameter is not supported. This error is returned if the Family parameter specified was not AF_INET or AF_INET6. </term></item><item><term> WSAEFAULT </term><term> The pszAddrString or pAddrBuf parameters are NULL or are not part of the user address space. </term></item></list>
		/// </returns>
		/// <remarks>
		///   <para>The <c>InetPton</c> function is supported on Windows Vistaand later.</para><para>The <c>InetPton</c> function provides a protocol-independent conversion of an Internet network address in its standard text presentation form into its numeric binary form. The <c>InetPton</c> function takes a text representation of an Internet address pointed to by the pszAddrString parameter and returns a pointer to the numeric binary IP address in the pAddrBuf parameter. While the inet_addrfunction works only with IPv4 address strings, the <c>InetPton</c> function works with either IPv4 or IPv6 address strings.</para><para>The ANSI version of this function is <c>inet_pton</c> as defined in RFC 2553. For more information, see RFC 2553 available at the IETF website.</para><para>The <c>InetPton</c> function does not require that the Windows Sockets DLL be loaded to perform conversion of a text string that represents an IP address to a numeric binary IP address.</para><para>If the Family parameter specified is <c>AF_INET</c>, then the pszAddrString parameter must point a text string of an IPv4 address in dotted-decimal notation as in "192.168.16.0", an example of an IPv4 address in dotted-decimal notation.</para><para>If the Family parameter specified is <c>AF_INET6</c>, then the pszAddrString parameter must point a text string of an IPv6 address in Internet standard format. The basic string representation consists of 8 hexadecimal numbers separated by colons. A string of consecutive zero numbers may be replaced with a double-colon. There can only be one double-colon in the string representation of the IPv6 address. The last 32 bits may be represented in IPv4-style dotted-octet notation if the address is a IPv4-compatible address.</para><para>When UNICODE or _UNICODE is defined, <c>InetPton</c> is defined to <c>InetPtonW</c>, the Unicode version of this function. The pszAddrString parameter is defined to the <c>PCWSTR</c> data type.</para><para>When UNICODE or _UNICODE is not defined, <c>InetPton</c> is defined to <c>InetPtonA</c>, the ANSI version of this function. The ANSI version of this function is always defined as inet_pton. The pszAddrString parameter is defined to the <c>PCSTR</c> data type.</para><para>The IN_ADDR structure is defined in the Inaddr.h header file.</para><para>The IN6_ADDR structure is defined in the In6addr.h header file.</para><para>On Windows Vista and later, the RtlIpv4StringToAddress and RtlIpv4StringToAddressEx functions can be used to convert a text representation of an IPv4 address in Internet standard dotted-decimal notation to a numeric binary address represented as an IN_ADDR structure. On Windows Vista and later, the RtlIpv6StringToAddress and RtlIpv6StringToAddressEx functions can be used to convert a string representation of an IPv6 address to a numeric binary IPv6 address represented as an IN6_ADDR structure. The <c>RtlIpv6StringToAddressEx</c> function is more flexible since it also converts a string representation of an IPv6 address that can include a scope ID and port in standard notation to a numeric binary form.</para><para><c>Windows 8.1</c> and <c>Windows Server 2012 R2</c>: The <c>InetPtonW</c> function is supported for Windows Store apps on Windows 8.1, Windows Server 2012 R2, and later.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2tcpip/nf-ws2tcpip-inet_pton
		// INT WSAAPI inet_pton( INT Family, PCSTR pszAddrString, PVOID pAddrBuf );
		[DllImport(Lib.Ws2_32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("ws2tcpip.h", MSDNShortId = "d0705997-0dc7-443b-a43f-611301cc9169")]
		public static extern int inet_pton([MarshalAs(UnmanagedType.U4)] ADDRESS_FAMILY Family, string pszAddrString, out IN6_ADDR pAddrBuf);

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
	}
}