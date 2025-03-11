using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.PInvoke;

/// <summary>Items from the Drt.dll</summary>
public static partial class Drt
{
	private const string Lib_Drt = "drt.dll";
	private const string Lib_DrtProv = "drtprov.dll";
	private const string Lib_DrtTrans = "drttransport.dll";

	/// <summary/>
	public const uint DRT_PAYLOAD_REVOKED = (1 << 0);
	/// <summary/>
	public const uint DRT_MIN_ROUTING_ADDRESSES = 1;
	/// <summary/>
	public const uint DRT_MAX_ROUTING_ADDRESSES = 20;
	/// <summary/>
	public const uint DRT_MAX_PAYLOAD_SIZE = 5120;
	/// <summary/>
	public const uint DRT_MAX_INSTANCE_PREFIX_LEN = 128;
	/// <summary/>
	public const uint DRT_LINK_LOCAL_ISATAP_SCOPEID = 0xffffffff;

	/// <summary>Increments the count of references for the Bootstrap Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Contains the pvContext value from DRT_BOOTSTRAP_PROVIDER.</param>
	/// <returns></returns>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate HRESULT DRT_BOOTSTRAP_PROVIDER_Attach([In] IntPtr pvContext);

	/// <summary>Decrements the count of references for the Bootstrap Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Contains the pvContext value from DRT_BOOTSTRAP_PROVIDER.</param>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DRT_BOOTSTRAP_PROVIDER_Detach([In] IntPtr pvContext);

	/// <summary>Ends the resolution of an endpoint.</summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="ResolveContext">
	/// The <c>BOOTSTRAP_RESOLVE_CONTEXT</c> received from the Resolve function of the specified bootstrap provider.
	/// </param>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DRT_BOOTSTRAP_PROVIDER_EndResolve([In] IntPtr pvContext, [In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext);

	/// <summary>Called by the DRT infrastructure to supply configuration information about upcoming name resolutions.</summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="fSplitDetect">Specifies if the resolve operation is being utilized for network split detection and recovery.</param>
	/// <param name="timeout">Specifies the maximum time a resolve should take before timing out. This value is represented in milliseconds.</param>
	/// <param name="cMaxResults">Specifies the maximum number of results to return during the resolve operation.</param>
	/// <param name="ResolveContext">Pointer to resolver specific data.</param>
	/// <param name="fFatalError">
	/// If the bootstrap provider encounters an irrecoverable error, this parameter must be set to <c>TRUE</c> when the function
	/// complete in order for the DRT to transition to the faulted state. The <c>HRESULT</c> that is made available to the higher layer
	/// application for debugging will appear in the <c>hr</c> member of the DRT_EVENT_DATA structure associated with the event
	/// signaling the transition to the faulted state. This bootstrap provider function should not return S_OK if setting the
	/// fFatalError flag to <c>TRUE</c>.
	/// </param>
	/// <returns></returns>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate HRESULT DRT_BOOTSTRAP_PROVIDER_InitResolve([In] IntPtr pvContext, [MarshalAs(UnmanagedType.Bool)] bool fSplitDetect, uint timeout, uint cMaxResults,
		out DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, [MarshalAs(UnmanagedType.Bool)] out bool fFatalError);

	/// <summary>
	/// Called by the DRT infrastructure to issue a resolution to determine the endpoints of nodes already active in the DRT cloud.
	/// </summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="pvCallbackContext">Pointer to the context data that is passed back to the callback defined by the next parameter.</param>
	/// <param name="callback">A BOOTSTRAP_RESOLVE_CALLBACK that is called back for each result and DRT_E_NO_MORE.</param>
	/// <param name="ResolveContext">Pointer to resolver specific data.</param>
	/// <param name="fFatalError">
	/// If the bootstrap provider encounters an irrecoverable error, this parameter must be set to <c>TRUE</c> when the function
	/// complete in order for the DRT to transition to the faulted state. The <c>HRESULT</c> that is made available to the higher layer
	/// application for debugging will appear in the <c>hr</c> member of the DRT_EVENT_DATA structure associated with the event
	/// signaling the transition to the faulted state. This bootstrap provider function should not return S_OK if setting the
	/// fFatalError flag to <c>TRUE</c>.
	/// </param>
	/// <returns></returns>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate HRESULT DRT_BOOTSTRAP_PROVIDER_IssueResolve([In] IntPtr pvContext, [In] IntPtr pvCallbackContext, DRT_BOOTSTRAP_RESOLVE_CALLBACK callback,
		[In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, [MarshalAs(UnmanagedType.Bool)] out bool fFatalError);

	/// <summary>
	/// Registers an endpoint with the bootstrapping mechanism. This process makes it possible for other nodes find the endpoint via the
	/// bootstrap resolver.
	/// </summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="pAddressList">Pointer to <see cref="SOCKET_ADDRESS_LIST"/> containing the list of addresses to register with the bootstrapping mechanism.</param>
	/// <returns></returns>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate HRESULT DRT_BOOTSTRAP_PROVIDER_Register([In] IntPtr pvContext, [In] IntPtr pAddressList);

	/// <summary>
	/// This function deregisters an endpoint with the bootstrapping mechanism. As a result, other nodes will be unable to find the
	/// local node via the bootstrap resolver.
	/// </summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DRT_BOOTSTRAP_PROVIDER_Unregister([In] IntPtr pvContext);

	/// <summary>Callback for some DRT functions.</summary>
	/// <param name="hr">The error.</param>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="pAddresses">Pointer to <see cref="SOCKET_ADDRESS_LIST"/> containing the list of addresses to register with the bootstrapping mechanism.</param>
	/// <param name="fFatalError">
	/// If the bootstrap provider encounters an irrecoverable error, this parameter must be set to <c>TRUE</c> when the function
	/// complete in order for the DRT to transition to the faulted state. The <c>HRESULT</c> that is made available to the higher layer
	/// application for debugging will appear in the <c>hr</c> member of the DRT_EVENT_DATA structure associated with the event
	/// signaling the transition to the faulted state. This bootstrap provider function should not return S_OK if setting the
	/// fFatalError flag to <c>TRUE</c>.
	/// </param>
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void DRT_BOOTSTRAP_RESOLVE_CALLBACK(HRESULT hr, IntPtr pvContext, [In] IntPtr pAddresses, [MarshalAs(UnmanagedType.Bool)] BOOL fFatalError);

	/// <summary>Increments the count of references for the Security Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_Attach([In] IntPtr pvContext);

	/// <summary>
	/// Called when the DRT receives a message containing encrypted data. This function is only called when the DRT is operating in the
	/// <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security mode defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pKeyToken">
	/// Contains the encrypted session key that can be decrypted by the recipient of the message and used to decrypt the protected fields.
	/// </param>
	/// <param name="pvKeyContext">Contains the context passed into DrtRegisterKey when the key was registered.</param>
	/// <param name="dwBuffers">Contains the size of pData buffer.</param>
	/// <param name="pData">Contains the decrypted data upon completion of the function.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_DecryptData([In] IntPtr pvContext, in DRT_DATA pKeyToken, [In] IntPtr pvKeyContext, [In] uint dwBuffers,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] DRT_DATA[] pData);

	/// <summary>Decrements the count of references for the Security Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	public delegate void DRT_SECURITY_PROVIDER_Detach([In] IntPtr pvContext);

	/// <summary>
	/// Called when the DRT sends a message containing data that must be encrypted. This function is only called when the DRT is
	/// operating in the <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security mode defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pRemoteCredential">Contains the credential of the peer that will receive the protected message.</param>
	/// <param name="dwBuffers">Contains the length of the pDataBuffers and pEncryptedBuffers.</param>
	/// <param name="pDataBuffers">Contains the unencrypted buffer.</param>
	/// <param name="pEncryptedBuffers">Contains the encrypted content upon completion of the function.</param>
	/// <param name="pKeyToken">
	/// Contains the encrypted session key that can be decrypted by the recipient of the message and used to decrypted the protected fields.
	/// </param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_EncryptData([In] IntPtr pvContext, in DRT_DATA pRemoteCredential, [In] uint dwBuffers,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DRT_DATA[] pDataBuffers,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] DRT_DATA[] pEncryptedBuffers, out DRT_DATA pKeyToken);

	/// <summary>Called to release resources previously allocated for a security provider function.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pv">Specifies what data to free.</param>
	public delegate void DRT_SECURITY_PROVIDER_FreeData([In] IntPtr pvContext, [In, Optional] IntPtr pv);

	/// <summary>
	/// Called when the DRT must provide a credential used to authorize the local node. This function is only called when the DRT is
	/// operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pSelfCredential">Contains the serialized credential upon completion of the function.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_GetSerializedCredential([In] IntPtr pvContext, out DRT_DATA pSelfCredential);

	/// <summary>Called to register a key with the Security Provider.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pRegistration">
	/// Pointer to the DRT_REGISTRATION structure created by an application and passed to the DrtRegisterKey function.
	/// </param>
	/// <param name="pvKeyContext">Pointer to the context data created by an application and passed to the DrtRegisterKey function.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_RegisterKey([In] IntPtr pvContext, in DRT_REGISTRATION pRegistration, [In, Optional] IntPtr pvKeyContext);

	/// <summary>
	/// Called when an Authority message is about to be sent on the wire. It is responsible for securing the data before it is sent, and
	/// for packing the service addresses, revoked flag, nonce, and other application data into the Secured Address Payload.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pvKeyContext">Contains the context passed into DrtRegisterKey when the key was registered.</param>
	/// <param name="bProtocolMajor">Pointer to the byte array that represents the protocol major version.</param>
	/// <param name="bProtocolMinor">Pointer to the byte array that represents the protocol minor version.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Any DRT specific flags, currently defined only to be the revoked or deleted flag that need to be packed, secured and sent to
	/// another instance for processing.
	/// </para>
	/// <para><c>Note</c> Currently the only allowed value is: <c>DRT_PAYLOAD_REVOKED</c></para>
	/// </param>
	/// <param name="pKey">Pointer to the key to which this payload is registered.</param>
	/// <param name="pPayload">Pointer to the payload specified by the application when calling DrtRegisterKey.</param>
	/// <param name="pAddressList">Pointer to the service addresses that are placed in the Secured Address Payload.</param>
	/// <param name="pNonce">
	/// Pointer to the nonce that was sent in the original <c>Inquire</c> or <c>Lookup</c> message. This value is fixed at 16 bytes.
	/// </param>
	/// <param name="pSecuredAddressPayload">
	/// Pointer to the payload to send on the wire which contains the service addresses, revoked flag, nonce, and other data required by
	/// the security provider. <c>pSecuredAddressPayload.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="pClassifier">
	/// Pointer to the classifier to send in the Authority message. <c>pClassifier.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="pSecuredPayload">
	/// Pointer to the application data payload received in the Authority message. After validation, the original data (after
	/// decryption, removal of signature, and so on.) is output as pPayload. <c>pSecuredPayload.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="pCertChain">
	/// Pointer to the cert chain to send in the Authority message. <c>pCertChain.pb</c> is allocated by the security provider.
	/// </param>
	/// <returns></returns>
	public unsafe delegate HRESULT DRT_SECURITY_PROVIDER_SecureAndPackPayload([In] IntPtr pvContext, [In, Optional] IntPtr pvKeyContext, byte bProtocolMajor, byte bProtocolMinor,
		uint dwFlags, in DRT_DATA pKey, [In, Optional] DRT_DATA* pPayload, [In, Optional] IntPtr pAddressList,
		in DRT_DATA pNonce, out DRT_DATA pSecuredAddressPayload, [Out, Optional] DRT_DATA* pClassifier,
		[Out, Optional] DRT_DATA* pSecuredPayload, [Out, Optional] DRT_DATA* pCertChain);

	/// <summary>
	/// Called when the DRT must sign a data blob for inclusion in a DRT protocol message. This function is only called when the DRT is
	/// operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="dwBuffers">Contains the size of the pDataBuffers buffer.</param>
	/// <param name="pDataBuffers">Contains the data to be signed.</param>
	/// <param name="pKeyIdentifier">
	/// Upon completion of this function, contains an index that can be used to select from multiple credentials for use in calculating
	/// the signature.
	/// </param>
	/// <param name="pSignature">Upon completion of this function, contains the signature data.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_SignData([In] IntPtr pvContext, [In] uint dwBuffers,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DRT_DATA[] pDataBuffers, out DRT_DATA pKeyIdentifier,
		out DRT_DATA pSignature);

	/// <summary>Called to deregister a key with the Security Provider.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pKey">Pointer to the key to which the payload is registered.</param>
	/// <param name="pvKeyContext">Pointer to the context data created by the application and passed to DrtRegisterKey.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_UnregisterKey([In] IntPtr pvContext, in DRT_DATA pKey, [In, Optional] IntPtr pvKeyContext);

	/// <summary>
	/// Called when an Authority message is received on the wire. It is responsible for validating the data received, and for unpacking
	/// the service addresses, revoked flag, and nonce from the Secured Address Payload.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pSecuredAddressPayload">
	/// Pointer to the payload received on the wire that contains the service addresses, revoked flag, nonce, and any other data
	/// required by the security provider.
	/// </param>
	/// <param name="pCertChain">Pointer to the cert chain received in the authority message.</param>
	/// <param name="pClassifier">Pointer to the classifier received in the authority message.</param>
	/// <param name="pNonce">
	/// Pointer to the nonce that was sent in the original <c>Inquire</c> or <c>Lookup</c> message. This value must be compared to the
	/// value embedded in the Secured Address Payload to ensure they are the same. This value is fixed at 16 bytes.
	/// </param>
	/// <param name="pSecuredPayload">
	/// Pointer to the application data payload received in the Authority message. After validation, the original data (after
	/// decryption, removal of signature, and so on.) is output as pPayload.
	/// </param>
	/// <param name="pbProtocolMajor">
	/// Pointer to the byte array that represents the protocol major version. This is packed in every DRT packet to identify the version
	/// of the security provider in use when a single DRT instance is supporting multiple Security Providers.
	/// </param>
	/// <param name="pbProtocolMinor">
	/// Pointer to the byte array that represents the protocol minor version. This is packed in every DRT packet to identify the version
	/// of the security provider in use when a single DRT instance is supporting multiple Security Providers.
	/// </param>
	/// <param name="pKey">Pointer to the key to which the payload is registered.</param>
	/// <param name="pPayload">
	/// Pointer to the original payload specified by the remote application. <c>pPayload.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="ppPublicKey">Pointer to a pointer to the number of service addresses embedded in the secured address payload.</param>
	/// <param name="ppAddressList">
	/// Pointer to a pointer to the service addresses that are embedded in the Secured Address Payload. <c>pAddresses</c> is allocated
	/// by the security provider.
	/// </param>
	/// <param name="pdwFlags">
	/// Any DRT flags currently defined only to be the revoked or deleted flag that need to be unpacked for the local DRT instance processing.
	/// <para><c>Note</c> Currently the only allowed value is: <c>DRT_PAYLOAD_REVOKED (1)</c></para>
	/// </param>
	/// <returns></returns>
	public unsafe delegate HRESULT DRT_SECURITY_PROVIDER_ValidateAndUnpackPayload([In] IntPtr pvContext, in DRT_DATA pSecuredAddressPayload, [In, Optional] DRT_DATA* pCertChain,
		[In, Optional] DRT_DATA* pClassifier, [In, Optional] DRT_DATA* pNonce, [In, Optional] DRT_DATA* pSecuredPayload,
		[Out] byte* pbProtocolMajor, [Out] byte* pbProtocolMinor, out DRT_DATA pKey, [Out, Optional] DRT_DATA* pPayload,
		[Out] CERT_PUBLIC_KEY_INFO** ppPublicKey, [Out, Optional] void** ppAddressList, out uint pdwFlags);

	/// <summary>Called when the DRT must validate a credential provided by a peer node.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pRemoteCredential">Contains the serialized credential provided by the peer node.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_ValidateRemoteCredential([In] IntPtr pvContext, in DRT_DATA pRemoteCredential);

	/// <summary>
	/// Called when the DRT must verify a signature calculated over a block of data included in a DRT message. This function is only
	/// called when the DRT is operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes
	/// defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="dwBuffers">Contains the size of the pDataBuffers buffer.</param>
	/// <param name="pDataBuffers">Contains the data over which the signature was calculated.</param>
	/// <param name="pRemoteCredentials">Contains the credentials of the remote node used to calculate the signature.</param>
	/// <param name="pKeyIdentifier">Contains an index that may be used to select from multiple credentials provided in pRemoteCredentials.</param>
	/// <param name="pSignature">Contains the signature to be verified.</param>
	/// <returns></returns>
	public delegate HRESULT DRT_SECURITY_PROVIDER_VerifyData([In] IntPtr pvContext, [In] uint dwBuffers,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DRT_DATA[] pDataBuffers, in DRT_DATA pRemoteCredentials,
		in DRT_DATA pKeyIdentifier, in DRT_DATA pSignature);

	/// <summary>
	/// The <c>DRT_ADDRESS_FLAGS</c> enumeration defines the set of responses that may be returned by an intermediate node when
	/// performing a search for a key.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_address_flags typedef enum _DRT_ADDRESS_FLAGS {
	// DRT_ADDRESS_FLAG_ACCEPTED, DRT_ADDRESS_FLAG_REJECTED, DRT_ADDRESS_FLAG_UNREACHABLE, DRT_ADDRESS_FLAG_LOOP,
	// DRT_ADDRESS_FLAG_TOO_BUSY, DRT_ADDRESS_FLAG_BAD_VALIDATE_ID, DRT_ADDRESS_FLAG_SUSPECT_UNREGISTERED_ID, DRT_ADDRESS_FLAG_INQUIRE }
	// DRT_ADDRESS_FLAGS, *PDRT_ADDRESS_FLAGS;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt._DRT_ADDRESS_FLAGS")]
	[Flags]
	public enum DRT_ADDRESS_FLAGS
	{
		/// <summary>The response provided by this machine was successfully used to make progress towards the search target.</summary>
		DRT_ADDRESS_FLAG_ACCEPTED = 0x01,

		/// <summary>
		/// The response provided by this machine was not used in the search. This machine may have provided the address of a node
		/// publishing a key numerically farther from the target than other nodes already contacted.
		/// </summary>
		DRT_ADDRESS_FLAG_REJECTED = 0x02,

		/// <summary>This machine did not respond.</summary>
		DRT_ADDRESS_FLAG_UNREACHABLE = 0x04,

		/// <summary>
		/// The response provided by this machine was not used in the search. This machine provided the address of a node that has
		/// already been contacted.
		/// </summary>
		DRT_ADDRESS_FLAG_LOOP = 0x08,

		/// <summary>This machine indicated that it does not have sufficient resources to process the query.</summary>
		DRT_ADDRESS_FLAG_TOO_BUSY = 0x10,

		/// <summary>
		/// This machine is not publishing the key expected by the local DRT instance. As a result, it may not be able to provide useful information.
		/// </summary>
		DRT_ADDRESS_FLAG_BAD_VALIDATE_ID = 0x20,

		/// <summary>This machine has reason to believe that the target key has been unregistered.</summary>
		DRT_ADDRESS_FLAG_SUSPECT_UNREGISTERED_ID = 0x40,

		/// <summary>This machine was asked to provide proof of ownership of its key.</summary>
		DRT_ADDRESS_FLAG_INQUIRE = 0x80,
	}

	/// <summary>The <c>DRT_EVENT_TYPE</c> enumeration defines the set of events that can be raised by the Distributed Routing Table.</summary>
	/// <remarks>The event handle passed to DrtOpen is signaled with an event specified by the <c>DRT_EVENT_TYPE</c> enumeration.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_event_type typedef enum drt_event_type_tag {
	// DRT_EVENT_STATUS_CHANGED, DRT_EVENT_LEAFSET_KEY_CHANGED, DRT_EVENT_REGISTRATION_STATE_CHANGED } DRT_EVENT_TYPE;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt.drt_event_type_tag")]
	public enum DRT_EVENT_TYPE
	{
		/// <summary>The status of the local DRT instance has changed.</summary>
		DRT_EVENT_STATUS_CHANGED,

		/// <summary>A key or node was changed from the DRT leaf set of the local node.</summary>
		DRT_EVENT_LEAFSET_KEY_CHANGED,

		/// <summary>A locally published key is no longer resolvable by other nodes.</summary>
		DRT_EVENT_REGISTRATION_STATE_CHANGED,
	}

	/// <summary>
	/// The <c>DRT_LEAFSET_KEY_CHANGE_TYPE</c> enumeration defines the set of changes that can occur on nodes in the leaf set of a
	/// locally registered key.
	/// </summary>
	/// <remarks>
	/// This enumeration is used to determine the event type returned by DrtGetEventData, which is called with the event handle passed
	/// to DrtOpen.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_leafset_key_change_type typedef enum
	// drt_leafset_key_change_type_tag { DRT_LEAFSET_KEY_ADDED, DRT_LEAFSET_KEY_DELETED } DRT_LEAFSET_KEY_CHANGE_TYPE;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt.drt_leafset_key_change_type_tag")]
	public enum DRT_LEAFSET_KEY_CHANGE_TYPE
	{
		/// <summary>A node was added to the DRT leaf set of the local node.</summary>
		DRT_LEAFSET_KEY_ADDED,

		/// <summary>A node was deleted from the DRT leaf set of the local node.</summary>
		DRT_LEAFSET_KEY_DELETED,
	}

	/// <summary>The <c>DRT_MATCH_TYPE</c> enumeration defines the exactness of a search result returned by DrtGetSearchResult after initiating a search with the DrtStartSearch API.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_match_type
	// typedef enum drt_match_type_tag { DRT_MATCH_EXACT = 0, DRT_MATCH_NEAR = 1, DRT_MATCH_INTERMEDIATE = 2 } DRT_MATCH_TYPE;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt.drt_match_type_tag")]
	public enum DRT_MATCH_TYPE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The node found is publishing the target key or is publishing a key within the specified range.</para>
		/// </summary>
		DRT_MATCH_EXACT,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The node found is publishing the numerically closest key to the specified target key.</para>
		/// </summary>
		DRT_MATCH_NEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// The node returned is an intermediate node. An application will receive this node match type if <c>fIterative</c> is set to
		/// <see langword="true"/>.
		/// </para>
		/// </summary>
		DRT_MATCH_INTERMEDIATE,
	}

	/// <summary>The <c>DRT_REGISTRATION_STATE</c> enumeration defines the set of legal states for a registered key.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_registration_state typedef enum _DRT_REGISTRATION_STATE {
	// DRT_REGISTRATION_STATE_UNRESOLVEABLE } DRT_REGISTRATION_STATE, *PDRT_REGISTRATION_STATE;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt._DRT_REGISTRATION_STATE")]
	public enum DRT_REGISTRATION_STATE
	{
		/// <summary>
		/// The locally registered key is no longer resolvable by other nodes. The Distributed Routing Table signals this state when the
		/// local security provider is unable to generate an authentication token for the locally registered key. For example, if the
		/// Derived Key Security Provider is used, this state is signaled when the certificate used to authenticate expires.
		/// </summary>
		DRT_REGISTRATION_STATE_UNRESOLVEABLE = 1,
	}

	/// <summary>
	/// The <c>DRT_SCOPE</c> enumeration defines the set of IPv6 scopes in which DRT operates while using the IPv6 UDP transport created
	/// by DrtCreateIpv6UdpTransport.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_scope typedef enum drt_scope_tag { DRT_GLOBAL_SCOPE,
	// DRT_SITE_LOCAL_SCOPE, DRT_LINK_LOCAL_SCOPE } DRT_SCOPE;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt.drt_scope_tag")]
	public enum DRT_SCOPE
	{
		/// <summary>Uses the global scope.</summary>
		DRT_GLOBAL_SCOPE = 1,

		/// <summary>The DRT_SITE_LOCAL_SCOPE has been deprecated and should not be used.</summary>
		DRT_SITE_LOCAL_SCOPE,

		/// <summary>Uses the link local scope.</summary>
		DRT_LINK_LOCAL_SCOPE,
	}

	/// <summary>
	/// The <c>DRT_SECURITY_MODE</c> enumeration defines possible security modes for the DRT. The security mode is specified by a field
	/// of the DRT_SETTINGS structure.
	/// </summary>
	/// <remarks>
	/// The more secure a DRT security mode, the more of a computational load exists for nodes participating in the DRT. More bandwidth
	/// is also consumed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_security_mode typedef enum drt_security_mode_tag {
	// DRT_SECURE_RESOLVE, DRT_SECURE_MEMBERSHIP, DRT_SECURE_CONFIDENTIALPAYLOAD } DRT_SECURITY_MODE;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt.drt_security_mode_tag")]
	public enum DRT_SECURITY_MODE
	{
		/// <summary>
		/// Nodes must authenticate the keys they publish. Nodes are not required to authenticate themselves when performing searches.
		/// </summary>
		DRT_SECURE_RESOLVE,

		/// <summary>
		/// Nodes must authenticate the keys they publish. Nodes must also authenticate themselves when performing searches.
		/// Unauthorized nodes cannot search for keys and cannot retrieve the data associated with published keys.
		/// </summary>
		DRT_SECURE_MEMBERSHIP,

		/// <summary>
		/// Nodes must authenticate the keys they publish. Nodes must also authenticate themselves when performing searches. Encryption
		/// is required for all data associated with published keys prior to transmission between DRT nodes. Unauthorized nodes cannot
		/// search for keys, cannot retrieve the data associated with published keys, and cannot retrieve data by observing network
		/// traffic between other DRT nodes.
		/// </summary>
		DRT_SECURE_CONFIDENTIALPAYLOAD,
	}

	/// <summary>The <c>DRT_STATUS</c> enumeration defines the status of a local DRT instance.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ne-drt-drt_status typedef enum drt_status_tag { DRT_ACTIVE, DRT_ALONE,
	// DRT_NO_NETWORK, DRT_FAULTED } DRT_STATUS;
	[PInvokeData("drt.h", MSDNShortId = "NE:drt.drt_status_tag")]
	public enum DRT_STATUS
	{
		/// <summary>
		/// The local node is connected to the DRT mesh and participating in the DRT system. This is also an indication that remote
		/// nodes exist and are present in the cache of the local node.
		/// </summary>
		DRT_ACTIVE = 0,

		/// <summary>
		/// The local node is participating in the DRT system, but is waiting for remote nodes to join the DRT mesh. This is an
		/// indication that remote nodes do not exist, or are not yet present in the cache of the local node.
		/// </summary>
		DRT_ALONE = 1,

		/// <summary>The local node does not have network connectivity.</summary>
		DRT_NO_NETWORK = 10,

		/// <summary>
		/// A critical error has occurred in the local DRT instance. The DrtClose function must be called, after which an attempt to
		/// re-open the DRT can be made.
		/// </summary>
		DRT_FAULTED = 20,
	}

	/// <summary>The <c>DrtClose</c> function closes the local instance of the DRT.</summary>
	/// <param name="hDrt">Handle to the DRT instance.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The hDrt handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtclose void DrtClose( HDRT hDrt );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtClose")]
	public static extern void DrtClose(HDRT hDrt);

	/// <summary>
	/// The <c>DrtContinueSearch</c> function continues an iterative search for a key.This function is used only when the
	/// <c>fIterative</c> flag is set to 'true' in the associated DRT_SEARCH_INFO structure. Call this after getting a
	/// <c>DRT_MATCH_INTERMEDIATE</c> search result.
	/// </summary>
	/// <param name="hSearchContext">Handle to the search context to close. This parameter is returned by the DrtStartSearch API.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The hSearchContext handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>This search is not an iterative search.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcontinuesearch HRESULT DrtContinueSearch( HDRT_SEARCH_CONTEXT
	// hSearchContext );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtContinueSearch")]
	public static extern HRESULT DrtContinueSearch(HDRT_SEARCH_CONTEXT hSearchContext);

	/// <summary>
	/// The <c>DrtCreateDerivedKey</c> function creates a key that can be utilized by DrtRegisterKey when the DRT is using a derived key
	/// security provider.
	/// </summary>
	/// <param name="pLocalCert">
	/// Pointer to the certificate that is the "local" portion of the chain. The root of this chain must match the root specified by
	/// pRootCert in DrtCreateDerivedKeySecurityProvider. This certificate is used to generate a key that is used to register and prove
	/// "key ownership" with the DRT.
	/// </param>
	/// <param name="pKey">Pointer to the created key.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>DRT_E_CAPABILITY_MISMATCH</term>
	/// <term/>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcreatederivedkey HRESULT DrtCreateDerivedKey( PCCERT_CONTEXT
	// pLocalCert, DRT_DATA *pKey );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtCreateDerivedKey")]
	public static extern HRESULT DrtCreateDerivedKey(PCCERT_CONTEXT pLocalCert, [Out] SafeDRT_DATA pKey);

	/// <summary>
	/// The <c>DrtCreateDerivedKeySecurityProvider</c> function creates the derived key security provider for a Distributed Routing Table.
	/// </summary>
	/// <param name="pRootCert">
	/// Pointer to the certificate that is the "root" portion of the chain. This is used to ensure that keys derived from the same chain
	/// can be verified.
	/// </param>
	/// <param name="pLocalCert">Pointer to the DRT_SECURITY_PROVIDER module to be included in the DRT_SETTINGS structure.</param>
	/// <param name="ppSecurityProvider">Receives a pointer to the created security provider.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pRootCert is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system could not allocate memory for the security provider.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_CAPABILITY_MISMATCH</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_CERT_CHAIN</term>
	/// <term>No certificate store attached or there is an error in the certificate chain.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The security provider created by this function is specific to the DRT it was created for. It cannot be shared by multiple DRT instances.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcreatederivedkeysecurityprovider HRESULT
	// DrtCreateDerivedKeySecurityProvider( PCCERT_CONTEXT pRootCert, PCCERT_CONTEXT pLocalCert, DRT_SECURITY_PROVIDER
	// **ppSecurityProvider );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtCreateDerivedKeySecurityProvider")]
	public static extern HRESULT DrtCreateDerivedKeySecurityProvider(PCCERT_CONTEXT pRootCert, PCCERT_CONTEXT pLocalCert, out IntPtr ppSecurityProvider);

	/// <summary>
	/// The <c>DrtCreateDnsBootstrapResolver</c> function creates a bootstrap resolver that will use the GetAddrInfo system function to
	/// resolve the hostname of a will known node already present in the DRT mesh.
	/// </summary>
	/// <param name="port">Specifies the port to which the DRT protocol is bound on the well known node.</param>
	/// <param name="pwszAddress">Specifies the hostname of the well known node.</param>
	/// <param name="ppModule">Pointer to the DRT_BOOTSTRAP_PROVIDER module to be included in the DRT_SETTINGS structure.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pwszAddress is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system could not allocate memory for the provider.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> This function may also return errors from underlying calls to WSAStartup and StringCbPrintfW.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcreatednsbootstrapresolver HRESULT
	// DrtCreateDnsBootstrapResolver( USHORT port, PCWSTR pwszAddress, DRT_BOOTSTRAP_PROVIDER **ppModule );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtCreateDnsBootstrapResolver")]
	public static extern HRESULT DrtCreateDnsBootstrapResolver(ushort port, [MarshalAs(UnmanagedType.LPWStr)] string pwszAddress, out IntPtr ppModule);

	/// <summary>The <c>DrtCreateIpv6UdpTransport</c> function creates a transport based on the IPv6 UDP protocol.</summary>
	/// <param name="scope">The <c>DRT_SCOPE</c> enumeration that specifies the IPv6 scope in which the DRT is to operate.</param>
	/// <param name="dwScopeId">
	/// <para>The identifier that uniquely specifies the interface the scope is associated with.</para>
	/// <para>
	/// For the Global scope this parameter is always the "GLOBAL_" ID and is optional when using only the global scope. For the link
	/// local scope, this parameter represents the interface associated with the Network Interface Card on which the link local scope exists.
	/// </para>
	/// </param>
	/// <param name="dwLocalityThreshold">
	/// The identifier that specifies how Locality information based on IpV6 addresses is used when caching neighbors. By default, the
	/// DRT gives preference to neighbors that have an IPv6 address with a prefix in common with the local machine.
	/// </param>
	/// <param name="pwPort">Pointer to the port utilized by the local DRT instance.</param>
	/// <param name="phTransport">Pointer to a DRT transport handle specified in the DRT_SETTINGS structure.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system cannot allocate memory for the provider.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_PORT</term>
	/// <term>pwPort is NULL.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_TRANSPORT_PROVIDER</term>
	/// <term>hTransport is NULL.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SCOPE</term>
	/// <term>The specified scope is not DRT_GLOBAL_SCOPE, DRT_SITE_LOCAL_SCOPE or DRT_LINK_LOCAL_SCOPE.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_UNEXPECTED</term>
	/// <term>An unexpected error has occurred. See TraceError for reason.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> This function may also return errors from underlying calls to NotifyUnicastIpAddressChange,WSAStartup,
	/// GetAdaptersAddresses, setsockopt, WSASocket, Bind, WSAIoctl, CreateThreadpoolIo, CreateThreadpoolCleanupGroup and CreateTimerQueue.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The default IPv6 UDP Transport created by this function is specific to the DRT it is created for. As a result it cannot be
	/// re-used across multiple DRTs.
	/// </para>
	/// <para>
	/// When using the Distributed Routing Table API in Windows XP with Service Pack 2 (SP2), support of the IPv6 protocol must be
	/// enabled for the creation of a transport using <c>DrtCreateIpv6UdpTransport</c> to be successful.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcreateipv6udptransport HRESULT DrtCreateIpv6UdpTransport(
	// DRT_SCOPE scope, ULONG dwScopeId, ULONG dwLocalityThreshold, USHORT *pwPort, HDRT_TRANSPORT *phTransport );
	[DllImport(Lib_DrtTrans, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtCreateIpv6UdpTransport")]
	public static extern HRESULT DrtCreateIpv6UdpTransport(DRT_SCOPE scope, uint dwScopeId, uint dwLocalityThreshold, ref ushort pwPort, out SafeHDRT_TRANSPORT phTransport);

	/// <summary>
	/// The <c>DrtCreateNullSecurityProvider</c> function creates a null security provider. This security provider does not require nodes to
	/// authenticate keys.
	/// </summary>
	/// <param name="ppSecurityProvider">Pointer to the DRT_SETTINGS structure.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>E_OUTOFMEMORY</c></description>
	/// <description>The system cannot allocate memory for the provider.</description>
	/// </item>
	/// <item>
	/// <description><c>DRT_E_INVALID_ARG</c></description>
	/// <description><c>ppDrtSecurityProvider</c> is <c>NULL</c>.</description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcreatenullsecurityprovider
	// HRESULT DrtCreateNullSecurityProvider( [out] DRT_SECURITY_PROVIDER **ppSecurityProvider );
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtCreateNullSecurityProvider")]
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT DrtCreateNullSecurityProvider(out IntPtr ppSecurityProvider);

	/// <summary>
	/// The <c>DrtCreatePnrpBootstrapResolver</c> function creates a bootstrap resolver based on the Peer Name Resolution Protocol (PNRP).
	/// </summary>
	/// <param name="fPublish">
	/// If <c>TRUE</c>, the PeerName contained in pwzPeerName and passed with the PNRP Bootstrap Resolver is published by the local DRT
	/// using PNRP. This node will be resolvable by other nodes using the PNRP bootstrap provider, and will assist other nodes
	/// attempting to bootstrap
	/// </param>
	/// <param name="pwzPeerName">
	/// The name of the peer to search for in the PNRP cloud. This string has a maximum limit of 137 unicode characters
	/// </param>
	/// <param name="pwzCloudName">
	/// <para>The name of the cloud to search for in for the DRT corresponding to the MeshName.</para>
	/// <para>
	/// This string has a maximum limit of 256 unicode characters. If left blank the PNRP Bootstrap Provider will use all PNRP clouds available.
	/// </para>
	/// </param>
	/// <param name="pwzPublishingIdentity">
	/// The PeerIdentity that is publishing into the PNRP cloud utilized for bootstrapping. This string has a maximum limit of 137
	/// unicode characters. It is important to note that if fPublish is set to <c>TRUE</c>, the PublishingIdentity must be allowed to
	/// publish the PeerName specified.
	/// </param>
	/// <param name="ppResolver">A pointer to the created PNRP bootstrap resolver which is used in the DRT_SETTINGS structure.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system cannot allocate memory for the provider.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pwzPeerName is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_S_RETRY</term>
	/// <term>Underlying calls to PeerPnrpStartup or PeerIdentityGetCryptKey return a transient error. Try calling this function again.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> This function may also surface errors returned by underlying calls to PeerPnrpStartup or PeerIdentityGetCryptKey.</para>
	/// </returns>
	/// <remarks>
	/// The default PNRP Bootstrap Resolver created by this function is specific to the DRT it is created for. As a result it cannot be
	/// re-used across multiple DRTs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtcreatepnrpbootstrapresolver HRESULT
	// DrtCreatePnrpBootstrapResolver( BOOL fPublish, PCWSTR pwzPeerName, PCWSTR pwzCloudName, PCWSTR pwzPublishingIdentity,
	// DRT_BOOTSTRAP_PROVIDER **ppResolver );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtCreatePnrpBootstrapResolver")]
	public static extern HRESULT DrtCreatePnrpBootstrapResolver([MarshalAs(UnmanagedType.Bool)] bool fPublish, [MarshalAs(UnmanagedType.LPWStr)] string pwzPeerName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzCloudName, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwzPublishingIdentity,
		out IntPtr ppResolver);

	/// <summary>
	/// The <c>DrtDeleteDerivedKeySecurityProvider</c> function deletes a derived key security provider for a Distributed Routing Table.
	/// </summary>
	/// <param name="pSecurityProvider">Pointer to a DRT_SECURITY_PROVIDER specifying the security provider to delete.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletederivedkeysecurityprovider void
	// DrtDeleteDerivedKeySecurityProvider( DRT_SECURITY_PROVIDER *pSecurityProvider );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteDerivedKeySecurityProvider")]
	public static extern void DrtDeleteDerivedKeySecurityProvider(in DRT_SECURITY_PROVIDER pSecurityProvider);

	/// <summary>
	/// The <c>DrtDeleteDerivedKeySecurityProvider</c> function deletes a derived key security provider for a Distributed Routing Table.
	/// </summary>
	/// <param name="pSecurityProvider">Pointer to a DRT_SECURITY_PROVIDER specifying the security provider to delete.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletederivedkeysecurityprovider void
	// DrtDeleteDerivedKeySecurityProvider( DRT_SECURITY_PROVIDER *pSecurityProvider );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteDerivedKeySecurityProvider")]
	public static extern void DrtDeleteDerivedKeySecurityProvider([In] IntPtr pSecurityProvider);

	/// <summary>The <c>DrtDeleteDnsBootstrapResolver</c> function deletes a DNS Bootstrap Provider instance.</summary>
	/// <param name="pResolver">Pointer to a DRT_BOOTSTRAP_PROVIDER instance specifying the security provider to delte.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletednsbootstrapresolver void DrtDeleteDnsBootstrapResolver(
	// DRT_BOOTSTRAP_PROVIDER *pResolver );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteDnsBootstrapResolver")]
	public static extern void DrtDeleteDnsBootstrapResolver(in DRT_BOOTSTRAP_PROVIDER pResolver);

	/// <summary>The <c>DrtDeleteDnsBootstrapResolver</c> function deletes a DNS Bootstrap Provider instance.</summary>
	/// <param name="pResolver">Pointer to a DRT_BOOTSTRAP_PROVIDER instance specifying the security provider to delte.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletednsbootstrapresolver void DrtDeleteDnsBootstrapResolver(
	// DRT_BOOTSTRAP_PROVIDER *pResolver );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteDnsBootstrapResolver")]
	public static extern void DrtDeleteDnsBootstrapResolver([In] IntPtr pResolver);

	/// <summary>The <c>DrtDeleteIpv6UdpTransport</c> function deletes a transport based on the IPv6 UDP protocol.</summary>
	/// <param name="hTransport">The DRT transport handle specifying the transport to delete.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DRT_E_INVALID_TRANSPORT_PROVIDER</term>
	/// <term>hTransport is NULL or invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_EXECUTING_CALLBACK</term>
	/// <term>The transport provider is currently executing a method.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_STILL_BOUND</term>
	/// <term>The transport is still bound.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORTPROVIDER_IN_USE</term>
	/// <term>All clients have not called Release on the transport.</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> This function may also surface errors returned by underlying calls to PeerPnrpStartup or PeerIdentityGetCryptKey.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeleteipv6udptransport HRESULT DrtDeleteIpv6UdpTransport(
	// HDRT_TRANSPORT hTransport );
	[DllImport(Lib_DrtTrans, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteIpv6UdpTransport")]
	public static extern HRESULT DrtDeleteIpv6UdpTransport(HDRT_TRANSPORT hTransport);

	/// <summary>The <c>DrtDeleteNullSecurityProvider</c> function deletes a null security provider for a Distributed Routing Table.</summary>
	/// <param name="pSecurityProvider">Pointer to a DRT_SECURITY_PROVIDER structure specifying the security provider to delete.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletenullsecurityprovider void DrtDeleteNullSecurityProvider(
	// DRT_SECURITY_PROVIDER *pSecurityProvider );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteNullSecurityProvider")]
	public static extern void DrtDeleteNullSecurityProvider(in DRT_SECURITY_PROVIDER pSecurityProvider);

	/// <summary>The <c>DrtDeleteNullSecurityProvider</c> function deletes a null security provider for a Distributed Routing Table.</summary>
	/// <param name="pSecurityProvider">Pointer to a DRT_SECURITY_PROVIDER structure specifying the security provider to delete.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletenullsecurityprovider void DrtDeleteNullSecurityProvider(
	// DRT_SECURITY_PROVIDER *pSecurityProvider );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeleteNullSecurityProvider")]
	public static extern void DrtDeleteNullSecurityProvider([In] IntPtr pSecurityProvider);

	/// <summary>
	/// The <c>DrtDeletePnrpBootstrapResolver</c> function deletes a bootstrap resolver based on the Peer Name Resolution Protocol (PNRP).
	/// </summary>
	/// <param name="pResolver">Pointer to the created PNRP bootstrap resolver to be deleted.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletepnrpbootstrapresolver void DrtDeletePnrpBootstrapResolver(
	// DRT_BOOTSTRAP_PROVIDER *pResolver );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeletePnrpBootstrapResolver")]
	public static extern void DrtDeletePnrpBootstrapResolver(in DRT_BOOTSTRAP_PROVIDER pResolver);

	/// <summary>
	/// The <c>DrtDeletePnrpBootstrapResolver</c> function deletes a bootstrap resolver based on the Peer Name Resolution Protocol (PNRP).
	/// </summary>
	/// <param name="pResolver">Pointer to the created PNRP bootstrap resolver to be deleted.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtdeletepnrpbootstrapresolver void DrtDeletePnrpBootstrapResolver(
	// DRT_BOOTSTRAP_PROVIDER *pResolver );
	[DllImport(Lib_DrtProv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtDeletePnrpBootstrapResolver")]
	public static extern void DrtDeletePnrpBootstrapResolver([In] IntPtr pResolver);

	/// <summary>
	/// The <c>DrtEndSearch</c> function cancels a search for a key in a DRT. This API can be called at any point after a search is issued.
	/// </summary>
	/// <param name="hSearchContext">Handle to the search context to end. This parameter is returned from DrtStartSearch.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The hSearchContext handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The DRT infrastructure is unaware of the requested search.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>Calling the <c>DrtEndSearch</c> function will stop the return of search results via DRT_SEARCH_RESULT.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtendsearch HRESULT DrtEndSearch( HDRT_SEARCH_CONTEXT
	// hSearchContext );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtEndSearch")]
	public static extern HRESULT DrtEndSearch(HDRT_SEARCH_CONTEXT hSearchContext);

	/// <summary>The <c>DrtGetEventData</c> function retrieves event data associated with a signaled event.</summary>
	/// <param name="hDrt">Handle to the Distributed Routing Table instance for which the event occurred.</param>
	/// <param name="ulEventDataLen">The size, in bytes, of the pEventData buffer.</param>
	/// <param name="pEventData">Pointer to a DRT_EVENT_DATA structure that contains the event data.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The DRT infrastructure is unaware of the requested search.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>The hDrt handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INSUFFICIENT_BUFFER</term>
	/// <term>The provided buffer is insufficient in size.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_NO_MORE</term>
	/// <term>No more event data available.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgeteventdata HRESULT DrtGetEventData( HDRT hDrt, ULONG
	// ulEventDataLen, DRT_EVENT_DATA *pEventData );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetEventData")]
	public static extern HRESULT DrtGetEventData(HDRT hDrt, uint ulEventDataLen, [Out] IntPtr pEventData);

	/// <summary>
	/// The <c>DrtGetEventDataSize</c> function returns the size of the DRT_EVENT_DATA structure associated with a signaled event.
	/// </summary>
	/// <param name="hDrt">Handle to the Distributed Routing Table instance for which the event occurred.</param>
	/// <param name="pulEventDataLen">The size, in bytes, of the event data.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The DRT infrastructure is unaware of the requested search.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pulEventDataLen is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hDrt is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_NO_MORE</term>
	/// <term>There is no more event data available.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgeteventdatasize HRESULT DrtGetEventDataSize( HDRT hDrt, ULONG
	// *pulEventDataLen );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetEventDataSize")]
	public static extern HRESULT DrtGetEventDataSize(HDRT hDrt, out uint pulEventDataLen);

	/// <summary>
	/// The <c>DrtGetInstanceName</c> function retrieves the full name of the Distributed Routing Table instance that corresponds to the
	/// specified DRT handle.
	/// </summary>
	/// <param name="hDrt">Handle to the DRT instance.</param>
	/// <param name="ulcbInstanceNameSize">The length of the pwzDrtInstanceName buffer.</param>
	/// <param name="pwzDrtInstanceName">Contains the complete name of the DRT instance associated with hDRT.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pwzDrtInstanceName is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hDrt is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INSUFFICIENT_BUFFER</term>
	/// <term>The pwzDrtInstanceName buffer is insufficient in size.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgetinstancename HRESULT DrtGetInstanceName( HDRT hDrt, ULONG
	// ulcbInstanceNameSize, PWSTR pwzDrtInstanceName );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetInstanceName")]
	public static extern HRESULT DrtGetInstanceName(HDRT hDrt, uint ulcbInstanceNameSize, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwzDrtInstanceName);

	/// <summary>The <c>DrtGetInstanceNameSize</c> function returns the size of the Distributed Routing Table instance name.</summary>
	/// <param name="hDrt">Handle to the target DRT instance.</param>
	/// <param name="pulcbInstanceNameSize">The length of the DRT instance name.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pulcbInstanceNameSize is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hDrt handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgetinstancenamesize HRESULT DrtGetInstanceNameSize( HDRT hDrt,
	// ULONG *pulcbInstanceNameSize );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetInstanceNameSize")]
	public static extern HRESULT DrtGetInstanceNameSize(HDRT hDrt, out uint pulcbInstanceNameSize);

	/// <summary>The <c>DrtGetSearchPath</c> function returns a list of nodes contacted during the search operation.</summary>
	/// <param name="hSearchContext">Handle to the search context. This parameter is returned by the DrtStartSearch function.</param>
	/// <param name="ulSearchPathSize">The size of the search path which represents the number of nodes utilized in the search operation.</param>
	/// <param name="pSearchPath">Pointer to a DRT_ADDRESS_LIST structure containing the list of addresses.</param>
	/// <returns>This function returns S_OK on success.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgetsearchpath HRESULT DrtGetSearchPath( HDRT_SEARCH_CONTEXT
	// hSearchContext, ULONG ulSearchPathSize, DRT_ADDRESS_LIST *pSearchPath );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetSearchPath")]
	public static extern HRESULT DrtGetSearchPath(HDRT_SEARCH_CONTEXT hSearchContext, uint ulSearchPathSize, [Out] IntPtr pSearchPath);

	/// <summary>
	/// The <c>DrtGetSearchPathSize</c> function returns the size of the search path, which represents the number of nodes utilized in
	/// the search operation.
	/// </summary>
	/// <param name="hSearchContext">Handle to the search context. This parameter is returned by the DrtStartSearch function.</param>
	/// <param name="pulSearchPathSize">Pointer to a <c>ULONG</c> value that indicates the size of the search path.</param>
	/// <returns>This function returns S_OK on success.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgetsearchpathsize HRESULT DrtGetSearchPathSize(
	// HDRT_SEARCH_CONTEXT hSearchContext, ULONG *pulSearchPathSize );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetSearchPathSize")]
	public static extern HRESULT DrtGetSearchPathSize(HDRT_SEARCH_CONTEXT hSearchContext, out uint pulSearchPathSize);

	/// <summary>The <c>DrtGetSearchResult</c> function allows the caller to retrieve the search result(s).</summary>
	/// <param name="hSearchContext">Handle to the search context to close. This parameter is returned by the DrtStartSearch function.</param>
	/// <param name="ulSearchResultSize">Pointer to the DRT_SEARCH_RESULT structure containing the search result.</param>
	/// <param name="pSearchResult">Receives a pointer to a DRT_SEARCH_RESULT structure containing the search results.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>ulSearchPathSize is less than the size of DRT_SEARCH_RESULT.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hSearchContext is an invalid handle.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_FAULTED</term>
	/// <term>the DRT cloud is in the faulted state.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INSUFFICIENT_BUFFER</term>
	/// <term>The provided buffer is insufficient in size to contain the search result.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_NO_MORE</term>
	/// <term>There are no more results to return.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TIMEOUT</term>
	/// <term>The search failed because it timed out.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_SEARCH_IN_PROGRESS</term>
	/// <term>The search is currently in progress.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgetsearchresult HRESULT DrtGetSearchResult( HDRT_SEARCH_CONTEXT
	// hSearchContext, ULONG ulSearchResultSize, DRT_SEARCH_RESULT *pSearchResult );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetSearchResult")]
	public static extern HRESULT DrtGetSearchResult(HDRT_SEARCH_CONTEXT hSearchContext, uint ulSearchResultSize, [Out] IntPtr pSearchResult);

	/// <summary>The <c>DrtGetSearchResultSize</c> function returns the size of the next available search result.</summary>
	/// <param name="hSearchContext">Handle to the search context to close. This parameter is returned by the DrtStartSearch function.</param>
	/// <param name="pulSearchResultSize">Holds the size of the next available search result.</param>
	/// <returns>
	/// <para>Returns S_OK if the function succeeds. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>pulSearchResultSize is NULL.</term>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hSearchContext is an invalid handle.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_FAULTED</term>
	/// <term>The DRT cloud is in the faulted state.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_NO_MORE</term>
	/// <term>There are no more results to return.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TIMEOUT</term>
	/// <term>The search failed because it timed out.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_SEARCH_IN_PROGRESS</term>
	/// <term>The search is still in progress.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The application will receive S_OK and continue to loop using the <c>DrtGetSearchResultSize</c> and DrtGetSearchResult functions
	/// as long as the queue contains the search results. When the queue is empty the <c>DrtGetSearchResult</c> function will return
	/// DRT_E_SEARCH_IN_PROGRESS or DRT_E_NO_MORE.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtgetsearchresultsize HRESULT DrtGetSearchResultSize(
	// HDRT_SEARCH_CONTEXT hSearchContext, ULONG *pulSearchResultSize );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtGetSearchResultSize")]
	public static extern HRESULT DrtGetSearchResultSize(HDRT_SEARCH_CONTEXT hSearchContext, out uint pulSearchResultSize);

	/// <summary>
	/// The <c>DrtOpen</c> function creates a local Distributed Routing Table instance against criteria specified by the DRT_SETTINGS structure.
	/// </summary>
	/// <param name="pSettings">
	/// Pointer to the DRT_SETTINGS structure which specifies the settings used for the creation of the DRT instance.
	/// </param>
	/// <param name="hEvent">Handle to the event signaled when an event occurs.</param>
	/// <param name="pvContext">User defined context data which is passed to the application via events.</param>
	/// <param name="phDrt">The new handle associated with the DRT. This is used in all future operations on the DRT instance.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>phDrt is NULL.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SETTINGS</term>
	/// <term>pSettings is NULL or the dwSize member value of DRT_SETTINGS is not equal to the size of the DRT_SETTINGS object.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_KEY_SIZE</term>
	/// <term>cbKey is not equal to 256 bits.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_MAX_ADDRESSES</term>
	/// <term>The ulMaxRoutingAddresses member of DRT_SETTINGS specifies less than 1 or more than 20 as the maximum number of addresses.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_TRANSPORT_PROVIDER</term>
	/// <term>The hTransport member in DRT_SETTINGS is NULL or some fields of the Transport are NULL</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SECURITY_MODE</term>
	/// <term>The eSecurityMode member of DRT_SETTINGS specifies an invalid security mode.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SECURITY_PROVIDER</term>
	/// <term>The pSecurityProvider member of DRT_SETTINGS is NULL.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_BOOTSTRAP_PROVIDER</term>
	/// <term>The pBootstrapProvider member of DRT_SETTINGS is NULL or some fields of the bootstrap provider are NULL.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_INSTANCE_PREFIX</term>
	/// <term>The size of the pwzDrtInstancePrefix specified in DRT_SETTINGS is larger than the maximum prefix length (128).</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system cannot allocate memory for this operation.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_BOOTSTRAPPROVIDER_IN_USE</term>
	/// <term>The bootstrap provider is already attached.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_SECURITYPROVIDER_IN_USE</term>
	/// <term>The security provider is already attached.</term>
	/// </item>
	/// <item>
	/// <term>DRT_TRANSPORTPROVIDER_IN_USE</term>
	/// <term>The transport provider is already attached.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_CERT_CHAIN</term>
	/// <term>The certification chain is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_CAPABILITY_MISMATCH</term>
	/// <term>Local certificate cannot be NULL in DRT_SECURE_MEMBERSHIP and DRT_SECURE_CONFIDENTIALPAYLOAD security.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_SHUTTING_DOWN</term>
	/// <term>Transport is shutting down.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_ALREADY_BOUND</term>
	/// <term>Trasport is already bound.</term>
	/// </item>
	/// <item>
	/// <term>DRT_S_RETRY</term>
	/// <term>Bootstrap provider failed to locate other nodes, but may be successful in a second attempt.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_INVALID_ARGUMENT</term>
	/// <term>Transport provider parameter is NULL or invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORTPROVIDER_NOT_ATTACHED</term>
	/// <term>Transport is not attached.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unexpected fatal error occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// After <c>DrtOpen</c> is called, the DRT will begin the bootstrapping procedure and move to the <c>DRT_ACTIVE</c> or
	/// <c>DRT_ALONE</c> state, depending on the success of the bootstrap.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtopen HRESULT DrtOpen( const DRT_SETTINGS *pSettings, HANDLE
	// hEvent, const PVOID pvContext, HDRT *phDrt );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtOpen")]
	public static extern HRESULT DrtOpen(in DRT_SETTINGS pSettings, HANDLE hEvent, [In, Optional] IntPtr pvContext, out SafeHDRT phDrt);

	/// <summary>The <c>DrtRegisterKey</c> function registers a key in the DRT.</summary>
	/// <param name="hDrt">A pointer to a handle returned by the DrtOpen function.</param>
	/// <param name="pRegistration">A pointer to a handle to the DRT_REGISTRATION structure.</param>
	/// <param name="pvKeyContext">
	/// Pointer to the context data associated with the key in the DRT. This data is passed to the key-specific functions of the
	/// security provider.
	/// </param>
	/// <param name="phKeyRegistration">Pointer to a handle for a key that has been registered.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hDrt is an invalid handle or phKeyRegistration is an invalid handle</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_KEY_SIZE</term>
	/// <term>
	/// The size of cb value of the key member of the DRT_REGISTRATION structure is not equal to 256 bits or the pb value of the key
	/// member of the DRT_REGISTRATION structure is NULL..
	/// </term>
	/// </item>
	/// <item>
	/// <term>DRT_E_FAULTED</term>
	/// <term>The DRT cloud is in the faulted state.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_DUPLICATE_KEY</term>
	/// <term>The key is already registered.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_CERT_CHAIN</term>
	/// <term>The provided certification chain is invalid.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_CAPABILITY_MISMATCH</term>
	/// <term>Supplied certificate provider is not AES capable.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_KEY</term>
	/// <term>Supplied key does not match generated key.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_NO_DEST_ADDRESSES</term>
	/// <term>Valid address not found.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_SHUTTING_DOWN</term>
	/// <term>Transport is shutting down.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_TRANSPORT_PROVIDER</term>
	/// <term>Transport provider is NULL.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORTPROVIDER_NOT_ATTACHED</term>
	/// <term>Transport is not attached.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_SECURITYPROVIDER_NOT_ATTACHED</term>
	/// <term>Security provider is not attached.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_TRANSPORT_NOT_BOUND</term>
	/// <term>Transport is not currently bound.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unexpected fatal error has occurred.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c><c>DrtRegisterKey</c> may also surface errors from underlying calls to CryptGetProvParam, CertGetCertificateChain,
	/// CertOpenStore, CertAddCertificateContextToStore, CryptContextAddRef, CryptAcquireCertificatePrivateKey, CertSaveStore, WSAIoctl,
	/// CryptImportPublicKeyInfoEx2, NCryptSignHash, CertEnumCertificatesInStore, BCryptGetProperty, BCryptGenRandom,
	/// BCryptGenerateSymmetricKey and BCryptEncrypt.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A node can register keys while in the <c>DRT_ACTIVE</c>, <c>DRT_ALONE</c>, or <c>DRT_NO_NETWORK</c> state. However, keys
	/// registered in <c>DRT_ALONE</c> and <c>DRT_NO_NETWORK</c> states can only be recognized by other DRTs after the local node has
	/// transitioned to <c>DRT_ACTIVE</c>.
	/// </para>
	/// <para>
	/// To update an existing key, an application must first deregister the key with DrtUnregisterKey before calling
	/// <c>DrtRegisterKey</c> to register the updated key.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtregisterkey HRESULT DrtRegisterKey( HDRT hDrt, DRT_REGISTRATION
	// *pRegistration, PVOID pvKeyContext, HDRT_REGISTRATION_CONTEXT *phKeyRegistration );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtRegisterKey")]
	public static extern HRESULT DrtRegisterKey(HDRT hDrt, in DRT_REGISTRATION pRegistration, [In, Optional] IntPtr pvKeyContext, out HDRT_REGISTRATION_CONTEXT phKeyRegistration);

	/// <summary>The <c>DrtStartSearch</c> function searches the DRT for a key using criteria specified in the DRT_SEARCH_INFO structure.</summary>
	/// <param name="hDrt">The DRT handle returned by the DrtOpen function.</param>
	/// <param name="pKey">Pointer to the DRT_DATA structure containing the key.</param>
	/// <param name="pInfo">Pointer to the DRT_SEARCH_INFO structure that specifies the properties of the search.</param>
	/// <param name="timeout">Specifies the milliseconds until the search is stopped.</param>
	/// <param name="hEvent">
	/// Handle to the event that is signaled when the <c>DrtStartSearch</c> API finishes or an intermediate node is found.
	/// </param>
	/// <param name="pvContext">Pointer to the context data passed to the application through the event.</param>
	/// <param name="hSearchContext">Handle used in the call to DrtEndSearch.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hDrt is an invalid handle or phKeyRegistration is an invalid handle</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_KEY_SIZE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SEARCH_INFO</term>
	/// <term>pInfo was passed in but the dwSize of pInfo is not equal to size of the DRT_SEARCH_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_MAX_ENDPOINTS</term>
	/// <term>
	/// pInfo was passed in but max endpoints (cMaxEndpoints) is set to 0 inside pInfo or pInfo was passed in but cMaxEndpoints is
	/// greater than 1 with fAnyMatchInRange set to TRUE
	/// </term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SEARCH_RANGE</term>
	/// <term>Min and max key values are equal, but target is different.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_FAULTED</term>
	/// <term>The DRT cloud is in the faulted state.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The DRT is shutting down.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unexpected fatal error has occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtstartsearch HRESULT DrtStartSearch( HDRT hDrt, DRT_DATA *pKey,
	// const DRT_SEARCH_INFO *pInfo, ULONG timeout, HANDLE hEvent, const PVOID pvContext, HDRT_SEARCH_CONTEXT *hSearchContext );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtStartSearch")]
	public static extern HRESULT DrtStartSearch(HDRT hDrt, in DRT_DATA pKey, in DRT_SEARCH_INFO pInfo, uint timeout, HEVENT hEvent,
		[In, Optional] IntPtr pvContext, out HDRT_SEARCH_CONTEXT hSearchContext);

	/// <summary>The <c>DrtStartSearch</c> function searches the DRT for a key using criteria specified in the DRT_SEARCH_INFO structure.</summary>
	/// <param name="hDrt">The DRT handle returned by the DrtOpen function.</param>
	/// <param name="pKey">Pointer to the DRT_DATA structure containing the key.</param>
	/// <param name="pInfo">Pointer to the DRT_SEARCH_INFO structure that specifies the properties of the search.</param>
	/// <param name="timeout">Specifies the milliseconds until the search is stopped.</param>
	/// <param name="hEvent">
	/// Handle to the event that is signaled when the <c>DrtStartSearch</c> API finishes or an intermediate node is found.
	/// </param>
	/// <param name="pvContext">Pointer to the context data passed to the application through the event.</param>
	/// <param name="hSearchContext">Handle used in the call to DrtEndSearch.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hDrt is an invalid handle or phKeyRegistration is an invalid handle</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_KEY_SIZE</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SEARCH_INFO</term>
	/// <term>pInfo was passed in but the dwSize of pInfo is not equal to size of the DRT_SEARCH_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_MAX_ENDPOINTS</term>
	/// <term>
	/// pInfo was passed in but max endpoints (cMaxEndpoints) is set to 0 inside pInfo or pInfo was passed in but cMaxEndpoints is
	/// greater than 1 with fAnyMatchInRange set to TRUE
	/// </term>
	/// </item>
	/// <item>
	/// <term>DRT_E_INVALID_SEARCH_RANGE</term>
	/// <term>Min and max key values are equal, but target is different.</term>
	/// </item>
	/// <item>
	/// <term>DRT_E_FAULTED</term>
	/// <term>The DRT cloud is in the faulted state.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The DRT is shutting down.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>An unexpected fatal error has occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtstartsearch HRESULT DrtStartSearch( HDRT hDrt, DRT_DATA *pKey,
	// const DRT_SEARCH_INFO *pInfo, ULONG timeout, HANDLE hEvent, const PVOID pvContext, HDRT_SEARCH_CONTEXT *hSearchContext );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtStartSearch")]
	public static extern HRESULT DrtStartSearch(HDRT hDrt, in DRT_DATA pKey, [In, Optional] IntPtr pInfo, uint timeout, HEVENT hEvent,
		[In, Optional] IntPtr pvContext, out HDRT_SEARCH_CONTEXT hSearchContext);

	/// <summary>The <c>DrtUnregisterKey</c> function deregisters a key from the DRT.</summary>
	/// <param name="hKeyRegistration">
	/// The DRT handle returned by the DrtRegisterKey function specifying a registered key within the DRT.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// A node can deregister a key anytime after registration. Additionally, if an application calls DrtClose, all keys are
	/// deregistered by the DRT infrastructure.
	/// </para>
	/// <para>
	/// Only the application that registered they key may deregister it. An application can deregister a key from the local node. Upon
	/// completion the function triggers a <c>DRT_EVENT_LEAFSET_KEY_CHANGE</c> event; informing the application and other nodes
	/// participating in the DRT mesh of the deregistration.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtunregisterkey void DrtUnregisterKey( HDRT_REGISTRATION_CONTEXT
	// hKeyRegistration );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtUnregisterKey")]
	public static extern void DrtUnregisterKey(HDRT_REGISTRATION_CONTEXT hKeyRegistration);

	/// <summary>The <c>DrtUpdateKey</c> function updates the application data associated with a registered key.</summary>
	/// <param name="hKeyRegistration">
	/// The DRT handle returned by the DrtRegisterKey function specifying a registered key within the DRT instance.
	/// </param>
	/// <param name="pAppData">The new application data to associate with the key.</param>
	/// <returns>
	/// <para>This function returns S_OK on success. Other possible values include:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>E_HANDLE</term>
	/// <term>hKeyRegistration is an invalid handle.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>The system is out of memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/nf-drt-drtupdatekey HRESULT DrtUpdateKey( HDRT_REGISTRATION_CONTEXT
	// hKeyRegistration, DRT_DATA *pAppData );
	[DllImport(Lib_Drt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("drt.h", MSDNShortId = "NF:drt.DrtUpdateKey")]
	public static extern HRESULT DrtUpdateKey(HDRT_REGISTRATION_CONTEXT hKeyRegistration, in DRT_DATA pAppData);

	/// <summary>
	/// The <c>DRT_ADDRESS</c> structure contains endpoint information about a DRT node that participated in a search. This information
	/// is intended for use in debugging connectivity problems.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_address typedef struct _DRT_ADDRESS { SOCKADDR_STORAGE
	// socketAddress; ULONG flags; LONG nearness; ULONG latency; } DRT_ADDRESS, *PDRT_ADDRESS;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt._DRT_ADDRESS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_ADDRESS
	{
		/// <summary>Contains the endpoint on which the DRT protocol is listening on the remote node.</summary>
		public SOCKADDR_STORAGE socketAddress;

		/// <summary>Holds information explaining how this node behaved in the key lookup.</summary>
		public DRT_ADDRESS_FLAGS flags;

		/// <summary>
		/// Contains the number of bits that the key published by this node shares in common with the target key in the search.
		/// </summary>
		public int nearness;

		/// <summary>Round trip time to this node.</summary>
		public uint latency;
	}

	/// <summary>
	/// The <c>DRT_ADDRESS_LIST</c> structure contains a set of DRT_ADDRESS structures that represent the nodes contacted during a
	/// search for a key.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_address_list typedef struct _DRT_ADDRESS_LIST { ULONG
	// AddressCount; DRT_ADDRESS AddressList[1]; } DRT_ADDRESS_LIST, *PDRT_ADDRESS_LIST;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt._DRT_ADDRESS_LIST")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DRT_ADDRESS_LIST>), nameof(AddressCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_ADDRESS_LIST
	{
		/// <summary>The count of entries in <c>AddressList</c>.</summary>
		public uint AddressCount;

		/// <summary>
		/// An array of DRT_ADDRESS structures that contain information about addresses that participated in the search operation.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public DRT_ADDRESS[] AddressList;
	}

	/// <summary>
	/// <para>The <c>DRT_BOOTSTRAP_PROVIDER</c> structure defines the DRT interface that must be implemented by a bootstrap provider.</para>
	/// <para><c>Note</c> The DRT infrastructure does not call the methods of the bootstrap provider concurrently.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_bootstrap_provider typedef struct drt_bootstrap_provider_tag {
	// PVOID pvContext; HRESULT( )(const PVOID pvContext) *Attach; VOID( )(const PVOID pvContext) *Detach; HRESULT((const PVOID
	// pvContext,BOOL fSplitDetect,ULONG timeout,ULONG cMaxResults,DRT_BOOTSTRAP_RESOLVE_CONTEXT *ResolveContext,BOOL *fFatalError) *
	// )InitResolve; HRESULT()(const PVOID pvContext, const PVOID pvCallbackContext,DRT_BOOTSTRAP_RESOLVE_CALLBACK
	// callback,DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext,BOOL *fFatalError) * IssueResolve; VOID( )(const PVOID
	// pvContext,DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext)
	// *EndResolve; HRESULT()(const PVOID pvContext, const SOCKET_ADDRESS_LIST *pAddressList) * Register; VOID( )(const PVOID pvContext)
	// *Unregister; } DRT_BOOTSTRAP_PROVIDER, *PDRT_BOOTSTRAP_PROVIDER;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_bootstrap_provider_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_BOOTSTRAP_PROVIDER
	{
		/// <summary>
		/// Pointer to context data that is defined by the bootstrap resolver. When creating a bootstrap resolver, the developer is
		/// required to populate the resolver with the required information; often times, this occurs as a "this" pointer. This context
		/// gets passed to all the context parameters in the functions defined by the <c>DRT_BOOTSTRAP_PROVIDER</c>.
		/// </summary>
		public IntPtr pvContext;

		/// <summary>Increments the count of references for the Bootstrap Provider with a set of DRTs.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_Attach Attach;

		/// <summary>Decrements the count of references for the Bootstrap Provider with a set of DRTs.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_Detach Detach;

		/// <summary>Called by the DRT infrastructure to supply configuration information about upcoming name resolutions.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_InitResolve InitResolve;

		/// <summary>
		/// Called by the DRT infrastructure to issue a resolution to determine the endpoints of nodes already active in the DRT cloud.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_IssueResolve IssueResolve;

		/// <summary>Ends the resolution of an endpoint.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_EndResolve EndResolve;

		/// <summary>
		/// Registers an endpoint with the bootstrapping mechanism. This process makes it possible for other nodes find the endpoint via
		/// the bootstrap resolver.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_Register Register;

		/// <summary>
		/// This function deregisters an endpoint with the bootstrapping mechanism. As a result, other nodes will be unable to find the
		/// local node via the bootstrap resolver.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_BOOTSTRAP_PROVIDER_Unregister Unregister;
	}

	/// <summary>The <c>DRT_DATA</c> structure contains a data blob. This structure is used by several DRT functions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_data typedef struct drt_data_tag { ULONG cb; BYTE *pb; }
	// DRT_DATA, *PDRT_DATA;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_DATA : IArrayStruct<byte>
	{
		/// <summary>The number of bytes.</summary>
		public uint cb;

		/// <summary>Pointer to a byte array that contains the common data.</summary>
		public IntPtr pb;

		/// <summary>Performs an implicit conversion from <see cref="DRT_DATA"/> to <see cref="System.Byte"/>[].</summary>
		/// <param name="d">The <see cref="DRT_DATA"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator byte[]?(DRT_DATA d) => d.pb == IntPtr.Zero ? null : d.GetArray();
	}

	/// <summary>
	/// The <c>DRT_EVENT_DATA</c> structure contains the event data returned by calling DrtGetEventData after an application receives an
	/// event signal on the hEvent passed into DrtOpen.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_event_data typedef struct drt_event_data_tag { DRT_EVENT_TYPE
	// type; HRESULT hr; PVOID pvContext; union { struct { DRT_LEAFSET_KEY_CHANGE_TYPE change; DRT_DATA localKey; DRT_DATA remoteKey; }
	// leafsetKeyChange; struct { DRT_REGISTRATION_STATE state; DRT_DATA localKey; } registrationStateChange; struct { DRT_STATUS
	// status; struct { ULONG cntAddress; PSOCKADDR_STORAGE pAddresses; } bootstrapAddresses; } statusChange; }; } DRT_EVENT_DATA, *PDRT_EVENT_DATA;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_event_data_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_EVENT_DATA
	{
		/// <summary>A DRT_EVENT_TYPE enumeration that specifies the event type.</summary>
		public DRT_EVENT_TYPE type;

		/// <summary>
		/// The HRESULT of the operation for which the event was signaled that indicates if a result is the last result within a search.
		/// </summary>
		public HRESULT hr;

		/// <summary>
		/// Pointer to the context data passed to the API that generated the event. For example, if data is passed into the pvContext
		/// parameter of DrtOpen, that data is returned through this field.
		/// </summary>
		public IntPtr pvContext;

		/// <summary/>
		public UNION union;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary>
			/// This structure appears when the event has been raised to signal a change in a leaf set of a locally registered key; the
			/// type field of the DRT_EVENT_DATA structure is set to DRT_EVENT_LEAFSET_KEY_CHANGED.
			/// </summary>
			[FieldOffset(0)]
			public LEAFSETKEYCHANGE leafsetKeyChange;

			/// <summary>
			/// This structure appears when the event has been raised to signal a change in a local key registration; the type field of
			/// the DRT_EVENT_DATA structure is set to DRT_EVENT_REGISTRATION_STATE_CHANGED.
			/// </summary>
			[FieldOffset(0)]
			public REGISTRATIONSTATECHANGE registrationStateChange;

			/// <summary>
			/// This structure appears when the event has been raised to signal a state change in the local DRT instance; the type field
			/// of the DRT_EVENT_DATA structure is set to DRT_EVENT_STATUS_CHANGED.
			/// </summary>
			[FieldOffset(0)]
			public STATUSCHANGE statusChange;

			/// <summary>
			/// This structure appears when the event has been raised to signal a change in a leaf set of a locally registered key; the
			/// type field of the DRT_EVENT_DATA structure is set to DRT_EVENT_LEAFSET_KEY_CHANGED.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct LEAFSETKEYCHANGE

			{
				/// <summary>Specifies the type of key change that has occurred.</summary>
				public DRT_LEAFSET_KEY_CHANGE_TYPE change;

				/// <summary>Specifies the local key associated with the leaf set that has changed.</summary>
				public DRT_DATA localKey;

				/// <summary>Specifies the remote key that changed.</summary>
				public DRT_DATA remoteKey;
			}

			/// <summary>
			/// This structure appears when the event has been raised to signal a change in a local key registration; the type field of
			/// the DRT_EVENT_DATA structure is set to DRT_EVENT_REGISTRATION_STATE_CHANGED.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct REGISTRATIONSTATECHANGE
			{
				/// <summary>Specifies the type of registration state change that has occurred.</summary>
				public DRT_REGISTRATION_STATE state;

				/// <summary>Specifies the local key associated with the registration that has changed.</summary>
				public DRT_DATA localKey;
			}

			/// <summary>
			/// This structure appears when the event has been raised to signal a state change in the local DRT instance; the type field
			/// of the DRT_EVENT_DATA structure is set to DRT_EVENT_STATUS_CHANGED.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct STATUSCHANGE

			{
				/// <summary>Contains the current DRT_STATUS of the local DRT instance.</summary>
				public DRT_STATUS status;

				/// <summary>
				/// This structure contains the addresses returned by the bootstrap provider when the DRT attempts to join the mesh. This
				/// structure is completed only when the DRT transitions to the DRT_ALONE state. The contents of this structure can be
				/// used to diagnose connectivity issues between the local DRT instance and other nodes already present in the mesh.
				/// </summary>
				public BOOTSTRAPADDRESSES bootstrapAddresses;

				/// <summary>
				/// This structure contains the addresses returned by the bootstrap provider when the DRT attempts to join the mesh. This
				/// structure is completed only when the DRT transitions to the DRT_ALONE state. The contents of this structure can be
				/// used to diagnose connectivity issues between the local DRT instance and other nodes already present in the mesh.
				/// </summary>
				[StructLayout(LayoutKind.Sequential)]
				public struct BOOTSTRAPADDRESSES
				{
					/// <summary>Contains the number of addresses in pAddresses.</summary>
					public uint cntAddress;

					/// <summary>Contains an array of SOCKADDR_STORAGE addresses returned by the bootstrap provider.</summary>
					public IntPtr pAddresses;

					/// <summary>Gets the array of SOCKADDR_STORAGE addresses returned by the bootstrap provider.</summary>
					public SOCKADDR_STORAGE[] Addresses => pAddresses.ToArray<SOCKADDR_STORAGE>((int)cntAddress) ?? new SOCKADDR_STORAGE[0];
				}
			}
		}
	}

	/// <summary>The <c>DRT_REGISTRATION</c> structure contains key and application data that make up a registration.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_registration typedef struct drt_registration_tag { DRT_DATA
	// key; DRT_DATA appData; } DRT_REGISTRATION, *PDRT_REGISTRATION;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_registration_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_REGISTRATION
	{
		/// <summary>Contains the key portion of the registration.</summary>
		public DRT_DATA key;

		/// <summary>
		/// The application data associated with the key. The DRT_DATA structure containing this application data must point to a buffer
		/// less than 4KB in size.
		/// </summary>
		public DRT_DATA appData;
	}

	/// <summary>The <c>DRT_SEARCH_INFO</c> structure represents a search query issued with DrtStartSearch.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_search_info typedef struct drt_search_info_tag { DWORD dwSize;
	// BOOL fIterative; BOOL fAllowCurrentInstanceMatch; BOOL fAnyMatchInRange; ULONG cMaxEndpoints; DRT_DATA *pMaximumKey; DRT_DATA
	// *pMinimumKey; } DRT_SEARCH_INFO, *PDRT_SEARCH_INFO;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_search_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_SEARCH_INFO
	{
		/// <summary>Specifies the byte count of <c>DRT_SEARCH_INFO</c>.</summary>
		public uint dwSize;

		/// <summary>Indicates whether the search is iterative. If set to <c>TRUE</c>, the search is iterative.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIterative;

		/// <summary>
		/// Indicates whether search results can contain matches found in the local DRT instance. If set to <c>TRUE</c>, the search
		/// results are capable of containing matches found in the local DRT instance.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fAllowCurrentInstanceMatch;

		/// <summary>
		/// If set to <c>true</c>, the search will stop locating the first key falling within the specified range. Otherwise, the search
		/// for the closest match to the target key specified by DrtStartSearch will continue.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fAnyMatchInRange;

		/// <summary>
		/// Specifies the number of results to return. This includes closest and exact matches. If this value is greater than 1 when
		/// <c>fIterative</c> is <c>TRUE</c>, the search will only return 1 result.
		/// </summary>
		public uint cMaxEndpoints;

		/// <summary>Specifies the numerically largest key value the infrastructure should attempt to match.</summary>
		public IntPtr pMaximumKey;

		/// <summary>Specifies the numerically smallest key value the infrastructure should attempt to match.</summary>
		public IntPtr pMinimumKey;
	}

	/// <summary>
	/// The <c>DRT_SEARCH_RESULT</c> contains the registration entry and the type of match of the search result returned by
	/// DrtGetSearchResult when the hEvent passed into DrtStartSearch is signaled.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_search_result typedef struct drt_search_result_tag { DWORD
	// dwSize; DRT_MATCH_TYPE type; PVOID pvContext; DRT_REGISTRATION registration; } DRT_SEARCH_RESULT, *PDRT_SEARCH_RESULT;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_search_result_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_SEARCH_RESULT
	{
		/// <summary>The size of the <c>DRT_SEARCH_RESULT</c> structure.</summary>
		public uint dwSize;

		/// <summary>Specifies the exactness of the search. This member corresponds to the DRT_MATCH_TYPE enumeration.</summary>
		public DRT_MATCH_TYPE type;

		/// <summary>Pointer to the context data passed to the DrtStartSearch API.</summary>
		public IntPtr pvContext;

		/// <summary>Contains the registration result.</summary>
		public DRT_REGISTRATION registration;
	}

	/// <summary>The <c>DRT_SECURITY_PROVIDER</c> structure defines the DRT interface that must be implemented by a security provider.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_security_provider typedef struct drt_security_provider_tag {
	// PVOID pvContext; HRESULT( )(const PVOID pvContext) *Attach; VOID( )(const PVOID pvContext) *Detach; HRESULT()(const PVOID
	// pvContext, const DRT_REGISTRATION *pRegistration,PVOID pvKeyContext) * RegisterKey; HRESULT()(const PVOID pvContext, const
	// DRT_DATA *pKey,PVOID pvKeyContext) * UnregisterKey; HRESULT( pvContext,DRT_DATA *pSecuredAddressPayload,DRT_DATA
	// *pCertChain,DRT_DATA *pClassifier,DRT_DATA *pNonce,DRT_DATA *pSecuredPayload,BYTE *pbProtocolMajor,BYTE *pbProtocolMinor,DRT_DATA
	// *pKey,DRT_DATA *pPayload,CERT_PUBLIC_KEY_INFO **ppPublicKey,SOCKET_ADDRESS_LIST **ppAddressList,DWORD *pdwFlags) * )(const
	// PVOIDValidateAndUnpackPayload; HRESULT( PVOID pvContext,PVOID pvKeyContext,BYTE bProtocolMajor,BYTE bProtocolMinor,DWORD dwFlags,
	// const DRT_DATA *pKey, const DRT_DATA *pPayload, const SOCKET_ADDRESS_LIST *pAddressList, const DRT_DATA *pNonce,DRT_DATA
	// *pSecuredAddressPayload,DRT_DATA *pClassifier,DRT_DATA *pSecuredPayload,DRT_DATA *pCertChain) * )(constSecureAndPackPayload;
	// void( )(const PVOID pvContext,PVOID pv) *FreeData; HRESULT(onst PVOID pvContext, const DRT_DATA *pRemoteCredential,DWORD
	// dwBuffers,DRT_DATA *pDataBuffers,DRT_DATA *pEncryptedBuffers,DRT_DATA *pKeyToken) * )(cEncryptData; HRESULT((const PVOID
	// pvContext,DRT_DATA *pKeyToken, const PVOID pvKeyContext,DWORD dwBuffers,DRT_DATA *pData) * )DecryptData; HRESULT()(const PVOID
	// pvContext,DRT_DATA *pSelfCredential) * GetSerializedCredential; HRESULT()(const PVOID pvContext,DRT_DATA *pRemoteCredential) *
	// ValidateRemoteCredential; HRESULT(const PVOID pvContext,DWORD dwBuffers,DRT_DATA *pDataBuffers,DRT_DATA *pKeyIdentifier,DRT_DATA
	// *pSignature) * )(SignData; HRESULT(onst PVOID pvContext,DWORD dwBuffers,DRT_DATA *pDataBuffers,DRT_DATA
	// *pRemoteCredentials,DRT_DATA *pKeyIdentifier,DRT_DATA *pSignature) * )(cVerifyData; } DRT_SECURITY_PROVIDER, *PDRT_SECURITY_PROVIDER;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_security_provider_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_SECURITY_PROVIDER
	{
		/// <summary>
		/// <para>
		/// This member is specified by the application when passing the <c>DRT_SECURITY_PROVIDER</c> structure to the DrtOpen function.
		/// </para>
		/// <para>
		/// The DRT treats it as an opaque pointer, and passes it as the first parameter to the functions referenced by this structure.
		/// An application will use this as a pointer to the security provider state or to the object that implements the security
		/// provider functionality.
		/// </para>
		/// </summary>
		public IntPtr pvContext;

		/// <summary>Increments the count of references for the Security Provider with a set of DRTs.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_Attach Attach;

		/// <summary>Decrements the count of references for the Security Provider with a set of DRTs.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_Detach Detach;

		/// <summary>Called to register a key with the Security Provider.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_RegisterKey RegisterKey;

		/// <summary>Called to deregister a key with the Security Provider.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_UnregisterKey UnregisterKey;

		/// <summary>
		/// Called when an Authority message is received on the wire. It is responsible for validating the data received, and for
		/// unpacking the service addresses, revoked flag, and nonce from the Secured Address Payload.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_ValidateAndUnpackPayload ValidateAndUnpackPayload;

		/// <summary>
		/// Called when an Authority message is about to be sent on the wire. It is responsible for securing the data before it is sent,
		/// and for packing the service addresses, revoked flag, nonce, and other application data into the Secured Address Payload.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_SecureAndPackPayload SecureAndPackPayload;

		/// <summary>Called to release resources previously allocated for a security provider function.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_FreeData FreeData;

		/// <summary>
		/// Called when the DRT sends a message containing data that must be encrypted. This function is only called when the DRT is
		/// operating in the <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security mode defined by DRT_SECURITY_MODE.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_EncryptData EncryptData;

		/// <summary>
		/// Called when the DRT receives a message containing encrypted data. This function is only called when the DRT is operating in
		/// the <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security mode defined by DRT_SECURITY_MODE.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_DecryptData DecryptData;

		/// <summary>
		/// Called when the DRT must provide a credential used to authorize the local node. This function is only called when the DRT is
		/// operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_GetSerializedCredential GetSerializedCredential;

		/// <summary>Called when the DRT must validate a credential provided by a peer node.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_ValidateRemoteCredential ValidateRemoteCredential;

		/// <summary>
		/// Called when the DRT must sign a data blob for inclusion in a DRT protocol message. This function is only called when the DRT
		/// is operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_SignData SignData;

		/// <summary>
		/// Called when the DRT must verify a signature calculated over a block of data included in a DRT message. This function is only
		/// called when the DRT is operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security
		/// modes defined by DRT_SECURITY_MODE.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public DRT_SECURITY_PROVIDER_VerifyData VerifyData;
	}

	/// <summary>The <c>DRT_SETTINGS</c> structure contains the settings utilized by the local Distributed Routing Table.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/drt/ns-drt-drt_settings typedef struct drt_settings_tag { DWORD dwSize; ULONG
	// cbKey; BYTE bProtocolMajorVersion; BYTE bProtocolMinorVersion; ULONG ulMaxRoutingAddresses; PWSTR pwzDrtInstancePrefix;
	// HDRT_TRANSPORT hTransport; DRT_SECURITY_PROVIDER *pSecurityProvider; DRT_BOOTSTRAP_PROVIDER *pBootstrapProvider;
	// DRT_SECURITY_MODE eSecurityMode; } DRT_SETTINGS, *PDRT_SETTINGS;
	[PInvokeData("drt.h", MSDNShortId = "NS:drt.drt_settings_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DRT_SETTINGS
	{
		/// <summary>
		/// The size of the structure specified by the sizeof parameter found in <c>DRT_SETTINGS</c> with the purpose of allowing new
		/// fields in the structure in future versions of the DRT API.
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// Specifies the exact number of bytes for keys in this DRT instance. Currently only 8 bytes are supported. Any other values
		/// will return <c>E_INVALIDARG</c> via the DrtOpen function.
		/// </summary>
		public uint cbKey;

		/// <summary>
		/// Pointer to the byte array that represents the protocol major version specified by the application. This is packed in every
		/// DRT packet to identify the version of the Security or Bootstrap Providers in use when a single DRT instance is supporting
		/// multiple Security or Bootstrap Providers.
		/// </summary>
		public byte bProtocolMajorVersion;

		/// <summary>
		/// Pointer to the byte array that represents the protocol minor version specified by the application. This is packed in every
		/// DRT packet to identify the version of the Security or Bootstrap Providers in use when a single DRT instance is supporting
		/// multiple Security or Bootstrap Providers.
		/// </summary>
		public byte bProtocolMinorVersion;

		/// <summary>
		/// Specifies the maximum number of address the DRT registers when an application registers a key. The maximum value for this
		/// field is 4.
		/// </summary>
		public uint ulMaxRoutingAddresses;

		/// <summary>
		/// This string forms the basis of the name of the DRT instance. The name of the instance can be used to locate the Windows
		/// performance counters associated with it.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwzDrtInstancePrefix;

		/// <summary>
		/// Handle to a transport created by the transport creation API. This is used to open a DRT with a transport specified by the
		/// <c>DRT_SETTINGS</c> structure. Currently only IPv6 UDP is supported via DrtCreateIpv6UdpTransport.
		/// </summary>
		public HDRT_TRANSPORT hTransport;

		/// <summary>
		/// Pointer to the security provider specified for use. An instance of the Derived Key Security Provider can be obtained by
		/// calling DrtCreateDerivedKeySecurityProvider.
		/// </summary>
		public IntPtr pSecurityProvider;

		/// <summary/>
		public IntPtr pBootstrapProvider;

		/// <summary>
		/// Specifies the security mode that the DRT should operate under. All nodes participating in a DRT mesh must use the same
		/// security mode.
		/// </summary>
		public DRT_SECURITY_MODE eSecurityMode;
	}

	/// <summary>
	/// The DRT_DATA structure contains an arbitrary array of bytes. The structure definition includes aliases appropriate to the various
	/// functions that use it.
	/// </summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class SafeDRT_DATA : SafeNativeArray<byte>
	{
		static readonly int HdrSize = Marshal.SizeOf(typeof(DRT_DATA));

		/// <summary>Initializes a new instance of the <see cref="SafeDRT_DATA"/> class.</summary>
		/// <param name="size">The size, in bytes, to allocate.</param>
		public SafeDRT_DATA(int size) : base(size, (uint)HdrSize) { }

		/// <summary>Initializes a new instance of the <see cref="SafeDRT_DATA"/> class.</summary>
		/// <param name="bytes">The bytes to copy into the blob.</param>
		public SafeDRT_DATA(byte[] bytes) : base(bytes, (uint)HdrSize) { }

		/// <summary>Initializes a new instance of the <see cref="SafeDRT_DATA"/> class with a string.</summary>
		/// <param name="value">The string value.</param>
		/// <param name="charSet">The character set to use.</param>
		public SafeDRT_DATA(string value, CharSet charSet = CharSet.Ansi) : this(StringHelper.GetBytes(value, true, charSet)) { }

		/// <summary>A DWORD variable that contains the count, in bytes, of data.</summary>
		public int cb => base.Count;

		/// <summary>A pointer to the data buffer.</summary>
		public IntPtr pb => handle.Offset(HdrSize);

		/// <summary>Represents an empty instance of a blob.</summary>
		public static readonly SafeDRT_DATA Empty = new(0);

		/// <summary>Performs an implicit conversion from <see cref="SafeDRT_DATA"/> to <see cref="DRT_DATA"/>.</summary>
		/// <param name="safeData">The safe data.</param>
		/// <returns>The resulting <see cref="DRT_DATA"/> instance from the conversion.</returns>
		public static implicit operator DRT_DATA(SafeDRT_DATA safeData) { safeData.UpdateHdr(); return safeData.handle.ToStructure<DRT_DATA>(); }

		/// <inheritdoc/>
		protected override void OnCountChanged() => UpdateHdr();

		/// <inheritdoc/>
		protected override void OnUpdateHeader() => UpdateHdr();

		private void UpdateHdr() => handle.Write(new DRT_DATA() { cb = (uint)base.Count, pb = base.Count == 0 ? IntPtr.Zero : handle.Offset(HdrSize) });
	}
}