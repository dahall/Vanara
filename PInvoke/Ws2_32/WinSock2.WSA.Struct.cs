#pragma warning disable IDE1006 // Naming Styles

using System.Data;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from ws2_32.h.</summary>
public static partial class Ws2_32
{
	/// <summary>
	/// The <c>fd_set</c> structure is used by various Windows Sockets functions and service providers, such as the select function, to
	/// place sockets into a "set" for various purposes, such as testing a given socket for readability using the readfds parameter of
	/// the <c>select</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock/ns-winsock-fd_set typedef struct fd_set { u_int fd_count; SOCKET
	// fd_array[FD_SETSIZE]; } fd_set, FD_SET, *PFD_SET, *LPFD_SET;
	[PInvokeData("winsock.h", MSDNShortId = "2af5d69d-190e-4814-8d8b-438431808625")]
	[StructLayout(LayoutKind.Sequential)]
	public struct fd_set
	{
		/// <summary>The number of sockets in the set.</summary>
		public uint fd_count;

		/// <summary>An array of sockets that are in the set.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public SOCKET[] fd_array;
	}

	/// <summary>
	/// The <c>WSACOMPLETION</c> structure specifies completion notification settings for I/O control calls made to a registered namespace.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WSACOMPLETION</c> structure enables callbacks to be provided in any of the following formats, based on the value provided in <c>Type</c>:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Callback Format</term>
	/// <term>Type value</term>
	/// </listheader>
	/// <item>
	/// <term>Polling</term>
	/// <term>NSP_NOTIFY_IMMEDIATELY</term>
	/// </item>
	/// <item>
	/// <term>Window Message</term>
	/// <term>NSP_NOTIFY_HWND</term>
	/// </item>
	/// <item>
	/// <term>Event</term>
	/// <term>NSP_NOTIFY_EVENT</term>
	/// </item>
	/// <item>
	/// <term>APC</term>
	/// <term>NSP_NOTIFY_APC</term>
	/// </item>
	/// <item>
	/// <term>Completion Port</term>
	/// <term>NSP_NOTIFY_PORT</term>
	/// </item>
	/// </list>
	/// <para>For a blocking function, set the <c>WSACOMPLETION</c> structure to null.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsacompletion typedef struct _WSACOMPLETION {
	// WSACOMPLETIONTYPE Type; union { struct { HWND hWnd; UINT uMsg; WPARAM context; } WindowMessage; struct { LPWSAOVERLAPPED lpOverlapped;
	// } Event; struct { LPWSAOVERLAPPED lpOverlapped; LPWSAOVERLAPPED_COMPLETION_ROUTINE lpfnCompletionProc; } Apc; struct { LPWSAOVERLAPPED
	// lpOverlapped; HANDLE hPort; ULONG_PTR Key; } Port; } Parameters; } WSACOMPLETION, *PWSACOMPLETION, *LPWSACOMPLETION;
	[PInvokeData("winsock2.h", MSDNShortId = "NS:winsock2._WSACOMPLETION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSACOMPLETION
	{
		/// <summary>
		/// <para>Type: <c>WSACOMPLETIONTYPE</c></para>
		/// <para>The type of completion notification required. See Remarks.</para>
		/// </summary>
		public WSACOMPLETIONTYPE Type;

		/// <summary>
		/// The parameters required to complete the callback. The structures within the Parameters union specify information required for
		/// completing the callback of each given type. For example, the <c>WindowMessage</c> structure must be filled when <c>Type</c> is
		/// set to NSP_NOTIFY_HWND.
		/// </summary>
		public UNION Parameters;

		/// <summary>
		/// The parameters required to complete the callback. The structures within the Parameters union specify information required for
		/// completing the callback of each given type. For example, the <c>WindowMessage</c> structure must be filled when <c>Type</c> is
		/// set to NSP_NOTIFY_HWND.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary />
			[FieldOffset(0)]
			public WINDOWMESSAGE WindowMessage;

			/// <summary />
			[FieldOffset(0)]
			public EVENT Event;

			/// <summary />
			[FieldOffset(0)]
			public APC Apc;

			/// <summary />
			[FieldOffset(0)]
			public PORT Port;

			/// <summary />
			[StructLayout(LayoutKind.Sequential)]
			public struct WINDOWMESSAGE
			{
				/// <summary><c>Type: <c>HWND</c></c> Windows handle.</summary>
				public HWND hWnd;
				/// <summary><c>Type: <c>UINT</c></c> Message handle.</summary>
				public uint uMsg;
				/// <summary><c>Type: <c>WPARAM</c></c> Context of the message or handle.</summary>
				public IntPtr context;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct EVENT
			{
				/// <summary><c>Type: <c>LPWSAOVERLAPPED</c></c> A pointer to a WSAOVERLAPPED structure.</summary>
				public IntPtr lpOverlapped;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct APC
			{
				/// <summary><c>Type: <c>LPWSAOVERLAPPED</c></c> A pointer to a WSAOVERLAPPED structure.</summary>
				public IntPtr lpOverlapped;

				/// <summary>
				/// <para>Type: _In_opt_ <c>LPWSAOVERLAPPED_COMPLETION_ROUTINE</c></para>
				/// <para>A pointer to an application-provided completion routine.</para>
				/// </summary>
				[MarshalAs(UnmanagedType.FunctionPtr)]
				public LPWSAOVERLAPPED_COMPLETION_ROUTINE lpfnCompletionProc;
			}

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct PORT
			{
				/// <summary><c>Type: <c>LPWSAOVERLAPPED</c></c> A pointer to a WSAOVERLAPPED structure.</summary>
				public IntPtr lpOverlapped;

				/// <summary><c>Type: <c>HANDLE</c></c> A handle to the port.</summary>
				public HANDLE hPort;

				/// <summary><c>Type: <c>ULONG_PTR</c></c> A pointer to the key.</summary>
				public IntPtr Key;
			}
		}
	}

	/// <summary>The <c>WSANETWORKEVENTS</c> structure is used to store a socket's internal information about network events.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsanetworkevents typedef struct _WSANETWORKEVENTS { long
	// lNetworkEvents; int iErrorCode[FD_MAX_EVENTS]; } WSANETWORKEVENTS, *LPWSANETWORKEVENTS;
	[PInvokeData("winsock2.h", MSDNShortId = "72ae4aa8-4e15-4215-8dcb-45e394ac1313")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSANETWORKEVENTS
	{
		/// <summary>Indicates which of the FD_XXX network events have occurred.</summary>
		public int lNetworkEvents;

		/// <summary>
		/// Array that contains any associated error codes, with an array index that corresponds to the position of event bits in
		/// <c>lNetworkEvents</c>. The identifiers FD_READ_BIT, FD_WRITE_BIT and others can be used to index the <c>iErrorCode</c> array.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public int[] iErrorCode;
	}

	/// <summary>The <c>WSANSCLASSINFO</c> structure provides individual parameter information for a specific Windows Sockets namespace.</summary>
	/// <remarks>
	/// The <c>WSANSCLASSINFO</c> structure is defined differently depending on whether ANSI or UNICODE is used. The above syntax block
	/// applies to ANSI; for UNICODE, the datatype for <c>lpszName</c> is <c>LPWSTR</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsansclassinfoa typedef struct _WSANSClassInfoA { LPSTR
	// lpszName; DWORD dwNameSpace; DWORD dwValueType; DWORD dwValueSize; LPVOID lpValue; } WSANSCLASSINFOA, *PWSANSCLASSINFOA, *LPWSANSCLASSINFOA;
	[PInvokeData("winsock2.h", MSDNShortId = "b4f811ad-7967-45bd-b563-a28bb1633596")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WSANSCLASSINFO
	{
		/// <summary>String value associated with the parameter, such as SAPID, TCPPORT, and so forth.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string lpszName;

		/// <summary>GUID associated with the namespace.</summary>
		public uint dwNameSpace;

		/// <summary>Value type for the parameter, such as REG_DWORD or REG_SZ, and so forth.</summary>
		public uint dwValueType;

		/// <summary>Size of the parameter provided in <c>lpValue</c>, in bytes.</summary>
		public uint dwValueSize;

		/// <summary>Pointer to the value of the parameter.</summary>
		public IntPtr lpValue;
	}

	/// <summary>The <c>WSAPOLLFD</c> structure stores socket information used by the WSAPoll function.</summary>
	/// <remarks>
	/// <para>The <c>WSAPOLLFD</c> structure is defined on Windows Vista and later.</para>
	/// <para>
	/// The <c>WSAPOLLFD</c> structure is used by the WSAPoll function to determine the status of one or more sockets. The set of
	/// sockets for which status is requested is specified in fdarray parameter, which is an array of <c>WSAPOLLFD</c> structures. An
	/// application sets the appropriate flags in the <c>events</c> member of the <c>WSAPOLLFD</c> structure to specify the type of
	/// status requested for each corresponding socket. The <c>WSAPoll</c> function returns the status of a socket in the <c>revents</c>
	/// member of the <c>WSAPOLLFD</c> structure.
	/// </para>
	/// <para>
	/// If the <c>fd</c> member of the <c>WSAPOLLFD</c> structure is set to a negative value, the structure is ignored by the WSAPoll
	/// function call, and the <c>revents</c> member is cleared upon return. This is useful to applications that maintain a fixed
	/// allocation for the fdarray parameter of <c>WSAPoll</c>; such applications need not waste resources compacting elements of the
	/// array for unused entries or reallocating memory. It is unnecessary to clear the <c>revents</c> member prior to calling the
	/// <c>WSAPoll</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsapollfd typedef struct pollfd { SOCKET fd; SHORT
	// events; SHORT revents; } WSAPOLLFD, *PWSAPOLLFD, *LPWSAPOLLFD;
	[PInvokeData("winsock2.h", MSDNShortId = "88f122ce-e2ca-44ce-bd53-d73d0962e7ef")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WSAPOLLFD
	{
		/// <summary>
		/// <para>Type: <c>SOCKET</c></para>
		/// <para>The identifier of the socket for which to find status. This parameter is ignored if set to a negative value. See Remarks.</para>
		/// </summary>
		public SOCKET? fd;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>A set of flags indicating the type of status being requested. This must be one or more of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>POLLPRI</term>
		/// <term>Priority data may be read without blocking. This flag is not supported by the Microsoft Winsock provider.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDBAND</term>
		/// <term>Priority band (out-of-band) data can be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDNORM</term>
		/// <term>Normal data can be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLWRNORM</term>
		/// <term>Normal data can be written without blocking.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The POLLIN flag is defined as the combination of the <c>POLLRDNORM</c> and <c>POLLRDBAND</c> flag values. The POLLOUT flag
		/// is defined as the same as the <c>POLLWRNORM</c> flag value.
		/// </para>
		/// </summary>
		public PollFlags events;

		/// <summary>
		/// <para>Type: <c>short</c></para>
		/// <para>
		/// A set of flags that indicate, upon return from the WSAPoll function call, the results of the status query. This can a
		/// combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>POLLERR</term>
		/// <term>An error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>POLLHUP</term>
		/// <term>A stream-oriented connection was either disconnected or aborted.</term>
		/// </item>
		/// <item>
		/// <term>POLLNVAL</term>
		/// <term>An invalid socket was used.</term>
		/// </item>
		/// <item>
		/// <term>POLLPRI</term>
		/// <term>Priority data may be read without blocking. This flag is not returned by the Microsoft Winsock provider.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDBAND</term>
		/// <term>Priority band (out-of-band) data may be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLRDNORM</term>
		/// <term>Normal data may be read without blocking.</term>
		/// </item>
		/// <item>
		/// <term>POLLWRNORM</term>
		/// <term>Normal data may be written without blocking.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The POLLIN flag is defined as the combination of the <c>POLLRDNORM</c> and <c>POLLRDBAND</c> flag values. The POLLOUT flag
		/// is defined as the same as the <c>POLLWRNORM</c> flag value.
		/// </para>
		/// <para>
		/// For sockets that do not satisfy the status query, and have no error, the <c>revents</c> member is set to zero upon return.
		/// </para>
		/// </summary>
		public PollFlags revents;
	}

	/// <summary>
	/// The <c>WSAQUERYSET</c> structure provides relevant information about a given service, including service class ID, service name,
	/// applicable namespace identifier and protocol information, as well as a set of transport addresses at which the service listens.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WSAQUERYSET</c> structure is used as part of the original namespace provider version 1 architecture available on Windows
	/// 95 and later. A newer version 2 of the namespace architecture is available on Windows Vista and later.
	/// </para>
	/// <para>
	/// In most instances, applications interested in only a particular transport protocol should constrain their query by address
	/// family and protocol rather than by namespace. This would allow an application that needs to locate a TCP/IP service, for
	/// example, to have its query processed by all available namespaces such as the local hosts file, DNS, and NIS.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaquerysetw typedef struct _WSAQuerySetW { DWORD dwSize;
	// LPWSTR lpszServiceInstanceName; LPGUID lpServiceClassId; LPWSAVERSION lpVersion; LPWSTR lpszComment; DWORD dwNameSpace; LPGUID
	// lpNSProviderId; LPWSTR lpszContext; DWORD dwNumberOfProtocols; LPAFPROTOCOLS lpafpProtocols; LPWSTR lpszQueryString; DWORD
	// dwNumberOfCsAddrs; LPCSADDR_INFO lpcsaBuffer; DWORD dwOutputFlags; LPBLOB lpBlob; } WSAQUERYSETW, *PWSAQUERYSETW, *LPWSAQUERYSETW;
	[PInvokeData("winsock2.h", MSDNShortId = "6c81fbba-aaf4-49ca-ab79-b6fe5dfb0076")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WSAQUERYSET
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in bytes, of the <c>WSAQUERYSET</c> structure. This member is used as a versioning mechanism since the size of the
		/// <c>WSAQUERYSET</c> structure has changed on later versions of Windows.
		/// </para>
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to an optional NULL-terminated string that contains service name. The semantics for using wildcards within the
		/// string are not defined, but can be supported by certain namespace providers.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszServiceInstanceName;

		/// <summary>
		/// <para>Type: <c>LPGUID</c></para>
		/// <para>The GUID corresponding to the service class. This member is required to be set.</para>
		/// </summary>
		public GuidPtr lpServiceClassId;

		/// <summary>
		/// <para>Type: <c>LPWSAVERSION</c></para>
		/// <para>
		/// A pointer to an optional desired version number of the namespace provider. This member provides version comparison semantics
		/// (that is, the version requested must match exactly, or version must be not less than the value supplied).
		/// </para>
		/// </summary>
		public IntPtr lpVersion;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszComment;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A namespace identifier that determines which namespace providers are queried. Passing a specific namespace identifier will
		/// result in only namespace providers that support the specified namespace being queried. Specifying <c>NS_ALL</c> will result
		/// in all installed and active namespace providers being queried.
		/// </para>
		/// <para>
		/// Options for the <c>dwNameSpace</c> member are listed in the Winsock2.h include file. Several new namespace providers are
		/// included with Windows Vista and later. Other namespace providers can be installed, so the following possible values are only
		/// those commonly available. Many other values are possible.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NS_ALL</term>
		/// <term>All installed and active namespaces.</term>
		/// </item>
		/// <item>
		/// <term>NS_BTH</term>
		/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_DNS</term>
		/// <term>The domain name system (DNS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_EMAIL</term>
		/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NLA</term>
		/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPNAME</term>
		/// <term>
		/// The peer-to-peer name space for a specific peer name. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer name space for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public NS dwNameSpace;

		/// <summary>
		/// <para>Type: <c>LPGUID</c></para>
		/// <para>
		/// A pointer to an optional GUID of a specific namespace provider to query in the case where multiple namespace providers are
		/// registered under a single namespace such as <c>NS_DNS</c>. Passing the GUID for a specific namespace provider will result in
		/// only the specified namespace provider being queried. The WSAEnumNameSpaceProviders and WSAEnumNameSpaceProvidersEx functions
		/// can be called to retrieve the GUID for a namespace provider.
		/// </para>
		/// </summary>
		public GuidPtr lpNSProviderId;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to an optional starting point of the query in a hierarchical namespace.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszContext;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the protocol constraint array. This member can be zero.</para>
		/// </summary>
		public uint dwNumberOfProtocols;

		/// <summary>
		/// <para>Type: <c>LPAFPROTOCOLS</c></para>
		/// <para>A pointer to an optional array of AFPROTOCOLS structures. Only services that utilize these protocols will be returned.</para>
		/// </summary>
		public IntPtr lpafpProtocols;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to an optional NULL-terminated query string. Some namespaces, such as Whois++, support enriched SQL-like queries
		/// that are contained in a simple text string. This parameter is used to specify that string.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpszQueryString;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		public uint dwNumberOfCsAddrs;

		/// <summary>
		/// <para>Type: <c>LPCSADDR_INFO</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		public IntPtr lpcsaBuffer;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This member is ignored for queries.</para>
		/// </summary>
		public uint dwOutputFlags;

		/// <summary>
		/// <para>Type: <c>LPBLOB</c></para>
		/// <para>
		/// An optional pointer to data that is used to query or set provider-specific namespace information. The format of this
		/// information is specific to the namespace provider.
		/// </para>
		/// </summary>
		public IntPtr lpBlob;

		/// <summary>Initializes a new instance of the <see cref="WSAQUERYSET"/> struct.</summary>
		/// <param name="nameSpace">The name space.</param>
		public WSAQUERYSET(NS nameSpace) : this()
		{
			dwSize = (uint)Marshal.SizeOf(this);
			dwNameSpace = nameSpace;
		}

		/// <summary>Initializes a new instance of the <see cref="WSAQUERYSET"/> struct.</summary>
		/// <param name="svcClass">The GUID corresponding to the service class.</param>
		public WSAQUERYSET(GuidPtr svcClass) : this()
		{
			dwSize = (uint)Marshal.SizeOf(this);
			lpServiceClassId = svcClass;
		}
	}

	/// <summary>
	/// The <c>WSAQUERYSET</c> structure provides relevant information about a given service, including service class ID, service name,
	/// applicable namespace identifier and protocol information, as well as a set of transport addresses at which the service listens.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>WSAQUERYSET</c> structure is used as part of the original namespace provider version 1 architecture available on Windows
	/// 95 and later. A newer version 2 of the namespace architecture is available on Windows Vista and later.
	/// </para>
	/// <para>
	/// In most instances, applications interested in only a particular transport protocol should constrain their query by address
	/// family and protocol rather than by namespace. This would allow an application that needs to locate a TCP/IP service, for
	/// example, to have its query processed by all available namespaces such as the local hosts file, DNS, and NIS.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaquerysetw typedef struct _WSAQuerySetW { DWORD dwSize;
	// LPWSTR lpszServiceInstanceName; LPGUID lpServiceClassId; LPWSAVERSION lpVersion; LPWSTR lpszComment; DWORD dwNameSpace; LPGUID
	// lpNSProviderId; LPWSTR lpszContext; DWORD dwNumberOfProtocols; LPAFPROTOCOLS lpafpProtocols; LPWSTR lpszQueryString; DWORD
	// dwNumberOfCsAddrs; LPCSADDR_INFO lpcsaBuffer; DWORD dwOutputFlags; LPBLOB lpBlob; } WSAQUERYSETW, *PWSAQUERYSETW, *LPWSAQUERYSETW;
	[PInvokeData("winsock2.h", MSDNShortId = "6c81fbba-aaf4-49ca-ab79-b6fe5dfb0076")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WSAQUERYSET_MGD : IVanaraMarshaler
	{
		/// <summary>
		/// An optional string that contains service name. The semantics for using wildcards within the string are not defined, but can be
		/// supported by certain namespace providers.
		/// </summary>
		public string? lpszServiceInstanceName;

		/// <summary>The GUID corresponding to the service class. This member is required to be set.</summary>
		public Guid? lpServiceClassId;

		/// <summary>
		/// An optional desired version number of the namespace provider. This member provides version comparison semantics (that is, the
		/// version requested must match exactly, or version must be not less than the value supplied).
		/// </summary>
		public WSAVERSION? lpVersion;

		/// <summary>This member is ignored for queries.</summary>
		public string? lpszComment;

		/// <summary>
		/// <para>
		/// A namespace identifier that determines which namespace providers are queried. Passing a specific namespace identifier will result
		/// in only namespace providers that support the specified namespace being queried. Specifying <c>NS_ALL</c> will result in all
		/// installed and active namespace providers being queried.
		/// </para>
		/// <para>
		/// Options for the <c>dwNameSpace</c> member are listed in the Winsock2.h include file. Several new namespace providers are included
		/// with Windows Vista and later. Other namespace providers can be installed, so the following possible values are only those
		/// commonly available. Many other values are possible.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NS_ALL</term>
		/// <term>All installed and active namespaces.</term>
		/// </item>
		/// <item>
		/// <term>NS_BTH</term>
		/// <term>The Bluetooth namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_DNS</term>
		/// <term>The domain name system (DNS) namespace.</term>
		/// </item>
		/// <item>
		/// <term>NS_EMAIL</term>
		/// <term>The email namespace. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_NLA</term>
		/// <term>The network location awareness (NLA) namespace. This namespace identifier is supported on Windows XP and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPNAME</term>
		/// <term>The peer-to-peer name space for a specific peer name. This namespace identifier is supported on Windows Vista and later.</term>
		/// </item>
		/// <item>
		/// <term>NS_PNRPCLOUD</term>
		/// <term>
		/// The peer-to-peer name space for a collection of peer names. This namespace identifier is supported on Windows Vista and later.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public NS dwNameSpace;

		/// <summary>
		/// An optional GUID of a specific namespace provider to query in the case where multiple namespace providers are registered under a
		/// single namespace such as <c>NS_DNS</c>. Passing the GUID for a specific namespace provider will result in only the specified
		/// namespace provider being queried. The WSAEnumNameSpaceProviders and WSAEnumNameSpaceProvidersEx functions can be called to
		/// retrieve the GUID for a namespace provider.
		/// </summary>
		public Guid? lpNSProviderId;

		/// <summary>An optional starting point of the query in a hierarchical namespace.</summary>
		public string? lpszContext;

		/// <summary>An optional array of AFPROTOCOLS structures. Only services that utilize these protocols will be returned.</summary>
		public AFPROTOCOLS[]? lpafpProtocols;

		/// <summary>
		/// An optional query string. Some namespaces, such as Whois++, support enriched SQL-like queries that are contained in a simple text
		/// string. This parameter is used to specify that string.
		/// </summary>
		public string? lpszQueryString;

		/// <summary>This member is ignored for queries.</summary>
		public CSADDR_INFO[]? lpcsaBuffer;

		/// <summary>This member is ignored for queries.</summary>
		public uint dwOutputFlags;

		/// <summary>
		/// Optional data that is used to query or set provider-specific namespace information. The format of this information is specific to
		/// the namespace provider.
		/// </summary>
		public byte[]? lpBlob;

		SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(WSAQUERYSET));
		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject) => throw new NotImplementedException();
		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			if (pNativeData == IntPtr.Zero) return null;
			WSAQUERYSET qs = (WSAQUERYSET)Marshal.PtrToStructure(pNativeData, typeof(WSAQUERYSET))!;
			BLOB? blob = qs.lpBlob.ToNullableStructure<BLOB>();
			return new WSAQUERYSET_MGD()
			{
				lpszServiceInstanceName = qs.lpszServiceInstanceName,
				lpServiceClassId = qs.lpServiceClassId,
				lpVersion = qs.lpVersion.ToNullableStructure<WSAVERSION>(),
				lpszComment = qs.lpszComment,
				dwNameSpace = qs.dwNameSpace,
				lpNSProviderId = qs.lpNSProviderId,
				lpszContext = qs.lpszContext,
				lpafpProtocols = qs.lpafpProtocols.ToArray<AFPROTOCOLS>((int)qs.dwNumberOfProtocols),
				lpszQueryString = qs.lpszQueryString,
				lpcsaBuffer = qs.lpcsaBuffer.ToArray<CSADDR_INFO>((int)qs.dwNumberOfCsAddrs),
				dwOutputFlags = qs.dwOutputFlags,
				lpBlob = blob.HasValue ? blob.Value.pBlobData.ToByteArray((int)blob.Value.cbSize) : null
			};
		}
	}

	/// <summary>
	/// The <c>WSASERVICECLASSINFO</c> structure contains information about a specified service class. For each service class in Windows
	/// Sockets 2, there is a single <c>WSASERVICECLASSINFO</c> structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winsock2/ns-winsock2-wsaserviceclassinfow typedef struct _WSAServiceClassInfoW
	// { LPGUID lpServiceClassId; LPWSTR lpszServiceClassName; DWORD dwCount; LPWSANSCLASSINFOW lpClassInfos; } WSASERVICECLASSINFOW,
	// *PWSASERVICECLASSINFOW, *LPWSASERVICECLASSINFOW;
	[PInvokeData("winsock2.h", MSDNShortId = "02422c24-34a6-4e34-a795-66b0b687ac44")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WSASERVICECLASSINFO
	{
		/// <summary>Unique Identifier (GUID) for the service class.</summary>
		public GuidPtr lpServiceClassId;

		/// <summary>Well known name associated with the service class.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpszServiceClassName;

		/// <summary>Number of entries in <c>lpClassInfos</c>.</summary>
		public uint dwCount;

		/// <summary>Array of WSANSCLASSINFO structures that contains information about the service class.</summary>
		public IntPtr lpClassInfos;

		/// <summary>Marshaled array of WSANSCLASSINFO structures that contains information about the service class.</summary>
		public readonly WSANSCLASSINFO[]? ClassInfos => lpClassInfos.ToArray<WSANSCLASSINFO>((int)dwCount);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="WSAEVENT"/> that is disposed using <see cref="WSACloseEvent"/>.</summary>
	public class SafeWSAEVENT : SafeHANDLE, ISyncHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeWSAEVENT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeWSAEVENT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeWSAEVENT"/> class.</summary>
		private SafeWSAEVENT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeWSAEVENT"/> to <see cref="WSAEVENT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WSAEVENT(SafeWSAEVENT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => WSACloseEvent(handle);
	}

	/// <summary>
	/// A disposable class to manage initialization of the WSA library. See remarks for use.
	/// </summary>
	/// <example>
	/// <code>
	/// using (var wsa = SafeWSA.Initialize())
	/// {
	///    // Call WSA functions...
	/// }
	/// </code>
	/// Or, if you must have a certain version of the library, use the <c>InitDemandVersion</c> static method.
	/// <code>
	/// using (var wsa = SafeWSA.InitDemandVersion(Macros.MAKEWORD(1, 1)))
	/// {
	///    // Call WSA functions.
	///    // The above call with throw a VersionNotFoundException if that version is not supported.
	/// }
	/// </code>
	/// </example>
	/// <seealso cref="System.IDisposable" />
	public class SafeWSA : IDisposable
	{
		private WSADATA data;

		private SafeWSA() { }

		/// <summary>Initiates use of the Winsock DLL by a process.</summary>
		/// <param name="wVersionRequired">The requested version of the WinSock library.</param>
		/// <returns>An object that holds the WinSock library while in scope. Upon disposal, <c>WSACleanup</c> is called.</returns>
		public static SafeWSA Initialize(ushort wVersionRequired = 0x0202)
		{
			var ret = new SafeWSA();
			WSAStartup(wVersionRequired, out ret.data).ThrowIfFailed();
			return ret;
		}

		/// <summary>
		/// Initiates use of the Winsock DLL by a process and throws an exception if <paramref name="wVersionRequired"/> isn't available.
		/// </summary>
		/// <param name="wVersionRequired">The required version of the WinSock library.</param>
		/// <returns>An object that holds the WinSock library while in scope. Upon disposal, <c>WSACleanup</c> is called.</returns>
		/// <exception cref="VersionNotFoundException"></exception>
		public static SafeWSA DemandVersion(ushort wVersionRequired)
		{
			var ret = Initialize(wVersionRequired);
			if (ret.Data.wVersion != wVersionRequired)
				throw new VersionNotFoundException();
			return ret;
		}

		/// <summary>Gets the WSADATA value returned by <c>WSAStartup</c>.</summary>
		/// <value>The data.</value>
		public WSADATA Data { get => data; private set => data = value; }

		void IDisposable.Dispose() => WSACleanup();
	}
}