using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.Drt;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Net;

#if RELEASE
public class DistributedRoutingTable
{
	private SafeHDRT hDrt;
	private SafeEventHandle evt;
	private SafeRegisteredWaitHandle drtWaitEvent;
	private readonly Ws2_32.SafeWSA ws = Ws2_32.SafeWSA.Initialize();

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HDRT"/> that is disposed using <see cref="CloseHandle"/>.</summary>
	public class SafeHDRT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHDRT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public SafeHDRT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHDRT"/> class.</summary>
		private SafeHDRT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHDRT"/> to <see cref="HDRT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HDRT(SafeHDRT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { DrtClose(handle); return true; }
	}

	public DistributedRoutingTable(PCCERT_CONTEXT pRootCert, PCCERT_CONTEXT pLocalCert, string hostName, ushort port)
	{
		IntPtr pBootstrapProvider, pSecurityProvider;
		if (pRootCert.IsNull)
			DrtCreateNullSecurityProvider(out pSecurityProvider).ThrowIfFailed();
		else
			DrtCreateDerivedKeySecurityProvider(pRootCert, pLocalCert, out pSecurityProvider).ThrowIfFailed();

		Init(pSecurityProvider, pBootstrapProvider);
	}

	public DistributedRoutingTable(ICustomDrtSecurityProvider securityProvider, ICustomBootstrapProvider bootstrapper)
	{

	}

	private void Init(IntPtr pSecProv, IntPtr pBootProv)
	{
		ushort port = 0;
		DrtCreateIpv6UdpTransport(DRT_SCOPE.DRT_GLOBAL_SCOPE, 0, 300, ref port, out var hTransport).ThrowIfFailed();

		DRT_SETTINGS pSettings = new()
		{
			dwSize = (uint)Marshal.SizeOf(typeof(DRT_SETTINGS)),
			cbKey = 32,
			ulMaxRoutingAddresses = 4,
			bProtocolMajorVersion = 0x6,
			bProtocolMinorVersion = 0x65,
			eSecurityMode = DRT_SECURITY_MODE.DRT_SECURE_CONFIDENTIALPAYLOAD,
			pwzDrtInstancePrefix = "__VanaraDRT",
			pSecurityProvider = pSecProv,
			pBootstrapProvider = pBootProv
		};
		evt = CreateEvent(null, false, false);
		DrtOpen(pSettings, evt, default, out var h).ThrowIfFailed();
		hDrt = new((IntPtr)h);
		Win32Error.ThrowLastErrorIfFalse(RegisterWaitForSingleObject(out drtWaitEvent, evt, DrtEventCallback, default /*AddCtx(Drt)*/, INFINITE, WT.WT_EXECUTEDEFAULT));
	}

	void DrtEventCallback(IntPtr Param, bool TimedOut)
	{
		HRESULT hr;
		var Drt = GetCtx(Param);

		hr = DrtGetEventDataSize(Drt.hDrt, out var ulDrtEventDataLen);
		if (hr.Failed)
		{
			if (hr != HRESULT.DRT_E_NO_MORE)
				Console.Write(" DrtGetEventDataSize failed: {0}\n", hr);
			goto Cleanup;
		}

		using (var pEventData = new SafeCoTaskMemStruct<DRT_EVENT_DATA>(ulDrtEventDataLen))
		{
			if (pEventData.IsInvalid)
			{
				Console.Write(" Out of memory\n");
				goto Cleanup;
			}

			hr = DrtGetEventData(Drt.hDrt, ulDrtEventDataLen, pEventData);
			if (hr.Failed)
			{
				if (hr != HRESULT.DRT_E_NO_MORE)
					Console.Write(" DrtGetEventData failed: {0}\n", hr);
				goto Cleanup;
			}

			switch (pEventData.Value.type)
			{
				case DRT_EVENT_TYPE.DRT_EVENT_STATUS_CHANGED:
					switch (pEventData.Value.union.statusChange.status)
					{
						case DRT_STATUS.DRT_ACTIVE:
							SetConsoleTitle("DrtSdkSample Current Drt Status: Active");
							if (g_DisplayEvents)
								Console.Write(" DRT Status Changed to Active\n");
							break;
						case DRT_STATUS.DRT_ALONE:
							SetConsoleTitle("DrtSdkSample Current Drt Status: Alone");
							if (g_DisplayEvents)
								Console.Write(" DRT Status Changed to Alone\n");
							break;
						case DRT_STATUS.DRT_NO_NETWORK:
							SetConsoleTitle("DrtSdkSample Current Drt Status: No Network");
							if (g_DisplayEvents)
								Console.Write(" DRT Status Changed to No Network\n");
							break;
						case DRT_STATUS.DRT_FAULTED:
							SetConsoleTitle("DrtSdkSample Current Drt Status: Faulted");
							if (g_DisplayEvents)
								Console.Write(" DRT Status Changed to Faulted\n");
							break;
					}

					break;
				case DRT_EVENT_TYPE.DRT_EVENT_LEAFSET_KEY_CHANGED:
					if (g_DisplayEvents)
					{
						switch (pEventData.Value.union.leafsetKeyChange.change)
						{
							case DRT_LEAFSET_KEY_CHANGE_TYPE.DRT_LEAFSET_KEY_ADDED:
								Console.Write(" Leafset Key Added Event: {0}\n", pEventData.Value.hr);
								break;
							case DRT_LEAFSET_KEY_CHANGE_TYPE.DRT_LEAFSET_KEY_DELETED:
								Console.Write(" Leafset Key Deleted Event: {0}\n", pEventData.Value.hr);
								break;
						}
					}

					break;
				case DRT_EVENT_TYPE.DRT_EVENT_REGISTRATION_STATE_CHANGED:
					if (g_DisplayEvents)
						Console.Write(" Registration State Changed Event: [hr: 0x%x, registration state: %i]\n", pEventData.Value.hr, pEventData.Value.union.registrationStateChange.state);
					break;
			}
		}
	Cleanup:
		return;
	}
}

public interface ICustomBootstrapProvider
{
	/// <summary>Increments the count of references for the Bootstrap Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Contains the pvContext value from DRT_BOOTSTRAP_PROVIDER.</param>
	/// <returns></returns>
	HRESULT Attach([In] IntPtr pvContext);

	/// <summary>Decrements the count of references for the Bootstrap Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Contains the pvContext value from DRT_BOOTSTRAP_PROVIDER.</param>
	void Detach([In] IntPtr pvContext);

	/// <summary>Ends the resolution of an endpoint.</summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="ResolveContext">
	/// The <c>BOOTSTRAP_RESOLVE_CONTEXT</c> received from the Resolve function of the specified bootstrap provider.
	/// </param>
	void EndResolve([In] IntPtr pvContext, [In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext);

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
	HRESULT InitResolve([In] IntPtr pvContext, bool fSplitDetect, uint timeout, uint cMaxResults,
		out DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError);

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
	HRESULT IssueResolve([In] IntPtr pvContext, [In] IntPtr pvCallbackContext, DRT_BOOTSTRAP_RESOLVE_CALLBACK callback,
		[In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError);

	/// <summary>
	/// Registers an endpoint with the bootstrapping mechanism. This process makes it possible for other nodes find the endpoint via the
	/// bootstrap resolver.
	/// </summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	/// <param name="pAddressList">Pointer to <see cref="SOCKET_ADDRESS_LIST"/> containing the list of addresses to register with the bootstrapping mechanism.</param>
	/// <returns></returns>
	HRESULT Register([In] IntPtr pvContext, [In] IntPtr pAddressList);

	/// <summary>
	/// This function deregisters an endpoint with the bootstrapping mechanism. As a result, other nodes will be unable to find the
	/// local node via the bootstrap resolver.
	/// </summary>
	/// <param name="pvContext">Contains the <c>pvContext</c> value from <c>DRT_BOOTSTRAP_PROVIDER</c>.</param>
	void Unregister([In] IntPtr pvContext);
}

public interface ICustomDrtSecurityProvider
{
	/// <summary>Increments the count of references for the Security Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	HRESULT Attach([In] IntPtr pvContext);

	/// <summary>Decrements the count of references for the Security Provider with a set of DRTs.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	void Detach([In] IntPtr pvContext);

	/// <summary>Called to register a key with the Security Provider.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pRegistration">
	/// Pointer to the DRT_REGISTRATION structure created by an application and passed to the DrtRegisterKey function.
	/// </param>
	/// <param name="pvKeyContext">Pointer to the context data created by an application and passed to the DrtRegisterKey function.</param>
	/// <returns></returns>
	HRESULT RegisterKey([In] IntPtr pvContext, in DRT_REGISTRATION pRegistration, [In, Optional] IntPtr pvKeyContext);

	/// <summary>Called to deregister a key with the Security Provider.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pKey">Pointer to the key to which the payload is registered.</param>
	/// <param name="pvKeyContext">Pointer to the context data created by the application and passed to DrtRegisterKey.</param>
	/// <returns></returns>
	HRESULT UnregisterKey([In] IntPtr pvContext, in DRT_DATA pKey, [In, Optional] IntPtr pvKeyContext);

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
	unsafe HRESULT ValidateAndUnpackPayload([In] IntPtr pvContext, in DRT_DATA pSecuredAddressPayload, [In, Optional] DRT_DATA* pCertChain,
		[In, Optional] DRT_DATA* pClassifier, [In, Optional] DRT_DATA* pNonce, [In, Optional] DRT_DATA* pSecuredPayload,
		[Out] byte* pbProtocolMajor, [Out] byte* pbProtocolMinor, out DRT_DATA pKey, [Out, Optional] DRT_DATA* pPayload,
		[Out] CERT_PUBLIC_KEY_INFO** ppPublicKey, [Out, Optional] void** ppAddressList, out uint pdwFlags);

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
	unsafe HRESULT SecureAndPackPayload([In] IntPtr pvContext, [In, Optional] IntPtr pvKeyContext, byte bProtocolMajor, byte bProtocolMinor,
		uint dwFlags, in DRT_DATA pKey, [In, Optional] DRT_DATA* pPayload, [In, Optional] IntPtr pAddressList,
		in DRT_DATA pNonce, out DRT_DATA pSecuredAddressPayload, [Out, Optional] DRT_DATA* pClassifier,
		[Out, Optional] DRT_DATA* pSecuredPayload, [Out, Optional] DRT_DATA* pCertChain);

	/// <summary>Called to release resources previously allocated for a security provider function.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pv">Specifies what data to free.</param>
	void FreeData([In] IntPtr pvContext, [In, Optional] IntPtr pv);

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
	HRESULT EncryptData([In] IntPtr pvContext, in DRT_DATA pRemoteCredential,
		[In] DRT_DATA[] pDataBuffers, [Out] DRT_DATA[] pEncryptedBuffers, out DRT_DATA pKeyToken);

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
	HRESULT DecryptData([In] IntPtr pvContext, in DRT_DATA pKeyToken, [In] IntPtr pvKeyContext,
		[In, Out] DRT_DATA[] pData);

	/// <summary>
	/// Called when the DRT must provide a credential used to authorize the local node. This function is only called when the DRT is
	/// operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pSelfCredential">Contains the serialized credential upon completion of the function.</param>
	/// <returns></returns>
	HRESULT GetSerializedCredential([In] IntPtr pvContext, out DRT_DATA pSelfCredential);

	/// <summary>Called when the DRT must validate a credential provided by a peer node.</summary>
	/// <param name="pvContext">Pointer to the value held by the <c>pvContext</c> member of <c>DRT_SECURITY_PROVIDER</c>.</param>
	/// <param name="pRemoteCredential">Contains the serialized credential provided by the peer node.</param>
	/// <returns></returns>
	HRESULT ValidateRemoteCredential([In] IntPtr pvContext, in DRT_DATA pRemoteCredential);

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
	HRESULT SignData([In] IntPtr pvContext, [In] DRT_DATA[] pDataBuffers, out DRT_DATA pKeyIdentifier,
		out DRT_DATA pSignature);

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
	HRESULT VerifyData([In] IntPtr pvContext, [In] DRT_DATA[] pDataBuffers, in DRT_DATA pRemoteCredentials,
		in DRT_DATA pKeyIdentifier, in DRT_DATA pSignature);
}

[StructLayout(LayoutKind.Sequential)]
public abstract class DrtSecurityProvider
{
	private readonly DRT_SECURITY_PROVIDER prov;

	protected DrtSecurityProvider()
	{
		unsafe
		{
			prov = new()
			{
				Attach = InternalAttach,
				Detach = InternalDetach,
				RegisterKey = InternalRegisterKey,
				UnregisterKey = InternalUnregisterKey,
				ValidateAndUnpackPayload = InternalValidateAndUnpackPayload,
				SecureAndPackPayload = InternalSecureAndPackPayload,
				FreeData = InternalFreeData,
				EncryptData = InternalEncryptData,
				DecryptData = InternalDecryptData,
				GetSerializedCredential = InternalGetSerializedCredential,
				ValidateRemoteCredential = InternalValidateRemoteCredential,
				SignData = InternalSignData,
				VerifyData = InternalVerifyData,
			};
		}
	}

	protected abstract void Attach(object context);
	protected abstract void Detach(object context);

	static HRESULT Execute(Action<object> action, IntPtr ctx) { try { action(ctx == IntPtr.Zero ? null : GCHandle.FromIntPtr(ctx).Target); return HRESULT.S_OK; } catch (Exception ex) { return ex.HResult; } }

	HRESULT InternalAttach(IntPtr pvContext) => Execute(Attach, pvContext);
	HRESULT InternalDecryptData(IntPtr pvContext, in DRT_DATA pKeyToken, IntPtr pvKeyContext, uint dwBuffers, DRT_DATA[] pData) => throw new NotImplementedException();
	void InternalDetach(IntPtr pvContext) => Execute(Detach, pvContext);
	HRESULT InternalEncryptData(IntPtr pvContext, in DRT_DATA pRemoteCredential, uint dwBuffers, DRT_DATA[] pDataBuffers, DRT_DATA[] pEncryptedBuffers, out DRT_DATA pKeyToken) => throw new NotImplementedException();
	void InternalFreeData(IntPtr pvContext, IntPtr pv) => throw new NotImplementedException();
	HRESULT InternalGetSerializedCredential(IntPtr pvContext, out DRT_DATA pSelfCredential) => throw new NotImplementedException();
	HRESULT InternalRegisterKey(IntPtr pvContext, in DRT_REGISTRATION pRegistration, IntPtr pvKeyContext) => throw new NotImplementedException();
	HRESULT InternalSignData(IntPtr pvContext, uint dwBuffers, DRT_DATA[] pDataBuffers, out DRT_DATA pKeyIdentifier, out DRT_DATA pSignature) => throw new NotImplementedException();
	HRESULT InternalUnregisterKey(IntPtr pvContext, in DRT_DATA pKey, IntPtr pvKeyContext) => throw new NotImplementedException();
	HRESULT InternalValidateRemoteCredential(IntPtr pvContext, in DRT_DATA pRemoteCredential) => throw new NotImplementedException();
	HRESULT InternalVerifyData(IntPtr pvContext, uint dwBuffers, DRT_DATA[] pDataBuffers, in DRT_DATA pRemoteCredentials, in DRT_DATA pKeyIdentifier, in DRT_DATA pSignature) => throw new NotImplementedException();
	unsafe HRESULT InternalValidateAndUnpackPayload(IntPtr pvContext, in DRT_DATA pSecuredAddressPayload, DRT_DATA* pCertChain, DRT_DATA* pClassifier, DRT_DATA* pNonce, DRT_DATA* pSecuredPayload, byte* pbProtocolMajor, byte* pbProtocolMinor, out DRT_DATA pKey, DRT_DATA* pPayload, CERT_PUBLIC_KEY_INFO** ppPublicKey, void** ppAddressList, out uint pdwFlags) => throw new NotImplementedException();
	unsafe HRESULT InternalSecureAndPackPayload(IntPtr pvContext, IntPtr pvKeyContext, byte bProtocolMajor, byte bProtocolMinor, uint dwFlags, in DRT_DATA pKey, DRT_DATA* pPayload, IntPtr pAddressList, in DRT_DATA pNonce, out DRT_DATA pSecuredAddressPayload, DRT_DATA* pClassifier, DRT_DATA* pSecuredPayload, DRT_DATA* pCertChain) => throw new NotImplementedException();
}
#endif