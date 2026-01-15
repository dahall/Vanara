#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Items from HttpApi.dll.</summary>
public static partial class HttpApi
{
	/// <summary>
	/// <para>The <c>HTTP_BANDWIDTH_LIMIT_INFO</c> structure is used to set or query the bandwidth throttling limit.</para>
	/// <para>This structure must be used when setting or querying the HttpServerBandwidthProperty on a URL Group or server session.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_bandwidth_limit_info typedef struct _HTTP_BANDWIDTH_LIMIT_INFO {
	// HTTP_PROPERTY_FLAGS Flags; ULONG MaxBandwidth; } HTTP_BANDWIDTH_LIMIT_INFO, *PHTTP_BANDWIDTH_LIMIT_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_BANDWIDTH_LIMIT_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_BANDWIDTH_LIMIT_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure specifying whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// The maximum allowed bandwidth rate in bytesper second. Setting the value to HTTP_LIMIT_INFINITE allows unlimited bandwidth rate.
		/// The value cannot be smaller than HTTP_MIN_ALLOWED_BANDWIDTH_THROTTLING_RATE.
		/// </summary>
		public uint MaxBandwidth;
	}

	/// <summary>
	/// <para>The <c>HTTP_BINDING_INFO</c> structure is used to associate a URL Group with a request queue.</para>
	/// <para>This structure must be used when setting or querying the HttpServerBindingProperty on a URL Group.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_binding_info typedef struct _HTTP_BINDING_INFO {
	// HTTP_PROPERTY_FLAGS Flags; HANDLE RequestQueueHandle; } HTTP_BINDING_INFO, *PHTTP_BINDING_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_BINDING_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_BINDING_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure specifying whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// The request queue that is associated with the URL group. The structure can be used to remove an existing binding by setting this
		/// parameter to <c>NULL</c>.
		/// </summary>
		public HREQQUEUE RequestQueueHandle;
	}

	/// <summary>
	/// The <c>HTTP_BYTE_RANGE</c> structure is used to specify a byte range within a cached response fragment, file, or other data block.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_byte_range typedef struct _HTTP_BYTE_RANGE { ULARGE_INTEGER
	// StartingOffset; ULARGE_INTEGER Length; } HTTP_BYTE_RANGE, *PHTTP_BYTE_RANGE;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_BYTE_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_BYTE_RANGE
	{
		/// <summary>Starting offset of the byte range.</summary>
		public ulong StartingOffset;

		/// <summary>
		/// Size, in bytes, of the range. If this member is HTTP_BYTE_RANGE_TO_EOF, the range extends from the starting offset to the end of
		/// the file or data block.
		/// </summary>
		public ulong Length;
	}

	/// <summary>The <c>HTTP_CACHE_POLICY</c> structure is used to define a cache policy associated with a cached response fragment.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_cache_policy typedef struct _HTTP_CACHE_POLICY {
	// HTTP_CACHE_POLICY_TYPE Policy; ULONG SecondsToLive; } HTTP_CACHE_POLICY, *PHTTP_CACHE_POLICY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_CACHE_POLICY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_CACHE_POLICY
	{
		/// <summary>
		/// <para>
		/// This parameter is one of the following values from the HTTP_CACHE_POLICY_TYPE to control how an associated response or response
		/// fragment is cached.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HttpCachePolicyNocache</c></term>
		/// <term>Do not cache the data at all.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpCachePolicyUserInvalidates</c></term>
		/// <term>Cache the data until the application explicitly releases it.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpCachePolicyTimeToLive</c></term>
		/// <term>Cache the data for a number of seconds specified by the <c>SecondsToLive</c> member.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_CACHE_POLICY_TYPE Policy;

		/// <summary>
		/// When the <c>Policy</c> member is equal to HttpCachePolicyTimeToLive, data is cached for <c>SecondsToLive</c> seconds before it is
		/// released. For other values of <c>Policy</c>, <c>SecondsToLive</c> is ignored.
		/// </summary>
		public uint SecondsToLive;
	}

	/// <summary>The <c>HTTP_CHANNEL_BIND_INFO</c> structure is used to set or query channel bind authentication.</summary>
	/// <remarks>
	/// <c>Note</c>
	/// <para></para>
	/// This structure is used to set server session or URL group properties by passing it to HttpSetServerSessionProperty or HttpSetUrlGroupProperty.
	/// <para></para>
	/// The <c>HTTP_CHANNEL_BIND_INFO</c> structure is also returned when server session or URL group properties are queried
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_channel_bind_info typedef struct _HTTP_CHANNEL_BIND_INFO {
	// HTTP_AUTHENTICATION_HARDENING_LEVELS Hardening; ULONG Flags; PHTTP_SERVICE_BINDING_BASE *ServiceNames; ULONG NumberOfServiceNames; }
	// HTTP_CHANNEL_BIND_INFO, *PHTTP_CHANNEL_BIND_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_CHANNEL_BIND_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_CHANNEL_BIND_INFO
	{
		/// <summary>
		/// An HTTP_AUTHENTICATION_HARDENING_LEVELS value indicating the hardening level levels to be set or queried per server session or
		/// URL group.
		/// </summary>
		public HTTP_AUTHENTICATION_HARDENING_LEVELS Hardening;

		/// <summary>
		/// <para>A bitwise OR combination of flags that determine the behavior of authentication.</para>
		/// <para>The following values are supported.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HTTP_CHANNEL_BIND_PROXY</term>
		/// <term>0x1</term>
		/// <term>
		/// The exact Channel Bind Token (CBT) match is bypassed. CBT is checked not to be equal to ‘unbound’. Service Principle Name (SPN)
		/// check is enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HTTP_CHANNEL_BIND_PROXY_COHOSTING</term>
		/// <term>Ox20</term>
		/// <term>
		/// This flag is valid only if HTTP_CHANNEL_BIND_PROXY is also set. With the flag set, the CBT check (comparing with ‘unbound’) is
		/// skipped. The flag should be set if both secure channel traffic passed through proxy and traffic originally sent through insecure
		/// channel have to be authenticated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HTTP_CHANNEL_BIND_NO_SERVICE_NAME_CHECK</term>
		/// <term>0x2</term>
		/// <term>SPN check always succeeds.</term>
		/// </item>
		/// <item>
		/// <term>HTTP_CHANNEL_BIND_DOTLESS_SERVICE</term>
		/// <term>0x4</term>
		/// <term>Enables dotless service names. Otherwise configuring CBT properties with dotless service names will fail.</term>
		/// </item>
		/// <item>
		/// <term>HTTP_CHANNEL_BIND_SECURE_CHANNEL_TOKEN</term>
		/// <term>0x8</term>
		/// <term>
		/// Server session, URL group, or response is configured to retrieve secure channel endpoint binding for each request and pass it to
		/// user the mode application. When set, a pointer to a buffer with the secure channel endpoint binding is stored in an
		/// HTTP_REQUEST_CHANNEL_BIND_STATUS structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HTTP_CHANNEL_BIND_CLIENT_SERVICE</term>
		/// <term>0x10</term>
		/// <term>
		/// Server session, URL group, or response is configured to retrieve SPN for each request and pass it to the user mode application.
		/// The SPN is stored in the <c>ServiceName</c> field of the HTTP_REQUEST_CHANNEL_BIND_STATUS structure. The type is always
		/// <c>HttpServiceBindingTypeW</c> (Unicode).
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_CHANNEL_BIND Flags;

		/// <summary>
		/// Pointer to a buffer holding an array of 1 or more service names. Each service name is represented by either an
		/// HTTP_SERVICE_BINDING_A structure or an HTTP_SERVICE_BINDING_W structure, dependent upon whether the name is ASCII or Unicode.
		/// Regardless of which structure type is used, the array is cast into a pointer to an HTTP_SERVICE_BINDING_BASE structure.
		/// </summary>
		public IntPtr ServiceNames;

		/// <summary>The number of names in <c>ServiceNames</c>.</summary>
		public uint NumberOfServiceNames;
	}

	/// <summary>
	/// <para>
	/// The <c>HTTP_CONNECTION_LIMIT_INFO</c> structure is used to set or query the limit on the maximum number of outstanding connections
	/// for a URL Group.
	/// </para>
	/// <para>This structure must be used when setting or querying the HttpServerConnectionsProperty on a URL Group.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_connection_limit_info typedef struct _HTTP_CONNECTION_LIMIT_INFO
	// { HTTP_PROPERTY_FLAGS Flags; ULONG MaxConnections; } HTTP_CONNECTION_LIMIT_INFO, *PHTTP_CONNECTION_LIMIT_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_CONNECTION_LIMIT_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_CONNECTION_LIMIT_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure specifying whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>The number of connections allowed. Setting this value to HTTP_LIMIT_INFINITE allows an unlimited number of connections.</summary>
		public uint MaxConnections;
	}

	/// <summary>
	/// The <c>HTTP_COOKED_URL</c> structure contains a validated, canonical, UTF-16 Unicode-encoded URL request string together with
	/// pointers into it and element lengths. This is the string that the HTTP Server API matches against registered UrlPrefix strings in
	/// order to route the request appropriately.
	/// </summary>
	/// <remarks>
	/// For example, if <c>pFullUrl</c> is "http://www.fabrikam.com/path1/path2/file.ext?n1=v1&amp;n2=v2", then <c>pHost</c> points to
	/// "www.fabrikam", <c>pAbsPath</c> points to "/path1/…" and <c>pQueryString</c> points to "?n1=v1…".
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_cooked_url typedef struct _HTTP_COOKED_URL { USHORT
	// FullUrlLength; USHORT HostLength; USHORT AbsPathLength; USHORT QueryStringLength; PCWSTR pFullUrl; PCWSTR pHost; PCWSTR pAbsPath;
	// PCWSTR pQueryString; } HTTP_COOKED_URL, *PHTTP_COOKED_URL;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_COOKED_URL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_COOKED_URL
	{
		/// <summary>Size, in bytes, of the data pointed to by the <c>pFullUrl</c> member, not including a terminating null character.</summary>
		public ushort FullUrlLength;

		/// <summary>Size, in bytes, of the data pointed to by the <c>pHost</c> member.</summary>
		public ushort HostLength;

		/// <summary>Size, in bytes, of the data pointed to by the <c>pAbsPath</c> member.</summary>
		public ushort AbsPathLength;

		/// <summary>Size, in bytes, of the data pointed to by the <c>pQueryString</c> member.</summary>
		public ushort QueryStringLength;

		/// <summary>Pointer to the scheme element at the beginning of the URL (must be either "http://..." or "https://...").</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pFullUrl;

		/// <summary>
		/// Pointer to the first character in the host element, immediately following the double slashes at the end of the scheme element.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pHost;

		/// <summary>
		/// Pointer to the third forward slash ("/") in the string. In a UrlPrefix string, this is the slash immediately preceding the
		/// relativeUri element.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pAbsPath;

		/// <summary>Pointer to the first question mark (?) in the string, or <c>NULL</c> if there is none.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pQueryString;
	}

	/// <summary>Properties that can be passed down with IOCTL_HTTP_CREATE_REQUEST_QUEUE_EX.</summary>
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_DATA_CHUNK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_CREATE_REQUEST_QUEUE_PROPERTY_INFO
	{
		/// <summary/>
		public HTTP_CREATE_REQUEST_QUEUE_PROPERTY_ID PropertyId;

		/// <summary/>
		public uint PropertyInfoLength;

		/// <summary/>
		public IntPtr PropertyInfo;
	}

	/// <summary>
	/// The <c>HTTP_DATA_CHUNK</c> structure represents an individual block of data either in memory, in a file, or in the HTTP Server API
	/// response-fragment cache.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_data_chunk typedef struct _HTTP_DATA_CHUNK { HTTP_DATA_CHUNK_TYPE
	// DataChunkType; union { struct { PVOID pBuffer; ULONG BufferLength; } FromMemory; struct { HTTP_BYTE_RANGE ByteRange; HANDLE
	// FileHandle; } FromFileHandle; struct { USHORT FragmentNameLength; PCWSTR pFragmentName; } FromFragmentCache; struct { HTTP_BYTE_RANGE
	// ByteRange; PCWSTR pFragmentName; } FromFragmentCacheEx; struct { USHORT TrailerCount; PHTTP_UNKNOWN_HEADER pTrailers; } Trailers; }; }
	// HTTP_DATA_CHUNK, *PHTTP_DATA_CHUNK;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_DATA_CHUNK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_DATA_CHUNK
	{
		private HTTP_DATA_CHUNK(HTTP_DATA_CHUNK_TYPE type) { DataChunkType = type; union = default; }

		/// <summary>Initializes a new instance of the <see cref="HTTP_DATA_CHUNK"/> struct for <c>HttpDataChunkFromMemory</c>.</summary>
		/// <param name="mem">The memory.</param>
		public HTTP_DATA_CHUNK(SafeAllocatedMemoryHandleBase mem) : this(HTTP_DATA_CHUNK_TYPE.HttpDataChunkFromMemory) => FromMemory = new(mem);

		/// <summary>Initializes a new instance of the <see cref="HTTP_DATA_CHUNK"/> struct for <c>HttpDataChunkFromFileHandle</c>.</summary>
		/// <param name="hFile">The file handle.</param>
		/// <param name="startingOffset">The starting offset.</param>
		/// <param name="length">The length.</param>
		public HTTP_DATA_CHUNK(HFILE hFile, ulong startingOffset = 0, ulong length = HTTP_BYTE_RANGE_TO_EOF) : this(HTTP_DATA_CHUNK_TYPE.HttpDataChunkFromFileHandle) =>
			FromFileHandle = new() { FileHandle = hFile, ByteRange = new() { StartingOffset = startingOffset, Length = length } };

		/// <summary>Initializes a new instance of the <see cref="HTTP_DATA_CHUNK"/> struct for <c>HttpDataChunkFromFragmentCache</c>.</summary>
		/// <param name="fragmentName">Name of the fragment.</param>
		public HTTP_DATA_CHUNK(SafePWSTR fragmentName) : this(HTTP_DATA_CHUNK_TYPE.HttpDataChunkFromFragmentCache) => FromFragmentCache = new(fragmentName);

		/// <summary>Initializes a new instance of the <see cref="HTTP_DATA_CHUNK"/> struct for <c>HttpDataChunkFromFragmentCacheEx</c>.</summary>
		/// <param name="fragmentName">Name of the fragment.</param>
		/// <param name="startingOffset">The starting offset.</param>
		/// <param name="length">The length.</param>
		public HTTP_DATA_CHUNK(SafePWSTR fragmentName, ulong startingOffset = 0, ulong length = HTTP_BYTE_RANGE_TO_EOF) : this(HTTP_DATA_CHUNK_TYPE.HttpDataChunkFromFragmentCacheEx) =>
			FromFragmentCacheEx = new() { pFragmentName = fragmentName, ByteRange = new() { StartingOffset = startingOffset, Length = length } };

		/// <summary>Initializes a new instance of the <see cref="HTTP_DATA_CHUNK"/> struct for <c>HttpDataChunkTrailers</c>.</summary>
		/// <param name="headers">The headers.</param>
		public HTTP_DATA_CHUNK(SafeNativeArray<HTTP_UNKNOWN_HEADER> headers) : this(HTTP_DATA_CHUNK_TYPE.HttpDataChunkTrailers) => Trailers = new() { TrailerCount = (ushort)headers.Count, pTrailers = headers };

		/// <summary>Type of data store. This member can be one of the values from the <c>HTTP_DATA_CHUNK_TYPE</c> enumeration.</summary>
		public HTTP_DATA_CHUNK_TYPE DataChunkType;

		/// <summary/>
		private UNION union;

		/// <summary/>
		public FROMMEMORY FromMemory { get => union.FromMemory; set => union.FromMemory = value; }

		/// <summary/>
		public FROMFILEHANDLE FromFileHandle { get => union.FromFileHandle; set => union.FromFileHandle = value; }

		/// <summary/>
		public FROMFRAGMENTCACHE FromFragmentCache { get => union.FromFragmentCache; set => union.FromFragmentCache = value; }

		/// <summary/>
		public FROMFRAGMENTCACHEEX FromFragmentCacheEx { get => union.FromFragmentCacheEx; set => union.FromFragmentCacheEx = value; }

		/// <summary/>
		public TRAILERS Trailers { get => union.Trailers; set => union.Trailers = value; }

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			/// <summary/>
			[FieldOffset(0)]
			public FROMMEMORY FromMemory;

			/// <summary/>
			[FieldOffset(0)]
			public FROMFILEHANDLE FromFileHandle;

			/// <summary/>
			[FieldOffset(0)]
			public FROMFRAGMENTCACHE FromFragmentCache;

			/// <summary/>
			[FieldOffset(0)]
			public FROMFRAGMENTCACHEEX FromFragmentCacheEx;

			/// <summary/>
			[FieldOffset(0)]
			public TRAILERS Trailers;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct FROMMEMORY
		{
			/// <summary>Pointer to the starting memory address of the data block.</summary>
			public IntPtr pBuffer;

			/// <summary>Length, in bytes, of the data block.</summary>
			public uint BufferLength;

			internal FROMMEMORY(SafeAllocatedMemoryHandleBase mem) { pBuffer = mem; BufferLength = mem.Size; }
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct FROMFILEHANDLE
		{
			/// <summary>
			/// An HTTP_BYTE_RANGE structure that specifies all or part of the file. To specify the entire file, set the
			/// <c>StartingOffset</c> member to zero and the <c>Length</c> member to <c>HTTP_BYTE_RANGE_TO_EOF</c>.
			/// </summary>
			public HTTP_BYTE_RANGE ByteRange;

			/// <summary>Open handle to the file in question.</summary>
			public HFILE FileHandle;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct FROMFRAGMENTCACHE
		{
			/// <summary>Length, in bytes, of the fragment name not including the terminating null character.</summary>
			public ushort FragmentNameLength;

			/// <summary>
			/// Pointer to a string that contains the fragment name assigned when the fragment was added to the response-fragment cache using
			/// the HttpAddFragmentToCache function.
			/// </summary>
			public PWSTR pFragmentName;

			internal FROMFRAGMENTCACHE(SafePWSTR fragmentName)
			{
				pFragmentName = fragmentName;
				FragmentNameLength = (ushort)(fragmentName?.Length ?? 0);
			}
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct FROMFRAGMENTCACHEEX
		{
			/// <summary>An HTTP_BYTE_RANGE structure specifying the byte range in the cached fragment.</summary>
			public HTTP_BYTE_RANGE ByteRange;

			/// <summary>
			/// <para>
			/// Pointer to a string that contains the fragment name assigned when the fragment was added to the response-fragment cache using
			/// the HttpAddFragmentToCache function. The length of the string cannot exceed 65532 bytes.
			/// </para>
			/// <para><c>Note</c> This string must be NULL terminated.</para>
			/// </summary>
			public PWSTR pFragmentName;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct TRAILERS
		{
			/// <summary>Count of the number of HTTP_UNKNOWN_HEADER structures in the array pointed to by <c>pTrailers</c>.</summary>
			public ushort TrailerCount;

			/// <summary>Pointer to an array of <see cref="HTTP_UNKNOWN_HEADER"/> structures containing the trailers.</summary>
			public IntPtr pTrailers;
		}
	}

	/// <summary>Describes additional property information when delegating a request.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_delegate_request_property_info typedef struct
	// _HTTP_DELEGATE_REQUEST_PROPERTY_INFO { HTTP_DELEGATE_REQUEST_PROPERTY_ID PropertyId; ULONG PropertyInfoLength; PVOID PropertyInfo; }
	// HTTP_DELEGATE_REQUEST_PROPERTY_INFO, *PHTTP_DELEGATE_REQUEST_PROPERTY_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_DELEGATE_REQUEST_PROPERTY_INFO")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HTTP_DELEGATE_REQUEST_PROPERTY_INFO
	{
		/// <summary>
		/// <para>Type: <c>HTTP_DELEGATE_REQUEST_PROPERTY_ID</c></para>
		/// <para>The type of property info pointed to by this struct.</para>
		/// </summary>
		public HTTP_DELEGATE_REQUEST_PROPERTY_ID PropertyId;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The length in bytes of the value of the PropertyInfo parameter.</para>
		/// </summary>
		public uint PropertyInfoLength;

		/// <summary>
		/// <para>Type: <c>PVOID</c></para>
		/// <para>A pointer to the property information.</para>
		/// </summary>
		public IntPtr PropertyInfo;
	}

	/// <summary/>
	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_ERROR_HEADERS_PARAM
	{
		/// <summary/>
		public ushort StatusCode;

		/// <summary/>
		public ushort HeaderCount;

		/// <summary/>
		public IntPtr Headers;
	}

	/// <summary>The transfer rate of a response</summary>
	/// <remarks>
	/// <para>
	/// This structure allows an HTTP Server application to maximize the network bandwidth use by throttling down the transfer rate of an
	/// HTTP response. This is especially useful in serving media content where the initial burst of the content is served at a higher
	/// transfer rate and then throttled. This allows content from a larger number of media to be served concurrently.
	/// </para>
	/// <para>The transfer rate is allowed to exceed <c>MaxBandwidth</c> in two cases:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the connection slows and the transfer rate falls below <c>MaxBandwidth</c>, the application can go beyond <c>MaxBandwidth</c> to
	/// catch up.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The beginning of a response is allowed to exceed <c>MaxBandwidth</c>. For example, a server may transfer media file at high speed at
	/// the beginning in order to expedite playback on the client. For example, if that client needs initial 20KB of the file to start
	/// playback, the server might have this variable set to 20KB.
	/// </term>
	/// </item>
	/// </list>
	/// <para>When <c>MaxBandwidth</c> is exceeded, <c>MaxPeakBandwidth</c> is still the absolute upper limit.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_flowrate_info typedef struct _HTTP_FLOWRATE_INFO {
	// HTTP_PROPERTY_FLAGS Flags; ULONG MaxBandwidth; ULONG MaxPeakBandwidth; ULONG BurstSize; } HTTP_FLOWRATE_INFO, *PHTTP_FLOWRATE_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_FLOWRATE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_FLOWRATE_INFO
	{
		/// <summary>An HTTP_PROPERTY_FLAGS structure specifying whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// The maximum bandwidth represented in bytes/second. This is the maximum bandwidth for the response after the burst content, whose
		/// size is specified in <c>BurstSize</c>, has been sent.
		/// </summary>
		public uint MaxBandwidth;

		/// <summary>The peak bandwidth represented in bytes/second. This is the maximum bandwidth at which the burst is delivered.</summary>
		public uint MaxPeakBandwidth;

		/// <summary>
		/// The size of the content, in bytes, to be delivered at <c>MaxPeakBandwidth</c>. Once this content has been delivered, the response
		/// is throttled at <c>MaxBandwidth</c>. If the HTTP Server application sends responses at a rate slower than <c>MaxBandwidth</c>,
		/// the response is subject to burst again at <c>MaxPeakBandwidth</c> to maximize bandwidth utilization.
		/// </summary>
		public uint BurstSize;
	}

	/// <summary>The <c>HTTP_KNOWN_HEADER</c> structure contains the header values for a known header from an HTTP request or HTTP response.</summary>
	/// <remarks>
	/// <para>
	/// In the HTTP Server API, known headers are defined as those that are enumerated in the HTTP_HEADER_ID enumeration type. Be aware that
	/// there are different lists of different sizes for request and response headers.
	/// </para>
	/// <para>For more information about the structure and usage of HTTP headers, see the RFC 2616.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_known_header typedef struct _HTTP_KNOWN_HEADER { USHORT
	// RawValueLength; PCSTR pRawValue; } HTTP_KNOWN_HEADER, *PHTTP_KNOWN_HEADER;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_KNOWN_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_KNOWN_HEADER
	{
		/// <summary>
		/// Size, in bytes, of the 8-bit string pointed to by the <c>pRawValue</c> member, not counting a terminating null character, if
		/// present. If <c>RawValueLength</c> is zero, then the value of the <c>pRawValue</c> element is meaningless.
		/// </summary>
		public ushort RawValueLength;

		/// <summary>
		/// Pointer to the text of this HTTP header. Use <c>RawValueLength</c> to determine where this text ends rather than relying on the
		/// string to have a terminating null. The format of the header text is specified in RFC 2616.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pRawValue;
	}

	/// <summary>Controls whether IP-based URLs should listen on the specific IP address or on a wildcard.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_listen_endpoint_info typedef struct _HTTP_LISTEN_ENDPOINT_INFO {
	// HTTP_PROPERTY_FLAGS Flags; BOOLEAN EnableSharing; } HTTP_LISTEN_ENDPOINT_INFO, *PHTTP_LISTEN_ENDPOINT_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_LISTEN_ENDPOINT_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_LISTEN_ENDPOINT_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure that specifies if the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>A Boolean value that specifies whether sharing is enabled.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool EnableSharing;
	}

	/// <summary>The <c>HTTP_LOG_DATA</c> structure contains a value that specifies the type of the log data.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_log_data typedef struct _HTTP_LOG_DATA { HTTP_LOG_DATA_TYPE Type;
	// } HTTP_LOG_DATA, *PHTTP_LOG_DATA;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_LOG_DATA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_LOG_DATA
	{
		/// <summary>An HTTP_LOG_DATA_TYPE enumeration value that specifies the type.</summary>
		public HTTP_LOG_DATA_TYPE Type;
	}

	/// <summary>
	/// The <c>HTTP_LOG_FIELDS_DATA</c> structure is used to pass the fields that are logged for an HTTP response when WC3 logging is enabled.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>HTTP_LOG_FIELDS_DATA</c> structure is an optional parameter (pLogData) in the HttpSendResponseEntityBody and
	/// HttpSendHttpResponse functions starting with the HTTP version 2.0 API. The <c>HTTP_LOG_FIELDS_DATA</c> structure specifies which
	/// fields are logged in the response.
	/// </para>
	/// <para>
	/// Unless this structure is passed, the response will not be logged, even when the server logging property is set on a URL group or a
	/// server session. Requests will not be logged unless the application passes the <c>HTTP_LOG_FIELDS_DATA</c> structure with each
	/// response and the logging property is set on the server session or URL Group. Most of the fields in the <c>HTTP_LOG_FIELDS_DATA</c>
	/// structure can be initialized from the corresponding field in the HTTP_REQUEST structure, however, some of the log fields are only
	/// known to the application; for example, Win32Status and SubStatus. This structure enables applications to alter the fields that are
	/// logged. The application passes a <c>NULL</c> pointer and a zero length for the corresponding member to disable logging for that field.
	/// </para>
	/// <para>
	/// Applications must provide the <c>HTTP_LOG_FIELDS_DATA</c> structure with the last send call. If a response is sent with a single call
	/// to HttpSendHttpResponse, the log data must be provided in this call. If the response is sent over multiple send calls, the data must
	/// be provided with the last call to HttpSendResponseEntityBody.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_log_fields_data typedef struct _HTTP_LOG_FIELDS_DATA {
	// HTTP_LOG_DATA Base; USHORT UserNameLength; USHORT UriStemLength; USHORT ClientIpLength; USHORT ServerNameLength; USHORT
	// ServiceNameLength; USHORT ServerIpLength; USHORT MethodLength; USHORT UriQueryLength; USHORT HostLength; USHORT UserAgentLength;
	// USHORT CookieLength; USHORT ReferrerLength; PWCHAR UserName; PWCHAR UriStem; PCHAR ClientIp; PCHAR ServerName; PCHAR ServiceName;
	// PCHAR ServerIp; PCHAR Method; PCHAR UriQuery; PCHAR Host; PCHAR UserAgent; PCHAR Cookie; PCHAR Referrer; USHORT ServerPort; USHORT
	// ProtocolStatus; ULONG Win32Status; HTTP_VERB MethodNum; USHORT SubStatus; } HTTP_LOG_FIELDS_DATA, *PHTTP_LOG_FIELDS_DATA;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_LOG_FIELDS_DATA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_LOG_FIELDS_DATA
	{
		/// <summary>Initialize this member to the <c>HttpLogDataTypeFields</c> value of the HTTP_LOG_DATA_TYPE enumeration.</summary>
		public HTTP_LOG_DATA Base;

		/// <summary>The size, in bytes, of the user name member.</summary>
		public ushort UserNameLength;

		/// <summary>The size, in bytes, of the URI stem member.</summary>
		public ushort UriStemLength;

		/// <summary>The size, in bytes, of the client IP address member.</summary>
		public ushort ClientIpLength;

		/// <summary>The size, in bytes, of the server name member.</summary>
		public ushort ServerNameLength;

		/// <summary/>
		public ushort ServiceNameLength;

		/// <summary>The size, in bytes, of the server IP address member.</summary>
		public ushort ServerIpLength;

		/// <summary>The size, in bytes, of the HTTP method member.</summary>
		public ushort MethodLength;

		/// <summary>The size, in bytes, of the URI query member.</summary>
		public ushort UriQueryLength;

		/// <summary>The size, in bytes, of the host name member.</summary>
		public ushort HostLength;

		/// <summary>The size, in bytes, of the user agent member.</summary>
		public ushort UserAgentLength;

		/// <summary>The size, in bytes, of the cookie member.</summary>
		public ushort CookieLength;

		/// <summary>The size, in bytes, of the referrer member.</summary>
		public ushort ReferrerLength;

		/// <summary>The name of the user.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string UserName;

		/// <summary>The URI stem.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string UriStem;

		/// <summary>The IP address of the client.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string ClientIp;

		/// <summary>The name of the server.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string ServerName;

		/// <summary>The name of the service.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string ServiceName;

		/// <summary>The IP address of the server.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string ServerIp;

		/// <summary>The HTTP method.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string Method;

		/// <summary>The URI query.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string UriQuery;

		/// <summary>The host information from the request.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string Host;

		/// <summary>The user agent name.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string UserAgent;

		/// <summary>The cookie provided by the application.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string Cookie;

		/// <summary>The referrer.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string Referrer;

		/// <summary>The port for the server.</summary>
		public ushort ServerPort;

		/// <summary>The protocol status.</summary>
		public ushort ProtocolStatus;

		/// <summary>The win32 status.</summary>
		public Win32Error Win32Status;

		/// <summary>The method number.</summary>
		public HTTP_VERB MethodNum;

		/// <summary>The sub status.</summary>
		public ushort SubStatus;
	}

	/// <summary>
	/// <para>The <c>HTTP_LOGGING_INFO</c> structure is used to enable server side logging on a URL Group or on a server session.</para>
	/// <para>This structure must be used when setting or querying the HttpServerLoggingProperty on a URL Group or server session.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The HttpServerLoggingProperty property sets one of four types of server side logging: HttpLoggingTypeW3C, HttpLoggingTypeIIS,
	/// HttpLoggingTypeNCSA, or HttpLoggingTypeRaw. When this property is set on a server session it functions as centralized form of logging
	/// for all of the URL groups under that server session. Requests that are routed to one of the URL groups under the server session are
	/// logged in one centralized log file. The configuration parameters for the log file are passed in the <c>HTTP_LOGGING_INFO</c>
	/// structure in the call to HttpSetServerSessionProperty.
	/// </para>
	/// <para>
	/// When this property is set on a URL Group, logging is performed only on requests that are routed to the URL Group. Log files are
	/// created when the request arrives on the URL Group or server session, they are not created when logging is configured.
	/// </para>
	/// <para>Applications must ensure that the directory specified in the <c>DirectoryName</c> member is unique.</para>
	/// <para>The log files names are based on the specified rollover type. The following table shows the naming conventions for log files.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Format</term>
	/// <term>Rollover type</term>
	/// <term>File name pattern</term>
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
	/// <term>inyymmww.log</term>
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
	/// <para>The letters yy, mm, ww, dd, hh, and nn in the table represent the following digits:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>yy: The two digit representation of the year.</term>
	/// </item>
	/// <item>
	/// <term>mm: The two digit representation of the month.</term>
	/// </item>
	/// <item>
	/// <term>ww: The two digit representation of the week.</term>
	/// </item>
	/// <item>
	/// <term>dd: The two digit representation of the day.</term>
	/// </item>
	/// <item>
	/// <term>hh: The two digit representation of the hour in 24 hour notation.</term>
	/// </item>
	/// <item>
	/// <term>nn: The two digit representation of the numerical sequence.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Please note that in the HTTP version 2.0 API, the HttpSendHttpResponse and HttpSendResponseEntityBody have been revisioned to allow
	/// applications to pass an HTTP_LOG_FIELDS_DATA structure so the response can be logged. Setting the <c>HttpServerLoggingProperty</c>
	/// property on a server session or a URL group does not mean that HTTP responses are logged. Logging on the URL group or the server
	/// session will not take place unless the calls to <c>HttpSendResponseEntityBody</c> and <c>HttpSendHttpResponse</c> include an optional
	/// <c>HTTP_LOG_FIELDS_DATA</c> structure. For more information, see the <c>HTTP_LOG_FIELDS_DATA</c> topic.
	/// </para>
	/// <para>For information on the log file formats, see the IIS Log File Formats topic.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_logging_info typedef struct _HTTP_LOGGING_INFO {
	// HTTP_PROPERTY_FLAGS Flags; ULONG LoggingFlags; PCWSTR SoftwareName; USHORT SoftwareNameLength; USHORT DirectoryNameLength; PCWSTR
	// DirectoryName; HTTP_LOGGING_TYPE Format; ULONG Fields; PVOID pExtFields; USHORT NumOfExtFields; USHORT MaxRecordSize;
	// HTTP_LOGGING_ROLLOVER_TYPE RolloverType; ULONG RolloverSize; PSECURITY_DESCRIPTOR pSecurityDescriptor; } HTTP_LOGGING_INFO, *PHTTP_LOGGING_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_LOGGING_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_LOGGING_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure that specifies whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// <para>The optional logging flags change the default logging behavior.</para>
		/// <para>These can be one or more of the following HTTP_LOGGING_FLAG values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_LOGGING_FLAG_LOCAL_TIME_ROLLOVER</c></term>
		/// <term>Changes the log file rollover time to local time. By default log file rollovers are based on GMT.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_LOGGING_FLAG_USE_UTF8_CONVERSION</c></term>
		/// <term>
		/// By default, the unicode logging fields are converted to multibytes using the systems local code page. If this flags is set, the
		/// UTF8 conversion is used instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_LOGGING_FLAG_LOG_ERRORS_ONLY</c></term>
		/// <term>
		/// The log errors only flag enables logging errors only. By default, both error and success request are logged. The
		/// <c>HTTP_LOGGING_FLAG_LOG_ERRORS_ONLY</c> and <c>HTTP_LOGGING_FLAG_LOG_SUCCESS_ONLY</c> flags are used to perform selective
		/// logging. Only one of these flags can be set at a time; they are mutually exclusive.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_LOGGING_FLAG_LOG_SUCCESS_ONLY</c></term>
		/// <term>
		/// The log success only flag enables logging successful requests only. By default, both error and success request are logged. The
		/// <c>HTTP_LOGGING_FLAG_LOG_ERRORS_ONLY</c> and <c>HTTP_LOGGING_FLAG_LOG_SUCCESS_ONLY</c> flags are used to perform selective
		/// logging. Only one of these flags can be set at a time; they are mutually exclusive.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_LOGGING_FLAG LoggingFlags;

		/// <summary>
		/// The optional software name string used in W3C type logging. This name is not used for other types of logging. If this parameter
		/// is <c>NULL</c>, the HTTP Server API logs a default string.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? SoftwareName;

		/// <summary>
		/// <para>The length, in bytes, of the software name. The length cannot be greater than <c>MAX_PATH</c>.</para>
		/// <para>If the <c>SoftwareName</c> member is <c>NULL</c>, this length must be zero.</para>
		/// </summary>
		public ushort SoftwareNameLength;

		/// <summary>The length, in bytes, of the directory name. The length cannot be greater than 424 bytes.</summary>
		public ushort DirectoryNameLength;

		/// <summary>
		/// <para>
		/// The logging directory under which the log files are created. The directory string must be a fully qualified path including the
		/// drive letter.
		/// </para>
		/// <para>Applications can use a UNC path to a remote machine to enable UNC logging.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string DirectoryName;

		/// <summary>
		/// <para>A member of the HTTP_LOGGING_TYPE enumeration specifying one of the following log file formats.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Format</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HttpLoggingTypeW3C</c></term>
		/// <term>
		/// The log format is W3C style extended logging. With this format, application can pick a combination of log fields to be logged.
		/// When W3C logging is set on a URL group, logging is similar to the IIS6 site logging. When W3C logging is set on a server session,
		/// this logging functions as a centralized logging for all of the URL Groups.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingTypeIIS</c></term>
		/// <term>
		/// The log format is IIS6/5 style logging. This format has fixed field definitions; applications cannot select the fields that are
		/// logged. This format cannot be used for logging a server session.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingTypeNCSA</c></term>
		/// <term>
		/// The log format is NCSA style logging. This format has fixed field definitions; applications cannot select the fields that are
		/// logged. This format cannot be used for logging a server session.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingTypeRaw</c></term>
		/// <term>
		/// The log format is centralized binary logging. This format has fixed field definitions; applications cannot select the fields that
		/// are logged. This format cannot be used for logging a URL Group.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_LOGGING_TYPE Format;

		/// <summary>
		/// <para>The fields that are logged when the format is set to W3C. These can be one or more of the HTTP_LOG_FIELD_ Constants values.</para>
		/// <para>When the logging format is W3C is , applications must specify the log fields otherwise no fields are logged.</para>
		/// </summary>
		public HTTP_LOG_FIELD Fields;

		/// <summary>Reserved. Set to 0 (zero) or <c>NULL</c>.</summary>
		public IntPtr pExtFields;

		/// <summary>Reserved. Set to 0 (zero) or <c>NULL</c>.</summary>
		public ushort NumOfExtFields;

		/// <summary>Reserved. Set to 0 (zero) or <c>NULL</c>.</summary>
		public ushort MaxRecordSize;

		/// <summary>
		/// <para>One of the following members of the HTTP_LOGGING_ROLLOVER_TYPE enumeration specifying the criteria for log file rollover.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Rollover Type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HttpLoggingRolloverSize</c></term>
		/// <term>The log files are rolled over when they reach or exceed a specified size.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingRolloverDaily</c></term>
		/// <term>The log files are rolled over every day.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingRolloverWeekly</c></term>
		/// <term>The log files are rolled over every week.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingRolloverMonthly</c></term>
		/// <term>The log files are rolled over every month.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpLoggingRolloverHourly</c></term>
		/// <term>The log files are rolled over every hour.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_LOGGING_ROLLOVER_TYPE RolloverType;

		/// <summary>
		/// <para>
		/// The maximum size, in bytes, after which the log files is rolled over. A value of <c>HTTP_LIMIT_INFINITE</c> indicates an
		/// unlimited size. The minimum value cannot be smaller than <c>HTTP_MIN_ALLOWED_LOG_FILE_ROLLOVER_SIZE</c> (1024 * 1024).
		/// </para>
		/// <para>This field is used only for <c>HttpLoggingRolloverSize</c> rollover type and should be set to zero for all other types.</para>
		/// <para>When rollover type is <c>HttpLoggingRolloverSize</c>, applications must specify the maximum size for the log file.</para>
		/// </summary>
		public uint RolloverSize;

		/// <summary>
		/// The security descriptor that is applied to the log files directory and all sub-directories. If this member is <c>NULL</c>, either
		/// the system default ACL is used or the ACL is inherited from the parent directory.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;
	}

	/// <summary>
	/// The <c>HTTP_MULTIPLE_KNOWN_HEADERS</c> structure specifies the headers that are included in an HTTP response when more than one
	/// header is required.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The HTTP version 1.0 API allows applications to send only one known response header with the response. Starting with the HTTP version
	/// 2.0 API, applications are enabled to send multiple known response headers.
	/// </para>
	/// <para>
	/// The <c>pInfo</c> member of the HTTP_RESPONSE_INFO structure points to this structure when the application provides multiple known
	/// headers on a response. The <c>HTTP_RESPONSE_INFO</c> structure extends the HTTP_RESPONSE structure starting with HTTP version 2.0.
	/// </para>
	/// <para>
	/// The <c>HTTP_MULTIPLE_KNOWN_HEADERS</c> structure enables server applications to send multiple authentication challenges to the client.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_multiple_known_headers typedef struct
	// _HTTP_MULTIPLE_KNOWN_HEADERS { HTTP_HEADER_ID HeaderId; ULONG Flags; USHORT KnownHeaderCount; PHTTP_KNOWN_HEADER KnownHeaders; }
	// HTTP_MULTIPLE_KNOWN_HEADERS, *PHTTP_MULTIPLE_KNOWN_HEADERS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_MULTIPLE_KNOWN_HEADERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_MULTIPLE_KNOWN_HEADERS
	{
		/// <summary>A member of the HTTP_HEADER_ID enumeration specifying the response header ID.</summary>
		public HTTP_HEADER_ID HeaderId;

		/// <summary>
		/// <para>
		/// The flags corresponding to the response header in the <c>HeaderId</c> member. This member is used only when the WWW-Authenticate
		/// header is present. This can be zero or the following:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_RESPONSE_INFO_FLAGS_PRESERVE_ORDER</c></term>
		/// <term>The specified order of authentication schemes is preserved on the challenge response.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_RESPONSE_INFO_FLAGS Flags;

		/// <summary>The number of elements in the array specified in the <c>KnownHeaders</c> member.</summary>
		public ushort KnownHeaderCount;

		/// <summary>A pointer to the first element in the array of <see cref="HTTP_KNOWN_HEADER"/> structures.</summary>
		public IntPtr KnownHeaders;

		/// <summary>Gets the array of <see cref="HTTP_KNOWN_HEADER"/> structures.</summary>
		public IEnumerable<HTTP_KNOWN_HEADER> GetKnownHeaders() => KnownHeaders.ToIEnum<HTTP_KNOWN_HEADER>(KnownHeaderCount);
	}

	/// <summary/>
	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_PERFORMANCE_PARAM
	{
		/// <summary/>
		public HTTP_PERFORMANCE_PARAM_TYPE Type;

		/// <summary/>
		public uint BufferSize;

		/// <summary/>
		public IntPtr Buffer;
	}

	/// <summary>
	/// <para>
	/// The <c>HTTP_PROPERTY_FLAGS</c> structure is used by the property configuration structures to enable or disable a property on a
	/// configuration object when setting property configurations.
	/// </para>
	/// <para>
	/// When the configuration structure is used to query property configurations, this structure specifies whether the property is present
	/// on the configuration object.
	/// </para>
	/// </summary>
	/// <remarks>
	/// The property configuration structures are used in calls to HttpSetRequestQueueProperty, HttpSetServerSessionProperty, and
	/// HttpSetUrlGroupProperty to set properties on the corresponding configuration objects. The configuration structures are also used in
	/// calls to HttpQueryRequestQueueProperty, HttpQueryServerSessionProperty, and HttpQueryUrlGroupProperty, to query properties on the
	/// corresponding configuration object. When properties are set on the URL Group, server session, or request queue, this structure
	/// enables or disables the property. When properties are queried for the URL Group, server session, or request queue, this structure is
	/// used by the application to determine if the property is present. For more information, see the list of property configuration
	/// structures in the See Also section below.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_property_flags typedef struct _HTTP_PROPERTY_FLAGS { ULONG
	// Present : 1; } HTTP_PROPERTY_FLAGS, *PHTTP_PROPERTY_FLAGS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_PROPERTY_FLAGS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_PROPERTY_FLAGS
	{
		private uint _bits;

		/// <summary>
		/// <para>
		/// The <c>Present</c> flag enables or disables a property, or determines whether the property is present on the configuration object.
		/// </para>
		/// <para>A value of zero indicates the property is not present; a positive value indicates the property is present.</para>
		/// </summary>
		public bool Present { get => BitHelper.GetBit(_bits, 0); set => BitHelper.SetBit(ref _bits, 0, value); }
	}

	/// <summary>
	/// Controls whether the associated UrlGroup Namespace should receive edge traversed traffic. By default this parameter is unspecified.
	/// </summary>
	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_PROTECTION_LEVEL_INFO
	{
		/// <summary/>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary/>
		public HTTP_PROTECTION_LEVEL_TYPE Level;
	}

	/// <summary>The <c>HTTP_QOS_SETTING_INFO</c> structurecontains information about a QOS setting.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_qos_setting_info typedef struct _HTTP_QOS_SETTING_INFO {
	// HTTP_QOS_SETTING_TYPE QosType; PVOID QosSetting; } HTTP_QOS_SETTING_INFO, *PHTTP_QOS_SETTING_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_QOS_SETTING_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_QOS_SETTING_INFO
	{
		/// <summary>An HTTP_QOS_SETTING_TYPE enumeration value that specifies the type of the QOS setting.</summary>
		public HTTP_QOS_SETTING_TYPE QosType;

		/// <summary>A pointer to a structure that contains the setting.</summary>
		public IntPtr QosSetting;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_QUERY_REQUEST_QUALIFIER_QUIC
	{
		public ulong Freshness;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_QUERY_REQUEST_QUALIFIER_TCP
	{
		public ulong Freshness;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_QUIC_API_TIMINGS
	{
		public HTTP_QUIC_CONNECTION_API_TIMINGS ConnectionTimings;
		public HTTP_QUIC_STREAM_API_TIMINGS StreamTimings;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_QUIC_CONNECTION_API_TIMINGS
	{
		public ulong OpenTime;
		public ulong CloseTime;

		public ulong StartTime;
		public ulong ShutdownTime;

		public ulong SecConfigCreateTime;
		public ulong SecConfigDeleteTime;

		public ulong GetParamCount;
		public ulong GetParamSum;

		public ulong SetParamCount;
		public ulong SetParamSum;

		public ulong SetCallbackHandlerCount;
		public ulong SetCallbackHandlerSum;

		public HTTP_QUIC_STREAM_API_TIMINGS ControlStreamTimings;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_QUIC_STREAM_API_TIMINGS
	{
		public ulong OpenCount;
		public ulong OpenSum;
		public ulong CloseCount;
		public ulong CloseSum;

		public ulong StartCount;
		public ulong StartSum;
		public ulong ShutdownCount;
		public ulong ShutdownSum;

		public ulong SendCount;
		public ulong SendSum;

		public ulong ReceiveSetEnabledCount;
		public ulong ReceiveSetEnabledSum;

		public ulong GetParamCount;
		public ulong GetParamSum;

		public ulong SetParamCount;
		public ulong SetParamSum;

		public ulong SetCallbackHandlerCount;
		public ulong SetCallbackHandlerSum;
	}

	/// <summary>
	/// <para>
	/// The <c>HTTP_REQUEST_AUTH_INFO</c> structure contains the authentication status of the request with a handle to the client token that
	/// the receiving process can use to impersonate the authenticated client.
	/// </para>
	/// <para>This structure is contained in the HTTP_REQUEST_INFO structure.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Starting with HTTP version 2.0, the HTTP_REQUEST structure contains an HTTP_REQUEST_INFO structure. The <c>pVoid</c> member of the
	/// <c>HTTP_REQUEST_INFO</c> structure points to the <c>HTTP_REQUEST_AUTH_INFO</c> when the request information type is <c>HttpRequestInfoTypeAuth</c>.
	/// </para>
	/// <para>
	/// When the application receives a request with this structure and the request has not been authenticated, it can send the initial 401
	/// challenge with the desired set of WWW-Authenticate headers in the HTTP_MULTIPLE_KNOWN_HEADERS structure. When the HTTP Server API
	/// completes the authentication handshake, it fills the <c>HTTP_REQUEST_AUTH_INFO</c> structure and passes it to the application with
	/// the request again. The handle to the access token that represents the client identity is provided in this structure by the HTTP
	/// Server API.
	/// </para>
	/// <para>Context Attributes</para>
	/// <para>
	/// The <c>ContextAttributes</c> member is provided for SSPI based schemes. For example, SSPI applications can determine whether
	/// <c>ASC_RET_MUTUAL_AUTH</c> is set for a mutually authenticated session.
	/// </para>
	/// <para>
	/// The HTTP Server API does not provide the expiration time for the context in the <c>PackedContext</c> member. Applications may require
	/// the expiration time in specific circumstances, for example, when NTLM credential caching is enabled and the application queries for
	/// the expiration time for a cached context. If the server application requires the expiration time for the underlying client context
	/// associated with the access token, it can receive the packed context and call QueryContextAttributes with the <c>SECPKG_ATTR_LIFESPAN</c>.
	/// </para>
	/// <para>Mutual Authentication Data</para>
	/// <para>
	/// By default, the HTTP Server API ensures that the mutual authentication data is added to the final 200 response; in general, server
	/// applications are not responsible for sending the mutual authentication data.
	/// </para>
	/// <para>
	/// However, applications can receive the mutual authentication data and send it with the final response. When the
	/// <c>ReceiveMutualAuth</c> member of the HTTP_SERVER_AUTHENTICATION_INFO structure is set to true, applications receive the server
	/// credentials for mutual authentication along with the authenticated request.
	/// </para>
	/// <para>
	/// The mutual authentication data provided in the <c>pMutualAuthData</c> member contains the exact value of WWW-Authenticate header
	/// without the header name. For example, <c>pMutualAuthData</c> points to "Negotiate ade02938481eca". The application builds the
	/// WWW-Authenticate header by appending the provided <c>pMutualAuthData</c> as a response header value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_auth_info typedef struct _HTTP_REQUEST_AUTH_INFO {
	// HTTP_AUTH_STATUS AuthStatus; SECURITY_STATUS SecStatus; ULONG Flags; HTTP_REQUEST_AUTH_TYPE AuthType; HANDLE AccessToken; ULONG
	// ContextAttributes; ULONG PackedContextLength; ULONG PackedContextType; PVOID PackedContext; ULONG MutualAuthDataLength; PCHAR
	// pMutualAuthData; USHORT PackageNameLength; PWSTR pPackageName; } HTTP_REQUEST_AUTH_INFO, *PHTTP_REQUEST_AUTH_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_AUTH_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_AUTH_INFO
	{
		/// <summary>
		/// <para>A member of the HTTP_AUTH_STATUS enumeration that indicates the final authentication status of the request.</para>
		/// <para>
		/// If the authentication status is not <c>HttpAuthStatusSuccess</c>, applications should disregard members of this structure except
		/// <c>AuthStatus</c>, <c>SecStatus</c>, and <c>AuthType</c>.
		/// </para>
		/// </summary>
		public HTTP_AUTH_STATUS AuthStatus;

		/// <summary>A SECURITY_STATUS value that indicates the security failure status when the <c>AuthStatus</c> member is <c>HttpAuthStatusFailure</c>.</summary>
		public HRESULT SecStatus;

		/// <summary>
		/// <para>The authentication flags that indicate the following authentication attributes:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Attribute</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_REQUEST_AUTH_FLAG_TOKEN_FOR_CACHED_CRED</c></term>
		/// <term>The provided token is for NTLM and is based on a cached credential of a Keep Alive (KA) connection.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_REQUEST_AUTH_FLAG Flags;

		/// <summary>
		/// A member of the HTTP_REQUEST_AUTH_TYPE enumeration that indicates the authentication scheme attempted or established for the request.
		/// </summary>
		public HTTP_REQUEST_AUTH_TYPE AuthType;

		/// <summary>
		/// <para>A handle to the client token that the receiving process can use to impersonate the authenticated client.</para>
		/// <para>
		/// The handle to the token should be closed by calling CloseHandle when it is no longer required. This token is valid only for the
		/// lifetime of the request. Applications can regenerate the initial 401 challenge to reauthenticate when the token expires.
		/// </para>
		/// </summary>
		public HTOKEN AccessToken;

		/// <summary>The client context attributes for the access token.</summary>
		public uint ContextAttributes;

		/// <summary>The length, in bytes, of the <c>PackedContext</c>.</summary>
		public uint PackedContextLength;

		/// <summary>The type of context in the <c>PackedContext</c> member.</summary>
		public uint PackedContextType;

		/// <summary>
		/// <para>The security context for the authentication type.</para>
		/// <para>
		/// Applications can query the attributes of the packed context by calling the SSPI QueryContextAttributes API. However, applications
		/// must acquire a credential handle for the security package for the indicated AuthType.
		/// </para>
		/// <para>Application should call the SSPI FreeContextBuffer API to free the serialized context when it is no longer required.</para>
		/// </summary>
		public IntPtr PackedContext;

		/// <summary>The length, in bytes, of the <c>pMutualAuthData</c> member.</summary>
		public uint MutualAuthDataLength;

		/// <summary>The Base64 encoded mutual authentication data used in the WWW-Authenticate header.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pMutualAuthData;

		/// <summary/>
		public ushort PackageNameLength;

		/// <summary/>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pPackageName;
	}

	/// <summary>The <c>HTTP_REQUEST_CHANNEL_BIND_STATUS</c> structure contains secure channel endpoint binding information.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_channel_bind_status typedef struct
	// _HTTP_REQUEST_CHANNEL_BIND_STATUS { PHTTP_SERVICE_BINDING_BASE ServiceName; PUCHAR ChannelToken; ULONG ChannelTokenSize; ULONG Flags;
	// } HTTP_REQUEST_CHANNEL_BIND_STATUS, *PHTTP_REQUEST_CHANNEL_BIND_STATUS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_CHANNEL_BIND_STATUS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_CHANNEL_BIND_STATUS
	{
		/// <summary>
		/// A pointer to an HTTP_SERVICE_BINDING_W structure cast to a pointer to an HTTP_SERVICE_BINDING_BASE structure containing the
		/// service name from the client. This is populated if the request's Channel Binding Token (CBT) is not configured to retrieve
		/// service names.
		/// </summary>
		public IntPtr ServiceName;

		/// <summary>A pointer to a buffer that contains the secure channel endpoint binding.</summary>
		public IntPtr ChannelToken;

		/// <summary>The length of the <c>ChannelToken</c> buffer in bytes.</summary>
		public uint ChannelTokenSize;

		/// <summary>Reserved</summary>
		public uint Flags;
	}

	/// <summary>The <c>HTTP_REQUEST_HEADERS</c> structure contains headers sent with an HTTP request.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_headers typedef struct _HTTP_REQUEST_HEADERS { USHORT
	// UnknownHeaderCount; PHTTP_UNKNOWN_HEADER pUnknownHeaders; USHORT TrailerCount; PHTTP_UNKNOWN_HEADER pTrailers; HTTP_KNOWN_HEADER
	// KnownHeaders[HttpHeaderRequestMaximum]; } HTTP_REQUEST_HEADERS, *PHTTP_REQUEST_HEADERS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_HEADERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_HEADERS
	{
		/// <summary>
		/// A number of unknown headers sent with the HTTP request. This number is the size of the array pointed to by the
		/// <c>pUnknownHeaders</c> member.
		/// </summary>
		public ushort UnknownHeaderCount;

		/// <summary>
		/// A pointer to an array of HTTP_UNKNOWN_HEADER structures. This array contains one structure for each of the unknown headers sent
		/// in the HTTP request.
		/// </summary>
		public IntPtr pUnknownHeaders;

		/// <summary>This member is reserved and must be zero.</summary>
		public ushort TrailerCount;

		/// <summary>This member is reserved and must be <c>NULL</c>.</summary>
		public IntPtr pTrailers;

		/// <summary>
		/// Fixed-size array of HTTP_KNOWN_HEADER structures. The HTTP_HEADER_ID enumeration provides a mapping from header types to array
		/// indexes. If a known header of a given type is included in the HTTP request, the array element at the index that corresponds to
		/// that type specifies the header value. Those elements of the array for which no corresponding headers are present contain a
		/// zero-valued <c>RawValueLength</c> member. Use <c>RawValueLength</c> to determine the end of the header string pointed to by
		/// <c>pRawValue</c>, rather than relying on the string to have a terminating null.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)HTTP_HEADER_ID.HttpHeaderRequestMaximum)]
		public HTTP_KNOWN_HEADER[] KnownHeaders;

		/// <summary>
		/// An array of HTTP_UNKNOWN_HEADER structures. This array contains one structure for each of the unknown headers sent
		/// in the HTTP request.
		/// </summary>
		public HTTP_UNKNOWN_HEADER[] UnknownHeaders => pUnknownHeaders.ToArray<HTTP_UNKNOWN_HEADER>(UnknownHeaderCount) ?? new HTTP_UNKNOWN_HEADER[0];
	}

	/// <summary>The <c>HTTP_REQUEST_INFO</c> structure extends the HTTP_REQUEST structure with additional information about the request.</summary>
	/// <remarks>
	/// Starting with the HTTP Server API version 2.0, the HTTP_REQUEST structure is extended to include an array of <c>HTTP_REQUEST_INFO</c>
	/// structures in the <c>pRequestInfo</c> member. These structures contain additional information for the request.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_info typedef struct _HTTP_REQUEST_INFO {
	// HTTP_REQUEST_INFO_TYPE InfoType; ULONG InfoLength; PVOID pInfo; } HTTP_REQUEST_INFO, *PHTTP_REQUEST_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_INFO
	{
		/// <summary>A member of the HTTP_REQUEST_INFO_TYPE enumeration specifying the type of information contained in this structure.</summary>
		public HTTP_REQUEST_INFO_TYPE InfoType;

		/// <summary>The length, in bytes, of the <c>pInfo</c> member.</summary>
		public uint InfoLength;

		/// <summary>
		/// A pointer to the HTTP_REQUEST_AUTH_INFO structure when the <c>InfoType</c> member is <c>HttpRequestInfoTypeAuth</c>; otherwise <c>NULL</c>.
		/// </summary>
		public IntPtr pInfo;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HTTP_REQUEST_PROPERTY_SNI
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = HTTP_REQUEST_PROPERTY_SNI_HOST_MAX_LENGTH + 1)]
		public string Hostname;

		public HTTP_REQUEST_PROPERTY_SNI_FLAG Flags;
	}

	/// <summary>The <c>HTTP_REQUEST_PROPERTY_STREAM_ERROR</c> structure represents an HTTP/2 or HTTP/3 stream error code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_property_stream_error typedef struct
	// _HTTP_REQUEST_PROPERTY_STREAM_ERROR { ULONG ErrorCode; } HTTP_REQUEST_PROPERTY_STREAM_ERROR, *PHTTP_REQUEST_PROPERTY_STREAM_ERROR;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_PROPERTY_STREAM_ERROR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_PROPERTY_STREAM_ERROR
	{
		/// <summary>The protocol stream error code.</summary>
		public uint ErrorCode;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HTTP_REQUEST_SIZING_INFO
	{
		public HTTP_REQUEST_SIZING_INFO_FLAG Flags;
		public uint RequestIndex;
		public uint RequestSizingCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)HTTP_REQUEST_SIZING_TYPE.HttpRequestSizingTypeMax)]
		public ulong[] RequestSizing;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HTTP_REQUEST_TIMING_INFO
	{
		public uint RequestTimingCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)HTTP_REQUEST_TIMING_TYPE.HttpRequestTimingTypeMax)]
		public ulong[] RequestTiming;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HTTP_REQUEST_TOKEN_BINDING_INFO
	{
		public IntPtr TokenBinding;
		public uint TokenBindingSize;
		public IntPtr EKM;
		public uint EKMSize;
		public byte KeyType;
	}

	/// <summary>
	/// <para>Uses the HTTP_REQUEST structure to return data associated with a specific request.</para>
	/// <para>
	/// Do not use <c>HTTP_REQUEST_V1</c> directly in your code; using HTTP_REQUEST instead ensures that the proper version, based on the
	/// operating system the code is compiled under, is used.
	/// </para>
	/// </summary>
	/// <remarks>
	/// The unprocessed URL contained in the <c>pRawUrl</c> member is for tracking and statistical purposes only. For other purposes, use the
	/// processed, canonical URL contained in the <c>CookedUrl</c> member.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_v1 typedef struct _HTTP_REQUEST_V1 { ULONG Flags;
	// HTTP_CONNECTION_ID ConnectionId; HTTP_REQUEST_ID RequestId; HTTP_URL_CONTEXT UrlContext; HTTP_VERSION Version; HTTP_VERB Verb; USHORT
	// UnknownVerbLength; USHORT RawUrlLength; PCSTR pUnknownVerb; PCSTR pRawUrl; HTTP_COOKED_URL CookedUrl; HTTP_TRANSPORT_ADDRESS Address;
	// HTTP_REQUEST_HEADERS Headers; ULONGLONG BytesReceived; USHORT EntityChunkCount; PHTTP_DATA_CHUNK pEntityChunks; HTTP_RAW_CONNECTION_ID
	// RawConnectionId; PHTTP_SSL_INFO pSslInfo; } HTTP_REQUEST_V1, *PHTTP_REQUEST_V1;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_V1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_V1
	{
		/// <summary>
		/// <para>A combination of zero or more of the following flag values may be combined, with OR, as appropriate.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_MORE_ENTITY_BODY_EXISTS</c></term>
		/// <term>
		/// There is more entity body to be read for this request. This applies only to incoming requests that span multiple reads. If this
		/// value is not set, either the whole entity body was copied into the buffer specified by <c>pEntityChunks</c> or the request did
		/// not include an entity body.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_IP_ROUTED</c></term>
		/// <term>
		/// The request was routed based on host and IP binding. The application should reflect the local IP while flushing kernel cache
		/// entries for this request. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_HTTP2</c></term>
		/// <term>Indicates the request was received over HTTP/2.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_REQUEST_FLAG Flags;

		/// <summary>
		/// An identifier for the connection on which the request was received. Use this value when calling HttpWaitForDisconnect or HttpReceiveClientCertificate.
		/// </summary>
		public HTTP_CONNECTION_ID ConnectionId;

		/// <summary>A value used to identify the request when calling HttpReceiveRequestEntityBody, HttpSendHttpResponse, and/or HttpSendResponseEntityBody.</summary>
		public HTTP_REQUEST_ID RequestId;

		/// <summary>
		/// <para>The context that is associated with the URL in the <c>pRawUrl</c> parameter.</para>
		/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c></para>
		/// </summary>
		public HTTP_URL_CONTEXT UrlContext;

		/// <summary>An HTTP_VERSION structure that contains the version of HTTP specified by this request.</summary>
		public HTTP_VERSION Version;

		/// <summary>An HTTP verb associated with this request. This member can be one of the values from the HTTP_VERB enumeration.</summary>
		public HTTP_VERB Verb;

		/// <summary>
		/// If the <c>Verb</c> member contains a value equal to <c>HttpVerbUnknown</c>, the <c>UnknownVerbLength</c> member contains the
		/// size, in bytes, of the string pointed to by the <c>pUnknownVerb</c> member, not including the terminating null character. If
		/// <c>Verb</c> is not equal to <c>HttpVerbUnknown</c>, <c>UnknownVerbLength</c> is equal to zero.
		/// </summary>
		public ushort UnknownVerbLength;

		/// <summary>
		/// The size, in bytes, of the unprocessed URL string pointed to by the <c>pRawUrl</c> member, not including the terminating null character.
		/// </summary>
		public ushort RawUrlLength;

		/// <summary>
		/// If the <c>Verb</c> member is equal to <c>HttpVerbUnknown</c>, <c>pUnknownVerb</c>, points to a null-terminated string of octets
		/// that contains the HTTP verb for this request; otherwise, the application ignores this parameter.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pUnknownVerb;

		/// <summary>
		/// A pointer to a string of octets that contains the original, unprocessed URL targeted by this request. Use this unprocessed URL
		/// only for tracking or statistical purposes; the <c>CookedUrl</c> member contains the canonical form of the URL for general use.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pRawUrl;

		/// <summary>
		/// An HTTP_COOKED_URL structure that contains a parsed canonical wide-character version of the URL targeted by this request. This is
		/// the version of the URL HTTP Listeners should act upon, rather than the raw URL.
		/// </summary>
		public HTTP_COOKED_URL CookedUrl;

		/// <summary>An HTTP_TRANSPORT_ADDRESS structure that contains the transport addresses for the connection for this request.</summary>
		public HTTP_TRANSPORT_ADDRESS Address;

		/// <summary>An HTTP_REQUEST_HEADERS structure that contains the headers specified in this request.</summary>
		public HTTP_REQUEST_HEADERS Headers;

		/// <summary>The total number of bytes received from the network comprising this request.</summary>
		public ulong BytesReceived;

		/// <summary>The number of elements in the <c>pEntityChunks</c> array. If no entity body was copied, this value is zero.</summary>
		public ushort EntityChunkCount;

		/// <summary>
		/// A pointer to an array of <see cref="HTTP_DATA_CHUNK"/> structures that contains the data blocks making up the entity body.
		/// HttpReceiveHttpRequest does not copy the entity body unless called with the HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY flag set.
		/// </summary>
		public IntPtr pEntityChunks;

		/// <summary>Raw connection ID for an Secure Sockets Layer (SSL) request.</summary>
		public HTTP_RAW_CONNECTION_ID RawConnectionId;

		/// <summary>
		/// A pointer to an <see cref="HTTP_SSL_INFO"/> structure that contains Secure Sockets Layer (SSL) information about the connection
		/// on which the request was received.
		/// </summary>
		public IntPtr pSslInfo;
	}

	/// <summary>
	/// <para>The <c>HTTP_REQUEST_V2</c> structure extends the HTTP_REQUEST_V1 request structure with more information about the request.</para>
	/// <para>
	/// Do not use <c>HTTP_REQUEST_V2</c> directly in your code; use HTTP_REQUEST instead to ensure that the proper version, based on the
	/// operating system the code is compiled under, is used.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_v2 typedef struct _HTTP_REQUEST_V2 : _HTTP_REQUEST_V1 {
	// USHORT RequestInfoCount; PHTTP_REQUEST_INFO pRequestInfo; } HTTP_REQUEST_V2, *PHTTP_REQUEST_V2;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_V2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_REQUEST_V2
	{
		/// <summary>
		/// <para>A combination of zero or more of the following flag values may be combined, with OR, as appropriate.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_MORE_ENTITY_BODY_EXISTS</c></term>
		/// <term>
		/// There is more entity body to be read for this request. This applies only to incoming requests that span multiple reads. If this
		/// value is not set, either the whole entity body was copied into the buffer specified by <c>pEntityChunks</c> or the request did
		/// not include an entity body.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_IP_ROUTED</c></term>
		/// <term>
		/// The request was routed based on host and IP binding. The application should reflect the local IP while flushing kernel cache
		/// entries for this request. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_HTTP2</c></term>
		/// <term>Indicates the request was received over HTTP/2.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_REQUEST_FLAG Flags;

		/// <summary>
		/// An identifier for the connection on which the request was received. Use this value when calling HttpWaitForDisconnect or HttpReceiveClientCertificate.
		/// </summary>
		public HTTP_CONNECTION_ID ConnectionId;

		/// <summary>A value used to identify the request when calling HttpReceiveRequestEntityBody, HttpSendHttpResponse, and/or HttpSendResponseEntityBody.</summary>
		public HTTP_REQUEST_ID RequestId;

		/// <summary>
		/// <para>The context that is associated with the URL in the <c>pRawUrl</c> parameter.</para>
		/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c></para>
		/// </summary>
		public HTTP_URL_CONTEXT UrlContext;

		/// <summary>An HTTP_VERSION structure that contains the version of HTTP specified by this request.</summary>
		public HTTP_VERSION Version;

		/// <summary>An HTTP verb associated with this request. This member can be one of the values from the HTTP_VERB enumeration.</summary>
		public HTTP_VERB Verb;

		/// <summary>
		/// If the <c>Verb</c> member contains a value equal to <c>HttpVerbUnknown</c>, the <c>UnknownVerbLength</c> member contains the
		/// size, in bytes, of the string pointed to by the <c>pUnknownVerb</c> member, not including the terminating null character. If
		/// <c>Verb</c> is not equal to <c>HttpVerbUnknown</c>, <c>UnknownVerbLength</c> is equal to zero.
		/// </summary>
		public ushort UnknownVerbLength;

		/// <summary>
		/// The size, in bytes, of the unprocessed URL string pointed to by the <c>pRawUrl</c> member, not including the terminating null character.
		/// </summary>
		public ushort RawUrlLength;

		/// <summary>
		/// If the <c>Verb</c> member is equal to <c>HttpVerbUnknown</c>, <c>pUnknownVerb</c>, points to a null-terminated string of octets
		/// that contains the HTTP verb for this request; otherwise, the application ignores this parameter.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pUnknownVerb;

		/// <summary>
		/// A pointer to a string of octets that contains the original, unprocessed URL targeted by this request. Use this unprocessed URL
		/// only for tracking or statistical purposes; the <c>CookedUrl</c> member contains the canonical form of the URL for general use.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pRawUrl;

		/// <summary>
		/// An HTTP_COOKED_URL structure that contains a parsed canonical wide-character version of the URL targeted by this request. This is
		/// the version of the URL HTTP Listeners should act upon, rather than the raw URL.
		/// </summary>
		public HTTP_COOKED_URL CookedUrl;

		/// <summary>An HTTP_TRANSPORT_ADDRESS structure that contains the transport addresses for the connection for this request.</summary>
		public HTTP_TRANSPORT_ADDRESS Address;

		/// <summary>An HTTP_REQUEST_HEADERS structure that contains the headers specified in this request.</summary>
		public HTTP_REQUEST_HEADERS Headers;

		/// <summary>The total number of bytes received from the network comprising this request.</summary>
		public ulong BytesReceived;

		/// <summary>The number of elements in the <c>pEntityChunks</c> array. If no entity body was copied, this value is zero.</summary>
		public ushort EntityChunkCount;

		/// <summary>
		/// A pointer to an array of <see cref="HTTP_DATA_CHUNK"/> structures that contains the data blocks making up the entity body.
		/// HttpReceiveHttpRequest does not copy the entity body unless called with the HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY flag set.
		/// </summary>
		public IntPtr pEntityChunks;

		/// <summary>Raw connection ID for an Secure Sockets Layer (SSL) request.</summary>
		public HTTP_RAW_CONNECTION_ID RawConnectionId;

		/// <summary>
		/// A pointer to an <see cref="HTTP_SSL_INFO"/> structure that contains Secure Sockets Layer (SSL) information about the connection
		/// on which the request was received.
		/// </summary>
		public IntPtr pSslInfo;

		/// <summary>The number of HTTP_REQUEST_INFO structures in the array pointed to by <c>pRequestInfo</c>.</summary>
		public ushort RequestInfoCount;

		/// <summary>
		/// A pointer to an array of <see cref="HTTP_REQUEST_INFO"/> structures that contains additional information about the request.
		/// </summary>
		public IntPtr pRequestInfo;
	}

	/// <summary>
	/// <para>The <c>HTTP_REQUEST_V2</c> structure extends the HTTP_REQUEST_V1 request structure with more information about the request.</para>
	/// <para>
	/// Do not use <c>HTTP_REQUEST_V2</c> directly in your code; use HTTP_REQUEST instead to ensure that the proper version, based on the
	/// operating system the code is compiled under, is used.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_request_v2 typedef struct _HTTP_REQUEST_V2 : _HTTP_REQUEST_V1 {
	// USHORT RequestInfoCount; PHTTP_REQUEST_INFO pRequestInfo; } HTTP_REQUEST_V2, *PHTTP_REQUEST_V2;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_REQUEST_V2")]
	public class HTTP_REQUEST : IDisposable
	{
		public HTTP_REQUEST() => Ptr = new SafeCoTaskMemStruct<HTTP_REQUEST_V2>();

		internal HTTP_REQUEST(SafeCoTaskMemStruct<HTTP_REQUEST_V2> value) => Ptr = value;

		/// <inheritdoc/>
		void IDisposable.Dispose() => Ptr.Dispose();

		/// <summary>
		/// <para>A combination of zero or more of the following flag values may be combined, with OR, as appropriate.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_MORE_ENTITY_BODY_EXISTS</c></term>
		/// <term>
		/// There is more entity body to be read for this request. This applies only to incoming requests that span multiple reads. If this
		/// value is not set, either the whole entity body was copied into the buffer specified by <c>pEntityChunks</c> or the request did
		/// not include an entity body.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_IP_ROUTED</c></term>
		/// <term>
		/// The request was routed based on host and IP binding. The application should reflect the local IP while flushing kernel cache
		/// entries for this request. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_REQUEST_FLAG_HTTP2</c></term>
		/// <term>Indicates the request was received over HTTP/2.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_REQUEST_FLAG Flags => Ptr.AsRef().Flags;

		/// <summary>
		/// An identifier for the connection on which the request was received. Use this value when calling HttpWaitForDisconnect or HttpReceiveClientCertificate.
		/// </summary>
		public HTTP_CONNECTION_ID ConnectionId => Ptr.AsRef().ConnectionId;

		/// <summary>A value used to identify the request when calling HttpReceiveRequestEntityBody, HttpSendHttpResponse, and/or HttpSendResponseEntityBody.</summary>
		public HTTP_REQUEST_ID RequestId => Ptr.AsRef().RequestId;

		/// <summary>
		/// <para>The context that is associated with the URL in the <c>pRawUrl</c> parameter.</para>
		/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c></para>
		/// </summary>
		public HTTP_URL_CONTEXT UrlContext => Ptr.AsRef().UrlContext;

		/// <summary>An HTTP_VERSION structure that contains the version of HTTP specified by this request.</summary>
		public HTTP_VERSION Version => Ptr.AsRef().Version;

		/// <summary>An HTTP verb associated with this request. This member can be one of the values from the HTTP_VERB enumeration.</summary>
		public HTTP_VERB Verb => Ptr.AsRef().Verb;

		/// <summary>
		/// If the <c>Verb</c> member is equal to <c>HttpVerbUnknown</c>, <c>pUnknownVerb</c>, points to a null-terminated string of octets
		/// that contains the HTTP verb for this request; otherwise, the application ignores this parameter.
		/// </summary>
		public string UnknownVerb => Ptr.AsRef().pUnknownVerb;

		/// <summary>
		/// A pointer to a string of octets that contains the original, unprocessed URL targeted by this request. Use this unprocessed URL
		/// only for tracking or statistical purposes; the <c>CookedUrl</c> member contains the canonical form of the URL for general use.
		/// </summary>
		public string RawUrl => Ptr.AsRef().pRawUrl;

		/// <summary>
		/// An HTTP_COOKED_URL structure that contains a parsed canonical wide-character version of the URL targeted by this request. This is
		/// the version of the URL HTTP Listeners should act upon, rather than the raw URL.
		/// </summary>
		public HTTP_COOKED_URL CookedUrl => Ptr.AsRef().CookedUrl;

		/// <summary>An HTTP_TRANSPORT_ADDRESS structure that contains the transport addresses for the connection for this request.</summary>
		public HTTP_TRANSPORT_ADDRESS Address => Ptr.AsRef().Address;

		/// <summary>An HTTP_REQUEST_HEADERS structure that contains the headers specified in this request.</summary>
		public HTTP_REQUEST_HEADERS Headers => Ptr.AsRef().Headers;

		/// <summary>The total number of bytes received from the network comprising this request.</summary>
		public ulong BytesReceived => Ptr.AsRef().BytesReceived;

		/// <summary>
		/// An array of <see cref="HTTP_DATA_CHUNK"/> structures that contains the data blocks making up the entity body.
		/// HttpReceiveHttpRequest does not copy the entity body unless called with the HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY flag set.
		/// </summary>
		public HTTP_DATA_CHUNK[] EntityChunks => Ptr.AsRef().pEntityChunks.ToArray<HTTP_DATA_CHUNK>(Ptr.AsRef().EntityChunkCount) ?? new HTTP_DATA_CHUNK[0];

		/// <summary>Raw connection ID for an Secure Sockets Layer (SSL) request.</summary>
		public HTTP_RAW_CONNECTION_ID RawConnectionId => Ptr.AsRef().RawConnectionId;

		/// <summary>
		/// A <see cref="HTTP_SSL_INFO"/> structure that contains Secure Sockets Layer (SSL) information about the connection
		/// on which the request was received.
		/// </summary>
		public HTTP_SSL_INFO? SslInfo => Ptr.AsRef().pSslInfo.ToNullableStructure<HTTP_SSL_INFO>();

		/// <summary>
		/// An array of <see cref="HTTP_REQUEST_INFO"/> structures that contains additional information about the request.
		/// </summary>
		public HTTP_REQUEST_INFO[] RequestInfo => Ptr.AsRef().pRequestInfo.ToArray<HTTP_REQUEST_INFO>(Ptr.AsRef().RequestInfoCount) ?? new HTTP_REQUEST_INFO[0];

		internal SafeCoTaskMemStruct<HTTP_REQUEST_V2> Ptr { get; private set; }
	}

	/// <summary>The <c>HTTP_RESPONSE_HEADERS</c> structure contains the headers sent with an HTTP response.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_headers typedef struct _HTTP_RESPONSE_HEADERS { USHORT
	// UnknownHeaderCount; PHTTP_UNKNOWN_HEADER pUnknownHeaders; USHORT TrailerCount; PHTTP_UNKNOWN_HEADER pTrailers; HTTP_KNOWN_HEADER
	// KnownHeaders[HttpHeaderResponseMaximum]; } HTTP_RESPONSE_HEADERS, *PHTTP_RESPONSE_HEADERS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_RESPONSE_HEADERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_RESPONSE_HEADERS
	{
		/// <summary>
		/// A number of unknown headers sent with the HTTP response and contained in the array pointed to by the <c>pUnknownHeaders</c>
		/// member. This number cannot exceed 9999.
		/// </summary>
		public ushort UnknownHeaderCount;

		/// <summary>
		/// A pointer to an array of HTTP_UNKNOWN_HEADER structures that contains one structure for each of the unknown headers sent in the
		/// HTTP response.
		/// </summary>
		public IntPtr pUnknownHeaders;

		/// <summary>This member is reserved and must be zero.</summary>
		public ushort TrailerCount;

		/// <summary>This member is reserved and must be <c>NULL</c>.</summary>
		public IntPtr pTrailers;

		/// <summary>
		/// Fixed-size array of HTTP_KNOWN_HEADER structures. The HTTP_HEADER_ID enumeration provides a mapping from header types to array
		/// indexes. If a known header of a given type is included in the HTTP response, the array element at the index that corresponds to
		/// that type specifies the header value. Those elements of the array for which no corresponding headers are present contain a
		/// zero-valued <c>RawValueLength</c> member. Use <c>RawValueLength</c> to determine the end of the header string pointed to by
		/// <c>pRawValue</c>, rather than relying on the string to have a terminating null.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)HTTP_HEADER_ID.HttpHeaderResponseMaximum)]
		public HTTP_KNOWN_HEADER[] KnownHeaders;
	}

	/// <summary>The <c>HTTP_RESPONSE_INFO</c> structure extends the HTTP_RESPONSE structure with additional information for the response.</summary>
	/// <remarks>
	/// Starting with the HTTP Server API version 2.0, the HTTP_RESPONSE structure is extended to include an array of
	/// <c>HTTP_RESPONSE_INFO</c> structures in the <c>pRequestInfo</c> member. These structures contain additional information for the response.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_info typedef struct _HTTP_RESPONSE_INFO {
	// HTTP_RESPONSE_INFO_TYPE Type; ULONG Length; PVOID pInfo; } HTTP_RESPONSE_INFO, *PHTTP_RESPONSE_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_RESPONSE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_RESPONSE_INFO
	{
		/// <summary>A member of the HTTP_RESPONSE_INFO_TYPE enumeration specifying the type of information contained in this structure.</summary>
		public HTTP_RESPONSE_INFO_TYPE Type;

		/// <summary>The length, in bytes, of the <c>pInfo</c> member.</summary>
		public uint Length;

		/// <summary>
		/// A pointer to the <see cref="HTTP_MULTIPLE_KNOWN_HEADERS"/> structure when the <c>InfoType</c> member is
		/// <c>HttpResponseInfoTypeMultipleKnownHeaders</c>; otherwise <c>NULL</c>.
		/// </summary>
		public IntPtr pInfo;
	}

	/// <summary>
	/// <para>The <c>HTTP_RESPONSE_V1</c> structure contains data associated with an HTTP response.</para>
	/// <para>
	/// Do not use <c>HTTP_RESPONSE_V1</c> directly in your code; use HTTP_RESPONSE instead to ensure that the proper version, based on the
	/// operating system the code is compiled under, is used.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_v1 typedef struct _HTTP_RESPONSE_V1 { ULONG Flags;
	// HTTP_VERSION Version; USHORT StatusCode; USHORT ReasonLength; PCSTR pReason; HTTP_RESPONSE_HEADERS Headers; USHORT EntityChunkCount;
	// PHTTP_DATA_CHUNK pEntityChunks; } HTTP_RESPONSE_V1, *PHTTP_RESPONSE_V1;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_RESPONSE_V1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_RESPONSE_V1
	{
		/// <summary>
		/// The optional logging flags change the default response behavior. These can be one of any of the HTTP_RESPONSE_FLAG values.
		/// </summary>
		public HTTP_RESPONSE_FLAGS Flags;

		/// <summary>This member is ignored; the response is always an HTTP/1.1 response.</summary>
		public HTTP_VERSION Version;

		/// <summary>
		/// <para>
		/// Numeric status code that characterizes the result of the HTTP request (for example, 200 signifying "OK" or 404 signifying "Not
		/// Found"). For more information and a list of these codes, see Section 10 of RFC 2616.
		/// </para>
		/// <para>
		/// If a request is directed to a URL that is reserved but not registered, indicating that the appropriate application to handle it
		/// is not running, then the HTTP Server API itself returns a response with status code 400, signifying "Bad Request". This is
		/// transparent to the application. A code 400 is preferred here to 503 ("Server not available") because the latter is interpreted by
		/// some smart load balancers as an indication that the server is overloaded.
		/// </para>
		/// </summary>
		public ushort StatusCode;

		/// <summary>
		/// Size, in bytes, of the string pointed to by the <c>pReason</c> member not including the terminating null. May be zero.
		/// </summary>
		public ushort ReasonLength;

		/// <summary>
		/// A pointer to a human-readable, null-terminated string of printable characters that characterizes the result of the HTTP request
		/// (for example, "OK" or "Not Found").
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pReason;

		/// <summary>An HTTP_RESPONSE_HEADERS structure that contains the headers used in this response.</summary>
		public HTTP_RESPONSE_HEADERS Headers;

		/// <summary>
		/// A number of entity-body data blocks specified in the <c>pEntityChunks</c> array. This number cannot exceed 100. If the response
		/// has no entity body, this member must be zero.
		/// </summary>
		public ushort EntityChunkCount;

		/// <summary>
		/// An array of <see cref="HTTP_DATA_CHUNK"/> structures that together specify all the data blocks that make up the entity body of
		/// the response.
		/// </summary>
		public IntPtr pEntityChunks;
	}

	/// <summary>
	/// <para>The <c>HTTP_RESPONSE_V2</c> structure extends the HTTP version 1.0 response structure with more information for the response.</para>
	/// <para>
	/// Do not use <c>HTTP_RESPONSE_V2</c> directly in your code; use HTTP_RESPONSE instead to ensure that the proper version, based on the
	/// operating system the code is compiled under, is used.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_response_v2 typedef struct _HTTP_RESPONSE_V2 : _HTTP_RESPONSE_V1
	// { USHORT ResponseInfoCount; PHTTP_RESPONSE_INFO pResponseInfo; } HTTP_RESPONSE_V2, *PHTTP_RESPONSE_V2;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_RESPONSE_V2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_RESPONSE_V2
	{
		/// <summary>
		/// The optional logging flags change the default response behavior. These can be one of any of the HTTP_RESPONSE_FLAG values.
		/// </summary>
		public HTTP_RESPONSE_FLAGS Flags;

		/// <summary>This member is ignored; the response is always an HTTP/1.1 response.</summary>
		public HTTP_VERSION Version;

		/// <summary>
		/// <para>
		/// Numeric status code that characterizes the result of the HTTP request (for example, 200 signifying "OK" or 404 signifying "Not
		/// Found"). For more information and a list of these codes, see Section 10 of RFC 2616.
		/// </para>
		/// <para>
		/// If a request is directed to a URL that is reserved but not registered, indicating that the appropriate application to handle it
		/// is not running, then the HTTP Server API itself returns a response with status code 400, signifying "Bad Request". This is
		/// transparent to the application. A code 400 is preferred here to 503 ("Server not available") because the latter is interpreted by
		/// some smart load balancers as an indication that the server is overloaded.
		/// </para>
		/// </summary>
		public ushort StatusCode;

		/// <summary>
		/// Size, in bytes, of the string pointed to by the <c>pReason</c> member not including the terminating null. May be zero.
		/// </summary>
		public ushort ReasonLength;

		/// <summary>
		/// A pointer to a human-readable, null-terminated string of printable characters that characterizes the result of the HTTP request
		/// (for example, "OK" or "Not Found").
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pReason;

		/// <summary>An HTTP_RESPONSE_HEADERS structure that contains the headers used in this response.</summary>
		public HTTP_RESPONSE_HEADERS Headers;

		/// <summary>
		/// A number of entity-body data blocks specified in the <c>pEntityChunks</c> array. This number cannot exceed 100. If the response
		/// has no entity body, this member must be zero.
		/// </summary>
		public ushort EntityChunkCount;

		/// <summary>
		/// An array of <see cref="HTTP_DATA_CHUNK"/> structures that together specify all the data blocks that make up the entity body of
		/// the response.
		/// </summary>
		public IntPtr pEntityChunks;

		/// <summary>
		/// <para>The number of HTTP_RESPONSE_INFO structures in the array pointed to by <c>pResponseInfo</c>.</para>
		/// <para>The count of the HTTP_RESPONSE_INFO elements in the array pointed to by <c>pResponseInfo</c>.</para>
		/// </summary>
		public ushort ResponseInfoCount;

		/// <summary>A pointer to an array of <see cref="HTTP_RESPONSE_INFO"/> structures containing more information about the request.</summary>
		public IntPtr pResponseInfo;

		/// <summary>Performs an implicit conversion from <see cref="HTTP_RESPONSE_V1"/> to <see cref="HTTP_RESPONSE_V2"/>.</summary>
		/// <param name="v1">The v1 value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTTP_RESPONSE_V2(HTTP_RESPONSE_V1 v1) => new HTTP_RESPONSE_V2
		{
			Flags = v1.Flags,
			Version = v1.Version,
			StatusCode = v1.StatusCode,
			ReasonLength = v1.ReasonLength,
			pReason = v1.pReason,
			Headers = v1.Headers,
			EntityChunkCount = v1.EntityChunkCount,
			pEntityChunks = v1.pEntityChunks,
		};
	}

	/// <summary>
	/// <para>The <c>HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS</c> structure contains the information for Basic authentication on a URL Group.</para>
	/// <para>This structure is contained in the HTTP_SERVER_AUTHENTICATION_INFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_server_authentication_basic_params typedef struct
	// _HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS { USHORT RealmLength; PWSTR Realm; } HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS, *PHTTP_SERVER_AUTHENTICATION_BASIC_PARAMS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS
	{
		/// <summary>The length, in bytes, of the <c>Realm</c> member.</summary>
		public ushort RealmLength;

		/// <summary>
		/// <para>The realm used for Basic authentication.</para>
		/// <para>
		/// The realm allows the server to be partitioned into a set of protection spaces, each with its own set of authentication schemes
		/// from the authentication database.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Realm;
	}

	/// <summary>
	/// <para>The <c>HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS</c> structure contains the information for digest authentication on a URL Group.</para>
	/// <para>This structure is contained in the HTTP_SERVER_AUTHENTICATION_INFO structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_server_authentication_digest_params typedef struct
	// _HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS { USHORT DomainNameLength; PWSTR DomainName; USHORT RealmLength; PWSTR Realm; }
	// HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS, *PHTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS
	{
		/// <summary>The length, in bytes, of the <c>DomainName</c> member.</summary>
		public ushort DomainNameLength;

		/// <summary>
		/// <para>The domain name used for Digest authentication.</para>
		/// <para>If <c>NULL</c>, the client assumes the protection space consists of all the URIs under the responding server.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? DomainName;

		/// <summary>The length, in bytes, of the <c>Realm</c> member.</summary>
		public ushort RealmLength;

		/// <summary>
		/// <para>The realm used for Digest authentication.</para>
		/// <para>
		/// The realm allows the server to be partitioned into a set of protection spaces, each with its own set of authentication schemes
		/// from the authentication database.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Realm;
	}

	/// <summary>
	/// <para>
	/// The <c>HTTP_SERVER_AUTHENTICATION_INFO</c> structure is used to enable server-side authentication on a URL group or server session.
	/// This structure is also used to query the existing authentication schemes enabled for a URL group or server session.
	/// </para>
	/// <para>This structure must be used when setting or querying the HttpServerAuthenticationProperty on a URL group, or server session.</para>
	/// </summary>
	/// <remarks>
	/// The <c>HTTP_SERVER_AUTHENTICATION_INFO</c> structure is included in the HTTP request if authentication has been configured on the
	/// associated URL group. The original HTTP authentication header received from the client is always included in the HTTP request,
	/// regardless of the authentication status.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_server_authentication_info typedef struct
	// _HTTP_SERVER_AUTHENTICATION_INFO { HTTP_PROPERTY_FLAGS Flags; ULONG AuthSchemes; BOOLEAN ReceiveMutualAuth; BOOLEAN
	// ReceiveContextHandle; BOOLEAN DisableNTLMCredentialCaching; UCHAR ExFlags; HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS DigestParams;
	// HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS BasicParams; } HTTP_SERVER_AUTHENTICATION_INFO, *PHTTP_SERVER_AUTHENTICATION_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVER_AUTHENTICATION_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVER_AUTHENTICATION_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure that specifies if the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// <para>The supported authentication schemes. This can be one or more of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Authentication Scheme</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_AUTH_ENABLE_BASIC</c></term>
		/// <term>Basic authentication is enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_AUTH_ENABLE_DIGEST</c></term>
		/// <term>Digest authentication is enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_AUTH_ENABLE_NTLM</c></term>
		/// <term>NTLM authentication is enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_AUTH_ENABLE_NEGOTIATE</c></term>
		/// <term>Negotiate authentication is enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_AUTH_ENABLE_KERBEROS</c></term>
		/// <term>Kerberos authentication is enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_AUTH_ENABLE_ALL</c></term>
		/// <term>All types of authentication are enabled.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_AUTH_ENABLE AuthSchemes;

		/// <summary>
		/// <para>
		/// A Boolean value that indicates, if <c>True</c>, that the client application receives the server credentials for mutual
		/// authentication with the authenticated request. If <c>False</c>, the client application does not receive the credentials.
		/// </para>
		/// <para>Be aware that this option is set for all requests served by the associated request queue.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool ReceiveMutualAuth;

		/// <summary>
		/// A Boolean value that indicates, if <c>True</c>, that the finalized client context is serialized and passed to the application
		/// with the request. If <c>False</c>, the application does not receive the context. This handle can be used to query context attributes.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool ReceiveContextHandle;

		/// <summary>
		/// <para>
		/// A Boolean value that indicates, if <c>True</c>, that the NTLM credentials are not cached. If <c>False</c>, the default behavior
		/// is preserved.
		/// </para>
		/// <para>
		/// By default, HTTP caches the client context for Keep Alive (KA) connections for the NTLM scheme if the request did not originate
		/// from a proxy.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool DisableNTLMCredentialCaching;

		/// <summary>
		/// <para>Optional authentication flags. Can be one or more of the following possible values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_AUTH_EX_FLAG_ENABLE_KERBEROS_CREDENTIAL_CACHING</c></term>
		/// <term>If set, the Kerberos authentication credentials are cached. Kerberos or Negotiate authentication must be enabled by <c>AuthSchemes</c>.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_AUTH_EX_FLAG_CAPTURE_CREDENTIAL</c></term>
		/// <term>
		/// If set, the HTTP Server API captures the caller's credentials and uses them for Kerberos or Negotiate authentication. Kerberos or
		/// Negotiate authentication must be enabled by <c>AuthSchemes</c>.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_AUTH_EX_FLAG ExFlags;

		/// <summary>The HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS structure that provides the domain and realm for the digest challenge.</summary>
		public HTTP_SERVER_AUTHENTICATION_DIGEST_PARAMS DigestParams;

		/// <summary>The HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS structure that provides the realm for the basic challenge.</summary>
		public HTTP_SERVER_AUTHENTICATION_BASIC_PARAMS BasicParams;
	}

	/// <summary>The <c>HTTP_SERVICE_BINDING_A</c> structure provides Service Principle Name (SPN) in ASCII.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_binding_a typedef struct _HTTP_SERVICE_BINDING_A {
	// HTTP_SERVICE_BINDING_BASE Base; PCHAR Buffer; ULONG BufferSize; } HTTP_SERVICE_BINDING_A, *PHTTP_SERVICE_BINDING_A;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_BINDING_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct HTTP_SERVICE_BINDING_A
	{
		/// <summary>An HTTP_SERVICE_BINDING_BASE value, the <c>Type</c> member of which must be set to <c>HttpServiceBindingTypeA</c>.</summary>
		public HTTP_SERVICE_BINDING_BASE Base;

		/// <summary>A pointer to a buffer that represents the SPN.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string Buffer;

		/// <summary>The length, in bytes, of the string in <c>Buffer</c>.</summary>
		public uint BufferSize;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_BINDING_BASE</c> structure is a placeholder for the HTTP_SERVICE_BINDING_A structure and the
	/// HTTP_SERVICE_BINDING_W structure.
	/// </summary>
	/// <remarks>
	/// <c>Note</c>
	/// <para></para>
	/// The first member of both the HTTP_SERVICE_BINDING_A structure and the HTTP_SERVICE_BINDING_W structure is a
	/// <c>HTTP_SERVICE_BINDING_BASE</c> structure. Therefore, an array of either of the first two structures can be indicated by a pointer
	/// to a <c>HTTP_SERVICE_BINDING_BASE</c> structure.
	/// <para></para>
	/// The <c>ServiceNames</c> member of the HTTP_CHANNEL_BIND_INFO structure is cast to a pointer to a <c>HTTP_SERVICE_BINDING_BASE</c>
	/// structure for this purpose.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_binding_base typedef struct _HTTP_SERVICE_BINDING_BASE {
	// HTTP_SERVICE_BINDING_TYPE Type; } HTTP_SERVICE_BINDING_BASE, *PHTTP_SERVICE_BINDING_BASE;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_BINDING_BASE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_BINDING_BASE
	{
		/// <summary>An HTTP_SERVICE_BINDING_TYPE value that indicates whether the data is in ASCII or Unicode.</summary>
		public HTTP_SERVICE_BINDING_TYPE Type;
	}

	/// <summary>The <c>HTTP_SERVICE_BINDING_W</c> structure provides Service Principle Name (SPN) in Unicode.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_binding_w typedef struct _HTTP_SERVICE_BINDING_W {
	// HTTP_SERVICE_BINDING_BASE Base; PWCHAR Buffer; ULONG BufferSize; } HTTP_SERVICE_BINDING_W, *PHTTP_SERVICE_BINDING_W;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_BINDING_W")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct HTTP_SERVICE_BINDING_W
	{
		/// <summary>An HTTP_SERVICE_BINDING_BASE value, the <c>Type</c> member of which must be set to <c>HttpServiceBindingTypeW</c>.</summary>
		public HTTP_SERVICE_BINDING_BASE Base;

		/// <summary>A pointer to a buffer that represents the SPN.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Buffer;

		/// <summary>The length, in bytes, of the string in <c>Buffer</c>.</summary>
		public uint BufferSize;
	}

	/// <summary>Used in the <c>pConfigInformation</c> parameter of the HttpSetServiceConfiguration function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_cache_set typedef struct {
	// HTTP_SERVICE_CONFIG_CACHE_KEY KeyDesc; HTTP_SERVICE_CONFIG_CACHE_PARAM ParamDesc; } HTTP_SERVICE_CONFIG_CACHE_SET, *PHTTP_SERVICE_CONFIG_CACHE_SET;
	[PInvokeData("http.h", MSDNShortId = "NS:http.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_CACHE_SET
	{
		/// <summary>Cache key.</summary>
		public HTTP_SERVICE_CONFIG_CACHE_KEY KeyDesc;

		/// <summary>Configuration cache parameter.</summary>
		public uint ParamDesc;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM</c> structure is used to specify an IP address to be added to or deleted from the list of
	/// IP addresses to which the HTTP service binds.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ip_listen_param typedef struct
	// _HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM { USHORT AddrLength; PSOCKADDR pAddress; } HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM, *PHTTP_SERVICE_CONFIG_IP_LISTEN_PARAM;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM
	{
		/// <summary>The size, in bytes, of the address pointed to by <c>pAddress</c>.</summary>
		public ushort AddrLength;

		/// <summary>
		/// <para>A pointer to an Internet Protocol (IP) address to be added to or deleted from the listen list.</para>
		/// <para>
		/// To specify an IPv6 address, use a SOCKADDR_IN6 structure, declared in the Ws2tcpip.h header file, and cast its address to a
		/// PSOCKADDR when you use it to set the <c>pAddress</c> member. The <c>sin_family</c> member of the SOCKADDR_IN6 should be set to AF_INET6.
		/// </para>
		/// <para>
		/// If the <c>sin_addr</c> field in SOCKADDR_IN6 structure is set to 0.0.0.0, it means to bind to all IPv4 addresses. If the
		/// <c>sin6_addr</c> field in SOCKADDR_IN6 is set to [::], it means to bind to all IPv6 addresses.
		/// </para>
		/// </summary>
		public IntPtr pAddress;

		/// <summary>Initializes a new instance of the <see cref="HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM"/> struct.</summary>
		/// <param name="sockaddr">The SOCKADDR instance.</param>
		public HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM(SOCKADDR sockaddr)
		{
			AddrLength = (ushort)(uint)sockaddr.Size;
			pAddress = sockaddr;
		}
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY</c> structure is used by HttpQueryServiceConfiguration to return a list of the Internet
	/// Protocol (IP) addresses to which the HTTP service binds.
	/// </summary>
	/// <remarks>
	/// <para>
	/// An IPv4 address may be expressed as a literal string of four dotted decimal numbers, each in the range 0-255, such as
	/// 192.168.197.113. IPv4 addresses are contained in <c>sockaddr_in</c> structures, declared in the Windows header file Winsock2.h as follows:
	/// </para>
	/// <para>
	/// <code> struct sockaddr_in { short sin_family; /* == AF_INET */ u_short sin_port; /* Transport-level port number */ struct in_addr sin_addr; /* IPv4 address */ char sin_zero[8]; };</code>
	/// </para>
	/// <para>The <c>SOCKADDR_IN</c> structure is exactly equivalent to <c>sockaddr_in</c> by typedef.</para>
	/// <para>
	/// An IPv6 address can be expressed as a literal string enclosed in square brackets that contains hex numbers separated by colons;
	/// examples are: [::1] and [3ffe:ffff:6ECB:0101]. IPv6 addresses are contained in <c>sockaddr_in6</c> structures, declared in the
	/// Windows header file WS2tcpip.h as follows:
	/// </para>
	/// <para>
	/// <code> struct sockaddr_in6 { short sin6_family; /* == AF_INET6 */ u_short sin6_port; /* Transport-level port number */ u_long sin6_flowinfo; /* IPv6 flow information */ IN6_ADDR sin6_addr; /* IPv6 address */ u_long sin6_scope_id; /* set of scope interfaces */ };</code>
	/// </para>
	/// <para>The <c>SOCKADDR_IN6</c> structure is exactly equivalent to <c>sockaddr_in6</c> by typedef.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ip_listen_query typedef struct
	// _HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY { ULONG AddrCount; SOCKADDR_STORAGE AddrList[ANYSIZE_ARRAY]; }
	// HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY, *PHTTP_SERVICE_CONFIG_IP_LISTEN_QUERY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY>), nameof(AddrCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY
	{
		/// <summary>The number of address structures in the <c>AddrList</c> array.</summary>
		public uint AddrCount;

		/// <summary>
		/// An array of SOCKADDR_STORAGE structures that contains IP addresses in either IPv4 or IPv6 form. To determine what form an address
		/// in the list has, cast it to a SOCKADDR and examine the <c>sa_family</c> element. If <c>sa_family</c> is equal to AF_INET, the
		/// address is in IPv4 form, or if it is equal to AF_INET6, the address is in IPv6 form.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public SOCKADDR_STORAGE[] AddrList;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SETTING_SET
	{
		public HTTP_SERVICE_CONFIG_SETTING_KEY KeyDesc;
		public HTTP_SERVICE_CONFIG_SETTING_PARAM ParamDesc;
	}

	/// <summary>
	/// Serves as the key by which identifies the SSL certificate record that specifies that Http.sys should consult the Centralized
	/// Certificate Store (CCS) store to find certificates if the port receives a Transport Layer Security (TLS) handshake.
	/// </summary>
	/// <remarks>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_CCS_KEY</c> structure appears in the HTTP_SERVICE_CONFIG_SSL_CCS_SET and the
	/// HTTP_SERVICE_CONFIG_SSL_CCS_QUERY structures. <c>HTTP_SERVICE_CONFIG_SSL_CCS_KEY</c> is passed as part of these structures in the
	/// <c>pConfigInformation</c>, <c>ConfigInfo</c>, <c>pInputConfigInfo</c>, and <c>pOutputConfigInfo</c> parameters to the
	/// HttpDeleteServiceConfiguration, HttpQueryServiceConfiguration, HttpSetServiceConfiguration, and HttpUpdateServiceConfiguration
	/// functions when the <c>ConfigId</c> parameter is set to <c>HttpServiceConfigSslCcsCertInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_ccs_key typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_CCS_KEY { SOCKADDR_STORAGE LocalAddress; } HTTP_SERVICE_CONFIG_SSL_CCS_KEY, *PHTTP_SERVICE_CONFIG_SSL_CCS_KEY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_CCS_KEY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_CCS_KEY
	{
		/// <summary>
		/// A SOCKADDR_STORAGE structure that contains the Internet Protocol version 4 (IPv4) address with which this SSL certificate record
		/// is associated. It must be set to the IPv4 wildcard address of type SOCKADDR_IN with the <c>sin_family</c> member set to AF_INET
		/// and the <c>sin_addr</c> member filled with zeros (0.0.0.0). The <c>sin_port</c> member can be any valid port.
		/// </summary>
		public SOCKADDR_STORAGE LocalAddress;
	}

	/// <summary>
	/// Specifies a Secure Sockets Layer (SSL) configuration to query for an SSL Centralized Certificate Store (CCS) record on the port when
	/// you call the HttpQueryServiceConfiguration function. The SSL certificate record specifies that Http.sys should consult the CCS store
	/// to find certificates if the port receives a Transport Layer Security (TLS) handshake.
	/// </summary>
	/// <remarks>
	/// Pass this structure to the HttpQueryServiceConfiguration function by using the <c>pInputConfigInfo</c> parameter when the
	/// <c>ConfigId</c> parameter is set to <c>HttpServiceConfigSslCcsCertInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_ccs_query typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_CCS_QUERY { HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc; HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc; DWORD dwToken;
	// } HTTP_SERVICE_CONFIG_SSL_CCS_QUERY, *PHTTP_SERVICE_CONFIG_SSL_CCS_QUERY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_CCS_QUERY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_CCS_QUERY
	{
		/// <summary>
		/// <para>
		/// One of the following values from the HTTP_SERVICE_CONFIG_QUERY_TYPE enumeration that indicates whether the call to
		/// HttpQueryServiceConfiguration is a call to retrieve a single record or part of a sequence of calls to retrieve a sequence of records.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HttpServiceConfigQueryExact</c></term>
		/// <term>
		/// The call to HttpQueryServiceConfiguration is call to retrieve a single SSL CCS certificate record, which the <c>KeyDesc</c>
		/// member specifies.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HttpServiceConfigQueryNext</c></term>
		/// <term>
		/// The call to HttpQueryServiceConfiguration is part of a sequence of calls to retrieve a sequence of SSL CCS certificate records.
		/// The value of the <c>dwToken</c> member controls which record in the sequence that this call to
		/// <c>HttpQueryServiceConfiguration</c> retrieves.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

		/// <summary>
		/// An HTTP_SERVICE_CONFIG_SSL_CCS_KEY structure that identifies the SSL CCS certificate record queried, if the <c>QueryDesc</c>
		/// member is equal to <c>HttpServiceConfigQueryExact</c>. Ignored if <c>QueryDesc</c> is equal to <c>HTTPServiceConfigQueryNext</c>.
		/// </summary>
		public HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc;

		/// <summary>
		/// The position of the record in the sequence of records that this call to HttpQueryServiceConfiguration should retrieve if the
		/// <c>QueryDesc</c> method equals <c>HTTPServiceConfigQueryNext</c>, starting from zero. In other words, <c>dwToken</c> must be
		/// equal to zero on the first call to the <c>HttpQueryServiceConfiguration</c> function, one on the second call, two on the third
		/// call, and so forth. When the sequence of calls has returned all SSL certificate records, <c>HttpQueryServiceConfiguration</c>
		/// returns <c>ERROR_NO_MORE_ITEMS</c>. Ignored if the <c>QueryDesc</c> is equal to <c>HttpServiceConfigQueryExact</c>.
		/// </summary>
		public uint dwToken;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_CCS_QUERY_EX
	{
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
		public HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc;
		public uint dwToken;
		public HTTP_SSL_SERVICE_CONFIG_EX_PARAM_TYPE ParamType;
	}

	/// <summary>
	/// Represents the SSL certificate record that specifies that Http.sys should consult the Centralized Certificate Store (CCS) store to
	/// find certificates if the port receives a Transport Layer Security (TLS) handshake. Use this structure to add, delete, retrieve, or
	/// update that SSL certificate.
	/// </summary>
	/// <remarks>
	/// Pass this structure to the HttpSetServiceConfiguration or HttpDeleteServiceConfiguration function through the
	/// <c>pConfigInformation</c> parameter to add or remove an SSL certificate record. Pass this structure to the
	/// HttpUpdateServiceConfiguration function through the <c>ConfigInfo</c> parameter to update an SSL certificate record. Use the
	/// <c>pOutputConfigInfo</c> parameter of the HttpQueryServiceConfiguration function to retrieve SSL certificate record data in this
	/// structure. For all of these operations, set the <c>ConfigId</c> parameter of these functions to <c>HttpServiceConfigSslCcsCertInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_ccs_set typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_CCS_SET { HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc; HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc; }
	// HTTP_SERVICE_CONFIG_SSL_CCS_SET, *PHTTP_SERVICE_CONFIG_SSL_CCS_SET;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_CCS_SET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_CCS_SET
	{
		/// <summary>An HTTP_SERVICE_CONFIG_SSL_CCS_KEY structure that identifies the SSL CCS certificate record.</summary>
		public HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc;

		/// <summary>An HTTP_SERVICE_CONFIG_SSL_PARAM structure that holds the contents of the specified SSL CCS certificate record.</summary>
		public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_CCS_SET_EX
	{
		public HTTP_SERVICE_CONFIG_SSL_CCS_KEY KeyDesc;
		public HTTP_SERVICE_CONFIG_SSL_PARAM_EX ParamDesc;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_KEY</c> structure serves as the key by which a given Secure Sockets Layer (SSL) certificate record is
	/// identified. It appears in the HTTP_SERVICE_CONFIG_SSL_SET and the HTTP_SERVICE_CONFIG_SSL_QUERY structures, and is passed as the
	/// <c>pConfigInformation</c> parameter to HTTPDeleteServiceConfiguration, HttpQueryServiceConfiguration, and HttpSetServiceConfiguration
	/// when the <c>ConfigId</c> parameter is set to <c>HttpServiceConfigSSLCertInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_key typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_KEY { PSOCKADDR pIpPort; } HTTP_SERVICE_CONFIG_SSL_KEY, *PHTTP_SERVICE_CONFIG_SSL_KEY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_KEY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_KEY
	{
		/// <summary>
		/// <para>Pointer to a sockaddr structure that contains the Internet Protocol (IP) address with which this SSL certificate is associated.</para>
		/// <para>
		/// If the <c>sin_addr</c> field in <c>IpPort</c> is set to 0.0.0.0, the certificate is applicable to all IPv4 and IPv6 addresses. If
		/// the <c>sin6_addr</c> field in <c>IpPort</c> is set to [::], the certificate is applicable to all IPv6 addresses.
		/// </para>
		/// </summary>
		public IntPtr pIpPort;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_KEY_EX
	{
		public SOCKADDR_STORAGE IpPort;
	}

	/// <summary>The <c>HTTP_SERVICE_CONFIG_SSL_PARAM</c> structure defines a record in the SSL configuration store.</summary>
	/// <remarks>
	/// <para>
	/// Together with a HTTP_SERVICE_CONFIG_SSL_KEY structure, the <c>HTTP_SERVICE_CONFIG_SSL_PARAM</c> structure makes up the
	/// HTTP_SERVICE_CONFIG_SSL_SET structure passed to HttpSetServiceConfiguration function in the <c>pConfigInformation</c> parameter when
	/// the <c>ConfigId</c> parameter is set to <c>HttpServiceConfigSSLCertInfo</c>.
	/// </para>
	/// <para>
	/// Together with a HTTP_SERVICE_CONFIG_SSL_CCS_KEY structure, the <c>HTTP_SERVICE_CONFIG_SSL_PARAM</c> structure makes up the
	/// HTTP_SERVICE_CONFIG_SSL_CCS_SET structure passed to HttpSetServiceConfiguration function in the <c>pConfigInformation</c> parameter
	/// when the <c>ConfigId</c> parameter is set to <c>HttpServiceConfigSslCcsCertInfo</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_param typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_PARAM { ULONG SslHashLength; PVOID pSslHash; GUID AppId; PWSTR pSslCertStoreName; DWORD DefaultCertCheckMode;
	// DWORD DefaultRevocationFreshnessTime; DWORD DefaultRevocationUrlRetrievalTimeout; PWSTR pDefaultSslCtlIdentifier; PWSTR
	// pDefaultSslCtlStoreName; DWORD DefaultFlags; } HTTP_SERVICE_CONFIG_SSL_PARAM, *PHTTP_SERVICE_CONFIG_SSL_PARAM;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_PARAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_PARAM
	{
		/// <summary>The size, in bytes, of the SSL hash.</summary>
		public uint SslHashLength;

		/// <summary>A pointer to the SSL certificate hash.</summary>
		public IntPtr pSslHash;

		/// <summary>A unique identifier of the application setting this record.</summary>
		public Guid AppId;

		/// <summary>
		/// A pointer to a wide-character string that contains the name of the store from which the server certificate is to be read. If set
		/// to <c>NULL</c>, "MY" is assumed as the default name. The specified certificate store name must be present in the Local System
		/// store location.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pSslCertStoreName;

		/// <summary>
		/// <para>Determines how client certificates are checked. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>0</c></term>
		/// <term>Enables the client certificate revocation check.</term>
		/// </item>
		/// <item>
		/// <term><c>1</c></term>
		/// <term>Client certificate is not to be verified for revocation.</term>
		/// </item>
		/// <item>
		/// <term><c>2</c></term>
		/// <term>Only cached certificate revocation is to be used.</term>
		/// </item>
		/// <item>
		/// <term><c>4</c></term>
		/// <term>The <c>DefaultRevocationFreshnessTime</c> setting is enabled.</term>
		/// </item>
		/// <item>
		/// <term><c>0x10000</c></term>
		/// <term>No usage check is to be performed.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint DefaultCertCheckMode;

		/// <summary>
		/// The number of seconds after which to check for an updated certificate revocation list (CRL). If this value is zero, the new CRL
		/// is updated only when the previous one expires.
		/// </summary>
		public uint DefaultRevocationFreshnessTime;

		/// <summary>The timeout interval, in milliseconds, for an attempt to retrieve a certificate revocation list from the remote URL.</summary>
		public uint DefaultRevocationUrlRetrievalTimeout;

		/// <summary>
		/// A pointer to an SSL control identifier, which enables an application to restrict the group of certificate issuers to be trusted.
		/// This group must be a subset of the certificate issuers trusted by the machine on which the application is running.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pDefaultSslCtlIdentifier;

		/// <summary>The name of the store where the control identifier pointed to by <c>pDefaultSslCtlIdentifier</c> is stored.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pDefaultSslCtlStoreName;

		/// <summary>
		/// <para>A combination of zero or more of the following flag values can be combined with OR as appropriate.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flags</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_SERVICE_CONFIG_SSL_FLAG_NEGOTIATE_CLIENT_CERT</c></term>
		/// <term>Enables a client certificate to be cached locally for subsequent use.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_SERVICE_CONFIG_SSL_FLAG_NO_RAW_FILTER</c></term>
		/// <term>Prevents SSL requests from being passed to low-level ISAPI filters.</term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_SERVICE_CONFIG_SSL_FLAG_USE_DS_MAPPER</c></term>
		/// <term>
		/// Client certificates are mapped where possible to corresponding operating-system user accounts based on the certificate mapping
		/// rules stored in Active Directory. If this flag is set and the mapping is successful, the <c>Token</c> member of the
		/// HTTP_SSL_CLIENT_CERT_INFO structure is a handle to an access token. Release this token explicitly by closing the handle when the
		/// <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure is no longer required.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_SERVICE_CONFIG_SSL_FLAG DefaultFlags;
	}

	/// <summary>This defines the extended params for the ssl config record.</summary>
	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_PARAM_EX
	{
		/// <summary>The id that decides which param property is passed below.</summary>
		public HTTP_SSL_SERVICE_CONFIG_EX_PARAM_TYPE ParamType;

		/// <summary>Flags for future use, if any.</summary>
		public ulong Flags;

		/// <summary>The property.</summary>
		public UNION union;

		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			[FieldOffset(0)]
			public HTTP2_WINDOW_SIZE_PARAM Http2WindowSizeParam;

			[FieldOffset(0)]
			public HTTP2_SETTINGS_LIMITS_PARAM Http2SettingsLimitsParam;

			[FieldOffset(0)]
			public HTTP_PERFORMANCE_PARAM HttpPerformanceParam;

			[FieldOffset(0)]
			public HTTP_TLS_RESTRICTIONS_PARAM HttpTlsRestrictionsParam;

			[FieldOffset(0)]
			public HTTP_ERROR_HEADERS_PARAM HttpErrorHeadersParam;

			[FieldOffset(0)]
			public HTTP_TLS_SESSION_TICKET_KEYS_PARAM HttpTlsSessionTicketKeysParam;
		}
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_QUERY</c> structure is used to specify a particular record to query in the SSL configuration store. It
	/// is passed to the HttpQueryServiceConfiguration function using the <c>pInputConfigInfo</c> parameter when the <c>ConfigId</c>
	/// parameter is set to <c>HttpServiceConfigSSLCertInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_query typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_QUERY { HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc; HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc; DWORD dwToken; }
	// HTTP_SERVICE_CONFIG_SSL_QUERY, *PHTTP_SERVICE_CONFIG_SSL_QUERY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_QUERY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_QUERY
	{
		/// <summary>
		/// <para>One of the following values from the HTTP_SERVICE_CONFIG_QUERY_TYPE enumeration.</para>
		/// <para>HttpServiceConfigQueryExact</para>
		/// <para>Returns a single SSL record.</para>
		/// <para>HttpServiceConfigQueryNext</para>
		/// <para>Returns a sequence of SSL records in a sequence of calls, as controlled by the <c>dwToken</c> parameter.</para>
		/// </summary>
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

		/// <summary>
		/// If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryExact</c>, then <c>KeyDesc</c> should contain an
		/// HTTP_SERVICE_CONFIG_SSL_KEY structure that identifies the SSL certificate record queried. If the <c>QueryDesc</c> parameter is
		/// equal to HTTPServiceConfigQueryNext, then <c>KeyDesc</c> is ignored.
		/// </summary>
		public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;

		/// <summary>
		/// <para>
		/// If the <c>QueryDesc</c> parameter is equal to <c>HTTPServiceConfigQueryNext</c>, then <c>dwToken</c> must be equal to zero on the
		/// first call to the HttpQueryServiceConfiguration function, one on the second call, two on the third call, and so forth until all
		/// SSL certificate records are returned, at which point <c>HttpQueryServiceConfiguration</c> returns ERROR_NO_MORE_ITEMS.
		/// </para>
		/// <para>If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryExact</c>, then <c>dwToken</c> is ignored.</para>
		/// </summary>
		public uint dwToken;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_QUERY_EX
	{
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
		public HTTP_SERVICE_CONFIG_SSL_KEY_EX KeyDesc;
		public uint dwToken;
		public HTTP_SSL_SERVICE_CONFIG_EX_PARAM_TYPE ParamType;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_SET</c> structure is used to add a new record to the SSL store or retrieve an existing record from it.
	/// An instance of the structure is used to pass data in to the HTTPSetServiceConfiguration function through the
	/// <c>pConfigInformation</c> parameter or to retrieve data from the HTTPQueryServiceConfiguration function through the
	/// <c>pOutputConfigInformation</c> parameter when the <c>ConfigId</c> parameter of either function is equal to <c>HTTPServiceConfigSSLCertInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_set typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_SET { HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc; HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc; }
	// HTTP_SERVICE_CONFIG_SSL_SET, *PHTTP_SERVICE_CONFIG_SSL_SET;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_SET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SET
	{
		/// <summary>An HTTP_SERVICE_CONFIG_SSL_KEY structure that identifies the SSL certificate record.</summary>
		public HTTP_SERVICE_CONFIG_SSL_KEY KeyDesc;

		/// <summary>An HTTP_SERVICE_CONFIG_SSL_PARAM structure that holds the contents of the specified SSL certificate record.</summary>
		public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SET_EX
	{
		public HTTP_SERVICE_CONFIG_SSL_KEY_EX KeyDesc;
		public HTTP_SERVICE_CONFIG_SSL_PARAM_EX ParamDesc;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_SNI_KEY</c> structure serves as the key by which a given Secure Sockets Layer (SSL) Server Name
	/// Indication (SNI) certificate record is identified in the SSL SNI store. It appears in the HTTP_SERVICE_CONFIG_SSL_SNI_SET and the
	/// HTTP_SERVICE_CONFIG_SSL_SNI_QUERY structures, and is passed as the <c>pConfigInformation</c> parameter to
	/// HttpDeleteServiceConfiguration, HttpQueryServiceConfiguration, and HttpSetServiceConfiguration when the <c>ConfigId</c> parameter is
	/// set to <c>HttpServiceConfigSslSniCertInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_sni_key typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_SNI_KEY { SOCKADDR_STORAGE IpPort; PWSTR Host; } HTTP_SERVICE_CONFIG_SSL_SNI_KEY, *PHTTP_SERVICE_CONFIG_SSL_SNI_KEY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_SNI_KEY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SNI_KEY
	{
		/// <summary>
		/// A SOCKADDR_STORAGE structure that contains the Internet Protocol version 4 (IPv4) address with which this SSL SNI certificate is
		/// associated. It must be set to the IPv4 wildcard address of type <c>SOCKADDR_IN</c> with <c>ss_family</c> set to <c>AF_INET</c>
		/// and <c>sin_addr</c> filled with zeros. <c>Port</c> can be any valid port.
		/// </summary>
		public SOCKADDR_STORAGE IpPort;

		/// <summary>A pointer to a null-terminated Unicode UTF-16 string that represents the hostname.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Host;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_SNI_QUERY</c> structure is used to specify a particular Secure Sockets Layer (SSL) Server Name
	/// Indication (SNI) certificate record to query in the SSL SNI store. It is passed to the HttpQueryServiceConfiguration function using
	/// the <c>pInputConfigInfo</c> parameter when the <c>ConfigId</c> parameter is set to <c>HttpServiceConfigSslSniCertInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_sni_query typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_SNI_QUERY { HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc; HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc; DWORD dwToken;
	// } HTTP_SERVICE_CONFIG_SSL_SNI_QUERY, *PHTTP_SERVICE_CONFIG_SSL_SNI_QUERY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_SNI_QUERY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SNI_QUERY
	{
		/// <summary>
		/// <para>One of the following values from the HTTP_SERVICE_CONFIG_QUERY_TYPE enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HttpServiceConfigQueryExact</c></term>
		/// <term>Returns a single SSL SNI certificate record.</term>
		/// </item>
		/// <item>
		/// <term><c>HttpServiceConfigQueryNext</c></term>
		/// <term>Returns a sequence of SSL SNI certificate records in a sequence of calls, as controlled by <c>dwToken</c>.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

		/// <summary>
		/// If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryExact</c>, then <c>KeyDesc</c> should contain an
		/// HTTP_SERVICE_CONFIG_SSL_SNI_KEY structure that identifies the SSL SNI certificate record queried. If the <c>QueryDesc</c>
		/// parameter is equal to <c>HTTPServiceConfigQueryNext</c>, then <c>KeyDesc</c> is ignored.
		/// </summary>
		public HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc;

		/// <summary>
		/// <para>
		/// If the <c>QueryDesc</c> parameter is equal to <c>HTTPServiceConfigQueryNext</c>, then <c>dwToken</c> must be equal to zero on the
		/// first call to the HttpQueryServiceConfiguration function, one on the second call, two on the third call, and so forth until all
		/// SSL certificate records are returned, at which point <c>HttpQueryServiceConfiguration</c> returns ERROR_NO_MORE_ITEMS.
		/// </para>
		/// <para>If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryExact</c>, then <c>dwToken</c> is ignored.</para>
		/// </summary>
		public uint dwToken;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SNI_QUERY_EX
	{
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;
		public HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc;
		public uint dwToken;
		public HTTP_SSL_SERVICE_CONFIG_EX_PARAM_TYPE ParamType;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_SSL_SNI_SET</c> structure is used to add a new Secure Sockets Layer (SSL) Server Name Indication (SNI)
	/// certificate record to the SSL SNI store or retrieve an existing record from it. It is passed to the HttpSetServiceConfiguration
	/// function through the <c>pConfigInformation</c> parameter or to retrieve data from the HttpQueryServiceConfiguration function through
	/// the <c>pOutputConfigInformation</c> parameter when the <c>ConfigId</c> parameter of either function is set to <c>HttpServiceConfigSslSniCertInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_sni_set typedef struct
	// _HTTP_SERVICE_CONFIG_SSL_SNI_SET { HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc; HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc; }
	// HTTP_SERVICE_CONFIG_SSL_SNI_SET, *PHTTP_SERVICE_CONFIG_SSL_SNI_SET;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_SSL_SNI_SET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SNI_SET
	{
		/// <summary>An HTTP_SERVICE_CONFIG_SSL_SNI_KEY structure that identifies the SSL SNI certificate record.</summary>
		public HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc;

		/// <summary>An HTTP_SERVICE_CONFIG_SSL_PARAM structure that holds the contents of the specified SSL SNI certificate record.</summary>
		public HTTP_SERVICE_CONFIG_SSL_PARAM ParamDesc;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_SSL_SNI_SET_EX
	{
		public HTTP_SERVICE_CONFIG_SSL_SNI_KEY KeyDesc;
		public HTTP_SERVICE_CONFIG_SSL_PARAM_EX ParamDesc;
	}

	/// <summary>The <c>HTTP_SERVICE_CONFIG_TIMEOUT_SET</c> structure is used to set the HTTP Server API wide timeout value.</summary>
	/// <remarks>
	/// <para>
	/// An instance of the <c>HTTP_SERVICE_CONFIG_TIMEOUT_SET</c> structure is used to pass data in to the HTTPSetServiceConfiguration
	/// function through the <c>pConfigInformation</c> parameter or to retrieve data from the HTTPQueryServiceConfiguration function through
	/// the <c>pOutputConfigInformation</c> parameter when the <c>ConfigId</c> parameter of either function is equal to <c>HttpServiceConfigTimeout</c>.
	/// </para>
	/// <para>
	/// Querying the existing value of an HTTP Server API wide timeout does not require administrative privileges. Setting the value,
	/// however, does require administrative privileges.
	/// </para>
	/// <para>
	/// When the HTTP Server API wide timeout value is set with HTTPSetServiceConfiguration, the setting persists when the HTTP service is
	/// stopped and restarted. The timeout value is applied to all the HTTP Server API applications on the machine.
	/// </para>
	/// <para>
	/// The HTTP Server API timeout value is deleted by calling HTTPDeleteServiceConfiguration with the <c>ConfigId</c> parameter set to
	/// <c>HttpServiceConfigTimeout</c> and the <c>pConfigInformation</c> parameter pointing to the <c>HTTP_SERVICE_CONFIG_TIMEOUT_SET</c>
	/// structure. When a timer value is deleted, the persistent setting goes away, and HTTP Server API uses its hardcoded defaults.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_timeout_set typedef struct
	// _HTTP_SERVICE_CONFIG_TIMEOUT_SET { HTTP_SERVICE_CONFIG_TIMEOUT_KEY KeyDesc; HTTP_SERVICE_CONFIG_TIMEOUT_PARAM ParamDesc; }
	// HTTP_SERVICE_CONFIG_TIMEOUT_SET, *PHTTP_SERVICE_CONFIG_TIMEOUT_SET;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_TIMEOUT_SET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_TIMEOUT_SET
	{
		/// <summary>A member of the HTTP_SERVICE_CONFIG_TIMEOUT_KEY enumeration identifying the timer that is set.</summary>
		public HTTP_SERVICE_CONFIG_TIMEOUT_KEY KeyDesc;

		/// <summary>The value, in seconds, for the timer. The value must be greater than zero.</summary>
		public ushort ParamDesc;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_URLACL_KEY</c> structure is used to specify a particular reservation record in the URL namespace
	/// reservation store. It is a member of the HTTP_SERVICE_CONFIG_URLACL_SET and HTTP_SERVICE_CONFIG_URLACL_QUERY structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_key typedef struct
	// _HTTP_SERVICE_CONFIG_URLACL_KEY { PWSTR pUrlPrefix; } HTTP_SERVICE_CONFIG_URLACL_KEY, *PHTTP_SERVICE_CONFIG_URLACL_KEY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_URLACL_KEY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_URLACL_KEY
	{
		/// <summary>A pointer to the UrlPrefix string that defines the portion of the URL namespace to which this reservation pertains.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pUrlPrefix;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_URLACL_PARAM</c> structure is used to specify the permissions associated with a particular record in the
	/// URL namespace reservation store. It is a member of the HTTP_SERVICE_CONFIG_URLACL_SET structure.
	/// </summary>
	/// <remarks>
	/// <para>The security descriptor string pointed to by the <c>pStringSecurityDescriptor</c> member has the following elements:</para>
	/// <para>An example of a security descriptor string is:</para>
	/// <para>
	/// <code>D:(A;;GX;;;S-1-0-0)(A;;GA;;;S-1-5-11)</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_param typedef struct
	// _HTTP_SERVICE_CONFIG_URLACL_PARAM { PWSTR pStringSecurityDescriptor; } HTTP_SERVICE_CONFIG_URLACL_PARAM, *PHTTP_SERVICE_CONFIG_URLACL_PARAM;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_URLACL_PARAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_URLACL_PARAM
	{
		/// <summary>
		/// A pointer to a Security Descriptor Definition Language (SDDL) string that contains the permissions associated with this URL
		/// namespace reservation record.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pStringSecurityDescriptor;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_URLACL_QUERY</c> structure is used to specify a particular reservation record to query in the URL
	/// namespace reservation store. It is passed to the HttpQueryServiceConfiguration function using the <c>pInputConfigInfo</c> parameter
	/// when the <c>ConfigId</c> parameter is equal to <c>HttpServiceConfigUrlAclInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_query typedef struct
	// _HTTP_SERVICE_CONFIG_URLACL_QUERY { HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc; HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc; DWORD dwToken; }
	// HTTP_SERVICE_CONFIG_URLACL_QUERY, *PHTTP_SERVICE_CONFIG_URLACL_QUERY;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_URLACL_QUERY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_URLACL_QUERY
	{
		/// <summary>
		/// <para>One of the following values from the HTTP_SERVICE_CONFIG_QUERY_TYPE enumeration.</para>
		/// <para>HttpServiceConfigQueryExact</para>
		/// <para>Returns a single record.</para>
		/// <para>HttpServiceConfigQueryNext</para>
		/// <para>Returns a sequence of records in a sequence of calls, controlled by the <c>dwToken</c> parameter.</para>
		/// </summary>
		public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

		/// <summary>
		/// <para>
		/// If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryExact</c>, then <c>KeyDesc</c> should contain an
		/// HTTP_SERVICE_CONFIG_URLACL_KEY structure that identifies the reservation record queried.
		/// </para>
		/// <para>If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryNext</c>, <c>KeyDesc</c> is ignored.</para>
		/// </summary>
		public HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;

		/// <summary>
		/// <para>
		/// If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryNext</c>, then <c>dwToken</c> must be equal to zero on the
		/// first call to the HttpQueryServiceConfiguration function, one on the second call, two on the third call, and so forth until all
		/// reservation records are returned, at which point <c>HttpQueryServiceConfiguration</c> returns ERROR_NO_MORE_ITEMS.
		/// </para>
		/// <para>If the <c>QueryDesc</c> parameter is equal to <c>HttpServiceConfigQueryExact</c>, then <c>dwToken</c> is ignored.</para>
		/// </summary>
		public uint dwToken;
	}

	/// <summary>
	/// The <c>HTTP_SERVICE_CONFIG_URLACL_SET</c> structure is used to add a new record to the URL reservation store or retrieve an existing
	/// record from it. An instance of the structure is used to pass data in through the <c>pConfigInformation</c> parameter of the
	/// HTTPSetServiceConfiguration function, or to retrieve data through the <c>pOutputConfigInformation</c> parameter of the
	/// HTTPQueryServiceConfiguration function when the <c>ConfigId</c> parameter of either function is equal to <c>HTTPServiceConfigUrlAclInfo</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_set typedef struct
	// _HTTP_SERVICE_CONFIG_URLACL_SET { HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc; HTTP_SERVICE_CONFIG_URLACL_PARAM ParamDesc; }
	// HTTP_SERVICE_CONFIG_URLACL_SET, *PHTTP_SERVICE_CONFIG_URLACL_SET;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SERVICE_CONFIG_URLACL_SET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SERVICE_CONFIG_URLACL_SET
	{
		/// <summary>An HTTP_SERVICE_CONFIG_URLACL_KEY structure that identifies the URL reservation record.</summary>
		public HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;

		/// <summary>An HTTP_SERVICE_CONFIG_URLACL_PARAM structure that holds the contents of the specified URL reservation record.</summary>
		public HTTP_SERVICE_CONFIG_URLACL_PARAM ParamDesc;
	}

	/// <summary>
	/// The <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure contains data about a Secure Sockets Layer (SSL) client certificate that can be used
	/// to determine whether the certificate is valid.
	/// </summary>
	/// <remarks>
	/// An <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure is pointed to by the <c>pClientCertInfo</c> member of the HTTP_SSL_INFO structure, and
	/// is used by the HttpReceiveClientCertificate function to return data about the client certificate through the
	/// <c>pSslClientCertInfo</c> parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_ssl_client_cert_info typedef struct _HTTP_SSL_CLIENT_CERT_INFO {
	// ULONG CertFlags; ULONG CertEncodedSize; PUCHAR pCertEncoded; HANDLE Token; BOOLEAN CertDeniedByMapper; } HTTP_SSL_CLIENT_CERT_INFO, *PHTTP_SSL_CLIENT_CERT_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SSL_CLIENT_CERT_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SSL_CLIENT_CERT_INFO
	{
		/// <summary>
		/// <para>
		/// Flags that indicate whether the certificate is valid. The possible values for this member are a SSPI Status Code returned from
		/// SSPI or one of the following flags from the <c>dwError</c> member of the CERT_CHAIN_POLICY_STATUS structure:
		/// </para>
		/// <para>CERT_E_EXPIRED</para>
		/// <para>CERT_E_UNTRUSTEDCA</para>
		/// <para>CERT_E_WRONG_USAGE</para>
		/// <para>CERT_E_UNTRUSTEDROOT</para>
		/// <para>CERT_E_REVOKED</para>
		/// <para>CERT_E_CN_NO_MATCH</para>
		/// </summary>
		public HRESULT CertFlags;

		/// <summary>The size, in bytes, of the certificate.</summary>
		public uint CertEncodedSize;

		/// <summary>A pointer to the actual certificate.</summary>
		public IntPtr pCertEncoded;

		/// <summary>
		/// A handle to an access token. If the HTTP_SERVICE_CONFIG_SSL_FLAG_USE_DS_MAPPER flag is set using the HttpSetServiceConfiguration
		/// function, and the client certificate was successfully mapped to an operating-system user account, then this member contains the
		/// handle to a valid access token. When the <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure is no longer required, release this token
		/// explicitly by closing the handle.
		/// </summary>
		public HTOKEN Token;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool CertDeniedByMapper;

		/// <summary>The actual certificate.</summary>
		public byte[] CertEncoded => pCertEncoded.ToByteArray((int)CertEncodedSize) ?? new byte[0];
	}

	/// <summary>
	/// The <c>HTTP_SSL_INFO</c> structure contains data for a connection that uses Secure Sockets Layer (SSL), obtained through the SSL handshake.
	/// </summary>
	/// <remarks>An <c>HTTP_SSL_INFO</c> structure can be pointed to by the <c>pSslInfo</c> member of an HTTP_REQUEST structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_ssl_info typedef struct _HTTP_SSL_INFO { USHORT
	// ServerCertKeySize; USHORT ConnectionKeySize; ULONG ServerCertIssuerSize; ULONG ServerCertSubjectSize; PCSTR pServerCertIssuer; PCSTR
	// pServerCertSubject; PHTTP_SSL_CLIENT_CERT_INFO pClientCertInfo; ULONG SslClientCertNegotiated; } HTTP_SSL_INFO, *PHTTP_SSL_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_SSL_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SSL_INFO
	{
		/// <summary>The size, in bytes, of the public key used to sign the server certificate.</summary>
		public ushort ServerCertKeySize;

		/// <summary>The size, in bytes, of the cipher key used to encrypt the current session.</summary>
		public ushort ConnectionKeySize;

		/// <summary>
		/// The size, in bytes, of the string pointed to by the <c>pServerCertIssuer</c> member not including the terminating null character.
		/// </summary>
		public uint ServerCertIssuerSize;

		/// <summary>
		/// The size, in bytes, of the string pointed to by the <c>pServerCertSubject</c> member not including the terminating null character.
		/// </summary>
		public uint ServerCertSubjectSize;

		/// <summary>A pointer to a null-terminated string of octets that specifies the name of the entity that issued the certificate.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pServerCertIssuer;

		/// <summary>A pointer to a null-terminated string of octets that specifies the name of the entity to which the certificate belongs.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pServerCertSubject;

		/// <summary>A pointer to an <see cref="HTTP_SSL_CLIENT_CERT_INFO"/> structure that specifies the client certificate.</summary>
		public IntPtr pClientCertInfo;

		/// <summary>If non-zero, indicates that the client certificate is already present locally.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool SslClientCertNegotiated;

		/// <summary>A <see cref="HTTP_SSL_CLIENT_CERT_INFO"/> structure that specifies the client certificate.</summary>
		public HTTP_SSL_CLIENT_CERT_INFO? ClientCertInfo => pClientCertInfo.ToNullableStructure<HTTP_SSL_CLIENT_CERT_INFO>();
	}

	/// <summary>
	/// HttpRequestInfoTypeSslProtocol payload. Contains basic information about the SSL/TLS protocol and cipher. See
	/// SecPkgContext_ConnectionInfo documentation for details. This information is meant for statistics. Do not use this for security
	/// enforcement because by the time you check this the client may already have transmitted the information being protected (e.g. HTTP
	/// request headers).
	/// </summary>
	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_SSL_PROTOCOL_INFO
	{
		public uint Protocol;
		public uint CipherType;
		public uint CipherStrength;
		public uint HashType;
		public uint HashStrength;
		public uint KeyExchangeType;
		public uint KeyExchangeStrength;
	}

	/// <summary>
	/// <para>The <c>HTTP_STATE_INFO</c> structure is used to enable or disable a Server Session or URL Group.</para>
	/// <para>This structure must be used when setting or querying the HttpServerStateProperty on a URL Group or Server Session.</para>
	/// </summary>
	/// <remarks>
	/// When the <c>HttpServerStateProperty</c> is set on a server session or a URL group, the <c>HTTP_STATE_INFO</c> structure must be used.
	/// Server Sessions, and URL Groups represent a configuration for a part of the namespace where inheritance is involved. When traversing
	/// the namespace for a request, the HTTP Server API may encounter multiple applicable URL Groups. The property configuration structures
	/// must carry information identifying if it is present in a specific URL group.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_state_info typedef struct _HTTP_STATE_INFO { HTTP_PROPERTY_FLAGS
	// Flags; HTTP_ENABLED_STATE State; } HTTP_STATE_INFO, *PHTTP_STATE_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_STATE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_STATE_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure specifying whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// <para>A member of the HTTP_ENABLED_STATE enumeration specifying the whether the configuration object is enabled or disabled.</para>
		/// <para>This can be used to disable a URL Group or Server Session.</para>
		/// </summary>
		public HTTP_ENABLED_STATE State;
	}

	/// <summary>
	/// <para>The <c>HTTP_TIMEOUT_LIMIT_INFO</c> structure defines the application-specific connection timeout limits.</para>
	/// <para>
	/// This structure must be used when setting or querying the HttpServerTimeoutsProperty on a URL Group, server session, or request queue.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is used in the HttpQueryServerSessionProperty, and HttpSetServerSessionProperty functions to set or query the
	/// connection timeouts. The following table lists the default timeouts.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Timer</term>
	/// <term>HTTP Server API Default</term>
	/// <term>HTTP Server API Wide Configuration</term>
	/// <term>Application Specific Configuration</term>
	/// </listheader>
	/// <item>
	/// <term>EntityBody</term>
	/// <term>2 Minutes</term>
	/// <term>No</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>DrainEntityBody</term>
	/// <term>2 Minutes</term>
	/// <term>No</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>RequestQueue</term>
	/// <term>2 Minutes</term>
	/// <term>No</term>
	/// <term>Yes</term>
	/// </item>
	/// <item>
	/// <term>IdleConnection</term>
	/// <term>2 Minutes</term>
	/// <term>Yes</term>
	/// <term>Limited</term>
	/// </item>
	/// <item>
	/// <term>HeaderWait</term>
	/// <term>2 Minutes</term>
	/// <term>Yes</term>
	/// <term>Limited</term>
	/// </item>
	/// <item>
	/// <term>MinSendRate</term>
	/// <term>150 bytes/second</term>
	/// <term>No</term>
	/// <term>Yes</term>
	/// </item>
	/// </list>
	/// <para>
	/// Calling HttpSetServerSessionProperty or HttpSetUrlGroupProperty to configure a connection timeout affects only the calling
	/// application and does not set driver wide timeout limits. The idle connection and header wait timers can be configured for all HTTP
	/// applications by calling HttpSetServiceConfiguration. Administrative privileges are required to configure HTTP Server API wide
	/// timeouts. HTTP Server API wide configurations affect all HTTP applications on the computer and persist when the computer is shut down.
	/// </para>
	/// <para>
	/// The application-specific <c>IdleConnection</c> and <c>HeaderWait</c> timers are set on a limited basis. The HTTP Server API cannot
	/// determine the request queue or URL group that the request is associated with until the headers have been parsed. Therefore, the HTTP
	/// Server API enforces the default <c>IdleConnection</c> and <c>HeaderWait</c> timers for the first request on a connection. Subsequent
	/// requests on a Keep-Alive connection will use the application specific timeouts.
	/// </para>
	/// <para>
	/// Setting a timeout on a server session affects all the URL Groups under the server session. However, if the URL Group has configured a
	/// timeout, the setting for the URL Group takes precedence over the server session configuration.
	/// </para>
	/// <para>
	/// Setting a timeout to zero on a server session causes the HTTP Server API to revert to the default value for that timer. For timers
	/// set on a URL Group, the server session timeout is used if present, otherwise the HTTP Server API default is used.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_timeout_limit_info typedef struct _HTTP_TIMEOUT_LIMIT_INFO {
	// HTTP_PROPERTY_FLAGS Flags; USHORT EntityBody; USHORT DrainEntityBody; USHORT RequestQueue; USHORT IdleConnection; USHORT HeaderWait;
	// ULONG MinSendRate; } HTTP_TIMEOUT_LIMIT_INFO, *PHTTP_TIMEOUT_LIMIT_INFO;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_TIMEOUT_LIMIT_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_TIMEOUT_LIMIT_INFO
	{
		/// <summary>The HTTP_PROPERTY_FLAGS structure that specifies whether the property is present.</summary>
		public HTTP_PROPERTY_FLAGS Flags;

		/// <summary>
		/// <para>The time, in seconds, allowed for the request entity body to arrive.</para>
		/// <para>
		/// The HTTP Server API turns on this timer when the request has an entity body. The timer expiration is initially set to the
		/// configured value. When the HTTP Server API receives additional data indications on the request, it resets the timer to give the
		/// connection another interval.
		/// </para>
		/// </summary>
		public ushort EntityBody;

		/// <summary>
		/// <para>The time, in seconds, allowed for the HTTP Server API to drain the entity body on a Keep-Alive connection.</para>
		/// <para>
		/// On a Keep-Alive connection, after the application has sent a response for a request and before the request entity body has
		/// completely arrived, the HTTP Server API starts draining the remainder of the entity body to reach another potentially pipelined
		/// request from the client. If the time to drain the remaining entity body exceeds the allowed period the connection is timed out.
		/// </para>
		/// </summary>
		public ushort DrainEntityBody;

		/// <summary>The time, in seconds, allowed for the request to remain in the request queue before the application picks it up.</summary>
		public ushort RequestQueue;

		/// <summary>
		/// <para>The time, in seconds, allowed for an idle connection.</para>
		/// <para>
		/// This timeout is only enforced after the first request on the connection is routed to the application. For more information, see
		/// the Remarks section.
		/// </para>
		/// </summary>
		public ushort IdleConnection;

		/// <summary>
		/// <para>The time, in seconds, allowed for the HTTP Server API to parse the request header.</para>
		/// <para>
		/// This timeout is only enforced after the first request on the connection is routed to the application. For more information, see
		/// the Remarks section.
		/// </para>
		/// </summary>
		public ushort HeaderWait;

		/// <summary>
		/// <para>The minimum send rate, in bytes-per-second, for the response. The default response send rate is 150 bytes-per-second.</para>
		/// <para>To disable this timer, set <c>MinSendRate</c> to <c>MAXULONG</c>.</para>
		/// </summary>
		public uint MinSendRate;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_TLS_RESTRICTIONS_PARAM
	{
		public uint RestrictionCount;
		public IntPtr TlsRestrictions;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_TLS_SESSION_TICKET_KEYS_PARAM
	{
		public uint SessionTicketKeyCount;
		public IntPtr SessionTicketKeys;
	}

	/// <summary>The <c>HTTP_TRANSPORT_ADDRESS</c> structure specifies the addresses (local and remote) used for a particular HTTP connection.</summary>
	/// <remarks>
	/// Although the <c>pRemoteAddress</c> and <c>pLocalAddress</c> members are formally declared as <c>PSOCKADDR</c>, they are in fact
	/// <c>PSOCKADDR_IN</c> or <c>PSOCKADDR_IN6</c> types. Inspect the <c>sa_family</c> member, which is the same in all three structures, to
	/// determine how to access the address. If <c>sa_family</c> is equal to AF_INET, then the address is in IPv4 form and can be accessed by
	/// casting the members to <c>PSOCKADDR_IN</c>, but if <c>sa_family</c> equals AF_INET6, the address is in IPv6 form and you must cast
	/// them to <c>PSOCKADDR_IN6</c> before accessing the address. Both <c>pLocalAddress</c> and <c>pRemoteAddress</c> are always of the same
	/// type; that is they are either both of type <c>PSOCKADDR_IN</c> or both of type <c>PSOCKADDR_IN6</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_transport_address typedef struct _HTTP_TRANSPORT_ADDRESS {
	// PSOCKADDR pRemoteAddress; PSOCKADDR pLocalAddress; } HTTP_TRANSPORT_ADDRESS, *PHTTP_TRANSPORT_ADDRESS;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_TRANSPORT_ADDRESS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_TRANSPORT_ADDRESS
	{
		/// <summary>
		/// A pointer to the remote IP address associated with this connection. For more information about how to access this address, see
		/// the Remarks section.
		/// </summary>
		private IntPtr pRemoteAddress;

		/// <summary>
		/// A pointer to the local IP address associated with this connection. For more information about how to access this address, see the
		/// Remarks section.
		/// </summary>
		private IntPtr pLocalAddress;

		/// <summary>The remote IP address associated with this connection.</summary>
		public SOCKADDR_STORAGE RemoteAddress => (SOCKADDR_STORAGE)new SOCKADDR(pRemoteAddress);

		/// <summary>The local IP address associated with this connection.</summary>
		public SOCKADDR_STORAGE LocalAddress => (SOCKADDR_STORAGE)new SOCKADDR(pLocalAddress);
	}

	/// <summary>
	/// The <c>HTTP_UNKNOWN_HEADER</c> structure contains the name and value for a header in an HTTP request or response whose name does not
	/// appear in the enumeration.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_unknown_header typedef struct _HTTP_UNKNOWN_HEADER { USHORT
	// NameLength; USHORT RawValueLength; PCSTR pName; PCSTR pRawValue; } HTTP_UNKNOWN_HEADER, *PHTTP_UNKNOWN_HEADER;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_UNKNOWN_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_UNKNOWN_HEADER
	{
		/// <summary>The size, in bytes, of the data pointed to by the <c>pName</c> member not counting a terminating null.</summary>
		public ushort NameLength;

		/// <summary>The size, in bytes, of the data pointed to by the <c>pRawValue</c> member, in bytes.</summary>
		public ushort RawValueLength;

		/// <summary>
		/// A pointer to a string of octets that specifies the header name. Use <c>NameLength</c> to determine the end of the string, rather
		/// than relying on a terminating <c>null</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pName;

		/// <summary>
		/// A pointer to a string of octets that specifies the values for this header. Use <c>RawValueLength</c> to determine the end of the
		/// string, rather than relying on a terminating <c>null</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pRawValue;
	}

	/// <summary>
	/// The <c>HTTP_VERSION</c> structure defines a version of the HTTP protocol that a request requires or a response provides. This is not
	/// to be confused with the version of the HTTP Server API used, which is stored in an HTTPAPI_VERSION structure.
	/// </summary>
	/// <remarks>
	/// <para>For more information about the HTTP protocol, see RFC 2616.</para>
	/// <para>
	/// The following macros define various versions of the HTTP protocol:"#define HTTP_VERSION_UNKNOWN { 0, 0 }""#define HTTP_VERSION_0_9 {
	/// 0, 9 }""#define HTTP_VERSION_1_0 { 1, 0 }""#define HTTP_VERSION_1_1 { 1, 1 }"
	/// </para>
	/// <para>
	/// The HTTP Server API provides a number of macros that can be used to evaluate the value of an HTTP_VERSION structure; For more
	/// information, see HTTP Server API Version 1.0 Macros.
	/// </para>
	/// <para>
	/// <c>Note</c> The HTTP Server API rejects a version of HTTP larger than 65,535 in either the major or minor portion. If a request
	/// includes such a version number, the HTTP Server API discards it and returns a response with status 400 ("Bad Request").
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-http_version typedef struct _HTTP_VERSION { USHORT MajorVersion;
	// USHORT MinorVersion; } HTTP_VERSION, *PHTTP_VERSION;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTP_VERSION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_VERSION : IEquatable<HTTP_VERSION>
	{
		/// <summary>Major version of the HTTP protocol.</summary>
		public ushort MajorVersion;

		/// <summary>Minor version of the HTTP protocol.</summary>
		public ushort MinorVersion;

		/// <summary>A constant for the Unknown HTTP Version.</summary>
		public static readonly HTTP_VERSION HTTP_VERSION_UNKNOWN = new();

		/// <summary>A constant for the HTTP Version 0.9.</summary>
		public static readonly HTTP_VERSION HTTP_VERSION_0_9 = new() { MinorVersion = 9 };

		/// <summary>A constant for the HTTP Version 1.0.</summary>
		public static readonly HTTP_VERSION HTTP_VERSION_1_0 = new() { MajorVersion = 1 };

		/// <summary>A constant for the HTTP Version 1.1.</summary>
		public static readonly HTTP_VERSION HTTP_VERSION_1_1 = new() { MajorVersion = 1, MinorVersion = 1 };

		/// <summary>A constant for the HTTP Version 2.0.</summary>
		public static readonly HTTP_VERSION HTTP_VERSION_2_0 = new() { MajorVersion = 2 };

		/// <summary>A constant for the HTTP Version 3.0.</summary>
		public static readonly HTTP_VERSION HTTP_VERSION_3_0 = new() { MajorVersion = 3 };

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTTP_VERSION left, HTTP_VERSION right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTTP_VERSION left, HTTP_VERSION right) => !left.Equals(right);

		/// <summary>Implements the operator &gt;.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator >(HTTP_VERSION left, HTTP_VERSION right) =>
			left.MajorVersion > right.MajorVersion || left.MinorVersion == right.MinorVersion && left.MinorVersion > right.MinorVersion;

		/// <summary>Implements the operator &lt;.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator <(HTTP_VERSION left, HTTP_VERSION right) =>
			left.MajorVersion < right.MajorVersion || left.MinorVersion == right.MinorVersion && left.MinorVersion < right.MinorVersion;

		/// <inheritdoc/>
		public bool Equals(HTTP_VERSION other) =>
			MajorVersion == other.MajorVersion && MinorVersion == other.MinorVersion;

		/// <inheritdoc/>
		public override int GetHashCode() => (MajorVersion, MinorVersion).GetHashCode();

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HTTP_VERSION v && Equals(v);

		/// <inheritdoc/>
		public override string ToString() => $"{MajorVersion}.{MinorVersion}";
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP_WSK_API_TIMINGS
	{
		public ulong ConnectCount;
		public ulong ConnectSum;
		public ulong DisconnectCount;
		public ulong DisconnectSum;

		public ulong SendCount;
		public ulong SendSum;
		public ulong ReceiveCount;
		public ulong ReceiveSum;

		public ulong ReleaseCount;
		public ulong ReleaseSum;

		public ulong ControlSocketCount;
		public ulong ControlSocketSum;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP2_SETTINGS_LIMITS_PARAM
	{
		/// <summary>The maximum allowed settings per SETTINGS frame.</summary>
		public uint Http2MaxSettingsPerFrame;

		/// <summary>The maximum settings we will process in a minute.</summary>
		public uint Http2MaxSettingsPerMinute;
	}

	[PInvokeData("http.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTP2_WINDOW_SIZE_PARAM
	{
		/// <summary>The http/2 connection receive window size.</summary>
		public uint Http2ReceiveWindowSize;
	}

	/// <summary>
	/// The <c>HTTPAPI_VERSION</c> structure defines the version of the HTTP Server API. This is not to be confused with the version of the
	/// HTTP protocol used, which is stored in an <c>HTTP_VERSION</c> structure.
	/// </summary>
	/// <remarks>
	/// <para>Constants that represents the version of the API are pre-defined in the Http.h header file as follows:</para>
	/// <para>"#define HTTPAPI_VERSION_1 {1, 0}"</para>
	/// <para>"#define HTTPAPI_VERSION_2 {2, 0}"</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/ns-http-httpapi_version typedef struct _HTTPAPI_VERSION { USHORT
	// HttpApiMajorVersion; USHORT HttpApiMinorVersion; } HTTPAPI_VERSION, *PHTTPAPI_VERSION;
	[PInvokeData("http.h", MSDNShortId = "NS:http._HTTPAPI_VERSION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HTTPAPI_VERSION : IEquatable<HTTPAPI_VERSION>
	{
		/// <summary>Major version of the HTTP Server API.</summary>
		public ushort HttpApiMajorVersion;

		/// <summary>Minor version of the HTTP Server API.</summary>
		public ushort HttpApiMinorVersion;

		/// <summary>A constant for the HTTP API Version 1.</summary>
		public static readonly HTTPAPI_VERSION HTTPAPI_VERSION_1 = new() { HttpApiMajorVersion = 1 };

		/// <summary>A constant for the HTTP API Version 2.</summary>
		public static readonly HTTPAPI_VERSION HTTPAPI_VERSION_2 = new() { HttpApiMajorVersion = 2 };

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTTPAPI_VERSION left, HTTPAPI_VERSION right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTTPAPI_VERSION left, HTTPAPI_VERSION right) => !left.Equals(right);

		/// <summary>Implements the operator &gt;.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator >(HTTPAPI_VERSION left, HTTPAPI_VERSION right) =>
			left.HttpApiMajorVersion > right.HttpApiMajorVersion || left.HttpApiMinorVersion == right.HttpApiMinorVersion && left.HttpApiMinorVersion > right.HttpApiMinorVersion;

		/// <summary>Implements the operator &lt;.</summary>
		/// <param name="left">The left value.</param>
		/// <param name="right">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator <(HTTPAPI_VERSION left, HTTPAPI_VERSION right) =>
			left.HttpApiMajorVersion < right.HttpApiMajorVersion || left.HttpApiMinorVersion == right.HttpApiMinorVersion && left.HttpApiMinorVersion < right.HttpApiMinorVersion;

		/// <inheritdoc/>
		public bool Equals(HTTPAPI_VERSION other) =>
			HttpApiMajorVersion == other.HttpApiMajorVersion && HttpApiMinorVersion == other.HttpApiMinorVersion;

		/// <inheritdoc/>
		public override int GetHashCode() => (HttpApiMajorVersion, HttpApiMinorVersion).GetHashCode();

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HTTPAPI_VERSION v && Equals(v);

		/// <inheritdoc/>
		public override string ToString() => $"{HttpApiMajorVersion}.{HttpApiMinorVersion}";
	}
}