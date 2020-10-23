using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Functions and interfaces from UrlMon.dll. URL monikers allow an application to bind a resource, specified by a URL, to a moniker.
	/// Asynchronous pluggable protocols enable developers to create pluggable protocol handlers, MIME filters, and namespace handlers.
	/// </summary>
	public static partial class UrlMon
	{
		/// <summary>Contains the values that determine how a resource is bound to a moniker.</summary>
		/// <remarks>
		/// <para>
		/// These values are passed to the Urlmon.dll from the client application's implementation of the
		/// <c>IBindStatusCallback::GetBindInfo</c> method.
		/// </para>
		/// <para>
		/// <c>Note</c> The gopher protocol is turned off by default in Microsoft Internet Explorer 6 for Windows XP Service Pack 2 (SP2).
		/// The protocol has been removed from WinInet in Windows Internet Explorer 7.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775130(v=vs.85) typedef
		// enum { BINDF_ASYNCHRONOUS = 0x00000001, BINDF_ASYNCSTORAGE = 0x00000002, BINDF_NOPROGRESSIVERENDERING = 0x00000004,
		// BINDF_OFFLINEOPERATION = 0x00000008, BINDF_GETNEWESTVERSION = 0x00000010, BINDF_NOWRITECACHE = 0x00000020, BINDF_NEEDFILE =
		// 0x00000040, BINDF_PULLDATA = 0x00000080, BINDF_IGNORESECURITYPROBLEM = 0x00000100, BINDF_RESYNCHRONIZE = 0x00000200,
		// BINDF_HYPERLINK = 0x00000400, BINDF_NO_UI = 0x00000800, BINDF_SILENTOPERATION = 0x00001000, BINDF_PRAGMA_NO_CACHE = 0x00002000,
		// BINDF_GETCLASSOBJECT = 0x00004000, BINDF_RESERVED_1 = 0x00008000, BINDF_FREE_THREADED = 0x00010000, BINDF_DIRECT_READ =
		// 0x00020000, BINDF_FORMS_SUBMIT = 0x00040000, BINDF_GETFROMCACHE_IF_NET_FAIL = 0x00080000, BINDF_FROMURLMON = 0x00100000,
		// BINDF_FWD_BACK = 0x00200000, BINDF_PREFERDEFAULTHANDLER = 0x00400000, BINDF_ENFORCERESTRICTED = 0x00800000 } BINDF;
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum BINDF : uint
		{
			/// <summary>
			/// Value that indicates that the moniker will return immediately from a call to the IMoniker::BindToStorage method or the
			/// IMoniker::BindToObject method. The actual result of the bind to an object or the bind to storage returns asynchronously. The
			/// client application is notified by a call to the <c>IBindStatusCallback::OnDataAvailable</c> method or the
			/// <c>IBindStatusCallback::OnObjectAvailable</c> method. If the client does not specify this flag, the bind operation is
			/// synchronous, and the client receives no data from the bind operation until the IMoniker::BindToStorage call or the
			/// IMoniker::BindToObject call returns.
			/// </summary>
			BINDF_ASYNCHRONOUS = 0x00000001,

			/// <summary>
			/// <para>
			/// Value that indicates that the client application calling the IMoniker::BindToStorage method specifies that the storage
			/// objects and stream objects returned from the <c>IBindStatusCallback::OnDataAvailable</c> method return E_PENDING when the
			/// objects reference data that is not yet available through the IStream::Read method, instead of blocking until the data
			/// becomes available. This flag applies only to <c>BINDF_ASYNCHRONOUS</c> operations.
			/// </para>
			/// <para>
			/// <c>Note</c> Asynchronous stream objects return E_PENDING while data is still downloading and return S_FALSE for the end of
			/// the file.
			/// </para>
			/// </summary>
			BINDF_ASYNCSTORAGE = 0x00000002,

			/// <summary>Value that indicates that progressive rendering is not be allowed.</summary>
			BINDF_NOPROGRESSIVERENDERING = 0x00000004,

			/// <summary>Value that indicates that the moniker is bound to the cached version of the resource.</summary>
			BINDF_OFFLINEOPERATION = 0x00000008,

			/// <summary>
			/// Value that indicates that the bind operation retrieves the newest version of the data or object available. In URL monikers,
			/// this flag maps to the WinInet flag, INTERNET_FLAG_RELOAD, which forces a download of the requested resource.
			/// </summary>
			BINDF_GETNEWESTVERSION = 0x00000010,

			/// <summary>
			/// Value that indicates that the bind operation does not store retrieved data in the disk cache. The client must specify
			/// <c>BINDF_PULLDATA</c> to turn off the cache file generation when the IMoniker::BindToStorage method is called.
			/// </summary>
			BINDF_NOWRITECACHE = 0x00000020,

			/// <summary>Value that indicates that the downloaded resource must be saved in the cache or a local file.</summary>
			BINDF_NEEDFILE = 0x00000040,

			/// <summary>
			/// Value that indicates that the asynchronous moniker enables the client of the IMoniker::BindToStorage method to drive the
			/// bind operation by pulling the data, instead of using the moniker to drive the operation by pushing the data to the client.
			/// When this flag is specified, new data is read or downloaded after the client finishes downloading all data that is currently
			/// available. This means data is only downloaded for the client after the client calls an IStream::Read operation that blocks
			/// or returns E_PENDING. When this flag is specified, the client must read all the data it can, even data that is not
			/// necessarily available yet. When this flag is not specified, the moniker continues downloading data and calls the client with
			/// <c>IBindStatusCallback::OnDataAvailable</c> whenever new data is available. This flag applies only to
			/// <c>BINDF_ASYNCHRONOUS</c> bind operations.
			/// </summary>
			BINDF_PULLDATA = 0x00000080,

			/// <summary>
			/// Value that indicates that security problems related to bad certificates and redirects between HTTP and HTTPS servers should
			/// be ignored. For URL monikers, this flag corresponds to the following WinInet flags: INTERNET_FLAG_IGNORE_CERT_CN_INVALID,
			/// INTERNET_FLAG_IGNORE_CERT_DATE_INVALID, INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTP, and INTERNET_FLAG_IGNORE_REDIRECT_TO_HTTPS.
			/// <para>
			/// Security Warning: Using this value incorrectly can compromise the security of your application. If you implement the
			/// IBindStatusCallback::GetBindInfo method to ignore security problems with certificates and redirection, users may be
			/// susceptible to unwanted information disclosure. You should not implement IBindStatusCallback::GetBindInfo with a return
			/// value of BINDF_IGNORESECURITYPROBLEM because it prevents Internet Explorer from notifying users of security concerns. For
			/// more information, see Security Considerations: URL Monikers.
			/// </para>
			/// </summary>
			BINDF_IGNORESECURITYPROBLEM = 0x00000100,

			/// <summary>
			/// Value that indicates that the resource should be resynchronized. For URL monikers, this flag maps to the WinInet flag,
			/// INTERNET_FLAG_RESYNCHRONIZE, which reloads an HTTP resource if the resource has been modified since the last time it was
			/// downloaded. All FTP and Gopher resources are reloaded.
			/// </summary>
			BINDF_RESYNCHRONIZE = 0x00000200,

			/// <summary>Value that indicates that hyperlinks are allowed.</summary>
			BINDF_HYPERLINK = 0x00000400,

			/// <summary>Value that indicates that the bind operation will not display any user interfaces.</summary>
			BINDF_NO_UI = 0x00000800,

			/// <summary>
			/// Value that indicates the bind operation will be completed silently. No user interface or user notification will occur.
			/// </summary>
			BINDF_SILENTOPERATION = 0x00001000,

			/// <summary>Value that indicates that the resource will not be stored in the Internet cache.</summary>
			BINDF_PRAGMA_NO_CACHE = 0x00002000,

			/// <summary>Value that indicates that the class object will be retrieved. Typically the class instance is retrieved.</summary>
			BINDF_GETCLASSOBJECT = 0x00004000,

			/// <summary>Reserved.</summary>
			BINDF_RESERVED_1 = 0x00008000,

			/// <summary>Reserved.</summary>
			BINDF_FREE_THREADED = 0x00010000,

			/// <summary>
			/// Value that indicates that the client application does not have to know the exact size of the data available, so the
			/// information is read directly from the source.
			/// </summary>
			BINDF_DIRECT_READ = 0x00020000,

			/// <summary>Value that indicates that this transaction is handled as a forms submittal.</summary>
			BINDF_FORMS_SUBMIT = 0x00040000,

			/// <summary>
			/// Value that indicates the resource is retrieved from the cache if the attempt to download the resource from the network fails.
			/// </summary>
			BINDF_GETFROMCACHE_IF_NET_FAIL = 0x00080000,

			/// <summary>Value that indicates the binding is from a URL moniker. This value was added for Internet Explorer 5.</summary>
			BINDF_FROMURLMON = 0x00100000,

			/// <summary>
			/// Value that indicates that the moniker will bind to the copy of the resource that is currently in the Internet cache. If the
			/// requested item is not found in the Internet cache, the system will attempt to locate the resource on the network. This value
			/// maps to the Win32 Internet API flag, INTERNET_FLAG_USE_CACHED_COPY.
			/// </summary>
			BINDF_FWD_BACK = 0x00200000,

			/// <summary>
			/// Value that indicates that the moniker client will specify that Urlmon.dll should look for and use the default system
			/// protocol first, instead of searching for temporary or permanent namespace handlers before it uses the default registered
			/// handler for particular protocols.
			/// </summary>
			BINDF_PREFERDEFAULTHANDLER = 0x00400000,

			/// <summary>
			/// Value that indicates that this transaction will be treated as taking place in the Restricted Sites Zone. For URL monikers,
			/// this flag maps to the Win32 Internet API flag, INTERNET_FLAG_RESTRICTED_ZONE.
			/// </summary>
			BINDF_ENFORCERESTRICTED = 0x00800000
		}

		/// <summary>
		/// Contains values that are passed to the client application's implementation of the <c>IBindStatusCallback::OnProgress</c> method.
		/// These values indicate the progress of the bind operation.
		/// </summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775133(v=vs.85) typedef
		// enum tagBINDSTATUS { BINDSTATUS_FINDINGRESOURCE = 1, BINDSTATUS_CONNECTING, BINDSTATUS_REDIRECTING, BINDSTATUS_BEGINDOWNLOADDATA,
		// BINDSTATUS_DOWNLOADINGDATA, BINDSTATUS_ENDDOWNLOADDATA, BINDSTATUS_BEGINDOWNLOADCOMPONENTS, BINDSTATUS_INSTALLINGCOMPONENTS,
		// BINDSTATUS_ENDDOWNLOADCOMPONENTS, BINDSTATUS_USINGCACHEDCOPY, BINDSTATUS_SENDINGREQUEST, BINDSTATUS_CLASSIDAVAILABLE,
		// BINDSTATUS_MIMETYPEAVAILABLE, BINDSTATUS_CACHEFILENAMEAVAILABLE, BINDSTATUS_BEGINSYNCOPERATION, BINDSTATUS_ENDSYNCOPERATION,
		// BINDSTATUS_BEGINUPLOADDATA, BINDSTATUS_UPLOADINGDATA, BINDSTATUS_ENDUPLOADINGDATA, BINDSTATUS_PROTOCOLCLASSID,
		// BINDSTATUS_ENCODING, BINDSTATUS_VERFIEDMIMETYPEAVAILABLE, BINDSTATUS_CLASSINSTALLLOCATION, BINDSTATUS_DECODING,
		// BINDSTATUS_LOADINGMIMEHANDLER, BINDSTATUS_CONTENTDISPOSITIONATTACH, BINDSTATUS_FILTERREPORTMIMETYPE,
		// BINDSTATUS_CLSIDCANINSTANTIATE, BINDSTATUS_IUNKNOWNAVAILABLE, BINDSTATUS_DIRECTBIND, BINDSTATUS_RAWMIMETYPE,
		// BINDSTATUS_PROXYDETECTING, BINDSTATUS_ACCEPTRANGES, BINDSTATUS_COOKIE_SENT, BINDSTATUS_COMPACT_POLICY_RECEIVED,
		// BINDSTATUS_COOKIE_SUPPRESSED, BINDSTATUS_COOKIE_STATE_UNKNOWN, BINDSTATUS_COOKIE_STATE_ACCEPT, BINDSTATUS_COOKIE_STATE_REJECT,
		// BINDSTATUS_COOKIE_STATE_PROMPT, BINDSTATUS_COOKIE_STATE_LEASH, BINDSTATUS_COOKIE_STATE_DOWNGRADE, BINDSTATUS_POLICY_HREF,
		// BINDSTATUS_P3P_HEADER, BINDSTATUS_SESSION_COOKIE_RECEIVED, BINDSTATUS_PERSISTENT_COOKIE_RECEIVED,
		// BINDSTATUS_SESSION_COOKIES_ALLOWED, BINDSTATUS_CACHECONTROL, BINDSTATUS_CONTENTDISPOSITIONFILENAME,
		// BINDSTATUS_MIMETEXTPLAINMISMATCH, BINDSTATUS_PUBLISHERAVAILABLE, BINDSTATUS_DISPLAYNAMEAVAILABLE, BINDSTATUS_SSLUX_NAVBLOCKED,
		// BINDSTATUS_SERVER_MIMETYPEAVAILABLE, BINDSTATUS_SNIFFED_CLASSIDAVAILABLE, BINDSTATUS_64BIT_PROGRESS, BINDSTATUS_LAST =
		// BINDSTATUS_64BIT_PROGRESS, BINDSTATUS_RESERVED_0, BINDSTATUS_RESERVED_1, BINDSTATUS_RESERVED_2, BINDSTATUS_RESERVED_3,
		// BINDSTATUS_RESERVED_4, BINDSTATUS_RESERVED_5, BINDSTATUS_RESERVED_6, BINDSTATUS_RESERVED_7, BINDSTATUS_RESERVED_8,
		// BINDSTATUS_RESERVED_9, BINDSTATUS_LAST_PRIVATE = BINDSTATUS_RESERVED_9 } BINDSTATUS;
		[PInvokeData("Urlmon.h")]
		public enum BINDSTATUS
		{
			/// <summary>
			/// Notifies the client application that the bind operation is finding the resource that holds the object or storage. The
			/// szStatusText parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the resource that
			/// the bind operation is looking for (for example, "www.microsoft.com").
			/// </summary>
			BINDSTATUS_FINDINGRESOURCE = 1,

			/// <summary>
			/// Notifies the client application that the bind operation is connecting to the resource that holds the object or storage. The
			/// szStatusText parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the resource that
			/// the bind operation is connecting to (for example, an IP address).
			/// </summary>
			BINDSTATUS_CONNECTING,

			/// <summary>
			/// Notifies the client application that the bind operation has been redirected to a different data location. The szStatusText
			/// parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the new data location.
			/// </summary>
			BINDSTATUS_REDIRECTING,

			/// <summary>
			/// Notifies the client application that the bind operation has begun receiving the object or storage. The szStatusText
			/// parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the data location .
			/// </summary>
			BINDSTATUS_BEGINDOWNLOADDATA,

			/// <summary>
			/// Notifies the client application that the bind operation continues to receive the object or storage. The szStatusText
			/// parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the data location.
			/// </summary>
			BINDSTATUS_DOWNLOADINGDATA,

			/// <summary>
			/// Notifies the client application that the bind operation has finished receiving the object or storage. The szStatusText
			/// parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the data location.
			/// </summary>
			BINDSTATUS_ENDDOWNLOADDATA,

			/// <summary>Notifies the client application that the bind operation is beginning to download the component.</summary>
			BINDSTATUS_BEGINDOWNLOADCOMPONENTS,

			/// <summary>Notifies the client application that the bind operation is installing the component.</summary>
			BINDSTATUS_INSTALLINGCOMPONENTS,

			/// <summary>Notifies the client application that the bind operation has finished downloading the component.</summary>
			BINDSTATUS_ENDDOWNLOADCOMPONENTS,

			/// <summary>
			/// Notifies the client application that the bind operation is retrieving the requested object or storage from a cached copy.
			/// The szStatusText parameter to the <c>IBindStatusCallback::OnProgress</c> method is <c>NULL</c>.
			/// </summary>
			BINDSTATUS_USINGCACHEDCOPY,

			/// <summary>
			/// Notifies the client application that the bind operation is requesting the object or storage. The szStatusText parameter to
			/// the <c>IBindStatusCallback::OnProgress</c> method provides the display name of the object (for example, a file name).
			/// </summary>
			BINDSTATUS_SENDINGREQUEST,

			/// <summary>Notifies the client application that the <c>CLSID</c> of the resource is available.</summary>
			BINDSTATUS_CLASSIDAVAILABLE,

			/// <summary>
			/// <para>Notifies the client application that the MIME type of the resource is available.</para>
			/// <para>
			/// <c>Note</c> Internet Explorer 7. Not used if Internet Explorer feature <c>FEATURE_DISABLE_LEGACY_COMPRESSION</c> is enabled.
			/// </para>
			/// </summary>
			BINDSTATUS_MIMETYPEAVAILABLE,

			/// <summary>
			/// Notifies the client application that the temporary or cache file name of the resource is available. The temporary file name
			/// might be returned if <c>BINDF_NOWRITECACHE</c> is called. The temporary file will be deleted after the storage is released.
			/// </summary>
			BINDSTATUS_CACHEFILENAMEAVAILABLE,

			/// <summary>Notifies the client application that a synchronous operation has started.</summary>
			BINDSTATUS_BEGINSYNCOPERATION,

			/// <summary>Notifies the client application that the synchronous operation has completed.</summary>
			BINDSTATUS_ENDSYNCOPERATION,

			/// <summary>Notifies the client application that the file upload has started.</summary>
			BINDSTATUS_BEGINUPLOADDATA,

			/// <summary>Notifies the client application that the file upload is in progress.</summary>
			BINDSTATUS_UPLOADINGDATA,

			/// <summary>Notifies the client application that the file upload has completed.</summary>
			BINDSTATUS_ENDUPLOADINGDATA,

			/// <summary>Notifies the client application that the <c>CLSID</c> of the protocol handler being used is available.</summary>
			BINDSTATUS_PROTOCOLCLASSID,

			/// <summary>
			/// <para>Notifies the client application that the Urlmon.dll is encoding data.</para>
			/// <para><c>Note</c> Internet Explorer 9. Urlmon no longer performs compression.</para>
			/// </summary>
			BINDSTATUS_ENCODING,

			/// <summary>Notifies the client application that the verified MIME type is available.</summary>
			BINDSTATUS_VERFIEDMIMETYPEAVAILABLE,

			/// <summary>Notifies the client application that the class install location is available.</summary>
			BINDSTATUS_CLASSINSTALLLOCATION,

			/// <summary>Notifies the client application that the bind operation is decoding data.</summary>
			BINDSTATUS_DECODING,

			/// <summary>
			/// Notifies the client application that a pluggable MIME handler is being loaded. This value was added for Internet Explorer 5.
			/// </summary>
			BINDSTATUS_LOADINGMIMEHANDLER,

			/// <summary>
			/// <para>
			/// Notifies the client application that this resource contained a Content-Disposition header that indicates that this resource
			/// is an attachment. The content of this resource should not be automatically displayed. Client applications should request
			/// permission from the user. This value was added for Internet Explorer 5.
			/// </para>
			/// <para>
			/// <c>Note</c> Internet Explorer 7. Not used if Internet Explorer feature <c>FEATURE_DISABLE_LEGACY_COMPRESSION</c> is enabled.
			/// </para>
			/// </summary>
			BINDSTATUS_CONTENTDISPOSITIONATTACH,

			/// <summary>
			/// Notifies the client application of the new MIME type of the resource. This is used by a pluggable MIME filter to report a
			/// change in the MIME type after it has processed the resource. This value was added for Internet Explorer 5.
			/// </summary>
			BINDSTATUS_FILTERREPORTMIMETYPE,

			/// <summary>
			/// Notifies the Urlmon.dll that this <c>CLSID</c> is for the class that the Urlmon.dll should return to the client on a call to
			/// IMoniker::BindToObject. This value was added for Internet Explorer 5.
			/// </summary>
			BINDSTATUS_CLSIDCANINSTANTIATE,

			/// <summary>Reports that the IUnknown interface has been released. This value was added for Internet Explorer 5.</summary>
			BINDSTATUS_IUNKNOWNAVAILABLE,

			/// <summary>
			/// Reports whether the client application is connected directly to the pluggable protocol handler. This value was added for
			/// Internet Explorer 5.
			/// </summary>
			BINDSTATUS_DIRECTBIND,

			/// <summary>
			/// Reports the MIME type of the resource, before any data sniffing is done. This value was added for Internet Explorer 5. For
			/// more information, see MIME Type Detection in Internet Explorer.
			/// </summary>
			BINDSTATUS_RAWMIMETYPE,

			/// <summary>Reports that a proxy server has been detected. This value was added for Internet Explorer 5.</summary>
			BINDSTATUS_PROXYDETECTING,

			/// <summary>Reports the valid types of range requests for a resource. This value was added for Internet Explorer 5.</summary>
			BINDSTATUS_ACCEPTRANGES,

			/// <summary>Notifies the client application that a cookie was sent with the web request.</summary>
			BINDSTATUS_COOKIE_SENT,

			/// <summary>
			/// Notifies the client application that a P3P v1 compact policy was received. A compact policy can be sent only in the P3P HTTP
			/// response header. For example,
			/// </summary>
			BINDSTATUS_COMPACT_POLICY_RECEIVED,

			/// <summary>Notifies the client application that a cookie was suppressed from being sent to the web server.</summary>
			BINDSTATUS_COOKIE_SUPPRESSED,

			/// <summary>
			/// Notifies the client application that a cookie has been initialized. This is a default initialization state for cookie operations.
			/// </summary>
			BINDSTATUS_COOKIE_STATE_UNKNOWN,

			/// <summary>Notifies the client application that a cookie sent by the server was accepted on the client.</summary>
			BINDSTATUS_COOKIE_STATE_ACCEPT,

			/// <summary>Notifies the client application that a cookie sent by the server was rejected based on privacy and user settings.</summary>
			BINDSTATUS_COOKIE_STATE_REJECT,

			/// <summary>Notifies the client application that the user settings require a prompt before performing a cookie operation.</summary>
			BINDSTATUS_COOKIE_STATE_PROMPT,

			/// <summary>
			/// Notifies the client application that the cookie is a leashed cookie. A leashed cookie is only sent on requests to download
			/// first-party content. When requests are made for third-party content, leashed cookies are suppressed, that is, they are not sent.
			/// </summary>
			BINDSTATUS_COOKIE_STATE_LEASH,

			/// <summary>
			/// Notifies the client application that the cookie is a downgraded cookie. A downgraded cookie is a persistent cookie that is
			/// deleted when the browsing session ends or the cookie expires, whichever comes first. In other words, the persistent cookie
			/// becomes a session cookie.
			/// </summary>
			BINDSTATUS_COOKIE_STATE_DOWNGRADE,

			/// <summary>Notifies the client application that the HTTP headers contain a link to the full privacy policy.</summary>
			BINDSTATUS_POLICY_HREF,

			/// <summary>Notifies the client application that an HTTP response from the server contains the P3P privacy header.</summary>
			BINDSTATUS_P3P_HEADER,

			/// <summary>Notifies the client application that a session cookie was received.</summary>
			BINDSTATUS_SESSION_COOKIE_RECEIVED,

			/// <summary>Notifies the client application that a persistent cookie was received.</summary>
			BINDSTATUS_PERSISTENT_COOKIE_RECEIVED,

			/// <summary>Notifies the client application that session cookies are allowed.</summary>
			BINDSTATUS_SESSION_COOKIES_ALLOWED,

			/// <summary>
			/// <para>
			/// Notifies the client application that a response from the server was written to memory only. No temporary file was created in
			/// the WinInet cache.
			/// </para>
			/// <para>
			/// <c>Note</c> Internet Explorer 7. Not used if Internet Explorer feature control <c>FEATURE_DISABLE_LEGACY_COMPRESSION</c> is enabled.
			/// </para>
			/// </summary>
			BINDSTATUS_CACHECONTROL,

			/// <summary>
			/// <para>
			/// Internet Explorer 6 for Windows XP SP2 and later. Notifies the client application that the Content-Disposition header
			/// contains a file name rather than an attachment. See <c>BINDSTATUS_CONTENTDISPOSITIONATTACH</c> for more information.
			/// </para>
			/// <para>
			/// <c>Note</c> Internet Explorer 7. Not used if Internet Explorer feature control <c>FEATURE_DISABLE_LEGACY_COMPRESSION</c> is enabled.
			/// </para>
			/// </summary>
			BINDSTATUS_CONTENTDISPOSITIONFILENAME,

			/// <summary>
			/// Internet Explorer 6 for Windows XP SP2 and later. Notifies the client application that the reported Content-Type of the file
			/// does not match the content. This notification is sent only for files whose Content-Type is text/plain.
			/// </summary>
			BINDSTATUS_MIMETEXTPLAINMISMATCH,

			/// <summary>
			/// Internet Explorer 6 for Windows XP SP2 and later. Notifies the client application that the name of the publisher whose
			/// control is being downloaded is available. The name is extracted from the file's signature.
			/// </summary>
			BINDSTATUS_PUBLISHERAVAILABLE,

			/// <summary>
			/// Internet Explorer 6 for Windows XP SP2 and later. Notifies the client application that the display name of the control that
			/// is being downloaded is available. The name is extracted from the file's signature, otherwise, the file name (without the
			/// extension) is used.
			/// </summary>
			BINDSTATUS_DISPLAYNAMEAVAILABLE,

			/// <summary>
			/// Internet Explorer 7. Notifies the client application that there was a problem with the SSL certificate, and the security
			/// handshake was interrupted. These problems include invalid certificate authority, invalid date, invalid common name, and
			/// certificate revocation failure. The szStatusText parameter to the <c>IBindStatusCallback::OnProgress</c> method provides the
			/// error code.
			/// </summary>
			BINDSTATUS_SSLUX_NAVBLOCKED,

			/// <summary>
			/// <para>
			/// Internet Explorer 8. Reports the server's authoritative MIME type. Sending an authoritative header prevents Internet
			/// Explorer from data sniffing a response away from the declared type. (For a detailed explanation of data sniffing, see MIME
			/// Type Detection in Internet Explorer.) To be considered authoritative, the server must provide in the HTTP response header,
			/// as follows:
			/// </para>
			/// <para>
			/// The authoritative type is not reported if the HTTP response header is present. The szStatusText parameter to the
			/// <c>IBindStatusCallback::OnProgress</c> method provides the MIME type.
			/// </para>
			/// </summary>
			BINDSTATUS_SERVER_MIMETYPEAVAILABLE,

			/// <summary>
			/// Internet Explorer 8. Reports CLSID generated from authoritative HTTP response header. Value is reported in canonical GUID
			/// format in the szStatusText parameter.
			/// </summary>
			BINDSTATUS_SNIFFED_CLASSIDAVAILABLE,

			/// <summary>
			/// Internet Explorer 8. Notifies the client application of download progress values above the maximum 32-bit file size limit.
			/// Value is reported as two 64-bit numbers separated by a comma (current progress and total bytes) in the szStatusText
			/// parameter. For example, given the string , 857 is the current progress and 500000000 is the maximum progress.
			/// </summary>
			BINDSTATUS_64BIT_PROGRESS,

			/// <summary>The count of public <c>BINDSTATUS</c> enumeration values.</summary>
			BINDSTATUS_LAST = BINDSTATUS_64BIT_PROGRESS,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_0,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_1,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_2,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_3,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_4,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_5,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_6,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_7,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_8,

			/// <summary>Internet Explorer 9. Reserved. Do not use.</summary>
			BINDSTATUS_RESERVED_9,

			/// <summary>Internet Explorer 9. Used to calculate the count of private enumeration values.</summary>
			BINDSTATUS_LAST_PRIVATE = BINDSTATUS_RESERVED_9,
		}

		/// <summary>
		/// <para>
		/// This enumeration's values are passed to the client in the IBindStatusCallback::OnDataAvailable method to indicate the type of
		/// data that is available.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/embedded/aa452105(v=msdn.10)
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum BSCF : uint
		{
			/// <summary>Identify the first call to <c>IBindStatusCallback::OnDataAvailable</c> for a given bind operation.</summary>
			BSCF_FIRSTDATANOTIFICATION = 0x00000001,

			/// <summary>Identify an intermediate call to <c>IBindStatusCallback::OnDataAvailable</c> for a bind operation.</summary>
			BSCF_INTERMEDIATEDATANOTIFICATION = 0x00000002,

			/// <summary>Identify the last call to <c>IBindStatusCallback::OnDataAvailable</c> for a bind operation.</summary>
			BSCF_LASTDATANOTIFICATION = 0x00000004,

			/// <summary>All of the requested data is available.</summary>
			BSCF_DATAFULLYAVAILABLE = 0x00000008,

			/// <summary>Size of the data available is unknown.</summary>
			BSCF_AVAILABLEDATASIZEUNKNOWN = 0x00000010,

			/// <summary>
			/// Internet Explorer 8. Flag sent to IBindStatusCallback::OnDataAvailable to bypass cache downloads for file:// URLs. Normally,
			/// the cache file is emptied when new data is available. Specify this flag when it is not necessary to read the data and throw
			/// it away, such as when downloading a file through a UNC path.
			/// </summary>
			BSCF_SKIPDRAINDATAFORFILEURLS = 0x00000020,

			/// <summary>
			/// Internet Explorer 8. Notification to the IInternetProtocolSink::ReportProgress that the size cannot be expressed in 32-bit
			/// terms for downloads exceeding 4 GB.
			/// </summary>
			BSCF_64BITLENGTHDOWNLOAD = 0x00000040
		}

		/// <summary>The following flags determine the behavior of registered Microsoft ActiveX controls.</summary>
		/// <remarks>
		/// These enumeration members are bit masks that determine how ActiveX controls are used in Internet Explorer. Values are stored in
		/// the registry key <c>HKEY_LOCAL_MACHINE</c>\ <c>SOFTWARE</c>\ <c>Microsoft</c>\ <c>Internet Explorer</c>\ <c>ActiveX Compatibility</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa768234%28v%3dvs.85%29
		// typedef enum { COMPAT_AGGREGATE = 0x00000001, COMPAT_NO_OBJECTSAFETY = 0x00000002, COMPAT_NO_PROPNOTIFYSINK = 0x00000004,
		// COMPAT_SEND_SHOW = 0x00000008, COMPAT_SEND_HIDE = 0x00000010, COMPAT_ALWAYS_INPLACEACTIVATE = 0x00000020, COMPAT_NO_SETEXTENT =
		// 0x00000040, COMPAT_NO_UIACTIVATE = 0x00000080, COMPAT_NO_QUICKACTIVATE = 0x00000100, COMPAT_NO_BINDF_OFFLINEOPERATION =
		// 0x00000200, COMPAT_EVIL_DONT_LOAD = 0x00000400, COMPAT_PROGSINK_UNTIL_ACTIVATED = 0x00000800, COMPAT_USE_PROPBAG_AND_STREAM =
		// 0x00001000, COMPAT_DISABLEWINDOWLESS = 0x00002000, COMPAT_SETWINDOWRGN = 0x00004000, COMPAT_PRINTPLUGINSITE = 0x00008000,
		// COMPAT_INPLACEACTIVATEEVENWHENINVISIBLE = 0x00010000, COMPAT_NEVERFOCUSSABLE = 0x00020000, COMPAT_ALWAYSDEFERSETWINDOWRGN =
		// 0x00040000, COMPAT_INPLACEACTIVATESYNCHRONOUSLY = 0x00080000, COMPAT_NEEDSZEROBASEDDRAWRECT = 0x00100000, COMPAT_HWNDPRIVATE =
		// 0x00200000, COMPAT_SECURITYCHECKONREDIRECT = 0x00400000, COMPAT_SAFEFOR_LOADING = 0x00800000 } COMPAT;
		[Flags]
		public enum COMPAT
		{
			/// <summary>This control is aggregated.</summary>
			COMPAT_AGGREGATE = 0x00000001,

			/// <summary>This control is not safe for scripting, even if it implements IObjectSafety.</summary>
			COMPAT_NO_OBJECTSAFETY = 0x00000002,

			/// <summary>A property notify sink is not attached to this control.</summary>
			COMPAT_NO_PROPNOTIFYSINK = 0x00000004,

			/// <summary>For this control, IOleObject::DoVerb is called with OLEIVERB_SHOW before IOleObject::DoVerb is called with OLEIVERB_INPLACEACTIVATE.</summary>
			COMPAT_SEND_SHOW = 0x00000008,

			/// <summary>
			/// For this control, IOleObject::DoVerb is called with OLEIVERB_HIDE before IOleInPlaceObject::InPlaceDeactivate is called.
			/// </summary>
			COMPAT_SEND_HIDE = 0x00000010,

			/// <summary>For this control, IOleObject::DoVerb is called with OLEIVERB_INPLACEACTIVATE.</summary>
			COMPAT_ALWAYS_INPLACEACTIVATE = 0x00000020,

			/// <summary>The amount of space required by this control's container is not specified.</summary>
			COMPAT_NO_SETEXTENT = 0x00000040,

			/// <summary>This control cannot activate the UI elements of the current document host.</summary>
			COMPAT_NO_UIACTIVATE = 0x00000080,

			/// <summary>This control does not implement IQuickActivate or should not be activated quickly.</summary>
			COMPAT_NO_QUICKACTIVATE = 0x00000100,

			/// <summary>A cached version of this control is never used.</summary>
			COMPAT_NO_BINDF_OFFLINEOPERATION = 0x00000200,

			/// <summary>This control is never used.</summary>
			COMPAT_EVIL_DONT_LOAD = 0x00000400,

			/// <summary>This control cannot be used for scripting until in-place activation is complete.</summary>
			COMPAT_PROGSINK_UNTIL_ACTIVATED = 0x00000800,

			/// <summary>Both IPersistPropertyBag::Load and IPersistStreamInit::Load are called when using this control.</summary>
			COMPAT_USE_PROPBAG_AND_STREAM = 0x00001000,

			/// <summary>This control cannot be in-place activated without a window.</summary>
			COMPAT_DISABLEWINDOWLESS = 0x00002000,

			/// <summary>This control cannot have UI outside of the window.</summary>
			COMPAT_SETWINDOWRGN = 0x00004000,

			/// <summary>This control has printing capabilities that should be used instead of those provided by Internet Explorer.</summary>
			COMPAT_PRINTPLUGINSITE = 0x00008000,

			/// <summary>This control is in-place activated whether or not it is visible.</summary>
			COMPAT_INPLACEACTIVATEEVENWHENINVISIBLE = 0x00010000,

			/// <summary>This control can never receive focus.</summary>
			COMPAT_NEVERFOCUSSABLE = 0x00020000,

			/// <summary>This control is allowed to have, at most, one pending resize request.</summary>
			COMPAT_ALWAYSDEFERSETWINDOWRGN = 0x00040000,

			/// <summary>This control is in-place activated syncronously.</summary>
			COMPAT_INPLACEACTIVATESYNCHRONOUSLY = 0x00080000,

			/// <summary>This control is positioned in the upper-left corner of the host window.</summary>
			COMPAT_NEEDSZEROBASEDDRAWRECT = 0x00100000,

			/// <summary>This control does not provide access to its window handle.</summary>
			COMPAT_HWNDPRIVATE = 0x00200000,

			/// <summary>This control is prevented from accessing content from another domain when redirected by the original server.</summary>
			COMPAT_SECURITYCHECKONREDIRECT = 0x00400000,

			/// <summary>
			/// Internet Explorer 7 and later. In the Internet zone, Internet Explorer checks every control for IObjectSafety to determine
			/// safety status quickly and abort instantiation as soon as possible. If a particular control doesn't implement IObjectSafety
			/// or component categories yet still needs to be instantiated in Internet Explorer without data or scripting, this
			/// compatibility flag can be used to disable the frontloaded safety check and revert back to Internet Explorer 6 behavior. See
			/// Safe Initialization and Scripting for ActiveX Controls.
			/// </summary>
			COMPAT_SAFEFOR_LOADING = 0x00800000
		}

		/// <summary>Flags for <see cref="FaultInIEFeature"/>.</summary>
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum FIEF_FLAG
		{
			/// <summary>
			/// Force JIT, even if the user has canceled a previous JIT in the same session, or has specified to this feature. Note: For
			/// Internet Explorer 7, this flag is not respected; it is overridden by E_ACCESSDENIED.
			/// </summary>
			FIEF_FLAG_FORCE_JITUI = 0x1,

			/// <summary>
			/// Do not faultin, just peek. Note: Peek also returns the currently installed version in the QUERYCONTEXT. For Internet
			/// Explorer 7, it disables the Java dialog box.
			/// </summary>
			FIEF_FLAG_PEEK = 0x2,

			/// <summary>
			/// Ignores local version as being satisfactory and forces JIT download. Typically, this is called by code download, or by
			/// another caller after a CoCreateInstance call has failed with REGDB_E_CLASSNOTREG or ERROR_MOD_NOT_FOUND (missing a
			/// dependency DLL). Note: The registry might show that this feature is installed when it is not, or when it is damaged. For
			/// Internet Explorer 7, this flag is not respected; it is overridden by E_ACCESSDENIED.
			/// </summary>
			FIEF_FLAG_SKIP_INSTALLED_VERSION_CHECK = 0x4
		}

		/// <summary>Mime flags.</summary>
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum FMFD
		{
			/// <summary>The FMFD default</summary>
			FMFD_DEFAULT = 0x00000000,

			/// <summary>The FMFD urlasfilename</summary>
			FMFD_URLASFILENAME = 0x00000001,

			/// <summary>The FMFD enablemimesniffing</summary>
			FMFD_ENABLEMIMESNIFFING = 0x00000002,

			/// <summary>The FMFD ignoremimetextplain</summary>
			FMFD_IGNOREMIMETEXTPLAIN = 0x00000004,

			/// <summary>The FMFD servermime</summary>
			FMFD_SERVERMIME = 0x00000008,

			/// <summary>The FMFD respecttextplain</summary>
			FMFD_RESPECTTEXTPLAIN = 0x00000010,

			/// <summary>The FMFD returnupdatedimgmimes</summary>
			FMFD_RETURNUPDATEDIMGMIMES = 0x00000020,
		}

		/// <summary>
		/// Contains options for URL parsing operations. Used by <c>CoInternetParseUrl</c>, <c>CoInternetParseIUri</c>, and implementations
		/// of <c>IInternetProtocolInfo::ParseUrl</c>.
		/// </summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775138%28v%3dvs.85%29
		// typedef enum _tagPARSEACTION { PARSE_CANONICALIZE = 1, PARSE_FRIENDLY, PARSE_SECURITY_URL, PARSE_ROOTDOCUMENT, PARSE_DOCUMENT,
		// PARSE_ANCHOR, PARSE_ENCODE, PARSE_DECODE, PARSE_PATH_FROM_URL, PARSE_URL_FROM_PATH, PARSE_MIME, PARSE_SERVER, PARSE_SCHEMA,
		// PARSE_SITE, PARSE_DOMAIN, PARSE_LOCATION, PARSE_SECURITY_DOMAIN, PARSE_ESCAPE, PARSE_UNESCAPE } PARSEACTION;
		[PInvokeData("Urlmon.h")]
		public enum PARSEACTION
		{
			/// <summary>Canonicalize the URL.</summary>
			PARSE_CANONICALIZE = 1,

			/// <summary>Retrieve a URL suitable for display.</summary>
			PARSE_FRIENDLY,

			/// <summary>
			/// Retrieve the URL that should be used by a security manager to make security decisions. The method should either return a
			/// security domain or map the input URL to a known protocol (such as HTTP). See also PARSE_SECURITY_DOMAIN.
			/// </summary>
			PARSE_SECURITY_URL,

			/// <summary>
			/// Retrieve the scheme and hostname, only.
			/// <para>Internet Explorer 7 and later. CoInternetParseIUri also returns user name, password, and port.</para>
			/// </summary>
			PARSE_ROOTDOCUMENT,

			/// <summary>Retrieve everything prior to the fragment (named anchor) part of the URL.</summary>
			PARSE_DOCUMENT,

			/// <summary>Retrieve the fragment (named anchor), including the delimiting number sign (#).</summary>
			PARSE_ANCHOR,

			/// <summary>
			/// Unescape the URL. Deprecated in Internet Explorer 8; use PARSE_UNESCAPE instead. To enforce deprecation, #define URLMON_STRICT.
			/// </summary>
			PARSE_ENCODE,

			/// <summary>
			/// Escape the URL. Deprecated in Internet Explorer 8; use PARSE_ESCAPE instead. To enforce deprecation, #define URLMON_STRICT.
			/// </summary>
			PARSE_DECODE,

			/// <summary>Retrieve a DOS file path from a file:// URL.</summary>
			PARSE_PATH_FROM_URL,

			/// <summary>Create a file:// URL from the specified DOS file path.</summary>
			PARSE_URL_FROM_PATH,

			/// <summary>Return the MIME type of this URL based on its file name extension. Not supported by CoInternetParseUrl or CoInternetParseIUri.</summary>
			PARSE_MIME,

			/// <summary>Return the server name. Not supported by CoInternetParseUrl or CoInternetParseIUri.</summary>
			PARSE_SERVER,

			/// <summary>Retrieve the URL scheme for this URL, for example http.</summary>
			PARSE_SCHEMA,

			/// <summary>Retrieve the hostname associated with this URL, for example www.microsoft.com.</summary>
			PARSE_SITE,

			/// <summary>Retrieve the domain associated with this URL.</summary>
			PARSE_DOMAIN,

			/// <summary>Same as PARSE_ANCHOR.</summary>
			PARSE_LOCATION,

			/// <summary>Retrieve the security form of the URL, as scheme:host.</summary>
			PARSE_SECURITY_DOMAIN,

			/// <summary>Percent-encode the URL. Convert reserved characters to escape sequences.</summary>
			PARSE_ESCAPE,

			/// <summary>Decode a percent-encoded URL. Convert escape sequences to the characters they represent.</summary>
			PARSE_UNESCAPE
		}

		/// <summary>Contains the available query options for <c>CoInternetQueryInfo</c>.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775139%28v%3dvs.85%29
		// typedef enum _tagQUERYOPTION { QUERY_EXPIRATION_DATE = 1, QUERY_TIME_OF_LAST_CHANGE, QUERY_CONTENT_ENCODING, QUERY_CONTENT_TYPE,
		// QUERY_REFRESH, QUERY_RECOMBINE, QUERY_CAN_NAVIGATE, QUERY_USES_NETWORK, QUERY_IS_CACHED, QUERY_IS_INSTALLEDENTRY,
		// QUERY_IS_CACHED_OR_MAPPED, QUERY_USES_CACHE, QUERY_IS_SECURE, QUERY_IS_SAFE, QUERY_USES_HISTORYFOLDER,
		// QUERY_IS_CACHED_AND_USABLE_OFFLINE } QUERYOPTION;
		[PInvokeData("Urlmon.h")]
		public enum QUERYOPTION
		{
			/// <summary>Request the expiration date in a SYSTEMTIME format.</summary>
			QUERY_EXPIRATION_DATE = 1,

			/// <summary>Request the last changed date in a SYSTEMTIME format.</summary>
			QUERY_TIME_OF_LAST_CHANGE,

			/// <summary>Request the content encoding schema.</summary>
			QUERY_CONTENT_ENCODING,

			/// <summary>Request the content type header.</summary>
			QUERY_CONTENT_TYPE,

			/// <summary>Request a refresh.</summary>
			QUERY_REFRESH,

			/// <summary>Combine the page URL with the nearest base URL if TRUE.</summary>
			QUERY_RECOMBINE,

			/// <summary>Check if the protocol can navigate.</summary>
			QUERY_CAN_NAVIGATE,

			/// <summary>Check if the URL needs to access the network.</summary>
			QUERY_USES_NETWORK,

			/// <summary>Check if the resource is cached locally.</summary>
			QUERY_IS_CACHED,

			/// <summary>Check if this resource is installed locally on a CD-ROM.</summary>
			QUERY_IS_INSTALLEDENTRY,

			/// <summary>Check if this resource is stored in the cache or if it is on a mapped drive (in a cache container).</summary>
			QUERY_IS_CACHED_OR_MAPPED,

			/// <summary>Check if the specified protocol uses the Internet cache.</summary>
			QUERY_USES_CACHE,

			/// <summary>Check if the protocol is encrypted.</summary>
			QUERY_IS_SECURE,

			/// <summary>Check if the protocol only serves trusted content.</summary>
			QUERY_IS_SAFE,

			/// <summary>Internet Explorer 7. Check whether the URLs from this protocol appear in history.</summary>
			QUERY_USES_HISTORYFOLDER,

			/// <summary>
			/// Internet Explorer 9. If the cache entry is available and can be used offline (not expired or flagged to revalidate), then
			/// CoInternetQueryInfo returns TRUE in pvBuffer; FALSE otherwise.
			/// </summary>
			QUERY_IS_CACHED_AND_USABLE_OFFLINE
		}

		/// <summary>Flags used by <see cref="CreateUri"/>.</summary>
		[PInvokeData("Urlmon.h")]
		public enum Uri_CREATE
		{
			/// <summary>Default. If the scheme is unspecified and not implicitly "file," assume relative.</summary>
			Uri_CREATE_ALLOW_RELATIVE = 0x0001,

			/// <summary>If the scheme is unspecified and not implicitly "file," assume wildcard.</summary>
			Uri_CREATE_ALLOW_IMPLICIT_WILDCARD_SCHEME = 0x0002,

			/// <summary>Default. If the scheme is unspecified and URI starts with a drive letter (X:) or UNC path (\\), assume "file."</summary>
			Uri_CREATE_ALLOW_IMPLICIT_FILE_SCHEME = 0x0004,

			/// <summary>If there is a query string, don't look for a fragment.</summary>
			Uri_CREATE_NOFRAG = 0x0008,

			/// <summary>Do not canonicalize the scheme, host, authority, path, query, or fragment.</summary>
			Uri_CREATE_NO_CANONICALIZE = 0x0010,

			/// <summary>Default. Canonicalize the scheme, host, authority, path, query, and fragment.</summary>
			Uri_CREATE_CANONICALIZE = 0x0100,

			/// <summary>Use DOS path compatibility mode to create "file" URIs.</summary>
			Uri_CREATE_FILE_USE_DOS_PATH = 0x0020,

			/// <summary>
			/// Default. Perform the percent-encoding and percent-decoding canonicalizations on the query and fragment. This flag takes
			/// precedence over Uri_CREATE_NO_CANONICALIZE.
			/// </summary>
			Uri_CREATE_DECODE_EXTRA_INFO = 0x0040,

			/// <summary>
			/// Do not perform the percent-encoding or percent-decoding canonicalizations on the query and fragment. This flag takes
			/// precedence over Uri_CREATE_CANONICALIZE.
			/// </summary>
			Uri_CREATE_NO_DECODE_EXTRA_INFO = 0x0080,

			/// <summary>Default. Hierarchical URIs with unrecognized schemes will be treated like hierarchical URIs.</summary>
			Uri_CREATE_CRACK_UNKNOWN_SCHEMES = 0x0200,

			/// <summary>Hierarchical URIs with unrecognized schemes will be treated like opaque URIs.</summary>
			Uri_CREATE_NO_CRACK_UNKNOWN_SCHEMES = 0x0400,

			/// <summary>
			/// Default. Perform preprocessing on the URI to remove control characters and white space, as if the URI had come from the raw
			/// href value of an HTML page.
			/// </summary>
			Uri_CREATE_PRE_PROCESS_HTML_URI = 0x0800,

			/// <summary>Do not perform preprocessing to remove control characters and white space as appropriate.</summary>
			Uri_CREATE_NO_PRE_PROCESS_HTML_URI = 0x1000,

			/// <summary>Use Internet Explorer registry settings to determine default URL-parsing behavior.</summary>
			Uri_CREATE_IE_SETTINGS = 0x2000,

			/// <summary>Default. Do not use Internet Explorer registry settings.</summary>
			Uri_CREATE_NO_IE_SETTINGS = 0x4000,

			/// <summary>
			/// Do not percent-encode characters that are forbidden by RFC-3986. Use with Uri_CREATE_FILE_USE_DOS_PATH to create file monikers.
			/// </summary>
			Uri_CREATE_NO_ENCODE_FORBIDDEN_CHARACTERS = 0x8000,

			/// <summary>
			/// Default. Percent encode all extended Unicode characters, then decode all percent encoded extended Unicode characters (except
			/// those identified as dangerous).
			/// </summary>
			Uri_CREATE_NORMALIZE_INTL_CHARACTERS = 0x00010000,
		}

		/// <summary>Used by <see cref="IUri.GetPropertyBSTR"/>.</summary>
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum Uri_DISPLAY
		{
			/// <summary>Uri_PROPERTY_DISPLAY_URI: Exclude the fragment portion of the URI, if any.</summary>
			Uri_DISPLAY_NO_FRAGMENT = 0x00000001,

			/// <summary>
			/// Uri_PROPERTY_ABSOLUTE_URI, Uri_PROPERTY_DOMAIN, Uri_PROPERTY_HOST: If the URI is an IDN, always display the hostname encoded
			/// as punycode.
			/// </summary>
			Uri_PUNYCODE_IDN_HOST = 0x00000002,

			/// <summary>
			/// Uri_PROPERTY_ABSOLUTE_URI, Uri_PROPERTY_DOMAIN, Uri_PROPERTY_HOST: Display the hostname in punycode or Unicode as it would
			/// appear in the Uri_PROPERTY_DISPLAY_URI property.
			/// </summary>
			Uri_DISPLAY_IDN_HOST = 0x00000004,
		}

		/// <summary>Specify the encoding of all applicable components, except the scheme and the port.</summary>
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum Uri_ENCODING
		{
			/// <summary>Default. The user info component and path component use percent encoded UTF-8.</summary>
			Uri_ENCODING_USER_INFO_AND_PATH_IS_PERCENT_ENCODED_UTF8 = 0x00000001,

			/// <summary>The user info component and path component use the codepage specified in dwCodePage.</summary>
			Uri_ENCODING_USER_INFO_AND_PATH_IS_CP = 0x00000002,

			/// <summary>Default. The host component uses IDN (Punycode) format.</summary>
			Uri_ENCODING_HOST_IS_IDN = 0x00000004,

			/// <summary>The host component uses percent encoded UTF-8.</summary>
			Uri_ENCODING_HOST_IS_PERCENT_ENCODED_UTF8 = 0x00000008,

			/// <summary>The host component uses the codepage specified in dwCodePage.</summary>
			Uri_ENCODING_HOST_IS_PERCENT_ENCODED_CP = 0x00000010,

			/// <summary>Default. The query and fragment components use percent encoded UTF-8.</summary>
			Uri_ENCODING_QUERY_AND_FRAGMENT_IS_PERCENT_ENCODED_UTF8 = 0x00000020,

			/// <summary>The query and fragment components use the codepage specified in dwCodePage.</summary>
			Uri_ENCODING_QUERY_AND_FRAGMENT_IS_CP = 0x00000040,

			/// <summary>
			/// The URI meets the requirements of RFC 3490. This flag combines the preceding default flags: Uri_ENCODING_HOST_IS_IDN,
			/// Uri_ENCODING_USER_INFO_AND_PATH_IS_PERCENT_ENCODED_UTF8, and Uri_ENCODING_QUERY_AND_FRAGMENT_IS_PERCENT_ENCODED_UTF8.
			/// </summary>
			Uri_ENCODING_RFC = Uri_ENCODING_USER_INFO_AND_PATH_IS_PERCENT_ENCODED_UTF8 | Uri_ENCODING_HOST_IS_PERCENT_ENCODED_UTF8 | Uri_ENCODING_QUERY_AND_FRAGMENT_IS_PERCENT_ENCODED_UTF8
		}

		/// <summary>Used by <see cref="IUri.GetProperties"/>.</summary>
		[PInvokeData("Urlmon.h")]
		[Flags]
		public enum Uri_HAS : uint
		{
			/// <summary>Uri_PROPERTY_ABSOLUTE_URI exists.</summary>
			Uri_HAS_ABSOLUTE_URI = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_ABSOLUTE_URI,

			/// <summary>Uri_PROPERTY_AUTHORITY exists.</summary>
			Uri_HAS_AUTHORITY = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_AUTHORITY,

			/// <summary>Uri_PROPERTY_DISPLAY_URI exists.</summary>
			Uri_HAS_DISPLAY_URI = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_DISPLAY_URI,

			/// <summary>Uri_PROPERTY_DOMAIN exists.</summary>
			Uri_HAS_DOMAIN = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_DOMAIN,

			/// <summary>Uri_PROPERTY_EXTENSION exists.</summary>
			Uri_HAS_EXTENSION = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_EXTENSION,

			/// <summary>Uri_PROPERTY_FRAGMENT exists.</summary>
			Uri_HAS_FRAGMENT = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_FRAGMENT,

			/// <summary>Uri_PROPERTY_HOST exists.</summary>
			Uri_HAS_HOST = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_HOST,

			/// <summary>Uri_PROPERTY_PASSWORD exists.</summary>
			Uri_HAS_PASSWORD = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_PASSWORD,

			/// <summary>Uri_PROPERTY_PATH exists.</summary>
			Uri_HAS_PATH = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_PATH,

			/// <summary>Uri_PROPERTY_QUERY exists.</summary>
			Uri_HAS_QUERY = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_QUERY,

			/// <summary>Uri_PROPERTY_RAW_URI exists.</summary>
			Uri_HAS_RAW_URI = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_RAW_URI,

			/// <summary>Uri_PROPERTY_SCHEME_NAME exists.</summary>
			Uri_HAS_SCHEME_NAME = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_SCHEME_NAME,

			/// <summary>Uri_PROPERTY_USER_NAME exists.</summary>
			Uri_HAS_USER_NAME = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_USER_NAME,

			/// <summary>Uri_PROPERTY_PATH_AND_QUERY exists.</summary>
			Uri_HAS_PATH_AND_QUERY = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_PATH_AND_QUERY,

			/// <summary>Uri_PROPERTY_USER_INFO exists.</summary>
			Uri_HAS_USER_INFO = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_USER_INFO,

			/// <summary>Uri_PROPERTY_HOST_TYPE exists.</summary>
			Uri_HAS_HOST_TYPE = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_HOST_TYPE,

			/// <summary>Uri_PROPERTY_PORT exists.</summary>
			Uri_HAS_PORT = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_PORT,

			/// <summary>Uri_PROPERTY_SCHEME exists.</summary>
			Uri_HAS_SCHEME = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_SCHEME,

			/// <summary>Uri_PROPERTY_ZONE exists.</summary>
			Uri_HAS_ZONE = 1 << (int)Uri_PROPERTY.Uri_PROPERTY_ZONE,
		}

		/// <summary>Describes the format of the specified host in a Uniform Resource Identifier (URI).</summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775140%28v%3dvs.85%29
		// typedef enum { Uri_HOST_UNKNOWN = 0, Uri_HOST_DNS = 1, Uri_HOST_IPV4 = 2, Uri_HOST_IPV6 = 3, Uri_HOST_IDN = 4 } Uri_HOST_TYPE;
		[PInvokeData("Urlmon.h")]
		public enum Uri_HOST_TYPE
		{
			/// <summary>Indicates an unrecognized (or future version) format.</summary>
			Uri_HOST_UNKNOWN = 0,

			/// <summary>Indicates a textual DNS naming convention.</summary>
			Uri_HOST_DNS = 1,

			/// <summary>Indicates an IPv4 host format.</summary>
			Uri_HOST_IPV4 = 2,

			/// <summary>Indicates an IPv6 host format.</summary>
			Uri_HOST_IPV6 = 3,

			/// <summary>Indicates an IDN.</summary>
			Uri_HOST_IDN = 4
		}

		/// <summary>
		/// Represents properties that an <c>IUri</c> can contain. The properties in the range Uri_PROPERTY_STRING_START to
		/// Uri_PROPERTY_STRING_LAST are strings and the rest are DWORD values.
		/// </summary>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775141%28v%3dvs.85%29
		// typedef enum { Uri_PROPERTY_ABSOLUTE_URI = 0, Uri_PROPERTY_STRING_START = Uri_PROPERTY_ABSOLUTE_URI, Uri_PROPERTY_AUTHORITY = 1,
		// Uri_PROPERTY_DISPLAY_URI = 2, Uri_PROPERTY_DOMAIN = 3, Uri_PROPERTY_EXTENSION = 4, Uri_PROPERTY_FRAGMENT = 5, Uri_PROPERTY_HOST =
		// 6, Uri_PROPERTY_PASSWORD = 7, Uri_PROPERTY_PATH = 8, Uri_PROPERTY_PATH_AND_QUERY = 9, Uri_PROPERTY_QUERY = 10,
		// Uri_PROPERTY_RAW_URI = 11, Uri_PROPERTY_SCHEME_NAME = 12, Uri_PROPERTY_USER_INFO = 13, Uri_PROPERTY_USER_NAME = 14,
		// Uri_PROPERTY_STRING_LAST = Uri_PROPERTY_USER_NAME, Uri_PROPERTY_HOST_TYPE = 15, Uri_PROPERTY_DWORD_START =
		// Uri_PROPERTY_HOST_TYPE, Uri_PROPERTY_PORT = 16, Uri_PROPERTY_SCHEME = 17, Uri_PROPERTY_ZONE = 18, Uri_PROPERTY_DWORD_LAST =
		// Uri_PROPERTY_ZONE } Uri_PROPERTY;
		[PInvokeData("Urlmon.h")]
		public enum Uri_PROPERTY : uint
		{
			/// <summary>Includes the entire canonicalized URI. This property is not defined for relative URLs. See also Uri_PROPERTY_RAW_URI.</summary>
			Uri_PROPERTY_ABSOLUTE_URI = 0,

			/// <summary>Designates the first string property.</summary>
			Uri_PROPERTY_STRING_START = 0,

			/// <summary>
			/// Combines user name, password, fully qualified domain name, and port number. If user name and password are not specified, the
			/// separator characters (: and @) are removed. The trailing colon is also removed if the port number is not specified or is the
			/// default for the protocol scheme.
			/// </summary>
			Uri_PROPERTY_AUTHORITY = 1,

			/// <summary>
			/// Combines protocol scheme, fully qualified domain name, port number, full path, query string, and (optionally) fragment.
			/// (Pass the Uri_DISPLAY_NO_FRAGMENT flag to get one or more of the following methods to hide the fragment portion:
			/// IUri::GetPropertyBSTR and IUri::GetPropertyLength.) If the scheme is unrecognized, the user name and password will also be displayed.
			/// <para>
			/// <c>Note</c> The display URI may have additional formatting applied to it, such that the string produced by
			/// IUri::GetDisplayUri isn't necessarily a valid URI. For this reason, and since the userinfo is not present, the display URI
			/// should be used for viewing only; it should not be used for edit by the user, or as a form of transfer for URIs inside or
			/// between applications.
			/// </para>
			/// </summary>
			Uri_PROPERTY_DISPLAY_URI = 2,

			/// <summary>
			/// Indicates the private domain name and public suffix (top-level domain) only. If the URL contains only a plain hostname (for
			/// example, "http://example/") or public suffix (for example, "http://co.uk/"), then Uri_PROPERTY_DOMAIN is NULL; use
			/// Uri_PROPERTY_HOST instead.
			/// </summary>
			Uri_PROPERTY_DOMAIN = 3,

			/// <summary>Indicates the file name extension only.</summary>
			Uri_PROPERTY_EXTENSION = 4,

			/// <summary>Indicates the fragment (secondary resource, or named anchor identifier) only.</summary>
			Uri_PROPERTY_FRAGMENT = 5,

			/// <summary>Indicates the fully qualified domain name or plain hostname. See also Uri_PROPERTY_DOMAIN.</summary>
			Uri_PROPERTY_HOST = 6,

			/// <summary>Indicates the password only, as parsed from the URI. Prompted credentials do not appear here.</summary>
			Uri_PROPERTY_PASSWORD = 7,

			/// <summary>Indicates the path and resource.</summary>
			Uri_PROPERTY_PATH = 8,

			/// <summary>Combines full path to resource with URI query string.</summary>
			Uri_PROPERTY_PATH_AND_QUERY = 9,

			/// <summary>
			/// Indicates the query (or search) string. The search string may be canonicalized by CreateUri if the Uri_CREATE_DECODE_EXTRA
			/// flag was used; however, no other encoding or decoding is performed.
			/// </summary>
			Uri_PROPERTY_QUERY = 10,

			/// <summary>
			/// Includes the entire original URI as entered. Note that character %61 is lowercase A in the following example. See also Uri_PROPERTY_ABSOLUTE_URI.
			/// </summary>
			Uri_PROPERTY_RAW_URI = 11,

			/// <summary>Indicates the protocol scheme name. See also Uri_PROPERTY_SCHEME.</summary>
			Uri_PROPERTY_SCHEME_NAME = 12,

			/// <summary>
			/// Combines user name and password as parsed from the URI. String does not include colon (:) if password is not present.
			/// </summary>
			Uri_PROPERTY_USER_INFO = 13,

			/// <summary>Designates the final string property.</summary>
			Uri_PROPERTY_STRING_LAST = 14,

			/// <summary>Indicates the user name only, as parsed from the URI. Prompted credentials do not appear here.</summary>
			Uri_PROPERTY_USER_NAME = 14,

			/// <summary>Designates the first numerical property.</summary>
			Uri_PROPERTY_DWORD_START = 15,

			/// <summary>Returns a value from the Uri_HOST_TYPE enumeration.</summary>
			Uri_PROPERTY_HOST_TYPE = 15,

			/// <summary>Indicates the port number only.</summary>
			Uri_PROPERTY_PORT = 16,

			/// <summary>Returns a value from the URL_SCHEME enumeration. See also Uri_PROPERTY_SCHEME_NAME.</summary>
			Uri_PROPERTY_SCHEME = 17,

			/// <summary>Designates the final numerical property.</summary>
			Uri_PROPERTY_DWORD_LAST = 18,

			/// <summary>
			/// Not implemented. To calculate the zone of a URI object, pass the URI to the IInternetSecurityManagerEx2::MapUrlToZoneEx2 method.
			/// </summary>
			Uri_PROPERTY_ZONE = 18
		}

		/// <summary>Specifies which URL parser to use.</summary>
		[PInvokeData("Urlmon.h")]
		public enum URL_MK
		{
			/// <summary>Use the same URL parser as <c>CreateURLMoniker</c>.</summary>
			URL_MK_LEGACY = 0,

			/// <summary>Use the updated URL parser.</summary>
			URL_MK_UNIFORM = 1,

			/// <summary>Do not attempt to convert the URL moniker to the standard format.</summary>
			URL_MK_NO_CANONICALIZE = 2,
		}

		/// <summary>Used to specify URL schemes.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/shlwapi/ne-shlwapi-url_scheme typedef enum { URL_SCHEME_INVALID,
		// URL_SCHEME_UNKNOWN, URL_SCHEME_FTP, URL_SCHEME_HTTP, URL_SCHEME_GOPHER, URL_SCHEME_MAILTO, URL_SCHEME_NEWS, URL_SCHEME_NNTP,
		// URL_SCHEME_TELNET, URL_SCHEME_WAIS, URL_SCHEME_FILE, URL_SCHEME_MK, URL_SCHEME_HTTPS, URL_SCHEME_SHELL, URL_SCHEME_SNEWS,
		// URL_SCHEME_LOCAL, URL_SCHEME_JAVASCRIPT, URL_SCHEME_VBSCRIPT, URL_SCHEME_ABOUT, URL_SCHEME_RES, URL_SCHEME_MSSHELLROOTED,
		// URL_SCHEME_MSSHELLIDLIST, URL_SCHEME_MSHELP, URL_SCHEME_MSSHELLDEVICE, URL_SCHEME_WILDCARD, URL_SCHEME_SEARCH_MS,
		// URL_SCHEME_SEARCH, URL_SCHEME_KNOWNFOLDER, URL_SCHEME_MAXVALUE } ;
		[PInvokeData("shlwapi.h", MSDNShortId = "45686920-356d-4dd7-8482-2427854a92ed")]
		public enum URL_SCHEME
		{
			/// <summary>An invalid scheme.</summary>
			URL_SCHEME_INVALID,

			/// <summary>An unknown scheme.</summary>
			URL_SCHEME_UNKNOWN,

			/// <summary>FTP (ftp:).</summary>
			URL_SCHEME_FTP,

			/// <summary>HTTP (http:).</summary>
			URL_SCHEME_HTTP,

			/// <summary>Gopher (gopher:).</summary>
			URL_SCHEME_GOPHER,

			/// <summary>Mail-to (mailto:).</summary>
			URL_SCHEME_MAILTO,

			/// <summary>Usenet news (news:).</summary>
			URL_SCHEME_NEWS,

			/// <summary>Usenet news with NNTP (nntp:).</summary>
			URL_SCHEME_NNTP,

			/// <summary>Telnet (telnet:).</summary>
			URL_SCHEME_TELNET,

			/// <summary>Wide Area Information Server (wais:).</summary>
			URL_SCHEME_WAIS,

			/// <summary>File (file:).</summary>
			URL_SCHEME_FILE,

			/// <summary>URL moniker (mk:).</summary>
			URL_SCHEME_MK,

			/// <summary>URL HTTPS (https:).</summary>
			URL_SCHEME_HTTPS,

			/// <summary>Shell (shell:).</summary>
			URL_SCHEME_SHELL,

			/// <summary>NNTP news postings with SSL (snews:).</summary>
			URL_SCHEME_SNEWS,

			/// <summary>Local (local:).</summary>
			URL_SCHEME_LOCAL,

			/// <summary>JavaScript (javascript:).</summary>
			URL_SCHEME_JAVASCRIPT,

			/// <summary>VBScript (vbscript:).</summary>
			URL_SCHEME_VBSCRIPT,

			/// <summary>About (about:).</summary>
			URL_SCHEME_ABOUT,

			/// <summary>Res (res:).</summary>
			URL_SCHEME_RES,

			/// <summary>Internet Explorer 6 and later only. Shell-rooted (ms-shell-rooted:)</summary>
			URL_SCHEME_MSSHELLROOTED,

			/// <summary>Internet Explorer 6 and later only. Shell ID-list (ms-shell-idlist:).</summary>
			URL_SCHEME_MSSHELLIDLIST,

			/// <summary>Internet Explorer 6 and later only. MSHelp (hcp:).</summary>
			URL_SCHEME_MSHELP,

			/// <summary>Not supported.</summary>
			URL_SCHEME_MSSHELLDEVICE,

			/// <summary>Internet Explorer 7 and later only. Wildcard (*:).</summary>
			URL_SCHEME_WILDCARD,

			/// <summary>Windows Vista and later only. Search-MS (search-ms:).</summary>
			URL_SCHEME_SEARCH_MS,

			/// <summary>Windows Vista with SP1 and later only. Search (search:).</summary>
			URL_SCHEME_SEARCH,

			/// <summary>Windows 7 and later. Known folder (knownfolder:).</summary>
			URL_SCHEME_KNOWNFOLDER,

			/// <summary>The highest legitimate value in the enumeration, used for validation purposes.</summary>
			URL_SCHEME_MAXVALUE,
		}

		/// <summary>Installs the specified component.</summary>
		/// <param name="szDistUnit">A pointer to a string that specifies the name of the component.</param>
		/// <param name="szTYPE">
		/// A pointer to a string that specifies the MIME type of the component. This parameter is used to generate a CLSID for the component.
		/// </param>
		/// <param name="szExt">
		/// A pointer to a string that specifies the extension. If szTYPE is not specified, this parameter is used to generate a CLSID for
		/// this component.
		/// </param>
		/// <param name="dwFileVersionMS">
		/// A value of type <c>DWORD</c> that specifies the major version number of the component. When the version is indicated by four
		/// words, ; dwFileVersionMS indicates with the high-order word and with the low-order word.
		/// </param>
		/// <param name="dwFileVersionLS">
		/// A value of type <c>DWORD</c> that specifies the minor version number of the component. When the version is indicated by four
		/// words, ; dwFileVersionLS indicates with the high-order word and with the low-order word.
		/// </param>
		/// <param name="szURL">A pointer to a string that specifies the URL of the component.</param>
		/// <param name="pbc">A pointer to an IBindCtx interface that specifies the binding context for this operation.</param>
		/// <param name="pvReserved"/>
		/// <param name="flags">
		/// <para>A value of type <c>DWORD</c> that specifies one of the following flags.</para>
		/// <para><c>0x00</c> (0x00)</para>
		/// <para>
		/// Download the component if the version specified by dwFileVersionMS and dwFileVersionLS is more recent then the currently
		/// installed version.
		/// </para>
		/// <para><c>0x01</c> (0x01)</para>
		/// <para>Download the component regardless of the currently installed version.</para>
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775082(v%3Dvs.85)
		// HRESULT AsyncInstallDistributionUnit( LPCWSTR szDistUnit, LPCWSTR szTYPE, LPCWSTR szExt, DWORD dwFileVersionMS, DWORD
		// dwFileVersionLS, LPCWSTR szURL, IBindCtx *pbc, _Reserved_ LPVOID pvReserved, DWORD flags );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT AsyncInstallDistributionUnit([MarshalAs(UnmanagedType.LPWStr)] string szDistUnit, [Optional, MarshalAs(UnmanagedType.LPWStr)] string szTYPE,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string szExt, uint dwFileVersionMS, uint dwFileVersionLS, [Optional, MarshalAs(UnmanagedType.LPWStr)] string szURL,
			IBindCtx pbc, [Optional] IntPtr pvReserved, uint flags);

		/// <summary>Returns a factory object for a given <c>CLSID</c>.</summary>
		/// <param name="rclsid">
		/// The CLSID of the ActiveX object to install. If the value is CLSID_NULL, szContentType is used to determine the CLSID.
		/// </param>
		/// <param name="szCodeURL">The address of a string value that contains the full URL of the code for the ActiveX object.</param>
		/// <param name="dwFileVersionMS">
		/// An unsigned long integer value that contains the major version number for the object to be installed. If this value and the
		/// value for dwFileVersionLS are both 0xFFFFFFFF, the latest version of the code should always be installed. This means that
		/// Internet Component Download will always attempt to download new code.
		/// </param>
		/// <param name="dwFileVersionLS">
		/// An unsigned long integer value that contains the minor version number for the object to be installed. If this value and the
		/// value for dwFileVersionMS are both 0xFFFFFFFF, the latest version of the code should always be installed. This means that
		/// Internet Component Download will always attempt to download new code.
		/// </param>
		/// <param name="szContentType">
		/// A pointer to a string value that contains the MIME type to be understood by the installed ActiveX object. If rclsid is
		/// CLSID_NULL, this string is used to determine the CLSID of the object to install. Note that this parameter is useful only when
		/// you try to download a viewer for a particular media type; when the MIME type of media is known, but the CLSID is not.
		/// </param>
		/// <param name="pBindCtx">
		/// A pointer to the bind context to use for downloading or installing component code. An implementation of IBindStatusCallback must
		/// be registered on this bind context before you can call this function.
		/// </param>
		/// <param name="dwClsContext">
		/// An unsigned long integer value that specifies the execution context for the class object. This can be one of the values taken
		/// from the CLSCTX enumeration.
		/// </param>
		/// <param name="pvReserved">Reserved. Must be set to NULL.</param>
		/// <param name="riid">The reference identifier of the interface to obtain on the factory object. Usually, this interface is IClassFactory.</param>
		/// <param name="ppv">The interface pointer for synchronous calls, or NULL otherwise.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully, and the ppv parameter contains the requested interface pointer.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The requested interface pointer is not available.</term>
		/// </item>
		/// <item>
		/// <term>MK_S_ASYNCHRONOUS</term>
		/// <term>
		/// Component code will be downloaded and installed asynchronously. The client will receive notifications through the
		/// IBindStatusCallback interface registered on pBindCtx.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If no <c>CLSID</c> is specified (CLSID_NULL), the <c>CoGetClassObjectFromURL</c> function chooses the appropriate <c>CLSID</c>
		/// for interpreting the MIME type specified in szContentType. If the specified object is installed on the system, it is
		/// instantiated. Otherwise, the necessary code is downloaded and installed from the location specified in szCodeURL.
		/// </para>
		/// <para>
		/// The <c>CoGetClassObjectFromURL</c> function was designed to be used by MSHTML to retrieve the code for objects on a Web page.
		/// When the requested object is available for use on the user's computer, this function returns synchronously with a valid object
		/// reference. For objects that aren't available on the user's computer and must be downloaded from szCodeURL, the
		/// <c>CoGetClassObjectFromURL</c> function returns asynchronously with MK_S_ASNYNCHRONOUS and notifies the calling application
		/// through the <c>IBindStatusCallback</c> interface that was registered on pBindCtx.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775083(v=vs.85) HRESULT
		// CoGetClassObjectFromURL( _In_ REFCLSID rclsid, _In_ LPCWSTR szCodeURL, _In_ DWORD dwFileVersionMS, _In_ DWORD dwFileVersionLS,
		// _In_ LPCWSTR szContentType, _In_ LPBINDCTX pBindCtx, _In_ DWORD dwClsContext, _Reserved_ LPVOID pvReserved, _In_ REFIID riid,
		// _Out_ VOID **ppv );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoGetClassObjectFromURL(in Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string szCodeURL, uint dwFileVersionMS,
			uint dwFileVersionLS, [MarshalAs(UnmanagedType.LPWStr)] string szContentType, IBindCtx pBindCtx, CLSCTX dwClsContext,
			[Optional] IntPtr pvReserved, in Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);

		/// <summary>Combines a base Uniform Resource Identifier (URI) and a relative URI into a full URI.</summary>
		/// <param name="pBaseUri">A pointer to the <c>IUri</c> interface of the base URI.</param>
		/// <param name="pRelativeUri">A pointer to the <c>IUri</c> interface of the relative URI.</param>
		/// <param name="dwCombineFlags">
		/// <para>An unsigned long integer value that combines one or more of the following flags.</para>
		/// <para><c>URL_DONT_SIMPLIFY</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_NO_CANONICALIZE</c>.</para>
		/// <para><c>URL_DONT_UNESCAPE_EXTRA_INFO</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_NO_DECODE_EXTRA_INFO</c>.</para>
		/// <para><c>URL_FILE_USE_PATHURL</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_FILE_USE_DOS_PATH</c>.</para>
		/// </param>
		/// <param name="ppCombinedUri">
		/// A pointer to an <c>IUri</c> interface that receives the newly created combined URI. The client must call Release on the returned pointer.
		/// </param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to create the new IUri.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The following examples demonstrate the effect of combining a base URI and a relative URI. Note that the first example ends in a
		/// resource, and the second example ends in a path segment.
		/// </para>
		/// <para>
		/// For more information on the algorithm used to combine a base URI and a relative URI, refer to RFC-3986 Section 5.2, "Relative Resolution."
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775084(v=vs.85) HRESULT
		// CoInternetCombineIUri( IUri *pBaseUri, IUri *pRelativeUri, DWORD dwCombineFlags, IUri **ppCombinedUri, _Reserved_ DWORD_PTR
		// dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetCombineIUri(IUri pBaseUri, IUri pRelativeUri, Uri_CREATE dwCombineFlags, out IUri ppCombinedUri, [Optional] IntPtr dwReserved);

		/// <summary>Combines a base URL and a relative URL into a full URL.</summary>
		/// <param name="pwzBaseUrl">A pointer to a string value containing the base URL.</param>
		/// <param name="pwzRelativeUrl">A pointer to a string value containing the relative URL.</param>
		/// <param name="dwCombineFlags">
		/// <para>An unsigned long integer value that combines one or more of the following flags.</para>
		/// <para><c>URL_DONT_SIMPLIFY</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_NO_CANONICALIZE</c>.</para>
		/// <para><c>URL_DONT_UNESCAPE_EXTRA_INFO</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_NO_DECODE_EXTRA_INFO</c>.</para>
		/// <para><c>URL_FILE_USE_PATHURL</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_FILE_USE_DOS_PATH</c>.</para>
		/// </param>
		/// <param name="pwzResult">A pointer to a string variable where the full URL will be stored.</param>
		/// <param name="cchResult">An unsigned long integer value that contains the size of the buffer.</param>
		/// <param name="pcchResult">
		/// A pointer to an unsigned long integer value that receives the number of characters returned in pwzResult. Count does not include
		/// the terminating NULL character.
		/// </param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The buffer is too small to contain the resulting URL.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>pwzResult is NULL, or the buffer is too small.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The return value of this function differs depending on the protocol handler implementation used to perform the combine
		/// operation. If the function fails because the output buffer is too small, the number returned in pcchResult is the length in
		/// bytes required to hold the result, including the terminating <c>NULL</c> character.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775085(v=vs.85) HRESULT
		// CoInternetCombineUrl( LPCWSTR pwzBaseUrl, LPCWSTR pwzRelativeUrl, DWORD dwCombineFlags, LPWSTR pwzResult, DWORD cchResult, DWORD
		// *pcchResult, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetCombineUrl([MarshalAs(UnmanagedType.LPWStr)] string pwzBaseUrl, [MarshalAs(UnmanagedType.LPWStr)] string pwzRelativeUrl,
			Uri_CREATE dwCombineFlags, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwzResult, uint cchResult, out uint pcchResult, [Optional] uint dwReserved);

		/// <summary>Combines a base URL and a relative URL into a full Uniform Resource Identifier (URI).</summary>
		/// <param name="pBaseUri">A pointer to an <c>IUri</c> interface containing the base URI.</param>
		/// <param name="pwzRelativeUrl">A pointer to a string value containing the relative URL.</param>
		/// <param name="dwCombineFlags">
		/// <para>An unsigned long integer value that combines one or more of the following flags.</para>
		/// <para><c>URL_DONT_SIMPLIFY</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_NO_CANONICALIZE</c>.</para>
		/// <para><c>URL_DONT_UNESCAPE_EXTRA_INFO</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_NO_DECODE_EXTRA_INFO</c>.</para>
		/// <para><c>URL_FILE_USE_PATHURL</c></para>
		/// <para>Equivalent to <c>Uri_CREATE_FILE_USE_DOS_PATH</c>.</para>
		/// </param>
		/// <param name="ppCombinedUri">
		/// A pointer to an <c>IUri</c> interface that receives the newly created combined URI. The client must call Release on the returned pointer.
		/// </param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_INVALID_URL</term>
		/// <term>URI syntax error in pwzRelativeUrl.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to create the new IUri.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Use this function to combine an <c>IUri</c> and a relative URL stored as a Unicode string value. To combine two <c>IUri</c>
		/// objects, use the <c>CoInternetCombineIUri</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775086(v=vs.85) HRESULT
		// CoInternetCombineUrlEx( IUri *pBaseUri, LPCWSTR pwzRelativeUrl, DWORD dwCombineFlags, IUri **ppCombinedUri, _Reserved_ DWORD_PTR
		// dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetCombineUrlEx(IUri pBaseUri, [MarshalAs(UnmanagedType.LPWStr)] string pwzRelativeUrl, Uri_CREATE dwCombineFlags, out IUri ppCombinedUri, [Optional] IntPtr dwReserved);

		/// <summary>Compares two URLs and determines if they are equal.</summary>
		/// <param name="pwzUrl1">The address of a string value that contains the first URL.</param>
		/// <param name="pwzUrl2">The address of a string value that contains the second URL.</param>
		/// <param name="dwCompareFlags">
		/// An unsigned long integer value that controls how the comparison should be done. This is set to TRUE to ignore slash marks, or
		/// FALSE otherwise.
		/// </param>
		/// <returns>Returns S_OK if equal, or S_FALSE otherwise.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775087(v=vs.85) HRESULT
		// CoInternetCompareUrl( _In_ LPCWSTR pwzUrl1, _In_ LPCWSTR pwzUrl2, _In_ DWORD dwCompareFlags );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetCompareUrl([MarshalAs(UnmanagedType.LPWStr)] string pwzUrl1, [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl2, [MarshalAs(UnmanagedType.Bool)] bool dwCompareFlags);

		/// <summary>
		/// Creates a session that allows temporary asynchronous pluggable protocols to be implemented and returns the
		/// <c>IInternetSession</c> interface of the session.
		/// </summary>
		/// <param name="dwSessionMode">Reserved. Must be set to 0.</param>
		/// <param name="ppIInternetSession">The address of a pointer to the IInternetSession interface.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Not enough memory to create a session.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the arguments is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa767908(v=vs.85) STDAPI
		// CoInternetGetSession( _Reserved_ DWORD dwSessionMode, IInternetSession **ppIInternetSession, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetGetSession([Optional] uint dwSessionMode, out IInternetSession ppIInternetSession, [Optional] uint dwReserved);

		/// <summary>Transforms and identifies parts of URLs. Compare to <c>CoInternetParseUrl</c>.</summary>
		/// <param name="pIUri">
		/// <para>[in]</para>
		/// <para>The address of an <c>IUri</c> interface to be parsed.</para>
		/// </param>
		/// <param name="ParseAction">
		/// <para>[in]</para>
		/// <para>One of the following <c>PARSEACTION</c> values:</para>
		/// <para>(PARSE_CANONICALIZE)</para>
		/// <para>Canonicalize the URL.</para>
		/// <para>(PARSE_FRIENDLY)</para>
		/// <para>Retrieve a URL suitable for display.</para>
		/// <para>(PARSE_ROOTDOCUMENT)</para>
		/// <para>Retrieve the scheme and authority (including user name, password, and port if available) of the URL; for example, .</para>
		/// <para>(PARSE_DOCUMENT)</para>
		/// <para>Retrieve the portion of the URL prior to the fragment; for example, .</para>
		/// <para>(PARSE_ENCODE or PARSE_UNESCAPE)</para>
		/// <para>Percent-encode reserved characters in the URL.</para>
		/// <para>(PARSE_DECODE or PARSE_ESCAPE)</para>
		/// <para>Decode percent-encoded character sequences in the URL.</para>
		/// <para>(PARSE_PATH_FROM_URL)</para>
		/// <para>Convert a URL scheme into a DOS file path.</para>
		/// <para>(PARSE_URL_FROM_PATH)</para>
		/// <para>Convert a DOS path into a URL.</para>
		/// <para>(PARSE_SCHEMA)</para>
		/// <para>Retrieve the URL scheme; for example, .</para>
		/// <para>(PARSE_SITE)</para>
		/// <para>Retrieve the hostname; for example, .</para>
		/// <para>(PARSE_DOMAIN)</para>
		/// <para>Retrieve the top-level domain; for example, .</para>
		/// <para>(PARSE_LOCATION or PARSE_ANCHOR)</para>
		/// <para>Retrieve the URL fragment (named anchor); for example, .</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>[in]</para>
		/// <para>
		/// A <c>DWORD</c> value that controls the parsing operation, based on the value passed as the ParseAction parameter. For valid
		/// flags, see Remarks section.
		/// </para>
		/// </param>
		/// <param name="pwzResult">
		/// <para>[in]</para>
		/// <para>A pointer to a Unicode string buffer that receives the result of the parsing operation.</para>
		/// </param>
		/// <param name="cchResult">
		/// <para>[in]</para>
		/// <para>
		/// An unsigned long integer value that contains the size of the buffer in pwzResult, including the terminating <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="pcchResult">
		/// <para>[out]</para>
		/// <para>
		/// The address of a <c>DWORD</c> value that receives the number of characters returned in pwzResult. Count does not include the
		/// terminating <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="dwReserved">
		/// <para>[in]</para>
		/// <para>Reserved. Must be set to 0.</para>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The buffer is too small to contain the resulting URL.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_DEFAULT_ACTION</term>
		/// <term>Use the default action.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALID_ARG</term>
		/// <term>Missing input arguments or incompatible dwFlags and ParseAction.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Used for compatibility with CoInternetParseUrl behavior for some ParseAction requests.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Much of the functionality of the string-based <c>CoInternetParseUrl</c> function is not necessary with a preparsed <c>IUri</c>
		/// object. Encode operations and decode operations are discouraged because an <c>IUri</c> stores its data in a normalized
		/// (canonical) form.
		/// </para>
		/// <para>
		/// The possible values for dwFlags are determined by ParseAction. For example, if <c>PARSE_CANONICALIZE</c> is passed as the
		/// ParseAction parameter, the flags that are valid for the UrlCanonicalize function can also be passed to this function to control
		/// the parsing operation. The following table lists the parsing actions and related flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ParseAction</term>
		/// <term>Related dwFlags</term>
		/// </listheader>
		/// <item>
		/// <term>PARSE_CANONICALIZE</term>
		/// <term>UrlCanonicalize</term>
		/// </item>
		/// <item>
		/// <term>PARSE_UNESCAPE, PARSE_ENCODE</term>
		/// <term>UrlUnescape</term>
		/// </item>
		/// <item>
		/// <term>PARSE_ESCAPE, PARSE_DECODE</term>
		/// <term>UrlEscape</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775088(v=vs.85) STDAPI
		// CoInternetParseIUri( _In_ IUri *pIUri, _In_ PARSEACTION ParseAction, _In_ DWORD dwFlags, _In_ LPWSTR pwzResult, _In_ DWORD
		// cchResult, _Out_ DWORD *pcchResult, _Reserved_ DWORD_PTR dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetParseIUri(IUri pIUri, PARSEACTION ParseAction, uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwzResult, uint cchResult, out uint pcchResult, [Optional] IntPtr dwReserved);

		/// <summary>Transforms and identifies parts of URLs. Compare to <c>CoInternetParseIUri</c>.</summary>
		/// <param name="pwzUrl">String value that contains the URL to parse.</param>
		/// <param name="ParseAction">
		/// <para>One of the following <c>PARSEACTION</c> values:</para>
		/// <para>(PARSE_CANONICALIZE)</para>
		/// <para>Canonicalize the URL.</para>
		/// <para>(PARSE_ROOTDOCUMENT)</para>
		/// <para>Retrieve the scheme and hostname of the URL; for example, .</para>
		/// <para>(PARSE_ENCODE or PARSE_ESCAPE)</para>
		/// <para>Percent-encode reserved characters in the URL.</para>
		/// <para>(PARSE_DECODE or PARSE_UNESCAPE)</para>
		/// <para>Decode percent-encoded character sequences in the URL.</para>
		/// <para>(PARSE_PATH_FROM_URL)</para>
		/// <para>Convert a URL scheme into a DOS file path.</para>
		/// <para>(PARSE_URL_FROM_PATH)</para>
		/// <para>Convert a DOS path into a URL.</para>
		/// <para>(PARSE_SCHEMA)</para>
		/// <para>Retrieve the URL scheme; for example, .</para>
		/// <para>(PARSE_DOMAIN)</para>
		/// <para>Retrieve the hostname; for example, .</para>
		/// <para>(PARSE_LOCATION)</para>
		/// <para>Retrieve the URL fragment (named anchor); for example, .</para>
		/// </param>
		/// <param name="dwFlags">
		/// Unsigned long integer value that controls the parsing operation, based on the value passed as the ParseAction parameter. For
		/// valid flags, see Remarks section.
		/// </param>
		/// <param name="pszResult">String value that contains the information parsed from the URL.</param>
		/// <param name="cchResult">Unsigned long integer value that contains the size of the buffer.</param>
		/// <param name="pcchResult">
		/// Pointer to an unsigned long integer value that contains the size of the information stored in the buffer.
		/// </param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The buffer was too small to contain the resulting URL.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The buffer was too small to contain the resulting URL. See Remarks.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_DEFAULT_ACTION</term>
		/// <term>Use the default action.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When ParseAction is PARSE_UNESCAPE, PARSE_ENCODE, PARSE_ESCAPE, or PARSE_DECODE, <c>CoInternetParseUrl</c> will return E_POINTER
		/// if pszResult is too small to hold the result. When ParseAction is PARSE_URL_FROM_PATH, this function will return S_FALSE if
		/// pwzUrl does not contain a DOS file path.
		/// </para>
		/// <para>
		/// The possible values for dwFlags are determined by ParseAction. For example, if <c>PARSE_CANONICALIZE</c> is passed as the
		/// ParseAction parameter, the flags that are valid for the UrlCanonicalize function can also be passed to this function to control
		/// the parsing operation. The following table lists the parsing actions and related flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>ParseAction</term>
		/// <term>Related dwFlags</term>
		/// </listheader>
		/// <item>
		/// <term>PARSE_CANONICALIZE</term>
		/// <term>UrlCanonicalize</term>
		/// </item>
		/// <item>
		/// <term>PARSE_UNESCAPE, PARSE_ENCODE</term>
		/// <term>UrlUnescape</term>
		/// </item>
		/// <item>
		/// <term>PARSE_ESCAPE, PARSE_DECODE</term>
		/// <term>UrlEscape</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775089(v=vs.85) STDAPI
		// CoInternetParseUrl( LPCWSTR pwzUrl, PARSEACTION ParseAction, DWORD dwFlags, LPWSTR pszResult, DWORD cchResult, DWORD *pcchResult,
		// _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetParseUrl([MarshalAs(UnmanagedType.LPWStr)] string pwzUrl, PARSEACTION ParseAction, uint dwFlags,
			[MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszResult, uint cchResult, out uint pcchResult, [Optional] uint dwReserved);

		/// <summary>Retrieves information related to the specified URL.</summary>
		/// <param name="pwzUrl">The PWZ URL.</param>
		/// <param name="QueryOption">The query option.</param>
		/// <param name="dwQueryFlags">The dw query flags.</param>
		/// <param name="pvBuffer">The pv buffer.</param>
		/// <param name="cbBuffer">The cb buffer.</param>
		/// <param name="pcbBuffer">The PCB buffer.</param>
		/// <param name="dwReserved">The dw reserved.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The buffer is too small to store the information.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_QUERYOPTION_UNKNOWN</term>
		/// <term>The option requested is unknown.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>CoInternetQueryInfo</c> function is a wrapper around the <c>IInternetProtocolInfo::QueryInfo</c> method. Pluggable
		/// protocol handlers should return and error codes, as described above. For URLs not handled by a pluggable protocol handler, this
		/// function returns for both "buffer too small" and "option unknown" errors.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775090(v=vs.85) HRESULT
		// CoInternetQueryInfo( LPCWSTR pwzUrl, QUERYOPTION QueryOption, DWORD dwQueryFlags, LPVOID pvBuffer, DWORD cbBuffer, DWORD
		// *pcbBuffer, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CoInternetQueryInfo([MarshalAs(UnmanagedType.LPWStr)] string pwzUrl, QUERYOPTION QueryOption, uint dwQueryFlags, IntPtr pvBuffer, uint cbBuffer, out uint pcbBuffer, [Optional] uint dwReserved);

		/// <summary>Compares two security identifiers (SIDs) for equivalence.</summary>
		/// <param name="pbSecurityId1">A pointer to a byte value that identifies the first SID.</param>
		/// <param name="dwLen1">An unsigned long integer value that contains the first SID array length.</param>
		/// <param name="pbSecurityId2">A pointer to a byte value that identifies the second SID.</param>
		/// <param name="dwLen2">An unsigned long integer value that contains the second SID array length.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The SIDs match.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The SIDs do not match.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Not a valid SID.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Only the domain names of both SIDs are considered for a match. You can compare Domain Name System (DNS) or Internationalized
		/// Domain Name (IDN) URLs, but not SIDs generated from an IP address or intranet sites.
		/// </para>
		/// <para>If one SID is derived from a Mark of the Web, both must be.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa359661(v=vs.85) HRESULT
		// CompareSecurityIds( BYTE *pbSecurityId1, DWORD dwLen1, BYTE *pbSecurityId2, DWORD dwLen2, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CompareSecurityIds(byte[] pbSecurityId1, uint dwLen1, byte[] pbSecurityId2, uint dwLen2, [Optional] uint dwReserved);

		/// <summary>Reads the Microsoft ActiveX Compatibility registry entries for the specified ActiveX control.</summary>
		/// <param name="pclsid">A pointer to the CLSID of the ActiveX control.</param>
		/// <param name="pdwCompatFlags">
		/// Receives a value from the COMPAT enumeration. This parameter returns a value of zero if the entry is missing from the registry.
		/// </param>
		/// <param name="pdwMiscStatusFlags">
		/// Receives a value from the OLEMISC enumeration. This parameter returns a value of zero if the entry is missing from the registry.
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Indicates that zone elevation is disallowed.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Indicates that the registry entry cannot be found.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Indicates that pclsid, pdwCompatFlags, or pdwMiscStatusFlags is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CompatFlagsFromClsid</c> function was introduced in Microsoft Internet Explorer 6 for Windows XP Service Pack 2 (SP2).
		/// </para>
		/// <para>
		/// The compatibility registry keys for ActiveX controls can be found at <c>HKEY_LOCAL_MACHINE</c>\ <c>Software</c>\
		/// <c>Microsoft</c>\ <c>Internet Explorer</c>\ <c>ActiveX Compatibility</c> in the registry.
		/// </para>
		/// <para>This function is used by IMoniker::BindToObject to determine whether an ActiveX control can be created.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775091(v=vs.85) HRESULT
		// CompatFlagsFromClsid( CLSID *pclsid, LPDWORD pdwCompatFlags, LPDWORD pdwMiscStatusFlags );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CompatFlagsFromClsid(in Guid pclsid, out COMPAT pdwCompatFlags, out OLEMISC pdwMiscStatusFlags);

		/// <summary>Copies the given <c>BINDINFO</c> structure.</summary>
		/// <param name="pcbiSrc">The address of the BINDINFO structure to be copied.</param>
		/// <param name="pcbiDest">The address of the BINDINFO structure to store the copy.</param>
		/// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775092(v=vs.85) HRESULT
		// CopyBindInfo( const BINDINFO *pcbiSrc, BINDINFO *pcbiDest );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CopyBindInfo(in BINDINFO pcbiSrc, out BINDINFO pcbiDest);

		/// <summary>Copies the given STGMEDIUM structure.</summary>
		/// <param name="pcstgmedSrc">The address of the STGMEDIUM structure to copy.</param>
		/// <param name="pstgmedDest">The address of the STGMEDIUM structure in which to store the copy.</param>
		/// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775093(v=vs.85) HRESULT
		// CopyStgMedium( const STGMEDIUM *pcstgmedSrc, STGMEDIUM *pstgmedDest );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CopyStgMedium(in STGMEDIUM pcstgmedSrc, out STGMEDIUM pstgmedDest);

		/// <summary>Creates an asynchronous bind context for use with asynchronous monikers.</summary>
		/// <param name="reserved">This parameter is reserved and must be 0.</param>
		/// <param name="pBSCb">A pointer to the IBindStatusCallback interface used for receiving data availability and progress notification.</param>
		/// <param name="pEFetc">
		/// A pointer to the IEnumFORMATETC interface that can be used to enumerate formats for format negotiation during binding. This
		/// parameter can be <c>NULL</c>, in which case the caller is not interested in format negotiation during binding, and the default
		/// format of the object will be bound to.
		/// </param>
		/// <param name="ppBC">Address of an IBindCtx* pointer variable that receives the interface pointer to the new bind context.</param>
		/// <returns>
		/// <para>This function can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method ran out of memory and did not complete.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function automatically registers the IBindStatusCallback and IEnumFORMATETC interfaces with the bind context. The client
		/// can specify flags from BSCO_OPTION to indicate which callback notifications the client is capable of receiving. If the client
		/// does not wish to receive certain notification, it can choose to implement those callback methods as empty function stubs
		/// (returning E_NOTIMPL), and they should not be called.
		/// </para>
		/// <para>The RegisterBindStatusCallback function can also be used to register callback interfaces in the bind context.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/urlmon/nf-urlmon-createasyncbindctx HRESULT CreateAsyncBindCtx( DWORD
		// reserved, IBindStatusCallback *pBSCb, IEnumFORMATETC *pEFetc, IBindCtx **ppBC );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("urlmon.h", MSDNShortId = "0c79b61b-d3d6-48fd-aaee-21cddad09208")]
		public static extern HRESULT CreateAsyncBindCtx([Optional] uint reserved, IBindStatusCallback pBSCb, [In, Optional] IEnumFORMATETC pEFetc, out IBindCtx ppBC);

		/// <summary>Creates an asynchronous bind context for use with asynchronous monikers.</summary>
		/// <param name="pbc">A pointer to the IBindCtx interface.</param>
		/// <param name="dwOptions">An unsigned long integer value that contains the option values.</param>
		/// <param name="pBSCb">A pointer to the <c>IBindStatusCallback</c> interface.</param>
		/// <param name="pEnum">A pointer to the IEnumFORMATETC interface.</param>
		/// <param name="ppBC">A pointer to the IBindCtx interface that is returned.</param>
		/// <param name="reserved">Reserved. Must be set to 0.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775095(v=vs.85) HRESULT
		// CreateAsyncBindCtxEx( IBindCtx *pbc, DWORD dwOptions, IBindStatusCallback *pBSCb, IEnumFORMATETC *pEnum, IBindCtx **ppBC,
		// _Reserved_ DWORD reserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateAsyncBindCtxEx(IBindCtx pbc, uint dwOptions, IBindStatusCallback pBSCb, IEnumFORMATETC pEnum, out IBindCtx ppBC, uint reserved = 0);

		/// <summary>Creates an object that implements IEnumFORMATETC over a static array of FORMATETC structures.</summary>
		/// <param name="cfmtetc">
		/// Number of FORMATETC structures in the static array specified by the rgfmtetc parameter. The cfmtetc parameter cannot be zero.
		/// </param>
		/// <param name="rgfmtetc">Pointer to a static array of FORMATETC structures.</param>
		/// <param name="ppenumfmtetc">
		/// Address of IEnumFORMATETC pointer variable that receives the interface pointer to the enumerator object.
		/// </param>
		/// <returns>
		/// <para>This function returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters are invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>CreateFormatEnumerator</c> function creates an enumerator object that implements IEnumFORMATETC over a static array of
		/// FORMATETC structures. The cfmtetc parameter specifies the number of these structures. With the pointer, you can call the
		/// standard enumeration methods to enumerate the structures.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/urlmon/nf-urlmon-createformatenumerator HRESULT CreateFormatEnumerator( UINT
		// cfmtetc, FORMATETC *rgfmtetc, IEnumFORMATETC **ppenumfmtetc );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("urlmon.h", MSDNShortId = "302418e5-48b6-46ee-bb96-2a8170c4af5e")]
		public static extern HRESULT CreateFormatEnumerator(uint cfmtetc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] FORMATETC[] rgfmtetc, out IEnumFORMATETC ppenumfmtetc);

		/// <summary>Creates a new <c>IUriBuilder</c> instance, and initializes it from an optional <c>IUri</c>.</summary>
		/// <param name="pIUri">
		/// [in, optional]Pointer to an existing <c>IUri</c> with which to initialize the object, or <c>NULL</c> to create an uninitialized object.
		/// </param>
		/// <param name="dwFlags">[in]Currently unused. Set to 0.</param>
		/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
		/// <param name="ppIUriBuilder">[out]Address of a pointer variable of type <c>IUriBuilder</c> that receives the new object.</param>
		/// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775097(v=vs.85) STDAPI
		// CreateIUriBuilder( _In_opt_ IUri *pIUri, _In_ DWORD dwFlags, _Reserved_ DWORD_PTR dwReserved, _Out_ IUriBuilder **ppIUriBuilder );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateIUriBuilder([Optional] IUri pIUri, [Optional] uint dwFlags, [Optional] IntPtr dwReserved, out IUriBuilder ppIUriBuilder);

		/// <summary>
		/// Creates a new <c>IUri</c> instance, and initializes it from a Uniform Resource Identifier (URI) string. <c>CreateUri</c> also
		/// normalizes and validates the URI.
		/// </summary>
		/// <param name="pwzURI">
		/// <para>[in]</para>
		/// <para>A constant pointer to a UTF-16 character string that specifies the URI.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>[in]</para>
		/// <para>A valid combination of the following flags.</para>
		/// <para><c>Uri_CREATE_ALLOW_RELATIVE</c> (0x0001)</para>
		/// <para>Default. If the scheme is unspecified and not implicitly "file," assume relative.</para>
		/// <para><c>Uri_CREATE_ALLOW_IMPLICIT_WILDCARD_SCHEME</c> (0x0002)</para>
		/// <para>If the scheme is unspecified and not implicitly "file," assume wildcard.</para>
		/// <para><c>Uri_CREATE_ALLOW_IMPLICIT_FILE_SCHEME</c> (0x0004)</para>
		/// <para>Default. If the scheme is unspecified and URI starts with a drive letter (X:) or UNC path (\\), assume "file."</para>
		/// <para><c>Uri_CREATE_NOFRAG</c> (0x0008)</para>
		/// <para>If there is a query string, don't look for a fragment.</para>
		/// <para><c>Uri_CREATE_NO_CANONICALIZE</c> (0x0010)</para>
		/// <para>Do not canonicalize the scheme, host, authority, path, query, or fragment.</para>
		/// <para><c>Uri_CREATE_CANONICALIZE</c> (0x0100)</para>
		/// <para>Default. Canonicalize the scheme, host, authority, path, query, and fragment.</para>
		/// <para><c>Uri_CREATE_FILE_USE_DOS_PATH</c> (0x0020)</para>
		/// <para>Use DOS path compatibility mode to create "file" URIs.</para>
		/// <para><c>Uri_CREATE_DECODE_EXTRA_INFO</c> (0x0040)</para>
		/// <para>
		/// Default. Perform the percent-encoding and percent-decoding canonicalizations on the query and fragment. This flag takes
		/// precedence over <c>Uri_CREATE_NO_CANONICALIZE</c>.
		/// </para>
		/// <para><c>Uri_CREATE_NO_DECODE_EXTRA_INFO</c> (0x0080)</para>
		/// <para>
		/// Do not perform the percent-encoding or percent-decoding canonicalizations on the query and fragment. This flag takes precedence
		/// over <c>Uri_CREATE_CANONICALIZE</c>.
		/// </para>
		/// <para><c>Uri_CREATE_CRACK_UNKNOWN_SCHEMES</c> (0x0200)</para>
		/// <para>Default. Hierarchical URIs with unrecognized schemes will be treated like hierarchical URIs.</para>
		/// <para><c>Uri_CREATE_NO_CRACK_UNKNOWN_SCHEMES</c> (0x0400)</para>
		/// <para>Hierarchical URIs with unrecognized schemes will be treated like opaque URIs.</para>
		/// <para><c>Uri_CREATE_PRE_PROCESS_HTML_URI</c> (0x0800)</para>
		/// <para>
		/// Default. Perform preprocessing on the URI to remove control characters and white space, as if the URI had come from the raw href
		/// value of an HTML page.
		/// </para>
		/// <para><c>Uri_CREATE_NO_PRE_PROCESS_HTML_URI</c> (0x1000)</para>
		/// <para>Do not perform preprocessing to remove control characters and white space as appropriate.</para>
		/// <para><c>Uri_CREATE_IE_SETTINGS</c> (0x2000)</para>
		/// <para>Use Internet Explorer registry settings to determine default URL-parsing behavior.</para>
		/// <para><c>Uri_CREATE_NO_IE_SETTINGS</c> (0x4000)</para>
		/// <para>Default. Do not use Internet Explorer registry settings.</para>
		/// <para><c>Uri_CREATE_NO_ENCODE_FORBIDDEN_CHARACTERS</c> (0x8000)</para>
		/// <para>
		/// Do not percent-encode characters that are forbidden by RFC-3986. Use with <c>Uri_CREATE_FILE_USE_DOS_PATH</c> to create file monikers.
		/// </para>
		/// <para><c>Uri_CREATE_NORMALIZE_INTL_CHARACTERS</c> (0x00010000)</para>
		/// <para>
		/// Default. Percent encode all extended Unicode characters, then decode all percent encoded extended Unicode characters (except
		/// those identified as dangerous).
		/// </para>
		/// </param>
		/// <param name="dwReserved">
		/// <para>[in]</para>
		/// <para>Reserved. Must be set to 0.</para>
		/// </param>
		/// <param name="ppURI">
		/// <para>[out]</para>
		/// <para>An <c>IUri</c> interface pointer that receives the new instance.</para>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>Success.</description>
		/// </item>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>dwFlags conflict, or ppURI is NULL.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory to create the IUri.</description>
		/// </item>
		/// <item>
		/// <description>INET_E_INVALID_URL</description>
		/// <description>The string does not contain a recognized URI format.</description>
		/// </item>
		/// <item>
		/// <description>INET_E_SECURITY_PROBLEM</description>
		/// <description>The URI contains syntax that attempts to bypass security.</description>
		/// </item>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>Unknown error while parsing the URI.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>CreateUri</c> returns E_INVALIDARGS if conflicting flags are specified in dwFlags. For example,
		/// <c>Uri_CREATE_DECODE_EXTRA_INFO</c> and <c>Uri_CREATE_NO_DECODE_EXTRA_INFO</c>, or <c>Uri_CREATE_ALLOW_RELATIVE</c> and
		/// <c>Uri_CREATE_ALLOW_IMPLICIT_WILDCARD_SCHEME</c>. INET_E_SECURITY_PROBLEM is returned if the URI specifies userinfo but the
		/// Windows Internet Explorer feature control <c>FEATURE_HTTP_USERNAME_PASSWORD_DISABLE</c> is enabled.
		/// </para>
		/// <para>Hierarchical vs. Opaque Protocol Schemes</para>
		/// <para>
		/// Hierarchical URIs and opaque URIs are mutually exclusive. A hierarchical URI conforms to the RFC-defined syntax for URIs. (Refer
		/// to RFC3986: Uniform Resource Identifier (URI), Generic Syntax.) An opaque URI is parsed without an authority in the following manner.
		/// </para>
		/// <para>
		/// By default, all URIs are treated as hierarchical unless the <c>Uri_CREATE_NO_CRACK_UNKNOWN_SCHEMES</c> is set. (Unknown protocol
		/// schemes are those not defined in the URL_SCHEME enumeration.) The two flags <c>Uri_CREATE_ALLOW_RELATIVE</c> and
		/// <c>Uri_CREATE_ALLOW_IMPLICIT_WILDCARD_SCHEME</c> only apply if the string input is not an implicit file path or an absolute
		/// (hierarchical) URI. The syntax for relative URIs is a shortened form of the syntax for absolute URIs, where some prefix of the
		/// URI is missing and path segments ("." and "..") are allowed to remain until combined with a base URI. The wildcard URI scheme
		/// might be explicitly stated as "*:[[//]authority][path]," or implicitly stated by the "authority[path]" form.
		/// </para>
		/// <para>
		/// <c>CreateUri</c> can parse URIs in both the URL syntax and the Uniform Resource Name (URN) syntax. The difference between URLs
		/// and URNs is whether there is a protocol that enables access to the identified resource. Accessing the resource identified by an
		/// <c>IUri</c> is outside the scope of the Consolidated URL (cURL) API.
		/// </para>
		/// <para>Creating File Schemes from File Paths</para>
		/// <para>
		/// There are two kinds of file scheme URIs. The first is the well-formed, or "healthy," URL style that supports query strings,
		/// fragments, percent-encoded octets, and so on. The other is basically a DOS file path with "file://" prepended to the front. This
		/// latter form is generated when <c>Uri_CREATE_FILE_USE_DOS_PATH</c> is set and should be used only for legacy communication.
		/// </para>
		/// <para>
		/// <c>Warning</c> Legacy file scheme URIs should be used only with legacy APIs that will not accept healthy file scheme URIs.
		/// Legacy file scheme URIs do not allow percent encoded octets, which can lead to ambiguity. Therefore, legacy file scheme URIs
		/// should not be used unless absolutely necessary.
		/// </para>
		/// <para>The following is a comparison of the two forms of file scheme URIs.</para>
		/// <para>
		/// The <c>Uri_CREATE_ALLOW_IMPLICIT_FILE_SCHEME</c> flag allows the creation of a file scheme URI from a Microsoft Win32 file path.
		/// It doesn't change the interpretation of the input string; that is, if a Win32 file path is passed in, <c>CreateUri</c> either
		/// succeeds or fails based on the <c>Uri_CREATE_ALLOW_IMPLICIT_FILE_SCHEME</c> flag; it won't change the interpretation of the
		/// input string.
		/// </para>
		/// <para>Understanding Canonicalization</para>
		/// <para>Canonicalization, or conversion into the standard URI format, involves the following steps.</para>
		/// <list type="number">
		/// <item>The scheme is changed to lowercase.</item>
		/// <item>If the host is an IPv4 or IPv6 address, it is converted to normal form.</item>
		/// <item>
		/// If the host is a named host, it is changed to lowercase. Internationalized Domain Names (IDNs) with labels in Punycode are
		/// converted to Unicode.
		/// </item>
		/// <item>If the explicit port is the same as the default port for the scheme, it is removed.</item>
		/// <item>
		/// Backslash (\) characters in the path are changed to forward slash characters (/) in http, https, ftp, news, nntp, snews, and
		/// telnet schemes.
		/// </item>
		/// <item>If the URI has an authority but no path, the path is set to "/".</item>
		/// <item>Relative path segments "./" and "../" are removed, and the path is shortened as appropriate.</item>
		/// <item>Percent-encoded characters in the format "%XX," (where X is a hexadecimal digit) are decoded, if they are unreserved.</item>
		/// <item>
		/// Characters that are forbidden to appear in a URI are percent encoded. Forbidden characters are those that are neither in the
		/// "reserved" nor "unreserved" sets. The percent sign (%), which is used for percent encoding, is allowed. Refer to the following
		/// table for details.
		/// </item>
		/// </list>
		/// <para>The following is a raw URI value.</para>
		/// <para>
		/// <code>hTTp://us%45r%3Ainfo@examp%4CE.com:80/path/a/b/./c/../%2E%2E/Forbidden'&lt;|&gt; Characters</code>
		/// </para>
		/// <para>After canonicalization, the absolute URI appears as follows.</para>
		/// <para>
		/// <code>http://usEr%3Ainfo@example.com/path/a/Forbidden%60%3C%7C%3E%20Characters</code>
		/// </para>
		/// <list type="bullet">
		/// <item>In the username component, the %45 is decoded to "E" because it is in the unreserved set, while the %3A (@) is not. -</item>
		/// <item>In the host component, the %4C is first decoded to "L," and then changed to lowercase. -</item>
		/// <item>The port "80" (the default port for http) is removed. -</item>
		/// <item>The "./" in the path is removed. -</item>
		/// <item>The "../" following the "c/" in the path is removed along with its logical parent, the "c/" path segment. -</item>
		/// <item>
		/// The %2E characters are in the unreserved set and are converted to "." forming "../". This new "../" is removed along with its
		/// logical parent path segment, which in this case is "b/." -
		/// </item>
		/// <item>
		/// All of the characters between "Forbidden" and "Characters" (including the space) are percent encoded because they are forbidden
		/// to appear in a URI. -
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775098(v%3Dvs.85)
		// STDAPI CreateUri( _In_ LPCWSTR pwzURI, _In_ DWORD dwFlags = Uri_CREATE_CANONICALIZE, _Reserved_ DWORD_PTR dwReserved, _Out_ IUri
		// **ppURI );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateUri([MarshalAs(UnmanagedType.LPWStr)] string pwzURI, Uri_CREATE dwFlags, [Optional] IntPtr dwReserved, out IUri ppURI);

		/// <summary>Converts an ANSI URL with components in various multibyte character set (MBCS) encodings to an <c>IUri</c> object.</summary>
		/// <param name="pszANSIInputUri">
		/// <para>[in]</para>
		/// <para>A constant pointer to an ANSI character string that specifies the URI.</para>
		/// </param>
		/// <param name="dwEncodingFlags">
		/// <para>[in]</para>
		/// <para>
		/// A valid combination of the following flags, which allows the caller to specify the encoding of all applicable components, except
		/// the scheme and the port.
		/// </para>
		/// <para><c>Uri_ENCODING_USER_INFO_AND_PATH_IS_PERCENT_ENCODED_UTF8</c> (0x00000001)</para>
		/// <para>Default. The user info component and path component use percent encoded UTF-8.</para>
		/// <para><c>Uri_ENCODING_USER_INFO_AND_PATH_IS_CP</c> (0x00000002)</para>
		/// <para>The user info component and path component use the codepage specified in dwCodePage.</para>
		/// <para><c>Uri_ENCODING_HOST_IS_IDN</c> (0x00000004)</para>
		/// <para>Default. The host component uses IDN (Punycode) format.</para>
		/// <para><c>Uri_ENCODING_HOST_IS_PERCENT_ENCODED_UTF8</c> (0x00000008)</para>
		/// <para>The host component uses percent encoded UTF-8.</para>
		/// <para><c>Uri_ENCODING_HOST_IS_PERCENT_ENCODED_CP</c> (0x00000010)</para>
		/// <para>The host component uses the codepage specified in dwCodePage.</para>
		/// <para><c>Uri_ENCODING_QUERY_AND_FRAGMENT_IS_PERCENT_ENCODED_UTF8</c> (0x00000020)</para>
		/// <para>Default. The query and fragment components use percent encoded UTF-8.</para>
		/// <para><c>Uri_ENCODING_QUERY_AND_FRAGMENT_IS_CP</c> (0x00000040)</para>
		/// <para>The query and fragment components use the codepage specified in dwCodePage.</para>
		/// <para><c>Uri_ENCODING_RFC</c> (0x00000025)</para>
		/// <para>
		/// The URI meets the requirements of RFC 3490. This flag combines the preceding default flags: <c>Uri_ENCODING_HOST_IS_IDN</c>,
		/// <c>Uri_ENCODING_USER_INFO_AND_PATH_IS_PERCENT_ENCODED_UTF8</c>, and <c>Uri_ENCODING_QUERY_AND_FRAGMENT_IS_PERCENT_ENCODED_UTF8</c>.
		/// </para>
		/// </param>
		/// <param name="dwCodePage">
		/// <para>[in]</para>
		/// <para>An unsigned long integer value that contains the codepage identifier value for the multibyte URI.</para>
		/// </param>
		/// <param name="dwCreateFlags">
		/// <para>[in]</para>
		/// <para>A valid combination of flags. Refer to <c>CreateUri</c> for a complete list of flags and values.</para>
		/// </param>
		/// <param name="dwReserved">
		/// <para>[in]</para>
		/// <para>Reserved. Must be set to 0.</para>
		/// </param>
		/// <param name="ppURI">
		/// <para>[out]</para>
		/// <para>An <c>IUri</c> interface pointer that will receive the new instance.</para>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Flags conflict, or ppURI is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to create the IUri.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_INVALID_URL</term>
		/// <term>The string does not contain a recognized URI format.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_SECURITY_PROBLEM</term>
		/// <term>The URI contains syntax that attempts to bypass security.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function fails with E_INVALIDARG, if the flags specified in dwEncodingFlags conflict. For example, if both
		/// <c>Uri_ENCODING_HOST_IS_PERCENT_ENCODED_UTF8</c> and <c>Uri_ENCODING_HOST_IS_PERCENT_ENCODED_CP</c> are set, this function will fail.
		/// </para>
		/// <para>
		/// The dwEncodingFlags for host are ignored if <c>Uri_CREATE_NO_CRACK_UNKNOWN_SCHEMES</c> is specified in dwCreateFlags. Use the
		/// encoding flags for userinfo and path instead.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775099(v=vs.85) HRESULT
		// CreateUriFromMultiByteString( _In_ LPCSTR pszANSIInputUri, _In_ DWORD dwEncodingFlags =
		// Uri_ENCODING_USER_INFO_AND_PATH_IS_PERCENT_ENCODED_UTF8, _In_ DWORD dwCodePage, _In_ DWORD dwCreateFlags, _Reserved_ DWORD_PTR
		// dwReserved, _Out_ IUri **ppURI );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateUriFromMultiByteString([MarshalAs(UnmanagedType.LPStr)] string pszANSIInputUri, Uri_ENCODING dwEncodingFlags,
			uint dwCodePage, Uri_CREATE dwCreateFlags, [Optional] IntPtr dwReserved, out IUri ppURI);

		/// <summary>
		/// Creates a new <c>IUri</c> instance (and optional fragment), and initializes the instance from a Uniform Resource Identifier
		/// (URI) string.
		/// </summary>
		/// <param name="pwzURI">[in]A constant pointer to an UTF-8 character string that specifies the URI.</param>
		/// <param name="pwzFragment">[in]A constant pointer to a UTF-8 character string that specifies the explicit fragment, or <c>NULL</c>.</param>
		/// <param name="dwFlags">[in]A valid combination of flags. Refer to <c>CreateUri</c> for a complete list of flags and values.</param>
		/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
		/// <param name="ppURI">[out]An <c>IUri</c> interface pointer that will receive the new instance.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>dwFlags conflict, or ppURI is NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to create the IUri.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_INVALID_URL</term>
		/// <term>The string does not contain a recognized URI format.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_SECURITY_PROBLEM</term>
		/// <term>The URI contains syntax that attempts to bypass security.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function is identical to <c>CreateUri</c>, except that an explicit fragment can be specified. You cannot specify an
		/// explicit fragment and an implicit fragment in the URI; the function will fail with E_INVALIDARG. The explicit fragment can start
		/// with the delimiting "#," but it will be removed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775100(v=vs.85) STDAPI
		// CreateUriWithFragment( _In_ LPCWSTR pwzURI, _In_ LPCWSTR pwzFragment, _In_ DWORD dwFlags, _Reserved_ DWORD_PTR dwReserved, _Out_
		// IUri **ppURI );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateUriWithFragment([MarshalAs(UnmanagedType.LPWStr)] string pwzURI, [MarshalAs(UnmanagedType.LPWStr)] string pwzFragment, Uri_CREATE dwFlags, [Optional] IntPtr dwReserved, out IUri ppURI);

		/// <summary>Deprecated in Windows Internet Explorer 7. Use <c>CreateURLMonikerEx</c> instead.</summary>
		/// <param name="pMkCtx">
		/// [in]The address of the IMoniker interface for the URL moniker to use as the base context when the szURL parameter is a partial
		/// URL string. The pMkCtx parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szURL">[in]The address of a string value that contains the display name to be parsed.</param>
		/// <param name="ppmk">[out]Pointer to an IMoniker interface for the new URL moniker.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Success.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The operation ran out of memory.</term>
		/// </item>
		/// <item>
		/// <term>MK_E_SYNTAX</term>
		/// <term>
		/// A moniker cannot be created because szURL does not correspond to valid URL syntax for a full or partial URL. This is uncommon,
		/// because most parsing of the URL occurs during binding, and the syntax for URLs is extremely flexible.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateURLMoniker</c> function creates a URL moniker from a full URL string, or from a base context URL moniker and a
		/// partial URL string.
		/// </para>
		/// <para>
		/// <c>Security Warning:</c> This function does not correctly interpret percent encoded octets in Windows file paths or "file://"
		/// scheme Uniform Resource Identifiers (URIs). On systems with Microsoft Internet Explorer 6 and earlier, calling
		/// <c>CreateURLMoniker</c> with the output of a previous call might produce a result that is not equivalent. Since
		/// <c>CreateURLMoniker</c> can produce results that are not equivalent to the input, its use can result in security problems.
		/// </para>
		/// <para>
		/// Use <c>CreateURLMonikerEx</c> with the <c>URL_MK_UNIFORM</c> flag to ensure that Windows file paths and "file://" URIs are
		/// interpreted correctly with regard to percent encoded octets; and that the result is equivalent to the input. To correctly
		/// extract a Windows file path from the result of <c>CreateURLMoniker</c>, use the PathCreateFromUrl function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775102(v=vs.85) HRESULT
		// CreateURLMoniker( _In_ IMoniker *pMkCtx, _In_ LPCWSTR szURL, _Out_ IMoniker **ppmk );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h"), Obsolete("Use CreateURLMonikerEx.")]
		public static extern HRESULT CreateURLMoniker([In, Optional] IMoniker pMkCtx, [MarshalAs(UnmanagedType.LPWStr)] string szURL, out IMoniker ppmk);

		/// <summary>Creates a URL moniker from a full URL, or from a base context URL moniker and a partial URL.</summary>
		/// <param name="pMkCtx">
		/// A pointer to an IMoniker interface of the URL moniker to use as the base context when the szURL parameter is a partial URL
		/// string. The pMkCtx parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="szURL">A string value that contains the URL to be parsed.</param>
		/// <param name="ppmk">A pointer to an IMoniker interface for the new URL moniker.</param>
		/// <param name="dwFlags">
		/// <para>A <c>DWORD</c> value that specifies which URL parser to use. This can be one of the following values.</para>
		/// <para><c>URL_MK_LEGACY</c></para>
		/// <para>Use the same URL parser as <c>CreateURLMoniker</c>.</para>
		/// <para><c>URL_MK_UNIFORM</c></para>
		/// <para>Use the updated URL parser.</para>
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// <para>
		/// Use <c>CreateURLMonikerEx</c> with the <c>URL_MK_UNIFORM</c> flag to ensure that a Windows file path and "file://" Uniform
		/// Resource Identifier (URI) is interpreted correctly with regard to percent encoded octets, and that the result is equivalent to
		/// the input. To correctly extract a Windows file path from the result of <c>CreateURLMonikerEx</c>, use PathCreateFromUrl.
		/// </para>
		/// <para>
		/// For compatibility reasons, it might be possible to create a URL moniker from an invalid URL; however, such a base moniker cannot
		/// be combined with a relative URL. Any attempt to do so will fail with E_INVALIDARG.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775103(v=vs.85) HRESULT
		// CreateURLMonikerEx( IMoniker *pMkCtx, LPCWSTR szURL, IMoniker **ppmk, DWORD dwFlags );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateURLMonikerEx([In, Optional] IMoniker pMkCtx, [MarshalAs(UnmanagedType.LPWStr)] string szURL, out IMoniker ppmk, URL_MK dwFlags);

		/// <summary>
		/// Creates a new URL moniker from a full Uniform Resource Identifier (URI), or from a base context URL moniker and a relative URI.
		/// </summary>
		/// <param name="pMkCtx">
		/// A pointer to an IMoniker interface of the URL moniker to use as the base context. The pMkCtx parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pUri">A pointer to an <c>IUri</c> interface that contains a full or relative URI.</param>
		/// <param name="ppmk">A pointer to an IMoniker interface for the new URL moniker.</param>
		/// <param name="dwFlags">
		/// <para>An unsigned long integer value that contains a combination of the following flags.</para>
		/// <para><c>URL_MK_LEGACY</c> (0)</para>
		/// <para>Create legacy file URLs. Equivalent to <c>Uri_CREATE_FILE_USE_DOS_PATH</c>.</para>
		/// <para><c>URL_MK_UNIFORM</c> (1)</para>
		/// <para>Use the updated URL parser.</para>
		/// <para><c>URL_MK_NO_CANONICALIZE</c> (2)</para>
		/// <para>Do not attempt to convert the URL moniker to the standard format.</para>
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// Any two URIs can be combined. The base URI and context URI can be any combination of relative and absolute. This is also true
		/// for the <c>CoInternetCombineUrl</c> function, the <c>CoInternetCombineUrlEx</c> function, and the <c>CoInternetCombineIUri</c> function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775104(v=vs.85) HRESULT
		// CreateURLMonikerEx2( IMoniker *pMkCtx, IUri *pUri, IMoniker **ppmk, DWORD dwFlags );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT CreateURLMonikerEx2([In, Optional] IMoniker pMkCtx, IUri pUri, out IMoniker ppmk, URL_MK dwFlags);

		/// <summary>
		/// This synchronous function is invoked by the client of a Windows Internet Explorer feature before the client accesses the feature.
		/// </summary>
		/// <param name="hWnd">
		/// <para>[in]</para>
		/// <para>A handle to the parent window of the HTML dialog box.</para>
		/// </param>
		/// <param name="pClassSpec">
		/// <para>[in]</para>
		/// <para>A pointer to a union that provides ways of mapping to a CLSID. Note that is defined in .</para>
		/// </param>
		/// <param name="pQuery">
		/// <para>[in, out]</para>
		/// <para>
		/// A ointer to a structure that contains a list of attributes used to look up a class implementation. The installed version number
		/// is returned in , which is passed in.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>[in]</para>
		/// <para>The control behavior. The following values are valid.</para>
		/// <para><c>FIEF_FLAG_FORCE_JITUI (0x0001)</c></para>
		/// <para>
		/// Force JIT, even if the user has canceled a previous JIT in the same session, or has specified to this feature. Note: For
		/// Internet Explorer 7, this flag is not respected; it is overridden by E_ACCESSDENIED.
		/// </para>
		/// <para><c>FIEF_FLAG_PEEK (0x0002)</c></para>
		/// <para>
		/// Do not faultin, just peek. Note: Peek also returns the currently installed version in the QUERYCONTEXT. For Internet Explorer 7,
		/// it disables the Java dialog box.
		/// </para>
		/// <para><c>FIEF_FLAG_SKIP_INSTALLED_VERSION_CHECK (0x0004)</c></para>
		/// <para>
		/// Ignores local version as being satisfactory and forces JIT download. Typically, this is called by code download, or by another
		/// caller after a CoCreateInstance call has failed with or (missing a dependency DLL). Note: The registry might show that this
		/// feature is installed when it is not, or when it is damaged. For Internet Explorer 7, this flag is not respected; it is
		/// overridden by .
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// Behavior is installed. Call CoCreateInstance or IMoniker::BindToObject or another system service to invoke the class or MIME handler.
		/// </term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The class or MIME handler is not part of an Internet Explorer feature. Call CoCreateInstance, IMoniker::BindToObject, or some
		/// other system service to invoke the class or MIME handler. Active setup settings are not found in registry.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>The administrator has turned off the JIT feature.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the feature is already installed, then the function succeeds and the client should attempt to access the feature. Successful
		/// return does not guarantee that the feature is fully installed, or that the feature will work. The client should still provide
		/// access to the feature with proper error checking.
		/// </para>
		/// <para>
		/// <c>Note</c> The importance of this function degraded significantly after Microsoft Internet Explorer 6 SP1b and Windows XP, due
		/// to a lack of dependence on JIT in components.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa359663(v=vs.85) HRESULT
		// FaultInIEFeature( _In_ HWND hWnd, _In_ uCLSSPEC *pClassSpec, _Inout_ QUERYCONTEXT *pQuery, _In_ DWORD dwFlags );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT FaultInIEFeature(HWND hWnd, in uCLSSPEC pClassSpec, ref QUERYCONTEXT pQuery, FIEF_FLAG dwFlags);

		/// <summary>Retrieves the 32-bit value assigned to the specified media type.</summary>
		/// <param name="rgszTypes">The address of a string value that identifies the media type.</param>
		/// <param name="rgcfTypes">The address of the CLIPFORMAT value assigned to the specified media type.</param>
		/// <returns>Returns S_OK if successful, or an error value otherwise.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775105(v=vs.85) HRESULT
		// FindMediaType( LPCSTR rgszTypes, CLIPFORMAT *rgcfTypes );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT FindMediaType([MarshalAs(UnmanagedType.LPStr)] string rgszTypes, out CLIPFORMAT rgcfTypes);

		/// <summary>Retrieves the <c>CLSID</c> for the specified media type.</summary>
		/// <param name="pbc">[in]A pointer to the bind context on which the media type is registered.</param>
		/// <param name="szType">[in]A string identifying the media types. This parameter cannot be <c>NULL</c>.</param>
		/// <param name="pclsID">[out]A pointer to the <c>CLSID</c> corresponding to the specified media types in szType.</param>
		/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
		/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters are invalid.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775106(v=vs.85) HRESULT
		// FindMediaTypeClass( _In_ LPBC pbc, _In_ LPCSTR szType, _Out_ CLSID *pclsID, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT FindMediaTypeClass([In] IBindCtx pbc, [MarshalAs(UnmanagedType.LPStr)] string szType, out Guid pclsID, uint dwReserved = 0);

		/// <summary>Determines the MIME type from the data provided.</summary>
		/// <param name="pBC">A pointer to the IBindCtx interface. Can be set to <c>NULL</c>.</param>
		/// <param name="pwzUrl">
		/// A pointer to a string value that contains the URL of the data. Can be set to <c>NULL</c> if pBuffer contains the data to be sniffed.
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to the buffer that contains the data to be sniffed. Can be set to <c>NULL</c> if pwzUrl contains a valid URL.
		/// </param>
		/// <param name="cbSize">An unsigned long integer value that contains the size of the buffer.</param>
		/// <param name="pwzMimeProposed">
		/// A pointer to a string value that contains the proposed MIME type. This value is authoritative if type cannot be determined from
		/// the data. If the proposed type contains a semi-colon (;) it is removed. This parameter can be set to <c>NULL</c>.
		/// </param>
		/// <param name="dwMimeFlags">
		/// <para><c>FMFD_DEFAULT</c> (0x00000000)</para>
		/// <para>No flags specified. Use default behavior for the function.</para>
		/// <para><c>FMFD_URLASFILENAME</c> (0x00000001)</para>
		/// <para>Treat the specified pwzUrl as a file name.</para>
		/// <para><c>FMFD_ENABLEMIMESNIFFING</c> (0x00000002)</para>
		/// <para>
		/// Internet Explorer 6 for Windows XP SP2 and later. Use MIME-type detection even if <c>FEATURE_MIME_SNIFFING</c> is detected.
		/// Usually, this feature control key would disable MIME-type detection.
		/// </para>
		/// <para><c>FMFD_IGNOREMIMETEXTPLAIN</c> (0x00000004)</para>
		/// <para>
		/// Internet Explorer 6 for Windows XP SP2 and later. Perform MIME-type detection if "text/plain" is proposed, even if data sniffing
		/// is otherwise disabled. Plain text may be converted to if HTML tags are detected.
		/// </para>
		/// <para><c>FMFD_SERVERMIME</c> (0x00000008)</para>
		/// <para>
		/// Internet Explorer 8. Use the authoritative MIME type specified in pwzMimeProposed. Unless <c>FMFD_IGNOREMIMETEXTPLAIN</c> is
		/// specified, no data sniffing is performed.
		/// </para>
		/// <para><c>FMFD_RESPECTTEXTPLAIN</c> (0x00000010)</para>
		/// <para>Internet Explorer 9. Do not perform detection if "text/plain" is specified in pwzMimeProposed.</para>
		/// <para><c>FMFD_RETURNUPDATEDIMGMIMES</c> (0x00000020)</para>
		/// <para>Internet Explorer 9. Returns and instead of and .</para>
		/// </param>
		/// <param name="ppwzMimeOut">The address of a string value that receives the suggested MIME type.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// MIME type detection, or "data sniffing," refers to the process of determining an appropriate MIME type from binary data. The
		/// final result depends on a combination of server-supplied MIME type headers, file name extension, and/or the data itself.
		/// Usually, only the first 256 bytes of data are significant. For more information and a complete list of recognized MIME types,
		/// see MIME Type Detection in Internet Explorer.
		/// </para>
		/// <para>
		/// If pwzUrl is specified without data to be sniffed (pBuffer), the file name extension determines the MIME type. If the file name
		/// extension cannot be mapped to a MIME type, this method returns E_FAIL unless a proposed MIME type is supplied in pwzMimeProposed.
		/// </para>
		/// <para>After ppwzMimeOut returns and is read, the memory allocated for it should be freed with the operator delete function.</para>
		/// <para>
		/// Internet Explorer 8 and later. <c>FindMimeFromData</c> will not promote image types to "text/html" even if the data lacks
		/// signature bytes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775107(v=vs.85) HRESULT
		// FindMimeFromData( LPBC pBC, LPCWSTR pwzUrl, LPVOID pBuffer, DWORD cbSize, LPCWSTR pwzMimeProposed, DWORD dwMimeFlags, LPWSTR
		// *ppwzMimeOut, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT FindMimeFromData([In, Optional] IBindCtx pBC, [MarshalAs(UnmanagedType.LPWStr)] string pwzUrl, IntPtr pBuffer, uint cbSize,
			[MarshalAs(UnmanagedType.LPWStr)] string pwzMimeProposed, FMFD dwMimeFlags, [MarshalAs(UnmanagedType.LPWStr)] out string ppwzMimeOut, uint dwReserved = 0);

		/// <summary>Gets the <c>CLSID</c> of the object to instantiate for the specified file.</summary>
		/// <param name="pBC">
		/// A pointer to a bind context that can affect the mapping to a <c>CLSID</c>. This parameter is usually <c>NULL</c>. It can be used
		/// to override system <c>CLSID</c> mappings when it is used with <c>RegisterMediaTypeClass</c>.
		/// </param>
		/// <param name="szFilename">A pointer to a string variable that contains the file name. Can be set to <c>NULL</c>.</param>
		/// <param name="pBuffer">A pointer to a buffer that contains data from the beginning of the file. Can be set to <c>NULL</c>.</param>
		/// <param name="cbSize">An unsigned long integer value that contains the size of pBuffer.</param>
		/// <param name="szMime">A pointer to a string variable that contains the MIME type of the file. Can be set to <c>NULL</c>.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <param name="pclsid">
		/// A pointer to a <c>CLSID</c> that receives the <c>CLSID</c> of the object to instantiate for the specified file.
		/// </param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		/// <remarks>
		/// Windows Internet Explorer 9. This function can also return a class identifier (CLSID) from structured storage files if sniffing
		/// is allowed for the security zone ( <c>URLACTION_ALLOW_STRUCTURED_STORAGE_SNIFFING</c> is enabled) and sniffing is not disabled
		/// for the process by using . Structured storage sniffing is enabled by default in the Local intranet and Trusted sites zones.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775108(v=vs.85) HRESULT
		// GetClassFileOrMime( LPBC pBC, LPCWSTR szFilename, LPVOID pBuffer, DWORD cbSize, LPCWSTR szMime, _Reserved_ DWORD dwReserved,
		// CLSID *pclsid );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT GetClassFileOrMime([In, Optional] IBindCtx pBC, [Optional, MarshalAs(UnmanagedType.LPWStr)] string szFilename, IntPtr pBuffer, uint cbSize,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string szMime, [Optional] uint dwReserved, out Guid pclsid);

		/// <summary>Gets a string component ID from information contained in a union .</summary>
		/// <param name="pClassSpec">[in]A pointer to a union that provides ways of mapping to a CLSID.</param>
		/// <param name="ppszComponentID">
		/// [out]A pointer to a string containing a component ID that is based on a , which is defined in .
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The component ID was successfuly retrieved.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The class or Mime is not part of an Internet Explorer feature.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The parameter contains invalid data.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The program does not have enough memory for successful operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> The importance of this function degraded significantly after Microsoft Internet Explorer 6 SP1b and Windows XP, due
		/// to a lack of dependence on just-in-time (JIT) in components.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/aa359665(v=vs.85) HRESULT
		// GetComponentIDFromCLSSPEC( _In_ uCLSSPEC *pClassSpec, _Out_ LPSTR *ppszComponentID );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT GetComponentIDFromCLSSPEC(in uCLSSPEC pClassSpec, out SafeCoTaskMemHandle ppszComponentID);

		/// <summary>This function provides the current Install Scope to a Microsoft ActiveX DLL.</summary>
		/// <param name="pdwScope">
		/// <para>[out]</para>
		/// <para>A pointer to a <c>DWORD</c> which contains one of the Install Scope values.</para>
		/// <para>(INSTALL_SCOPE_USER)</para>
		/// <para>The ActiveX control should register in the current user profile.</para>
		/// <para>(INSTALL_SCOPE_MACHINE)</para>
		/// <para>The ActiveX control should register machine-wide.</para>
		/// <para>(INSTALL_SCOPE_INVALID)</para>
		/// <para>The Install Scope could not be retrieved. The ActiveX control should not install.</para>
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The Install Scope was successfully retrieved.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>An error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function call is intended to be used by an ActiveX DLL during its install-time registration. It provides the current
		/// Install Scope to the ActiveX DLL. The ActiveX package developer can choose to install or not, depending on the returned scope.
		/// For example, if the ActiveX package requires machine scope, but only user scope is available, the developer can choose not to
		/// install the package.
		/// </para>
		/// <para>Registration is done using DllRegisterServer or DllUnregisterServer.</para>
		/// <para>
		/// <c>Important</c> The ActiveX package should install and register only if both S_OK and a valid value for pdwScope have been returned.
		/// </para>
		/// <para>
		/// S_OK is also returned when the configuration does not support Windows Internet Explorer Install Scope. Therefore, when Windows
		/// Internet Explorer 8 is running on an operating system that is earlier than Windows Vista, the function will return
		/// INSTALL_SCOPE_MACHINE. The ActiveX control should install machine-wide in this case.
		/// </para>
		/// <para>Only one Install Scopes value will be returned by this function.</para>
		/// <para>The ActiveX templates in Active Template Library (ATL) 7 and earlier do not support per-user ActiveX Install Scope.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/cc197030(v=vs.85) HRESULT
		// IEInstallScope( _Out_ LPDWORD pdwScope );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT IEInstallScope(out uint pdwScope);

		/// <summary>Tests to determine whether a moniker supports asynchronous binding.</summary>
		/// <param name="pmk">The PMK.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The pmk parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The specified moniker is not asynchronous.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The specified moniker is asynchronous.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A moniker implementation is asynchronous if it supports the interface, which is an empty interface that is an implementation of
		/// IUnknown. The <c>IsAsyncMoniker</c> function tests for support of and handles composite monikers correctly.
		/// </para>
		/// <para>
		/// No public headers define the interface; however, you can support the interface by returning a pointer to your object in response
		/// to QueryInterface for , which is defined as follows:
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775110(v=vs.85) HRESULT
		// IsAsyncMoniker( _In_ IMoniker *pmk );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT IsAsyncMoniker(IMoniker pmk);

		/// <summary>Determines if a specified string is a valid URL.</summary>
		/// <param name="pBC">[in]A pointer to the IBindCtx interface. This parameter is currently ignored. It should be set to <c>NULL</c>.</param>
		/// <param name="szURL">[in]A pointer to a string value that contains the full URL to check.</param>
		/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The szURL parameter contains a valid URL.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The szURL parameter does not contain a valid URL.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775112(v=vs.85) HRESULT
		// IsValidURL( _In_ LPBC pBC, _In_ LPCWSTR szURL, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT IsValidURL([Optional] IBindCtx pBC, [MarshalAs(UnmanagedType.LPWStr)] string szURL, uint dwReserved = 0);

		/// <summary>Creates a moniker to the object that is specified by the given string.</summary>
		/// <param name="pbc">[in]The address of the IBindCtx interface of the bind context in which to accumulate bound objects.</param>
		/// <param name="szDisplayName">[in]The address of the string value to parse.</param>
		/// <param name="pcchEaten">
		/// [out]The address of an unsigned long integer value that indicates the number of characters successfully parsed.
		/// </param>
		/// <param name="ppmk">[out]A pointer to the IMoniker interface of the resulting moniker.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successful.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_UNKNOWN_PROTOCOL</term>
		/// <term>The szDisplayName parameter contains a protocol (other than telnet) that does not have a valid protocol handler assigned.</term>
		/// </item>
		/// <item>
		/// <term>MK_E_SYNTAX</term>
		/// <term>
		/// Parsing failed because szDisplayName can only be partially resolved into a moniker. In this case, pcchEaten receives the number
		/// of characters that are successfully parsed into a moniker prefix.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NOERROR</term>
		/// <term>The szDisplayName uses a telnet protocol, for which the function does not have a valid protocol handler.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When MK_E_SYNTAX is returned and pcchEaten contains a nonzero value, a subsequent call to <c>MkParseDisplayNameEx</c> with the
		/// same pbc parameter and a shortened szDisplayName parameter returns a valid moniker.
		/// </para>
		/// <para>
		/// <c>Security Warning:</c> Calling MkParseDisplayName or <c>MkParseDisplayNameEx</c> with a szDisplayName parameter from a
		/// non-trusted source is unsafe. Not only can an arbitrary class be instantiated but some moniker implementations might act on the
		/// string during parsing instead of deferring this to binding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775113(v=vs.85) HRESULT
		// MkParseDisplayNameEx( _In_ IBindCtx *pbc, _In_ LPWSTR szDisplayName, _Out_ unsigned long *pcchEaten, _Out_ IMoniker **ppmk );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT MkParseDisplayNameEx(IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string szDisplayName, out uint pcchEaten, out IMoniker ppmk);

		/// <summary>Retrieves the User-Agent HTTP request header string that is currently being used.</summary>
		/// <param name="dwOption">
		/// <para>[in]</para>
		/// <para><c>7 | UAS_EXACTLEGACY</c> (0x1000)</para>
		/// <para>Internet Explorer 7 in exact legacy mode.</para>
		/// <para><c>7</c></para>
		/// <para>Internet Explorer 7 in compatible mode.</para>
		/// <para><c>8</c></para>
		/// <para>Internet Explorer 8.</para>
		/// <para><c>0</c></para>
		/// <para>Default. As currently set.</para>
		/// </param>
		/// <param name="pcszUAOut">
		/// <para>[out]</para>
		/// <para>Pointer to a string value that contains the User-Agent request header string that is currently being used.</para>
		/// </param>
		/// <param name="cbSize">
		/// <para>[out]</para>
		/// <para>Pointer to an unsigned long integer value that contains the length of the User-Agent request header string.</para>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The operation ran out of memory.</term>
		/// </item>
		/// <item>
		/// <term>NOERROR</term>
		/// <term>The function completed successfully.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Passing a bitwise OR of <c>7 | UAS_EXACTLEGACY</c> to dwOption specifies Internet Explorer 7 running in exact legacy mode, as
		/// opposed to compatible mode.
		/// </para>
		/// <para>Internet Explorer 8. dwOption is no longer reserved and must have one of the required values.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775114(v=vs.85) HRESULT
		// ObtainUserAgentString( _In_ DWORD dwOption = 0, _Out_ LPCSTR *pcszUAOut, _Out_ DWORD *cbSize );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT ObtainUserAgentString(uint dwOption, [MarshalAs(UnmanagedType.LPStr)] StringBuilder pcszUAOut, ref uint cbSize);

		/// <summary>Registers a callback interface with an existing bind context.</summary>
		/// <param name="pbc">[in]A pointer to the IBindCtx interface from which to receive callbacks.</param>
		/// <param name="pbsc">[in]A pointer to the <c>IBindStatusCallback</c> interface implementation to be registered.</param>
		/// <param name="ppbscPrevious">[out]A pointer to a previously registered instance of <c>IBindStatusCallback</c>. May be <c>NULL</c>.</param>
		/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>No new callbacks allowed after binding has started.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory to register the callback with the bind context.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IBindStatusCallback</c> interface passed into the pbsc parameter receives callbacks on any binding operations that uses
		/// the bind context passed into the pbc parameter.
		/// </para>
		/// <para>
		/// More than one <c>IBindStatusCallback</c> can be registered at a time. Each callback is notified in sequence. If the
		/// ppbscPrevious parameter is specified, the previously registered <c>IBindStatusCallback</c> interface is removed from the list
		/// and returned. The caller would then be responsible for forwarding any binding events it receives to the previous handler, if wanted.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775115(v=vs.85) HRESULT
		// RegisterBindStatusCallback( _In_ IBindCtx *pbc, _In_ IBindStatusCallback *pbsc, _Out_ IBindStatusCallback **ppbscPrevious,
		// _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT RegisterBindStatusCallback(IBindCtx pbc, IBindStatusCallback pbsc, out IBindStatusCallback ppbscPrevious, uint dwReserved = 0);

		/// <summary>Registers a FORMATETC enumerator object on the given bind context.</summary>
		/// <param name="pBC">[in]A pointer to the IBindCtx interface for the bind context on which to register the enumerator.</param>
		/// <param name="pEFetc">[in]A pointer to the IEnumFORMATETC interface for the enumerator to register.</param>
		/// <param name="reserved">[in]Reserved. Must be set to 0.</param>
		/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters is invalid.</returns>
		/// <remarks>
		/// The enumerator is used to determine the format types that are preferred for the bind operation. Typically, the pEFetc parameter
		/// is the pointer obtained through a call to <c>CreateFormatEnumerator</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775116(v=vs.85) HRESULT
		// RegisterFormatEnumerator( _In_ LPBC pBC, _In_ IEnumFORMATETC *pEFetc, _Reserved_ DWORD reserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT RegisterFormatEnumerator(IBindCtx pBC, IEnumFORMATETC pEFetc, uint reserved = 0);

		/// <summary>Registers a mapping of media types to <c>CLSID</c> s to override the default mapping specified in the registry.</summary>
		/// <param name="pbc">[in]A pointer to the IBindCtx interface for the bind context on which the media types are registered.</param>
		/// <param name="ctypes">
		/// [in]An unsigned integer value that contains the number of media type strings in the rgszTypes array. This parameter cannot be zero.
		/// </param>
		/// <param name="rgszTypes">
		/// [in]A pointer to an array of strings that identify the media types to register. None of these strings can be <c>NULL</c>. See
		/// <c>Clipboard Formats</c> for a list of valid values.
		/// </param>
		/// <param name="rgclsID">
		/// [in]A pointer to an array of <c>CLSID</c> s to associate with the media type strings in the rgszTypes array.
		/// </param>
		/// <param name="dwReserved">[in]Reserved. Must be set to 0.</param>
		/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters is invalid.</returns>
		/// <remarks>
		/// <para>The new mapping is used in calls to IMoniker::BindToObject when binding objects on the specified bind context.</para>
		/// <para>
		/// This function is used by moniker clients calling IMoniker::BindToObject to override the default registry mapping between MIME
		/// types and <c>CLSID</c> s. Typically, the default mapping provided in the registry is used. However, a browser might require the
		/// <c>CLSID</c> for its HTML viewer to be associated with .txt files, without changing the default registry association for text
		/// files. The override is used for all bind operations using the specified bind context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775117(v=vs.85) HRESULT
		// RegisterMediaTypeClass( _In_ LPBC pbc, _In_ UINT ctypes, _In_ LPCSTR *rgszTypes, _In_ CLSID *rgclsID, _Reserved_ DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT RegisterMediaTypeClass(IBindCtx pbc, uint ctypes, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] rgszTypes, [MarshalAs(UnmanagedType.LPArray)] Guid[] rgclsID, uint dwReserved = 0);

		/// <summary>Registers media type strings.</summary>
		/// <param name="ctypes">[in]The number of media type strings in the rgszTypes array. This parameter cannot be zero.</param>
		/// <param name="rgszTypes">
		/// [in]The address of an array of strings identifying the media types to be registered. None of the strings in the array can be
		/// <c>NULL</c>. See <c>Clipboard Formats</c> for a list of valid values.
		/// </param>
		/// <param name="rgcfTypes">
		/// [out]The address of an array of the 32-bit values assigned to corresponding media types in rgszTypes. See the following Remarks
		/// section for the definition of CLIPFORMAT.
		/// </param>
		/// <returns>Returns S_OK if successful, or E_INVALIDARG if one or more parameters are invalid.</returns>
		/// <remarks/>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775118(v=vs.85) HRESULT
		// RegisterMediaTypes( _In_ UINT ctypes, _In_ LPCSTR *rgszTypes, _Out_ CLIPFORMAT *rgcfTypes );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT RegisterMediaTypes(uint ctypes, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] rgszTypes, [Out] CLIPFORMAT[] rgcfTypes);

		/// <summary>Releases the resources used by the specified <c>BINDINFO</c> structure.</summary>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775119(v=vs.85) void
		// ReleaseBindInfo( BINDINFO *pbindinfo );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern void ReleaseBindInfo(ref BINDINFO pbindinfo);

		/// <summary>Revokes a bind status callback interface previously registered on a bind context.</summary>
		/// <param name="pbc">[in]The address of the IBindCtx interface for the bind context from which the callback interface is revoked.</param>
		/// <param name="pbsc">[in]The address of the <c>IBindStatusCallback</c> interface to revoke.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Successful.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The callback interface specified is not registered on the specified bind context.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This function will not succeed if it is made during a bind operation.</para>
		/// <para>
		/// <c>Note</c> You don't have to make this call for every use of a bind context. Although it is not recommended, it is possible to
		/// reuse the same bind context and the same callback for several bind operations. After the Release method is called, all
		/// registered objects on that bind context are revoked, including the callback interfaces. Releasing a bind context implicitly
		/// releases all registered callbacks. If you want to reuse a bind context, you can use <c>RevokeBindStatusCallback</c> to remove a
		/// registered callback so that it is not reused.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775120(v=vs.85) HRESULT
		// RevokeBindStatusCallback( _In_ IBindCtx *pbc, _In_ IBindStatusCallback *pbsc );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT RevokeBindStatusCallback(IBindCtx pbc, IBindStatusCallback pbsc);

		/// <summary>Removes a format enumerator from the given bind context.</summary>
		/// <param name="pbc">[in]The address of the IBindCtx interface for the bind context from which the enumerator is to be revoked.</param>
		/// <param name="pEFetc">[in]The address of the IEnumFORMATETC interface for the enumerator to revoke.</param>
		/// <returns>Returns S_OK if the enumerator is successfully removed, or E_INVALIDARG if one or more parameters is invalid.</returns>
		/// <remarks>
		/// <para>
		/// This function removes a format enumerator from the bind context specified in pbc. The format enumerator must have been
		/// registered previously with a call to <c>RegisterFormatEnumerator</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> You don't have to make this call for every use of a bind context. Although it is not recommended it is possible to
		/// reuse the same bind context and the same format enumerator for several bind operations. After the Release method is called, all
		/// registered objects on that bind context are revoked, including the format enumerator interfaces. Releasing a bind context
		/// implicitly releases all registered format enumerators. If you want to reuse a bind context, you can use
		/// <c>RevokeFormatEnumerator</c> to remove a registered format enumerator so that it is not reused.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775121(v=vs.85) HRESULT
		// RevokeFormatEnumerator( _In_ LPBC pbc, _In_ IEnumFORMATETC *pEFetc );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT RevokeFormatEnumerator(IBindCtx pbc, IEnumFORMATETC pEFetc);

		/// <summary>Downloads data to the Internet cache and returns the file name of the cache location for retrieving the bits.</summary>
		/// <param name="lpUnkcaller">
		/// [in]A pointer to the controlling IUnknown interface of the calling ActiveX component, if the caller is an ActiveX component. If
		/// the caller is not an ActiveX component, this value can be set to <c>NULL</c>. Otherwise, the caller is a COM object that is
		/// contained in another component, such as an ActiveX control in the context of an HTML page. This parameter represents the
		/// outermost IUnknown of the calling component. The function attempts the download in the context of the ActiveX client framework,
		/// and allows the caller container to receive callbacks on the progress of the download.
		/// </param>
		/// <param name="szURL">[in]A pointer to a string value that contains the URL to download. Cannot be set to <c>NULL</c>.</param>
		/// <param name="szFileName">[out]A pointer to a string value that contains the name of the downloaded file. Cannot be set to <c>NULL</c>.</param>
		/// <param name="cchFileName">[in]An unsigned long integer value that contains the number of characters of the szFileName value.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <param name="pBSC">
		/// [in, optional]A pointer to the <c>IBindStatusCallback</c> interface of the caller. By using
		/// <c>IBindStatusCallback::OnProgress</c>, a caller can receive download status. <c>URLDownloadToCacheFile</c> calls the
		/// <c>IBindStatusCallback::OnProgress</c> and <c>IBindStatusCallback::OnDataAvailable</c> methods as data is received. The download
		/// operation can be canceled by returning E_ABORT from any callback. This parameter can be set to <c>NULL</c> if status is not required.
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The buffer length is invalid, or there is insufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation succeeded.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The client can choose to be notified of progress through a notification callback.</para>
		/// <para>
		/// This function always returns a file name, if the download operation succeeds. If the given URL is a "file:" URL,
		/// <c>URLDownloadToCacheFile</c> directly returns the file name for the "file:" URL, instead of making a copy to the cache. If the
		/// given URL is an Internet URL, such as "http:" or "ftp:," <c>URLDownloadToCacheFile</c> downloads this file and returns the local
		/// file name of the cached copy. Use this function to ensure that a file name is returned without unnecessary copying of data.
		/// </para>
		/// <para>
		/// Windows Internet Explorer 8. <c>URLDownloadToCacheFile</c> does not support <c>IBindStatusCallbackEx</c> and cannot be used to
		/// download files over 4 gigabytes (GB) in size. Refer instead to <c>IBindStatusCallbackEx::GetBindInfoEx</c> for a code example.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775122(v=vs.85) HRESULT
		// URLDownloadToCacheFile( _In_ LPUNKNOWN lpUnkcaller, _In_ LPCSTR szURL, _Out_ LPTSTR szFileName, _In_ DWORD cchFileName,
		// _Reserved_ DWORD dwReserved, _In_opt_ IBindStatusCallback *pBSC );
		[DllImport(Lib.UrlMon, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT URLDownloadToCacheFile([Optional, MarshalAs(UnmanagedType.IUnknown)] object lpUnkcaller, [MarshalAs(UnmanagedType.LPTStr)] string szURL, StringBuilder szFileName, uint cchFileName, [Optional] uint dwReserved, [Optional] IBindStatusCallback pBSC);

		/// <summary>Downloads bits from the Internet and saves them to a file.</summary>
		/// <param name="pCaller">
		/// A pointer to the controlling IUnknown interface of the calling ActiveX component, if the caller is an ActiveX component. If the
		/// calling application is not an ActiveX component, this value can be set to <c>NULL</c>. Otherwise, the caller is a COM object
		/// that is contained in another component, such as an ActiveX control in the context of an HTML page. This parameter represents the
		/// outermost IUnknown of the calling component. The function attempts the download in the context of the ActiveX client framework,
		/// and allows the caller container to receive callbacks on the progress of the download.
		/// </param>
		/// <param name="szURL">
		/// A pointer to a string value that contains the URL to download. Cannot be set to <c>NULL</c>. If the URL is invalid,
		/// INET_E_DOWNLOAD_FAILURE is returned.
		/// </param>
		/// <param name="szFileName">
		/// A pointer to a string value containing the name or full path of the file to create for the download. If szFileName includes a
		/// path, the target directory must already exist.
		/// </param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <param name="lpfnCB">
		/// A pointer to the <c>IBindStatusCallback</c> interface of the caller. By using <c>IBindStatusCallback::OnProgress</c>, a caller
		/// can receive download status. <c>URLDownloadToFile</c> calls the <c>IBindStatusCallback::OnProgress</c> and
		/// <c>IBindStatusCallback::OnDataAvailable</c> methods as data is received. The download operation can be canceled by returning
		/// E_ABORT from any callback. This parameter can be set to <c>NULL</c> if status is not required.
		/// </param>
		/// <returns>
		/// <para>This function can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The download started successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The buffer length is invalid, or there is insufficient memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>INET_E_DOWNLOAD_FAILURE</term>
		/// <term>The specified resource or callback interface was invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>URLDownloadToFile</c> binds to a host that supports <c>IBindHost</c> to perform the download. To do this, it first queries
		/// the controlling IUnknown passed as pCaller for <c>IServiceProvider</c>, then calls <c>IServiceProvider::QueryService</c> with
		/// SID_SBindHost. If pCaller does not support <c>IServiceProvider</c>, IOleObject or <c>IObjectWithSite</c> is used to query the
		/// object's host container. If no <c>IBindHost</c> interface is supported, or pCaller is <c>NULL</c>, <c>URLDownloadToFile</c>
		/// creates its own bind context to intercept download notifications.
		/// </para>
		/// <para>
		/// <c>URLDownloadToFile</c> returns S_OK even if the file cannot be created and the download is canceled. If the szFileName
		/// parameter contains a file path, ensure that the destination directory exists before calling <c>URLDownloadToFile</c>. For best
		/// control over the download and its progress, an <c>IBindStatusCallback</c> interface is recommended.
		/// </para>
		/// <para>
		/// Windows Internet Explorer 8. <c>URLDownloadToFile</c> does not support <c>IBindStatusCallbackEx</c> and cannot be used to
		/// download files over 4 gigabytes (GB) in size. Refer instead to <c>IBindStatusCallbackEx::GetBindInfoEx</c> for a code example.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775123(v=vs.85) HRESULT
		// URLDownloadToFile( LPUNKNOWN pCaller, LPCTSTR szURL, LPCTSTR szFileName, _Reserved_ DWORD dwReserved, LPBINDSTATUSCALLBACK lpfnCB );
		[DllImport(Lib.UrlMon, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT URLDownloadToFile([Optional, MarshalAs(UnmanagedType.IUnknown)] object pCaller, string szURL, StringBuilder szFileName, [Optional] uint dwReserved, [Optional] IBindStatusCallback lpfnCB);

		/// <summary>Gets options for the current Internet session.</summary>
		/// <param name="dwOption">
		/// <para>[in]</para>
		/// <para>An unsigned long integer value containing the session options to retrieve. This can be one of the following values.</para>
		/// <para><c>URLMON_OPTION_URL_ENCODING</c></para>
		/// <para>Gets the Internet Explorer default encoding policy. This value was introduced in Internet Explorer 5.</para>
		/// <para><c>URLMON_OPTION_USERAGENT</c></para>
		/// <para>Gets the current user agent string.</para>
		/// <para><c>URLMON_OPTION_USE_BINDSTRINGCREDS</c></para>
		/// <para>Gets a value that indicates whether it is safe to pass credentials to URLMON. Always returns 1.</para>
		/// <para><c>URLMON_OPTION_USE_BROWSERAPPSDOCUMENTS</c></para>
		/// <para>Gets a value that indicates whether URLMON accepts browser application documents. Always returns 1.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>[in]</para>
		/// <para>A pointer to the buffer containing the new session settings.</para>
		/// </param>
		/// <param name="dwBufferLength">
		/// <para>[in]</para>
		/// <para>An unsigned long integer value containing the size of pBuffer.</para>
		/// </param>
		/// <param name="pdwBufferLengthOut">
		/// <para>[out]</para>
		/// <para>
		/// A pointer to an unsigned long integer value containing the size of the data stored in the buffer, or the size required to store
		/// the data, if the buffer size is insufficient.
		/// </para>
		/// </param>
		/// <param name="dwReserved">
		/// <para>[in]</para>
		/// <para>Reserved. Must be set to 0.</para>
		/// </param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The option was successfully set.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The option is not supported, or there is an invalid parameter.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The option cannot be set.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775124(v=vs.85) HRESULT
		// UrlMkGetSessionOption( _In_ DWORD dwOption, _In_ __out_bcount_part_opt(dwBufferLength,*pdwBufferLengthOut) LPVOID pBuffer, _In_
		// DWORD dwBufferLength, _Out_ __out DWORD *pdwBufferLengthOut, _Reserved_ __reserved DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT UrlMkGetSessionOption(uint dwOption, IntPtr pBuffer, uint dwBufferLength, out uint pdwBufferLengthOut, uint dwReserved = 0);

		/// <summary>Sets options for the current Internet session.</summary>
		/// <param name="dwOption">
		/// <para>[in]</para>
		/// <para>An unsigned long integer value that contains the option to set. This can be one of the following values.</para>
		/// <para><c>INTERNET_OPTION_PROXY</c></para>
		/// <para>
		/// Sets the proxy settings. pBuffer must contain an INTERNET_PROXY_INFO structure. INTERNET_OPTION_PROXY and INTERNET_PROXY_INFO
		/// are defined in the file. For more information, see Introduction to the Microsoft Win32 Internet Functions.
		/// </para>
		/// <para><c>INTERNET_OPTION_REFRESH</c></para>
		/// <para>
		/// Sets the value that determines if the proxy information can be reread from the registry. The value <c>TRUE</c> indicates that
		/// the proxy information can be reread from the registry. For more information, see Introduction to the Microsoft Win32 Internet Functions.
		/// </para>
		/// <para><c>URLMON_OPTION_USERAGENT</c></para>
		/// <para>Sets the user agent string for this process.</para>
		/// <para><c>URLMON_OPTION_USERAGENT_REFRESH</c></para>
		/// <para>Refreshes the user agent string from the registry for this process.</para>
		/// </param>
		/// <param name="pBuffer">
		/// <para>[in]</para>
		/// <para>A pointer to the buffer containing the new session settings.</para>
		/// </param>
		/// <param name="dwBufferLength">
		/// <para>[in]</para>
		/// <para>An unsigned long integer value that contains the size of pBuffer.</para>
		/// </param>
		/// <param name="dwReserved">
		/// <para>[in]</para>
		/// <para>Reserved. Must be set to 0.</para>
		/// </param>
		/// <returns>Returns S_OK if options are successfully set, or E_INVALIDARG if one of the parameters is invalid.</returns>
		/// <remarks>
		/// <para>
		/// This function maps directly to the Windows Internet function InternetSetOption, although <c>UrlMkSetSessionOption</c> allows
		/// only global options to be set.
		/// </para>
		/// <para>
		/// To use this function, the client code must include the header file, which declares values for the dwOption parameter and
		/// structures for the pBuffer parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775125(v=vs.85) HRESULT
		// UrlMkSetSessionOption( _In_ DWORD dwOption, _In_ __in_bcount_opt(dwBufferLength) LPVOID pBuffer, _In_ DWORD dwBufferLength,
		// _Reserved_ __reserved DWORD dwReserved );
		[DllImport(Lib.UrlMon, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT UrlMkSetSessionOption(uint dwOption, IntPtr pBuffer, uint dwBufferLength, uint dwReserved = 0);

		/// <summary>
		/// Creates a blocking type stream object from a URL and downloads the data from the Internet. When the data is downloaded, the
		/// client application or control can read it by using the IStream::Read method.
		/// </summary>
		/// <param name="pCaller">
		/// A pointer to the controlling IUnknown interface. If the client application or control is not a COM object or a ActiveX control,
		/// the parameter can be set to <c>NULL</c>.
		/// </param>
		/// <param name="szURL">A pointer to a string value containing the URL to convert to a stream object. Cannot be set to <c>NULL</c>.</param>
		/// <param name="ppStream">
		/// A pointer to the IStream interface on the stream object created by this function. The caller can read from the stream as soon as
		/// it has this pointer.
		/// </param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <param name="lpfnCB">A pointer to the caller <c>IBindStatusCallback</c> interface. Can be set to <c>NULL</c>.</param>
		/// <returns>Returns S_OK if the operation succeeded, or E_OUTOFMEMORY if there is insufficient memory to complete the operation.</returns>
		/// <remarks>
		/// <para>This function is synchronous and returns only after all the data has been downloaded from the Internet.</para>
		/// <para>
		/// If the <c>IBindStatusCallback::OnProgress</c> method is provided, <c>URLOpenBlockingStream</c> calls the method on a connection
		/// activity, including the arrival of data. <c>IBindStatusCallback::OnDataAvailable</c> is never called. By using
		/// <c>IBindStatusCallback::OnProgress</c>, a caller can implement a user interface or other progress monitoring functionality. The
		/// download operation can be canceled by returning E_ABORT from the <c>IBindStatusCallback::OnProgress</c> call.
		/// </para>
		/// <para><c>Note</c><c>URLOpenBlockingStream</c> should not be used with protocols that do not return content, such as <c>mailto</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775127(v=vs.85) HRESULT
		// URLOpenBlockingStream( LPUNKNOWN pCaller, LPCSTR szURL, LPSTREAM *ppStream, _Reserved_ DWORD dwReserved, LPBINDSTATUSCALLBACK
		// lpfnCB );
		[DllImport(Lib.UrlMon, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT URLOpenBlockingStream([Optional, MarshalAs(UnmanagedType.IUnknown)] object pCaller, [MarshalAs(UnmanagedType.LPTStr)] string szURL, out IStream ppStream, [Optional] uint dwReserved, [Optional] IBindStatusCallback lpfnCB);

		/// <summary>Creates a pull type stream object from a URL.</summary>
		/// <param name="pCaller">
		/// A pointer to the controlling IUnknown interface of the calling ActiveX component, if the caller is an ActiveX component. If the
		/// caller is not an ActiveX component, this value can be set to <c>NULL</c>. Otherwise, the caller is a COM object that is
		/// contained in another component, such as an ActiveX control in the context of an HTML page. This parameter represents the
		/// outermost IUnknown of the calling component. The function attempts the download in the context of the ActiveX client framework,
		/// and allows the caller container to receive callbacks on the progress of the download.
		/// </param>
		/// <param name="szURL">A string containing the URL to be converted to a stream object. Cannot be set to <c>NULL</c>.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <param name="lpfnCB">
		/// A pointer to the caller <c>IBindStatusCallback</c> interface, on which <c>URLOpenPullStream</c> calls
		/// <c>IBindStatusCallback::OnDataAvailable</c> when data arrives from the Internet. The download operation can be canceled by
		/// returning E_ABORT from the <c>IBindStatusCallback::OnDataAvailable</c> call.
		/// </param>
		/// <returns>Returns S_OK if the operation succeeded, or E_OUTOFMEMORY if there is insufficient memory to complete the operation.</returns>
		/// <remarks>
		/// <para>
		/// The pull model is more cumbersome than the push model, but it allows the client to control the amount of Internet access for the download.
		/// </para>
		/// <para>
		/// The data is downloaded from the Internet on demand. If not enough data is available locally to satisfy the requests, the
		/// IStream::Read call will not block until enough data arrives. Instead, IStream::Read immediately returns E_PENDING, and
		/// <c>URLOpenPullStream</c> requests the next packet of data from the Internet server.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775128(v=vs.85) HRESULT
		// URLOpenPullStream( LPUNKNOWN pCaller, LPCSTR szURL, _Reserved_ DWORD dwReserved, LPBINDSTATUSCALLBACK lpfnCB );
		[DllImport(Lib.UrlMon, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT URLOpenPullStream([Optional, MarshalAs(UnmanagedType.IUnknown)] object pCaller, [MarshalAs(UnmanagedType.LPTStr)] string szURL, [Optional] uint dwReserved, [Optional] IBindStatusCallback lpfnCB);

		/// <summary>Creates a push type stream object from a URL.</summary>
		/// <param name="pCaller">
		/// A pointer to the controlling IUnknown interface of the calling ActiveX component, if the caller is an ActiveX component. If the
		/// caller is not an ActiveX component, this value can be set to <c>NULL</c>. Otherwise, the caller is a COM object that is
		/// contained in another component, such as an ActiveX control in the context of an HTML page). This parameter represents the
		/// outermost IUnknown of the calling component. The function attempts the download in the context of the ActiveX client framework,
		/// and allows the caller container to receive callbacks on the progress of the download.
		/// </param>
		/// <param name="szURL">A string containing the URL to be converted to a stream object. Cannot be set to <c>NULL</c>.</param>
		/// <param name="dwReserved">Reserved. Must be set to 0.</param>
		/// <param name="lpfnCB">
		/// A pointer to the caller <c>IBindStatusCallback</c> interface, on which <c>URLOpenStream</c> calls
		/// <c>IBindStatusCallback::OnDataAvailable</c> when data arrives from the Internet. The download operation can be canceled by
		/// returning E_ABORT from the <c>IBindStatusCallback::OnDataAvailable</c> call.
		/// </param>
		/// <returns>Returns S_OK if the operation succeeded, or E_OUTOFMEMORY if there is insufficient memory to complete the operation.</returns>
		/// <remarks>
		/// The data is downloaded from the Internet as fast as possible. When data is available, it is pushed at the client through a
		/// notification callback.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775129(v=vs.85) HRESULT
		// URLOpenStream( LPUNKNOWN pCaller, LPCSTR szURL, _Reserved_ DWORD dwReserved, LPBINDSTATUSCALLBACK lpfnCB );
		[DllImport(Lib.UrlMon, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Urlmon.h")]
		public static extern HRESULT URLOpenStream([Optional, MarshalAs(UnmanagedType.IUnknown)] object pCaller, [MarshalAs(UnmanagedType.LPTStr)] string szURL, [Optional] uint dwReserved, [Optional] IBindStatusCallback lpfnCB);

		/// <summary>
		/// Contains additional information on the requested binding operation. The meaning of this structure is specific to the type of
		/// asynchronous moniker.
		/// </summary>
		/// <remarks>
		/// The size of this structure changed with the release of Microsoft Internet Explorer 4.0. Developers must write code that checks
		/// the size of the <c>BINDINFO</c> structure that is passed into their implementation of this method before writing to members of
		/// the structure. For more information, see Handling BINDINFO Structures.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms774966%28v%3dvs.85%29
		// typedef struct _tagBINDINFO { unsigned long cbSize; LPWSTR szExtraInfo; STGMEDIUM stgmedData; DWORD grfBindInfoF; DWORD
		// dwBindVerb; LPWSTR szCustomVerb; DWORD cbStgmedData; DWORD dwOptions; DWORD dwOptionsFlags; DWORD dwCodePage; SECURITY_ATTRIBUTES
		// securityAttributes; IID iid; IUnknown *pUnk; DWORD dwReserved; } BINDINFO;
		[PInvokeData("Urlmon.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct BINDINFO
		{
			/// <summary>Size of the structure, in bytes.</summary>
			public uint cbSize;

			/// <summary>
			/// Behavior of this field is moniker-specific. For URL monikers, this string is appended to the URL when the bind operation is
			/// started. Like other OLE strings, this value is a Unicode string that the client should allocate using CoTaskMemAlloc. The
			/// URL moniker frees the memory later.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string szExtraInfo;

			/// <summary>Data to be used in a PUT or POST operation specified by the <c>dwBindVerb</c> member.</summary>
			public STGMEDIUM stgmedData;

			/// <summary>
			/// Flag from the <c>BINDINFOF</c> enumeration that determines the use of URL encoding during the bind operation. This member is
			/// specific to URL monikers.
			/// </summary>
			public uint grfBindInfoF;

			/// <summary>Value from the <c>BINDVERB</c> enumeration specifying an action to be performed during the bind operation.</summary>
			public uint dwBindVerb;

			/// <summary>
			/// specifying a protocol-specific custom action to be performed during the bind operation (only if <c>dwBindVerb</c> is set to BINDVERB_CUSTOM).
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string szCustomVerb;

			/// <summary>Size of the data provided in the <c>stgmedData</c> member.</summary>
			public uint cbStgmedData;

			/// <summary>Value from the <c>BINDINFO_OPTIONS</c> enumeration specifying flags for the bind operation.</summary>
			public uint dwOptions;

			/// <summary>Additional Win32 Internet API flags. Must also set <c>BINDINFO_OPTIONS_WININETFLAG</c> in <c>dwOptions</c>.</summary>
			public uint dwOptionsFlags;

			/// <summary>
			/// Unsigned long integer value that contains the code page used to perform the conversion. This can be one of the following values:
			/// </summary>
			public uint dwCodePage;

			/// <summary>
			/// SECURITY_ATTRIBUTES structure that contains the descriptor for the object being bound to and indicates whether the handle
			/// retrieved by specifying this structure is inheritable.
			/// </summary>
			public tagSECURITY_ATTRIBUTES securityAttributes;

			/// <summary>Interface identifier of the IUnknown interface referred to by <c>pUnk</c>.</summary>
			public Guid iid;

			/// <summary>Pointer to the IUnknown interface.</summary>
			public IntPtr pUnk;

			/// <summary>Reserved. Must be zero.</summary>
			public uint dwReserved;

			/// <summary>A default instance of this structure with the size set.</summary>
			public static readonly BINDINFO Default = new BINDINFO { cbSize = (uint)Marshal.SizeOf(typeof(BINDINFO)), securityAttributes = tagSECURITY_ATTRIBUTES.Default };
		}
	}
}