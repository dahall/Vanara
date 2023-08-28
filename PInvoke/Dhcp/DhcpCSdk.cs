namespace Vanara.PInvoke;

/// <summary>Items from Dhcpcsvc6.dll and Dhcpcsvc.dll.</summary>
public static partial class Dhcp
{
	/// <summary>De-register handle that is an event</summary>
	public const uint DHCPCAPI_DEREGISTER_HANDLE_EVENT = 0x01;

	/// <summary>Handle returned is to an event</summary>
	public const uint DHCPCAPI_REGISTER_HANDLE_EVENT = 0x01;

	private const string Lib_Dhcp = "dhcpcsvc.dll";

	/// <summary>
	/// DHCP options. See <a href="https://kb.isc.org/docs/isc-dhcp-44-manual-pages-dhcp-options">ISC DHCP 4.4 Manual Pages -
	/// dhcp-options</a> for some details.
	/// </summary>
	[PInvokeData("dhcpcsdk.h")]
	public enum DHCP_OPTION_ID : uint
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		OPTION_PAD = 0,
		OPTION_SUBNET_MASK = 1,
		OPTION_TIME_OFFSET = 2,
		OPTION_ROUTER_ADDRESS = 3,
		OPTION_TIME_SERVERS = 4,
		OPTION_IEN116_NAME_SERVERS = 5,
		OPTION_DOMAIN_NAME_SERVERS = 6,
		OPTION_LOG_SERVERS = 7,
		OPTION_COOKIE_SERVERS = 8,
		OPTION_LPR_SERVERS = 9,
		OPTION_IMPRESS_SERVERS = 10,
		OPTION_RLP_SERVERS = 11,
		OPTION_HOST_NAME = 12,
		OPTION_BOOT_FILE_SIZE = 13,
		OPTION_MERIT_DUMP_FILE = 14,
		OPTION_DOMAIN_NAME = 15,
		OPTION_SWAP_SERVER = 16,
		OPTION_ROOT_DISK = 17,
		OPTION_EXTENSIONS_PATH = 18,
		OPTION_BE_A_ROUTER = 19,
		OPTION_NON_LOCAL_SOURCE_ROUTING = 20,
		OPTION_POLICY_FILTER_FOR_NLSR = 21,
		OPTION_MAX_REASSEMBLY_SIZE = 22,
		OPTION_DEFAULT_TTL = 23,
		OPTION_PMTU_AGING_TIMEOUT = 24,
		OPTION_PMTU_PLATEAU_TABLE = 25,
		OPTION_MTU = 26,
		OPTION_ALL_SUBNETS_MTU = 27,
		OPTION_BROADCAST_ADDRESS = 28,
		OPTION_PERFORM_MASK_DISCOVERY = 29,
		OPTION_BE_A_MASK_SUPPLIER = 30,
		OPTION_PERFORM_ROUTER_DISCOVERY = 31,
		OPTION_ROUTER_SOLICITATION_ADDR = 32,
		OPTION_STATIC_ROUTES = 33,
		OPTION_TRAILERS = 34,
		OPTION_ARP_CACHE_TIMEOUT = 35,
		OPTION_ETHERNET_ENCAPSULATION = 36,
		OPTION_TTL = 37,
		OPTION_KEEP_ALIVE_INTERVAL = 38,
		OPTION_KEEP_ALIVE_DATA_SIZE = 39,
		OPTION_NETWORK_INFO_SERVICE_DOM = 40,
		OPTION_NETWORK_INFO_SERVERS = 41,
		OPTION_NETWORK_TIME_SERVERS = 42,
		OPTION_VENDOR_SPEC_INFO = 43,
		OPTION_NETBIOS_NAME_SERVER = 44,
		OPTION_NETBIOS_DATAGRAM_SERVER = 45,
		OPTION_NETBIOS_NODE_TYPE = 46,
		OPTION_NETBIOS_SCOPE_OPTION = 47,
		OPTION_XWINDOW_FONT_SERVER = 48,
		OPTION_XWINDOW_DISPLAY_MANAGER = 49,
		OPTION_REQUESTED_ADDRESS = 50,
		OPTION_LEASE_TIME = 51,
		OPTION_OK_TO_OVERLAY = 52,
		OPTION_MESSAGE_TYPE = 53,
		OPTION_SERVER_IDENTIFIER = 54,
		OPTION_PARAMETER_REQUEST_LIST = 55,
		OPTION_MESSAGE = 56,
		OPTION_MESSAGE_LENGTH = 57,
		OPTION_RENEWAL_TIME = 58,
		OPTION_REBIND_TIME = 59,
		OPTION_CLIENT_CLASS_INFO = 60,
		OPTION_CLIENT_ID = 61,
		OPTION_TFTP_SERVER_NAME = 66,
		OPTION_BOOTFILE_NAME = 67,
		OPTION_MSFT_IE_PROXY = 252,
		OPTION_END = 255,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>Flags that specify the data being requested.</summary>
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpRequestParams")]
	[Flags]
	public enum DHCPCAPI_REQUEST
	{
		/// <summary>The request is persisted but no options are fetched.</summary>
		DHCPCAPI_REQUEST_PERSISTENT = 0x01,

		/// <summary>Options will be fetched from the server.</summary>
		DHCPCAPI_REQUEST_SYNCHRONOUS = 0x02,

		/// <summary>Request and return, set event on completion.</summary>
		DHCPCAPI_REQUEST_ASYNCHRONOUS = 0x04,

		/// <summary>Cancel request.</summary>
		DHCPCAPI_REQUEST_CANCEL = 0x08,
	}

	/// <summary>Identifies the client type in a NetBIOS client.</summary>
	[Flags]
	public enum NetBIOSNodeType : byte
	{
		/// <summary>B-node: Broadcast - no WINS</summary>
		Bnode = 0x1,
		/// <summary>P-node: Peer - WINS only</summary>
		Pnode = 0x2,
		/// <summary>M-node: Mixed - broadcast, then WINS</summary>
		Mnode = 0x4,
		/// <summary>H-node: Hybrid - WINS, then broadcast</summary>
		Hnode = 0x8
	}

	/// <summary>This option, sent by both client and server, specifies the type of DHCP message contained in the DHCP packet.</summary>
	public enum DhcpMessageType : byte
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		DHCPDISCOVER = 1,
		DHCPOFFER = 2,
		DHCPREQUEST = 3,
		DHCPDECLINE = 4,
		DHCPACK = 5,
		DHCPNAK = 6,
		DHCPRELEASE = 7,
		DHCPINFORM = 8,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// The <c>DhcpCApiCleanup</c> function enables DHCP to properly clean up resources allocated throughout the use of DHCP function
	/// calls. The <c>DhcpCApiCleanup</c> function must only be called if a previous call to DhcpCApiInitialize executed successfully.
	/// </summary>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcpcapicleanup void DhcpCApiCleanup();
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpCApiCleanup")]
	public static extern void DhcpCApiCleanup();

	/// <summary>
	/// The <c>DhcpCApiInitialize</c> function must be the first function call made by users of DHCP; it prepares the system for all
	/// other DHCP function calls. Other DHCP functions should only be called if the <c>DhcpCApiInitialize</c> function executes successfully.
	/// </summary>
	/// <param name="Version">Pointer to the DHCP version implemented by the client.</param>
	/// <returns>Returns ERROR_SUCCESS upon successful completion.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcpcapiinitialize DWORD DhcpCApiInitialize( LPDWORD
	// Version );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpCApiInitialize")]
	public static extern Win32Error DhcpCApiInitialize(out uint Version);

	/// <summary>
	/// The <c>DhcpDeRegisterParamChange</c> function releases resources associated with previously registered event notifications, and
	/// closes the associated event handle.
	/// </summary>
	/// <param name="Flags">Reserved. Must be set to zero.</param>
	/// <param name="Reserved">Reserved. Must be set to <c>NULL</c>.</param>
	/// <param name="Event">
	/// Must be the same value as the <c>HANDLE</c> variable in the DhcpRegisterParamChange function call for which the client is
	/// deregistering event notification.
	/// </param>
	/// <returns>Returns ERROR_SUCCESS upon successful completion. Otherwise, returns Windows error codes.</returns>
	/// <remarks>
	/// The <c>DhcpDeRegisterParamChange</c> function must be made subsequent to an associated DhcpRegisterParamChange function call,
	/// and the Flags parameter and the <c>HANDLE</c> variable passed in the Event parameter to <c>DhcpDeRegisterParamChange</c> must
	/// match corresponding Flags parameter and the <c>HANDLE</c> variable of the previous and associated <c>DhcpRegisterParamChange</c>
	/// function call.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcpderegisterparamchange DWORD
	// DhcpDeRegisterParamChange( DWORD Flags, LPVOID Reserved, LPVOID Event );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpDeRegisterParamChange")]
	public static extern Win32Error DhcpDeRegisterParamChange([Optional] uint Flags, [Optional] IntPtr Reserved, HEVENT Event);

	/// <summary>The <c>DhcpGetOriginalSubnetMask</c> is used to get the subnet mask of any given adapter name.</summary>
	/// <param name="sAdapterName">[in] Contains the name of the local DHCP-enabled adapter for which the subnet mask is being retrieved.</param>
	/// <param name="dwSubnetMask">[out] Pointer to the retrieved subnet mask.</param>
	/// <returns>
	/// <para>This function always returns 0.</para>
	/// <para>Failure is indicated by a return value of 0 for the dwSubnetMask parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <description>ERROR_INVALID_PARAMETER</description>
	/// <description>Returned if the sAdapterName parameter is invalid.</description>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/previous-versions/bb656318(v=vs.85)
	// void APIENTRY DhcpGetOriginalSubnetMask( __in LPCWSTR sAdapterName, __out DWORD *dwSubnetMask );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Dhcpcsdk.h")]
	public static extern void DhcpGetOriginalSubnetMask([MarshalAs(UnmanagedType.LPWStr)] string sAdapterName, out DHCP_IP_ADDRESS dwSubnetMask);
	
	/// <summary>
	/// The <c>DhcpRegisterParamChange</c> function enables clients to register for notification of changes in DHCP configuration parameters.
	/// </summary>
	/// <param name="Flags">
	/// Reserved. Must be set to DHCPCAPI_REGISTER_HANDLE_EVENT. If it is not set to this flag value, the API call will not be successful.
	/// </param>
	/// <param name="Reserved">Reserved. Must be set to <c>NULL</c>.</param>
	/// <param name="AdapterName">GUID of the adapter for which event notification is being requested. Must be under 256 characters.</param>
	/// <param name="ClassId">Reserved. Must be set to <c>NULL</c>.</param>
	/// <param name="Params">
	/// Parameters for which the client is interested in registering for notification, in the form of a DHCPCAPI_PARAMS_ARRAY structure.
	/// </param>
	/// <param name="Handle">
	/// Attributes of Handle are determined by the value of Flags. In version 2 of the DHCP API, Flags must be set to
	/// DHCPCAPI_REGISTER_HANDLE_EVENT, and therefore, Handle must be a pointer to a <c>HANDLE</c> variable that will hold the handle to
	/// a Windows event that gets signaled when parameters specified in Params change. Note that this <c>HANDLE</c> variable is used in
	/// a subsequent call to the <c>DhcpDeRegisterParamChange</c> function to deregister event notifications associated with this
	/// particular call to the <c>DhcpRegisterParamChange</c> function.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion. Otherwise, returns Windows error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if the AdapterName parameter is over 256 characters long.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Version 2 of the DHCP Client API provides only event-based notification. With event-based notification in DHCP, clients enable
	/// notification by having Handle point to a variable that, upon successful return, holds the EVENT handles that are signaled
	/// whenever changes occur to the parameters requested in Params.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcpregisterparamchange DWORD DhcpRegisterParamChange(
	// DWORD Flags, LPVOID Reserved, LPWSTR AdapterName, LPDHCPCAPI_CLASSID ClassId, DHCPCAPI_PARAMS_ARRAY Params, LPVOID Handle );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpRegisterParamChange")]
	public static extern Win32Error DhcpRegisterParamChange(uint Flags, [Optional] IntPtr Reserved, [MarshalAs(UnmanagedType.LPWStr)] string AdapterName,
		[Optional] IntPtr ClassId, DHCPCAPI_PARAMS_ARRAY Params, out HEVENT Handle);

	/// <summary>The <c>DhcpRemoveDNSRegistrations</c> function removes all DHCP-initiated DNS registrations for the client.</summary>
	/// <returns>Returns ERROR_SUCCESS upon successful completion.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcpremovednsregistrations DWORD DhcpRemoveDNSRegistrations();
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpRemoveDNSRegistrations")]
	public static extern Win32Error DhcpRemoveDNSRegistrations();

	/// <summary>
	/// The <c>DhcpRequestParams</c> function enables callers to synchronously, or synchronously and persistently obtain DHCP data from
	/// a DHCP server.
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// Flags that specify the data being requested. This parameter is optional. The following possible values are supported and are not
	/// mutually exclusive:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DHCPCAPI_REQUEST_PERSISTENT</term>
	/// <term>The request is persisted but no options are fetched.</term>
	/// </item>
	/// <item>
	/// <term>DHCPCAPI_REQUEST_SYNCHRONOUS</term>
	/// <term>Options will be fetched from the server.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="AdapterName">GUID of the adapter on which requested data is being made. Must be under 256 characters.</param>
	/// <param name="ClassId">
	/// Class identifier (ID) that should be used if DHCP INFORM messages are being transmitted onto the network. This parameter is optional.
	/// </param>
	/// <param name="SendParams">
	/// Optional data to be requested, in addition to the data requested in the RecdParams array. The SendParams parameter cannot
	/// contain any of the standard options that the DHCP client sends by default.
	/// </param>
	/// <param name="RecdParams">
	/// Array of DHCP data the caller is interested in receiving. This array must be empty prior to the <c>DhcpRequestParams</c>
	/// function call.
	/// </param>
	/// <param name="Buffer">Buffer used for storing the data associated with requests made in RecdParams.</param>
	/// <param name="pSize">
	/// <para>Size of Buffer.</para>
	/// <para>
	/// Required size of the buffer, if it is insufficiently sized to hold the data, otherwise indicates size of the buffer which was
	/// successfully filled.
	/// </para>
	/// </param>
	/// <param name="RequestIdStr">
	/// Application identifier (ID) used to facilitate a persistent request. Must be a printable string with no special characters
	/// (commas, backslashes, colons, or other illegal characters may not be used). The specified application identifier (ID) is used in
	/// a subsequent <c>DhcpUndoRequestParams</c> function call to clear the persistent request, as necessary.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <para>
	/// Upon return, RecdParams is filled with pointers to requested data, with corresponding data placed in Buffer. If pSize indicates
	/// that Buffer has insufficient space to store returned data, the <c>DhcpRequestParams</c> function returns ERROR_MORE_DATA, and
	/// returns the required buffer size in pSize. Note that the required size of Buffer may increase during the time that elapses
	/// between the initial function call's return and a subsequent call; therefore, the required size of Buffer (indicated in pSize)
	/// provides an indication of the approximate size required of Buffer, rather than guaranteeing that subsequent calls will return
	/// successfully if Buffer is set to the size indicated in pSize.
	/// </para>
	/// <para>Other errors return appropriate Windows error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if the AdapterName parameter is over 256 characters long.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUFFER_OVERFLOW</term>
	/// <term>Returned if the AdapterName parameter is over 256 characters long.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// DHCP clients store data obtained from a DHCP server in their local cache. If the DHCP client cache contains all data requested
	/// in the RecdParams array of a <c>DhcpRequestParams</c> function call, the client returns data from its cache. If requested data
	/// is not available in the client cache, the client processes the <c>DhcpRequestParams</c> function call by submitting a
	/// DHCP-INFORM message to the DHCP server.
	/// </para>
	/// <para>
	/// When the client submits a DHCP-INFORM message to the DHCP server, it includes any requests provided in the optional SendParams
	/// parameter, and provides the Class identifier (ID) specified in the ClassId parameter, if provided.
	/// </para>
	/// <para>
	/// Clients can also specify that DHCP data be retrieved from the DHCP server each time the DHCP client boots, which is considered a
	/// persistent request. To enable persistent requests, the caller must specify the RequestIdStr parameter, and also specify the
	/// additional <c>DHCPAPI_REQUEST_PERSISTENT</c> flag in the dwFlags parameter. This persistent request capability is especially
	/// useful when clients need to automatically request application-critical information at each boot. To disable a persist request,
	/// clients must call the function.
	/// </para>
	/// <para>
	/// <c>Note</c> The callers of this API must not make blocking calls to this API, since it can take up to a maximum of 2 minutes to
	/// return a code or status. UI behaviors in particular should not block on the return of this call, since it can introduce a
	/// significant delay in UI response time.
	/// </para>
	/// <para>For more information about DHCP INFORM messages, and other standards-based information about DHCP, consult DHCP Standards.</para>
	/// <para>To see the <c>DhcpRequestParams</c> function in use, see DHCP Examples.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcprequestparams DWORD DhcpRequestParams( DWORD Flags,
	// LPVOID Reserved, LPWSTR AdapterName, LPDHCPCAPI_CLASSID ClassId, DHCPCAPI_PARAMS_ARRAY SendParams, DHCPCAPI_PARAMS_ARRAY
	// RecdParams, LPBYTE Buffer, LPDWORD pSize, LPWSTR RequestIdStr );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpRequestParams")]
	public static extern Win32Error DhcpRequestParams([Optional] DHCPCAPI_REQUEST Flags, [In, Optional] IntPtr Reserved, [MarshalAs(UnmanagedType.LPWStr)] string AdapterName,
		in DHCPCAPI_CLASSID ClassId, DHCPCAPI_PARAMS_ARRAY SendParams, DHCPCAPI_PARAMS_ARRAY RecdParams, [Out] IntPtr Buffer, ref uint pSize, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? RequestIdStr);

	/// <summary>
	/// The <c>DhcpRequestParams</c> function enables callers to synchronously, or synchronously and persistently obtain DHCP data from
	/// a DHCP server.
	/// </summary>
	/// <param name="Flags">
	/// <para>
	/// Flags that specify the data being requested. This parameter is optional. The following possible values are supported and are not
	/// mutually exclusive:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DHCPCAPI_REQUEST_PERSISTENT</term>
	/// <term>The request is persisted but no options are fetched.</term>
	/// </item>
	/// <item>
	/// <term>DHCPCAPI_REQUEST_SYNCHRONOUS</term>
	/// <term>Options will be fetched from the server.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Reserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="AdapterName">GUID of the adapter on which requested data is being made. Must be under 256 characters.</param>
	/// <param name="ClassId">
	/// Class identifier (ID) that should be used if DHCP INFORM messages are being transmitted onto the network. This parameter is optional.
	/// </param>
	/// <param name="SendParams">
	/// Optional data to be requested, in addition to the data requested in the RecdParams array. The SendParams parameter cannot
	/// contain any of the standard options that the DHCP client sends by default.
	/// </param>
	/// <param name="RecdParams">
	/// Array of DHCP data the caller is interested in receiving. This array must be empty prior to the <c>DhcpRequestParams</c>
	/// function call.
	/// </param>
	/// <param name="Buffer">Buffer used for storing the data associated with requests made in RecdParams.</param>
	/// <param name="pSize">
	/// <para>Size of Buffer.</para>
	/// <para>
	/// Required size of the buffer, if it is insufficiently sized to hold the data, otherwise indicates size of the buffer which was
	/// successfully filled.
	/// </para>
	/// </param>
	/// <param name="RequestIdStr">
	/// Application identifier (ID) used to facilitate a persistent request. Must be a printable string with no special characters
	/// (commas, backslashes, colons, or other illegal characters may not be used). The specified application identifier (ID) is used in
	/// a subsequent <c>DhcpUndoRequestParams</c> function call to clear the persistent request, as necessary.
	/// </param>
	/// <returns>
	/// <para>Returns ERROR_SUCCESS upon successful completion.</para>
	/// <para>
	/// Upon return, RecdParams is filled with pointers to requested data, with corresponding data placed in Buffer. If pSize indicates
	/// that Buffer has insufficient space to store returned data, the <c>DhcpRequestParams</c> function returns ERROR_MORE_DATA, and
	/// returns the required buffer size in pSize. Note that the required size of Buffer may increase during the time that elapses
	/// between the initial function call's return and a subsequent call; therefore, the required size of Buffer (indicated in pSize)
	/// provides an indication of the approximate size required of Buffer, rather than guaranteeing that subsequent calls will return
	/// successfully if Buffer is set to the size indicated in pSize.
	/// </para>
	/// <para>Other errors return appropriate Windows error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Returned if the AdapterName parameter is over 256 characters long.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUFFER_OVERFLOW</term>
	/// <term>Returned if the AdapterName parameter is over 256 characters long.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// DHCP clients store data obtained from a DHCP server in their local cache. If the DHCP client cache contains all data requested
	/// in the RecdParams array of a <c>DhcpRequestParams</c> function call, the client returns data from its cache. If requested data
	/// is not available in the client cache, the client processes the <c>DhcpRequestParams</c> function call by submitting a
	/// DHCP-INFORM message to the DHCP server.
	/// </para>
	/// <para>
	/// When the client submits a DHCP-INFORM message to the DHCP server, it includes any requests provided in the optional SendParams
	/// parameter, and provides the Class identifier (ID) specified in the ClassId parameter, if provided.
	/// </para>
	/// <para>
	/// Clients can also specify that DHCP data be retrieved from the DHCP server each time the DHCP client boots, which is considered a
	/// persistent request. To enable persistent requests, the caller must specify the RequestIdStr parameter, and also specify the
	/// additional <c>DHCPAPI_REQUEST_PERSISTENT</c> flag in the dwFlags parameter. This persistent request capability is especially
	/// useful when clients need to automatically request application-critical information at each boot. To disable a persist request,
	/// clients must call the function.
	/// </para>
	/// <para>
	/// <c>Note</c> The callers of this API must not make blocking calls to this API, since it can take up to a maximum of 2 minutes to
	/// return a code or status. UI behaviors in particular should not block on the return of this call, since it can introduce a
	/// significant delay in UI response time.
	/// </para>
	/// <para>For more information about DHCP INFORM messages, and other standards-based information about DHCP, consult DHCP Standards.</para>
	/// <para>To see the <c>DhcpRequestParams</c> function in use, see DHCP Examples.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcprequestparams DWORD DhcpRequestParams( DWORD Flags,
	// LPVOID Reserved, LPWSTR AdapterName, LPDHCPCAPI_CLASSID ClassId, DHCPCAPI_PARAMS_ARRAY SendParams, DHCPCAPI_PARAMS_ARRAY
	// RecdParams, LPBYTE Buffer, LPDWORD pSize, LPWSTR RequestIdStr );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpRequestParams")]
	public static extern Win32Error DhcpRequestParams([Optional] DHCPCAPI_REQUEST Flags, [In, Optional] IntPtr Reserved, [MarshalAs(UnmanagedType.LPWStr)] string AdapterName,
		[In, Optional] IntPtr ClassId, DHCPCAPI_PARAMS_ARRAY SendParams, DHCPCAPI_PARAMS_ARRAY RecdParams, [Out] IntPtr Buffer, ref uint pSize, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? RequestIdStr);

	/// <summary>
	/// The <c>DhcpUndoRequestParams</c> function removes persistent requests previously made with a <c>DhcpRequestParams</c> function call.
	/// </summary>
	/// <param name="Flags">Reserved. Must be zero.</param>
	/// <param name="Reserved">Reserved for future use. Must be set to <c>NULL</c>.</param>
	/// <param name="AdapterName">
	/// <para>GUID of the adapter for which information is no longer required. Must be under 256 characters.</para>
	/// <para><c>Note</c> This parameter is no longer used.</para>
	/// </param>
	/// <param name="RequestIdStr">
	/// Application identifier (ID) originally used to make a persistent request. This string must match the RequestIdStr parameter used
	/// in the <c>DhcpRequestParams</c> function call that obtained the corresponding persistent request. Note that this must match the
	/// previous application identifier (ID) used, and must be a printable string with no special characters (commas, backslashes,
	/// colons, or other illegal characters may not be used).
	/// </param>
	/// <returns>Returns ERROR_SUCCESS upon successful completion. Otherwise, returns a Windows error code.</returns>
	/// <remarks>
	/// Persistent requests are typically made by the setup or installer process associated with the application. When appropriate, the
	/// setup or installer process would likely make the <c>DhcpUndoRequestParams</c> function call to cancel its associated persistent request.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/nf-dhcpcsdk-dhcpundorequestparams DWORD DhcpUndoRequestParams( DWORD
	// Flags, LPVOID Reserved, LPWSTR AdapterName, LPWSTR RequestIdStr );
	[DllImport(Lib_Dhcp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NF:dhcpcsdk.DhcpUndoRequestParams")]
	public static extern Win32Error DhcpUndoRequestParams([Optional] uint Flags, [In, Optional] IntPtr Reserved, [MarshalAs(UnmanagedType.LPWStr)] string? AdapterName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? RequestIdStr);

	/// <summary>Represents an 8-byte IP v4 address.</summary>
	[PInvokeData("dhcpsapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCP_IP_ADDRESS
	{
		/// <summary>The underlying value.</summary>
		public uint value;

		/// <summary>Initializes a new instance of the <see cref="DHCP_IP_ADDRESS"/> struct from a UInt32/DWORD.</summary>
		/// <param name="val">The value.</param>
		public DHCP_IP_ADDRESS(uint val = 0) => value = val;

		/// <summary>Initializes a new instance of the <see cref="DHCP_IP_ADDRESS"/> struct from an <see cref="System.Net.IPAddress"/>.</summary>
		/// <param name="ipaddr">The <see cref="System.Net.IPAddress"/> value.</param>
		/// <exception cref="InvalidCastException"></exception>
		public DHCP_IP_ADDRESS(System.Net.IPAddress ipaddr)
		{
			if (ipaddr is null) value = 0;
			if (ipaddr?.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
				throw new InvalidCastException();
			value = (uint)ipaddr.Address;
		}

		/// <summary>Performs an explicit conversion from <see cref="DHCP_IP_ADDRESS"/> to <see cref="System.Net.IPAddress"/>.</summary>
		/// <param name="addr">The DWORD based address.</param>
		/// <returns>The resulting <see cref="System.Net.IPAddress"/> instance from the conversion.</returns>
		public static explicit operator System.Net.IPAddress(DHCP_IP_ADDRESS addr) =>
			new(BitConverter.GetBytes(addr.value));

		/// <summary>Performs an implicit conversion from <see cref="System.Net.IPAddress"/> to <see cref="DHCP_IP_ADDRESS"/>.</summary>
		/// <param name="addr">The <see cref="System.Net.IPAddress"/> value.</param>
		/// <returns>The resulting <see cref="DHCP_IP_ADDRESS"/> instance from the conversion.</returns>
		public static implicit operator DHCP_IP_ADDRESS(System.Net.IPAddress addr) => new(addr);

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="DHCP_IP_ADDRESS"/>.</summary>
		/// <param name="addr">The address as four bytes.</param>
		/// <returns>The resulting <see cref="DHCP_IP_ADDRESS"/> instance from the conversion.</returns>
		public static implicit operator DHCP_IP_ADDRESS(uint addr) => new(addr);

		/// <summary>Converts this address to standard notation.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => ((System.Net.IPAddress)this).ToString();

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => value.GetHashCode();
	}

	/// <summary>The <c>DHCPAPI_PARAMS</c> structure is used to request DHCP parameters.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/ns-dhcpcsdk-dhcpapi_params typedef struct _DHCPAPI_PARAMS { ULONG
	// Flags; ULONG OptionId; BOOL IsVendor; #if ... LPBYTE Data; #else LPBYTE Data; #endif DWORD nBytesData; } DHCPAPI_PARAMS,
	// *PDHCPAPI_PARAMS, *LPDHCPAPI_PARAMS, DHCPCAPI_PARAMS, *PDHCPCAPI_PARAMS, *LPDHCPCAPI_PARAMS;
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NS:dhcpcsdk._DHCPAPI_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPAPI_PARAMS
	{
		/// <summary>Reserved. Must be set to zero.</summary>
		public uint Flags;

		/// <summary>Identifier for the DHCP parameter being requested.</summary>
		public DHCP_OPTION_ID OptionId;

		/// <summary>Specifies whether the DHCP parameter is vendor-specific. Set to <c>TRUE</c> if the parameter is vendor-specific.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool IsVendor;

		/// <summary>Pointer to the parameter data.</summary>
		public IntPtr Data;

		/// <summary>Size of the data pointed to by <c>Data</c>, in bytes.</summary>
		public uint nBytesData;
	}

	/// <summary>The <c>DHCPCAPI_CLASSID</c> structure defines a client Class ID.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/ns-dhcpcsdk-dhcpcapi_classid typedef struct _DHCPCAPI_CLASSID { ULONG
	// Flags; #if ... LPBYTE Data; #else LPBYTE Data; #endif ULONG nBytesData; } DHCPCAPI_CLASSID, *PDHCPCAPI_CLASSID, *LPDHCPCAPI_CLASSID;
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NS:dhcpcsdk._DHCPCAPI_CLASSID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPCAPI_CLASSID
	{
		/// <summary>Reserved. Must be set to zero.</summary>
		public uint Flags;

		/// <summary>Class ID binary data.</summary>
		public IntPtr Data;

		/// <summary>Size of <c>Data</c>, in bytes.</summary>
		public uint nBytesData;
	}

	/// <summary>The <c>DHCPCAPI_PARAMS_ARRAY</c> structure stores an array of DHCPAPI_PARAMS structures used to query DHCP parameters.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dhcpcsdk/ns-dhcpcsdk-dhcpcapi_params_array typedef struct
	// _DHCPCAPI_PARAMS_ARARAY { ULONG nParams; #if ... LPDHCPCAPI_PARAMS Params; #else LPDHCPCAPI_PARAMS Params; #endif }
	// DHCPCAPI_PARAMS_ARRAY, *PDHCPCAPI_PARAMS_ARRAY, *LPDHCPCAPI_PARAMS_ARRAY;
	[PInvokeData("dhcpcsdk.h", MSDNShortId = "NS:dhcpcsdk._DHCPCAPI_PARAMS_ARARAY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DHCPCAPI_PARAMS_ARRAY
	{
		/// <summary>Number of elements in the <c>Params</c> array.</summary>
		public uint nParams;

		/// <summary>Array of DHCPAPI_PARAMS structures.</summary>
		public IntPtr Params;

		/// <summary>Makes an instance for <see cref="DHCPCAPI_PARAMS_ARRAY"/> from an array of ids.</summary>
		/// <param name="array">The resulting native array.</param>
		/// <param name="ids">The list of ids.</param>
		/// <returns>The resulting instance.</returns>
		public static DHCPCAPI_PARAMS_ARRAY Make(out SafeNativeArray<DHCPAPI_PARAMS>? array, params DHCP_OPTION_ID[] ids)
		{
			array = ids.Length == 0 ? null : new(Array.ConvertAll(ids, i => new DHCPAPI_PARAMS { OptionId = i }));
			return new() { nParams = (uint)ids.Length, Params = array?.DangerousGetHandle() ?? default };
		}
	}
}