global using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke;

/// <summary>Items from the Network Diagnostic Framework (NdfApi.dll).</summary>
public static partial class NdfApi
{
	private const string Lib_Ndfapi = "ndfapi.dll";

	/// <summary>Available flags for NdfDiagnoseIncident</summary>
	[Flags]
	public enum NDF_DIAG : uint
	{
		/// <summary>
		/// Turns on network tracing during diagnosis. Diagnostic results will be included in the Event Trace Log (ETL) file returned by NdfGetTraceFile.
		/// </summary>
		NDF_ADD_CAPTURE_TRACE = 0x0001,

		/// <summary>
		/// Applies filtering to the returned root causes so that they are consistent with the in-box scripted diagnostics behavior. Without
		/// this flag, root causes will not be filtered. This flag must be set by the caller, so existing callers will not see a change in
		/// behavior unless they explicitly specify this flag.
		/// </summary>
		NDF_APPLY_INCLUSION_LIST_FILTER = 0x0002,
	}

	/// <summary>Flags for <c>NdfCreateInboundIncident</c>.</summary>
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateInboundIncident")]
	[Flags]
	public enum NDF_INBOUND_FLAG : uint
	{
		/// <summary>
		/// Indicates that a configuration should be considered unhealthy if both gateways on the local network are within the private access
		/// range, rather than only considering the configuration to be healthy if both gateways are Internet Gateway Devices (IGDs).
		/// </summary>
		NDF_INBOUND_FLAG_EDGETRAVERSAL = 0x00001,

		/// <summary>
		/// Ends the session immediately if no inbound traffic problems are diagnosed, instead of turning on detailed tracing and allowing
		/// the user to reproduce their problem for a second diagnosis.
		/// </summary>
		NDF_INBOUND_FLAG_HEALTHCHECK = 0x00002,
	}

	/// <summary>
	/// The <c>NdfCancelIncident</c> function is used to cancel unneeded functions which have been previously called on an existing incident.
	/// </summary>
	/// <param name="Handle">
	/// <para>Type: <c>NDFHANDLE</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident. This handle should match the handle of an existing incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// </list>
	/// <para>Any result other than S_OK should be interpreted as an error.</para>
	/// </returns>
	/// <remarks>
	/// <para>Before using this API, an application must call an incident creation function such as NdfCreateWebIncident.</para>
	/// <para>
	/// <c>NdfCancelIncident</c> is primarily used to cancel calls to functions such as NdfDiagnoseIncident or NdfRepairIncident which have
	/// been previously called, but are no longer needed. When <c>NdfCancelIncident</c> is called, NDF will stop the diagnosis/repair as soon
	/// as possible rather than calling the other functions (unless results have already been returned from those functions, in which case
	/// <c>NdfCancelIncident</c> will have no effect).
	/// </para>
	/// <para>
	/// NdfCloseIncident should be used to close an incident once it has been resolved, as <c>NdfCancelIncident</c> does not actually close
	/// the incident itself.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcancelincident HRESULT NdfCancelIncident( [in] NDFHANDLE Handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCancelIncident")]
	public static extern HRESULT NdfCancelIncident([In] NDFHANDLE Handle);

	/// <summary>The <c>NdfCloseIncident</c> function is used to close an Network Diagnostics Framework (NDF) incident following its resolution.</summary>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE</c></para>
	/// <para>Handle to the NDF incident that is being closed.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcloseincident HRESULT NdfCloseIncident( [in] NDFHANDLE handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCloseIncident")]
	public static extern HRESULT NdfCloseIncident([In] NDFHANDLE handle);

	/// <summary>The <c>NdfCreateConnectivityIncident</c> function diagnoses generic Internet connectivity problems.</summary>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_ABORT</c></term>
	/// <term>The underlying diagnosis or repair operation has been canceled.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>The handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreateconnectivityincident HRESULT
	// NdfCreateConnectivityIncident( [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateConnectivityIncident")]
	public static extern HRESULT NdfCreateConnectivityIncident(out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateDNSIncident</c> function diagnoses name resolution issues in resolving a specific host name.</summary>
	/// <param name="hostname">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The host name with which there is a name resolution issue.</para>
	/// </param>
	/// <param name="queryType">
	/// <para>Type: <c>WORD</c></para>
	/// <para>
	/// The numeric representation of the type of record that was queried when the issue occurred. For more information and a complete
	/// listing of record set types and their numeric representations, see the windns.h header file.
	/// </para>
	/// <para>This parameter should be set to <c>DNS_TYPE_ZERO</c> for generic DNS resolution diagnosis.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_ABORT</c></term>
	/// <term>The underlying diagnosis or repair operation has been canceled.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatednsincident HRESULT NdfCreateDNSIncident( [in] LPCWSTR
	// hostname, WORD queryType, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateDNSIncident")]
	public static extern HRESULT NdfCreateDNSIncident([MarshalAs(UnmanagedType.LPWStr)] string hostname, ushort queryType, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateGroupingIncident</c> function creates a session to diagnose peer-to-peer grouping functionality issues.</summary>
	/// <param name="CloudName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The name of the Peer Name Resolution Protocol (PNRP) cloud where the group is created. If <c>NULL</c>, the session will not attempt
	/// to diagnose issues related to PNRP.
	/// </para>
	/// </param>
	/// <param name="GroupName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The name of the group to be diagnosed. If <c>NULL</c>, the session will not attempt to diagnose issues related to group availability.</para>
	/// </param>
	/// <param name="Identity">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The identity that a peer uses to access the group. If <c>NULL</c>, the session will not attempt to diagnose issues related to the
	/// group's ability to register in PNRP.
	/// </para>
	/// </param>
	/// <param name="Invitation">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// An XML invitation granted by another peer. An invitation is created when the inviting peer calls PeerGroupCreateInvitation or
	/// PeerGroupIssueCredentials. If this value is present, the invitation will be checked to ensure its format and expiration are valid.
	/// </para>
	/// </param>
	/// <param name="Addresses">
	/// <para>Type: <c>SOCKET_ADDRESS_LIST*</c></para>
	/// <para>
	/// Optional list of addresses of the peers to which the application is trying to connect. If this parameter is used, the helper class
	/// will diagnose connectivity to these addresses.
	/// </para>
	/// </param>
	/// <param name="appId">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Application ID for the calling application.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters has not been provided correctly.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The level of diagnosis performed depends on the parameters supplied.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If no parameters are specified, NDF will validate the grouping service status, the status of peer-to-peer services (PNRP and Identity
	/// Manager), and Windows clock synchronization.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If <c>CloudName</c> is specified, NDF will validate grouping functionality in that cloud.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>GroupName</c> is specified, NDF will validate that the name can be resolved in PNRP (or invoke the PNRP helper class if the
	/// name cannot be resolved) and validate the firewall settings for grouping.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>Identity</c> is specified, NDF will validate PNRP's ability to register the <c>GroupName</c> with this Identity. If this fails,
	/// the PNRP helper class will be invoked.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>Invitation</c> is specified, the <c>GroupName</c> will be derived from the Invitation (if a <c>GroupName</c> was not also
	/// specified) and NDF will validate the invitation's format and status.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If <c>Addresses</c> is specified, NDF will validate whether Windows can connect to up to three of these addresses.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreategroupingincident HRESULT NdfCreateGroupingIncident( [in,
	// optional] LPCWSTR CloudName, [in, optional] LPCWSTR GroupName, [in, optional] LPCWSTR Identity, [in, optional] LPCWSTR Invitation,
	// [in, optional] SOCKET_ADDRESS_LIST *Addresses, [in, optional] LPCWSTR appId, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateGroupingIncident")]
	public static extern HRESULT NdfCreateGroupingIncident([Optional, MarshalAs(UnmanagedType.LPWStr)] string? CloudName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? GroupName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? Identity,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? Invitation, [In, Optional] IntPtr Addresses,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? appId, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateGroupingIncident</c> function creates a session to diagnose peer-to-peer grouping functionality issues.</summary>
	/// <param name="CloudName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The name of the Peer Name Resolution Protocol (PNRP) cloud where the group is created. If <c>NULL</c>, the session will not attempt
	/// to diagnose issues related to PNRP.
	/// </para>
	/// </param>
	/// <param name="GroupName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The name of the group to be diagnosed. If <c>NULL</c>, the session will not attempt to diagnose issues related to group availability.</para>
	/// </param>
	/// <param name="Identity">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// The identity that a peer uses to access the group. If <c>NULL</c>, the session will not attempt to diagnose issues related to the
	/// group's ability to register in PNRP.
	/// </para>
	/// </param>
	/// <param name="Invitation">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>
	/// An XML invitation granted by another peer. An invitation is created when the inviting peer calls PeerGroupCreateInvitation or
	/// PeerGroupIssueCredentials. If this value is present, the invitation will be checked to ensure its format and expiration are valid.
	/// </para>
	/// </param>
	/// <param name="Addresses">
	/// <para>Type: <c>SOCKET_ADDRESS_LIST*</c></para>
	/// <para>
	/// Optional list of addresses of the peers to which the application is trying to connect. If this parameter is used, the helper class
	/// will diagnose connectivity to these addresses.
	/// </para>
	/// </param>
	/// <param name="appId">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Application ID for the calling application.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters has not been provided correctly.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The level of diagnosis performed depends on the parameters supplied.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If no parameters are specified, NDF will validate the grouping service status, the status of peer-to-peer services (PNRP and Identity
	/// Manager), and Windows clock synchronization.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If <c>CloudName</c> is specified, NDF will validate grouping functionality in that cloud.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>GroupName</c> is specified, NDF will validate that the name can be resolved in PNRP (or invoke the PNRP helper class if the
	/// name cannot be resolved) and validate the firewall settings for grouping.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>Identity</c> is specified, NDF will validate PNRP's ability to register the <c>GroupName</c> with this Identity. If this fails,
	/// the PNRP helper class will be invoked.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If <c>Invitation</c> is specified, the <c>GroupName</c> will be derived from the Invitation (if a <c>GroupName</c> was not also
	/// specified) and NDF will validate the invitation's format and status.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If <c>Addresses</c> is specified, NDF will validate whether Windows can connect to up to three of these addresses.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreategroupingincident HRESULT NdfCreateGroupingIncident( [in,
	// optional] LPCWSTR CloudName, [in, optional] LPCWSTR GroupName, [in, optional] LPCWSTR Identity, [in, optional] LPCWSTR Invitation,
	// [in, optional] SOCKET_ADDRESS_LIST *Addresses, [in, optional] LPCWSTR appId, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateGroupingIncident")]
	public static extern HRESULT NdfCreateGroupingIncident([Optional, MarshalAs(UnmanagedType.LPWStr)] string? CloudName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? GroupName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? Identity,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? Invitation, in SOCKET_ADDRESS_LIST Addresses,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? appId, out SafeNDFHANDLE handle);

	/// <summary>
	/// The <c>NdfCreateInboundIncident</c> function creates a session to diagnose inbound connectivity for a specific application or service.
	/// </summary>
	/// <param name="applicationID">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The fully qualified path to the application receiving the inbound traffic.</para>
	/// </param>
	/// <param name="serviceID">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The Windows service receiving the inbound traffic.</para>
	/// <para>dll,-28502 (File/Print Sharing)</para>
	/// <para>dll,-28752 (Remote Desktop)</para>
	/// <para>dll,-32752 (Network Discovery)</para>
	/// </param>
	/// <param name="userID">
	/// <para>Type: <c>SID*</c></para>
	/// <para>The SID for the application receiving the traffic. If <c>NULL</c>, the caller's SID is automatically used.</para>
	/// </param>
	/// <param name="localTarget">
	/// <para>Type: <c>const SOCKADDR_STORAGE</c></para>
	/// <para>
	/// A SOCKADDR_STORAGE structure which limits the diagnosis to traffic to a specific IP address. If <c>NULL</c>, all traffic will be
	/// included in the diagnosis.
	/// </para>
	/// </param>
	/// <param name="protocol">
	/// <para>Type: <c>IPPROTO</c></para>
	/// <para>The protocol which should be diagnosed. For example, IPPROTO_TCP would be used to indicate the TCP/IP protocol.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Possible values:</para>
	/// <para><c>NDF_INBOUND_FLAG_EDGETRAVERSAL</c></para>
	/// <para>
	/// Indicates that a configuration should be considered unhealthy if both gateways on the local network are within the private access
	/// range, rather than only considering the configuration to be healthy if both gateways are Internet Gateway Devices (IGDs).
	/// </para>
	/// <para><c>NDF_INBOUND_FLAG_HEALTHCHECK</c></para>
	/// <para>
	/// Ends the session immediately if no inbound traffic problems are diagnosed, instead of turning on detailed tracing and allowing the
	/// user to reproduce their problem for a second diagnosis.
	/// </para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Pointer to a handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_INVALIDARG</c></term>
	/// <term>One or more parameters has not been provided correctly.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Either <c>applicationID</c> or <c>serviceID</c> must be specified, but not both.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreateinboundincident HRESULT NdfCreateInboundIncident( [in,
	// optional] LPCWSTR applicationID, [in, optional] LPCWSTR serviceID, [in, optional] SID *userID, [in, optional] const SOCKADDR_STORAGE
	// *localTarget, IPPROTO protocol, DWORD dwFlags, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateInboundIncident")]
	public static extern HRESULT NdfCreateInboundIncident([Optional, MarshalAs(UnmanagedType.LPWStr)] string? applicationID,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? serviceID, [In, Optional] PSID userID, in SOCKADDR_STORAGE localTarget,
		IPPROTO protocol, NDF_INBOUND_FLAG dwFlags, out SafeNDFHANDLE handle);

	/// <summary>
	/// The <c>NdfCreateInboundIncident</c> function creates a session to diagnose inbound connectivity for a specific application or service.
	/// </summary>
	/// <param name="applicationID">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The fully qualified path to the application receiving the inbound traffic.</para>
	/// </param>
	/// <param name="serviceID">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The Windows service receiving the inbound traffic.</para>
	/// <para>dll,-28502 (File/Print Sharing)</para>
	/// <para>dll,-28752 (Remote Desktop)</para>
	/// <para>dll,-32752 (Network Discovery)</para>
	/// </param>
	/// <param name="userID">
	/// <para>Type: <c>SID*</c></para>
	/// <para>The SID for the application receiving the traffic. If <c>NULL</c>, the caller's SID is automatically used.</para>
	/// </param>
	/// <param name="localTarget">
	/// <para>Type: <c>const SOCKADDR_STORAGE</c></para>
	/// <para>
	/// A SOCKADDR_STORAGE structure which limits the diagnosis to traffic to a specific IP address. If <c>NULL</c>, all traffic will be
	/// included in the diagnosis.
	/// </para>
	/// </param>
	/// <param name="protocol">
	/// <para>Type: <c>IPPROTO</c></para>
	/// <para>The protocol which should be diagnosed. For example, IPPROTO_TCP would be used to indicate the TCP/IP protocol.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Possible values:</para>
	/// <para><c>NDF_INBOUND_FLAG_EDGETRAVERSAL</c></para>
	/// <para>
	/// Indicates that a configuration should be considered unhealthy if both gateways on the local network are within the private access
	/// range, rather than only considering the configuration to be healthy if both gateways are Internet Gateway Devices (IGDs).
	/// </para>
	/// <para><c>NDF_INBOUND_FLAG_HEALTHCHECK</c></para>
	/// <para>
	/// Ends the session immediately if no inbound traffic problems are diagnosed, instead of turning on detailed tracing and allowing the
	/// user to reproduce their problem for a second diagnosis.
	/// </para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Pointer to a handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_INVALIDARG</c></term>
	/// <term>One or more parameters has not been provided correctly.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Either <c>applicationID</c> or <c>serviceID</c> must be specified, but not both.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreateinboundincident HRESULT NdfCreateInboundIncident( [in,
	// optional] LPCWSTR applicationID, [in, optional] LPCWSTR serviceID, [in, optional] SID *userID, [in, optional] const SOCKADDR_STORAGE
	// *localTarget, IPPROTO protocol, DWORD dwFlags, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateInboundIncident")]
	public static extern HRESULT NdfCreateInboundIncident([Optional, MarshalAs(UnmanagedType.LPWStr)] string? applicationID,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? serviceID, [In, Optional] PSID userID, [In, Optional] IntPtr localTarget,
		IPPROTO protocol, NDF_INBOUND_FLAG dwFlags, out SafeNDFHANDLE handle);

	/// <summary>
	/// The <c>NdfCreateIncident</c> function is used internally by application developers to test the NDF functionality incorporated into
	/// their application.
	/// </summary>
	/// <param name="helperClassName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The name of the helper class to be used in the diagnoses of the incident.</para>
	/// </param>
	/// <param name="celt">
	/// <para>Type: <c>ULONG</c></para>
	/// <para>A count of elements in the attributes array.</para>
	/// </param>
	/// <param name="attributes">
	/// <para>Type: <c>HELPER_ATTRIBUTE*</c></para>
	/// <para>The applicable HELPER_ATTRIBUTE structure.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>A handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_NOHELPERCLASS</c></term>
	/// <term><c>helperClassName</c> is <c>NULL</c>.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreateincident HRESULT NdfCreateIncident( [in] LPCWSTR
	// helperClassName, ULONG celt, [in] HELPER_ATTRIBUTE *attributes, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateIncident")]
	public static extern HRESULT NdfCreateIncident([MarshalAs(UnmanagedType.LPWStr)] string helperClassName, uint celt,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HELPER_ATTRIBUTE[] attributes, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateNetConnectionIncident</c> function diagnoses connectivity issues using the NetConnection helper class.</summary>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <param name="id">
	/// <para>Type: <c>GUID</c></para>
	/// <para>Identifier of the network interface that the caller would like to create the incident for.</para>
	/// <para>
	/// The NULL GUID {00000000-0000-0000-0000-000000000000} may be used if the caller does not want to specify an interface. The system will
	/// attempt to determine the most appropriate interface based on the current state of the system.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_ABORT</c></term>
	/// <term>The underlying diagnosis or repair operation has been canceled.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>The handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatenetconnectionincident HRESULT
	// NdfCreateNetConnectionIncident( [out] NDFHANDLE *handle, GUID id );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateNetConnectionIncident")]
	public static extern HRESULT NdfCreateNetConnectionIncident(out SafeNDFHANDLE handle, [In, Optional] Guid id);

	/// <summary>
	/// The <c>NdfCreatePnrpIncident</c> function creates a session to diagnose issues with the Peer Name Resolution Protocol (PNRP) service.
	/// </summary>
	/// <param name="cloudname">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The name of the cloud to be diagnosed.</para>
	/// </param>
	/// <param name="peername">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Optional name of a peer node which PNRP can attempt to resolve. The results will be used to help diagnose any problems.</para>
	/// </param>
	/// <param name="diagnosePublish">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Specifies whether the helper class should verify that the node can publish IDs. If <c>FALSE</c>, this diagnostic step will be skipped.
	/// </para>
	/// </param>
	/// <param name="appId">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Application ID for the calling application.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters has not been provided correctly.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The level of diagnosis performed depends on the parameters supplied. The availability of the PNRP service and the availability of the
	/// IPv6 networking class will be diagnosed, and additional diagnosis will be performed if certain parameters are supplied.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If <c>peername</c> is specified, NDF will validate the availability of that peer in the PNRP network.</term>
	/// </item>
	/// <item>
	/// <term>If <c>diagnosePublish</c> is specified, NDF will validate the ability to publish a name in PNRP.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatepnrpincident HRESULT NdfCreatePnrpIncident( [in] LPCWSTR
	// cloudname, [in, optional] LPCWSTR peername, [in] BOOL diagnosePublish, [in, optional] LPCWSTR appId, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreatePnrpIncident")]
	public static extern HRESULT NdfCreatePnrpIncident([MarshalAs(UnmanagedType.LPWStr)] string cloudname,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? peername, [MarshalAs(UnmanagedType.Bool)] bool diagnosePublish,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? appId, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateSharingIncident</c> function diagnoses network problems in accessing a specific network share.</summary>
	/// <param name="UNCPath">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The full UNC string (for example, "\server\folder\file.ext") for the shared asset with which there is a connectivity issue.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_ABORT</c></term>
	/// <term>The underlying diagnosis or repair operation has been canceled.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatesharingincident HRESULT NdfCreateSharingIncident( [in]
	// LPCWSTR UNCPath, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateSharingIncident")]
	public static extern HRESULT NdfCreateSharingIncident([MarshalAs(UnmanagedType.LPWStr)] string UNCPath, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateWebIncident</c> function diagnoses web connectivity problems concerning a specific URL.</summary>
	/// <param name="url">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The URL with which there is a connectivity issue.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_ABORT</c></term>
	/// <term>The underlying diagnosis or repair operation has been canceled.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatewebincident HRESULT NdfCreateWebIncident( [in] LPCWSTR
	// url, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateWebIncident")]
	public static extern HRESULT NdfCreateWebIncident([MarshalAs(UnmanagedType.LPWStr)] string url, out SafeNDFHANDLE handle);

	/// <summary>
	/// The <c>NdfCreateWebIncidentEx</c> function diagnoses web connectivity problems concerning a specific URL. This function allows for
	/// more control over the underlying diagnosis than the NdfCreateWebIncident function.
	/// </summary>
	/// <param name="url">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The URL with which there is a connectivity issue.</para>
	/// </param>
	/// <param name="useWinHTTP">
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if diagnosis will be performed using the WinHTTP APIs; <c>FALSE</c> if the WinInet APIs will be used.</para>
	/// </param>
	/// <param name="moduleName">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>
	/// The module name to use when checking against application-specific filtering rules (for example, "C:\Program Files\Internet
	/// Explorer\iexplorer.exe"). If <c>NULL</c>, the value is autodetected during the diagnosis.
	/// </para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_ABORT</c></term>
	/// <term>The underlying diagnosis or repair operation has been canceled.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatewebincidentex HRESULT NdfCreateWebIncidentEx( [in]
	// LPCWSTR url, [in] BOOL useWinHTTP, [in] LPWSTR moduleName, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateWebIncidentEx")]
	public static extern HRESULT NdfCreateWebIncidentEx([MarshalAs(UnmanagedType.LPWStr)] string url, [MarshalAs(UnmanagedType.Bool)] bool useWinHTTP,
		[MarshalAs(UnmanagedType.LPWStr)] string? moduleName, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfCreateWinSockIncident</c> function provides access to the Winsock Helper Class provided by Microsoft.</summary>
	/// <param name="sock">
	/// <para>Type: <c>SOCKET</c></para>
	/// <para>A descriptor identifying a connected socket.</para>
	/// </param>
	/// <param name="host">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>A pointer to the local host.</para>
	/// </param>
	/// <param name="port">
	/// <para>Type: <c>USHORT</c></para>
	/// <para>The port providing Winsock access.</para>
	/// </param>
	/// <param name="appId">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Unique identifier associated with the application.</para>
	/// </param>
	/// <param name="userId">
	/// <para>Type: <c>SID*</c></para>
	/// <para>Unique identifier associated with the user.</para>
	/// </param>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE*</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_OUTOFMEMORY</c></term>
	/// <term>There is not enough memory available to complete this operation.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_BAD_PARAM</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term><c>E_INVALIDARG</c></term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfcreatewinsockincident HRESULT NdfCreateWinSockIncident( SOCKET
	// sock, [in, optional] LPCWSTR host, USHORT port, [in, optional] LPCWSTR appId, [in, optional] SID *userId, [out] NDFHANDLE *handle );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfCreateWinSockIncident")]
	public static extern HRESULT NdfCreateWinSockIncident(SOCKET sock, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? host,
		ushort port, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? appId, [In, Optional] PSID userId, out SafeNDFHANDLE handle);

	/// <summary>The <c>NdfDiagnoseIncident</c> function diagnoses the root cause of an incident without displaying a user interface.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>NDFHANDLE</c></para>
	/// <para>A handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <param name="RootCauseCount">
	/// <para>Type: <c>ULONG*</c></para>
	/// <para>
	/// The number of root causes that could potentially have caused this incident. If diagnosis does not succeed, the contents of this
	/// parameter should be ignored.
	/// </para>
	/// </param>
	/// <param name="RootCauses">
	/// <para>Type: <c>RootCauseInfo**</c></para>
	/// <para>
	/// A collection of RootCauseInfo structures that contain a detailed description of the root cause. If diagnosis succeeds, this parameter
	/// contains both the leaf root causes identified in the diagnosis session and any non-leaf root causes that have an available repair. If
	/// diagnosis does not succeed, the contents of this parameter should be ignored.
	/// </para>
	/// <para>
	/// Memory allocated to these structures should later be freed. For an example of how to do this, see the Microsoft Windows Network
	/// Diagnostics Samples.
	/// </para>
	/// </param>
	/// <param name="dwWait">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The length of time, in milliseconds, to wait before terminating the diagnostic routine. INFINITE may be passed to this parameter if
	/// no time-out is desired.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Possible values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>NDF_ADD_CAPTURE_TRACE</c> 0x0001</term>
	/// <term>
	/// Turns on network tracing during diagnosis. Diagnostic results will be included in the Event Trace Log (ETL) file returned by NdfGetTraceFile.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NDF_APPLY_INCLUSION_LIST_FILTER</c> 0x0002</term>
	/// <term>
	/// Applies filtering to the returned root causes so that they are consistent with the in-box scripted diagnostics behavior. Without this
	/// flag, root causes will not be filtered. This flag must be set by the caller, so existing callers will not see a change in behavior
	/// unless they explicitly specify this flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_HANDLE</c></term>
	/// <term>The NDF incident handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>WAIT_TIMEOUT</c></term>
	/// <term>The diagnostic routine has terminated because it has taken longer than the time-out specified in dwWait.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is intended for use with scenarios where no user interface is shown, or where the standard Windows experience is not
	/// being used (as with Media Center and embedded applications). NdfExecuteDiagnosis will launch the diagnostics user interface, and
	/// should be used in scenarios using the standard Windows experience. You can call either <c>NdfExecuteDiagnosis</c> or
	/// <c>NdfDiagnoseIncident</c>, but not both.
	/// </para>
	/// <para>
	/// Before using this API, an application must call an incident creation function such as NdfCreateWebIncident to begin the NDF
	/// diagnostics process. The application then calls <c>NdfDiagnoseIncident</c> to diagnose the issue. If the diagnostics process
	/// identifies some possible repairs, the application can call NdfRepairIncident to repair the problem without displaying a user
	/// interface. NdfCancelIncident can optionally be called from a separate thread if the application wants to cancel an ongoing
	/// <c>NdfDiagnoseIncident</c> call. Finally, the application calls NdfCloseIncident.
	/// </para>
	/// <para>The following table shows some examples of root causes and their corresponding repairs.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Root cause GUID</term>
	/// <term>Repair GUID</term>
	/// <term>Root cause description</term>
	/// <term>Repair description</term>
	/// </listheader>
	/// <item>
	/// <term>{4DA030B8-86E5-4b6a-A879-2FFF8443B527}</term>
	/// <term>{1296DFF0-D04E-4be1-A512-90F04DDFA3E6}</term>
	/// <term>A network cable is not properly plugged in or may be broken.</term>
	/// <term>
	/// Plug an Ethernet cable into this computer.\nAn Ethernet cable looks like a telephone cable but with larger connectors on the ends.
	/// Plug this cable into the opening on the back or side of the computer.\nMake sure the other end of the cable is plugged into the
	/// router. If that does not help, try using a different cable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>{60372FD2-AD60-45c2-BD83-6B827FC438DF}</term>
	/// <term>{07d37f7b-fa5e-4443-bda7-ab107b29afb6}</term>
	/// <term>The %InterfaceName% adapter is disabled.</term>
	/// <term>Enable the %FriendlyInterfaceName% adapter.</term>
	/// </item>
	/// <item>
	/// <term>{245A9D66-AE9C-4518-A5B4-655752B0A5BD}</term>
	/// <term>{07d37f7b-fa5e-4443-bda7-ab107b29afb9}</term>
	/// <term>%InterfaceName%"" doesn't have a valid IP configuration.</term>
	/// <term>Reset the ""%InterfaceName%"" adapter.\nThis can sometimes resolve an intermittent problem.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfdiagnoseincident HRESULT NdfDiagnoseIncident( [in] NDFHANDLE
	// Handle, [out] ULONG *RootCauseCount, [out] RootCauseInfo **RootCauses, DWORD dwWait, DWORD dwFlags );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfDiagnoseIncident")]
	public static extern HRESULT NdfDiagnoseIncident([In] NDFHANDLE Handle, out uint RootCauseCount,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out RootCauseInfo[] RootCauses, uint dwWait, NDF_DIAG dwFlags);

	/// <summary>The <c>NdfExecuteDiagnosis</c> function is used to diagnose the root cause of the incident that has occurred.</summary>
	/// <param name="handle">
	/// <para>Type: <c>NDFHANDLE</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident.</para>
	/// </param>
	/// <param name="hwnd">
	/// <para>Type: <c>HWND</c></para>
	/// <para>
	/// Handle to the window that is intended to display the diagnostic information. If specified, the NDF UI is modal to the window. If
	/// <c>NULL</c>, the UI is non-modal.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>E_HANDLE</c></term>
	/// <term><c>handle</c> is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfexecutediagnosis HRESULT NdfExecuteDiagnosis( NDFHANDLE handle,
	// HWND hwnd );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfExecuteDiagnosis")]
	public static extern HRESULT NdfExecuteDiagnosis(NDFHANDLE handle, [In, Optional] HWND hwnd);

	/// <summary>
	/// The <c>NdfGetTraceFile</c> function is used to retrieve the path containing an Event Trace Log (ETL) file that contains Event Tracing
	/// for Windows (ETW) events from a diagnostic session.
	/// </summary>
	/// <param name="Handle">
	/// <para>Type: <c>NDFHANDLE</c></para>
	/// <para>Handle to a Network Diagnostics Framework incident. This handle should match the handle of an existing incident.</para>
	/// </param>
	/// <param name="TraceFileLocation">
	/// <para>Type: <c>LPCWSTR*</c></para>
	/// <para>The location of the trace file.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>The operation succeeded.</term>
	/// </item>
	/// </list>
	/// <para>Any result other than S_OK should be interpreted as an error.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function cannot be called on an incident which has already been closed.</para>
	/// <para>
	/// ETL files contain information such as which components were diagnosed, component configuration information, and diagnosis results.
	/// For more information about ETL files, see Network Tracing in Windows 7.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfgettracefile HRESULT NdfGetTraceFile( [in] NDFHANDLE Handle,
	// [out] LPCWSTR *TraceFileLocation );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfGetTraceFile")]
	public static extern HRESULT NdfGetTraceFile([In] NDFHANDLE Handle, [MarshalAs(UnmanagedType.LPWStr)] out string TraceFileLocation);

	/// <summary>The <c>NdfRepairIncident</c> function repairs an incident without displaying a user interface.</summary>
	/// <param name="Handle">
	/// <para>Type: <c>NDFHANDLE</c></para>
	/// <para>Handle to the Network Diagnostics Framework incident. This handle should match the handle passed to NdfDiagnoseIncident.</para>
	/// </param>
	/// <param name="RepairEx">
	/// <para>Type: <c>RepairInfoEx*</c></para>
	/// <para>A structure (obtained from NdfDiagnoseIncident) which indicates the particular repair to be performed.</para>
	/// <para>
	/// Memory allocated to these structures should later be freed. For an example of how to do this, see the Microsoft Windows Network
	/// Diagnostics Samples.
	/// </para>
	/// </param>
	/// <param name="dwWait">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>
	/// The length of time, in milliseconds, to wait before terminating the diagnostic routine. INFINITE may be passed to this parameter if
	/// no timeout is desired.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Possible return values include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>S_OK</c></term>
	/// <term>Repair succeeded.</term>
	/// </item>
	/// <item>
	/// <term><c>NDF_E_VALIDATION</c></term>
	/// <term>
	/// The repair executed successfully, but NDF validation still found a connectivity problem. If this value is returned, the session
	/// should be closed by calling NdfCloseIncident and another session should be created to continue the diagnosis.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>E_HANDLE</c></term>
	/// <term>The NDF incident handle is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>WAIT_TIMEOUT</c></term>
	/// <term>The repair operation has terminated because it has taken longer than the time-out specified in dwWait.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Other failure codes are returned if the repair failed to execute. In that case, the client can call <c>NdfRepairIncident</c> again
	/// with a different repair.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>NdfRepairIncident</c> can only be called when NdfDiagnoseIncident is used for diagnostics. This is typically the case in scenarios
	/// where no user interface is shown, or where the standard Windows experience is not being used (as with Media Center and embedded
	/// applications). <c>NdfRepairIncident</c> should not be called when NdfExecuteDiagnosis is used.
	/// </para>
	/// <para>
	/// Before using this API, an application must call an incident creation function such as NdfCreateWebIncident to begin the NDF
	/// diagnostics process. The application then calls NdfDiagnoseIncident to diagnose the issue. If the diagnostics process identifies some
	/// possible repairs, the application can call <c>NdfRepairIncident</c> to repair the problem without displaying a user interface.
	/// NdfCancelIncident can optionally be called from a separate thread if the application wants to cancel an ongoing
	/// <c>NdfRepairIncident</c> call. Finally, the application calls NdfCloseIncident.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ndfapi/nf-ndfapi-ndfrepairincident HRESULT NdfRepairIncident( [in] NDFHANDLE
	// Handle, [in] RepairInfoEx *RepairEx, DWORD dwWait );
	[DllImport(Lib_Ndfapi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ndfapi.h", MSDNShortId = "NF:ndfapi.NdfRepairIncident")]
	public static extern HRESULT NdfRepairIncident([In] NDFHANDLE Handle, in RepairInfoEx RepairEx, uint dwWait);

	/// <summary>Provides a handle to a Network Diagnostic Framework incident.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct NDFHANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="NDFHANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public NDFHANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="NDFHANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static NDFHANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(NDFHANDLE h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="NDFHANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(NDFHANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NDFHANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator NDFHANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(NDFHANDLE h1, NDFHANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(NDFHANDLE h1, NDFHANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is NDFHANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NDFHANDLE"/> that is disposed using <see cref="NdfCloseIncident"/>.</summary>
	public class SafeNDFHANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeNDFHANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeNDFHANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNDFHANDLE"/> class.</summary>
		private SafeNDFHANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeNDFHANDLE"/> to <see cref="NDFHANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator NDFHANDLE(SafeNDFHANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => NdfCloseIncident(handle).Succeeded;
	}
}