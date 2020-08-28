using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke
{
	/// <summary>Items from the P2P.dll</summary>
	public static partial class P2P
	{
		/// <summary/>
		public const ushort PEER_COLLAB_VERSION = 0x0001;

		/// <summary/>
		public const ushort PEER_GRAPH_VERSION = 0x0001;

		/// <summary/>
		public const ushort PEER_GROUP_VERSION = 0x0101;

		/// <summary/>
		public const ushort PNRP_VERSION = 0x0002;

		/// <summary>
		/// The <c>PFNPEER_FREE_SECURITY_DATA</c> callback specifies the function that the Peer Graphing Infrastructure calls to free data
		/// returned by PFNPEER_SECURE_RECORD and PFNPEER_VALIDATE_RECORD callbacks.
		/// </summary>
		/// <param name="hGraph">Specifies the peer graph associated with the specified record.</param>
		/// <param name="pvContext">
		/// Pointer to the security context to free. This parameter is set to the value of the <c>pvContext</c> member of the
		/// PEER_SECURITY_INTERFACE structure passed in PeerGraphCreate or PeerGraphOpen.
		/// </param>
		/// <param name="pSecurityData">Pointer to the security data to free.</param>
		/// <returns>
		/// <para>If the callback is successful, the return value is S_OK. Otherwise, the callback returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This callback can be invoked from any of the Peer Graphing API functions involving records, such as PeerGraphUpdateRecord.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nc-p2p-pfnpeer_free_security_data PFNPEER_FREE_SECURITY_DATA
		// PfnpeerFreeSecurityData; HRESULT PfnpeerFreeSecurityData( HGRAPH hGraph, PVOID pvContext, PPEER_DATA pSecurityData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("p2p.h", MSDNShortId = "NC:p2p.PFNPEER_FREE_SECURITY_DATA")]
		public delegate HRESULT PFNPEER_FREE_SECURITY_DATA(HGRAPH hGraph, [In, Optional] IntPtr pvContext, in PEER_DATA pSecurityData);

		/// <summary></summary>
		/// <param name="hGraph">Specifies the peer graph associated with the specified record.</param>
		/// <param name="pvContext">
		/// Pointer to the security context. This parameter should point to the <c>pvContext</c> member of the PEER_SECURITY_INTERFACE structure.
		/// </param>
		/// <returns>If this callback succeeds, the return value is S_OK; otherwise, the error.</returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("p2p.h")]
		public delegate HRESULT PFNPEER_ON_PASSWORD_AUTH_FAILED(HGRAPH hGraph, [In, Optional] IntPtr pvContext);

		/// <summary>
		/// The <c>PFNPEER_SECURE_RECORD</c> callback specifies the function that the Peer Graphing Infrastructure calls to secure records.
		/// </summary>
		/// <param name="hGraph">Specifies the peer graph associated with the specified record.</param>
		/// <param name="pvContext">
		/// Pointer to the security context. This parameter points to the <c>pvContext</c> member of the PEER_SECURITY_INTERFACE structure.
		/// </param>
		/// <param name="pRecord">Pointer to the record to secure.</param>
		/// <param name="changeType">Specifies the reason the validation must occur. PEER_RECORD_CHANGE_TYPE enumerates the valid values.</param>
		/// <param name="ppSecurityData"/>
		/// <returns>If this callback succeeds, the return value is S_OK.</returns>
		/// <remarks>
		/// <para>
		/// This callback is invoked whenever an application calls any of the methods that modify records, such as PeerGraphAddRecord or
		/// PeerGraphUpdateRecord. This callback should create data that is specific to this record, such as a small digital signature, and
		/// return it through the ppSecurityData parameter. This data is then added to the record in the <c>securityData</c> member, and is
		/// verified by the method specified by the <c>pfnValidateRecord</c> member of the PEER_SECURITY_INTERFACE.
		/// </para>
		/// <para>
		/// <c>Note</c> This process happens on the local computer as well as any peer connected to the graph when the peer receives the record.
		/// </para>
		/// <para>
		/// If the operation specified by the changeType parameter is not allowed, the callback should return a failure code, such as
		/// PEER_E_NOT_AUTHORIZED, instead of S_OK.
		/// </para>
		/// <para>This callback can be invoked from any of the Peer Graphing API functions involving records, such as PeerGraphUpdateRecord.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nc-p2p-pfnpeer_secure_record PFNPEER_SECURE_RECORD PfnpeerSecureRecord;
		// HRESULT PfnpeerSecureRecord( HGRAPH hGraph, PVOID pvContext, PPEER_RECORD pRecord, PEER_RECORD_CHANGE_TYPE changeType, PPEER_DATA
		// *ppSecurityData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("p2p.h", MSDNShortId = "NC:p2p.PFNPEER_SECURE_RECORD")]
		public delegate HRESULT PFNPEER_SECURE_RECORD(HGRAPH hGraph, [In, Optional] IntPtr pvContext, in PEER_RECORD pRecord, PEER_RECORD_CHANGE_TYPE changeType, out PEER_DATA ppSecurityData);

		/// <summary>
		/// The <c>PFNPEER_VALIDATE_RECORD</c> callback specifies the function that the Peer Graphing Infrastructure calls to validate records.
		/// </summary>
		/// <param name="hGraph">Specifies the peer graph associated with the specified record.</param>
		/// <param name="pvContext">
		/// Pointer to the security context. This parameter should point to the <c>pvContext</c> member of the PEER_SECURITY_INTERFACE structure.
		/// </param>
		/// <param name="pRecord">Specifies the record to validate.</param>
		/// <param name="changeType">Specifies the reason the validation must occur. Must be one of the PEER_RECORD_CHANGE_TYPE values.</param>
		/// <returns>
		/// <para>If this callback succeeds, the return value is S_OK; otherwise, the function returns one of the following errors:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_DEFERRED_VALIDATION</term>
		/// <term>
		/// The specified record cannot be validated at this time because there is insufficient information to complete the operation.
		/// Validation is deferred. Call PeerGraphValidateDeferredRecords when sufficient information is obtained.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_RECORD</term>
		/// <term>The specified record is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this callback is called by the Peer Graphing Infrastructure, a PEER_RECORD_CHANGE_TYPE value is passed. This specifies the
		/// operation just performed on the record. The application must verify the record based on the change type. If the application
		/// requires more information to verify the record, it can return PEER_E_DEFERRED_VALIDATION and the Peer Graphing Infrastructure
		/// places the record in a deferred-record list. Once the security mechanism has enough information to validate the record, it calls
		/// PeerGraphValidateDeferredRecords, and any record in the deferred-record list is re-submitted for validation.
		/// </para>
		/// <para>This callback can be invoked from any of the Peer Graphing API functions involving records, such as PeerGraphUpdateRecord.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nc-p2p-pfnpeer_validate_record PFNPEER_VALIDATE_RECORD
		// PfnpeerValidateRecord; HRESULT PfnpeerValidateRecord( HGRAPH hGraph, PVOID pvContext, PPEER_RECORD pRecord,
		// PEER_RECORD_CHANGE_TYPE changeType ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("p2p.h", MSDNShortId = "NC:p2p.PFNPEER_VALIDATE_RECORD")]
		public delegate HRESULT PFNPEER_VALIDATE_RECORD(HGRAPH hGraph, [In, Optional] IntPtr pvContext, in PEER_RECORD pRecord, PEER_RECORD_CHANGE_TYPE changeType);

		/// <summary>
		/// The <c>PeerEndEnumeration</c> function releases an enumeration, for example, a record or member enumeration, and deallocates all
		/// resources associated with the enumeration.
		/// </summary>
		/// <param name="hPeerEnum">Handle to the enumeration to be released. This handle is generated by a peer enumeration function.</param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerendenumeration NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerEndEnumeration( HPEERENUM hPeerEnum );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerEndEnumeration")]
		public static extern HRESULT PeerEndEnumeration(HPEERENUM hPeerEnum);

		/// <summary>
		/// The <c>PeerFreeData</c> function deallocates a block of data and returns it to the memory pool. Use the <c>PeerFreeData</c>
		/// function to free data that the Peer Identity Manager, Peer Grouping, and Peer Collaboration APIs return.
		/// </summary>
		/// <param name="pvData">Pointer to a block of data to be deallocated. This parameter must reference a valid block of memory.</param>
		/// <returns>There are no return values.</returns>
		/// <remarks>
		/// Do not use this function to release memory that the Peer Graphing API returns. Use PeerGraphFreeData for memory that the Peer
		/// Graphing API returns.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerfreedata NOT_BUILD_WINDOWS_DEPRECATE VOID PeerFreeData( LPCVOID
		// pvData );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerFreeData")]
		public static extern void PeerFreeData(IntPtr pvData);

		/// <summary>The <c>PeerGetItemCount</c> function returns a count of the items in a peer enumeration.</summary>
		/// <param name="hPeerEnum">
		/// Handle to the peer enumeration on which a count is performed. A peer enumeration function generates this handle.
		/// </param>
		/// <param name="pCount">Returns the total number of items in a peer enumeration.</param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergetitemcount NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGetItemCount( HPEERENUM hPeerEnum, ULONG *pCount );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGetItemCount")]
		public static extern HRESULT PeerGetItemCount(HPEERENUM hPeerEnum, out uint pCount);

		/// <summary>The <c>PeerGetNextItem</c> function returns a specific number of items from a peer enumeration.</summary>
		/// <param name="hPeerEnum">
		/// Handle to the peer enumeration from which items are retrieved. This handle is generated by a peer enumeration function.
		/// </param>
		/// <param name="pCount">
		/// Pointer to an integer that specifies the number of items to be retrieved from the peer enumeration. When returned, it contains
		/// the number of items in ppvItems. This parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="pppvItems">
		/// Receives a pointer to an array of pointers to the next pCount items in the peer enumeration. The data, for example, a record or
		/// member information block, depends on the actual peer enumeration type.
		/// </param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform a specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>PeerGetNextItem</c> function returns the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Items that are equal to or less than the amount specified in pCount.</term>
		/// </item>
		/// <item>
		/// <term>A list of items that are less than the amount specified when the amount is greater than the number of items available.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> For example, when the inbound value of pCount is 10 and the remainder of the enumeration is 5 items, only 5 items
		/// are returned and the value pointed to by pCount is set to 5.
		/// </para>
		/// <para>All items returned must be freed by passing a pointer to the array of pointers to the PeerFreeData function.</para>
		/// <para>The end of an enumeration is indicated when the function returns with the pCount parameter set to zero (0).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergetnextitem NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGetNextItem( HPEERENUM hPeerEnum, ULONG *pCount, PVOID **pppvItems );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGetNextItem")]
		public static extern HRESULT PeerGetNextItem([In] HPEERENUM hPeerEnum, ref uint pCount, out SafePeerData pppvItems);

		/// <summary>
		/// The <c>PeerGraphShutdown</c> function cleans up any resources allocated by the call to PeerGraphStartup. There must be a call to
		/// <c>PeerGraphShutdown</c> for each call to <c>PeerGraphStartup</c>.
		/// </summary>
		/// <returns>
		/// <para>
		/// Returns S_OK if the operation succeeds; otherwise, the function returns the one of the standard error codes defined in
		/// WinError.h, or the function returns the following value:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_NOT_INITIALIZED</term>
		/// <term>The peer graph must be initialized with a call to PeerGraphStartup before using this function.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// When the last <c>PeerGraphShutdown</c> is called for a peer graph, all the opened peer graphs, outstanding enumeration handles,
		/// and outstanding event registration handles are automatically released.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergraphshutdown NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerGraphShutdown();
		[DllImport(Lib_P2PGraph, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGraphShutdown")]
		public static extern HRESULT PeerGraphShutdown();

		/// <summary>
		/// The <c>PeerGraphStartup</c> function indicates to the Peer Graphing Infrastructure what version of the Peer protocols the
		/// calling application requires. <c>PeerGraphStartup</c> must be called before any other peer graphing functions. It must be
		/// matched by a call to PeerGraphShutdown.
		/// </summary>
		/// <param name="wVersionRequested">Specify PEER_GRAPH_VERSION.</param>
		/// <param name="pVersionData">
		/// Pointer to a PEER_VERSION_DATA structure that receives the version of the Peer Infrastructure installed on the local computer.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds; otherwise, the function returns one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNSUPPORTED_VERSION</term>
		/// <term>The version requested is not supported by the Peer Infrastructure .dll installed on the local computer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergraphstartup NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGraphStartup( WORD wVersionRequested, PPEER_VERSION_DATA pVersionData );
		[DllImport(Lib_P2PGraph, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGraphStartup")]
		public static extern HRESULT PeerGraphStartup(ushort wVersionRequested, out PEER_VERSION_DATA pVersionData);

		/// <summary>
		/// The <c>PeerHostNameToPeerName</c> function decodes a host name returned by PeerNameToPeerHostName into the peer name string it represents.
		/// </summary>
		/// <param name="pwzHostName">Pointer to a zero-terminated Unicode string that contains the host name to decode.</param>
		/// <param name="ppwzPeerName">
		/// Pointer to the address of the zero-terminated Unicode string that contains the decoded peer name. The returned string must be
		/// released with PeerFreeData.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerhostnametopeername NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerHostNameToPeerName( PCWSTR pwzHostName, PWSTR *ppwzPeerName );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerHostNameToPeerName")]
		public static extern HRESULT PeerHostNameToPeerName([MarshalAs(UnmanagedType.LPWStr)] string pwzHostName,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzPeerName);

		/// <summary>
		/// The <c>PeerNameToPeerHostName</c> function encodes the supplied peer name as a format that can be used with a subsequent call to
		/// the getaddrinfo Windows Sockets function.
		/// </summary>
		/// <param name="pwzPeerName">Pointer to a zero-terminated Unicode string that contains the peer name to encode as a host name.</param>
		/// <param name="ppwzHostName">
		/// Pointer to the address of the zero-terminated Unicode string that contains the encoded host name. This string can be passed to
		/// getaddrinfo_v2 to obtain network information about the peer.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peernametopeerhostname NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerNameToPeerHostName( PCWSTR pwzPeerName, PWSTR *ppwzHostName );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerNameToPeerHostName")]
		public static extern HRESULT PeerNameToPeerHostName([MarshalAs(UnmanagedType.LPWStr)] string pwzPeerName,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzHostName);

		/// <summary>
		/// The <c>PeerPnrpEndResolve</c> function closes the handle for an asynchronous PNRP resolution operation initiated with a previous
		/// call to PeerPnrpStartResolve.
		/// </summary>
		/// <param name="hResolve">The handle to the asynchronous peer name resolution operation returned by a previous call to PeerPnrpStartResolve.</param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpendresolve NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpEndResolve( HRESOLUTION hResolve );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpEndResolve")]
		public static extern HRESULT PeerPnrpEndResolve(HRESOLUTION hResolve);

		/// <summary>
		/// The <c>PeerPnrpCloudInfo</c> function retrieves information on the Peer Name Resolution Protocol (PNRP) clouds in which the
		/// calling peer is participating.
		/// </summary>
		/// <param name="pcNumClouds">The number of PNRP clouds returned in ppCloudInfo.</param>
		/// <param name="ppCloudInfo">
		/// <para>
		/// Pointer to a list of PEER_PNRP_CLOUD_INFO structures that contain information about the PNRP clouds in which the calling peer is participating.
		/// </para>
		/// <para>This data returned by this parameter must be freed by calling PeerFreeData.</para>
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpgetcloudinfo NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpGetCloudInfo( ULONG *pcNumClouds, PPEER_PNRP_CLOUD_INFO *ppCloudInfo );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpGetCloudInfo")]
		public static extern HRESULT PeerPnrpGetCloudInfo(out uint pcNumClouds,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_PNRP_CLOUD_INFO>))] out PEER_PNRP_CLOUD_INFO ppCloudInfo);

		/// <summary>
		/// The <c>PeerPnrpGetEndpoint</c> function retrieves a peer endpoint address resolved during an asynchronous peer name resolution operation.
		/// </summary>
		/// <param name="hResolve">The handle to the asynchronous peer name resolution operation returned by a previous call to PeerPnrpStartResolve.</param>
		/// <param name="ppEndpoint">
		/// <para>
		/// Pointer to the address of a PEER_PNRP_ENDPOINT_INFO structure that contains an endpoint address for the peer name supplied in
		/// the previous call to PeerPnrpStartResolve.
		/// </para>
		/// <para>This data returned by this parameter must be freed by calling PeerFreeData.</para>
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_MORE</term>
		/// <term>All endpoint addresses have been retrieved for the peer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>PeerPnrpStartResolve creates a handle to an asynchronous peer name resolution operation.</para>
		/// <para>
		/// Whenever an endpoint is found, the event handle provided in hEvent is signaled, and <c>PeerPnrpGetEndpoint</c> must be called
		/// with the phResolve handle by the application to obtain that endpoint.
		/// </para>
		/// <para>
		/// The last event specifies the PEER_E_NO_MORE error code, indicating that all endpoints corresponding to the peer name supplied to
		/// PeerPnrpStartResolve have been found. At this time, the application must close the handle with a call to PeerPnrpEndResolve.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpgetendpoint NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpGetEndpoint( HRESOLUTION hResolve, PPEER_PNRP_ENDPOINT_INFO *ppEndpoint );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpGetEndpoint")]
		public static extern HRESULT PeerPnrpGetEndpoint(HRESOLUTION hResolve,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_PNRP_ENDPOINT_INFO>))] out PEER_PNRP_ENDPOINT_INFO ppEndpoint);

		/// <summary>
		/// <para>
		/// The <c>PeerPnrpRegister</c> function registers a peer with a PNRP cloud and returns a handle that can be used for registration updates.
		/// </para>
		/// <para><c>Note</c> When called, this function will block until the PNRP service has been initiated.</para>
		/// </summary>
		/// <param name="pcwzPeerName">
		/// Pointer to a zero-terminated Unicode string that contains the peer name to register with the PNRP service.
		/// </param>
		/// <param name="pRegistrationInfo">
		/// Pointer to a PEER_PNRP_REGISTRATION_INFO structure that contains the endpoint information for the registering peer node. If
		/// <c>NULL</c>, the API will register the peer with all known PNRP clouds, and any registered addresses are automatically selected
		/// by the infrastructure.
		/// </param>
		/// <param name="phRegistration">
		/// Handle to the PNRP registration for the calling peer node. Use this handle to update the registration or to deregister with the
		/// PNRP service.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_NOT_FOUND</term>
		/// <term>The local peer is using an identity that does not exist.</term>
		/// </item>
		/// </list>
		/// <para>Additionally, this function can return WSA values. For a complete list of possible values, see PNRP NSP Error Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A handle must be registered in a process separate of the process it will be resolved in. If a handle is registered and resolved
		/// within the same process it will not be recognized.
		/// </para>
		/// <para>A name cannot be registered with an endpoint more than once. When updates to a registered name are required, use PeerPnrpUpdateRegistration.</para>
		/// <para>
		/// When pRegistrationInfo is <c>NULL</c>, or PEER_PNRP_AUTO_ADDRESSES is specified for cAddresses, the infrastructure will keep the
		/// addresses registered up to date as addresses change or cloud availability changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpregister NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpRegister( PCWSTR pcwzPeerName, PPEER_PNRP_REGISTRATION_INFO pRegistrationInfo, HREGISTRATION *phRegistration );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpRegister")]
		public static extern HRESULT PeerPnrpRegister([MarshalAs(UnmanagedType.LPWStr)] string pcwzPeerName, in PEER_PNRP_REGISTRATION_INFO pRegistrationInfo, out HREGISTRATION phRegistration);

		/// <summary>
		/// <para>
		/// The <c>PeerPnrpRegister</c> function registers a peer with a PNRP cloud and returns a handle that can be used for registration updates.
		/// </para>
		/// <para><c>Note</c> When called, this function will block until the PNRP service has been initiated.</para>
		/// </summary>
		/// <param name="pcwzPeerName">
		/// Pointer to a zero-terminated Unicode string that contains the peer name to register with the PNRP service.
		/// </param>
		/// <param name="pRegistrationInfo">
		/// Pointer to a PEER_PNRP_REGISTRATION_INFO structure that contains the endpoint information for the registering peer node. If
		/// <c>NULL</c>, the API will register the peer with all known PNRP clouds, and any registered addresses are automatically selected
		/// by the infrastructure.
		/// </param>
		/// <param name="phRegistration">
		/// Handle to the PNRP registration for the calling peer node. Use this handle to update the registration or to deregister with the
		/// PNRP service.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_NOT_FOUND</term>
		/// <term>The local peer is using an identity that does not exist.</term>
		/// </item>
		/// </list>
		/// <para>Additionally, this function can return WSA values. For a complete list of possible values, see PNRP NSP Error Codes.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A handle must be registered in a process separate of the process it will be resolved in. If a handle is registered and resolved
		/// within the same process it will not be recognized.
		/// </para>
		/// <para>A name cannot be registered with an endpoint more than once. When updates to a registered name are required, use PeerPnrpUpdateRegistration.</para>
		/// <para>
		/// When pRegistrationInfo is <c>NULL</c>, or PEER_PNRP_AUTO_ADDRESSES is specified for cAddresses, the infrastructure will keep the
		/// addresses registered up to date as addresses change or cloud availability changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpregister NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpRegister( PCWSTR pcwzPeerName, PPEER_PNRP_REGISTRATION_INFO pRegistrationInfo, HREGISTRATION *phRegistration );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpRegister")]
		public static extern HRESULT PeerPnrpRegister([MarshalAs(UnmanagedType.LPWStr)] string pcwzPeerName, [In, Optional] IntPtr pRegistrationInfo, out HREGISTRATION phRegistration);

		/// <summary>The <c>PeerPnrpResolve</c> function obtains the endpoint address(es) registered for a specific peer name.</summary>
		/// <param name="pcwzPeerName">
		/// Pointer to a zero-terminated string that contains the peer name for which endpoint addresses will be obtained.
		/// </param>
		/// <param name="pcwzCloudName">
		/// Pointer to a zero-terminated string that contains the name of the PNRP cloud under which to resolve the peer name. If
		/// <c>NULL</c>, the resolve is performed in all clouds. If PEER_PNRP_ALL_LINK_CLOUDS, the resolve is performed in all link local
		/// clouds. When "GLOBAL_", resolve will only take place in the global cloud.
		/// </param>
		/// <param name="pcEndpoints">
		/// The maximum number of endpoints to return in ppEndpoints. Upon return, this parameter contains the actual number of endpoints in ppEndpoints.
		/// </param>
		/// <param name="ppEndpoints">
		/// Pointer to a list of PEER_PNRP_ENDPOINT_INFO structures that contain the endpoints for which the peer name successfully
		/// resolved. Each endpoint contains one or more IP addresses at which the peer node can be reached.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This call is synchronous and will block until completed. For aysnchronous peer name resolution, call PeerPnrpStartResolve and
		/// obtain the resolved endpoint address when the supplied event is raised.
		/// </para>
		/// <para>
		/// A handle must be resolved in a process separate of the process it was registered in. If a handle is registered and resolved
		/// within the same process it will not be recognized.
		/// </para>
		/// <para>
		/// When resolution is performed for all clouds, it is issued to each cloud simultaneously. The method will return as soon as it has
		/// received enough results from any combination of clouds.
		/// </para>
		/// <para>
		/// The default resolve timeout used internally by this method is 30 seconds. If a specific timeout is required, the asynchronous
		/// PeerPnrpStartResolve function should be used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpresolve NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpResolve( PCWSTR pcwzPeerName, PCWSTR pcwzCloudName, ULONG *pcEndpoints, PPEER_PNRP_ENDPOINT_INFO *ppEndpoints );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpResolve")]
		public static extern HRESULT PeerPnrpResolve([MarshalAs(UnmanagedType.LPWStr)] string pcwzPeerName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pcwzCloudName,
			ref uint pcEndpoints, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PEER_PNRP_ENDPOINT_INFO[] ppEndpoints);

		/// <summary>
		/// The <c>PeerPnrpShutdown</c> function shuts down a running instance of the Peer Name Resolution Protocol (PNRP) service and
		/// releases all resources associated with it.
		/// </summary>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_NOT_INITIALIZED</term>
		/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpshutdown NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerPnrpShutdown();
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpShutdown")]
		public static extern HRESULT PeerPnrpShutdown();

		/// <summary>The <c>PeerPnrpStartResolve</c> function starts an asynchronous peer name resolution operation.</summary>
		/// <param name="pcwzPeerName">
		/// Pointer to a zero-terminated string that contains the peer name for which endpoint addresses will be obtained.
		/// </param>
		/// <param name="pcwzCloudName">
		/// Pointer to a zero-terminated string that contains the name of the PNRP cloud under which to resolve the peer name. If
		/// <c>NULL</c>, resolution is performed for all clouds. If PEER_PNRP_ALL_LINK_CLOUDS, resolution is performed for all link local
		/// clouds. When "GLOBAL_" is specified, resolution takes place in the global cloud.
		/// </param>
		/// <param name="cMaxEndpoints">The maximum number of endpoints to return for the peer name.</param>
		/// <param name="hEvent">
		/// Handle to the event signaled when a peer endpoint is resolved for the supplied peer name and are ready for consumption by
		/// calling PeerPnrpGetEndpoint. This event is signaled for every endpoint discovered by the PNRP service. If PEER_NO_MORE is
		/// returned by a call to PeerPnrpGetEndpoint, then all endpoints have been found for that peer.
		/// </param>
		/// <param name="phResolve">
		/// Handle to this peer name resolution request. This handle must be provided to PeerPnrpEndResolve after the resolution events are
		/// raised and the endpoints are obtained with corresponding calls to PeerPnrpGetEndpoint, or if the operation fails.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para><c>PeerPnrpStartResolve</c> creates a handle to an asynchronous peer name resolution operation.</para>
		/// <para>
		/// Whenever an endpoint is found, the event handle provided in hEvent is signaled, and PeerPnrpGetEndpoint must be called with the
		/// phResolve handle by the application to obtain that endpoint.
		/// </para>
		/// <para>
		/// The last event specifies the PEER_E_NO_MORE error code, indicating that all endpoints corresponding to the peer name supplied to
		/// <c>PeerPnrpStartResolve</c> have been found. At this time, the application must close the handle with a call to PeerPnrpEndResolve.
		/// </para>
		/// <para>
		/// A handle must be resolved in a process separate from the process in which it was registered. If a handle is registered and
		/// resolved within the same process it will not be recognized.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpstartresolve NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpStartResolve( PCWSTR pcwzPeerName, PCWSTR pcwzCloudName, ULONG cMaxEndpoints, HANDLE hEvent, HRESOLUTION *phResolve );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpStartResolve")]
		public static extern HRESULT PeerPnrpStartResolve([MarshalAs(UnmanagedType.LPWStr)] string pcwzPeerName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pcwzCloudName,
			[Optional] uint cMaxEndpoints, HANDLE hEvent, out HRESOLUTION phResolve);

		/// <summary>The <c>PeerPnrpStartup</c> function starts the Peer Name Resolution Protocol (PNRP) service for the calling peer.</summary>
		/// <param name="wVersionRequested">The version of PNRP to use for this service instance. The default value is PNRP_VERSION (2).</param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNSUPPORTED_VERSION</term>
		/// <term>The provided version is unsupported.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_SERVICE_NOT_AVAILABLE</term>
		/// <term>
		/// The Peer Collaboration infrastructure, which includes People Near Me, is not available. This code will also be returned whenever
		/// an attempt is made to utilize the Collaboration infrastructure from an elevated process.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>To shutdown the PNRP service for the calling peer and release all resources associated with it, call PeerPnrpShutdown.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpstartup NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpStartup( WORD wVersionRequested );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpStartup")]
		public static extern HRESULT PeerPnrpStartup(ushort wVersionRequested = PNRP_VERSION);

		/// <summary>The <c>PeerPnrpUnregister</c> function deregisters a peer from a PNRP cloud.</summary>
		/// <param name="hRegistration">Handle to a PNRP registration for the peer node obtained by a previous call to PeerPnrpRegister.</param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpunregister NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpUnregister( HREGISTRATION hRegistration );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpUnregister")]
		public static extern HRESULT PeerPnrpUnregister(HREGISTRATION hRegistration);

		/// <summary>The <c>PeerPnrpUpdateRegistration</c> function updates the PNRP registration information for a name.</summary>
		/// <param name="hRegistration">Handle to a PNRP registration for the peer node obtained by a previous call to PeerPnrpRegister.</param>
		/// <param name="pRegistrationInfo">
		/// Pointer to a PEER_PNRP_REGISTRATION_INFO structure that contains the endpoint information for the registering peer node.
		/// </param>
		/// <returns>
		/// <para>If the function call succeeds, the return value is <c>S_OK</c>. Otherwise, it returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>pwzCloudName</c> and <c>cAddresses</c> members of the PEER_PNRP_REGISTRATION_INFO provided in the pRegistrationInfo
		/// parameter cannot be changed with PeerPnrpUpdateRegistration. Attempting to do so will return an <c>E_INVALIDARG</c> error.
		/// </para>
		/// <para>PeerPnrpUpdateRegistration has a maximum payload of 4k.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peerpnrpupdateregistration NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerPnrpUpdateRegistration( HREGISTRATION hRegistration, PPEER_PNRP_REGISTRATION_INFO pRegistrationInfo );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerPnrpUpdateRegistration")]
		public static extern HRESULT PeerPnrpUpdateRegistration(HREGISTRATION hRegistration, in PEER_PNRP_REGISTRATION_INFO pRegistrationInfo);

		/// <summary>Provides a handle to a peer enumeration.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HPEERENUM : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HPEERENUM"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HPEERENUM(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HPEERENUM"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HPEERENUM NULL => new HPEERENUM(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HPEERENUM"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HPEERENUM h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPEERENUM"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HPEERENUM(IntPtr h) => new HPEERENUM(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HPEERENUM h1, HPEERENUM h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HPEERENUM h1, HPEERENUM h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HPEERENUM h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to the PNRP registration for the calling peer node.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HREGISTRATION : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HREGISTRATION"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HREGISTRATION(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HREGISTRATION"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HREGISTRATION NULL => new HREGISTRATION(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HREGISTRATION"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HREGISTRATION h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HREGISTRATION"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HREGISTRATION(IntPtr h) => new HREGISTRATION(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HREGISTRATION h1, HREGISTRATION h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HREGISTRATION h1, HREGISTRATION h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HREGISTRATION h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to an asynchronous peer name resolution operation.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HRESOLUTION : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HRESOLUTION"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HRESOLUTION(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HRESOLUTION"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HRESOLUTION NULL => new HRESOLUTION(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HRESOLUTION"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HRESOLUTION h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRESOLUTION"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HRESOLUTION(IntPtr h) => new HRESOLUTION(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HRESOLUTION h1, HRESOLUTION h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HRESOLUTION h1, HRESOLUTION h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HRESOLUTION h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HPEERENUM"/> that is disposed using <see cref="PeerEndEnumeration"/>.</summary>
		/// <typeparam name="T">The type of the structure that can be enumerated.</typeparam>
		/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
		/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
		public class SafeHPEERENUM<T> : SafeHANDLE, IEnumerable<T> where T : struct
		{
			private uint count;
			private SafePeerData data;

			/// <summary>Initializes a new instance of the <see cref="SafeHPEERENUM{T}"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHPEERENUM(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHPEERENUM{T}"/> class.</summary>
			private SafeHPEERENUM() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHPEERENUM{T}"/> to <see cref="HPEERENUM"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HPEERENUM(SafeHPEERENUM<T> h) => h.handle;

			IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<T>)this).GetEnumerator();

			IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)GetData().DangerousGetHandle().ToArray<T>((int)count)).GetEnumerator();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle()
			{
				data?.Dispose();
				return PeerEndEnumeration(handle).Succeeded;
			}

			private SafePeerData GetData()
			{
				if (IsInvalid) throw new InvalidOperationException("The enumeration has ended.");
				if (data is null)
				{
					PeerGetItemCount(handle, out count).ThrowIfFailed();
					if (count > 0)
						PeerGetNextItem(handle, ref count, out data).ThrowIfFailed();
					else
						data = new SafePeerData();
				}
				return data;
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for data that is disposed using <see cref="PeerFreeData"/>.</summary>
		public class SafePeerData : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafePeerData"/> class.</summary>
			protected internal SafePeerData() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { PeerFreeData(handle); return true; }
		}

		internal class PeerStringMarshaler : ICustomMarshaler
		{
			internal PeerStringMarshaler()
			{
			}

			public static ICustomMarshaler GetInstance(string _) => new PeerStringMarshaler();

			/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
			/// <param name="ManagedObj">The managed object to be destroyed.</param>
			public void CleanUpManagedData(object ManagedObj) { }

			/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
			/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
			public void CleanUpNativeData(IntPtr pNativeData) => PeerFreeData(pNativeData);

			/// <summary>Returns the size of the native data to be marshaled.</summary>
			/// <returns>The size in bytes of the native data.</returns>
			public int GetNativeDataSize() => -1;

			/// <summary>Converts the managed data to unmanaged data.</summary>
			/// <param name="ManagedObj">The managed object to be converted.</param>
			/// <returns>Returns the COM view of the managed object.</returns>
			public IntPtr MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

			/// <summary>Converts the unmanaged data to managed data.</summary>
			/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
			/// <returns>Returns the managed view of the COM data.</returns>
			public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.PtrToStringUni(pNativeData);
		}

		internal class PeerStructMarshaler<T> : ICustomMarshaler where T : struct
		{
			internal PeerStructMarshaler()
			{
			}

			public static ICustomMarshaler GetInstance(string _) => new PeerStructMarshaler<T>();

			/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
			/// <param name="ManagedObj">The managed object to be destroyed.</param>
			public void CleanUpManagedData(object ManagedObj) { }

			/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
			/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
			public void CleanUpNativeData(IntPtr pNativeData) => PeerFreeData(pNativeData);

			/// <summary>Returns the size of the native data to be marshaled.</summary>
			/// <returns>The size in bytes of the native data.</returns>
			public int GetNativeDataSize() => -1;

			/// <summary>Converts the managed data to unmanaged data.</summary>
			/// <param name="ManagedObj">The managed object to be converted.</param>
			/// <returns>Returns the COM view of the managed object.</returns>
			public IntPtr MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

			/// <summary>Converts the unmanaged data to managed data.</summary>
			/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
			/// <returns>Returns the managed view of the COM data.</returns>
			public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.PtrToStructure(pNativeData, typeof(T));
		}

		/*
PeerGraphAddRecord
PeerGraphClose
PeerGraphCloseDirectConnection
PeerGraphConnect
PeerGraphCreate
PeerGraphDelete
PeerGraphDeleteRecord
PeerGraphEndEnumeration
PeerGraphEnumConnections
PeerGraphEnumNodes
PeerGraphEnumRecords
PeerGraphExportDatabase
PeerGraphFreeData
PeerGraphGetEventData
PeerGraphGetItemCount
PeerGraphGetNextItem
PeerGraphGetNodeInfo
PeerGraphGetProperties
PeerGraphGetRecord
PeerGraphGetStatus
PeerGraphImportDatabase
PeerGraphListen
PeerGraphOpen
PeerGraphOpenDirectConnection
PeerGraphPeerTimeToUniversalTime
PeerGraphRegisterEvent
PeerGraphSearchRecords
PeerGraphSendData
PeerGraphSetNodeAttributes
PeerGraphSetPresence
PeerGraphSetProperties
PeerGraphUniversalTimeToPeerTime
PeerGraphUnregisterEvent
PeerGraphUpdateRecord
PeerGraphValidateDeferredRecords
*/
	}
}