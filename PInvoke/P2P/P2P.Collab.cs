using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the P2P.dll</summary>
public static partial class P2P
{
	/// <summary>The <c>PeerCollabAddContact</c> function adds a contact to the contact list of a peer.</summary>
	/// <param name="pwzContactData">
	/// <para>
	/// Pointer to a zero-terminated Unicode string buffer that contains the contact data for the peer that is added to the contact
	/// list. This string buffer can either be obtained by passing the peer name of the endpoint to add as a contact to
	/// PeerCollabQueryContactData, or through an out-of-band mechanism.
	/// </para>
	/// <para>
	/// To send its own contact data out-of-band, the peer can call PeerCollabExportContact with a <c>NULL</c> peer name. This function
	/// returns the contact data in XML format.
	/// </para>
	/// </param>
	/// <param name="ppContact">
	/// <para>
	/// Pointer to a pointer to a PEER_CONTACT structure. This parameter receives the address of a <c>PEER_CONTACT</c> structure
	/// containing peer contact information for the contact supplied in pwzContactData. This parameter may be <c>NULL</c>.
	/// </para>
	/// <para>Call PeerFreeData on the address of the PEER_CONTACT structure to free this data.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabaddcontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabAddContact( PCWSTR pwzContactData, PPEER_CONTACT *ppContact );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabAddContact")]
	public static extern HRESULT PeerCollabAddContact([MarshalAs(UnmanagedType.LPWStr)] string pwzContactData,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_CONTACT>))] out PEER_CONTACT ppContact);
		out SafePeerData ppContact);

	/// <summary>
	/// The <c>PeerCollabAsyncInviteContact</c> function sends an invitation to a trusted peer contact to join the sender's peer
	/// collaboration activity over a secured connection. The availability of the invitation response is updated through an asynchronous event.
	/// </summary>
	/// <param name="pcContact">
	/// <para>
	/// Pointer to a PEER_CONTACT structure that contains the contact information associated with the recipient of the invite. This
	/// parameter is optional.
	/// </para>
	/// <para>To invite the endpoint of the calling peer specified in pcEndpoint, set the pointer value to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcEndpoint">
	/// Pointer to a PEER_ENDPOINT structure that contains information about the invited peer's endpoint. The endpoint must be
	/// associated with the peer contact specified in pcContact.
	/// </param>
	/// <param name="pcInvitation">
	/// Pointer to a PEER_INVITATION structure that contains the invitation request to send to the endpoint specified in pcEndpoint.
	/// E_INVALIDARG is returned if this parameter is set to <c>NULL</c>.
	/// </param>
	/// <param name="hEvent">
	/// <para>
	/// Handle to the event for this invitation, created by a previous call to CreateEvent. The event is signaled when the status of the
	/// asynchronous invitation is updated. To obtain the response data, call PeerCollabGetInvitationResponse.
	/// </para>
	/// <para>If the event is not provided the caller must poll for the result by calling PeerCollabGetInvitationResponse.</para>
	/// </param>
	/// <param name="phInvitation">
	/// A pointer to a handle to the sent invitation. The framework will cleanup the response information after the invitation response
	/// is received if <c>NULL</c> is specified. When <c>NULL</c> is not the specified handle to the invitation provided, it must be
	/// closed by calling PeerCollabCloseHandle.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_NOTIMPL</term>
	/// <term>pcEndpoint is NULL.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API ensures the peer that receives the invitation is the contact specified as input. The connection will fail if the
	/// specific contact is not present on the endpoint specified. The use of <c>PeerCollabAsyncInviteContact</c> is recommended in
	/// place of the less secure PeerCollabAsyncInviteEndpoint.
	/// </para>
	/// <para>
	/// A toast will appear for the recipient of the invitation. This toast will be converted to a dialog box in which the user can
	/// accept or decline the invitation. When the invitation is successfully accepted, the collaborative application is launched on the
	/// recipient's machine.
	/// </para>
	/// <para>
	/// To successfully receive the invitation the application must be registered on the recipient's machine using
	/// PeerCollabRegisterApplication. It is also possible for the sender of the invite to have failure codes returned because the
	/// recipient has turned off application invites.
	/// </para>
	/// <para>
	/// The PeerCollabGetInvitiationResponse function will return PEER_E_CONNECTION_FAILED if the contact to which the invitation is
	/// being sent is not accepting invitations.
	/// </para>
	/// <para>
	/// If the recipient is accepting invitations only from trusted contacts, then the sender of the invite must be added to the contact
	/// store of the recipient machine. The sender must be added to the contact store before the invitation attempt. To add a contact to
	/// the contact store, call PeerCollabAddContact.
	/// </para>
	/// <para>To cancel an outstanding invitation, call PeerCollabCancelInvitation.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabasyncinvitecontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabAsyncInviteContact( PCPEER_CONTACT pcContact, PCPEER_ENDPOINT pcEndpoint, PCPEER_INVITATION pcInvitation, HANDLE
	// hEvent, HANDLE *phInvitation );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabAsyncInviteContact")]
	public static extern HRESULT PeerCollabAsyncInviteContact(in PEER_CONTACT pcContact, in PEER_ENDPOINT pcEndpoint, in PEER_INVITATION pcInvitation, [In, Optional] HANDLE hEvent, out SafePeerCollabHandle phInvitation);

	/// <summary>
	/// The <c>PeerCollabAsyncInviteContact</c> function sends an invitation to a trusted peer contact to join the sender's peer
	/// collaboration activity over a secured connection. The availability of the invitation response is updated through an asynchronous event.
	/// </summary>
	/// <param name="pcContact">
	/// <para>
	/// Pointer to a PEER_CONTACT structure that contains the contact information associated with the recipient of the invite. This
	/// parameter is optional.
	/// </para>
	/// <para>To invite the endpoint of the calling peer specified in pcEndpoint, set the pointer value to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcEndpoint">
	/// Pointer to a PEER_ENDPOINT structure that contains information about the invited peer's endpoint. The endpoint must be
	/// associated with the peer contact specified in pcContact.
	/// </param>
	/// <param name="pcInvitation">
	/// Pointer to a PEER_INVITATION structure that contains the invitation request to send to the endpoint specified in pcEndpoint.
	/// E_INVALIDARG is returned if this parameter is set to <c>NULL</c>.
	/// </param>
	/// <param name="hEvent">
	/// <para>
	/// Handle to the event for this invitation, created by a previous call to CreateEvent. The event is signaled when the status of the
	/// asynchronous invitation is updated. To obtain the response data, call PeerCollabGetInvitationResponse.
	/// </para>
	/// <para>If the event is not provided the caller must poll for the result by calling PeerCollabGetInvitationResponse.</para>
	/// </param>
	/// <param name="phInvitation">
	/// A pointer to a handle to the sent invitation. The framework will cleanup the response information after the invitation response
	/// is received if <c>NULL</c> is specified. When <c>NULL</c> is not the specified handle to the invitation provided, it must be
	/// closed by calling PeerCollabCloseHandle.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_NOTIMPL</term>
	/// <term>pcEndpoint is NULL.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API ensures the peer that receives the invitation is the contact specified as input. The connection will fail if the
	/// specific contact is not present on the endpoint specified. The use of <c>PeerCollabAsyncInviteContact</c> is recommended in
	/// place of the less secure PeerCollabAsyncInviteEndpoint.
	/// </para>
	/// <para>
	/// A toast will appear for the recipient of the invitation. This toast will be converted to a dialog box in which the user can
	/// accept or decline the invitation. When the invitation is successfully accepted, the collaborative application is launched on the
	/// recipient's machine.
	/// </para>
	/// <para>
	/// To successfully receive the invitation the application must be registered on the recipient's machine using
	/// PeerCollabRegisterApplication. It is also possible for the sender of the invite to have failure codes returned because the
	/// recipient has turned off application invites.
	/// </para>
	/// <para>
	/// The PeerCollabGetInvitiationResponse function will return PEER_E_CONNECTION_FAILED if the contact to which the invitation is
	/// being sent is not accepting invitations.
	/// </para>
	/// <para>
	/// If the recipient is accepting invitations only from trusted contacts, then the sender of the invite must be added to the contact
	/// store of the recipient machine. The sender must be added to the contact store before the invitation attempt. To add a contact to
	/// the contact store, call PeerCollabAddContact.
	/// </para>
	/// <para>To cancel an outstanding invitation, call PeerCollabCancelInvitation.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabasyncinvitecontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabAsyncInviteContact( PCPEER_CONTACT pcContact, PCPEER_ENDPOINT pcEndpoint, PCPEER_INVITATION pcInvitation, HANDLE
	// hEvent, HANDLE *phInvitation );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabAsyncInviteContact")]
	public static extern HRESULT PeerCollabAsyncInviteContact([In, Optional] IntPtr pcContact, in PEER_ENDPOINT pcEndpoint, in PEER_INVITATION pcInvitation, [In, Optional] HANDLE hEvent, out SafePeerCollabHandle phInvitation);

	/// <summary>
	/// The <c>PeerCollabAsyncInviteEndpoint</c> function sends an invitation to a specified peer endpoint to join the sender's peer
	/// collaboration activity. The availability of the response to the invitation is updated through an asynchronous event.
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>
	/// Pointer to a PEER_ENDPOINT structure that contains information about the invited peer. This peer is sent an invitation when this
	/// API is called.
	/// </para>
	/// <para>This parameter must not be set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcInvitation">
	/// Pointer to a PEER_INVITATION structure that contains the invitation request to send to the endpoint specified in pcEndpoint.
	/// E_INVALIDARG is returned if this parameter is set to <c>NULL</c>.
	/// </param>
	/// <param name="hEvent">
	/// <para>
	/// Handle to the event for this invitation, created by a previous call to CreateEvent. The event is signaled when the status of the
	/// asynchronous invitation is updated. To obtain the response data, call PeerCollabGetInvitationResponse.
	/// </para>
	/// <para>If the event is not provided, the caller must poll for the result by calling PeerCollabGetInvitationResponse.</para>
	/// </param>
	/// <param name="phInvitation">
	/// A pointer to a handle to the sent invitation. If this parameter is <c>NULL</c>, the framework will cleanup the response
	/// information after the invitation response is received. If this parameter is not <c>NULL</c>, the handle must be closed by
	/// calling PeerCollabCloseHandle.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API sends an invitation to the endpoint specified as input. It does not guarantee that the recipient of the invite is the
	/// specific contact that the user intended to send the invite to. To ensure that the invitation is sent to the correct contact use PeerCollabAsyncInviteContact.
	/// </para>
	/// <para>
	/// A toast will appear for the recipient of the invitation. This toast will be converted to a dialog box in which the user can
	/// accept or decline the invitation. When the invitation is successfully accepted, the collaborative application is launched on the
	/// recipient's machine.
	/// </para>
	/// <para>
	/// To successfully receive the invitation, the application must be registered on the recipient's machine using
	/// PeerCollabRegisterApplication. It is also possible for the sender of the invite to have failure codes returned because the
	/// recipient has turned off application invites.
	/// </para>
	/// <para>
	/// The PeerCollabGetInvitiationResponse function will return PEER_E_CONNECTION_FAILED if the endpoint to which the invitation is
	/// being sent is not accepting invitations.
	/// </para>
	/// <para>
	/// If the recipient is accepting invitations only from trusted contacts, then the sender of the invite must be added to the contact
	/// store of the recipient machine. The sender must be added to the contact store before the invitation attempt. To add a contact to
	/// the contact store, call PeerCollabAddContact.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabasyncinviteendpoint NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabAsyncInviteEndpoint( PCPEER_ENDPOINT pcEndpoint, PCPEER_INVITATION pcInvitation, HANDLE hEvent, HANDLE *phInvitation );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabAsyncInviteEndpoint")]
	public static extern HRESULT PeerCollabAsyncInviteEndpoint(in PEER_ENDPOINT pcEndpoint, in PEER_INVITATION pcInvitation, [In, Optional] HANDLE hEvent, out SafePeerCollabHandle phInvitation);

	/// <summary>The <c>PeerCollabCancelInvitation</c> function cancels an invitation previously sent by the caller to a contact.</summary>
	/// <param name="hInvitation">Handle to a previously sent invitation.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The provided handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The application did not make a previous call to PeerCollabStartup.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The handle specified is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When <c>PeerCollabCancelInvitation</c> is called, depending on the state of the invitation, it will perform one or more of the
	/// following actions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the connection to the receiver is not yet established, it will cancel the connection creation process and the receiver will
	/// not see the invitation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the invitation has been received, but not responded to, it will notify the recipient contact that the invitation has been
	/// canceled. As a result, the receiver will not be able to respond to the invitation.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the receiver has already responded to the invitation, the call performs a no-op. After canceling the invitation, you must
	/// call PeerCollabCloseHandle.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabcancelinvitation NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabCancelInvitation( HANDLE hInvitation );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabCancelInvitation")]
	public static extern HRESULT PeerCollabCancelInvitation([In] SafePeerCollabHandle hInvitation);

	/// <summary>The <c>PeerCollabCloseHandle</c> function closes the handle to a Peer Collaboration activity invitation.</summary>
	/// <param name="hInvitation">Handle obtained by a previous call to PeerCollabAsyncInviteContact or PeerCollabAsyncInviteEndpoint.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The handle specified is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// You must call this API after the handle has been signaled for an event and any data associated with the event has been obtained.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabclosehandle NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabCloseHandle( HANDLE hInvitation );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabCloseHandle")]
	public static extern HRESULT PeerCollabCloseHandle(HANDLE hInvitation);

	/// <summary>The <c>PeerCollabDeleteContact</c> function deletes a contact from the local contact store associated with the caller.</summary>
	/// <param name="pwzPeerName">
	/// Pointer to a zero-terminated Unicode string that contains the peer name of the contact to delete. This parameter must not be
	/// <c>NULL</c>. You cannot delete the 'Me' contact.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Once a contact is deleted using <c>PeerCollabDeleteContact</c>, the presence updates provided by a subscription will no longer
	/// be available for that contact. If the contact is being watched (fWatch is set to <c>TRUE</c>) than PEER_EVENT_WATCHLIST_CHANGED
	/// will be raised.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabdeletecontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabDeleteContact( PCWSTR pwzPeerName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabDeleteContact")]
	public static extern HRESULT PeerCollabDeleteContact([MarshalAs(UnmanagedType.LPWStr)] string pwzPeerName);

	/// <summary>
	/// The <c>PeerCollabDeleteEndpointData</c> function deletes the peer endpoint data on the calling peer node that matches the
	/// supplied endpoint data.
	/// </summary>
	/// <param name="pcEndpoint">
	/// Pointer to a PEER_ENDPOINT structure that contains the peer endpoint information to delete from the current peer node.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The function <c>PeerCollabDeleteEndpointData</c> is used to remove cached endpoint data previously retrieved by
	/// PeerCollabRefreshEndpointData when it is no longer required. Any data obtained through <c>PeerCollabRefreshEndpointData</c>
	/// remains in memory until <c>PeerCollabDeleteEndpointData</c> is called.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabdeleteendpointdata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabDeleteEndpointData( PCPEER_ENDPOINT pcEndpoint );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabDeleteEndpointData")]
	public static extern HRESULT PeerCollabDeleteEndpointData(in PEER_ENDPOINT pcEndpoint);

	/// <summary>The <c>PeerCollabDeleteObject</c> function deletes a peer object from the calling endpoint.</summary>
	/// <param name="pObjectId">Pointer to a GUID value that uniquely identifies the peer object to delete from the calling endpoint.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture, an avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 3216K in size.
	/// </para>
	/// <para>
	/// Trusted contacts watching this peer object and the subscriber of the "Me" contact will have a PEER_EVENT_OBJECT_CHANGED event
	/// raised, signaling this peer object's change in status. PEER_EVENT_MY_OBJECT_CHANGED will be raised locally.
	/// </para>
	/// <para>Pre-defined objects, like Picture objects, cannot be deleted by calling this API.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabdeleteobject NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabDeleteObject( const GUID *pObjectId );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabDeleteObject")]
	public static extern HRESULT PeerCollabDeleteObject(in Guid pObjectId);

	/// <summary>
	/// The <c>PeerCollabEnumApplicationRegistrationInfo</c> function obtains the enumeration handle used to retrieve peer application information.
	/// </summary>
	/// <param name="registrationType">
	/// A PEER_APPLICATION_REGISTRATION_TYPE value that specifies whether the peer's application is registered to the <c>current
	/// user</c> or <c>all users</c> of the peer's machine.
	/// </param>
	/// <param name="phPeerEnum">
	/// Pointer to a peer enumeration handle for the peer application registration information. This data is obtained by passing this
	/// handle to PeerGetNextItem.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To obtain the individual peer applications, pass the returned handle to PeerGetNextItem. An array of
	/// PEER_APPLICATION_REGISTRATION_INFO structures will be returned. To close the enumeration and release the resources associated
	/// with it, pass this handle to PeerEndEnumeration. Individual items returned by the enumeration must be released with PeerFreeData.
	/// </para>
	/// <para>
	/// An application is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// A peer's application has a GUID representing a single specific application. When an application is registered for a peer, this
	/// GUID and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the
	/// peer can participate in. To unregister a peer's application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// <para>Peer application registration information items are returned as individual PEER_APPLICATION_REGISTRATION_INFO structures.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumapplicationregistrationinfo
	// NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerCollabEnumApplicationRegistrationInfo( PEER_APPLICATION_REGISTRATION_TYPE
	// registrationType, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumApplicationRegistrationInfo")]
	public static extern HRESULT PeerCollabEnumApplicationRegistrationInfo(PEER_APPLICATION_REGISTRATION_TYPE registrationType, out SafeHPEERENUM phPeerEnum);

	/// <summary>The <c>PeerCollabEnumApplicationRegistrationInfo</c> function enumerates peer application information.</summary>
	/// <param name="registrationType">
	/// A PEER_APPLICATION_REGISTRATION_TYPE value that specifies whether the peer's application is registered to the <c>current
	/// user</c> or <c>all users</c> of the peer's machine.
	/// </param>
	/// <returns>A list of <see cref="PEER_APPLICATION_REGISTRATION_INFO"/> structures.</returns>
	/// <remarks>
	/// <para>
	/// An application is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// A peer's application has a GUID representing a single specific application. When an application is registered for a peer, this
	/// GUID and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the
	/// peer can participate in. To unregister a peer's application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// <para>Peer application registration information items are returned as individual PEER_APPLICATION_REGISTRATION_INFO structures.</para>
	/// </remarks>
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumApplicationRegistrationInfo")]
	public static SafePeerList<PEER_APPLICATION_REGISTRATION_INFO> PeerCollabEnumApplicationRegistrationInfo(PEER_APPLICATION_REGISTRATION_TYPE registrationType) =>
		PeerEnum<PEER_APPLICATION_REGISTRATION_INFO>(() => { PeerCollabEnumApplicationRegistrationInfo(registrationType, out var h).ThrowIfFailed(); return h; });

	/// <summary>
	/// The <c>PeerCollabEnumApplications</c> function returns the handle to an enumeration that contains the applications registered to
	/// a specific peer's endpoint(s).
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>Pointer to a PEER_ENDPOINT structure that contains the endpoint information for a peer whose applications will be enumerated.</para>
	/// <para>If this parameter is set to <c>NULL</c>, the published application information for the local peer's endpoint is enumerated.</para>
	/// </param>
	/// <param name="pApplicationId">
	/// Pointer to the GUID value that uniquely identifies a particular application of the supplied peer. If this parameter is supplied,
	/// the only peer application returned is the one that matches this GUID.
	/// </param>
	/// <param name="phPeerEnum">
	/// Pointer to the handle for the enumerated set of registered applications that correspond to the GUID returned in pObjectId. Pass
	/// this handle to PeerGetNextItem to obtain each item in the enumerated set.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In order to enumerate the applications for the specified endpoint successfully, application data must be available on the
	/// endpoint. For application data to be available, one of the following must occur:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To obtain the individual peer applications, pass the returned handle to PeerGetNextItem. To close the enumeration and release
	/// the resources associated with it, pass this handle to PeerEndEnumeration. Individual items returned by the enumeration must be
	/// released with PeerFreeData.
	/// </para>
	/// <para>Peer application data items are returned as individual PEER_APPLICATION structures.</para>
	/// <para>
	/// The <c>PeerCollabEnumApplications</c> function returns an empty array for endpoints on the subnet that are not trusted contacts.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumapplications NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumApplications( PCPEER_ENDPOINT pcEndpoint, const GUID *pApplicationId, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumApplications")]
	public static extern HRESULT PeerCollabEnumApplications(in PEER_ENDPOINT pcEndpoint, in Guid pApplicationId, out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumApplications</c> function returns the handle to an enumeration that contains the applications registered to
	/// a specific peer's endpoint(s).
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>Pointer to a PEER_ENDPOINT structure that contains the endpoint information for a peer whose applications will be enumerated.</para>
	/// <para>If this parameter is set to <c>NULL</c>, the published application information for the local peer's endpoint is enumerated.</para>
	/// </param>
	/// <param name="pApplicationId">
	/// Pointer to the GUID value that uniquely identifies a particular application of the supplied peer. If this parameter is supplied,
	/// the only peer application returned is the one that matches this GUID.
	/// </param>
	/// <param name="phPeerEnum">
	/// Pointer to the handle for the enumerated set of registered applications that correspond to the GUID returned in pObjectId. Pass
	/// this handle to PeerGetNextItem to obtain each item in the enumerated set.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In order to enumerate the applications for the specified endpoint successfully, application data must be available on the
	/// endpoint. For application data to be available, one of the following must occur:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To obtain the individual peer applications, pass the returned handle to PeerGetNextItem. To close the enumeration and release
	/// the resources associated with it, pass this handle to PeerEndEnumeration. Individual items returned by the enumeration must be
	/// released with PeerFreeData.
	/// </para>
	/// <para>Peer application data items are returned as individual PEER_APPLICATION structures.</para>
	/// <para>
	/// The <c>PeerCollabEnumApplications</c> function returns an empty array for endpoints on the subnet that are not trusted contacts.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumapplications NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumApplications( PCPEER_ENDPOINT pcEndpoint, const GUID *pApplicationId, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumApplications")]
	public static extern HRESULT PeerCollabEnumApplications([In, Optional] IntPtr pcEndpoint, [In, Optional] IntPtr pApplicationId, out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumApplications</c> function returns the handle to an enumeration that contains the applications registered to
	/// a specific peer's endpoint(s).
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>A PEER_ENDPOINT structure that contains the endpoint information for a peer whose applications will be enumerated.</para>
	/// <para>If this parameter is set to <c>NULL</c>, the published application information for the local peer's endpoint is enumerated.</para>
	/// </param>
	/// <param name="pApplicationId">
	/// A GUID value that uniquely identifies a particular application of the supplied peer. If this parameter is supplied, the only
	/// peer application returned is the one that matches this GUID.
	/// </param>
	/// <returns>
	/// A list of <see cref="PEER_APPLICATION"/> structures that contains the applications registered to a specific peer's endpoint(s).
	/// </returns>
	/// <remarks>
	/// <para>
	/// In order to enumerate the applications for the specified endpoint successfully, application data must be available on the
	/// endpoint. For application data to be available, one of the following must occur:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>PeerCollabEnumApplications</c> function returns an empty array for endpoints on the subnet that are not trusted contacts.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumapplications NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumApplications( PCPEER_ENDPOINT pcEndpoint, const GUID *pApplicationId, HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumApplications")]
	public static SafePeerList<PEER_APPLICATION> PeerCollabEnumApplications([In, Optional] PEER_ENDPOINT? pcEndpoint, [In, Optional] Guid? pApplicationId) =>
		PeerEnum<PEER_APPLICATION>(() =>
		{
			SafeHPEERENUM h;
			if (pcEndpoint.HasValue && pApplicationId.HasValue)
				PeerCollabEnumApplications(pcEndpoint.Value, pApplicationId.Value, out h).ThrowIfFailed();
			else
			{
				using var e = (SafeHGlobalStruct<PEER_ENDPOINT>)pcEndpoint;
				using var a = (SafeHGlobalStruct<Guid>)pApplicationId;
				PeerCollabEnumApplications(e, a, out h).ThrowIfFailed();
			}
			return h;
		});

	/// <summary>
	/// The <c>PeerCollabEnumContacts</c> function returns a handle to an enumerated set that contains all of the peer collaboration
	/// network contacts currently available on the calling peer.
	/// </summary>
	/// <param name="phPeerEnum">
	/// Handle to an enumerated set that contains all of the peer collaboration network contacts currently available on the calling
	/// peer, excluding the "Me" contact.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To obtain the individual peer contacts, pass the returned handle to PEER_CONTACT structures will be returned. To close the
	/// enumeration and release the resources associated with it, pass this handle to PeerEndEnumeration. Individual items returned by
	/// the enumeration must be released with PeerFreeData.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumcontacts NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumContacts( HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumContacts")]
	public static extern HRESULT PeerCollabEnumContacts(out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumContacts</c> function returns an enumerated set that contains all of the peer collaboration network
	/// contacts currently available on the calling peer.
	/// </summary>
	/// <returns>A list of <see cref="PEER_CONTACT"/> of all currently available contacts.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumcontacts NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumContacts( HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumContacts")]
	public static SafePeerList<PEER_CONTACT> PeerCollabEnumContacts() => PeerEnum<PEER_CONTACT>(() => { PeerCollabEnumContacts(out var h).ThrowIfFailed(); return h; });

	/// <summary>
	/// The <c>PeerCollabEnumEndpoints</c> function returns the handle to an enumeration that contains the endpoints associated with a
	/// specific peer contact.
	/// </summary>
	/// <param name="pcContact">
	/// Pointer to a PEER_CONTACT structure that contains the contact information for a specific peer. This parameter must not be <c>NULL</c>.
	/// </param>
	/// <param name="phPeerEnum">
	/// Pointer to a handle for the enumerated set of endpoints that are associated with the supplied peer contact. Pass this handle to
	/// PeerGetNextItem to obtain each item in the enumerated set.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is recommended that a contact record is updated using PeerCollabUpdateContact prior to calling
	/// <c>PeerCollabEnumEndpoints</c>. Failure to do so can result in a return of E_INVALIDARG.
	/// </para>
	/// <para>
	/// Endpoints will be available only for contacts with fWatch set to <c>true</c>. Only endpoints that have the "Me" contact of the
	/// calling peer saved as a trusted contact and have WatcherPermissions set to <c>allow</c> will be available. A contact must also
	/// be signed-in to the internet. In the event the contact is not signed-in, the error <c>E_INVALIDARG</c> will be returned.
	/// </para>
	/// <para>
	/// To obtain the individual peer endpoints, pass the returned handle to PeerGetNextItem. An array of pointers to PEER_ENDPOINT
	/// structures will be returned. If no endpoints are available, an empty array will be returned. To close the enumeration and
	/// release the resources associated with it, pass this handle to PeerEndEnumeration. Individual items returned by the enumeration
	/// must be released with PeerFreeData.
	/// </para>
	/// <para>The limit for connections to a single contact is 50.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumendpoints NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumEndpoints( PCPEER_CONTACT pcContact, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumEndpoints")]
	public static extern HRESULT PeerCollabEnumEndpoints(in PEER_CONTACT pcContact, out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumEndpoints</c> function returns an enumeration that contains the endpoints associated with a specific peer contact.
	/// </summary>
	/// <param name="pcContact">Pointer to a PEER_CONTACT structure that contains the contact information for a specific peer.</param>
	/// <returns>
	/// An enumeration of <see cref="PEER_ENDPOINT"/> structures that contain the endpoints associated with a specific peer contact.
	/// </returns>
	/// <remarks>
	/// <para>
	/// It is recommended that a contact record is updated using PeerCollabUpdateContact prior to calling
	/// <c>PeerCollabEnumEndpoints</c>. Failure to do so can result in a return of E_INVALIDARG.
	/// </para>
	/// <para>
	/// Endpoints will be available only for contacts with fWatch set to <c>true</c>. Only endpoints that have the "Me" contact of the
	/// calling peer saved as a trusted contact and have WatcherPermissions set to <c>allow</c> will be available. A contact must also
	/// be signed-in to the internet. In the event the contact is not signed-in, the error <c>E_INVALIDARG</c> will be returned.
	/// </para>
	/// <para>The limit for connections to a single contact is 50.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumendpoints NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumEndpoints( PCPEER_CONTACT pcContact, HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumEndpoints")]
	public static SafePeerList<PEER_ENDPOINT> PeerCollabEnumEndpoints(in PEER_CONTACT pcContact) =>
		PeerEnum<PEER_ENDPOINT, PEER_CONTACT>(pcContact, i => { PeerCollabEnumEndpoints(i, out var h).ThrowIfFailed(); return h; });

	/// <summary>
	/// The <c>PeerCollabEnumObjects</c> function returns the handle to an enumeration that contains the peer objects associated with a
	/// specific peer's endpoint.
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>Pointer to a PEER_ENDPOINT structure that contains the endpoint information for a peer whose objects will be enumerated.</para>
	/// <para>If this parameter is <c>NULL</c> the published objects of the local peer's contacts are returned.</para>
	/// </param>
	/// <param name="pObjectId">
	/// Pointer to a GUID value that uniquely identifies a peer object with the supplied peer. If this parameter is supplied, the only
	/// peer object returned is the one that matches this GUID.
	/// </param>
	/// <param name="phPeerEnum">
	/// Pointer to the handle for the enumerated set of peer objects that correspond to the GUID returned in pObjectId. Pass this handle
	/// to PeerGetNextItem to obtain each item in the enumerated set.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture, an avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 16K in size.
	/// </para>
	/// <para>
	/// <c>PeerCollabEnumObjects</c> will return all of the objects published for the local peer. The objects can be published by more
	/// than one application.
	/// </para>
	/// <para>
	/// To obtain the individual peer objects, pass the returned handle to PeerGetNextItem. The peer objects are returned as an array of
	/// pointers to the PEER_OBJECT structures. If the endpoint is not publishing any objects, an empty array will be returned. To close
	/// the enumeration and release the resources associated with it, pass this handle to PeerEndEnumeration. Individual items returned
	/// by the enumeration must be released with PeerFreeData.
	/// </para>
	/// <para>To obtain a peer object successfully:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the user is publishing a picture, the picture can be obtained by retrieving the corresponding object. The GUID for the
	/// picture object is PEER_COLLAB_OBJECTID_USER_PICTURE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumobjects NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumObjects( PCPEER_ENDPOINT pcEndpoint, const GUID *pObjectId, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumObjects")]
	public static extern HRESULT PeerCollabEnumObjects(in PEER_ENDPOINT pcEndpoint, in Guid pObjectId, out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumObjects</c> function returns the handle to an enumeration that contains the peer objects associated with a
	/// specific peer's endpoint.
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>Pointer to a PEER_ENDPOINT structure that contains the endpoint information for a peer whose objects will be enumerated.</para>
	/// <para>If this parameter is <c>NULL</c> the published objects of the local peer's contacts are returned.</para>
	/// </param>
	/// <param name="pObjectId">
	/// Pointer to a GUID value that uniquely identifies a peer object with the supplied peer. If this parameter is supplied, the only
	/// peer object returned is the one that matches this GUID.
	/// </param>
	/// <param name="phPeerEnum">
	/// Pointer to the handle for the enumerated set of peer objects that correspond to the GUID returned in pObjectId. Pass this handle
	/// to PeerGetNextItem to obtain each item in the enumerated set.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture, an avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 16K in size.
	/// </para>
	/// <para>
	/// <c>PeerCollabEnumObjects</c> will return all of the objects published for the local peer. The objects can be published by more
	/// than one application.
	/// </para>
	/// <para>
	/// To obtain the individual peer objects, pass the returned handle to PeerGetNextItem. The peer objects are returned as an array of
	/// pointers to the PEER_OBJECT structures. If the endpoint is not publishing any objects, an empty array will be returned. To close
	/// the enumeration and release the resources associated with it, pass this handle to PeerEndEnumeration. Individual items returned
	/// by the enumeration must be released with PeerFreeData.
	/// </para>
	/// <para>To obtain a peer object successfully:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the user is publishing a picture, the picture can be obtained by retrieving the corresponding object. The GUID for the
	/// picture object is PEER_COLLAB_OBJECTID_USER_PICTURE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumobjects NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumObjects( PCPEER_ENDPOINT pcEndpoint, const GUID *pObjectId, HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumObjects")]
	public static extern HRESULT PeerCollabEnumObjects([In, Optional] IntPtr pcEndpoint, [In, Optional] IntPtr pObjectId, out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumObjects</c> function returns an enumeration that contains the peer objects associated with a specific
	/// peer's endpoint.
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>A PEER_ENDPOINT structure that contains the endpoint information for a peer whose objects will be enumerated.</para>
	/// <para>If this parameter is <see langword="null"/> the published objects of the local peer's contacts are returned.</para>
	/// </param>
	/// <param name="pObjectId">
	/// A GUID value that uniquely identifies a peer object with the supplied peer. If this parameter is supplied, the only peer object
	/// returned is the one that matches this GUID.
	/// </param>
	/// <returns>The enumerated set of peer objects that correspond to the GUID returned in pObjectId.</returns>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture, an avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 16K in size.
	/// </para>
	/// <para>
	/// <c>PeerCollabEnumObjects</c> will return all of the objects published for the local peer. The objects can be published by more
	/// than one application.
	/// </para>
	/// <para>To obtain a peer object successfully:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the user is publishing a picture, the picture can be obtained by retrieving the corresponding object. The GUID for the
	/// picture object is PEER_COLLAB_OBJECTID_USER_PICTURE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumobjects NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumObjects( PCPEER_ENDPOINT pcEndpoint, const GUID *pObjectId, HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumObjects")]
	public static SafePeerList<PEER_OBJECT> PeerCollabEnumObjects([In, Optional] PEER_ENDPOINT? pcEndpoint, [In, Optional] Guid? pObjectId) => PeerEnum<PEER_OBJECT>(() =>
	{
		SafeHPEERENUM h;
		if (pcEndpoint.HasValue && pObjectId.HasValue)
			PeerCollabEnumObjects(pcEndpoint.Value, pObjectId.Value, out h).ThrowIfFailed();
		else
		{
			using var e = (SafeHGlobalStruct<PEER_ENDPOINT>)pcEndpoint;
			using var a = (SafeHGlobalStruct<Guid>)pObjectId;
			PeerCollabEnumObjects(e, a, out h).ThrowIfFailed();
		}
		return h;
	});

	/// <summary>
	/// The <c>PeerCollabEnumPeopleNearMe</c> function returns a handle to an enumerated set that contains all of the peer collaboration
	/// network "people near me" endpoints currently available on the subnet of the calling peer.
	/// </summary>
	/// <param name="phPeerEnum">
	/// Pointer to a handle of an enumerated set that contains all of the peer collaboration network "people near me" endpoints
	/// currently available on the subnet of the calling peer.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// To obtain the individual peer "people near me" contacts, pass the returned handle to PeerGetNextItem. An array of pointers to
	/// the PEER_PEOPLE_NEAR_ME structures are returned. To close the enumeration and release the resources associated with it, pass
	/// this handle to PeerEndEnumeration. Individual items returned by the enumeration must be released with PeerFreeData.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumpeoplenearme NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumPeopleNearMe( HPEERENUM *phPeerEnum );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumPeopleNearMe")]
	public static extern HRESULT PeerCollabEnumPeopleNearMe(out SafeHPEERENUM phPeerEnum);

	/// <summary>
	/// The <c>PeerCollabEnumPeopleNearMe</c> function returns an enumerated set that contains all of the peer collaboration network
	/// "people near me" endpoints currently available on the subnet of the calling peer.
	/// </summary>
	/// <returns>
	/// An enumerated set that contains all of the peer collaboration network "people near me" endpoints currently available on the
	/// subnet of the calling peer.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabenumpeoplenearme NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabEnumPeopleNearMe( HPEERENUM *phPeerEnum );
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabEnumPeopleNearMe")]
	public static SafePeerList<PEER_PEOPLE_NEAR_ME> PeerCollabEnumPeopleNearMe() => PeerEnum<PEER_PEOPLE_NEAR_ME>(() => { PeerCollabEnumPeopleNearMe(out var h).ThrowIfFailed(); return h; });

	/// <summary>
	/// <para>
	/// The <c>PeerCollabExportContact</c> function exports the contact data associated with a peer name to a string buffer. The buffer
	/// contains contact data in XML format.
	/// </para>
	/// <para>The PeerCollabAddContact function allows this XML string to be utilized by other peers.</para>
	/// </summary>
	/// <param name="pwzPeerName">
	/// <para>Pointer to zero-terminated Unicode string that contains the name of the peer contact for which to export.</para>
	/// <para>If this parameter is <c>NULL</c>, the "Me" contact information for the calling peer is exported.</para>
	/// </param>
	/// <param name="ppwzContactData">
	/// <para>
	/// Pointer to a zero-terminated string buffer that contains peer contact XML data where the peer names match the string supplied in pwzPeerName.
	/// </para>
	/// <para>The memory returned here can be freed by calling PeerFreeData.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabexportcontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabExportContact( PCWSTR pwzPeerName, PWSTR *ppwzContactData );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabExportContact")]
	public static extern HRESULT PeerCollabExportContact([MarshalAs(UnmanagedType.LPWStr)] string pwzPeerName, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzContactData);

	/// <summary>
	/// The <c>PeerCollabGetAppLaunchInfo</c> function obtains the peer application launch information, including the contact name, the
	/// peer endpoint, and the invitation request.
	/// </summary>
	/// <param name="ppLaunchInfo">
	/// <para>Pointer to a PEER_APP_LAUNCH_INFO structure that receives the peer application launch data.</para>
	/// <para>Free the memory associated with this structure by passing it to PeerFreeData.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The requested data does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// When an application invite is accepted, the application is launched with the information sent as part of the application invite.
	/// This information can be obtained by calling <c>PeerCollabGetAppLaunchInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetapplaunchinfo NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetAppLaunchInfo( PPEER_APP_LAUNCH_INFO *ppLaunchInfo );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetAppLaunchInfo")]
	public static extern HRESULT PeerCollabGetAppLaunchInfo(out SafePeerData ppLaunchInfo);
	//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_APP_LAUNCH_INFO>))] out PEER_APP_LAUNCH_INFO ppLaunchInfo);

	/// <summary>The <c>PeerCollabGetApplicationRegistrationInfo</c> function obtains application-specific registration information.</summary>
	/// <param name="pApplicationId">Pointer to the GUID value that represents a particular peer's application registration flags.</param>
	/// <param name="registrationType">
	/// A PEER_APPLICATION_REGISTRATION_TYPE enumeration value that describes whether the peer's application is registered to the
	/// current user or all users of the local machine.
	/// </param>
	/// <param name="ppApplication">
	/// Pointer to the address of a PEER_APPLICATION_REGISTRATION_INFO structure that contains the information about a peer's specific
	/// registered application. The data returned in this parameter can be freed by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The requested application is not registered for the given registrationType.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// A peer's application has a GUID representing a single application. When an application is registered for a peer, this GUID and
	/// the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the peer can
	/// participate in. To unregister a peer's application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetapplicationregistrationinfo
	// NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerCollabGetApplicationRegistrationInfo( const GUID *pApplicationId,
	// PEER_APPLICATION_REGISTRATION_TYPE registrationType, PPEER_APPLICATION_REGISTRATION_INFO *ppApplication );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetApplicationRegistrationInfo")]
	public static extern HRESULT PeerCollabGetApplicationRegistrationInfo(in Guid pApplicationId, PEER_APPLICATION_REGISTRATION_TYPE registrationType,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_APPLICATION_REGISTRATION_INFO>))] out PEER_APPLICATION_REGISTRATION_INFO ppApplication);
		out SafePeerData ppApplication);

	/// <summary>The <c>PeerCollabGetContact</c> function obtains the information for a peer contact given the peer name of the contact.</summary>
	/// <param name="pwzPeerName">
	/// <para>Pointer to zero-terminated Unicode string that contains the name of the peer contact for which to obtain information.</para>
	/// <para>If this parameter is <c>NULL</c>, the 'Me' contact information for the calling peer is returned.</para>
	/// </param>
	/// <param name="ppContact">
	/// <para>
	/// Pointer to a pointer to a PEER_CONTACT structure. It receives the address of a PEER_CONTACT structure containing peer contact
	/// information for the peer name supplied in pwzPeerName. When this parameter is <c>NULL</c>, this function returns E_INVALIDARG.
	/// </para>
	/// <para>Call PeerFreeData on the address of the PEER_CONTACT structure to free this data.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetcontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetContact( PCWSTR pwzPeerName, PPEER_CONTACT *ppContact );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetContact")]
	public static extern HRESULT PeerCollabGetContact([MarshalAs(UnmanagedType.LPWStr)] string pwzPeerName,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_CONTACT>))] out PEER_CONTACT ppContact);
		out SafePeerData ppContact);

	/// <summary>
	/// The <c>PeerCollabGetEndpointName</c> function retrieves the name of the current endpoint of the calling peer, as previously set
	/// by a call to PeerCollabSetEndpointName.
	/// </summary>
	/// <param name="ppwzEndpointName">
	/// Pointer to a zero-terminated Unicode string name of the peer endpoint currently used by the calling application.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The endpoint name is limited to 25 Unicode characters. To free this data call PeerFreeData.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetendpointname NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetEndpointName( PWSTR *ppwzEndpointName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetEndpointName")]
	public static extern HRESULT PeerCollabGetEndpointName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzEndpointName);

	/// <summary>
	/// The <c>PeerCollabGetEventData</c> function obtains the data associated with a peer collaboration event raised on the peer.
	/// </summary>
	/// <param name="hPeerEvent">The peer collaboration network event handle obtained by a call to PeerCollabRegisterEvent.</param>
	/// <param name="ppEventData">
	/// Pointer to a list of PEER_COLLAB_EVENT_DATA structures that contain data about the peer collaboration network event. These data
	/// structures must be freed after use by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_S_NO_EVENT_DATA</term>
	/// <term>The event data is not present.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgeteventdata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetEventData( HPEEREVENT hPeerEvent, PPEER_COLLAB_EVENT_DATA *ppEventData );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetEventData")]
	public static extern HRESULT PeerCollabGetEventData(HPEEREVENT hPeerEvent,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_COLLAB_EVENT_DATA>))] out PEER_COLLAB_EVENT_DATA ppEventData);
		out SafePeerData ppEventData);

	/// <summary>
	/// The <c>PeerCollabGetInvitationResponse</c> function obtains the response from a peer previously invited to join a peer
	/// collaboration activity.
	/// </summary>
	/// <param name="hInvitation">Handle to an invitation to join a peer collaboration activity.</param>
	/// <param name="ppInvitationResponse">
	/// <para>
	/// Pointer to the address of a PEER_INVITATION_RESPONSE structure that contains an invited peer's response to a previously
	/// transmitted invitation request.
	/// </para>
	/// <para>Free the memory associated with this structure by calling PeerFreeData.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The provided handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The invitation recipient could not be found.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_INVITE_CANCELED</term>
	/// <term>The invitation was previously canceled.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_INVITE_RESPONSE_NOT_AVAILABLE</term>
	/// <term>The response to the peer invitation is not available.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_CONNECTION_FAILED</term>
	/// <term>A connection to the graph or group has failed, or a direct connection in a graph or group has failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function must be called after PeerCollabAsyncInviteContact or PeerCollabAsyncInviteEndpoint is called and the event handle
	/// provided to PeerCollabRegisterEvent is signaled on the peer that sent the invitation.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetinvitationresponse NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetInvitationResponse( HANDLE hInvitation, PPEER_INVITATION_RESPONSE *ppInvitationResponse );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetInvitationResponse")]
	public static extern HRESULT PeerCollabGetInvitationResponse(HANDLE hInvitation,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_INVITATION_RESPONSE>))] out PEER_INVITATION_RESPONSE ppInvitationResponse);
		out SafePeerData ppInvitationResponse);

	/// <summary>
	/// The <c>PeerCollabGetPresenceInfo</c> function retrieves the presence information for the endpoint associated with a specific contact.
	/// </summary>
	/// <param name="pcEndpoint">
	/// Pointer to a PEER_ENDPOINT structure that contains the specific endpoint associated with the contact specified in pcContact for
	/// which presence information must be returned.
	/// </param>
	/// <param name="ppPresenceInfo">
	/// Pointer to the address of the PEER_PRESENCE_INFO structure that contains the requested presence data for the supplied endpoint.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The application did not make a previous call to PeerCollabStartup.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The presence information for the specified endpoint was not found in the peer collaboration network.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>To obtain a peer object successfully:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetpresenceinfo NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetPresenceInfo( PCPEER_ENDPOINT pcEndpoint, PPEER_PRESENCE_INFO *ppPresenceInfo );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetPresenceInfo")]
	public static extern HRESULT PeerCollabGetPresenceInfo(in PEER_ENDPOINT pcEndpoint,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_PRESENCE_INFO>))] out PEER_PRESENCE_INFO ppPresenceInfo);
		out SafePeerData ppPresenceInfo);

	/// <summary>
	/// The <c>PeerCollabGetSigninOptions</c> function obtains the peer's current signed-in peer collaboration network presence options.
	/// </summary>
	/// <param name="pdwSigninOptions">The PEER_SIGNIN_FLAGS enumeration value is returned by this function.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The application did not make a previous call to PeerCollabStartup.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The application has not signed into the peer collaboration network with a previous call to PeerCollabSignIn.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabgetsigninoptions NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabGetSigninOptions( DWORD *pdwSigninOptions );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabGetSigninOptions")]
	public static extern HRESULT PeerCollabGetSigninOptions(out PEER_SIGNIN_FLAGS pdwSigninOptions);

	/// <summary>
	/// The <c>PeerCollabInviteContact</c> function sends an invitation to join a peer collaboration activity to a trusted contact. This
	/// call is synchronous and, if successful, obtains a response from the contact.
	/// </summary>
	/// <param name="pcContact">Pointer to a PEER_CONTACT structure that contains the contact information associated with the invitee.</param>
	/// <param name="pcEndpoint">
	/// Pointer to a PEER_ENDPOINT structure that contains information about the invited peer. This peer is sent an invitation when this
	/// API is called.
	/// </param>
	/// <param name="pcInvitation">
	/// Pointer to a PEER_INVITATION structure that contains the invitation request to send to the endpoint(s) specified in pcEndpoint.
	/// This parameter must not be set to <c>NULL</c>.
	/// </param>
	/// <param name="ppResponse">
	/// <para>Pointer to a PEER_INVITATION_RESPONSE structure that receives an invited peer endpoint's responses to the invitation request.</para>
	/// <para>If this call fails with an error, this parameter will be <c>NULL</c>.</para>
	/// <para>Free the memory returned by calling PeerFreeData.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_TIMEOUT</term>
	/// <term>The recipient of the invitation has not responded within 5 minutes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API ensures the peer that receives the invitation is the contact specified as input. The connection will fail if the
	/// specific contact is not present on the endpoint specified. The use of <c>PeerCollabInviteContact</c> is recommended in place of
	/// the less secure PeerCollabInviteEndpoint.
	/// </para>
	/// <para>
	/// A toast will appear for the recipient of the invitation. This toast will be converted to a dialog box in which the user can
	/// accept or decline the invitation. When the invitation is successfully accepted, the collaborative application is launched on the
	/// recipient's machine.
	/// </para>
	/// <para>
	/// To successfully receive the invitation, the application must be registered on the recipient's machine using
	/// PeerCollabRegisterApplication. It is also possible for the sender of the invite to have failure codes returned because the
	/// recipient has turned off application invites.
	/// </para>
	/// <para>
	/// If the recipient is accepting invitations only from trusted contacts, then the sender of the invite must be added to the contact
	/// store of the recipient machine. The sender must be added to the contact store before the invitation attempt. To add a contact to
	/// the contact store, call PeerCollabAddContact.
	/// </para>
	/// <para>The recipient of the invitation must respond within 5 minutes to avoid timeout.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabinvitecontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabInviteContact( PCPEER_CONTACT pcContact, PCPEER_ENDPOINT pcEndpoint, PCPEER_INVITATION pcInvitation,
	// PPEER_INVITATION_RESPONSE *ppResponse );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabInviteContact")]
	public static extern HRESULT PeerCollabInviteContact(in PEER_CONTACT pcContact, in PEER_ENDPOINT pcEndpoint, in PEER_INVITATION pcInvitation,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_INVITATION_RESPONSE>))] out PEER_INVITATION_RESPONSE ppResponse);
		out SafePeerData ppResponse);

	/// <summary>
	/// The <c>PeerCollabInviteEndpoint</c> function sends an invitation to a specified peer endpoint to join the sender's peer
	/// collaboration activity. This call is synchronous and, if successful, obtains a response from the peer endpoint.
	/// </summary>
	/// <param name="pcEndpoint">
	/// <para>
	/// Pointer to a PEER_ENDPOINT structure that contains information about the invited peer. This peer is sent an invitation when this
	/// API is called.
	/// </para>
	/// <para>This parameter must not be set to <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcInvitation">
	/// Pointer to a PEER_INVITATION structure that contains the invitation request to send to the endpoint specified in pcEndpoint.
	/// This parameter must not be set to <c>NULL</c>.
	/// </param>
	/// <param name="ppResponse">
	/// <para>Pointer to a PEER_INVITATION_RESPONSE structure that receives an invited peer endpoint's responses to the invitation request.</para>
	/// <para>If this call fails with an error, on output this parameter will be <c>NULL</c>.</para>
	/// <para>Free the memory associated with this structure by pass it to PeerFreeData.</para>
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_TIMEOUT</term>
	/// <term>The recipient of the invitation has not responded within 5 minutes.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This API sends an invitation to the endpoint specified as input. It does not guarantee that the recipient of the invite is the
	/// specific contact that the user intended to send the invite to. To ensure that the invitation is sent to the correct contact,
	/// call PeerCollabInviteContact.
	/// </para>
	/// <para>
	/// A toast will appear for the recipient of the invitation. This toast will be converted to a dialog box in which the user can
	/// accept or decline the invitation. When the invitation is successfully accepted, the collaborative application is launched on the
	/// recipient's machine.
	/// </para>
	/// <para>
	/// To successfully receive the invitation, the application must be registered on the recipient's machine using
	/// PeerCollabRegisterApplication. It is also possible for the sender of the invite to have failure codes returned because the
	/// recipient has turned off application invites.
	/// </para>
	/// <para>The recipient of the invitation must respond within 5 minutes to avoid timeout.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabinviteendpoint NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabInviteEndpoint( PCPEER_ENDPOINT pcEndpoint, PCPEER_INVITATION pcInvitation, PPEER_INVITATION_RESPONSE *ppResponse );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabInviteEndpoint")]
	public static extern HRESULT PeerCollabInviteEndpoint(in PEER_ENDPOINT pcEndpoint, in PEER_INVITATION pcInvitation,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_INVITATION_RESPONSE>))] out PEER_INVITATION_RESPONSE ppResponse);
		out SafePeerData ppResponse);

	/// <summary>
	/// The <c>PeerCollabParseContact</c> function parses a Unicode string buffer containing contact XML data into a PEER_CONTACT data structure.
	/// </summary>
	/// <param name="pwzContactData">
	/// Pointer to zero-terminated Unicode string buffer that contains XML contact data as returned by functions like
	/// PeerCollabQueryContactData or PeerCollabExportContact.
	/// </param>
	/// <param name="ppContact">
	/// Pointer to the address of a PEER_CONTACT structure that contain the peer contact information parsed from pwzContactData. Free
	/// the memory allocated by calling PeerFreeData.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabparsecontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabParseContact( PCWSTR pwzContactData, PPEER_CONTACT *ppContact );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabParseContact")]
	public static extern HRESULT PeerCollabParseContact([MarshalAs(UnmanagedType.LPWStr)] string pwzContactData,
		//[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStructMarshaler<PEER_CONTACT>))] out PEER_CONTACT ppContact);
		out SafePeerData ppContact);

	/// <summary>The <c>PeerCollabQueryContactData</c> function retrieves the contact information for the supplied peer endpoint.</summary>
	/// <param name="pcEndpoint">
	/// <para>Pointer to a PEER_ENDPOINT structure that contains the peer endpoint about which to obtain contact information.</para>
	/// <para>If this parameter is set to <c>NULL</c>, the contact information for the current peer endpoint is obtained.</para>
	/// </param>
	/// <param name="ppwzContactData">
	/// Pointer to a zero-terminated Unicode string buffer that contains the contact data for the endpoint supplied in pcEndpoint. Call
	/// PeerFreeData to free the data.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The requested contact data does not exist. Try calling PeerCollabRefreshEndpointData before making another attempt.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve contact data for an endpoint successfully, one of the following must occur:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The endpoint must have been previously obtained by calling PeerCollabEnumEndpoints.</term>
	/// </item>
	/// <item>
	/// <term>The local peer must have subscribed to the endpoint by calling PeerCollabSubscribeEndpointData.</term>
	/// </item>
	/// <item>
	/// <term>The endpoint data must be refreshed by calling PeerCollabRefreshEndpointData successfully.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabquerycontactdata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabQueryContactData( PCPEER_ENDPOINT pcEndpoint, PWSTR *ppwzContactData );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabQueryContactData")]
	public static extern HRESULT PeerCollabQueryContactData(in PEER_ENDPOINT pcEndpoint,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PeerStringMarshaler))] out string ppwzContactData);

	/// <summary>The <c>PeerCollabRefreshEndpointData</c> function updates the calling peer node with new endpoint data.</summary>
	/// <param name="pcEndpoint">
	/// Pointer to a PEER_ENDPOINT structure that contains the updated peer endpoint information for the current peer node.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>PeerCollabRefreshEndpointData</c> allows an application to refresh data associated with the endpoint. Upon completion of the
	/// API, the PEER_EVENT_REQUEST_STATUS_CHANGED event will be raised. The event will contain a success or failure code.
	/// </para>
	/// <para>
	/// On success, the application can call functions like PeerCollabGetPresenceInfo, PeerCollabEnumApplications,
	/// PeerCollabEnumObjects, and PeerCollabQueryContactData to obtain additional data. When the data is no longer needed it can be
	/// deleted by calling PeerCollabDeleteEndpointData.
	/// </para>
	/// <para>
	/// If a peer is subscribed to the endpoint, the subscribed data takes higher precedence than the data that was cached by calling
	/// PeerCollabRefreshEndpointDataand will return <c>PEER_EVENT_REQUEST_STATUS_CHANGED</c>.
	/// </para>
	/// <para>
	/// The <c>PeerCollabRefreshEndpointData</c> API takes a snapshot of the data for the specified endpoint. If endpoint data changes
	/// after this snapshot is taken, the caller will have a stale copy of the data. If PeerCollabRefreshEndpointData is called by an
	/// application multiple times for the same endpoint, the latest data received replaces the data stored from an earlier call to the
	/// API. However, in order to ensure that the caller is notified of any changes and always has the latest copy,
	/// PeerCollabSubscribeEndpointData is recommended instead of <c>PeerCollabRefreshEndpointData</c>.
	/// </para>
	/// <para>The <c>PeerCollabRefreshEndpointData</c> function will timeout at 30 seconds.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabrefreshendpointdata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabRefreshEndpointData( PCPEER_ENDPOINT pcEndpoint );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabRefreshEndpointData")]
	public static extern HRESULT PeerCollabRefreshEndpointData(in PEER_ENDPOINT pcEndpoint);

	/// <summary>
	/// The <c>PeerCollabRegisterApplication</c> function registers an application with the local computer so that it can be launched in
	/// a peer collaboration activity.
	/// </summary>
	/// <param name="pcApplication">
	/// Pointer to a PEER_APPLICATION_REGISTRATION_INFO structure that contains the UUID of the peer's application feature set as well
	/// as any additional peer-specific data.
	/// </param>
	/// <param name="registrationType">
	/// A PEER_APPLICATION_REGISTRATION_TYPE value that describes whether the peer's application is registered to the <c>current
	/// user</c> or <c>all users</c> of the peer's machine.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// The collaboration infrastructure can receive application invites from trusted contacts or from "People Near Me", which are based
	/// on the scope the collaboration infrastructure is signed in with using PeerCollabSignin.
	/// </para>
	/// <para>
	/// A peer's application has a GUID representing a single specific application. When an application is registered for a peer, this
	/// GUID and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the
	/// peer can participate in. To unregister a peer's application, call PeerCollabUnregisterApplication with this GUID.
	/// </para>
	/// <para>
	/// When registering an application, it is recommended that developers specify a relative path, such as <c>%ProgramFiles%</c>,
	/// instead of an absolute path. This prevents application failure due to a change in the location of application files. For
	/// example, if the <c>C:\ProgramFiles</c> directory is moved to <c>E:&lt;/b&gt;.</c>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabregisterapplication NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabRegisterApplication( PCPEER_APPLICATION_REGISTRATION_INFO pcApplication, PEER_APPLICATION_REGISTRATION_TYPE
	// registrationType );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabRegisterApplication")]
	public static extern HRESULT PeerCollabRegisterApplication(in PEER_APPLICATION_REGISTRATION_INFO pcApplication, PEER_APPLICATION_REGISTRATION_TYPE registrationType);

	/// <summary>
	/// The <c>PeerCollabRegisterEvent</c> function registers an application with the peer collaboration infrastructure to receive
	/// callbacks for specific peer collaboration events.
	/// </summary>
	/// <param name="hEvent">
	/// Handle created by CreateEvent that the application is signaled on when an event is triggered. When an application is signaled,
	/// it must call PeerCollabGetEventData to retrieve events until PEER_S_NO_EVENT_DATA is returned.
	/// </param>
	/// <param name="cEventRegistration">The number of PEER_COLLAB_EVENT_REGISTRATION structures in pEventRegistrations.</param>
	/// <param name="pEventRegistrations">
	/// An array of PEER_COLLAB_EVENT_REGISTRATION structures that specify the peer collaboration events for which the application
	/// requests notification.
	/// </param>
	/// <param name="phPeerEvent">
	/// The peer event handle returned by this function. This handle is passed to PeerCollabGetEventData when a peer collaboration
	/// network event is raised on the peer.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_SERVICE_NOT_AVAILABLE</term>
	/// <term>An attempt was made to call PeerCollabRegisterEvent from an elevated process.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If the p2phost.exe service is not running, this function will attempt to launch it for registrations that require p2phost.</para>
	/// <para>
	/// If attempt is made to launch p2phost.exe from an elevated process, an error is returned. As a result, security cannot be
	/// compromised by an application mistakenly granting administrative privileges to p2phost.exe. It is not possible to launch
	/// p2phost.exe in a non-interactive mode, as it needs to display Windows dialog boxes for incoming invites.
	/// </para>
	/// <para>
	/// When <c>PeerCollabRegisterEvent</c> is called on machines under heavy stress, the function may return the
	/// PEER_E_SERVICE_NOT_AVAILABLE error code.
	/// </para>
	/// <para>
	/// An application can call <c>PeerCollabRegisterEvent</c> multiple times, where each call is considered to be a separate
	/// registration. When an event is registered multiple times, each registration receives a copy of the event.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabregisterevent NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabRegisterEvent( HANDLE hEvent, DWORD cEventRegistration, PEER_COLLAB_EVENT_REGISTRATION *pEventRegistrations, HPEEREVENT
	// *phPeerEvent );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabRegisterEvent")]
	public static extern HRESULT PeerCollabRegisterEvent(HANDLE hEvent, uint cEventRegistration, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] PEER_COLLAB_EVENT_REGISTRATION[] pEventRegistrations, out SafeCollabHPEEREVENT phPeerEvent);

	/// <summary>The <c>PeerCollabSetEndpointName</c> function sets the name of the current endpoint used by the peer application.</summary>
	/// <param name="pwzEndpointName">
	/// Pointer to the new name of the current endpoint, represented as a zero-terminated Unicode string. An error is raised if the new
	/// name is the same as the current one. An endpoint name is limited to 255 Unicode characters.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// An endpoint name is set to the machine name by default. However, a new endpoint name set by the <c>PeerCollabSetEndpointName</c>
	/// function will persist across reboots.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabsetendpointname NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabSetEndpointName( PCWSTR pwzEndpointName );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabSetEndpointName")]
	public static extern HRESULT PeerCollabSetEndpointName([MarshalAs(UnmanagedType.LPWStr)] string pwzEndpointName);

	/// <summary>The <c>PeerCollabSetObject</c> function creates or updates a peer data object used in a peer collaboration network.</summary>
	/// <param name="pcObject">Pointer to a PEER_OBJECT structure that contains the peer object on the peer collaboration network.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Peer objects are run-time data items associated with a particular application, such as a picture, an avatar, a certificate, or a
	/// specific description. Each peer object must be smaller than 16K in size and cannot be 0.
	/// </para>
	/// <para>
	/// If an object is already published, <c>PeerCollabSetObject</c> will update the existing object data. The last application that
	/// updates the object will take ownership of the object. As a result, if the application is terminated the object is deleted.
	/// </para>
	/// <para>
	/// If an object's 'published' status is removed due to sign-out rather than the closure of the associated application, the
	/// application is responsible for publishing the object the next time the user signs on.
	/// </para>
	/// <para>
	/// Trusted contacts watching this peer object will have a <c>PEER_EVENT_OBJECT_CHANGED</c> event raised locally, signaling this
	/// peer object's change in status.
	/// </para>
	/// <para><c>PeerCollabSetObject</c> can be used to publish at most 128 objects.</para>
	/// <para>There is one object with a given GUID published at any given time.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabsetobject NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabSetObject( PCPEER_OBJECT pcObject );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabSetObject")]
	public static extern HRESULT PeerCollabSetObject(in PEER_OBJECT pcObject);

	/// <summary>
	/// The <c>PeerCollabSetPresenceInfo</c> function updates the caller's presence information to any contacts watching it.
	/// </summary>
	/// <param name="pcPresenceInfo">
	/// Pointer to a PEER_PRESENCE_INFO structure that contains the new presence information to publish for the calling peer application.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_SIGNED_IN</term>
	/// <term>The operation requires the user to be signed in.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Contacts watching this peer's presence will have a PEER_EVENT_PRESENCE_CHANGED event raised locally that signals this peer's
	/// change in presence status. A peer's presence status cannot be set to offline while signed-in. By default, a peer's presence
	/// status is 'online' and the descriptive text is <c>NULL</c> when signing in.
	/// </para>
	/// <para>Any descriptive text for presence status is limited to 255 Unicode characters.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabsetpresenceinfo NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabSetPresenceInfo( PCPEER_PRESENCE_INFO pcPresenceInfo );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabSetPresenceInfo")]
	public static extern HRESULT PeerCollabSetPresenceInfo(in PEER_PRESENCE_INFO pcPresenceInfo);

	/// <summary>
	/// The <c>PeerCollabShutdown</c> function shuts down the Peer Collaboration infrastructure and releases any resources associated
	/// with it.
	/// </summary>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The application did not make a previous call to PeerCollabStartup.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// A call to this function decreases the number of references to the Peer Collaboration infrastructure by 1. If the reference count
	/// equals 0, then all resources associated with the Peer Collaboration infrastructure are released.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabshutdown NOT_BUILD_WINDOWS_DEPRECATE HRESULT PeerCollabShutdown();
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabShutdown")]
	public static extern HRESULT PeerCollabShutdown();

	/// <summary>
	/// The <c>PeerCollabSignin</c> function signs the peer into a hosted Internet (serverless presence) or subnet ("People Near Me")
	/// peer collaboration network presence provider.
	/// </summary>
	/// <param name="hwndParent">Windows handle to the parent application signing in.</param>
	/// <param name="dwSigninOptions">
	/// PEER_SIGNIN_FLAGS enumeration value that contains the presence provider sign-in options for the calling peer.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The application did not make a previous call to PeerCollabStartup.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_SERVICE_NOT_AVAILABLE</term>
	/// <term>An attempt was made to call PeerCollabSignIn from an elevated process.</term>
	/// </item>
	/// <item>
	/// <term>PEER_S_NO_CONNECTIVITY</term>
	/// <term>The sign-in succeeded, but IPv6 addresses are not available at this time.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If the p2phost.exe service is not running, this function will launch it.</para>
	/// <para>
	/// If an attempt is made to launch the p2phost.exe service from an elevated process, an error is returned. As a result, security
	/// cannot be compromised by an application mistakenly granting administrative privileges to p2phost.exe. It is not possible to
	/// launch p2phost.exe in a non-interactive mode, as it needs to display Windows dialog boxes for incoming invites.
	/// </para>
	/// <para>
	/// Calling <c>PeerCollabSignin</c> displays a sign-in user interface if the user has not authorized automatic sign-in. If
	/// hwndParent is specified, the user interface window will use hwndParent as the parent window.
	/// </para>
	/// <para>
	/// When a user signs in to "People Near Me", the user's display name, machine name, and IP address are published to peers on the
	/// subnet. The user can optionally specify a display picture for publishing. This information is not published if
	/// <c>PeerCollabSignin</c> is not called or the user signs out.
	/// </para>
	/// <para>
	/// Once signed in, the user can view a list of peers signed in on the subnet and available for interaction. This list will be empty
	/// if nobody else has signed in to "People Near Me" on the subnet.
	/// </para>
	/// <para>
	/// Multiple applications can use the infrastructure at any given moment. It is not recommended for a single application to call
	/// PeerCollabSignout, as other applications will not be able to use the infrastructure. Applications must also be prepared to
	/// handle the user signing in and signing out, or situations where a machine goes to sleep or hibernation.
	/// </para>
	/// <para>The <c>PeerCollabSignin</c> function currently requires up to two seconds to complete.</para>
	/// <para>
	/// Display names are not necessarily unique. Users should verify the identity of the person using a display name by e-mail, phone,
	/// or in person before accepting an invitation to interact.
	/// </para>
	/// <para>
	/// To sign out of a peer collaborative network, call PeerCollabSignout with the same set of sign-in options. A user can also sign
	/// out through the user interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabsignin NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabSignin( HWND hwndParent, DWORD dwSigninOptions );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabSignin")]
	public static extern HRESULT PeerCollabSignin([Optional] HWND hwndParent, PEER_SIGNIN_FLAGS dwSigninOptions);

	/// <summary>
	/// The <c>PeerCollabSignout</c> function signs a peer out of a specific type of peer collaboration network presence provider.
	/// </summary>
	/// <param name="dwSigninOptions">
	/// PEER_SIGNIN_FLAGS enumeration value that contains the presence provider sign-in options for the calling peer. This value is
	/// obtained by calling PeerCollabGetSigninOptions from the peer application.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The application did not make a previous call to PeerCollabStartup.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the local peer's collaboration infrastructure is signed out of both Internet and People Near Me presence, all transient
	/// information like objects and the endpoint ID are deleted. Any application that uses this information must republish the
	/// information. A single event that indicates signout is raised, instead of sending multiple individual events for each object or application.
	/// </para>
	/// <para>
	/// Multiple applications can use the infrastructure at any given moment. It is not recommended for a single application to sign
	/// out, as other applications will not be able to use the infrastructure. Applications must also be prepared to handle user sign in
	/// and sign out, or situations where a machine goes to sleep or into hibernation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabsignout NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabSignout( DWORD dwSigninOptions );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabSignout")]
	public static extern HRESULT PeerCollabSignout(PEER_SIGNIN_FLAGS dwSigninOptions);

	/// <summary>The <c>PeerCollabStartup</c> function initializes the Peer Collaboration infrastructure.</summary>
	/// <param name="wVersionRequested">Contains the minimum version of the Peer Collaboration infrastructure requested by the peer.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_UNSUPPORTED_VERSION</term>
	/// <term>The requested version of the Peer Collaboration Infrastructure is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function must be called before any other peer collaboration (PeerCollab*) functions are called.</para>
	/// <para>
	/// When the application no longer requires the Peer Collaboration infrastructure, it must make a corresponding call to
	/// PeerCollabShutdown. If <c>PeerCollabStartup</c> is called multiple times, there must be a separate corresponding call to
	/// <c>PeerCollabShutdown</c>. All of the components of the infrastructure are cleaned up only when the last call to
	/// <c>PeerCollabShutdown</c> occurs.
	/// </para>
	/// <para>The current supported version is <c>1.0</c>. Call
	/// <code>MAKEWORD(1, 0)</code>
	/// to generate this version number WORD value.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabstartup NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabStartup( WORD wVersionRequested );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabStartup")]
	public static extern HRESULT PeerCollabStartup(ushort wVersionRequested = PEER_COLLAB_VERSION);

	/// <summary>The <c>PeerCollabSubscribeEndpointData</c> function creates a subscription to an available endpoint.</summary>
	/// <param name="pcEndpoint">Pointer to a PEER_ENDPOINT structure that contains the peer endpoint used to obtain presence information.</param>
	/// <returns>
	/// <para>
	/// Returns S_OK or PEER_S_SUBSCRIPTION_EXISTS if the function succeeds. Otherwise, the function returns one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>PeerCollabSubscribeEndpointData</c> is an asynchronous call, meaning that the process to subscribe the endpoint has been
	/// started but not necessarily completed when this call returns. An application should wait for PEER_EVENT_REQUEST_STATUS_CHANGED
	/// to get the result of the subscription request.
	/// </para>
	/// <para>This function will timeout at 30 seconds.</para>
	/// <para>
	/// <c>PeerCollabSubscribeEndpointData</c> can be called multiple times from different applications for the same endpoint. Each call
	/// is reference counted; only when the last reference is released is a peer unsubscribed. To release the reference call <c>PeerCollabUnsubscribeEndpointData</c>.
	/// </para>
	/// <para>
	/// When an application exits without calling PeerCollabUnsubscribeEndpointData, all of the references for that application are
	/// released automatically.
	/// </para>
	/// <para>
	/// To successfully call the PeerCollabGetPresenceInfo, PeerCollabEnumApplications, PeerCollabEnumObjects, and
	/// PeerCollabQueryContactData APIs, an application must first call <c>PeerCollabSubscribeEndpointData</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabsubscribeendpointdata NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabSubscribeEndpointData( const PCPEER_ENDPOINT pcEndpoint );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabSubscribeEndpointData")]
	public static extern HRESULT PeerCollabSubscribeEndpointData(in PEER_ENDPOINT pcEndpoint);

	/// <summary>
	/// The <c>PeerCollabUnregisterApplication</c> function unregisters the specific applications of a peer from the local computer.
	/// </summary>
	/// <param name="pApplicationId">Pointer to the GUID value that represents a particular peer's application.</param>
	/// <param name="registrationType">
	/// A PEER_APPLICATION_REGISTRATION_TYPE value that describes whether the peer's application is deregistered for the current user or
	/// all users of the peer's machine.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_FOUND</term>
	/// <term>The application requested to unregister was not registered for the given registrationType.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An application is a set of software or software features available on the peer's endpoint. Commonly, this refers to software
	/// packages that support peer networking activities, like games or other collaborative applications.
	/// </para>
	/// <para>
	/// The collaboration infrastructure can receive application invites from trusted contacts or from "People Near Me", which are based
	/// on what scope the collaboration infrastructure is signed in with using PeerCollabSignin.
	/// </para>
	/// <para>
	/// A peer's application has a GUID representing a single specific application. When application is registered for a peer, this GUID
	/// and the corresponding application can be made available to all trusted contacts of the peer, indicating the activities the peer
	/// can participate in. To unregister a peer's application, call <c>PeerCollabUnregisterApplication</c> with this GUID.
	/// </para>
	/// <para>To unregister the application for all users, the caller of this API must be elevated.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabunregisterapplication NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabUnregisterApplication( const GUID *pApplicationId, PEER_APPLICATION_REGISTRATION_TYPE registrationType );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabUnregisterApplication")]
	public static extern HRESULT PeerCollabUnregisterApplication(in Guid pApplicationId, PEER_APPLICATION_REGISTRATION_TYPE registrationType);

	/// <summary>
	/// The <c>PeerCollabUnregisterEvent</c> function deregisters an application from notification about specific peer collaboration events.
	/// </summary>
	/// <param name="hPeerEvent">
	/// Handle to the peer collaboration event the peer application will deregister. This handle is obtained with a previous call to PeerCollabRegisterEvent.
	/// </param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabunregisterevent NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabUnregisterEvent( HPEEREVENT hPeerEvent );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabUnregisterEvent")]
	public static extern HRESULT PeerCollabUnregisterEvent(IntPtr hPeerEvent);

	/// <summary>The <c>PeerCollabUnsubscribeEndpointData</c> function removes a subscription to an endpoint created with PeerCollabSubscribeEndpointData.</summary>
	/// <param name="pcEndpoint">Pointer to a PEER_ENDPOINT structure that contains the peer endpoint that is used to remove the subscription.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEER_E_NOT_INITIALIZED</term>
	/// <term>The Windows Peer infrastructure is not initialized. Calling the relevant initialization function is required.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Each call is reference counted. As a result, the peer is unsubscribed only when the last reference is released.</para>
	/// <para>The <c>PeerCollabUnsubscribeEndpointData</c> function will timeout at 30 seconds.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabunsubscribeendpointdata NOT_BUILD_WINDOWS_DEPRECATE
	// HRESULT PeerCollabUnsubscribeEndpointData( const PCPEER_ENDPOINT pcEndpoint );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabUnsubscribeEndpointData")]
	public static extern HRESULT PeerCollabUnsubscribeEndpointData(in PEER_ENDPOINT pcEndpoint);

	/// <summary>
	/// The <c>PeerCollabUpdateContact</c> function updates the information associated with a peer contact specified in the local
	/// contact store of the caller.
	/// </summary>
	/// <param name="pContact">Pointer to a PEER_CONTACT structure that contains the updated information for a specific peer contact.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Otherwise, the function returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory to support this operation.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One of the arguments is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the contact provided is the 'Me' contact, only the nickname, display name and email address can be changed. If a nickname is
	/// changed for a contact signed in to "People Near Me", the structure PEER_EVENT_PEOPLE_NEAR_ME_CHANGED_DATA with changeType of
	/// PEER_CHANGE_UPDATED will be raised.
	/// </para>
	/// <para>The <c>PeerCollabUpdateContact</c> function will timeout at 30 seconds.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/p2p/nf-p2p-peercollabupdatecontact NOT_BUILD_WINDOWS_DEPRECATE HRESULT
	// PeerCollabUpdateContact( PCPEER_CONTACT pContact );
	[DllImport(Lib_P2P, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("p2p.h", MSDNShortId = "NF:p2p.PeerCollabUpdateContact")]
	public static extern HRESULT PeerCollabUpdateContact(in PEER_CONTACT pContact);

	/// <summary>Provides a handle to a peer collaboration network event.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HPEEREVENT : IHandle
	{
		private IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HPEEREVENT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HPEEREVENT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HPEEREVENT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HPEEREVENT NULL => new HPEEREVENT(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HPEEREVENT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HPEEREVENT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HPEEREVENT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPEEREVENT(IntPtr h) => new HPEEREVENT(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HPEEREVENT h1, HPEEREVENT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HPEEREVENT h1, HPEEREVENT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is HPEEREVENT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HPEEREVENT"/> that is disposed using <see cref="PeerCollabUnregisterEvent"/>.</summary>
	public class SafeCollabHPEEREVENT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeCollabHPEEREVENT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeCollabHPEEREVENT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCollabHPEEREVENT"/> class.</summary>
		private SafeCollabHPEEREVENT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeCollabHPEEREVENT"/> to <see cref="HPEEREVENT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HPEEREVENT(SafeCollabHPEEREVENT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PeerCollabUnregisterEvent(handle).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for P2P collaboration handle that is disposed using <see cref="PeerCollabCloseHandle"/>.</summary>
	public class SafePeerCollabHandle : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafePeerCollabHandle"/> class.</summary>
		private SafePeerCollabHandle() : base() { }

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => PeerCollabCloseHandle(handle).Succeeded;
	}
}