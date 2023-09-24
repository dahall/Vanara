using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.PInvoke;
using static Vanara.PInvoke.FirewallApi;

namespace Vanara.Network;

/// <summary>Specifies the conditions under which edge traversal traffic is allowed.</summary>
/// <remarks>
/// In order for Windows Firewall to dynamically allow edge traversal traffic, the application must use the IPV6_PROTECTION_LEVEL socket
/// option on the listening socket and set it to <c>PROTECTION_LEVEL_UNRESTRICTED</c> only in the cases where edge traversal traffic should
/// be allowed. The Windows Firewall rule added for the application must then set its edge traversal option to
/// <c>DeferToApp</c> or <c>DeferToUser</c>.
/// </remarks>
public enum EdgeTraversalType
{
	/// <summary>Edge traversal traffic is always blocked.This is the same as setting the EdgeTraversal property using INetFwRule to VARIANT_FALSE.</summary>
	Deny = NET_FW_EDGE_TRAVERSAL_TYPE.NET_FW_EDGE_TRAVERSAL_TYPE_DENY,

	/// <summary>Edge traversal traffic is always allowed.This is the same as setting the EdgeTraversal property using INetFwRule to VARIANT_TRUE.</summary>
	Allow = NET_FW_EDGE_TRAVERSAL_TYPE.NET_FW_EDGE_TRAVERSAL_TYPE_ALLOW,

	/// <summary>
	/// Edge traversal traffic is allowed when the application sets the IPV6_PROTECTION_LEVEL socket option to PROTECTION_LEVEL_UNRESTRICTED.
	/// Otherwise, it is blocked.
	/// </summary>
	DeferToApp = NET_FW_EDGE_TRAVERSAL_TYPE.NET_FW_EDGE_TRAVERSAL_TYPE_DEFER_TO_APP,

	/// <summary>
	/// The user is prompted whether to allow edge traversal traffic when the application sets the IPV6_PROTECTION_LEVEL socket option to
	/// PROTECTION_LEVEL_UNRESTRICTED. If the user chooses to allow edge traversal traffic, the rule is modified to defer to the
	/// application's settings.If the application has not set the IPV6_PROTECTION_LEVEL socket option to PROTECTION_LEVEL_UNRESTRICTED, edge
	/// traversal traffic is blocked.In order to use this option, the firewall rule must have both the application path and protocol scopes
	/// specified. This option cannot be used if port(s) are defined.
	/// </summary>
	DeferToUser = NET_FW_EDGE_TRAVERSAL_TYPE.NET_FW_EDGE_TRAVERSAL_TYPE_DEFER_TO_USER,
}

/// <summary>Specifies the action for a rule or default setting.</summary>
public enum FirewallAction
{
	/// <summary>Block traffic.</summary>
	Block = NET_FW_ACTION.NET_FW_ACTION_BLOCK,

	/// <summary>Allow traffic.</summary>
	Allow = NET_FW_ACTION.NET_FW_ACTION_ALLOW,

	/// <summary>Maximum traffic.</summary>
	Max = NET_FW_ACTION.NET_FW_ACTION_MAX,
}

/// <summary>Specifies the type of authentication which must occur in order for traffic to be allowed.</summary>
public enum FirewallAuthenticateType
{
	/// <summary>No security check is performed.</summary>
	None = NET_FW_AUTHENTICATE_TYPE.NET_FW_AUTHENTICATE_NONE,

	/// <summary>
	/// The traffic is allowed if it is IPsec-protected with authentication and no encapsulation protection. This means that the peer is
	/// authenticated, but there is no integrity protection on the data.
	/// </summary>
	NoEncapsulation = NET_FW_AUTHENTICATE_TYPE.NET_FW_AUTHENTICATE_NO_ENCAPSULATION,

	/// <summary>The traffic is allowed if it is IPsec-protected with authentication and integrity protection.</summary>
	WithIntegrity = NET_FW_AUTHENTICATE_TYPE.NET_FW_AUTHENTICATE_WITH_INTEGRITY,

	/// <summary>
	/// The traffic is allowed if its is IPsec-protected with authentication and integrity protection. In addition, negotiation of encryption
	/// protections on subsequent packets is requested.
	/// </summary>
	NegotiateEncryption = NET_FW_AUTHENTICATE_TYPE.NET_FW_AUTHENTICATE_AND_NEGOTIATE_ENCRYPTION,

	/// <summary>
	/// The traffic is allowed if it is IPsec-protected with authentication, integrity and encryption protection since the very first packet.
	/// </summary>
	Encrypt = NET_FW_AUTHENTICATE_TYPE.NET_FW_AUTHENTICATE_AND_ENCRYPT,
}

/// <summary>Specifies the effect of modifications to the current policy.</summary>
public enum FirewallPolicyModifyState
{
	/// <summary>Changing or adding a firewall rule or firewall group to the current profile will take effect.</summary>
	Ok = NET_FW_MODIFY_STATE.NET_FW_MODIFY_STATE_OK,

	/// <summary>
	/// Changing or adding a firewall rule or firewall group to the current profile will not take effect because the profile is
	/// controlled by the group policy.
	/// </summary>
	OverrideGroupPolicy = NET_FW_MODIFY_STATE.NET_FW_MODIFY_STATE_GP_OVERRIDE,

	/// <summary>
	/// Changing or adding a firewall rule or firewall group to the current profile will not take effect because unsolicited inbound
	/// traffic is not allowed.
	/// </summary>
	InboundBlocked = NET_FW_MODIFY_STATE.NET_FW_MODIFY_STATE_INBOUND_BLOCKED,
}

/// <summary>Specifies the type of profile.</summary>
[Flags]
public enum FirewallProfileType
{
	/// <summary/>
	All = NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_ALL,

	/// <summary>Profile type is domain.</summary>
	Domain = NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_DOMAIN,

	/// <summary>Profile type is private. This profile type is used for home and other private network types.</summary>
	Private = NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_PRIVATE,

	/// <summary>Profile type is public. This profile type is used for public Internet access points.</summary>
	Public = NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_PUBLIC,
}

/// <summary>Specifies the direction of traffic to which a rule applies.</summary>
public enum RuleDirection
{
	/// <summary>The rule applies to inbound traffic.</summary>
	In = NET_FW_RULE_DIRECTION.NET_FW_RULE_DIR_IN,

	/// <summary>The rule applies to outbound traffic.</summary>
	Out = NET_FW_RULE_DIRECTION.NET_FW_RULE_DIR_OUT,
}

/// <summary>Specifies the interface types to which a rule applies.</summary>
[Flags]
public enum RuleInterfaceType
{
	/// <summary>All interfaces</summary>
	All = 0,

	/// <summary>Local area network interfaces.</summary>
	Lan = 1,

	/// <summary>Remote access interfaces.</summary>
	RemoteAccess = 2,

	/// <summary>Wireless interfaces.</summary>
	Wireless = 4,
}

/// <summary>Wrapper for Windows Firewall interface methods (i.e. <see cref="INetFwPolicy2"/>).</summary>
public static class WindowsFirewall
{
	private static readonly ComReleaser<INetFwPolicy2> pPol = ComReleaserFactory.Create(new INetFwPolicy2());
	private static FirewallProfile? dom, priv, pub;
	private static FirewallRules? rules, svcRules;

	static WindowsFirewall()
	{
		if (!PInvokeClient.WindowsVista.IsPlatformSupported())
			throw new PlatformNotSupportedException("Windows Firewall requires Windows Vista or later.");
	}

	/// <summary>Gets the firewall profile for the active domain.</summary>
	/// <value>The domain profile.</value>
	public static FirewallProfile DomainProfile => dom ??= new FirewallProfile(pPol.Item, NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_DOMAIN);

	/// <summary>
	/// <para>
	/// The LocalPolicyModifyState attribute determines if adding or setting a rule or group of rules will take effect in the current
	/// firewall profile.
	/// </para>
	/// <para>This property is read-only.</para>
	/// </summary>
	public static FirewallPolicyModifyState LocalPolicyModifyState => (FirewallPolicyModifyState)pPol.Item.LocalPolicyModifyState;

	/// <summary>Gets the firewall profile for the private network. This profile type is used for home and other private network types.</summary>
	/// <value>The private profile.</value>
	public static FirewallProfile PrivateProfile => priv ??= new FirewallProfile(pPol.Item, NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_PRIVATE);

	/// <summary>Gets the firewall profile for the public network. This profile type is used for public Internet access points.</summary>
	/// <value>The public profile.</value>
	public static FirewallProfile PublicProfile => pub ??= new FirewallProfile(pPol.Item, NET_FW_PROFILE_TYPE2.NET_FW_PROFILE2_PUBLIC);

	/// <summary>
	/// <para>Retrieves the collection of firewall rules.</para>
	/// <para>This property is read-only.</para>
	/// </summary>
	public static FirewallRules Rules => rules ??= new FirewallRules(pPol.Item.Rules);

	/// <summary>Retrieves the collection of Windows Service Hardening networking rules.</summary>
	public static FirewallRules ServiceHardeningRules => svcRules ??= new FirewallRules(pPol.Item.ServiceRestriction.Rules);

	/// <summary>
	/// <para>Retrieves the interface used to access the Windows Service Hardening store.</para>
	/// <para>This property is read-only.</para>
	/// </summary>
	public static INetFwServiceRestriction ServiceRestriction => pPol.Item.ServiceRestriction;

	/// <summary>
	/// The <c>get_IsRuleGroupCurrentlyEnabled</c> method determines whether a specified group of firewall rules are enabled or disabled for
	/// the current profile.
	/// </summary>
	/// <param name="group">
	/// A string that was used to group rules together. It can be the group name or an indirect string to the group name in the form of
	/// "@C:\Program Files\Contoso Storefront\StorefrontRes.dll,-1234". Rules belonging to this group would be queried.
	/// </param>
	/// <returns>
	/// <para>
	/// This call returns a boolean enable status which indicates whether the group of rules identified by the group parameter are enabled or
	/// disabled. If this value is set to true ( <c>VARIANT_TRUE</c>), the group of rules is enabled; otherwise, the group is disabled.
	/// </para>
	/// </returns>
	/// <remarks>
	/// When indirect strings in the form of "@C:\Program Files\Contoso Storefront\StorefrontRes.dll,-1234" are passed as parameters to the
	/// Windows Firewall with Advanced Security APIs, they should be specified by a full path. The file should have a secure access that
	/// permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid non-privileged
	/// security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
	/// </remarks>
	public static bool IsRuleGroupEnabled(string group) => pPol.Item.IsRuleGroupCurrentlyEnabled[group];

	/// <summary>Indicates whether service restriction rules are enabled to limit traffic to the resources specified by the firewall rules.</summary>
	/// <param name="serviceName">Name of the service being queried concerning service restriction state.</param>
	/// <param name="appName">Name of the application being queried concerning service restriction state.</param>
	/// <returns>
	/// Indicates whether service restriction rules are in place to restrict the specified service. If <see langword="true"/>, service is
	/// restricted. Otherwise, service is not restricted to the resources specified by firewall rules.
	/// </returns>
	public static bool IsServiceRestricted(string serviceName, string appName) => pPol.Item.ServiceRestriction.ServiceRestricted(serviceName, appName);

	/// <summary>The <c>RestoreLocalFirewallDefaults</c> method restores the local firewall configuration to its default state.</summary>
	public static void RestoreLocalFirewallDefaults() => pPol.Item.RestoreLocalFirewallDefaults();

	/// <summary>The <c>RestrictService</c> method turns service restriction on or off for a given service.</summary>
	/// <param name="serviceName">Name of the service for which service restriction is being turned on or off.</param>
	/// <param name="appName">Name of the application for which service restriction is being turned on or off.</param>
	/// <param name="restrictService">
	/// Indicates whether service restriction is being turned on or off. If this value is <see langword="true"/>, the service will be
	/// restricted when sending or receiving network traffic. The Windows Service Hardening rules collection can contain rules which can
	/// allow this service specific inbound or outbound network access per specific requirements. If <see langword="false"/>, the service is
	/// not restricted by Windows Service Hardening.
	/// </param>
	/// <param name="serviceSidRestricted">
	/// Indicates the type of service SID for the specified service. If this value is <see langword="true"/>, the service SID will be
	/// restricted. Otherwise, it will be unrestricted.
	/// </param>
	/// <remarks>When adding rules, note that there may be a small time lag before the newly-added rule is applied.</remarks>
	public static void RestrictService(string serviceName, string appName, bool restrictService, bool serviceSidRestricted) =>
		pPol.Item.ServiceRestriction.RestrictService(serviceName, appName, restrictService, serviceSidRestricted);
}

/// <summary>Represents a profile of the Windows Firewall.</summary>
public class FirewallProfile
{
	private readonly INetFwPolicy2 iPol;
	private readonly NET_FW_PROFILE_TYPE2 type;

	/// <summary>Initializes a new instance of the <see cref="FirewallProfile"/> class with the specified type.</summary>
	/// <param name="type">The profile type.</param>
	public FirewallProfile(FirewallProfileType type) : this(new(), (NET_FW_PROFILE_TYPE2)type) { }

	internal FirewallProfile(INetFwPolicy2 item, NET_FW_PROFILE_TYPE2 type)
	{
		iPol = item;
		this.type = type;
	}

	private FirewallProfile() => throw new NotSupportedException();

	/// <summary>
	/// <para>Indicates whether the firewall should not allow inbound traffic.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// All interfaces are firewall-enabled. This means that all the exceptions (such as GloballyOpenPorts, Applications, or
	/// Services) which are specified in the profile are ignored and only locally-initiated traffic is allowed.
	/// </para>
	/// </remarks>
	public bool BlockAllInboundTraffic { get => iPol.BlockAllInboundTraffic[type]; set => iPol.BlockAllInboundTraffic[type] = value; }

	/// <summary>
	/// <para>Specifies the default action for inbound traffic. These settings are Block by default.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <value>The default inbound action.</value>
	/// <remarks>
	/// All interfaces are firewall-enabled. This means that all the exceptions (such as GloballyOpenPorts, Applications, or
	/// Services) which are specified in the profile, are ignored And only locally-initiated traffic is allowed.
	/// </remarks>
	public FirewallAction DefaultInboundAction { get => (FirewallAction)iPol.DefaultInboundAction[type]; set => iPol.DefaultInboundAction[type] = (NET_FW_ACTION)value; }

	/// <summary>
	/// <para>Specifies the default action for outbound traffic. These settings are Allow by default.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <value>The default outbound action.</value>
	/// <remarks>
	/// All interfaces are firewall-enabled. This means that all the exceptions (such as GloballyOpenPorts, Applications, or
	/// Services) which are specified in the profile are ignored And only locally-initiated traffic is allowed.
	/// </remarks>
	public FirewallAction DefaultOutboundAction { get => (FirewallAction)iPol.DefaultOutboundAction[type]; set => iPol.DefaultOutboundAction[type] = (NET_FW_ACTION)value; }

	/// <summary>
	/// <para>Indicates whether a firewall is enabled locally (the effective result may differ due to group policy settings).</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public bool Enabled { get => iPol.FirewallEnabled[type]; set => iPol.FirewallEnabled[type] = value; }

	/// <summary>
	/// <para>Specifies a list of interfaces on which firewall settings are excluded.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <value>The excluded interfaces.</value>
	/// <remarks>
	/// <para>
	/// An excluded interface is an interface to which the firewall is not applicable. The firewall is not applicable to any traffic received
	/// from or sent to an excluded interface. An empty list indicates that there are no excluded interfaces.
	/// </para>
	/// </remarks>
	public string[]? ExcludedInterfaces
	{ get => iPol.ExcludedInterfaces[type] is null ? null : Array.ConvertAll((object[])iPol.ExcludedInterfaces[type], o => o.ToString());
		set => iPol.ExcludedInterfaces[type] = value is null || value.Length == 0 ? null : Array.ConvertAll(value, s => (object)s);
	}

	/// <summary>
	/// Indicates whether interactive firewall notifications are disabled.
	/// <para>This property is read/write.</para>
	/// </summary>
	public bool NotificationsDisabled { get => iPol.NotificationsDisabled[type]; set => iPol.NotificationsDisabled[type] = value; }

	/// <summary>
	/// <para>Indicates whether the firewall should not allow unicast responses to multicast And broadcast traffic.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>If a computer sends a broadcast packet, a unicast response is allowed for three seconds. Use this property to change this behavior.</para>
	/// </remarks>
	public bool UnicastResponsesToMulticastBroadcastDisabled { get => iPol.UnicastResponsesToMulticastBroadcastDisabled[type]; set => iPol.UnicastResponsesToMulticastBroadcastDisabled[type] = value; }

	/// <summary>The <c>IsRuleGroupEnabled</c> method determines whether a specified group of firewall rules are enabled or disabled.</summary>
	/// <param name="group">
	/// A string that was used to group rules together. It can be the group name or an indirect string to the group name in the form of
	/// "@yourresourcedll.dll,-23255". Rules belonging to this group would be queried.
	/// </param>
	/// <returns>
	/// This call returns a boolean enable status which indicates whether the group of rules identified by the group parameter are enabled or
	/// disabled. If this value is set to true (VARIANT_TRUE), the group of rules is enabled; otherwise, the group is disabled.
	/// </returns>
	/// <remarks>
	/// When indirect strings in the form of "@yourresourcedll.dll,-23255" are passed as parameters to the Windows Firewall with Advanced
	/// Security APIs, they should either be placed under the System32 Windows directory or specified by a full path. Further the file should
	/// have a secure access that permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To
	/// avoid non-privileged security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
	/// </remarks>
	public bool IsRuleGroupEnabled(string group) => iPol.IsRuleGroupEnabled(type, group);
}

/// <summary>Provides access to the properties of a firewall rule.</summary>
/// <remarks>
/// <para>
/// Each time you change a property of a rule, Windows Firewall commits the rule and verifies it for correctness. As a result, when you edit
/// a rule, you must perform the steps in a specific order. For example, if you add an ICMP rule, you must first set the protocol to ICMP,
/// then add the rule. If these steps are taken in the opposite order, an error occurs and the change is lost.
/// </para>
/// <para>
/// If you are editing a TCP port rule and converting it into an ICMP rule, first delete the port, change protocol from TCP to ICMP, and then
/// add the rule.
/// </para>
/// <para>
/// In order to retrieve and modify existing rules, instances of this interface must be retrieved through INetFwRules. All configuration
/// changes take place immediately.
/// </para>
/// <para>When accessing the properties of a rule, keep in mind that there may be a small time lag before a newly-added rule is applied.</para>
/// <para>Properties are used to create firewall rules. Many of the properties can be used in order to create very specific firewall rules.</para>
/// <list type="table">
/// <listheader>
/// <term>Property</term>
/// <term>Type and format</term>
/// <term>Constraints</term>
/// </listheader>
/// <rule>
/// <term>Name</term>
/// <term>Clear text string.</term>
/// <term>Required. The string must not contain a "|" and it must not be "all".</term>
/// </rule><rule>
/// <term>Description</term>
/// <term>Clear text string.</term>
/// <term>Optional. The string must not contain a "|".</term>
/// </rule><rule>
/// <term>Grouping</term>
/// <term>String in the format "@&lt;dll name&gt;, &lt;resource string identifier&gt;".</term>
/// <term>Required.</term>
/// </rule><rule>
/// <term>Enabled</term>
/// <term>Boolean (VARIANT_BOOLEAN).</term>
/// <term>Optional. Defaults to false (VARIANT_FALSE) if nothing is specified.</term>
/// </rule><rule>
/// <term>ApplicationName</term>
/// <term>Clear text string.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>ServiceName</term>
/// <term>Clear text string.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>LocalPorts</term>
/// <term>Clear text string containing a list of port numbers. "RPC" is an acceptable value.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>RemotePorts</term>
/// <term>Clear text string containing a list of port numbers.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>LocalAddresses</term>
/// <term>Clear text string containing a list of IPv4 and IPv6 addresses separated by commas. Range values and"*"are acceptable in this list.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>RemoteAddresses</term>
/// <term>Clear text string containing a list of IPv4 and IPv6 addresses separated by commas. Range values and"*"are acceptable in this list.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>Protocol</term>
/// <term>Number.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>put_Profiles</term>
/// <term>
/// String value in the format "type, code". Multiple types and codes can be included in the string by separating each pair with a ";".
/// </term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>Interfaces</term>
/// <term>Array of strings containing the friendly names of interfaces.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>InterfaceTypes</term>
/// <term>
/// String value. Multiple interface types can be included in the string by separating each value with a ",". Acceptable values are
/// "RemoteAccess", "Wireless", "Lan", and "All".
/// </term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>Direction</term>
/// <term>Enumeration.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>Action</term>
/// <term>Enumeration.</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>EdgeTraversal</term>
/// <term>Boolean (VARIANT_BOOLEAN).</term>
/// <term>Optional.</term>
/// </rule><rule>
/// <term>Profiles</term>
/// <term>Enumeration.</term>
/// <term>Optional.</term>
/// </rule>
/// </list>
/// <para>For additional information on each property, please see the corresponding topic.</para>
/// </remarks>
/// <seealso cref="INamedEntity"/>
public class FirewallRule : INamedEntity, IEquatable<FirewallRule>
{
	internal readonly INetFwRule iRule;

	/// <summary>Initializes a new instance of the <see cref="FirewallRule"/> class.</summary>
	/// <param name="name">The friendly name for the rule.</param>
	/// <param name="group">The group name for the rule.</param>
	/// <param name="allow">If set to <see langword="true"/>, this is an allow rule; otherwise a blocking rule.</param>
	/// <param name="in">If set to <see langword="true"/>, the direction is in; otherwise it is out.</param>
	/// <param name="description">The optional description.</param>
	public FirewallRule(string name, string? group, bool allow = true, bool @in = true, string? description = null)
	{
		iRule = new INetFwRule();
		Name = name;
		Grouping = group;
		Action = (FirewallAction)(allow ? NET_FW_ACTION.NET_FW_ACTION_ALLOW : NET_FW_ACTION.NET_FW_ACTION_BLOCK);
		Direction = (RuleDirection)(@in ? NET_FW_RULE_DIRECTION.NET_FW_RULE_DIR_IN : NET_FW_RULE_DIRECTION.NET_FW_RULE_DIR_OUT);
		Description = description;
	}

	internal FirewallRule(INetFwRule netFwRule) => iRule = netFwRule;

	/// <summary>
	/// <para>Specifies the action for a rule or default setting.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	public FirewallAction Action { get => (FirewallAction)iRule.Action; set => iRule.Action = (NET_FW_ACTION)value; }

	/// <summary>
	/// <para>Specifies the friendly name of the application to which this rule applies.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	[DefaultValue(null)]
	public string? ApplicationName { get => iRule.ApplicationName; set => iRule.ApplicationName = value; }

	/// <summary>
	/// <para>Specifies the description of this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional. The string must not contain the "|" character.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	[DefaultValue(null)]
	public string? Description { get => iRule.Description; set => iRule.Description = value; }

	/// <summary>
	/// <para>Specifies the direction of traffic for which the rule applies.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional. If this property is not specified, the default value is <c>in</c>.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	[DefaultValue(NET_FW_RULE_DIRECTION.NET_FW_RULE_DIR_IN)]
	public RuleDirection Direction { get => (RuleDirection)iRule.Direction; set => iRule.Direction = (NET_FW_RULE_DIRECTION)value; }

	/// <summary>
	/// <para>Indicates whether edge traversal is enabled or disabled for this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The EdgeTraversal property indicates that specific inbound traffic is allowed to tunnel through NATs and other edge devices using the
	/// Teredo tunneling technology. In order for this setting to work correctly, the application or service with the inbound firewall rule
	/// needs to support IPv6. The primary application of this setting allows listeners on the host to be globally addressable through a
	/// Teredo IPv6 address.
	/// </para>
	/// <para>New rules have the EdgeTraversal property disabled by default.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	[DefaultValue(false)]
	public bool EdgeTraversal { get => iRule.EdgeTraversal; set => iRule.EdgeTraversal = value; }

	/// <summary>
	/// <para>This property can be used to access the edge properties of a firewall rule defined by NET_FW_EDGE_TRAVERSAL_TYPE.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public EdgeTraversalType EdgeTraversalOptions { get => (EdgeTraversalType)iRule2.EdgeTraversalOptions; set => iRule2.EdgeTraversalOptions = (NET_FW_EDGE_TRAVERSAL_TYPE)value; }

	/// <summary>
	/// <para>Enables or disables a rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional. A new rule is disabled by default.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	public bool Enabled { get => iRule.Enabled; set => iRule.Enabled = value; }

	/// <summary>
	/// <para>Specifies the group to which an individual rule belongs.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// <para>
	/// Using the Grouping property is highly recommended, as it groups multiple rules into a single line in the Windows Firewall control
	/// panel. This allows the user to enable or disable multiple rules with a single click. The Grouping property can also be specified
	/// using indirect strings. In this case, a group description can also be specified that will appear in the rule group properties in the
	/// Windows Firewall control panel. For example, if the group string is specified by an indirect string at index 1005
	/// ("@yourresources.dll,-1005"), the group description can be specified at a resource string higher by 10000 "@youresources.dll,-11005."
	/// </para>
	/// <para>
	/// When indirect strings in the form of "h" are passed as parameters to the Windows Firewall with Advanced Security APIs, they should
	/// either be placed under the System32 Windows directory or specified by a full path. Further, the file should have a secure access that
	/// permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid non-privileged
	/// security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
	/// </para>
	/// </remarks>
	public Windows.Shell.IndirectString? Grouping { get => iRule.Grouping is null ? null : new(iRule.Grouping); set => iRule.Grouping = value?.RawValue; }

	// <summary> <para>Specifies the list of ICMP types and codes for this rule.</para> <para>This property is read/write.</para> </summary>
	// <remarks> <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	// <para> The icmpTypesAndCodes parameter is a list of ICMP types and codes separated by semicolon. "*" indicates all ICMP types and
	// codes. </para> </remarks>
	public (byte icmpType, ushort icmpCode)[]? IcmpTypesAndCodes
	{
		get
		{
			if (iRule.IcmpTypesAndCodes == "*")
			{
				return null;
			}

			string[]? s = iRule.IcmpTypesAndCodes.FromDelim(';');
			return s is null ? null : Array.ConvertAll(s, StrToPair);

			static (byte icmpType, ushort icmpCode) StrToPair(string input)
			{
				System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(input, @"(\d{1,3})\:(\d{1,3}|\*)");
				return !m.Success
					? throw new InvalidCastException($"Unable to parse ICMP type and code: {input}")
					: ((byte icmpType, ushort icmpCode))(byte.Parse(m.Groups[1].Value), m.Groups[2].Value == "*" ? (ushort)0x100 : ushort.Parse(m.Groups[2].Value));
			}
		}

		set => iRule.IcmpTypesAndCodes = value is null ? null : Array.ConvertAll(value, p => $"{p.icmpType}:{p.icmpCode}").ToDelim(';');
	}

	/// <summary>
	/// <para>Specifies the list of interfaces for which the rule applies.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional. The interfaces in the list are represented by their friendly name.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	public string[]? InterfaceNames
	{ get => iRule.Interfaces is null ? null : Array.ConvertAll((object[])iRule.Interfaces, o => o.ToString());
		set => iRule.Interfaces = value is null || value.Length == 0 ? null : Array.ConvertAll(value, s => (object)s);
	}

	/// <summary>
	/// <para>Specifies the list of interfaces for which the rule applies.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional. The interfaces in the list are represented by their friendly name.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	public System.Net.NetworkInformation.NetworkInterface[]? Interfaces
	{
		get
		{
			if (iRule.Interfaces is null)
			{
				return null;
			}

			string[] ifList = iRule.GetInterfaces();
			return System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Where(i => ifList.Contains(i.Name)).ToArray();
		}

		set => iRule.Interfaces = value is null || value.Length == 0 ? null : Array.ConvertAll(value, i => (object)i.Name);
	}

	/// <summary>
	/// <para>Specifies the list of interface types for which the rule applies.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	[DefaultValue(0)]
	public RuleInterfaceType InterfaceTypes
	{
		get => (RuleInterfaceType)Enum.Parse(typeof(RuleInterfaceType), iRule.InterfaceTypes ?? "All");
		set => iRule.InterfaceTypes = value.ToString().Replace(" ", "");
	}

	/// <summary>
	/// <para>Specifies the list of local addresses for this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// <para>
	/// The localAddrs parameter consists of one or more comma-delimited tokens specifying the local addresses from which the application can
	/// listen for traffic. "*" is the default value. Valid tokens include:
	/// </para>
	/// <list type="bullet"><rule>
	/// <term>"*" indicates any local address. If present, this must be the only token included.</term>
	/// </rule><rule>
	/// <term>"Defaultgateway"</term>
	/// </rule><rule>
	/// <term>"DHCP"</term>
	/// </rule><rule>
	/// <term>"WINS"</term>
	/// </rule><rule>
	/// <term>"LocalSubnet" indicates any local address on the local subnet. This token is not case-sensitive.</term>
	/// </rule><rule>
	/// <term>
	/// A subnet can be specified using either the subnet mask or network prefix notation. If neither a subnet mask not a network prefix is
	/// specified, the subnet mask defaults to 255.255.255.255.
	/// </term>
	/// </rule><rule>
	/// <term>A valid IPv6 address.</term>
	/// </rule><rule>
	/// <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
	/// </rule><rule>
	/// <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
	/// </rule>
	/// </list>
	/// </remarks>
	public string[]? LocalAddresses { get => iRule.LocalAddresses.FromDelim(','); set => iRule.LocalAddresses = value.ToDelim(','); }

	/// <summary>
	/// <para>
	/// Specifies the package identifier or the app container identifier of a process, whether from a Windows Store app or a desktop app.
	/// </para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public string LocalAppPackageId { get => iRule3.LocalAppPackageId; set => iRule3.LocalAppPackageId = value; }

	/// <summary>
	/// <para>Specifies the list of local ports for this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// <para>The Protocol property must be set before the <c>LocalPorts</c> property or an error will be returned.</para>
	/// </remarks>
	public string[]? LocalPorts { get => iRule.LocalPorts.FromDelim(','); set => iRule.LocalPorts = value.ToDelim(','); }

	/// <summary>
	/// <para>Specifies a list of authorized local users for an app container.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public RawSecurityDescriptor? LocalUserAuthorizedList
	{
		get => iRule3.LocalUserAuthorizedList.ToSD();
		set => iRule3.LocalUserAuthorizedList = value.FromSD();
	}

	/// <summary>
	/// <para>Specifies the user security identifier (SID) of the user who is the owner of the rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// If this rule does not specify <c>localUserConditions</c>, all the traffic that this rule matches must be destined to or originated
	/// from this user.
	/// </remarks>
	public SecurityIdentifier? LocalUserOwner
	{
		get => iRule3.LocalUserOwner is null ? null : new(iRule3.LocalUserOwner);
		set => iRule3.LocalUserOwner = value?.Value;
	}

	/// <summary>
	/// <para>Specifies the friendly name of this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is required. The string must not contain the "|" character.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	public string Name { get => iRule.Name; set => iRule.Name = value; }

	/// <summary>
	/// <para>Specifies the profiles to which the rule belongs.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	[DefaultValue(FirewallProfileType.All)]
	public FirewallProfileType Profiles { get => (FirewallProfileType)iRule.Profiles; set => iRule.Profiles = (NET_FW_PROFILE_TYPE2)value; }

	/// <summary>
	/// <para>Specifies the IP protocol of this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// <para>The <c>Protocol</c> property must be set before the LocalPorts or RemotePorts properties or an error will be returned.</para>
	/// <para>A list of protocol numbers is available at the IANA website.</para>
	/// </remarks>
	[DefaultValue(256)]
	public int Protocol { get => iRule.Protocol; set => iRule.Protocol = value; }

	/// <summary>
	/// <para>Specifies the list of remote addresses for this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// <para>
	/// The remoteAddrs parameter consists of one or more comma-delimited tokens specifying the remote addresses from which the application
	/// can listen for traffic. The default value is "*". Valid tokens include:
	/// </para>
	/// <list type="bullet"><rule>
	/// <term>"*" indicates any remote address. If present, this must be the only token included.</term>
	/// </rule><rule>
	/// <term>"Defaultgateway"</term>
	/// </rule><rule>
	/// <term>"DHCP"</term>
	/// </rule><rule>
	/// <term>"DNS"</term>
	/// </rule><rule>
	/// <term>"WINS"</term>
	/// </rule><rule>
	/// <term>"LocalSubnet" indicates any local address on the local subnet. This token is not case-sensitive.</term>
	/// </rule><rule>
	/// <term>
	/// A subnet can be specified using either the subnet mask or network prefix notation. If neither a subnet mask not a network prefix is
	/// specified, the subnet mask defaults to 255.255.255.255.
	/// </term>
	/// </rule><rule>
	/// <term>A valid IPv6 address.</term>
	/// </rule><rule>
	/// <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
	/// </rule><rule>
	/// <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
	/// </rule>
	/// </list>
	/// </remarks>
	public string[]? RemoteAddresses { get => iRule.RemoteAddresses.FromDelim(','); set => iRule.RemoteAddresses = value.ToDelim(','); }

	/// <summary>
	/// <para>Specifies a list of remote computers which are authorized to access an app container.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public RawSecurityDescriptor? RemoteMachineAuthorizedList { get => iRule3.RemoteMachineAuthorizedList.ToSD(); set => iRule3.RemoteMachineAuthorizedList = value.FromSD(); }

	/// <summary>
	/// <para>Specifies the list of remote ports for this rule.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>This property is optional.</para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// <para>The Protocol property must be set before the <c>RemotePorts</c> property or an error will be returned.</para>
	/// </remarks>
	public string[]? RemotePorts { get => iRule.RemotePorts.FromDelim(','); set => iRule.RemotePorts = value.ToDelim(','); }

	/// <summary>
	/// <para>Specifies a list of remote users who are authorized to access an app container.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public RawSecurityDescriptor? RemoteUserAuthorizedList { get => iRule3.RemoteUserAuthorizedList.ToSD(); set => iRule3.RemoteUserAuthorizedList = value.FromSD(); }

	/// <summary>
	/// <para>
	/// Specifies which firewall verifications of security levels provided by IPsec must be guaranteed to allow the collection. The allowed
	/// values must correspond to those of the NET_FW_AUTHENTICATE_TYPE enumeration.
	/// </para>
	/// <para>This property is read/write.</para>
	/// </summary>
	public FirewallAuthenticateType SecureFlags { get => (FirewallAuthenticateType)iRule3.SecureFlags; set => iRule3.SecureFlags = (NET_FW_AUTHENTICATE_TYPE)value; }

	/// <summary>
	/// <para>Specifies the service name property of the application.</para>
	/// <para>This property is read/write.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This property is optional. A serviceName value of "*" indicates that a service, not an application, must be sending or receiving traffic.
	/// </para>
	/// <para>Also see the restrictions on changing properties described in the Remarks section of the <see cref="FirewallRule"/> class.</para>
	/// </remarks>
	public string ServiceName { get => iRule.serviceName; set => iRule.serviceName = value; }

	private INetFwRule2 iRule2 => iRule as INetFwRule2 ?? throw new NotSupportedException();
	private INetFwRule3 iRule3 => iRule as INetFwRule3 ?? throw new NotSupportedException();

	/// <inheritdoc/>
	public bool Equals(FirewallRule? other) => Equals(other?.Name, Name) &&
		Equals(other?.Profiles, Profiles) &&
		Equals(other?.Direction, Direction) &&
		Equals(other?.Enabled, Enabled) &&
		Equals(other?.Action, Action) &&
		Equals(other?.ApplicationName, ApplicationName);
}

/// <summary>Represents the rules for the Windows Firewall.</summary>
/// <seealso cref="IReadOnlyList{T}"/>
/// <seealso cref="ICollection{T}"/>
public class FirewallRules : IReadOnlyList<FirewallRule>, ICollection<FirewallRule>
{
	private readonly INetFwRules iRules;

	internal FirewallRules(INetFwRules rules) => iRules = rules;

	private FirewallRules() => throw new NotSupportedException();

	/// <inheritdoc/>
	public int Count => iRules.Count;

	/// <inheritdoc/>
	bool ICollection<FirewallRule>.IsReadOnly => false;

	/// <summary>Gets the <see cref="FirewallRule"/> with the specified name.</summary>
	/// <value>The <see cref="FirewallRule"/>.</value>
	/// <param name="name">The name of the rule to retrieve.</param>
	/// <returns>The element with the specified name.</returns>
	public FirewallRule this[string name] => new(iRules.Item(name));

	/// <inheritdoc/>
	public FirewallRule this[int index] => this.ToArray()[index];

	/// <summary>The <c>Add</c> method adds a new rule to the collection.</summary>
	/// <param name="rule">Rule to be added to the collection.</param>
	/// <remarks>
	/// <para>If a rule with the same rule identifier as the one being submitted already exists, the existing rule is overwritten.</para>
	/// <para>Adding a firewall rule with a LocalAppPackageId specified can lead to unexpected behavior and is not supported.</para>
	/// </remarks>
	public void Add(FirewallRule rule) => iRules.Add(rule.iRule);

	/// <inheritdoc/>
	public void Clear()
	{
		IEnumerator enumerator = iRules.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current is INetFwRule rule)
				iRules.Remove(rule.Name);
		}
	}

	/// <inheritdoc/>
	public bool Contains(FirewallRule item) => ((IEnumerable<FirewallRule>)this).Contains(item);

	/// <inheritdoc/>
	public void CopyTo(FirewallRule[] array, int arrayIndex) => Array.Copy(this.ToArray(), 0, array, arrayIndex, Count);

	/// <inheritdoc/>
	public IEnumerator<FirewallRule> GetEnumerator()
	{
		IEnumerator enumerator = iRules.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current is INetFwRule rule)
				yield return new FirewallRule(rule);
		}
	}

	/// <inheritdoc/>
	public int IndexOf(FirewallRule item) => this.Select((value, index) => new { value, index })
						.Where(pair => Equals(pair.value, item))
						.Select(pair => pair.index + 1)
						.FirstOrDefault() - 1;

	/// <inheritdoc/>
	public bool Remove(FirewallRule item) => Remove(item.Name);

	/// <summary>The <c>Remove</c> method removes a rule from the collection.</summary>
	/// <param name="name">Name of the rule to remove from the collection.</param>
	/// <remarks>If a rule specified by the name parameter does not exist in the collection, the <c>Remove</c> method has no effect.</remarks>
	public bool Remove(string name)
	{
		try { iRules.Remove(name); return true; } catch { return false; }
	}

	/// <inheritdoc/>
	public void RemoveAt(int index) => Remove(this[index].Name);

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal static class FwExt
{
	public static string[]? FromDelim(this string? list, char sep) => string.IsNullOrEmpty(list) ? null : list?.Split(new char[] { sep }, StringSplitOptions.RemoveEmptyEntries);

	public static string? FromSD(this RawSecurityDescriptor? sd) => sd?.GetSddlForm(AccessControlSections.Owner | AccessControlSections.Access);

	public static string? ToDelim(this string[]? list, char sep) => list is null || list.Length == 0 ? null : string.Join(sep.ToString(), list);

	public static RawSecurityDescriptor? ToSD(this string? sddl) => sddl is null ? null : new(sddl);
}