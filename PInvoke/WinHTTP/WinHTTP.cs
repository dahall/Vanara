using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.Schannel;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke
{
	/// <summary>Items from the WinHTTP.dll.</summary>
	public static partial class WinHTTP
	{
		/// <summary>The default internet HTTP port.</summary>
		public const ushort INTERNET_DEFAULT_HTTP_PORT = 80;

		/// <summary>The default internet HTTPS port.</summary>
		public const ushort INTERNET_DEFAULT_HTTPS_PORT = 443;

		/// <summary>The default internet port for the specified protocol.</summary>
		public const ushort INTERNET_DEFAULT_PORT = 0;

		/// <summary/>
		public const WINHTTP_ADDREQ_FLAG WINHTTP_ADDREQ_FLAGS_MASK = (WINHTTP_ADDREQ_FLAG)0xFFFF0000;

		/// <summary/>
		public const WINHTTP_ADDREQ_FLAG WINHTTP_ADDREQ_INDEX_MASK = (WINHTTP_ADDREQ_FLAG)0x0000FFFF;

		/// <summary>Default value.</summary>
		public const string WINHTTP_HEADER_NAME_BY_INDEX = null;

		/// <summary>Default value.</summary>
		public const string WINHTTP_NO_ADDITIONAL_HEADERS = null;

		/// <summary>Default value.</summary>
		public const string WINHTTP_NO_HEADER_INDEX = null;

		/// <summary>Default value.</summary>
		public const string WINHTTP_NO_OUTPUT_BUFFER = null;

		/// <summary>Default value.</summary>
		public const string WINHTTP_NO_REQUEST_DATA = null;

		/// <summary>The size of a string buffer to recieve a formatted time.</summary>
		public const uint WINHTTP_TIME_FORMAT_BUFSIZE = 62;

		/// <summary>If the following value is returned by WinHttpSetStatusCallback, then probably an invalid (non-code) address was supplied for the callback.</summary>
		public static readonly IntPtr WINHTTP_INVALID_STATUS_CALLBACK = new(-1);

		/// <summary>Return value from an asynchronous Microsoft Windows HTTP Services (WinHTTP) function.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_ASYNC_RESULT")]
		public enum ASYNC_RESULT : ulong
		{
			/// <summary>The error occurred during a call to WinHttpReceiveResponse.</summary>
			API_RECEIVE_RESPONSE = 1,

			/// <summary>The error occurred during a call to WinHttpQueryDataAvailable.</summary>
			API_QUERY_DATA_AVAILABLE = 2,

			/// <summary>The error occurred during a call to WinHttpReadData.</summary>
			API_READ_DATA = 3,

			/// <summary>The error occurred during a call to WinHttpWriteData.</summary>
			API_WRITE_DATA = 4,

			/// <summary>The error occurred during a call to WinHttpSendRequest.</summary>
			API_SEND_REQUEST = 5,

			/// <summary>The error occurred during a call to WinHttpGetProxyForUrl.</summary>
			API_GET_PROXY_FOR_URL = 6,
		}

		/// <summary>These constants and corresponding values indicate HTTP status codes returned by servers on the Internet.</summary>
		[PInvokeData("winhttp.h")]
		public enum HTTP_STATUS
		{
			/// <summary>The request can be continued.</summary>
			HTTP_STATUS_CONTINUE = 100,

			/// <summary>The server has switched protocols in an upgrade header.</summary>
			HTTP_STATUS_SWITCH_PROTOCOLS = 101,

			/// <summary>The request completed successfully.</summary>
			HTTP_STATUS_OK = 200,

			/// <summary>The request has been fulfilled and resulted in the creation of a new resource.</summary>
			HTTP_STATUS_CREATED = 201,

			/// <summary>The request has been accepted for processing, but the processing has not been completed.</summary>
			HTTP_STATUS_ACCEPTED = 202,

			/// <summary>The returned meta information in the entity-header is not the definitive set available from the originating server.</summary>
			HTTP_STATUS_PARTIAL = 203,

			/// <summary>The server has fulfilled the request, but there is no new information to send back.</summary>
			HTTP_STATUS_NO_CONTENT = 204,

			/// <summary>
			/// The request has been completed, and the client program should reset the document view that caused the request to be sent to
			/// allow the user to easily initiate another input action.
			/// </summary>
			HTTP_STATUS_RESET_CONTENT = 205,

			/// <summary>The server has fulfilled the partial GET request for the resource.</summary>
			HTTP_STATUS_PARTIAL_CONTENT = 206,

			/// <summary>
			/// During a World Wide Web Distributed Authoring and Versioning (WebDAV) operation, this indicates multiple status codes for a
			/// single response. The response body contains Extensible Markup Language (XML) that describes the status codes. For more
			/// information, see HTTP Extensions for Distributed Authoring.
			/// </summary>
			HTTP_STATUS_WEBDAV_MULTI_STATUS = 207,

			/// <summary>The requested resource is available at one or more locations.</summary>
			HTTP_STATUS_AMBIGUOUS = 300,

			/// <summary>
			/// The requested resource has been assigned to a new permanent Uniform Resource Identifier (URI), and any future references to
			/// this resource should be done using one of the returned URIs.
			/// </summary>
			HTTP_STATUS_MOVED = 301,

			/// <summary>The requested resource resides temporarily under a different URI.</summary>
			HTTP_STATUS_REDIRECT = 302,

			/// <summary>
			/// The response to the request can be found under a different URI and should be retrieved using a GET HTTP verb on that resource.
			/// </summary>
			HTTP_STATUS_REDIRECT_METHOD = 303,

			/// <summary>The requested resource has not been modified.</summary>
			HTTP_STATUS_NOT_MODIFIED = 304,

			/// <summary>The requested resource must be accessed through the proxy given by the location field.</summary>
			HTTP_STATUS_USE_PROXY = 305,

			/// <summary>The redirected request keeps the same HTTP verb. HTTP/1.1 behavior.</summary>
			HTTP_STATUS_REDIRECT_KEEP_VERB = 307,

			/// <summary>The request could not be processed by the server due to invalid syntax.</summary>
			HTTP_STATUS_BAD_REQUEST = 400,

			/// <summary>The requested resource requires user authentication.</summary>
			HTTP_STATUS_DENIED = 401,

			/// <summary>Not implemented in the HTTP protocol.</summary>
			HTTP_STATUS_PAYMENT_REQ = 402,

			/// <summary>The server understood the request, but cannot fulfill it.</summary>
			HTTP_STATUS_FORBIDDEN = 403,

			/// <summary>The server has not found anything that matches the requested URI.</summary>
			HTTP_STATUS_NOT_FOUND = 404,

			/// <summary>The HTTP verb used is not allowed.</summary>
			HTTP_STATUS_BAD_METHOD = 405,

			/// <summary>No responses acceptable to the client were found.</summary>
			HTTP_STATUS_NONE_ACCEPTABLE = 406,

			/// <summary>Proxy authentication required.</summary>
			HTTP_STATUS_PROXY_AUTH_REQ = 407,

			/// <summary>The server timed out waiting for the request.</summary>
			HTTP_STATUS_REQUEST_TIMEOUT = 408,

			/// <summary>
			/// The request could not be completed due to a conflict with the current state of the resource. The user should resubmit with
			/// more information.
			/// </summary>
			HTTP_STATUS_CONFLICT = 409,

			/// <summary>The requested resource is no longer available at the server, and no forwarding address is known.</summary>
			HTTP_STATUS_GONE = 410,

			/// <summary>The server cannot accept the request without a defined content length.</summary>
			HTTP_STATUS_LENGTH_REQUIRED = 411,

			/// <summary>
			/// The precondition given in one or more of the request header fields evaluated to false when it was tested on the server.
			/// </summary>
			HTTP_STATUS_PRECOND_FAILED = 412,

			/// <summary>The server cannot process the request because the request entity is larger than the server is able to process.</summary>
			HTTP_STATUS_REQUEST_TOO_LARGE = 413,

			/// <summary>The server cannot service the request because the request URI is longer than the server can interpret.</summary>
			HTTP_STATUS_URI_TOO_LONG = 414,

			/// <summary>
			/// The server cannot service the request because the entity of the request is in a format not supported by the requested
			/// resource for the requested method.
			/// </summary>
			HTTP_STATUS_UNSUPPORTED_MEDIA = 415,

			/// <summary>The request should be retried after doing the appropriate action.</summary>
			HTTP_STATUS_RETRY_WITH = 449,

			/// <summary>The server encountered an unexpected condition that prevented it from fulfilling the request.</summary>
			HTTP_STATUS_SERVER_ERROR = 500,

			/// <summary>The server does not support the functionality required to fulfill the request.</summary>
			HTTP_STATUS_NOT_SUPPORTED = 501,

			/// <summary>
			/// The server, while acting as a gateway or proxy, received an invalid response from the upstream server it accessed in
			/// attempting to fulfill the request.
			/// </summary>
			HTTP_STATUS_BAD_GATEWAY = 502,

			/// <summary>The service is temporarily overloaded.</summary>
			HTTP_STATUS_SERVICE_UNAVAIL = 503,

			/// <summary>The request was timed out waiting for a gateway.</summary>
			HTTP_STATUS_GATEWAY_TIMEOUT = 504,

			/// <summary>The server does not support the HTTP protocol version that was used in the request message.</summary>
			HTTP_STATUS_VERSION_NOT_SUP = 505,
		}

		/// <summary>Flags that control the operation of this function.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpCreateUrl")]
		[Flags]
		public enum ICU : uint
		{
			/// <summary>Does not convert unsafe characters to escape sequences.</summary>
			ICU_NO_ENCODE = 0x20000000,

			/// <summary>Converts all %XX sequences to characters, including escape sequences, before the URL is parsed.</summary>
			ICU_DECODE = 0x10000000,

			/// <summary>Does not remove meta sequences (such as "." and "..") from the URL.</summary>
			ICU_NO_META = 0x08000000,

			/// <summary>Encodes spaces only.</summary>
			ICU_ENCODE_SPACES_ONLY = 0x04000000,

			/// <summary>
			/// Does not encode or decode characters after "#" or "?", and does not remove trailing white space after "?". If this value is
			/// not specified, the entire URL is encoded and trailing white space is removed.
			/// </summary>
			ICU_BROWSER_MODE = 0x02000000,

			/// <summary>
			/// Encodes any percent signs encountered. By default, percent signs are not encoded. This value is available in Microsoft
			/// Internet Explorer 5 and later.
			/// </summary>
			ICU_ENCODE_PERCENT = 0x00001000,

			/// <summary>
			/// Converts all unsafe characters to their corresponding escape sequences in the path string pointed to by the
			/// <c>lpszUrlPath</c> member and in <c>lpszExtraInfo</c> the extra-information string pointed to by the member of the
			/// URL_COMPONENTS structure pointed to by the <c>lpUrlComponents</c> parameter.
			/// </summary>
			ICU_ESCAPE = 0x80000000,

			/// <summary>
			/// The percent character (%) in the IPv6 literal address must be percent escaped when present in the URI. For example, the scope
			/// ID FE80::2%3, must appear in the URI as "https://[FE80::2%253]/", where %25 is the hex encoded percent character (%). If the
			/// application retrieves the URI from a Unicode API, such as the Winsock WSAAddressToString API, the application must add the
			/// escaped version of the percent character (%) in the hostname of the URI. To create the escaped version of the URI,
			/// applications call InternetCreateUrl with the dwFlags parameter set to ICU_ESCAPE_AUTHORITY, and the IPv6 hostname specified
			/// in the URL components structure specified in the lpUrlComponents parameter.
			/// </summary>
			ICU_ESCAPE_AUTHORITY = 0x00002000,

			/// <summary>
			/// Rejects URLs as input that contains either a username, or a password, or both. If the function fails because of an invalid
			/// URL, subsequent calls to GetLastError will return ERROR_WINHTTP_INVALID_URL.
			/// </summary>
			ICU_REJECT_USERPWD = 0x00004000,
		}

		/// <summary>Internet schemes supported by WinHTTP.</summary>
		[PInvokeData("winhttp.h")]
		public enum INTERNET_SCHEME
		{
			/// <summary>An HTTP internet scheme.</summary>
			INTERNET_SCHEME_HTTP = 1,

			/// <summary>An HTTPS (SSL) internet scheme.</summary>
			INTERNET_SCHEME_HTTPS = 2,

			/// <summary>An FTP internet scheme. This scheme is only supported for use in WinHttpGetProxyForUrl and WinHttpGetProxyForUrlEx.</summary>
			INTERNET_SCHEME_FTP = 3,

			/// <summary>A SOCKS internet scheme. This scheme is only supported for use in WINHTTP_PROXY_RESULT_ENTRY.</summary>
			INTERNET_SCHEME_SOCKS = 4,
		}

		/// <summary>Contains the security flags for a handle.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum SECURITY_FLAG : uint
		{
			/// <summary>Uses secure transfers. This is only returned in a call to WinHttpQueryOption.</summary>
			SECURITY_FLAG_SECURE = 0x00000001,

			/// <summary>Uses weak (40-bit) encryption. This is only returned in a call to WinHttpQueryOption.</summary>
			SECURITY_FLAG_STRENGTH_WEAK = 0x10000000,

			/// <summary>Uses medium (56-bit) encryption. This is only returned in a call to WinHttpQueryOption.</summary>
			SECURITY_FLAG_STRENGTH_MEDIUM = 0x40000000,

			/// <summary>Uses strong (128-bit) encryption. This is only returned in a call to WinHttpQueryOption.</summary>
			SECURITY_FLAG_STRENGTH_STRONG = 0x20000000,

			/// <summary>
			/// Allows an invalid certificate authority. If this flag is set, the application does not receive a
			/// WINHTTP_CALLBACK_STATUS_FLAG_INVALID_CA callback.
			/// </summary>
			SECURITY_FLAG_IGNORE_UNKNOWN_CA = 0x00000100,

			/// <summary>
			/// Allows an invalid certificate date, that is, an expired or not-yet-effective certificate. If this flag is set, the
			/// application does not receive a WINHTTP_CALLBACK_STATUS_FLAG_CERT_DATE_INVALID callback.
			/// </summary>
			SECURITY_FLAG_IGNORE_CERT_DATE_INVALID = 0x00002000,

			/// <summary>
			/// Allows an invalid common name in a certificate; that is, the server name specified by the application does not match the
			/// common name in the certificate. If this flag is set, the application does not receive a
			/// WINHTTP_CALLBACK_STATUS_FLAG_CERT_CN_INVALID callback.
			/// </summary>
			SECURITY_FLAG_IGNORE_CERT_CN_INVALID = 0x00001000,

			/// <summary>Allows the identity of a server to be established with a non-server certificate (for example, a client certificate).</summary>
			SECURITY_FLAG_IGNORE_CERT_WRONG_USAGE = 0x00000200,

			/// <summary>
			/// Allows a weak signature to be ignored. This flag is available in the rollup update for each OS starting with Windows 7 and
			/// Windows Server 2008 R2.
			/// </summary>
			SECURITY_FLAG_IGNORE_ALL_CERT_ERRORS = SECURITY_FLAG_IGNORE_UNKNOWN_CA | SECURITY_FLAG_IGNORE_CERT_DATE_INVALID | SECURITY_FLAG_IGNORE_CERT_CN_INVALID | SECURITY_FLAG_IGNORE_CERT_WRONG_USAGE
		}

		/// <summary>The access type.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_PROXY_INFO")]
		public enum WINHTTP_ACCESS_TYPE : uint
		{
			/// <summary>Applies only when setting proxy information.</summary>
			WINHTTP_ACCESS_TYPE_DEFAULT_PROXY = 0,

			/// <summary>Internet accessed through a direct connection.</summary>
			WINHTTP_ACCESS_TYPE_NO_PROXY = 1,

			/// <summary>Internet accessed using a proxy.</summary>
			WINHTTP_ACCESS_TYPE_NAMED_PROXY = 3,

			/// <summary>Internet accessed using an automatic proxy.</summary>
			WINHTTP_ACCESS_TYPE_AUTOMATIC_PROXY = 4,
		}

		/// <summary>contains the flags used to modify the semantics of this function.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpAddRequestHeaders")]
		[Flags]
		public enum WINHTTP_ADDREQ_FLAG : uint
		{
			/// <summary>Adds the header only if it does not already exist; otherwise, an error is returned.</summary>
			WINHTTP_ADDREQ_FLAG_ADD_IF_NEW = 0x10000000,

			/// <summary>Adds the header if it does not exist. Used with <c>WINHTTP_ADDREQ_FLAG_REPLACE</c>.</summary>
			WINHTTP_ADDREQ_FLAG_ADD = 0x20000000,

			/// <summary>
			/// Merges headers of the same name using a comma. For example, adding "Accept: text/*" followed by "Accept: audio/*" with this
			/// flag results in a single header "Accept: text/*, audio/*". This causes the first header found to be merged. The calling
			/// application must to ensure a cohesive scheme with respect to merged and separate headers.
			/// </summary>
			WINHTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA = 0x40000000,

			/// <summary>Merges headers of the same name using a semicolon.</summary>
			WINHTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON = 0x01000000,

			/// <summary>Merges headers of the same name.</summary>
			WINHTTP_ADDREQ_FLAG_COALESCE = WINHTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA,

			/// <summary>
			/// Replaces or removes a header. If the header value is empty and the header is found, it is removed. If the value is not empty,
			/// it is replaced.
			/// </summary>
			WINHTTP_ADDREQ_FLAG_REPLACE = 0x80000000,
		}

		/// <summary>A flag that contains the authentication scheme.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp.tagWINHTTP_CREDS")]
		[Flags]
		public enum WINHTTP_AUTH_SCHEME : uint
		{
			/// <term>Use basic authentication.</term>
			WINHTTP_AUTH_SCHEME_BASIC = 0x00000001,

			/// <term>Use NTLM authentication.</term>
			WINHTTP_AUTH_SCHEME_NTLM = 0x00000002,

			/// <summary>Indicates passport authentication is available.</summary>
			WINHTTP_AUTH_SCHEME_PASSPORT = 0x00000004,

			/// <term>Use digest authentication.</term>
			WINHTTP_AUTH_SCHEME_DIGEST = 0x00000008,

			/// <term>Select between NTLM and Kerberos authentication.</term>
			WINHTTP_AUTH_SCHEME_NEGOTIATE = 0x00000010,
		}

		/// <summary>Specifies a flag that contains the authentication target.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryAuthSchemes")]
		[Flags]
		public enum WINHTTP_AUTH_TARGET : uint
		{
			/// <summary>Authentication target is a server. Indicates that a 401 status code has been received.</summary>
			WINHTTP_AUTH_TARGET_SERVER = 0x00000000,

			/// <summary>Authentication target is a proxy. Indicates that a 407 status code has been received.</summary>
			WINHTTP_AUTH_TARGET_PROXY = 0x00000001,
		}

		/// <summary>Specifies what protocols are to be used to locate the PAC file.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_AUTOPROXY_OPTIONS")]
		[Flags]
		public enum WINHTTP_AUTO_DETECT_TYPE : uint
		{
			/// <summary>Use DHCP to locate the proxy auto-configuration file.</summary>
			WINHTTP_AUTO_DETECT_TYPE_DHCP = 0x00000001,

			/// <summary>
			/// Use DNS to attempt to locate the proxy auto-configuration file at a well-known location on the domain of the local computer.
			/// </summary>
			WINHTTP_AUTO_DETECT_TYPE_DNS_A = 0x00000002,
		}

		/// <summary>Values for WINHTTP_OPTION_AUTOLOGON_POLICY.</summary>
		[PInvokeData("winhttp.h")]
		public enum WINHTTP_AUTOLOGON_SECURITY_LEVEL : uint
		{
			/// <summary>WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM</summary>
			WINHTTP_AUTOLOGON_SECURITY_LEVEL_DEFAULT = WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM,

			/// <summary>An authenticated log on using the default credentials is performed only for requests on the local Intranet.</summary>
			WINHTTP_AUTOLOGON_SECURITY_LEVEL_MEDIUM = 0,

			/// <summary>An authenticated log on using the default credentials is performed for all requests.</summary>
			WINHTTP_AUTOLOGON_SECURITY_LEVEL_LOW = 1,

			/// <summary>
			/// Default credentials are not used. Note that this flag takes effect only if you specify the server by the actual machine name.
			/// It will not take effect, if you specify the server by "localhost" or IP address.
			/// </summary>
			WINHTTP_AUTOLOGON_SECURITY_LEVEL_HIGH = 2,
		}

		/// <summary>Mechanisms should be used to obtain the PAC file.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_AUTOPROXY_OPTIONS")]
		[Flags]
		public enum WINHTTP_AUTOPROXY : uint
		{
			/// <summary>Attempt to automatically discover the URL of the PAC file using both DHCP and DNS queries to the local network.</summary>
			WINHTTP_AUTOPROXY_AUTO_DETECT = 0x00000001,

			/// <summary>
			/// Download the PAC file from the URL specified by <c>lpszAutoConfigUrl</c> in the <c>WINHTTP_AUTOPROXY_OPTIONS</c> structure.
			/// </summary>
			WINHTTP_AUTOPROXY_CONFIG_URL = 0x00000002,

			/// <summary>Maintains the case of the hostnames passed to the PAC script. This is the default behavior.</summary>
			WINHTTP_AUTOPROXY_HOST_KEEPCASE = 0x00000004,

			/// <summary>Converts hostnames to lowercase before passing them to the PAC script.</summary>
			WINHTTP_AUTOPROXY_HOST_LOWERCASE = 0x00000008,

			/// <summary>Enables proxy detection via autoconfig URL.</summary>
			WINHTTP_AUTOPROXY_ALLOW_AUTOCONFIG = 0x00000100,

			/// <summary>Enables proxy detection via static configuration.</summary>
			WINHTTP_AUTOPROXY_ALLOW_STATIC = 0x00000200,

			/// <summary>Enables proxy detection via connection manager.</summary>
			WINHTTP_AUTOPROXY_ALLOW_CM = 0x00000400,

			/// <summary>
			/// Executes the Web Proxy Auto-Discovery (WPAD) protocol in-process instead of delegating to an out-of-process WinHTTP AutoProxy
			/// Service, if available. This flag must be combined with one of the other flags. This option has no effect when passed to WinHttpGetProxyForUrlEx.
			/// </summary>
			WINHTTP_AUTOPROXY_RUN_INPROCESS = 0x00010000,

			/// <summary>
			/// By default, WinHTTP is configured to fall back to auto-discover a proxy in-process. If this fallback behavior is undesirable
			/// in the event that an out-of-process discovery fails, it can be disabled using this flag. This option has no effect when
			/// passed to WinHttpGetProxyForUrlEx.
			/// </summary>
			WINHTTP_AUTOPROXY_RUN_OUTPROCESS_ONLY = 0x00020000,

			/// <summary>Disables querying Direct Access proxy settings for this request.</summary>
			WINHTTP_AUTOPROXY_NO_DIRECTACCESS = 0x00040000,

			/// <summary>Disables querying a host to proxy cache of script execution results in the current process.</summary>
			WINHTTP_AUTOPROXY_NO_CACHE_CLIENT = 0x00080000,

			/// <summary>Disables querying a host to proxy cache of script execution results in the autoproxy service.</summary>
			WINHTTP_AUTOPROXY_NO_CACHE_SVC = 0x00100000,

			/// <summary>Orders the proxy results based on a heuristic placing the fastest proxies first.</summary>
			WINHTTP_AUTOPROXY_SORT_RESULTS = 0x00400000,
		}

		/// <summary>Specifies flags to indicate which events activate the callback function.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpSetStatusCallback")]
		[Flags]
		public enum WINHTTP_CALLBACK_FLAG : uint
		{
			/// <summary>Activates upon beginning and completing name resolution.</summary>
			WINHTTP_CALLBACK_FLAG_RESOLVE_NAME = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_RESOLVING_NAME | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_NAME_RESOLVED,

			/// <summary>Activates upon beginning and completing connection to the server.</summary>
			WINHTTP_CALLBACK_FLAG_CONNECT_TO_SERVER = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_CONNECTING_TO_SERVER | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER,

			/// <summary>Activates upon beginning and completing the sending of a request header with WinHttpSendRequest.</summary>
			WINHTTP_CALLBACK_FLAG_SEND_REQUEST = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_SENDING_REQUEST | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_REQUEST_SENT,

			/// <summary>Activates upon beginning and completing the receipt of a resource from the HTTP server.</summary>
			WINHTTP_CALLBACK_FLAG_RECEIVE_RESPONSE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED,

			/// <summary>Activates when beginning and completing the closing of an HTTP connection.</summary>
			WINHTTP_CALLBACK_FLAG_CLOSE_CONNECTION = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED,

			/// <summary>Activates when an HINTERNET handle is created or closed.</summary>
			WINHTTP_CALLBACK_FLAG_HANDLES = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_HANDLE_CREATED | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING,

			/// <summary>Activates when detecting the proxy server.</summary>
			WINHTTP_CALLBACK_FLAG_DETECTING_PROXY = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_DETECTING_PROXY,

			/// <summary>Activates when the request is redirected.</summary>
			WINHTTP_CALLBACK_FLAG_REDIRECT = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_REDIRECT,

			/// <summary>Activates when receiving an intermediate (100 level) status code message from the server.</summary>
			WINHTTP_CALLBACK_FLAG_INTERMEDIATE_RESPONSE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE,

			/// <summary>Activates upon a secure connection failure.</summary>
			WINHTTP_CALLBACK_FLAG_SECURE_FAILURE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_SECURE_FAILURE,

			/// <summary>Activates when a request header has been sent with WinHttpSendRequest.</summary>
			WINHTTP_CALLBACK_FLAG_SENDREQUEST_COMPLETE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE,

			/// <summary>Activates when the response headers are available for retrieval.</summary>
			WINHTTP_CALLBACK_FLAG_HEADERS_AVAILABLE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE,

			/// <summary>Activates when completing a query for data.</summary>
			WINHTTP_CALLBACK_FLAG_DATA_AVAILABLE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE,

			/// <summary>Activates upon completion of a data-read operation.</summary>
			WINHTTP_CALLBACK_FLAG_READ_COMPLETE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_READ_COMPLETE,

			/// <summary>Activates upon completion of a data-post operation.</summary>
			WINHTTP_CALLBACK_FLAG_WRITE_COMPLETE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE,

			/// <summary>Activates when an asynchronous error occurs.</summary>
			WINHTTP_CALLBACK_FLAG_REQUEST_ERROR = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_REQUEST_ERROR,

			/// <summary/>
			WINHTTP_CALLBACK_FLAG_GETPROXYFORURL_COMPLETE = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE,

			/// <summary>
			/// Activates upon any completion notification. This flag specifies that all notifications required for read or write operations
			/// are used. See WINHTTP_STATUS_CALLBACK for a list of completions.
			/// </summary>
			WINHTTP_CALLBACK_FLAG_ALL_COMPLETIONS = WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE |
				WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE |
				WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_READ_COMPLETE | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE |
				WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_REQUEST_ERROR | WINHTTP_CALLBACK_STATUS.WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE,

			/// <summary>
			/// Activates upon any status change notification including completions. See WINHTTP_STATUS_CALLBACK for a list of notifications.
			/// </summary>
			WINHTTP_CALLBACK_FLAG_ALL_NOTIFICATIONS = 0xffffffff,
		}

		/// <summary>Specifies the status code that indicates why the callback function is called.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NC:winhttp.WINHTTP_STATUS_CALLBACK")]
		[Flags]
		public enum WINHTTP_CALLBACK_STATUS : uint
		{
			/// <summary>The connection was successfully closed via a call to WinHttpWebSocketClose.</summary>
			WINHTTP_CALLBACK_STATUS_CLOSE_COMPLETE = 0x02000000,

			/// <summary>Closing the connection to the server. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</summary>
			WINHTTP_CALLBACK_STATUS_CLOSING_CONNECTION = 0x00000100,

			/// <summary>
			/// Successfully connected to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to an <c>LPWSTR</c> that
			/// indicates the IP address of the server in dotted notation.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_CONNECTED_TO_SERVER = 0x00000008,

			/// <summary>
			/// Connecting to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to an <c>LPWSTR</c> that indicates the
			/// IP address of the server in dotted notation.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_CONNECTING_TO_SERVER = 0x00000004,

			/// <summary>Successfully closed the connection to the server. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</summary>
			WINHTTP_CALLBACK_STATUS_CONNECTION_CLOSED = 0x00000200,

			/// <summary>
			/// Data is available to be retrieved with WinHttpReadData. The <c>lpvStatusInformation</c> parameter points to a <c>DWORD</c>
			/// that contains the number of bytes of data available. The <c>dwStatusInformationLength</c> parameter itself is 4 (the size of
			/// a <c>DWORD</c>).
			/// </summary>
			WINHTTP_CALLBACK_STATUS_DATA_AVAILABLE = 0x00040000,

			/// <summary>Not implemented.</summary>
			WINHTTP_CALLBACK_STATUS_DETECTING_PROXY = 0x00001000,

			/// <summary>
			/// The operation initiated by a call to WinHttpGetProxyForUrlEx is complete. Data is available to be retrieved with WinHttpReadData.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_GETPROXYFORURL_COMPLETE = 0x01000000,

			/// <summary>
			/// This handle value has been terminated. The <c>lpvStatusInformation</c> parameter contains a pointer to the HINTERNET handle.
			/// There will be no more callbacks for this handle.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING = 0x00000800,

			/// <summary>
			/// An HINTERNET handle has been created. The <c>lpvStatusInformation</c> parameter contains a pointer to the HINTERNET handle.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_HANDLE_CREATED = 0x00000400,

			/// <summary>
			/// The response header has been received and is available with WinHttpQueryHeaders. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_HEADERS_AVAILABLE = 0x00020000,

			/// <summary>
			/// Received an intermediate (100 level) status code message from the server. The <c>lpvStatusInformation</c> parameter contains
			/// a pointer to a <c>DWORD</c> that indicates the status code.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_INTERMEDIATE_RESPONSE = 0x00008000,

			/// <summary>
			/// Successfully found the IP address of the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a
			/// <c>LPWSTR</c> that indicates the name that was resolved.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_NAME_RESOLVED = 0x00000002,

			/// <summary>
			/// <para>
			/// Data was successfully read from the server. The <c>lpvStatusInformation</c> parameter contains a pointer to the buffer
			/// specified in the call to WinHttpReadData. The <c>dwStatusInformationLength</c> parameter contains the number of bytes read.
			/// </para>
			/// <para>
			/// When used by WinHttpWebSocketReceive, the <c>lpvStatusInformation</c> parameter contains a pointer to a
			/// WINHTTP_WEB_SOCKET_STATUS structure, and the <c>dwStatusInformationLength</c> parameter indicates the size of <c>lpvStatusInformation</c>.
			/// </para>
			/// </summary>
			WINHTTP_CALLBACK_STATUS_READ_COMPLETE = 0x00080000,

			/// <summary>Waiting for the server to respond to a request. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</summary>
			WINHTTP_CALLBACK_STATUS_RECEIVING_RESPONSE = 0x00000040,

			/// <summary>
			/// An HTTP request is about to automatically redirect the request. The <c>lpvStatusInformation</c> parameter contains a pointer
			/// to an <c>LPWSTR</c> indicating the new URL. At this point, the application can read any data returned by the server with the
			/// redirect response and can query the response headers. It can also cancel the operation by closing the handle.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_REDIRECT = 0x00004000,

			/// <summary>
			/// An error occurred while sending an HTTP request. The <c>lpvStatusInformation</c> parameter contains a pointer to a
			/// WINHTTP_ASYNC_RESULT structure. Its <c>dwResult</c> member indicates the ID of the called function and <c>dwError</c>
			/// indicates the return value.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_REQUEST_ERROR = 0x00200000,

			/// <summary>
			/// Successfully sent the information request to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a
			/// <c>DWORD</c> indicating the number of bytes sent.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_REQUEST_SENT = 0x00000020,

			/// <summary>
			/// Looking up the IP address of a server name. The <c>lpvStatusInformation</c> parameter contains a pointer to the server name
			/// being resolved.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_RESOLVING_NAME = 0x00000001,

			/// <summary>
			/// Successfully received a response from the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a
			/// <c>DWORD</c> indicating the number of bytes received.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_RESPONSE_RECEIVED = 0x00000080,

			/// <summary>
			/// One or more errors were encountered while retrieving a Secure Sockets Layer (SSL) certificate from the server. The
			/// <c>lpvStatusInformation</c> parameter contains a flag. For more information, see the description for <c>lpvStatusInformation</c>.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_SECURE_FAILURE = 0x00010000,

			/// <summary>Sending the information request to the server. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</summary>
			WINHTTP_CALLBACK_STATUS_SENDING_REQUEST = 0x00000010,

			/// <summary>The request completed successfully. The <c>lpvStatusInformation</c> parameter is <c>NULL</c>.</summary>
			WINHTTP_CALLBACK_STATUS_SENDREQUEST_COMPLETE = 0x00400000,

			/// <summary/>
			WINHTTP_CALLBACK_STATUS_SETTINGS_READ_COMPLETE = 0x20000000,

			/// <summary/>
			WINHTTP_CALLBACK_STATUS_SETTINGS_WRITE_COMPLETE = 0x10000000,

			/// <summary>The connection was successfully shut down via a call to WinHttpWebSocketShutdown.</summary>
			WINHTTP_CALLBACK_STATUS_SHUTDOWN_COMPLETE = 0x04000000,

			/// <summary>
			/// <para>
			/// Data was successfully written to the server. The <c>lpvStatusInformation</c> parameter contains a pointer to a <c>DWORD</c>
			/// that indicates the number of bytes written.
			/// </para>
			/// <para>
			/// When used by WinHttpWebSocketSend, the <c>lpvStatusInformation</c> parameter contains a pointer to a
			/// WINHTTP_WEB_SOCKET_STATUS structure, and the <c>dwStatusInformationLength</c> parameter indicates the size of <c>lpvStatusInformation</c>.
			/// </para>
			/// </summary>
			WINHTTP_CALLBACK_STATUS_WRITE_COMPLETE = 0x00100000,
		}

		/// <summary>
		/// If the <c>dwInternetStatus</c> argument is WINHTTP_CALLBACK_STATUS_SECURE_FAILURE, then <c>lpvStatusInformation</c> points to a
		/// DWORD which is a bitwise-OR combination of one or more of the following values.
		/// </summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NC:winhttp.WINHTTP_STATUS_CALLBACK")]
		[Flags]
		public enum WINHTTP_CALLBACK_STATUS_FLAG : uint
		{
			/// <summary>
			/// Certification revocation checking has been enabled, but the revocation check failed to verify whether a certificate has been
			/// revoked. The server used to check for revocation might be unreachable.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_FLAG_CERT_REV_FAILED = 0x00000001,

			/// <summary>SSL certificate is invalid.</summary>
			WINHTTP_CALLBACK_STATUS_FLAG_INVALID_CERT = 0x00000002,

			/// <summary>SSL certificate was revoked.</summary>
			WINHTTP_CALLBACK_STATUS_FLAG_CERT_REVOKED = 0x00000004,

			/// <summary>The function is unfamiliar with the Certificate Authority that generated the server's certificate.</summary>
			WINHTTP_CALLBACK_STATUS_FLAG_INVALID_CA = 0x00000008,

			/// <summary>
			/// SSL certificate common name (host name field) is incorrect, for example, if you entered www.microsoft.com and the common name
			/// on the certificate says www.msn.com.
			/// </summary>
			WINHTTP_CALLBACK_STATUS_FLAG_CERT_CN_INVALID = 0x00000010,

			/// <summary>SSL certificate date that was received from the server is bad. The certificate is expired.</summary>
			WINHTTP_CALLBACK_STATUS_FLAG_CERT_DATE_INVALID = 0x00000020,

			/// <summary/>
			WINHTTP_CALLBACK_STATUS_FLAG_CERT_WRONG_USAGE = 0x00000040,

			/// <summary>The application experienced an internal error loading the SSL libraries.</summary>
			WINHTTP_CALLBACK_STATUS_FLAG_SECURITY_CHANNEL_ERROR = 0x80000000,
		}

		/// <summary>Flags which determine whether WinHTTP will automatically decompress response bodies with compressed Content-Encodings.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_DECOMPRESSION_FLAG : uint
		{
			/// <summary>Decompress Content-Encoding: gzip responses.</summary>
			WINHTTP_DECOMPRESSION_FLAG_GZIP = 0x00000001,

			/// <summary>Decompress Content-Encoding: deflate responses.</summary>
			WINHTTP_DECOMPRESSION_FLAG_DEFLATE = 0x00000002,

			/// <summary>Decompress responses with any supported Content-Encoding.</summary>
			WINHTTP_DECOMPRESSION_FLAG_ALL = WINHTTP_DECOMPRESSION_FLAG_GZIP | WINHTTP_DECOMPRESSION_FLAG_DEFLATE
		}

		/// <summary>Specifies which features are disabled.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_DISABLE : uint
		{
			/// <summary>
			/// Automatic addition of cookie headers to requests is disabled. Also, returned cookies are not automatically added to the
			/// cookie database. Disabling cookies can result in poor performance for Passport authentication.
			/// </summary>
			WINHTTP_DISABLE_COOKIES = 0x00000001,

			/// <summary>
			/// Automatic redirection is disabled when sending requests with WinHttpSendRequest. If automatic redirection is disabled, an
			/// application must register a callback function in order for Passport authentication to succeed.
			/// </summary>
			WINHTTP_DISABLE_REDIRECTS = 0x00000002,

			/// <summary>Automatic authentication is disabled.</summary>
			WINHTTP_DISABLE_AUTHENTICATION = 0x00000004,

			/// <summary>
			/// Disables keep-alive semantics for the connection. Keep-alive semantics are required for MSN, NTLM, and other types of authentication.
			/// </summary>
			WINHTTP_DISABLE_KEEP_ALIVE = 0x00000008,
		}

		/// <summary>Specifies whether Passport Authentication in WinHTTP authentication is enabled.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_DISABLE_PASSPORT : uint
		{
			/// <summary>Microsoft Passport authentication is disabled. This is the default.</summary>
			WINHTTP_DISABLE_PASSPORT_AUTH = 0x00000000,

			/// <summary>Passport authentication is enabled.</summary>
			WINHTTP_ENABLE_PASSPORT_AUTH = 0x10000000,

			/// <summary>The Passport keyring is disabled. This is the default.</summary>
			WINHTTP_DISABLE_PASSPORT_KEYRING = 0x20000000,

			/// <summary>The Passport keyring is enabled.</summary>
			WINHTTP_ENABLE_PASSPORT_KEYRING = 0x40000000,
		}

		/// <summary>Specifies the features currently enabled.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_ENABLE_SSL : uint
		{
			/// <summary>If enabled, WinHTTP allows SSL revocation. This value can be set only on the request handle.</summary>
			WINHTTP_ENABLE_SSL_REVOCATION = 0x00000001,

			/// <summary>
			/// If enabled, WinHTTP temporarily reverts client impersonation for the duration of SSL certificate authentication operations.
			/// This value can be set only on the session handle.
			/// </summary>
			WINHTTP_ENABLE_SSL_REVERT_IMPERSONATION = 0x00000002,
		}

		/// <summary>Flags for WinHttpAddRequestHeadersEx.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpAddRequestHeadersEx")]
		[Flags]
		public enum WINHTTP_EXTENDED_HEADER_FLAG : ulong
		{
			/// <summary>Indicate that the strings passed in are Unicode strings.</summary>
			WINHTTP_EXTENDED_HEADER_FLAG_UNICODE = 1
		}

		/// <summary>Specifies which secure protocols are acceptable.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_FLAG_SECURE_PROTOCOL : uint
		{
			/// <summary>The SSL 2.0 protocol can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_SSL2 = 0x00000008,

			/// <summary>The SSL 3.0 protocol can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_SSL3 = 0x00000020,

			/// <summary>The TLS 1.0 protocol can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_TLS1 = 0x00000080,

			/// <summary>The TLS 1.1 protocol can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_1 = 0x00000200,

			/// <summary>The TLS 1.2 protocol can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_2 = 0x00000800,

			/// <summary>The TLS 1.3 protocol can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_TLS1_3 = 0x00002000,

			/// <summary>The Secure Sockets Layer (SSL) 2.0, SSL 3.0, and Transport Layer Security (TLS) 1.0 protocols can be used.</summary>
			WINHTTP_FLAG_SECURE_PROTOCOL_ALL = WINHTTP_FLAG_SECURE_PROTOCOL_SSL2 | WINHTTP_FLAG_SECURE_PROTOCOL_SSL3 | WINHTTP_FLAG_SECURE_PROTOCOL_TLS1,
		}

		/// <summary>The type of the HINTERNET handle passed in.</summary>
		[PInvokeData("winhttp.h")]
		public enum WINHTTP_HANDLE_TYPE : uint
		{
			/// <summary>The handle is a session handle.</summary>
			WINHTTP_HANDLE_TYPE_SESSION = 1,

			/// <summary>The handle is a connection handle.</summary>
			WINHTTP_HANDLE_TYPE_CONNECT = 2,

			/// <summary>The handle is a request handle.</summary>
			WINHTTP_HANDLE_TYPE_REQUEST = 3,
		}

		/// <summary>Flags for WINHTTP_MATCH_CONNECTION_GUID.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NS:winhttp._WINHTTP_MATCH_CONNECTION_GUID")]
		[Flags]
		public enum WINHTTP_MATCH_CONNECTION_GUID_FLAG : ulong
		{
			/// <summary>
			/// If you don't want an unmarked connection to be matched. When using that flag, if no matching marked connection is found, then
			/// a new connection is created, and the request is sent on that connection.
			/// </summary>
			WINHTTP_MATCH_CONNECTION_GUID_FLAG_REQUIRE_MARKED_CONNECTION = 0x00000001
		}

		/// <summary>The flags that indicate various options affecting the behavior of WinHttpOpen.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpOpen")]
		[Flags]
		public enum WINHTTP_OPEN_FLAG : uint
		{
			/// <summary>
			/// Use the WinHTTP functions asynchronously. By default, all WinHTTP functions that use the returned HINTERNET handle are
			/// performed synchronously. When this flag is set, the caller needs to specify a callback function through WinHttpSetStatusCallback.
			/// </summary>
			WINHTTP_FLAG_ASYNC = 0x10000000,

			/// <summary>
			/// When this flag is set, WinHttp will require use of TLS 1.2 or newer. If the caller attempts to enable older TLS versions by
			/// setting <c>WINHTTP_OPTION_SECURE_PROTOCOLS</c>, it will fail with <c>ERROR_ACCESS_DENIED</c>. Additionally, TLS fallback will
			/// be disabled. Note that setting this flag also sets flag <c>WINHTTP_FLAG_ASYNC</c>.
			/// </summary>
			WINHTTP_FLAG_SECURE_DEFAULTS = 0x30000000,
		}

		/// <summary></summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpOpenRequest")]
		[Flags]
		public enum WINHTTP_OPENREQ_FLAG : uint
		{
			/// <summary>
			/// Uses secure transaction semantics. This translates to using Secure Sockets Layer (SSL)/Transport Layer Security (TLS).
			/// </summary>
			WINHTTP_FLAG_SECURE = 0x00800000,

			/// <summary>
			/// The string passed in for <c>pwszObjectName</c> is converted from an <c>LPCWSTR</c> to an <c>LPSTR</c>. All unsafe characters
			/// are converted to an escape sequence including the percent symbol. By default, all unsafe characters except the percent symbol
			/// are converted to an escape sequence.
			/// </summary>
			WINHTTP_FLAG_ESCAPE_PERCENT = 0x00000004,

			/// <summary>
			/// The string passed in for <c>pwszObjectName</c> is assumed to consist of valid ANSI characters represented by <c>WCHAR</c>. No
			/// check are done for unsafe characters. <c>Windows 7:</c> This option is obsolete.
			/// </summary>
			WINHTTP_FLAG_NULL_CODEPAGE = 0x00000008,

			/// <summary>This flag provides the same behavior as <c>WINHTTP_FLAG_REFRESH</c>.</summary>
			WINHTTP_FLAG_BYPASS_PROXY_CACHE = 0x00000100,

			/// <summary>
			/// Indicates that the request should be forwarded to the originating server rather than sending a cached version of a resource
			/// from a proxy server. When this flag is used, a "Pragma: no-cache" header is added to the request handle. When creating an
			/// HTTP/1.1 request header, a "Cache-Control: no-cache" is also added.
			/// </summary>
			WINHTTP_FLAG_REFRESH = WINHTTP_FLAG_BYPASS_PROXY_CACHE,

			/// <summary>Unsafe characters in the URL passed in for <c>pwszObjectName</c> are not converted to escape sequences.</summary>
			WINHTTP_FLAG_ESCAPE_DISABLE = 0x00000040,

			/// <summary>
			/// Unsafe characters in the query component of the URL passed in for <c>pwszObjectName</c> are not converted to escape sequences.
			/// </summary>
			WINHTTP_FLAG_ESCAPE_DISABLE_QUERY = 0x00000080,
		}

		/// <summary>
		/// The following option flags are supported by WinHttpQueryOption and WinHttpSetOption.
		/// <para>WINHTTP_OPTION_ASSURED_NON_BLOCKING_CALLBACKS</para>
		/// <para>
		/// The default is FALSE. If set to TRUE, WinHTTP does not guarantee progress if status callbacks are blocked by the client application.
		/// </para>
		/// <para>
		/// The client application must take special care to perform minimal operations within the callback without blocking, returning as
		/// quickly as possible, and in particular must not wait for any subsequent WinHTTP calls. If it does not follow these guidelines,
		/// there is likely to be a negative performance impact or a potential application hang. If used in the prescribed manner, this
		/// option may improve performance.
		/// </para>
		/// </summary>
		[PInvokeData("winhttp.h")]
		public enum WINHTTP_OPTION
		{
			/// <summary>Undocumented.</summary>
			WINHTTP_OPTION_AGGREGATE_PROXY_CONFIG = 181,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_ASSURED_NON_BLOCKING_CALLBACKS = 111,

			/// <summary>
			/// Sets an unsigned long integer value that specifies the Automatic Logon Policy with one of the
			/// WINHTTP_AUTOLOGON_SECURITY_LEVEL values.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_AUTOLOGON_SECURITY_LEVEL), CorrespondingAction.Set)]
			WINHTTP_OPTION_AUTOLOGON_POLICY = 77,

			/// <summary>
			/// When you set this option on a session handle, you must pass the number of connections you wish to open. Then, upon first
			/// sending a request, rather than opening only a single connection, WinHttp opens a number of connections in parallel. This can
			/// improve the performance of subsequent requests to the same destination, which won't have the overhead of connection establishment.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_BACKGROUND_CONNECTIONS = 172,

			/// <summary>Retrieves the pointer to the callback function set with WinHttpSetStatusCallback.</summary>
			[CorrespondingType(typeof(WINHTTP_STATUS_CALLBACK))]
			WINHTTP_OPTION_CALLBACK = 1,

			/// <summary>
			/// <para>
			/// Sets the client certificate context. If an application receives ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED, it must call
			/// WinHttpSetOption to supply a certificate before retrying the request. As a part of processing this option, WinHttp calls
			/// CertDuplicateCertificateContext on the caller-provided certificate context so that the certificate context can be
			/// independently released by the caller.
			/// </para>
			/// <para>
			/// <note type="note">The application should not attempt to close the certificate store with the CERT_CLOSE_STORE_FORCE_FLAG flag
			/// in the call to CertCloseStore on the certificate store from which the certificate context was retrieved. An access violation
			/// may occur.</note>
			/// </para>
			/// <para>
			/// When the server requests a client certificate, WinHttpSendRequest, or WinHttpReceiveResponse returns an
			/// ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED error. If the server requests the certificate but does not require it, the application
			/// can specify this option to indicate that it does not have a certificate. The server can choose another authentication scheme
			/// or allow anonymous access to the server. The application provides the WINHTTP_NO_CLIENT_CERT_CONTEXT macro in the lpBuffer
			/// parameter of WinHttpSetOption as shown in the following code example.
			/// </para>
			/// <para>
			/// <code language="c">BOOL fRet = WinHttpSetOption(hRequest, WINHTTP_OPTION_CLIENT_CERT_CONTEXT, WINHTTP_NO_CLIENT_CERT_CONTEXT, 0);</code>
			/// </para>
			/// <para>
			/// If the server requires a client certificate, it may send a 403 HTTP status code in response. For more information, see the
			/// WINHTTP_OPTION_CLIENT_CERT_ISSUER_LIST option.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(Crypt32.CERT_CONTEXT), CorrespondingAction.Set)]
			WINHTTP_OPTION_CLIENT_CERT_CONTEXT = 47,

			/// <summary>
			/// Retrieves a SecPkgContext_IssuerListInfoEx structure when the error from WinHttpSendRequest or WinHttpReceiveResponse is
			/// ERROR_WINHTTP_CLIENT_AUTH_CERT_NEEDED. The issuer list in the structure contains a list of acceptable Certificate Authorities
			/// (CA) from the server. The client application can filter the CA list to retrieve the client certificate for SSL authentication.
			/// <para>
			/// Alternately, if the server requests the client certificate, but does not require it, the application can call
			/// WinHttpSetOption with the WINHTTP_OPTION_CLIENT_CERT_CONTEXT option. For more information, see the
			/// WINHTTP_OPTION_CLIENT_CERT_CONTEXT option.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_IssuerListInfoEx), CorrespondingAction.Get)]
			WINHTTP_OPTION_CLIENT_CERT_ISSUER_LIST = 94,

			/// <summary>Sets the code page that is used to process the URL (that is, query string). The default is UTF8.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_CODEPAGE = 68,

			/// <summary>
			/// Sets a WINHTTP_DISABLE_PASSPORT value that specifies whether Passport Authentication in WinHTTP authentication is enabled.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_DISABLE_PASSPORT), CorrespondingAction.Set)]
			WINHTTP_OPTION_CONFIGURE_PASSPORT_AUTH = 83,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the number of timesWinHTTP attempts to connect to a host.
			/// Microsoft Windows HTTP Services (WinHTTP) only attempts once per Internet Protocol (IP) address. For example, if you attempt
			/// to connect to a multihomed host that has 10 IP addresses and WINHTTP_OPTION_CONNECT_RETRIES is set to 7, then WinHTTP only
			/// attempts to connect to the first seven IP address. Given the same set of 10 IP addresses, if WINHTTP_OPTION_CONNECT_RETRIES
			/// is set to 20, WinHTTP attempts each of the 10 only once. If a connection attempt still fails after the specified number of
			/// attempts, or if the connect timeout expired before then, the request is canceled. The default value for
			/// WINHTTP_OPTION_CONNECT_RETRIES is five attempts.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_CONNECT_RETRIES = 4,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds. Setting this option to
			/// infinite (0xFFFFFFFF) will disable this timer.
			/// <para>
			/// If a TCP connection request takes longer than this time-out value, the request is canceled. The default timeout is 60
			/// seconds. When you are attempting to connect to multiple IP addresses for a single host (a multihomed host), the timeout limit
			/// is for each individual connection.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_CONNECT_TIMEOUT = 3,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_CONNECTION_FILTER = 131,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(Guid))]
			WINHTTP_OPTION_CONNECTION_GUID = 178,

			/// <summary>
			/// Retrieves the source and destination IP address, and port of the request that generated the response when
			/// WinHttpReceiveResponse returns. The application calls WinHttpQueryOption with the WINHTTP_OPTION_CONNECTION_INFO option, and
			/// provides the WINHTTP_CONNECTION_INFO structure in the lpBuffer parameter. For more information, see WINHTTP_CONNECTION_INFO.
			/// <para>Windows Server 2003 with SP1 and Windows XP with SP2: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_CONNECTION_INFO))]
			WINHTTP_OPTION_CONNECTION_INFO = 93,

			/// <summary>
			/// Retreives the TCP_INFO_v0 struct for the underlying connection used by the request. The returned struct may contain
			/// statistics from prior requests sent over the same connection. <note type="note">This option has been superseded by WINHTTP_OPTION_CONNECTION_STATS_V1.</note>
			/// </summary>
			[CorrespondingType(typeof(TCP_INFO_v0))]
			WINHTTP_OPTION_CONNECTION_STATS_V0 = 141,

			/// <summary>
			/// Retreives the TCP_INFO_v1 struct for the underlying connection used by the request. The returned struct may contain
			/// statistics from prior requests sent over the same connection.
			/// </summary>
			[CorrespondingType(typeof(TCP_INFO_v1))]
			WINHTTP_OPTION_CONNECTION_STATS_V1 = 150,

			/// <summary>
			/// Sets or retrieves a DWORD_PTR that contains a pointer to the context value associated with this HINTERNET handle. The value
			/// stored in the buffer is used and the WINHTTP_OPTION_CONTEXT_VALUE option flag is assigned a new value.
			/// </summary>
			[CorrespondingType(typeof(IntPtr))]
			WINHTTP_OPTION_CONTEXT_VALUE = 45,

			/// <summary>
			/// Sets a WINHTTP_DECOMPRESSION_FLAG flag value which determine whether WinHTTP will automatically decompress response bodies
			/// with compressed Content-Encodings. WinHTTP will also set an appropriate Accept-Encoding header, overriding any supplied by
			/// the caller.
			/// <para>By default, WinHTTP will deliver compressed responses to the caller unmodified.</para>
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_DECOMPRESSION_FLAG), CorrespondingAction.Set)]
			WINHTTP_OPTION_DECOMPRESSION = 118,

			/// <summary>
			/// Setting this option on a WinHttp session handle allows you to enable/disable whether the server certificate chain is built.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_DISABLE_CERT_CHAIN_BUILDING = 171,

			/// <summary>
			/// Sets a WINHTTP_DISABLE value that specifies which features are disabled with one or more of the following flags. Be aware
			/// that this feature should only be passed to WinHttpSetOption on request handles after the request handle is created with
			/// WinHttpOpenRequest, and before the request is sent with WinHttpSendRequest.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_DISABLE), CorrespondingAction.Set)]
			WINHTTP_OPTION_DISABLE_FEATURE = 63,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_DISABLE_PROXY_LINK_LOCAL_NAME_RESOLUTION = 176,

			/// <summary>
			/// Prevents WinHTTP from retrying a connection with a lower version of the security protocol when the initial protocol
			/// negotiation fails.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_DISABLE_SECURE_PROTOCOL_FALLBACK = 144,

			/// <summary>
			/// Allows new requests to open an additional HTTP/2 connection when the maximum concurrent stream limit is reached, rather than
			/// waiting for the next available stream on an existing connection.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_DISABLE_STREAM_QUEUE = 139,

			/// <summary>Sets a WINHTTP_ENABLE_SSL value that specifies the features currently enabled.</summary>
			[CorrespondingType(typeof(WINHTTP_ENABLE_SSL), CorrespondingAction.Set)]
			WINHTTP_OPTION_ENABLE_FEATURE = 79,

			/// <summary>
			/// Sets a DWORD bitmask of acceptable advanced HTTP versions.
			/// <para>Legacy versions of HTTP (1.1 and prior) cannot be disabled using this option. The default is 0x0.</para>
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_PROTOCOL_FLAG), CorrespondingAction.Set)]
			WINHTTP_OPTION_ENABLE_HTTP_PROTOCOL = 133,

			/// <summary>
			/// This option can be set on a WinHttp session handle to allow WinHttp to use the caller-provided client certificate context
			/// when HTTP/2 is being used.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_ENABLE_HTTP2_PLUS_CLIENT_CERT = 161,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_ENABLE_TEST_SIGNING = 174,

			/// <summary>
			/// Sets a BOOL value that specifies whether tracing is currently enabled. For more information about the trace facility in
			/// WinHTTP, see WinHTTP Trace Facility. This option can only be set on a NULL HINTERNET handle.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_ENABLETRACING = 85,

			/// <summary>
			/// Enables URL percent encoding for path and query string. Alternatively, you can percent encode before calling WinHttp.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_ENCODE_EXTRA = 138,

			/// <summary>
			/// This option can only be set on a request handle which is still active (sending or receiving). Setting this option will tell
			/// WinHttp to stop serving requests on the connection associated with the request handle passed in. The connection will be
			/// closed after the request handle this option is called with is completed. This option does not take any parameters.
			/// </summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			WINHTTP_OPTION_EXPIRE_CONNECTION = 143,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains a Microsoft Windows Sockets error code that was mapped to the
			/// ERROR_WINHTTP_* error messages last returned in this thread context. You can pass NULL as the handle value.
			/// </summary>
			[CorrespondingType(typeof(Win32Error), CorrespondingAction.Get)]
			WINHTTP_OPTION_EXTENDED_ERROR = 24,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_FAILED_CONNECTION_RETRIES = 162,

			/// <summary>
			/// By default, when WinHttp sends a request, if there are no available connections to serve the request, WinHttp will attempt to
			/// establish a new connection, and the request will be bound to this new connection. When you set this option, such a request
			/// will instead be served on the first connection that becomes available, and not necessarily the one being established.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_FIRST_AVAILABLE_CONNECTION = 173,

			/// <summary>
			/// Takes a pointer to a WINHTTP_CREDS_EX structure with the hInternet function parameter set to NULL. This option requires
			/// registry key HKLM\Software\Microsoft\Windows\CurrentVersion\Internet Settings!ShareCredsWithWinHttp. If this registry key is
			/// not set WinHTTP will return error ERROR_WINHTTP_INVALID_OPTION. This registry key is not present by default. When it is set,
			/// WinINet will send credentials down to WinHTTP. Whenever WinHttp gets an authentication challenge and if there are no
			/// credentials set on the current handle, it will use the credentials provided by WinINet. In order to share server credentials
			/// in addition to proxy credentials, users needs to set WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_CREDS_EX), CorrespondingAction.Set)]
			WINHTTP_OPTION_GLOBAL_PROXY_CREDS = 97,

			/// <summary>
			/// Takes a pointer to a WINHTTP_CREDS_EX structure with the hInternet function parameter set to NULL. This option requires
			/// registry key HKLM\Software\Microsoft\Windows\CurrentVersion\Internet Settings!ShareCredsWithWinHttp. If this registry key is
			/// not set WinHTTP will return error ERROR_WINHTTP_INVALID_OPTION. This registry key is not present by default. When it is set,
			/// WinINet will send credentials down to WinHTTP. Whenever WinHttp gets an authentication challenge and if there are no
			/// credentials set on the current handle, it will use the credentials provided by WinINet. In order to share server credentials
			/// in addition to proxy credentials, users needs to set WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_CREDS_EX), CorrespondingAction.Set)]
			WINHTTP_OPTION_GLOBAL_SERVER_CREDS = 98,

			/// <summary>Retrieves an unsigned long integer value that contains the type of the HINTERNET handle passed in.</summary>
			[CorrespondingType(typeof(WINHTTP_HANDLE_TYPE), CorrespondingAction.Get)]
			WINHTTP_OPTION_HANDLE_TYPE = 9,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_HEAP_EXTENSION = 157,

			/// <summary>
			/// Prevents protocol versions other than those enabled by WINHTTP_OPTION_ENABLE_HTTP_PROTOCOL from being used for the request.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_HTTP_PROTOCOL_REQUIRED = 145,

			/// <summary>
			/// Gets a DWORD indicating which advanced HTTP version was used on a given request. For a list of possible values, see WINHTTP_OPTION_ENABLE_HTTP_PROTOCOL.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_PROTOCOL_FLAG), CorrespondingAction.Get)]
			WINHTTP_OPTION_HTTP_PROTOCOL_USED = 134,

			/// <summary>
			/// Sets or retrieves an HTTP_VERSION_INFO structure that contains the HTTP version being supported. This is a process-wide
			/// option; use NULL for the handle.
			/// </summary>
			[CorrespondingType(typeof(HTTP_VERSION_INFO))]
			WINHTTP_OPTION_HTTP_VERSION = 59,

			/// <summary>
			/// This option can be set on a session handle to have WinHttp use HTTP/2 PING frames as a keepalive mechanism. Callers specify a
			/// timeout in milliseconds, and after there is no activity on a connection for that timeout period, WinHttp will begin to send
			/// HTTP/2 PING frames. Callers cannot set a timeout value less than 5000 milliseconds.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_HTTP2_KEEPALIVE = 164,

			/// <summary>
			/// This option can be set on a WinHttp request handle to control how WinHttp behaves when an HTTP/2 response contains a
			/// "Transfer-Encoding" header. In such a case, WinHttp will return an error if this option is set to FALSE.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_HTTP2_PLUS_TRANSFER_ENCODING = 169,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_HTTP2_RECEIVE_WINDOW = 183,

			/// <summary>
			/// Allows secure connections to use security certificates for which the certificate revocation list could not be downloaded.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_IGNORE_CERT_REVOCATION_OFFLINE = 155,

			/// <summary>
			/// Enables IPv6 fast fallback (Happier Eyeballs) for the connection. This behavior is similar to the Happy Eyeballs behavior
			/// described in RFC 6555 for improving connection times on networks where IPv6 is unreliable.
			/// <list type="bullet">
			/// <item>
			/// If both IPv6 and IPv4 addresses are resolved for a given host, WinHttp will begin by connecting to the first resolved IPv6
			/// address with a short (300ms) timeout.
			/// </item>
			/// <item>Should that connection fail, WinHttp will attempt to connect to the first resolved IPv4 address with the standard timeout.</item>
			/// <item>Should the second connection fail, WinHttp will retry the first resolved IPv6 address with the standard timeout.</item>
			/// <item>
			/// Should the third connection fail, WinHttp will revert to the default behavior for any remaining addresses, attempting a
			/// connection to each one with the standard timeout until a connection is made or no addresses remain.
			/// </item>
			/// </list>
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_IPV6_FAST_FALLBACK = 140,

			/// <summary>Gets whether or not a Proxy Return Connect Response can be retrieved.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
			WINHTTP_OPTION_IS_PROXY_CONNECT_RESPONSE = 104,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_KDC_PROXY_SETTINGS = 136,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(Guid), CorrespondingAction.Set)]
			WINHTTP_OPTION_MATCH_CONNECTION_GUID = 179,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per HTTP/1.0 server.
			/// The default value is INFINITE.
			/// <para>Windows Vista with SP1 and Windows Server 2008: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_MAX_CONNS_PER_1_0_SERVER = 74,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per server. The
			/// default value is INFINITE.
			/// <para>When this option is set to zero, WinHTTP sets the limit on the number of connections to 2.</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_MAX_CONNS_PER_SERVER = 73,

			/// <summary>
			/// Sets the maximum number of redirects that WinHTTP follows; the default is 10. This limit prevents unauthorized sites from
			/// making the WinHTTP client pause following a large number of redirects.
			/// <para>Windows XP with SP1 and Windows 2000 with SP3: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_MAX_HTTP_AUTOMATIC_REDIRECTS = 89,

			/// <summary>
			/// The maximum number of Informational 100-199 status code responses ignored before returning the final status code to the
			/// WinHTTP client. Informational 100-199 status codes can be sent by the server before the final status code, and are described
			/// in the specification for HTTP/1.1 (for more information, see RFC 2616). The default is 10.
			/// <para>Windows XP with SP1 and Windows 2000 with SP3: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_MAX_HTTP_STATUS_CONTINUE = 90,

			/// <summary>
			/// A bound on the amount of data drained from responses in order to reuse a connection, specified in bytes. The default is 1MB.
			/// <para>Windows XP with SP1 and Windows 2000 with SP3: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_MAX_RESPONSE_DRAIN_SIZE = 92,

			/// <summary>
			/// A bound set on the maximum size of the header portion of the server response, specified in bytes. This bound protects the
			/// client from an unauthorized server attempting to stall the client by sending a response with an infinite amount of header
			/// data. The default value is 64KB.
			/// <para>Windows XP with SP1 and Windows 2000 with SP3: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_MAX_RESPONSE_HEADER_SIZE = 91,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_NTSERVICE_FLAG_TEST = 175,

			/// <summary>Retrieves the parent handle to this handle.</summary>
			[CorrespondingType(typeof(HINTERNET), CorrespondingAction.Get)]
			WINHTTP_OPTION_PARENT_HANDLE = 21,

			/// <summary>
			/// Retrieves a string that contains the cobranding text provided by the Passport logon server. This option should be retrieved
			/// immediately after the logon server responds with a 401 status code. An application should pass in a buffer size, in bytes,
			/// that is big enough to hold the returned string.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			WINHTTP_OPTION_PASSPORT_COBRANDING_TEXT = 81,

			/// <summary>
			/// Retrieves a string that contains a URL for a cobranding graphic provided by the Passport logon server. This option should be
			/// retrieved immediately after the logon server responds with a 401 status code. An application should pass in a buffer size, in
			/// bytes, that is big enough to hold the returned string.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			WINHTTP_OPTION_PASSPORT_COBRANDING_URL = 82,

			/// <summary>Sets a read-only option on a request handle that retrieves the Passport return URL.</summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
			WINHTTP_OPTION_PASSPORT_RETURN_URL = 87,

			/// <summary>
			/// Sets the option on a session handle to sign out of any Passport logins. An application should pass in the Passport return URL
			/// that was retrieved with WINHTTP_OPTION_PASSPORT_RETURN_URL. All cookies related to the return URL are cleared.
			/// </summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Set)]
			WINHTTP_OPTION_PASSPORT_SIGN_OUT = 86,

			/// <summary>Sets or retrieves a string value that contains the password associated with a request handle.</summary>
			[CorrespondingType(typeof(string))]
			WINHTTP_OPTION_PASSWORD = 0x1001,

			/// <summary>
			/// Sets or retrieves an WINHTTP_PROXY_INFO structure that contains the proxy data on an existing session handle or request
			/// handle. When retrieving proxy data, an application must free the lpszProxy and lpszProxyBypass strings contained in this
			/// structure (if they are non-NULL) using the GlobalFree function. An application can query for the global proxy data (the
			/// default proxy) by passing a NULL handle.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_PROXY_INFO), CorrespondingAction.Get)]
			[CorrespondingType(typeof(WINHTTP_PROXY_INFO_IN), CorrespondingAction.Set)]
			WINHTTP_OPTION_PROXY = 38,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(WINHTTP_PROXY_SETTINGS))]
			WINHTTP_OPTION_PROXY_CONFIG_INFO = 180,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_PROXY_DISABLE_SERVICE_CALLS = 137,

			/// <summary>Sets or retrieves a string value that contains the password used to access the proxy.</summary>
			[CorrespondingType(typeof(string))]
			WINHTTP_OPTION_PROXY_PASSWORD = 0x1003,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(WINHTTP_PROXY_RESULT_ENTRY), CorrespondingAction.Set)]
			WINHTTP_OPTION_PROXY_RESULT_ENTRY = 39,

			/// <summary>
			/// Gets the proxy Server Principal Name that WinHTTP supplied to SSPI during authentication. This string value is usefor passing
			/// to SspiPromptForCredentials after an authentication failure.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			WINHTTP_OPTION_PROXY_SPN_USED = 107,

			/// <summary>Sets or retrieves a string value that contains the user name used to access the proxy.</summary>
			[CorrespondingType(typeof(string))]
			WINHTTP_OPTION_PROXY_USERNAME = 0x1002,

			/// <summary>This option has been deprecated; it has no effect.</summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_READ_BUFFER_SIZE = 12,

			/// <summary>Sets whether or not the proxy response entity can be retrieved. This option is disabled by default.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_RECEIVE_PROXY_CONNECT_RESPONSE = 103,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the timeout value, in milliseconds, to wait to receive all
			/// response headers to a request. If WinHTTP fails to receive all the headers within this timeout period, the request is
			/// canceled. The default timeout value is 90 seconds.
			/// <para>
			/// This timeout is checked only when data is received from the socket. As a result, when the timeout expires the client
			/// application is not notified until more data arrives from the server. If no data arrives from the server, the delay between
			/// the timeout expiration and notification of the client application could be as large as the timeout value set using the
			/// dwReceiveTimeout parameter of the WinHttpSetTimeouts function.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_RECEIVE_RESPONSE_TIMEOUT = 7,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds, to receive a partial
			/// response to a request or read some data. If the response takes longer than this time-out value, the request is canceled. The
			/// default timeout value is 30 seconds.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_RECEIVE_TIMEOUT = 6,

			/// <summary>
			/// Sets the behavior of WinHTTP regarding the handling of a 30x HTTP redirect status code. This option can be set on a session
			/// or request handle.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_OPTION_REDIRECT_POLICY), CorrespondingAction.Set)]
			WINHTTP_OPTION_REDIRECT_POLICY = 88,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_REFERER_TOKEN_BINDING_HOSTNAME = 168,

			/// <summary>
			/// Rejects URLs that contain a username and password. This option also rejects URLs that contain username:password semantics,
			/// even if no username or password is specified. For example, "u:p@hostname", ":@hostname", "u:@hostname", and ":p@hostname"
			/// would all be flagged as invalid. If an invalid URL is passed to the function, it returns ERROR_WINHTTP_INVALID_URL. This
			/// option is turned off by default.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_REJECT_USERPWD_IN_URL = 100,

			/// <summary>This option has been deprecated; it has no effect.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_REQUEST_PRIORITY = 58,

			/// <summary>Retreives statistics for the request. For a list of the available statistics, see WINHTTP_REQUEST_STATS.</summary>
			[CorrespondingType(typeof(WINHTTP_REQUEST_STATS), CorrespondingAction.Get)]
			WINHTTP_OPTION_REQUEST_STATS = 146,

			/// <summary>Retreives timing information for the request. For a list of the available timings, see WINHTTP_REQUEST_TIMES.</summary>
			[CorrespondingType(typeof(WINHTTP_REQUEST_TIMES), CorrespondingAction.Get)]
			WINHTTP_OPTION_REQUEST_TIMES = 142,

			/// <summary>
			/// This option tells WinHttp to ignore "Content-Length" response headers, and continue receiving on a stream until the
			/// END_STREAM flag is received.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_REQUIRE_STREAM_END = 160,

			/// <summary>
			/// This option can be set on a WinHttp request handle before it has been sent. If set, WinHttp will use the caller-provided
			/// string as the hostname for DNS resolution.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Set)]
			WINHTTP_OPTION_RESOLUTION_HOSTNAME = 165,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds, to resolve a host name.
			/// The default timeout value is INFINITE. If a non-default value is specified, there is an overhead of one thread-creation per
			/// name resolution.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_RESOLVE_TIMEOUT = 2,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_RESOLVER_CACHE_CONFIG = 170,

			/// <summary>
			/// Sets an unsigned long integer value that specifies which secure protocols are acceptable. By default only SSL3 and TLS1 are
			/// enabled in Windows 7 and Windows 8. By default only SSL3, TLS1.0, TLS1.1, and TLS1.2 are enabled in Windows 8.1 and Windows 10.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_FLAG_SECURE_PROTOCOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_SECURE_PROTOCOLS = 84,

			/// <summary>
			/// Retrieves the certificate for a SSL/TLS server into the WINHTTP_CERTIFICATE_INFO structure. The application must free the
			/// lpszSubjectInfo and lpszIssuerInfo members with LocalFree.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_CERTIFICATE_INFO), CorrespondingAction.Get)]
			WINHTTP_OPTION_SECURITY_CERTIFICATE_STRUCT = 32,

			/// <summary>Sets or retrieves an unsigned long integer value that contains the security flags for a handle.</summary>
			[CorrespondingType(typeof(SECURITY_FLAG))]
			WINHTTP_OPTION_SECURITY_FLAGS = 31,

			/// <summary>Retreives the SChannel connection and cipher information for a request.</summary>
			[CorrespondingType(typeof(WINHTTP_SECURITY_INFO), CorrespondingAction.Get)]
			WINHTTP_OPTION_SECURITY_INFO = 151,

			/// <summary>
			/// Retrieves an unsigned long integer value that contains the cipher strength of the encryption key. A larger number indicates
			/// stronger cipher strength encryption.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			WINHTTP_OPTION_SECURITY_KEY_BITNESS = 36,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(WINHTTP_PROXY_SETTINGS))]
			WINHTTP_OPTION_SELECTED_PROXY_CONFIG_INFO = 182,

			/// <summary>
			/// Sets or retrieves an unsigned long integer value that contains the time-out value, in milliseconds, to send a request or
			/// write some data. If sending the request takes longer than the timeout, the send operation is canceled. The default timeout is
			/// 30 seconds.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_SEND_TIMEOUT = 5,

			/// <summary>
			/// Gets a pointer to SecPkgContext_Bindings structure that specifies a Channel Binding Token (CBT).
			/// <para>
			/// A Channel Binding Token is a property of a secure transport channel and is used to bind an authentication channel to the
			/// secure transport channel. This token can only be obtained by this option after an SSL connection has been established.
			/// </para>
			/// <note type="note">Passing this option and a null value for lpBuffer to WinHttpQueryOption will return
			/// ERROR_INSUFFICIENT_BUFFER and the required byte size for the buffer in the lpdwBufferLength parameter.This returned buffer
			/// size value can be passed in a subsequent call to query for the Channel Binding Token.These steps are necessary when handling
			/// WINHTTP_CALLBACK_STATUS_REQUEST if you want to modify request headers based on the Channel Binding Token. Note that Windows
			/// XP and Vista do not support modifying request headers during this callback.</note>
			/// </summary>
			[CorrespondingType(typeof(Secur32.SecPkgContext_Bindings), CorrespondingAction.Get)]
			WINHTTP_OPTION_SERVER_CBT = 108,

			/// <summary>
			/// Retrieves the server certification chain context. WINHTTP_OPTION_SERVER_CERT_CHAIN_CONTEXT can be passed to obtain a
			/// duplicated pointer to the CERT_CHAIN_CONTEXT for a server certificate chain received during a negotiated SSL connection. The
			/// client must call CertFreeCertificateContext on the returned PCCERT_CONTEXT pointer that is filled into the buffer.
			/// </summary>
			[CorrespondingType(typeof(Crypt32.PCCERT_CHAIN_CONTEXT), CorrespondingAction.Get)]
			WINHTTP_OPTION_SERVER_CERT_CHAIN_CONTEXT = 147,

			/// <summary>
			/// Retrieves the server certification context. WINHTTP_OPTION_SERVER_CERT_CONTEXT can be passed to obtain a duplicated pointer
			/// to the CERT CONTEXT for a server certificate received during a negotiated SSL connection. The client must call
			/// CertFreeCertificateContext on the returned PCCERT_CONTEXT pointer that is filled into the buffer.
			/// </summary>
			[CorrespondingType(typeof(Crypt32.PCCERT_CONTEXT), CorrespondingAction.Get)]
			WINHTTP_OPTION_SERVER_CERT_CONTEXT = 78,

			/// <summary>
			/// Gets the server Server Principal Name that WinHTTP supplied to SSPI during authentication. This string value can be passed to
			/// SspiPromptForCredentials after an authentication failure.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			WINHTTP_OPTION_SERVER_SPN_USED = 106,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_SET_GLOBAL_CALLBACK = 163,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_SET_TOKEN_BINDING = 166,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_SOURCE_ADDRESS = 156,

			/// <summary>
			/// Includes or removes the server port number when the SPN (service principal name) is built for Kerberos or Negotiate Kerberos authentication.
			/// </summary>
			[CorrespondingType(typeof(WINHTTP_SPN), CorrespondingAction.Set)]
			WINHTTP_OPTION_SPN = 96,

			/// <summary>
			/// This option can be queried on a WinHttp request handle, and will return the error code indicated by a RST_STREAM frame
			/// received on an HTTP stream.
			/// </summary>
			[CorrespondingType(typeof(Win32Error), CorrespondingAction.Get)]
			WINHTTP_OPTION_STREAM_ERROR_CODE = 159,

			/// <summary>Enables TCP Fast Open for the connection.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_TCP_FAST_OPEN = 153,

			/// <summary>
			/// This option can be set on a WinHttp session handle to enable TCP keep-alive behavior on the underlying socket. Takes a
			/// tcp_keepalive struct.
			/// </summary>
			[CorrespondingType(typeof(tcp_keepalive), CorrespondingAction.Set)]
			WINHTTP_OPTION_TCP_KEEPALIVE = 152,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_TCP_PRIORITY_HINT = 128,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(ulong), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_TCP_PRIORITY_STATUS = 177,

			/// <summary>Enables TLS False Start for the connection.</summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_TLS_FALSE_START = 154,

			/// <summary>
			/// This option can be set on a WinHttp session handle to control whether fallback to TLS 1.0 is allowed if there is a TLS
			/// handshake failure with a newer protocol version.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_TLS_PROTOCOL_INSECURE_FALLBACK = 158,

			/// <summary>Undocumented.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_TOKEN_BINDING_PUBLIC_KEY = 167,

			/// <summary>
			/// Takes an event that will be set when the last callback has completed for a particular session. This flag must be must be used
			/// on a session handle. The event cannot be closed until after it has been set by WinHTTP.
			/// </summary>
			[CorrespondingType(typeof(HEVENT), CorrespondingAction.Set)]
			WINHTTP_OPTION_UNLOAD_NOTIFY_EVENT = 99,

			/// <summary>This option is reserved for internal use and should not be called.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_UNSAFE_HEADER_PARSING = 110,

			/// <summary>Instructs the stack to start a WebSocket handshake process with WinHttpSendRequest. This option takes no parameters.</summary>
			[CorrespondingType(null, CorrespondingAction.Set)]
			WINHTTP_OPTION_UPGRADE_TO_WEB_SOCKET = 114,

			/// <summary>
			/// Retrieves a string value that contains the full URL of a downloaded resource. If the original URL contained any extra data,
			/// such as search strings or anchors, or if the call was redirected, the URL returned differs from the original. The application
			/// should pass in a buffer, sized in bytes, that is big enough to hold the returned URL in wide char.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.Get)]
			WINHTTP_OPTION_URL = 34,

			/// <summary>
			/// Takes a BOOL and can be set only a session handle. It will only propagate down to handles created from the session handle
			/// after the option has been set. If TRUE, this option causes as a last resort the use of global server credentials that were
			/// pushed down from WinInet. The default for this option is FALSE. This option requires registry key
			/// HKLM\Software\Microsoft\Windows\CurrentVersion\Internet Settings!ShareCredsWithWinHttp. This registry key is not present by
			/// default. When it is set, WinINet will send credentials down to WinHTTP. Whenever WinHttp gets an authentication challenge and
			/// if there are no credentials set on the current handle, it will use the credentials provided by WinINet.
			/// </summary>
			[CorrespondingType(typeof(BOOL), CorrespondingAction.Set)]
			WINHTTP_OPTION_USE_GLOBAL_SERVER_CREDENTIALS = 101,

			/// <summary>
			/// Sets or retrieves the user agent string on handles supplied by WinHttpOpen and used in subsequent WinHttpSendRequest
			/// functions, as long as it is not overridden by a header added by WinHttpAddRequestHeaders or WinHttpSendRequest. When
			/// retrieving a user agent, the application should pass in a buffer, sized in bytes, that is big enough to hold the returned URL
			/// in wide char. When setting the user agent, the buffer size is the length of the string, in characters, plus the NULL terminator.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_USER_AGENT = 41,

			/// <summary>Sets or retrieves a string that contains the user name.</summary>
			[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_USERNAME = 0x1000,

			/// <summary>
			/// Sets the time, in milliseconds, that WinHttpWebSocketClose should wait to complete the close handshake. The default is 10 seconds.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_WEB_SOCKET_CLOSE_TIMEOUT = 115,

			/// <summary>
			/// Sets the interval, in milliseconds, to send a keep-alive packet over the connection. The default interval is 30000 (30
			/// seconds). The minimum interval is 15000 (15 seconds). Using WinHttpSetOption to set a value lower than 15000 will return with
			/// ERROR_INVALID_PARAMETER. <note type="note">The default value for WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL is read from
			/// HKLM:\SOFTWARE\Microsoft\WebSocket\KeepaliveInterval. If a value is not set, the default value of 30000 will be used. It is
			/// not possible to have a lower keepalive interval than 15000 milliseconds.</note>
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_WEB_SOCKET_KEEPALIVE_INTERVAL = 116,

			/// <summary>Sets or retrieves a DWORD which specifies the receive buffer size to be used on WebSocket connections.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_WEB_SOCKET_RECEIVE_BUFFER_SIZE = 122,

			/// <summary>Sets or retrieves a DWORD which specifies the send buffer size to be used on WebSocket connections.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			WINHTTP_OPTION_WEB_SOCKET_SEND_BUFFER_SIZE = 123,

			/// <summary>
			/// Sets an unsigned long integer value that specifies the number of worker threads the thread pool should use for asynchronous
			/// completions. The default value of this option is zero, which specifies that the number of worker threads is equal to the
			/// number of CPUs on the system. This option can only be set on a NULL HINTERNET handle before an asynchronous operation has
			/// occurred. This option can only be set once.
			/// <para>Windows Server 2008 R2 and Windows 7: This flag is obsolete.</para>
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
			WINHTTP_OPTION_WORKER_THREAD_COUNT = 80,

			/// <summary>This option has been deprecated; it has no effect.</summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_OPTION_WRITE_BUFFER_SIZE = 13,
		}

		/// <summary>The behavior of WinHTTP regarding the handling of a 30x HTTP redirect status code.</summary>
		[PInvokeData("winhttp.h")]
		public enum WINHTTP_OPTION_REDIRECT_POLICY : uint
		{
			/// <summary>WINHTTP_OPTION_REDIRECT_POLICY_DISALLOW_HTTPS_TO_HTTP</summary>
			WINHTTP_OPTION_REDIRECT_POLICY_DEFAULT = WINHTTP_OPTION_REDIRECT_POLICY_DISALLOW_HTTPS_TO_HTTP,

			/// <summary>Redirects are never followed. The 30x status is returned to the application.</summary>
			WINHTTP_OPTION_REDIRECT_POLICY_NEVER = 0,

			/// <summary>
			/// All redirects are followed, except those that originate from a secure (https) URL to an unsecure (http) URL. This is the
			/// default setting.
			/// </summary>
			WINHTTP_OPTION_REDIRECT_POLICY_DISALLOW_HTTPS_TO_HTTP = 1,

			/// <summary>All redirects are followed automatically.</summary>
			WINHTTP_OPTION_REDIRECT_POLICY_ALWAYS = 2,
		}

		/// <summary>Bitmask of acceptable advanced HTTP versions.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_PROTOCOL_FLAG : uint
		{
			/// <summary>Restricts the request to HTTP/1.1 and prior.</summary>
			None = 0,

			/// <summary>Enables HTTP/2 for the request.</summary>
			WINHTTP_PROTOCOL_FLAG_HTTP2 = 0x1,

			/// <summary>Enables HTTP/3 for the request.</summary>
			WINHTTP_PROTOCOL_FLAG_HTTP3 = 0x2,
		}

		/// <summary>
		/// <para>These attributes and modifiers are used by WinHttpQueryHeaders.</para>
		/// <para>
		/// The attribute flags are used by WinHttpQueryHeaders to indicate what information to retrieve. Most of the attribute flags map
		/// directly to a specific HTTP header. There are also some special flags, such as WINHTTP_QUERY_RAW_HEADERS, that are not related to
		/// a specific header.
		/// </para>
		/// <para>
		/// The modifier flags are used in conjunction with an attribute flag to modify the request. Modifier flags either modify the format
		/// of the data returned or indicate where the WinHttpQueryHeaders function should search for the information.
		/// </para>
		/// </summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_QUERY : uint
		{
			/// <summary>Retrieves the acceptable media types for the response.</summary>
			WINHTTP_QUERY_ACCEPT = 24,

			/// <summary>Retrieves the acceptable character sets for the response.</summary>
			WINHTTP_QUERY_ACCEPT_CHARSET = 25,

			/// <summary>Retrieves the acceptable content-coding values for the response.</summary>
			WINHTTP_QUERY_ACCEPT_ENCODING = 26,

			/// <summary>Retrieves the acceptable natural languages for the response.</summary>
			WINHTTP_QUERY_ACCEPT_LANGUAGE = 27,

			/// <summary>Retrieves the types of range requests that are accepted for a resource.</summary>
			WINHTTP_QUERY_ACCEPT_RANGES = 42,

			/// <summary>
			/// Retrieves the Age response-header field, which contains the sender's estimate of the amount of time since the response was
			/// generated at the originating server.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_QUERY_AGE = 48,

			/// <summary>Receives the HTTP verbs supported by the server.</summary>
			WINHTTP_QUERY_ALLOW = 7,

			/// <summary>Retrieves the Authentication-Info header.</summary>
			WINHTTP_QUERY_AUTHENTICATION_INFO = 76,

			/// <summary>Retrieves the authorization credentials used for a request.</summary>
			WINHTTP_QUERY_AUTHORIZATION = 28,

			/// <summary>Retrieves the cache control directives.</summary>
			WINHTTP_QUERY_CACHE_CONTROL = 49,

			/// <summary>
			/// Retrieves any options that are specified for a particular connection and must not be communicated by proxies over further connections.
			/// </summary>
			WINHTTP_QUERY_CONNECTION = 23,

			/// <summary>Retrieves the base Uniform Resource Identifier (URI) to resolve relative URLs within the entity.</summary>
			WINHTTP_QUERY_CONTENT_BASE = 50,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_CONTENT_DESCRIPTION = 4,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_CONTENT_DISPOSITION = 47,

			/// <summary>Retrieves additional content coding that has been applied to the entire resource.</summary>
			WINHTTP_QUERY_CONTENT_ENCODING = 29,

			/// <summary>Retrieves the content identification.</summary>
			WINHTTP_QUERY_CONTENT_ID = 3,

			/// <summary>Retrieves the language that the content is written in.</summary>
			WINHTTP_QUERY_CONTENT_LANGUAGE = 6,

			/// <summary>Retrieves the size of the resource, in bytes.</summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_QUERY_CONTENT_LENGTH = 5,

			/// <summary>Retrieves the resource location for the entity enclosed in the message.</summary>
			WINHTTP_QUERY_CONTENT_LOCATION = 51,

			/// <summary>
			/// Retrieves an MD5 digest of the entity body for the purpose of providing an end-to-end message integrity check for the entity
			/// body. For more information, see RFC 1864.
			/// </summary>
			WINHTTP_QUERY_CONTENT_MD5 = 52,

			/// <summary>
			/// Retrieves the location in the full entity body where the partial entity body should be inserted and the total size of the
			/// full entity body.
			/// </summary>
			WINHTTP_QUERY_CONTENT_RANGE = 53,

			/// <summary>
			/// Retrieves an encoding transformation applicable to an entity-body. It may already have been applied, may need to be applied,
			/// or may be optionally applicable.
			/// </summary>
			WINHTTP_QUERY_CONTENT_TRANSFER_ENCODING = 2,

			/// <summary>Receives the content type of the resource, such as text or html.</summary>
			WINHTTP_QUERY_CONTENT_TYPE = 1,

			/// <summary>Retrieves any cookies associated with the request.</summary>
			WINHTTP_QUERY_COOKIE = 44,

			/// <summary>Not supported.</summary>
			WINHTTP_QUERY_COST = 15,

			/// <summary>
			/// Causes WinHttpQueryHeaders to search for the header name specified in the pwszName parameter and store the header information
			/// in lpBuffer. An application can use WINHTTP_OPTION_RECEIVE_RESPONSE_TIMEOUT to limit the maximum time this query waits for
			/// all headers to be received.
			/// </summary>
			WINHTTP_QUERY_CUSTOM = 65535,

			/// <summary>Receives the date and time at which the message was originated.</summary>
			[CorrespondingType(typeof(SYSTEMTIME))]
			WINHTTP_QUERY_DATE = 9,

			/// <summary>Not supported.</summary>
			WINHTTP_QUERY_DERIVED_FROM = 14,

			/// <summary>Retrieves the entity tag for the associated entity.</summary>
			WINHTTP_QUERY_ETAG = 54,

			/// <summary>Retrieves the Expect header, which indicates whether the client application should expect 100 series responses.</summary>
			WINHTTP_QUERY_EXPECT = 68,

			/// <summary>Receives the date and time after which the resource should be considered outdated.</summary>
			[CorrespondingType(typeof(SYSTEMTIME))]
			WINHTTP_QUERY_EXPIRES = 10,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_FORWARDED = 30,

			/// <summary>Retrieves the e-mail address for the user who controls the requesting user agent if the From header is given.</summary>
			WINHTTP_QUERY_FROM = 31,

			/// <summary>Retrieves the Internet host and port number of the resource being requested.</summary>
			WINHTTP_QUERY_HOST = 55,

			/// <summary>Retrieves the contents of the If-Match request-header field.</summary>
			WINHTTP_QUERY_IF_MATCH = 56,

			/// <summary>Retrieves the contents of the If-Modified-Since header.</summary>
			[CorrespondingType(typeof(SYSTEMTIME))]
			WINHTTP_QUERY_IF_MODIFIED_SINCE = 32,

			/// <summary>Retrieves the contents of the If-None-Match request-header field.</summary>
			WINHTTP_QUERY_IF_NONE_MATCH = 57,

			/// <summary>
			/// Retrieves the contents of the If-Range request-header field. This header allows the client application to check if the entity
			/// related to a partial copy of the entity in the client application's cache has not been updated. If the entity has not been
			/// updated, send the parts that the client application is missing. If the entity has been updated, send the entire updated entity.
			/// </summary>
			WINHTTP_QUERY_IF_RANGE = 58,

			/// <summary>Retrieves the contents of the If-Unmodified-Since request-header field.</summary>
			[CorrespondingType(typeof(SYSTEMTIME))]
			WINHTTP_QUERY_IF_UNMODIFIED_SINCE = 59,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_LINK = 11,

			/// <summary>Receives the date and time at which the resource was last modified. The date and time are determined by the server.</summary>
			[CorrespondingType(typeof(SYSTEMTIME))]
			WINHTTP_QUERY_LAST_MODIFIED = 16,

			/// <summary>Retrieves the absolute URI used in a Location response-header.</summary>
			WINHTTP_QUERY_LOCATION = 33,

			/// <summary>Indicates the maximum value of a WINHTTP_QUERY_* value. Not a query flag.</summary>
			WINHTTP_QUERY_MAX = 78,

			/// <summary>Retrieves the number of proxies or gateways that can forward the request to the next inbound server.</summary>
			[CorrespondingType(typeof(uint))]
			WINHTTP_QUERY_MAX_FORWARDS = 60,

			/// <summary>Not supported.</summary>
			WINHTTP_QUERY_MESSAGE_ID = 12,

			/// <summary>
			/// Receives the version of the Multipurpose Internet Mail Extensions (MIME) protocol that was used to construct the message.
			/// </summary>
			WINHTTP_QUERY_MIME_VERSION = 0,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_ORIG_URI = 34,

			/// <summary>
			/// Receives the implementation-specific directives that might apply to any recipient along the request/response chain.
			/// </summary>
			WINHTTP_QUERY_PRAGMA = 17,

			/// <summary>Retrieves the authentication scheme and realm returned by the proxy.</summary>
			WINHTTP_QUERY_PROXY_AUTHENTICATE = 41,

			/// <summary>
			/// Retrieves the header that is used to identify the user to a proxy that requires authentication. This header can only be
			/// retrieved before the request is sent to the server.
			/// </summary>
			WINHTTP_QUERY_PROXY_AUTHORIZATION = 61,

			/// <summary>Retrieves the Proxy-Connection header.</summary>
			WINHTTP_QUERY_PROXY_CONNECTION = 69,

			/// <summary>Retrieves the Proxy-Support header.</summary>
			WINHTTP_QUERY_PROXY_SUPPORT = 75,

			/// <summary>Receives HTTP verbs available at this server.</summary>
			WINHTTP_QUERY_PUBLIC = 8,

			/// <summary>Retrieves the byte range of an entity.</summary>
			WINHTTP_QUERY_RANGE = 62,

			/// <summary>
			/// Receives all the headers returned by the server. Each header is terminated by "\0". An additional "\0" terminates the list of headers.
			/// </summary>
			[CorrespondingType(typeof(string[]))]
			WINHTTP_QUERY_RAW_HEADERS = 21,

			/// <summary>
			/// Receives all the headers returned by the server. Each header is separated by a carriage return/line feed (CR/LF) sequence.
			/// </summary>
			[CorrespondingType(typeof(string))]
			WINHTTP_QUERY_RAW_HEADERS_CRLF = 22,

			/// <summary>Receives the URI of the resource where the requested URI was obtained.</summary>
			[CorrespondingType(typeof(string))]
			WINHTTP_QUERY_REFERER = 35,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_REFRESH = 46,

			/// <summary>Receives the HTTP verb that is being used in the request, typically GET or POST.</summary>
			[CorrespondingType(typeof(string))]
			WINHTTP_QUERY_REQUEST_METHOD = 45,

			/// <summary>Retrieves the amount of time the service is expected to be unavailable.</summary>
			WINHTTP_QUERY_RETRY_AFTER = 36,

			/// <summary>Retrieves information about the software used by the originating server to handle the request.</summary>
			WINHTTP_QUERY_SERVER = 37,

			/// <summary>Receives the value of the cookie set for the request.</summary>
			WINHTTP_QUERY_SET_COOKIE = 43,

			/// <summary>Receives the status code returned by the server. For a list of possible values, see HTTP Status Codes.</summary>
			[CorrespondingType(typeof(HTTP_STATUS))]
			WINHTTP_QUERY_STATUS_CODE = 19,

			/// <summary>Receives additional text returned by the server on the response line.</summary>
			WINHTTP_QUERY_STATUS_TEXT = 20,

			/// <summary>Obsolete. Maintained for legacy application compatibility.</summary>
			WINHTTP_QUERY_TITLE = 38,

			/// <summary>
			/// Retrieves the type of transformation that has been applied to the message body so it can be safely transferred between the
			/// sender and recipient.
			/// </summary>
			WINHTTP_QUERY_TRANSFER_ENCODING = 63,

			/// <summary>Retrieves the Unless-Modified-Since header.</summary>
			WINHTTP_QUERY_UNLESS_MODIFIED_SINCE = 70,

			/// <summary>Retrieves the additional communication protocols that are supported by the server.</summary>
			WINHTTP_QUERY_UPGRADE = 64,

			/// <summary>Receives some or all of the URI by which the Request-URI resource can be identified.</summary>
			WINHTTP_QUERY_URI = 13,

			/// <summary>Retrieves information about the user agent that made the request.</summary>
			WINHTTP_QUERY_USER_AGENT = 39,

			/// <summary>
			/// Retrieves the header that indicates that the entity was selected from a number of available representations of the response
			/// using server-driven negotiation.
			/// </summary>
			WINHTTP_QUERY_VARY = 65,

			/// <summary>Retrieves the HTTP version that is present in the status line.</summary>
			WINHTTP_QUERY_VERSION = 18,

			/// <summary>
			/// Retrieves the intermediate protocols and recipients between the user agent and the server on requests, and between the origin
			/// server and the client on responses.
			/// </summary>
			WINHTTP_QUERY_VIA = 66,

			/// <summary>
			/// Retrieves additional information about the status of a response that might not be reflected by the response status code.
			/// </summary>
			WINHTTP_QUERY_WARNING = 67,

			/// <summary>Retrieves the authentication scheme and realm returned by the server.</summary>
			WINHTTP_QUERY_WWW_AUTHENTICATE = 40,

			/// <summary>Returns the data as a 32-bit number for headers whose value is a number, such as the status code.</summary>
			WINHTTP_QUERY_FLAG_NUMBER = 0x20000000,

			/// <summary>Queries request headers only.</summary>
			WINHTTP_QUERY_FLAG_REQUEST_HEADERS = 0x80000000,

			/// <summary>
			/// Returns the header value as a SYSTEMTIME structure, which does not require the application to parse the data. Use for headers
			/// whose value is a date/time string, such as "Last-Modified-Time".
			/// </summary>
			WINHTTP_QUERY_FLAG_SYSTEMTIME = 0x40000000,

			/// <summary>
			/// Queries response trailers. Prior to querying response trailers, you must call WinHttpReadData until it returns 0 bytes read.
			/// </summary>
			WINHTTP_QUERY_FLAG_TRAILERS = 0x02000000,

			/// <summary>
			/// By default, WinHttpQueryHeaders performs a Unicode conversion before returning the header that was queried. If this flag is
			/// set, WinHttp returns the header to the caller without performing this conversion.
			/// </summary>
			WINHTTP_QUERY_FLAG_WIRE_ENCODING = 0x01000000,

			/// <summary/>
			WINHTTP_QUERY_EX_ALL_HEADERS = WINHTTP_QUERY_RAW_HEADERS,

			/// <summary>Returns the data as a 64-bit number for headers whose value is a number, such as the status code.</summary>
			WINHTTP_QUERY_FLAG_NUMBER64 = 0x08000000,
		}

		/// <summary>Flags for WinHttpQueryConnectionGroup.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpQueryConnectionGroup")]
		[Flags]
		public enum WINHTTP_QUERY_CONNECTION_GROUP_FLAG : ulong
		{
			/// <summary>Indicate that you want non-HTTPS connections (see hInternet).</summary>
			WINHTTP_QUERY_CONNECTION_GROUP_FLAG_INSECURE = 1
		}

		/// <summary>Flags for WinHttpReadDataEx.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_READ_DATA_EX_FLAG : ulong
		{
			/// <summary>
			/// WinHttp won't complete the call to <c>WinHttpReadDataEx</c> until the provided data buffer has been filled, or the response
			/// is complete.
			/// </summary>
			WINHTTP_READ_DATA_EX_FLAG_FILL_BUFFER = 0x0000000000000001
		}

		/// <summary>The <c>WINHTTP_REQUEST_STAT_ENTRY</c> enumeration lists the available types of request statistics.</summary>
		/// <remarks>
		/// This structure is used with WinHttpQueryOption to retrieve statistics for a request by specifying the
		/// <c>WINHTTP_OPTION_REQUEST_STATS</c> flag.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ne-winhttp-winhttp_request_stat_entry typedef enum
		// _WINHTTP_REQUEST_STAT_ENTRY { WinHttpConnectFailureCount = 0, WinHttpProxyFailureCount, WinHttpTlsHandshakeClientLeg1Size,
		// WinHttpTlsHandshakeServerLeg1Size, WinHttpTlsHandshakeClientLeg2Size, WinHttpTlsHandshakeServerLeg2Size,
		// WinHttpRequestHeadersSize, WinHttpRequestHeadersCompressedSize, WinHttpResponseHeadersSize, WinHttpResponseHeadersCompressedSize,
		// WinHttpResponseBodySize, WinHttpResponseBodyCompressedSize, WinHttpProxyTlsHandshakeClientLeg1Size,
		// WinHttpProxyTlsHandshakeServerLeg1Size, WinHttpProxyTlsHandshakeClientLeg2Size, WinHttpProxyTlsHandshakeServerLeg2Size,
		// WinHttpRequestStatLast, WinHttpRequestStatMax = 32 } WINHTTP_REQUEST_STAT_ENTRY;
		[PInvokeData("winhttp.h", MSDNShortId = "NE:winhttp._WINHTTP_REQUEST_STAT_ENTRY")]
		public enum WINHTTP_REQUEST_STAT_ENTRY : uint
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>The number of connection failures during connection establishment.</para>
			/// </summary>
			WinHttpConnectFailureCount = 0,

			/// <summary>The number of proxy connection failures during connection establishment.</summary>
			WinHttpProxyFailureCount,

			/// <summary>The size of the client data for the first leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg1Size,

			/// <summary>The size of the server data for the first leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeServerLeg1Size,

			/// <summary>The size of the client data for the second leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg2Size,

			/// <summary>The size of the server data for the second leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeServerLeg2Size,

			/// <summary>The size of the request headers.</summary>
			WinHttpRequestHeadersSize,

			/// <summary>The compressed size of the request headers.</summary>
			WinHttpRequestHeadersCompressedSize,

			/// <summary>The size of the response headers.</summary>
			WinHttpResponseHeadersSize,

			/// <summary>The compressed size of the response headers.</summary>
			WinHttpResponseHeadersCompressedSize,

			/// <summary>The size of the response body.</summary>
			WinHttpResponseBodySize,

			/// <summary>The compressed size of the response body.</summary>
			WinHttpResponseBodyCompressedSize,

			/// <summary>The size of the client data for the first leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg1Size,

			/// <summary>The size of the server data for the first leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeServerLeg1Size,

			/// <summary>The size of the client data for the second leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg2Size,

			/// <summary>The size of the server data for the second leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeServerLeg2Size,

			/// <summary>Marker for the end of the list of available statistics.</summary>
			WinHttpRequestStatLast,

			/// <summary>
			/// <para>Value:</para>
			/// <para>32</para>
			/// <para>The maximum number of statistics available.</para>
			/// </summary>
			WinHttpRequestStatMax = 32,
		}

		/// <summary>Flags containing details on how the request was made.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_REQUEST_STAT_FLAG : ulong
		{
			/// <summary>TCP Fast Open occurred.</summary>
			WINHTTP_REQUEST_STAT_FLAG_TCP_FAST_OPEN = 0x00000001,

			/// <summary>TLS Session Resumption occurred.</summary>
			WINHTTP_REQUEST_STAT_FLAG_TLS_SESSION_RESUMPTION = 0x00000002,

			/// <summary>TLS False Start occurred.</summary>
			WINHTTP_REQUEST_STAT_FLAG_TLS_FALSE_START = 0x00000004,

			/// <summary>TLS Session Resumption occurred for the proxy connection.</summary>
			WINHTTP_REQUEST_STAT_FLAG_PROXY_TLS_SESSION_RESUMPTION = 0x00000008,

			/// <summary>TLS False Start occurred for the proxy connection.</summary>
			WINHTTP_REQUEST_STAT_FLAG_PROXY_TLS_FALSE_START = 0x00000010,

			/// <summary>This is the first request on the connection.</summary>
			WINHTTP_REQUEST_STAT_FLAG_FIRST_REQUEST = 0x00000020,
		}

		/// <summary>The <c>WINHTTP_REQUEST_TIME_ENTRY</c> enumeration lists the available types of request timing information.</summary>
		/// <remarks>
		/// This structure is used with WinHttpQueryOption to retrieve timing information for a request by specifying the
		/// <c>WINHTTP_OPTION_REQUEST_TIMES</c> flag.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ne-winhttp-winhttp_request_time_entry typedef enum
		// _WINHTTP_REQUEST_TIME_ENTRY { WinHttpProxyDetectionStart = 0, WinHttpProxyDetectionEnd, WinHttpConnectionAcquireStart,
		// WinHttpConnectionAcquireWaitEnd, WinHttpConnectionAcquireEnd, WinHttpNameResolutionStart, WinHttpNameResolutionEnd,
		// WinHttpConnectionEstablishmentStart, WinHttpConnectionEstablishmentEnd, WinHttpTlsHandshakeClientLeg1Start,
		// WinHttpTlsHandshakeClientLeg1End, WinHttpTlsHandshakeClientLeg2Start, WinHttpTlsHandshakeClientLeg2End,
		// WinHttpTlsHandshakeClientLeg3Start, WinHttpTlsHandshakeClientLeg3End, WinHttpStreamWaitStart, WinHttpStreamWaitEnd,
		// WinHttpSendRequestStart, WinHttpSendRequestHeadersCompressionStart, WinHttpSendRequestHeadersCompressionEnd,
		// WinHttpSendRequestHeadersEnd, WinHttpSendRequestEnd, WinHttpReceiveResponseStart, WinHttpReceiveResponseHeadersDecompressionStart,
		// WinHttpReceiveResponseHeadersDecompressionEnd, WinHttpReceiveResponseHeadersEnd, WinHttpReceiveResponseBodyDecompressionDelta,
		// WinHttpReceiveResponseEnd, WinHttpProxyTunnelStart, WinHttpProxyTunnelEnd, WinHttpProxyTlsHandshakeClientLeg1Start,
		// WinHttpProxyTlsHandshakeClientLeg1End, WinHttpProxyTlsHandshakeClientLeg2Start, WinHttpProxyTlsHandshakeClientLeg2End,
		// WinHttpProxyTlsHandshakeClientLeg3Start, WinHttpProxyTlsHandshakeClientLeg3End, WinHttpRequestTimeLast, WinHttpRequestTimeMax = 64
		// } WINHTTP_REQUEST_TIME_ENTRY;
		[PInvokeData("winhttp.h", MSDNShortId = "NE:winhttp._WINHTTP_REQUEST_TIME_ENTRY")]
		public enum WINHTTP_REQUEST_TIME_ENTRY : uint
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>Start of proxy detection.</para>
			/// </summary>
			WinHttpProxyDetectionStart = 0,

			/// <summary>End of proxy detection.</summary>
			WinHttpProxyDetectionEnd,

			/// <summary>Start of connection acquisition.</summary>
			WinHttpConnectionAcquireStart,

			/// <summary>End waiting for an available connection.</summary>
			WinHttpConnectionAcquireWaitEnd,

			/// <summary>End of connection acquisition.</summary>
			WinHttpConnectionAcquireEnd,

			/// <summary>Start of name resolution.</summary>
			WinHttpNameResolutionStart,

			/// <summary>End of name resolution.</summary>
			WinHttpNameResolutionEnd,

			/// <summary>Start of connection establishment.</summary>
			WinHttpConnectionEstablishmentStart,

			/// <summary>End of connection establishment.</summary>
			WinHttpConnectionEstablishmentEnd,

			/// <summary>Start of the first leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg1Start,

			/// <summary>End of the first leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg1End,

			/// <summary>Start of the second leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg2Start,

			/// <summary>End of the second leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg2End,

			/// <summary>Start of the third leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg3Start,

			/// <summary>End of the third leg of the TLS handshake.</summary>
			WinHttpTlsHandshakeClientLeg3End,

			/// <summary>Start waiting for an available stream.</summary>
			WinHttpStreamWaitStart,

			/// <summary>End waiting for an available stream.</summary>
			WinHttpStreamWaitEnd,

			/// <summary>Start sending a request.</summary>
			WinHttpSendRequestStart,

			/// <summary>Start of request header compression.</summary>
			WinHttpSendRequestHeadersCompressionStart,

			/// <summary>End of request header compression.</summary>
			WinHttpSendRequestHeadersCompressionEnd,

			/// <summary>End sending request headers.</summary>
			WinHttpSendRequestHeadersEnd,

			/// <summary>End sending a request.</summary>
			WinHttpSendRequestEnd,

			/// <summary>Start receiving a response.</summary>
			WinHttpReceiveResponseStart,

			/// <summary>Start of response header decompression.</summary>
			WinHttpReceiveResponseHeadersDecompressionStart,

			/// <summary>End of response header decompression.</summary>
			WinHttpReceiveResponseHeadersDecompressionEnd,

			/// <summary>End receiving response headers.</summary>
			WinHttpReceiveResponseHeadersEnd,

			/// <summary>Delta between start and end times for response body decompression.</summary>
			WinHttpReceiveResponseBodyDecompressionDelta,

			/// <summary>End receiving a response.</summary>
			WinHttpReceiveResponseEnd,

			/// <summary>Start establishing a proxy tunnel.</summary>
			WinHttpProxyTunnelStart,

			/// <summary>End establishing a proxy tunnel.</summary>
			WinHttpProxyTunnelEnd,

			/// <summary>Start of the first leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg1Start,

			/// <summary>End of the first leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg1End,

			/// <summary>Start of the second leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg2Start,

			/// <summary>End of the second leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg2End,

			/// <summary>Start of the third leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg3Start,

			/// <summary>End of the third leg of the proxy TLS handshake.</summary>
			WinHttpProxyTlsHandshakeClientLeg3End,

			/// <summary>Marker for the end of the list of available timings.</summary>
			WinHttpRequestTimeLast,

			/// <summary>
			/// <para>Value:</para>
			/// <para>64</para>
			/// <para>The maximum number of timings available.</para>
			/// </summary>
			WinHttpRequestTimeMax = 64,
		}

		/// <summary>A set of flags that affects the reset operation.</summary>
		[PInvokeData("winhttp.h", MSDNShortId = "NF:winhttp.WinHttpResetAutoProxy")]
		[Flags]
		public enum WINHTTP_RESET : uint
		{
			/// <summary>Forces a flush and retry of non-persistent proxy information on the current network.</summary>
			WINHTTP_RESET_STATE = 0x00000001,

			/// <summary>Flush the PAD information for the current network.</summary>
			WINHTTP_RESET_SWPAD_CURRENT_NETWORK = 0x00000002,

			/// <summary>Flush the PAD information for all networks.</summary>
			WINHTTP_RESET_SWPAD_ALL = 0x00000004,

			/// <summary>Flush the persistent HTTP cache of proxy scripts.</summary>
			WINHTTP_RESET_SCRIPT_CACHE = 0x00000008,

			/// <summary>Forces a flush and retry of all proxy information on the current network.</summary>
			WINHTTP_RESET_ALL = 0x0000FFFF,

			/// <summary>Flush the current proxy information and notify that the network changed.</summary>
			WINHTTP_RESET_NOTIFY_NETWORK_CHANGED = 0x00010000,

			/// <summary>
			/// Act on the autoproxy service instead of the current process. Applications that use the WinHttpGetProxyForUrl function to
			/// purge in-process caching should close the <c>hInternet</c> handle and open a new handle for future calls.
			/// </summary>
			WINHTTP_RESET_OUT_OF_PROC = 0x00020000,

			/// <summary/>
			WINHTTP_RESET_DISCARD_RESOLVERS = 0x00040000,
		}

		/// <summary>Includes or removes the server port number when the SPN (service principal name) is built for Kerberos or Negotiate Kerberos authentication.</summary>
		[PInvokeData("winhttp.h")]
		[Flags]
		public enum WINHTTP_SPN : uint
		{
			/// <summary>Removes the server port number.</summary>
			WINHTTP_DISABLE_SPN_SERVER_PORT = 0x00000000,

			/// <summary>Includes the server port number.</summary>
			WINHTTP_ENABLE_SPN_SERVER_PORT = 0x00000001,
		}
		/// <summary>The <c>WINHTTP_WEB_SOCKET_BUFFER_TYPE</c> enumeration includes types of WebSocket buffers.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ne-winhttp-winhttp_web_socket_buffer_type typedef enum
		// _WINHTTP_WEB_SOCKET_BUFFER_TYPE { WINHTTP_WEB_SOCKET_BINARY_MESSAGE_BUFFER_TYPE = 0,
		// WINHTTP_WEB_SOCKET_BINARY_FRAGMENT_BUFFER_TYPE = 1, WINHTTP_WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE = 2,
		// WINHTTP_WEB_SOCKET_UTF8_FRAGMENT_BUFFER_TYPE = 3, WINHTTP_WEB_SOCKET_CLOSE_BUFFER_TYPE = 4 } WINHTTP_WEB_SOCKET_BUFFER_TYPE;
		[PInvokeData("winhttp.h", MSDNShortId = "NE:winhttp._WINHTTP_WEB_SOCKET_BUFFER_TYPE")]
		public enum WINHTTP_WEB_SOCKET_BUFFER_TYPE
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>Buffer contains either the entire binary message or the last part of it.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_BINARY_MESSAGE_BUFFER_TYPE,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1</para>
			/// <para>Buffer contains only part of a binary message.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_BINARY_FRAGMENT_BUFFER_TYPE,

			/// <summary>
			/// <para>Value:</para>
			/// <para>2</para>
			/// <para>Buffer contains either the entire UTF-8 message or the last part of it.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_UTF8_MESSAGE_BUFFER_TYPE,

			/// <summary>
			/// <para>Value:</para>
			/// <para>3</para>
			/// <para>Buffer contains only part of a UTF-8 message.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_UTF8_FRAGMENT_BUFFER_TYPE,

			/// <summary>
			/// <para>Value:</para>
			/// <para>4</para>
			/// <para>The server sent a close frame.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_CLOSE_BUFFER_TYPE,
		}

		/// <summary>The <c>WINHTTP_WEB_SOCKET_CLOSE_STATUS</c> enumeration includes the status of a WebSocket close operation.</summary>
		/// <remarks><c>WINHTTP_WEB_SOCKET_CLOSE_STATUS</c> is used by WinHttpWebSocketClose, WinHttpWebSocketShutdown, and WinHttpWebSocketQueryCloseStatus.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ne-winhttp-winhttp_web_socket_close_status typedef enum
		// _WINHTTP_WEB_SOCKET_CLOSE_STATUS { WINHTTP_WEB_SOCKET_SUCCESS_CLOSE_STATUS = 1000,
		// WINHTTP_WEB_SOCKET_ENDPOINT_TERMINATED_CLOSE_STATUS = 1001, WINHTTP_WEB_SOCKET_PROTOCOL_ERROR_CLOSE_STATUS = 1002,
		// WINHTTP_WEB_SOCKET_INVALID_DATA_TYPE_CLOSE_STATUS = 1003, WINHTTP_WEB_SOCKET_EMPTY_CLOSE_STATUS = 1005,
		// WINHTTP_WEB_SOCKET_ABORTED_CLOSE_STATUS = 1006, WINHTTP_WEB_SOCKET_INVALID_PAYLOAD_CLOSE_STATUS = 1007,
		// WINHTTP_WEB_SOCKET_POLICY_VIOLATION_CLOSE_STATUS = 1008, WINHTTP_WEB_SOCKET_MESSAGE_TOO_BIG_CLOSE_STATUS = 1009,
		// WINHTTP_WEB_SOCKET_UNSUPPORTED_EXTENSIONS_CLOSE_STATUS = 1010, WINHTTP_WEB_SOCKET_SERVER_ERROR_CLOSE_STATUS = 1011,
		// WINHTTP_WEB_SOCKET_SECURE_HANDSHAKE_ERROR_CLOSE_STATUS = 1015 } WINHTTP_WEB_SOCKET_CLOSE_STATUS;
		[PInvokeData("winhttp.h", MSDNShortId = "NE:winhttp._WINHTTP_WEB_SOCKET_CLOSE_STATUS")]
		public enum WINHTTP_WEB_SOCKET_CLOSE_STATUS : ushort
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>1000</para>
			/// <para>The connection closed successfully.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_SUCCESS_CLOSE_STATUS = 1000,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1001</para>
			/// <para>The peer is going away and terminating the connection.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_ENDPOINT_TERMINATED_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1002</para>
			/// <para>A protocol error occurred.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_PROTOCOL_ERROR_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1003</para>
			/// <para>Invalid data received by the peer.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_INVALID_DATA_TYPE_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1005</para>
			/// <para>The close message was empty.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_EMPTY_CLOSE_STATUS = 1005,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1006</para>
			/// <para>The connection was aborted.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_ABORTED_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1007</para>
			/// <para>The payload was invalid.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_INVALID_PAYLOAD_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1008</para>
			/// <para>The message violates an endpoint's policy.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_POLICY_VIOLATION_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1009</para>
			/// <para>The message sent was too large to process.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_MESSAGE_TOO_BIG_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1010</para>
			/// <para>
			/// A client endpoint expected the server to negotiate one or more extensions, but the server didn't return them in the response
			/// message of the WebSocket handshake.
			/// </para>
			/// </summary>
			WINHTTP_WEB_SOCKET_UNSUPPORTED_EXTENSIONS_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1011</para>
			/// <para>An unexpected condition prevented the server from</para>
			/// <para>fulfilling the request.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_SERVER_ERROR_CLOSE_STATUS,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1015</para>
			/// <para>The TLS handshake could not be completed.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_SECURE_HANDSHAKE_ERROR_CLOSE_STATUS = 1015,
		}

		/// <summary>The <c>WINHTTP_WEB_SOCKET_OPERATION</c> enumeration includes the WebSocket operation type.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winhttp/ne-winhttp-winhttp_web_socket_operation typedef enum
		// _WINHTTP_WEB_SOCKET_OPERATION { WINHTTP_WEB_SOCKET_SEND_OPERATION = 0, WINHTTP_WEB_SOCKET_RECEIVE_OPERATION = 1,
		// WINHTTP_WEB_SOCKET_CLOSE_OPERATION = 2, WINHTTP_WEB_SOCKET_SHUTDOWN_OPERATION = 3 } WINHTTP_WEB_SOCKET_OPERATION;
		[PInvokeData("winhttp.h", MSDNShortId = "NE:winhttp._WINHTTP_WEB_SOCKET_OPERATION")]
		public enum WINHTTP_WEB_SOCKET_OPERATION
		{
			/// <summary>
			/// <para>Value:</para>
			/// <para>0</para>
			/// <para>A</para>
			/// <para>WinHttpWebSocketSend</para>
			/// <para>operation.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_SEND_OPERATION,

			/// <summary>
			/// <para>Value:</para>
			/// <para>1</para>
			/// <para>A</para>
			/// <para>WinHttpWebSocketReceive</para>
			/// <para>operation.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_RECEIVE_OPERATION,

			/// <summary>
			/// <para>Value:</para>
			/// <para>2</para>
			/// <para>A</para>
			/// <para>WinHttpWebSocketClose</para>
			/// <para>operation.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_CLOSE_OPERATION,

			/// <summary>
			/// <para>Value:</para>
			/// <para>3</para>
			/// <para>A</para>
			/// <para>WinHttpWebSocketShutdown</para>
			/// <para>operation.</para>
			/// </summary>
			WINHTTP_WEB_SOCKET_SHUTDOWN_OPERATION,
		}

		/// <summary>The <c>WinHttpRequestAutoLogonPolicy</c> enumeration includes possible settings for the Automatic Logon Policy.</summary>
		/// <remarks>
		/// <para>To set the automatic logon policy, call the <c>SetAutoLogonPolicy</c> method and specify one of the preceding constants.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHTTP start page.</para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winhttp/winhttprequestautologonpolicy typedef enum WinHttpRequestAutoLogonPolicy {
		// AutoLogonPolicy_Always = 0, AutoLogonPolicy_OnlyIfBypassProxy = 1, AutoLogonPolicy_Never = 2 } WinHttpRequestAutoLogonPolicy;
		[PInvokeData("winhttp.h")]
		public enum WinHttpRequestAutoLogonPolicy
		{
			/// <summary>An authenticated log on, using the default credentials, is performed for all requests.</summary>
			AutoLogonPolicy_Always,

			/// <summary>
			/// An authenticated log on, using the default credentials, is performed only for requests on the local intranet. The local
			/// intranet is considered to be any server on the proxy bypass list in the current proxy configuration.
			/// </summary>
			AutoLogonPolicy_OnlyIfBypassProxy,

			/// <summary>Authentication is not used automatically.</summary>
			AutoLogonPolicy_Never,
		}

		/// <summary>
		/// The <c>WinHttpRequestOption</c> enumeration includes options that can be set or retrieved for the current Microsoft Windows HTTP
		/// Services (WinHTTP) session.
		/// </summary>
		/// <remarks>
		/// <para>Set an option by specifying one of the preceding constants as the parameter of the <c>Option</c> property.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>For Windows XP and Windows 2000, see the Run-Time Requirements section of the WinHttp start page.</para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/winhttp/winhttprequestoption typedef enum WinHttpRequestOption {
		// WinHttpRequestOption_UserAgentString, WinHttpRequestOption_URL, WinHttpRequestOption_URLCodePage,
		// WinHttpRequestOption_EscapePercentInURL, WinHttpRequestOption_SslErrorIgnoreFlags, WinHttpRequestOption_SelectCertificate,
		// WinHttpRequestOption_EnableRedirects, WinHttpRequestOption_UrlEscapeDisable, WinHttpRequestOption_UrlEscapeDisableQuery,
		// WinHttpRequestOption_SecureProtocols, WinHttpRequestOption_EnableTracing, WinHttpRequestOption_RevertImpersonationOverSsl,
		// WinHttpRequestOption_EnableHttpsToHttpRedirects, WinHttpRequestOption_EnablePassportAuthentication,
		// WinHttpRequestOption_MaxAutomaticRedirects, WinHttpRequestOption_MaxResponseHeaderSize, WinHttpRequestOption_MaxResponseDrainSize,
		// WinHttpRequestOption_EnableHttp1_1, WinHttpRequestOption_EnableCertificateRevocationCheck } WinHttpRequestOption;
		[PInvokeData("winhttp.h")]
		public enum WinHttpRequestOption
		{
			/// <summary>Sets or retrieves a <c>VARIANT</c> that contains the user agent string.</summary>
			WinHttpRequestOption_UserAgentString,

			/// <summary>
			/// Retrieves a <c>VARIANT</c> that contains the URL of the resource. This value is read-only; you cannot set the URL using this
			/// property. The URL cannot be read until the <c>Open</c> method is called. This option is useful for checking the URL after the
			/// <c>Send</c> method is finished to verify that any redirection occurred.
			/// </summary>
			WinHttpRequestOption_URL,

			/// <summary>
			/// Sets or retrieves a <c>VARIANT</c> that identifies the code page for the URL string. The default value is the UTF-8 code
			/// page. The code page is used to convert the Unicode URL string, passed in the <c>Open</c> method, to a single-byte string representation.
			/// </summary>
			WinHttpRequestOption_URLCodePage,

			/// <summary>
			/// Sets or retrieves a <c>VARIANT</c> that indicates whether percent characters in the URL string are converted to an escape
			/// sequence. The default value of this option is <c>VARIANT_TRUE</c> which specifies all unsafe American National Standards
			/// Institute (ANSI) characters except the percent symbol are converted to an escape sequence.
			/// </summary>
			WinHttpRequestOption_EscapePercentInURL,

			/// <summary>
			/// <para>
			/// Sets or retrieves a <c>VARIANT</c> that indicates which server certificate errors should be ignored. This can be a
			/// combination of one or more of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Error</term>
			/// <term>Value</term>
			/// </listheader>
			/// <item>
			/// <term>Unknown certification authority (CA) or untrusted root</term>
			/// <term>0x0100</term>
			/// </item>
			/// <item>
			/// <term>Wrong usage</term>
			/// <term>0x0200</term>
			/// </item>
			/// <item>
			/// <term>Invalid common name (CN)</term>
			/// <term>0x1000</term>
			/// </item>
			/// <item>
			/// <term>Invalid date or certificate expired</term>
			/// <term>0x2000</term>
			/// </item>
			/// </list>
			/// <para>
			/// The default value of this option in Version 5.1 of WinHTTP is zero, which results in no errors being ignored. In earlier
			/// versions of WinHTTP, the default setting was 0x3300, which resulted in all server certificate errors being ignored by default.
			/// </para>
			/// </summary>
			WinHttpRequestOption_SslErrorIgnoreFlags,

			/// <summary>
			/// Sets a <c>VARIANT</c> that specifies the client certificate that is sent to a server for authentication. This option
			/// indicates the location, certificate store, and subject of a client certificate delimited with backslashes. For more
			/// information about selecting a client certificate, see SSL in WinHTTP.
			/// </summary>
			WinHttpRequestOption_SelectCertificate,

			/// <summary>
			/// Sets or retrieves a <c>VARIANT</c> that indicates whether requests are automatically redirected when the server specifies a
			/// new location for the resource. The default value of this option is <c>VARIANT_TRUE</c> to indicate that requests are
			/// automatically redirected.
			/// </summary>
			WinHttpRequestOption_EnableRedirects,

			/// <summary>
			/// Sets or retrieves a <c>VARIANT</c> that indicates whether unsafe characters in the path and query components of a URL are
			/// converted to escape sequences. The default value of this option is <c>VARIANT_TRUE</c>, which specifies that characters in
			/// the path and query are converted.
			/// </summary>
			WinHttpRequestOption_UrlEscapeDisable,

			/// <summary>
			/// Sets or retrieves a <c>VARIANT</c> that indicates whether unsafe characters in the query component of the URL are converted
			/// to escape sequences. The default value of this option is <c>VARIANT_TRUE</c>, which specifies that characters in the query
			/// are converted.
			/// </summary>
			WinHttpRequestOption_UrlEscapeDisableQuery,

			/// <summary>
			/// <para>
			/// Sets or retrieves a <c>VARIANT</c> that indicates which secure protocols can be used. This option selects the protocols
			/// acceptable to the client. The protocol is negotiated during the Secure Sockets Layer (SSL) handshake. This can be a
			/// combination of one or more of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Protocol</term>
			/// <term>Value</term>
			/// </listheader>
			/// <item>
			/// <term>SSL 2.0</term>
			/// <term>0x0008</term>
			/// </item>
			/// <item>
			/// <term>SSL 3.0</term>
			/// <term>0x0020</term>
			/// </item>
			/// <item>
			/// <term>Transport Layer Security (TLS) 1.0</term>
			/// <term>0x0080</term>
			/// </item>
			/// </list>
			/// <para>
			/// The default value of this option is 0x0028, which indicates that SSL 2.0 or SSL 3.0 can be used. If this option is set to
			/// zero, the client and server are not able to determine an acceptable security protocol and the next <c>Send</c> results in an error.
			/// </para>
			/// </summary>
			WinHttpRequestOption_SecureProtocols,

			/// <summary>
			/// Sets or retrieves a <c>VARIANT</c> that indicates whether tracing is currently enabled. For more information about the trace
			/// facility in Microsoft Windows HTTP Services (WinHTTP), see WinHTTP Trace Facility.
			/// </summary>
			WinHttpRequestOption_EnableTracing,

			/// <summary>
			/// Controls whether the <c>WinHttpRequest</c> object temporarily reverts client impersonation for the duration of the SSL
			/// certificate authentication operations. The default setting for the <c>WinHttpRequest</c> object is <c>TRUE</c>. Set this
			/// option to <c>FALSE</c> to keep impersonation while performing certificate authentication operations.
			/// </summary>
			WinHttpRequestOption_RevertImpersonationOverSsl,

			/// <summary>
			/// Controls whether or not WinHTTP allows redirects. By default, all redirects are automatically followed, except those that
			/// transfer from a secure (https) URL to an non-secure (http) URL. Set this option to <c>TRUE</c> to enable HTTPS to HTTP redirects.
			/// </summary>
			WinHttpRequestOption_EnableHttpsToHttpRedirects,

			/// <summary>
			/// Enables or disables support for Passport authentication. By default, automatic support for Passport authentication is
			/// disabled; set this option to <c>TRUE</c> to enable Passport authentication support.
			/// </summary>
			WinHttpRequestOption_EnablePassportAuthentication,

			/// <summary>
			/// <para>
			/// Sets or retrieves the maximum number of redirects that WinHTTP follows; the default is 10. This limit prevents unauthorized
			/// sites from making the WinHTTP client stall following a large number of redirects.
			/// </para>
			/// <para><c>Windows XP with SP1 and Windows 2000 with SP3:</c> This enumeration value is not supported.</para>
			/// </summary>
			WinHttpRequestOption_MaxAutomaticRedirects,

			/// <summary>
			/// <para>
			/// Sets or retrieves a bound set on the maximum size of the header portion of the server's response. This bound protects the
			/// client from a malicious server attempting to stall the client by sending a response with an infinite amount of header data.
			/// The default value is 64 KB.
			/// </para>
			/// <para><c>Windows XP with SP1 and Windows 2000 with SP3:</c> This enumeration value is not supported.</para>
			/// </summary>
			WinHttpRequestOption_MaxResponseHeaderSize,

			/// <summary>
			/// <para>
			/// Sets or retrieves a bound on the amount of data that will be drained from responses in order to reuse a connection. The
			/// default is 1 MB.
			/// </para>
			/// <para><c>Windows XP with SP1 and Windows 2000 with SP3:</c> This enumeration value is not supported.</para>
			/// </summary>
			WinHttpRequestOption_MaxResponseDrainSize,

			/// <summary>
			/// <para>
			/// Sets or retrieves a boolean value that indicates whether HTTP/1.1 or HTTP/1.0 should be used. The default is <c>TRUE</c>, so
			/// that HTTP/1.1 is used by default.
			/// </para>
			/// <para><c>Windows XP with SP1 and Windows 2000 with SP3:</c> This enumeration value is not supported.</para>
			/// </summary>
			WinHttpRequestOption_EnableHttp1_1,

			/// <summary>
			/// <para>
			/// Enables server certificate revocation checking during SSL negotiation. When the server presents a certificate, a check is
			/// performed to determine whether the certificate has been revoked by its issuer. If the certificate is indeed revoked, or the
			/// revocation check fails because the Certificate Revocation List (CRL) cannot be downloaded, the request fails; such revocation
			/// errors cannot be suppressed.
			/// </para>
			/// <para><c>Windows XP with SP1 and Windows 2000 with SP3:</c> This enumeration value is not supported.</para>
			/// </summary>
			WinHttpRequestOption_EnableCertificateRevocationCheck,
		}
	}
}