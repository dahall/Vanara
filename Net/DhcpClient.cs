using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Vanara.PInvoke;
using static Vanara.PInvoke.Dhcp;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Net;

/// <summary>Encapsulates the functions and properties for a DHCP client.</summary>
/// <seealso cref="System.IDisposable"/>
public class DhcpClient : IDisposable
{
#pragma warning disable IDE0052 // Remove unread private members
	private static readonly DhcpInit init = new();
#pragma warning restore IDE0052 // Remove unread private members

	private readonly SafeEventHandle closing = CreateEvent(default, false, false), updateList = CreateEvent(default, false, false);
	private readonly SafeHTHREAD hThread;
	private readonly Dictionary<HEVENT, DHCP_OPTION_ID> paramChgEvents = new();

	/// <summary>Initializes a new instance of the <see cref="DhcpClient"/> class.</summary>
	public DhcpClient()
	{
		var h = GCHandle.Alloc(this, GCHandleType.Normal);
		hThread = CreateThread(default, 0, ThreadProc, (IntPtr)h, CREATE_THREAD_FLAGS.RUN_IMMEDIATELY, out _);
	}

	/// <summary>
	/// Occurs when the value related to a <see cref="DHCP_OPTION_ID"/> has changed.
	/// <para>Use the <see cref="ChangeEventIds"/> to set the list of identifiers that are watched.</para>
	/// </summary>
	public event Action<DHCP_OPTION_ID>? ParamChanged;

	/// <summary>
	/// Specifies whether or not the client may assume that all subnets of the IP network to which the client is connected use the same MTU
	/// as the subnet of that network to which the client is directly connected. A value of true indicates that all subnets share the same
	/// MTU. A value of false means that the client should assume that some subnets of the directly connected network may have smaller MTUs.
	/// </summary>
	public bool AllSubnetsMTU => GetParam<bool>(DHCP_OPTION_ID.OPTION_ALL_SUBNETS_MTU);

	/// <summary>Specifies the timeout in seconds for ARP cache entries.</summary>
	public TimeSpan ARPCacheTimeout => TimeSpan.FromSeconds(GetParam<uint>(DHCP_OPTION_ID.OPTION_ARP_CACHE_TIMEOUT));

	/// <summary>
	/// Specifies whether or not the client should respond to subnet mask requests using ICMP. A value of false indicates that the client
	/// should not respond. A value of true means that the client should respond.
	/// </summary>
	public bool BeAMaskSupplier => GetParam<bool>(DHCP_OPTION_ID.OPTION_BE_A_MASK_SUPPLIER);

	/// <summary>
	/// Specifies whether or not the client should solicit routers using the Router Discovery mechanism defined in RFC 1256. A value of false
	/// indicates that the client should not perform router discovery. A value of true means that the client should perform router discovery.
	/// </summary>
	public bool BeARouter => GetParam<bool>(DHCP_OPTION_ID.OPTION_BE_A_ROUTER);

	/// <summary>
	/// Identifies a bootstrap file. If supported by the client, it should have the same effect as the filename declaration. BOOTP clients
	/// are unlikely to support this option. Some DHCP clients will support it, and others actually require it.
	/// </summary>
	public string? BootfileName => GetParam<string>(DHCP_OPTION_ID.OPTION_BOOTFILE_NAME);

	/// <summary>This option specifies the length in 512-octet blocks of the default boot image for the client.</summary>
	public ushort BootFileSize => GetParam<ushort>(DHCP_OPTION_ID.OPTION_BOOT_FILE_SIZE);

	/// <summary>
	/// This option specifies the broadcast address in use on the client’s subnet. Legal values for broadcast addresses are specified in
	/// section 3.2.1.3 of STD 3 (RFC1122).
	/// </summary>
	public IPAddress BroadcastAddress => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_BROADCAST_ADDRESS));

	/// <summary>
	/// Gets or sets the list of <see cref="DHCP_OPTION_ID"/> values that, when changed, will fire the <see cref="ParamChanged"/> event.
	/// </summary>
	/// <value>The list of <see cref="DHCP_OPTION_ID"/> values that, when changed, will fire the <see cref="ParamChanged"/> event.</value>
	public DHCP_OPTION_ID[] ChangeEventIds
	{
		get => paramChgEvents.Values.ToArray();
		set
		{
			ClearListeners();
			updateList.Set();
			string? adapter = Adapter;
			if (value is null || value.Length == 0 || adapter is null) return;
			foreach (DHCP_OPTION_ID id in value)
			{
				if (DhcpRegisterParamChange(DHCPCAPI_REGISTER_HANDLE_EVENT, default, adapter, default, DHCPCAPI_PARAMS_ARRAY.Make(out _, id), out HEVENT hEvt).Succeeded)
				{
					paramChgEvents.Add(hEvt, id);
				}
			}
			updateList.Set();
		}
	}

	/// <summary>
	/// Class identifier (ID) that should be used if DHCP INFORM messages are being transmitted onto the network. This value is optional.
	/// </summary>
	public byte[]? ClassId { get; set; }

	/// <summary>
	/// This option is used by some DHCP clients as a way for users to specify identifying information to the client. This can be used in a
	/// similar way to the vendor-class-identifier option, but the value of the option is specified by the user, not the vendor. Most recent
	/// DHCP clients have a way in the user interface to specify the value for this identifier, usually as a text string.
	/// </summary>
	public string? ClientClassInfo => GetParam<string>(DHCP_OPTION_ID.OPTION_CLIENT_CLASS_INFO);

	/// <summary>
	/// This option can be used to specify a DHCP client identifier in a host declaration, so that dhcpd can find the host record by matching
	/// against the client identifier.
	/// </summary>
	public string? ClientId => GetParam<string>(DHCP_OPTION_ID.OPTION_CLIENT_ID);

	/// <summary>
	/// The cookie server option specifies a list of RFC 865 cookie servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] CookieServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_COOKIE_SERVERS));

	/// <summary>This option specifies the default time-to-live that the client should use on outgoing datagrams.</summary>
	public byte DefaultTTL => GetParam<byte>(DHCP_OPTION_ID.OPTION_DEFAULT_TTL);

	/// <summary>This option specifies the domain name that client should use when resolving hostnames via the Domain Name System.</summary>
	public string? DomainName => GetParam<string>(DHCP_OPTION_ID.OPTION_DOMAIN_NAME);

	/// <summary>
	/// The domain-name-servers option specifies a list of Domain Name System (STD 13, RFC 1035) name servers available to the client.
	/// Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] DomainNameServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_DOMAIN_NAME_SERVERS));

	/// <summary>
	/// This option specifies whether or not the client should use Ethernet Version 2 (RFC 894) or IEEE 802.3 (RFC 1042) encapsulation if the
	/// interface is an Ethernet. A value of false indicates that the client should use RFC 894 encapsulation. A value of true means that the
	/// client should use RFC 1042 encapsulation.
	/// </summary>
	public bool EthernetEncapsulation => GetParam<bool>(DHCP_OPTION_ID.OPTION_ETHERNET_ENCAPSULATION);

	/// <summary>
	/// This option specifies the name of a file containing additional options to be interpreted according to the DHCP option format as
	/// specified in RFC2132.
	/// </summary>
	public string? ExtensionsPath => GetParam<string>(DHCP_OPTION_ID.OPTION_EXTENSIONS_PATH);

	/// <summary>
	/// This option specifies the name of the client. The name may or may not be qualified with the local domain name (it is preferable to
	/// use the domain-name option to specify the domain name). See RFC 1035 for character set restrictions. This option is only honored by
	/// dhclient-script(8) if the hostname for the client machine is not set.
	/// </summary>
	public string? HostName => GetParam<string>(DHCP_OPTION_ID.OPTION_HOST_NAME);

	/// <summary>
	/// The ien116-name-servers option specifies a list of IEN 116 name servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] IEN116NameServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_IEN116_NAME_SERVERS));

	/// <summary>The Internet Explorer proxy.</summary>
	public string? IEProxy => GetParam<string>(DHCP_OPTION_ID.OPTION_MSFT_IE_PROXY);

	/// <summary>
	/// The impress-server option specifies a list of Imagen Impress servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] ImpressServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_IMPRESS_SERVERS));

	/// <summary></summary>
	public uint KeepAliveDataSize => GetParam<uint>(DHCP_OPTION_ID.OPTION_KEEP_ALIVE_DATA_SIZE);

	/// <summary>
	/// This option specifies the interval (in seconds) that the client TCP should wait before sending a keepalive message on a TCP
	/// connection. The time is specified as a 32-bit unsigned integer. A value of zero indicates that the client should not generate
	/// keepalive messages on connections unless specifically requested by an application.
	/// </summary>
	public TimeSpan KeepAliveInterval => TimeSpan.FromSeconds(GetParam<uint>(DHCP_OPTION_ID.OPTION_KEEP_ALIVE_INTERVAL));

	/// <summary>
	/// This option is used in a client request (DHCPDISCOVER or DHCPREQUEST) to allow the client to request a lease time for the IP address.
	/// In a server reply (DHCPOFFER), a DHCP server uses this option to specify the lease time it is willing to offer.
	/// </summary>
	public TimeSpan LeaseTime => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_LEASE_TIME));

	/// <summary>
	/// The log-server option specifies a list of MIT-LCS UDP log servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] LogServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_LOG_SERVERS));

	/// <summary>
	/// The LPR server option specifies a list of RFC 1179 line printer servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] LPRServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_LPR_SERVERS));

	/// <summary>
	/// This option specifies the maximum size datagram that the client should be prepared to reassemble. The minimum legal value is 576.
	/// </summary>
	public ushort MaxReassemblySize => GetParam<ushort>(DHCP_OPTION_ID.OPTION_MAX_REASSEMBLY_SIZE);

	/// <summary>
	/// This option specifies the path-name of a file to which the client’s core image should be dumped in the event the client crashes. The
	/// path is formatted as a character string consisting of characters from the NVT ASCII character set.
	/// </summary>
	public string? MeritDumpFile => GetParam<string>(DHCP_OPTION_ID.OPTION_MERIT_DUMP_FILE);

	/// <summary>
	/// This option is used by a DHCP server to provide an error message to a DHCP client in a DHCPNAK message in the event of a failure. A
	/// client may use this option in a DHCPDECLINE message to indicate why the client declined the offered parameters.
	/// </summary>
	public string? Message => GetParam<string>(DHCP_OPTION_ID.OPTION_MESSAGE);

	/// <summary>
	/// This option, when sent by the client, specifies the maximum size of any response that the server sends to the client. When specified
	/// on the server, if the client did not send a dhcp-max-message-size option, the size specified on the server is used. This works for
	/// BOOTP as well as DHCP responses.
	/// </summary>
	public ushort MessageLength => GetParam<ushort>(DHCP_OPTION_ID.OPTION_MESSAGE_LENGTH);

	/// <summary>This option, sent by both client and server, specifies the type of DHCP message contained in the DHCP packet.</summary>
	public DhcpMessageType MessageType => GetParam<DhcpMessageType>(DHCP_OPTION_ID.OPTION_MESSAGE_TYPE);

	/// <summary>This option specifies the MTU to use on this interface. The minimum legal value for the MTU is 68.</summary>
	public ushort MTU => GetParam<ushort>(DHCP_OPTION_ID.OPTION_MTU);

	/// <summary>
	/// The NetBIOS datagram distribution server (NBDD) option specifies a list of RFC 1001/1002 NBDD servers listed in order of preference.
	/// </summary>
	public IPAddress[] NetBIOSDatagramServer => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_NETBIOS_DATAGRAM_SERVER));

	/// <summary>
	/// The NetBIOS name server (NBNS) option specifies a list of RFC 1001/1002 NBNS name servers listed in order of preference. NetBIOS Name
	/// Service is currently more commonly referred to as WINS. WINS servers can be specified using the netbios-name-servers option.
	/// </summary>
	public IPAddress[] NetBIOSNameServer => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_NETBIOS_NAME_SERVER));

	/// <summary>
	/// The NetBIOS node type option allows NetBIOS over TCP/IP clients which are configurable to be configured as described in RFC
	/// 1001/1002. The value is specified as a single octet which identifies the client type.
	/// </summary>
	public NetBIOSNodeType NetBIOSNodeType => GetParam<NetBIOSNodeType>(DHCP_OPTION_ID.OPTION_NETBIOS_NODE_TYPE);

	/// <summary>
	/// The NetBIOS scope option specifies the NetBIOS over TCP/IP scope parameter for the client as specified in RFC 1001/1002. See RFC1001,
	/// RFC1002, and RFC1035 for character-set restrictions.
	/// </summary>
	public string? NetBIOSScopeOption => GetParam<string>(DHCP_OPTION_ID.OPTION_NETBIOS_SCOPE_OPTION);

	/// <summary>
	/// The netinfo-server-address option has not been described in any RFC, but has been allocated (and is claimed to be in use) by Apple
	/// Computers. It’s hard to say if the above is the correct format, or what clients might be expected to do if values were configured.
	/// Use at your own risk.
	/// </summary>
	public IPAddress[] NetworkInfoServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_NETWORK_INFO_SERVERS));

	/// <summary>
	/// This option specifies the name of the client’s NIS (Sun Network Information Services) domain. The domain is formatted as a character
	/// string consisting of characters from the NVT ASCII character set.
	/// </summary>
	public string? NetworkInfoServiceDomain => GetParam<string>(DHCP_OPTION_ID.OPTION_NETWORK_INFO_SERVICE_DOM);

	/// <summary>
	/// The NNTP server option specifies a list of NNTP servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] NetworkTimeServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_NETWORK_TIME_SERVERS));

	/// <summary>
	/// This option specifies whether the client should configure its IP layer to allow forwarding of datagrams with non-local source routes
	/// (see Section 3.3.5 of [4] for a discussion of this topic). A value of false means disallow forwarding of such datagrams, and a value
	/// of true means allow forwarding.
	/// </summary>
	public bool NonLocalSourceRouting => GetParam<bool>(DHCP_OPTION_ID.OPTION_NON_LOCAL_SOURCE_ROUTING);

	/// <summary></summary>
	public bool OkToOverlay => GetParam<bool>(DHCP_OPTION_ID.OPTION_OK_TO_OVERLAY);

	/// <summary>
	/// This option, when sent by the client, specifies which options the client wishes the server to return. Normally, in the ISC DHCP
	/// client, this is done using the request statement. If this option is not specified by the client, the DHCP server will normally return
	/// every option that is valid in scope and that fits into the reply. When this option is specified on the server, the server returns the
	/// specified options. This can be used to force a client to take options that it hasn’t requested, and it can also be used to tailor the
	/// response of the DHCP server for clients that may need a more limited set of options than those the server would normally return.
	/// </summary>
	public byte[] ParameterRequestList => GetParam<byte[]>(DHCP_OPTION_ID.OPTION_PARAMETER_REQUEST_LIST) ?? new byte[0];

	/// <summary>
	/// This option specifies the timeout (in seconds) to use when aging Path MTU values discovered by the mechanism defined in RFC 1191.
	/// </summary>
	public TimeSpan PathMTUAgingTimeout => TimeSpan.FromSeconds(GetParam<uint>(DHCP_OPTION_ID.OPTION_PMTU_AGING_TIMEOUT));

	/// <summary>
	/// This option specifies a table of MTU sizes to use when performing Path MTU Discovery as defined in RFC 1191. The table is formatted
	/// as a list of 16-bit unsigned integers, ordered from smallest to largest. The minimum MTU value cannot be smaller than 68.
	/// </summary>
	public ushort[] PathMTUPlateauTable => GetParam<ushort[]>(DHCP_OPTION_ID.OPTION_PMTU_PLATEAU_TABLE) ?? new ushort[0];

	/// <summary>
	/// This option specifies whether or not the client should perform subnet mask discovery using ICMP. A value of false indicates that the
	/// client should not perform mask discovery. A value of true means that the client should perform mask discovery.
	/// </summary>
	public bool PerformMaskDiscovery => GetParam<bool>(DHCP_OPTION_ID.OPTION_PERFORM_MASK_DISCOVERY);

	/// <summary>
	/// This option specifies whether or not the client should solicit routers using the Router Discovery mechanism defined in RFC 1256. A
	/// value of false indicates that the client should not perform router discovery. A value of true means that the client should perform
	/// router discovery.
	/// </summary>
	public bool PerformRouterDiscovery => GetParam<bool>(DHCP_OPTION_ID.OPTION_PERFORM_ROUTER_DISCOVERY);

	/// <summary>
	/// This option specifies policy filters for non-local source routing. The filters consist of a list of IP addresses and masks which
	/// specify destination/mask pairs with which to filter incoming source routes.
	/// <para>Any source routed datagram whose next-hop address does not match one of the filters should be discarded by the client.</para>
	/// </summary>
	public IPAddress[] PolicyFilter => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_POLICY_FILTER_FOR_NLSR));

	/// <summary>
	/// <para>
	/// This option specifies the number of seconds from the time a client gets an address until the client transitions to the REBINDING state.
	/// </para>
	/// <para>This option is user configurable, but it will be ignored if the value is greater than or equal to the lease time.</para>
	/// <para>
	/// To make DHCPv4+DHCPv6 migration easier in the future, any value configured in this option is also used as a DHCPv6 "T1" (renew) time.
	/// </para>
	/// </summary>
	public TimeSpan RebindTime => TimeSpan.FromSeconds(GetParam<uint>(DHCP_OPTION_ID.OPTION_REBIND_TIME));

	/// <summary>
	/// <para>
	/// This option specifies the number of seconds from the time a client gets an address until the client transitions to the RENEWING state.
	/// </para>
	/// <para>
	/// This option is user configurable, but it will be ignored if the value is greater than or equal to the rebinding time, or lease time.
	/// </para>
	/// <para>To make DHCPv4+DHCPv6 migration easier in the future,</para>
	/// </summary>
	public TimeSpan RenewalTime => TimeSpan.FromSeconds(GetParam<uint>(DHCP_OPTION_ID.OPTION_RENEWAL_TIME));

	/// <summary>
	/// <para>This option is used by the client in a DHCPDISCOVER to request that a particular IP address be assigned.</para>
	/// <para>This option is not user configurable.</para>
	/// </summary>
	public IPAddress RequestedAddress => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_REQUESTED_ADDRESS));

	/// <summary></summary>
	public IPAddress[] RlpServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_RLP_SERVERS));

	/// <summary>
	/// This option specifies the path-name that contains the client’s root disk. The path is formatted as a character string consisting of
	/// characters from the NVT ASCII character set.
	/// </summary>
	public string? RootDisk => GetParam<string>(DHCP_OPTION_ID.OPTION_ROOT_DISK);

	/// <summary>
	/// The routers option specifies a list of IP addresses for routers on the client’s subnet. Routers should be listed in order of preference.
	/// </summary>
	public IPAddress RouterAddress => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_ROUTER_ADDRESS));

	/// <summary>This option specifies the address to which the client should transmit router solicitation requests.</summary>
	public IPAddress RouterSolicitationAddress => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_ROUTER_SOLICITATION_ADDR));

	/// <summary>
	/// GUID of the adapter on which requested data is being made. Must be under 256 characters. If this value is <see langword="null"/>, the
	/// first adapter with an address supplied via DHCP will be used.
	/// </summary>
	public string? SelectedAdapterId { get; set; }

	/// <summary>
	/// <para>
	/// This option is used in DHCPOFFER and DHCPREQUEST messages, and may optionally be included in the DHCPACK and DHCPNAK messages. DHCP
	/// servers include this option in the DHCPOFFER in order to allow the client to distinguish between lease offers. DHCP clients use the
	/// contents of the ´server identifier´ field as the destination address for any DHCP messages unicast to the DHCP server. DHCP clients
	/// also indicate which of several lease offers is being accepted by including this option in a DHCPREQUEST message.
	/// </para>
	/// <para>The value of this option is the IP address of the server.</para>
	/// <para>This option is not directly user configurable. See the server-identifier server option in dhcpd.conf(5).</para>
	/// </summary>
	public IPAddress ServerIdentifier => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_SERVER_IDENTIFIER));

	/// <summary>
	/// <para>
	/// This option specifies a list of static routes that the client should install in its routing cache. If multiple routes to the same
	/// destination are specified, they are listed in descending order of priority.
	/// </para>
	/// <para>
	/// The routes consist of a list of IP address pairs. The first address is the destination address, and the second address is the router
	/// for the destination.
	/// </para>
	/// <para>
	/// The default route (0.0.0.0) is an illegal destination for a static route. To specify the default route, use the routers option. Also,
	/// please note that this option is not intended for classless IP routing - it does not include a subnet mask. Since classless IP routing
	/// is now the most widely deployed routing standard, this option is virtually useless, and is not implemented by any of the popular DHCP
	/// clients, for example the Microsoft DHCP client.
	/// </para>
	/// </summary>
	public IPAddress[] StaticRoutes => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_STATIC_ROUTES));

	/// <summary>
	/// The subnet mask option specifies the client’s subnet mask as per RFC 950. If no subnet mask option is provided anywhere in scope, as
	/// a last resort dhcpd will use the subnet mask from the subnet declaration for the network on which an address is being assigned.
	/// However, any subnet-mask option declaration that is in scope for the address being assigned will override the subnet mask specified
	/// in the subnet declaration.
	/// </summary>
	public IPAddress SubnetMask => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_SUBNET_MASK));

	/// <summary>This specifies the IP address of the client’s swap server.</summary>
	public IPAddress SwapServer => new(GetParam<uint>(DHCP_OPTION_ID.OPTION_SWAP_SERVER));

	/// <summary>
	/// This option is used to identify a TFTP server and, if supported by the client, should have the same effect as the server-name
	/// declaration. BOOTP clients are unlikely to support this option. Some DHCP clients will support it, and others actually require it.
	/// </summary>
	public string? TFTPServerName => GetParam<string>(DHCP_OPTION_ID.OPTION_TFTP_SERVER_NAME);

	/// <summary>The time-offset option specifies the offset of the client’s subnet in seconds from Coordinated Universal Time (UTC).</summary>
	public DateTimeOffset TimeOffset => new(0, TimeSpan.FromSeconds(GetParam<uint>(DHCP_OPTION_ID.OPTION_TIME_OFFSET)));

	/// <summary>
	/// The time-server option specifies a list of RFC 868 time servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] TimeServers => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_TIME_SERVERS));

	/// <summary>
	/// This option specifies whether or not the client should negotiate the use of trailers (RFC 893 [14]) when using the ARP protocol. A
	/// value of false indicates that the client should not attempt to use trailers. A value of true means that the client should attempt to
	/// use trailers.
	/// </summary>
	public bool Trailers => GetParam<bool>(DHCP_OPTION_ID.OPTION_TRAILERS);

	/// <summary>This option specifies the default TTL that the client should use when sending TCP segments. The minimum value is 1.</summary>
	public byte TTL => GetParam<byte>(DHCP_OPTION_ID.OPTION_TTL);

	/// <summary>
	/// <para>
	/// This option is used by some DHCP clients to identify the vendor type and possibly the configuration of a DHCP client. The information
	/// is a string of bytes whose contents are specific to the vendor and are not specified in a standard. To see what vendor class
	/// identifier clients are sending, you can write the following in your DHCP server configuration file:
	/// </para>
	/// <para>set vendor-string = option vendor-class-identifier;</para>
	/// <para>
	/// This will result in all entries in the DHCP server lease database file for clients that sent vendor-class-identifier options having a
	/// set statement that looks something like this:
	/// </para>
	/// <para>set vendor-string = "SUNW.Ultra-5_10";</para>
	/// <para>
	/// The vendor-class-identifier option is normally used by the DHCP server to determine the options that are returned in the
	/// vendor-encapsulated-options option. Please see the VENDOR ENCAPSULATED OPTIONS section later in this manual page for further information.
	/// </para>
	/// </summary>
	public string? VendorSpecInfo => GetParam<string>(DHCP_OPTION_ID.OPTION_VENDOR_SPEC_INFO);

	/// <summary>
	/// This option specifies a list of systems that are running the X Window System Display Manager and are available to the client.
	/// Addresses should be listed in order of preference.
	/// </summary>
	public IPAddress[] XwindowDisplayManager => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_XWINDOW_DISPLAY_MANAGER));

	/// <summary>
	/// This option specifies a list of X Window System Font servers available to the client. Servers should be listed in order of preference.
	/// </summary>
	public IPAddress[] XwindowFontServer => ToIP(GetParam<uint[]>(DHCP_OPTION_ID.OPTION_XWINDOW_FONT_SERVER));

	internal static NetworkInterface? CurrentAdapter => NetworkInterface.GetAllNetworkInterfaces().
			Where(i => i.NetworkInterfaceType == NetworkInterfaceType.Ethernet && i.OperationalStatus == OperationalStatus.Up &&
				i.Supports(NetworkInterfaceComponent.IPv4) && (i.GetIPProperties()?.GetIPv4Properties().IsDhcpEnabled ?? false)).
			FirstOrDefault();

	internal string? Adapter => SelectedAdapterId ?? CurrentAdapter?.Id;

	/// <summary>Gets the original subnet mask.</summary>
	/// <returns>The retrieved subnet mask.</returns>
	public IPAddress GetOriginalSubnetMask()
	{
		if (Adapter is null) return IPAddress.None;
		DhcpGetOriginalSubnetMask(Adapter, out DHCP_IP_ADDRESS mask);
		return new(mask.value);
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		ClearListeners();
		closing.Set();
		hThread.Close();
	}

	/// <summary>Gets the current DHCP servers for this client.</summary>
	/// <returns>A sequence of addresses of DHCP servers.</returns>
	public IEnumerable<IPAddress> GetDhcpServers() => NetworkInterface.GetAllNetworkInterfaces().Where(i => i.OperationalStatus == OperationalStatus.Up).SelectMany(i => i.GetIPProperties().DhcpServerAddresses).Distinct();

	/// <summary>The <c>DhcpRemoveDNSRegistrations</c> function removes all DHCP-initiated DNS registrations for the client.</summary>
	public void RemoveDNSRegistrations() => DhcpRemoveDNSRegistrations().ThrowIfFailed();

	private void ClearListeners()
	{
		foreach (KeyValuePair<HEVENT, DHCP_OPTION_ID> kv in paramChgEvents)
		{
			DhcpDeRegisterParamChange(0, default, kv.Key);
		}
		paramChgEvents.Clear();
	}

	private T? GetParam<T>(DHCP_OPTION_ID optionId)
	{
		string? adapter = Adapter ?? throw new InvalidOperationException("No adapter selected.");

		using SafeCoTaskMemHandle pClassIdData = ClassId is null ? SafeCoTaskMemHandle.Null : new(ClassId);
		using SafeCoTaskMemStruct<DHCPCAPI_CLASSID> pClass = (DHCPCAPI_CLASSID?)(ClassId is null ? null : new DHCPCAPI_CLASSID() { nBytesData = (uint)ClassId.Length, Data = pClassIdData });

		DHCPCAPI_PARAMS_ARRAY sendParams = new();
		DHCPCAPI_PARAMS_ARRAY reqParams = DHCPCAPI_PARAMS_ARRAY.Make(out SafeNativeArray<DHCPAPI_PARAMS>? pparam, optionId);

		uint sz = 0;
		DhcpRequestParams(DHCPCAPI_REQUEST.DHCPCAPI_REQUEST_SYNCHRONOUS, default, adapter, pClass, sendParams, reqParams, IntPtr.Zero, ref sz, null).ThrowUnless(Win32Error.ERROR_MORE_DATA);

		using SafeCoTaskMemHandle buffer = new(sz);
		Guid appId = Guid.NewGuid();
		DhcpRequestParams(DHCPCAPI_REQUEST.DHCPCAPI_REQUEST_SYNCHRONOUS, default, adapter, pClass, sendParams, reqParams, buffer, ref sz, appId.ToString("N")).ThrowIfFailed();
		if (sz == 0)
			return default;

		DHCPAPI_PARAMS p = pparam?[0] ?? default;
		if (typeof(T).IsArray)
		{
			Type elemType = typeof(T).GetElementType()!;
			System.Diagnostics.Debug.WriteLine($"Array: type={elemType.Name}, elemSz={InteropExtensions.SizeOf(elemType)}, memSz={sz}");
			return (T)(object)p.Data.ToArray(elemType, sz / InteropExtensions.SizeOf(elemType), 0, sz)!;
		}
		else
		{
			System.Diagnostics.Debug.WriteLine(typeof(T) == typeof(string) ? $"String: memSz={sz}" : $"Value: type={typeof(T).Name}, sz={InteropExtensions.SizeOf<T>()}, memSz={sz}");
			return p.Data.Convert<T>(p.nBytesData, CharSet.Ansi);
		}
	}

	private static uint ThreadProc(IntPtr hgc)
	{
		var c = (DhcpClient)GCHandle.FromIntPtr(hgc).Target!;
		HEVENT[] hevts;
		RebuildList();
		do
		{
			WAIT_STATUS state = WaitForMultipleObjects(hevts, false, INFINITE);
			if (state == (WAIT_STATUS)c.paramChgEvents.Count)
			{
				break;
			}
			else if (state == (WAIT_STATUS)c.paramChgEvents.Count + 1)
			{
				RebuildList();
			}
			else
			{
				if (hevts.Length > (int)state && c.paramChgEvents.TryGetValue(hevts[(int)state], out var id))
					c.ParamChanged?.Invoke(id);
			}
		} while (true);
		return 0;

		void RebuildList() => hevts = c.paramChgEvents.Keys.Concat(new HEVENT[] { c.closing, c.updateList }).ToArray();
	}

	private IPAddress[] ToIP(uint[]? ips) => ips is null ? new IPAddress[0] : Array.ConvertAll(ips, i => new IPAddress(i));

	internal class DhcpInit
	{
		public readonly uint DhcpVersion, DhcpV6Version;

		public DhcpInit()
		{
			DhcpCApiInitialize(out DhcpVersion).ThrowIfFailed();
			Dhcpv6CApiInitialize(out DhcpV6Version);
		}

		~DhcpInit()
		{
			Dhcpv6CApiCleanup();
			DhcpCApiCleanup();
		}
	}
}