using System.Threading;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class HttpApi
{
	/// <summary>The <c>HTTP_IS_NULL_ID</c> macro determines if the HTTP_OPAQUE_ID is <c>NULL</c>.</summary>
	/// <param name="pid">The parameter determined to be <c>NULL</c>.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-http_is_null_id void HTTP_IS_NULL_ID( pid );
	[PInvokeData("http.h", MSDNShortId = "NF:http.HTTP_IS_NULL_ID")]
	public static bool HTTP_IS_NULL_ID(HTTP_OPAQUE_ID pid) => pid == HTTP_NULL_ID;

	/// <summary>
	/// The <c>HttpAddFragmentToCache</c> function caches a data fragment with a specified name by which it can be retrieved, or updates data
	/// cached under a specified name. Such cached data fragments can be used repeatedly to construct dynamic responses without the expense
	/// of disk reads. For example, a response composed of text and three images could be assembled dynamically from four or more cached
	/// fragments at the time a request is processed.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// Handle to the request queue with which this cache is associated. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="UrlPrefix">
	/// <para>
	/// Pointer to a UrlPrefix string that the application uses in subsequent calls to HttpSendHttpResponse to identify this cache entry. The
	/// application must have called <c>HttpAddUrl</c> previously with the same handle as in the <c>ReqQueueHandle</c> parameter, and with
	/// either this identical UrlPrefix string or a valid prefix of it.
	/// </para>
	/// <para>Like any UrlPrefix, this string must take the form "scheme://host:port/relativeURI"; for example, http://www.mysite.com:80/image1.gif.</para>
	/// </param>
	/// <param name="DataChunk">
	/// Pointer to an HTTP_DATA_CHUNK structure that specifies an entity body data block to cache under the name pointed to by <c>pUrlPrefix</c>.
	/// </param>
	/// <param name="CachePolicy">Pointer to an HTTP_CACHE_POLICY structure that specifies how this data fragment should be cached.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks the calling thread until the cache operation is complete, whereas an asynchronous call immediately returns
	/// ERROR_IO_PENDING and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is
	/// completed. For more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the cache request is queued and will
	/// complete later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpaddfragmenttocache HTTPAPI_LINKAGE ULONG HttpAddFragmentToCache(
	// [in] HANDLE RequestQueueHandle, [in] PCWSTR UrlPrefix, [in] PHTTP_DATA_CHUNK DataChunk, [in] PHTTP_CACHE_POLICY CachePolicy, [in,
	// optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpAddFragmentToCache")]
	public static extern uint HttpAddFragmentToCache(HREQQUEUEv1 RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string UrlPrefix,
		in HTTP_DATA_CHUNK DataChunk, in HTTP_CACHE_POLICY CachePolicy, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpAddFragmentToCache</c> function caches a data fragment with a specified name by which it can be retrieved, or updates data
	/// cached under a specified name. Such cached data fragments can be used repeatedly to construct dynamic responses without the expense
	/// of disk reads. For example, a response composed of text and three images could be assembled dynamically from four or more cached
	/// fragments at the time a request is processed.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// Handle to the request queue with which this cache is associated. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="UrlPrefix">
	/// <para>
	/// Pointer to a UrlPrefix string that the application uses in subsequent calls to HttpSendHttpResponse to identify this cache entry. The
	/// application must have called <c>HttpAddUrl</c> previously with the same handle as in the <c>ReqQueueHandle</c> parameter, and with
	/// either this identical UrlPrefix string or a valid prefix of it.
	/// </para>
	/// <para>Like any UrlPrefix, this string must take the form "scheme://host:port/relativeURI"; for example, http://www.mysite.com:80/image1.gif.</para>
	/// </param>
	/// <param name="DataChunk">
	/// Pointer to an HTTP_DATA_CHUNK structure that specifies an entity body data block to cache under the name pointed to by <c>pUrlPrefix</c>.
	/// </param>
	/// <param name="CachePolicy">Pointer to an HTTP_CACHE_POLICY structure that specifies how this data fragment should be cached.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks the calling thread until the cache operation is complete, whereas an asynchronous call immediately returns
	/// ERROR_IO_PENDING and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is
	/// completed. For more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the cache request is queued and will
	/// complete later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpaddfragmenttocache HTTPAPI_LINKAGE ULONG HttpAddFragmentToCache(
	// [in] HANDLE RequestQueueHandle, [in] PCWSTR UrlPrefix, [in] PHTTP_DATA_CHUNK DataChunk, [in] PHTTP_CACHE_POLICY CachePolicy, [in,
	// optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpAddFragmentToCache")]
	public static extern Win32Error HttpAddFragmentToCache(HREQQUEUE RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string UrlPrefix,
		in HTTP_DATA_CHUNK DataChunk, in HTTP_CACHE_POLICY CachePolicy, in NativeOverlapped Overlapped);

	/// <summary>
	/// <para>
	/// The <c>HttpAddUrl</c> function registers a given URL so that requests that match it are routed to a specified HTTP Server API request
	/// queue. An application can register multiple URLs to a single request queue using repeated calls to <c>HttpAddUrl</c>. For more
	/// information about how HTTP Server API matches request URLs to registered URLs, see UrlPrefix Strings.
	/// </para>
	/// <para>
	/// Starting with HTTP Server API Version 2.0, applications should call HttpAddUrlToUrlGroup to register a URL; <c>HttpAddUrl</c> should
	/// not be used.
	/// </para>
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// The handle to the request queue to which requests for the specified URL are to be routed. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="FullyQualifiedUrl">
	/// A pointer to a Unicode string that contains a properly formed UrlPrefix string that identifies the URL to be registered.
	/// </param>
	/// <param name="Reserved">Reserved; must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling application does not have permission to register the URL.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DLL_INIT_FAILED</c></term>
	/// <term>The calling application did not call HttpInitialize before calling this function.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>The specified UrlPrefix conflicts with an existing registration.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Insufficient resources to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// As stated in the UrlPrefix Strings topic, the scheme specification of the UrlPrefix to be registered must be either lower-case "http"
	/// or lower-case "https". No other substring is valid.
	/// </para>
	/// <para>
	/// Also, it is not possible to register URLs having different schemes on the same port. That is, "http" and "https" schemes cannot
	/// coexist on a port.
	/// </para>
	/// <para>
	/// Also be aware that <c>HttpAddUrl</c> registers any UrlPrefix passed to it as long as the string is well-formed. Any validation of
	/// existence, accessibility, ownership, or other characteristic of the specified URL namespace must be handled by the application.
	/// </para>
	/// <para>
	/// To release the resources allocated as a result of the registration performed by <c>HttpAddUrl</c>, make a matching call to the
	/// HttpRemoveUrl function when your application has finished with the namespace involved.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpaddurl HTTPAPI_LINKAGE ULONG HttpAddUrl( [in] HANDLE
	// RequestQueueHandle, [in] PCWSTR FullyQualifiedUrl, PVOID Reserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpAddUrl")]
	public static extern Win32Error HttpAddUrl(HREQQUEUEv1 RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string FullyQualifiedUrl, IntPtr Reserved = default);

	/// <summary>
	/// <para>The <c>HttpAddUrlToUrlGroup</c> function adds the specified URL to the URL Group identified by the URL Group ID.</para>
	/// <para>This function replaces the HTTP version 1.0 HttpAddUrl function.</para>
	/// </summary>
	/// <param name="UrlGroupId">
	/// The group ID for the URL group to which requests for the specified URL are routed. The URL group is created by the HttpCreateUrlGroup function.
	/// </param>
	/// <param name="pFullyQualifiedUrl">
	/// A pointer to a Unicode string that contains a properly formed UrlPrefix String that identifies the URL to be registered.
	/// </param>
	/// <param name="UrlContext">
	/// The context that is associated with the URL registered in this call. The URL context is returned in the HTTP_REQUEST structure with
	/// every request received on the URL specified in the <c>pFullyQualifiedUrl</c> parameter.
	/// </param>
	/// <param name="Reserved">Reserved. Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The <c>UrlGroupId</c> does not exist. The <c>Reserved</c> parameter is not zero. The application does not have permission to add URLs
	/// to the Group. Only the application that created the URL Group can add URLs.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling process does not have permission to register the URL.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>The specified URL conflicts with an existing registration.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The HTTP Server API supports existing applications using version 1.0 URL registrations, however, new development with the HTTP Server
	/// API should use <c>HttpAddUrlToUrlGroup</c>; HttpAddUrl should not be used.
	/// </para>
	/// <para>
	/// An application can add multiple URLs to a URL group using repeated calls to <c>HttpAddUrlToUrlGroup</c>. Requests that match the
	/// specified URL are routed to the request queue associated with the URL group. For more information about how the HTTP Server API
	/// matches request URLs to registered URLs, see UrlPrefix Strings.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpaddurltourlgroup HTTPAPI_LINKAGE ULONG HttpAddUrlToUrlGroup( [in]
	// HTTP_URL_GROUP_ID UrlGroupId, [in] PCWSTR pFullyQualifiedUrl, [in, optional] HTTP_URL_CONTEXT UrlContext, [in] ULONG Reserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpAddUrlToUrlGroup")]
	public static extern Win32Error HttpAddUrlToUrlGroup([In] HTTP_URL_GROUP_ID UrlGroupId, [MarshalAs(UnmanagedType.LPWStr)] string pFullyQualifiedUrl,
		[In, Optional] HTTP_URL_CONTEXT UrlContext, uint Reserved = 0);

	/// <summary>The <c>HttpCancelHttpRequest</c> function cancels a specified request.</summary>
	/// <param name="RequestQueueHandle">A handle to the request queue from which the request came.</param>
	/// <param name="RequestId">The ID of the request to be canceled.</param>
	/// <param name="Overlapped">
	/// For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.
	/// </param>
	/// <returns>If the function succeeds, it returns <c>NO_ERROR</c>.</returns>
	/// <remarks>
	/// When the <c>HttpCancelHttpRequest</c> function is used to cancel a request, the underlying transport connection used for the request
	/// will be closed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcancelhttprequest HTTPAPI_LINKAGE ULONG HttpCancelHttpRequest(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCancelHttpRequest")]
	public static extern Win32Error HttpCancelHttpRequest([In] HREQQUEUE RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, in NativeOverlapped Overlapped);

	/// <summary>The <c>HttpCancelHttpRequest</c> function cancels a specified request.</summary>
	/// <param name="RequestQueueHandle">A handle to the request queue from which the request came.</param>
	/// <param name="RequestId">The ID of the request to be canceled.</param>
	/// <param name="Overlapped">
	/// For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.
	/// </param>
	/// <returns>If the function succeeds, it returns <c>NO_ERROR</c>.</returns>
	/// <remarks>
	/// When the <c>HttpCancelHttpRequest</c> function is used to cancel a request, the underlying transport connection used for the request
	/// will be closed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcancelhttprequest HTTPAPI_LINKAGE ULONG HttpCancelHttpRequest(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCancelHttpRequest")]
	public static extern Win32Error HttpCancelHttpRequest([In] HREQQUEUE RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// <para>The <c>HttpCloseRequestQueue</c> function closes the handle to the specified request queue created by HttpCreateRequestQueue.</para>
	/// <para>The application must close the request queue when it is no longer required.</para>
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// The handle to the request queue that is closed. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The application does not have permission to close the request queue. Only the application that created the request queue can close it.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Applications should not call CloseHandle on the request queue handle; instead, they should call <c>HttpCloseRequestQueue</c> to
	/// ensure that all the resources are released.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcloserequestqueue HTTPAPI_LINKAGE ULONG HttpCloseRequestQueue(
	// [in] HANDLE RequestQueueHandle );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCloseRequestQueue")]
	public static extern Win32Error HttpCloseRequestQueue(HREQQUEUE RequestQueueHandle);

	/// <summary>
	/// The <c>HttpCloseServerSession</c> function deletes the server session identified by the server session ID. All remaining URL Groups
	/// associated with the server session will also be closed.
	/// </summary>
	/// <param name="ServerSessionId">The ID of the server session that is closed.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The Server Session does not exist. The application does not have permission to close the server session. Only the application that
	/// created the server session can close the session.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Applications must call HttpCloseUrlGroup before calling <c>HttpCloseServerSession</c> to close the all the URL Groups associated with
	/// the server session.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcloseserversession HTTPAPI_LINKAGE ULONG HttpCloseServerSession(
	// [in] HTTP_SERVER_SESSION_ID ServerSessionId );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCloseServerSession")]
	public static extern Win32Error HttpCloseServerSession(HTTP_SERVER_SESSION_ID ServerSessionId);

	/// <summary>
	/// The <c>HttpCloseUrlGroup</c> function closes the URL Group identified by the URL Group ID. This call also removes all of the URLs
	/// that are associated with the URL Group.
	/// </summary>
	/// <param name="UrlGroupId">The ID of the URL Group that is deleted.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The ID of the URL Group does not exist. The application does not have permission to close the URL Group. Only the application that
	/// created the URL Group can close the group.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Applications must call <c>HttpCloseUrlGroup</c> before calling HttpCloseServerSession to close the all URL Groups associated with the
	/// server session.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcloseurlgroup HTTPAPI_LINKAGE ULONG HttpCloseUrlGroup( [in]
	// HTTP_URL_GROUP_ID UrlGroupId );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCloseUrlGroup")]
	public static extern Win32Error HttpCloseUrlGroup(HTTP_URL_GROUP_ID UrlGroupId);

	/// <summary>
	/// <para>
	/// The <c>HttpCreateHttpHandle</c> function creates an HTTP request queue for the calling application and returns a handle to it.
	/// </para>
	/// <para>
	/// Starting with HTTP Server API Version 2.0, applications should call HttpCreateRequestQueue to create the request queue;
	/// <c>HttpCreateHttpHandle</c> should not be used.
	/// </para>
	/// </summary>
	/// <param name="RequestQueueHandle">A pointer to a variable that receives a handle to the request queue.</param>
	/// <param name="Reserved">Reserved. This parameter must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_DLL_INIT_FAILED</c></term>
	/// <term>The calling application did not call HttpInitialize before calling this function.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The request queue enables the calling application to receive requests for particular URLs. The calling application uses the
	/// HttpAddUrl function to specify the URL for which it should receive requests.
	/// </para>
	/// <para>
	/// An application should use a single request queue to receive requests. Using multiple request queues from a single process does not
	/// increase response time or throughput.
	/// </para>
	/// <para>When an application has finished receiving requests, it should call the CloseHandle function to close the handle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcreatehttphandle HTTPAPI_LINKAGE ULONG HttpCreateHttpHandle( [out]
	// PHANDLE RequestQueueHandle, [in] ULONG Reserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCreateHttpHandle")]
	public static extern Win32Error HttpCreateHttpHandle(out SafeHREQQUEUEv1 RequestQueueHandle, uint Reserved = 0);

	/// <summary>
	/// <para>The <c>HttpCreateRequestQueue</c> function creates a new request queue or opens an existing request queue.</para>
	/// <para>This function replaces the HTTP version 1.0 HttpCreateHttpHandle function.</para>
	/// </summary>
	/// <param name="Version">
	/// <para>
	/// An HTTPAPI_VERSION structure indicating the request queue version. For version 2.0, declare an instance of the structure and set it
	/// to the predefined value HTTPAPI_VERSION_2 before passing it to <c>HttpCreateRequestQueue</c>.
	/// </para>
	/// <para>The version must be 2.0; <c>HttpCreateRequestQueue</c> does not support version 1.0 request queues.</para>
	/// </param>
	/// <param name="Name">
	/// <para>The name of the request queue. The length, in bytes, cannot exceed MAX_PATH.</para>
	/// <para>The optional name parameter allows other processes to access the request queue by name.</para>
	/// </param>
	/// <param name="SecurityAttributes">
	/// <para>A pointer to the SECURITY_ATTRIBUTES structure that contains the access permissions for the request queue.</para>
	/// <para>This parameter must be <c>NULL</c> when opening an existing request queue.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>The flags parameter defines the scope of the request queue. This parameter can be one or more of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_CREATE_REQUEST_QUEUE_FLAG_CONTROLLER</c></term>
	/// <term>
	/// The handle to the request queue created using this flag cannot be used to perform I/O operations. This flag can be set only when the
	/// request queue handle is created.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING</c></term>
	/// <term>
	/// The <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING</c> flag allows applications to open an existing request queue by name and
	/// retrieve the request queue handle. The <c>pName</c> parameter must contain a valid request queue name; it cannot be <c>NULL</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="RequestQueueHandle">
	/// A pointer to a variable that receives a handle to the request queue. This parameter must contain a valid pointer; it cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_REVISION_MISMATCH</c></term>
	/// <term>The <c>Version</c> parameter contains an invalid version.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The length, in bytes, of the request queue name cannot exceed MAX_PATH. The <c>pSecurityAttributes</c> parameter must be <c>NULL</c>
	/// when opening an existing request queue. The <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_CONTROLLER</c> can only be set when the request queue
	/// is created. The <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING</c> can only be set when the application has permission to open an
	/// existing request queue. In this case, the <c>pReqQueueHandle</c> parameter must be a valid pointer, and the <c>pName</c> parameter
	/// must contain a valid request queue name; it cannot be <c>NULL</c>. The <c>pReqQueueHandle</c> parameter returned by
	/// HttpCreateRequestQueue is <c>NULL</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>The <c>pName</c> parameter conflicts with an existing request queue that contains an identical name.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling process does not have a permission to open the request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DLL_INIT_FAILED</c></term>
	/// <term>The application has not called HttpInitialize prior to calling HttpCreateRequestQueue.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The HTTP Server API supports existing applications using the version 1.0 request queues, however, new development with the HTTP
	/// Server API should use <c>HttpCreateRequestQueue</c> to create request queues; HttpCreateHttpHandle should not be used. The version
	/// 2.0 API are only compatible with the version 2.0 request queues created by <c>HttpCreateRequestQueue</c>.
	/// </para>
	/// <para>
	/// The HTTP version 2 request queues require manual configuration; the application must create the URL Groups and associate one or more
	/// URL Group with the request queue by calling HttpSetUrlGroupProperty with the <c>HttpServerBindingProperty</c>. The application
	/// configures the request queue by calling HttpSetRequestQueueProperty with the desired configuration in the <c>Property</c> parameter.
	/// For more information about creating and configuring URL groups, see HttpCreateUrlGroup and <c>HttpSetUrlGroupProperty</c>.
	/// </para>
	/// <para>
	/// Security attributes may be supplied in <c>pSecurityAttributes</c> parameter only when the request queue is created. Only the
	/// application that creates the request queue can set Access Control Lists (ACLs) on the request queue handle to allow processes (other
	/// than the creator application) permission to open, receive requests, and send responses on the request queue handle. By default,
	/// applications are not allowed to open a request queue unless they have been granted permission in the ACL.
	/// </para>
	/// <para>
	/// The creator process can optionally use the <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_CONTROLLER</c> flag to indicate that it does not want to
	/// receive http requests.
	/// </para>
	/// <para>
	/// <c>HttpCreateRequestQueue</c> allows applications to open an existing request queue with the
	/// <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_OPEN_EXISTING</c> flag and retrieve the handle to the request queue. Non-controller applications
	/// can use this handle to perform HTTP I/O operations. Only the application that creates the request queue can set properties on it by
	/// calling the HttpSetRequestQueueProperty.
	/// </para>
	/// <para>
	/// The handle to the request queue created by <c>HttpCreateRequestQueue</c> must be closed by calling HttpCloseRequestQueue before the
	/// application terminates or when the session is no longer required.
	/// </para>
	/// <para>Applications must call HttpInitialize prior to calling <c>HttpCreateRequestQueue</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcreaterequestqueue HTTPAPI_LINKAGE ULONG HttpCreateRequestQueue(
	// [in] HTTPAPI_VERSION Version, [in, optional] PCWSTR Name, [in, optional] PSECURITY_ATTRIBUTES SecurityAttributes, [in, optional] ULONG
	// Flags, [out] PHANDLE RequestQueueHandle );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCreateRequestQueue")]
	public static extern Win32Error HttpCreateRequestQueue(HTTPAPI_VERSION Version, [Optional, MarshalAs(UnmanagedType.LPWStr)] string Name,
		[In, Optional] SECURITY_ATTRIBUTES SecurityAttributes, [In, Optional] HTTP_CREATE_REQUEST_QUEUE_FLAG Flags,
		out SafeHREQQUEUE RequestQueueHandle);

	/// <summary>The <c>HttpCreateServerSession</c> function creates a server session for the specified version.</summary>
	/// <param name="Version">
	/// <para>
	/// An HTTPAPI_VERSION structure that indicates the version of the server session. For version 2.0, declare an instance of the structure
	/// and set it to the predefined value <c>HTTPAPI_VERSION_2</c> before passing it to <c>HttpCreateServerSession</c>.
	/// </para>
	/// <para>The version must be 2.0; <c>HttpCreateServerSession</c> does not support version 1.0 request queues.</para>
	/// </param>
	/// <param name="ServerSessionId">A pointer to the variable that receives the ID of the server session.</param>
	/// <param name="Reserved">Reserved. Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_REVISION_MISMATCH</c></term>
	/// <term>The version passed is invalid or unsupported.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>pServerSessionId</c> parameter is null or the <c>Reserved</c> is non zero.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Server sessions own a set of URL Groups. They are top-level configuration containers for configuration information that applies to
	/// all of the URL Groups created under them. For more information about configuring a server session, see HttpSetServerSessionProperty.
	/// </para>
	/// <para>The HTTP Server API does not support asynchronous I/O for server sessions.</para>
	/// <para>
	/// When the server session is no longer required, or before the application terminates, application must delete the server session by
	/// calling HttpCloseServerSession. When a server session is deleted all of the associated URL Groups are also automatically deleted.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcreateserversession HTTPAPI_LINKAGE ULONG HttpCreateServerSession(
	// [in] HTTPAPI_VERSION Version, [out] PHTTP_SERVER_SESSION_ID ServerSessionId, [in] ULONG Reserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCreateServerSession")]
	public static extern Win32Error HttpCreateServerSession(HTTPAPI_VERSION Version, out SafeHTTP_SERVER_SESSION_ID ServerSessionId, uint Reserved = 0);

	/// <summary>The <c>HttpCreateUrlGroup</c> function creates a URL Group under the specified server session.</summary>
	/// <param name="ServerSessionId">The identifier of the server session under which the URL Group is created.</param>
	/// <param name="pUrlGroupId">A pointer to the variable that receives the ID of the URL Group.</param>
	/// <param name="Reserved">Reserved. Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The <c>ServerSessionId</c> parameter indicates a non-existing Server Session. The <c>pUrlGroupId</c> parameter is null. The
	/// <c>Reserved</c> parameter is non-zero.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// URL Groups are configuration containers for a set of URLs. They are created under the server session and inherit the configuration
	/// settings of the server session. When a configuration parameter is set on the URL Group, it overrides the configuration set on the
	/// server session. For more information about the setting configurations for the URL Group, see HttpSetUrlGroupProperty.
	/// </para>
	/// <para>
	/// After the URL group is created it must be associated with a request queue to receive requests. To associate the URL Group with a
	/// request queue, the application calls HttpSetUrlGroupProperty with the <c>HttpServerBindingProperty</c> property. If this property is
	/// not set, matching requests for the URL Group are not delivered to a request queue and the HTTP Server API generates a 503 response.
	/// </para>
	/// <para>
	/// The URL Group association with a request queue is dynamic. The association with the servers session cannot be changed until either
	/// the server session or the URL Group is deleted. When a server session is deleted all of the associated URL Groups are also
	/// automatically closed.
	/// </para>
	/// <para>The URL Group is initially created as an empty group. URLs must be added to the group by calling HttpAddUrlToUrlGroup.</para>
	/// <para>Application may create multiple URL Groups for the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>To set distinct configurations for different portions of URL name space on which it is listening.</term>
	/// </item>
	/// <item>
	/// <term>To set separate request queues for different portions of URL name space on which it is listening.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Applications should combine URLs into groups as much as possible; otherwise performance will degrade and increased memory consumption
	/// of the system will affect the scalability.
	/// </para>
	/// <para>The HTTP Server API does not support asynchronous I/O on URL Groups.</para>
	/// <para>When the URL group is no longer needed or before the application terminates it must delete the URL Group by calling HttpCloseUrlGroup.</para>
	/// <para>The URL Group is created with the same version as the server session under which it is created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpcreateurlgroup HTTPAPI_LINKAGE ULONG HttpCreateUrlGroup( [in]
	// HTTP_SERVER_SESSION_ID ServerSessionId, [out] PHTTP_URL_GROUP_ID pUrlGroupId, [in] ULONG Reserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpCreateUrlGroup")]
	public static extern Win32Error HttpCreateUrlGroup(HTTP_SERVER_SESSION_ID ServerSessionId, out SafeHTTP_URL_GROUP_ID pUrlGroupId, uint Reserved = 0);

	/// <summary>
	/// Declares a resource-to-subresource relationship to use for an HTTP server push. HTTP.sys then performs an HTTP 2.0 server push for
	/// the given resource, if the underlying protocol, connection, client, and policies allow the push operation.
	/// </summary>
	/// <param name="RequestQueueHandle">The handle to an HTTP.sys request queue that the HttpCreateRequestQueue function returned.</param>
	/// <param name="RequestId">
	/// The opaque identifier of the request that is declaring the push operation. The request must be from the specified queue handle.
	/// </param>
	/// <param name="Verb">
	/// The HTTP verb to use for the push operation. The HTTP.sys push operation only supports <c>HttpVerbGET</c> and <c>HttpVerbHEAD</c>.
	/// </param>
	/// <param name="Path">The path portion of the URL for the resource being pushed.</param>
	/// <param name="Query">
	/// The query portion of the URL for the resource being pushed. This string should not include the leading question mark (?).
	/// </param>
	/// <param name="Headers">
	/// <para>The request headers for the push operation.</para>
	/// <para>
	/// You should not provide a Host header, because HTTP.sys automatically generates the correct Host information. HTTP.sys does not
	/// support cross-origin push operations, so HTTP.sys enforces and generates Host information that matches the original client-initiated request.
	/// </para>
	/// <para>
	/// The push request is not allowed to have an entity body, so you cannot include a non-zero Content-Length header or any
	/// Transfer-Encoding header.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// You should call <c>HttpDeclarePush</c> before you send any response bytes that would cause the client to discover the subresource
	/// itself. Failure to observe this order results in a race between the server that is pushing the resource and the client that is
	/// retrieving the resources, which can waste bandwidth. The server application should only use <c>HttpDeclarePush</c> to push resources
	/// that the server application is highly confident are needed and not already cached by the client. If the server application pushes
	/// other resources, unnecessary use of bandwidth and CPU may occur.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpdeclarepush HTTPAPI_LINKAGE ULONG HttpDeclarePush( [in] HANDLE
	// RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] HTTP_VERB Verb, [in] PCWSTR Path, [in, optional] PCSTR Query, [in, optional]
	// PHTTP_REQUEST_HEADERS Headers );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpDeclarePush")]
	public static extern Win32Error HttpDeclarePush([In] HREQQUEUE RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_VERB Verb,
		[MarshalAs(UnmanagedType.LPWStr)] string Path, [Optional, MarshalAs(UnmanagedType.LPStr)] string Query, [In, Optional] IntPtr Headers);

	/// <summary>
	/// Declares a resource-to-subresource relationship to use for an HTTP server push. HTTP.sys then performs an HTTP 2.0 server push for
	/// the given resource, if the underlying protocol, connection, client, and policies allow the push operation.
	/// </summary>
	/// <param name="RequestQueueHandle">The handle to an HTTP.sys request queue that the HttpCreateRequestQueue function returned.</param>
	/// <param name="RequestId">
	/// The opaque identifier of the request that is declaring the push operation. The request must be from the specified queue handle.
	/// </param>
	/// <param name="Verb">
	/// The HTTP verb to use for the push operation. The HTTP.sys push operation only supports <c>HttpVerbGET</c> and <c>HttpVerbHEAD</c>.
	/// </param>
	/// <param name="Path">The path portion of the URL for the resource being pushed.</param>
	/// <param name="Query">
	/// The query portion of the URL for the resource being pushed. This string should not include the leading question mark (?).
	/// </param>
	/// <param name="Headers">
	/// <para>The request headers for the push operation.</para>
	/// <para>
	/// You should not provide a Host header, because HTTP.sys automatically generates the correct Host information. HTTP.sys does not
	/// support cross-origin push operations, so HTTP.sys enforces and generates Host information that matches the original client-initiated request.
	/// </para>
	/// <para>
	/// The push request is not allowed to have an entity body, so you cannot include a non-zero Content-Length header or any
	/// Transfer-Encoding header.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns a system error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// You should call <c>HttpDeclarePush</c> before you send any response bytes that would cause the client to discover the subresource
	/// itself. Failure to observe this order results in a race between the server that is pushing the resource and the client that is
	/// retrieving the resources, which can waste bandwidth. The server application should only use <c>HttpDeclarePush</c> to push resources
	/// that the server application is highly confident are needed and not already cached by the client. If the server application pushes
	/// other resources, unnecessary use of bandwidth and CPU may occur.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpdeclarepush HTTPAPI_LINKAGE ULONG HttpDeclarePush( [in] HANDLE
	// RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] HTTP_VERB Verb, [in] PCWSTR Path, [in, optional] PCSTR Query, [in, optional]
	// PHTTP_REQUEST_HEADERS Headers );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpDeclarePush")]
	public static extern Win32Error HttpDeclarePush([In] HREQQUEUE RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_VERB Verb,
		[MarshalAs(UnmanagedType.LPWStr)] string Path, [Optional, MarshalAs(UnmanagedType.LPStr)] string Query, in HTTP_REQUEST_HEADERS Headers);

	/// <summary>Delegates a request from the source request queue to the target request queue.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>Type: _In_ <c>HANDLE</c></para>
	/// <para>A handle to the source request queue.</para>
	/// </param>
	/// <param name="DelegateQueueHandle">
	/// <para>Type: _In_ <c>HANDLE</c></para>
	/// <para>A handle to the target request queue.</para>
	/// </param>
	/// <param name="RequestId">
	/// <para>Type: _In_ <c>HTTP_REQUEST_ID</c></para>
	/// <para>A unique request ID received with HttpReceiveHttpRequest.</para>
	/// </param>
	/// <param name="DelegateUrlGroupId">
	/// <para>Type: _In_ <c>HTTP_URL_GROUP_ID</c></para>
	/// <para>The url group id of the target url group.</para>
	/// </param>
	/// <param name="PropertyInfoSetSize">
	/// <para>Type: _In_ <c>ULONG</c></para>
	/// <para>The number of entries in the PropertyInfoSet array.</para>
	/// </param>
	/// <param name="PropertyInfoSet">
	/// <para>Type: _In_ **PHTTP_DELEGATE_REQUEST_PROPERTY_INFO**</para>
	/// <para>An array of properties to be set on request when delegating.</para>
	/// </param>
	/// <returns>A <c>ULONG</c> containing an NTSTATUS completion status.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpdelegaterequestex HTTPAPI_LINKAGE ULONG HttpDelegateRequestEx(
	// HANDLE RequestQueueHandle, HANDLE DelegateQueueHandle, HTTP_REQUEST_ID RequestId, HTTP_URL_GROUP_ID DelegateUrlGroupId, ULONG
	// PropertyInfoSetSize, PHTTP_DELEGATE_REQUEST_PROPERTY_INFO PropertyInfoSet );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpDelegateRequestEx")]
	public static extern Win32Error HttpDelegateRequestEx(HREQQUEUE RequestQueueHandle, HREQQUEUE DelegateQueueHandle, HTTP_REQUEST_ID RequestId,
		HTTP_URL_GROUP_ID DelegateUrlGroupId, uint PropertyInfoSetSize, in HTTP_DELEGATE_REQUEST_PROPERTY_INFO PropertyInfoSet);

	/// <summary>
	/// The <c>HttpDeleteServiceConfiguration</c> function deletes specified data, such as IP addresses or SSL Certificates, from the HTTP
	/// Server API configuration store, one record at a time.
	/// </summary>
	/// <param name="ServiceHandle">This parameter is reserved and must be zero.</param>
	/// <param name="ConfigId">
	/// <para>Type of configuration. This parameter is one of the values in the HTTP_SERVICE_CONFIG_ID enumeration.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>Deletes a specified IP address from the IP Listen List.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>Deletes a specified SSL certificate record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>Deletes a specified URL reservation record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeout</c></term>
	/// <term>Deletes a specified connection timeout. <c>Windows Vista and later:</c> This enumeration is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>
	/// Deletes a specified SSL Server Name Indication (SNI) certificate record. <c>Windows 8 and later:</c> This enumeration value is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslCcsCertInfo</c></term>
	/// <term>
	/// Deletes the SSL certificate record that specifies that Http.sys should consult the Centralized Certificate Store (CCS) store to find
	/// certificates if the port receives a Transport Layer Security (TLS) handshake. The port is specified by the <c>KeyDesc</c> member of
	/// the HTTP_SERVICE_CONFIG_SSL_CCS_SET structure that you pass to the <c>pConfigInformation</c> parameter. <c>Windows 8 and later:</c>
	/// This enumeration value is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pConfigInformation">
	/// <para>Pointer to a buffer that contains data required for the type of configuration specified in the <c>ConfigId</c> parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_URLACL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeouts</c></term>
	/// <term>HTTP_SERVICE_CONFIG_TIMEOUT_KEY structure. <c>Windows Vista and later:</c> This structure is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>
	/// HTTP_SERVICE_CONFIG_SSL_SNI_SET structure. The hostname will be "*" when the SSL central certificate store is queried and wildcard
	/// bindings are used, and a host name for regular SNI. <c>Windows 8 and later:</c> This structure is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c><c>HttpServiceConfigSslCcsCertInfo</c></c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_CCS_SET structure. <c>Windows 8 and later:</c> This structure is supported.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ConfigInformationLength">Size, in bytes, of the <c>pConfigInformation</c> buffer.</param>
	/// <param name="pOverlapped">Reserved for future asynchronous operation. This parameter must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns NO_ERROR.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpdeleteserviceconfiguration HTTPAPI_LINKAGE ULONG
	// HttpDeleteServiceConfiguration( [in] HANDLE ServiceHandle, [in] HTTP_SERVICE_CONFIG_ID ConfigId, [in] PVOID pConfigInformation, [in]
	// ULONG ConfigInformationLength, [in] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpDeleteServiceConfiguration")]
	public static extern Win32Error HttpDeleteServiceConfiguration([In, Optional] IntPtr ServiceHandle, [In] HTTP_SERVICE_CONFIG_ID ConfigId,
		[In] IntPtr pConfigInformation, [In] uint ConfigInformationLength, [In, Optional] IntPtr pOverlapped);

	/// <summary>Retrieves a URL group ID for a URL and a request queue.</summary>
	/// <param name="FullyQualifiedUrl">
	/// <para>Type: _In_ <c>PCWSTR</c></para>
	/// <para>The URL whose URL group to query.</para>
	/// </param>
	/// <param name="RequestQueueHandle">
	/// <para>Type: _In_ <c>HANDLE</c></para>
	/// <para>The request queue associated with the URL group.</para>
	/// </param>
	/// <param name="UrlGroupId">
	/// <para>Type: _Out_ <c>PHTTP_URL_GROUP_ID</c></para>
	/// <para>The matching URL group ID.</para>
	/// </param>
	/// <returns>A <c>ULONG</c> containing an NTSTATUS completion status.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpfindurlgroupid HTTPAPI_LINKAGE ULONG HttpFindUrlGroupId( PCWSTR
	// FullyQualifiedUrl, HANDLE RequestQueueHandle, PHTTP_URL_GROUP_ID UrlGroupId );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpFindUrlGroupId")]
	public static extern Win32Error HttpFindUrlGroupId([MarshalAs(UnmanagedType.LPWStr)] string FullyQualifiedUrl, HREQQUEUE RequestQueueHandle,
		in HTTP_URL_GROUP_ID UrlGroupId);

	/// <summary>
	/// The <c>HttpFlushResponseCache</c> function removes from the HTTP Server API cache associated with a given request queue all response
	/// fragments that have a name whose site portion matches a specified UrlPrefix. The application must previously have called HttpAddUrl,
	/// or HttpAddUrlToUrlGroup to add this UrlPrefix or a valid prefix of it to the request queue in question, and then called
	/// HttpAddFragmentToCache to cache the associated response fragment or fragments.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// Handle to the request queue with which this cache is associated. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="UrlPrefix">
	/// Pointer to a UrlPrefix string to match against the site portion of fragment names. The application must previously have called
	/// HttpAddUrl to add this UrlPrefix or a valid prefix of it to the request queue in question, and then called HttpAddFragmentToCache to
	/// cache the associated response fragment.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can contain the following flag:</para>
	/// <para>HTTP_FLUSH_RESPONSE_FLAG_RECURSIVE</para>
	/// <para>
	/// Causes response fragments that have names in which the site portion is a hierarchical descendant of the specified UrlPrefix to be
	/// removed from the fragment cache, in addition to those fragments having site portions that directly match.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the cache operation is complete, whereas an asynchronous call immediately returns ERROR_IO_PENDING
	/// and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the cache request is queued and completes
	/// later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpflushresponsecache HTTPAPI_LINKAGE ULONG HttpFlushResponseCache(
	// [in] HANDLE RequestQueueHandle, [in] PCWSTR UrlPrefix, [in] ULONG Flags, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpFlushResponseCache")]
	public static extern Win32Error HttpFlushResponseCache([In] HREQQUEUE RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string UrlPrefix,
		[In] HTTP_FLUSH_RESPONSE_FLAG Flags, in NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>HttpFlushResponseCache</c> function removes from the HTTP Server API cache associated with a given request queue all response
	/// fragments that have a name whose site portion matches a specified UrlPrefix. The application must previously have called HttpAddUrl,
	/// or HttpAddUrlToUrlGroup to add this UrlPrefix or a valid prefix of it to the request queue in question, and then called
	/// HttpAddFragmentToCache to cache the associated response fragment or fragments.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// Handle to the request queue with which this cache is associated. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="UrlPrefix">
	/// Pointer to a UrlPrefix string to match against the site portion of fragment names. The application must previously have called
	/// HttpAddUrl to add this UrlPrefix or a valid prefix of it to the request queue in question, and then called HttpAddFragmentToCache to
	/// cache the associated response fragment.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can contain the following flag:</para>
	/// <para>HTTP_FLUSH_RESPONSE_FLAG_RECURSIVE</para>
	/// <para>
	/// Causes response fragments that have names in which the site portion is a hierarchical descendant of the specified UrlPrefix to be
	/// removed from the fragment cache, in addition to those fragments having site portions that directly match.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the cache operation is complete, whereas an asynchronous call immediately returns ERROR_IO_PENDING
	/// and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the cache request is queued and completes
	/// later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpflushresponsecache HTTPAPI_LINKAGE ULONG HttpFlushResponseCache(
	// [in] HANDLE RequestQueueHandle, [in] PCWSTR UrlPrefix, [in] ULONG Flags, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpFlushResponseCache")]
	public static extern Win32Error HttpFlushResponseCache([In] HREQQUEUEv1 RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string UrlPrefix,
		[In] HTTP_FLUSH_RESPONSE_FLAG Flags, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpInitialize</c> function initializes the HTTP Server API driver, starts it, if it has not already been started, and
	/// allocates data structures for the calling application to support response-queue creation and other operations. Call this function
	/// before calling any other functions in the HTTP Server API.
	/// </summary>
	/// <param name="Version">
	/// HTTP version. This parameter is an HTTPAPI_VERSION structure. For the current version, declare an instance of the structure and set
	/// it to the pre-defined value <c>HTTPAPI_VERSION_1</c> before passing it to <c>HttpInitialize</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>Initialization options, which can include one or both of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_INITIALIZE_CONFIG</c></term>
	/// <term>
	/// Perform initialization for applications that use the HTTP configuration functions, HttpSetServiceConfiguration,
	/// HttpQueryServiceConfiguration, HttpDeleteServiceConfiguration, and HttpIsFeatureSupported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_INITIALIZE_SERVER</c></term>
	/// <term>Perform initialization for applications that use the HTTP Server API.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReserved">This parameter is reserved, and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, then the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, then the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>Flags</c> parameter contains an unsupported value.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Call HttpTerminate when the application completes. All the same flags that were passed to <c>HttpInitialize</c> in the <c>Flags</c>
	/// parameter must also be passed to <c>HttpTerminate</c>. An application can call <c>HttpInitialize</c> repeatedly, provided that each
	/// call to <c>HttpInitialize</c> is later matched by a corresponding call to <c>HttpTerminate</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpinitialize HTTPAPI_LINKAGE ULONG HttpInitialize( [in]
	// HTTPAPI_VERSION Version, [in] ULONG Flags, [in, out] PVOID pReserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpInitialize")]
	public static extern Win32Error HttpInitialize(HTTPAPI_VERSION Version, HTTP_INIT Flags, IntPtr pReserved = default);

	/// <summary>Checks whether a particular feature is supported.</summary>
	/// <param name="FeatureId">
	/// <para>Type: _In_ <c>HTTP_FEATURE_ID</c></para>
	/// <para>The identifier of the feature.</para>
	/// </param>
	/// <returns>
	/// <code>TRUE</code>
	/// if the feature is supported, otherwise
	/// <code>FALSE</code>
	/// .
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpisfeaturesupported BOOL HttpIsFeatureSupported( HTTP_FEATURE_ID
	// FeatureId );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpIsFeatureSupported")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HttpIsFeatureSupported(HTTP_FEATURE_ID FeatureId);

	/// <summary>
	/// The <c>HttpPrepareUrl</c> function parses, analyzes, and normalizes a non-normalized Unicode or punycode URL so it is safe and valid
	/// to use in other HTTP functions.
	/// </summary>
	/// <param name="Url">A pointer to a string that represents the non-normalized Unicode or punycode URL to prepare.</param>
	/// <param name="PreparedUrl">
	/// <para>On successful output, a pointer to a string that represents the normalized URL.</para>
	/// <para><c>Note</c> Free <c>PreparedUrl</c> using HeapFree.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpprepareurl HTTPAPI_LINKAGE ULONG HttpPrepareUrl( PVOID Reserved,
	// ULONG Flags, [in] PCWSTR Url, [out] PWSTR *PreparedUrl );
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpPrepareUrl")]
	public static Win32Error HttpPrepareUrl(string Url, out string PreparedUrl)
	{
		var err = HttpPrepareUrl(default, default, Url, out var pUrl);
		PreparedUrl = err.Succeeded ? pUrl.ToString(-1, CharSet.Unicode) : null;
		return err;
	}

	/// <summary>
	/// The <c>HttpQueryRequestQueueProperty</c> function queries a property of the request queue identified by the specified handle.
	/// </summary>
	/// <param name="RequestQueueHandle"/>
	/// <param name="Property">
	/// <para>A member of the HTTP_SERVER_PROPERTY enumeration that describes the property type that is set. This can be one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServer503VerbosityProperty</c></term>
	/// <term>Queries the current verbosity level of 503 responses generated for the requests queue.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerQueueLengthProperty</c></term>
	/// <term>Queries the limit on the number of outstanding requests in the request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerStateProperty</c></term>
	/// <term>Queries the current state of the request queue. The state must be either active or inactive.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>A pointer to the buffer that receives the property information.</para>
	/// <para>pPropertyInformation</para>
	/// <para>points to one of the following property information values based on the property that is set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_ENABLED_STATE (enumeration member)</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQueueLengthProperty</term>
	/// <term>ULONG</term>
	/// </item>
	/// <item>
	/// <term>HttpServer503VerbosityProperty</term>
	/// <term>HTTP_503_RESPONSE_VERBOSITY (enumeration member)</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformationLength">The length, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter.</param>
	/// <param name="Reserved1">Reserved. Must be zero.</param>
	/// <param name="ReturnLength">
	/// <para>The number, in bytes, returned in the <c>pPropertyInformation</c> buffer if not <c>NULL</c>.</para>
	/// <para>
	/// If the output buffer is too small, the call fails with a return value of <c>ERROR_MORE_DATA</c>. The value pointed to by
	/// <c>pReturnLength</c> can be used to determine the minimum length of the buffer required for the call to succeed.
	/// </para>
	/// </param>
	/// <param name="Reserved2">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The <c>Reserved</c> parameter is not zero or the <c>pReserved</c> parameter is not <c>NULL</c>. The property type specified in the
	/// <c>Property</c> parameter is not supported on request queues. The <c>pPropertyInformation</c> parameter is <c>NULL</c>. The
	/// <c>PropertyInformationLength</c> parameter is zero. The application does not have permission to open the request queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The size, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter is too small to receive the property
	/// information. Call the function again with a buffer at least as large as the size pointed to by <c>pReturnLength</c> on exit.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The handle to the request queue is an HTTP version 1.0 handle. Property management is only supported for HTTP version 2.0 and later
	/// request queues.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpqueryrequestqueueproperty HTTPAPI_LINKAGE ULONG
	// HttpQueryRequestQueueProperty( HANDLE RequestQueueHandle, [in] HTTP_SERVER_PROPERTY Property, [out] PVOID PropertyInformation, [in]
	// ULONG PropertyInformationLength, [in] ULONG Reserved1, [out, optional] PULONG ReturnLength, [in] PVOID Reserved2 );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpQueryRequestQueueProperty")]
	public static extern Win32Error HttpQueryRequestQueueProperty(HREQQUEUE RequestQueueHandle, [In] HTTP_SERVER_PROPERTY Property,
		[Out] IntPtr PropertyInformation, [In] uint PropertyInformationLength, [In, Optional] uint Reserved1, out uint ReturnLength,
		[In, Optional] IntPtr Reserved2);

	/// <summary>The <c>HttpQueryServerSessionProperty</c> function queries a server property on the specified server session.</summary>
	/// <param name="ServerSessionId">The server session for which the property setting is returned.</param>
	/// <param name="Property">
	/// <para>A member of the HTTP_SERVER_PROPERTY enumeration that describes the property type that is queried. This can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServerStateProperty</c></term>
	/// <term>Queries the current state of the server session.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerTimeoutsProperty</c></term>
	/// <term>Queries the server session connection timeout limits.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerQosProperty</c></term>
	/// <term>Queries the bandwidth throttling for the server session. By default, the HTTP Server API does not limit bandwidth.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerAuthenticationProperty</c></term>
	/// <term>Queries kernel mode server-side authentication for the Basic, NTLM, Negotiate, and Digest authentication schemes.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerChannelBindProperty</c></term>
	/// <term>Queries the channel binding token (CBT) properties.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>A pointer to the buffer that receives the property data.</para>
	/// <para>pPropertyInformation</para>
	/// <para>points to one of the following property data structures based on the property that is set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_STATE_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQosProperty</term>
	/// <term>HTTP_QOS_SETTING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerTimeoutsProperty</term>
	/// <term>HTTP_TIMEOUT_LIMIT_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerChannelBindProperty</term>
	/// <term>HTTP_CHANNEL_BIND_INFO</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformationLength">The length, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter.</param>
	/// <param name="ReturnLength">
	/// <para>The number, in bytes, returned in the <c>pPropertyInformation</c> buffer.</para>
	/// <para>
	/// If the output buffer is too small, the call fails with a return value of <c>ERROR_MORE_DATA</c>. The value pointed to by
	/// <c>pReturnLength</c> can be used to determine the minimum length of the buffer required for the call to succeed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The property type specified in the <c>Property</c> parameter is not supported for server sessions. The <c>ServerSessionId</c>
	/// parameter does not contain a valid server session. The <c>pPropertyInformation</c> parameter is <c>NULL</c>. The
	/// <c>PropertyInformationLength</c> parameter is zero. The application does not have permission to query the server session properties.
	/// Only the application that created the server session can query the properties.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The size, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter is too small to receive the property data.
	/// On exit call the function again with a buffer at least as large as the size pointed to by <c>pReturnLength</c> on exit.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Querying the <c>HttpServerLoggingProperty</c> is not supported.</para>
	/// <para>
	/// The <c>pPropertyInformation</c> parameter points to the configuration structure for the property type that is queried. The
	/// <c>PropertyInformationLength</c> parameter specifies the size, in bytes, of the configuration structure. For example, when querying
	/// the <c>HttpServerTimeoutsProperty</c> the <c>pPropertyInformation</c> parameter must point to a buffer that is at least the size of
	/// the HTTP_TIMEOUT_LIMIT_INFO structure.
	/// </para>
	/// <para>
	/// To specify the HttpServerQosProperty property in the <c>pPropertyInformation</c> parameter, set <c>QosType</c> to
	/// <c>HttpQosSettingTypeBandwidth</c> inside the HTTP_QOS_SETTING_INFO structure, and pass a pointer to this structure in the parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpqueryserversessionproperty HTTPAPI_LINKAGE ULONG
	// HttpQueryServerSessionProperty( [in] HTTP_SERVER_SESSION_ID ServerSessionId, [in] HTTP_SERVER_PROPERTY Property, [out] PVOID
	// PropertyInformation, [in] ULONG PropertyInformationLength, [out, optional] PULONG ReturnLength );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpQueryServerSessionProperty")]
	public static extern Win32Error HttpQueryServerSessionProperty([In] HTTP_SERVER_SESSION_ID ServerSessionId, [In] HTTP_SERVER_PROPERTY Property,
		[Out] IntPtr PropertyInformation, [In] uint PropertyInformationLength, out uint ReturnLength);

	/// <summary>The <c>HttpQueryServiceConfiguration</c> function retrieves one or more HTTP Server API configuration records.</summary>
	/// <param name="ServiceHandle">Reserved. Must be zero.</param>
	/// <param name="ConfigId">
	/// <para>The configuration record query type. This parameter is one of the following values from the HTTP_SERVICE_CONFIG_ID enumeration.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>Queries the IP Listen List.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>Queries the SSL store for a specific certificate record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>Queries URL reservation information.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeout</c></term>
	/// <term>Queries HTTP Server API wide connection timeouts. <c>Windows Vista and later:</c> This enumeration is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>
	/// Queries the SSL Server Name Indication (SNI) store for a specific certificate record. <c>Windows 8 and later:</c> This enumeration
	/// value is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslCcsCertInfo</c></term>
	/// <term>
	/// Queries the SSL configuration for an SSL Centralized Certificate Store (CCS) record on the port. The port is specified by the
	/// <c>KeyDesc</c> member of the HTTP_SERVICE_CONFIG_SSL_CCS_QUERY structure that you pass to the <c>pInputConfigInfo</c> parameter.
	/// <c>Windows 8 and later:</c> This enumeration value is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInput">
	/// <para>
	/// A pointer to a structure whose contents further define the query and of the type that correlates with <c>ConfigId</c> in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>No input data; set to <c>NULL</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_QUERY structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_URLACL_QUERY structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeout</c></term>
	/// <term>HTTP_SERVICE_CONFIG_TIMEOUT_KEY structure. <c>Windows Vista and later:</c> This structure is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_SNI_QUERY structure. <c>Windows 8 and later:</c> This structure is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslCcsCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_CCS_QUERY structure. <c>Windows 8 and later:</c> This structure is supported.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see the appropriate query structures.</para>
	/// </param>
	/// <param name="InputLength">Size, in bytes, of the <c>pInputConfigInfo</c> buffer.</param>
	/// <param name="pOutput">
	/// <para>A pointer to a buffer in which the query results are returned. The type of this buffer correlates with <c>ConfigId</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>HTTP_SERVICE_CONFIG_IP_LISTEN_QUERY structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_URLACL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeout</c></term>
	/// <term>HTTP_SERVICE_CONFIG_TIMEOUT_PARAM data type. <c>Windows Vista and later:</c> This structure is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_SNI_SET structure. <c>Windows 8 and later:</c> This structure is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslCcsCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_CCS_SET structure. <c>Windows 8 and later:</c> This structure is supported.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="OutputLength">Size, in bytes, of the <c>pOutputConfigInfo</c> buffer.</param>
	/// <param name="pReturnLength">
	/// A pointer to a variable that receives the number of bytes to be written in the output buffer. If the output buffer is too small, the
	/// call fails with a return value of <c>ERROR_INSUFFICIENT_BUFFER</c>. The value pointed to by <c>pReturnLength</c> can be used to
	/// determine the minimum length the buffer requires for the call to succeed.
	/// </param>
	/// <param name="pOverlapped">Reserved for asynchronous operation and must be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>
	/// The buffer pointed to by <c>pOutputConfigInfo</c> is too small to receive the output data. Call the function again with a buffer at
	/// least as large as the size pointed to by <c>pReturnLength</c> on exit.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// This error code is only returned when <c>ConfigId</c> is set to <c>HttpServiceConfigTimeout</c>. The buffer pointed to by
	/// <c>pOutputConfigInfo</c> is too small to receive the output data. Call the function again with a buffer at least as large as the size
	/// pointed to by <c>pReturnLength</c> on exit.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_MORE_ITEMS</c></term>
	/// <term>There are no more items to return that meet the specified criteria.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpqueryserviceconfiguration HTTPAPI_LINKAGE ULONG
	// HttpQueryServiceConfiguration( [in] HANDLE ServiceHandle, [in] HTTP_SERVICE_CONFIG_ID ConfigId, [in, optional] PVOID pInput, [in,
	// optional] ULONG InputLength, [in, out, optional] PVOID pOutput, [in, optional] ULONG OutputLength, [out, optional] PULONG
	// pReturnLength, [in] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpQueryServiceConfiguration")]
	public static extern Win32Error HttpQueryServiceConfiguration([In, Optional] IntPtr ServiceHandle, [In] HTTP_SERVICE_CONFIG_ID ConfigId,
		[In, Optional] IntPtr pInput, [In, Optional] uint InputLength, [In, Out, Optional] IntPtr pOutput, [In, Optional] uint OutputLength,
		out uint pReturnLength, [In, Optional] IntPtr pOverlapped);

	/// <summary>The <c>HttpQueryUrlGroupProperty</c> function queries a property on the specified URL Group.</summary>
	/// <param name="UrlGroupId">The ID of the URL Group for which the property setting is returned.</param>
	/// <param name="Property">
	/// <para>A member of the HTTP_SERVER_PROPERTY enumeration that describes the property type that is queried. This can be one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServerAuthenticationProperty</c></term>
	/// <term>Queries the enabled server-side authentication schemes.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerTimeoutsProperty</c></term>
	/// <term>Queries the URL Group connection timeout limits.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerStateProperty</c></term>
	/// <term>Queries the current state of the URL Group. The state can be either enabled or disabled.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerQosProperty</c></term>
	/// <term>
	/// This value maps to the generic HTTP_QOS_SETTING_INFO structure with <c>QosType</c> set to either <c>HttpQosSettingTypeBandwidth</c>
	/// or <c>HttpQosSettingTypeConnectionLimit</c>. If <c>HttpQosSettingTypeBandwidth</c>, queries the bandwidth throttling for the URL
	/// Group. If <c>HttpQosSettingTypeConnectionLimit</c>, queries the maximum number of outstanding connections served for a URL group at
	/// any time.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerChannelBindProperty</c></term>
	/// <term>Queries the channel binding token (CBT) properties.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>A pointer to the buffer that receives the property information.</para>
	/// <para>pPropertyInformation</para>
	/// <para>points to one of the following property information structures based on the property that is queried.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_STATE_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQosProperty</term>
	/// <term>HTTP_QOS_SETTING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerTimeoutsProperty</term>
	/// <term>HTTP_TIMEOUT_LIMIT_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerChannelBindProperty</term>
	/// <term>HTTP_CHANNEL_BIND_INFO</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformationLength">The length, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter.</param>
	/// <param name="ReturnLength">
	/// <para>The size, in bytes, returned in the <c>pPropertyInformation</c> buffer.</para>
	/// <para>
	/// If the output buffer is too small, the call fails with a return value of <c>ERROR_MORE_DATA</c>. The value pointed to by
	/// <c>pReturnLength</c> can be used to determine the minimum length of the buffer required for the call to succeed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The property type specified in the <c>Property</c> parameter is not supported for URL Groups. The <c>UrlGroupId</c> parameter does
	/// not identify a valid server URL Group. The <c>pPropertyInformation</c> parameter is <c>NULL</c>. The <c>PropertyInformationLength</c>
	/// parameter is zero. The application does not have permission to query the URL Group properties. Only the application that created the
	/// URL Group can query the properties.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The size, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter is too small to receive the property
	/// information. Call the function again with a buffer at least as large as the size pointed to by <c>pReturnLength</c> on exit.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Querying the <c>HttpServerLoggingProperty</c> is not supported.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpqueryurlgroupproperty HTTPAPI_LINKAGE ULONG
	// HttpQueryUrlGroupProperty( [in] HTTP_URL_GROUP_ID UrlGroupId, [in] HTTP_SERVER_PROPERTY Property, [out] PVOID PropertyInformation,
	// [in] ULONG PropertyInformationLength, [out, optional] PULONG ReturnLength );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpQueryUrlGroupProperty")]
	public static extern Win32Error HttpQueryUrlGroupProperty([In] HTTP_URL_GROUP_ID UrlGroupId, [In] HTTP_SERVER_PROPERTY Property,
		[Out] IntPtr PropertyInformation, [In] uint PropertyInformationLength, out uint ReturnLength);

	/// <summary>
	/// The <c>HttpReadFragmentFromCache</c> function retrieves a response fragment having a specified name from the HTTP Server API cache.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// Handle to the request queue with which the specified response fragment is associated. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="UrlPrefix">
	/// Pointer to a UrlPrefix string that contains the name of the fragment to be retrieved. This must match a UrlPrefix string used in a
	/// previous successful call to HttpAddFragmentToCache.
	/// </param>
	/// <param name="ByteRange">
	/// Optional pointer to an HTTP_BYTE_RANGE structure that indicates a starting offset in the specified fragment and byte-count to be
	/// returned. <c>NULL</c> if not used, in which case the entire fragment is returned.
	/// </param>
	/// <param name="Buffer">Pointer to a buffer into which the function copies the requested fragment.</param>
	/// <param name="BufferLength">Size, in bytes, of the <c>pBuffer</c> buffer.</param>
	/// <param name="BytesRead">
	/// <para>
	/// Optional pointer to a variable that receives the number of bytes to be written into the output buffer. If <c>BufferLength</c> is less
	/// than this number, the call fails with a return of ERROR_INSUFFICIENT_BUFFER, and the value pointed to by <c>pBytesRead</c> can be
	/// used to determine the minimum length of buffer required for the call to succeed.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesRead</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesRead</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the cache operation is complete, whereas an asynchronous call immediately returns ERROR_IO_PENDING
	/// and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the cache request is queued and completes
	/// later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The buffer pointed to by <c>pBuffer</c> is too small to receive all the requested data; the size of buffer required is pointed to by
	/// <c>pBytesRead</c> unless it was <c>NULL</c> or the call was asynchronous. In the case of an asynchronous call, the value pointed to
	/// by the <c>lpNumberOfBytesTransferred</c> parameter of the GetOverLappedResult function is set to the buffer size required.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreadfragmentfromcache HTTPAPI_LINKAGE ULONG
	// HttpReadFragmentFromCache( [in] HANDLE RequestQueueHandle, [in] PCWSTR UrlPrefix, [in] PHTTP_BYTE_RANGE ByteRange, [out] PVOID Buffer,
	// [in] ULONG BufferLength, [out] PULONG BytesRead, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReadFragmentFromCache")]
	public static extern Win32Error HttpReadFragmentFromCache([In] HREQQUEUEv1 RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string UrlPrefix,
		in HTTP_BYTE_RANGE ByteRange, [Out] IntPtr Buffer, [In] uint BufferLength, out uint BytesRead, in NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>HttpReadFragmentFromCache</c> function retrieves a response fragment having a specified name from the HTTP Server API cache.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// Handle to the request queue with which the specified response fragment is associated. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="UrlPrefix">
	/// Pointer to a UrlPrefix string that contains the name of the fragment to be retrieved. This must match a UrlPrefix string used in a
	/// previous successful call to HttpAddFragmentToCache.
	/// </param>
	/// <param name="ByteRange">
	/// Optional pointer to an HTTP_BYTE_RANGE structure that indicates a starting offset in the specified fragment and byte-count to be
	/// returned. <c>NULL</c> if not used, in which case the entire fragment is returned.
	/// </param>
	/// <param name="Buffer">Pointer to a buffer into which the function copies the requested fragment.</param>
	/// <param name="BufferLength">Size, in bytes, of the <c>pBuffer</c> buffer.</param>
	/// <param name="BytesRead">
	/// <para>
	/// Optional pointer to a variable that receives the number of bytes to be written into the output buffer. If <c>BufferLength</c> is less
	/// than this number, the call fails with a return of ERROR_INSUFFICIENT_BUFFER, and the value pointed to by <c>pBytesRead</c> can be
	/// used to determine the minimum length of buffer required for the call to succeed.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesRead</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesRead</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the cache operation is complete, whereas an asynchronous call immediately returns ERROR_IO_PENDING
	/// and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the cache request is queued and completes
	/// later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The buffer pointed to by <c>pBuffer</c> is too small to receive all the requested data; the size of buffer required is pointed to by
	/// <c>pBytesRead</c> unless it was <c>NULL</c> or the call was asynchronous. In the case of an asynchronous call, the value pointed to
	/// by the <c>lpNumberOfBytesTransferred</c> parameter of the GetOverLappedResult function is set to the buffer size required.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreadfragmentfromcache HTTPAPI_LINKAGE ULONG
	// HttpReadFragmentFromCache( [in] HANDLE RequestQueueHandle, [in] PCWSTR UrlPrefix, [in] PHTTP_BYTE_RANGE ByteRange, [out] PVOID Buffer,
	// [in] ULONG BufferLength, [out] PULONG BytesRead, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReadFragmentFromCache")]
	public static extern Win32Error HttpReadFragmentFromCache([In] HREQQUEUEv1 RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string UrlPrefix,
		[In, Optional] IntPtr ByteRange, [Out] IntPtr Buffer, [In] uint BufferLength, out uint BytesRead, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpReceiveClientCertificate</c> function is used by a server application to retrieve a client SSL certificate or channel
	/// binding token (CBT).
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue with which the specified SSL client or CBT is associated. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="ConnectionId">
	/// A value that identifies the connection to the client. This value is obtained from the <c>ConnectionId</c> element of an HTTP_REQUEST
	/// structure filled in by the HttpReceiveHttpRequest function.
	/// </param>
	/// <param name="Flags">
	/// <para>A value that modifies the behavior of the <c>HttpReceiveClientCertificate</c> function</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_RECEIVE_SECURE_CHANNEL_TOKEN</c> 0x1</term>
	/// <term>
	/// The <c>pSslClientCertInfo</c> parameter will be populated with CBT data. This value is supported on Windows 7, Windows Server 2008
	/// R2, and later.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="SslClientCertInfo">
	/// <para>
	/// If the <c>Flags</c> parameter is 0, then this parameter points to an HTTP_SSL_CLIENT_CERT_INFO structure into which the function
	/// writes the requested client certificate information. The buffer pointed to by the <c>pSslClientCertInfo</c> should be sufficiently
	/// large enough to hold the <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure plus the value of the <c>CertEncodedSize</c> member of this structure.
	/// </para>
	/// <para>
	/// If the <c>Flags</c> parameter is <c>HTTP_RECEIVE_SECURE_CHANNEL_TOKEN</c>, then this parameter points to an
	/// HTTP_REQUEST_CHANNEL_BIND_STATUS structure into which the function writes the requested CBT information. The buffer pointed to by the
	/// <c>pSslClientCertInfo</c> should be sufficiently large enough to hold the <c>HTTP_REQUEST_CHANNEL_BIND_STATUS</c> structure plus the
	/// value of the <c>ChannelTokenSize</c> member of this structure.
	/// </para>
	/// </param>
	/// <param name="SslClientCertInfoSize">The size, in bytes, of the buffer pointed to by the <c>pSslClientCertInfo</c> parameter.</param>
	/// <param name="BytesReceived">
	/// <para>
	/// An optional pointer to a variable that receives the number of bytes to be written to the structure pointed to by
	/// <c>pSslClientCertInfo</c>. If not used, set it to <c>NULL</c>.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesReceived</c> to <c>NULL</c>. Otherwise, when
	/// <c>pOverlapped</c> is set to <c>NULL</c>, <c>pBytesReceived</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the client certificate is retrieved, whereas an asynchronous call immediately returns
	/// <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the
	/// operation is completed. For more information about using OVERLAPPED structures for synchronization, see the section Synchronization
	/// and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>
	/// The function succeeded. All the data has been written into the buffer pointed to by the <c>pSslClientCertInfo</c> parameter. The
	/// <c>NumberOfBytesTransferred</c> indicates how many bytes were written into the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>
	/// The function is being used asynchronously. The operation has been initiated and will complete later through normal overlapped I/O
	/// completion mechanisms.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer pointed to by the <c>pSslClientCertInfo</c> parameter is too small to receive the data and no data was written.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The buffer pointed to by the <c>pSslClientCertInfo</c> parameter is not large enough to receive all the data. Only the basic
	/// structure has been written and only partially populated. When the <c>Flags</c> parameter is 0, the HTTP_SSL_CLIENT_CERT_INFO
	/// structure has been written with the <c>CertEncodedSize</c> member populated. The caller should call the function again with a buffer
	/// that is at least the size, in bytes, of the <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure plus the value of the <c>CertEncodedSize</c>
	/// member. When the <c>Flags</c> parameter is <c>HTTP_RECEIVE_SECURE_CHANNEL_TOKEN</c>, the HTTP_REQUEST_CHANNEL_BIND_STATUS structure
	/// has been written with the <c>ChannelTokenSize</c> member populated. The caller should call the function again with a buffer that is
	/// at least the size, in bytes, of the <c>HTTP_REQUEST_CHANNEL_BIND_STATUS</c> plus the value of the <c>ChannelTokenSize</c> member.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The function cannot find the client certificate or CBT.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in the <c>WinError.h</c> header file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The behavior of the <c>HttpReceiveClientCertificate</c> function varies based on whether a client SSL certificate or a channel
	/// binding token is requested.
	/// </para>
	/// <para>
	/// In the case of a synchronous call to the <c>HttpReceiveClientCertificate</c> function , the number of bytes received is returned in
	/// the value pointed to by the <c>pBytesReceived</c> parameter.
	/// </para>
	/// <para>
	/// In the case of an asynchronous call to the <c>HttpReceiveClientCertificate</c> function, the number of bytes received is returned by
	/// the standard mechanisms used for asynchronous calls. The <c>lpNumberOfBytesTransferred</c> parameter returned by the
	/// GetOverlappedResult function contains the number of bytes received.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreceiveclientcertificate HTTPAPI_LINKAGE ULONG
	// HttpReceiveClientCertificate( [in] HANDLE RequestQueueHandle, [in] HTTP_CONNECTION_ID ConnectionId, [in] ULONG Flags, [out]
	// PHTTP_SSL_CLIENT_CERT_INFO SslClientCertInfo, [in] ULONG SslClientCertInfoSize, [out, optional] PULONG BytesReceived, [in, optional]
	// LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveClientCertificate")]
	public static extern Win32Error HttpReceiveClientCertificate([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_CONNECTION_ID ConnectionId,
		[In] HTTP_RECEIVE Flags, [Out] IntPtr SslClientCertInfo, [In] uint SslClientCertInfoSize, out uint BytesReceived, in NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>HttpReceiveClientCertificate</c> function is used by a server application to retrieve a client SSL certificate or channel
	/// binding token (CBT).
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue with which the specified SSL client or CBT is associated. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="ConnectionId">
	/// A value that identifies the connection to the client. This value is obtained from the <c>ConnectionId</c> element of an HTTP_REQUEST
	/// structure filled in by the HttpReceiveHttpRequest function.
	/// </param>
	/// <param name="Flags">
	/// <para>A value that modifies the behavior of the <c>HttpReceiveClientCertificate</c> function</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_RECEIVE_SECURE_CHANNEL_TOKEN</c> 0x1</term>
	/// <term>
	/// The <c>pSslClientCertInfo</c> parameter will be populated with CBT data. This value is supported on Windows 7, Windows Server 2008
	/// R2, and later.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="SslClientCertInfo">
	/// <para>
	/// If the <c>Flags</c> parameter is 0, then this parameter points to an HTTP_SSL_CLIENT_CERT_INFO structure into which the function
	/// writes the requested client certificate information. The buffer pointed to by the <c>pSslClientCertInfo</c> should be sufficiently
	/// large enough to hold the <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure plus the value of the <c>CertEncodedSize</c> member of this structure.
	/// </para>
	/// <para>
	/// If the <c>Flags</c> parameter is <c>HTTP_RECEIVE_SECURE_CHANNEL_TOKEN</c>, then this parameter points to an
	/// HTTP_REQUEST_CHANNEL_BIND_STATUS structure into which the function writes the requested CBT information. The buffer pointed to by the
	/// <c>pSslClientCertInfo</c> should be sufficiently large enough to hold the <c>HTTP_REQUEST_CHANNEL_BIND_STATUS</c> structure plus the
	/// value of the <c>ChannelTokenSize</c> member of this structure.
	/// </para>
	/// </param>
	/// <param name="SslClientCertInfoSize">The size, in bytes, of the buffer pointed to by the <c>pSslClientCertInfo</c> parameter.</param>
	/// <param name="BytesReceived">
	/// <para>
	/// An optional pointer to a variable that receives the number of bytes to be written to the structure pointed to by
	/// <c>pSslClientCertInfo</c>. If not used, set it to <c>NULL</c>.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesReceived</c> to <c>NULL</c>. Otherwise, when
	/// <c>pOverlapped</c> is set to <c>NULL</c>, <c>pBytesReceived</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure, or for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the client certificate is retrieved, whereas an asynchronous call immediately returns
	/// <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the
	/// operation is completed. For more information about using OVERLAPPED structures for synchronization, see the section Synchronization
	/// and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>NO_ERROR</c></term>
	/// <term>
	/// The function succeeded. All the data has been written into the buffer pointed to by the <c>pSslClientCertInfo</c> parameter. The
	/// <c>NumberOfBytesTransferred</c> indicates how many bytes were written into the buffer.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_IO_PENDING</c></term>
	/// <term>
	/// The function is being used asynchronously. The operation has been initiated and will complete later through normal overlapped I/O
	/// completion mechanisms.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer pointed to by the <c>pSslClientCertInfo</c> parameter is too small to receive the data and no data was written.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The buffer pointed to by the <c>pSslClientCertInfo</c> parameter is not large enough to receive all the data. Only the basic
	/// structure has been written and only partially populated. When the <c>Flags</c> parameter is 0, the HTTP_SSL_CLIENT_CERT_INFO
	/// structure has been written with the <c>CertEncodedSize</c> member populated. The caller should call the function again with a buffer
	/// that is at least the size, in bytes, of the <c>HTTP_SSL_CLIENT_CERT_INFO</c> structure plus the value of the <c>CertEncodedSize</c>
	/// member. When the <c>Flags</c> parameter is <c>HTTP_RECEIVE_SECURE_CHANNEL_TOKEN</c>, the HTTP_REQUEST_CHANNEL_BIND_STATUS structure
	/// has been written with the <c>ChannelTokenSize</c> member populated. The caller should call the function again with a buffer that is
	/// at least the size, in bytes, of the <c>HTTP_REQUEST_CHANNEL_BIND_STATUS</c> plus the value of the <c>ChannelTokenSize</c> member.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_FOUND</c></term>
	/// <term>The function cannot find the client certificate or CBT.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in the <c>WinError.h</c> header file.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The behavior of the <c>HttpReceiveClientCertificate</c> function varies based on whether a client SSL certificate or a channel
	/// binding token is requested.
	/// </para>
	/// <para>
	/// In the case of a synchronous call to the <c>HttpReceiveClientCertificate</c> function , the number of bytes received is returned in
	/// the value pointed to by the <c>pBytesReceived</c> parameter.
	/// </para>
	/// <para>
	/// In the case of an asynchronous call to the <c>HttpReceiveClientCertificate</c> function, the number of bytes received is returned by
	/// the standard mechanisms used for asynchronous calls. The <c>lpNumberOfBytesTransferred</c> parameter returned by the
	/// GetOverlappedResult function contains the number of bytes received.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreceiveclientcertificate HTTPAPI_LINKAGE ULONG
	// HttpReceiveClientCertificate( [in] HANDLE RequestQueueHandle, [in] HTTP_CONNECTION_ID ConnectionId, [in] ULONG Flags, [out]
	// PHTTP_SSL_CLIENT_CERT_INFO SslClientCertInfo, [in] ULONG SslClientCertInfoSize, [out, optional] PULONG BytesReceived, [in, optional]
	// LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveClientCertificate")]
	public static extern Win32Error HttpReceiveClientCertificate([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_CONNECTION_ID ConnectionId,
		[In] HTTP_RECEIVE Flags, [Out] IntPtr SslClientCertInfo, [In] uint SslClientCertInfoSize, out uint BytesReceived, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpReceiveHttpRequest</c> function retrieves the next available HTTP request from the specified request queue either
	/// synchronously or asynchronously.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which to retrieve the next available request. A request queue is created and its handle returned
	/// by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// On the first call to retrieve a request, this parameter should be <c>HTTP_NULL_ID</c>. Then, if more than one call is required to
	/// retrieve the entire request, <c>HttpReceiveHttpRequest</c> or HttpReceiveRequestEntityBody can be called with <c>RequestID</c> set to
	/// the value returned in the <c>RequestId</c> member of the HTTP_REQUEST structure pointed to by <c>pRequestBuffer</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>A parameter that can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>0 (zero)</c></term>
	/// <term>Only the request headers are retrieved; the entity body is not copied.</term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY</c></term>
	/// <term>
	/// The available entity body is copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
	/// points to the entity body.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_FLAG_FLUSH_BODY</c></term>
	/// <term>
	/// All of the entity bodies are copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
	/// points to the entity body.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="RequestBuffer">
	/// A pointer to a buffer into which the function copies an HTTP_REQUEST structure and entity body for the HTTP request.
	/// <c>HTTP_REQUEST.RequestId</c> contains the identifier for this HTTP request, which the application can use in subsequent calls
	/// HttpReceiveRequestEntityBody, HttpSendHttpResponse, or HttpSendResponseEntityBody.
	/// </param>
	/// <param name="RequestBufferLength">Size, in bytes, of the <c>pRequestBuffer</c> buffer.</param>
	/// <param name="BytesReturned">
	/// <para>
	/// Optional. A pointer to a variable that receives the size, in bytes, of the entity body, or of the remaining part of the entity body.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesReceived</c> to <c>NULL</c>. Otherwise, when
	/// <c>pOverlapped</c> is set to <c>NULL</c>, <c>pBytesReceived</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until a request has arrived in the specified queue and some or all of it has been retrieved, whereas an
	/// asynchronous call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O
	/// completion ports to determine when the operation is completed. For more information about using OVERLAPPED structures for
	/// synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is being used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet
	/// ready and will be retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOACCESS</c></term>
	/// <term>
	/// One or more of the supplied parameters points to an invalid or unaligned memory buffer. The <c>pRequestBuffer</c> parameter must
	/// point to a valid memory buffer with a memory alignment equal or greater to the memory alignment requirement for an
	/// <c>HTTP_REQUEST</c> structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The value of <c>RequestBufferLength</c> is greater than or equal to the size of the request header received, but is not as large as
	/// the combined size of the request structure and entity body. The buffer size required to read the remaining part of the entity body is
	/// returned in the <c>pBytesReceived</c> parameter if this is non- <c>NULL</c> and if the call is synchronous. Call the function again
	/// with a large enough buffer to retrieve all data.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HANDLE_EOF</c></term>
	/// <term>
	/// The specified request has already been completely retrieved; in this case, the value pointed to by <c>pBytesReceived</c> is not
	/// meaningful, and <c>pRequestBuffer</c> should not be examined.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// More than one call can be required to retrieve a given request. When the <c>Flags</c> parameter is set to zero, for example,
	/// <c>HttpReceiveHttpRequest</c> only copies the request header structure into the buffer, and does not attempt to copy any of the
	/// entity body. In this case, the HttpReceiveRequestEntityBody function can be used to retrieve the entity body, or a second call can be
	/// made to <c>HttpReceiveHttpRequest</c>.
	/// </para>
	/// <para>
	/// Alternatively, the buffer provided by the application may be insufficiently large to receive all or part of the request. To be sure
	/// of receiving at least part of the request, it is recommended that an application provide at least a buffer of 4 KB, which
	/// accommodates most HTTP requests. Alternately, authentication headers, parsed as unknown headers, can add up to 12 KB to that, so if
	/// authentication/authorization is used, a buffer size of at least 16 KB is recommended.
	/// </para>
	/// <para>
	/// If <c>HttpReceiveHttpRequest</c> returns <c>ERROR_MORE_DATA</c>, the application continues to make additional calls, identifying the
	/// request in each additional call by passing in the <c>HTTP_REQUEST.RequestId</c> value returned by the first call until
	/// <c>ERROR_HANDLE_EOF</c> is returned.
	/// </para>
	/// <para>
	/// <c>Note</c> The application must examine all relevant request headers, including content-negotiation headers if used, and fail the
	/// request as appropriate based on the header content. <c>HttpReceiveHttpRequest</c> ensures only that the header line is properly
	/// terminated and does not contain illegal characters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreceivehttprequest HTTPAPI_LINKAGE ULONG HttpReceiveHttpRequest(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [out] PHTTP_REQUEST RequestBuffer, [in] ULONG
	// RequestBufferLength, [out, optional] PULONG BytesReturned, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveHttpRequest")]
	public static extern Win32Error HttpReceiveHttpRequest([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId,
		[In] HTTP_RECEIVE_REQUEST_FLAG Flags, [Out] IntPtr RequestBuffer, [In] uint RequestBufferLength, out uint BytesReturned, in NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>HttpReceiveHttpRequest</c> function retrieves the next available HTTP request from the specified request queue either
	/// synchronously or asynchronously.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which to retrieve the next available request. A request queue is created and its handle returned
	/// by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// On the first call to retrieve a request, this parameter should be <c>HTTP_NULL_ID</c>. Then, if more than one call is required to
	/// retrieve the entire request, <c>HttpReceiveHttpRequest</c> or HttpReceiveRequestEntityBody can be called with <c>RequestID</c> set to
	/// the value returned in the <c>RequestId</c> member of the HTTP_REQUEST structure pointed to by <c>pRequestBuffer</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>A parameter that can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>0 (zero)</c></term>
	/// <term>Only the request headers are retrieved; the entity body is not copied.</term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY</c></term>
	/// <term>
	/// The available entity body is copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
	/// points to the entity body.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_FLAG_FLUSH_BODY</c></term>
	/// <term>
	/// All of the entity bodies are copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
	/// points to the entity body.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="RequestBuffer">
	/// A pointer to a buffer into which the function copies an HTTP_REQUEST structure and entity body for the HTTP request.
	/// <c>HTTP_REQUEST.RequestId</c> contains the identifier for this HTTP request, which the application can use in subsequent calls
	/// HttpReceiveRequestEntityBody, HttpSendHttpResponse, or HttpSendResponseEntityBody.
	/// </param>
	/// <param name="RequestBufferLength">Size, in bytes, of the <c>pRequestBuffer</c> buffer.</param>
	/// <param name="BytesReturned">
	/// <para>
	/// Optional. A pointer to a variable that receives the size, in bytes, of the entity body, or of the remaining part of the entity body.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesReceived</c> to <c>NULL</c>. Otherwise, when
	/// <c>pOverlapped</c> is set to <c>NULL</c>, <c>pBytesReceived</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until a request has arrived in the specified queue and some or all of it has been retrieved, whereas an
	/// asynchronous call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O
	/// completion ports to determine when the operation is completed. For more information about using OVERLAPPED structures for
	/// synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is being used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet
	/// ready and will be retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOACCESS</c></term>
	/// <term>
	/// One or more of the supplied parameters points to an invalid or unaligned memory buffer. The <c>pRequestBuffer</c> parameter must
	/// point to a valid memory buffer with a memory alignment equal or greater to the memory alignment requirement for an
	/// <c>HTTP_REQUEST</c> structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The value of <c>RequestBufferLength</c> is greater than or equal to the size of the request header received, but is not as large as
	/// the combined size of the request structure and entity body. The buffer size required to read the remaining part of the entity body is
	/// returned in the <c>pBytesReceived</c> parameter if this is non- <c>NULL</c> and if the call is synchronous. Call the function again
	/// with a large enough buffer to retrieve all data.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HANDLE_EOF</c></term>
	/// <term>
	/// The specified request has already been completely retrieved; in this case, the value pointed to by <c>pBytesReceived</c> is not
	/// meaningful, and <c>pRequestBuffer</c> should not be examined.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// More than one call can be required to retrieve a given request. When the <c>Flags</c> parameter is set to zero, for example,
	/// <c>HttpReceiveHttpRequest</c> only copies the request header structure into the buffer, and does not attempt to copy any of the
	/// entity body. In this case, the HttpReceiveRequestEntityBody function can be used to retrieve the entity body, or a second call can be
	/// made to <c>HttpReceiveHttpRequest</c>.
	/// </para>
	/// <para>
	/// Alternatively, the buffer provided by the application may be insufficiently large to receive all or part of the request. To be sure
	/// of receiving at least part of the request, it is recommended that an application provide at least a buffer of 4 KB, which
	/// accommodates most HTTP requests. Alternately, authentication headers, parsed as unknown headers, can add up to 12 KB to that, so if
	/// authentication/authorization is used, a buffer size of at least 16 KB is recommended.
	/// </para>
	/// <para>
	/// If <c>HttpReceiveHttpRequest</c> returns <c>ERROR_MORE_DATA</c>, the application continues to make additional calls, identifying the
	/// request in each additional call by passing in the <c>HTTP_REQUEST.RequestId</c> value returned by the first call until
	/// <c>ERROR_HANDLE_EOF</c> is returned.
	/// </para>
	/// <para>
	/// <c>Note</c> The application must examine all relevant request headers, including content-negotiation headers if used, and fail the
	/// request as appropriate based on the header content. <c>HttpReceiveHttpRequest</c> ensures only that the header line is properly
	/// terminated and does not contain illegal characters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreceivehttprequest HTTPAPI_LINKAGE ULONG HttpReceiveHttpRequest(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [out] PHTTP_REQUEST RequestBuffer, [in] ULONG
	// RequestBufferLength, [out, optional] PULONG BytesReturned, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveHttpRequest")]
	public static extern Win32Error HttpReceiveHttpRequest([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId,
		[In] HTTP_RECEIVE_REQUEST_FLAG Flags, [Out] IntPtr RequestBuffer, [In] uint RequestBufferLength, out uint BytesReturned, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpReceiveHttpRequest</c> function retrieves the next available HTTP request from the specified request queue either
	/// synchronously or asynchronously.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="RequestBuffer"/>.</typeparam>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which to retrieve the next available request. A request queue is created and its handle returned
	/// by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// On the first call to retrieve a request, this parameter should be <c>HTTP_NULL_ID</c>. Then, if more than one call is required to
	/// retrieve the entire request, <c>HttpReceiveHttpRequest</c> or HttpReceiveRequestEntityBody can be called with <c>RequestID</c> set to
	/// the value returned in the <c>RequestId</c> member of the HTTP_REQUEST structure pointed to by <c>pRequestBuffer</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>A parameter that can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>0 (zero)</c></term>
	/// <term>Only the request headers are retrieved; the entity body is not copied.</term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_FLAG_COPY_BODY</c></term>
	/// <term>
	/// The available entity body is copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
	/// points to the entity body.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_FLAG_FLUSH_BODY</c></term>
	/// <term>
	/// All of the entity bodies are copied along with the request headers. The <c>pEntityChunks</c> member of the HTTP_REQUEST structure
	/// points to the entity body.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="RequestBuffer">
	/// A pointer to a buffer into which the function copies an HTTP_REQUEST structure and entity body for the HTTP request.
	/// <c>HTTP_REQUEST.RequestId</c> contains the identifier for this HTTP request, which the application can use in subsequent calls
	/// HttpReceiveRequestEntityBody, HttpSendHttpResponse, or HttpSendResponseEntityBody.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is being used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet
	/// ready and will be retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOACCESS</c></term>
	/// <term>
	/// One or more of the supplied parameters points to an invalid or unaligned memory buffer. The <c>pRequestBuffer</c> parameter must
	/// point to a valid memory buffer with a memory alignment equal or greater to the memory alignment requirement for an
	/// <c>HTTP_REQUEST</c> structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// The value of <c>RequestBufferLength</c> is greater than or equal to the size of the request header received, but is not as large as
	/// the combined size of the request structure and entity body. The buffer size required to read the remaining part of the entity body is
	/// returned in the <c>pBytesReceived</c> parameter if this is non- <c>NULL</c> and if the call is synchronous. Call the function again
	/// with a large enough buffer to retrieve all data.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HANDLE_EOF</c></term>
	/// <term>
	/// The specified request has already been completely retrieved; in this case, the value pointed to by <c>pBytesReceived</c> is not
	/// meaningful, and <c>pRequestBuffer</c> should not be examined.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// More than one call can be required to retrieve a given request. When the <c>Flags</c> parameter is set to zero, for example,
	/// <c>HttpReceiveHttpRequest</c> only copies the request header structure into the buffer, and does not attempt to copy any of the
	/// entity body. In this case, the HttpReceiveRequestEntityBody function can be used to retrieve the entity body, or a second call can be
	/// made to <c>HttpReceiveHttpRequest</c>.
	/// </para>
	/// <para>
	/// Alternatively, the buffer provided by the application may be insufficiently large to receive all or part of the request. To be sure
	/// of receiving at least part of the request, it is recommended that an application provide at least a buffer of 4 KB, which
	/// accommodates most HTTP requests. Alternately, authentication headers, parsed as unknown headers, can add up to 12 KB to that, so if
	/// authentication/authorization is used, a buffer size of at least 16 KB is recommended.
	/// </para>
	/// <para>
	/// If <c>HttpReceiveHttpRequest</c> returns <c>ERROR_MORE_DATA</c>, the application continues to make additional calls, identifying the
	/// request in each additional call by passing in the <c>HTTP_REQUEST.RequestId</c> value returned by the first call until
	/// <c>ERROR_HANDLE_EOF</c> is returned.
	/// </para>
	/// <para>
	/// <c>Note</c> The application must examine all relevant request headers, including content-negotiation headers if used, and fail the
	/// request as appropriate based on the header content. <c>HttpReceiveHttpRequest</c> ensures only that the header line is properly
	/// terminated and does not contain illegal characters.
	/// </para>
	/// </remarks>
	public static Win32Error HttpReceiveHttpRequest<T>(HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId,
		[In] HTTP_RECEIVE_REQUEST_FLAG Flags, out T RequestBuffer) where T : struct
	{
		using var mem = new SafeCoTaskMemStruct<T>();
		var err = HttpReceiveHttpRequest(RequestQueueHandle, RequestId, Flags, mem, mem.Size, out var sz, default);
		switch ((uint)err)
		{
			case Win32Error.ERROR_SUCCESS:
				RequestBuffer = mem.Value;
				return Win32Error.ERROR_SUCCESS;

			case Win32Error.ERROR_MORE_DATA:
				RequestId = mem.DangerousGetHandle().AsRef<HTTP_REQUEST_V1>().RequestId;
				mem.Size = sz;
				break;

			case Win32Error.ERROR_CONNECTION_INVALID:
				if (RequestId != HTTP_NULL_ID)
					RequestId = HTTP_NULL_ID;
				break;

			default:
				RequestBuffer = default;
				return err;
		}
		err = HttpReceiveHttpRequest(RequestQueueHandle, RequestId, Flags, mem, mem.Size, out _, default);
		RequestBuffer = mem.Value;
		return err;
	}

	/// <summary>The <c>HttpReceiveRequestEntityBody</c> function receives additional entity body data for a specified HTTP request.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// The handle to the request queue from which to retrieve the specified entity body data. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// The identifier of the HTTP request that contains the retrieved entity body. This value is returned in the <c>RequestId</c> member of
	/// the HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. This value cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be the following flag value.</para>
	/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This parameter is reserved and must be zero.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_ENTITY_BODY_FLAG_FILL_BUFFER</c></term>
	/// <term>Specifies that the buffer will be filled with one or more entity bodies, unless there are no remaining entity bodies to copy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="EntityBuffer">A pointer to a buffer that receives entity-body data.</param>
	/// <param name="EntityBufferLength">The size, in bytes, of the buffer pointed to by the <c>pBuffer</c> parameter.</param>
	/// <param name="BytesReturned">
	/// <para>
	/// Optional. A pointer to a variables that receives the size, in bytes, of the entity body data returned in the <c>pBuffer</c> buffer.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesReceived</c> to <c>NULL</c>. Otherwise, when
	/// <c>pOverlapped</c> is set to <c>NULL</c>, <c>pBytesReceived</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the entity-body data has been retrieved, whereas an asynchronous call immediately returns
	/// <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the
	/// operation is completed. For more information about using OVERLAPPED structures for synchronization, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters are in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HANDLE_EOF</c></term>
	/// <term>
	/// The specified entity body has already been completely retrieved; in this case, the value pointed to by <c>pBytesReceived</c> is not
	/// meaningful, and <c>pBuffer</c> should not be examined.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DLL_INIT_FAILED</c></term>
	/// <term>The calling application did not call HttpInitialize before calling this function.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To retrieve an entire entity body, an application is expected to call <c>HttpReceiveRequestEntityBody</c>, passing in new buffers,
	/// until the function returns <c>ERROR_HANDLE_EOF</c>. As long as a buffer full of entity-body data is copied successfully and there is
	/// still more entity-body data waiting to be retrieved, the function returns <c>NO_ERROR</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreceiverequestentitybody HTTPAPI_LINKAGE ULONG
	// HttpReceiveRequestEntityBody( [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [out] PVOID
	// EntityBuffer, [in] ULONG EntityBufferLength, [out, optional] PULONG BytesReturned, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveRequestEntityBody")]
	public static extern Win32Error HttpReceiveRequestEntityBody([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId,
		[In] HTTP_RECEIVE_REQUEST_ENTITY_BODY_FLAG Flags, [Out] IntPtr EntityBuffer, [In] uint EntityBufferLength, out uint BytesReturned,
		in NativeOverlapped Overlapped);

	/// <summary>The <c>HttpReceiveRequestEntityBody</c> function receives additional entity body data for a specified HTTP request.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// The handle to the request queue from which to retrieve the specified entity body data. A request queue is created and its handle
	/// returned by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// The identifier of the HTTP request that contains the retrieved entity body. This value is returned in the <c>RequestId</c> member of
	/// the HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. This value cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be the following flag value.</para>
	/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This parameter is reserved and must be zero.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_RECEIVE_REQUEST_ENTITY_BODY_FLAG_FILL_BUFFER</c></term>
	/// <term>Specifies that the buffer will be filled with one or more entity bodies, unless there are no remaining entity bodies to copy.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="EntityBuffer">A pointer to a buffer that receives entity-body data.</param>
	/// <param name="EntityBufferLength">The size, in bytes, of the buffer pointed to by the <c>pBuffer</c> parameter.</param>
	/// <param name="BytesReturned">
	/// <para>
	/// Optional. A pointer to a variables that receives the size, in bytes, of the entity body data returned in the <c>pBuffer</c> buffer.
	/// </para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesReceived</c> to <c>NULL</c>. Otherwise, when
	/// <c>pOverlapped</c> is set to <c>NULL</c>, <c>pBytesReceived</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the entity-body data has been retrieved, whereas an asynchronous call immediately returns
	/// <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the
	/// operation is completed. For more information about using OVERLAPPED structures for synchronization, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters are in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_HANDLE_EOF</c></term>
	/// <term>
	/// The specified entity body has already been completely retrieved; in this case, the value pointed to by <c>pBytesReceived</c> is not
	/// meaningful, and <c>pBuffer</c> should not be examined.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DLL_INIT_FAILED</c></term>
	/// <term>The calling application did not call HttpInitialize before calling this function.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To retrieve an entire entity body, an application is expected to call <c>HttpReceiveRequestEntityBody</c>, passing in new buffers,
	/// until the function returns <c>ERROR_HANDLE_EOF</c>. As long as a buffer full of entity-body data is copied successfully and there is
	/// still more entity-body data waiting to be retrieved, the function returns <c>NO_ERROR</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpreceiverequestentitybody HTTPAPI_LINKAGE ULONG
	// HttpReceiveRequestEntityBody( [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [out] PVOID
	// EntityBuffer, [in] ULONG EntityBufferLength, [out, optional] PULONG BytesReturned, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpReceiveRequestEntityBody")]
	public static extern Win32Error HttpReceiveRequestEntityBody([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId,
		[In] HTTP_RECEIVE_REQUEST_ENTITY_BODY_FLAG Flags, [Out] IntPtr EntityBuffer, [In] uint EntityBufferLength, out uint BytesReturned,
		[In, Optional] IntPtr Overlapped);

	/// <summary>
	/// <para>
	/// The <c>HttpRemoveUrl</c> function causes the system to stop routing requests that match a specified UrlPrefix string to a specified
	/// request queue.
	/// </para>
	/// <para>
	/// Starting with HTTP Server API Version 2.0, applications should call HttpRemoveUrlFromUrlGroup to register a URL; <c>HttpRemoveUrl</c>
	/// should not be used.
	/// </para>
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// The handle to the request queue from which the URL registration is to be removed. A request queue is created and its handle returned
	/// by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="FullyQualifiedUrl">
	/// A pointer to a UrlPrefix string registered to the specified request queue. This string must be identical to the one passed to
	/// HttpAddUrl to register the UrlPrefix; even a nomenclature change in an IPv6 address is not accepted.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling application does not have permission to remove the URL.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_ENOUGH_MEMORY</c></term>
	/// <term>Insufficient resources to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The specified UrlPrefix could not be found in the registration database.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpremoveurl HTTPAPI_LINKAGE ULONG HttpRemoveUrl( [in] HANDLE
	// RequestQueueHandle, [in] PCWSTR FullyQualifiedUrl );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpRemoveUrl")]
	public static extern Win32Error HttpRemoveUrl([In] HREQQUEUEv1 RequestQueueHandle, [MarshalAs(UnmanagedType.LPWStr)] string FullyQualifiedUrl);

	/// <summary>
	/// <para>
	/// The <c>HttpRemoveUrlFromUrlGroup</c> function removes the specified URL from the group identified by the URL Group ID. This function
	/// removes one, or all, of the URLs from the group.
	/// </para>
	/// <para>This function replaces the HTTP version 1.0 HttpRemoveUrl function.</para>
	/// </summary>
	/// <param name="UrlGroupId">The ID of the URL group from which the URL specified in <c>pFullyQualifiedUrl</c> is removed.</param>
	/// <param name="pFullyQualifiedUrl">
	/// <para>A pointer to a Unicode string that contains a properly formed UrlPrefix String that identifies the URL to be removed.</para>
	/// <para>
	/// When <c>HTTP_URL_FLAG_REMOVE_ALL</c> is passed in the <c>Flags</c> parameter, all of the existing URL registrations for the URL Group
	/// identified in <c>UrlGroupId</c> are removed from the group. In this case, <c>pFullyQualifiedUrl</c> must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>The URL flags qualifying the URL that is removed. This can be one of the following flags:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>URL Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_URL_FLAG_REMOVE_ALL</c></term>
	/// <term>Removes all of the URLs currently registered with the URL Group.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns NO_ERROR.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The URL Group does not exist. The Flags parameter contains an invalid combination of flags. The HTTP_URL_FLAG_REMOVE_ALL flag was set
	/// and the <c>pFullyQualifiedUrl</c> parameter was not set to <c>NULL</c>. The application does not have permission to remove URLs from
	/// the Group. Only the application that created the URL Group can remove URLs.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ACCESS_DENIED</c></term>
	/// <term>The calling process does not have permission to deregister the URL.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The specified URL is not registered with the URL Group.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The HTTP Server API supports existing applications using the version 1.0 URL registrations, however, new development with the HTTP
	/// Server API should use <c>HttpRemoveUrlFromUrlGroup</c>; do not use HttpRemoveUrl.
	/// </para>
	/// <para>Applications should remove the URL added to the group by HttpAddUrlToUrlGroup, when the URL is no longer required.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpremoveurlfromurlgroup HTTPAPI_LINKAGE ULONG
	// HttpRemoveUrlFromUrlGroup( [in] HTTP_URL_GROUP_ID UrlGroupId, [in] PCWSTR pFullyQualifiedUrl, [in] ULONG Flags );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpRemoveUrlFromUrlGroup")]
	public static extern Win32Error HttpRemoveUrlFromUrlGroup([In] HTTP_URL_GROUP_ID UrlGroupId, [MarshalAs(UnmanagedType.LPWStr)] string pFullyQualifiedUrl,
		[In, Optional] HTTP_URL_FLAG Flags);

	/// <summary>The <c>HttpSendHttpResponse</c> function sends an HTTP response to the specified HTTP request.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which the specified request was retrieved. A request queue is created and its handle returned by a
	/// call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// An identifier of the HTTP request to which this response corresponds. This value is returned in the <c>RequestId</c> member of the
	/// HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. This value cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be a combination of some of the following flag values. Those that are mutually exclusive are marked accordingly.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_DISCONNECT</c></term>
	/// <term>
	/// The network connection should be disconnected after sending this response, overriding any persistent connection features associated
	/// with the version of HTTP in use.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_MORE_DATA</c></term>
	/// <term>
	/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
	/// HttpSendResponseEntityBody. The last call sending entity-body data then sets this flag to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA</c></term>
	/// <term>
	/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous I/O
	/// or by an application doing asynchronous I/O with no more than one outstanding send at a time. Applications that use asynchronous I/O
	/// and that may have more than one send outstanding at a time should not use this flag. When this flag is set, it should also be used
	/// consistently in calls to the HttpSendResponseEntityBody function. <c>Windows Server 2003:</c> This flag is not supported. This flag
	/// is new for Windows Server 2003 with SP1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING</c></term>
	/// <term>
	/// Enables the TCP nagling algorithm for this send only. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES</c></term>
	/// <term>
	/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
	/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_OPAQUE</c></term>
	/// <term>
	/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
	/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
	/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
	/// <c>HttpSendHttpResponse</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used. <c>Windows
	/// 8 and later:</c> This flag is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HttpResponse">A pointer to an HTTP_RESPONSE structure that defines the HTTP response.</param>
	/// <param name="CachePolicy">
	/// <para>A pointer to the HTTP_CACHE_POLICY structure used to cache the response.</para>
	/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="BytesSent">
	/// <para>Optional. A pointer to a variable that receives the number, in bytes, sent if the function operates synchronously.</para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesSent</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesSent</c> must contain a valid memory address and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Reserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="Reserved2">This parameter is reserved and must be zero.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until all response data specified in the <c>pHttpResponse</c> parameter is sent, whereas an asynchronous
	/// call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to
	/// determine when the operation is completed. For more information about using OVERLAPPED structures for synchronization, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <param name="LogData">
	/// <para>
	/// A pointer to the HTTP_LOG_DATA structure used to log the response. Pass a pointer to the HTTP_LOG_FIELDS_DATA structure and cast it
	/// to <c>PHTTP_LOG_DATA</c>.
	/// </para>
	/// <para>
	/// Be aware that even when logging is enabled on a URL Group, or server session, the response will not be logged unless the application
	/// supplies the log fields data structure.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// <para><c>Windows Vista and Windows Server 2008:</c> This parameter is new for Windows Vista, and Windows Server 2008</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HttpSendHttpResponse</c> function is used to create and send a response header, and the HttpSendResponseEntityBody function
	/// can be used to send entity-body data as required.
	/// </para>
	/// <para>
	/// If neither a content-length header nor a transfer-encoding header is included with the response, the application must indicate the
	/// end of the response by explicitly closing the connection by using the <c>HTTP_SEND_RESPONSE_DISCONNECT</c> flag.
	/// </para>
	/// <para>
	/// If an application specifies a "Server:" header in a response, using the <c>HttpHeaderServer</c> identifier in the HTTP_KNOWN_HEADER
	/// structure, that specified value is placed as the first part of the header, followed by a space and then "Microsoft-HTTPAPI/1.0". If
	/// no server header is specified, <c>HttpSendHttpResponse</c> supplies "Microsoft-HTTPAPI/1.0" as the server header.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpSendHttpResponse</c> and HttpSendResponseEntityBody function must not be called simultaneously from different
	/// threads on the same <c>RequestId</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsendhttpresponse HTTPAPI_LINKAGE ULONG HttpSendHttpResponse( [in]
	// HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [in] PHTTP_RESPONSE HttpResponse, [in, optional]
	// PHTTP_CACHE_POLICY CachePolicy, [out] PULONG BytesSent, [in] PVOID Reserved1, [in] ULONG Reserved2, [in] LPOVERLAPPED Overlapped, [in,
	// optional] PHTTP_LOG_DATA LogData );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendHttpResponse")]
	public static extern Win32Error HttpSendHttpResponse([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_SEND_RESPONSE_FLAG Flags,
		in HTTP_RESPONSE_V1 HttpResponse, in HTTP_CACHE_POLICY CachePolicy, out uint BytesSent, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2,
		in NativeOverlapped Overlapped, in HTTP_LOG_DATA LogData);

	/// <summary>The <c>HttpSendHttpResponse</c> function sends an HTTP response to the specified HTTP request.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which the specified request was retrieved. A request queue is created and its handle returned by a
	/// call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// An identifier of the HTTP request to which this response corresponds. This value is returned in the <c>RequestId</c> member of the
	/// HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. This value cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be a combination of some of the following flag values. Those that are mutually exclusive are marked accordingly.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_DISCONNECT</c></term>
	/// <term>
	/// The network connection should be disconnected after sending this response, overriding any persistent connection features associated
	/// with the version of HTTP in use.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_MORE_DATA</c></term>
	/// <term>
	/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
	/// HttpSendResponseEntityBody. The last call sending entity-body data then sets this flag to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA</c></term>
	/// <term>
	/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous I/O
	/// or by an application doing asynchronous I/O with no more than one outstanding send at a time. Applications that use asynchronous I/O
	/// and that may have more than one send outstanding at a time should not use this flag. When this flag is set, it should also be used
	/// consistently in calls to the HttpSendResponseEntityBody function. <c>Windows Server 2003:</c> This flag is not supported. This flag
	/// is new for Windows Server 2003 with SP1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING</c></term>
	/// <term>
	/// Enables the TCP nagling algorithm for this send only. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES</c></term>
	/// <term>
	/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
	/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_OPAQUE</c></term>
	/// <term>
	/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
	/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
	/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
	/// <c>HttpSendHttpResponse</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used. <c>Windows
	/// 8 and later:</c> This flag is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HttpResponse">A pointer to an HTTP_RESPONSE structure that defines the HTTP response.</param>
	/// <param name="CachePolicy">
	/// <para>A pointer to the HTTP_CACHE_POLICY structure used to cache the response.</para>
	/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="BytesSent">
	/// <para>Optional. A pointer to a variable that receives the number, in bytes, sent if the function operates synchronously.</para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesSent</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesSent</c> must contain a valid memory address and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Reserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="Reserved2">This parameter is reserved and must be zero.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until all response data specified in the <c>pHttpResponse</c> parameter is sent, whereas an asynchronous
	/// call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to
	/// determine when the operation is completed. For more information about using OVERLAPPED structures for synchronization, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <param name="LogData">
	/// <para>
	/// A pointer to the HTTP_LOG_DATA structure used to log the response. Pass a pointer to the HTTP_LOG_FIELDS_DATA structure and cast it
	/// to <c>PHTTP_LOG_DATA</c>.
	/// </para>
	/// <para>
	/// Be aware that even when logging is enabled on a URL Group, or server session, the response will not be logged unless the application
	/// supplies the log fields data structure.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// <para><c>Windows Vista and Windows Server 2008:</c> This parameter is new for Windows Vista, and Windows Server 2008</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HttpSendHttpResponse</c> function is used to create and send a response header, and the HttpSendResponseEntityBody function
	/// can be used to send entity-body data as required.
	/// </para>
	/// <para>
	/// If neither a content-length header nor a transfer-encoding header is included with the response, the application must indicate the
	/// end of the response by explicitly closing the connection by using the <c>HTTP_SEND_RESPONSE_DISCONNECT</c> flag.
	/// </para>
	/// <para>
	/// If an application specifies a "Server:" header in a response, using the <c>HttpHeaderServer</c> identifier in the HTTP_KNOWN_HEADER
	/// structure, that specified value is placed as the first part of the header, followed by a space and then "Microsoft-HTTPAPI/1.0". If
	/// no server header is specified, <c>HttpSendHttpResponse</c> supplies "Microsoft-HTTPAPI/1.0" as the server header.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpSendHttpResponse</c> and HttpSendResponseEntityBody function must not be called simultaneously from different
	/// threads on the same <c>RequestId</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsendhttpresponse HTTPAPI_LINKAGE ULONG HttpSendHttpResponse( [in]
	// HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [in] PHTTP_RESPONSE HttpResponse, [in, optional]
	// PHTTP_CACHE_POLICY CachePolicy, [out] PULONG BytesSent, [in] PVOID Reserved1, [in] ULONG Reserved2, [in] LPOVERLAPPED Overlapped, [in,
	// optional] PHTTP_LOG_DATA LogData );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendHttpResponse")]
	public static extern Win32Error HttpSendHttpResponse([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_SEND_RESPONSE_FLAG Flags,
		in HTTP_RESPONSE_V1 HttpResponse, [In, Optional] IntPtr CachePolicy, out uint BytesSent, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2,
		[In, Optional] IntPtr Overlapped, [In, Optional] IntPtr LogData);

	/// <summary>The <c>HttpSendHttpResponse</c> function sends an HTTP response to the specified HTTP request.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which the specified request was retrieved. A request queue is created and its handle returned by a
	/// call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// An identifier of the HTTP request to which this response corresponds. This value is returned in the <c>RequestId</c> member of the
	/// HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. This value cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be a combination of some of the following flag values. Those that are mutually exclusive are marked accordingly.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_DISCONNECT</c></term>
	/// <term>
	/// The network connection should be disconnected after sending this response, overriding any persistent connection features associated
	/// with the version of HTTP in use.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_MORE_DATA</c></term>
	/// <term>
	/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
	/// HttpSendResponseEntityBody. The last call sending entity-body data then sets this flag to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA</c></term>
	/// <term>
	/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous I/O
	/// or by an application doing asynchronous I/O with no more than one outstanding send at a time. Applications that use asynchronous I/O
	/// and that may have more than one send outstanding at a time should not use this flag. When this flag is set, it should also be used
	/// consistently in calls to the HttpSendResponseEntityBody function. <c>Windows Server 2003:</c> This flag is not supported. This flag
	/// is new for Windows Server 2003 with SP1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING</c></term>
	/// <term>
	/// Enables the TCP nagling algorithm for this send only. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES</c></term>
	/// <term>
	/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
	/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_OPAQUE</c></term>
	/// <term>
	/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
	/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
	/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
	/// <c>HttpSendHttpResponse</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used. <c>Windows
	/// 8 and later:</c> This flag is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HttpResponse">A pointer to an HTTP_RESPONSE structure that defines the HTTP response.</param>
	/// <param name="CachePolicy">
	/// <para>A pointer to the HTTP_CACHE_POLICY structure used to cache the response.</para>
	/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="BytesSent">
	/// <para>Optional. A pointer to a variable that receives the number, in bytes, sent if the function operates synchronously.</para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesSent</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesSent</c> must contain a valid memory address and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Reserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="Reserved2">This parameter is reserved and must be zero.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until all response data specified in the <c>pHttpResponse</c> parameter is sent, whereas an asynchronous
	/// call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to
	/// determine when the operation is completed. For more information about using OVERLAPPED structures for synchronization, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <param name="LogData">
	/// <para>
	/// A pointer to the HTTP_LOG_DATA structure used to log the response. Pass a pointer to the HTTP_LOG_FIELDS_DATA structure and cast it
	/// to <c>PHTTP_LOG_DATA</c>.
	/// </para>
	/// <para>
	/// Be aware that even when logging is enabled on a URL Group, or server session, the response will not be logged unless the application
	/// supplies the log fields data structure.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// <para><c>Windows Vista and Windows Server 2008:</c> This parameter is new for Windows Vista, and Windows Server 2008</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HttpSendHttpResponse</c> function is used to create and send a response header, and the HttpSendResponseEntityBody function
	/// can be used to send entity-body data as required.
	/// </para>
	/// <para>
	/// If neither a content-length header nor a transfer-encoding header is included with the response, the application must indicate the
	/// end of the response by explicitly closing the connection by using the <c>HTTP_SEND_RESPONSE_DISCONNECT</c> flag.
	/// </para>
	/// <para>
	/// If an application specifies a "Server:" header in a response, using the <c>HttpHeaderServer</c> identifier in the HTTP_KNOWN_HEADER
	/// structure, that specified value is placed as the first part of the header, followed by a space and then "Microsoft-HTTPAPI/1.0". If
	/// no server header is specified, <c>HttpSendHttpResponse</c> supplies "Microsoft-HTTPAPI/1.0" as the server header.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpSendHttpResponse</c> and HttpSendResponseEntityBody function must not be called simultaneously from different
	/// threads on the same <c>RequestId</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsendhttpresponse HTTPAPI_LINKAGE ULONG HttpSendHttpResponse( [in]
	// HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [in] PHTTP_RESPONSE HttpResponse, [in, optional]
	// PHTTP_CACHE_POLICY CachePolicy, [out] PULONG BytesSent, [in] PVOID Reserved1, [in] ULONG Reserved2, [in] LPOVERLAPPED Overlapped, [in,
	// optional] PHTTP_LOG_DATA LogData );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendHttpResponse")]
	public static extern Win32Error HttpSendHttpResponse([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_SEND_RESPONSE_FLAG Flags,
		in HTTP_RESPONSE_V2 HttpResponse, in HTTP_CACHE_POLICY CachePolicy, out uint BytesSent, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2,
		in NativeOverlapped Overlapped, in HTTP_LOG_DATA LogData);

	/// <summary>The <c>HttpSendHttpResponse</c> function sends an HTTP response to the specified HTTP request.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which the specified request was retrieved. A request queue is created and its handle returned by a
	/// call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// An identifier of the HTTP request to which this response corresponds. This value is returned in the <c>RequestId</c> member of the
	/// HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. This value cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can be a combination of some of the following flag values. Those that are mutually exclusive are marked accordingly.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_DISCONNECT</c></term>
	/// <term>
	/// The network connection should be disconnected after sending this response, overriding any persistent connection features associated
	/// with the version of HTTP in use.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_MORE_DATA</c></term>
	/// <term>
	/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
	/// HttpSendResponseEntityBody. The last call sending entity-body data then sets this flag to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA</c></term>
	/// <term>
	/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous I/O
	/// or by an application doing asynchronous I/O with no more than one outstanding send at a time. Applications that use asynchronous I/O
	/// and that may have more than one send outstanding at a time should not use this flag. When this flag is set, it should also be used
	/// consistently in calls to the HttpSendResponseEntityBody function. <c>Windows Server 2003:</c> This flag is not supported. This flag
	/// is new for Windows Server 2003 with SP1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING</c></term>
	/// <term>
	/// Enables the TCP nagling algorithm for this send only. <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES</c></term>
	/// <term>
	/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
	/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_OPAQUE</c></term>
	/// <term>
	/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
	/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
	/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
	/// <c>HttpSendHttpResponse</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used. <c>Windows
	/// 8 and later:</c> This flag is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HttpResponse">A pointer to an HTTP_RESPONSE structure that defines the HTTP response.</param>
	/// <param name="CachePolicy">
	/// <para>A pointer to the HTTP_CACHE_POLICY structure used to cache the response.</para>
	/// <para><c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="BytesSent">
	/// <para>Optional. A pointer to a variable that receives the number, in bytes, sent if the function operates synchronously.</para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesSent</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesSent</c> must contain a valid memory address and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Reserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="Reserved2">This parameter is reserved and must be zero.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until all response data specified in the <c>pHttpResponse</c> parameter is sent, whereas an asynchronous
	/// call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to
	/// determine when the operation is completed. For more information about using OVERLAPPED structures for synchronization, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <param name="LogData">
	/// <para>
	/// A pointer to the HTTP_LOG_DATA structure used to log the response. Pass a pointer to the HTTP_LOG_FIELDS_DATA structure and cast it
	/// to <c>PHTTP_LOG_DATA</c>.
	/// </para>
	/// <para>
	/// Be aware that even when logging is enabled on a URL Group, or server session, the response will not be logged unless the application
	/// supplies the log fields data structure.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// <para><c>Windows Vista and Windows Server 2008:</c> This parameter is new for Windows Vista, and Windows Server 2008</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HttpSendHttpResponse</c> function is used to create and send a response header, and the HttpSendResponseEntityBody function
	/// can be used to send entity-body data as required.
	/// </para>
	/// <para>
	/// If neither a content-length header nor a transfer-encoding header is included with the response, the application must indicate the
	/// end of the response by explicitly closing the connection by using the <c>HTTP_SEND_RESPONSE_DISCONNECT</c> flag.
	/// </para>
	/// <para>
	/// If an application specifies a "Server:" header in a response, using the <c>HttpHeaderServer</c> identifier in the HTTP_KNOWN_HEADER
	/// structure, that specified value is placed as the first part of the header, followed by a space and then "Microsoft-HTTPAPI/1.0". If
	/// no server header is specified, <c>HttpSendHttpResponse</c> supplies "Microsoft-HTTPAPI/1.0" as the server header.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>HttpSendHttpResponse</c> and HttpSendResponseEntityBody function must not be called simultaneously from different
	/// threads on the same <c>RequestId</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsendhttpresponse HTTPAPI_LINKAGE ULONG HttpSendHttpResponse( [in]
	// HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [in] PHTTP_RESPONSE HttpResponse, [in, optional]
	// PHTTP_CACHE_POLICY CachePolicy, [out] PULONG BytesSent, [in] PVOID Reserved1, [in] ULONG Reserved2, [in] LPOVERLAPPED Overlapped, [in,
	// optional] PHTTP_LOG_DATA LogData );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendHttpResponse")]
	public static extern Win32Error HttpSendHttpResponse([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_SEND_RESPONSE_FLAG Flags,
		in HTTP_RESPONSE_V2 HttpResponse, [In, Optional] IntPtr CachePolicy, out uint BytesSent, [In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2,
		[In, Optional] IntPtr Overlapped, [In, Optional] IntPtr LogData);

	/// <summary>The <c>HttpSendResponseEntityBody</c> function sends entity-body data associated with an HTTP response.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which the specified request was retrieved. A request queue is created and its handle returned by a
	/// call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// An identifier of the HTTP request to which this response corresponds. This value is returned in the <c>RequestId</c> member of the
	/// HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. It cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>A parameter that can include one of the following mutually exclusive flag values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_DISCONNECT</c></term>
	/// <term>
	/// The network connection should be disconnected after sending this response, overriding any persistent connection features associated
	/// with the version of HTTP in use. Applications should use this flag to indicate the end of the entity in cases where neither content
	/// length nor chunked encoding is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_MORE_DATA</c></term>
	/// <term>
	/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
	/// <c>HttpSendResponseEntityBody</c>. The last call then sets this flag to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA</c></term>
	/// <term>
	/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous I/O,
	/// or by a an application doing asynchronous I/O with no more than one send outstanding at a time. Applications using asynchronous I/O
	/// which may have more than one send outstanding at a time should not use this flag. When this flag is set, it should be used
	/// consistently in calls to the HttpSendHttpResponse function as well. <c>Windows Server 2003:</c> This flag is not supported. This flag
	/// is new for Windows Server 2003 with SP1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING</c></term>
	/// <term>Enables the TCP nagling algorithm for this send only. <c>Windows Vista and later:</c> This flag is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES</c></term>
	/// <term>
	/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
	/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_OPAQUE</c></term>
	/// <term>
	/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
	/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
	/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
	/// <c>HttpSendResponseEntityBody</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used.
	/// <c>Windows 8 and later:</c> This flag is supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Caution</c> Combining both flags in a single call to the HttpSendHttpResponse function produces undefined results.</para>
	/// </param>
	/// <param name="EntityChunkCount">
	/// A number of structures in the array pointed to by <c>pEntityChunks</c>. This count cannot exceed 9999.
	/// </param>
	/// <param name="EntityChunks">A pointer to an array of HTTP_DATA_CHUNK structures to be sent as entity-body data.</param>
	/// <param name="BytesSent">
	/// <para>Optional. A pointer to a variable that receives the number, in bytes, sent if the function operates synchronously.</para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesSent</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesSent</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Reserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="Reserved2">This parameter is reserved and must be zero.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until all response data specified in the <c>pEntityChunks</c> parameter is sent, whereas an asynchronous
	/// call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to
	/// determine when the operation is completed. For more information about using OVERLAPPED structures for synchronization, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <param name="LogData">
	/// <para>
	/// A pointer to the HTTP_LOG_DATA structure used to log the response. Pass a pointer to the HTTP_LOG_FIELDS_DATA structure and cast it
	/// to <c>PHTTP_LOG_DATA</c>.
	/// </para>
	/// <para>
	/// Be aware that even when logging is enabled on a URL Group, or server session, the response will not be logged unless the application
	/// supplies the log fields data structure.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// <para><c>Windows Vista and Windows Server 2008:</c> This parameter is new for Windows Vista, and Windows Server 2008</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_BAD_COMMAND</c></term>
	/// <term>There is a call pending to HttpSendHttpResponse or HttpSendResponseEntityBody having the same <c>RequestId</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If neither a Content-length header nor a Transfer-encoding header is included in the response headers, the application must indicate
	/// the end of the response by explicitly closing the connection using the <c>HTTP_SEND_RESPONSE_DISCONNECT</c> flag.
	/// </para>
	/// <para>
	/// <c>Note</c><c>HttpSendResponseEntityBody</c> (or HttpSendHttpResponse) and <c>HttpSendResponseEntityBody</c> must not be called
	/// simultaneously from different threads on the same <c>RequestId</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsendresponseentitybody HTTPAPI_LINKAGE ULONG
	// HttpSendResponseEntityBody( [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [in] USHORT
	// EntityChunkCount, [in] PHTTP_DATA_CHUNK EntityChunks, [out] PULONG BytesSent, [in] PVOID Reserved1, [in] ULONG Reserved2, [in]
	// LPOVERLAPPED Overlapped, [in, optional] PHTTP_LOG_DATA LogData );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendResponseEntityBody")]
	public static extern Win32Error HttpSendResponseEntityBody([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_SEND_RESPONSE_FLAG Flags,
		[In] ushort EntityChunkCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] HTTP_DATA_CHUNK[] EntityChunks, out uint BytesSent,
		[In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2, in NativeOverlapped Overlapped, in HTTP_LOG_DATA LogData);

	/// <summary>The <c>HttpSendResponseEntityBody</c> function sends entity-body data associated with an HTTP response.</summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue from which the specified request was retrieved. A request queue is created and its handle returned by a
	/// call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="RequestId">
	/// An identifier of the HTTP request to which this response corresponds. This value is returned in the <c>RequestId</c> member of the
	/// HTTP_REQUEST structure by a call to the HttpReceiveHttpRequest function. It cannot be <c>HTTP_NULL_ID</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>A parameter that can include one of the following mutually exclusive flag values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flags</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_DISCONNECT</c></term>
	/// <term>
	/// The network connection should be disconnected after sending this response, overriding any persistent connection features associated
	/// with the version of HTTP in use. Applications should use this flag to indicate the end of the entity in cases where neither content
	/// length nor chunked encoding is used.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_MORE_DATA</c></term>
	/// <term>
	/// Additional entity body data for this response is sent by the application through one or more subsequent calls to
	/// <c>HttpSendResponseEntityBody</c>. The last call then sets this flag to zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_BUFFER_DATA</c></term>
	/// <term>
	/// This flag enables buffering of data in the kernel on a per-response basis. It should be used by an application doing synchronous I/O,
	/// or by a an application doing asynchronous I/O with no more than one send outstanding at a time. Applications using asynchronous I/O
	/// which may have more than one send outstanding at a time should not use this flag. When this flag is set, it should be used
	/// consistently in calls to the HttpSendHttpResponse function as well. <c>Windows Server 2003:</c> This flag is not supported. This flag
	/// is new for Windows Server 2003 with SP1.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_ENABLE_NAGLING</c></term>
	/// <term>Enables the TCP nagling algorithm for this send only. <c>Windows Vista and later:</c> This flag is not supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_PROCESS_RANGES</c></term>
	/// <term>
	/// Specifies that for a range request, the full response content is passed and the caller wants the HTTP API to process ranges
	/// appropriately. Windows Server 2008 R2 and Windows 7 or later. <c>Note</c> This flag is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_SEND_RESPONSE_FLAG_OPAQUE</c></term>
	/// <term>
	/// Specifies that the request/response is not HTTP compliant and all subsequent bytes should be treated as entity-body. Applications
	/// specify this flag when it is accepting a Web Socket upgrade request and informing HTTP.sys to treat the connection data as opaque
	/// data. This flag is only allowed when the <c>StatusCode</c> member of <c>pHttpResponse</c> is <c>101</c>, switching protocols.
	/// <c>HttpSendResponseEntityBody</c> returns <c>ERROR_INVALID_PARAMETER</c> for all other HTTP response types if this flag is used.
	/// <c>Windows 8 and later:</c> This flag is supported.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Caution</c> Combining both flags in a single call to the HttpSendHttpResponse function produces undefined results.</para>
	/// </param>
	/// <param name="EntityChunkCount">
	/// A number of structures in the array pointed to by <c>pEntityChunks</c>. This count cannot exceed 9999.
	/// </param>
	/// <param name="EntityChunks">A pointer to an array of HTTP_DATA_CHUNK structures to be sent as entity-body data.</param>
	/// <param name="BytesSent">
	/// <para>Optional. A pointer to a variable that receives the number, in bytes, sent if the function operates synchronously.</para>
	/// <para>
	/// When making an asynchronous call using <c>pOverlapped</c>, set <c>pBytesSent</c> to <c>NULL</c>. Otherwise, when <c>pOverlapped</c>
	/// is set to <c>NULL</c>, <c>pBytesSent</c> must contain a valid memory address, and not be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="Reserved1">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <param name="Reserved2">This parameter is reserved and must be zero.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until all response data specified in the <c>pEntityChunks</c> parameter is sent, whereas an asynchronous
	/// call immediately returns <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to
	/// determine when the operation is completed. For more information about using OVERLAPPED structures for synchronization, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <param name="LogData">
	/// <para>
	/// A pointer to the HTTP_LOG_DATA structure used to log the response. Pass a pointer to the HTTP_LOG_FIELDS_DATA structure and cast it
	/// to <c>PHTTP_LOG_DATA</c>.
	/// </para>
	/// <para>
	/// Be aware that even when logging is enabled on a URL Group, or server session, the response will not be logged unless the application
	/// supplies the log fields data structure.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP with SP2:</c> This parameter is reserved and must be <c>NULL</c>.</para>
	/// <para><c>Windows Vista and Windows Server 2008:</c> This parameter is new for Windows Vista, and Windows Server 2008</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of <c>ERROR_IO_PENDING</c> indicates that the next request is not yet ready
	/// and is retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_BAD_COMMAND</c></term>
	/// <term>There is a call pending to HttpSendHttpResponse or HttpSendResponseEntityBody having the same <c>RequestId</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If neither a Content-length header nor a Transfer-encoding header is included in the response headers, the application must indicate
	/// the end of the response by explicitly closing the connection using the <c>HTTP_SEND_RESPONSE_DISCONNECT</c> flag.
	/// </para>
	/// <para>
	/// <c>Note</c><c>HttpSendResponseEntityBody</c> (or HttpSendHttpResponse) and <c>HttpSendResponseEntityBody</c> must not be called
	/// simultaneously from different threads on the same <c>RequestId</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsendresponseentitybody HTTPAPI_LINKAGE ULONG
	// HttpSendResponseEntityBody( [in] HANDLE RequestQueueHandle, [in] HTTP_REQUEST_ID RequestId, [in] ULONG Flags, [in] USHORT
	// EntityChunkCount, [in] PHTTP_DATA_CHUNK EntityChunks, [out] PULONG BytesSent, [in] PVOID Reserved1, [in] ULONG Reserved2, [in]
	// LPOVERLAPPED Overlapped, [in, optional] PHTTP_LOG_DATA LogData );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSendResponseEntityBody")]
	public static extern Win32Error HttpSendResponseEntityBody([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_REQUEST_ID RequestId, [In] HTTP_SEND_RESPONSE_FLAG Flags,
		[In] ushort EntityChunkCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] HTTP_DATA_CHUNK[] EntityChunks, out uint BytesSent,
		[In, Optional] IntPtr Reserved1, [In, Optional] uint Reserved2, [In, Optional] IntPtr Overlapped, [In, Optional] IntPtr LogData);

	/// <summary>The <c>HttpSetRequestProperty</c> function sets a new property or modifies an existing property on the specified request.</summary>
	/// <param name="RequestQueueHandle">
	/// The handle to the request queue on which the request was received. A request queue is created and its handle returned by a call to
	/// the HttpCreateRequestQueue function.
	/// </param>
	/// <param name="Id">
	/// The opaque ID of the request. This ID is located in the RequestId member of the HTTP_REQUEST structure returned by HttpReceiveHttpRequest.
	/// </param>
	/// <param name="PropertyId">
	/// <para>A member of the HTTP_REQUEST_PROPERTY enumeration describing the property type that is set. This must be one of the following:</para>
	/// <para>| <c>Property</c> | <c>Meaning</c> | | HttpRequestPropertyStreamError | Sets a stream error on the request. |</para>
	/// </param>
	/// <param name="Input">
	/// <para>A pointer to the buffer that contains the property information.</para>
	/// <para>It must point to one of the following property information types based on the property that is set.</para>
	/// <para>
	/// | <c>Property</c> | <c>Configuration Type</c> | | HttpRequestPropertyStreamError | HTTP_REQUEST_PROPERTY_STREAM_ERROR structure |
	/// </para>
	/// </param>
	/// <param name="InputPropertySize">The length, in bytes, of the buffer pointed to by the Input parameter.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set pOverlapped to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the operation is complete, whereas an asynchronous call immediately returns <c>ERROR_IO_PENDING</c>
	/// and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns a system error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsetrequestproperty HTTPAPI_LINKAGE ULONG HttpSetRequestProperty(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_OPAQUE_ID Id, [in] HTTP_REQUEST_PROPERTY PropertyId, [in] PVOID Input, [in] ULONG
	// InputPropertySize, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetRequestProperty")]
	public static extern Win32Error HttpSetRequestProperty([In] HREQQUEUE RequestQueueHandle, [In] HTTP_OPAQUE_ID Id, [In] HTTP_REQUEST_PROPERTY PropertyId,
		[In] IntPtr Input, [In] uint InputPropertySize, in NativeOverlapped Overlapped);

	/// <summary>The <c>HttpSetRequestProperty</c> function sets a new property or modifies an existing property on the specified request.</summary>
	/// <param name="RequestQueueHandle">
	/// The handle to the request queue on which the request was received. A request queue is created and its handle returned by a call to
	/// the HttpCreateRequestQueue function.
	/// </param>
	/// <param name="Id">
	/// The opaque ID of the request. This ID is located in the RequestId member of the HTTP_REQUEST structure returned by HttpReceiveHttpRequest.
	/// </param>
	/// <param name="PropertyId">
	/// <para>A member of the HTTP_REQUEST_PROPERTY enumeration describing the property type that is set. This must be one of the following:</para>
	/// <para>| <c>Property</c> | <c>Meaning</c> | | HttpRequestPropertyStreamError | Sets a stream error on the request. |</para>
	/// </param>
	/// <param name="Input">
	/// <para>A pointer to the buffer that contains the property information.</para>
	/// <para>It must point to one of the following property information types based on the property that is set.</para>
	/// <para>
	/// | <c>Property</c> | <c>Configuration Type</c> | | HttpRequestPropertyStreamError | HTTP_REQUEST_PROPERTY_STREAM_ERROR structure |
	/// </para>
	/// </param>
	/// <param name="InputPropertySize">The length, in bytes, of the buffer pointed to by the Input parameter.</param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set pOverlapped to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the operation is complete, whereas an asynchronous call immediately returns <c>ERROR_IO_PENDING</c>
	/// and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// more information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns a system error code.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsetrequestproperty HTTPAPI_LINKAGE ULONG HttpSetRequestProperty(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_OPAQUE_ID Id, [in] HTTP_REQUEST_PROPERTY PropertyId, [in] PVOID Input, [in] ULONG
	// InputPropertySize, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetRequestProperty")]
	public static extern Win32Error HttpSetRequestProperty([In] HREQQUEUE RequestQueueHandle, [In] HTTP_OPAQUE_ID Id, [In] HTTP_REQUEST_PROPERTY PropertyId,
		[In] IntPtr Input, [In] uint InputPropertySize, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpSetRequestQueueProperty</c> function sets a new property or modifies an existing property on the request queue identified
	/// by the specified handle.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// The handle to the request queue on which the property is set. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </param>
	/// <param name="Property">
	/// <para>A member of the HTTP_SERVER_PROPERTY enumeration describing the property type that is set. This must be one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServer503VerbosityProperty</c></term>
	/// <term>Modifies or sets the current verbosity level of 503 responses generated for the request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerQueueLengthProperty</c></term>
	/// <term>Modifies or sets the limit on the number of outstanding requests in the request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerStateProperty</c></term>
	/// <term>Modifies or sets the state of the request queue. The state must be either active or inactive.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>A pointer to the buffer that contains the property information.</para>
	/// <para>pPropertyInformation</para>
	/// <para>points to one of the following property information types based on the property that is set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Configuration Type</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_ENABLED_STATE enumeration</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQueueLengthProperty</term>
	/// <term>ULONG</term>
	/// </item>
	/// <item>
	/// <term>HttpServer503VerbosityProperty</term>
	/// <term>HTTP_503_RESPONSE_VERBOSITY enumeration</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformationLength">The length, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter.</param>
	/// <param name="Reserved1">Reserved. Must be zero.</param>
	/// <param name="Reserved2">Reserved. Must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The <c>Reserved</c> parameter is not zero or the <c>pReserved</c> parameter is not <c>NULL</c>. The property type specified in the
	/// <c>Property</c> parameter is not supported for request queues. The <c>pPropertyInformation</c> parameter is <c>NULL</c>. The
	/// <c>PropertyInformationLength</c> parameter is zero. The application does not have permission to set properties on the request queue.
	/// Only the application that created the request queue can set the properties.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The handle to the request queue is an HTTP version 1.0 handle. Property management is only supported on HTTP version 2.0 or later
	/// request queues.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsetrequestqueueproperty HTTPAPI_LINKAGE ULONG
	// HttpSetRequestQueueProperty( [in] HANDLE RequestQueueHandle, [in] HTTP_SERVER_PROPERTY Property, [in] PVOID PropertyInformation, [in]
	// ULONG PropertyInformationLength, [in] ULONG Reserved1, [in] PVOID Reserved2 );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetRequestQueueProperty")]
	public static extern Win32Error HttpSetRequestQueueProperty([In] HREQQUEUE RequestQueueHandle, [In] HTTP_SERVER_PROPERTY Property,
		[In] IntPtr PropertyInformation, [In] uint PropertyInformationLength, [In, Optional] uint Reserved1, [In, Optional] IntPtr Reserved2);

	/// <summary>
	/// The <c>HttpSetRequestQueueProperty</c> function sets a new property or modifies an existing property on the request queue identified
	/// by the specified handle.
	/// </summary>
	/// <typeparam name="T">The type of the value being set.</typeparam>
	/// <param name="RequestQueueHandle">
	/// The handle to the request queue on which the property is set. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>The property information.</para>
	/// <para>pPropertyInformation is one of the following property information types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Configuration Type</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_ENABLED_STATE enumeration</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQueueLengthProperty</term>
	/// <term>ULONG</term>
	/// </item>
	/// <item>
	/// <term>HttpServer503VerbosityProperty</term>
	/// <term>HTTP_503_RESPONSE_VERBOSITY enumeration</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The <c>Reserved</c> parameter is not zero or the <c>pReserved</c> parameter is not <c>NULL</c>. The property type specified in the
	/// <c>Property</c> parameter is not supported for request queues. The <c>pPropertyInformation</c> parameter is <c>NULL</c>. The
	/// <c>PropertyInformationLength</c> parameter is zero. The application does not have permission to set properties on the request queue.
	/// Only the application that created the request queue can set the properties.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c></term>
	/// <term>
	/// The handle to the request queue is an HTTP version 1.0 handle. Property management is only supported on HTTP version 2.0 or later
	/// request queues.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <exception cref="System.ArgumentOutOfRangeException">PropertyInformation</exception>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetRequestQueueProperty")]
	public static Win32Error HttpSetRequestQueueProperty<T>([In] HREQQUEUE RequestQueueHandle, T PropertyInformation) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanSet<T, HTTP_SERVER_PROPERTY>(out var Property))
			throw new ArgumentOutOfRangeException(nameof(PropertyInformation));
		using SafeCoTaskMemStruct<T> mem = new(PropertyInformation);
		return HttpSetRequestQueueProperty(RequestQueueHandle, Property, mem, mem.Size);
	}

	/// <summary>
	/// The <c>HttpSetServerSessionProperty</c> function sets a new server session property or modifies an existing property on the specified
	/// server session.
	/// </summary>
	/// <param name="ServerSessionId">The server session for which the property is set.</param>
	/// <param name="Property">
	/// <para>A member of the HTTP_SERVER_PROPERTY enumeration that describes the property type that is set. This can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServerStateProperty</c></term>
	/// <term>Modifies or sets the state of the server session. The state can be either enabled or disabled; the default state is enabled.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerTimeoutsProperty</c></term>
	/// <term>Modifies or sets the server session connection timeout limits.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerQosProperty</c></term>
	/// <term>Modifies or sets the bandwidth throttling for the server session. By default, the HTTP Server API does not limit bandwidth.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerLoggingProperty</c></term>
	/// <term>
	/// Enables or disables logging for the server session. This property sets only centralized W3C and centralized binary logging. By
	/// default, logging is not enabled.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerAuthenticationProperty</c></term>
	/// <term>Enables kernel mode server side authentication for the Basic, NTLM, Negotiate, and Digest authentication schemes.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerExtendedAuthenticationProperty</c></term>
	/// <term>Enables kernel mode server side authentication for the Kerberos authentication scheme.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerChannelBindProperty</c></term>
	/// <term>Enables server side authentication that uses a channel binding token (CBT).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>A pointer to the buffer that contains the property data.</para>
	/// <para>pPropertyInformation</para>
	/// <para>points to a property data structure, listed in the following table, based on the property that is set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_STATE_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerLoggingProperty</term>
	/// <term>HTTP_LOGGING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQosProperty</term>
	/// <term>HTTP_QOS_SETTING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerTimeoutsProperty</term>
	/// <term>HTTP_TIMEOUT_LIMIT_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerExtendedAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerChannelBindProperty</term>
	/// <term>HTTP_CHANNEL_BIND_INFO</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformationLength">The length, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The property type specified in the <c>Property</c> parameter is not supported for server sessions. The <c>pPropertyInformation</c>
	/// parameter is <c>NULL</c>. The <c>PropertyInformationLength</c> parameter is zero. The <c>ServerSessionId</c> parameter does not
	/// contain a valid server session. The application does not have permission to set the server session properties. Only the application
	/// that created the server session can set the properties.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Server sessions are top level configuration containers for configuration data that applies to all of the URL groups created under
	/// them. The server session is created with HttpCreateServerSession.
	/// </para>
	/// <para>
	/// The <c>pPropertyInformation</c> parameter points to the configuration structure for the property type that is set. The
	/// <c>PropertyInformationLength</c> parameter specifies the size, in bytes, of the configuration structure. For example, when setting
	/// the <c>HttpServerTimeoutsProperty</c> the <c>pPropertyInformation</c> parameter must point to a buffer that is at least equal to the
	/// size of the HTTP_TIMEOUT_LIMIT_INFO structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsetserversessionproperty HTTPAPI_LINKAGE ULONG
	// HttpSetServerSessionProperty( [in] HTTP_SERVER_SESSION_ID ServerSessionId, [in] HTTP_SERVER_PROPERTY Property, [in] PVOID
	// PropertyInformation, [in] ULONG PropertyInformationLength );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetServerSessionProperty")]
	public static extern Win32Error HttpSetServerSessionProperty([In] HTTP_SERVER_SESSION_ID ServerSessionId, [In] HTTP_SERVER_PROPERTY Property,
		[In] IntPtr PropertyInformation, [In] uint PropertyInformationLength);

	/// <summary>
	/// The <c>HttpSetServerSessionProperty</c> function sets a new server session property or modifies an existing property on the specified
	/// server session.
	/// </summary>
	/// <typeparam name="T">The type of <paramref name="PropertyInformation"/>.</typeparam>
	/// <param name="ServerSessionId">The server session for which the property is set.</param>
	/// <param name="PropertyInformation">
	/// <para>The property data.</para>
	/// <para>pPropertyInformation is a property data structure, listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_STATE_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerLoggingProperty</term>
	/// <term>HTTP_LOGGING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQosProperty</term>
	/// <term>HTTP_QOS_SETTING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerTimeoutsProperty</term>
	/// <term>HTTP_TIMEOUT_LIMIT_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerExtendedAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerChannelBindProperty</term>
	/// <term>HTTP_CHANNEL_BIND_INFO</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The property type specified in the <c>Property</c> parameter is not supported for server sessions. The <c>pPropertyInformation</c>
	/// parameter is <c>NULL</c>. The <c>PropertyInformationLength</c> parameter is zero. The <c>ServerSessionId</c> parameter does not
	/// contain a valid server session. The application does not have permission to set the server session properties. Only the application
	/// that created the server session can set the properties.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <exception cref="System.ArgumentOutOfRangeException">PropertyInformation</exception>
	/// <remarks>
	/// <para>
	/// Server sessions are top level configuration containers for configuration data that applies to all of the URL groups created under
	/// them. The server session is created with HttpCreateServerSession.
	/// </para>
	/// <para>
	/// The <c>pPropertyInformation</c> parameter points to the configuration structure for the property type that is set. The
	/// <c>PropertyInformationLength</c> parameter specifies the size, in bytes, of the configuration structure. For example, when setting
	/// the <c>HttpServerTimeoutsProperty</c> the <c>pPropertyInformation</c> parameter must point to a buffer that is at least equal to the
	/// size of the HTTP_TIMEOUT_LIMIT_INFO structure.
	/// </para>
	/// </remarks>
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetServerSessionProperty")]
	public static Win32Error HttpSetServerSessionProperty<T>([In] HTTP_SERVER_SESSION_ID ServerSessionId, T PropertyInformation) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanSet<T, HTTP_SERVER_PROPERTY>(out var Property))
			throw new ArgumentOutOfRangeException(nameof(PropertyInformation));
		using SafeCoTaskMemStruct<T> mem = new(PropertyInformation);
		return HttpSetServerSessionProperty(ServerSessionId, Property, mem, mem.Size);
	}

	/// <summary>
	/// The <c>HttpSetServiceConfiguration</c> function creates and sets a configuration record for the HTTP Server API configuration store.
	/// The call fails if the specified record already exists. To change a given configuration record, delete it and then recreate it with a
	/// different value.
	/// </summary>
	/// <param name="ServiceHandle">Reserved. Must be zero.</param>
	/// <param name="ConfigId">
	/// <para>Type of configuration record to be set. This parameter can be one of the following values from the HTTP_SERVICE_CONFIG_ID enumeration.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>Sets a record in the IP Listen List.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>Sets a specified SSL certificate record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>Sets a URL reservation record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeout</c></term>
	/// <term>Sets a specified HTTP Server API wide connection time-out. <c>Windows Vista and later:</c> This enumeration value is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>
	/// Sets a specified SSL Server Name Indication (SNI) certificate record. <c>Windows 8 and later:</c> This enumeration value is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c><c>HttpServiceConfigSslCcsCertInfo</c></c></term>
	/// <term>
	/// Sets the SSL certificate record that specifies that Http.sys should consult the Centralized Certificate Store (CCS) store to find
	/// certificates if the port receives a Transport Layer Security (TLS) handshake. The port is specified by the <c>KeyDesc</c> member of
	/// the HTTP_SERVICE_CONFIG_SSL_CCS_SET structure that you pass to the <c>pConfigInformation</c> parameter. <c>Windows 8 and later:</c>
	/// This enumeration value is supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pConfigInformation">
	/// <para>A pointer to a buffer that contains the appropriate data to specify the type of record to be set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigIPListenList</c></term>
	/// <term>HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigUrlAclInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_URLACL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigTimeout</c></term>
	/// <term>HTTP_SERVICE_CONFIG_TIMEOUT_SET structure. <c>Windows Vista and later:</c> This structure is supported.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>
	/// HTTP_SERVICE_CONFIG_SSL_SNI_SET structure. The hostname will be "*" when the SSL central certificate store is queried and wildcard
	/// bindings are used, and a host name for regular SNI. <c>Windows 8 and later:</c> This structure is supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c><c>HttpServiceConfigSslCcsCertInfo</c></c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_CCS_SET structure. <c>Windows 8 and later:</c> This structure is supported.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ConfigInformationLength">Size, in bytes, of the <c>pConfigInformation</c> buffer.</param>
	/// <param name="pOverlapped">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>The specified record already exists, and must be deleted in order for its value to be re-set.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer size specified in the <c>ConfigInformationLength</c> parameter is insufficient.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>ServiceHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SUCH_LOGON_SESSION</c></term>
	/// <term>The SSL Certificate used is invalid. This can occur only if the <c>HttpServiceConfigSSLCertInfo</c> parameter is used.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The configuration parameters set with <c>HttpSetServiceConfiguration</c> are applied to all the HTTP Server API applications on the
	/// machine, and persist when the HTTP Server API shuts down, or when the computer is restarted.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpsetserviceconfiguration HTTPAPI_LINKAGE ULONG
	// HttpSetServiceConfiguration( [in] HANDLE ServiceHandle, [in] HTTP_SERVICE_CONFIG_ID ConfigId, [in] PVOID pConfigInformation, [in]
	// ULONG ConfigInformationLength, [in] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetServiceConfiguration")]
	public static extern Win32Error HttpSetServiceConfiguration([In, Optional] HANDLE ServiceHandle, [In] HTTP_SERVICE_CONFIG_ID ConfigId,
		[In] IntPtr pConfigInformation, [In] uint ConfigInformationLength, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// The <c>HttpSetUrlGroupProperty</c> function sets a new property or modifies an existing property on the specified URL Group.
	/// </summary>
	/// <param name="UrlGroupId">The ID of the URL Group for which the property is set.</param>
	/// <param name="Property">
	/// <para>
	/// A member of the HTTP_SERVER_PROPERTY enumeration that describes the property type that is modified or set. This can be one of the following:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServerAuthenticationProperty</c></term>
	/// <term>Enables server-side authentication for the URL Group using the Basic, NTLM, Negotiate, and Digest authentication schemes.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerExtendedAuthenticationProperty</c></term>
	/// <term>Enables server-side authentication for the URL Group using the Kerberos authentication scheme.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerQosProperty</c></term>
	/// <term>
	/// This value maps to the generic HTTP_QOS_SETTING_INFO structure with <c>QosType</c> set to either <c>HttpQosSettingTypeBandwidth</c>
	/// or <c>HttpQosSettingTypeConnectionLimit</c>. If <c>HttpQosSettingTypeBandwidth</c>, modifies or sets the bandwidth throttling for the
	/// URL Group. If <c>HttpQosSettingTypeConnectionLimit</c>, modifies or sets the maximum number of outstanding connections served for a
	/// URL Group at any time.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerBindingProperty</c></term>
	/// <term>Modifies or sets the URL Group association with a request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerLoggingProperty</c></term>
	/// <term>Modifies or sets logging for the URL Group.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerStateProperty</c></term>
	/// <term>Modifies or sets the state of the URL Group. The state can be either enabled or disabled.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerTimeoutsProperty</c></term>
	/// <term>Modifies or sets the connection timeout limits for the URL Group.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServerChannelBindProperty</c></term>
	/// <term>Enables server side authentication that uses a channel binding token (CBT).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformation">
	/// <para>A pointer to the buffer that contains the property information.</para>
	/// <para>pPropertyInformation</para>
	/// <para>points to one of the following property information structures based on the property that is set.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Structure</term>
	/// </listheader>
	/// <item>
	/// <term>HttpServerAuthenticatonProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerExtendedAuthenticationProperty</term>
	/// <term>HTTP_SERVER_AUTHENTICATION_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerQosProperty</term>
	/// <term>HTTP_QOS_SETTING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerBindingProperty</term>
	/// <term>HTTP_BINDING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerLoggingProperty</term>
	/// <term>HTTP_LOGGING_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerStateProperty</term>
	/// <term>HTTP_STATE_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerTimeoutsProperty</term>
	/// <term>HTTP_TIMEOUT_LIMIT_INFO</term>
	/// </item>
	/// <item>
	/// <term>HttpServerChannelBindProperty</term>
	/// <term>HTTP_CHANNEL_BIND_INFO</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="PropertyInformationLength">The length, in bytes, of the buffer pointed to by the <c>pPropertyInformation</c> parameter.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The property type specified in the <c>Property</c> parameter is not supported for URL Groups. The <c>pPropertyInformation</c>
	/// parameter is <c>NULL</c>. The <c>PropertyInformationLength</c> parameter is zero. The <c>UrlGroupId</c> parameter does not contain a
	/// valid server session. The application does not have permission to set the URL Group properties. Only the application that created the
	/// URL Group can set the properties.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// After the URL Group is created it must be associated with a request queue to receive requests. To associate the URL Group with a
	/// request queue, the application calls <c>HttpSetUrlGroupProperty</c> with the <c>HttpServerBindingProperty</c> property. If this
	/// property is not set, matching requests for the URL Group are not delivered to a request queue and the HTTP Server API generates a 503 response.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpseturlgroupproperty HTTPAPI_LINKAGE ULONG HttpSetUrlGroupProperty(
	// [in] HTTP_URL_GROUP_ID UrlGroupId, [in] HTTP_SERVER_PROPERTY Property, [in] PVOID PropertyInformation, [in] ULONG
	// PropertyInformationLength );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpSetUrlGroupProperty")]
	public static extern Win32Error HttpSetUrlGroupProperty([In] HTTP_URL_GROUP_ID UrlGroupId, [In] HTTP_SERVER_PROPERTY Property,
		[In] IntPtr PropertyInformation, [In] uint PropertyInformationLength);

	/// <summary>
	/// The <c>HttpShutdownRequestQueue</c> function stops queuing requests for the specified request queue process. Outstanding calls to
	/// HttpReceiveHttpRequest are canceled.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// The handle to the request queue that is shut down. A request queue is created and its handle returned by a call to the
	/// HttpCreateRequestQueue function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c></para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>
	/// The <c>ReqQueueHandle</c> parameter does not contain a valid request queue. The application does not have permission to shut down the
	/// request queue.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>HttpShutdownRequestQueue</c> cancels outstanding requests and stops all processing on the request queue process. The following
	/// steps are performed when this function is called:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>The request queue process is marked for cleanup and no new requests are routed to the request queue process.</term>
	/// </item>
	/// <item>
	/// <term>If the calling process is a controller, outstanding HttpWaitForDemandStart calls are canceled.</term>
	/// </item>
	/// <item>
	/// <term>Pending HttpReceiveHttpRequest calls from the calling process are canceled.</term>
	/// </item>
	/// <item>
	/// <term>Requests that are already bound to the calling process are canceled.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The unreceived pending requests that are queued to the request queue process rerouted to another request queue process. If no other
	/// request queue process is available, the pending requests are saved until the request queue is closed, or another non-controller
	/// request queue process launches.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Pending HttpWaitForDisconnect calls initiated by the calling process are canceled.</term>
	/// </item>
	/// <item>
	/// <term>Outstanding responses indicated by the calling process are not affected, they are properly completed.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Be aware that if the request queue handle is shared by multiple processes, <c>HttpShutdownRequestQueue</c> limits cleanup to the
	/// calling process. Other processes currently working on the request queue are not affected.
	/// </para>
	/// <para>
	/// <c>HttpShutdownRequestQueue</c> can be used by applications to recycle request queue processes. For this purpose,
	/// <c>HttpShutdownRequestQueue</c> is called prior to terminating a process that shares the request queue with other processes. After
	/// <c>HttpShutdownRequestQueue</c> returns, the process can be safely terminated or recycled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpshutdownrequestqueue HTTPAPI_LINKAGE ULONG
	// HttpShutdownRequestQueue( [in] HANDLE RequestQueueHandle );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpShutdownRequestQueue")]
	public static extern Win32Error HttpShutdownRequestQueue([In] HREQQUEUE RequestQueueHandle);

	/// <summary>
	/// The <c>HttpTerminate</c> function cleans up resources used by the HTTP Server API to process calls by an application. An application
	/// should call <c>HttpTerminate</c> once for every time it called HttpInitialize, with matching flag settings.
	/// </summary>
	/// <param name="Flags">
	/// <para>Termination options. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HTTP_INITIALIZE_CONFIG</c></term>
	/// <term>Release all resources used by applications that modify the HTTP configuration.</term>
	/// </item>
	/// <item>
	/// <term><c>HTTP_INITIALIZE_SERVER</c></term>
	/// <term>Release all resources used by server applications.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReserved">This parameter is reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Every call to HttpInitialize should be matched by a corresponding call to <c>HttpTerminate</c>. For example, if you call
	/// <c>HttpInitialize</c> with HTTP_INITIALIZE_SERVER, you must call <c>HttpTerminate</c> with HTTP_INITIALIZE_SERVER. If you call
	/// <c>HttpInitialize</c> twice, once with HTTP_INITIALIZE_SERVER and the second time with HTTP_INITIALIZE_CONFIG, you can call
	/// <c>HttpTerminate</c> one time with both flags.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpterminate HTTPAPI_LINKAGE ULONG HttpTerminate( [in] ULONG Flags,
	// [in, out] PVOID pReserved );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpTerminate")]
	public static extern Win32Error HttpTerminate(HTTP_INIT Flags, IntPtr pReserved = default);

	/// <summary>
	/// Updates atomically a service configuration parameter that specifies a Transport Layer Security (TLS) certificate in a configuration
	/// record within the HTTP Server API configuration store.
	/// </summary>
	/// <param name="Handle">Reserved and must be <c>NULL</c>.</param>
	/// <param name="ConfigId">
	/// <para>
	/// The type of configuration record to update. This parameter can be one of the following values from the HTTP_SERVICE_CONFIG_ID enumeration.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>Updates a specified SSL certificate record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>Updates a specified SSL Server Name Indication (SNI) certificate record.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslCcsCertInfo</c></term>
	/// <term>
	/// Updates the SSL certificate record that specifies that Http.sys should consult the Centralized Certificate Store (CCS) store to find
	/// certificates if the port receives a TLS handshake. The port is specified by the <c>KeyDesc</c> member of the
	/// HTTP_SERVICE_CONFIG_SSL_CCS_SET structure that you pass to the <c>pConfigInfo</c> parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ConfigInfo">
	/// <para>
	/// A pointer to a buffer that contains the appropriate data to specify the type of record to update. The following table shows the type
	/// of data the buffer contains for the different possible values of the <c>ConfigId</c> parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term><c>ConfigId</c> value</term>
	/// <term>Type of data in the <c>pConfigInfo</c> buffer</term>
	/// </listheader>
	/// <item>
	/// <term><c>HttpServiceConfigSSLCertInfo</c></term>
	/// <term>HTTP_SERVICE_CONFIG_SSL_SET structure.</term>
	/// </item>
	/// <item>
	/// <term><c>HttpServiceConfigSslSniCertInfo</c></term>
	/// <term>
	/// HTTP_SERVICE_CONFIG_SSL_SNI_SET structure. The hostname will be "*" when the SSL central certificate store is queried and wildcard
	/// bindings are used, and a host name for regular SNI.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c><c>HttpServiceConfigSslCcsCertInfo</c></c></term>
	/// <term>
	/// HTTP_SERVICE_CONFIG_SSL_CCS_SET structure. This structure is used to add the CCS store on the specified port, as well as to delete,
	/// retrieve, or update an existing SSL CCS record.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ConfigInfoLength">The size, in bytes, of the <c>ConfigInfo</c> buffer.</param>
	/// <param name="Overlapped">Reserved and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_FILE_NOT_FOUND</c></term>
	/// <term>The specified record does not exist.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INSUFFICIENT_BUFFER</c></term>
	/// <term>The buffer size specified in the <c>ConfigInfoLength</c> parameter is insufficient.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The <c>ServiceHandle</c> parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_SUCH_LOGON_SESSION</c></term>
	/// <term>The SSL Certificate used is invalid. This can occur only if the <c>HttpServiceConfigSSLCertInfo</c> parameter is used.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The configuration parameters that you update with <c>HttpUpdateServiceConfiguration</c> are applied to all the HTTP Server API
	/// applications on the machine, and persist when the HTTP Server API shuts down, or when the computer is restarted.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpupdateserviceconfiguration HTTPAPI_LINKAGE ULONG
	// HttpUpdateServiceConfiguration( [in] HANDLE Handle, [in] HTTP_SERVICE_CONFIG_ID ConfigId, [in] PVOID ConfigInfo, [in] ULONG
	// ConfigInfoLength, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpUpdateServiceConfiguration")]
	public static extern Win32Error HttpUpdateServiceConfiguration([In, Optional] HANDLE Handle, [In] HTTP_SERVICE_CONFIG_ID ConfigId,
		[In] IntPtr ConfigInfo, [In] uint ConfigInfoLength, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpWaitForDemandStart</c> function waits for the arrival of a new request that can be served by a new request queue process.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// A handle to the request queue on which demand start is registered. A request queue is created and its handle returned by a call to
	/// the HttpCreateRequestQueue function.
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until a request has arrived in the specified queue, whereas an asynchronous call immediately returns
	/// <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the
	/// operation is completed. For more information about using OVERLAPPED structures for synchronization, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>ReqQueueHandle</c> parameter does not contain a valid request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_ID_AUTHORITY</c></term>
	/// <term>The calling process is not the controller process for this request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The calling process has already initiated a shutdown on the request queue or has closed the request queue handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>A demand start registration already exists for the request queue.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only the controller process can call <c>HttpWaitForDemandStart</c> to register a demand start notification. The controller process is
	/// the process that created the request queue and indicated that it is a controller process by passing the
	/// <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_CONTROLLER</c> flag. If a process other than the controlling process calls
	/// <c>HttpWaitForDemandStart</c>, the HTTP Server API returns <c>ERROR_INVALID_ID_AUTHORITY</c>.
	/// </para>
	/// <para>
	/// <c>HttpWaitForDemandStart</c> completes when a new request arrives for the specified request queue. At this time, a controller
	/// process can use this API to start a new worker process to server pending requests. Delayed start of the worker process allows
	/// applications to avoid consuming resources until they are required.
	/// </para>
	/// <para>
	/// The HTTP Server API allows only one outstanding notification registered on a request queue at any time. The HTTP Server API does not
	/// enforce limitations on the number of times that <c>HttpWaitForDemandStart</c> can be called on the same request queue consecutively.
	/// There is no limit on the number of outstanding processes that are working on the same request queue.
	/// </para>
	/// <para>
	/// The HTTP Server API supports canceling asynchronous <c>HttpWaitForDemandStart</c> calls. Applications can use CancelIoEx with the
	/// overlapped structure supplied in the <c>pOverlapped</c> parameter, to cancel an outstanding <c>HttpWaitForDemandStart</c> call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpwaitfordemandstart HTTPAPI_LINKAGE ULONG HttpWaitForDemandStart(
	// [in] HANDLE RequestQueueHandle, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpWaitForDemandStart")]
	public static extern Win32Error HttpWaitForDemandStart([In] HREQQUEUE RequestQueueHandle, in NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>HttpWaitForDemandStart</c> function waits for the arrival of a new request that can be served by a new request queue process.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// A handle to the request queue on which demand start is registered. A request queue is created and its handle returned by a call to
	/// the HttpCreateRequestQueue function.
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until a request has arrived in the specified queue, whereas an asynchronous call immediately returns
	/// <c>ERROR_IO_PENDING</c> and the calling application then uses GetOverlappedResult or I/O completion ports to determine when the
	/// operation is completed. For more information about using OVERLAPPED structures for synchronization, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, it returns one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>The <c>ReqQueueHandle</c> parameter does not contain a valid request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_ID_AUTHORITY</c></term>
	/// <term>The calling process is not the controller process for this request queue.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>The calling process has already initiated a shutdown on the request queue or has closed the request queue handle.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_ALREADY_EXISTS</c></term>
	/// <term>A demand start registration already exists for the request queue.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only the controller process can call <c>HttpWaitForDemandStart</c> to register a demand start notification. The controller process is
	/// the process that created the request queue and indicated that it is a controller process by passing the
	/// <c>HTTP_CREATE_REQUEST_QUEUE_FLAG_CONTROLLER</c> flag. If a process other than the controlling process calls
	/// <c>HttpWaitForDemandStart</c>, the HTTP Server API returns <c>ERROR_INVALID_ID_AUTHORITY</c>.
	/// </para>
	/// <para>
	/// <c>HttpWaitForDemandStart</c> completes when a new request arrives for the specified request queue. At this time, a controller
	/// process can use this API to start a new worker process to server pending requests. Delayed start of the worker process allows
	/// applications to avoid consuming resources until they are required.
	/// </para>
	/// <para>
	/// The HTTP Server API allows only one outstanding notification registered on a request queue at any time. The HTTP Server API does not
	/// enforce limitations on the number of times that <c>HttpWaitForDemandStart</c> can be called on the same request queue consecutively.
	/// There is no limit on the number of outstanding processes that are working on the same request queue.
	/// </para>
	/// <para>
	/// The HTTP Server API supports canceling asynchronous <c>HttpWaitForDemandStart</c> calls. Applications can use CancelIoEx with the
	/// overlapped structure supplied in the <c>pOverlapped</c> parameter, to cancel an outstanding <c>HttpWaitForDemandStart</c> call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpwaitfordemandstart HTTPAPI_LINKAGE ULONG HttpWaitForDemandStart(
	// [in] HANDLE RequestQueueHandle, [in, optional] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpWaitForDemandStart")]
	public static extern Win32Error HttpWaitForDemandStart([In] HREQQUEUE RequestQueueHandle, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpWaitForDisconnect</c> function notifies the application when the connection to an HTTP client is broken for any reason.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue that handles requests from the specified connection. A request queue is created and its handle returned
	/// by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="ConnectionId">
	/// Identifier for the connection to the client computer. This value is returned in the <c>ConnectionID</c> member of the HTTP_REQUEST
	/// structure by a call to the HttpReceiveHttpRequest function.
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the connection is broken, whereas an asynchronous call immediately returns ERROR_IO_PENDING and the
	/// calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the next request is not yet ready and is
	/// retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpwaitfordisconnect HTTPAPI_LINKAGE ULONG HttpWaitForDisconnect(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_CONNECTION_ID ConnectionId, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpWaitForDisconnect")]
	public static extern Win32Error HttpWaitForDisconnect([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_CONNECTION_ID ConnectionId, in NativeOverlapped Overlapped);

	/// <summary>
	/// The <c>HttpWaitForDisconnect</c> function notifies the application when the connection to an HTTP client is broken for any reason.
	/// </summary>
	/// <param name="RequestQueueHandle">
	/// <para>
	/// A handle to the request queue that handles requests from the specified connection. A request queue is created and its handle returned
	/// by a call to the HttpCreateRequestQueue function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 with SP1 and Windows XP with SP2:</c> The handle to the request queue is created by the HttpCreateHttpHandle function.
	/// </para>
	/// </param>
	/// <param name="ConnectionId">
	/// Identifier for the connection to the client computer. This value is returned in the <c>ConnectionID</c> member of the HTTP_REQUEST
	/// structure by a call to the HttpReceiveHttpRequest function.
	/// </param>
	/// <param name="Overlapped">
	/// <para>For asynchronous calls, set <c>pOverlapped</c> to point to an OVERLAPPED structure; for synchronous calls, set it to <c>NULL</c>.</para>
	/// <para>
	/// A synchronous call blocks until the connection is broken, whereas an asynchronous call immediately returns ERROR_IO_PENDING and the
	/// calling application then uses GetOverlappedResult or I/O completion ports to determine when the operation is completed. For
	/// information about using OVERLAPPED structures for synchronization, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>
	/// If the function is used asynchronously, a return value of ERROR_IO_PENDING indicates that the next request is not yet ready and is
	/// retrieved later through normal overlapped I/O completion mechanisms.
	/// </para>
	/// <para>If the function fails, the return value is one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One or more of the supplied parameters is in an unusable form.</term>
	/// </item>
	/// <item>
	/// <term><c>Other</c></term>
	/// <term>A system error code defined in WinError.h.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpwaitfordisconnect HTTPAPI_LINKAGE ULONG HttpWaitForDisconnect(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_CONNECTION_ID ConnectionId, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpWaitForDisconnect")]
	public static extern Win32Error HttpWaitForDisconnect([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_CONNECTION_ID ConnectionId, [In, Optional] IntPtr Overlapped);

	/// <summary>This function is an extension to HttpWaitForDisconnect.</summary>
	/// <param name="RequestQueueHandle"/>
	/// <param name="ConnectionId"/>
	/// <param name="Reserved"/>
	/// <param name="Overlapped"/>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpwaitfordisconnectex HTTPAPI_LINKAGE ULONG HttpWaitForDisconnectEx(
	// [in] HANDLE RequestQueueHandle, [in] HTTP_CONNECTION_ID ConnectionId, ULONG Reserved, [in] LPOVERLAPPED Overlapped );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpWaitForDisconnectEx")]
	public static extern Win32Error HttpWaitForDisconnectEx([In] HREQQUEUEv1 RequestQueueHandle, [In] HTTP_CONNECTION_ID ConnectionId, [In, Optional] uint Reserved, [In, Optional] IntPtr Overlapped);

	/// <summary>
	/// The <c>HttpPrepareUrl</c> function parses, analyzes, and normalizes a non-normalized Unicode or punycode URL so it is safe and valid
	/// to use in other HTTP functions.
	/// </summary>
	/// <param name="Reserved">Reserved. Must be <c>NULL</c>.</param>
	/// <param name="Flags">Reserved. Must be zero.</param>
	/// <param name="Url">A pointer to a string that represents the non-normalized Unicode or punycode URL to prepare.</param>
	/// <param name="PreparedUrl">
	/// <para>On successful output, a pointer to a string that represents the normalized URL.</para>
	/// <para><c>Note</c> Free <c>PreparedUrl</c> using HeapFree.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns one of the following or a system error code defined in WinError.h.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/http/nf-http-httpprepareurl HTTPAPI_LINKAGE ULONG HttpPrepareUrl( PVOID Reserved,
	// ULONG Flags, [in] PCWSTR Url, [out] PWSTR *PreparedUrl );
	[DllImport(Lib_Httpapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("http.h", MSDNShortId = "NF:http.HttpPrepareUrl")]
	private static extern Win32Error HttpPrepareUrl([In, Optional] IntPtr Reserved, [Optional] uint Flags, [MarshalAs(UnmanagedType.LPWStr)] string Url,
		out SafeHeapBlock PreparedUrl);

	/// <summary>Provides a handle to a v2 HTTP Request Queue.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HREQQUEUE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HREQQUEUE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HREQQUEUE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HREQQUEUE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HREQQUEUE NULL { get; } = default;

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HREQQUEUE h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HREQQUEUE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HREQQUEUE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HREQQUEUE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HREQQUEUE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HREQQUEUE h1, HREQQUEUE h2) => h1.handle != h2.handle;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HREQQUEUE h1, HREQQUEUE h2) => h1.handle == h2.handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => (obj is IHandle h && handle == h.DangerousGetHandle()) || (obj is IntPtr p && handle == p);

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to an HTTP request queue.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HREQQUEUEv1 : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HREQQUEUEv1"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HREQQUEUEv1(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HREQQUEUEv1"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HREQQUEUEv1 NULL { get; } = default;

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HREQQUEUEv1"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HREQQUEUEv1 h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HREQQUEUEv1"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HREQQUEUEv1(IntPtr h) => new(h);

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HREQQUEUEv1 h1) => h1.IsNull;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HREQQUEUEv1 h1, HREQQUEUEv1 h2) => h1.handle != h2.handle;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HREQQUEUEv1 h1, HREQQUEUEv1 h2) => h1.handle == h2.handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => (obj is IHandle h && handle == h.DangerousGetHandle()) || (obj is IntPtr p && handle == p);

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HREQQUEUE"/> that is disposed using <see cref="HttpCloseRequestQueue"/>.</summary>
	public class SafeHREQQUEUE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHREQQUEUE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHREQQUEUE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHREQQUEUE"/> class.</summary>
		private SafeHREQQUEUE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHREQQUEUE"/> to <see cref="HREQQUEUE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HREQQUEUE(SafeHREQQUEUE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeHREQQUEUE"/> to <see cref="HREQQUEUEv1"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HREQQUEUEv1(SafeHREQQUEUE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => HttpCloseRequestQueue(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HREQQUEUEv1"/> that is disposed using <see cref="CloseHandle"/>.</summary>
	public class SafeHREQQUEUEv1 : SafeHANDLE, IKernelHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHREQQUEUEv1"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHREQQUEUEv1(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHREQQUEUEv1"/> class.</summary>
		private SafeHREQQUEUEv1() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHREQQUEUEv1"/> to <see cref="HREQQUEUEv1"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HREQQUEUEv1(SafeHREQQUEUEv1 h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseHandle(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HTTP_SERVER_SESSION_ID"/> that is disposed using <see cref="HttpCloseServerSession"/>.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public class SafeHTTP_SERVER_SESSION_ID : IDisposable
	{
		private ulong id;

		/// <summary>Initializes a new instance of the <see cref="SafeHTTP_SERVER_SESSION_ID"/> class.</summary>
		private SafeHTTP_SERVER_SESSION_ID() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHTTP_SERVER_SESSION_ID"/> to <see cref="HTTP_SERVER_SESSION_ID"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTTP_SERVER_SESSION_ID(SafeHTTP_SERVER_SESSION_ID h) => h.id;

		/// <inheritdoc/>
		public void Dispose()
		{ HttpCloseServerSession(id).ThrowIfFailed(); id = 0; }
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HTTP_URL_GROUP_ID"/> that is disposed using <see cref="HttpCloseUrlGroup"/>.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public class SafeHTTP_URL_GROUP_ID : IDisposable
	{
		private ulong id;

		/// <summary>Initializes a new instance of the <see cref="SafeHTTP_URL_GROUP_ID"/> class.</summary>
		private SafeHTTP_URL_GROUP_ID() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHTTP_URL_GROUP_ID"/> to <see cref="HTTP_URL_GROUP_ID"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTTP_URL_GROUP_ID(SafeHTTP_URL_GROUP_ID h) => h.id;

		/// <inheritdoc/>
		public void Dispose()
		{ HttpCloseUrlGroup(id).ThrowIfFailed(); id = 0; }
	}

	/// <summary>Auto-closing class used to initialize and terminate an HTTP server sesssion.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class SafeHttpInitialize : IDisposable
	{
		private readonly HTTP_INIT flags;

		/// <summary>Initializes a new instance of the <see cref="SafeHttpInitialize"/> class.</summary>
		/// <param name="Version">
		/// HTTP version. This parameter is an HTTPAPI_VERSION structure. For the current version, declare an instance of the structure and
		/// set it to the pre-defined value <c>HTTPAPI_VERSION_1</c> before passing it to <c>HttpInitialize</c>.
		/// </param>
		/// <param name="Flags">
		/// <para>Initialization options, which can include one or both of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_INITIALIZE_CONFIG</c></term>
		/// <term>
		/// Perform initialization for applications that use the HTTP configuration functions, HttpSetServiceConfiguration,
		/// HttpQueryServiceConfiguration, HttpDeleteServiceConfiguration, and HttpIsFeatureSupported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_INITIALIZE_SERVER</c></term>
		/// <term>Perform initialization for applications that use the HTTP Server API.</term>
		/// </item>
		/// </list>
		/// </param>
		public SafeHttpInitialize(HTTPAPI_VERSION Version, HTTP_INIT Flags) => HttpInitialize(Version, flags = Flags).ThrowIfFailed();

		/// <summary>Initializes a new instance of the <see cref="SafeHttpInitialize"/> class with the latest version.</summary>
		/// <param name="Flags">
		/// <para>Initialization options, which can include one or both of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>HTTP_INITIALIZE_CONFIG</c></term>
		/// <term>
		/// Perform initialization for applications that use the HTTP configuration functions, HttpSetServiceConfiguration,
		/// HttpQueryServiceConfiguration, HttpDeleteServiceConfiguration, and HttpIsFeatureSupported.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>HTTP_INITIALIZE_SERVER</c></term>
		/// <term>Perform initialization for applications that use the HTTP Server API.</term>
		/// </item>
		/// </list>
		/// </param>
		public SafeHttpInitialize(HTTP_INIT Flags = HTTP_INIT.HTTP_INITIALIZE_SERVER) : this(HTTPAPI_VERSION.HTTPAPI_VERSION_2, Flags) { }

		/// <summary>Calls <see cref="HttpTerminate"/> to close the session on disposal.</summary>
		public void Dispose() => HttpTerminate(flags).ThrowIfFailed();
	}
}