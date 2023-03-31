using System;
using System.Runtime.InteropServices;
using Vanara.Collections;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class WlanApi
{
	/// <summary>Specifies the authentication algorithm for user or machine authentication on an ad hoc network.</summary>
	[PInvokeData("adhoc.h")]
	public enum DOT11_ADHOC_AUTH_ALGORITHM
	{
		/// <summary>The authentication algorithm specified is invalid.</summary>
		DOT11_ADHOC_AUTH_ALGO_INVALID = -1,

		/// <summary>Specifies an IEEE 802.11 Open System authentication algorithm.</summary>
		DOT11_ADHOC_AUTH_ALGO_80211_OPEN = 1,

		/// <summary>
		/// Specifies an IEEE 802.11i Robust Security Network Association (RSNA) algorithm that uses the pre-shared key (PSK) mode. IEEE
		/// 802.1X port authorization is performed by the supplicant and authenticator. Cipher keys are dynamically derived through a
		/// pre-shared key that is used on both the supplicant and authenticator.
		/// </summary>
		DOT11_ADHOC_AUTH_ALGO_RSNA_PSK = 7
	}

	/// <summary>Specifies a cipher algorithm used to encrypt and decrypt information on an ad hoc network.</summary>
	[PInvokeData("adhoc.h")]
	public enum DOT11_ADHOC_CIPHER_ALGORITHM
	{
		/// <summary>The cipher algorithm specified is invalid.</summary>
		DOT11_ADHOC_CIPHER_ALGO_INVALID = -1,

		/// <summary>Specifies that no cipher algorithm is enabled or supported.</summary>
		DOT11_ADHOC_CIPHER_ALGO_NONE = 0x00,

		/// <summary>
		/// Specifies a Counter Mode with Cipher Block Chaining Message Authentication Code Protocol (CCMP) algorithm. The CCMP
		/// algorithm is specified in the IEEE 802.11i-2004 standard and RFC 3610. CCMP is used with the Advanced Encryption Standard
		/// (AES) encryption algorithm, as defined in FIPS PUB 197.
		/// </summary>
		DOT11_ADHOC_CIPHER_ALGO_CCMP = 0x04,

		/// <summary>Specifies a Wired Equivalent Privacy (WEP) algorithm of any length.</summary>
		DOT11_ADHOC_CIPHER_ALGO_WEP = 0x101,
	}

	/// <summary>Specifies the reason why a connection attempt failed.</summary>
	[PInvokeData("adhoc.h")]
	public enum DOT11_ADHOC_CONNECT_FAIL_REASON
	{
		/// <summary>
		/// The local host's configuration is incompatible with the target network. This occurs when the local host is 802.11d compliant
		/// and the regulatory domain of the local host is not compatible with the regulatory domain of the target network. For more
		/// information about regulatory domains, see the IEEE 802.11d-2001 standard. The standard can be downloaded from the IEEE website.
		/// </summary>
		DOT11_ADHOC_CONNECT_FAIL_DOMAIN_MISMATCH = 0,

		/// <summary>The passphrase supplied to authenticate the local machine or user on the target network is incorrect.</summary>
		DOT11_ADHOC_CONNECT_FAIL_PASSPHRASE_MISMATCH = 1,

		/// <summary>The connection failed for another reason.</summary>
		DOT11_ADHOC_CONNECT_FAIL_OTHER = 2
	}

	/// <summary>Specifies the connection state of an ad hoc network.</summary>
	[PInvokeData("adhoc.h")]
	public enum DOT11_ADHOC_NETWORK_CONNECTION_STATUS
	{
		/// <summary>The connection status cannot be determined. A network with this status should not be used.</summary>
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS_INVALID = 0,

		/// <summary>
		/// There are no hosts or clients connected to the network. There are also no pending connection requests for this network.
		/// </summary>
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS_DISCONNECTED = 11,

		/// <summary>
		/// There is an outstanding connection request. Once the client or host succeeds or fails in its connection attempt, the
		/// connection status is updated.
		/// </summary>
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS_CONNECTING = 12,

		/// <summary>A client or host is connected to the network.</summary>
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS_CONNECTED = 13,

		/// <summary>The network has been formed. Once a client or host connects to the network, the connection status is updated.</summary>
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS_FORMED = 14
	}

	/// <summary>
	/// <para>Represents a wireless network interface card (NIC).</para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocinterface
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocInterface")]
	[ComImport, Guid("8F10CC2B-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDot11AdHocInterface
	{
		/// <summary>
		/// Gets the signature of the NIC. This signature is stored in the registry and it is used by TCP/IP to uniquely identify the NIC.
		/// </summary>
		/// <returns>The signature of the NIC.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-getdevicesignature HRESULT
		// GetDeviceSignature( GUID *pSignature );
		Guid GetDeviceSignature();

		/// <summary>Gets the friendly name of the NIC.</summary>
		/// <returns>
		/// <para>The friendly name of the NIC. The SSID of the network is used as the friendly name.</para>
		/// <para>You must free this string using CoTaskMemFree.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-getfriendlyname HRESULT
		// GetFriendlyName( LPWSTR *ppszName );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetFriendlyName();

		/// <summary>Specifies whether the NIC is 802.11d compliant.</summary>
		/// <returns>
		/// A pointer to a boolean that specifies 802.11d compliance. The boolean value is set to <c>TRUE</c> if the NIC is compliant
		/// and <c>FALSE</c> otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-isdot11d HRESULT IsDot11d( BOOLEAN
		// *pf11d );
		[return: MarshalAs(UnmanagedType.U1)]
		bool IsDot11d();

		/// <summary>Specifies whether a NIC supports the creation or use of an ad hoc network.</summary>
		/// <returns>
		/// A pointer to a boolean that specifies the NIC's ad hoc network capabilities. The boolean value is set to <c>TRUE</c> if the
		/// NIC supports the creation and use of ad hoc networks and <c>FALSE</c> otherwise.
		/// </returns>
		/// <remarks>
		/// <para>pfAdHocCapable can be set to <c>FALSE</c> for many reasons, including the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Group policy prohibits the use of ad hoc networks on this interface</term>
		/// </item>
		/// <item>
		/// <term>
		/// The machine is configured to only connect to infrastructure networks, or the machine configuration disallows wireless connections
		/// </term>
		/// </item>
		/// <item>
		/// <term>The NIC does not support ad hoc networks</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-isadhoccapable HRESULT IsAdHocCapable(
		// BOOLEAN *pfAdHocCapable );
		[return: MarshalAs(UnmanagedType.U1)]
		bool IsAdHocCapable();

		/// <summary>Specifies whether the radio is on.</summary>
		/// <returns>A pointer to a boolean that specifies the radio state. The value is set to <c>TRUE</c> if the radio is on.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-isradioon HRESULT IsRadioOn( BOOLEAN
		// *pfIsRadioOn );
		[return: MarshalAs(UnmanagedType.U1)]
		bool IsRadioOn();

		/// <summary>Gets the network that is currently active on the interface.</summary>
		/// <returns>A pointer to an IDot11AdHocNetwork object that represents the active network.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-getactivenetwork HRESULT
		// GetActiveNetwork( IDot11AdHocNetwork **ppNetwork );
		IDot11AdHocNetwork GetActiveNetwork();

		/// <summary>Gets the collection of security settings associated with this NIC.</summary>
		/// <returns>A pointer to an IEnumDot11AdHocSecuritySettings interface that contains the collection of security settings.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-getienumsecuritysettings HRESULT
		// GetIEnumSecuritySettings( IEnumDot11AdHocSecuritySettings **ppEnum );
		IEnumDot11AdHocSecuritySettings GetIEnumSecuritySettings();

		/// <summary>Gets the collection of networks associated with this NIC.</summary>
		/// <param name="pFilterGuid">
		/// An optional parameter that specifies the GUID of the application that created the network. An application can use this
		/// identifier to limit the networks enumerated to networks created by the application. For this filtering to work correctly,
		/// all instances of the application on all machines must use the same GUID.
		/// </param>
		/// <returns>A pointer to a IEnumDot11AdHocNetworks interface that contains the enumerated networks.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-getienumdot11adhocnetworks HRESULT
		// GetIEnumDot11AdHocNetworks( GUID *pFilterGuid, IEnumDot11AdHocNetworks **ppEnum );
		IEnumDot11AdHocNetworks GetIEnumDot11AdHocNetworks([In, Optional] GuidPtr pFilterGuid);

		/// <summary>
		/// Gets the connection status of the active network associated with this NIC. You can determine the active network by calling IDot11AdHocInterface::GetActiveNetwork.
		/// </summary>
		/// <returns>A pointer to a DOT11_ADHOC_NETWORK_CONNECTION_STATUS value that specifies the connection state.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterface-getstatus HRESULT GetStatus(
		// DOT11_ADHOC_NETWORK_CONNECTION_STATUS *pState );
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS GetStatus();
	}

	/// <summary>
	/// <para>
	/// The <c>IDot11AdHocInterfaceNotificationSink</c> interface defines the notifications supported by IDot11AdHocInterface. To
	/// register for notifications, call the Advise method on an instantiated IDot11AdHocManager object with the
	/// <c>IDot11AdHocInterfaceNotificationSink</c> interface passed as the pUnk parameter. To terminate notifications, call the
	/// Unadvise method.
	/// </para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocinterfacenotificationsink
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocInterfaceNotificationSink")]
	[ComImport, Guid("8F10CC2F-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDot11AdHocInterfaceNotificationSink
	{
		/// <summary>Notifies the client that the connection status of the network associated with the NIC has changed.</summary>
		/// <param name="eStatus">A pointer to a DOT11_ADHOC_NETWORK_CONNECTION_STATUS value that specifies the new connection state.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This notification is triggered when the connection status changes as a result of connection and disconnection requests
		/// issued by the current application. It is also triggered when other applications issue successful connection and
		/// disconnection requests using the IDot11AdHocNetwork methods or the Native Wifi functions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocinterfacenotificationsink-onconnectionstatuschange
		// HRESULT OnConnectionStatusChange( DOT11_ADHOC_NETWORK_CONNECTION_STATUS eStatus );
		[PreserveSig]
		HRESULT OnConnectionStatusChange(DOT11_ADHOC_NETWORK_CONNECTION_STATUS eStatus);
	}

	/// <summary>
	/// <para>
	/// The <c>IDot11AdHocManager</c> interface creates and manages 802.11 ad hoc networks. It is the top-level 802.11 ad hoc interface
	/// and the only ad hoc interface with a coclass. As such, it is the only ad hoc interface that can be instantiated by CoCreateInstance.
	/// </para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// <para>
	/// The <c>IDot11AdHocManager</c> coclass implements the IConnectionPoint interface. The Advise method can be used to register for
	/// network manager, network, and interface-related notifications. Notifications are implemented by the
	/// IDot11AdHocManagerNotificationSink interface. To register for notifications, call the <c>Advise</c> method with the appropriate
	/// notification sink interface as the pUnk parameter.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocmanager
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocManager")]
	[ComImport, Guid("8F10CC26-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(Dot11AdHocManager))]
	public interface IDot11AdHocManager
	{
		/// <summary>Creates a wireless ad hoc network. Other clients and hosts can connect to this network.</summary>
		/// <param name="Name">
		/// The friendly name of the network. This string should be limited to 32 characters. The SSID should be used as the friendly
		/// name. This name is broadcasted in a beacon.
		/// </param>
		/// <param name="Password">
		/// <para>The password used for machine or user authentication on the network.</para>
		/// <para>
		/// The length of the password string depends on the security settings passed in the pSecurity parameter. The following table
		/// shows the password length associated with various security settings.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Security Settings</term>
		/// <term>Password Length</term>
		/// </listheader>
		/// <item>
		/// <term>Open-None</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>Open-WEP</term>
		/// <term>5 or 13 characters; 10 or 26 hexadecimal digits</term>
		/// </item>
		/// <item>
		/// <term>WPA2PSK</term>
		/// <term>8 to 63 characters</term>
		/// </item>
		/// </list>
		/// <para>
		/// For the enumerated values that correspond to the security settings pair above, see DOT11_ADHOC_AUTH_ALGORITHM and DOT11_ADHOC_CIPHER_ALGORITHM
		/// </para>
		/// </param>
		/// <param name="GeographicalId">
		/// <para>
		/// The geographical location in which the network will be created. For a list of possible values, see Table of Geographical Locations.
		/// </para>
		/// <para>
		/// If the interface is not 802.11d conformant, this value is ignored. That means if IDot11AdHocInterface::IsDot11d returns
		/// <c>FALSE</c>, this value is ignored.
		/// </para>
		/// <para>
		/// If you are not sure which value to use, set GeographicalId to CTRY_DEFAULT. If you use CTRY_DEFAULT, 802.11d conformance is
		/// not enforced.
		/// </para>
		/// </param>
		/// <param name="pInterface">
		/// An optional pointer to an IDot11AdHocInterface that specifies the network interface upon which the new network is created.
		/// If this parameter is <c>NULL</c>, the first unused interface is used. If all interfaces are in use, the first enumerated
		/// interface is used. In that case, the previous network on the interface is disconnected.
		/// </param>
		/// <param name="pSecurity">
		/// A pointer to an IDot11AdHocSecuritySettings interface that specifies the security settings used on the network.
		/// </param>
		/// <param name="pContextGuid">
		/// An optional parameter that specifies the GUID of the application that created the network. An application can use this
		/// identifier to limit the networks enumerated by GetIEnumDot11AdHocNetworks to networks created by the application. For this
		/// filtering to work correctly, all instances of the application on all machines must use the same GUID.
		/// </param>
		/// <returns>A pointer to an IDot11AdHocNetwork interface that represents the created network.</returns>
		/// <remarks>
		/// <para>
		/// After a successful <c>CreateNetwork</c> call, the network object returned by pIAdHoc is provisioned but not constructed. A
		/// subsequent call to CommitCreatedNetwork initializes the network. Beacons are not sent until the network is committed.
		/// </para>
		/// <para>
		/// There are no clients or hosts connected to the network after a <c>CreateNetwork</c> call. Applications are notified of both
		/// successful and failed connection attempts using the IDot11AdHocManagerNotificationSink interface. For information about
		/// registering for notifications on that interface, see IDot11AdHocManager.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanager-createnetwork HRESULT CreateNetwork(
		// LPCWSTR Name, LPCWSTR Password, LONG GeographicalId, IDot11AdHocInterface *pInterface, IDot11AdHocSecuritySettings
		// *pSecurity, GUID *pContextGuid, IDot11AdHocNetwork **pIAdHoc );
		IDot11AdHocNetwork CreateNetwork([MarshalAs(UnmanagedType.LPWStr)] string Name, [MarshalAs(UnmanagedType.LPWStr)] string Password,
			int GeographicalId, [In, Optional] IDot11AdHocInterface pInterface, IDot11AdHocSecuritySettings pSecurity, [In, Optional] GuidPtr pContextGuid);

		/// <summary>
		/// Initializes a created network and optionally commits the network's profile to the profile store. The network must be created
		/// using CreateNetwork before calling <c>CommitCreatedNetwork</c>.
		/// </summary>
		/// <param name="pIAdHoc">A pointer to a IDot11AdHocNetwork interface that specifies the network to be initialized and committed.</param>
		/// <param name="fSaveProfile">
		/// <para>
		/// An optional parameter that specifies whether a wireless profile should be saved. If <c>TRUE</c>, the profile is saved to the
		/// profile store. Once a profile has been saved, the user can modify the profile using the <c>Manage Wireless Network</c> user
		/// interface. Profiles can also be modified using the Native Wifi Functions.
		/// </para>
		/// <para>Saving a profile modifies the network signature returned by IDot11AdHocNetwork::GetSignature.</para>
		/// </param>
		/// <param name="fMakeSavedProfileUserSpecific">
		/// <para>
		/// An optional parameter that specifies whether the profile to be saved is an all-user profile. If set to <c>TRUE</c>, the
		/// profile is specific to the current user. If set to <c>FALSE</c>, the profile is an all-user profile and can be used by any
		/// user logged into the machine. This parameter is ignored if fSaveProfile is <c>FALSE</c>.
		/// </para>
		/// <para>
		/// By default, only members of the Administrators group can persist an all-user profile. These security settings can be altered
		/// using the WlanSetSecuritySettings function. Your application must be launched by a user with sufficient privileges for an
		/// all-user profile to be persisted successfully.
		/// </para>
		/// <para>
		/// If your application is running in a Remote Desktop window, you can only save an all-user profile. User-specific profiles
		/// cannot be saved from an application running remotely.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanager-commitcreatednetwork HRESULT
		// CommitCreatedNetwork( IDot11AdHocNetwork *pIAdHoc, BOOLEAN fSaveProfile, BOOLEAN fMakeSavedProfileUserSpecific );
		void CommitCreatedNetwork(IDot11AdHocNetwork pIAdHoc, [MarshalAs(UnmanagedType.U1)] bool fSaveProfile, [MarshalAs(UnmanagedType.U1)] bool fMakeSavedProfileUserSpecific);

		/// <summary>Returns a list of available ad hoc network destinations within connection range. This list may be filtered.</summary>
		/// <param name="pContextGuid">
		/// An optional parameter that specifies the GUID of the application that created the network. An application can use this
		/// identifier to limit the networks enumerated to networks created by the application. For this filtering to work correctly,
		/// all instances of the application on all machines must use the same GUID.
		/// </param>
		/// <returns>A pointer to an IEnumDot11AdHocNetworks interface that contains the enumerated networks.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanager-getienumdot11adhocnetworks HRESULT
		// GetIEnumDot11AdHocNetworks( GUID *pContextGuid, IEnumDot11AdHocNetworks **ppEnum );
		IEnumDot11AdHocNetworks GetIEnumDot11AdHocNetworks([In, Optional] GuidPtr pContextGuid);

		/// <summary>Returns the set of wireless network interface cards (NICs) available on the machine.</summary>
		/// <returns>A pointer to an IEnumDot11AdHocInterfaces interface that contains the list of NICs.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanager-getienumdot11adhocinterfaces HRESULT
		// GetIEnumDot11AdHocInterfaces( IEnumDot11AdHocInterfaces **ppEnum );
		IEnumDot11AdHocInterfaces GetIEnumDot11AdHocInterfaces();

		/// <summary>Returns the network associated with a signature.</summary>
		/// <param name="NetworkSignature">
		/// A signature that uniquely identifies an ad hoc network. This signature is generated from certain network attributes.
		/// </param>
		/// <returns>A pointer to an IDot11AdHocNetwork interface that represents the network associated with the signature.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanager-getnetwork HRESULT GetNetwork( GUID
		// *NetworkSignature, IDot11AdHocNetwork **pNetwork );
		IDot11AdHocNetwork GetNetwork(in Guid NetworkSignature);
	}

	/// <summary>
	/// <para>
	/// The <c>IDot11AdHocManagerNotificationSink</c> interface defines the notifications supported by the IDot11AdHocManager interface.
	/// To register for notifications, call the Advise method on an instantiated IDot11AdHocManager object with the
	/// <c>IDot11AdHocManagerNotificationSink</c> interface passed as the pUnk parameter. To terminate notifications, call the Unadvise method.
	/// </para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocmanagernotificationsink
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocManagerNotificationSink")]
	[ComImport, Guid("8F10CC27-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDot11AdHocManagerNotificationSink
	{
		/// <summary>Notifies the client that a new wireless ad hoc network destination is in range and available for connection.</summary>
		/// <param name="pIAdHocNetwork">A pointer to an IDot11AdHocNetwork interface that represents the new network.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanagernotificationsink-onnetworkadd HRESULT
		// OnNetworkAdd( IDot11AdHocNetwork *pIAdHocNetwork );
		[PreserveSig]
		HRESULT OnNetworkAdd(IDot11AdHocNetwork pIAdHocNetwork);

		/// <summary>Notifies the client that a wireless ad hoc network destination is no longer available for connection.</summary>
		/// <param name="Signature">
		/// A pointer to a signature that uniquely identifies the newly unavailable network. For more information about signatures, see IDot11AdHocNetwork::GetSignature.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanagernotificationsink-onnetworkremove HRESULT
		// OnNetworkRemove( GUID *Signature );
		[PreserveSig]
		HRESULT OnNetworkRemove(in Guid Signature);

		/// <summary>Notifies the client that a new network interface card (NIC) is active.</summary>
		/// <param name="pIAdHocInterface">A pointer to an IDot11AdHocInterface interface that represents the activated NIC.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanagernotificationsink-oninterfaceadd HRESULT
		// OnInterfaceAdd( IDot11AdHocInterface *pIAdHocInterface );
		[PreserveSig]
		HRESULT OnInterfaceAdd(IDot11AdHocInterface pIAdHocInterface);

		/// <summary>Notifies the client that a network interface card (NIC) has become inactive.</summary>
		/// <param name="Signature">
		/// A pointer to a signature that uniquely identifies the inactive NIC. For more information about signatures, see IDot11AdHocInterface::GetDeviceSignature.
		/// </param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocmanagernotificationsink-oninterfaceremove
		// HRESULT OnInterfaceRemove( GUID *Signature );
		[PreserveSig]
		HRESULT OnInterfaceRemove(in Guid Signature);
	}

	/// <summary>
	/// <para>
	/// The <c>IDot11AdHocNetwork</c> interface represents an available ad hoc network destination within connection range. Before an
	/// application can connect to a network, the network must have been created using IDot11AdHocManager::CreateNetwork and committed
	/// using IDot11AdHocManager::CommitCreatedNetwork.
	/// </para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocnetwork
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocNetwork")]
	[ComImport, Guid("8F10CC29-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDot11AdHocNetwork
	{
		/// <summary>Gets the connection status of the network.</summary>
		/// <returns>A DOT11_ADHOC_NETWORK_CONNECTION_STATUS value that specifies the connection state.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getstatus HRESULT GetStatus(
		// DOT11_ADHOC_NETWORK_CONNECTION_STATUS *eStatus );
		DOT11_ADHOC_NETWORK_CONNECTION_STATUS GetStatus();

		/// <summary>Gets the SSID of the network.</summary>
		/// <returns>
		/// <para>The SSID of the network.</para>
		/// <para>You must free this string using CoTaskMemFree.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getssid HRESULT GetSSID( LPWSTR
		// *ppszwSSID );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetSSID();

		/// <summary>Returns a boolean value that specifies whether there is a saved profile associated with the network.</summary>
		/// <returns>
		/// Specifies whether the network has a profile. This value is set to <c>TRUE</c> if the network has a profile and <c>FALSE</c> otherwise.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-hasprofile HRESULT HasProfile( BOOLEAN
		// *pf11d );
		[return: MarshalAs(UnmanagedType.U1)]
		bool HasProfile();

		/// <summary>Gets the profile name associated with the network.</summary>
		/// <returns>
		/// <para>The name of the profile associated with the network. If the network has no profile, this parameter is <c>NULL</c>.</para>
		/// <para>You must free this string using CoTaskMemFree.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getprofilename HRESULT GetProfileName(
		// LPWSTR *ppszwProfileName );
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string GetProfileName();

		/// <summary>Deletes any profile associated with the network.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-deleteprofile HRESULT DeleteProfile();
		void DeleteProfile();

		/// <summary>Gets the signal quality values associated with the network's radio.</summary>
		/// <param name="puStrengthValue">The current signal strength. This parameter takes a ULONG value between 0 and puStrengthMax.</param>
		/// <param name="puStrengthMax">
		/// The maximum signal strength value. This parameter takes a ULONG value between 0 and 100. By default, puStrengthMax is set to 100.
		/// </param>
		/// <remarks>
		/// Signal strength, in this context, is measured on a linear scale. When puStrengthMax is set to the default value of 100,
		/// puStrengthValue represents the percentage of the maximum signal strength currently used for transmission.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getsignalquality HRESULT
		// GetSignalQuality( ULONG *puStrengthValue, ULONG *puStrengthMax );
		void GetSignalQuality(out uint puStrengthValue, out uint puStrengthMax);

		/// <summary>Gets the security settings for the network.</summary>
		/// <returns>A pointer to an IDot11AdHocSecuritySettings interface that contains the security settings for the network.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getsecuritysetting HRESULT
		// GetSecuritySetting( IDot11AdHocSecuritySettings **pAdHocSecuritySetting );
		IDot11AdHocSecuritySettings GetSecuritySetting();

		/// <summary>
		/// Gets the context identifier associated with the network. This GUID identifies the application that created the network.
		/// </summary>
		/// <returns>
		/// The context identifier associated with the network. If no ContextGuid was specified when the CreateNetwork call was made,
		/// the GUID returned consists of all zeros.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getcontextguid HRESULT GetContextGuid(
		// GUID *pContextGuid );
		Guid GetContextGuid();

		/// <summary>
		/// Gets the unique signature associated with the ad hoc network. The signature uniquely identifies an IDot11AdHocNetwork object
		/// with a particular set of attributes.
		/// </summary>
		/// <returns>A signature that uniquely identifies an ad hoc network. This signature is generated from certain network attributes.</returns>
		/// <remarks>
		/// Do not cache the returned signature locally. Whenever a network object changes, its signature changes. Actions that are not
		/// associated with notifications, such as saving the network's profile, can cause the signature to change.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getsignature HRESULT GetSignature( GUID
		// *pSignature );
		Guid GetSignature();

		/// <summary>Gets the interface associated with a network.</summary>
		/// <returns>A pointer to an IDot11AdHocInterface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-getinterface HRESULT GetInterface(
		// IDot11AdHocInterface **pAdHocInterface );
		IDot11AdHocInterface GetInterface();

		/// <summary>
		/// Connects to a previously created wireless ad hoc network. Before an application can connect to a network, the network must
		/// have been created using IDot11AdHocManager::CreateNetwork and committed using IDot11AdHocManager::CommitCreatedNetwork.
		/// </summary>
		/// <param name="Passphrase">
		/// <para>The password string used to authenticate the user or machine on the network.</para>
		/// <para>
		/// The length of the password string depends on the security settings passed in the pSecurity parameter of the CreateNetwork
		/// call. The following table shows the password length associated with various security settings.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Security Settings</term>
		/// <term>Password Length</term>
		/// </listheader>
		/// <item>
		/// <term>Open-None</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>Open-WEP</term>
		/// <term>5 or 13 characters; 10 or 26 hexadecimal digits</term>
		/// </item>
		/// <item>
		/// <term>WPA2PSK</term>
		/// <term>8 to 63 characters</term>
		/// </item>
		/// </list>
		/// <para>
		/// For the enumerated values that correspond to the security settings pair above, see DOT11_ADHOC_AUTH_ALGORITHM and DOT11_ADHOC_CIPHER_ALGORITHM.
		/// </para>
		/// </param>
		/// <param name="GeographicalId">
		/// The geographical location in which the network was created. For a list of possible values, see Table of Geographical Locations.
		/// </param>
		/// <param name="fSaveProfile">
		/// <para>
		/// An optional parameter that specifies whether a wireless profile should be saved. If <c>TRUE</c>, the profile is saved to the
		/// profile store. Once a profile is saved, the user can modify the profile using the <c>Manage Wireless Network</c> user
		/// interface. Profiles can also be modified using the Native Wifi Functions.
		/// </para>
		/// <para>Saving a profile modifies the network signature returned by IDot11AdHocNetwork::GetSignature.</para>
		/// </param>
		/// <param name="fMakeSavedProfileUserSpecific">
		/// <para>
		/// An optional parameter that specifies whether the profile to be saved is an all-user profile. If set to <c>TRUE</c>, the
		/// profile is specific to the current user. If set to <c>FALSE</c>, the profile is an all-user profile and can be used by any
		/// user logged into the machine. This parameter is ignored if fSaveProfile is <c>FALSE</c>.
		/// </para>
		/// <para>
		/// By default, only members of the Administrators group can save an all-user profile. These security settings can be altered
		/// using the WlanSetSecuritySettings function. Your application must be launched by a user with sufficient privileges for an
		/// all-user profile to be saved successfully.
		/// </para>
		/// <para>
		/// If your application is running in a Remote Desktop window, you can only save an all-user profile. User-specific profiles
		/// cannot be saved from an application running remotely.
		/// </para>
		/// </param>
		/// <remarks>
		/// This method is asynchronous. <c>Connect</c> returns S_OK immediately if the parameters passed to the method are valid.
		/// However, a return code of S_OK does not indicate that the connection was successful. You must register for notifications on
		/// the IDot11AdHocNetworkNotificationSink interface to be notified of connection success or failure. The
		/// IDot11AdHocNetworkNotificationSink::OnStatusChange method returns the connection status. For more information about
		/// registering for notifications, see IDot11AdHocManager.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-connect HRESULT Connect( LPCWSTR
		// Passphrase, LONG GeographicalId, BOOLEAN fSaveProfile, BOOLEAN fMakeSavedProfileUserSpecific );
		void Connect([MarshalAs(UnmanagedType.LPWStr)] string Passphrase, int GeographicalId, [MarshalAs(UnmanagedType.U1)] bool fSaveProfile, [MarshalAs(UnmanagedType.U1)] bool fMakeSavedProfileUserSpecific);

		/// <summary>Disconnects from an ad hoc network.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetwork-disconnect HRESULT Disconnect();
		void Disconnect();
	}

	/// <summary>
	/// <para>
	/// The <c>IDot11AdHocNetworkNotificationSink</c> interface defines the notifications supported by the IDot11AdHocNetwork interface.
	/// To register for notifications, call the Advise method on an instantiated IDot11AdHocManager object with the
	/// <c>IDot11AdHocNetworkNotificationSink</c> interface passed as the pUnk parameter. To terminate notifications, call the Unadvise method.
	/// </para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocnetworknotificationsink
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocNetworkNotificationSink")]
	[ComImport, Guid("8F10CC2A-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDot11AdHocNetworkNotificationSink
	{
		/// <summary>Notifies the client that the connection status of the network has changed.</summary>
		/// <param name="eStatus">A DOT11_ADHOC_NETWORK_CONNECTION_STATUS value that specifies the updated connection status.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This notification is triggered when the connection status changes as a result of connection and disconnection requests
		/// issued by the current application. It is also triggered when other applications issue successful connection and
		/// disconnection requests using the IDot11AdHocNetwork methods or the Native Wifi functions. Connection and disconnection
		/// requests triggered by the user interface will also trigger the <c>OnStatusChange</c> notification.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetworknotificationsink-onstatuschange HRESULT
		// OnStatusChange( DOT11_ADHOC_NETWORK_CONNECTION_STATUS eStatus );
		[PreserveSig]
		HRESULT OnStatusChange(DOT11_ADHOC_NETWORK_CONNECTION_STATUS eStatus);

		/// <summary>
		/// Notifies the client that a connection attempt failed. The connection attempt may have been initiated by the client itself or
		/// by another application using the IDot11AdHocNetwork methods or the Native Wifi functions.
		/// </summary>
		/// <param name="eFailReason">A DOT11_ADHOC_CONNECT_FAIL_REASON value that specifies the reason the connection attempt failed.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocnetworknotificationsink-onconnectfail HRESULT
		// OnConnectFail( DOT11_ADHOC_CONNECT_FAIL_REASON eFailReason );
		[PreserveSig]
		HRESULT OnConnectFail(DOT11_ADHOC_CONNECT_FAIL_REASON eFailReason);
	}

	/// <summary>
	/// <para>The <c>IDot11AdHocSecuritySettings</c> interface specifies the security settings for a wireless ad hoc network.</para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-idot11adhocsecuritysettings
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocSecuritySettings")]
	[ComImport, Guid("8F10CC2E-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDot11AdHocSecuritySettings
	{
		/// <summary>
		/// Gets the authentication algorithm associated with the security settings. The authentication algorithm is used to
		/// authenticate machines and users connecting to the ad hoc network associated with an interface.
		/// </summary>
		/// <returns>A pointer to a DOT11_ADHOC_AUTH_ALGORITHM value that specifies the authentication algorithm.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocsecuritysettings-getdot11authalgorithm HRESULT
		// GetDot11AuthAlgorithm( DOT11_ADHOC_AUTH_ALGORITHM *pAuth );
		DOT11_ADHOC_AUTH_ALGORITHM GetDot11AuthAlgorithm();

		/// <summary>
		/// Gets the cipher algorithm associated with the security settings. The cipher algorithm is used to encrypt and decrypt
		/// information sent on the ad hoc network associated with an interface.
		/// </summary>
		/// <returns>A pointer to a DOT11_ADHOC_CIPHER_ALGORITHM value that specifies the cipher algorithm.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-idot11adhocsecuritysettings-getdot11cipheralgorithm HRESULT
		// GetDot11CipherAlgorithm( DOT11_ADHOC_CIPHER_ALGORITHM *pCipher );
		DOT11_ADHOC_CIPHER_ALGORITHM GetDot11CipherAlgorithm();
	}

	/// <summary>
	/// <para>This interface represents the collection of currently visible 802.11 ad hoc network interfaces. It is a standard enumerator.</para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-ienumdot11adhocinterfaces
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IEnumDot11AdHocInterfaces")]
	[ComImport, Guid("8F10CC2C-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumDot11AdHocInterfaces : ICOMEnum<IDot11AdHocInterface>
	{
		/// <summary>
		/// Gets the specified number of elements from the sequence and advances the current position by the number of items retrieved.
		/// If there are fewer than the requested number of elements left in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="cElt">The number of elements requested.</param>
		/// <param name="rgElt">
		/// A pointer to a variable that, on successful return, points to an array of pointers to IDot11AdHocInterface interfaces. The
		/// array is of size cElt.
		/// </param>
		/// <param name="pcEltFetched">A pointer to a variable that specifies the number of elements returned in rgElt.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>A specified interface is not supported.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method could not allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A pointer passed as a parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocinterfaces-next HRESULT Next( ULONG cElt,
		// IDot11AdHocInterface **rgElt, ULONG *pcEltFetched );
		[PreserveSig]
		HRESULT Next(uint cElt, IDot11AdHocInterface[] rgElt, out uint pcEltFetched);

		/// <summary>Skips over the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="cElt">The number of elements to skip.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocinterfaces-skip HRESULT Skip( ULONG cElt );
		[PreserveSig]
		HRESULT Skip(uint cElt);

		/// <summary>Resets to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocinterfaces-reset HRESULT Reset();
		void Reset();

		/// <summary>Creates a new enumeration interface.</summary>
		/// <returns>A pointer that, on successful return, points to an IEnumDot11AdHocInterfaces interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocinterfaces-clone HRESULT Clone(
		// IEnumDot11AdHocInterfaces **ppEnum );
		IEnumDot11AdHocInterfaces Clone();
	}

	/// <summary>
	/// <para>This interface represents the collection of currently visible 802.11 ad hoc networks. It is a standard enumerator.</para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-ienumdot11adhocnetworks
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IEnumDot11AdHocNetworks")]
	[ComImport, Guid("8F10CC28-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumDot11AdHocNetworks : ICOMEnum<IDot11AdHocNetwork>
	{
		/// <summary>
		/// Gets the specified number of elements from the sequence and advances the current position by the number of items retrieved.
		/// If there are fewer than the requested number of elements left in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="cElt">The number of elements requested.</param>
		/// <param name="rgElt">
		/// A pointer to the first element in an array of IDot11AdHocNetwork interfaces. The array is of size cElt. The array must exist
		/// and be of size cElt (at a minimum) before the <c>Next</c> method is called, although the array need not be initialized. Upon
		/// return, the previously existing array will contain pointers to <c>IDot11AdHocNetwork</c> objects.
		/// </param>
		/// <param name="pcEltFetched">A pointer to a variable that specifies the number of elements returned in rgElt.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>A specified interface is not supported.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method could not allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A pointer passed as a parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocnetworks-next HRESULT Next( ULONG cElt,
		// IDot11AdHocNetwork **rgElt, ULONG *pcEltFetched );
		[PreserveSig]
		HRESULT Next(uint cElt, IDot11AdHocNetwork[] rgElt, out uint pcEltFetched);

		/// <summary>Skips over the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="cElt">The number of elements to skip.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocnetworks-skip HRESULT Skip( ULONG cElt );
		[PreserveSig]
		HRESULT Skip(uint cElt);

		/// <summary>Resets to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocnetworks-reset HRESULT Reset();
		void Reset();

		/// <summary>Creates a new enumeration interface.</summary>
		/// <returns>A pointer to a variable that, on successful return, points to an IEnumDot11AdHocNetworks interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocnetworks-clone HRESULT Clone(
		// IEnumDot11AdHocNetworks **ppEnum );
		IEnumDot11AdHocNetworks Clone();
	}

	/// <summary>
	/// <para>
	/// This interface represents the collection of security settings associated with each visible wireless ad hoc network. It is a
	/// standard enumerator.
	/// </para>
	/// <para>
	/// <c>Note</c> Ad hoc mode might not be available in future versions of Windows. Starting with Windows 8.1 and Windows Server 2012
	/// R2, use Wi-Fi Direct instead.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nn-adhoc-ienumdot11adhocsecuritysettings
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IEnumDot11AdHocSecuritySettings")]
	[ComImport, Guid("8F10CC2D-CF0D-42a0-ACBE-E2DE7007384D"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumDot11AdHocSecuritySettings : ICOMEnum<IDot11AdHocSecuritySettings>
	{
		/// <summary>
		/// Gets the specified number of elements from the sequence and advances the current position by the number of items retrieved.
		/// If there are fewer than the requested number of elements left in the sequence, it retrieves the remaining elements.
		/// </summary>
		/// <param name="cElt">The number of elements requested.</param>
		/// <param name="rgElt">
		/// A pointer to a variable that, on successful return, points an array of pointers to IDot11AdHocSecuritySettings interfaces.
		/// The array is of size cElt.
		/// </param>
		/// <param name="pcEltFetched">A pointer to a variable that specifies the number of elements returned in rgElt.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One of the parameters is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>A specified interface is not supported.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>The method could not allocate the memory required to perform this operation.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A pointer passed as a parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocsecuritysettings-next HRESULT Next( ULONG
		// cElt, IDot11AdHocSecuritySettings **rgElt, ULONG *pcEltFetched );
		[PreserveSig]
		HRESULT Next(uint cElt, IDot11AdHocSecuritySettings[] rgElt, out uint pcEltFetched);

		/// <summary>Skips over the next specified number of elements in the enumeration sequence.</summary>
		/// <param name="cElt">The number of elements to skip.</param>
		/// <returns>
		/// <para>Possible return values include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The method failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocsecuritysettings-skip HRESULT Skip( ULONG
		// cElt );
		[PreserveSig]
		HRESULT Skip(uint cElt);

		/// <summary>Resets to the beginning of the enumeration sequence.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocsecuritysettings-reset HRESULT Reset();
		void Reset();

		/// <summary>Creates a new enumeration interface.</summary>
		/// <returns>A pointer that, on successful return, points to an IEnumDot11AdHocSecuritySettings interface.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/adhoc/nf-adhoc-ienumdot11adhocsecuritysettings-clone HRESULT Clone(
		// IEnumDot11AdHocSecuritySettings **ppEnum );
		IEnumDot11AdHocSecuritySettings Clone();
	}

	/// <summary>CLSID_AdHocManager</summary>
	[PInvokeData("adhoc.h", MSDNShortId = "NN:adhoc.IDot11AdHocManager")]
	[ComImport, Guid("DD06A84F-83BD-4d01-8AB9-2389FEA0869E"), ClassInterface(ClassInterfaceType.None)]
	public class Dot11AdHocManager { }
}