using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke
{
    /// <summary>Items from the PortableDeviceApi.dll</summary>
    public static partial class PortableDeviceApi
    {
        private const string Lib_PortableDeviceApi = "PortableDeviceApi.dll";

        private delegate HRESULT PDMStrArrGet(string[] arr, ref uint cnt);

        private delegate HRESULT PDMStrGet(string devId, StringBuilder str, ref uint sz);

        /// <summary>
        /// The <c>IEnumPortableDeviceObjectIDs</c> interface enumerates the objects on a portable device. Get this interface initially by
        /// calling IPortableDeviceContent::EnumObjects on a device.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-ienumportabledeviceobjectids
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IEnumPortableDeviceObjectIDs")]
        [ComImport, Guid("10ECE955-CF41-4728-BFA0-41EEDF1BBF19"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IEnumPortableDeviceObjectIDs : Vanara.Collections.ICOMEnum<string>
        {
            /// <summary>The <c>Next</c> method retrieves the next one or more object IDs in the enumeration sequence.</summary>
            /// <param name="cObjects">A count of the objects requested.</param>
            /// <param name="pObjIDs">
            /// An array of <c>LPWSTR</c> pointers, each specifying a retrieved object ID. The caller must allocate an array of cObjects
            /// LPWSTR elements. The caller must free both the array and the returned strings. The strings are freed by calling CoTaskMemFree.
            /// </param>
            /// <param name="pcFetched">
            /// On input, this parameter is ignored. On output, the number of IDs actually retrieved. If no object IDs are released and the
            /// return value is S_FALSE, there are no more objects to enumerate.
            /// </param>
            /// <returns>
            /// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Return code</term>
            /// <term>Description</term>
            /// </listheader>
            /// <item>
            /// <term>S_OK</term>
            /// <term>The method succeeded.</term>
            /// </item>
            /// <item>
            /// <term>S_FALSE</term>
            /// <term>There are no more objects to enumerate.</term>
            /// </item>
            /// </list>
            /// </returns>
            /// <remarks>
            /// <para>
            /// If fewer than the requested number of elements remain in the sequence, this method retrieves the remaining elements. The
            /// number of elements that are actually retrieved is returned through pcFetched (unless the caller passed in NULL for that
            /// parameter). Enumerated objects are all peers—that is, enumerating children of an object will enumerate only direct children,
            /// not grandchild or deeper objects.
            /// </para>
            /// <para>Examples</para>
            /// <para>
            /// <code><![CDATA[ // This number controls how many object identifiers are requested during each call
            /// // to IEnumPortableDeviceObjectIDs::Next()
            /// #define NUM_OBJECTS_TO_REQUEST 10
            /// 
            /// // Recursively called function which enumerates using the specified
            /// // object identifier as the parent.
            /// void RecursiveEnumerate(LPCWSTR wszParentObjectID, IPortableDeviceContent* pContent)
            /// {
            ///    HRESULT hr = S_OK;
            ///    IEnumPortableDeviceObjectIDs* pEnumObjectIDs = NULL;
            ///    if ((wszParentObjectID == NULL) || (pContent == NULL)) { return; }
            ///    
            ///    // wszParentObjectID is the object identifier of the parent being used for enumeration
            ///    // Get an IEnumPortableDeviceObjectIDs interface by calling EnumObjects with the
            ///    // specified parent object identifier.
            ///    hr = pContent-&gt;EnumObjects(0, wszParentObjectID, NULL, &amp;pEnumObjectIDs);
            ///    if (FAILED(hr)) {
            ///      // Failed to get IEnumPortableDeviceObjectIDs from IPortableDeviceContent
            ///    }
            ///    
            ///    // Loop calling Next() while S_OK is being returned.
            ///    while(hr == S_OK) {
            ///      DWORD cFetched = 0;
            ///      LPWSTR szObjectIDArray[NUM_OBJECTS_TO_REQUEST] = {0};
            ///      hr = pEnumObjectIDs-&gt;Next(
            ///        NUM_OBJECTS_TO_REQUEST, // Number of objects to request on each NEXT call
            ///        szObjectIDArray, // Array of LPWSTR array which will be populated on each NEXT call
            ///        &amp;cFetched); // Number of objects written to the LPWSTR array
            ///        
            ///      if (SUCCEEDED(hr)) {
            ///        // Traverse the results of the Next() operation and recursively enumerate
            ///        // Remember to free all returned object identifiers using CoTaskMemFree()
            ///        for (DWORD dwIndex = 0; dwIndex &lt; cFetched; dwIndex++) {
            ///          RecursiveEnumerate(szObjectIDArray[dwIndex],pContent);
            ///          // Free allocated LPWSTRs after the recursive enumeration call has completed.
            ///          CoTaskMemFree(szObjectIDArray[dwIndex]);
            ///          szObjectIDArray[dwIndex] = NULL;
            ///        }
            ///      }
            ///    }
            ///    // Release the IEnumPortableDeviceObjectIDs when finished
            ///    if (pEnumObjectIDs != NULL) {
            ///      pEnumObjectIDs-&gt;Release();
            ///      pEnumObjectIDs = NULL;
            ///    } 
            /// }]]></code>
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-ienumportabledeviceobjectids-next
            // HRESULT Next( [in] ULONG cObjects, [in, out] LPWSTR *pObjIDs, [in, out] ULONG *pcFetched );
            [PreserveSig]
            HRESULT Next(uint cObjects, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pObjIDs, out uint pcFetched);

            /// <summary>The <c>Skip</c> method skips a specified number of objects in the enumeration sequence.</summary>
            /// <param name="cObjects">The number of objects to skip.</param>
            /// <returns>
            /// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Return code</term>
            /// <term>Description</term>
            /// </listheader>
            /// <item>
            /// <term>S_OK</term>
            /// <term>The method succeeded.</term>
            /// </item>
            /// <item>
            /// <term>S_FALSE</term>
            /// <term>
            /// The specified number of objects could not be skipped (for instance, if fewer than cObjects remained in the enumeration sequence).
            /// </term>
            /// </item>
            /// </list>
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-ienumportabledeviceobjectids-skip
            // HRESULT Skip( [in] ULONG cObjects );
            [PreserveSig]
            HRESULT Skip([In] uint cObjects);

            /// <summary>The <c>Reset</c> method resets the enumeration sequence to the beginning.</summary>
            /// <remarks>
            /// There is no guarantee that the same objects will be enumerated after this method is called. This is because objects that
            /// were enumerated previously might have been deleted or new objects might have been added.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-ienumportabledeviceobjectids-reset
            // HRESULT Reset();
            void Reset();

            /// <summary>
            /// <para>The <c>Clone</c> method duplicates the current <c>IEnumPortableDeviceObjectIDs</c> interface.</para>
            /// <para><c>Not implemented in this release.</c></para>
            /// </summary>
            /// <returns>An enumeration interface. The caller must release this interface when it is finished with the interface.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-ienumportabledeviceobjectids-clone
            // HRESULT Clone( [out] IEnumPortableDeviceObjectIDs **ppEnum );
            IEnumPortableDeviceObjectIDs Clone();

            /// <summary>The <c>Cancel</c> method cancels a pending operation.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-ienumportabledeviceobjectids-cancel
            // HRESULT Cancel();
            void Cancel();
        }

        /// <summary>
        /// <para>The <c>IPortableDevice</c> interface provides access to a portable device.</para>
        /// <para>
        /// To create and open this interface, first call CoCreateInstance with <c>CLSID_PortableDeviceFTM</c> or
        /// <c>CLSID_PortableDevice</c> to retrieve an <c>IPortableDevice</c> interface, and then call Open to open a connection to the device.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The client interfaces are designed to be used for any WPD object; it is not necessary to create a new instance for each object
        /// referenced by the application. After an application opens an instance of the <c>IPortableDevice</c> interface, it should open
        /// and cache any other WPD client interfaces that it will require.
        /// </para>
        /// <para>
        /// For Windows 7, IPortableDevice supports two CLSIDs for <c>CoCreateInstance</c>. <c>CLSID_PortableDevice</c> returns an
        /// <c>IPortableDevice</c> pointer that does not aggregate the free-threaded marshaler; <c>CLSID_PortableDeviceFTM</c> is a new
        /// CLSID that returns an <c>IPortableDevice</c> pointer that aggregates the free-threaded marshaler. Both pointers support the same
        /// functionality otherwise.
        /// </para>
        /// <para>
        /// Applications that live in Single Threaded Apartments should use <c>CLSID_PortableDeviceFTM</c> as this eliminates the overhead
        /// of interface pointer marshaling. <c>CLSID_PortableDevice</c> is still supported for legacy applications.
        /// </para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevice
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDevice")]
        [ComImport, Guid("625e2df8-6392-4cf0-9ad1-3cfa5f17775c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PortableDevice))]
        public interface IPortableDevice
        {
            /// <summary>The <c>Open</c> method opens a connection between the application and the device.</summary>
            /// <param name="pszPnPDeviceID">
            /// A pointer to a that contains the Plug and Play ID string for the device. You can get this string by calling IPortableDeviceManager::GetDevices.
            /// </param>
            /// <param name="pClientInfo">
            /// <para>
            /// A pointer to an IPortableDeviceValues interface that holds information that identifies the application to the device. This
            /// interface holds <c>PROPERTYKEY</c>/value pairs that try to identify an application uniquely. Although the presence of a
            /// CoCreated interface is required, the application is not required to send any key/value pairs. However, sending data might
            /// improve performance. Typical key/value pairs include the application name, major and minor version, and build number.
            /// </para>
            /// <para>See properties beginning with "WPD_CLIENT_" in the Properties section.</para>
            /// </param>
            /// <remarks>
            /// <para>
            /// A device must be opened before you can call any methods on it. (Note that the IPortableDeviceManager methods do not require
            /// you to open a device before calling any methods.) However, usually you do not need to call Close.
            /// </para>
            /// <para>
            /// Administrators can restrict the access of portable devices to computers running on a network. For example, an administrator
            /// may restrict all Guest users to read-only access, while Authenticated users are given read/write access.
            /// </para>
            /// <para>
            /// Due to these security issues, if your application will not perform write operations, it should call the <c>Open</c> method
            /// and request read-only access by specifying GENERIC_READ for the WPD_CLIENT_DESIRED_ACCESS property that it supplies in the
            /// pClientInfo parameter.
            /// </para>
            /// <para>
            /// If your application requires write operations, it should call the <c>Open</c> method as shown in the following example code.
            /// The first time, it should request read/write access by passing the default WPD_CLIENT_DESIRED_ACCESS property in the
            /// pClientInfo parameter. If this first call fails and returns E_ACCESSDENIED, your application should call the <c>Open</c>
            /// method a second time and request read-only access by specifying GENERIC_READ for the WPD_CLIENT_DESIRED_ACCESS property that
            /// it supplies in the pClientInfo parameter.
            /// </para>
            /// <para>
            /// Applications that live in Single Threaded Apartments should use <c>CLSID_PortableDeviceFTM</c>, as this eliminates the
            /// overhead of interface pointer marshaling. <c>CLSID_PortableDevice</c> is still supported for legacy applications.
            /// </para>
            /// <para>Examples</para>
            /// <para>
            /// <code> #define CLIENT_NAME L"My WPD Application" #define CLIENT_MAJOR_VER 1 #define CLIENT_MINOR_VER 0 #define CLIENT_REVISION 0 HRESULT OpenDevice(LPCWSTR wszPnPDeviceID, IPortableDevice** ppDevice) { HRESULT hr = S_OK; IPortableDeviceValues* pClientInformation = NULL; IPortableDevice* pDevice = NULL; if ((wszPnPDeviceID == NULL) || (ppDevice == NULL)) { hr = E_INVALIDARG; return hr; } // CoCreate an IPortableDeviceValues interface to hold the client information. hr = CoCreateInstance(CLSID_PortableDeviceValues, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDeviceValues, (VOID**) &amp;pClientInformation); if (SUCCEEDED(hr)) { HRESULT ClientInfoHR = S_OK; // Attempt to set all properties for client information. If we fail to set // any of the properties below it is OK. Failing to set a property in the // client information isn't a fatal error. ClientInfoHR = pClientInformation-&gt;SetStringValue(WPD_CLIENT_NAME, CLIENT_NAME); if (FAILED(ClientInfoHR)) { // Failed to set WPD_CLIENT_NAME } ClientInfoHR = pClientInformation-&gt;SetUnsignedIntegerValue(WPD_CLIENT_MAJOR_VERSION, CLIENT_MAJOR_VER); if (FAILED(ClientInfoHR)) { // Failed to set WPD_CLIENT_MAJOR_VERSION } ClientInfoHR = pClientInformation-&gt;SetUnsignedIntegerValue(WPD_CLIENT_MINOR_VERSION, CLIENT_MINOR_VER); if (FAILED(ClientInfoHR)) { // Failed to set WPD_CLIENT_MINOR_VERSION } ClientInfoHR = pClientInformation-&gt;SetUnsignedIntegerValue(WPD_CLIENT_REVISION, CLIENT_REVISION); if (FAILED(ClientInfoHR)) { // Failed to set WPD_CLIENT_REVISION } } else { // Failed to CoCreateInstance CLSID_PortableDeviceValues for client information } ClientInfoHR = pClientInformation-&gt;SetUnsignedIntegerValue(WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE, SECURITY_IMPERSONATION); if (FAILED(ClientInfoHR)) { // Failed to set WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE } if (SUCCEEDED(hr)) { // CoCreate an IPortableDevice interface hr = CoCreateInstance(CLSID_PortableDeviceFTM, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDevice, (VOID**) &amp;pDevice); if (SUCCEEDED(hr)) { // Attempt to open the device using the PnPDeviceID string given // to this function and the newly created client information. // Note that we're attempting to open the device the first // time using the default (read/write) access. If this fails // with E_ACCESSDENIED, we'll attempt to open a second time // with read-only access. hr = pDevice-&gt;Open(wszPnPDeviceID, pClientInformation); if (hr == E_ACCESSDENIED) { // Attempt to open for read-only access pClientInformation-&gt;SetUnsignedIntegerValue( WPD_CLIENT_DESIRED_ACCESS, GENERIC_READ); hr = pDevice-&gt;Open(wszPnPDeviceID, pClientInformation); } if (SUCCEEDED(hr)) { // The device successfully opened, obtain an instance of the Device into // ppDevice so the caller can be returned an opened IPortableDevice. hr = pDevice-&gt;QueryInterface(IID_IPortableDevice, (VOID**)ppDevice); if (FAILED(hr)) { // Failed to QueryInterface the opened IPortableDevice } } } else { // Failed to CoCreateInstance CLSID_PortableDevice } } // Release the IPortableDevice when finished if (pDevice != NULL) { pDevice-&gt;Release(); pDevice = NULL; } // Release the IPortableDeviceValues that contains the client information when finished if (pClientInformation != NULL) { pClientInformation-&gt;Release(); pClientInformation = NULL; } return hr; }</code>
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-open HRESULT Open(
            // [in] LPCWSTR pszPnPDeviceID, [in] IPortableDeviceValues *pClientInfo );
            void Open([In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In] IPortableDeviceValues pClientInfo);

            /// <summary>The <c>SendCommand</c> method sends a command to the device and retrieves the results synchronously.</summary>
            /// <param name="dwFlags">Currently not used; specify zero.</param>
            /// <param name="pParameters">
            /// <para>
            /// Pointer to an IPortableDeviceValues interface that specifies the command and parameters to call on the device. This
            /// interface must include the following two values to indicate the command. Additional parameters vary depending on the
            /// command. For a list of the parameters that are required for each command, see Commands.
            /// </para>
            /// <list type="table">
            /// <listheader>
            /// <term>Command or property</term>
            /// <term>Description</term>
            /// </listheader>
            /// <item>
            /// <term>WPD_PROPERTY_COMMON_COMMAND_CATEGORY</term>
            /// <term>The category GUID of the command to send. For example, to reset a device, you would send WPD_COMMAND_COMMON_RESET_DEVICE.fmtid.</term>
            /// </item>
            /// <item>
            /// <term>WPD_PROPERTY_COMMON_COMMAND_ID</term>
            /// <term>The PID of the command to send. For example, to reset a device, you would send WPD_COMMAND_COMMON_RESET_DEVICE.pid.</term>
            /// </item>
            /// </list>
            /// </param>
            /// <returns>
            /// An IPortableDeviceValues interface that indicates the results of the command results, including success or failure, and any
            /// command values returned by the device. The caller must release this interface when it is done with it. The retrieved values
            /// vary by command; see the appropriate command documentation in Commands to learn what values are returned by each command call.
            /// </returns>
            /// <remarks>
            /// <para>
            /// This function is used to send a command directly to the driver. A command is a <c>PROPERTYKEY</c> that is sent to the driver
            /// to indicate the expected action, along with a list of required parameters. Each command has a list of required and optional
            /// parameters and results that must be packaged with the command for the driver to perform the requested action. A list of
            /// commands defined by Windows Portable Devices, with the required parameters and return values, is given in Commands.
            /// </para>
            /// <para>
            /// Most Windows Portable Devices methods actually work by sending one or more of the Windows Portable Devices commands for you
            /// and wrapping the parameters for you. Some commands have no corresponding Windows Portable Devices methods. The only way to
            /// call these commands is by using <c>SendCommand</c>. The following commands have no corresponding method:
            /// </para>
            /// <list type="bullet">
            /// <item>
            /// <term>WPD_COMMAND_COMMON_RESET_DEVICE</term>
            /// </item>
            /// <item>
            /// <term>WPD_COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION</term>
            /// </item>
            /// <item>
            /// <term>WPD_COMMAND_SMS_SEND</term>
            /// </item>
            /// <item>
            /// <term>WPD_COMMAND_STILL_IMAGE_CAPTURE_INITIATE</term>
            /// </item>
            /// <item>
            /// <term>WPD_COMMAND_STORAGE_EJECT</term>
            /// </item>
            /// </list>
            /// <para>You also must call <c>SendCommand</c> to send any custom driver commands driver.</para>
            /// <para>
            /// Some custom commands may require a specific Input/Output Control Code (IOCTL) access level. Your application sets this
            /// access level by calling the IPortableDeviceValues::SetUnsignedIntegerValue method on the command parameters that it passes
            /// to the <c>SendCommand</c> method. For example, if a custom command requires read-only access, you would call
            /// <c>SetUnsignedIntegerValue</c> and pass WPD_API_OPTION_IOCTL_ACCESS as the first argument and FILE_READ_ACCESS as the second
            /// argument. By updating these command parameters, your application ensures that the Windows Portable Devices API issues the
            /// command with the read-only IOCTL.
            /// </para>
            /// <para>
            /// Errors that are encountered by the driver while processing a command are retrieved by the ppResults parameter, not by the
            /// <c>SendCommand</c> return value. The return value of this method is any error (or success) code that is encountered while
            /// sending the command to the driver.
            /// </para>
            /// <para>
            /// If a driver does not support the specified command, this method will succeed, but the only guaranteed element in the
            /// returned ppResults parameter will be WPD_PROPERTY_COMMON_HRESULT, which will contain E_NOTIMPL. You can verify whether a
            /// driver supports a command by calling IPortableDeviceCapabilities::GetSupportedCommands before calling a command.
            /// </para>
            /// <para>
            /// If a command supports options (such as delete recursively or delete nonrecursively), you can query for supported options by
            /// calling IPortableDeviceCapabilities::GetCommandOptions.
            /// </para>
            /// <para>
            /// There is no option to set a timeout in a call to <c>SendCommand</c> but the developer can attempt to cancel the command by
            /// calling IPortableDevice::Cancel from a separate thread.
            /// </para>
            /// <para>Examples</para>
            /// <para>
            /// <code> // void ResetDevice(IPortableDevice* pDevice) { HRESULT hr = S_OK; CComPtr&lt;IPortableDeviceValues&gt; pDevValues; hr = CoCreateInstance(CLSID_PortableDeviceValues, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDeviceValues, (VOID**) &amp;pDevValues); if (SUCCEEDED(hr)) { if (pDevValues != NULL) { hr = pDevValues-&gt;SetGuidValue(WPD_PROPERTY_COMMON_COMMAND_CATEGORY, WPD_COMMAND_COMMON_RESET_DEVICE.fmtid); if (FAILED(hr)) { printf("! IPortableDeviceValues::SetGuidValue failed, hr= 0x%lx\n", hr); } hr = pDevValues-&gt;SetUnsignedIntegerValue(WPD_PROPERTY_COMMON_COMMAND_ID, WPD_COMMAND_COMMON_RESET_DEVICE.pid); if (FAILED(hr)) { printf("! IPortableDeviceValues::SetGuidValue failed, hr= 0x%lx\n", hr); } } } hr = pDevice-&gt;SendCommand(0, pDevValues, &amp;pDevValues); if (FAILED(hr)) { printf("! Failed to reset the device, hr = 0x%lx\n",hr); } else printf("Device successfully reset\n"); return; } //</code>
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-sendcommand HRESULT
            // SendCommand( [in] const DWORD dwFlags, [in] IPortableDeviceValues *pParameters, [out] IPortableDeviceValues **ppResults );
            IPortableDeviceValues SendCommand([Optional] UInt32 dwFlags, [In] IPortableDeviceValues pParameters);

            /// <summary>The <c>Content</c> method retrieves an interface that you can use to access objects on a device.</summary>
            /// <returns>
            /// An IPortableDeviceContent interface that is used to access the content on a device. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-content HRESULT
            // Content( [out] IPortableDeviceContent **ppContent );
            IPortableDeviceContent Content();

            /// <summary>The <c>Capabilities</c> method retrieves an interface used to query the capabilities of a portable device.</summary>
            /// <returns>
            /// An IPortableDeviceCapabilities interface that can describe the device's capabilities. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-capabilities
            // HRESULT Capabilities( [out] IPortableDeviceCapabilities **ppCapabilities );
            IPortableDeviceCapabilities Capabilities();

            /// <summary>The <c>Cancel</c> method cancels a pending operation on this interface.</summary>
            /// <remarks>
            /// <para>
            /// If your application invokes the WPD API from multiple threads, each thread should create a new instance of the
            /// IPortableDevice interface. Doing this ensures that any cancel operation affects only the I/O for the affected thread.
            /// </para>
            /// <para>
            /// If an <c>IStream</c> write operation is underway when the <c>Cancel</c> method is invoked, your application should discard
            /// all changes by invoking the <c>IStream::Revert</c> method. Once the changes are discarded, the application should also close
            /// the stream by invoking the <c>IUnknown::Release</c> method.
            /// </para>
            /// <para>
            /// Also, note that if the <c>Cancel</c> method is invoked before an <c>IStream::Write</c> method has completed, the data being
            /// written may be corrupted.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-cancel HRESULT Cancel();
            void Cancel();

            /// <summary>The <c>Close</c> method closes the connection with the device.</summary>
            /// <remarks>
            /// You should not usually need to call this method yourself. When the last reference to the IPortableDevice interface is
            /// released, Windows Portable Devices calls <c>Close</c> for you. Calling this method manually forces the connection to the
            /// device to close, and any Windows Portable Devices objects hosted on this device will cease to function. You can call Open to
            /// reopen the connection.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-close HRESULT Close();
            void Close();

            /// <summary>The <c>Advise</c> method registers an application-defined callback that receives device events.</summary>
            /// <param name="dwFlags"><c>DWORD</c> that specifies option flags.</param>
            /// <param name="pCallback">Pointer to a callback object.</param>
            /// <param name="pParameters">This parameter is ignored and should be set to <c>NULL</c>.</param>
            /// <param name="ppszCookie">
            /// A string that represents a unique context ID. This is used to unregister for callbacks when calling Unadvise.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-advise HRESULT
            // Advise( [in] const DWORD dwFlags, [in] IPortableDeviceEventCallback *pCallback, [in] IPortableDeviceValues *pParameters,
            // [out] LPWSTR *ppszCookie );
            void Advise([Optional] uint dwFlags, IPortableDeviceEventCallback pCallback, [Optional] IPortableDeviceValues pParameters, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

            /// <summary>
            /// The <c>Unadvise</c> method unregisters a client from receiving callback notifications. You must call this method if you
            /// called Advise previously.
            /// </summary>
            /// <param name="pszCookie">A unique context ID. This was retrieved in the initial call to IPortableDevice::Advise.</param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-unadvise HRESULT
            // Unadvise( [in] LPCWSTR pszCookie );
            void Unadvise([In, MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

            /// <summary>
            /// The <c>GetPnPDeviceID</c> method retrieves the Plug and Play (PnP) device identifier that the application used to open the device.
            /// </summary>
            /// <returns>The Plug and Play ID string for the device.</returns>
            /// <remarks>
            /// <para>
            /// After the application is through using the string returned by this method, it must call the CoTaskMemFree function to free
            /// the string.
            /// </para>
            /// <para>The ppszPnPDeviceID argument must not be set to <c>NULL</c>.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevice-getpnpdeviceid
            // HRESULT GetPnPDeviceID( [out] LPWSTR *ppszPnPDeviceID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetPnPDeviceID();
        }

        /// <summary>
        /// The <c>IPortableDeviceCapabilities</c> interface a variety of device capabilities, including supported formats, commands, and
        /// functional objects. You can retrieve this interface from a device by calling <c>IPortableDevice::Capabilities</c>.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicecapabilities
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceCapabilities")]
        [ComImport, Guid("2C8C6DBF-E3DC-4061-BECC-8542E810D126"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceCapabilities
        {
            /// <summary>The <c>GetSupportedCommands</c> method retrieves a list of all the supported commands for this device.</summary>
            /// <returns>
            /// An IPortableDeviceKeyCollection interface that holds all the valid commands. For a list of commands that are defined by
            /// Windows Portable Devices, see Commands. The caller must release this interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getsupportedcommands
            // HRESULT GetSupportedCommands( [out] IPortableDeviceKeyCollection **ppCommands );
            IPortableDeviceKeyCollection GetSupportedCommands();

            /// <summary>The <c>GetCommandOptions</c> method retrieves all the supported options for the specified command on the device.</summary>
            /// <param name="Command">
            /// A <c>REFPROPERTYKEY</c> that specifies a command to query for supported options. For a list of the commands that are defined
            /// by Windows Portable Devices, see Commands.
            /// </param>
            /// <returns>
            /// An IPortableDeviceValues interface that contains the supported options. If no options are supported, this will not contain
            /// any values. The caller must release this interface when it is done with it. For more information, see Remarks.
            /// </returns>
            /// <remarks>
            /// <para>
            /// This method is called by applications that want to call a command directly on the driver by calling
            /// IPortableDevice::SendCommand. Some commands allow the caller to specify additional options. For example, some drivers
            /// support recursive child deletion when deleting an object using the WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS command.
            /// </para>
            /// <para>
            /// If an option is a simple Boolean value, the key of the retrieved IPortableDeviceValues interface will be the name of the
            /// option, and the <c>PROPVARIANT</c> value will be a VT_BOOL value of True or False. If an option has several values, the
            /// retrieved <c>PROPVARIANT</c> value will be a collection type that holds the supported values.
            /// </para>
            /// <para>
            /// If this method is called for the WPD_COMMAND_STORAGE_FORMAT command and the ppOptions parameter is set to
            /// WPD_OPTION_VALID_OBJECT_IDS, the driver will return an IPortableDevicePropVariant collection of type VT_LPWSTR that
            /// specifies the identifiers for each object on the device that can be formatted. (If this option does not exist, the format
            /// command is available for all objects.)
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getcommandoptions
            // HRESULT GetCommandOptions( [in] REFPROPERTYKEY Command, [out] IPortableDeviceValues **ppOptions );
            IPortableDeviceValues GetCommandOptions(in PROPERTYKEY Command);

            /// <summary>The <c>GetFunctionalCategories</c> method retrieves all functional categories supported by the device.</summary>
            /// <returns>
            /// An IPortableDevicePropVariantCollection interface that holds all the functional categories for this device. The values will
            /// be <c>GUID</c> s of type VT_CLSID in the retrieved <c>PROPVARIANT</c> values. The caller must release this interface when it
            /// is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Functional categories describe the types of functions that a device can perform, such as image capture, audio capture, and
            /// storage. This method is typically very fast, because the driver usually queries the device only on startup and caches the results.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method see Retrieving the Functional Categories Supported by a Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getfunctionalcategories
            // HRESULT GetFunctionalCategories( [out] IPortableDevicePropVariantCollection **ppCategories );
            IPortableDevicePropVariantCollection GetFunctionalCategories();

            /// <summary>The GetFunctionalObjects method retrieves all functional objects that match a specified category on the device.</summary>
            /// <param name="Category">
            /// A <c>REFGUID</c> that specifies the category to search for. This can be WPD_FUNCTIONAL_CATEGORY_ALL to return all functional objects.
            /// </param>
            /// <returns>
            /// An IPortableDevicePropVariantCollection interface that contains the object IDs of the functional objects as strings (type
            /// VT_LPWSTR in the retrieved <c>PROPVARIANT</c> items). If no objects of the requested type are found, this will be an empty
            /// collection (not <c>NULL</c>). The caller must release this interface when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// This operation is usually fast, because the driver does not need to perform a full content enumeration, and the number of
            /// retrieved functional objects is typically less than 10. If no objects of the requested type are found, this method will not
            /// return an error, but returns an empty collection for ppObjectIDs.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving the Functional Object Identifiers for a Device</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getfunctionalobjects
            // HRESULT GetFunctionalObjects( [in] REFGUID Category, [out] IPortableDevicePropVariantCollection **ppObjectIDs );
            IPortableDevicePropVariantCollection GetFunctionalObjects(in Guid Category);

            /// <summary>
            /// The <c>GetSupportedContentTypes</c> method retrieves all supported content types for a specified functional object type on a device.
            /// </summary>
            /// <param name="Category">
            /// A <c>REFGUID</c> that specifies a functional object category. To get a list of functional categories on the device, call IPortableDeviceCapabilities::GetFunctionalCategories.
            /// </param>
            /// <returns>
            /// An IPortableDevicePropVariantCollection interface that lists all the supported object types for the specified functional
            /// object category. These object types will be <c>GUID</c> values of type VT_CLSID in the retrieved <c>PROPVARIANT</c> items.
            /// See Requirements for Objects for a list of object types defined by Windows Portable Devices. The caller must release this
            /// interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getsupportedcontenttypes
            // HRESULT GetSupportedContentTypes( [in] REFGUID Category, [out] IPortableDevicePropVariantCollection **ppContentTypes );
            IPortableDevicePropVariantCollection GetSupportedContentTypes(in Guid Category);

            /// <summary>
            /// The <c>GetSupportedFormats</c> method retrieves the supported formats for a specified object type on the device. For
            /// example, specifying audio objects might return <c>WPD_OBJECT_FORMAT_WMA</c>, <c>WPD_OBJECT_FORMAT_WAV</c>, and <c>WPD_OBJECT_FORMAT_MP3</c>.
            /// </summary>
            /// <param name="ContentType">
            /// A <c>REFGUID</c> that specifies a content type, such as image, audio, or video. For a list of content types that are defined
            /// by Windows Portable Devices, see Requirements for Objects.
            /// </param>
            /// <returns>
            /// An IPortableDevicePropVariantCollection interface that lists the supported formats for the specified content type. These are
            /// GUID values (type VT_CLSID) in the retrieved collection items. For a list of formats that are supported by Windows Portable
            /// Devices, see Object Formats. The caller must release this interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getsupportedformats
            // HRESULT GetSupportedFormats( [in] REFGUID ContentType, [out] IPortableDevicePropVariantCollection **ppFormats );
            IPortableDevicePropVariantCollection GetSupportedFormats(in Guid ContentType);

            /// <summary>
            /// The <c>GetSupportedFormatProperties</c> method retrieves the properties supported by objects of a specified format on the device.
            /// </summary>
            /// <param name="Format">
            /// A <c>REFGUID</c> that specifies the format of the object. For a list of formats that are defined by Windows Portable
            /// Devices, see Object Formats.
            /// </param>
            /// <returns>
            /// An IPortableDeviceKeyCollection interface that contains the supported properties for the specified format. For a list of
            /// properties defined by Windows Portable Devices, see Properties and Attributes. The caller must release this interface when
            /// it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>You can specify <c>WPD_OBJECT_FORMAT_ALL</c> for the Format parameter to retrieve the complete set of property attributes.</para>
            /// <para>
            /// If an object does not have a value assigned to a specific property, or if the property was deleted, a device might not
            /// report the property at all when enumerating its properties. Another device might report the property, but with an empty
            /// string or a value of zero. In order to avoid this inconsistency, you can call this method to learn all the properties you
            /// can set on a specific object.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getsupportedformatproperties
            // HRESULT GetSupportedFormatProperties( [in] REFGUID Format, [out] IPortableDeviceKeyCollection **ppKeys );
            IPortableDeviceKeyCollection GetSupportedFormatProperties(in Guid Format);

            /// <summary>
            /// The <c>GetFixedPropertyAttributes</c> method retrieves the standard property attributes for a specified property and format.
            /// Standard attributes are those that have the same value for all objects of the same format. For example, one device might not
            /// allow users to modify video file names; this device would return <c>WPD_PROPERTY_ATTRIBUTE_CAN_WRITE</c> with a value of
            /// False for WMV formatted objects. Attributes that can have different values for a format, or optional attributes, are not returned.
            /// </summary>
            /// <param name="Format">
            /// A <c>REFGUID</c> that specifies the format of the objects of interest. For format <c>GUID</c> values, see Object Formats.
            /// </param>
            /// <param name="Key">
            /// A <c>REFPROPERTYKEY</c> that specifies the property that you want to know the attributes of. Properties defined by Windows
            /// Portable Devices are listed in Properties and Attributes.
            /// </param>
            /// <returns>
            /// An IPortableDeviceValues interface that holds the attributes and their values. The caller must release this interface when
            /// it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>You can specify <c>WPD_OBJECT_FORMAT_ALL</c> for the Format parameter to retrieve the complete set of property attributes.</para>
            /// <para>
            /// Attributes describe properties. Example attributes are <c>WPD_PROPERTY_ATTRIBUTE_CAN_READ</c> and
            /// <c>WPD_PROPERTY_ATTRIBUTE_CAN_WRITE</c>. This method does not retrieve resource attributes.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getfixedpropertyattributes
            // HRESULT GetFixedPropertyAttributes( [in] REFGUID Format, [in] REFPROPERTYKEY Key, [out] IPortableDeviceValues **ppAttributes );
            IPortableDeviceValues GetFixedPropertyAttributes(in Guid Format, in PROPERTYKEY Key);

            /// <summary>The <c>Cancel</c> method cancels a pending request on this interface.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-cancel
            // HRESULT Cancel();
            void Cancel();

            /// <summary>The <c>GetSupportedEvents</c> method retrieves the supported events for this device.</summary>
            /// <returns>
            /// An IPortableDevicePropVariantCollection interface that lists the supported events. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-getsupportedevents
            // HRESULT GetSupportedEvents( [out] IPortableDevicePropVariantCollection **ppEvents );
            IPortableDevicePropVariantCollection GetSupportedEvents();

            /// <summary>The <c>GetEventOptions</c> method retrieves all the supported options for the specified event on the device.</summary>
            /// <param name="Event">
            /// A <c>REFGUID</c> that specifies a event to query for supported options. For a list of the events that are defined by Windows
            /// Portable Devices, see Events.
            /// </param>
            /// <returns>
            /// An IPortableDeviceValues interface that contains the supported options. If no options are supported, this will not contain
            /// any values. The caller must release this interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecapabilities-geteventoptions
            // HRESULT GetEventOptions( [in] REFGUID Event, [out] IPortableDeviceValues **ppOptions );
            IPortableDeviceValues GetEventOptions(in Guid Event);
        }

        /// <summary>
        /// The <c>IPortableDeviceContent</c> interface provides methods to create, enumerate, examine, and delete content on a device. To
        /// get this interface, call <c>IPortableDevice::Content</c>.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicecontent
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceContent")]
        [ComImport, Guid("6A96ED84-7C73-4480-9938-BF5AF477D426"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceContent
        {
            /// <summary>
            /// The <c>EnumObjects</c> method retrieves an interface that is used to enumerate the immediate child objects of an object. It
            /// has an optional filter that can enumerate objects with specific properties.
            /// </summary>
            /// <param name="dwFlags">Currently ignored; specify zero.</param>
            /// <param name="pszParentObjectID">
            /// The ID of the parent. This can be an empty string (but not a <c>NULL</c>
            /// pointer) or the defined constant <c>WPD_DEVICE_OBJECT_ID</c> to indicate the device root.
            /// </param>
            /// <param name="pFilter">This parameter is ignored and should be set to <c>NULL</c>.</param>
            /// <returns>
            /// An IEnumPortableDeviceObjectIDs interface that is used to enumerate the objects that are found. The caller must release this
            /// interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-enumobjects
            // HRESULT EnumObjects( [in] const DWORD dwFlags, [in] LPCWSTR pszParentObjectID, [in] IPortableDeviceValues *pFilter, [out]
            // IEnumPortableDeviceObjectIDs **ppEnum );
            IEnumPortableDeviceObjectIDs EnumObjects([Optional] uint dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
                [In, Optional] IPortableDeviceValues pFilter);

            /// <summary>
            /// The <c>Properties</c> method retrieves the interface that is required to get or set properties on an object on the device.
            /// </summary>
            /// <returns>
            /// An IPortableDeviceProperties interface that is used to get or set object properties. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// The retrieved interface is not specific to a particular object on the device; it is specific only to the device. You must
            /// specify the ID of the object you want when requesting or setting properties.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Setting Properties for a Single Object.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-properties
            // HRESULT Properties( [out] IPortableDeviceProperties **ppProperties );
            IPortableDeviceProperties Properties();

            /// <summary>
            /// The Transfer method retrieves an interface that is used to read from or write to the content data of an existing object resource.
            /// </summary>
            /// <returns>
            /// An IPortableDeviceResources interface that is used to modify an object's resources. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>This method is typically used to read from an existing object.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Adding a Resource to an Object.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-transfer
            // HRESULT Transfer( [out] IPortableDeviceResources **ppResources );
            IPortableDeviceResources Transfer();

            /// <summary>The <c>CreateObjectWithPropertiesOnly</c> method creates an object with only properties on the device.</summary>
            /// <param name="pValues">
            /// An IPortableDeviceValues collection of properties to assign to the object. For a list of required and optional properties
            /// for an object, see Requirements for Objects.
            /// </param>
            /// <returns>
            /// An optional string to receive the name of the new object. Can be <c>NULL</c>, if not needed. Windows Portable Devices
            /// defines the constant WPD_DEVICE_OBJECT_ID to represent a device. The SDK allocates this memory; the caller must release it
            /// using <c>CoTaskMemFree</c>.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Some objects are only a collection of properties—such as a folder, which is only a collection of pointers to other
            /// objects—while other objects are both properties and data—such as an audio file, which contains all the properties and the
            /// actual music bits. This method is used to create an object that contains only properties. To create an object with both
            /// properties and data, use CreateObjectWithPropertiesAndData.
            /// </para>
            /// <para>This method is synchronous; when it returns, the new object should be present on the device.</para>
            /// <para>
            /// The object that the driver actually creates might be a properties-and-data object, depending on what type of object is most
            /// convenient for the driver. To check what kind of object the driver has created, request the WPD_OBJECT_FORMAT property of
            /// the new object.
            /// </para>
            /// <para>The object will be created on the device when this method returns.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Transferring a Properties-Only Object to the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-createobjectwithpropertiesonly
            // HRESULT CreateObjectWithPropertiesOnly( IPortableDeviceValues *pValues, [in, out] LPWSTR *ppszObjectID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string CreateObjectWithPropertiesOnly(IPortableDeviceValues pValues);

            /// <summary>The <c>CreateObjectWithPropertiesAndData</c> method creates an object with both properties and data on the device.</summary>
            /// <param name="pValues">
            /// An <c>IPortableDeviceValues</c> collection of properties to assign to the object. For a list of required and optional
            /// properties for an object, see Requirements for Objects.
            /// </param>
            /// <param name="ppData">
            /// An <c>IStream</c> interface that the application uses to send the object data to the device. The object will not be created
            /// on the device until the application sends the data by calling ppData-&gt; <c>Commit</c>. To abandon a data transfer in
            /// progress, you can call ppData -&gt; <c>Revert</c>. The caller must release this interface when it is done with it. The
            /// underlying object extends both <c>IStream</c> and IPortableDeviceDataStream.
            /// </param>
            /// <param name="pdwOptimalWriteBufferSize">
            /// An optional <c>DWORD</c> pointer that specifies the optimal buffer size for the application to use when writing the data to
            /// ppData. The application can specify <c>TRUE</c> to ignore this.
            /// </param>
            /// <returns>
            /// An optional unique, ID that is used to identify this creation request in the application's implementation of
            /// IPortableDeviceEventCallback (if implemented). When the device finishes creating the object, it will send this identifier to
            /// the callback function. This identifier allows an application to monitor object creation in a different thread from the one
            /// that called CreateObjectWithPropertiesOnly. The SDK allocates this memory, and the caller must release it using <c>CoTaskMemFree</c>.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Some objects are only a collection of properties—such as a folder, which is only a collection of pointers to other
            /// objects—while other objects are both properties and data—such as an audio file, which contains all the properties and the
            /// actual music bits. This method is used to create an object that requires both properties and data. To create a
            /// properties-only object, call CreateObjectWithPropertiesOnly.
            /// </para>
            /// <para>
            /// Because the object is not created until the application calls <c>Commit</c> on the retrieved <c>IStream</c> ppData, the
            /// object will not have an ID until <c>Commit</c> is called on it. <c>Commit</c> is synchronous, so when that method returns
            /// successfully, the object will exist on the device.
            /// </para>
            /// <para>
            /// After calling <c>Commit</c> to create the object, call <c>QueryInterface</c> on ppData for IPortableDeviceDataStream, and
            /// then call IPortableDeviceDataStream::GetObjectID to get the ID of the newly created object.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Transferring an Image or Music File to the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-createobjectwithpropertiesanddata
            // HRESULT CreateObjectWithPropertiesAndData( IPortableDeviceValues *pValues, [out] IStream **ppData, [in, out] DWORD
            // *pdwOptimalWriteBufferSize, [in, out] LPWSTR *ppszCookie );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string CreateObjectWithPropertiesAndData(IPortableDeviceValues pValues, out IStream ppData, [In, Out] ref uint pdwOptimalWriteBufferSize);

            /// <summary>The <c>Delete</c> method deletes one or more objects from the device.</summary>
            /// <param name="dwOptions">One of the DELETE_OBJECT_OPTIONS enumerators.</param>
            /// <param name="pObjectIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that holds one or more null-terminated strings (type VT_LPWSTR)
            /// specifying the object IDs of the objects to delete.
            /// </param>
            /// <returns>
            /// Optional. On return, this parameter contains a collection of VT_ERROR values indicating the success or failure of the
            /// operation. The first element returned in ppResults corresponds to the first object in the pObjectIDs collection, the second
            /// element returned in ppResults corresponds to the second object in the pObjectIDs collection, and so on. This parameter can
            /// be <c>NULL</c> if the application is not concerned with the results.
            /// </returns>
            /// <remarks>
            /// <para>
            /// To see if recursive deletion is supported, call IPortableDeviceCapabilities::GetCommandOptions. If the retrieved
            /// IPortableDeviceValues interface contains a property value called WPD_OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED
            /// with a boolVal value of True, the device supports recursive deletion.
            /// </para>
            /// <para>The following table lists the possible return codes that may appear in the collection at which ppResults points.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Deleting Content from the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-delete
            // HRESULT Delete( [in] const DWORD dwOptions, [in] IPortableDevicePropVariantCollection *pObjectIDs, [in, out]
            // IPortableDevicePropVariantCollection **ppResults );
            IPortableDevicePropVariantCollection Delete(DELETE_OBJECT_OPTIONS dwOptions, IPortableDevicePropVariantCollection pObjectIDs);

            /// <summary>
            /// The <c>GetObjectIDsFromPersistentUniqueIDs</c> method retrieves the current object ID of one or more objects, given their
            /// persistent unique IDs (PUIDs).
            /// </summary>
            /// <param name="pPersistentUniqueIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that contains one or more persistent unique ID (PUID) string
            /// values (type VT_LPWSTR).
            /// </param>
            /// <returns>
            /// Pointer to an <c>IPortableDevicePropVariantCollection</c> interface pointer that contains the retrieved object IDs, as type
            /// <c>VT_LPWSTR</c>. The retrieved IDs will be in the same order as the submitted PUIDs; if a value could not be found, it is
            /// indicated by an empty string. The caller must release this interface when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Windows Portable Devices Object IDs are unique across the device, but may be different across sessions. An Object ID can
            /// change when the application reconnects to the device.
            /// </para>
            /// <para>
            /// Certain applications, such as synchronization engines, require a way to identify the object across connection sessions.
            /// Every object has a WPD_OBJECT_PERSISTENT_UNIQUE_ID property, which indicates an identifier that is persistent across
            /// sessions. Applications can read and save this property in their initial session, by calling the Properties method.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving an Object Identifier from a Persistent Unique Identifier</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-getobjectidsfrompersistentuniqueids
            // HRESULT GetObjectIDsFromPersistentUniqueIDs( [in] IPortableDevicePropVariantCollection *pPersistentUniqueIDs, [out]
            // IPortableDevicePropVariantCollection **ppObjectIDs );
            IPortableDevicePropVariantCollection GetObjectIDsFromPersistentUniqueIDs(IPortableDevicePropVariantCollection pPersistentUniqueIDs);

            /// <summary>The <c>Cancel</c> method cancels a pending operation called on this interface.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-cancel
            // HRESULT Cancel();
            void Cancel();

            /// <summary>The <c>Move</c> method moves one or more objects from one location on the device to another.</summary>
            /// <param name="pObjectIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that holds one or more null-terminated strings (type VT_LPWSTR)
            /// specifying the object IDs of the objects to be moved.
            /// </param>
            /// <param name="pszDestinationFolderObjectID">The ID of the destination.</param>
            /// <returns>
            /// Optional. On return, this parameter contains a collection of VT_ERROR values indicating the success or failure of the
            /// operation. The first element returned in ppResults corresponds to the first object in the pObjectIDs collection, the second
            /// element returned in ppResults corresponds to the second object in the pObjectIDs collection, and so on. This parameter can
            /// be <c>NULL</c> if the application is not concerned with the results.
            /// </returns>
            /// <remarks>
            /// <para>
            /// If the specified device supports move operations on a functional storage, the pszDestinationFolderObjectID parameter may
            /// specify the identifier for a functional storage.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Moving Content on the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-move HRESULT
            // Move( [in] IPortableDevicePropVariantCollection *pObjectIDs, [in] LPCWSTR pszDestinationFolderObjectID, [in, out]
            // IPortableDevicePropVariantCollection **ppResults );
            IPortableDevicePropVariantCollection Move(IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID);

            /// <summary>The <c>Copy</c> method copies objects from one location on a device to another.</summary>
            /// <param name="pObjectIDs">A collection of object identifiers for the objects that this method will copy.</param>
            /// <param name="pszDestinationFolderObjectID">
            /// An object identifier for the destination folder (or functional storage) into which this method will copy the specified objects.
            /// </param>
            /// <returns>
            /// A collection of VT_ERROR values indicating the success or failure of copying a particular element. The first error value
            /// corresponds to the first object in the collection of object identifiers, the second to the second element, and so on. This
            /// argument can be <c>NULL</c>.
            /// </returns>
            /// <remarks>
            /// If the specified device supports copy operations to a functional storage, the pszDestinationFolderObjectID parameter may
            /// specify the identifier for a functional storage.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-copy HRESULT
            // Copy( IPortableDevicePropVariantCollection *pObjectIDs, LPCWSTR pszDestinationFolderObjectID, [out]
            // IPortableDevicePropVariantCollection **ppResults );
            IPortableDevicePropVariantCollection Copy(IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID);
        }

        /// <summary>
        /// The <c>IPortableDeviceContent2</c> interface defines additional methods that provide access to content found on a device.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicecontent2
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceContent2")]
        [ComImport, Guid("9B4ADD96-F6BF-4034-8708-ECA72BF10554"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceContent2 : IPortableDeviceContent
        {
            /// <summary>
            /// The <c>EnumObjects</c> method retrieves an interface that is used to enumerate the immediate child objects of an object. It
            /// has an optional filter that can enumerate objects with specific properties.
            /// </summary>
            /// <param name="dwFlags">Currently ignored; specify zero.</param>
            /// <param name="pszParentObjectID">
            /// The ID of the parent. This can be an empty string (but not a <c>NULL</c>
            /// pointer) or the defined constant <c>WPD_DEVICE_OBJECT_ID</c> to indicate the device root.
            /// </param>
            /// <param name="pFilter">This parameter is ignored and should be set to <c>NULL</c>.</param>
            /// <returns>
            /// An IEnumPortableDeviceObjectIDs interface that is used to enumerate the objects that are found. The caller must release this
            /// interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-enumobjects
            // HRESULT EnumObjects( [in] const DWORD dwFlags, [in] LPCWSTR pszParentObjectID, [in] IPortableDeviceValues *pFilter, [out]
            // IEnumPortableDeviceObjectIDs **ppEnum );
            new IEnumPortableDeviceObjectIDs EnumObjects([Optional] uint dwFlags, [In, MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID,
                [In, Optional] IPortableDeviceValues pFilter);

            /// <summary>
            /// The <c>Properties</c> method retrieves the interface that is required to get or set properties on an object on the device.
            /// </summary>
            /// <returns>
            /// An IPortableDeviceProperties interface that is used to get or set object properties. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// The retrieved interface is not specific to a particular object on the device; it is specific only to the device. You must
            /// specify the ID of the object you want when requesting or setting properties.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Setting Properties for a Single Object.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-properties
            // HRESULT Properties( [out] IPortableDeviceProperties **ppProperties );
            new IPortableDeviceProperties Properties();

            /// <summary>
            /// The Transfer method retrieves an interface that is used to read from or write to the content data of an existing object resource.
            /// </summary>
            /// <returns>
            /// An IPortableDeviceResources interface that is used to modify an object's resources. The caller must release this interface
            /// when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>This method is typically used to read from an existing object.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Adding a Resource to an Object.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-transfer
            // HRESULT Transfer( [out] IPortableDeviceResources **ppResources );
            new IPortableDeviceResources Transfer();

            /// <summary>The <c>CreateObjectWithPropertiesOnly</c> method creates an object with only properties on the device.</summary>
            /// <param name="pValues">
            /// An IPortableDeviceValues collection of properties to assign to the object. For a list of required and optional properties
            /// for an object, see Requirements for Objects.
            /// </param>
            /// <returns>
            /// An optional string to receive the name of the new object. Can be <c>NULL</c>, if not needed. Windows Portable Devices
            /// defines the constant WPD_DEVICE_OBJECT_ID to represent a device. The SDK allocates this memory; the caller must release it
            /// using <c>CoTaskMemFree</c>.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Some objects are only a collection of properties—such as a folder, which is only a collection of pointers to other
            /// objects—while other objects are both properties and data—such as an audio file, which contains all the properties and the
            /// actual music bits. This method is used to create an object that contains only properties. To create an object with both
            /// properties and data, use CreateObjectWithPropertiesAndData.
            /// </para>
            /// <para>This method is synchronous; when it returns, the new object should be present on the device.</para>
            /// <para>
            /// The object that the driver actually creates might be a properties-and-data object, depending on what type of object is most
            /// convenient for the driver. To check what kind of object the driver has created, request the WPD_OBJECT_FORMAT property of
            /// the new object.
            /// </para>
            /// <para>The object will be created on the device when this method returns.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Transferring a Properties-Only Object to the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-createobjectwithpropertiesonly
            // HRESULT CreateObjectWithPropertiesOnly( IPortableDeviceValues *pValues, [in, out] LPWSTR *ppszObjectID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string CreateObjectWithPropertiesOnly(IPortableDeviceValues pValues);

            /// <summary>The <c>CreateObjectWithPropertiesAndData</c> method creates an object with both properties and data on the device.</summary>
            /// <param name="pValues">
            /// An <c>IPortableDeviceValues</c> collection of properties to assign to the object. For a list of required and optional
            /// properties for an object, see Requirements for Objects.
            /// </param>
            /// <param name="ppData">
            /// An <c>IStream</c> interface that the application uses to send the object data to the device. The object will not be created
            /// on the device until the application sends the data by calling ppData-&gt; <c>Commit</c>. To abandon a data transfer in
            /// progress, you can call ppData -&gt; <c>Revert</c>. The caller must release this interface when it is done with it. The
            /// underlying object extends both <c>IStream</c> and IPortableDeviceDataStream.
            /// </param>
            /// <param name="pdwOptimalWriteBufferSize">
            /// An optional <c>DWORD</c> pointer that specifies the optimal buffer size for the application to use when writing the data to
            /// ppData. The application can specify <c>TRUE</c> to ignore this.
            /// </param>
            /// <returns>
            /// An optional unique, ID that is used to identify this creation request in the application's implementation of
            /// IPortableDeviceEventCallback (if implemented). When the device finishes creating the object, it will send this identifier to
            /// the callback function. This identifier allows an application to monitor object creation in a different thread from the one
            /// that called CreateObjectWithPropertiesOnly. The SDK allocates this memory, and the caller must release it using <c>CoTaskMemFree</c>.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Some objects are only a collection of properties—such as a folder, which is only a collection of pointers to other
            /// objects—while other objects are both properties and data—such as an audio file, which contains all the properties and the
            /// actual music bits. This method is used to create an object that requires both properties and data. To create a
            /// properties-only object, call CreateObjectWithPropertiesOnly.
            /// </para>
            /// <para>
            /// Because the object is not created until the application calls <c>Commit</c> on the retrieved <c>IStream</c> ppData, the
            /// object will not have an ID until <c>Commit</c> is called on it. <c>Commit</c> is synchronous, so when that method returns
            /// successfully, the object will exist on the device.
            /// </para>
            /// <para>
            /// After calling <c>Commit</c> to create the object, call <c>QueryInterface</c> on ppData for IPortableDeviceDataStream, and
            /// then call IPortableDeviceDataStream::GetObjectID to get the ID of the newly created object.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Transferring an Image or Music File to the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-createobjectwithpropertiesanddata
            // HRESULT CreateObjectWithPropertiesAndData( IPortableDeviceValues *pValues, [out] IStream **ppData, [in, out] DWORD
            // *pdwOptimalWriteBufferSize, [in, out] LPWSTR *ppszCookie );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            new string CreateObjectWithPropertiesAndData(IPortableDeviceValues pValues, out IStream ppData, [In, Out] ref uint pdwOptimalWriteBufferSize);

            /// <summary>The <c>Delete</c> method deletes one or more objects from the device.</summary>
            /// <param name="dwOptions">One of the DELETE_OBJECT_OPTIONS enumerators.</param>
            /// <param name="pObjectIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that holds one or more null-terminated strings (type VT_LPWSTR)
            /// specifying the object IDs of the objects to delete.
            /// </param>
            /// <returns>
            /// Optional. On return, this parameter contains a collection of VT_ERROR values indicating the success or failure of the
            /// operation. The first element returned in ppResults corresponds to the first object in the pObjectIDs collection, the second
            /// element returned in ppResults corresponds to the second object in the pObjectIDs collection, and so on. This parameter can
            /// be <c>NULL</c> if the application is not concerned with the results.
            /// </returns>
            /// <remarks>
            /// <para>
            /// To see if recursive deletion is supported, call IPortableDeviceCapabilities::GetCommandOptions. If the retrieved
            /// IPortableDeviceValues interface contains a property value called WPD_OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED
            /// with a boolVal value of True, the device supports recursive deletion.
            /// </para>
            /// <para>The following table lists the possible return codes that may appear in the collection at which ppResults points.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Deleting Content from the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-delete
            // HRESULT Delete( [in] const DWORD dwOptions, [in] IPortableDevicePropVariantCollection *pObjectIDs, [in, out]
            // IPortableDevicePropVariantCollection **ppResults );
            new IPortableDevicePropVariantCollection Delete(DELETE_OBJECT_OPTIONS dwOptions, IPortableDevicePropVariantCollection pObjectIDs);

            /// <summary>
            /// The <c>GetObjectIDsFromPersistentUniqueIDs</c> method retrieves the current object ID of one or more objects, given their
            /// persistent unique IDs (PUIDs).
            /// </summary>
            /// <param name="pPersistentUniqueIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that contains one or more persistent unique ID (PUID) string
            /// values (type VT_LPWSTR).
            /// </param>
            /// <returns>
            /// Pointer to an <c>IPortableDevicePropVariantCollection</c> interface pointer that contains the retrieved object IDs, as type
            /// <c>VT_LPWSTR</c>. The retrieved IDs will be in the same order as the submitted PUIDs; if a value could not be found, it is
            /// indicated by an empty string. The caller must release this interface when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Windows Portable Devices Object IDs are unique across the device, but may be different across sessions. An Object ID can
            /// change when the application reconnects to the device.
            /// </para>
            /// <para>
            /// Certain applications, such as synchronization engines, require a way to identify the object across connection sessions.
            /// Every object has a WPD_OBJECT_PERSISTENT_UNIQUE_ID property, which indicates an identifier that is persistent across
            /// sessions. Applications can read and save this property in their initial session, by calling the Properties method.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving an Object Identifier from a Persistent Unique Identifier</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-getobjectidsfrompersistentuniqueids
            // HRESULT GetObjectIDsFromPersistentUniqueIDs( [in] IPortableDevicePropVariantCollection *pPersistentUniqueIDs, [out]
            // IPortableDevicePropVariantCollection **ppObjectIDs );
            new IPortableDevicePropVariantCollection GetObjectIDsFromPersistentUniqueIDs(IPortableDevicePropVariantCollection pPersistentUniqueIDs);

            /// <summary>The <c>Cancel</c> method cancels a pending operation called on this interface.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-cancel
            // HRESULT Cancel();
            new void Cancel();

            /// <summary>The <c>Move</c> method moves one or more objects from one location on the device to another.</summary>
            /// <param name="pObjectIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that holds one or more null-terminated strings (type VT_LPWSTR)
            /// specifying the object IDs of the objects to be moved.
            /// </param>
            /// <param name="pszDestinationFolderObjectID">The ID of the destination.</param>
            /// <returns>
            /// Optional. On return, this parameter contains a collection of VT_ERROR values indicating the success or failure of the
            /// operation. The first element returned in ppResults corresponds to the first object in the pObjectIDs collection, the second
            /// element returned in ppResults corresponds to the second object in the pObjectIDs collection, and so on. This parameter can
            /// be <c>NULL</c> if the application is not concerned with the results.
            /// </returns>
            /// <remarks>
            /// <para>
            /// If the specified device supports move operations on a functional storage, the pszDestinationFolderObjectID parameter may
            /// specify the identifier for a functional storage.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Moving Content on the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-move HRESULT
            // Move( [in] IPortableDevicePropVariantCollection *pObjectIDs, [in] LPCWSTR pszDestinationFolderObjectID, [in, out]
            // IPortableDevicePropVariantCollection **ppResults );
            new IPortableDevicePropVariantCollection Move(IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID);

            /// <summary>The <c>Copy</c> method copies objects from one location on a device to another.</summary>
            /// <param name="pObjectIDs">A collection of object identifiers for the objects that this method will copy.</param>
            /// <param name="pszDestinationFolderObjectID">
            /// An object identifier for the destination folder (or functional storage) into which this method will copy the specified objects.
            /// </param>
            /// <returns>
            /// A collection of VT_ERROR values indicating the success or failure of copying a particular element. The first error value
            /// corresponds to the first object in the collection of object identifiers, the second to the second element, and so on. This
            /// argument can be <c>NULL</c>.
            /// </returns>
            /// <remarks>
            /// If the specified device supports copy operations to a functional storage, the pszDestinationFolderObjectID parameter may
            /// specify the identifier for a functional storage.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent-copy HRESULT
            // Copy( IPortableDevicePropVariantCollection *pObjectIDs, LPCWSTR pszDestinationFolderObjectID, [out]
            // IPortableDevicePropVariantCollection **ppResults );
            new IPortableDevicePropVariantCollection Copy(IPortableDevicePropVariantCollection pObjectIDs, [MarshalAs(UnmanagedType.LPWStr)] string pszDestinationFolderObjectID);

            /// <summary>
            /// The <c>UpdateObjectWithPropertiesAndData</c> method updates an object by using properties and data found on the device.
            /// </summary>
            /// <param name="pszObjectID">The identifier of the object to update.</param>
            /// <param name="pProperties">The IPortableDeviceValues interface that specifies the object properties to be updated.</param>
            /// <param name="ppData">The <c>IStream</c> interface through which the object data is sent to the device.</param>
            /// <param name="pdwOptimalWriteBufferSize">
            /// The optimal buffer size for writing the object data to ppData, or <c>NULL</c> if the buffer size is ignored.
            /// </param>
            /// <remarks>
            /// <para>
            /// Device formats and object formats can derive some of their object properties from the data itself. Or, they can have
            /// property values that depend on the data. For example, a music track has a duration property that is specified when an
            /// application calls the IPortableDeviceContent::CreateObjectWithPropertiesAndData method. If this track is stored as a default
            /// resource (WPD_RESOURCE_DEFAULT), the application might update it. The application additionally mighthave to update the
            /// duration property. This method lets the application perform both updates at the same time.
            /// </para>
            /// <para>An update is incomplete until the <c>IStream::Commit</c> method is called on the object referenced by the ppData parameter.</para>
            /// <para>
            /// To abandon a data transfer in progress, an application should call the <c>IStream::Revert</c> method on the object
            /// referenced by the ppData parameter.
            /// </para>
            /// <para>
            /// The <c>IStream</c> interface object referenced by the ppData parameter must be released after the update operation is
            /// complete, or, is canceled.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicecontent2-updateobjectwithpropertiesanddata
            // HRESULT UpdateObjectWithPropertiesAndData( [in] LPCWSTR pszObjectID, [in] IPortableDeviceValues *pProperties, [out] IStream
            // **ppData, [in, out] DWORD *pdwOptimalWriteBufferSize );
            void UpdateObjectWithPropertiesAndData([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, IPortableDeviceValues pProperties,
                out IStream ppData, out uint pdwOptimalWriteBufferSize);
        }

        /// <summary>
        /// The <c>IPortableDeviceDataStream</c> interface exposes additional methods on an <c>IStream</c> that is used for data transfers.
        /// It is obtained by calling <c>QueryInterface</c> on the <c>IStream</c> that is retrieved by IPortableDeviceResources::GetStream
        /// or IPortableDeviceContent::CreateObjectWithPropertiesAndData.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicedatastream
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceDataStream")]
        [ComImport, Guid("88e04db3-1012-4d64-9996-f703a950d3f4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceDataStream : IStream
        {
            /// <inheritdoc/>
            new void Read(byte[] pv, int cb, IntPtr pcbRead);

            /// <inheritdoc/>
            new void Write(byte[] pv, int cb, IntPtr pcbWritten);

            /// <inheritdoc/>
            new void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

            /// <inheritdoc/>
            new void SetSize(long libNewSize);

            /// <inheritdoc/>
            new void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

            /// <inheritdoc/>
            new void Commit(int grfCommitFlags);

            /// <inheritdoc/>
            new void Revert();

            /// <inheritdoc/>
            new void LockRegion(long libOffset, long cb, int dwLockType);

            /// <inheritdoc/>
            new void UnlockRegion(long libOffset, long cb, int dwLockType);

            /// <inheritdoc/>
            new void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, int grfStatFlag);

            /// <inheritdoc/>
            new void Clone(out IStream ppstm);

            /// <summary>
            /// The <c>GetObjectID</c> method retrieves the object ID of the resource that was written to the device. This method is only
            /// valid after calling <c>IStream::Commit</c> on the data stream.
            /// </summary>
            /// <returns>The ID of the object just transferred to the device.</returns>
            /// <remarks>
            /// An object ID is created after the object is created on the device. Therefore, a new object that is created by calling
            /// IPortableDeviceContent::CreateObjectWithPropertiesAndData will not have an ID assigned until the application calls
            /// <c>Commit</c> on the data transfer stream.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicedatastream-getobjectid
            // HRESULT GetObjectID( [out] LPWSTR *ppszObjectID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetObjectID();

            /// <summary>The <c>Cancel</c> method cancels a call in progress on this interface.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicedatastream-cancel
            // HRESULT Cancel();
            void Cancel();
        }

        /// <summary>Represents a factory that can instantiate a WPD Automation Device object.</summary>
        /// <remarks>
        /// <para>
        /// The <c>IPortableDeviceDispatchFactory</c> interface can be CoCreated directly using <c>CLSID_PortableDeviceDispatchFactory</c>
        /// as in the following code.
        /// </para>
        /// <code>
        ///<![CDATA[
        ///IPortableDeviceDispatchFactgory* pDeviceDispatchFactory = NULL;
        ///HRESULT hr = CoCreateInstance(CLSID_PortableDeviceDispatchFactory, NULL, CLSCTX_INPROC_SERVER, IID_PPV_ARGS(&amp;pDeviceDispatchFactory));
        ///]]>
        /// </code>
        /// <para>Examples</para>
        /// <para>
        /// For an example of how to use the <c>IPortableDeviceDispatchFactory</c> interface to instantiate a WPD Automation <c>Device</c>
        /// object, see Instantiating the WPD Automation Factory Interface.
        /// </para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicedispatchfactory
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceDispatchFactory")]
        [ComImport, Guid("5e1eafc3-e3d7-4132-96fa-759c0f9d1e0f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PortableDeviceDispatchFactory))]
        public interface IPortableDeviceDispatchFactory
        {
            /// <summary>Instantiates a WPD Automation Device object for a given WPD device identifier.</summary>
            /// <param name="pszPnPDeviceID">
            /// A pointer to a <c>String</c> that is used by Plug-and-play to identify a currently connected WPD device. The Plug and Play
            /// (PnP) identifier for a particular device can be obtained from the IPortableDeviceManager::GetDevices method in the WPD
            /// C++/COM API.
            /// </param>
            /// <returns>Contains a pointer to the <c>IDispatch</c> implementation for the WPD Automation Device object.</returns>
            /// <remarks>
            /// For an example of how to use <c>GetDeviceDispatch</c> method to instantiate a WPD Automation <c>Device</c> object, see
            /// Instantiating the WPD Automation Factory Interface.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicedispatchfactory-getdevicedispatch
            // HRESULT GetDeviceDispatch( [in] LPCWSTR pszPnPDeviceID, [out] IDispatch **ppDeviceDispatch );
            [return: MarshalAs(UnmanagedType.IDispatch)]
            object GetDeviceDispatch([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID);
        }

        /// <summary>
        /// The <c>IPortableDeviceEventCallback</c> interface implemented by the application to receive asynchronous callbacks if an
        /// application has registered to receive them by calling IPortableDevice::Advise.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceeventcallback
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceEventCallback")]
        [ComImport, Guid("A8792A31-F385-493C-A893-40F64EB45F6E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceEventCallback
        {
            /// <summary>The <c>OnEvent</c> method is called by the SDK to notify the application about asynchronous events.</summary>
            /// <param name="pEventParameters">Pointer to an IPortableDeviceValues interface that contains event details.</param>
            /// <returns>Any values returned by the application are ignored by Windows Portable Devices.</returns>
            /// <remarks>
            /// <para>The application must register to receive events by calling IPortableDevice::Advise.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Handling Events from the Device.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceeventcallback-onevent
            // HRESULT OnEvent( [in] IPortableDeviceValues *pEventParameters );
            void OnEvent([Optional] IPortableDeviceValues pEventParameters);
        }

        /// <summary>
        /// <para>
        /// Enumerates devices that are connected to the computer and provides a simple way to request installation information, including
        /// manufacturer, friendly name, and description. This is typically the first Windows Portable Devices interface created by an
        /// application. To create an instance of this interface, call <c>CoCreateInstance</c> and specify <c>CLSID_PortableDeviceManager</c>.
        /// </para>
        /// <para>
        /// The properties that are requested using this interface can also be requested by using the IPortableDeviceProperties interface.
        /// However, that interface requires several steps to acquire; using this interface is a much simpler way to request device information.
        /// </para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicemanager
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceManager")]
        [ComImport, Guid("a1567595-4c2f-4574-a6fa-ecef917b9a40"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PortableDeviceManager))]
        public interface IPortableDeviceManager
        {
            /// <summary>Retrieves a list of portable devices connected to the computer.</summary>
            /// <param name="pPnPDeviceIDs">
            /// A caller-allocated array of strings that holds the Plug and Play names of all of the connected devices. To learn the
            /// required size for this parameter, first call this method with this parameter set to <c>NULL</c> and pcPnPDeviceIDs set to
            /// zero, and then allocate a buffer according to the value retrieved by pcPnPDeviceIDs. These names can be used by
            /// IPortableDevice::Open to create a connection to a device.
            /// </param>
            /// <param name="pcPnPDeviceIDs">
            /// On input, the number of values that pPnPDeviceIDs can hold. On output, a pointer to the number of devices actually written
            /// to pPnPDeviceIDs.
            /// </param>
            /// <remarks>
            /// <para>
            /// The list of devices is generated when the device manager is instantiated; it does not refresh as devices connect and
            /// disconnect. To refresh the list of connected devices, call RefreshDeviceList.
            /// </para>
            /// <para>
            /// The API allocates the memory for each string pointed to by the pPnPDeviceIDs array. Once your application no longer needs
            /// these strings, it must iterate through this array and free the associated memory by calling the <c>CoTaskMemFree</c> function.
            /// </para>
            /// <para>Examples</para>
            /// <para>
            /// For an example of how to use this method to enumerate devices, see Enumerating Devices. For an example of how to use this
            /// method to enumerate Services, see Enumerating Services.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getdevices
            // HRESULT GetDevices( [in, out] LPWSTR *pPnPDeviceIDs, [in, out] DWORD *pcPnPDeviceIDs );
            [PreserveSig]
            HRESULT GetDevices([In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] pPnPDeviceIDs,
                ref uint pcPnPDeviceIDs);

            /// <summary>The <c>RefreshDeviceList</c> method refreshes the list of devices that are connected to the computer.</summary>
            /// <remarks>
            /// <para>
            /// When the <c>IPortableDeviceManager</c> interface is instantiated the first time, it generates a list of the devices that are
            /// connected. However, devices can connect and disconnect from the computer, making the original list obsolete. This method
            /// enables an application to refresh the list of connected devices.
            /// </para>
            /// <para>
            /// This method is less resource-intensive than instantiating a new device manager to generate a new device list. However, it
            /// does require some resources; therefore, we recommend that you do not call this method arbitrarily. The best solution is to
            /// have the application register to get device arrival and removal notifications, and when a notification is received, have the
            /// application call this function.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-refreshdevicelist
            // HRESULT RefreshDeviceList();
            void RefreshDeviceList();

            /// <summary>Retrieves the user-friendly name for the device.</summary>
            /// <param name="pszPnPDeviceID">
            /// The device's Plug and Play ID. You can retrieve a list of Plug and Play names of all devices that are connected to the
            /// computer by calling GetDevices.
            /// </param>
            /// <param name="pDeviceFriendlyName">
            /// A caller-allocated buffer that is used to hold the user-friendly name for the device. To learn the required size for this
            /// parameter, first call this method with this parameter set to <c>NULL</c> and pcchDeviceFriendlyName set to <c>0</c>; the
            /// method will succeed and set pcchDeviceFriendlyName to the required buffer size to hold the device-friendly name, including
            /// the termination character.
            /// </param>
            /// <param name="pcchDeviceFriendlyName">
            /// On input, the maximum number of characters that pDeviceFriendlyName can hold, not including the termination character. On
            /// output, the number of characters that is returned by pDeviceFriendlyName, not including the termination character.
            /// </param>
            /// <remarks>
            /// A device is not required to support this method. If this method fails to retrieve a name, try requesting the WPD_OBJECT_NAME
            /// property of the device object (the object with the ID WPD_DEVICE_OBJECT_ID).
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getdevicefriendlyname
            // HRESULT GetDeviceFriendlyName( [in] LPCWSTR pszPnPDeviceID, [in, out] WCHAR *pDeviceFriendlyName, [in, out] DWORD
            // *pcchDeviceFriendlyName );
            [PreserveSig]
            HRESULT GetDeviceFriendlyName([In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceFriendlyName,
                [In, Out] ref uint pcchDeviceFriendlyName);

            /// <summary>Retrieves the description of a device.</summary>
            /// <param name="pszPnPDeviceID">
            /// The device's Plug and Play ID. You can retrieve a list of Plug and Play names of devices that are currently connected by
            /// calling GetDevices.
            /// </param>
            /// <param name="pDeviceDescription">
            /// A caller-allocated buffer to hold the user-description name of the device. The caller must allocate the memory for this
            /// parameter. To learn the required size for this parameter, first call this method with this parameter set to <c>NULL</c> and
            /// pcchDeviceDescription set to <c>0</c>; the method will succeed and set pcchDeviceDescription to the required buffer size to
            /// hold the device-friendly name, including the termination character.
            /// </param>
            /// <param name="pcchDeviceDescription">
            /// The number of characters (not including the termination character) in pDeviceDescription. On input, the maximum length of
            /// pDeviceDescription; on output, the length of the returned string in pDeviceDescription.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getdevicedescription
            // HRESULT GetDeviceDescription( [in] LPCWSTR pszPnPDeviceID, [in, out] WCHAR *pDeviceDescription, [in, out] DWORD
            // *pcchDeviceDescription );
            [PreserveSig]
            HRESULT GetDeviceDescription([In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceDescription,
                [In, Out] ref uint pcchDeviceDescription);

            /// <summary>Retrieves the name of the device manufacturer.</summary>
            /// <param name="pszPnPDeviceID">
            /// The device's Plug and Play ID. You can retrieve a list of Plug and Play names of all devices that are connected to the
            /// computer by calling GetDevices.
            /// </param>
            /// <param name="pDeviceManufacturer">
            /// A caller-allocated buffer that holds the name of the device manufacturer. To learn the required size for this parameter,
            /// first call this method with this parameter set to <c>NULL</c> and pcchDeviceManufacturer set to <c>0</c>; the method will
            /// succeed and set pcchDeviceManufacturer to the required buffer size to hold the device-friendly name, including the
            /// termination character.
            /// </param>
            /// <param name="pcchDeviceManufacturer">
            /// On input, the maximum number of characters that pDeviceManufacturer can hold, not including the termination character. On
            /// output, the number of characters returned by pDeviceManufacturer, not including the termination character.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getdevicemanufacturer
            // HRESULT GetDeviceManufacturer( [in] LPCWSTR pszPnPDeviceID, [in, out] WCHAR *pDeviceManufacturer, [in, out] DWORD
            // *pcchDeviceManufacturer );
            [PreserveSig]
            HRESULT GetDeviceManufacturer([In, MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [In, Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pDeviceManufacturer,
                [In, Out] ref uint pcchDeviceManufacturer);

            /// <summary>
            /// Retrieves a property value stored by the device on the computer. (These are not standard properties that are defined by
            /// Windows Portable Devices.)
            /// </summary>
            /// <param name="pszPnPDeviceID">
            /// The device's Plug and Play ID. You can retrieve a list of Plug and Play names of all devices that are connected to the
            /// computer by calling GetDevices.
            /// </param>
            /// <param name="pszDevicePropertyName">
            /// The name of the property to request. These are custom property names defined by a device manufacturer.
            /// </param>
            /// <param name="pData">
            /// A caller-allocated buffer to hold the retrieved data. To get the size required, call this method with this parameter set to
            /// <c>NULL</c> and pcbData set to zero, and the required size will be retrieved in pcbData. This call will also return an error
            /// that can be ignored. See Return Values.
            /// </param>
            /// <param name="pcbData">The size of the buffer allocated or returned by pData, in bytes.</param>
            /// <param name="pdwType">
            /// A constant describing the type of data returned in pData. The values for this parameter are the same types used to describe
            /// the lpType parameter of the Platform SDK function <c>RegQueryValueEx</c>.
            /// </param>
            /// <remarks>
            /// <para>
            /// These property values are stored on device installation, or stored by a device during operation so that they can be
            /// persisted across connection sessions. An application must know the exact name of the property, which is specified by the
            /// device itself; therefore, this method is intended to be used by device developers who are creating their own applications.
            /// </para>
            /// <para>
            /// To get Windows Portable Devices properties from the device object, call IPortableDeviceProperties::GetValues, and specify
            /// the device object with <c>WPD_DEVICE_OBJECT_ID</c>.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getdeviceproperty
            // HRESULT GetDeviceProperty( [in] LPCWSTR pszPnPDeviceID, [in] LPCWSTR pszDevicePropertyName, [in, out] BYTE *pData, [in, out]
            // DWORD *pcbData, [in, out] DWORD *pdwType );
            [PreserveSig]
            HRESULT GetDeviceProperty([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, [MarshalAs(UnmanagedType.LPWStr)] string pszDevicePropertyName,
                [In, Out] IntPtr pData, ref uint pcbData, out REG_VALUE_TYPE pdwType);

            /// <summary>
            /// The <c>GetPrivateDevices</c> method retrieves a list of private portable devices connected to the computer. These private
            /// devices are only accessible through an application that is designed for these particular devices.
            /// </summary>
            /// <param name="pPnPDeviceIDs">
            /// A caller-allocated array of strings that holds the Plug and Play names of all of the connected devices. To learn the
            /// required size for this parameter, first call this method with this parameter set to <c>NULL</c> and pcPnPDeviceIDs set to
            /// zero, and then allocate a buffer according to the value retrieved by pcPnPDeviceIDs. These names can be used by
            /// IPortableDevice::Open to create a connection to a device.
            /// </param>
            /// <param name="pcPnPDeviceIDs">
            /// On input, the number of values that pPnPDeviceIDs can hold. On output, a pointer to the number of devices actually written
            /// to pPnPDeviceIDs.
            /// </param>
            /// <remarks>
            /// <para>
            /// In order to write an application that communicates with a private device, you must have knowledge of the custom
            /// functionality exposed by a particular device driver. The description of this functionality must be obtained from the device manufacturer.
            /// </para>
            /// <para>
            /// The list of devices is generated when the device manager is instantiated; it does not refresh as devices connect and
            /// disconnect. To refresh the list of connected devices, call RefreshDeviceList.
            /// </para>
            /// <para>
            /// The API allocates the memory for each string pointed to by the pPnPDeviceIDs array. Once your application no longer needs
            /// these strings, it must iterate through this array and free the associated memory by calling the <c>CoTaskMemFree</c> function.
            /// </para>
            /// <para>
            /// A private device may not respond correctly to the standard Windows Portable Devices function calls that perform object
            /// enumeration, resource transfer, retrieval of device capabilities, and so on.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getprivatedevices
            // HRESULT GetPrivateDevices( [in, out] LPWSTR *pPnPDeviceIDs, [in, out] DWORD *pcPnPDeviceIDs );
            [PreserveSig]
            HRESULT GetPrivateDevices([In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] pPnPDeviceIDs, ref uint pcPnPDeviceIDs);
        }

        /// <summary>
        /// The <c>IPortableDeviceProperties</c> interface retrieves, adds, or deletes properties from an object on a device, or the device
        /// itself. To get this interface, call IPortableDeviceContent::Properties on an object. To get this interface for the object,
        /// specify <c>WPD_DEVICE_OBJECT_ID</c> in <c>GetValues</c>.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceproperties
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceProperties")]
        [ComImport, Guid("7F6D695C-03DF-4439-A809-59266BEEE3A6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceProperties
        {
            /// <summary>
            /// The <c>GetSupportedProperties</c> method retrieves a list of properties that a specified object supports. Note that not all
            /// of these properties may actually have values.
            /// </summary>
            /// <param name="pszObjectID">The object ID of the object to query. To specify the device, use <c>WPD_DEVICE_OBJECT_ID</c>.</param>
            /// <returns>
            /// An IPortableDeviceKeyCollection interface that contains the supported properties. For a list of properties defined by
            /// Windows Portable Devices, see Properties and Attributes. The caller must release this interface when it is done with it.
            /// </returns>
            /// <remarks>To get the values of supported properties, call <c>GetPropertyAttributes</c>.</remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceproperties-getsupportedproperties
            // HRESULT GetSupportedProperties( [in] LPCWSTR pszObjectID, [out] IPortableDeviceKeyCollection **ppKeys );
            IPortableDeviceKeyCollection GetSupportedProperties([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID);

            /// <summary>The <c>GetPropertyAttributes</c> method retrieves attributes of a specified object property on a device.</summary>
            /// <param name="pszObjectID">The object ID of the object to query. To specify the device, use <c>WPD_DEVICE_OBJECT_ID</c>.</param>
            /// <param name="Key">
            /// A <c>REFPROPERTYKEY</c> that specifies the property to query for. You can retrieve a list of supported properties by calling
            /// GetSupportedProperties. For a list of properties that are defined by Windows Portable Devices, see Properties and Attributes.
            /// </param>
            /// <returns>
            /// An IPortableDeviceValues interface that holds the retrieved property attributes. These are PROPERTYKEY/value pairs, where
            /// the <c>PROPERTYKEY</c> is the property, and the value data type depends on the specific property. The caller must release
            /// this interface when it is done with it. Attributes defined by Windows Portable Devices can be found on the Properties and
            /// Attributes page.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Property attributes describe a property's access rights, valid values, and other information. For example, a property can
            /// have a WPD_PROPERTY_ATTRIBUTE_CAN_DELETE value set to False to prevent deletion, and have a range of valid values stored as
            /// individual entries.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Setting Properties for a Single Object.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceproperties-getpropertyattributes
            // HRESULT GetPropertyAttributes( [in] LPCWSTR pszObjectID, [in] REFPROPERTYKEY Key, [out] IPortableDeviceValues **ppAttributes );
            IPortableDeviceValues GetPropertyAttributes([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, in PROPERTYKEY Key);

            /// <summary>The <c>GetValues</c> method retrieves a list of specified properties from a specified object on a device.</summary>
            /// <param name="pszObjectID">The ID of the object to query. To specify the device, use WPD_DEVICE_OBJECT_ID.</param>
            /// <param name="pKeys">
            /// Pointer to an IPortableDeviceKeyCollection interface that contains one or more properties to query for. If this is
            /// <c>NULL</c>, all properties will be retrieved. See Properties and Attributes for a list of properties that are defined by
            /// Windows Portable Devices.
            /// </param>
            /// <returns>
            /// An IPortableDeviceValues interface that contains the requested property values. These will be returned as PROPERTYKEY/value
            /// pairs, where the data type of the value depends on the property. If a value could not be retrieved for some reason, the
            /// returned type will be VT_ERROR, and contain an HRESULT value describing the retrieval error. The caller must release this
            /// interface when it is done with it.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceproperties-getvalues
            // HRESULT GetValues( [in] LPCWSTR pszObjectID, [in] IPortableDeviceKeyCollection *pKeys, [out] IPortableDeviceValues **ppValues );
            IPortableDeviceValues GetValues([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, IPortableDeviceKeyCollection pKeys);

            /// <summary>The <c>SetValues</c> method adds or modifies one or more properties on a specified object on a device.</summary>
            /// <param name="pszObjectID">The object ID of the object to modify. To specify the device, use WPD_DEVICE_OBJECT_ID.</param>
            /// <param name="pValues">
            /// Pointer to an IPortableDeviceValues interface that contains one or more property/value pairs to set. Existing values will be overwritten.
            /// </param>
            /// <returns>
            /// An <c>IPortableDeviceValues</c> interface that contains a collection of property/HRESULT values. Each value (type VT_ERROR)
            /// describes the success or failure of the property set attempt. The caller must release this interface when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// To delete a property, call IPortableDeviceProperties::Delete. A property can be deleted only if its
            /// WPD_PROPERTY_ATTRIBUTE_CAN_WRITE attribute is True. This attribute can be retrieved by calling GetPropertyAttributes.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Setting Properties for a Single Object.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceproperties-setvalues
            // HRESULT SetValues( [in] LPCWSTR pszObjectID, [in] IPortableDeviceValues *pValues, [out] IPortableDeviceValues **ppResults );
            IPortableDeviceValues SetValues([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, IPortableDeviceValues pValues);

            /// <summary>The <c>Delete</c> method deletes specified properties from a specified object on a device.</summary>
            /// <param name="pszObjectID">The ID of the object whose properties you will delete. To specify the device, use <c>WPD_DEVICE_OBJECT_ID</c>.</param>
            /// <param name="pKeys">
            /// Pointer to an IPortableDeviceKeyCollection interface that specifies which properties to delete. For a list of properties
            /// defined by Windows Portable Devices, see Properties and Attributes.
            /// </param>
            /// <remarks>
            /// <para>
            /// Properties can be deleted only if their WPD_PROPERTY_ATTRIBUTE_CAN_DELETE attribute is True. This attribute can be retrieved
            /// by calling GetPropertyAttributes.
            /// </para>
            /// <para>
            /// The driver has no way to indicate partial success; that is, if only some properties could be deleted, the driver will return
            /// <c>S_FALSE</c>, but this method does not indicate which properties were successfully deleted. The only way to learn which
            /// properties were deleted is to request all properties by calling IPortableDeviceProperties::GetValues.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceproperties-delete
            // HRESULT Delete( [in] LPCWSTR pszObjectID, [in] IPortableDeviceKeyCollection *pKeys );
            void Delete([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, IPortableDeviceKeyCollection pKeys);

            /// <summary>The <c>Cancel</c> method cancels a pending call.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceproperties-cancel
            // HRESULT Cancel();
            void Cancel();
        }

        /// <summary>
        /// <para>
        /// The <c>IPortableDevicePropertiesBulk</c> interface queries or sets multiple properties on multiple objects on a device,
        /// asynchronously. Information is returned by an application-implemented IPortableDevicePropertiesBulkCallback interface.
        /// </para>
        /// <para>
        /// To get this interface, call <c>QueryInterface</c> on <c>IPortableDeviceProperties</c>. If the device does not support bulk
        /// operations, this call will fail with E_NOINTERFACE.
        /// </para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicepropertiesbulk
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDevicePropertiesBulk")]
        [ComImport, Guid("482b05c0-4056-44ed-9e0f-5e23b009da93"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDevicePropertiesBulk
        {
            /// <summary>
            /// The <c>QueueGetValuesByObjectList</c> method queues a request for one or more specified properties from one or more
            /// specified objects on the device.
            /// </summary>
            /// <param name="pObjectIDs">
            /// Pointer to an IPortableDevicePropVariantCollection interface that lists the object IDs of all the objects to query. These
            /// will be of type VT_LPWSTR.
            /// </param>
            /// <param name="pKeys">
            /// Pointer to an IPortableDeviceKeyCollection interface that specifies the properties to request. For a list of properties
            /// defined by Windows Portable Devices, see Properties and Attributes. Specify <c>NULL</c> to indicate all properties from the
            /// specified objects.
            /// </param>
            /// <param name="pCallback">
            /// Pointer to an application-implemented IPortableDevicePropertiesBulkCallback interface that will receive the information as
            /// it is retrieved.
            /// </param>
            /// <param name="pContext">
            /// Pointer to a GUID that is used to start, cancel, or identify the request <c>IPortableDevicePropertiesBulkCallback</c>
            /// callbacks, if implemented.
            /// </param>
            /// <remarks>
            /// <para>
            /// The queued request is not started until the application calls Start. For more information on how to use this method, see
            /// IPortableDevicePropertiesBulk Interface.
            /// </para>
            /// <para>
            /// Due to performance issues, some devices may not return a comprehensive list of properties when the pKeys parameter is <c>NULL</c>.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulk-queuegetvaluesbyobjectlist
            // HRESULT QueueGetValuesByObjectList( [in] IPortableDevicePropVariantCollection *pObjectIDs, [in] IPortableDeviceKeyCollection
            // *pKeys, [in] IPortableDevicePropertiesBulkCallback *pCallback, [out] GUID *pContext );
            void QueueGetValuesByObjectList(IPortableDevicePropVariantCollection pObjectIDs, [Optional] IPortableDeviceKeyCollection pKeys,
                IPortableDevicePropertiesBulkCallback pCallback, out Guid pContext);

            /// <summary>
            /// The <c>QueueGetValuesByObjectFormat</c> interface queues a request for properties of objects of a specific format on a device.
            /// </summary>
            /// <param name="pguidObjectFormat">
            /// Pointer to a <c>GUID</c> that specifies the object format. Only objects of this type are queried.
            /// </param>
            /// <param name="pszParentObjectID">
            /// The object ID of the parent object where the search should begin. To search all the objects on a device, specify <c>WPD_DEVICE_OBJECT_ID</c>.
            /// </param>
            /// <param name="dwDepth">
            /// The maximum depth to search below the parent, where 1 means immediate children only. It is acceptable for this number to be
            /// greater than the actual number of levels. To search to any depth, specify 0xFFFFFFFF
            /// </param>
            /// <param name="pKeys">
            /// Pointer to an <c>IPortableDeviceKeyCollection</c> interface that contains the properties to retrieve. For a list of
            /// properties that are defined by Windows Portable Devices, see Properties and Attributes. Specify <c>NULL</c> to indicate all
            /// properties from the specified format.
            /// </param>
            /// <param name="pCallback">
            /// Pointer to an application-implemented IPortableDevicePropertiesBulkCallback interface that will receive the information as
            /// it is retrieved.
            /// </param>
            /// <param name="pContext">
            /// Pointer to a GUID that will be used to start, cancel, or identify the request in
            /// <c>IPortableDevicePropertiesBulkCallback</c> callbacks, if implemented.
            /// </param>
            /// <remarks>
            /// <para>
            /// If you specify WPD_OBJECT_FORMAT_ALL for the pguidObjectFormat parameter, this method will return properties for all objects
            /// on the device.
            /// </para>
            /// <para>
            /// If the pszParentObjectID parameter is set to an empty string (""), the method will perform a search that is dependent on the
            /// dwDepth parameter as described in the following table.
            /// </para>
            /// <list type="table">
            /// <listheader>
            /// <term>dwDepth</term>
            /// <term>Method returns</term>
            /// </listheader>
            /// <item>
            /// <term>0</term>
            /// <term>No results</term>
            /// </item>
            /// <item>
            /// <term>1</term>
            /// <term>Values for the specified device only.</term>
            /// </item>
            /// <item>
            /// <term>2</term>
            /// <term>Values for the specified device and all functional objects found on that device.</term>
            /// </item>
            /// </list>
            /// <para>
            /// If the pszParentObjectID parameter is set to WPD_DEVICE_OBJECT_ID, the method will perform a search that is dependent on the
            /// dwDepth parameter as described in the following table.
            /// </para>
            /// <list type="table">
            /// <listheader>
            /// <term>dwDepth</term>
            /// <term>Method returns</term>
            /// </listheader>
            /// <item>
            /// <term>0</term>
            /// <term>Values for the specified device only.</term>
            /// </item>
            /// <item>
            /// <term>1</term>
            /// <term>Values for the specified device and all functional objects found on that device.</term>
            /// </item>
            /// </list>
            /// <para>
            /// The queued request is not started until the application calls Start. For more information on how to use this method, see
            /// IPortableDevicePropertiesBulk Interface.
            /// </para>
            /// <para>
            /// Due to performance issues, some devices may not return a comprehensive list of properties when the pKeys parameter is <c>NULL</c>.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulk-queuegetvaluesbyobjectformat
            // HRESULT QueueGetValuesByObjectFormat( [in] REFGUID pguidObjectFormat, [in] LPCWSTR pszParentObjectID, [in] const DWORD
            // dwDepth, [in] IPortableDeviceKeyCollection *pKeys, [in] IPortableDevicePropertiesBulkCallback *pCallback, [out] GUID
            // *pContext );
            void QueueGetValuesByObjectFormat(in Guid pguidObjectFormat,
                [MarshalAs(UnmanagedType.LPWStr)] string pszParentObjectID, uint dwDepth,
                [Optional] IPortableDeviceKeyCollection pKeys, IPortableDevicePropertiesBulkCallback pCallback, out Guid pContext);

            /// <summary>
            /// The <c>QueueSetValuesByObjectList</c> method queues a request to set one or more specified values on one or more specified
            /// objects on the device.
            /// </summary>
            /// <param name="pObjectValues">
            /// Pointer to an IPortableDeviceValuesCollection interface that contains the properties and values to set on specified objects.
            /// This interface holds one or more IPortableDeviceValues interfaces, each representing a single object. Each
            /// <c>IPortableDeviceValues</c> interface holds a collection of key/value pairs, where the key is the <c>PROPERTYKEY</c>
            /// identifying the property, and the value is a data type that varies by property. Each <c>IPortableDeviceValues</c> interface
            /// also holds one WPD_OBJECT_ID property that identifies the object to which this interface refers.
            /// </param>
            /// <param name="pCallback">
            /// Pointer to an application-implemented IPortableDevicePropertiesBulkCallback interface that will receive the information as
            /// it is retrieved.
            /// </param>
            /// <param name="pContext">
            /// Pointer to a GUID that is used to start, cancel, or identify the request to any client-implemented
            /// <c>IPortableDevicePropertiesBulkCallback</c> callbacks.
            /// </param>
            /// <remarks>
            /// The queued request is not started until the application calls Start. For more information on how to use this method, see
            /// IPortableDevicePropertiesBulk Interface.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulk-queuesetvaluesbyobjectlist
            // HRESULT QueueSetValuesByObjectList( [in] IPortableDeviceValuesCollection *pObjectValues, [in]
            // IPortableDevicePropertiesBulkCallback *pCallback, [out] GUID *pContext );
            void QueueSetValuesByObjectList(IPortableDeviceValuesCollection pObjectValues,
                IPortableDevicePropertiesBulkCallback pCallback, out Guid pContext);

            /// <summary>The <c>Start</c> method starts a queued operation.</summary>
            /// <param name="pContext">
            /// A pointer to a GUID that identifies the operation to start. This value is generated by a <c>Queue...</c> method of this interface.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulk-start
            // HRESULT Start( [in] REFGUID pContext );
            void Start(in Guid pContext);

            /// <summary>The <c>Cancel</c> method cancels a pending properties request.</summary>
            /// <param name="pContext">
            /// Pointer to a context GUID that was retrieved when an asynchronous request was started by calling one of the <c>Queue...</c> methods.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulk-cancel
            // HRESULT Cancel( [in] REFGUID pContext );
            void Cancel(in Guid pContext);
        }

        /// <summary>
        /// <para>
        /// The <c>IPortableDevicePropertiesBulkCallback</c> interface is implemented by the application to track the progress of an
        /// asynchronous operation that was begun by using the IPortableDevicePropertiesBulk interface.
        /// </para>
        /// <para>
        /// After the application calls IPortableDevicePropertiesBulk::Start, Windows Portable Devices calls
        /// <c>IPortableDevicePropertiesBulkCallback::OnStart</c> first, and then repeatedly calls
        /// <c>IPortableDevicePropertiesBulkCallback::OnProgress</c> with information until the operation is completed or the application
        /// calls IPortableDevicePropertiesBulk::Cancel or returns an error value for <c>OnProgress</c>. Finally, regardless of whether the
        /// operation completed successfully, Windows Portable Devices calls <c>IPortableDevicePropertiesBulkCallback::OnEnd</c>.
        /// </para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledevicepropertiesbulkcallback
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDevicePropertiesBulkCallback")]
        [ComImport, Guid("9deacb80-11e8-40e3-a9f3-f557986a7845"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDevicePropertiesBulkCallback
        {
            /// <summary>
            /// The <c>OnStart</c> method is called by the SDK when a bulk operation started by IPortableDevicePropertiesBulk::Start is
            /// about to begin.
            /// </summary>
            /// <param name="pContext">
            /// Pointer to a GUID that identifies which operation has started. This value is produced by a <c>Queue</c>... method of the
            /// IPortableDevicePropertiesBulk interface.
            /// </param>
            /// <returns>
            /// The application should return either S_OK or an error code to abandon the operation. The application should handle all error
            /// codes in the same manner.
            /// </returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulkcallback-onstart
            // HRESULT OnStart( [in] REFGUID pContext );
            [PreserveSig]
            HRESULT OnStart(in Guid pContext);

            /// <summary>
            /// The <c>OnProgress</c> method is called by the SDK when a bulk operation started by IPortableDevicePropertiesBulk::Start has
            /// sent data to the device and received some information back.
            /// </summary>
            /// <param name="pContext">
            /// Pointer to a GUID that identifies which operation is in progress. This value is produced by a <c>Queue</c>... method of the
            /// IPortableDevicePropertiesBulk interface.
            /// </param>
            /// <param name="pResults">
            /// Pointer to an IPortableDeviceValuesCollection interface that contains the results retrieved from the device. This interface
            /// will hold one or more IPortableDeviceValues interfaces. Each of these interfaces will hold one WPD_OBJECT_ID property with a
            /// string value (VT_LPSTR) specifying the object ID of the object that these values pertain to. The rest of the values in each
            /// <c>IPortableDeviceValues</c> interface vary, depending on the bulk operation being reported. For the
            /// <c>QueueGetValuesByObjectFormat</c> and <c>QueueGetValuesByObjectList</c> methods, they will be retrieved values of varying
            /// types. For QueueSetValuesByObjectList, they will be <c>VT_ERROR</c><c>HRESULT</c> values for any errors encountered when
            /// setting values.
            /// </param>
            /// <returns>
            /// The application should return either S_OK, or an error code to abandon the operation. All error codes are handled the same way.
            /// </returns>
            /// <remarks>
            /// <para>This method can be called once or multiple times, depending on how large the operation is.</para>
            /// <para>
            /// This method does not necessarily retrieve all properties at once, nor does it return the properties in a particular order.
            /// </para>
            /// <para>If this method is called multiple times, it may return properties for the same object identifier each time.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulkcallback-onprogress
            // HRESULT OnProgress( [in] REFGUID pContext, [in] IPortableDeviceValuesCollection *pResults );
            [PreserveSig]
            HRESULT OnProgress(in Guid pContext, IPortableDeviceValuesCollection pResults);

            /// <summary>
            /// The <c>OnEnd</c> method is called by the SDK when a bulk operation that is started by IPortableDevicePropertiesBulk::Start
            /// is completed.
            /// </summary>
            /// <param name="pContext">
            /// Pointer to a GUID that identifies which operation has finished. This value is produced by a <c>Queue</c>... method of the
            /// IPortableDevicePropertiesBulk interface.
            /// </param>
            /// <param name="hrStatus">Contains any errors returned by the driver after the bulk operation has completed.</param>
            /// <returns>The method's return value is ignored.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicepropertiesbulkcallback-onend
            // HRESULT OnEnd( [in] REFGUID pContext, [out] HRESULT hrStatus );
            void OnEnd(in Guid pContext, HRESULT hrStatus);
        }

        /// <summary>
        /// The <c>IPortableDeviceResources</c> interface provides access to an object's raw data. Use this interface to read or write
        /// resources in an object. To get this interface, call IPortableDeviceContent::Transfer.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceresources
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceResources")]
        [ComImport, Guid("FD8878AC-D841-4D17-891C-E6829CDB6934"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceResources
        {
            /// <summary>The <c>GetSupportedResources</c> method retrieves a list of resources that are supported by a specific object.</summary>
            /// <param name="pszObjectID">The ID of the object.</param>
            /// <returns>
            /// An IPortableDeviceKeyCollection interface that holds a collection of <c>PROPERTYKEY</c> values specifying resource types
            /// supported by this object type. If the object cannot hold resources, this will be an empty collection. The caller must
            /// release this interface when it is done with it.
            /// </returns>
            /// <remarks>
            /// The list of resources returned by this method includes all resources that the object can support. This does not mean that
            /// all the listed resources actually have data, but that the object is capable of supporting each listed resource.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceresources-getsupportedresources
            // HRESULT GetSupportedResources( [in] LPCWSTR pszObjectID, [out] IPortableDeviceKeyCollection **ppKeys );
            IPortableDeviceKeyCollection GetSupportedResources([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID);

            /// <summary>The <c>GetResourceAttributes</c> method retrieves all attributes from a specified resource in an object.</summary>
            /// <param name="pszObjectID">The object ID of the object hosting the resource.</param>
            /// <param name="Key">A <c>REFPROPERTYKEY</c> that specifies which resource to query.</param>
            /// <returns>
            /// Pointer to an IPortableDeviceValues interface pointer that holds <c>PROPERTYKEY</c>/ <c>PROPVARIANT</c> pairs that describe
            /// each attribute and its value, respectively. The value types of the attribute values vary. If a property could not be
            /// returned, the value for the returned property will be <c>VT_ERROR</c>, and the <c>PROPVARIANT</c> scode member will contain
            /// the <c>HRESULT</c> of that particular failure.
            /// </returns>
            /// <remarks>
            /// Resource attributes describe the access rights, size, format, and other information related to a resource. For example, the
            /// attributes for an audio annotation resource on an image object may specify the bit rate, channel count, and data format of
            /// the audio.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceresources-getresourceattributes
            // HRESULT GetResourceAttributes( [in] LPCWSTR pszObjectID, [in] REFPROPERTYKEY Key, [out] IPortableDeviceValues
            // **ppResourceAttributes );
            IPortableDeviceValues GetResourceAttributes([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, in PROPERTYKEY Key);

            /// <summary>
            /// The <c>GetStream</c> method gets an <c>IStream</c> interface with which to read or write the content data in an object on a
            /// device. The retrieved interface enables you to read from or write to the object data.
            /// </summary>
            /// <param name="pszObjectID">The object ID of the object.</param>
            /// <param name="Key">
            /// A <c>REFPROPERTYKEY</c> that specifies which resource to read. You can retrieve the keys of all the object's resources by
            /// calling GetSupportedResources.
            /// </param>
            /// <param name="dwMode">
            /// <para>One of the following access modes:</para>
            /// <list type="bullet">
            /// <item>
            /// <term>STGM_READ (Read-only access.)</term>
            /// </item>
            /// <item>
            /// <term>STGM_WRITE (Write-only access.)</term>
            /// </item>
            /// <item>
            /// <term>STGM_READWRITE (Read/write access.)</term>
            /// </item>
            /// </list>
            /// </param>
            /// <param name="pdwOptimalBufferSize">
            /// An optional pointer to a <c>DWORD</c> that specifies an estimate of the best buffer size to use when reading or writing data
            /// by using ppStream. A driver is required to support this value.
            /// </param>
            /// <returns>
            /// Pointer to an <c>IStream</c> interface pointer. This interface is used to read and write data to the object. The caller must
            /// release this interface when it is done with it.
            /// </returns>
            /// <remarks>
            /// <para>
            /// The retrieved stream cannot read the contents of a folder recursively. To copy all the resources in an object, specify
            /// <c>WPD_RESOURCE_DEFAULT</c> for Key.
            /// </para>
            /// <para>If the object does not support resources, this method will return an error, and ppStream will be <c>NULL</c>.</para>
            /// <para>
            /// Applications should use the buffer size returned by pdwOptimalBufferSize when allocating the buffer for read or write operations.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceresources-getstream
            // HRESULT GetStream( [in] LPCWSTR pszObjectID, [in] REFPROPERTYKEY Key, [in] const DWORD dwMode, [in, out] DWORD
            // *pdwOptimalBufferSize, [out] IStream **ppStream );
            IStream GetStream([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, in PROPERTYKEY Key, STGM dwMode, out uint pdwOptimalBufferSize);

            /// <summary>The <c>Delete</c> method deletes one or more resources from the object identified by the pszObjectID parameter.</summary>
            /// <param name="pszObjectID">The object ID of the object.</param>
            /// <param name="pKeys">
            /// Pointer to an IPortableDeviceKeyCollection interface that lists which resources to delete. You can find out what resources
            /// the object has by calling GetSupportedResources.
            /// </param>
            /// <remarks>
            /// <para>
            /// An object can have several resources. For instance, an object may contain image data, thumbnail image data, and audio data.
            /// </para>
            /// <para>An application can retrieve a list of supported resources by calling the GetSupportedResources method.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceresources-delete
            // HRESULT Delete( [in] LPCWSTR pszObjectID, [in] IPortableDeviceKeyCollection *pKeys );
            void Delete([MarshalAs(UnmanagedType.LPWStr)] string pszObjectID, IPortableDeviceKeyCollection pKeys);

            /// <summary>The <c>Cancel</c> method cancels a pending operation.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDevice interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceresources-cancel
            // HRESULT Cancel();
            void Cancel();

            /// <summary>The <c>CreateResource</c> method creates a resource.</summary>
            /// <param name="pResourceAttributes">
            /// <para>Pointer to the following object parameter attributes.</para>
            /// <list type="table">
            /// <listheader>
            /// <term>Attribute</term>
            /// <term>Description</term>
            /// </listheader>
            /// <item>
            /// <term>WPD_OBJECT_NAME</term>
            /// <term>The object name.</term>
            /// </item>
            /// <item>
            /// <term>WPD_RESOURCE_ATTRIBUTE_TOTAL_SIZE</term>
            /// <term>The total size of the resource data stream.</term>
            /// </item>
            /// <item>
            /// <term>WPD_RESOURCE_ATTRIBUTE_FORMAT</term>
            /// <term>The format of the resource data stream.</term>
            /// </item>
            /// <item>
            /// <term>WPD_RESOURCE_ATTRIBUTE_RESOURCE_KEY</term>
            /// <term>The resource key.</term>
            /// </item>
            /// </list>
            /// </param>
            /// <param name="ppData">Pointer to a stream into which the caller can write resource data.</param>
            /// <param name="pdwOptimalWriteBufferSize">
            /// Pointer to a value that specifies the optimal buffer size when writing to the stream. This parameter is optional.
            /// </param>
            /// <param name="ppszCookie">Pointer to a cookie that identifies the resource creation request. This parameter is optional.</param>
            /// <remarks>
            /// <para>
            /// When an application calls this method, it must specify the resource attributes and it must write the required data to the
            /// stream that this method returns.
            /// </para>
            /// <para>
            /// A resource is not created when the method returns; it is created when the application commits the data by calling the
            /// <c>Commit</c> method on the stream at which ppData points.
            /// </para>
            /// <para>
            /// To cancel the data transfer to a resource, the application must call the <c>Revert</c> method on the stream at which ppData
            /// points. Once the transfer is canceled, the application must invoke <c>IUnknown::Release</c> to close the stream.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceresources-createresource
            // HRESULT CreateResource( [in] IPortableDeviceValues *pResourceAttributes, [out] IStream **ppData, [out] DWORD
            // *pdwOptimalWriteBufferSize, [out] LPWSTR *ppszCookie );
            void CreateResource(IPortableDeviceValues pResourceAttributes, out IStream ppData, out uint pdwOptimalWriteBufferSize, [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);
        }

        /// <summary>The <c>IPortableDeviceService</c> interface provides access to a service.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceservice
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceService")]
        [ComImport, Guid("D3BD3A44-D7B5-40A9-98B7-2FA4D01DEC08"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(PortableDeviceService))]
        public interface IPortableDeviceService
        {
            /// <summary>The <c>Open</c> method opens a connection to the service.</summary>
            /// <param name="pszPnPServiceID">
            /// The Plug and Play (PnP) identifier for the service, which is the same identifier that is retrieved by the GetPnPServiceId method.
            /// </param>
            /// <param name="pClientInfo">The IPortableDeviceValues interface specifying the client information.</param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-open HRESULT
            // Open( [in] LPCWSTR pszPnPServiceID, [in] IPortableDeviceValues *pClientInfo );
            void Open([MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID, IPortableDeviceValues pClientInfo);

            /// <summary>The <c>Capabilities</c> method retrieves the service capabilities.</summary>
            /// <returns>The IPortableDeviceServiceCapabilities interface specifying the capabilities of the service.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-capabilities
            // HRESULT Capabilities( [out] IPortableDeviceServiceCapabilities **ppCapabilities );
            IPortableDeviceServiceCapabilities Capabilities();

            /// <summary>The <c>Content</c> method retrieves access to the service content.</summary>
            /// <returns>The IPortableDeviceContent2 interface that accesses the service content.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-content
            // HRESULT Content( [out] IPortableDeviceContent2 **ppContent );
            IPortableDeviceContent2 Content();

            /// <summary>
            /// The <c>Methods</c> method retrieves the IPortableDeviceServiceMethods interface that is used to invoke custom functionality
            /// on the service.
            /// </summary>
            /// <returns>The IPortableDeviceServiceMethods interface used for invoking methods on the given service.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-methods
            // HRESULT Methods( [out] IPortableDeviceServiceMethods **ppMethods );
            IPortableDeviceServiceMethods Methods();

            /// <summary>The <c>Cancel</c> method cancels a pending operation on this interface.</summary>
            /// <remarks>
            /// <para>
            /// This method cancels all pending operations on the current device handle, which corresponds to a session associated with an
            /// IPortableDeviceService interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </para>
            /// <para>
            /// If your application invokes the WPD API from multiple threads, each thread should create a new instance of the
            /// IPortableDeviceService interface. Doing this ensures that any cancel operation affects only the I/O for the affected thread.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-cancel
            // HRESULT Cancel();
            void Cancel();

            /// <summary>The <c>Close</c> method releases the connection to the service.</summary>
            /// <remarks>
            /// <para>
            /// Applications typically won't call this method, as the Windows Portable Devices (WPD) API automatically calls it when the
            /// last reference to a service is removed.
            /// </para>
            /// <para>
            /// When an application does call this method, the WPD API releases the service connection, so that any WPD objects attached to
            /// the service will return the <c>E_WPD_SERVICE_NOT_OPEN</c> error.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-close
            // HRESULT Close();
            void Close();

            /// <summary>
            /// The <c>GetServiceObjectID</c> method retrieves an object identifier for the service. This object identifier can be used to
            /// access the properties of the service, for example.
            /// </summary>
            /// <returns>The retrieved service object identifier.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-getserviceobjectid
            // HRESULT GetServiceObjectID( [out] LPWSTR *ppszServiceObjectID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetServiceObjectID();

            /// <summary>The <c>GetPnPServiceID</c> method retrieves a Plug and Play (PnP) identifier for the service.</summary>
            /// <returns>The retrieved PnP identifier, which is the same identifier that was passed to the Open method.</returns>
            /// <remarks>
            /// <para>The Open method must be called on the service before a PnP identifier can be retrieved.</para>
            /// <para>
            /// When an application no longer needs the PnP identifier, it should call the <c>CoTaskMemFree</c> function to free the
            /// identifier memory.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-getpnpserviceid
            // HRESULT GetPnPServiceID( [out] LPWSTR *ppszPnPServiceID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetPnPServiceID();

            /// <summary>The <c>Advise</c> method registers an application-defined callback object that receives service events.</summary>
            /// <param name="dwFlags">Not used.</param>
            /// <param name="pCallback">The IPortableDeviceEventCallback interface specifying the callback object to register.</param>
            /// <param name="pParameters">
            /// The IPortableDeviceValues interface specifying the event-registration parameters, or <c>NULL</c> if the callback object is
            /// to receive all service events.
            /// </param>
            /// <param name="ppszCookie">
            /// The unique context ID for the callback object. This value matches that used by the Unadvise method to unregister the
            /// callback object.
            /// </param>
            /// <remarks>
            /// During cleanup, an application should unregister the callback object by calling the Unadvise method, and then release the
            /// memory referenced by the ppszCookie parameter by calling the <c>CoTaskMemFree</c> function.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-advise
            // HRESULT Advise( [in] const DWORD dwFlags, [in] IPortableDeviceEventCallback *pCallback, [in] IPortableDeviceValues
            // *pParameters, [out] LPWSTR *ppszCookie );
            void Advise([In, Optional] uint dwFlags, IPortableDeviceEventCallback pCallback, [In, Optional] IPortableDeviceValues pParameters,
                [MarshalAs(UnmanagedType.LPWStr)] out string ppszCookie);

            /// <summary>The <c>Unadvise</c> method unregisters a service event callback object.</summary>
            /// <param name="pszCookie">
            /// The unique context ID for the application-supplied callback object. This value matches that yielded by the ppszCookie
            /// parameter of the Advise method.
            /// </param>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-unadvise
            // HRESULT Unadvise( [in] LPCWSTR pszCookie );
            void Unadvise([MarshalAs(UnmanagedType.LPWStr)] string pszCookie);

            /// <summary>The <c>SendCommand</c> method sends a standard WPD command and its parameters to the service.</summary>
            /// <param name="dwFlags">Not used.</param>
            /// <param name="pParameters">The IPortableDeviceValues interface specifying the command parameters.</param>
            /// <param name="ppResults">The IPortableDeviceValues interface specifying the command results.</param>
            /// <remarks>
            /// <para>
            /// This method should only be used to send standard WPD commands to the service. To invoke service methods, use the
            /// IPortableDeviceServiceMethods interface.
            /// </para>
            /// <para>
            /// This method may fail even though it returns <c>S_OK</c> as its <c>HRESULT</c> value. To determine if a command succeeded, an
            /// application should always examine the properties referenced by the ppResults parameter:
            /// </para>
            /// <list type="bullet">
            /// <item>
            /// <term>The WPD_PROPERTY_COMMON_HRESULT property indicates if the command succeeded.</term>
            /// </item>
            /// <item>
            /// <term>If the command failed, the WPD_PROPERTY_COMMON_DRIVER_ERROR_CODE property will contain driver-specific error codes.</term>
            /// </item>
            /// </list>
            /// <para>The object referenced by the pParameters parameter must specify at least these properties:</para>
            /// <list type="bullet">
            /// <item>
            /// <term>
            /// WPD_PROPERTY_COMMON_COMMAND_CATEGORY, which should contain a command category, such as the <c>fmtid</c> member of the
            /// WPD_COMMAND_COMMON_RESET_DEVICE property
            /// </term>
            /// </item>
            /// <item>
            /// <term>
            /// WPD_PROPERTY_COMMON_COMMAND_ID, which should contain a command identifier, such as the <c>pid</c> member of the
            /// WPD_COMMAND_COMMON_RESET_DEVICE property.
            /// </term>
            /// </item>
            /// </list>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservice-sendcommand
            // HRESULT SendCommand( [in] const DWORD dwFlags, [in] IPortableDeviceValues *pParameters, [out] IPortableDeviceValues
            // **ppResults );
            void SendCommand([In, Optional] uint dwFlags, IPortableDeviceValues pParameters, out IPortableDeviceValues ppResults);
        }

        /// <summary>
        /// Clients use this interface to asynchronously open an IPortableDeviceService instance. This is used when opening a service can
        /// involve a user consent prompt.
        /// </summary>
        [PInvokeData("portabledeviceapi.h")]
        [ComImport, Guid("e56b0534-d9b9-425c-9b99-75f97cb3d7c8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceServiceActivation
        {
            /// <summary/>
            [PreserveSig]
            HRESULT OpenAsync([MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID, IPortableDeviceValues pClientInfo, IPortableDeviceServiceOpenCallback pCallback);

            /// <summary/>
            [PreserveSig]
            HRESULT CancelOpenAsync();
        }

        /// <summary>The <c>IPortableDeviceServiceCapabilities</c> interface retrieves information describing the capabilities of a service.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceservicecapabilities
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceServiceCapabilities")]
        [ComImport, Guid("24DBD89D-413E-43E0-BD5B-197F3C56C886"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceServiceCapabilities
        {
            /// <summary>The <c>GetSupportedMethods</c> method retrieves the methods supported by the service.</summary>
            /// <returns>The IPortableDevicePropVariantCollection interface that receives the list of methods.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getsupportedmethods
            // HRESULT GetSupportedMethods( [out] IPortableDevicePropVariantCollection **ppMethods );
            IPortableDevicePropVariantCollection GetSupportedMethods();

            /// <summary>
            /// The <c>GetSupportedMethodsByFormat</c> method retrieves the methods supported by the service for the specified format.
            /// </summary>
            /// <param name="Format">The format whose supported methods are retrieved.</param>
            /// <returns>The IPortableDevicePropVariantCollection interface that receives the list of methods.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getsupportedmethodsbyformat
            // HRESULT GetSupportedMethodsByFormat( [in] REFGUID Format, [out] IPortableDevicePropVariantCollection **ppMethods );
            IPortableDevicePropVariantCollection GetSupportedMethodsByFormat(in Guid Format);

            /// <summary>The <c>GetMethodAttributes</c> method retrieves the attributes used to describe a given method.</summary>
            /// <param name="Method">The method whose attributes are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of attributes.</returns>
            /// <remarks>
            /// <para>
            /// Possible attributes include the WPD_METHOD_ATTRIBUTE_NAME, <c>WPD_METHOD_ATTRIBUTE_ASSOCIATED_FORMAT</c>,
            /// <c>WPD_METHOD_ATTRIBUTE_ACCESS</c>, and WPD_METHOD_ATTRIBUTE_PARAMETERS properties.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving Supported Service Methods.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getmethodattributes
            // HRESULT GetMethodAttributes( [in] REFGUID Method, [out] IPortableDeviceValues **ppAttributes );
            IPortableDeviceValues GetMethodAttributes(in Guid Method);

            /// <summary>The <c>GetMethodParameterAttributes</c> method retrieves the attributes used to describe a given method parameter.</summary>
            /// <param name="Method">The method that contains the parameter whose attributes are retrieved.</param>
            /// <param name="Parameter">The parameter whose attributes are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of attributes.</returns>
            /// <remarks>
            /// <para>
            /// Possible attributes include the WPD_PARAMETER_ATTRIBUTE_ORDER, <c>WPD_PARAMETER_ATTRIBUTE_USAGE</c>,
            /// <c>WPD_PARAMETER_ATTRIBUTE_NAME</c>, and <c>WPD_PARAMETER_ATTRIBUTE_VARTYPE</c> properties.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving Supported Service Methods.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getmethodparameterattributes
            // HRESULT GetMethodParameterAttributes( REFGUID Method, [in] REFPROPERTYKEY Parameter, [out] IPortableDeviceValues
            // **ppAttributes );
            IPortableDeviceValues GetMethodParameterAttributes(in Guid Method, in PROPERTYKEY Parameter);

            /// <summary>The <c>GetSupportedFormats</c> method retrieves the formats supported by the service.</summary>
            /// <returns>The IPortableDevicePropVariantCollection interface that receives the list of formats.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getsupportedformats
            // HRESULT GetSupportedFormats( [out] IPortableDevicePropVariantCollection **ppFormats );
            IPortableDevicePropVariantCollection GetSupportedFormats();

            /// <summary>The <c>GetFormatAttributes</c> method retrieves the attributes of a format.</summary>
            /// <param name="Format">The format whose attributes are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of attributes.</returns>
            /// <remarks>
            /// <para>WPD_FORMAT_ATTRIBUTE_NAME is an example of a commonly retrieved attribute.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving Supported Service Formats.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getformatattributes
            // HRESULT GetFormatAttributes( [in] REFGUID Format, [out] IPortableDeviceValues **ppAttributes );
            IPortableDeviceValues GetFormatAttributes(in Guid Format);

            /// <summary>
            /// The <c>GetSupportedFormatProperties</c> method retrieves the properties supported by the service for the specified format.
            /// </summary>
            /// <param name="Format">The format whose properties are retrieved.</param>
            /// <returns>The IPortableDeviceKeyCollection interface that receives the list of properties.</returns>
            /// <remarks>
            /// <para>The retrieved property collection is a superset of all properties supported by an object of the specified format.</para>
            /// <para>
            /// An application can also retrieve the properties for an object by calling the IPortableDeviceService::SendCommand method with
            /// the WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED property passed as the command identifier. However, the
            /// <c>GetSupportedFormatProperties</c> method is typically faster than the <c>IPortableDeviceService::SendCommand</c> method.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getsupportedformatproperties
            // HRESULT GetSupportedFormatProperties( [in] REFGUID Format, [out] IPortableDeviceKeyCollection **ppKeys );
            IPortableDeviceKeyCollection GetSupportedFormatProperties(in Guid Format);

            /// <summary>The <c>GetFormatPropertyAttributes</c> method retrieves the attributes of a format property.</summary>
            /// <param name="Format">The format whose property has its attributes retrieved.</param>
            /// <param name="Property">The property whose attributes are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of attributes.</returns>
            /// <remarks>
            /// <para>
            /// A Windows Portable Devices (WPD) driver often treats objects of a given format the same. Many properties will therefore have
            /// attributes that are identical across all objects of that format. This method retrieves such attributes.
            /// </para>
            /// <para>Note that this method will not retrieve attributes that differ across object instances.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getformatpropertyattributes
            // HRESULT GetFormatPropertyAttributes( [in] REFGUID Format, [in] REFPROPERTYKEY Property, [out] IPortableDeviceValues
            // **ppAttributes );
            IPortableDeviceValues GetFormatPropertyAttributes(in Guid Format, in PROPERTYKEY Property);

            /// <summary>The <c>GetSupportedEvents</c> method retrieves the events supported by the service.</summary>
            /// <returns>The IPortableDevicePropVariantCollection interface that receives the list of events.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getsupportedevents
            // HRESULT GetSupportedEvents( [out] IPortableDevicePropVariantCollection **ppEvents );
            IPortableDevicePropVariantCollection GetSupportedEvents();

            /// <summary>The <c>GetEventAttributes</c> method retrieves the attributes of an event.</summary>
            /// <param name="Event">The event whose attributes are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of attributes.</returns>
            /// <remarks>
            /// <para>
            /// Possible attributes include the WPD_EVENT_ATTRIBUTE_NAME, WPD_EVENT_ATTRIBUTE_PARAMETERS, and WPD_EVENT_ATTRIBUTE_OPTIONS properties.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving Supported Service Events.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-geteventattributes
            // HRESULT GetEventAttributes( [in] REFGUID Event, [out] IPortableDeviceValues **ppAttributes );
            IPortableDeviceValues GetEventAttributes(in Guid Event);

            /// <summary>The <c>GetEventParameterAttributes</c> method retrieves the attributes of an event parameter.</summary>
            /// <param name="Event">The event that contains the parameter whose attributes are retrieved.</param>
            /// <param name="Parameter">The parameter whose attributes are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of attributes.</returns>
            /// <remarks>
            /// <para>Possible attribute values include the WPD_PARAMETER_ATTRIBUTE_VARTYPE and WPD_PARAMETER_ATTRIBUTE_FORM properties.</para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Retrieving Supported Service Events.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-geteventparameterattributes
            // HRESULT GetEventParameterAttributes( REFGUID Event, [in] REFPROPERTYKEY Parameter, [out] IPortableDeviceValues **ppAttributes );
            IPortableDeviceValues GetEventParameterAttributes(in Guid Event, in PROPERTYKEY Parameter);

            /// <summary>The <c>GetInheritedServices</c> method retrieves the services having the specified inheritance type.</summary>
            /// <param name="dwInheritanceType">The type of inherited services to retrieve.</param>
            /// <returns>
            /// The IPortableDevicePropVariantCollection interface that receives the list of services. If no inherited services are found,
            /// an empty collection is returned.
            /// </returns>
            /// <remarks>
            /// <para>
            /// Currently, device services may only inherit by implementing an abstract service. This is analogous to how a class implements
            /// methods of an abstract interface or a virtual class in object-oriented programming. By implementing an abstract service, a
            /// device service will support all formats, properties, and method behavior that the abstract service describes. For instance,
            /// a <c>Contacts</c> service may implement the <c>Anchor Sync</c> abstract service, where the device stores markers indicating
            /// which contacts were updated since the last synchronization with the PC.
            /// </para>
            /// <para>
            /// Possible values for the dwInheritanceType parameter are those defined in the WPD_SERVICE_INHERITANCE_TYPES enumeration. (For
            /// Windows 7, only the <c>WPD_SERVICE_INHERITANCE_IMPLEMENTATION</c> enumeration constant is supported.)
            /// </para>
            /// <para>
            /// If the value of the dwInheritanceType parameter is <c>WPD_SERVICE_INHERITANCE_IMPLEMENTATION</c>, each item in the
            /// collection specified by the ppServices parameter has variant type <c>VT_CLSID</c>.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getinheritedservices
            // HRESULT GetInheritedServices( [in] const DWORD dwInheritanceType, [out] IPortableDevicePropVariantCollection **ppServices );
            IPortableDevicePropVariantCollection GetInheritedServices([In] WPD_SERVICE_INHERITANCE_TYPES dwInheritanceType);

            /// <summary>The <c>GetFormatRenderingProfiles</c> method retrieves the rendering profiles of a format.</summary>
            /// <param name="Format">The format whose rendering profiles are retrieved.</param>
            /// <returns>The IPortableDeviceValuesCollection object that receives the list of rendering profiles.</returns>
            /// <remarks>
            /// The rendering profiles are similar to what the WPD_FUNCTIONAL_CATEGORY_RENDERING_INFORMATION functional object returns for
            /// device-wide rendering profiles, so that the <c>DisplayRenderingProfile</c> helper function described in Retrieving the
            /// Rendering Capabilities Supported by a Device could be used here as well. But there are differences: The
            /// <c>GetFormatRenderingProfiles</c> method retrieves only rendering profiles that apply to the selected service and have been
            /// filtered by format.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getformatrenderingprofiles
            // HRESULT GetFormatRenderingProfiles( [in] REFGUID Format, [out] IPortableDeviceValuesCollection **ppRenderingProfiles );
            IPortableDeviceValuesCollection GetFormatRenderingProfiles(in Guid Format);

            /// <summary>The <c>GetSupportedCommands</c> method retrieves the commands supported by the service.</summary>
            /// <returns>The IPortableDeviceKeyCollection interface that receives the list of commands.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getsupportedcommands
            // HRESULT GetSupportedCommands( [out] IPortableDeviceKeyCollection **ppCommands );
            IPortableDeviceKeyCollection GetSupportedCommands();

            /// <summary>The <c>GetCommandOptions</c> method retrieves the options of a WPD command.</summary>
            /// <param name="Command">The command whose options are retrieved.</param>
            /// <returns>The IPortableDeviceValues interface that receives the list of options.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-getcommandoptions
            // HRESULT GetCommandOptions( [in] REFPROPERTYKEY Command, [out] IPortableDeviceValues **ppOptions );
            IPortableDeviceValues GetCommandOptions(in PROPERTYKEY Command);

            /// <summary>The <c>Cancel</c> method cancels a pending operation.</summary>
            /// <remarks>
            /// This method cancels all pending operations on the current service handle, which corresponds to a session associated with an
            /// IPortableDeviceService interface. The Windows Portable Devices (WPD) API does not support targeted cancellation of specific operations.
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicecapabilities-cancel
            // HRESULT Cancel();
            void Cancel();
        }

        /// <summary>
        /// The <c>IPortableDeviceServiceManager</c> interface retrieves the device associated with a service and the list of services found
        /// on a device.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceservicemanager
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceServiceManager")]
        [ComImport, Guid("a8abc4e9-a84a-47a9-80b3-c5d9b172a961"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceServiceManager
        {
            /// <summary>The <c>GetDeviceServices</c> method retrieves a list of the services associated with the specified device.</summary>
            /// <param name="pszPnPDeviceID">The Plug and Play (PnP) identifier of the device.</param>
            /// <param name="guidServiceCategory">
            /// A reference to a globally unique identifier (GUID) that specifies the category of services to retrieve. If the referenced
            /// identifier is GUID_DEVINTERFACE_WPD_SERVICE, this method will retrieve all services supported by the device.
            /// </param>
            /// <param name="pServices">
            /// A user-allocated array of pointers to strings. When the method returns, the array contains the retrieved PnP service identifiers.
            /// </param>
            /// <param name="pcServices">
            /// The number of elements in the array specified by the pServices parameter. This value represents the maximum number of
            /// service identifiers that will be retrieved. When the method returns, this parameter contains the number of identifiers
            /// actually retrieved.
            /// </param>
            /// <remarks>
            /// <para>
            /// If this method succeeds, the application should call the FreePortableDevicePnPIDs function to free the array referenced by
            /// the pServices parameter.
            /// </para>
            /// <para>An application can retrieve the PnP identifier for a device by calling the IPortableDeviceManager::GetDevices method.</para>
            /// <para>
            /// Applications that use Single Threaded Apartments should use <c>CLSID_PortableDeviceServiceFTM</c> as this eliminates the
            /// overhead of interface pointer marshaling. <c>CLSID_PortableDeviceService</c> is still supported for legacy applications.
            /// </para>
            /// <para>Examples</para>
            /// <para>The following example shows how to retrieve a list of services for all devices.</para>
            /// <para>
            /// <code> #include "stdafx.h" #include "atlbase.h" #include "portabledeviceapi.h" #include "portabledevice.h" HRESULT GetServiceName( LPCWSTR pszPnpServiceID, LPWSTR* ppszServiceName); HRESULT EnumerateServicesForDevice( IPortableDeviceServiceManager* pPortableDeviceServiceManager, LPCWSTR pszPnpDeviceID); int _tmain(int argc, _TCHAR* argv[]) { HRESULT hr = S_OK; DWORD cPnPDeviceIDs = 0; LPWSTR* pPnpDeviceIDs = NULL; CComPtr&lt;IPortableDeviceManager&gt; pPortableDeviceManager; CComPtr&lt;IPortableDeviceServiceManager&gt; pPortableDeviceServiceManager; // Initialize COM for COINIT_MULTITHREADED hr = CoInitializeEx(NULL, COINIT_MULTITHREADED); // CoCreate the IPortableDeviceManager interface to enumerate // portable devices and to get information about them. if (hr == S_OK) { hr = CoCreateInstance(CLSID_PortableDeviceManager, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDeviceManager, (VOID**) &amp;pPortableDeviceManager); } if (hr == S_OK) { // Get the PortableDeviceServiceManager interface // by calling QueryInterface from IPortableDeviceManager hr = pPortableDeviceManager-&gt;QueryInterface (IID_IPortableDeviceServiceManager, (VOID**) &amp;pPortableDeviceServiceManager); } // Get the number of devices on the system if (hr == S_OK) { hr = pPortableDeviceManager-&gt;GetDevices(NULL, &amp;cPnPDeviceIDs); } // If we have at least 1 device, // continue to query the list of services for each device if ((hr == S_OK) &amp;&amp; (cPnPDeviceIDs &gt; 0)) { pPnpDeviceIDs = new LPWSTR[cPnPDeviceIDs]; if (pPnpDeviceIDs != NULL) { hr = pPortableDeviceManager-&gt;GetDevices (pPnpDeviceIDs, &amp;cPnPDeviceIDs); if (SUCCEEDED(hr)) { for (DWORD dwIndex = 0; dwIndex &lt; cPnPDeviceIDs; dwIndex++) { hr = EnumerateServicesForDevice (pPortableDeviceServiceManager, pPnpDeviceIDs[dwIndex]); } } // Free all returned PnPDeviceID strings FreePortableDevicePnPIDs(pPnpDeviceIDs, cPnPDeviceIDs); // Delete the array of LPWSTR pointers delete [] pPnpDeviceIDs; pPnpDeviceIDs = NULL; } } return 0; } HRESULT EnumerateServicesForDevice( IPortableDeviceServiceManager* pPortableDeviceServiceManager, LPCWSTR pszPnpDeviceID) { HRESULT hr = S_OK; DWORD cPnpServiceIDs = 0; LPWSTR* pPnpServiceIDs = NULL; if (pPortableDeviceServiceManager == NULL) { return E_POINTER; } // Get the number of services for the device if (hr == S_OK) { hr = pPortableDeviceServiceManager-&gt;GetDeviceServices( pszPnpDeviceID, GUID_DEVINTERFACE_WPD_SERVICE, NULL, &amp;cPnpServiceIDs); } // If we have at least 1, continue to gather information about // each service and populate the device information array. if ((hr == S_OK) &amp;&amp; (cPnpServiceIDs &gt; 0)) { pPnpServiceIDs = new LPWSTR[cPnpServiceIDs]; if (pPnpServiceIDs != NULL) { // Get a list of all services on the given device. // To query a give type of service (e.g. the Contacts Service), // a service GUID can be provided here instead of // GUID_DEVINTERFACE_WPD_SERVICE which returns all services DWORD dwIndex = 0; hr = pPortableDeviceServiceManager-&gt;GetDeviceServices (pszPnpDeviceID, GUID_DEVINTERFACE_WPD_SERVICE, pPnpServiceIDs, &amp;cPnpServiceIDs); if (SUCCEEDED(hr)) { // For each service found, read the name property for (dwIndex = 0; dwIndex &lt; cPnpServiceIDs &amp;&amp; SUCCEEDED(hr); dwIndex++) { LPWSTR pszServiceName = NULL; hr = GetServiceName(pPnpServiceIDs[dwIndex], &amp;pszServiceName); CoTaskMemFree(pszServiceName); } } FreePortableDevicePnPIDs(pPnpServiceIDs, cPnpServiceIDs); // Delete the array of LPWSTR pointers delete [] pPnpServiceIDs; pPnpServiceIDs = NULL; } } } HRESULT GetServiceName( LPCWSTR pszPnpServiceID, LPWSTR* ppszServiceName) { HRESULT hr = S_OK; LPWSTR pszServiceID = NULL; LPWSTR pszServiceObjectID = NULL; CComPtr&lt;IPortableDeviceValues&gt; pClientInfo; CComPtr&lt;IPortableDeviceValues&gt; pPropertyValues; CComPtr&lt;IPortableDeviceService&gt; pService; CComPtr&lt;IPortableDeviceContent2&gt; pContent; CComPtr&lt;IPortableDeviceProperties&gt;pProperties; CComPtr&lt;IPortableDeviceKeyCollection&gt; pPropertiesToRead; hr = CoCreateInstance(CLSID_PortableDeviceServiceFTM, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDeviceService, (VOID**) &amp;pService); if (hr == S_OK) { // CoCreate an IPortableDeviceValues interface // to hold the client information. hr = CoCreateInstance(CLSID_PortableDeviceValues, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDeviceValues, (VOID**) &amp; pClientInfo); if ((hr == S_OK) &amp;&amp; (pClientInfo!= NULL)) { hr = pClientInfo-&gt;SetStringValue (WPD_CLIENT_NAME, L"Service Sample Application"); if (hr == S_OK) { hr = pClientInfo-&gt;SetUnsignedIntegerValue( WPD_CLIENT_MAJOR_VERSION, 1); } if (hr == S_OK) { hr = pClientInfo-&gt;SetUnsignedIntegerValue( WPD_CLIENT_MINOR_VERSION, 0); } if (hr == S_OK) { hr = pClientInfo-&gt;SetUnsignedIntegerValue( WPD_CLIENT_REVISION, 0); } if (hr == S_OK) { hr = pClientInfo-&gt;SetUnsignedIntegerValue( WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE, SECURITY_IMPERSONATION); } if (hr == S_OK) { // Open a connection to the service hr = pService-&gt;Open(pszPnpServiceID, pClientInfo); } if (hr == S_OK) { hr = pService-&gt;GetServiceObjectID(&amp;pszServiceID); } if (hr == S_OK) { hr = pService-&gt;Content(&amp;pContent); } if (hr == S_OK) { hr = pContent-&gt;Properties(&amp;pProperties); } // Create a IPortableDeviceKeyCollection // containing the single PROPERTYKEY if (hr == S_OK) { hr = CoCreateInstance(CLSID_PortableDeviceKeyCollection, NULL, CLSCTX_INPROC_SERVER, IID_IPortableDeviceKeyCollection, (VOID**) &amp;pPropertiesToRead); } // Add our property key if (hr == S_OK) { hr = pPropertiesToRead-&gt;Add(WPD_OBJECT_NAME); } if (hr == S_OK) { hr = pProperties-&gt;GetValues( pszServiceID, pPropertiesToRead, &amp;pPropertyValues); } if (hr == S_OK) { hr = pPropertyValues-&gt;GetStringValue( WPD_OBJECT_NAME, ppszServiceName); } CoTaskMemFree(pszServiceObjectID); return hr; } } }</code>
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicemanager-getdeviceservices
            // HRESULT GetDeviceServices( [in] LPCWSTR pszPnPDeviceID, [in] REFGUID guidServiceCategory, [in, out] LPWSTR *pServices, [in,
            // out] DWORD *pcServices );
            void GetDeviceServices([MarshalAs(UnmanagedType.LPWStr)] string pszPnPDeviceID, in Guid guidServiceCategory,
                [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)] string[] pServices, ref uint pcServices);

            /// <summary>The <c>GetDeviceForService</c> method retrieves the device associated with the specified service.</summary>
            /// <param name="pszPnPServiceID">The Plug and Play (PnP) identifier of the service.</param>
            /// <returns>The retrieved PnP identifier of the device associated with the service.</returns>
            /// <remarks>
            /// <para>Neither the pszPnPServiceID parameter nor the pszPnPDeviceID parameter can be <c>NULL</c>.</para>
            /// <para>An application can retrieve a PnP service identifier by calling the <c>GetDeviceServices</c> method.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicemanager-getdeviceforservice
            // HRESULT GetDeviceForService( [in] LPCWSTR pszPnPServiceID, [out] LPWSTR *ppszPnPDeviceID );
            [return: MarshalAs(UnmanagedType.LPWStr)]
            string GetDeviceForService([MarshalAs(UnmanagedType.LPWStr)] string pszPnPServiceID);
        }

        /// <summary>
        /// <para>
        /// The <c>IPortableDeviceServiceMethodCallback</c> interface contains a method that applications use to track the completion of a
        /// callback method. Applications that call service methods asynchronously may implement this interface, and supply it as a
        /// parameter to IPortableDeviceServiceMethods::InvokeAsync.
        /// </para>
        /// <para>
        /// Each asynchronous method invocation uses the application-supplied callback object as its context. Therefore, an application that
        /// intends to simultaneously invoke multiple methods should avoid reusing the callback object. Instead, the application should
        /// provide a unique instance of the callback object for each call to <c>InvokeAsync</c>
        /// </para>
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceservicemethodcallback
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceServiceMethodCallback")]
        [ComImport, Guid("C424233C-AFCE-4828-A756-7ED7A2350083"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceServiceMethodCallback
        {
            /// <summary>The <c>OnComplete</c> method indicates that a callback method has completed execution.</summary>
            /// <param name="hrStatus">The overall status of the method.</param>
            /// <param name="pResults">
            /// An IPortableDeviceValues interface that contains the method-execution results. This is empty if the method returns no results.
            /// </param>
            /// <returns>If the method succeeds, it returns <c>S_OK</c>. Any other <c>HRESULT</c> value indicates that the call failed.</returns>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicemethodcallback-oncomplete
            // HRESULT OnComplete( [in] HRESULT hrStatus, [in] IPortableDeviceValues *pResults );
            [PreserveSig]
            HRESULT OnComplete(HRESULT hrStatus, IPortableDeviceValues pResults);
        }

        /// <summary>The <c>IPortableDeviceServiceMethods</c> interface invokes, or cancels invocation of, a method on a service.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nn-portabledeviceapi-iportabledeviceservicemethods
        [PInvokeData("portabledeviceapi.h", MSDNShortId = "NN:portabledeviceapi.IPortableDeviceServiceMethods")]
        [ComImport, Guid("E20333C9-FD34-412D-A381-CC6F2D820DF7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceServiceMethods
        {
            /// <summary>The <c>Invoke</c> method synchronously invokes a method.</summary>
            /// <param name="Method">The method to invoke.</param>
            /// <param name="pParameters">
            /// A pointer to an IPortableDeviceValues interface that contains the parameters of the invoked method, or <c>NULL</c> to
            /// indicate that the method has no parameters.
            /// </param>
            /// <param name="ppResults">
            /// The address of a pointer to an IPortableDeviceValues interface that receives the method results, or <c>NULL</c> to ignore
            /// the method results.
            /// </param>
            /// <remarks>
            /// <para>
            /// The method invocation is synchronous and will not return until the method has completed. For long-running methods, your
            /// application should call the InvokeAsync method instead.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Invoking Service Methods</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicemethods-invoke
            // HRESULT Invoke( [in] REFGUID Method, [in] IPortableDeviceValues *pParameters, [in, out] IPortableDeviceValues **ppResults );
            void Invoke(in Guid Method, [Optional] IPortableDeviceValues pParameters, out IPortableDeviceValues ppResults);

            /// <summary>The <c>InvokeAsync</c> method asynchronously invokes a method.</summary>
            /// <param name="Method">The method to invoke.</param>
            /// <param name="pParameters">
            /// A pointer to an IPortableDeviceValues interface that contains the parameters of the invoked method, or <c>NULL</c> to
            /// indicate that the method has no parameters.
            /// </param>
            /// <param name="pCallback">
            /// A pointer to an application-supplied IPortableDeviceServiceMethodCallback callback object that receives the method results,
            /// or <c>NULL</c> to ignore the method results.
            /// </param>
            /// <remarks>
            /// <para>
            /// When invoking multiple methods, clients can create a separate instance of the IPortableDeviceServiceMethodCallback interface
            /// for each invocation, saving a context with that instance object before passing it to the <c>InvokeAsync</c> method. This
            /// way, the method operation can be identified when the OnComplete method is called. Use of a unique object for each invocation
            /// also allows targeted cancellation of an operation by the Cancel method.
            /// </para>
            /// <para>Examples</para>
            /// <para>For an example of how to use this method, see Invoking Service Methods Asynchronously.</para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicemethods-invokeasync
            // HRESULT InvokeAsync( [in] REFGUID Method, [in] IPortableDeviceValues *pParameters, [in] IPortableDeviceServiceMethodCallback
            // *pCallback );
            void InvokeAsync(in Guid Method, [Optional] IPortableDeviceValues pParameters, [Optional] IPortableDeviceServiceMethodCallback pCallback);

            /// <summary>The <c>Cancel</c> method cancels a pending method invocation.</summary>
            /// <param name="pCallback">
            /// A pointer to the callback object whose method invocation is to be canceled, or <c>NULL</c> to cancel all pending method invocations.
            /// </param>
            /// <remarks>
            /// <para>
            /// A callback object identifies a method invocation. If the same callback object is reused for multiple calls to the
            /// InvokeAsync method, all method invocations arising from these calls will be cancelled.
            /// </para>
            /// <para>
            /// To enable targeted cancellation of a specific method invocation, pass a unique instance of the
            /// IPortableDeviceServiceMethodCallback interface to the InvokeAsync method.
            /// </para>
            /// </remarks>
            // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledeviceservicemethods-cancel
            // HRESULT Cancel( [in] IPortableDeviceServiceMethodCallback *pCallback );
            void Cancel([Optional] IPortableDeviceServiceMethodCallback pCallback);
        }

        /// <summary>Callback interface for implemented by clients for retrieving results of an asynchronous service open.</summary>
        [PInvokeData("portabledeviceapi.h")]
        [ComImport, Guid("bced49c8-8efe-41ed-960b-61313abd47a9"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPortableDeviceServiceOpenCallback
        {
            /// <summary/>
            [PreserveSig]
            HRESULT OnComplete(HRESULT hrStatus);
        }

        /// <summary>Enumerates the items in the collection.</summary>
        /// <param name="intf">The <see cref="IEnumPortableDeviceObjectIDs"/> instance.</param>
        /// <returns>A sequence of <see cref="string"/> values from the collection.</returns>
        public static IEnumerable<string> Enumerate(this IEnumPortableDeviceObjectIDs intf) =>
            new Vanara.Collections.IEnumFromCom<string>(intf.Next, intf.Reset);

        /// <summary>Retrieves the description of a device.</summary>
        /// <param name="manager">The <see cref="IPortableDeviceManager"/> instance used to get the name.</param>
        /// <param name="pszPnPDeviceID">The device's Plug and Play ID.</param>
        /// <returns>The user-description name of the device.</returns>
        public static string GetDeviceDescription(this IPortableDeviceManager manager, string pszPnPDeviceID) => PDMGetString(manager.GetDeviceDescription, pszPnPDeviceID);

        /// <summary>Retrieves the user-friendly name for the device.</summary>
        /// <param name="manager">The <see cref="IPortableDeviceManager"/> instance used to get the name.</param>
        /// <param name="pszPnPDeviceID">The device's Plug and Play ID.</param>
        /// <returns>The user-friendly name for the device.</returns>
        /// <remarks>
        /// A device is not required to support this method. If this method fails to retrieve a name, try requesting the WPD_OBJECT_NAME
        /// property of the device object (the object with the ID WPD_DEVICE_OBJECT_ID).
        /// </remarks>
        public static string GetDeviceFriendlyName(this IPortableDeviceManager manager, string pszPnPDeviceID) => PDMGetString(manager.GetDeviceFriendlyName, pszPnPDeviceID);

        /// <summary>Retrieves the name of the device manufacturer.</summary>
        /// <param name="manager">The <see cref="IPortableDeviceManager"/> instance used to get the name.</param>
        /// <param name="pszPnPDeviceID">The device's Plug and Play ID.</param>
        /// <returns>The name of the device manufacturer.</returns>
        public static string GetDeviceManufacturer(this IPortableDeviceManager manager, string pszPnPDeviceID) => PDMGetString(manager.GetDeviceManufacturer, pszPnPDeviceID);

        /// <summary>
        /// Retrieves a property value stored by the device on the computer. (These are not standard properties that are defined by Windows
        /// Portable Devices.)
        /// </summary>
        /// <typeparam name="T">The type of the value to return.</typeparam>
        /// <param name="manager">The <see cref="IPortableDeviceManager"/> instance used to get the device property.</param>
        /// <param name="pszPnPDeviceID">
        /// The device's Plug and Play ID. You can retrieve a list of Plug and Play names of all devices that are connected to the computer
        /// by calling GetDevices.
        /// </param>
        /// <param name="pszDevicePropertyName">
        /// The name of the property to request. These are custom property names defined by a device manufacturer.
        /// </param>
        /// <returns>The retrieved data. This call will also return an error that can be ignored. See Return Values.</returns>
        /// <remarks>
        /// <para>
        /// These property values are stored on device installation, or stored by a device during operation so that they can be persisted
        /// across connection sessions. An application must know the exact name of the property, which is specified by the device itself;
        /// therefore, this method is intended to be used by device developers who are creating their own applications.
        /// </para>
        /// <para>
        /// To get Windows Portable Devices properties from the device object, call IPortableDeviceProperties::GetValues, and specify the
        /// device object with <c>WPD_DEVICE_OBJECT_ID</c>.
        /// </para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceapi/nf-portabledeviceapi-iportabledevicemanager-getdeviceproperty
        // HRESULT GetDeviceProperty( [in] LPCWSTR pszPnPDeviceID, [in] LPCWSTR pszDevicePropertyName, [in, out] BYTE *pData, [in, out]
        // DWORD *pcbData, [in, out] DWORD *pdwType );
        public static T GetDeviceProperty<T>(this IPortableDeviceManager manager, string pszPnPDeviceID, string pszDevicePropertyName)
        {
            var sz = 0U;
            manager.GetDeviceProperty(pszPnPDeviceID, pszDevicePropertyName, default, ref sz, out _);
            if (sz == 0)
                return default;
            using var mem = new SafeCoTaskMemHandle(sz);
            manager.GetDeviceProperty(pszPnPDeviceID, pszDevicePropertyName, mem, ref sz, out var type);
            return (T)type.GetValue(mem, mem.Size);
        }

        /// <summary>Retrieves a list of portable devices connected to the computer.</summary>
        /// <param name="manager">The <see cref="IPortableDeviceManager"/> instance used to get the list of devices.</param>
        /// <param name="forceRefresh">
        /// If set to <see langword="true"/>, calls <see cref="IPortableDeviceManager.RefreshDeviceList"/> before retrieving the name;
        /// otherwise the device names will represent those available then the <see cref="IPortableDeviceManager"/> instance was created.
        /// </param>
        /// <returns>
        /// An array of strings that holds the Plug and Play names of all of the connected devices. These names can be used by
        /// IPortableDevice::Open to create a connection to a device.
        /// </returns>
        public static string[] GetDevices(this IPortableDeviceManager manager, bool forceRefresh = false)
        {
            if (forceRefresh)
                manager.RefreshDeviceList();
            return PDMGetStrings(manager.GetDevices);
        }

        /// <summary>
        /// Retrieves a list of private portable devices connected to the computer. These private devices are only accessible through an
        /// application that is designed for these particular devices.
        /// </summary>
        /// <param name="manager">The <see cref="IPortableDeviceManager"/> instance used to get the list of devices.</param>
        /// <returns>
        /// An array of strings that holds the Plug and Play names of all of the connected devices. These names can be used by
        /// IPortableDevice::Open to create a connection to a device.
        /// </returns>
        public static string[] GetPrivateDevices(this IPortableDeviceManager manager) => PDMGetStrings(manager.GetPrivateDevices);

        private static string PDMGetString(PDMStrGet func, string devId)
        {
            var cnt = 0U;
            var hr = func(devId, null, ref cnt);
            if (cnt == 0)
                return string.Empty;
            if (hr.Failed && hr != HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_INSUFFICIENT_BUFFER))
                throw hr.GetException();
            var sb = new StringBuilder((int)cnt + 1);
            if (cnt > 0)
                func(devId, sb, ref cnt).ThrowIfFailed();
            return sb.ToString();
        }

        private static string[] PDMGetStrings(PDMStrArrGet func)
        {
            var cnt = 0U;
            var hr = func(null, ref cnt);
            if (cnt == 0)
                return new string[0];
            if (hr.Failed && hr != HRESULT.HRESULT_FROM_WIN32(Win32Error.ERROR_INSUFFICIENT_BUFFER))
                throw hr.GetException();
            var devices = new string[cnt];
            if (cnt > 0)
                func(devices, ref cnt).ThrowIfFailed();
            return devices;
        }

        /// <summary>PortableDevice Class</summary>
        [ComImport, Guid("728a21c5-3d9e-48d7-9810-864848f0f404"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDevice { }

        /// <summary>PortableDeviceDispatchFactory Class</summary>
        [ComImport, Guid("43232233-8338-4658-ae01-0b4ae830b6b0"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceDispatchFactory { }

        /// <summary>PortableDeviceFTM Class</summary>
        [ComImport, Guid("f7c0039a-4762-488a-b4b3-760ef9a1ba9b"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceFTM { }

        /// <summary>PortableDeviceManager Class</summary>
        [ComImport, Guid("0af10cec-2ecd-4b92-9581-34f6ae0637f3"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceManager { }

        /// <summary>PortableDeviceService Class</summary>
        [ComImport, Guid("ef5db4c2-9312-422c-9152-411cd9c4dd84"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceService { }

        /// <summary>PortableDeviceServiceFTM Class</summary>
        [ComImport, Guid("1649b154-c794-497a-9b03-f3f0121302f3"), ClassInterface(ClassInterfaceType.None)]
        public class PortableDeviceServiceFTM { }
    }
}