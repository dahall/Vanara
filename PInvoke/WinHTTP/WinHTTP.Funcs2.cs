using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Items from the WinHTTP.dll.</summary>
public static partial class WinHTTP
{
	/// <summary>Represents an application-defined proxy change callback function.</summary>
	/// <param name="ullFlags">
	/// <para>Type: _In_ <c>ULONGLONG</c></para>
	/// <para>The flag passed to the WinHttpRegisterProxyChangeNotification function (for example, <c>WINHTTP_PROXY_NOTIFY_CHANGE</c>).</para>
	/// </param>
	/// <param name="pvContext">
	/// <para>Type: _In_ <c>PVOID</c></para>
	/// <para>The context object pointer passed to the WinHttpRegisterProxyChangeNotification function.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nc-winhttp-winhttp_proxy_change_callback WINHTTP_PROXY_CHANGE_CALLBACK
	// WinhttpProxyChangeCallback; void WinhttpProxyChangeCallback( ULONGLONG ullFlags, PVOID pvContext ) {...}
	[PInvokeData("winhttp.h", MSDNShortId = "NC:winhttp.WINHTTP_PROXY_CHANGE_CALLBACK")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate void WINHTTP_PROXY_CHANGE_CALLBACK(ulong ullFlags, IntPtr pvContext);

	/// <summary>Frees the data retrieved from a previous call to WinHttpGetProxySettingsResultEx.</summary>
	/// <param name="ProxySettingsType">
	/// <para>Type: _In_ <c>WINHTTP_PROXY_SETTINGS_TYPE</c></para>
	/// <para>A proxy settings type.</para>
	/// </param>
	/// <param name="pProxySettingsEx">
	/// <para>Type: _In_ <c>PVOID</c></para>
	/// <para>A pointer to a WINHTTP_PROXY_SETTINGS_EX structure that was retrieved from a previous call to WinHttpGetProxySettingsResultEx.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpfreeproxysettingsex WINHTTPAPI DWORD
	// WinHttpFreeProxySettingsEx( WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType, PVOID pProxySettingsEx );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpFreeProxySettingsEx")]
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error WinHttpFreeProxySettingsEx(WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType,
		IntPtr pProxySettingsEx);

	/// <summary>Retrieves extended proxy settings.</summary>
	/// <param name="hResolver">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>The WinHTTP resolver handle returned by the WinHttpCreateProxyResolver function.</para>
	/// </param>
	/// <param name="ProxySettingsType">
	/// <para>Type: _In_ <c>WINHTTP_PROXY_SETTINGS_TYPE</c></para>
	/// <para>A proxy settings type.</para>
	/// </param>
	/// <param name="pProxySettingsParam">
	/// <para>Type: _In_opt_ <c>PWINHTTP_PROXY_SETTINGS_PARAM</c></para>
	/// <para>An optional pointer to a WINHTTP_PROXY_SETTINGS_PARAM.</para>
	/// </param>
	/// <param name="pContext">
	/// <para>Type: _In_opt_ <c>DWORD_PTR</c></para>
	/// <para>An optional pointer to a <c>DWORD</c> containing context data that will be passed to the completion callback function.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// A <c>DWORD</c> containing a status code indicating the result of the operation. The following codes can be returned (the list is not exhaustive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_IO_PENDING</term>
	/// <term>The operation is continuing asynchronously.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxysettingsex WINHTTPAPI DWORD
	// WinHttpGetProxySettingsEx( HINTERNET hResolver, WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType, PWINHTTP_PROXY_SETTINGS_PARAM
	// pProxySettingsParam, DWORD_PTR pContext );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxySettingsEx")]
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error WinHttpGetProxySettingsEx(HINTERNET hResolver, WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType,
		in WINHTTP_PROXY_SETTINGS_PARAM pProxySettingsParam, [In, Optional] IntPtr pContext);

	/// <summary>Retrieves extended proxy settings.</summary>
	/// <param name="hResolver">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>The WinHTTP resolver handle returned by the WinHttpCreateProxyResolver function.</para>
	/// </param>
	/// <param name="ProxySettingsType">
	/// <para>Type: _In_ <c>WINHTTP_PROXY_SETTINGS_TYPE</c></para>
	/// <para>A proxy settings type.</para>
	/// </param>
	/// <param name="pProxySettingsParam">
	/// <para>Type: _In_opt_ <c>PWINHTTP_PROXY_SETTINGS_PARAM</c></para>
	/// <para>An optional pointer to a WINHTTP_PROXY_SETTINGS_PARAM.</para>
	/// </param>
	/// <param name="pContext">
	/// <para>Type: _In_opt_ <c>DWORD_PTR</c></para>
	/// <para>An optional pointer to a <c>DWORD</c> containing context data that will be passed to the completion callback function.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// A <c>DWORD</c> containing a status code indicating the result of the operation. The following codes can be returned (the list is not exhaustive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_IO_PENDING</term>
	/// <term>The operation is continuing asynchronously.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxysettingsex WINHTTPAPI DWORD
	// WinHttpGetProxySettingsEx( HINTERNET hResolver, WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType, PWINHTTP_PROXY_SETTINGS_PARAM
	// pProxySettingsParam, DWORD_PTR pContext );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxySettingsEx")]
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error WinHttpGetProxySettingsEx(HINTERNET hResolver, WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType,
		[In, Optional] IntPtr pProxySettingsParam, [In, Optional] IntPtr pContext);

	/// <summary>Retrieves the results of a call to WinHttpGetProxySettingsEx.</summary>
	/// <param name="hResolver">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>The WinHTTP resolver handle returned by the WinHttpCreateProxyResolver function.</para>
	/// </param>
	/// <param name="ProxySettingsType">
	/// <para>Type: _In_ <c>WINHTTP_PROXY_SETTINGS_TYPE</c></para>
	/// <para>A proxy settings type.</para>
	/// </param>
	/// <param name="pProxySettingsParam">
	/// <para>Type: _In_opt_ <c>PWINHTTP_PROXY_SETTINGS_PARAM</c></para>
	/// <para>An optional WINHTTP_PROXY_SETTINGS_PARAM.</para>
	/// </param>
	/// <param name="pProxySettingsEx">A WINHTTP_PROXY_SETTINGS_EX structure.</param>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxysettingsresultex WINHTTPAPI DWORD
	// WinHttpGetProxySettingsResultEx( HINTERNET hResolver, PVOID pProxySettingsEx );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxySettingsResultEx")]
	public static Win32Error WinHttpGetProxySettingsEx(HINTERNET hResolver, WINHTTP_PROXY_SETTINGS_TYPE ProxySettingsType,
		WINHTTP_PROXY_SETTINGS_PARAM? pProxySettingsParam, out WINHTTP_PROXY_SETTINGS_EX_MGD pProxySettingsEx)
	{
		pProxySettingsEx = default;
		using var pParam = pProxySettingsParam.HasValue ? new SafeCoTaskMemStruct<WINHTTP_PROXY_SETTINGS_PARAM>(pProxySettingsParam.Value) : SafeCoTaskMemStruct<WINHTTP_PROXY_SETTINGS_PARAM>.Null;
		var ret = WinHttpGetProxySettingsEx(hResolver, ProxySettingsType, pParam, default);
		if (ret.Failed)
			return ret;
		IntPtr ptr = default;
		ret = WinHttpGetProxySettingsResultEx(hResolver, ptr);
		if (ret.Failed)
			return ret;
		pProxySettingsEx = ptr.ToStructure<WINHTTP_PROXY_SETTINGS_EX>();
		WinHttpFreeProxySettingsEx(ProxySettingsType, ptr);
		return ret;
	}

	/// <summary>Retrieves the results of a call to WinHttpGetProxySettingsEx.</summary>
	/// <param name="hResolver">
	/// <para>Type: _In_ <c>HINTERNET</c></para>
	/// <para>The resolver handle used to issue a previously completed call to WinHttpGetProxySettingsEx.</para>
	/// </param>
	/// <param name="pProxySettingsEx">
	/// A pointer to a WINHTTP_PROXY_SETTINGS_EX structure. The memory occupied by the structure is allocated by
	/// <c>WinHttpGetProxySettingsResultEx</c>, so you need to free that memory by passing this pointer to WinHttpFreeProxySettingsEx.
	/// </param>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpgetproxysettingsresultex
	// WINHTTPAPI DWORD WinHttpGetProxySettingsResultEx( HINTERNET hResolver, PVOID pProxySettingsEx );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpGetProxySettingsResultEx")]
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error WinHttpGetProxySettingsResultEx(HINTERNET hResolver, IntPtr pProxySettingsEx);

	/// <summary>The <c>WinHttpQueryOption</c> function queries an Internet option on the specified handle.</summary>
	/// <param name="hInternet">
	/// An <c>HINTERNET</c> handle on which to query information. Note that this can be either a Session handle or a Request handle,
	/// depending on what option is being queried; see the Option Flags topic to determine which handle is appropriate to use in querying a
	/// particular option.
	/// </param>
	/// <param name="dwOption">
	/// An unsigned long integer value that contains the Internet option to query. This can be one of the Option Flags values.
	/// </param>
	/// <param name="lpBuffer">
	/// A pointer to a buffer that receives the option setting. Strings returned by the <c>WinHttpQueryOption</c> function are globally
	/// allocated, so the calling application must globally free the string when it finishes using it. Setting this parameter to <c>NULL</c>
	/// causes this function to return <c>FALSE</c>. Calling GetLastError then returns ERROR_INSUFFICIENT_BUFFER and <c>lpdwBufferLength</c>
	/// contains the number of bytes required to hold the requested information.
	/// </param>
	/// <param name="lpdwBufferLength">
	/// A pointer to an unsigned long integer variable that contains the length of <c>lpBuffer</c>, in bytes. When the function returns, the
	/// variable receives the length of the data placed into <c>lpBuffer</c>. If GetLastError returns ERROR_INSUFFICIENT_BUFFER, this
	/// parameter receives the number of bytes required to hold the requested information.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError. Among the error
	/// codes returned are the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
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
	/// <term><c>ERROR_WINHTTP_INVALID_OPTION</c></term>
	/// <term>An invalid option value was specified.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// GetLastError returns the ERROR_INVALID_PARAMETER if an option flag that is invalid for the specified handle type is passed to the
	/// <c>dwOption</c> parameter.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>This example demonstrates retrieving the connection time-out value:</para>
	/// <para>
	/// <code> DWORD data; DWORD dwSize = sizeof(DWORD); // Use WinHttpOpen to obtain an HINTERNET handle. HINTERNET hSession = WinHttpOpen(L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); if (hSession) { // Use WinHttpQueryOption to retrieve internet options. if (WinHttpQueryOption( hSession, WINHTTP_OPTION_CONNECT_TIMEOUT, &amp;data, &amp;dwSize)) { printf("Connection timeout: %u ms\n\n",data); } else { printf( "Error %u in WinHttpQueryOption.\n", GetLastError()); } // When finished, release the HINTERNET handle. WinHttpCloseHandle(hSession); } else { printf("Error %u in WinHttpOpen.\n", GetLastError()); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryoption BOOL WinHttpQueryOption( [in] HINTERNET
	// hInternet, [in] DWORD dwOption, [out] LPVOID lpBuffer, [in, out] LPDWORD lpdwBufferLength );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryOption")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpQueryOption(HINTERNET hInternet, WINHTTP_OPTION dwOption, [Out, Optional] IntPtr lpBuffer, ref uint lpdwBufferLength);

	/// <summary>The <c>WinHttpQueryOption</c> function queries an Internet option on the specified handle.</summary>
	/// <typeparam name="T">The type of the option.</typeparam>
	/// <param name="hInternet">
	/// An <c>HINTERNET</c> handle on which to query information. Note that this can be either a Session handle or a Request handle,
	/// depending on what option is being queried; see the Option Flags topic to determine which handle is appropriate to use in querying a
	/// particular option.
	/// </param>
	/// <param name="dwOption">
	/// An unsigned long integer value that contains the Internet option to query. This can be one of the Option Flags values.
	/// </param>
	/// <returns>The option setting.</returns>
	/// <remarks>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpqueryoption BOOL WinHttpQueryOption( [in] HINTERNET
	// hInternet, [in] DWORD dwOption, [out] LPVOID lpBuffer, [in, out] LPDWORD lpdwBufferLength );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryOption")]
	public static T WinHttpQueryOption<T>(HINTERNET hInternet, WINHTTP_OPTION dwOption)
	{
		Type rType = CorrespondingTypeAttribute.GetCorrespondingTypes(dwOption, CorrespondingAction.Get).FirstOrDefault() ?? typeof(T);
		if (typeof(T) != typeof(object))
		{
			rType = typeof(T);
		}

		uint sz = 0;
		WinHttpQueryOption(hInternet, dwOption, default, ref sz);
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		using SafeHGlobalHandle buffer = new(sz);
		Win32Error.ThrowLastErrorIfFalse(WinHttpQueryOption(hInternet, dwOption, buffer, ref sz));
		return (T)buffer.DangerousGetHandle().Convert(sz, rType, CharSet.Unicode)!;
	}

	/// <summary>Also see WinHttpReadDataEx.</summary>
	/// <param name="hRequest">
	/// Valid HINTERNET handle returned from a previous call to WinHttpOpenRequest. WinHttpReceiveResponse or WinHttpQueryDataAvailable must
	/// have been called for this handle and must have completed before <c>WinHttpReadData</c> is called. Although calling
	/// <c>WinHttpReadData</c> immediately after completion of <c>WinHttpReceiveResponse</c> avoids the expense of a buffer copy, doing so
	/// requires that the application use a fixed-length buffer for reading.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that receives the data read. Make sure that this buffer remains valid until <c>WinHttpReadData</c> has completed.
	/// </param>
	/// <param name="dwNumberOfBytesToRead">Unsigned long integer value that contains the number of bytes to read.</param>
	/// <param name="lpdwNumberOfBytesRead">
	/// Pointer to an unsigned long integer variable that receives the number of bytes read. <c>WinHttpReadData</c> sets this value to zero
	/// before doing any work or error checking. When using WinHTTP asynchronously, always set this parameter to <c>NULL</c> and retrieve the
	/// information in the callback function; not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. The following table
	/// identifies the error codes that are returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
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
	/// Starting in Windows Vista and Windows Server 2008, WinHttp enables applications to perform chunked transfer encoding on data sent to
	/// the server. When the Transfer-Encoding header is present on the WinHttp response, <c>WinHttpReadData</c> strips the chunking
	/// information before giving the data to the application.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, this function failed and you can call
	/// GetLastError to get extended error information. If this function returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_READ_COMPLETE
	/// completion to determine whether this function was successful and the value of the parameters. The
	/// WINHTTP_CALLBACK_STATUS_REQUEST_ERROR completion indicates that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When WinHTTP is used in asynchronous mode, always set the <c>lpdwNumberOfBytesRead</c> parameter to <c>NULL</c> and
	/// retrieve the bytes read in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// When the read buffer is very small, <c>WinHttpReadData</c> might complete synchronously. If the WINHTTP_CALLBACK_STATUS_READ_COMPLETE
	/// completion triggers another call to <c>WinHttpReadData</c>, the situation can result in a stack overflow. In general, it is best to
	/// use a read buffer that is comparable in size, or larger than the internal read buffer used by WinHTTP, which is 8 KB.
	/// </para>
	/// <para>
	/// If you are using <c>WinHttpReadData</c> synchronously, and the return value is <c>TRUE</c> and the number of bytes read is zero, the
	/// transfer has been completed and there are no more bytes to read on the handle. This is analogous to reaching end-of-file in a local
	/// file. If you are using the function asynchronously, the WINHTTP_CALLBACK_STATUS_READ_COMPLETE callback is called with the
	/// <c>dwStatusInformationLength</c> parameter set to zero when the end of a response is found.
	/// </para>
	/// <para>
	/// <c>WinHttpReadData</c> tries to fill the buffer pointed to by <c>lpBuffer</c> until there is no more data available from the
	/// response. If sufficient data has not arrived from the server, the buffer is not filled.
	/// </para>
	/// <para>
	/// For HINTERNET handles created by the WinHttpOpenRequest function and sent by WinHttpSendRequest, a call to WinHttpReceiveResponse
	/// must be made on the handle before <c>WinHttpReadData</c> can be used.
	/// </para>
	/// <para>Single byte characters retrieved with <c>WinHttpReadData</c> are not converted to multi-byte characters.</para>
	/// <para>
	/// When the read buffer is very small, <c>WinHttpReadData</c> may complete synchronously, and if the
	/// <c>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</c> completion then triggers another call to <c>WinHttpReadData</c>, a stack overflow can
	/// result. It is best to use a read buffer that is 8 Kilobytes or larger in size.
	/// </para>
	/// <para>
	/// If sufficient data has not arrived from the server, <c>WinHttpReadData</c> does not entirely fill the buffer pointed to by
	/// <c>lpBuffer</c>. The buffer must be large enough at least to hold the HTTP headers on the first read, and when reading HTML encoded
	/// directory entries, it must be large enough to hold at least one complete entry.
	/// </para>
	/// <para>
	/// If a status callback function has been installed by using WinHttpSetStatusCallback, then those of the following notifications that
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
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use secure transaction semantics to download a resource from an Secure Hypertext Transfer Protocol
	/// (HTTPS) server. The sample code initializes the WinHTTP application programming interface (API), selects a target HTTPS server, then
	/// opens and sends a request for this secure resource. WinHttpQueryDataAvailable is used with the request handle to determine how much
	/// data is available for download, then <c>WinHttpReadData</c> is used to read that data. This process repeats until the entire document
	/// has been retrieved and displayed.
	/// </para>
	/// <para>
	/// <code> DWORD dwSize = 0; DWORD dwDownloaded = 0; PSTR pszOutBuffer; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"WinHTTP Example/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0); // Create an HTTP request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE); // Send a request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Keep checking for data until there is nothing left. if (bResults) { do { // Check for available data. dwSize = 0; if (!WinHttpQueryDataAvailable( hRequest, &amp;dwSize)) { printf( "Error %u in WinHttpQueryDataAvailable.\n", GetLastError()); break; } // No more available data. if (!dwSize) break; // Allocate space for the buffer. pszOutBuffer = new char[dwSize+1]; if (!pszOutBuffer) { printf("Out of memory\n"); break; } // Read the Data. ZeroMemory(pszOutBuffer, dwSize+1); if (!WinHttpReadData( hRequest, (LPVOID)pszOutBuffer, dwSize, &amp;dwDownloaded)) { printf( "Error %u in WinHttpReadData.\n", GetLastError()); } else { printf("%s", pszOutBuffer); } // Free the memory allocated to the buffer. delete [] pszOutBuffer; // This condition should never be reached since WinHttpQueryDataAvailable // reported that there are bits to read. if (!dwDownloaded) break; } while (dwSize &gt; 0); } else { // Report any errors. printf( "Error %d has occurred.\n", GetLastError() ); } // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreaddata BOOL WinHttpReadData( [in] HINTERNET hRequest,
	// [out] LPVOID lpBuffer, [in] DWORD dwNumberOfBytesToRead, [out] LPDWORD lpdwNumberOfBytesRead );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReadData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpReadData(HINTERNET hRequest, [Out] IntPtr lpBuffer, uint dwNumberOfBytesToRead, out uint lpdwNumberOfBytesRead);

	/// <summary>Also see WinHttpReadDataEx.</summary>
	/// <param name="hRequest">
	/// Valid HINTERNET handle returned from a previous call to WinHttpOpenRequest. WinHttpReceiveResponse or WinHttpQueryDataAvailable must
	/// have been called for this handle and must have completed before <c>WinHttpReadData</c> is called. Although calling
	/// <c>WinHttpReadData</c> immediately after completion of <c>WinHttpReceiveResponse</c> avoids the expense of a buffer copy, doing so
	/// requires that the application use a fixed-length buffer for reading.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that receives the data read. Make sure that this buffer remains valid until <c>WinHttpReadData</c> has completed.
	/// </param>
	/// <param name="dwNumberOfBytesToRead">Unsigned long integer value that contains the number of bytes to read.</param>
	/// <param name="lpdwNumberOfBytesRead">
	/// Pointer to an unsigned long integer variable that receives the number of bytes read. <c>WinHttpReadData</c> sets this value to zero
	/// before doing any work or error checking. When using WinHTTP asynchronously, always set this parameter to <c>NULL</c> and retrieve the
	/// information in the callback function; not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. The following table
	/// identifies the error codes that are returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
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
	/// Starting in Windows Vista and Windows Server 2008, WinHttp enables applications to perform chunked transfer encoding on data sent to
	/// the server. When the Transfer-Encoding header is present on the WinHttp response, <c>WinHttpReadData</c> strips the chunking
	/// information before giving the data to the application.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, this function failed and you can call
	/// GetLastError to get extended error information. If this function returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_READ_COMPLETE
	/// completion to determine whether this function was successful and the value of the parameters. The
	/// WINHTTP_CALLBACK_STATUS_REQUEST_ERROR completion indicates that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When WinHTTP is used in asynchronous mode, always set the <c>lpdwNumberOfBytesRead</c> parameter to <c>NULL</c> and
	/// retrieve the bytes read in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// When the read buffer is very small, <c>WinHttpReadData</c> might complete synchronously. If the WINHTTP_CALLBACK_STATUS_READ_COMPLETE
	/// completion triggers another call to <c>WinHttpReadData</c>, the situation can result in a stack overflow. In general, it is best to
	/// use a read buffer that is comparable in size, or larger than the internal read buffer used by WinHTTP, which is 8 KB.
	/// </para>
	/// <para>
	/// If you are using <c>WinHttpReadData</c> synchronously, and the return value is <c>TRUE</c> and the number of bytes read is zero, the
	/// transfer has been completed and there are no more bytes to read on the handle. This is analogous to reaching end-of-file in a local
	/// file. If you are using the function asynchronously, the WINHTTP_CALLBACK_STATUS_READ_COMPLETE callback is called with the
	/// <c>dwStatusInformationLength</c> parameter set to zero when the end of a response is found.
	/// </para>
	/// <para>
	/// <c>WinHttpReadData</c> tries to fill the buffer pointed to by <c>lpBuffer</c> until there is no more data available from the
	/// response. If sufficient data has not arrived from the server, the buffer is not filled.
	/// </para>
	/// <para>
	/// For HINTERNET handles created by the WinHttpOpenRequest function and sent by WinHttpSendRequest, a call to WinHttpReceiveResponse
	/// must be made on the handle before <c>WinHttpReadData</c> can be used.
	/// </para>
	/// <para>Single byte characters retrieved with <c>WinHttpReadData</c> are not converted to multi-byte characters.</para>
	/// <para>
	/// When the read buffer is very small, <c>WinHttpReadData</c> may complete synchronously, and if the
	/// <c>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</c> completion then triggers another call to <c>WinHttpReadData</c>, a stack overflow can
	/// result. It is best to use a read buffer that is 8 Kilobytes or larger in size.
	/// </para>
	/// <para>
	/// If sufficient data has not arrived from the server, <c>WinHttpReadData</c> does not entirely fill the buffer pointed to by
	/// <c>lpBuffer</c>. The buffer must be large enough at least to hold the HTTP headers on the first read, and when reading HTML encoded
	/// directory entries, it must be large enough to hold at least one complete entry.
	/// </para>
	/// <para>
	/// If a status callback function has been installed by using WinHttpSetStatusCallback, then those of the following notifications that
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
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use secure transaction semantics to download a resource from an Secure Hypertext Transfer Protocol
	/// (HTTPS) server. The sample code initializes the WinHTTP application programming interface (API), selects a target HTTPS server, then
	/// opens and sends a request for this secure resource. WinHttpQueryDataAvailable is used with the request handle to determine how much
	/// data is available for download, then <c>WinHttpReadData</c> is used to read that data. This process repeats until the entire document
	/// has been retrieved and displayed.
	/// </para>
	/// <para>
	/// <code> DWORD dwSize = 0; DWORD dwDownloaded = 0; PSTR pszOutBuffer; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"WinHTTP Example/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0); // Create an HTTP request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE); // Send a request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Keep checking for data until there is nothing left. if (bResults) { do { // Check for available data. dwSize = 0; if (!WinHttpQueryDataAvailable( hRequest, &amp;dwSize)) { printf( "Error %u in WinHttpQueryDataAvailable.\n", GetLastError()); break; } // No more available data. if (!dwSize) break; // Allocate space for the buffer. pszOutBuffer = new char[dwSize+1]; if (!pszOutBuffer) { printf("Out of memory\n"); break; } // Read the Data. ZeroMemory(pszOutBuffer, dwSize+1); if (!WinHttpReadData( hRequest, (LPVOID)pszOutBuffer, dwSize, &amp;dwDownloaded)) { printf( "Error %u in WinHttpReadData.\n", GetLastError()); } else { printf("%s", pszOutBuffer); } // Free the memory allocated to the buffer. delete [] pszOutBuffer; // This condition should never be reached since WinHttpQueryDataAvailable // reported that there are bits to read. if (!dwDownloaded) break; } while (dwSize &gt; 0); } else { // Report any errors. printf( "Error %d has occurred.\n", GetLastError() ); } // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreaddata BOOL WinHttpReadData( [in] HINTERNET hRequest,
	// [out] LPVOID lpBuffer, [in] DWORD dwNumberOfBytesToRead, [out] LPDWORD lpdwNumberOfBytesRead );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReadData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpReadData(HINTERNET hRequest, [Out] IntPtr lpBuffer, uint dwNumberOfBytesToRead, [Optional] IntPtr lpdwNumberOfBytesRead);

	/// <summary>Also see WinHttpReadDataEx.</summary>
	/// <param name="hRequest">
	/// Valid HINTERNET handle returned from a previous call to WinHttpOpenRequest. WinHttpReceiveResponse or WinHttpQueryDataAvailable must
	/// have been called for this handle and must have completed before <c>WinHttpReadData</c> is called. Although calling
	/// <c>WinHttpReadData</c> immediately after completion of <c>WinHttpReceiveResponse</c> avoids the expense of a buffer copy, doing so
	/// requires that the application use a fixed-length buffer for reading.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that receives the data read. Make sure that this buffer remains valid until <c>WinHttpReadData</c> has completed.
	/// </param>
	/// <param name="dwNumberOfBytesToRead">Unsigned long integer value that contains the number of bytes to read.</param>
	/// <param name="lpdwNumberOfBytesRead">
	/// Pointer to an unsigned long integer variable that receives the number of bytes read. <c>WinHttpReadData</c> sets this value to zero
	/// before doing any work or error checking. When using WinHTTP asynchronously, always set this parameter to <c>NULL</c> and retrieve the
	/// information in the callback function; not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. The following table
	/// identifies the error codes that are returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
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
	/// Starting in Windows Vista and Windows Server 2008, WinHttp enables applications to perform chunked transfer encoding on data sent to
	/// the server. When the Transfer-Encoding header is present on the WinHttp response, <c>WinHttpReadData</c> strips the chunking
	/// information before giving the data to the application.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, this function failed and you can call
	/// GetLastError to get extended error information. If this function returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_READ_COMPLETE
	/// completion to determine whether this function was successful and the value of the parameters. The
	/// WINHTTP_CALLBACK_STATUS_REQUEST_ERROR completion indicates that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When WinHTTP is used in asynchronous mode, always set the <c>lpdwNumberOfBytesRead</c> parameter to <c>NULL</c> and
	/// retrieve the bytes read in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// When the read buffer is very small, <c>WinHttpReadData</c> might complete synchronously. If the WINHTTP_CALLBACK_STATUS_READ_COMPLETE
	/// completion triggers another call to <c>WinHttpReadData</c>, the situation can result in a stack overflow. In general, it is best to
	/// use a read buffer that is comparable in size, or larger than the internal read buffer used by WinHTTP, which is 8 KB.
	/// </para>
	/// <para>
	/// If you are using <c>WinHttpReadData</c> synchronously, and the return value is <c>TRUE</c> and the number of bytes read is zero, the
	/// transfer has been completed and there are no more bytes to read on the handle. This is analogous to reaching end-of-file in a local
	/// file. If you are using the function asynchronously, the WINHTTP_CALLBACK_STATUS_READ_COMPLETE callback is called with the
	/// <c>dwStatusInformationLength</c> parameter set to zero when the end of a response is found.
	/// </para>
	/// <para>
	/// <c>WinHttpReadData</c> tries to fill the buffer pointed to by <c>lpBuffer</c> until there is no more data available from the
	/// response. If sufficient data has not arrived from the server, the buffer is not filled.
	/// </para>
	/// <para>
	/// For HINTERNET handles created by the WinHttpOpenRequest function and sent by WinHttpSendRequest, a call to WinHttpReceiveResponse
	/// must be made on the handle before <c>WinHttpReadData</c> can be used.
	/// </para>
	/// <para>Single byte characters retrieved with <c>WinHttpReadData</c> are not converted to multi-byte characters.</para>
	/// <para>
	/// When the read buffer is very small, <c>WinHttpReadData</c> may complete synchronously, and if the
	/// <c>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</c> completion then triggers another call to <c>WinHttpReadData</c>, a stack overflow can
	/// result. It is best to use a read buffer that is 8 Kilobytes or larger in size.
	/// </para>
	/// <para>
	/// If sufficient data has not arrived from the server, <c>WinHttpReadData</c> does not entirely fill the buffer pointed to by
	/// <c>lpBuffer</c>. The buffer must be large enough at least to hold the HTTP headers on the first read, and when reading HTML encoded
	/// directory entries, it must be large enough to hold at least one complete entry.
	/// </para>
	/// <para>
	/// If a status callback function has been installed by using WinHttpSetStatusCallback, then those of the following notifications that
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
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use secure transaction semantics to download a resource from an Secure Hypertext Transfer Protocol
	/// (HTTPS) server. The sample code initializes the WinHTTP application programming interface (API), selects a target HTTPS server, then
	/// opens and sends a request for this secure resource. WinHttpQueryDataAvailable is used with the request handle to determine how much
	/// data is available for download, then <c>WinHttpReadData</c> is used to read that data. This process repeats until the entire document
	/// has been retrieved and displayed.
	/// </para>
	/// <para>
	/// <code> DWORD dwSize = 0; DWORD dwDownloaded = 0; PSTR pszOutBuffer; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"WinHTTP Example/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.microsoft.com", INTERNET_DEFAULT_HTTPS_PORT, 0); // Create an HTTP request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"GET", NULL, NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, WINHTTP_FLAG_SECURE); // Send a request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Keep checking for data until there is nothing left. if (bResults) { do { // Check for available data. dwSize = 0; if (!WinHttpQueryDataAvailable( hRequest, &amp;dwSize)) { printf( "Error %u in WinHttpQueryDataAvailable.\n", GetLastError()); break; } // No more available data. if (!dwSize) break; // Allocate space for the buffer. pszOutBuffer = new char[dwSize+1]; if (!pszOutBuffer) { printf("Out of memory\n"); break; } // Read the Data. ZeroMemory(pszOutBuffer, dwSize+1); if (!WinHttpReadData( hRequest, (LPVOID)pszOutBuffer, dwSize, &amp;dwDownloaded)) { printf( "Error %u in WinHttpReadData.\n", GetLastError()); } else { printf("%s", pszOutBuffer); } // Free the memory allocated to the buffer. delete [] pszOutBuffer; // This condition should never be reached since WinHttpQueryDataAvailable // reported that there are bits to read. if (!dwDownloaded) break; } while (dwSize &gt; 0); } else { // Report any errors. printf( "Error %d has occurred.\n", GetLastError() ); } // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreaddata BOOL WinHttpReadData( [in] HINTERNET hRequest,
	// [out] LPVOID lpBuffer, [in] DWORD dwNumberOfBytesToRead, [out] LPDWORD lpdwNumberOfBytesRead );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReadData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpReadData(HINTERNET hRequest, [Out] byte[] lpBuffer, int dwNumberOfBytesToRead, out int lpdwNumberOfBytesRead);

	/// <summary>Reads data from a handle opened by the WinHttpOpenRequest function.</summary>
	/// <param name="hRequest">
	/// <para>Type: IN <c>HINTERNET</c></para>
	/// <para>An <c>HINTERNET</c> handle returned from a previous call to WinHttpOpenRequest.</para>
	/// <para>
	/// WinHttpReceiveResponse or WinHttpQueryDataAvailable must have been called for this handle and must have completed before
	/// <c>WinHttpReadDataEx</c> is called. Although calling <c>WinHttpReadDataEx</c> immediately after completion of
	/// <c>WinHttpReceiveResponse</c> avoids the expense of a buffer copy, doing so requires that your application use a fixed-length buffer
	/// for reading.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>Type: _Out_writes_bytes_to_(dwNumberOfBytesToRead, *lpdwNumberOfBytesRead) __out_data_source(NETWORK) <c>LPVOID</c></para>
	/// <para>
	/// Pointer to a buffer that receives the data read. Make sure that this buffer remains valid until <c>WinHttpReadDataEx</c> has completed.
	/// </para>
	/// </param>
	/// <param name="dwNumberOfBytesToRead">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>Unsigned long integer value that contains the number of bytes to read.</para>
	/// </param>
	/// <param name="lpdwNumberOfBytesRead">
	/// <para>Type: OUT <c>LPDWORD</c></para>
	/// <para>
	/// Pointer to an unsigned long integer variable that receives the number of bytes read. <c>WinHttpReadDataEx</c> sets this value to zero
	/// before doing any work or error checking. When using WinHTTP asynchronously, always set this parameter to <c>NULL</c> and retrieve the
	/// information in the callback function; not doing so can cause a memory fault.
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: IN <c>ULONGLONG</c></para>
	/// <para>
	/// If you pass <c>WINHTTP_READ_DATA_EX_FLAG_FILL_BUFFER</c>, then WinHttp won't complete the call to <c>WinHttpReadDataEx</c> until the
	/// provided data buffer has been filled, or the response is complete. Passing this flag makes the behavior of this API equivalent to
	/// that of WinHttpReadData.
	/// </para>
	/// </param>
	/// <param name="cbProperty">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>Reserved. Pass 0.</para>
	/// </param>
	/// <param name="pvProperty">
	/// <para>Type: _In_reads_bytes_opt_(cbProperty) <c>PVOID</c></para>
	/// <para>Reserved. Pass NULL.</para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation. Among the error codes returned are the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
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
	/// By default, <c>WinHttpReadDataEx</c> returns after any amount of data has been written to the buffer that you provide (the function
	/// won't always completely fill the buffer that you provide).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreaddataex WINHTTPAPI DWORD WinHttpReadDataEx( HINTERNET
	// hRequest, LPVOID lpBuffer, DWORD dwNumberOfBytesToRead, LPDWORD lpdwNumberOfBytesRead, ULONGLONG ullFlags, DWORD cbProperty, PVOID
	// pvProperty );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReadDataEx")]
	public static extern Win32Error WinHttpReadDataEx(HINTERNET hRequest, [Out] IntPtr lpBuffer, uint dwNumberOfBytesToRead,
		out uint lpdwNumberOfBytesRead, [Optional] WINHTTP_READ_DATA_EX_FLAG ullFlags, [Optional] uint cbProperty, [Optional] IntPtr pvProperty);

	/// <summary>Reads data from a handle opened by the WinHttpOpenRequest function.</summary>
	/// <param name="hRequest">
	/// <para>Type: IN <c>HINTERNET</c></para>
	/// <para>An <c>HINTERNET</c> handle returned from a previous call to WinHttpOpenRequest.</para>
	/// <para>
	/// WinHttpReceiveResponse or WinHttpQueryDataAvailable must have been called for this handle and must have completed before
	/// <c>WinHttpReadDataEx</c> is called. Although calling <c>WinHttpReadDataEx</c> immediately after completion of
	/// <c>WinHttpReceiveResponse</c> avoids the expense of a buffer copy, doing so requires that your application use a fixed-length buffer
	/// for reading.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>Type: _Out_writes_bytes_to_(dwNumberOfBytesToRead, *lpdwNumberOfBytesRead) __out_data_source(NETWORK) <c>LPVOID</c></para>
	/// <para>
	/// Pointer to a buffer that receives the data read. Make sure that this buffer remains valid until <c>WinHttpReadDataEx</c> has completed.
	/// </para>
	/// </param>
	/// <param name="dwNumberOfBytesToRead">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>Unsigned long integer value that contains the number of bytes to read.</para>
	/// </param>
	/// <param name="lpdwNumberOfBytesRead">
	/// <para>Type: OUT <c>LPDWORD</c></para>
	/// <para>
	/// Pointer to an unsigned long integer variable that receives the number of bytes read. <c>WinHttpReadDataEx</c> sets this value to zero
	/// before doing any work or error checking. When using WinHTTP asynchronously, always set this parameter to <c>NULL</c> and retrieve the
	/// information in the callback function; not doing so can cause a memory fault.
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: IN <c>ULONGLONG</c></para>
	/// <para>
	/// If you pass <c>WINHTTP_READ_DATA_EX_FLAG_FILL_BUFFER</c>, then WinHttp won't complete the call to <c>WinHttpReadDataEx</c> until the
	/// provided data buffer has been filled, or the response is complete. Passing this flag makes the behavior of this API equivalent to
	/// that of WinHttpReadData.
	/// </para>
	/// </param>
	/// <param name="cbProperty">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>Reserved. Pass 0.</para>
	/// </param>
	/// <param name="pvProperty">
	/// <para>Type: _In_reads_bytes_opt_(cbProperty) <c>PVOID</c></para>
	/// <para>Reserved. Pass NULL.</para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation. Among the error codes returned are the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
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
	/// By default, <c>WinHttpReadDataEx</c> returns after any amount of data has been written to the buffer that you provide (the function
	/// won't always completely fill the buffer that you provide).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreaddataex WINHTTPAPI DWORD WinHttpReadDataEx( HINTERNET
	// hRequest, LPVOID lpBuffer, DWORD dwNumberOfBytesToRead, LPDWORD lpdwNumberOfBytesRead, ULONGLONG ullFlags, DWORD cbProperty, PVOID
	// pvProperty );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReadDataEx")]
	public static extern Win32Error WinHttpReadDataEx(HINTERNET hRequest, [Out] IntPtr lpBuffer, uint dwNumberOfBytesToRead,
		[In, Optional] IntPtr lpdwNumberOfBytesRead, [Optional] WINHTTP_READ_DATA_EX_FLAG ullFlags, [Optional] uint cbProperty, [Optional] IntPtr pvProperty);

	/// <summary>Reads data from a handle opened by the WinHttpOpenRequest function.</summary>
	/// <param name="hRequest">
	/// <para>Type: IN <c>HINTERNET</c></para>
	/// <para>An <c>HINTERNET</c> handle returned from a previous call to WinHttpOpenRequest.</para>
	/// <para>
	/// WinHttpReceiveResponse or WinHttpQueryDataAvailable must have been called for this handle and must have completed before
	/// <c>WinHttpReadDataEx</c> is called. Although calling <c>WinHttpReadDataEx</c> immediately after completion of
	/// <c>WinHttpReceiveResponse</c> avoids the expense of a buffer copy, doing so requires that your application use a fixed-length buffer
	/// for reading.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>Type: _Out_writes_bytes_to_(dwNumberOfBytesToRead, *lpdwNumberOfBytesRead) __out_data_source(NETWORK) <c>LPVOID</c></para>
	/// <para>
	/// Pointer to a buffer that receives the data read. Make sure that this buffer remains valid until <c>WinHttpReadDataEx</c> has completed.
	/// </para>
	/// </param>
	/// <param name="dwNumberOfBytesToRead">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>Unsigned long integer value that contains the number of bytes to read.</para>
	/// </param>
	/// <param name="lpdwNumberOfBytesRead">
	/// <para>Type: OUT <c>LPDWORD</c></para>
	/// <para>
	/// Pointer to an unsigned long integer variable that receives the number of bytes read. <c>WinHttpReadDataEx</c> sets this value to zero
	/// before doing any work or error checking. When using WinHTTP asynchronously, always set this parameter to <c>NULL</c> and retrieve the
	/// information in the callback function; not doing so can cause a memory fault.
	/// </para>
	/// </param>
	/// <param name="ullFlags">
	/// <para>Type: IN <c>ULONGLONG</c></para>
	/// <para>
	/// If you pass <c>WINHTTP_READ_DATA_EX_FLAG_FILL_BUFFER</c>, then WinHttp won't complete the call to <c>WinHttpReadDataEx</c> until the
	/// provided data buffer has been filled, or the response is complete. Passing this flag makes the behavior of this API equivalent to
	/// that of WinHttpReadData.
	/// </para>
	/// </param>
	/// <param name="cbProperty">
	/// <para>Type: IN <c>DWORD</c></para>
	/// <para>Reserved. Pass 0.</para>
	/// </param>
	/// <param name="pvProperty">
	/// <para>Type: _In_reads_bytes_opt_(cbProperty) <c>PVOID</c></para>
	/// <para>Reserved. Pass NULL.</para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating the result of the operation. Among the error codes returned are the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
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
	/// By default, <c>WinHttpReadDataEx</c> returns after any amount of data has been written to the buffer that you provide (the function
	/// won't always completely fill the buffer that you provide).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreaddataex WINHTTPAPI DWORD WinHttpReadDataEx( HINTERNET
	// hRequest, LPVOID lpBuffer, DWORD dwNumberOfBytesToRead, LPDWORD lpdwNumberOfBytesRead, ULONGLONG ullFlags, DWORD cbProperty, PVOID
	// pvProperty );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReadDataEx")]
	public static extern Win32Error WinHttpReadDataEx(HINTERNET hRequest, [Out] byte[] lpBuffer, int dwNumberOfBytesToRead,
		out int lpdwNumberOfBytesRead, [Optional] WINHTTP_READ_DATA_EX_FLAG ullFlags, [Optional] uint cbProperty, [Optional] IntPtr pvProperty);

	/// <summary>
	/// The <c>WinHttpReceiveResponse</c> function waits to receive the response to an HTTP request initiated by WinHttpSendRequest. When
	/// <c>WinHttpReceiveResponse</c> completes successfully, the status code and response headers have been received and are available for
	/// the application to inspect using WinHttpQueryHeaders. An application must call <c>WinHttpReceiveResponse</c> before it can use
	/// WinHttpQueryDataAvailable and WinHttpReadData to access the response entity body (if any).
	/// </summary>
	/// <param name="hRequest">
	/// HINTERNET handle returned by WinHttpOpenRequest and sent by WinHttpSendRequest. Wait until <c>WinHttpSendRequest</c> has completed
	/// for this handle before calling <c>WinHttpReceiveResponse</c>.
	/// </param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
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
	/// <term><c>ERROR_WINHTTP_CANNOT_CONNECT</c></term>
	/// <term>Returned if connection to the server failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CHUNKED_ENCODING_HEADER_SIZE_OVERFLOW</c></term>
	/// <term>Returned when an overflow condition is encountered in the course of parsing chunked encoding.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED</c></term>
	/// <term>Returned when the server requests client authentication.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// version 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_HEADER_COUNT_EXCEEDED</c></term>
	/// <term>Returned when a larger number of headers were present in a response than WinHTTP could receive.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_HEADER_SIZE_OVERFLOW</c></term>
	/// <term>Returned by WinHttpReceiveResponse when the size of headers received exceeds the limit for the request handle.</term>
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
	/// <term><c>ERROR_WINHTTP_INVALID_SERVER_RESPONSE</c></term>
	/// <term>The server response could not be parsed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INVALID_URL</c></term>
	/// <term>The URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_LOGIN_FAILURE</c></term>
	/// <term>
	/// The login attempt failed. When this error is encountered, the request handle should be closed with WinHttpCloseHandle. A new request
	/// handle must be created before retrying the function that originally produced this error.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_NAME_NOT_RESOLVED</c></term>
	/// <term>The server name could not be resolved.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_REDIRECT_FAILED</c></term>
	/// <term>The redirection failed because either the scheme changed or all attempts made to redirect failed (default is five attempts).</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESEND_REQUEST</c></term>
	/// <term>The WinHTTP function failed. The desired function can be retried on the same request handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_SECURE_FAILURE</c></term>
	/// <term>
	/// One or more errors were found in the Secure Sockets Layer (SSL) certificate sent by the server. To determine what type of error was
	/// encountered, check for a WINHTTP_CALLBACK_STATUS_SECURE_FAILURE notification in a status callback function. For more information, see WINHTTP_STATUS_CALLBACK.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_TIMEOUT</c></term>
	/// <term>The request has timed out.</term>
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
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, this function failed and you can call
	/// GetLastError to get extended error information. If this function returns <c>TRUE</c>, the application should expect either the
	/// <c>WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE</c> completion callback, indicating success, or the
	/// <c>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</c> completion callback, indicating that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then those of the following notifications that have
	/// been set in the <c>dwNotificationFlags</c> parameter of <c>WinHttpSetStatusCallback</c> indicate progress in receiving the response:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REDIRECT</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the server closes the connection, the following notifications will also be reported, provided that they have been set in the
	/// <c>dwNotificationFlags</c> parameter of WinHttpSetStatusCallback:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// This example shows code that writes data to an HTTP server. The server name supplied in the example, www.wingtiptoys.com, is
	/// fictitious and must be replaced with the name of a server for which you have write access.
	/// </para>
	/// <para>
	/// <code> PSTR pszData = "WinHttpWriteData Example"; DWORD dwBytesWritten = 0; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.wingtiptoys.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP Request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"PUT", L"/writetst.txt", NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a Request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, (DWORD)strlen(pszData), 0); // Write data to the server. if (bResults) bResults = WinHttpWriteData( hRequest, pszData, (DWORD)strlen(pszData), &amp;dwBytesWritten); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Report any errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpreceiveresponse WINHTTPAPI BOOL WinHttpReceiveResponse(
	// [in] HINTERNET hRequest, [in] LPVOID lpReserved );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpReceiveResponse")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpReceiveResponse(HINTERNET hRequest, [In, Optional] IntPtr lpReserved);

	/// <summary>Registers a callback function that WinHTTP calls when the effective proxy settings change.</summary>
	/// <param name="ullFlags">
	/// <para>Type: _In_ <c>ULONGLONG</c></para>
	/// <para>The flag to pass to the callback (for example, <c>WINHTTP_PROXY_NOTIFY_CHANGE</c>).</para>
	/// </param>
	/// <param name="pfnCallback">
	/// <para>Type: _In_ <c>WINHTTP_PROXY_CHANGE_CALLBACK</c></para>
	/// <para>A pointer to the callback function that should be called when the effective proxy settings change.</para>
	/// </param>
	/// <param name="pvContext">
	/// <para>Type: _In_ <c>PVOID</c></para>
	/// <para>A pointer to a context object to pass to the callback.</para>
	/// </param>
	/// <param name="hRegistration">
	/// <para>Type: _Out_ <c>WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE*</c></para>
	/// <para>
	/// A handle that identifies the registration of the callback function. To unregister, pass this value to
	/// WinHttpUnregisterProxyChangeNotification. <c>WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE</c> is equivalent to PVOID.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// A <c>DWORD</c> containing a status code indicating the result of the operation. The following codes can be returned (the list is not exhaustive).
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpregisterproxychangenotification WINHTTPAPI DWORD
	// WinHttpRegisterProxyChangeNotification( ULONGLONG ullFlags, WINHTTP_PROXY_CHANGE_CALLBACK pfnCallback, PVOID pvContext,
	// WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE *hRegistration );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpRegisterProxyChangeNotification")]
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error WinHttpRegisterProxyChangeNotification(ulong ullFlags,
		WINHTTP_PROXY_CHANGE_CALLBACK pfnCallback, IntPtr pvContext,
		ref WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE hRegistration);

	/// <summary>The <c>WinHttpResetAutoProxy</c> function resets the auto-proxy.</summary>
	/// <param name="hSession">A valid HINTERNET WinHTTP session handle returned by a previous call to the WinHttpOpen function.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that affects the reset operation.</para>
	/// <para>The following flags are supported as defined in the <c>Winhttp.h</c> header file.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_RESET_STATE</c> 0x00000001</term>
	/// <term>Forces a flush and retry of non-persistent proxy information on the current network.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_RESET_SWPAD_CURRENT_NETWORK</c> 0x00000002</term>
	/// <term>Flush the PAD information for the current network.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_RESET_SWPAD_ALL</c> 0x00000004</term>
	/// <term>Flush the PAD information for all networks.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_RESET_SCRIPT_CACHE</c> 0x00000008</term>
	/// <term>Flush the persistent HTTP cache of proxy scripts.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_RESET_ALL</c> 0x0000FFFF</term>
	/// <term>Forces a flush and retry of all proxy information on the current network.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_RESET_NOTIFY_NETWORK_CHANGED</c> 0x00010000</term>
	/// <term>Flush the current proxy information and notify that the network changed.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_RESET_OUT_OF_PROC</c> 0x00020000</term>
	/// <term>
	/// Act on the autoproxy service instead of the current process. Applications that use the WinHttpGetProxyForUrl function to purge
	/// in-process caching should close the <c>hInternet</c> handle and open a new handle for future calls.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>A code indicating the success or failure of the operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_SUCCESS</c></term>
	/// <term>The operation was successful.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>hSession</c> parameter is not a valid handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_INCORRECT_HANDLE TYPE</c></term>
	/// <term>The <c>hSession</c> parameter is not the product of a call to WinHttpOpen.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>To reset everything, set the <c>dwFlags</c> parameter to include <c>WINHTTP_RESET_ALL</c> and <c>WINHTTP_RESET_OUT_OF_PROC</c>.</para>
	/// <para>
	/// <c>Note</c> If you make subsequent calls to the <c>WinHttpResetAutoProxy</c> function, there must be at least 30 seconds delay
	/// between calls to reset the state of the auto-proxy. If there is less than 30 seconds, the <c>WinHttpResetAutoProxy</c> function call
	/// may return <c>ERROR_SUCCESS</c> but the reset won't happen.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpresetautoproxy WINHTTPAPI DWORD WinHttpResetAutoProxy(
	// [in] HINTERNET hSession, [in] DWORD dwFlags );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpResetAutoProxy")]
	public static extern Win32Error WinHttpResetAutoProxy(HINTERNET hSession, WINHTTP_RESET dwFlags);

	/// <summary>The <c>WinHttpSendRequest</c> function sends the specified request to the HTTP server.</summary>
	/// <param name="hRequest">An HINTERNET handle returned by WinHttpOpenRequest.</param>
	/// <param name="lpszHeaders">
	/// A pointer to a string that contains the additional headers to append to the request. This parameter can be
	/// <c>WINHTTP_NO_ADDITIONAL_HEADERS</c> if there are no additional headers to append.
	/// </param>
	/// <param name="dwHeadersLength">
	/// An unsigned long integer value that contains the length, in characters, of the additional headers. If this parameter is <c>-1L</c>
	/// and <c>pwszHeaders</c> is not <c>NULL</c>, this function assumes that <c>pwszHeaders</c> is <c>null</c>-terminated, and the length is calculated.
	/// </param>
	/// <param name="lpOptional">
	/// <para>
	/// A pointer to a buffer that contains any optional data to send immediately after the request headers. This parameter is generally used
	/// for POST and PUT operations. The optional data can be the resource or data posted to the server. This parameter can be
	/// <c>WINHTTP_NO_REQUEST_DATA</c> if there is no optional data to send.
	/// </para>
	/// <para>If the <c>dwOptionalLength</c> parameter is 0, this parameter is ignored and set to <c>NULL</c>.</para>
	/// <para>This buffer must remain available until the request handle is closed or the call to WinHttpReceiveResponse has completed.</para>
	/// </param>
	/// <param name="dwOptionalLength">
	/// <para>
	/// An unsigned long integer value that contains the length, in bytes, of the optional data. This parameter can be zero if there is no
	/// optional data to send.
	/// </para>
	/// <para>
	/// This parameter must contain a valid length when the <c>lpOptional</c> parameter is not <c>NULL</c>. Otherwise, <c>lpOptional</c> is
	/// ignored and set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwTotalLength">
	/// <para>
	/// An unsigned long integer value that contains the length, in bytes, of the total data sent. This parameter specifies the
	/// Content-Length header of the request. If the value of this parameter is greater than the length specified by <c>dwOptionalLength</c>,
	/// then WinHttpWriteData can be used to send additional data.
	/// </para>
	/// <para>
	/// <c>dwTotalLength</c> must not change between calls to <c>WinHttpSendRequest</c> for the same request. If <c>dwTotalLength</c> needs
	/// to be changed, the caller should create a new request.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// A pointer to a pointer-sized variable that contains an application-defined value that is passed, with the request handle, to any
	/// callback functions.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Error codes are
	/// listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CANNOT_CONNECT</c></term>
	/// <term>Returned if connection to the server failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED</c></term>
	/// <term>
	/// The secure HTTP server requires a client certificate. The application retrieves the list of certificate issuers by calling
	/// WinHttpQueryOption with the <c>WINHTTP_OPTION_CLIENT_CERT_ISSUER_LIST</c> option. If the server requests the client certificate, but
	/// does not require it, the application can alternately call WinHttpSetOption with the <c>WINHTTP_OPTION_CLIENT_CERT_CONTEXT</c> option.
	/// In this case, the application specifies the WINHTTP_NO_CLIENT_CERT_CONTEXT macro in the <c>lpBuffer</c> parameter of
	/// <c>WinHttpSetOption</c>. For more information, see the <c>WINHTTP_OPTION_CLIENT_CERT_CONTEXT</c> option. <c>Windows Server 2003 with
	/// SP1, Windows XP with SP2 and Windows 2000:</c> This error is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// version 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_INVALID_URL</c></term>
	/// <term>The URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_LOGIN_FAILURE</c></term>
	/// <term>
	/// The login attempt failed. When this error is encountered, the request handle should be closed with WinHttpCloseHandle. A new request
	/// handle must be created before retrying the function that originally produced this error.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_NAME_NOT_RESOLVED</c></term>
	/// <term>The server name cannot be resolved.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESPONSE_DRAIN_OVERFLOW</c></term>
	/// <term>Returned when an incoming response exceeds an internal WinHTTP size limit.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_SECURE_FAILURE</c></term>
	/// <term>
	/// One or more errors were found in the Secure Sockets Layer (SSL) certificate sent by the server. To determine what type of error was
	/// encountered, verify through a WINHTTP_CALLBACK_STATUS_SECURE_FAILURE notification in a status callback function. For more
	/// information, see WINHTTP_STATUS_CALLBACK.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_SHUTDOWN</c></term>
	/// <term>The WinHTTP function support is shut down or unloaded.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_TIMEOUT</c></term>
	/// <term>The request timed out.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_UNRECOGNIZED_SCHEME</c></term>
	/// <term>The URL specified a scheme other than "http:" or "https:".</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>
	/// Not enough memory was available to complete the requested operation. (Windows error code) <c>Windows Server 2003, Windows XP and
	/// Windows 2000:</c> The TCP reservation range set with the <c>WINHTTP_OPTION_PORT_RESERVATION</c> option is not large enough to send
	/// this request.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The content length specified in the <c>dwTotalLength</c> parameter does not match the length specified in the Content-Length header.
	/// The <c>lpOptional</c> parameter must be <c>NULL</c> and the <c>dwOptionalLength</c> parameter must be zero when the Transfer-Encoding
	/// header is present. The Content-Length header cannot be present when the Transfer-Encoding header is present.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_RESEND_REQUEST</c></term>
	/// <term>
	/// The application must call WinHttpSendRequest again due to a redirect or authentication challenge. <c>Windows Server 2003 with SP1,
	/// Windows XP with SP2 and Windows 2000:</c> This error is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode, that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen, this function
	/// can operate either synchronously or asynchronously. In either case, if the request is sent successfully, the application is called
	/// back with the completion status set to <c>WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE</c>. The
	/// <c>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</c> completion indicates that the operation completed asynchronously, but failed. Upon
	/// receiving the <c>WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE</c> status callback, the application can start to receive a response
	/// from the server with WinHttpReceiveResponse. Before then, no other asynchronous functions can be called, otherwise,
	/// <c>ERROR_WINHTTP_INCORRECT_HANDLE_STATE</c> is returned.
	/// </para>
	/// <para>
	/// An application must not delete or alter the buffer pointed to by <c>lpOptional</c> until the request handle is closed or the call to
	/// WinHttpReceiveResponse has completed, because an authentication challenge or redirect that required the optional data could be
	/// encountered in the course of receiving the response. If the operation must be aborted with WinHttpCloseHandle, the application must
	/// keep the buffer valid until it receives the callback <c>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</c> with an
	/// <c>ERROR_WINHTTP_OPERATION_CANCELLED</c> error code.
	/// </para>
	/// <para>
	/// If WinHTTP is used synchronously, that is, when <c>WINHTP_FLAG_ASYNC</c> was not set in WinHttpOpen, an application is not called
	/// with a completion status even if a callback function is registered. While in this mode, the application can call
	/// WinHttpReceiveResponse when <c>WinHttpSendRequest</c> returns.
	/// </para>
	/// <para>
	/// The <c>WinHttpSendRequest</c> function sends the specified request to the HTTP server and allows the client to specify additional
	/// headers to send along with the request.
	/// </para>
	/// <para>
	/// This function also lets the client specify optional data to send to the HTTP server immediately following the request headers. This
	/// feature is generally used for write operations such as PUT and POST.
	/// </para>
	/// <para>
	/// An application can use the same HTTP request handle in multiple calls to <c>WinHttpSendRequest</c> to re-send the same request, but
	/// the application must read all data returned from the previous call before calling this function again.
	/// </para>
	/// <para>
	/// The name and value of request headers added with this function are validated. Headers must be well formed. For more information about
	/// valid HTTP headers, see RFC 2616. If an invalid header is used, this function fails and GetLastError returns ERROR_INVALID_PARAMETER.
	/// The invalid header is not added.
	/// </para>
	/// <para><c>Windows 2000:</c> When sending requests from multiple threads, there may be a significant decrease in network and CPU performance.</para>
	/// <para><c>Windows XP and Windows 2000:</c> See Run-Time Requirements.</para>
	/// <para>WinHttpSetStatusCallback</para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then those of the following notifications that have
	/// been set in the <c>dwNotificationFlags</c> parameter of <c>WinHttpSetStatusCallback</c> indicate the progress in sending the request:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_DETECTING_PROXY (not implemented)</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE (only in asynchronous mode)</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REDIRECT</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SECURE_FAILURE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> On Windows 7 and Windows Server 2008 R2, all of the following notifications are deprecated.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESOLVING_NAME</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_NAME_RESOLVED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTING_TO_SERVER</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SENDING_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REQUEST_SENT</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the server closes the connection, the following notifications are also sent, provided that they have been set in the
	/// <c>dwNotificationFlags</c> parameter of WinHttpSetStatusCallback:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED</term>
	/// </item>
	/// </list>
	/// <para>Support for Greater Than 4-GB Upload</para>
	/// <para>
	/// Starting in Windows Vista and Windows Server 2008, WinHttp supports uploading files up to the size of a LARGE_INTEGER (2^64
	/// bytes) using the Content-Length header. Payload lengths specified in the call to <c>WinHttpSendRequest</c> are limited to the size of
	/// a <c>DWORD</c> (2^32 bytes). To upload data to a URL larger than a <c>DWORD</c>, the application must provide the length in the
	/// Content-Length header of the request. In this case, the WinHttp client application calls <c>WinHttpSendRequest</c> with the
	/// <c>dwTotalLength</c> parameter set to <c>WINHTTP_IGNORE_REQUEST_TOTAL_LENGTH</c>.
	/// </para>
	/// <para>
	/// If the Content-Length header specifies a length less than a 2^32, the application must also specify the content length in the call to
	/// <c>WinHttpSendRequest</c>. If the <c>dwTotalLength</c> parameter does not match the length specified in the Content-Length header,
	/// the call fails and returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// The Content-Length header can be added in the call to WinHttpAddRequestHeaders, or it can be specified in the <c>lpszHeader</c>
	/// parameter of <c>WinHttpSendRequest</c> as shown in the following code example.
	/// </para>
	/// <para>
	/// <code>BOOL fRet = WinHttpSendRequest( hReq, L"Content-Length: 68719476735\r\n", -1L, WINHTTP_NO_REQUEST_DATA, 0, WINHTTP_IGNORE_REQUEST_TOTAL_LENGTH, pMyContent);</code>
	/// </para>
	/// <para>Transfer-Encoding Header</para>
	/// <para>
	/// Starting in Windows Vista and Windows Server 2008, WinHttp enables applications to perform chunked transfer encoding on data sent to
	/// the server. When the Transfer-Encoding header is present on the WinHttp request, the <c>dwTotalLength</c> parameter in the call to
	/// <c>WinHttpSendRequest</c> is set to <c>WINHTTP_IGNORE_REQUEST_TOTAL_LENGTH</c> and the application sends the entity body in one or
	/// more calls to WinHttpWriteData. The <c>lpOptional</c> parameter of <c>WinHttpSendRequest</c> must be <c>NULL</c> and the
	/// <c>dwOptionLength</c> parameter must be zero, otherwise an <c>ERROR_WINHTTP_INVALID_PARAMETER</c> error is returned. To terminate the
	/// chunked data transfer, the application generates a zero length chunk and sends it in the last call to <c>WinHttpWriteData</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code example shows how to obtain an HINTERNET handle, open an HTTP session, create a request header, and send that
	/// header to the server.
	/// </para>
	/// <para>
	/// <code> BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.wingtiptoys.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP Request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"PUT", L"/writetst.txt", NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a Request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, 0, 0); // Place additional code here. // Report errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsendrequest BOOL WinHttpSendRequest( [in] HINTERNET
	// hRequest, [in, optional] LPCWSTR lpszHeaders, [in] DWORD dwHeadersLength, [in, optional] LPVOID lpOptional, [in] DWORD
	// dwOptionalLength, [in] DWORD dwTotalLength, [in] DWORD_PTR dwContext );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSendRequest")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpSendRequest(HINTERNET hRequest, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? lpszHeaders,
		[Optional] int dwHeadersLength, [In, Optional] IntPtr lpOptional, [Optional] uint dwOptionalLength, [Optional] uint dwTotalLength,
		[In, Optional] IntPtr dwContext);

	/// <summary>The <c>WinHttpSetCredentials</c> function passes the required authorization credentials to the server.</summary>
	/// <param name="hRequest">Valid HINTERNET handle returned by WinHttpOpenRequest.</param>
	/// <param name="AuthTargets">
	/// <para>
	/// An unsigned integer that specifies a flag that contains the authentication target. Can be one of the values in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_AUTH_TARGET_SERVER</c></term>
	/// <term>Credentials are passed to a server.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_TARGET_PROXY</c></term>
	/// <term>Credentials are passed to a proxy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="AuthScheme">
	/// <para>
	/// An unsigned integer that specifies a flag that contains the authentication scheme. Must be one of the supported authentication
	/// schemes returned from WinHttpQueryAuthSchemes. The following table identifies the possible values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_BASIC</c></term>
	/// <term>Use basic authentication.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_NTLM</c></term>
	/// <term>Use NTLM authentication.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_PASSPORT</c></term>
	/// <term>Use passport authentication.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_DIGEST</c></term>
	/// <term>Use digest authentication.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_AUTH_SCHEME_NEGOTIATE</c></term>
	/// <term>Selects between NTLM and Kerberos authentication.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pwszUserName">Pointer to a string that contains a valid user name.</param>
	/// <param name="pwszPassword">Pointer to a string that contains a valid password. The password can be blank.</param>
	/// <param name="pAuthParams">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. The following table
	/// identifies the error codes returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
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
	/// <term>Not enough memory was available to complete the requested operation (Windows error code).</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// The credentials set by <c>WinHttpSetCredentials</c> are only used for a single request; WinHTTP does not cache these credentials for
	/// use in subsequent requests. As a result, applications must be written so that they can respond to multiple challenges. If an
	/// authenticated connection is re-used, subsequent requests cannot be challenged, but your code should be able to respond to a challenge
	/// at any point.
	/// </para>
	/// <para>For sample code that illustrates the use of <c>WinHttpSetCredentials</c>, see Authentication in WinHTTP.</para>
	/// <para>
	/// <note type="note">When using Passport authentication and responding to a 407 status code, a WinHTTP application must use
	/// WinHttpSetOption to provide proxy credentials rather than <c>WinHttpSetCredentials</c>. This is only true when using Passport
	/// authentication; in all other circumstances, use <c>WinHttpSetCredentials</c>, because <c>WinHttpSetOption</c> is less secure.</note>
	/// </para>
	/// <para><note type="note">For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</note></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsetcredentials BOOL WinHttpSetCredentials( [in] HINTERNET
	// hRequest, [in] DWORD AuthTargets, [in] DWORD AuthScheme, [in] LPCWSTR pwszUserName, [in] LPCWSTR pwszPassword, [in] LPVOID pAuthParams );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetCredentials")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpSetCredentials(HINTERNET hRequest, WINHTTP_AUTH_TARGET AuthTargets, WINHTTP_AUTH_SCHEME AuthScheme,
		[MarshalAs(UnmanagedType.LPWStr)] string pwszUserName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszPassword, IntPtr pAuthParams = default);

	/// <summary>The <c>WinHttpSetDefaultProxyConfiguration</c> function sets the default WinHTTP proxy configuration in the registry.</summary>
	/// <param name="pProxyInfo">A pointer to a variable of type WINHTTP_PROXY_INFO that specifies the default proxy configuration.</param>
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
	/// The default proxy configuration set by <c>WinHttpSetDefaultProxyConfiguration</c> can be overridden for an existing WinHTTP session
	/// by calling WinHttpSetOption and specifying the WINHTTP_OPTION_PROXY flag. The default proxy configuration can be overridden for a new
	/// session by specifying the configuration with the WinHttpOpen function.
	/// </para>
	/// <para>
	/// The dwAccessType member of the WINHTTP_PROXY_INFO structure pointed to by <c>pProxyInfo</c> should be set to
	/// <c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c> if a proxy is specified. Otherwise, it should be set to <c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c>.
	/// </para>
	/// <para>Any new sessions created after calling this function use the new default proxy configuration.</para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para><note type="note">For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP start page.</note></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsetdefaultproxyconfiguration WINHTTPAPI BOOL
	// WinHttpSetDefaultProxyConfiguration( [in] WINHTTP_PROXY_INFO *pProxyInfo );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetDefaultProxyConfiguration")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpSetDefaultProxyConfiguration(in WINHTTP_PROXY_INFO pProxyInfo);

	/// <summary>The <c>WinHttpSetOption</c> function sets an Internet option.</summary>
	/// <param name="hInternet">
	/// The HINTERNET handle on which to set data. Be aware that this can be either a Session handle or a Request handle, depending on what
	/// option is being set. For more information about how to determine which handle is appropriate to use in setting a particular option,
	/// see the Option Flags.
	/// </param>
	/// <param name="dwOption">
	/// An unsigned long integer value that contains the Internet option to set. This can be one of the Option Flags values.
	/// </param>
	/// <param name="lpBuffer">A pointer to a buffer that contains the option setting.</param>
	/// <param name="dwBufferLength">
	/// Unsigned long integer value that contains the length of the <c>lpBuffer</c> buffer. The length of the buffer is specified in
	/// characters for the following options; for all other options, the length is specified in bytes.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
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
	/// <term><c>ERROR_WINHTTP_INVALID_OPTION</c></term>
	/// <term>A request to WinHttpQueryOption or WinHttpSetOption specified an invalid option value.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// A parameter is not valid. This value will be returned if <c>WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL</c> is set to a value lower
	/// than 15000.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPTION_NOT_SETTABLE</c></term>
	/// <term>The requested option cannot be set, only queried.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// A parameter is not valid. This value will be returned if <c>WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL</c> is set to a value lower
	/// than 15000.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Credentials passed to <c>WinHttpSetOption</c> could be unexpectedly sent in plaintext. It is strongly recommended that you use
	/// WinHttpQueryAuthSchemes and WinHttpSetCredentials instead of <c>WinHttpSetOption</c> for setting credentials.
	/// </para>
	/// <para>
	/// <note type="note">When using Passport authentication, however, a WinHTTP application responding to a 407 status code must use
	/// <c>WinHttpSetOption</c> to provide proxy credentials rather than WinHttpSetCredentials. This is only true when using Passport
	/// authentication; in all other circumstances, use <c>WinHttpSetCredentials</c>.</note>
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>GetLastError returns the error ERROR_INVALID_PARAMETER if an option flag is specified that cannot be set.</para>
	/// <para>For more information and code examples that show the use of <c>WinHttpSetOption</c>, see Authentication in WinHTTP.</para>
	/// <para><note type="note">For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</note></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsetoption BOOL WinHttpSetOption( [in] HINTERNET
	// hInternet, [in] DWORD dwOption, [in] LPVOID lpBuffer, [in] DWORD dwBufferLength );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetOption")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpSetOption(HINTERNET hInternet, WINHTTP_OPTION dwOption, [In] IntPtr lpBuffer, uint dwBufferLength);

	/// <summary>The <c>WinHttpSetOption</c> function sets an Internet option.</summary>
	/// <param name="hInternet">
	/// The HINTERNET handle on which to set data. Be aware that this can be either a Session handle or a Request handle, depending on what
	/// option is being set. For more information about how to determine which handle is appropriate to use in setting a particular option,
	/// see the Option Flags.
	/// </param>
	/// <param name="dwOption">
	/// An unsigned long integer value that contains the Internet option to set. This can be one of the Option Flags values.
	/// </param>
	/// <param name="value">The option setting.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
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
	/// <term><c>ERROR_WINHTTP_INVALID_OPTION</c></term>
	/// <term>A request to WinHttpQueryOption or WinHttpSetOption specified an invalid option value.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// A parameter is not valid. This value will be returned if <c>WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL</c> is set to a value lower
	/// than 15000.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPTION_NOT_SETTABLE</c></term>
	/// <term>The requested option cannot be set, only queried.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// A parameter is not valid. This value will be returned if <c>WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL</c> is set to a value lower
	/// than 15000.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Not enough memory was available to complete the requested operation. (Windows error code)</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Credentials passed to <c>WinHttpSetOption</c> could be unexpectedly sent in plaintext. It is strongly recommended that you use
	/// WinHttpQueryAuthSchemes and WinHttpSetCredentials instead of <c>WinHttpSetOption</c> for setting credentials.
	/// </para>
	/// <para>
	/// <note type="note">When using Passport authentication, however, a WinHTTP application responding to a 407 status code must use
	/// <c>WinHttpSetOption</c> to provide proxy credentials rather than WinHttpSetCredentials. This is only true when using Passport
	/// authentication; in all other circumstances, use <c>WinHttpSetCredentials</c>.</note>
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>GetLastError returns the error ERROR_INVALID_PARAMETER if an option flag is specified that cannot be set.</para>
	/// <para>For more information and code examples that show the use of <c>WinHttpSetOption</c>, see Authentication in WinHTTP.</para>
	/// <para><note type="note">For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</note></para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsetoption BOOL WinHttpSetOption( [in] HINTERNET
	// hInternet, [in] DWORD dwOption, [in] LPVOID lpBuffer, [in] DWORD dwBufferLength );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetOption")]
	public static bool WinHttpSetOption<T>(HINTERNET hInternet, WINHTTP_OPTION dwOption, in T value) where T : struct
	{
		using SafeHGlobalHandle mem = SafeHGlobalHandle.CreateFromStructure(value);
		return WinHttpSetOption(hInternet, dwOption, mem, mem.Size);
	}

	/// <summary>
	/// The <c>WinHttpSetStatusCallback</c> function sets up a callback function that WinHTTP can call as progress is made during an operation.
	/// </summary>
	/// <param name="hInternet">HINTERNET handle for which the callback is to be set.</param>
	/// <param name="lpfnInternetCallback">
	/// Pointer to the callback function to call when progress is made. Set this to <c>NULL</c> to remove the existing callback function. For
	/// more information about the callback function, see WINHTTP_STATUS_CALLBACK.
	/// </param>
	/// <param name="dwNotificationFlags">
	/// <para>Unsigned long integer value that specifies flags to indicate which events activate the callback function.</para>
	/// <para>The possible values are as follows.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_ALL_COMPLETIONS</c></term>
	/// <term>
	/// Activates upon any completion notification. This flag specifies that all notifications required for read or write operations are
	/// used. See WINHTTP_STATUS_CALLBACK for a list of completions.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_ALL_NOTIFICATIONS</c></term>
	/// <term>Activates upon any status change notification including completions. See WINHTTP_STATUS_CALLBACK for a list of notifications.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_RESOLVE_NAME</c></term>
	/// <term>Activates upon beginning and completing name resolution.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_CONNECT_TO_SERVER</c></term>
	/// <term>Activates upon beginning and completing connection to the server.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_DETECTING_PROXY</c></term>
	/// <term>Activates when detecting the proxy server.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_DATA_AVAILABLE</c></term>
	/// <term>Activates when completing a query for data.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_HEADERS_AVAILABLE</c></term>
	/// <term>Activates when the response headers are available for retrieval.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_READ_COMPLETE</c></term>
	/// <term>Activates upon completion of a data-read operation.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_REQUEST_ERROR</c></term>
	/// <term>Activates when an asynchronous error occurs.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_SEND_REQUEST</c></term>
	/// <term>Activates upon beginning and completing the sending of a request header with WinHttpSendRequest.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_SENDREQUEST_COMPLETE</c></term>
	/// <term>Activates when a request header has been sent with WinHttpSendRequest.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_WRITE_COMPLETE</c></term>
	/// <term>Activates upon completion of a data-post operation.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_RECEIVE_RESPONSE</c></term>
	/// <term>Activates upon beginning and completing the receipt of a resource from the HTTP server.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_CLOSE_CONNECTION</c></term>
	/// <term>Activates when beginning and completing the closing of an HTTP connection.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_HANDLES</c></term>
	/// <term>Activates when an HINTERNET handle is created or closed.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_REDIRECT</c></term>
	/// <term>Activates when the request is redirected.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_INTERMEDIATE_RESPONSE</c></term>
	/// <term>Activates when receiving an intermediate (100 level) status code message from the server.</term>
	/// </item>
	/// <item>
	/// <term><c>WINHTTP_CALLBACK_FLAG_SECURE_FAILURE</c></term>
	/// <term>Activates upon a secure connection failure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// If successful, returns a pointer to the previously defined status callback function or <c>NULL</c> if there was no previously defined
	/// status callback function. Returns <c>WINHTTP_INVALID_STATUS_CALLBACK</c> if the callback function could not be installed. For
	/// extended error information, call GetLastError. Among the error codes returned are the following.
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
	/// If you set the callback on the session handle before creating the request handle, the request handle inherits the callback function
	/// pointer from its parent session.
	/// </para>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// Both synchronous and asynchronous functions use the callback function to indicate the progress of the request, such as resolving a
	/// name, connecting to a server, and so on. The callback function is required for an asynchronous operation.
	/// </para>
	/// <para>
	/// A callback function can be set on any handle and is inherited by derived handles. A callback function can be changed using
	/// <c>WinHttpSetStatusCallback</c>, provided there are no pending requests that need to use the previous callback value. However,
	/// changing the callback function on a handle does not change the callbacks on derived handles, such as that returned by WinHttpConnect.
	/// You must change the callback function at each level.
	/// </para>
	/// <para>Many WinHTTP functions perform several operations on the network. Each operation can take time to complete and each can fail.</para>
	/// <para>
	/// After initiating the <c>WinHttpSetStatusCallback</c> function, the callback function can be accessed from within WinHTTP for
	/// monitoring time-intensive network operations.
	/// </para>
	/// <para>
	/// At the end of asynchronous processing, the application may set the callback function to <c>NULL</c>. This prevents the client
	/// application from receiving additional notifications.
	/// </para>
	/// <para>The following code snippet shows the recommended method for setting the callback function to <c>NULL</c>.</para>
	/// <para><c>WinHttpSetStatusCallback( hOpen, NULL, WINHTTP_CALLBACK_FLAG_ALL_NOTIFICATIONS, NULL );</c></para>
	/// <para>
	/// Note, however, that WinHTTP does not synchronize <c>WinHttpSetStatusCallback</c> with worker threads. If a callback originating in
	/// another thread is in progress when an application calls <c>WinHttpSetStatusCallback</c>, the application still receives a callback
	/// notification even after <c>WinHttpSetStatusCallback</c> successfully sets the callback function to <c>NULL</c> and returns.
	/// </para>
	/// <para><note type="note">For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</note></para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to install a callback function for asynchronous WinHTTP functions. The example assumes that a
	/// WINHTTP_STATUS_CALLBACK function named "AsyncCallback( )" has been previously implemented:
	/// </para>
	/// <para>
	/// <code>// Use WinHttpOpen to obtain an HINTERNET handle. HINTERNET hSession = WinHttpOpen(L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); if (hSession) { // Install the status callback function. WINHTTP_STATUS_CALLBACK isCallback = WinHttpSetStatusCallback( hSession, (WINHTTP_STATUS_CALLBACK)AsyncCallback, WINHTTP_CALLBACK_FLAG_ALL_NOTIFICATIONS, NULL); // Place additional code here. // When finished, release the HINTERNET handle. WinHttpCloseHandle(hSession); } else { printf("Error %u in WinHttpOpen.\n", GetLastError()); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsetstatuscallback WINHTTPAPI WINHTTP_STATUS_CALLBACK
	// WinHttpSetStatusCallback( [in] HINTERNET hInternet, [in] WINHTTP_STATUS_CALLBACK lpfnInternetCallback, [in] DWORD dwNotificationFlags,
	// [in] DWORD_PTR dwReserved );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetStatusCallback")]
	public static extern IntPtr WinHttpSetStatusCallback(HINTERNET hInternet, [Optional] WINHTTP_STATUS_CALLBACK? lpfnInternetCallback,
		WINHTTP_CALLBACK_FLAG dwNotificationFlags, IntPtr dwReserved = default);

	/// <summary>The <c>WinHttpSetTimeouts</c> function sets time-outs involved with HTTP transactions.</summary>
	/// <param name="hInternet">The HINTERNET handle returned by WinHttpOpen or WinHttpOpenRequest.</param>
	/// <param name="nResolveTimeout">
	/// <para>
	/// A value of type integer that specifies the time-out value, in milliseconds, to use for name resolution. If resolution takes longer
	/// than this time-out value, the action is canceled. The initial value is zero, meaning no time-out (infinite).
	/// </para>
	/// <para>
	/// <c>Windows Vista and Windows XP:</c> If DNS timeout is specified using NAME_RESOLUTION_TIMEOUT, there is an overhead of one thread
	/// per request.
	/// </para>
	/// </param>
	/// <param name="nConnectTimeout">
	/// <para>
	/// A value of type integer that specifies the time-out value, in milliseconds, to use for server connection requests. If a connection
	/// request takes longer than this time-out value, the request is canceled. The initial value is 60,000 (60 seconds).
	/// </para>
	/// <para>TCP/IP can time out while setting up the socket during the three leg SYN/ACK exchange, regardless of the value of this parameter.</para>
	/// </param>
	/// <param name="nSendTimeout">
	/// A value of type integer that specifies the time-out value, in milliseconds, to use for sending requests. If sending a request takes
	/// longer than this time-out value, the send is canceled. The initial value is 30,000 (30 seconds).
	/// </param>
	/// <param name="nReceiveTimeout">
	/// A value of type integer that specifies the time-out value, in milliseconds, to receive a response to a request. If a response takes
	/// longer than this time-out value, the request is canceled. The initial value is 30,000 (30 seconds).
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
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the timeout parameters has a negative value other than -1.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// A value of 0 or -1 sets a time-out to wait infinitely. A value greater than 0 sets the time-out value in milliseconds. For example,
	/// 30,000 would set the time-out to 30 seconds. All negative values other than -1 cause the function to fail with ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// <c>Important</c> If a small timeout is set using WinHttpSetOption and WINHTTP_OPTION_RECEIVE_TIMEOUT, it can override the value set
	/// with the <c>dwReceiveTimeout</c> parameter, causing a response to terminate earlier than expected. To avoid this, do not set a
	/// timeout with the <c>WINHTTP_OPTION_RECEIVE_TIMEOUT</c> option that is smaller than the value set using <c>dwReceiveTimeout</c>.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP start page.</para>
	/// <para>Examples</para>
	/// <para>This example shows how to set new time-out values using <c>WinHttpSetTimeouts</c>.</para>
	/// <para>
	/// <code> // Use WinHttpOpen to obtain an HINTERNET handle. HINTERNET hSession = WinHttpOpen(L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); if (hSession) { // Use WinHttpSetTimeouts to set a new time-out values. if (!WinHttpSetTimeouts( hSession, 10000, 10000, 10000, 10000)) printf( "Error %u in WinHttpSetTimeouts.\n", GetLastError()); // PLACE ADDITIONAL CODE HERE. // When finished, release the HINTERNET handle. WinHttpCloseHandle(hSession); } else { printf("Error %u in WinHttpOpen.\n", GetLastError()); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpsettimeouts BOOL WinHttpSetTimeouts( [in] HINTERNET
	// hInternet, [in] int nResolveTimeout, [in] int nConnectTimeout, [in] int nSendTimeout, [in] int nReceiveTimeout );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetTimeouts")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpSetTimeouts(HINTERNET hInternet, int nResolveTimeout = 0, int nConnectTimeout = 60000, int nSendTimeout = 30000, int nReceiveTimeout = 30000);

	/// <summary>The <c>WinHttpTimeFromSystemTime</c> function formats a date and time according to the HTTP version 1.0 specification.</summary>
	/// <param name="pst">A pointer to a SYSTEMTIME structure that contains the date and time to format.</param>
	/// <param name="pwszTime">
	/// A pointer to a string buffer that receives the formatted date and time. The buffer should equal to the size, in bytes, of WINHTTP_TIME_FORMAT_BUFSIZE.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Error codes
	/// include the following.
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
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP Start Page.</para>
	/// <para>Examples</para>
	/// <para>The following code example code shows how to convert a SYSTEMTIME structure to a string that contains the time in HTTP format.</para>
	/// <para>
	/// <code> SYSTEMTIME sTime; PWSTR pwszTimeStr; // Get the current time. GetSystemTime(&amp;sTime); // Allocate memory for the string. // Note: WINHTTP_TIME_FORMAT_BUFSIZE is a byte count. // Therefore, you must divide the array by // sizeof WCHAR to get the proper string length. pwszTimeStr = new WCHAR[WINHTTP_TIME_FORMAT_BUFSIZE/sizeof(WCHAR)]; // Convert the current time to HTTP format. if(!WinHttpTimeFromSystemTime( &amp;sTime, pwszTimeStr)) { printf( "Error %u in WinHttpTimeFromSystemTime.\n", GetLastError()); } else { // Print the time. printf("Current time is (%S)\n", pwszTimeStr); } // Free the memory. delete [] pwszTimeStr;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttptimefromsystemtime BOOL WinHttpTimeFromSystemTime( [in]
	// const SYSTEMTIME *pst, [out] PWSTR pwszTime );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpTimeFromSystemTime")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpTimeFromSystemTime(in SYSTEMTIME pst, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszTime);

	/// <summary>The <c>WinHttpTimeToSystemTime</c> function takes an HTTP time/date string and converts it to a SYSTEMTIME structure.</summary>
	/// <param name="pwszTime">
	/// Pointer to a null-terminated date/time string to convert. This value must use the format defined in section 3.3 of the RFC2616.
	/// </param>
	/// <param name="pst">Pointer to the SYSTEMTIME structure that receives the converted time.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned is:
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
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// operates synchronously. The return value indicates success or failure. To get extended error information, call GetLastError.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
	/// <para>Examples</para>
	/// <para>This example shows how to convert an HTTP formatted date to a SYSTEMTIME structure.</para>
	/// <para>
	/// <code> SYSTEMTIME sTime; LPCWSTR pwszTimeStr = L"Tue, 21 Nov 2000 01:06:53 GMT"; // Convert the HTTP string to a SYSTEMTIME structure. if (!WinHttpTimeToSystemTime( pwszTimeStr, &amp;sTime)) { printf( "Error %u in WinHttpTimeToSystemTime.\n", GetLastError()); } else { // Print the date. printf( "The U.S. formatted date is (%u/%u/%u)\n", sTime.wMonth, sTime.wDay, sTime.wYear); }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttptimetosystemtime BOOL WinHttpTimeToSystemTime( [in]
	// LPCWSTR pwszTime, [out] SYSTEMTIME *pst );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpTimeToSystemTime")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpTimeToSystemTime([MarshalAs(UnmanagedType.LPWStr)] string pwszTime, out SYSTEMTIME pst);

	/// <summary>Unregisters a callback function that was registered by calling WinHttpRegisterProxyChangeNotification.</summary>
	/// <param name="hRegistration">
	/// <para>Type: _In_ <c>WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE*</c></para>
	/// <para>The handle that was returned from WinHttpRegisterProxyChangeNotification.</para>
	/// </param>
	/// <returns>A <c>DWORD</c> containing a status code indicating the result of the operation.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpunregisterproxychangenotification WINHTTPAPI DWORD
	// WinHttpUnregisterProxyChangeNotification( WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE hRegistration );
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpUnregisterProxyChangeNotification")]
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error WinHttpUnregisterProxyChangeNotification(WINHTTP_PROXY_CHANGE_REGISTRATION_HANDLE hRegistration);

	/// <summary>The <c>WinHttpWebSocketClose</c> function closes a WebSocket connection.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>Handle to a WebSocket.</para>
	/// </param>
	/// <param name="usStatus">
	/// <para>Type: <c>USHORT</c></para>
	/// <para>A close status code. See WINHTTP_WEB_SOCKET_CLOSE_STATUS for possible values.</para>
	/// </param>
	/// <param name="pvReason">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A detailed reason for the close.</para>
	/// </param>
	/// <param name="dwReasonLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The length of <c>pvReason</c>, in bytes.</para>
	/// <para>If <c>pvReason</c> is NULL, this must be 0. This value must be within the range of 0 to 123.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>With the following exception, all error codes indicate that the underlying TCP connection has been aborted.</para>
	/// <list type="table">
	/// <listheader>
	/// <term/>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_OPERATION</c></term>
	/// <term>A close or send is pending.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SERVER_RESPONSE</c></term>
	/// <term>Invalid data was received from the server.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinHttpWebSocketClose</c> completely closes a WebSocket connection. To close the send channel while still leaving the receive
	/// channel open, use WinHttpWebSocketShutdown.
	/// </para>
	/// <para>
	/// It is possible to receive a close frame during regular receive operations. In this case, <c>WinHttpWebSocketClose</c> will also send
	/// a close frame.
	/// </para>
	/// <para>The close timer can be set by the property WINHTTP_OPTION_WEB_SOCKET_CLOSE_TIMEOUT. The default is 10 seconds.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwebsocketclose WINHTTPAPI DWORD WinHttpWebSocketClose(
	// [in] HINTERNET hWebSocket, [in] USHORT usStatus, [in, optional] PVOID pvReason, [in] DWORD dwReasonLength );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWebSocketClose")]
	public static extern Win32Error WinHttpWebSocketClose(HINTERNET hWebSocket, WINHTTP_WEB_SOCKET_CLOSE_STATUS usStatus,
		[In, Optional] IntPtr pvReason, [In, Optional] uint dwReasonLength);

	/// <summary>The <c>WinHttpWebSocketCompleteUpgrade</c> function completes a WebSocket handshake started by WinHttpSendRequest.</summary>
	/// <param name="hRequest">
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>HTTP request handle used to send a WebSocket handshake.</para>
	/// </param>
	/// <param name="pContext">
	/// <para>Type: <c>DWORD_PTR</c></para>
	/// <para>Context to be associated with the new handle.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>A new WebSocket handle. If NULL, call GetLastError to determine the cause of failure.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinHttpWebSocketCompleteUpgrade</c> can be called on an open HTTP request to get a WebSocket handle for performing other WebSocket operations.
	/// </para>
	/// <para>
	/// The request handle must be marked as a WebSocket upgrade by calling WinHttpSetOption with <c>WINHTTP_OPTION_UPGRADE_TO_WEB_SOCKET</c>
	/// before sending the request.
	/// </para>
	/// <para>
	/// The caller should check the HTTP status code returned by the server and call this function only if the status code was 101. Calling
	/// it with any other status code will result in a failure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwebsocketcompleteupgrade WINHTTPAPI HINTERNET
	// WinHttpWebSocketCompleteUpgrade( [in] HINTERNET hRequest, [in, optional] DWORD_PTR pContext );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWebSocketCompleteUpgrade")]
	public static extern SafeHINTERNET WinHttpWebSocketCompleteUpgrade(HINTERNET hRequest, [In, Optional] IntPtr pContext);

	/// <summary>The <c>WinHttpWebSocketQueryCloseStatus</c> function retrieves the close status sent by a server.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>Handle to a WebSocket</para>
	/// </param>
	/// <param name="pusStatus">
	/// <para>Type: <c>USHORT*</c></para>
	/// <para>A pointer to a close status code that will be filled upon return. See WINHTTP_WEB_SOCKET_CLOSE_STATUS for possible values.</para>
	/// </param>
	/// <param name="pvReason">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A pointer to a buffer that will receive a close reason on return.</para>
	/// </param>
	/// <param name="dwReasonLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The length of the <c>pvReason</c> buffer, in bytes.</para>
	/// </param>
	/// <param name="pdwReasonLengthConsumed">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// The number of bytes consumed. If <c>pvReason</c> is <c>NULL</c> and <c>dwReasonLength</c> is 0, <c>pdwReasonLengthConsumed</c> will
	/// contain the size of the buffer that needs to be allocated by the calling application.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para><c>NO_ERROR</c> on success. Otherwise an error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term/>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>There is not enough space in <c>pvReason</c> to write the whole close reason.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_OPERATION</c></term>
	/// <term>No close frame has been received yet.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call <c>WinHttpWebSocketQueryCloseStatus</c> only after WinHttpWebSocketClose succeeds or if WinHttpWebSocketReceive returns <c>WINHTTP_WEB_SOCKET_CLOSE_BUFFER_TYPE</c>.
	/// </para>
	/// <para>
	/// <c>pdwReasonLengthConsumed</c> will never be greater than 123, so allocating buffer with at least 123 will guarantee that
	/// <c>ERROR_INSUFFICIENT_BUFFER</c> will never be returned.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwebsocketqueryclosestatus WINHTTPAPI DWORD
	// WinHttpWebSocketQueryCloseStatus( [in] HINTERNET hWebSocket, [out] USHORT *pusStatus, [out] PVOID pvReason, [in] DWORD dwReasonLength,
	// [out] DWORD *pdwReasonLengthConsumed );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWebSocketQueryCloseStatus")]
	public static extern Win32Error WinHttpWebSocketQueryCloseStatus(HINTERNET hWebSocket, out WINHTTP_WEB_SOCKET_CLOSE_STATUS pusStatus, [Out] IntPtr pvReason,
		uint dwReasonLength, out uint pdwReasonLengthConsumed);

	/// <summary>The <c>WinHttpWebSocketReceive</c> function receives data from a WebSocket connection.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>Handle to a WebSocket.</para>
	/// </param>
	/// <param name="pvBuffer">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Pointer to a buffer to receive the data.</para>
	/// </param>
	/// <param name="dwBufferLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Length of <c>pvBuffer</c>, in bytes.</para>
	/// </param>
	/// <param name="pdwBytesRead">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>
	/// Pointer to a <c>DWORD</c> that receives the number of bytes read from the connection at the end of the operation. This is set only if
	/// <c>WinHttpWebSocketReceive</c> returns <c>NO_ERROR</c> and the handle was opened in synchronous mode.
	/// </para>
	/// </param>
	/// <param name="peBufferType">
	/// <para>Type: <c>WINHTTP_WEB_SOCKET_BUFFER_TYPE*</c></para>
	/// <para>
	/// The type of a returned buffer. This is only set if <c>WinHttpWebSocketReceive</c> returns <c>NO_ERROR</c> and the handle was opened
	/// in synchronous mode.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para><c>NO_ERROR</c> on success. Otherwise an error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term/>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_OPERATION</c></term>
	/// <term>A close or send is pending, or the receive channel has already been closed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_SERVER_RESPONSE</c></term>
	/// <term>Invalid data was received from the server.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was cancelled because WinHttpWebSocketClose was called to close the connection.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwebsocketreceive WINHTTPAPI DWORD
	// WinHttpWebSocketReceive( [in] HINTERNET hWebSocket, [out] PVOID pvBuffer, [in] DWORD dwBufferLength, [out] DWORD *pdwBytesRead, [out]
	// WINHTTP_WEB_SOCKET_BUFFER_TYPE *peBufferType );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWebSocketReceive")]
	public static extern Win32Error WinHttpWebSocketReceive(HINTERNET hWebSocket, [Out] IntPtr pvBuffer, uint dwBufferLength,
		out uint pdwBytesRead, out WINHTTP_WEB_SOCKET_BUFFER_TYPE peBufferType);

	/// <summary>The <c>WinHttpWebSocketSend</c> function sends data over a WebSocket connection.</summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>Handle to a websocket.</para>
	/// </param>
	/// <param name="eBufferType">
	/// <para>Type: <c>WINHTTP_WEB_SOCKET_BUFFER_TYPE</c></para>
	/// <para>Type of buffer.</para>
	/// </param>
	/// <param name="pvBuffer">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>Pointer to a buffer containing the data to send. Can be <c>NULL</c> only if <c>dwBufferLength</c> is 0.</para>
	/// </param>
	/// <param name="dwBufferLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Length of <c>pvBuffer</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para><c>NO_ERROR</c> on success. Otherwise an error code.</para>
	/// <list type="table">
	/// <listheader>
	/// <term/>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_OPERATION</c></term>
	/// <term>A close or send is pending, or the send channel has already been closed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>A parameter is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwebsocketsend WINHTTPAPI DWORD WinHttpWebSocketSend( [in]
	// HINTERNET hWebSocket, [in] WINHTTP_WEB_SOCKET_BUFFER_TYPE eBufferType, [in] PVOID pvBuffer, [in] DWORD dwBufferLength );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWebSocketSend")]
	public static extern Win32Error WinHttpWebSocketSend(HINTERNET hWebSocket, WINHTTP_WEB_SOCKET_BUFFER_TYPE eBufferType,
		[In, Optional] IntPtr pvBuffer, [In, Optional] uint dwBufferLength);

	/// <summary>
	/// The <c>WinHttpWebSocketShutdown</c> function sends a close frame to a WebSocket server to close the send channel, but leaves the
	/// receive channel open.
	/// </summary>
	/// <param name="hWebSocket">
	/// <para>Type: <c>HINTERNET</c></para>
	/// <para>Handle to a WebSocket.</para>
	/// </param>
	/// <param name="usStatus">
	/// <para>Type: <c>USHORT</c></para>
	/// <para>A close status code. See WINHTTP_WEB_SOCKET_CLOSE_STATUS for possible values.</para>
	/// </param>
	/// <param name="pvReason">
	/// <para>Type: <c>PVOID</c></para>
	/// <para>A detailed reason for the close.</para>
	/// </param>
	/// <param name="dwReasonLength">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>The length of <c>pvReason</c>, in bytes.</para>
	/// <para>If <c>pvReason</c> is NULL, this must be 0. This value must be within the range of 0 to 123.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>DWORD</c></para>
	/// <para>With the following exception, all error codes indicate that the underlying TCP connection has been aborted.</para>
	/// <list type="table">
	/// <listheader>
	/// <term/>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>The operation will complete asynchronously.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>WinHttpWebSocketShutdown</c> sends a close frame and prevents additional data from being sent over the WebSocket connection. It
	/// does not close the receive channel. Use WinHttpWebSocketClose when you want to completely close the connection and prevent any
	/// subsequent receive operations.
	/// </para>
	/// <para>The application is responsible for receiving the close frame from the server (through regular receive operations).</para>
	/// <para>
	/// After <c>WinHttpWebSocketShutdown</c> is called, the application can call WinHttpWebSocketClose if it does not want to receive a
	/// close frame on its own and delegate it to the stack.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwebsocketshutdown WINHTTPAPI DWORD
	// WinHttpWebSocketShutdown( [in] HINTERNET hWebSocket, [in] USHORT usStatus, [in, optional] PVOID pvReason, [in] DWORD dwReasonLength );
	[DllImport(Lib_Winhttp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWebSocketShutdown")]
	public static extern Win32Error WinHttpWebSocketShutdown(HINTERNET hWebSocket, WINHTTP_WEB_SOCKET_CLOSE_STATUS usStatus,
		[In, Optional] IntPtr pvReason, [In, Optional] uint dwReasonLength);

	/// <summary>The <c>WinHttpWriteData</c> function writes request data to an HTTP server.</summary>
	/// <param name="hRequest">
	/// Valid HINTERNET handle returned by WinHttpOpenRequest. Wait until WinHttpSendRequest has completed before calling this function.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that contains the data to be sent to the server. Be sure that this buffer remains valid until after
	/// <c>WinHttpWriteData</c> completes.
	/// </param>
	/// <param name="dwNumberOfBytesToWrite">Unsigned long integer value that contains the number of bytes to be written to the file.</param>
	/// <param name="lpdwNumberOfBytesWritten">
	/// Pointer to an unsigned long integer variable that receives the number of bytes written to the buffer. The <c>WinHttpWriteData</c>
	/// function sets this value to zero before doing any work or error checking. When using WinHTTP asynchronously, this parameter must be
	/// set to <c>NULL</c> and retrieve the information in the callback function. Not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// version 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
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
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, you can call GetLastError to get extended
	/// error information. If this function returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE completion to determine
	/// whether this function was successful and the value of the parameters. The WINHTTP_CALLBACK_STATUS_REQUEST_ERROR completion indicates
	/// that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When using WinHTTP asynchronously, always set the <c>lpdwNumberOfBytesWritten</c> parameter to <c>NULL</c> and
	/// retrieve the bytes written in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// When the application is sending data, it can call WinHttpReceiveResponse to end the data transfer. If WinHttpCloseHandle is called,
	/// then the data transfer is aborted.
	/// </para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then those of the following notifications that have
	/// been set in the <c>dwNotificationFlags</c> parameter of <c>WinHttpSetStatusCallback</c> indicate progress in sending data to the server:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_DATA_WRITTEN</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SENDING_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REQUEST_SENT</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE</term>
	/// </item>
	/// </list>
	/// <para>
	/// Two issues can arise when attempting to POST (or PUT) data to proxies or servers that challenge using NTLM or Negotiate
	/// authentication. First, these proxies or servers may send 401/407 challenges and close the connection before all the data can be
	/// POST'ed, in which case not only does <c>WinHttpWriteData</c> fail, but also WinHTTP cannot handle the authentication challenges. NTLM
	/// and Negotiate require that all authentication handshakes be exchanged on the same socket connection, so authentication fails if the
	/// connection is broken prematurely.
	/// </para>
	/// <para>
	/// Secondly, NTLM and Negotiate may require multiple handshakes to complete authentication, which requires data to be re-POST'ed for
	/// each authentication legs. This can be very inefficient for large data uploads.
	/// </para>
	/// <para>
	/// To work around these two issues, one solution is to send an idempotent warm-up request such as HEAD to the authenticating v-dir
	/// first, handle the authentication challenges associated with this request, and only then POST data. As long as the same socket is
	/// re-used to handle the POST'ing, no further authentication challenges should be encountered and all data can be uploaded at once.
	/// Since an authenticated socket can only be reused for subsequent requests within the same session, the POST should go out in the same
	/// socket as long as the socket is not pooled with concurrent requests competing for it.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// This example shows code that writes data to an HTTP server. The server name supplied in the example, www.wingtiptoys.com, is
	/// fictitious and must be replaced with the name of a server for which you have write access.
	/// </para>
	/// <para>
	/// <code> PCSTR pszData = "WinHttpWriteData Example"; DWORD dwBytesWritten = 0; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.wingtiptoys.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP Request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"PUT", L"/writetst.txt", NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a Request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, (DWORD)strlen(pszData), 0); // Write data to the server. if (bResults) bResults = WinHttpWriteData( hRequest, pszData, (DWORD)strlen(pszData), &amp;dwBytesWritten); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Report any errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwritedata BOOL WinHttpWriteData( [in] HINTERNET hRequest,
	// [in] LPCVOID lpBuffer, [in] DWORD dwNumberOfBytesToWrite, [out] LPDWORD lpdwNumberOfBytesWritten );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWriteData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpWriteData(HINTERNET hRequest, [In] IntPtr lpBuffer, uint dwNumberOfBytesToWrite, out uint lpdwNumberOfBytesWritten);

	/// <summary>The <c>WinHttpWriteData</c> function writes request data to an HTTP server.</summary>
	/// <param name="hRequest">
	/// Valid HINTERNET handle returned by WinHttpOpenRequest. Wait until WinHttpSendRequest has completed before calling this function.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that contains the data to be sent to the server. Be sure that this buffer remains valid until after
	/// <c>WinHttpWriteData</c> completes.
	/// </param>
	/// <param name="dwNumberOfBytesToWrite">Unsigned long integer value that contains the number of bytes to be written to the file.</param>
	/// <param name="lpdwNumberOfBytesWritten">
	/// Pointer to an unsigned long integer variable that receives the number of bytes written to the buffer. The <c>WinHttpWriteData</c>
	/// function sets this value to zero before doing any work or error checking. When using WinHTTP asynchronously, this parameter must be
	/// set to <c>NULL</c> and retrieve the information in the callback function. Not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// version 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
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
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, you can call GetLastError to get extended
	/// error information. If this function returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE completion to determine
	/// whether this function was successful and the value of the parameters. The WINHTTP_CALLBACK_STATUS_REQUEST_ERROR completion indicates
	/// that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When using WinHTTP asynchronously, always set the <c>lpdwNumberOfBytesWritten</c> parameter to <c>NULL</c> and
	/// retrieve the bytes written in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// When the application is sending data, it can call WinHttpReceiveResponse to end the data transfer. If WinHttpCloseHandle is called,
	/// then the data transfer is aborted.
	/// </para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then those of the following notifications that have
	/// been set in the <c>dwNotificationFlags</c> parameter of <c>WinHttpSetStatusCallback</c> indicate progress in sending data to the server:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_DATA_WRITTEN</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SENDING_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REQUEST_SENT</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE</term>
	/// </item>
	/// </list>
	/// <para>
	/// Two issues can arise when attempting to POST (or PUT) data to proxies or servers that challenge using NTLM or Negotiate
	/// authentication. First, these proxies or servers may send 401/407 challenges and close the connection before all the data can be
	/// POST'ed, in which case not only does <c>WinHttpWriteData</c> fail, but also WinHTTP cannot handle the authentication challenges. NTLM
	/// and Negotiate require that all authentication handshakes be exchanged on the same socket connection, so authentication fails if the
	/// connection is broken prematurely.
	/// </para>
	/// <para>
	/// Secondly, NTLM and Negotiate may require multiple handshakes to complete authentication, which requires data to be re-POST'ed for
	/// each authentication legs. This can be very inefficient for large data uploads.
	/// </para>
	/// <para>
	/// To work around these two issues, one solution is to send an idempotent warm-up request such as HEAD to the authenticating v-dir
	/// first, handle the authentication challenges associated with this request, and only then POST data. As long as the same socket is
	/// re-used to handle the POST'ing, no further authentication challenges should be encountered and all data can be uploaded at once.
	/// Since an authenticated socket can only be reused for subsequent requests within the same session, the POST should go out in the same
	/// socket as long as the socket is not pooled with concurrent requests competing for it.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// This example shows code that writes data to an HTTP server. The server name supplied in the example, www.wingtiptoys.com, is
	/// fictitious and must be replaced with the name of a server for which you have write access.
	/// </para>
	/// <para>
	/// <code> PCSTR pszData = "WinHttpWriteData Example"; DWORD dwBytesWritten = 0; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.wingtiptoys.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP Request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"PUT", L"/writetst.txt", NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a Request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, (DWORD)strlen(pszData), 0); // Write data to the server. if (bResults) bResults = WinHttpWriteData( hRequest, pszData, (DWORD)strlen(pszData), &amp;dwBytesWritten); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Report any errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwritedata BOOL WinHttpWriteData( [in] HINTERNET hRequest,
	// [in] LPCVOID lpBuffer, [in] DWORD dwNumberOfBytesToWrite, [out] LPDWORD lpdwNumberOfBytesWritten );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWriteData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpWriteData(HINTERNET hRequest, [In] IntPtr lpBuffer, uint dwNumberOfBytesToWrite, [In, Optional] IntPtr lpdwNumberOfBytesWritten);

	/// <summary>The <c>WinHttpWriteData</c> function writes request data to an HTTP server.</summary>
	/// <param name="hRequest">
	/// Valid HINTERNET handle returned by WinHttpOpenRequest. Wait until WinHttpSendRequest has completed before calling this function.
	/// </param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that contains the data to be sent to the server. Be sure that this buffer remains valid until after
	/// <c>WinHttpWriteData</c> completes.
	/// </param>
	/// <param name="dwNumberOfBytesToWrite">Unsigned long integer value that contains the number of bytes to be written to the file.</param>
	/// <param name="lpdwNumberOfBytesWritten">
	/// Pointer to an unsigned long integer variable that receives the number of bytes written to the buffer. The <c>WinHttpWriteData</c>
	/// function sets this value to zero before doing any work or error checking. When using WinHTTP asynchronously, this parameter must be
	/// set to <c>NULL</c> and retrieve the information in the callback function. Not doing so can cause a memory fault.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. For extended error information, call GetLastError. Among the error
	/// codes returned are:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error Code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_WINHTTP_CONNECTION_ERROR</c></term>
	/// <term>
	/// The connection with the server has been reset or terminated, or an incompatible SSL protocol was encountered. For example, WinHTTP
	/// version 5.1 does not support SSL2 unless the client specifically enables it.
	/// </term>
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
	/// <term><c>ERROR_WINHTTP_OPERATION_CANCELLED</c></term>
	/// <term>The operation was canceled, usually because the handle on which the request was operating was closed before the operation completed.</term>
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
	/// Even when WinHTTP is used in asynchronous mode (that is, when <c>WINHTTP_FLAG_ASYNC</c> has been set in WinHttpOpen), this function
	/// can operate either synchronously or asynchronously. If this function returns <c>FALSE</c>, you can call GetLastError to get extended
	/// error information. If this function returns <c>TRUE</c>, use the WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE completion to determine
	/// whether this function was successful and the value of the parameters. The WINHTTP_CALLBACK_STATUS_REQUEST_ERROR completion indicates
	/// that the operation completed asynchronously, but failed.
	/// </para>
	/// <para>
	/// <c>Warning</c> When using WinHTTP asynchronously, always set the <c>lpdwNumberOfBytesWritten</c> parameter to <c>NULL</c> and
	/// retrieve the bytes written in the callback function; otherwise, a memory fault can occur.
	/// </para>
	/// <para>
	/// When the application is sending data, it can call WinHttpReceiveResponse to end the data transfer. If WinHttpCloseHandle is called,
	/// then the data transfer is aborted.
	/// </para>
	/// <para>
	/// If a status callback function has been installed with WinHttpSetStatusCallback, then those of the following notifications that have
	/// been set in the <c>dwNotificationFlags</c> parameter of <c>WinHttpSetStatusCallback</c> indicate progress in sending data to the server:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_DATA_WRITTEN</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_SENDING_REQUEST</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_REQUEST_SENT</term>
	/// </item>
	/// <item>
	/// <term>WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE</term>
	/// </item>
	/// </list>
	/// <para>
	/// Two issues can arise when attempting to POST (or PUT) data to proxies or servers that challenge using NTLM or Negotiate
	/// authentication. First, these proxies or servers may send 401/407 challenges and close the connection before all the data can be
	/// POST'ed, in which case not only does <c>WinHttpWriteData</c> fail, but also WinHTTP cannot handle the authentication challenges. NTLM
	/// and Negotiate require that all authentication handshakes be exchanged on the same socket connection, so authentication fails if the
	/// connection is broken prematurely.
	/// </para>
	/// <para>
	/// Secondly, NTLM and Negotiate may require multiple handshakes to complete authentication, which requires data to be re-POST'ed for
	/// each authentication legs. This can be very inefficient for large data uploads.
	/// </para>
	/// <para>
	/// To work around these two issues, one solution is to send an idempotent warm-up request such as HEAD to the authenticating v-dir
	/// first, handle the authentication challenges associated with this request, and only then POST data. As long as the same socket is
	/// re-used to handle the POST'ing, no further authentication challenges should be encountered and all data can be uploaded at once.
	/// Since an authenticated socket can only be reused for subsequent requests within the same session, the POST should go out in the same
	/// socket as long as the socket is not pooled with concurrent requests competing for it.
	/// </para>
	/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP start page.</para>
	/// <para>Examples</para>
	/// <para>
	/// This example shows code that writes data to an HTTP server. The server name supplied in the example, www.wingtiptoys.com, is
	/// fictitious and must be replaced with the name of a server for which you have write access.
	/// </para>
	/// <para>
	/// <code> PCSTR pszData = "WinHttpWriteData Example"; DWORD dwBytesWritten = 0; BOOL bResults = FALSE; HINTERNET hSession = NULL, hConnect = NULL, hRequest = NULL; // Use WinHttpOpen to obtain a session handle. hSession = WinHttpOpen( L"A WinHTTP Example Program/1.0", WINHTTP_ACCESS_TYPE_DEFAULT_PROXY, WINHTTP_NO_PROXY_NAME, WINHTTP_NO_PROXY_BYPASS, 0); // Specify an HTTP server. if (hSession) hConnect = WinHttpConnect( hSession, L"www.wingtiptoys.com", INTERNET_DEFAULT_HTTP_PORT, 0); // Create an HTTP Request handle. if (hConnect) hRequest = WinHttpOpenRequest( hConnect, L"PUT", L"/writetst.txt", NULL, WINHTTP_NO_REFERER, WINHTTP_DEFAULT_ACCEPT_TYPES, 0); // Send a Request. if (hRequest) bResults = WinHttpSendRequest( hRequest, WINHTTP_NO_ADDITIONAL_HEADERS, 0, WINHTTP_NO_REQUEST_DATA, 0, (DWORD)strlen(pszData), 0); // Write data to the server. if (bResults) bResults = WinHttpWriteData( hRequest, pszData, (DWORD)strlen(pszData), &amp;dwBytesWritten); // End the request. if (bResults) bResults = WinHttpReceiveResponse( hRequest, NULL); // Report any errors. if (!bResults) printf("Error %d has occurred.\n",GetLastError()); // Close any open handles. if (hRequest) WinHttpCloseHandle(hRequest); if (hConnect) WinHttpCloseHandle(hConnect); if (hSession) WinHttpCloseHandle(hSession);</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/nf-winhttp-winhttpwritedata BOOL WinHttpWriteData( [in] HINTERNET hRequest,
	// [in] LPCVOID lpBuffer, [in] DWORD dwNumberOfBytesToWrite, [out] LPDWORD lpdwNumberOfBytesWritten );
	[DllImport(Lib_Winhttp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpWriteData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WinHttpWriteData(HINTERNET hRequest, [In] byte[] lpBuffer, int dwNumberOfBytesToWrite, out int lpdwNumberOfBytesWritten);
}