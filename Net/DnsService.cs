#nullable enable

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.DnsApi;

namespace Vanara.Net;

/// <summary>Represents a DNS service.</summary>
/// <seealso cref="System.IDisposable"/>
public class DnsService : IDisposable
{
	private readonly IntPtr ctx;
	private readonly AutoResetEvent evt = new(false);
	private readonly SafePDNS_SERVICE_INSTANCE pSvcInst;
	private bool disposed = false, registering = false;
	private Win32Error err = 0;
	private DNS_SERVICE_REGISTER_REQUEST req;

	/// <summary>Initializes a new instance of the <see cref="DnsService"/> class.</summary>
	/// <param name="serviceName">The name of the service.</param>
	/// <param name="hostName">The name of the host of the service.</param>
	/// <param name="port">The port.</param>
	/// <param name="priority">The service priority.</param>
	/// <param name="weight">The service weight.</param>
	/// <param name="address">The service-associated address and port.</param>
	/// <param name="properties">A dictionary of property keys and values.</param>
	public DnsService(string serviceName, string hostName, ushort port, [Optional] ushort priority,
		[Optional] ushort weight, [Optional] IPAddress? address, [Optional] IDictionary<string, string>? properties)
	{
		using SafeCoTaskMemHandle v4 = address is null ? SafeCoTaskMemHandle.Null : new(address.MapToIPv4().GetAddressBytes());
		using SafeCoTaskMemHandle v6 = address is null ? SafeCoTaskMemHandle.Null : new(address.MapToIPv6().GetAddressBytes());
		pSvcInst = DnsServiceConstructInstance(serviceName, hostName, v4, v6, port,
			priority, weight, (uint)(properties?.Count ?? 0), properties?.Keys.ToArray(), properties?.Values.ToArray());
		ctx = (IntPtr)GCHandle.Alloc(this, GCHandleType.Normal);
	}

	internal DnsService(IntPtr pInst)
	{
		pSvcInst = new SafePDNS_SERVICE_INSTANCE(pInst);
		ctx = (IntPtr)GCHandle.Alloc(this, GCHandleType.Normal);
	}

	/// <summary>A string that represents the name of the host of the service.</summary>
	public string HostName => pSvcInst.pszHostName;

	/// <summary>
	/// A string that represents the service name. This is a fully qualified domain name that begins with a service name, and ends with
	/// ".local". It takes the generalized form "&lt;ServiceName&gt;._&lt;ServiceType&gt;._&lt;TransportProtocol&gt;.local". For example, "MyMusicServer._http._tcp.local".
	/// </summary>
	public string InstanceName => pSvcInst.pszInstanceName;

	/// <summary>A value that contains the interface index on which the service was discovered.</summary>
	public uint InterfaceIndex => pSvcInst.dwInterfaceIndex;

	/// <summary>The service-associated IPv4 address, if defined.</summary>
	public IPAddress? Ip4Address => pSvcInst.ip4Address?.Address.MapToIPv4();

	/// <summary>The service-associated IPv6 address, if defined.</summary>
	public IPAddress? Ip6Address => pSvcInst.ip6Address?.Address.MapToIPv6();

	/// <summary>Gets a value indicating whether this instance is registered.</summary>
	/// <value><see langword="true"/> if this instance is registered; otherwise, <see langword="false"/>.</value>
	public bool IsRegistered => req.Version != 0;

	/// <summary>A value that represents the port on which the service is running.</summary>
	public ushort Port => pSvcInst.wPort;

	/// <summary>A value that represents the service priority.</summary>
	public ushort Priority => pSvcInst.wPriority;

	/// <summary>The DNS service properties.</summary>
	public IReadOnlyDictionary<string, string> Properties => pSvcInst.properties;

	/// <summary>A value that represents the service weight.</summary>
	public ushort Weight => pSvcInst.wWeight;

	/// <summary>Used to obtain more information about a service advertised on the local network.</summary>
	/// <param name="serviceName">
	/// The service name. This is a fully qualified domain name that begins with a service name, and ends with ".local". It takes the
	/// generalized form "&lt;ServiceName&gt;._&lt;ServiceType&gt;._&lt;TransportProtocol&gt;.local". For example, "MyMusicServer._http._tcp.local".
	/// </param>
	/// <param name="adapter">The interface over which the query is sent. If <see langword="null"/>, then all interfaces will be considered.</param>
	/// <param name="cancellationToken">A cancellation token that can be used to cancel a pending asynchronous resolve operation.</param>
	/// <returns>If successful, returns a new <see cref="DnsService"/> instance; otherwise, throws the appropriate DNS-specific exception.</returns>
	/// <remarks>This function is asynchronous.</remarks>
	public static async Task<DnsService> ResolveAsync(string serviceName, NetworkInterface? adapter = null, CancellationToken cancellationToken = default)
	{
		using ManualResetEvent evt = new(false);
		Win32Error err = 0;
		IntPtr result = default;
		DNS_SERVICE_RESOLVE_REQUEST res = new()
		{
			Version = DNS_QUERY_REQUEST_VERSION1,
			InterfaceIndex = (uint)(adapter?.GetIPProperties().GetIPv4Properties().Index ?? 0),
			QueryName = serviceName,
			pResolveCompletionCallback = ResolveCallback,
		};
		DnsServiceResolve(res, out DNS_SERVICE_CANCEL c).ThrowUnless(Win32Error.DNS_REQUEST_PENDING);
		await Task.Run(() =>
		{
			if (WaitHandle.WaitAny(new[] { cancellationToken.WaitHandle, evt }) == 0)
				DnsServiceResolveCancel(c);
		}, cancellationToken);
		return result != IntPtr.Zero ? new DnsService(result) : throw err.GetException();

		void ResolveCallback(Win32Error Status, IntPtr pQueryContext, IntPtr pInstance)
		{
			if ((err = Status).Succeeded)
				result = pInstance;
			evt.Set();
		}
	}

	/// <summary>Used to remove a registered service.</summary>
	/// <returns>If not successful, throws an appropriate DNS-specific exception.</returns>
	/// <remarks>This function is asynchronous.</remarks>
	public async Task DeRegisterAsync()
	{
		if (!IsRegistered)
			return;

		if (registering)
			throw new InvalidOperationException("Service is already being deregistered.");

		registering = true;
		DnsServiceDeRegister(req, IntPtr.Zero);
		await Task.Run(() => evt.WaitOne());
		registering = false;
		req = default;
		err.ThrowIfFailed();
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		if (disposed)
			return;

		disposed = true;
		pSvcInst?.Dispose();
		if (ctx != IntPtr.Zero)
			GCHandle.FromIntPtr(ctx).Free();
	}

	/// <summary>Used to register a discoverable service on this device.</summary>
	/// <param name="unicastEnabled">
	/// <see langword="true"/> if the DNS protocol should be used to advertise the service; <see langword="false"/> if the mDNS protocol
	/// should be used.
	/// </param>
	/// <param name="adapter">
	/// An optional value that contains the network interface over which the service is to be advertised. If <see langword="null"/>, then all
	/// interfaces will be considered.
	/// </param>
	/// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchonous operation.</param>
	/// <exception cref="System.InvalidOperationException">Service is already registered.</exception>
	/// <remarks>
	/// This function is asynchronous. To deregister the service, call DnsServiceDeRegister. The registration is tied to the lifetime of the
	/// calling process. If the process goes away, the service will be automatically deregistered.
	/// </remarks>
	public async Task RegisterAsync(bool unicastEnabled = false, NetworkInterface? adapter = null, CancellationToken cancellationToken = default)
	{
		if (IsRegistered)
			throw new InvalidOperationException("Service is already registered.");

		if (registering)
			throw new InvalidOperationException("Service is already being registered.");

		req = new DNS_SERVICE_REGISTER_REQUEST()
		{
			Version = DNS_QUERY_REQUEST_VERSION1,
			InterfaceIndex = (uint)(adapter?.GetIPProperties().GetIPv4Properties().Index ?? 0),
			pServiceInstance = pSvcInst,
			pQueryContext = ctx,
			pRegisterCompletionCallback = RegCallback,
			unicastEnabled = unicastEnabled
		};
		registering = true;
		DnsServiceRegister(req, out DNS_SERVICE_CANCEL svcCancel).ThrowUnless(Win32Error.DNS_REQUEST_PENDING);
		await Task.Run(() =>
		{
			if (WaitHandle.WaitAny(new[] { cancellationToken.WaitHandle, evt }) == 0)
				DnsServiceResolveCancel(svcCancel);
		}, cancellationToken);
		registering = false;
		err.ThrowIfFailed();
	}

	private static void RegCallback(Win32Error Status, IntPtr pQueryContext, IntPtr pInstance)
	{
		using SafePDNS_SERVICE_INSTANCE i = new(pInstance);
		DnsService? svc = GCHandle.FromIntPtr(pQueryContext).Target as DnsService;
		if (svc is not null)
		{
			svc.err = Status;
			svc.evt.Set();
		}
	}
}