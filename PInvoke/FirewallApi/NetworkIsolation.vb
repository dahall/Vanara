Imports System
Imports System.Runtime.InteropServices

Partial Public Module FirewallApi

    ''' <summary>The <c>INET_FIREWALL_AC_CHANGE_TYPE</c> enumeration specifies which type of app container change occurred.</summary>
    <PInvokeData("networkisolation.h", MSDNShortId:="NE:networkisolation._INET_FIREWALL_AC_CHANGE_TYPE")>
    Public Enum INET_FIREWALL_AC_CHANGE_TYPE

        ''' <summary>This value is reserved for system use.</summary>
        INET_FIREWALL_AC_CHANGE_INVALID

        ''' <summary>An app container was created.</summary>
        INET_FIREWALL_AC_CHANGE_CREATE

        ''' <summary>An app container was deleted.</summary>
        INET_FIREWALL_AC_CHANGE_DELETE

        ''' <summary>Maximum value for testing purposes.</summary>
        INET_FIREWALL_AC_CHANGE_MAX

    End Enum

    ''' <summary>
    ''' The <c>NetworkIsolationDiagnoseConnectFailureAndGetInfo</c> function gets information about a network isolation connection failure
    ''' due to a missing capability. This function can be used to identify the capabilities required to connect to a server.
    ''' </summary>
    ''' <param name="wszServerName">
    ''' <para>Type: <c>LPCWSTR</c></para>
    ''' <para>Name (or IP address literal string) of the server to which a connection was attempted.</para>
    ''' </param>
    ''' <param name="netIsoError">
    ''' <para>Type: <c>NETISO_ERROR_TYPE*</c></para>
    ''' <para>The error that has occurred, indicating which network capability was missing and thus caused the failure.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' </returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("networkisolation.h", MSDNShortId:="NF:networkisolation.NetworkIsolationDiagnoseConnectFailureAndGetInfo")>
    Public Function NetworkIsolationDiagnoseConnectFailureAndGetInfo(
    <MarshalAs(UnmanagedType.LPWStr)> ByVal wszServerName As String, <Out> ByRef netIsoError As NETISO_ERROR_TYPE) As Win32Error
    End Function

    ''' <summary>
    ''' The <c>NetworkIsolationFreeAppContainers</c> function is used to release memory resources allocated to one or more app containers
    ''' </summary>
    ''' <param name="pPublicAppCs">
    ''' <para>Type: <c>PINET_FIREWALL_APP_CONTAINER</c></para>
    ''' <para>The app container memory resources to be freed.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' </returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("networkisolation.h", MSDNShortId:="NF:networkisolation.NetworkIsolationFreeAppContainers")>
    Public Function NetworkIsolationFreeAppContainers(
    <[In]> ByVal pPublicAppCs As IntPtr) As Win32Error
    End Function

    ''' <summary>
    ''' The <c>NetworkIsolationGetAppContainerConfig</c> function is used to retrieve configuration information about one or more app containers.
    ''' </summary>
    ''' <param name="pdwNumPublicAppCs">
    ''' <para>Type: <c>DWORD*</c></para>
    ''' <para>The number of app containers in the <c>appContainerSids</c> member.</para>
    ''' </param>
    ''' <param name="appContainerSids">
    ''' <para>Type: <c>PSID_AND_ATTRIBUTES*</c></para>
    ''' <para>The security identifiers (SIDs) of app containers that are allowed to send loopback traffic. Used for debugging purposes.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' </returns>
    ''' <remarks>
    ''' <para>
    ''' Note that it is the calling program's responsibility to free the memory associated with the PSID_AND_ATTRIBUTES structure. The
    ''' following code sample shows how to call this function. The FreeAppContainerConfig function shows how to free all of the associated memory.
    ''' </para>
    ''' <para>
    ''' <code> #include "stdafx.h" #include &lt;netfw.h&gt; typedef DWORD (WINAPI *FN_NETWORKISOLATIONGETAPPCONTAINERCONFIG)( _Out_ DWORD *pdwNumPublicAppCs, _Outptr_result_buffer_(*pdwNumPublicAppCs) PSID_AND_ATTRIBUTES *appContainerSids ); void FreeAppContainerConfig( __in DWORD sidCount, __in_ecount(sidCount) SID_AND_ATTRIBUTES *srcSidAttrib ) { DWORD dwIndex = 0; for (dwIndex = 0; dwIndex &lt; sidCount; dwIndex++) { HeapFree(GetProcessHeap(), 0, srcSidAttrib[dwIndex].Sid); } HeapFree(GetProcessHeap(), 0, srcSidAttrib); } int _tmain(int argc, _TCHAR* argv[]) { DWORD dwErr = 0; PSID_AND_ATTRIBUTES appContainerSids = NULL; DWORD dwCount = 0; HMODULE hModule = NULL; FN_NETWORKISOLATIONGETAPPCONTAINERCONFIG pfnNetworkIsolationGetAppContainerConfig = NULL; hModule = LoadLibraryW(L"FirewallAPI.dll"); if (hModule == NULL) { dwErr = GetLastError(); goto Cleanup; } pfnNetworkIsolationGetAppContainerConfig = (FN_NETWORKISOLATIONGETAPPCONTAINERCONFIG)GetProcAddress( hModule, "NetworkIsolationGetAppContainerConfig" ); if (pfnNetworkIsolationGetAppContainerConfig == NULL) { dwErr = GetLastError(); goto Cleanup; } dwErr = pfnNetworkIsolationGetAppContainerConfig( &amp;dwCount, &amp;appContainerSids ); if (dwErr != ERROR_SUCCESS) { goto Cleanup; } // Process the app container sids Cleanup: FreeAppContainerConfig( dwCount, appContainerSids ); if (hModule != NULL) { FreeLibrary(hModule); } return 0; }</code>
    ''' </para>
    ''' </remarks>
    <DllImport(Lib_Firewallapi, SetLastError:=True, ExactSpelling:=True)>
    <PInvokeData("networkisolation.h", MSDNShortId:="NF:networkisolation.NetworkIsolationGetAppContainerConfig")>
    Public Function NetworkIsolationGetAppContainerConfig(<Out> ByRef pdwNumPublicAppCs As UInteger, <Out> ByRef appContainerSids As IntPtr) As Win32Error
    End Function

    ''' <summary>
    ''' The <c>NetworkIsolationRegisterForAppContainerChanges</c> function is used to register for the delivery of notifications regarding
    ''' changes to an app container.
    ''' </summary>
    ''' <param name="flags">
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>A bitmask value of control flags which specify when to receive notifications. May contain one or more of the following flags.</para>
    ''' <list type="table">
    ''' <listheader>
    ''' <term>Value</term>
    ''' <term>Meaning</term>
    ''' </listheader>
    ''' <item>
    ''' <term>INET_FIREWALL_AC_NONE 0x00</term>
    ''' <term>No notifications will be delivered.</term>
    ''' </item>
    ''' <item>
    ''' <term>INET_FIREWALL_AC_PACKAGE_ID_ONLY 0x01</term>
    ''' <term>Notifications will be delivered when an app container is created with a package identifier.</term>
    ''' </item>
    ''' <item>
    ''' <term>INET_FIREWALL_AC_BINARY 0x02</term>
    ''' <term>Notifications will be delivered when an app container is created with a binary path.</term>
    ''' </item>
    ''' <item>
    ''' <term>INET_FIREWALL_AC_MAX 0x04</term>
    ''' <term>Maximum value for testing purposes.</term>
    ''' </item>
    ''' </list>
    ''' </param>
    ''' <param name="callback">
    ''' <para>Type: <c>PAC_CHANGES_CALLBACK_FN</c></para>
    ''' <para>Function pointer that will be invoked when a notification is ready for delivery.</para>
    ''' </param>
    ''' <param name="context">
    ''' <para>Type: <c>PVOID</c></para>
    ''' <para>Optional context pointer. This pointer is passed to the callback function along with details of the change.</para>
    ''' </param>
    ''' <param name="registrationObject">
    ''' <para>Type: <c>HANDLE*</c></para>
    ''' <para>Handle to the newly created registration.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' </returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("networkisolation.h", MSDNShortId:="NF:networkisolation.NetworkIsolationRegisterForAppContainerChanges")>
    Public Function NetworkIsolationRegisterForAppContainerChanges(ByVal flags As INET_FIREWALL_AC_CREATION_TYPE, ByVal callback As PAC_CHANGES_CALLBACK_FN,
    <[In], [Optional]> ByVal context As IntPtr, <Out> ByRef registrationObject As HANDLE) As Win32Error
    End Function

    ''' <summary>
    ''' The <c>NetworkIsolationUnregisterForAppContainerChanges</c> function is used to cancel an app container change registration and stop
    ''' receiving notifications.
    ''' </summary>
    ''' <param name="registrationObject">
    ''' <para>Type: <c>HANDLE</c></para>
    ''' <para>Handle to the previously created registration.</para>
    ''' </param>
    ''' <returns>
    ''' <para>Type: <c>DWORD</c></para>
    ''' <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
    ''' </returns>
    <DllImport(Lib_Firewallapi, SetLastError:=False, ExactSpelling:=True)>
    <PInvokeData("networkisolation.h", MSDNShortId:="NF:networkisolation.NetworkIsolationUnregisterForAppContainerChanges")>
    Public Function NetworkIsolationUnregisterForAppContainerChanges(ByVal registrationObject As HANDLE) As Win32Error
    End Function

    ''' <summary>The <c>INET_FIREWALL_AC_CAPABILITIES</c> structure contains information about the capabilities of an app container.</summary>
    <PInvokeData("networkisolation.h", MSDNShortId:="NS:networkisolation._INET_FIREWALL_AC_CAPABILITIES")>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure INET_FIREWALL_AC_CAPABILITIES

        ''' <summary>
        ''' <para>Type: <c>DWORD</c></para>
        ''' <para>The number of security identifiers (SIDs) in the <c>capabilities</c> member.</para>
        ''' </summary>
        Public count As UInteger

        ''' <summary>
        ''' <para>Type: <c>SID_AND_ATTRIBUTES*</c></para>
        ''' <para>Security information related to the app container's capabilities.</para>
        ''' </summary>
        Public capabilities As IntPtr

    End Structure

    ''' <summary>The <c>INET_FIREWALL_APP_CONTAINER</c> structure contains information about an specific app container.</summary>
    <PInvokeData("networkisolation.h", MSDNShortId:="NS:networkisolation._INET_FIREWALL_APP_CONTAINER")>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure INET_FIREWALL_APP_CONTAINER

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
        ''' <para>The app container's globally unique name.</para>
        ''' <para>Also referred to as the Package Family Name, for the app container of a Windows Store app.</para>
        ''' </summary>
        <MarshalAs(UnmanagedType.LPWStr)>
        Public appContainerName As String

        ''' <summary>
        ''' <para>Type: <c>LPWSTR</c></para>
        ''' <para>Friendly name of the app container</para>
        ''' </summary>
        <MarshalAs(UnmanagedType.LPWStr)>
        Public displayName As String

        ''' <summary>
        ''' <para>Type: <c>LPWSTR</c></para>
        ''' <para>A description of the app container (its use, the objective of the application that uses it, etc.)</para>
        ''' </summary>
        <MarshalAs(UnmanagedType.LPWStr)>
        Public description As String

        ''' <summary>
        ''' <para>Type: <c>INET_FIREWALL_AC_CAPABILITIES</c></para>
        ''' <para>The capabilities of the app container.</para>
        ''' </summary>
        Public capabilities As INET_FIREWALL_AC_CAPABILITIES

        ''' <summary>
        ''' <para>Type: <c>INET_FIREWALL_AC_BINARIES</c></para>
        ''' <para>Binary paths to the applications running in the app container.</para>
        ''' </summary>
        Public binaries As INET_FIREWALL_AC_BINARIES

        ''' <summary/>
        <MarshalAs(UnmanagedType.LPWStr)>
        Public workingDirectory As String

        ''' <summary/>
        <MarshalAs(UnmanagedType.LPWStr)>
        Public packageFullName As String

    End Structure

End Module