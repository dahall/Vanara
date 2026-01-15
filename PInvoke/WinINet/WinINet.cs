using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Vanara.PInvoke;

/// <summary>Functions and structures from WinInet.dll.</summary>
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

	/// <summary/>
	public const int INTERNET_RFC1123_BUFSIZE = 30;

	/// <summary>Represents a failure occurred when calling <see cref="InternetSetStatusCallback"/>.</summary>
	public static readonly IntPtr INTERNET_INVALID_STATUS_CALLBACK = (IntPtr)(-1);

	private const uint GOPHER_ATTRIBUTE_ID_BASE = 0xabcccc00;

	private const int INTERNET_MAX_HOST_NAME_LENGTH = 256;

	private const int INTERNET_MAX_PASSWORD_LENGTH = 128;

	private const int INTERNET_MAX_PATH_LENGTH = 2048;

	private const int INTERNET_MAX_PORT_NUMBER_LENGTH = 5;

	private const int INTERNET_MAX_PORT_NUMBER_VALUE = 65535;

	private const int INTERNET_MAX_SCHEME_LENGTH = 32;

	private const int INTERNET_MAX_URL_LENGTH = INTERNET_MAX_SCHEME_LENGTH + 3 /* sizeof("://") */ + INTERNET_MAX_PATH_LENGTH;

	private const int INTERNET_MAX_USER_NAME_LENGTH = 128;

	/// <summary>
	/// <para>[The GopherAttributeEnumerator function is available for use in the operating systems specified in the Requirements section.]</para>
	/// <para>
	/// Prototype for a callback function that processes attribute information from a Gopher server. This callback function is installed
	/// by a call to the GopherGetAttribute function.
	/// </para>
	/// <para>
	/// The <c>GOPHER_ATTRIBUTE_ENUMERATOR</c> type defines a pointer to this callback function. GopherAttributeEnumerator is a
	/// placeholder for the application-defined function name.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nc-wininet-gopher_attribute_enumerator GOPHER_ATTRIBUTE_ENUMERATOR
	// GopherAttributeEnumerator; BOOL GopherAttributeEnumerator( LPGOPHER_ATTRIBUTE_TYPE lpAttributeInfo, DWORD dwError ) {...}
	[PInvokeData("wininet.h", MSDNShortId = "1a319d79-7866-4121-a80f-22e3bf983a0a")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate BOOL GopherAttributeEnumerator(in GOPHER_ATTRIBUTE_TYPE lpAttributeInfo, Win32Error dwError);

	/// <summary>Callback for <see cref="INTERNET_AUTH_NOTIFY_DATA"/>.</summary>
	/// <param name="dwContext">The context specified in the structure.</param>
	/// <param name="dwReturn">The error code: success, resend, or cancel.</param>
	/// <param name="lpReserved">Reserved. Will always be IntPtr.Zero.</param>
	/// <returns>Error?? (undocumented)</returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate uint InternetAuthNotifyCallback(IntPtr dwContext, Win32Error dwReturn, IntPtr lpReserved);

	/// <summary>Prototype for an application-defined status callback function.</summary>
	/// <param name="hInternet">The handle for which the callback function is called.</param>
	/// <param name="dwContext">A pointer to a variable that specifies the application-defined context value associated with hInternet.</param>
	/// <param name="dwInternetStatus">A status code that indicates why the callback function is called.</param>
	/// <param name="lpvStatusInformation">
	/// A pointer to additional status information. When the INTERNET_STATUS_STATE_CHANGE flag is set, lpvStatusInformation points to a
	/// DWORD that contains one or more of the <see cref="InternetState"/> flags.
	/// </param>
	/// <param name="dwStatusInformationLength">The size, in bytes, of the data pointed to by lpvStatusInformation.</param>
	[PInvokeData("wininet.h", MSDNShortId = "a054fb71-66ab-46fd-be19-2237f05662bc")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void InternetStatusCallback([In] HINTERNET hInternet, [In, Optional] IntPtr dwContext, [In] InternetStatus dwInternetStatus, [In, Optional] IntPtr lpvStatusInformation, [In] uint dwStatusInformationLength);

	/// <summary>Indicates the members that are to be retrieved via <see cref="GetUrlCacheConfigInfo"/>.</summary>
	[PInvokeData("winineti.h", MSDNShortId = "93a29a4f-57bf-497c-a7b1-3960935590f9")]
	[Flags]
	public enum CACHE_CONFIG_FC : uint
	{
		/// <summary>Not used.</summary>
		CACHE_CONFIG_FORCE_CLEANUP_FC = 0x00000020,

		/// <summary>Not used.</summary>
		CACHE_CONFIG_DISK_CACHE_PATHS_FC = 0x00000040,

		/// <summary>Reserved.</summary>
		CACHE_CONFIG_SYNC_MODE_FC = 0x00000080,

		/// <summary>
		/// The CachePath field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo parameter is filled with
		/// a pointer to a string identifying the content path. This cannot be used at the same time as CACHE_CONFIG_HISTORY_PATHS_FC or CACHE_CONFIG_COOKIES_PATHS_FC.
		/// </summary>
		CACHE_CONFIG_CONTENT_PATHS_FC = 0x00000100,

		/// <summary>
		/// The CachePath field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo parameter is filled with
		/// a pointer to a string identifying the cookie path. This cannot be used at the same time as CACHE_CONFIG_CONTENT_PATHS_FC or CACHE_CONFIG_HISTORY_PATHS_FC.
		/// </summary>
		CACHE_CONFIG_COOKIES_PATHS_FC = 0x00000200,

		/// <summary>
		/// The CachePath field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo parameter is filled with
		/// a pointer to a string identifying the history path. This cannot be used at the same time as CACHE_CONFIG_CONTENT_PATHS_FC or CACHE_CONFIG_COOKIES_PATHS_FC.
		/// </summary>
		CACHE_CONFIG_HISTORY_PATHS_FC = 0x00000400,

		/// <summary>
		/// The dwQuota field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo is set to the cache limit
		/// for the container specified in the dwContainer field.
		/// </summary>
		CACHE_CONFIG_QUOTA_FC = 0x00000800,

		/// <summary>Reserved.</summary>
		CACHE_CONFIG_USER_MODE_FC = 0x00001000,

		/// <summary>
		/// The dwNormalUsage field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo is set to the cache
		/// size for the container specified in the dwContainer field.
		/// </summary>
		CACHE_CONFIG_CONTENT_USAGE_FC = 0x00002000,

		/// <summary>
		/// The dwExemptUsage field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo is set to the exempt
		/// usage, the amount of bytes exempt from scavenging, for the container specified in the dwContainer field. (This field must be
		/// the content container.)
		/// </summary>
		CACHE_CONFIG_STICKY_CONTENT_USAGE_FC = 0x00004000,
	}

	/// <summary>Indicates the members that are to be set via <see cref="SetUrlCacheEntryInfo"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "71f6e1a3-09ce-4576-9480-1270f343db39")]
	[Flags]
	public enum CACHE_ENTRY_FC : uint
	{
		/// <summary>Sets the cache entry type.</summary>
		CACHE_ENTRY_ATTRIBUTE_FC = 0x00000004,

		/// <summary>Sets the hit rate.</summary>
		CACHE_ENTRY_HITRATE_FC = 0x00000010,

		/// <summary>Sets the last modified time.</summary>
		CACHE_ENTRY_MODTIME_FC = 0x00000040,

		/// <summary>Sets the expire time.</summary>
		CACHE_ENTRY_EXPTIME_FC = 0x00000080,

		/// <summary>Sets the last access time.</summary>
		CACHE_ENTRY_ACCTIME_FC = 0x00000100,

		/// <summary>Sets the last sync time.</summary>
		CACHE_ENTRY_SYNCTIME_FC = 0x00000200,

		/// <summary>Not currently implemented.</summary>
		CACHE_ENTRY_HEADERINFO_FC = 0x00000400,

		/// <summary>Sets the exempt delta.</summary>
		CACHE_ENTRY_EXEMPT_DELTA_FC = 0x00000800,
	}

	/// <summary>A bitmask indicating the type of cache entry and its properties.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "7bda08e0-5df0-4087-a5cd-3a25c6ae5ade")]
	[Flags]
	public enum CACHE_ENTRY_TYPE
	{
		/// <summary>The default filter.</summary>
		URLCACHE_FIND_DEFAULT_FILTER = NORMAL_CACHE_ENTRY | COOKIE_CACHE_ENTRY | URLHISTORY_CACHE_ENTRY | TRACK_OFFLINE_CACHE_ENTRY | TRACK_ONLINE_CACHE_ENTRY | STICKY_CACHE_ENTRY,

		/// <summary>Normal cache entry; can be deleted to recover space for new entries.</summary>
		NORMAL_CACHE_ENTRY = 0x00000001,

		/// <summary>
		/// Sticky cache entry that is exempt from scavenging for the amount of time specified by dwExemptDelta. The default value set
		/// by CommitUrlCacheEntryA and CommitUrlCacheEntryW is one day.
		/// </summary>
		STICKY_CACHE_ENTRY = 0x00000004,

		/// <summary>Cache entry file that has been edited externally. This cache entry type is exempt from scavenging.</summary>
		EDITED_CACHE_ENTRY = 0x00000008,

		/// <summary>Not currently implemented.</summary>
		TRACK_OFFLINE_CACHE_ENTRY = 0x00000010,

		/// <summary>Not currently implemented.</summary>
		TRACK_ONLINE_CACHE_ENTRY = 0x00000020,

		/// <summary>Partial response cache entry.</summary>
		SPARSE_CACHE_ENTRY = 0x00010000,

		/// <summary>Cookie cache entry.</summary>
		COOKIE_CACHE_ENTRY = 0x00100000,

		/// <summary>Visited link cache entry.</summary>
		URLHISTORY_CACHE_ENTRY = 0x00200000,
	}

	/// <summary>Cache group flgas.</summary>
	[PInvokeData("wininet.h")]
	public enum CACHEGROUP_FLAG
	{
		/// <summary>Indicates that the cache entries in this group will not be removed by the cache manager.</summary>
		CACHEGROUP_FLAG_NONPURGEABLE = 0x00000001,

		/// <summary>Causes <c>CreateUrlCacheGroup</c> to generate a unique GROUPID, but does not create a physical group.</summary>
		CACHEGROUP_FLAG_GIDONLY = 0x00000004,

		/// <summary>
		/// Causes <c>DeleteUrlCacheGroup</c> to delete all of the cache entries associated with this group, unless the entry belongs to
		/// another group.
		/// </summary>
		CACHEGROUP_FLAG_FLUSHURL_ONDELETE = 0x00000002,
	}

	/// <summary>Filters for <see cref="FindFirstUrlCacheGroup"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "a333cbc6-a880-4b1c-be0d-abb083909638")]
	public enum CACHEGROUP_SEARCH
	{
		/// <summary>Search all cache groups.</summary>
		CACHEGROUP_SEARCH_ALL,

		/// <summary>Not currently implemented.</summary>
		CACHEGROUP_SEARCH_BYURL
	}

	/// <summary>Options for <see cref="InternetCheckConnection"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "4666e4ee-057e-452d-ac2c-d03321a0073f")]
	[Flags]
	public enum FLAG_ICC
	{
		/// <summary>Forces a connection.</summary>
		FLAG_ICC_FORCE_CONNECTION = 1
	}

	/// <summary>Actions to perform when calling <see cref="InternetErrorDlg"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "09384ba9-e5cc-48fd-a52c-15df223f87dc")]
	[Flags]
	public enum FLAGS_ERROR_UI
	{
		/// <summary>
		/// Scans the returned headers for errors. Call InternetErrorDlg with this flag set following a call to HttpSendRequest so as to
		/// detect hidden errors. Authentication errors, for example, are normally hidden because the call to HttpSendRequest completes
		/// successfully, but by scanning the status codes, InternetErrorDlg can determine that the proxy or server requires authentication.
		/// </summary>
		FLAGS_ERROR_UI_FILTER_FOR_ERRORS = 0x01,

		/// <summary>If the function succeeds, stores the results of the dialog box in the Internet handle.</summary>
		FLAGS_ERROR_UI_FLAGS_CHANGE_OPTIONS = 0x02,

		/// <summary>
		/// Queries the Internet handle for needed information. The function constructs the appropriate data structure for the error.
		/// (For example, for Cert CN failures, the function grabs the certificate.)
		/// </summary>
		FLAGS_ERROR_UI_FLAGS_GENERATE_DATA = 0x04,

		/// <summary>
		/// Allows the caller to pass NULL to the hWnd parameter without error. To be used in circumstances in which no user interface
		/// is required.
		/// </summary>
		FLAGS_ERROR_UI_FLAGS_NO_UI = 0x08,

		/// <summary>
		/// Serializes authentication dialog boxes for concurrent requests on a password cache entry. The lppvData parameter should
		/// contain the address of a pointer to an INTERNET_AUTH_NOTIFY_DATA structure, and the client should implement a thread-safe,
		/// non-blocking callback function.
		/// </summary>
		FLAGS_ERROR_UI_SERIALIZE_DIALOGS = 0x10,
	}

	/// <summary>Transfer types for FTP transfers.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "cd12f52c-80d6-4aee-96c8-cb3cafcf0a6a")]
	public enum FTP_TRANSER_TYPE : uint
	{
		/// <summary>
		/// Transfers the file using the FTP Image (Type I) transfer method. The file is transferred exactly with no changes. This is
		/// the default transfer method.
		/// </summary>
		FTP_TRANSER_TYPE_BINARY = INTERNET_FLAG.INTERNET_FLAG_TRANSFER_BINARY,

		/// <summary>
		/// Transfers the file using the FTP ASCII (Type A) transfer method. Control and formatting data is converted to local equivalents.
		/// </summary>
		FTP_TRANSER_TYPE_ASCII = INTERNET_FLAG.INTERNET_FLAG_TRANSFER_ASCII
	}

	/// <summary>Attribute type.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "01daae8c-9080-4a8d-9f73-3e364ca868fe")]
	public enum GOPHER_ATTRIBUTE_ID : uint
	{
		/// <summary/>
		GOPHER_ATTRIBUTE_ID_ADMIN = GOPHER_ATTRIBUTE_ID_BASE + 10,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_MOD_DATE = GOPHER_ATTRIBUTE_ID_BASE + 11,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_TTL = GOPHER_ATTRIBUTE_ID_BASE + 12,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_SCORE = GOPHER_ATTRIBUTE_ID_BASE + 13,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_RANGE = GOPHER_ATTRIBUTE_ID_BASE + 14,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_SITE = GOPHER_ATTRIBUTE_ID_BASE + 15,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_ORG = GOPHER_ATTRIBUTE_ID_BASE + 16,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_LOCATION = GOPHER_ATTRIBUTE_ID_BASE + 17,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_GEOG = GOPHER_ATTRIBUTE_ID_BASE + 18,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_TIMEZONE = GOPHER_ATTRIBUTE_ID_BASE + 19,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_PROVIDER = GOPHER_ATTRIBUTE_ID_BASE + 20,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_VERSION = GOPHER_ATTRIBUTE_ID_BASE + 21,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_ABSTRACT = GOPHER_ATTRIBUTE_ID_BASE + 22,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_VIEW = GOPHER_ATTRIBUTE_ID_BASE + 23,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_TREEWALK = GOPHER_ATTRIBUTE_ID_BASE + 24,

		/// <summary/>
		GOPHER_ATTRIBUTE_ID_UNKNOWN = GOPHER_ATTRIBUTE_ID_BASE + 25,
	}

	/// <summary>Name of the Gopher category for the attribute.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "01daae8c-9080-4a8d-9f73-3e364ca868fe")]
	public enum GOPHER_CATEGORY_ID : uint
	{
		/// <summary/>
		GOPHER_CATEGORY_ID_INFO = GOPHER_ATTRIBUTE_ID_BASE + 2,

		/// <summary/>
		GOPHER_CATEGORY_ID_ADMIN = GOPHER_ATTRIBUTE_ID_BASE + 3,

		/// <summary/>
		GOPHER_CATEGORY_ID_VIEWS = GOPHER_ATTRIBUTE_ID_BASE + 4,

		/// <summary/>
		GOPHER_CATEGORY_ID_ABSTRACT = GOPHER_ATTRIBUTE_ID_BASE + 5,

		/// <summary/>
		GOPHER_CATEGORY_ID_VERONICA = GOPHER_ATTRIBUTE_ID_BASE + 6,

		/// <summary/>
		GOPHER_CATEGORY_ID_ASK = GOPHER_ATTRIBUTE_ID_BASE + 7,

		/// <summary/>
		GOPHER_CATEGORY_ID_UNKNOWN = GOPHER_ATTRIBUTE_ID_BASE + 8,
	}

	/// <summary>Gopher types.</summary>
	[PInvokeData("wininet.h")]
	[Flags]
	public enum GOPHER_TYPE : uint
	{
		/// <summary>Ask+ item.</summary>
		GOPHER_TYPE_ASK = 0x40000000,

		/// <summary>Binary file.</summary>
		GOPHER_TYPE_BINARY = 0x00000200,

		/// <summary>Bitmap file.</summary>
		GOPHER_TYPE_BITMAP = 0x00004000,

		/// <summary>Calendar file.</summary>
		GOPHER_TYPE_CALENDAR = 0x00080000,

		/// <summary>CSO telephone book server.</summary>
		GOPHER_TYPE_CSO = 0x00000004,

		/// <summary>Directory of additional Gopher items.</summary>
		GOPHER_TYPE_DIRECTORY = 0x00000002,

		/// <summary>MS-DOS archive file.</summary>
		GOPHER_TYPE_DOS_ARCHIVE = 0x00000020,

		/// <summary>Indicator of an error condition.</summary>
		GOPHER_TYPE_ERROR = 0x00000008,

		/// <summary>GIF graphics file.</summary>
		GOPHER_TYPE_GIF = 0x00001000,

		/// <summary>Gopher+ item.</summary>
		GOPHER_TYPE_GOPHER_PLUS = 0x80000000,

		/// <summary>HTML document.</summary>
		GOPHER_TYPE_HTML = 0x00020000,

		/// <summary>Image file.</summary>
		GOPHER_TYPE_IMAGE = 0x00002000,

		/// <summary>Index server.</summary>
		GOPHER_TYPE_INDEX_SERVER = 0x00000080,

		/// <summary>Inline file.</summary>
		GOPHER_TYPE_INLINE = 0x00100000,

		/// <summary>Macintosh file in BINHEX format.</summary>
		GOPHER_TYPE_MAC_BINHEX = 0x00000010,

		/// <summary>Movie file.</summary>
		GOPHER_TYPE_MOVIE = 0x00008000,

		/// <summary>PDF file.</summary>
		GOPHER_TYPE_PDF = 0x00040000,

		/// <summary>
		/// Indicator of a duplicated server. The information contained within is a duplicate of the primary server. The primary server
		/// is defined as the last directory entry that did not have a GOPHER_TYPE_REDUNDANT type.
		/// </summary>
		GOPHER_TYPE_REDUNDANT = 0x00000400,

		/// <summary>Sound file.</summary>
		GOPHER_TYPE_SOUND = 0x00010000,

		/// <summary>Telnet server.</summary>
		GOPHER_TYPE_TELNET = 0x00000100,

		/// <summary>ASCII text file.</summary>
		GOPHER_TYPE_TEXT_FILE = 0x00000001,

		/// <summary>TN3270 server.</summary>
		GOPHER_TYPE_TN3270 = 0x00000800,

		/// <summary>UUENCODED file.</summary>
		GOPHER_TYPE_UNIX_UUENCODED = 0x00000040,

		/// <summary>Item type is unknown.</summary>
		GOPHER_TYPE_UNKNOWN = 0x20000000,
	}

	/// <summary>A set of modifiers that control the semantics of <see cref="HttpAddRequestHeaders"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "636c3442-a2e6-4885-8fb4-1f6996ba6860")]
	[Flags]
	public enum HTTP_ADDREQ_FLAG : uint
	{
		/// <summary>Adds the header only if it does not already exist; otherwise, an error is returned.</summary>
		HTTP_ADDREQ_FLAG_ADD_IF_NEW = 0x10000000,

		/// <summary>Adds the header if it does not exist. Used with HTTP_ADDREQ_FLAG_REPLACE.</summary>
		HTTP_ADDREQ_FLAG_ADD = 0x20000000,

		/// <summary>
		/// Coalesces headers of the same name. For example, adding "Accept: text/*" followed by "Accept: audio/*" with this flag
		/// results in the formation of the single header "Accept: text/*, audio/*". This causes the first header found to be coalesced.
		/// It is up to the calling application to ensure a cohesive scheme with respect to coalesced/separate headers.
		/// </summary>
		HTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA = 0x40000000,

		/// <summary>Coalesces headers of the same name using a semicolon.</summary>
		HTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON = 0x01000000,

		/// <summary>Coalesces headers of the same name.</summary>
		HTTP_ADDREQ_FLAG_COALESCE = HTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA,

		/// <summary>
		/// Replaces or removes a header. If the header value is empty and the header is found, it is removed. If not empty, the header
		/// value is replaced.
		/// </summary>
		HTTP_ADDREQ_FLAG_REPLACE = 0x80000000
	}

	/// <summary>
	/// The attribute flags are used by HttpQueryInfo (or QueryInfo) to indicate what data to retrieve. Most of the attribute flags map
	/// directly to a specific HTTP header. There are also some special flags, such as HTTP_QUERY_RAW_HEADERS, that are not related to a
	/// specific header.
	/// </summary>
	[PInvokeData("wininet.h")]
	[Flags]
	public enum HTTP_QUERY : uint
	{
		/// <summary>Retrieves the acceptable media types for the response.</summary>
		HTTP_QUERY_ACCEPT = 24,

		/// <summary>Retrieves the acceptable character sets for the response.</summary>
		HTTP_QUERY_ACCEPT_CHARSET = 25,

		/// <summary>Retrieves the acceptable content-coding values for the response.</summary>
		HTTP_QUERY_ACCEPT_ENCODING = 26,

		/// <summary>Retrieves the acceptable natural languages for the response.</summary>
		HTTP_QUERY_ACCEPT_LANGUAGE = 27,

		/// <summary>Retrieves the types of range requests that are accepted for a resource.</summary>
		HTTP_QUERY_ACCEPT_RANGES = 42,

		/// <summary>
		/// Retrieves the Age response-header field, which contains the sender's estimate of the amount of time since the response was
		/// generated at the origin server.
		/// </summary>
		HTTP_QUERY_AGE = 48,

		/// <summary>Receives the HTTP verbs supported by the server.</summary>
		HTTP_QUERY_ALLOW = 7,

		/// <summary>Retrieves the authorization credentials used for a request.</summary>
		HTTP_QUERY_AUTHORIZATION = 28,

		/// <summary>Retrieves the cache control directives.</summary>
		HTTP_QUERY_CACHE_CONTROL = 49,

		/// <summary>
		/// Retrieves any options that are specified for a particular connection and must not be communicated by proxies over further connections.
		/// </summary>
		HTTP_QUERY_CONNECTION = 23,

		/// <summary>Retrieves the base URI (Uniform Resource Identifier) for resolving relative URLs within the entity.</summary>
		HTTP_QUERY_CONTENT_BASE = 50,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_CONTENT_DESCRIPTION = 4,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_CONTENT_DISPOSITION = 47,

		/// <summary>Retrieves any additional content codings that have been applied to the entire resource.</summary>
		HTTP_QUERY_CONTENT_ENCODING = 29,

		/// <summary>Retrieves the content identification.</summary>
		HTTP_QUERY_CONTENT_ID = 3,

		/// <summary>Retrieves the language that the content is in.</summary>
		HTTP_QUERY_CONTENT_LANGUAGE = 6,

		/// <summary>Retrieves the size of the resource, in bytes.</summary>
		HTTP_QUERY_CONTENT_LENGTH = 5,

		/// <summary>Retrieves the resource location for the entity enclosed in the message.</summary>
		HTTP_QUERY_CONTENT_LOCATION = 51,

		/// <summary>
		/// Retrieves an MD5 digest of the entity-body for the purpose of providing an end-to-end message integrity check (MIC) for the
		/// entity-body. For more information, see RFC1864, The Content-MD5 Header Field, at https://ftp.isi.edu/in-notes/rfc1864.txt.
		/// </summary>
		HTTP_QUERY_CONTENT_MD5 = 52,

		/// <summary>
		/// Retrieves the location in the full entity-body where the partial entity-body should be inserted and the total size of the
		/// full entity-body.
		/// </summary>
		HTTP_QUERY_CONTENT_RANGE = 53,

		/// <summary>Receives the additional content coding that has been applied to the resource.</summary>
		HTTP_QUERY_CONTENT_TRANSFER_ENCODING = 2,

		/// <summary>Receives the content type of the resource (such as text/html).</summary>
		HTTP_QUERY_CONTENT_TYPE = 1,

		/// <summary>Retrieves any cookies associated with the request.</summary>
		HTTP_QUERY_COOKIE = 44,

		/// <summary>No longer supported.</summary>
		HTTP_QUERY_COST = 15,

		/// <summary>Causes HttpQueryInfo to search for the header name specified in lpvBuffer and store the header data in lpvBuffer.</summary>
		HTTP_QUERY_CUSTOM = 65535,

		/// <summary>Receives the date and time at which the message was originated.</summary>
		HTTP_QUERY_DATE = 9,

		/// <summary>No longer supported.</summary>
		HTTP_QUERY_DERIVED_FROM = 14,

		/// <summary>Not currently implemented.</summary>
		HTTP_QUERY_ECHO_HEADERS = 73,

		/// <summary>Not currently implemented.</summary>
		HTTP_QUERY_ECHO_HEADERS_CRLF = 74,

		/// <summary>Not currently implemented.</summary>
		HTTP_QUERY_ECHO_REPLY = 72,

		/// <summary>Not currently implemented.</summary>
		HTTP_QUERY_ECHO_REQUEST = 71,

		/// <summary>Retrieves the entity tag for the associated entity.</summary>
		HTTP_QUERY_ETAG = 54,

		/// <summary>Retrieves the Expect header, which indicates whether the client application should expect 100 series responses.</summary>
		HTTP_QUERY_EXPECT = 68,

		/// <summary>Receives the date and time after which the resource should be considered outdated.</summary>
		HTTP_QUERY_EXPIRES = 10,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_FORWARDED = 30,

		/// <summary>
		/// Retrieves the email address for the human user who controls the requesting user agent if the From header is given.
		/// </summary>
		HTTP_QUERY_FROM = 31,

		/// <summary>Retrieves the Internet host and port number of the resource being requested.</summary>
		HTTP_QUERY_HOST = 55,

		/// <summary>Retrieves the contents of the If-Match request-header field.</summary>
		HTTP_QUERY_IF_MATCH = 56,

		/// <summary>Retrieves the contents of the If-Modified-Since header.</summary>
		HTTP_QUERY_IF_MODIFIED_SINCE = 32,

		/// <summary>Retrieves the contents of the If-None-Match request-header field.</summary>
		HTTP_QUERY_IF_NONE_MATCH = 57,

		/// <summary>
		/// Retrieves the contents of the If-Range request-header field. This header enables the client application to verify that the
		/// entity related to a partial copy of the entity in the client application cache has not been updated. If the entity has not
		/// been updated, send the parts that the client application is missing. If the entity has been updated, send the entire updated entity.
		/// </summary>
		HTTP_QUERY_IF_RANGE = 58,

		/// <summary>Retrieves the contents of the If-Unmodified-Since request-header field.</summary>
		HTTP_QUERY_IF_UNMODIFIED_SINCE = 59,

		/// <summary>Receives the date and time at which the server believes the resource was last modified.</summary>
		HTTP_QUERY_LAST_MODIFIED = 11,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_LINK = 16,

		/// <summary>Retrieves the absolute Uniform Resource Identifier (URI) used in a Location response-header.</summary>
		HTTP_QUERY_LOCATION = 33,

		/// <summary>Not a query flag. Indicates the maximum value of an HTTP_QUERY_* value.</summary>
		HTTP_QUERY_MAX = 78,

		/// <summary>Retrieves the number of proxies or gateways that can forward the request to the next inbound server.</summary>
		HTTP_QUERY_MAX_FORWARDS = 60,

		/// <summary>No longer supported.</summary>
		HTTP_QUERY_MESSAGE_ID = 12,

		/// <summary>Receives the version of the MIME protocol that was used to construct the message.</summary>
		HTTP_QUERY_MIME_VERSION = 0,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_ORIG_URI = 34,

		/// <summary>
		/// Receives the implementation-specific directives that might apply to any recipient along the request/response chain.
		/// </summary>
		HTTP_QUERY_PRAGMA = 17,

		/// <summary>Retrieves the authentication scheme and realm returned by the proxy.</summary>
		HTTP_QUERY_PROXY_AUTHENTICATE = 41,

		/// <summary>
		/// Retrieves the header that is used to identify the user to a proxy that requires authentication. This header can only be
		/// retrieved before the request is sent to the server.
		/// </summary>
		HTTP_QUERY_PROXY_AUTHORIZATION = 61,

		/// <summary>Retrieves the Proxy-Connection header.</summary>
		HTTP_QUERY_PROXY_CONNECTION = 69,

		/// <summary>Receives methods available at this server.</summary>
		HTTP_QUERY_PUBLIC = 8,

		/// <summary>Retrieves the byte range of an entity.</summary>
		HTTP_QUERY_RANGE = 62,

		/// <summary>
		/// Receives all the headers returned by the server. Each header is terminated by "\0". An additional "\0" terminates the list
		/// of headers.
		/// </summary>
		HTTP_QUERY_RAW_HEADERS = 21,

		/// <summary>
		/// Receives all the headers returned by the server. Each header is separated by a carriage return/line feed (CR/LF) sequence.
		/// </summary>
		HTTP_QUERY_RAW_HEADERS_CRLF = 22,

		/// <summary>Receives the Uniform Resource Identifier (URI) of the resource where the requested URI was obtained.</summary>
		HTTP_QUERY_REFERER = 35,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_REFRESH = 46,

		/// <summary>Receives the HTTP verb that is being used in the request, typically GET or POST.</summary>
		HTTP_QUERY_REQUEST_METHOD = 45,

		/// <summary>Retrieves the amount of time the service is expected to be unavailable.</summary>
		HTTP_QUERY_RETRY_AFTER = 36,

		/// <summary>Retrieves data about the software used by the origin server to handle the request.</summary>
		HTTP_QUERY_SERVER = 37,

		/// <summary>Receives the value of the cookie set for the request.</summary>
		HTTP_QUERY_SET_COOKIE = 43,

		/// <summary>
		/// Receives the status code returned by the server. For more information and a list of possible values, see HTTP Status Codes.
		/// </summary>
		HTTP_QUERY_STATUS_CODE = 19,

		/// <summary>Receives any additional text returned by the server on the response line.</summary>
		HTTP_QUERY_STATUS_TEXT = 20,

		/// <summary>Obsolete. Maintained for legacy application compatibility only.</summary>
		HTTP_QUERY_TITLE = 38,

		/// <summary>
		/// Retrieves the type of transformation that has been applied to the message body so it can be safely transferred between the
		/// sender and recipient.
		/// </summary>
		HTTP_QUERY_TRANSFER_ENCODING = 63,

		/// <summary>Retrieves the Unless-Modified-Since header.</summary>
		HTTP_QUERY_UNLESS_MODIFIED_SINCE = 70,

		/// <summary>Retrieves the additional communication protocols that are supported by the server.</summary>
		HTTP_QUERY_UPGRADE = 64,

		/// <summary>Receives some or all of the Uniform Resource Identifiers (URIs) by which the Request-URI resource can be identified.</summary>
		HTTP_QUERY_URI = 13,

		/// <summary>Retrieves data about the user agent that made the request.</summary>
		HTTP_QUERY_USER_AGENT = 39,

		/// <summary>
		/// Retrieves the header that indicates that the entity was selected from a number of available representations of the response
		/// using server-driven negotiation.
		/// </summary>
		HTTP_QUERY_VARY = 65,

		/// <summary>Receives the last response code returned by the server.</summary>
		HTTP_QUERY_VERSION = 18,

		/// <summary>
		/// Retrieves the intermediate protocols and recipients between the user agent and the server on requests, and between the
		/// origin server and the client on responses.
		/// </summary>
		HTTP_QUERY_VIA = 66,

		/// <summary>
		/// Retrieves additional data about the status of a response that might not be reflected by the response status code.
		/// </summary>
		HTTP_QUERY_WARNING = 67,

		/// <summary>Retrieves the authentication scheme and realm returned by the server.</summary>
		HTTP_QUERY_WWW_AUTHENTICATE = 40,

		/// <summary>Retrieves the X-Content-Type-Options header value.</summary>
		HTTP_QUERY_X_CONTENT_TYPE_OPTIONS = 79,

		/// <summary>Retrieves the P3P header value.</summary>
		HTTP_QUERY_P3P = 80,

		/// <summary>Retrieves the X-P2P-PeerDist header value.</summary>
		HTTP_QUERY_X_P2P_PEERDIST = 81,

		/// <summary>Retrieves the translate header value.</summary>
		HTTP_QUERY_TRANSLATE = 82,

		/// <summary>Retrieves the X-UA-Compatible header value.</summary>
		HTTP_QUERY_X_UA_COMPATIBLE = 83,

		/// <summary>Retrieves the Default-Style header value.</summary>
		HTTP_QUERY_DEFAULT_STYLE = 84,

		/// <summary>Retrieves the X-Frame-Options header value.</summary>
		HTTP_QUERY_X_FRAME_OPTIONS = 85,

		/// <summary>
		/// Retrieves the X-XSS-Protection header value.
		/// <para>
		/// The modifier flags are used in conjunction with an attribute flag to modify the request. Modifier flags either modify the
		/// format of the data returned or indicate where HttpQueryInfo (or QueryInfo) should search for the data.
		/// </para>
		/// </summary>
		HTTP_QUERY_X_XSS_PROTECTION = 86,

		/// <summary>Not implemented.</summary>
		HTTP_QUERY_FLAG_COALESCE = 0x10000000,

		/// <summary>Returns the data as a 32-bit number for headers whose value is a number, such as the status code.</summary>
		HTTP_QUERY_FLAG_NUMBER = 0x20000000,

		/// <summary>
		/// If this bit is set in the dwInfoLevel parameter of HttpQueryInfo(), then the values from several headers of the same name
		/// will be combined using comma as the delimiter.
		/// </summary>
		HTTP_QUERY_FLAG_COALESCE_WITH_COMMA = 0x40000000,

		/// <summary>Queries request headers only.</summary>
		HTTP_QUERY_FLAG_REQUEST_HEADERS = 0x80000000,

		/// <summary>
		/// Returns the header value as a SYSTEMTIME structure, which does not require the application to parse the data. Use for
		/// headers whose value is a date/time string, such as "Last-Modified-Time".
		/// </summary>
		HTTP_QUERY_FLAG_SYSTEMTIME = 0x40000000,
	}

	/// <summary>The HTTP status codes returned by servers on the Internet.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/wininet/http-status-codes
	[PInvokeData("wininet.h")]
	public enum HTTP_STATUS : uint
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

		/// <summary>The returned meta information in the entity-header is not the definitive set available from the origin server.</summary>
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

		/// <summary>The server couldn't decide what to return.</summary>
		HTTP_STATUS_AMBIGUOUS = 300,

		/// <summary>
		/// The requested resource has been assigned to a new permanent URI (Uniform Resource Identifier), and any future references to
		/// this resource should be done using one of the returned URIs.
		/// </summary>
		HTTP_STATUS_MOVED = 301,

		/// <summary>The requested resource resides temporarily under a different URI (Uniform Resource Identifier).</summary>
		HTTP_STATUS_REDIRECT = 302,

		/// <summary>
		/// The response to the request can be found under a different URI (Uniform Resource Identifier) and should be retrieved using a
		/// GET HTTP verb on that resource.
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

		/// <summary>Not currently implemented in the HTTP protocol.</summary>
		HTTP_STATUS_PAYMENT_REQ = 402,

		/// <summary>The server understood the request, but is refusing to fulfill it.</summary>
		HTTP_STATUS_FORBIDDEN = 403,

		/// <summary>The server has not found anything matching the requested URI (Uniform Resource Identifier).</summary>
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

		/// <summary>The server refuses to accept the request without a defined content length.</summary>
		HTTP_STATUS_LENGTH_REQUIRED = 411,

		/// <summary>
		/// The precondition given in one or more of the request header fields evaluated to false when it was tested on the server.
		/// </summary>
		HTTP_STATUS_PRECOND_FAILED = 412,

		/// <summary>
		/// The server is refusing to process a request because the request entity is larger than the server is willing or able to process.
		/// </summary>
		HTTP_STATUS_REQUEST_TOO_LARGE = 413,

		/// <summary>
		/// The server is refusing to service the request because the request URI (Uniform Resource Identifier) is longer than the server
		/// is willing to interpret.
		/// </summary>
		HTTP_STATUS_URI_TOO_LONG = 414,

		/// <summary>
		/// The server is refusing to service the request because the entity of the request is in a format not supported by the requested
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

		/// <summary>The server does not support, or refuses to support, the HTTP protocol version that was used in the request message.</summary>
		HTTP_STATUS_VERSION_NOT_SUP = 505,
	}

	/// <summary>Controls canonicalization.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "3bfde980-e478-4960-b41f-e1c8105ef419")]
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
		/// Converts all escape sequences (%xx) to their corresponding characters. This can be used only in <c>InternetCrackUrl</c> and
		/// <c>InternetCreateUrl</c> and if the user provides buffers in the URL_COMPONENTS structure to copy the components into.
		/// </summary>
		ICU_ESCAPE = 0x80000000,

		/// <summary>Obsolete — ignored.</summary>
		ICU_USERNAME = 0x40000000,
	}

	/// <summary>Flags used by <see cref="INTERNET_DIAGNOSTIC_SOCKET_INFO"/>.</summary>
	[PInvokeData("WinInet.h")]
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

	/// <summary>Controls this operation of <see cref="InternetAutodial"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "843875a8-6c83-4259-8e46-a04f786eb230")]
	[Flags]
	public enum INTERNET_AUTODIAL
	{
		/// <summary>
		/// Causes InternetAutodial to fail if file and printer sharing is disabled for Windows 95 or later.
		/// <para>Windows Server 2008 and Windows Vista: This flag is obsolete.</para>
		/// </summary>
		INTERNET_AUTODIAL_FAILIFSECURITYCHECK = 0x04,

		/// <summary>Forces an online Internet connection.</summary>
		INTERNET_AUTODIAL_FORCE_ONLINE = 0x01,

		/// <summary>Forces an unattended Internet dial-up.</summary>
		INTERNET_AUTODIAL_FORCE_UNATTENDED = 0x02,

		/// <summary>Causes InternetAutodial to dial the modem connection even when a network connection to the Internet is present.</summary>
		INTERNET_AUTODIAL_OVERRIDE_NET_PRESENT = 0x08,
	}

	/// <summary>Cache container flags.</summary>
	[PInvokeData("wininet.h")]
	[Flags]
	public enum INTERNET_CACHE_CONTAINER
	{
		/// <summary/>
		INTERNET_CACHE_CONTAINER_NOSUBDIRS = 0x1,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_AUTODELETE = 0x2,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_RESERVED1 = 0x4,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_NODESKTOPINIT = 0x8,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_MAP_ENABLED = 0x10,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_BLOOM_FILTER = 0x20,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_SHARE_READ = 0x100,

		/// <summary/>
		INTERNET_CACHE_CONTAINER_SHARE_READ_WRITE = 0x300,
	}

	/// <summary>Determines whether the entry is added to or removed from a cache group.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "b39a96ac-c5b5-4b02-88e2-298a037be25f")]
	public enum INTERNET_CACHE_GROUP
	{
		/// <summary>Adds the cache entry to the cache group.</summary>
		INTERNET_CACHE_GROUP_ADD = 0,

		/// <summary>Removes the entry from the cache group.</summary>
		INTERNET_CACHE_GROUP_REMOVE = 1
	}

	/// <summary>Internet connection state retrieved from <see cref="InternetGetConnectedState"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "500765b8-fbe4-4bba-894e-cc7f114d9eaa")]
	[Flags]
	public enum INTERNET_CONNECTION
	{
		/// <summary>Local system has a valid connection to the Internet, but it might or might not be currently connected.</summary>
		INTERNET_CONNECTION_CONFIGURED = 0x40,

		/// <summary>Local system uses a local area network to connect to the Internet.</summary>
		INTERNET_CONNECTION_LAN = 0x02,

		/// <summary>Local system uses a modem to connect to the Internet.</summary>
		INTERNET_CONNECTION_MODEM = 0x01,

		/// <summary>No longer used.</summary>
		INTERNET_CONNECTION_MODEM_BUSY = 0x08,

		/// <summary>Local system is in offline mode.</summary>
		INTERNET_CONNECTION_OFFLINE = 0x20,

		/// <summary>Local system uses a proxy server to connect to the Internet.</summary>
		INTERNET_CONNECTION_PROXY = 0x04,

		/// <summary>Local system has RAS installed.</summary>
		INTERNET_RAS_INSTALLED = 0x10,
	}

	/// <summary>Flags related to cookies.</summary>
	[PInvokeData("wininet.h")]
	[Flags]
	public enum INTERNET_COOKIE
	{
		/// <summary></summary>
		INTERNET_COOKIE_IS_SECURE = 0x00000001,

		/// <summary></summary>
		INTERNET_COOKIE_IS_SESSION = 0x00000002,

		/// <summary>Retrieves only third-party cookies if policy explicitly allows all cookies for the specified URL to be retrieved.</summary>
		INTERNET_COOKIE_THIRD_PARTY = 0x00000010,

		/// <summary></summary>
		INTERNET_COOKIE_PROMPT_REQUIRED = 0x00000020,

		/// <summary></summary>
		INTERNET_COOKIE_EVALUATE_P3P = 0x00000040,

		/// <summary></summary>
		INTERNET_COOKIE_APPLY_P3P = 0x00000080,

		/// <summary></summary>
		INTERNET_COOKIE_P3P_ENABLED = 0x00000100,

		/// <summary></summary>
		INTERNET_COOKIE_IS_RESTRICTED = 0x00000200,

		/// <summary></summary>
		INTERNET_COOKIE_IE6 = 0x00000400,

		/// <summary></summary>
		INTERNET_COOKIE_IS_LEGACY = 0x00000800,

		/// <summary></summary>
		INTERNET_COOKIE_NON_SCRIPT = 0x00001000,

		/// <summary>
		/// Enables the retrieval of cookies that are marked as "HTTPOnly". Do not use this flag if you expose a scriptable interface,
		/// because this has security implications. It is imperative that you use this flag only if you can guarantee that you will
		/// never expose the cookie to third-party code by way of an extensibility mechanism you provide. Version: Requires Internet
		/// Explorer 8.0 or later.
		/// </summary>
		INTERNET_COOKIE_HTTPONLY = 0x00002000,

		/// <summary></summary>
		INTERNET_COOKIE_HOST_ONLY = 0x00004000,

		/// <summary></summary>
		INTERNET_COOKIE_APPLY_HOST_ONLY = 0x00008000,

		/// <summary></summary>
		INTERNET_COOKIE_HOST_ONLY_APPLIED = 0x00080000,

		/// <summary></summary>
		INTERNET_COOKIE_SAME_SITE_STRICT = 0x00100000,

		/// <summary></summary>
		INTERNET_COOKIE_SAME_SITE_LAX = 0x00200000,

		/// <summary></summary>
		INTERNET_COOKIE_SAME_SITE_LEVEL_CROSS_SITE = 0x00400000,
	}

	/// <summary>Options for <see cref="InternetDial"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "b8ce748b-9879-4f68-aea1-32e2bfaee8ab")]
	[Flags]
	public enum INTERNET_DIAL
	{
		/// <summary>Forces an online Internet connection.</summary>
		INTERNET_AUTODIAL_FORCE_ONLINE = 0x01,

		/// <summary>Forces an unattended Internet dial-up.</summary>
		INTERNET_AUTODIAL_FORCE_UNATTENDED = 0x02,

		/// <summary>Ignores the "dial automatically" setting and forces the dialing user interface to be displayed.</summary>
		INTERNET_DIAL_FORCE_PROMPT = 0x2000,

		/// <summary>Shows the Work Offline button instead of the Cancel button in the dialing user interface.</summary>
		INTERNET_DIAL_SHOW_OFFLINE = 0x4000,

		/// <summary>
		/// Connects to the Internet through a modem, without displaying a user interface, if possible. Otherwise, the function will
		/// wait for user input.
		/// </summary>
		INTERNET_DIAL_UNATTENDED = 0x8000,
	}

	/// <summary>Flags used for controlling connections</summary>
	[PInvokeData("WinInet.h")]
	[Flags]
	public enum INTERNET_FLAG : uint
	{
		/// <summary>retrieve the original item</summary>
		INTERNET_FLAG_RELOAD = 0x80000000,

		/// <summary>FTP/gopher find: receive the item as raw (structured) data</summary>
		INTERNET_FLAG_RAW_DATA = 0x40000000,

		/// <summary>FTP: use existing InternetConnect handle for server if possible</summary>
		INTERNET_FLAG_EXISTING_CONNECT = 0x20000000,

		/// <summary>this request is asynchronous (where supported)</summary>
		INTERNET_FLAG_ASYNC = 0x10000000,

		/// <summary>used for FTP connections</summary>
		INTERNET_FLAG_PASSIVE = 0x08000000,

		/// <summary>don't write this item to the cache</summary>
		INTERNET_FLAG_NO_CACHE_WRITE = 0x04000000,

		/// <summary>don't write this item to the cache</summary>
		INTERNET_FLAG_DONT_CACHE = 0x04000000,

		/// <summary>make this item persistent in cache</summary>
		INTERNET_FLAG_MAKE_PERSISTENT = 0x02000000,

		/// <summary>use offline semantics</summary>
		INTERNET_FLAG_FROM_CACHE = 0x01000000,

		/// <summary>use offline semantics</summary>
		INTERNET_FLAG_OFFLINE = 0x01000000,

		/// <summary>use PCT/SSL if applicable (HTTP)</summary>
		INTERNET_FLAG_SECURE = 0x00800000,

		/// <summary>use keep-alive semantics</summary>
		INTERNET_FLAG_KEEP_CONNECTION = 0x00400000,

		/// <summary>don't handle redirections automatically</summary>
		INTERNET_FLAG_NO_AUTO_REDIRECT = 0x00200000,

		/// <summary>do background read prefetch</summary>
		INTERNET_FLAG_READ_PREFETCH = 0x00100000,

		/// <summary>no automatic cookie handling</summary>
		INTERNET_FLAG_NO_COOKIES = 0x00080000,

		/// <summary>no automatic authentication handling</summary>
		INTERNET_FLAG_NO_AUTH = 0x00040000,

		/// <summary>return cache file if net request fails</summary>
		INTERNET_FLAG_CACHE_IF_NET_FAIL = 0x00010000,

		/// <summary>ex: https:// to http://</summary>
		INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP = 0x00008000,

		/// <summary>ex: http:// to https://</summary>
		INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS = 0x00004000,

		/// <summary>expired X509 Cert.</summary>
		INTERNET_FLAG_IGNORE_CERT_DATE_INVALID = 0x00002000,

		/// <summary>bad common name in X509 Cert.</summary>
		INTERNET_FLAG_IGNORE_CERT_CN_INVALID = 0x00001000,

		/// <summary>asking wininet to update an item if it is newer</summary>
		INTERNET_FLAG_RESYNCHRONIZE = 0x00000800,

		/// <summary>asking wininet to do hyperlinking semantic which works right for scripts</summary>
		INTERNET_FLAG_HYPERLINK = 0x00000400,

		/// <summary>no cookie popup</summary>
		INTERNET_FLAG_NO_UI = 0x00000200,

		/// <summary>asking wininet to add "pragma: no-cache"</summary>
		INTERNET_FLAG_PRAGMA_NOCACHE = 0x00000100,

		/// <summary>ok to perform lazy cache-write</summary>
		INTERNET_FLAG_CACHE_ASYNC = 0x00000080,

		/// <summary>this is a forms submit</summary>
		INTERNET_FLAG_FORMS_SUBMIT = 0x00000040,

		/// <summary>fwd-back button op</summary>
		INTERNET_FLAG_FWD_BACK = 0x00000020,

		/// <summary>need a file for this request</summary>
		INTERNET_FLAG_NEED_FILE = 0x00000010,

		/// <summary>need a file for this request</summary>
		INTERNET_FLAG_MUST_CACHE_REQUEST = 0x00000010,

		/// <summary/>
		INTERNET_FLAG_TRANSFER_ASCII = 0x00000001,

		/// <summary/>
		INTERNET_FLAG_TRANSFER_BINARY = 0x00000002,
	}

	/// <summary>Option to be queried or set within <see cref="INTERNET_PER_CONN_OPTION"/> structure.</summary>
	[PInvokeData("WinInet.h")]
	public enum INTERNET_PER_CONN_OPTION_ID
	{
		/// <summary>Sets or retrieves the connection type.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_FLAGS = 1,

		/// <summary>Sets or retrieves a string containing the proxy servers.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_PROXY_SERVER = 2,

		/// <summary>Sets or retrieves a string containing the URLs that do not use the proxy server.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_PROXY_BYPASS = 3,

		/// <summary>Sets or retrieves a string containing the URL to the automatic configuration script.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_AUTOCONFIG_URL = 4,

		/// <summary>Sets or retrieves the automatic discovery settings.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_AUTODISCOVERY_FLAGS = 5,

		/// <summary>
		/// Chained autoconfig URL. Used when the primary autoconfig URL points to an INS file that sets a second autoconfig URL for
		/// proxy information.
		/// </summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_AUTOCONFIG_SECONDARY_URL = 6,

		/// <summary>The number of minutes until automatic refresh of autoconfig URL by autodiscovery.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_AUTOCONFIG_RELOAD_DELAY_MINS = 7,

		/// <summary>Read only option. Returns the time the last known good autoconfig URL was found using autodiscovery.</summary>
		[CorrespondingType(typeof(FILETIME), CorrespondingAction.Get)]
		INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_TIME = 8,

		/// <summary>Read only option. Returns the last known good URL found using autodiscovery.</summary>
		[CorrespondingType(typeof(string), CorrespondingAction.Get)]
		INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_URL = 9,

		/// <summary>Sets or retrieves the connection type.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		INTERNET_PER_CONN_FLAGS_UI = 10
	}

	/// <summary>Transmission Control Protocol/Internet Protocol (TCP/IP) port on the server.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "42b5d733-dccd-4c9d-8820-e358e033077c")]
	public enum INTERNET_PORT : ushort
	{
		/// <summary>Uses the default port for the service specified by dwService.</summary>
		INTERNET_INVALID_PORT_NUMBER = 0,

		/// <summary>Uses the default port for FTP servers (port 21).</summary>
		INTERNET_DEFAULT_FTP_PORT = 21,

		/// <summary>Uses the default port for Gopher servers (port 70).</summary>
		INTERNET_DEFAULT_GOPHER_PORT = 70,

		/// <summary>Uses the default port for HTTP servers (port 80).</summary>
		INTERNET_DEFAULT_HTTP_PORT = 80,

		/// <summary>Uses the default port for Secure Hypertext Transfer Protocol (HTTPS) servers (port 443).</summary>
		INTERNET_DEFAULT_HTTPS_PORT = 443,

		/// <summary>Uses the default port for SOCKS firewall servers (port 1080).</summary>
		INTERNET_DEFAULT_SOCKS_PORT = 1080,
	}

	/// <summary>RFC formats.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "b52ba402-bad1-4005-b9d0-7630194272d1")]
	public enum INTERNET_RFC
	{
		/// <summary>RFC 1123 format.</summary>
		INTERNET_RFC1123_FORMAT = 0
	}

	/// <summary>Defines the flags used with the <c>nScheme</c> member of the URL_COMPONENTS structure.</summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ne-wininet-internet_scheme typedef enum { INTERNET_SCHEME_PARTIAL,
	// INTERNET_SCHEME_UNKNOWN, INTERNET_SCHEME_DEFAULT, INTERNET_SCHEME_FTP, INTERNET_SCHEME_GOPHER, INTERNET_SCHEME_HTTP,
	// INTERNET_SCHEME_HTTPS, INTERNET_SCHEME_FILE, INTERNET_SCHEME_NEWS, INTERNET_SCHEME_MAILTO, INTERNET_SCHEME_SOCKS,
	// INTERNET_SCHEME_JAVASCRIPT, INTERNET_SCHEME_VBSCRIPT, INTERNET_SCHEME_RES, INTERNET_SCHEME_FIRST, INTERNET_SCHEME_LAST } *LPINTERNET_SCHEME;
	[PInvokeData("wininet.h", MSDNShortId = "640d0b62-a44f-4115-be27-9976da4bc73a")]
	public enum INTERNET_SCHEME
	{
		/// <summary>Partial URL.</summary>
		INTERNET_SCHEME_PARTIAL = -2,

		/// <summary>Unknown URL scheme.</summary>
		INTERNET_SCHEME_UNKNOWN = -1,

		/// <summary>Default URL scheme.</summary>
		INTERNET_SCHEME_DEFAULT = 0,

		/// <summary>FTP URL scheme (ftp:).</summary>
		INTERNET_SCHEME_FTP,

		/// <summary>Gopher URL scheme (gopher:).</summary>
		INTERNET_SCHEME_GOPHER,

		/// <summary>HTTP URL scheme (http:).</summary>
		INTERNET_SCHEME_HTTP,

		/// <summary>HTTPS URL scheme (https:).</summary>
		INTERNET_SCHEME_HTTPS,

		/// <summary>File URL scheme (file:).</summary>
		INTERNET_SCHEME_FILE,

		/// <summary>News URL scheme (news:).</summary>
		INTERNET_SCHEME_NEWS,

		/// <summary>Mail URL scheme (mailto:).</summary>
		INTERNET_SCHEME_MAILTO,

		/// <summary>Socks URL scheme (socks:).</summary>
		INTERNET_SCHEME_SOCKS,

		/// <summary>JScript URL scheme (javascript:).</summary>
		INTERNET_SCHEME_JAVASCRIPT,

		/// <summary>VBScript URL scheme (vbscript:).</summary>
		INTERNET_SCHEME_VBSCRIPT,

		/// <summary>Resource URL scheme (res:).</summary>
		INTERNET_SCHEME_RES,

		/// <summary>Lowest known scheme value.</summary>
		INTERNET_SCHEME_FIRST = INTERNET_SCHEME_FTP,

		/// <summary>Highest known scheme value.</summary>
		INTERNET_SCHEME_LAST = INTERNET_SCHEME_RES,
	}

	/// <summary>Options for the <see cref="InternetOpen(string, InternetOpenType, string, string, InternetApiFlags)"/> function.</summary>
	[PInvokeData("WinInet.h")]
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
		/// and other information about the resource is not checked. If the requested item is not found in the Internet cache, the
		/// system attempts to locate the resource on the network. This value was introduced in Microsoft Internet Explorer 5 and is
		/// associated with the Forward and Back button operations of Internet Explorer.
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
		/// Disables checking of SSL/PCT-based certificates that are returned from the server against the host name given in the
		/// request. WinINet uses a simple check against certificates by comparing for matching host names and simple wildcarding rules.
		/// This flag can be used by HttpOpenRequest and InternetOpenUrl (for HTTP requests).
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
		/// if the call is made through a CERN proxy, InternetOpenUrl returns the HTML version of the directory. Only the
		/// InternetOpenUrl function uses this flag.
		/// <para>
		/// Windows XP and Windows Server 2003 R2 and earlier: Also returns a GOPHER_FIND_DATA structure when retrieving Gopher
		/// directory information.
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
		/// https:// appears in the URL.The InternetConnect function uses this flag for HTTP connections; all the request handles
		/// created under this connection will inherit this flag.
		/// </summary>
		INTERNET_FLAG_SECURE = 0x00800000,

		/// <summary>Transfers file as ASCII (FTP only). This flag can be used by FtpOpenFile, FtpGetFile, and FtpPutFile.</summary>
		INTERNET_FLAG_TRANSFER_ASCII = 0x00000001,

		/// <summary>Transfers file as binary (FTP only). This flag can be used by FtpOpenFile, FtpGetFile, and FtpPutFile.</summary>
		INTERNET_FLAG_TRANSFER_BINARY = 0x00000002,

		/// <summary>
		/// Indicates that no callbacks should be made for that API. This is used for the dxContext parameter of the functions that
		/// allow asynchronous operations.
		/// </summary>
		INTERNET_NO_CALLBACK = 0x00000000,

		/// <summary>
		/// Sets an HTTP request object such that it will not logon to origin servers, but will perform automatic logon to HTTP proxy
		/// servers. This option differs from the Request flag INTERNET_FLAG_NO_AUTH, which prevents authentication to both proxy
		/// servers and origin servers. Setting this mode will suppress the use of any credential material (either previously provided
		/// username/password or client SSL certificate) when communicating with an origin server. However, if the request must transit
		/// via an authenticating proxy, WinINet will still perform automatic authentication to the HTTP proxy per the Intranet Zone
		/// settings for the user. The default Intranet Zone setting is to permit automatic logon using the user’s default credentials.
		/// To ensure suppression of all identifying information, the caller should combine INTERNET_OPTION_SUPPRESS_SERVER_AUTH with
		/// the INTERNET_FLAG_NO_COOKIES request flag. This option may only be set on request objects before they have been sent.
		/// Attempts to set this option after the request has been sent will return ERROR_INTERNET_INCORRECT_HANDLE_STATE. No buffer is
		/// required for this option. This is used by InternetSetOption on handles returned by HttpOpenRequest only. Version: Requires
		/// Internet Explorer 8.0 or later.
		/// </summary>
		INTERNET_OPTION_SUPPRESS_SERVER_AUTH = 104,

		/// <summary>Forces asynchronous operations.</summary>
		WININET_API_FLAG_ASYNC = 0x00000001,

		/// <summary>Forces synchronous operations.</summary>
		WININET_API_FLAG_SYNC = 0x00000004,

		/// <summary>Forces the API to use the context value, even if it is set to zero.</summary>
		WININET_API_FLAG_USE_CONTEXT = 0x00000008
	}

	/// <summary>The <c>InternetCookieState</c> enumeration defines the state of the cookie.</summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ne-wininet-internetcookiestate typedef enum { COOKIE_STATE_UNKNOWN,
	// COOKIE_STATE_ACCEPT, COOKIE_STATE_PROMPT, COOKIE_STATE_LEASH, COOKIE_STATE_DOWNGRADE, COOKIE_STATE_REJECT, COOKIE_STATE_MAX } ;
	[PInvokeData("wininet.h", MSDNShortId = "3f43f492-3133-4cbd-9ab9-3c9600ef5263")]
	public enum InternetCookieState
	{
		/// <summary>Reserved.</summary>
		COOKIE_STATE_UNKNOWN,

		/// <summary>The cookies are accepted.</summary>
		COOKIE_STATE_ACCEPT,

		/// <summary>The user is prompted to accept or deny the cookie.</summary>
		COOKIE_STATE_PROMPT,

		/// <summary>Cookies are accepted only in the first-party context.</summary>
		COOKIE_STATE_LEASH,

		/// <summary>Cookies are accepted and become session cookies.</summary>
		COOKIE_STATE_DOWNGRADE,

		/// <summary>The cookies are rejected.</summary>
		COOKIE_STATE_REJECT,

		/// <summary>Same as COOKIE_STATE_REJECT.</summary>
		COOKIE_STATE_MAX,
	}

	/// <summary>Values available for the <see cref="InternetOptionFlags.INTERNET_OPTION_ERROR_MASK"/> value.</summary>
	[PInvokeData("WinInet.h")]
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
	[PInvokeData("WinInet.h")]
	public enum InternetOpenType
	{
		/// <summary>Resolves all host names locally.</summary>
		INTERNET_OPEN_TYPE_DIRECT = 1,

		/// <summary>Retrieves the proxy or direct configuration from the registry.</summary>
		INTERNET_OPEN_TYPE_PRECONFIG = 0,

		/// <summary>
		/// Retrieves the proxy or direct configuration from the registry and prevents the use of a startup Microsoft JScript or
		/// Internet Setup (INS) file.
		/// </summary>
		INTERNET_OPEN_TYPE_PRECONFIG_WITH_NO_AUTOPROXY = 4,

		/// <summary>
		/// Passes requests to the proxy unless a proxy bypass list is supplied and the name to be resolved bypasses the proxy. In this
		/// case, the function uses INTERNET_OPEN_TYPE_DIRECT.
		/// </summary>
		INTERNET_OPEN_TYPE_PROXY = 3
	}

	/// <summary>Error masks for internet functions.</summary>
	[PInvokeData("WinInet.h")]
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
	[PInvokeData("WinInet.h")]
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
		[CorrespondingType(typeof(InternetStatusCallback))]
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
		/// For a request where WinInet decompressed the server’s supplied Content-Encoding, retrieves the server-reported
		/// Content-Length of the response body as a ULONGLONG. Supported in Windows 10, version 1507 and later.
		/// </summary>
		[CorrespondingType(typeof(ulong), CorrespondingAction.Get)]
		INTERNET_OPTION_COMPRESSED_CONTENT_LENGTH = 147,

		/// <summary>Not implemented.</summary>
		[CorrespondingType(CorrespondingAction.Exception)]
		INTERNET_OPTION_CONNECT_BACKOFF = 4,

		/// <summary>
		/// Sets or retrieves an unsigned long integer value that contains the number of times WinINet attempts to resolve and connect
		/// to a host. It only attempts once per IP address. For example, if you attempt to connect to a multihome host that has ten IP
		/// addresses and INTERNET_OPTION_CONNECT_RETRIES is set to seven, WinINet only attempts to resolve and connect to the first
		/// seven IP addresses. Conversely, given the same set of ten IP addresses, if INTERNET_OPTION_CONNECT_RETRIES is set to 20,
		/// WinINet attempts each of the ten only once. If a host has only one IP address and the first connection attempt fails, there
		/// are no further attempts. If a connection attempt still fails after the specified number of attempts, the request is
		/// canceled. The default value for INTERNET_OPTION_CONNECT_RETRIES is five attempts. This option can be used on any HINTERNET
		/// handle, including a NULL handle. It is used by InternetQueryOption and InternetSetOption.
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
		/// Gets/sets a BOOL indicating whether non-ASCII characters in the query string should be percent-encoded. The default is
		/// FALSE. Supported in Windows 8.1 and later.
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
		/// Retrieves an unsigned long integer value that contains a Winsock error code mapped to the ERROR_INTERNET_ error messages
		/// last returned in this thread context. This option is used on a NULLHINTERNET handle by InternetQueryOption.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		INTERNET_OPTION_EXTENDED_ERROR = 24,

		/// <summary>
		/// Sets or retrieves a1n unsigned long integer value that contains the amount of time the system should wait for a response to
		/// a network request before checking the cache for a copy of the resource. If a network request takes longer than the time
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
		/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per HTTP/1.0
		/// server. This is used by InternetQueryOption and InternetSetOption. This option is only valid in Internet Explorer 5 and later.
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
		/// Opt-in for weak signatures (e.g. SHA-1) to be treated as insecure. This will instruct WinInet to call
		/// CertGetCertificateChain using the CERT_CHAIN_OPT_IN_WEAK_SIGNATURE parameter.
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
		/// Sets or retrieves a string value that contains the password used to access the proxy. This is used by InternetQueryOption
		/// and InternetSetOption. This option can be set on the handle returned by InternetConnect or HttpOpenRequest.
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
		/// Starts a new cache session for the process. No buffer is required. This is used by InternetSetOption. This option is
		/// reserved for internal use only.
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
		/// Retrieves an unsigned long integer value that contains the bit size of the encryption key. The larger the number, the
		/// greater the encryption strength used. This is used by InternetQueryOption. Be aware that the data retrieved this way relates
		/// to a transaction that has already occurred, whose security level can no longer be changed.
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
		/// Sets or retrieves the user agent string on handles supplied by InternetOpen and used in subsequent HttpSendRequest
		/// functions, as long as it is not overridden by a header added by HttpAddRequestHeaders or HttpSendRequest. This is used by
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
		/// Retrieves an INTERNET_VERSION_INFO structure that contains the version number of WinInet.dll. This option can be used on a
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
		/// option on the request, or connection handle, when IDN is disabled, specifies a code page encoding scheme for the host
		/// portion of the URL. The lpBuffer parameter in the call to InternetSetOption contains the desired DBCS code page. If no code
		/// page is specified in lpBuffer, WinINet uses the default system code page (CP_ACP). Note: This option is ignored if IDN is
		/// not disabled. For more information about how to disable IDN, see the INTERNET_OPTION_IDN option.
		/// <para><c>Windows XP with SP2 and Windows Server 2003 with SP1:</c> This flag is not supported.</para>
		/// <para><c>Version:</c> Requires Internet Explorer 7.0.</para>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Set)]
		INTERNET_OPTION_CODEPAGE = 68,

		/// <summary>
		/// By default, the path portion of the URL is UTF8 encoded. The WinINet API performs escape character (%) encoding on the
		/// high-bit characters. Setting this option on the request, or connection handle, disables the UTF8 encoding and sets a
		/// specific code page. The lpBuffer parameter in the call to InternetSetOption contains the desired DBCS codepage for the path.
		/// If no code page is specified in lpBuffer, WinINet uses the default CP_UTF8.
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
		/// Sets or retrieves an unsigned long integer value, in milliseconds, that contains the time-out value to send a request for
		/// the data channel of an FTP transaction. If the send takes longer than this time-out value, the send is canceled. This option
		/// can be used on any HINTERNET handle, including a NULL handle. It is used by InternetQueryOption and InternetSetOption. This
		/// flag has no impact on HTTP functionality.
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
		/// handle. This is used by InternetQueryOption and InternetSetOption. On Windows 7, Windows Server 2008 R2, and later, the
		/// value of the dwMinorVersion member in the HTTP_VERSION_INFO structure is overridden by Internet Explorer settings.
		/// EnableHttp1_1 is a registry value under HKLM\Software\Microsoft\InternetExplorer\AdvacnedOptions\HTTP\GENABLE controlled by
		/// Internet Options set in Internet Explorer for the system. The EnableHttp1_1 value defaults to 1. The HTTP_VERSION_INFO
		/// structure is ignored for any HTTP version less than 1.1 if EnableHttp1_1 is set to 1.
		/// </summary>
		[CorrespondingType(typeof(INTERNET_VERSION_INFO))]
		INTERNET_OPTION_HTTP_VERSION = 59,

		/// <summary>
		/// By default, the host or authority portion of the URL is encoded according to the IDN specification for both direct and proxy
		/// connections. This option can be used on the request, or connection handle to enable or disable IDN. When IDN is disabled,
		/// WinINet uses the system codepage to encode the host or authority portion of the URL. To disable IDN host conversion, set the
		/// lpBuffer parameter in the call to InternetSetOption to zero. To enable IDN conversion on only the direct connection, specify
		/// INTERNET_FLAG_IDN_DIRECT in the lpBuffer parameter in the call to InternetSetOption. To enable IDN conversion on only the
		/// proxy connection, specify INTERNET_FLAG_IDN_PROXY in the lpBuffer parameter in the call to InternetSetOption. Windows XP
		/// with SP2 and Windows Server 2003 with SP1: This flag is not supported.
		/// Version:  Requires Internet Explorer 7.0.
		/// </summary>
		[CorrespondingType(typeof(InternetOptionIDNFlags), CorrespondingAction.Set)]
		INTERNET_OPTION_IDN = 102,

		/// <summary>
		/// Sets or retrieves an unsigned long integer value that contains the maximum number of connections allowed per CERN proxy.
		/// When this option is set or retrieved, the hInternet parameter must set to a null handle value. A null handle value indicates
		/// that the option should be set or queried for the current process. When calling InternetSetOption with this option, all
		/// existing proxy objects will receive the new value. This value is limited to a range of 2 to 128, inclusive. <c>Version:</c>
		/// Requires Internet Explorer 8.0.
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
		/// is recommended that INTERNET_OPTION_PER_CONNECTION_OPTION be used instead of INTERNET_OPTION_PROXY. For more information,
		/// see KB article 226473.
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
		/// Sets or retrieves an unsigned long integer value, in milliseconds, that contains the time-out value to send a request. If
		/// the send takes longer than this time-out value, the send is canceled. This option can be used on any HINTERNET handle,
		/// including a NULL handle. It is used by InternetQueryOption and InternetSetOption. When used in reference to an FTP
		/// transaction, this option refers to the control channel.
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
		/// servers. This option differs from the Request flag INTERNET_FLAG_NO_AUTH, which prevents authentication to both proxy
		/// servers and origin servers. Setting this mode will suppress the use of any credential material (either previously provided
		/// username/password or client SSL certificate) when communicating with an origin server. However, if the request must transit
		/// via an authenticating proxy, WinINet will still perform automatic authentication to the HTTP proxy per the Intranet Zone
		/// settings for the user. The default Intranet Zone setting is to permit automatic logon using the user’s default credentials.
		/// To ensure suppression of all identifying information, the caller should combine INTERNET_OPTION_SUPPRESS_SERVER_AUTH with
		/// the INTERNET_FLAG_NO_COOKIES request flag. This option may only be set on request objects before they have been sent.
		/// Attempts to set this option after the request has been sent will return ERROR_INTERNET_INCORRECT_HANDLE_STATE. No buffer is
		/// required for this option. This is used by InternetSetOption on handles returned by HttpOpenRequest only.
		/// Version:  Requires Internet Explorer 8.0 or later.
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Set)]
		INTERNET_OPTION_SUPPRESS_SERVER_AUTH = 104,
	}

	/// <summary>Handle types.</summary>
	[PInvokeData("WinInet.h")]
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

	/// <summary>IDN flags</summary>
	[PInvokeData("WinInet.h")]
	[Flags]
	public enum InternetOptionIDNFlags
	{
		/// <summary>IDN enabled for direct connections</summary>
		INTERNET_FLAG_IDN_DIRECT = 0x00000001,

		/// <summary>IDN enabled for proxy</summary>
		INTERNET_FLAG_IDN_PROXY = 0x00000002
	}

	/// <summary>Request flags.</summary>
	[PInvokeData("WinInet.h")]
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

	/// <summary>Security flags.</summary>
	[PInvokeData("WinInet.h")]
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

	/// <summary>Behavior suppression flags.</summary>
	[PInvokeData("WinInet.h")]
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
		/// Suppresses the persistence of cookies, even if the server has specified them as persistent. <c>Version:</c> Requires
		/// Internet Explorer 8.0 or later.
		/// </summary>
		INTERNET_SUPPRESS_COOKIE_PERSIST = 3,

		/// <summary>
		/// Disables the INTERNET_SUPPRESS_COOKIE_PERSIST suppression, re-enabling the persistence of cookies. Any previously suppressed
		/// cookies will not become persistent. <c>Version:</c> Requires Internet Explorer 8.0 or later.
		/// </summary>
		INTERNET_SUPPRESS_COOKIE_PERSIST_RESET = 4
	}

	/// <summary>Type of service to access in <see cref="InternetConnect"/>.</summary>
	[PInvokeData("WinInet.h")]
	public enum InternetService
	{
		/// <summary>FTP service.</summary>
		INTERNET_SERVICE_FTP = 1,

		/// <summary>Gopher service. <note type="note">Windows XP and Windows Server 2003 R2 and earlier only.</note></summary>
		INTERNET_SERVICE_GOPHER = 2,

		/// <summary>HTTP service.</summary>
		INTERNET_SERVICE_HTTP = 3
	}

	/// <summary>Values passed using the <see cref="InternetStatusCallback"/> delegate.</summary>
	[PInvokeData("WinInet.h")]
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

	/// <summary>Values passed using the <see cref="InternetStatusCallback"/> delegate.</summary>
	[PInvokeData("WinInet.h")]
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
		/// Successfully found the IP address of the name contained in lpvStatusInformation. The lpvStatusInformation parameter points
		/// to a PCTSTR containing the host name.
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

	/// <summary>Flags for <see cref="InternetReadFileEx"/>.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "04e7bb7e-d925-41fd-8333-3cb443a04c5b")]
	public enum IRF : uint
	{
		/// <summary>Identical to WININET_API_FLAG_ASYNC.</summary>
		IRF_ASYNC = 0x01,

		/// <summary>Identical to WININET_API_FLAG_SYNC.</summary>
		IRF_SYNC = 0x04,

		/// <summary>Identical to WININET_API_FLAG_USE_CONTEXT.</summary>
		IRF_USE_CONTEXT = 0x08,

		/// <summary>
		/// Do not wait for data. If there is data available, the function returns either the amount of data requested or the amount of
		/// data available (whichever is smaller).
		/// </summary>
		IRF_NO_WAIT = 0x08,
	}

	/// <summary>Values for INTERNET_PER_CONN_AUTODISCOVERY_FLAGS.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "NS:wininet.__unnamed_struct_3")]
	[Flags]
	public enum PER_CONN_AUTODISCOVERY_FLAGS : uint
	{
		/// <summary>The user has explicitly set the automatic detection.</summary>
		AUTO_PROXY_FLAG_USER_SET = 0x00000001,

		/// <summary>Always automatically detect settings.</summary>
		AUTO_PROXY_FLAG_ALWAYS_DETECT = 0x00000002,

		/// <summary>Automatic detection has been run at least once on this connection.</summary>
		AUTO_PROXY_FLAG_DETECTION_RUN = 0x00000004,

		/// <summary>
		/// The setting was migrated from a Microsoft Internet Explorer 4.0 installation, and automatic detection should be attempted once.
		/// </summary>
		AUTO_PROXY_FLAG_MIGRATED = 0x00000008,

		/// <summary>Do not allow the caching of the result of the automatic proxy configuration script.</summary>
		AUTO_PROXY_FLAG_DONT_CACHE_PROXY_RESULT = 0x00000010,

		/// <summary>
		/// Indicates that the cached results of the automatic proxy configuration script should be used, instead of actually running
		/// the script, unless the cached file has expired.
		/// </summary>
		AUTO_PROXY_FLAG_CACHE_INIT_RUN = 0x00000020,

		/// <summary>Not currently supported.</summary>
		AUTO_PROXY_FLAG_DETECTION_SUSPECT = 0x00000040,
	}

	/// <summary>Values for INTERNET_PER_CONN_FLAGS.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "NS:wininet.__unnamed_struct_3")]
	[Flags]
	public enum PER_CONN_FLAGS : uint
	{
		/// <summary>The connection does not use a proxy server.</summary>
		PROXY_TYPE_DIRECT = 0x00000001,

		/// <summary>The connection uses an explicitly set proxy server.</summary>
		PROXY_TYPE_PROXY = 0x00000002,

		/// <summary>The connection downloads and processes an automatic configuration script at a specified URL.</summary>
		PROXY_TYPE_AUTO_PROXY_URL = 0x00000004,

		/// <summary>The connection automatically detects settings.</summary>
		PROXY_TYPE_AUTO_DETECT = 0x00000008,
	}

	/// <summary>Privacy template for a URLL zone and type.</summary>
	[PInvokeData("wininet.h")]
	public enum PrivacyTemplate
	{
		/// <summary>This is the same as Block All Cookies on the Privacy Preferences slider bar in Internet Options.</summary>
		PRIVACY_TEMPLATE_NO_COOKIES = 0,

		/// <summary>This is the same as High on the Privacy Preferences slider bar in Internet Options.</summary>
		PRIVACY_TEMPLATE_HIGH = 1,

		/// <summary>This is the same as Medium_High on the Privacy Preferences slider bar in Internet Options.</summary>
		PRIVACY_TEMPLATE_MEDIUM_HIGH = 2,

		/// <summary>This is the same as Medium on the Privacy Preferences slider bar in Internet Options.</summary>
		PRIVACY_TEMPLATE_MEDIUM = 3,

		/// <summary>This is the same as Low on the Privacy Preferences slider bar in Internet Options.</summary>
		PRIVACY_TEMPLATE_MEDIUM_LOW = 4,

		/// <summary>This is the same as Accept All Cookies on the Privacy Preferences slider bar in Internet Options.</summary>
		PRIVACY_TEMPLATE_LOW = 5,

		/// <summary>User-defined. See How to Create a Customized Privacy Import File to understand how to set custom privacy settings.</summary>
		PRIVACY_TEMPLATE_CUSTOM = 100,

		/// <summary>
		/// User-defined. Advanced options are set in the Advanced Privacy Settings dialog reachable from the Privacy tab in Internet Options.
		/// </summary>
		PRIVACY_TEMPLATE_ADVANCED = 101,

		/// <summary>Same as PRIVACY_TEMPLATE_LOW.</summary>
		PRIVACY_TEMPLATE_MAX = PRIVACY_TEMPLATE_LOW,
	}

	/// <summary>Specifies the PrivacyType for which privacy settings are being set or retrieved.</summary>
	[PInvokeData("wininet.h")]
	public enum PrivacyType
	{
		/// <summary>Refers to privacy settings for first party cookies.</summary>
		PRIVACY_TYPE_FIRST_PARTY = 0,

		/// <summary>Refers to privacy settings for third party cookies.</summary>
		PRIVACY_TYPE_THIRD_PARTY = 1,
	}

	/// <summary>Automation detection type.</summary>
	[PInvokeData("wininet.h", MSDNShortId = "4e94ab0c-0f39-4e6e-a272-6beff61e97c6")]
	[Flags]
	public enum PROXY_AUTO_DETECT_TYPE
	{
		/// <summary>Use a Dynamic Host Configuration Protocol (DHCP) search to identify the proxy.</summary>
		PROXY_AUTO_DETECT_TYPE_DHCP = 1,

		/// <summary>Use a well qualified name search to identify the proxy.</summary>
		PROXY_AUTO_DETECT_TYPE_DNS_A = 2
	}

	/// <summary>Stores data in the specified file in the Internet cache and associates it with the specified URL.</summary>
	/// <param name="lpszUrlName">
	/// Pointer to a string variable that contains the source name of the cache entry. The name string must be unique and should not
	/// contain any escape characters.
	/// </param>
	/// <param name="lpszLocalFileName">
	/// Pointer to a string variable that contains the name of the local file that is being cached. This should be the same name as that
	/// returned by <c>CreateUrlCacheEntryA</c>.
	/// </param>
	/// <param name="ExpireTime">
	/// FILETIME structure that contains the expire date and time (in Greenwich mean time) of the file that is being cached. If the
	/// expire date and time is unknown, set this parameter to zero.
	/// </param>
	/// <param name="LastModifiedTime">
	/// FILETIME structure that contains the last modified date and time (in Greenwich mean time) of the URL that is being cached. If
	/// the last modified date and time is unknown, set this parameter to zero.
	/// </param>
	/// <param name="CacheEntryType">
	/// <para>
	/// A bitmask indicating the type of cache entry and its properties. The cache entry types include: history entries
	/// (URLHISTORY_CACHE_ENTRY), cookie entries (COOKIE_CACHE_ENTRY), and normal cached content (NORMAL_CACHE_ENTRY).
	/// </para>
	/// <para>This parameter can be zero or more of the following property flags, and cache type flags listed below.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>COOKIE_CACHE_ENTRY</term>
	/// <term>Cookie cache entry.</term>
	/// </item>
	/// <item>
	/// <term>EDITED_CACHE_ENTRY</term>
	/// <term>Cache entry file that has been edited externally. This cache entry type is exempt from scavenging.</term>
	/// </item>
	/// <item>
	/// <term>NORMAL_CACHE_ENTRY</term>
	/// <term>Normal cache entry; can be deleted to recover space for new entries.</term>
	/// </item>
	/// <item>
	/// <term>SPARSE_CACHE_ENTRY</term>
	/// <term>Partial response cache entry.</term>
	/// </item>
	/// <item>
	/// <term>STICKY_CACHE_ENTRY</term>
	/// <term>Sticky cache entry; exempt from scavenging.</term>
	/// </item>
	/// <item>
	/// <term>TRACK_OFFLINE_CACHE_ENTRY</term>
	/// <term>Not currently implemented.</term>
	/// </item>
	/// <item>
	/// <term>TRACK_ONLINE_CACHE_ENTRY</term>
	/// <term>Not currently implemented.</term>
	/// </item>
	/// <item>
	/// <term>URLHISTORY_CACHE_ENTRY</term>
	/// <term>Visited link cache entry.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpHeaderInfo">
	/// Pointer to the buffer that contains the header information. If this parameter is not <c>NULL</c>, the header information is
	/// treated as extended attributes of the URL that are returned in the <c>lpHeaderInfo</c> member of the INTERNET_CACHE_ENTRY_INFO structure.
	/// </param>
	/// <param name="cchHeaderInfo">
	/// Size of the header information, in <c>TCHARs</c>. If lpHeaderInfo is not <c>NULL</c>, this value is assumed to indicate the size
	/// of the buffer that stores the header information. An application can maintain headers as part of the data and provide
	/// cchHeaderInfo together with a <c>NULL</c> value for lpHeaderInfo.
	/// </param>
	/// <param name="lpszFileExtension">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="lpszOriginalUrl">Pointer to a string that contains the original URL, if redirection has occurred.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. The
	/// following are possible error values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_DISK_FULL</term>
	/// <term>The cache storage is full.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The specified local file is not found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The STICKY_CACHE_ENTRY type is used to make cache entries exempt from scavenging. The default exempt time for entries set using
	/// <c>CommitUrlCacheEntryA</c> is ten minutes. The exempt time can be changed by setting the expires time parameter in the
	/// INTERNET_CACHE_ENTRY_INFO structure in the call to the SetUrlCacheEntryInfo function.
	/// </para>
	/// <para>
	/// If the cache storage is full, <c>CommitUrlCacheEntryA</c> invokes cache cleanup to make space for this new file. If the cache
	/// entry already exists, the function overwrites the entry if it is not in use. An entry is in use when it has been retrieved with
	/// either RetrieveUrlCacheEntryStream or RetrieveUrlCacheEntryFile.
	/// </para>
	/// <para>
	/// Clients that add entries to the cache should set the headers to at least "HTTP/1.0 200 OK\r\n\r\n"; otherwise, Microsoft
	/// Internet Explorer and other client applications should disregard the entry.
	/// </para>
	/// <para>See Caching for example code calling <c>CreateUrlCacheEntryA</c>.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-commiturlcacheentrya BOOLAPI CommitUrlCacheEntryA( LPCSTR
	// lpszUrlName, LPCSTR lpszLocalFileName, FILETIME ExpireTime, FILETIME LastModifiedTime, DWORD CacheEntryType, LPBYTE lpHeaderInfo,
	// DWORD cchHeaderInfo, LPCSTR lpszFileExtension, LPCSTR lpszOriginalUrl );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "4bd21b30-cac5-482b-9826-b5a4ffeeebe9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitUrlCacheEntry(string lpszUrlName, string lpszLocalFileName, [Optional] FILETIME ExpireTime, [Optional] FILETIME LastModifiedTime,
		[Optional] CACHE_ENTRY_TYPE CacheEntryType, [Optional] string? lpHeaderInfo, [Optional] uint cchHeaderInfo, [Optional] string? lpszFileExtension, [Optional] string? lpszOriginalUrl);

	/// <summary>
	/// The <c>CreateMD5SSOHash</c> function obtains the default Microsoft Passport password for a specified account or realm, creates
	/// an MD5 hash from it using a specified wide-character challenge string, and returns the result as a string of hexadecimal digit bytes.
	/// </summary>
	/// <param name="pszChallengeInfo">Pointer to the wide-character challenge string to use for the MD5 hash.</param>
	/// <param name="pwszRealm">
	/// Pointer to a string that names a realm for which to obtain the password. This parameter is ignored unless pwszTarget is
	/// <c>NULL</c>. If both pwszTarget and pwszRealm are <c>NULL</c>, the default realm is used.
	/// </param>
	/// <param name="pwszTarget">
	/// Pointer to a string that names an account for which to obtain the password. If pwszTarget is <c>NULL</c>, the realm indicated by
	/// pwszRealm is used.
	/// </param>
	/// <param name="pbHexHash">
	/// Pointer to an output buffer into which the MD5 hash is returned in hex string format. This buffer must be at least 33 bytes long.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// Once the <c>CreateMD5SSOHash</c> function successfully obtains the Microsoft Passport password for the specified account or
	/// realm, it converts both the challenge string and the password from wide characters to multi-byte (generally 8-bit) characters,
	/// concatenates them, and uses the RSA library to generate an MD5 hash from the resulting key. It then converts the hash into a
	/// <c>null</c>-terminated string of 8-bit hexadecimal digits (using lowercase letters) which it places in the buffer pointed to by
	/// the pbHexHash parameter.
	/// </para>
	/// <para>
	/// The output buffer pointed to by pbHexHash must therefore be long enough to accept two bytes for each of the 16 bytes of the
	/// hash, plus a terminating <c>null</c> character, for a total of 33 bytes.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-createmd5ssohash BOOLAPI CreateMD5SSOHash( PWSTR
	// pszChallengeInfo, PWSTR pwszRealm, PWSTR pwszTarget, PBYTE pbHexHash );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "9aba22d7-a1a9-4b90-bfc6-78df8a8d0ce5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateMD5SSOHash([MarshalAs(UnmanagedType.LPWStr)] string pszChallengeInfo, [MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszRealm,
		[MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszTarget, byte[] pbHexHash);

	/// <summary>
	/// <para>
	/// Creates a cache container in the specified cache path to hold cache entries based on the specified name, cache prefix, and
	/// container type.
	/// </para>
	/// <note>This API is deprecated. Please use the Extensible Storage Engine instead.</note>
	/// </summary>
	/// <param name="Name">The name to give to the cache.</param>
	/// <param name="lpCachePrefix">The cache prefix to base the cache on.</param>
	/// <param name="lpszCachePath">The cache prefix to create the cache in.</param>
	/// <param name="KBCacheLimit">The size limit of the cache in whole kilobytes, or 0 for the default size.</param>
	/// <param name="dwContainerType">The container type to base the cache on.</param>
	/// <param name="dwOptions">This parameter is reserved and must be 0.</param>
	/// <param name="pvBuffer">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="cbBuffer">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/winineti/nf-winineti-createurlcachecontainera BOOLAPI
	// CreateUrlCacheContainerA( LPCSTR Name, LPCSTR lpCachePrefix, LPCSTR lpszCachePath, DWORD KBCacheLimit, DWORD dwContainerType,
	// DWORD dwOptions, LPVOID pvBuffer, LPDWORD cbBuffer );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winineti.h", MSDNShortId = "19b518cc-2f02-49c3-bedc-f5d633cc635d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateUrlCacheContainer(string Name, string lpCachePrefix, string lpszCachePath, [Optional] uint KBCacheLimit,
		INTERNET_CACHE_CONTAINER dwContainerType, uint dwOptions = 0, IntPtr pvBuffer = default, IntPtr cbBuffer = default);

	/// <summary>Creates a local file name for saving the cache entry based on the specified URL and the file name extension.</summary>
	/// <param name="lpszUrlName">
	/// Pointer to a string value that contains the name of the URL. The string must contain a value; an empty string will cause
	/// <c>CreateUrlCacheEntry</c> to fail. In addition, the string must not contain any escape characters.
	/// </param>
	/// <param name="dwExpectedFileSize">
	/// Expected size of the file needed to store the data that corresponds to the source entity, in <c>TCHARs</c>. If the expected size
	/// is unknown, set this value to zero.
	/// </param>
	/// <param name="lpszFileExtension">Pointer to a string value that contains an extension name of the file in the local storage.</param>
	/// <param name="lpszFileName">
	/// Pointer to a buffer that receives the file name. The buffer should be large enough to store the path of the created file (at
	/// least MAX_PATH characters in length).
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After <c>CreateUrlCacheEntry</c> is called, the application can write directly into the file in local storage. When the file is
	/// completely received, the caller should call CommitUrlCacheEntry to commit the entry in the cache.
	/// </para>
	/// <para>
	/// WinINet attempts to decode Unicode parameters according to the system code page. Applications should ensure that Unicode
	/// parameters are properly encoded for the system code page. Applications can set the system code page with InternetSetOption as
	/// shown in the following code example:
	/// </para>
	/// <para>If the Unicode parameter is not properly encoded to the system code page, WinINet attempts UTF8 decoding.</para>
	/// <para>
	/// When items are retrieved from the cache, the system code page that was used to place the item in the cache must match the
	/// current system code page for the user. For applications running under IE6 and earlier, if decoding for the system code page
	/// fails, WinINet attempts UTF8 decoding.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-createurlcacheentryw BOOLAPI CreateUrlCacheEntryW( LPCWSTR
	// lpszUrlName, DWORD dwExpectedFileSize, LPCWSTR lpszFileExtension, LPWSTR lpszFileName, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "9a58cf05-2306-4a0f-876d-85f5e91c5a2b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateUrlCacheEntry(string lpszUrlName, uint dwExpectedFileSize, string lpszFileExtension, StringBuilder lpszFileName, uint dwReserved = 0);

	/// <summary>Generates cache group identifications.</summary>
	/// <param name="dwFlags">
	/// Controls the creation of the cache group. This parameter can be set to CACHEGROUP_FLAG_GIDONLY, which causes
	/// <c>CreateUrlCacheGroup</c> to generate a unique GROUPID, but does not create a physical group.
	/// </param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// Returns a valid <c>GROUPID</c> if successful, or <c>FALSE</c> otherwise. To get specific error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-createurlcachegroup void CreateUrlCacheGroup( DWORD
	// dwFlags, LPVOID lpReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "bea0bc3b-75fb-4147-a4bd-f4290dfbf290")]
	public static extern long CreateUrlCacheGroup([Optional] CACHEGROUP_FLAG dwFlags, IntPtr lpReserved = default);

	/// <summary>
	/// <para>
	/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
	/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
	/// </para>
	/// <para>Deletes a cache container (which contains cache entries) based on the specified name.</para>
	/// </summary>
	/// <param name="Name">The name of the cache container to be deleted.</param>
	/// <param name="dwOptions">This parameter is reserved, and must be 0.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service nor when
	/// impersonating a security context. For server implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winineti/nf-winineti-deleteurlcachecontainera BOOLAPI
	// DeleteUrlCacheContainerA( LPCSTR Name, DWORD dwOptions );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winineti.h", MSDNShortId = "97F46974-9B20-46C6-B742-4BA5C60491DA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteUrlCacheContainer(string Name, uint dwOptions = 0);

	/// <summary>Removes the file associated with the source name from the cache, if the file exists.</summary>
	/// <param name="lpszUrlName">Pointer to a string that contains the name of the source that corresponds to the cache entry.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Possible
	/// error values include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The file is locked or in use. The entry is marked and deleted when the file is unlocked.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The file is not in the cache.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-deleteurlcacheentry BOOLAPI DeleteUrlCacheEntry( LPCSTR
	// lpszUrlName );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "bb765cba-6662-4dca-8f9f-3f35e37da28a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteUrlCacheEntry(string lpszUrlName);

	/// <summary>Releases the specified <c>GROUPID</c> and any associated state in the cache index file.</summary>
	/// <param name="GroupId">ID of the cache group to be released.</param>
	/// <param name="dwFlags">
	/// Controls the cache group deletion. This can be set to any member of the cache group constants. When this parameter is set to
	/// CACHEGROUP_FLAG_FLUSHURL_ONDELETE, it causes <c>DeleteUrlCacheGroup</c> to delete all of the cache entries associated with this
	/// group, unless the entry belongs to another group.
	/// </param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get specific error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-deleteurlcachegroup BOOLAPI DeleteUrlCacheGroup( GROUPID
	// GroupId, DWORD dwFlags, LPVOID lpReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "f1ff70db-36b7-4805-8f23-e3920acf0d11")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteUrlCacheGroup(long GroupId, CACHEGROUP_FLAG dwFlags, IntPtr lpReserved = default);

	/// <summary>Attempts to determine the location of a WPAD autoproxy script.</summary>
	/// <param name="pszAutoProxyUrl">Pointer to a buffer to receive the URL from which a WPAD autoproxy script can be downloaded.</param>
	/// <param name="cchAutoProxyUrl">Size of the buffer pointed to by lpszAutoProxyUrl, in bytes.</param>
	/// <param name="dwDetectFlags">
	/// <para>Automation detection type. This parameter can be one or both of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PROXY_AUTO_DETECT_TYPE_DHCP</term>
	/// <term>Use a Dynamic Host Configuration Protocol (DHCP) search to identify the proxy.</term>
	/// </item>
	/// <item>
	/// <term>PROXY_AUTO_DETECT_TYPE_DNS_A</term>
	/// <term>Use a well qualified name search to identify the proxy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-detectautoproxyurl BOOLAPI DetectAutoProxyUrl( PSTR
	// pszAutoProxyUrl, DWORD cchAutoProxyUrl, DWORD dwDetectFlags );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "4e94ab0c-0f39-4e6e-a272-6beff61e97c6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DetectAutoProxyUrl([MarshalAs(UnmanagedType.LPStr)] StringBuilder pszAutoProxyUrl, uint cchAutoProxyUrl, PROXY_AUTO_DETECT_TYPE dwDetectFlags);

	/// <summary>Closes the specified cache enumeration handle.</summary>
	/// <param name="hEnumHandle">Handle returned by a previous call to the FindFirstUrlCacheEntry function.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-findcloseurlcache BOOLAPI FindCloseUrlCache( HANDLE
	// hEnumHandle );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "54fc7bea-4cc1-4034-93c3-49ec88817648")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindCloseUrlCache(HFINDCACHE hEnumHandle);

	/// <summary>Begins the enumeration of the Internet cache.</summary>
	/// <param name="lpszUrlSearchPattern">
	/// A pointer to a string that contains the source name pattern to search for. This parameter can only be set to "cookie:",
	/// "visited:", or <c>NULL</c>. Set this parameter to "cookie:" to enumerate the cookies or "visited:" to enumerate the URL History
	/// entries in the cache. If this parameter is <c>NULL</c>, <c>FindFirstUrlCacheEntry</c> returns all content entries in the cache.
	/// </param>
	/// <param name="lpFirstCacheEntryInfo">Pointer to an INTERNET_CACHE_ENTRY_INFO structure.</param>
	/// <param name="lpcbCacheEntryInfo">
	/// Pointer to a variable that specifies the size of the lpFirstCacheEntryInfo buffer, in bytes. When the function returns, the
	/// variable contains the number of bytes copied to the buffer, or the required size needed to retrieve the cache entry, in bytes.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns a handle that the application can use in the FindNextUrlCacheEntry function to retrieve subsequent entries in the cache.
	/// If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// ERROR_INSUFFICIENT_BUFFER indicates that the size of lpFirstCacheEntryInfo as specified by lpdwFirstCacheEntryInfoBufferSize is
	/// not sufficient to contain all the information. The value returned in lpdwFirstCacheEntryInfoBufferSize indicates the buffer size
	/// necessary to contain all the information.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The handle returned from <c>FindFirstUrlCacheEntry</c> is used in all subsequent calls to FindNextUrlCacheEntry. At the end of
	/// the enumeration, the application should call FindCloseUrlCache.
	/// </para>
	/// <para>
	/// <c>FindFirstUrlCacheEntry</c> and FindNextUrlCacheEntry return variable size information. If ERROR_INSUFFICIENT_BUFFER is
	/// returned, the application should allocate a buffer of the size specified by lpdwFirstCacheEntryInfoBufferSize. For more
	/// information, see Using Buffers.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-findfirsturlcacheentrya void FindFirstUrlCacheEntryA(
	// LPCSTR lpszUrlSearchPattern, LPINTERNET_CACHE_ENTRY_INFOA lpFirstCacheEntryInfo, LPDWORD lpcbCacheEntryInfo );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "e8407284-846b-4080-b75b-4805330e0f95")]
	public static extern HFINDCACHE FindFirstUrlCacheEntry(string? lpszUrlSearchPattern, IntPtr lpFirstCacheEntryInfo, ref uint lpcbCacheEntryInfo);

	/// <summary>Initiates the enumeration of the cache groups in the Internet cache.</summary>
	/// <param name="dwFlags">This parameter is reserved and must be 0.</param>
	/// <param name="dwFilter">
	/// <para>Filters to be used. This parameter can be zero or one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CACHEGROUP_SEARCH_ALL</term>
	/// <term>Search all cache groups.</term>
	/// </item>
	/// <item>
	/// <term>CACHEGROUP_SEARCH_BYURL</term>
	/// <term>Not currently implemented.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpSearchCondition">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="dwSearchCondition">This parameter is reserved and must be 0.</param>
	/// <param name="lpGroupId">Pointer to the ID of the first cache group that matches the search criteria.</param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// Returns a valid handle to the first item in the enumeration if successful, or <c>NULL</c> otherwise. To get specific error
	/// information, call GetLastError. If the function finds no matching files, <c>GetLastError</c> returns ERROR_NO_MORE_FILES.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The handle returned from <c>FindFirstUrlCacheGroup</c> is used in subsequent calls to FindNextUrlCacheGroup. At the end of the
	/// enumeration, the application should call FindCloseUrlCache.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-findfirsturlcachegroup void FindFirstUrlCacheGroup( DWORD
	// dwFlags, DWORD dwFilter, LPVOID lpSearchCondition, DWORD dwSearchCondition, GROUPID *lpGroupId, LPVOID lpReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "a333cbc6-a880-4b1c-be0d-abb083909638")]
	public static extern HFINDCACHE FindFirstUrlCacheGroup([Optional] uint dwFlags, [Optional] CACHEGROUP_SEARCH dwFilter,
		[Optional] IntPtr lpSearchCondition, [Optional] uint dwSearchCondition, out long lpGroupId, [Optional] IntPtr lpReserved);

	/// <summary>Retrieves the next entry in the Internet cache.</summary>
	/// <param name="hEnumHandle">Handle to the enumeration obtained from a previous call to FindFirstUrlCacheEntry.</param>
	/// <param name="lpNextCacheEntryInfo">
	/// Pointer to an INTERNET_CACHE_ENTRY_INFO structure that receives information about the cache entry.
	/// </param>
	/// <param name="lpcbCacheEntryInfo">
	/// Pointer to a variable that specifies the size of the lpNextCacheEntryInfo buffer, in bytes. When the function returns, the
	/// variable contains the number of bytes copied to the buffer, or the size of the buffer required to retrieve the cache entry, in bytes.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Possible
	/// error values include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The size of lpNextCacheEntryInfo as specified by lpdwNextCacheEntryInfoBufferSize is not sufficient to contain all the
	/// information. The value returned in lpdwNextCacheEntryInfoBufferSize indicates the buffer size necessary to contain all the information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>The enumeration completed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Continue to call <c>FindNextUrlCacheEntry</c> until the last item in the cache is returned.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-findnexturlcacheentrya BOOLAPI FindNextUrlCacheEntryA(
	// HANDLE hEnumHandle, LPINTERNET_CACHE_ENTRY_INFOA lpNextCacheEntryInfo, LPDWORD lpcbCacheEntryInfo );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "776bf73e-00f3-46a1-a8c7-5eb365e9a518")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindNextUrlCacheEntry(HFINDCACHE hEnumHandle, IntPtr lpNextCacheEntryInfo, ref uint lpcbCacheEntryInfo);

	/// <summary>Retrieves the next cache group in a cache group enumeration started by FindFirstUrlCacheGroup.</summary>
	/// <param name="hFind">The cache group enumeration handle, which is returned by FindFirstUrlCacheGroup.</param>
	/// <param name="lpGroupId">Pointer to a variable that receives the cache group identifier.</param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get specific error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>Continue to call <c>FindNextUrlCacheGroup</c> until the last item in the cache is returned.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-findnexturlcachegroup BOOLAPI FindNextUrlCacheGroup( HANDLE
	// hFind, GROUPID *lpGroupId, LPVOID lpReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "f3cbe67c-c069-404c-8ca4-d18b35cc4c4a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FindNextUrlCacheGroup(HFINDCACHE hFind, out long lpGroupId, IntPtr lpReserved = default);

	/// <summary>Enumerates the Internet cache.</summary>
	/// <param name="lpszUrlSearchPattern">
	/// A pointer to a string that contains the source name pattern to search for. This parameter can only be set to "cookie:",
	/// "visited:", or <c>NULL</c>. Set this parameter to "cookie:" to enumerate the cookies or "visited:" to enumerate the URL History
	/// entries in the cache. If this parameter is <c>NULL</c>, <c>FindFirstUrlCacheEntry</c> returns all content entries in the cache.
	/// </param>
	/// <returns>
	/// An enumeration of <see cref="INTERNET_CACHE_ENTRY_INFO_MGD"/> structures which parallel the values in the native <see
	/// cref="INTERNET_CACHE_ENTRY_INFO"/> structure.
	/// </returns>
	public static IEnumerable<INTERNET_CACHE_ENTRY_INFO_MGD> FindUrlCacheEntries(string? lpszUrlSearchPattern = null)
	{
		using var mem = new SafeHGlobalHandle(1024);
		uint sz = mem.Size;
		var h = FindFirstUrlCacheEntry(lpszUrlSearchPattern, mem, ref sz);
		if (h.IsNull)
		{
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
			mem.Size = sz;
			h = FindFirstUrlCacheEntry(lpszUrlSearchPattern, mem, ref sz);
			if (h.IsNull) Win32Error.ThrowLastError();
		}
		yield return new INTERNET_CACHE_ENTRY_INFO_MGD(mem.ToStructure<INTERNET_CACHE_ENTRY_INFO>());
		try
		{
			do
			{
				if (!FindNextUrlCacheEntry(h, mem, ref sz))
				{
					var err = Win32Error.GetLastError();
					if (err == Win32Error.ERROR_NO_MORE_ITEMS)
						break;
					err.ThrowUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
					mem.Size = sz;
					if (!FindNextUrlCacheEntry(h, mem, ref sz))
						Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
				}
				yield return new INTERNET_CACHE_ENTRY_INFO_MGD(mem.ToStructure<INTERNET_CACHE_ENTRY_INFO>());
			} while (true);
		}
		finally
		{
			FindCloseUrlCache(h);
		}
	}

	/// <summary>Initiates the enumeration of the cache groups in the Internet cache.</summary>
	/// <returns>An enumeration of GROUPID values.</returns>
	public static IEnumerable<long> FindUrlCacheGroups()
	{
		var h = FindFirstUrlCacheGroup(lpGroupId: out var id);
		if (h.IsNull)
			Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
		var done = h.IsNull;
		while (!done)
		{
			yield return id;
			if (!FindNextUrlCacheGroup(h, out id))
			{
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NO_MORE_ITEMS);
				done = true;
			}
		}
	}

	/// <summary>The <c>FtpCommand</c> function sends commands directly to an FTP server.</summary>
	/// <param name="hConnect">A handle returned from a call to InternetConnect.</param>
	/// <param name="fExpectResponse">
	/// A Boolean value that indicates whether the application expects a data connection to be established by the FTP server. This must
	/// be set to <c>TRUE</c> if a data connection is expected, or <c>FALSE</c> otherwise.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A parameter that can be set to one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_ASCII</term>
	/// <term>Transfers the file using the FTP ASCII (Type A) transfer method. Control and formatting data is converted to local equivalents.</term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_BINARY</term>
	/// <term>
	/// Transfers the file using the FTP Image (Type I) transfer method. The file is transferred exactly with no changes. This is the
	/// default transfer method.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszCommand">A pointer to a string that contains the command to send to the FTP server.</param>
	/// <param name="dwContext">
	/// A pointer to a variable that contains an application-defined value used to identify the application context in callback operations.
	/// </param>
	/// <param name="phFtpCommand">
	/// A pointer to a handle that is created if a valid data socket is opened. The fExpectResponse parameter must be set to <c>TRUE</c>
	/// for phFtpCommand to be filled.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// GetLastError can return ERROR_INTERNET_NO_DIRECT_ACCESS if the client application is offline. If one or more of the parameters
	/// are invalid, <c>GetLastError</c> will return <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpcommanda BOOLAPI FtpCommandA( HINTERNET hConnect, BOOL
	// fExpectResponse, DWORD dwFlags, LPCSTR lpszCommand, DWORD_PTR dwContext, HINTERNET *phFtpCommand );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "cd12f52c-80d6-4aee-96c8-cb3cafcf0a6a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpCommand(HINTERNET hConnect, [MarshalAs(UnmanagedType.Bool)] bool fExpectResponse, FTP_TRANSER_TYPE dwFlags,
		string lpszCommand, [Optional] IntPtr dwContext, out SafeHINTERNET phFtpCommand);

	/// <summary>Creates a new directory on the FTP server.</summary>
	/// <param name="hConnect">Handle returned by a previous call to InternetConnect using <c>INTERNET_SERVICE_FTP</c>.</param>
	/// <param name="lpszDirectory">
	/// Pointer to a null-terminated string that contains the name of the directory to be created. This can be either a fully qualified
	/// path or a name relative to the current directory.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError. If the error
	/// message indicates that the FTP server denied the request to create a directory, use InternetGetLastResponseInfo to determine why.
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application should use FtpGetCurrentDirectory to determine the remote site's current working directory instead of assuming
	/// that the remote system uses a hierarchical naming scheme for directories.
	/// </para>
	/// <para>The lpszDirectory parameter can be either partially or fully qualified file names relative to the current directory.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpcreatedirectorya BOOLAPI FtpCreateDirectoryA( HINTERNET
	// hConnect, LPCSTR lpszDirectory );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "51a33c5b-4e82-4148-8a3f-0cf7c0a8bac0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpCreateDirectory(HINTERNET hConnect, string lpszDirectory);

	/// <summary>Deletes a file stored on the FTP server.</summary>
	/// <param name="hConnect">Handle returned by a previous call to InternetConnect using <c>INTERNET_SERVICE_FTP</c>.</param>
	/// <param name="lpszFileName">Pointer to a null-terminated string that contains the name of the file to be deleted.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>The lpszFileName parameter can be either partially or fully qualified file names relative to the current directory.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpdeletefilea BOOLAPI FtpDeleteFileA( HINTERNET hConnect,
	// LPCSTR lpszFileName );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "16723c97-fd6f-40c2-844d-fc6d2dcc1a32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpDeleteFile(HINTERNET hConnect, string lpszFileName);

	/// <summary>
	/// Searches the specified directory of the given FTP session. File and directory entries are returned to the application in the
	/// WIN32_FIND_DATA structure.
	/// </summary>
	/// <param name="hConnect">Handle to an FTP session returned from InternetConnect.</param>
	/// <param name="lpszSearchFile">
	/// Pointer to a <c>null</c>-terminated string that specifies a valid directory path or file name for the FTP server's file system.
	/// The string can contain wildcards, but no blank spaces are allowed. If the value of lpszSearchFile is <c>NULL</c> or if it is an
	/// empty string, the function finds the first file in the current directory on the server.
	/// </param>
	/// <param name="lpFindFileData">Pointer to a WIN32_FIND_DATA structure that receives information about the found file or directory.</param>
	/// <param name="dwFlags">
	/// <para>Controls the behavior of this function. This parameter can be a combination of the following values.</para>
	/// <para>INTERNET_FLAG_HYPERLINK</para>
	/// <para>INTERNET_FLAG_NEED_FILE</para>
	/// <para>INTERNET_FLAG_NO_CACHE_WRITE</para>
	/// <para>INTERNET_FLAG_RELOAD</para>
	/// <para>INTERNET_FLAG_RESYNCHRONIZE</para>
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that specifies the application-defined value that associates this search with any application data. This
	/// parameter is used only if the application has already called InternetSetStatusCallback to set up a status callback function.
	/// </param>
	/// <returns>
	/// Returns a valid handle for the request if the directory enumeration was started successfully, or returns <c>NULL</c> otherwise.
	/// To get a specific error message, call GetLastError. If <c>GetLastError</c> returns ERROR_INTERNET_EXTENDED_ERROR, as in the case
	/// where the function finds no matching files, call the InternetGetLastResponseInfo function to retrieve the extended error text,
	/// as documented in Handling Errors.
	/// </returns>
	/// <remarks>
	/// <para>
	/// For <c>FtpFindFirstFile</c>, file times returned in the WIN32_FIND_DATA structure are in the local time zone, not in a
	/// coordinated universal time (UTC) format.
	/// </para>
	/// <para>
	/// <c>FtpFindFirstFile</c> is similar to the FindFirstFile function. Note, however, that only one <c>FtpFindFirstFile</c> can occur
	/// at a time within a given FTP session. The enumerations, therefore, are correlated with the FTP session handle. This is because
	/// the FTP protocol allows only a single directory enumeration per session.
	/// </para>
	/// <para>
	/// After calling <c>FtpFindFirstFile</c> and until calling InternetCloseHandle, the application cannot call <c>FtpFindFirstFile</c>
	/// again on the given FTP session handle. If a call is made to <c>FtpFindFirstFile</c> on that handle, the function fails with
	/// ERROR_FTP_TRANSFER_IN_PROGRESS. After the calling application has finished using the <c>HINTERNET</c> handle returned by
	/// <c>FtpFindFirstFile</c>, it must be closed using the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// After beginning a directory enumeration with <c>FtpFindFirstFile</c>, the InternetFindNextFile function can be used to continue
	/// the enumeration.
	/// </para>
	/// <para>
	/// Because the FTP protocol provides no standard means of enumerating, some of the common information about files, such as file
	/// creation date and time, is not always available or correct. When this happens, <c>FtpFindFirstFile</c> and InternetFindNextFile
	/// fill in unavailable information with a best guess based on available information. For example, creation and last access dates
	/// are often the same as the file's modification date.
	/// </para>
	/// <para>The application cannot call <c>FtpFindFirstFile</c> between calls to FtpOpenFile and InternetCloseHandle.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpfindfirstfilea void FtpFindFirstFileA( HINTERNET
	// hConnect, LPCSTR lpszSearchFile, LPWIN32_FIND_DATAA lpFindFileData, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "4f331f99-c52c-4744-a9a7-eeb09803862d")]
	public static extern SafeHINTERNET FtpFindFirstFile(HINTERNET hConnect, [Optional] string? lpszSearchFile, out WIN32_FIND_DATA lpFindFileData,
		INTERNET_FLAG dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Retrieves the current directory for the specified FTP session.</summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszCurrentDirectory">Pointer to a null-terminated string that receives the absolute path of the current directory.</param>
	/// <param name="lpdwCurrentDirectory">
	/// Pointer to a variable that specifies the length of the buffer, in <c>TCHARs</c>. The buffer length must include room for a
	/// terminating null character. Using a length of <c>MAX_PATH</c> is sufficient for all paths. When the function returns, the
	/// variable receives the number of characters copied into the buffer.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// If the lpszCurrentDirectory buffer is not large enough, lpdwCurrentDirectory receives the number of bytes required to retrieve
	/// the full, current directory name.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpgetcurrentdirectorya BOOLAPI FtpGetCurrentDirectoryA(
	// HINTERNET hConnect, LPSTR lpszCurrentDirectory, LPDWORD lpdwCurrentDirectory );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "1b757061-469b-4c11-9d0d-38b300216221")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpGetCurrentDirectory(HINTERNET hConnect, StringBuilder lpszCurrentDirectory, ref uint lpdwCurrentDirectory);

	/// <summary>
	/// Retrieves a file from the FTP server and stores it under the specified file name, creating a new local file in the process.
	/// </summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszRemoteFile">Pointer to a null-terminated string that contains the name of the file to be retrieved.</param>
	/// <param name="lpszNewFile">
	/// Pointer to a null-terminated string that contains the name of the file to be created on the local system.
	/// </param>
	/// <param name="fFailIfExists">
	/// Indicates whether the function should proceed if a local file of the specified name already exists. If fFailIfExists is
	/// <c>TRUE</c> and the local file exists, <c>FtpGetFile</c> fails.
	/// </param>
	/// <param name="dwFlagsAndAttributes">
	/// File attributes for the new file. This parameter can be any combination of the FILE_ATTRIBUTE_* flags used by the CreateFile function.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Controls how the function will handle the file download. The first set of flag values indicates the conditions under which the
	/// transfer occurs. These transfer type flags can be used in combination with the second set of flags that control caching.
	/// </para>
	/// <para>The application can select one of these transfer type values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_ASCII</term>
	/// <term>
	/// Transfers the file using FTP's ASCII (Type A) transfer method. Control and formatting information is converted to local equivalents.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_BINARY</term>
	/// <term>
	/// Transfers the file using FTP's Image (Type I) transfer method. The file is transferred exactly as it exists with no changes.
	/// This is the default transfer method.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_UNKNOWN</term>
	/// <term>Defaults to FTP_TRANSFER_TYPE_BINARY.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_TRANSFER_ASCII</term>
	/// <term>Transfers the file as ASCII.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_TRANSFER_BINARY</term>
	/// <term>Transfers the file as binary.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following flags determine how the caching of this file will be done. Any combination of the following flags can be used with
	/// the transfer type flag.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_HYPERLINK</term>
	/// <term>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NEED_FILE</term>
	/// <term>Causes a temporary file to be created if the file cannot be cached.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RELOAD</term>
	/// <term>Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESYNCHRONIZE</term>
	/// <term>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are reloaded.
	/// Windows XP and Windows Server 2003 R2 and earlier: Gopher resources are also reloaded.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that contains the application-defined value that associates this search with any application data. This is
	/// used only if the application has already called InternetSetStatusCallback to set up a status callback function.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// <c>FtpGetFile</c> is a high-level routine that handles all the bookkeeping and overhead associated with reading a file from an
	/// FTP server and storing it locally. An application that needs to retrieve file data only or that requires close control over the
	/// file transfer should use the FtpOpenFile and InternetReadFile functions.
	/// </para>
	/// <para>
	/// If the dwFlags parameter specifies <c>FTP_TRANSFER_TYPE_ASCII</c>, translation of the file data converts control and formatting
	/// characters to local equivalents. The default transfer is binary mode, where the file is downloaded in the same format as it is
	/// stored on the server.
	/// </para>
	/// <para>Both lpszRemoteFile and lpszNewFile can be either partially or fully qualified file names relative to the current directory.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpgetfilea BOOLAPI FtpGetFileA( HINTERNET hConnect, LPCSTR
	// lpszRemoteFile, LPCSTR lpszNewFile, BOOL fFailIfExists, DWORD dwFlagsAndAttributes, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "2de83924-dc48-42bc-8f08-b94e9eb88b6f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpGetFile(HINTERNET hConnect, string lpszRemoteFile, string lpszNewFile, [MarshalAs(UnmanagedType.Bool)] bool fFailIfExists,
		FileFlagsAndAttributes dwFlagsAndAttributes, INTERNET_FLAG dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Retrieves the file size of the requested FTP resource.</summary>
	/// <param name="hFile">Handle returned from a call to FtpOpenFile.</param>
	/// <param name="lpdwFileSizeHigh">Pointer to the high-order unsigned long integer of the file size of the requested FTP resource.</param>
	/// <returns>Returns the low-order unsigned long integer of the file size of the requested FTP resource.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpgetfilesize void FtpGetFileSize( HINTERNET hFile,
	// LPDWORD lpdwFileSizeHigh );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "f6cc696b-55b6-4d21-9401-fbb15062d0b4")]
	public static extern uint FtpGetFileSize(HINTERNET hFile, out uint lpdwFileSizeHigh);

	/// <summary>Initiates access to a remote file on an FTP server for reading or writing.</summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszFileName">Pointer to a null-terminated string that contains the name of the file to be accessed.</param>
	/// <param name="dwAccess">File access. This parameter can be <c>GENERIC_READ</c> or <c>GENERIC_WRITE</c>, but not both.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Conditions under which the transfers occur. The application should select one transfer type and any of the flags that indicate
	/// how the caching of the file will be controlled.
	/// </para>
	/// <para>The transfer type can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_ASCII</term>
	/// <term>
	/// Transfers the file using FTP's ASCII (Type A) transfer method. Control and formatting information is converted to local equivalents.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_BINARY</term>
	/// <term>
	/// Transfers the file using FTP's Image (Type I) transfer method. The file is transferred exactly as it exists with no changes.
	/// This is the default transfer method.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_UNKNOWN</term>
	/// <term>Defaults to FTP_TRANSFER_TYPE_BINARY.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_TRANSFER_ASCII</term>
	/// <term>Transfers the file as ASCII.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_TRANSFER_BINARY</term>
	/// <term>Transfers the file as binary.</term>
	/// </item>
	/// </list>
	/// <para>The following values are used to control the caching of the file. The application can use one or more of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_HYPERLINK</term>
	/// <term>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NEED_FILE</term>
	/// <term>Causes a temporary file to be created if the file cannot be cached.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RELOAD</term>
	/// <term>Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESYNCHRONIZE</term>
	/// <term>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are reloaded.
	/// Windows XP and Windows Server 2003 R2 and earlier: Gopher resources are also reloaded.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that contains the application-defined value that associates this search with any application data. This is
	/// only used if the application has already called InternetSetStatusCallback to set up a status callback function.
	/// </param>
	/// <returns>Returns a handle if successful, or <c>NULL</c> otherwise. To retrieve a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// After calling <c>FtpOpenFile</c> and until calling InternetCloseHandle, all other calls to FTP functions on the same FTP session
	/// handle will fail and set the error message to ERROR_FTP_TRANSFER_IN_PROGRESS. After the calling application has finished using
	/// the HINTERNET handle returned by <c>FtpOpenFile</c>, it must be closed using the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// Only one file can be open in a single FTP session. Therefore, no file handle is returned and the application simply uses the FTP
	/// session handle when necessary.
	/// </para>
	/// <para>The lpszFileName parameter can be either a partially or fully qualified file name relative to the current directory.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpopenfilea void FtpOpenFileA( HINTERNET hConnect, LPCSTR
	// lpszFileName, DWORD dwAccess, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "fb44d7bd-7868-4c53-aa4b-608d79c5bc7c")]
	public static extern SafeHINTERNET FtpOpenFile(HINTERNET hConnect, string lpszFileName, ACCESS_MASK dwAccess, FTP_TRANSER_TYPE dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Stores a file on the FTP server.</summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszLocalFile">
	/// Pointer to a null-terminated string that contains the name of the file to be sent from the local system.
	/// </param>
	/// <param name="lpszNewRemoteFile">
	/// Pointer to a null-terminated string that contains the name of the file to be created on the remote system.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Conditions under which the transfers occur. The application should select one transfer type and any of the flags that control
	/// how the caching of the file will be controlled.
	/// </para>
	/// <para>The transfer type can be any one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_ASCII</term>
	/// <term>
	/// Transfers the file using FTP's ASCII (Type A) transfer method. Control and formatting information is converted to local equivalents.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_BINARY</term>
	/// <term>
	/// Transfers the file using FTP's Image (Type I) transfer method. The file is transferred exactly as it exists with no changes.
	/// This is the default transfer method.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FTP_TRANSFER_TYPE_UNKNOWN</term>
	/// <term>Defaults to FTP_TRANSFER_TYPE_BINARY.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_TRANSFER_ASCII</term>
	/// <term>Transfers the file as ASCII.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_TRANSFER_BINARY</term>
	/// <term>Transfers the file as binary.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following values are used to control the caching of the file. The application can use one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_HYPERLINK</term>
	/// <term>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NEED_FILE</term>
	/// <term>Causes a temporary file to be created if the file cannot be cached.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RELOAD</term>
	/// <term>Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESYNCHRONIZE</term>
	/// <term>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are reloaded.
	/// Windows XP and Windows Server 2003 R2 and earlier: Gopher resources are also reloaded.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that contains the application-defined value that associates this search with any application data. This
	/// parameter is used only if the application has already called InternetSetStatusCallback to set up a status callback.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// <c>FtpPutFile</c> is a high-level routine that handles all the bookkeeping and overhead associated with reading a file locally
	/// and storing it on an FTP server. An application that needs to send file data only, or that requires close control over the file
	/// transfer, should use the FtpOpenFile and InternetWriteFile functions.
	/// </para>
	/// <para>
	/// If the dwFlags parameter specifies <c>FILE_TRANSFER_TYPE_ASCII</c>, translation of the file data converts control and formatting
	/// characters to local equivalents.
	/// </para>
	/// <para>
	/// Both lpszNewRemoteFile and lpszLocalFile can be either partially or fully qualified file names relative to the current directory.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpputfilea BOOLAPI FtpPutFileA( HINTERNET hConnect, LPCSTR
	// lpszLocalFile, LPCSTR lpszNewRemoteFile, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "161d4c04-c928-4178-b75b-f4552ac051ea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpPutFile(HINTERNET hConnect, string lpszLocalFile, string lpszNewRemoteFile, INTERNET_FLAG dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Removes the specified directory on the FTP server.</summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszDirectory">
	/// Pointer to a null-terminated string that contains the name of the directory to be removed. This can be either a fully qualified
	/// path or a name relative to the current directory.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError. If the error
	/// message indicates that the FTP server denied the request to remove a directory, use InternetGetLastResponseInfo to determine why.
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application should use FtpGetCurrentDirectory to determine the remote site's current working directory, instead of assuming
	/// that the remote system uses a hierarchical naming scheme for directories.
	/// </para>
	/// <para>The lpszDirectory parameter can be either partially or fully qualified file names relative to the current directory.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpremovedirectorya BOOLAPI FtpRemoveDirectoryA( HINTERNET
	// hConnect, LPCSTR lpszDirectory );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "4c02af2f-ece8-409a-9c3e-495e1beb80ef")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpRemoveDirectory(HINTERNET hConnect, string lpszDirectory);

	/// <summary>Renames a file stored on the FTP server.</summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszExisting">Pointer to a null-terminated string that contains the name of the file to be renamed.</param>
	/// <param name="lpszNew">Pointer to a null-terminated string that contains the new name for the remote file.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// The lpszExisting and lpszNew parameters can be either partially or fully qualified file names relative to the current directory.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftprenamefilea BOOLAPI FtpRenameFileA( HINTERNET hConnect,
	// LPCSTR lpszExisting, LPCSTR lpszNew );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "2c46d8bb-aceb-4dd2-be4f-2c418357d4ae")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpRenameFile(HINTERNET hConnect, string lpszExisting, string lpszNew);

	/// <summary>Changes to a different working directory on the FTP server.</summary>
	/// <param name="hConnect">Handle to an FTP session.</param>
	/// <param name="lpszDirectory">
	/// Pointer to a null-terminated string that contains the name of the directory to become the current working directory. This can be
	/// either a fully qualified path or a name relative to the current directory.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError. If the error
	/// message indicates that the FTP server denied the request to change a directory, use InternetGetLastResponseInfo to determine why.
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application should use FtpGetCurrentDirectory to determine the remote site's current working directory, instead of assuming
	/// that the remote system uses a hierarchical naming scheme for directories.
	/// </para>
	/// <para>The lpszDirectory parameter can be either partially or fully qualified file names relative to the current directory.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-ftpsetcurrentdirectorya BOOLAPI FtpSetCurrentDirectoryA(
	// HINTERNET hConnect, LPCSTR lpszDirectory );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "1ee21e9e-d113-427e-ab47-86139e6ecad0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FtpSetCurrentDirectory(HINTERNET hConnect, string lpszDirectory);

	/// <summary>Retrieves information about cache configuration.</summary>
	/// <param name="lpCacheConfigInfo">
	/// A pointer to an INTERNET_CACHE_CONFIG_INFO structure that receives information about the cache configuration. The
	/// <c>dwStructSize</c> field of the structure should be initialized to the size of <c>INTERNET_CACHE_CONFIG_INFO</c>.
	/// </param>
	/// <param name="lpcbCacheConfigInfo">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="dwFieldControl">
	/// <para>Determines the behavior of the function, as one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CACHE_CONFIG_FORCE_CLEANUP_FC 0x00000020</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_DISK_CACHE_PATHS_FC 0x00000040</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_SYNC_MODE_FC 0x00000080</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_CONTENT_PATHS_FC 0x00000100</term>
	/// <term>
	/// The CachePath field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo parameter is filled with a
	/// pointer to a string identifying the content path. This cannot be used at the same time as CACHE_CONFIG_HISTORY_PATHS_FC or CACHE_CONFIG_COOKIES_PATHS_FC.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_HISTORY_PATHS_FC 0x00000400</term>
	/// <term>
	/// The CachePath field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo parameter is filled with a
	/// pointer to a string identifying the history path. This cannot be used at the same time as CACHE_CONFIG_CONTENT_PATHS_FC or CACHE_CONFIG_COOKIES_PATHS_FC.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_COOKIES_PATHS_FC 0x00000200</term>
	/// <term>
	/// The CachePath field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo parameter is filled with a
	/// pointer to a string identifying the cookie path. This cannot be used at the same time as CACHE_CONFIG_CONTENT_PATHS_FC or CACHE_CONFIG_HISTORY_PATHS_FC.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_QUOTA_FC 0x00000800</term>
	/// <term>
	/// The dwQuota field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo is set to the cache limit for
	/// the container specified in the dwContainer field.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_USER_MODE_FC 0x00001000</term>
	/// <term>Reserved.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_CONTENT_USAGE_FC 0x00002000</term>
	/// <term>
	/// The dwNormalUsage field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo is set to the cache size
	/// for the container specified in the dwContainer field.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CACHE_CONFIG_STICKY_CONTENT_USAGE_FC 0x00004000</term>
	/// <term>
	/// The dwExemptUsage field of the INTERNET_CACHE_CONFIG_INFO structure specified in the lpCachedConfigInfo is set to the exempt
	/// usage, the amount of bytes exempt from scavenging, for the container specified in the dwContainer field. (This field must be the
	/// content container.)
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winineti/nf-winineti-geturlcacheconfiginfoa BOOLAPI GetUrlCacheConfigInfoA(
	// LPINTERNET_CACHE_CONFIG_INFOA lpCacheConfigInfo, LPDWORD lpcbCacheConfigInfo, DWORD dwFieldControl );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winineti.h", MSDNShortId = "93a29a4f-57bf-497c-a7b1-3960935590f9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetUrlCacheConfigInfo(ref INTERNET_CACHE_CONFIG_INFO lpCacheConfigInfo, [Optional] IntPtr lpcbCacheConfigInfo, CACHE_CONFIG_FC dwFieldControl);

	/// <summary>Retrieves information about a cache entry.</summary>
	/// <param name="lpszUrlName">
	/// A pointer to a null-terminated string that contains the name of the cache entry. The name string should not contain any escape characters.
	/// </param>
	/// <param name="lpCacheEntryInfo">
	/// <para>
	/// A pointer to an INTERNET_CACHE_ENTRY_INFO structure that receives information about the cache entry. A buffer should be
	/// allocated for this parameter.
	/// </para>
	/// <para>
	/// Since the required size of the buffer is not known in advance, it is best to allocate a buffer adequate to handle the size of
	/// most INTERNET_CACHE_ENTRY_INFO entries. There is no cache entry size limit, so applications that need to enumerate the cache
	/// must be prepared to allocate variable-sized buffers.
	/// </para>
	/// </param>
	/// <param name="lpcbCacheEntryInfo">
	/// A pointer to a variable that specifies the size of the lpCacheEntryInfo buffer, in bytes. When the function returns, the
	/// variable contains the number of bytes copied to the buffer, or the required size of the buffer, in bytes.
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Possible
	/// error values include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The specified cache entry is not found in the cache.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The size of lpCacheEntryInfo as specified by lpdwCacheEntryInfoBufferSize is not sufficient to contain all the information. The
	/// value returned in lpdwCacheEntryInfoBufferSize indicates the buffer size necessary to contain all the information.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetUrlCacheEntryInfo</c> does not do any URL parsing, so a URL containing an anchor (#) will not be found in the cache, even
	/// if the resource is cached. For example, if the URL http://example.com/example.htm#sample is passed, the function returns
	/// <c>ERROR_FILE_NOT_FOUND</c> even if http://example.com/example.htm is in the cache.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-geturlcacheentryinfoa BOOLAPI GetUrlCacheEntryInfoA( LPCSTR
	// lpszUrlName, LPINTERNET_CACHE_ENTRY_INFOA lpCacheEntryInfo, LPDWORD lpcbCacheEntryInfo );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "0f70bcef-2d56-4765-a44e-4549b4ae2ced")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetUrlCacheEntryInfo(string lpszUrlName, IntPtr lpCacheEntryInfo, ref uint lpcbCacheEntryInfo);

	/// <summary>
	/// Retrieves information on the cache entry associated with the specified URL, taking into account any redirections that are
	/// applied in offline mode by the HttpSendRequest function.
	/// </summary>
	/// <param name="lpszUrl">
	/// A pointer to a <c>null</c>-terminated string that contains the name of the cache entry. The name string should not contain any
	/// escape characters.
	/// </param>
	/// <param name="lpCacheEntryInfo">
	/// <para>
	/// A pointer to an INTERNET_CACHE_ENTRY_INFO structure that receives information about the cache entry. A buffer should be
	/// allocated for this parameter.
	/// </para>
	/// <para>
	/// Since the required size of the buffer is not known in advance, it is best to allocate a buffer adequate to handle the size of
	/// most INTERNET_CACHE_ENTRY_INFO entries. There is no cache entry size limit, so applications that need to enumerate the cache
	/// must be prepared to allocate variable-sized buffers.
	/// </para>
	/// </param>
	/// <param name="lpcbCacheEntryInfo">
	/// Pointer to a variable that specifies the size of the lpCacheEntryInfo buffer, in bytes. When the function returns, the variable
	/// contains the number of bytes copied to the buffer, or the required size of the buffer in bytes.
	/// </param>
	/// <param name="lpszRedirectUrl">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="lpcbRedirectUrl">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if the URL was located, or <c>FALSE</c> otherwise. Call GetLastError for specific error information.
	/// Possible errors include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The URL was not found in the cache index, even after taking any cached redirections into account.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The buffer referenced by lpCacheEntryInfo was not large enough to hold the requested information. The size of the buffer needed
	/// will be returned to lpdwCacheEntryInfoBufSize.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetUrlCacheEntryInfoEx</c> does not do any URL parsing, so a URL containing an anchor (#) will not be found in the cache,
	/// even if the resource is cached. For example, if the URL http://example.com/example.htm#sample is passed, the function returns
	/// ERROR_FILE_NOT_FOUND even if http://example.com/example.htm is in the cache.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-geturlcacheentryinfoexa BOOLAPI GetUrlCacheEntryInfoExA(
	// LPCSTR lpszUrl, LPINTERNET_CACHE_ENTRY_INFOA lpCacheEntryInfo, LPDWORD lpcbCacheEntryInfo, LPSTR lpszRedirectUrl, LPDWORD
	// lpcbRedirectUrl, LPVOID lpReserved, DWORD dwFlags );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "3842dae9-9474-492a-83fa-29d7927dc92d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetUrlCacheEntryInfoEx(string lpszUrl, IntPtr lpCacheEntryInfo, ref uint lpcbCacheEntryInfo,
		[Optional] IntPtr lpszRedirectUrl, [Optional] IntPtr lpcbRedirectUrl, [Optional] IntPtr lpReserved, [Optional] uint dwFlags);

	/// <summary>
	/// <para>[The <c>GopherCreateLocator</c> function is available for use in the operating systems specified in the Requirements section.]</para>
	/// <para>Creates a Gopher or Gopher+ locator string from the selector string's component parts.</para>
	/// </summary>
	/// <param name="lpszHost">
	/// Pointer to a <c>null</c>-terminated string that contains the name of the host, or a dotted-decimal IP address (such as 198.105.232.1).
	/// </param>
	/// <param name="nServerPort">
	/// Port number on which the Gopher server at lpszHost lives, in host byte order. If nServerPort is
	/// <c>INTERNET_INVALID_PORT_NUMBER</c>, the default Gopher port is used.
	/// </param>
	/// <param name="lpszDisplayString">
	/// Pointer to a <c>null</c>-terminated string that contains the Gopher document or directory to be displayed. If this parameter is
	/// <c>NULL</c>, the function returns the default directory for the Gopher server.
	/// </param>
	/// <param name="lpszSelectorString">
	/// Pointer to the selector string to send to the Gopher server in order to retrieve information. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="dwGopherType">
	/// Determines whether lpszSelectorString refers to a directory or document, and whether the request is Gopher+ or Gopher. The
	/// default value, GOPHER_TYPE_DIRECTORY, is used if the value of dwGopherType is zero. This can be one of the gopher type values.
	/// </param>
	/// <param name="lpszLocator">
	/// Pointer to a buffer that receives the locator string. If lpszLocator is <c>NULL</c>, lpdwBufferLength receives the necessary
	/// buffer length, but the function performs no other processing.
	/// </param>
	/// <param name="lpdwBufferLength">
	/// Pointer to a variable that contains the length of the lpszLocator buffer, in characters. When the function returns, this
	/// parameter receives the number of characters written to the buffer. If GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c>,
	/// this parameter receives the number of characters required.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError or InternetGetLastResponseInfo.
	/// </returns>
	/// <remarks>
	/// <para>To retrieve information from a Gopher server, an application must first get a Gopher "locator" from the Gopher server.</para>
	/// <para>
	/// The locator, which the application should treat as an opaque token, is normally used for calls to the GopherFindFirstFile
	/// function to retrieve a specific piece of information.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-gophercreatelocatora BOOLAPI GopherCreateLocatorA( LPCSTR
	// lpszHost, INTERNET_PORT nServerPort, LPCSTR lpszDisplayString, LPCSTR lpszSelectorString, DWORD dwGopherType, LPSTR lpszLocator,
	// LPDWORD lpdwBufferLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "972a4ff9-efda-4784-9ac8-c76e679e8032")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GopherCreateLocator(string lpszHost, INTERNET_PORT nServerPort, [Optional] string? lpszDisplayString, [Optional] string? lpszSelectorString,
		GOPHER_TYPE dwGopherType, [Optional] StringBuilder? lpszLocator, ref uint lpdwBufferLength);

	/// <summary>
	/// <para>[The <c>GopherFindFirstFile</c> function is available for use in the operating systems specified in the Requirements section.]</para>
	/// <para>
	/// Uses a Gopher locator and search criteria to create a session with the server and locate the requested documents, binary files,
	/// index servers, or directory trees.
	/// </para>
	/// </summary>
	/// <param name="hConnect">Handle to a Gopher session returned by InternetConnect.</param>
	/// <param name="lpszLocator">
	/// <para>Pointer to a <c>null</c>-terminated string that contains the name of the item to locate. This can be one of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Gopher locator returned by a previous call to this function or the InternetFindNextFile function.</term>
	/// </item>
	/// <item>
	/// <term><c>NULL</c> pointer or empty string indicating that the topmost information from a Gopher server is being returned.</term>
	/// </item>
	/// <item>
	/// <term>Locator created by the GopherCreateLocator function.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszSearchString">
	/// Pointer to a buffer that contains the strings to search, if this request is to an index server. Otherwise, this parameter should
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="lpFindData">Pointer to a GOPHER_FIND_DATA structure that receives the information retrieved by this function.</param>
	/// <param name="dwFlags">
	/// <para>Controls the function behavior. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_HYPERLINK</term>
	/// <term>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NEED_FILE</term>
	/// <term>Causes a temporary file to be created if the file cannot be cached.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_CACHE_WRITE</term>
	/// <term>Does not add the returned entity to the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RELOAD</term>
	/// <term>Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESYNCHRONIZE</term>
	/// <term>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP and Gopher resources are reloaded.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that contains the application-defined value that associates this search with any application data.
	/// </param>
	/// <returns>
	/// Returns a valid search handle if successful, or <c>NULL</c> otherwise. To retrieve extended error information, call GetLastError
	/// or InternetGetLastResponseInfo.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GopherFindFirstFile</c> closely resembles the FindFirstFile function. It creates a connection with a Gopher server, and then
	/// returns a single structure containing information about the first Gopher object referenced by the locator string.
	/// </para>
	/// <para>
	/// After calling <c>GopherFindFirstFile</c> to retrieve the first Gopher object in an enumeration, an application can use the
	/// InternetFindNextFile function to retrieve subsequent Gopher objects.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>GopherFindFirstFile</c>, it must be closed
	/// using the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-gopherfindfirstfilea void GopherFindFirstFileA( HINTERNET
	// hConnect, LPCSTR lpszLocator, LPCSTR lpszSearchString, LPGOPHER_FIND_DATAA lpFindData, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "801dc601-9d1d-4f7d-acf0-b36ea2314d70")]
	public static extern SafeHINTERNET GopherFindFirstFile(HINTERNET hConnect, [Optional] string? lpszLocator, [Optional] string? lpszSearchString,
		out GOPHER_FIND_DATA lpFindData, INTERNET_FLAG dwFlags, [Optional] IntPtr dwContext);

	/// <summary>
	/// <para>[The <c>GopherGetAttribute</c> function is available for use in the operating systems specified in the Requirements section.]</para>
	/// <para>Retrieves the specific attribute information from the server.</para>
	/// </summary>
	/// <param name="hConnect">Handle to a Gopher session returned by InternetConnect.</param>
	/// <param name="lpszLocator">
	/// Pointer to a <c>null</c>-terminated string that identifies the item at the Gopher server on which to return attribute information.
	/// </param>
	/// <param name="lpszAttributeName">
	/// Pointer to a space-delimited string specifying the names of attributes to return. If lpszAttributeName is <c>NULL</c>,
	/// <c>GopherGetAttribute</c> returns information about all attributes.
	/// </param>
	/// <param name="lpBuffer">Pointer to an application-defined buffer from which attribute information is retrieved.</param>
	/// <param name="dwBufferLength">Size of the lpBuffer buffer, in <c>TCHARs</c>.</param>
	/// <param name="lpdwCharactersReturned">Pointer to a variable that contains the number of characters read into the lpBuffer buffer.</param>
	/// <param name="lpfnEnumerator">
	/// <para>
	/// Pointer to a GopherAttributeEnumerator callback function that enumerates each attribute of the locator. This parameter is
	/// optional. If it is <c>NULL</c>, all Gopher attribute information is placed into lpBuffer. If lpfnEnumerator is specified, the
	/// callback function is called once for each attribute of the object.
	/// </para>
	/// <para>
	/// The callback function receives the address of a single GOPHER_ATTRIBUTE_TYPE structure with each call. The enumeration callback
	/// function allows the application to avoid having to parse the Gopher attribute information.
	/// </para>
	/// </param>
	/// <param name="dwContext">Application-defined value that associates this operation with any application data.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the request is satisfied, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError
	/// or InternetGetLastResponseInfo.
	/// </returns>
	/// <remarks>
	/// <para>Generally, applications call this function after calling GopherFindFirstFile or InternetFindNextFile.</para>
	/// <para>The size of the lpBuffer parameter must be equal to or greater than the value of <c>MIN_GOPHER_ATTRIBUTE_LENGTH</c>.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-gophergetattributea BOOLAPI GopherGetAttributeA( HINTERNET
	// hConnect, LPCSTR lpszLocator, LPCSTR lpszAttributeName, LPBYTE lpBuffer, DWORD dwBufferLength, LPDWORD lpdwCharactersReturned,
	// GOPHER_ATTRIBUTE_ENUMERATOR lpfnEnumerator, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "c9e95532-8c65-45fb-acd0-a1f09cee2ce2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GopherGetAttribute(HINTERNET hConnect, string lpszLocator, [Optional] string? lpszAttributeName, IntPtr lpBuffer,
		uint dwBufferLength, out uint lpdwCharactersReturned, [Optional] GopherAttributeEnumerator? lpfnEnumerator, [Optional] IntPtr dwContext);

	/// <summary>
	/// <para>
	/// [The <c>GopherGetLocatorType</c> function is available for use in the operating systems specified in the Requirements section.]
	/// </para>
	/// <para>Parses a Gopher locator and determines its attributes.</para>
	/// </summary>
	/// <param name="lpszLocator">Pointer to a null-terminated string that specifies the Gopher locator to be parsed.</param>
	/// <param name="lpdwGopherType">
	/// Pointer to a variable that receives the type of the locator. The type is a bitmask that consists of a combination of the gopher
	/// type values.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// <c>GopherGetLocatorType</c> returns information about the item referenced by a Gopher locator. Note that it is possible for
	/// multiple attributes to be set on a file. For example, both <c>GOPHER_TYPE_TEXT_FILE</c> and <c>GOPHER_TYPE_GOPHER_PLUS</c> are
	/// set for a text file stored on a Gopher+ server.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-gophergetlocatortypea BOOLAPI GopherGetLocatorTypeA( LPCSTR
	// lpszLocator, LPDWORD lpdwGopherType );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "e6f0ef67-c411-43ff-a477-5a8635057f2c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GopherGetLocatorType(string lpszLocator, out GOPHER_TYPE lpdwGopherType);

	/// <summary>
	/// <para>[The <c>GopherOpenFile</c> function is available for use in the operating systems specified in the Requirements section.]</para>
	/// <para>Begins reading a Gopher data file from a Gopher server.</para>
	/// </summary>
	/// <param name="hConnect">Handle to a Gopher session returned by InternetConnect.</param>
	/// <param name="lpszLocator">
	/// Pointer to a <c>null</c>-terminated string that specifies the file to be opened. Generally, this locator is returned from a call
	/// to GopherFindFirstFile or InternetFindNextFile. Because the Gopher protocol has no concept of a current directory, the locator
	/// is always fully qualified.
	/// </param>
	/// <param name="lpszView">
	/// Pointer to a <c>null</c>-terminated string that describes the view to open if several views of the file exist on the server. If
	/// lpszView is <c>NULL</c>, the function uses the default file view.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Conditions under which subsequent transfers occur. This parameter can be any of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_HYPERLINK</term>
	/// <term>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NEED_FILE</term>
	/// <term>Causes a temporary file to be created if the file cannot be cached.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_CACHE_WRITE</term>
	/// <term>Does not add the returned entity to the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RELOAD</term>
	/// <term>Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESYNCHRONIZE</term>
	/// <term>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP and Gopher resources are reloaded.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that contains an application-defined value that associates this operation with any application data.
	/// </param>
	/// <returns>
	/// Returns a handle if successful, or <c>NULL</c> if the file cannot be opened. To retrieve extended error information, call
	/// GetLastError or InternetGetLastResponseInfo.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GopherOpenFile</c> opens a file at a Gopher server. Because a file cannot actually be opened or locked at a server, this
	/// function simply associates location information with a handle that an application can use for file-based operations such as
	/// InternetReadFile or GopherGetAttribute.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>GopherOpenFile</c>, it must be closed using
	/// the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-gopheropenfilea void GopherOpenFileA( HINTERNET hConnect,
	// LPCSTR lpszLocator, LPCSTR lpszView, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "2731d573-f981-48ce-a306-bb7e295cefc6")]
	public static extern SafeHINTERNET GopherOpenFile(HINTERNET hConnect, string lpszLocator, [Optional] string? lpszView, INTERNET_FLAG dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Adds one or more HTTP request headers to the HTTP request handle.</summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest function.</param>
	/// <param name="lpszHeaders">
	/// A pointer to a string variable containing the headers to append to the request. Each header must be terminated by a CR/LF
	/// (carriage return/line feed) pair.
	/// </param>
	/// <param name="dwHeadersLength">
	/// The size of lpszHeaders, in <c>TCHARs</c>. If this parameter is -1L, the function assumes that lpszHeaders is zero-terminated
	/// (ASCIIZ), and the length is computed.
	/// </param>
	/// <param name="dwModifiers">
	/// <para>A set of modifiers that control the semantics of this function. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HTTP_ADDREQ_FLAG_ADD</term>
	/// <term>Adds the header if it does not exist. Used with HTTP_ADDREQ_FLAG_REPLACE.</term>
	/// </item>
	/// <item>
	/// <term>HTTP_ADDREQ_FLAG_ADD_IF_NEW</term>
	/// <term>Adds the header only if it does not already exist; otherwise, an error is returned.</term>
	/// </item>
	/// <item>
	/// <term>HTTP_ADDREQ_FLAG_COALESCE</term>
	/// <term>Coalesces headers of the same name.</term>
	/// </item>
	/// <item>
	/// <term>HTTP_ADDREQ_FLAG_COALESCE_WITH_COMMA</term>
	/// <term>
	/// Coalesces headers of the same name. For example, adding "Accept: text/*" followed by "Accept: audio/*" with this flag results in
	/// the formation of the single header "Accept: text/*, audio/*". This causes the first header found to be coalesced. It is up to
	/// the calling application to ensure a cohesive scheme with respect to coalesced/separate headers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HTTP_ADDREQ_FLAG_COALESCE_WITH_SEMICOLON</term>
	/// <term>Coalesces headers of the same name using a semicolon.</term>
	/// </item>
	/// <item>
	/// <term>HTTP_ADDREQ_FLAG_REPLACE</term>
	/// <term>
	/// Replaces or removes a header. If the header value is empty and the header is found, it is removed. If not empty, the header
	/// value is replaced.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// <c>HttpAddRequestHeaders</c> appends additional, free-format headers to the HTTP request handle and is intended for use by
	/// sophisticated clients that need detailed control over the exact request sent to the HTTP server.
	/// </para>
	/// <para>
	/// Note that for basic <c>HttpAddRequestHeaders</c>, the application can pass in multiple headers in a single buffer. If the
	/// application is trying to remove or replace a header, only one header can be supplied in lpszHeaders.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpAddRequestHeadersA</c> function represents headers as ISO-8859-1 characters not ANSI characters. The
	/// <c>HttpAddRequestHeadersW</c> function represents headers as ISO-8859-1 characters converted to UTF-16LE characters. As a
	/// result, it is never safe to use the <c>HttpAddRequestHeadersW</c> function when the headers to be added can contain non-ASCII
	/// characters. Instead, an application can use the MultiByteToWideChar and WideCharToMultiByte functions with a Codepage parameter
	/// set to 28591 to map between ANSI characters and UTF-16LE characters.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpaddrequestheadersa BOOLAPI HttpAddRequestHeadersA(
	// HINTERNET hRequest, LPCSTR lpszHeaders, DWORD dwHeadersLength, DWORD dwModifiers );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "636c3442-a2e6-4885-8fb4-1f6996ba6860")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpAddRequestHeaders(HINTERNET hRequest, string lpszHeaders, int dwHeadersLength, HTTP_ADDREQ_FLAG dwModifiers);

	/// <summary>Ends an HTTP request that was initiated by HttpSendRequestEx.</summary>
	/// <param name="hRequest">Handle returned by HttpOpenRequest and sent by HttpSendRequestEx.</param>
	/// <param name="lpBuffersOut">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">This parameter is reserved and must be set to 0.</param>
	/// <param name="dwContext">This parameter is reserved and must be set to 0.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If lpBuffersOut is not set to <c>NULL</c>, <c>HttpEndRequest</c> will return ERROR_INVALID_PARAMETER.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpendrequesta BOOLAPI HttpEndRequestA( HINTERNET
	// hRequest, LPINTERNET_BUFFERSA lpBuffersOut, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "6ea91da6-0bc2-49b6-a56b-c4224ad73b81")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpEndRequest(HINTERNET hRequest, IntPtr lpBuffersOut = default, uint dwFlags = 0, IntPtr dwContext = default);

	/// <summary>Creates an HTTP request handle.</summary>
	/// <param name="hConnect">A handle to an HTTP session returned by InternetConnect.</param>
	/// <param name="lpszVerb">
	/// A pointer to a <c>null</c>-terminated string that contains the HTTP verb to use in the request. If this parameter is
	/// <c>NULL</c>, the function uses GET as the HTTP verb.
	/// </param>
	/// <param name="lpszObjectName">
	/// A pointer to a <c>null</c>-terminated string that contains the name of the target object of the specified HTTP verb. This is
	/// generally a file name, an executable module, or a search specifier.
	/// </param>
	/// <param name="lpszVersion">
	/// <para>
	/// A pointer to a <c>null</c>-terminated string that contains the HTTP version to use in the request. Settings in Internet Explorer
	/// will override the value specified in this parameter.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the function uses an HTTP version of 1.1 or 1.0, depending on the value of the Internet
	/// Explorer settings.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description>HTTP/1.0</description>
	/// <description>HTTP version 1.0</description>
	/// </item>
	/// <item>
	/// <description>HTTP/1.1</description>
	/// <description>HTTP version 1.1</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszReferrer">
	/// A pointer to a <c>null</c>-terminated string that specifies the URL of the document from which the URL in the request
	/// (lpszObjectName) was obtained. If this parameter is <c>NULL</c>, no referrer is specified.
	/// </param>
	/// <param name="lplpszAcceptTypes">
	/// An array of strings that indicates media types accepted by the client.
	/// <para>
	/// If this parameter is <c>NULL</c>, no types are accepted by the client. Servers generally interpret a lack of accept types to
	/// indicate that the client accepts only documents of type "text/*" (that is, only text documents—no pictures or other binary
	/// files). For more information and a list of valid media types, see ftp://ftp.isi.edu/in-notes/iana/assignments/media-types/media-types.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Internet options. This parameter can be any of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description>INTERNET_FLAG_CACHE_IF_NET_FAIL</description>
	/// <description>
	/// Returns the resource from the cache if the network request for the resource fails due to an ERROR_INTERNET_CONNECTION_RESET (the
	/// connection with the server has been reset) or ERROR_INTERNET_CANNOT_CONNECT (the attempt to connect to the server failed).
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_HYPERLINK</description>
	/// <description>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_IGNORE_CERT_CN_INVALID</description>
	/// <description>
	/// Disables checking of SSL/PCT-based certificates that are returned from the server against the host name given in the request.
	/// WinINet functions use a simple check against certificates by comparing for matching host names and simple wildcarding rules.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_IGNORE_CERT_DATE_INVALID</description>
	/// <description>Disables checking of SSL/PCT-based certificates for proper validity dates.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP</description>
	/// <description>
	/// Disables detection of this special type of redirect. When this flag is used, WinINet functions transparently allow redirects
	/// from HTTPS to HTTP URLs.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS</description>
	/// <description>
	/// Disables detection of this special type of redirect. When this flag is used, WinINet functions transparently allow redirects
	/// from HTTP to HTTPS URLs.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_KEEP_CONNECTION</description>
	/// <description>
	/// Uses keep-alive semantics, if available, for the connection. This flag is required for Microsoft Network (MSN), NT LAN Manager
	/// (NTLM), and other types of authentication.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_NEED_FILE</description>
	/// <description>Causes a temporary file to be created if the file cannot be cached.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_NO_AUTH</description>
	/// <description>Does not attempt authentication automatically.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_NO_AUTO_REDIRECT</description>
	/// <description>Does not automatically handle redirection in HttpSendRequest.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_NO_CACHE_WRITE</description>
	/// <description>Does not add the returned entity to the cache.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_NO_COOKIES</description>
	/// <description>
	/// Does not automatically add cookie headers to requests, and does not automatically add returned cookies to the cookie database.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_NO_UI</description>
	/// <description>Disables the cookie dialog box.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_PRAGMA_NOCACHE</description>
	/// <description>Forces the request to be resolved by the origin server, even if a cached copy exists on the proxy.</description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_RELOAD</description>
	/// <description>
	/// Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_RESYNCHRONIZE</description>
	/// <description>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are reloaded.
	/// Windows XP and Windows Server 2003 R2 and earlier: Gopher resources are also reloaded.
	/// </description>
	/// </item>
	/// <item>
	/// <description>INTERNET_FLAG_SECURE</description>
	/// <description>
	/// Uses secure transaction semantics. This translates to using Secure Sockets Layer/Private Communications Technology (SSL/PCT) and
	/// is only meaningful in HTTP requests.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// A pointer to a variable that contains the application-defined value that associates this operation with any application data.
	/// </param>
	/// <returns>
	/// Returns an HTTP request handle if successful, or <c>NULL</c> otherwise. To retrieve extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HttpOpenRequest</c> function creates a new HTTP request handle and stores the specified parameters in that handle. An
	/// HTTP request handle holds a request to be sent to an HTTP server and contains all RFC822/MIME/HTTP headers to be sent as part of
	/// the request.
	/// </para>
	/// <para>
	/// If a verb other than "GET" or "POST" is specified, <c>HttpOpenRequest</c> automatically sets INTERNET_FLAG_NO_CACHE_WRITE and
	/// INTERNET_FLAG_RELOAD for the request.
	/// </para>
	/// <para>
	/// With Microsoft Internet Explorer 5 and later, if lpszVerb is set to "HEAD", the Content-Length header is ignored on responses
	/// from HTTP/1.1 servers.
	/// </para>
	/// <para>
	/// On Windows 7, Windows Server 2008 R2, and later, the lpszVersion parameter is overridden by Internet Explorer settings. The
	/// <c>EnableHttp1_1</c> is a registry value under <c>HKLM\Software\Microsoft\InternetExplorer\AdvacnedOptions\HTTP\GENABLE</c>
	/// controlled by Internet Options set in Internet Explorer for the system. The <c>EnableHttp1_1</c> value defaults to 1. The
	/// <c>HttpOpenRequest</c> function upgrades any HTTP version less than 1.1 to HTTP version 1.1 if <c>EnableHttp1_1</c> is set to 1.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>HttpOpenRequest</c>, it must be closed
	/// using the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// <c>Note</c> When a request is sent in asynchronous mode (the dwFlags parameter of InternetOpen specifies
	/// <c>INTERNET_FLAG_ASYNC</c>), and the dwContext parameter is zero ( <c>INTERNET_NO_CALLBACK</c>), the callback function set with
	/// InternetSetStatusCallback on the request handle will not be invoked, however, the call will still be performed in asynchronous mode.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpopenrequesta void HttpOpenRequestA( HINTERNET hConnect,
	// LPCSTR lpszVerb, LPCSTR lpszObjectName, LPCSTR lpszVersion, LPCSTR lpszReferrer, LPCSTR *lplpszAcceptTypes, DWORD dwFlags,
	// DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "caaff8e8-7db9-4d6d-8ba2-d8d19475173a")]
	public static extern SafeHINTERNET HttpOpenRequest(HINTERNET hConnect, string? lpszVerb = null, string lpszObjectName = "/",
		string? lpszVersion = null, string? lpszReferrer = null,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StringPtrArrayMarshaler), MarshalCookie = "Auto")] string[]? lplpszAcceptTypes = null,
		INTERNET_FLAG dwFlags = 0, IntPtr dwContext = default);

	/// <summary>Retrieves header information associated with an HTTP request.</summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest or InternetOpenUrl function.</param>
	/// <param name="dwInfoLevel">
	/// A combination of an attribute to be retrieved and flags that modify the request. For a list of possible attribute and modifier
	/// values, see Query Info Flags.
	/// </param>
	/// <param name="lpBuffer">A pointer to a buffer to receive the requested information. This parameter must not be <c>NULL</c>.</param>
	/// <param name="lpdwBufferLength">
	/// <para>A pointer to a variable that contains, on entry, the size in bytes of the buffer pointed to by lpvBuffer.</para>
	/// <para>
	/// When the function returns successfully, this variable contains the number of bytes of information written to the buffer. In the
	/// case of a string, the byte count does not include the string's terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// When the function fails with an extended error code of <c>ERROR_INSUFFICIENT_BUFFER</c>, the variable pointed to by
	/// lpdwBufferLength contains on exit the size, in bytes, of a buffer large enough to receive the requested information. The calling
	/// application can then allocate a buffer of this size or larger, and call the function again.
	/// </para>
	/// </param>
	/// <param name="lpdwIndex">
	/// A pointer to a zero-based header index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. If the next index cannot be found, <c>ERROR_HTTP_HEADER_NOT_FOUND</c> is returned.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>You can retrieve the following types of data from <c>HttpQueryInfo</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Strings (default)</term>
	/// </item>
	/// <item>
	/// <term>SYSTEMTIME (for dates)</term>
	/// </item>
	/// <item>
	/// <term><c>DWORD</c> (for <c>STATUS_CODE</c>, <c>CONTENT_LENGTH</c>, and so on, if <c>HTTP_QUERY_FLAG_NUMBER</c> has been used)</term>
	/// </item>
	/// </list>
	/// <para>
	/// If your application requires that the data be returned as a data type other than a string, you must include the appropriate
	/// modifier with the attribute passed to dwInfoLevel.
	/// </para>
	/// <para>
	/// The <c>HttpQueryInfo</c> function is available in Microsoft Internet Explorer 3.0 for ISO-8859-1 characters (
	/// <c>HttpQueryInfoA</c> function) and in Internet Explorer 4.0 or later for ISO-8859-1 characters ( <c>HttpQueryInfoA</c>
	/// function) and for ISO-8859-1 characters converted to UTF-16LE characters.(the <c>HttpQueryInfoW</c> function).
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpQueryInfoA</c> function represents headers as ISO-8859-1 characters not ANSI characters. The
	/// <c>HttpQueryInfoW</c> function represents headers as ISO-8859-1 characters converted to UTF-16LE characters. As a result, it is
	/// never safe to use the <c>HttpQueryInfoW</c> function when the headers can contain non-ASCII characters. Instead, an application
	/// can use the MultiByteToWideChar and WideCharToMultiByte functions with a Codepage parameter set to 28591 to map between ANSI
	/// characters and UTF-16LE characters.
	/// </para>
	/// <para>See Retrieving HTTP Headers for an example code calling the <c>HttpQueryInfo</c> function.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpqueryinfoa BOOLAPI HttpQueryInfoA( HINTERNET hRequest,
	// DWORD dwInfoLevel, LPVOID lpBuffer, LPDWORD lpdwBufferLength, LPDWORD lpdwIndex );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "5747ce19-5004-4eea-abe9-dd00abac1b3b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpQueryInfo(HINTERNET hRequest, HTTP_QUERY dwInfoLevel, IntPtr lpBuffer, ref uint lpdwBufferLength, ref uint lpdwIndex);

	/// <summary>Retrieves header information associated with an HTTP request.</summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest or InternetOpenUrl function.</param>
	/// <param name="dwInfoLevel">
	/// A combination of an attribute to be retrieved and flags that modify the request. For a list of possible attribute and modifier
	/// values, see Query Info Flags.
	/// </param>
	/// <param name="lpBuffer">A pointer to a buffer to receive the requested information. This parameter must not be <c>NULL</c>.</param>
	/// <param name="lpdwBufferLength">
	/// <para>A pointer to a variable that contains, on entry, the size in bytes of the buffer pointed to by lpvBuffer.</para>
	/// <para>
	/// When the function returns successfully, this variable contains the number of bytes of information written to the buffer. In the
	/// case of a string, the byte count does not include the string's terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// When the function fails with an extended error code of <c>ERROR_INSUFFICIENT_BUFFER</c>, the variable pointed to by
	/// lpdwBufferLength contains on exit the size, in bytes, of a buffer large enough to receive the requested information. The calling
	/// application can then allocate a buffer of this size or larger, and call the function again.
	/// </para>
	/// </param>
	/// <param name="lpdwIndex">
	/// A pointer to a zero-based header index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. If the next index cannot be found, <c>ERROR_HTTP_HEADER_NOT_FOUND</c> is returned.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>You can retrieve the following types of data from <c>HttpQueryInfo</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Strings (default)</term>
	/// </item>
	/// <item>
	/// <term>SYSTEMTIME (for dates)</term>
	/// </item>
	/// <item>
	/// <term><c>DWORD</c> (for <c>STATUS_CODE</c>, <c>CONTENT_LENGTH</c>, and so on, if <c>HTTP_QUERY_FLAG_NUMBER</c> has been used)</term>
	/// </item>
	/// </list>
	/// <para>
	/// If your application requires that the data be returned as a data type other than a string, you must include the appropriate
	/// modifier with the attribute passed to dwInfoLevel.
	/// </para>
	/// <para>
	/// The <c>HttpQueryInfo</c> function is available in Microsoft Internet Explorer 3.0 for ISO-8859-1 characters (
	/// <c>HttpQueryInfoA</c> function) and in Internet Explorer 4.0 or later for ISO-8859-1 characters ( <c>HttpQueryInfoA</c>
	/// function) and for ISO-8859-1 characters converted to UTF-16LE characters.(the <c>HttpQueryInfoW</c> function).
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpQueryInfoA</c> function represents headers as ISO-8859-1 characters not ANSI characters. The
	/// <c>HttpQueryInfoW</c> function represents headers as ISO-8859-1 characters converted to UTF-16LE characters. As a result, it is
	/// never safe to use the <c>HttpQueryInfoW</c> function when the headers can contain non-ASCII characters. Instead, an application
	/// can use the MultiByteToWideChar and WideCharToMultiByte functions with a Codepage parameter set to 28591 to map between ANSI
	/// characters and UTF-16LE characters.
	/// </para>
	/// <para>See Retrieving HTTP Headers for an example code calling the <c>HttpQueryInfo</c> function.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpqueryinfoa BOOLAPI HttpQueryInfoA( HINTERNET hRequest,
	// DWORD dwInfoLevel, LPVOID lpBuffer, LPDWORD lpdwBufferLength, LPDWORD lpdwIndex );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "5747ce19-5004-4eea-abe9-dd00abac1b3b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpQueryInfo(HINTERNET hRequest, HTTP_QUERY dwInfoLevel, IntPtr lpBuffer, ref uint lpdwBufferLength, [In, Optional] IntPtr lpdwIndex);

	/// <summary>Retrieves header information associated with an HTTP request.</summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest or InternetOpenUrl function.</param>
	/// <param name="dwInfoLevel">
	/// A combination of an attribute to be retrieved and flags that modify the request. For a list of possible attribute and modifier
	/// values, see Query Info Flags.
	/// </param>
	/// <param name="lpdwIndex">
	/// A pointer to a zero-based header index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. If the next index cannot be found, <c>ERROR_HTTP_HEADER_NOT_FOUND</c> is returned.
	/// </param>
	/// <returns>
	/// A <see cref="SafeCoTaskMemHandle"/> instance with sufficient memory needed to hold the response. This should be cast to the type required.
	/// </returns>
	public static ISafeMemoryHandle HttpQueryInfo(HINTERNET hRequest, HTTP_QUERY dwInfoLevel, ref uint lpdwIndex)
	{
		var sz = 0U;
		HttpQueryInfo(hRequest, dwInfoLevel, IntPtr.Zero, ref sz, ref lpdwIndex);
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		var hMem = new SafeCoTaskMemHandle(sz);
		Win32Error.ThrowLastErrorIfFalse(HttpQueryInfo(hRequest, dwInfoLevel, hMem, ref sz, ref lpdwIndex));
		return hMem;
	}

	/// <summary>Retrieves header information associated with an HTTP request.</summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest or InternetOpenUrl function.</param>
	/// <param name="dwInfoLevel">
	/// A combination of an attribute to be retrieved and flags that modify the request. For a list of possible attribute and modifier
	/// values, see Query Info Flags.
	/// </param>
	/// <returns>
	/// A <see cref="SafeCoTaskMemHandle"/> instance with sufficient memory needed to hold the response. This should be cast to the type required.
	/// </returns>
	public static ISafeMemoryHandle HttpQueryInfo(HINTERNET hRequest, HTTP_QUERY dwInfoLevel)
	{
		var sz = 0U;
		HttpQueryInfo(hRequest, dwInfoLevel, IntPtr.Zero, ref sz);
		Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_INSUFFICIENT_BUFFER);
		var hMem = new SafeCoTaskMemHandle(sz);
		Win32Error.ThrowLastErrorIfFalse(HttpQueryInfo(hRequest, dwInfoLevel, hMem, ref sz));
		return hMem;
	}

	/// <summary>Retrieves header information associated with an HTTP request.</summary>
	/// <typeparam name="T">
	/// Return type. This should be, by default, a <see cref="string"/> unless one of the return type modification flags is passed into
	/// <paramref name="dwInfoLevel"/>.
	/// </typeparam>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest or InternetOpenUrl function.</param>
	/// <param name="dwInfoLevel">
	/// A combination of an attribute to be retrieved and flags that modify the request. For a list of possible attribute and modifier
	/// values, see Query Info Flags.
	/// </param>
	/// <param name="lpdwIndex">
	/// A pointer to a zero-based header index used to enumerate multiple headers with the same name. When calling the function, this
	/// parameter is the index of the specified header to return. When the function returns, this parameter is the index of the next
	/// header. If the next index cannot be found, <c>ERROR_HTTP_HEADER_NOT_FOUND</c> is returned.
	/// </param>
	/// <returns>The HTTP information.</returns>
	public static T HttpQueryInfo<T>(HINTERNET hRequest, HTTP_QUERY dwInfoLevel, ref uint lpdwIndex)
	{
		using ISafeMemoryHandle hMem = HttpQueryInfo(hRequest, dwInfoLevel, ref lpdwIndex);
		return typeof(T) == typeof(string) ? (T)(object)hMem.ToString(-1)! : (typeof(T) == typeof(bool) ? (T)(object)Convert.ToBoolean(hMem.ToStructure<uint>()) : hMem.ToStructure<T>()!);
	}

	/// <summary>Retrieves header information associated with an HTTP request.</summary>
	/// <typeparam name="T">
	/// Return type. This should be, by default, a <see cref="string"/> unless one of the return type modification flags is passed into
	/// <paramref name="dwInfoLevel"/>.
	/// </typeparam>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest or InternetOpenUrl function.</param>
	/// <param name="dwInfoLevel">
	/// A combination of an attribute to be retrieved and flags that modify the request. For a list of possible attribute and modifier
	/// values, see Query Info Flags.
	/// </param>
	/// <returns>The HTTP information.</returns>
	public static T HttpQueryInfo<T>(HINTERNET hRequest, HTTP_QUERY dwInfoLevel)
	{
		using ISafeMemoryHandle hMem = HttpQueryInfo(hRequest, dwInfoLevel);
		return typeof(T) == typeof(string) ? (T)(object)hMem.ToString(-1)! : (typeof(T) == typeof(bool) ? (T)(object)Convert.ToBoolean(hMem.ToStructure<uint>()) : hMem.ToStructure<T>()!);
	}

	/// <summary>
	/// Sends the specified request to the HTTP server, allowing callers to send extra data beyond what is normally passed to HttpSendRequestEx.
	/// </summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest function.</param>
	/// <param name="lpszHeaders">
	/// A pointer to a <c>null</c>-terminated string that contains the additional headers to be appended to the request. This parameter
	/// can be <c>NULL</c> if there are no additional headers to be appended.
	/// </param>
	/// <param name="dwHeadersLength">
	/// The size of the additional headers, in <c>TCHARs</c>. If this parameter is -1L and lpszHeaders is not <c>NULL</c>, the function
	/// assumes that lpszHeaders is zero-terminated (ASCIIZ), and the length is calculated. See Remarks for specifics.
	/// </param>
	/// <param name="lpOptional">
	/// A pointer to a buffer containing any optional data to be sent immediately after the request headers. This parameter is generally
	/// used for POST and PUT operations. The optional data can be the resource or information being posted to the server. This
	/// parameter can be <c>NULL</c> if there is no optional data to send.
	/// </param>
	/// <param name="dwOptionalLength">
	/// The size of the optional data, in bytes. This parameter can be zero if there is no optional data to send.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// <c>HttpSendRequest</c> sends the specified request to the HTTP server and allows the client to specify additional headers to
	/// send along with the request.
	/// </para>
	/// <para>
	/// The function also lets the client specify optional data to send to the HTTP server immediately following the request headers.
	/// This feature is generally used for "write" operations such as PUT and POST.
	/// </para>
	/// <para>
	/// After the request is sent, the status code and response headers from the HTTP server are read. These headers are maintained
	/// internally and are available to client applications through the HttpQueryInfo function.
	/// </para>
	/// <para>
	/// An application can use the same HTTP request handle in multiple calls to <c>HttpSendRequest</c>, but the application must read
	/// all data returned from the previous call before calling the function again.
	/// </para>
	/// <para>
	/// In offline mode, <c>HttpSendRequest</c> returns <c>ERROR_FILE_NOT_FOUND</c> if the resource is not found in the Internet cache.
	/// </para>
	/// <para>
	/// There two versions of <c>HttpSendRequest</c>— <c>HttpSendRequestA</c> (used with ANSI builds) and <c>HttpSendRequestW</c> (used
	/// with Unicode builds). If <c>dwHeadersLength</c> is -1L and lpszHeaders is not <c>NULL</c>, the following will happen: If
	/// <c>HttpSendRequestA</c> is called, the function assumes that lpszHeaders is zero-terminated (ASCIIZ), and the length is
	/// calculated. If <c>HttpSendRequestW</c> is called, the function fails with <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpSendRequestA</c> function represents headers as ISO-8859-1 characters not ANSI characters. The
	/// <c>HttpSendRequestW</c> function represents headers as ISO-8859-1 characters converted to UTF-16LE characters. As a result, it
	/// is never safe to use the <c>HttpSendRequestW</c> function when the headers to be added can contain non-ASCII characters.
	/// Instead, an application can use the MultiByteToWideChar and WideCharToMultiByte functions with a Codepage parameter set to 28591
	/// to map between ANSI characters and UTF-16LE characters.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpsendrequesta BOOLAPI HttpSendRequestA( HINTERNET
	// hRequest, LPCSTR lpszHeaders, DWORD dwHeadersLength, LPVOID lpOptional, DWORD dwOptionalLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "f53d9ff7-43b1-452f-a6cb-754d0229ab9a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpSendRequest(HINTERNET hRequest, [MarshalAs(UnmanagedType.LPTStr), Optional] string? lpszHeaders,
		[Optional] uint dwHeadersLength, [Optional] IntPtr lpOptional, [Optional] uint dwOptionalLength);

	/// <summary>
	/// <para>Sends the specified request to the HTTP server.</para>
	/// <note type="note">Callers that need to send extra data beyond what is normally passed to <c>HttpSendRequestEx</c> can do so by
	/// calling HttpSendRequest instead.</note>
	/// </summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest function.</param>
	/// <param name="lpBuffersIn">Optional. A pointer to an INTERNET_BUFFERS structure.</param>
	/// <param name="lpBuffersOut">Reserved. Must be <c>NULL</c>.</param>
	/// <param name="dwFlags">Reserved. Must be zero.</param>
	/// <param name="dwContext">Application-defined context value, if a status callback function has been registered.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>HttpSendRequestEx</c> performs both the send and the receive for the response. This does not allow the application to send
	/// any extra data beyond the single buffer that was passed to <c>HttpSendRequestEx</c>. Callers that need to send extra data beyond
	/// what is normally passed to <c>HttpSendRequestEx</c> can do so by calling HttpSendRequest instead. After the call to
	/// <c>HttpSendRequestEx</c>, send the remaining data by calling InternetWriteFile. Finally, follow up with a call to HttpEndRequest.
	/// </para>
	/// <note type="note">The <c>HttpSendRequestExA</c> function represents data to send as ISO-8859-1 characters not ANSI characters.
	/// The <c>HttpSendRequestExW</c> function represents data to send as ISO-8859-1 characters converted to UTF-16LE characters. As a
	/// result, it is never safe to use the <c>HttpSendRequestExW</c> function when the headers to be added can contain non-ASCII
	/// characters. Instead, an application can use the MultiByteToWideChar and WideCharToMultiByte functions with a Codepage parameter
	/// set to 28591 to map between ANSI characters and UTF-16LE characters.</note><note type="note">WinINet does not support server
	/// implementations. In addition, it should not be used from a service. For server implementations or services use Microsoft Windows
	/// HTTP Services (WinHTTP).</note>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpsendrequestexa BOOLAPI HttpSendRequestExA( HINTERNET
	// hRequest, LPINTERNET_BUFFERSA lpBuffersIn, LPINTERNET_BUFFERSA lpBuffersOut, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "3362fcd2-e8df-4886-9525-bf60589b2c1f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpSendRequestEx(HINTERNET hRequest, in INTERNET_BUFFERS lpBuffersIn, [Optional] IntPtr lpBuffersOut,
		[Optional] uint dwFlags, [Optional] IntPtr dwContext);

	/// <summary>
	/// <para>Sends the specified request to the HTTP server.</para>
	/// <note type="note">Callers that need to send extra data beyond what is normally passed to <c>HttpSendRequestEx</c> can do so by
	/// calling HttpSendRequest instead.</note>
	/// </summary>
	/// <param name="hRequest">A handle returned by a call to the HttpOpenRequest function.</param>
	/// <param name="lpBuffersIn">Optional. A pointer to an INTERNET_BUFFERS structure.</param>
	/// <param name="lpBuffersOut">Reserved. Must be <c>NULL</c>.</param>
	/// <param name="dwFlags">Reserved. Must be zero.</param>
	/// <param name="dwContext">Application-defined context value, if a status callback function has been registered.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>HttpSendRequestEx</c> performs both the send and the receive for the response. This does not allow the application to send
	/// any extra data beyond the single buffer that was passed to <c>HttpSendRequestEx</c>. Callers that need to send extra data beyond
	/// what is normally passed to <c>HttpSendRequestEx</c> can do so by calling HttpSendRequest instead. After the call to
	/// <c>HttpSendRequestEx</c>, send the remaining data by calling InternetWriteFile. Finally, follow up with a call to HttpEndRequest.
	/// </para>
	/// <note type="note">The <c>HttpSendRequestExA</c> function represents data to send as ISO-8859-1 characters not ANSI characters.
	/// The <c>HttpSendRequestExW</c> function represents data to send as ISO-8859-1 characters converted to UTF-16LE characters. As a
	/// result, it is never safe to use the <c>HttpSendRequestExW</c> function when the headers to be added can contain non-ASCII
	/// characters. Instead, an application can use the MultiByteToWideChar and WideCharToMultiByte functions with a Codepage parameter
	/// set to 28591 to map between ANSI characters and UTF-16LE characters.</note><note type="note">WinINet does not support server
	/// implementations. In addition, it should not be used from a service. For server implementations or services use Microsoft Windows
	/// HTTP Services (WinHTTP).</note>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-httpsendrequestexa BOOLAPI HttpSendRequestExA( HINTERNET
	// hRequest, LPINTERNET_BUFFERSA lpBuffersIn, LPINTERNET_BUFFERSA lpBuffersOut, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "3362fcd2-e8df-4886-9525-bf60589b2c1f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpSendRequestEx(HINTERNET hRequest, [Optional] IntPtr lpBuffersIn, [Optional] IntPtr lpBuffersOut,
		[Optional] uint dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Attempts to make a connection to the Internet.</summary>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>Returns ERROR_SUCCESS if successful, or a system error code otherwise.</returns>
	/// <remarks>
	/// <para>
	/// This function allows an application to first attempt to connect before issuing any requests. A client program can use this to
	/// evoke the dial-up dialog box. If the attempt fails, the application should enter offline mode.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetattemptconnect void InternetAttemptConnect( DWORD
	// dwReserved );
	[DllImport(Lib.WinInet, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "a6f22704-f7ca-4c4d-91c3-304b592db6ca")]
	public static extern Win32Error InternetAttemptConnect(uint dwReserved = 0);

	/// <summary>Causes the modem to automatically dial the default Internet connection.</summary>
	/// <param name="dwFlags">
	/// <para>Controls this operation. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_AUTODIAL_FAILIFSECURITYCHECK 0x04</term>
	/// <term>
	/// Causes InternetAutodial to fail if file and printer sharing is disabled for Windows 95 or later. Windows Server 2008 and Windows
	/// Vista: This flag is obsolete.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_AUTODIAL_FORCE_ONLINE 0x01</term>
	/// <term>Forces an online Internet connection.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_AUTODIAL_FORCE_UNATTENDED 0x02</term>
	/// <term>Forces an unattended Internet dial-up.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_AUTODIAL_OVERRIDE_NET_PRESENT 0x08</term>
	/// <term>Causes InternetAutodial to dial the modem connection even when a network connection to the Internet is present.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hwndParent">Handle to the parent window.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. Applications can call GetLastError to retrieve the error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetAutodial</c> does not support double-dial connections, SmartCard authentication, or connections that require
	/// registry-based certification.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting on Windows Vista and Windows Server 2008, the WinINet dial-up functions use the RAS functions to establish
	/// a dial-up connection. WinINet supports the functionality documented in the RasDialDlg function.
	/// </para>
	/// <para>
	/// <c>InternetAutodial</c> does not attempt to dial if there is an existing dial-up connection on the system. Also, if there is an
	/// existing LAN connection, and <c>InternetAutodial</c> is not configured to force dial (set the
	/// <c>INTERNET_AUTODIAL_FORCE_ONLINE</c> in the dwFlags parameter), <c>InternetAutodial</c> does not attempt to dial the connection
	/// and returns <c>TRUE</c>.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetautodial BOOLAPI InternetAutodial( DWORD dwFlags,
	// HWND hwndParent );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "843875a8-6c83-4259-8e46-a04f786eb230")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetAutodial(INTERNET_AUTODIAL dwFlags, HWND hwndParent);

	/// <summary>Disconnects an automatic dial-up connection.</summary>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. Applications can call GetLastError to retrieve the error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetAutoDialHangup</c> returns <c>TRUE</c> if autodial is not enabled, or if autodial is enabled but does not have an
	/// entry configured on the computer.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetautodialhangup BOOLAPI InternetAutodialHangup(
	// DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "8aa8ecb8-cacd-4cd9-a00b-5293b28dd6bf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetAutodialHangup(uint dwReserved = 0);

	/// <summary>Canonicalizes a URL, which includes converting unsafe characters and spaces into escape sequences.</summary>
	/// <param name="lpszUrl">A pointer to the string that contains the URL to canonicalize.</param>
	/// <param name="lpszBuffer">A pointer to the buffer that receives the resulting canonicalized URL.</param>
	/// <param name="lpdwBufferLength">
	/// A pointer to a variable that contains the size, in characters, of the lpszBuffer buffer. If the function succeeds, this
	/// parameter receives the number of characters actually copied to the lpszBuffer buffer, which does not include the terminating
	/// null character. If the function fails, this parameter receives the required size of the buffer, in characters, which includes
	/// the terminating null character.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Controls canonicalization. If no flags are specified, the function converts all unsafe characters and meta sequences (such as
	/// .,\ .., and ...) to escape sequences. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICU_BROWSER_MODE</term>
	/// <term>
	/// Does not encode or decode characters after "#" or "?", and does not remove trailing white space after "?". If this value is not
	/// specified, the entire URL is encoded and trailing white space is removed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICU_DECODE</term>
	/// <term>Converts all %XX sequences to characters, including escape sequences, before the URL is parsed.</term>
	/// </item>
	/// <item>
	/// <term>ICU_ENCODE_PERCENT</term>
	/// <term>
	/// Encodes any percent signs encountered. By default, percent signs are not encoded. This value is available in Microsoft Internet
	/// Explorer 5 and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICU_ENCODE_SPACES_ONLY</term>
	/// <term>Encodes spaces only.</term>
	/// </item>
	/// <item>
	/// <term>ICU_NO_ENCODE</term>
	/// <term>Does not convert unsafe characters to escape sequences.</term>
	/// </item>
	/// <item>
	/// <term>ICU_NO_META</term>
	/// <term>Does not remove meta sequences (such as "." and "..") from the URL.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call the GetLastError function.
	/// Possible errors include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_PATHNAME</term>
	/// <term>The URL could not be canonicalized.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The canonicalized URL is too large to fit in the buffer provided. The lpdwBufferLength parameter is set to the size, in bytes,
	/// of the buffer required to hold the canonicalized URL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_INVALID_URL</term>
	/// <term>The format of the URL is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>There is an invalid string, buffer, buffer size, or flags parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In Internet Explorer 4.0 and later, <c>InternetCanonicalizeUrl</c> always functions as if the <c>ICU_BROWSER_MODE</c> flag is
	/// set. Client applications that must canonicalize the entire URL should use either CoInternetParseUrl (with the action
	/// <c>PARSE_CANONICALIZE</c> and the flag <c>URL_ESCAPE_UNSAFE</c>) or UrlCanonicalize.
	/// </para>
	/// <para>
	/// <c>InternetCanonicalizeUrl</c> always encodes by default, even if the <c>ICU_DECODE</c> flag has been specified. To decode
	/// without reencoding, use <c>ICU_DECODE</c> | <c>ICU_NO_ENCODE</c>. If the <c>ICU_DECODE</c> flag is used without
	/// <c>ICU_NO_ENCODE</c>, the URL is decoded before being parsed; unsafe characters are then re-encoded after parsing. This function
	/// handles arbitrary protocol schemes, but to do so it must make inferences from the unsafe character set.
	/// </para>
	/// <para>
	/// Applications that call <c>InternetCanonicalizeUrl</c> when using Internet Explorer 3.0 (or when setting the
	/// <c>ICU_ENCODE_PERCENT</c> flag for Internet Explorer 5 and later) should track the usage of this function on a particular URL.
	/// If unsafe characters in a URL have been converted to escape sequences, using <c>InternetCanonicalizeUrl</c> again on the URL
	/// (with no flags) causes the escape sequences to be converted to another escape sequence. For example, a blank space in a URL
	/// would be converted to the escape sequence %20. Calling <c>InternetCanonicalizeUrl</c> again on the URL would cause the escape
	/// sequence %20 to be converted to the escape sequence %2520, because the % sign is an unsafe character that is reserved for escape
	/// sequences and is replaced by the function with the escape sequence %25.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetcanonicalizeurla BOOLAPI InternetCanonicalizeUrlA(
	// LPCSTR lpszUrl, LPSTR lpszBuffer, LPDWORD lpdwBufferLength, DWORD dwFlags );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "3bfde980-e478-4960-b41f-e1c8105ef419")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetCanonicalizeUrl(string lpszUrl, StringBuilder lpszBuffer, ref uint lpdwBufferLength, ICU dwFlags);

	/// <summary>
	/// <para>
	/// [ <c>InternetCheckConnection</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions. Instead, use NetworkInformation.GetInternetConnectionProfile or the NLM
	/// Interfaces. ]
	/// </para>
	/// <para>Allows an application to check if a connection to the Internet can be established.</para>
	/// </summary>
	/// <param name="lpszUrl">
	/// Pointer to a <c>null</c>-terminated string that specifies the URL to use to check the connection. This value can be <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Options. FLAG_ICC_FORCE_CONNECTION is the only flag that is currently available. If this flag is set, it forces a connection. A
	/// sockets connection is attempted in the following order:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If lpszUrl is non- <c>NULL</c>, the host value is extracted from it and used to ping that specific host.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If lpszUrl is <c>NULL</c> and there is an entry in the internal server database for the nearest server, the host value is
	/// extracted from the entry and used to ping that server.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if a connection is made successfully, or <c>FALSE</c> otherwise. Use GetLastError to retrieve the error
	/// code. ERROR_NOT_CONNECTED is returned by <c>GetLastError</c> if a connection cannot be made or if the sockets database is
	/// unconditionally offline.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetCheckConnection</c> is deprecated. <c>InternetCheckConnection</c> does not work in environments that use a web proxy
	/// server to access the Internet. Depending on the environment, use NetworkInformation.GetInternetConnectionProfile or the NLM
	/// Interfaces to check for Internet access instead.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetcheckconnectiona BOOLAPI InternetCheckConnectionA(
	// LPCSTR lpszUrl, DWORD dwFlags, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "4666e4ee-057e-452d-ac2c-d03321a0073f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetCheckConnection([Optional] string? lpszUrl, [Optional] FLAG_ICC dwFlags, uint dwReserved = 0);

	/// <summary>Clears all decisions that were made about cookies on a site by site basis.</summary>
	/// <returns>Returns <c>TRUE</c> if all decisions were cleared and <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetclearallpersitecookiedecisions BOOLAPI
	// InternetClearAllPerSiteCookieDecisions( );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "980df63e-70b8-44d3-b98a-b7c8a3e395c6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetClearAllPerSiteCookieDecisions();

	/// <summary>Closes a single Internet handle.</summary>
	/// <param name="hInternet">Handle to be closed.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the handle is successfully closed, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>The function terminates any pending operations on the handle and discards any outstanding data.</para>
	/// <para>
	/// It is safe to call <c>InternetCloseHandle</c> as long as no API calls are being made or will be made using the handle. Once an
	/// API has returned <c>ERROR_IO_PENDING</c>, it is safe to call <c>InternetCloseHandle</c> to cancel that I/O, as long as no
	/// subsequent API calls will be issued with the handle.
	/// </para>
	/// <para>
	/// It is safe to call <c>InternetCloseHandle</c> in a callback for the handle being closed. If there is a status callback
	/// registered for the handle being closed, and the handle was created with a non-NULL context value, an
	/// <c>INTERNET_STATUS_HANDLE_CLOSING</c> callback will be made. This indication will be the last callback made from a handle and
	/// indicates that the handle is being destroyed.
	/// </para>
	/// <para>
	/// If asynchronous requests are pending for the handle or any of its child handles, the handle cannot be closed immediately, but it
	/// will be invalidated. Any new requests attempted using the handle will return with an ERROR_INVALID_HANDLE notification. The
	/// asynchronous requests will complete with <c>INTERNET_STATUS_REQUEST_COMPLETE</c>. Applications must be prepared to receive any
	/// <c>INTERNET_STATUS_REQUEST_COMPLETE</c> indications on the handle before the final <c>INTERNET_STATUS_HANDLE_CLOSING</c>
	/// indication is made, which indicates that the handle is completely closed.
	/// </para>
	/// <para>
	/// An application can call GetLastError to determine if requests are pending. If <c>GetLastError</c> returns
	/// <c>ERROR_IO_PENDING</c>, there were outstanding requests when the handle was closed.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetclosehandle BOOLAPI InternetCloseHandle( HINTERNET
	// hInternet );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "52b57e3c-3cfe-40bc-b87b-90cf39c5c38d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetCloseHandle(HINTERNET hInternet);

	/// <summary>
	/// Checks for changes between secure and nonsecure URLs. Always inform the user when a change occurs in security between two URLs.
	/// Typically, an application should allow the user to acknowledge the change through interaction with a dialog box.
	/// </summary>
	/// <param name="hWnd">Handle to the parent window for any required dialog box.</param>
	/// <param name="szUrlPrev">
	/// Pointer to a null-terminated string that specifies the URL that was viewed before the current request was made.
	/// </param>
	/// <param name="szUrlNew">Pointer to a null-terminated string that specifies the new URL that the user has requested to view.</param>
	/// <param name="bPost">Not implemented.</param>
	/// <returns>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The user confirmed that it was okay to continue, or there was no user input required.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>The user canceled the request.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There is not enough memory to carry out the request.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Always inform the user when a change in security level occurs, or you risk subjecting the user to involuntary information disclosure.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetconfirmzonecrossing void
	// InternetConfirmZoneCrossing( HWND hWnd, LPSTR szUrlPrev, LPSTR szUrlNew, BOOL bPost );
	[DllImport(Lib.WinInet, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "e14f58df-5457-4a17-919c-6a25691c2ee1")]
	public static extern Win32Error InternetConfirmZoneCrossing(HWND hWnd, string szUrlPrev, string szUrlNew, [MarshalAs(UnmanagedType.Bool)] bool bPost = false);

	/// <summary>Opens an File Transfer Protocol (FTP) or HTTP session for a given site.</summary>
	/// <param name="hInternet">Handle returned by a previous call to InternetOpen.</param>
	/// <param name="lpszServerName">
	/// Pointer to a <c>null</c>-terminated string that specifies the host name of an Internet server. Alternately, the string can
	/// contain the IP number of the site, in ASCII dotted-decimal format (for example, 11.0.1.45).
	/// </param>
	/// <param name="nServerPort">
	/// <para>
	/// Transmission Control Protocol/Internet Protocol (TCP/IP) port on the server. These flags set only the port that is used. The
	/// service is set by the value of dwService. This parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_DEFAULT_FTP_PORT</term>
	/// <term>Uses the default port for FTP servers (port 21).</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DEFAULT_GOPHER_PORT</term>
	/// <term>Uses the default port for Gopher servers (port 70).</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DEFAULT_HTTP_PORT</term>
	/// <term>Uses the default port for HTTP servers (port 80).</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DEFAULT_HTTPS_PORT</term>
	/// <term>Uses the default port for Secure Hypertext Transfer Protocol (HTTPS) servers (port 443).</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DEFAULT_SOCKS_PORT</term>
	/// <term>Uses the default port for SOCKS firewall servers (port 1080).</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_INVALID_PORT_NUMBER</term>
	/// <term>Uses the default port for the service specified by dwService.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszUserName">
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the user to log on. If this parameter is <c>NULL</c>, the
	/// function uses an appropriate default. For the FTP protocol, the default is "anonymous".
	/// </param>
	/// <param name="lpszPassword">
	/// Pointer to a <c>null</c>-terminated string that contains the password to use to log on. If both lpszPassword and lpszUsername
	/// are <c>NULL</c>, the function uses the default "anonymous" password. In the case of FTP, the default password is the user's
	/// email name. If lpszPassword is <c>NULL</c>, but lpszUsername is not <c>NULL</c>, the function uses a blank password.
	/// </param>
	/// <param name="dwService">
	/// <para>Type of service to access. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_SERVICE_FTP</term>
	/// <term>FTP service.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_SERVICE_GOPHER</term>
	/// <term>Gopher service.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_SERVICE_HTTP</term>
	/// <term>HTTP service.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// Options specific to the service used. If dwService is INTERNET_SERVICE_FTP, INTERNET_FLAG_PASSIVE causes the application to use
	/// passive FTP semantics.
	/// </param>
	/// <param name="dwContext">
	/// Pointer to a variable that contains an application-defined value that is used to identify the application context for the
	/// returned handle in callbacks.
	/// </param>
	/// <returns>
	/// Returns a valid handle to the session if the connection is successful, or <c>NULL</c> otherwise. To retrieve extended error
	/// information, call GetLastError. An application can also use InternetGetLastResponseInfo to determine why access to the service
	/// was denied.
	/// </returns>
	/// <remarks>
	/// <para>The following table describes the behavior for the four possible settings of lpszUsername and lpszPassword.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>lpszUsername</term>
	/// <term>lpszPassword</term>
	/// <term>User name sent to FTP server</term>
	/// <term>Password sent to FTP server</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>"anonymous"</term>
	/// <term>User's email name</term>
	/// </item>
	/// <item>
	/// <term>Non-NULL string</term>
	/// <term>NULL</term>
	/// <term>lpszUsername</term>
	/// <term>""</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>Non-NULL string</term>
	/// <term>ERROR</term>
	/// <term>ERROR</term>
	/// </item>
	/// <item>
	/// <term>Non-NULL string</term>
	/// <term>Non-NULL string</term>
	/// <term>lpszUsername</term>
	/// <term>lpszPassword</term>
	/// </item>
	/// </list>
	/// <para>
	/// For FTP sites, <c>InternetConnect</c> actually establishes a connection with the server; for others, the actual connection is
	/// not established until the application requests a specific transaction.
	/// </para>
	/// <para>
	/// For maximum efficiency, applications using the HTTP protocols should try to minimize calls to <c>InternetConnect</c> and avoid
	/// calling this function for every transaction requested by the user. One way to accomplish this is to keep a small cache of
	/// handles returned from <c>InternetConnect</c>; when the user makes a request to a previously accessed server, that session handle
	/// is still available.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>InternetConnect</c>, it must be closed
	/// using the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// <c>Note</c> When a request is sent asynchronous mode (the dwFlags parameter of InternetOpen specifies
	/// <c>INTERNET_FLAG_ASYNC</c>), and the dwContext parameter is zero ( <c>INTERNET_NO_CALLBACK</c>), the callback function set with
	/// InternetSetStatusCallback on the connection handle will not be called, however, the call will still be performed in asynchronous mode.
	/// </para>
	/// <para>Examples of <c>InternetConnect</c> usage can be found in the following topics.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Handling Authentication</term>
	/// </item>
	/// <item>
	/// <term>Asynchronous Example Application</term>
	/// </item>
	/// </list>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetconnecta void InternetConnectA( HINTERNET
	// hInternet, LPCSTR lpszServerName, INTERNET_PORT nServerPort, LPCSTR lpszUserName, LPCSTR lpszPassword, DWORD dwService, DWORD
	// dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "42b5d733-dccd-4c9d-8820-e358e033077c")]
	public static extern SafeHINTERNET InternetConnect(HINTERNET hInternet, string lpszServerName, [Optional] INTERNET_PORT nServerPort,
		[Optional] string? lpszUserName, [Optional] string? lpszPassword, InternetService dwService, [Optional] InternetApiFlags dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Cracks a URL into its component parts.</summary>
	/// <param name="lpszUrl">Pointer to a string that contains the canonical URL to be cracked.</param>
	/// <param name="dwUrlLength">Size of the lpszUrl string, in <c>TCHARs</c>, or zero if lpszUrl is an ASCIIZ string.</param>
	/// <param name="dwFlags">
	/// <para>Controls the operation. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICU_DECODE</term>
	/// <term>
	/// Converts encoded characters back to their normal form. This can be used only if the user provides buffers in the URL_COMPONENTS
	/// structure to copy the components into.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICU_ESCAPE</term>
	/// <term>
	/// Converts all escape sequences (%xx) to their corresponding characters. This can be used only if the user provides buffers in the
	/// URL_COMPONENTS structure to copy the components into.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpUrlComponents">Pointer to a URL_COMPONENTS structure that receives the URL components.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The required components are indicated by members of the URL_COMPONENTS structure. Each component has a pointer to the value and
	/// has a member that stores the length of the stored value. If both the value and the length for a component are equal to zero,
	/// that component is not returned. <c>Windows Vista and later.:</c> If the pointer to the value of the component is <c>NULL</c> and
	/// the value of its corresponding length member is nonzero, the address of the first character of the corresponding component in
	/// the lpszUrl string is stored in the pointer, and the length of the component is stored in the length member.
	/// </para>
	/// <para>
	/// If the pointer contains the address of the user-supplied buffer, the length member must contain the size of the buffer.
	/// <c>InternetCrackUrl</c> copies the component into the buffer, and the length member is set to the length of the copied
	/// component, minus 1 for the trailing string terminator.
	/// </para>
	/// <para>
	/// For <c>InternetCrackUrl</c> to work properly, the size of the URL_COMPONENTS structure, in bytes, must be stored in the
	/// <c>dwStructSize</c> member.
	/// </para>
	/// <para>
	/// <c>Note</c> Do not use <c>InternetCrackUrl</c> on "file://" URLs that contain spaces, because the value returned in the
	/// <c>dwUrlPathLength</c> member of the URL_COMPONENTS structure pointed to by lpUrlComponents is too large. This is only the case,
	/// however, with "file://" URLs that contain space characters.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetcrackurla BOOLAPI InternetCrackUrlA( LPCSTR
	// lpszUrl, DWORD dwUrlLength, DWORD dwFlags, LPURL_COMPONENTSA lpUrlComponents );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "30677071-3eb2-4d9c-a0a3-ff11a077f98a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetCrackUrl(string lpszUrl, uint dwUrlLength, ICU dwFlags, ref URL_COMPONENTS lpUrlComponents);

	/// <summary>Creates a URL from its component parts.</summary>
	/// <param name="lpUrlComponents">Pointer to a URL_COMPONENTS structure that contains the components from which to create the URL.</param>
	/// <param name="dwFlags">
	/// <para>Controls the operation of this function. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICU_ESCAPE</term>
	/// <term>
	/// Converts all unsafe characters to their corresponding escape sequences in the path string pointed to by the lpszUrlPath member
	/// and in lpszExtraInfo the extra-information string pointed to by the member of the URL_COMPONENTS structure pointed to by the
	/// lpUrlComponents parameter. The Unicode version of InternetCreateUrl will first try to convert using the system code page. If
	/// that fails it falls back to UTF-8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICU_USERNAME</term>
	/// <term>Obsolete — ignored.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszUrl">Pointer to a buffer that receives the URL.</param>
	/// <param name="lpdwUrlLength">
	/// Pointer to a variable that specifies the size of the URLlpszUrl buffer, in <c>TCHARs</c>. When the function returns, this
	/// parameter receives the size of the URL string, excluding the NULL terminator. If GetLastError returns ERROR_INSUFFICIENT_BUFFER,
	/// this parameter receives the number of bytes required to hold the created URL.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// When specifying scheme in the URL_COMPONENTS structure passed to lpUrlComponents, if lpszScheme is not NULL it will be used for
	/// the scheme. If lpszScheme is NULL, the scheme can be specified using the INTERNET_SCHEME enumeration by setting <c>nScheme</c>
	/// to the required <c>INTERNET_SCHEME</c> or <c>INTERNET_SCHEME_DEFAULT</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetcreateurla BOOLAPI InternetCreateUrlA(
	// LPURL_COMPONENTSA lpUrlComponents, DWORD dwFlags, LPSTR lpszUrl, LPDWORD lpdwUrlLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "b01bb684-0b2f-4c17-ab32-9f83fdd89e69")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetCreateUrl(ref URL_COMPONENTS lpUrlComponents, ICU dwFlags, StringBuilder lpszUrl, ref uint lpdwUrlLength);

	/// <summary>Creates a URL from its component parts.</summary>
	/// <param name="lpUrlComponents">Pointer to a URL_COMPONENTS structure that contains the components from which to create the URL.</param>
	/// <param name="dwFlags">
	/// <para>Controls the operation of this function. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ICU_ESCAPE</term>
	/// <term>
	/// Converts all unsafe characters to their corresponding escape sequences in the path string pointed to by the lpszUrlPath member
	/// and in lpszExtraInfo the extra-information string pointed to by the member of the URL_COMPONENTS structure pointed to by the
	/// lpUrlComponents parameter. The Unicode version of InternetCreateUrl will first try to convert using the system code page. If
	/// that fails it falls back to UTF-8.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ICU_USERNAME</term>
	/// <term>Obsolete — ignored.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszUrl">Pointer to a buffer that receives the URL.</param>
	/// <param name="lpdwUrlLength">
	/// Pointer to a variable that specifies the size of the URLlpszUrl buffer, in <c>TCHARs</c>. When the function returns, this
	/// parameter receives the size of the URL string, excluding the NULL terminator. If GetLastError returns ERROR_INSUFFICIENT_BUFFER,
	/// this parameter receives the number of bytes required to hold the created URL.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// When specifying scheme in the URL_COMPONENTS structure passed to lpUrlComponents, if lpszScheme is not NULL it will be used for
	/// the scheme. If lpszScheme is NULL, the scheme can be specified using the INTERNET_SCHEME enumeration by setting <c>nScheme</c>
	/// to the required <c>INTERNET_SCHEME</c> or <c>INTERNET_SCHEME_DEFAULT</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetcreateurla BOOLAPI InternetCreateUrlA(
	// LPURL_COMPONENTSA lpUrlComponents, DWORD dwFlags, LPSTR lpszUrl, LPDWORD lpdwUrlLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "b01bb684-0b2f-4c17-ab32-9f83fdd89e69")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetCreateUrl(ref URL_COMPONENTS lpUrlComponents, ICU dwFlags, IntPtr lpszUrl, ref uint lpdwUrlLength);

	/// <summary>Initiates a connection to the Internet using a modem.</summary>
	/// <param name="hwndParent">Handle to the parent window.</param>
	/// <param name="lpszConnectoid">
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the dial-up connection to be used. If this parameter
	/// contains the empty string (""), the user chooses the connection. If this parameter is <c>NULL</c>, the function connects to the
	/// autodial connection.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Options. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_AUTODIAL_FORCE_ONLINE</term>
	/// <term>Forces an online connection.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_AUTODIAL_FORCE_UNATTENDED</term>
	/// <term>Forces an unattended Internet dial-up. If user intervention is required, the function will fail.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DIAL_FORCE_PROMPT</term>
	/// <term>Ignores the "dial automatically" setting and forces the dialing user interface to be displayed.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DIAL_UNATTENDED</term>
	/// <term>
	/// Connects to the Internet through a modem, without displaying a user interface, if possible. Otherwise, the function will wait
	/// for user input.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_DIAL_SHOW_OFFLINE</term>
	/// <term>Shows the Work Offline button instead of the Cancel button in the dialing user interface.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpdwConnection">
	/// Pointer to a variable that specifies the connection number. This number is a unique indentifier for the connection that can be
	/// used in other functions, such as InternetHangUp.
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise. The error code can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters are incorrect.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_CONNECTION</term>
	/// <term>There is a problem with the dial-up connection.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_USER_DISCONNECTION</term>
	/// <term>The user clicked either the Work Offline or Cancel button on the Internet connection dialog box.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetDial</c> does not support double-dial connections, SmartCard authentication, or connections that require
	/// registry-based certification.
	/// </para>
	/// <para>
	/// <c>Note</c> Starting on Windows Vista and Windows Server 2008, the WinINet dial-up functions use the RAS functions to establish
	/// a dial-up connection. WinINet supports the functionality documented in the RasDialDlg function.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetdial void InternetDial( HWND hwndParent, LPSTR
	// lpszConnectoid, DWORD dwFlags, LPDWORD lpdwConnection, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "b8ce748b-9879-4f68-aea1-32e2bfaee8ab")]
	public static extern Win32Error InternetDial(HWND hwndParent, [Optional] string? lpszConnectoid, INTERNET_DIAL dwFlags, out uint lpdwConnection, uint dwReserved = 0);

	/// <summary>Retrieves the domains and cookie settings of websites for which site-specific cookie regulations are set.</summary>
	/// <param name="pszSiteName">An <c>LPSTR</c> that receives a string specifying a website domain.</param>
	/// <param name="pcSiteNameSize">
	/// A pointer to an unsigned long that specifies the size of the pcSiteNameSize parameter provided to the
	/// InternetEnumPerSiteCookieDecision function when it is called. When <c>InternetEnumPerSiteCookieDecision</c> returns,
	/// pcSiteNameSize receives the actual length of the domain string returned in pszSiteName.
	/// </param>
	/// <param name="pdwDecision">
	/// Pointer to an unsigned long that receives the InternetCookieState enumeration value corresponding to pszSiteName.
	/// </param>
	/// <param name="dwIndex">An unsigned long that specifies the index of the website and corresponding cookie setting to retrieve.</param>
	/// <returns><c>TRUE</c> if the function retrieved the cookie setting for the given domain; otherwise, false. <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>
	/// <c>InternetEnumPerSiteCookieDecision</c> should be initially called with dwIndex equal to 0. Incrementing the dwIndex parameter
	/// steps through the list of websites and cookie settings. The end of the list is reached when
	/// <c>InternetEnumPerSiteCookieDecision</c> returns <c>FALSE</c> and produces the wininet error, <c>ERROR_NO_MORE_ITEMS</c>.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetenumpersitecookiedecisiona BOOLAPI
	// InternetEnumPerSiteCookieDecisionA( LPSTR pszSiteName, unsigned long *pcSiteNameSize, unsigned long *pdwDecision, unsigned long
	// dwIndex );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "de1db7e6-21f4-4bbb-b4fc-277bbd01f32c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetEnumPerSiteCookieDecision(StringBuilder pszSiteName, ref uint pcSiteNameSize, out InternetCookieState pdwDecision, uint dwIndex);

	/// <summary>
	/// Displays a dialog box for the error that is passed to <c>InternetErrorDlg</c>, if an appropriate dialog box exists. If the
	/// <c>FLAGS_ERROR_UI_FILTER_FOR_ERRORS</c> flag is used, the function also checks the headers for any hidden errors and displays a
	/// dialog box if needed.
	/// </summary>
	/// <param name="hWnd">
	/// Handle to the parent window for any needed dialog box. If no dialog box is needed and <c>FLAGS_ERROR_UI_FLAGS_NO_UI</c> is
	/// passed to dwFlags, then this parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="hRequest">Handle to the Internet connection used in the call to HttpSendRequest.</param>
	/// <param name="dwError">
	/// <para>Error value for which to display a dialog box. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_HTTP_REDIRECT_NEEDS_CONFIRMATION</term>
	/// <term>Allows the user to confirm the redirect.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_BAD_AUTO_PROXY_SCRIPT</term>
	/// <term>Displays a dialog indicating that the auto proxy script is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_CHG_POST_IS_NON_SECURE</term>
	/// <term>Displays a dialog asking the user whether to post the given data on a non-secure channel.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED</term>
	/// <term>
	/// The server is requesting a client certificate. The return value for this error is always ERROR_SUCCESS, regardless of whether or
	/// not the user has selected a certificate. If the user has not selected a certificate then anonymous client authentication will be
	/// attempted on the subsequent request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR</term>
	/// <term>Notifies the user of the zone crossing to a secure site.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR</term>
	/// <term>Notifies the user of the zone crossing from a secure site.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_HTTPS_HTTP_SUBMIT_REDIR</term>
	/// <term>Notifies the user that the data being posted is now being redirected to a non-secure site.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_INCORRECT_PASSWORD</term>
	/// <term>Displays a dialog box requesting the user's name and password.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_INVALID_CA</term>
	/// <term>
	/// Indicates that the SSL certificate Common Name (host name field) is incorrect. Displays an Invalid SSL Common Name dialog box
	/// and lets the user view the incorrect certificate.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_MIXED_SECURITY</term>
	/// <term>Displays a warning to the user concerning mixed secure and non-secure content.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_POST_IS_NON_SECURE</term>
	/// <term>Displays a dialog asking the user whether to post the given data on a non-secure channel.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_CN_INVALID</term>
	/// <term>
	/// Indicates that the SSL certificate Common Name (host name field) is incorrect. Displays an Invalid SSL Common Name dialog box
	/// and lets the user view the incorrect certificate. Also allows the user to select a certificate in response to a server request.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_ERRORS</term>
	/// <term>Displays a warning to the user showing the issues with the server certificate.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_DATE_INVALID</term>
	/// <term>Tells the user that the SSL certificate has expired.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_REV_FAILED</term>
	/// <term>Displays a warning to the user showing that the server certificate’s revocation check failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_REVOKED</term>
	/// <term>Displays a dialog indicating that the server certificate is revoked.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_UNABLE_TO_DOWNLOAD_SCRIPT</term>
	/// <term>Displays a dialog indicating that the auto proxy script could not be downloaded.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Actions. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FLAGS_ERROR_UI_FILTER_FOR_ERRORS</term>
	/// <term>
	/// Scans the returned headers for errors. Call InternetErrorDlg with this flag set following a call to HttpSendRequest so as to
	/// detect hidden errors. Authentication errors, for example, are normally hidden because the call to HttpSendRequest completes
	/// successfully, but by scanning the status codes, InternetErrorDlg can determine that the proxy or server requires authentication.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FLAGS_ERROR_UI_FLAGS_CHANGE_OPTIONS</term>
	/// <term>If the function succeeds, stores the results of the dialog box in the Internet handle.</term>
	/// </item>
	/// <item>
	/// <term>FLAGS_ERROR_UI_FLAGS_GENERATE_DATA</term>
	/// <term>
	/// Queries the Internet handle for needed information. The function constructs the appropriate data structure for the error. (For
	/// example, for Cert CN failures, the function grabs the certificate.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>FLAGS_ERROR_UI_SERIALIZE_DIALOGS</term>
	/// <term>
	/// Serializes authentication dialog boxes for concurrent requests on a password cache entry. The lppvData parameter should contain
	/// the address of a pointer to an INTERNET_AUTH_NOTIFY_DATA structure, and the client should implement a thread-safe, non-blocking
	/// callback function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FLAGS_ERROR_UI_FLAGS_NO_UI</term>
	/// <term>
	/// Allows the caller to pass NULL to the hWnd parameter without error. To be used in circumstances in which no user interface is required.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lppvData">
	/// Pointer to the address of a data structure. The structure can be different for each error that needs to be handled.
	/// </param>
	/// <returns>
	/// <para>Returns one of the following values, or an error value otherwise.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully. For more information, see ERROR_INTERNET_CLIENT_AUTH_CERT_NEEDED in the dwError parameter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>The function was canceled by the user.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_FORCE_RETRY</term>
	/// <term>
	/// This indicates that the function needs to redo its request. In the case of authentication this indicates that the user clicked
	/// the OK button.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle to the parent window is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Always inform the user when any of the following events occur:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_INVALID_CA</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_POST_IS_NON_SECURE</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_CN_INVALID</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INTERNET_SEC_CERT_DATE_INVALID</term>
	/// </item>
	/// </list>
	/// <para>
	/// Unless the user has explicitly chosen not to be informed of these events, failure to do so exposes the user involuntarily to a
	/// significant security risk.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-interneterrordlg void InternetErrorDlg( HWND hWnd,
	// HINTERNET hRequest, DWORD dwError, DWORD dwFlags, LPVOID *lppvData );
	[DllImport(Lib.WinInet, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "09384ba9-e5cc-48fd-a52c-15df223f87dc")]
	public static extern Win32Error InternetErrorDlg([Optional] HWND hWnd, HINTERNET hRequest, Win32Error dwError, FLAGS_ERROR_UI dwFlags, in IntPtr lppvData);

	/// <summary>
	/// <para>Continues a file search started as a result of a previous call to FtpFindFirstFile.</para>
	/// <para>
	/// <c>Windows XP and Windows Server 2003 R2 and earlier:</c> Or continues a file search as a result of a previous call to GopherFindFirstFile.
	/// </para>
	/// </summary>
	/// <param name="hFind">
	/// <para>Handle returned from either FtpFindFirstFile or InternetOpenUrl (directories only).</para>
	/// <para><c>Windows XP and Windows Server 2003 R2 and earlier:</c> Also a handle returned from GopherFindFirstFile.</para>
	/// </param>
	/// <param name="lpvFindData">
	/// <para>
	/// Pointer to the buffer that receives information about the file or directory. The format of the information placed in the buffer
	/// depends on the protocol in use. The FTP protocol returns a WIN32_FIND_DATA structure.
	/// </para>
	/// <para><c>Windows XP and Windows Server 2003 R2 and earlier:</c> The Gopher protocol returns a GOPHER_FIND_DATA structure.</para>
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// If the function finds no matching files, <c>GetLastError</c> returns <c>ERROR_NO_MORE_FILES</c>.
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetfindnextfilea BOOLAPI InternetFindNextFileA(
	// HINTERNET hFind, LPVOID lpvFindData );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "7c53e399-b8a5-4cc0-9ef6-88d9a525d87f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetFindNextFile(HINTERNET hFind, IntPtr lpvFindData);

	/// <summary>
	/// <para>Continues a file search started as a result of a previous call to FtpFindFirstFile.</para>
	/// <para>
	/// <c>Windows XP and Windows Server 2003 R2 and earlier:</c> Or continues a file search as a result of a previous call to GopherFindFirstFile.
	/// </para>
	/// </summary>
	/// <param name="hFind">
	/// <para>Handle returned from either FtpFindFirstFile or InternetOpenUrl (directories only).</para>
	/// <para><c>Windows XP and Windows Server 2003 R2 and earlier:</c> Also a handle returned from GopherFindFirstFile.</para>
	/// </param>
	/// <param name="lpvFindData">
	/// <para>
	/// Pointer to the buffer that receives information about the file or directory. The format of the information placed in the buffer
	/// depends on the protocol in use. The FTP protocol returns a WIN32_FIND_DATA structure.
	/// </para>
	/// <para><c>Windows XP and Windows Server 2003 R2 and earlier:</c> The Gopher protocol returns a GOPHER_FIND_DATA structure.</para>
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// If the function finds no matching files, <c>GetLastError</c> returns <c>ERROR_NO_MORE_FILES</c>.
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetfindnextfilea BOOLAPI InternetFindNextFileA(
	// HINTERNET hFind, LPVOID lpvFindData );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "7c53e399-b8a5-4cc0-9ef6-88d9a525d87f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetFindNextFile(HINTERNET hFind, out WIN32_FIND_DATA lpvFindData);

	/// <summary>
	/// <note>Using this API is not recommended, use the INetworkListManager::GetConnectivity method instead.</note>
	/// <para>Retrieves the connected state of the local system.</para>
	/// </summary>
	/// <param name="lpdwFlags">
	/// <para>
	/// Pointer to a variable that receives the connection description. This parameter may return a valid flag even when the function
	/// returns <c>FALSE</c>. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_CONNECTION_CONFIGURED 0x40</term>
	/// <term>Local system has a valid connection to the Internet, but it might or might not be currently connected.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_LAN 0x02</term>
	/// <term>Local system uses a local area network to connect to the Internet.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_MODEM 0x01</term>
	/// <term>Local system uses a modem to connect to the Internet.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_MODEM_BUSY 0x08</term>
	/// <term>No longer used.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_OFFLINE 0x20</term>
	/// <term>Local system is in offline mode.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_PROXY 0x04</term>
	/// <term>Local system uses a proxy server to connect to the Internet.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_RAS_INSTALLED 0x10</term>
	/// <term>Local system has RAS installed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if there is an active modem or a LAN Internet connection, or <c>FALSE</c> if there is no Internet
	/// connection, or if all possible Internet connections are not currently active. For more information, see the Remarks section.
	/// </para>
	/// <para>
	/// When <c>InternetGetConnectedState</c> returns <c>FALSE</c>, the application can call GetLastError to retrieve the error code.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A return value of <c>TRUE</c> from <c>InternetGetConnectedState</c> indicates that at least one connection to the Internet is
	/// available. It does not guarantee that a connection to a specific host can be established. Applications should always check for
	/// errors returned from API calls that connect to a server. InternetCheckConnection can be called to determine if a connection to a
	/// specific destination can be established.
	/// </para>
	/// <para>
	/// A return value of <c>TRUE</c> indicates that either the modem connection is active, or a LAN connection is active and a proxy is
	/// properly configured for the LAN. A return value of <c>FALSE</c> indicates that neither the modem nor the LAN is connected. If
	/// <c>FALSE</c> is returned, the <c>INTERNET_CONNECTION_CONFIGURED</c> flag may be set to indicate that autodial is configured to
	/// "always dial" but is not currently active. If autodial is not configured, the function returns <c>FALSE</c>.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetconnectedstate BOOLAPI
	// InternetGetConnectedState( LPDWORD lpdwFlags, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "500765b8-fbe4-4bba-894e-cc7f114d9eaa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetConnectedState(out INTERNET_CONNECTION lpdwFlags, uint dwReserved = 0);

	/// <summary>
	/// <summary>
	/// <note>Using this API is not recommended, use the INetworkListManager::GetConnectivity method instead.</note>
	/// <para>Retrieves the connected state of the specified Internet connection.</para>
	/// </summary>
	/// </summary>
	/// <param name="lpdwFlags">
	/// <para>
	/// Pointer to a variable that receives the connection description. This parameter may return a valid flag even when the function
	/// returns <c>FALSE</c>. This parameter can be a combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_CONNECTION_CONFIGURED 0x40</term>
	/// <term>Local system has a valid connection to the Internet, but it might or might not be currently connected.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_LAN 0x02</term>
	/// <term>Local system uses a local area network to connect to the Internet.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_MODEM 0x01</term>
	/// <term>Local system uses a modem to connect to the Internet.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_MODEM_BUSY 0x08</term>
	/// <term>No longer used.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_OFFLINE 0x20</term>
	/// <term>Local system is in offline mode.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CONNECTION_PROXY 0x04</term>
	/// <term>Local system uses a proxy server to connect to the Internet.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszConnectionName">Pointer to a string value that receives the connection name.</param>
	/// <param name="dwNameLen">Size of the lpszConnectionName string, in <c>TCHARs</c>.</param>
	/// <param name="dwReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if there is an Internet connection, or <c>FALSE</c> if there is no Internet connection, or if all possible
	/// Internet connections are not currently active. For more information, see the Remarks section.
	/// </para>
	/// <para>When InternetGetConnectedState returns <c>FALSE</c>, the application can call GetLastError to retrieve the error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A return value of <c>TRUE</c> from InternetGetConnectedState indicates that at least one connection to the Internet is
	/// available. It does not guarantee that a connection to a specific host can be established. Applications should always check for
	/// errors returned from API calls that connect to a server. InternetCheckConnection can be called to determine if a connection to a
	/// specific destination can be established.
	/// </para>
	/// <para>
	/// A return value of <c>TRUE</c> indicates that either the modem connection is active, or a LAN connection is active and a proxy is
	/// properly configured for the LAN. A return value of <c>FALSE</c> indicates that neither the modem nor the LAN is connected. If
	/// <c>FALSE</c> is returned, the <c>INTERNET_CONNECTION_CONFIGURED</c> flag may be set to indicate that autodial is configured to
	/// "always dial" but is not currently active. If autodial is not configured, the function returns <c>FALSE</c>.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetconnectedstateex BOOLAPI
	// InternetGetConnectedStateEx( LPDWORD lpdwFlags, LPSTR lpszConnectionName, DWORD dwNameLen, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "0b27b86d-6e55-4022-84ce-d4116d71f124")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetConnectedStateEx(out INTERNET_CONNECTION lpdwFlags, StringBuilder lpszConnectionName, uint dwNameLen, uint dwReserved = 0);

	/// <summary>Retrieves the cookie for the specified URL.</summary>
	/// <param name="lpszUrl">A pointer to a <c>null</c>-terminated string that specifies the URL for which cookies are to be retrieved.</param>
	/// <param name="lpszCookieName">Not implemented.</param>
	/// <param name="lpszCookieData">A pointer to a buffer that receives the cookie data. This parameter can be <c>NULL</c>.</param>
	/// <param name="lpdwSize">
	/// A pointer to a variable that specifies the size of the lpszCookieData parameter buffer, in TCHARs. If the function succeeds, the
	/// buffer receives the amount of data copied to the lpszCookieData buffer. If lpszCookieData is <c>NULL</c>, this parameter
	/// receives a value that specifies the size of the buffer necessary to copy all the cookie data, expressed as a byte count.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error data, call GetLastError.</para>
	/// <para>The following error values apply to <c>InternetGetCookie</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There is no cookie for the specified URL and all its parents.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The value passed in lpdwSize is insufficient to copy all the cookie data. The value returned in lpdwSize is the size of the
	/// buffer necessary to get all the data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters is invalid. The lpszUrl parameter is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetGetCookie</c> does not require a call to InternetOpen. <c>InternetGetCookie</c> checks in the windows\cookies
	/// directory for persistent cookies that have an expiration date set sometime in the future. <c>InternetGetCookie</c> also searches
	/// memory for any session cookies, that is, cookies that do not have an expiration date that were created in the same process by
	/// InternetSetCookie, because these cookies are not written to any files. Rules for creating cookie files are internal to the
	/// system and can change in the future.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetcookiea BOOLAPI InternetGetCookieA( LPCSTR
	// lpszUrl, LPCSTR lpszCookieName, LPSTR lpszCookieData, LPDWORD lpdwSize );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "12c1ebab-3954-4995-9e1f-bf29699af396")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetCookie(string lpszUrl, [Optional] string? lpszCookieName, StringBuilder lpszCookieData, ref uint lpdwSize);

	/// <summary>
	/// The <c>InternetGetCookieEx</c> function retrieves data stored in cookies associated with a specified URL. Unlike
	/// InternetGetCookie, <c>InternetGetCookieEx</c> can be used to restrict data retrieved to a single cookie name or, by policy,
	/// associated with untrusted sites or third-party cookies.
	/// </summary>
	/// <param name="lpszUrl">
	/// A pointer to a <c>null</c>-terminated string that contains the URL with which the cookie to retrieve is associated. This
	/// parameter cannot be <c>NULL</c> or <c>InternetGetCookieEx</c> fails and returns an <c>ERROR_INVALID_PARAMETER</c> error.
	/// </param>
	/// <param name="lpszCookieName">
	/// A pointer to a <c>null</c>-terminated string that contains the name of the cookie to retrieve. This name is case-sensitive.
	/// </param>
	/// <param name="lpszCookieData">A pointer to a buffer to receive the cookie data.</param>
	/// <param name="lpdwSize">
	/// <para>A pointer to a DWORD variable.</para>
	/// <para>On entry, the variable must contain the size, in TCHARs, of the buffer pointed to by the pchCookieData parameter.</para>
	/// <para>
	/// On exit, if the function is successful, this variable contains the number of TCHARs of cookie data copied into the buffer. If
	/// <c>NULL</c> was passed as the lpszCookieData parameter, or if the function fails with an error of
	/// <c>ERROR_INSUFFICIENT_BUFFER</c>, the variable contains the size, in BYTEs, of buffer required to receive the cookie data.
	/// </para>
	/// <para>
	/// This parameter cannot be <c>NULL</c> or <c>InternetGetCookieEx</c> fails and returns an <c>ERROR_INVALID_PARAMETER</c> error.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>A flag that controls how the function retrieves cookie data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_COOKIE_HTTPONLY</term>
	/// <term>
	/// Enables the retrieval of cookies that are marked as "HTTPOnly". Do not use this flag if you expose a scriptable interface,
	/// because this has security implications. It is imperative that you use this flag only if you can guarantee that you will never
	/// expose the cookie to third-party code by way of an extensibility mechanism you provide. Version: Requires Internet Explorer 8.0
	/// or later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_COOKIE_THIRD_PARTY</term>
	/// <term>Retrieves only third-party cookies if policy explicitly allows all cookies for the specified URL to be retrieved.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESTRICTED_ZONE</term>
	/// <term>
	/// Retrieves only cookies that would be allowed if the specified URL were untrusted; that is, if it belonged to the
	/// URLZONE_UNTRUSTED zone.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpReserved">Reserved for future use. Set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get a specific error value, call GetLastError.</para>
	/// <para>If <c>NULL</c> is passed to lpszCookieData, the call will succeed and the function will not set <c>ERROR_INSUFFICIENT_BUFFER</c>.</para>
	/// <para>The following error codes may be set by this function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// Returned if cookie data retrieved is larger than the buffer size pointed to by the pcchCookieData parameter or if that parameter
	/// is NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if either the pchURL or the pcchCookieData parameter is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>Returned if no cookied data as specified could be retrieved.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetcookieexa BOOLAPI InternetGetCookieExA( LPCSTR
	// lpszUrl, LPCSTR lpszCookieName, LPSTR lpszCookieData, LPDWORD lpdwSize, DWORD dwFlags, LPVOID lpReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "5006f009-e217-4fdc-9e4e-800ff5fcbf03")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetCookieEx(string lpszUrl, [Optional] string? lpszCookieName, StringBuilder lpszCookieData,
		ref uint lpdwSize, [Optional] INTERNET_COOKIE dwFlags, IntPtr lpReserved = default);

	/// <summary>Retrieves the last error description or server response on the thread calling this function.</summary>
	/// <param name="lpdwError">Pointer to a variable that receives an error message pertaining to the operation that failed.</param>
	/// <param name="lpszBuffer">Pointer to a buffer that receives the error text.</param>
	/// <param name="lpdwBufferLength">
	/// Pointer to a variable that contains the size of the lpszBuffer buffer, in <c>TCHARs</c>. When the function returns, this
	/// parameter contains the size of the string written to the buffer, not including the terminating zero.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if error text was successfully written to the buffer, or <c>FALSE</c> otherwise. To get extended error
	/// information, call GetLastError. If the buffer is too small to hold all the error text, <c>GetLastError</c> returns
	/// <c>ERROR_INSUFFICIENT_BUFFER</c>, and the lpdwBufferLength parameter contains the minimum buffer size required to return all the
	/// error text.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The FTP protocols can return additional text information along with most errors. This extended error information can be
	/// retrieved by using the <c>InternetGetLastResponseInfo</c> function whenever GetLastError returns ERROR_INTERNET_EXTENDED_ERROR
	/// (occurring after an unsuccessful function call).
	/// </para>
	/// <para>
	/// The buffer pointed to by lpszBuffer must be large enough to hold both the error string and a zero terminator at the end of the
	/// string. However, note that the value returned in lpdwBufferLength does not include the terminating zero.
	/// </para>
	/// <para>
	/// <c>InternetGetLastResponseInfo</c> can be called multiple times until another function is called on this thread. When another
	/// function is called, the internal buffer that is storing the last response information is cleared.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetlastresponseinfoa BOOLAPI
	// InternetGetLastResponseInfoA( LPDWORD lpdwError, LPSTR lpszBuffer, LPDWORD lpdwBufferLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "0aa274c5-0aa0-4eb9-8aef-3128e735759d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetLastResponseInfo(out Win32Error lpdwError, StringBuilder lpszBuffer, ref uint lpdwBufferLength);

	/// <summary>Retrieves a decision on cookies for a given domain.</summary>
	/// <param name="pchHostName">An <c>LPCTSTR</c> that points to a string containing a domain.</param>
	/// <param name="pResult">A pointer to an <c>unsigned long</c> that contains one of the InternetCookieState enumeration values.</param>
	/// <returns>Returns <c>TRUE</c> if the decision was retrieved and <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>A return value of <c>FALSE</c> may indicate that the domain pchHostName does not have any site-specific cookie regulations.</para>
	/// <para>
	/// WinINet minimizes the domain specified in the pchHostName parameter and sets the cookie policy on the minimum legal domain. For
	/// example, if the specified host name is widgets.microsoft.com, the policy is set on the minimized host name microsoft.com.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgetpersitecookiedecisiona BOOLAPI
	// InternetGetPerSiteCookieDecisionA( LPCSTR pchHostName, unsigned long *pResult );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "04fa4c33-077c-4b16-8170-c3770783c98a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGetPerSiteCookieDecision(string pchHostName, out InternetCookieState pResult);

	/// <summary>Prompts the user for permission to initiate connection to a URL.</summary>
	/// <param name="lpszURL">Pointer to a null-terminated string that specifies the URL of the website for the connection.</param>
	/// <param name="hwndParent">Handle to the parent window.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be zero or the following flag.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_GOONLINE_REFRESH</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. Applications can call GetLastError to retrieve the error code.</para>
	/// <para>If the functions fails, it can return the following error code:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters is incorrect. The dwFlags parameter contains a value other than zero or INTERNET_GOONLINE_REFRESH.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetgoonline BOOLAPI InternetGoOnline( LPSTR lpszURL,
	// HWND hwndParent, DWORD dwFlags );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "ed1c0282-5469-49d5-8a8c-b7671d27ebd2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetGoOnline(string lpszURL, HWND hwndParent, uint dwFlags = 0);

	/// <summary>Instructs the modem to disconnect from the Internet.</summary>
	/// <param name="dwConnection">Connection number of the connection to be disconnected.</param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>Returns ERROR_SUCCESS if successful, or an error value otherwise.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internethangup void InternetHangUp( DWORD_PTR dwConnection,
	// DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "5d74532e-14cd-45c1-b16b-b302bed89c12")]
	public static extern Win32Error InternetHangUp(in uint dwConnection, uint dwReserved = 0);

	/// <summary>
	/// <para>
	/// There are two WinINet functions named <c>InternetInitializeAutoProxyDll</c>. The first, which merely refreshes the internal
	/// state of proxy configuration information from the registry, has a single parameter as documented directly below.
	/// </para>
	/// <para>
	/// The second function, prototyped as <c>pfnInternetInitializeAutoProxyDll</c>, is part of WinINet's limited autoproxy support, and
	/// must be called by dynamically linking to "JSProxy.dll". For autoproxy support, use Windows HTTP Services (WinHTTP) version 5.1.
	/// For more information, see WinHTTP AutoProxy Support.
	/// </para>
	/// </summary>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// Because the <c>InternetInitializeAutoProxyDll</c> function takes time to complete its operation, it should not be called from a
	/// UI thread.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetinitializeautoproxydll BOOLAPI
	// InternetInitializeAutoProxyDll( DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "d55d64cb-ee92-4366-a1bb-f5d421ed81c8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetInitializeAutoProxyDll(uint dwReserved = 0);

	/// <summary>Places a lock on the file that is being used.</summary>
	/// <param name="hInternet">Handle returned by the FtpOpenFile, GopherOpenFile, HttpOpenRequest, or InternetOpenUrl function.</param>
	/// <param name="lphLockRequestInfo">Pointer to a handle that receives the lock request handle.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// If the HINTERNET handle passed to hInternet was created using INTERNET_FLAG_NO_CACHE_WRITE or INTERNET_FLAG_DONT_CACHE, the
	/// function creates a temporary file with the extension .tmp, unless it is an HTTPS resource. If the handle was created using
	/// <c>INTERNET_FLAG_NO_CACHE_WRITE</c> or <c>INTERNET_FLAG_DONT_CACHE</c> and it is accessing an HTTPS resource,
	/// <c>InternetLockRequestFile</c> fails.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetlockrequestfile BOOLAPI InternetLockRequestFile(
	// HINTERNET hInternet, HANDLE *lphLockRequestInfo );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "5924d117-1dcd-43d8-817e-02bda302bdd4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetLockRequestFile(HINTERNET hInternet, out HANDLE lphLockRequestInfo);

	/// <summary>Initializes an application's use of the WinINet functions.</summary>
	/// <param name="lpszAgent">
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the application or entity calling the WinINet functions.
	/// This name is used as the user agent in the HTTP protocol.
	/// </param>
	/// <param name="dwAccessType">
	/// <para>Type of access required. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_OPEN_TYPE_DIRECT</term>
	/// <term>Resolves all host names locally.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_OPEN_TYPE_PRECONFIG</term>
	/// <term>Retrieves the proxy or direct configuration from the registry.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_OPEN_TYPE_PRECONFIG_WITH_NO_AUTOPROXY</term>
	/// <term>
	/// Retrieves the proxy or direct configuration from the registry and prevents the use of a startup Microsoft JScript or Internet
	/// Setup (INS) file.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_OPEN_TYPE_PROXY</term>
	/// <term>
	/// Passes requests to the proxy unless a proxy bypass list is supplied and the name to be resolved bypasses the proxy. In this
	/// case, the function uses INTERNET_OPEN_TYPE_DIRECT.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszProxy">
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the proxy server(s) to use when proxy access is specified
	/// by setting dwAccessType to <c>INTERNET_OPEN_TYPE_PROXY</c>. Do not use an empty string, because <c>InternetOpen</c> will use it
	/// as the proxy name. The WinINet functions recognize only CERN type proxies (HTTP only) and the TIS FTP gateway (FTP only). If
	/// Microsoft Internet Explorer is installed, these functions also support SOCKS proxies. FTP requests can be made through a CERN
	/// type proxy either by changing them to an HTTP request or by using InternetOpenUrl. If dwAccessType is not set to
	/// <c>INTERNET_OPEN_TYPE_PROXY</c>, this parameter is ignored and should be <c>NULL</c>. For more information about listing proxy
	/// servers, see the Listing Proxy Servers section of Enabling Internet Functionality.
	/// </param>
	/// <param name="lpszProxyBypass">
	/// <para>
	/// Pointer to a <c>null</c>-terminated string that specifies an optional list of host names or IP addresses, or both, that should
	/// not be routed through the proxy when dwAccessType is set to <c>INTERNET_OPEN_TYPE_PROXY</c>. The list can contain wildcards. Do
	/// not use an empty string, because <c>InternetOpen</c> will use it as the proxy bypass list. If this parameter specifies the
	/// "&lt;local&gt;" macro, the function bypasses the proxy for any host name that does not contain a period.
	/// </para>
	/// <para>
	/// By default, WinINet will bypass the proxy for requests that use the host names "localhost", "loopback", "127.0.0.1", or "[::1]".
	/// This behavior exists because a remote proxy server typically will not resolve these addresses properly. <c>Internet Explorer
	/// 9:</c> You can remove the local computer from the proxy bypass list using the "&lt;-loopback&gt;" macro.
	/// </para>
	/// <para>If dwAccessType is not set to <c>INTERNET_OPEN_TYPE_PROXY</c>, this parameter is ignored and should be <c>NULL</c>.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Options. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_ASYNC</term>
	/// <term>Makes only asynchronous requests on handles descended from the handle returned from this function.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_FROM_CACHE</term>
	/// <term>
	/// Does not make network requests. All entities are returned from the cache. If the requested item is not in the cache, a suitable
	/// error, such as ERROR_FILE_NOT_FOUND, is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_OFFLINE</term>
	/// <term>
	/// Identical to INTERNET_FLAG_FROM_CACHE. Does not make network requests. All entities are returned from the cache. If the
	/// requested item is not in the cache, a suitable error, such as ERROR_FILE_NOT_FOUND, is returned.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns a valid handle that the application passes to subsequent WinINet functions. If <c>InternetOpen</c> fails, it returns
	/// <c>NULL</c>. To retrieve a specific error message, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetOpen</c> is the first WinINet function called by an application. It tells the Internet DLL to initialize internal
	/// data structures and prepare for future calls from the application. When the application finishes using the Internet functions,
	/// it should call InternetCloseHandle to free the handle and any associated resources.
	/// </para>
	/// <para>
	/// The application can make any number of calls to <c>InternetOpen</c>, though a single call is normally sufficient. The
	/// application might need to define separate behaviors for each <c>InternetOpen</c> instance, such as different proxy servers
	/// configured for each.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>InternetOpen</c>, it must be closed using
	/// the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetopena void InternetOpenA( LPCSTR lpszAgent, DWORD
	// dwAccessType, LPCSTR lpszProxy, LPCSTR lpszProxyBypass, DWORD dwFlags );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "9ec087c9-d484-4763-a527-2ea5c1a0cf28")]
	public static extern SafeHINTERNET InternetOpen([Optional] string? lpszAgent, [Optional] InternetOpenType dwAccessType,
		[Optional] string? lpszProxy, [Optional] string? lpszProxyBypass, [Optional] InternetApiFlags dwFlags);

	/// <summary>Opens a resource specified by a complete FTP or HTTP URL.</summary>
	/// <param name="hInternet">
	/// The handle to the current Internet session. The handle must have been returned by a previous call to InternetOpen.
	/// </param>
	/// <param name="lpszUrl">
	/// A pointer to a <c>null</c>-terminated string variable that specifies the URL to begin reading. Only URLs beginning with ftp:,
	/// http:, or https: are supported.
	/// </param>
	/// <param name="lpszHeaders">
	/// A pointer to a <c>null</c>-terminated string that specifies the headers to be sent to the HTTP server. For more information, see
	/// the description of the lpszHeaders parameter in the HttpSendRequest function.
	/// </param>
	/// <param name="dwHeadersLength">
	/// The size of the additional headers, in <c>TCHARs</c>. If this parameter is -1L and lpszHeaders is not <c>NULL</c>, lpszHeaders
	/// is assumed to be zero-terminated (ASCIIZ) and the length is calculated.
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_FLAG_EXISTING_CONNECT</term>
	/// <term>
	/// Attempts to use an existing InternetConnect object if one exists with the same attributes required to make the request. This is
	/// useful only with FTP operations, since FTP is the only protocol that typically performs multiple operations during the same
	/// session. The WinINet API caches a single connection handle for each HINTERNET handle generated by InternetOpen. InternetOpenUrl
	/// uses this flag for HTTP and FTP connections.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_HYPERLINK</term>
	/// <term>
	/// Forces a reload if there was no Expires time and no LastModified time returned from the server when determining whether to
	/// reload the item from the network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_IGNORE_CERT_CN_INVALID</term>
	/// <term>
	/// Disables checking of SSL/PCT-based certificates that are returned from the server against the host name given in the request.
	/// WinINet functions use a simple check against certificates by comparing for matching host names and simple wildcarding rules.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_IGNORE_CERT_DATE_INVALID</term>
	/// <term>Disables checking of SSL/PCT-based certificates for proper validity dates.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP</term>
	/// <term>
	/// Disables detection of this special type of redirect. When this flag is used, WinINet transparently allows redirects from HTTPS
	/// to HTTP URLs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS</term>
	/// <term>
	/// Disables the detection of this special type of redirect. When this flag is used, WinINet transparently allows redirects from
	/// HTTP to HTTPS URLs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_KEEP_CONNECTION</term>
	/// <term>
	/// Uses keep-alive semantics, if available, for the connection. This flag is required for Microsoft Network (MSN), NTLM, and other
	/// types of authentication.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NEED_FILE</term>
	/// <term>Causes a temporary file to be created if the file cannot be cached.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_AUTH</term>
	/// <term>Does not attempt authentication automatically.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_AUTO_REDIRECT</term>
	/// <term>Does not automatically handle redirection in HttpSendRequest.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_CACHE_WRITE</term>
	/// <term>Does not add the returned entity to the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_COOKIES</term>
	/// <term>Does not automatically add cookie headers to requests, and does not automatically add returned cookies to the cookie database.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_NO_UI</term>
	/// <term>Disables the cookie dialog box.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_PASSIVE</term>
	/// <term>Uses passive FTP semantics. InternetOpenUrl uses this flag for FTP files and directories.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_PRAGMA_NOCACHE</term>
	/// <term>Forces the request to be resolved by the origin server, even if a cached copy exists on the proxy.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RAW_DATA</term>
	/// <term>
	/// Returns the data as a WIN32_FIND_DATA structure when retrieving FTP directory information. If this flag is not specified or if
	/// the call was made through a CERN proxy, InternetOpenUrl returns the HTML version of the directory. Windows XP and Windows Server
	/// 2003 R2 and earlier: Also returns data as a GOPHER_FIND_DATA structure when retrieving Gopher directory information.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RELOAD</term>
	/// <term>Forces a download of the requested file, object, or directory listing from the origin server, not from the cache.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESYNCHRONIZE</term>
	/// <term>
	/// Reloads HTTP resources if the resource has been modified since the last time it was downloaded. All FTP resources are reloaded.
	/// Windows XP and Windows Server 2003 R2 and earlier: Gopher resources are also reloaded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_SECURE</term>
	/// <term>
	/// Uses secure transaction semantics. This translates to using Secure Sockets Layer/Private Communications Technology (SSL/PCT) and
	/// is only meaningful in HTTP requests.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">
	/// A pointer to a variable that specifies the application-defined value that is passed, along with the returned handle, to any
	/// callback functions.
	/// </param>
	/// <returns>
	/// Returns a valid handle to the URL if the connection is successfully established, or <c>NULL</c> if the connection fails. To
	/// retrieve a specific error message, call GetLastError. To determine why access to the service was denied, call InternetGetLastResponseInfo.
	/// </returns>
	/// <remarks>
	/// <para>Call InternetCanonicalizeUrl first if the URL being used contains a relative URL and a base URL separated by blank spaces.</para>
	/// <para>
	/// This is a general function that an application can use to retrieve data over any of the protocols that WinINet supports. This
	/// function is especially useful when the application does not need to access the particulars of a protocol, but only requires the
	/// data corresponding to a URL. The <c>InternetOpenUrl</c> function parses the URL string, establishes a connection to the server,
	/// and prepares to download the data identified by the URL. The application can then use InternetReadFile (for files) or
	/// InternetFindNextFile (for directories) to retrieve the URL data. It is not necessary to call InternetConnect before <c>InternetOpenUrl</c>.
	/// </para>
	/// <para>
	/// <c>Windows XP and Windows Server 2003 R2 and earlier:</c><c>InternetOpenUrl</c> disables Gopher on ports less than 1024, except
	/// for port 70—the standard Gopher port—and port 105—typically used for Central Services Organization (CSO) name searches.
	/// </para>
	/// <para>
	/// After the calling application has finished using the HINTERNET handle returned by <c>InternetOpenUrl</c>, it must be closed
	/// using the InternetCloseHandle function.
	/// </para>
	/// <para>
	/// <c>Note</c> When working in asynchronous mode (the dwFlags parameter of InternetOpen specifies <c>INTERNET_FLAG_ASYNC</c>), and
	/// the dwContext parameter is zero ( <c>INTERNET_NO_CALLBACK</c>), the callback function set with InternetSetStatusCallback on the
	/// session handle will not be invoked, however, the call will still be performed in asynchronous mode
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetopenurla void InternetOpenUrlA( HINTERNET
	// hInternet, LPCSTR lpszUrl, LPCSTR lpszHeaders, DWORD dwHeadersLength, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "73f969c3-3fa7-43f5-88c5-ba78e59a8d1c")]
	public static extern SafeHINTERNET InternetOpenUrl(HINTERNET hInternet, string lpszUrl, string? lpszHeaders, uint dwHeadersLength,
		INTERNET_FLAG dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Queries the server to determine the amount of data available.</summary>
	/// <param name="hFile">Handle returned by the InternetOpenUrl, FtpOpenFile, GopherOpenFile, or HttpOpenRequest function.</param>
	/// <param name="lpdwNumberOfBytesAvailable">Pointer to a variable that receives the number of available bytes. May be <c>NULL</c>.</param>
	/// <param name="dwFlags">This parameter is reserved and must be 0.</param>
	/// <param name="dwContext">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the function succeeds, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// If the function finds no matching files, <c>GetLastError</c> returns ERROR_NO_MORE_FILES.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function returns the number of bytes of data that are available to be read immediately by a subsequent call to
	/// InternetReadFile. If there is currently no data available and the end of the file has not been reached, the request waits until
	/// data becomes available. The amount of data remaining will not be recalculated until all available data indicated by the call to
	/// <c>InternetQueryDataAvailable</c> is read.
	/// </para>
	/// <para>
	/// For HINTERNET handles created by HttpOpenRequest and sent by HttpSendRequestEx, a call to HttpEndRequest must be made on the
	/// handle before <c>InternetQueryDataAvailable</c> can be used.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetquerydataavailable BOOLAPI
	// InternetQueryDataAvailable( HINTERNET hFile, LPDWORD lpdwNumberOfBytesAvailable, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "fea8250d-f260-421f-b4dd-14b8685e8dac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetQueryDataAvailable(HINTERNET hFile, out uint lpdwNumberOfBytesAvailable, uint dwFlags = 0, IntPtr dwContext = default);

	/// <summary>Queries an Internet option on the specified handle.</summary>
	/// <param name="hInternet">Handle on which to query information.</param>
	/// <param name="dwOption">Internet option to be queried. This can be one of the Option Flags values.</param>
	/// <param name="lpBuffer">
	/// Pointer to a buffer that receives the option setting. Strings returned by <c>InternetQueryOption</c> are globally allocated, so
	/// the calling application must free them when it is finished using them.
	/// </param>
	/// <param name="lpdwBufferLength">
	/// Pointer to a variable that contains the size of lpBuffer, in bytes. When <c>InternetQueryOption</c> returns, lpdwBufferLength
	/// specifies the size of the data placed into lpBuffer. If GetLastError returns ERROR_INSUFFICIENT_BUFFER, this parameter points to
	/// the number of bytes required to hold the requested information.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// GetLastError will return the <c>ERROR_INVALID_PARAMETER</c> if an option flag that is invalid for the specified handle type is
	/// passed to the dwOption parameter.
	/// </para>
	/// <para>For more information, see Setting and Retrieving Internet Options.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetqueryoptiona BOOLAPI InternetQueryOptionA(
	// HINTERNET hInternet, DWORD dwOption, LPVOID lpBuffer, LPDWORD lpdwBufferLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "b0bafd3d-8f54-429e-b423-dae3d61b0030")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetQueryOption(HINTERNET hInternet, InternetOptionFlags dwOption, IntPtr lpBuffer, ref int lpdwBufferLength);

	/// <summary>Queries an Internet option on the specified handle.</summary>
	/// <param name="hInternet">Handle on which to query information.</param>
	/// <param name="option">Internet option to be queried. This can be one of the Option Flags values.</param>
	/// <returns>
	/// A <see cref="SafeCoTaskMemHandle"/> instance with sufficient memory needed to hold the response. This should be cast to the type required.
	/// </returns>
	public static ISafeMemoryHandle InternetQueryOption(HINTERNET hInternet, InternetOptionFlags option)
	{
		var sz = 0;
		InternetQueryOption(hInternet, option, IntPtr.Zero, ref sz);
		var err = Win32Error.GetLastError();
		if (err != Win32Error.ERROR_INSUFFICIENT_BUFFER) err.ThrowIfFailed();
		var hMem = new SafeCoTaskMemHandle(sz);
		var res = InternetQueryOption(hInternet, option, hMem, ref sz);
		if (!res) Win32Error.ThrowLastError();
		return hMem;
	}

	/// <summary>Queries an Internet option on the specified handle.</summary>
	/// <typeparam name="T">The expected type returned by the option.</typeparam>
	/// <param name="hInternet">Handle on which to query information.</param>
	/// <param name="option">Internet option to be queried. This can be one of the Option Flags values.</param>
	/// <returns>The option setting.</returns>
	public static T InternetQueryOption<T>(HINTERNET hInternet, InternetOptionFlags option)
	{
		if (!CorrespondingTypeAttribute.CanGet(option, typeof(T))) throw new ArgumentException($"{option} cannot be used to get values of type {typeof(T)}.");
		using var hMem = InternetQueryOption(hInternet, option);
		return typeof(T) == typeof(string) ? (T)(object)hMem.ToString(-1)! : (typeof(T) == typeof(bool) ? (T)(object)Convert.ToBoolean(hMem.ToStructure<uint>()) : hMem.ToStructure<T>()!);
	}

	/// <summary>Reads data from a handle opened by the InternetOpenUrl, FtpOpenFile, or HttpOpenRequest function.</summary>
	/// <param name="hFile">Handle returned from a previous call to InternetOpenUrl, FtpOpenFile, or HttpOpenRequest.</param>
	/// <param name="lpBuffer">Pointer to a buffer that receives the data.</param>
	/// <param name="dwNumberOfBytesToRead">Number of bytes to be read.</param>
	/// <param name="lpdwNumberOfBytesRead">
	/// Pointer to a variable that receives the number of bytes read. <c>InternetReadFile</c> sets this value to zero before doing any
	/// work or error checking.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. An
	/// application can also use InternetGetLastResponseInfo when necessary.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetReadFile</c> operates much like the base ReadFile function, with a few exceptions. Typically, <c>InternetReadFile</c>
	/// retrieves data from an HINTERNET handle as a sequential stream of bytes. The amount of data to be read for each call to
	/// <c>InternetReadFile</c> is specified by the dwNumberOfBytesToRead parameter and the data is returned in the lpBuffer parameter.
	/// A normal read retrieves the specified dwNumberOfBytesToRead for each call to <c>InternetReadFile</c> until the end of the file
	/// is reached. To ensure all data is retrieved, an application must continue to call the <c>InternetReadFile</c> function until the
	/// function returns <c>TRUE</c> and the lpdwNumberOfBytesRead parameter equals zero. This is especially important if the requested
	/// data is written to the cache, because otherwise the cache will not be properly updated and the file downloaded will not be
	/// committed to the cache. Note that caching happens automatically unless the original request to open the data stream set the
	/// <c>INTERNET_FLAG_NO_CACHE_WRITE</c> flag.
	/// </para>
	/// <para>
	/// When an application retrieves a handle using InternetOpenUrl, WinINet attempts to make all data look like a file download, in an
	/// effort to make reading from the Internet easier for the application. For some types of information, such as FTP file directory
	/// listings, it converts the data to be returned by <c>InternetReadFile</c> to an HTML stream. It does this on a line-by-line
	/// basis. For example, it can convert an FTP directory listing to a line of HTML and return this HTML to the application.
	/// </para>
	/// <para>
	/// WinINet attempts to write the HTML to the lpBuffer buffer a line at a time. If the application's buffer is too small to fit at
	/// least one line of generated HTML, the error code <c>ERROR_INSUFFICIENT_BUFFER</c> is returned as an indication to the
	/// application that it needs a larger buffer. Also, converted lines might not completely fill the buffer, so
	/// <c>InternetReadFile</c> can return with less data in lpBuffer than requested. Subsequent reads will retrieve all the converted
	/// HTML. The application must again check that all data is retrieved as described previously.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// When running asynchronously, if a call to <c>InternetReadFile</c> does not result in a completed transaction, it will return
	/// FALSE and a subsequent call to GetLastError will return ERROR_IO_PENDING. When the transaction is completed the
	/// InternetStatusCallback specified in a previous call to InternetSetStatusCallback will be called with INTERNET_STATUS_REQUEST_COMPLETE.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetreadfile BOOLAPI InternetReadFile( HINTERNET hFile,
	// LPVOID lpBuffer, DWORD dwNumberOfBytesToRead, LPDWORD lpdwNumberOfBytesRead );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "1ec0fe70-4749-4251-9c58-44efdab74688")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetReadFile(HINTERNET hFile, [Out] IntPtr lpBuffer, uint dwNumberOfBytesToRead, out uint lpdwNumberOfBytesRead);

	/// <summary>Reads data from a handle opened by the InternetOpenUrl, FtpOpenFile, or HttpOpenRequest function.</summary>
	/// <param name="hFile">Handle returned from a previous call to InternetOpenUrl, FtpOpenFile, or HttpOpenRequest.</param>
	/// <param name="lpBuffer">Pointer to a buffer that receives the data.</param>
	/// <param name="dwNumberOfBytesToRead">Number of bytes to be read.</param>
	/// <param name="lpdwNumberOfBytesRead">
	/// Pointer to a variable that receives the number of bytes read. <c>InternetReadFile</c> sets this value to zero before doing any work
	/// or error checking.
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. An application
	/// can also use InternetGetLastResponseInfo when necessary.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>InternetReadFile</c> operates much like the base ReadFile function, with a few exceptions. Typically, <c>InternetReadFile</c>
	/// retrieves data from an HINTERNET handle as a sequential stream of bytes. The amount of data to be read for each call to
	/// <c>InternetReadFile</c> is specified by the <c>dwNumberOfBytesToRead</c> parameter and the data is returned in the <c>lpBuffer</c>
	/// parameter. A normal read retrieves the specified <c>dwNumberOfBytesToRead</c> for each call to <c>InternetReadFile</c> until the end
	/// of the file is reached. To ensure all data is retrieved, an application must continue to call the <c>InternetReadFile</c> function
	/// until the function returns <c>TRUE</c> and the <c>lpdwNumberOfBytesRead</c> parameter equals zero. This is especially important if
	/// the requested data is written to the cache, because otherwise the cache will not be properly updated and the file downloaded will not
	/// be committed to the cache. Note that caching happens automatically unless the original request to open the data stream set the
	/// <c>INTERNET_FLAG_NO_CACHE_WRITE</c> flag.
	/// </para>
	/// <para>
	/// When an application retrieves a handle using InternetOpenUrl, WinINet attempts to make all data look like a file download, in an
	/// effort to make reading from the Internet easier for the application. For some types of information, such as FTP file directory
	/// listings, it converts the data to be returned by <c>InternetReadFile</c> to an HTML stream. It does this on a line-by-line basis. For
	/// example, it can convert an FTP directory listing to a line of HTML and return this HTML to the application.
	/// </para>
	/// <para>
	/// WinINet attempts to write the HTML to the <c>lpBuffer</c> buffer a line at a time. If the application's buffer is too small to fit at
	/// least one line of generated HTML, the error code <c>ERROR_INSUFFICIENT_BUFFER</c> is returned as an indication to the application
	/// that it needs a larger buffer. Also, converted lines might not completely fill the buffer, so <c>InternetReadFile</c> can return with
	/// less data in <c>lpBuffer</c> than requested. Subsequent reads will retrieve all the converted HTML. The application must again check
	/// that all data is retrieved as described previously.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// When running asynchronously, if a call to <c>InternetReadFile</c> does not result in a completed transaction, it will return
	/// <c>FALSE</c> and a subsequent call to GetLastError will return <c>ERROR_IO_PENDING</c>. When the transaction is completed the
	/// InternetStatusCallback specified in a previous call to InternetSetStatusCallback will be called with <c>INTERNET_STATUS_REQUEST_COMPLETE</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetreadfile
	// BOOL InternetReadFile( [in] HINTERNET hFile, [out] LPVOID lpBuffer, [in] DWORD dwNumberOfBytesToRead, [out] LPDWORD lpdwNumberOfBytesRead );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "NF:wininet.InternetReadFile")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetReadFile(HINTERNET hFile, [Out] byte[] lpBuffer, int dwNumberOfBytesToRead, out int lpdwNumberOfBytesRead);

	/// <summary>Reads data from a handle opened by the InternetOpenUrl or HttpOpenRequest function.</summary>
	/// <param name="hFile">Handle returned by the InternetOpenUrl or HttpOpenRequest function.</param>
	/// <param name="lpBuffersOut">Pointer to an INTERNET_BUFFERS structure that receives the data downloaded.</param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>IRF_ASYNC</term>
	/// <term>Identical to WININET_API_FLAG_ASYNC.</term>
	/// </item>
	/// <item>
	/// <term>IRF_SYNC</term>
	/// <term>Identical to WININET_API_FLAG_SYNC.</term>
	/// </item>
	/// <item>
	/// <term>IRF_USE_CONTEXT</term>
	/// <term>Identical to WININET_API_FLAG_USE_CONTEXT.</term>
	/// </item>
	/// <item>
	/// <term>IRF_NO_WAIT</term>
	/// <term>
	/// Do not wait for data. If there is data available, the function returns either the amount of data requested or the amount of data
	/// available (whichever is smaller).
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">A caller supplied context value used for asynchronous operations.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. An
	/// application can also use InternetGetLastResponseInfo when necessary.
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetreadfileexa BOOLAPI InternetReadFileExA( HINTERNET
	// hFile, LPINTERNET_BUFFERSA lpBuffersOut, DWORD dwFlags, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "04e7bb7e-d925-41fd-8333-3cb443a04c5b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetReadFileEx(HINTERNET hFile, ref INTERNET_BUFFERS lpBuffersOut, IRF dwFlags, [Optional] IntPtr dwContext);

	/// <summary>Creates a cookie associated with the specified URL.</summary>
	/// <param name="lpszUrl">Pointer to a <c>null</c>-terminated string that specifies the URL for which the cookie should be set.</param>
	/// <param name="lpszCookieName">
	/// Pointer to a <c>null</c>-terminated string that specifies the name to be associated with the cookie data. If this parameter is
	/// <c>NULL</c>, no name is associated with the cookie.
	/// </param>
	/// <param name="lpszCookieData">Pointer to the actual data to be associated with the URL.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// Cookies created by <c>InternetSetCookie</c> without an expiration date are stored in memory and are available only in the same
	/// process that created them. Cookies that include an expiration date are stored in the windows\cookies directory.
	/// </para>
	/// <para>
	/// Creating a new cookie might cause a dialog box to appear on the screen asking the user if they want to allow or disallow cookies
	/// from this site based on the privacy settings for the user.
	/// </para>
	/// <para>
	/// <c>Caution</c><c>InternetSetCookie</c> will unconditionally create a cookie even if “Block all cookies” is set in Internet
	/// Explorer. This behavior can be viewed as a breach of privacy even though such cookies are not subsequently sent back to servers
	/// while the “Block all cookies” setting is active. Applications should use InternetSetCookieEx to correctly honor the user's
	/// privacy settings. For more cookie internals, see http://blogs.msdn.com/ieinternals/archive/2009/08/20/WinINET-IE-Cookie-Internals-FAQ.aspx.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetcookiea BOOLAPI InternetSetCookieA( LPCSTR
	// lpszUrl, LPCSTR lpszCookieName, LPCSTR lpszCookieData );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "1b1ca72e-9c74-4e94-86a9-6fee12c83933")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetSetCookie(string lpszUrl, [Optional] string? lpszCookieName, string lpszCookieData);

	/// <summary>
	/// The <c>InternetSetCookieEx</c> function creates a cookie with a specified name that is associated with a specified URL. This
	/// function differs from the InternetSetCookie function by being able to create third-party cookies.
	/// </summary>
	/// <param name="lpszUrl">
	/// <para>Pointer to a <c>null</c>-terminated string that contains the URL for which the cookie should be set.</para>
	/// <para>If this pointer is <c>NULL</c>, <c>InternetSetCookieEx</c> fails with an <c>ERROR_INVALID_PARAMETER</c> error.</para>
	/// </param>
	/// <param name="lpszCookieName">
	/// Pointer to a <c>null</c>-terminated string that contains the name to associate with this cookie. If this pointer is <c>NULL</c>,
	/// then no name is associated with the cookie.
	/// </param>
	/// <param name="lpszCookieData">
	/// <para>Pointer to a <c>null</c>-terminated string that contains the data to be associated with the new cookie.</para>
	/// <para>If this pointer is <c>NULL</c>, <c>InternetSetCookieEx</c> fails with an <c>ERROR_INVALID_PARAMETER</c> error.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that control how the function retrieves cookie data:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_COOKIE_EVALUATE_P3P</term>
	/// <term>
	/// If this flag is set and the dwReserved parameter is not NULL, then the dwReserved parameter is cast to an LPCTSTR that points to
	/// a Platform-for-Privacy-Protection (P3P) header for the cookie in question.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_COOKIE_HTTPONLY</term>
	/// <term>
	/// Enables the retrieval of cookies that are marked as "HTTPOnly". Do not use this flag if you expose a scriptable interface,
	/// because this has security implications. If you expose a scriptable interface, you can become an attack vector for cross-site
	/// scripting attacks. It is utterly imperative that you use this flag only if they can guarantee that you will never permit
	/// third-party code to set a cookie using this flag by way of an extensibility mechanism you provide. Version: Requires Internet
	/// Explorer 8.0 or later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INTERNET_COOKIE_THIRD_PARTY</term>
	/// <term>Indicates that the cookie being set is a third-party cookie.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_FLAG_RESTRICTED_ZONE</term>
	/// <term>Indicates that the cookie being set is associated with an untrusted site.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">
	/// <c>NULL</c>, or contains a pointer to a Platform-for-Privacy-Protection (P3P) header to be associated with the cookie.
	/// </param>
	/// <returns>
	/// Returns a member of the InternetCookieState enumeration if successful, or <c>FALSE</c> if the function fails. On failure, if a
	/// call to GetLastError returns ERROR_NOT_ENOUGH_MEMORY, insufficient system memory was available.
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetcookieexa void InternetSetCookieExA( LPCSTR
	// lpszUrl, LPCSTR lpszCookieName, LPCSTR lpszCookieData, DWORD dwFlags, DWORD_PTR dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "5044761f-152d-4606-87d2-c56a11db18c4")]
	public static extern InternetCookieState InternetSetCookieEx(string lpszUrl, [Optional] string? lpszCookieName, string lpszCookieData,
		INTERNET_COOKIE dwFlags, IntPtr dwReserved = default);

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>This function is obsolete. Do not use.</para>
	/// </summary>
	/// <param name="lpszConnectoid">TBD</param>
	/// <param name="dwState">TBD</param>
	/// <param name="dwReserved">TBD</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetdialstate BOOLAPI InternetSetDialState( LPCSTR
	// lpszConnectoid, DWORD dwState, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "f523f1ca-3e5a-4da0-850f-8654c82ee41e")]
	[Obsolete]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetSetDialState(string lpszConnectoid, uint dwState, uint dwReserved);

	/// <summary>
	/// Sets a file position for InternetReadFile. This is a synchronous call; however, subsequent calls to InternetReadFile might block
	/// or return pending if the data is not available from the cache and the server does not support random access.
	/// </summary>
	/// <param name="hFile">
	/// Handle returned from a previous call to InternetOpenUrl (on an HTTP or HTTPS URL) or HttpOpenRequest (using the GET or HEAD HTTP
	/// verb and passed to HttpSendRequest or HttpSendRequestEx). This handle must not have been created with the
	/// INTERNET_FLAG_DONT_CACHE or INTERNET_FLAG_NO_CACHE_WRITE value set.
	/// </param>
	/// <param name="lDistanceToMove">
	/// The low order 32-bits of a signed 64-bit number of bytes to move the file pointer. <c>Internet Explorer 7 and
	/// earlier:</c><c>InternetSetFilePointer</c> used to move the pointer only within the bounds of a LONG. When calling this older
	/// version of the function, lpDistanceToMoveHigh is reserved and should be set to <c>0</c>. A positive value moves the pointer
	/// forward in the file; a negative value moves it backward.
	/// </param>
	/// <param name="lpDistanceToMoveHigh">
	/// A pointer to the high order 32-bits of the signed 64-bit distance to move. If you do not need the high order 32-bits, this
	/// pointer must be set to <c>NULL</c>. When not <c>NULL</c>, this parameter also receives the high order DWORD of the new value of
	/// the file pointer. A positive value moves the pointer forward in the file; a negative value moves it backward. <c>Internet
	/// Explorer 7 and earlier:</c><c>InternetSetFilePointer</c> used to move the pointer only within the bounds of a LONG. When calling
	/// this older version of the function, lpDistanceToMoveHigh is reserved and should be set to <c>0</c>.
	/// </param>
	/// <param name="dwMoveMethod">
	/// <para>Starting point for the file pointer move. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_BEGIN</term>
	/// <term>
	/// Starting point is zero or the beginning of the file. If FILE_BEGIN is specified, lDistanceToMove is interpreted as an unsigned
	/// location for the new file pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_CURRENT</term>
	/// <term>Current value of the file pointer is the starting point.</term>
	/// </item>
	/// <item>
	/// <term>FILE_END</term>
	/// <term>Current end-of-file position is the starting point. This method fails if the content length is unknown.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// I the function succeeds, it returns the current file position. A return value of <c>INVALID_SET_FILE_POINTER</c> indicates a
	/// potential failure and needs to be followed by be a call to GetLastError.
	/// </para>
	/// <para>
	/// Since <c>INVALID_SET_FILE_POINTER</c> is a valid value for the low-order DWORD of the new file pointer, the caller must check
	/// both the return value of the function and the error code returned by GetLastError to determine whether or not an error has
	/// occurred. If an error has occurred, the return value of InternetSetFilePointer is <c>INVALID_SET_FILE_POINTER</c> and
	/// <c>GetLastError</c> returns a value other than <c>NO_ERROR</c>.
	/// </para>
	/// <para>
	/// If the function succeeds and lpDistanceToMoveHigh is <c>NULL</c>, the return value is the low-order <c>DWORD</c> of the new file pointer.
	/// </para>
	/// <para>
	/// If the function succeeds and lpDistanceToMoveHigh is not <c>NULL</c>, the return value is the lower-order <c>DWORD</c> of the
	/// new file pointer and lpDistanceToMoveHigh contains the high order <c>DWORD</c> of the new file pointer.
	/// </para>
	/// <para>
	/// If a new file pointer is a negative value, the function fails, the file pointer is not moved, and the code returned by
	/// GetLastError is <c>ERROR_NEGATIVE_SEEK</c>.
	/// </para>
	/// <para>
	/// If lpDistanceToMoveHigh is <c>NULL</c> and the new file position does not fit in a 32-bit value the function fails and returns <c>INVALID_SET_FILE_POINTER</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function cannot be used once the end of the file has been reached by InternetReadFile.</para>
	/// <para>
	/// For HINTERNET handles created by HttpOpenRequest and sent by HttpSendRequestEx, a call to HttpEndRequest must be made on the
	/// handle before <c>InternetSetFilePointer</c> is used.
	/// </para>
	/// <para><c>InternetSetFilePointer</c> cannot be used reliably if the content length is unknown.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>InternetSetFilePointer</c> has changed over time. In Internet Explorer 7 and earlier, it used to move the pointer only within
	/// the bounds of a LONG. When calling this older version of the function, lDistanceToMove contains the entire value. A positive
	/// value moves the pointer forward in the file; a negative value moves it backward. lpDistanceToMoveHigh is reserved and is set to
	/// <c>0</c>. In current versions, lpDistanceToMoveHigh is a significant value and where any negative value would be indicated.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetfilepointer void InternetSetFilePointer(
	// HINTERNET hFile, LONG lDistanceToMove, PLONG lpDistanceToMoveHigh, DWORD dwMoveMethod, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "0fdd85cb-f6a9-4a08-b72b-10d2075efb59")]
	public static extern uint InternetSetFilePointer(HINTERNET hFile, int lDistanceToMove, [In, Optional] IntPtr lpDistanceToMoveHigh,
		SeekOrigin dwMoveMethod, [Optional] IntPtr dwContext);

	/// <summary>
	/// Sets a file position for InternetReadFile. This is a synchronous call; however, subsequent calls to InternetReadFile might block
	/// or return pending if the data is not available from the cache and the server does not support random access.
	/// </summary>
	/// <param name="hFile">
	/// Handle returned from a previous call to InternetOpenUrl (on an HTTP or HTTPS URL) or HttpOpenRequest (using the GET or HEAD HTTP
	/// verb and passed to HttpSendRequest or HttpSendRequestEx). This handle must not have been created with the
	/// INTERNET_FLAG_DONT_CACHE or INTERNET_FLAG_NO_CACHE_WRITE value set.
	/// </param>
	/// <param name="lDistanceToMove">
	/// The low order 32-bits of a signed 64-bit number of bytes to move the file pointer. <c>Internet Explorer 7 and
	/// earlier:</c><c>InternetSetFilePointer</c> used to move the pointer only within the bounds of a LONG. When calling this older
	/// version of the function, lpDistanceToMoveHigh is reserved and should be set to <c>0</c>. A positive value moves the pointer
	/// forward in the file; a negative value moves it backward.
	/// </param>
	/// <param name="lpDistanceToMoveHigh">
	/// A pointer to the high order 32-bits of the signed 64-bit distance to move. If you do not need the high order 32-bits, this
	/// pointer must be set to <c>NULL</c>. When not <c>NULL</c>, this parameter also receives the high order DWORD of the new value of
	/// the file pointer. A positive value moves the pointer forward in the file; a negative value moves it backward. <c>Internet
	/// Explorer 7 and earlier:</c><c>InternetSetFilePointer</c> used to move the pointer only within the bounds of a LONG. When calling
	/// this older version of the function, lpDistanceToMoveHigh is reserved and should be set to <c>0</c>.
	/// </param>
	/// <param name="dwMoveMethod">
	/// <para>Starting point for the file pointer move. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FILE_BEGIN</term>
	/// <term>
	/// Starting point is zero or the beginning of the file. If FILE_BEGIN is specified, lDistanceToMove is interpreted as an unsigned
	/// location for the new file pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FILE_CURRENT</term>
	/// <term>Current value of the file pointer is the starting point.</term>
	/// </item>
	/// <item>
	/// <term>FILE_END</term>
	/// <term>Current end-of-file position is the starting point. This method fails if the content length is unknown.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwContext">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// I the function succeeds, it returns the current file position. A return value of <c>INVALID_SET_FILE_POINTER</c> indicates a
	/// potential failure and needs to be followed by be a call to GetLastError.
	/// </para>
	/// <para>
	/// Since <c>INVALID_SET_FILE_POINTER</c> is a valid value for the low-order DWORD of the new file pointer, the caller must check
	/// both the return value of the function and the error code returned by GetLastError to determine whether or not an error has
	/// occurred. If an error has occurred, the return value of InternetSetFilePointer is <c>INVALID_SET_FILE_POINTER</c> and
	/// <c>GetLastError</c> returns a value other than <c>NO_ERROR</c>.
	/// </para>
	/// <para>
	/// If the function succeeds and lpDistanceToMoveHigh is <c>NULL</c>, the return value is the low-order <c>DWORD</c> of the new file pointer.
	/// </para>
	/// <para>
	/// If the function succeeds and lpDistanceToMoveHigh is not <c>NULL</c>, the return value is the lower-order <c>DWORD</c> of the
	/// new file pointer and lpDistanceToMoveHigh contains the high order <c>DWORD</c> of the new file pointer.
	/// </para>
	/// <para>
	/// If a new file pointer is a negative value, the function fails, the file pointer is not moved, and the code returned by
	/// GetLastError is <c>ERROR_NEGATIVE_SEEK</c>.
	/// </para>
	/// <para>
	/// If lpDistanceToMoveHigh is <c>NULL</c> and the new file position does not fit in a 32-bit value the function fails and returns <c>INVALID_SET_FILE_POINTER</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>This function cannot be used once the end of the file has been reached by InternetReadFile.</para>
	/// <para>
	/// For HINTERNET handles created by HttpOpenRequest and sent by HttpSendRequestEx, a call to HttpEndRequest must be made on the
	/// handle before <c>InternetSetFilePointer</c> is used.
	/// </para>
	/// <para><c>InternetSetFilePointer</c> cannot be used reliably if the content length is unknown.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>InternetSetFilePointer</c> has changed over time. In Internet Explorer 7 and earlier, it used to move the pointer only within
	/// the bounds of a LONG. When calling this older version of the function, lDistanceToMove contains the entire value. A positive
	/// value moves the pointer forward in the file; a negative value moves it backward. lpDistanceToMoveHigh is reserved and is set to
	/// <c>0</c>. In current versions, lpDistanceToMoveHigh is a significant value and where any negative value would be indicated.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetfilepointer void InternetSetFilePointer(
	// HINTERNET hFile, LONG lDistanceToMove, PLONG lpDistanceToMoveHigh, DWORD dwMoveMethod, DWORD_PTR dwContext );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "0fdd85cb-f6a9-4a08-b72b-10d2075efb59")]
	public static extern uint InternetSetFilePointer(HINTERNET hFile, int lDistanceToMove, in int lpDistanceToMoveHigh, SeekOrigin dwMoveMethod, [Optional] IntPtr dwContext);

	/// <summary>Sets an Internet option.</summary>
	/// <param name="hInternet">Handle on which to set information.</param>
	/// <param name="dwOption">Internet option to be set. This can be one of the Option Flags values.</param>
	/// <param name="lpBuffer">Pointer to a buffer that contains the option setting.</param>
	/// <param name="dwBufferLength">
	/// Size of the lpBuffer buffer. If lpBuffer contains a string, the size is in <c>TCHARs</c>. If lpBuffer contains anything other
	/// than a string, the size is in bytes.
	/// </param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <para>GetLastError will return the error <c>ERROR_INVALID_PARAMETER</c> if an option flag that cannot be set is specified.</para>
	/// <para>For more information, see Setting and Retrieving Internet Options.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetoptiona BOOLAPI InternetSetOptionA( HINTERNET
	// hInternet, DWORD dwOption, LPVOID lpBuffer, DWORD dwBufferLength );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "578c7130-7426-4a2e-ae0f-ed8a84449b06")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetSetOption(HINTERNET hInternet, InternetOptionFlags dwOption, IntPtr lpBuffer, int dwBufferLength);

	/// <summary>Sets an Internet option</summary>
	/// <param name="hInternet">Handle on which to set information.</param>
	/// <param name="option">Internet option to be set. This can be one of the Option Flags values.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	public static bool InternetSetOption(HINTERNET hInternet, InternetOptionFlags option)
	{
		var attrs = CorrespondingTypeAttribute.GetCorrespondingTypes(option, CorrespondingAction.Set);
		if (!attrs.Any() || attrs.First() != null)
			throw new ArgumentException($"{option} cannot be used to set options that do not require a value.");
		return InternetSetOption(hInternet, option, IntPtr.Zero, 0);
	}

	/// <summary>Sets an Internet option</summary>
	/// <typeparam name="T">The type expected by the option.</typeparam>
	/// <param name="hInternet">Handle on which to set information.</param>
	/// <param name="option">Internet option to be set. This can be one of the Option Flags values.</param>
	/// <param name="value">The option setting value.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get a specific error message, call GetLastError.</returns>
	public static bool InternetSetOption<T>(HINTERNET hInternet, InternetOptionFlags option, T value)
	{
		if (!CorrespondingTypeAttribute.CanSet(option, typeof(T))) throw new ArgumentException($"{option} cannot be used to set values of type {typeof(T)}.");
		using SafeAllocatedMemoryHandle hMem = typeof(T) == typeof(string) ? new SafeCoTaskMemString(value?.ToString(), CharSet.Auto) : (typeof(T) == typeof(bool) ? SafeCoTaskMemHandle.CreateFromStructure(Convert.ToUInt32(value)) : SafeCoTaskMemHandle.CreateFromStructure(value));
		return InternetSetOption(hInternet, option, hMem, typeof(T) == typeof(string) ? value?.ToString()?.Length + 1 ?? 0 : (int)hMem.Size);
	}

	/// <summary>
	/// <para>Not supported.</para>
	/// <para>
	/// Implemented only as a stub that calls the InternetSetOption function; <c>InternetSetOptionEx</c> has no functionality of its
	/// own. Do not use this function at this time.
	/// </para>
	/// </summary>
	/// <param name="hInternet">TBD</param>
	/// <param name="dwOption">TBD</param>
	/// <param name="lpBuffer">TBD</param>
	/// <param name="dwBufferLength">TBD</param>
	/// <param name="dwFlags">TBD</param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetoptionexa BOOLAPI InternetSetOptionExA(
	// HINTERNET hInternet, DWORD dwOption, LPVOID lpBuffer, DWORD dwBufferLength, DWORD dwFlags );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "535e4f38-d941-4b69-8c48-ea47f3fbd5e7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetSetOptionEx(HINTERNET hInternet, uint dwOption, IntPtr lpBuffer, uint dwBufferLength, uint dwFlags);

	/// <summary>Sets a decision on cookies for a given domain.</summary>
	/// <param name="pchHostName">An <c>LPCTSTR</c> that points to a string containing a domain.</param>
	/// <param name="dwDecision">A value of type <c>DWORD</c> that contains one of the InternetCookieState enumeration values.</param>
	/// <returns>Returns <c>TRUE</c> if the decision is set and <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>
	/// WinINet minimizes the domain specified in the pchHostName parameter and sets the cookie policy on the minimum legal domain. For
	/// example, if the specified host name is widgets.microsoft.com, the policy is set on the minimized host name microsoft.com.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetpersitecookiedecisiona BOOLAPI
	// InternetSetPerSiteCookieDecisionA( LPCSTR pchHostName, DWORD dwDecision );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "c25699b9-f79a-443b-b9a4-461c379fa8e4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetSetPerSiteCookieDecision(string pchHostName, InternetCookieState dwDecision);

	/// <summary>
	/// The InternetSetStatusCallback function sets up a callback function that WinINet functions can call as progress is made during an operation.
	/// </summary>
	/// <param name="hInternet">The handle for which the callback is set.</param>
	/// <param name="lpfnInternetCallback">
	/// A pointer to the callback function to call when progress is made, or <c>NULL</c> to remove the existing callback function. For
	/// more information about the callback function, see InternetStatusCallback.
	/// </param>
	/// <returns>
	/// Returns the previously defined status callback function if successful, <c>NULL</c> if there was no previously defined status
	/// callback function, or INTERNET_INVALID_STATUS_CALLBACK if the callback function is not valid.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Both synchronous and asynchronous functions use the callback function to indicate the progress of the request, such as resolving
	/// a name, connecting to a server, and so on. The callback function is required for an asynchronous operation. The asynchronous
	/// request will call back to the application with INTERNET_STATUS_REQUEST_COMPLETE to indicate the request has been completed.
	/// </para>
	/// <para>
	/// A callback function can be set on any handle, and is inherited by derived handles. A callback function can be changed using
	/// <c>InternetSetStatusCallback</c>, providing there are no pending requests that need to use the previous callback value. Note,
	/// however, that changing the callback function on a handle does not change the callbacks on derived handles, such as that returned
	/// by InternetConnect. You must change the callback function at each level.
	/// </para>
	/// <para>
	/// Many of the WinINet functions perform several operations on the network. Each operation can take time to complete, and each can fail.
	/// </para>
	/// <para>
	/// It is sometimes desirable to display status information during a long-term operation. You can display status information by
	/// setting up an Internet status callback function that cannot be removed as long as any callbacks or any asynchronous functions
	/// are pending.
	/// </para>
	/// <para>
	/// After initiating <c>InternetSetStatusCallback</c>, the callback function can be accessed from within any WinINet function for
	/// monitoring time-intensive network operations.
	/// </para>
	/// <para>
	/// <c>Note</c> The callback function specified in the lpfnInternetCallback parameter will not be called on asynchronous operations
	/// for the request handle when the dwContext parameter of HttpOpenRequest is set to zero ( <c>INTERNET_NO_CALLBACK</c>), or the
	/// connection handle when the dwContext handle of InternetConnect is set to zero ( <c>INTERNET_NO_CALLBACK</c>).
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetsetstatuscallback void InternetSetStatusCallback(
	// HINTERNET hInternet, INTERNET_STATUS_CALLBACK lpfnInternetCallback );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "fe15627b-c77b-45c0-8ff6-02faa8512b57")]
	public static extern IntPtr InternetSetStatusCallback(HINTERNET hInternet, InternetStatusCallback? lpfnInternetCallback);

	/// <summary>Formats a date and time according to the HTTP version 1.0 specification.</summary>
	/// <param name="pst">Pointer to a SYSTEMTIME structure that contains the date and time to format.</param>
	/// <param name="dwRFC">RFC format used. Currently, the only valid format is INTERNET_RFC1123_FORMAT.</param>
	/// <param name="lpszTime">Pointer to a string buffer that receives the formatted date and time. The buffer should be of size INTERNET_RFC1123_BUFSIZE.</param>
	/// <param name="cbTime">Size of the lpszTime buffer, in bytes.</param>
	/// <returns>Returns TRUE if the function succeeds, or FALSE otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internettimefromsystemtime BOOLAPI
	// InternetTimeFromSystemTime( const SYSTEMTIME *pst, DWORD dwRFC, LPSTR lpszTime, DWORD cbTime );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "b52ba402-bad1-4005-b9d0-7630194272d1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetTimeFromSystemTime(in SYSTEMTIME pst, INTERNET_RFC dwRFC, StringBuilder lpszTime, uint cbTime);

	/// <summary>Converts an HTTP time/date string to a SYSTEMTIME structure.</summary>
	/// <param name="lpszTime">Pointer to a null-terminated string that specifies the date/time to be converted.</param>
	/// <param name="pst">Pointer to a SYSTEMTIME structure that receives the converted time.</param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the string was converted, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internettimetosystemtime BOOLAPI InternetTimeToSystemTime(
	// LPCSTR lpszTime, SYSTEMTIME *pst, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "fcfe99de-13b2-4e93-a978-f013ddae89f0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetTimeToSystemTime(string lpszTime, out SYSTEMTIME pst, uint dwReserved = 0);

	/// <summary>Unlocks a file that was locked using InternetLockRequestFile.</summary>
	/// <param name="hLockRequestInfo">Handle to a lock request that was returned by InternetLockRequestFile.</param>
	/// <returns>Returns TRUE if successful, or FALSE otherwise. To get a specific error message, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetunlockrequestfile BOOLAPI
	// InternetUnlockRequestFile( HANDLE hLockRequestInfo );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "356f7277-66ef-450f-ab5a-0303d0b1d807")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetUnlockRequestFile(HANDLE hLockRequestInfo);

	/// <summary>Writes data to an open Internet file.</summary>
	/// <param name="hFile">Handle returned from a previous call to FtpOpenFile or an HINTERNET handle sent by HttpSendRequestEx.</param>
	/// <param name="lpBuffer">Pointer to a buffer that contains the data to be written to the file.</param>
	/// <param name="dwNumberOfBytesToWrite">Number of bytes to be written to the file.</param>
	/// <param name="lpdwNumberOfBytesWritten">
	/// Pointer to a variable that receives the number of bytes written to the file. <c>InternetWriteFile</c> sets this value to zero
	/// before doing any work or error checking.
	/// </param>
	/// <returns>
	/// Returns TRUE if the function succeeds, or FALSE otherwise. To get extended error information, call GetLastError. An application
	/// can also use InternetGetLastResponseInfo when necessary.
	/// </returns>
	/// <remarks>
	/// <para>When the application is sending data, it must call InternetCloseHandle to end the data transfer.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetwritefile BOOLAPI InternetWriteFile( HINTERNET
	// hFile, LPCVOID lpBuffer, DWORD dwNumberOfBytesToWrite, LPDWORD lpdwNumberOfBytesWritten );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "3bf8d4d8-9193-4aed-acf9-8d7207b332a5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetWriteFile(HINTERNET hFile, IntPtr lpBuffer, uint dwNumberOfBytesToWrite, out uint lpdwNumberOfBytesWritten);

	/// <summary>Writes data to an open Internet file.</summary>
	/// <param name="hFile">Handle returned from a previous call to FtpOpenFile or an HINTERNET handle sent by HttpSendRequestEx.</param>
	/// <param name="lpBuffer">Pointer to a buffer that contains the data to be written to the file.</param>
	/// <param name="dwNumberOfBytesToWrite">Number of bytes to be written to the file.</param>
	/// <param name="lpdwNumberOfBytesWritten">
	/// Pointer to a variable that receives the number of bytes written to the file. <c>InternetWriteFile</c> sets this value to zero
	/// before doing any work or error checking.
	/// </param>
	/// <returns>
	/// Returns TRUE if the function succeeds, or FALSE otherwise. To get extended error information, call GetLastError. An application
	/// can also use InternetGetLastResponseInfo when necessary.
	/// </returns>
	/// <remarks>
	/// <para>When the application is sending data, it must call InternetCloseHandle to end the data transfer.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-internetwritefile BOOLAPI InternetWriteFile( HINTERNET
	// hFile, LPCVOID lpBuffer, DWORD dwNumberOfBytesToWrite, LPDWORD lpdwNumberOfBytesWritten );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "3bf8d4d8-9193-4aed-acf9-8d7207b332a5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InternetWriteFile(HINTERNET hFile, byte[] lpBuffer, int dwNumberOfBytesToWrite, out uint lpdwNumberOfBytesWritten);

	/// <summary>Retrieves the privacy settings for a given URLZONE and PrivacyType.</summary>
	/// <param name="dwZone">A value of type DWORD that specifies the URLZONE for which privacy settings are being retrieved.</param>
	/// <param name="dwType">A value of type DWORD that specifies the PrivacyType for which privacy settings are being retrieved.</param>
	/// <param name="pdwTemplate">
	/// An <c>LPDWORD</c> that returns a pointer to a <c>DWORD</c> containing which of the PrivacyTemplates is in use for this dwZone
	/// and dwType.
	/// </param>
	/// <param name="pszBuffer">
	/// An <c>LPWSTR</c> that points to a buffer containing a <c>LPCWSTR</c> representing a string version of the pdwTemplate or a
	/// customized string if the pdwTemplate is set to <c>PRIVACY_TEMPLATE_CUSTOM</c>. See PrivacySetZonePreferenceW for a description
	/// of a customized privacy preferences string.
	/// </param>
	/// <param name="pdwBufferLength">
	/// An <c>LPDWORD</c> that contains the buffer length in characters. If the buffer length is not sufficient,
	/// <c>PrivacyGetZonePreferenceW</c> returns with this parameter set to the number of characters required and with a return value of <c>ERROR_MORE_DATA</c>.
	/// </param>
	/// <returns>Returns zero if successful. Otherwise, one of the Error Messages defined in winerr.h is returned.</returns>
	/// <remarks>
	/// <para>These privacy settings for the Internet zone are found on the Privacy tab of the Internet Options dialog box.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-privacygetzonepreferencew void PrivacyGetZonePreferenceW(
	// DWORD dwZone, DWORD dwType, LPDWORD pdwTemplate, LPWSTR pszBuffer, LPDWORD pdwBufferLength );
	[DllImport(Lib.WinInet, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("wininet.h", MSDNShortId = "530a86a0-bb67-406a-be83-5f2b463a1aa1")]
	public static extern Win32Error PrivacyGetZonePreferenceW(URLZONE dwZone, PrivacyType dwType, out PrivacyTemplate pdwTemplate, StringBuilder pszBuffer, ref uint pdwBufferLength);

	/// <summary>Sets the privacy settings for a given URLZONE and PrivacyType.</summary>
	/// <param name="dwZone">Value of type <c>DWORD</c> that specifies the URLZONEfor which privacy settings are being set.</param>
	/// <param name="dwType">Value of type <c>DWORD</c> that specifies the PrivacyType for which privacy settings are being set.</param>
	/// <param name="dwTemplate">
	/// Value of type <c>DWORD</c> that specifies which of the privacy templates is to be used to set the privacy settings.
	/// </param>
	/// <param name="pszPreference">
	/// If dwTemplate is set to <c>PRIVACY_TEMPLATE_CUSTOM</c>, this parameter is the string representation of the custom preferences.
	/// Otherwise, it should be set to <c>NULL</c>. A description of this string representation is included in the Remarks section.
	/// </param>
	/// <returns>Returns zero if successful. Otherwise, one of the errors defined in winerr.h is returned.</returns>
	/// <remarks>
	/// <para>
	/// These privacy settings for the Internet zone are found on the <c>Privacy</c> tab of the <c>Internet Options</c> dialog box.
	/// </para>
	/// <para>
	/// Setting the privacy options for the URLZONE_INTERNET involves setting the privacy templates for both PrivacyTypes. The slider on
	/// the <c>Privacy</c> Menu in <c>Internet Options</c> only moves if privacy is set for both <c>PrivacyTypes</c>.
	/// </para>
	/// <para>
	/// Custom privacy preferences for a given URLZONE and PrivacyType can be set through the pszPreference parameter. The pszPreference
	/// parameter can contain a series of rules separated by white space describing the privacy preferences. It is important to note
	/// that the rules themselves cannot contain white space. The pszPreference has the following structure where there can be multiple
	/// logical rules: &lt;signature&gt; &lt;logical-rule&gt; &lt;special-rule&gt;.
	/// </para>
	/// <para>Currently, the signature must be set to IE6-P3PSettings/V1:.</para>
	/// <para>Logical rules have the following format: /&lt;expression&gt;=&lt;decision&gt;/.</para>
	/// <para>
	/// An expression is a Boolean statement composed of compact policy tokens using the operators &amp; (logical AND) and ! (logical
	/// NOT). The compact policy token is case-sensitive. (For more information on Platform for Privacy Preferences (P3P) privacy
	/// policies and compact policy tokens, see the W3C: Platform for Privacy Preferences (P3P) Project specification.) The decision is
	/// a single lowercase character that defines the action to take on the cookie whose compact policy contains the specified token(s).
	/// The following table lists valid decision characters.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Character</term>
	/// <term>Definition</term>
	/// </listheader>
	/// <item>
	/// <term>a</term>
	/// <term>Accept the cookie.</term>
	/// </item>
	/// <item>
	/// <term>p</term>
	/// <term>Prompt user to accept or deny the cookie.</term>
	/// </item>
	/// <item>
	/// <term>r</term>
	/// <term>Reject the cookie.</term>
	/// </item>
	/// <item>
	/// <term>l</term>
	/// <term>Leash the cookie (only send it in a first-party context).</term>
	/// </item>
	/// <item>
	/// <term>d</term>
	/// <term>Downgrade the cookie, if it is a persistent cookie, to a session cookie.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Logical rules are evaluated in the order they are listed. The first logical-rule to be matched, if any, determines the cookie action.
	/// </para>
	/// <para>
	/// An empty expression is also allowed. If an expression is empty, the left side evaluates to true. This form of a logical-rule can
	/// be used at the end of a set of rules to catch all situations that did not fall into the other categories.
	/// </para>
	/// <para>The following examples show valid logical rules.</para>
	/// <para>
	/// Special rules are specified using the nopolicy, session, and always symbols. The nopolicy symbol is used to specify the action
	/// to taken when there is no compact policy. For example nopolicy=d specifies to downgrade all cookies without a compact policy to
	/// session cookies. The session symbol is used to specify the action to take on session cookies and can only be set to a. When
	/// session=a is specified, all session cookies are accepted regardless of the content of the compact policy. If this rule is not
	/// specified, session cookies are subject to the same rules as persistent cookies. Finally, the always symbol is used to specify to
	/// perform the same action for everything. For example, always=d specifies to deny all cookies regardless of the existence of a
	/// compact policy. Note that always=d is equivalent to /=d/.
	/// </para>
	/// <para>
	/// The following example shows a privacy preferences string that specifies to accept cookies for which the compact policy contains
	/// a FIN/CONi token pair, reject cookies with compact policies containing FIN/CON, FIN/CONo, FIN/CONa and GOV/PUB token pairs or a
	/// TEL token, and to prompt the user when a cookie's compact policy contains the UNR token. It also specifies to downgrade cookies
	/// without a compact policy to session cookies and to accept all cookies that do not match one of the given rules. Note that the
	/// first rule that evaluates to true determines the cookie action.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-privacysetzonepreferencew void PrivacySetZonePreferenceW(
	// DWORD dwZone, DWORD dwType, DWORD dwTemplate, LPCWSTR pszPreference );
	[DllImport(Lib.WinInet, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("wininet.h", MSDNShortId = "29c8dbc0-052e-40f4-a036-cb647d920055")]
	public static extern Win32Error PrivacySetZonePreferenceW(URLZONE dwZone, PrivacyType dwType, PrivacyTemplate dwTemplate, [Optional] string? pszPreference);

	/// <summary>Reads the cached data from a stream that has been opened using the RetrieveUrlCacheEntryStream function.</summary>
	/// <param name="hUrlCacheStream">Handle that was returned by the RetrieveUrlCacheEntryStream function.</param>
	/// <param name="dwLocation">Offset to be read from.</param>
	/// <param name="lpBuffer">Pointer to a buffer that receives the data.</param>
	/// <param name="lpdwLen">
	/// Pointer to a variable that specifies the size of the lpBuffer buffer, in bytes. When the function returns, the variable contains
	/// the number of bytes copied to the buffer, or the required size of the buffer, in bytes.
	/// </param>
	/// <param name="Reserved">This parameter is reserved and must be 0.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <para>
	/// If the buffer size is not sufficient, GetLastError returns ERROR_INSUFFICIENT_BUFFER and sets lpdwLen to the size necessary to
	/// contain all the information.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-readurlcacheentrystream BOOLAPI ReadUrlCacheEntryStream(
	// HANDLE hUrlCacheStream, DWORD dwLocation, LPVOID lpBuffer, LPDWORD lpdwLen, DWORD Reserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "8cfd0c64-25ca-4f08-b9b3-2743ded18030")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadUrlCacheEntryStream(HCACHEENTRYSTREAM hUrlCacheStream, uint dwLocation, IntPtr lpBuffer, ref uint lpdwLen, uint Reserved = 0);

	/// <summary>The <c>ResumeSuspendedDownload</c> function resumes a request that is suspended by a user interface dialog box.</summary>
	/// <param name="hRequest">Handle of the request that is suspended by a user interface dialog box.</param>
	/// <param name="dwResultCode">The error result returned from InternetErrorDlg, or zero if a different dialog is invoked.</param>
	/// <returns>Returns <c>TRUE</c> if successful; otherwise <c>FALSE</c>. Call GetLastError for extended error information.</returns>
	/// <remarks>
	/// <para>
	/// Applications that use WinINet functions asynchronously can call <c>ResumeSuspendedDownload</c> to resume a request that is
	/// suspended by a user interface dialog box.
	/// </para>
	/// <para>
	/// For example, call <c>ResumeSuspendedDownload</c> after a call to InternetErrorDlg, or in an InternetStatusCallback function when
	/// the lpvStatusInformation parameter equals <c>INTERNET_STATUS_USER_INPUT_REQUIRED</c>. The following code example shows you how
	/// to use the <c>ResumeSuspendedDownload</c> function in a callback.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// <para>Examples</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-resumesuspendeddownload BOOLAPI ResumeSuspendedDownload(
	// HINTERNET hRequest, DWORD dwResultCode );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "72b5511a-872d-4058-9f38-9b1bdf6784c3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ResumeSuspendedDownload(HINTERNET hRequest, Win32Error dwResultCode);

	/// <summary>Locks the cache entry file associated with the specified URL.</summary>
	/// <param name="lpszUrlName">
	/// Pointer to a string that contains the URL of the resource associated with the cache entry. This must be a unique name. The name
	/// string should not contain any escape characters.
	/// </param>
	/// <param name="lpCacheEntryInfo">
	/// Pointer to a cache entry information buffer. If the buffer is not sufficient, this function returns ERROR_INSUFFICIENT_BUFFER
	/// and sets lpdwCacheEntryInfoBufferSize to the number of bytes required.
	/// </param>
	/// <param name="lpcbCacheEntryInfo">
	/// Pointer to an unsigned long integer variable that specifies the size of the lpCacheEntryInfo buffer, in bytes. When the function
	/// returns, the variable contains the size, in bytes, of the actual buffer used or the number of bytes required to retrieve the
	/// cache entry file. The caller should check the return value in this parameter. If the return size is less than or equal to the
	/// size passed in, all the relevant data has been returned.
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError. Possible
	/// error values include:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The cache entry specified by the source name is not found in the cache storage.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The size of the lpCacheEntryInfo buffer as specified by lpdwCacheEntryInfoBufferSize is not sufficient to contain all the
	/// information. The value returned in lpdwCacheEntryInfoBufferSize indicates the buffer size necessary to get all the information.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>RetrieveUrlCacheEntryFile</c> does not do any URL parsing, so a URL containing an anchor (#) will not be found in the cache,
	/// even if the resource is cached. For example, if the URL http://adatum.com/example.htm#sample was passed, the function would
	/// return ERROR_FILE_NOT_FOUND even if http://adatum.com/example.htm is in the cache.
	/// </para>
	/// <para>
	/// The file is locked for the caller when it is retrieved; the caller should unlock the file after the caller is finished with the
	/// file. The cache manager automatically unlocks the files after a certain interval. While the file is locked, the cache manager
	/// will not remove the file from the cache. It is important to note that this function may or may not perform efficiently,
	/// depending on the internal implementation of the cache. For instance, if the URL data is stored in a packed file that contains
	/// data for other URLs, the cache will make a copy of the data to a file in a temporary directory maintained by the cache. The
	/// cache will eventually delete the copy. It is recommended that this function be used only in situations where a file name is
	/// needed to launch an application. RetrieveUrlCacheEntryStream and associated stream functions should be used in most cases.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-retrieveurlcacheentryfilea BOOLAPI
	// RetrieveUrlCacheEntryFileA( LPCSTR lpszUrlName, LPINTERNET_CACHE_ENTRY_INFOA lpCacheEntryInfo, LPDWORD lpcbCacheEntryInfo, DWORD
	// dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "eb311b8d-560d-4742-af4c-b5afe660c8e5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RetrieveUrlCacheEntryFile(string lpszUrlName, IntPtr lpCacheEntryInfo, ref uint lpcbCacheEntryInfo, uint dwReserved = 0);

	/// <summary>Provides the most efficient and implementation-independent way to access the cache data.</summary>
	/// <param name="lpszUrlName">
	/// Pointer to a null-terminated string that contains the source name of the cache entry. This must be a unique name. The name
	/// string should not contain any escape characters.
	/// </param>
	/// <param name="lpCacheEntryInfo">
	/// Pointer to an INTERNET_CACHE_ENTRY_INFO structure that receives information about the cache entry.
	/// </param>
	/// <param name="lpcbCacheEntryInfo">
	/// Pointer to a variable that specifies the size, in bytes, of the lpCacheEntryInfo buffer. When the function returns, the variable
	/// receives the number of bytes copied to the buffer or the required size, in bytes, of the buffer. Note that this buffer size must
	/// accommodate both the INTERNET_CACHE_ENTRY_INFO structure and the associated strings that are stored immediately following it.
	/// </param>
	/// <param name="fRandomRead">
	/// Whether the stream is open for random access. Set the flag to <c>TRUE</c> to open the stream for random access.
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a valid handle for use in the ReadUrlCacheEntryStream and
	/// UnlockUrlCacheEntryStream functions.
	/// </para>
	/// <para>If the function fails, it returns <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// <para>Possible error values include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The cache entry specified by the source name is not found in the cache storage.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>
	/// The size of lpCacheEntryInfo as specified by lpdwCacheEntryInfoBufferSize is not sufficient to contain all the information. The
	/// value returned in lpdwCacheEntryInfoBufferSize indicates the buffer size necessary to contain all the information.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>RetrieveUrlCacheEntryStream</c> does not do any URL parsing, so a URL containing an anchor (#) will not be found in the
	/// cache, even if the resource is cached. For example, if the URL http://adatum.com/example.htm#sample is passed, the function
	/// returns ERROR_FILE_NOT_FOUND even if http://adatum.com/example.htm is in the cache.
	/// </para>
	/// <para>
	/// Cache clients that do not need URL data in the form of a file should use this function to access the data for a particular URL.
	/// </para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-retrieveurlcacheentrystreama void
	// RetrieveUrlCacheEntryStreamA( LPCSTR lpszUrlName, LPINTERNET_CACHE_ENTRY_INFOA lpCacheEntryInfo, LPDWORD lpcbCacheEntryInfo, BOOL
	// fRandomRead, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "0414efb0-d91b-46f0-9fee-0b69ef823029")]
	public static extern SafeHCACHEENTRYSTREAM RetrieveUrlCacheEntryStream(string lpszUrlName, IntPtr lpCacheEntryInfo, ref uint lpcbCacheEntryInfo,
		[MarshalAs(UnmanagedType.Bool)] bool fRandomRead, uint dwReserved = 0);

	/// <summary>Adds entries to or removes entries from a cache group.</summary>
	/// <param name="lpszUrlName">Pointer to a <c>null</c>-terminated string value that specifies the URL of the cached resource.</param>
	/// <param name="dwFlags">
	/// <para>Determines whether the entry is added to or removed from a cache group. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_CACHE_GROUP_ADD</term>
	/// <term>Adds the cache entry to the cache group.</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_CACHE_GROUP_REMOVE</term>
	/// <term>Removes the entry from the cache group.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="GroupId">Identifier of the cache group that the entry will be added to or removed from.</param>
	/// <param name="pbGroupAttributes">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="cbGroupAttributes">This parameter is reserved and must be 0.</param>
	/// <param name="lpReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</returns>
	/// <remarks>
	/// <para>A cache entry can belong to more than one cache group.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-seturlcacheentrygroup BOOLAPI SetUrlCacheEntryGroup( LPCSTR
	// lpszUrlName, DWORD dwFlags, GROUPID GroupId, LPBYTE pbGroupAttributes, DWORD cbGroupAttributes, LPVOID lpReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "b39a96ac-c5b5-4b02-88e2-298a037be25f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetUrlCacheEntryGroup(string lpszUrlName, INTERNET_CACHE_GROUP dwFlags, long GroupId, IntPtr pbGroupAttributes = default,
		uint cbGroupAttributes = 0, IntPtr lpReserved = default);

	/// <summary>Sets the specified members of the INTERNET_CACHE_ENTRY_INFO structure.</summary>
	/// <param name="lpszUrlName">
	/// Pointer to a null-terminated string that specifies the name of the cache entry. The name string should not contain any escape characters.
	/// </param>
	/// <param name="lpCacheEntryInfo">
	/// Pointer to an INTERNET_CACHE_ENTRY_INFO structure containing the values to be assigned to the cache entry designated by lpszUrlName.
	/// </param>
	/// <param name="dwFieldControl">
	/// <para>Indicates the members that are to be set. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CACHE_ENTRY_ACCTIME_FC</term>
	/// <term>Sets the last access time.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_ATTRIBUTE_FC</term>
	/// <term>Sets the cache entry type.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_EXEMPT_DELTA_FC</term>
	/// <term>Sets the exempt delta.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_EXPTIME_FC</term>
	/// <term>Sets the expire time.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_HEADERINFO_FC</term>
	/// <term>Not currently implemented.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_HITRATE_FC</term>
	/// <term>Sets the hit rate.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_MODTIME_FC</term>
	/// <term>Sets the last modified time.</term>
	/// </item>
	/// <item>
	/// <term>CACHE_ENTRY_SYNCTIME_FC</term>
	/// <term>Sets the last sync time.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// Returns TRUE if successful, or FALSE otherwise. To get extended error information, call GetLastError. Possible error values
	/// include the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The specified cache entry is not found in the cache.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The value(s) to be set is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-seturlcacheentryinfow BOOLAPI SetUrlCacheEntryInfoW(
	// LPCWSTR lpszUrlName, LPINTERNET_CACHE_ENTRY_INFOW lpCacheEntryInfo, DWORD dwFieldControl );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "71f6e1a3-09ce-4576-9480-1270f343db39")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetUrlCacheEntryInfo(string lpszUrlName, in INTERNET_CACHE_ENTRY_INFO lpCacheEntryInfo, CACHE_ENTRY_FC dwFieldControl);

	/// <summary>Unlocks the cache entry that was locked while the file was retrieved for use from the cache.</summary>
	/// <param name="lpszUrlName">
	/// Pointer to a <c>null</c>-terminated string that specifies the source name of the cache entry that is being unlocked. The name
	/// string should not contain any escape characters.
	/// </param>
	/// <param name="dwReserved">This parameter is reserved and must be 0.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.
	/// ERROR_FILE_NOT_FOUND indicates that the cache entry specified by the source name is not found in the cache storage.
	/// </returns>
	/// <remarks>
	/// <para>The application should not access the file after calling this function.</para>
	/// <para>When this function returns, the cache manager is free to delete the cache entry.</para>
	/// <para>
	/// Like all other aspects of the WinINet API, this function cannot be safely called from within DllMain or the constructors and
	/// destructors of global objects.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-unlockurlcacheentryfile BOOLAPI UnlockUrlCacheEntryFile(
	// LPCSTR lpszUrlName, DWORD dwReserved );
	[DllImport(Lib.WinInet, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wininet.h", MSDNShortId = "ccc650dc-1759-4438-85d5-539c71d21a74")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnlockUrlCacheEntryFile(string lpszUrlName, uint dwReserved = 0);

	/// <summary>Closes the stream that has been retrieved using the RetrieveUrlCacheEntryStream function.</summary>
	/// <param name="hUrlCacheStream">Handle that was returned by the RetrieveUrlCacheEntryStream function.</param>
	/// <param name="Reserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise. To get extended error information, call GetLastError.</returns>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/nf-wininet-unlockurlcacheentrystream BOOLAPI
	// UnlockUrlCacheEntryStream( HANDLE hUrlCacheStream, DWORD Reserved );
	[DllImport(Lib.WinInet, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wininet.h", MSDNShortId = "9fcc257e-732c-4545-a81b-7db20a98e497")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnlockUrlCacheEntryStream(HANDLE hUrlCacheStream, uint Reserved = 0);

	[DllImport("inetcpl.cpl", SetLastError = true)]
	private static extern int LaunchInternetControlPanel(HWND hWnd);

	/// <summary>
	/// <para>
	/// [The <c>GOPHER_ATTRIBUTE_TYPE</c> structure is available for use in the operating systems specified in the Requirements section.]
	/// </para>
	/// <para>Contains the relevant information of a single Gopher attribute for an object.</para>
	/// </summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-gopher_attribute_type typedef struct { DWORD CategoryId;
	// DWORD AttributeId; union { GOPHER_ADMIN_ATTRIBUTE_TYPE Admin; GOPHER_MOD_DATE_ATTRIBUTE_TYPE ModDate; GOPHER_TTL_ATTRIBUTE_TYPE
	// Ttl; GOPHER_SCORE_ATTRIBUTE_TYPE Score; GOPHER_SCORE_RANGE_ATTRIBUTE_TYPE ScoreRange; GOPHER_SITE_ATTRIBUTE_TYPE Site;
	// GOPHER_ORGANIZATION_ATTRIBUTE_TYPE Organization; GOPHER_LOCATION_ATTRIBUTE_TYPE Location;
	// GOPHER_GEOGRAPHICAL_LOCATION_ATTRIBUTE_TYPE GeographicalLocation; GOPHER_TIMEZONE_ATTRIBUTE_TYPE TimeZone;
	// GOPHER_PROVIDER_ATTRIBUTE_TYPE Provider; GOPHER_VERSION_ATTRIBUTE_TYPE Version; GOPHER_ABSTRACT_ATTRIBUTE_TYPE Abstract;
	// GOPHER_VIEW_ATTRIBUTE_TYPE View; GOPHER_VERONICA_ATTRIBUTE_TYPE Veronica; GOPHER_ASK_ATTRIBUTE_TYPE Ask;
	// GOPHER_UNKNOWN_ATTRIBUTE_TYPE Unknown; } AttributeType; } GOPHER_ATTRIBUTE_TYPE, *LPGOPHER_ATTRIBUTE_TYPE;
	[PInvokeData("wininet.h", MSDNShortId = "01daae8c-9080-4a8d-9f73-3e364ca868fe")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GOPHER_ATTRIBUTE_TYPE
	{
		/// <summary>
		/// <para>Name of the Gopher category for the attribute. The possible values include:</para>
		/// <para>GOPHER_CATEGORY_ID_ABSTRACT</para>
		/// <para>GOPHER_CATEGORY_ID_ADMIN</para>
		/// <para>GOPHER_CATEGORY_ID_ALL</para>
		/// <para>GOPHER_CATEGORY_ID_INFO</para>
		/// <para>GOPHER_CATEGORY_ID_UNKNOWN</para>
		/// <para>GOPHER_CATEGORY_ID_VERONICA</para>
		/// <para>GOPHER_CATEGORY_ID_VIEWS</para>
		/// </summary>
		public GOPHER_CATEGORY_ID CategoryId;

		/// <summary>
		/// <para>Attribute type. The possible values include:</para>
		/// <para>GOPHER_ATTRIBUTE_ID_ABSTRACT</para>
		/// <para>GOPHER_ATTRIBUTE_ID_ADMIN</para>
		/// <para>GOPHER_ATTRIBUTE_ID_GEOG</para>
		/// <para>GOPHER_ATTRIBUTE_ID_LOCATION</para>
		/// <para>GOPHER_ATTRIBUTE_ID_MOD_DATE</para>
		/// <para>GOPHER_ATTRIBUTE_ID_ORG</para>
		/// <para>GOPHER_ATTRIBUTE_ID_PROVIDER</para>
		/// <para>GOPHER_ATTRIBUTE_ID_RANGE</para>
		/// <para>GOPHER_ATTRIBUTE_ID_SCORE</para>
		/// <para>GOPHER_ATTRIBUTE_ID_SITE</para>
		/// <para>GOPHER_ATTRIBUTE_ID_TIMEZONE</para>
		/// <para>GOPHER_ATTRIBUTE_ID_TREEWALK</para>
		/// <para>GOPHER_ATTRIBUTE_ID_TTL</para>
		/// <para>GOPHER_ATTRIBUTE_ID_UNKNOWN</para>
		/// <para>GOPHER_ATTRIBUTE_ID_VERSION</para>
		/// <para>GOPHER_ATTRIBUTE_ID_VIEW</para>
		/// </summary>
		public GOPHER_ATTRIBUTE_ID AttributeId;

		/// <summary>
		/// Data for the Gopher attribute. The specific structure depends on the <c>AttributeId</c> member. The definitions of these
		/// data structures are available in WinInet.h.
		/// </summary>
		public ATTRIBUTETYPE AttributeType;

		/// <summary>
		/// Data for the Gopher attribute. The specific structure depends on the <c>AttributeId</c> member. The definitions of these
		/// data structures are available in WinInet.h.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct ATTRIBUTETYPE
		{
			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_ADMIN_ATTRIBUTE_TYPE Admin;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_MOD_DATE_ATTRIBUTE_TYPE ModDate;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_TTL_ATTRIBUTE_TYPE Ttl;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_SCORE_ATTRIBUTE_TYPE Score;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_SCORE_RANGE_ATTRIBUTE_TYPE ScoreRange;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_SITE_ATTRIBUTE_TYPE Site;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_ORGANIZATION_ATTRIBUTE_TYPE Organization;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_LOCATION_ATTRIBUTE_TYPE Location;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_GEOGRAPHICAL_LOCATION_ATTRIBUTE_TYPE GeographicalLocation;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_TIMEZONE_ATTRIBUTE_TYPE TimeZone;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_PROVIDER_ATTRIBUTE_TYPE Provider;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_VERSION_ATTRIBUTE_TYPE Version;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_ABSTRACT_ATTRIBUTE_TYPE Abstract;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_VIEW_ATTRIBUTE_TYPE View;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_VERONICA_ATTRIBUTE_TYPE Veronica;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_ASK_ATTRIBUTE_TYPE Ask;

			/// <summary/>
			[FieldOffset(0)]
			public GOPHER_UNKNOWN_ATTRIBUTE_TYPE Unknown;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_ADMIN_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Comment;

				/// <summary/>
				public LPTSTR EmailAddress;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_MOD_DATE_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public FILETIME DateAndTime;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_TTL_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public uint Ttl;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_SCORE_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public int Score;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_SCORE_RANGE_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public int LowerBound;

				/// <summary/>
				public int UpperBound;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_SITE_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Site;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_ORGANIZATION_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Organization;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_LOCATION_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Location;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_GEOGRAPHICAL_LOCATION_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public int DegreesNorth;

				/// <summary/>
				public int MinutesNorth;

				/// <summary/>
				public int SecondsNorth;

				/// <summary/>
				public int DegreesEast;

				/// <summary/>
				public int MinutesEast;

				/// <summary/>
				public int SecondsEast;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_TIMEZONE_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public int Zone;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_PROVIDER_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Provider;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_VERSION_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Version;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_ABSTRACT_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR ShortAbstract;

				/// <summary/>
				public LPTSTR AbstractFile;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_VIEW_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR ContentType;

				/// <summary/>
				public LPTSTR Language;

				/// <summary/>
				public uint Size;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_VERONICA_ATTRIBUTE_TYPE
			{
				/// <summary/>
				[MarshalAs(UnmanagedType.Bool)] public bool TreeWalk;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_ASK_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR QuestionType;

				/// <summary/>
				public LPTSTR QuestionText;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct GOPHER_UNKNOWN_ATTRIBUTE_TYPE
			{
				/// <summary/>
				public LPTSTR Text;
			}
		}
	}

	/// <summary>
	/// <para>[The <c>GOPHER_FIND_DATA</c> structure is available for use in the operating systems specified in the Requirements section.]</para>
	/// <para>Contains information retrieved by the GopherFindFirstFile and InternetFindNextFile functions.</para>
	/// </summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-gopher_find_dataa typedef struct { CHAR
	// DisplayString[MAX_GOPHER_DISPLAY_TEXT + 1]; DWORD GopherType; DWORD SizeLow; DWORD SizeHigh; FILETIME LastModificationTime; CHAR
	// Locator[MAX_GOPHER_LOCATOR_LENGTH + 1]; } GOPHER_FIND_DATAA, *LPGOPHER_FIND_DATAA;
	[PInvokeData("wininet.h", MSDNShortId = "53bcba70-2d6a-465a-86ec-4b11b1474ee1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct GOPHER_FIND_DATA
	{
		/// <summary>Friendly name of an object. An application can display this string to allow the user to select the object.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
		public string DisplayString;

		/// <summary>
		/// <para>Describes the item returned. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GOPHER_TYPE_ASK</term>
		/// <term>Ask+ item.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_BINARY</term>
		/// <term>Binary file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_BITMAP</term>
		/// <term>Bitmap file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_CALENDAR</term>
		/// <term>Calendar file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_CSO</term>
		/// <term>CSO telephone book server.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_DIRECTORY</term>
		/// <term>Directory of additional Gopher items.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_DOS_ARCHIVE</term>
		/// <term>MS-DOS archive file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_ERROR</term>
		/// <term>Indicator of an error condition.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_GIF</term>
		/// <term>GIF graphics file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_GOPHER_PLUS</term>
		/// <term>Gopher+ item.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_HTML</term>
		/// <term>HTML document.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_IMAGE</term>
		/// <term>Image file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_INDEX_SERVER</term>
		/// <term>Index server.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_INLINE</term>
		/// <term>Inline file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_MAC_BINHEX</term>
		/// <term>Macintosh file in BINHEX format.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_MOVIE</term>
		/// <term>Movie file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_PDF</term>
		/// <term>PDF file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_REDUNDANT</term>
		/// <term>
		/// Indicator of a duplicated server. The information contained within is a duplicate of the primary server. The primary server
		/// is defined as the last directory entry that did not have a GOPHER_TYPE_REDUNDANT type.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_SOUND</term>
		/// <term>Sound file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_TELNET</term>
		/// <term>Telnet server.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_TEXT_FILE</term>
		/// <term>ASCII text file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_TN3270</term>
		/// <term>TN3270 server.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_UNIX_UUENCODED</term>
		/// <term>UUENCODED file.</term>
		/// </item>
		/// <item>
		/// <term>GOPHER_TYPE_UNKNOWN</term>
		/// <term>Item type is unknown.</term>
		/// </item>
		/// </list>
		/// </summary>
		public GOPHER_TYPE GopherType;

		/// <summary>Low 32 bits of the file size.</summary>
		public uint SizeLow;

		/// <summary>High 32 bits of the file size.</summary>
		public uint SizeHigh;

		/// <summary>FILETIME structure that contains the time when the file was last modified.</summary>
		public FILETIME LastModificationTime;

		/// <summary>File locator. An application can pass the locator string to GopherOpenFile or GopherFindFirstFile.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 654)]
		public string Locator;
	}

	/// <summary>The <c>InternetCookieHistory</c> structure contains the cookie history.</summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internetcookiehistory typedef struct { BOOL fAccepted; BOOL
	// fLeashed; BOOL fDowngraded; BOOL fRejected; } InternetCookieHistory;
	[PInvokeData("wininet.h", MSDNShortId = "NS:wininet.__unnamed_struct_15")]
	[StructLayout(LayoutKind.Sequential)]
	public struct InternetCookieHistory
	{
		/// <summary>If true, the cookie was accepted.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fAccepted;

		/// <summary>If true, the cookie was leashed.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fLeashed;

		/// <summary>If true, the cookie was downgraded.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDowngraded;

		/// <summary>If true, the cookie was rejected.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fRejected;
	}

	/// <summary>Contains the result of a call to an asynchronous function. This structure is used with InternetStatusCallback.</summary>
	/// <remarks>
	/// <para>The value of <c>dwResult</c> is determined by the value of <c>dwInternetStatus</c> in the status callback function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value of <c>dwInternetStatus</c></term>
	/// <term>Value of <c>dwResult</c></term>
	/// </listheader>
	/// <item>
	/// <term>INTERNET_STATUS_HANDLE_CREATED</term>
	/// <term>Pointer to the HINTERNET handle</term>
	/// </item>
	/// <item>
	/// <term>INTERNET_STATUS_REQUEST_COMPLETE</term>
	/// <term>Boolean return code from the asynchronous function.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internet_async_result typedef struct { DWORD_PTR dwResult; DWORD
	// dwError; } INTERNET_ASYNC_RESULT, *LPINTERNET_ASYNC_RESULT;
	[PInvokeData("wininet.h", MSDNShortId = "NS:wininet.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INTERNET_ASYNC_RESULT
	{
		/// <summary>
		/// Result. This parameter can be an HINTERNET handle, unsigned long integer, or Boolean return code from an asynchronous function.
		/// </summary>
		public IntPtr dwResult;

		/// <summary>
		/// Error code, if <c>dwResult</c> indicates that the function failed. If the operation succeeded, this member usually contains ERROR_SUCCESS.
		/// </summary>
		public Win32Error dwError;
	}

	/// <summary>Contains the notification data for an authentication request.</summary>
	/// <remarks>
	/// <note>WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).</note>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internet_auth_notify_data typedef struct { DWORD cbStruct;
	// DWORD dwOptions; PFN_AUTH_NOTIFY pfnNotify; DWORD_PTR dwContext; } INTERNET_AUTH_NOTIFY_DATA;
	[PInvokeData("wininet.h", MSDNShortId = "d6f36cf7-7a54-4890-aa27-ffb40997cfd6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INTERNET_AUTH_NOTIFY_DATA
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint cbStruct;

		/// <summary>Reserved. Must be 0.</summary>
		public uint dwOptions;

		/// <summary>Notification callback to retry InternetErrorDlg.</summary>
		public InternetAuthNotifyCallback pfnNotify;

		/// <summary>
		/// Pointer to a variable that contains an application-defined value used to identify the application context to pass to the
		/// notification function.
		/// </summary>
		public IntPtr dwContext;

		/// <summary>The default instance of INTERNET_AUTH_NOTIFY_DATA with cbStruct set.</summary>
		public static readonly INTERNET_AUTH_NOTIFY_DATA Default = new() { cbStruct = (uint)Marshal.SizeOf(typeof(INTERNET_AUTH_NOTIFY_DATA)) };
	}

	/// <summary>Contains both the data and header information.</summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internet_buffersa typedef struct _INTERNET_BUFFERSA { DWORD
	// dwStructSize; struct _INTERNET_BUFFERSA *Next; LPCSTR lpcszHeader; DWORD dwHeadersLength; DWORD dwHeadersTotal; LPVOID lpvBuffer;
	// DWORD dwBufferLength; DWORD dwBufferTotal; DWORD dwOffsetLow; DWORD dwOffsetHigh; } INTERNET_BUFFERSA, *LPINTERNET_BUFFERSA;
	[PInvokeData("wininet.h", MSDNShortId = "9381184d-17f4-46ad-bd09-15c7e653d1b9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_BUFFERS
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint dwStructSize;

		/// <summary>Pointer to the next <c>INTERNET_BUFFERS</c> structure.</summary>
		public IntPtr Next;

		/// <summary>Pointer to a string value that contains the headers. This member can be <c>NULL</c>.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpcszHeader;

		/// <summary>Size of the headers, in <c>TCHARs</c>, if <c>lpcszHeader</c> is not <c>NULL</c>.</summary>
		public uint dwHeadersLength;

		/// <summary>Size of the headers, if there is not enough memory in the buffer.</summary>
		public uint dwHeadersTotal;

		/// <summary>Pointer to the data buffer.</summary>
		public IntPtr lpvBuffer;

		/// <summary>Size of the buffer, in bytes, if <c>lpvBuffer</c> is not <c>NULL</c>.</summary>
		public uint dwBufferLength;

		/// <summary>Total size of the resource, in bytes.</summary>
		public uint dwBufferTotal;

		/// <summary>Reserved; do not use.</summary>
		public uint dwOffsetLow;

		/// <summary>Reserved; do not use.</summary>
		public uint dwOffsetHigh;

		/// <summary>The default instance of INTERNET_BUFFERS with dwStructSize set.</summary>
		public static readonly INTERNET_BUFFERS Default = new() { dwStructSize = (uint)Marshal.SizeOf(typeof(INTERNET_BUFFERS)) };
	}

	/// <summary>Contains information about the configuration of the Internet cache.</summary>
	/// <remarks>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winineti/ns-winineti-internet_cache_config_infoa typedef struct
	// _INTERNET_CACHE_CONFIG_INFOA { DWORD dwStructSize; DWORD dwContainer; DWORD dwQuota; DWORD dwReserved4; BOOL fPerUser; DWORD
	// dwSyncMode; DWORD dwNumCachePaths; union { struct { CHAR CachePath[MAX_PATH]; DWORD dwCacheSize; };
	// INTERNET_CACHE_CONFIG_PATH_ENTRYA CachePaths[ANYSIZE_ARRAY]; }; DWORD dwNormalUsage; DWORD dwExemptUsage; }
	// INTERNET_CACHE_CONFIG_INFOA, *LPINTERNET_CACHE_CONFIG_INFOA;
	[PInvokeData("winineti.h", MSDNShortId = "39019a94-6f14-4758-86f7-aba598e23d2e")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_CACHE_CONFIG_INFO
	{
		/// <summary>Size of this structure, in bytes. This value can be used to help determine the version of the cache system.</summary>
		public uint dwStructSize;

		/// <summary>The container that the rest of the data in the struct applies to. 0 (zero) indicates the content container.</summary>
		public uint dwContainer;

		/// <summary>The cache quota limit of the container specified in kilobytes.</summary>
		public uint dwQuota;

		/// <summary>Reserved.</summary>
		public uint dwReserved4;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fPerUser;

		/// <summary>Reserved.</summary>
		public uint dwSyncMode;

		/// <summary>Reserved.</summary>
		public uint dwNumCachePaths;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public INTERNET_CACHE_CONFIG_PATH_ENTRY[] CachePaths;

		/// <summary>The cache size of the container specified in kilobytes.</summary>
		public uint dwNormalUsage;

		/// <summary>The number of kilobytes for this container exempt from scavenging.</summary>
		public uint dwExemptUsage;

		/// <summary>The default instance of INTERNET_CACHE_CONFIG_INFO with dwStructSize set.</summary>
		public static readonly INTERNET_CACHE_CONFIG_INFO Default = new() { dwStructSize = (uint)Marshal.SizeOf(typeof(INTERNET_CACHE_CONFIG_INFO)) };
	}

	/// <summary>Entry in <c>INTERNET_CACHE_CONFIG_INFO</c>.</summary>
	[PInvokeData("winineti.h", MSDNShortId = "39019a94-6f14-4758-86f7-aba598e23d2e")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_CACHE_CONFIG_PATH_ENTRY
	{
		/// <summary>The cache path for the container in dwContainer.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string CachePath;

		/// <summary>The cache size in bytes.</summary>
		public uint dwCacheSize;
	}

	/// <summary>Contains information about an entry in the Internet cache.</summary>
	/// <remarks>
	/// <para>
	/// There is no cache entry size limit, so applications that need to enumerate the cache must be prepared to allocate variable-sized
	/// buffers. For more information, see Using Buffers.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internet_cache_entry_infoa typedef struct
	// _INTERNET_CACHE_ENTRY_INFOA { DWORD dwStructSize; LPSTR lpszSourceUrlName; LPSTR lpszLocalFileName; DWORD CacheEntryType; DWORD
	// dwUseCount; DWORD dwHitRate; DWORD dwSizeLow; DWORD dwSizeHigh; FILETIME LastModifiedTime; FILETIME ExpireTime; FILETIME
	// LastAccessTime; FILETIME LastSyncTime; LPSTR lpHeaderInfo; DWORD dwHeaderInfoSize; LPSTR lpszFileExtension; union { DWORD
	// dwReserved; DWORD dwExemptDelta; }; } INTERNET_CACHE_ENTRY_INFOA, *LPINTERNET_CACHE_ENTRY_INFOA;
	[PInvokeData("wininet.h", MSDNShortId = "7bda08e0-5df0-4087-a5cd-3a25c6ae5ade")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_CACHE_ENTRY_INFO
	{
		/// <summary>Size of this structure, in bytes. This value can be used to help determine the version of the cache system.</summary>
		public uint dwStructSize;

		/// <summary>
		/// Pointer to a null-terminated string that contains the URL name. The string occupies the memory area at the end of this structure.
		/// </summary>
		public LPTSTR lpszSourceUrlName;

		/// <summary>
		/// Pointer to a null-terminated string that contains the local file name. The string occupies the memory area at the end of
		/// this structure.
		/// </summary>
		public LPTSTR lpszLocalFileName;

		/// <summary>
		/// <para>
		/// A bitmask indicating the type of cache entry and its properties. The cache entry types include: history entries
		/// (URLHISTORY_CACHE_ENTRY), cookie entries (COOKIE_CACHE_ENTRY), and normal cached content (NORMAL_CACHE_ENTRY).
		/// </para>
		/// <para>This member can be zero or more of the following property flags, and cache type flags listed below.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EDITED_CACHE_ENTRY</term>
		/// <term>Cache entry file that has been edited externally. This cache entry type is exempt from scavenging.</term>
		/// </item>
		/// <item>
		/// <term>SPARSE_CACHE_ENTRY</term>
		/// <term>Partial response cache entry.</term>
		/// </item>
		/// <item>
		/// <term>STICKY_CACHE_ENTRY</term>
		/// <term>
		/// Sticky cache entry that is exempt from scavenging for the amount of time specified by dwExemptDelta. The default value set
		/// by CommitUrlCacheEntryA and CommitUrlCacheEntryW is one day.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TRACK_OFFLINE_CACHE_ENTRY</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// <item>
		/// <term>TRACK_ONLINE_CACHE_ENTRY</term>
		/// <term>Not currently implemented.</term>
		/// </item>
		/// </list>
		/// <para>The following list contains the cache type flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COOKIE_CACHE_ENTRY</term>
		/// <term>Cookie cache entry.</term>
		/// </item>
		/// <item>
		/// <term>NORMAL_CACHE_ENTRY</term>
		/// <term>Normal cache entry; can be deleted to recover space for new entries.</term>
		/// </item>
		/// <item>
		/// <term>URLHISTORY_CACHE_ENTRY</term>
		/// <term>Visited link cache entry.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CACHE_ENTRY_TYPE CacheEntryType;

		/// <summary>Current number of WinINEet callers using the cache entry.</summary>
		public uint dwUseCount;

		/// <summary>Number of times the cache entry was retrieved.</summary>
		public uint dwHitRate;

		/// <summary>Low-order portion of the file size, in <c>bytes</c>.</summary>
		public uint dwSizeLow;

		/// <summary>High-order portion of the file size, in <c>bytes</c>.</summary>
		public uint dwSizeHigh;

		/// <summary>FILETIME structure that contains the last modified time of this URL, in Greenwich mean time format.</summary>
		public FILETIME LastModifiedTime;

		/// <summary>FILETIME structure that contains the expiration time of this file, in Greenwich mean time format.</summary>
		public FILETIME ExpireTime;

		/// <summary>FILETIME structure that contains the last accessed time, in Greenwich mean time format.</summary>
		public FILETIME LastAccessTime;

		/// <summary>FILETIME structure that contains the last time the cache was synchronized.</summary>
		public FILETIME LastSyncTime;

		/// <summary>
		/// Pointer to a buffer that contains the header information. The buffer occupies the memory at the end of this structure.
		/// </summary>
		public LPTSTR lpHeaderInfo;

		/// <summary>Size of the <c>lpHeaderInfo</c> buffer, in <c>TCHARs</c>.</summary>
		public uint dwHeaderInfoSize;

		/// <summary>
		/// Pointer to a string that contains the file name extension used to retrieve the data as a file. The string occupies the
		/// memory area at the end of this structure.
		/// </summary>
		public LPTSTR lpszFileExtension;

		/// <summary/>
		public uint dwReserved;

		/// <summary>Exemption time from the last accessed time, in seconds.</summary>
		public uint dwExemptDelta;

		/// <summary>The default instance of INTERNET_CACHE_ENTRY_INFO with dwStructSize set.</summary>
		public static readonly INTERNET_CACHE_ENTRY_INFO Default = new() { dwStructSize = (uint)Marshal.SizeOf(typeof(INTERNET_CACHE_ENTRY_INFO)) };
	}

	/// <summary>Contains information about an entry in the Internet cache.</summary>
	/// <remarks>
	/// <para>
	/// There is no cache entry size limit, so applications that need to enumerate the cache must be prepared to allocate variable-sized
	/// buffers. For more information, see Using Buffers.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internet_cache_entry_infoa typedef struct
	// _INTERNET_CACHE_ENTRY_INFOA { DWORD dwStructSize; LPSTR lpszSourceUrlName; LPSTR lpszLocalFileName; DWORD CacheEntryType; DWORD
	// dwUseCount; DWORD dwHitRate; DWORD dwSizeLow; DWORD dwSizeHigh; FILETIME LastModifiedTime; FILETIME ExpireTime; FILETIME
	// LastAccessTime; FILETIME LastSyncTime; LPSTR lpHeaderInfo; DWORD dwHeaderInfoSize; LPSTR lpszFileExtension; union { DWORD
	// dwReserved; DWORD dwExemptDelta; }; } INTERNET_CACHE_ENTRY_INFOA, *LPINTERNET_CACHE_ENTRY_INFOA;
	[PInvokeData("wininet.h", MSDNShortId = "7bda08e0-5df0-4087-a5cd-3a25c6ae5ade")]
	public struct INTERNET_CACHE_ENTRY_INFO_MGD
	{
		/// <summary>A bitmask indicating the type of cache entry and its properties.</summary>
		public CACHE_ENTRY_TYPE CacheEntryType;

		/// <summary>Exemption time from the last accessed time, in seconds.</summary>
		public TimeSpan dwExemptDelta;

		/// <summary>Number of times the cache entry was retrieved.</summary>
		public uint dwHitRate;

		/// <summary>The file size, in <c>bytes</c>.</summary>
		public ulong dwSize;

		/// <summary>Current number of WinINEet callers using the cache entry.</summary>
		public uint dwUseCount;

		/// <summary>FILETIME structure that contains the expiration time of this file, in Greenwich mean time format.</summary>
		public DateTime ExpireTime;

		/// <summary>FILETIME structure that contains the last accessed time, in Greenwich mean time format.</summary>
		public DateTime LastAccessTime;

		/// <summary>FILETIME structure that contains the last modified time of this URL, in Greenwich mean time format.</summary>
		public DateTime LastModifiedTime;

		/// <summary>FILETIME structure that contains the last time the cache was synchronized.</summary>
		public DateTime LastSyncTime;

		/// <summary>
		/// Pointer to a buffer that contains the header information. The buffer occupies the memory at the end of this structure.
		/// </summary>
		public string? lpHeaderInfo;

		/// <summary>
		/// Pointer to a string that contains the file name extension used to retrieve the data as a file. The string occupies the
		/// memory area at the end of this structure.
		/// </summary>
		public string? lpszFileExtension;

		/// <summary>
		/// Pointer to a null-terminated string that contains the local file name. The string occupies the memory area at the end of
		/// this structure.
		/// </summary>
		public string? lpszLocalFileName;

		/// <summary>
		/// Pointer to a null-terminated string that contains the URL name. The string occupies the memory area at the end of this structure.
		/// </summary>
		public string? lpszSourceUrlName;

		/// <summary>Initializes a new instance of the <see cref="INTERNET_CACHE_ENTRY_INFO_MGD"/> struct from an unmanaged structure.</summary>
		/// <param name="i">The <see cref="INTERNET_CACHE_ENTRY_INFO"/> instance.</param>
		public INTERNET_CACHE_ENTRY_INFO_MGD(in INTERNET_CACHE_ENTRY_INFO i)
		{
			lpszSourceUrlName = i.lpszSourceUrlName;
			lpszLocalFileName = i.lpszLocalFileName;
			lpHeaderInfo = i.lpHeaderInfo;
			lpszFileExtension = i.lpszFileExtension;
			CacheEntryType = i.CacheEntryType;
			dwUseCount = i.dwUseCount;
			dwHitRate = i.dwHitRate;
			dwSize = Macros.MAKELONG64(i.dwSizeLow, i.dwSizeHigh);
			LastModifiedTime = i.LastModifiedTime.ToDateTime();
			ExpireTime = i.ExpireTime.ToDateTime();
			LastAccessTime = i.LastAccessTime.ToDateTime();
			LastSyncTime = i.LastSyncTime.ToDateTime();
			dwExemptDelta = TimeSpan.FromSeconds(i.dwExemptDelta);
		}
	}

	/// <summary>Contains the LastModified and Expire times for a resource stored in the Internet cache.</summary>
	[PInvokeData("WinInet.h")]
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
	[PInvokeData("WinInet.h")]
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
		public LPSTR lpszSubjectInfo;

		/// <summary>
		/// Pointer to a buffer that contains the name of the organization, site, and server that issued the certificate. The
		/// application must call LocalFree to release the resources allocated for this parameter.
		/// </summary>
		public LPSTR lpszIssuerInfo;

		/// <summary>
		/// Pointer to a buffer that contains the name of the protocol used to provide the secure connection. The application must call
		/// LocalFree to release the resources allocated for this parameter.
		/// </summary>
		public LPSTR lpszProtocolName;

		/// <summary>
		/// Pointer to a buffer that contains the name of the algorithm used for signing the certificate. The application must call
		/// LocalFree to release the resources allocated for this parameter.
		/// </summary>
		public LPSTR lpszSignatureAlgName;

		/// <summary>
		/// Pointer to a buffer that contains the name of the algorithm used for doing encryption over the secure channel (SSL/PCT)
		/// connection. The application must call LocalFree to release the resources allocated for this parameter.
		/// </summary>
		public LPSTR lpszEncryptionAlgName;

		/// <summary>Size, in TCHARs, of the key.</summary>
		public uint dwKeySize;
	}

	/// <summary>
	/// The INTERNET_DIAGNOSTIC_SOCKET_INFO structure is returned by the InternetQueryOption function when the
	/// INTERNET_OPTION_DIAGNOSTIC_SOCKET_INFO flag is passed to it together with a handle to an HTTP Request. The
	/// INTERNET_DIAGNOSTIC_SOCKET_INFO structure contains information about the socket associated with that HTTP Request.
	/// </summary>
	[PInvokeData("WinInet.h")]
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
	/// <remarks>
	/// <para>
	/// In Internet Explorer 5, only the ANSI versions of InternetQueryOption and InternetSetOption will work with the
	/// <c>INTERNET_PER_CONN_OPTION</c> structure. The Unicode versions will support the <c>INTERNET_PER_CONN_OPTION</c> structure in
	/// later versions of Internet Explorer.
	/// </para>
	/// <para>
	/// For queries that return strings, InternetQueryOption allocates the memory for the <c>pszValue</c> member of the structure. The
	/// calling application must free this memory using the GlobalFree function when it has finished using the string.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-internet_per_conn_optiona typedef struct { DWORD dwOption;
	// union { DWORD dwValue; LPSTR pszValue; FILETIME ftValue; } Value; } INTERNET_PER_CONN_OPTIONA, *LPINTERNET_PER_CONN_OPTIONA;
	[PInvokeData("wininet.h", MSDNShortId = "NS:wininet.__unnamed_struct_3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_PER_CONN_OPTION
	{
		/// <summary>
		/// <para>Option to be queried or set. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INTERNET_PER_CONN_AUTOCONFIG_URL</term>
		/// <term>Sets or retrieves a string containing the URL to the automatic configuration script.</term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_AUTODISCOVERY_FLAGS</term>
		/// <term>
		/// Sets or retrieves the automatic discovery settings. The Value member will contain one or more of the following values:
		/// AUTO_PROXY_FLAG_ALWAYS_DETECT Always automatically detect settings. AUTO_PROXY_FLAG_CACHE_INIT_RUN Indicates that the cached
		/// results of the automatic proxy configuration script should be used, instead of actually running the script, unless the
		/// cached file has expired. AUTO_PROXY_FLAG_DETECTION_RUN Automatic detection has been run at least once on this connection.
		/// AUTO_PROXY_FLAG_DETECTION_SUSPECT Not currently supported. AUTO_PROXY_FLAG_DONT_CACHE_PROXY_RESULT Do not allow the caching
		/// of the result of the automatic proxy configuration script. AUTO_PROXY_FLAG_MIGRATED The setting was migrated from a
		/// Microsoft Internet Explorer 4.0 installation, and automatic detection should be attempted once. AUTO_PROXY_FLAG_USER_SET The
		/// user has explicitly set the automatic detection.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_FLAGS</term>
		/// <term>
		/// Sets or retrieves the connection type. The Value member will contain one or more of the following values: PROXY_TYPE_DIRECT
		/// The connection does not use a proxy server. PROXY_TYPE_PROXY The connection uses an explicitly set proxy server.
		/// PROXY_TYPE_AUTO_PROXY_URL The connection downloads and processes an automatic configuration script at a specified URL.
		/// PROXY_TYPE_AUTO_DETECT The connection automatically detects settings.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_PROXY_BYPASS</term>
		/// <term>Sets or retrieves a string containing the URLs that do not use the proxy server.</term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_PROXY_SERVER</term>
		/// <term>Sets or retrieves a string containing the proxy servers.</term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_AUTOCONFIG_SECONDARY_URL</term>
		/// <term>
		/// Chained autoconfig URL. Used when the primary autoconfig URL points to an INS file that sets a second autoconfig URL for
		/// proxy information.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_AUTOCONFIG_RELOAD_DELAY_MINS</term>
		/// <term>of minutes until automatic refresh of autoconfig URL by autodiscovery.</term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_TIME</term>
		/// <term>Read only option. Returns the time the last known good autoconfig URL was found using autodiscovery.</term>
		/// </item>
		/// <item>
		/// <term>INTERNET_PER_CONN_AUTOCONFIG_LAST_DETECT_URL</term>
		/// <term>Read only option. Returns the last known good URL found using autodiscovery.</term>
		/// </item>
		/// </list>
		/// <para>Windows 7 and later:</para>
		/// <para>
		/// Clients that support Internet Explorer 8 should query the connection type using <c>INTERNET_PER_CONN_FLAGS_UI</c>. If this
		/// query fails, then the system is running a previous version of Internet Explorer and the client should query again with <c>INTERNET_PER_CONN_FLAGS</c>.
		/// </para>
		/// <para>Restore the connection type using</para>
		/// <para>INTERNET_PER_CONN_FLAGS</para>
		/// <para>regardless of the version of Internet Explorer.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INTERNET_PER_CONN_FLAGS_UI</term>
		/// <term>
		/// Sets or retrieves the connection type. The Value member will contain one or more of the following values: PROXY_TYPE_DIRECT
		/// The connection does not use a proxy server. PROXY_TYPE_PROXY The connection uses an explicitly set proxy server.
		/// PROXY_TYPE_AUTO_PROXY_URL The connection downloads and processes an automatic configuration script at a specified URL.
		/// PROXY_TYPE_AUTO_DETECT The connection automatically detects settings.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public INTERNET_PER_CONN_OPTION_ID dwOption;

		/// <summary>
		/// <para>Union that contains the value for the option. It can be any one of the following types depending on the value of <c>dwOption</c>:</para>
		/// <para>dwValue</para>
		/// <para>Unsigned long integer value.</para>
		/// <para>pszValue</para>
		/// <para>Pointer to a string value.</para>
		/// <para>ftValue</para>
		/// <para>A FILETIME structure.</para>
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
			public LPTSTR pszValue;

			/// <summary>A FILETIME structure.</summary>
			[FieldOffset(0)]
			public FILETIME ftValue;
		}
	}

	/// <summary>Contains the list of options for a particular Internet connection.</summary>
	[PInvokeData("WinInet.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_PER_CONN_OPTION_LIST
	{
		/// <summary>Size of the structure, in bytes.</summary>
		public uint dwSize;

		/// <summary>
		/// Pointer to a string that contains the name of the RAS connection or NULL, which indicates the default or LAN connection, to
		/// set or query options on.
		/// </summary>
		public LPTSTR pszConnection;

		/// <summary>Number of options to query or set.</summary>
		public uint dwOptionCount;

		/// <summary>Options that failed, if an error occurs.</summary>
		public uint dwOptionError;

		/// <summary>Pointer to an array of INTERNET_PER_CONN_OPTION structures containing the options to query or set.</summary>
		public IntPtr pOptions;

		/// <summary>The default instance of INTERNET_PER_CONN_OPTION_LIST with dwSize set.</summary>
		public static readonly INTERNET_PER_CONN_OPTION_LIST Default = new() { dwSize = (uint)Marshal.SizeOf(typeof(INTERNET_PER_CONN_OPTION_LIST)) };
	}

	/// <summary>
	/// Contains information that is supplied with the INTERNET_OPTION_PROXY value to get or set proxy information on a handle obtained
	/// from a call to the InternetOpen function.
	/// </summary>
	[PInvokeData("WinInet.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INTERNET_PROXY_INFO
	{
		/// <summary>Access type.</summary>
		public InternetOpenType dwAccessType;

		/// <summary>Pointer to a string that contains the proxy server list.</summary>
		public LPTSTR lpszProxy;

		/// <summary>Pointer to a string that contains the proxy bypass list.</summary>
		public LPTSTR lpszProxyBypass;
	}

	/// <summary>
	/// Contains the HTTP version number of the server. This structure is used when passing the INTERNET_OPTION_VERSION flag to the
	/// InternetQueryOption function.
	/// </summary>
	[PInvokeData("WinInet.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INTERNET_VERSION_INFO
	{
		/// <summary>Major version number.</summary>
		public uint dwMajorVersion;

		/// <summary>Minor version number.</summary>
		public uint dwMinorVersion;
	}

	/// <summary>
	/// Contains the constituent parts of a URL. This structure is used with the InternetCrackUrl and InternetCreateUrl functions.
	/// </summary>
	/// <remarks>
	/// <para>
	/// For InternetCrackUrl, if a pointer member and its corresponding length member are both zero, that component is not returned. If
	/// the pointer member is <c>NULL</c> but the length member is not zero, both the pointer and length members are returned. If both
	/// pointer and corresponding length members are nonzero, the pointer member points to a buffer where the component is copied. The
	/// component can be un-escaped, depending on the dwFlags parameter of InternetCrackUrl.
	/// </para>
	/// <para>
	/// For InternetCreateUrl, the pointer members should be <c>NULL</c> if the component is not required. If the corresponding length
	/// member is zero, the pointer member is the address of a zero-terminated string. If the length member is not zero, it is the
	/// string length of the corresponding pointer member.
	/// </para>
	/// <para>
	/// <c>Note</c> WinINet does not support server implementations. In addition, it should not be used from a service. For server
	/// implementations or services use Microsoft Windows HTTP Services (WinHTTP).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wininet/ns-wininet-url_componentsa typedef struct { DWORD dwStructSize; LPSTR
	// lpszScheme; DWORD dwSchemeLength; INTERNET_SCHEME nScheme; LPSTR lpszHostName; DWORD dwHostNameLength; INTERNET_PORT nPort; LPSTR
	// lpszUserName; DWORD dwUserNameLength; LPSTR lpszPassword; DWORD dwPasswordLength; LPSTR lpszUrlPath; DWORD dwUrlPathLength; LPSTR
	// lpszExtraInfo; DWORD dwExtraInfoLength; } URL_COMPONENTSA, *LPURL_COMPONENTSA;
	[PInvokeData("wininet.h", MSDNShortId = "faebdd29-f746-486b-b779-cceeecac9163")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct URL_COMPONENTS
	{
		/// <summary>Size of this structure, in bytes.</summary>
		public uint dwStructSize;

		/// <summary>Pointer to a string that contains the scheme name.</summary>
		public IntPtr lpszScheme;

		/// <summary>Size of the scheme name, in <c>TCHARs</c>.</summary>
		public uint dwSchemeLength;

		/// <summary>INTERNET_SCHEME value that indicates the Internet protocol scheme.</summary>
		public INTERNET_SCHEME nScheme;

		/// <summary>Pointer to a string that contains the host name.</summary>
		public IntPtr lpszHostName;

		/// <summary>Size of the host name, in <c>TCHARs</c>.</summary>
		public uint dwHostNameLength;

		/// <summary>Converted port number.</summary>
		public INTERNET_PORT nPort;

		/// <summary>Pointer to a string value that contains the user name.</summary>
		public IntPtr lpszUserName;

		/// <summary>Size of the user name, in <c>TCHARs</c>.</summary>
		public uint dwUserNameLength;

		/// <summary>Pointer to a string that contains the password.</summary>
		public IntPtr lpszPassword;

		/// <summary>Size of the password, in <c>TCHARs</c>.</summary>
		public uint dwPasswordLength;

		/// <summary>Pointer to a string that contains the URL path.</summary>
		public IntPtr lpszUrlPath;

		/// <summary>Size of the URL path, in <c>TCHARs</c>.</summary>
		public uint dwUrlPathLength;

		/// <summary>Pointer to a string that contains the extra information (for example, ?something or #something).</summary>
		public IntPtr lpszExtraInfo;

		/// <summary>Size of the extra information, in <c>TCHARs</c>.</summary>
		public uint dwExtraInfoLength;

		/// <summary>The default instance of URL_COMPONENTS with dwStructSize set.</summary>
		public static readonly URL_COMPONENTS Default = new() { dwStructSize = (uint)Marshal.SizeOf(typeof(URL_COMPONENTS)) };
	}

	/// <summary>A managed equivalent to <see cref="URL_COMPONENTS"/>.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class URL_COMPONENTS_MGD : IDisposable
	{
		private readonly SafeCoTaskMemString scheme, host, user, pwd, url, extra;
		private URL_COMPONENTS uc;

		/// <summary>Initializes a new instance of the <see cref="URL_COMPONENTS_MGD"/> class.</summary>
		public URL_COMPONENTS_MGD()
		{
			uc.dwStructSize = (uint)Marshal.SizeOf(typeof(URL_COMPONENTS));
			uc.lpszScheme = scheme = new SafeCoTaskMemString((int)(uc.dwSchemeLength = INTERNET_MAX_SCHEME_LENGTH + 1), CharSet.Auto);
			uc.lpszHostName = host = new SafeCoTaskMemString((int)(uc.dwHostNameLength = INTERNET_MAX_HOST_NAME_LENGTH + 1), CharSet.Auto);
			uc.lpszUserName = user = new SafeCoTaskMemString((int)(uc.dwUserNameLength = INTERNET_MAX_USER_NAME_LENGTH + 1), CharSet.Auto);
			uc.lpszPassword = pwd = new SafeCoTaskMemString((int)(uc.dwPasswordLength = INTERNET_MAX_PASSWORD_LENGTH + 1), CharSet.Auto);
			uc.lpszUrlPath = url = new SafeCoTaskMemString((int)(uc.dwUrlPathLength = INTERNET_MAX_PATH_LENGTH + 1), CharSet.Auto);
			uc.lpszExtraInfo = extra = new SafeCoTaskMemString((int)(uc.dwExtraInfoLength = INTERNET_MAX_PATH_LENGTH + 1), CharSet.Auto);
		}

		/// <summary>Initializes a new instance of the <see cref="URL_COMPONENTS_MGD"/> class with values.</summary>
		/// <param name="scheme">The scheme.</param>
		/// <param name="host">The host.</param>
		/// <param name="path">The URL path.</param>
		/// <param name="extra">The extra information.</param>
		/// <param name="port">The port.</param>
		/// <param name="userName">Name of the user.</param>
		/// <param name="password">The password.</param>
		public URL_COMPONENTS_MGD(string scheme, string host, string? path = null, string? extra = null, INTERNET_PORT port = INTERNET_PORT.INTERNET_INVALID_PORT_NUMBER,
			string? userName = null, string? password = null) : this()
		{
			lpszScheme = scheme ?? "";
			lpszHostName = host ?? "";
			lpszUrlPath = path ?? "";
			lpszExtraInfo = extra ?? "";
			nPort = port;
			lpszUserName = userName ?? "";
			lpszPassword = password ?? "";
		}

		/// <summary>Pointer to a string that contains the extra information (for example, ?something or #something).</summary>
		public string? lpszExtraInfo { get => extra; set { extra.Set(value); uc.dwExtraInfoLength = (uint)(value?.Length ?? 0); } }

		/// <summary>Pointer to a string that contains the host name.</summary>
		public string? lpszHostName { get => host; set { host.Set(value); uc.dwHostNameLength = (uint)(value?.Length ?? 0); } }

		/// <summary>Pointer to a string that contains the password.</summary>
		public string? lpszPassword { get => pwd; set { pwd.Set(value); uc.dwPasswordLength = (uint)(value?.Length ?? 0); } }

		/// <summary>Pointer to a string that contains the scheme name.</summary>
		public string? lpszScheme { get => scheme; set { scheme.Set(value); uc.dwSchemeLength = (uint)(value?.Length ?? 0); } }

		/// <summary>Pointer to a string that contains the URL path.</summary>
		public string? lpszUrlPath { get => url; set { url.Set(value); uc.dwUrlPathLength = (uint)(value?.Length ?? 0); } }

		/// <summary>Pointer to a string value that contains the user name.</summary>
		public string? lpszUserName { get => user; set { user.Set(value); uc.dwUserNameLength = (uint)(value?.Length ?? 0); } }

		/// <summary>Converted port number.</summary>
		public INTERNET_PORT nPort { get => uc.nPort; set => uc.nPort = value; }

		/// <summary>INTERNET_SCHEME value that indicates the Internet protocol scheme.</summary>
		public INTERNET_SCHEME nScheme { get => uc.nScheme; set => uc.nScheme = value; }

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			scheme.Dispose();
			host.Dispose();
			user.Dispose();
			pwd.Dispose();
			url.Dispose();
			extra.Dispose();
		}

		/// <summary>Gets a reference to the unmanaged structure.</summary>
		/// <returns>A reference to <see cref="URL_COMPONENTS"/>.</returns>
		public ref URL_COMPONENTS GetRef() => ref uc;
	}
}