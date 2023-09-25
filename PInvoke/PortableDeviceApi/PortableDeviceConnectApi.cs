using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke;

public static partial class PortableDeviceApi
{
	/// <summary>
	/// The <c>IConnectionRequestCallback</c> interface defines a single callback method. A Windows Portable Devices (WPD) application
	/// implements this optional Component Object Model (COM) interface to receive notifications about completed requests and to cancel
	/// pending requests. The requests are sent using the <c>IPortableDeviceConnector::Connect</c> and
	/// <c>IPortableDeviceConnector::Disconnect</c> methods.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iconnectionrequestcallback
	[PInvokeData("portabledeviceconnectapi.h")]
	[ComImport, Guid("272C9AE0-7161-4AE0-91BD-9F448EE9C427"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IConnectionRequestCallback
	{
		/// <summary>
		/// The <c>OnComplete</c> method notifies an application that a previously scheduled Connect or Disconnect request to the
		/// MTP/Bluetooth device has completed
		/// </summary>
		/// <param name="hrStatus">The status of the request to connect or disconnect a given device.</param>
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
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application implements the <c>IConnectionRequestCallback</c> interface to receive notifications about completed requests
		/// and to cancel pending requests.
		/// </para>
		/// <para>
		/// Windows Portable Devices (WPD) calls this method to notify an application that a previously scheduled request has completed.
		/// Each request can be tracked and canceled by its application-supplied callback. Therefore, if the application needs to send
		/// multiple requests at the same time using the same <c>IPortableDeviceConnector</c> object, each request should be passed a
		/// unique <c>IConnectionRequestCallback</c> object as the input parameter to the <c>IPortableDeviceConnector::Connect</c> and
		/// <c>IPortableDeviceConnector::Disconnect</c> methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/iconnectionrequestcallback-oncomplete HRESULT OnComplete( [in] HRESULT
		// hrStatus );
		[PreserveSig]
		HRESULT OnComplete(HRESULT hrStatus);
	}

	/// <summary>
	/// The <c>IEnumPortableDeviceConnectors</c> interface supports the enumeration of <c>IPortableDeviceConnector</c> interfaces,
	/// representing MTP/Bluetooth devices that were paired with the PC. Note that this will retrieve all previously-paired devices,
	/// including devices that are paired but disconnected. To determine if a device is still connected, query the
	/// <c>DEVPKEY_MTPBTH_IsConnected</c> property for that device.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/ienumportabledeviceconnectors
	[PInvokeData("portabledeviceconnectapi.h")]
	[ComImport, Guid("BFDEF549-9247-454F-BD82-06FE80853FAA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(EnumBthMtpConnectors))]
	public interface IEnumPortableDeviceConnectors : Vanara.Collections.ICOMEnum<IPortableDeviceConnector>
	{
		/// <summary>
		/// The <c>Next</c> method retrieves the next one or more <c>IPortableDeviceConnector</c> objects in the enumeration sequence.
		/// </summary>
		/// <param name="cRequested">
		/// The number of requested devices. This value also indicates the number of elements in the caller-allocated array specified by
		/// the pConnectors parameter.
		/// </param>
		/// <param name="pConnectors">
		/// An array of <c>IPortableDeviceConnector</c> pointers, each specifying a paired MTP Bluetooth device. The caller must
		/// allocate an array of <c>IPortableDeviceConnector</c> pointers, with the array length specified by the cRequested parameter.
		/// On successful return, the caller must free both the array and the returned pointers. The <c>IPortableDeviceConnector</c>
		/// interfaces are freed by calling the <c>IUnknown::Release</c> method.
		/// </param>
		/// <param name="pcFetched">
		/// The number of <c>IPortableDeviceConnector</c> interfaces that are actually retrieved. If no <c>IPortableDeviceConnector</c>
		/// interfaces are retrieved and the return value is <c>S_FALSE</c>, there are no more <c>IPortableDeviceConnector</c>
		/// interfaces to enumerate.
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
		/// <term>There are no more MTP Bluetooth devices to enumerate.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/ienumportabledeviceconnectors-next HRESULT Next( [in] UINT32
		// cRequested, [out] IPortableDeviceConnector **pConnectors, [in, out] UINT32 *pcFetched );
		[PreserveSig]
		HRESULT Next(uint cRequested, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IPortableDeviceConnector[] pConnectors,
			[In, Out] ref uint pcFetched);

		/// <summary>The <c>Skip</c> method skips the specified number of devices in the enumeration sequence.</summary>
		/// <param name="cConnectors">The number of devices to skip.</param>
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
		/// The specified number of devices could not be skipped. One possible cause: The cConnectors parameter specifies more devices
		/// than actually remain in the enumeration sequence.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/ienumportabledeviceconnectors-skip HRESULT Skip( [in] UINT32
		// cConnectors );
		[PreserveSig]
		HRESULT Skip(uint cConnectors);

		/// <summary>The <c>Reset</c> method resets the enumeration sequence to the beginning.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/ienumportabledeviceconnectors-reset HRESULT Reset();
		void Reset();

		/// <summary>The <c>Clone</c> method creates a copy of the current <c>IEnumPortableDeviceConnectors</c> interface.</summary>
		/// <returns>
		/// The address of a pointer to an <c>IEnumPortableDeviceConnectors</c> interface. The calling application must release this
		/// interface when it is done with it.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/ienumportabledeviceconnectors-clone HRESULT Clone( [out]
		// IEnumPortableDeviceConnectors **ppEnum );
		IEnumPortableDeviceConnectors Clone();
	}

	/// <summary>
	/// The <c>IPortableDeviceConnector</c> interface defines methods used for connection-management and property-retrieval for a paired
	/// MTP/Bluetooth device.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nn-portabledeviceconnectapi-iportabledeviceconnector
	[PInvokeData("portabledeviceconnectapi.h", MSDNShortId = "NN:portabledeviceconnectapi.IPortableDeviceConnector")]
	[ComImport, Guid("625E2DF8-6392-4CF0-9AD1-3CFA5F17775C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPortableDeviceConnector
	{
		/// <summary>The <c>Connect</c> method sends an asynchronous connection request to the MTP/Bluetooth device.</summary>
		/// <param name="pCallback">
		/// A pointer to a IConnectionRequestCallback interface if the application wishes to be notified when the request is complete;
		/// otherwise, <c>NULL</c>. If multiple requests are being sent simultaneously using the same IPortableDeviceConnector object, a
		/// different instance of the callback object must be used.
		/// </param>
		/// <remarks>
		/// <para>
		/// This method will queue a connect request and then return immediately. The connection request will result in a no-op if a
		/// device is already connected.
		/// </para>
		/// <para>
		/// To be notified when the request is complete, applications should provide a pointer to the IConnectionRequestCallback interface.
		/// </para>
		/// <para>
		/// If a previously paired MTP/Bluetooth device is within range, applications can call this method to instantiate the Windows
		/// Portable Devices (WPD) class driver stack for that device, so that the device can be communicated to using the WPD API.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nf-portabledeviceconnectapi-iportabledeviceconnector-connect
		// HRESULT Connect( [in, optional] IConnectionRequestCallback? *pCallback );
		void Connect([Optional] IConnectionRequestCallback? pCallback);

		/// <summary>The <c>Disconnect</c> method sends an asynchronous disconnect request to the MTP/Bluetooth device.</summary>
		/// <param name="pCallback">A pointer to an IConnectionRequestCallback interface.</param>
		/// <remarks>
		/// <para>This method will queue a disconnect request and then return immediately.</para>
		/// <para>
		/// To be notified when the request is complete, applications should provide a pointer to the IConnectionRequestCallback
		/// interface. This will disconnect the MTP/Bluetooth link and remove the Windows Portable Devices (WPD) class driver stack for
		/// that device.
		/// </para>
		/// <para>Once the disconnection completes, the WPD API will no longer enumerate this device.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nf-portabledeviceconnectapi-iportabledeviceconnector-disconnect
		// HRESULT Disconnect( [in] IConnectionRequestCallback *pCallback );
		void Disconnect(IConnectionRequestCallback pCallback);

		/// <summary>
		/// The <c>Cancel</c> method cancels a pending request to connect or disconnect an MTP/Bluetooth device. The callback object is
		/// used to identify the request. This method returns immediately, and the request will be cancelled asynchronously.
		/// </summary>
		/// <param name="pCallback">A pointer to an IConnectionRequestCallback interface. This value cannot be <c>NULL</c>.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nf-portabledeviceconnectapi-iportabledeviceconnector-cancel
		// HRESULT Cancel( [in] IConnectionRequestCallback *pCallback );
		void Cancel(IConnectionRequestCallback pCallback);

		/// <summary>The <c>GetProperty</c> method retrieves a property for the given MTP/Bluetooth Bus Enumerator device.</summary>
		/// <param name="pPropertyKey">A pointer to a property key for the requested property.</param>
		/// <param name="pPropertyType">A pointer to a property type.</param>
		/// <param name="ppData">The address of a pointer to the property data.</param>
		/// <param name="pcbData">A pointer to the size (in bytes) of the property data.</param>
		/// <remarks>
		/// <para>
		/// The properties retrieved by this method are set on the device node. An example property key is
		/// <c>DEVPKEY_MTPBTH_IsConnected</c>, which indicates whether the device is currently connected.
		/// </para>
		/// <para>
		/// Valid values for the pPropertyType parameter are system-defined base data types of the unified device property model. The
		/// data-type names start with the prefix <c>DEVPROP_TYPE_</c>.
		/// </para>
		/// <para>
		/// Once the application no longer needs the property data specified by the ppData parameter, it must call <c>CoTaskMemAlloc</c>
		/// to free this data.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows how to read the DEVPKEY_MTPBTH_IsConnected property for a paired MTP/Bluetooth device.</para>
		/// <para>
		/// <code>#include &lt;devpkey.h&gt; #include &lt;PortableDeviceConnectAPI.h&gt; HRESULT IsDeviceConnected( __in IPortableDeviceConnector* pDevice, __out BOOL* pIsConnected) { DEVPROPTYPE typeGet; BYTE* pDataGet; UINT32 cbDataGet; *pbIsConnected = FALSE; HRESULT hr = pDevice -&gt;GetProperty(&amp;DEVPKEY_MTPBTH_IsConnected, &amp;typeGet, &amp;pDataGet, &amp;cbDataGet); if (SUCCEEDED(hr)) { DEVPROP_BOOLEAN bIsConnected = *((DEVPROP_BOOLEAN*)pDataGet); if (bIsConnected == DEVPROP_TRUE) { * pIsConnected = TRUE; } // Release memory allocated by GetProperty CoTaskMemFree(pDataGet); } return hr; }</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nf-portabledeviceconnectapi-iportabledeviceconnector-getproperty
		// HRESULT GetProperty( [in] const DEVPROPKEY *pPropertyKey, [out] DEVPROPTYPE *pPropertyType, [out] BYTE **ppData, [out] UINT32
		// *pcbData );
		void GetProperty(in DEVPROPKEY pPropertyKey, out DEVPROPTYPE pPropertyType, out SafeCoTaskMemHandle ppData, out uint pcbData);

		/// <summary>The <c>SetProperty</c> method sets the given property on the MTP/Bluetooth Bus Enumerator device.</summary>
		/// <param name="pPropertyKey">A pointer to a property key for the given property.</param>
		/// <param name="PropertyType">The property type.</param>
		/// <param name="pData">A pointer to the property data.</param>
		/// <param name="cbData">The size (in bytes) of the property data.</param>
		/// <remarks>Before calling this method, an application must verify that it has Administrator user rights.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nf-portabledeviceconnectapi-iportabledeviceconnector-setproperty
		// HRESULT SetProperty( [in] const DEVPROPKEY *pPropertyKey, [in] DEVPROPTYPE PropertyType, [in] const BYTE *pData, [in] UINT32
		// cbData );
		void SetProperty(in DEVPROPKEY pPropertyKey, DEVPROPTYPE PropertyType, [In] IntPtr pData, [In] uint cbData);

		/// <summary>The <c>GetPnPID</c> method retrieves the connector's Plug and Play (PnP) device identifier.</summary>
		/// <returns>The PnP device identifier.</returns>
		/// <remarks>
		/// <para>
		/// The identifier retrieved by this method corresponds to a handle to the MTP/Bluetooth Bus Enumerator device node that
		/// receives connect and disconnect IOCTL requests for a paired MTP/Bluetooth device. Applications can use this identifier with
		/// the SetupAPI functions to access the device node.
		/// </para>
		/// <para>
		/// Once the application no longer needs the identifier specified by the ppwszPnPID parameter, it must call the
		/// <c>CoTaskMemAlloc</c> function to free the identifier.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/portabledeviceconnectapi/nf-portabledeviceconnectapi-iportabledeviceconnector-getpnpid
		// HRESULT GetPnPID( [out] LPWSTR *ppwszPnPID );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetPnPID();
	}

	/// <summary>EnumBthMtpConnectors Class</summary>
	[PInvokeData("portabledeviceconnectapi.h")]
	[ComImport, Guid("a1570149-e645-4f43-8b0d-409b061db2fc"), ClassInterface(ClassInterfaceType.None)]
	public class EnumBthMtpConnectors { }
}