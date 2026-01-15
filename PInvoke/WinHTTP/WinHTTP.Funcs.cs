using INTERNET_PORT = System.UInt16;

namespace Vanara.PInvoke;

/// <summary>Items from the WinHTTP.dll.</summary>
public static partial class WinHTTP
{
	private const string Lib_Winhttp = "WinHTTP.dll";

	/// <summary>The <c>WINHTTP_STATUS_CALLBACK</c> type represents an application-defined status callback function.</summary>
	/// <param name="hInternet">The handle for which the callback function is called.</param>
	/// <param name="dwContext">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the application-defined context value associated with the handle in the
	/// <c>hInternet</c> parameter.
	/// </para>
	/// <para>
	/// A context value can be assigned to a Session, Connect, or Request handle by calling WinHttpSetOption with the
	/// WINHTTP_OPTION_CONTEXT_VALUE option. Alternatively, WinHttpSendRequest can be used to associate a context value with a Request handle.
	/// </para>
	/// </param>
	/// <param name="dwInternetStatus">
	/// <para>
	/// Points to a <c>DWORD</c> that specifies the status code that indicates why the callback function is called. This can be one of
	/// the following values:
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION</para>
	/// <para>Closing the connection to the server. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER</para>
	/// <para>
	/// Successfully connected to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to an <c>PWSTR</c> that
	/// indicates the IP address of the server in dotted notation.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_CONNECTING_TO_SERVER</para>
	/// <para>
	/// Connecting to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to an <c>PWSTR</c> that indicates the IP
	/// address of the server in dotted notation.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED</para>
	/// <para>Successfully closed the connection to the server. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE</para>
	/// <para>
	/// Data is available to be retrieved with WinHttpReadData. The <c>lpvStatusInformation</c> parameter points to a <c>DWORD</c> that
	/// contains the number of bytes of data available. The <c>dwStatusInformationLength</c> parameter itself is 4 (the size of a <c>DWORD</c>).
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_HANDLE_CREATED</para>
	/// <para>An HINTERNET handle has been created. The <c>lpvStatusInformation</c> parameter contains a pointer to the HINTERNET handle.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</para>
	/// <para>
	/// This handle value has been terminated. The <c>lpvStatusInformation</c> parameter contains a pointer to the HINTERNET handle.
	/// There will be no more callbacks for this handle.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE</para>
	/// <para>
	/// The response header has been received and is available with WinHttpQueryHeaders. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE</para>
	/// <para>
	/// Received an intermediate (100 level) status code message from the server. The <c>lpvStatusInformation</c> parameter contains a
	/// pointer to a <c>DWORD</c> that indicates the status code.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_NAME_RESOLVED</para>
	/// <para>
	/// Successfully found the IP address of the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a <c>PWSTR</c>
	/// that indicates the name that was resolved.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</para>
	/// <para>
	/// Data was successfully read from the server. The <c>lpvStatusInformation</c> parameter contains a pointer to the buffer specified
	/// in the call to WinHttpReadData. The <c>dwStatusInformationLength</c> parameter contains the number of bytes read.
	/// </para>
	/// <para>
	/// When used by WinHttpWebSocketReceive, the <c>lpvStatusInformation</c> parameter contains a pointer to a WINHTTP_WEB_SOCKET_STATUS
	/// structure, and the <c>dwStatusInformationLength</c> parameter indicates the size of <c>lpvStatusInformation</c>.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</para>
	/// <para>Waiting for the server to respond to a request. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_REDIRECT</para>
	/// <para>
	/// An HTTP request is about to automatically redirect the request. The <c>lpvStatusInformation</c> parameter contains a pointer to
	/// an <c>PWSTR</c> indicating the new URL. At this point, the application can read any data returned by the server with the
	/// redirect response and can query the response headers. It can also cancel the operation by closing the handle.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</para>
	/// <para>
	/// An error occurred while sending an HTTP request. The <c>lpvStatusInformation</c> parameter contains a pointer to a
	/// WINHTTP_ASYNC_RESULT structure. Its <c>dwResult</c> member indicates the ID of the called function and <c>dwError</c> indicates
	/// the return value.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_REQUEST_SENT</para>
	/// <para>
	/// Successfully sent the information request to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a
	/// <c>DWORD</c> indicating the number of bytes sent.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_RESOLVING_NAME</para>
	/// <para>
	/// Looking up the IP address of a server name. The <c>lpvStatusInformation</c> parameter contains a pointer to the server name being resolved.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</para>
	/// <para>
	/// Successfully received a response from the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a <c>DWORD</c>
	/// indicating the number of bytes received.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_SECURE_FAILURE</para>
	/// <para>
	/// One or more errors were encountered while retrieving a Secure Sockets Layer (SSL) certificate from the server. The
	/// <c>lpvStatusInformation</c> parameter contains a flag. For more information, see the description for <c>lpvStatusInformation</c>.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_SENDING_REQUEST</para>
	/// <para>Sending the information request to the server. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE</para>
	/// <para>The request completed successfully. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE</para>
	/// <para>
	/// Data was successfully written to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a <c>DWORD</c> that
	/// indicates the number of bytes written.
	/// </para>
	/// <para>
	/// When used by WinHttpWebSocketSend, the <c>lpvStatusInformation</c> parameter contains a pointer to a WINHTTP_WEB_SOCKET_STATUS
	/// structure, and the <c>dwStatusInformationLength</c> parameter indicates the size of <c>lpvStatusInformation</c>.
	/// </para>
	/// <para>WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE</para>
	/// <para>The operation initiated by a call to WinHttpGetProxyForUrlEx is complete. Data is available to be retrieved with WinHttpReadData.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_CLOSE_COMPLETE</para>
	/// <para>The connection was successfully closed via a call to WinHttpWebSocketClose.</para>
	/// <para>WINHTTP_CALLBACK_STATUS_SHUTDOWN_COMPLETE</para>
	/// <para>The connection was successfully shut down via a call to WinHttpWebSocketShutdown.</para>
	/// </param>
	/// <param name="lpvStatusInformation">
	/// <para>
	/// A pointer to a buffer that specifies information pertinent to this call to the callback function. The format of these data
	/// depends on the value of the <c>dwInternetStatus</c> argument. For more information, see <c>dwInternetStatus</c>.
	/// </para>
	/// <para>
	/// If the <c>dwInternetStatus</c> argument is WINHTTP_CALLBACK_STATUS_SECURE_FAILURE, then <c>lpvStatusInformation</c> points to a
	/// DWORD which is a bitwise-OR combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_CERT_REV_FAILED</c></term>
	/// <term>
	/// Certification revocation checking has been enabled, but the revocation check failed to verify whether a certificate has been
	/// revoked. The server used to check for revocation might be unreachable.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_INVALID_CERT</c></term>
	/// <term>SSL certificate is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_CERT_REVOKED</c></term>
	/// <term>SSL certificate was revoked.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_INVALID_CA</c></term>
	/// <term>The function is unfamiliar with the Certificate Authority that generated the server's certificate.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_CERT_CN_INVALID</c></term>
	/// <term>
	/// SSL certificate common name (host name field) is incorrect, for example, if you entered www.microsoft.com and the common name on
	/// the certificate says www.msn.com.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_CERT_DATE_INVALID</c></term>
	/// <term>SSL certificate date that was received from the server is bad. The certificate is expired.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_STATUS_FLAG_SECURITY_CHANNEL_ERROR</c></term>
	/// <term>The application experienced an internal error loading the SSL libraries.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwStatusInformationLength">
	/// <c>WINHTTP_CALLBACK_STATUS_REDIRECT</c> status callbacks provide a <c>dwStatusInformationLength</c> value that corresponds to the
	/// character count of the <c>PWSTR</c> pointed to by <c>lpvStatusInformation</c>.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The callback function must be threadsafe and reentrant because it can be called on another thread for a separate request, and
	/// reentered on the same thread for the current request. It must therefore be coded to handle reentrance safely while processing.
	/// When the <c>dwInternetStatus</c> parameter is equal to <c>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</c>, the callback does not need
	/// to be able to handle reentrance for the same request, because this callback is guaranteed to be the last, and does not occur when
	/// other messages for this request are handled.
	/// </para>
	/// <para>
	/// The status callback function receives updates on the status of asynchronous operations through notification flags. Notifications
	/// that indicate a particular operation is complete are called completion notifications, or just completions. The following table
	/// lists the six completion flags and the corresponding function that is complete when this flag is received.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Completion flag</term>
	/// <term>Function</term>
	/// </listheader>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE</term>
	/// <term>WinHttpQueryDataAvailable</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE</term>
	/// <term>WinHttpReceiveResponse</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</term>
	/// <term>WinHttpReadData</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE</term>
	/// <term>WinHttpSendRequest</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE</term>
	/// <term>WinHttpWriteData</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</term>
	/// <term>Any of the above functions when an error occurs.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Because callbacks are made during the processing of the request, the application should spend as little time as possible in the
	/// callback function to avoid degrading data throughput on the network. For example, displaying a dialog box in a callback function
	/// can be such a lengthy operation that the server terminates the request.
	/// </para>
	/// <para>The callback function can be called in a thread context different from the thread that initiated the request.</para>
	/// <para>
	/// Similarly, there is no callback thread affinity when you call WinHttp asynchronously: a call might start from one thread, but any
	/// other thread can receive the callback.
	/// </para>
	/// <para><c>Note</c> For more information about implementation in Windows XP and Windows 2000, see Run-Time Requirements.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nc-winhttp-winhttp_status_callback WINHTTP_STATUS_CALLBACK
	// WinhttpStatusCallback; void WinhttpStatusCallback( [in] HINTERNET hInternet, [in] DWORD_PTR dwContext, [in] DWORD
	// dwInternetStatus, [in] LPVOID lpvStatusInformation, [in] DWORD dwStatusInformationLength ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winhttp.h", MSDNShortId = "NC:winhttp.WINHTTP_STATUS_CALLBACK")]
	public delegate void WINHTTP_STATUS_CALLBACK([In] HINTERNET hInternet, [In] IntPtr dwContext, WINHTTP_CALLBACK_STATUS dwInternetStatus,
		[In, Optional] IntPtr lpvStatusInformation, uint dwStatusInformationLength);

	/// <summary>The <c>WinHttpAddRequestHeaders</c> function adds one or more HTTP request headers to the HTTP request handle.</summary>
	/// <param name="hRequest">A HINTERNET handle returned by a call to the WinHttpOpenRequest function.</param>
	/// <param name="lpszHeaders">
	/// A pointer to a string variable that contains the headers to append to the request. Each header except the last must be terminated
	/// by a carriage return/line feed (CR/LF).
	/// </param>
	/// <param name="dwHeadersLength">
	/// An unsigned long integer value that contains the length, in characters, of <c>pwszHeaders</c>. If this parameter is -1L, the
	/// function assumes that <c>pwszHeaders</c> is zero-terminated (ASCIIZ), and the length is computed.
	/// </param>
	/// <param name="dwModifiers">
	/// <para>
	/// An unsigned long integer value that contains the flags used to modify the semantics of this function. Can be one or more of the
	/// following flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_ADD</c></term>
	/// <term>Adds the header if it does not exist. Used with <c>WINHTTP_ADDREQ_FLAG_REPLACE</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_ADD_IF_NEW</c></term>
	/// <term>Adds the header only if it does not already exist; otherwise, an error is returned.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_COALESCE</c></term>
	/// <term>Merges headers of the same name.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA</c></term>
	/// <term>
	/// Merges headers of the same name using a comma. For example, adding "Accept: text/*" followed by "Accept: audio/*" with this flag
	/// results in a single header "Accept: text/*, audio/*". This causes the first header found to be merged. The calling application
	/// must to ensure a cohesive scheme with respect to merged and separate headers.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON</c></term>
	/// <term>Merges headers of the same name using a semicolon.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_REPLACE</c></term>
	/// <term>
	/// Replaces or removes a header. If the header value is empty and the header is found, it is removed. If the value is not empty, it
	/// is replaced.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot be performed because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Headers are transferred across redirects. This can be a security issue. To avoid having headers transferred when a redirect
	/// occurs, use the WINHTTP_STATUS_CALLBACK callback to correct the specific headers when a redirect occurs.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// The <c>WinHttpAddRequestHeaders</c> function appends additional free-format headers to the HTTP request handle and is intended
	/// for use by sophisticated clients that require detailed control over the exact request sent to the HTTP server.
	/// </para>
	/// <para>
	/// The name and value of request headers added with this function are validated. Headers must be well formed. For more information
	/// about valid HTTP headers, see RFC 2616. If an invalid header is used, this function fails and GetLastError returns
	/// ERROR_INVALID_PARAMETER. The invalid header is not added.
	/// </para>
	/// <para>
	/// If you are sending a Date: request header, you can use the WinHttpTimeFromSystemTime function to create structure for the header.
	/// </para>
	/// <para>For basic <c>WinHttpAddRequestHeaders</c>, the application can pass in multiple headers in a single buffer.</para>
	/// <para>An application can also use WinHttpSendRequest to add additional headers to the HTTP request handle before sending a request.</para>
	/// <para><c>Note</c> For more information, see Run-Time Requirements.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example includes an If-Modified-Since header in a request. The response header is interpreted to determine
	/// whether the target document has been updated.
	/// </para>
	/// <para>
	/// <code><![CDATA[DWORD dwSize = sizeof(DWORD);
	/// DWORD dwStatusCode = 0;
	/// BOOL bResults = FALSE;
	/// HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL;
	/// // Use WinHttpOpen to obtain a session handle.
	/// hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0 );
	/// // Specify an HTTP server.
	/// if( hSession )
	/// hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTP_PORT, 0 );
	/// // Create an HTTP Request handle.
	/// if( hConnect )
	/// hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0 );
	/// // Add a request header.
	/// if( hRequest )
	/// bResults = WinHttpAddRequestHeaders( hRequest, L"If-Modified-Since: Mon, 20 Nov 2000 20:00:00 GMT", (ULONG)-1L, WINHTTP_ADDREQ_FLAG_ADD );
	/// // Send a Request.
	/// if( bResults )
	/// bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0 );
	/// // End the request.
	/// if( bResults )
	/// bResults = WinHttpReceiveResponse( hRequest, NULL);
	/// // Use WinHttpQueryHeaders to obtain the header buffer.
	/// if( bResults )
	/// bResults = WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_STATUS_CODE | WINHTTP_QUERY_FLAG_NUMBER, NULL, &amp;dwStatusCode, &amp;dwSize, WINHTTP_NO_HEADER_INDEX );
	/// // Based on the status code, determine whether
	/// // the document was recently updated.
	/// if( bResults ) {
	/// if( dwStatusCode == 304 )
	/// printf( "Document has not been updated.\n" );
	/// else if( dwStatusCode == 200 )
	/// printf( "Document has been updated.\n" );
	/// else
	/// printf( "Status code = %u.\n",dwStatusCode );
	/// }
	/// // Report any errors.
	/// if( !bResults )
	/// printf( "Error %d has occurred.\n", GetLastError( ) );
	/// // Close open handles.
	/// if( hRequest )
	/// WinHttpCloseHandle( hRequest );
	/// if( hConnect )
	/// WinHttpCloseHandle( hConnect );
	/// if( hSession )
	/// WinHttpCloseHandle( hSession );]]></code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpaddrequestheaders BOOL WinHttpAddRequestHeaders( [in]
	// HINTERNET hRequest, [in] LPCWSTR lpszHeaders, [in] DWORD dwHeadersLength, [in] DWORD dwModifiers );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpAddRequestHeaders")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpAddRequestHeaders(HINTERNET hRequest, [MarshalAs(UnmanagedType.LPWStr)] string lpszHeaders, int dwHeadersLength, WINHTTP_ADDREQ_FLAG dwModifiers);

	/// <summary>Adds one or more HTTP request headers to an HTTP request handle, allowing you to use separate name/value strings.</summary>
	/// <param name="hRequest">
	/// <para>Type: IN <c>HINTERNET</c></para>
	/// <para>An <c>HINTERNET</c> handle returned by a call to WinHttpOpenRequest.</para>
	/// </param>
	/// <param name="dwModifiers">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>
	/// An unsigned long integer value that contains the flags used to modify the semantics of this function. Can be one or more of the
	/// following flags.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_ADD</c></term>
	/// <term>Adds the header if it does not exist. Used with <c>WINHTTP_ADDREQ_FLAG_REPLACE</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_ADD_IF_NEW</c></term>
	/// <term>Adds the header only if it does not already exist; otherwise, an error is returned.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_COALESCE</c></term>
	/// <term>Merges headers of the same name.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA</c></term>
	/// <term>
	/// Merges headers of the same name using a comma. For example, adding "Accept: text/*" followed by "Accept: audio/*" with this flag
	/// results in a single header "Accept: text/*, audio/*". This causes the first header found to be merged. The calling application
	/// must to ensure a cohesive scheme with respect to merged and separate headers.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON</c></term>
	/// <term>Merges headers of the same name using a semicolon.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ADDREQ_FLAG_REPLACE</c></term>
	/// <term>
	/// Replaces or removes a header. If the header value is empty and the header is found, it is removed. If the value is not empty, it
	/// is replaced.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: IN <c>ULONGLONG</c></para>
	/// <para>Pass <c>WINHTTP_EXTENDED_HEADER_FLAG_UNICODE</c> to indicate that the strings passed in are Unicode strings.</para>
	/// </param>
	/// <param name="ullExtra">
	/// <para>Type: IN <c>ULONGLONG</c></para>
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="cHeaders">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>The number of elements in pHeaders.</para>
	/// </param>
	/// <param name="pHeaders">
	/// <para>Type: _In_reads_(cHeaders) <c>WINHTTP_EXTENDED_HEADER*</c></para>
	/// <para>An array of <c>WINHTTP_EXTENDED_HEADER</c> structures.</para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation. Among the error codes returned are the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot be performed because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpaddrequestheadersex WINHTTPAPI DWORD
	// WinHttpAddRequestHeadersEx( HINTERNET hRequest, DWORD dwModifiers, ULONGLONG ullFlags, ULONGLONG ullExtra, DWORD cHeaders,
	// WINHTTP_EXTENDED_HEADER *pHeaders );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpAddRequestHeadersEx")]
	public static extern Win32Error WinHttpAddRequestHeadersEx(HINTERNET hRequest, WINHTTP_ADDREQ_FLAG dwModifiers, WINHTTP_EXTENDED_HEADER_FLAG ullFlags,
		[Optional] ulong ullExtra, int cHeaders, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] WINHTTP_EXTENDED_HEADER[] pHeaders);

	/// <summary>
	/// The <c>WinHttpCheckPlatform</c> function determines whether the current platform is supported by this version of Microsoft
	/// Windows HTTP Services (WinHTTP).
	/// </summary>
	/// <returns>
	/// The return value is <c>TRUE</c> if the platform is supported by Microsoft Windows HTTP Services (WinHTTP), or <c>FALSE</c> otherwise.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is useful if your application uses Microsoft Windows HTTP Services (WinHTTP), but also supports platforms that
	/// WinHTTP does not.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// WinHTTP version 5.1 is an operating-system component of Windows 2000 with Service Pack 3 (SP3) and later (except Datacenter
	/// Server), Windows XP with Service Pack 1 (SP1) and later, and Windows Server 2003. In Windows Server 2003, WinHTTP is a system
	/// side-by-side assembly.
	/// </para>
	/// <para>For more information, see Run-Time Requirements.</para>
	/// <para>Examples</para>
	/// <para>The following example shows how to determine whether the current platform is supported.</para>
	/// <para>
	/// <code language="c"> if (WinHttpCheckPlatform( )) printf("This platform is supported by WinHTTP.\n"); else printf("This platform is NOT supported by WinHTTP.\n");</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpcheckplatform BOOL WinHttpCheckPlatform();
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpCheckPlatform")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpCheckPlatform();

	/// <summary>The <c>WinHttpCloseHandle</c> function closes a single <c>HINTERNET</c> handle (see HINTERNET Handles in WinHTTP).</summary>
	/// <param name="hInternet">A valid <c>HINTERNET</c> handle (see HINTERNET Handles in WinHTTP) to be closed.</param>
	/// <returns>
	/// <para>
	/// <c>TRUE</c> if the handle is successfully closed, otherwise <c>FALSE</c>. To get extended error information, call GetLastError.
	/// Among the error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Codes</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_SHUTDOWN</c></term>
	/// <term>The WinHTTP function support is being shut down or unloaded.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// If there is a status callback registered for the handle being closed and the handle was created with a non- <c>NULL</c> context
	/// value, a <c>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</c> callback is made. This is the last callback made from the handle and
	/// indicates that the handle is being destroyed.
	/// </para>
	/// <para>
	/// An application can terminate an in-progress asynchronous request by closing the HINTERNET request handle using
	/// <c>WinHttpCloseHandle</c>. Keep the following points in mind:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// After an application calls <c>WinHttpCloseHandle</c> on a WinHTTP handle, it cannot call any other WinHTTP API functions using
	/// that handle from any thread.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Even after a call to <c>WinHttpCloseHandle</c> returns, the application must still be prepared to receive callbacks for the
	/// closed handle, because WinHTTP can tear down the handle asynchronously. If the asynchronous request was not able to complete
	/// successfully, the callback receives a WINHTTP_CALLBACK_STATUS_REQUEST_ERROR notification.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If an application associates a context data structure or object with the handle, it should maintain that binding until the
	/// callback function receives a <c>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</c> notification. This is the last callback notification
	/// WinHTTP sends prior to deleting a handle object from memory. In order to receive the
	/// <c>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</c> callback notification, the application must enable the
	/// <c>WINHTTP_CALLBACK_FLAG_HANDLES</c> flag in the WinHttpSetStatusCallback call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Before calling <c>WinHttpCloseHandle</c>, an application can call WinHttpSetStatusCallback to indicate that no more callbacks
	/// should be made:
	/// <para>
	/// <code>WinHttpSetStatusCallback( hRequest, NULL, 0, 0 );</code>
	/// </para>
	/// <para>
	/// It might seem that the context data structure could then be freed immediately rather than having to wait for a
	/// <c>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</c> notification, but this is not the case: WinHTTP does not synchronize
	/// WinHttpSetStatusCallback with callbacks originating in worker threads. As a result, a callback could already be in progress from
	/// another thread, and the application could receive a callback notification even after having <c>NULL</c> ed-out the callback
	/// function pointer and deleted the handle's context data structure. Because of this potential race condition, be conservative in
	/// freeing the context structure until after having received the <c>WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING</c> notification.
	/// </para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// An application should never call <c>WinHttpCloseHandle</c> on a synchronous request. This can create a race condition. See
	/// HINTERNET Handles in WinHTTP for more information.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpclosehandle BOOL WinHttpCloseHandle( [in] HINTERNET
	// hInternet );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpCloseHandle")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpCloseHandle(HINTERNET hInternet);

	/// <summary>
	/// The <c>WinHttpConnect</c> function specifies the initial target server of an HTTP request and returns an HINTERNET connection
	/// handle to an HTTP session for that initial target.
	/// </summary>
	/// <param name="hSession">Valid HINTERNET WinHTTP session handle returned by a previous call to WinHttpOpen.</param>
	/// <param name="pswzServerName">
	/// Pointer to a <c>null</c>-terminated string that contains the host name of an HTTP server. Alternately, the string can contain the
	/// IP address of the site in ASCII, for example, 10.0.1.45. Note that WinHttp does not accept international host names without
	/// converting them first to Punycode. For more information, see Handling Internationalized Domain Names (IDNs).
	/// </param>
	/// <param name="nServerPort">
	/// <para>
	/// Unsigned integer that specifies the TCP/IP port on the server to which a connection is made. This parameter can be any valid
	/// TCP/IP port number, or one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description><c>INTERNET_DEFAULT_HTTP_PORT</c></description>
	/// <description>Uses the default port for HTTP servers (port 80).</description>
	/// </item>
	/// <item>
	/// <description><c>INTERNET_DEFAULT_HTTPS_PORT</c></description>
	/// <description>
	/// Uses the default port for HTTPS servers (port 443). Selecting this port does not automatically establish a secure connection. You
	/// must still specify the use of secure transaction semantics by using the WINHTTP_FLAG_SECURE flag with WinHttpOpenRequest.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>INTERNET_DEFAULT_PORT</c></description>
	/// <description>Uses port 80 for HTTP and port 443 for Secure Hypertext Transfer Protocol (HTTPS).</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// Returns a valid connection handle to the HTTP session if the connection is successful, or <c>NULL</c> otherwise. To retrieve
	/// extended error information, call GetLastError. Among the error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Codes</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></description>
	/// <description>The type of handle supplied is incorrect for this operation.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_WINHTTP_INTERNAL_ERROR</c></description>
	/// <description>An internal error has occurred.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_WINHTTP_INVALID_URL</c></description>
	/// <description>The URL is invalid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></description>
	/// <description>
	/// The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_WINHTTP_UNRECOGNIZED_SCHEME</c></description>
	/// <description>The URL scheme could not be recognized, or is not supported.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_WINHTTP_SHUTDOWN</c></description>
	/// <description>The WinHTTP function support is being shut down or unloaded.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_NOT_ENOUGH_MEMORY</c></description>
	/// <description>Not enough memory was available to complete the requested operation. (Windows error code)</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>WinHttpConnect</c>, it must be closed using
	/// the WinHttpCloseHandle function.
	/// </para>
	/// <para>
	/// <c>WinHttpConnect</c> specifies the target HTTP server, however a response can come from another server if the request was
	/// redirected. You can determine the URL of the server sending the response by calling WinHttpQueryOption with the
	/// WINHTTP_OPTION_URL flag.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use secure transaction semantics to download a resource from an HTTPS server. The sample code
	/// initializes the Microsoft Windows HTTP Services (WinHTTP) application programming interface (API), selects a target HTTPS server,
	/// then opens and sends a request for this secure resource. WinHttpQueryDataAvailable is used with the request handle to determine
	/// how much data is available for download, then WinHttpReadData is used to read that data. This process repeats until the entire
	/// document has been retrieved and displayed.
	/// </para>
	/// <para>
	/// <code><![CDATA[DWORD dwSize = sizeof(DWORD);
	/// DWORD dwStatusCode = 0;
	/// BOOL bResults = FALSE;
	/// HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL;
	/// // Use WinHttpOpen to obtain a session handle.
	/// hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0 );
	/// // Specify an HTTP server.
	/// if( hSession )
	/// hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTP_PORT, 0 );
	/// // Create an HTTP Request handle.
	/// if( hConnect )
	/// hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0 );
	/// // Add a request header.
	/// if( hRequest )
	/// bResults = WinHttpAddRequestHeaders( hRequest, L"If-Modified-Since: Mon, 20 Nov 2000 20:00:00 GMT", (ULONG)-1L, WINHTTP_ADDREQ_FLAG_ADD );
	/// // Send a Request.
	/// if( bResults )
	/// bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0 );
	/// // End the request.
	/// if( bResults )
	/// bResults = WinHttpReceiveResponse( hRequest, NULL);
	/// // Use WinHttpQueryHeaders to obtain the header buffer.
	/// if( bResults )
	/// bResults = WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_STATUS_CODE | WINHTTP_QUERY_FLAG_NUMBER, NULL, &amp;dwStatusCode, &amp;dwSize, WINHTTP_NO_HEADER_INDEX );
	/// // Based on the status code, determine whether
	/// // the document was recently updated.
	/// if( bResults ) {
	/// if( dwStatusCode == 304 )
	/// printf( "Document has not been updated.\n" );
	/// else if( dwStatusCode == 200 )
	/// printf( "Document has been updated.\n" );
	/// else
	/// printf( "Status code = %u.\n",dwStatusCode );
	/// }
	/// // Report any errors.
	/// if( !bResults )
	/// printf( "Error %d has occurred.\n", GetLastError( ) );
	/// // Close open handles.
	/// if( hRequest )
	/// WinHttpCloseHandle( hRequest );
	/// if( hConnect )
	/// WinHttpCloseHandle( hConnect );
	/// if( hSession )
	/// WinHttpCloseHandle( hSession );]]></code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpconnect WINHTTPAPI HINTERNET WinHttpConnect( [in]
	// HINTERNET hSession, [in] LPCWSTR pswzServerName, [in] INTERNET_PORT nServerPort, [in] DWORD dwReserved );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpConnect")]
	public static extern SafeHINTERNET WinHttpConnect(HINTERNET hSession, [MarshalAs(UnmanagedType.LPWStr)] string pswzServerName, INTERNET_PORT nServerPort, uint dwReserved = 0);

	/// <summary>The <c>WinHttpCrackUrl</c> function separates a URL into its component parts such as host name and path.</summary>
	/// <param name="pwszUrl">
	/// Pointer to a string that contains the canonical URL to separate. <c>WinHttpCrackUrl</c> does not check this URL for validity or
	/// correct format before attempting to crack it.
	/// </param>
	/// <param name="dwUrlLength">
	/// The length of the <c>pwszUrl</c> string, in characters. If <c>dwUrlLength</c> is set to zero, <c>WinHttpCrackUrl</c> assumes that
	/// the <c>pwszUrl</c> string is <c>null</c> terminated and determines the length of the <c>pwszUrl</c> string based on that assumption.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The flags that control the operation. This parameter can be a combination of one or more of the following flags (values can be
	/// bitwise OR'd together). Or, the parameter can be 0, which performs no special operations.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ICU_DECODE</c></term>
	/// <term>
	/// Converts characters that are "escape encoded" (%xx) to their non-escaped form. This does not decode other encodings, such as
	/// UTF-8. This feature can be used only if the user provides buffers in the URL_COMPONENTS structure to copy the components into.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ICU_ESCAPE</c></term>
	/// <term>
	/// Escapes certain characters to their escape sequences (%xx). Characters to be escaped are non-ASCII characters or those ASCII
	/// characters that must be escaped to be represented in an HTTP request. This feature can be used only if the user provides buffers
	/// in the URL_COMPONENTS structure to copy the components into.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ICU_REJECT_USERPWD</c></term>
	/// <term>
	/// Rejects URLs as input that contain embedded credentials (either a username, a password, or both). If the function fails because
	/// of an invalid URL, then subsequent calls to GetLastError return <c>ERROR_WINHTTP_INVALID_URL</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpUrlComponents">Pointer to a URL_COMPONENTS structure that receives the URL components.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// Among the error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Codes</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INVALID_URL</c></term>
	/// <term>The URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNRECOGNIZED_SCHEME</c></term>
	/// <term>The URL scheme could not be recognized, or is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// The required components are indicated by members of the URL_COMPONENTS structure. Each component has a pointer to the value and
	/// has a member that stores the length of the stored value. If both the value and the length for a component are equal to zero, that
	/// component is not returned. If the pointer to the value of the component is not <c>NULL</c> and the value of its corresponding
	/// length member is nonzero, the address of the first character of the corresponding component in the <c>pwszUrl</c> string is
	/// stored in the pointer, and the length of the component is stored in the length member.
	/// </para>
	/// <para>
	/// If the pointer contains the address of the user-supplied buffer, the length member must contain the size of the buffer. The
	/// <c>WinHttpCrackUrl</c> function copies the component into the buffer, and the length member is set to the length of the copied
	/// component, minus 1 for the trailing string terminator. If a user-supplied buffer is not large enough, <c>WinHttpCrackUrl</c>
	/// returns <c>FALSE</c>, and GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </para>
	/// <para>
	/// For <c>WinHttpCrackUrl</c> to work properly, the size of the URL_COMPONENTS structure must be stored in the dwStructSize member
	/// of that structure.
	/// </para>
	/// <para>
	/// If the Internet protocol of the URL passed in for <c>pwszUrl</c> is not HTTP or HTTPS, then <c>WinHttpCrackUrl</c> returns
	/// <c>FALSE</c> and GetLastError indicates ERROR_WINHTTP_UNRECOGNIZED_SCHEME.
	/// </para>
	/// <para>
	/// <c>WinHttpCrackUrl</c> does not check the validity or format of a URL before attempting to crack it. As a result, if a string
	/// such as ""http://server?Bad=URL"" is passed in, the function returns incorrect results.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>This example shows how to break a URL into its components, update a component, then reconstruct the URL.</para>
	/// <para>
	/// <code> URL_COMPONENTS urlComp; LPCWSTR pwszUrl1 = L"http://search.msn.com/results.asp?RS=CHECKED&amp;FORM=MSNH&amp;v=1&amp;q=wininet"; DWORD dwUrlLen = 0; // Initialize the URL_COMPONENTS structure. ZeroMemory(&amp;urlComp, sizeof(urlComp)); urlComp.dwStructSize = sizeof(urlComp); // Set required component lengths to non-zero // so that they are cracked. urlComp.dwSchemeLength = (DWORD)-1; urlComp.dwHostNameLength = (DWORD)-1; urlComp.dwUrlPathLength = (DWORD)-1; urlComp.dwExtraInfoLength = (DWORD)-1; // Crack the URL. if (!WinHttpCrackUrl( pwszUrl1, (DWORD)wcslen(pwszUrl1), 0, &amp;urlComp)) { printf("Error %u in WinHttpCrackUrl.\n", GetLastError()); } else { // Change the search information. // New info is the same length. urlComp.lpszExtraInfo = L"?RS=CHECKED&amp;FORM=MSNH&amp;v=1&amp;q=winhttp"; // Obtain the size of the new URL and allocate memory. WinHttpCreateUrl( &amp;urlComp, 0, NULL, &amp;dwUrlLen); PWSTR pwszUrl2 = new WCHAR[dwUrlLen]; // Create a new URL. if(!WinHttpCreateUrl( &amp;urlComp, 0, pwszUrl2, &amp;dwUrlLen)) { printf("Error %u in WinHttpCreateUrl.\n", GetLastError()); } else { // Show both URLs. printf("Old URL: %S\nNew URL: %S\n", pwszUrl1, pwszUrl2); } // Free allocated memory. delete [] pwszUrl2; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpcrackurl BOOL WinHttpCrackUrl( [in] LPCWSTR pwszUrl,
	// [in] DWORD dwUrlLength, [in] DWORD dwFlags, [in, out] LPURL_COMPONENTS lpUrlComponents );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpCrackUrl")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpCrackUrl([MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [Optional] uint dwUrlLength, ICU dwFlags, ref WINHTTP_URL_COMPONENTS lpUrlComponents);

	/// <summary>The <c>WinHttpCreateProxyResolver</c> function creates a handle for use by WinHttpGetProxyForUrlEx.</summary>
	/// <param name="hSession">
	/// Valid HINTERNET WinHTTP session handle returned by a previous call to WinHttpOpen. The session handle must be opened using <c>WINHTTP_FLAG_ASYNC</c>.
	/// </param>
	/// <param name="phResolver">
	/// A pointer to a new handle for use by WinHttpGetProxyForUrlEx. When finished or cancelling an outstanding operation, close this
	/// handle with WinHttpCloseHandle.
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>The following codes may be returned.</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term><c>hSession</c> is NULL.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term><c>hSession</c> is not the result of a call to WinHttpOpen or <c>hSession</c> is not marked as asynchronous using <c>WINHTTP_FLAG_ASYNC</c>.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpcreateproxyresolver WINHTTPAPI DWORD
	// WinHttpCreateProxyResolver( [in] HINTERNET hSession, [out] HINTERNET *phResolver );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpCreateProxyResolver")]
	public static extern Win32Error WinHttpCreateProxyResolver(HINTERNET hSession, out SafeHINTERNET phResolver);

	/// <summary>The <c>WinHttpCreateUrl</c> function creates a URL from component parts such as the host name and path.</summary>
	/// <param name="lpUrlComponents">Pointer to a URL_COMPONENTS structure that contains the components from which to create the URL.</param>
	/// <param name="dwFlags">
	/// <para>Flags that control the operation of this function. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ICU_ESCAPE</c></term>
	/// <term>
	/// Converts all unsafe characters to their corresponding escape sequences in the path string pointed to by the <c>lpszUrlPath</c>
	/// member and in <c>lpszExtraInfo</c> the extra-information string pointed to by the member of the URL_COMPONENTS structure pointed
	/// to by the <c>lpUrlComponents</c> parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ICU_REJECT_USERPWD</c></term>
	/// <term>
	/// Rejects URLs as input that contains either a username, or a password, or both. If the function fails because of an invalid URL,
	/// subsequent calls to GetLastError will return ERROR_WINHTTP_INVALID_URL.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pwszUrl">Pointer to a character buffer that receives the URL as a wide character (Unicode) string.</param>
	/// <param name="pdwUrlLength">
	/// Pointer to a variable of type unsigned long integer that receives the length of the <c>pwszUrl</c> buffer in wide (Unicode)
	/// characters. When the function returns, this parameter receives the length of the URL string wide in characters, minus 1 for the
	/// terminating character. If GetLastError returns ERROR_INSUFFICIENT_BUFFER, this parameter receives the number of wide characters
	/// required to hold the created URL.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error data, call GetLastError. Among the
	/// error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Insufficient memory available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode, that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen, this
	/// function operates synchronously. The return value indicates success or failure. To get extended error data, call GetLastError.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to decompile, or crack, a URL into its subcomponents, update a component, then reconstruct the URL.
	/// </para>
	/// <para>
	/// <code> URL_COMPONENTS urlComp; LPCWSTR pwszUrl1 = L"http://search.msn.com/results.asp?RS=CHECKED&amp;FORM=MSNH&amp;v=1&amp;q=wininet"; DWORD dwUrlLen = 0; // Initialize the URL_COMPONENTS structure. ZeroMemory(&amp;urlComp, sizeof(urlComp)); urlComp.dwStructSize = sizeof(urlComp); // Set required component lengths to non-zero, // so that they are cracked. urlComp.dwSchemeLength = (DWORD)-1; urlComp.dwHostNameLength = (DWORD)-1; urlComp.dwUrlPathLength = (DWORD)-1; urlComp.dwExtraInfoLength = (DWORD)-1; // Crack the URL. if (!WinHttpCrackUrl( pwszUrl1, (DWORD)wcslen(pwszUrl1), 0, &amp;urlComp)) { printf("Error %u in WinHttpCrackUrl.\n", GetLastError()); } else { // Change the search data. New data is the same length. urlComp.lpszExtraInfo = L"?RS=CHECKED&amp;FORM=MSNH&amp;v=1&amp;q=winhttp"; // Obtain the size of the new URL and allocate memory. WinHttpCreateUrl( &amp;urlComp, 0, NULL, &amp;dwUrlLen); PWSTR pwszUrl2 = new WCHAR[dwUrlLen]; // Create a new URL. if(!WinHttpCreateUrl( &amp;urlComp, 0, pwszUrl2, &amp;dwUrlLen)) { printf( "Error %u in WinHttpCreateUrl.\n", GetLastError()); } else { // Show both URLs. printf( "Old URL: %S\nNew URL: %S\n", pwszUrl1, pwszUrl2); } // Free allocated memory. delete [] pwszUrl2; }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpcreateurl BOOL WinHttpCreateUrl( [in]
	// LPURL_COMPONENTS lpUrlComponents, [in] DWORD dwFlags, [out] PWSTR pwszUrl, [in, out] LPDWORD pdwUrlLength );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpCreateUrl")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpCreateUrl(in WINHTTP_URL_COMPONENTS_IN lpUrlComponents, ICU dwFlags,
		[Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? pwszUrl, ref uint pdwUrlLength);

	/// <summary>
	/// The <c>WinHttpDetectAutoProxyConfigUrl</c> function finds the URL for the Proxy Auto-Configuration (PAC) file. This function
	/// reports the URL of the PAC file, but it does not download the file.
	/// </summary>
	/// <param name="dwAutoDetectFlags">
	/// <para>
	/// A data type that specifies what protocols to use to locate the PAC file. If both the DHCP and DNS auto detect flags are set, DHCP
	/// is used first; if no PAC URL is discovered using DHCP, then DNS is used.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_AUTO_DETECT_TYPE_DHCP</c></term>
	/// <term>Use DHCP to locate the proxy auto-configuration file.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTO_DETECT_TYPE_DNS_A</c></term>
	/// <term>Use DNS to attempt to locate the proxy auto-configuration file at a well-known location on the domain of the local computer.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppwstrAutoConfigUrl">
	/// A data type that returns a pointer to a null-terminated Unicode string that contains the configuration URL that receives the
	/// proxy data. You must free the string pointed to by <c>ppwszAutoConfigUrl</c> using the GlobalFree function.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_AUTODETECTION_FAILED</c></term>
	/// <term>Returned if WinHTTP was unable to discover the URL of the Proxy Auto-Configuration (PAC) file.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// WinHTTP implements the Web Proxy Auto-Discovery (WPAD) protocol, often referred to as <c>autoproxy</c>. For more information
	/// about well-known locations, see the Discovery Process section of the WPAD protocol document.
	/// </para>
	/// <para>
	/// Note that because the <c>WinHttpDetectAutoProxyConfigUrl</c> function takes time to complete its operation, it should not be
	/// called from a UI thread.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpdetectautoproxyconfigurl BOOL
	// WinHttpDetectAutoProxyConfigUrl( [in] DWORD dwAutoDetectFlags, [out] PWSTR *ppwstrAutoConfigUrl );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpDetectAutoProxyConfigUrl")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpDetectAutoProxyConfigUrl(WINHTTP_AUTO_DETECT_TYPE dwAutoDetectFlags, out SafeHGlobalHandle ppwstrAutoConfigUrl);

	/// <summary>The <c>WinHttpFreeProxyResult</c> function frees the data retrieved from a previous call to <see cref="WinHttpGetProxyResult"/>.</summary>
	/// <param name="pProxyResult">A pointer to a WINHTTP_PROXY_RESULT structure retrieved from a previous call to WinHttpGetProxyResult.</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// Upon completion, all internal members of <c>pProxyResult</c> will be zeroed and the memory allocated to those members will be
	/// freed. If <c>pProxyResult</c> is an allocated pointer, the caller must free the pointer.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpfreeproxyresult WINHTTPAPI VOID
	// WinHttpFreeProxyResult( [in, out] WINHTTP_PROXY_RESULT *pProxyResult );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpFreeProxyResult")]
	public static extern void WinHttpFreeProxyResult(ref WINHTTP_PROXY_RESULT pProxyResult);

	/// <summary>Frees the memory allocated by a previous call to WinHttpQueryConnectionGroup.</summary>
	/// <param name="pResult">
	/// <para>Type: _Inout_ <c>WINHTTP_QUERY_CONNECTION_GROUP_RESULT*</c></para>
	/// <para>A pointer to the WINHTTP_QUERY_CONNECTION_GROUP_RESULT object to free.</para>
	/// </param>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpfreequeryconnectiongroupresult WINHTTPAPI VOID
	// WinHttpFreeQueryConnectionGroupResult( WINHTTP_QUERY_CONNECTION_GROUP_RESULT *pResult );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpFreeQueryConnectionGroupResult")]
	public static extern void WinHttpFreeQueryConnectionGroupResult(IntPtr pResult);

	/// <summary>
	/// The <c>WinHttpGetDefaultProxyConfiguration</c> function retrieves the default WinHTTP proxy configuration from the registry.
	/// </summary>
	/// <param name="pProxyInfo">A pointer to a variable of type WINHTTP_PROXY_INFO that receives the default proxy configuration.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful or <c>FALSE</c> otherwise. To retrieve a specific error message, call GetLastError. Error codes
	/// returned include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinHttpGetDefaultProxyConfiguration</c> retrieves the proxy configuration set by WinHttpSetDefaultProxyConfiguration or ProxyCfg.exe.
	/// </para>
	/// <para>
	/// The default proxy configuration can be overridden for a WinHTTP session by calling WinHttpSetOption and specifying the
	/// WINHTTP_OPTION_PROXY flag. <c>WinHttpGetDefaultProxyConfiguration</c> does not retrieve the configuration for the current
	/// session. It retrieves the configuration specified in the registry.
	/// </para>
	/// <para>
	/// If the registry contains a list of proxy servers, the <c>dwAccessType</c> member of <c>pProxyInfo</c> is set to
	/// <c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c>. Otherwise, it is set to <c>WINHTTP_ACCESS_TYPE_NO_PROXY</c>.
	/// </para>
	/// <para>
	/// <c>WinHttpGetDefaultProxyConfiguration</c> allocates memory for the string members of <c>pProxyInfo</c>. To free this memory,
	/// call GlobalFree.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP Start Page.</para>
	/// <para>Examples</para>
	/// <para>The following code example shows how to retrieve the default proxy configuration from the registry.</para>
	/// <para>
	/// <code> WINHTTP_PROXY_INFO proxyInfo; // Retrieve the default proxy configuration. WinHttpGetDefaultProxyConfiguration( &amp;proxyInfo ); // Display the proxy servers and free memory // allocated to this string. if (proxyInfo.lpszProxy != NULL) { printf("Proxy server list: %S\n", proxyInfo.lpszProxy); GlobalFree( proxyInfo.lpszProxy ); } // Display the bypass list and free memory // allocated to this string. if (proxyInfo.lpszProxyBypass != NULL) { printf("Proxy bypass list: %S\n", proxyInfo.lpszProxyBypass); GlobalFree( proxyInfo.lpszProxyBypass ); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetdefaultproxyconfiguration WINHTTPAPI BOOL
	// WinHttpGetDefaultProxyConfiguration( [in, out] WINHTTP_PROXY_INFO *pProxyInfo );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetDefaultProxyConfiguration")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpGetDefaultProxyConfiguration(out WINHTTP_PROXY_INFO pProxyInfo);

	/// <summary>
	/// The <c>WinHttpGetIEProxyConfigForCurrentUser</c> function retrieves the Internet Explorer proxy configuration for the current user.
	/// </summary>
	/// <param name="pProxyConfig">
	/// A pointer, on input, to a WINHTTP_CURRENT_USER_IE_PROXY_CONFIG structure. On output, the structure contains the Internet Explorer
	/// proxy settings for the current active network connection (for example, LAN, dial-up, or VPN connection).
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>No Internet Explorer proxy settings can be found.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In Internet Explorer, the proxy settings are found on the <c>Connections</c> tab of the <c>Tools</c> / <c>Internet Options</c>
	/// menu option. Proxy settings are configured on a per-connection basis; that is, the proxy settings for a LAN connection are
	/// separate from those for a dial-up or VPN connection. <c>WinHttpGetIEProxyConfigForCurrentUser</c> returns the proxy settings for
	/// the current active connection.
	/// </para>
	/// <para>
	/// This function is useful in client applications running in network environments in which the Web Proxy Auto-Discovery (WPAD)
	/// protocol is not implemented (meaning that no Proxy Auto-Configuration file is available). If a PAC file is not available, then
	/// the WinHttpGetProxyForUrl function fails. The <c>WinHttpGetIEProxyConfigForCurrentUser</c> function can be used as a fall-back
	/// mechanism to discover a workable proxy configuration by retrieving the user's proxy configuration in Internet Explorer.
	/// </para>
	/// <para>
	/// This function should not be used in a service process that does not impersonate a logged-on user.If the caller does not
	/// impersonate a logged on user, WinHTTP attempts to retrieve the Internet Explorer settings for the current service process: for
	/// example, the local service or the network service. If the Internet Explorer settings are not configured for these system
	/// accounts, the call to <c>WinHttpGetIEProxyConfigForCurrentUser</c> will fail.
	/// </para>
	/// <para>
	/// The caller must free the <c>lpszProxy</c>, <c>lpszProxyBypass</c> and <c>lpszAutoConfigUrl</c> strings in the
	/// WINHTTP_CURRENT_USER_IE_PROXY_CONFIG structure if they are non- <c>NULL</c>. Use GlobalFree to free the strings.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetieproxyconfigforcurrentuser BOOL
	// WinHttpGetIEProxyConfigForCurrentUser( [in, out] WINHTTP_CURRENT_USER_IE_PROXY_CONFIG *pProxyConfig );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetIEProxyConfigForCurrentUser")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpGetIEProxyConfigForCurrentUser(out WINHTTP_CURRENT_USER_IE_PROXY_CONFIG pProxyConfig);

	/// <summary>The <c>WinHttpGetProxyForUrl</c> function retrieves the proxy data for the specified URL.</summary>
	/// <param name="hSession">The WinHTTP session handle returned by the WinHttpOpen function.</param>
	/// <param name="lpcwszUrl">
	/// A pointer to a null-terminated Unicode string that contains the URL of the HTTP request that the application is preparing to send.
	/// </param>
	/// <param name="pAutoProxyOptions">
	/// A pointer to a WINHTTP_AUTOPROXY_OPTIONS structure that specifies the auto-proxy options to use.
	/// </param>
	/// <param name="pProxyInfo">
	/// A pointer to a WINHTTP_PROXY_INFO structure that receives the proxy setting. This structure is then applied to the request handle
	/// using the WINHTTP_OPTION_PROXY option. Free the <c>lpszProxy</c> and <c>lpszProxyBypass</c> strings contained in this structure
	/// (if they are non-NULL) using the GlobalFree function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error data, call GetLastError.</para>
	/// <para>Possible error codes include the folllowing.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_AUTO_PROXY_SERVICE_ERROR</c></term>
	/// <term>Returned by WinHttpGetProxyForUrl when a proxy for the specified URL cannot be located.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_BAD_AUTO_PROXY_SCRIPT</c></term>
	/// <term>An error occurred executing the script code in the Proxy Auto-Configuration (PAC) file.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INVALID_URL</c></term>
	/// <term>The URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_LOGIN_FAILURE</c></term>
	/// <term>
	/// The login attempt failed. When this error is encountered, close the request handle with WinHttpCloseHandle. A new request handle
	/// must be created before retrying the function that originally produced this error.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>
	/// The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNABLE_TO_DOWNLOAD_SCRIPT</c></term>
	/// <term>
	/// The PAC file could not be downloaded. For example, the server referenced by the PAC URL may not have been reachable, or the
	/// server returned a 404 NOT FOUND response.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNRECOGNIZED_SCHEME</c></term>
	/// <term>The URL of the PAC file specified a scheme other than "http:" or "https:".</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function implements the Web Proxy Auto-Discovery (WPAD) protocol for automatically configuring the proxy settings for an
	/// HTTP request. The WPAD protocol downloads a Proxy Auto-Configuration (PAC) file, which is a script that identifies the proxy
	/// server to use for a given target URL. PAC files are typically deployed by the IT department within a corporate network
	/// environment. The URL of the PAC file can either be specified explicitly or <c>WinHttpGetProxyForUrl</c> can be instructed to
	/// automatically discover the location of the PAC file on the local network.
	/// </para>
	/// <para><c>WinHttpGetProxyForUrl</c> supports only ECMAScript-based PAC files.</para>
	/// <para>
	/// <c>WinHttpGetProxyForUrl</c> must be called on a per-URL basis, because the PAC file can return a different proxy server for
	/// different URLs. This is useful because the PAC file enables an IT department to implement proxy server load balancing by mapping
	/// (hashing) the target URL (specified by the <c>lpcwszUrl</c> parameter) to a certain proxy in a proxy server array.
	/// </para>
	/// <para>
	/// <c>WinHttpGetProxyForUrl</c> caches the autoproxy URL and the autoproxy script when auto-discovery is specified in the
	/// <c>dwFlags</c> member of the <c>pAutoProxyOptions</c> structure. For more information, see Autoproxy Cache.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxyforurl BOOL WinHttpGetProxyForUrl( [in]
	// HINTERNET hSession, [in] LPCWSTR lpcwszUrl, [in] WINHTTP_AUTOPROXY_OPTIONS *pAutoProxyOptions, [out] WINHTTP_PROXY_INFO
	// *pProxyInfo );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxyForUrl")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpGetProxyForUrl(HINTERNET hSession, [MarshalAs(UnmanagedType.LPWStr)] string lpcwszUrl,
		in WINHTTP_AUTOPROXY_OPTIONS pAutoProxyOptions, out WINHTTP_PROXY_INFO pProxyInfo);

	/// <summary>The <c>WinHttpGetProxyForUrlEx</c> function retrieves the proxy data for the specified URL.</summary>
	/// <param name="hResolver">The WinHTTP resolver handle returned by the WinHttpCreateProxyResolver function.</param>
	/// <param name="pcwszUrl">
	/// A pointer to a null-terminated Unicode string that contains a URL for which proxy information will be determined.
	/// </param>
	/// <param name="pAutoProxyOptions">
	/// A pointer to a WINHTTP_AUTOPROXY_OPTIONS structure that specifies the auto-proxy options to use.
	/// </param>
	/// <param name="pContext">Context data that will be passed to the completion callback function.</param>
	/// <returns>
	/// <para>A status code indicating the result of the operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>The following codes may be returned.</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>The operation is continuing asynchronously.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_AUTO_PROXY_SERVICE_ERROR</c></term>
	/// <term>Returned by WinHttpGetProxyForUrlEx when a proxy for the specified URL cannot be located.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_BAD_AUTO_PROXY_SCRIPT</c></term>
	/// <term>An error occurred executing the script code in the Proxy Auto-Configuration (PAC) file.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INVALID_URL</c></term>
	/// <term>The URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>
	/// The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNABLE_TO_DOWNLOAD_SCRIPT</c></term>
	/// <term>
	/// The PAC file could not be downloaded. For example, the server referenced by the PAC URL may not have been reachable, or the
	/// server returned a 404 NOT FOUND response.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNRECOGNIZED_SCHEME</c></term>
	/// <term>The URL of the PAC file specified a scheme other than "http:" or "https:".</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function implements the Web Proxy Auto-Discovery (WPAD) protocol for automatically configuring the proxy settings for an
	/// HTTP request. The WPAD protocol downloads a Proxy Auto-Configuration (PAC) file, which is a script that identifies the proxy
	/// server to use for a given target URL. PAC files are typically deployed by the IT department within a corporate network
	/// environment. The URL of the PAC file can either be specified explicitly or <c>WinHttpGetProxyForUrlEx</c> can be instructed to
	/// automatically discover the location of the PAC file on the local network.
	/// </para>
	/// <para><c>WinHttpGetProxyForUrlEx</c> supports only ECMAScript-based PAC files.</para>
	/// <para>
	/// <c>WinHttpGetProxyForUrlEx</c> must be called on a per-URL basis, because the PAC file can return a different proxy server for
	/// different URLs. This is useful because the PAC file enables an IT department to implement proxy server load balancing by mapping
	/// (hashing) the target URL (specified by the <c>lpcwszUrl</c> parameter) to a certain proxy in a proxy server array.
	/// </para>
	/// <para>
	/// <c>WinHttpGetProxyForUrlEx</c> caches the autoproxy URL and the autoproxy script when auto-discovery is specified in the
	/// <c>dwFlags</c> member of the <c>pAutoProxyOptions</c> structure. For more information, see Autoproxy Cache.
	/// </para>
	/// <para>
	/// <c>WinHttpGetProxyForUrlEx</c> provides a fully Asynchronous and cancellable API that WinHttpGetProxyForUrl does not.
	/// <c>WinHttpGetProxyForUrlEx</c> also provides the application with the full proxy list that was returned by the PAC script
	/// allowing the application to better handle failover to "DIRECT" and to understand SOCKS if desired.
	/// </para>
	/// <para>
	/// <c>WinHttpGetProxyForUrlEx</c> always executes asynchronously and returns immediately with <c>ERROR_IO_PENDING</c> on success.
	/// The callback is set by calling WinHttpSetStatusCallback on the <c>hSession</c> provided by WinHttpOpen. Alternately call
	/// <c>WinHttpSetStatusCallback</c> on the <c>hResolver</c> provided by WinHttpCreateProxyResolver to have a specific callback for
	/// each call.
	/// </para>
	/// <para>
	/// You must call WinHttpSetStatusCallback before WinHttpCreateProxyResolver. When calling <c>WinHttpSetStatusCallback</c>, use
	/// <c>WINHTTP_CALLBACK_FLAG_REQUEST_ERROR | WINHTTP_CALLBACK_FLAG_GETPROXYFORURL_COMPLETE</c>. See WINHTTP_STATUS_CALLBACK for
	/// information on the use of the callback.
	/// </para>
	/// <para>
	/// Once a callback of status <c>WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE</c> is returned, the application can call
	/// WinHttpGetProxyResult on the resolver handle used to issue <c>WinHttpGetProxyForUrlEx</c> to receive the results of that call.
	/// </para>
	/// <para>
	/// If the call fails after returning <c>ERROR_IO_PENDING</c> then a callback of <c>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</c> will be issued.
	/// </para>
	/// <para>This function always executes out-of-process.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxyforurlex WINHTTPAPI DWORD
	// WinHttpGetProxyForUrlEx( [in] HINTERNET hResolver, [in] PCWSTR pcwszUrl, [in] WINHTTP_AUTOPROXY_OPTIONS *pAutoProxyOptions, [in]
	// DWORD_PTR pContext );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxyForUrlEx")]
	public static extern Win32Error WinHttpGetProxyForUrlEx(HINTERNET hResolver, [MarshalAs(UnmanagedType.LPWStr)] string pcwszUrl,
		in WINHTTP_AUTOPROXY_OPTIONS pAutoProxyOptions, [In, Optional] IntPtr pContext);

	/// <summary>The <c>WinHttpGetProxyResult</c> function retrieves the results of a call to WinHttpGetProxyForUrlEx.</summary>
	/// <param name="hResolver">The resolver handle used to issue a previously completed call to WinHttpGetProxyForUrlEx.</param>
	/// <param name="pProxyResult">
	/// A pointer to a WINHTTP_PROXY_RESULT structure that contains the results of a previous call to WinHttpGetProxyForUrlEx. The
	/// results must be freed by calling WinHttpFreeProxyResult.
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>The following codes may be returned.</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The resolver handle has not successfully completed a call to WinHttpGetProxyForUrlEx.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxyresult WINHTTPAPI DWORD
	// WinHttpGetProxyResult( [in] HINTERNET hResolver, [out] WINHTTP_PROXY_RESULT *pProxyResult );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxyResult")]
	public static extern Win32Error WinHttpGetProxyResult(HINTERNET hResolver, out WINHTTP_PROXY_RESULT pProxyResult);

	/// <summary>
	/// The <c>WinHttpOpen</c> function initializes, for an application, the use of WinHTTP functions and returns a WinHTTP-session handle.
	/// </summary>
	/// <param name="pszAgentW">
	/// A pointer to a string variable that contains the name of the application or entity calling the WinHTTP functions. This name is
	/// used as the user agent in the HTTP protocol.
	/// </param>
	/// <param name="dwAccessType">
	/// <para>Type of access required. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_ACCESS_TYPE_NO_PROXY</c></term>
	/// <term>Resolves all host names directly without a proxy.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c></term>
	/// <term>
	/// Retrieves the static proxy or direct configuration from the registry. <c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c> does not inherit
	/// browser proxy settings. The WinHTTP proxy configuration is set by one of these mechanisms.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c></term>
	/// <term>
	/// Passes requests to the proxy unless a proxy bypass list is supplied and the name to be resolved bypasses the proxy. In this case,
	/// this function uses the values passed for <c>pwszProxyName</c> and <c>pwszProxyBypass</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_ACCESS_TYPE_AUTOMATIC_PROXY</c></term>
	/// <term>
	/// Uses system and per-user proxy settings (including the Internet Explorer proxy configuration) to determine which proxy/proxies to
	/// use. Automatically attempts to handle failover between multiple proxies, different proxy configurations per interface, and
	/// authentication. Supported in Windows 8.1 and newer.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszProxyW">
	/// A pointer to a string variable that contains the name of the proxy server to use when proxy access is specified by setting
	/// <c>dwAccessType</c> to <c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c>. The WinHTTP functions recognize only CERN type proxies for HTTP.
	/// If <c>dwAccessType</c> is not set to <c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c>, this parameter must be set to <c>WINHTTP_NO_PROXY_NAME</c>.
	/// </param>
	/// <param name="pszProxyBypassW">
	/// A pointer to a string variable that contains an optional semicolon delimited list of host names or IP addresses, or both, that
	/// should not be routed through the proxy when <c>dwAccessType</c> is set to <c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c>. The list can
	/// contain wildcard characters. Do not use an empty string, because the <c>WinHttpOpen</c> function uses it as the proxy bypass
	/// list. If this parameter specifies the "&lt;local&gt;" macro in the list as the only entry, this function bypasses any host name
	/// that does not contain a period. If <c>dwAccessType</c> is not set to <c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c>, this parameter must
	/// be set to <c>WINHTTP_NO_PROXY_BYPASS</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Unsigned long integer value that contains the flags that indicate various options affecting the behavior of this function. This
	/// parameter can have the following value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_FLAG_ASYNC</c></term>
	/// <term>
	/// Use the WinHTTP functions asynchronously. By default, all WinHTTP functions that use the returned HINTERNET handle are performed
	/// synchronously. When this flag is set, the caller needs to specify a callback function through WinHttpSetStatusCallback.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_SECURE_DEFAULTS</c></term>
	/// <term>
	/// When this flag is set, WinHttp will require use of TLS 1.2 or newer. If the caller attempts to enable older TLS versions by
	/// setting <c>WINHTTP_OPTION_SECURE_PROTOCOLS</c>, it will fail with <c>ERROR_ACCESS_DENIED</c>. Additionally, TLS fallback will be
	/// disabled. Note that setting this flag also sets flag <c>WINHTTP_FLAG_ASYNC</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a valid session handle if successful, or <c>NULL</c> otherwise. To retrieve extended error information, call
	/// GetLastError. Among the error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// We strongly recommend that you use WinHTTP in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in
	/// <c>WinHttpOpen</c>, so that usage of the returned HINTERNET become asynchronous). The return value indicates success or failure.
	/// To retrieve extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// The <c>WinHttpOpen</c> function is the first of the WinHTTP functions called by an application. It initializes internal WinHTTP
	/// data structures and prepares for future calls from the application. When the application finishes using the WinHTTP functions, it
	/// must call WinHttpCloseHandle to free the session handle and any associated resources.
	/// </para>
	/// <para>
	/// The application can make any number of calls to <c>WinHttpOpen</c>, though a single call is normally sufficient. Each call to
	/// <c>WinHttpOpen</c> opens a new session context. Because user data is not shared between multiple session contexts, an application
	/// that makes requests on behalf of multiple users should create a separate session for each user, so as not to share user-specific
	/// cookies and authentication state. The application should define separate behaviors for each <c>WinHttpOpen</c> instance, such as
	/// different proxy servers configured for each.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>WinHttpOpen</c>, it must be closed using the
	/// WinHttpCloseHandle function.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see Run-Time Requirements.</para>
	/// <para>Examples</para>
	/// <para>The following example code shows how to retrieve the default connection time-out value.</para>
	/// <para>
	/// <code> DWORD data; DWORD dwSize = sizeof(DWORD); // Use WinHttpOpen to obtain an HINTERNET handle. HINTERNET hSession = WinHttpOpen(L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); if (hSession) { // Use WinHttpQueryOption to retrieve internet options. if (WinHttpQueryOption( hSession, WINHTTP_OPTION_CONNECT_TIMEOUT, &amp;data, &amp;dwSize)) { printf("Connection timeout: %u ms\n\n",data); } else { printf( "Error %u in WinHttpQueryOption.\n", GetLastError()); } // When finished, release the HINTERNET handle. WinHttpCloseHandle(hSession); } else { printf("Error %u in WinHttpOpen.\n", GetLastError()); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpopen WINHTTPAPI HINTERNET WinHttpOpen( [in, optional]
	// LPCWSTR pszAgentW, [in] DWORD dwAccessType, [in] LPCWSTR pszProxyW, [in] LPCWSTR pszProxyBypassW, [in] DWORD dwFlags );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpOpen")]
	public static extern SafeHINTERNET WinHttpOpen([Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszAgentW, [Optional] WINHTTP_ACCESS_TYPE dwAccessType,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszProxyW, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pszProxyBypassW, [Optional] WINHTTP_OPEN_FLAG dwFlags);

	/// <summary>The <c>WinHttpOpenRequest</c> function creates an HTTP request handle.</summary>
	/// <param name="hConnect">HINTERNET connection handle to an HTTP session returned by WinHttpConnect.</param>
	/// <param name="pwszVerb">
	/// Pointer to a string that contains the HTTP verb to use in the request. If this parameter is <c>NULL</c>, the function uses GET as
	/// the <c>HTTP verb</c>. <c>Note</c> This string should be all uppercase. Many servers treat HTTP verbs as case-sensitive, and the
	/// Internet Engineering Task Force (IETF) Requests for Comments (RFCs) spell these verbs using uppercase characters only.
	/// </param>
	/// <param name="pwszObjectName">
	/// Pointer to a string that contains the name of the target resource of the specified HTTP verb. This is generally a file name, an
	/// executable module, or a search specifier.
	/// </param>
	/// <param name="pwszVersion">
	/// Pointer to a string that contains the HTTP version. If this parameter is <c>NULL</c>, the function uses HTTP/1.1.
	/// </param>
	/// <param name="pwszReferrer">
	/// Pointer to a string that specifies the URL of the document from which the URL in the request <c>pwszObjectName</c> was obtained.
	/// If this parameter is set to <c>WINHTTP_NO_REFERER</c>, no referring document is specified.
	/// </param>
	/// <param name="ppwszAcceptTypes">
	/// Pointer to a <c>null</c>-terminated array of string pointers that specifies media types accepted by the client. If this parameter
	/// is set to <c>WINHTTP_DEFAULT_ACCEPT_TYPES</c>, no types are accepted by the client. Typically, servers handle a lack of accepted
	/// types as indication that the client accepts only documents of type "text/*"; that is, only text documents—no pictures or other
	/// binary files. For a list of valid media types, see Media Types defined by IANA at http://www.iana.org/assignments/media-types/.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Unsigned long integer value that contains the Internet flag values. This can be one or more of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_FLAG_BYPASS_PROXY_CACHE</c></term>
	/// <term>This flag provides the same behavior as <c>WINHTTP_FLAG_REFRESH</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_ESCAPE_DISABLE</c></term>
	/// <term>Unsafe characters in the URL passed in for <c>pwszObjectName</c> are not converted to escape sequences.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_ESCAPE_DISABLE_QUERY</c></term>
	/// <term>Unsafe characters in the query component of the URL passed in for <c>pwszObjectName</c> are not converted to escape sequences.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_ESCAPE_PERCENT</c></term>
	/// <term>
	/// The string passed in for <c>pwszObjectName</c> is converted from an <c>LPCWSTR</c> to an <c>PSTR</c>. All unsafe characters are
	/// converted to an escape sequence including the percent symbol. By default, all unsafe characters except the percent symbol are
	/// converted to an escape sequence.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_NULL_CODEPAGE</c></term>
	/// <term>
	/// The string passed in for <c>pwszObjectName</c> is assumed to consist of valid ANSI characters represented by <c>WCHAR</c>. No
	/// check are done for unsafe characters. <c>Windows 7:</c> This option is obsolete.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_REFRESH</c></term>
	/// <term>
	/// Indicates that the request should be forwarded to the originating server rather than sending a cached version of a resource from
	/// a proxy server. When this flag is used, a "Pragma: no-cache" header is added to the request handle. When creating an HTTP/1.1
	/// request header, a "Cache-Control: no-cache" is also added.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_FLAG_SECURE</c></term>
	/// <term>Uses secure transaction semantics. This translates to using Secure Sockets Layer (SSL)/Transport Layer Security (TLS).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a valid HTTP request handle if successful, or <c>NULL</c> if not. For extended error information, call GetLastError.
	/// Among the error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INVALID_URL</c></term>
	/// <term>The URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>
	/// The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNRECOGNIZED_SCHEME</c></term>
	/// <term>The URL specified a scheme other than "http:" or "https:".</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The return value indicates success or failure. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The <c>WinHttpOpenRequest</c> function creates a new HTTP request handle and stores the specified parameters in that handle. An
	/// HTTP request handle holds a request to send to an HTTP server and contains all RFC822/MIME/HTTP headers to be sent as part of the request.
	/// </para>
	/// <para>If <c>pwszVerb</c> is set to "HEAD", the Content-Length header is ignored.</para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then a
	/// <c>WINHTTP_CALLBACK_STATUS_HANDLE_CREATED</c> notification indicates that <c>WinHttpOpenRequest</c> has created a request handle.
	/// </para>
	/// <para>
	/// After the calling application finishes using the HINTERNET handle returned by <c>WinHttpOpenRequest</c>, it must be closed using
	/// the WinHttpCloseHandle function.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// This example shows how to obtain an HINTERNET handle, open an HTTP session, create a request header, and send that header to the server.
	/// </para>
	/// <para>
	/// <code> BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.wingtiptoys.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP Request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"PUT", L"/writetst.txt", NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a Request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // PLACE ADDITIONAL CODE HERE. // Report any errors. if (!bResults) printf( "Error %d has occurred.\n", GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpopenrequest WINHTTPAPI HINTERNET WinHttpOpenRequest(
	// [in] HINTERNET hConnect, [in] LPCWSTR pwszVerb, [in] LPCWSTR pwszObjectName, [in] LPCWSTR pwszVersion, [in] LPCWSTR pwszReferrer,
	// [in] LPCWSTR *ppwszAcceptTypes, [in] DWORD dwFlags );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpOpenRequest")]
	public static extern SafeHINTERNET WinHttpOpenRequest(HINTERNET hConnect, [MarshalAs(UnmanagedType.LPWStr)] string pwszVerb,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszObjectName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszVersion,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszReferrer,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string?[]? ppwszAcceptTypes, [Optional] WINHTTP_OPENREQ_FLAG dwFlags);

	/// <summary>The <c>WinHttpQueryAuthSchemes</c> function returns the authorization schemes that are supported by the server.</summary>
	/// <param name="hRequest">Valid HINTERNET handle returned by WinHttpOpenRequest</param>
	/// <param name="lpdwSupportedSchemes">
	/// <para>
	/// An unsigned integer that specifies a flag that contains the supported authentication schemes. This parameter can return one or
	/// more flags that are identified in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_BASIC</c></term>
	/// <term>Indicates basic authentication is available.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_NTLM</c></term>
	/// <term>Indicates NTLM authentication is available.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_PASSPORT</c></term>
	/// <term>Indicates passport authentication is available.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_DIGEST</c></term>
	/// <term>Indicates digest authentication is available.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_NEGOTIATE</c></term>
	/// <term>Selects between NTLM and Kerberos authentication.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwFirstScheme">
	/// <para>
	/// An unsigned integer that specifies a flag that contains the first authentication scheme listed by the server. This parameter can
	/// return one or more flags that are identified in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_BASIC</c></term>
	/// <term>Indicates basic authentication is first.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_NTLM</c></term>
	/// <term>Indicates NTLM authentication is first.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_PASSPORT</c></term>
	/// <term>Indicates passport authentication is first.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_DIGEST</c></term>
	/// <term>Indicates digest authentication is first.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_NEGOTIATE</c></term>
	/// <term>Selects between NTLM and Kerberos authentication.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwAuthTarget">
	/// <para>
	/// An unsigned integer that specifies a flag that contains the authentication target. This parameter can return one or more flags
	/// that are identified in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_AUTH_TARGET_SERVER</c></term>
	/// <term>Authentication target is a server. Indicates that a 401 status code has been received.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_TARGET_PROXY</c></term>
	/// <term>Authentication target is a proxy. Indicates that a 407 status code has been received.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> if unsuccessful. To get extended error information, call GetLastError. The
	/// following table identifies the error codes that are returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> is set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para><c>WinHttpQueryAuthSchemes</c> cannot be used before calling WinHttpQueryHeaders.</para>
	/// <para><c>Note</c> For Windows XP and Windows 2000 see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to retrieve a specified document from an HTTP server when authentication is required. The status
	/// code is retrieved from the response to determine if the server or proxy is requesting authentication. If a 200 status code is
	/// found, the document is available. If a status code of 401 or 407 is found, authentication is required before the document can be
	/// retrieved. For any other status code an error message is displayed.
	/// </para>
	/// <para>
	/// <code>#include &lt;windows.h&gt; #include &lt;winhttp.h&gt; #include &lt;stdio.h&gt; #pragma comment(lib, "winhttp.lib") DWORD ChooseAuthScheme( DWORD dwSupportedSchemes ) { // It is the server's responsibility only to accept // authentication schemes that provide a sufficient level // of security to protect the server's resources. // // The client is also obligated only to use an authentication // scheme that adequately protects its username and password. // // Thus, this sample code does not use Basic authentication // because Basic authentication exposes the client's username // and password to anyone monitoring the connection. if( dwSupportedSchemes &amp; WINHTTP_AUTH_SCHEME_NEGOTIATE ) return WINHTTP_AUTH_SCHEME_NEGOTIATE; else if( dwSupportedSchemes &amp; WINHTTP_AUTH_SCHEME_NTLM ) return WINHTTP_AUTH_SCHEME_NTLM; else if( dwSupportedSchemes &amp; WINHTTP_AUTH_SCHEME_PASSPORT ) return WINHTTP_AUTH_SCHEME_PASSPORT; else if( dwSupportedSchemes &amp; WINHTTP_AUTH_SCHEME_DIGEST ) return WINHTTP_AUTH_SCHEME_DIGEST; else return 0; } struct SWinHttpSampleGet { LPCWSTR szServer; LPCWSTR szPath; BOOL fUseSSL; LPCWSTR szServerUsername; LPCWSTR szServerPassword; LPCWSTR szProxyUsername; LPCWSTR szProxyPassword; }; void WinHttpAuthSample( IN SWinHttpSampleGet *pGetRequest ) { DWORD dwStatusCode = 0; DWORD dwSupportedSchemes; DWORD dwFirstScheme; DWORD dwSelectedScheme; DWORD dwTarget; DWORD dwLastStatus = 0; DWORD dwSize = sizeof(DWORD); BOOL bResults = FALSE; BOOL bDone = FALSE; DWORD dwProxyAuthScheme = 0; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"WinHTTP Example/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0 ); INTERNET_PORT nPort = ( pGetRequest-&gt;fUseSSL ) ? INTERNET_DEFAULT_HTTPS_PORT : INTERNET_DEFAULT_HTTP_PORT; // Specify an HTTP server. if( hSession ) hConnect = WinHttpConnect( hSession, pGetRequest-&gt;szServer, nPort, 0 ); // Create an HTTP request handle. if( hConnect ) hRequest = WinHttpOpenRequest( hConnect, L"GET", pGetRequest-&gt;szPath, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, ( pGetRequest-&gt;fUseSSL ) ? WINHTTP_FLAG_SECURE : 0 ); // Continue to send a request until status code is not 401 or 407. if( hRequest == NULL ) bDone = TRUE; while( !bDone ) { // If a proxy authentication challenge was responded to, reset // those credentials before each SendRequest, because the proxy // may require re-authentication after responding to a 401 or to // a redirect. If you don't, you can get into a 407-401-407-401 // loop. if( dwProxyAuthScheme != 0 ) bResults = WinHttpSetCredentials( hRequest, WINHTTP_AUTH_TARGET_PROXY, dwProxyAuthScheme, pGetRequest-&gt;szProxyUsername, pGetRequest-&gt;szProxyPassword, NULL ); // Send a request. bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0 ); // End the request. if( bResults ) bResults = WinHttpReceiveResponse( hRequest, NULL ); // Resend the request in case of // ERROR_WINHTTP_RESEND_REQUEST error. if( !bResults &amp;&amp; GetLastError( ) == ERROR_WINHTTP_RESEND_REQUEST) continue; // Check the status code. if( bResults ) bResults = WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_STATUS_CODE | WINHTTP_QUERY_FLAG_NUMBER, NULL, &amp;dwStatusCode, &amp;dwSize, NULL ); if( bResults ) { switch( dwStatusCode ) { case 200: // The resource was successfully retrieved. // You can use WinHttpReadData to read the contents // of the server's response. printf( "The resource was successfully retrieved.\n" ); bDone = TRUE; break; case 401: // The server requires authentication. printf( "The server requires authentication. Sending credentials\n"); // Obtain the supported and preferred schemes. bResults = WinHttpQueryAuthSchemes( hRequest, &amp;dwSupportedSchemes, &amp;dwFirstScheme, &amp;dwTarget ); // Set the credentials before re-sending the request. if( bResults ) { dwSelectedScheme = ChooseAuthScheme( dwSupportedSchemes ); if( dwSelectedScheme == 0 ) bDone = TRUE; else bResults = WinHttpSetCredentials( hRequest, dwTarget, dwSelectedScheme, pGetRequest-&gt;szServerUsername, pGetRequest-&gt;szServerPassword, NULL ); } // If the same credentials are requested twice, abort the // request. For simplicity, this sample does not check for // a repeated sequence of status codes. if( dwLastStatus == 401 ) bDone = TRUE; break; case 407: // The proxy requires authentication. printf( "The proxy requires authentication. Sending credentials\n"); // Obtain the supported and preferred schemes. bResults = WinHttpQueryAuthSchemes( hRequest, &amp;dwSupportedSchemes, &amp;dwFirstScheme, &amp;dwTarget ); // Set the credentials before re-sending the request. if( bResults ) dwProxyAuthScheme = ChooseAuthScheme(dwSupportedSchemes); // If the same credentials are requested twice, abort the // request. For simplicity, this sample does not check for // a repeated sequence of status codes. if( dwLastStatus == 407 ) bDone = TRUE; break; default: // The status code does not indicate success. printf( "Error. Status code %d returned.\n", dwStatusCode ); bDone = TRUE; } } // Keep track of the last status code. dwLastStatus = dwStatusCode; // If there are any errors, break out of the loop. if( !bResults ) bDone = TRUE; } // Report any errors. if( !bResults ) { DWORD dwLastError = GetLastError( ); printf( "Error %d has occurred.\n", dwLastError ); } // Close any open handles. if( hRequest ) WinHttpCloseHandle( hRequest ); if( hConnect ) WinHttpCloseHandle( hConnect ); if( hSession ) WinHttpCloseHandle( hSession ); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryauthschemes BOOL WinHttpQueryAuthSchemes( [in]
	// HINTERNET hRequest, [out] LPDWORD lpdwSupportedSchemes, [out] LPDWORD lpdwFirstScheme, [out] LPDWORD pdwAuthTarget );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryAuthSchemes")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpQueryAuthSchemes(HINTERNET hRequest, out WINHTTP_AUTH_SCHEME lpdwSupportedSchemes,
		out WINHTTP_AUTH_SCHEME lpdwFirstScheme, out WINHTTP_AUTH_TARGET pdwAuthTarget);

	/// <summary>Retrieves a description of the current state of WinHttp's connections.</summary>
	/// <param name="hInternet">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>A request handle or a connect handle.</para>
	/// <para>
	/// If a connect handle, then WinHttp assumes that the host uses HTTPS by default. But you can pass
	/// <c>WINHTTP_QUERY_CONNECTION_GROUP_FLAG_INSECURE</c> (0x0000000000000001ull) in ullFlags to indicate that you want non-HTTPS connections.
	/// </para>
	/// </param>
	/// <param name="pGuidConnection">
	/// <para>Type: _In_ <c>GUID*</c></para>
	/// <para>
	/// An optional GUID. If provided, then only connections matching the GUID are returned. Otherwise, the function returns all
	/// connections to the host (specified in hInternet either by a request handle or a connect handle).
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: _In_ <c>ULONGLONG</c></para>
	/// <para>Flags. Pass <c>WINHTTP_QUERY_CONNECTION_GROUP_FLAG_INSECURE</c> to indicate that you want non-HTTPS connections (see hInternet).</para>
	/// </param>
	/// <param name="ppResult">
	/// <para>Type: _Inout_ <c>PWINHTTP_QUERY_CONNECTION_GROUP_RESULT*</c></para>
	/// <para>The address of a pointer to a WINHTTP_QUERY_CONNECTION_GROUP_RESULT, through which the results are returned.</para>
	/// <para>WinHttp performs an allocation internally, so once you're done with it you must free this pointer by calling WinHttpFreeQueryConnectionGroupResult.</para>
	/// </param>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryconnectiongroup WINHTTPAPI DWORD
	// WinHttpQueryConnectionGroup( HINTERNET hInternet, const GUID *pGuidConnection, ULONGLONG ullFlags,
	// PWINHTTP_QUERY_CONNECTION_GROUP_RESULT *ppResult );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryConnectionGroup")]
	public static extern Win32Error WinHttpQueryConnectionGroup(HINTERNET hInternet, in Guid pGuidConnection,
		[Optional] WINHTTP_QUERY_CONNECTION_GROUP_FLAG ullFlags, ref IntPtr ppResult);

	/// <summary>Retrieves a description of the current state of WinHttp's connections.</summary>
	/// <param name="hInternet">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>A request handle or a connect handle.</para>
	/// <para>
	/// If a connect handle, then WinHttp assumes that the host uses HTTPS by default. But you can pass
	/// <c>WINHTTP_QUERY_CONNECTION_GROUP_FLAG_INSECURE</c> (0x0000000000000001ull) in ullFlags to indicate that you want non-HTTPS connections.
	/// </para>
	/// </param>
	/// <param name="pGuidConnection">
	/// <para>Type: _In_ <c>GUID*</c></para>
	/// <para>
	/// An optional GUID. If provided, then only connections matching the GUID are returned. Otherwise, the function returns all
	/// connections to the host (specified in hInternet either by a request handle or a connect handle).
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: _In_ <c>ULONGLONG</c></para>
	/// <para>Flags. Pass <c>WINHTTP_QUERY_CONNECTION_GROUP_FLAG_INSECURE</c> to indicate that you want non-HTTPS connections (see hInternet).</para>
	/// </param>
	/// <param name="ppResult">
	/// <para>Type: _Inout_ <c>PWINHTTP_QUERY_CONNECTION_GROUP_RESULT*</c></para>
	/// <para>The address of a pointer to a <see cref="WINHTTP_QUERY_CONNECTION_GROUP_RESULT"/>, through which the results are returned.</para>
	/// <para>WinHttp performs an allocation internally, so once you're done with it you must free this pointer by calling <see cref="WinHttpFreeQueryConnectionGroupResult"/>.</para>
	/// </param>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryconnectiongroup WINHTTPAPI DWORD
	// WinHttpQueryConnectionGroup( HINTERNET hInternet, const GUID *pGuidConnection, ULONGLONG ullFlags,
	// PWINHTTP_QUERY_CONNECTION_GROUP_RESULT *ppResult );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryConnectionGroup")]
	public static extern Win32Error WinHttpQueryConnectionGroup(HINTERNET hInternet, [In, Optional] GuidPtr pGuidConnection,
		[Optional] WINHTTP_QUERY_CONNECTION_GROUP_FLAG ullFlags, ref IntPtr ppResult);

	/// <summary>The <c>WinHttpQueryDataAvailable</c> function returns the amount of data, in bytes, available to be read with WinHttpReadData.</summary>
	/// <param name="hRequest">
	/// A valid HINTERNET handle returned by WinHttpOpenRequest. WinHttpReceiveResponse must have been called for this handle and have
	/// completed before <c>WinHttpQueryDataAvailable</c> is called.
	/// </param>
	/// <param name="lpdwNumberOfBytesAvailable">
	/// A pointer to an unsigned long integer variable that receives the number of available bytes. When WinHTTP is used in asynchronous
	/// mode, always set this parameter to <c>NULL</c> and retrieve data in the callback function; not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error data, call GetLastError. Among the
	/// error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example,
	/// WinHTTP version 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot complete because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>
	/// The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_TIMEOUT</c></term>
	/// <term>The request has timed out.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function can operate either synchronously or asynchronously. If it returns <c>FALSE</c>, it failed and you can call GetLastError
	/// to get extended error information. If it returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE completion to
	/// determine whether this function was successful and the value of the parameters. The WINHTTP_CALLBACK_STATUS_REQUEST_ERROR
	/// completion indicates that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When WinHTTP is used in asynchronous mode, always set the <c>lpdwNumberOfBytesAvailable</c> parameter to
	/// <c>NULL</c> and retrieve the bytes available in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// This function returns the number of bytes of data that are available to read immediately by a subsequent call to WinHttpReadData.
	/// If no data is available and the end of the file has not been reached, one of two things happens. If the session is synchronous,
	/// the request waits until data becomes available. If the session is asynchronous, the function returns <c>TRUE</c>, and when data
	/// becomes available, calls the callback function with WINHTTP_STATUS_CALLBACK_DATA_AVAILABLE and indicates the number of bytes
	/// immediately available to read by calling <c>WinHttpReadData</c>.
	/// </para>
	/// <para>
	/// The amount of data that remains is not recalculated until all available data indicated by the call to
	/// <c>WinHttpQueryDataAvailable</c> is read.
	/// </para>
	/// <para>Use the return value of WinHttpReadData to determine when a response has been completely read.</para>
	/// <para>
	/// <c>Important</c> Do not use the return value of <c>WinHttpQueryDataAvailable</c> to determine whether the end of a response has
	/// been reached, because not all servers terminate responses properly, and an improperly terminated response causes
	/// <c>WinHttpQueryDataAvailable</c> to anticipate more data.
	/// </para>
	/// <para>
	/// For HINTERNET handles created by the WinHttpOpenRequest function and sent by WinHttpSendRequest, a call to WinHttpReceiveResponse
	/// must be made on the handle before <c>WinHttpQueryDataAvailable</c> can be used.
	/// </para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then those of the following notifications that
	/// have been set in the <c>dwNotificationFlags</c> parameter of <c>WinHttpSetStatusCallback</c> indicate progress in checking for
	/// available data:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For more information about Windows XP and Windows 2000, see Run-Time Requirements.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpquerydataavailable BOOL WinHttpQueryDataAvailable(
	// [in] HINTERNET hRequest, [out] LPDWORD lpdwNumberOfBytesAvailable );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryDataAvailable")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpQueryDataAvailable(HINTERNET hRequest, out uint lpdwNumberOfBytesAvailable);

	/// <summary>Also see WinHttpQueryHeadersEx, which offers a way to retrieve parsed header name and value strings.</summary>
	/// <param name="hRequest">
	/// HINTERNET request handle returned by WinHttpOpenRequest. WinHttpReceiveResponse must have been called for this handle and have
	/// completed before <c>WinHttpQueryHeaders</c> is called.
	/// </param>
	/// <param name="dwInfoLevel">
	/// Value of type <c>DWORD</c> that specifies a combination of attribute and modifier flags listed on the Query Info Flags page.
	/// These attribute and modifier flags indicate that the information is being requested and how it is to be formatted.
	/// </param>
	/// <param name="pwszName">
	/// Pointer to a string that contains the header name. If the flag in <c>dwInfoLevel</c> is not <c>WINHTTP_QUERY_CUSTOM</c>, set this
	/// parameter to WINHTTP_HEADER_NAME_BY_INDEX.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to the buffer that receives the information. Setting this parameter to WINHTTP_NO_OUTPUT_BUFFER causes this function to
	/// return <c>FALSE</c>. Calling GetLastError then returns <c>ERROR_INSUFFICIENT_BUFFER</c> and <c>lpdwBufferLength</c> contains the
	/// number of bytes required to hold the requested information.
	/// </param>
	/// <param name="lpdwBufferLength">
	/// <para>
	/// Pointer to a value of type <c>DWORD</c> that specifies the length of the data buffer, in bytes. When the function returns, this
	/// parameter contains the pointer to a value that specifies the length of the information written to the buffer. When the function
	/// returns strings, the following rules apply.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the function succeeds, <c>lpdwBufferLength</c> specifies the length of the string, in bytes, minus 2 for the terminating null.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the function fails and <c>ERROR_INSUFFICIENT_BUFFER</c> is returned, <c>lpdwBufferLength</c> specifies the number of bytes
	/// that the application must allocate to receive the string.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwIndex">
	/// Pointer to a zero-based header index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. If the next index cannot be found, <c>ERROR_WINHTTP_HEADER_NOT_FOUND</c> is returned. Set this parameter to
	/// WINHTTP_NO_HEADER_INDEX to specify that only the first occurrence of a header should be returned.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Among the
	/// error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_HEADER_NOT_FOUND</c></term>
	/// <term>The requested header could not be located.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot be carried out because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// By default <c>WinHttpQueryHeaders</c> returns a string. However, you can request data in the form of a SYSTEMTIME structure or
	/// <c>DWORD</c> by including the appropriate modifier flag in <c>dwInfoLevel</c>. The following table shows the possible data types
	/// that <c>WinHttpQueryHeaders</c> can return along with the modifier flag that you use to select that data type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Data type</term>
	/// <term>Modifier flag</term>
	/// </listheader>
	/// <item>
	/// <term><c>LPCWSTR</c></term>
	/// <term>Default. No modifier flag required.</term>
	/// </item>
	/// <item>
	/// <term><c>SYSTEMTIME</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_SYSTEMTIME</c></term>
	/// </item>
	/// <item>
	/// <term><c>DWORD</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_NUMBER</c></term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to obtain an HINTERNET handle, open an HTTP session, create and send a request header, and
	/// examine the returned response header.
	/// </para>
	/// <para>
	/// <code> DWORD dwSize = 0; LPVOID lpOutBuffer = NULL; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // First, use WinHttpQueryHeaders to obtain the size of the buffer. if (bResults) { WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_RAW_HEADERS_CRLF, WINHTTP_HEADER_NAME_BY_INDEX, NULL, &amp;dwSize, WINHTTP_NO_HEADER_INDEX); // Allocate memory for the buffer. if( GetLastError( ) == ERROR_INSUFFICIENT_BUFFER ) { lpOutBuffer = new WCHAR[dwSize/sizeof(WCHAR)]; // Now, use WinHttpQueryHeaders to retrieve the header. bResults = WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_RAW_HEADERS_CRLF, WINHTTP_HEADER_NAME_BY_INDEX, lpOutBuffer, &amp;dwSize, WINHTTP_NO_HEADER_INDEX); } } // Print the header contents. if (bResults) printf("Header contents: \n%S",lpOutBuffer); // Free the allocated memory. delete [] lpOutBuffer; // Report any errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryheaders BOOL WinHttpQueryHeaders( [in] HINTERNET
	// hRequest, [in] DWORD dwInfoLevel, [in, optional] LPCWSTR pwszName, [out] LPVOID lpBuffer, [in, out] LPDWORD lpdwBufferLength, [in,
	// out] LPDWORD lpdwIndex );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryHeaders")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpQueryHeaders(HINTERNET hRequest, WINHTTP_QUERY dwInfoLevel, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszName,
		[Out, Optional] IntPtr lpBuffer, ref uint lpdwBufferLength, ref uint lpdwIndex);

	/// <summary>Also see WinHttpQueryHeadersEx, which offers a way to retrieve parsed header name and value strings.</summary>
	/// <param name="hRequest">
	/// HINTERNET request handle returned by WinHttpOpenRequest. WinHttpReceiveResponse must have been called for this handle and have
	/// completed before <c>WinHttpQueryHeaders</c> is called.
	/// </param>
	/// <param name="dwInfoLevel">
	/// Value of type <c>DWORD</c> that specifies a combination of attribute and modifier flags listed on the Query Info Flags page.
	/// These attribute and modifier flags indicate that the information is being requested and how it is to be formatted.
	/// </param>
	/// <param name="pwszName">
	/// Pointer to a string that contains the header name. If the flag in <c>dwInfoLevel</c> is not <c>WINHTTP_QUERY_CUSTOM</c>, set this
	/// parameter to WINHTTP_HEADER_NAME_BY_INDEX.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to the buffer that receives the information. Setting this parameter to WINHTTP_NO_OUTPUT_BUFFER causes this function to
	/// return <c>FALSE</c>. Calling GetLastError then returns <c>ERROR_INSUFFICIENT_BUFFER</c> and <c>lpdwBufferLength</c> contains the
	/// number of bytes required to hold the requested information.
	/// </param>
	/// <param name="lpdwBufferLength">
	/// <para>
	/// Pointer to a value of type <c>DWORD</c> that specifies the length of the data buffer, in bytes. When the function returns, this
	/// parameter contains the pointer to a value that specifies the length of the information written to the buffer. When the function
	/// returns strings, the following rules apply.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the function succeeds, <c>lpdwBufferLength</c> specifies the length of the string, in bytes, minus 2 for the terminating null.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the function fails and <c>ERROR_INSUFFICIENT_BUFFER</c> is returned, <c>lpdwBufferLength</c> specifies the number of bytes
	/// that the application must allocate to receive the string.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwIndex">
	/// Pointer to a zero-based header index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. If the next index cannot be found, <c>ERROR_WINHTTP_HEADER_NOT_FOUND</c> is returned. Set this parameter to
	/// WINHTTP_NO_HEADER_INDEX to specify that only the first occurrence of a header should be returned.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Among the
	/// error codes returned are the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_HEADER_NOT_FOUND</c></term>
	/// <term>The requested header could not be located.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot be carried out because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// By default <c>WinHttpQueryHeaders</c> returns a string. However, you can request data in the form of a SYSTEMTIME structure or
	/// <c>DWORD</c> by including the appropriate modifier flag in <c>dwInfoLevel</c>. The following table shows the possible data types
	/// that <c>WinHttpQueryHeaders</c> can return along with the modifier flag that you use to select that data type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Data type</term>
	/// <term>Modifier flag</term>
	/// </listheader>
	/// <item>
	/// <term><c>LPCWSTR</c></term>
	/// <term>Default. No modifier flag required.</term>
	/// </item>
	/// <item>
	/// <term><c>SYSTEMTIME</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_SYSTEMTIME</c></term>
	/// </item>
	/// <item>
	/// <term><c>DWORD</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_NUMBER</c></term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to obtain an HINTERNET handle, open an HTTP session, create and send a request header, and
	/// examine the returned response header.
	/// </para>
	/// <para>
	/// <code> DWORD dwSize = 0; LPVOID lpOutBuffer = NULL; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // First, use WinHttpQueryHeaders to obtain the size of the buffer. if (bResults) { WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_RAW_HEADERS_CRLF, WINHTTP_HEADER_NAME_BY_INDEX, NULL, &amp;dwSize, WINHTTP_NO_HEADER_INDEX); // Allocate memory for the buffer. if( GetLastError( ) == ERROR_INSUFFICIENT_BUFFER ) { lpOutBuffer = new WCHAR[dwSize/sizeof(WCHAR)]; // Now, use WinHttpQueryHeaders to retrieve the header. bResults = WinHttpQueryHeaders( hRequest, WINHTTP_QUERY_RAW_HEADERS_CRLF, WINHTTP_HEADER_NAME_BY_INDEX, lpOutBuffer, &amp;dwSize, WINHTTP_NO_HEADER_INDEX); } } // Print the header contents. if (bResults) printf("Header contents: \n%S",lpOutBuffer); // Free the allocated memory. delete [] lpOutBuffer; // Report any errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryheaders BOOL WinHttpQueryHeaders( [in] HINTERNET
	// hRequest, [in] DWORD dwInfoLevel, [in, optional] LPCWSTR pwszName, [out] LPVOID lpBuffer, [in, out] LPDWORD lpdwBufferLength, [in,
	// out] LPDWORD lpdwIndex );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryHeaders")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpQueryHeaders(HINTERNET hRequest, WINHTTP_QUERY dwInfoLevel, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszName,
		[Out, Optional] IntPtr lpBuffer, ref uint lpdwBufferLength, [In, Optional] IntPtr lpdwIndex);

	/// <summary>Also see WinHttpQueryHeadersEx, which offers a way to retrieve parsed header name and value strings.</summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="hRequest">
	/// HINTERNET request handle returned by WinHttpOpenRequest. WinHttpReceiveResponse must have been called for this handle and have
	/// completed before <c>WinHttpQueryHeaders</c> is called.
	/// </param>
	/// <param name="infoLevel">
	/// Value of type <c>DWORD</c> that specifies a combination of attribute and modifier flags listed on the Query Info Flags page.
	/// These attribute and modifier flags indicate that the information is being requested and how it is to be formatted.
	/// </param>
	/// <param name="name">
	/// Pointer to a string that contains the header name. If the flag in <paramref name="infoLevel"/> is not
	/// <c>WINHTTP_QUERY_CUSTOM</c>, set this parameter to WINHTTP_HEADER_NAME_BY_INDEX.
	/// </param>
	/// <param name="index">
	/// A zero-based header index used to enumerate multiple headers with the same name. When calling the function, this parameter is the
	/// index of the specified header to return. When the function returns, this parameter is the index of the next header. If the next
	/// index cannot be found, <c>ERROR_WINHTTP_HEADER_NOT_FOUND</c> is returned.
	/// </param>
	/// <returns>The requested value.</returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously.
	/// </para>
	/// <para>
	/// By default <c>WinHttpQueryHeaders</c> returns a string. However, you can request data in the form of a SYSTEMTIME structure or
	/// <c>uint</c> by including the appropriate modifier flag in <paramref name="infoLevel"/>. The following table shows the possible
	/// data types that <c>WinHttpQueryHeaders</c> can return along with the modifier flag that you use to select that data type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Data type</term>
	/// <term>Modifier flag</term>
	/// </listheader>
	/// <item>
	/// <term><c>string</c></term>
	/// <term>Default. No modifier flag required.</term>
	/// </item>
	/// <item>
	/// <term><c>SYSTEMTIME</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_SYSTEMTIME</c></term>
	/// </item>
	/// <item>
	/// <term><c>uint</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_NUMBER</c></term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryHeaders")]
	public static T WinHttpQueryHeaders<T>(HINTERNET hRequest, WINHTTP_QUERY infoLevel, [Optional] string? name, ref uint index)
	{
		uint sz = 0;
		WinHttpQueryHeaders(hRequest, infoLevel, name, default, ref sz, ref index);
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		if (typeof(T).IsValueType)
			sz = Math.Max(InteropExtensions.SizeOf<T>(), sz);
		using var buffer = new SafeHGlobalHandle(sz);
		Win32Error.ThrowLastErrorIfFalse(WinHttpQueryHeaders(hRequest, infoLevel, name, buffer, ref sz, ref index));
		return buffer.ToType<T>()!;
	}

	/// <summary>Also see WinHttpQueryHeadersEx, which offers a way to retrieve parsed header name and value strings.</summary>
	/// <typeparam name="T">The type of the value to return.</typeparam>
	/// <param name="hRequest">
	/// HINTERNET request handle returned by WinHttpOpenRequest. WinHttpReceiveResponse must have been called for this handle and have
	/// completed before <c>WinHttpQueryHeaders</c> is called.
	/// </param>
	/// <param name="infoLevel">
	/// Value of type <c>DWORD</c> that specifies a combination of attribute and modifier flags listed on the Query Info Flags page.
	/// These attribute and modifier flags indicate that the information is being requested and how it is to be formatted.
	/// </param>
	/// <param name="name">
	/// Pointer to a string that contains the header name. If the flag in <paramref name="infoLevel"/> is not
	/// <c>WINHTTP_QUERY_CUSTOM</c>, set this parameter to WINHTTP_HEADER_NAME_BY_INDEX.
	/// </param>
	/// <returns>The requested value.</returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this
	/// function operates synchronously.
	/// </para>
	/// <para>
	/// By default <c>WinHttpQueryHeaders</c> returns a string. However, you can request data in the form of a SYSTEMTIME structure or
	/// <c>uint</c> by including the appropriate modifier flag in <paramref name="infoLevel"/>. The following table shows the possible
	/// data types that <c>WinHttpQueryHeaders</c> can return along with the modifier flag that you use to select that data type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Data type</term>
	/// <term>Modifier flag</term>
	/// </listheader>
	/// <item>
	/// <term><c>string</c></term>
	/// <term>Default. No modifier flag required.</term>
	/// </item>
	/// <item>
	/// <term><c>SYSTEMTIME</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_SYSTEMTIME</c></term>
	/// </item>
	/// <item>
	/// <term><c>uint</c></term>
	/// <term><c>WINHTTP_QUERY_FLAG_NUMBER</c></term>
	/// </item>
	/// </list>
	/// </remarks>
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryHeaders")]
	public static T WinHttpQueryHeaders<T>(HINTERNET hRequest, WINHTTP_QUERY infoLevel, [Optional] string? name)
	{
		uint sz = 0;
		WinHttpQueryHeaders(hRequest, infoLevel, name, default, ref sz);
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		if (typeof(T).IsValueType)
			sz = Math.Max(InteropExtensions.SizeOf<T>(), sz);
		using var buffer = new SafeHGlobalHandle(sz);
		Win32Error.ThrowLastErrorIfFalse(WinHttpQueryHeaders(hRequest, infoLevel, name, buffer, ref sz));
		return buffer.ToType<T>()!;
	}

	private const WINHTTP_QUERY queryMods = WINHTTP_QUERY.WINHTTP_QUERY_FLAG_NUMBER | WINHTTP_QUERY.WINHTTP_QUERY_FLAG_NUMBER64 | WINHTTP_QUERY.WINHTTP_QUERY_FLAG_SYSTEMTIME;

	/// <summary>
	/// Retrieves header information associated with an HTTP request; offers a way to retrieve parsed header name and value strings.
	/// </summary>
	/// <param name="hRequest">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>
	/// Request handle returned by WinHttpOpenRequest. The WinHttpReceiveResponse call for this handle must have completed before calling
	/// <c>WinHttpQueryHeadersEx</c>. If you're querying trailers, then the WinHttpReadData call for this handle must return 0 bytes read
	/// before calling <c>WinHttpQueryHeadersEx</c>.
	/// </para>
	/// </param>
	/// <param name="dwInfoLevel">
	/// <para>Type: _In_ <c>DWORD</c></para>
	/// <para>
	/// Value of type <c>DWORD</c> that specifies a combination of attribute and modifier flags listed in the Query info flags topic.
	/// These attribute and modifier flags indicate the information that is being requested, and how it is to be formatted.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The following flags return <c>ERROR_INVALID_PARAMETER</c> if used: <c>WINHTTP_QUERY_VERSION</c>,
	/// <c>WINHTTP_QUERY_STATUS_CODE</c>, <c>WINHTTP_QUERY_STATUS_TEXT</c>, <c>WINHTTP_QUERY_FLAG_NUMBER</c>,
	/// <c>WINHTTP_QUERY_FLAG_NUMBER64</c>, <c>WINHTTP_QUERY_FLAG_SYSTEMTIME</c>, and <c>WINHTTP_QUERY_RAW_HEADERS_CRLF</c>.
	/// </para>
	/// </para>
	/// <para>The flag <c>WINHTTP_QUERY_EX_ALL_HEADERS</c> returns all the headers.</para>
	/// <para>
	/// If you're not querying for all of the headers, then you can pass the flag corresponding to a specific known header, or you can
	/// pass <c>WINHTTP_QUERY_CUSTOM</c> along with a string for the header name in the pHeaderName parameter.
	/// </para>
	/// <para>
	/// Passing <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c> returns the headers in the format in which they're sent over the wire (you should
	/// access/set the psz* members of WINHTTP_EXTENDED_HEADER and WINHTTP_HEADER_NAME). If you don't set the wire encoding flag, then
	/// the default behavior is to return headers in Unicode format (you should access/set the pwsz* members of WINHTTP_EXTENDED_HEADER
	/// and WINHTTP_HEADER_NAME).
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: _In_ <c>ULONGLONG</c></para>
	/// <para>Reserved. Set to 0.</para>
	/// </param>
	/// <param name="uiCodePage">
	/// <para>Type: _In_ <c>UINT</c></para>
	/// <para>
	/// The code page to use for Unicode conversion. You should pass in 0 for default behavior (CP_ACP), or when using
	/// <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c>. No validation is done for this parameter.
	/// </para>
	/// </param>
	/// <param name="pdwIndex">
	/// <para>Type: _Inout_opt_ <c>PDWORD</c></para>
	/// <para>
	/// The address of a zero-based index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. Pass <c>NULL</c> to access the first instance of a given header.
	/// </para>
	/// </param>
	/// <param name="pHeaderName">
	/// <para>Type: _Inout_opt_ <c>PWINHTTP_HEADER_NAME</c></para>
	/// <para>The address of a WINHTTP_HEADER_NAME structure.</para>
	/// <para>
	/// Set pHeaderName to <c>NULL</c> when retrieving all headers. If this parameter is not <c>NULL</c>, and you pass
	/// <c>WINHTTP_QUERY_CUSTOM</c> with dwInfoLevel, then <c>WinHttpQueryHeadersEx</c> will retrieve only the header specified by this
	/// parameter. If you pass <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c> with dwInfoLevel, then you should use the pszName member (if the
	/// flag is not set, then use pwszName member).
	/// </para>
	/// </param>
	/// <param name="pBuffer">
	/// <para>Type: _Out_writes_bytes_to_opt_(*pdwBufferLength, *pdwBufferLength) <c>LPVOID</c></para>
	/// <para>
	/// A caller-provided buffer to store the parsed header pointers and the headers. If this parameter is <c>NULL</c> or too small, then
	/// <c>WinHttpQueryHeadersEx</c> returns <c>ERROR_INSUFFICIENT_BUFFER</c>, and the pdwBufferLength parameter contains the required
	/// buffer size in bytes.
	/// </para>
	/// </param>
	/// <param name="pdwBufferLength">
	/// <para>Type: _Inout_ <c>PDWORD</c></para>
	/// <para>
	/// Length of the caller-provided buffer. If pBuffer is <c>NULL</c> or too small, then <c>WinHttpQueryHeadersEx</c> writes the
	/// required buffer size in bytes to this parameter.
	/// </para>
	/// </param>
	/// <param name="ppHeaders">
	/// <para>Type: _Out_writes_opt_(*pdwHeadersCount) <c>PWINHTTP_EXTENDED_HEADER*</c></para>
	/// <para>
	/// A handle to an array of WINHTTP_EXTENDED_HEADER for accessing parsed header names/values. You should pass in the address of a
	/// <c>WINHTTP_EXTENDED_HEADER</c> pointer that's initialized to <c>NULL</c>. Upon completion, you should access the pszName/pszValue
	/// parameters if using <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c>, and pwszName/pwszValue otherwise.
	/// </para>
	/// </param>
	/// <param name="pdwHeadersCount">
	/// <para>Type: _Out_ <c>PDWORD</c></para>
	/// <para>The number of headers returned. You shouldn't try to access beyond
	/// <code>ppHeaders[cHeaders - 1]</code>
	/// , because that is out of bounds of the array.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation. Among the error codes returned are the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_HEADER_NOT_FOUND</c></term>
	/// <term>The requested header could not be located.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot be carried out because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinHttpQueryHeadersEx</c> builds on the functionality of WinHttpQueryHeaders. <c>WinHttpQueryHeaders</c> allows you to query
	/// request or response headers (or response trailers) in the form of a string, a number (DWORD), or a timestamp (SYSTEMTIME).
	/// Querying for all headers returns a single serialized string with CRLF or NULL characters delimiting different headers. For
	/// example, "Name1: value1\r\nName2: value2\r\n\r\n". Or "Name1: value1\0Name2: value2\0\0". A double delimiter is used to indicate
	/// the end of the string.
	/// </para>
	/// <para><c>WinHttpQueryHeadersEx</c> gives you a way to retrieve parsed header name and value strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryheadersex WINHTTPAPI DWORD
	// WinHttpQueryHeadersEx( HINTERNET hRequest, DWORD dwInfoLevel, ULONGLONG ullFlags, UINT uiCodePage, PDWORD pdwIndex,
	// PWINHTTP_HEADER_NAME pHeaderName, PVOID pBuffer, PDWORD pdwBufferLength, PWINHTTP_EXTENDED_HEADER *ppHeaders, PDWORD
	// pdwHeadersCount );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryHeadersEx")]
	public static extern Win32Error WinHttpQueryHeadersEx(HINTERNET hRequest, WINHTTP_QUERY dwInfoLevel, [Optional] ulong ullFlags,
		[Optional] uint uiCodePage, ref uint pdwIndex, ref WINHTTP_HEADER_NAME pHeaderName, [Out, Optional] IntPtr pBuffer,
		ref uint pdwBufferLength, out IntPtr ppHeaders, out uint pdwHeadersCount);

	/// <summary>
	/// Retrieves header information associated with an HTTP request; offers a way to retrieve parsed header name and value strings.
	/// </summary>
	/// <param name="hRequest">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>
	/// Request handle returned by WinHttpOpenRequest. The WinHttpReceiveResponse call for this handle must have completed before calling
	/// <c>WinHttpQueryHeadersEx</c>. If you're querying trailers, then the WinHttpReadData call for this handle must return 0 bytes read
	/// before calling <c>WinHttpQueryHeadersEx</c>.
	/// </para>
	/// </param>
	/// <param name="dwInfoLevel">
	/// <para>Type: _In_ <c>DWORD</c></para>
	/// <para>
	/// Value of type <c>DWORD</c> that specifies a combination of attribute and modifier flags listed in the Query info flags topic.
	/// These attribute and modifier flags indicate the information that is being requested, and how it is to be formatted.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The following flags return <c>ERROR_INVALID_PARAMETER</c> if used: <c>WINHTTP_QUERY_VERSION</c>,
	/// <c>WINHTTP_QUERY_STATUS_CODE</c>, <c>WINHTTP_QUERY_STATUS_TEXT</c>, <c>WINHTTP_QUERY_FLAG_NUMBER</c>,
	/// <c>WINHTTP_QUERY_FLAG_NUMBER64</c>, <c>WINHTTP_QUERY_FLAG_SYSTEMTIME</c>, and <c>WINHTTP_QUERY_RAW_HEADERS_CRLF</c>.
	/// </para>
	/// </para>
	/// <para>The flag <c>WINHTTP_QUERY_EX_ALL_HEADERS</c> returns all the headers.</para>
	/// <para>
	/// If you're not querying for all of the headers, then you can pass the flag corresponding to a specific known header, or you can
	/// pass <c>WINHTTP_QUERY_CUSTOM</c> along with a string for the header name in the pHeaderName parameter.
	/// </para>
	/// <para>
	/// Passing <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c> returns the headers in the format in which they're sent over the wire (you should
	/// access/set the psz* members of WINHTTP_EXTENDED_HEADER and WINHTTP_HEADER_NAME). If you don't set the wire encoding flag, then
	/// the default behavior is to return headers in Unicode format (you should access/set the pwsz* members of WINHTTP_EXTENDED_HEADER
	/// and WINHTTP_HEADER_NAME).
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: _In_ <c>ULONGLONG</c></para>
	/// <para>Reserved. Set to 0.</para>
	/// </param>
	/// <param name="uiCodePage">
	/// <para>Type: _In_ <c>UINT</c></para>
	/// <para>
	/// The code page to use for Unicode conversion. You should pass in 0 for default behavior (CP_ACP), or when using
	/// <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c>. No validation is done for this parameter.
	/// </para>
	/// </param>
	/// <param name="pdwIndex">
	/// <para>Type: _Inout_opt_ <c>PDWORD</c></para>
	/// <para>
	/// The address of a zero-based index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. Pass <c>NULL</c> to access the first instance of a given header.
	/// </para>
	/// </param>
	/// <param name="pHeaderName">
	/// <para>Type: _Inout_opt_ <c>PWINHTTP_HEADER_NAME</c></para>
	/// <para>The address of a WINHTTP_HEADER_NAME structure.</para>
	/// <para>
	/// Set pHeaderName to <c>NULL</c> when retrieving all headers. If this parameter is not <c>NULL</c>, and you pass
	/// <c>WINHTTP_QUERY_CUSTOM</c> with dwInfoLevel, then <c>WinHttpQueryHeadersEx</c> will retrieve only the header specified by this
	/// parameter. If you pass <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c> with dwInfoLevel, then you should use the pszName member (if the
	/// flag is not set, then use pwszName member).
	/// </para>
	/// </param>
	/// <param name="pBuffer">
	/// <para>Type: _Out_writes_bytes_to_opt_(*pdwBufferLength, *pdwBufferLength) <c>LPVOID</c></para>
	/// <para>
	/// A caller-provided buffer to store the parsed header pointers and the headers. If this parameter is <c>NULL</c> or too small, then
	/// <c>WinHttpQueryHeadersEx</c> returns <c>ERROR_INSUFFICIENT_BUFFER</c>, and the pdwBufferLength parameter contains the required
	/// buffer size in bytes.
	/// </para>
	/// </param>
	/// <param name="pdwBufferLength">
	/// <para>Type: _Inout_ <c>PDWORD</c></para>
	/// <para>
	/// Length of the caller-provided buffer. If pBuffer is <c>NULL</c> or too small, then <c>WinHttpQueryHeadersEx</c> writes the
	/// required buffer size in bytes to this parameter.
	/// </para>
	/// </param>
	/// <param name="ppHeaders">
	/// <para>Type: _Out_writes_opt_(*pdwHeadersCount) <c>PWINHTTP_EXTENDED_HEADER*</c></para>
	/// <para>
	/// A handle to an array of WINHTTP_EXTENDED_HEADER for accessing parsed header names/values. You should pass in the address of a
	/// <c>WINHTTP_EXTENDED_HEADER</c> pointer that's initialized to <c>NULL</c>. Upon completion, you should access the pszName/pszValue
	/// parameters if using <c>WINHTTP_QUERY_FLAG_WIRE_ENCODING</c>, and pwszName/pwszValue otherwise.
	/// </para>
	/// </param>
	/// <param name="pdwHeadersCount">
	/// <para>Type: _Out_ <c>PDWORD</c></para>
	/// <para>The number of headers returned. You shouldn't try to access beyond
	/// <code>ppHeaders[cHeaders - 1]</code>
	/// , because that is out of bounds of the array.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation. Among the error codes returned are the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_HEADER_NOT_FOUND</c></term>
	/// <term>The requested header could not be located.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c></term>
	/// <term>The requested operation cannot be carried out because the handle supplied is not in the correct state.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE_TYPE</c></term>
	/// <term>The type of handle supplied is incorrect for this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INTERNAL_ERROR</c></term>
	/// <term>An internal error has occurred.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinHttpQueryHeadersEx</c> builds on the functionality of WinHttpQueryHeaders. <c>WinHttpQueryHeaders</c> allows you to query
	/// request or response headers (or response trailers) in the form of a string, a number (DWORD), or a timestamp (SYSTEMTIME).
	/// Querying for all headers returns a single serialized string with CRLF or NULL characters delimiting different headers. For
	/// example, "Name1: value1\r\nName2: value2\r\n\r\n". Or "Name1: value1\0Name2: value2\0\0". A double delimiter is used to indicate
	/// the end of the string.
	/// </para>
	/// <para><c>WinHttpQueryHeadersEx</c> gives you a way to retrieve parsed header name and value strings.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryheadersex WINHTTPAPI DWORD
	// WinHttpQueryHeadersEx( HINTERNET hRequest, DWORD dwInfoLevel, ULONGLONG ullFlags, UINT uiCodePage, PDWORD pdwIndex,
	// PWINHTTP_HEADER_NAME pHeaderName, PVOID pBuffer, PDWORD pdwBufferLength, PWINHTTP_EXTENDED_HEADER *ppHeaders, PDWORD
	// pdwHeadersCount );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryHeadersEx")]
	public static extern Win32Error WinHttpQueryHeadersEx(HINTERNET hRequest, WINHTTP_QUERY dwInfoLevel, [Optional] ulong ullFlags,
		[Optional] uint uiCodePage, [Optional] IntPtr pdwIndex, [Optional] IntPtr pHeaderName, [Out, Optional] IntPtr pBuffer,
		ref uint pdwBufferLength, out IntPtr ppHeaders, out uint pdwHeadersCount);
}