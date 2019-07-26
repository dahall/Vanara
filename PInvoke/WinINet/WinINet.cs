using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class WinINet
	{
		/// <summary>Uses the default port for FTP servers (port 21).</summary>
		public const ushort INTERNET_DEFAULT_FTP_PORT = 21;

		/// <summary>Uses the default port for Gopher servers (port 70). Note Windows XP and Windows Server 2003 R2 and earlier only.</summary>
		public const ushort INTERNET_DEFAULT_GOPHER_PORT = 70;

		/// <summary>Uses the default port for HTTP servers (port 80).</summary>
		public const ushort INTERNET_DEFAULT_HTTP_PORT = 80;

		/// <summary>Uses the default port for Secure Hypertext Transfer Protocol (HTTPS) servers (port 443).</summary>
		public const ushort INTERNET_DEFAULT_HTTPS_PORT = 443;

		/// <summary>Uses the default port for SOCKS firewall servers (port 1080).</summary>
		public const ushort INTERNET_DEFAULT_SOCKS_PORT = 1080;

		/// <summary>Uses the default port for the service specified by dwService.</summary>
		public const ushort INTERNET_INVALID_PORT_NUMBER = 0;

		/// <summary>Prototype for an application-defined status callback function.</summary>
		/// <param name="hInternet">The handle for which the callback function is called.</param>
		/// <param name="dwContext">A pointer to a variable that specifies the application-defined context value associated with hInternet.</param>
		/// <param name="dwInternetStatus">A status code that indicates why the callback function is called.</param>
		/// <param name="lpvStatusInformation">
		/// A pointer to additional status information. When the INTERNET_STATUS_STATE_CHANGE flag is set, lpvStatusInformation points to a
		/// DWORD that contains one or more of the <see cref="InternetState"/> flags.
		/// </param>
		/// <param name="dwStatusInformationLength">The size, in bytes, of the data pointed to by lpvStatusInformation.</param>
		public delegate void INTERNET_STATUS_CALLBACK([In] IntPtr hInternet, [In, Optional] IntPtr dwContext, [In] InternetStatus dwInternetStatus, [In, Optional] IntPtr lpvStatusInformation, [In] uint dwStatusInformationLength);

		/// <summary>Flags used by <see cref="INTERNET_DIAGNOSTIC_SOCKET_INFO"/>.</summary>
		[Flags]
		public enum IDSI_Flags
		{
			/// <summary>Set if the connection is from the "keep-alive" pool.</summary>
			IDSI_FLAG_KEEP_ALIVE = 0x00000001,

			/// <summary>Set if the HTTP Request is using a secure socket.</summary>
			IDSI_FLAG_SECURE = 0x00000002,

			/// <summary>Set if a proxy is being used to reach the server.</summary>
			IDSI_FLAG_PROXY = 0x00000004,

			/// <summary>Set if a proxy is being used to create a tunnel.</summary>
			IDSI_FLAG_TUNNEL = 0x00000008
		}

		/// <summary>Option to be queried or set within <see cref="INTERNET_PER_CONN_OPTION"/> structure.</summary>
		public enum INTERNET_PER_CONN_OPTION_ID
		{
			/// <summary>Sets or retrieves the connection type.</summary>
			INTERNET_PER_CONN_FLAGS = 1,

			/// <summary>Sets or retrieves a string containing the proxy servers.</summary>
			INTERNET_PER_CONN_PROXY_SERVER = 2,

			/// <summary>Sets or retrieves a string containing the URLs that do not use the proxy server.</summary>
			INTERNET_PER_CONN_PROXY_BYPASS = 3,

			/// <summary>Sets or retrieves a string containing the URL to the automatic configuration script.</summary>
			INTERNET_PER_CONN_AUTOCONFIG_URL = 4,

			/// <summary>Sets or retrieves the automatic discovery settings.</summary>
			INTERNET_PER_CONN_AUTODISCOVERY_FLAGS = 5,

			/// <summary>
			/// Chained autoconfig URL. Used when the primary autoconfig URL points to an INS file that sets a second autoconfig URL for
			/// proxy information.
			/// </summary>
			INTERNET_PER_CONN_AUTOCONFIG_SECONDARY_URL = 6,

			/// <summary>The number of minutes until automatic refresh of autoconfig URL by autodiscovery.</summary>
			INTERNET_PER_CONN_AUTOCONFIG_RELOAD_DELAY_MINS = 7,

			/// <summary>Read only option. Returns the time the last known good autoconfig URL was found using autodiscovery.</summary>
			INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_TIME = 8,

			/// <summary>Read only option. Returns the last known good URL found using autodiscovery.</summary>
			INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_URL = 9,

			/// <summary>Sets or retrieves the connection type.</summary>
			INTERNET_PER_CONN_FLAGS_UI = 10
		}

		/// <summary>Options for the <see cref="InternetOpen(string, InternetOpenType, string, string, InternetApiFlags)"/> function.</summary>
		[Flags]
		public enum InternetApiFlags : uint
		{
			/// <summary>Indicates that a Platform for Privacy Protection (P3P) header is to be associated with a cookie.</summary>
			INTERNET_COOKIE_EVALUATE_P3P = 0x80,

			/// <summary>Indicates that a third-party cookie is being set or retrieved.</summary>
			INTERNET_COOKIE_THIRD_PARTY = 0x10,

			/// <summary>
			/// Makes only asynchronous requests on handles descended from the handle returned from this function. Only the InternetOpen
			/// function uses this flag.
			/// </summary>
			INTERNET_FLAG_ASYNC = 0x10000000,

			/// <summary>Allows a lazy cache write.</summary>
			INTERNET_FLAG_CACHE_ASYNC = 0x00000080,

			/// <summary>
			/// Returns the resource from the cache if the network request for the resource fails due to an ERROR_INTERNET_CONNECTION_RESET
			/// or ERROR_INTERNET_CANNOT_CONNECT error. This flag is used by HttpOpenRequest.
			/// </summary>
			INTERNET_FLAG_CACHE_IF_NET_FAIL = 0x00010000,

			/// <summary>Does not add the returned entity to the cache. This is identical to the preferred value, INTERNET_FLAG_NO_CACHE_WRITE.</summary>
			INTERNET_FLAG_DONT_CACHE = 0x04000000,

			/// <summary>
			/// Attempts to use an existing InternetConnect object if one exists with the same attributes required to make the request. This
			/// is useful only with FTP operations, since FTP is the only protocol that typically performs multiple operations during the
			/// same session. WinINet caches a single connection handle for each HINTERNET handle generated by InternetOpen. The
			/// InternetOpenUrl and InternetConnect functions use this flag for Http and Ftp connections.
			/// </summary>
			INTERNET_FLAG_EXISTING_CONNECT = 0x20000000,

			/// <summary>Indicates that this is a Forms submission.</summary>
			INTERNET_FLAG_FORMS_SUBMIT = 0x00000040,

			/// <summary>
			/// Does not make network requests. All entities are returned from the cache. If the requested item is not in the cache, a
			/// suitable error, such as ERROR_FILE_NOT_FOUND, is returned. Only the InternetOpen function uses this flag.
			/// </summary>
			INTERNET_FLAG_FROM_CACHE = 0x01000000,

			/// <summary>
			/// Indicates that the function should use the copy of the resource that is currently in the Internet cache. The expiration date
			/// and other information about the resource is not checked. If the requested item is not found in the Internet cache, the system
			/// attempts to locate the resource on the network. This value was introduced in Microsoft Internet Explorer 5 and is associated
			/// with the Forward and Back button operations of Internet Explorer.
			/// </summary>
			INTERNET_FLAG_FWD_BACK = 0x00000020,

			/// <summary>
			/// Forces a reload if there is no Expires time and no LastModified time returned from the server when determining whether to
			/// reload the item from the network. This flag can be used by FtpFindFirstFile, FtpGetFile, FtpOpenFile, FtpPutFile,
			/// HttpOpenRequest, and InternetOpenUrl.
			/// <para>Windows XP and Windows Server 2003 R2 and earlier: Also used by GopherFindFirstFile and GopherOpenFile.</para>
			/// </summary>
			INTERNET_FLAG_HYPERLINK = 0x00000400,

			/// <summary>
			/// Disables checking of SSL/PCT-based certificates that are returned from the server against the host name given in the request.
			/// WinINet uses a simple check against certificates by comparing for matching host names and simple wildcarding rules. This flag
			/// can be used by HttpOpenRequest and InternetOpenUrl (for HTTP requests).
			/// </summary>
			INTERNET_FLAG_IGNORE_CERT_CN_INVALID = 0x00001000,

			/// <summary>
			/// Disables checking of SSL/PCT-based certificates for proper validity dates. This flag can be used by HttpOpenRequest and
			/// InternetOpenUrl (for HTTP requests).
			/// </summary>
			INTERNET_FLAG_IGNORE_CERT_DATE_INVALID = 0x00002000,

			/// <summary>
			/// Disables detection of this special type of redirect. When this flag is used, WinINet transparently allows redirects from
			/// HTTPS to HTTP URLs. This flag can be used by HttpOpenRequest and InternetOpenUrl (for HTTP requests).
			/// </summary>
			INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP = 0x00008000,

			/// <summary>
			/// Disables detection of this special type of redirect. When this flag is used, WinINet transparently allow redirects from HTTP
			/// to HTTPS URLs. This flag can be used by HttpOpenRequest and InternetOpenUrl (for HTTP requests).
			/// </summary>
			INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS = 0x00004000,

			/// <summary>
			/// Uses keep-alive semantics, if available, for the connection. This flag is used by HttpOpenRequest and InternetOpenUrl (for
			/// HTTP requests). This flag is required for Microsoft Network (MSN), NTLM, and other types of authentication.
			/// </summary>
			INTERNET_FLAG_KEEP_CONNECTION = 0x00400000,

			/// <summary>No longer supported.</summary>
			INTERNET_FLAG_MAKE_PERSISTENT = 0x02000000,

			/// <summary>
			/// Identical to the preferred value, INTERNET_FLAG_NEED_FILE. Causes a temporary file to be created if the file cannot be
			/// cached. This flag can be used by FtpFindFirstFile, FtpGetFile, FtpOpenFile, FtpPutFile, HttpOpenRequest, and InternetOpenUrl.
			/// <para>Windows XP and Windows Server 2003 R2 and earlier: Also used by GopherFindFirstFile and GopherOpenFile.</para>
			/// </summary>
			INTERNET_FLAG_MUST_CACHE_REQUEST = 0x00000010,

			/// <summary>
			/// Causes a temporary file to be created if the file cannot be cached. This flag can be used by FtpFindFirstFile, FtpGetFile,
			/// FtpOpenFile, FtpPutFile, HttpOpenRequest, and InternetOpenUrl.
			/// <para>Windows XP and Windows Server 2003 R2 and earlier: Also used by GopherFindFirstFile and GopherOpenFile.</para>
			/// </summary>
			INTERNET_FLAG_NEED_FILE = 0x00000010,

			/// <summary>
			/// Does not attempt authentication automatically. This flag can be used by HttpOpenRequest and InternetOpenUrl (for HTTP requests).
			/// </summary>
			INTERNET_FLAG_NO_AUTH = 0x00040000,

			/// <summary>
			/// Does not automatically handle redirection in HttpSendRequest. This flag can also be used by InternetOpenUrl for HTTP requests.
			/// </summary>
			INTERNET_FLAG_NO_AUTO_REDIRECT = 0x00200000,

			/// <summary>
			/// Does not add the returned entity to the cache. This flag is used by , HttpOpenRequest, and InternetOpenUrl.
			/// <para>Windows XP and Windows Server 2003 R2 and earlier: Also used by GopherFindFirstFile and GopherOpenFile.</para>
			/// </summary>
			INTERNET_FLAG_NO_CACHE_WRITE = 0x04000000,

			/// <summary>
			/// Does not automatically add cookie headers to requests, and does not automatically add returned cookies to the cookie
			/// database. This flag can be used by HttpOpenRequest and InternetOpenUrl (for HTTP requests).
			/// </summary>
			INTERNET_FLAG_NO_COOKIES = 0x00080000,

			/// <summary>
			/// Disables the cookie dialog box. This flag can be used by HttpOpenRequest and InternetOpenUrl (HTTP requests only).
			/// </summary>
			INTERNET_FLAG_NO_UI = 0x00000200,

			/// <summary>
			/// Identical to INTERNET_FLAG_FROM_CACHE. Does not make network requests. All entities are returned from the cache. If the
			/// requested item is not in the cache, a suitable error, such as ERROR_FILE_NOT_FOUND, is returned. Only the InternetOpen
			/// function uses this flag.
			/// </summary>
			INTERNET_FLAG_OFFLINE = 0x01000000,

			/// <summary>
			/// Uses passive FTP semantics. Only InternetConnect and InternetOpenUrl use this flag. InternetConnect uses this flag for FTP
			/// requests, and InternetOpenUrl uses this flag for FTP files and directories.
			/// </summary>
			INTERNET_FLAG_PASSIVE = 0x08000000,

			/// <summary>
			/// Forces the request to be resolved by the origin server, even if a cached copy exists on the proxy. The InternetOpenUrl
			/// function (on HTTP and HTTPS requests only) and HttpOpenRequest function use this flag.
			/// </summary>
			INTERNET_FLAG_PRAGMA_NOCACHE = 0x00000100,

			/// <summary>
			/// Returns the data as a WIN32_FIND_DATA structure when retrieving FTP directory information. If this flag is not specified or
			/// if the call is made through a CERN proxy, InternetOpenUrl returns the HTML version of the directory. Only the InternetOpenUrl
			/// function uses this flag.
			/// <para>
			/// Windows XP and Windows Server 2003 R2 and earlier: Also returns a GOPHER_FIND_DATA structure when retrieving Gopher directory information.
			/// </para>
			/// </summary>
			INTERNET_FLAG_RAW_DATA = 0x40000000,

			/// <summary>This flag is currently disabled.</summary>
			INTERNET_FLAG_READ_PREFETCH = 0x00100000,

			/// <summary>
			/// Forces a download of the requested file, object, or directory listing from the origin server, not from the cache. The
			/// FtpFindFirstFile, FtpGetFile, FtpOpenFile, FtpPutFile, HttpOpenRequest, and InternetOpenUrl functions use this flag.
			/// <para>Windows XP and Windows Server 2003 R2 and earlier: Also used by GopherFindFirstFile and GopherOpenFile.</para>
			/// </summary>
			INTERNET_FLAG_RELOAD = 0x80000000,

			/// <summary>Indicates that the cookie being set is associated with an untrusted site.</summary>
			INTERNET_FLAG_RESTRICTED_ZONE = 0x00020000,

			/// <summary>
			/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are
			/// reloaded. This flag can be used by FtpFindFirstFile, FtpGetFile, FtpOpenFile, FtpPutFile, HttpOpenRequest, and InternetOpenUrl.
			/// <para>
			/// Windows XP and Windows Server 2003 R2 and earlier: Also used by GopherFindFirstFile and GopherOpenFile, and Gopher resources
			/// are reloaded.
			/// </para>
			/// </summary>
			INTERNET_FLAG_RESYNCHRONIZE = 0x00000800,

			/// <summary>
			/// Uses secure transaction semantics. This translates to using Secure Sockets Layer/Private Communications Technology (SSL/PCT)
			/// and is only meaningful in HTTP requests. This flag is used by HttpOpenRequest and InternetOpenUrl, but this is redundant if
			/// https:// appears in the URL.The InternetConnect function uses this flag for HTTP connections; all the request handles created
			/// under this connection will inherit this flag.
			/// </summary>
			INTERNET_FLAG_SECURE = 0x00800000,

			/// <summary>Transfers file as ASCII (FTP only). This flag can be used by FtpOpenFile, FtpGetFile, and FtpPutFile.</summary>
			INTERNET_FLAG_TRANSFER_ASCII = 0x00000001,

			/// <summary>Transfers file as binary (FTP only). This flag can be used by FtpOpenFile, FtpGetFile, and FtpPutFile.</summary>
			INTERNET_FLAG_TRANSFER_BINARY = 0x00000002,

			/// <summary>
			/// Indicates that no callbacks should be made for that API. This is used for the dxContext parameter of the functions that allow
			/// asynchronous operations.
			/// </summary>
			INTERNET_NO_CALLBACK = 0x00000000,

			/// <summary>
			/// Sets an HTTP request object such that it will not logon to origin servers, but will perform automatic logon to HTTP proxy
			/// servers. This option differs from the Request flag INTERNET_FLAG_NO_AUTH, which prevents authentication to both proxy servers
			/// and origin servers. Setting this mode will suppress the use of any credential material (either previously provided
			/// username/password or client SSL certificate) when communicating with an origin server. However, if the request must transit
			/// via an authenticating proxy, WinINet will still perform automatic authentication to the HTTP proxy per the Intranet Zone
			/// settings for the user. The default Intranet Zone setting is to permit automatic logon using the user’s default credentials.
			/// To ensure suppression of all identifying information, the caller should combine INTERNET_OPTION_SUPPRESS_SERVER_AUTH with the
			/// INTERNET_FLAG_NO_COOKIES request flag. This option may only be set on request objects before they have been sent. Attempts to
			/// set this option after the request has been sent will return ERROR_INTERNET_INCORRECT_HANDLE_STATE. No buffer is required for
			/// this option. This is used by InternetSetOption on handles returned by HttpOpenRequest only. Version: Requires Internet
			/// Explorer 8.0 or later.
			/// </summary>
			INTERNET_OPTION_SUPPRESS_SERVER_AUTH = 104,

			/// <summary>Forces asynchronous operations.</summary>
			WININET_API_FLAG_ASYNC = 0x00000001,

			/// <summary>Forces synchronous operations.</summary>
			WININET_API_FLAG_SYNC = 0x00000004,

			/// <summary>Forces the API to use the context value, even if it is set to zero.</summary>
			WININET_API_FLAG_USE_CONTEXT = 0x00000008
		}

		/// <summary>Values available for the <see cref="InternetOptionFlags.INTERNET_OPTION_ERROR_MASK"/> value.</summary>
		[Flags]
		public enum InternetErrorMask
		{
			/// <summary>The internet error mask insert cdrom</summary>
			INTERNET_ERROR_MASK_INSERT_CDROM = 0x1,

			/// <summary>The internet error mask combined sec cert</summary>
			INTERNET_ERROR_MASK_COMBINED_SEC_CERT = 0x2,

			/// <summary>The internet error mask need MSN sspi PKG</summary>
			INTERNET_ERROR_MASK_NEED_MSN_SSPI_PKG = 0X4,

			/// <summary>The internet error mask login failure display entity body</summary>
			INTERNET_ERROR_MASK_LOGIN_FAILURE_DISPLAY_ENTITY_BODY = 0x8,
		}

		/// <summary>
		/// Type of access required for the <see cref="InternetOpen(string, InternetOpenType, string, string, InternetApiFlags)"/> function.
		/// </summary>
		public enum InternetOpenType
		{
			/// <summary>Resolves all host names locally.</summary>
			INTERNET_OPEN_TYPE_DIRECT = 1,

			/// <summary>Retrieves the proxy or direct configuration from the registry.</summary>
			INTERNET_OPEN_TYPE_PRECONFIG = 0,

			/// <summary>
			/// Retrieves the proxy or direct configuration from the registry and prevents the use of a startup Microsoft JScript or Internet
			/// Setup (INS) file.
			/// </summary>
			INTERNET_OPEN_TYPE_PRECONFIG_WITH_NO_AUTOPROXY = 4,

			/// <summary>
			/// Passes requests to the proxy unless a proxy bypass list is supplied and the name to be resolved bypasses the proxy. In this
			/// case, the function uses INTERNET_OPEN_TYPE_DIRECT.
			/// </summary>
			INTERNET_OPEN_TYPE_PROXY = 3
		}

		[Flags]
		public enum InternetOptionErrorMask
		{
			/// <summary>Indicates that the client application can handle the ERROR_INTERNET_INSERT_CDROM error code.</summary>
			INTERNET_ERROR_MASK_INSERT_CDROM = 0x1,

			/// <summary>
			/// Indicates that all certificate errors are to be reported using the same error return, namely ERROR_INTERNET_SEC_CERT_ERRORS.
			/// If this flag is set, call InternetErrorDlg upon receiving the ERROR_INTERNET_SEC_CERT_ERRORS error, so that the user can
			/// respond to a familiar dialog describing the problem. Caution Failing to inform the user of this error exposes the user to
			/// potential spoofing attacks.
			/// </summary>
			INTERNET_ERROR_MASK_COMBINED_SEC_CERT = 0x2,

			/// <summary>
			/// Indicates that the client application can handle the ERROR_INTERNET_LOGIN_FAILURE_DISPLAY_ENTITY_BODY error code.
			/// </summary>
			INTERNET_ERROR_MASK_LOGIN_FAILURE_DISPLAY_ENTITY_BODY = 0x8,

			/// <summary>Not implemented.</summary>
			INTERNET_ERROR_MASK_NEED_MSN_SSPI_PKG = 0x4,
		}

		/// <summary>The following option flags are used with the InternetQueryOption and InternetSetOption functions.</summary>
		[Flags]
		public enum InternetOptionFlags : uint
		{
			/// <summary>Not implemented</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_ALTER_IDENTITY = 80,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_ASYNC = 30,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_ASYNC_ID = 15,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_ASYNC_PRIORITY = 16,

			/// <summary>
			/// Sets or retrieves the Boolean value that determines if the system should check the network for newer content and overwrite
			/// edited cache entries if a newer version is found. If set to True, the system checks the network for newer content and
			/// overwrites the edited cache entry with the newer version. The default is False, which indicates that the edited cache entry
			/// should be used without checking the network. This is used by InternetQueryOption and InternetSetOption. It is valid only in
			/// Microsoft Internet Explorer 5 and later.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			INTERNET_OPTION_BYPASS_EDITED_ENTRY = 64,

			/// <summary>No longer supported.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_CACHE_STREAM_HANDLE = 27,

			/// <summary>
			/// Retrieves an INTERNET_CACHE_TIMESTAMPS structure that contains the LastModified time and Expires time from the resource
			/// stored in the Internet cache. This value is used by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_CACHE_TIMESTAMPS), CorrespondingAction.Get)]
			INTERNET_OPTION_CACHE_TIMESTAMPS = 69,

			/// <summary>
			/// Sets or retrieves the address of the callback function defined for this handle. This option can be used on all HINTERNET
			/// handles. Used by InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_STATUS_CALLBACK))]
			INTERNET_OPTION_CALLBACK = 1,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_CALLBACK_FILTER = 54,

			/// <summary>
			/// This flag is not supported by InternetQueryOption. The lpBuffer parameter must be a pointer to a CERT_CONTEXT structure and
			/// not a pointer to a CERT_CONTEXT pointer. If an application receives ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED, it must call
			/// InternetErrorDlg or use InternetSetOption to supply a certificate before retrying the request.
			/// CertDuplicateCertificateContext is then called so that the certificate context passed can be independently released by the application.
			/// </summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
			INTERNET_OPTION_CLIENT_CERT_CONTEXT = 84,

			/// <summary>
			/// For a request where WinInet decompressed the server’s supplied Content-Encoding, retrieves the server-reported Content-Length
			/// of the response body as a ULONGLONG. Supported in Windows 10, version 1507 and later.
			/// </summary>
			[CorrespondingType(typeof(ulong), CorrespondingAction.Get)]
			INTERNET_OPTION_COMPRESSED_CONTENT_LENGTH = 147,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_CONNECT_BACKOFF = 4,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the number of times WinINet attempts to resolve and connect to
			/// a host. It only attempts once per IP address. For example, if you attempt to connect to a multihome host that has ten IP
			/// addresses and INTERNET_OPTION_CONNECT_RETRIES is set to seven, WinINet only attempts to resolve and connect to the first
			/// seven IP addresses. Conversely, given the same set of ten IP addresses, if INTERNET_OPTION_CONNECT_RETRIES is set to 20,
			/// WinINet attempts each of the ten only once. If a host has only one IP address and the first connection attempt fails, there
			/// are no further attempts. If a connection attempt still fails after the specified number of attempts, the request is canceled.
			/// The default value for INTERNET_OPTION_CONNECT_RETRIES is five attempts. This option can be used on any HINTERNET handle,
			/// including a NULL handle. It is used by InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_CONNECT_RETRIES = 3,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_CONNECT_TIME = 55,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the connected state. This is used by InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_CONNECTED_STATE = 50,

			/// <summary>
			/// Sets or retrieves a DWORD_PTR that contains the address of the context value associated with this HINTERNET handle. This
			/// option can be used on any HINTERNET handle. This is used by InternetQueryOption and InternetSetOption. Previously, this set
			/// the context value to the address stored in the lpBuffer pointer. This has been corrected so that the value stored in the
			/// buffer is used and the INTERNET_OPTION_CONTEXT_VALUE flag is assigned a new value. The old value, 10, has been preserved so
			/// that applications written for the old behavior are still supported.
			/// </summary>
			[CorrespondingType(typeof(IntPtr))]
			INTERNET_OPTION_CONTEXT_VALUE = 45,

			/// <summary>Identical to INTERNET_OPTION_RECEIVE_TIMEOUT. This is used by InternetQueryOption and InternetSetOption.</summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_CONTROL_RECEIVE_TIMEOUT = 6,

			/// <summary>Identical to INTERNET_OPTION_SEND_TIMEOUT. This is used by InternetQueryOption and InternetSetOption.</summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_CONTROL_SEND_TIMEOUT = 5,

			/// <summary>
			/// Retrieves a string value that contains the name of the file backing a downloaded entity. This flag is valid after
			/// InternetOpenUrl, FtpOpenFile, GopherOpenFile, or HttpOpenRequest has completed. This option can only be queried by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			INTERNET_OPTION_DATAFILE_NAME = 33,

			/// <summary>
			/// Sets a string value that contains the extension of the file backing a downloaded entity. This flag should be set before
			/// calling InternetOpenUrl, FtpOpenFile, GopherOpenFile, or HttpOpenRequest. This option can only be set by InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Set)]
			INTERNET_OPTION_DATAFILE_EXT = 96,

			/// <summary>
			/// Causes the system to log off the Digest authentication SSPI package, purging all of the credentials created for the process.
			/// No buffer is required for this option. It is used by InternetSetOption.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_DIGEST_AUTH_UNLOAD = 76,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_DISABLE_AUTODIAL = 70,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_DISCONNECTED_TIMEOUT = 49,

			/// <summary>
			/// On a request handle, sets a Boolean controlling whether redirects will be returned from the WinInet cache for a given
			/// request. The default is FALSE. Supported in Windows 8 and later.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrespondingAction.Set)]
			INTERNET_OPTION_ENABLE_REDIRECT_CACHE_READ = 122,

			/// <summary>
			/// Gets/sets a BOOL indicating whether non-ASCII characters in the query string should be percent-encoded. The default is FALSE.
			/// Supported in Windows 8.1 and later.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			INTERNET_OPTION_ENCODE_EXTRA = 155,

			/// <summary>
			/// Flushes entries not in use from the password cache on the hard disk drive. Also resets the cache time used when the
			/// synchronization mode is once-per-session. No buffer is required for this option. This is used by InternetSetOption.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_END_BROWSER_SESSION = 42,

			/// <summary>Sets an unsigned long integer value that contains the error masks that can be handled by the client application.</summary>
			[CorrespondingType(typeof(InternetErrorMask), CorrespondingAction.Set)]
			INTERNET_OPTION_ERROR_MASK = 62,

			/// <summary>
			/// Sets a PWSTR containing the Enterprise ID (see
			/// https://msdn.microsoft.com/en-us/library/windows/desktop/mt759320(v=vs.85).aspx) which applies to the request. Supported in
			/// Windows 10, version 1507 and later.
			/// </summary>
			[CorrespondingType(typeof(InternetErrorMask), CorrespondingAction.Set)]
			INTERNET_OPTION_ENTERPRISE_CONTEXT = 159,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains a Winsock error code mapped to the ERROR_INTERNET_ error messages last
			/// returned in this thread context. This option is used on a NULLHINTERNET handle by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			INTERNET_OPTION_EXTENDED_ERROR = 24,

			/// <summary>
			/// Sets or retrieves a1n unsigned long integer value that contains the amount of time the system should wait for a response to a
			/// network request before checking the cache for a copy of the resource. If a network request takes longer than the time
			/// specified and the requested resource is available in the cache, the resource is retrieved from the cache. This is used by
			/// InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_FROM_CACHE_TIMEOUT = 63,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Returns a InternetOptionHandleType value.
			/// </summary>
			[CorrespondingType(typeof(InternetOptionHandleType), CorrespondingAction.Get)]
			INTERNET_OPTION_HANDLE_TYPE = 9,

			/// <summary>
			/// Gets/sets a BOOL indicating whether WinInet should follow HTTP Strict Transport Security (HSTS) directives from servers. If
			/// enabled, http:// schemed requests to domains which have an HSTS policy cached by WinInet will be redirected to matching
			/// https:// URLs. The default is FALSE. Supported in Windows 8.1 and later.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			INTERNET_OPTION_HSTS = 157,

			/// <summary>
			/// Enables WinINet to perform decoding for the gzip and deflate encoding schemes. For more information, see Content Encoding.
			/// </summary>
			[CorrespondingType(typeof(bool), CorrespondingAction.Set)]
			INTERNET_OPTION_HTTP_DECODING = 65,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_IDENTITY = 78,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_IDLE_STATE = 51,

			/// <summary>
			/// Sets or retrieves whether the global offline flag should be ignored for the specified request handle. No buffer is required
			/// for this option. This is used by InternetQueryOption and InternetSetOption with a request handle. This option is only valid
			/// in Internet Explorer 5 and later.
			/// </summary>
			[CorrespondingType(null)]
			INTERNET_OPTION_IGNORE_OFFLINE = 77,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_KEEP_CONNECTION = 22,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_LISTEN_TIMEOUT = 11,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per HTTP/1.0 server.
			/// This is used by InternetQueryOption and InternetSetOption. This option is only valid in Internet Explorer 5 and later.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_MAX_CONNS_PER_1_0_SERVER = 74,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per server. This is
			/// used by InternetQueryOption and InternetSetOption. This option is only valid in Internet Explorer 5 and later.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_MAX_CONNS_PER_SERVER = 73,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_OFFLINE_MODE = 26,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_OFFLINE_SEMANTICS = 52,

			/// <summary>
			/// Opt-in for weak signatures (e.g. SHA-1) to be treated as insecure. This will instruct WinInet to call CertGetCertificateChain
			/// using the CERT_CHAIN_OPT_IN_WEAK_SIGNATURE parameter.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			INTERNET_OPTION_OPT_IN_WEAK_SIGNATURE = 176,

			/// <summary>Retrieves the parent handle to this handle. This option can be used on any HINTERNET handle by InternetQueryOption.</summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
			INTERNET_OPTION_PARENT_HANDLE = 21,

			/// <summary>
			/// Sets or retrieves a string value that contains the password associated with a handle returned by InternetConnect. This is
			/// used by InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(string))]
			INTERNET_OPTION_PASSWORD = 29,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_POLICY = 48,

			/// <summary>
			/// Sets or retrieves a string value that contains the password used to access the proxy. This is used by InternetQueryOption and
			/// InternetSetOption. This option can be set on the handle returned by InternetConnect or HttpOpenRequest.
			/// </summary>
			[CorrespondingType(typeof(string))]
			INTERNET_OPTION_PROXY_PASSWORD = 44,

			/// <summary>
			/// Alerts the current WinInet instance that proxy settings have changed and that they must update with the new settings. To
			/// alert all available WinInet instances, set the Buffer parameter of InternetSetOption to NULL and BufferLength to 0 when
			/// passing this option. This option can be set on the handle returned by InternetConnect or HttpOpenRequest.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_PROXY_SETTINGS_CHANGED = 95,

			/// <summary>
			/// Sets or retrieves a string value that contains the user name used to access the proxy. This is used by InternetQueryOption
			/// and InternetSetOption. This option can be set on the handle returned by InternetConnect or HttpOpenRequest.
			/// </summary>
			[CorrespondingType(typeof(string))]
			INTERNET_OPTION_PROXY_USERNAME = 43,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the size of the read buffer. This option can be used on
			/// HINTERNET handles returned by FtpOpenFile, FtpFindFirstFile, and InternetConnect (FTP session only). This option is used by
			/// InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_READ_BUFFER_SIZE = 12,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_RECEIVE_THROUGHPUT = 57,

			/// <summary>
			/// Causes the proxy data to be reread from the registry for a handle. No buffer is required. This option can be used on the
			/// HINTERNET handle returned by InternetOpen. It is used by InternetSetOption.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_REFRESH = 37,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_REMOVE_IDENTITY = 79,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the special status flags that indicate the status of the download in
			/// progress. This is used by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(InternetOptionRequestFlags), CorrespondingAction.Get)]
			INTERNET_OPTION_REQUEST_FLAGS = 23,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the priority of requests that compete for a connection on an
			/// HTTP handle. This is used by InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_REQUEST_PRIORITY = 58,

			/// <summary>
			/// Starts a new cache session for the process. No buffer is required. This is used by InternetSetOption. This option is reserved
			/// for internal use only.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_RESET_URLCACHE_SESSION = 60,

			/// <summary>
			/// Sets or retrieves a string value that contains the secondary cache key. This is used by InternetQueryOption and
			/// InternetSetOption. This option is reserved for internal use only.
			/// </summary>
			[CorrespondingType(typeof(string))]
			INTERNET_OPTION_SECONDARY_CACHE_KEY = 53,

			/// <summary>
			/// Retrieves the certificate for an SSL/PCT (Secure Sockets Layer/Private Communications Technology) server into a formatted
			/// string. This is used by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			INTERNET_OPTION_SECURITY_CERTIFICATE = 35,

			/// <summary>
			/// Retrieves the certificate for an SSL/PCT server into the INTERNET_CERTIFICATE_INFO structure. This is used by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_CERTIFICATE_INFO), CorrespondingAction.Get)]
			INTERNET_OPTION_SECURITY_CERTIFICATE_STRUCT = 32,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the security flags for a handle. This option is used by
			/// InternetQueryOption. It can be a combination of the following values.
			/// </summary>
			[CorrespondingType(typeof(InternetOptionSecurityFlags), CorrespondingAction.Get)]
			INTERNET_OPTION_SECURITY_FLAGS = 31,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the bit size of the encryption key. The larger the number, the greater
			/// the encryption strength used. This is used by InternetQueryOption. Be aware that the data retrieved this way relates to a
			/// transaction that has already occurred, whose security level can no longer be changed.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			INTERNET_OPTION_SECURITY_KEY_BITNESS = 36,

			/// <summary>Not implemented.</summary>
			[CorrespondingType(CorrespondingAction.Exception)]
			INTERNET_OPTION_SEND_THROUGHPUT = 56,

			/// <summary>
			/// Notifies the system that the registry settings have been changed so that it verifies the settings on the next call to
			/// InternetConnect. This is used by InternetSetOption.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_SETTINGS_CHANGED = 39,

			/// <summary>
			/// A general purpose option that is used to suppress behaviors on a process-wide basis. The lpBuffer parameter of the function
			/// must be a pointer to a DWORD containing the specific behavior to suppress. This option cannot be queried with
			/// InternetQueryOption. The permitted values are:
			/// </summary>
			[CorrespondingType(typeof(InternetOptionSupressBehavior), CorrespondingAction.Set)]
			INTERNET_OPTION_SUPPRESS_BEHAVIOR = 81,

			/// <summary>
			/// Retrieves a string value that contains the full URL of a downloaded resource. If the original URL contained any extra data,
			/// such as search strings or anchors, or if the call was redirected, the URL returned differs from the original. This option is
			/// valid on HINTERNET handles returned by InternetOpenUrl, FtpOpenFile, GopherOpenFile, or HttpOpenRequest. It is used by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			INTERNET_OPTION_URL = 34,

			/// <summary>
			/// Sets or retrieves the user agent string on handles supplied by InternetOpen and used in subsequent HttpSendRequest functions,
			/// as long as it is not overridden by a header added by HttpAddRequestHeaders or HttpSendRequest. This is used by
			/// InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(string))]
			INTERNET_OPTION_USER_AGENT = 41,

			/// <summary>
			/// Sets or retrieves a string that contains the user name associated with a handle returned by InternetConnect. This is used by
			/// InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(string))]
			INTERNET_OPTION_USERNAME = 28,

			/// <summary>
			/// Retrieves an INTERNET_VERSION_INFO structure that contains the version number of Wininet.dll. This option can be used on a
			/// NULLHINTERNET handle by InternetQueryOption.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_VERSION_INFO), CorrespondingAction.Get)]
			INTERNET_OPTION_VERSION = 40,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the size, in bytes, of the write buffer. This option can be
			/// used on HINTERNET handles returned by FtpOpenFile and InternetConnect (FTP session only). It is used by InternetQueryOption
			/// and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_WRITE_BUFFER_SIZE = 13,

			/// <summary>
			/// By default, the host or authority portion of the Unicode URL is encoded according to the IDN specification. Setting this
			/// option on the request, or connection handle, when IDN is disabled, specifies a code page encoding scheme for the host portion
			/// of the URL. The lpBuffer parameter in the call to InternetSetOption contains the desired DBCS code page. If no code page is
			/// specified in lpBuffer, WinINet uses the default system code page (CP_ACP). Note: This option is ignored if IDN is not
			/// disabled. For more information about how to disable IDN, see the INTERNET_OPTION_IDN option.
			/// <para><c>Windows XP with SP2 and Windows Server 2003 with SP1:</c> This flag is not supported.</para>
			/// <para><c>Version:</c> Requires Internet Explorer 7.0.</para>
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			INTERNET_OPTION_CODEPAGE = 68,

			/// <summary>
			/// By default, the path portion of the URL is UTF8 encoded. The WinINet API performs escape character (%) encoding on the
			/// high-bit characters. Setting this option on the request, or connection handle, disables the UTF8 encoding and sets a specific
			/// code page. The lpBuffer parameter in the call to InternetSetOption contains the desired DBCS codepage for the path. If no
			/// code page is specified in lpBuffer, WinINet uses the default CP_UTF8.
			/// <para><c>Windows XP with SP2 and Windows Server 2003 with SP1:</c> This flag is not supported.</para>
			/// <para><c>Version:</c> Requires Internet Explorer 7.0.</para>
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			INTERNET_OPTION_CODEPAGE_PATH = 100,

			/// <summary>
			/// By default, the path portion of the URL is the default system code page (CP_ACP). The escape character (%) conversions are
			/// not performed on the extra portion. Setting this option on the request, or connection handle disables the CP_ACP encoding.
			/// The lpBuffer parameter in the call to InternetSetOption contains the desired DBCS codepage for the extra portion of the URL.
			/// If no code page is specified in lpBuffer, WinINet uses the default system code page (CP_ACP).
			/// <para><c>Windows XP with SP2 and Windows Server 2003 with SP1:</c> This flag is not supported.</para>
			/// <para><c>Version:</c> Requires Internet Explorer 7.0.</para>
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			INTERNET_OPTION_CODEPAGE_EXTRA = 101,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds, to use for Internet
			/// connection requests. Setting this option to infinite (0xFFFFFFFF) will disable this timer. If a connection request takes
			/// longer than this time-out value, the request is canceled. When attempting to connect to multiple IP addresses for a single
			/// host (a multihome host), the timeout limit is cumulative for all of the IP addresses. This option can be used on any
			/// HINTERNET handle, including a NULL handle. It is used by InternetQueryOption and InternetSetOption.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_CONNECT_TIMEOUT = 2,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds, to receive a response to
			/// a request for the data channel of an FTP transaction. If the response takes longer than this time-out value, the request is
			/// canceled. This option can be used on any HINTERNET handle, including a NULL handle. It is used by InternetQueryOption and
			/// InternetSetOption. This flag has no impact on HTTP functionality.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_DATA_RECEIVE_TIMEOUT = 8,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value, in milliseconds, that contains the time-out value to send a request for the
			/// data channel of an FTP transaction. If the send takes longer than this time-out value, the send is canceled. This option can
			/// be used on any HINTERNET handle, including a NULL handle. It is used by InternetQueryOption and InternetSetOption. This flag
			/// has no impact on HTTP functionality.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_DATA_SEND_TIMEOUT = 7,

			/// <summary>
			/// Retrieves an INTERNET_DIAGNOSTIC_SOCKET_INFO structure that contains data about a specified HTTP Request. This flag is used
			/// by InternetQueryOption. <c>Windows 7:</c> This option is no longer supported.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_DIAGNOSTIC_SOCKET_INFO), CorrespondingAction.Get)]
			INTERNET_OPTION_DIAGNOSTIC_SOCKET_INFO = 67,

			/// <summary>
			/// Sets a DWORD bitmask of acceptable advanced HTTP versions. May be set on any handle type. Possible values are:
			/// HTTP_PROTOCOL_FLAG_HTTP2 (0x2). Supported on Windows 10, version 1507 and later. Legacy versions of HTTP (1.1 and prior)
			/// cannot be disabled using this option. The default is 0x0. Supported in Windows 10, version 1507 and later.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			INTERNET_OPTION_ENABLE_HTTP_PROTOCOL = 148,

			/// <summary>
			/// Gets a DWORD indicating which advanced HTTP version was used on a given request. Possible values are:
			/// HTTP_PROTOCOL_FLAG_HTTP2 (0x2). Supported on Windows 10, version 1507 and later. 0x0 indicates HTTP/1.1 or earlier; see
			/// INTERNET_OPTION_HTTP_VERSION if more precision is needed about which legacy version was used. Supported on Windows 10,
			/// version 1507 and later.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			INTERNET_OPTION_HTTP_PROTOCOL_USED = 149,

			/// <summary>
			/// Sets or retrieves an HTTP_VERSION_INFO structure that contains the supported HTTP version. This must be used on a NULL
			/// handle. This is used by InternetQueryOption and InternetSetOption. On Windows 7, Windows Server 2008 R2, and later, the value
			/// of the dwMinorVersion member in the HTTP_VERSION_INFO structure is overridden by Internet Explorer settings. EnableHttp1_1 is
			/// a registry value under HKLM\Software\Microsoft\InternetExplorer\AdvacnedOptions\HTTP\GENABLE controlled by Internet Options
			/// set in Internet Explorer for the system. The EnableHttp1_1 value defaults to 1. The HTTP_VERSION_INFO structure is ignored
			/// for any HTTP version less than 1.1 if EnableHttp1_1 is set to 1.
			/// </summary>
			[CorrespondingType(typeof(HTTP_VERSION_INFO))]
			INTERNET_OPTION_HTTP_VERSION = 59,

			/// <summary>
			/// By default, the host or authority portion of the URL is encoded according to the IDN specification for both direct and proxy
			/// connections. This option can be used on the request, or connection handle to enable or disable IDN. When IDN is disabled,
			/// WinINet uses the system codepage to encode the host or authority portion of the URL. To disable IDN host conversion, set the
			/// lpBuffer parameter in the call to InternetSetOption to zero. To enable IDN conversion on only the direct connection, specify
			/// INTERNET_FLAG_IDN_DIRECT in the lpBuffer parameter in the call to InternetSetOption. To enable IDN conversion on only the
			/// proxy connection, specify INTERNET_FLAG_IDN_PROXY in the lpBuffer parameter in the call to InternetSetOption. Windows XP with
			/// SP2 and Windows Server 2003 with SP1: This flag is not supported.
			/// Version:  Requires Internet Explorer 7.0.
			/// </summary>
			[CorrespondingType(typeof(InternetOptionIDNFlags), CorrespondingAction.Set)]
			INTERNET_OPTION_IDN = 102,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per CERN proxy. When
			/// this option is set or retrieved, the hInternet parameter must set to a null handle value. A null handle value indicates that
			/// the option should be set or queried for the current process. When calling InternetSetOption with this option, all existing
			/// proxy objects will receive the new value. This value is limited to a range of 2 to 128, inclusive. <c>Version:</c> Requires
			/// Internet Explorer 8.0.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_MAX_CONNS_PER_PROXY = 103,

			/// <summary>
			/// Sets or retrieves an INTERNET_PER_CONN_OPTION_LIST structure that specifies a list of options for a particular connection.
			/// This is used by InternetQueryOption and InternetSetOption. This option is only valid in Internet Explorer 5 and later. Note
			/// INTERNET_OPTION_PER_CONNECTION_OPTION causes the settings to be changed on a system-wide basis when a NULL handle is used in
			/// the call to InternetSetOption. To refresh the global proxy settings, you must call InternetSetOption with the
			/// INTERNET_OPTION_REFRESH option flag. Note To change proxy information for the entire process without affecting the global
			/// settings in Internet Explorer 5 and later, use this option on the handle that is returned from InternetOpen. The following
			/// code example changes the proxy for the whole process even though the HINTERNET handle is closed and is not used by any
			/// requests. For more information and code examples, see KB article 226473.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_PER_CONN_OPTION_LIST))]
			INTERNET_OPTION_PER_CONNECTION_OPTION = 75,

			/// <summary>
			/// Sets or retrieves an INTERNET_PROXY_INFO structure that contains the proxy data for an existing InternetOpen handle when the
			/// HINTERNET handle is not NULL. If the HINTERNET handle is NULL, the function sets or queries the global proxy data. This
			/// option can be used on the handle returned by InternetOpen. It is used by InternetQueryOption and InternetSetOption. Note It
			/// is recommended that INTERNET_OPTION_PER_CONNECTION_OPTION be used instead of INTERNET_OPTION_PROXY. For more information, see
			/// KB article 226473.
			/// </summary>
			[CorrespondingType(typeof(INTERNET_PROXY_INFO))]
			INTERNET_OPTION_PROXY = 38,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds, to receive a response to
			/// a request. If the response takes longer than this time-out value, the request is canceled. This option can be used on any
			/// HINTERNET handle, including a NULL handle. It is used by InternetQueryOption and InternetSetOption. This option is not
			/// intended to represent a fine-grained, immediate timeout. You can expect the timeout to occur up to six seconds after the set
			/// timeout value. When used in reference to an FTP transaction, this option refers to the control channel.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_RECEIVE_TIMEOUT = 6,

			/// <summary>
			/// The bit size used in the encryption is unknown. This is only returned in a call to InternetQueryOption. Be aware that the
			/// data retrieved this way relates to a transaction that has occurred, whose security level can no longer be changed.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SECURITY_FLAG_UNKNOWNBIT = 0x80000000,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value, in milliseconds, that contains the time-out value to send a request. If the
			/// send takes longer than this time-out value, the send is canceled. This option can be used on any HINTERNET handle, including
			/// a NULL handle. It is used by InternetQueryOption and InternetSetOption. When used in reference to an FTP transaction, this
			/// option refers to the control channel.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			INTERNET_OPTION_SEND_TIMEOUT = 5,

			/// <summary>
			/// Retrieves the server’s certificate-chain context as a duplicated PCCERT_CHAIN_CONTEXT. You may pass this duplicated context
			/// to any Crypto API function which takes a PCCERT_CHAIN_CONTEXT. You must call CertFreeCertificateChain on the returned
			/// PCCERT_CHAIN_CONTEXT when you are done with the certificate-chain context. <c>Version:</c> Requires Internet Explorer 8.0.
			/// </summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
			INTERNET_OPTION_SERVER_CERT_CHAIN_CONTEXT = 105,

			/// <summary>
			/// Sets an HTTP request object such that it will not logon to origin servers, but will perform automatic logon to HTTP proxy
			/// servers. This option differs from the Request flag INTERNET_FLAG_NO_AUTH, which prevents authentication to both proxy servers
			/// and origin servers. Setting this mode will suppress the use of any credential material (either previously provided
			/// username/password or client SSL certificate) when communicating with an origin server. However, if the request must transit
			/// via an authenticating proxy, WinINet will still perform automatic authentication to the HTTP proxy per the Intranet Zone
			/// settings for the user. The default Intranet Zone setting is to permit automatic logon using the user’s default credentials.
			/// To ensure suppression of all identifying information, the caller should combine INTERNET_OPTION_SUPPRESS_SERVER_AUTH with the
			/// INTERNET_FLAG_NO_COOKIES request flag. This option may only be set on request objects before they have been sent. Attempts to
			/// set this option after the request has been sent will return ERROR_INTERNET_INCORRECT_HANDLE_STATE. No buffer is required for
			/// this option. This is used by InternetSetOption on handles returned by HttpOpenRequest only.
			/// Version:  Requires Internet Explorer 8.0 or later.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			INTERNET_OPTION_SUPPRESS_SERVER_AUTH = 104,
		}

		public enum InternetOptionHandleType
		{
			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_CONNECT_FTP = 2,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_CONNECT_GOPHER = 3,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_CONNECT_HTTP = 4,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_FILE_REQUEST = 14,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_FTP_FILE = 7,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_FTP_FILE_HTML = 8,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_FTP_FIND = 5,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_FTP_FIND_HTML = 6,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_GOPHER_FILE = 11,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_GOPHER_FILE_HTML = 12,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_GOPHER_FIND = 9,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_GOPHER_FIND_HTML = 10,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_HTTP_REQUEST = 13,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the type of the HINTERNET handles passed in. This is used by
			/// InternetQueryOption on any HINTERNET handle. Possible return values include the following.
			/// </summary>
			INTERNET_HANDLE_TYPE_INTERNET = 1,
		}

		[Flags]
		public enum InternetOptionIDNFlags
		{
			/// <summary>IDN enabled for direct connections</summary>
			INTERNET_FLAG_IDN_DIRECT = 0x00000001,

			/// <summary>IDN enabled for proxy</summary>
			INTERNET_FLAG_IDN_PROXY = 0x00000002
		}

		[Flags]
		public enum InternetOptionRequestFlags
		{
			/// <summary>Not implemented.</summary>
			INTERNET_REQFLAG_ASYNC = 0x00000002,

			/// <summary>Internet request cannot be cached (an HTTPS request, for example).</summary>
			INTERNET_REQFLAG_CACHE_WRITE_DISABLED = 0x00000040,

			/// <summary>Response came from the cache.</summary>
			INTERNET_REQFLAG_FROM_CACHE = 0x00000001,

			/// <summary>Internet request timed out.</summary>
			INTERNET_REQFLAG_NET_TIMEOUT = 0x00000080,

			/// <summary>Original response contained no headers.</summary>
			INTERNET_REQFLAG_NO_HEADERS = 0x00000008,

			/// <summary>Not implemented.</summary>
			INTERNET_REQFLAG_PASSIVE = 0x00000010,

			/// <summary>Request was made through a proxy.</summary>
			INTERNET_REQFLAG_VIA_PROXY = 0x00000004,
		}

		[Flags]
		public enum InternetOptionSecurityFlags
		{
			/// <summary>Identical to the preferred value SECURITY_FLAG_STRENGTH_STRONG. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_128BIT = 0x20000000,

			/// <summary>Identical to the preferred value SECURITY_FLAG_STRENGTH_WEAK. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_40BIT = 0x10000000,

			/// <summary>Identical to the preferred value SECURITY_FLAG_STRENGTH_MEDIUM. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_56BIT = 0x40000000,

			/// <summary>Indicates Fortezza has been used to provide secrecy, authentication, and/or integrity for the specified connection.</summary>
			SECURITY_FLAG_FORTEZZA = 0x08000000,

			/// <summary>Not implemented.</summary>
			SECURITY_FLAG_IETFSSL4 = 0x00000020,

			/// <summary>Ignores the ERROR_INTERNET_SEC_CERT_CN_INVALID error message.</summary>
			SECURITY_FLAG_IGNORE_CERT_CN_INVALID = 0x00001000,

			/// <summary>Ignores the ERROR_INTERNET_SEC_CERT_DATE_INVALID error message.</summary>
			SECURITY_FLAG_IGNORE_CERT_DATE_INVALID = 0x00002000,

			/// <summary>Ignores the ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR error message.</summary>
			SECURITY_FLAG_IGNORE_REDIRECT_TO_HTTP = 0x00008000,

			/// <summary>Ignores the ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR error message.</summary>
			SECURITY_FLAG_IGNORE_REDIRECT_TO_HTTPS = 0x00004000,

			/// <summary>Ignores certificate revocation problems.</summary>
			SECURITY_FLAG_IGNORE_REVOCATION = 0x00000080,

			/// <summary>Ignores unknown certificate authority problems.</summary>
			SECURITY_FLAG_IGNORE_UNKNOWN_CA = 0x00000100,

			/// <summary>Ignores weak certificate signature problems.</summary>
			SECURITY_FLAG_IGNORE_WEAK_SIGNATURE = 0x00010000,

			/// <summary>Ignores incorrect usage problems.</summary>
			SECURITY_FLAG_IGNORE_WRONG_USAGE = 0x00000200,

			/// <summary>Identical to the value SECURITY_FLAG_STRENGTH_WEAK. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_NORMALBITNESS = 0x10000000,

			/// <summary>Not implemented.</summary>
			SECURITY_FLAG_PCT = 0x00000008,

			/// <summary>Not implemented.</summary>
			SECURITY_FLAG_PCT4 = 0x00000010,

			/// <summary>Uses secure transfers. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_SECURE = 0x00000001,

			/// <summary>Not implemented.</summary>
			SECURITY_FLAG_SSL = 0x00000002,

			/// <summary>Not implemented.</summary>
			SECURITY_FLAG_SSL3 = 0x00000004,

			/// <summary>Uses medium (56-bit) encryption. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_STRENGTH_MEDIUM = 0x40000000,

			/// <summary>Uses strong (128-bit) encryption. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_STRENGTH_STRONG = 0x20000000,

			/// <summary>Uses weak (40-bit) encryption. This is only returned in a call to InternetQueryOption.</summary>
			SECURITY_FLAG_STRENGTH_WEAK = 0x10000000,
		}

		public enum InternetOptionSupressBehavior
		{
			/// <summary>
			/// Disables all suppressions, re-enabling default and configured behavior. This option is the equivalent of setting
			/// INTERNET_SUPPRESS_COOKIE_POLICY_RESET and INTERNET_SUPPRESS_COOKIE_PERSIST_RESET individually. <c>Version:</c> Requires
			/// Internet Explorer 6.0 or later.
			/// </summary>
			INTERNET_SUPPRESS_RESET_ALL = 0,

			/// <summary>
			/// Ignores any configured cookie policies and allows cookies to be set. <c>Version:</c> Requires Internet Explorer 6.0 or later.
			/// </summary>
			INTERNET_SUPPRESS_COOKIE_POLICY = 1,

			/// <summary>
			/// Disables the INTERNET_SUPPRESS_COOKIE_POLICY suppression, permitting the evaluation of cookies according to the configured
			/// cookie policy. <c>Version:</c> Requires Internet Explorer 6.0 or later.
			/// </summary>
			INTERNET_SUPPRESS_COOKIE_POLICY_RESET = 2,

			/// <summary>
			/// Suppresses the persistence of cookies, even if the server has specified them as persistent. <c>Version:</c> Requires Internet
			/// Explorer 8.0 or later.
			/// </summary>
			INTERNET_SUPPRESS_COOKIE_PERSIST = 3,

			/// <summary>
			/// Disables the INTERNET_SUPPRESS_COOKIE_PERSIST suppression, re-enabling the persistence of cookies. Any previously suppressed
			/// cookies will not become persistent. <c>Version:</c> Requires Internet Explorer 8.0 or later.
			/// </summary>
			INTERNET_SUPPRESS_COOKIE_PERSIST_RESET = 4
		}

		/// <summary>Type of service to access in <see cref="InternetConnect"/>.</summary>
		public enum InternetService
		{
			/// <summary>FTP service.</summary>
			INTERNET_SERVICE_FTP = 1,

			/// <summary>Gopher service. <note type="note">Windows XP and Windows Server 2003 R2 and earlier only.</note></summary>
			INTERNET_SERVICE_GOPHER = 2,

			/// <summary>HTTP service.</summary>
			INTERNET_SERVICE_HTTP = 3
		}

		/// <summary>Values passed using the <see cref="INTERNET_STATUS_CALLBACK"/> delegate.</summary>
		[Flags]
		public enum InternetState
		{
			/// <summary>Connected state. Mutually exclusive with disconnected state.</summary>
			INTERNET_STATE_CONNECTED = 1,

			/// <summary>Disconnected state. No network connection could be established.</summary>
			INTERNET_STATE_DISCONNECTED = 2,

			/// <summary>Disconnected by user request.</summary>
			INTERNET_STATE_DISCONNECTED_BY_USER = 0x10,

			/// <summary>No network requests are being made by Windows Internet.</summary>
			INTERNET_STATE_IDLE = 0x100,

			/// <summary>Network requests are being made by Windows Internet.</summary>
			INTERNET_STATE_BUSY = 0x200,
		}

		/// <summary>Values passed using the <see cref="INTERNET_STATUS_CALLBACK"/> delegate.</summary>
		public enum InternetStatus
		{
			/// <summary>Closing the connection to the server. The lpvStatusInformation parameter is NULL.</summary>
			INTERNET_STATUS_CLOSING_CONNECTION = 50,

			/// <summary>Successfully connected to the socket address (SOCKADDR) pointed to by lpvStatusInformation.</summary>
			INTERNET_STATUS_CONNECTED_TO_SERVER = 21,

			/// <summary>Connecting to the socket address (SOCKADDR) pointed to by lpvStatusInformation.</summary>
			INTERNET_STATUS_CONNECTING_TO_SERVER = 20,

			/// <summary>Successfully closed the connection to the server. The lpvStatusInformation parameter is NULL.</summary>
			INTERNET_STATUS_CONNECTION_CLOSED = 51,

			/// <summary>
			/// Retrieving content from the cache. Contains data about past cookie events for the URL such as if cookies were accepted,
			/// rejected, downgraded, or leashed. The lpvStatusInformation parameter is a pointer to an InternetCookieHistory structure.
			/// </summary>
			INTERNET_STATUS_COOKIE_HISTORY = 327,

			/// <summary>
			/// Indicates the number of cookies that were accepted, rejected, downgraded (changed from persistent to session cookies), or
			/// leashed (will be sent out only in 1st party context). The lpvStatusInformation parameter is a DWORD with the number of
			/// cookies received.
			/// </summary>
			INTERNET_STATUS_COOKIE_RECEIVED = 321,

			/// <summary>
			/// Indicates the number of cookies that were either sent or suppressed, when a request is sent. The lpvStatusInformation
			/// parameter is a DWORD with the number of cookies sent or suppressed.
			/// </summary>
			INTERNET_STATUS_COOKIE_SENT = 320,

			/// <summary>Not implemented.</summary>
			INTERNET_STATUS_CTL_RESPONSE_RECEIVED = 42,

			/// <summary>Notifies the client application that a proxy has been detected.</summary>
			INTERNET_STATUS_DETECTING_PROXY = 80,

			/// <summary>
			/// This handle value has been terminated. pvStatusInformation contains the address of the handle being closed. The
			/// lpvStatusInformation parameter contains the address of the handle being closed.
			/// </summary>
			INTERNET_STATUS_HANDLE_CLOSING = 70,

			/// <summary>
			/// Used by InternetConnect to indicate it has created the new handle. This lets the application call InternetCloseHandle from
			/// another thread, if the connect is taking too long. The lpvStatusInformation parameter contains the address of an HINTERNET handle.
			/// </summary>
			INTERNET_STATUS_HANDLE_CREATED = 60,

			/// <summary>Received an intermediate (100 level) status code message from the server.</summary>
			INTERNET_STATUS_INTERMEDIATE_RESPONSE = 120,

			/// <summary>
			/// Successfully found the IP address of the name contained in lpvStatusInformation. The lpvStatusInformation parameter points to
			/// a PCTSTR containing the host name.
			/// </summary>
			INTERNET_STATUS_NAME_RESOLVED = 11,

			/// <summary>The response has a P3P header in it.</summary>
			INTERNET_STATUS_P3P_HEADER = 325,

			/// <summary>Not implemented.</summary>
			INTERNET_STATUS_P3P_POLICYREF = 326,

			/// <summary>Not implemented.</summary>
			INTERNET_STATUS_PREFETCH = 43,

			/// <summary>Not implemented.</summary>
			INTERNET_STATUS_PRIVACY_IMPACTED = 324,

			/// <summary>Waiting for the server to respond to a request. The lpvStatusInformation parameter is NULL.</summary>
			INTERNET_STATUS_RECEIVING_RESPONSE = 40,

			/// <summary>
			/// An HTTP request is about to automatically redirect the request. The lpvStatusInformation parameter points to the new URL. At
			/// this point, the application can read any data returned by the server with the redirect response and can query the response
			/// headers. It can also cancel the operation by closing the handle. This callback is not made if the original request specified INTERNET_FLAG_NO_AUTO_REDIRECT.
			/// </summary>
			INTERNET_STATUS_REDIRECT = 110,

			/// <summary>
			/// An asynchronous operation has been completed. The lpvStatusInformation parameter contains the address of an
			/// INTERNET_ASYNC_RESULT structure.
			/// </summary>
			INTERNET_STATUS_REQUEST_COMPLETE = 100,

			/// <summary>
			/// Successfully sent the information request to the server. The lpvStatusInformation parameter points to a DWORD value that
			/// contains the number of bytes sent.
			/// </summary>
			INTERNET_STATUS_REQUEST_SENT = 31,

			/// <summary>
			/// Looking up the IP address of the name contained in lpvStatusInformation. The lpvStatusInformation parameter points to a
			/// PCTSTR containing the host name.
			/// </summary>
			INTERNET_STATUS_RESOLVING_NAME = 10,

			/// <summary>Successfully received a response from the server.</summary>
			INTERNET_STATUS_RESPONSE_RECEIVED = 41,

			/// <summary>Sending the information request to the server. The lpvStatusInformation parameter is NULL.</summary>
			INTERNET_STATUS_SENDING_REQUEST = 30,

			/// <summary>
			/// Moved between a secure (HTTPS) and a nonsecure (HTTP) site. The user must be informed of this change; otherwise, the user is
			/// at risk of disclosing sensitive information involuntarily. When this flag is set, the lpvStatusInformation parameter points
			/// to a status DWORD that contains additional flags.
			/// </summary>
			INTERNET_STATUS_STATE_CHANGE = 200,

			/// <summary>The request requires user input to be completed.</summary>
			INTERNET_STATUS_USER_INPUT_REQUIRED = 140,
		}

		/// <summary>Closes a single Internet handle.</summary>
		/// <param name="hInternet">Handle to be closed.</param>
		/// <returns>Returns TRUE if the handle is successfully closed, or FALSE otherwise. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.WinInet, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InternetCloseHandle(IntPtr hInternet);

		/// <summary>Opens an File Transfer Protocol (FTP) or HTTP session for a given site.</summary>
		/// <param name="hInternet">Handle returned by a previous call to InternetOpen.</param>
		/// <param name="lpszServerName">
		/// A string that specifies the host name of an Internet server. Alternately, the string can contain the IP number of the site, in
		/// ASCII dotted-decimal format (for example, 11.0.1.45).
		/// </param>
		/// <param name="nServerPort">
		/// Transmission Control Protocol/Internet Protocol (TCP/IP) port on the server. These flags set only the port that is used. The
		/// service is set by the value of dwService.
		/// </param>
		/// <param name="lpszUsername">
		/// A string that specifies the name of the user to log on. If this parameter is NULL, the function uses an appropriate default. For
		/// the FTP protocol, the default is "anonymous".
		/// </param>
		/// <param name="lpszPassword">
		/// A string that contains the password to use to log on. If both lpszPassword and lpszUsername are NULL, the function uses the
		/// default "anonymous" password. In the case of FTP, the default password is the user's email name. If lpszPassword is NULL, but
		/// lpszUsername is not NULL, the function uses a blank password.
		/// </param>
		/// <param name="dwService">Type of service to access.</param>
		/// <param name="dwFlags">
		/// Options specific to the service used. If dwService is INTERNET_SERVICE_FTP, INTERNET_FLAG_PASSIVE causes the application to use
		/// passive FTP semantics.
		/// </param>
		/// <param name="dwContext">
		/// Pointer to a variable that contains an application-defined value that is used to identify the application context for the
		/// returned handle in callbacks.
		/// </param>
		/// <returns>
		/// Returns a valid handle to the session if the connection is successful, or NULL otherwise. To retrieve extended error information,
		/// call GetLastError. An application can also use InternetGetLastResponseInfo to determine why access to the service was denied.
		/// </returns>
		[DllImport(Lib.WinInet, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern SafeInternetConnectHandle InternetConnect(SafeInternetHandle hInternet, string lpszServerName, ushort nServerPort, string lpszUsername, string lpszPassword, InternetService dwService, InternetApiFlags dwFlags, IntPtr dwContext);

		/// <summary>Initializes an application's use of the WinINet functions</summary>
		/// <param name="lpszAgent">
		/// A string that specifies the name of the application or entity calling the WinINet functions. This name is used as the user agent
		/// in the HTTP protocol.
		/// </param>
		/// <param name="dwAccessType">Type of access required.</param>
		/// <param name="lpszProxyName">
		/// A string that specifies the name of the proxy server(s) to use when proxy access is specified by setting dwAccessType to
		/// INTERNET_OPEN_TYPE_PROXY. Do not use an empty string, because InternetOpen will use it as the proxy name. The WinINet functions
		/// recognize only CERN type proxies (HTTP only) and the TIS FTP gateway (FTP only). If Microsoft Internet Explorer is installed,
		/// these functions also support SOCKS proxies. FTP requests can be made through a CERN type proxy either by changing them to an HTTP
		/// request or by using InternetOpenUrl. If dwAccessType is not set to INTERNET_OPEN_TYPE_PROXY, this parameter is ignored and should
		/// be NULL. For more information about listing proxy servers, see the Listing Proxy Servers section of Enabling Internet Functionality.
		/// </param>
		/// <param name="lpszProxyBypass">
		/// A string that specifies an optional list of host names or IP addresses, or both, that should not be routed through the proxy when
		/// dwAccessType is set to INTERNET_OPEN_TYPE_PROXY. The list can contain wildcards. Do not use an empty string, because InternetOpen
		/// will use it as the proxy bypass list. If this parameter specifies the "&lt;local&gt;" macro, the function bypasses the proxy for
		/// any host name that does not contain a period.
		/// <para>
		/// By default, WinINet will bypass the proxy for requests that use the host names "localhost", "loopback", "127.0.0.1", or "[::1]".
		/// This behavior exists because a remote proxy server typically will not resolve these addresses properly.
		/// </para>
		/// <para>Internet Explorer 9: You can remove the local computer from the proxy bypass list using the "&lt;-loopback&gt;" macro.</para>
		/// <para>If dwAccessType is not set to INTERNET_OPEN_TYPE_PROXY, this parameter is ignored and should be NULL.</para>
		/// </param>
		/// <param name="dwFlags">Options.</param>
		/// <returns>
		/// Returns a valid handle that the application passes to subsequent WinINet functions. If InternetOpen fails, it returns NULL. To
		/// retrieve a specific error message, call GetLastError.
		/// </returns>
		[DllImport(Lib.WinInet, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern SafeInternetHandle InternetOpen(string lpszAgent, InternetOpenType dwAccessType, string lpszProxyName, string lpszProxyBypass, InternetApiFlags dwFlags);

		/// <summary>Queries an Internet option on the specified handle.</summary>
		/// <param name="hInternet">Handle on which to query information.</param>
		/// <param name="dwOption">Internet option to be queried. This can be one of the Option Flags values.</param>
		/// <param name="optionsList">
		/// Pointer to a buffer that receives the option setting. Strings returned by InternetQueryOption are globally allocated, so the
		/// calling application must free them when it is finished using them.
		/// </param>
		/// <param name="bufferLength">
		/// Pointer to a variable that contains the size of lpBuffer, in bytes. When InternetQueryOption returns, lpdwBufferLength specifies
		/// the size of the data placed into lpBuffer. If GetLastError returns ERROR_INSUFFICIENT_BUFFER, this parameter points to the number
		/// of bytes required to hold the requested information.
		/// </param>
		/// <returns>Returns TRUE if successful, or FALSE otherwise. To get a specific error message, call GetLastError.</returns>
		[DllImport(Lib.WinInet, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InternetQueryOption(SafeInternetHandle hInternet, InternetOptionFlags dwOption, IntPtr optionsList, ref int bufferLength);

		/// <summary>Queries an Internet option on the specified handle.</summary>
		/// <param name="hInternet">Handle on which to query information.</param>
		/// <param name="option">Internet option to be queried. This can be one of the Option Flags values.</param>
		/// <returns>
		/// A <see cref="SafeCoTaskMemHandle"/> instance with sufficient memory needed to hold the response. This should be cast to the type required.
		/// </returns>
		public static SafeCoTaskMemHandle InternetQueryOption(this SafeInternetHandle hInternet, InternetOptionFlags option)
		{
			var sz = 0;
			InternetQueryOption(hInternet, option, IntPtr.Zero, ref sz);
			var err = Win32Error.GetLastError();
			if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER) err.ThrowIfFailed();
			var hMem = new SafeCoTaskMemHandle(sz);
			var res = InternetQueryOption(hInternet, option, (IntPtr)hMem, ref sz);
			if (!res) Win32Error.ThrowLastError();
			return hMem;
		}

		/// <summary>Queries an Internet option on the specified handle.</summary>
		/// <typeparam name="T">The expected type returned by the option.</typeparam>
		/// <param name="hInternet">Handle on which to query information.</param>
		/// <param name="option">Internet option to be queried. This can be one of the Option Flags values.</param>
		/// <returns>The option setting.</returns>
		public static T InternetQueryOption<T>(this SafeInternetHandle hInternet, InternetOptionFlags option)
		{
			if (!CorrespondingTypeAttribute.CanGet(option, typeof(T))) throw new ArgumentException($"{option} cannot be used to get values of type {typeof(T)}.");
			var hMem = InternetQueryOption(hInternet, option);
			return typeof(T) == typeof(string) ? (T)(object)hMem.ToString(-1) : (typeof(T) == typeof(bool) ? (T)(object)Convert.ToBoolean(hMem.ToStructure<uint>()) : hMem.ToStructure<T>());
		}

		/// <summary>Sets an Internet option.</summary>
		/// <param name="hInternet">Handle on which to set information.</param>
		/// <param name="dwOption">Internet option to be set. This can be one of the Option Flags values.</param>
		/// <param name="lpBuffer">Pointer to a buffer that contains the option setting.</param>
		/// <param name="lpdwBufferLength">
		/// Size of the lpBuffer buffer. If lpBuffer contains a string, the size is in TCHARs. If lpBuffer contains anything other than a
		/// string, the size is in bytes.
		/// </param>
		/// <returns>Returns TRUE if successful, or FALSE otherwise. To get a specific error message, call GetLastError.</returns>
		[DllImport(Lib.WinInet, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InternetSetOption(SafeInternetHandle hInternet, InternetOptionFlags dwOption, IntPtr lpBuffer, int lpdwBufferLength);

		/// <summary>Sets an Internet option</summary>
		/// <param name="hInternet">Handle on which to set information.</param>
		/// <param name="option">Internet option to be set. This can be one of the Option Flags values.</param>
		public static void InternetSetOption(this SafeInternetHandle hInternet, InternetOptionFlags option)
		{
			if (CorrespondingTypeAttribute.GetCorrespondingTypes(option).FirstOrDefault() != null) throw new ArgumentException($"{option} cannot be used to set options that do not require a value.");
			var res = InternetSetOption(hInternet, option, IntPtr.Zero, 0);
			if (!res) Win32Error.ThrowLastError();
		}

		/// <summary>Sets an Internet option</summary>
		/// <typeparam name="T">The type expected by the option.</typeparam>
		/// <param name="hInternet">Handle on which to set information.</param>
		/// <param name="option">Internet option to be set. This can be one of the Option Flags values.</param>
		/// <param name="value">The option setting value.</param>
		public static void InternetSetOption<T>(this SafeInternetHandle hInternet, InternetOptionFlags option, T value)
		{
			if (!CorrespondingTypeAttribute.CanSet(option, typeof(T))) throw new ArgumentException($"{option} cannot be used to set values of type {typeof(T)}.");
			var hMem = typeof(T) == typeof(string) ? new SafeCoTaskMemHandle(value?.ToString()) : (typeof(T) == typeof(bool) ? SafeCoTaskMemHandle.CreateFromStructure(Convert.ToUInt32(value)) : SafeCoTaskMemHandle.CreateFromStructure(value));
			var res = InternetSetOption(hInternet, option, (IntPtr)hMem, typeof(T) == typeof(string) ? value?.ToString().Length + 1 ?? 0 : (int)hMem.Size);
			if (!res) Win32Error.ThrowLastError();
		}

		/// <summary>
		/// The InternetSetStatusCallback function sets up a callback function that WinINet functions can call as progress is made during an operation.
		/// </summary>
		/// <param name="hInternet">The handle for which the callback is set.</param>
		/// <param name="lpfnInternetCallback">
		/// A pointer to the callback function to call when progress is made, or NULL to remove the existing callback function. For more
		/// information about the callback function, see InternetStatusCallback.
		/// </param>
		/// <returns>
		/// Returns the previously defined status callback function if successful, NULL if there was no previously defined status callback
		/// function, or INTERNET_INVALID_STATUS_CALLBACK if the callback function is not valid.
		/// </returns>
		[DllImport(Lib.WinInet, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr InternetSetStatusCallback(SafeInternetHandle hInternet, INTERNET_STATUS_CALLBACK lpfnInternetCallback);

		[DllImport("inetcpl.cpl", SetLastError = true)]
		private static extern int LaunchInternetControlPanel(HWND hWnd);

		/// <summary>Contains the global HTTP version.</summary>
		/// <remarks>
		/// On Windows 7, Windows Server 2008 R2, and later, the value in the HTTP_VERSION_INFO structure is overridden by Internet Explorer
		/// settings. EnableHttp1_1 is a registry value under HKLM\Software\Microsoft\InternetExplorer\AdvacnedOptions\HTTP\GENABLE
		/// controlled by Internet Options set in Internet Explorer for the system. The EnableHttp1_1 value defaults to 1. The
		/// HTTP_VERSION_INFO structure is ignored for any HTTP version less than 1.1 if EnableHttp1_1 is set to 1.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential)]
		public struct HTTP_VERSION_INFO
		{
			/// <summary>The major version number. Must be 1.</summary>
			public uint dwMajorVersion;

			/// <summary>The minor version number. Can be either 1 or zero.</summary>
			public uint dwMinorVersion;
		}

		/// <summary>Contains the LastModified and Expire times for a resource stored in the Internet cache.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNET_CACHE_TIMESTAMPS
		{
			/// <summary>FILETIME structure that contains the Expires time.</summary>
			public FILETIME ftExpires;

			/// <summary>FILETIME structure that contains the LastModified time.</summary>
			public FILETIME ftLastModified;
		}

		/// <summary>Contains certificate information returned from the server. This structure is used by the InternetQueryOption function.</summary>
		/// <remarks>
		/// Despite what the header indicates, the implementation of INTERNET_CERTIFICATE_INFO is not Unicode-aware. All of the string
		/// members are filled as ANSI strings regardless of whether Unicode is enabled. Consequently, when reading these values, the caller
		/// must cast them to LPSTR if Unicode is enabled.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct INTERNET_CERTIFICATE_INFO
		{
			/// <summary>FILETIME structure that contains the date the certificate expires.</summary>
			public FILETIME ftExpiry;

			/// <summary>FILETIME structure that contains the date the certificate becomes valid.</summary>
			public FILETIME ftStart;

			/// <summary>
			/// Pointer to a buffer that contains the name of the organization, site, and server for which the certificate was issued. The
			/// application must call LocalFree to release the resources allocated for this parameter.
			/// </summary>
			public StrPtrAnsi lpszSubjectInfo;

			/// <summary>
			/// Pointer to a buffer that contains the name of the organization, site, and server that issued the certificate. The application
			/// must call LocalFree to release the resources allocated for this parameter.
			/// </summary>
			public StrPtrAnsi lpszIssuerInfo;

			/// <summary>
			/// Pointer to a buffer that contains the name of the protocol used to provide the secure connection. The application must call
			/// LocalFree to release the resources allocated for this parameter.
			/// </summary>
			public StrPtrAnsi lpszProtocolName;

			/// <summary>
			/// Pointer to a buffer that contains the name of the algorithm used for signing the certificate. The application must call
			/// LocalFree to release the resources allocated for this parameter.
			/// </summary>
			public StrPtrAnsi lpszSignatureAlgName;

			/// <summary>
			/// Pointer to a buffer that contains the name of the algorithm used for doing encryption over the secure channel (SSL/PCT)
			/// connection. The application must call LocalFree to release the resources allocated for this parameter.
			/// </summary>
			public StrPtrAnsi lpszEncryptionAlgName;

			/// <summary>Size, in TCHARs, of the key.</summary>
			public uint dwKeySize;
		}

		/// <summary>
		/// The INTERNET_DIAGNOSTIC_SOCKET_INFO structure is returned by the InternetQueryOption function when the
		/// INTERNET_OPTION_DIAGNOSTIC_SOCKET_INFO flag is passed to it together with a handle to an HTTP Request. The
		/// INTERNET_DIAGNOSTIC_SOCKET_INFO structure contains information about the socket associated with that HTTP Request.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct INTERNET_DIAGNOSTIC_SOCKET_INFO
		{
			/// <summary>Descriptor that identifies the socket associated with the specified HTTP Request.</summary>
			public IntPtr Socket;

			/// <summary>The address of the port at which the HTTP Request and response was received.</summary>
			public uint SourcePort;

			/// <summary>The address of the port at which the response was sent.</summary>
			public uint DestPort;

			/// <summary>The flags</summary>
			public IDSI_Flags Flags;
		}

		/// <summary>Contains the value of an option.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNET_PER_CONN_OPTION
		{
			/// <summary>Option to be queried or set.</summary>
			public INTERNET_PER_CONN_OPTION_ID dwOption;

			/// <summary>
			/// Union that contains the value for the option. It can be any one of the following types depending on the value of dwOption.
			/// </summary>
			public INTERNET_PER_CONN_OPTION_Value Value;

			/// <summary>
			/// Union that contains the value for the option. It can be any one of the following types depending on the value of dwOption.
			/// </summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct INTERNET_PER_CONN_OPTION_Value
			{
				/// <summary>Unsigned long integer value.</summary>
				[FieldOffset(0)]
				public uint dwValue;

				/// <summary>Pointer to a string value.</summary>
				[FieldOffset(0)]
				public StrPtrAuto pszValue;

				/// <summary>A FILETIME structure.</summary>
				[FieldOffset(0)]
				public FILETIME ftValue;
			}
		}

		/// <summary>Contains the list of options for a particular Internet connection.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct INTERNET_PER_CONN_OPTION_LIST
		{
			/// <summary>Size of the structure, in bytes.</summary>
			public uint dwSize;

			/// <summary>
			/// Pointer to a string that contains the name of the RAS connection or NULL, which indicates the default or LAN connection, to
			/// set or query options on.
			/// </summary>
			public StrPtrAuto pszConnection;

			/// <summary>Number of options to query or set.</summary>
			public uint dwOptionCount;

			/// <summary>Options that failed, if an error occurs.</summary>
			public uint dwOptionError;

			/// <summary>Pointer to an array of INTERNET_PER_CONN_OPTION structures containing the options to query or set.</summary>
			public IntPtr pOptions;
		}

		/// <summary>
		/// Contains information that is supplied with the INTERNET_OPTION_PROXY value to get or set proxy information on a handle obtained
		/// from a call to the InternetOpen function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct INTERNET_PROXY_INFO
		{
			/// <summary>Access type.</summary>
			public InternetOpenType dwAccessType;

			/// <summary>Pointer to a string that contains the proxy server list.</summary>
			public StrPtrAuto lpszProxy;

			/// <summary>Pointer to a string that contains the proxy bypass list.</summary>
			public StrPtrAuto lpszProxyBypass;
		}

		/// <summary>
		/// Contains the HTTP version number of the server. This structure is used when passing the INTERNET_OPTION_VERSION flag to the
		/// InternetQueryOption function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNET_VERSION_INFO
		{
			/// <summary>Major version number.</summary>
			public uint dwMajorVersion;

			/// <summary>Minor version number.</summary>
			public uint dwMinorVersion;
		}

		public class SafeInternetConnectHandle : SafeInternetHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeInternetConnectHandle"/> class.</summary>
			public SafeInternetConnectHandle() { }

			/// <summary>Initializes a new instance of the <see cref="SafeInternetConnectHandle"/> class.</summary>
			/// <param name="hInternet">An existing handle.</param>
			/// <param name="owns">if set to <c>true</c> owns and disposes of the handle.</param>
			public SafeInternetConnectHandle(IntPtr hInternet, bool owns = true) : base(hInternet, owns) { }

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SafeInternetHandle"/>.</summary>
			/// <param name="hInternet">The HINTERNET handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SafeInternetConnectHandle(IntPtr hInternet) => new SafeInternetConnectHandle(hInternet);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> that is disposed using <see cref="InternetCloseHandle"/>.</summary>
		public class SafeInternetHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeInternetHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeInternetHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeInternetHandle"/> class.</summary>
			protected SafeInternetHandle() : base() { }

			/// <summary>Represents a NULL value for this handle.</summary>
			public static readonly SafeInternetHandle Null = new SafeInternetHandle();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => InternetCloseHandle(this.DangerousGetHandle());
		}
	}
}