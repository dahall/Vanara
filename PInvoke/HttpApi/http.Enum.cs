#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Vanara.PInvoke;

/// <summary>Items from HttpApi.dll.</summary>
public static partial class HttpApi
{
	/// <summary>
	/// <para>The <c>HTTP_503_RESPONSE_VERBOSITY</c> enumeration defines the verbosity levels for a 503, service unavailable, error responses.</para>
	/// <para>This structure must be used when setting or querying the HttpServer503ResponseProperty on a request queue.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This enumeration is used in HttpSetRequestQueueProperty, and HttpQueryrequestQueueProperty to set and query the 503 response
	/// verbosity. The <c>pPropertyInformation</c> parameter points to a member of the <c>HTTP_503_RESPONSE_VERBOSITY</c> enumeration when
	/// the <c>Property</c> parameter is <c>HttpServer503VerbosityProperty</c>.
	/// </para>
	/// <para>
	/// This enumeration defines the verbosity level for a request queue when sending 503 (Service Unavailable) error responses. Note that
	/// the 503 response level set using the <c>HTTP_503_RESPONSE_VERBOSITY</c> enumeration only affects the error responses generated
	/// internally by the HTTP Server API.
	/// </para>
	/// <para><c>Note</c> Disclosing information about the state of the service to potentially unsafe clients may pose a security risk.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_503_response_verbosity typedef enum _HTTP_503_RESPONSE_VERBOSITY
	// { Http503ResponseVerbosityBasic, Http503ResponseVerbosityLimited, Http503ResponseVerbosityFull } HTTP_503_RESPONSE_VERBOSITY, *PHTTP_503_RESPONSE_VERBOSITY;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_503_RESPONSE_VERBOSITY")]
	public enum HTTP_503_RESPONSE_VERBOSITY
	{
		/// <summary>
		/// <para>A 503 response is not sent; the connection is reset.</para>
		/// <para>This is the default HTTP Server API behavior.</para>
		/// </summary>
		Http503ResponseVerbosityBasic,

		/// <summary>
		/// The HTTP Server API sends a 503 response with a "Service Unavailable" reason phrase. The HTTP Server closes the TCP connection
		/// after sending the response, so the client has to re-connect.
		/// </summary>
		Http503ResponseVerbosityLimited,

		/// <summary>
		/// The HTTP Server API sends a 503 response with a detailed reason phrase. The HTTP Server closes the TCP connection after sending
		/// the response, so the client has to re-connect.
		/// </summary>
		Http503ResponseVerbosityFull,
	}

	/// <summary>The supported authentication schemes.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVER_AUTHENTICATION_INFO")]
	[Flags]
	public enum HTTP_AUTH_ENABLE : uint
	{
		/// <summary>Basic authentication is enabled.</summary>
		HTTP_AUTH_ENABLE_BASIC = 0x00000001,

		/// <summary>Digest authentication is enabled.</summary>
		HTTP_AUTH_ENABLE_DIGEST = 0x00000002,

		/// <summary>NTLM authentication is enabled.</summary>
		HTTP_AUTH_ENABLE_NTLM = 0x00000004,

		/// <summary>Negotiate authentication is enabled.</summary>
		HTTP_AUTH_ENABLE_NEGOTIATE = 0x00000008,

		/// <summary>Kerberos authentication is enabled.</summary>
		HTTP_AUTH_ENABLE_KERBEROS = 0x00000010,

		/// <summary>All types of authentication are enabled.</summary>
		HTTP_AUTH_ENABLE_ALL = HTTP_AUTH_ENABLE_BASIC     | HTTP_AUTH_ENABLE_DIGEST    |HTTP_AUTH_ENABLE_NTLM      |HTTP_AUTH_ENABLE_NEGOTIATE |HTTP_AUTH_ENABLE_KERBEROS,
	}

	/// <summary>Optional authentication flags.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVER_AUTHENTICATION_INFO")]
	[Flags]
	public enum HTTP_AUTH_EX_FLAG : byte
	{
		/// <summary>
		/// If set, the Kerberos authentication credentials are cached. Kerberos or Negotiate authentication must be enabled by <c>AuthSchemes</c>.
		/// </summary>
		HTTP_AUTH_EX_FLAG_ENABLE_KERBEROS_CREDENTIAL_CACHING = 0x01,

		/// <summary>
		/// If set, the HTTP Server API captures the caller's credentials and uses them for Kerberos or Negotiate authentication. Kerberos or
		/// Negotiate authentication must be enabled by <c>AuthSchemes</c>.
		/// </summary>
		HTTP_AUTH_EX_FLAG_CAPTURE_CREDENTIAL = 0x02,
	}

	/// <summary>
	/// <para>The <c>HTTP_AUTH_STATUS</c> enumeration defines the authentication state of a request.</para>
	/// <para>This enumeration is used in the HTTP_REQUEST_AUTH_INFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_auth_status typedef enum _HTTP_AUTH_STATUS {
	// HttpAuthStatusSuccess, HttpAuthStatusNotAuthenticated, HttpAuthStatusFailure } HTTP_AUTH_STATUS, *PHTTP_AUTH_STATUS;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_AUTH_STATUS")]
	public enum HTTP_AUTH_STATUS
	{
		/// <summary>
		/// <para>The request was successfully authenticated for the authentication type indicated in the <c>HTTP_REQUEST_AUTH_INFO</c> structure.</para>
		/// </summary>
		HttpAuthStatusSuccess,

		/// <summary>
		/// <para>
		/// Authentication was configured on the URL group for this request, however, the HTTP Server API did not handle the authentication.
		/// This could be because of one of the following reasons:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The scheme defined in the HttpHeaderAuthorization header of the request is not supported by the HTTP Server API, or it is not
		/// enabled on the URL Group. If the scheme is not enabled, the <c>AuthType</c> member of HTTP_REQUEST_AUTH_INFO is set to the
		/// appropriate type, otherwise <c>AuthType</c> will have the value HttpRequestAuthTypeNone.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The authorization header is not present, however, authentication is enabled on the URL Group.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The application should either proceed with its own authentication or respond with the initial 401 challenge containing the
		/// desired set of authentication schemes.
		/// </para>
		/// </summary>
		HttpAuthStatusNotAuthenticated,

		/// <summary>
		/// <para>
		/// Authentication for the authentication type listed in the <c>HTTP_REQUEST_AUTH_INFO</c> structure failed, possibly due to one of
		/// the following reasons:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The Security Service Provider Interface (SSPI) based authentication scheme failed to successfully return from a call to
		/// AcceptSecurityContext. The error returned AcceptSecurityContext is indicated in the <c>SecStatus</c> member of the
		/// HTTP_REQUEST_AUTH_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The finalized client context is for a Null NTLM session. Null sessions are treated as authentication failures.</term>
		/// </item>
		/// <item>
		/// <term>The call to <c>LogonUser</c> failed for the Basic authentication.</term>
		/// </item>
		/// </list>
		/// </summary>
		HttpAuthStatusFailure,
	}

	/// <summary>Server Hardening level.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_authentication_hardening_levels typedef enum
	// _HTTP_AUTHENTICATION_HARDENING_LEVELS { HttpAuthenticationHardeningLegacy = 0, HttpAuthenticationHardeningMedium,
	// HttpAuthenticationHardeningStrict } HTTP_AUTHENTICATION_HARDENING_LEVELS;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_AUTHENTICATION_HARDENING_LEVELS")]
	public enum HTTP_AUTHENTICATION_HARDENING_LEVELS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Server is not hardened and operates without Channel Binding Token (CBT) support.</para>
		/// </summary>
		HttpAuthenticationHardeningLegacy,

		/// <summary>Server is partially hardened. Clients that support CBT are serviced appropriately. Legacy clients are also serviced.</summary>
		HttpAuthenticationHardeningMedium,

		/// <summary>Server is hardened. Only clients that supported CBT are serviced.</summary>
		HttpAuthenticationHardeningStrict,
	}

	/// <summary>
	/// The <c>HTTP_CACHE_POLICY_TYPE</c> enumeration type defines available cache policies. It is used to restrict the values of the
	/// <c>Policy</c> member of the HTTP_CACHE_POLICY structure, which in turn is used in the <c>pCachePolicy</c> parameter of the
	/// HttpAddFragmentToCache function to specify how a response fragment is cached.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_cache_policy_type typedef enum _HTTP_CACHE_POLICY_TYPE {
	// HttpCachePolicyNocache, HttpCachePolicyUserInvalidates, HttpCachePolicyTimeToLive, HttpCachePolicyMaximum } HTTP_CACHE_POLICY_TYPE, *PHTTP_CACHE_POLICY_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_CACHE_POLICY_TYPE")]
	public enum HTTP_CACHE_POLICY_TYPE
	{
		/// <summary>Do not cache this value at all.</summary>
		HttpCachePolicyNocache,

		/// <summary>Cache this value until the user provides a different one.</summary>
		HttpCachePolicyUserInvalidates,

		/// <summary>Cache this value for a specified time and then remove it from the cache.</summary>
		HttpCachePolicyTimeToLive,

		/// <summary>Terminates the enumeration; not used to determine policy.</summary>
		HttpCachePolicyMaximum,
	}

	/// <summary>A bitwise OR combination of flags that determine the behavior of authentication.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_CHANNEL_BIND_INFO")]
	[Flags]
	public enum HTTP_CHANNEL_BIND : uint
	{
		/// <summary>
		/// The exact Channel Bind Token (CBT) match is bypassed. CBT is checked not to be equal to ‘unbound’. Service Principle Name (SPN)
		/// check is enabled.
		/// </summary>
		HTTP_CHANNEL_BIND_PROXY = 0x1,

		/// <summary>
		/// This flag is valid only if HTTP_CHANNEL_BIND_PROXY is also set. With the flag set, the CBT check (comparing with ‘unbound’) is
		/// skipped. The flag should be set if both secure channel traffic passed through proxy and traffic originally sent through insecure
		/// channel have to be authenticated.
		/// </summary>
		HTTP_CHANNEL_BIND_PROXY_COHOSTING = 0x20,

		/// <summary>SPN check always succeeds.</summary>
		HTTP_CHANNEL_BIND_NO_SERVICE_NAME_CHECK = 0x2,

		/// <summary>Enables dotless service names. Otherwise configuring CBT properties with dotless service names will fail.</summary>
		HTTP_CHANNEL_BIND_DOTLESS_SERVICE = 0x4,

		/// <summary>
		/// Server session, URL group, or response is configured to retrieve secure channel endpoint binding for each request and pass it to
		/// user the mode application. When set, a pointer to a buffer with the secure channel endpoint binding is stored in an
		/// HTTP_REQUEST_CHANNEL_BIND_STATUS structure.
		/// </summary>
		HTTP_CHANNEL_BIND_SECURE_CHANNEL_TOKEN = 0x8,

		/// <summary>
		/// Server session, URL group, or response is configured to retrieve SPN for each request and pass it to the user mode application.
		/// The SPN is stored in the <c>ServiceName</c> field of the HTTP_REQUEST_CHANNEL_BIND_STATUS structure. The type is always
		/// <c>HttpServiceBindingTypeW</c> (Unicode).
		/// </summary>
		HTTP_CHANNEL_BIND_CLIENT_SERVICE = 0x10,
	}

	/// <summary>Definitions for request queue manipulation. These flags are used with HttpCreateRequestQueue() API.</summary>
	[Flags]
	public enum HTTP_CREATE_REQUEST_QUEUE_FLAG : uint
	{
		HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING = 0x00000001,
		HTTP_CREATE_REQUEST_QUEUE_FLAG_CONTROLLER = 0x00000002,
		HTTP_CREATE_REQUEST_QUEUE_FLAG_DELEGATION = 0x00000008,
	}

	/// <summary/>
	[PInvokeData("http.h")]
	public enum HTTP_CREATE_REQUEST_QUEUE_PROPERTY_ID
	{
		/// <summary/>
		CreateRequestQueueExternalIdProperty = 1,

		/// <summary/>
		CreateRequestQueueMax
	}

	/// <summary>Defines the data source for a data chunk.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_data_chunk_type typedef enum _HTTP_DATA_CHUNK_TYPE {
	// HttpDataChunkFromMemory, HttpDataChunkFromFileHandle, HttpDataChunkFromFragmentCache, HttpDataChunkFromFragmentCacheEx,
	// HttpDataChunkTrailers, HttpDataChunkMaximum } HTTP_DATA_CHUNK_TYPE, *PHTTP_DATA_CHUNK_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_DATA_CHUNK_TYPE")]
	public enum HTTP_DATA_CHUNK_TYPE
	{
		/// <summary>
		/// <para>The data source is a memory data block. The union should be interpreted as a <c>FromMemory</c> structure.</para>
		/// </summary>
		HttpDataChunkFromMemory,

		/// <summary>
		/// <para>The data source is a file handle data block. The union should be interpreted as a <c>FromFileHandle</c> structure.</para>
		/// </summary>
		HttpDataChunkFromFileHandle,

		/// <summary>
		/// <para>The data source is a fragment cache data block. The union should be interpreted as a <c>FromFragmentCache</c> structure.</para>
		/// </summary>
		HttpDataChunkFromFragmentCache,

		/// <summary>
		/// <para>The data source is a fragment cache data block. The union should be interpreted as a <c>FromFragmentCacheEx</c> structure.</para>
		/// <para>Windows Server 2003 with SP1 and Windows XP with SP2:</para>
		/// <para>This flag is not supported.</para>
		/// </summary>
		HttpDataChunkFromFragmentCacheEx,

		/// <summary>
		/// <para>The data source is a trailers data block. The union should be interpreted as a <c>Trailers</c> structure.</para>
		/// <para>Windows 10, version 2004 and prior:</para>
		/// <para>This flag is not supported.</para>
		/// </summary>
		HttpDataChunkTrailers,

		/// <summary/>
		HttpDataChunkMaximum,
	}

	/// <summary>Defines constants that specify a type of property information for a delegate request.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_delegate_request_property_id typedef enum
	// _HTTP_DELEGATE_REQUEST_PROPERTY_ID { DelegateRequestReservedProperty, DelegateRequestDelegateUrlProperty }
	// HTTP_DELEGATE_REQUEST_PROPERTY_ID, *PHTTP_DELEGATE_REQUEST_PROPERTY_ID;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_DELEGATE_REQUEST_PROPERTY_ID")]
	public enum HTTP_DELEGATE_REQUEST_PROPERTY_ID
	{
		/// <summary>This property is reserved.</summary>
		DelegateRequestReservedProperty,

		/// <summary>Specifies the property that provides the target url to which a delegated request should be delivered.</summary>
		DelegateRequestDelegateUrlProperty,
	}

	/// <summary>
	/// <para>The <c>HTTP_ENABLED_STATE</c> enumeration defines the state of a request queue, server session, or URL Group.</para>
	/// <para>This enumeration is used in the HTTP_STATE_INFO struct</para>
	/// </summary>
	/// <remarks>
	/// The default state of a request queue is enabled. Typically this enumeration is used to temporarily disable a request queue.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_enabled_state typedef enum _HTTP_ENABLED_STATE {
	// HttpEnabledStateActive, HttpEnabledStateInactive } HTTP_ENABLED_STATE, *PHTTP_ENABLED_STATE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_ENABLED_STATE")]
	public enum HTTP_ENABLED_STATE
	{
		/// <summary>The HTTP Server API object is enabled.</summary>
		HttpEnabledStateActive,

		/// <summary>The HTTP Server API object is disabled.</summary>
		HttpEnabledStateInactive,
	}

	/// <summary>Defines constants that specify an identifier for an HTTP feature.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_feature_id typedef enum _HTTP_FEATURE_ID { HttpFeatureUnknown =
	// 0, HttpFeatureResponseTrailers = 1, HttpFeatureApiTimings = 2, HttpFeatureDelegateEx = 3, HttpFeatureHttp3, HttpFeatureLast,
	// HttpFeaturemax = 0xFFFFFFFF } HTTP_FEATURE_ID, *PHTTP_FEATURE_ID;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_FEATURE_ID")]
	public enum HTTP_FEATURE_ID : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies an unknown feature.</para>
		/// </summary>
		HttpFeatureUnknown,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Specifies HTTP response trailers.</para>
		/// </summary>
		HttpFeatureResponseTrailers,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Specifies HTTP API timings.</para>
		/// </summary>
		HttpFeatureApiTimings,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Specifies a request for delegation.</para>
		/// </summary>
		HttpFeatureDelegateEx,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xFFFFFFFF</para>
		/// <para>Specifies the maximum number of supported features.</para>
		/// </summary>
		HttpFeaturemax = 0xFFFFFFFF,
	}

	/// <summary>Flag values for HttpFlushResponseCache.</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpFlushResponseCache")]
	[Flags]
	public enum HTTP_FLUSH_RESPONSE_FLAG : uint
	{
		/// <summary>
		/// Causes response fragments that have names in which the site portion is a hierarchical descendant of the specified UrlPrefix to be
		/// removed from the fragment cache, in addition to those fragments having site portions that directly match.
		/// </summary>
		HTTP_FLUSH_RESPONSE_FLAG_RECURSIVE = 0x00000001,
	}

	/// <summary>
	/// The <c>HTTP_HEADER_ID</c> enumeration type lists <c>known headers</c> for HTTP requests and responses, and associates an array index
	/// with each such header. It is used to size and access the <c>KnownHeaders</c> array members of the HTTP_REQUEST_HEADERS and
	/// HTTP_RESPONSE_HEADERS structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_header_id typedef enum _HTTP_HEADER_ID { HttpHeaderCacheControl =
	// 0, HttpHeaderConnection = 1, HttpHeaderDate = 2, HttpHeaderKeepAlive = 3, HttpHeaderPragma = 4, HttpHeaderTrailer = 5,
	// HttpHeaderTransferEncoding = 6, HttpHeaderUpgrade = 7, HttpHeaderVia = 8, HttpHeaderWarning = 9, HttpHeaderAllow = 10,
	// HttpHeaderContentLength = 11, HttpHeaderContentType = 12, HttpHeaderContentEncoding = 13, HttpHeaderContentLanguage = 14,
	// HttpHeaderContentLocation = 15, HttpHeaderContentMd5 = 16, HttpHeaderContentRange = 17, HttpHeaderExpires = 18, HttpHeaderLastModified
	// = 19, HttpHeaderAccept = 20, HttpHeaderAcceptCharset = 21, HttpHeaderAcceptEncoding = 22, HttpHeaderAcceptLanguage = 23,
	// HttpHeaderAuthorization = 24, HttpHeaderCookie = 25, HttpHeaderExpect = 26, HttpHeaderFrom = 27, HttpHeaderHost = 28,
	// HttpHeaderIfMatch = 29, HttpHeaderIfModifiedSince = 30, HttpHeaderIfNoneMatch = 31, HttpHeaderIfRange = 32,
	// HttpHeaderIfUnmodifiedSince = 33, HttpHeaderMaxForwards = 34, HttpHeaderProxyAuthorization = 35, HttpHeaderReferer = 36,
	// HttpHeaderRange = 37, HttpHeaderTe = 38, HttpHeaderTranslate = 39, HttpHeaderUserAgent = 40, HttpHeaderRequestMaximum = 41,
	// HttpHeaderAcceptRanges = 20, HttpHeaderAge = 21, HttpHeaderEtag = 22, HttpHeaderLocation = 23, HttpHeaderProxyAuthenticate = 24,
	// HttpHeaderRetryAfter = 25, HttpHeaderServer = 26, HttpHeaderSetCookie = 27, HttpHeaderVary = 28, HttpHeaderWwwAuthenticate = 29,
	// HttpHeaderResponseMaximum = 30, HttpHeaderMaximum = 41 } HTTP_HEADER_ID, *PHTTP_HEADER_ID;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_HEADER_ID")]
	public enum HTTP_HEADER_ID
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Used to specify caching behavior along the request or response chain, overriding the default caching algorithm.</para>
		/// </summary>
		HttpHeaderCacheControl,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Allows the sender to specify options that are desired for that particular connection. These are used for a single connection only
		/// and must not be communicated by proxies over further connections.
		/// </para>
		/// </summary>
		HttpHeaderConnection,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The Date is a general header field that indicates the time that the request or response was sent.</para>
		/// </summary>
		HttpHeaderDate,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Based on the keepalive XML element (see RFC 2518, section 12.12.1, page 66); a list of URIs included in the KeepAlive header must
		/// be "live" after they are copied (moved) to the destination.
		/// </para>
		/// </summary>
		HttpHeaderKeepAlive,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// Used to include optional, implementation-specific directives that might apply to any recipient along the request/response chain.
		/// </para>
		/// </summary>
		HttpHeaderPragma,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Indicates that specified header fields are present in the trailer of a message encoded with chunked transfer-coding.</para>
		/// </summary>
		HttpHeaderTrailer,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Indicates what, if any, transformations have been applied to the message body in transit.</para>
		/// </summary>
		HttpHeaderTransferEncoding,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Allows the client to specify one or more other communication protocols it would prefer to use if the server can comply.</para>
		/// </summary>
		HttpHeaderUpgrade,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The Via header field indicates the path taken by the request.</para>
		/// </summary>
		HttpHeaderVia,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>This is a response header that contains the 3-digit warn code along with the reason phrase.</para>
		/// </summary>
		HttpHeaderWarning,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Lists the set of methods supported by the resource identified by the Request-URI.</para>
		/// </summary>
		HttpHeaderAllow,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The size of the message body in decimal bytes.</para>
		/// </summary>
		HttpHeaderContentLength,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>The media type of the message body.</para>
		/// </summary>
		HttpHeaderContentType,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>The encoding scheme for the message body.</para>
		/// </summary>
		HttpHeaderContentEncoding,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>Provides the natural language of the intended audience.</para>
		/// </summary>
		HttpHeaderContentLanguage,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>
		/// Location of the resource for the entity enclosed in the message when that entity is accessible from a location separate from the
		/// requested resource's URI.
		/// </para>
		/// </summary>
		HttpHeaderContentLocation,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>An MD5 digest of the entity-body used to provide end-to-end message integrity check (MIC) of the entity-body.</para>
		/// </summary>
		HttpHeaderContentMd5,

		/// <summary>
		/// <para>Value:</para>
		/// <para>17</para>
		/// <para>
		/// The content range header is sent with a partial entity body to specify where in the full entity body the partial body should be applied.
		/// </para>
		/// </summary>
		HttpHeaderContentRange,

		/// <summary>
		/// <para>Value:</para>
		/// <para>18</para>
		/// <para>The date and time after which the message content expires.</para>
		/// </summary>
		HttpHeaderExpires,

		/// <summary>
		/// <para>Value:</para>
		/// <para>19</para>
		/// <para>Indicates the date and time at which the origin server believes the variant was last modified.</para>
		/// </summary>
		HttpHeaderLastModified,

		/// <summary>
		/// <para>Value:</para>
		/// <para>20</para>
		/// <para>Used with the INVITE, OPTIONS, and REGISTER methods to indicate what media types are acceptable in the response.</para>
		/// </summary>
		HttpHeaderAccept,

		/// <summary>
		/// <para>Value:</para>
		/// <para>21</para>
		/// <para>Indicates the character sets that are acceptable for the response.</para>
		/// </summary>
		HttpHeaderAcceptCharset,

		/// <summary>
		/// <para>Value:</para>
		/// <para>22</para>
		/// <para>The content encodings that are acceptable in the response.</para>
		/// </summary>
		HttpHeaderAcceptEncoding,

		/// <summary>
		/// <para>Value:</para>
		/// <para>23</para>
		/// <para>
		/// Used by the client to indicate to the server which language it would prefer to receive reason phrases, session descriptions, or
		/// status responses.
		/// </para>
		/// </summary>
		HttpHeaderAcceptLanguage,

		/// <summary>
		/// <para>Value:</para>
		/// <para>24</para>
		/// <para>
		/// The user-agent can authenticate itself with a server by sending the Authorization request header field with the request. The
		/// field contains the credentials for the domain that the user is requesting.
		/// </para>
		/// </summary>
		HttpHeaderAuthorization,

		/// <summary>
		/// <para>Value:</para>
		/// <para>25</para>
		/// <para>
		/// The cookie request header contains data used to maintain client state with the server. Cookie data is obtained from a response
		/// sent with HttpHeaderSetCookie.
		/// </para>
		/// </summary>
		HttpHeaderCookie,

		/// <summary>
		/// <para>Value:</para>
		/// <para>26</para>
		/// <para>Indicates the specific server behaviors that are required by the client.</para>
		/// </summary>
		HttpHeaderExpect,

		/// <summary>
		/// <para>Value:</para>
		/// <para>27</para>
		/// <para>The From header field specifies the initiator of the SIP request or response message.</para>
		/// </summary>
		HttpHeaderFrom,

		/// <summary>
		/// <para>Value:</para>
		/// <para>28</para>
		/// <para>
		/// Specifies the Internet host and port number of the requested resource. This is obtained from the original URI given by the user
		/// or referring resource.
		/// </para>
		/// </summary>
		HttpHeaderHost,

		/// <summary>
		/// <para>Value:</para>
		/// <para>29</para>
		/// <para>
		/// The If-Match request header field is used with a method to make it conditional. A client that has one or more entities previously
		/// obtained from the resource can verify that one of those entities is current by including a list of their associated entity tags
		/// in the If-Match header field.
		/// </para>
		/// </summary>
		HttpHeaderIfMatch,

		/// <summary>
		/// <para>Value:</para>
		/// <para>30</para>
		/// <para>
		/// The If-Modified-Since request header field is used with a method to make it conditional. If the requested variant has not been
		/// modified since the time specified in this field, an entity is not returned from the server; instead, a 304 (not modified)
		/// response is returned without any message-body.
		/// </para>
		/// </summary>
		HttpHeaderIfModifiedSince,

		/// <summary>
		/// <para>Value:</para>
		/// <para>31</para>
		/// <para>
		/// The If-None-Match request-header field is used with a method to make it conditional. When a client has obtained one or more
		/// entities from a resource, it can verify that none of those entities is current by including a list of their associated entity
		/// tags in the If-None-Match header field. The purpose of this feature is to allow efficient updates of cached information with a
		/// minimum amount of transaction overhead, and to prevent a method such as PUT from inadvertently modifying an existing resource
		/// when the client believes that the resource does not exist.
		/// </para>
		/// </summary>
		HttpHeaderIfNoneMatch,

		/// <summary>
		/// <para>Value:</para>
		/// <para>32</para>
		/// <para>
		/// If a client has a partial copy of an entity in its cache, and wishes to obtain an up-to-date copy of the entire entity, it can
		/// use the If-Range header. Informally, its meaning is, "if the entity is unchanged, send me the part(s) I am missing; otherwise,
		/// send me the entire new entity."
		/// </para>
		/// </summary>
		HttpHeaderIfRange,

		/// <summary>
		/// <para>Value:</para>
		/// <para>33</para>
		/// <para>
		/// The If-Unmodified-Since request-header field is used with a method to make it conditional. If the requested resource has not been
		/// modified since the time specified in this field, the server performs the requested operation as if the If-Unmodified-Since header
		/// were not present, but if the requested resource has been modified, the server returns a 412 error (Precondition Failed).
		/// </para>
		/// </summary>
		HttpHeaderIfUnmodifiedSince,

		/// <summary>
		/// <para>Value:</para>
		/// <para>34</para>
		/// <para>The maximum number of proxies or gateways that can forward the request.</para>
		/// </summary>
		HttpHeaderMaxForwards,

		/// <summary>
		/// <para>Value:</para>
		/// <para>35</para>
		/// <para>This header field is used by the client to identify itself with a proxy.</para>
		/// </summary>
		HttpHeaderProxyAuthorization,

		/// <summary>
		/// <para>Value:</para>
		/// <para>36</para>
		/// <para>
		/// Allows the client to specify, for the server's benefit, the address (URI) of the resource from which the Request-URI was obtained.
		/// </para>
		/// </summary>
		HttpHeaderReferer,

		/// <summary>
		/// <para>Value:</para>
		/// <para>37</para>
		/// <para>Allows a client to request a part of an entity instead of the whole.</para>
		/// </summary>
		HttpHeaderRange,

		/// <summary>
		/// <para>Value:</para>
		/// <para>38</para>
		/// <para>This header field contains the recipient of the SIP request or response message.</para>
		/// </summary>
		HttpHeaderTe,

		/// <summary>
		/// <para>Value:</para>
		/// <para>39</para>
		/// <para>
		/// Allows the client to specify whether it wants the source representation or programmatic interpretation of the requested content.
		/// </para>
		/// </summary>
		HttpHeaderTranslate,

		/// <summary>
		/// <para>Value:</para>
		/// <para>40</para>
		/// <para>
		/// Indicates what extension transfer-codings the client accepts in the response and whether or not the client accepts trailer fields
		/// in a chunked transfer-coding.
		/// </para>
		/// </summary>
		HttpHeaderUserAgent,

		/// <summary>
		/// <para>Value:</para>
		/// <para>41</para>
		/// <para>Not a value that actually designates a header; instead, it is used to count the enumerated Request headers.</para>
		/// </summary>
		HttpHeaderRequestMaximum,

		/// <summary>
		/// <para>Value:</para>
		/// <para>20</para>
		/// <para>Allows the server to indicate its acceptance of range requests for a resource.</para>
		/// </summary>
		HttpHeaderAcceptRanges = 20,

		/// <summary>
		/// <para>Value:</para>
		/// <para>21</para>
		/// <para>
		/// Conveys the sender's estimate of the amount of time since the response (or its revalidation) was generated at the origin server.
		/// </para>
		/// </summary>
		HttpHeaderAge,

		/// <summary>
		/// <para>Value:</para>
		/// <para>22</para>
		/// <para>Provides the current value of the entity tag for the requested variant.</para>
		/// </summary>
		HttpHeaderEtag,

		/// <summary>
		/// <para>Value:</para>
		/// <para>23</para>
		/// <para>
		/// Used to redirect the recipient to a location other than the Request-URI for completion of the request or identification of a new resource.
		/// </para>
		/// </summary>
		HttpHeaderLocation,

		/// <summary>
		/// <para>Value:</para>
		/// <para>24</para>
		/// <para>
		/// The response field that must be included as a part of the 407 response. The field includes the authentication scheme and
		/// parameters that apply to the proxy for this Request-URI.
		/// </para>
		/// </summary>
		HttpHeaderProxyAuthenticate,

		/// <summary>
		/// <para>Value:</para>
		/// <para>25</para>
		/// <para>The length of time that the service is expected to be unavailable to the requesting client.</para>
		/// </summary>
		HttpHeaderRetryAfter,

		/// <summary>
		/// <para>Value:</para>
		/// <para>26</para>
		/// <para>This is a response header field that contains information about the server that is handling the request.</para>
		/// </summary>
		HttpHeaderServer,

		/// <summary>
		/// <para>Value:</para>
		/// <para>27</para>
		/// <para>The <c>set-cookie</c> response header contains data used to maintain client state in future requests sent with <c>HttpHeaderCookie</c>.</para>
		/// </summary>
		HttpHeaderSetCookie,

		/// <summary>
		/// <para>Value:</para>
		/// <para>28</para>
		/// <para>
		/// Indicates the set of request header fields that fully determines, while the response is fresh, whether a cache is permitted to
		/// use the response to reply to a subsequent request without revalidation.
		/// </para>
		/// </summary>
		HttpHeaderVary,

		/// <summary>
		/// <para>Value:</para>
		/// <para>29</para>
		/// <para>The WWW_Authenticate header field contains the authentication schemes and parameters applicable to the Request-URI.</para>
		/// </summary>
		HttpHeaderWwwAuthenticate,

		/// <summary>
		/// <para>Value:</para>
		/// <para>30</para>
		/// <para>Not a value that actually designates a header; instead, it is used to count the enumerated Response headers.</para>
		/// </summary>
		HttpHeaderResponseMaximum,

		/// <summary>
		/// <para>Value:</para>
		/// <para>41</para>
		/// <para>Not a value that actually designates a header; instead, it is used to count all the enumerated headers.</para>
		/// </summary>
		HttpHeaderMaximum,
	}

	/// <summary>Initialization options for <see cref="HttpInitialize"/>.</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpInitialize")]
	[Flags]
	public enum HTTP_INIT : uint
	{
		/// <summary>Perform initialization for applications that use the HTTP Server API.</summary>
		HTTP_INITIALIZE_SERVER = 0x00000001,

		/// <summary>
		/// Perform initialization for applications that use the HTTP configuration functions, HttpSetServiceConfiguration,
		/// HttpQueryServiceConfiguration, HttpDeleteServiceConfiguration, and HttpIsFeatureSupported.
		/// </summary>
		HTTP_INITIALIZE_CONFIG = 0x00000002,

		/// <summary/>
		HTTP_DEMAND_CBT = 0x00000004,
	}

	/// <summary>The <c>HTTP_LOG_DATA_TYPE</c> enumeration identifies the type of log data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_log_data_type typedef enum _HTTP_LOG_DATA_TYPE {
	// HttpLogDataTypeFields = 0 } HTTP_LOG_DATA_TYPE, *PHTTP_LOG_DATA_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_LOG_DATA_TYPE")]
	public enum HTTP_LOG_DATA_TYPE
	{
		/// <summary>
		/// <para>Value: 0</para>
		/// <para>
		/// The HTTP_LOG_FIELDS_DATA structure is used for logging a request. This structure is passed to an HttpSendHttpResponse or
		/// HttpSendResponseEntityBody call.
		/// </para>
		/// </summary>
		HttpLogDataTypeFields,
	}

	/// <summary></summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_LOGGING_INFO")]
	[Flags]
	public enum HTTP_LOG_FIELD : uint
	{
		/// <summary>The date on which the activity occurred.</summary>
		HTTP_LOG_FIELD_DATE = 0x00000001,

		/// <summary>The time, in coordinated universal time (UTC), at which the activity occurred.</summary>
		HTTP_LOG_FIELD_TIME = 0x00000002,

		/// <summary>The IP address of the client that made the request.</summary>
		HTTP_LOG_FIELD_CLIENT_IP = 0x00000004,

		/// <summary>The name of the authenticated user who accessed your server. Anonymous users are indicated by a hyphen.</summary>
		HTTP_LOG_FIELD_USER_NAME = 0x00000008,

		/// <summary>The name of the site on which the log file entry was generated.</summary>
		HTTP_LOG_FIELD_SITE_NAME = 0x00000010,

		/// <summary>The name of the computer on which the log file entry was generated.</summary>
		HTTP_LOG_FIELD_COMPUTER_NAME = 0x00000020,

		/// <summary>The IP address of the server on which the log file entry was generated.</summary>
		HTTP_LOG_FIELD_SERVER_IP = 0x00000040,

		/// <summary>The requested action, for example, a get method.</summary>
		HTTP_LOG_FIELD_METHOD = 0x00000080,

		/// <summary>The target of the action, for example, Default.htm.</summary>
		HTTP_LOG_FIELD_URI_STEM = 0x00000100,

		/// <summary>
		/// The query, if any, that the client was trying to perform. A Universal Resource Identifier (URI) query is necessary only for
		/// dynamic pages.
		/// </summary>
		HTTP_LOG_FIELD_URI_QUERY = 0x00000200,

		/// <summary>The HTTP status code.</summary>
		HTTP_LOG_FIELD_STATUS = 0x00000400,

		/// <summary>The Windows status code.</summary>
		HTTP_LOG_FIELD_WIN32_STATUS = 0x00000800,

		/// <summary>The number, in bytes, sent by the server.</summary>
		HTTP_LOG_FIELD_BYTES_SENT = 0x00001000,

		/// <summary>The number, in bytes, received by the server.</summary>
		HTTP_LOG_FIELD_BYTES_RECV = 0x00002000,

		/// <summary>The time, in milliseconds, of the action.</summary>
		HTTP_LOG_FIELD_TIME_TAKEN = 0x00004000,

		/// <summary>The server port number that is configured for the service.</summary>
		HTTP_LOG_FIELD_SERVER_PORT = 0x00008000,

		/// <summary>The application that the client used.</summary>
		HTTP_LOG_FIELD_USER_AGENT = 0x00010000,

		/// <summary>The content of the cookie sent or received, if any.</summary>
		HTTP_LOG_FIELD_COOKIE = 0x00020000,

		/// <summary>The site that the user last visited. This site provided a link to the current site.</summary>
		HTTP_LOG_FIELD_REFERER = 0x00040000,

		/// <summary>The HTTP protocol version that the client used.</summary>
		HTTP_LOG_FIELD_VERSION = 0x00080000,

		/// <summary>The host header name, if any.</summary>
		HTTP_LOG_FIELD_HOST = 0x00100000,

		/// <summary>The substatus error code.</summary>
		HTTP_LOG_FIELD_SUB_STATUS = 0x00200000,

		/// <summary>The stream id.</summary>
		HTTP_LOG_FIELD_STREAM_ID = 0x08000000,

		/// <summary/>
		HTTP_LOG_FIELD_STREAM_ID_EX = 0x10000000,

		/// <summary/>
		HTTP_LOG_FIELD_TRANSPORT_TYPE = 0x20000000,

		/// <summary>The client port number from which the request is received. This log field is only used for error logging.</summary>
		HTTP_LOG_FIELD_CLIENT_PORT = 0x00400000,

		/// <summary>The URI received in the request including the query portion. This log field is only used for error logging.</summary>
		HTTP_LOG_FIELD_URI = 0x00800000,

		/// <summary>
		/// The application-specific numeric ID of the URL Group on which the request is routed. This log field is only used for error logging.
		/// </summary>
		HTTP_LOG_FIELD_SITE_ID = 0x01000000,

		/// <summary>The error reason phrase. This log field is only used for error logging.</summary>
		HTTP_LOG_FIELD_REASON = 0x02000000,

		/// <summary>The name of the request queue to which the request is dispatched. This log field is only used for error logging.</summary>
		HTTP_LOG_FIELD_QUEUE_NAME = 0x04000000,

		/// <summary/>
		HTTP_LOG_FIELD_CORRELATION_ID = 0x40000000,
	}

	/// <summary>The optional logging flags change the default logging behavior.</summary>
	[Flags]
	public enum HTTP_LOGGING_FLAG : uint
	{
		/// <summary>Changes the log file rollover time to local time. By default log file rollovers are based on GMT.</summary>
		HTTP_LOGGING_FLAG_LOCAL_TIME_ROLLOVER = 0x00000001,

		/// <summary>
		/// By default, the unicode logging fields are converted to multibytes using the systems local code page. If this flags is set, the
		/// UTF8 conversion is used instead.
		/// </summary>
		HTTP_LOGGING_FLAG_USE_UTF8_CONVERSION = 0x00000002,

		/// <summary>
		/// The log errors only flag enables logging errors only. By default, both error and success request are logged. The
		/// <c>HTTP_LOGGING_FLAG_LOG_ERRORS_ONLY</c> and <c>HTTP_LOGGING_FLAG_LOG_SUCCESS_ONLY</c> flags are used to perform selective
		/// logging. Only one of these flags can be set at a time; they are mutually exclusive.
		/// </summary>
		HTTP_LOGGING_FLAG_LOG_ERRORS_ONLY = 0x00000004,

		/// <summary>
		/// The log success only flag enables logging successful requests only. By default, both error and success request are logged. The
		/// <c>HTTP_LOGGING_FLAG_LOG_ERRORS_ONLY</c> and <c>HTTP_LOGGING_FLAG_LOG_SUCCESS_ONLY</c> flags are used to perform selective
		/// logging. Only one of these flags can be set at a time; they are mutually exclusive.
		/// </summary>
		HTTP_LOGGING_FLAG_LOG_SUCCESS_ONLY = 0x00000008,
	}

	/// <summary>
	/// <para>The <c>HTTP_LOGGING_ROLLOVER_TYPE</c> enumeration defines the log file rollover types.</para>
	/// <para>This enumeration is used in the HTTP_LOGGING_INFO structure.</para>
	/// </summary>
	/// <remarks>
	/// <para>The log files are named based on the rollover type and logging format as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Format</term>
	/// <term>Rollover Type</term>
	/// <term>Filename Pattern</term>
	/// </listheader>
	/// <item>
	/// <term>Microsoft IIS Log Format</term>
	/// <term>Size</term>
	/// <term>inetsvnn.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Hourly</term>
	/// <term>inyymmddhh.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Daily</term>
	/// <term>inyymmdd.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Weekly</term>
	/// <term>inymmww.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Monthly</term>
	/// <term>inyymm.log</term>
	/// </item>
	/// <item>
	/// <term>NCSA Common Log File Format</term>
	/// <term>Size</term>
	/// <term>ncsann.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Hourly</term>
	/// <term>ncyymmddhh.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Daily</term>
	/// <term>ncyymmdd.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Weekly</term>
	/// <term>ncyymmww.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Monthly</term>
	/// <term>ncyymm.log</term>
	/// </item>
	/// <item>
	/// <term>W3C Extended Log File Format</term>
	/// <term>Size</term>
	/// <term>extendnn.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Hourly</term>
	/// <term>exyymmddhh.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Daily</term>
	/// <term>exyymmdd.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Weekly</term>
	/// <term>exyymmww.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Monthly</term>
	/// <term>exyymm.log</term>
	/// </item>
	/// </list>
	/// <para>The following table lists time element characters and what they represent.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Item</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>yy</term>
	/// <term>The two digit representation of the year.</term>
	/// </item>
	/// <item>
	/// <term>mm</term>
	/// <term>The two digit representation of the month.</term>
	/// </item>
	/// <item>
	/// <term>ww</term>
	/// <term>The two digit representation of the week.</term>
	/// </item>
	/// <item>
	/// <term>dd</term>
	/// <term>The two digit representation of the day.</term>
	/// </item>
	/// <item>
	/// <term>hh</term>
	/// <term>The two digit representation of the hour in 24 hour notation.</term>
	/// </item>
	/// <item>
	/// <term>nn</term>
	/// <term>The two digit representation of the numerical sequence.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_logging_rollover_type typedef enum _HTTP_LOGGING_ROLLOVER_TYPE {
	// HttpLoggingRolloverSize, HttpLoggingRolloverDaily, HttpLoggingRolloverWeekly, HttpLoggingRolloverMonthly, HttpLoggingRolloverHourly }
	// HTTP_LOGGING_ROLLOVER_TYPE, *PHTTP_LOGGING_ROLLOVER_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_LOGGING_ROLLOVER_TYPE")]
	public enum HTTP_LOGGING_ROLLOVER_TYPE
	{
		/// <summary>The log files are rolled over when they reach a specified size.</summary>
		HttpLoggingRolloverSize,

		/// <summary>The log files are rolled over every day.</summary>
		HttpLoggingRolloverDaily,

		/// <summary>The log files are rolled over every week.</summary>
		HttpLoggingRolloverWeekly,

		/// <summary>The log files are rolled over every month.</summary>
		HttpLoggingRolloverMonthly,

		/// <summary>The log files are rolled over every hour, based on GMT.</summary>
		HttpLoggingRolloverHourly,
	}

	/// <summary>
	/// <para>The <c>HTTP_LOGGING_TYPE</c> enumeration defines the type of logging that is performed.</para>
	/// <para>This enumeration is used in the HTTP_LOGGING_INFO structure.</para>
	/// </summary>
	/// <remarks>
	/// <para>The log files are named based on the rollover type and logging format as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Format</term>
	/// <term>Rollover Type</term>
	/// <term>Filename Pattern</term>
	/// </listheader>
	/// <item>
	/// <term>Microsoft IIS Log Format</term>
	/// <term>Size</term>
	/// <term>inetsvnn.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Hourly</term>
	/// <term>inyymmddhh.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Daily</term>
	/// <term>inyymmdd.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Weekly</term>
	/// <term>inymmww.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Monthly</term>
	/// <term>inyymm.log</term>
	/// </item>
	/// <item>
	/// <term>NCSA Common Log File Format</term>
	/// <term>Size</term>
	/// <term>ncsann.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Hourly</term>
	/// <term>ncyymmddhh.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Daily</term>
	/// <term>ncyymmdd.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Weekly</term>
	/// <term>ncyymmww.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Monthly</term>
	/// <term>ncyymm.log</term>
	/// </item>
	/// <item>
	/// <term>W3C Extended Log File Format</term>
	/// <term>Size</term>
	/// <term>extendnn.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Hourly</term>
	/// <term>exyymmddhh.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Daily</term>
	/// <term>exyymmdd.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Weekly</term>
	/// <term>exyymmww.log</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>Monthly</term>
	/// <term>exyymm.log</term>
	/// </item>
	/// </list>
	/// <para>The following table lists time element characters and what they represent.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Item</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>yy</term>
	/// <term>The two digit representation of the year.</term>
	/// </item>
	/// <item>
	/// <term>mm</term>
	/// <term>The two digit representation of the month.</term>
	/// </item>
	/// <item>
	/// <term>ww</term>
	/// <term>The two digit representation of the week.</term>
	/// </item>
	/// <item>
	/// <term>dd</term>
	/// <term>The two digit representation of the day.</term>
	/// </item>
	/// <item>
	/// <term>hh</term>
	/// <term>The two digit representation of the hour in 24 hour notation.</term>
	/// </item>
	/// <item>
	/// <term>nn</term>
	/// <term>The two digit representation of the numerical sequence.</term>
	/// </item>
	/// </list>
	/// <para>For more information about the log file formats, see IIS Log File Formats.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_logging_type typedef enum _HTTP_LOGGING_TYPE {
	// HttpLoggingTypeW3C, HttpLoggingTypeIIS, HttpLoggingTypeNCSA, HttpLoggingTypeRaw } HTTP_LOGGING_TYPE, *PHTTP_LOGGING_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_LOGGING_TYPE")]
	public enum HTTP_LOGGING_TYPE
	{
		/// <summary>
		/// <para>
		/// The log format is W3C style extended logging. Applications choose the fields that are logged in the Fields member of the
		/// HTTP_LOGGING_INFO structure.
		/// </para>
		/// <para>
		/// When this type of logging is set on a URL Group, logging is similar to the IIS6 site logging. When set on a server session this
		/// format functions as a centralized logging for all of the URL Groups.
		/// </para>
		/// </summary>
		HttpLoggingTypeW3C,

		/// <summary>
		/// The log format is IIS5/6 style logging. This format has a fixed field definition; applications cannot choose which fields are
		/// logged. This format cannot be chosen when setting the logging property on a server session.
		/// </summary>
		HttpLoggingTypeIIS,

		/// <summary>
		/// The log format is NCSA style logging. This format has a fixed field definition; applications cannot choose which fields are
		/// logged. This format cannot be chosen when setting the logging property on a server session.
		/// </summary>
		HttpLoggingTypeNCSA,

		/// <summary>
		/// The log format is centralized binary logging. This format has a fixed field definition; applications cannot choose which fields
		/// are logged. This format cannot be chosen when setting the logging property on a URL Group.
		/// </summary>
		HttpLoggingTypeRaw,
	}

	/// <summary/>
	[PInvokeData("http.h")]
	public enum HTTP_PERFORMANCE_PARAM_TYPE
	{
		/// <summary/>
		PerformanceParamSendBufferingFlags,

		/// <summary/>
		PerformanceParamAggressiveICW,

		/// <summary/>
		PerformanceParamMaxSendBufferSize,

		/// <summary/>
		PerformanceParamMaxConcurrentClientStreams,

		/// <summary/>
		PerformanceParamMaxReceiveBufferSize,

		/// <summary/>
		PerformanceParamDecryptOnSspiThread,

		/// <summary/>
		PerformanceParamMax,
	}

	/// <summary>Defines the protection level types for UrlGroups.</summary>
	[PInvokeData("http.h")]
	public enum HTTP_PROTECTION_LEVEL_TYPE
	{
		/// <summary>
		/// This option will allow edge (NAT) traversed traffic, i.e. Teredo for the UrlGroup, unless there is an admin rule that overwrites
		/// the application's intend.
		/// </summary>
		HttpProtectionLevelUnrestricted,

		/// <summary>This setting will ensure that edge (NAT) traversed traffic will not be allowed.</summary>
		HttpProtectionLevelEdgeRestricted,

		/// <summary>Below type is not supported by HTTP API.</summary>
		HttpProtectionLevelRestricted
	}

	/// <summary>
	/// The <c>HTTP_QOS_SETTING_TYPE</c> enumeration identifies the type of a QOS setting contained in a HTTP_QOS_SETTING_INFO structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_qos_setting_type typedef enum _HTTP_QOS_SETTING_TYPE {
	// HttpQosSettingTypeBandwidth, HttpQosSettingTypeConnectionLimit, HttpQosSettingTypeFlowRate } HTTP_QOS_SETTING_TYPE, *PHTTP_QOS_SETTING_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_QOS_SETTING_TYPE")]
	public enum HTTP_QOS_SETTING_TYPE
	{
		/// <summary>
		/// <para>The setting is a bandwidth limit represented by a <c>HTTP_BANDWIDTH_LIMIT_INFO</c> structure.</para>
		/// </summary>
		HttpQosSettingTypeBandwidth,

		/// <summary>
		/// <para>The setting is a connection limit represented by a <c>HTTP_CONNECTION_LIMIT_INFO</c> structure.</para>
		/// </summary>
		HttpQosSettingTypeConnectionLimit,

		/// <summary>
		/// <para>A flow rate represented by</para>
		/// <para>HTTP_FLOWRATE_INFO</para>
		/// <para>.</para>
		/// <para><c>Note</c> Windows Server 2008 R2 and Windows 7 only.</para>
		/// </summary>
		HttpQosSettingTypeFlowRate,
	}

	/// <summary>A value that modifies the behavior of the <c>HttpReceiveClientCertificate</c> function</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveClientCertificate")]
	[Flags]
	public enum HTTP_RECEIVE : uint
	{
		/// <summary>
		/// The <c>pSslClientCertInfo</c> parameter will be populated with CBT data. This value is supported on Windows 7, Windows Server
		/// 2008 R2, and later.
		/// </summary>
		HTTP_RECEIVE_SECURE_CHANNEL_TOKEN = 0x1,

		/// <summary>Flag to retrieve full certificate chain with HttpReceiveClientCertificate</summary>
		HTTP_RECEIVE_FULL_CHAIN = 0x2,
	}

	/// <summary>A value that modifies the behavior of the <c>HttpReceiveRequestEntityBody</c> function</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveRequestEntityBody")]
	[Flags]
	public enum HTTP_RECEIVE_REQUEST_ENTITY_BODY_FLAG : uint
	{
		/// <summary>
		/// Specifies that the buffer will be filled with one or more entity bodies, unless there are no remaining entity bodies to copy.
		/// </summary>
		HTTP_RECEIVE_REQUEST_ENTITY_BODY_FLAG_FILL_BUFFER = 0x00000001,
	}

	/// <summary>A value that modifies the behavior of the <c>HttpReceiveHttpRequest</c> function</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveHttpRequest")]
	[Flags]
	public enum HTTP_RECEIVE_REQUEST_FLAG : uint
	{
		/// <summary>
		/// The available entity body is copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
		/// points to the entity body.
		/// </summary>
		HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY = 0x00000001,

		/// <summary>
		/// All of the entity bodies are copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
		/// points to the entity body.
		/// </summary>
		HTTP_RECEIVE_REQUEST_FLAG_FLUSH_BODY = 0x00000002,
	}

	/// <summary>The authentication flags that indicate authentication attributes.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_AUTH_INFO")]
	public enum HTTP_REQUEST_AUTH_FLAG
	{
		/// <summary>The provided token is for NTLM and is based on a cached credential of a Keep Alive (KA) connection.</summary>
		HTTP_REQUEST_AUTH_FLAG_TOKEN_FOR_CACHED_CRED = 1
	}

	/// <summary>
	/// <para>The <c>HTTP_REQUEST_AUTH_TYPE</c> enumeration defines the authentication types supported by the HTTP Server API.</para>
	/// <para>This enumeration is used in the HTTP_REQUEST_AUTH_INFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_request_auth_type typedef enum _HTTP_REQUEST_AUTH_TYPE {
	// HttpRequestAuthTypeNone = 0, HttpRequestAuthTypeBasic, HttpRequestAuthTypeDigest, HttpRequestAuthTypeNTLM,
	// HttpRequestAuthTypeNegotiate, HttpRequestAuthTypeKerberos } HTTP_REQUEST_AUTH_TYPE, *PHTTP_REQUEST_AUTH_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_REQUEST_AUTH_TYPE")]
	public enum HTTP_REQUEST_AUTH_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No authentication is attempted for the request.</para>
		/// </summary>
		HttpRequestAuthTypeNone,

		/// <summary>Basic authentication is attempted for the request.</summary>
		HttpRequestAuthTypeBasic,

		/// <summary>Digest authentication is attempted for the request.</summary>
		HttpRequestAuthTypeDigest,

		/// <summary>NTLM authentication is attempted for the request.</summary>
		HttpRequestAuthTypeNTLM,

		/// <summary>Negotiate authentication is attempted for the request.</summary>
		HttpRequestAuthTypeNegotiate,

		/// <summary>Kerberos authentication is attempted for the request.</summary>
		HttpRequestAuthTypeKerberos,
	}

	/// <summary>A combination of zero or more of the following flag values may be combined, with OR, as appropriate.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_V1")]
	[Flags]
	public enum HTTP_REQUEST_FLAG
	{
		/// <summary>
		/// There is more entity body to be read for this request. This applies only to incoming requests that span multiple reads. If this
		/// value is not set, either the whole entity body was copied into the buffer specified by <c>pEntityChunks</c> or the request did
		/// not include an entity body.
		/// </summary>
		HTTP_REQUEST_FLAG_MORE_ENTITY_BODY_EXISTS = 0x00000001,

		/// <summary>
		/// The request was routed based on host and IP binding. The application should reflect the local IP while flushing kernel cache
		/// entries for this request. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
		/// </summary>
		HTTP_REQUEST_FLAG_IP_ROUTED = 0x00000002,

		/// <summary>Indicates the request was received over HTTP/2.</summary>
		HTTP_REQUEST_FLAG_HTTP2 = 0x00000004,

		/// <summary>Indicates the request was received over HTTP/3.</summary>
		HTTP_REQUEST_FLAG_HTTP3 = 0x00000008,
	}

	/// <summary>
	/// <para>The <c>HTTP_REQUEST_INFO_TYPE</c> enumeration defines the type of information contained in the HTTP_REQUEST_INFO structure.</para>
	/// <para>This enumeration is used in the HTTP_REQUEST_INFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_request_info_type typedef enum _HTTP_REQUEST_INFO_TYPE {
	// HttpRequestInfoTypeAuth, HttpRequestInfoTypeChannelBind, HttpRequestInfoTypeSslProtocol, HttpRequestInfoTypeSslTokenBindingDraft,
	// HttpRequestInfoTypeSslTokenBinding, HttpRequestInfoTypeRequestTiming, HttpRequestInfoTypeTcpInfoV0, HttpRequestInfoTypeRequestSizing,
	// HttpRequestInfoTypeQuicStats, HttpRequestInfoTypeTcpInfoV1 } HTTP_REQUEST_INFO_TYPE, *PHTTP_REQUEST_INFO_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_REQUEST_INFO_TYPE")]
	public enum HTTP_REQUEST_INFO_TYPE
	{
		/// <summary>
		/// <para>The request information type is authentication.</para>
		/// <para>The</para>
		/// <para>pInfo</para>
		/// <para>member of the <c>HTTP_REQUEST_INFO</c> structure points to a <c>HTTP_REQUEST_AUTH_INFO</c> structure.</para>
		/// </summary>
		HttpRequestInfoTypeAuth,

		/// <summary/>
		HttpRequestInfoTypeChannelBind,

		/// <summary/>
		HttpRequestInfoTypeSslProtocol,

		/// <summary/>
		HttpRequestInfoTypeSslTokenBindingDraft,

		/// <summary/>
		HttpRequestInfoTypeSslTokenBinding,

		/// <summary/>
		HttpRequestInfoTypeRequestTiming,

		/// <summary/>
		HttpRequestInfoTypeTcpInfoV0,

		/// <summary/>
		HttpRequestInfoTypeRequestSizing,

		/// <summary/>
		HttpRequestInfoTypeQuicStats,

		/// <summary/>
		HttpRequestInfoTypeTcpInfoV1
	}

	/// <summary>The <c>HTTP_REQUEST_PROPERTY</c> enumeration defines the properties that are configured by the HTTP Server API on a request.</summary>
	/// <remarks>
	/// The <c>HTTP_REQUEST_PROPERTY</c> enumeration types are used to set or query the configurations on a request. A member of this
	/// enumeration together with the associated configuration structure is used by HttpSetRequestProperty to define the configuration parameters.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_request_property typedef enum _HTTP_REQUEST_PROPERTY {
	// HttpRequestPropertyIsb, HttpRequestPropertyTcpInfoV0, HttpRequestPropertyQuicStats, HttpRequestPropertyTcpInfoV1,
	// HttpRequestPropertySni, HttpRequestPropertyStreamError, HttpRequestPropertyWskApiTimings, HttpRequestPropertyQuicApiTimings }
	// HTTP_REQUEST_PROPERTY, *PHTTP_REQUEST_PROPERTY;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_REQUEST_PROPERTY")]
	public enum HTTP_REQUEST_PROPERTY
	{
		/// <summary/>
		HttpRequestPropertyIsb,

		/// <summary/>
		HttpRequestPropertyTcpInfoV0,

		/// <summary/>
		HttpRequestPropertyQuicStats,

		/// <summary/>
		HttpRequestPropertyTcpInfoV1,

		/// <summary/>
		[CorrespondingType(typeof(HTTP_REQUEST_PROPERTY_SNI))]
		HttpRequestPropertySni,

		/// <summary>
		/// <para>The HTTP/2 or HTTP/3 stream error on the request.</para>
		/// <para>The HTTP_REQUEST_PROPERTY_STREAM_ERROR structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_REQUEST_PROPERTY_STREAM_ERROR))]
		HttpRequestPropertyStreamError,

		/// <summary/>
		[CorrespondingType(typeof(HTTP_WSK_API_TIMINGS))]
		HttpRequestPropertyWskApiTimings,

		/// <summary/>
		[CorrespondingType(typeof(HTTP_QUIC_API_TIMINGS))]
		HttpRequestPropertyQuicApiTimings
	}

	/// <summary>Flags inside HTTP_REQUEST_PROPERTY_SNI</summary>
	[PInvokeData("http.h")]
	[Flags]
	public enum HTTP_REQUEST_PROPERTY_SNI_FLAG : uint
	{
		/// <summary>
		/// Indicates that SNI was used for succesful endpoint lookup during handshake. If client sent the SNI but Http.sys still decided to
		/// use IP endpoint binding then this flag will not be set.
		/// </summary>
		HTTP_REQUEST_PROPERTY_SNI_FLAG_SNI_USED = 0x00000001,

		/// <summary>
		/// Indicates that client did not send the SNI. If this flag is set, HTTP_REQUEST_PROPERTY_SNI_FLAG_SNI_USED can not be set.
		/// </summary>
		HTTP_REQUEST_PROPERTY_SNI_FLAG_NO_SNI = 0x00000002,
	}

	/// <summary>List of possible sizes for which information will be retured in HTTP_REQUEST_SIZING_INFO.</summary>
	[PInvokeData("http.h")]
	public enum HTTP_REQUEST_SIZING_TYPE
	{
		/// <summary/>
		HttpRequestSizingTypeTlsHandshakeLeg1ClientData, // Inbound/outbound data?

		/// <summary/>
		HttpRequestSizingTypeTlsHandshakeLeg1ServerData,

		/// <summary/>
		HttpRequestSizingTypeTlsHandshakeLeg2ClientData,

		/// <summary/>
		HttpRequestSizingTypeTlsHandshakeLeg2ServerData,

		/// <summary/>
		HttpRequestSizingTypeHeaders,

		/// <summary/>
		HttpRequestSizingTypeMax
	}

	/// <summary>
	/// List of possible request timings for which information will be retured in HTTP_REQUEST_TIMING_INFO. Not all timings apply for every request.
	/// </summary>
	[PInvokeData("http.h")]
	public enum HTTP_REQUEST_TIMING_TYPE
	{
		HttpRequestTimingTypeConnectionStart,
		HttpRequestTimingTypeDataStart,
		HttpRequestTimingTypeTlsCertificateLoadStart,
		HttpRequestTimingTypeTlsCertificateLoadEnd,
		HttpRequestTimingTypeTlsHandshakeLeg1Start,
		HttpRequestTimingTypeTlsHandshakeLeg1End,
		HttpRequestTimingTypeTlsHandshakeLeg2Start,
		HttpRequestTimingTypeTlsHandshakeLeg2End,
		HttpRequestTimingTypeTlsAttributesQueryStart,
		HttpRequestTimingTypeTlsAttributesQueryEnd,
		HttpRequestTimingTypeTlsClientCertQueryStart,
		HttpRequestTimingTypeTlsClientCertQueryEnd,
		HttpRequestTimingTypeHttp2StreamStart,
		HttpRequestTimingTypeHttp2HeaderDecodeStart,
		HttpRequestTimingTypeHttp2HeaderDecodeEnd,
		HttpRequestTimingTypeRequestHeaderParseStart,
		HttpRequestTimingTypeRequestHeaderParseEnd,
		HttpRequestTimingTypeRequestRoutingStart,
		HttpRequestTimingTypeRequestRoutingEnd,
		HttpRequestTimingTypeRequestQueuedForInspection,
		HttpRequestTimingTypeRequestDeliveredForInspection,
		HttpRequestTimingTypeRequestReturnedAfterInspection,
		HttpRequestTimingTypeRequestQueuedForDelegation,
		HttpRequestTimingTypeRequestDeliveredForDelegation,
		HttpRequestTimingTypeRequestReturnedAfterDelegation,
		HttpRequestTimingTypeRequestQueuedForIO,
		HttpRequestTimingTypeRequestDeliveredForIO,
		HttpRequestTimingTypeHttp3StreamStart,
		HttpRequestTimingTypeHttp3HeaderDecodeStart,
		HttpRequestTimingTypeHttp3HeaderDecodeEnd,
		HttpRequestTimingTypeMax
	}

	/// <summary>
	/// <para>The <c>HTTP_RESPONSE_FLAG_</c> constants define options to configure responses in the HTTP Server API.</para>
	/// <para>These constants are used in the <c>Flags</c> member of the <c>HTTP_RESPONSE_V1</c> structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/http/http-response-flag--constants
	[PInvokeData("http.h")]
	[Flags]
	public enum HTTP_RESPONSE_FLAGS : uint
	{
		/// <summary>
		/// Encodings other than identity form are available for this resource. This flag is ignored if the application has not asked for the
		/// response to be cached. It's used as a hint to the HTTP Server API for content negotiation when serving from the kernel response cache.
		/// </summary>
		HTTP_RESPONSE_FLAG_MULTIPLE_ENCODINGS_AVAILABLE = 0x00000001,

		/// <summary>
		/// There is more entity body to be read for this response. Otherwise, there is no entity body or all of the entity body was copied
		/// into pEntityChunks.
		/// </summary>
		HTTP_RESPONSE_FLAG_MORE_ENTITY_BODY_EXISTS = 0x00000002,
	}

	/// <summary>
	/// The flags corresponding to the response header in the <c>HeaderId</c> member. This member is used only when the WWW-Authenticate
	/// header is present.
	/// </summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_MULTIPLE_KNOWN_HEADERS")]
	public enum HTTP_RESPONSE_INFO_FLAGS
	{
		/// <summary>The specified order of authentication schemes is preserved on the challenge response.</summary>
		HTTP_RESPONSE_INFO_FLAGS_PRESERVE_ORDER = 1
	}

	/// <summary>
	/// <para>The <c>HTTP_RESPONSE_INFO_TYPE</c> enumeration defines the type of information contained in the HTTP_RESPONSE_INFO structure.</para>
	/// <para>This enumeration is used in the HTTP_RESPONSE_INFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_response_info_type typedef enum _HTTP_RESPONSE_INFO_TYPE {
	// HttpResponseInfoTypeMultipleKnownHeaders, HttpResponseInfoTypeAuthenticationProperty, HttpResponseInfoTypeQoSProperty,
	// HttpResponseInfoTypeChannelBind } HTTP_RESPONSE_INFO_TYPE, PHTTP_RESPONSE_INFO_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_RESPONSE_INFO_TYPE")]
	public enum HTTP_RESPONSE_INFO_TYPE
	{
		/// <summary>
		/// <para>The response information type is authentication.</para>
		/// <para>The pInfo member of the HTTP_RESPONSE_INFO structure points to a HTTP_MULTIPLE_KNOWN_HEADERS structure.</para>
		/// </summary>
		HttpResponseInfoTypeMultipleKnownHeaders,

		/// <summary>Reserved for future use.</summary>
		HttpResponseInfoTypeAuthenticationProperty,

		/// <summary>
		/// <para>Pointer to an HTTP_QOS_SETTING_INFO structure that contains information about a QOS setting.</para>
		/// </summary>
		HttpResponseInfoTypeQoSProperty,

		/// <summary>
		/// <para>Pointer to an HTTP_CHANNEL_BIND_INFO structure that contains information on the channel binding token.</para>
		/// </summary>
		HttpResponseInfoTypeChannelBind,
	}

	/// <summary>Flags values for <c>HttpSendHttpResponse</c>.</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendHttpResponse")]
	[Flags]
	public enum HTTP_SEND_RESPONSE_FLAG : uint
	{
		/// <summary>
		/// The network connection should be disconnected after sending this response, overriding any persistent connection features
		/// associated with the version of HTTP in use.
		/// </summary>
		HTTP_SEND_RESPONSE_FLAG_DISCONNECT = 0x00000001,

		/// <summary>
		/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
		/// HttpSendResponseEntityBody. The last call sending entity-body data then sets this flag to zero.
		/// </summary>
		HTTP_SEND_RESPONSE_FLAG_MORE_DATA = 0x00000002,

		/// <summary>
		/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous
		/// I/O or by an application doing asynchronous I/O with no more than one outstanding send at a time. Applications that use
		/// asynchronous I/O and that may have more than one send outstanding at a time should not use this flag. When this flag is set, it
		/// should also be used consistently in calls to the HttpSendResponseEntityBody function. <c>Windows Server 2003:</c> This flag is
		/// not supported. This flag is new for Windows Server 2003 with SP1.
		/// </summary>
		HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA = 0x00000004,

		/// <summary>
		/// Enables the TCP nagling algorithm for this send only. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is
		/// not supported.
		/// </summary>
		HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING = 0x00000008,

		/// <summary>
		/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
		/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
		/// </summary>
		HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES = 0x00000020,

		/// <summary>
		/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
		/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
		/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
		/// <c>HttpSendHttpResponse</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used.
		/// <c>Windows 8 and later:</c> This flag is supported.
		/// </summary>
		HTTP_SEND_RESPONSE_FLAG_OPAQUE = 0x00000040,

		/// <summary>For HTTP/2 and HTTP/3, this results in sending a GOAWAY frame and will cause the client to move to a different connection.</summary>
		HTTP_SEND_RESPONSE_FLAG_GOAWAY = 0x00000100,
	}

	/// <summary>
	/// The <c>HTTP_SERVER_PROPERTY</c> enumeration defines the properties that are configured by the HTTP Server API on a URL group, server
	/// session, or request queue.
	/// </summary>
	/// <remarks>
	/// The <c>HTTP_SERVER_PROPERTY</c> enumeration types are used to set or query the configurations on a server session, URL group, or
	/// request queue. A member of this enumeration together with the associated configuration structure is used by
	/// HttpQueryRequestQueueProperty, HttpQueryServerSessionProperty, HttpQueryUrlGroupProperty, HttpSetRequestQueueProperty,
	/// HttpSetServerSessionProperty, and HttpSetUrlGroupProperty to define the configuration parameters.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_server_property typedef enum _HTTP_SERVER_PROPERTY {
	// HttpServerAuthenticationProperty = 0, HttpServerLoggingProperty = 1, HttpServerQosProperty = 2, HttpServerTimeoutsProperty = 3,
	// HttpServerQueueLengthProperty = 4, HttpServerStateProperty = 5, HttpServer503VerbosityProperty = 6, HttpServerBindingProperty = 7,
	// HttpServerExtendedAuthenticationProperty = 8, HttpServerListenEndpointProperty = 9, HttpServerChannelBindProperty = 10,
	// HttpServerProtectionLevelProperty = 11, HttpServerDelegationProperty } HTTP_SERVER_PROPERTY, *PHTTP_SERVER_PROPERTY;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_SERVER_PROPERTY")]
	public enum HTTP_SERVER_PROPERTY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// The authentication property enables server-side authentication for a URL group, or server session using the Basic, NTLM,
		/// Negotiate, and Digest authentication schemes.
		/// </para>
		/// <para>The <c>HTTP_SERVER_AUTHENTICATION_INFO</c> structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_SERVER_AUTHENTICATION_INFO))]
		HttpServerAuthenticationProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The logging property enables logging for a server session or URL group.</para>
		/// <para>The <c>HTTP_LOGGING_INFO</c> structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_LOGGING_INFO))]
		HttpServerLoggingProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// The QOS property enables settings affecting quality of service, such as limiting the maximum number of outstanding connections
		/// served for a URL group at any given time or limiting the response send bandwidth for a server session or URL group.
		/// </para>
		/// <para>The <c>HTTP_QOS_SETTING_INFO</c> structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_QOS_SETTING_INFO))]
		HttpServerQosProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The timeouts property configures timeouts for a server session or URL group.</para>
		/// <para>The <c>HTTP_TIMEOUT_LIMIT_INFO</c> structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_TIMEOUT_LIMIT_INFO))]
		HttpServerTimeoutsProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The connections property limits the number of requests in the request queue. This is a ULONG.</para>
		/// </summary>
		[CorrespondingType(typeof(uint))]
		HttpServerQueueLengthProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The connections property configures the state of a URL group, server session, or request queue.</para>
		/// <para>
		/// The <c>HTTP_STATE_INFO</c> structure contains the configuration data for this property for the URL group or server session. The
		/// request queue uses the <c>HTTP_ENABLED_STATE</c> enumeration to configure this property.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_STATE_INFO))]
		HttpServerStateProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>
		/// The 503 verbosity property configures the verbosity level of 503 responses generated by the HTTP Server API for a request queue.
		/// </para>
		/// <para>The <c>HTTP_503_RESPONSE_VERBOSITY</c> enumeration contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_503_RESPONSE_VERBOSITY))]
		HttpServer503VerbosityProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The binding property associates a URL group with a request queue.</para>
		/// <para>The <c>HTTP_BINDING_INFO</c> structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_BINDING_INFO))]
		HttpServerBindingProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>
		/// The extended authentication property enables server-side authentication for a URL group, or server session using the Kerberos
		/// authentication scheme.
		/// </para>
		/// <para>The <c>HTTP_SERVER_AUTHENTICATION_INFO</c> structure contains the configuration data for this property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_SERVER_AUTHENTICATION_INFO))]
		HttpServerExtendedAuthenticationProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Listening endpoint property.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_LISTEN_ENDPOINT_INFO))]
		HttpServerListenEndpointProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>This property implements authorization channel binding.</para>
		/// <para>The <c>HTTP_CHANNEL_BIND_INFO</c> structure contains the authorization details.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_CHANNEL_BIND_INFO))]
		HttpServerChannelBindProperty,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_PROTECTION_LEVEL_INFO))]
		HttpServerProtectionLevelProperty,

		/// <summary>Used for manipulating Url Group to Delegate Request Queue association.</summary>
		HttpServerDelegationProperty = 16,
	}

	/// <summary>The <c>HTTP_SERVICE_BINDING_TYPE</c> enumerated type specifies the string type for service names.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_binding_type typedef enum _HTTP_SERVICE_BINDING_TYPE {
	// HttpServiceBindingTypeNone = 0, HttpServiceBindingTypeW, HttpServiceBindingTypeA } HTTP_SERVICE_BINDING_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_SERVICE_BINDING_TYPE")]
	public enum HTTP_SERVICE_BINDING_TYPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No type.</para>
		/// </summary>
		HttpServiceBindingTypeNone,

		/// <summary>Unicode.</summary>
		HttpServiceBindingTypeW,

		/// <summary>ASCII</summary>
		HttpServiceBindingTypeA,
	}

	/// <summary>Used in the HttpSetServiceConfiguration and HttpQueryServiceConfiguration functions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_cache_key typedef enum
	// _HTTP_SERVICE_CONFIG_CACHE_KEY { MaxCacheResponseSize = 0, CacheRangeChunkSize } HTTP_SERVICE_CONFIG_CACHE_KEY, *PHTTP_SERVICE_CONFIG_CACHE_KEY;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_SERVICE_CONFIG_CACHE_KEY")]
	public enum HTTP_SERVICE_CONFIG_CACHE_KEY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The maximum cache size for the response.</para>
		/// </summary>
		MaxCacheResponseSize,

		/// <summary>The chunk size.</summary>
		CacheRangeChunkSize,
	}

	/// <summary>The <c>HTTP_SERVICE_CONFIG_ID</c> enumeration type defines service configuration options.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_id typedef enum _HTTP_SERVICE_CONFIG_ID {
	// HttpServiceConfigIPListenList, HttpServiceConfigSSLCertInfo, HttpServiceConfigUrlAclInfo, HttpServiceConfigTimeout,
	// HttpServiceConfigCache, HttpServiceConfigSslSniCertInfo, HttpServiceConfigSslCcsCertInfo, HttpServiceConfigSetting,
	// HttpServiceConfigSslCertInfoEx, HttpServiceConfigSslSniCertInfoEx, HttpServiceConfigSslCcsCertInfoEx,
	// HttpServiceConfigSslScopedCcsCertInfo, HttpServiceConfigSslScopedCcsCertInfoEx, HttpServiceConfigMax } HTTP_SERVICE_CONFIG_ID, *PHTTP_SERVICE_CONFIG_ID;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_SERVICE_CONFIG_ID")]
	public enum HTTP_SERVICE_CONFIG_ID
	{
		/// <summary>Specifies the IP Listen List used to register IP addresses on which to listen for SSL connections.</summary>
		[CorrespondingType(typeof(HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM))]
		HttpServiceConfigIPListenList,

		/// <summary>
		/// <para>Specifies the SSL certificate store.</para>
		/// <para>
		/// <c>Note</c> If SSL is enabled in the HTTP Server API, TLS 1.0 may be used in place of SSL when the client application specifies TLS.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_SERVICE_CONFIG_SSL_SET))]
		HttpServiceConfigSSLCertInfo,

		/// <summary>Specifies the URL reservation store.</summary>
		[CorrespondingType(typeof(HTTP_SERVICE_CONFIG_URLACL_SET))]
		HttpServiceConfigUrlAclInfo,

		/// <summary>
		/// <para>Configures the HTTP Server API wide connection timeouts.</para>
		/// <para><c>Note</c> Windows Vista and later versions of Windows</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_SERVICE_CONFIG_TIMEOUT_SET))]
		HttpServiceConfigTimeout,

		/// <summary>
		/// <para>Used in the HttpQueryServiceConfiguration and HttpSetServiceConfiguration functions.</para>
		/// <para><c>Note</c> Windows Server 2008 R2 and Windows 7 and later versions of Windows.</para>
		/// </summary>
		HttpServiceConfigCache,

		/// <summary>
		/// <para>
		/// Specifies the SSL endpoint configuration with Hostname:Port as key. Used in the HttpDeleteServiceConfiguration,
		/// HttpQueryServiceConfiguration, HttpSetServiceConfiguration, and HttpUpdateServiceConfiguration functions
		/// </para>
		/// <para><c>Note</c> Windows 8 and later versions of Windows.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_SERVICE_CONFIG_SSL_SNI_SET))]
		HttpServiceConfigSslSniCertInfo,

		/// <summary>
		/// <para>
		/// Specifies that an operation should be performed for the SSL certificate record that specifies that Http.sys should consult the
		/// Centralized Certificate Store (CCS) store to find certificates if the port receives a Transport Layer Security (TLS) handshake.
		/// Used in the HttpDeleteServiceConfiguration, HttpQueryServiceConfiguration, HttpSetServiceConfiguration, and
		/// HttpUpdateServiceConfiguration functions
		/// </para>
		/// <para><c>Note</c> Windows 8 and later versions of Windows.</para>
		/// </summary>
		[CorrespondingType(typeof(HTTP_SERVICE_CONFIG_SSL_CCS_SET))]
		HttpServiceConfigSslCcsCertInfo,

		/// <summary/>
		HttpServiceConfigSetting,

		/// <summary/>
		HttpServiceConfigSslCertInfoEx,

		/// <summary/>
		HttpServiceConfigSslSniCertInfoEx,

		/// <summary/>
		HttpServiceConfigSslCcsCertInfoEx,

		/// <summary/>
		HttpServiceConfigSslScopedCcsCertInfo,

		/// <summary/>
		HttpServiceConfigSslScopedCcsCertInfoEx,

		/// <summary>Terminates the enumeration; is not used to define a service configuration option.</summary>
		HttpServiceConfigMax,
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_QUERY_TYPE</c> enumeration type defines various types of queries to make. It is used in the
	/// HTTP_SERVICE_CONFIG_SSL_QUERY, HTTP_SERVICE_CONFIG_SSL_CCS_QUERY, and HTTP_SERVICE_CONFIG_URLACL_QUERY structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_query_type typedef enum
	// _HTTP_SERVICE_CONFIG_QUERY_TYPE { HttpServiceConfigQueryExact, HttpServiceConfigQueryNext, HttpServiceConfigQueryMax }
	// HTTP_SERVICE_CONFIG_QUERY_TYPE, *PHTTP_SERVICE_CONFIG_QUERY_TYPE;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_SERVICE_CONFIG_QUERY_TYPE")]
	public enum HTTP_SERVICE_CONFIG_QUERY_TYPE
	{
		/// <summary>The query returns a single record that matches the specified key value.</summary>
		HttpServiceConfigQueryExact,

		/// <summary>
		/// The query iterates through the store and returns all records in sequence, using an index value that the calling process
		/// increments between query calls.
		/// </summary>
		HttpServiceConfigQueryNext,

		/// <summary>Terminates the enumeration; is not used to define a query type.</summary>
		HttpServiceConfigQueryMax,
	}

	/// <summary>Controls config settings</summary>
	[PInvokeData("http.h")]
	public enum HTTP_SERVICE_CONFIG_SETTING_KEY
	{
		HttpNone = 0,
		HttpTlsThrottle
	}

	/// <summary>A combination of zero or more of the following flag values can be combined with OR as appropriate.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_PARAM")]
	[Flags]
	public enum HTTP_SERVICE_CONFIG_SSL_FLAG
	{
		/// <summary>
		/// Client certificates are mapped where possible to corresponding operating-system user accounts based on the certificate mapping
		/// rules stored in Active Directory. If this flag is set and the mapping is successful, the <c>Token</c> member of the
		/// HTTP_SSL_CLIENT_CERT_INFO structure is a handle to an access token. Release this token explicitly by closing the handle when the
		/// <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure is no longer required.
		/// </summary>
		HTTP_SERVICE_CONFIG_SSL_FLAG_USE_DS_MAPPER = 0x00000001,

		/// <summary>Enables a client certificate to be cached locally for subsequent use.</summary>
		HTTP_SERVICE_CONFIG_SSL_FLAG_NEGOTIATE_CLIENT_CERT = 0x00000002,

		/// <summary>Prevents SSL requests from being passed to low-level ISAPI filters.</summary>
		HTTP_SERVICE_CONFIG_SSL_FLAG_NO_RAW_FILTER = 0x00000004,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_REJECT = 0x00000008,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_HTTP2 = 0x00000010,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_QUIC = 0x00000020,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_TLS13 = 0x00000040,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_OCSP_STAPLING = 0x00000080,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_ENABLE_TOKEN_BINDING = 0x00000100,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_LOG_EXTENDED_EVENTS = 0x00000200,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_LEGACY_TLS = 0x00000400,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_ENABLE_SESSION_TICKET = 0x00000800,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_TLS12 = 0x00001000,

		/// <summary/>
		HTTP_SERVICE_CONFIG_SSL_FLAG_ENABLE_CLIENT_CORRELATION = 0x00002000,
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_TIMEOUT_KEY</c> enumeration defines the type of timer that is queried or configured through the
	/// HTTP_SERVICE_CONFIG_TIMEOUT_SET structure.
	/// </summary>
	/// <remarks>
	/// The <c>HTTP_SERVICE_CONFIG_TIMEOUT_KEY</c> enumeration is used in the HTTP_SERVICE_CONFIG_TIMEOUT_SET structure to define the type of
	/// timer that is configured. The <c>HTTP_SERVICE_CONFIG_TIMEOUT_SET</c> structure passes data to the HTTPSetServiceConfiguration
	/// function through the <c>pConfigInformation</c> parameter or retrieves data from the HTTPQueryServiceConfiguration function through
	/// the <c>pOutputConfigInformation</c> parameter when the <c>ConfigId</c> parameter of either function is equal to <c>HttpServiceConfigTimeout</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_timeout_key typedef enum
	// _HTTP_SERVICE_CONFIG_TIMEOUT_KEY { IdleConnectionTimeout = 0, HeaderWaitTimeout } HTTP_SERVICE_CONFIG_TIMEOUT_KEY, *PHTTP_SERVICE_CONFIG_TIMEOUT_KEY;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_SERVICE_CONFIG_TIMEOUT_KEY")]
	public enum HTTP_SERVICE_CONFIG_TIMEOUT_KEY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The maximum time allowed for a connection to remain idle, after which, the connection is timed out and reset.</para>
		/// </summary>
		IdleConnectionTimeout,

		/// <summary>
		/// The maximum time allowed to parse all the request headers, including the request line, after which, the connection is timed out
		/// and reset.
		/// </summary>
		HeaderWaitTimeout,
	}

	/// <summary>The extended param type for the SSL extended params.</summary>
	[PInvokeData("http.h")]
	public enum HTTP_SSL_SERVICE_CONFIG_EX_PARAM_TYPE
	{
		ExParamTypeHttp2Window,
		ExParamTypeHttp2SettingsLimits,
		ExParamTypeHttpPerformance,
		ExParamTypeTlsRestrictions,
		ExParamTypeErrorHeaders,
		ExParamTypeTlsSessionTicketKeys,
		ExParamTypeMax
	}

	/// <summary>The enum type for HTTP Scheme.</summary>
	[PInvokeData("http.h")]
	public enum HTTP_URI_SCHEME
	{
		HttpSchemeHttp,
		HttpSchemeHttps,
		HttpSchemeMaximum
	}

	/// <summary>The URL flags qualifying the URL that is removed.</summary>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpRemoveUrlFromUrlGroup")]
	[Flags]
	public enum HTTP_URL_FLAG : uint
	{
		/// <summary>Removes all of the URLs currently registered with the URL Group.</summary>
		HTTP_URL_FLAG_REMOVE_ALL = 0x00000001,
	}

	/// <summary>
	/// The <c>HTTP_VERB</c> enumeration type defines values that are used to specify known, standard HTTP verbs in the HTTP_REQUEST
	/// structure. The majority of these known verbs are documented in RFC 2616 and RFC 2518, as indicated below.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ne-http-http_verb typedef enum _HTTP_VERB { HttpVerbUnparsed, HttpVerbUnknown,
	// HttpVerbInvalid, HttpVerbOPTIONS, HttpVerbGET, HttpVerbHEAD, HttpVerbPOST, HttpVerbPUT, HttpVerbDELETE, HttpVerbTRACE,
	// HttpVerbCONNECT, HttpVerbTRACK, HttpVerbMOVE, HttpVerbCOPY, HttpVerbPROPFIND, HttpVerbPROPPATCH, HttpVerbMKCOL, HttpVerbLOCK,
	// HttpVerbUNLOCK, HttpVerbSEARCH, HttpVerbMaximum } HTTP_VERB, *PHTTP_VERB;
	[PInvokeData("http.h", MSDNShortId = "NE:http._HTTP_VERB")]
	public enum HTTP_VERB
	{
		/// <summary>Not relevant for applications; used only in kernel mode.</summary>
		HttpVerbUnparsed,

		/// <summary>
		/// <para>
		/// Indicates that the application can examine the UnknownVerbLength and pUnknownVerb members of the <c>HTTP_REQUEST</c> structure to
		/// retrieve the HTTP verb for the request. This is the case in an HTTP/1.1 request when a browser client specifies a custom verb.
		/// </para>
		/// </summary>
		HttpVerbUnknown,

		/// <summary>Not relevant for applications; used only in kernel mode.</summary>
		HttpVerbInvalid,

		/// <summary>
		/// <para>The OPTIONS method requests information about the communication options and requirements associated with a URI.</para>
		/// <para>See page 52 of RFC 2616.</para>
		/// </summary>
		HttpVerbOPTIONS,

		/// <summary>
		/// <para>
		/// The GET method retrieves the information or entity that is identified by the URI of the Request. If that URI refers to a script
		/// or other data-producing process, it is the data produced, not the text of the script, that is returned in the response.
		/// </para>
		/// <para>
		/// A GET method can be made conditional or partial by including a conditional or Range header field in the request. A conditional
		/// GET requests that the entity be sent only if all conditions specified in the header are met, and a partial GET requests only part
		/// of the entity, as specified in the Range header. Both of these forms of GET can help avoid unnecessary network traffic.
		/// </para>
		/// <para>See page 53 of RFC 2616.</para>
		/// </summary>
		HttpVerbGET,

		/// <summary>
		/// <para>
		/// The HEAD method is identical to GET except that the server only returns message-headers in the response, without a message-body.
		/// The headers are the same as would be returned in response to a GET.
		/// </para>
		/// <para>See page 54 of RFC 2616.</para>
		/// </summary>
		HttpVerbHEAD,

		/// <summary>
		/// <para>The POST method is used to post a new entity as an addition to a URI.</para>
		/// <para>The URI identifies an entity that consumes the posted data in some fashion.</para>
		/// <para>See page 54 of RFC 2616.</para>
		/// </summary>
		HttpVerbPOST,

		/// <summary>
		/// <para>The PUT method is used to replace an entity identified by a URI.</para>
		/// <para>See page 55 of RFC 2616.</para>
		/// </summary>
		HttpVerbPUT,

		/// <summary>
		/// <para>The</para>
		/// <para>DELETE method requests that a specified URI be deleted.</para>
		/// <para>See page 56 of RFC 2616.</para>
		/// </summary>
		HttpVerbDELETE,

		/// <summary>
		/// <para>The TRACE method invokes a remote, application-layer loop-back of the request message.</para>
		/// <para>
		/// It allows the client to see what is being received at the other end of the request chain for diagnostic purposes. See page 56 of
		/// RFC 2616.
		/// </para>
		/// </summary>
		HttpVerbTRACE,

		/// <summary>
		/// <para>
		/// The CONNECT method can be used with a proxy that can dynamically switch to tunneling, as in the case of SSL tunneling. See page
		/// 57 of RFC 2616.
		/// </para>
		/// </summary>
		HttpVerbCONNECT,

		/// <summary>The TRACK method is used by Microsoft Cluster Server to implement a non-logged trace.</summary>
		HttpVerbTRACK,

		/// <summary>
		/// <para>
		/// The MOVE method requests a WebDAV operation equivalent to a copy (COPY), followed by consistency maintenance processing, followed
		/// by a delete of the source, where all three actions are performed atomically. When applied to a collection, "Depth" is assumed to
		/// be or must be specified as "infinity". See page 42 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbMOVE,

		/// <summary>
		/// <para>
		/// The COPY method requests a WebDAV operation that creates a duplicate of the source resource, identified by the Request URI, in
		/// the destination resource, identified by a URI specified in the Destination header. See page 37 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbCOPY,

		/// <summary>
		/// <para>
		/// The PROPFIND method requests a WebDAV operation that retrieves properties defined on the resource identified by the Request-URI.
		/// See page 24 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbPROPFIND,

		/// <summary>
		/// <para>
		/// The PROPPATCH method requests a WebDAV operation that sets and/or removes properties defined on the resource identified by the
		/// Request-URI. See page 31 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbPROPPATCH,

		/// <summary>
		/// <para>
		/// The MKCOL method requests a WebDAV operation that creates a new collection resource at the location specified by the Request-URI.
		/// See page 33 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbMKCOL,

		/// <summary>
		/// <para>
		/// The LOCK method requests a WebDAV operation that creates a lock as specified by the lockinfo XML element on the Request-URI. See
		/// page 45 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbLOCK,

		/// <summary>
		/// <para>
		/// The UNLOCK method requests a WebDAV operation that removes a lock, identified by a lock token in the Lock-Token request header,
		/// from the resource identified by the Request-URI, and from all other resources included in the lock. See page 51 of RFC 2518.
		/// </para>
		/// </summary>
		HttpVerbUNLOCK,

		/// <summary>
		/// <para>
		/// The SEARCH method requests a WebDAV operation used by Microsoft Exchange to search folders. See the Internet Engineering Task
		/// Force (IETF) Internet Draft WebDAV SEARCH for more information, and the WebDAV Web site for possible updates.
		/// </para>
		/// </summary>
		HttpVerbSEARCH,

		/// <summary>Terminates the enumeration; is not used to define a verb.</summary>
		HttpVerbMaximum,
	}
}