using System;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

/// <summary>Interfaces and constants for Windows Connect Now.</summary>
public static partial class WcnApi
{
	/// <summary>Flags for WCN_VENDOR_EXTENSION_SPEC</summary>
	[Flags]
	public enum WCN_FLAG : uint
	{
		/// <summary>The vendor extension was not available before the session started. The vendor extension is not secure.</summary>
		WCN_FLAG_DISCOVERY_VE = 0x0001,

		/// <summary>
		/// The vendor extension is authentic. Only devices that pass authentication can read or write authenticated vendor extensions.
		/// </summary>
		WCN_FLAG_AUTHENTICATED_VE = 0x0002,

		/// <summary>
		/// The vendor extension is authentic and encrypted. In addition to the guarantee of authenticated vendor extensions, vendor
		/// extensions are encrypted before transmission.
		/// </summary>
		WCN_FLAG_ENCRYPTED_VE = 0x0004,
	}

	/// <summary>The <c>WCN_PASSWORD_TYPE</c> enumeration defines the authentication that will be used in a WPS session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/ne-wcndevice-wcn_password_type typedef enum tagWCN_PASSWORD_TYPE {
	// WCN_PASSWORD_TYPE_PUSH_BUTTON, WCN_PASSWORD_TYPE_PIN, WCN_PASSWORD_TYPE_PIN_REGISTRAR_SPECIFIED, WCN_PASSWORD_TYPE_OOB_SPECIFIED,
	// WCN_PASSWORD_TYPE_WFDS } WCN_PASSWORD_TYPE;
	[PInvokeData("wcndevice.h", MSDNShortId = "NE:wcndevice.tagWCN_PASSWORD_TYPE")]
	public enum WCN_PASSWORD_TYPE
	{
		/// <summary>
		/// Indicates the device uses a WPS button interface to put the device into wireless provisioning mode. If this value is
		/// specified when calling IWCNDevice::SetPassword, set dwPasswordLength to zero and pbPassword to NULL.
		/// </summary>
		WCN_PASSWORD_TYPE_PUSH_BUTTON = 0,

		/// <summary>
		/// Indicates that authentication is secured via a PIN. The user must provide the PIN of the device. Usually, the PIN is a 4 or
		/// 8-digit number printed on a label attached to the device, or displayed on the screen. If this value is specified when
		/// calling IWCNDevice::SetPassword, set dwPasswordLength to the number of digits in the password, and pbPassword to point to a
		/// buffer containing the ASCII representation of the pin.
		/// </summary>
		WCN_PASSWORD_TYPE_PIN,

		/// <summary>Indicates that authentication is secured via a PIN, as above, but that the PIN is specified by the registrar.</summary>
		WCN_PASSWORD_TYPE_PIN_REGISTRAR_SPECIFIED,

		/// <summary/>
		WCN_PASSWORD_TYPE_OOB_SPECIFIED,

		/// <summary/>
		WCN_PASSWORD_TYPE_WFDS,
	}

	/// <summary>The <c>WCN_SESSION_STATUS</c> enumeration defines the outcome status of a WPS session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/ne-wcndevice-wcn_session_status typedef enum tagWCN_SESSION_STATUS {
	// WCN_SESSION_STATUS_SUCCESS, WCN_SESSION_STATUS_FAILURE_GENERIC, WCN_SESSION_STATUS_FAILURE_TIMEOUT } WCN_SESSION_STATUS;
	[PInvokeData("wcndevice.h", MSDNShortId = "NE:wcndevice.tagWCN_SESSION_STATUS")]
	public enum WCN_SESSION_STATUS
	{
		/// <summary>Indicates that the session is successful.</summary>
		WCN_SESSION_STATUS_SUCCESS = 0,

		/// <summary/>
		WCN_SESSION_STATUS_FAILURE_GENERIC,

		/// <summary/>
		WCN_SESSION_STATUS_FAILURE_TIMEOUT,
	}

	/// <summary>Use this interface to receive a success or failure notification when a Windows Connect Now connect session completes.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nn-wcndevice-iwcnconnectnotify
	[PInvokeData("wcndevice.h", MSDNShortId = "NN:wcndevice.IWCNConnectNotify")]
	[ComImport, Guid("C100BE9F-D33A-4a4b-BF23-BBEF4663D017"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWCNConnectNotify
	{
		/// <summary>
		/// The <c>IWCNConnectNotify::ConnectSucceeded</c> callback method that indicates a successful IWCNDevice::Connect operation.
		/// </summary>
		/// <returns>...</returns>
		/// <remarks>
		/// <para>
		/// Notification of success does not implicitly indicate that the device is ready, as some devices reboot in order to apply
		/// settings provided during the IWCNDevice::Connect operation.
		/// </para>
		/// <para>
		/// If the IWCNDevice interface was used to obtain network settings from a device, then the network profile is immediately ready
		/// for use.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcnconnectnotify-connectsucceeded HRESULT ConnectSucceeded();
		[PreserveSig]
		HRESULT ConnectSucceeded();

		/// <summary>The <c>IWCNConnectNotify::ConnectFailed</c> callback method indicates a IWCNDevice::Connect failure.</summary>
		/// <param name="hrFailure">An <c>HRESULT</c> that specifies the reason for the connection failure.</param>
		/// <returns>This method does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcnconnectnotify-connectfailed HRESULT
		// ConnectFailed( HRESULT hrFailure );
		[PreserveSig]
		HRESULT ConnectFailed(HRESULT hrFailure);
	}

	/// <summary>Use this interface to configure the device and initiate the session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nn-wcndevice-iwcndevice
	[PInvokeData("wcndevice.h", MSDNShortId = "NN:wcndevice.IWCNDevice")]
	[ComImport, Guid("C100BE9C-D33A-4a4b-BF23-BBEF4663D017"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(WCNDeviceObject))]
	public interface IWCNDevice
	{
		/// <summary>
		/// The <c>IWCNDevice::SetPassword</c> method configures the authentication method value, and if required, a password used for
		/// the pending session. This method may only be called prior to IWCNDevice::Connect.
		/// </summary>
		/// <param name="Type">
		/// <para>A <c>WCN_PASSWORD_TYPE</c> value that specifies the authentication method used for the session.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WCN_PASSWORD_TYPE_PUSH_BUTTON</term>
		/// <term>Use PushButton authentication. The value of dwPasswordLength must be NULL.</term>
		/// </item>
		/// <item>
		/// <term>WCN_PASSWORD_TYPE_PIN</term>
		/// <term>Use PIN-based authentication.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwPasswordLength">Number of bytes in the buffer pbPassword.</param>
		/// <param name="pbPassword">A byte array of the password, encoded in ASCII.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The password will be used for the pending session.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The password type is WCN_PASSWORD_TYPE_PUSH_BUTTON and the password length is not zero. The password type is not
		/// WCN_PASSWORD_TYPE_PUSH_BUTTON or WCN_PASSWORD_TYPE_PIN.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The byte array is not <c>NULL</c>-terminated. For example, if the password is a 4-digit PIN, you should pass
		/// dwPasswordLength as 4 and pbPassword should point to a 4-byte array containing the PIN in ASCII.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-setpassword HRESULT SetPassword(
		// WCN_PASSWORD_TYPE Type, DWORD dwPasswordLength, const BYTE [] pbPassword );
		[PreserveSig]
		HRESULT SetPassword(WCN_PASSWORD_TYPE Type, uint dwPasswordLength, [MarshalAs(UnmanagedType.LPStr)] string pbPassword);

		/// <summary>The <c>IWCNDevice::Connect</c> method initiates the session.</summary>
		/// <param name="pNotify">
		/// A pointer to the implemented IWCNConnectNotify callback interface which specifies if a connection has been successfully established.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The operation has succeeded.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</term>
		/// <term>The device does not support the connection options queued via IWCNDevice::Set.</term>
		/// </item>
		/// <item>
		/// <term>WCN_E_PEER_NOT_FOUND</term>
		/// <term>The device could not be located on the network.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// After calling this method you may not call any other IWCNDevice 'Set' methods. There is no way to cancel or roll back device
		/// settings once a connection has been established.
		/// </para>
		/// <para>
		/// <c>NULL</c> can be passed via pNotify, in place of the IWCNConnectNotify callback interface to prevent notification from
		/// being sent when the connect operation is complete.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-connect HRESULT Connect(
		// IWCNConnectNotify *pNotify );
		[PreserveSig]
		HRESULT Connect([In, Optional] IWCNConnectNotify pNotify);

		/// <summary>The <c>IWCNDevice::GetAttribute</c> method gets a cached attribute from the device.</summary>
		/// <param name="AttributeType">
		/// A <c>WCN_ATTRIBUTE_TYPE</c> value that represents a specific attribute value (for example, <c>WCN_PASSWORD_TYPE</c>).
		/// </param>
		/// <param name="dwMaxBufferSize">The allocated size, in bytes, of pbBuffer.</param>
		/// <param name="pbBuffer">A user-allocated buffer that, on successful return, contains the contents of the attribute.</param>
		/// <param name="pdwBufferUsed">On return, contains the size of the attribute in bytes.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</term>
		/// <term>The attribute specified is not available.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The buffer specified by pbBuffer is not large enough to contain the returned attribute value.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// To only query the size of an attribute, a value of 0 (zero) can be passed via dwMaxBufferSize and pdwBufferUsed will be
		/// filled appropriately.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-getattribute HRESULT GetAttribute(
		// WCN_ATTRIBUTE_TYPE AttributeType, DWORD dwMaxBufferSize, BYTE [] pbBuffer, DWORD *pdwBufferUsed );
		[PreserveSig]
		HRESULT GetAttribute(WCN_ATTRIBUTE_TYPE AttributeType, uint dwMaxBufferSize, [Out] IntPtr pbBuffer, out uint pdwBufferUsed);

		/// <summary>The GetIntegerAttribute method gets a cached attribute from the device as an integer.</summary>
		/// <param name="AttributeType">
		/// A <c>WCN_ATTRIBUTE_TYPE</c> value that represents a specific attribute value (for example, <c>WCN_PASSWORD_TYPE</c>).
		/// </param>
		/// <param name="puInteger">Pointer to an unsigned-integer that represents the retrieved attribute value.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</term>
		/// <term>The attribute specified is not available.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The buffer specified by pbBuffer is not large enough to contain the returned attribute value.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INVALID_DATATYPE)</term>
		/// <term>This attribute cannot be expressed as an integer. For example, if it is a string.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-getintegerattribute HRESULT
		// GetIntegerAttribute( WCN_ATTRIBUTE_TYPE AttributeType, UINT *puInteger );
		[PreserveSig]
		HRESULT GetIntegerAttribute(WCN_ATTRIBUTE_TYPE AttributeType, out uint puInteger);

		/// <summary>The <c>IWCNDevice::GetStringAttribute</c> method gets a cached attribute from the device as a string.</summary>
		/// <param name="AttributeType">
		/// A <c>WCN_ATTRIBUTE_TYPE</c> value that represents a specific attribute value (for example, <c>WCN_PASSWORD_TYPE</c>). If the
		/// attribute is not natively a string data type (for example, <c>WCN_TYPE_VERSION</c> is natively an integer, and
		/// <c>WNC_TYPE_SSID</c> is natively a blob), this function will fail with <c>HRESULT_FROM_WIN32(ERROR_INVALID_DATATYPE)</c>.
		/// </param>
		/// <param name="cchMaxString">The size of the buffer wszString, in characters.</param>
		/// <param name="wszString">
		/// A user-allocated buffer that, on successful return, contains a <c>NULL</c>-terminated string value of the vendor extension.
		/// </param>
		/// <returns>
		/// <para>...</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</term>
		/// <term>The attribute specified is not available.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The buffer specified by wszString is not large enough to contain the returned attribute value.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INVALID_DATATYPE)</term>
		/// <term>This attribute cannot be expressed as a string. For example, if it is an integer.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-getstringattribute HRESULT
		// GetStringAttribute( WCN_ATTRIBUTE_TYPE AttributeType, DWORD cchMaxString, WCHAR [] wszString );
		[PreserveSig]
		HRESULT GetStringAttribute(WCN_ATTRIBUTE_TYPE AttributeType, uint cchMaxString, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszString);

		/// <summary>The <c>IWCNDevice::GetNetworkProfile</c> method gets a network profile from the device.</summary>
		/// <param name="cchMaxStringLength">The allocated size, in characters, of wszProfile.</param>
		/// <param name="wszProfile">A string that specifies the XML WLAN network profile type.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The network profile was successfully retrieved.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This function can only be called after IWCNDevice::Connect has been called, and the session has completed successfully.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-getnetworkprofile HRESULT
		// GetNetworkProfile( DWORD cchMaxStringLength, LPWSTR wszProfile );
		[PreserveSig]
		HRESULT GetNetworkProfile(uint cchMaxStringLength, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder wszProfile);

		/// <summary>
		/// The <c>IWCNDevice::SetNetworkProfile</c> method queues an XML WLAN profile to be provisioned to the device. This method may
		/// only be called prior to IWCNDevice::Connect.
		/// </summary>
		/// <param name="pszProfileXml">The XML WLAN profile XML string.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</term>
		/// <term>The WLAN profile is not supported for WCN connections.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_BAD_PROFILE)</term>
		/// <term>The provided XML profile cannot be read.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Currently, the <c>Windows Connect Now API</c> (WCNAPI) supports the following profile types:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>None (Open or Shared)</term>
		/// </item>
		/// <item>
		/// <term>WEP (Open or Shared)</term>
		/// </item>
		/// <item>
		/// <term>WPA-PSK (TKIP or AES)</term>
		/// </item>
		/// <item>
		/// <term>WPA2-PSK (TKIP or AES)</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the specified WLAN profile has extraneous settings (like IHV settings), these settings will be ignored. In the event a
		/// WLAN profile is not compatible with the WCNAPI, an <c>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</c> value is returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-setnetworkprofile HRESULT
		// SetNetworkProfile( LPCWSTR pszProfileXml );
		[PreserveSig]
		HRESULT SetNetworkProfile([MarshalAs(UnmanagedType.LPWStr)] string pszProfileXml);

		/// <summary>The <c>GetVendorExtension</c> method gets a cached vendor extension from the device.</summary>
		/// <param name="pVendorExtSpec">
		/// A pointer to a user-defined <c>WCN_VENDOR_EXTENSION_SPEC</c> structure that describes the vendor extension to query for.
		/// </param>
		/// <param name="dwMaxBufferSize">The size, in bytes, of pbBuffer.</param>
		/// <param name="pbBuffer">An allocated buffer that, on return, contains the contents of the vendor extension.</param>
		/// <param name="pdwBufferUsed">On return, contains the size of the vendor extension in bytes.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The vendor extension was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_NOT_FOUND)</term>
		/// <term>The vendor extension specified is not available.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</term>
		/// <term>The buffer specified by pbBuffer is not large enough to contain the returned vendor extension.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// To query the size of a vendor extension, you can pass a value of 0 with the dwMaxBufferSize parameter, and pdwBufferUsed
		/// will receive the size.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-getvendorextension HRESULT
		// GetVendorExtension( const WCN_VENDOR_EXTENSION_SPEC *pVendorExtSpec, DWORD dwMaxBufferSize, BYTE [] pbBuffer, DWORD
		// *pdwBufferUsed );
		[PreserveSig]
		HRESULT GetVendorExtension(in WCN_VENDOR_EXTENSION_SPEC pVendorExtSpec, uint dwMaxBufferSize, [Out] IntPtr pbBuffer, out uint pdwBufferUsed);

		/// <summary>
		/// The <c>IWCNDevice::SetVendorExtension</c> method queues a vendor extension for use in the pending session. This function may
		/// only be called prior to IWCNDevice::Connect.
		/// </summary>
		/// <param name="pVendorExtSpec">
		/// A pointer to a <c>WCN_VENDOR_EXTENSION_SPEC</c> structure that contains the vendor extension specification.
		/// </param>
		/// <param name="cbBuffer">The number of bytes contained in pbBuffer.</param>
		/// <param name="pbBuffer">Pointer to a buffer that contains the data to set in the vendor extension.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The vendor extension will be sent in the pending session.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified WCN_VENDOR_EXTENSION_SPEC contains an illegal VendorID, sub-type, or flag.</term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_IMPLEMENTATION_LIMIT)</term>
		/// <term>
		/// The number of vendor extensions has exceeded the current implementation limit, which is currently equal to 25 vendor
		/// extensions per session.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-setvendorextension HRESULT
		// SetVendorExtension( const WCN_VENDOR_EXTENSION_SPEC *pVendorExtSpec, DWORD cbBuffer, const BYTE [] pbBuffer );
		[PreserveSig]
		HRESULT SetVendorExtension(in WCN_VENDOR_EXTENSION_SPEC pVendorExtSpec, uint cbBuffer, [In] IntPtr pbBuffer);

		/// <summary>The <c>IWCNDevice::Unadvise</c> method removes any callback previously set via IWCNDevice::Connect.</summary>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// It is not necessary to call <c>IWCNDevice::Unadvise</c> unless the application is shutting down and must ensure that no more
		/// callbacks are received on its IWCNConnectNotify callback. Do not call <c>IWCNDevice::Unadvise</c> from within an
		/// <c>IWCNConnectNotify</c> callback, since that will cause a deadlock. Note that <c>IWCNDevice::Unadvise</c> does not cancel
		/// the connect operation on the wire.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/nf-wcndevice-iwcndevice-unadvise HRESULT Unadvise();
		[PreserveSig]
		HRESULT Unadvise();

		/// <summary>Sets the NFC password parameters.</summary>
		/// <param name="Type">The password type.</param>
		/// <param name="dwOOBPasswordID">The password identifier.</param>
		/// <param name="dwPasswordLength">Length of the password.</param>
		/// <param name="pbPassword">The password.</param>
		/// <param name="dwRemotePublicKeyHashLength">Length of the remote public key hash.</param>
		/// <param name="pbRemotePublicKeyHash">The remote public key hash.</param>
		/// <param name="dwDHKeyBlobLength">Length of the key BLOB.</param>
		/// <param name="pbDHKeyBlob">The key BLOB.</param>
		/// <returns></returns>
		[PreserveSig]
		HRESULT SetNFCPasswordParams(WCN_PASSWORD_TYPE Type, uint dwOOBPasswordID, uint dwPasswordLength,
			[In] IntPtr pbPassword, uint dwRemotePublicKeyHashLength, [In] IntPtr pbRemotePublicKeyHash,
			uint dwDHKeyBlobLength, [In] IntPtr pbDHKeyBlob);
	}

	/// <summary>The GetIntegerAttribute method gets a cached attribute from the device as an integer.</summary>
	/// <typeparam name="T">The type to which the retrieved integer is converted.</typeparam>
	/// <param name="iDev">The <see cref="IWCNDevice"/> instance.</param>
	/// <param name="AttributeType">A <c>WCN_ATTRIBUTE_TYPE</c> value that represents a specific attribute value (for example, <c>WCN_PASSWORD_TYPE</c>).</param>
	/// <returns>The retrieved attribute value.</returns>
	public static T GetIntegerAttribute<T>(this IWCNDevice iDev, WCN_ATTRIBUTE_TYPE AttributeType) where T : struct, IConvertible
	{
		var hr = iDev.GetIntegerAttribute(AttributeType, out var u);
		return hr.Succeeded ? (T)Convert.ChangeType(u, typeof(T)) : throw hr.GetException();
	}

	/// <summary>The <c>WCN_VENDOR_EXTENSION_SPEC</c> structure contains data that defines a vendor extension.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wcndevice/ns-wcndevice-wcn_vendor_extension_spec typedef struct
	// tagWCN_VENDOR_EXTENSION_SPEC { DWORD VendorId; DWORD SubType; DWORD Index; DWORD Flags; } WCN_VENDOR_EXTENSION_SPEC;
	[PInvokeData("wcndevice.h", MSDNShortId = "NS:wcndevice.tagWCN_VENDOR_EXTENSION_SPEC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCN_VENDOR_EXTENSION_SPEC
	{
		/// <summary>
		/// Set this value to the SMI Enterprise ID Number of the vendor that defines the vendor extension. For example, the Microsoft
		/// ID is '311' (WCN_MICROSOFT_VENDOR_ID).
		/// </summary>
		public uint VendorId;

		/// <summary>
		/// The subtype, as defined by the first two bytes of the vendor extension. If the vendor has not provided the two-byte subtype
		/// prefix, use WCN_NO_SUBTYPE.
		/// </summary>
		public uint SubType;

		/// <summary>Distinguishes between multiple vendor extensions with the same VendorID and SubType. The index begins at zero.</summary>
		public uint Index;

		/// <summary>
		/// <para>Applications must specify one of the following flag values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WCN_FLAG_DISCOVERY_VE 0x0001</term>
		/// <term>The vendor extension was not available before the session started. The vendor extension is not secure.</term>
		/// </item>
		/// <item>
		/// <term>WCN_FLAG_AUTHENTICATED_VE 0x0002</term>
		/// <term>The vendor extension is authentic. Only devices that pass authentication can read or write authenticated vendor extensions.</term>
		/// </item>
		/// <item>
		/// <term>WCN_FLAG_ENCRYPTED_VE 0x0004</term>
		/// <term>
		/// The vendor extension is authentic and encrypted. In addition to the guarantee of authenticated vendor extensions, vendor
		/// extensions are encrypted before transmission.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public WCN_FLAG Flags;
	}

	/// <summary>Class object for <see cref="IWCNDevice"/>.</summary>
	[ComImport, Guid("C100BEA7-D33A-4a4b-BF23-BBEF4663D017"), ClassInterface(ClassInterfaceType.None)]
	public class WCNDeviceObject { }
}