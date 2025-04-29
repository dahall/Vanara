Imports System
Imports System.Collections
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.CustomMarshalers

#Disable Warning BC40000 ' Type or member is obsolete

Partial Public Module FirewallApi


    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>
    ''' The <c>INetFwAuthorizedApplication</c> interface provides access to the properties of an application that has been authorized have
    ''' openings in the firewall.
    ''' </para>
    ''' </summary>
    ''' <remarks>
    ''' <para>When creating New applications, this interface Is supported by the HNetCfg.FwAuthorizedApplication COM object.</para>
    ''' <para>
    ''' For reading Or modifying existing applications, instances of this interface are retrieved through the INetFwAuthorizedApplications collection.
    ''' </para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <ComImport, Guid("B5E64FFA-C2C5-444E-A301-FB5E00018050"), CoClass(GetType(NetFwAuthorizedApplication))>
    Public Interface INetFwAuthorizedApplication

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the friendly name of this application.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>This property Is required.</remarks>
        <DispId(1)>
        Property Name As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the process image file name for this application.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The image file name must be a fully qualified path And reference an existing application. The name may contain environment variables.
        ''' </para>
        ''' <para>This property Is required.</para>
        ''' <para>A demonstration of this property can be found in the VBScript code example Adding an Application.</para>
        ''' </remarks>
        <DispId(2)>
        Property ProcessImageFileName As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the IP version setting for this application.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>Only NET_FW_IP_VERSION_ANY Is supported And this Is the default for New applications.</remarks>
        <DispId(3)>
        Property IpVersion As NET_FW_IP_VERSION

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Controls the network scope from which the port can listen.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>When setting the Scope property, only <c>NET_FW_SCOPE_ALL</c> And <c>NET_FW_SCOPE_LOCAL_SUBNET</c> are valid.</para>
        ''' <para>The default value Is <c>NET_FW_SCOPE_ALL</c> for New ports.</para>
        ''' <para>To create a custom scope, use the RemoteAddresses property.</para>
        ''' </remarks>
        <DispId(4)>
        Property Scope As NET_FW_SCOPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies a set of the remote addresses from which the application can listen for traffic.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*".
        ''' </para>
        ''' <para>Valid tokens:</para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*": any remote address; If present, it must be the only token.</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet": Not case-sensitive; specifying more than once has no effect.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' subnet: may be specified Using either subnet mask Or network prefix notation. If neither a subnet mask nor a network prefix Is
        ''' specified, the subnet mask defaults to 255.255.255.255. Examples of valid subnets: 10.0.0.2/255.0.0.0 10.0.0.2/8 10.0.0.2
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv4 address range In the format "start address - end address."</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv6 address range In the format "start address - end address."</term>
        ''' </item>
        ''' </list>
        ''' <para>For a predefined address range, use the Scope property.</para>
        ''' </remarks>
        <DispId(5)>
        Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether the settings for this application are currently enabled.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' This property can be set to false ( <c>VARIANT_FALSE</c>) to allow application settings to be stored in the
        ''' INetFWAuthorizedApplications collection without actually authorizing the application.
        ''' </para>
        ''' <para>The default value Is true ( <c>VARIANT_TRUE</c>) for New applications.</para>
        ''' </remarks>
        <DispId(6)>
        Property Enabled As Boolean

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>
    ''' The <c>INetFwAuthorizedApplications</c> interface provides access to a collection of applications authorized open ports in the firewall.
    ''' </para>
    ''' </summary>
    ''' <remarks>
    ''' <para>An instance of this interface Is retrieved through the AuthorizedApplications property of the INetFwProfile interface.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <ComImport, Guid("644EFD52-CCF9-486C-97A2-39F352570B30")>
    Public Interface INetFwAuthorizedApplications
        Inherits IEnumerable

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the number of items in the collection.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <returns>None</returns>
        <DispId(1)>
        ReadOnly Property Count As Integer

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>The <c>Add</c> method adds a New application to the collection.</para>
        ''' </summary>
        ''' <param name="app">TBD</param>
        ''' <remarks>If an application with the same path already exists, the existing settings are overwritten.</remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Sub Add(<[In], MarshalAs(UnmanagedType.Interface)> ByVal app As INetFwAuthorizedApplication)

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>The <c>Remove</c> method removes an application from the collection.</para>
        ''' </summary>
        ''' <param name="imageFileName">Application name to be removed.</param>
        ''' <remarks>
        ''' <para>The <c>imageFileName</c> parameter must be a fully qualified path And may contain environment variables.</para>
        ''' <para>If the application does Not exist in the collection, the Remove method has no effect.</para>
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(3)>
        Sub Remove(<[In], MarshalAs(UnmanagedType.BStr)> ByVal imageFileName As String)

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>The <c>Item</c> method returns the specified application if it Is in the collection.</para>
        ''' </summary>
        ''' <param name="imageFileName">Application to retrieve.</param>
        ''' <returns>TBD</returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(4)>
        Function Item(<[In], MarshalAs(UnmanagedType.BStr)> ByVal imageFileName As String) As <MarshalAs(UnmanagedType.Interface)> INetFwAuthorizedApplication

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Returns an object supporting <c>IEnumVARIANT</c> that can be used to iterate through all the applications in the collection.</para>
        ''' <para>
        ''' Iteration through a collection Is done using the <c>for each</c> construct in VBScript. See Iterating a Collection for an example.
        ''' </para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <returns/>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(-4)>
        Overloads Function GetEnumerator() As <MarshalAs(UnmanagedType.CustomMarshaler, MarshalType:="", MarshalTypeRef:=GetType(EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> IEnumerator

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The <c>INetFwIcmpSettings</c> interface provides access to the settings controlling ICMP packets.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>Instances of this interface are retrieved through the IcmpSettings property of the INetFwProfile interface.</para>
    ''' <para>
    ''' Because the methods And properties of this interface enable all rules belonging to a given ICMP type, enabling a rule may enable
    ''' rules from other groups as well.
    ''' </para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwIcmpSettings")>
    <ComImport, Guid("A6207B2E-7CDD-426A-951E-5E1CBC5AFEAD")>
    Public Interface INetFwIcmpSettings

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether this Is allowed.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>This setting Is common to IPv4 And IPv6.</remarks>
        <DispId(1)>
        Property AllowOutboundDestinationUnreachable As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether redirect Is allowed.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>This setting Is common to IPv4 And IPv6.</remarks>
        <DispId(2)>
        Property AllowRedirect As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow inbound echo requests.</summary>
        <DispId(3)>
        Property AllowInboundEchoRequest As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow �outbound time exceeded� messages.</summary>
        <DispId(4)>
        Property AllowOutboundTimeExceeded As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow �outbound parameter problem� messages.</summary>
        <DispId(5)>
        Property AllowOutboundParameterProblem As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow �outbound source quench� messages.</summary>
        <DispId(6)>
        Property AllowOutboundSourceQuench As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow inbound router requests.</summary>
        <DispId(7)>
        Property AllowInboundRouterRequest As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow inbound timestamp requests.</summary>
        <DispId(8)>
        Property AllowInboundTimestampRequest As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow inbound mask requests.</summary>
        <DispId(9)>
        Property AllowInboundMaskRequest As Boolean

        ''' <summary>Gets Or sets a flag indicating whether to allow �outbound packet too big� messages.</summary>
        <DispId(10)>
        Property AllowOutboundPacketTooBig As Boolean

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The INetFwMgr interface provides access to the firewall settings for a computer.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>
    ''' <c>Windows Vista:</c> Windows Vista users must use applications developed in Windows Vista for all methods And properties of this interface.
    ''' </para>
    ''' <para>This interface Is supported by the HNetCfg.FwMgr COM object.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwMgr"), CoClass(GetType(NetFwMgr))>
    <ComImport, Guid("F7898AF5-CAC4-4632-A2EC-DA06E5111AF2")>
    Public Interface INetFwMgr

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the local firewall policy.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property LocalPolicy As <MarshalAs(UnmanagedType.Interface)> INetFwPolicy

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the type of firewall profile currently in effect.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <remarks>The SharedAccess service must be running.</remarks>
        <DispId(2)>
        ReadOnly Property CurrentProfileType As NET_FW_PROFILE_TYPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Restores the local configuration to its default, installed state.</para>
        ''' </summary>
        ''' <remarks>
        ''' This method deletes all user And application-added applications And ports that return the system to its installed state. This
        ''' includes restoring the defaults for Internet Connection Sharing.
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(3)>
        Sub RestoreDefaults()

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Determines whether an application can listen for inbound traffic on the specified port.</para>
        ''' </summary>
        ''' <param name="imageFileName">
        ''' The image file name of the process listening on the network. It must be a fully qualified path, but may contain environment
        ''' variables. If imageFileName Is <c>NULL</c>, the function determines whether the port Is allowed for all applications.
        ''' </param>
        ''' <param name="ipVersion">IP version of the traffic. If localAddress Is non- <c>NULL</c>, this must Not be <c>NET_FW_IP_VERSION_ANY</c>.</param>
        ''' <param name="portNumber">Local IP port number of the traffic.</param>
        ''' <param name="localAddress">
        ''' Either a dotted-decimal IPv4 address Or an IPv6 hex address specifying the local address of the traffic. Typically, this Is the
        ''' address passed to bind. If localAddress Is <c>NULL</c>, the function determines whether the port Is allowed for all interfaces.
        ''' </param>
        ''' <param name="ipProtocol">IP protocol of the traffic, either <c>NET_FW_IP_PROTOCOL_TCP</c> Or <c>NET_FW_IP_PROTOCOL_UDP</c>.</param>
        ''' <param name="allowed">
        ''' Indicates by a value of VARIANT_TRUE Or VARIANT_FALSE whether the port Is allowed for at least some local interfaces And remote addresses.
        ''' </param>
        ''' <param name="restricted">
        ''' Indicates by a value of VARIANT_TRUE Or VARIANT_FALSE whether some local interfaces Or remote addresses are blocked for this
        ''' port. For example, if the port Is restricted to the local subnet only.
        ''' </param>
        ''' <remarks>
        ''' <para>The INetFwPolicy2:IsRuleGroupEnabled method Is generally recommended In place Of this method.</para>
        ''' <para>The <c>IsPortAllowed</c> method checks whether traffic will be allowed with the current firewall configuration for:</para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>A specific application.</term>
        ''' </item>
        ''' <item>
        ''' <term>A specific port.</term>
        ''' </item>
        ''' <item>
        ''' <term>A specific application on a specific port.</term>
        ''' </item>
        ''' </list>
        ''' <para>
        ''' In its operation <c>IsPortAllowed</c> considers whether the firewall Is currently enabled Or disabled, whether the application
        ''' Is allowed in the current profile Exceptions List, whether the port Is allowed in the current profile Exceptions List, whether
        ''' the file And print sharing option has been enabled, And whether the remote administration option has been enabled.
        ''' </para>
        ''' <para>
        ''' Because of the many factors in determining whether a port Is allowed, the more specific information that Is given via this
        ''' method's input parameters, the more likely a clear result with meaningful restrictions will be returned.
        ''' </para>
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(4)>
        Sub IsPortAllowed(<[In], [Optional], MarshalAs(UnmanagedType.BStr)> ByVal imageFileName As String, <[In]> ByVal ipVersion As NET_FW_IP_VERSION, <[In]> ByVal portNumber As Integer,
                          <[In], [Optional], MarshalAs(UnmanagedType.BStr)> ByVal localAddress As String, <[In]> ByVal ipProtocol As NET_FW_IP_PROTOCOL,
                          <Out, MarshalAs(UnmanagedType.VariantBool)> ByRef allowed As Boolean, <Out, MarshalAs(UnmanagedType.VariantBool)> ByRef restricted As Boolean)

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Determines whether the specified ICMP type Is allowed.</para>
        ''' </summary>
        ''' <param name="ipVersion">
        ''' <para>IP version of the traffic. This cannot be <c>NET_FW_IP_VERSION_ANY</c>.</para>
        ''' <para>IP version of the traffic. This cannot be <c>NET_FW_IP_VERSION_ANY</c>.</para>
        ''' </param>
        ''' <param name="localAddress">
        ''' <para>
        ''' Either a dotted-decimal IPv4 address Or an IPv6 hex address specifying the local address of the traffic. Typically, this Is the
        ''' address passed to bind. If localAddress Is <c>NULL</c>, the function determines whether the port Is allowed for all interfaces.
        ''' </para>
        ''' <para>
        ''' Either a dotted-decimal IPv4 address Or an IPv6 hex address specifying the local address of the traffic. Typically, this Is the
        ''' address passed to bind. If localAddress Is <c>NULL</c>, the function determines whether the port Is allowed for all interfaces.
        ''' </para>
        ''' </param>
        ''' <param name="type">
        ''' <para>ICMP type. For a list of possible ICMP types, see ICMP Type Numbers.</para>
        ''' <para>ICMP type.</para>
        ''' </param>
        ''' <param name="allowed">
        ''' <para>
        ''' Indicates by a value of VARIANT_TRUE Or VARIANT_FALSE whether the port Is allowed for at least some local interfaces And remote addresses.
        ''' </para>
        ''' <para>
        ''' Indicates by a value of VARIANT_TRUE Or VARIANT_FALSE whether the port Is allowed for at least some local interfaces And remote addresses.
        ''' </para>
        ''' </param>
        ''' <param name="restricted">
        ''' <para>
        ''' Indicates by a value of VARIANT_TRUE Or VARIANT_FALSE whether some local interfaces Or remote addresses are blocked for this
        ''' port. For example, if the port Is restricted to the local subnet only.
        ''' </para>
        ''' <para>
        ''' Indicates by a value of VARIANT_TRUE Or VARIANT_FALSE whether some local interfaces Or remote addresses are blocked for this
        ''' port. For example, if the port Is restricted to the local subnet only.
        ''' </para>
        ''' </param>
        ''' <remarks>The INetFwPolicy2:IsRuleGroupEnabled method Is generally recommended In place Of this method.</remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(5)>
        Sub IsIcmpTypeAllowed(<[In]> ByVal ipVersion As NET_FW_IP_VERSION, <[In], [Optional], MarshalAs(UnmanagedType.BStr)> ByVal localAddress As String,
                              <[In]> ByVal type As Byte, <Out, MarshalAs(UnmanagedType.VariantBool)> ByRef allowed As Boolean, <Out, MarshalAs(UnmanagedType.VariantBool)> ByRef restricted As Boolean)

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The <c>INetFwOpenPort</c> interface provides access to the properties of a port that has been opened in the firewall.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>Ports with their <c>BuiltIn</c> property set to true ( <c>VARIANT_TRUE</c>) are system specified And cannot be removed.</para>
    ''' <para>When creating New ports, this interface Is supported by the <c>HNetCfg.FWOpenPort</c> COM object.</para>
    ''' <para>For reading Or modifying existing ports, instances of this interface are retrieved through the INetFwOpenPortscollection.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwOpenPort")>
    <ComImport, Guid("E0483BA0-47FF-4D9C-A6D6-7741D0B195F7"), CoClass(GetType(NetFwOpenPort))>
    Public Interface INetFwOpenPort

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the friendly name of this port.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>This property Is required.</remarks>
        <DispId(1)>
        Property Name As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the IP version setting for this port.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>Only <c>NET_FW_IP_VERSION_ANY</c> Is supported And this Is the default for New ports.</remarks>
        <DispId(2)>
        Property IpVersion As NET_FW_IP_VERSION

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the protocol type setting for this port.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>The default protocol type Is TCP for New ports.</remarks>
        <DispId(3)>
        Property Protocol As NET_FW_IP_PROTOCOL

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifiess the host-ordered port number for this port.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(4)>
        Property Port As Integer

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Controls the network scope from which the port can listen.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>When setting the Scope property, only <c>NET_FW_SCOPE_ALL</c> And <c>NET_FW_SCOPE_LOCAL_SUBNET</c> are valid.</para>
        ''' <para>The default value Is <c>NET_FW_SCOPE_ALL</c> for New ports.</para>
        ''' <para>To create a custom scope, use the RemoteAddresses property.</para>
        ''' </remarks>
        <DispId(5)>
        Property Scope As NET_FW_SCOPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies a set of remote addresses from which the port can listen for traffic.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*".
        ''' </para>
        ''' <para>Valid tokens:</para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*": any remote address; If present, it must be the only token.</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet": Not case-sensitive; specifying more than once has no effect.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' subnet: may be specified Using either subnet mask Or network prefix notation. If neither a subnet mask nor a network prefix Is
        ''' specified, the subnet mask defaults to 255.255.255.255. Examples of valid subnets: 10.0.0.2/255.0.0.0 10.0.0.2/8 10.0.0.2
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv4 address range In the format "start address - end address."</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv6 address range In the format "start address - end address."</term>
        ''' </item>
        ''' </list>
        ''' <para>For a predefined address range, use the Scope property.</para>
        ''' </remarks>
        <DispId(6)>
        Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether the settings for this port are currently enabled.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' This property can be set to false ( <c>VARIANT_FALSE</c>) to allow port settings to be stored in the INetFWOpenPorts collection
        ''' without actually opening the port.
        ''' </para>
        ''' <para>The default value Is true ( <c>VARIANT_TRUE</c>) for New ports.</para>
        ''' </remarks>
        <DispId(7)>
        Property Enabled As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether the port Is defined by the system.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <remarks>
        ''' Ports with their <c>BuiltIn</c> property set to true ( <c>VARIANT_TRUE</c>) are system specified And cannot be removed, only the
        ''' Enabled, RemoteAddress, And Scope properties can be modified.
        ''' </remarks>
        <DispId(8)>
        ReadOnly Property BuiltIn As Boolean

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The <c>INetFwOpenPorts</c> interface Is a standard Automation collection interface.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>An instance of this interface Is retrieved through the GloballyOpenPorts property of the INetFwProfile interface.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwOpenPorts")>
    <ComImport, Guid("C0E9D7FA-E07E-430A-B19A-090CE82D92E2")>
    Public Interface INetFwOpenPorts
        Inherits IEnumerable

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves a read-only element yielding the number of items in the collection.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property Count As Integer

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Opens a New port And adds it to the collection.</para>
        ''' </summary>
        ''' <param name="port">Port to add to the collection.</param>
        ''' <remarks>If the port Is already open, the existing settings are overwritten.</remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Sub Add(<[In], MarshalAs(UnmanagedType.Interface)> ByVal Port As INetFwOpenPort)

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Closes a port And removes it from the collection.</para>
        ''' </summary>
        ''' <param name="portNumber">Port number to remove.</param>
        ''' <param name="ipProtocol">Protocol of the port to remove.</param>
        ''' <remarks>If the port Is already closed ,the <c>Remove</c> method has no effect.</remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(3)>
        Sub Remove(<[In]> ByVal portNumber As Integer, <[In]> ByVal ipProtocol As NET_FW_IP_PROTOCOL)

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Returns the specified port if it Is in the collection.</para>
        ''' </summary>
        ''' <param name="portNumber">Port number to find.</param>
        ''' <param name="ipProtocol">Protocol of the port to find by type NET_FW_IP_PROTOCOL.</param>
        ''' <returns>
        ''' <para>Reference to the returned INetFwOpenPort object.</para>
        ''' </returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(4)>
        Function Item(<[In]> ByVal portNumber As Integer, <[In]> ByVal ipProtocol As NET_FW_IP_PROTOCOL) As <MarshalAs(UnmanagedType.Interface)> INetFwOpenPort

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Returns an object supporting <c>IEnumVARIANT</c> that can be used to iterate through all the ports in the collection.</para>
        ''' <para>
        ''' Iteration through a collection Is done using the <c>for each</c> construct in VBScript. See Iterating a Collection for an example.
        ''' </para>
        ''' </summary>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(-4)>
        Overloads Function GetEnumerator() As <MarshalAs(UnmanagedType.CustomMarshaler, MarshalType:="", MarshalTypeRef:=GetType(EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> IEnumerator

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The <c>INetFwPolicy</c> interface provides access to a firewall policy.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>Instances of this interface are retrieved through the LocalPolicy property of the INetFwMgr interface.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' <para>The Windows Firewall/Internet Connection Sharing service must be running to access this interface.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwPolicy")>
    <ComImport, Guid("D46D2478-9AC9-4008-9DC7-5563CE5536CC")>
    Public Interface INetFwPolicy

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the current firewall profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <value>The current firewall profile.</value>
        ''' <remarks>
        ''' <para>The SharedAccess service must be running.</para>
        ''' <para>To get specific profile objects, use INetFwPolicy:GetProfileByType instead Of <c>INetFwPolicy:CurrentProfile</c>.</para>
        ''' <para>
        ''' On Windows 7, the netsh context <c>current</c> maps to all currently active profiles for netsh advfirewall And netsh firewall.
        ''' On earlier versions of Windows, <c>current</c> maps to the most restrictive profile.
        ''' </para>
        ''' </remarks>
        <DispId(1)>
        ReadOnly Property CurrentProfile As <MarshalAs(UnmanagedType.Interface)> INetFwProfile

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the profile of the requested type.</para>
        ''' </summary>
        ''' <param name="profileType">Type of profile from NET_FW_PROFILE_TYPE.</param>
        ''' <returns>Retrieved profile of type INetFwProfile.</returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Function GetProfileByType(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE) As <MarshalAs(UnmanagedType.Interface)> INetFwProfile

    End Interface

    ''' <summary>The <c>INetFwPolicy2</c> interface allows an application Or service to access the firewall policy.</summary>
    ''' <remarks>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' <para>The Windows Firewall/Internet Connection Sharing service must be running to access this interface.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwPolicy2")>
    <ComImport, Guid("98325047-C671-4174-8D81-DEFCD3F03186"), CoClass(GetType(NetFwPolicy2))>
    Public Interface INetFwPolicy2

        ''' <summary>
        ''' <para>Retrieves the currently active firewall profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <remarks>Multiple profiles can be returned in the profiles bitmask.</remarks>
        <DispId(1)>
        ReadOnly Property CurrentProfileTypes As NET_FW_PROFILE_TYPE2

        ''' <summary>
        ''' <para>Indicates whether a firewall Is enabled locally (the effective result may differ due to group policy settings).</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <param name="profileType"/>
        ''' <remarks>
        ''' When you pass a profile type obtained from the CurrentProfileTypes property, make sure that you pass only one profile type to
        ''' <c>get_FirewallEnabled</c> And <c>put_FirewallEnabled</c>. Note that <c>get_CurrentProfileTypes</c> can return multiple profiles.
        ''' </remarks>
        <DispId(2)>
        Property FirewallEnabled(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As Boolean

        ''' <summary>
        ''' <para>Specifies a list of interfaces on which firewall settings are excluded.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <param name="profileType"/>
        ''' <remarks>
        ''' <para>
        ''' An excluded interface Is an interface to which the firewall Is Not applicable. The firewall Is Not applicable to any traffic
        ''' received from Or sent to an excluded interface. An empty list indicates that there are no excluded interfaces.
        ''' </para>
        ''' <para>
        ''' When you pass a profile type obtained from the CurrentProfileTypes property, make sure that you pass only one profile type to
        ''' <c>get_ExcludedInterfaces</c> And <c>put_ExcludedInterfaces</c>. Note that <c>get_CurrentProfileTypes</c> can return multiple profiles.
        ''' </para>
        ''' </remarks>
        <DispId(3)>
        Property ExcludedInterfaces(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As <MarshalAs(UnmanagedType.Struct)> Object

        ''' <summary>
        ''' <para>Indicates whether the firewall should Not allow inbound traffic.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <param name="profileType"/>
        ''' <remarks>
        ''' <para>
        ''' All interfaces are firewall-enabled. This means that all the exceptions (such as GloballyOpenPorts, Applications, Or
        ''' Services) which are specified in the profile are ignored And only locally-initiated traffic Is allowed.
        ''' </para>
        ''' <para>
        ''' When you pass a profile type obtained from the CurrentProfileTypes property, make sure that you pass only one profile type to
        ''' <c>get_BlockAllInboundTraffic</c> And <c>put_BlockAllInboundTraffic</c>. Note that <c>get_CurrentProfileTypes</c> can return
        ''' multiple profiles.
        ''' </para>
        ''' </remarks>
        <DispId(4)>
        Property BlockAllInboundTraffic(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As Boolean

        ''' <summary>
        ''' <para>Indicates whether interactive firewall notifications are disabled.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(5)>
        Property NotificationsDisabled(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As Boolean

        ''' <summary>
        ''' <para>Indicates whether the firewall should Not allow unicast responses to multicast And broadcast traffic.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <param name="profileType"/>
        ''' <remarks>
        ''' <para>
        ''' If a computer sends a broadcast packet, a unicast response Is allowed for three seconds. Use this property to change this behavior.
        ''' </para>
        ''' <para>
        ''' When you pass a profile type obtained from the CurrentProfileTypes property ( <c>get_CurrentProfileTypes</c>), make sure that
        ''' you pass only one profile type to <c>get_UnicastResponsesToMulticastBroadcastDisabled</c> And
        ''' <c>put_UnicastResponsesToMulticastBroadcastDisabled</c>. Note that <c>get_CurrentProfileTypes</c> can return multiple profiles.
        ''' </para>
        ''' </remarks>
        <DispId(6)>
        Property UnicastResponsesToMulticastBroadcastDisabled(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As Boolean

        ''' <summary>
        ''' <para>Retrieves the collection of firewall rules.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(7)>
        ReadOnly Property Rules As <MarshalAs(UnmanagedType.Interface)> INetFwRules

        ''' <summary>
        ''' <para>Retrieves the interface used to access the Windows Service Hardening store.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(8)>
        ReadOnly Property ServiceRestriction As <MarshalAs(UnmanagedType.Interface)> INetFwServiceRestriction

        ''' <summary>The <c>EnableRuleGroup</c> method enables Or disables a specified group of firewall rules.</summary>
        ''' <param name="profileTypesBitmask">A bitmask of profiles from NET_FW_PROFILE_TYPE2.</param>
        ''' <param name="group">
        ''' A string that was used to group rules together. It can be the group name Or an indirect string to the group name in the form of
        ''' "@C:\Program Files\Contoso Storefront\StorefrontRes.dll,-1234". Rules belonging to this group would be enabled Or disabled.
        ''' </param>
        ''' <param name="enable">
        ''' <para>Indicates whether the group of rules identified by the group parameter are to be enabled Or disabled.</para>
        ''' <para>If this value Is set to true ( <c>VARIANT_TRUE</c>), the group of rules will be enabled; otherwise the group Is disabled.</para>
        ''' </param>
        ''' <remarks>
        ''' When indirect strings in the form of "@C:\Program Files\Contoso Storefront\StorefrontRes.dll,-1234" are passed as parameters to
        ''' the Windows Firewall with Advanced Security APIs, they should be specified by a full path. The file should have a secure access
        ''' that permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid
        ''' non-privileged security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(9)>
        Sub EnableRuleGroup(<[In]> ByVal profileTypesBitmask As NET_FW_PROFILE_TYPE2, <[In], MarshalAs(UnmanagedType.BStr)> ByVal group As String, <[In]> ByVal enable As Boolean)

        ''' <summary>The <c>IsRuleGroupEnabled</c> method determines whether a specified group of firewall rules are enabled Or disabled.</summary>
        ''' <param name="profileTypesBitmask">A bitmask of profiles from NET_FW_PROFILE_TYPE2.</param>
        ''' <param name="group">
        ''' A string that was used to group rules together. It can be the group name Or an indirect string to the group name in the form of
        ''' "@yourresourcedll.dll,-23255". Rules belonging to this group would be queried.
        ''' </param>
        ''' <returns>
        ''' This call returns a boolean enable status which indicates whether the group of rules identified by the group parameter are
        ''' enabled Or disabled. If this value Is set to true (VARIANT_TRUE), the group of rules Is enabled; otherwise, the group Is disabled.
        ''' </returns>
        ''' <remarks>
        ''' When indirect strings in the form of "@yourresourcedll.dll,-23255" are passed as parameters to the Windows Firewall with
        ''' Advanced Security APIs, they should either be placed under the System32 Windows directory Or specified by a full path. Further
        ''' the file should have a secure access that permits the Local Service account read access to allow the Windows Firewall Service to
        ''' read the strings. To avoid non-privileged security principals from modifying the strings, the DLLs should only allow write
        ''' access to the Administrator account.
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(10)>
        Function IsRuleGroupEnabled(<[In]> ByVal profileTypesBitmask As NET_FW_PROFILE_TYPE2, <[In], MarshalAs(UnmanagedType.BStr)> ByVal group As String) As Boolean

        ''' <summary>The <c>RestoreLocalFirewallDefaults</c> method restores the local firewall configuration to its default state.</summary>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(11)>
        Sub RestoreLocalFirewallDefaults()

        ''' <summary>
        ''' <para>Specifies the default action for inbound traffic. These settings are Block by default.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' All interfaces are firewall-enabled. This means that all the exceptions (such as GloballyOpenPorts, Applications, Or
        ''' Services) which are specified in the profile, are ignored And only locally-initiated traffic Is allowed.
        ''' </para>
        ''' <para>
        ''' When you pass a profile type obtained from the CurrentProfileTypes property, make sure that you pass only one profile type to
        ''' <c>get_DefaultInboundAction</c> And <c>put_DefaultInboundAction</c>. Note that <c>get_CurrentProfileTypes</c> can return
        ''' multiple profiles.
        ''' </para>
        ''' </remarks>
        <DispId(12)>
        Property DefaultInboundAction(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As NET_FW_ACTION

        ''' <summary>
        ''' <para>Specifies the default action for outbound traffic. These settings are Allow by default.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' All interfaces are firewall-enabled. This means that all the exceptions (such as GloballyOpenPorts, Applications, Or
        ''' Services) which are specified in the profile are ignored And only locally-initiated traffic Is allowed.
        ''' </para>
        ''' <para>
        ''' When you pass a profile type obtained from the CurrentProfileTypes property, make sure that you pass only one profile type to
        ''' <c>get_DefaultOutboundAction</c> And <c>put_DefaultOutboundAction</c>. Note that <c>get_CurrentProfileTypes</c> can return
        ''' multiple profiles.
        ''' </para>
        ''' </remarks>
        <DispId(13)>
        Property DefaultOutboundAction(<[In]> ByVal profileType As NET_FW_PROFILE_TYPE2) As NET_FW_ACTION

        ''' <summary>
        ''' The <c>get_IsRuleGroupCurrentlyEnabled</c> method determines whether a specified group of firewall rules are enabled Or disabled
        ''' for the current profile.
        ''' </summary>
        ''' <param name="group">
        ''' A string that was used to group rules together. It can be the group name Or an indirect string to the group name in the form of
        ''' "@C:\Program Files\Contoso Storefront\StorefrontRes.dll,-1234". Rules belonging to this group would be queried.
        ''' </param>
        ''' <returns>
        ''' <para>
        ''' This call returns a boolean enable status which indicates whether the group of rules identified by the group parameter are
        ''' enabled Or disabled. If this value Is set to true ( <c>VARIANT_TRUE</c>), the group of rules Is enabled; otherwise, the group Is disabled.
        ''' </para>
        ''' </returns>
        ''' <remarks>
        ''' When indirect strings in the form of "@C:\Program Files\Contoso Storefront\StorefrontRes.dll,-1234" are passed as parameters to
        ''' the Windows Firewall with Advanced Security APIs, they should be specified by a full path. The file should have a secure access
        ''' that permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid
        ''' non-privileged security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
        ''' </remarks>
        <DispId(14)>
        ReadOnly Property IsRuleGroupCurrentlyEnabled(<[In]> ByVal group As String) As Boolean

        ''' <summary>
        ''' <para>
        ''' The LocalPolicyModifyState attribute determines if adding Or setting a rule Or group of rules will take effect in the current
        ''' firewall profile.
        ''' </para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(15)>
        ReadOnly Property LocalPolicyModifyState As NET_FW_MODIFY_STATE

    End Interface

    ''' <summary>
    ''' The <c>INetFwProduct</c> interface allows an application Or service to access the properties of a third-party firewall registration.
    ''' </summary>
    <ComImport, Guid("71881699-18F4-458B-B892-3FFCE5E07F75"), CoClass(GetType(NetFwProduct))>
    Public Interface INetFwProduct

        ''' <summary>
        ''' <para>
        ''' For a third-party firewall product registration, indicates the rule categories for which the third-party firewall wishes to take
        ''' ownership from Windows Firewall.
        ''' </para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(1)>
        Property RuleCategories As <MarshalAs(UnmanagedType.Struct)> Object

        ''' <summary>
        ''' <para>Indicates the display name for a third-party firewall product registration.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(2)>
        Property DisplayName As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Indicates the path to the signed executable file of a third-party firewall product registration.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <remarks>This Is a read-only property, which Is set after the product has been registered.</remarks>
        <DispId(3)>
        ReadOnly Property PathToSignedProductExe As <MarshalAs(UnmanagedType.BStr)> String

    End Interface

    ''' <summary>
    ''' The <c>INetFwProducts</c> interface allows an application Or service to access the methods And properties for registering
    ''' third-party firewall products with Windows Firewall And for enumerating registered products.
    ''' </summary>
    <ComImport, Guid("39EB36E0-2097-40BD-8AF2-63A13B525362"), CoClass(GetType(NetFwProducts))>
    Public Interface INetFwProducts
        Inherits IEnumerable

        ''' <summary>
        ''' <para>Indicates the number of registered third-party firewall products.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property Count As Integer

        ''' <summary>The <c>Register</c> method registers a third-party firewall product.</summary>
        ''' <param name="product">The INetFwProduct object that defines the product to be registered.</param>
        ''' <returns>The registration handle. The registration will be removed when this object Is released.</returns>
        ''' <remarks>
        ''' <para>
        ''' Registrations only last for the lifetime of the Windows Firewall service. Third-party firewalls calling this API should also
        ''' have a service dependency on the Windows Firewall service (mpssvc) to make sure that the service Is Not unexpectedly stopped,
        ''' causing all registrations to be lost.
        ''' </para>
        ''' <para>
        ''' Registrations are removed when a returned registration object Is released by the third-party firewall Or when the third-party
        ''' firewall process exits.
        ''' </para>
        ''' <para>
        ''' A user mode code module using this API should be linked with the /integritycheck linker flag. This flag sets
        ''' IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY in the image PE header OptionalHeader.DllCharacteristics field, which enforces a
        ''' signature check at load time. The code module should be digitally signed, consistent with the Authenticode signing procedure.
        ''' </para>
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Function Register(<[In], MarshalAs(UnmanagedType.Interface)> ByVal product As INetFwProduct) As <MarshalAs(UnmanagedType.IUnknown)> Object

        ''' <summary>The <c>Item</c> method returns the product with the specified index if it Is in the collection.</summary>
        ''' <param name="index">Index of the product to retrieve.</param>
        ''' <returns>Reference to the returned INetFwProduct object.</returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(3)>
        Function Item(<[In]> ByVal index As Integer) As <MarshalAs(UnmanagedType.Interface)> INetFwProduct

        ''' <summary>
        ''' <para>
        ''' Returns an object supporting <c>IEnumVARIANT</c> that can be used to iterate through all the registered third-party firewall
        ''' products in the collection.
        ''' </para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(-4)>
        Overloads Function GetEnumerator() As <MarshalAs(UnmanagedType.CustomMarshaler, MarshalType:="", MarshalTypeRef:=GetType(EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> IEnumerator

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The <c>INetFwProfile</c> interface provides access to the firewall settings profile.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>
    ''' Instances of this interface are retrieved through the CurrentProfile property Or GetProfileByType method of the INetFwPolicy interface.
    ''' </para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwProfile")>
    <ComImport, Guid("174A0DDA-E9F9-449D-993B-21AB667CA456")>
    Public Interface INetFwProfile

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Speciifes the type of the profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property Type As NET_FW_PROFILE_TYPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether the firewall Is enabled.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' The resulting firewall status Is based on the local policy from the local store. Use the procedure Checking the Effective
        ''' Firewall Status to determine the overall operational state.
        ''' </remarks>
        <DispId(2)>
        Property FirewallEnabled As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether the firewall should Not allow exceptions.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' All interfaces are firewalled. This means that all the exceptions; such as GloballyOpenPorts, Applications, Or Services, which
        ''' are specified in the profile, are ignored And only locally initiated traffic Is allowed.
        ''' </para>
        ''' <para>
        ''' The resulting firewall status Is determined by the combination of two levels: First check the Global operation mode, Then the
        ''' mode on the interface of interest. Use the procedure Checking the Effective Firewall Status to determine the overall operational state.
        ''' </para>
        ''' </remarks>
        <DispId(3)>
        Property ExceptionsNotAllowed As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether interactive firewall notifications are disabled.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(4)>
        Property NotificationsDisabled As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether the firewall should Not allow unicast responses to multicast And broadcast traffic.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' If a PC sends a broadcast packet, a unicast response Is allowed for three seconds. Use this property to change this behavior.
        ''' </remarks>
        <DispId(5)>
        Property UnicastResponsesToMulticastBroadcastDisabled As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the settings governing remote administration.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(6)>
        ReadOnly Property RemoteAdminSettings As <MarshalAs(UnmanagedType.Interface)> INetFwRemoteAdminSettings

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the ICMP settings of the profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(7)>
        ReadOnly Property IcmpSettings As <MarshalAs(UnmanagedType.Interface)> INetFwIcmpSettings

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the collection of globally open ports of the profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(8)>
        ReadOnly Property GloballyOpenPorts As <MarshalAs(UnmanagedType.Interface)> INetFwOpenPorts

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the collection of services of the profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(9)>
        ReadOnly Property Services As <MarshalAs(UnmanagedType.Interface)> INetFwServices

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the collection of authorized applications of the profile.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(10)>
        ReadOnly Property AuthorizedApplications As <MarshalAs(UnmanagedType.Interface)> INetFwAuthorizedApplications

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>The <c>INetFwRemoteAdminSettings</c> interface provides access to the settings that control remote administration.</para>
    ''' </summary>
    ''' <remarks>
    ''' <para>An instance of this interface Is retrieved through the RemoteAdminSettingsproperty of the INetFwProfile interface.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwRemoteAdminSettings")>
    <ComImport, Guid("D4BECDDF-6F73-4A83-B832-9C66874CD20E")>
    Public Interface INetFwRemoteAdminSettings

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the IP version.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This Is the IP version for which remote admin Is authorized.</para>
        ''' <para>Only <c>NET_FW_IP_VERSION_ANY</c> Is supported.</para>
        ''' </remarks>
        <DispId(1)>
        Property IpVersion As NET_FW_IP_VERSION

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Controls the network scope from which remote administration Is allowed.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>When setting the <c>Scope</c> property, only <c>NET_FW_SCOPE_ALL</c> And <c>NET_FW_SCOPE_LOCAL_SUBNET</c> are valid.</para>
        ''' <para>The default value Is <c>NET_FW_SCOPE_ALL</c> for New ports.</para>
        ''' <para>To create a custom scope, use the RemoteAddresses property of this interface.</para>
        ''' </remarks>
        <DispId(2)>
        Property Scope As NET_FW_SCOPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies a set of remote addresses from which remote administration Is allowed.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*".
        ''' </para>
        ''' <para>Valid tokens:</para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*": any remote address; If present, it must be the only token.</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet": Not case-sensitive; specifying more than once has no effect.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' subnet: may be specified Using either subnet mask Or network prefix notation. If neither a subnet mask nor a network prefix Is
        ''' specified, the subnet mask defaults to 255.255.255.255. Examples of valid subnets: 10.0.0.2/255.0.0.0 10.0.0.2/8 10.0.0.2
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv4 address range In the format "start address - end address."</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv6 address range In the format "start address - end address."</term>
        ''' </item>
        ''' </list>
        ''' <para>For a predefined address range, use the Scope property.</para>
        ''' </remarks>
        <DispId(3)>
        Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether remote administration Is enabled..</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(4)>
        Property Enabled As Boolean

    End Interface

    ''' <summary>The <c>INetFwRule</c> interface provides access to the properties of a rule.</summary>
    ''' <remarks>
    ''' <para>
    ''' Each time you change a property of a rule, Windows Firewall commits the rule And verifies it for correctness. As a result, when you
    ''' edit a rule, you must perform the steps in a specific order. For example, if you add an ICMP rule, you must first set the protocol
    ''' to ICMP, then add the rule. If these steps are taken in the opposite order, an error occurs And the change Is lost.
    ''' </para>
    ''' <para>
    ''' If you are editing a TCP port rule And converting it into an ICMP rule, first delete the port, change protocol from TCP to ICMP, And
    ''' then add the rule.
    ''' </para>
    ''' <para>
    ''' In order to retrieve And modify existing rules, instances of this interface must be retrieved through INetFwRules. All configuration
    ''' changes take place immediately.
    ''' </para>
    ''' <para>When accessing the properties of a rule, keep in mind that there may be a small time lag before a newly-added rule Is applied.</para>
    ''' <para>
    ''' Properties are used to create firewall rules. Many of the properties can be used in order to create very specific firewall rules.
    ''' </para>
    ''' <list type="table">
    ''' <listheader>
    ''' <term>Property</term>
    ''' <term>Type And format</term>
    ''' <term>Constraints</term>
    ''' </listheader>
    ''' <item>
    ''' <term>Name</term>
    ''' <term>Clear text string.</term>
    ''' <term>Required. The string must Not contain a "|" And it must Not be "all".</term>
    ''' </item>
    ''' <item>
    ''' <term>Description</term>
    ''' <term>Clear text string.</term>
    ''' <term>Optional. The string must Not contain a "|".</term>
    ''' </item>
    ''' <item>
    ''' <term>Grouping</term>
    ''' <term>String in the format "@&lt;dll name&gt;, &lt;resource string identifier&gt;".</term>
    ''' <term>Required.</term>
    ''' </item>
    ''' <item>
    ''' <term>Enabled</term>
    ''' <term>Boolean (VARIANT_BOOLEAN).</term>
    ''' <term>Optional. Defaults to false (VARIANT_FALSE) if nothing Is specified.</term>
    ''' </item>
    ''' <item>
    ''' <term>ApplicationName</term>
    ''' <term>Clear text string.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>ServiceName</term>
    ''' <term>Clear text string.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>LocalPorts</term>
    ''' <term>Clear text string containing a list of port numbers. "RPC" Is an acceptable value.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>RemotePorts</term>
    ''' <term>Clear text string containing a list of port numbers.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>LocalAddresses</term>
    ''' <term>
    ''' Clear text string containing a list of IPv4 And IPv6 addresses separated by commas. Range values And"*"are acceptable in this list.
    ''' </term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>RemoteAddresses</term>
    ''' <term>
    ''' Clear text string containing a list of IPv4 And IPv6 addresses separated by commas. Range values And"*"are acceptable in this list.
    ''' </term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>Protocol</term>
    ''' <term>Number.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>put_Profiles</term>
    ''' <term>
    ''' String value in the format "type, code". Multiple types And codes can be included in the string by separating each pair with a ";".
    ''' </term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>Interfaces</term>
    ''' <term>Array of strings containing the friendly names of interfaces.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>InterfaceTypes</term>
    ''' <term>
    ''' String value. Multiple interface types can be included in the string by separating each value with a ",". Acceptable values are
    ''' "RemoteAccess", "Wireless", "Lan", And "All".
    ''' </term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>Direction</term>
    ''' <term>Enumeration.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>Action</term>
    ''' <term>Enumeration.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>EdgeTraversal</term>
    ''' <term>Boolean (VARIANT_BOOLEAN).</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' <item>
    ''' <term>Profiles</term>
    ''' <term>Enumeration.</term>
    ''' <term>Optional.</term>
    ''' </item>
    ''' </list>
    ''' <para>For additional information on each property, please see the corresponding topic.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwRule")>
    <ComImport, Guid("AF230D27-BABA-4E42-ACED-F524F22CFCE2"), CoClass(GetType(NetFwRule))>
    Public Interface INetFwRule

        ''' <summary>
        ''' <para>Specifies the friendly name of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is required. The string must Not contain the "|" character.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(1)>
        Property Name As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the description of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. The string must Not contain the "|" character.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(2)>
        Property Description As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the friendly name of the application to which this rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(3)>
        Property ApplicationName As <MarshalAs(UnmanagedType.BStr)> String

#Disable Warning IDE1006 ' Naming Styles
        ''' <summary>
        ''' <para>Specifies the service name property of the application.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' This property Is optional. A serviceName value of "*" indicates that a service, Not an application, must be sending Or receiving traffic.
        ''' </para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(4)>
        Property serviceName As <MarshalAs(UnmanagedType.BStr)> String
#Enable Warning IDE1006 ' Naming Styles

        ''' <summary>
        ''' <para>Specifies the IP protocol of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The <c>Protocol</c> property must be set before the LocalPorts Or RemotePorts properties Or an error will be returned.</para>
        ''' <para>A list of protocol numbers Is available at the IANA website.</para>
        ''' </remarks>
        <DispId(5)>
        Property Protocol As Integer

        ''' <summary>
        ''' <para>Specifies the list of local ports for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The Protocol property must be set before the <c>LocalPorts</c> property Or an error will be returned.</para>
        ''' </remarks>
        <DispId(6)>
        Property LocalPorts As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of remote ports for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The Protocol property must be set before the <c>RemotePorts</c> property Or an error will be returned.</para>
        ''' </remarks>
        <DispId(7)>
        Property RemotePorts As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of local addresses for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The localAddrs parameter consists of one Or more comma-delimited tokens specifying the local addresses from which the
        ''' application can listen for traffic. "*" Is the default value. Valid tokens include:
        ''' </para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*" indicates any local address. If present, this must be the only token included.</term>
        ''' </item>
        ''' <item>
        ''' <term>"Defaultgateway"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DHCP"</term>
        ''' </item>
        ''' <item>
        ''' <term>"WINS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet" indicates any local address on the local subnet. This token Is Not case-sensitive.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' A subnet can be specified using either the subnet mask Or network prefix notation. If neither a subnet mask Not a network prefix
        ''' Is specified, the subnet mask defaults to 255.255.255.255.
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <DispId(8)>
        Property LocalAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of remote addresses for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*". Valid tokens include:
        ''' </para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*" indicates any remote address. If present, this must be the only token included.</term>
        ''' </item>
        ''' <item>
        ''' <term>"Defaultgateway"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DHCP"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DNS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"WINS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet" indicates any local address on the local subnet. This token Is Not case-sensitive.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' A subnet can be specified using either the subnet mask Or network prefix notation. If neither a subnet mask Not a network prefix
        ''' Is specified, the subnet mask defaults to 255.255.255.255.
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <DispId(9)>
        Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of ICMP types And codes for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The icmpTypesAndCodes parameter Is a list of ICMP types And codes separated by semicolon. "*" indicates all ICMP types And codes.
        ''' </para>
        ''' </remarks>
        <DispId(10)>
        Property IcmpTypesAndCodes As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the direction of traffic for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. If this property Is Not specified, the default value Is <c>in</c>.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(11)>
        Property Direction As NET_FW_RULE_DIRECTION

        ''' <summary>
        ''' <para>Specifies the list of interfaces for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. The interfaces in the list are represented by their friendly name.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(12)>
        Property Interfaces As <MarshalAs(UnmanagedType.Struct)> Object

        ''' <summary>
        ''' <para>Specifies the list of interface types for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' Acceptable values for this property are "RemoteAccess", "Wireless", "Lan", And "All". If more than one interface type Is
        ''' specified, the strings must be separated by a comma.
        ''' </para>
        ''' </remarks>
        <DispId(13)>
        Property InterfaceTypes As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Enables Or disables a rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. A New rule Is disabled by default.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(14)>
        Property Enabled As Boolean

        ''' <summary>
        ''' <para>Specifies the group to which an individual rule belongs.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' Using the Grouping property Is highly recommended, as it groups multiple rules into a single line in the Windows Firewall
        ''' control panel. This allows the user to enable Or disable multiple rules with a single click. The Grouping property can also be
        ''' specified using indirect strings. In this case, a group description can also be specified that will appear in the rule group
        ''' properties in the Windows Firewall control panel. For example, if the group string Is specified by an indirect string at index
        ''' 1005 ("@yourresources.dll,-1005"), the group description can be specified at a resource string higher by 10000 "@youresources.dll,-11005."
        ''' </para>
        ''' <para>
        ''' When indirect strings in the form of "h" are passed as parameters to the Windows Firewall with Advanced Security APIs, they
        ''' should either be placed under the System32 Windows directory Or specified by a full path. Further, the file should have a secure
        ''' access that permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid
        ''' non-privileged security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
        ''' </para>
        ''' </remarks>
        <DispId(15)>
        Property Grouping As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the profiles to which the rule belongs.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H10)>
        Property Profiles As NET_FW_PROFILE_TYPE2

        ''' <summary>
        ''' <para>Indicates whether edge traversal Is enabled Or disabled for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The EdgeTraversal property indicates that specific inbound traffic Is allowed to tunnel through NATs And other edge devices
        ''' using the Teredo tunneling technology. In order for this setting to work correctly, the application Or service with the inbound
        ''' firewall rule needs to support IPv6. The primary application of this setting allows listeners on the host to be globally
        ''' addressable through a Teredo IPv6 address.
        ''' </para>
        ''' <para>New rules have the EdgeTraversal property disabled by default.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H11)>
        Property EdgeTraversal As Boolean

        ''' <summary>
        ''' <para>Specifies the action for a rule Or default setting.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H12)>
        Property Action As NET_FW_ACTION

    End Interface

    ''' <summary>
    ''' The <c>INetFwRule2</c> interface allows an application Or service to access all the properties of INetFwRule as well as the four
    ''' edge properties of a firewall rule specified by NET_FW_EDGE_TRAVERSAL_TYPE.
    ''' </summary>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwRule2")>
    <ComImport, Guid("9C27C8DA-189B-4DDE-89F7-8B39A316782C"), CoClass(GetType(NetFwRule))>
    Public Interface INetFwRule2
        Inherits INetFwRule

        ''' <summary>
        ''' <para>Specifies the friendly name of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is required. The string must Not contain the "|" character.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(1)>
        Overloads Property Name As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the description of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. The string must Not contain the "|" character.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(2)>
        Overloads Property Description As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the friendly name of the application to which this rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(3)>
        Overloads Property ApplicationName As <MarshalAs(UnmanagedType.BStr)> String

#Disable Warning IDE1006 ' Naming Styles
        ''' <summary>
        ''' <para>Specifies the service name property of the application.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' This property Is optional. A serviceName value of "*" indicates that a service, Not an application, must be sending Or receiving traffic.
        ''' </para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(4)>
        Overloads Property serviceName As <MarshalAs(UnmanagedType.BStr)> String
#Enable Warning IDE1006 ' Naming Styles

        ''' <summary>
        ''' <para>Specifies the IP protocol of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The <c>Protocol</c> property must be set before the LocalPorts Or RemotePorts properties Or an error will be returned.</para>
        ''' <para>A list of protocol numbers Is available at the IANA website.</para>
        ''' </remarks>
        <DispId(5)>
        Overloads Property Protocol As Integer

        ''' <summary>
        ''' <para>Specifies the list of local ports for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The Protocol property must be set before the <c>LocalPorts</c> property Or an error will be returned.</para>
        ''' </remarks>
        <DispId(6)>
        Overloads Property LocalPorts As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of remote ports for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The Protocol property must be set before the <c>RemotePorts</c> property Or an error will be returned.</para>
        ''' </remarks>
        <DispId(7)>
        Overloads Property RemotePorts As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of local addresses for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The localAddrs parameter consists of one Or more comma-delimited tokens specifying the local addresses from which the
        ''' application can listen for traffic. "*" Is the default value. Valid tokens include:
        ''' </para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*" indicates any local address. If present, this must be the only token included.</term>
        ''' </item>
        ''' <item>
        ''' <term>"Defaultgateway"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DHCP"</term>
        ''' </item>
        ''' <item>
        ''' <term>"WINS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet" indicates any local address on the local subnet. This token Is Not case-sensitive.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' A subnet can be specified using either the subnet mask Or network prefix notation. If neither a subnet mask Not a network prefix
        ''' Is specified, the subnet mask defaults to 255.255.255.255.
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <DispId(8)>
        Overloads Property LocalAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of remote addresses for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*". Valid tokens include:
        ''' </para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*" indicates any remote address. If present, this must be the only token included.</term>
        ''' </item>
        ''' <item>
        ''' <term>"Defaultgateway"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DHCP"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DNS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"WINS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet" indicates any local address on the local subnet. This token Is Not case-sensitive.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' A subnet can be specified using either the subnet mask Or network prefix notation. If neither a subnet mask Not a network prefix
        ''' Is specified, the subnet mask defaults to 255.255.255.255.
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <DispId(9)>
        Overloads Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of ICMP types And codes for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The icmpTypesAndCodes parameter Is a list of ICMP types And codes separated by semicolon. "*" indicates all ICMP types And codes.
        ''' </para>
        ''' </remarks>
        <DispId(10)>
        Overloads Property IcmpTypesAndCodes As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the direction of traffic for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. If this property Is Not specified, the default value Is <c>in</c>.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(11)>
        Overloads Property Direction As NET_FW_RULE_DIRECTION

        ''' <summary>
        ''' <para>Specifies the list of interfaces for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. The interfaces in the list are represented by their friendly name.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(12)>
        Overloads Property Interfaces As <MarshalAs(UnmanagedType.Struct)> Object

        ''' <summary>
        ''' <para>Specifies the list of interface types for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' Acceptable values for this property are "RemoteAccess", "Wireless", "Lan", And "All". If more than one interface type Is
        ''' specified, the strings must be separated by a comma.
        ''' </para>
        ''' </remarks>
        <DispId(13)>
        Overloads Property InterfaceTypes As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Enables Or disables a rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. A New rule Is disabled by default.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(14)>
        Overloads Property Enabled As Boolean

        ''' <summary>
        ''' <para>Specifies the group to which an individual rule belongs.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' Using the Grouping property Is highly recommended, as it groups multiple rules into a single line in the Windows Firewall
        ''' control panel. This allows the user to enable Or disable multiple rules with a single click. The Grouping property can also be
        ''' specified using indirect strings. In this case, a group description can also be specified that will appear in the rule group
        ''' properties in the Windows Firewall control panel. For example, if the group string Is specified by an indirect string at index
        ''' 1005 ("@yourresources.dll,-1005"), the group description can be specified at a resource string higher by 10000 "@youresources.dll,-11005."
        ''' </para>
        ''' <para>
        ''' When indirect strings in the form of "h" are passed as parameters to the Windows Firewall with Advanced Security APIs, they
        ''' should either be placed under the System32 Windows directory Or specified by a full path. Further, the file should have a secure
        ''' access that permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid
        ''' non-privileged security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
        ''' </para>
        ''' </remarks>
        <DispId(15)>
        Overloads Property Grouping As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the profiles to which the rule belongs.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H10)>
        Overloads Property Profiles As NET_FW_PROFILE_TYPE2

        ''' <summary>
        ''' <para>Indicates whether edge traversal Is enabled Or disabled for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The EdgeTraversal property indicates that specific inbound traffic Is allowed to tunnel through NATs And other edge devices
        ''' using the Teredo tunneling technology. In order for this setting to work correctly, the application Or service with the inbound
        ''' firewall rule needs to support IPv6. The primary application of this setting allows listeners on the host to be globally
        ''' addressable through a Teredo IPv6 address.
        ''' </para>
        ''' <para>New rules have the EdgeTraversal property disabled by default.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H11)>
        Overloads Property EdgeTraversal As Boolean

        ''' <summary>
        ''' <para>Specifies the action for a rule Or default setting.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H12)>
        Overloads Property Action As NET_FW_ACTION

        ''' <summary>
        ''' <para>This property can be used to access the edge properties of a firewall rule defined by NET_FW_EDGE_TRAVERSAL_TYPE.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(&H13)>
        Property EdgeTraversalOptions As NET_FW_EDGE_TRAVERSAL_TYPE

    End Interface

    ''' <summary>
    ''' The <c>INetFwRule3</c> interface allows an application Or service to access all the properties of INetFwRule2 And to provide access
    ''' to the requirements of app containers.
    ''' </summary>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwRule3")>
    <ComImport, Guid("B21563FF-D696-4222-AB46-4E89B73AB34A"), CoClass(GetType(NetFwRule))>
    Public Interface INetFwRule3
        Inherits INetFwRule2

        ''' <summary>
        ''' <para>Specifies the friendly name of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is required. The string must Not contain the "|" character.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(1)>
        Overloads Property Name As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the description of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. The string must Not contain the "|" character.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(2)>
        Overloads Property Description As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the friendly name of the application to which this rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(3)>
        Overloads Property ApplicationName As <MarshalAs(UnmanagedType.BStr)> String

#Disable Warning IDE1006 ' Naming Styles
        ''' <summary>
        ''' <para>Specifies the service name property of the application.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' This property Is optional. A serviceName value of "*" indicates that a service, Not an application, must be sending Or receiving traffic.
        ''' </para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(4)>
        Overloads Property serviceName As <MarshalAs(UnmanagedType.BStr)> String
#Enable Warning IDE1006 ' Naming Styles

        ''' <summary>
        ''' <para>Specifies the IP protocol of this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The <c>Protocol</c> property must be set before the LocalPorts Or RemotePorts properties Or an error will be returned.</para>
        ''' <para>A list of protocol numbers Is available at the IANA website.</para>
        ''' </remarks>
        <DispId(5)>
        Overloads Property Protocol As Integer

        ''' <summary>
        ''' <para>Specifies the list of local ports for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The Protocol property must be set before the <c>LocalPorts</c> property Or an error will be returned.</para>
        ''' </remarks>
        <DispId(6)>
        Overloads Property LocalPorts As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of remote ports for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>The Protocol property must be set before the <c>RemotePorts</c> property Or an error will be returned.</para>
        ''' </remarks>
        <DispId(7)>
        Overloads Property RemotePorts As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of local addresses for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The localAddrs parameter consists of one Or more comma-delimited tokens specifying the local addresses from which the
        ''' application can listen for traffic. "*" Is the default value. Valid tokens include:
        ''' </para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*" indicates any local address. If present, this must be the only token included.</term>
        ''' </item>
        ''' <item>
        ''' <term>"Defaultgateway"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DHCP"</term>
        ''' </item>
        ''' <item>
        ''' <term>"WINS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet" indicates any local address on the local subnet. This token Is Not case-sensitive.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' A subnet can be specified using either the subnet mask Or network prefix notation. If neither a subnet mask Not a network prefix
        ''' Is specified, the subnet mask defaults to 255.255.255.255.
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <DispId(8)>
        Overloads Property LocalAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of remote addresses for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*". Valid tokens include:
        ''' </para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*" indicates any remote address. If present, this must be the only token included.</term>
        ''' </item>
        ''' <item>
        ''' <term>"Defaultgateway"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DHCP"</term>
        ''' </item>
        ''' <item>
        ''' <term>"DNS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"WINS"</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet" indicates any local address on the local subnet. This token Is Not case-sensitive.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' A subnet can be specified using either the subnet mask Or network prefix notation. If neither a subnet mask Not a network prefix
        ''' Is specified, the subnet mask defaults to 255.255.255.255.
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv4 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' <item>
        ''' <term>An IPv6 address range in the format of "start address - end address" with no spaces included.</term>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <DispId(9)>
        Overloads Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the list of ICMP types And codes for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' The icmpTypesAndCodes parameter Is a list of ICMP types And codes separated by semicolon. "*" indicates all ICMP types And codes.
        ''' </para>
        ''' </remarks>
        <DispId(10)>
        Overloads Property IcmpTypesAndCodes As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the direction of traffic for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. If this property Is Not specified, the default value Is <c>in</c>.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(11)>
        Overloads Property Direction As NET_FW_RULE_DIRECTION

        ''' <summary>
        ''' <para>Specifies the list of interfaces for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. The interfaces in the list are represented by their friendly name.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(12)>
        Overloads Property Interfaces As <MarshalAs(UnmanagedType.Struct)> Object

        ''' <summary>
        ''' <para>Specifies the list of interface types for which the rule applies.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' Acceptable values for this property are "RemoteAccess", "Wireless", "Lan", And "All". If more than one interface type Is
        ''' specified, the strings must be separated by a comma.
        ''' </para>
        ''' </remarks>
        <DispId(13)>
        Overloads Property InterfaceTypes As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Enables Or disables a rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional. A New rule Is disabled by default.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(14)>
        Overloads Property Enabled As Boolean

        ''' <summary>
        ''' <para>Specifies the group to which an individual rule belongs.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' <para>
        ''' Using the Grouping property Is highly recommended, as it groups multiple rules into a single line in the Windows Firewall
        ''' control panel. This allows the user to enable Or disable multiple rules with a single click. The Grouping property can also be
        ''' specified using indirect strings. In this case, a group description can also be specified that will appear in the rule group
        ''' properties in the Windows Firewall control panel. For example, if the group string Is specified by an indirect string at index
        ''' 1005 ("@yourresources.dll,-1005"), the group description can be specified at a resource string higher by 10000 "@youresources.dll,-11005."
        ''' </para>
        ''' <para>
        ''' When indirect strings in the form of "h" are passed as parameters to the Windows Firewall with Advanced Security APIs, they
        ''' should either be placed under the System32 Windows directory Or specified by a full path. Further, the file should have a secure
        ''' access that permits the Local Service account read access to allow the Windows Firewall Service to read the strings. To avoid
        ''' non-privileged security principals from modifying the strings, the DLLs should only allow write access to the Administrator account.
        ''' </para>
        ''' </remarks>
        <DispId(15)>
        Overloads Property Grouping As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the profiles to which the rule belongs.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H10)>
        Overloads Property Profiles As NET_FW_PROFILE_TYPE2

        ''' <summary>
        ''' <para>Indicates whether edge traversal Is enabled Or disabled for this rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>
        ''' The EdgeTraversal property indicates that specific inbound traffic Is allowed to tunnel through NATs And other edge devices
        ''' using the Teredo tunneling technology. In order for this setting to work correctly, the application Or service with the inbound
        ''' firewall rule needs to support IPv6. The primary application of this setting allows listeners on the host to be globally
        ''' addressable through a Teredo IPv6 address.
        ''' </para>
        ''' <para>New rules have the EdgeTraversal property disabled by default.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H11)>
        Overloads Property EdgeTraversal As Boolean

        ''' <summary>
        ''' <para>Specifies the action for a rule Or default setting.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>This property Is optional.</para>
        ''' <para>Also see the restrictions on changing properties described in the Remarks section of the INetFwRule interface page.</para>
        ''' </remarks>
        <DispId(&H12)>
        Overloads Property Action As NET_FW_ACTION

        ''' <summary>
        ''' <para>This property can be used to access the edge properties of a firewall rule defined by NET_FW_EDGE_TRAVERSAL_TYPE.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(&H13)>
        Overloads Property EdgeTraversalOptions As NET_FW_EDGE_TRAVERSAL_TYPE

        ''' <summary>
        ''' <para>
        ''' Specifies the package identifier Or the app container identifier of a process, whether from a Windows Store app Or a desktop app.
        ''' </para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(20)>
        Property LocalAppPackageId As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies the user security identifier (SID) of the user who Is the owner of the rule.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' If this rule does Not specify <c>localUserConditions</c>, all the traffic that this rule matches must be destined to Or
        ''' originated from this user.
        ''' </remarks>
        <DispId(&H15)>
        Property LocalUserOwner As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies a list of authorized local users for an app container.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(&H16)>
        Property LocalUserAuthorizedList As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies a list of remote users who are authorized to access an app container.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(&H17)>
        Property RemoteUserAuthorizedList As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>Specifies a list of remote computers which are authorized to access an app container.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(&H18)>
        Property RemoteMachineAuthorizedList As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' Specifies which firewall verifications of security levels provided by IPsec must be guaranteed to allow the collection. The
        ''' allowed values must correspond to those of the NET_FW_AUTHENTICATE_TYPE enumeration.
        ''' </para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(&H19)>
        Property SecureFlags As NET_FW_AUTHENTICATE_TYPE

    End Interface

    ''' <summary>Gets the string array from the Interfaces property.</summary>
    ''' <param name="rule">The rule.</param>
    ''' <returns>A string array with zero or more elements.</returns>
    <Extension()>
    Public Function GetInterfaces(rule As INetFwRule) As String()
        Return If(rule.Interfaces Is Nothing, New String(-1) {}, Array.ConvertAll(CType(rule.Interfaces, Object()), Function(o) o.ToString()))
    End Function

    ''' <summary>The <c>INetFwRules</c> interface provides a collection of firewall rules.</summary>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwRules")>
    <ComImport, Guid("9C4C6277-5027-441E-AFAE-CA1F542DA009")>
    Public Interface INetFwRules
        Inherits IEnumerable

        ''' <summary>
        ''' <para>Returns the number of rules in a collection.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property Count As Integer

        ''' <summary>The <c>Add</c> method adds a New rule to the collection.</summary>
        ''' <param name="rule">Rule to be added to the collection via an INetFwRule object.</param>
        ''' <remarks>
        ''' <para>If a rule with the same rule identifier as the one being submitted already exists, the existing rule Is overwritten.</para>
        ''' <para>Adding a firewall rule with a LocalAppPackageId specified can lead to unexpected behavior And Is Not supported.</para>
        ''' </remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Sub Add(<[In], MarshalAs(UnmanagedType.Interface)> ByVal rule As INetFwRule)

        ''' <summary>The <c>Remove</c> method removes a rule from the collection.</summary>
        ''' <param name="name">Name of the rule to remove from the collection.</param>
        ''' <remarks>If a rule specified by the name parameter does Not exist in the collection, the <c>Remove</c> method has no effect.</remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(3)>
        Sub Remove(<[In], MarshalAs(UnmanagedType.BStr)> ByVal Name As String)

        ''' <summary>The <c>Item</c> method returns the specified rule if it Is in the collection.</summary>
        ''' <param name="name">Name of the rule to retrieve.</param>
        ''' <returns>Reference to the returned INetFwRule object.</returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(4)>
        Function Item(<[In], MarshalAs(UnmanagedType.BStr)> ByVal Name As String) As <MarshalAs(UnmanagedType.Interface)> INetFwRule

        ''' <summary>
        ''' <para>Returns an object supporting <c>IEnumVARIANT</c> that can be used to iterate through all the rules in the collection.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Overloads Function GetEnumerator() As <MarshalAs(UnmanagedType.CustomMarshaler, MarshalType:="", MarshalTypeRef:=GetType(EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> IEnumerator

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>
    ''' The <c>INetFwService</c> interface provides access to the properties of a service that may be authorized to listen through the firewall.
    ''' </para>
    ''' </summary>
    ''' <remarks>
    ''' <para>Instances of this interface are retrieved through the INetFwServices collection.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwService")>
    <ComImport, Guid("79FD57C8-908E-4A36-9888-D5B3F0A444CF")>
    Public Interface INetFwService

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the friendly name of the service.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property Name As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the type of the service.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(2)>
        ReadOnly Property Type As NET_FW_SERVICE_TYPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether at least one of the ports associated with the service has been customized.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        ''' <remarks>
        ''' If a service has been customized, the values returned by the service properties do Not reflect the configuration of all the
        ''' ports associated with the service.
        ''' </remarks>
        <DispId(3)>
        ReadOnly Property Customized As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies the firewall IP version for which the service Is authorized.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>Only <c>NET_FW_IP_VERSION_ANY</c> Is supported.</remarks>
        <DispId(4)>
        Property IpVersion As NET_FW_IP_VERSION

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Controls the network scope from which the port can listen.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>When setting the Scope property, only <c>NET_FW_SCOPE_ALL</c> And <c>NET_FW_SCOPE_LOCAL_SUBNET</c> are valid.</para>
        ''' <para>The default value Is <c>NET_FW_SCOPE_ALL</c> for New ports.</para>
        ''' <para>To create a custom scope, use the RemoteAddresses property.</para>
        ''' </remarks>
        <DispId(5)>
        Property Scope As NET_FW_SCOPE

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Specifies a set of the remote addresses from which the service ports can listen for traffic.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        ''' <remarks>
        ''' <para>If the service has been customized, get returns the union of the remote addresses for all the service ports.</para>
        ''' <para>
        ''' The remoteAddrs parameter consists of one Or more comma-delimited tokens specifying the remote addresses from which the
        ''' application can listen for traffic. The default value Is "*".
        ''' </para>
        ''' <para>Valid tokens:</para>
        ''' <list type="bullet">
        ''' <item>
        ''' <term>"*": any remote address; If present, it must be the only token.</term>
        ''' </item>
        ''' <item>
        ''' <term>"LocalSubnet": Not case-sensitive; specifying more than once has no effect.</term>
        ''' </item>
        ''' <item>
        ''' <term>
        ''' subnet: may be specified Using either subnet mask Or network prefix notation. If neither a subnet mask nor a network prefix Is
        ''' specified, the subnet mask defaults to 255.255.255.255. Examples of valid subnets: 10.0.0.2/255.0.0.0 10.0.0.2/8 10.0.0.2
        ''' </term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: A valid IPv6 address.</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv4 address range In the format "start address - end address."</term>
        ''' </item>
        ''' <item>
        ''' <term>Windows Vista: An IPv6 address range In the format "start address - end address."</term>
        ''' </item>
        ''' </list>
        ''' <para>For a predefined address range, use the Scope property.</para>
        ''' </remarks>
        <DispId(6)>
        Property RemoteAddresses As <MarshalAs(UnmanagedType.BStr)> String

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Indicates whether all the ports associated with the service are enabled.</para>
        ''' <para>This property Is read/write.</para>
        ''' </summary>
        <DispId(7)>
        Property Enabled As Boolean

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves the collection of globally open ports associated with the service.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(8)>
        ReadOnly Property GloballyOpenPorts As <MarshalAs(UnmanagedType.Interface)> INetFwOpenPorts

    End Interface

    ''' <summary>The <c>INetFwServiceRestriction</c> interface provides access to the Windows Service Hardening networking rules.</summary>
    ''' <remarks>When adding rules, note that there may be a small time lag before the newly-added rule Is applied.</remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwServiceRestriction")>
    <ComImport, Guid("8267BBE3-F890-491C-B7B6-2DB1EF0E5D2B")>
    Public Interface INetFwServiceRestriction

        ''' <summary>The <c>RestrictService</c> method turns service restriction on Or off for a given service.</summary>
        ''' <param name="serviceName">Name of the service for which service restriction Is being turned on Or off.</param>
        ''' <param name="appName">Name of the application for which service restriction Is being turned on Or off.</param>
        ''' <param name="restrictService">
        ''' Indicates whether service restriction Is being turned on Or off. If this value Is true ( <c>VARIANT_TRUE</c>), the service will
        ''' be restricted when sending Or receiving network traffic. The Windows Service Hardening rules collection can contain rules which
        ''' can allow this service specific inbound Or outbound network access per specific requirements. If false ( <c>VARIANT_FALSE</c>),
        ''' the service Is Not restricted by Windows Service Hardening.
        ''' </param>
        ''' <param name="serviceSidRestricted">
        ''' Indicates the type of service SID for the specified service. If this value Is true ( <c>VARIANT_TRUE</c>), the service SID will
        ''' be restricted. Otherwise, it will be unrestricted.
        ''' </param>
        ''' <remarks>When adding rules, note that there may be a small time lag before the newly-added rule Is applied.</remarks>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(1)>
        Sub RestrictService(<[In], MarshalAs(UnmanagedType.BStr)> ByVal serviceName As String, <[In], MarshalAs(UnmanagedType.BStr)> ByVal appName As String, <[In]> ByVal RestrictService As Boolean, <[In]> ByVal serviceSidRestricted As Boolean)

        ''' <summary>
        ''' The <c>ServiceRestricted</c> method indicates whether service restriction rules are enabled to limit traffic to the resources
        ''' specified by the firewall rules.
        ''' </summary>
        ''' <param name="serviceName">Name of the service being queried concerning service restriction state.</param>
        ''' <param name="appName">Name of the application being queried concerning service restriction state.</param>
        ''' <returns>
        ''' Indicates whether service restriction rules are in place to restrict the specified service. If true ( <c>VARIANT_TRUE</c>),
        ''' service Is restricted. Otherwise, service Is Not restricted to the resources specified by firewall rules.
        ''' </returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Function ServiceRestricted(<[In], MarshalAs(UnmanagedType.BStr)> ByVal serviceName As String, <[In], MarshalAs(UnmanagedType.BStr)> ByVal appName As String) As Boolean

        ''' <summary>
        ''' <para>Retrieves the collection of Windows Service Hardening networking rules.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(3)>
        ReadOnly Property Rules As <MarshalAs(UnmanagedType.Interface)> INetFwRules

    End Interface

    ''' <summary>
    ''' <para>
    ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered Or
    ''' unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
    ''' </para>
    ''' <para>
    ''' The <c>INetFwServices</c> interface Is a standard Automation interface which provides access to a collection of services that may be
    ''' authorized to listen through the firewall.
    ''' </para>
    ''' </summary>
    ''' <remarks>
    ''' <para>An instance of this interface Is retrieved through the Services property of the INetFwProfile interface.</para>
    ''' <para>All configuration changes take effect immediately.</para>
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NN:netfw.INetFwServices")>
    <ComImport, Guid("79649BB4-903E-421B-94C9-79848E79F6EE")>
    Public Interface INetFwServices
        Inherits IEnumerable

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Retrieves a read-only element yielding the number of items in the collection.</para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <DispId(1)>
        ReadOnly Property Count As Integer

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Returns the specified service if it Is in the collection.</para>
        ''' </summary>
        ''' <param name="svcType">
        ''' <list type="table">
        ''' <listheader>
        ''' <term>C++</term>
        ''' <term>Type of service to fetch.</term>
        ''' </listheader>
        ''' <item>
        ''' <term>VB</term>
        ''' <term>Type of service to fetch. See NET_FW_SERVICE_TYPE</term>
        ''' </item>
        ''' </list>
        ''' </param>
        ''' <returns>Reference to the returned INetFwService object.</returns>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), DispId(2)>
        Function Item(<[In]> ByVal svcType As NET_FW_SERVICE_TYPE) As <MarshalAs(UnmanagedType.Interface)> INetFwService

        ''' <summary>
        ''' <para>
        ''' [The Windows Firewall API Is available for use in the operating systems specified in the Requirements section. It may be altered
        ''' Or unavailable in subsequent versions. For Windows Vista And later, use of the Windows Firewall with Advanced Security API Is recommended.]
        ''' </para>
        ''' <para>Returns an object supporting <c>IEnumVARIANT</c> that can be used to iterate through all the services in the collection.</para>
        ''' <para>
        ''' Iteration through a collection Is done using the <c>for each</c> construct in VBScript. See Iterating a Collection for an example.
        ''' </para>
        ''' <para>This property Is read-only.</para>
        ''' </summary>
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Overloads Function GetEnumerator() As <MarshalAs(UnmanagedType.CustomMarshaler, MarshalType:="", MarshalTypeRef:=GetType(EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> IEnumerator

    End Interface

    ''' <summary>CoClass for <see cref="INetFwAuthorizedApplication"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("EC9846B3-2762-4A6B-A214-6ACB603462D2"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwAuthorizedApplication
    End Class

    ''' <summary>CoClass for <see cref="INetFwMgr"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("304CE942-6E39-40D8-943A-B913C40C9CD4"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwMgr
    End Class

    ''' <summary>CoClass for <see cref="INetFwOpenPort"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("0CA545C6-37AD-4A6C-BF92-9F7610067EF5"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwOpenPort
    End Class

    ''' <summary>CoClass for <see cref="INetFwPolicy2"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("E2B3C97F-6AE1-41AC-817A-F6F92166D7DD"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwPolicy2
    End Class

    ''' <summary>CoClass for <see cref="INetFwProduct"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("9D745ED8-C514-4D1D-BF42-751FED2D5AC7"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwProduct
    End Class

    ''' <summary>CoClass for <see cref="INetFwProducts"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("CC19079B-8272-4D73-BB70-CDB533527B61"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwProducts
    End Class

    ''' <summary>CoClass for <see cref="INetfwRule"/>.</summary>
    <PInvokeData("netfw.h")>
    <ComImport, Guid("2C5BC43E-3369-4C33-AB0C-BE9469677AF4"), ClassInterface(ClassInterfaceType.None)>
    Public Class NetFwRule
    End Class

End Module