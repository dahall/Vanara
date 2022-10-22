Imports System

Partial Public Module FirewallApi

    ''' <summary>The <c>NET_FW_ACTION</c> enumerated type specifies the action for a rule or default setting.</summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_ACTION_")>
    Public Enum NET_FW_ACTION

        ''' <summary>Block traffic.</summary>
        NET_FW_ACTION_BLOCK

        ''' <summary>Allow traffic.</summary>
        NET_FW_ACTION_ALLOW

        ''' <summary>Maximum traffic.</summary>
        NET_FW_ACTION_MAX

    End Enum

    ''' <summary>
    ''' The <c>NET_FW_AUTHENTICATE_TYPE</c> enumerated type specifies the type of authentication which must occur in order for traffic to be allowed..
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_AUTHENTICATE_TYPE_")>
    Public Enum NET_FW_AUTHENTICATE_TYPE

        ''' <summary>No security check is performed.</summary>
        NET_FW_AUTHENTICATE_NONE

        ''' <summary>
        ''' The traffic is allowed if it is IPsec-protected with authentication and no encapsulation protection. This means that the peer is
        ''' authenticated, but there is no integrity protection on the data.
        ''' </summary>
        NET_FW_AUTHENTICATE_NO_ENCAPSULATION

        ''' <summary>The traffic is allowed if it is IPsec-protected with authentication and integrity protection.</summary>
        NET_FW_AUTHENTICATE_WITH_INTEGRITY

        ''' <summary>
        ''' The traffic is allowed if its is IPsec-protected with authentication and integrity protection. In addition, negotiation of
        ''' encryption protections on subsequent packets is requested.
        ''' </summary>
        NET_FW_AUTHENTICATE_AND_NEGOTIATE_ENCRYPTION

        ''' <summary>
        ''' The traffic is allowed if it is IPsec-protected with authentication, integrity and encryption protection since the very first packet.
        ''' </summary>
        NET_FW_AUTHENTICATE_AND_ENCRYPT

    End Enum

    ''' <summary>
    ''' The <c>NET_FW_EDGE_TRAVERSAL_TYPE</c> enumerated type specifies the conditions under which edge traversal traffic is allowed.
    ''' </summary>
    ''' <remarks>
    ''' In order for Windows Firewall to dynamically allow edge traversal traffic, the application must use the IPV6_PROTECTION_LEVEL socket
    ''' option on the listening socket and set it to <c>PROTECTION_LEVEL_UNRESTRICTED</c> only in the cases where edge traversal traffic
    ''' should be allowed. The Windows Firewall rule added for the application must then set its edge traversal option to
    ''' <c>NET_FW_EDGE_TRAVERSAL_TYPE_DEFER_TO_APP</c> or <c>NET_FW_EDGE_TRAVERSAL_TYPE_DEFER_TO_USER</c>.
    ''' </remarks>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_EDGE_TRAVERSAL_TYPE_")>
    Public Enum NET_FW_EDGE_TRAVERSAL_TYPE

        ''' <summary>
        ''' Edge traversal traffic is always blocked.This is the same as setting the EdgeTraversal property using INetFwRule to VARIANT_FALSE.
        ''' </summary>
        NET_FW_EDGE_TRAVERSAL_TYPE_DENY

        ''' <summary>
        ''' Edge traversal traffic is always allowed.This is the same as setting the EdgeTraversal property using INetFwRule to VARIANT_TRUE.
        ''' </summary>
        NET_FW_EDGE_TRAVERSAL_TYPE_ALLOW

        ''' <summary>
        ''' Edge traversal traffic is allowed when the application sets the IPV6_PROTECTION_LEVEL socket option to
        ''' PROTECTION_LEVEL_UNRESTRICTED. Otherwise, it is blocked.
        ''' </summary>
        NET_FW_EDGE_TRAVERSAL_TYPE_DEFER_TO_APP

        ''' <summary>
        ''' The user is prompted whether to allow edge traversal traffic when the application sets the IPV6_PROTECTION_LEVEL socket option
        ''' to PROTECTION_LEVEL_UNRESTRICTED. If the user chooses to allow edge traversal traffic, the rule is modified to defer to the
        ''' application's settings.If the application has not set the IPV6_PROTECTION_LEVEL socket option to PROTECTION_LEVEL_UNRESTRICTED,
        ''' edge traversal traffic is blocked.In order to use this option, the firewall rule must have both the application path and
        ''' protocol scopes specified. This option cannot be used if port(s) are defined.
        ''' </summary>
        NET_FW_EDGE_TRAVERSAL_TYPE_DEFER_TO_USER

    End Enum

    ''' <summary>
    ''' <para>The <c>NET_FW_IP_PROTOCOL</c> enumeration type specifies the Internet protocol.</para>
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_IP_PROTOCOL_")>
    Public Enum NET_FW_IP_PROTOCOL

        ''' <summary/>
        NET_FW_IP_PROTOCOL_ANY = &H100

        ''' <summary>Transmission Control Protocol.</summary>
        NET_FW_IP_PROTOCOL_TCP = 6

        ''' <summary>User Datagram Protocol.</summary>
        NET_FW_IP_PROTOCOL_UDP = &H11

    End Enum

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API is available for use in the operating systems specified in the Requirements section. It may be altered or
    ''' unavailable in subsequent versions. For Windows Vista and later, use of the Windows Firewall with Advanced Security API is recommended.]
    ''' </para>
    ''' <para>The <c>NET_FW_IP_VERSION</c> enumerated type specifies the IP version for a port.</para>
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_IP_VERSION_")>
    Public Enum NET_FW_IP_VERSION

        ''' <summary>The port supports IPv4.</summary>
        NET_FW_IP_VERSION_V4

        ''' <summary>The port supports IPv6.</summary>
        NET_FW_IP_VERSION_V6

        ''' <summary>The port supports either version of IP.</summary>
        NET_FW_IP_VERSION_ANY

        ''' <summary>This value is used for boundary checking only and is not valid for application programming.</summary>
        NET_FW_IP_VERSION_MAX

    End Enum

    ''' <summary>The NET_FW_MODIFY_STATE enumerated type specifies the effect of modifications to the current policy.</summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_MODIFY_STATE_")>
    Public Enum NET_FW_MODIFY_STATE

        ''' <summary>Changing or adding a firewall rule or firewall group to the current profile will take effect.</summary>
        NET_FW_MODIFY_STATE_OK

        ''' <summary>
        ''' Changing or adding a firewall rule or firewall group to the current profile will not take effect because the profile is
        ''' controlled by the group policy.
        ''' </summary>
        NET_FW_MODIFY_STATE_GP_OVERRIDE

        ''' <summary>
        ''' Changing or adding a firewall rule or firewall group to the current profile will not take effect because unsolicited inbound
        ''' traffic is not allowed.
        ''' </summary>
        NET_FW_MODIFY_STATE_INBOUND_BLOCKED

    End Enum

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API is available for use in the operating systems specified in the Requirements section. It may be altered or
    ''' unavailable in subsequent versions. For Windows Vista and later, use of the Windows Firewall with Advanced Security API is recommended.]
    ''' </para>
    ''' <para>The <c>NET_FW_POLICY_TYPE</c> enumerated type specifies the type of policy.</para>
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_POLICY_TYPE_")>
    Public Enum NET_FW_POLICY_TYPE

        ''' <summary>Policy type is group.</summary>
        NET_FW_POLICY_GROUP

        ''' <summary>Policy type is local.</summary>
        NET_FW_POLICY_LOCAL

        ''' <summary>Policy type is effective.</summary>
        NET_FW_POLICY_EFFECTIVE

        ''' <summary>Used for boundary checking only. Not valid for application programming.</summary>
        NET_FW_POLICY_TYPE_MAX

    End Enum

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API is available for use in the operating systems specified in the Requirements section. It may be altered or
    ''' unavailable in subsequent versions. For Windows Vista and later, use of the Windows Firewall with Advanced Security API is recommended.]
    ''' </para>
    ''' <para>The <c>NET_FW_PROFILE_TYPE</c> enumerated type specifies the type of profile.</para>
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_PROFILE_TYPE_")>
    Public Enum NET_FW_PROFILE_TYPE

        ''' <summary>Profile type is domain.</summary>
        NET_FW_PROFILE_DOMAIN

        ''' <summary>Profile type is standard.</summary>
        NET_FW_PROFILE_STANDARD

        ''' <summary>Profile type is current.</summary>
        NET_FW_PROFILE_CURRENT

        ''' <summary>Used for boundary checking only. Not valid for application programming.</summary>
        NET_FW_PROFILE_TYPE_MAX

    End Enum

    ''' <summary>The <c>NET_FW_PROFILE_TYPE2</c> enumerated type specifies the type of profile.</summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_PROFILE_TYPE2_")>
    <Flags>
    Public Enum NET_FW_PROFILE_TYPE2

        ''' <summary/>
        NET_FW_PROFILE2_ALL = &H7FFFFFFF

        ''' <summary>Profile type is domain.</summary>
        NET_FW_PROFILE2_DOMAIN = 1

        ''' <summary>Profile type is private. This profile type is used for home and other private network types.</summary>
        NET_FW_PROFILE2_PRIVATE = 2

        ''' <summary>Profile type is public. This profile type is used for public Internet access points.</summary>
        NET_FW_PROFILE2_PUBLIC = 4

    End Enum

    ''' <summary>The <c>NET_FW_RULE_CATEGORY</c> enumerated type specifies the firewall rule category.</summary>
    ''' <remarks>For more information about using <c>NET_FW_RULE_CATEGORY</c>, download the Windows Firewall and User Facing Impact document.</remarks>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_RULE_CATEGORY_")>
    Public Enum NET_FW_RULE_CATEGORY

        ''' <summary>Specifies boot time filters.</summary>
        NET_FW_RULE_CATEGORY_BOOT

        ''' <summary>Specifies stealth filters.</summary>
        NET_FW_RULE_CATEGORY_STEALTH

        ''' <summary>Specifies firewall filters.</summary>
        NET_FW_RULE_CATEGORY_FIREWALL

        ''' <summary>Specifies connection security filters.</summary>
        NET_FW_RULE_CATEGORY_CONSEC

        ''' <summary>Maximum value for testing purposes.</summary>
        NET_FW_RULE_CATEGORY_MAX

    End Enum

    ''' <summary>The <c>NET_FW_RULE_DIRECTION</c> enumerated type specifies the direction of traffic to which a rule applies.</summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_RULE_DIRECTION_")>
    Public Enum NET_FW_RULE_DIRECTION

        ''' <summary>The rule applies to inbound traffic.</summary>
        NET_FW_RULE_DIR_IN = 1

        ''' <summary>The rule applies to outbound traffic.</summary>
        NET_FW_RULE_DIR_OUT = 2

        ''' <summary>This value is used for boundary checking only and is not valid for application programming.</summary>
        NET_FW_RULE_DIR_MAX = 3

    End Enum

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API is available for use in the operating systems specified in the Requirements section. It may be altered or
    ''' unavailable in subsequent versions. For Windows Vista and later, use of the Windows Firewall with Advanced Security API is recommended.]
    ''' </para>
    ''' <para>The <c>NET_FW_SCOPE</c> enumerated type specifies the scope of addresses from which a port can listen.</para>
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_SCOPE_")>
    Public Enum NET_FW_SCOPE

        ''' <summary>Scope is all.</summary>
        NET_FW_SCOPE_ALL

        ''' <summary>Scope is local subnet only.</summary>
        NET_FW_SCOPE_LOCAL_SUBNET

        ''' <summary>Scope is custom.</summary>
        NET_FW_SCOPE_CUSTOM

        ''' <summary>Used for boundary checking only. Not valid for application programming.</summary>
        NET_FW_SCOPE_MAX

    End Enum

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API is available for use in the operating systems specified in the Requirements section. It may be altered or
    ''' unavailable in subsequent versions. For Windows Vista and later, use of the Windows Firewall with Advanced Security API is recommended.]
    ''' </para>
    ''' <para>The <c>NET_FW_SERVICE_TYPE</c> enumerated type specifies the type of service.</para>
    ''' </summary>
    <PInvokeData("icftypes.h", MSDNShortId:="NE:icftypes.NET_FW_SERVICE_TYPE_")>
    Public Enum NET_FW_SERVICE_TYPE

        ''' <summary>Service type is File and Print Sharing.</summary>
        NET_FW_SERVICE_FILE_AND_PRINT

        ''' <summary>Service type is UPnP Framework.</summary>
        NET_FW_SERVICE_UPNP

        ''' <summary>Service type is Remote Desktop.</summary>
        NET_FW_SERVICE_REMOTE_DESKTOP

        ''' <summary>Not a valid service type. This is used to indicate that a port is not part of a service.</summary>
        NET_FW_SERVICE_NONE

        ''' <summary>Used for boundary checking only. Not valid for application programming.</summary>
        NET_FW_SERVICE_TYPE_MAX

    End Enum

End Module