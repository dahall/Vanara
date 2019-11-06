using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>The routine that is called when the calling thread is in an alertable thread and an ICMPv6 reply arrives.</summary>
		/// <param name="ApcContext">
		/// The ApcContext parameter passed to the Icmp6SendEcho2 function. This parameter can be used by the application to identify the
		/// Icmp6SendEcho2 request that the callback function is responding to.
		/// </param>
		/// <param name="IoStatusBlock">
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct.
		/// </param>
		/// <param name="Reserved">This parameter is reserved.</param>
		[PInvokeData("wdm.h", MSDNShortId = "1ce2b1d0-a8b2-4a05-8895-e13802690a7b")]
		public delegate void PIO_APC_ROUTINE(IntPtr ApcContext, ref IO_STATUS_BLOCK IoStatusBlock, uint Reserved);

		/// <summary>The <c>Icmp6CreateFile</c> function opens a handle on which IPv6 ICMP echo requests can be issued.</summary>
		/// <returns>
		/// The <c>Icmp6CreateFile</c> function returns an open handle on success. On failure, the function returns
		/// <c>INVALID_HANDLE_VALUE</c>. Call the GetLastError function for extended error information.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>Icmp6CreateFile</c> function opens a handle on which IPv6 ICMP echo requests can be issued. The Icmp6SendEcho2 function is
		/// used to send the IPv6 ICMP echo requests. The Icmp6ParseReplies function is used to parse the IPv6 ICMP replies. The
		/// IcmpCloseHandle function is used to close the ICMP handle opened by the <c>Icmp6CreateFile</c> function.
		/// </para>
		/// <para>For IPv4, use the IcmpCreateFile function.</para>
		/// <para>For IPv4, use the IcmpCreateFile, <c>IcmpSendEcho</c>, IcmpSendEcho2, IcmpSendEcho2Ex, and IcmpParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>The following example opens a handle on which IPv6 ICMP echo requests can be issued.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmp6createfile HANDLE Icmp6CreateFile( );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "2ddb23d8-a4e6-47c4-a552-2815ccaf055f")]
		public static extern SafeIcmpHandle Icmp6CreateFile();

		/// <summary>
		/// The <c>Icmp6ParseReplies</c> function parses the reply buffer provided and returns an IPv6 ICMPv6 echo response reply if found.
		/// </summary>
		/// <param name="ReplyBuffer">
		/// A pointer to the buffer passed to the Icmp6SendEcho2 function. This parameter is points to an ICMPV6_ECHO_REPLY structure to hold
		/// the response.
		/// </param>
		/// <param name="ReplySize">The size, in bytes, of the buffer pointed to by the ReplyBuffer parameter.</param>
		/// <returns>
		/// <para>
		/// The <c>Icmp6ParseReplies</c> function returns 1 on success. In this case, the <c>Status</c> member in the ICMPV6_ECHO_REPLY
		/// structure pointed to by the ReplyBuffer parameter will be either <c>IP_SUCCESS</c> if the target node responded or <c>IP_TTL_EXPIRED_TRANSIT</c>.
		/// </para>
		/// <para>If the return value is zero, extended error information is available through GetLastError.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_GEN_FAILURE</term>
		/// <term>
		/// A general failure occurred. This error is returned if the ReplyBuffer parameter is a NULL pointer or the ReplySize parameter is zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>Icmp6ParseReplies</c> function is used by IPv6 to parse replies that result from an ICMPv6 echo request. The
		/// <c>Icmp6ParseReplies</c> function parses a reply buffer previously passed to the Icmp6SendEcho2 function. Use the
		/// <c>Icmp6ParseReplies</c> function only with the <c>Icmp6SendEcho2</c> function.
		/// </para>
		/// <para>
		/// The <c>Icmp6ParseReplies</c> function cannot be used on a reply buffer previously passed to IcmpSendEcho or IcmpSendEcho2 for IPv4.
		/// </para>
		/// <para>For IPv4, use the IcmpCreateFile, <c>IcmpSendEcho</c>, IcmpSendEcho2, IcmpSendEcho2Ex, and IcmpParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmp6parsereplies DWORD Icmp6ParseReplies( LPVOID
		// ReplyBuffer, DWORD ReplySize );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "b4d63ffd-37ad-4901-b017-205fb15381e7")]
		public static extern Win32Error Icmp6ParseReplies(IntPtr ReplyBuffer, uint ReplySize);

		/// <summary>
		/// The <c>Icmp6SendEcho2</c> function sends an IPv6 ICMPv6 echo request and returns either immediately (if Event or ApcRoutine is
		/// non- <c>NULL</c>) or returns after the specified time-out. The ReplyBuffer contains the IPv6 ICMPv6 echo response, if any.
		/// </summary>
		/// <param name="IcmpHandle">The open handle returned by Icmp6CreateFile.</param>
		/// <param name="Event">
		/// <para>
		/// An event to be signaled whenever an ICMPv6 response arrives. If this parameter is specified, it requires a handle to a valid
		/// event object. Use the CreateEvent or CreateEventEx function to create this event object.
		/// </para>
		/// <para>For more information on using events, see Event Objects.</para>
		/// </param>
		/// <param name="ApcRoutine">
		/// <para>
		/// The routine that is called when the calling thread is in an alertable thread and an ICMPv6 reply arrives. On Windows Vista and
		/// later, <c>PIO_APC_ROUTINE_DEFINED</c> must be defined to force the datatype for this parameter to <c>PIO_APC_ROUTINE</c> rather
		/// than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, <c>PIO_APC_ROUTINE_DEFINED</c> must not be defined to force the datatype for this
		/// parameter to <c>FARPROC</c>.
		/// </para>
		/// </param>
		/// <param name="ApcContext">
		/// An optional parameter passed to the callback routine specified in the ApcRoutine parameter whenever an ICMPv6 response arrives or
		/// an error occurs.
		/// </param>
		/// <param name="SourceAddress">The IPv6 source address on which to issue the echo request, in the form of a sockaddr structure.</param>
		/// <param name="DestinationAddress">The IPv6 destination address of the echo request, in the form of a sockaddr structure.</param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IPv6 header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform,
		/// this parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be NULL if no IP header options need to be specified.</para>
		/// <para>
		/// <c>Note</c> On Windows Server 2003 and Windows XP, the RequestOptions parameter is not optional and must not be NULL and only the
		/// <c>Ttl</c> and <c>Flags</c> members are used.
		/// </para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// A pointer to a buffer to hold replies to the request. Upon return, the buffer contains an ICMPV6_ECHO_REPLY structure followed by
		/// the message body from the ICMPv6 echo response reply data. The buffer must be large enough to hold at least one
		/// <c>ICMPV6_ECHO_REPLY</c> structure plus the number of bytes of data specified in the RequestSize parameter. This buffer should
		/// also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </param>
		/// <param name="ReplySize">
		/// The size, in bytes, of the reply buffer pointed to by the ReplyBuffer parameter. This buffer should be large enough to hold at
		/// least one ICMPV6_ECHO_REPLY structure plus RequestSize bytes of data. This buffer should also be large enough to also hold 8 more
		/// bytes of data (the size of an ICMP error message) plus space for an <c>IO_STATUS_BLOCK</c> structure.
		/// </param>
		/// <param name="Timeout">
		/// The time, in milliseconds, to wait for replies. This parameter is only used if the <c>Icmp6SendEcho2</c> function is called
		/// synchronously. So this parameter is not used if either the ApcRoutine or Eventparameter are not <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// When called synchronously, the <c>Icmp6SendEcho2</c> function returns the number of replies received and stored in ReplyBuffer.
		/// If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// When called asynchronously, the <c>Icmp6SendEcho2</c> function returns ERROR_IO_PENDING to indicate the operation is in progress.
		/// The results can be retrieved later when the event specified in the Event parameter signals or the callback function in the
		/// ApcRoutine parameter is called.
		/// </para>
		/// <para>If the return value is zero, call GetLastError for extended error information.</para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>This function is not supported on this system.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The data area passed to a system call is too small. This error is returned if the ReplySize parameter indicates that the buffer
		/// pointed to by the ReplyBuffer parameter is too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters is invalid. This error is returned if the IcmpHandle parameter contains an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>
		/// The operation is in progress. This value is returned by a successful asynchronous call to Icmp6SendEcho2 and is not an indication
		/// of an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv6 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>Icmp6SendEcho2</c> function is called synchronously if the ApcRoutine or Event parameters are <c>NULL</c>. When called
		/// synchronously, the return value contains the number of replies received and stored in ReplyBuffer after waiting for the time
		/// specified in the Timeout parameter. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The <c>Icmp6SendEcho2</c> function is called asynchronously when either the ApcRoutine or Event parameters are specified. When
		/// called asynchronously, the ReplyBuffer and ReplySize parameters are required to accept the response. ICMP response data is copied
		/// to the ReplyBuffer provided and the application is signaled (when the Event parameter is specified) or the callback function is
		/// called (when the ApcRoutine parameter is specified). The application must parse the data pointed to by ReplyBuffer parameter
		/// using the Icmp6ParseReplies function.
		/// </para>
		/// <para>
		/// If the Event parameter is specified, the <c>Icmp6SendEcho2</c> function is called asynchronously. The event specified in the
		/// Event parameter is signaled whenever an ICMPv6 response arrives. Use the CreateEvent function to create this event object.
		/// </para>
		/// <para>
		/// If the ApcRoutine parameter is specified, the <c>Icmp6SendEcho2</c> function is called asynchronously. The ApcRoutine parameter
		/// should point to a user-defined callback function. The callback function specified in the ApcRoutine parameter is called whenever
		/// an ICMPv6 response arrives. The invocation of the callback function specified in the ApcRoutine parameter is serialized.
		/// </para>
		/// <para>
		/// If both the Event and ApcRoutine parameters are specified, the event specified in the Event parameter is signaled whenever an
		/// ICMPv6 response arrives, but the callback function specified in the ApcRoutine parameter is ignored .
		/// </para>
		/// <para>
		/// On Windows Vista and later, any application that calls <c>Icmp6SendEcho2</c> function asynchronously using the ApcRoutine
		/// parameter must define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to <c>PIO_APC_ROUTINE</c>
		/// rather than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the callback function pointed to by the ApcRoutine must be defined as a function of type <c>VOID</c>
		/// with the following syntax:
		/// </para>
		/// <para>On Windows Vista and later, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the Icmp6SendEcho2 function. This parameter can be used by the application to identify the
		/// Icmp6SendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN PIO_STATUS_BLOCK IoStatusBlock</term>
		/// <term>
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct. The
		/// IO_STATUS_BLOCK structure is defined in the Wdm.h header file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN ULONG Reserved</term>
		/// <term>This parameter is reserved.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows Server 2003 and Windows XP, any application that calls the <c>Icmp6SendEcho2</c> function asynchronously using the
		/// ApcRoutine parameter must not define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to
		/// <c>FARPROC</c> rather than <c>PIO_APC_ROUTINE</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, the callback function pointed to by the ApcRoutine must be defined as a function of type
		/// <c>VOID</c> with the following syntax:
		/// </para>
		/// <para>On Windows Server 2003 and Windows XP, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the Icmp6SendEcho2 function. This parameter can be used by the application to identify the
		/// Icmp6SendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the ApcRoutine parameter must be implemented in the same process as the application calling
		/// the <c>Icmp6SendEcho2</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>Icmp6SendEcho2</c> function.
		/// </para>
		/// <para>For IPv4, use the IcmpCreateFile, <c>IcmpSendEcho</c>, IcmpSendEcho2, IcmpSendEcho2Ex, and IcmpParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmp6sendecho2 DWORD Icmp6SendEcho2( HANDLE IcmpHandle,
		// HANDLE Event, PIO_APC_ROUTINE ApcRoutine, PVOID ApcContext, sockaddr_in6 *SourceAddress, sockaddr_in6 *DestinationAddress, LPVOID
		// RequestData, WORD RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID ReplyBuffer, DWORD ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "622c769b-ede8-4bc2-ac54-98de47ae1fed")]
		public static extern Win32Error Icmp6SendEcho2(SafeIcmpHandle IcmpHandle, [Optional] HANDLE Event, [Optional] PIO_APC_ROUTINE ApcRoutine, [Optional] IntPtr ApcContext, in SOCKADDR_IN6 SourceAddress,
			in SOCKADDR_IN6 DestinationAddress, [In] IntPtr RequestData, ushort RequestSize, in IP_OPTION_INFORMATION RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// The <c>Icmp6SendEcho2</c> function sends an IPv6 ICMPv6 echo request and returns either immediately (if Event or ApcRoutine is
		/// non- <c>NULL</c>) or returns after the specified time-out. The ReplyBuffer contains the IPv6 ICMPv6 echo response, if any.
		/// </summary>
		/// <param name="IcmpHandle">The open handle returned by Icmp6CreateFile.</param>
		/// <param name="Event">
		/// <para>
		/// An event to be signaled whenever an ICMPv6 response arrives. If this parameter is specified, it requires a handle to a valid
		/// event object. Use the CreateEvent or CreateEventEx function to create this event object.
		/// </para>
		/// <para>For more information on using events, see Event Objects.</para>
		/// </param>
		/// <param name="ApcRoutine">
		/// <para>
		/// The routine that is called when the calling thread is in an alertable thread and an ICMPv6 reply arrives. On Windows Vista and
		/// later, <c>PIO_APC_ROUTINE_DEFINED</c> must be defined to force the datatype for this parameter to <c>PIO_APC_ROUTINE</c> rather
		/// than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, <c>PIO_APC_ROUTINE_DEFINED</c> must not be defined to force the datatype for this
		/// parameter to <c>FARPROC</c>.
		/// </para>
		/// </param>
		/// <param name="ApcContext">
		/// An optional parameter passed to the callback routine specified in the ApcRoutine parameter whenever an ICMPv6 response arrives or
		/// an error occurs.
		/// </param>
		/// <param name="SourceAddress">The IPv6 source address on which to issue the echo request, in the form of a sockaddr structure.</param>
		/// <param name="DestinationAddress">The IPv6 destination address of the echo request, in the form of a sockaddr structure.</param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IPv6 header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform,
		/// this parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be NULL if no IP header options need to be specified.</para>
		/// <para>
		/// <c>Note</c> On Windows Server 2003 and Windows XP, the RequestOptions parameter is not optional and must not be NULL and only the
		/// <c>Ttl</c> and <c>Flags</c> members are used.
		/// </para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// A pointer to a buffer to hold replies to the request. Upon return, the buffer contains an ICMPV6_ECHO_REPLY structure followed by
		/// the message body from the ICMPv6 echo response reply data. The buffer must be large enough to hold at least one
		/// <c>ICMPV6_ECHO_REPLY</c> structure plus the number of bytes of data specified in the RequestSize parameter. This buffer should
		/// also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </param>
		/// <param name="ReplySize">
		/// The size, in bytes, of the reply buffer pointed to by the ReplyBuffer parameter. This buffer should be large enough to hold at
		/// least one ICMPV6_ECHO_REPLY structure plus RequestSize bytes of data. This buffer should also be large enough to also hold 8 more
		/// bytes of data (the size of an ICMP error message) plus space for an <c>IO_STATUS_BLOCK</c> structure.
		/// </param>
		/// <param name="Timeout">
		/// The time, in milliseconds, to wait for replies. This parameter is only used if the <c>Icmp6SendEcho2</c> function is called
		/// synchronously. So this parameter is not used if either the ApcRoutine or Eventparameter are not <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// When called synchronously, the <c>Icmp6SendEcho2</c> function returns the number of replies received and stored in ReplyBuffer.
		/// If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// When called asynchronously, the <c>Icmp6SendEcho2</c> function returns ERROR_IO_PENDING to indicate the operation is in progress.
		/// The results can be retrieved later when the event specified in the Event parameter signals or the callback function in the
		/// ApcRoutine parameter is called.
		/// </para>
		/// <para>If the return value is zero, call GetLastError for extended error information.</para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
		/// <term>This function is not supported on this system.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The data area passed to a system call is too small. This error is returned if the ReplySize parameter indicates that the buffer
		/// pointed to by the ReplyBuffer parameter is too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the parameters is invalid. This error is returned if the IcmpHandle parameter contains an invalid handle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>
		/// The operation is in progress. This value is returned by a successful asynchronous call to Icmp6SendEcho2 and is not an indication
		/// of an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to process this command.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv6 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>Icmp6SendEcho2</c> function is called synchronously if the ApcRoutine or Event parameters are <c>NULL</c>. When called
		/// synchronously, the return value contains the number of replies received and stored in ReplyBuffer after waiting for the time
		/// specified in the Timeout parameter. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The <c>Icmp6SendEcho2</c> function is called asynchronously when either the ApcRoutine or Event parameters are specified. When
		/// called asynchronously, the ReplyBuffer and ReplySize parameters are required to accept the response. ICMP response data is copied
		/// to the ReplyBuffer provided and the application is signaled (when the Event parameter is specified) or the callback function is
		/// called (when the ApcRoutine parameter is specified). The application must parse the data pointed to by ReplyBuffer parameter
		/// using the Icmp6ParseReplies function.
		/// </para>
		/// <para>
		/// If the Event parameter is specified, the <c>Icmp6SendEcho2</c> function is called asynchronously. The event specified in the
		/// Event parameter is signaled whenever an ICMPv6 response arrives. Use the CreateEvent function to create this event object.
		/// </para>
		/// <para>
		/// If the ApcRoutine parameter is specified, the <c>Icmp6SendEcho2</c> function is called asynchronously. The ApcRoutine parameter
		/// should point to a user-defined callback function. The callback function specified in the ApcRoutine parameter is called whenever
		/// an ICMPv6 response arrives. The invocation of the callback function specified in the ApcRoutine parameter is serialized.
		/// </para>
		/// <para>
		/// If both the Event and ApcRoutine parameters are specified, the event specified in the Event parameter is signaled whenever an
		/// ICMPv6 response arrives, but the callback function specified in the ApcRoutine parameter is ignored .
		/// </para>
		/// <para>
		/// On Windows Vista and later, any application that calls <c>Icmp6SendEcho2</c> function asynchronously using the ApcRoutine
		/// parameter must define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to <c>PIO_APC_ROUTINE</c>
		/// rather than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the callback function pointed to by the ApcRoutine must be defined as a function of type <c>VOID</c>
		/// with the following syntax:
		/// </para>
		/// <para>On Windows Vista and later, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the Icmp6SendEcho2 function. This parameter can be used by the application to identify the
		/// Icmp6SendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN PIO_STATUS_BLOCK IoStatusBlock</term>
		/// <term>
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct. The
		/// IO_STATUS_BLOCK structure is defined in the Wdm.h header file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN ULONG Reserved</term>
		/// <term>This parameter is reserved.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows Server 2003 and Windows XP, any application that calls the <c>Icmp6SendEcho2</c> function asynchronously using the
		/// ApcRoutine parameter must not define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to
		/// <c>FARPROC</c> rather than <c>PIO_APC_ROUTINE</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, the callback function pointed to by the ApcRoutine must be defined as a function of type
		/// <c>VOID</c> with the following syntax:
		/// </para>
		/// <para>On Windows Server 2003 and Windows XP, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the Icmp6SendEcho2 function. This parameter can be used by the application to identify the
		/// Icmp6SendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the ApcRoutine parameter must be implemented in the same process as the application calling
		/// the <c>Icmp6SendEcho2</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>Icmp6SendEcho2</c> function.
		/// </para>
		/// <para>For IPv4, use the IcmpCreateFile, <c>IcmpSendEcho</c>, IcmpSendEcho2, IcmpSendEcho2Ex, and IcmpParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmp6sendecho2 DWORD Icmp6SendEcho2( HANDLE IcmpHandle,
		// HANDLE Event, PIO_APC_ROUTINE ApcRoutine, PVOID ApcContext, sockaddr_in6 *SourceAddress, sockaddr_in6 *DestinationAddress, LPVOID
		// RequestData, WORD RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID ReplyBuffer, DWORD ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "622c769b-ede8-4bc2-ac54-98de47ae1fed")]
		public static extern Win32Error Icmp6SendEcho2(SafeIcmpHandle IcmpHandle, [Optional] HANDLE Event, [Optional] PIO_APC_ROUTINE ApcRoutine, [Optional] IntPtr ApcContext, in SOCKADDR_IN6 SourceAddress,
			in SOCKADDR_IN6 DestinationAddress, [In] IntPtr RequestData, ushort RequestSize, [Optional] IntPtr RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>The <c>IcmpCloseHandle</c> function closes a handle opened by a call to the IcmpCreateFile or Icmp6CreateFile functions.</summary>
		/// <param name="IcmpHandle">The handle to close. This handle must have been returned by a call to IcmpCreateFile or Icmp6CreateFile.</param>
		/// <returns>
		/// If the handle is closed successfully the return value is <c>TRUE</c>, otherwise <c>FALSE</c>. Call the GetLastError function for
		/// extended error information.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpCloseHandle</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpCloseHandle</c> function is
		/// exported from the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function.
		/// Applications requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows
		/// versions should not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for
		/// the presence of <c>IcmpCloseHandle</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the
		/// application should check for the presence of <c>IcmpCloseHandle</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>The following example opens and closes a handle on which ICMP echo requests can be issued.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpclosehandle IPHLPAPI_DLL_LINKAGE BOOL IcmpCloseHandle(
		// HANDLE IcmpHandle );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "ce8f11bb-1e33-41bd-adb9-c18efadd4d0b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IcmpCloseHandle(IntPtr IcmpHandle);

		/// <summary>The <c>IcmpCreateFile</c> function opens a handle on which IPv4 ICMP echo requests can be issued.</summary>
		/// <returns>
		/// The <c>IcmpCreateFile</c> function returns an open handle on success. On failure, the function returns
		/// <c>INVALID_HANDLE_VALUE</c>. Call the GetLastError function for extended error information.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpCreateFile</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpCreateFile</c> function is exported
		/// from the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function. Applications
		/// requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows versions should
		/// not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for the presence of
		/// <c>IcmpCreateFile</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the application should
		/// check for the presence of <c>IcmpCreateFile</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>The following example opens a handle on which ICMP echo requests can be issued.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpcreatefile IPHLPAPI_DLL_LINKAGE HANDLE IcmpCreateFile( );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "b435b38b-df86-4991-9772-c712c9ea606f")]
		public static extern SafeIcmpHandle IcmpCreateFile();

		/// <summary>
		/// The <c>IcmpParseReplies</c> function parses the reply buffer provided and returns the number of ICMP echo request responses found.
		/// </summary>
		/// <param name="ReplyBuffer">
		/// <para>The buffer passed to IcmpSendEcho2. This is rewritten to hold an array of ICMP_ECHO_REPLY structures, its type is <c>PICMP_ECHO_REPLY</c>.</para>
		/// <para>On a 64-bit plaform, this buffer is rewritten to hold an array of ICMP_ECHO_REPLY32 structures, its type is <c>PICMP_ECHO_REPLY32</c>.</para>
		/// </param>
		/// <param name="ReplySize">The size, in bytes, of the buffer pointed to by the ReplyBuffer parameter.</param>
		/// <returns>
		/// The <c>IcmpParseReplies</c> function returns the number of ICMP responses found on success. The function returns zero on error.
		/// Call GetLastError for additional error information.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpParseReplies</c> function should not be used on a reply buffer previously passed to IcmpSendEcho. The
		/// <c>IcmpSendEcho</c> function parses that buffer before returning to the user. Use this function only with IcmpSendEcho2.
		/// </para>
		/// <para>
		/// The <c>IcmpParseReplies</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpParseReplies</c> function is
		/// exported from the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function.
		/// Applications requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows
		/// versions should not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for
		/// the presence of <c>IcmpParseReplies</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the
		/// application should check for the presence of <c>IcmpParseReplies</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpparsereplies IPHLPAPI_DLL_LINKAGE DWORD
		// IcmpParseReplies( LPVOID ReplyBuffer, DWORD ReplySize );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "ec7c2a5f-5406-4350-b795-6e72fe25f62d")]
		public static extern uint IcmpParseReplies(IntPtr ReplyBuffer, uint ReplySize);

		/// <summary>
		/// The <c>IcmpSendEcho</c> function sends an IPv4 ICMP echo request and returns any echo response replies. The call returns when the
		/// time-out has expired or the reply buffer is filled.
		/// </summary>
		/// <param name="IcmpHandle">The open handle returned by the IcmpCreateFile function.</param>
		/// <param name="DestinationAddress">The IPv4 destination address of the echo request, in the form of an IPAddr structure.</param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IP header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform, this
		/// parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be <c>NULL</c> if no IP header options need to be specified.</para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// A buffer to hold any replies to the echo request. Upon return, the buffer contains an array of ICMP_ECHO_REPLY structures
		/// followed by the options and data for the replies. The buffer should be large enough to hold at least one <c>ICMP_ECHO_REPLY</c>
		/// structure plus RequestSize bytes of data.
		/// </param>
		/// <param name="ReplySize">
		/// <para>
		/// The allocated size, in bytes, of the reply buffer. The buffer should be large enough to hold at least one ICMP_ECHO_REPLY
		/// structure plus RequestSize bytes of data.
		/// </para>
		/// <para>This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message).</para>
		/// </param>
		/// <param name="Timeout">The time, in milliseconds, to wait for replies.</param>
		/// <returns>
		/// <para>
		/// The <c>IcmpSendEcho</c> function returns the number of ICMP_ECHO_REPLY structures stored in the ReplyBuffer. The status of each
		/// reply is contained in the structure. If the return value is zero, call GetLastError for additional error information.
		/// </para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The data area passed to a system call is too small. This error is returned if the ReplySize parameter indicates that the buffer
		/// pointed to by the ReplyBuffer parameter is too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the IcmpHandle parameter contains an invalid handle.
		/// This error can also be returned if the ReplySize parameter specifies a value less than the size of an ICMP_ECHO_REPLY structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpSendEcho</c> function send an ICMP echo request to the specified address and returns the number of replies received
		/// and stored in ReplyBuffer. The <c>IcmpSendEcho</c> function is a synchronous function and returns after waiting for the time
		/// specified in the Timeout parameter for a response. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The IcmpSendEcho2 and IcmpSendEcho2Ex functions are enhanced version of <c>IcmpSendEcho</c> that support asynchronous operation.
		/// The <c>IcmpSendEcho2Ex</c> function also allows the source IP address to be specified. This feature is useful on computers with
		/// multiple network interfaces.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>
		/// The <c>IcmpSendEcho</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpSendEcho</c> function is exported from
		/// the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function. Applications
		/// requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows versions should
		/// not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for the presence of
		/// <c>IcmpSendEcho</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the application should check
		/// for the presence of <c>IcmpSendEcho</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example sends an ICMP echo request to the IP address specified on the command line and prints the information
		/// received from the first response.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpsendecho IPHLPAPI_DLL_LINKAGE DWORD IcmpSendEcho(
		// HANDLE IcmpHandle, IPAddr DestinationAddress, LPVOID RequestData, WORD RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID
		// ReplyBuffer, DWORD ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "c3cdc535-2c13-48c6-9ab1-88cc5e5119b5")]
		public static extern uint IcmpSendEcho(SafeIcmpHandle IcmpHandle, IN_ADDR DestinationAddress, IntPtr RequestData, ushort RequestSize, in IP_OPTION_INFORMATION RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// The <c>IcmpSendEcho</c> function sends an IPv4 ICMP echo request and returns any echo response replies. The call returns when the
		/// time-out has expired or the reply buffer is filled.
		/// </summary>
		/// <param name="IcmpHandle">The open handle returned by the IcmpCreateFile function.</param>
		/// <param name="DestinationAddress">The IPv4 destination address of the echo request, in the form of an IPAddr structure.</param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IP header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform, this
		/// parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be <c>NULL</c> if no IP header options need to be specified.</para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// A buffer to hold any replies to the echo request. Upon return, the buffer contains an array of ICMP_ECHO_REPLY structures
		/// followed by the options and data for the replies. The buffer should be large enough to hold at least one <c>ICMP_ECHO_REPLY</c>
		/// structure plus RequestSize bytes of data.
		/// </param>
		/// <param name="ReplySize">
		/// <para>
		/// The allocated size, in bytes, of the reply buffer. The buffer should be large enough to hold at least one ICMP_ECHO_REPLY
		/// structure plus RequestSize bytes of data.
		/// </para>
		/// <para>This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message).</para>
		/// </param>
		/// <param name="Timeout">The time, in milliseconds, to wait for replies.</param>
		/// <returns>
		/// <para>
		/// The <c>IcmpSendEcho</c> function returns the number of ICMP_ECHO_REPLY structures stored in the ReplyBuffer. The status of each
		/// reply is contained in the structure. If the return value is zero, call GetLastError for additional error information.
		/// </para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The data area passed to a system call is too small. This error is returned if the ReplySize parameter indicates that the buffer
		/// pointed to by the ReplyBuffer parameter is too small.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the IcmpHandle parameter contains an invalid handle.
		/// This error can also be returned if the ReplySize parameter specifies a value less than the size of an ICMP_ECHO_REPLY structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpSendEcho</c> function send an ICMP echo request to the specified address and returns the number of replies received
		/// and stored in ReplyBuffer. The <c>IcmpSendEcho</c> function is a synchronous function and returns after waiting for the time
		/// specified in the Timeout parameter for a response. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The IcmpSendEcho2 and IcmpSendEcho2Ex functions are enhanced version of <c>IcmpSendEcho</c> that support asynchronous operation.
		/// The <c>IcmpSendEcho2Ex</c> function also allows the source IP address to be specified. This feature is useful on computers with
		/// multiple network interfaces.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>
		/// The <c>IcmpSendEcho</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpSendEcho</c> function is exported from
		/// the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function. Applications
		/// requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows versions should
		/// not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for the presence of
		/// <c>IcmpSendEcho</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the application should check
		/// for the presence of <c>IcmpSendEcho</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example sends an ICMP echo request to the IP address specified on the command line and prints the information
		/// received from the first response.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpsendecho IPHLPAPI_DLL_LINKAGE DWORD IcmpSendEcho(
		// HANDLE IcmpHandle, IPAddr DestinationAddress, LPVOID RequestData, WORD RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID
		// ReplyBuffer, DWORD ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "c3cdc535-2c13-48c6-9ab1-88cc5e5119b5")]
		public static extern uint IcmpSendEcho(SafeIcmpHandle IcmpHandle, IN_ADDR DestinationAddress, IntPtr RequestData, ushort RequestSize, [Optional] IntPtr RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// The <c>IcmpSendEcho2</c> function sends an IPv4 ICMP echo request and returns either immediately (if Event or ApcRoutine is non-
		/// <c>NULL</c>) or returns after the specified time-out. The ReplyBuffer contains the ICMP echo responses, if any.
		/// </summary>
		/// <param name="IcmpHandle">The open handle returned by the ICMPCreateFile function.</param>
		/// <param name="Event">
		/// <para>
		/// An event to be signaled whenever an ICMP response arrives. If this parameter is specified, it requires a handle to a valid event
		/// object. Use the CreateEvent or CreateEventEx function to create this event object.
		/// </para>
		/// <para>For more information on using events, see Event Objects.</para>
		/// </param>
		/// <param name="ApcRoutine">
		/// <para>
		/// The routine that is called when the calling thread is in an alertable thread and an ICMPv4 reply arrives. On Windows Vista and
		/// later, <c>PIO_APC_ROUTINE_DEFINED</c> must be defined to force the datatype for this parameter to <c>PIO_APC_ROUTINE</c> rather
		/// than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003, Windows XP, and Windows 2000, <c>PIO_APC_ROUTINE_DEFINED</c> must not be defined to force the datatype
		/// for this parameter to <c>FARPROC</c>.
		/// </para>
		/// </param>
		/// <param name="ApcContext">
		/// An optional parameter passed to the callback routine specified in the ApcRoutine parameter whenever an ICMP response arrives or
		/// an error occurs.
		/// </param>
		/// <param name="DestinationAddress">The IPv4 destination of the echo request, in the form of an IPAddr structure.</param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IP header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform, this
		/// parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be <c>NULL</c> if no IP header options need to be specified.</para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// <para>
		/// A pointer to a buffer to hold any replies to the request. Upon return, the buffer contains an array of ICMP_ECHO_REPLY structures
		/// followed by options and data. The buffer must be large enough to hold at least one <c>ICMP_ECHO_REPLY</c> structure plus
		/// RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="ReplySize">
		/// <para>
		/// The allocated size, in bytes, of the reply buffer. The buffer should be large enough to hold at least one ICMP_ECHO_REPLY
		/// structure plus RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="Timeout">The time, in milliseconds, to wait for replies.</param>
		/// <returns>
		/// <para>
		/// When called synchronously, the <c>IcmpSendEcho2</c> function returns the number of replies received and stored in ReplyBuffer. If
		/// the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// When called asynchronously, the <c>IcmpSendEcho2</c> function returns ERROR_IO_PENDING to indicate the operation is in progress.
		/// The results can be retrieved later when the event specified in the Event parameter signals or the callback function in the
		/// ApcRoutine parameter is called.
		/// </para>
		/// <para>If the return value is zero, call GetLastError for extended error information.</para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the IcmpHandle parameter contains an invalid handle.
		/// This error can also be returned if the ReplySize parameter specifies a value less than the size of an ICMP_ECHO_REPLY structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>
		/// The operation is in progress. This value is returned by a successful asynchronous call to IcmpSendEcho2 and is not an indication
		/// of an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpSendEcho2</c> function is called synchronously if the ApcRoutine or Event parameters are <c>NULL</c>. When called
		/// synchronously, the return value contains the number of replies received and stored in ReplyBuffer after waiting for the time
		/// specified in the Timeout parameter. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2</c> function is called asynchronously when either the ApcRoutine or Event parameters are specified. When
		/// called asynchronously, the ReplyBuffer and ReplySize parameters are required to accept the response. ICMP response data is copied
		/// to the ReplyBuffer provided and the application is signaled (when the Event parameter is specified) or the callback function is
		/// called (when the ApcRoutine parameter is specified). The application must parse the data pointed to by ReplyBuffer parameter
		/// using the IcmpParseReplies function.
		/// </para>
		/// <para>
		/// If the Event parameter is specified, the <c>IcmpSendEcho2</c> function is called asynchronously. The event specified in the Event
		/// parameter is signaled whenever an ICMP response arrives. Use the CreateEvent function to create this event object.
		/// </para>
		/// <para>
		/// If the ApcRoutine parameter is specified, the <c>IcmpSendEcho2</c> function is called asynchronously. The ApcRoutine parameter
		/// should point to a user-defined callback function. The callback function specified in the ApcRoutine parameter is called whenever
		/// an ICMP response arrives. The invocation of the callback function specified in the ApcRoutine parameter is serialized.
		/// </para>
		/// <para>
		/// If both the Event and ApcRoutine parameters are specified, the event specified in the Event parameter is signaled whenever an
		/// ICMP response arrives, but the callback function specified in the ApcRoutine parameter is ignored .
		/// </para>
		/// <para>
		/// On Windows Vista and later, any application that calls <c>IcmpSendEcho2</c> function asynchronously using the ApcRoutine
		/// parameter must define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to <c>PIO_APC_ROUTINE</c>
		/// rather than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the callback function pointed to by the ApcRoutine must be defined as a function of type <c>VOID</c>
		/// with the following syntax:
		/// </para>
		/// <para>On Windows Vista and later, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the IcmpSendEcho2 function. This parameter can be used by the application to identify the
		/// IcmpSendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN PIO_STATUS_BLOCK IoStatusBlock</term>
		/// <term>
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct. The
		/// IO_STATUS_BLOCK structure is defined in the Wdm.h header file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN ULONG Reserved</term>
		/// <term>This parameter is reserved.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows Server 2003, Windows XP, and Windows 2000, any application that calls the <c>IcmpSendEcho2</c> function asynchronously
		/// using the ApcRoutine parameter must not define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter
		/// to <c>FARPROC</c> rather than <c>PIO_APC_ROUTINE</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, the callback function pointed to by the ApcRoutine must be defined as a function of type
		/// <c>VOID</c> with the following syntax:
		/// </para>
		/// <para>On Windows Server 2003, Windows XP, and Windows 2000, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the IcmpSendEcho2 function. This parameter can be used by the application to identify the
		/// IcmpSendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the ApcRoutine parameter must be implemented in the same process as the application calling
		/// the <c>IcmpSendEcho2</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>IcmpSendEcho2</c> function.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpSendEcho2</c> function is exported
		/// from the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function. Applications
		/// requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows versions should
		/// not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for the presence of
		/// <c>IcmpSendEcho2</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the application should check
		/// for the presence of <c>IcmpSendEcho2</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example calls the <c>IcmpSendEcho2</c> function synchronously. The example sends an ICMP echo request to the IP
		/// address specified on the command line and prints the information received from the first response.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpsendecho2 IPHLPAPI_DLL_LINKAGE DWORD IcmpSendEcho2(
		// HANDLE IcmpHandle, HANDLE Event, PIO_APC_ROUTINE ApcRoutine, PVOID ApcContext, IPAddr DestinationAddress, LPVOID RequestData, WORD
		// RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID ReplyBuffer, DWORD ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "1f70b6cc-9085-4eb8-b2cc-3b3d98d0ea46")]
		public static extern uint IcmpSendEcho2(SafeIcmpHandle IcmpHandle, [Optional] HANDLE Event, [Optional] PIO_APC_ROUTINE ApcRoutine, [Optional] IntPtr ApcContext, IN_ADDR DestinationAddress, IntPtr RequestData, ushort RequestSize, in IP_OPTION_INFORMATION RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// The <c>IcmpSendEcho2</c> function sends an IPv4 ICMP echo request and returns either immediately (if Event or ApcRoutine is non-
		/// <c>NULL</c>) or returns after the specified time-out. The ReplyBuffer contains the ICMP echo responses, if any.
		/// </summary>
		/// <param name="IcmpHandle">The open handle returned by the ICMPCreateFile function.</param>
		/// <param name="Event">
		/// <para>
		/// An event to be signaled whenever an ICMP response arrives. If this parameter is specified, it requires a handle to a valid event
		/// object. Use the CreateEvent or CreateEventEx function to create this event object.
		/// </para>
		/// <para>For more information on using events, see Event Objects.</para>
		/// </param>
		/// <param name="ApcRoutine">
		/// <para>
		/// The routine that is called when the calling thread is in an alertable thread and an ICMPv4 reply arrives. On Windows Vista and
		/// later, <c>PIO_APC_ROUTINE_DEFINED</c> must be defined to force the datatype for this parameter to <c>PIO_APC_ROUTINE</c> rather
		/// than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003, Windows XP, and Windows 2000, <c>PIO_APC_ROUTINE_DEFINED</c> must not be defined to force the datatype
		/// for this parameter to <c>FARPROC</c>.
		/// </para>
		/// </param>
		/// <param name="ApcContext">
		/// An optional parameter passed to the callback routine specified in the ApcRoutine parameter whenever an ICMP response arrives or
		/// an error occurs.
		/// </param>
		/// <param name="DestinationAddress">The IPv4 destination of the echo request, in the form of an IPAddr structure.</param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IP header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform, this
		/// parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be <c>NULL</c> if no IP header options need to be specified.</para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// <para>
		/// A pointer to a buffer to hold any replies to the request. Upon return, the buffer contains an array of ICMP_ECHO_REPLY structures
		/// followed by options and data. The buffer must be large enough to hold at least one <c>ICMP_ECHO_REPLY</c> structure plus
		/// RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="ReplySize">
		/// <para>
		/// The allocated size, in bytes, of the reply buffer. The buffer should be large enough to hold at least one ICMP_ECHO_REPLY
		/// structure plus RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="Timeout">The time, in milliseconds, to wait for replies.</param>
		/// <returns>
		/// <para>
		/// When called synchronously, the <c>IcmpSendEcho2</c> function returns the number of replies received and stored in ReplyBuffer. If
		/// the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// When called asynchronously, the <c>IcmpSendEcho2</c> function returns ERROR_IO_PENDING to indicate the operation is in progress.
		/// The results can be retrieved later when the event specified in the Event parameter signals or the callback function in the
		/// ApcRoutine parameter is called.
		/// </para>
		/// <para>If the return value is zero, call GetLastError for extended error information.</para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the IcmpHandle parameter contains an invalid handle.
		/// This error can also be returned if the ReplySize parameter specifies a value less than the size of an ICMP_ECHO_REPLY structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>
		/// The operation is in progress. This value is returned by a successful asynchronous call to IcmpSendEcho2 and is not an indication
		/// of an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IcmpSendEcho2</c> function is called synchronously if the ApcRoutine or Event parameters are <c>NULL</c>. When called
		/// synchronously, the return value contains the number of replies received and stored in ReplyBuffer after waiting for the time
		/// specified in the Timeout parameter. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2</c> function is called asynchronously when either the ApcRoutine or Event parameters are specified. When
		/// called asynchronously, the ReplyBuffer and ReplySize parameters are required to accept the response. ICMP response data is copied
		/// to the ReplyBuffer provided and the application is signaled (when the Event parameter is specified) or the callback function is
		/// called (when the ApcRoutine parameter is specified). The application must parse the data pointed to by ReplyBuffer parameter
		/// using the IcmpParseReplies function.
		/// </para>
		/// <para>
		/// If the Event parameter is specified, the <c>IcmpSendEcho2</c> function is called asynchronously. The event specified in the Event
		/// parameter is signaled whenever an ICMP response arrives. Use the CreateEvent function to create this event object.
		/// </para>
		/// <para>
		/// If the ApcRoutine parameter is specified, the <c>IcmpSendEcho2</c> function is called asynchronously. The ApcRoutine parameter
		/// should point to a user-defined callback function. The callback function specified in the ApcRoutine parameter is called whenever
		/// an ICMP response arrives. The invocation of the callback function specified in the ApcRoutine parameter is serialized.
		/// </para>
		/// <para>
		/// If both the Event and ApcRoutine parameters are specified, the event specified in the Event parameter is signaled whenever an
		/// ICMP response arrives, but the callback function specified in the ApcRoutine parameter is ignored .
		/// </para>
		/// <para>
		/// On Windows Vista and later, any application that calls <c>IcmpSendEcho2</c> function asynchronously using the ApcRoutine
		/// parameter must define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to <c>PIO_APC_ROUTINE</c>
		/// rather than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// On Windows Vista and later, the callback function pointed to by the ApcRoutine must be defined as a function of type <c>VOID</c>
		/// with the following syntax:
		/// </para>
		/// <para>On Windows Vista and later, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the IcmpSendEcho2 function. This parameter can be used by the application to identify the
		/// IcmpSendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN PIO_STATUS_BLOCK IoStatusBlock</term>
		/// <term>
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct. The
		/// IO_STATUS_BLOCK structure is defined in the Wdm.h header file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN ULONG Reserved</term>
		/// <term>This parameter is reserved.</term>
		/// </item>
		/// </list>
		/// <para>
		/// On Windows Server 2003, Windows XP, and Windows 2000, any application that calls the <c>IcmpSendEcho2</c> function asynchronously
		/// using the ApcRoutine parameter must not define <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter
		/// to <c>FARPROC</c> rather than <c>PIO_APC_ROUTINE</c>.
		/// </para>
		/// <para>
		/// On Windows Server 2003 and Windows XP, the callback function pointed to by the ApcRoutine must be defined as a function of type
		/// <c>VOID</c> with the following syntax:
		/// </para>
		/// <para>On Windows Server 2003, Windows XP, and Windows 2000, the parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the IcmpSendEcho2 function. This parameter can be used by the application to identify the
		/// IcmpSendEcho2 request that the callback function is responding to.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the ApcRoutine parameter must be implemented in the same process as the application calling
		/// the <c>IcmpSendEcho2</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>IcmpSendEcho2</c> function.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2</c> function is exported from the Icmp.dll on Windows 2000. The <c>IcmpSendEcho2</c> function is exported
		/// from the Iphlpapi.dll on Windows XP and later. Windows version checking is not recommended to use this function. Applications
		/// requiring portability with this function across Windows 2000, Windows XP, Windows Server 2003 and later Windows versions should
		/// not statically link to either the Icmp.lib or the Iphlpapi.lib file. Instead, the application should check for the presence of
		/// <c>IcmpSendEcho2</c> in the Iphlpapi.dll with calls to LoadLibrary and GetProcAddress. Failing that, the application should check
		/// for the presence of <c>IcmpSendEcho2</c> in the Icmp.dll with calls to <c>LoadLibrary</c> and <c>GetProcAddress</c>.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example calls the <c>IcmpSendEcho2</c> function synchronously. The example sends an ICMP echo request to the IP
		/// address specified on the command line and prints the information received from the first response.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpsendecho2 IPHLPAPI_DLL_LINKAGE DWORD IcmpSendEcho2(
		// HANDLE IcmpHandle, HANDLE Event, PIO_APC_ROUTINE ApcRoutine, PVOID ApcContext, IPAddr DestinationAddress, LPVOID RequestData, WORD
		// RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID ReplyBuffer, DWORD ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "1f70b6cc-9085-4eb8-b2cc-3b3d98d0ea46")]
		public static extern uint IcmpSendEcho2(SafeIcmpHandle IcmpHandle, [Optional] HANDLE Event, [Optional] PIO_APC_ROUTINE ApcRoutine, [Optional] IntPtr ApcContext, IN_ADDR DestinationAddress, IntPtr RequestData, ushort RequestSize, [Optional] IntPtr RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// The <c>IcmpSendEcho2Ex</c> function sends an IPv4 ICMP echo request and returns either immediately (if Event or ApcRoutine is
		/// non- <c>NULL</c>) or returns after the specified time-out. The ReplyBuffer contains the ICMP responses, if any.
		/// </summary>
		/// <param name="IcmpHandle">An open handle returned by the ICMPCreateFile function.</param>
		/// <param name="Event">
		/// <para>
		/// An event to be signaled whenever an ICMP response arrives. If this parameter is specified, it requires a handle to a valid event
		/// object. Use the CreateEvent or CreateEventEx function to create this event object.
		/// </para>
		/// <para>For more information on using events, see Event Objects.</para>
		/// </param>
		/// <param name="ApcRoutine">
		/// The routine that is called when the calling thread is in an alertable thread and an ICMP reply arrives.
		/// <c>PIO_APC_ROUTINE_DEFINED</c> must be defined to force the datatype for this parameter to <c>PIO_APC_ROUTINE</c> rather than <c>FARPROC</c>.
		/// </param>
		/// <param name="ApcContext">
		/// An optional parameter passed to the callback routine specified in the ApcRoutine parameter whenever an ICMP response arrives or
		/// an error occurs.
		/// </param>
		/// <param name="SourceAddress">
		/// The IPv4 source address on which to issue the echo request. This address is in the form of an IPAddr structure.
		/// </param>
		/// <param name="DestinationAddress">
		/// The IPv4 destination address for the echo request. This address is in the form of an IPAddr structure.
		/// </param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IP header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform, this
		/// parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be <c>NULL</c> if no IP header options need to be specified.</para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// <para>
		/// A pointer to a buffer to hold any replies to the request. Upon return, the buffer contains an array of ICMP_ECHO_REPLY structures
		/// followed by options and data. The buffer must be large enough to hold at least one <c>ICMP_ECHO_REPLY</c> structure plus
		/// RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="ReplySize">
		/// <para>
		/// The allocated size, in bytes, of the reply buffer. The buffer should be large enough to hold at least one ICMP_ECHO_REPLY
		/// structure plus RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="Timeout">The time, in milliseconds, to wait for replies.</param>
		/// <returns>
		/// <para>
		/// When called synchronously, the <c>IcmpSendEcho2Ex</c> function returns the number of replies received and stored in ReplyBuffer.
		/// If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// When called asynchronously, the <c>IcmpSendEcho2Ex</c> function returns ERROR_IO_PENDING to indicate the operation is in
		/// progress. The results can be retrieved later when the event specified in the Event parameter signals or the callback function in
		/// the ApcRoutine parameter is called.
		/// </para>
		/// <para>If the return value is zero, call GetLastError for extended error information.</para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the IcmpHandle parameter contains an invalid handle.
		/// This error can also be returned if the ReplySize parameter specifies a value less than the size of an ICMP_ECHO_REPLY structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>
		/// The operation is in progress. This value is returned by a successful asynchronous call to IcmpSendEcho2Ex and is not an
		/// indication of an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>IcmpSendEcho2Ex</c> function is available on Windows Server 2008 and later.</para>
		/// <para>
		/// The <c>IcmpSendEcho2Ex</c> function is an enhanced version of the IcmpSendEcho2 function that allows the user to specify the IPv4
		/// source address on which to issue the ICMP request. The <c>IcmpSendEcho2Ex</c> function is useful in cases where a computer has
		/// multiple network interfaces.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2Ex</c> function is called synchronously if the ApcRoutine or Event parameters are <c>NULL</c>. When called
		/// synchronously, the return value contains the number of replies received and stored in ReplyBuffer after waiting for the time
		/// specified in the Timeout parameter. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2Ex</c> function is called asynchronously when either the ApcRoutine or Event parameters are specified. When
		/// called asynchronously, the ReplyBuffer and ReplySize parameters are required to accept the response. ICMP response data is copied
		/// to the ReplyBuffer provided and the application is signaled (when the Event parameter is specified) or the callback function is
		/// called (when the ApcRoutine parameter is specified). The application must parse the data pointed to by ReplyBuffer parameter
		/// using the IcmpParseReplies function.
		/// </para>
		/// <para>
		/// If the Event parameter is specified, the <c>IcmpSendEcho2Ex</c> function is called asynchronously. The event specified in the
		/// Event parameter is signaled whenever an ICMP response arrives. Use the CreateEvent function to create this event object.
		/// </para>
		/// <para>
		/// If the ApcRoutine parameter is specified, the <c>IcmpSendEcho2Ex</c> function is called asynchronously. The ApcRoutine parameter
		/// should point to a user-defined callback function. The callback function specified in the ApcRoutine parameter is called whenever
		/// an ICMP response arrives. The invocation of the callback function specified in the ApcRoutine parameter is serialized.
		/// </para>
		/// <para>
		/// If both the Event and ApcRoutine parameters are specified, the event specified in the Event parameter is signaled whenever an
		/// ICMP response arrives, but the callback function specified in the ApcRoutine parameter is ignored .
		/// </para>
		/// <para>
		/// Any application that calls the <c>IcmpSendEcho2Ex</c> function asynchronously using the ApcRoutine parameter must define
		/// <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to <c>PIO_APC_ROUTINE</c> rather than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// The callback function pointed to by the ApcRoutine must be defined as a function of type <c>VOID</c> with the following syntax:
		/// </para>
		/// <para>The parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the IcmpSendEcho2Ex function. This parameter can be used by the application to identify the
		/// IcmpSendEcho2Ex request that the callback function is responding to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN PIO_STATUS_BLOCK IoStatusBlock</term>
		/// <term>
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct. The
		/// IO_STATUS_BLOCK structure is defined in the Wdm.h header file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN ULONG Reserved</term>
		/// <term>This parameter is reserved.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the ApcRoutine parameter must be implemented in the same process as the application calling
		/// the <c>IcmpSendEcho2Ex</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>IcmpSendEcho2Ex</c> function.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpsendecho2ex IPHLPAPI_DLL_LINKAGE DWORD
		// IcmpSendEcho2Ex( HANDLE IcmpHandle, HANDLE Event, PIO_APC_ROUTINE ApcRoutine, PVOID ApcContext, IPAddr SourceAddress, IPAddr
		// DestinationAddress, LPVOID RequestData, WORD RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID ReplyBuffer, DWORD
		// ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "7b2b2cae-650f-4ecb-aa2e-a55ee4026999")]
		public static extern uint IcmpSendEcho2Ex(SafeIcmpHandle IcmpHandle, [Optional] HANDLE Event, [Optional] PIO_APC_ROUTINE ApcRoutine, [Optional] IntPtr ApcContext, IN_ADDR SourceAddress, IN_ADDR DestinationAddress, IntPtr RequestData, ushort RequestSize, in IP_OPTION_INFORMATION RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// The <c>IcmpSendEcho2Ex</c> function sends an IPv4 ICMP echo request and returns either immediately (if Event or ApcRoutine is
		/// non- <c>NULL</c>) or returns after the specified time-out. The ReplyBuffer contains the ICMP responses, if any.
		/// </summary>
		/// <param name="IcmpHandle">An open handle returned by the ICMPCreateFile function.</param>
		/// <param name="Event">
		/// <para>
		/// An event to be signaled whenever an ICMP response arrives. If this parameter is specified, it requires a handle to a valid event
		/// object. Use the CreateEvent or CreateEventEx function to create this event object.
		/// </para>
		/// <para>For more information on using events, see Event Objects.</para>
		/// </param>
		/// <param name="ApcRoutine">
		/// The routine that is called when the calling thread is in an alertable thread and an ICMP reply arrives.
		/// <c>PIO_APC_ROUTINE_DEFINED</c> must be defined to force the datatype for this parameter to <c>PIO_APC_ROUTINE</c> rather than <c>FARPROC</c>.
		/// </param>
		/// <param name="ApcContext">
		/// An optional parameter passed to the callback routine specified in the ApcRoutine parameter whenever an ICMP response arrives or
		/// an error occurs.
		/// </param>
		/// <param name="SourceAddress">
		/// The IPv4 source address on which to issue the echo request. This address is in the form of an IPAddr structure.
		/// </param>
		/// <param name="DestinationAddress">
		/// The IPv4 destination address for the echo request. This address is in the form of an IPAddr structure.
		/// </param>
		/// <param name="RequestData">A pointer to a buffer that contains data to send in the request.</param>
		/// <param name="RequestSize">The size, in bytes, of the request data buffer pointed to by the RequestData parameter.</param>
		/// <param name="RequestOptions">
		/// <para>
		/// A pointer to the IP header options for the request, in the form of an IP_OPTION_INFORMATION structure. On a 64-bit platform, this
		/// parameter is in the form for an IP_OPTION_INFORMATION32 structure.
		/// </para>
		/// <para>This parameter may be <c>NULL</c> if no IP header options need to be specified.</para>
		/// </param>
		/// <param name="ReplyBuffer">
		/// <para>
		/// A pointer to a buffer to hold any replies to the request. Upon return, the buffer contains an array of ICMP_ECHO_REPLY structures
		/// followed by options and data. The buffer must be large enough to hold at least one <c>ICMP_ECHO_REPLY</c> structure plus
		/// RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="ReplySize">
		/// <para>
		/// The allocated size, in bytes, of the reply buffer. The buffer should be large enough to hold at least one ICMP_ECHO_REPLY
		/// structure plus RequestSize bytes of data.
		/// </para>
		/// <para>
		/// This buffer should also be large enough to also hold 8 more bytes of data (the size of an ICMP error message) plus space for an
		/// <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// </param>
		/// <param name="Timeout">The time, in milliseconds, to wait for replies.</param>
		/// <returns>
		/// <para>
		/// When called synchronously, the <c>IcmpSendEcho2Ex</c> function returns the number of replies received and stored in ReplyBuffer.
		/// If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// When called asynchronously, the <c>IcmpSendEcho2Ex</c> function returns ERROR_IO_PENDING to indicate the operation is in
		/// progress. The results can be retrieved later when the event specified in the Event parameter signals or the callback function in
		/// the ApcRoutine parameter is called.
		/// </para>
		/// <para>If the return value is zero, call GetLastError for extended error information.</para>
		/// <para>If the function fails, the extended error code returned by GetLastError can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// An invalid parameter was passed to the function. This error is returned if the IcmpHandle parameter contains an invalid handle.
		/// This error can also be returned if the ReplySize parameter specifies a value less than the size of an ICMP_ECHO_REPLY structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_IO_PENDING</term>
		/// <term>
		/// The operation is in progress. This value is returned by a successful asynchronous call to IcmpSendEcho2Ex and is not an
		/// indication of an error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported. This error is returned if no IPv4 stack is on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>IP_BUF_TOO_SMALL</term>
		/// <term>The size of the ReplyBuffer specified in the ReplySize parameter was too small.</term>
		/// </item>
		/// <item>
		/// <term>Other</term>
		/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>IcmpSendEcho2Ex</c> function is available on Windows Server 2008 and later.</para>
		/// <para>
		/// The <c>IcmpSendEcho2Ex</c> function is an enhanced version of the IcmpSendEcho2 function that allows the user to specify the IPv4
		/// source address on which to issue the ICMP request. The <c>IcmpSendEcho2Ex</c> function is useful in cases where a computer has
		/// multiple network interfaces.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2Ex</c> function is called synchronously if the ApcRoutine or Event parameters are <c>NULL</c>. When called
		/// synchronously, the return value contains the number of replies received and stored in ReplyBuffer after waiting for the time
		/// specified in the Timeout parameter. If the return value is zero, call GetLastError for extended error information.
		/// </para>
		/// <para>
		/// The <c>IcmpSendEcho2Ex</c> function is called asynchronously when either the ApcRoutine or Event parameters are specified. When
		/// called asynchronously, the ReplyBuffer and ReplySize parameters are required to accept the response. ICMP response data is copied
		/// to the ReplyBuffer provided and the application is signaled (when the Event parameter is specified) or the callback function is
		/// called (when the ApcRoutine parameter is specified). The application must parse the data pointed to by ReplyBuffer parameter
		/// using the IcmpParseReplies function.
		/// </para>
		/// <para>
		/// If the Event parameter is specified, the <c>IcmpSendEcho2Ex</c> function is called asynchronously. The event specified in the
		/// Event parameter is signaled whenever an ICMP response arrives. Use the CreateEvent function to create this event object.
		/// </para>
		/// <para>
		/// If the ApcRoutine parameter is specified, the <c>IcmpSendEcho2Ex</c> function is called asynchronously. The ApcRoutine parameter
		/// should point to a user-defined callback function. The callback function specified in the ApcRoutine parameter is called whenever
		/// an ICMP response arrives. The invocation of the callback function specified in the ApcRoutine parameter is serialized.
		/// </para>
		/// <para>
		/// If both the Event and ApcRoutine parameters are specified, the event specified in the Event parameter is signaled whenever an
		/// ICMP response arrives, but the callback function specified in the ApcRoutine parameter is ignored .
		/// </para>
		/// <para>
		/// Any application that calls the <c>IcmpSendEcho2Ex</c> function asynchronously using the ApcRoutine parameter must define
		/// <c>PIO_APC_ROUTINE_DEFINED</c> to force the datatype for the ApcRoutine parameter to <c>PIO_APC_ROUTINE</c> rather than <c>FARPROC</c>.
		/// </para>
		/// <para>
		/// The callback function pointed to by the ApcRoutine must be defined as a function of type <c>VOID</c> with the following syntax:
		/// </para>
		/// <para>The parameters passed to the callback function include the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IN PVOID ApcContext</term>
		/// <term>
		/// The ApcContext parameter passed to the IcmpSendEcho2Ex function. This parameter can be used by the application to identify the
		/// IcmpSendEcho2Ex request that the callback function is responding to.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN PIO_STATUS_BLOCK IoStatusBlock</term>
		/// <term>
		/// A pointer to a IO_STATUS_BLOCK. This variable contains the final completion status and information about the operation. The
		/// number of bytes actually received in the reply is returned in the Information member of the IO_STATUS_BLOCK struct. The
		/// IO_STATUS_BLOCK structure is defined in the Wdm.h header file.
		/// </term>
		/// </item>
		/// <item>
		/// <term>IN ULONG Reserved</term>
		/// <term>This parameter is reserved.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The callback function specified in the ApcRoutine parameter must be implemented in the same process as the application calling
		/// the <c>IcmpSendEcho2Ex</c> function. If the callback function is in a separate DLL, then the DLL should be loaded before calling
		/// the <c>IcmpSendEcho2Ex</c> function.
		/// </para>
		/// <para>For IPv6, use the Icmp6CreateFile, Icmp6SendEcho2, and Icmp6ParseReplies functions.</para>
		/// <para>Note that the include directive for Iphlpapi.h header file must be placed before the Icmpapi.h header file.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/icmpapi/nf-icmpapi-icmpsendecho2ex IPHLPAPI_DLL_LINKAGE DWORD
		// IcmpSendEcho2Ex( HANDLE IcmpHandle, HANDLE Event, PIO_APC_ROUTINE ApcRoutine, PVOID ApcContext, IPAddr SourceAddress, IPAddr
		// DestinationAddress, LPVOID RequestData, WORD RequestSize, PIP_OPTION_INFORMATION RequestOptions, LPVOID ReplyBuffer, DWORD
		// ReplySize, DWORD Timeout );
		[DllImport(Lib.IpHlpApi, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("icmpapi.h", MSDNShortId = "7b2b2cae-650f-4ecb-aa2e-a55ee4026999")]
		public static extern uint IcmpSendEcho2Ex(SafeIcmpHandle IcmpHandle, [Optional] HANDLE Event, [Optional] PIO_APC_ROUTINE ApcRoutine, [Optional] IntPtr ApcContext, IN_ADDR SourceAddress, IN_ADDR DestinationAddress, IntPtr RequestData, ushort RequestSize, [Optional] IntPtr RequestOptions, IntPtr ReplyBuffer, uint ReplySize, uint Timeout);

		/// <summary>
		/// A driver sets an IRP's I/O status block to indicate the final status of an I/O request, before calling IoCompleteRequest for the IRP.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Unless a driver's dispatch routine completes an IRP with an error status value, the lowest-level driver in the chain frequently
		/// sets the IRP's I/O status block to the values that will be returned to the original requester of the I/O operation.
		/// </para>
		/// <para>
		/// The IoCompletion routines of higher-level drivers usually check the I/O status block in IRPs completed by lower drivers. By
		/// design, the I/O status block in an IRP is the only information passed back from the underlying device driver to all higher-level
		/// drivers' IoCompletion routines.
		/// </para>
		/// <para>
		/// The operating system implements support routines that write <c>IO_STATUS_BLOCK</c> values to caller-supplied output buffers. For
		/// example, see ZwOpenFile or NtOpenFile. These routines return status codes that might not match the status codes in the
		/// <c>IO_STATUS_BLOCK</c> structures. If one of these routines returns STATUS_PENDING, the caller should wait for the I/O operation
		/// to complete, and then check the status code in the <c>IO_STATUS_BLOCK</c> structure to determine the final status of the
		/// operation. If the routine returns a status code other than STATUS_PENDING, the caller should rely on this status code instead of
		/// the status code in the <c>IO_STATUS_BLOCK</c> structure.
		/// </para>
		/// <para>For more information, see I/O Status Blocks.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/ns-wdm-_io_status_block typedef struct _IO_STATUS_BLOCK
		// { union { NTSTATUS Status; PVOID Pointer; } DUMMYUNIONNAME; ULONG_PTR Information; } IO_STATUS_BLOCK, *PIO_STATUS_BLOCK;
		[PInvokeData("wdm.h", MSDNShortId = "1ce2b1d0-a8b2-4a05-8895-e13802690a7b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IO_STATUS_BLOCK
		{
			/// <summary>
			/// This is the completion status, either STATUS_SUCCESS if the requested operation was completed successfully or an
			/// informational, warning, or error STATUS_XXX value. For more information, see Using NTSTATUS values.
			/// </summary>
			[MarshalAs(UnmanagedType.SysUInt)]
			public NTStatus Status;

			/// <summary>
			/// This is set to a request-dependent value. For example, on successful completion of a transfer request, this is set to the
			/// number of bytes transferred. If a transfer request is completed with another STATUS_XXX, this member is set to zero.
			/// </summary>
			public IntPtr Information;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for an IMCP handle that is disposed using <see cref="IcmpCloseHandle"/>.</summary>
		public class SafeIcmpHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeIcmpHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeIcmpHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeIcmpHandle"/> class.</summary>
			private SafeIcmpHandle() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => IcmpCloseHandle(handle);
		}
	}
}