global using System;
global using System.Collections.Generic;
global using System.Runtime.InteropServices;
global using Vanara.Extensions;
global using Vanara.InteropServices;

global using static Vanara.PInvoke.Ws2_32;

global using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
global using HTTP_OPAQUE_ID = System.UInt64;
global using HTTP_REQUEST_ID = System.UInt64;
global using HTTP_CONNECTION_ID = System.UInt64;
global using HTTP_RAW_CONNECTION_ID = System.UInt64;
global using HTTP_URL_GROUP_ID = System.UInt64;
global using HTTP_SERVER_SESSION_ID = System.UInt64;
global using HTTP_CLIENT_REQUEST_ID = System.UInt64;
global using HTTP_CLIENT_STREAM_ID = System.UInt64;
global using HTTP_CLIENT_CONNECTION_ID = System.UInt64;
global using HTTP_URL_CONTEXT = System.UInt64;
global using HTTP_SERVICE_CONFIG_SETTING_PARAM = System.UInt32;

namespace Vanara.PInvoke;

/// <summary>Items from HttpApi.dll.</summary>
public static partial class HttpApi
{
	private const string Lib_Httpapi = "httpapi.dll";

	/// <summary/>
	public const int HTTP_REQUEST_PROPERTY_SNI_HOST_MAX_LENGTH = 255;
	/// <summary/>
	public const int HTTP_MAX_SERVER_QUEUE_LENGTH = 0x7FFFFFFF;
	/// <summary/>
	public const int HTTP_MIN_SERVER_QUEUE_LENGTH = 1;

	/// <summary>
	/// Bandwidth throttling limit can not be set lower than the following number. The value is in bytes/sec.
	/// </summary>
	public const uint HTTP_MIN_ALLOWED_BANDWIDTH_THROTTLING_RATE = 1024;

	/// <summary>
	/// Distinguished value for bandwidth, connection limits and logging rollover
	/// size indicating "no limit".
	/// </summary>
	public const int HTTP_LIMIT_INFINITE = -1;

	/// <summary>
	/// Log file rollover size can not be set lower than the following limit. The value is in bytes.
	/// </summary>
	public const uint HTTP_MIN_ALLOWED_LOG_FILE_ROLLOVER_SIZE = 1U * 1024 * 1024;

	/// <summary/>
	public const HTTP_OPAQUE_ID HTTP_NULL_ID = 0;

	/*

// Macros for opaque identifier manipulations.
//


#define HTTP_IS_NULL_ID(pid)    (HTTP_NULL_ID == *(pid))
#define HTTP_SET_NULL_ID(pid)   (*(pid) = HTTP_NULL_ID)

//
// This structure defines a file byte range.
//
// If the Length field is HTTP_BYTE_RANGE_TO_EOF then the remainder of the
// file (everything after StartingOffset) is sent.
//

public const ulong HTTP_BYTE_RANGE_TO_EOF = ulong.MaxValue;


// Flag values for HTTP_REQUEST_SIZING_INFO
//

HTTP_REQUEST_SIZING_INFO_FLAG_TCP_FAST_OPEN = 0x00000001,
HTTP_REQUEST_SIZING_INFO_FLAG_TLS_SESSION_RESUMPTION = 0x00000002,
HTTP_REQUEST_SIZING_INFO_FLAG_TLS_FALSE_START = 0x00000004,
HTTP_REQUEST_SIZING_INFO_FLAG_FIRST_REQUEST = 0x00000008,

public const int HTTP_REQUEST_AUTH_FLAG_TOKEN_FOR_CACHED_CRED = (0x00000001);
	//
	// Values for HTTP_REQUEST::Flags. Zero or more of these may be ORed together.
	//
	// HTTP_REQUEST_FLAG_MORE_ENTITY_BODY_EXISTS - there is more entity body
	// to be read for this request. Otherwise, there is no entity body or
	// all of the entity body was copied into pEntityChunks.
	// HTTP_REQUEST_FLAG_IP_ROUTED - This flag indicates that the request has been
	// routed based on host plus ip or ip binding.This is a hint for the application
	// to include the local ip while flushing kernel cache entries build for this
	// request if any.
	// HTTP_REQUEST_FLAG_HTTP2 - Indicates the request was received over HTTP/2.
	// HTTP_REQUEST_FLAG_HTTP3 - Indicates the request was received over HTTP/3.
	//

	HTTP_REQUEST_FLAG_MORE_ENTITY_BODY_EXISTS = 0x00000001,
HTTP_REQUEST_FLAG_IP_ROUTED = 0x00000002,
HTTP_REQUEST_FLAG_HTTP2 = 0x00000004,
HTTP_REQUEST_FLAG_HTTP3 = 0x00000008,
// Values for HTTP_RESPONSE::Flags.
//
// HTTP_RESPONSE_FLAG_MULTIPLE_ENCODINGS_AVAILABLE - Set this flag if encodings
// other than identity form are available for this resource.This flag is ignored
// if application has not asked for response to be cached. It's used as a hint
// to the Http Server API for content negotiation  used when serving from the
// the kernel response cache.
//
// HTTP_RESPONSE_FLAG_MORE_ENTITY_BODY_EXISTS - there is more entity body
// to be read for this response.  Otherwise, there is no entity body or
// all of the entity body was copied into pEntityChunks.
//


HTTP_RESPONSE_INFO_FLAGS_PRESERVE_ORDER = 0x00000001,
// The SSL config flags.
//

HTTP_SERVICE_CONFIG_SSL_FLAG_USE_DS_MAPPER = 0x00000001,
HTTP_SERVICE_CONFIG_SSL_FLAG_NEGOTIATE_CLIENT_CERT = 0x00000002,
HTTP_SERVICE_CONFIG_SSL_FLAG_NO_RAW_FILTER = 0x00000004,
HTTP_SERVICE_CONFIG_SSL_FLAG_REJECT = 0x00000008,
HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_HTTP2 = 0x00000010,
HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_QUIC = 0x00000020,
HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_TLS13 = 0x00000040,
HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_OCSP_STAPLING = 0x00000080,
HTTP_SERVICE_CONFIG_SSL_FLAG_ENABLE_TOKEN_BINDING = 0x00000100,
HTTP_SERVICE_CONFIG_SSL_FLAG_LOG_EXTENDED_EVENTS = 0x00000200,
HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_LEGACY_TLS = 0x00000400,
HTTP_SERVICE_CONFIG_SSL_FLAG_ENABLE_SESSION_TICKET = 0x00000800,
HTTP_SERVICE_CONFIG_SSL_FLAG_DISABLE_TLS12 = 0x00001000,
HTTP_SERVICE_CONFIG_SSL_FLAG_ENABLE_CLIENT_CORRELATION = 0x00002000,
	*/
}