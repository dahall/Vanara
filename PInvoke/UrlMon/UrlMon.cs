using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Functions and interfaces from UrlMon.dll. URL monikers allow an application to bind a resource, specified by a URL, to a moniker.
	/// Asynchronous pluggable protocols enable developers to create pluggable protocol handlers, MIME filters, and namespace handlers.
	/// </summary>
	public static partial class UrlMon
	{
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

		/// <summary>
		/// Exposes methods and properties used to parse and build Uniform Resource Identifiers (URIs) in Windows Internet Explorer 7.
		/// </summary>
		/// <remarks>
		/// Once an <c>IUri</c> has been created, it cannot change its properties. Property values do not change between calls to the same object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775038(v=vs.85)?redirectedfrom=MSDN
		[PInvokeData("Urlmon.h")]
		[ComImport, Guid("A39EE748-6A27-4817-A6F2-13914BEF5890"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IUri
		{
			/// <summary>Returns the specified Uniform Resource Identifier (URI) property value in a new <c>BSTR</c>.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pbstrProperty">
			/// <para>[out]</para>
			/// <para>Address of a <c>BSTR</c> that receives the property value.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyBSTR</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>
			/// The pbstrProperty parameter will be set to a new <c>BSTR</c> containing the value of the specified string property. The
			/// caller should use SysFreeString to free the string.
			/// </para>
			/// <para>This method will return and set pbstrProperty to an empty string if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775026(v=vs.85)
			// HRESULT GetPropertyBSTR( [in] Uri_PROPERTY uriProp, [out] BSTR *pbstrProperty, [in] DWORD dwFlags );
			void GetPropertyBSTR([In] Uri_PROPERTY uriProp, [MarshalAs(UnmanagedType.BStr)] out string pbstrProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>
			/// Returns the string length of the specified Uniform Resource Identifier (URI) property. Call this function if you want the
			/// length but don't necessarily want to create a new <c>BSTR</c>.
			/// </summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pcchProperty">
			/// <para>[out]</para>
			/// <para>
			/// Address of a <c>DWORD</c> that is set to the length of the value of the string property excluding the <c>NULL</c> terminator.
			/// </para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>[in]</para>
			/// <para>One of the following property-specific flags, or zero.</para>
			/// <para><c>Uri_DISPLAY_NO_FRAGMENT</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c>: Exclude the fragment portion of the URI, if any.</para>
			/// <para><c>Uri_PUNYCODE_IDN_HOST</c> (0x00000002)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: If the URI is an IDN, always display
			/// the hostname encoded as punycode.
			/// </para>
			/// <para><c>Uri_DISPLAY_IDN_HOST</c> (0x00000004)</para>
			/// <para>
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c>, <c>Uri_PROPERTY_DOMAIN</c>, <c>Uri_PROPERTY_HOST</c>: Display the hostname in punycode or
			/// Unicode as it would appear in the <c>Uri_PROPERTY_DISPLAY_URI</c> property.
			/// </para>
			/// </param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyLength</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a string property. This method will fail if the specified property isn't a <c>BSTR</c> property.
			/// </para>
			/// <para>This method will return and set pcchProperty to if the URI doesn't contain the specified property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775028(v=vs.85)
			// HRESULT GetPropertyLength( [in] Uri_PROPERTY uriProp, [out] DWORD *pcchProperty, [in] DWORD dwFlags );
			void GetPropertyLength([In] Uri_PROPERTY uriProp, out uint pcchProperty, [In] Uri_DISPLAY dwFlags);

			/// <summary>Returns the specified numeric Uniform Resource Identifier (URI) property value.</summary>
			/// <param name="uriProp">
			/// <para>[in]</para>
			/// <para>A value from the <c>Uri_PROPERTY</c> enumeration.</para>
			/// </param>
			/// <param name="pdwProperty">Address of a DWORD that is set to the value of the specified property.</param>
			/// <param name="dwFlags">Property-specific flags. Must be set to 0.</param>
			/// <remarks>
			/// <para><c>IUri::GetPropertyDWORD</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The uriProp parameter must be a numeric property. This method will fail if the specified property isn't a <c>DWORD</c> property.
			/// </para>
			/// <para>This method will return and set pdwProperty to if the specified property doesn't exist in the URI.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775027(v=vs.85)
			// HRESULT GetPropertyDWORD( [in] Uri_PROPERTY uriProp, [out] DWORD *pdwProperty, [in] DWORD dwFlags );
			void GetPropertyDWORD([In] Uri_PROPERTY uriProp, out uint pdwProperty, [In] uint dwFlags);

			/// <summary>Determines if the specified property exists in the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a BOOL value. Set to TRUE if the specified property exists in the URI.</returns>
			/// <remarks><c>IUri::HasProperty</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775036(v=vs.85)
			// HRESULT HasProperty( [in] Uri_PROPERTY uriProp, [out] BOOL *pfHasProperty );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool HasProperty([In] Uri_PROPERTY uriProp);

			/// <summary>Returns the entire canonicalized Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAbsoluteUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_ABSOLUTE_URI</c> property.
			/// </para>
			/// <para>This property is not defined for relative URIs.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775013%28v%3dvs.85%29
			// HRESULT GetAbsoluteUri( [out] BSTR *pbstrAbsoluteUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetAbsoluteUri();

			/// <summary>Returns the user name, password, domain, and port.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetAuthority</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_AUTHORITY</c> property.
			/// </para>
			/// <para>
			/// If user name and password are not specified, the separator characters (: and @) are removed. The trailing colon is also
			/// removed if the port number is not specified or is the default for the protocol scheme.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775014(v=vs.85)
			// HRESULT GetAuthority( [out] BSTR *pbstrAuthority );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetAuthority();

			/// <summary>Returns a Uniform Resource Identifier (URI) that can be used for display purposes.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDisplayUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// The display URI combines protocol scheme, fully qualified domain name, port number (if not the default for the scheme), full
			/// resource path, query string, and fragment.
			/// </para>
			/// <para>
			/// <c>Note</c> The display URI may have additional formatting applied to it, such that the string produced by
			/// <c>IUri::GetDisplayUri</c> isn't necessarily a valid URI. For this reason, and since the userinfo is not present, the
			/// display URI should be used for viewing only; it should not be used for edit by the user, or as a form of transfer for URIs
			/// inside or between applications.
			/// </para>
			/// <para>
			/// If the scheme is known (for example, http, ftp, or file) then the display URI will hide credentials. However, if the URI
			/// uses an unknown scheme and supplies user name and password, the display URI will also contain the user name and password.
			/// </para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_DISPLAY_URI</c> property and no flags.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775015(v=vs.85)
			// HRESULT GetDisplayUri( [out] BSTR *pbstrDisplayString );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetDisplayUri();

			/// <summary>Returns the domain name (including top-level domain) only.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetDomain</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_DOMAIN</c> property.
			/// </para>
			/// <para>
			/// If the URL contains only a plain hostname (for example, "http://example/") or a public suffix (for example,
			/// "http://co.uk/"), then <c>IUri::GetDomain</c> returns <c>NULL</c>. Use <c>IUri::GetHost</c> instead.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775016(v=vs.85)
			// HRESULT GetDomain( [out] BSTR *pbstrDomain );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetDomain();

			/// <summary>Returns the file name extension of the resource.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetExtension</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_EXTENSION</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775017(v=vs.85)
			// HRESULT GetExtension( [out] BSTR *pbstrExtension );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetExtension();

			/// <summary>Returns the text following a fragment marker (#), including the fragment marker itself.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetFragment</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_FRAGMENT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775018(v=vs.85)
			// HRESULT GetFragment( [out] BSTR *pbstrFragment );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetFragment();

			/// <summary>Returns the fully qualified domain name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHost</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_HOST</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775019(v=vs.85)
			// HRESULT GetHost( [out] BSTR *pbstrHost );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetHost();

			/// <summary>Returns the password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPassword</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PASSWORD</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775021(v=vs.85)
			// HRESULT GetPassword( [out] BSTR *pbstrPassword );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetPassword();

			/// <summary>Returns the path and resource name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPath</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_PATH</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775022(v=vs.85)
			// HRESULT GetPath( [out] BSTR *pbstrPath );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetPath();

			/// <summary>Returns the path, resource name, and query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPathAndQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_PATH_AND_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775023(v=vs.85)
			// HRESULT GetPathAndQuery( [out] BSTR *pbstrPathAndQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetPathAndQuery();

			/// <summary>Returns the query string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetQuery</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the <c>Uri_PROPERTY_QUERY</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775029(v=vs.85)
			// HRESULT GetQuery( [out] BSTR *pbstrQuery );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetQuery();

			/// <summary>Returns the entire original Uniform Resource Identifier (URI) input string.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetRawUri</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_RAW_URI</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775030(v=vs.85)
			// HRESULT GetRawUri( [out] BSTR *pbstrRawUri );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetRawUri();

			/// <summary>Returns the protocol scheme name.</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetSchemeName</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_SCHEME_NAME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775032(v=vs.85)
			// HRESULT GetSchemeName( [out] BSTR *pbstrSchemeName );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetSchemeName();

			/// <summary>Returns the user name and password, as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetUserInfo</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// <c>Security Warning:</c> Storing sensitive information as clear text in a URI is not recommended. According to RFC3986:
			/// Uniform Resource Identifier (URI), Generic Syntax, Section 7.5, "A password appearing within the userinfo component is
			/// deprecated and should be considered an error except in those rare cases where the 'password' parameter is intended to be public."
			/// </para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_INFO</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775033(v=vs.85)
			// HRESULT GetUserInfo( [out] BSTR *pbstrUserInfo );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetUserInfo();

			/// <summary>Returns the user name as parsed from the Uniform Resource Identifier (URI).</summary>
			/// <returns>Address of a string that receives the property value.</returns>
			/// <remarks>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyBSTR</c> with the
			/// <c>Uri_PROPERTY_USER_NAME</c> property.
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775034(v=vs.85)
			// HRESULT GetUserName( [out] BSTR *pbstrUserName );
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetUserName();

			/// <summary>Returns a value from the <c>Uri_HOST_TYPE</c> enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the Uri_HOST_TYPE enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetHostType</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_HOST_TYPE</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775020(v=vs.85)
			// HRESULT GetHostType( [out] DWORD *pdwHostType );
			Uri_HOST_TYPE GetHostType();

			/// <summary>Returns the port number.</summary>
			/// <returns>Address of a DWORD that receives the port number value.</returns>
			/// <remarks>
			/// <para><c>IUri::GetPort</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the <c>Uri_PROPERTY_PORT</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775024(v=vs.85)
			// HRESULT GetPort( [out] DWORD *pdwPort );
			uint GetPort();

			/// <summary>Returns a value from the URL_SCHEME enumeration.</summary>
			/// <returns>Address of a DWORD that receives a value from the URL_SCHEME enumeration.</returns>
			/// <remarks>
			/// <para><c>IUri::GetScheme</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>
			/// This function is for convenience. It is the same as calling <c>IUri::GetPropertyDWORD</c> with the
			/// <c>Uri_PROPERTY_SCHEME</c> property.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775031(v=vs.85)
			// HRESULT GetScheme( [out] DWORD *pdwScheme );
			URL_SCHEME GetScheme();

			/// <summary>This method is not implemented.</summary>
			/// <returns/>
			URLZONE GetZone();

			/// <summary>Returns a bitmap of flags that indicate which Uniform Resource Identifier (URI) properties have been set.</summary>
			/// <param name="pdwFlags">
			/// <para>[out]</para>
			/// <para>Address of a <c>DWORD</c> that receives a combination of the following flags:</para>
			/// <para><c>Uri_HAS_ABSOLUTE_URI</c> (0x00000000)</para>
			/// <para><c>Uri_PROPERTY_ABSOLUTE_URI</c> exists.</para>
			/// <para><c>Uri_HAS_AUTHORITY</c> (0x00000001)</para>
			/// <para><c>Uri_PROPERTY_AUTHORITY</c> exists.</para>
			/// <para><c>Uri_HAS_DISPLAY_URI</c> (0x00000002)</para>
			/// <para><c>Uri_PROPERTY_DISPLAY_URI</c> exists.</para>
			/// <para><c>Uri_HAS_DOMAIN</c> (0x00000004)</para>
			/// <para><c>Uri_PROPERTY_DOMAIN</c> exists.</para>
			/// <para><c>Uri_HAS_EXTENSION</c> (0x00000008)</para>
			/// <para><c>Uri_PROPERTY_EXTENSION</c> exists.</para>
			/// <para><c>Uri_HAS_FRAGMENT</c> (0x00000010)</para>
			/// <para><c>Uri_PROPERTY_FRAGMENT</c> exists.</para>
			/// <para><c>Uri_HAS_HOST</c> (0x00000020)</para>
			/// <para><c>Uri_PROPERTY_HOST</c> exists.</para>
			/// <para><c>Uri_HAS_HOST_TYPE</c> (0x00004000)</para>
			/// <para><c>Uri_PROPERTY_HOST_TYPE</c> exists.</para>
			/// <para><c>Uri_HAS_PASSWORD</c> (0x00000040)</para>
			/// <para><c>Uri_PROPERTY_PASSWORD</c> exists.</para>
			/// <para><c>Uri_HAS_PATH</c> (0x00000080)</para>
			/// <para><c>Uri_PROPERTY_PATH</c> exists.</para>
			/// <para><c>Uri_HAS_PATH_AND_QUERY</c> (0x00001000)</para>
			/// <para><c>Uri_PROPERTY_PATH_AND_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_PORT</c> (0x00008000)</para>
			/// <para><c>Uri_PROPERTY_PORT</c> exists.</para>
			/// <para><c>Uri_HAS_QUERY</c> (0x00000100)</para>
			/// <para><c>Uri_PROPERTY_QUERY</c> exists.</para>
			/// <para><c>Uri_HAS_RAW_URI</c> (0x00000200)</para>
			/// <para><c>Uri_PROPERTY_RAW_URI</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME</c> (0x00010000)</para>
			/// <para><c>Uri_PROPERTY_SCHEME</c> exists.</para>
			/// <para><c>Uri_HAS_SCHEME_NAME</c> (0x00000400)</para>
			/// <para><c>Uri_PROPERTY_SCHEME_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_NAME</c> (0x00000800)</para>
			/// <para><c>Uri_PROPERTY_USER_NAME</c> exists.</para>
			/// <para><c>Uri_HAS_USER_INFO</c> (0x00002000)</para>
			/// <para><c>Uri_PROPERTY_USER_INFO</c> exists.</para>
			/// <para><c>Uri_HAS_ZONE</c> (0x00020000)</para>
			/// <para><c>Uri_PROPERTY_ZONE</c> exists.</para>
			/// </param>
			/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
			/// <remarks><c>IUri::GetProperties</c> was introduced in Windows Internet Explorer 7.</remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775025(v=vs.85)
			// HRESULT GetProperties( [out] LPDWORD pdwFlags );
			Uri_HAS GetProperties();

			/// <summary>Compares the logical content of two <c>IUri</c> objects.</summary>
			/// <returns>Address of a BOOL that is set to TRUE if the logical content of pUri is the same.</returns>
			/// <remarks>
			/// <para><c>IUri::IsEqual</c> was introduced in Windows Internet Explorer 7.</para>
			/// <para>The comparison is case-insensitive. Comparing an <c>IUri</c> to itself will always return <c>TRUE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775037(v=vs.85)
			// HRESULT IsEqual( [in] IUri *pUri, [out] BOOL *pfEqual );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsEqual([In] IUri pUri);
		}

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
	}
}