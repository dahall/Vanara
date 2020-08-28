using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Crypt32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Items from the P2P.dll</summary>
	public static partial class P2P
	{
		/// <summary>
		/// The <c>PeerGroupAddRecord</c> function adds a new record to the peer group, which is propagated to all participating peers.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin function. This
		/// parameter is required.
		/// </param>
		/// <param name="pRecord">
		/// <para>Pointer to a PEER_RECORD structure that is added to the peer group specified in hGroup. This parameter is required.</para>
		/// <para>The following members in PEER_RECORD must be populated.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>dwSize</c></term>
		/// </item>
		/// <item>
		/// <term><c>type</c></term>
		/// </item>
		/// <item>
		/// <term><c>ftExpiration</c></term>
		/// </item>
		/// </list>
		/// <para>ftExpiration</para>
		/// <para>must be expressed as peer time (see</para>
		/// <para>PeerGroupUniversalTimeToPeerTime</para>
		/// <para>).</para>
		/// <para>The following members are ignored and overwritten if populated.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>id</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzCreatorId</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzLastModifiedById</c></term>
		/// </item>
		/// <item>
		/// <term><c>ftCreation</c></term>
		/// </item>
		/// <item>
		/// <term><c>ftLastModified</c></term>
		/// </item>
		/// <item>
		/// <term><c>securityData</c></term>
		/// </item>
		/// </list>
		/// <para>The remaining fields are optional.</para>
		/// </param>
		/// <param name="pRecordId">Pointer to a GUID that identifies the record. This parameter is required.</param>
		/// <returns>
		/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where records can be added. For example, PeerGroupJoin is called, but synchronization with the
		/// peer group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_ATTRIBUTES</term>
		/// <term>
		/// The XML string that contains the record attributes in the pwzAttributes member of the PEER_RECORD structure does not comply with
		/// the schema specification.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_PEER_NAME</term>
		/// <term>The supplied peer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_RECORD</term>
		/// <term>One or more fields in PEER_RECORD are invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_MAX_RECORD_SIZE_EXCEEDED</term>
		/// <term>The record has exceeded the maximum size allowed by the peer group properties.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>The identity is not authorized to publish a record of that type.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupaddrecord NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupAddRecord( HGROUP hGroup, PPEER_RECORD pRecord, GUID *pRecordId );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupAddRecord")]
		public static extern HRESULT PeerGroupAddRecord(HGROUP hGroup, in PEER_RECORD pRecord, out Guid pRecordId);

		/// <summary>
		/// The <c>PeerGroupClose</c> function invalidates the peer group handle obtained by a previous call to the PeerGroupCreate,
		/// PeerGroupJoin, or PeerGroupOpen function.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group to close. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin function.
		/// This parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If the peer group handle closed is the last handle that refers to a peer group shared across multiple applications or processes,
		/// the call also closes the respective network connections for the peer.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupclose NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerGroupClose(
		// HGROUP hGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupClose")]
		public static extern HRESULT PeerGroupClose(HGROUP hGroup);

		/// <summary>The <c>PeerGroupCloseDirectConnection</c> function closes a specific direct connection between two peers.</summary>
		/// <param name="hGroup">
		/// Handle to the peer group that contains the peers involved in the direct connection. This handle is returned by the
		/// PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="ullConnectionId">
		/// Specifies the connection ID to disconnect from. This parameter is required and has no default value.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_CONNECTION_NOT_FOUND</term>
		/// <term>A direct connection that matches the supplied connection ID cannot be found.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupclosedirectconnection NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupCloseDirectConnection( HGROUP hGroup, ULONGLONG ullConnectionId );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupCloseDirectConnection")]
		public static extern HRESULT PeerGroupCloseDirectConnection(HGROUP hGroup, ulong ullConnectionId);

		/// <summary>
		/// The <c>PeerGroupConnect</c> function initiates a PNRP search for a peer group and attempts to connect to it. After this function
		/// is called successfully, a peer can communicate with other members of the peer group.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group to which a peer intends to connect. This handle is returned by the PeerGroupCreate,
		/// PeerGroupOpen,PeerGroupJoin, or PeerGroupPasswordJoin function. This parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application registers for peer events before calling this function. If the function call is unsuccessful, a
		/// PEER_GROUP_EVENT_CONNECTION_FAILED event is raised. Otherwise, a PEER_GROUP_EVENT_STATUS_CHANGED event is raised.
		/// </para>
		/// <para>
		/// The PEER_GROUP_EVENT_CONNECTION_FAILED event is also raised when a group creator fails to call <c>PeerGroupConnect</c>
		/// immediately after creation. If this does not take place, users given an invitation will call <c>PeerGroupConnect</c>
		/// successfully but they will not be able to listen and will eventually receive the connection failed event.
		/// </para>
		/// <para>
		/// In the event of a clock skew between participating machines, the success of <c>PeerGroupConnect</c> may depend on the severity
		/// of the skew. When troubleshooting a failure to join, this possibility should be taken into consideration by verifying that the
		/// machine clocks are synchronized.
		/// </para>
		/// <para>To be present in the peer group and receive events but remain unconnected, use the PeerGroupOpen function.</para>
		/// <para>
		/// If a time-out value for <c>PeerGroupConnect</c> is not provided in the application, encountering a failure will cause the
		/// application to hang. A time-out value of 30 seconds is recommended.
		/// </para>
		/// <para>
		/// Prior to calling <c>PeerGroupConnect</c>, a group exists in a ' <c>Disconnected State</c>'. During this time the group cannot be
		/// detected or receive connections. In order to return a group to this state, the PeerGroupClose function must be called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupconnect NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupConnect( HGROUP hGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupConnect")]
		public static extern HRESULT PeerGroupConnect(HGROUP hGroup);

		/// <summary>
		/// The <c>PeerGroupConnectByAddress</c> function attempts to connect to the peer group that other peers with known IPv6 addresses
		/// are participating in. After this function is called successfully, a peer can communicate with other members of the peer group.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group to which a peer intends to connect. This handle is returned by the PeerGroupCreate,
		/// PeerGroupOpen,PeerGroupJoin, or PeerGroupPasswordJoin function. This parameter is required.
		/// </param>
		/// <param name="cAddresses">The total number of PEER_ADDRESS structures pointed to by pAddresses.</param>
		/// <param name="pAddresses">
		/// Pointer to a list of PEER_ADDRESS structures that specify the endpoints of peers participating in the group.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors may be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If a time-out value for PeerGroupConnectByAddress is not provided in the application, encountering a failure will cause the
		/// application to hang. A time-out value of 30 seconds is recommended.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupconnectbyaddress NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupConnectByAddress( HGROUP hGroup, ULONG cAddresses, PPEER_ADDRESS pAddresses );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupConnectByAddress")]
		public static extern HRESULT PeerGroupConnectByAddress(HGROUP hGroup, uint cAddresses, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PEER_ADDRESS[] pAddresses);

		/// <summary>The <c>PeerGroupCreate</c> function creates a new peer group.</summary>
		/// <param name="pProperties">
		/// <para>
		/// Pointer to a PEER_GROUP_PROPERTIES structure that specifies the specific details of the group, such as the peer group names,
		/// invitation lifetimes, and presence lifetimes. This parameter is required.
		/// </para>
		/// <para>The following members must be set:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwzCreatorPeerName</c></term>
		/// </item>
		/// </list>
		/// <para>The following members cannot be set:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwzGroupPeerName</c></term>
		/// </item>
		/// </list>
		/// <para>The remaining members are optional.</para>
		/// </param>
		/// <param name="phGroup">
		/// Returns the handle pointer to the peer group. Any function called with this handle as a parameter has the corresponding action
		/// performed on that peer group. This parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_CLOUD_NAME_AMBIGUOUS</term>
		/// <term>The cloud specified in pProperties cannot be uniquely discovered (more than one cloud matches the provided name).</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_CLASSIFIER</term>
		/// <term>The peer group classifier specified in pProperties is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_PEER_NAME</term>
		/// <term>The peer name specified for the group in pProperties is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_PROPERTIES</term>
		/// <term>One or more of the peer group properties supplied in pProperties is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_CLOUD</term>
		/// <term>The cloud specified in pProperties cannot be located.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL is reset manually.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_PASSWORD_DOES_NOT_MEET_POLICY</term>
		/// <term>Password specified does not meet system password requirements.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_DELETE_PENDING</term>
		/// <term>The peer identity specified as the Group Creator has been deleted or is in the process of being deleted.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// PeerGroupConnect must be called by the group creator immediately after creation. If this does not take place, users given an
		/// invitation will call PeerGroupConnect successfully but they will not be able to listen and will eventually receive the
		/// connection failed event.
		/// </para>
		/// <para>
		/// An application obtains an identity by calling PeerIdentityCreate, or any other method that returns an identity name string. This
		/// identity serves as the owner of the group, and is the initial member of the peer group when created.
		/// </para>
		/// <para>
		/// For applications that utilize passwords, it is recommended the passwords are handled securely by calling the CryptoProtectMemory
		/// and SecureZeroMemory functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupcreate NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupCreate( PPEER_GROUP_PROPERTIES pProperties, HGROUP *phGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupCreate")]
		public static extern HRESULT PeerGroupCreate(in PEER_GROUP_PROPERTIES pProperties, out HGROUP phGroup);

		/// <summary>
		/// The <c>PeerGroupCreateInvitation</c> function returns an XML string that can be used by the specified peer to join a group.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group for which this invitation is issued. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzIdentityInfo">
		/// Pointer to a Unicode string that contains the XML blob (including the GMC) returned by a previous call to PeerIdentityGetXML
		/// with the identity of the peer. Alternatively, this parameter can contain a pointer to an XML blob generated by
		/// <c>PeerIdentityGetXML</c> using the peer information contained in PEER_CONTACT to generate an invitation for a peer contact.
		/// </param>
		/// <param name="pftExpiration">
		/// Specifies a UTC FILETIME structure that contains the specific date and time the invitation expires. This value cannot be greater
		/// than the remaining lifetime of the issuing peer. If this parameter is <c>NULL</c>, the invitation lifetime is set to the maximum
		/// value possible - the remaining lifetime of the peer.
		/// </param>
		/// <param name="cRoles">Specifies the count of roles in pRoleInfo.</param>
		/// <param name="pRoles">
		/// <para>Pointer to a list of GUIDs that specifies the combined set of available roles. The available roles are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GROUP_ROLE_ADMIN</term>
		/// <term>
		/// This role can issue invitations, issue credentials, and renew the GMC of other administrators, as well as behave as a member of
		/// the peer group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_GROUP_ROLE_MEMBER</term>
		/// <term>This role can publish records to the group database.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppwzInvitation">
		/// Pointer to a Unicode string that contains the invitation from the issuer. This invitation can be passed to PeerGroupJoin by the
		/// recipient in order to join the specified peer group. To return the details of the invitation as a PEER_INVITATION_INFO
		/// structure, pass this string to PeerGroupParseInvitation. To release this data, pass this pointer to PeerFreeData.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds; otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where records can be added. For example, PeerGroupJoin is called, but synchronization with the
		/// group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CHAIN_TOO_LONG</term>
		/// <term>
		/// The GMC chain is longer than 24 administrators or members. For more information about GMC chains, please refer to the How Group
		/// Security Works documentation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_DELETED</term>
		/// <term>The data passed as pwzIdentityInfo is for a deleted identity and no longer valid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>The peer that called this method is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL is reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Peers cannot create invitations for peers whose assumed role is superior to their own. For example, a peer in a member role
		/// cannot create an invitation for a peer in an administrator role.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupcreateinvitation NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupCreateInvitation( HGROUP hGroup, PCWSTR pwzIdentityInfo, FILETIME *pftExpiration, ULONG cRoles, const GUID *pRoles,
		// PWSTR *ppwzInvitation );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupCreateInvitation")]
		public static extern HRESULT PeerGroupCreateInvitation(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzIdentityInfo, in FILETIME pftExpiration,
			uint cRoles, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] pRoles,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzInvitation);

		/// <summary>
		/// The <c>PeerGroupCreateInvitation</c> function returns an XML string that can be used by the specified peer to join a group.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group for which this invitation is issued. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzIdentityInfo">
		/// Pointer to a Unicode string that contains the XML blob (including the GMC) returned by a previous call to PeerIdentityGetXML
		/// with the identity of the peer. Alternatively, this parameter can contain a pointer to an XML blob generated by
		/// <c>PeerIdentityGetXML</c> using the peer information contained in PEER_CONTACT to generate an invitation for a peer contact.
		/// </param>
		/// <param name="pftExpiration">
		/// Specifies a UTC FILETIME structure that contains the specific date and time the invitation expires. This value cannot be greater
		/// than the remaining lifetime of the issuing peer. If this parameter is <c>NULL</c>, the invitation lifetime is set to the maximum
		/// value possible - the remaining lifetime of the peer.
		/// </param>
		/// <param name="cRoles">Specifies the count of roles in pRoleInfo.</param>
		/// <param name="pRoles">
		/// <para>Pointer to a list of GUIDs that specifies the combined set of available roles. The available roles are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GROUP_ROLE_ADMIN</term>
		/// <term>
		/// This role can issue invitations, issue credentials, and renew the GMC of other administrators, as well as behave as a member of
		/// the peer group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_GROUP_ROLE_MEMBER</term>
		/// <term>This role can publish records to the group database.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppwzInvitation">
		/// Pointer to a Unicode string that contains the invitation from the issuer. This invitation can be passed to PeerGroupJoin by the
		/// recipient in order to join the specified peer group. To return the details of the invitation as a PEER_INVITATION_INFO
		/// structure, pass this string to PeerGroupParseInvitation. To release this data, pass this pointer to PeerFreeData.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds; otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where records can be added. For example, PeerGroupJoin is called, but synchronization with the
		/// group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CHAIN_TOO_LONG</term>
		/// <term>
		/// The GMC chain is longer than 24 administrators or members. For more information about GMC chains, please refer to the How Group
		/// Security Works documentation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_DELETED</term>
		/// <term>The data passed as pwzIdentityInfo is for a deleted identity and no longer valid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>The peer that called this method is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL is reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Peers cannot create invitations for peers whose assumed role is superior to their own. For example, a peer in a member role
		/// cannot create an invitation for a peer in an administrator role.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupcreateinvitation NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupCreateInvitation( HGROUP hGroup, PCWSTR pwzIdentityInfo, FILETIME *pftExpiration, ULONG cRoles, const GUID *pRoles,
		// PWSTR *ppwzInvitation );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupCreateInvitation")]
		public static extern HRESULT PeerGroupCreateInvitation(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzIdentityInfo, [In, Optional] IntPtr pftExpiration,
			uint cRoles, [In, MarshalAs(UnmanagedType.LPArray)] Guid[] pRoles,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzInvitation);

		/// <summary>
		/// The <c>PeerGroupCreatePasswordInvitation</c> function returns an XML string that can be used by the specified peer to join a
		/// group with a matching password.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group for which this invitation is issued. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="ppwzInvitation">
		/// <para>
		/// Pointer to a Unicode string that contains the invitation from the issuer. This invitation can be passed to PeerGroupPasswordJoin
		/// by the recipient in order to join the specified peer group. To return the details of the invitation as a PEER_INVITATION_INFO
		/// structure, pass this string to PeerGroupParseInvitation. To release this data, pass this pointer to PeerFreeData.
		/// </para>
		/// <para>This function requires that the following fields are set on the</para>
		/// <para>PEER_GROUP_PROPERTIES</para>
		/// <para>structure passed to</para>
		/// <para>PeerGroupCreate</para>
		/// <para>.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwzGroupPassword</c>. This field must contain the password used to validate peers joining the peer group.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>groupPasswordRole</c>. This field must containing the GUID of the role (administrator or peer) for which the password is required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>dwAuthenticationSchemes</c>. This field must have the <c>PEER_GROUP_PASSWORD_AUTHENTICATION</c> flag (0x00000001) set on it.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds; otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where records can be added. For example, PeerGroupJoin is called, but synchronization with the
		/// group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CHAIN_TOO_LONG</term>
		/// <term>
		/// The GMC chain is longer than 24 administrators or members. For more information about GMC chains, please refer to the How Group
		/// Security Works documentation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_DELETED</term>
		/// <term>The data passed as pwzIdentityInfo is for a deleted identity and no longer valid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>The peer that called this method is not an administrator.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL is reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors may be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupcreatepasswordinvitation NOT_BUILD_WINDOWS_DEPRECATE
		// HRESULT PeerGroupCreatePasswordInvitation( HGROUP hGroup, PWSTR *ppwzInvitation );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupCreatePasswordInvitation")]
		public static extern HRESULT PeerGroupCreatePasswordInvitation(HGROUP hGroup,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzInvitation);

		/// <summary>The <c>PeerGroupDelete</c> function deletes the local data and certificate associated with a peer group.</summary>
		/// <param name="pwzIdentity">
		/// Pointer to a Unicode string that contains the identity opening the specified peer group. If this parameter is <c>NULL</c>, the
		/// implementation uses the identity obtained from PeerIdentityGetDefault.
		/// </param>
		/// <param name="pwzGroupPeerName">
		/// Pointer to a Unicode string that contains the peer name of the peer group for which data is deleted. This parameter is required.
		/// The group name can be obtained by calling PeerGroupGetProperties prior to PeerGroupClose, or by parsing the invitation with PeerGroupParseInvitation.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <para><c>Note</c> If a delete operation fails due to a file system error, the appropriate file system error is returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED</term>
		/// <term>
		/// Access to the peer group database is denied. Ensure that the peer has permission to perform this operation. In this case, the
		/// peer must be the original creator of the peer group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_FOUND</term>
		/// <term>The peer group cannot be found.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL is reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// If a peer group is deleted, all handles associated with that group immediately become invalid. As a best practice, ensure that
		/// all handles for this group are closed before calling this function. Otherwise, this data is deleted from all other running peer
		/// applications that use it, which can cause errors and instability.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupdelete NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupDelete( PCWSTR pwzIdentity, PCWSTR pwzGroupPeerName );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupDelete")]
		public static extern HRESULT PeerGroupDelete([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pwzGroupPeerName);

		/// <summary>
		/// The <c>PeerGroupDeleteRecord</c> function deletes a record from a peer group. The creator, as well as any other member in an
		/// administrative role may delete a specific record.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group that contains the record. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pRecordId">Specifies the GUID value that uniquely identifies the record to be deleted. This parameter is required.</param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where records can be deleted. For example, PeerGroupJoin is called, but synchronization with
		/// the peer group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>
		/// The current identity does not have the authorization to delete the record. In this case, the identity is not the creator or a
		/// member in an administrative role may delete a specific record.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_RECORD_NOT_FOUND</term>
		/// <term>The record cannot be located in the data store.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupdeleterecord NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupDeleteRecord( HGROUP hGroup, const GUID *pRecordId );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupDeleteRecord")]
		public static extern HRESULT PeerGroupDeleteRecord(HGROUP hGroup, in Guid pRecordId);

		/// <summary>The <c>PeerGroupEnumConnections</c> function creates an enumeration of connections currently active on the peer.</summary>
		/// <param name="hGroup">
		/// Handle to the group that contains the connections to be enumerated. This handle is returned by the PeerGroupCreate,
		/// PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="dwFlags">
		/// Specifies the flags that indicate the type of connection to enumerate. Valid values are specified by PEER_CONNECTION_FLAGS.
		/// </param>
		/// <param name="phPeerEnum">
		/// Pointer to the enumeration that contains the returned list of active connections. This handle is passed to PeerGetNextItem to
		/// retrieve the items, with each item represented as a pointer to a PEER_CONNECTION_INFO structure. When finished,
		/// PeerEndEnumeration is called to return the memory used by the enumeration. This parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupenumconnections NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupEnumConnections( HGROUP hGroup, DWORD dwFlags, HPEERENUM *phPeerEnum );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupEnumConnections")]
		public static extern HRESULT PeerGroupEnumConnections(HGROUP hGroup, PEER_CONNECTION_FLAGS dwFlags, out SafeHPEERENUM<PEER_CONNECTION_INFO> phPeerEnum);

		/// <summary>
		/// The <c>PeerGroupEnumMembers</c> function creates an enumeration of available peer group members and the associated membership information.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group whose members are enumerated. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the PEER_MEMBER_FLAGS flags that indicate which types of members to include in the enumeration. If this value is set
		/// to zero, all members of the peer group are included.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_MEMBER_PRESENT</term>
		/// <term>Enumerate all members of the current peer group that are online.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwzIdentity">
		/// Unicode string that contains the identity of a specific peer whose information is retrieved and returned in a one-item
		/// enumeration. If this parameter is <c>NULL</c>, all members of the current peer group are retrieved. This parameter is required.
		/// </param>
		/// <param name="phPeerEnum">
		/// Pointer to the enumeration that contains the returned list of peer group members. This handle is passed to PeerGetNextItem to
		/// retrieve the items, with each item represented as a pointer to a PEER_MEMBER structure. When finished, PeerEndEnumeration is
		/// called to return the memory used by the enumeration. This parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The local node is always the very first item in the enumeration if pwzIdentity is <c>NULL</c>, and dwFlags is set to indicate
		/// that the local node is a member of the explicit subset.
		/// </para>
		/// <para>
		/// By default, every member publishes membership information to the peer group. If PEER_MEMBER_DATA_OPTIONAL is set on the
		/// PEER_MEMBER data for that peer, this information is only available when a peer performs an action within the group, for example,
		/// publishing a record, updating presence, or issuing a GMC.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupenummembers NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupEnumMembers( HGROUP hGroup, DWORD dwFlags, PCWSTR pwzIdentity, HPEERENUM *phPeerEnum );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupEnumMembers")]
		public static extern HRESULT PeerGroupEnumMembers(HGROUP hGroup, PEER_MEMBER_FLAGS dwFlags, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, out SafeHPEERENUM<PEER_MEMBER> phPeerEnum);

		/// <summary>The <c>PeerGroupEnumRecords</c> function creates an enumeration of peer group records.</summary>
		/// <param name="hGroup">
		/// Handle to the peer group whose records are enumerated. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pRecordType">
		/// Pointer to a <c>GUID</c> value that uniquely identifies a specific record type. If this parameter is <c>NULL</c>, all records
		/// are returned.
		/// </param>
		/// <param name="phPeerEnum">
		/// Pointer to the enumeration that contains the returned list of records. This handle is passed to PeerGetNextItem to retrieve the
		/// items, with each item represented as a pointer to a PEER_RECORD structure. When finished, PeerEndEnumeration is called to return
		/// the memory used by the enumeration. This parameter is required.
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
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupenumrecords NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupEnumRecords( HGROUP hGroup, const GUID *pRecordType, HPEERENUM *phPeerEnum );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupEnumRecords")]
		public static extern HRESULT PeerGroupEnumRecords(HGROUP hGroup, in Guid pRecordType, out SafeHPEERENUM<PEER_RECORD> phPeerEnum);

		/// <summary>
		/// The <c>PeerGroupExportConfig</c> function exports the group configuration for a peer as an XML string that contains the
		/// identity, group name, and the GMC for the identity.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the group. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzPassword">
		/// Specifies the password used to protect the exported configuration. There are no rules or limits for the formation of this
		/// password. This parameter is required.
		/// </param>
		/// <param name="ppwzXML">
		/// Pointer to the returned XML configuration string that contains the identity, group peer name, cloud peer name, group scope, and
		/// the GMC for the identity. This parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the function succeeds. Otherwise, the function returns one of the following values.</para>
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
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL is reset manually .
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft Base Cryptographic Provider. These errors are prefixed with
		/// CRYPT_* and defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After being exported, this configuration can be passed out-of-band to another peer, where the configuration of the identity can
		/// be established. To import the configuration, pass the XML string returned by this function with the password set on it to PeerGroupImportConfig.
		/// </para>
		/// <para>The configuration XML string appears in the following format:</para>
		/// <para>
		/// <code>&lt;PEERGROUPCONFIG VERSION="1.0"&gt; &lt;IDENTITYPEERNAME&gt; &lt;!-- UTF-8 encoded peer name of the identity --&gt; &lt;/IDENTITYPEERNAME&gt; &lt;GROUPPEERNAME&gt; &lt;!-- UTF-8 encoded peer name of the group --&gt; &lt;/GROUPPEERNAME&gt; &lt;CLOUDNAME&gt; &lt;!-- UTF-8 encoded Unicode name of the cloud --&gt; &lt;/CLOUDNAME&gt; &lt;SCOPE&gt; &lt;!-- UTF-8 encoded Unicode name of the scope: global, site-local, link-local --&gt; &lt;/SCOPE&gt; &lt;CLOUDFLAGS&gt; &lt;!-- A DWORD containing cloud-specific settings, represented as a string --&gt; &lt;/CLOUDFLAGS&gt; &lt;GMC xmlns:dt="urn:schemas-microsoft-com:datatypes" dt:dt="bin.base64"&gt; &lt;!-- base64/PKCS7 encoded GMC chain --&gt; &lt;/GMC&gt; &lt;/PEERGROUPCONFIG&gt;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupexportconfig NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupExportConfig( HGROUP hGroup, PCWSTR pwzPassword, PWSTR *ppwzXML );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupExportConfig")]
		public static extern HRESULT PeerGroupExportConfig(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzPassword,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzXML);

		/// <summary>
		/// The <c>PeerGroupExportDatabase</c> function exports a peer group database to a specific file, which can be transported to
		/// another computer and imported with the PeerGroupImportDatabase function.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group whose database is exported to a local file on the peer. This handle is returned by the PeerGroupCreate,
		/// PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzFilePath">
		/// Pointer to a Unicode string that contains the absolute file system path and file name where the exported database is stored. For
		/// example, "C:\backup\p2pdb.db". If this file already exists at the specified location, the older file is overwritten. This
		/// parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns S_OK if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <para>
		/// <c>Note</c> If an export fails due to a file system error, the appropriate file system error, defined in winerror.h, is returned.
		/// </para>
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
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupexportdatabase NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupExportDatabase( HGROUP hGroup, PCWSTR pwzFilePath );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupExportDatabase")]
		public static extern HRESULT PeerGroupExportDatabase(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath);

		/// <summary>The <c>PeerGroupGetEventData</c> function allows an application to retrieve the data returned by a grouping event.</summary>
		/// <param name="hPeerEvent">Handle obtained from a previous call to PeerGroupRegisterEvent. This parameter is required.</param>
		/// <param name="ppEventData">
		/// Pointer to a PEER_GROUP_EVENT_DATA structure that contains data about the peer event. This data structure must be freed after
		/// use with PeerFreeData. This parameter is required.
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
		/// <term>PEER_S_NO_EVENT_DATA</term>
		/// <term>The call is successful, but there is no event data available.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When an event occurs for which a peer has requested notification, the corresponding peer event handle is signaled. The peer
		/// calls this method until PEER_GROUP_EVENT_DATA structures are retrieved. Each data structure contains the following two key
		/// pieces of data:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The registration associated with a peer event.</term>
		/// </item>
		/// <item>
		/// <term>The actual data for a peer event.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupgeteventdata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupGetEventData( HPEEREVENT hPeerEvent, PPEER_GROUP_EVENT_DATA *ppEventData );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupGetEventData")]
		public static extern HRESULT PeerGroupGetEventData(HPEEREVENT hPeerEvent,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_GROUP_EVENT_DATA>))] out PEER_GROUP_EVENT_DATA ppEventData);

		/// <summary>The <c>PeerGroupGetProperties</c> function retrieves information on the properties of a specified group.</summary>
		/// <param name="hGroup">
		/// Handle to a peer group whose properties are retrieved. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="ppProperties">
		/// Pointer to a PEER_GROUP_PROPERTIES structure that contains information about peer group properties. This data must be freed with
		/// PeerFreeData. This parameter is required.
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
		/// <item>
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The group is not in a state where peer group properties can be retrieved. For example, PeerGroupJoin is called, but
		/// synchronization with the group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Group properties cannot be retrieved if a peer has not synchronized with a peer group database. To synchronize with a peer group
		/// database before calling this function, first call PeerGroupConnect.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupgetproperties NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupGetProperties( HGROUP hGroup, PPEER_GROUP_PROPERTIES *ppProperties );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupGetProperties")]
		public static extern HRESULT PeerGroupGetProperties(HGROUP hGroup,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_GROUP_PROPERTIES>))] out PEER_GROUP_PROPERTIES ppProperties);

		/// <summary>The <c>PeerGroupGetRecord</c> function retrieves a specific group record.</summary>
		/// <param name="hGroup">
		/// Handle to a group that contains a specific record. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pRecordId">
		/// Specifies the GUID value that uniquely identifies a required record within a peer group. This parameter is required.
		/// </param>
		/// <param name="ppRecord">
		/// Pointer to the address of a PEER_RECORD structure that contains a returned record. This structure is freed by passing its
		/// pointer to PeerFreeData. This parameter is required.
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
		/// <term>There is not enough memory to perform the specified operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where group records can be retrieved. For example, PeerGroupJoin is called, but synchronization
		/// with the peer group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to a peer group is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_RECORD_NOT_FOUND</term>
		/// <term>A record that matches the supplied ID cannot be found in a peer group database.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupgetrecord NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupGetRecord( HGROUP hGroup, const GUID *pRecordId, PPEER_RECORD *ppRecord );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupGetRecord")]
		public static extern HRESULT PeerGroupGetRecord(HGROUP hGroup, in Guid pRecordId,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_RECORD>))] out PEER_RECORD ppRecord);

		/// <summary>The <c>PeerGroupGetStatus</c> function retrieves the current status of a group.</summary>
		/// <param name="hGroup">
		/// Handle to a peer group whose status is returned. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin
		/// function. This parameter is required.
		/// </param>
		/// <param name="pdwStatus">Pointer to a set of PEER_GROUP_STATUS flags that describe the status of a peer group.</param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory available to complete an operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to a group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupgetstatus NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupGetStatus( HGROUP hGroup, DWORD *pdwStatus );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupGetStatus")]
		public static extern HRESULT PeerGroupGetStatus(HGROUP hGroup, out PEER_GROUP_STATUS pdwStatus);

		/// <summary>
		/// The <c>PeerGroupImportConfig</c> function imports a peer group configuration for an identity based on the specific settings in a
		/// supplied XML configuration string.
		/// </summary>
		/// <param name="pwzXML">
		/// Specifies a Unicode string that contains a previously exported (using PeerGroupExportConfig) peer group configuration. For the
		/// specific XML format of the string, see to the Remarks section of this topic. This parameter is required.
		/// </param>
		/// <param name="pwzPassword">
		/// Specifies the password used to access the encrypted peer group configuration data, as a Unicode string. This parameter is required.
		/// </param>
		/// <param name="fOverwrite">
		/// If true, the existing group configuration is overwritten. If false, the group configuration is written only if a previous group
		/// configuration does not exist. The default value is false. This parameter is required.
		/// </param>
		/// <param name="ppwzIdentity">Contains the peer identity returned after an import completes. This parameter is required.</param>
		/// <param name="ppwzGroup">Contains a peer group peer name returned after an import completes. This parameter is required.</param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the function succeeds. Otherwise, the function returns one of the following values.</para>
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
		/// <item>
		/// <term>PEER_E_ALREADY_EXISTS</term>
		/// <term>A peer group configuration already exists, and fOverwrite is set to false.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To generate a peer group configuration, call PeerGroupExportConfig, pass in an identity to export, a password, and a handle to
		/// the peer group.
		/// </para>
		/// <para>The configuration XML string appears in the following format:</para>
		/// <para>
		/// <code>&lt;PEERGROUPCONFIG VERSION="1.0"&gt; &lt;IDENTITYPEERNAME&gt; &lt;!-- UTF-8 encoded peer name of the identity --&gt; &lt;/IDENTITYPEERNAME&gt; &lt;GROUPPEERNAME&gt; &lt;!-- UTF-8 encoded peer name of the peer group --&gt; &lt;/GROUPPEERNAME&gt; &lt;CLOUDNAME&gt; &lt;!-- UTF-8 encoded Unicode name of the cloud --&gt; &lt;/CLOUDNAME&gt; &lt;SCOPE&gt; &lt;!-- UTF-8 encoded Unicode name of the scope: global, site-local, link-local --&gt; &lt;/SCOPE&gt; &lt;CLOUDFLAGS&gt; &lt;!-- A DWORD that contains cloud-specific settings, represented as a string --&gt; &lt;/CLOUDFLAGS&gt; &lt;GMC xmlns:dt="urn:schemas-microsoft-com:datatypes" dt:dt="bin.base64"&gt; &lt;!-- base64/PKCS7 encoded GMC chain --&gt; &lt;/GMC&gt; &lt;/PEERGROUPCONFIG&gt;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupimportconfig NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupImportConfig( PCWSTR pwzXML, PCWSTR pwzPassword, BOOL fOverwrite, PWSTR *ppwzIdentity, PWSTR *ppwzGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupImportConfig")]
		public static extern HRESULT PeerGroupImportConfig([MarshalAs(UnmanagedType.LPWStr)] string pwzXML, [MarshalAs(UnmanagedType.LPWStr)] string pwzPassword,
			[MarshalAs(UnmanagedType.Bool)] bool fOverwrite,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzIdentity,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzGroup);

		/// <summary>The <c>PeerGroupImportDatabase</c> function imports a peer group database from a local file.</summary>
		/// <param name="hGroup">
		/// Handle to a peer group whose database is imported from a local file. This handle is returned by the PeerGroupCreate,
		/// PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzFilePath">
		/// Pointer to a Unicode string that contains the absolute file system path and file name where the data is stored, for example,
		/// "C:\backup\p2pdb.db". If the file does not exist at this location, an appropriate error from the file system is returned. This
		/// parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <para><c>Note</c> If an import fails due to a file system error, the appropriate file system error is returned.</para>
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
		/// <term>PEER_E_GROUP_IN_USE</term>
		/// <term>
		/// The operation cannot be completed because the peer group database is currently in use. For example, PeerGroupConnect has been
		/// called by a peer, but has not yet completed any database transactions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>This function must be called before PeerGroupConnect, and after PeerGroupOpen or PeerGroupJoin.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupimportdatabase NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupImportDatabase( HGROUP hGroup, PCWSTR pwzFilePath );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupImportDatabase")]
		public static extern HRESULT PeerGroupImportDatabase(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzFilePath);

		/// <summary>
		/// The <c>PeerGroupIssueCredentials</c> function issues credentials, including a GMC, to a specific identity, and optionally
		/// returns an invitation XML string the invited peer can use to join a peer group.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to a peer group for which a peer will issue credentials to potential invited peers. This handle is returned by the
		/// PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzSubjectIdentity">Specifies the identity of a peer to whom credentials will be issued. This parameter is required.</param>
		/// <param name="pCredentialInfo">
		/// <para>
		/// PEER_CREDENTIAL_INFO structure that contains information about the credentials of a peer whose identity is specified in
		/// pwzSubjectIdentity. If this parameter is <c>NULL</c>, the information stored in the peer database is used, instead. This
		/// parameter is optional.
		/// </para>
		/// <para>If this parameter is provided, the following fields in</para>
		/// <para>PEER_CREDENTIAL_INFO</para>
		/// <para>are ignored:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwzIssuerPeerName</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzIssuerFriendlyName</c></term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies a set of flags used to describe actions taken when credentials are issued. If this parameter is set to 0 (zero), the
		/// credentials are returned in ppwzInvitation. This parameter is optional.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GROUP_STORE_CREDENTIALS</term>
		/// <term>
		/// Publish the subject identity's newly-created GMC in the group database. The GMC is picked up automatically by the subject. If
		/// this flag is not set, the credentials must be obtained by a different application such as email.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppwzInvitation">
		/// Pointer to an invitation XML string returned by the function call. This invitation is passed out-of-band to the invited peer who
		/// uses it in a call to PeerGroupJoin. This parameter is optional.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_DELETED</term>
		/// <term>The identity creating the credentials has been deleted.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_NOT_FOUND</term>
		/// <term>The identity cannot be found in the group database, and pCredentialInfo is NULL.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This function can only be called successfully by an administrator.</para>
		/// <para>
		/// The credentials for a member (PEER_CREDENTIAL_INFO) are obtained by calling PeerGroupEnumMembers. The credentials are located in
		/// the <c>pCredentialInfo</c> field of the PEER_MEMBER structure for a specific member.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupissuecredentials NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupIssueCredentials( HGROUP hGroup, PCWSTR pwzSubjectIdentity, PEER_CREDENTIAL_INFO *pCredentialInfo, DWORD dwFlags, PWSTR
		// *ppwzInvitation );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupIssueCredentials")]
		public static extern HRESULT PeerGroupIssueCredentials(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzSubjectIdentity,
			in PEER_CREDENTIAL_INFO pCredentialInfo, PEER_GROUP_ISSUE_CREDENTIAL_FLAGS dwFlags,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzInvitation);

		/// <summary>
		/// The <c>PeerGroupIssueCredentials</c> function issues credentials, including a GMC, to a specific identity, and optionally
		/// returns an invitation XML string the invited peer can use to join a peer group.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to a peer group for which a peer will issue credentials to potential invited peers. This handle is returned by the
		/// PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzSubjectIdentity">Specifies the identity of a peer to whom credentials will be issued. This parameter is required.</param>
		/// <param name="pCredentialInfo">
		/// <para>
		/// PEER_CREDENTIAL_INFO structure that contains information about the credentials of a peer whose identity is specified in
		/// pwzSubjectIdentity. If this parameter is <c>NULL</c>, the information stored in the peer database is used, instead. This
		/// parameter is optional.
		/// </para>
		/// <para>If this parameter is provided, the following fields in</para>
		/// <para>PEER_CREDENTIAL_INFO</para>
		/// <para>are ignored:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwzIssuerPeerName</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzIssuerFriendlyName</c></term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies a set of flags used to describe actions taken when credentials are issued. If this parameter is set to 0 (zero), the
		/// credentials are returned in ppwzInvitation. This parameter is optional.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEER_GROUP_STORE_CREDENTIALS</term>
		/// <term>
		/// Publish the subject identity's newly-created GMC in the group database. The GMC is picked up automatically by the subject. If
		/// this flag is not set, the credentials must be obtained by a different application such as email.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="ppwzInvitation">
		/// Pointer to an invitation XML string returned by the function call. This invitation is passed out-of-band to the invited peer who
		/// uses it in a call to PeerGroupJoin. This parameter is optional.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_DELETED</term>
		/// <term>The identity creating the credentials has been deleted.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IDENTITY_NOT_FOUND</term>
		/// <term>The identity cannot be found in the group database, and pCredentialInfo is NULL.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the identity or group keys is denied. Typically, this is caused by an incorrect access control list (ACL) for the
		/// folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This function can only be called successfully by an administrator.</para>
		/// <para>
		/// The credentials for a member (PEER_CREDENTIAL_INFO) are obtained by calling PeerGroupEnumMembers. The credentials are located in
		/// the <c>pCredentialInfo</c> field of the PEER_MEMBER structure for a specific member.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupissuecredentials NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupIssueCredentials( HGROUP hGroup, PCWSTR pwzSubjectIdentity, PEER_CREDENTIAL_INFO *pCredentialInfo, DWORD dwFlags, PWSTR
		// *ppwzInvitation );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupIssueCredentials")]
		public static extern HRESULT PeerGroupIssueCredentials(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzSubjectIdentity,
			[In, Optional] IntPtr pCredentialInfo, PEER_GROUP_ISSUE_CREDENTIAL_FLAGS dwFlags, [In, Optional] IntPtr ppwzInvitation);

		/// <summary>
		/// The <c>PeerGroupJoin</c> function prepares a peer with an invitation to join an existing peer group prior to calling
		/// PeerGroupConnect or PeerGroupConnectByAddress.
		/// </summary>
		/// <param name="pwzIdentity">
		/// Pointer to a Unicode string that contains the identity opening the specified peer group. If this parameter is <c>NULL</c>, the
		/// implementation uses the identity obtained from PeerIdentityGetDefault.
		/// </param>
		/// <param name="pwzInvitation">
		/// Pointer to a Unicode string that contains the XML invitation granted by another peer. An invitation is created when the inviting
		/// peer calls PeerGroupCreateInvitation or PeerGroupIssueCredentials. Specific details regarding this invitation can be obtained as
		/// a PEER_INVITATION_INFO structure by calling PeerGroupParseInvitation. This parameter is required.
		/// </param>
		/// <param name="pwzCloud">
		/// Pointer to a Unicode string that contains the name of the PNRP cloud where a group is located. The default value is <c>NULL</c>,
		/// which indicates that the cloud specified in the invitation must be used.
		/// </param>
		/// <param name="phGroup">
		/// Pointer to the handle of the peer group. To start communication with a group, call PeerGroupConnect. This parameter is required.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CLOUD_NAME_AMBIGUOUS</term>
		/// <term>The cloud cannot be uniquely discovered, for example, more than one cloud matches the provided name.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_PEER_NAME</term>
		/// <term>The peer identity specified in pwzIdentity is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_TIME_PERIOD</term>
		/// <term>
		/// The validity period specified in the invitation is invalid. Either the specified period has expired or the invitation is not yet
		/// valid (i.e. the specified ValidityStart date\time has not yet been reached). One possible reason for the return of this error is
		/// that the system clock is incorrectly set on the machine joining the group, or on the machine that issued the invitation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVITATION_NOT_TRUSTED</term>
		/// <term>The invitation is not trusted. This may be due to invitation alteration, errors, or expiration.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_CLOUD</term>
		/// <term>The cloud cannot be located.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNSUPPORTED_VERSION</term>
		/// <term>The invitation is not supported by the current version of the Peer Infrastructure.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
		/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupjoin NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerGroupJoin(
		// PCWSTR pwzIdentity, PCWSTR pwzInvitation, PCWSTR pwzCloud, HGROUP *phGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupJoin")]
		public static extern HRESULT PeerGroupJoin([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pwzInvitation,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzCloud, out HGROUP phGroup);

		/// <summary>
		/// The <c>PeerGroupOpen</c> function opens a peer group that a peer has created or joined. After a peer group is opened, the peer
		/// can register for event notifications.
		/// </summary>
		/// <param name="pwzIdentity">
		/// Pointer to a Unicode string that contains the identity a peer uses to open a group. This parameter is required.
		/// </param>
		/// <param name="pwzGroupPeerName">
		/// Pointer to a Unicode string that contains the peer name of the peer group. This parameter is required.
		/// </param>
		/// <param name="pwzCloud">
		/// Pointer to a Unicode string that contains the name of the PNRP cloud in which the peer group is located. If the value is
		/// <c>NULL</c>, the cloud specified in the peer group properties is used.
		/// </param>
		/// <param name="phGroup">
		/// Pointer to a handle for a peer group. If this value is <c>NULL</c>, the open operation is unsuccessful. This parameter is required.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CLOUD_NAME_AMBIGUOUS</term>
		/// <term>The cloud specified in pwzCloud cannot be uniquely discovered, for example, more than one cloud matches the provided name.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_CLOUD</term>
		/// <term>The cloud specified in pwzCloud cannot be located.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
		/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Multiple applications can open the same group simultaneously. Any application can choose to open a group without subsequently
		/// calling PeerGroupConnect. These applications are considered to be offline. However, a second application can open and connect
		/// the peer to the group, which means that an application must be ready to connect at any time.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupopen NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerGroupOpen(
		// PCWSTR pwzIdentity, PCWSTR pwzGroupPeerName, PCWSTR pwzCloud, HGROUP *phGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupOpen")]
		public static extern HRESULT PeerGroupOpen([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pwzGroupPeerName,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzCloud, out HGROUP phGroup);

		/// <summary>The <c>PeerGroupOpenDirectConnection</c> function establishes a direct connection with another peer in a peer group.</summary>
		/// <param name="hGroup">
		/// Handle to the peer group that hosts the direct connection. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzIdentity">Pointer to a Unicode string that contains the identity a peer connects to. This parameter is required.</param>
		/// <param name="pAddress">
		/// Pointer to a PEER_ADDRESS structure that contains the IPv6 address the peer connects to. This parameter is required.
		/// </param>
		/// <param name="pullConnectionId">
		/// Unsigned 64-bit integer that identifies the direct connection. This ID value cannot be assumed as valid until the
		/// PEER_GROUP_EVENT_DIRECT_CONNECTION event is raised and indicates that the connection has been accepted by the other peer. This
		/// parameter is required.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CONNECT_SELF</term>
		/// <term>The connection failed because it was a loopback, that is, the connection is between a peer and itself.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the peer identity or peer group keys is denied. This is typically caused by an incorrect access control list (ACL) for
		/// the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Every direct connection opened with this function must be closed with PEER_GROUP_EVENT DATA structure has the <c>status</c>
		/// member of its component PEER_EVENT_CONNECTION_CHANGE_DATA structure set to PEER_CONNECTION_FAILED.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupopendirectconnection NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupOpenDirectConnection( HGROUP hGroup, PCWSTR pwzIdentity, PPEER_ADDRESS pAddress, ULONGLONG *pullConnectionId );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupOpenDirectConnection")]
		public static extern HRESULT PeerGroupOpenDirectConnection(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, in PEER_ADDRESS pAddress, out ulong pullConnectionId);

		/// <summary>
		/// The <c>PeerGroupParseInvitation</c> function returns a PEER_INVITATION_INFO structure with the details of a specific invitation.
		/// </summary>
		/// <param name="pwzInvitation">
		/// Pointer to a Unicode string that contains the specific peer group invitation. This parameter is required.
		/// </param>
		/// <param name="ppInvitationInfo">
		/// Pointer to a PEER_INVITATION_INFO structure with the details of a specific invitation. To release the resources used by this
		/// structure, pass this pointer to PeerFreeData. This parameter is required.
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
		/// <term>There is not enough memory available to complete an operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVITATION_NOT_TRUSTED</term>
		/// <term>The invitation is not trusted by the peer. It has been altered or contains errors.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNSUPPORTED_VERSION</term>
		/// <term>The invitation is not supported by the current version of the Peer Infrastructure.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupparseinvitation NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupParseInvitation( PCWSTR pwzInvitation, PPEER_INVITATION_INFO *ppInvitationInfo );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupParseInvitation")]
		public static extern HRESULT PeerGroupParseInvitation([MarshalAs(UnmanagedType.LPWStr)] string pwzInvitation,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_INVITATION_INFO>))] out PEER_INVITATION_INFO ppInvitationInfo);

		/// <summary>
		/// The <c>PeerGroupPasswordJoin</c> function prepares a peer with an invitation and the correct password to join a
		/// password-protected peer group prior to calling PeerGroupConnect or PeerGroupConnectByAddress.
		/// </summary>
		/// <param name="pwzIdentity">
		/// Pointer to a Unicode string that contains the identity opening the specified peer group. If this parameter is <c>NULL</c>, the
		/// implementation uses the identity obtained from PeerIdentityGetDefault.
		/// </param>
		/// <param name="pwzInvitation">
		/// Pointer to a Unicode string that contains the XML invitation granted by another peer. An invitation with a password is created
		/// when the inviting peer calls PeerGroupCreatePasswordInvitation. Specific details regarding this invitation, including the
		/// password set by the group creator, can be obtained as a PEER_INVITATION_INFO structure by calling PeerGroupParseInvitation. This
		/// parameter is required.
		/// </param>
		/// <param name="pwzPassword">
		/// Pointer to a zero-terminated Unicode string that contains the password required to validate and join the peer group. This
		/// password must match the password specified in the invitation. This parameter is required.
		/// </param>
		/// <param name="pwzCloud">
		/// Pointer to a Unicode string that contains the name of the PNRP cloud where a group is located. The default value is <c>NULL</c>,
		/// which indicates that the cloud specified in the invitation must be used.
		/// </param>
		/// <param name="phGroup">
		/// Pointer to the handle of the peer group. To start communication with a group, call PeerGroupConnect. This parameter is required.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_CLOUD_NAME_AMBIGUOUS</term>
		/// <term>The cloud cannot be uniquely discovered, for example, more than one cloud matches the provided name.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_PEER_NAME</term>
		/// <term>The peer identity specified in pwzIdentity is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVITATION_NOT_TRUSTED</term>
		/// <term>The invitation is not trusted by the peer. It has been altered or contains errors.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_CLOUD</term>
		/// <term>The cloud cannot be located.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNSUPPORTED_VERSION</term>
		/// <term>The invitation is not supported by the current version of the Peer Infrastructure.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NO_KEY_ACCESS</term>
		/// <term>
		/// Access to the peer identity or peer group keys is denied. Typically, this is caused by an incorrect access control list (ACL)
		/// for the folder that contains the user or computer keys. This can happen when the ACL has been reset manually.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_S_ALREADY_A_MEMBER</term>
		/// <term>The local peer attempted to join a group based on a password more than once.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors may be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// In the event of a clock skew between participating machines, the initial <c>PeerGroupPasswordJoin</c> function may still succeed
		/// while the following call of PeerGroupConnect can result in a failure to join depending on the severity of the skew.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergrouppasswordjoin NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupPasswordJoin( PCWSTR pwzIdentity, PCWSTR pwzInvitation, PCWSTR pwzPassword, PCWSTR pwzCloud, HGROUP *phGroup );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupPasswordJoin")]
		public static extern HRESULT PeerGroupPasswordJoin([MarshalAs(UnmanagedType.LPWStr)] string pwzIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pwzInvitation,
			[MarshalAs(UnmanagedType.LPWStr)] string pwzPassword, [Optional, MarshalAs(UnmanagedType.LPWStr)] string pwzCloud, out HGROUP phGroup);

		/// <summary>
		/// The <c>PeerGroupPeerTimeToUniversalTime</c> function converts the peer group-maintained reference time value to a localized time
		/// value appropriate for display on a peer computer.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group that a peer participates in. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pftPeerTime">
		/// Pointer to the peer time value—Coordinated Universal Time (UTC)—that is represented as a FILETIME structure. This parameter is required.
		/// </param>
		/// <param name="pftUniversalTime">
		/// Pointer to the returned universal time value that is represented as a FILETIME structure. This parameter is <c>NULL</c> if an
		/// error occurs.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>S_OK</c> if the function succeeds. Otherwise, the function returns either one of the remote procedure call (RPC)
		/// errors or one of the following errors.
		/// </para>
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
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state that peer time can be retrieved accurately, for example, PeerGroupJoin has been called, but
		/// synchronization with the group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_INITIALIZED</term>
		/// <term>The peer group must be initialized with a call to PeerGroupStartup before using this function.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Universal time is the universal time value maintained on a peer computer.</para>
		/// <para>
		/// Peer time is a common reference time maintained by a peer group, expressed as UTC. It is often offset from the universal time
		/// value, and is used to correct latency issues.
		/// </para>
		/// <para>Universal time can be converted to peer time by calling the converse function PeerGroupUniversalTimeToPeerTime.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergrouppeertimetouniversaltime NOT_BUILD_WINDOWS_DEPRECATE
		// HRESULT PeerGroupPeerTimeToUniversalTime( HGROUP hGroup, FILETIME *pftPeerTime, FILETIME *pftUniversalTime );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupPeerTimeToUniversalTime")]
		public static extern HRESULT PeerGroupPeerTimeToUniversalTime(HGROUP hGroup, in FILETIME pftPeerTime, out FILETIME pftUniversalTime);

		/// <summary>The <c>PeerGroupRegisterEvent</c> function registers a peer for specific peer group events.</summary>
		/// <param name="hGroup">
		/// Handle of the peer group on which to monitor the specific peer events. This handle is returned by the PeerGroupCreate,
		/// PeerGroupOpen, or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="hEvent">
		/// Pointer to a Windows event handle, which is signaled when a peer event is fired. When this handle is signaled, the peer should
		/// call PeerGroupGetEventData until the function returns <c>PEER_S_NO_EVENT_DATA</c>. This parameter is required.
		/// </param>
		/// <param name="cEventRegistration">
		/// Contains the number of PEER_GROUP_EVENT_REGISTRATION structures listed in pEventRegistrations. This parameter is required.
		/// </param>
		/// <param name="pEventRegistrations">
		/// Pointer to a list of PEER_GROUP_EVENT_REGISTRATION structures that contains the peer event types for which registration occurs.
		/// This parameter is required.
		/// </param>
		/// <param name="phPeerEvent">
		/// Pointer to the returned HPEEREVENT handle. A peer can unregister for this peer event by passing this handle to
		/// PeerGroupUnregisterEvent. This parameter is required.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the group is invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>Before you close the HPEEREVENT handle, you must unregister for the peer event types by passing the handle to PeerGroupUnregisterEvent.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupregisterevent NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupRegisterEvent( HGROUP hGroup, HANDLE hEvent, DWORD cEventRegistration, PEER_GROUP_EVENT_REGISTRATION
		// *pEventRegistrations, HPEEREVENT *phPeerEvent );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupRegisterEvent")]
		public static extern HRESULT PeerGroupRegisterEvent(HGROUP hGroup, HANDLE hEvent, uint cEventRegistration,
			[In, MarshalAs(UnmanagedType.LPArray)] PEER_GROUP_EVENT_REGISTRATION[] pEventRegistrations, out SafeHPEEREVENT phPeerEvent);

		/// <summary>
		/// The <c>PeerGroupSearchRecords</c> function searches the local peer group database for records that match the supplied criteria.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group whose local database is searched. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pwzCriteria">
		/// Pointer to a Unicode XML string that contains the record search query. For information about formulating an XML query string to
		/// search the peer group records database, see the Record Search Query Format documentation. This parameter is required.
		/// </param>
		/// <param name="phPeerEnum">
		/// Pointer to the enumeration that contains the returned list of records. This handle is passed to PeerGetNextItem to retrieve the
		/// items with each item represented as a pointer to a PEER_RECORD structure. When finished, PeerEndEnumeration is called to return
		/// the memory used by the enumeration. This parameter is required.
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
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_SEARCH</term>
		/// <term>The XML search query does not adhere to the search query schema specification.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupsearchrecords NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupSearchRecords( HGROUP hGroup, PCWSTR pwzCriteria, HPEERENUM *phPeerEnum );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupSearchRecords")]
		public static extern HRESULT PeerGroupSearchRecords(HGROUP hGroup, [MarshalAs(UnmanagedType.LPWStr)] string pwzCriteria, out SafeHPEERENUM<PEER_RECORD> phPeerEnum);

		/// <summary>The <c>PeerGroupSendData</c> function sends data to a member over a neighbor or direct connection.</summary>
		/// <param name="hGroup">
		/// Handle to the group that contains both members of a connection. This handle is returned by the PeerGroupCreate, PeerGroupOpen,
		/// or PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="ullConnectionId">
		/// Unsigned 64-bit integer that contains the ID of the connection that hosts the data transmission. A connection ID is obtained by
		/// calling PeerGroupOpenDirectConnection. This parameter is required.
		/// </param>
		/// <param name="pType">Pointer to a <c>GUID</c> value that uniquely identifies the data being transmitted. This parameter is required.</param>
		/// <param name="cbData">Specifies the size of the data in pvData, in bytes. This parameter is required.</param>
		/// <param name="pvData">
		/// Pointer to the block of data to send. The receiving application is responsible for parsing this data. This parameter is required.
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
		/// <term>PEER_E_CONNECTION_NOT_FOUND</term>
		/// <term>A connection with the ID specified in ullConnectionId cannot be found.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>To receive data, the receiving peer must have registered for the <c>PEER_GROUP_EVENT_INCOMING_DATA</c> peer event.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupsenddata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupSendData( HGROUP hGroup, ULONGLONG ullConnectionId, const GUID *pType, ULONG cbData, PVOID pvData );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupSendData")]
		public static extern HRESULT PeerGroupSendData(HGROUP hGroup, ulong ullConnectionId, in Guid pType, uint cbData, [In] IntPtr pvData);

		/// <summary>
		/// The <c>PeerGroupSetProperties</c> function sets the current peer group properties. In version 1.0 of this API, only the creator
		/// of the peer group can perform this operation.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group whose properties are set by a peer. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pProperties">
		/// <para>
		/// Pointer to a peer-populated PEER_GROUP_PROPERTIES structure that contains the new properties. To obtain this structure, a peer
		/// must first call PeerGroupGetProperties, change the appropriate fields, and then pass it as this parameter. This parameter is required.
		/// </para>
		/// <para>The following members of</para>
		/// <para>PEER_GROUP_PROPERTIES</para>
		/// <para>cannot be changed:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>dwSize</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzCloud</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzClassifier</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzGroupPeerName</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzCreatorPeerName</c></term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The group is not in a state where peer group properties can be set. For example, PeerGroupJoin has been called, but
		/// synchronization with the peer group database is not complete.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP_PROPERTIES</term>
		/// <term>One or more of the specified properties is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>
		/// The current identity does not have the authorization to change these properties. In this case, the identity is not the creator
		/// of the peer group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_PASSWORD_DOES_NOT_MEET_POLICY</term>
		/// <term>Password specified does not meet system password requirements.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// For applications that utilize passwords, it is recommended the passwords are handled securely by calling the CryptoProtectMemory
		/// and SecureZeroMemory functions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupsetproperties NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupSetProperties( HGROUP hGroup, PPEER_GROUP_PROPERTIES pProperties );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupSetProperties")]
		public static extern HRESULT PeerGroupSetProperties(HGROUP hGroup, in PEER_GROUP_PROPERTIES pProperties);

		/// <summary>
		/// The <c>PeerGroupShutdown</c> function closes a peer group created with PeerGroupStartup and disposes of any allocated resources.
		/// </summary>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the operation succeeds. Otherwise, the function returns the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The function terminated unexpectedly.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupshutdown NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerGroupShutdown();
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupShutdown")]
		public static extern HRESULT PeerGroupShutdown();

		/// <summary>The <c>PeerGroupStartup</c> function initiates a peer group by using a requested version of the Peer infrastructure.</summary>
		/// <param name="wVersionRequested">
		/// Specifies the highest version of the Peer Infrastructure that a caller can support. The high order byte specifies the minor
		/// version (revision) number. The low order byte specifies the major version number This parameter is required.
		/// </param>
		/// <param name="pVersionData">
		/// Pointer to a PEER_VERSION_DATA structure that contains the specific level of support provided by the Peer Infrastructure. This
		/// parameter is required.
		/// </param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the function succeeds. Otherwise, the function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SERVICE_DEPENDENCY_FAIL</term>
		/// <term>The Peer Name Resolution Protocol (PNRP) service must be started before calling PeerGroupStartup.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is not enough memory available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_IPV6_NOT_INSTALLED</term>
		/// <term>The grouping service failed to start because IPv6 is not installed on the computer.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_UNSUPPORTED_VERSION</term>
		/// <term>The requested version is not supported by the installed Peer subsystem.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The Peer Name Resolution Protocol (PNRP) service must be started before calling this function.</para>
		/// <para>This function is called by the application before calling any other Peer Grouping function.</para>
		/// <para>For this release, applications should use <c>PEER_GROUP_VERSION</c> as the requested version.</para>
		/// <para>A peer group started with this function is closed by calling PeerGroupShutdown when the application terminates.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupstartup NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupStartup( WORD wVersionRequested, PPEER_VERSION_DATA pVersionData );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupStartup")]
		public static extern HRESULT PeerGroupStartup(ushort wVersionRequested, out PEER_VERSION_DATA pVersionData);

		/// <summary>
		/// The <c>PeerGroupUniversalTimeToPeerTime</c> function converts a local time value from a peer's computer to a common peer group
		/// time value.
		/// </summary>
		/// <param name="hGroup">
		/// Handle to the peer group a peer participates in. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or PeerGroupJoin
		/// function. This parameter is required.
		/// </param>
		/// <param name="pftUniversalTime">
		/// Pointer to the universal time value, represented as a FILETIME structure. This parameter is required.
		/// </param>
		/// <param name="pftPeerTime">
		/// Pointer to the returned peer time—Greenwich Mean Time (GMT) value that is represented as a FILETIME structure. This parameter is
		/// <c>NULL</c> if an error occurs.
		/// </param>
		/// <returns>
		/// <para>
		/// Returns <c>S_OK</c> if the function succeeds. Otherwise, the function returns either one of the RPC errors or one of the
		/// following values.
		/// </para>
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
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where peer time can be accurately calculated. For example, PeerGroupJoin has been called, but
		/// synchronization with the peer group database has not completed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_INITIALIZED</term>
		/// <term>The group must be initialized with a call to PeerGroupStartup before using this function.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Universal time is the universal time value maintained on a peer's computer.</para>
		/// <para>
		/// Peer time is a common reference time maintained by a peer group, expressed as Coordinated Universal Time (UTC). It is often
		/// offset from the universal time value, and is used to correct latency issues.
		/// </para>
		/// <para>Peer time can be converted to universal time by calling the converse function PeerGroupPeerTimeToUniversalTime.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupuniversaltimetopeertime NOT_BUILD_WINDOWS_DEPRECATE
		// HRESULT PeerGroupUniversalTimeToPeerTime( HGROUP hGroup, FILETIME *pftUniversalTime, FILETIME *pftPeerTime );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupUniversalTimeToPeerTime")]
		public static extern HRESULT PeerGroupUniversalTimeToPeerTime(HGROUP hGroup, in FILETIME pftUniversalTime, out FILETIME pftPeerTime);

		/// <summary>
		/// The <c>PeerGroupUnregisterEvent</c> function unregisters a peer from notification of peer events associated with the supplied
		/// event handle.
		/// </summary>
		/// <param name="hPeerEvent">Handle returned by a previous call to PeerGroupRegisterEvent. This parameter is required.</param>
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
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		/// <remarks>This function must be called before the HPEEREVENT handle is closed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupunregisterevent NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupUnregisterEvent( HPEEREVENT hPeerEvent );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupUnregisterEvent")]
		public static extern HRESULT PeerGroupUnregisterEvent(HPEEREVENT hPeerEvent);

		/// <summary>The <c>PeerGroupUpdateRecord</c> function updates a record within a specific peer group.</summary>
		/// <param name="hGroup">
		/// Handle to the peer group whose record is updated. This handle is returned by the PeerGroupCreate, PeerGroupOpen, or
		/// PeerGroupJoin function. This parameter is required.
		/// </param>
		/// <param name="pRecord">
		/// <para>Pointer to a PEER_RECORD structure that contains the updated record for hGroup. This parameter is required.</para>
		/// <para>The following members in PEER_RECORD can be updated.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>pwzAttributes</c></term>
		/// </item>
		/// <item>
		/// <term><c>ftExpiration</c></term>
		/// </item>
		/// <item>
		/// <term><c>data</c></term>
		/// </item>
		/// </list>
		/// <para>The following members in</para>
		/// <para>PEER_RECORD</para>
		/// <para>must be present, but cannot be changed.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>dwSize</c></term>
		/// </item>
		/// <item>
		/// <term><c>id</c></term>
		/// </item>
		/// <item>
		/// <term><c>type</c></term>
		/// </item>
		/// <item>
		/// <term><c>dwFlags</c></term>
		/// </item>
		/// </list>
		/// <para>The following members are ignored if populated.</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>dwVersion</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzCreatorId</c></term>
		/// </item>
		/// <item>
		/// <term><c>pwzModifiedById</c></term>
		/// </item>
		/// <item>
		/// <term><c>ftCreation</c></term>
		/// </item>
		/// <item>
		/// <term><c>ftLastModified</c></term>
		/// </item>
		/// <item>
		/// <term><c>securityData</c></term>
		/// </item>
		/// </list>
		/// <para>The members that remain are optional.</para>
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
		/// <term>One of the specified parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_GROUP_NOT_READY</term>
		/// <term>
		/// The peer group is not in a state where a record can be updated, for example, PeerGroupJoin has been called, but synchronization
		/// with the peer group database is not complete.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_INVALID_GROUP</term>
		/// <term>The handle to the peer group is invalid.</term>
		/// </item>
		/// <item>
		/// <term>PEER_E_NOT_AUTHORIZED</term>
		/// <term>
		/// The current peer identity does not have the authorization to delete the record. In this case, the peer identity is not the
		/// creator of the record.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PEER_E_RECORD_NOT_FOUND</term>
		/// <term>The record cannot be located in the data store.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Cryptography-specific errors can be returned from the Microsoft RSA Base Provider. These errors are prefixed with CRYPT_* and
		/// defined in Winerror.h.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peergroupupdaterecord NOT_BUILD_WINDOWS_DEPRECATE HRESULT
		// PeerGroupUpdateRecord( HGROUP hGroup, PPEER_RECORD pRecord );
		[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerGroupUpdateRecord")]
		public static extern HRESULT PeerGroupUpdateRecord(HGROUP hGroup, in PEER_RECORD pRecord);

		/// <summary>Provides a handle to a peer group.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HGROUP : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HGROUP"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HGROUP(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGROUP"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HGROUP NULL => new HGROUP(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HGROUP"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HGROUP h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HGROUP"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HGROUP(IntPtr h) => new HGROUP(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HGROUP h1, HGROUP h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HGROUP h1, HGROUP h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HGROUP h && handle == h.handle;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}
	}
}