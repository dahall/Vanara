Imports System
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.CustomMarshalers

Partial Public Module FirewallApi

    Friend Const Lib_Firewallapi As String = "firewallapi.dll"

    ''' <summary>
    ''' The <c>PAC_CHANGES_CALLBACK_FN</c> function is used to add custom behavior to the app container change notification process.
    ''' </summary>
    ''' <param name="context">TOptional context pointer.</param>
    ''' <param name="pChange"/>
    ''' <remarks>Call NetworkIsolationRegisterForAppContainerChanges to register this callback function.</remarks>
    <UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet:=CharSet.Unicode)>
    <PInvokeData("netfw.h", MSDNShortId:="NC:netfw.PAC_CHANGES_CALLBACK_FN")>
    Public Delegate Sub PAC_CHANGES_CALLBACK_FN(<[In], Out, [Optional]> ByVal context As IntPtr, <[In]> ByRef pChange As INET_FIREWALL_AC_CHANGE)

    ''' <summary>Callback used by <see cref="NetworkIsolationGetEnterpriseIdAsync"/>.</summary>
    ''' <param name="context">TOptional context pointer.</param>
    ''' <param name="wszEnterpriseId">The WSZ enterprise identifier.</param>
    ''' <param name="dwErr">The dw error.</param>
    <UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet:=CharSet.Unicode)>
    <PInvokeData("netfw.h", MSDNShortId:="NC:netfw.PAC_CHANGES_CALLBACK_FN")>
    Public Delegate Sub PNETISO_EDP_ID_CALLBACK_FN(<[In], Out, [Optional]> ByVal context As IntPtr, <[In], [Optional], MarshalAs(UnmanagedType.LPWStr)> ByVal wszEnterpriseId As String, ByVal dwErr As Win32Error)

    ''' <summary>
    ''' The <c>INET_FIREWALL_AC_CREATION_TYPE</c> enumeration specifies the type of app container creation events for which notifications
    ''' will be delivered.
    ''' </summary>
    <PInvokeData("netfw.h", MSDNShortId:="NE:netfw._INET_FIREWALL_AC_CREATION_TYPE")>
    <Flags>
    Public Enum INET_FIREWALL_AC_CREATION_TYPE

        ''' <summary>This value is reserved for system use.</summary>
        INET_FIREWALL_AC_NONE = &H0

        ''' <summary>Notifications will be delivered when an app container is created with a package identifier.</summary>
        INET_FIREWALL_AC_PACKAGE_ID_ONLY = &H1

        ''' <summary>Notifications will be delivered when an app container is created with a binary path.</summary>
        INET_FIREWALL_AC_BINARY = &H2

        ''' <summary>Maximum value for testing purposes.</summary>
        INET_FIREWALL_AC_MAX = &H4

    End Enum

    ''' <summary>The <c>NETISO_ERROR_TYPE</c> enumerated type specifies the type of error related to a network isolation operation.</summary>
    <PInvokeData("netfw.h", MSDNShortId:="NE:netfw._NETISO_ERROR_TYPE")>
    Public Enum NETISO_ERROR_TYPE

        ''' <summary>No error.</summary>
        NETISO_ERROR_TYPE_NONE

        ''' <summary>The failure was caused because the privateNetworkClientServer capability is missing.</summary>
        NETISO_ERROR_TYPE_PRIVATE_NETWORK

        ''' <summary>The failure was caused because the internetClient capability is missing.</summary>
        NETISO_ERROR_TYPE_INTERNET_CLIENT

        ''' <summary>The failure was caused because the internetClientServer capability is missing.</summary>
        NETISO_ERROR_TYPE_INTERNET_CLIENT_SERVER

        ''' <summary>Maximum value for testing purposes.</summary>
        NETISO_ERROR_TYPE_MAX

    End Enum

    ''' <summary>The <c>NETISO_FLAG</c> enumerated type specifies whether binaries should be returned for app containers.</summary>
    ''' <remarks>
    ''' By default, binaries are not returned. <c>NETISO_FLAG_FORCE_COMPUTE_BINARIES</c> must be set in order for these to be returned.
    ''' </remarks>
    <PInvokeData("netfw.h", MSDNShortId:="NE:netfw.NETISO_FLAG")>
    <Flags>
    Public Enum NETISO_FLAG

        ''' <summary>
        ''' Specifies that all binaries will be computed before the app container is returned.This flag should be set if the caller requires
        ''' up-to-date and complete information on app container binaries. If this flag is not set, returned data may be stale or incomplete.
        ''' </summary>
        NETISO_FLAG_FORCE_COMPUTE_BINARIES = &H1

        ''' <summary>Maximum value for testing purposes.</summary>
        NETISO_FLAG_MAX = &H2

    End Enum

    ''' <summary>A bitmask value of control flags which specify the context of <see cref="NetworkIsolationGetEnterpriseIdAsync"/>.</summary>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationGetEnterpriseIdAsync")>
    Public Enum NETISO_GEID

        ''' <summary>
        ''' Default API behavior. Returns the Enterprise ID for Enterprise resources. Returns NULL for Personal resources. For Neutral
        ''' resources, returns Enterprise ID if it is called from an Enterprise context, or returns NULL if it is called from a Personal context.
        ''' </summary>
        NETISO_GEID_DEFAULT = &H0

        ''' <summary>Used in the context of the Windows Defender Application Guard (WDAG) scenario.</summary>
        NETISO_GEID_FOR_WDAG = &H1

        ''' <summary>
        ''' Used by applications that are aware of neutral resources. For Neutral resources the API will return L”*”. For Enterprise
        ''' resources the API will return the Enterprise ID. For Personal resources the API will return NULL.
        ''' </summary>
        NETISO_GEID_FOR_NEUTRAL_AWARE = &H2

        ''' <summary>
        ''' Forces API to check the resource even in cases when neither Windows Information Protection nor Windows Defender Application
        ''' Guard are enabled.
        ''' </summary>
        NETISO_GEID_FORCE_TO_CHECK = &H4

    End Enum

    ''' <summary>
    ''' The <c>NetworkIsolationEnumAppContainers</c> function enumerates all of the app containers that have been created in the system.
    ''' </summary>
    ''' <param name="Flags">
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>
    ''' May be set to <c>NETISO_FLAG_FORCE_COMPUTE_BINARIES</c> to ensure that all binaries are computed before the app container is
    ''' returned. This flag should be set if the caller requires up-to-date and complete information on app container binaries. If this flag
    ''' is not set, returned data may be stale or incomplete.
    ''' </para>
    ''' <para>See NETISO_FLAG for more information.</para>
    ''' </param>
    ''' <param name="pdwNumPublicAppCs">
    ''' <para>Type: <c>DWORD*</c></para>
    ''' <para>The number of app containers in the <c>ppPublicAppCs</c> member.</para>
    ''' </param>
    ''' <param name="ppPublicAppCs">
    ''' <para>Type: <c>PINET_FIREWALL_APP_CONTAINER*</c></para>
    ''' <para>The list of app container structure elements.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' <para>ERROR_OUTOFMEMORY will be returned if memory is unavailable.</para>
    ''' </returns>
    ''' <remarks>If no app containers are installed on the system, ERROR_SUCCESS will still be returned (and ppPublicAppCs will be empty).</remarks>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationEnumAppContainers")>
    Public Function NetworkIsolationEnumAppContainers(ByVal Flags As NETISO_FLAG, <Out> ByRef pdwNumPublicAppCs As UInteger, <Out> ByRef ppPublicAppCs As IntPtr) As Win32Error
    End Function

    ''' <summary>The <c>NetworkIsolationEnumerateAppContainerRules</c> function enumerates all of the rules related to app containers.</summary>
    ''' <param name="newEnum">
    ''' <para>Type: <c>IEnumVARIANT**</c></para>
    ''' <para>Enumerator interface of an INetFwRule3 object that represents the rules enforcing app containers.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>HRESULT</c></para>
    ''' <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
    ''' </returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationEnumerateAppContainerRules")>
    Public Function NetworkIsolationEnumerateAppContainerRules(<Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef:=GetType(EnumeratorToEnumVariantMarshaler), MarshalCookie:="")> ByRef newEnum As IEnumerable) As HRESULT
    End Function

    ''' <summary>
    ''' <para>
    ''' Gets the Enterprise ID based on Network Isolation endpoints in the context of the Windows Information Protection (WIP) or the
    ''' Windows Defender Application Guard (WDAG) scenarios. If neither WIP nor WDAG are on, the API returns NULL, unless the flag
    ''' <c>NETISO_GEID_FORCE_TO_CHECK</c> is passed. The Enterprise ID can be any string different from NULL or “*”.
    ''' </para>
    ''' <para>Example of NetworkIsolationGetEnterpriseIdAsync usage: https://github.com/microsoft/EnterpriseStateClassify</para>
    ''' </summary>
    ''' <param name="wszServerName">The name of the Enterprise Data Protection Server.</param>
    ''' <param name="dwFlags">
    ''' <para>A bitmask value of control flags which specify the context of the API call. May contain one or more of the following flags.</para>
    ''' <list type="table">
    ''' <listheader>
    ''' <term>Value</term>
    ''' <term>Meaning</term>
    ''' </listheader>
    ''' <item>
    ''' <term>NETISO_GEID_DEFAULT 0x00</term>
    ''' <term>
    ''' Default API behavior. Returns the Enterprise ID for Enterprise resources. Returns NULL for Personal resources. For Neutral
    ''' resources, returns Enterprise ID if it is called from an Enterprise context, or returns NULL if it is called from a Personal context.
    ''' </term>
    ''' </item>
    ''' <item>
    ''' <term>NETISO_GEID_FOR_WDAG 0x01</term>
    ''' <term>Used in the context of the Windows Defender Application Guard (WDAG) scenario.</term>
    ''' </item>
    ''' <item>
    ''' <term>NETISO_GEID_FOR_NEUTRAL_AWARE 0x02</term>
    ''' <term>
    ''' Used by applications that are aware of neutral resources. For Neutral resources the API will return L”*”. For Enterprise resources
    ''' the API will return the Enterprise ID. For Personal resources the API will return NULL.
    ''' </term>
    ''' </item>
    ''' <item>
    ''' <term>NETISO_GEID_FORCE_TO_CHECK 0x04</term>
    ''' <term>
    ''' Forces API to check the resource even in cases when neither Windows Information Protection nor Windows Defender Application Guard
    ''' are enabled.
    ''' </term>
    ''' </item>
    ''' </list>
    ''' </param>
    ''' <param name="context">Optional context pointer.</param>
    ''' <param name="callback">Function pointer that will be invoked when a notification is ready for delivery.</param>
    ''' <param name="hOperation">The handle for the Enterprise Data Protection Server endpoints.</param>
    ''' <returns>Returns ERROR_SUCCESS if successful, or an error value otherwise.</returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationGetEnterpriseIdAsync")>
    Public Function NetworkIsolationGetEnterpriseIdAsync(<MarshalAs(UnmanagedType.LPWStr)> ByVal wszServerName As String, ByVal dwFlags As NETISO_GEID,
        <[In], [Optional]> ByVal context As IntPtr, ByVal callback As PNETISO_EDP_ID_CALLBACK_FN, <Out> ByRef hOperation As HANDLE) As Win32Error
    End Function

    ''' <summary>
    ''' <para>
    ''' This API is used for closing the handle returned by NetworkIsolationGetEnterpriseIdAsync as well as for synchronizing the operation.
    ''' </para>
    ''' <para>Example of NetworkIsolationGetEnterpriseIdClose usage: https://github.com/microsoft/EnterpriseStateClassify</para>
    ''' </summary>
    ''' <param name="hOperation">The handle to release.</param>
    ''' <param name="bWaitForOperation">Indicates whether to wait for synchronization.</param>
    ''' <returns>Returns ERROR_SUCCESS if successful, or an error value otherwise.</returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationGetEnterpriseIdClose")>
    Public Function NetworkIsolationGetEnterpriseIdClose(ByVal hOperation As HANDLE, <MarshalAs(UnmanagedType.Bool)> ByVal bWaitForOperation As Boolean) As Win32Error
    End Function

    ''' <summary>The <c>NetworkIsolationSetAppContainerConfig</c> function is used to set the configuration of one or more app containers.</summary>
    ''' <param name="dwNumPublicAppCs">
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>The number of app containers in the <c>appContainerSids</c> member.</para>
    ''' </param>
    ''' <param name="appContainerSids">
    ''' <para>Type: <c>PSID_AND_ATTRIBUTES</c></para>
    ''' <para>The security identifiers (SIDs) of app containers that are allowed to send loopback traffic. Used for debugging purposes.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' </returns>
    ''' <remarks>
    ''' Note that it is the calling program's responsibility to first call the <c>NetworkIsolationGetAppContainerConfig</c> function in
    ''' order to retrieve and preserve the app container SIDs already configured to send loopback traffic.
    ''' </remarks>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationSetAppContainerConfig")>
    Public Function NetworkIsolationSetAppContainerConfig(ByVal dwNumPublicAppCs As UInteger, <[In]> ByVal appContainerSids As IntPtr) As Win32Error
    End Function

    ''' <summary>
    ''' The <c>NetworkIsolationSetupAppContainerBinaries</c> function is used by software installers to provide information about the image
    ''' paths of applications that are running in an app container. This information is provided to third-party firewall applications about
    ''' the applications in order to enhance user experience and security decisions.
    ''' </summary>
    ''' <param name="applicationContainerSid">
    ''' <para>Type: <c>PSID</c></para>
    ''' <para>The package identifier of the app container.</para>
    ''' </param>
    ''' <param name="packageFullName">
    ''' <para>Type: <c>LPCWSTR</c></para>
    ''' <para>
    ''' A string representing the package identity of the app that owns this app container. Contains the 5-part tuple as individual fields
    ''' (name, version, architecture, resourceid, publisher).
    ''' </para>
    ''' </param>
    ''' <param name="packageFolder">
    ''' <para>Type: <c>LPCWSTR</c></para>
    ''' <para>The file location of the app that owns this app container.</para>
    ''' </param>
    ''' <param name="displayName">
    ''' <para>Type: <c>LPCWSTR</c></para>
    ''' <para>The friendly name of the app container.</para>
    ''' </param>
    ''' <param name="bBinariesFullyComputed">
    ''' <para>Type: <c>BOOL</c></para>
    ''' <para>True if the binary files are being provided by the caller; otherwise, false.</para>
    ''' </param>
    ''' <param name="binaries">
    ''' <para>Type: <c>LPCWSTR*</c></para>
    ''' <para>An array of paths to the applications running in the app container.</para>
    ''' </param>
    ''' <param name="binariesCount">
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>The number of paths contained in the binaries parameter.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>HRESULT</c></para>
    ''' <para>If the function succeeds, it returns S_OK.</para>
    ''' <para>
    ''' If the function fails, it returns an <c>HRESULT</c> value that indicates the error. For a list of common error codes, see Common
    ''' HRESULT Values.
    ''' </para>
    ''' </returns>
    ''' <remarks>
    ''' Applications creating an app container can use <c>NetworkIsolationSetupAppContainerBinaries</c> to provide third-party firewall
    ''' applications with the direct path to applications running inside that app container.
    ''' </remarks>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("netfw.h", MSDNShortId:="NF:netfw.NetworkIsolationSetupAppContainerBinaries")>
    Public Function NetworkIsolationSetupAppContainerBinaries(ByVal applicationContainerSid As PSID, <MarshalAs(UnmanagedType.LPWStr)> ByVal packageFullName As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal packageFolder As String,
        <MarshalAs(UnmanagedType.LPWStr)> ByVal displayName As String,
        <MarshalAs(UnmanagedType.Bool)> ByVal bBinariesFullyComputed As Boolean,
        <[In], MarshalAs(UnmanagedType.LPArray, ArraySubType:=UnmanagedType.LPWStr)> ByVal binaries As String(),
        ByVal binariesCount As UInteger) As HRESULT
    End Function

    ''' <summary>The <c>INET_FIREWALL_AC_BINARIES</c> structure contains the binary paths to applications running in an app container.</summary>
    <PInvokeData("netfw.h", MSDNShortId:="NS:netfw._INET_FIREWALL_AC_BINARIES")>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure INET_FIREWALL_AC_BINARIES

        ''' <summary>The number of paths in the <c>binaries</c> member.</summary>
        Public count As UInteger

        ''' <summary>Paths to the applications running in the app container.</summary>
        Public binaries As IntPtr

    End Structure

    ''' <summary>The INET_FIREWALL_AC_CHANGE structure contains information about a change made to an app container.</summary>
    <PInvokeData("netfw.h", MSDNShortId:="NS:netfw._INET_FIREWALL_AC_CHANGE")>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure INET_FIREWALL_AC_CHANGE

        ''' <summary>
        ''' <para>Type: <c>INET_FIREWALL_AC_CHANGE_TYPE</c></para>
        ''' <para>The type of change made.</para>
        ''' </summary>
        Public changeType As INET_FIREWALL_AC_CHANGE_TYPE

        ''' <summary>
        ''' <para>Type: <c>INET_FIREWALL_AC_CREATION_TYPE</c></para>
        ''' <para>The method by which the app container was created.</para>
        ''' </summary>
        Public createType As INET_FIREWALL_AC_CREATION_TYPE

        ''' <summary>
        ''' <para>Type: <c>SID*</c></para>
        ''' <para>The package identifier of the app container</para>
        ''' </summary>
        Public appContainerSid As PSID

        ''' <summary>
        ''' <para>Type: <c>SID*</c></para>
        ''' <para>The security identifier (SID) of the user to whom the app container belongs.</para>
        ''' </summary>
        Public userSid As PSID

        ''' <summary>
        ''' <para>Type: <c>LPWSTR</c></para>
        ''' <para>Friendly name of the app container.</para>
        ''' </summary>
        <MarshalAs(UnmanagedType.LPWStr)>
        Public displayName As String

        ''' <summary/>
        Public union As UNIONType

        ''' <summary/>
        <StructLayout(LayoutKind.Explicit)>
        Public Structure UNIONType

            ''' <summary>
            ''' <para>Type: <c>INET_FIREWALL_AC_CAPABILITIES</c></para>
            ''' <para>Information about the capabilities of the changed app container.</para>
            ''' </summary>
            <FieldOffset(0)>
            Public capabilities As INET_FIREWALL_AC_CAPABILITIES

            ''' <summary>
            ''' <para>Type: <c>INET_FIREWALL_AC_BINARIES</c></para>
            ''' <para>Binary paths to the applications running in the changed app container.</para>
            ''' </summary>
            <FieldOffset(0)>
            Public binaries As INET_FIREWALL_AC_BINARIES

        End Structure

    End Structure

End Module