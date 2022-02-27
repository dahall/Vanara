using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Schannel;
using static Vanara.PInvoke.Ws2_32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using INTERNET_PORT = System.UInt16;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WinHTTP.dll.</summary>
	public static partial class WinHTTP
	{
		/// <summary>Provides a handle to an internet connection.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HINTERNET : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HINTERNET"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HINTERNET(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HINTERNET"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HINTERNET NULL { get; } = default;

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HINTERNET"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HINTERNET h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HINTERNET"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HINTERNET(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HINTERNET h1, HINTERNET h2) => h1.handle != h2.handle;

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HINTERNET h1, HINTERNET h2) => h1.handle == h2.handle;

			/// <inheritdoc/>
			public override bool Equals(object obj) => (obj is IHandle h && handle == h.DangerousGetHandle()) || (obj is IntPtr p && handle == p);

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>The <c>HTTP_VERSION_INFO</c> structure contains the global HTTP version.</summary>
		/// <remarks><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-http_version_info typedef struct _HTTP_VERSION_INFO { DWORD
		// dwMajorVersion; DWORD dwMinorVersion; } HTTP_VERSION_INFO, *LPHTTP_VERSION_INFO, *PHTTP_VERSION_INFO;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._HTTP_VERSION_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct HTTP_VERSION_INFO
		{
			/// <summary>Major version number. Must be 1.</summary>
			public uint dwMajorVersion;

			/// <summary>Minor version number. Can be either 1 or 0.</summary>
			public uint dwMinorVersion;
		}

		/// <summary>
		/// The <c>WINHTTP_ASYNC_RESULT</c> structure contains the result of a call to an asynchronous function. This structure is used with
		/// the WINHTTP_STATUS_CALLBACK prototype.
		/// </summary>
		/// <remarks><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_async_result typedef struct _WINHTTP_ASYNC_RESULT {
		// DWORD_PTR dwResult; DWORD dwError; } WINHTTP_ASYNC_RESULT, *LPWINHTTP_ASYNC_RESULT, *PWINHTTP_ASYNC_RESULT;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_ASYNC_RESULT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_ASYNC_RESULT
		{
			private readonly nuint _dwResult;

			/// <summary>Contains the error code if <c>dwResult</c> indicates that the function failed.</summary>
			public Win32Error dwError;

			/// <summary>
			/// <para>
			/// Return value from an asynchronous Microsoft Windows HTTP Services (WinHTTP) function. This member can be one of the following values:
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>API_RECEIVE_RESPONSE</c> 1</term>
			/// <term>The error occurred during a call to WinHttpReceiveResponse.</term>
			/// </item>
			/// <item>
			/// <term><c>API_QUERY_DATA_AVAILABLE</c> 2</term>
			/// <term>The error occurred during a call to WinHttpQueryDataAvailable.</term>
			/// </item>
			/// <item>
			/// <term><c>API_READ_DATA</c> 3</term>
			/// <term>The error occurred during a call to WinHttpReadData.</term>
			/// </item>
			/// <item>
			/// <term><c>API_WRITE_DATA</c> 4</term>
			/// <term>The error occurred during a call to WinHttpWriteData.</term>
			/// </item>
			/// <item>
			/// <term><c>API_SEND_REQUEST</c> 5</term>
			/// <term>The error occurred during a call to WinHttpSendRequest.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ASYNC_RESULT dwResult => (ASYNC_RESULT)_dwResult;
		}

		/// <summary>
		/// The <c>WINHTTP_AUTOPROXY_OPTIONS</c> structure is used to indicate to the WinHttpGetProxyForURL function whether to specify the
		/// URL of the Proxy Auto-Configuration (PAC) file or to automatically locate the URL with DHCP or DNS queries to the network.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_autoproxy_options typedef struct
		// _WINHTTP_AUTOPROXY_OPTIONS { DWORD dwFlags; DWORD dwAutoDetectFlags; LPCWSTR lpszAutoConfigUrl; LPVOID lpvReserved; DWORD
		// dwReserved; BOOL fAutoLogonIfChallenged; } WINHTTP_AUTOPROXY_OPTIONS, *PWINHTTP_AUTOPROXY_OPTIONS;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_AUTOPROXY_OPTIONS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_AUTOPROXY_OPTIONS
		{
			/// <summary>
			/// <para>Mechanisms should be used to obtain the PAC file.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term/>
			/// <term/>
			/// <term><c>WINHTTP_AUTOPROXY_ALLOW_STATIC</c></term>
			/// <term>Enables proxy detection via static configuration.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_AUTO_DETECT</c></term>
			/// <term>Attempt to automatically discover the URL of the PAC file using both DHCP and DNS queries to the local network.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_CONFIG_URL</c></term>
			/// <term>Download the PAC file from the URL specified by <c>lpszAutoConfigUrl</c> in the <c>WINHTTP_AUTOPROXY_OPTIONS</c> structure.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_HOST_KEEPCASE</c></term>
			/// <term>Maintains the case of the hostnames passed to the PAC script. This is the default behavior.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_HOST_LOWERCASE</c></term>
			/// <term>Converts hostnames to lowercase before passing them to the PAC script.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_NO_CACHE_CLIENT</c></term>
			/// <term>Disables querying a host to proxy cache of script execution results in the current process.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_NO_CACHE_SVC</c></term>
			/// <term>Disables querying a host to proxy cache of script execution results in the autoproxy service.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_NO_DIRECTACCESS</c></term>
			/// <term>Disables querying Direct Access proxy settings for this request.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_RUN_INPROCESS</c></term>
			/// <term>
			/// Executes the Web Proxy Auto-Discovery (WPAD) protocol in-process instead of delegating to an out-of-process WinHTTP AutoProxy
			/// Service, if available. This flag must be combined with one of the other flags. This option has no effect when passed to WinHttpGetProxyForUrlEx.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_RUN_OUTPROCESS_ONLY</c></term>
			/// <term>
			/// By default, WinHTTP is configured to fall back to auto-discover a proxy in-process. If this fallback behavior is undesirable
			/// in the event that an out-of-process discovery fails, it can be disabled using this flag. This option has no effect when
			/// passed to WinHttpGetProxyForUrlEx.
			/// </term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTOPROXY_SORT_RESULTS</c></term>
			/// <term>Orders the proxy results based on a heuristic placing the fastest proxies first.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WINHTTP_AUTOPROXY dwFlags;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> includes the WINHTTP_AUTOPROXY_AUTO_DETECT flag, then <c>dwAutoDetectFlags</c> specifies what protocols are
			/// to be used to locate the PAC file. If both the DHCP and DNS auto detect flags are specified, then DHCP is used first; if no
			/// PAC URL is discovered using DHCP, then DNS is used.
			/// </para>
			/// <para>If <c>dwFlags</c> does not include the WINHTTP_AUTOPROXY_AUTO_DETECT flag, then <c>dwAutoDetectFlags</c> must be zero.</para>
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
			/// <term>
			/// Use DNS to attempt to locate the proxy auto-configuration file at a well-known location on the domain of the local computer.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public WINHTTP_AUTO_DETECT_TYPE dwAutoDetectFlags;

			/// <summary>
			/// <para>
			/// If <c>dwFlags</c> includes the WINHTTP_AUTOPROXY_CONFIG_URL flag, the <c>lpszAutoConfigUrl</c> must point to a
			/// <c>null</c>-terminated Unicode string that contains the URL of the proxy auto-configuration (PAC) file.
			/// </para>
			/// <para>If <c>dwFlags</c> does not include the WINHTTP_AUTOPROXY_CONFIG_URL flag, then <c>lpszAutoConfigUrl</c> must be <c>NULL</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszAutoConfigUrl;

			/// <summary>Reserved for future use; must be <c>NULL</c>.</summary>
			public IntPtr lpvReserved;

			/// <summary>Reserved for future use; must be zero.</summary>
			public uint dwReserved;

			/// <summary>
			/// <para>
			/// Specifies whether the client's domain credentials should be automatically sent in response to an NTLM or Negotiate
			/// Authentication challenge when WinHTTP requests the PAC file.
			/// </para>
			/// <para>
			/// If this flag is TRUE, credentials should automatically be sent in response to an authentication challenge. If this flag is
			/// FALSE and authentication is required to download the PAC file, the WinHttpGetProxyForUrl function fails.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAutoLogonIfChallenged;
		}

		/// <summary>
		/// The <c>WINHTTP_CERTIFICATE_INFO</c> structure contains certificate information returned from the server. This structure is used
		/// by the WinHttpQueryOption function.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <c>WINHTTP_CERTIFICATE_INFO</c> structure contains information on the certificate returned by the server when the connection
		/// uses SSL/TLS. The WinHttpQueryOption function returns the <c>WINHTTP_CERTIFICATE_INFO</c> structure when the <c>dwOption</c>
		/// parameter passed to the <c>WinHttpQueryOption</c> function is set to <c>WINHTTP_OPTION_SECURITY_CERTIFICATE_STRUCT</c>. For more
		/// information, see Option Flags.
		/// </para>
		/// <para>
		/// The WinHttpQueryOption function does not set the <c>lpszProtocolName</c>, <c>lpszSignatureAlgName</c>, and
		/// <c>lpszEncryptionAlgName</c> members of the <c>WINHTTP_CERTIFICATE_INFO</c> structure, so these member are always returned as <c>NULL</c>.
		/// </para>
		/// <para>
		/// Once the application no longer needs the returned <c>WINHTTP_CERTIFICATE_INFO</c> structure, the LocalFree function should be
		/// called to free any pointers returned in the structure. The structure members containing pointers that are not NULL and need to be
		/// freed are <c>lpszSubjectInfo</c> and <c>lpszIssuerInfo</c>.
		/// </para>
		/// <para>
		/// <note type="note">For Windows XP and Windows 2000, see the Run-Time Requirements section of the Windows HTTP Services start page.</note>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_certificate_info typedef struct
		// _WINHTTP_CERTIFICATE_INFO { FILETIME ftExpiry; FILETIME ftStart; LPWSTR lpszSubjectInfo; LPWSTR lpszIssuerInfo; LPWSTR
		// lpszProtocolName; LPWSTR lpszSignatureAlgName; LPWSTR lpszEncryptionAlgName; DWORD dwKeySize; } WINHTTP_CERTIFICATE_INFO, *PWINHTTP_CERTIFICATE_INFO;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_CERTIFICATE_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_CERTIFICATE_INFO
		{
			/// <summary>A FILETIME structure that contains the date the certificate expires.</summary>
			public FILETIME ftExpiry;

			/// <summary>A FILETIME structure that contains the date the certificate becomes valid.</summary>
			public FILETIME ftStart;

			/// <summary>
			/// A pointer to a buffer that contains the name of the organization, site, and server for which the certificate was issued.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszSubjectInfo;

			/// <summary>A pointer to a buffer that contains the name of the organization, site, and server that issued the certificate.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszIssuerInfo;

			/// <summary>
			/// A pointer to a buffer that contains the name of the protocol used to provide the secure connection. This member is not
			/// current used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszProtocolName;

			/// <summary>
			/// A pointer to a buffer that contains the name of the algorithm used to sign the certificate. This member is not current used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszSignatureAlgName;

			/// <summary>
			/// A pointer to a buffer that contains the name of the algorithm used to perform encryption over the secure channel (SSL/TLS)
			/// connection. This member is not current used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszEncryptionAlgName;

			/// <summary>The size, in bytes, of the key.</summary>
			public uint dwKeySize;
		}

		/// <summary>Represents a connection group.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_connection_group typedef struct
		// _WINHTTP_CONNECTION_GROUP { ULONG cConnections; GUID guidGroup; } WINHTTP_CONNECTION_GROUP, *PWINHTTP_CONNECTION_GROUP;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_CONNECTION_GROUP")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_CONNECTION_GROUP
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of connections marked with guidGroup.</para>
			/// </summary>
			public uint cConnections;

			/// <summary>
			/// <para>Type: <c>GUID</c></para>
			/// <para>A http connection <c>GUID</c>.</para>
			/// </summary>
			public Guid guidGroup;
		}

		/// <summary>
		/// The <c>WINHTTP_CONNECTION_INFO</c> structure contains the source and destination IP address of the request that generated the response.
		/// </summary>
		/// <remarks>
		/// <para>
		/// When WinHttpReceiveResponse returns, the application can retrieve the source and destination IP address of the request that
		/// generated the response. The application calls WinHttpQueryOption with the <c>WINHTTP_OPTION_CONNECTION_INFO</c> option, and
		/// provides the <c>WINHTTP_CONNECTION_INFO</c> structure in the <c>lpBuffer</c> parameter.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows the call to WinHttpQueryOption. Winsock2.h must be included before Winhttp.h when using the
		/// <c>WINHTTP_OPTION_CONNECTION_INFO</c> option.
		/// </para>
		/// <para>
		/// If the original request was redirected, the <c>WINHTTP_CONNECTION_INFO</c> structure contains the IP address and port of the
		/// request that resulted from the first non-30X response.
		/// </para>
		/// <para>
		/// <code>WINHTTP_CONNECTION_INFO ConnInfo; DWORD dwConnInfoSize = sizeof(WINHTTP_CONNECTION_INFO); WinHttpQueryOption( hRequest, WINHTTP_OPTION_CONNECTION_INFO, &amp;ConnInfo, &amp;dwConnInfoSize);</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_connection_info typedef struct
		// _WINHTTP_CONNECTION_INFO { DWORD cbSize; SOCKADDR_STORAGE LocalAddress; SOCKADDR_STORAGE RemoteAddress; } WINHTTP_CONNECTION_INFO, *PWINHTTP_CONNECTION_INFO;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_CONNECTION_INFO")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct WINHTTP_CONNECTION_INFO
		{
			/// <summary>The size, in bytes, of the <c>WINHTTP_CONNECTION_INFO</c> structure.</summary>
			public uint cbSize;

			/// <summary>A SOCKADDR_STORAGE structure that contains the local IP address and port of the original request.</summary>
			public SOCKADDR_STORAGE LocalAddress;

			/// <summary>A SOCKADDR_STORAGE structure that contains the remote IP address and port of the original request.</summary>
			public SOCKADDR_STORAGE RemoteAddress;
		}

		/// <summary>
		/// <para>The <c>WINHTTP_CREDS</c> structure contains user credential information used for server and proxy authentication.</para>
		/// <para><c>Note</c> This structure has been deprecated. Instead, the use of the WINHTTP_CREDS_EX structure is recommended.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// This structure is used with options <c>WINHTTP_OPTION_GLOBAL_SERVER_CREDS</c> and <c>WINHTTP_OPTION_GLOBAL_PROXY_CREDS</c> option
		/// flags. These options require the registry key <c>HKLM\Software\Microsoft\Windows\CurrentVersion\Internet
		/// Settings!ShareCredsWithWinHttp</c>. This registry key is not present by default.
		/// </para>
		/// <para>
		/// When it is set, WinINet will send credentials down to WinHTTP. Whenever WinHttp gets an authentication challenge and if there are
		/// no credentials set on the current handle, it will use the credentials provided by WinINet. In order to share server credentials
		/// in addition to proxy credentials, users needs to set the <c>WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS</c> option flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_creds typedef struct tagWINHTTP_CREDS { LPSTR
		// lpszUserName; LPSTR lpszPassword; LPSTR lpszRealm; DWORD dwAuthScheme; LPSTR lpszHostName; DWORD dwPort; } WINHTTP_CREDS, *PWINHTTP_CREDS;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp.tagWINHTTP_CREDS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_CREDS
		{
			/// <summary>Pointer to a buffer that contains username.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszUserName;

			/// <summary>Pointer to a buffer that contains password.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszPassword;

			/// <summary>Pointer to a buffer that contains realm.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszRealm;

			/// <summary>
			/// <para>A flag that contains the authentication scheme, as one of the following values.</para>
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
			/// <term><c>INHTTP_AUTH_SCHEME_DIGEST</c></term>
			/// <term>Use digest authentication.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTH_SCHEME_NEGOTIATE</c></term>
			/// <term>Select between NTLM and Kerberos authentication.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WINHTTP_AUTH_SCHEME dwAuthScheme;

			/// <summary>Pointer to a buffer that contains hostname.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszHostName;

			/// <summary>The server connection port.</summary>
			public uint dwPort;
		}

		/// <summary>The <c>WINHTTP_CREDS_EX</c> structure contains user credential information used for server and proxy authentication.</summary>
		/// <remarks>
		/// <para>
		/// This structure is used with options <c>WINHTTP_OPTION_GLOBAL_SERVER_CREDS</c> and <c>WINHTTP_OPTION_GLOBAL_PROXY_CREDS</c> option
		/// flags. These options require the registry key <c>HKLM\Software\Microsoft\Windows\CurrentVersion\Internet
		/// Settings\ShareCredsWithWinHttp</c>. This registry key is not present by default.
		/// </para>
		/// <para>
		/// When it is set, WinINet will send credentials down to WinHTTP. Whenever WinHttp gets an authentication challenge and if there are
		/// no credentials set on the current handle, it will use the credentials provided by WinINet. In order to share server credentials
		/// in addition to proxy credentials, users needs to set the <c>WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS</c> option flag.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_creds_ex typedef struct tagWINHTTP_CREDS_EX { LPSTR
		// lpszUserName; LPSTR lpszPassword; LPSTR lpszRealm; DWORD dwAuthScheme; LPSTR lpszHostName; DWORD dwPort; LPSTR lpszUrl; }
		// WINHTTP_CREDS_EX, *PWINHTTP_CREDS_EX;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp.tagWINHTTP_CREDS_EX")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_CREDS_EX
		{
			/// <summary>Pointer to a buffer that contains username.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszUserName;

			/// <summary>Pointer to a buffer that contains password.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszPassword;

			/// <summary>Pointer to a buffer that contains realm.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszRealm;

			/// <summary>
			/// <para>A flag that contains the authentication scheme, as one of the following values.</para>
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
			/// <term><c>INHTTP_AUTH_SCHEME_DIGEST</c></term>
			/// <term>Use digest authentication.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_AUTH_SCHEME_NEGOTIATE</c></term>
			/// <term>Select between NTLM and Kerberos authentication.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WINHTTP_AUTH_SCHEME dwAuthScheme;

			/// <summary>Pointer to a buffer that contains hostname.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszHostName;

			/// <summary>The server connection port.</summary>
			public uint dwPort;

			/// <summary>Pointer to a buffer that contains target URL.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string lpszUrl;
		}

		/// <summary>The <c>WINHTTP_CURRENT_USER_IE_PROXY_CONFIG</c> structure contains the Internet Explorer proxy configuration information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_current_user_ie_proxy_config typedef struct
		// _WINHTTP_CURRENT_USER_IE_PROXY_CONFIG { BOOL fAutoDetect; LPWSTR lpszAutoConfigUrl; LPWSTR lpszProxy; LPWSTR lpszProxyBypass; }
		// WINHTTP_CURRENT_USER_IE_PROXY_CONFIG, *PWINHTTP_CURRENT_USER_IE_PROXY_CONFIG;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_CURRENT_USER_IE_PROXY_CONFIG")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_CURRENT_USER_IE_PROXY_CONFIG
		{
			/// <summary>
			/// If TRUE, indicates that the Internet Explorer proxy configuration for the current user specifies "automatically detect settings".
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fAutoDetect;

			/// <summary>
			/// Pointer to a null-terminated Unicode string that contains the auto-configuration URL if the Internet Explorer proxy
			/// configuration for the current user specifies "Use automatic proxy configuration".
			/// </summary>
			public StrPtrUni lpszAutoConfigUrl;

			/// <summary>
			/// Pointer to a null-terminated Unicode string that contains the proxy URL if the Internet Explorer proxy configuration for the
			/// current user specifies "use a proxy server".
			/// </summary>
			public StrPtrUni lpszProxy;

			/// <summary>Pointer to a null-terminated Unicode string that contains the optional proxy by-pass server list.</summary>
			public StrPtrUni lpszProxyBypass;

			/// <summary>Frees the memory tied to the strings in this structure.</summary>
			public void FreeMemory()
			{
				Marshal.FreeHGlobal((IntPtr)lpszAutoConfigUrl);
				Marshal.FreeHGlobal((IntPtr)lpszProxy);
				Marshal.FreeHGlobal((IntPtr)lpszProxyBypass);
				lpszAutoConfigUrl = lpszProxy = lpszProxyBypass = default;
			}
		}

		/// <summary>Represents an HTTP request header as a name/value string pair.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_extended_header typedef struct
		// _WINHTTP_EXTENDED_HEADER { union { PCWSTR pwszName; PCSTR pszName; }; union { PCWSTR pwszValue; PCSTR pszValue; }; }
		// WINHTTP_EXTENDED_HEADER, *PWINHTTP_EXTENDED_HEADER;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_EXTENDED_HEADER")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WINHTTP_EXTENDED_HEADER
		{
			/// <summary>A string containing a name.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszName;

			/// <summary>A string containing a value.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszValue;

			/// <summary>Initializes a new instance of the <see cref="WINHTTP_EXTENDED_HEADER"/> struct.</summary>
			/// <param name="name">The name.</param>
			/// <param name="value">The value.</param>
			public WINHTTP_EXTENDED_HEADER(string name, string value)
			{
				pszName = name;
				pszValue = value;
			}

			/// <summary>Performs an implicit conversion from <see cref="System.ValueTuple{TName, TValue}"/> to <see cref="WINHTTP_EXTENDED_HEADER"/>.</summary>
			/// <param name="t">The tuple.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WINHTTP_EXTENDED_HEADER((string name, string value) t) => new(t.name, t.value);
		}

		/// <summary>Represents an HTTP request header name.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_header_name typedef union _WINHTTP_HEADER_NAME {
		// PCWSTR pwszName; PCSTR pszName; } WINHTTP_HEADER_NAME, *PWINHTTP_HEADER_NAME;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_HEADER_NAME")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct WINHTTP_HEADER_NAME
		{
			/// <summary>A string containing a name.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string pszName;
		}

		/// <summary>Represents a collection of connection groups.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_host_connection_group typedef struct
		// _WINHTTP_HOST_CONNECTION_GROUP { PCWSTR pwszHost; ULONG cConnectionGroups; PWINHTTP_CONNECTION_GROUP pConnectionGroups; }
		// WINHTTP_HOST_CONNECTION_GROUP, *PWINHTTP_HOST_CONNECTION_GROUP;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_HOST_CONNECTION_GROUP")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_HOST_CONNECTION_GROUP
		{
			/// <summary>
			/// <para>Type: <c>PCWSTR</c></para>
			/// <para>A string containing the host name.</para>
			/// </summary>
			public StrPtrUni pwszHost;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of elements in pConnectionGroups.</para>
			/// </summary>
			public uint cConnectionGroups;

			/// <summary>
			/// <para>Type: <c>PWINHTTP_CONNECTION_GROUP</c></para>
			/// <para>An array of WINHTTP_CONNECTION_GROUP objects.</para>
			/// </summary>
			public IntPtr pConnectionGroups;

			/// <summary>Gets the list of WINHTTP_CONNECTION_GROUP objects.</summary>
			public ReadOnlySpan<WINHTTP_CONNECTION_GROUP> ConnectionGroups => pConnectionGroups.AsReadOnlySpan<WINHTTP_CONNECTION_GROUP>((int)cConnectionGroups);
		}

		/// <summary>
		/// See the option flag <c>WINHTTP_OPTION_MATCH_CONNECTION_GUID</c>. That option takes as input a
		/// <c>WINHTTP_MATCH_CONNECTION_GUID</c> value.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_match_connection_guid typedef struct
		// _WINHTTP_MATCH_CONNECTION_GUID { GUID ConnectionGuid; ULONGLONG ullFlags; } WINHTTP_MATCH_CONNECTION_GUID, *PWINHTTP_MATCH_CONNECTION_GUID;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_MATCH_CONNECTION_GUID")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_MATCH_CONNECTION_GUID
		{
			/// <summary>
			/// <para>Type: <c>GUID</c></para>
			/// <para>A connection's <c>GUID</c>.</para>
			/// <para>
			/// When <c>WINHTTP_OPTION_MATCH_CONNECTION_GUID</c> is set on a request, WinHttp attempts to serve the request on a connection
			/// matching ConnectionGuid.
			/// </para>
			/// </summary>
			public Guid ConnectionGuid;

			/// <summary>
			/// <para>Type: <c>ULONGLONG</c></para>
			/// <para>Flags.</para>
			/// <para>
			/// Due to the nature of connection-matching logic, it's possible for an unmarked connection to be assigned to serve the request
			/// (if one is encountered before a matching marked connection is). Set ullFlags to
			/// <c>WINHTTP_MATCH_CONNECTION_GUID_FLAG_REQUIRE_MARKED_CONNECTION</c> if you don't want an unmarked connection to be matched.
			/// When using that flag, if no matching marked connection is found, then a new connection is created, and the request is sent on
			/// that connection.
			/// </para>
			/// </summary>
			public WINHTTP_MATCH_CONNECTION_GUID_FLAG ullFlags;
		}

		/// <summary>The <c>WINHTTP_PROXY_INFO</c> structure contains the session or default proxy configuration.</summary>
		/// <remarks>
		/// <para>
		/// This structure is used with WinHttpSetOption and WinHttpQueryOption to get or set the proxy configuration for the current session
		/// by specifying the WINHTTP_OPTION_PROXY flag.
		/// </para>
		/// <para>
		/// This structure is used with WinHttpSetDefaultProxyConfiguration and WinHttpGetDefaultProxyConfiguration to get or set the default
		/// proxy configuration in the registry.
		/// </para>
		/// <para>The proxy server list contains one or more of the following strings separated by semicolons or whitespace.</para>
		/// <para>
		/// <code>([&lt;scheme&gt;=][&lt;scheme&gt;"://"]&lt;server&gt;[":"&lt;port&gt;])</code>
		/// </para>
		/// <para>
		/// The proxy bypass list contains one or more server names separated by semicolons or whitespace. The proxy bypass list can also
		/// contain the string "&lt;local&gt;" to indicate that all local intranet sites are bypassed. Local intranet sites are considered to
		/// be all servers that do not contain a period in their name.
		/// </para>
		/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_proxy_info typedef struct _WINHTTP_PROXY_INFO {
		// DWORD dwAccessType; LPWSTR lpszProxy; LPWSTR lpszProxyBypass; } WINHTTP_PROXY_INFO, *LPWINHTTP_PROXY_INFO, *PWINHTTP_PROXY_INFO;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_PROXY_INFO")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_PROXY_INFO
		{
			/// <summary>
			/// <para>Unsigned long integer value that contains the access type. This can be one of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>WINHTTP_ACCESS_TYPE_NO_PROXY</c></term>
			/// <term>Internet accessed through a direct connection.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_ACCESS_TYPE_DEFAULT_PROXY</c></term>
			/// <term>Applies only when setting proxy information.</term>
			/// </item>
			/// <item>
			/// <term><c>WINHTTP_ACCESS_TYPE_NAMED_PROXY</c></term>
			/// <term>Internet accessed using a proxy.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WINHTTP_ACCESS_TYPE dwAccessType;

			/// <summary>Pointer to a string value that contains the proxy server list.</summary>
			public StrPtrUni lpszProxy;

			/// <summary>Pointer to a string value that contains the proxy bypass list.</summary>
			public StrPtrUni lpszProxyBypass;

			/// <summary>Frees the memory tied to the strings in this structure.</summary>
			public void FreeMemory()
			{
				Marshal.FreeHGlobal((IntPtr)lpszProxy);
				Marshal.FreeHGlobal((IntPtr)lpszProxyBypass);
				lpszProxy = lpszProxyBypass = default;
			}
		}

		/// <summary>The <c>WINHTTP_PROXY_RESULT</c> structure contains collection of proxy result entries provided by WinHttpGetProxyResult.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_proxy_result typedef struct _WINHTTP_PROXY_RESULT {
		// DWORD cEntries; WINHTTP_PROXY_RESULT_ENTRY *pEntries; } WINHTTP_PROXY_RESULT;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_PROXY_RESULT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_PROXY_RESULT
		{
			/// <summary>The number of entries in the <c>pEntries</c> array.</summary>
			public uint cEntries;

			/// <summary>A pointer to an array of WINHTTP_PROXY_RESULT_ENTRY structures.</summary>
			public IntPtr pEntries;

			/// <summary>An array of WINHTTP_PROXY_RESULT_ENTRY structures.</summary>
			public WINHTTP_PROXY_RESULT_ENTRY[] Entries => pEntries.ToArray<WINHTTP_PROXY_RESULT_ENTRY>((int)cEntries);
		}

		/// <summary>The <c>WINHTTP_PROXY_RESULT_ENTRY</c> structure contains a result entry from a call to WinHttpGetProxyResult.</summary>
		/// <remarks>This structure is stored in an array inside of a WINHTTP_PROXY_RESULT structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_proxy_result_entry typedef struct
		// _WINHTTP_PROXY_RESULT_ENTRY { BOOL fProxy; BOOL fBypass; INTERNET_SCHEME ProxyScheme; PWSTR pwszProxy; INTERNET_PORT ProxyPort; } WINHTTP_PROXY_RESULT_ENTRY;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_PROXY_RESULT_ENTRY")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_PROXY_RESULT_ENTRY
		{
			/// <summary>
			/// A <c>BOOL</c> that whether a result is from a proxy. It is set to <c>TRUE</c> if the result contains a proxy or <c>FALSE</c>
			/// if the result does not contain a proxy.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fProxy;

			/// <summary>
			/// A BOOL that indicates if the result is bypassing a proxy (on an intranet). It is set to <c>TRUE</c> if the result is
			/// bypassing a proxy or <c>FALSE</c> if all traffic is direct. This parameter applies only if <c>fProxy</c> is <c>FALSE</c>.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fBypass;

			/// <summary>An INTERNET_SCHEME value that specifies the scheme of the proxy.</summary>
			public INTERNET_SCHEME ProxyScheme;

			/// <summary>A string that contains the hostname of the proxy.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwszProxy;

			/// <summary>An INTERNET_PORT value that specifies the port of the proxy.</summary>
			public INTERNET_PORT ProxyPort;
		}

		/// <summary/>
		[PInvokeData("winhttp.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_PROXY_SETTINGS
		{
			/// <summary/>
			public uint dwStructSize;
			/// <summary/>
			public uint dwFlags;
			/// <summary/>
			public uint dwCurrentSettingsVersion;
			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszConnectionName;
			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszProxy;
			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszProxyBypass;
			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszAutoconfigUrl;
			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszAutoconfigSecondaryUrl;
			/// <summary/>
			public uint dwAutoDiscoveryFlags;
			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszLastKnownGoodAutoConfigUrl;
			/// <summary/>
			public uint dwAutoconfigReloadDelayMins;
			/// <summary/>
			public FILETIME ftLastKnownDetectTime;
			/// <summary/>
			public uint dwDetectedInterfaceIpCount;
			/// <summary/>
			public IntPtr pdwDetectedInterfaceIp;
			/// <summary/>
			public uint cNetworkKeys;
			/// <summary/>
			public IntPtr pNetworkKeys;
		}

		/// <summary/>
		public struct WINHTTP_PROXY_NETWORKING_KEY
		{
			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			public byte[] pbBuffer;
		}

		/// <summary>Represents a description of the current state of WinHttp's connections. Retrieved via WinHttpQueryConnectionGroup.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_query_connection_group_result typedef struct
		// _WINHTTP_QUERY_CONNECTION_GROUP_RESULT { ULONG cHosts; PWINHTTP_HOST_CONNECTION_GROUP pHostConnectionGroups; }
		// WINHTTP_QUERY_CONNECTION_GROUP_RESULT, *PWINHTTP_QUERY_CONNECTION_GROUP_RESULT;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_QUERY_CONNECTION_GROUP_RESULT")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_QUERY_CONNECTION_GROUP_RESULT
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of elements in pHostConnectionGroups.</para>
			/// </summary>
			public uint cHosts;

			/// <summary>
			/// <para>Type: <c>PWINHTTP_HOST_CONNECTION_GROUP</c></para>
			/// <para>An array of WINHTTP_HOST_CONNECTION_GROUP objects.</para>
			/// </summary>
			public IntPtr pHostConnectionGroups;

			/// <summary>
			/// Gets a list of WINHTTP_HOST_CONNECTION_GROUP objects.
			/// </summary>
			public ReadOnlySpan<WINHTTP_HOST_CONNECTION_GROUP> HostConnectionGroups => pHostConnectionGroups.AsReadOnlySpan<WINHTTP_HOST_CONNECTION_GROUP>((int)cHosts);
		}

		/// <summary>The <c>WINHTTP_REQUEST_STATS</c> structure contains a variety of statistics for a request.</summary>
		/// <remarks>
		/// This structure is used with WinHttpQueryOption to retrieve statistics for a request by specifying the
		/// <c>WINHTTP_OPTION_REQUEST_STATS</c> flag.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_request_stats typedef struct _WINHTTP_REQUEST_STATS
		// { ULONGLONG ullFlags; ULONG ulIndex; ULONG cStats; ULONGLONG rgullStats[WinHttpRequestStatMax]; } WINHTTP_REQUEST_STATS, *PWINHTTP_REQUEST_STATS;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_REQUEST_STATS")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct WINHTTP_REQUEST_STATS
		{
			/// <summary>
			/// <para>Flags containing details on how the request was made. The following flags are available.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WINHTTP_REQUEST_STAT_FLAG_TCP_FAST_OPEN</term>
			/// <term>TCP Fast Open occurred.</term>
			/// </item>
			/// <item>
			/// <term>WINHTTP_REQUEST_STAT_FLAG_TLS_SESSION_RESUMPTION</term>
			/// <term>TLS Session Resumption occurred.</term>
			/// </item>
			/// <item>
			/// <term>WINHTTP_REQUEST_STAT_FLAG_TLS_FALSE_START</term>
			/// <term>TLS False Start occurred.</term>
			/// </item>
			/// <item>
			/// <term>WINHTTP_REQUEST_STAT_FLAG_PROXY_TLS_SESSION_RESUMPTION</term>
			/// <term>TLS Session Resumption occurred for the proxy connection.</term>
			/// </item>
			/// <item>
			/// <term>WINHTTP_REQUEST_STAT_FLAG_PROXY_TLS_FALSE_START</term>
			/// <term>TLS False Start occurred for the proxy connection.</term>
			/// </item>
			/// <item>
			/// <term>WINHTTP_REQUEST_STAT_FLAG_FIRST_REQUEST</term>
			/// <term>This is the first request on the connection.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WINHTTP_REQUEST_STAT_FLAG ullFlags;

			/// <summary>
			/// The index of the request on the connection. This indicates how many prior requests were sent over the shared connection.
			/// </summary>
			public uint ulIndex;

			/// <summary>
			/// Unsigned long integer value that contains the number of statistics to retrieve. This should generally be set to <c>WinHttpRequestStatLast</c>.
			/// </summary>
			public uint cStats;

			/// <summary>Array of unsigned long long integer values that will contain the returned statistics, indexed by <c>WINHTTP_REQUEST_STAT_ENTRY</c>.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public ulong[] rgullStats;
		}

		/// <summary>The <c>WINHTTP_REQUEST_TIMES</c> structure contains a variety of timing information for a request.</summary>
		/// <remarks>
		/// This structure is used with WinHttpQueryOption to retrieve timing information for a request by specifying the
		/// <c>WINHTTP_OPTION_REQUEST_TIMES</c> flag.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_request_times typedef struct _WINHTTP_REQUEST_TIMES
		// { ULONG cTimes; ULONGLONG rgullTimes[WinHttpRequestTimeMax]; } WINHTTP_REQUEST_TIMES, *PWINHTTP_REQUEST_TIMES;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_REQUEST_TIMES")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct WINHTTP_REQUEST_TIMES
		{
			/// <summary>
			/// Unsigned long integer value that contains the number of timings to retrieve. This should generally be set to <c>WinHttpRequestTimeLast</c>.
			/// </summary>
			public uint cTimes;

			/// <summary>
			/// <para>Array of unsigned long long integer values that will contain the returned timings, indexed by <c>WINHTTP_REQUEST_TIME_ENTRY</c>.</para>
			/// <para>Times are measured as performance counter values; for more information, see QueryPerformanceCounter.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
			public ulong[] rgullTimes;
		}

		/// <summary>The <c>WINHTTP_SECURITY_INFO</c> structure contains the SChannel connection and cipher information for a request.</summary>
		/// <remarks>
		/// This structure is used with <c>WinHttpQueryOption</c> to retrieve security information for a request by specifying the
		/// <c>WINHTTP_OPTION_SECURITY_INFO</c> flag.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_security_info typedef struct _WINHTTP_SECURITY_INFO
		// { SecPkgContext_ConnectionInfo ConnectionInfo; SecPkgContext_CipherInfo CipherInfo; } WINHTTP_SECURITY_INFO, *PWINHTTP_SECURITY_INFO;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_SECURITY_INFO")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_SECURITY_INFO
		{
			/// <summary><c>SecPkgContext_ConnectionInfo</c> containing the SChannel connection information for the request.</summary>
			public SecPkgContext_ConnectionInfo ConnectionInfo;

			/// <summary><c>SecPkgContext_CipherInfo</c> containing the SChannel cipher information for the request.</summary>
			public SecPkgContext_CipherInfo CipherInfo;
		}

		/// <summary>
		/// The <c>URL_COMPONENTS</c> structure contains the constituent parts of a URL. This structure is used with the WinHttpCrackUrl and
		/// WinHttpCreateUrl functions.
		/// </summary>
		/// <remarks>
		/// <para>
		/// For the WinHttpCrackUrl function, if a pointer member and its corresponding length member are both zero, that component of the
		/// URL is not returned. If the pointer member is <c>NULL</c> but the length member is not zero, both the pointer and length members
		/// are returned. If both pointer and corresponding length members are nonzero, the pointer member points to a buffer where the
		/// component is copied. All escape sequences can be removed from a component, depending on the <c>dwFlags</c> parameter of WinHttpCrackUrl.
		/// </para>
		/// <para>
		/// For the WinHttpCreateUrl function, the pointer members should be <c>NULL</c> if the component of the URL is not required. If the
		/// corresponding length member is zero, the pointer member is the pointer to a zero-terminated string. If the length member is not
		/// zero, it is the string length of the corresponding pointer member.
		/// </para>
		/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-url_components typedef struct _WINHTTP_URL_COMPONENTS {
		// DWORD dwStructSize; LPWSTR lpszScheme; DWORD dwSchemeLength; INTERNET_SCHEME nScheme; LPWSTR lpszHostName; DWORD dwHostNameLength;
		// INTERNET_PORT nPort; LPWSTR lpszUserName; DWORD dwUserNameLength; LPWSTR lpszPassword; DWORD dwPasswordLength; LPWSTR lpszUrlPath;
		// DWORD dwUrlPathLength; LPWSTR lpszExtraInfo; DWORD dwExtraInfoLength; } URL_COMPONENTS, *LPURL_COMPONENTS;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_URL_COMPONENTS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_URL_COMPONENTS
		{
			/// <summary>
			/// Size of this structure, in bytes. Used for version checking. The size of this structure must be set to initialize this
			/// structure properly.
			/// </summary>
			public uint dwStructSize;

			/// <summary>Pointer to a string value that contains the scheme name.</summary>
			public StrPtrUni lpszScheme;

			/// <summary>Length of the scheme name, in characters.</summary>
			public uint dwSchemeLength;

			/// <summary>
			/// <para>Internet protocol scheme. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>INTERNET_SCHEME_HTTP</c> 1</term>
			/// <term>The Internet scheme is the HTTP protocol. See RFC 2616 for more information.</term>
			/// </item>
			/// <item>
			/// <term><c>INTERNET_SCHEME_HTTPS</c> 2</term>
			/// <term>The Internet scheme, HTTPS, is an HTTP protocol that uses secure transaction semantics.</term>
			/// </item>
			/// </list>
			/// </summary>
			public INTERNET_SCHEME nScheme;

			/// <summary>Pointer to a string value that contains the host name.</summary>
			public StrPtrUni lpszHostName;

			/// <summary>Length of the host name, in characters.</summary>
			public uint dwHostNameLength;

			/// <summary>Port number.</summary>
			public ushort nPort;

			/// <summary>Pointer to a string that contains the user name.</summary>
			public StrPtrUni lpszUserName;

			/// <summary>Length of the user name, in characters.</summary>
			public uint dwUserNameLength;

			/// <summary>Pointer to a string that contains the password.</summary>
			public StrPtrUni lpszPassword;

			/// <summary>Length of the password, in characters.</summary>
			public uint dwPasswordLength;

			/// <summary>Pointer to a string that contains the URL path.</summary>
			public StrPtrUni lpszUrlPath;

			/// <summary>Length of the URL path, in characters.</summary>
			public uint dwUrlPathLength;

			/// <summary>Pointer to a string value that contains the extra information, for example, ?something or #something.</summary>
			public StrPtrUni lpszExtraInfo;

			/// <summary>Unsigned long integer value that contains the length of the extra information, in characters.</summary>
			public uint dwExtraInfoLength;

			/// <summary>Initializes a new instance of the <see cref="WINHTTP_URL_COMPONENTS"/> struct.</summary>
			public WINHTTP_URL_COMPONENTS()
			{
				dwStructSize = (uint)Marshal.SizeOf(typeof(WINHTTP_URL_COMPONENTS));
				lpszScheme = lpszHostName = lpszUrlPath = lpszUserName = lpszPassword = lpszExtraInfo = default;
				nPort = 0;
				nScheme = 0;
				dwSchemeLength = dwHostNameLength = dwUserNameLength = dwPasswordLength = dwUrlPathLength = dwExtraInfoLength = unchecked((uint)-1);
			}
		}

		/// <summary>
		/// The <c>URL_COMPONENTS</c> structure contains the constituent parts of a URL. This structure is used with the WinHttpCrackUrl and
		/// WinHttpCreateUrl functions.
		/// </summary>
		/// <remarks>
		/// <para>
		/// For the WinHttpCrackUrl function, if a pointer member and its corresponding length member are both zero, that component of the
		/// URL is not returned. If the pointer member is <c>NULL</c> but the length member is not zero, both the pointer and length members
		/// are returned. If both pointer and corresponding length members are nonzero, the pointer member points to a buffer where the
		/// component is copied. All escape sequences can be removed from a component, depending on the <c>dwFlags</c> parameter of WinHttpCrackUrl.
		/// </para>
		/// <para>
		/// For the WinHttpCreateUrl function, the pointer members should be <c>NULL</c> if the component of the URL is not required. If the
		/// corresponding length member is zero, the pointer member is the pointer to a zero-terminated string. If the length member is not
		/// zero, it is the string length of the corresponding pointer member.
		/// </para>
		/// <para><c>Note</c> For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-url_components typedef struct _WINHTTP_URL_COMPONENTS {
		// DWORD dwStructSize; LPWSTR lpszScheme; DWORD dwSchemeLength; INTERNET_SCHEME nScheme; LPWSTR lpszHostName; DWORD dwHostNameLength;
		// INTERNET_PORT nPort; LPWSTR lpszUserName; DWORD dwUserNameLength; LPWSTR lpszPassword; DWORD dwPasswordLength; LPWSTR lpszUrlPath;
		// DWORD dwUrlPathLength; LPWSTR lpszExtraInfo; DWORD dwExtraInfoLength; } URL_COMPONENTS, *LPURL_COMPONENTS;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_URL_COMPONENTS")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct WINHTTP_URL_COMPONENTS_IN
		{
			/// <summary>
			/// Size of this structure, in bytes. Used for version checking. The size of this structure must be set to initialize this
			/// structure properly.
			/// </summary>
			public uint dwStructSize;

			/// <summary>Pointer to a string value that contains the scheme name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszScheme;

			/// <summary>Length of the scheme name, in characters.</summary>
			public uint dwSchemeLength;

			/// <summary>
			/// <para>Internet protocol scheme. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term><c>INTERNET_SCHEME_HTTP</c> 1</term>
			/// <term>The Internet scheme is the HTTP protocol. See RFC 2616 for more information.</term>
			/// </item>
			/// <item>
			/// <term><c>INTERNET_SCHEME_HTTPS</c> 2</term>
			/// <term>The Internet scheme, HTTPS, is an HTTP protocol that uses secure transaction semantics.</term>
			/// </item>
			/// </list>
			/// </summary>
			public INTERNET_SCHEME nScheme;

			/// <summary>Pointer to a string value that contains the host name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszHostName;

			/// <summary>Length of the host name, in characters.</summary>
			public uint dwHostNameLength;

			/// <summary>Port number.</summary>
			public ushort nPort;

			/// <summary>Pointer to a string that contains the user name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszUserName;

			/// <summary>Length of the user name, in characters.</summary>
			public uint dwUserNameLength;

			/// <summary>Pointer to a string that contains the password.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszPassword;

			/// <summary>Length of the password, in characters.</summary>
			public uint dwPasswordLength;

			/// <summary>Pointer to a string that contains the URL path.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszUrlPath;

			/// <summary>Length of the URL path, in characters.</summary>
			public uint dwUrlPathLength;

			/// <summary>Pointer to a string value that contains the extra information, for example, ?something or #something.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszExtraInfo;

			/// <summary>Unsigned long integer value that contains the length of the extra information, in characters.</summary>
			public uint dwExtraInfoLength;

			/// <summary>Initializes a new instance of the <see cref="WINHTTP_URL_COMPONENTS"/> struct.</summary>
			public WINHTTP_URL_COMPONENTS_IN(string scheme = null, INTERNET_SCHEME iScheme = INTERNET_SCHEME.INTERNET_SCHEME_HTTPS, string host = null,
				ushort port = 0, string user = null, string pwd = null, string urlPath = null, string extra = null)
			{
				dwStructSize = (uint)Marshal.SizeOf(typeof(WINHTTP_URL_COMPONENTS));
				lpszScheme = scheme;
				lpszHostName = host;
				lpszUrlPath = urlPath;
				lpszUserName = user;
				lpszPassword = pwd;
				lpszExtraInfo = extra;
				nPort = port;
				nScheme = iScheme;
				dwSchemeLength = dwHostNameLength = dwUserNameLength = dwPasswordLength = dwUrlPathLength = dwExtraInfoLength = 0;
			}

			/// <summary>Performs an implicit conversion from <see cref="WINHTTP_URL_COMPONENTS"/> to <see cref="WINHTTP_URL_COMPONENTS_IN"/>.</summary>
			/// <param name="c">The value.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator WINHTTP_URL_COMPONENTS_IN(WINHTTP_URL_COMPONENTS c)
			{
				return new(S(c.lpszScheme, c.dwSchemeLength), c.nScheme, S(c.lpszHostName, c.dwHostNameLength), c.nPort, S(c.lpszUserName, c.dwUserNameLength),
					S(c.lpszPassword, c.dwPasswordLength), S(c.lpszUrlPath, c.dwUrlPathLength), S(c.lpszExtraInfo, c.dwExtraInfoLength));

				static string S(StrPtrUni p, uint l) => StringHelper.GetString((IntPtr)p, (int)l, CharSet.Unicode);
			}
		}

		/// <summary>The <c>WINHTTP_WEB_SOCKET_ASYNC_RESULT</c> includes the result status of a WebSocket operation.</summary>
		/// <remarks>
		/// A <c>WINHTTP_WEB_SOCKET_ASYNC_RESULT</c> structure is passed to the completion callbacks of WebSocket functions such as
		/// WinHttpWebSocketSend, WinHttpWebSocketReceive, and WinHttpWebSocketClose when <c>dwInternetStatus</c> is <c>WINHTTP_CALLBACK_STATUS_REQUEST_ERROR</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_web_socket_async_result typedef struct
		// _WINHTTP_WEB_SOCKET_ASYNC_RESULT { WINHTTP_ASYNC_RESULT AsyncResult; WINHTTP_WEB_SOCKET_OPERATION Operation; } WINHTTP_WEB_SOCKET_ASYNC_RESULT;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_WEB_SOCKET_ASYNC_RESULT")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_WEB_SOCKET_ASYNC_RESULT
		{
			/// <summary>
			/// <para>Type: <c>WINHTTP_ASYNC_RESULT</c></para>
			/// <para>The result of a WebSocket operation.</para>
			/// </summary>
			public WINHTTP_ASYNC_RESULT AsyncResult;

			/// <summary>
			/// <para>Type: <c>WINHTTP_WEB_SOCKET_OPERATION</c></para>
			/// <para>The type of WebSocket operation.</para>
			/// </summary>
			public WINHTTP_WEB_SOCKET_OPERATION Operation;
		}

		/// <summary>The <c>WINHTTP_WEB_SOCKET_STATUS</c> enumeration includes the status of a WebSocket operation.</summary>
		/// <remarks>
		/// <para>
		/// A <c>WINHTTP_WEB_SOCKET_STATUS</c> structure is passed to the completion callback of WinHttpWebSocketSend when
		/// <c>dwInternetStatus</c> is <c>WINHTTP_CALLBACK_STATUS_READ_COMPLETE</c>.
		/// </para>
		/// <para>
		/// A <c>WINHTTP_WEB_SOCKET_STATUS</c> structure is passed to the completion callback of WinHttpWebSocketReceive when
		/// <c>dwInternetStatus</c> is <c>WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE</c>.
		/// </para>
		/// <para>
		/// A <c>WINHTTP_WEB_SOCKET_STATUS</c> structure is passed to the completion callback of WinHttpWebSocketClose when
		/// <c>dwInternetStatus</c> is <c>WINHTTP_CALLBACK_STATUS_CLOSE_COMPLETE</c>.
		/// </para>
		/// <para>
		/// A <c>WINHTTP_WEB_SOCKET_STATUS</c> structure is passed to the completion callback of WinHttpWebSocketShutdown when
		/// <c>dwInternetStatus</c> is <c>WINHTTP_CALLBACK_STATUS_SHUTDOWN_COMPLETE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ns-winhttp-winhttp_web_socket_status typedef struct
		// _WINHTTP_WEB_SOCKET_STATUS { DWORD dwBytesTransferred; WINHTTP_WEB_SOCKET_BUFFER_TYPE eBufferType; } WINHTTP_WEB_SOCKET_STATUS;
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_WEB_SOCKET_STATUS")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINHTTP_WEB_SOCKET_STATUS
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The amount of bytes transferred in the operation.</para>
			/// </summary>
			public uint dwBytesTransferred;

			/// <summary>
			/// <para>Type: <c>WINHTTP_WEB_SOCKET_BUFFER_TYPE</c></para>
			/// <para>The type of data in the buffer.</para>
			/// </summary>
			public WINHTTP_WEB_SOCKET_BUFFER_TYPE eBufferType;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HINTERNET"/> that is disposed using <see cref="WinHttpCloseHandle"/>.</summary>
		public class SafeHINTERNET : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHINTERNET"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeHINTERNET(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHINTERNET"/> class.</summary>
			private SafeHINTERNET() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHINTERNET"/> to <see cref="HINTERNET"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HINTERNET(SafeHINTERNET h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => WinHttpCloseHandle(handle);
		}
	}
}