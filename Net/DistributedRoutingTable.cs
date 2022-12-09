#nullable enable

using System;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.Net.DrtUtil;
using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.Drt;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ws2_32;

namespace Vanara.Net;

/// <summary>DNS Bootstrapper</summary>
/// <seealso cref="Vanara.Net.DrtCustomBootstrapProvider"/>
public class CustomDnsBootstapper : DrtCustomBootstrapProvider
{
	private readonly string hostname;
	private readonly object m_lock = new();
	private readonly string port;
	private uint m_CallbackThreadId;
	private uint m_dwMaxResults;
	private bool m_fEndResolve;
	private bool m_fResolveInProgress;
	private SafeEventHandle? m_hCallbackComplete;

	/// <summary>Initializes a new instance of the <see cref="CustomDnsBootstapper"/> class.</summary>
	/// <param name="pNodeName">
	/// A string that contains a host (node) name or a numeric host address string. For the Internet protocol, the numeric host address
	/// string is a dotted-decimal IPv4 address or an IPv6 hex address.
	/// </param>
	/// <param name="pServiceName">
	/// <para>A string that contains either a service name or port number represented as a string.</para>
	/// <para>
	/// A service name is a string alias for a port number. For example, “http” is an alias for port 80 defined by the Internet Engineering
	/// Task Force (IETF) as the default port used by web servers for the HTTP protocol. Possible values for the pServiceName parameter when
	/// a port number is not specified are listed in the following file:
	/// </para>
	/// </param>
	public CustomDnsBootstapper(string pNodeName, string pServiceName)
	{
		hostname = pNodeName;
		port = pServiceName;
	}

	/// <inheritdoc/>
	protected override void EndResolve([In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext)
	{
		var fWaitForCallback = false;

		var CallbackComplete = CreateEvent(default, true, false, default);

		lock (m_lock)
		{
			if (m_fResolveInProgress && (GetCurrentThreadId() != m_CallbackThreadId))
			{
				if (!m_fEndResolve)
				{
					// This is the first thread to call EndResolve and we need to wait for a callback to complete so initialize the class
					// member event
					m_fEndResolve = true;
					m_hCallbackComplete = CallbackComplete;
				}
				fWaitForCallback = true;
			}
		}

		if (!CallbackComplete.IsInvalid && (m_hCallbackComplete != CallbackComplete))
		{
			// This thread was not the first to call EndResolve, so its event is not in use, release it (m_hCallbackComplete is released in
			// the destructor)
			CallbackComplete.Dispose();
		}

		if (fWaitForCallback && m_hCallbackComplete != null)
		{
			WaitForSingleObject(m_hCallbackComplete, INFINITE);
		}

		Release();
	}

	/// <inheritdoc/>
	protected override HRESULT InitResolve(bool fSplitDetect, TimeSpan timeout, uint cMaxResults, out DRT_BOOTSTRAP_RESOLVE_CONTEXT pResolveContext, out bool fFatalError)
	{
		fFatalError = false;
		pResolveContext = default;

		var hr = HRESULT.DRT_E_BOOTSTRAPPROVIDER_NOT_ATTACHED;
		if (IsAttached)
		{
			// The cache is not scope aware so we ask for a larger number of addresses than the cache wants. In the expectation that one of
			// them may be good for us
			m_dwMaxResults = cMaxResults;

			AddRef();
			hr = HRESULT.S_OK;
		}

		if (hr.Failed)
		{
			// CustomDNSResolver has no retry cases, so any failed HRESULT is fatal
			fFatalError = true;
		}

		return hr;
	}

	/// <inheritdoc/>
	protected override HRESULT IssueResolve(DRT_BOOTSTRAP_RESOLVE_CALLBACK callback, [In] IntPtr pvCallbackContext, [In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError)
	{
		fFatalError = false;

		if (callback is null)
		{
			return HRESULT.E_INVALIDARG;
		}

		var hr = HRESULT.DRT_E_BOOTSTRAPPROVIDER_NOT_ATTACHED;
		if (IsAttached)
		{
			lock (m_lock)
			{
				m_fResolveInProgress = true;
				m_CallbackThreadId = GetCurrentThreadId();
			}

			if (m_dwMaxResults > 0)
			{
				var addresses = hostname.Split(new[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();
				foreach (var CurrentAddress in addresses)
				{
					if (m_fEndResolve)
						break;

					// Retrieve bootstrap possibilities
					var addrInf = new ADDRINFOW
					{
						ai_flags = ADDRINFO_FLAGS.AI_CANONNAME,
						ai_family = ADDRESS_FAMILY.AF_UNSPEC,
						ai_socktype = SOCK.SOCK_STREAM
					};

					var nStat = GetAddrInfoW(CurrentAddress, port, addrInf, out var results);
					if (nStat.Succeeded)
					{
						using (results)
						{
							var cbSA6 = Marshal.SizeOf(typeof(SOCKADDR_IN6));
							using var psockAddrs = new SafeNativeArray<SOCKADDR_IN6>(results.Select(a => { using var ar = a.addr; return (SOCKADDR_IN6)ar; }).ToArray());
							var Addresses = new SOCKET_ADDRESS_LIST
							{
								iAddressCount = psockAddrs.Count,
								Address = psockAddrs.Select((a, i) => new SOCKET_ADDRESS { iSockaddrLength = cbSA6, lpSockaddr = ((IntPtr)psockAddrs).Offset(cbSA6) }).ToArray()
							};

							// Call the callback to signal completion
							using var pAddresses = Addresses.Pack();
							callback?.Invoke(hr, pvCallbackContext, pAddresses, false);
						}
					}
					else
					{
						// GetAddrInfoW Failed but there may be more addresses in the string so keep going otherwise we return
						// HRESULT.E_NO_MORE and retry next cycle
					}
				}
			}

			// Tell the drt there will be no more results
			if (!m_fEndResolve)
				callback?.Invoke(HRESULT.DRT_E_NO_MORE, pvCallbackContext, default, false);

			lock (m_lock)
			{
				if (m_hCallbackComplete != null && !m_hCallbackComplete.IsInvalid)
				{
					// Notify EndResolve that callbacks have completed
					m_hCallbackComplete.Set();
				}
				m_fResolveInProgress = false;
			}
			hr = HRESULT.S_OK;
		}

		if (hr.Failed)
		{
			// DNSResolver has no retry cases, so any failed HRESULT is fatal
			fFatalError = true;
		}
		return hr;
	}
}

/// <summary>Represents a distributed routing table from Win32.</summary>
public class DistributedRoutingTable : IDisposable
{
	private static readonly SafeWSA ws = SafeWSA.Initialize();

	private readonly SafeRegisteredWaitHandle? drtWaitEvent;
	private readonly SafeEventHandle? evt;
	private readonly SafeHDRT? hDrt;
	private readonly SafeHDRT_TRANSPORT hTransport;
	private readonly IntPtr selfPin;
	private bool disposedValue;
	private DRT_SETTINGS pSettings;

	/// <summary>Initializes a new instance of the <see cref="DistributedRoutingTable"/> class.</summary>
	/// <param name="securityProvider">The security provider.</param>
	/// <param name="bootstrapper">The bootstrapper.</param>
	public DistributedRoutingTable(DrtSecurityProvider? securityProvider, DrtBootstrapProvider bootstrapper) :
		this((IntPtr)(securityProvider ?? DrtSecurityProvider.CreateNullSecurityProvider()), (IntPtr)bootstrapper)
	{ }

	private DistributedRoutingTable(IntPtr pSecProv, IntPtr pBootProv)
	{
		ushort port = 0;
		pSettings = new()
		{
			dwSize = (uint)Marshal.SizeOf(typeof(DRT_SETTINGS)),
			cbKey = 32,
			ulMaxRoutingAddresses = 4,
			bProtocolMajorVersion = 0x6,
			bProtocolMinorVersion = 0x65,
			eSecurityMode = DRT_SECURITY_MODE.DRT_SECURE_CONFIDENTIALPAYLOAD,
			pwzDrtInstancePrefix = "__VanaraDRT" + Guid.NewGuid().ToString("N"),
			pSecurityProvider = pSecProv,
			pBootstrapProvider = pBootProv,
		};
		DrtCreateIpv6UdpTransport(DRT_SCOPE.DRT_GLOBAL_SCOPE, 0, 300, ref port, out hTransport).ThrowIfFailed();

		pSettings.hTransport = hTransport;
		evt = CreateEvent(null, false, false);
		DrtOpen(pSettings, evt, default, out hDrt).ThrowIfFailed();
		selfPin = (IntPtr)GCHandle.Alloc(this, GCHandleType.Normal);
		Win32Error.ThrowLastErrorIfFalse(RegisterWaitForSingleObject(out drtWaitEvent, evt, DrtEventCallback, selfPin, INFINITE, WT.WT_EXECUTEDEFAULT));
	}

	/// <summary>Finalizes an instance of the <see cref="DistributedRoutingTable"/> class.</summary>
	~DistributedRoutingTable()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: false);
	}

	/// <summary>Occurs when the leaf set key changes.</summary>
	public event EventHandler<DrtLeafSetKeyChangeEventArgs>? LeafSetKeyChange;

	/// <summary>Occurs when the registration state changes.</summary>
	public event EventHandler<DrtRegistrationStateChangeEventArgs>? RegistrationStateChange;

	/// <summary>Occurs when the status changes.</summary>
	public event EventHandler<DrtStatusChangeEventArgs>? StatusChange;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				if (selfPin != IntPtr.Zero)
					GCHandle.FromIntPtr(selfPin).Free();
			}

			drtWaitEvent?.Dispose();
			evt?.Dispose();
			hDrt?.Dispose();
			hTransport?.Dispose();

			disposedValue = true;
		}
	}

	private static void DrtEventCallback(IntPtr Param, bool TimedOut)
	{
		var Drt = (DistributedRoutingTable?)GCHandle.FromIntPtr(Param).Target;

		HRESULT hr = DrtGetEventDataSize(Drt?.hDrt, out var ulDrtEventDataLen);
		if (hr.Failed)
		{
			if (hr != HRESULT.DRT_E_NO_MORE)
				throw hr.GetException();
			goto Cleanup;
		}

		using (SafeCoTaskMemStruct<DRT_EVENT_DATA> pEventData = new(ulDrtEventDataLen))
		{
			hr = DrtGetEventData(Drt.hDrt, ulDrtEventDataLen, pEventData);
			if (hr.Failed)
			{
				if (hr != HRESULT.DRT_E_NO_MORE)
					throw hr.GetException();
				goto Cleanup;
			}

			switch (pEventData.Value.type)
			{
				case DRT_EVENT_TYPE.DRT_EVENT_STATUS_CHANGED:
					Drt.StatusChange?.Invoke(Drt, new(pEventData.Value));
					break;
				case DRT_EVENT_TYPE.DRT_EVENT_LEAFSET_KEY_CHANGED:
					Drt.LeafSetKeyChange?.Invoke(Drt, new(pEventData.Value));
					break;
				case DRT_EVENT_TYPE.DRT_EVENT_REGISTRATION_STATE_CHANGED:
					Drt.RegistrationStateChange?.Invoke(Drt, new(pEventData.Value));
					break;
			}
		}
	Cleanup:
		return;
	}
}

/// <summary>Abstract base class for a custom DRT bootstrap provider.</summary>
public class DrtBootstrapProvider : IDisposable
{
	/// <summary>The bootstrap provider structure.</summary>
	protected DRT_BOOTSTRAP_PROVIDER prov;

	private readonly IntPtr pProv;
	private readonly char pProvType;

	/// <summary>Initializes a new instance of the <see cref="DrtBootstrapProvider"/> class.</summary>
	/// <param name="prov">The prov.</param>
	protected DrtBootstrapProvider(in DRT_BOOTSTRAP_PROVIDER prov)
	{
		this.prov = prov;
		pProv = GCHandle.Alloc(this.prov, GCHandleType.Pinned).AddrOfPinnedObject();
		pProvType = 'h';
	}

	/// <summary>Initializes a new instance of the <see cref="DrtBootstrapProvider"/> class.</summary>
	protected DrtBootstrapProvider() { }

	/// <summary>
	/// Creates a bootstrap resolver that will use the GetAddrInfo system function to resolve the hostname of a will known node already
	/// present in the DRT mesh.
	/// </summary>
	/// <param name="hostname">Specifies the hostname of the well known node.</param>
	/// <param name="port">Specifies the port to which the DRT protocol is bound on the well known node.</param>
	/// <returns>A DNS <see cref="DrtBootstrapProvider"/> instance.</returns>
	public DrtBootstrapProvider(string? hostname, ushort port)
	{
		hostname ??= LocalDnsHost;
		DrtCreateDnsBootstrapResolver(port, hostname, out IntPtr pbp).ThrowIfFailed();
		pProv = pbp;
		pProvType = 'd';
	}

	/// <summary>Initializes a new instance of the <see cref="DrtBootstrapProvider"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="provType">Type of the provider pointer.</param>
	private DrtBootstrapProvider(IntPtr ptr, char provType)
	{
		pProv = ptr;
		pProvType = provType;
	}

	/// <summary>Gets the local DNS host.</summary>
	protected static string LocalDnsHost
	{
		get
		{
			Win32Error.ThrowLastErrorIfFalse(GetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNameDnsFullyQualified, out string? name));
			return name;
		}
	}

	/// <summary>Creates a bootstrap resolver based on the Peer Name Resolution Protocol (PNRP).</summary>
	/// <param name="peerName">The name of the peer to search for in the PNRP cloud. This string has a maximum limit of 137 unicode characters</param>
	/// <param name="cloudName">
	/// <para>The name of the cloud to search for in for the DRT corresponding to the MeshName.</para>
	/// <para>
	/// This string has a maximum limit of 256 unicode characters. If left blank the PNRP Bootstrap Provider will use all PNRP clouds available.
	/// </para>
	/// </param>
	/// <param name="publishingId">
	/// The PeerIdentity that is publishing into the PNRP cloud utilized for bootstrapping. This string has a maximum limit of 137 unicode
	/// characters. The PublishingIdentity must be allowed to publish the PeerName specified.
	/// </param>
	/// <returns>A PNRP <see cref="DrtBootstrapProvider"/> instance.</returns>
	/// <remarks>
	/// The default PNRP Bootstrap Resolver created by this function is specific to the DRT it is created for. As a result it cannot be
	/// re-used across multiple DRTs.
	/// </remarks>
	public static DrtBootstrapProvider CreatePnrpBootstrapResolver(string peerName, string? cloudName = null, string? publishingId = null)
	{
		DrtCreatePnrpBootstrapResolver(true, peerName, cloudName, publishingId, out IntPtr pbp).ThrowIfFailed();
		return new(pbp, 'p');
	}

	/// <summary>Performs an explicit conversion from <see cref="Vanara.Net.DrtBootstrapProvider"/> to <see cref="System.IntPtr"/>.</summary>
	/// <param name="prov">The prov.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(DrtBootstrapProvider prov) => prov.pProv;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		if (pProv != default)
		{
			if (pProvType == 'd')
			{
				DrtDeleteDnsBootstrapResolver(pProv);
			}
			else if (pProvType == 'p')
			{
				DrtDeletePnrpBootstrapResolver(pProv);
			}
			else if (pProvType == 'h')
			{
				GCHandle.FromIntPtr(pProv).Free();
			}
		}
	}
}

/// <summary>Abstract base class for a custom DRT bootstrap provider.</summary>
public abstract class DrtCustomBootstrapProvider : DrtBootstrapProvider
{
	private int refCount;

	/// <summary>Initializes a new instance of the <see cref="DrtBootstrapProvider"/> class.</summary>
	protected DrtCustomBootstrapProvider(object? context = null) : base(default)
	{
		unsafe
		{
			prov.Attach = InternalAttach;
			prov.Detach = InternalDetach;
			prov.InitResolve = InternalInitResolve;
			prov.IssueResolve = InternalIssueResolve;
			prov.EndResolve = InternalEndResolve;
			prov.Register = InternalRegister;
			prov.Unregister = InternalUnregister;
			if (context != null)
				prov.pvContext = GCHandle.Alloc(context).AddrOfPinnedObject();
		}
		AddRef();
	}

	/// <summary>Gets the context provided for all methods.</summary>
	/// <value>The context object.</value>
	protected virtual object? Context => prov.pvContext == IntPtr.Zero ? null : GCHandle.FromIntPtr(prov.pvContext).Target;

	/// <summary>Gets a value indicating whether this instance is attached.</summary>
	/// <value><see langword="true"/> if this instance is attached; otherwise, <see langword="false"/>.</value>
	protected bool IsAttached => refCount > 0;

	/// <summary>Adds the reference.</summary>
	protected void AddRef()
	{
		if (refCount == 0)
			GC.SuppressFinalize(this);
		InterlockedIncrement(ref refCount);
	}

	/// <summary>Ends the resolution of an endpoint.</summary>
	/// <param name="ResolveContext">
	/// The <c>BOOTSTRAP_RESOLVE_CONTEXT</c> received from the Resolve function of the specified bootstrap provider.
	/// </param>
	protected abstract void EndResolve([In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext);

	/// <summary>Called by the DRT infrastructure to supply configuration information about upcoming name resolutions.</summary>
	/// <param name="fSplitDetect">Specifies if the resolve operation is being utilized for network split detection and recovery.</param>
	/// <param name="timeout">Specifies the maximum time a resolve should take before timing out. This value is represented in milliseconds.</param>
	/// <param name="cMaxResults">Specifies the maximum number of results to return during the resolve operation.</param>
	/// <param name="ResolveContext">Pointer to resolver specific data.</param>
	/// <param name="fFatalError">
	/// If the bootstrap provider encounters an irrecoverable error, this parameter must be set to <c>TRUE</c> when the function complete in
	/// order for the DRT to transition to the faulted state. The <c>HRESULT</c> that is made available to the higher layer application for
	/// debugging will appear in the <c>hr</c> member of the DRT_EVENT_DATA structure associated with the event signaling the transition to
	/// the faulted state. This bootstrap provider function should not return S_OK if setting the fFatalError flag to <c>TRUE</c>.
	/// </param>
	protected abstract HRESULT InitResolve(bool fSplitDetect, TimeSpan timeout, uint cMaxResults,
		out DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError);

	/// <summary>
	/// Called by the DRT infrastructure to issue a resolution to determine the endpoints of nodes already active in the DRT cloud.
	/// </summary>
	/// <param name="pvCallbackContext">Pointer to the context data that is passed back to the callback defined by the next parameter.</param>
	/// <param name="callback">A BOOTSTRAP_RESOLVE_CALLBACK that is called back for each result and DRT_E_NO_MORE.</param>
	/// <param name="ResolveContext">Pointer to resolver specific data.</param>
	/// <param name="fFatalError">
	/// If the bootstrap provider encounters an irrecoverable error, this parameter must be set to <c>TRUE</c> when the function complete in
	/// order for the DRT to transition to the faulted state. The <c>HRESULT</c> that is made available to the higher layer application for
	/// debugging will appear in the <c>hr</c> member of the DRT_EVENT_DATA structure associated with the event signaling the transition to
	/// the faulted state. This bootstrap provider function should not return S_OK if setting the fFatalError flag to <c>TRUE</c>.
	/// </param>
	protected abstract HRESULT IssueResolve(DRT_BOOTSTRAP_RESOLVE_CALLBACK callback, [In] IntPtr pvCallbackContext,
		[In] DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError);

	/// <summary>
	/// Registers an endpoint with the bootstrapping mechanism. This process makes it possible for other nodes find the endpoint via the
	/// bootstrap resolver.
	/// </summary>
	/// <param name="pAddressList">
	/// Pointer to <see cref="SOCKET_ADDRESS_LIST"/> containing the list of addresses to register with the bootstrapping mechanism.
	/// </param>
	protected virtual HRESULT Register([In] IPEndPoint[]? pAddressList) => HRESULT.S_OK;

	/// <summary>Releases this instance.</summary>
	protected void Release()
	{
		if (InterlockedDecrement(ref refCount) == 0)
		{
			if (prov.pvContext != default)
				GCHandle.FromIntPtr(prov.pvContext).Free();
			GC.ReRegisterForFinalize(this);
		}
	}

	/// <summary>
	/// This function deregisters an endpoint with the bootstrapping mechanism. As a result, other nodes will be unable to find the local
	/// node via the bootstrap resolver.
	/// </summary>
	protected virtual void Unregister() { }

	private HRESULT InternalAttach(IntPtr pvContext)
	{
		if (InterlockedCompareExchange(ref refCount, 1, 0) != 0)
			return HRESULT.DRT_E_BOOTSTRAPPROVIDER_IN_USE;
		AddRef();
		return HRESULT.S_OK;
	}
	private void InternalDetach(IntPtr pvContext)
	{
		InterlockedCompareExchange(ref refCount, 0, 1);
		Release();
	}
	private void InternalEndResolve(IntPtr pvContext, DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext) => EndResolve(ResolveContext);

	private HRESULT InternalInitResolve(IntPtr pvContext, bool fSplitDetect, uint timeout, uint cMaxResults,
		out DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError) =>
		InitResolve(fSplitDetect, TimeSpan.FromMilliseconds(timeout), cMaxResults, out ResolveContext, out fFatalError);

	private HRESULT InternalIssueResolve(IntPtr pvContext, IntPtr pvCallbackContext, DRT_BOOTSTRAP_RESOLVE_CALLBACK callback,
		DRT_BOOTSTRAP_RESOLVE_CONTEXT ResolveContext, out bool fFatalError) =>
		IssueResolve(callback, pvCallbackContext, ResolveContext, out fFatalError);

	private HRESULT InternalRegister(IntPtr pvContext, IntPtr pAddressList) => Register(ToEndPoints(pAddressList.ToNullableStructure<SOCKET_ADDRESS_LIST>()));

	private void InternalUnregister(IntPtr pvContext) => Unregister();
}

/// <summary>Abstract base class for DRT event arguments.</summary>
/// <seealso cref="System.EventArgs"/>
public abstract class DrtEventArgs : EventArgs
{
	/// <summary>Initializes a new instance of the <see cref="DrtEventArgs"/> class.</summary>
	/// <param name="data">The data.</param>
	protected DrtEventArgs(in DRT_EVENT_DATA data)
	{
		LastError = data.hr;
		Context = data.pvContext;
	}

	/// <summary>
	/// Pointer to the context data passed to the API that generated the event. For example, if data is passed into the pvContext parameter
	/// of DrtOpen, that data is returned through this field.
	/// </summary>
	public IntPtr Context { get; }

	/// <summary>
	/// The HRESULT of the operation for which the event was signaled that indicates if a result is the last result within a search.
	/// </summary>
	public HRESULT LastError { get; }
}

/// <summary>Arguments associated with a DRT leaf set key change event.</summary>
/// <seealso cref="Vanara.Net.DrtEventArgs"/>
public class DrtLeafSetKeyChangeEventArgs : DrtEventArgs
{
	internal DrtLeafSetKeyChangeEventArgs(in DRT_EVENT_DATA data) : base(data)
	{
		Type = data.union.leafsetKeyChange.change;
		LocalKey = (byte[])data.union.leafsetKeyChange.localKey;
		RemoteKey = (byte[])data.union.leafsetKeyChange.remoteKey;
	}

	/// <summary>Specifies the local key associated with the leaf set that has changed.</summary>
	public byte[]? LocalKey { get; private set; }

	/// <summary>Specifies the remote key that changed.</summary>
	public byte[]? RemoteKey { get; private set; }

	/// <summary>Specifies the type of key change that has occurred.</summary>
	public DRT_LEAFSET_KEY_CHANGE_TYPE Type { get; private set; }
}

/// <summary>Arguments associated with a DRT registration state change event.</summary>
/// <seealso cref="Vanara.Net.DrtEventArgs"/>
public class DrtRegistrationStateChangeEventArgs : DrtEventArgs
{
	internal DrtRegistrationStateChangeEventArgs(in DRT_EVENT_DATA data) : base(data)
	{
		State = data.union.registrationStateChange.state;
		LocalKey = (byte[])data.union.registrationStateChange.localKey;
	}

	/// <summary>Specifies the local key associated with the registration that has changed.</summary>
	public byte[]? LocalKey { get; }

	/// <summary>Specifies the type of registration state change that has occurred.</summary>
	public DRT_REGISTRATION_STATE State { get; }
}

/// <summary>Base class for a DRT security provider.</summary>
public class DrtSecurityProvider : IDisposable
{
	/// <summary>The security provider structure.</summary>
	protected DRT_SECURITY_PROVIDER prov;

	private readonly IntPtr pProv;
	private readonly char pProvType;

	/// <summary>Initializes a new instance of the <see cref="DrtSecurityProvider"/> class.</summary>
	/// <param name="prov">The prov.</param>
	protected DrtSecurityProvider(in DRT_SECURITY_PROVIDER prov)
	{
		this.prov = prov;
		pProv = GCHandle.Alloc(this.prov, GCHandleType.Pinned).AddrOfPinnedObject();
		pProvType = 'h';
	}

	private DrtSecurityProvider() { }

	private DrtSecurityProvider(IntPtr ptr, char provType)
	{
		pProv = ptr;
		pProvType = provType;
	}

	/// <summary>Creates the derived key security provider for a Distributed Routing Table.</summary>
	/// <param name="pRootCert">
	/// Pointer to the certificate that is the "root" portion of the chain. This is used to ensure that keys derived from the same chain can
	/// be verified.
	/// </param>
	/// <param name="pLocalCert">Pointer to the DRT_SECURITY_PROVIDER module to be included in the DRT_SETTINGS structure.</param>
	/// <returns>A derived key <see cref="DrtSecurityProvider"/> instance.</returns>
	/// <remarks>
	/// The security provider created by this function is specific to the DRT it was created for. It cannot be shared by multiple DRT instances.
	/// </remarks>
	public static DrtSecurityProvider CreateDerivedKeySecurityProvider(PCCERT_CONTEXT pRootCert, PCCERT_CONTEXT pLocalCert)
	{
		DrtCreateDerivedKeySecurityProvider(pRootCert, pLocalCert, out IntPtr psp).ThrowIfFailed();
		return new(psp, 'd');
	}

	/// <summary>Creates a null security provider. This security provider does not require nodes to authenticate keys.</summary>
	/// <returns>A null <see cref="DrtSecurityProvider"/> instance.</returns>
	public static DrtSecurityProvider CreateNullSecurityProvider()
	{
		DrtCreateNullSecurityProvider(out IntPtr psp).ThrowIfFailed();
		return new DrtSecurityProvider(psp, 'n');
	}

	/// <summary>Performs an explicit conversion from <see cref="Vanara.Net.DrtSecurityProvider"/> to <see cref="System.IntPtr"/>.</summary>
	/// <param name="prov">The prov.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(DrtSecurityProvider prov) => prov.pProv;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		if (pProv != default)
		{
			if (pProvType == 'n')
			{
				DrtDeleteNullSecurityProvider(pProv);
			}
			else if (pProvType == 'd')
			{
				DrtDeleteDerivedKeySecurityProvider(pProv);
			}
			else if (pProvType == 'h')
			{
				GCHandle.FromIntPtr(pProv).Free();
			}
		}
	}
}

/// <summary>Arguments associated with a DRT status change event.</summary>
/// <seealso cref="Vanara.Net.DrtEventArgs"/>
public class DrtStatusChangeEventArgs : DrtEventArgs
{
	internal DrtStatusChangeEventArgs(in DRT_EVENT_DATA data) : base(data)
	{
		Status = data.union.statusChange.status;
		BootstrapAddresses = data.union.statusChange.bootstrapAddresses.Addresses?.Select(Cvt).ToArray();

		static IPEndPoint Cvt(SOCKADDR_STORAGE input)
		{
			var inet = (SOCKADDR_INET)input;
			return inet.si_family is ADDRESS_FAMILY.AF_INET or ADDRESS_FAMILY.AF_UNSPEC
				? new IPEndPoint(inet.Ipv4.sin_addr, inet.Ipv4.sin_port)
				: new IPEndPoint(new IPAddress(inet.Ipv6.sin6_addr.bytes, inet.Ipv6.sin6_scope_id), inet.Ipv6.sin6_port);
		}
	}

	/// <summary>Contains an array of <see cref="IPEndPoint"/> returned by the bootstrap provider.</summary>
	public IPEndPoint[]? BootstrapAddresses { get; }

	/// <summary>Contains the current DRT_STATUS of the local DRT instance.</summary>
	public DRT_STATUS Status { get; }
}

internal static class DrtUtil
{
	public static IntPtr Alloc(int size) => Marshal.AllocCoTaskMem(size);

	public static void Free(IntPtr ptr) => Marshal.FreeCoTaskMem(ptr);

	public static IntPtr ToAddrListPtr(IPEndPoint[]? pts)
	{
		if (pts is null || pts.Length == 0)
		{
			return default;
		}

		SocketAddress[] sa = Array.ConvertAll(pts, p => p.Serialize());
		int ptsz = sa.Sum(a => a.Size);
		int strsz = Marshal.SizeOf(typeof(SOCKET_ADDRESS_LIST));
		int sasz = Marshal.SizeOf(typeof(SOCKET_ADDRESS));
		SafeCoTaskMemHandle psal = new(strsz + sasz * (pts.Length - 1) + ptsz);
		psal.Write(pts.Length);
		Span<byte> salSpan = psal.AsSpan<byte>(psal.Size);
		for (int i = 0, aoff = Marshal.OffsetOf(typeof(SOCKET_ADDRESS_LIST), "Address").ToInt32(), asoff = strsz + sasz * (pts.Length - 1); i < pts.Length; i++, aoff += sasz)
		{
			psal.Write(new SOCKET_ADDRESS { iSockaddrLength = sa[i].Size, lpSockaddr = ((IntPtr)psal).Offset(asoff) }, false, aoff);
			for (int j = 0; j < sa[i].Size; j++)
			{
				salSpan[asoff + j] = sa[i][j];
			}

			asoff += sa[i].Size;
		}
		return psal.TakeOwnership();
	}

	public static DRT_DATA ToData(byte[]? data)
	{
		DRT_DATA ret = default;
		if (data is not null)
		{
			ret.pb = data.MarshalToPtr(Alloc, out int cb);
			ret.cb = (uint)cb;
		}
		return ret;
	}

	public static IPEndPoint[]? ToEndPoints(SOCKET_ADDRESS_LIST? al)
	{
		return al.HasValue ? Array.ConvertAll(al.Value.Address, Cvt) : null;

		static IPEndPoint Cvt(SOCKET_ADDRESS a)
		{
			SOCKADDR sa = new(a.lpSockaddr, false, a.iSockaddrLength);
			SocketAddress nsa = new((System.Net.Sockets.AddressFamily)sa.sa_family, sa.Size);
			Span<byte> saspan = sa.AsBytes();
			for (int i = 2; i < sa.Size; i++)
			{
				nsa[i] = saspan[i];
			}

			IPEndPoint ep = new(0, 0);
			return (IPEndPoint)ep.Create(nsa);
		}
	}
}

/// <summary>Abstract base class for a custom DRT security provider.</summary>
public abstract class DrtCustomSecurityProvider : DrtSecurityProvider
{
	private int refCount;

	/// <summary>Initializes a new instance of the <see cref="DrtSecurityProvider"/> class.</summary>
	/// <param name="context">The context.</param>
	protected DrtCustomSecurityProvider(object? context) : base(default)
	{
		unsafe
		{
			prov.Attach = InternalAttach;
			prov.Detach = InternalDetach;
			prov.RegisterKey = InternalRegisterKey;
			prov.UnregisterKey = InternalUnregisterKey;
			prov.ValidateAndUnpackPayload = InternalValidateAndUnpackPayload;
			prov.SecureAndPackPayload = InternalSecureAndPackPayload;
			prov.FreeData = InternalFreeData;
			prov.EncryptData = InternalEncryptData;
			prov.DecryptData = InternalDecryptData;
			prov.GetSerializedCredential = InternalGetSerializedCredential;
			prov.ValidateRemoteCredential = InternalValidateRemoteCredential;
			prov.SignData = InternalSignData;
			prov.VerifyData = InternalVerifyData;
			if (context != null)
				prov.pvContext = GCHandle.Alloc(context).AddrOfPinnedObject();
		}
		AddRef();
	}

	/// <summary>Gets the context provided for all methods.</summary>
	/// <value>The context object.</value>
	protected virtual object? Context => prov.pvContext == IntPtr.Zero ? null : GCHandle.FromIntPtr(prov.pvContext).Target;

	/// <summary>Gets a value indicating whether this instance is attached.</summary>
	/// <value><see langword="true"/> if this instance is attached; otherwise, <see langword="false"/>.</value>
	protected bool IsAttached => refCount > 0;

	/// <summary>Adds the reference.</summary>
	protected void AddRef()
	{
		if (refCount == 0)
			GC.SuppressFinalize(this);
		InterlockedIncrement(ref refCount);
	}

	/// <summary>
	/// Called when the DRT receives a message containing encrypted data. This function is only called when the DRT is operating in the
	/// <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security mode defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pKeyToken">
	/// Contains the encrypted session key that can be decrypted by the recipient of the message and used to decrypt the protected fields.
	/// </param>
	/// <param name="pvKeyContext">Contains the context passed into DrtRegisterKey when the key was registered.</param>
	/// <param name="pData">Contains the decrypted data upon completion of the function.</param>
	protected virtual HRESULT DecryptData([In] byte[] pKeyToken, [Optional] IntPtr pvKeyContext, byte[][] pData) => HRESULT.S_OK;

	/// <summary>
	/// Called when the DRT sends a message containing data that must be encrypted. This function is only called when the DRT is operating in
	/// the <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security mode defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pRemoteCredential">Contains the credential of the peer that will receive the protected message.</param>
	/// <param name="pDataBuffers">Contains the unencrypted buffer.</param>
	/// <param name="pEncryptedBuffers">Contains the encrypted content upon completion of the function.</param>
	/// <param name="pKeyToken">
	/// Contains the encrypted session key that can be decrypted by the recipient of the message and used to decrypted the protected fields.
	/// </param>
	/// <returns></returns>
	protected abstract HRESULT EncryptData([In] byte[] pRemoteCredential, byte[][] pDataBuffers, byte[][] pEncryptedBuffers, out byte[]? pKeyToken);

	/// <summary>Called to release resources previously allocated for a security provider function.</summary>
	/// <param name="pv">Specifies what data to free.</param>
	protected virtual void FreeData([In, Optional] IntPtr pv) => Free(pv);

	/// <summary>
	/// Called when the DRT must provide a credential used to authorize the local node. This function is only called when the DRT is
	/// operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <returns>Contains the serialized credential upon completion of the function.</returns>
	protected virtual byte[]? GetSerializedCredential() => null;

	/// <summary>Called to register a key with the Security Provider.</summary>
	/// <param name="pRegistration">
	/// Pointer to the DRT_REGISTRATION structure created by an application and passed to the DrtRegisterKey function.
	/// </param>
	/// <param name="pvKeyContext">Pointer to the context data created by an application and passed to the DrtRegisterKey function.</param>
	/// <returns></returns>
	protected virtual HRESULT RegisterKey(in DRT_REGISTRATION pRegistration, [In, Optional] IntPtr pvKeyContext) => HRESULT.S_OK;

	/// <summary>Releases this instance.</summary>
	protected void Release()
	{
		if (InterlockedDecrement(ref refCount) == 0)
		{
			if (prov.pvContext != default)
				GCHandle.FromIntPtr(prov.pvContext).Free();
			GC.ReRegisterForFinalize(this);
		}
	}

	/// <summary>
	/// Called when an Authority message is about to be sent on the wire. It is responsible for securing the data before it is sent, and for
	/// packing the service addresses, revoked flag, nonce, and other application data into the Secured Address Payload.
	/// </summary>
	/// <param name="pvKeyContext">Contains the context passed into DrtRegisterKey when the key was registered.</param>
	/// <param name="bProtocolMajor">Pointer to the byte array that represents the protocol major version.</param>
	/// <param name="bProtocolMinor">Pointer to the byte array that represents the protocol minor version.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Any DRT specific flags, currently defined only to be the revoked or deleted flag that need to be packed, secured and sent to another
	/// instance for processing.
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
	/// Pointer to the payload to send on the wire which contains the service addresses, revoked flag, nonce, and other data required by the
	/// security provider. <c>pSecuredAddressPayload.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="pClassifier">
	/// Pointer to the classifier to send in the Authority message. <c>pClassifier.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="pSecuredPayload">
	/// Pointer to the application data payload received in the Authority message. After validation, the original data (after decryption,
	/// removal of signature, and so on.) is output as pPayload. <c>pSecuredPayload.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="pCertChain">
	/// Pointer to the cert chain to send in the Authority message. <c>pCertChain.pb</c> is allocated by the security provider.
	/// </param>
	/// <returns></returns>
	protected abstract HRESULT SecureAndPackPayload([In, Optional] IntPtr pvKeyContext, byte bProtocolMajor, byte bProtocolMinor, uint dwFlags,
		[In] byte[] pKey, [In] byte[]? pPayload, [In] IPEndPoint[]? pAddressList, [In] byte[] pNonce, out byte[] pSecuredAddressPayload,
		out byte[]? pClassifier, out byte[]? pSecuredPayload, out byte[]? pCertChain);

	/// <summary>
	/// Called when the DRT must sign a data blob for inclusion in a DRT protocol message. This function is only called when the DRT is
	/// operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="dataBuffers">Contains the data to be signed.</param>
	/// <param name="keyIdentifier">
	/// Upon completion of this function, contains an index that can be used to select from multiple credentials for use in calculating the signature.
	/// </param>
	/// <param name="signature">Upon completion of this function, contains the signature data.</param>
	/// <returns></returns>
	protected virtual HRESULT SignData(byte[][] dataBuffers, out byte[]? keyIdentifier, out byte[]? signature)
	{
		keyIdentifier = signature = null;
		return HRESULT.S_OK;
	}

	/// <summary>Called to deregister a key with the Security Provider.</summary>
	/// <param name="key">Pointer to the key to which the payload is registered.</param>
	/// <param name="pvKeyContext">Pointer to the context data created by an application and passed to the DrtRegisterKey function.</param>
	/// <returns>Pointer to the context data created by the application and passed to DrtRegisterKey.</returns>
	protected virtual HRESULT UnregisterKey(byte[] key, [In, Optional] IntPtr pvKeyContext) => HRESULT.S_OK;

	/// <summary>
	/// Called when an Authority message is received on the wire. It is responsible for validating the data received, and for unpacking the
	/// service addresses, revoked flag, and nonce from the Secured Address Payload.
	/// </summary>
	/// <param name="pSecuredAddressPayload">
	/// Pointer to the payload received on the wire that contains the service addresses, revoked flag, nonce, and any other data required by
	/// the security provider.
	/// </param>
	/// <param name="pCertChain">Pointer to the cert chain received in the authority message.</param>
	/// <param name="pClassifier">Pointer to the classifier received in the authority message.</param>
	/// <param name="pNonce">
	/// Pointer to the nonce that was sent in the original <c>Inquire</c> or <c>Lookup</c> message. This value must be compared to the value
	/// embedded in the Secured Address Payload to ensure they are the same. This value is fixed at 16 bytes.
	/// </param>
	/// <param name="pSecuredPayload">
	/// Pointer to the application data payload received in the Authority message. After validation, the original data (after decryption,
	/// removal of signature, and so on.) is output as pPayload.
	/// </param>
	/// <param name="pbProtocolMajor">
	/// Pointer to the byte array that represents the protocol major version. This is packed in every DRT packet to identify the version of
	/// the security provider in use when a single DRT instance is supporting multiple Security Providers.
	/// </param>
	/// <param name="pbProtocolMinor">
	/// Pointer to the byte array that represents the protocol minor version. This is packed in every DRT packet to identify the version of
	/// the security provider in use when a single DRT instance is supporting multiple Security Providers.
	/// </param>
	/// <param name="pKey">Pointer to the key to which the payload is registered.</param>
	/// <param name="pPayload">
	/// Pointer to the original payload specified by the remote application. <c>pPayload.pb</c> is allocated by the security provider.
	/// </param>
	/// <param name="ppPublicKey">Pointer to a pointer to the number of service addresses embedded in the secured address payload.</param>
	/// <param name="ppAddressList">
	/// Pointer to a pointer to the service addresses that are embedded in the Secured Address Payload. <c>pAddresses</c> is allocated by the
	/// security provider.
	/// </param>
	/// <param name="pdwFlags">
	/// Any DRT flags currently defined only to be the revoked or deleted flag that need to be unpacked for the local DRT instance processing.
	/// <para><c>Note</c> Currently the only allowed value is: <c>DRT_PAYLOAD_REVOKED (1)</c></para>
	/// </param>
	/// <returns></returns>
	protected abstract HRESULT ValidateAndUnpackPayload([In] byte[] pSecuredAddressPayload, [In] byte[]? pCertChain,
		[In] byte[]? pClassifier, [In] byte[]? pNonce, [In] byte[]? pSecuredPayload,
		out byte pbProtocolMajor, out byte pbProtocolMinor, out byte[] pKey, out byte[]? pPayload,
		out SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO> ppPublicKey, out IPEndPoint[]? ppAddressList,
		out uint pdwFlags);

	/// <summary>Called when the DRT must validate a credential provided by a peer node.</summary>
	/// <param name="pRemoteCredential">Contains the serialized credential provided by the peer node.</param>
	/// <returns></returns>
	protected virtual HRESULT ValidateRemoteCredential(byte[] pRemoteCredential) => HRESULT.S_OK;

	/// <summary>
	/// Called when the DRT must verify a signature calculated over a block of data included in a DRT message. This function is only called
	/// when the DRT is operating in the <c>DRT_SECURE_MEMBERSHIP</c> and <c>DRT_SECURE_CONFIDENTIALPAYLOAD</c> security modes defined by DRT_SECURITY_MODE.
	/// </summary>
	/// <param name="pDataBuffers">Contains the data over which the signature was calculated.</param>
	/// <param name="remoteCredentials">Contains the credentials of the remote node used to calculate the signature.</param>
	/// <param name="keyIdentifier">Contains an index that may be used to select from multiple credentials provided in pRemoteCredentials.</param>
	/// <param name="signature">Contains the signature to be verified.</param>
	/// <returns></returns>
	protected virtual HRESULT VerifyData(byte[][] pDataBuffers, byte[] remoteCredentials, byte[] keyIdentifier, byte[] signature) =>
		signature is null || signature.Length == 0 ? HRESULT.DRT_E_INVALID_MESSAGE : (HRESULT)HRESULT.S_OK;

	private HRESULT InternalAttach(IntPtr pvContext)
	{
		if (InterlockedCompareExchange(ref refCount, 1, 0) != 0)
			return HRESULT.DRT_E_SECURITYPROVIDER_IN_USE;
		AddRef();
		return HRESULT.S_OK;
	}

	private HRESULT InternalDecryptData(IntPtr pvContext, in DRT_DATA pKeyToken, IntPtr pvKeyContext, uint dwBuffers, DRT_DATA[] pData) =>
		DecryptData((byte[])pKeyToken, pvKeyContext, Array.ConvertAll(pData, p => (byte[])p));

	private void InternalDetach(IntPtr pvContext)
	{
		InterlockedCompareExchange(ref refCount, 0, 1);
		Release();
	}

	private HRESULT InternalEncryptData(IntPtr pvContext, in DRT_DATA pRemoteCredential, uint dwBuffers, DRT_DATA[] pDataBuffers, DRT_DATA[] pEncryptedBuffers, out DRT_DATA pKeyToken)
	{
		var hr = EncryptData((byte[])pRemoteCredential, Array.ConvertAll(pDataBuffers, p => (byte[])p), Array.ConvertAll(pEncryptedBuffers, p => (byte[])p), out byte[]? pkt);
		pKeyToken = ToData(pkt);
		return hr;
	}

	private void InternalFreeData(IntPtr pvContext, IntPtr pv) => FreeData(pv);

	private HRESULT InternalGetSerializedCredential(IntPtr pvContext, out DRT_DATA pSelfCredential)
	{
		pSelfCredential = ToData(GetSerializedCredential());
		return HRESULT.S_OK;
	}

	private HRESULT InternalRegisterKey(IntPtr pvContext, in DRT_REGISTRATION pRegistration, IntPtr pvKeyContext) =>
		RegisterKey(pRegistration, pvKeyContext);

	private unsafe HRESULT InternalSecureAndPackPayload(IntPtr pvContext, IntPtr pvKeyContext, byte bProtocolMajor, byte bProtocolMinor,
		uint dwFlags, in DRT_DATA pKey, DRT_DATA* pPayload, IntPtr pAddressList, in DRT_DATA pNonce, out DRT_DATA pSecuredAddressPayload,
		DRT_DATA* pClassifier, DRT_DATA* pSecuredPayload, DRT_DATA* pCertChain)
	{
		HRESULT hr = SecureAndPackPayload(pvContext, bProtocolMajor, bProtocolMinor, dwFlags, (byte[])pKey, pPayload is null ? null : (byte[])(*pPayload),
			ToEndPoints(pAddressList.ToNullableStructure<SOCKET_ADDRESS_LIST>()), (byte[])pNonce, out byte[]? sap, out byte[]? cl, out byte[]? sp, out byte[]? cc);
		pSecuredAddressPayload = ToData(sap);
		if (cl is not null)
			*pClassifier = ToData(cl);
		if (sp is not null)
			*pSecuredPayload = ToData(sp);
		if (cc is not null)
			*pCertChain = ToData(cc);
		return hr;
	}

	private HRESULT InternalSignData(IntPtr pvContext, uint dwBuffers, DRT_DATA[] pDataBuffers, out DRT_DATA pKeyIdentifier, out DRT_DATA pSignature)
	{
		HRESULT hr = SignData(Array.ConvertAll(pDataBuffers, b => (byte[])b), out byte[]? id, out byte[]? sig);
		pKeyIdentifier = ToData(id);
		pSignature = ToData(sig);
		return hr;
	}

	private HRESULT InternalUnregisterKey(IntPtr pvContext, in DRT_DATA pKey, IntPtr pvKeyContext) =>
		UnregisterKey((byte[])pKey);

	private unsafe HRESULT InternalValidateAndUnpackPayload(IntPtr pvContext, in DRT_DATA pSecuredAddressPayload, DRT_DATA* pCertChain,
		DRT_DATA* pClassifier, DRT_DATA* pNonce, DRT_DATA* pSecuredPayload, byte* pbProtocolMajor, byte* pbProtocolMinor,
		out DRT_DATA pKey, DRT_DATA* pPayload, CERT_PUBLIC_KEY_INFO** ppPublicKey, void** ppAddressList, out uint pdwFlags)
	{
		HRESULT hr = ValidateAndUnpackPayload(pSecuredAddressPayload, pCertChain is null ? null : (byte[])(*pCertChain),
			pClassifier is null ? null : (byte[])(*pClassifier), pNonce is null ? null : (byte[])(*pNonce),
			pSecuredPayload is null ? null : (byte[])(*pSecuredPayload), out byte maj, out byte min, out byte[]? k,
			out byte[]? pl, out SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO>? pk, out IPEndPoint[]? al, out pdwFlags);
		*pbProtocolMajor = maj;
		*pbProtocolMinor = min;
		pKey = ToData(k);
		if (pl is not null)
			*pPayload = ToData(pl);
		*ppPublicKey = (CERT_PUBLIC_KEY_INFO*)(pk?.TakeOwnership() ?? IntPtr.Zero);
		*ppAddressList = (void*)ToAddrListPtr(al);
		return hr;
	}

	private HRESULT InternalValidateRemoteCredential(IntPtr pvContext, in DRT_DATA pRemoteCredential) =>
		ValidateRemoteCredential((byte[])pRemoteCredential);

	private HRESULT InternalVerifyData(IntPtr pvContext, uint dwBuffers, DRT_DATA[] pDataBuffers, in DRT_DATA pRemoteCredentials, in DRT_DATA pKeyIdentifier, in DRT_DATA pSignature) =>
		VerifyData(Array.ConvertAll(pDataBuffers, b => (byte[])b), (byte[])pRemoteCredentials, (byte[])pKeyIdentifier, (byte[])pSignature);
}

/*
/// <summary></summary>
/// <seealso cref="Vanara.Net.DrtCustomSecurityProvider"/>
public class CustomNullSecurityProvider : DrtCustomSecurityProvider
{
	internal unsafe class CCustomNullSecuredAddressPayload : IDisposable
	{
		public const ALG_ID DRT_ALGORITHM = ALG_ID.CALG_SHA_256;
		public const string DRT_ALGORITHM_OID = AlgOID.szOID_RSA_SHA1RSA;
		public const uint DRT_DERIVED_KEY_SIZE = 32;

		// default security provider constants
		public const byte DRT_SECURITY_VERSION_MAJOR = 1;

		public const byte DRT_SECURITY_VERSION_MINOR = 0;
		public const uint DRT_SHA2_LENGTH = 32;
		public const uint DRT_SIG_LENGTH = SHA2_SIG_LENGTH;

		// Original 0x8000 + space for extended payload (4k plus some overhead)
		public const uint MAX_MESSAGE_SIZE = 0x8000 + 0x1200;

		public const uint SHA1_SIG_LENGTH = 0x80;
		public const uint SHA2_SIG_LENGTH = 0x80;

		private readonly byte[] m_signature = new byte[DRT_SIG_LENGTH];
		private IPEndPoint[]? m_addressList;
		private byte m_bProtocolVersionMajor;
		private byte m_bProtocolVersionMinor;
		private byte[] m_ddKey;
		private byte[] m_ddNonce;
		private bool m_fAllocated; // set if the data needs to be freed when destroyed (true when deserializing)

		//CERT_PUBLIC_KEY_INFO*
		private SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO>? m_pPublicKey;

		/// <summary>Initializes a new instance of the <see cref="CCustomNullSecuredAddressPayload"/> class.</summary>
		/// <param name="bMajor">The b major.</param>
		/// <param name="bMinor">The b minor.</param>
		/// <param name="key">The key.</param>
		/// <param name="nonce">The nonce.</param>
		/// <param name="pAddressList">The p address list.</param>
		/// <param name="flags">The flags.</param>
		public CCustomNullSecuredAddressPayload(byte bMajor, byte bMinor, byte[] key, byte[] nonce, IPEndPoint[]? pAddressList, uint flags)
		{
			m_bProtocolVersionMajor = bMajor;
			m_bProtocolVersionMinor = bMinor;
			m_ddKey = key;
			m_ddNonce = nonce;
			m_addressList = pAddressList;
			Flags = flags;
		}

		// Purpose: Retrieve or set the flags
		//
		// Args: dwFlags:
		public uint Flags { get; set; }

		// Serialized SecureAddressPayload format: bytes name 1 protocol major version 1 protocol minor version 1 security major version 1
		// security minor version 2 key length (KL) KL key 1 signature length (SL) SL signature 1 nonce length (NL) NL nonce 4 flags
		// ----- public key ----------- 1 algorithm length (AL) 2 key parameters length (PL) 2 public key length (KL) 1 unused bits AL
		// algorithm (byte) PL key parameters KL public key
		// ----- end public key ------- 1 address count
		// ----- for each address ----- 2 address length (AL) AL address data
		// ----- end each address -----
		// Function: CCustomNullSecuredAddressPayload::DeserializeAndValidate
		//
		// Purpose: Deserialize and validate the payload.
		//
		// Args: pData: data to deserialize
		// pNonce: expected nonce
		// pCertChain: opt. remote cert chain (if one was in the message)
		// hCryptProv: crypt provider to use with remote public key
		//
		// Notes: The deserialized data is later retrieved via Get* methods.
		public HRESULT DeserializeAndValidate(byte[] pData, byte[]? pNonce)
		{
			HRESULT hr = HRESULT.S_OK;

			using var deserializer = new MemoryStream(pData, true);
			m_fAllocated = true;

			// protocol version
			m_bProtocolVersionMajor = (byte)deserializer.ReadByte();
			m_bProtocolVersionMinor = (byte)deserializer.ReadByte();

			// security version
			var bVersionMajor = (byte)deserializer.ReadByte();
			var bVersionMinor = (byte)deserializer.ReadByte();

			// ensure we are receiving a version we understand
			if (bVersionMajor != DRT_SECURITY_VERSION_MAJOR || bVersionMinor != DRT_SECURITY_VERSION_MINOR)
			{
				hr = HRESULT.DRT_E_INVALID_MESSAGE;
				goto cleanup;
			}

			// extract key
			var cb = deserializer.Read<ushort>();
			m_ddKey = new byte[cb];
			deserializer.Read(m_ddKey, 0, cb);

			// extract signature
			var b = (byte)deserializer.ReadByte();
			if (b != DRT_SIG_LENGTH)
			{
				hr = HRESULT.DRT_E_INVALID_MESSAGE;
				goto cleanup;
			}

			var pbSignature = deserializer.Position;
			deserializer.Position += DRT_SIG_LENGTH; //deserializer.ReadArray(DRT_SIG_LENGTH, &ddSignature);

			// extract and validate nonce
			cb = (byte)deserializer.ReadByte();
			m_ddNonce = new byte[cb];
			deserializer.Read(m_ddNonce, 0, cb);

			// if a nonce was supplied, ensure it matches the nonce in the message
			if (pNonce != null && (hr = CompareNonce(pNonce)).Failed)
			{
				goto cleanup;
			}

			// extract flags
			Flags = deserializer.Read<uint>();

			// extract public key
			hr = ReadPublicKey(deserializer, out m_pPublicKey);

			// extract addresses
			var addressList = new SOCKET_ADDRESS_LIST { iAddressCount = (byte)deserializer.ReadByte() };
			addressList.Address = new SOCKET_ADDRESS[addressList.iAddressCount];
			for (var i = 0; i < addressList.iAddressCount; i++)
			{
				addressList.Address[i] = new SOCKET_ADDRESS { iSockaddrLength = deserializer.Read<ushort>() };
				// Store just the pointer and then pull that into the packed object
				addressList.Address[i].lpSockaddr = deserializer.Pointer.Offset(deserializer.Position);
				deserializer.Seek(addressList.Address[i].iSockaddrLength, System.IO.SeekOrigin.Current);
			}

			m_addressList = addressList.Pack();

			if (deserializer.Position != deserializer.Length)
			{
				hr = HRESULT.DRT_E_INVALID_MESSAGE;
				goto cleanup;
			}

		cleanup:
			// the remaining allocated memory is Marshal.FreeCoTaskMem in the destructor, or ownership is passed via GetAddresses
			return hr;
		}

		public void Dispose()
		{
			m_addressList?.Dispose();
			m_pPublicKey?.Dispose();
			if (m_fAllocated)
			{
				Marshal.FreeCoTaskMem(m_ddKey.pb);
				Marshal.FreeCoTaskMem(m_ddNonce.pb);
			}
		}

		// Purpose: Retrieve the addresses. This returns the memory allocated during de-serialization, so can only be called once. Since it
		// will only be called once, there isn't benefit to making another copy of the data.
		public void GetAddresses(out SafeCoTaskMemStruct<SOCKET_ADDRESS_LIST> pAddressList)
		{
			pAddressList = m_addressList;
			// this object no longer owns the address list
			m_addressList = default;
		}

		// Purpose: Retrieve the key deserialized earlier. This returns memory allocated during deserialization, and passes ownership to the
		// caller. This method may only be called once.
		public void GetKey(out DRT_DATA pData)
		{
			pData = m_ddKey;
			// this object no longer owns the public key
			m_ddKey = default;
		}

		// Purpose: Retrieve the flags
		public void GetProtocolVersion(out byte pbMajor, out byte pbMinor)
		{
			pbMajor = m_bProtocolVersionMajor;
			pbMinor = m_bProtocolVersionMinor;
		}

		// Purpose: Retrieve the public key deserialized earlier. This returns memory allocated during deserialization, and passes ownership
		// to the caller. This method may only be called once.
		public void GetPublicKey(out SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO> pKey)
		{
			pKey = m_pPublicKey;
			m_pPublicKey = null;
		}

		// Purpose: Serialize the SecuredAddressPayload according to the format specified above, and sign it using the specified credentials.
		//
		// Args: pCertChain: [out] pData: serialized/signed data. pData->pb is allocated.
		//
		// Notes: The data to be serialized has already been set using the Set* methods.
		public HRESULT SerializeAndSign(out byte[] pData)
		{
			CERT_PUBLIC_KEY_INFO publicKey = default;
			using var emptyAddress = new SafeCoTaskMemString("0.0.0.0", CharSet.Ansi);
			publicKey.Algorithm.pszObjId = (IntPtr)emptyAddress;
			publicKey.PublicKey.cbData = sizeof(uint);
			var dwBaadFood = 0xbaadf00d;
			publicKey.PublicKey.pbData = (IntPtr)(&dwBaadFood);

			pData = default;

			uint cbAlgorithmId = emptyAddress.Size;

			// validate that the lengths are all reasonable (fit in the space provided for their count)
			var addressList = m_addressList.Value;
			if (m_ddNonce.cb > byte.MaxValue ||
				addressList.iAddressCount > byte.MaxValue ||
				m_ddKey.cb > ushort.MaxValue || cbAlgorithmId > byte.MaxValue ||
				publicKey.Algorithm.Parameters.cbData > ushort.MaxValue ||
				publicKey.PublicKey.cbData > ushort.MaxValue ||
				publicKey.PublicKey.cUnusedBits > byte.MaxValue)
			{
				return HRESULT.E_INVALIDARG;
			}

			// serialize away
			using var mem = new SafeCoTaskMemHandle(1024);
			var ddDataPtr = new NativeMemoryStream(mem);

			// protocol version
			ddDataPtr.Write(m_bProtocolVersionMajor);
			ddDataPtr.Write(m_bProtocolVersionMinor);

			// security version
			ddDataPtr.Write(DRT_SECURITY_VERSION_MAJOR);
			ddDataPtr.Write(DRT_SECURITY_VERSION_MINOR);

			// key
			ddDataPtr.Write((ushort)m_ddKey.cb);
			ddDataPtr.WriteFromPtr(m_ddKey.pb, m_ddKey.cb);

			// skip over the signature for now (leave it zero while we calculate the signature)
			ddDataPtr.Write((byte)DRT_SIG_LENGTH);
			var pbSignature = ddDataPtr.Position; // save the location of the signature for later
			ddDataPtr.Position += DRT_SIG_LENGTH;

			// nonce
			ddDataPtr.Write((byte)m_ddNonce.cb);
			ddDataPtr.WriteFromPtr(m_ddNonce.pb, m_ddNonce.cb);

			// flags
			ddDataPtr.Write(Flags);

			// public key sizes
			ddDataPtr.Write((byte)cbAlgorithmId);
			ddDataPtr.Write((ushort)publicKey.Algorithm.Parameters.cbData);
			ddDataPtr.Write((ushort)publicKey.PublicKey.cbData);
			ddDataPtr.Write((byte)publicKey.PublicKey.cUnusedBits);

			// public key data
			ddDataPtr.Write(publicKey.Algorithm.pszObjId.ToString(), CharSet.Ansi);
			if (publicKey.Algorithm.Parameters.cbData > 0)
				ddDataPtr.WriteFromPtr(publicKey.Algorithm.Parameters.pbData, publicKey.Algorithm.Parameters.cbData);
			ddDataPtr.WriteFromPtr(publicKey.PublicKey.pbData, publicKey.PublicKey.cbData);

			// addresses
			ddDataPtr.Write((byte)addressList.iAddressCount);
			for (var i = 0; i < addressList.iAddressCount; i++)
			{
				ddDataPtr.Write((ushort)addressList.Address[i].iSockaddrLength);
				ddDataPtr.WriteFromPtr(addressList.Address[i].lpSockaddr, addressList.Address[i].iSockaddrLength);
			}

			// pass the data back to the caller
			pData = new DRT_DATA { cb = (uint)ddDataPtr.Length, pb = mem.TakeOwnership() };

			return HRESULT.S_OK;
		}

		// Purpose:  Read a public key from the stream
		//
		// Args:     [out] ppPublicKey: public key allocated as a single block of memory (with self-refertial embedded pointers)
		private static HRESULT ReadPublicKey(NativeMemoryStream deserializer, out SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO> ppPublicKey)
		{
			ppPublicKey = default;

			try
			{
				var cbAlgorithmId = (byte)deserializer.ReadByte();
				var cbParameters = deserializer.Read<ushort>();
				var cbPublicKey = deserializer.Read<ushort>();
				var cUnusedBits = (byte)deserializer.ReadByte();

				var szAlgId = cbAlgorithmId == 0 ? null : deserializer.Read<string>(CharSet.Ansi);
				var pParamData = cbParameters == 0 ? new byte[0] : deserializer.ReadArray<byte>(cbParameters, false).ToArray();
				var pKeyData = cbPublicKey == 0 ? new byte[0] : deserializer.ReadArray<byte>(cbPublicKey, false).ToArray();

				var cbTotal = sizeof(CERT_PUBLIC_KEY_INFO) + Macros.ALIGN_TO_MULTIPLE(cbAlgorithmId + 1, IntPtr.Size) +
					Macros.ALIGN_TO_MULTIPLE(cbParameters, IntPtr.Size) + Macros.ALIGN_TO_MULTIPLE(cbPublicKey, IntPtr.Size);

				var pPublicKey = new SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO>(cbTotal);
				ref var rpk = ref pPublicKey.AsRef();
				var pbStructIter = ((IntPtr)pPublicKey).Offset(sizeof(CERT_PUBLIC_KEY_INFO)); // skip the structure

				// copy the algorithm id
				rpk.Algorithm.pszObjId = pbStructIter;
				StringHelper.Write(szAlgId, pbStructIter, out var written, true, CharSet.Ansi);
				pbStructIter += (int)Macros.ALIGN_TO_MULTIPLE(written, IntPtr.Size);

				// copy the key parameters
				if (cbParameters > 0)
				{
					rpk.Algorithm.Parameters.cbData = cbParameters;
					rpk.Algorithm.Parameters.pbData = pbStructIter;
					pbStructIter.Write(pParamData);
					pbStructIter += (int)Macros.ALIGN_TO_MULTIPLE(pParamData.Length, IntPtr.Size);
				}

				// copy the key
				rpk.PublicKey.cbData = cbPublicKey;
				rpk.PublicKey.cUnusedBits = cUnusedBits;
				rpk.PublicKey.pbData = pbStructIter;
				pbStructIter.Write(pKeyData);

				ppPublicKey = pPublicKey;

				return HRESULT.S_OK;
			}
			catch (Exception ex)
			{
				return HRESULT.FromException(ex);
			}
		}

		// Purpose: Compare the nonce provided by the DRT to the nonce received on the wire, returning HRESULT.DRT_E_INVALID_MESSAGE if they
		// don't match.
		//
		// Args: pNonce:
		private HRESULT CompareNonce(byte[] pNonce) => pNonce.SequenceEqual(m_ddNonce) ? (HRESULT)HRESULT.S_OK : HRESULT.DRT_E_INVALID_MESSAGE;
	}   
	
	/// <summary>Initializes a new instance of the <see cref="CustomNullSecurityProvider"/> class.</summary>
	/// <param name="context">The context.</param>
	public CustomNullSecurityProvider(object? context) : base(context) { }

	/// <inheritdoc/>
	protected override HRESULT EncryptData([In] byte[] pRemoteCredential, byte[][] pDataBuffers, byte[][] pEncryptedBuffers, out byte[]? pKeyToken)
	{
		HRESULT hr = HRESULT.S_OK;
		pKeyToken = default;

		//copy all input buffers into out buffers unmodified
		for (uint dwIdx = 0; dwIdx < pDataBuffers.GetLength(0); dwIdx++)
		{
			pDataBuffers[dwIdx].CopyTo(pEncryptedBuffers[dwIdx], 0);
		}
		return hr;
	}

	/// <inheritdoc/>
	protected override HRESULT SecureAndPackPayload([In, Optional] IntPtr pvKeyContext, byte bProtocolMajor, byte bProtocolMinor, uint dwFlags,
		[In] byte[] pKey, [In] byte[]? pPayload, [In] IPEndPoint[]? pAddressList, [In] byte[] pNonce, out byte[] pSecuredAddressPayload,
		out byte[]? pClassifier, out byte[]? pSecuredPayload, out byte[]? pCertChain)
	{
		// NULL out the out params
		pClassifier = default;
		pSecuredPayload = default;
		pCertChain = default;

		// set the payload contents
		var sap = new CCustomNullSecuredAddressPayload(bProtocolMajor, bProtocolMinor, pKey, pNonce, pAddressList, dwFlags);
		var hr = sap.SerializeAndSign(out pSecuredAddressPayload);
		if (hr.Failed)
		{
			goto cleanup;
		}

		if (pPayload != null && pSecuredPayload != null)
		{
			pSecuredPayload->cb = pPayload->cb;
			pSecuredPayload->pb = Marshal.AllocCoTaskMem((int)pSecuredPayload->cb);
			if (pSecuredPayload->pb == default)
			{
				hr = HRESULT.E_OUTOFMEMORY;
				goto cleanup;
			}
			pPayload->pb.CopyTo(pSecuredPayload->pb, pSecuredPayload->cb);
		}

		// make a copy of the serialized local cert chain
		if (pCertChain != null)
		{
			pCertChain->cb = sizeof(uint);
			pCertChain->pb = Marshal.AllocCoTaskMem((int)pCertChain->cb);
			if (pCertChain->pb == default)
			{
				hr = HRESULT.E_OUTOFMEMORY;
				goto cleanup;
			}
			pCertChain->pb.Write(0xdeadbeefU, 0, sizeof(uint));
		}

	cleanup:
		// if something failed, free all the out params and NULL them out
		if (hr.Failed)
		{
			Marshal.FreeCoTaskMem(pSecuredAddressPayload.pb);
			pSecuredAddressPayload = default;
			if (pSecuredPayload != null)
			{
				Marshal.FreeCoTaskMem(pSecuredPayload->pb);
				*pSecuredPayload = default;
			}
			if (pCertChain != null)
			{
				Marshal.FreeCoTaskMem(pCertChain->pb);
				*pCertChain = default;
			}
		}

		return hr;
	}

	/// <inheritdoc/>
	protected override HRESULT ValidateAndUnpackPayload([In] byte[] pSecuredAddressPayload, [In] byte[]? pCertChain, [In] byte[]? pClassifier,
		[In] byte[]? pNonce, [In] byte[]? pSecuredPayload, out byte pbProtocolMajor, out byte pbProtocolMinor, out byte[] pKey,
		out byte[]? pPayload, out SafeCoTaskMemStruct<CERT_PUBLIC_KEY_INFO> ppPublicKey, out IPEndPoint[]? ppAddressList, out uint pdwFlags)
	{
		var sap = new CCustomNullSecuredAddressPayload();
		HRESULT hr = HRESULT.S_OK;

		// NULL out the out params
		*pbProtocolMajor = 0;
		*pbProtocolMinor = 0;
		pKey = default;
		if (pPayload != null)
			*pPayload = default;
		*ppPublicKey = null;
		pdwFlags = 0;

		// deserialize Secured Address Payload
		hr = sap.DeserializeAndValidate(pSecuredAddressPayload, pNonce);
		if (hr.Failed)
		{
			goto cleanup;
		}

		// When we asked for the payload validate signature of payload
		if (pPayload != null && pSecuredPayload != null)
		{
			pPayload->cb = pSecuredPayload->cb;
			pPayload->pb = Marshal.AllocCoTaskMem((int)pPayload->cb);
			if (pPayload->pb == default)
			{
				hr = HRESULT.E_OUTOFMEMORY;
				goto cleanup;
			}
			pSecuredPayload->pb.CopyTo(pPayload->pb, pPayload->cb);
		}

		pdwFlags = sap.Flags;

		// everything is valid, time to extract the data
		if (ppAddressList != null)
		{
			sap.GetAddresses(out var addr);
			*ppAddressList = (void*)addr.TakeOwnership();
		}
		sap.GetPublicKey(out var pk);
		*ppPublicKey = (CERT_PUBLIC_KEY_INFO*)pk.TakeOwnership();
		sap.GetKey(out pKey);
		sap.GetProtocolVersion(out *pbProtocolMajor, out *pbProtocolMinor);

	cleanup:
		// if something failed, free all the out params and NULL them out
		if (hr.Failed)
		{
			*pbProtocolMajor = 0;
			*pbProtocolMinor = 0;
			pdwFlags = 0;
			Marshal.FreeCoTaskMem(pKey.pb);
			pKey = default;
			if (pPayload != null)
			{
				Marshal.FreeCoTaskMem(pPayload->pb);
				*pPayload = default;
			}
			Marshal.FreeCoTaskMem((IntPtr)(*ppPublicKey));
			*ppPublicKey = null;

			// free all the addresses
			if (ppAddressList != null)
			{
				Marshal.FreeCoTaskMem((IntPtr)(*ppAddressList));
				*ppAddressList = null;
			}
		}

		return hr;
	}
}
*/