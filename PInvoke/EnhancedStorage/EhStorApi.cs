using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.PortableDeviceApi;

namespace Vanara.PInvoke
{
    /// <summary>Elements from the Enhanced Storage API.</summary>
    public static partial class EnhancedStorage
    {
        private delegate void GetArrayDelegate(out SafeCoTaskMemHandle h, out uint c);

        /// <summary>Integer value that indicates the possible authorization state of the ACT.</summary>
        [PInvokeData("ehstorapi.h")]
        public enum ACT_AUTHORIZATION_STATE_VALUE
        {
            /// <summary>The ACT is unauthorized</summary>
            ACT_UNAUTHORIZED = 0x0000,

            /// <summary>The ACT is authorized</summary>
            ACT_AUTHORIZED = 0x0001
        }

        /// <summary>Undocumented.</summary>
        [PInvokeData("ehstorapi.h")]
        [Flags]
        public enum ACT_AUTHORIZE
        {
            /// <summary>Undocumented.</summary>
            ACT_AUTHORIZE_ON_RESUME = 0x00000001,

            /// <summary>Undocumented.</summary>
            ACT_AUTHORIZE_ON_SESSION_UNLOCK = 0x00000002,
        }

        /// <summary>Undocumented.</summary>
        [PInvokeData("ehstorapi.h")]
        [Flags]
        public enum ACT_UNAUTHORIZE
        {
            /// <summary>Undocumented.</summary>
            ACT_UNAUTHORIZE_ON_SUSPEND = 0x00000001,

            /// <summary>Undocumented.</summary>
            ACT_UNAUTHORIZE_ON_SESSION_LOCK = 0x00000002,
        }

        /// <summary>Use this interface to obtain information and perform operations for a 1667 Addressable Contact Target (ACT).</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nn-ehstorapi-ienhancedstorageact
        [PInvokeData("ehstorapi.h", MSDNShortId = "NN:ehstorapi.IEnhancedStorageACT")]
        [ComImport, Guid("6e7781f4-e0f2-4239-b976-a01abab52930"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnhancedStorageACT))]
        public interface IEnhancedStorageACT
        {
            /// <summary>
            /// /// Associates the Addressable Command Target (ACT) with the <c>Authorized</c> state defined by ACT_AUTHORIZATION_STATE, and
            /// ensures the authentication of each individual silo according to the required sequence and logical combination necessary to
            /// authorize access to the ACT.
            /// </summary>
            /// <param name="hwndParent">Not used.</param>
            /// <param name="dwFlags">Not used.</param>
            /// <remarks>This interface method can be used when an application wants to change the ACT to the 'Authorized' state.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-authorize HRESULT Authorize(
            // [in] DWORD hwndParent, [in] DWORD dwFlags );
            void Authorize([In, Optional] uint hwndParent, [In, Optional] ACT_AUTHORIZE dwFlags);

            /// <summary>
            /// Associates the Addressable Command Target (ACT) with the <c>Unauthorized</c> state defined by ACT_AUTHORIZATION_STATE, and
            /// ensures the deauthentication of each individual silo according to the required sequence and logical combination necessary to
            /// restrict access to the ACT.
            /// </summary>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-unauthorize HRESULT Unauthorize();
            void Unauthorize();

            /// <summary>Returns the current authorization state of the ACT.</summary>
            /// <returns>An ACT_AUTHORIZATION_STATE that specifies the current authorization state of the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getauthorizationstate HRESULT
            // GetAuthorizationState( [out] ACT_AUTHORIZATION_STATE *pState );
            ACT_AUTHORIZATION_STATE GetAuthorizationState();

            /// <summary>Returns the volume associated with the Addressable Command Target (ACT).</summary>
            /// <returns>The volume associated with the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getmatchingvolume HRESULT
            // GetMatchingVolume( [out] LPWSTR *ppwszVolume );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetMatchingVolume();

            /// <summary>Retrieves the unique identity of the Addressable Command Target (ACT).</summary>
            /// <returns>The unique identity of the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getuniqueidentity HRESULT
            // GetUniqueIdentity( [out] LPWSTR *ppwszIdentity );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetUniqueIdentity();

            /// <summary>Returns an enumeration of all silos associated with the Addressable Command Target (ACT).</summary>
            /// <param name="pppIEnhancedStorageSilos">
            /// Returns an array of one or more IEnhancedStorageSilo interface pointers associated with the ACT.
            /// </param>
            /// <param name="pcEnhancedStorageSilos">
            /// Count of IEnhancedStorageSilo pointers returned. This value indicates the dimension of the array represented by pppIEnhancedStorageSilos.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getsilos HRESULT GetSilos(
            // [out] IEnhancedStorageSilo ***pppIEnhancedStorageSilos, [out] ULONG *pcEnhancedStorageSilos );
            void GetSilos(out SafeCoTaskMemHandle pppIEnhancedStorageSilos, out uint pcEnhancedStorageSilos);
        }

        /// <summary>The <c>IEnhancedStorageACT2</c> interface is used to obtain information for a 1667 Addressable Contact Target (ACT).</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nn-ehstorapi-ienhancedstorageact2
        [PInvokeData("ehstorapi.h", MSDNShortId = "NN:ehstorapi.IEnhancedStorageACT2")]
        [ComImport, Guid("4DA57D2E-8EB3-41f6-A07E-98B52B88242B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnhancedStorageACT))]
        public interface IEnhancedStorageACT2 : IEnhancedStorageACT
        {
            /// <summary>
            /// /// Associates the Addressable Command Target (ACT) with the <c>Authorized</c> state defined by ACT_AUTHORIZATION_STATE, and
            /// ensures the authentication of each individual silo according to the required sequence and logical combination necessary to
            /// authorize access to the ACT.
            /// </summary>
            /// <param name="hwndParent">Not used.</param>
            /// <param name="dwFlags">Not used.</param>
            /// <remarks>This interface method can be used when an application wants to change the ACT to the 'Authorized' state.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-authorize HRESULT Authorize(
            // [in] DWORD hwndParent, [in] DWORD dwFlags );
            new void Authorize([In, Optional] uint hwndParent, [In, Optional] ACT_AUTHORIZE dwFlags);

            /// <summary>
            /// Associates the Addressable Command Target (ACT) with the <c>Unauthorized</c> state defined by ACT_AUTHORIZATION_STATE, and
            /// ensures the deauthentication of each individual silo according to the required sequence and logical combination necessary to
            /// restrict access to the ACT.
            /// </summary>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-unauthorize HRESULT Unauthorize();
            new void Unauthorize();

            /// <summary>Returns the current authorization state of the ACT.</summary>
            /// <returns>An ACT_AUTHORIZATION_STATE that specifies the current authorization state of the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getauthorizationstate HRESULT
            // GetAuthorizationState( [out] ACT_AUTHORIZATION_STATE *pState );
            new ACT_AUTHORIZATION_STATE GetAuthorizationState();

            /// <summary>Returns the volume associated with the Addressable Command Target (ACT).</summary>
            /// <returns>The volume associated with the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getmatchingvolume HRESULT
            // GetMatchingVolume( [out] LPWSTR *ppwszVolume );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string GetMatchingVolume();

            /// <summary>Retrieves the unique identity of the Addressable Command Target (ACT).</summary>
            /// <returns>The unique identity of the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getuniqueidentity HRESULT
            // GetUniqueIdentity( [out] LPWSTR *ppwszIdentity );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string GetUniqueIdentity();

            /// <summary>Returns an enumeration of all silos associated with the Addressable Command Target (ACT).</summary>
            /// <param name="pppIEnhancedStorageSilos">
            /// Returns an array of one or more IEnhancedStorageSilo interface pointers associated with the ACT.
            /// </param>
            /// <param name="pcEnhancedStorageSilos">
            /// Count of IEnhancedStorageSilo pointers returned. This value indicates the dimension of the array represented by pppIEnhancedStorageSilos.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getsilos HRESULT GetSilos(
            // [out] IEnhancedStorageSilo ***pppIEnhancedStorageSilos, [out] ULONG *pcEnhancedStorageSilos );
            new void GetSilos(out SafeCoTaskMemHandle pppIEnhancedStorageSilos, out uint pcEnhancedStorageSilos);

            /// <summary>
            /// The <c>IEnhancedStorageACT2::GetDeviceName</c> method returns the device name associated with the Addressable Command Target (ACT).
            /// </summary>
            /// <returns>The device name associated with the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact2-getdevicename HRESULT
            // GetDeviceName( [out] LPWSTR *ppwszDeviceName );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDeviceName();

            /// <summary>
            /// The <c>IEnhancedStorageACT2::IsDeviceRemovable</c> method returns information that indicates if the device associated with
            /// the ACT is removable.
            /// </summary>
            /// <returns>Indicates if the device associated with the ACT is removable.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact2-isdeviceremovable HRESULT
            // IsDeviceRemovable( BOOL *pIsDeviceRemovable );
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsDeviceRemovable();
        }

        /// <summary>Undocumented.</summary>
        /// <seealso cref="Vanara.PInvoke.EnhancedStorage.IEnhancedStorageACT2"/>
        [PInvokeData("ehstorapi.h")]
        [ComImport, Guid("022150A1-113D-11DF-BB61-001AA01BBC58"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnhancedStorageACT))]
        public interface IEnhancedStorageACT3 : IEnhancedStorageACT2
        {
            /// <summary>
            /// /// Associates the Addressable Command Target (ACT) with the <c>Authorized</c> state defined by ACT_AUTHORIZATION_STATE, and
            /// ensures the authentication of each individual silo according to the required sequence and logical combination necessary to
            /// authorize access to the ACT.
            /// </summary>
            /// <param name="hwndParent">Not used.</param>
            /// <param name="dwFlags">Not used.</param>
            /// <remarks>This interface method can be used when an application wants to change the ACT to the 'Authorized' state.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-authorize HRESULT Authorize(
            // [in] DWORD hwndParent, [in] DWORD dwFlags );
            new void Authorize([In, Optional] uint hwndParent, [In, Optional] ACT_AUTHORIZE dwFlags);

            /// <summary>
            /// Associates the Addressable Command Target (ACT) with the <c>Unauthorized</c> state defined by ACT_AUTHORIZATION_STATE, and
            /// ensures the deauthentication of each individual silo according to the required sequence and logical combination necessary to
            /// restrict access to the ACT.
            /// </summary>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-unauthorize HRESULT Unauthorize();
            new void Unauthorize();

            /// <summary>Returns the current authorization state of the ACT.</summary>
            /// <returns>An ACT_AUTHORIZATION_STATE that specifies the current authorization state of the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getauthorizationstate HRESULT
            // GetAuthorizationState( [out] ACT_AUTHORIZATION_STATE *pState );
            new ACT_AUTHORIZATION_STATE GetAuthorizationState();

            /// <summary>Returns the volume associated with the Addressable Command Target (ACT).</summary>
            /// <returns>The volume associated with the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getmatchingvolume HRESULT
            // GetMatchingVolume( [out] LPWSTR *ppwszVolume );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string GetMatchingVolume();

            /// <summary>Retrieves the unique identity of the Addressable Command Target (ACT).</summary>
            /// <returns>The unique identity of the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getuniqueidentity HRESULT
            // GetUniqueIdentity( [out] LPWSTR *ppwszIdentity );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string GetUniqueIdentity();

            /// <summary>Returns an enumeration of all silos associated with the Addressable Command Target (ACT).</summary>
            /// <param name="pppIEnhancedStorageSilos">
            /// Returns an array of one or more IEnhancedStorageSilo interface pointers associated with the ACT.
            /// </param>
            /// <param name="pcEnhancedStorageSilos">
            /// Count of IEnhancedStorageSilo pointers returned. This value indicates the dimension of the array represented by pppIEnhancedStorageSilos.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact-getsilos HRESULT GetSilos(
            // [out] IEnhancedStorageSilo ***pppIEnhancedStorageSilos, [out] ULONG *pcEnhancedStorageSilos );
            new void GetSilos(out SafeCoTaskMemHandle pppIEnhancedStorageSilos, out uint pcEnhancedStorageSilos);

            /// <summary>
            /// The <c>IEnhancedStorageACT2::GetDeviceName</c> method returns the device name associated with the Addressable Command Target (ACT).
            /// </summary>
            /// <returns>The device name associated with the ACT.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact2-getdevicename HRESULT
            // GetDeviceName( [out] LPWSTR *ppwszDeviceName );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string GetDeviceName();

            /// <summary>
            /// The <c>IEnhancedStorageACT2::IsDeviceRemovable</c> method returns information that indicates if the device associated with
            /// the ACT is removable.
            /// </summary>
            /// <returns>Indicates if the device associated with the ACT is removable.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstorageact2-isdeviceremovable HRESULT
            // IsDeviceRemovable( BOOL *pIsDeviceRemovable );
            [return: MarshalAs(UnmanagedType.Bool)]
            new bool IsDeviceRemovable();

            /// <summary>Undocumented.</summary>
            /// <param name="dwFlags"/>
            void UnauthorizeEx(ACT_UNAUTHORIZE dwFlags);

            /// <summary>Undocumented.</summary>
            /// <returns/>
            [return: MarshalAs(UnmanagedType.Bool)]
            bool IsQueueFrozen();

            /// <summary>Undocumented.</summary>
            /// <returns/>
            [return: MarshalAs(UnmanagedType.Bool)]
            bool GetShellExtSupport();
        }

        /// <summary>
        /// The <c>IEnhancedStorageSilo</c> interface is the point of access for an IEEE 1667 silo and is used to obtain information and
        /// perform operations at the silo level.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nn-ehstorapi-ienhancedstoragesilo
        [PInvokeData("ehstorapi.h", MSDNShortId = "NN:ehstorapi.IEnhancedStorageSilo")]
        [ComImport, Guid("5aef78c6-2242-4703-bf49-44b29357a359"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnhancedStorageSilo))]
        public interface IEnhancedStorageSilo
        {
            /// <summary>Returns the descriptive information associated with the silo object.</summary>
            /// <returns>A SILO_INFO object containing descriptive information associated with the silo.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesilo-getinfo HRESULT GetInfo( [out]
            // SILO_INFO *pSiloInfo );
            SILO_INFO GetInfo();

            /// <summary>Returns an enumeration of all actions available to the silo object.</summary>
            /// <param name="pppIEnhancedStorageSiloActions">
            /// Array of pointers to IEnhancedStorageAction interface objects that represent the actions available for the silo object. This
            /// array is allocated within the API when at least one action is available to the silo.
            /// </param>
            /// <param name="pcEnhancedStorageSiloActions">
            /// Count of IEnhancedStorageAction pointers returned. This value indicates the dimension of the array represented by pppIEnhancedStorageSilos.
            /// </param>
            /// <remarks>
            /// The memory containing the IEnhancedStorageAction interface pointers is allocated by the Enhanced Storage API and must be
            /// freed by passing the returned pointer to CoTaskMemFree.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesilo-getactions HRESULT GetActions(
            // [out] IEnhancedStorageSiloAction ***pppIEnhancedStorageSiloActions, [out] ULONG *pcEnhancedStorageSiloActions );
            void GetActions(out SafeCoTaskMemHandle pppIEnhancedStorageSiloActions, out uint pcEnhancedStorageSiloActions);

            /// <summary>
            /// Sends a raw silo command to the silo object. This method is utilized to communicate with a silo which is not represented by
            /// a driver.
            /// </summary>
            /// <param name="Command">
            /// The silo command to be issued. 8 bits of this value are placed in the byte at position 3 of the CDB sent to the device; i.e.
            /// the second byte of the <c>SecurityProtocolSpecific</c> field.
            /// </param>
            /// <param name="pbCommandBuffer">The command payload sent to the device in the send data phase of the command.</param>
            /// <param name="cbCommandBuffer">The count of bytes contained in the pbCommandBuffer buffer.</param>
            /// <param name="pbResponseBuffer">
            /// The response payload that is returned to the host from the device in the receive data phase of the command.
            /// </param>
            /// <param name="pcbResponseBuffer">
            /// On method entry, contains the size of pbResponseBuffer in bytes. On method exit, it contains the count of bytes contained in
            /// the returned pbResponse buffer.
            /// </param>
            /// <remarks>
            /// <para>
            /// This method is currently not supported by the IEEE 1667 certificate and password silos. It is recommended that the Enhanced
            /// Storage Portable Device Commands are used instead.
            /// </para>
            /// <para>
            /// The caller is responsible for sending correct parameters to the command, as well as allocating the necessary buffer for the
            /// returned results.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesilo-sendcommand HRESULT
            // SendCommand( [in] UCHAR Command, [in] BYTE *pbCommandBuffer, [in] ULONG cbCommandBuffer, [out] BYTE *pbResponseBuffer, [out]
            // ULONG *pcbResponseBuffer );
            void SendCommand([In] byte Command, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbCommandBuffer,
                [In] uint cbCommandBuffer,
                [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbResponseBuffer,
                [In, Out] ref uint pcbResponseBuffer);

            /// <summary>Obtains an IPortableDevice pointer used to issue commands to the corresponding Enhanced Storage silo driver.</summary>
            /// <returns>An IPortableDevice object.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesilo-getportabledevice HRESULT
            // GetPortableDevice( [out] IPortableDevice **ppIPortableDevice );
            IPortableDevice GetPortableDevice();

            /// <summary>
            /// Retrieves the path to the silo device node. The returned string is suitable for passing to <c>Windows System</c> APIs such
            /// as CreateFile or SetupDiOpenDeviceInterface.
            /// </summary>
            /// <returns>The path to the Silo device node.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesilo-getdevicepath HRESULT
            // GetDevicePath( [out] LPWSTR *ppwszSiloDevicePath );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDevicePath();
        }

        /// <summary>Use this interface as a point of access for actions involving IEEE 1667 silos.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nn-ehstorapi-ienhancedstoragesiloaction
        [PInvokeData("ehstorapi.h", MSDNShortId = "NN:ehstorapi.IEnhancedStorageSiloAction")]
        [ComImport, Guid("b6f7f311-206f-4ff8-9c4b-27efee77a86f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnhancedStorageSiloAction))]
        public interface IEnhancedStorageSiloAction
        {
            /// <summary>Returns a string for the name of the action specified by the IEnhancedStorageSiloAction object.</summary>
            /// <returns>The silo action by name.</returns>
            /// <remarks>
            /// <para>
            /// A name string is short, consisting of one or two words, and is suitable for display in a UI element such as a menu item or
            /// button label.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesiloaction-getname HRESULT GetName(
            // [out] LPWSTR *ppwszActionName );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetName();

            /// <summary>Returns a descriptive string for the action specified by the IEnhancedStorageSiloAction object.</summary>
            /// <returns>A string that describes the silo action.</returns>
            /// <remarks>
            /// <para>
            /// The description string is brief, consisting of one or two short sentences, and is suitable for display in a UI element such
            /// as tooltip or small static text box.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesiloaction-getdescription HRESULT
            // GetDescription( [out] LPWSTR *ppwszActionDescription );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDescription();

            /// <summary>Performs the action specified by an IEnhancedStorageSiloAction object.</summary>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesiloaction-invoke HRESULT Invoke();
            void Invoke();
        }

        /// <summary>Use this interface as the top level enumerator for all IEEE 1667 Addressable Contact Targets (ACT).</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nn-ehstorapi-ienumenhancedstorageact
        [PInvokeData("ehstorapi.h", MSDNShortId = "NN:ehstorapi.IEnumEnhancedStorageACT")]
        [ComImport, Guid("09b224bd-1335-4631-a7ff-cfd3a92646d7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnumEnhancedStorageACT))]
        public interface IEnumEnhancedStorageACT
        {
            /// <summary>
            /// Returns an enumeration of all the Addressable Command Targets (ACT) currently connected to the system. If at least one ACT
            /// is present, the Enhanced Storage API allocates an array of 1 or more IEnumEnhancedStorageACT pointers.
            /// </summary>
            /// <param name="pppIEnhancedStorageACTs">
            /// Array of IEnhancedStorageACT interface pointers that represent the ACTs for all devices connected to the system. This array
            /// is allocated within the API.
            /// </param>
            /// <param name="pcEnhancedStorageACTs">
            /// Count of IEnhancedStorageACT pointers returned. This is the dimension of the array represented by pppIEnhancedStorageACTs.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienumenhancedstorageact-getacts HRESULT GetACTs(
            // [out] IEnhancedStorageACT ***pppIEnhancedStorageACTs, ULONG *pcEnhancedStorageACTs );
            void GetACTs(out SafeCoTaskMemHandle pppIEnhancedStorageACTs, out uint pcEnhancedStorageACTs);

            /// <summary>
            /// Returns the Addressable Command Target (ACT) associated with the volume specified via the string supplied by the client.
            /// </summary>
            /// <param name="szVolume">A string that specifies the volume for which a matching ACT is searched for.</param>
            /// <returns>
            /// An <c>IEnhancedStorageACT</c> interface pointer that represents the matching ACT. If no matching ACT is found the error
            /// <c>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</c> is returned.
            /// </returns>
            /// <remarks>
            /// This method can also be utilized by the client to determine if the specified volume resides on, and is represented by an
            /// IEEE 1667 ACT.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienumenhancedstorageact-getmatchingact HRESULT
            // GetMatchingACT( [in] LPCWSTR szVolume, [out] IEnhancedStorageACT **ppIEnhancedStorageACT );
            IEnhancedStorageACT GetMatchingACT([In, MarshalAs(UnmanagedType.LPWStr)] string szVolume);
        }

        /// <summary>Returns an enumeration of all actions available to the silo object.</summary>
        /// <returns>Array of IEnhancedStorageAction interface objects that represent the actions available for the silo object.</returns>
        public static IEnhancedStorageSiloAction[] GetActions(this IEnhancedStorageSilo silo) => GetIntfArray<IEnhancedStorageSiloAction>(silo.GetActions);

        /// <summary>
        /// Returns an enumeration of all the Addressable Command Targets (ACT) currently connected to the system. If at least one ACT is
        /// present, the Enhanced Storage API allocates an array of 1 or more IEnumEnhancedStorageACT pointers.
        /// </summary>
        /// <returns>Array of IEnhancedStorageACT interface pointers that represent the ACTs for all devices connected to the system.</returns>
        public static IEnhancedStorageACT[] GetACTs(this IEnumEnhancedStorageACT act) => GetIntfArray<IEnhancedStorageACT>(act.GetACTs);

        /// <summary>Returns an enumeration of all silos associated with the Addressable Command Target (ACT).</summary>
        /// <returns>An array of one or more IEnhancedStorageSilo interface pointers associated with the ACT.</returns>
        public static IEnhancedStorageSilo[] GetSilos(this IEnhancedStorageACT act) => GetIntfArray<IEnhancedStorageSilo>(act.GetSilos);

        /// <summary>
        /// Sends a raw silo command to the silo object. This method is utilized to communicate with a silo which is not represented by a driver.
        /// </summary>
        /// <param name="silo">The silo interface instance.</param>
        /// <param name="command">
        /// The silo command to be issued. 8 bits of this value are placed in the byte at position 3 of the CDB sent to the device; i.e. the
        /// second byte of the <c>SecurityProtocolSpecific</c> field.
        /// </param>
        /// <param name="commandBuffer">The command payload sent to the device in the send data phase of the command.</param>
        /// <param name="expectedResponseBufferSize">Contains the expected size of the response in bytes.</param>
        /// <returns>The response payload that is returned to the host from the device in the receive data phase of the command.</returns>
        /// <remarks>
        /// <para>
        /// This method is currently not supported by the IEEE 1667 certificate and password silos. It is recommended that the Enhanced
        /// Storage Portable Device Commands are used instead.
        /// </para>
        /// <para>The caller is responsible for sending correct parameters to the command.</para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/nf-ehstorapi-ienhancedstoragesilo-sendcommand HRESULT
        public static byte[] SendCommand(this IEnhancedStorageSilo silo, Byte command, Byte[] commandBuffer, UInt32 expectedResponseBufferSize)
        {
            // *** From SDK sample ***
            // 1. align command buffer to 512 bytes boundary
            UInt32 commandBufferLength = (UInt32)Macros.ALIGN_TO_MULTIPLE(commandBuffer.Length, 512);
            Byte[] commandBufferAlign = new Byte[commandBufferLength];
            commandBuffer.CopyTo(commandBufferAlign, 0);
            // 2. create response buffer 
            var responseBuffer = new Byte[expectedResponseBufferSize];
            UInt32 responseBufferSize = (UInt32)responseBuffer.Length;
            // 3. send command to silo
            silo.SendCommand(command, commandBufferAlign, commandBufferLength, responseBuffer, ref responseBufferSize);
            return responseBuffer;
        }

        private static T[] GetIntfArray<T>(GetArrayDelegate f) where T : class
        {
            f(out var h, out var cnt);
            return cnt == 0 ? new T[0] : h.ToEnumerable<IntPtr>((int)cnt).Select(p => (T)Marshal.GetObjectForIUnknown(p)).ToArray();
        }

        /// <summary>
        /// The <c>ACT_AUTHORIZATION_STATE</c> structure contains data that describes the current authorization state of a Addressable
        /// Command Target (ACT).
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/ns-ehstorapi-act_authorization_state typedef struct
        // _ACT_AUTHORIZATION_STATE { ULONG ulState; } ACT_AUTHORIZATION_STATE;
        [PInvokeData("ehstorapi.h", MSDNShortId = "NS:ehstorapi._ACT_AUTHORIZATION_STATE")]
        [StructLayout(LayoutKind.Sequential)]
        public struct ACT_AUTHORIZATION_STATE
        {
            /// <summary>
            /// <para>Integer value that indicates the possible authorization state of the ACT.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Value</term>
            /// <term>Meaning</term>
            /// </listheader>
            /// <item>
            /// <term>0</term>
            /// <term>The ACT is unauthorized</term>
            /// </item>
            /// <item>
            /// <term>1</term>
            /// <term>The ACT is authorized</term>
            /// </item>
            /// </list>
            /// </summary>
            public ACT_AUTHORIZATION_STATE_VALUE ulState;
        }

        /// <summary>The <c>SILO_INFO</c> structure contains information that identifies and describes the silo.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/ehstorapi/ns-ehstorapi-silo_info typedef struct _SILO_INFO { ULONG ulSTID;
        // UCHAR SpecificationMajor; UCHAR SpecificationMinor; UCHAR ImplementationMajor; UCHAR ImplementationMinor; UCHAR type; UCHAR
        // capabilities; } SILO_INFO;
        [PInvokeData("ehstorapi.h", MSDNShortId = "NS:ehstorapi._SILO_INFO")]
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct SILO_INFO
        {
            /// <summary>Silo Type Identifier for the silo assigned by IEEE 1667 Working Group.</summary>
            public uint ulSTID;

            /// <summary>Major version of the specification implemented in the silo.</summary>
            public byte SpecificationMajor;

            /// <summary>Minor version of the specification implemented in the silo.</summary>
            public byte SpecificationMinor;

            /// <summary>Major version of the firmware implemented in the silo.</summary>
            public byte ImplementationMajor;

            /// <summary>Minor version of the firmware implemented in the silo.</summary>
            public byte ImplementationMinor;

            /// <summary>Type of the silo.</summary>
            public byte type;

            /// <summary>Capabilities of the silo.</summary>
            public byte capabilities;
        }

        /// <summary>EnhancedStorageACT Class</summary>
        [ComImport, Guid("af076a15-2ece-4ad4-bb21-29f040e176d8"), ClassInterface(ClassInterfaceType.None)]
        public class EnhancedStorageACT
        {
        }

        /// <summary>EnhancedStorageSilo Class</summary>
        [ComImport, Guid("cb25220c-76c7-4fee-842b-f3383cd022bc"), ClassInterface(ClassInterfaceType.None)]
        public class EnhancedStorageSilo
        {
        }

        /// <summary>EnhancedStorageSiloAction Class</summary>
        [ComImport, Guid("886D29DD-B506-466B-9FBF-B44FF383FB3F"), ClassInterface(ClassInterfaceType.None)]
        public class EnhancedStorageSiloAction
        {
        }

        /// <summary>EnumEnhancedStorageACT Class</summary>
        [ComImport, Guid("fe841493-835c-4fa3-b6cc-b4b2d4719848"), ClassInterface(ClassInterfaceType.None)]
        public class EnumEnhancedStorageACT
        {
        }
    }
}