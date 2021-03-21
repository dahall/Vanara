using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.CustomMarshalers;

namespace Vanara.PInvoke
{
    public static partial class FirewallApi
    {
        internal const string Lib_Firewallapi = "firewallapi.dll";

        /// <summary>
        /// The <c>PAC_CHANGES_CALLBACK_FN</c> function is used to add custom behavior to the app container change notification process.
        /// </summary>
        /// <param name="context">TOptional context pointer.</param>
        /// <param name="pChange"/>
        /// <remarks>Call NetworkIsolationRegisterForAppContainerChanges to register this callback function.</remarks>
        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        [PInvokeData("netfw.h", MSDNShortId = "NC:netfw.PAC_CHANGES_CALLBACK_FN")]
        public delegate void PAC_CHANGES_CALLBACK_FN([In, Out, Optional] IntPtr context, [In] ref INET_FIREWALL_AC_CHANGE pChange);

        /// <summary>Callback used by <see cref="NetworkIsolationGetEnterpriseIdAsync"/>.</summary>
        /// <param name="context">TOptional context pointer.</param>
        /// <param name="wszEnterpriseId">The WSZ enterprise identifier.</param>
        /// <param name="dwErr">The dw error.</param>
        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
        [PInvokeData("netfw.h", MSDNShortId = "NC:netfw.PAC_CHANGES_CALLBACK_FN")]
        public delegate void PNETISO_EDP_ID_CALLBACK_FN([In, Out, Optional] IntPtr context, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string wszEnterpriseId, Win32Error dwErr);

        /// <summary>
        /// The <c>INET_FIREWALL_AC_CREATION_TYPE</c> enumeration specifies the type of app container creation events for which notifications
        /// will be delivered.
        /// </summary>
        [PInvokeData("netfw.h", MSDNShortId = "NE:netfw._INET_FIREWALL_AC_CREATION_TYPE")]
        [Flags]
        public enum INET_FIREWALL_AC_CREATION_TYPE
        {
            /// <summary>This value is reserved for system use.</summary>
            INET_FIREWALL_AC_NONE = 0x0,

            /// <summary>Notifications will be delivered when an app container is created with a package identifier.</summary>
            INET_FIREWALL_AC_PACKAGE_ID_ONLY = 0x1,

            /// <summary>Notifications will be delivered when an app container is created with a binary path.</summary>
            INET_FIREWALL_AC_BINARY = 0x2,

            /// <summary>Maximum value for testing purposes.</summary>
            INET_FIREWALL_AC_MAX = 0x4
        }

        /// <summary>The <c>NETISO_ERROR_TYPE</c> enumerated type specifies the type of error related to a network isolation operation.</summary>
        [PInvokeData("netfw.h", MSDNShortId = "NE:netfw._NETISO_ERROR_TYPE")]
        public enum NETISO_ERROR_TYPE
        {
            /// <summary>No error.</summary>
            NETISO_ERROR_TYPE_NONE,

            /// <summary>The failure was caused because the privateNetworkClientServer capability is missing.</summary>
            NETISO_ERROR_TYPE_PRIVATE_NETWORK,

            /// <summary>The failure was caused because the internetClient capability is missing.</summary>
            NETISO_ERROR_TYPE_INTERNET_CLIENT,

            /// <summary>The failure was caused because the internetClientServer capability is missing.</summary>
            NETISO_ERROR_TYPE_INTERNET_CLIENT_SERVER,

            /// <summary>Maximum value for testing purposes.</summary>
            NETISO_ERROR_TYPE_MAX
        }

        /// <summary>The <c>NETISO_FLAG</c> enumerated type specifies whether binaries should be returned for app containers.</summary>
        /// <remarks>
        /// By default, binaries are not returned. <c>NETISO_FLAG_FORCE_COMPUTE_BINARIES</c> must be set in order for these to be returned.
        /// </remarks>
        [PInvokeData("netfw.h", MSDNShortId = "NE:netfw.NETISO_FLAG")]
        [Flags]
        public enum NETISO_FLAG
        {
            /// <summary>
            ///     Specifies that all binaries will be computed before the app container is returned.This flag should be set if the caller requires
            ///     up-to-date and complete information on app container binaries. If this flag is not set, returned data may be stale or incomplete.
            /// </summary>
            NETISO_FLAG_FORCE_COMPUTE_BINARIES = 0x1,

            /// <summary>Maximum value for testing purposes.</summary>
            NETISO_FLAG_MAX = 0x2
        }

        /// <summary>A bitmask value of control flags which specify the context of <see cref="NetworkIsolationGetEnterpriseIdAsync"/>.</summary>
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationGetEnterpriseIdAsync")]
        public enum NETISO_GEID
        {
            /// <summary>
            ///     Default API behavior. Returns the Enterprise ID for Enterprise resources. Returns NULL for Personal resources. For Neutral
            ///     resources, returns Enterprise ID if it is called from an Enterprise context, or returns NULL if it is called from a Personal context.
            /// </summary>
            NETISO_GEID_DEFAULT = 0x0,

            /// <summary>Used in the context of the Windows Defender Application Guard (WDAG) scenario.</summary>
            NETISO_GEID_FOR_WDAG = 0x1,

            /// <summary>
            ///     Used by applications that are aware of neutral resources. For Neutral resources the API will return L”*”. For Enterprise
            ///     resources the API will return the Enterprise ID. For Personal resources the API will return NULL.
            /// </summary>
            NETISO_GEID_FOR_NEUTRAL_AWARE = 0x2,

            /// <summary>
            ///     Forces API to check the resource even in cases when neither Windows Information Protection nor Windows Defender Application
            ///     Guard are enabled.
            /// </summary>
            NETISO_GEID_FORCE_TO_CHECK = 0x4
        }

        /// <summary>
        /// The <c>NetworkIsolationEnumAppContainers</c> function enumerates all of the app containers that have been created in the system.
        /// </summary>
        /// <param name="Flags">
        /// <para>Type: <c>DWORD</c></para>
        /// <para>
        /// May be set to <c>NETISO_FLAG_FORCE_COMPUTE_BINARIES</c> to ensure that all binaries are computed before the app container is
        /// returned. This flag should be set if the caller requires up-to-date and complete information on app container binaries. If this flag
        /// is not set, returned data may be stale or incomplete.
        /// </para>
        /// <para>See NETISO_FLAG for more information.</para>
        /// </param>
        /// <param name="pdwNumPublicAppCs">
        /// <para>Type: <c>DWORD*</c></para>
        /// <para>The number of app containers in the <c>ppPublicAppCs</c> member.</para>
        /// </param>
        /// <param name="ppPublicAppCs">
        /// <para>Type: <c>PINET_FIREWALL_APP_CONTAINER*</c></para>
        /// <para>The list of app container structure elements.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <c>DWORD</c></para>
        /// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
        /// <para>ERROR_OUTOFMEMORY will be returned if memory is unavailable.</para>
        /// </returns>
        /// <remarks>If no app containers are installed on the system, ERROR_SUCCESS will still be returned (and ppPublicAppCs will be empty).</remarks>
        [DllImport(Lib_Firewallapi, SetLastError = false, ExactSpelling = true)]
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationEnumAppContainers")]
        public static extern Win32Error NetworkIsolationEnumAppContainers(NETISO_FLAG Flags, out uint pdwNumPublicAppCs, out IntPtr ppPublicAppCs);

        /// <summary>The <c>NetworkIsolationEnumerateAppContainerRules</c> function enumerates all of the rules related to app containers.</summary>
        /// <param name="newEnum">
        /// <para>Type: <c>IEnumVARIANT**</c></para>
        /// <para>Enumerator interface of an INetFwRule3 object that represents the rules enforcing app containers.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <c>HRESULT</c></para>
        /// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
        /// </returns>
        [DllImport(Lib_Firewallapi, SetLastError = false, ExactSpelling = true)]
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationEnumerateAppContainerRules")]
        public static extern HRESULT NetworkIsolationEnumerateAppContainerRules([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnumeratorToEnumVariantMarshaler), MarshalCookie = "")] out IEnumerable newEnum);

        /// <summary>
        /// <para>
        /// Gets the Enterprise ID based on Network Isolation endpoints in the context of the Windows Information Protection (WIP) or the
        /// Windows Defender Application Guard (WDAG) scenarios. If neither WIP nor WDAG are on, the API returns NULL, unless the flag
        /// <c>NETISO_GEID_FORCE_TO_CHECK</c> is passed. The Enterprise ID can be any string different from NULL or “*”.
        /// </para>
        /// <para>Example of NetworkIsolationGetEnterpriseIdAsync usage: https://github.com/microsoft/EnterpriseStateClassify</para>
        /// </summary>
        /// <param name="wszServerName">The name of the Enterprise Data Protection Server.</param>
        /// <param name="dwFlags">
        /// <para>A bitmask value of control flags which specify the context of the API call. May contain one or more of the following flags.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <term>Meaning</term>
        /// </listheader>
        /// <item>
        /// <term>NETISO_GEID_DEFAULT 0x00</term>
        /// <term>
        /// Default API behavior. Returns the Enterprise ID for Enterprise resources. Returns NULL for Personal resources. For Neutral
        /// resources, returns Enterprise ID if it is called from an Enterprise context, or returns NULL if it is called from a Personal context.
        /// </term>
        /// </item>
        /// <item>
        /// <term>NETISO_GEID_FOR_WDAG 0x01</term>
        /// <term>Used in the context of the Windows Defender Application Guard (WDAG) scenario.</term>
        /// </item>
        /// <item>
        /// <term>NETISO_GEID_FOR_NEUTRAL_AWARE 0x02</term>
        /// <term>
        /// Used by applications that are aware of neutral resources. For Neutral resources the API will return L”*”. For Enterprise resources
        /// the API will return the Enterprise ID. For Personal resources the API will return NULL.
        /// </term>
        /// </item>
        /// <item>
        /// <term>NETISO_GEID_FORCE_TO_CHECK 0x04</term>
        /// <term>
        /// Forces API to check the resource even in cases when neither Windows Information Protection nor Windows Defender Application Guard
        /// are enabled.
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="context">Optional context pointer.</param>
        /// <param name="callback">Function pointer that will be invoked when a notification is ready for delivery.</param>
        /// <param name="hOperation">The handle for the Enterprise Data Protection Server endpoints.</param>
        /// <returns>Returns ERROR_SUCCESS if successful, or an error value otherwise.</returns>
        [DllImport(Lib_Firewallapi, SetLastError = false, ExactSpelling = true)]
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationGetEnterpriseIdAsync")]
        public static extern Win32Error NetworkIsolationGetEnterpriseIdAsync([MarshalAs(UnmanagedType.LPWStr)] string wszServerName, NETISO_GEID dwFlags, [In][Optional] IntPtr context, PNETISO_EDP_ID_CALLBACK_FN callback, out HANDLE hOperation);

        /// <summary>
        /// <para>
        /// This API is used for closing the handle returned by NetworkIsolationGetEnterpriseIdAsync as well as for synchronizing the operation.
        /// </para>
        /// <para>Example of NetworkIsolationGetEnterpriseIdClose usage: https://github.com/microsoft/EnterpriseStateClassify</para>
        /// </summary>
        /// <param name="hOperation">The handle to release.</param>
        /// <param name="bWaitForOperation">Indicates whether to wait for synchronization.</param>
        /// <returns>Returns ERROR_SUCCESS if successful, or an error value otherwise.</returns>
        [DllImport(Lib_Firewallapi, SetLastError = false, ExactSpelling = true)]
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationGetEnterpriseIdClose")]
        public static extern Win32Error NetworkIsolationGetEnterpriseIdClose(HANDLE hOperation, [MarshalAs(UnmanagedType.Bool)] bool bWaitForOperation);

        /// <summary>The <c>NetworkIsolationSetAppContainerConfig</c> function is used to set the configuration of one or more app containers.</summary>
        /// <param name="dwNumPublicAppCs">
        /// <para>Type: <c>DWORD</c></para>
        /// <para>The number of app containers in the <c>appContainerSids</c> member.</para>
        /// </param>
        /// <param name="appContainerSids">
        /// <para>Type: <c>PSID_AND_ATTRIBUTES</c></para>
        /// <para>The security identifiers (SIDs) of app containers that are allowed to send loopback traffic. Used for debugging purposes.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <c>DWORD</c></para>
        /// <para>Returns ERROR_SUCCESS if successful, or an error value otherwise.</para>
        /// </returns>
        /// <remarks>
        /// Note that it is the calling program's responsibility to first call the <c>NetworkIsolationGetAppContainerConfig</c> function in
        /// order to retrieve and preserve the app container SIDs already configured to send loopback traffic.
        /// </remarks>
        [DllImport(Lib_Firewallapi, SetLastError = false, ExactSpelling = true)]
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationSetAppContainerConfig")]
        public static extern Win32Error NetworkIsolationSetAppContainerConfig(uint dwNumPublicAppCs, [In] IntPtr appContainerSids);

        /// <summary>
        /// The <c>NetworkIsolationSetupAppContainerBinaries</c> function is used by software installers to provide information about the image
        /// paths of applications that are running in an app container. This information is provided to third-party firewall applications about
        /// the applications in order to enhance user experience and security decisions.
        /// </summary>
        /// <param name="applicationContainerSid">
        /// <para>Type: <c>PSID</c></para>
        /// <para>The package identifier of the app container.</para>
        /// </param>
        /// <param name="packageFullName">
        /// <para>Type: <c>LPCWSTR</c></para>
        /// <para>
        /// A string representing the package identity of the app that owns this app container. Contains the 5-part tuple as individual fields
        /// (name, version, architecture, resourceid, publisher).
        /// </para>
        /// </param>
        /// <param name="packageFolder">
        /// <para>Type: <c>LPCWSTR</c></para>
        /// <para>The file location of the app that owns this app container.</para>
        /// </param>
        /// <param name="displayName">
        /// <para>Type: <c>LPCWSTR</c></para>
        /// <para>The friendly name of the app container.</para>
        /// </param>
        /// <param name="bBinariesFullyComputed">
        /// <para>Type: <c>BOOL</c></para>
        /// <para>True if the binary files are being provided by the caller; otherwise, false.</para>
        /// </param>
        /// <param name="binaries">
        /// <para>Type: <c>LPCWSTR*</c></para>
        /// <para>An array of paths to the applications running in the app container.</para>
        /// </param>
        /// <param name="binariesCount">
        /// <para>Type: <c>DWORD</c></para>
        /// <para>The number of paths contained in the binaries parameter.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <c>HRESULT</c></para>
        /// <para>If the function succeeds, it returns S_OK.</para>
        /// <para>
        /// If the function fails, it returns an <c>HRESULT</c> value that indicates the error. For a list of common error codes, see Common
        /// HRESULT Values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Applications creating an app container can use <c>NetworkIsolationSetupAppContainerBinaries</c> to provide third-party firewall
        /// applications with the direct path to applications running inside that app container.
        /// </remarks>
        [DllImport(Lib_Firewallapi, SetLastError = false, ExactSpelling = true)]
        [PInvokeData("netfw.h", MSDNShortId = "NF:netfw.NetworkIsolationSetupAppContainerBinaries")]
        public static extern HRESULT NetworkIsolationSetupAppContainerBinaries(PSID applicationContainerSid, [MarshalAs(UnmanagedType.LPWStr)] string packageFullName, [MarshalAs(UnmanagedType.LPWStr)] string packageFolder, [MarshalAs(UnmanagedType.LPWStr)] string displayName, [MarshalAs(UnmanagedType.Bool)] bool bBinariesFullyComputed, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] binaries, uint binariesCount);

        /// <summary>The <c>INET_FIREWALL_AC_BINARIES</c> structure contains the binary paths to applications running in an app container.</summary>
        [PInvokeData("netfw.h", MSDNShortId = "NS:netfw._INET_FIREWALL_AC_BINARIES")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct INET_FIREWALL_AC_BINARIES
        {
            /// <summary>The number of paths in the <c>binaries</c> member.</summary>
            public uint count;

            /// <summary>Paths to the applications running in the app container.</summary>
            public IntPtr binaries;
        }

        /// <summary>The INET_FIREWALL_AC_CHANGE structure contains information about a change made to an app container.</summary>
        [PInvokeData("netfw.h", MSDNShortId = "NS:netfw._INET_FIREWALL_AC_CHANGE")]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct INET_FIREWALL_AC_CHANGE
        {
            /// <summary>
            /// <para>Type: <c>INET_FIREWALL_AC_CHANGE_TYPE</c></para>
            /// <para>The type of change made.</para>
            /// </summary>
            public INET_FIREWALL_AC_CHANGE_TYPE changeType;

            /// <summary>
            /// <para>Type: <c>INET_FIREWALL_AC_CREATION_TYPE</c></para>
            /// <para>The method by which the app container was created.</para>
            /// </summary>
            public INET_FIREWALL_AC_CREATION_TYPE createType;

            /// <summary>
            /// <para>Type: <c>SID*</c></para>
            /// <para>The package identifier of the app container</para>
            /// </summary>
            public PSID appContainerSid;

            /// <summary>
            /// <para>Type: <c>SID*</c></para>
            /// <para>The security identifier (SID) of the user to whom the app container belongs.</para>
            /// </summary>
            public PSID userSid;

            /// <summary>
            /// <para>Type: <c>LPWSTR</c></para>
            /// <para>Friendly name of the app container.</para>
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string displayName;

            /// <summary/>
            public UNIONType union;

            /// <summary/>
            [StructLayout(LayoutKind.Explicit)]
            public struct UNIONType
            {
                /// <summary>
                /// <para>Type: <c>INET_FIREWALL_AC_CAPABILITIES</c></para>
                /// <para>Information about the capabilities of the changed app container.</para>
                /// </summary>
                [FieldOffset(0)]
                public INET_FIREWALL_AC_CAPABILITIES capabilities;

                /// <summary>
                /// <para>Type: <c>INET_FIREWALL_AC_BINARIES</c></para>
                /// <para>Binary paths to the applications running in the changed app container.</para>
                /// </summary>
                [FieldOffset(0)]
                public INET_FIREWALL_AC_BINARIES binaries;
            }
        }
    }
}