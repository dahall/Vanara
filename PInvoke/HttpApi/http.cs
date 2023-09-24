global using System;
global using System.Collections.Generic;
global using System.Runtime.InteropServices;
global using Vanara.Extensions;
global using Vanara.InteropServices;
global using static Vanara.PInvoke.Ws2_32;
global using HTTP_SERVICE_CONFIG_SETTING_PARAM = System.UInt32;
global using HTTP_CONNECTION_ID = System.UInt64;
global using HTTP_OPAQUE_ID = System.UInt64;
global using HTTP_RAW_CONNECTION_ID = System.UInt64;
global using HTTP_REQUEST_ID = System.UInt64;
global using HTTP_SERVER_SESSION_ID = System.UInt64;
global using HTTP_URL_CONTEXT = System.UInt64;
global using HTTP_URL_GROUP_ID = System.UInt64;

namespace Vanara.PInvoke;

/// <summary>Items from HttpApi.dll.</summary>
public static partial class HttpApi
{
	private const string Lib_Httpapi = "httpapi.dll";

	/// <summary>If the Length field is HTTP_BYTE_RANGE_TO_EOF then the remainder of the file (everything after StartingOffset) is sent.</summary>
	public const ulong HTTP_BYTE_RANGE_TO_EOF = ulong.MaxValue;

	/// <summary>Distinguished value for bandwidth, connection limits and logging rollover size indicating "no limit".</summary>
	public const int HTTP_LIMIT_INFINITE = -1;

	/// <summary/>
	public const int HTTP_MAX_SERVER_QUEUE_LENGTH = 0x7FFFFFFF;

	/// <summary>Bandwidth throttling limit can not be set lower than the following number. The value is in bytes/sec.</summary>
	public const uint HTTP_MIN_ALLOWED_BANDWIDTH_THROTTLING_RATE = 1024;

	/// <summary>Log file rollover size can not be set lower than the following limit. The value is in bytes.</summary>
	public const uint HTTP_MIN_ALLOWED_LOG_FILE_ROLLOVER_SIZE = 1U * 1024 * 1024;

	/// <summary/>
	public const int HTTP_MIN_SERVER_QUEUE_LENGTH = 1;

	/// <summary/>
	public const HTTP_OPAQUE_ID HTTP_NULL_ID = 0;

	/// <summary/>
	public const int HTTP_REQUEST_PROPERTY_SNI_HOST_MAX_LENGTH = 255;
}